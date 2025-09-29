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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン管理マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    [Serializable]
    public class CampaignMngDB : RemoteDB, ICampaignMngDB
    {
        /// <summary>
        /// キャンペーン管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public CampaignMngDB()
            :
            base("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork", "CAMPAIGNMNGRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のキャンペーン管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="campaignMngWork">検索結果</param>
        /// <param name="paracampaignMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object campaignMngWork, object paracampaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignMngWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampaignMngProc(out campaignMngWork, paracampaignMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngDB.Search");
                campaignMngWork = new ArrayList();
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
        /// 指定された条件のキャンペーン管理マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objcampaignMngWork">検索結果</param>
        /// <param name="paracampaignMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchCampaignMngProc(out object objcampaignMngWork, object paracampaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CampaignMngOrderWork campaignMngWork = null;

            ArrayList campaignMngWorkList = new ArrayList();

            if (paracampaignMngWork != null)
            {
                campaignMngWork = paracampaignMngWork as CampaignMngOrderWork;
            }
            else
            {
                campaignMngWork = new CampaignMngOrderWork();
            }

            int status = SearchCampaignMngProc(out campaignMngWorkList, campaignMngWork, readMode, logicalMode, ref sqlConnection);
            objcampaignMngWork = campaignMngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のキャンペーン管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">検索結果</param>
        /// <param name="campaignMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchCampaignMngProc(out ArrayList campaignMngWorkList, CampaignMngOrderWork campaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchCampaignMngProcProc(out campaignMngWorkList, campaignMngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のキャンペーン管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">検索結果</param>
        /// <param name="campaignMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int SearchCampaignMngProcProc(out ArrayList campaignMngWorkList, CampaignMngOrderWork campaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                selectTxt += " SELECT   CAM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,CAM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,CAM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETMONEYRF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETPROFITRF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETCOUNTRF " + Environment.NewLine;
                selectTxt += "         ,CAM.CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.PRICEFLRF " + Environment.NewLine;
                selectTxt += "         ,CAM.RATEVALRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNMNGRF AS CAM" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = CAM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = CAM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = CAM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = CAM.GOODSNORF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, campaignMngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCampaignMngOrderWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            campaignMngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のキャンペーン管理マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CampaignMngWork campaignMngWork = new CampaignMngWork();

                // XMLの読み込み
                campaignMngWork = (CampaignMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignMngWork));
                if (campaignMngWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref campaignMngWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(campaignMngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngDB.Read");
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
        /// 指定された条件のキャンペーン管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref CampaignMngWork campaignMngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref campaignMngWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件のキャンペーン管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="campaignMngWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref CampaignMngWork campaignMngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT   CAM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,CAM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,CAM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,CAM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,CAM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETMONEYRF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETPROFITRF " + Environment.NewLine;
                selectTxt += "         ,CAM.SALESTARGETCOUNTRF " + Environment.NewLine;
                selectTxt += "         ,CAM.CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CAM.PRICEFLRF " + Environment.NewLine;
                selectTxt += "         ,CAM.RATEVALRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNMNGRF AS CAM" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = CAM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = CAM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = CAM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = CAM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = CAM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = CAM.GOODSNORF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  WHERE CAM.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND CAM.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "         AND CAM.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "         AND CAM.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "         AND CAM.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                selectTxt += "         AND CAM.GOODSNORF = @FINDGOODSNO " + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL商品コード
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // 商品番号

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                    findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                    findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                    findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        campaignMngWork = CopyToCampaignMngOrderWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// キャンペーン管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object campaignMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(campaignMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteCampaignMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                CampaignMngWork paraWork = paraList[0] as CampaignMngWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecCampaignMng(ref paraList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                campaignMngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngDB.Write(ref object campaignMngWork)");
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
        /// キャンペーン管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int WriteCampaignMngProc(ref ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteCampaignMngProcProc(ref campaignMngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int WriteCampaignMngProcProc(ref ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (campaignMngWorkList != null)
                {
                    for (int i = 0; i < campaignMngWorkList.Count; i++)
                    {
                        CampaignMngWork campaignMngWork = campaignMngWorkList[i] as CampaignMngWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                        SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL商品コード
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // 商品番号

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != campaignMngWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (campaignMngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE CAMPAIGNMNGRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                            sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                            sqlText += "  , SALESTARGETMONEYRF = @SALESTARGETMONEY " + Environment.NewLine;
                            sqlText += "  , SALESTARGETPROFITRF = @SALESTARGETPROFIT " + Environment.NewLine;
                            sqlText += "  , SALESTARGETCOUNTRF = @SALESTARGETCOUNT " + Environment.NewLine;
                            sqlText += "  , CAMPAIGNCODERF = @CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "  , PRICEFLRF = @PRICEFL " + Environment.NewLine;
                            sqlText += "  , RATEVALRF = @RATEVAL " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                            sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                            sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                            findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                            findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                            findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                            findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                            findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (campaignMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO CAMPAIGNMNGRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,GOODSMGROUPRF " + Environment.NewLine;
                            sqlText += "         ,BLGOODSCODERF " + Environment.NewLine;
                            sqlText += "         ,GOODSMAKERCDRF " + Environment.NewLine;
                            sqlText += "         ,GOODSNORF " + Environment.NewLine;
                            sqlText += "         ,SALESTARGETMONEYRF " + Environment.NewLine;
                            sqlText += "         ,SALESTARGETPROFITRF " + Environment.NewLine;
                            sqlText += "         ,SALESTARGETCOUNTRF " + Environment.NewLine;
                            sqlText += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                            sqlText += "         ,PRICEFLRF " + Environment.NewLine;
                            sqlText += "         ,RATEVALRF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "         ,@GOODSMGROUP " + Environment.NewLine;
                            sqlText += "         ,@BLGOODSCODE " + Environment.NewLine;
                            sqlText += "         ,@GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         ,@GOODSNO " + Environment.NewLine;
                            sqlText += "         ,@SALESTARGETMONEY " + Environment.NewLine;
                            sqlText += "         ,@SALESTARGETPROFIT " + Environment.NewLine;
                            sqlText += "         ,@SALESTARGETCOUNT " + Environment.NewLine;
                            sqlText += "         ,@CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "         ,@PRICEFL " + Environment.NewLine;
                            sqlText += "         ,@RATEVAL " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // 商品番号
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);  // 売上目標金額
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);  // 売上目標粗利額
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);  // 売上目標数量
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);  // 価格（浮動）
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);  // 掛率
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignMngWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                        paraGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetMoney);  // 売上目標金額
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetProfit);  // 売上目標粗利額
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.SalesTargetCount);  // 売上目標数量
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.CampaignCode);  // キャンペーンコード
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.PriceFl);  // 価格（浮動）
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.RateVal);  // 掛率
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignMngWork);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            campaignMngWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int UpdateAllSecCampaignMng(ref ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (campaignMngWorkList != null)
                {
                    CampaignMngWork campaignMngWork = campaignMngWorkList[0] as CampaignMngWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;
                    sqlText += " UPDATE CAMPAIGNMNGRF SET " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                    sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                    sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                    sqlText += "  , SALESTARGETMONEYRF = @SALESTARGETMONEY " + Environment.NewLine;
                    sqlText += "  , SALESTARGETPROFITRF = @SALESTARGETPROFIT " + Environment.NewLine;
                    sqlText += "  , SALESTARGETCOUNTRF = @SALESTARGETCOUNT " + Environment.NewLine;
                    sqlText += "  , CAMPAIGNCODERF = @CAMPAIGNCODE " + Environment.NewLine;
                    sqlText += "  , PRICEFLRF = @PRICEFL " + Environment.NewLine;
                    sqlText += "  , RATEVALRF = @RATEVAL " + Environment.NewLine;
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "         AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                    sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                    sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                    sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)campaignMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // 商品番号
                    SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);  // 売上目標金額
                    SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);  // 売上目標粗利額
                    SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);  // 売上目標数量
                    SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);  // 価格（浮動）
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);  // 掛率
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignMngWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                    paraGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号
                    paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetMoney);  // 売上目標金額
                    paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetProfit);  // 売上目標粗利額
                    paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.SalesTargetCount);  // 売上目標数量
                    paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.CampaignCode);  // キャンペーンコード
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.PriceFl);  // 価格（浮動）
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.RateVal);  // 掛率
                    #endregion

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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// キャンペーン管理マスタ情報を論理削除します
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object campaignMngWork)
        {
            return LogicalDeleteCampaignMng(ref campaignMngWork, 0);
        }

        /// <summary>
        /// 論理削除キャンペーン管理マスタ情報を復活します
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除キャンペーン管理マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object campaignMngWork)
        {
            return LogicalDeleteCampaignMng(ref campaignMngWork, 1);
        }

        /// <summary>
        /// キャンペーン管理マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="campaignMngWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteCampaignMng(ref object campaignMngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(campaignMngWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCampaignMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "CampaignMngDB.LogicalDeleteCampaignMng :" + procModestr);

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
        /// キャンペーン管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeleteCampaignMngProc(ref ArrayList campaignMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteCampaignMngProcProc(ref campaignMngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteCampaignMngProcProc(ref ArrayList campaignMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (campaignMngWorkList != null)
                {
                    for (int i = 0; i < campaignMngWorkList.Count; i++)
                    {
                        CampaignMngWork campaignMngWork = campaignMngWorkList[i] as CampaignMngWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                        SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL商品コード
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // 商品番号

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != campaignMngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CAMPAIGNMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                            findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                            findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                            findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                            findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                            findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
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
                            else if (logicalDelCd == 0) campaignMngWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else campaignMngWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) campaignMngWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignMngWork);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            campaignMngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// キャンペーン管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">キャンペーン管理マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : キャンペーン管理マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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

                status = DeleteCampaignMngProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CampaignMngDB.Delete");
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
        /// キャンペーン管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">キャンペーン管理マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : キャンペーン管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeleteCampaignMngProc(ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteCampaignMngProcProc(campaignMngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="campaignMngWorkList">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int DeleteCampaignMngProcProc(ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < campaignMngWorkList.Count; i++)
                {
                    CampaignMngWork campaignMngWork = campaignMngWorkList[i] as CampaignMngWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL商品コード
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // 商品番号

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                    findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                    findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                    findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != campaignMngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // 拠点コード
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // 商品中分類コード
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL商品コード
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // 商品メーカーコード
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // 商品番号
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CampaignMngOrderWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignMngOrderWork CampaignMngOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "CAM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CampaignMngOrderWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(CampaignMngOrderWork.SectionCode) == false)
            {
                retstring += "AND CAM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = CampaignMngOrderWork.SectionCode.Trim();
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND CAM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND CAM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // 商品中分類コード
            if (CampaignMngOrderWork.St_GoodsMGroup != 0)
            {
                retstring += "AND CAM.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.St_GoodsMGroup);
            }
            if (CampaignMngOrderWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND CAM.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.Ed_GoodsMGroup);
            }

            // BLグループコード
            if (CampaignMngOrderWork.St_BLGroupCode != 0)
            {
                retstring += "AND CAM.BLGROUPCODERF >= @FINDSTBLGROUPCODE ";
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@FINDSTBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.St_BLGroupCode);
            }
            if (CampaignMngOrderWork.Ed_BLGroupCode != 0)
            {
                retstring += "AND CAM.BLGROUPCODERF <= @FINDEDBLGROUPCODE ";
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@FINDEDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.Ed_BLGroupCode);
            }

            // BL商品コード
            if (CampaignMngOrderWork.St_BLGoodsCode != 0)
            {
                retstring += "AND CAM.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.St_BLGoodsCode);
            }
            if (CampaignMngOrderWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND CAM.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.Ed_BLGoodsCode);
            }

            // メーカーコード
            if (CampaignMngOrderWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND CAM.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.St_GoodsMakerCd);
            }
            if (CampaignMngOrderWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND CAM.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.Ed_GoodsMakerCd);
            }

            // キャンペーンコード
            if (CampaignMngOrderWork.St_CampaignCode != 0)
            {
                retstring += "AND CAM.CAMPAIGNCODERF >= @FINDSTCAMPAIGNCODE ";
                SqlParameter paraStCampaignCode = sqlCommand.Parameters.Add("@FINDSTCAMPAIGNCODE", SqlDbType.Int);
                paraStCampaignCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.St_CampaignCode);
            }
            if (CampaignMngOrderWork.Ed_CampaignCode != 0)
            {
                retstring += "AND CAM.CAMPAIGNCODERF <= @FINDEDCAMPAIGNCODE ";
                SqlParameter paraEdCampaignCode = sqlCommand.Parameters.Add("@FINDEDCAMPAIGNCODE", SqlDbType.Int);
                paraEdCampaignCode.Value = SqlDataMediator.SqlSetInt32(CampaignMngOrderWork.Ed_CampaignCode);
            }


		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngOrderWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignMngWork wkCampaignMngWork = new CampaignMngWork();

            #region クラスへ格納
            wkCampaignMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkCampaignMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkCampaignMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkCampaignMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkCampaignMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkCampaignMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkCampaignMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkCampaignMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkCampaignMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkCampaignMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkCampaignMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
            wkCampaignMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
            wkCampaignMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 商品番号
            wkCampaignMngWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));  // 売上目標金額
            wkCampaignMngWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));  // 売上目標粗利額
            wkCampaignMngWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));  // 売上目標数量
            wkCampaignMngWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
            wkCampaignMngWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));  // 価格（浮動）
            wkCampaignMngWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));  // 掛率
            wkCampaignMngWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
            wkCampaignMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // 商品中分類名称
            wkCampaignMngWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL商品コード名称
            wkCampaignMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
            wkCampaignMngWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BLグループコード
            wkCampaignMngWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  // BLグループ名称
            #endregion

            return wkCampaignMngWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignMngWork[] CampaignMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CampaignMngWork)
                    {
                        CampaignMngWork wkCampaignMngWork = paraobj as CampaignMngWork;
                        if (wkCampaignMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignMngWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CampaignMngWorkArray = (CampaignMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CampaignMngWork[]));
                        }
                        catch (Exception) { }
                        if (CampaignMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CampaignMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CampaignMngWork wkCampaignMngWork = (CampaignMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(CampaignMngWork));
                                if (wkCampaignMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCampaignMngWork);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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

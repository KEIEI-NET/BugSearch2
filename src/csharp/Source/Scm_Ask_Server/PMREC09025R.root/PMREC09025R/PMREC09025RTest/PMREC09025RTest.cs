using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

using NUnit.Framework;

using Broadleaf.Application.NUnit;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    [TestFixture]
    public class RecBgnGdsDBTest
    {
        #region SQL
        const string insertScmEpCNect = " INSERT INTO [SCMEPCNECTRF] "
                                     + "            ([CREATEDATETIMERF] "
                                     + "            ,[UPDATEDATETIMERF] "
                                     + "            ,[LOGICALDELETECODERF] "
                                     + "            ,[CNECTORIGINALEPCDRF] "
                                     + "            ,[CNECTORIGINALEPNMRF] "
                                     + "            ,[CNECTOTHEREPCDRF] "
                                     + "            ,[CNECTOTHEREPNMRF] "
                                     + "            ,[DISCDIVCDRF] "
                                     + "            ,[FIXPARTSSHOPDIVCDRF] "
                                     + "            ,[PMBIGCAROPTIONDIVCDRF]) "
                                     + "      VALUES "
                                     + "            ({0} "
                                     + "            ,{1} "
                                     + "            ,{2} "
                                     + "            ,'{3}' "
                                     + "            ,'{4}' "
                                     + "            ,'{5}' "
                                     + "            ,'{6}' "
                                     + "            ,{7} "
                                     + "            ,{8} "
                                     + "            ,{9}) ";
        const string insertScmEpScCnt = " INSERT INTO [SCMEPSCCNTRF] "
                                         + "            ([CREATEDATETIMERF] "
                                         + "            ,[UPDATEDATETIMERF] "
                                         + "            ,[LOGICALDELETECODERF] "
                                         + "            ,[CNECTORIGINALEPCDRF] "
                                         + "            ,[CNECTORIGINALSECCDRF] "
                                         + "            ,[CNECTORIGINALSECNMRF] "
                                         + "            ,[CNECTOTHEREPCDRF] "
                                         + "            ,[CNECTOTHERSECCDRF] "
                                         + "            ,[CNECTOTHERSECNMRF] "
                                         + "            ,[DISCDIVCDRF] "
                                         + "            ,[SCMCOMMMETHODRF] "
                                         + "            ,[PCCUOECOMMMETHODRF] "
                                         + "            ,[RCSCMCOMMMETHODRF] "
                                         + "            ,[DISPLAYORDERRF] "
                                         + "            ,[PRDISPSYSTEMRF] "
                                         + "            ,[TABUSEDIVRF] "
                                         + "            ,[OLDNEWSTATUSRF] "
                                         + "            ,[USUALMNALSTATUSRF] "
                                         + "            ,[PMDBIDRF] "
                                         + "            ,[PMUPLOADDIVRF]) "
                                         + "      VALUES "
                                         + "            ({0} "
                                         + "            ,{1} "
                                         + "            ,{2} "
                                         + "            ,'{3}' "
                                         + "            ,'{4}' "
                                         + "            ,'{5}' "
                                         + "            ,'{6}' "
                                         + "            ,'{7}' "
                                         + "            ,'{8}' "
                                         + "            ,{9} "
                                         + "            ,{10} "
                                         + "            ,{11} "
                                         + "            ,{12} "
                                         + "            ,{13} "
                                         + "            ,{14} "
                                         + "            ,{15} "
                                         + "            ,{16} "
                                         + "            ,{17} "
                                         + "            ,'{18}' "
                                         + "            ,{19}) ";

        const string insertRecBgnGrp = " INSERT INTO [RECBGNGDSRF] "
                                     + "            ([CREATEDATETIMERF] "
                                     + "            ,[UPDATEDATETIMERF] "
                                     + "            ,[LOGICALDELETECODERF] "
                                     + "            ,[INQOTHEREPCDRF] "
                                     + "            ,[INQOTHERSECCDRF] "
                                     + "            ,[GOODSNORF] "
                                     + "            ,[GOODSMAKERCDRF] "
                                     + "            ,[GOODSMAKERNMRF] "
                                     + "            ,[GOODSNAMERF] "
                                     + "            ,[BLGROUPCODERF] "
                                     + "            ,[BLGOODSCODERF] "
                                     + "            ,[GOODSCOMMENTRF] "
                                     + "            ,[MKRSUGGESTRTPRICRF] "
                                     + "            ,[LISTPRICERF] "
                                     + "            ,[UNITCALCRATERF] "
                                     + "            ,[UNITPRICERF] "
                                     + "            ,[APPLYSTADATERF] "
                                     + "            ,[APPLYENDDATERF] "
                                     + "            ,[MODELFITDIVRF] "
                                     + "            ,[CUSTRATEGRPCODERF] "
                                     + "            ,[DISPLAYDIVCODERF] "
                                     + "            ,[BRGNGOODSGRPCODERF]) "
                                     + "      VALUES "
                                     + "            ({0} "
                                     + "            ,{1} "
                                     + "            ,{2} "
                                     + "            ,'{3}' "
                                     + "            ,'{4}' "
                                     + "            ,'{5}' "
                                     + "            ,{6} "
                                     + "            ,'{7}' "
                                     + "            ,'{8}' "
                                     + "            ,{9} "
                                     + "            ,{10} "
                                     + "            ,'{11}' "
                                     + "            ,{12} "
                                     + "            ,{13} "
                                     + "            ,{14} "
                                     + "            ,{15} "
                                     + "            ,{16} "
                                     + "            ,{17} "
                                     + "            ,{18} "
                                     + "            ,{19} "
                                     + "            ,{20} "
                                     + "            ,{21}) ";
        const string insertRecBgnCust = " INSERT INTO [RECBGNCUSTRF] "
                                     + "            ([CREATEDATETIMERF] "
                                     + "            ,[UPDATEDATETIMERF] "
                                     + "            ,[LOGICALDELETECODERF] "
                                     + "            ,[INQORIGINALEPCDRF] "
                                     + "            ,[INQORIGINALSECCDRF] "
                                     + "            ,[INQOTHEREPCDRF] "
                                     + "            ,[INQOTHERSECCDRF] "
                                     + "            ,[GOODSNORF] "
                                     + "            ,[GOODSMAKERCDRF] "
                                     + "            ,[GOODSAPPLYSTADATERF] "
                                     + "            ,[CUSTOMERCODERF] "
                                     + "            ,[MNGSECTIONCODERF] "
                                     + "            ,[MKRSUGGESTRTPRICRF] "
                                     + "            ,[LISTPRICERF] "
                                     + "            ,[UNITCALCRATERF] "
                                     + "            ,[UNITPRICERF] "
                                     + "            ,[APPLYSTADATERF] "
                                     + "            ,[APPLYENDDATERF] "
                                     + "            ,[BRGNGOODSGRPCODERF] "
                                     + "            ,[DISPLAYDIVCODERF]) "
                                     + "      VALUES "
                                     + "            ({0} "
                                     + "            ,{1} "
                                     + "            ,{2} "
                                     + "            ,'{3}' "
                                     + "            ,'{4}' "
                                     + "            ,'{5}' "
                                     + "            ,'{6}' "
                                     + "            ,'{7}' "
                                     + "            ,{8} "
                                     + "            ,{9} "
                                     + "            ,{10} "
                                     + "            ,'{11}' "
                                     + "            ,{12} "
                                     + "            ,{13} "
                                     + "            ,{14} "
                                     + "            ,{15} "
                                     + "            ,{16} "
                                     + "            ,{17} "
                                     + "            ,{18} "
                                     + "            ,{19}) ";

        const string insertPmIsoProc = " INSERT INTO [PMISOLPRCRF] "
                            + "            ([CREATEDATETIMERF] "
                            + "            ,[UPDATEDATETIMERF] "
                            + "            ,[LOGICALDELETECODERF] "
                            + "            ,[ENTERPRISECODERF] "
                            + "            ,[SECTIONCODERF] "
                            + "            ,[MAKERCODERF] "
                            + "            ,[UPPERLIMITPRICERF] "
                            + "            ,[PMFRACTIONPROCUNITRF] "
                            + "            ,[PMFRACTIONPROCCDRF] "
                            + "            ,[LISTPRICEUPRATERF]) "
                            + "      VALUES "
                            + "            ({0} "
                            + "            ,{1} "
                            + "            ,{2} "
                            + "            ,'{3}' "
                            + "            ,'{4}' "
                            + "            ,{5} "
                            + "            ,{6} "
                            + "            ,{7} "
                            + "            ,{8} "
                            + "            ,{9}) ";

        const string deleteRecBgnGrp = " DELETE FROM  [RECBGNGDSRF]  WHERE INQOTHEREPCDRF='{3}' AND INQOTHERSECCDRF='{4}' AND GOODSNORF='{5}' ";

        const string deleteRecBgnCust = " DELETE FROM  [RECBGNCUSTRF]  WHERE INQOTHEREPCDRF='{5}' AND INQOTHERSECCDRF='{6}' AND GOODSNORF='{7}' ";

        const string deletePMIso = "DELETE FROM [PMISOLPRCRF] WHERE ENTERPRISECODERF='{3}' AND SECTIONCODERF='{4}'";
        #endregion

        /// <summary>企業連結マスタ設定</summary>
        private string[] SCMEPCNECTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	札幌開発 NUnit-001	5111150842021003	札幌開発 NUnit-001	0	0	0",//有効
            "634643105635632500	634643105635632500	1	5111150825430093	札幌開発 NUnit-001	5111150842021004	札幌開発 NUnit-002	0	0	0",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	札幌開発 NUnit-001	5111150842021005	札幌開発 NUnit-003	1	0	0",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	札幌開発 NUnit-001	5111150842021006	札幌開発 NUnit-004	0	0	0",//有効
            "634643105635632500	634643105635632500	1	5111150825430094	札幌開発 NUnit-002	5111150842021004	札幌開発 NUnit-001	0	0	0",//無効
            "634643105635632500	634643105635632500	0	5111150825430095	札幌開発 NUnit-003	5111150842021004	札幌開発 NUnit-001	1	0	0",//無効
            "634643105635632500	634643105635632500	0	5111150825430096	札幌開発 NUnit-004	5111150842021003	札幌開発 NUnit-001	0	0	0" //有効
        };

        /// <summary>企業拠点連結マスタ設定</summary>
        private string[] SCMEPSCCNTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021003	01    	01拠点	0	1	1	1	0	10	1	0	0	NUNIT	1",//有効
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021003	02    	02拠点	0	0	0	1	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021003	03    	03拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//有効
            "634643105635632500	634643105635632500	1	5111150825430093	000001	本社	5111150842021003	04    	04拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021003	05    	05拠点	1	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	000002	本社	5111150842021003	01    	01拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//有効
            "634643105635632500	634643105635632500	0	5111150825430093	000002	本社	5111150842021004	01    	01拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//企業で無効
            "634643105635632500	634643105635632500	0	5111150825430093	000002	本社	5111150842021004	02    	02拠点	1	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	1	5111150825430093	000002	本社	5111150842021004	03    	03拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	000002	本社	5111150842021005	01    	01拠点	1	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021006	01    	01拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//有効
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150842021006	02    	02拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//有効
            "634643105635632500	634643105635632500	1	5111150825430094	000001	本社	5111150842021004	01    	01拠点	0	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430095	000002	本社	5111150842021004	01    	01拠点	1	1	1	0	0	10	1	0	0	NUNIT	1",//無効
            "634643105635632500	634643105635632500	0	5111150825430096	000001	本社	5111150842021003	01    	01拠点	0	1	1	1	0	10	1	0	0	NUNIT	1"//有効
        };


        [TestFixtureSetUp]
        public void SetUpClass()
        {
            this.TearDownClass();

            #region テストデータ作成
            NUnitUtils.ExecuteAdHocSql(insertScmEpCNect, SCMEPCNECTRF);
            NUnitUtils.ExecuteAdHocSql(insertScmEpScCnt, SCMEPSCCNTRF);
            #endregion
        }

        [TestFixtureTearDown]
        public void TearDownClass()
        {
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPCNECTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] { "" });
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPSCCNTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] { "" });
        }


        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// 条件：連結企業無し
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = 空リスト
        /// </summary>
        [Test(Description = "接続企業・拠点が無い場合")]
        public void SearchForBuyerProc_接続情報無()
        {
            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430095";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 0);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }

        /// <summary>
        /// 条件：連結企業無し
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = 空リスト
        /// </summary>
        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定無()
        {
            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 0);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }

        /// <summary>
        /// 条件：公開お買得商品有り
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = 公開情報(企業拠点展開処理有り)
        /// </summary>
        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_公開()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1000	1000	1000	100	20150101	20150301	0	0	0	1	NULL"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 2);

                RecBgnGdsWork work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.GoodsMakerCd, 1);
                Assert.AreEqual(work.GoodsComment, "12コメント");
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 1000);

                work = ((ArrayList)answer)[1] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.GoodsMakerCd, 1);
                Assert.AreEqual(work.GoodsComment, "12コメント");
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 1000);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
            }
        }


        /// <summary>
        /// 条件：連結企業無し
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = 空リスト
        /// </summary>
        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_非公開()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1000	1000	1000	100	20150101	20150301	0	0	1	1	NULL"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 0);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
            }
        }


        /// <summary>
        /// 条件：公開お買得商品有り
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = 公開情報(企業拠点展開処理有り)
        /// </summary>
        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_全体非公開_一部公開()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1000	1000	1000	100	20150101	20150301	0	0	1	1	NULL"
            };

            string[] RECBGNCUSTRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150825430093	000002	5111150842021003	01    	HINBAN-001	1	20150101	1	01   	999999	100	100	100	20150201	20150228	0	0",
                "634643105635632500	634643105635632500	0	5111150825430096	000001	5111150842021003	01    	HINBAN-001	1	20150101	1	01   	999999	100	100	100	20150201	20150228	0	0"
            };


            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(insertRecBgnCust, RECBGNCUSTRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 1);

                RecBgnGdsWork  work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.GoodsMakerCd, 1);
                Assert.AreEqual(work.GoodsComment, "12コメント");
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 999999);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(deleteRecBgnCust, RECBGNCUSTRF);
            }
        }

        /// <summary>
        /// 条件：公開お買得商品有り
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = 公開情報(企業拠点展開処理有り)
        /// </summary>
        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_拠点絞込み()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1000	1000	1000	100	20150101	20150301	0	0	0	1	NULL"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            paraObj.InqOriginalSecCd = "000002";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 1);

                RecBgnGdsWork work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.GoodsMakerCd, 1);
                Assert.AreEqual(work.GoodsComment, "12コメント");
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 1000);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
            }
        }

        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_公開_離島価格設定済()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1000	1000	1000	100	20150101	20150301	0	0	0	1	NULL"
            };
            string[] PMISOLPRCRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	1	1000	1	2	120"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            paraObj.InqOriginalSecCd = "000001";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(insertPmIsoProc, PMISOLPRCRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 1);

                RecBgnGdsWork work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 1200);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(deletePMIso, PMISOLPRCRF);
            }
        }

        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_公開_離島価格設定済_複数()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	2000	2000	1000	100	20150101	20150301	0	0	0	1	NULL"
            };
            string[] PMISOLPRCRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	1	1000	1	2	120",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	1	2000	1	2	130",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	1	3000	1	2	140"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            paraObj.InqOriginalSecCd = "000001";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(insertPmIsoProc, PMISOLPRCRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 1);

                RecBgnGdsWork work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsNo, "HINBAN-001");
                Assert.AreEqual(work.MkrSuggestRtPric, 2600);//★130%計算
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(deletePMIso, PMISOLPRCRF);
            }
        }


        [Test()]
        public void SearchForBuyerProc_接続情報有_レコメンド設定全社共通_公開_離島価格設定済_端数処理計算()
        {
            string[] RECBGNGDSRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-001	1	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	2	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	3	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	4	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	5	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	6	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	7	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	8	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	HINBAN-002	9	トヨタ	2	0	12	12コメント	1555	1555	1555	100	20150101	20150301	0	0	0	1	NULL",
            };
            string[] PMISOLPRCRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150842021003	01    	1	100000	100	1	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	2	100000	100	3	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	3	100000	1	1	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	4	100000	1	2	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	5	100000	10	1	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	6	100000	100	2	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	7	100000	1	3	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	8	100000	10	3	150",
                "634643105635632500	634643105635632500	0	5111150842021003	01    	9	100000	10	2	150"
            };

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            object answer = new ArrayList() as object;
            RecBgnGdsSearchParaWork paraObj = new RecBgnGdsSearchParaWork();
            paraObj.InqOriginalEpCd = "5111150825430093";
            paraObj.InqOriginalSecCd = "000001";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(insertPmIsoProc, PMISOLPRCRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyperProc(out answer, (object)paraObj, logicalMode, ref sqlConnection, out count, ref errMsg);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 9);

                RecBgnGdsWork  work = ((ArrayList)answer)[0] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 1);
                Assert.AreEqual(work.MkrSuggestRtPric, 2300);//1555*1.5 = 2332.5 100円単位で切捨て

                work = ((ArrayList)answer)[1] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 2);
                Assert.AreEqual(work.MkrSuggestRtPric, 2400);//1555*1.5 = 2332.5 100円単位で切り上げ

                work = ((ArrayList)answer)[2] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 3);
                Assert.AreEqual(work.MkrSuggestRtPric, 2332);//1555*1.5 = 2332.5 1円単位で切捨て

                work = ((ArrayList)answer)[3] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 4);
                Assert.AreEqual(work.MkrSuggestRtPric, 2333);//1555*1.5 = 2332.5 1円単位で四捨五入

                work = ((ArrayList)answer)[4] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 5);
                Assert.AreEqual(work.MkrSuggestRtPric, 2330);//1555*1.5 = 2332.5 10円単位で切捨て

                work = ((ArrayList)answer)[5] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 6);
                Assert.AreEqual(work.MkrSuggestRtPric, 2300);//1555*1.5 = 2332.5 100円単位で四捨五入

                work = ((ArrayList)answer)[6] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 7);
                Assert.AreEqual(work.MkrSuggestRtPric, 2333);//1555*1.5 = 2332.5 1円単位で切り上げ

                work = ((ArrayList)answer)[7] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 8);
                Assert.AreEqual(work.MkrSuggestRtPric, 2340);//1555*1.5 = 2332.5 10円単位で切り上げ

                work = ((ArrayList)answer)[8] as RecBgnGdsWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.GoodsMakerCd, 9);
                Assert.AreEqual(work.MkrSuggestRtPric, 2330);//1555*1.5 = 2332.5 10円単位で四捨五入

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGDSRF);
                NUnitUtils.ExecuteAdHocSql(deletePMIso, PMISOLPRCRF);
            }
        }

        [Test()]
        public void WriteProc_動作確認()
        {

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            RecBgnGdsPMWork paraObj = new RecBgnGdsPMWork();

            object answer = new RecBgnGdsPMWork() as object;

            paraObj.LogicalDeleteCode = 0;
            paraObj.InqOtherEpCd = "999999999999999";
            paraObj.InqOtherSecCd = "99999";
            paraObj.GoodsNo = "9999";
            paraObj.GoodsMakerCd = 9;
            paraObj.GoodsName = "";
            paraObj.GoodsComment = "";
            paraObj.UnitPrice = 5000;
            paraObj.ApplyStaDate = 0;
            paraObj.DisplayDivCode = 0;

            answer = paraObj;
            #endregion

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                int status = remote.WriteProc(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.LogicalDeleteProc(ref answer, 0, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.RevivalLogicalDeleteProc(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.DeleteProc(answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.ReadDBBeforeSave(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

            }
            finally
            {
                // ロールバック
                sqlTransaction.Rollback();

                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }

        [Test()]
        public void WriteProcCust_動作確認()
        {

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            RecBgnCustPMWork paraObj = new RecBgnCustPMWork();

            object answer = new RecBgnCustPMWork() as object;

            paraObj.LogicalDeleteCode = 0;
            paraObj.InqOriginalEpCd = "999999999999999";
            paraObj.InqOriginalSecCd = "99999";
            paraObj.InqOtherEpCd = "999999999999999";
            paraObj.InqOtherSecCd = "99999";
            paraObj.GoodsNo = "9999";
            paraObj.GoodsMakerCd = 9;
            paraObj.GoodsApplyStaDate = 20150225;
            paraObj.CustomerCode = 0;
            paraObj.UnitPrice = 5000;
            paraObj.ApplyStaDate = 20150225;

            answer = paraObj;
            #endregion

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                int status = remote.WriteProcCust(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                RecBgnGdsPMWork paraObj2 = new RecBgnGdsPMWork();

                object answer2 = new RecBgnGdsPMWork() as object;

                paraObj2.LogicalDeleteCode = 0;
                paraObj2.InqOtherEpCd = "999999999999999";
                paraObj2.InqOtherSecCd = "99999";
                paraObj2.GoodsNo = "9999";
                paraObj2.GoodsMakerCd = 9;
                paraObj2.GoodsName = "";
                paraObj2.GoodsComment = "";
                paraObj2.UnitPrice = 5000;
                paraObj2.ApplyStaDate = 0;
                paraObj2.DisplayDivCode = 0;

                answer2 = paraObj2;

                status = remote.LogicalDeleteProcCust(ref answer2, 0, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.RevivalLogicalDeleteProcCust(ref answer2, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.DeleteProcCust(answer2, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.ReadDBBeforeSaveCust(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_ERROR);

            }
            finally
            {
                // ロールバック
                sqlTransaction.Rollback();

                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }

        [Test()]
        public void WriteProcIsol_動作確認()
        {

            #region  事前準備
            RecBgnGdsDB remote = new RecBgnGdsDB();
            PmIsolPrcWork paraObj = new PmIsolPrcWork();

            object answer = new PmIsolPrcWork() as object;

            paraObj.LogicalDeleteCode = 0;
            paraObj.EnterpriseCode = "999999999999999";
            paraObj.SectionCode = "99999";
            paraObj.MakerCode = 9;
            paraObj.UpperLimitPrice = 5000;
            paraObj.PMFractionProcUnit = 5000;
            paraObj.PMFractionProcUnit = 1;
            paraObj.ListPriceUpRate = 99.9;

            answer = paraObj;
            #endregion

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                int status = remote.WriteProcIsol(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.DeleteProcIsol(paraObj.MakerCode, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

                status = remote.ReadDBBeforeSaveIsol(ref answer, ref sqlConnection, ref sqlTransaction);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);

            }
            finally
            {
                // ロールバック
                sqlTransaction.Rollback();

                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }


    }
}

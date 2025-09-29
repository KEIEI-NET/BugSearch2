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
    public class RecGoodsLkDBTest
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
        const string insertScmEpScCnt = " INSERT INTO [dbo].[SCMEPSCCNTRF] "
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

        const string insertRecGoodsLk = " INSERT INTO [dbo].[RECGOODSLKRF] "
                                     + "            ([CREATEDATETIMERF] "
                                     + "            ,[UPDATEDATETIMERF] "
                                     + "            ,[LOGICALDELETECODERF] "
                                     + "            ,[INQORIGINALEPCDRF] "
                                     + "            ,[INQORIGINALSECCDRF] "
                                     + "            ,[INQOTHEREPCDRF] "
                                     + "            ,[INQOTHERSECCDRF] "
                                     + "            ,[CUSTOMERCODERF] "
                                     + "            ,[RECSOURCEBLGOODSCDRF] "
                                     + "            ,[RECDESTBLGOODSCDRF] "
                                     + "            ,[RECDESTBLGOODSNMRF] "
                                     + "            ,[GOODSCOMMENTRF]) "
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
                                     + "            ,{9} "
                                     + "            ,'{10}' "
                                     + "            ,'{11}') ";
        const string deleteRecGoodsLk = " DELETE FROM  [RECGOODSLKRF]  WHERE INQORIGINALEPCDRF='{3}' AND INQORIGINALSECCDRF='{4}' AND INQOTHEREPCDRF='{5}' AND INQOTHERSECCDRF='{6}' AND RECSOURCEBLGOODSCDRF={8}";
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
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPCNECTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] {"" });
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPSCCNTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] {"" });

            #region テストデータ作成
            NUnitUtils.ExecuteAdHocSql(insertScmEpCNect, SCMEPCNECTRF);
            NUnitUtils.ExecuteAdHocSql(insertScmEpScCnt, SCMEPSCCNTRF);
            #endregion
        }

        [TestFixtureTearDown]
        public void TearDownClass()
        {
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPCNECTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] { ""});
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPSCCNTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] { ""});
        }


        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }


        [Test]
        public void TestConstructor()
        {
            Assert.NotNull(new RecGoodsLkDB());
        }


        /// <summary>
        /// 条件：連結企業無し
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = 空リスト
        /// </summary>
        [Test(Description = "接続企業・拠点が無い場合")]
        public void SearchProc_接続情報無()
        {
            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430095";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 0);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定無し
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = 空リスト
        /// </summary>
        [Test]
        public void SearchProc_接続情報有_レコメンド設定無()
        {
            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 0);
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);
            }
        }

        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：得意先指定
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = 1件取得
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_得意先指定()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	11	10-11	得意先指定パターン",
                "635596754384768818	635596754384768819	1	5111150825430093	000001	5111150842021003	01    	1	10	12	10-12	得意先指定パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	01    	1	10	13	10-13	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 1);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "得意先指定パターン");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PM全社共通(SFは得意先指定)
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PM全社共通()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	00    	1	10	11	10-11	PM全社共通パターン",
                "635596754384768818	635596754384768819	1	5111150825430093	000001	5111150842021003	00    	1	10	12	10-12	PM全社共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	PM全社共通パターン"
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 2);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "PM全社共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "PM全社共通パターン");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：SF全社設定(PMは拠点指定)
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_SF共通()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	01    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン"
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 2);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン"
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 3);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 4);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "得意先指定パターン");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[3] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定、SF拠点絞込み
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定_拠点絞込み01()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            paraRecGoodsLkWork.InqOriginalSecCd = "000001";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 3);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "得意先指定パターン");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定、SF拠点絞込み
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定_拠点絞込み02()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            paraRecGoodsLkWork.InqOriginalSecCd = "000002";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 1);
                RecGoodsLkWork  work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定、PM複数企業有
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定_複数設定()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 6);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "得意先指定パターン");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[3] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021006");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 15);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-15");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");

                work = ((ArrayList)recGoodsLkWorkList)[4] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021006");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 16);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-16");
                Assert.AreEqual(work.GoodsComment, "得意先指定パターン");


                work = ((ArrayList)recGoodsLkWorkList)[5] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定、PM複数企業有、SF拠点での絞り込み
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定_複数設定_SF拠点絞込み02()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            paraRecGoodsLkWork.InqOriginalSecCd = "000002";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 1);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// 条件：連結企業有、レコメンド設定有り：PMSF全社設定+個別設定、PM複数企業有、SF拠点での絞り込み、PM企業拠点での絞り込み
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF側、PM側の有効拠点による展開処理が行われること
        /// </summary>
        [Test]
        public void SearchProc_レコメンド設定有り_PMSF共通_個別設定_複数設定_SF拠点絞込み02_PM企業拠点絞込み()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF共通パターン",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	得意先指定パターン",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF共通パターン",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	得意先指定パターン",
            };

            #region  事前準備
            RecGoodsLkDB remote = new RecGoodsLkDB();
            object recGoodsLkWorkList = new ArrayList() as object;
            RecGoodsLkWork paraRecGoodsLkWork = new RecGoodsLkWork();
            paraRecGoodsLkWork.InqOriginalEpCd = "5111150825430093";
            paraRecGoodsLkWork.InqOriginalSecCd = "000002";
            paraRecGoodsLkWork.InqOtherEpCd = "5111150842021003";
            paraRecGoodsLkWork.InqOtherSecCd = "01    ";
            int readMode = 0;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecGoodsLk, RECGOODSLKRF);

                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchForBuyerProc(out recGoodsLkWorkList, paraRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(recGoodsLkWorkList as ArrayList);
                Assert.AreEqual(((ArrayList)recGoodsLkWorkList).Count, 1);
                RecGoodsLkWork work = ((ArrayList)recGoodsLkWorkList)[0] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//★企業拠点連結マスタによる展開処理
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF共通パターン");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }
    }
}

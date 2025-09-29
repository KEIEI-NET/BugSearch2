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
    public class RecBgnGrpDBTest
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

        const string insertRecBgnGrp = " INSERT INTO [RECBGNGRPRF] "
                                     + "            ([CREATEDATETIMERF] "
                                     + "            ,[UPDATEDATETIMERF] "
                                     + "            ,[LOGICALDELETECODERF] "
                                     + "            ,[INQORIGINALEPCDRF] "
                                     + "            ,[INQORIGINALSECCDRF] "
                                     + "            ,[BRGNGOODSGRPCODERF] "
                                     + "            ,[DISPLAYORDERRF] "
                                     + "            ,[BRGNGOODSGRPTITLERF] "
                                     + "            ,[BRGNGOODSGRPTAGRF] "
                                     + "            ,[BRGNGOODSGRPCOMMENTRF]) "
                                     + "      VALUES "
                                     + "            ({0} "
                                     + "            ,{1} "
                                     + "            ,{2} "
                                     + "            ,'{3}' "
                                     + "            ,'{4}' "
                                     + "            ,{5} "
                                     + "            ,{6} "
                                     + "            ,'{7}' "
                                     + "            ,'{8}' "
                                     + "            ,'{9}' ) ";

        const string insertRecBgnGrpO = " INSERT INTO [RECBGNGRPORF] "
                                     + "            ([OFFERDATERF] "
                                     + "            ,[BRGNGOODSGRPCODERF] "
                                     + "            ,[BRGNGOODSGRPTITLERF] "
                                     + "            ,[BRGNGOODSGRPTAGRF] "
                                     + "            ,[BRGNGOODSGRPCOMMENTRF]) "
                                     + "      VALUES "
                                     + "            ({0} "
                                     + "            ,{1} "
                                     + "            ,'{2}' "
                                     + "            ,'{3}' "
                                     + "            ,'{4}') ";

        const string deleteRecBgnGrp = " DELETE FROM [RECBGNGRPRF] WHERE INQORIGINALEPCDRF='{3}' AND INQORIGINALSECCDRF='{4}' AND BRGNGOODSGRPCODERF={5} ";

        const string deleteRecBgnGrpO = " DELETE FROM [RECBGNGRPORF] WHERE BRGNGOODSGRPCODERF={1} ";

        #endregion

        /// <summary>企業連結マスタ設定</summary>
        private string[] SCMEPCNECTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	広葉整備	5111150825430100	ブロードパーツ	0	0	0",


        };

        /// <summary>企業拠点連結マスタ設定</summary>
        private string[] SCMEPSCCNTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	000001	本社	5111150825430100	01    	ＰＭ本社	0	1	1	0	8	10	1	1	0	emi                                               	1",
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
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPCNECTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093')", new string[] { "" });
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPSCCNTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093')", new string[] { "" });
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
        /// 条件：SearchAllProc　結果なし
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test(Description = "結果なし")]
        public void SearchAllProc_お買得商品グループなし()
        {
            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            string cnectOtherEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchAllProc(out answer, cnectOtherEpCd, logicalMode, ref count, ref errMsg, ref sqlConnection);

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
        /// 条件：SearchAllProc　お買得商品グループあり
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchAllProc_お買得商品グループあり()
        {
            string[] RECBGNGRPRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150825430100	000001	0	0	未分類商品	未分類	オススメ商品のグループ設定をしてください。",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	1	2	2月の期間限定お買得商品	期間限定	2月の期間限定オススメ商品です。",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	2	1	車検時の同時購入で更にお安く	車検時オススメ	車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	3	0	冬本番！お車の準備は万全ですか？	季節商品	突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	4	3	3月の期間限定お買得商品	3月期間限定	3月の期間限定オススメ商品です。4月もするよ！"
            };

            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            string cnectOtherEpCd = "5111150825430093";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGRPRF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchAllProc(out answer, cnectOtherEpCd, logicalMode, ref count, ref errMsg, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 5);

                RecBgnGrpWork work = ((ArrayList)answer)[0] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 0);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "未分類商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "未分類");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "オススメ商品のグループ設定をしてください。");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 1);
                Assert.AreEqual(work.DisplayOrder, 2);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2月の期間限定オススメ商品です。");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 2);
                Assert.AreEqual(work.DisplayOrder, 1);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "車検時の同時購入で更にお安く");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "車検時オススメ");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 3);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "冬本番！お車の準備は万全ですか？");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "季節商品");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 4);
                Assert.AreEqual(work.DisplayOrder, 3);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3月期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3月の期間限定オススメ商品です。4月もするよ！");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGRPRF);
            }
        }

        /// <summary>
        /// 条件：SearchProc　結果なし
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test()]
        public void SearchProc_お買得商品グループなし()
        {
            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            RecBgnGrpSearchParaWork paraobj = new RecBgnGrpSearchParaWork();
            paraobj.InqOriginalEpCd = "5111150825430100";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchProc(out answer, paraobj, logicalMode, ref count, ref errMsg, ref sqlConnection);

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
        /// 条件：SearchProc　お買得商品グループあり
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchProc_お買得商品グループあり()
        {
            string[] RECBGNGRPRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150825430100	000001	0	0	未分類商品	未分類	オススメ商品のグループ設定をしてください。",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	1	2	2月の期間限定お買得商品	期間限定	2月の期間限定オススメ商品です。",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	2	1	車検時の同時購入で更にお安く	車検時オススメ	車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	3	0	冬本番！お車の準備は万全ですか？	季節商品	突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	4	3	3月の期間限定お買得商品	3月期間限定	3月の期間限定オススメ商品です。4月もするよ！"
            };

            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            RecBgnGrpSearchParaWork paraobj = new RecBgnGrpSearchParaWork();
            paraobj.InqOriginalEpCd = "5111150825430100";
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrp, RECBGNGRPRF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchProc(out answer, paraobj, logicalMode, ref count, ref errMsg, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 5);

                RecBgnGrpWork work = ((ArrayList)answer)[0] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 0);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "未分類商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "未分類");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "オススメ商品のグループ設定をしてください。");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 1);
                Assert.AreEqual(work.DisplayOrder, 2);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2月の期間限定オススメ商品です。");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 2);
                Assert.AreEqual(work.DisplayOrder, 1);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "車検時の同時購入で更にお安く");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "車検時オススメ");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 3);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "冬本番！お車の準備は万全ですか？");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "季節商品");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 4);
                Assert.AreEqual(work.DisplayOrder, 3);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3月期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3月の期間限定オススメ商品です。4月もするよ！");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGRPRF);
            }
        }

        /// <summary>
        /// 条件：SearchAllOfferProc　結果なし
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test()]
        public void SearchAllOfferProc_お買得商品グループなし()
        {
            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchAllOfferProc(out answer, logicalMode, ref count, ref errMsg, ref sqlConnection);

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
        /// 条件：SearchAllOfferProc　お買得商品グループあり
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchAllOfferProc_お買得商品グループあり()
        {
            string[] RECBGNGRPORF = new string[]{
                "20150225	9000	未分類商品	未分類	オススメ商品のグループ設定をしてください。",
                "20150225	9001	2月の期間限定お買得商品	期間限定	2月の期間限定オススメ商品です。",
                "20150225	9002	車検時の同時購入で更にお安く	車検時オススメ	車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!",
                "20150225	9003	冬本番！お車の準備は万全ですか？	季節商品	突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集",
                "20150225	9004	3月の期間限定お買得商品	3月期間限定	3月の期間限定オススメ商品です。4月もするよ！"
            };

            #region  事前準備
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //テストデータ作成
                NUnitUtils.ExecuteAdHocSql(insertRecBgnGrpO, RECBGNGRPORF);


                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();

                int status = remote.SearchAllOfferProc(out answer, logicalMode, ref count, ref errMsg, ref sqlConnection);

                Assert.AreEqual(status, (int)ConstantManagement.DB_Status.ctDB_NORMAL);
                Assert.NotNull(answer as ArrayList);
                Assert.AreEqual(((ArrayList)answer).Count, 5);

                RecBgnGrpWork work = ((ArrayList)answer)[0] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9000);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "未分類商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "未分類");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "オススメ商品のグループ設定をしてください。");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9001);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2月の期間限定オススメ商品です。");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9002);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "車検時の同時購入で更にお安く");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "車検時オススメ");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "車検ご契約との同時購入でさらにお安くなります。取付手数料も10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9003);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "冬本番！お車の準備は万全ですか？");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "季節商品");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "突然の大雪・路面の凍結で困らない為に!!スタッドレス・チェーン特集");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9004);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3月の期間限定お買得商品");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3月期間限定");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3月の期間限定オススメ商品です。4月もするよ！");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrpO, RECBGNGRPORF);
            }
        }
    
    }
}

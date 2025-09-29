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

        /// <summary>��ƘA���}�X�^�ݒ�</summary>
        private string[] SCMEPCNECTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	�D�y�J�� NUnit-001	5111150842021003	�D�y�J�� NUnit-001	0	0	0",//�L��
            "634643105635632500	634643105635632500	1	5111150825430093	�D�y�J�� NUnit-001	5111150842021004	�D�y�J�� NUnit-002	0	0	0",//����
            "634643105635632500	634643105635632500	0	5111150825430093	�D�y�J�� NUnit-001	5111150842021005	�D�y�J�� NUnit-003	1	0	0",//����
            "634643105635632500	634643105635632500	0	5111150825430093	�D�y�J�� NUnit-001	5111150842021006	�D�y�J�� NUnit-004	0	0	0",//�L��
            "634643105635632500	634643105635632500	1	5111150825430094	�D�y�J�� NUnit-002	5111150842021004	�D�y�J�� NUnit-001	0	0	0",//����
            "634643105635632500	634643105635632500	0	5111150825430095	�D�y�J�� NUnit-003	5111150842021004	�D�y�J�� NUnit-001	1	0	0",//����
            "634643105635632500	634643105635632500	0	5111150825430096	�D�y�J�� NUnit-004	5111150842021003	�D�y�J�� NUnit-001	0	0	0" //�L��
        };

        /// <summary>��Ƌ��_�A���}�X�^�ݒ�</summary>
        private string[] SCMEPSCCNTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021003	01    	01���_	0	1	1	1	0	10	1	0	0	NUNIT	1",//�L��
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021003	02    	02���_	0	0	0	1	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021003	03    	03���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//�L��
            "634643105635632500	634643105635632500	1	5111150825430093	000001	�{��	5111150842021003	04    	04���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021003	05    	05���_	1	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430093	000002	�{��	5111150842021003	01    	01���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//�L��
            "634643105635632500	634643105635632500	0	5111150825430093	000002	�{��	5111150842021004	01    	01���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//��ƂŖ���
            "634643105635632500	634643105635632500	0	5111150825430093	000002	�{��	5111150842021004	02    	02���_	1	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	1	5111150825430093	000002	�{��	5111150842021004	03    	03���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430093	000002	�{��	5111150842021005	01    	01���_	1	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021006	01    	01���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//�L��
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150842021006	02    	02���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//�L��
            "634643105635632500	634643105635632500	1	5111150825430094	000001	�{��	5111150842021004	01    	01���_	0	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430095	000002	�{��	5111150842021004	01    	01���_	1	1	1	0	0	10	1	0	0	NUNIT	1",//����
            "634643105635632500	634643105635632500	0	5111150825430096	000001	�{��	5111150842021003	01    	01���_	0	1	1	1	0	10	1	0	0	NUNIT	1"//�L��
        };

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPCNECTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] {"" });
            NUnitUtils.ExecuteAdHocSql("DELETE FROM SCMEPSCCNTRF WHERE CNECTORIGINALEPCDRF IN ('5111150825430093','5111150825430094','5111150825430095','5111150825430096')", new string[] {"" });

            #region �e�X�g�f�[�^�쐬
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
        /// �����F�A����Ɩ���
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = �󃊃X�g
        /// </summary>
        [Test(Description = "�ڑ���ƁE���_�������ꍇ")]
        public void SearchProc_�ڑ����()
        {
            #region  ���O����
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
        /// �����F�A����ƗL�A���R�����h�ݒ薳��
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        ///       recGoodsLkWorkList = �󃊃X�g
        /// </summary>
        [Test]
        public void SearchProc_�ڑ����L_���R�����h�ݒ薳()
        {
            #region  ���O����
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
        /// �����F�A����ƗL�A���R�����h�ݒ�L��F���Ӑ�w��
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = 1���擾
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_���Ӑ�w��()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	11	10-11	���Ӑ�w��p�^�[��",
                "635596754384768818	635596754384768819	1	5111150825430093	000001	5111150842021003	01    	1	10	12	10-12	���Ӑ�w��p�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	01    	1	10	13	10-13	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.GoodsComment, "���Ӑ�w��p�^�[��");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPM�S�Ћ���(SF�͓��Ӑ�w��)
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = PM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PM�S�Ћ���()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	00    	1	10	11	10-11	PM�S�Ћ��ʃp�^�[��",
                "635596754384768818	635596754384768819	1	5111150825430093	000001	5111150842021003	00    	1	10	12	10-12	PM�S�Ћ��ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	PM�S�Ћ��ʃp�^�[��"
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "PM�S�Ћ��ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "PM�S�Ћ��ʃp�^�[��");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FSF�S�Аݒ�(PM�͋��_�w��)
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_SF����()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	01    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��"
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��"
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "���Ӑ�w��p�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[3] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�ASF���_�i����
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�_���_�i����01()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "���Ӑ�w��p�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }

        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�ASF���_�i����
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�_���_�i����02()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�APM������ƗL
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�_�����ݒ�()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[1] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 14);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-14");
                Assert.AreEqual(work.GoodsComment, "���Ӑ�w��p�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[2] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "03    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[3] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021006");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 15);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-15");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");

                work = ((ArrayList)recGoodsLkWorkList)[4] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021006");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 16);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-16");
                Assert.AreEqual(work.GoodsComment, "���Ӑ�w��p�^�[��");


                work = ((ArrayList)recGoodsLkWorkList)[5] as RecGoodsLkWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 635596754384768818L);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 635596754384768819L);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430093");
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�APM������ƗL�ASF���_�ł̍i�荞��
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�_�����ݒ�_SF���_�i����02()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }


        /// <summary>
        /// �����F�A����ƗL�A���R�����h�ݒ�L��FPMSF�S�Аݒ�+�ʐݒ�APM������ƗL�ASF���_�ł̍i�荞�݁APM��Ƌ��_�ł̍i�荞��
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        ///       recGoodsLkWorkList = SF���APM���̗L�����_�ɂ��W�J�������s���邱��
        /// </summary>
        [Test]
        public void SearchProc_���R�����h�ݒ�L��_PMSF����_�ʐݒ�_�����ݒ�_SF���_�i����02_PM��Ƌ��_�i����()
        {
            string[] RECGOODSLKRF = new string[]{
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021003	00    	1	10	11	10-11	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	1	0000000000000000	000000	5111150842021003	01    	1	10	12	10-12	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430096	000001	5111150842021003	00    	1	10	13	10-13	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021003	01    	1	10	14	10-14	���Ӑ�w��p�^�[��",
                "635596754384768818	635596754384768819	0	0000000000000000	000000	5111150842021006	01    	1	10	15	10-15	SF���ʃp�^�[��",
                "635596754384768818	635596754384768819	0	5111150825430093	000001	5111150842021006	01    	1	10	16	10-16	���Ӑ�w��p�^�[��",
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.InqOriginalSecCd, "000002");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.InqOtherEpCd, "5111150842021003");
                Assert.AreEqual(work.InqOtherSecCd, "01    ");//����Ƌ��_�A���}�X�^�ɂ��W�J����
                Assert.AreEqual(work.CustomerCode, 1);
                Assert.AreEqual(work.RecSourceBLGoodsCd, 10);
                Assert.AreEqual(work.RecDestBLGoodsCd, 11);
                Assert.AreEqual(work.RecDestBLGoodsNm, "10-11");
                Assert.AreEqual(work.GoodsComment, "SF���ʃp�^�[��");
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecGoodsLk, RECGOODSLKRF);
            }
        }
    }
}

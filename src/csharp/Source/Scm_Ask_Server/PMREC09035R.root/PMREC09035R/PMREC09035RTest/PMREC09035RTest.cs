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

        /// <summary>��ƘA���}�X�^�ݒ�</summary>
        private string[] SCMEPCNECTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	�L�t����	5111150825430100	�u���[�h�p�[�c	0	0	0",


        };

        /// <summary>��Ƌ��_�A���}�X�^�ݒ�</summary>
        private string[] SCMEPSCCNTRF = new string[]{
            "634643105635632500	634643105635632500	0	5111150825430093	000001	�{��	5111150825430100	01    	�o�l�{��	0	1	1	0	8	10	1	1	0	emi                                               	1",
        };


        [TestFixtureSetUp]
        public void SetUpClass()
        {
            this.TearDownClass();

            #region �e�X�g�f�[�^�쐬
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
        /// �����FSearchAllProc�@���ʂȂ�
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test(Description = "���ʂȂ�")]
        public void SearchAllProc_���������i�O���[�v�Ȃ�()
        {
            #region  ���O����
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
        /// �����FSearchAllProc�@���������i�O���[�v����
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchAllProc_���������i�O���[�v����()
        {
            string[] RECBGNGRPRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150825430100	000001	0	0	�����ޏ��i	������	�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	1	2	2���̊��Ԍ��肨�������i	���Ԍ���	2���̊��Ԍ���I�X�X�����i�ł��B",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	2	1	�Ԍ����̓����w���ōX�ɂ�����	�Ԍ����I�X�X��	�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	3	0	�~�{�ԁI���Ԃ̏����͖��S�ł����H	�G�ߏ��i	�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	4	3	3���̊��Ԍ��肨�������i	3�����Ԍ���	3���̊��Ԍ���I�X�X�����i�ł��B4���������I"
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�����ޏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "������");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 1);
                Assert.AreEqual(work.DisplayOrder, 2);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "���Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2���̊��Ԍ���I�X�X�����i�ł��B");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 2);
                Assert.AreEqual(work.DisplayOrder, 1);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�Ԍ����̓����w���ōX�ɂ�����");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�Ԍ����I�X�X��");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 3);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�~�{�ԁI���Ԃ̏����͖��S�ł����H");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�G�ߏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 4);
                Assert.AreEqual(work.DisplayOrder, 3);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3�����Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3���̊��Ԍ���I�X�X�����i�ł��B4���������I");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGRPRF);
            }
        }

        /// <summary>
        /// �����FSearchProc�@���ʂȂ�
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test()]
        public void SearchProc_���������i�O���[�v�Ȃ�()
        {
            #region  ���O����
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
        /// �����FSearchProc�@���������i�O���[�v����
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchProc_���������i�O���[�v����()
        {
            string[] RECBGNGRPRF = new string[]{
                "634643105635632500	634643105635632500	0	5111150825430100	000001	0	0	�����ޏ��i	������	�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	1	2	2���̊��Ԍ��肨�������i	���Ԍ���	2���̊��Ԍ���I�X�X�����i�ł��B",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	2	1	�Ԍ����̓����w���ōX�ɂ�����	�Ԍ����I�X�X��	�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	3	0	�~�{�ԁI���Ԃ̏����͖��S�ł����H	�G�ߏ��i	�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W",
                "634643105635632500	634643105635632500	0	5111150825430100	000001	4	3	3���̊��Ԍ��肨�������i	3�����Ԍ���	3���̊��Ԍ���I�X�X�����i�ł��B4���������I"
            };

            #region  ���O����
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
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�����ޏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "������");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 1);
                Assert.AreEqual(work.DisplayOrder, 2);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "���Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2���̊��Ԍ���I�X�X�����i�ł��B");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 2);
                Assert.AreEqual(work.DisplayOrder, 1);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�Ԍ����̓����w���ōX�ɂ�����");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�Ԍ����I�X�X��");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 3);
                Assert.AreEqual(work.DisplayOrder, 0);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�~�{�ԁI���Ԃ̏����͖��S�ł����H");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�G�ߏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.CreateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.UpdateDateTime.Ticks, 634643105635632500);
                Assert.AreEqual(work.LogicalDeleteCode, 0);
                Assert.AreEqual(work.InqOriginalEpCd, "5111150825430100");
                Assert.AreEqual(work.InqOriginalSecCd, "000001");
                Assert.AreEqual(work.BrgnGoodsGrpCode, 4);
                Assert.AreEqual(work.DisplayOrder, 3);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3�����Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3���̊��Ԍ���I�X�X�����i�ł��B4���������I");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrp, RECBGNGRPRF);
            }
        }

        /// <summary>
        /// �����FSearchAllOfferProc�@���ʂȂ�
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NOT_FOUND,
        /// </summary>
        [Test()]
        public void SearchAllOfferProc_���������i�O���[�v�Ȃ�()
        {
            #region  ���O����
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
        /// �����FSearchAllOfferProc�@���������i�O���[�v����
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// </summary>
        [Test()]
        public void SearchAllOfferProc_���������i�O���[�v����()
        {
            string[] RECBGNGRPORF = new string[]{
                "20150225	9000	�����ޏ��i	������	�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B",
                "20150225	9001	2���̊��Ԍ��肨�������i	���Ԍ���	2���̊��Ԍ���I�X�X�����i�ł��B",
                "20150225	9002	�Ԍ����̓����w���ōX�ɂ�����	�Ԍ����I�X�X��	�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!",
                "20150225	9003	�~�{�ԁI���Ԃ̏����͖��S�ł����H	�G�ߏ��i	�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W",
                "20150225	9004	3���̊��Ԍ��肨�������i	3�����Ԍ���	3���̊��Ԍ���I�X�X�����i�ł��B4���������I"
            };

            #region  ���O����
            RecBgnGrpDB remote = new RecBgnGrpDB();
            ArrayList answer = new ArrayList();
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            #endregion

            string errMsg = null;
            int count = 0;
            SqlConnection sqlConnection = null;
            try
            {
                //�e�X�g�f�[�^�쐬
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
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�����ޏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "������");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�I�X�X�����i�̃O���[�v�ݒ�����Ă��������B");

                work = ((ArrayList)answer)[1] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9001);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "2���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "���Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "2���̊��Ԍ���I�X�X�����i�ł��B");

                work = ((ArrayList)answer)[2] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9002);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�Ԍ����̓����w���ōX�ɂ�����");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�Ԍ����I�X�X��");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�Ԍ����_��Ƃ̓����w���ł���ɂ������Ȃ�܂��B��t�萔����10%OFF!!");


                work = ((ArrayList)answer)[3] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9003);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "�~�{�ԁI���Ԃ̏����͖��S�ł����H");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "�G�ߏ��i");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "�ˑR�̑��E�H�ʂ̓����ō���Ȃ��ׂ�!!�X�^�b�h���X�E�`�F�[�����W");


                work = ((ArrayList)answer)[4] as RecBgnGrpWork;
                Assert.NotNull(work);
                Assert.AreEqual(work.BrgnGoodsGrpCode, 9004);
                Assert.AreEqual(work.BrgnGoodsGrpTitle, "3���̊��Ԍ��肨�������i");
                Assert.AreEqual(work.BrgnGoodsGrpTag, "3�����Ԍ���");
                Assert.AreEqual(work.BrgnGoodsGrpComment, "3���̊��Ԍ���I�X�X�����i�ł��B4���������I");

            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlConnection);

                NUnitUtils.ExecuteAdHocSql(deleteRecBgnGrpO, RECBGNGRPORF);
            }
        }
    
    }
}

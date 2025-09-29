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
    /// �L�����y�[���Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    [Serializable]
    public class CampaignMngDB : RemoteDB, ICampaignMngDB
    {
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="campaignMngWork">��������</param>
        /// <param name="paracampaignMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object campaignMngWork, object paracampaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignMngWork = null;
            try
            {
                //�R�l�N�V��������
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
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objcampaignMngWork">��������</param>
        /// <param name="paracampaignMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">��������</param>
        /// <param name="campaignMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchCampaignMngProc(out ArrayList campaignMngWorkList, CampaignMngOrderWork campaignMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchCampaignMngProcProc(out campaignMngWorkList, campaignMngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">��������</param>
        /// <param name="campaignMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CampaignMngWork campaignMngWork = new CampaignMngWork();

                // XML�̓ǂݍ���
                campaignMngWork = (CampaignMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignMngWork));
                if (campaignMngWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref campaignMngWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
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
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref CampaignMngWork campaignMngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref campaignMngWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="campaignMngWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref CampaignMngWork campaignMngWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
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

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                    findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                    findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                    findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

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
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object campaignMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(campaignMngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteCampaignMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                CampaignMngWork paraWork = paraList[0] as CampaignMngWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecCampaignMng(ref paraList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                campaignMngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngDB.Write(ref object campaignMngWork)");
                // ���[���o�b�N
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
        /// �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int WriteCampaignMngProc(ref ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteCampaignMngProcProc(ref campaignMngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                        SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignMngWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (campaignMngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
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

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                            findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                            findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                            findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                            findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                            findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (campaignMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
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

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);  // ����ڕW���z
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);  // ����ڕW�e���z
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);  // ����ڕW����
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);  // ���i�i�����j
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);  // �|��
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignMngWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        paraGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetMoney);  // ����ڕW���z
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetProfit);  // ����ڕW�e���z
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.SalesTargetCount);  // ����ڕW����
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.CampaignCode);  // �L�����y�[���R�[�h
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.PriceFl);  // ���i�i�����j
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.RateVal);  // �|��
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignMngWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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
                    # region �X�V����SQL������
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

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)campaignMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�
                    SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);  // ����ڕW���z
                    SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);  // ����ڕW�e���z
                    SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);  // ����ڕW����
                    SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);  // ���i�i�����j
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);  // �|��
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignMngWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignMngWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignMngWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                    paraGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�
                    paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetMoney);  // ����ڕW���z
                    paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignMngWork.SalesTargetProfit);  // ����ڕW�e���z
                    paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.SalesTargetCount);  // ����ڕW����
                    paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.CampaignCode);  // �L�����y�[���R�[�h
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.PriceFl);  // ���i�i�����j
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(campaignMngWork.RateVal);  // �|��
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �L�����y�[���Ǘ��}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object campaignMngWork)
        {
            return LogicalDeleteCampaignMng(ref campaignMngWork, 0);
        }

        /// <summary>
        /// �_���폜�L�����y�[���Ǘ��}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�L�����y�[���Ǘ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object campaignMngWork)
        {
            return LogicalDeleteCampaignMng(ref campaignMngWork, 1);
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="campaignMngWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteCampaignMng(ref object campaignMngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(campaignMngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCampaignMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
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

                // ���[���o�b�N
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
        /// �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeleteCampaignMngProc(ref ArrayList campaignMngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteCampaignMngProcProc(ref campaignMngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                        SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignMngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CAMPAIGNMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                            findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                            findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                            findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                            findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                            findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) campaignMngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else campaignMngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) campaignMngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�L�����y�[���Ǘ��}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCampaignMngProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngDB.Delete");
                // ���[���o�b�N
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
        /// �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">�L�����y�[���Ǘ��}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeleteCampaignMngProc(ArrayList campaignMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteCampaignMngProcProc(campaignMngWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="campaignMngWorkList">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
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

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                    findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                    findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                    findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != campaignMngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignMngWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = campaignMngWork.SectionCode.Trim();  // ���_�R�[�h
                        findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMGroup);  // ���i�����ރR�[�h
                        findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.BLGoodsCode);  // BL���i�R�[�h
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignMngWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        findGoodsNo.Value = campaignMngWork.GoodsNo.Trim();  // ���i�ԍ�
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
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
                //���N���X�ɗ�O��n���ď������Ă��炤
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

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CampaignMngOrderWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignMngOrderWork CampaignMngOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "CAM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CampaignMngOrderWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(CampaignMngOrderWork.SectionCode) == false)
            {
                retstring += "AND CAM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = CampaignMngOrderWork.SectionCode.Trim();
            }
            
            //�_���폜�敪
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

            // ���i�����ރR�[�h
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

            // BL�O���[�v�R�[�h
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

            // BL���i�R�[�h
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

            // ���[�J�[�R�[�h
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

            // �L�����y�[���R�[�h
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

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngOrderWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignMngWork wkCampaignMngWork = new CampaignMngWork();

            #region �N���X�֊i�[
            wkCampaignMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkCampaignMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkCampaignMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkCampaignMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkCampaignMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkCampaignMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkCampaignMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkCampaignMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkCampaignMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkCampaignMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // ���i�����ރR�[�h
            wkCampaignMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
            wkCampaignMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
            wkCampaignMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // ���i�ԍ�
            wkCampaignMngWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));  // ����ڕW���z
            wkCampaignMngWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));  // ����ڕW�e���z
            wkCampaignMngWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));  // ����ڕW����
            wkCampaignMngWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // �L�����y�[���R�[�h
            wkCampaignMngWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));  // ���i�i�����j
            wkCampaignMngWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));  // �|��
            wkCampaignMngWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // ���_����
            wkCampaignMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // ���i�����ޖ���
            wkCampaignMngWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL���i�R�[�h����
            wkCampaignMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // ���[�J�[����
            wkCampaignMngWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BL�O���[�v�R�[�h
            wkCampaignMngWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  // BL�O���[�v����
            #endregion

            return wkCampaignMngWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignMngWork[] CampaignMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CampaignMngWork)
                    {
                        CampaignMngWork wkCampaignMngWork = paraobj as CampaignMngWork;
                        if (wkCampaignMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignMngWork);
                        }
                    }

                    //byte[]�̏ꍇ
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
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
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

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
    /// �S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SCMPrtSettingDB : RemoteDB, ISCMPrtSettingDB
    {
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        public SCMPrtSettingDB()
            :
            base("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork", "SCMPRTSETTINGRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="scmPrtSettingWork">��������</param>
        /// <param name="parascmPrtSettingWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int Search(out object scmPrtSettingWork, object scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmPrtSettingWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMPrtSettingProc(out scmPrtSettingWork, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "scmPrtSettingDB.Search");
                scmPrtSettingWork = new ArrayList();
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
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objscmPrtSettingWork">��������</param>
        /// <param name="objscmPrtSettingOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMPrtSettingProc(out object objscmPrtSettingWork, object objscmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList scmPrtSettingWorkList = new ArrayList();

            SCMPrtSettingOrderWork scmPrtSettingOrderWork = null;

            if (objscmPrtSettingOrderWork != null)
            {
                scmPrtSettingOrderWork = objscmPrtSettingOrderWork as SCMPrtSettingOrderWork;
            }
            else
            {
                scmPrtSettingOrderWork = new SCMPrtSettingOrderWork();
            }

            int status = SearchSCMPrtSettingProc(out scmPrtSettingWorkList, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
            objscmPrtSettingWork = scmPrtSettingWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">��������</param>
        /// <param name="scmPrtSettingOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMPrtSettingProc(out ArrayList scmPrtSettingWorkList, SCMPrtSettingOrderWork scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMPrtSettingProcProc(out scmPrtSettingWorkList, scmPrtSettingOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">��������</param>
        /// <param name="scmPrtSettingOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int SearchSCMPrtSettingProcProc(out ArrayList scmPrtSettingWorkList, SCMPrtSettingOrderWork scmPrtSettingOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUP.SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRTSETTINGRF AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP " + Environment.NewLine;
                //selectTxt += "   ON  SUP.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "   AND SUP.SUPPLIERCDRF = SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = SCM.GOODSNORF " + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmPrtSettingOrderWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMPrtSettingWorkFromReader(ref myReader));

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

            scmPrtSettingWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMPrtSettingWork scmPrtSettingWork = new SCMPrtSettingWork();

                // XML�̓ǂݍ���
                scmPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPrtSettingWork));
                if (scmPrtSettingWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmPrtSettingWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmPrtSettingWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Read");
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
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int ReadProc(ref SCMPrtSettingWork scmPrtSettingWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmPrtSettingWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int ReadProcProc(ref SCMPrtSettingWork scmPrtSettingWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT
                selectTxt += " SELECT   SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "         ,SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += "         ,SCM.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                //selectTxt += "         ,SUP.SUPPLIERNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,GRO.BLGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "         ,GOD.GOODSNAMERF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRTSETTINGRF AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                //selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP " + Environment.NewLine;
                //selectTxt += "   ON  SUP.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "   AND SUP.SUPPLIERCDRF = SCM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = SCM.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = SCM.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GRO " + Environment.NewLine;
                selectTxt += "   ON  GRO.ENTERPRISECODERF = BLG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GRO.BLGROUPCODERF = BLG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GOD " + Environment.NewLine;
                selectTxt += "   ON  GOD.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSMAKERCDRF = SCM.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "   AND GOD.GOODSNORF = SCM.GOODSNORF " + Environment.NewLine;
                selectTxt += " WHERE SCM.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SCM.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                //selectTxt += "         AND SCM.SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                //selectTxt += "         AND SCM.BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                selectTxt += "         AND SCM.GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.NChar);
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NChar);
                    //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.NChar);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.NChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPrtSettingWork = CopyToSCMPrtSettingWorkFromReader(ref myReader);
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
        /// SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int Write(ref object scmPrtSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmPrtSettingWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSCMPrtSettingProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMPrtSettingWork paraWork = paraList[0] as SCMPrtSettingWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMPrtSetting(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                scmPrtSettingWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Write(ref object scmPrtSettingWork)");
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
        /// SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int WriteSCMPrtSettingProc(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMPrtSettingProcProc(ref scmPrtSettingWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int WriteSCMPrtSettingProcProc(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                    {
                        SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP  AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (scmPrtSettingWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMPRTSETTINGRF SET CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "  , SUPPLIERCDRF = @SUPPLIERCD " + Environment.NewLine;
                            sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                            //sqlText += "  , BLGROUPCODERF = @BLGROUPCODE " + Environment.NewLine;
                            sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "         AND SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                            sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                            //sqlText += "         AND BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                            sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                            sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                            findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (scmPrtSettingWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMPRTSETTINGRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            //sqlText += "         ,SUPPLIERCDRF " + Environment.NewLine;
                            sqlText += "         ,GOODSMGROUPRF " + Environment.NewLine;
                            //sqlText += "         ,BLGROUPCODERF " + Environment.NewLine;
                            sqlText += "         ,BLGOODSCODERF " + Environment.NewLine;
                            sqlText += "         ,GOODSMAKERCDRF " + Environment.NewLine;
                            sqlText += "         ,GOODSNORF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
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
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            //sqlText += "         ,@SUPPLIERCD " + Environment.NewLine;
                            sqlText += "         ,@GOODSMGROUP " + Environment.NewLine;
                            //sqlText += "         ,@BLGROUPCODE " + Environment.NewLine;
                            sqlText += "         ,@BLGOODSCODE " + Environment.NewLine;
                            sqlText += "         ,@GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "         ,@GOODSNO " + Environment.NewLine;
                            sqlText += "         ,@AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);  // �d����R�[�h
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                        //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);  // BL�O���[�v�R�[�h
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�
                        SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // �����񓚋敪

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPrtSettingWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();  // ���_�R�[�h
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);  // ���Ӑ�R�[�h
                        //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);  // �d����R�[�h
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);  // ���i�����ރR�[�h
                        //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);  // BL�O���[�v�R�[�h
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);  // BL���i�R�[�h
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();  // ���i�ԍ�
                        paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.AutoAnswerDiv);  // �����񓚋敪
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPrtSettingWork);
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

            scmPrtSettingWorkList = al;

            return status;
        }

        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="scmPrtSettingWorkList">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int UpdateAllSecSCMPrtSetting(ref ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[0] as SCMPrtSettingWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region �X�V����SQL������
                    string sqlText = string.Empty;

                    sqlText += " UPDATE SCMPRTSETTINGRF SET CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                    //sqlText += "  , SUPPLIERCDRF = @SUPPLIERCD " + Environment.NewLine;
                    sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                    //sqlText += "  , BLGROUPCODERF = @BLGROUPCODE " + Environment.NewLine;
                    sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                    sqlText += "  , GOODSNORF = @GOODSNO " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSER " + Environment.NewLine;
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "         AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "         AND SUPPLIERCDRF = @FINDSUPPLIERCD " + Environment.NewLine;
                    sqlText += "         AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                    sqlText += "         AND BLGROUPCODERF = @FINDBLGROUPCODE " + Environment.NewLine;
                    sqlText += "         AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                    sqlText += "         AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                    sqlText += "         AND GOODSNORF = @FINDGOODSNO " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NChar);
                    //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.NChar);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.GoodsNo);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);  // �d����R�[�h
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                    //SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);  // BL�O���[�v�R�[�h
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);  // ���i�ԍ�
                    SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSER", SqlDbType.Int);  // �����񓚋敪

                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPrtSettingWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();  // ���_�R�[�h
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);  // ���Ӑ�R�[�h
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);  // �d����R�[�h
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);  // ���i�����ރR�[�h
                    //paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);  // BL�O���[�v�R�[�h
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);  // BL���i�R�[�h
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                    paraGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();  // ���i�ԍ�
                    paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.AutoAnswerDiv);  // �����񓚋敪
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
        /// SCM�i�ڐݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDelete(ref object scmPrtSettingWork)
        {
            return LogicalDeleteSCMPrtSetting(ref scmPrtSettingWork, 0);
        }

        /// <summary>
        /// �_���폜SCM�i�ڐݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="scmPrtSettingWork">scmPrtSettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM�i�ڐݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int RevivalLogicalDelete(ref object scmPrtSettingWork)
        {
            return LogicalDeleteSCMPrtSetting(ref scmPrtSettingWork, 1);
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int LogicalDeleteSCMPrtSetting(ref object scmPrtSettingWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmPrtSettingWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMPrtSettingProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMPrtSettingDB.LogicalDeleteSCMPrtSetting :" + procModestr);

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
        /// SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCMPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDeleteSCMPrtSettingProc(ref ArrayList scmPrtSettingWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMPrtSettingProcProc(ref scmPrtSettingWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCMPrtSettingWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int LogicalDeleteSCMPrtSettingProcProc(ref ArrayList scmPrtSettingWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmPrtSettingWorkList != null)
                {
                    for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                    {
                        SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMPRTSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                            //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                            findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPrtSettingWork;
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
                            else if (logicalDelCd == 0) scmPrtSettingWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else scmPrtSettingWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmPrtSettingWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPrtSettingWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPrtSettingWork);
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

            scmPrtSettingWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM�i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
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

                status = DeleteSCMPrtSettingProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPrtSettingDB.Delete");
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
        /// SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCM�i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int DeleteSCMPrtSettingProc(ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMPrtSettingProcProc(scmPrtSettingWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPrtSettingWorkList">SCM�i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int DeleteSCMPrtSettingProcProc(ArrayList scmPrtSettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmPrtSettingWorkList.Count; i++)
                {
                    SCMPrtSettingWork scmPrtSettingWork = scmPrtSettingWorkList[i] as SCMPrtSettingWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    //SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                    //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                    findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != scmPrtSettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMPRTSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND GOODSNORF = @FINDGOODSNO";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = scmPrtSettingWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.CustomerCode);
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.SupplierCd);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMGroup);
                        //findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingWork.GoodsMakerCd);
                        findParaGoodsNo.Value = scmPrtSettingWork.GoodsNo.Trim();
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
        /// <param name="scmPrtSettingWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMPrtSettingOrderWork scmPrtSettingOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "SCM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingOrderWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(scmPrtSettingOrderWork.SectionCode) == false)
            {
                retstring += "AND SCM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPrtSettingOrderWork.SectionCode);
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // ���Ӑ�R�[�h
            if (scmPrtSettingOrderWork.St_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_CustomerCode);
            }
            if (scmPrtSettingOrderWork.Ed_CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_CustomerCode);
            }

            //// �d����R�[�h
            //if (scmPrtSettingOrderWork.St_SupplierCd != 0)
            //{
            //    retstring += "AND SUPPLIERCDRF >= @FINDSTSUPPLIERCD ";
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@FINDSTSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_SupplierCd);
            //}
            //if (scmPrtSettingOrderWork.Ed_SupplierCd != 0)
            //{
            //    retstring += "AND SUPPLIERCDRF <= @FINDEDSUPPLIERCD ";
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@FINDEDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_SupplierCd);
            //}

            // ���i�����ރR�[�h
            if (scmPrtSettingOrderWork.St_GoodsMGroup != 0) 
            {
                retstring += "AND SCM.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_GoodsMGroup);
            } 
            if (scmPrtSettingOrderWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND SCM.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_GoodsMGroup);
            }

            // BL�O���[�v�R�[�h
            if (scmPrtSettingOrderWork.St_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF >= @FINDSTBLGROUPCODE ";
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@FINDSTBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_BLGroupCode);
            }
            if (scmPrtSettingOrderWork.Ed_BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF <= @FINDEDBLGROUPCODE ";
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@FINDEDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_BLGroupCode);
            }

            // BL���i�R�[�h
            if (scmPrtSettingOrderWork.St_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_BLGoodsCode);
            }
            if (scmPrtSettingOrderWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND SCM.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_BLGoodsCode);
            }

            // ���[�J�[�R�[�h
            if (scmPrtSettingOrderWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.St_GoodsMakerCd);
            }
            if (scmPrtSettingOrderWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND SCM.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmPrtSettingOrderWork.Ed_GoodsMakerCd);
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
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromReader(ref SqlDataReader myReader)
        {
            SCMPrtSettingWork wkSCMPrtSettingWork = new SCMPrtSettingWork();

            #region �N���X�֊i�[
            wkSCMPrtSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkSCMPrtSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkSCMPrtSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkSCMPrtSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMPrtSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkSCMPrtSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkSCMPrtSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkSCMPrtSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkSCMPrtSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkSCMPrtSettingWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
            //wkSCMPrtSettingWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));  // �d����R�[�h
            wkSCMPrtSettingWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // ���i�����ރR�[�h
            wkSCMPrtSettingWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BL�O���[�v�R�[�h
            wkSCMPrtSettingWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
            wkSCMPrtSettingWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
            wkSCMPrtSettingWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // ���i�ԍ�
            wkSCMPrtSettingWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // �����񓚋敪
            wkSCMPrtSettingWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // ���_����
            wkSCMPrtSettingWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // ���Ӑ於��
            //wkSCMPrtSettingWork.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNMRF"));  // �d���於��
            wkSCMPrtSettingWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // ���i�����ޖ���
            wkSCMPrtSettingWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));  // BL�O���[�v����
            wkSCMPrtSettingWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL���i�R�[�h����
            wkSCMPrtSettingWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // ���[�J�[����
            wkSCMPrtSettingWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  // ���i����
            #endregion

            return wkSCMPrtSettingWork;
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
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMPrtSettingWork[] SCMPrtSettingWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SCMPrtSettingWork)
                    {
                        SCMPrtSettingWork wkSCMPrtSettingWork = paraobj as SCMPrtSettingWork;
                        if (wkSCMPrtSettingWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMPrtSettingWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMPrtSettingWorkArray = (SCMPrtSettingWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMPrtSettingWork[]));
                        }
                        catch (Exception) { }
                        if (SCMPrtSettingWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMPrtSettingWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMPrtSettingWork wkSCMPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMPrtSettingWork));
                                if (wkSCMPrtSettingWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMPrtSettingWork);
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
        /// <br>Date       : 2009.05.08</br>
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

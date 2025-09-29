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
    /// <br>Programmer : 30745�@�g���@�F��</br>
    /// <br>Date       : 2012/10/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
    // �� �� ��  2012/11/20  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��20�Ή�
    //----------------------------------------------------------------------------//
    /// </remarks>
    [Serializable]
    public class AutoAnsItemStDB : RemoteDB, IAutoAnsItemStDB
    {
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// </remarks>
        public AutoAnsItemStDB()
            :
            base("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork", "AutoAnsItemStRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">��������</param>
        /// <param name="paraAutoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�</br>
        public int Search(out object autoAnsItemStWork, object paraAutoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAutoAnsItemStProc(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">��������</param>
        /// <param name="objAutoAnsItemStOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int SearchAutoAnsItemStProc(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList AutoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStOrderWork AutoAnsItemStOrderWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                AutoAnsItemStOrderWork = objAutoAnsItemStOrderWork as AutoAnsItemStOrderWork;
            }
            else
            {
                AutoAnsItemStOrderWork = new AutoAnsItemStOrderWork();
            }

            int status = SearchAutoAnsItemStProc(out AutoAnsItemStWorkList, AutoAnsItemStOrderWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = AutoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">��������</param>
        /// <param name="autoAnsItemStOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int SearchAutoAnsItemStProc(out ArrayList autoAnsItemStWorkList, AutoAnsItemStOrderWork autoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchAutoAnsItemStProcProc(out autoAnsItemStWorkList, autoAnsItemStOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">��������</param>
        /// <param name="objAutoAnsItemStOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int ReadProc2(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList autoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStWork autoAnsItemStWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                autoAnsItemStWork = objAutoAnsItemStOrderWork as AutoAnsItemStWork;
            }
            else
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            int status = ReadProc2(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = autoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">��������</param>
        /// <param name="objAutoAnsItemStOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int ReadProc3(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList autoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStWork autoAnsItemStWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                autoAnsItemStWork = objAutoAnsItemStOrderWork as AutoAnsItemStWork;
            }
            else
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            int status = ReadProc3(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = autoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">��������</param>
        /// <param name="autoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int ReadProc2(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc2(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">��������</param>
        /// <param name="autoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int ReadProc3(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc3(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">��������</param>
        /// <param name="AutoAnsItemStOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        private int SearchAutoAnsItemStProcProc(out ArrayList AutoAnsItemStWorkList, AutoAnsItemStOrderWork AutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, AutoAnsItemStOrderWork, logicalMode);

                string orderTxt = string.Empty;

                orderTxt += " ORDER BY    ATA.SECTIONCODERF DESC" + Environment.NewLine;
                orderTxt += "            ,ATA.CUSTOMERCODERF" + Environment.NewLine;
                orderTxt += "            ,ATA.GOODSMGROUPRF" + Environment.NewLine;
                orderTxt += "            ,ATA.BLGOODSCODERF" + Environment.NewLine;
                orderTxt += "            ,ATA.GOODSMAKERCDRF" + Environment.NewLine;
                orderTxt += "            ,ATA.PRMSETDTLNO2RF" + Environment.NewLine;

                sqlCommand.CommandText += orderTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));

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

            AutoAnsItemStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�</br>
        public int Read2(out object autoAnsItemStWork, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                AutoAnsItemStWork paraAutoAnsItemStWork = new AutoAnsItemStWork();

                // XML�̓ǂݍ���
                paraAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(parabyte, typeof(AutoAnsItemStWork));
                if (paraAutoAnsItemStWork == null) return status;


                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ReadProc2(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�</br>
        public int Read3(out object autoAnsItemStWork, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                AutoAnsItemStWork paraAutoAnsItemStWork = new AutoAnsItemStWork();

                // XML�̓ǂݍ���
                paraAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(parabyte, typeof(AutoAnsItemStWork));
                if (paraAutoAnsItemStWork == null) return status;


                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ReadProc3(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        public int ReadProc(ref AutoAnsItemStWork autoAnsItemStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref autoAnsItemStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        private int ReadProcProc(ref AutoAnsItemStWork autoAnsItemStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;

                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        autoAnsItemStWork = CopyToAutoAnsItemStWorkFromReader(ref myReader);
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

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">��������</param>
        /// <param name="autoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        private int ReadProcProc2(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = new SqlCommand();
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD ";

                #endregion

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
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

            autoAnsItemStWorkList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">��������</param>
        /// <param name="autoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎����񓚕i�ڐݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        private int ReadProcProc3(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = new SqlCommand();
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.AUTOANSWERDIVRF = 2 " + Environment.NewLine;
                selectTxt += " ORDER BY ATA.PRIORITYORDERRF " ;

                #endregion

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
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

            autoAnsItemStWorkList = al;

            return status;
        }

        #endregion

        #region [Write]
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�</br>
        public int Write(ref object autoAnsItemStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(autoAnsItemStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteAutoAnsItemStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                AutoAnsItemStWork paraWork = paraList[0] as AutoAnsItemStWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecAutoAnsItemSt(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                autoAnsItemStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Write(ref object AutoAnsItemStWork)");
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
        /// �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        public int WriteAutoAnsItemStProc(ref ArrayList AutoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteAutoAnsItemStProcProc(ref AutoAnsItemStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        private int WriteAutoAnsItemStProcProc(ref ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (autoAnsItemStWorkList != null)
                {
                    for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                    {
                        AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF , ENTERPRISECODERF FROM AUTOANSITEMSTRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE  AND SECTIONCODERF = @FINDSECTIONCODE  AND CUSTOMERCODERF = @FINDCUSTOMERCODE   AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (autoAnsItemStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE AUTOANSITEMSTRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                            sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "  , PRMSETDTLNO2RF = @PRMSETDTLNO2 " + Environment.NewLine;
                            sqlText += "  , PRMSETDTLNAME2RF = @PRMSETDTLNAME2 " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  , PRIORITYORDERRF = @PRIORITYORDER " + Environment.NewLine;
                            sqlText += "  WHERE " + Environment.NewLine;
                            sqlText += "        ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                            sqlText += "    AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                            sqlText += "    AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2 " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                            findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (autoAnsItemStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO AUTOANSITEMSTRF " + Environment.NewLine;
                            sqlText += "  ( CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "   ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "   ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "   ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "   ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "   ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "   ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "   ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "   ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "   ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "   ,GOODSMGROUPRF " + Environment.NewLine;
                            sqlText += "   ,BLGOODSCODERF " + Environment.NewLine;
                            sqlText += "   ,GOODSMAKERCDRF " + Environment.NewLine;
                            sqlText += "   ,PRMSETDTLNO2RF " + Environment.NewLine;
                            sqlText += "   ,PRMSETDTLNAME2RF " + Environment.NewLine;
                            sqlText += "   ,AUTOANSWERDIVRF " + Environment.NewLine;
                            sqlText += "   ,PRIORITYORDERRF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  ( @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "   ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "   ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "   ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "   ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "   ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "   ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "   ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "   ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "   ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "   ,@GOODSMGROUP " + Environment.NewLine;
                            sqlText += "   ,@BLGOODSCODE " + Environment.NewLine;
                            sqlText += "   ,@GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "   ,@PRMSETDTLNO2 " + Environment.NewLine;
                            sqlText += "   ,@PRMSETDTLNAME2 " + Environment.NewLine;
                            sqlText += "   ,@AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "   ,@PRIORITYORDER " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);  // �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);  // �D�ǐݒ�ڍז���
                        SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // �����񓚋敪
                        SqlParameter paraPriorityOrder = sqlCommand.Parameters.Add("@PRIORITYORDER", SqlDbType.Int);  // �D�揇��

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(autoAnsItemStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();  // ���_�R�[�h
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);  // ���Ӑ�R�[�h
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);  // ���i�����ރR�[�h
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);  // BL���i�R�[�h
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);  // �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
                        paraPrmSetDtlName2.Value = (object)autoAnsItemStWork.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q�iSqlDataMediator.SqlSetString���g�p����Ƌ󕶎��̃Z�b�g���ł��Ȃ��j
                        paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.AutoAnswerDiv);  // �����񓚋敪
                        paraPriorityOrder.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PriorityOrder); // �D�揇��
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(autoAnsItemStWork);
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

            autoAnsItemStWorkList = al;

            return status;
        }

        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        private int UpdateAllSecAutoAnsItemSt(ref ArrayList AutoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (AutoAnsItemStWorkList != null)
                {
                    AutoAnsItemStWork autoAnsItemStWork = AutoAnsItemStWorkList[0] as AutoAnsItemStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region �X�V����SQL������
                    string sqlText = string.Empty;

                    sqlText += " UPDATE AUTOANSITEMSTRF SET " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                    sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                    sqlText += "  , PRMSETDTLNO2RF = @PRMSETDTLNO2 " + Environment.NewLine;
                    sqlText += "  , PRMSETDTLNAME2RF = @PRMSETDTLNAME2 " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                    sqlText += "  , PRIORITYORDERRF = @PRIORITYORDER " + Environment.NewLine;
                    sqlText += "  WHERE " + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "    AND SECTIONCODERF <>'00'" + Environment.NewLine;
                    sqlText += "    AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "    AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                    sqlText += "    AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                    sqlText += "    AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                    sqlText += "    AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2 " + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                    findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // ���i�����ރR�[�h
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL���i�R�[�h
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // ���i���[�J�[�R�[�h
                    SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);  // �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
                    SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);  // �D�ǐݒ�ڍז���
                    SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // �����񓚋敪
                    SqlParameter paraPriorityOrder = sqlCommand.Parameters.Add("@PRIORITYORDER", SqlDbType.Int);  // �D�揇��

                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(autoAnsItemStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();  // ���_�R�[�h
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);  // ���Ӑ�R�[�h
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);  // ���i�����ރR�[�h
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);  // BL���i�R�[�h
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);  // ���i���[�J�[�R�[�h
                    paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);  // �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
                    paraPrmSetDtlName2.Value = (object)autoAnsItemStWork.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q�iSqlDataMediator.SqlSetString���g�p����Ƌ󕶎��̃Z�b�g���ł��Ȃ��j
                    paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.AutoAnswerDiv);  // �����񓚋敪
                    paraPriorityOrder.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PriorityOrder); // �D�揇��
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
        /// �����񓚕i�ڐݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^����_���폜���܂�</br>
        public int LogicalDelete(ref object autoAnsItemStWork)
        {
            return LogicalDeleteAutoAnsItemSt(ref autoAnsItemStWork, 0);
        }

        /// <summary>
        /// �_���폜�����񓚕i�ڐݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�����񓚕i�ڐݒ�}�X�^���𕜊����܂�</br>
        public int RevivalLogicalDelete(ref object autoAnsItemStWork)
        {
            return LogicalDeleteAutoAnsItemSt(ref autoAnsItemStWork, 1);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        private int LogicalDeleteAutoAnsItemSt(ref object autoAnsItemStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(autoAnsItemStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteAutoAnsItemStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
                // �߂�l�̐ݒ�
                autoAnsItemStWork = paraList;

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
                base.WriteErrorLog(ex, "AutoAnsItemStDB.LogicalDeleteAutoAnsItemSt :" + procModestr);

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
        /// �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        public int LogicalDeleteAutoAnsItemStProc(ref ArrayList AutoAnsItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteAutoAnsItemStProcProc(ref AutoAnsItemStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        private int LogicalDeleteAutoAnsItemStProcProc(ref ArrayList autoAnsItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (autoAnsItemStWorkList != null)
                {
                    for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                    {
                        AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;

                        //Select�R�}���h�̐���
                        // UPD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM AUTOANSITEMSTRF " + GetWhere(), sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM AUTOANSITEMSTRF " + GetWhere3(), sqlConnection, sqlTransaction);
                        // UPD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter findPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        findPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE AUTOANSITEMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " + GetWhere();
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                            findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                            else if (logicalDelCd == 0) autoAnsItemStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else autoAnsItemStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) autoAnsItemStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();

                    }

                    // �폜�A�����ΏۂƂȂ������R�[�h�̎擾
                    if (autoAnsItemStWorkList.Count > 0)
                    {
                        GetTargetRcord(myReader, sqlCommand, ref al, autoAnsItemStWorkList[0] as AutoAnsItemStWork);
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

            autoAnsItemStWorkList = al;

            return status;

        }

        /// <summary>
        /// �ΏۂƂȂ������R�[�h�̎擾
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="al"></param>
        /// <param name="autoAnsItemStWork"></param>
        /// <returns></returns>
        private int GetTargetRcord(SqlDataReader myReader, SqlCommand sqlCommand, ref ArrayList al, AutoAnsItemStWork autoAnsItemStWork)
        {
            al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // �ΏۂƂȂ������R�[�h�̎擾
                #region Select
                string selectTxt = string.Empty;
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += GetWhere2();

                #endregion

                sqlCommand.CommandText = selectTxt;
                sqlCommand.Parameters.Clear();
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
    
            return status;
        }

        /// <summary>
        /// �D�ǐݒ�ڍ׃R�[�h�Q���������L�[���ڂ����������ɂ���WHERE��
        /// GetWhere��GetWhere2�͓������e�ɂ��邱��
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            return "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD";
        }

        /// <summary>
        /// �D�ǐݒ�ڍ׃R�[�h�Q���������L�[���ڂ����������ɂ���WHERE��
        /// GetWhere��GetWhere2�͓������e�ɂ��邱��
        /// </summary>
        /// <returns></returns>
        private string GetWhere2()
        {
            return "WHERE ATA.ENTERPRISECODERF=@FINDENTERPRISECODE AND ATA.SECTIONCODERF=@FINDSECTIONCODE AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD";
        }
        
        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �L�[���ڂ����������ɂ���WHERE��
        /// </summary>
        /// <returns></returns>
        private string GetWhere3()
        {
            return "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND PRMSETDTLNO2RF = @PRMSETDTLNO2";
        }
        // ADD 2012/11/20 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��20 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region [Delete]
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�����񓚕i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�</br>
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

                status = DeleteAutoAnsItemStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Delete");
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
        /// �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">�����񓚕i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        public int DeleteAutoAnsItemStProc(ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteAutoAnsItemStProcProc(autoAnsItemStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">�����񓚕i�ڐݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        private int DeleteAutoAnsItemStProcProc(ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                {
                    AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM AUTOANSITEMSTRF " 
                                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                                              +   " AND SECTIONCODERF  = @FINDSECTIONCODE "
                                              +   " AND CUSTOMERCODERF = @FINDCUSTOMERCODE "
                                              +   " AND GOODSMGROUPRF  = @FINDGOODSMGROUP "
                                              +   " AND BLGOODSCODERF  = @FINDBLGOODSCODE "
                                              +   " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD "
                                              , sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM AUTOANSITEMSTRF "
                                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                                              + " AND SECTIONCODERF  = @FINDSECTIONCODE "
                                              + " AND CUSTOMERCODERF = @FINDCUSTOMERCODE "
                                              + " AND GOODSMGROUPRF  = @FINDGOODSMGROUP "
                                              + " AND BLGOODSCODERF  = @FINDBLGOODSCODE "
                                              + " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD ";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
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
        /// <param name="AutoAnsItemStOrderWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30745�@�g���@�F��</br>
        /// <br>Date       : 2012/10/25</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AutoAnsItemStOrderWork AutoAnsItemStOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ATA.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(AutoAnsItemStOrderWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(AutoAnsItemStOrderWork.SectionCode) == false)
            {
                retstring += "AND ATA.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(AutoAnsItemStOrderWork.SectionCode);
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND ATA.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND ATA.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // ���Ӑ�R�[�h
            if (AutoAnsItemStOrderWork.St_CustomerCode != 0)
            {
                retstring += "AND ATA.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_CustomerCode);
            }
            if (AutoAnsItemStOrderWork.Ed_CustomerCode != 0)
            {
                retstring += "AND ATA.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_CustomerCode);
            }

            // ���i�����ރR�[�h
            if (AutoAnsItemStOrderWork.St_GoodsMGroup != 0) 
            {
                retstring += "AND ATA.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_GoodsMGroup);
            } 
            if (AutoAnsItemStOrderWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND ATA.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_GoodsMGroup);
            }

            // BL���i�R�[�h
            if (AutoAnsItemStOrderWork.St_BLGoodsCode != 0)
            {
                retstring += "AND ATA.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_BLGoodsCode);
            }
            if (AutoAnsItemStOrderWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND ATA.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_BLGoodsCode);
            }

            // ���[�J�[�R�[�h
            if (AutoAnsItemStOrderWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND ATA.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_GoodsMakerCd);
            }
            if (AutoAnsItemStOrderWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND ATA.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_GoodsMakerCd);
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
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromReader(ref SqlDataReader myReader)
        {
            AutoAnsItemStWork wkAutoAnsItemStWork = new AutoAnsItemStWork();
            #region �N���X�֊i�[
            wkAutoAnsItemStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkAutoAnsItemStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkAutoAnsItemStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkAutoAnsItemStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkAutoAnsItemStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkAutoAnsItemStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkAutoAnsItemStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkAutoAnsItemStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkAutoAnsItemStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkAutoAnsItemStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
            wkAutoAnsItemStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // ���i�����ރR�[�h
            wkAutoAnsItemStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
            wkAutoAnsItemStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
            wkAutoAnsItemStWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));  // �D�ǐݒ�ڍ׃R�[�h�Q
            wkAutoAnsItemStWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));  // �D�ǐݒ�ڍז��̂Q
            wkAutoAnsItemStWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // �����񓚋敪
            wkAutoAnsItemStWork.PriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYORDERRF"));  // �D�揇��
            wkAutoAnsItemStWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // ���_����
            wkAutoAnsItemStWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // ���Ӑ於��
            wkAutoAnsItemStWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // ���i�����ޖ���
            wkAutoAnsItemStWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL���i�R�[�h����
            wkAutoAnsItemStWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // ���[�J�[����
            #endregion
            return wkAutoAnsItemStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AutoAnsItemStWork[] autoAnsItemStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is AutoAnsItemStWork)
                    {
                        AutoAnsItemStWork wkAutoAnsItemStWork = paraobj as AutoAnsItemStWork;
                        if (wkAutoAnsItemStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAutoAnsItemStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            autoAnsItemStWorkArray = (AutoAnsItemStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AutoAnsItemStWork[]));
                        }
                        catch (Exception) { }
                        if (autoAnsItemStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(autoAnsItemStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AutoAnsItemStWork wkAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(byteArray, typeof(AutoAnsItemStWork));
                                if (wkAutoAnsItemStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAutoAnsItemStWork);
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

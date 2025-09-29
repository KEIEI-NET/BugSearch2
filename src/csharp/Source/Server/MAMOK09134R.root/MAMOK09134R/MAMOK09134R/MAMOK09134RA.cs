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
    /// ���i�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.16</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.04  ���쏹��</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br>           : ���i�ԍ� null �΍�</br>
    /// <br>Update Note: 2008.06.18  ���� ���n</br>
    /// <br>           : PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    [Serializable]
    public class GcdSalesTargetDB : RemoteDB, IGcdSalesTargetDB
    {
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        /// </remarks>
        public GcdSalesTargetDB()
            :
            base("MAMOK09136D", "Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork", "GCDSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">��������</param>
        /// <param name="paragcdsalestargetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int Search(out object gcdsalestargetWork, object paragcdsalestargetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            gcdsalestargetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGcdSalesTargetProc(out gcdsalestargetWork, paragcdsalestargetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GcdSalesTargetDB.Search");
                gcdsalestargetWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgcdsalestargetWork">��������</param>
        /// <param name="paragcdsalestargetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int SearchGcdSalesTargetProc(out object objgcdsalestargetWork, object paragcdsalestargetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork = null; 

            ArrayList gcdsalestargetWorkList = paragcdsalestargetWork as ArrayList;
            if (gcdsalestargetWorkList == null)
            {
                searchGcdSalesTargetParaWork = paragcdsalestargetWork as SearchGcdSalesTargetParaWork;
            }
            else
            {
                if (gcdsalestargetWorkList.Count > 0)
                    searchGcdSalesTargetParaWork = gcdsalestargetWorkList[0] as SearchGcdSalesTargetParaWork;
            }

            int status = SearchGcdSalesTargetProc(out gcdsalestargetWorkList, searchGcdSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            objgcdsalestargetWork = gcdsalestargetWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">��������</param>
        /// <param name="searchGcdSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int SearchGcdSalesTargetProc(out ArrayList gcdsalestargetWorkList, SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGcdSalesTargetProcProc(out gcdsalestargetWorkList, searchGcdSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">��������</param>
        /// <param name="searchGcdSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int SearchGcdSalesTargetProcProc( out ArrayList gcdsalestargetWorkList, SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                selectTxt = "SELECT GCD.* , SEC.SECTIONGUIDENMRF ,SAL.GUIDENAMERF AS SALESCDNMRF ,ENT.GUIDENAMERF AS ENTERPRISEGANRENAMERF FROM GCDSALESTARGETRF AS GCD" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "    ON GCD.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  LEFT JOIN USERGDBDURF AS SAL" + Environment.NewLine;
                selectTxt += "    ON  GCD.ENTERPRISECODERF = SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SALESCODERF = SAL.GUIDECODERF" + Environment.NewLine;
                selectTxt += "    AND SAL.USERGUIDEDIVCDRF = 71" + Environment.NewLine;
                selectTxt += "  LEFT JOIN USERGDBDURF AS ENT" + Environment.NewLine;
                selectTxt += "    ON  GCD.ENTERPRISECODERF = ENT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SALESCODERF = ENT.GUIDECODERF" + Environment.NewLine;
                selectTxt += "    AND ENT.USERGUIDEDIVCDRF = 41" + Environment.NewLine;


                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchGcdSalesTargetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGcdSalesTargetWorkFromReader(ref myReader));

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            gcdsalestargetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GcdSalesTargetWork gcdsalestargetWork = new GcdSalesTargetWork();

                // XML�̓ǂݍ���
                gcdsalestargetWork = (GcdSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(GcdSalesTargetWork));
                if (gcdsalestargetWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref gcdsalestargetWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(gcdsalestargetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GcdSalesTargetDB.Read");
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
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int ReadProc(ref GcdSalesTargetWork gcdsalestargetWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref gcdsalestargetWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int ReadProcProc( ref GcdSalesTargetWork gcdsalestargetWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string selectTxt = string.Empty;

            try
            {
                selectTxt = "SELECT GCD.* , SEC.SECTIONGUIDENMRF ,SAL.GUIDENAMERF AS SALESCDNMRF ,ENT.GUIDENAMERF AS ENTERPRISEGANRENAMERF FROM GCDSALESTARGETRF AS GCD" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "    ON GCD.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  LEFT JOIN USERGDBDURF AS SAL" + Environment.NewLine;
                selectTxt += "    ON  GCD.ENTERPRISECODERF = SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SALESCODERF = SAL.GUIDECODERF" + Environment.NewLine;
                selectTxt += "    AND SAL.USERGUIDEDIVCDRF = 71" + Environment.NewLine;
                selectTxt += "  LEFT JOIN USERGDBDURF AS ENT" + Environment.NewLine;
                selectTxt += "    ON  GCD.ENTERPRISECODERF = ENT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND GCD.SALESCODERF = ENT.GUIDECODERF" + Environment.NewLine;
                selectTxt += "    AND ENT.USERGUIDEDIVCDRF = 41" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                selectTxt += " AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                selectTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                selectTxt += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                    SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                    findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                    findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                    findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        gcdsalestargetWork = CopyToGcdSalesTargetWorkFromReader(ref myReader);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int Write(ref object gcdsalestargetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(gcdsalestargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteGcdSalesTargetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                gcdsalestargetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GcdSalesTargetDB.Write(ref object gcdsalestargetWork)");
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
        /// ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int WriteGcdSalesTargetProc(ref ArrayList gcdsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGcdSalesTargetProcProc(ref gcdsalestargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int WriteGcdSalesTargetProcProc( ref ArrayList gcdsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                if (gcdsalestargetWorkList != null)
                {
                    for (int i = 0; i < gcdsalestargetWorkList.Count; i++)
                    {
                        GcdSalesTargetWork gcdsalestargetWork = gcdsalestargetWorkList[i] as GcdSalesTargetWork;

                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM GCDSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        selectTxt += " AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        selectTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                        selectTxt += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                        findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                        findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != gcdsalestargetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (gcdsalestargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE GCDSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TARGETSETCDRF=@TARGETSETCD , TARGETCONTRASTCDRF=@TARGETCONTRASTCD , TARGETDIVIDECODERF=@TARGETDIVIDECODE , TARGETDIVIDENAMERF=@TARGETDIVIDENAME , GOODSMAKERCDRF=@GOODSMAKERCD , GOODSNORF=@GOODSNO , BLGROUPCODERF=@BLGROUPCODE , BLGOODSCODERF=@BLGOODSCODE , SALESCODERF=@SALESCODE , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE  , APPLYSTADATERF=@APPLYSTADATE , APPLYENDDATERF=@APPLYENDDATE , SALESTARGETMONEYRF=@SALESTARGETMONEY , SALESTARGETPROFITRF=@SALESTARGETPROFIT , SALESTARGETCOUNTRF=@SALESTARGETCOUNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND SALESCODERF=@FINDSALESCODE AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE";

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                            findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                            findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)gcdsalestargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (gcdsalestargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO GCDSALESTARGETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, GOODSMAKERCDRF, GOODSNORF, BLGROUPCODERF, BLGOODSCODERF, SALESCODERF, ENTERPRISEGANRECODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TARGETSETCD, @TARGETCONTRASTCD, @TARGETDIVIDECODE, @TARGETDIVIDENAME, @GOODSMAKERCD, @GOODSNO, @BLGROUPCODE, @BLGOODSCODE, @SALESCODE, @ENTERPRISEGANRECODE, @APPLYSTADATE, @APPLYENDDATE, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)gcdsalestargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                        SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(gcdsalestargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(gcdsalestargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(gcdsalestargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.LogicalDeleteCode);
                        paraSectionCode.Value = gcdsalestargetWork.SectionCode;
                        paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                        paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                        paraTargetDivideName.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                        paraGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(gcdsalestargetWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(gcdsalestargetWork.ApplyEndDate);
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(gcdsalestargetWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(gcdsalestargetWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(gcdsalestargetWork.SalesTargetCount);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(gcdsalestargetWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            gcdsalestargetWorkList = al;

            return status;
        }
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">GcdSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        public int WriteProc(ref object gcdsalestargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraWriteList = CastToArrayListFromPara(gcdsalestargetWork);
                if (paraWriteList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraDeleteList = CastToArrayListFromPara(parabyte);
                if (paraDeleteList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete���s
                status = DeleteGcdSalesTargetProcProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                //write���s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteGcdSalesTargetProcProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    //�Ȃ��B
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
                gcdsalestargetWork = paraWriteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GcdSalesTargetDB.Write(ref object gcdsalestargetWork)");
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
        #endregion
        // ---ADD 2010/12/20---------<<<<<

        #region [LogicalDelete]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int LogicalDelete(ref object gcdsalestargetWork)
        {
            return LogicalDeleteGcdSalesTarget(ref gcdsalestargetWork, 0);
        }

        /// <summary>
        /// �_���폜���i�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int RevivalLogicalDelete(ref object gcdsalestargetWork)
        {
            return LogicalDeleteGcdSalesTarget(ref gcdsalestargetWork, 1);
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int LogicalDeleteGcdSalesTarget(ref object gcdsalestargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(gcdsalestargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGcdSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GcdSalesTargetDB.LogicalDeleteGcdSalesTarget :" + procModestr);

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
        /// ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int LogicalDeleteGcdSalesTargetProc(ref ArrayList gcdsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGcdSalesTargetProcProc(ref gcdsalestargetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">GcdSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int LogicalDeleteGcdSalesTargetProcProc( ref ArrayList gcdsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                if (gcdsalestargetWorkList != null)
                {
                    for (int i = 0; i < gcdsalestargetWorkList.Count; i++)
                    {
                        GcdSalesTargetWork gcdsalestargetWork = gcdsalestargetWorkList[i] as GcdSalesTargetWork;

                        //Select�R�}���h�̐���
                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM GCDSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        selectTxt += " AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        selectTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                        selectTxt += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;


                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                        findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                        findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != gcdsalestargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE GCDSALESTARGETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND SALESCODERF=@FINDSALESCODE AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                            findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                            findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);


                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)gcdsalestargetWork;
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
                            else if (logicalDelCd == 0) gcdsalestargetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else gcdsalestargetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) gcdsalestargetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(gcdsalestargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(gcdsalestargetWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            gcdsalestargetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
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

                status = DeleteGcdSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GcdSalesTargetDB.Delete");
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
        /// ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">���i�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        public int DeleteGcdSalesTargetProc(ArrayList gcdsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGcdSalesTargetProcProc(gcdsalestargetWorkList,ref sqlConnection,ref sqlTransaction);
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="gcdsalestargetWorkList">���i�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        private int DeleteGcdSalesTargetProcProc( ArrayList gcdsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectTxt = string.Empty;

            try
            {

                for (int i = 0; i < gcdsalestargetWorkList.Count; i++)
                {
                    GcdSalesTargetWork gcdsalestargetWork = gcdsalestargetWorkList[i] as GcdSalesTargetWork;

                    selectTxt = string.Empty;
                    selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM GCDSALESTARGETRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                    selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                    selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                    selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    selectTxt += " AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                    selectTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    selectTxt += " AND SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                    selectTxt += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                    SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                    findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                    findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                    findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != gcdsalestargetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND SALESCODERF=@FINDSALESCODE AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = gcdsalestargetWork.SectionCode;
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdsalestargetWork.TargetDivideCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.GoodsMakerCd);
                        findParaGoodsNo.Value = gcdsalestargetWork.GoodsNo;
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.SalesCode);
                        findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdsalestargetWork.EnterpriseGanreCode);
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

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="searchGcdSalesTargetParaWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        /// <br>Update Note: 2010/12/20  ������</br>
        /// <br>           : ���В�����ύX��ɁA�Ăяo�����s���Ǝ擾�o���Ȃ����R�[�h�����錻�ۂ̏C��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "GCD.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchGcdSalesTargetParaWork.EnterpriseCode);

		    //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND GCD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND GCD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            //���_�R�[�h
            if (searchGcdSalesTargetParaWork.AllSecSelEpUnit == false && searchGcdSalesTargetParaWork.AllSecSelSecUnit == false)
            {
                if (searchGcdSalesTargetParaWork.SelectSectCd != null)
                {
                    wkstring = "";
                    foreach (string seccdstr in searchGcdSalesTargetParaWork.SelectSectCd)
                    {
                        if (wkstring != "") wkstring += ",";
                        wkstring += "'" + seccdstr + "'";
                    }
                    if (wkstring != "")
                    {
                        retstring += "AND GCD.SECTIONCODERF IN (" + wkstring + ") ";
                    }
                }
            }

            //�ڕW�ݒ�敪
            if (searchGcdSalesTargetParaWork.TargetSetCd > 0)
            {
                retstring += "AND GCD.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.TargetSetCd);
            }

            //�ڕW�Δ�敪
            if (searchGcdSalesTargetParaWork.TargetContrastCd > 0)
            {
                retstring += "AND GCD.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.TargetContrastCd);
            }
            // ---UPD 2010/12/20--------->>>>>
            ////�ڕW�敪�R�[�h
            //if (searchGcdSalesTargetParaWork.TargetDivideCode != "")
            //{
            //    retstring += "AND GCD.TARGETDIVIDECODERF=@TARGETDIVIDECODE ";
            //    SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            //    paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(searchGcdSalesTargetParaWork.TargetDivideCode);
            //}

            //�ڕW�敪�R�[�h
            if (searchGcdSalesTargetParaWork.TargetDivideCode != "")
            {
                retstring += "AND GCD.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND GCD.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchGcdSalesTargetParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchGcdSalesTargetParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchGcdSalesTargetParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }
            // ---UPD 2010/12/20---------<<<<<
            //�ڕW�敪����
            if (searchGcdSalesTargetParaWork.TargetDivideName != "")
            {
                retstring += "AND GCD.TARGETDIVIDENAMERF LIKE @TARGETDIVIDENAME ";
                SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                paraTargetDivideName.Value = SqlDataMediator.SqlSetString("%" + searchGcdSalesTargetParaWork.TargetDivideName + "%");
            }
            // ---DEL 2010/12/20--------->>>>>
            ////�K�p�J�n���i�J�n�j
            //if (searchGcdSalesTargetParaWork.StartApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND GCD.APPLYSTADATERF>=@APPLYSTADATE ";
            //    SqlParameter paraStartApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraStartApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchGcdSalesTargetParaWork.StartApplyStaDate);
            //}

            ////�K�p�J�n���i�I���j
            //if (searchGcdSalesTargetParaWork.EndApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND GCD.APPLYSTADATERF<=@APPLYSTADATE ";
            //    SqlParameter paraEndApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraEndApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchGcdSalesTargetParaWork.EndApplyStaDate);
            //}

            ////�K�p�I�����i�J�n�j
            //if (searchGcdSalesTargetParaWork.StartApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND GCD.APPLYENDDATERF>=@APPLYENDDATE ";
            //    SqlParameter paraStartApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraStartApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchGcdSalesTargetParaWork.StartApplyEndDate);
            //}

            ////�K�p�I�����i�I���j
            //if (searchGcdSalesTargetParaWork.EndApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND GCD.APPLYENDDATERF<=@APPLYENDDATE ";
            //    SqlParameter paraEndApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraEndApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchGcdSalesTargetParaWork.EndApplyEndDate);
            //}
            // ---DEL 2010/12/20---------<<<<<
            //���[�J�[�R�[�h
            if (searchGcdSalesTargetParaWork.GoodsMakerCd > 0)
            {
                retstring += "AND GCD.GOODSMAKERCDRF=@GOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.GoodsMakerCd);
            }

            //�i��
            if (string.IsNullOrEmpty(searchGcdSalesTargetParaWork.GoodsNo) == false)
            {
                retstring += "AND GCD.GOODSNORF=@GOODSNO ";
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = searchGcdSalesTargetParaWork.GoodsNo;
                
            }

            //BL�O���[�v�R�[�h
            if (searchGcdSalesTargetParaWork.BLGroupCode > 0)
            {
                retstring += "AND GCD.BLGROUPCODERF=@BLGROUPCODE ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.BLGroupCode);
            }

            //BL�R�[�h
            if (searchGcdSalesTargetParaWork.BLGoodsCode > 0)
            {
                retstring += "AND GCD.BLGOODSCODERF=@BLGOODSCODE ";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.BLGoodsCode);
            }

            //�̔��敪�R�[�h
            if (searchGcdSalesTargetParaWork.SalesCode > 0)
            {
                retstring += "AND GCD.SALESCODERF=@SALESCODE ";
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.SalesCode);
            }

            //���Е��ރR�[�h
            if (searchGcdSalesTargetParaWork.EnterpriseGanreCode > 0)
            {
                retstring += "AND GCD.ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE ";
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(searchGcdSalesTargetParaWork.EnterpriseGanreCode);
            }

            //�\�[�g����
            retstring += "ORDER BY GCD.SECTIONCODERF,GCD.APPLYSTADATERF,GCD.APPLYENDDATERF,GCD.GOODSMAKERCDRF,GCD.GOODSNORF,GCD.BLGROUPCODERF,GCD.BLGOODSCODERF,GCD.SALESCODERF,GCD.ENTERPRISEGANRECODERF ";

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GcdSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GcdSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        /// </remarks>
        private GcdSalesTargetWork CopyToGcdSalesTargetWorkFromReader(ref SqlDataReader myReader)
        {
            GcdSalesTargetWork wkGcdSalesTargetWork = new GcdSalesTargetWork();

            #region �N���X�֊i�[
            wkGcdSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGcdSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGcdSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGcdSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGcdSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGcdSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGcdSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGcdSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGcdSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkGcdSalesTargetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkGcdSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkGcdSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkGcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkGcdSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkGcdSalesTargetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGcdSalesTargetWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            if (wkGcdSalesTargetWork.GoodsNo == null)
                wkGcdSalesTargetWork.GoodsNo = string.Empty;
            wkGcdSalesTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkGcdSalesTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            wkGcdSalesTargetWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
            wkGcdSalesTargetWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGcdSalesTargetWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            wkGcdSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkGcdSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkGcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkGcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkGcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkGcdSalesTargetWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GcdSalesTargetWork[] GcdSalesTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GcdSalesTargetWork)
                    {
                        GcdSalesTargetWork wkGcdSalesTargetWork = paraobj as GcdSalesTargetWork;
                        if (wkGcdSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGcdSalesTargetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GcdSalesTargetWorkArray = (GcdSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GcdSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (GcdSalesTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GcdSalesTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GcdSalesTargetWork wkGcdSalesTargetWork = (GcdSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(GcdSalesTargetWork));
                                if (wkGcdSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGcdSalesTargetWork);
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
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.16</br>
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

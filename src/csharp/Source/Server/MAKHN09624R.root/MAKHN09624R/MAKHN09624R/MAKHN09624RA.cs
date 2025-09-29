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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Z�b�g�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Z�b�g�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br></br>
    /// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>           : 2007.09.26 DC.NS�p�ɕύX</br>
    /// <br>Update Note: 2008.06.09 22008 ���� ���n</br>
    /// </remarks>
    [Serializable]
    public class GoodsSetDB : RemoteDB, IGoodsSetDB, IGetSyncdataList
    {
        /// <summary>
        /// ���i�Z�b�g�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        public GoodsSetDB()
            :
            base("MAKHN09626D", "Broadleaf.Application.Remoting.ParamData.GoodsSetWork", "GOODSSETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsSetWork">��������</param>
        /// <param name="paragoodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int Search(out object goodsSetWork, object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsSetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsSetProc(out goodsSetWork, paragoodsSetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Search");
                goodsSetWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsSetWork">��������</param>
        /// <param name="paragoodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out object objgoodsSetWork, object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsSetWork goodsSetWork = null;

            ArrayList goodsSetWorkList = paragoodsSetWork as ArrayList;
            if (goodsSetWorkList == null)
            {
                goodsSetWork = paragoodsSetWork as GoodsSetWork;
            }
            else
            {
                if (goodsSetWorkList.Count > 0)
                    goodsSetWork = goodsSetWorkList[0] as GoodsSetWork;
            }

            int status = SearchGoodsSetProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection);
            objgoodsSetWork = goodsSetWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">��������</param>
        /// <param name="goodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return SearchGoodsSetProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">��������</param>
        /// <param name="goodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchGoodsSetProcProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">��������</param>
        /// <param name="goodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int SearchGoodsSetProcProc( out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   GSET.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,GSET.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.CNTFLRF" + Environment.NewLine;
                sqlText += "  ,GSET.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "  ,GSET.SETSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GSET.CATALOGSHAPENORF" + Environment.NewLine;
                sqlText += "  ,GOODSP.GOODSNAMERF AS PARENTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS SUBGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERP.MAKERNAMERF AS PARENTMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS SUBMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM GOODSSETRF AS GSET" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSNORF=GOODSP.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=GOODSP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=MAKERP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsSetWorkFromReader(ref myReader,0));

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

            goodsSetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsSetWork goodsSetWork = new GoodsSetWork();

                // XML�̓ǂݍ���
                goodsSetWork = (GoodsSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsSetWork));
                if (goodsSetWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsSetWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(goodsSetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Read");
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
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int ReadProc(ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadProc(ref goodsSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int ReadProc(ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref goodsSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int ReadProcProc( ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   GSET.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,GSET.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.CNTFLRF" + Environment.NewLine;
                sqlText += "  ,GSET.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "  ,GSET.SETSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GSET.CATALOGSHAPENORF" + Environment.NewLine;
                sqlText += "  ,GOODSP.GOODSNAMERF AS PARENTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS SUBGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERP.MAKERNAMERF AS PARENTMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS SUBMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM GOODSSETRF AS GSET" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSNORF=GOODSP.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=GOODSP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=MAKERP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " WHERE GSET.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GSET.PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GSET.PARENTGOODSNORF=@FINDPARENTGOODSNO" + Environment.NewLine;
                sqlText += "  AND GSET.SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GSET.SUBGOODSNORF=@FINDSUBGOODSNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection)) // 2007.09.26 hikita ADD
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                    findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                    findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        goodsSetWork = CopyToGoodsSetWorkFromReader(ref myReader,0);
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
        /// ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int Write(ref object goodsSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteGoodsSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Write(ref object goodsSetWork)");
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
        /// <br>���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>���ꏤ�i�Z�b�g�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="parentGoodsMakerCd">�e���[�J�[�R�[�h</param>
        /// <param name="parentGoodsNo">�e���i�Z�b�g�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.11</br>
        //public int Write(ref object goodsSetWork, string enterpriseCode, string goodsSetCode)  // 2007.09.26 hikita del
        public int Write(ref object goodsSetWork, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo)  // 2007.09.26 hikita add
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //DELETE & INSERT ��Write���s
                status = DeleteInsert(ref paraList, enterpriseCode, parentGoodsMakerCd, parentGoodsNo, ref sqlConnection, ref sqlTransaction);  // 2007.09.26 hikita add

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    status = WriteGoodsSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Write(ref object goodsSetWork)");
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
        /// ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int WriteGoodsSetProc(ref ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsSetProcProc(ref goodsSetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int WriteGoodsSetProcProc( ref ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (goodsSetWorkList != null)
                {
                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita ADD

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsSetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (goodsSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE GOODSSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PARENTGOODSMAKERCDRF=@PARENTGOODSMAKERCD , PARENTGOODSNORF=@PARENTGOODSNO , SUBGOODSMAKERCDRF=@SUBGOODSMAKERCD , SUBGOODSNORF=@SUBGOODSNO , CNTFLRF=@CNTFL , DISPLAYORDERRF=@DISPLAYORDER , SETSPECIALNOTERF=@SETSPECIALNOTE , CATALOGSHAPENORF=@CATALOGSHAPENO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                            findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                            findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                            findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                            findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (goodsSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO GOODSSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PARENTGOODSMAKERCD, @PARENTGOODSNO, @SUBGOODSMAKERCD, @SUBGOODSNO, @CNTFL, @DISPLAYORDER, @SETSPECIALNOTE, @CATALOGSHAPENO)"; // 2007.09.26 hikita add

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
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
                        SqlParameter paraParentGoodsMakerCd = sqlCommand.Parameters.Add("@PARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraParentGoodsNo = sqlCommand.Parameters.Add("@PARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSubGoodsMakerCd = sqlCommand.Parameters.Add("@SUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraSubGoodsNo = sqlCommand.Parameters.Add("@SUBGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraCntFl = sqlCommand.Parameters.Add("@CNTFL", SqlDbType.Float);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        SqlParameter paraSetSpecialNote = sqlCommand.Parameters.Add("@SETSPECIALNOTE", SqlDbType.NVarChar);
                        SqlParameter paraCatalogShapeNo = sqlCommand.Parameters.Add("@CATALOGSHAPENO", SqlDbType.NChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);
                        paraParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        paraParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        paraSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        paraSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
                        paraCntFl.Value = SqlDataMediator.SqlSetDouble(goodsSetWork.CntFl);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.DisplayOrder);
                        paraSetSpecialNote.Value = SqlDataMediator.SqlSetString(goodsSetWork.SetSpecialNote);
                        paraCatalogShapeNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.CatalogShapeNo);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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

            goodsSetWorkList = al;

            return status;
        }

        /// <summary>
        /// ���i�Z�b�g�R�[�h���w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="parentGoodsMakerCd">�e���[�J�[�R�[�h</param>
        /// <param name="parentGoodsNo">�e���i�Z�b�g�R�[�h</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns></returns>
        public int DeleteInsert(ref ArrayList goodsSetWorkList, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            return DeleteInsertProc(ref goodsSetWorkList, enterpriseCode, parentGoodsMakerCd, parentGoodsNo, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�Z�b�g�R�[�h���w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="parentGoodsMakerCd">�e���[�J�[�R�[�h</param>
        /// <param name="parentGoodsNo">�e���i�Z�b�g�R�[�h</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns></returns>
        private int DeleteInsertProc(ref ArrayList goodsSetWorkList, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)   // 2007.09.26 hikita add
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (goodsSetWorkList != null)
                {
                    sqlCommand = new SqlCommand("DELETE FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO", sqlConnection, sqlTransaction);    // 2007.09.26 hikita add


                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(parentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(parentGoodsNo);

                    sqlCommand.ExecuteNonQuery();

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO GOODSSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PARENTGOODSMAKERCD, @PARENTGOODSNO, @SUBGOODSMAKERCD, @SUBGOODSNO, @CNTFL, @DISPLAYORDER, @SETSPECIALNOTE, @CATALOGSHAPENO)"; // 2007.09.26 hikita add

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraParentGoodsMakerCd = sqlCommand.Parameters.Add("@PARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraParentGoodsNo = sqlCommand.Parameters.Add("@PARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraSubGoodsMakerCd = sqlCommand.Parameters.Add("@SUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraSubGoodsNo = sqlCommand.Parameters.Add("@SUBGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraCntFl = sqlCommand.Parameters.Add("@CNTFL", SqlDbType.Float);
                    SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                    SqlParameter paraSetSpecialNote = sqlCommand.Parameters.Add("@SETSPECIALNOTE", SqlDbType.NVarChar);
                    SqlParameter paraCatalogShapeNo = sqlCommand.Parameters.Add("@CATALOGSHAPENO", SqlDbType.NChar);
                    #endregion

                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);
                        paraParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        paraParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        paraSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        paraSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
                        paraCntFl.Value = SqlDataMediator.SqlSetDouble(goodsSetWork.CntFl);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.DisplayOrder);
                        paraSetSpecialNote.Value = SqlDataMediator.SqlSetString(goodsSetWork.SetSpecialNote);
                        paraCatalogShapeNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.CatalogShapeNo);                        
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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
        /// ���i�Z�b�g�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int LogicalDelete(ref object goodsSetWork)
        {
            return LogicalDeleteGoodsSet(ref goodsSetWork, 0);
        }

        /// <summary>
        /// �_���폜���i�Z�b�g�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�Z�b�g�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int RevivalLogicalDelete(ref object goodsSetWork)
        {
            return LogicalDeleteGoodsSet(ref goodsSetWork, 1);
        }

        /// <summary>
        /// ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int LogicalDeleteGoodsSet(ref object goodsSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsSetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsSetDB.LogicalDeleteGoodsSet :" + procModestr);

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
        /// ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int LogicalDeleteGoodsSetProc(ref ArrayList goodsSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsSetProcProc(ref goodsSetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int LogicalDeleteGoodsSetProcProc( ref ArrayList goodsSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (goodsSetWorkList != null)
                {
                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita add

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE GOODSSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                            findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                            findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                            findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                            findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
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
                            else if (logicalDelCd == 0) goodsSetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else goodsSetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsSetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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

            goodsSetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i�Z�b�g�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�Z�b�g�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
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

                status = DeleteGoodsSetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsSetDB.Delete");
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
        /// ���i�Z�b�g�}�X�^���𕨗��폜���܂�(�O�������SqlConnection��SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">���i�Z�b�g�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���𕨗��폜���܂�(�O�������SqlConnection��SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        public int DeleteGoodsSetProc(ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsSetProcProc(goodsSetWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// ���i�Z�b�g�}�X�^���𕨗��폜���܂�(�O�������SqlConnection��SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsSetWorkList">���i�Z�b�g�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���𕨗��폜���܂�(�O�������SqlConnection��SqlTranaction���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private int DeleteGoodsSetProcProc(ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < goodsSetWorkList.Count; i++)
                {
                    GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita add

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                    findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                    findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
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

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Z�b�g���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM GOODSSETRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToGoodsSetWorkFromReader(ref myReader ,1));
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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsSetWork goodsSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //��ƃR�[�h
            retstring.Append("GSET.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND GSET.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND GSET.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�e���[�J�[�R�[�h
            if (IsValidParameter(goodsSetWork.ParentGoodsMakerCd))
            {
                retstring.Append("AND GSET.PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD ");
                SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
            }
            //�e���i�R�[�h
            if (IsValidParameter(goodsSetWork.ParentGoodsNo))
            {
                retstring.Append("AND GSET.PARENTGOODSNORF=@FINDPARENTGOODSNO ");
                SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
            }
            //�q���[�J�[�R�[�h
            if (IsValidParameter(goodsSetWork.SubGoodsMakerCd))
            {
                retstring.Append("AND GSET.SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD ");
                SqlParameter findSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                findSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
            }
            //�q���i�R�[�h
            if (IsValidParameter(goodsSetWork.SubGoodsNo))
            {
                retstring.Append("AND GSET.SUBGOODSNORF=@FINDSUBGOODSNO ");
                SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);
                findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
            }
            //ORDER BY
            retstring.Append("ORDER BY GSET.ENTERPRISECODERF, GSET.DISPLAYORDERRF, GSET.PARENTGOODSMAKERCDRF, GSET.PARENTGOODSNORF, GSET.SUBGOODSMAKERCDRF, GSET.SUBGOODSNORF");

            return retstring.ToString();
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }

        /// <summary>
        /// string���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// int���L���ȃp�����[�^���ǂ����𔻒f����
        /// </summary>
        private bool IsValidParameter(int value)
        {
            return value != 0;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">���[�h</param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        private GoodsSetWork CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            GoodsSetWork wkGoodsSetWork = new GoodsSetWork();

            #region �N���X�֊i�[
            wkGoodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
            wkGoodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
            wkGoodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
            wkGoodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
            wkGoodsSetWork.CntFl        = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
            wkGoodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
            wkGoodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
            #endregion

            if (mode == 0)
            {
                //�V���N�ȊO�̏ꍇ�͏��i�A���[�J�[���̂��Z�b�g
                wkGoodsSetWork.ParentGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNAMERF"));
                wkGoodsSetWork.SubGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNAMERF"));
                wkGoodsSetWork.ParentMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTMAKERNAMERF"));
                wkGoodsSetWork.SubMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBMAKERNAMERF"));
            }

            return wkGoodsSetWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsSetWork[] GoodsSetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsSetWork)
                    {
                        GoodsSetWork wkGoodsSetWork = paraobj as GoodsSetWork;
                        if (wkGoodsSetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsSetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsSetWorkArray = (GoodsSetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsSetWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsSetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsSetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsSetWork wkGoodsSetWork = (GoodsSetWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsSetWork));
                                if (wkGoodsSetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsSetWork);
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
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
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

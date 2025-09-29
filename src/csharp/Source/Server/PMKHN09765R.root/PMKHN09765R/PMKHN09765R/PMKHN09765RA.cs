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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �i�ԕϊ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �i�ԕϊ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
    /// </remarks>
    [Serializable]
    public class GoodsNoChangeDB : RemoteDB, IGoodsNoChangeDB, IGetSyncdataList
    {
        /// <summary>
        /// �i�ԕϊ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public GoodsNoChangeDB()
            :
            base("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork", "GOODSNOCHANGERF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsNoChangeWork">��������</param>
        /// <param name="paragoodsNoChangeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int Search(out object goodsNoChangeWork, object paragoodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsNoChangeWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsNoChangeProc(out goodsNoChangeWork, paragoodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Search");
                goodsNoChangeWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objgoodsNoChangeWork">��������</param>
        /// <param name="paragoodsNoChangeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int SearchGoodsNoChangeProc(out object objgoodsNoChangeWork, object paragoodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsNoChangeWork goodsNoChangeWork = null;

            ArrayList goodsNoChangeWorkList = paragoodsNoChangeWork as ArrayList;
            if (goodsNoChangeWorkList == null)
            {
                goodsNoChangeWork = paragoodsNoChangeWork as GoodsNoChangeWork;
            }
            else
            {
                if (goodsNoChangeWorkList.Count > 0)
                    goodsNoChangeWork = goodsNoChangeWorkList[0] as GoodsNoChangeWork;
            }

            int status = SearchGoodsNoChangeProcProc(out goodsNoChangeWorkList, goodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
            objgoodsNoChangeWork = goodsNoChangeWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">��������</param>
        /// <param name="goodsNoChangeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int SearchGoodsNoChange(out ArrayList goodsNoChangeWorkList, GoodsNoChangeWork goodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsNoChangeWorkList = new ArrayList();
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGoodsNoChangeProcProc(out goodsNoChangeWorkList, goodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.SearchGoodsNoChange");
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
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">��������</param>
        /// <param name="goodsNoChangeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int SearchGoodsNoChangeProcProc(out ArrayList goodsNoChangeWorkList, GoodsNoChangeWork goodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT " + Environment.NewLine
                        + " GDSCHG.CREATEDATETIMERF " + Environment.NewLine
                        + ",GDSCHG.UPDATEDATETIMERF " + Environment.NewLine
                        + ",GDSCHG.ENTERPRISECODERF " + Environment.NewLine
                        + ",GDSCHG.FILEHEADERGUIDRF " + Environment.NewLine
                        + ",GDSCHG.UPDEMPLOYEECODERF " + Environment.NewLine
                        + ",GDSCHG.UPDASSEMBLYID1RF " + Environment.NewLine
                        + ",GDSCHG.UPDASSEMBLYID2RF " + Environment.NewLine
                        + ",GDSCHG.LOGICALDELETECODERF " + Environment.NewLine
                        + ",GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine
                        + ",GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine
                        + ",GDSCHG.GOODSMAKERCDRF " + Environment.NewLine
                        + ",MAKER.MAKERNAMERF " + Environment.NewLine
                        + " FROM GOODSNOCHANGERF GDSCHG WITH(READUNCOMMITTED) " + Environment.NewLine
                        + " LEFT JOIN MAKERURF MAKER WITH(READUNCOMMITTED) " + Environment.NewLine
                        + "   ON MAKER.ENTERPRISECODERF = GDSCHG.ENTERPRISECODERF " + Environment.NewLine
                        + "   AND MAKER.GOODSMAKERCDRF = GDSCHG.GOODSMAKERCDRF " + Environment.NewLine
                        + " WHERE GDSCHG.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine);
                sqlCommand.CommandText = sb.ToString();
                
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToGoodsNoChangeWorkFromReader(ref myReader));

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

            goodsNoChangeWorkList = al;

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();

                // XML�̓ǂݍ���
                goodsNoChangeWork = (GoodsNoChangeWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsNoChangeWork));
                if (goodsNoChangeWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsNoChangeWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(goodsNoChangeWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Read");
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
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int ReadProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref goodsNoChangeWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork"></param>
        /// <param name="readMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int ReadProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc( ref goodsNoChangeWork, readMode, ref sqlConnection, ref sqlTransaction );
        }

        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// <br></br>
        private int ReadProcProc( ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();
                
                // �ύX�_�@�F�g�����U�N�V������n��
                sqlCommand = new SqlCommand( sqlTxt, sqlConnection, sqlTransaction );

                // SetParam
                SetParamForRead( ref sqlCommand, goodsNoChangeWork );

                // �ύX�_�A�F�R�l�N�V�������N���[�Y���Ȃ�
                myReader = sqlCommand.ExecuteReader();
                if ( myReader.Read() )
                {
                    goodsNoChangeWork = CopyToGoodsNoChangeWorkFromReader( ref myReader );
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
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

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int ReadProcProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();
                
                sqlCommand = new SqlCommand( sqlTxt, sqlConnection );

                // SetParam
                SetParamForRead( ref sqlCommand, goodsNoChangeWork );

                myReader = sqlCommand.ExecuteReader( CommandBehavior.CloseConnection );
                if ( myReader.Read() )
                {
                    goodsNoChangeWork = CopyToGoodsNoChangeWorkFromReader( ref myReader );
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( SqlException ex )
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog( ex );
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

            return status;
        }

        /// <summary>
        /// �N�G����������(Read�p)
        /// </summary>
        /// <returns></returns>
        private string GetSqlTextForRead()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT " + Environment.NewLine
                    + " CREATEDATETIMERF " + Environment.NewLine
                    + ",UPDATEDATETIMERF " + Environment.NewLine
                    + ",ENTERPRISECODERF " + Environment.NewLine
                    + ",FILEHEADERGUIDRF " + Environment.NewLine
                    + ",UPDEMPLOYEECODERF " + Environment.NewLine
                    + ",UPDASSEMBLYID1RF " + Environment.NewLine
                    + ",UPDASSEMBLYID2RF " + Environment.NewLine
                    + ",LOGICALDELETECODERF " + Environment.NewLine
                    + ",CHGSRCGOODSNORF " + Environment.NewLine
                    + ",CHGDESTGOODSNORF " + Environment.NewLine
                    + ",GOODSMAKERCDRF " + Environment.NewLine
                    + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                    + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                    + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO " + Environment.NewLine);
            return sb.ToString();
        }
        /// <summary>
        /// �p�����[�^�ݒ菈��(Read�p)
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="goodsNoChangeWork"></param>
        private void SetParamForRead( ref SqlCommand sqlCommand, GoodsNoChangeWork goodsNoChangeWork )
        {
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( goodsNoChangeWork.EnterpriseCode );
            findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
        }
        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,CHGSRCGOODSNORF " + Environment.NewLine;
                sqlTxt += "  ,CHGDESTGOODSNORF " + Environment.NewLine;
                sqlTxt += "  ,GOODSMAKERCDRF " + Environment.NewLine;
                sqlTxt += "FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsNoChangeWorkFromReader(ref myReader));

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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �i�ԕϊ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int Write(ref object goodsNoChangeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                //ArrayList paraList = CastToArrayListFromPara(goodsNoChangeWork);
                GoodsNoChangeWork goodsNoChangeWorkProc = goodsNoChangeWork as GoodsNoChangeWork;
                if (goodsNoChangeWorkProc == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteGoodsNoChangeProc(ref goodsNoChangeWorkProc, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                goodsNoChangeWork = goodsNoChangeWorkProc;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Write");
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
        /// �i�ԕϊ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int WriteGoodsNoChangeProc(ref GoodsNoChangeWork goodsNoChangeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsNoChangeProcProc(ref goodsNoChangeWork,ref sqlConnection,ref sqlTransaction);
        }
        
        /// <summary>
        /// �i�ԕϊ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int WriteGoodsNoChangeProcProc(ref GoodsNoChangeWork goodsNoChangeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                string sqlTxt = "";
            
                sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT " + Environment.NewLine
                        + " UPDATEDATETIMERF " + Environment.NewLine
                        + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                        + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                        + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                        + "  AND GOODSMAKERCDRF=@GOODSMAKERCDRF" + Environment.NewLine);

                sqlCommand.CommandText = sb.ToString();
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaGoodsMakerCode = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                findParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (goodsNoChangeWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }
                    
                    sqlTxt = "";
                    sqlTxt += "UPDATE GOODSNOCHANGERF SET " + Environment.NewLine;
                    sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME " + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME " + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID " + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE " + Environment.NewLine;
                    sqlTxt += " , CHGSRCGOODSNORF=@CHGSRCGOODSNO " + Environment.NewLine;
                    sqlTxt += " , CHGDESTGOODSNORF=@CHGDESTGOODSNO " + Environment.NewLine;
                    sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD " + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += "   AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += "   AND GOODSMAKERCDRF=@GOODSMAKERCDRF" + Environment.NewLine;
                    
                    sqlCommand.CommandText = sqlTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                    findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                    findParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (goodsNoChangeWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }
                    
                    sqlTxt = "";
                    sqlTxt += "INSERT INTO GOODSNOCHANGERF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += ", ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += ", FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += ", UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += ", UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += ", UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += ", CHGSRCGOODSNORF" + Environment.NewLine;
                    sqlTxt += ", CHGDESTGOODSNORF" + Environment.NewLine;
                    sqlTxt += ", GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += ") " + Environment.NewLine;
                    sqlTxt += "VALUES " + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += ", @UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += ", @ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += ", @FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += ", @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += ", @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += ", @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += ", @LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += ", @CHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += ", @CHGDESTGOODSNO" + Environment.NewLine;
                    sqlTxt += ", @GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += ")" + Environment.NewLine;

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = sqlTxt;
                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraOldGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraNewGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsNoChangeWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.LogicalDeleteCode);
                paraOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                // �V�i��
                if (SqlDataMediator.SqlSetString(goodsNoChangeWork.NewGoodsNo) == DBNull.Value)
                {
                    paraNewGoodsNo.Value = "";
                }
                else
                {
                    paraNewGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.NewGoodsNo);
                }
                // ���[�J�[
                if (SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd) == DBNull.Value)
                {
                    paraGoodsMakerCd.Value = 0;
                }
                else
                {
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);
                }
                #endregion

                sqlCommand.ExecuteNonQuery();

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
                    if (!myReader.IsClosed) myReader.Close();
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
        /// �i�ԕϊ��}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int LogicalDelete(ref object goodsNoChangeWork)
        {
            return LogicalDeleteGoodsNoChange(ref goodsNoChangeWork, 0);
        }

        /// <summary>
        /// �_���폜�i�ԕϊ��}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�i�ԕϊ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int RevivalLogicalDelete(ref object goodsNoChangeWork)
        {
            return LogicalDeleteGoodsNoChange(ref goodsNoChangeWork, 1);
        }

        /// <summary>
        /// �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int LogicalDeleteGoodsNoChange(ref object goodsNoChangeWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(goodsNoChangeWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsNoChangeProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsNoChangeDB.LogicalDeleteGoodsMng :" + procModestr);

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
        /// �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int LogicalDeleteGoodsNoChangeProc(ref ArrayList goodsNoChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsNoChangeProcProc(ref goodsNoChangeWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">GoodsNoChangeWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int LogicalDeleteGoodsNoChangeProcProc(ref ArrayList goodsNoChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string sqlTxt = "";

                if (goodsNoChangeWorkList != null)
                {
                    for (int i = 0; i < goodsNoChangeWorkList.Count; i++)
                    {
                        GoodsNoChangeWork goodsNoChangeWork = goodsNoChangeWorkList[i] as GoodsNoChangeWork;
                        sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT " + Environment.NewLine
                                + " UPDATEDATETIMERF " + Environment.NewLine
                                + " ,LOGICALDELETECODERF " + Environment.NewLine
                                + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                                + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                                + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                                + "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine);
                        sqlCommand.CommandText = sb.ToString();
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMaker = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                        findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                        findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSNOCHANGERF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine;

                            sqlCommand.CommandText = sqlTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                            findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                            findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
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
                            else if (logicalDelCd == 0) goodsNoChangeWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else goodsNoChangeWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsNoChangeWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsNoChangeWork);
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

            goodsNoChangeWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �i�ԕϊ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�i�ԕϊ��}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
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

                status = DeleteGoodsNoChangeProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Delete");
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
        /// �i�ԕϊ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">�i�ԕϊ��}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        public int DeleteGoodsNoChangeProc(ArrayList goodsNoChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsNoChangeProcProc(goodsNoChangeWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �i�ԕϊ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">�i�ԕϊ��}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �i�ԕϊ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private int DeleteGoodsNoChangeProcProc(ArrayList goodsNoChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";

                for (int i = 0; i < goodsNoChangeWorkList.Count; i++)
                {
                    GoodsNoChangeWork goodsNoChangeWork = goodsNoChangeWorkList[i] as GoodsNoChangeWork;
                    sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT " + Environment.NewLine
                            + "  UPDATEDATETIMERF " + Environment.NewLine
                            + " ,LOGICALDELETECODERF " + Environment.NewLine
                            + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                            + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                            + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                            + "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine);
                    sqlCommand.CommandText = sb.ToString();
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsMaker = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                    findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                    findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSNOCHANGERF " + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO " + Environment.NewLine;
                        sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                        findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                        findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
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
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsNoChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsNoChangeWork</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChangeWork CopyToGoodsNoChangeWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsNoChangeWork wkGoodsNoChangeWork = new GoodsNoChangeWork();

            #region �N���X�֊i�[
            wkGoodsNoChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsNoChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsNoChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsNoChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsNoChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsNoChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsNoChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsNoChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsNoChangeWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
            wkGoodsNoChangeWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
            wkGoodsNoChangeWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsNoChangeWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            #endregion

            return wkGoodsNoChangeWork;
        }

        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsNoChangeWork[] GoodsNoChangeWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsNoChangeWork)
                    {
                        GoodsNoChangeWork wkGoodsNoChangeWork = paraobj as GoodsNoChangeWork;
                        if (wkGoodsNoChangeWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsNoChangeWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsNoChangeWorkArray = (GoodsNoChangeWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsNoChangeWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsNoChangeWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsNoChangeWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsNoChangeWork wkGoodsNoChangeWork = (GoodsNoChangeWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsNoChangeWork));
                                if (wkGoodsNoChangeWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsNoChangeWork);
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
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
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

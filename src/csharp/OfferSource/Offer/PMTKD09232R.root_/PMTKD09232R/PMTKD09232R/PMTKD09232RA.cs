//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015.02.06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �� �B</br>
    /// <br>Date       : 2015.02.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkODB : RemoteDB, IRecGoodsLkODB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public RecGoodsLkODB() : base("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork", "RecGoodsLkORF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [�g�����U�N�V������������]
        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction��������</br>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region IRecGoodsLkODB �����o

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkOWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int Search(out object RecGoodsLkOWorkList, RecGoodsLkOWork parseRecGoodsLkOWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkOWorkList = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out RecGoodsLkOWorkList, parseRecGoodsLkOWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkODB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkOWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int SearchProc(out object RecGoodsLkOWorkList, RecGoodsLkOWork parseRecGoodsLkOWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkOWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT OFFERDATERF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKORF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkODB.SearchProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            RecGoodsLkOWorkList = al;

            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int Read(ref object RecGoodsLkOWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref RecGoodsLkOWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkODB.Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int ReadProc(ref object RecGoodsLkOWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RecGoodsLkOWork wkRecGoodsLkOWorkOld = null;
            RecGoodsLkOWork wkRecGoodsLkOWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (RecGoodsLkOWorkList != null)
            {
                wkRecGoodsLkOWorkOld = RecGoodsLkOWorkList as RecGoodsLkOWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkOWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT OFFERDATERF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKORF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     RECSOURCEBLGOODSCDRF=@RECSOURCEBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append("     RECDESTBLGOODSCDRF=@RECDESTBLGOODSCD ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.NChar);
                SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.NChar);
                
                //KEY�R�}���h���Đݒ�
                findParaRecSourceBLGoodsCd.Value = wkRecGoodsLkOWorkOld.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = wkRecGoodsLkOWorkOld.RecDestBLGoodsCd;
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkRecGoodsLkOWorkNew);
                if (wkRecGoodsLkOWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkODB.ReadProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            RecGoodsLkOWorkList = wkRecGoodsLkOWorkNew;

            return status;
        }

        #endregion

        #region ��������
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�擾����
        /// </summary>
        /// <param name="myReader">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^Reader</param>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <returns>���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList RecGoodsLkOWorkList)
        {
            RecGoodsLkOWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�񋟓��t
            int colIndex_OfferDate = 0;
            //������BL���i�R�[�h
            int colIndex_RecSourceBLGoodsCd = 0;
            //������BL���i�R�[�h
            int colIndex_RecDestBLGoodsCd = 0;
            //���i�R�����g
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                //�񋟓��t
                colIndex_OfferDate = myReader.GetOrdinal("OFFERDATERF");
                //������BL���i�R�[�h
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //������BL���i�R�[�h
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //���i�R�����g
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");
            }
            while (myReader.Read())
            {

                RecGoodsLkOWork RecGoodsLkOWork = new RecGoodsLkOWork();
                //�񋟓��t
                RecGoodsLkOWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_OfferDate);
                //������BL���i�R�[�h
                RecGoodsLkOWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //������BL���i�R�[�h
                RecGoodsLkOWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //���i�R�����g
                RecGoodsLkOWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                RecGoodsLkOWorkList.Add(RecGoodsLkOWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^Reader</param>
        /// <param name="RecGoodsLkOWork">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^</param>
        /// <returns>���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref RecGoodsLkOWork RecGoodsLkOWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�񋟓��t
            int colIndex_OfferDate = 0;
            //������BL���i�R�[�h
            int colIndex_RecSourceBLGoodsCd = 0;
            //������BL���i�R�[�h
            int colIndex_RecDestBLGoodsCd = 0;
            //���i�R�����g
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                RecGoodsLkOWork = new RecGoodsLkOWork();
                //�񋟓��t
                colIndex_OfferDate = myReader.GetOrdinal("OFFERDATERF");
                //������BL���i�R�[�h
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //������BL���i�R�[�h
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //���i�R�����g
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");

            }
            if(myReader.Read())
            {

                //�񋟓��t
                RecGoodsLkOWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_OfferDate);
                //������BL���i�R�[�h
                RecGoodsLkOWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //������BL���i�R�[�h
                RecGoodsLkOWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //���i�R�����g
                RecGoodsLkOWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

    }
}

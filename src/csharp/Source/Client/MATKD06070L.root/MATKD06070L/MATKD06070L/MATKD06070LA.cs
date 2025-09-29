using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// BL�R�[�h�}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20098�@�����@����</br>
    /// <br>Date       : 2007.04.05</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.01 980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 20081  �D�c �E�l</br>
    /// <br>Date       : 2008.06.09</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br>           : �e�[�u�������ύX����A�S�ʉ����̂��߃R�����g�͎c���܂���</br>
    /// </remarks>
    public class TbsPartsCodeLcDB
    {
        /// <summary>
        /// BL�R�[�hLC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        public TbsPartsCodeLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">��������</param>
        /// <param name="paraTbsPartsCodeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        public int Search(out List<TbsPartsCodeWork> tbsPartsCodeWorkList, TbsPartsCodeWork paraTbsPartsCodeWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            tbsPartsCodeWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchTbsPartsCodeProcProc(out tbsPartsCodeWorkList, paraTbsPartsCodeWork, readMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TbsPartsCodeLcDB.Search",0);
                tbsPartsCodeWorkList = new List<TbsPartsCodeWork>();
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
        /// �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">��������</param>
        /// <param name="tbsPartsCodeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        public int SearchTbsPartsCodeProc(out List<TbsPartsCodeWork> tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchTbsPartsCodeProcProc(out tbsPartsCodeWorkList, tbsPartsCodeWork, readMode, ref sqlConnection);
            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tbsPartsCodeWorkList">��������</param>
        /// <param name="tbsPartsCodeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        private int SearchTbsPartsCodeProcProc(out List<TbsPartsCodeWork> tbsPartsCodeWorkList, TbsPartsCodeWork tbsPartsCodeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<TbsPartsCodeWork> listdata = new List<TbsPartsCodeWork>();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,EQUIPGENRERF" + Environment.NewLine;
                sqlText += "    ,PRIMESEARCHFLGRF" + Environment.NewLine;
                sqlText += " FROM TBSPARTSCODERF" + Environment.NewLine;
                sqlText += " WHERE TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    listdata.Add(CopyToTbsPartsCodeWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "TbsPartsCodeLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            tbsPartsCodeWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������BL�R�[�hLC��߂��܂�
        /// </summary>
        /// <param name="tbsPartsCodeWork">TbsPartsCodeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC��߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        public int Read(ref TbsPartsCodeWork tbsPartsCodeWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {

               //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref tbsPartsCodeWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TbsPartsCodeLcDB.Read",0);
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
        /// �w�肳�ꂽ������BL�R�[�hLC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tbsPartsCodeWork">TbsPartsCodeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        public int ReadProc(ref TbsPartsCodeWork tbsPartsCodeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref tbsPartsCodeWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������BL�R�[�hLC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tbsPartsCodeWork">TbsPartsCodeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������BL�R�[�hLC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        private int ReadProcProc(ref TbsPartsCodeWork tbsPartsCodeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {
                    //Select�R�}���h�̐���
                    string sqlText = string.Empty;
                    sqlText += "SELECT OFFERDATERF" + Environment.NewLine;
                    sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                    sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                    sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                    sqlText += "    ,TBSPARTSFULLNAMERF" + Environment.NewLine;
                    sqlText += "    ,TBSPARTSHALFNAMERF" + Environment.NewLine;
                    sqlText += "    ,EQUIPGENRERF" + Environment.NewLine;
                    sqlText += "    ,PRIMESEARCHFLGRF" + Environment.NewLine;
                    sqlText += " FROM TBSPARTSCODERF" + Environment.NewLine;
                    sqlText += " WHERE TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCodeWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            tbsPartsCodeWork = CopyToTbsPartsCodeWorkFromReader(ref myReader);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    status = WriteSQLErrorLog(ex, "TbsPartsCodeLcDB.Read", 0);
                }
                finally
                {
                    if (myReader != null)
                        if (!myReader.IsClosed) myReader.Close();
                }

            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� TbsPartsCodeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TbsPartsCodeWork</returns>
        /// <remarks>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        /// <br></br>
        /// <br>Update Note: 2008.02.01 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// </remarks>
        private TbsPartsCodeWork CopyToTbsPartsCodeWorkFromReader(ref SqlDataReader myReader)
        {
            TbsPartsCodeWork wkTbsPartsCodeWork = new TbsPartsCodeWork();

            #region �N���X�֊i�[
            wkTbsPartsCodeWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkTbsPartsCodeWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkTbsPartsCodeWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkTbsPartsCodeWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkTbsPartsCodeWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
            wkTbsPartsCodeWork.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
            wkTbsPartsCodeWork.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
            wkTbsPartsCodeWork.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
            wkTbsPartsCodeWork.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));
            #endregion

            return wkTbsPartsCodeWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_OfferDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [�G���[���O�o�͏���]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}

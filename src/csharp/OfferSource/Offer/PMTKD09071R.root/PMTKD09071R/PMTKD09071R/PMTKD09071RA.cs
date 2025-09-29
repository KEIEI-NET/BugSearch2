//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �Ԏ햼�̃}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMTKD09071R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �Ԏ햼�̃}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ햼�̃}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ModelNameDB : RemoteDB, IModelNameDB
    {
        /// <summary>
        /// �Ԏ햼�̃}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public ModelNameDB()
            : base("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork", "MODELNAMERF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̎Ԏ햼�̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="modelNameObj">ModelNameWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object modelNameObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                ModelNameWork ModelNameWork = modelNameObj as ModelNameWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                    return status;

                status = this.Read(ModelNameWork, sqlConnection, null);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P��̎Ԏ햼�̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="modelNameWork">ModelNameWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ModelNameWork modelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProc(modelNameWork, sqlConnection, sqlTransaction);
        }

        private int ReadProc(ModelNameWork modelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT " + Environment.NewLine;
                sqlText += "OFFERDATERF, " + Environment.NewLine;
                sqlText += "MODELUNIQUECODERF, " + Environment.NewLine;
                sqlText += "MAKERCODERF, " + Environment.NewLine;
                sqlText += "MODELCODERF, " + Environment.NewLine;
                sqlText += "MODELSUBCODERF, " + Environment.NewLine;
                sqlText += "MODELFULLNAMERF, " + Environment.NewLine;
                sqlText += "MODELHALFNAMERF, " + Environment.NewLine;
                sqlText += "MODELALIASNAMERF " + Environment.NewLine;
                sqlText += "FROM " + Environment.NewLine;
                sqlText += "MODELNAMERF " + Environment.NewLine;
                sqlText += "WHERE MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

                //���j�[�N�R�[�h�ݒ�
                GetModelUniqueCode(modelNameWork);
                findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameWork.ModelUniqueCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToModelNameWorkFromReader(myReader, modelNameWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// �Ԏ햼�̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="modelNameList">��������</param>
        /// <param name="modelNameObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����A�S�Ă̎Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object modelNameList, object modelNameObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                if (modelNameList == null)
                {
                    modelNameList = new ArrayList();
                }
                ArrayList modelNameArray = modelNameList as ArrayList;
                ModelNameWork ModelNameWork = modelNameObj as ModelNameWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                    return status;

                status = this.Search(modelNameArray, ModelNameWork, sqlConnection, null);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="modelNameList">�Ԏ햼�̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="ModelNameWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����A�S�Ă̎Ԏ햼�̃}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ArrayList modelNameList, ModelNameWork ModelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchProc(modelNameList, ModelNameWork, sqlConnection, sqlTransaction);
        }

        private int SearchProc(ArrayList modelNameList, ModelNameWork ModelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "OFFERDATERF, " + Environment.NewLine;
                sqlText += "MODELUNIQUECODERF, " + Environment.NewLine;
                sqlText += "MAKERCODERF, " + Environment.NewLine;
                sqlText += "MODELCODERF, " + Environment.NewLine;
                sqlText += "MODELSUBCODERF, " + Environment.NewLine;
                sqlText += "MODELFULLNAMERF, " + Environment.NewLine;
                sqlText += "MODELHALFNAMERF, " + Environment.NewLine;
                sqlText += "MODELALIASNAMERF " + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MODELNAMERF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(sqlCommand, ModelNameWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    modelNameList.Add(this.CopyToModelNameWorkFromReader(myReader));
                }

                if (modelNameList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
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
            }

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="modelNameWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(SqlCommand sqlCommand, ModelNameWork modelNameWork)
        {
            string retstring = string.Empty;

            //�Ԏ�R�[�h
            int stunique, edunique = 0;

            GetModelUniqueCode(modelNameWork);

            if (modelNameWork.OfferDate != 0)
            {
                retstring = " OFFERDATERF > @FINDOFFERDATE" + Environment.NewLine;
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(modelNameWork.OfferDate);
            }
            if (modelNameWork.MakerCode != 0)
            {
                if (retstring != string.Empty)
                    retstring += "AND ";

                if (modelNameWork.ModelSubCode == -1)
                {
                    retstring += "  MODELUNIQUECODERF >= @STMODELUNIQUECODE" + Environment.NewLine;
                    retstring += "  AND MODELUNIQUECODERF <= @EDMODELUNIQUECODE" + Environment.NewLine;

                    if (modelNameWork.ModelCode == 0)
                    {
                        //���[�J�[�R�[�h�݂̂̎w��
                        stunique = modelNameWork.MakerCode * 1000000;
                        edunique = stunique + 999999;
                    }
                    else
                    {
                        //���[�J�[�R�[�h�����f���R�[�h�̎w��
                        stunique = modelNameWork.MakerCode * 1000000 + modelNameWork.ModelCode * 1000;
                        edunique = stunique + 999;
                    }

                    SqlParameter findStModelUniqueCode = sqlCommand.Parameters.Add("@STMODELUNIQUECODE", SqlDbType.Int);
                    SqlParameter findEdModelUniqueCode = sqlCommand.Parameters.Add("@EDMODELUNIQUECODE", SqlDbType.Int);

                    findStModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(stunique);
                    findEdModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(edunique);

                }
                else
                {
                    //���[�J�[�R�[�h�����f���R�[�h���T�u�R�[�h�̎w��
                    retstring += "  MODELUNIQUECODERF = @FINDMODELUNIQUECODE" + Environment.NewLine;
                    SqlParameter findModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);
                    findModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameWork.ModelUniqueCode);
                }
            }
            if (retstring != string.Empty)
                retstring = "WHERE " + retstring;

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� ModelNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ModelNameWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private ModelNameWork CopyToModelNameWorkFromReader(SqlDataReader myReader)
        {
            ModelNameWork ModelNameWork = new ModelNameWork();

            this.CopyToModelNameWorkFromReader(myReader, ModelNameWork);

            return ModelNameWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� ModelNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="modelNameWork">ModelNameWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToModelNameWorkFromReader(SqlDataReader myReader, ModelNameWork modelNameWork)
        {
            if (myReader != null && modelNameWork != null)
            {
                # region �N���X�֊i�[
                modelNameWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                modelNameWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELUNIQUECODERF"));
                modelNameWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                modelNameWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                modelNameWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                modelNameWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                modelNameWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                modelNameWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELALIASNAMERF"));
                # endregion
            }
        }
        # endregion

        # region [���j�[�N�R�[�h�ݒ菈��]
        private void GetModelUniqueCode(ModelNameWork ModelNameWork)
        {
            ModelNameWork.ModelUniqueCode = ModelNameWork.MakerCode * 1000000
                                             + ModelNameWork.ModelCode * 1000
                                             + ModelNameWork.ModelSubCode;
        }

        # endregion

        #region [�R�l�N�V�����쐬]
        private SqlConnection CreateSqlConnection()
        {
            //�r�p�k��������
            SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
            string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();
            return sqlConnection;
        }
        #endregion
    }
}

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
    /// ���j���[����ݒ���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���j���[����ݒ����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30747 �O�ˁ@�L��</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
    public class MenueStDB : RemoteDB, IMenueStDB
    {
        /// <summary>
        /// ���j���[����ݒ���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        public MenueStDB()
            :
            base("PMKHN02207D", "Broadleaf.Application.Remoting.ParamData.MenueStWork", "MENUEST")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�
        /// </summary>
        /// <param name="menueStWork">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sortCode">�����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int Search(out object menueStWork, String enterpriseCode, Int32 sortCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            menueStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchMenueStProc(out menueStWork, enterpriseCode, sortCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MenueStDB.Search");
                menueStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̃��j���[����ݒ������LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objmenueStWork">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sortCode">�����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchMenueStProc(out object objmenueStWork, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            ArrayList menueStWorkList = null;

            int status = SearchMenueStProc(out menueStWorkList, enterpriseCode, sortCode, ref sqlConnection);
            objmenueStWork = menueStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="menueStWorkList">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sortCode">�����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchMenueStProc(out ArrayList menueStWorkList, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            return this.SearchMenueStProcProc(out menueStWorkList, enterpriseCode, sortCode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="menueStWorkList">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sortCode">�����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��j���[����ݒ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int SearchMenueStProcProc(out ArrayList menueStWorkList, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "    RGNS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  , RGNS.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "  , RGNS.ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLECATEGORYIDRF,0) ROLECATEGORYIDRF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLECATEGORYSUBIDRF,0) ROLECATEGORYSUBIDRF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLEITEMIDRF,0) ROLEITEMIDRF" + Environment.NewLine;
                selectTxt += "  , '' SYSTEMNAMERF" + Environment.NewLine;
                selectTxt += "  , ERS.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  , E.NAMERF EMPLOYEENAMERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  ROLEGRPNAMESTRF RGNS " + Environment.NewLine;
                selectTxt += "  LEFT JOIN ROLEGRPAUTHRTSTRF RGAS " + Environment.NewLine;
                selectTxt += "    ON RGNS.ENTERPRISECODERF = RGAS.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND RGNS.ROLEGROUPCODERF = RGAS.ROLEGROUPCODERF " + Environment.NewLine;
                selectTxt += "    AND RGAS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEEROLESTRF ERS " + Environment.NewLine;
                selectTxt += "    ON RGNS.ENTERPRISECODERF = ERS.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND RGNS.ROLEGROUPCODERF = ERS.ROLEGROUPCODERF " + Environment.NewLine;
                selectTxt += "    AND ERS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEERF E " + Environment.NewLine;
                selectTxt += "    ON ERS.ENTERPRISECODERF = E.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND ERS.EMPLOYEECODERF = E.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    AND E.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "WHERE RGNS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  AND RGNS.ENTERPRISECODERF = '" + enterpriseCode + "'" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                switch (sortCode)
                {
                    case 0:
                        {
                            selectTxt += "    ROLEGROUPCODERF" + Environment.NewLine;       // ���[���O���[�v
                            selectTxt += "  , ROLECATEGORYIDRF" + Environment.NewLine;      // �J�e�S��
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // �T�u�J�e�S��
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // �A�C�e��
                            selectTxt += "  , EMPLOYEECODERF" + Environment.NewLine;        // �]�ƈ�
                            break;
                        }
                    case 1:
                        {
                            selectTxt += "    ROLECATEGORYIDRF" + Environment.NewLine;      // �J�e�S��
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // �T�u�J�e�S��
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // �A�C�e��
                            selectTxt += "  , ROLEGROUPCODERF" + Environment.NewLine;       // ���[���O���[�v
                            selectTxt += "  , EMPLOYEECODERF" + Environment.NewLine;        // �]�ƈ�
                            break;
                        }
                    default:
                        {
                            selectTxt += "    EMPLOYEECODERF" + Environment.NewLine;        // �]�ƈ�
                            selectTxt += "  , ROLECATEGORYIDRF" + Environment.NewLine;      // �J�e�S��
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // �T�u�J�e�S��
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // �A�C�e��
                            selectTxt += "  , ROLEGROUPCODERF" + Environment.NewLine;       // ���[���O���[�v
                            break;
                        }
                }


                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMenueStWorkFromReader(ref myReader));

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

            menueStWorkList = al;

            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� MenueStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MenueStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private MenueStWork CopyToMenueStWorkFromReader(ref SqlDataReader myReader)
        {
            MenueStWork wkMenueStWork = new MenueStWork();

            #region �N���X�֊i�[
            wkMenueStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));         // ��ƃR�[�h
            wkMenueStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));            // ���[���O���[�v�R�[�h
            wkMenueStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));           // ���[���O���[�v����
            wkMenueStWork.RoleCategoryId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYIDRF"));          // �J�e�S��
            wkMenueStWork.RoleCategorySubId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYSUBIDRF"));    // �T�u�J�e�S��
            wkMenueStWork.RoleItemId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEITEMIDRF"));                  // �A�C�e��
            wkMenueStWork.SystemName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMNAMERF"));                 // �V�X�e���@�\����
            wkMenueStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));             // �]�ƈ��R�[�h
            wkMenueStWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));             // �]�ƈ�����
            #endregion

            return wkMenueStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            MenueStWork[] MenueStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is MenueStWork)
                    {
                        MenueStWork wkMenueStWork = paraobj as MenueStWork;
                        if (wkMenueStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkMenueStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            MenueStWorkArray = (MenueStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(MenueStWork[]));
                        }
                        catch (Exception) { }
                        if (MenueStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(MenueStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                MenueStWork wkMenueStWork = (MenueStWork)XmlByteSerializer.Deserialize(byteArray, typeof(MenueStWork));
                                if (wkMenueStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkMenueStWork);
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
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
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

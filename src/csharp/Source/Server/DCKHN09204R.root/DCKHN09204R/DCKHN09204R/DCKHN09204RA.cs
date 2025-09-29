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
    /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    [Serializable]
    public class CustSalesTargetDB : RemoteDB, ICustSalesTargetDB
    {
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        public CustSalesTargetDB()
            :
            base("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork", "CUSTSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="custSalesTargetWork">��������</param>
        /// <param name="paracustSalesTargetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int Search(out object custSalesTargetWork, object paracustSalesTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custSalesTargetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCustSalesTargetProc(out custSalesTargetWork, paracustSalesTargetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Search");
                custSalesTargetWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objcustSalesTargetWork">��������</param>
        /// <param name="searchCustSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchCustSalesTargetProc(out object objcustSalesTargetWork, object searchCustSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchCustSalesTargetParaWork custSalesTargetParaWork = null;

            ArrayList custSalesTargetWorkList = searchCustSalesTargetParaWork as ArrayList;
            if (custSalesTargetWorkList == null)
            {
                custSalesTargetParaWork = searchCustSalesTargetParaWork as SearchCustSalesTargetParaWork;
            }
            else
            {
                if (custSalesTargetWorkList.Count > 0)
                    custSalesTargetParaWork = custSalesTargetWorkList[0] as SearchCustSalesTargetParaWork;
            }

            int status = SearchCustSalesTargetProc(out custSalesTargetWorkList, custSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            objcustSalesTargetWork = custSalesTargetWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custSalesTargetWorkList">��������</param>
        /// <param name="searchCustSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchCustSalesTargetProc(out ArrayList custSalesTargetWorkList, SearchCustSalesTargetParaWork searchCustSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM CUSTSALESTARGETRF AS A LEFT JOIN CUSTOMERRF AS B ON A.ENTERPRISECODERF=B.ENTERPRISECODERF AND A.CUSTOMERCODERF=B.CUSTOMERCODERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchCustSalesTargetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCustSalesTargetWorkFromReader(ref myReader));

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

            custSalesTargetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

                // XML�̓ǂݍ���
                custSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSalesTargetWork));
                if (custSalesTargetWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref custSalesTargetWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(custSalesTargetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Read");
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
        /// �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int ReadProc(ref CustSalesTargetWork custSalesTargetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                    findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                    findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        custSalesTargetWork = CopyToCustSalesTargetWorkFromReader(ref myReader);
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
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int Write(ref object custSalesTargetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteCustSalesTargetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                custSalesTargetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Write(ref object custSalesTargetWork)");
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
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custSalesTargetWorkList">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int WriteCustSalesTargetProc(ref ArrayList custSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (custSalesTargetWorkList != null)
                {
                    for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                    {
                        CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (custSalesTargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE CUSTSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TARGETSETCDRF=@TARGETSETCD , TARGETCONTRASTCDRF=@TARGETCONTRASTCD , TARGETDIVIDECODERF=@TARGETDIVIDECODE , TARGETDIVIDENAMERF=@TARGETDIVIDENAME , BUSINESSTYPECODERF=@BUSINESSTYPECODE , SALESAREACODERF=@SALESAREACODE , CUSTOMERCODERF=@CUSTOMERCODE , APPLYSTADATERF=@APPLYSTADATE , APPLYENDDATERF=@APPLYENDDATE , SALESTARGETMONEYRF=@SALESTARGETMONEY , SALESTARGETPROFITRF=@SALESTARGETPROFIT , SALESTARGETCOUNTRF=@SALESTARGETCOUNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                            findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (custSalesTargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO CUSTSALESTARGETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, BUSINESSTYPECODERF, SALESAREACODERF, CUSTOMERCODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TARGETSETCD, @TARGETCONTRASTCD, @TARGETDIVIDECODE, @TARGETDIVIDENAME, @BUSINESSTYPECODE, @SALESAREACODE, @CUSTOMERCODE, @APPLYSTADATE, @APPLYENDDATE, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
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
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custSalesTargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        paraTargetDivideName.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideName);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custSalesTargetWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custSalesTargetWork.ApplyEndDate);
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(custSalesTargetWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(custSalesTargetWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(custSalesTargetWork.SalesTargetCount);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSalesTargetWork);
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

            custSalesTargetWorkList = al;

            return status;
        }
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">CustSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        public int WriteProc(ref object custSalesTargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraWriteList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraWriteList == null) return status;

                ArrayList�@paraDeleteList = CastToArrayListFromPara(parabyte);
                if (paraDeleteList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete���s
                status = DeleteCustSalesTargetProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                //write���s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteCustSalesTargetProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
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
                custSalesTargetWork = paraWriteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Write(ref object custSalesTargetWork)");
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
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int LogicalDelete(ref object custSalesTargetWork)
        {
            return LogicalDeleteCustSalesTarget(ref custSalesTargetWork, 0);
        }

        /// <summary>
        /// �_���폜���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        public int RevivalLogicalDelete(ref object custSalesTargetWork)
        {
            return LogicalDeleteCustSalesTarget(ref custSalesTargetWork, 1);
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        private int LogicalDeleteCustSalesTarget(ref object custSalesTargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCustSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "CustSalesTargetDB.LogicalDeleteCustSalesTarget :" + procModestr);

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
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custSalesTargetWorkList">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int LogicalDeleteCustSalesTargetProc(ref ArrayList custSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (custSalesTargetWorkList != null)
                {
                    for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                    {
                        CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CUSTSALESTARGETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                            findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
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
                            else if (logicalDelCd == 0) custSalesTargetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else custSalesTargetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) custSalesTargetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSalesTargetWork);
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

            custSalesTargetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���Ӑ�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
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

                status = DeleteCustSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CustSalesTargetDB.Delete");
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
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="custSalesTargetWorkList">���Ӑ�ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int DeleteCustSalesTargetProc(ArrayList custSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                    findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                    findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
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
        /// <param name="searchCustSalesTargetParaWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br>Update Note: 2010/12/20  ������</br>
        /// <br>           : ���В�����ύX��ɁA�Ăяo�����s���Ǝ擾�o���Ȃ����R�[�h�����錻�ۂ̏C��</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchCustSalesTargetParaWork searchCustSalesTargetParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND A.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (searchCustSalesTargetParaWork.AllSecSelEpUnit == false && searchCustSalesTargetParaWork.AllSecSelSecUnit == false)
            {
                if (searchCustSalesTargetParaWork.SelectSectCd != null)
                {
                    wkstring = "";
                    foreach (string seccdstr in searchCustSalesTargetParaWork.SelectSectCd)
                    {
                        if (wkstring != "") wkstring += ",";
                        wkstring += "'" + seccdstr + "'";
                    }
                    if (wkstring != "")
                    {
                        retstring += "AND A.SECTIONCODERF IN (" + wkstring + ") ";
                    }
                }
            }

            //�ڕW�ݒ�敪
            if (searchCustSalesTargetParaWork.TargetSetCd > 0)
            {
                retstring += "AND A.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.TargetSetCd);
            }

            //�ڕW�Δ�敪
            if (searchCustSalesTargetParaWork.TargetContrastCd > 0)
            {
                retstring += "AND A.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.TargetContrastCd);
            }
            // ---UPD 2010/12/20--------->>>>>
            ////�ڕW�敪�R�[�h
            //if (searchCustSalesTargetParaWork.TargetDivideCode != "")
            //{
            //    retstring += "AND A.TARGETDIVIDECODERF=@TARGETDIVIDECODE ";
            //    SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            //    paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.TargetDivideCode);
            //}

            //�ڕW�敪�R�[�h
            if (searchCustSalesTargetParaWork.TargetDivideCode != "")
            {
                retstring += "AND A.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND A.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchCustSalesTargetParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchCustSalesTargetParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }
            // ---UPD 2010/12/20---------<<<<<
            //�ڕW�敪����
            if (searchCustSalesTargetParaWork.TargetDivideName != "")
            {
                retstring += "AND A.TARGETDIVIDENAMERF LIKE @TARGETDIVIDENAME ";
                SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                paraTargetDivideName.Value = SqlDataMediator.SqlSetString("%" + searchCustSalesTargetParaWork.TargetDivideName + "%");
            }

            //�Ǝ�R�[�h
            if (searchCustSalesTargetParaWork.BusinessTypeCode > 0)
            {
                retstring += "AND A.BUSINESSTYPECODERF=@BUSINESSTYPECODE ";
                SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.BusinessTypeCode);
            }

            //�̔��G���A�R�[�h
            if (searchCustSalesTargetParaWork.SalesAreaCode > 0)
            {
                retstring += "AND A.SALESAREACODERF=@SALESAREACODE ";
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.SalesAreaCode);
            }

            //���Ӑ�R�[�h
            if (searchCustSalesTargetParaWork.CustomerCode > 0)
            {
                retstring += "AND A.CUSTOMERCODERF=@CUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.CustomerCode);
            }
            // ---DEL 2010/12/20--------->>>>>
            ////�K�p�J�n���i�J�n�j
            //if (searchCustSalesTargetParaWork.StartApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYSTADATERF>=@APPLYSTADATE ";
            //    SqlParameter paraStartApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraStartApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.StartApplyStaDate);
            //}

            ////�K�p�J�n���i�I���j
            //if (searchCustSalesTargetParaWork.EndApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYSTADATERF<=@APPLYSTADATE ";
            //    SqlParameter paraEndApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraEndApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.EndApplyStaDate);
            //}

            ////�K�p�I�����i�J�n�j
            //if (searchCustSalesTargetParaWork.StartApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYENDDATERF>=@APPLYENDDATE ";
            //    SqlParameter paraStartApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraStartApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.StartApplyEndDate);
            //}

            ////�K�p�I�����i�I���j
            //if (searchCustSalesTargetParaWork.EndApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYENDDATERF<=@APPLYENDDATE ";
            //    SqlParameter paraEndApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraEndApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.EndApplyEndDate);
            //}
            // ---DEL 2010/12/20---------<<<<<
            //�\�[�g����
            retstring += "ORDER BY A.SECTIONCODERF,A.APPLYSTADATERF,A.APPLYENDDATERF,A.BUSINESSTYPECODERF,A.SALESAREACODERF,A.CUSTOMERCODERF ";

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        private CustSalesTargetWork CopyToCustSalesTargetWorkFromReader(ref SqlDataReader myReader)
        {
            CustSalesTargetWork wkCustSalesTargetWork = new CustSalesTargetWork();

            #region �N���X�֊i�[
            wkCustSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkCustSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkCustSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkCustSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkCustSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkCustSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkCustSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkCustSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkCustSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkCustSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkCustSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkCustSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkCustSalesTargetWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustSalesTargetWork[] CustSalesTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CustSalesTargetWork)
                    {
                        CustSalesTargetWork wkCustSalesTargetWork = paraobj as CustSalesTargetWork;
                        if (wkCustSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustSalesTargetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustSalesTargetWorkArray = (CustSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (CustSalesTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustSalesTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustSalesTargetWork wkCustSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustSalesTargetWork));
                                if (wkCustSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustSalesTargetWork);
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
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
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

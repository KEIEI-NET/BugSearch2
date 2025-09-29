//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�O���[�v�ݒ�}�X�^
// �v���O�����T�v   : �����������i�O���[�v�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� �j
// �� �� ��  2015/02/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� �j
// �� �� ��  2015/03/05  �C�����e : JOIN�����̕ύX�AGROUPBY��̒ǉ�
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
    /// �����������i�O���[�v�ݒ�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����������i�O���[�v�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���X�� �j</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecBgnGrpDB : RemoteDB, IRecBgnGrpDB
    {

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public RecBgnGrpDB() : base("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork", "RECBGNGRPRF")
        {
        }

        #endregion

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            // �ڑ�������擾
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            // �R�l�N�V�����쐬
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
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region IRecBgnGrpDB �����o

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�S�������j
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="cnectOtherEpCd">PM���Њ�ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, string cnectOtherEpCd, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int substatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retobj = null;
            count = 0;
            ArrayList retAryList = new ArrayList();
            ArrayList retUsrAryList = new ArrayList();

            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ���������i�O���[�v�}�X�^�i�񋟁j�S���擾
                status = SearchAllOfferProc(out retAryList, logicalMode, ref count, ref errMsg, ref sqlConnection);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    // ���������i�O���[�v�}�X�^�i���[�U�j�S���擾
                    substatus = SearchAllProc(out retUsrAryList, cnectOtherEpCd, logicalMode, ref count, ref errMsg, ref sqlConnection);
                    if (substatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (retUsrAryList != null)
                        {
                            retAryList.AddRange(retUsrAryList);
                        }
                        // ���������i�O���[�v�}�X�^�i���[�U�j�̏�Ԃ�Ԃ�
                        status = substatus;
                    }
                    else if (substatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // ���������i�O���[�v�}�X�^�i�񋟁j�̏�Ԃ�߂�
                    }
                    else
                    {
                        // ���������i�O���[�v�}�X�^�i���[�U�j�̏�Ԃ�Ԃ�
                        status = substatus;
                    }
                }
                retobj = retAryList;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, "RecBgnGrpDB.Search");
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
        /// ���������i���������i�O���[�v�}�X�^�����j
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int substatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retobj = null;
            count = 0;
            ArrayList retAryList = new ArrayList();
            ArrayList retUsrAryList = new ArrayList();

            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ���������i�O���[�v�}�X�^�i�񋟁j�S���擾
                status = SearchAllOfferProc(out retAryList, logicalMode, ref count, ref errMsg, ref sqlConnection);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = paraobj as RecBgnGrpSearchParaWork;
                    // SF��ƁE���_�R�[�h���w�肳��Ă��Ȃ��ꍇ�A���[�U�͎擾���Ȃ�
                    if ((recBgnGrpSearchParaWork.InqOriginalEpCd.ToString() != string.Empty)
                    || (recBgnGrpSearchParaWork.InqOriginalSecCd.ToString() != string.Empty))
                    {
                        // ���������i�O���[�v�}�X�^�i���[�U�j�擾
                        substatus = SearchProc(out retUsrAryList, paraobj, logicalMode, ref count, ref errMsg, ref sqlConnection);
                        if (substatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (retUsrAryList != null)
                            {
                                retAryList.AddRange(retUsrAryList);
                            }
                            // ���������i�O���[�v�}�X�^�i���[�U�j�̏�Ԃ�Ԃ�
                            status = substatus;
                        }
                        else if (substatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // ���������i�O���[�v�}�X�^�i�񋟁j�̏�Ԃ�߂�
                        }
                        else
                        {
                            // ���������i�O���[�v�}�X�^�i���[�U�j�̏�Ԃ�Ԃ�
                            status = substatus;
                        }
                    }
                }
                retobj = retAryList;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, "RecBgnGrpDB.Search");
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

        #endregion

        #region ��������

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�S�������j
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="cnectOtherEpCd">PM���Њ�ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchAllProc(out ArrayList retAryList, string cnectOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �����p�N�G���쐬

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                             + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                             + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                             + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                             + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " INNER JOIN SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED) " + Environment.NewLine
                             + " ON EPCNECT.LOGICALDELETECODERF = 0 " + Environment.NewLine
                             + " AND EPCNECT.DISCDIVCDRF = 0 " + Environment.NewLine
                             //--- UPD  2015/03/05 ���X�� ----->>>>>
                             //+ " AND EPCNECT.CNECTORIGINALEPCDRF = @CNECTOTHEREPCD " + Environment.NewLine
                             //+ " AND EPCNECT.CNECTOTHEREPCDRF = RBG.INQORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPCNECT.CNECTORIGINALEPCDRF = RBG.INQORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPCNECT.CNECTOTHEREPCDRF = @CNECTOTHEREPCD " + Environment.NewLine
                             //--- UPD  2015/03/05 ���X�� -----<<<<<
                             + " INNER JOIN SCMEPSCCNTRF AS EPSCCNT WITH(READUNCOMMITTED) " + Environment.NewLine
                             + " ON EPSCCNT.LOGICALDELETECODERF = 0 " + Environment.NewLine
                             + " AND EPSCCNT.DISCDIVCDRF = 0  " + Environment.NewLine
                             + " AND EPSCCNT.CNECTORIGINALEPCDRF = EPCNECT.CNECTORIGINALEPCDRF " + Environment.NewLine
                             + " AND EPSCCNT.CNECTOTHEREPCDRF = EPCNECT.CNECTOTHEREPCDRF " + Environment.NewLine
                             + " AND (EPSCCNT.PCCUOECOMMMETHODRF = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1) " + Environment.NewLine
                             + " AND (RBG.INQORIGINALSECCDRF='00' OR EPSCCNT.CNECTORIGINALSECCDRF = RBG.INQORIGINALSECCDRF) " + Environment.NewLine
                             + " WHERE RBG.LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;

            //--- ADD  2015/03/05 ���X�� ----->>>>>
            string groupTxt = " GROUP BY " + Environment.NewLine
                            + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                            + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                            + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                            + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine;
            //--- ADD  2015/03/05 ���X�� -----<<<<<

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT�쐬
                    sqlTxt.Append(selectTxt.ToString());

                    #region WHERE��쐬

                    // �A�����ƃR�[�h
                    SqlParameter findCnectOtherEpCdRF = sqlCommand.Parameters.Add("@CNECTOTHEREPCD", SqlDbType.NChar);
                    findCnectOtherEpCdRF.Value = SqlDataMediator.SqlSetString(cnectOtherEpCd);

                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    #endregion

                    //--- ADD  2015/03/05 ���X�� ----->>>>>
                    // GROUP��쐬
                    sqlTxt.Append(groupTxt.ToString());
                    //--- ADD  2015/03/05 ���X�� -----<<<<<

                    // ORDER��쐬
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                }  // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGrpDB.SearchAllProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�����j
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out ArrayList retAryList, object paraobj, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �����p�N�G���쐬

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBG.CREATEDATETIMERF, " + Environment.NewLine
                             + " RBG.UPDATEDATETIMERF, " + Environment.NewLine
                             + " RBG.LOGICALDELETECODERF, " + Environment.NewLine
                             + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                             + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBG.DISPLAYORDERRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBG.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " WHERE RBG.LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBG.INQORIGINALEPCDRF, " + Environment.NewLine
                            + " RBG.INQORIGINALSECCDRF, " + Environment.NewLine
                            + " RBG.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();

            try
            {
                RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = paraobj as RecBgnGrpSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT�쐬
                    sqlTxt.Append(selectTxt.ToString());

                    #region WHERE��쐬

                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // �⍇������ƃR�[�h
                    if (recBgnGrpSearchParaWork.InqOriginalEpCd.ToString() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGrpSearchParaWork.InqOriginalEpCd);
                    }

                    // �⍇�������_�R�[�h
                    if (recBgnGrpSearchParaWork.InqOriginalSecCd.ToString() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGrpSearchParaWork.InqOriginalSecCd);
                    }

                    // ���������i�O���[�v�R�[�h
                    if (recBgnGrpSearchParaWork.BrgnGoodsGrpCode != 0)
                    {
                        sqlTxt.Append(" AND RBG.BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE").Append(Environment.NewLine);
                        SqlParameter findBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                        findBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnGrpSearchParaWork.BrgnGoodsGrpCode);
                    }

                    #endregion

                    // ORDER��쐬
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();


                }  // end using

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGrpDB.SearchProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// ���������i���������i�O���[�v�}�X�^�i�񋟁j�����j
        /// </summary>
        /// <param name="retAryList">RecBgnGrpWork�������ʃf�[�^���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)�����ݖ��g�p</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchAllOfferProc(out ArrayList retAryList, ConstantManagement.LogicalMode logicalMode, ref int count, ref string errMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �����p�N�G���쐬

            string selectTxt = " SELECT " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPCODERF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPTITLERF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPTAGRF, " + Environment.NewLine
                             + " RBGO.BRGNGOODSGRPCOMMENTRF " + Environment.NewLine
                             + " FROM RECBGNGRPORF RBGO WITH (READUNCOMMITTED) " + Environment.NewLine
                             + " WHERE RBGO.BRGNGOODSGRPCODERF >= 9000 " + Environment.NewLine
                             + " AND RBGO.BRGNGOODSGRPCODERF <= 9999 " + Environment.NewLine;

            string orderTxt = " ORDER BY " + Environment.NewLine
                            + " RBGO.BRGNGOODSGRPCODERF " + Environment.NewLine;
            #endregion

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // SELECT�쐬
                    sqlTxt.Append(selectTxt.ToString());

                    // ORDER��쐬
                    sqlTxt.Append(orderTxt.ToString());

                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    sqlCommand.CommandText = sqlTxt.ToString();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count + count >= 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retAryList = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGrpWork recBgnGrpWork = this.CopyToRecBgnGrpOWorkFromReader(ref myReader);
                        al.Add(recBgnGrpWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                }  //end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchAllOfferProc", status);
                errMsg = ex.ToString();
            }
            retAryList = al;

            return status;
        }

        /// <summary>
        /// ���������i�O���[�v�ݒ�}�X�^�N���X�i�[���� Reader �� RecBgnGrpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGrpWork</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGrpWork CopyToRecBgnGrpWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGrpWork recBgnGrpWork = new RecBgnGrpWork();

            #region �N���X�֊i�[
            recBgnGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnGrpWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            recBgnGrpWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            recBgnGrpWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGrpWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            recBgnGrpWork.BrgnGoodsGrpTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTITLERF"));
            recBgnGrpWork.BrgnGoodsGrpTag = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTAGRF"));
            recBgnGrpWork.BrgnGoodsGrpComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPCOMMENTRF"));
            #endregion

            return recBgnGrpWork;
        }

        /// <summary>
        /// ���������i�O���[�v�ݒ�}�X�^�i�񋟁j�N���X�i�[���� Reader �� RecBgnGrpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGrpWork</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGrpWork CopyToRecBgnGrpOWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGrpWork recBgnGrpWork = new RecBgnGrpWork();

            #region �N���X�֊i�[
            recBgnGrpWork.CreateDateTime = DateTime.Now;
            recBgnGrpWork.UpdateDateTime = DateTime.Now;
            recBgnGrpWork.LogicalDeleteCode = 0;
            recBgnGrpWork.InqOriginalEpCd = "";
            recBgnGrpWork.InqOriginalSecCd = "";
            recBgnGrpWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGrpWork.DisplayOrder = 0;
            recBgnGrpWork.BrgnGoodsGrpTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTITLERF"));
            recBgnGrpWork.BrgnGoodsGrpTag = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPTAGRF"));
            recBgnGrpWork.BrgnGoodsGrpComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRGNGOODSGRPCOMMENTRF"));
            #endregion

            return recBgnGrpWork;
        }

        #endregion

    }
}

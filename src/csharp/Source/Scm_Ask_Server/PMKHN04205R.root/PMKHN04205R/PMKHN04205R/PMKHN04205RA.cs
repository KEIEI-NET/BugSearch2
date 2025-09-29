//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ� 
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : Redmine#17394
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/24  �C�����e : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Е��i���������Ɖ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Е��i���������Ɖ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �� ��</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class ScmInqLogInquiryDB : RemoteDB, IScmInqLogInquiryDB
    {
        /// <summary>
        /// ���Е��i���������Ɖ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public ScmInqLogInquiryDB()
        {

        }

        # region [Search]
        /// <summary>
        /// SCM�⍇�����O�e�[�u���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outScmInqLogDBList">��������</param>
        /// <param name="scmInqLogInquirySearchPara">��������</param>
        /// <param name="readMode">�����敪</param>        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�⍇�����O�e�[�u�����擾���܂��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        //public int Search(out object outScmInqLogDBList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode) // DEL 2010/11/19
        public int Search(out object outScmInqLogDBList, ref object scmInqLogInquirySearchPara, int readMode) // ADD 2010/11/19
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _scmInqLogDBList = null;

            outScmInqLogDBList = new CustomSerializeArrayList();

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                //status = this.SearchProc(out _scmInqLogDBList, scmInqLogInquirySearchPara, readMode, ref sqlConnection); // DEL 2010/11/19
                status = this.SearchProc(out _scmInqLogDBList, ref scmInqLogInquirySearchPara, readMode, ref sqlConnection); // ADD 2010/11/19

                if (_scmInqLogDBList != null)
                {
                    (outScmInqLogDBList as CustomSerializeArrayList).AddRange(_scmInqLogDBList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ScmInqLogInquiryDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ScmInqLogInquiryDB.Search", status);
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
        /// SCM�⍇�����O�e�[�u���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="scmInqLogDBList">��������</param>
        /// <param name="scmInqLogInquirySearchPara">��������</param>
        /// <param name="readMode">�����敪</param>        
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�⍇�����O�e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        //private int SearchProc(out ArrayList scmInqLogDBList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode, ref SqlConnection sqlConnection) // DEL 2010/11/19
        private int SearchProc(out ArrayList scmInqLogDBList, ref object scmInqLogInquirySearchPara, int readMode, ref SqlConnection sqlConnection) // ADD 2010/11/19
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // �R�l�N�V��������
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Select�R�}���h�̐���
                //sqlText.Append(" SELECT CREATEDATETIMERF, CNECTORIGINALEPNMRF, INQDATAINPUTSYSTEMRF, SCMINQCONTENTSRF FROM SCMINQLOGRF WITH (READUNCOMMITTED) WHERE CREATEDATETIMERF>=@FINDPARABEGINDATETIME AND CREATEDATETIMERF<=@FINDPARAENDDATETIME AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND CNECTOTHEREPCDRF=@FINDCNECTOTHEREPCD ORDER BY CREATEDATETIMERF ASC");        // SCM�⍇�����O�e�[�u�� // DEL 2010/11/24
                sqlText.Append(" SELECT TOP (@MAXSEARCHCT) CREATEDATETIMERF, CNECTORIGINALEPNMRF, INQDATAINPUTSYSTEMRF, SCMINQCONTENTSRF FROM SCMINQLOGRF WITH (READUNCOMMITTED) WHERE CREATEDATETIMERF>=@FINDPARABEGINDATETIME AND CREATEDATETIMERF<=@FINDPARAENDDATETIME AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND CNECTOTHEREPCDRF=@FINDCNECTOTHEREPCD ORDER BY CREATEDATETIMERF ASC");        // SCM�⍇�����O�e�[�u�� // ADD 2010/11/24
                sqlCommand.CommandText += sqlText.ToString();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaMaxSearchCt = sqlCommand.Parameters.Add("@MAXSEARCHCT", SqlDbType.Int); // ADD 2010/11/24
                SqlParameter findParaBeginDateTime = sqlCommand.Parameters.Add("@FINDPARABEGINDATETIME", SqlDbType.BigInt);
                SqlParameter findParaEndDateTime = sqlCommand.Parameters.Add("@FINDPARAENDDATETIME", SqlDbType.BigInt);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaCnectOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                // ---UPD 2010/11/19 -------------------------->>>
                //findParaBeginDateTime.Value = beginningTime;
                //findParaEndDateTime.Value = endingTime;
                //findParaLogicalDeleteCode.Value = 0;
                //findParaCnectOtherEpCd.Value = enterpriseCode;

                findParaMaxSearchCt.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt; // ADD 2010/11/24
                findParaBeginDateTime.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).BeginDateTime;
                findParaEndDateTime.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).EndDateTime;
                findParaLogicalDeleteCode.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).LogicalDeleteCode;
                findParaCnectOtherEpCd.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).CnectOtherEpCd;
                // ---UPD 2010/11/19 --------------------------<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ---UPD 2010/11/19 -------------------------->>>
                    //al.Add(this.CopyToScmInqLogWorkFromReader(ref myReader));
                    //if (al.Count < ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt) // DEL 2010/11/24
                    if (al.Count < ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt - 1) // ADD 2010/11/24
                    {
                        al.Add(this.CopyToScmInqLogWorkFromReader(ref myReader));
                    }
                    else
                    {
                        ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).SearchOverFlg = true;
                        break;
                    }
                    // ---UPD 2010/11/19 --------------------------<<<
                    
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ScmInqLogInquiryDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ScmInqLogInquiryDB.SearchProc", status);
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

            scmInqLogDBList = al;

            return status;

        }

        # endregion

        # region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[���� Reader �� ScmInqLogWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ScmInqLogWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private ScmInqLogInquiryWork CopyToScmInqLogWorkFromReader(ref SqlDataReader myReader)
        {
            ScmInqLogInquiryWork scmInqLogWork = new ScmInqLogInquiryWork();

            # region �N���X�֊i�[
            // ---UPD 2010/11/19 -------------------------->>>
            //scmInqLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            ////scmInqLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ////scmInqLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            ////scmInqLogWork.CnectOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPCDRF"));
            //scmInqLogWork.CnectOriginalEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPNMRF"));
            ////scmInqLogWork.CnectOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTOTHEREPCDRF"));
            ////scmInqLogWork.CnectOtherEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTOTHEREPNMRF"));
            //scmInqLogWork.InqDataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQDATAINPUTSYSTEMRF"));
            ////scmInqLogWork.LogDataGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("LOGDATAGUIDRF"));
            //scmInqLogWork.ScmInqContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMINQCONTENTSRF"));
            ////scmInqLogWork.AnswerPartsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERPARTSCNTRF"));

            scmInqLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            scmInqLogWork.CnectOriginalEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPNMRF"));
            scmInqLogWork.InqDataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQDATAINPUTSYSTEMRF"));
            scmInqLogWork.ScmInqContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMINQCONTENTSRF"));
            // ---UPD 2010/11/19 --------------------------<<<
            # endregion

            return scmInqLogWork;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_NS_DB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���摍���}�X�^�ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    [Serializable]
    public class SumSuppStPrintResultDB : RemoteDB, ISumSuppStPrintResultDB
    {
       #region [�N���X�R���X�g���N�^]
       /// <summary>
       /// �d���摍���}�X�^�ꗗ�\�R���X�g���N�^
       /// </summary>
       /// <remarks>
       /// <br>Note       : �Ȃ�</br>
       /// <br>Programmer : FSI�����@�v</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       public SumSuppStPrintResultDB()
            : base("PMKAK09019D", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork", "SumSuppStPrintResult")
       {

       }
       #endregion

       #region [Search]

       /// <summary>
       /// �w�肳�ꂽ�����̎d���摍���}�X�^�ꗗ�\���LIST��߂��܂�
       /// </summary>
       /// <param name="sumSuppStPrintResultWork">��������</param>
       /// <param name="sumSuppStPrintParaWork">�����p�����[�^</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : �w�肳�ꂽ�����̎d���摍���}�X�^�ꗗ�\���LIST��߂��܂�</br>
       /// <br>Programmer : FSI�����@�v</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       public int Search(out object sumSuppStPrintResultWork, object sumSuppStPrintParaWork)
       {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            sumSuppStPrintResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out sumSuppStPrintResultWork, sumSuppStPrintParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "SumSuppStResultDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumSuppStResultDB.Search");
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
            return status;
        }

        #endregion

       #region [SearchProc -- Search���C������]
       /// <summary>
       /// �w�肳�ꂽ�����̎d���摍���}�X�^�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
       /// </summary>
       /// <param name="retList">�������ʌ����p�����[�^</param>
       /// <param name="paraObj">�����p�����[�^</param>
       /// <param name="sqlConnection">sqlConnection</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : �w�肳�ꂽ�����̎d���摍���}�X�^�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
       /// <br>Programmer : FSI�����@�v</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
       {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SumSuppStPrintParaWork paraWork = null;
            paraWork = paraObj as SumSuppStPrintParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // SQL
            StringBuilder sqlString = new StringBuilder(string.Empty);
            
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandTimeout = 600;

                # region SQL��
                sqlString.AppendLine("SELECT DISTINCT");
                sqlString.AppendLine("	 SUMSECTIONCDRF");
                sqlString.AppendLine("	,SUMSUPPLIERCDRF");
                sqlString.AppendLine("	,SECTIONCODERF");
                sqlString.AppendLine("	,SUPPLIERCDRF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	SUMSUPPSTRF WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("		ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND LOGICALDELETECODERF = 0");

                // �ȍ~�̏����́A�p�����[�^�Ƃ��Ďw�肳�ꂽ�ꍇ�̂ݏ����ɒǉ�����
                if(paraWork.SectionCodeSt != string.Empty)
                {
                    sqlString.AppendLine("	AND SUMSECTIONCDRF >= @FINDSUMSECTIONCDST");
                }
                if (paraWork.SectionCodeEd != string.Empty)
                {
                    sqlString.AppendLine("	AND SUMSECTIONCDRF <= @FINDSUMSECTIONCDED");
                }
                if (paraWork.SupplierCodeSt != 0)
                {
                    sqlString.AppendLine("	AND SUMSUPPLIERCDRF >= @FINDSUMSUPPLIERCDST");
                }
                if (paraWork.SupplierCodeEd != 0)
                {
                    sqlString.AppendLine("	AND SUMSUPPLIERCDRF <= @FINDSUMSUPPLIERCDED");
                }
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	SUMSECTIONCDRF,SUMSUPPLIERCDRF,SECTIONCODERF,SUPPLIERCDRF ASC");
                sqlCommand.CommandText = sqlString.ToString();
                # endregion SQL��

                # region Parameter�I�u�W�F�N�g�쐬�E�l�i�[
                SqlParameter findEnterpriseCode  = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                if (paraWork.SectionCodeSt != string.Empty)
                {
                    SqlParameter findSumSectionCdSt = sqlCommand.Parameters.Add("@FINDSUMSECTIONCDST", SqlDbType.NChar);
                    findSumSectionCdSt.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeSt);
                }
                if (paraWork.SectionCodeEd != string.Empty)
                {
                    SqlParameter findSumSectionCdEd = sqlCommand.Parameters.Add("@FINDSUMSECTIONCDED", SqlDbType.NChar);
                    findSumSectionCdEd.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeEd);
                }
                if (paraWork.SupplierCodeSt != 0)
                {
                    SqlParameter findSumSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCDST", SqlDbType.Int);
                    findSumSupplierCdSt.Value = SqlDataMediator.SqlSetInt(paraWork.SupplierCodeSt);
                }
                if (paraWork.SupplierCodeEd != 0)
                {
                    SqlParameter findSumSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCDED", SqlDbType.Int);
                    findSumSupplierCdEd.Value = SqlDataMediator.SqlSetInt(paraWork.SupplierCodeEd);
                }

                # endregion Parameter�I�u�W�F�N�g�쐬�E�l�i�[

                // �N�G�����s
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // �������ʊi�[
                    al.Add(CopyToSumSuppStResultWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SumSuppStResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SumSuppStResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;
       }

       #endregion

       #region [�N���X�i�[����]
       /// <summary>
       /// �N���X�i�[���� Reader �� SumSuppStPrintResultWork
       /// </summary>
       /// <param name="myReader">SqlDataReader</param>
       /// <returns>Result</returns>
       /// <remarks>
       /// <br>Note       : Reader����SumSuppStPrintResultWork�֕ϊ����܂��B</br>
       /// <br>Programmer : FSI�����@�v</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       private SumSuppStPrintResultWork CopyToSumSuppStResultWorkFromReader(ref SqlDataReader myReader)
       {
           SumSuppStPrintResultWork listWork = new SumSuppStPrintResultWork();

           // �������_�R�[�h
           listWork.SumSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));

           // �����d����R�[�h
           listWork.SumSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMSUPPLIERCDRF"));

           // ���_�R�[�h
           listWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

           // �d����R�[�h
           listWork.SupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));

           return listWork;

       }
       #endregion  �N���X�i�[����

       #region [�R�l�N�V������������]
       /// <summary>
       /// SqlConnection��������
       /// </summary>
       /// <returns>SqlConnection</returns>
       /// <remarks>
       /// <br>Programmer : FSI�����@�v</br>
       /// <br>Date       : 2012/09/07</br>
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

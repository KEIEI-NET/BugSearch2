//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �ԕi���R�ꗗ�\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x�� 
// �C �� ��  2011/07/29  �C�����e : �C�X�R�Ή��EREADUNCOMMITTED�Ή�
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
    /// �ԕi���R�ꗗ�\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    [Serializable]
    public class RetGoodsReasonReportResultDB : RemoteDB , IRetGoodsReasonReportResultDB
    {
       #region �N���X�R���X�g���N�^
        /// <summary>
        /// �ԕi���R�ꗗ�\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public RetGoodsReasonReportResultDB()
            : base("PMHNB02219D", "Broadleaf.Application.Remoting.ParamData.RetGoodsReasonReportResultWork", "RETGOODSREASONREPORTRESULT")
        {

        }
        #endregion

       #region [Search]
        #region �w�肳�ꂽ�����̕ԕi���R�ꗗ�\�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̕ԕi���R�ꗗ�\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="retGoodsReasonReportResultWork">��������</param>
        /// <param name="retGoodsReasonReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̕ԕi���R�ꗗ�\���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public int Search(out object retGoodsReasonReportResultWork, object retGoodsReasonReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retGoodsReasonReportResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out retGoodsReasonReportResultWork, retGoodsReasonReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "RetGoodsReasonReportResultDB.Search");
                retGoodsReasonReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RetGoodsReasonReportResultDB.Search");
                retGoodsReasonReportResultWork = new ArrayList();
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

        #region �w�肳�ꂽ�����̕ԕi���R�ꗗ�\�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̕ԕi���R�ꗗ�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�������ʌ����p�����[�^</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̕ԕi���R�ꗗ�\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            RetGoodsReasonReportParaWork paraWork = null;
            paraWork = paraObj as RetGoodsReasonReportParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // ���㗚���f�[�^sql
            StringBuilder selectTxt1 = new StringBuilder(string.Empty);
            // ����f�[�^sql
            StringBuilder selectTxt2 = new StringBuilder(string.Empty);

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // ��ʂœ`�[��ʁF����
                if (0 == paraWork.SlipKindCd)
                {
                    selectTxt = MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork);

                }
                // ��ʂœ`�[��ʁF�ݏo�܂�
                else if (1 == paraWork.SlipKindCd)
                {
                    selectTxt.Append(MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork));
                    selectTxt.Append(" UNION ");
                    selectTxt.Append(MakeSearchSQL2(ref selectTxt2, ref sqlCommand, paraWork));
                }

                selectTxt = SortSql(selectTxt, paraWork, ref sqlCommand);

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToRetGoodsReasonReportResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "RetGoodsReasonReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RetGoodsReasonReportResultDB.SearchProc" + status);
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

        #region �����p���㗚���f�[�^�擾����
        /// <summary>
        /// �����p���㗚���f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt1">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p���㗚���f�[�^���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [�e�[�u��]
            selectTxt1.Append("FROM ");
            // 2011/07/29 >>>
            //selectTxt1.Append("SALESHISTORYRF A ");               // ���㗚���f�[�^
            selectTxt1.Append("SALESHISTORYRF A WITH (READUNCOMMITTED) ");               // ���㗚���f�[�^
            // 2011/07/29 <<<
            #endregion
            #region [���o����]
            MakeWhereString1(ref selectTxt1, ref sqlCommand, paraWork);
            #endregion
            #region [�W�v]
            SortRetGoodsReasonReportResult(ref selectTxt1, paraWork.PrintType);
            #endregion [�W�v]

            return selectTxt1;
            
        }
        #endregion

        #region �����p����f�[�^�擾����
        /// <summary>
        /// �����p����f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt2">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p����f�[�^���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [�e�[�u��]
            selectTxt2.Append("FROM ");
            // 2011/07/29 >>>
            //selectTxt2.Append("SALESSLIPRF A "); // ����f�[�^
            selectTxt2.Append("SALESSLIPRF A WITH (READUNCOMMITTED) "); // ����f�[�^
            // 2011/07/29 <<<
            #endregion
            #region [���o����]
            MakeWhereString2(ref selectTxt2, ref sqlCommand, paraWork);
            #endregion
            #region [�W�v]
            SortRetGoodsReasonReportResult(ref selectTxt2, paraWork.PrintType);
            #endregion [�W�v]

            return selectTxt2;
            
        }
        #endregion

        #region [�擾����]
        /// <summary>
        /// �擾����
        /// </summary>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="selectTxt">sql��</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SelectRow(RetGoodsReasonReportParaWork paraWork, StringBuilder selectTxt)
        {
            //�@�ԕi���R
            if (0 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // ����
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // ���ьv�㋒�_�R�[�h
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // �ԕi���R�R�[�h
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // �ԕi���R
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       �@// ����`�[���v�i�Ŕ����j
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
            }
            //�@���Ӑ�
            else if (1 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // ����
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // ���ьv�㋒�_�R�[�h
                selectTxt.Append("A.CUSTOMERCODERF CUSTOMERCODERF, ");                      // ���Ӑ�R�[�h
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // �ԕi���R�R�[�h
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // �ԕi���R
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       �@// ����`�[���v�i�Ŕ����j
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
            }
            //�@�S����
            else if (2 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // ����
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // ���ьv�㋒�_�R�[�h
                selectTxt.Append("A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, ");                // �̔��]�ƈ��R�[�h
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // �ԕi���R�R�[�h
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // �ԕi���R
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       �@// ����`�[���v�i�Ŕ����j
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
            }
            //�@�󒍎�
            else if (3 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // ����
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // ���ьv�㋒�_�R�[�h
                selectTxt.Append("A.FRONTEMPLOYEECDRF FRONTEMPLOYEECDRF, ");                // ��t�]�ƈ��R�[�h
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // �ԕi���R�R�[�h
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // �ԕi���R
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       �@// ����`�[���v�i�Ŕ����j
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
            }
            //�@���s��
            else if (4 == paraWork.PrintType)
            {
                selectTxt.Append("SELECT DISTINCT COUNT(*) COUNT, ");                       // ����
                selectTxt.Append("A.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");            // ���ьv�㋒�_�R�[�h
                selectTxt.Append("A.SALESINPUTCODERF SALESINPUTCODERF, ");                  // ������͎҃R�[�h
                selectTxt.Append("A.RETGOODSREASONDIVRF RETGOODSREASONDIVRF, ");            // �ԕi���R�R�[�h
                selectTxt.Append("A.RETGOODSREASONRF RETGOODSREASONRF, ");                  // �ԕi���R
                selectTxt.Append("SUM(A.SALESTOTALTAXEXCRF) SALESTOTALTAXEXCRF, ");       �@// ����`�[���v�i�Ŕ����j
                selectTxt.Append("A.ACPTANODRSTATUSRF ACPTANODRSTATUSRF ");                // �󒍃X�e�[�^�X
            }
            return selectTxt;
        }
        #endregion [�擾����]

        #region [�W�v]
        /// <summary>
        /// �O���[�v����ݒ�
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="printType">�o�͏�</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SortRetGoodsReasonReportResult(ref StringBuilder sql, int printType)
        {
            switch (printType)
            {   // �ԕi���R
                case(0):
                    {   
                        //���ьv�㋒�_�R�[�h
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //�ԕi���R
                        sql.Append("A.RETGOODSREASONRF, ");
                        // �󒍃X�e�[�^�X
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // ���Ӑ�
                case (1):
                    {
                        //���ьv�㋒�_�R�[�h
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //���Ӑ�R�[�h
                        sql.Append("A.CUSTOMERCODERF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //�ԕi���R
                        sql.Append("A.RETGOODSREASONRF, ");
                        // �󒍃X�e�[�^�X
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // �S����
                case (2):
                    {
                        //���ьv�㋒�_�R�[�h
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //�̔��]�ƈ��R�[�h
                        sql.Append("A.SALESEMPLOYEECDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //�ԕi���R
                        sql.Append("A.RETGOODSREASONRF, ");
                        // �󒍃X�e�[�^�X
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // �󒍎�
                case (3):
                    {
                        //���ьv�㋒�_�R�[�h
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //��t�]�ƈ��R�[�h
                        sql.Append("A.FRONTEMPLOYEECDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //�ԕi���R
                        sql.Append("A.RETGOODSREASONRF, ");
                        // �󒍃X�e�[�^�X
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
                // ���s��
                case (4):
                    {
                        //���ьv�㋒�_�R�[�h
                        sql.Append("GROUP BY A.RESULTSADDUPSECCDRF, ");
                        //������͎҃R�[�h
                        sql.Append("A.SALESINPUTCODERF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("A.RETGOODSREASONDIVRF, ");
                        //�ԕi���R
                        sql.Append("A.RETGOODSREASONRF, ");
                        // �󒍃X�e�[�^�X
                        sql.Append("A.ACPTANODRSTATUSRF ");

                    }
                    break;
             }
             return sql;
         }
        #endregion [�W�v]

        #region [�\�[�g����ݒ�]
        /// <summary>
        /// �\�[�g����ݒ�
        /// </summary>
        /// <param name="selectTxt">sql��</param>
        /// <param name="paraWork">�����p�����[�^</param>
         /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder SortSql(StringBuilder selectTxt,RetGoodsReasonReportParaWork paraWork,ref SqlCommand sqlCommand)
        {
            StringBuilder sql = new StringBuilder(string.Empty);
            switch (paraWork.PrintType)
            {   // �ԕi���R
                case (0):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // ����
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // ���ьv�㋒�_�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // �ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // �ԕi���R
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // ����`�[���v�i�Ŕ����j
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // �󒍃X�e�[�^�X
                        sql.Append("D.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // ���_�K�C�h����
                        sql.Append("FROM (" + selectTxt + ")  C ");

                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF D ");    // ���_���ݒ�}�X�^
                        sql.Append("LEFT JOIN  SECINFOSETRF D WITH (READUNCOMMITTED) ");    // ���_���ݒ�}�X�^
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = D.SECTIONCODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF = @ENTERPRISECODE3");
                        sql.Append(") ");

                        // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);
                        //���ьv�㋒�_�R�[�h
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF,  ");
                        //�ԕi���R����
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //�󒍃X�e�[�^�X
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // ���Ӑ�
                case (1):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // ����
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // ���ьv�㋒�_�R�[�h
                        sql.Append("C.CUSTOMERCODERF CUSTOMERCODERF,  ");            // ���Ӑ�R�[�h
                        sql.Append("D.CUSTOMERSNMRF CUSTOMERSNMRF,  ");              // ���Ӑ旪��
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // �ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // �ԕi���R
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // ����`�[���v�i�Ŕ����j
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // �󒍃X�e�[�^�X
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // ���_�K�C�h����
                        // �W�v�f�[�^
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // ���Ӑ�}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  CUSTOMERRF D ");
                        sql.Append("LEFT JOIN  CUSTOMERRF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.CUSTOMERCODERF = D.CUSTOMERCODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // ���_���ݒ�}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);
                        //���ьv�㋒�_�R�[�h
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //���Ӑ�R�[�h
                        sql.Append("C.CUSTOMERCODERF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //�ԕi���R����
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //�󒍃X�e�[�^�X
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // �S����
                case (2):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // ����
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // ���ьv�㋒�_�R�[�h
                        sql.Append("C.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, ");       // �̔��]�ƈ��R�[�h
                        sql.Append("D.NAMERF NAMERF, ");                             // �̔��]�ƈ�����
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // �ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // �ԕi���R
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // ����`�[���v�i�Ŕ����j
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // �󒍃X�e�[�^�X
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // ���_�K�C�h����
                        // �W�v�f�[�^
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // �]�ƈ��}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.SALESEMPLOYEECDRF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // ���_���ݒ�}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //���ьv�㋒�_�R�[�h
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //�̔��]�ƈ��R�[�h
                        sql.Append("C.SALESEMPLOYEECDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF,");
                        //�ԕi���R����
                        sql.Append("C.RETGOODSREASONRF, ");
                        //�󒍃X�e�[�^�X
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // �󒍎�
                case (3):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // ����
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // ���ьv�㋒�_�R�[�h
                        sql.Append("C.FRONTEMPLOYEECDRF FRONTEMPLOYEECDRF, ");       // ��t�]�ƈ��R�[�h
                        sql.Append("D.NAMERF NAMERF, ");                             // ��t�]�ƈ�����
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // �ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // �ԕi���R
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // ����`�[���v�i�Ŕ����j
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // �󒍃X�e�[�^�X
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // ���_�K�C�h����
                        // �W�v�f�[�^
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // �]�ƈ��}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.FRONTEMPLOYEECDRF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // ���_���ݒ�}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //���ьv�㋒�_�R�[�h
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //��t�]�ƈ��R�[�h
                        sql.Append("C.FRONTEMPLOYEECDRF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //�ԕi���R����
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //�󒍃X�e�[�^�X
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
                // ���s��
                case (4):
                    {
                        sql.Append("SELECT C.COUNT COUNT, ");                        // ����
                        sql.Append("C.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");   // ���ьv�㋒�_�R�[�h
                        sql.Append("C.SALESINPUTCODERF SALESINPUTCODERF, ");         // ������͎҃R�[�h
                        sql.Append("D.NAMERF NAMERF, ");                             // ������͎Җ���
                        sql.Append("C.RETGOODSREASONDIVRF RETGOODSREASONDIVRF,  ");  // �ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONRF RETGOODSREASONRF,  ");        // �ԕi���R
                        sql.Append("C.SALESTOTALTAXEXCRF  SALESTOTALTAXEXCRF, ");    // ����`�[���v�i�Ŕ����j
                        sql.Append("C.ACPTANODRSTATUSRF ACPTANODRSTATUSRF,  ");      // �󒍃X�e�[�^�X
                        sql.Append("E.SECTIONGUIDESNMRF SECTIONGUIDESNMRF  ");       // ���_�K�C�h����
                        // �W�v�f�[�^
                        sql.Append("FROM (" + selectTxt + ")  C  ");
                        // �]�ƈ��}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  EMPLOYEERF D ");
                        sql.Append("LEFT JOIN  EMPLOYEERF D WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.SALESINPUTCODERF = D.EMPLOYEECODERF ");
                        sql.Append("AND D.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND D.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");
                        // ���_���ݒ�}�X�^
                        // 2011/07/29 >>>
                        //sql.Append("LEFT JOIN  SECINFOSETRF E ");
                        sql.Append("LEFT JOIN  SECINFOSETRF E WITH (READUNCOMMITTED) ");
                        // 2011/07/29 <<<
                        sql.Append("ON ( ");
                        sql.Append("C.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                        sql.Append("AND E.LOGICALDELETECODERF = 0 ");
                        sql.Append("AND E.ENTERPRISECODERF =@ENTERPRISECODE3 ");
                        sql.Append(") ");

                        // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE3", SqlDbType.NChar);
                        ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                        //���ьv�㋒�_�R�[�h
                        sql.Append("ORDER BY C.RESULTSADDUPSECCDRF, ");
                        //������͎҃R�[�h
                        sql.Append("C.SALESINPUTCODERF, ");
                        //�ԕi���R�R�[�h
                        sql.Append("C.RETGOODSREASONDIVRF, ");
                        //�ԕi���R����
                        sql.Append("C.RETGOODSREASONRF,  ");
                        //�󒍃X�e�[�^�X
                        sql.Append("C.ACPTANODRSTATUSRF ASC  ");
                    }
                    break;
            }
            return sql;
        }
        #endregion  [�\�[�g����ݒ�]

        #region [Where���쐬����]
        /// <summary>
        /// ���㗚���f�[�^�������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder MakeWhereString1(ref StringBuilder sql, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            // �_���폜�敪
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // ����`�[�敪=�u1:�ԕi�v
            sql.Append(" AND  A.SALESSLIPCDRF = 1  ");
            // �󒍃X�e�[�^�X=�u30:����v
            sql.Append(" AND  A.ACPTANODRSTATUSRF = 30  ");
            // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE1 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // ���_�R�[�h
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sql.Append(" AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }

            // ������t
            /*---------DEL 2007/07/13 PVCS326--------->>>>>
            // �������������NULL�ł͂Ȃ��ꍇ
            if (paraWork.CurrentTotalDay != DateTime.MinValue)
            {   
                // ������t >= �O����������{�P
                sql.Append(" AND A.SALESDATERF >= @FINDPARAPREVTOTALDAY ");
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY", SqlDbType.Int);
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.PrevTotalDay.AddDays(1.0));
                // ������t <=�����������
                sql.Append(" AND A.SALESDATERF <= @FINDPARACURRENTTOTALDAY ");
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CurrentTotalDay);
            }
            else
            {
                // ������t >= �N�x�J�n���{�P
                sql.Append(" AND A.SALESDATERF >= @FINDSTARTYEARDATE ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate.AddDays(1.0));
                // ������t <=�N�x�I����
                sql.Append(" AND A.SALESDATERF <= @FINDENDYEARDATE ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
            ---------DEL 2007/07/13 PVCS326--------->>>>>*/

            if (paraWork.StartYearDate != DateTime.MinValue)
            {
                // ������t >= �J�n�N����+�P
                sql.Append(" AND A.SALESDATERF >= @FINDSTARTYEARDATE ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate);
            }
            if (paraWork.EndYearDate != DateTime.MinValue)
            {
                // ������t <=�I���N����
                sql.Append(" AND A.SALESDATERF <= @FINDENDYEARDATE ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
            // ��ʂ̓��Ӑ�(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt)) �@
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // ��ʂ̓��Ӑ�(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd)) �@
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            // ��ʂ̒S����(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFSt))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF >= @FINDSTSALESEMPLOYEECD ");
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSTSALESEMPLOYEECD", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFSt);
            }
            // ��ʂ̒S����(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFEd)) 
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF <= @FINDEDSALESEMPLOYEECD ");
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDEDSALESEMPLOYEECD", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFEd);
            }

            // ��ʂ̎󒍎�(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFSt))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF >= @FINDSTFRONTEMPLOYEECD ");
                SqlParameter paraStFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDSTFRONTEMPLOYEECD", SqlDbType.NChar);
                paraStFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFSt);
            }
            // ��ʂ̎󒍎�(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFEd)) 
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF <= @FINDEDFRONTEMPLOYEECD ");
                SqlParameter paraEdFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDEDFRONTEMPLOYEECD", SqlDbType.NChar);
                paraEdFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFEd);
            }

            // ��ʂ̔��s��(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFSt))
            {
                sql.Append(" AND A.SALESINPUTCODERF >= @FINDSTSALESINPUTCODE ");
                SqlParameter paraStSalesInputCd = sqlCommand.Parameters.Add("@FINDSTSALESINPUTCODE", SqlDbType.NChar);
                paraStSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFSt);
            }
            // ��ʂ̔��s��(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFEd)) 
            {
                sql.Append(" AND A.SALESINPUTCODERF <= @FINDEDSALESINPUTCODE ");
                SqlParameter paraEdSalesInputCd = sqlCommand.Parameters.Add("@FINDEDSALESINPUTCODE", SqlDbType.NChar);
                paraEdSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFEd);
            }
            // ��ʂ̕ԕi���R(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivSt))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF >= @FINDSTRETGOODSREASONDIV ");
                SqlParameter paraStRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDSTRETGOODSREASONDIV", SqlDbType.Int);
                paraStRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivSt));
            }
            // ��ʂ̕ԕi���R(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivEd))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF <= @FINDEDRETGOODSREASONDIV ");
                SqlParameter paraEdRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDEDRETGOODSREASONDIV", SqlDbType.Int);
                paraEdRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivEd));
            }

            return sql;
        }

        /// <summary>
        /// ����f�[�^�������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private StringBuilder MakeWhereString2(ref StringBuilder sql, ref SqlCommand sqlCommand, RetGoodsReasonReportParaWork paraWork)
        {
            // �_���폜�敪
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");

            // ����`�[�敪=�u1:�ԕi�v
            sql.Append(" AND  A.SALESSLIPCDRF = 1  ");

            // �󒍃X�e�[�^�X=�u40:�o�ׁv
            sql.Append(" AND  A.ACPTANODRSTATUSRF = 40  ");

            // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE2 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // ���_�R�[�h
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sql.Append(" AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ")  ");

                }
            }

            // �o�ד��t
            /*---------DEL 2007/07/13 PVCS326------>>>>>
            // �������������NULL�ł͂Ȃ��ꍇ
            if (paraWork.CurrentTotalDay != DateTime.MinValue)
            {
                // �o�ד��t >= �O����������{�P
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDPARAPREVTOTALDAY2 ");
                SqlParameter paraPrevTotalDay = sqlCommand.Parameters.Add("@FINDPARAPREVTOTALDAY2", SqlDbType.Int);
                paraPrevTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.PrevTotalDay.AddDays(1.0));
                // �o�ד��t <=�����������
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDPARACURRENTTOTALDAY2 ");
                SqlParameter paraCurrentTotalDay = sqlCommand.Parameters.Add("@FINDPARACURRENTTOTALDAY2", SqlDbType.Int);
                paraCurrentTotalDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CurrentTotalDay);
            }
            else
            {
                // �o�ד��t >= �N�x�J�n���{�P
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDSTARTYEARDATE2 ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE2", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate.AddDays(1.0));
                // �o�ד��t <=�N�x�I����
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDENDYEARDATE2 ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE2", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }
             ---------DEL 2007/07/13 PVCS326------>>>>>*/
            if (paraWork.StartYearDate != DateTime.MinValue)
            {
                // �o�ד��t >= �N�x�J�n���{�P
                sql.Append(" AND A.SHIPMENTDAYRF >= @FINDSTARTYEARDATE2 ");
                SqlParameter paraStartYearDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE2", SqlDbType.Int);
                paraStartYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.StartYearDate);
            }
            if (paraWork.EndYearDate != DateTime.MinValue)
            {
                // �o�ד��t <=�N�x�I����
                sql.Append(" AND A.SHIPMENTDAYRF <= @FINDENDYEARDATE2 ");
                SqlParameter paraEndYearDate = sqlCommand.Parameters.Add("@FINDENDYEARDATE2", SqlDbType.Int);
                paraEndYearDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.EndYearDate);
            }

            // ��ʂ̓��Ӑ�(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt))
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE2 ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE2", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // ��ʂ̓��Ӑ�(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd))
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE2  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE2", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            // ��ʂ̒S����(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFSt))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF >= @FINDSTSALESEMPLOYEECD2 ");
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSTSALESEMPLOYEECD2", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFSt);
            }
            // ��ʂ̒S����(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesEmployeeCdRFEd))
            {
                sql.Append(" AND A.SALESEMPLOYEECDRF <= @FINDEDSALESEMPLOYEECD2 ");
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDEDSALESEMPLOYEECD2", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesEmployeeCdRFEd);
            }

            // ��ʂ̎󒍎�(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFSt))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF >= @FINDSTFRONTEMPLOYEECD2 ");
                SqlParameter paraStFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDSTFRONTEMPLOYEECD2", SqlDbType.NChar);
                paraStFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFSt);
            }
            // ��ʂ̎󒍎�(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.FrontEmployeeCdRFEd))
            {
                sql.Append(" AND A.FRONTEMPLOYEECDRF <= @FINDEDFRONTEMPLOYEECD2 ");
                SqlParameter paraEdFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDEDFRONTEMPLOYEECD2", SqlDbType.NChar);
                paraEdFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paraWork.FrontEmployeeCdRFEd);
            }

            // ��ʂ̔��s��(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFSt))
            {
                sql.Append(" AND A.SALESINPUTCODERF >= @FINDSTSALESINPUTCODE2 ");
                SqlParameter paraStSalesInputCd = sqlCommand.Parameters.Add("@FINDSTSALESINPUTCODE2", SqlDbType.NChar);
                paraStSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFSt);
            }
            // ��ʂ̔��s��(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.SalesInputCdRFEd))
            {
                sql.Append(" AND A.SALESINPUTCODERF <= @FINDEDSALESINPUTCODE2 ");
                SqlParameter paraEdSalesInputCd = sqlCommand.Parameters.Add("@FINDEDSALESINPUTCODE2", SqlDbType.NChar);
                paraEdSalesInputCd.Value = SqlDataMediator.SqlSetString(paraWork.SalesInputCdRFEd);
            }
            // ��ʂ̕ԕi���R(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivSt))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF >= @FINDSTRETGOODSREASONDIV2 ");
                SqlParameter paraStRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDSTRETGOODSREASONDIV2", SqlDbType.Int);
                paraStRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivSt));
            }
            // ��ʂ̕ԕi���R(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.RetGoodsReasonDivEd))
            {
                sql.Append(" AND A.RETGOODSREASONDIVRF <= @FINDEDRETGOODSREASONDIV2 ");
                SqlParameter paraEdRetGoodsReasonDiv = sqlCommand.Parameters.Add("@FINDEDRETGOODSREASONDIV2", SqlDbType.Int);
                paraEdRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.RetGoodsReasonDivEd));
            }

            return sql;
        }
        #endregion

        #endregion

       #region �N���X�i�[���� Reader �� GoodsReasonReportResultWork
        /// <summary>
        /// �N���X�i�[���� Reader �� RetGoodsReasonReportResultWork
        /// </summary>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : Reader����RetGoodsReasonReportResultWork�֕ϊ����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private RetGoodsReasonReportResultWork CopyToRetGoodsReasonReportResultWorkFromReader(ref SqlDataReader myReader, RetGoodsReasonReportParaWork paraWork)
        {
            RetGoodsReasonReportResultWork listWork = new RetGoodsReasonReportResultWork();
            #region �N���X�֊i�[

            // ���_�K�C�h����
            listWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            // ���ьv�㋒�_�R�[�h
            listWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));

            //�o�͏��ɂ��I��
            switch (paraWork.PrintType)
            {
                case (0)://�ԕi���R
                    {
                        // �ԕi���R�R�[�h
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // �ԕi���R
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    }
                    break;
                case (1)://���Ӑ�
                    {
                        // ���Ӑ�R�[�h
                        listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // ���Ӑ於��
                        listWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        // �ԕi���R�R�[�h
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // �ԕi���R
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (2)://�S����
                    {
                        // �̔��]�ƈ��R�[�h
                        listWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                        // �̔��]�ƈ�����
                        listWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // �ԕi���R�R�[�h
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // �ԕi���R
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (3)://�󒍎�
                    {
                        // ��t�]�ƈ��R�[�h
                        listWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                        // ��t�]�ƈ�����
                        listWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // �ԕi���R�R�[�h
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // �ԕi���R
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;
                case (4)://���s��
                    {
                        // ������͎҃R�[�h
                        listWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                        // ������͎Җ���
                        listWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        // �ԕi���R�R�[�h
                        listWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                        // �ԕi���R
                        listWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));

                    }
                    break;

            }
            // ����`�[���v�i�Ŕ����j
            listWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            // ���
            int slipKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            if (30 == slipKind)
            {
                listWork.SlipKind = "����";
            }
            if (40 == slipKind)
            {
                listWork.SlipKind = "�ݏo";
            }
            // ����
            listWork.Count = Convert.ToInt64(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COUNT")));

            return listWork;
            #endregion
        }
        #endregion  �N���X�i�[���� Reader �� GoodsReasonReportResultWork

       #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
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

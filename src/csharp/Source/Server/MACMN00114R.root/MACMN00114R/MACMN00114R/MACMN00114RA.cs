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
    /// ���엚�����O�f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���엚�����O�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.24</br>
    /// <br></br>
    /// <br>Update Note: �����ݏ���(Write)�̏d���`�F�b�N�����폜 </br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.22</br>
    /// <br></br>
    /// <br>Update Note: ���o�s��C�� </br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.05</br>
    /// <br></br>
    /// <br>Update Note: �����s��C�� </br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// <br>Update Note: DSP���O�A�ʐM���O�f�[�^�Ɖ�̒��o�Œ[���ԍ��͊��S��v�Œ��o����悤�ɏC�� </br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2011/02/24</br>
    /// <br></br>
    /// <br>Update Note: �Ɖ�v���O�����̃��O�o�͋@�\�Ή� </br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2011/03/18</br>
    /// <br></br>
    /// <br>Update Note: #24648 �_���폜�̔r�����������C�� </br>
    /// <br>Programmer : ���@����</br>
    /// <br>Date       : 2011/09/13</br>
    /// <br>Update Note: K2016/10/28 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11202046-00</br>
    /// <br>           : �_�P�Y�Ƈ� �������������̒ǉ�</br>
    /// <br>Update Note: 2021/12/15  ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770181-00</br>
    /// <br>           : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OprtnHisLogDB : RemoteDB, IOprtnHisLogDB
    {
        /// <summary>
        /// ���엚�����O�f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br></br>
        /// <br>Update Note: �����ݏ���(Write)�̏d���`�F�b�N�����폜 </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.22</br>
        /// <br></br>
        /// <br>Update Note: ���o�s��C�� </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.05</br>
        /// <br></br>
        /// <br>Update Note: �����s��C�� </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br>Update Note: K2016/10/28 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11202046-00</br>
        /// <br>           : �_�P�Y�Ƈ� �������������̒ǉ�</br>
        /// <br>Update Note: 2021/12/15  ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770181-00</br>
        /// <br>           : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
        /// </remarks>
        public OprtnHisLogDB() : base("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork", "OPRTNHISLOGRF")
        {
        }

        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
        #region Const members
        private const long CT_TICKSPERDAY = 864000000000;
        private const long CT_TICKSPERSEC = 10000000;
        #endregion
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">oprtnHisLogResultWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (oprtnHisLogWork == null) return status;

                //�p�����[�^�̃L���X�g
                OprtnHisLogWork oprtnhisLogWork = oprtnHisLogWork as OprtnHisLogWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read���s
                status = this.ReadProc(ref oprtnhisLogWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Read");
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
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="oprtnHislogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int ReadProc(ref OprtnHisLogWork oprtnHislogWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref oprtnHislogWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="oprtnHislogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int ReadProcProc(ref OprtnHisLogWork oprtnHislogWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnHislogWork.EnterpriseCode);
                findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHislogWork.LogDataCreateDateTime);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    oprtnHislogWork = CopyToOprtnHisLogWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">��������</param>
        /// <param name="paraoprtnHisLogSrchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int Search(ref object oprtnHisLogWork, object paraoprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraoprtnHisLogSrchWork == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList oprtnHisLogArray = oprtnHisLogWork as ArrayList;
                if (oprtnHisLogArray == null)
                {
                    oprtnHisLogArray = new ArrayList();
                }

                OprtnHisLogSrchWork oprtnHisLogSrchWork = paraoprtnHisLogSrchWork as OprtnHisLogSrchWork;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search���s
                status = SearchOprtnHisLogProc(ref oprtnHisLogArray, oprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
                oprtnHisLogWork = oprtnHisLogArray;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Search");
                oprtnHisLogWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="oprtnHisLogWork">��������</param>
        /// <param name="paraoprtnHisLogSrchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchOprtnHisLogProc(ref object oprtnHisLogWork, OprtnHisLogSrchWork paraoprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            oprtnHisLogWork = null;
            ArrayList al = new ArrayList();   //���o����

            try
            {
                status = SearchOprtnHisLogProc(ref al, paraoprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.SearchOprtnHisLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            oprtnHisLogWork = al;
            
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="oprtnHisLogSrchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchOprtnHisLogProc(ref ArrayList al, OprtnHisLogSrchWork oprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchOprtnHisLogProcProc(ref al, oprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
        }
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="oprtnHisLogSrchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int SearchOprtnHisLogProcProc(ref ArrayList al, OprtnHisLogSrchWork oprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                //----- UPD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
                //sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                //
                //sqlCommand.CommandText = sqlText;
                ////WHERE��
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, oprtnHisLogSrchWork, logicalMode);
                if (!oprtnHisLogSrchWork.TimeSearchFlag)
                {
                    //���������|������ǉ����Ȃ��ꍇ�A�����ʂ��SQL�𐶐�
                    sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    //WHERE��
                    sqlCommand.CommandText += MakeWhereString( ref sqlCommand, oprtnHisLogSrchWork, logicalMode );
                }
                else
                {
                    //���������|������ǉ�����ꍇ�A�T�u�N�G���Ŋ����ʂ�̎擾���s������Ŏ������o����SQL�𐶐�
                    StringBuilder subQuelyStrings = new StringBuilder();
                    string subQuelyAsName = "OPLOG";

                    subQuelyStrings.AppendLine( " FROM (" );
                    subQuelyStrings.AppendLine( " SELECT * FROM OPRTNHISLOGRF" );
                    subQuelyStrings.AppendLine( MakeWhereString( ref sqlCommand, oprtnHisLogSrchWork, logicalMode ) );
                    subQuelyStrings.AppendLine( " ) AS " + subQuelyAsName + " " );

                    sqlCommand.CommandText = sqlText + subQuelyStrings.ToString();
                    //WHERE��
                    sqlCommand.CommandText += MakeTimeSpanWhereString( ref sqlCommand, oprtnHisLogSrchWork, subQuelyAsName );
                }
                //----- UPD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToOprtnHisLogWorkFromReader(ref myReader));

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
                }
            }

            return status;
        }
        #endregion

        #region [SearchUOE]
        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">��������</param>
        /// <param name="paraoprationLogOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchUOE(ref object oprtnHisLogWork, object paraoprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraoprationLogOrderWork == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList oprtnHisLogArray = oprtnHisLogWork as ArrayList;
                if (oprtnHisLogArray == null)
                {
                    oprtnHisLogArray = new ArrayList();
                }

                OprationLogOrderWork oprationLogOrderWork = paraoprationLogOrderWork as OprationLogOrderWork;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search���s
                status = SearchUOEProc(ref oprtnHisLogArray, oprationLogOrderWork, readMode, logicalMode, ref sqlConnection);
                oprtnHisLogWork = oprtnHisLogArray;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Search");
                oprtnHisLogWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="oprationLogOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchUOEProc(ref ArrayList al, OprationLogOrderWork oprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchUOEProcProc(ref al, oprationLogOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="oprationLogOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑��엚�����O�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int SearchUOEProcProc(ref ArrayList al, OprationLogOrderWork oprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                //WHERE��
                sqlCommand.CommandText += MakeUOEWhereString(ref sqlCommand, oprationLogOrderWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToOprtnHisLogWorkFromReader(ref myReader));

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
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���엚�����O�f�[�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int Write(ref object oprtnHisLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (oprtnHisLogWork == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteOprtnHisLogProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    //���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                oprtnHisLogWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Write(ref object oprtnHisLogWork)");
                //���[���o�b�N
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
        /// ���엚�����O�f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int WriteOprtnHisLogProc(ref ArrayList oprtnHisLogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteOprtnHisLogProcProc(ref oprtnHisLogWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ���엚�����O�f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int WriteOprtnHisLogProcProc(ref ArrayList oprtnHisLogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (oprtnHisLogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnHisLogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnHisLogWorkList[i] as OprtnHisLogWork;
                        sqlCommand.Parameters.Clear(); // ADD 2008.12.02
                        // DEL 2008.10.22 >>>
                        #region
                        /*
                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����
                            
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (oprtnhislogWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }
                                
                                sqlCommand.Cancel();

                                if (myReader.IsClosed == false) myReader.Close();
                                
                                return status;
                            }
                            
                            

                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,LOGDATACREATEDATETIMERF=@LOGDATACREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,LOGDATAGUIDRF=@LOGDATAGUID" + Environment.NewLine;
                            sqlText += " ,LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAMACHINENAMERF=@LOGDATAMACHINENAME" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTCDRF=@LOGDATAAGENTCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTNMRF=@LOGDATAAGENTNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF=@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYIDRF=@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYNMRF=@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJCLASSIDRF=@LOGDATAOBJCLASSID" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJPROCNMRF=@LOGDATAOBJPROCNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOPERATIONCDRF=@LOGDATAOPERATIONCD" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERDTPROCLVLRF=@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERFUNCLVLRF=@LOGOPERATERFUNCLVL" + Environment.NewLine;
                            sqlText += " ,LOGDATASYSTEMVERSIONRF=@LOGDATASYSTEMVERSION" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONSTATUSRF=@LOGOPERATIONSTATUS" + Environment.NewLine;
                            sqlText += " ,LOGDATAMASSAGERF=@LOGDATAMASSAGE" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONDATARF=@LOGOPERATIONDATA" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)oprtnhislogWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (oprtnhislogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                         */
                        #endregion
                        // DEL 2008.10.22 <<<

                        //Insert�R�}���h�̐���
                        #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                            sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                            sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@LOGDATACREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@LOGDATAGUID" + Environment.NewLine;
                            sqlText += " ,@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAKINDCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAMACHINENAME" + Environment.NewLine;
                            sqlText += " ,@LOGDATAAGENTCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAAGENTNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJCLASSID" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJPROCNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOPERATIONCD" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATERFUNCLVL" + Environment.NewLine;
                            sqlText += " ,@LOGDATASYSTEMVERSION" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATIONSTATUS" + Environment.NewLine;
                            sqlText += " ,@LOGDATAMASSAGE" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATIONDATA" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)oprtnhislogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        //} // DEL 2008.10.22 

                        //if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraLogDataCreateDateTime = sqlCommand.Parameters.Add("@LOGDATACREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraLogDataGuid = sqlCommand.Parameters.Add("@LOGDATAGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                        SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                        SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                        SqlParameter paraLogDataAgentNm = sqlCommand.Parameters.Add("@LOGDATAAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjBootProgramNm = sqlCommand.Parameters.Add("@LOGDATAOBJBOOTPROGRAMNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjAssemblyNm = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjClassID = sqlCommand.Parameters.Add("@LOGDATAOBJCLASSID", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjProcNm = sqlCommand.Parameters.Add("@LOGDATAOBJPROCNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                        SqlParameter paraLogOperaterDtProcLvl = sqlCommand.Parameters.Add("@LOGOPERATERDTPROCLVL", SqlDbType.NVarChar);
                        SqlParameter paraLogOperaterFuncLvl = sqlCommand.Parameters.Add("@LOGOPERATERFUNCLVL", SqlDbType.NVarChar);
                        SqlParameter paraLogDataSystemVersion = sqlCommand.Parameters.Add("@LOGDATASYSTEMVERSION", SqlDbType.NVarChar);
                        SqlParameter paraLogOperationStatus = sqlCommand.Parameters.Add("@LOGOPERATIONSTATUS", SqlDbType.Int);
                        SqlParameter paraLogDataMassage = sqlCommand.Parameters.Add("@LOGDATAMASSAGE", SqlDbType.NVarChar);
                        SqlParameter paraLogOperationData = sqlCommand.Parameters.Add("@LOGOPERATIONDATA", SqlDbType.NVarChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogicalDeleteCode);
                        paraLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);
                        paraLoginSectionCd.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LoginSectionCd);
                        paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogDataKindCd);
                        paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataMachineName);
                        paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataAgentCd);
                        paraLogDataAgentNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataAgentNm);
                        paraLogDataObjBootProgramNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjBootProgramNm);
                        paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjAssemblyID);
                        paraLogDataObjAssemblyNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjAssemblyNm);
                        paraLogDataObjClassID.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjClassID);
                        paraLogDataObjProcNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjProcNm);
                        paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogDataOperationCd);
                        paraLogOperaterDtProcLvl.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperaterDtProcLvl);
                        paraLogOperaterFuncLvl.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperaterFuncLvl);
                        paraLogDataSystemVersion.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataSystemVersion);
                        paraLogOperationStatus.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogOperationStatus);
                        paraLogDataMassage.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataMassage);
                        paraLogOperationData.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperationData);

                        //���O�f�[�^GUID
                        Guid guidValue = Guid.NewGuid();
                        paraLogDataGuid.Value = guidValue;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(oprtnhislogWork);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            oprtnHisLogWorkList = al;

            return status;
        }
        // --- ADD m.suzuki 2011/03/18 ---------->>>>>
        # region [�Ɖ�p]
        // --- ADD m.suzuki 2011/04/05 ---------->>>>>
        /// <summary>
        /// �Ɖ�p���엚�����O�������ݏ���
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="pgName"></param>
        /// <param name="message"></param>
        public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message )
        {
            // ���O�ɏ�������ID�����w��̏ꍇ�A�Ɖ�ʂƂ���"DCCMN04000U"�Ƃ���B
            WriteOprtnHisLogForReference( ref sqlConnection, enterpriseCode, pgName, message, "DCCMN04000U", 0 );
        }
        // --- ADD m.suzuki 2011/04/05 ----------<<<<<
        /// <summary>
        /// �Ɖ�p���엚�����O�������ݏ���
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="pgName"></param>
        /// <param name="message"></param>
        /// <param name="logDataObjAssemblyID"></param>
        /// <param name="logDataOperationCd"></param>
        // --- UPD m.suzuki 2011/04/05 ---------->>>>>
        //public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message )
        public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message, string logDataObjAssemblyID, int logDataOperationCd )
        // --- UPD m.suzuki 2011/04/05 ----------<<<<<
        {
            SqlTransaction sqlTransaction = null;
            try
            {
                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );

                ArrayList writeList = new ArrayList();
                OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
                # region [�������ݓ��e�̃Z�b�g]
                Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData( "", "", 0, new Exception() );
                oprtnhislogWork.EnterpriseCode = enterpriseCode;
                // --- UPD m.suzuki 2011/04/05 ---------->>>>>
                //oprtnhislogWork.LogDataObjAssemblyID = "DCCMN04000U";
                oprtnhislogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
                // --- UPD m.suzuki 2011/04/05 ----------<<<<<
                oprtnhislogWork.LogDataObjAssemblyNm = pgName;
                oprtnhislogWork.LogDataObjClassID = this.GetType().Name;
                // --- UPD m.suzuki 2010/00/00 ---------->>>>>
                //oprtnhislogWork.LogDataOperationCd = 0;
                oprtnhislogWork.LogDataOperationCd = logDataOperationCd;
                // --- UPD m.suzuki 2010/00/00 ----------<<<<<
                oprtnhislogWork.LogDataMassage = message;
                oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
                oprtnhislogWork.LogDataMachineName = logTextData.ClientAuthInfoWork.MachineUserId;
                oprtnhislogWork.LogDataAgentCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                oprtnhislogWork.LogDataAgentNm = logTextData.EmployeeAuthInfoWork.EmployeeWork.Name;
                oprtnhislogWork.LoginSectionCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.BelongSectionCode;
                oprtnhislogWork.LogOperaterDtProcLvl = logTextData.EmployeeAuthInfoWork.EmployeeWork.AuthorityLevel1.ToString();
                oprtnhislogWork.LogOperaterFuncLvl = logTextData.EmployeeAuthInfoWork.EmployeeWork.AuthorityLevel2.ToString();
                # endregion
                writeList.Add( oprtnhislogWork );

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogProc( ref writeList, ref sqlConnection, ref sqlTransaction );

                //�R�~�b�g
                sqlTransaction.Commit();
            }
            catch
            {
            }
            if ( sqlTransaction != null ) sqlTransaction.Dispose();
        }
        /// <summary>
        /// �N���C�A���g�A�Z���u���`�F�b�N����
        /// </summary>
        /// <param name="pgid"></param>
        public bool CheckClientAssemblyId( string pgid )
        {
            try
            {
                return this.GetClientAssemblyId().Contains( pgid );
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// �N���C�A���g�A�Z���u���h�c�擾����
        /// </summary>
        /// <returns></returns>
        public string GetClientAssemblyId()
        {
            try
            {
                Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData( "", "", 0, new Exception() );
                return logTextData.ClientAuthInfoWork.UpdAssemblyId;
            }
            catch
            {
                return string.Empty;
            }
        }
        # endregion
        // --- ADD m.suzuki 2011/03/18 ----------<<<<<
        #endregion

        #region [Delete]
        /// <summary>
        /// ���엚�����O�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int Delete(object oprtnHisLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (oprtnHisLogWork == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete���s
                status = DeleteOprtnHisLogProc(paraList, ref sqlConnection, ref sqlTransaction);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    //���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Delete");
                //���[���o�b�N
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
        /// ���엚�����O�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="oprtnhislogWorkList">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int DeleteOprtnHisLogProc(ArrayList oprtnhislogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteOprtnHisLogProcProc(oprtnhislogWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ���엚�����O�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="oprtnhislogWorkList">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int DeleteOprtnHisLogProcProc(ArrayList oprtnhislogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (oprtnhislogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnhislogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnhislogWorkList[i] as OprtnHisLogWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����
                            
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }

                            //Delete�R�}���h�̐���
                            #region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);
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
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [DeleteUOE]
        /// <summary>
        /// ���엚�����O�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraoprationLogOrderWork">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.12.02</br>
        public int DeleteUOE(object paraoprationLogOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraoprationLogOrderWork == null) return status;

                ////�p�����[�^�̃L���X�g
                //ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);


                OprationLogOrderWork oprationLogOrderWork = paraoprationLogOrderWork as OprationLogOrderWork;


                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete���s
                status = DeleteUOEProc(oprationLogOrderWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    //���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Delete");
                //���[���o�b�N
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
        /// ���엚�����O�f�[�^���(UOE��)�𕨗��폜���܂�
        /// </summary>
        /// <param name="oprationLogOrderWork">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.12.02</br>
        public int DeleteUOEProc(OprationLogOrderWork oprationLogOrderWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteUOEProcProc(oprationLogOrderWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���엚�����O�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="oprationLogOrderWork">���엚�����O�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���엚�����O�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.12.02</br>
        private int DeleteUOEProcProc(OprationLogOrderWork oprationLogOrderWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (oprationLogOrderWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (string seccdstr in oprationLogOrderWork.SectionCodes)
                    {

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                        sqlText += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                        SqlParameter findParaLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);
                        findParaLoginSectionCd.Value = SqlDataMediator.SqlSetString(seccdstr);
                        findParaLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����

                            //if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            //    sqlCommand.Cancel();
                            //    return status;
                            //}

                            //Delete�R�}���h�̐���
                            #region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);
                            findParaLoginSectionCd.Value = SqlDataMediator.SqlSetString(seccdstr);
                            findParaLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);

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
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                }
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
        /// ���엚�����O�f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return LogicalDeleteOprtnHisLog(ref oprtnHisLogWork, 0);
        }

        /// <summary>
        /// �_���폜���엚�����O�f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���엚�����O�f�[�^���𕜊����܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return LogicalDeleteOprtnHisLog(ref oprtnHisLogWork, 1);
        }

        /// <summary>
        /// ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int LogicalDeleteOprtnHisLog(ref object oprtnHisLogWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (oprtnHisLogWork == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //LogicalDelete���s
                status = LogicalDeleteOprtnHisLogProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    //���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                {
                    procModestr = "LogicalDelete";
                }
                else
                {
                    procModestr = "RevivalLogicalDelete";
                }
                base.WriteErrorLog(ex, "OprtnHisLogDB.LogicalDeleteOprtnHisLog :" + procModestr);

                //���[���o�b�N
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
        /// ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        public int LogicalDeleteOprtnHisLogProc(ref ArrayList oprtnHisLogWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteOprtnHisLogProcProc(ref oprtnHisLogWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���엚�����O�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        private int LogicalDeleteOprtnHisLogProcProc(ref ArrayList oprtnHisLogWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            int logicalDelCd = 0;
            ArrayList al = new ArrayList();

            try
            {
                if (oprtnHisLogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnHisLogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnHisLogWorkList[i] as OprtnHisLogWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        sqlText += " WHERE FILEHEADERGUIDRF=@FINDFILEHEADERGUID" + Environment.NewLine;//ADD 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);//DEL 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDFILEHEADERGUID", SqlDbType.UniqueIdentifier);//ADD 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);//DEL 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);//ADD 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }

                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                            sqlText += " WHERE FILEHEADERGUIDRF=@FINDFILEHEADERGUID" + Environment.NewLine;//ADD 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);//DEL 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);//ADD 2011/09/13 sundx #24648 �_���폜�̔r�����������C��
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)oprtnhislogWork;
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

                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;                         //���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) oprtnhislogWork.LogicalDeleteCode = 1;                  //�_���폜�t���O���Z�b�g
                            else oprtnhislogWork.LogicalDeleteCode = 3;                                         //���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) oprtnhislogWork.LogicalDeleteCode = 0;                       //�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;                 //���S�폜�̓f�[�^�Ȃ���߂�
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(oprtnhislogWork);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            oprtnHisLogWorkList = al;

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="oprtnHisLogSrchWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br>Update Note: 23015 �X�{ ��P</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, OprtnHisLogSrchWork oprtnHisLogSrchWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���O�C�����_�R�[�h
            if (oprtnHisLogSrchWork.LoginSectionCd != null)
            {
                string sectionCdstr = "";
                foreach (string seccdstr in oprtnHisLogSrchWork.LoginSectionCd)
                {
                    if (sectionCdstr != "")
                    {
                        sectionCdstr += ",";
                    }
                    sectionCdstr += "'" + seccdstr + "'";
                }
                if (sectionCdstr != "")
                {
                    retstring += "AND LOGINSECTIONCDRF IN (" + sectionCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���O�f�[�^�쐬����
            retstring += "AND LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME ";
            SqlParameter paraStLogDataCreateDateTime = sqlCommand.Parameters.Add( "@STLOGDATACREATEDATETIME", SqlDbType.BigInt );
            paraStLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks( oprtnHisLogSrchWork.St_LogDataCreateDateTime );
            //----- UPD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
            //retstring += "AND LOGDATACREATEDATETIMERF<=@EDLOGDATACREATEDATETIME ";
            //SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
            //paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            if (!oprtnHisLogSrchWork.TimeSearchFlagOverDay)
            {
                retstring += "AND LOGDATACREATEDATETIMERF<=@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            }
            else
            {
                //24���Ԃ𒴂���ꍇ�A00:00:00�`24:00:00�Ō�������
                retstring += "AND LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            }
            //----- UPD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<
            
            //���O�f�[�^��ʋ敪�R�[�h
            if (oprtnHisLogSrchWork.LogDataKindCd != -1)
            {
                retstring += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprtnHisLogSrchWork.LogDataKindCd);
            }

            //���O�f�[�^�[����(�B������)
            if (oprtnHisLogSrchWork.LogDataMachineName != "")
            {
                retstring += " AND LOGDATAMACHINENAMERF LIKE @LOGDATAMACHINENAME" + Environment.NewLine;
                SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                paraLogDataMachineName.Value = "%" + SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataMachineName) + "%"; 
            }

            //���O�f�[�^�S���҃R�[�h
            if (oprtnHisLogSrchWork.LogDataAgentCd != "")
            {
                retstring += " AND LOGDATAAGENTCDRF=@LOGDATAAGENTCD" + Environment.NewLine;
                SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataAgentCd);
            }

            //���O�f�[�^�ΏۃA�Z���u��ID
            if (oprtnHisLogSrchWork.LogDataObjAssemblyID != "")
            {
                retstring += " AND LOGDATAOBJASSEMBLYIDRF=@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataObjAssemblyID);
            }

            //���O�f�[�^�I�y���[�V�����R�[�h
            // if (oprtnHisLogSrchWork.LogDataOperationCd != 0) // DEL 2008.11.05 
            if (oprtnHisLogSrchWork.LogDataOperationCd != -1) // ADD 2008.11.05
            {
                retstring += " AND LOGDATAOPERATIONCDRF=@LOGDATAOPERATIONCD" + Environment.NewLine;
                SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(oprtnHisLogSrchWork.LogDataOperationCd);
            }

            return retstring;
        }

        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� ----->>>>>
        /// <summary>
        /// �����������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="oprtnHisLogSrchWork">���������i�[�N���X</param>
        /// <param name="subQuelyAsName">�T�u�N�G����</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �_�P�Y�Ƈ��ʋ@�\�p�������������쐬</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// <br>�Ǘ��ԍ�   : 11202046-00</br>
        /// <br>Update Note: 2021/12/15  ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770181-00</br>
        /// <br>           : �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�</br>
        /// </remarks>
        private string MakeTimeSpanWhereString( ref SqlCommand sqlCommand, OprtnHisLogSrchWork oprtnHisLogSrchWork, string subQuelyAsName)
        {
            StringBuilder whereStrings = new StringBuilder();

            whereStrings.AppendLine(" WHERE ");

            // ���������|������ǉ�����
            if (!oprtnHisLogSrchWork.TimeSearchFlag2)
            {
                //�ʏ펞�ԑт݂̂̏ꍇ ���[�鎞�ԑт݂̂̏ꍇ���܂�
                // �������o������ǉ�����
            	whereStrings.AppendFormat("        CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) >= @STSECONDS ", subQuelyAsName);
                whereStrings.AppendLine();
                //----- UPD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� ----->>>>>
                if (!oprtnHisLogSrchWork.TimeSearchFlagOverDay)
                {
                    whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) <= @EDSECONDS ", subQuelyAsName);
                    whereStrings.AppendLine();
                }
                else
                {
                    //24���Ԃ𒴂���ꍇ�A00:00:00�`24:00:00�Ō�������
                    whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) < 86400 ", subQuelyAsName);
                    whereStrings.AppendLine();
                }
                //----- UPD ���O 2021/12/15 �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή� -----<<<<<
            }
            else
            {
                //�J�n������24:00:00���I�������́i���t���ׂ��j�ꍇ

                whereStrings.AppendLine(" ( ");

                #region //�ʏ펞�ԑ�

                whereStrings.AppendFormat("	       {0}.LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME2 ", subQuelyAsName);
                whereStrings.AppendLine();
            	whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) >= @STSECONDS ", subQuelyAsName);
                whereStrings.AppendLine();
            	whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) < 86400 ", subQuelyAsName);
                whereStrings.AppendLine();

                // �ʏ펞�ԑт̏I�����t�̃p�����[�^�Z�b�g
                SqlParameter paraEdLogDataCreateDateTime2 = sqlCommand.Parameters.Add( "@EDLOGDATACREATEDATETIME2", SqlDbType.BigInt );
                DateTime paramEndDate = oprtnHisLogSrchWork.Ed_LogDataCreateDateTime;
                paramEndDate = paramEndDate.Date;
                paraEdLogDataCreateDateTime2.Value = SqlDataMediator.SqlSetDateTimeFromTicks( paramEndDate );

                #endregion //�ʏ펞�ԑ�

                whereStrings.AppendLine(" ) OR ( ");

                #region //�[�鎞�ԑ�

                whereStrings.AppendFormat("        {0}.LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME2 ", subQuelyAsName);
                whereStrings.AppendLine();
                whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) <= @EDSECONDS2 ", subQuelyAsName);
                whereStrings.AppendLine();

                // �[�鎞�ԑт̓��t�i�{�P���j�̃p�����[�^�Z�b�g
                SqlParameter paraStLogDataCreateDateTime2 = sqlCommand.Parameters.Add( "@STLOGDATACREATEDATETIME2", SqlDbType.BigInt );
                DateTime paramStartDate = oprtnHisLogSrchWork.St_LogDataCreateDateTime.AddDays( 1 );
                paramStartDate = paramStartDate.Date;
                paraStLogDataCreateDateTime2.Value = SqlDataMediator.SqlSetDateTimeFromTicks( paramStartDate );

                // �[�鎞�ԑт̏I�������̃p�����[�^�Z�b�g
                SqlParameter paraSeconds_Ed2 = sqlCommand.Parameters.Add( "@EDSECONDS2", SqlDbType.Int );
                int edTime2 = oprtnHisLogSrchWork.SearchHourEd2 * 3600 + oprtnHisLogSrchWork.SearchMinuteEd2 * 60 + oprtnHisLogSrchWork.SearchSecondEd2;
                paraSeconds_Ed2.Value = SqlDataMediator.SqlSetInt32( edTime2 );

                #endregion //�[�鎞�ԑ�

                whereStrings.AppendLine(" ) ");
            }

            SqlParameter paraSeconds_St = sqlCommand.Parameters.Add( "@STSECONDS", SqlDbType.Int );
            SqlParameter paraSeconds_Ed = sqlCommand.Parameters.Add( "@EDSECONDS", SqlDbType.Int );
            int stTime = oprtnHisLogSrchWork.SearchHourSt * 3600 + oprtnHisLogSrchWork.SearchMinuteSt * 60 + oprtnHisLogSrchWork.SearchSecondSt;
            paraSeconds_St.Value = SqlDataMediator.SqlSetInt32( stTime );
            int edTime = oprtnHisLogSrchWork.SearchHourEd * 3600 + oprtnHisLogSrchWork.SearchMinuteEd * 60 + oprtnHisLogSrchWork.SearchSecondEd;
            paraSeconds_Ed.Value = SqlDataMediator.SqlSetInt32( edTime );

            return whereStrings.ToString();
        }
        //----- ADD ���V�� K2016/10/28 �_�P�Y�Ƈ� �������������̒ǉ� -----<<<<<
        #endregion

        #region [Where���쐬���� UOE�p]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="oprationLogOrderWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br>Update Note: 23015 �X�{ ��P</br>
        private string MakeUOEWhereString(ref SqlCommand sqlCommand, OprationLogOrderWork oprationLogOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���O�C�����_�R�[�h
            if (oprationLogOrderWork.SectionCodes != null)
            {
                string sectionCdstr = "";
                foreach (string seccdstr in oprationLogOrderWork.SectionCodes)
                {
                    if (sectionCdstr != "")
                    {
                        sectionCdstr += ",";
                    }
                    sectionCdstr += "'" + seccdstr + "'";
                }
                if (sectionCdstr != "")
                {
                    retstring += "AND LOGINSECTIONCDRF IN (" + sectionCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���O�f�[�^�쐬����
            if (oprationLogOrderWork.St_LogDataCreateDateTime != DateTime.MinValue)
            {
                retstring += "AND LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME ";
                SqlParameter paraStLogDataCreateDateTime = sqlCommand.Parameters.Add("@STLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraStLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprationLogOrderWork.St_LogDataCreateDateTime);
            }
            if (oprationLogOrderWork.Ed_LogDataCreateDateTime != DateTime.MinValue)
            {
                retstring += "AND LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprationLogOrderWork.Ed_LogDataCreateDateTime);
            }
            //���O�f�[�^��ʋ敪�R�[�h
            if (oprationLogOrderWork.LogDataKindCd != -1)
            {
                retstring += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);
            }

            //���O�f�[�^�[����(�B������)
            if (oprationLogOrderWork.LogDataMachineName != "")
            {
                // -- UPD 2011/02/24 --------------------------------------------------->>>
                //retstring += " AND LOGDATAMACHINENAMERF LIKE @LOGDATAMACHINENAME" + Environment.NewLine;
                //SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                //paraLogDataMachineName.Value = "%" + SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataMachineName) + "%";

                retstring += " AND LOGDATAMACHINENAMERF=@LOGDATAMACHINENAME" + Environment.NewLine;
                SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataMachineName);
                // -- UPD 2011/02/24 ---------------------------------------------------<<<
            }

            //���O�f�[�^�ΏۃN���XID(���g�F������R�[�h)
            if (oprationLogOrderWork.LogDataObjClassID != "")
            {
                retstring += " AND LOGDATAOBJCLASSIDRF=@LOGDATAOBJCLASSID" + Environment.NewLine;
                SqlParameter paraLogDataObjClassID = sqlCommand.Parameters.Add("@LOGDATAOBJCLASSID", SqlDbType.NVarChar);
                paraLogDataObjClassID.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataObjClassID);
            }
            return retstring;
        }
        #endregion


        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� OprtnHisLogWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OprtnHisLogWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private OprtnHisLogWork CopyToOprtnHisLogWorkFromReader(ref SqlDataReader myReader)
        {
            OprtnHisLogWork wkOprtnHisLogWork = new OprtnHisLogWork();

            #region �N���X�֊i�[
            wkOprtnHisLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkOprtnHisLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkOprtnHisLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkOprtnHisLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkOprtnHisLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkOprtnHisLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkOprtnHisLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkOprtnHisLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkOprtnHisLogWork.LogDataCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("LOGDATACREATEDATETIMERF"));
            wkOprtnHisLogWork.LogDataGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("LOGDATAGUIDRF"));
            wkOprtnHisLogWork.LoginSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINSECTIONCDRF"));
            wkOprtnHisLogWork.LogDataKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGDATAKINDCDRF"));
            wkOprtnHisLogWork.LogDataMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAMACHINENAMERF"));
            wkOprtnHisLogWork.LogDataAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAAGENTCDRF"));
            wkOprtnHisLogWork.LogDataAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAAGENTNMRF"));
            wkOprtnHisLogWork.LogDataObjBootProgramNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJBOOTPROGRAMNMRF"));
            wkOprtnHisLogWork.LogDataObjAssemblyID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJASSEMBLYIDRF"));
            wkOprtnHisLogWork.LogDataObjAssemblyNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJASSEMBLYNMRF"));
            wkOprtnHisLogWork.LogDataObjClassID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJCLASSIDRF"));
            wkOprtnHisLogWork.LogDataObjProcNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJPROCNMRF"));
            wkOprtnHisLogWork.LogDataOperationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGDATAOPERATIONCDRF"));
            wkOprtnHisLogWork.LogOperaterDtProcLvl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATERDTPROCLVLRF"));
            wkOprtnHisLogWork.LogOperaterFuncLvl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATERFUNCLVLRF"));
            wkOprtnHisLogWork.LogDataSystemVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATASYSTEMVERSIONRF"));
            wkOprtnHisLogWork.LogOperationStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGOPERATIONSTATUSRF"));
            wkOprtnHisLogWork.LogDataMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAMASSAGERF"));
            wkOprtnHisLogWork.LogOperationData = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATIONDATARF"));
            #endregion

            return wkOprtnHisLogWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            OprtnHisLogWork[] OprtnHisLogWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is OprtnHisLogWork)
                    {
                        OprtnHisLogWork wkOprtnHisLogWork = paraobj as OprtnHisLogWork;
                        if (wkOprtnHisLogWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkOprtnHisLogWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            OprtnHisLogWorkArray = (OprtnHisLogWork[])XmlByteSerializer.Deserialize(byteArray, typeof(OprtnHisLogWork[]));
                        }
                        catch (Exception) { }
                        if (OprtnHisLogWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(OprtnHisLogWorkArray);
                        }
                        else
                        {
                            try
                            {
                                OprtnHisLogWork wkOprtnHisLogWork = (OprtnHisLogWork)XmlByteSerializer.Deserialize(byteArray, typeof(OprtnHisLogWork));
                                if (wkOprtnHisLogWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkOprtnHisLogWork);
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
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
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

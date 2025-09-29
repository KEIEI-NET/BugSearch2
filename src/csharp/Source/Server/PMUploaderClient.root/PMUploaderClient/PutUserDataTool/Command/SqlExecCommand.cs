using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace PutUserDataTool
{
    public class SqlExecCommand : AbstractChainCommand
    {
        public SqlExecCommand(Task task)
            : base(task)
        {
        }

        protected override void ExecuteMain()
        {
            //connection
            SqlConnection sqlConnection = null;
            try
            {
                //SQL�R�l�N�V����
                sqlConnection = SqlUtils.CreateSqlConnection();
                if (sqlConnection == null)
                {
                    throw new Exception(Environment.NewLine + "�f�[�^�x�[�X�ڑ������擾�ł��܂���ł����B���s���̊m�F���K�v�ł��B");
                };

                sqlConnection.Open();
                this.ExecuteMainProc(sqlConnection);
            }
            finally
            {
                //�R�l�N�V�����j��
                SqlUtils.CloseQuietly(sqlConnection);
            }
        }

        public void ExecuteMainProc(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            int dataSeparateNo = 0;
            int rowCount = 0;
            StringBuilder dataBuilder = new StringBuilder(1024);
            Result result = new Result();
            result.StartDate = DateTime.Now.ToString("yyyyMMdd", null);
            try
            {
                result.Name = SelfTask.Name;
                result.TaskNo = SelfTask.No;

                //���sSQL�ݒ�
                sqlCommand = new SqlCommand(SelfTask.Command, sqlConnection);
                sqlCommand.CommandTimeout = 600;//10��

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = ToolApplication.GetInstance().EnterpriseCode;

                //SQL���s
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    #region ��ɑ��M
                    //500���ɒB�����ꍇ(�Ō�̈ꌏ�ł���ꍇ�͏���)
                    if (rowCount > 0 && rowCount % DATA_SPLIT_SIZE == 0)
                    {
                        //�����񐔃J�E���g�A�b�v
                        dataSeparateNo++;
                        rowCount = 0;

                        result.SeparateNo = "" + dataSeparateNo;
                        result.DataText = dataBuilder.ToString();
                        //�t�@�C�����M
                        SendTaskResult(result);

                        //�N���A
                        result.DataText = null;
                        dataBuilder.Remove(0, dataBuilder.Length);
                    }
                    #endregion

                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        //dataBuilder.Append(sqlDataReader.GetValue(i)).Append('\t');// DEL 2024/03/04 �c������ �o�C�i���f�[�^�Ή�
                        // ADD 2024/03/04 �c������ �o�C�i���f�[�^�Ή� ----->>>>>
                        object obj = sqlDataReader.GetValue(i);
                        Type t = obj.GetType();
                        if (t.Name.Equals("Byte[]"))
                        {
                            //Byte�z��̃f�[�^�̏ꍇ�̓f�[�^��16�i������ϊ����Ċi�[����
                            //Byte�z��̃f�[�^�̓��e��null�̏ꍇ�́At.Name���uSystem.DBNull�v�ɂȂ邽�߁A������ʂ�Ȃ�
                            foreach (Byte b in (Byte[])obj)
                            {
                                try
                                {
                                    dataBuilder.Append(b.ToString("X2"));
                                }
                                catch
                                {
                                    dataBuilder.Append("##");
                                }
                            }
                            dataBuilder.Append('\t');
                        }
                        else
                        {
                            dataBuilder.Append(obj).Append('\t');
                        }
                        // ADD 2024/03/04 �c������ �o�C�i���f�[�^�Ή� -----<<<<<
                    }
                    dataBuilder.Remove(dataBuilder.Length - 1, 1);
                    dataBuilder.AppendLine();
                    rowCount++;
                }

                //��ł��K�����M�B
                if (dataBuilder.Length > 0 || dataSeparateNo == 0)
                {
                    result.SeparateNo = Result.SEPARATE_NO_END;
                    result.DataText = dataBuilder.ToString();
                    //�t�@�C�����M
                    SendTaskResult(result);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    dataSeparateNo++;
                    result.SeparateNo = dataSeparateNo + "";
                    result.DataText = "ERROR\t" + ex.Message + "\r\n" + ex.StackTrace;
                    //�t�@�C�����M
                    SendTaskResult(result);
                }
                catch (Exception)
                {
                    //ignore error.
                }
                Logger.GetInstance().Log("SQL���s���ɃG���[���������Ă��܂��B", ex, true);
                throw;
            }
            finally
            {
                SqlUtils.CloseQuietly(sqlDataReader);
                SqlUtils.CloseQuietly(sqlCommand);
            }
        }
    }
}

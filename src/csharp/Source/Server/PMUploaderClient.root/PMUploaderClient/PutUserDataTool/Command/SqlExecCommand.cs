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
                //SQLコネクション
                sqlConnection = SqlUtils.CreateSqlConnection();
                if (sqlConnection == null)
                {
                    throw new Exception(Environment.NewLine + "データベース接続情報を取得できませんでした。実行環境の確認が必要です。");
                };

                sqlConnection.Open();
                this.ExecuteMainProc(sqlConnection);
            }
            finally
            {
                //コネクション破棄
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

                //実行SQL設定
                sqlCommand = new SqlCommand(SelfTask.Command, sqlConnection);
                sqlCommand.CommandTimeout = 600;//10分

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = ToolApplication.GetInstance().EnterpriseCode;

                //SQL実行
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    #region 先に送信
                    //500件に達した場合(最後の一件である場合は除く)
                    if (rowCount > 0 && rowCount % DATA_SPLIT_SIZE == 0)
                    {
                        //分割回数カウントアップ
                        dataSeparateNo++;
                        rowCount = 0;

                        result.SeparateNo = "" + dataSeparateNo;
                        result.DataText = dataBuilder.ToString();
                        //ファイル送信
                        SendTaskResult(result);

                        //クリア
                        result.DataText = null;
                        dataBuilder.Remove(0, dataBuilder.Length);
                    }
                    #endregion

                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        //dataBuilder.Append(sqlDataReader.GetValue(i)).Append('\t');// DEL 2024/03/04 田村顕成 バイナリデータ対応
                        // ADD 2024/03/04 田村顕成 バイナリデータ対応 ----->>>>>
                        object obj = sqlDataReader.GetValue(i);
                        Type t = obj.GetType();
                        if (t.Name.Equals("Byte[]"))
                        {
                            //Byte配列のデータの場合はデータを16進文字列変換して格納する
                            //Byte配列のデータの内容がnullの場合は、t.Nameが「System.DBNull」になるため、ここを通らない
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
                        // ADD 2024/03/04 田村顕成 バイナリデータ対応 -----<<<<<
                    }
                    dataBuilder.Remove(dataBuilder.Length - 1, 1);
                    dataBuilder.AppendLine();
                    rowCount++;
                }

                //空でも必ず送信。
                if (dataBuilder.Length > 0 || dataSeparateNo == 0)
                {
                    result.SeparateNo = Result.SEPARATE_NO_END;
                    result.DataText = dataBuilder.ToString();
                    //ファイル送信
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
                    //ファイル送信
                    SendTaskResult(result);
                }
                catch (Exception)
                {
                    //ignore error.
                }
                Logger.GetInstance().Log("SQL実行中にエラーが発生しています。", ex, true);
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

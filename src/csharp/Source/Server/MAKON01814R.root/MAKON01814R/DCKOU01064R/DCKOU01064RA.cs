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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

//�����t�@�C�����C�A�E�g�ύX���̏C���ɂ��āc��������������������������������������������������
//�@�t�@�C�����C�A�E�g�ɕύX���������ꍇ�͈ȉ��̕�����𗊂�ɏC�����s���ĉ������B
//�@�@�d�������f�[�^�@�@ �� ���d�������f�[�^�ύX��
//�@�@�d�����𖾍׃f�[�^ �� ���d�����𖾍׃f�[�^�ύX��
//����������������������������������������������������������������������������������������������
/// <br>--------------------------------------</br>
/// <br>Note             :   �A��966 �d�����׃}�X�^�̓�����������N���A����B</br>
/// <br>Programmer       :   ����g</br>
/// <br>Date             :   2011/08/16</br>
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�������f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�������f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.10.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class StockSlipHistDB : RemoteWithAppLockDB, IStockSlipHistDB
    {
        /// <summary>
        /// �d�������f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        public StockSlipHistDB()
            :
            base("DCKOU01066D", "Broadleaf.Application.Remoting.ParamData.StockHistoryWork", "STOCKHISTORYRF")
        {
        }

        #region [Read]
        
        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^�Ǝd�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">���������Ǝ擾�l�����˂� StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">���������Ǝ擾�l�����˂� StockhistdtlWork ���i�[����Ă��� ArrayList</param>
        /// <param name="readMode">0:�d�������݂̂Ō���  1:�d�����ח������g�p���Č���</param>
        /// <returns>STATUS</returns>
        public int Read(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            try
            {
                //�R�l�N�V��������
                //sqlConnection = CreateSqlConnection();         //DEL 2008/06/03 M.Kubota
                sqlConnection = this.CreateSqlConnection(true);  //ADD 2008/06/03 M.Kubota

                if (sqlConnection != null)
                {
                    //sqlConnection.Open();  //DEL 2008/06/03 M.Kubota
                    SqlTransaction dummyTran = null;
                    status = ReadProc(ref stockhistoryWork, ref stockhistdtlWorkList, readMode, ref sqlConnection, ref dummyTran);
                }
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
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^�Ǝd�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">���������Ǝ擾�l�����˂� StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">���������Ǝ擾�l�����˂� StockhistdtlWork ���i�[����Ă��� ArrayList</param>
        /// <param name="readMode">0:�d�������݂̂Ō���  1:�d�����ח������g�p���Č���</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            status = this.ReadStockSlipHist(ref stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork && readMode == 1)
                {
                    status = this.ReadStockSlHistDtl(ref stockhistdtlWorkList, readMode, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    status = this.ReadStockSlHistDtl(out stockhistdtlWorkList, stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
                }
            }
            
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">���������Ǝ擾�l�����˂� StockHistoryWork �I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadStockSlipHist(ref StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlipHistProc(ref stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">���������Ǝ擾�l�����˂� StockHistoryWork �I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int ReadStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (stockhistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLPHIST.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS SLPHIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLPHIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLPHIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SLPHIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // �g�����U�N�V�������w�肳��Ă���ꍇ�͐ݒ肷��
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            this.CopyToStockHistoryWorkFromReader(myReader, ref stockhistoryWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
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
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^�ɕR�t���d�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�擾���� StockHistDtlWork ���i�[����� ArrayList</param>
        /// <param name="stockhistoryWork">���������ƂȂ� StockHistoryWork �I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// �d���`�[�ԍ�(�{�d���`��)�Ŏd�����ח������擾�������ꍇ�Ɏg�p����B
        /// </remarks>
        public int ReadStockSlHistDtl(out ArrayList stockhistdtlWorkList, StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlHistDtlProc(out stockhistdtlWorkList, stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�������f�[�^�ɕR�t���d�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�擾���� StockHistDtlWork ���i�[����� ArrayList</param>
        /// <param name="stockhistoryWork">���������ƂȂ� StockHistoryWork �I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// �d���`�[�ԍ�(�{�d���`��)�Ŏd�����ח������擾�������ꍇ�Ɏg�p����B
        /// </remarks>
        private int ReadStockSlHistDtlProc(out ArrayList stockhistdtlWorkList, StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockhistdtlWorkList = new ArrayList();

            if (stockhistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST INNER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "  ON  HIST.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // �g�����U�N�V�������w�肳��Ă���ꍇ�͐ݒ肷��
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            stockhistdtlWorkList.Add(CopyToStockHistDtlWorkFromReader(myReader));
                        }

                        if (stockhistdtlWorkList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
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
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">���������Ǝ擾�l�����˂� StockHistDtlWork ���i�[���ꂽ ArrayList</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// �d�����גʔ�(�{�d���`��)�Ŏd�����ח������擾�������ꍇ�Ɏg�p����B
        /// </remarks>
        public int ReadStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlHistDtlProc(ref stockhistdtlWorkList, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����ɍ��v����d�����ח����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">���������Ǝ擾�l�����˂� StockHistDtlWork ���i�[���ꂽ ArrayList</param>
        /// <param name="readMode">�����敪 �������_�ł͖��g�p</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// �d�����גʔ�(�{�d���`��)�Ŏd�����ח������擾�������ꍇ�Ɏg�p����B
        /// </remarks>
        private int ReadStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // �g�����U�N�V�������w�肳��Ă���ꍇ�͐ݒ肷��
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);     // ��ƃR�[�h
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);       // �d���`��
                        SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);  // �d�����גʔ�

                        int hitCount = 0;
                        
                        foreach (object item in stockhistdtlWorkList)
                        {
                            StockSlHistDtlWork dtlwork = item as StockSlHistDtlWork;

                            if (dtlwork != null)
                            {
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.StockSlipDtlNum);

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    if (myReader.Read())
                                    {
                                        this.CopyToStockHistDtlWorkFromReader(myReader, ref dtlwork);
                                        hitCount++;
                                    }
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
                                        myReader = null;
                                    }
                                }
                            }
                        }

                        if (hitCount > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
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
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int WriteInitialize(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockSlipHistWork stockHistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.MakeStockHistoryParam(paramList, out stockHistoryWork, out stockhistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockHistoryWork != null)
                {
                    paramList.Add(stockHistoryWork);
                }

                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0)
                {
                    paramList.Add(stockhistdtlWorkList);
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteInitialize(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockSlipHistWork stockHistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.MakeStockHistoryParam(paramList, out stockHistoryWork, out stockhistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockHistoryWork != null)
                {
                    // ���Ɏd���������o�^����Ă���ꍇ�͈�x�ǂݍ���
                    if (stockHistoryWork.SupplierSlipNo > 0)
                    {
                        status = this.ReadStockSlipHist(ref stockHistoryWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(stockHistoryWork);
                }

                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0)
                {
                    // ���Ɏd�����𖾍ׂ��o�^����Ă���ꍇ�͈�x�ǂݍ���
                    if ((stockhistdtlWorkList[0] as StockSlHistDtlWork).StockSlipDtlNum > 0)
                    {
                        status = this.ReadStockSlHistDtl(ref stockhistdtlWorkList, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(stockhistdtlWorkList);
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="stockHistoryWork"></param>
        /// <param name="stockHistDtlWorks"></param>
        /// <returns></returns>
        private int MakeStockHistoryParam(ArrayList paramList, out StockSlipHistWork stockHistoryWork, out ArrayList stockHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockSlipHistWork dstStockHistoryWork = null;
            ArrayList dstStockhistdtlWorkList = null;

            bool redSlip = true;

            if (paramList != null && paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is StockSlipWork)
                    {
                        if (dstStockHistoryWork == null)
                        {
                            StockSlipWork srcStockSlipWork = item as StockSlipWork;
                            dstStockHistoryWork = new StockSlipHistWork();

                            //���d�������f�[�^�ύX��
                            //dstStockHistoryWork.<#FieldName> = srcStockSlipWork.<#FieldName>;
                            # region [StockHistoryWork(�d�������f�[�^) �� StockSlipWork(�d���f�[�^)]
                            // �d�������f�[�^�E�d���f�[�^�̃��C�A�E�g�ύX�����������ꍇ�͗v�C��

                            // �ԓ`�̏ꍇ�͐V�K�ǉ������Ȃ��̂ŋ��ʃt�@�C���w�b�_������ݒ肵�Ȃ�
                            if (srcStockSlipWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;

                                dstStockHistoryWork.CreateDateTime = srcStockSlipWork.CreateDateTime;
                                dstStockHistoryWork.FileHeaderGuid = srcStockSlipWork.FileHeaderGuid;
                                dstStockHistoryWork.UpdateDateTime = srcStockSlipWork.UpdateDateTime;
                                dstStockHistoryWork.UpdEmployeeCode = srcStockSlipWork.UpdEmployeeCode;
                                dstStockHistoryWork.UpdAssemblyId1 = srcStockSlipWork.UpdAssemblyId1;
                                dstStockHistoryWork.UpdAssemblyId2 = srcStockSlipWork.UpdAssemblyId2;
                            }

                            dstStockHistoryWork.EnterpriseCode = srcStockSlipWork.EnterpriseCode;
                            dstStockHistoryWork.LogicalDeleteCode = srcStockSlipWork.LogicalDeleteCode;
                            dstStockHistoryWork.SupplierFormal = srcStockSlipWork.SupplierFormal;
                            dstStockHistoryWork.SupplierSlipNo = srcStockSlipWork.SupplierSlipNo;
                            dstStockHistoryWork.SectionCode = srcStockSlipWork.SectionCode;
                            dstStockHistoryWork.SubSectionCode = srcStockSlipWork.SubSectionCode;
                            dstStockHistoryWork.DebitNoteDiv = srcStockSlipWork.DebitNoteDiv;
                            dstStockHistoryWork.DebitNLnkSuppSlipNo = srcStockSlipWork.DebitNLnkSuppSlipNo;
                            dstStockHistoryWork.SupplierSlipCd = srcStockSlipWork.SupplierSlipCd;
                            dstStockHistoryWork.StockGoodsCd = srcStockSlipWork.StockGoodsCd;
                            dstStockHistoryWork.AccPayDivCd = srcStockSlipWork.AccPayDivCd;
                            dstStockHistoryWork.StockSectionCd = srcStockSlipWork.StockSectionCd;
                            dstStockHistoryWork.StockAddUpSectionCd = srcStockSlipWork.StockAddUpSectionCd;
                            dstStockHistoryWork.StockSlipUpdateCd = srcStockSlipWork.StockSlipUpdateCd;
                            dstStockHistoryWork.InputDay = srcStockSlipWork.InputDay;
                            dstStockHistoryWork.ArrivalGoodsDay = srcStockSlipWork.ArrivalGoodsDay;
                            dstStockHistoryWork.StockDate = srcStockSlipWork.StockDate;
                            dstStockHistoryWork.StockAddUpADate = srcStockSlipWork.StockAddUpADate;
                            dstStockHistoryWork.DelayPaymentDiv = srcStockSlipWork.DelayPaymentDiv;
                            dstStockHistoryWork.PayeeCode = srcStockSlipWork.PayeeCode;
                            dstStockHistoryWork.PayeeSnm = srcStockSlipWork.PayeeSnm;
                            dstStockHistoryWork.SupplierCd = srcStockSlipWork.SupplierCd;
                            dstStockHistoryWork.SupplierNm1 = srcStockSlipWork.SupplierNm1;
                            dstStockHistoryWork.SupplierNm2 = srcStockSlipWork.SupplierNm2;
                            dstStockHistoryWork.SupplierSnm = srcStockSlipWork.SupplierSnm;
                            dstStockHistoryWork.BusinessTypeCode = srcStockSlipWork.BusinessTypeCode;
                            dstStockHistoryWork.BusinessTypeName = srcStockSlipWork.BusinessTypeName;
                            dstStockHistoryWork.SalesAreaCode = srcStockSlipWork.SalesAreaCode;
                            dstStockHistoryWork.SalesAreaName = srcStockSlipWork.SalesAreaName;
                            dstStockHistoryWork.StockInputCode = srcStockSlipWork.StockInputCode;
                            dstStockHistoryWork.StockInputName = srcStockSlipWork.StockInputName;
                            dstStockHistoryWork.StockAgentCode = srcStockSlipWork.StockAgentCode;
                            dstStockHistoryWork.StockAgentName = srcStockSlipWork.StockAgentName;
                            dstStockHistoryWork.SuppTtlAmntDspWayCd = srcStockSlipWork.SuppTtlAmntDspWayCd;
                            dstStockHistoryWork.TtlAmntDispRateApy = srcStockSlipWork.TtlAmntDispRateApy;
                            dstStockHistoryWork.StockTotalPrice = srcStockSlipWork.StockTotalPrice;
                            dstStockHistoryWork.StockSubttlPrice = srcStockSlipWork.StockSubttlPrice;
                            dstStockHistoryWork.StockTtlPricTaxInc = srcStockSlipWork.StockTtlPricTaxInc;
                            dstStockHistoryWork.StockTtlPricTaxExc = srcStockSlipWork.StockTtlPricTaxExc;
                            dstStockHistoryWork.StockNetPrice = srcStockSlipWork.StockNetPrice;
                            dstStockHistoryWork.StockPriceConsTax = srcStockSlipWork.StockPriceConsTax;
                            dstStockHistoryWork.TtlItdedStcOutTax = srcStockSlipWork.TtlItdedStcOutTax;
                            dstStockHistoryWork.TtlItdedStcInTax = srcStockSlipWork.TtlItdedStcInTax;
                            dstStockHistoryWork.TtlItdedStcTaxFree = srcStockSlipWork.TtlItdedStcTaxFree;
                            dstStockHistoryWork.StockOutTax = srcStockSlipWork.StockOutTax;
                            dstStockHistoryWork.StckPrcConsTaxInclu = srcStockSlipWork.StckPrcConsTaxInclu;
                            dstStockHistoryWork.StckDisTtlTaxExc = srcStockSlipWork.StckDisTtlTaxExc;
                            dstStockHistoryWork.ItdedStockDisOutTax = srcStockSlipWork.ItdedStockDisOutTax;
                            dstStockHistoryWork.ItdedStockDisInTax = srcStockSlipWork.ItdedStockDisInTax;
                            dstStockHistoryWork.ItdedStockDisTaxFre = srcStockSlipWork.ItdedStockDisTaxFre;
                            dstStockHistoryWork.StockDisOutTax = srcStockSlipWork.StockDisOutTax;
                            dstStockHistoryWork.StckDisTtlTaxInclu = srcStockSlipWork.StckDisTtlTaxInclu;
                            dstStockHistoryWork.TaxAdjust = srcStockSlipWork.TaxAdjust;
                            dstStockHistoryWork.BalanceAdjust = srcStockSlipWork.BalanceAdjust;
                            dstStockHistoryWork.SuppCTaxLayCd = srcStockSlipWork.SuppCTaxLayCd;
                            dstStockHistoryWork.SupplierConsTaxRate = srcStockSlipWork.SupplierConsTaxRate;
                            dstStockHistoryWork.AccPayConsTax = srcStockSlipWork.AccPayConsTax;
                            dstStockHistoryWork.StockFractionProcCd = srcStockSlipWork.StockFractionProcCd;
                            dstStockHistoryWork.AutoPayment = srcStockSlipWork.AutoPayment;
                            dstStockHistoryWork.AutoPaySlipNum = srcStockSlipWork.AutoPaySlipNum;
                            dstStockHistoryWork.RetGoodsReasonDiv = srcStockSlipWork.RetGoodsReasonDiv;
                            dstStockHistoryWork.RetGoodsReason = srcStockSlipWork.RetGoodsReason;
                            dstStockHistoryWork.PartySaleSlipNum = srcStockSlipWork.PartySaleSlipNum;
                            dstStockHistoryWork.SupplierSlipNote1 = srcStockSlipWork.SupplierSlipNote1;
                            dstStockHistoryWork.SupplierSlipNote2 = srcStockSlipWork.SupplierSlipNote2;
                            dstStockHistoryWork.DetailRowCount = srcStockSlipWork.DetailRowCount;
                            dstStockHistoryWork.EdiSendDate = srcStockSlipWork.EdiSendDate;
                            dstStockHistoryWork.EdiTakeInDate = srcStockSlipWork.EdiTakeInDate;
                            dstStockHistoryWork.UoeRemark1 = srcStockSlipWork.UoeRemark1;
                            dstStockHistoryWork.UoeRemark2 = srcStockSlipWork.UoeRemark2;
                            dstStockHistoryWork.SlipPrintDivCd = srcStockSlipWork.SlipPrintDivCd;
                            dstStockHistoryWork.SlipPrintFinishCd = srcStockSlipWork.SlipPrintFinishCd;
                            dstStockHistoryWork.StockSlipPrintDate = srcStockSlipWork.StockSlipPrintDate;
                            dstStockHistoryWork.SlipPrtSetPaperId = srcStockSlipWork.SlipPrtSetPaperId;

                            # endregion
                        }
                    }
                    else if (item is StockSlipDeleteWork)
                    {
                        if (dstStockHistoryWork == null)
                        {
                            StockSlipDeleteWork srcStockSlipDeleteWork = item as StockSlipDeleteWork;
                            dstStockHistoryWork = new StockSlipHistWork();

                            //���d�������f�[�^�ύX��
                            # region [StockHistoryWork(�d�������f�[�^) �� StockSlipDeleteWork(�d���폜�f�[�^)]

                            // �ԓ`�̏ꍇ�͐V�K�ǉ������Ȃ��̂ŋ��ʃt�@�C���w�b�_������ݒ肵�Ȃ�
                            if (srcStockSlipDeleteWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;
                                dstStockHistoryWork.UpdateDateTime = srcStockSlipDeleteWork.UpdateDateTime;
                            }
                           
                            dstStockHistoryWork.EnterpriseCode = srcStockSlipDeleteWork.EnterpriseCode;
                            dstStockHistoryWork.SupplierFormal = srcStockSlipDeleteWork.SupplierFormal;
                            dstStockHistoryWork.SupplierSlipNo = srcStockSlipDeleteWork.SupplierSlipNo;
                            dstStockHistoryWork.DebitNoteDiv = srcStockSlipDeleteWork.DebitNoteDiv;
                            # endregion

                            if (srcStockSlipDeleteWork.SupplierFormal != 2)
                            {
                                dstStockhistdtlWorkList = new ArrayList();
                            }
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList)[0] is StockDetailWork)
                        {
                            if (dstStockhistdtlWorkList == null)
                            {
                                dstStockhistdtlWorkList = new ArrayList();

                                foreach (StockDetailWork srcStockDetailWork in (item as ArrayList))
                                {
                                    StockSlHistDtlWork dstStockHistDtlWork = new StockSlHistDtlWork();

                                    //���d�����𖾍׃f�[�^�ύX��
                                    //dstStockHistDtlWork.<#FieldName> = srcStockDetailWork.<#FieldName>;
                                    # region [StockHistDtlWork(�d�����𖾍׃f�[�^) �� StockDetailWork(�d�����׃f�[�^)]
                                    // �d�����𖾍׃f�[�^�E�d�����׃f�[�^�̃��C�A�E�g�ύX�����������ꍇ�͗v�C��
                                    dstStockHistDtlWork.CreateDateTime = srcStockDetailWork.CreateDateTime;
                                    dstStockHistDtlWork.UpdateDateTime = srcStockDetailWork.UpdateDateTime;
                                    dstStockHistDtlWork.EnterpriseCode = srcStockDetailWork.EnterpriseCode;
                                    dstStockHistDtlWork.FileHeaderGuid = srcStockDetailWork.FileHeaderGuid;
                                    dstStockHistDtlWork.UpdEmployeeCode = srcStockDetailWork.UpdEmployeeCode;
                                    dstStockHistDtlWork.UpdAssemblyId1 = srcStockDetailWork.UpdAssemblyId1;
                                    dstStockHistDtlWork.UpdAssemblyId2 = srcStockDetailWork.UpdAssemblyId2;
                                    dstStockHistDtlWork.LogicalDeleteCode = srcStockDetailWork.LogicalDeleteCode;
                                    dstStockHistDtlWork.AcceptAnOrderNo = srcStockDetailWork.AcceptAnOrderNo;
                                    dstStockHistDtlWork.SupplierFormal = srcStockDetailWork.SupplierFormal;
                                    dstStockHistDtlWork.SupplierSlipNo = srcStockDetailWork.SupplierSlipNo;
                                    dstStockHistDtlWork.StockRowNo = srcStockDetailWork.StockRowNo;
                                    dstStockHistDtlWork.SectionCode = srcStockDetailWork.SectionCode;
                                    dstStockHistDtlWork.SubSectionCode = srcStockDetailWork.SubSectionCode;
                                    dstStockHistDtlWork.CommonSeqNo = srcStockDetailWork.CommonSeqNo;
                                    dstStockHistDtlWork.StockSlipDtlNum = srcStockDetailWork.StockSlipDtlNum;
                                    dstStockHistDtlWork.SupplierFormalSrc = srcStockDetailWork.SupplierFormalSrc;
                                    dstStockHistDtlWork.StockSlipDtlNumSrc = srcStockDetailWork.StockSlipDtlNumSrc;
                                    dstStockHistDtlWork.AcptAnOdrStatusSync = srcStockDetailWork.AcptAnOdrStatusSync;
                                    dstStockHistDtlWork.SalesSlipDtlNumSync = srcStockDetailWork.SalesSlipDtlNumSync;
                                    dstStockHistDtlWork.StockSlipCdDtl = srcStockDetailWork.StockSlipCdDtl;
                                    dstStockHistDtlWork.StockAgentCode = srcStockDetailWork.StockAgentCode;
                                    dstStockHistDtlWork.StockAgentName = srcStockDetailWork.StockAgentName;
                                    dstStockHistDtlWork.GoodsKindCode = srcStockDetailWork.GoodsKindCode;
                                    dstStockHistDtlWork.GoodsMakerCd = srcStockDetailWork.GoodsMakerCd;
                                    dstStockHistDtlWork.MakerName = srcStockDetailWork.MakerName;
                                    dstStockHistDtlWork.MakerKanaName = srcStockDetailWork.MakerKanaName;
                                    dstStockHistDtlWork.CmpltMakerKanaName = srcStockDetailWork.CmpltMakerKanaName;
                                    dstStockHistDtlWork.GoodsNo = srcStockDetailWork.GoodsNo;
                                    dstStockHistDtlWork.GoodsName = srcStockDetailWork.GoodsName;
                                    dstStockHistDtlWork.GoodsNameKana = srcStockDetailWork.GoodsNameKana;
                                    dstStockHistDtlWork.GoodsLGroup = srcStockDetailWork.GoodsLGroup;
                                    dstStockHistDtlWork.GoodsLGroupName = srcStockDetailWork.GoodsLGroupName;
                                    dstStockHistDtlWork.GoodsMGroup = srcStockDetailWork.GoodsMGroup;
                                    dstStockHistDtlWork.GoodsMGroupName = srcStockDetailWork.GoodsMGroupName;
                                    dstStockHistDtlWork.BLGroupCode = srcStockDetailWork.BLGroupCode;
                                    dstStockHistDtlWork.BLGroupName = srcStockDetailWork.BLGroupName;
                                    dstStockHistDtlWork.BLGoodsCode = srcStockDetailWork.BLGoodsCode;
                                    dstStockHistDtlWork.BLGoodsFullName = srcStockDetailWork.BLGoodsFullName;
                                    dstStockHistDtlWork.EnterpriseGanreCode = srcStockDetailWork.EnterpriseGanreCode;
                                    dstStockHistDtlWork.EnterpriseGanreName = srcStockDetailWork.EnterpriseGanreName;
                                    dstStockHistDtlWork.WarehouseCode = srcStockDetailWork.WarehouseCode;
                                    dstStockHistDtlWork.WarehouseName = srcStockDetailWork.WarehouseName;
                                    dstStockHistDtlWork.WarehouseShelfNo = srcStockDetailWork.WarehouseShelfNo;
                                    dstStockHistDtlWork.StockOrderDivCd = srcStockDetailWork.StockOrderDivCd;
                                    dstStockHistDtlWork.OpenPriceDiv = srcStockDetailWork.OpenPriceDiv;
                                    dstStockHistDtlWork.GoodsRateRank = srcStockDetailWork.GoodsRateRank;
                                    dstStockHistDtlWork.CustRateGrpCode = srcStockDetailWork.CustRateGrpCode;
                                    dstStockHistDtlWork.SuppRateGrpCode = srcStockDetailWork.SuppRateGrpCode;
                                    dstStockHistDtlWork.ListPriceTaxExcFl = srcStockDetailWork.ListPriceTaxExcFl;
                                    dstStockHistDtlWork.ListPriceTaxIncFl = srcStockDetailWork.ListPriceTaxIncFl;
                                    dstStockHistDtlWork.StockRate = srcStockDetailWork.StockRate;
                                    dstStockHistDtlWork.RateSectStckUnPrc = srcStockDetailWork.RateSectStckUnPrc;
                                    dstStockHistDtlWork.RateDivStckUnPrc = srcStockDetailWork.RateDivStckUnPrc;
                                    dstStockHistDtlWork.UnPrcCalcCdStckUnPrc = srcStockDetailWork.UnPrcCalcCdStckUnPrc;
                                    dstStockHistDtlWork.PriceCdStckUnPrc = srcStockDetailWork.PriceCdStckUnPrc;
                                    dstStockHistDtlWork.StdUnPrcStckUnPrc = srcStockDetailWork.StdUnPrcStckUnPrc;
                                    dstStockHistDtlWork.FracProcUnitStcUnPrc = srcStockDetailWork.FracProcUnitStcUnPrc;
                                    dstStockHistDtlWork.FracProcStckUnPrc = srcStockDetailWork.FracProcStckUnPrc;
                                    dstStockHistDtlWork.StockUnitPriceFl = srcStockDetailWork.StockUnitPriceFl;
                                    dstStockHistDtlWork.StockUnitTaxPriceFl = srcStockDetailWork.StockUnitTaxPriceFl;
                                    dstStockHistDtlWork.StockUnitChngDiv = srcStockDetailWork.StockUnitChngDiv;
                                    dstStockHistDtlWork.BfStockUnitPriceFl = srcStockDetailWork.BfStockUnitPriceFl;
                                    dstStockHistDtlWork.BfListPrice = srcStockDetailWork.BfListPrice;
                                    dstStockHistDtlWork.RateBLGoodsCode = srcStockDetailWork.RateBLGoodsCode;
                                    dstStockHistDtlWork.RateBLGoodsName = srcStockDetailWork.RateBLGoodsName;
                                    dstStockHistDtlWork.RateGoodsRateGrpCd = srcStockDetailWork.RateGoodsRateGrpCd;
                                    dstStockHistDtlWork.RateGoodsRateGrpNm = srcStockDetailWork.RateGoodsRateGrpNm;
                                    dstStockHistDtlWork.RateBLGroupCode = srcStockDetailWork.RateBLGroupCode;
                                    dstStockHistDtlWork.RateBLGroupName = srcStockDetailWork.RateBLGroupName;
                                    dstStockHistDtlWork.StockCount = srcStockDetailWork.StockCount;
                                    dstStockHistDtlWork.StockPriceTaxExc = srcStockDetailWork.StockPriceTaxExc;
                                    dstStockHistDtlWork.StockPriceTaxInc = srcStockDetailWork.StockPriceTaxInc;
                                    dstStockHistDtlWork.StockGoodsCd = srcStockDetailWork.StockGoodsCd;
                                    dstStockHistDtlWork.StockPriceConsTax = srcStockDetailWork.StockPriceConsTax;
                                    dstStockHistDtlWork.TaxationCode = srcStockDetailWork.TaxationCode;
                                    dstStockHistDtlWork.StockDtiSlipNote1 = srcStockDetailWork.StockDtiSlipNote1;
                                    dstStockHistDtlWork.SalesCustomerCode = srcStockDetailWork.SalesCustomerCode;
                                    dstStockHistDtlWork.SalesCustomerSnm = srcStockDetailWork.SalesCustomerSnm;
                                    dstStockHistDtlWork.OrderNumber = srcStockDetailWork.OrderNumber;
                                    dstStockHistDtlWork.SlipMemo1 = srcStockDetailWork.SlipMemo1;
                                    dstStockHistDtlWork.SlipMemo2 = srcStockDetailWork.SlipMemo2;
                                    dstStockHistDtlWork.SlipMemo3 = srcStockDetailWork.SlipMemo3;
                                    dstStockHistDtlWork.InsideMemo1 = srcStockDetailWork.InsideMemo1;
                                    dstStockHistDtlWork.InsideMemo2 = srcStockDetailWork.InsideMemo2;
                                    dstStockHistDtlWork.InsideMemo3 = srcStockDetailWork.InsideMemo3;
                                    # endregion

                                    dstStockhistdtlWorkList.Add(dstStockHistDtlWork);
                                }
                            }
                        }
                    }
                }
            }

            //--- �d�����ׂɐԓ`�敪���ǉ����ꂽ�� �㕔 �ɏ������ړ����� --->>>
            // �ԓ`�̎d��������o�^����ꍇ�A�d�����ח����̋��ʃt�@�C���w�b�_������������
            if (dstStockhistdtlWorkList != null && redSlip)
            {
                foreach (StockSlHistDtlWork dstStockHistDtlWork in dstStockhistdtlWorkList)
                {
                    dstStockHistDtlWork.CreateDateTime = DateTime.MinValue;
                    dstStockHistDtlWork.FileHeaderGuid = Guid.Empty;
                    dstStockHistDtlWork.UpdateDateTime = DateTime.MinValue;
                    dstStockHistDtlWork.UpdEmployeeCode = "";
                    dstStockHistDtlWork.UpdAssemblyId1 = "";
                    dstStockHistDtlWork.UpdAssemblyId2 = "";
                }
            }
            //--- �d�����ׂɐԓ`�敪���ǉ����ꂽ�� �㕔 �ɏ������ړ����� ---<<<

            stockHistoryWork = dstStockHistoryWork;
            stockHistDtlWorks = dstStockhistdtlWorkList;

            // �d�������f�[�^�̐ԓ`�敪�� 2:���� �̏ꍇ�A�d�����ח����f�[�^�������Ă� ctDB_NORMAL �Ƃ���
            // 2009/02/18 ���ɍX�V�Ή�>>>>>>>>>>>>>>>>>>>>>>
            // �����f�[�^�̏ꍇ�̓m�[�}���Ƃ���
            //if ((dstStockHistoryWork != null && dstStockhistdtlWorkList != null) ||
            //    (dstStockhistdtlWorkList == null && (dstStockHistoryWork != null && dstStockHistoryWork.DebitNoteDiv == 2)))
            if ((dstStockHistoryWork != null && dstStockhistdtlWorkList != null) ||
                (dstStockhistdtlWorkList == null && (dstStockHistoryWork != null && dstStockHistoryWork.DebitNoteDiv == 2)) ||
                (dstStockHistoryWork != null && dstStockHistoryWork.SupplierFormal == 2))
            // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="stockHistoryWork"></param>
        /// <param name="stockHistDtlWorks"></param>
        /// <returns></returns>
        private int GetStockHistoryParam(ArrayList paramList, out StockSlipHistWork stockHistoryWork, out ArrayList stockHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockHistoryWork = null;
            stockHistDtlWorks = null;

            if (paramList != null || paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is StockSlipHistWork)
                    {
                        if (stockHistoryWork == null)
                        {
                            stockHistoryWork = item as StockSlipHistWork;
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList).Count > 0 && (item as ArrayList)[0] is StockSlHistDtlWork && stockHistDtlWorks == null)
                        {
                            stockHistDtlWorks = item as ArrayList;
                        }
                    }

                    if (stockHistoryWork != null && stockHistDtlWorks != null)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }
            }

            return status;
        }

        #region [Write]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Write(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            try
            {
                status = this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //write���s
                    status = this.WriteProc(ref stockhistoryWork, ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                // �d�������y�юd�����ח����Ɋւ���p�����[�^���폜����
                for (int i = paramList.Count - 1; i >= 0; i--)
                {
                    if (paramList[i] is StockSlipHistWork)
                    {
                        paramList.RemoveAt(i);
                    }
                    else if (paramList[i] is ArrayList)
                    {
                        if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is StockSlHistDtlWork)
                        {
                            paramList.RemoveAt(i);
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �d�������f�[�^�y�юd�����ח����f�[�^��o�^(�ǉ��E�X�V)���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">�o�^�ΏۂƂȂ� StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">�o�^�ΏۂƂȂ� StockhistdtlWork ���i�[����Ă��� ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �d�������f�[�^�o�^����
            status = this.WriteStockSlipHist(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �d�����ח����f�[�^�o�^����
                status = this.WriteStockSlHistDtl(ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// �d�������f�[�^��o�^(�폜���ǉ�)���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">�o�^�ΏۂƂȂ� StockHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteStockSlipHist(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockSlipHistProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d�������f�[�^��o�^(�폜���ǉ�)���܂��B
        /// </summary>
        /// <param name="stockhistoryWork">�o�^�ΏۂƂȂ� StockHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����Ƀf�[�^��o�^����
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    // �f�[�^�̗L���Ɋւ�炸�L�[�������ɍ폜���s��
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    sqlCommand.ExecuteNonQuery();
                    # endregion

                    // �d�������f�[�^��V�K�o�^����
                    # region [INSERT]
                    //���d�������f�[�^�ύX��
                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO STOCKSLIPHISTRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += " ,DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,ACCPAYDIVCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPUPDATECDRF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,ARRIVALGOODSDAYRF" + Environment.NewLine;
                    sqlText += " ,STOCKDATERF" + Environment.NewLine;
                    sqlText += " ,STOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,DELAYPAYMENTDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYEECODERF" + Environment.NewLine;
                    sqlText += " ,PAYEESNMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPENAMERF" + Environment.NewLine;
                    sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                    sqlText += " ,SALESAREANAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                    sqlText += " ,TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                    sqlText += " ,STOCKTOTALPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKSUBTTLPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                    sqlText += " ,STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,STOCKNETPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                    sqlText += " ,STOCKOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,STCKPRCCONSTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,STCKDISTTLTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISINTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISTAXFRERF" + Environment.NewLine;
                    sqlText += " ,STOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,STCKDISTTLTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,TAXADJUSTRF" + Environment.NewLine;
                    sqlText += " ,BALANCEADJUSTRF" + Environment.NewLine;
                    sqlText += " ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += " ,ACCPAYCONSTAXRF" + Environment.NewLine;
                    sqlText += " ,STOCKFRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONDIVRF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONRF" + Environment.NewLine;
                    sqlText += " ,PARTYSALESLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                    sqlText += " ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlText += " ,EDISENDDATERF" + Environment.NewLine;
                    sqlText += " ,EDITAKEINDATERF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTDIVCDRF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPPRINTDATERF" + Environment.NewLine;
                    sqlText += " ,SLIPPRTSETPAPERIDRF)" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                    sqlText += " ,@DEBITNLNKSUPPSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPCD" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                    sqlText += " ,@ACCPAYDIVCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@STOCKADDUPSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPUPDATECD" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;
                    sqlText += " ,@ARRIVALGOODSDAY" + Environment.NewLine;
                    sqlText += " ,@STOCKDATE" + Environment.NewLine;
                    sqlText += " ,@STOCKADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@DELAYPAYMENTDIV" + Environment.NewLine;
                    sqlText += " ,@PAYEECODE" + Environment.NewLine;
                    sqlText += " ,@PAYEESNM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPENAME" + Environment.NewLine;
                    sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                    sqlText += " ,@SALESAREANAME" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                    sqlText += " ,@TTLAMNTDISPRATEAPY" + Environment.NewLine;
                    sqlText += " ,@STOCKTOTALPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKSUBTTLPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKTTLPRICTAXINC" + Environment.NewLine;
                    sqlText += " ,@STOCKTTLPRICTAXEXC" + Environment.NewLine;
                    sqlText += " ,@STOCKNETPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                    sqlText += " ,@STOCKOUTTAX" + Environment.NewLine;
                    sqlText += " ,@STCKPRCCONSTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@STCKDISTTLTAXEXC" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISINTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISTAXFRE" + Environment.NewLine;
                    sqlText += " ,@STOCKDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@STCKDISTTLTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@TAXADJUST" + Environment.NewLine;
                    sqlText += " ,@BALANCEADJUST" + Environment.NewLine;
                    sqlText += " ,@SUPPCTAXLAYCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                    sqlText += " ,@ACCPAYCONSTAX" + Environment.NewLine;
                    sqlText += " ,@STOCKFRACTIONPROCCD" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASONDIV" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASON" + Environment.NewLine;
                    sqlText += " ,@PARTYSALESLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNOTE1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNOTE2" + Environment.NewLine;
                    sqlText += " ,@DETAILROWCOUNT" + Environment.NewLine;
                    sqlText += " ,@EDISENDDATE" + Environment.NewLine;
                    sqlText += " ,@EDITAKEINDATE" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK1" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK2" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTDIVCD" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPPRINTDATE" + Environment.NewLine;
                    sqlText += " ,@SLIPPRTSETPAPERID)" + Environment.NewLine;
                    # endregion

                    sqlCommand.CommandText = sqlText;

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockhistoryWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //���d�������f�[�^�ύX��
                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);            // �쐬����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);            // �X�V����
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);             // ��ƃR�[�h
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);           // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);          // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);          // �X�V�A�Z���u��ID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);         // �_���폜�敪
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);               // �d���`��
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);               // �d���`�[�ԍ�
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);                   // ���_�R�[�h
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);               // ����R�[�h
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);                   // �ԓ`�敪
                    SqlParameter paraDebitNLnkSuppSlipNo = sqlCommand.Parameters.Add("@DEBITNLNKSUPPSLIPNO", SqlDbType.Int);     // �ԍ��A���d���`�[�ԍ�
                    SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@SUPPLIERSLIPCD", SqlDbType.Int);               // �d���`�[�敪
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);                   // �d�����i�敪
                    SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@ACCPAYDIVCD", SqlDbType.Int);                     // ���|�敪
                    SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);             // �d�����_�R�[�h
                    SqlParameter paraStockAddUpSectionCd = sqlCommand.Parameters.Add("@STOCKADDUPSECTIONCD", SqlDbType.NChar);   // �d���v�㋒�_�R�[�h
                    SqlParameter paraStockSlipUpdateCd = sqlCommand.Parameters.Add("@STOCKSLIPUPDATECD", SqlDbType.Int);         // �d���`�[�X�V�敪
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);                           // ���͓�
                    SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);             // ���ד�
                    SqlParameter paraStockDate = sqlCommand.Parameters.Add("@STOCKDATE", SqlDbType.Int);                         // �d����
                    SqlParameter paraStockAddUpADate = sqlCommand.Parameters.Add("@STOCKADDUPADATE", SqlDbType.Int);             // �d���v����t
                    SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);             // �����敪
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);                         // �x����R�[�h
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);                      // �x���旪��
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);                       // �d����R�[�h
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);                // �d���於1
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);                // �d���於2
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);                // �d���旪��
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);           // �Ǝ�R�[�h
                    SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);      // �Ǝ햼��
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);                 // �̔��G���A�R�[�h
                    SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);            // �̔��G���A����
                    SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);             // �d�����͎҃R�[�h
                    SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);          // �d�����͎Җ���
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);             // �d���S���҃R�[�h
                    SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);          // �d���S���Җ���
                    SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);     // �d���摍�z�\�����@�敪
                    SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);       // ���z�\���|���K�p�敪
                    SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);          // �d�����z���v
                    SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);        // �d�����z���v
                    SqlParameter paraStockTtlPricTaxInc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXINC", SqlDbType.BigInt);    // �d�����z�v�i�ō��݁j
                    SqlParameter paraStockTtlPricTaxExc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXEXC", SqlDbType.BigInt);    // �d�����z�v�i�Ŕ����j
                    SqlParameter paraStockNetPrice = sqlCommand.Parameters.Add("@STOCKNETPRICE", SqlDbType.BigInt);              // �d���������z
                    SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);      // �d�����z����Ŋz
                    SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);      // �d���O�őΏۊz���v
                    SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);        // �d�����őΏۊz���v
                    SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);    // �d����ېőΏۊz���v
                    SqlParameter paraStockOutTax = sqlCommand.Parameters.Add("@STOCKOUTTAX", SqlDbType.BigInt);                  // �d�����z����Ŋz�i�O�Łj
                    SqlParameter paraStckPrcConsTaxInclu = sqlCommand.Parameters.Add("@STCKPRCCONSTAXINCLU", SqlDbType.BigInt);  // �d�����z����Ŋz�i���Łj
                    SqlParameter paraStckDisTtlTaxExc = sqlCommand.Parameters.Add("@STCKDISTTLTAXEXC", SqlDbType.BigInt);        // �d���l�����z�v�i�Ŕ����j
                    SqlParameter paraItdedStockDisOutTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISOUTTAX", SqlDbType.BigInt);  // �d���l���O�őΏۊz���v
                    SqlParameter paraItdedStockDisInTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISINTAX", SqlDbType.BigInt);    // �d���l�����őΏۊz���v
                    SqlParameter paraItdedStockDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSTOCKDISTAXFRE", SqlDbType.BigInt);  // �d���l����ېőΏۊz���v
                    SqlParameter paraStockDisOutTax = sqlCommand.Parameters.Add("@STOCKDISOUTTAX", SqlDbType.BigInt);            // �d���l������Ŋz�i�O�Łj
                    SqlParameter paraStckDisTtlTaxInclu = sqlCommand.Parameters.Add("@STCKDISTTLTAXINCLU", SqlDbType.BigInt);    // �d���l������Ŋz�i���Łj
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);                      // ����Œ����z
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);              // �c�������z
                    SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);                 // �d�������œ]�ŕ����R�[�h
                    SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);   // �d�������Őŗ�
                    SqlParameter paraAccPayConsTax = sqlCommand.Parameters.Add("@ACCPAYCONSTAX", SqlDbType.BigInt);              // ���|�����
                    SqlParameter paraStockFractionProcCd = sqlCommand.Parameters.Add("@STOCKFRACTIONPROCCD", SqlDbType.Int);     // �d���[�������敪
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);                     // �����x���敪
                    SqlParameter paraAutoPaySlipNum = sqlCommand.Parameters.Add("@AUTOPAYSLIPNUM", SqlDbType.Int);               // �����x���`�[�ԍ�
                    SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);         // �ԕi���R�R�[�h
                    SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);          // �ԕi���R
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);      // �����`�[�ԍ�
                    SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE1", SqlDbType.NVarChar);    // �d���`�[���l1
                    SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE2", SqlDbType.NVarChar);    // �d���`�[���l2
                    SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);               // ���׍s��
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);                     // �d�c�h���M��
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);                 // �d�c�h�捞��
                    SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);                  // �t�n�d���}�[�N�P
                    SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);                  // �t�n�d���}�[�N�Q
                    SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);               // �`�[���s�敪
                    SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);         // �`�[���s�ϋ敪
                    SqlParameter paraStockSlipPrintDate = sqlCommand.Parameters.Add("@STOCKSLIPPRINTDATE", SqlDbType.Int);       // �d���`�[���s��
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);    // �`�[����ݒ�p���[ID
                    #endregion

                    //���d�������f�[�^�ύX��
                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.CreateDateTime);             // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);             // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);                        // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockhistoryWork.FileHeaderGuid);                          // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);                      // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);                        // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);                        // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);                   // �_���폜�敪
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);                         // �d���`��
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);                         // �d���`�[�ԍ�
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SectionCode);                              // ���_�R�[�h
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SubSectionCode);                         // ����R�[�h
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DebitNoteDiv);                             // �ԓ`�敪
                    paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DebitNLnkSuppSlipNo);               // �ԍ��A���d���`�[�ԍ�
                    paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipCd);                         // �d���`�[�敪
                    paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockGoodsCd);                             // �d�����i�敪
                    paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AccPayDivCd);                               // ���|�敪
                    paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockSectionCd);                        // �d�����_�R�[�h
                    paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAddUpSectionCd);              // �d���v�㋒�_�R�[�h
                    paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockSlipUpdateCd);                   // �d���`�[�X�V�敪
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.InputDay);                      // ���͓�
                    paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.ArrivalGoodsDay);        // ���ד�
                    paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockDate);                    // �d����
                    paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockAddUpADate);        // �d���v����t
                    paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DelayPaymentDiv);                       // �����敪
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.PayeeCode);                                   // �x����R�[�h
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(stockhistoryWork.PayeeSnm);                                    // �x���旪��
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierCd);                                 // �d����R�[�h
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierNm1);                              // �d���於1
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierNm2);                              // �d���於2
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSnm);                              // �d���旪��
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.BusinessTypeCode);                     // �Ǝ�R�[�h
                    paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.BusinessTypeName);                    // �Ǝ햼��
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SalesAreaCode);                           // �̔��G���A�R�[�h
                    paraSalesAreaName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SalesAreaName);                          // �̔��G���A����
                    paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockInputCode);                        // �d�����͎҃R�[�h
                    paraStockInputName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockInputName);                        // �d�����͎Җ���
                    paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAgentCode);                        // �d���S���҃R�[�h
                    paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAgentName);                        // �d���S���Җ���
                    paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SuppTtlAmntDspWayCd);               // �d���摍�z�\�����@�敪
                    paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.TtlAmntDispRateApy);                 // ���z�\���|���K�p�敪
                    paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTotalPrice);                       // �d�����z���v
                    paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockSubttlPrice);                     // �d�����z���v
                    paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTtlPricTaxInc);                 // �d�����z�v�i�ō��݁j
                    paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTtlPricTaxExc);                 // �d�����z�v�i�Ŕ����j
                    paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockNetPrice);                           // �d���������z
                    paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockPriceConsTax);                   // �d�����z����Ŋz
                    paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcOutTax);                   // �d���O�őΏۊz���v
                    paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcInTax);                     // �d�����őΏۊz���v
                    paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcTaxFree);                 // �d����ېőΏۊz���v
                    paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockOutTax);                               // �d�����z����Ŋz�i�O�Łj
                    paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckPrcConsTaxInclu);               // �d�����z����Ŋz�i���Łj
                    paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckDisTtlTaxExc);                     // �d���l�����z�v�i�Ŕ����j
                    paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisOutTax);               // �d���l���O�őΏۊz���v
                    paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisInTax);                 // �d���l�����őΏۊz���v
                    paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisTaxFre);               // �d���l����ېőΏۊz���v
                    paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockDisOutTax);                         // �d���l������Ŋz�i�O�Łj
                    paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckDisTtlTaxInclu);                 // �d���l������Ŋz�i���Łj
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TaxAdjust);                                   // ����Œ����z
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.BalanceAdjust);                           // �c�������z
                    paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SuppCTaxLayCd);                           // �d�������œ]�ŕ����R�[�h
                    paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(stockhistoryWork.SupplierConsTaxRate);              // �d�������Őŗ�
                    paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.AccPayConsTax);                           // ���|�����
                    paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockFractionProcCd);               // �d���[�������敪
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AutoPayment);                               // �����x���敪
                    paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AutoPaySlipNum);                         // �����x���`�[�ԍ�
                    paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.RetGoodsReasonDiv);                   // �ԕi���R�R�[�h
                    paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(stockhistoryWork.RetGoodsReason);                        // �ԕi���R
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockhistoryWork.PartySaleSlipNum);                    // �����`�[�ԍ�
                    paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSlipNote1);                  // �d���`�[���l1
                    paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSlipNote2);                  // �d���`�[���l2
                    paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DetailRowCount);                         // ���׍s��
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.EdiSendDate);                // �d�c�h���M��
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.EdiTakeInDate);            // �d�c�h�捞��
                    paraUoeRemark1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UoeRemark1);                                // �t�n�d���}�[�N�P
                    paraUoeRemark2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UoeRemark2);                                // �t�n�d���}�[�N�Q
                    paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SlipPrintDivCd);                         // �`�[���s�敪
                    paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SlipPrintFinishCd);                   // �`�[���s�ϋ敪
                    paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockSlipPrintDate);  // �d���`�[���s��
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SlipPrtSetPaperId);                  // �`�[����ݒ�p���[ID
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    # endregion
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �d�����ח����f�[�^��o�^(�폜���ǉ�)���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�o�^�ΏۂƂȂ� StockhistdtlWork ���i�[����Ă��� ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockSlHistDtlProc(ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d�����ח����f�[�^��o�^(�폜���ǉ�)���܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�o�^�ΏۂƂȂ� StockhistdtlWork ���i�[����Ă��� ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    // �d���`�[�ԍ�(�{��)�������Ƃ��ăf�[�^�̗L���Ɋւ�炸�������׍s�̍폜���s��
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString((stockhistdtlWorkList[0] as StockSlHistDtlWork).EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32((stockhistdtlWorkList[0] as StockSlHistDtlWork).SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32((stockhistdtlWorkList[0] as StockSlHistDtlWork).SupplierSlipNo);

                    sqlCommand.ExecuteNonQuery();

                    # endregion

                    # region [INSERT]

                    //�V�K�쐬����SQL���𐶐�
                    //���d�����𖾍׃f�[�^�ύX��
                    //para<#FieldName>.Value = SqlDataMediator.<#sqlDbTypeSetAccessor>(stockhistdtlWork.<#FieldName>);  // <#name>
                    # region [INSERT��]
                    //--- ADD 2008/09/12 M.Kubota --->>>
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO STOCKSLHISTDTLRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,STOCKROWNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALSRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSKINDCODERF" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,MAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMEKANARF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSFULLNAMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,STOCKORDERDIVCDRF" + Environment.NewLine;
                    sqlText += " ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += " ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += " ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,SUPPRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,PRICECDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITCHNGDIVRF" + Environment.NewLine;
                    sqlText += " ,BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,BFLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKCOUNTRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXEXCRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXINCRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TAXATIONCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO3RF)" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@STOCKROWNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMALSRC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUMSRC" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUSSYNC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUMSYNC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPCDDTL" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@MAKERNAME" + Environment.NewLine;
                    sqlText += " ,@MAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNO" + Environment.NewLine;
                    sqlText += " ,@GOODSNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNAMEKANA" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@BLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@BLGOODSFULLNAME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSECODE" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSESHELFNO" + Environment.NewLine;
                    sqlText += " ,@STOCKORDERDIVCD" + Environment.NewLine;
                    sqlText += " ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@SUPPRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXINCFL" + Environment.NewLine;
                    sqlText += " ,@STOCKRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@PRICECDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITSTCUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITTAXPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITCHNGDIV" + Environment.NewLine;
                    sqlText += " ,@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@BFLISTPRICE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPCD" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPNM" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKCOUNT" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXEXC" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXINC" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TAXATIONCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKDTISLIPNOTE1" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO1" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO2" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO3" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO1" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO2" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO3)" + Environment.NewLine;
                    //--- ADD 2008/09/12 M.Kubota ---<<<
                    # endregion                    

                    sqlCommand.CommandText = sqlText;

                    //���d�����𖾍׃f�[�^�ύX��
                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraStockRowNo = sqlCommand.Parameters.Add("@STOCKROWNO", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                    SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                    SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                    SqlParameter paraAcptAnOdrStatusSync = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSYNC", SqlDbType.Int);
                    SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@STOCKSLIPCDDTL", SqlDbType.Int);
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                    SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                    SqlParameter paraGoodsLGroupName = sqlCommand.Parameters.Add("@GOODSLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                    SqlParameter paraGoodsMGroupName = sqlCommand.Parameters.Add("@GOODSMGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraBLGroupName = sqlCommand.Parameters.Add("@BLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                    SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                    SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                    SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                    SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@STOCKORDERDIVCD", SqlDbType.Int);
                    SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraSuppRateGrpCode = sqlCommand.Parameters.Add("@SUPPRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                    SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                    SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                    SqlParameter paraRateSectStckUnPrc = sqlCommand.Parameters.Add("@RATESECTSTCKUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivStckUnPrc = sqlCommand.Parameters.Add("@RATEDIVSTCKUNPRC", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdStckUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraPriceCdStckUnPrc = sqlCommand.Parameters.Add("@PRICECDSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraStdUnPrcStckUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSTCKUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcUnitStcUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSTCUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcStckUnPrc = sqlCommand.Parameters.Add("@FRACPROCSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                    SqlParameter paraStockUnitTaxPriceFl = sqlCommand.Parameters.Add("@STOCKUNITTAXPRICEFL", SqlDbType.Float);
                    SqlParameter paraStockUnitChngDiv = sqlCommand.Parameters.Add("@STOCKUNITCHNGDIV", SqlDbType.Int);
                    SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                    SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                    SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                    SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                    SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                    SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                    SqlParameter paraStockPriceTaxInc = sqlCommand.Parameters.Add("@STOCKPRICETAXINC", SqlDbType.BigInt);
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                    SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxationCode = sqlCommand.Parameters.Add("@TAXATIONCODE", SqlDbType.Int);
                    SqlParameter paraStockDtiSlipNote1 = sqlCommand.Parameters.Add("@STOCKDTISLIPNOTE1", SqlDbType.NVarChar);
                    SqlParameter paraSalesCustomerCode = sqlCommand.Parameters.Add("@SALESCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraSalesCustomerSnm = sqlCommand.Parameters.Add("@SALESCUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                    #endregion

                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����f�[�^��o�^����
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockhistdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            //���d�����𖾍׃f�[�^�ύX��
                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.CreateDateTime);   // �쐬����
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.UpdateDateTime);   // �X�V����
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);              // ��ƃR�[�h
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockhistdtlWork.FileHeaderGuid);                // GUID
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdEmployeeCode);            // �X�V�]�ƈ��R�[�h
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId1);              // �X�V�A�Z���u��ID1
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId2);              // �X�V�A�Z���u��ID2
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.LogicalDeleteCode);         // �_���폜�敪
                            paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.AcceptAnOrderNo);             // �󒍔ԍ�
                            paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);               // �d���`��
                            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierSlipNo);               // �d���`�[�ԍ�
                            paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockRowNo);                       // �d���s�ԍ�
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SectionCode);                    // ���_�R�[�h
                            paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SubSectionCode);               // ����R�[�h
                            paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.CommonSeqNo);                     // ���ʒʔ�
                            paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);             // �d�����גʔ�
                            paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormalSrc);         // �d���`���i���j
                            paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNumSrc);       // �d�����גʔԁi���j
                            paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.AcptAnOdrStatusSync);     // �󒍃X�e�[�^�X�i�����j
                            paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.SalesSlipDtlNumSync);     // ���㖾�גʔԁi�����j
                            paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockSlipCdDtl);               // �d���`�[�敪�i���ׁj
                            paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockAgentCode);              // �d���S���҃R�[�h
                            paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockAgentName);              // �d���S���Җ���
                            paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsKindCode);                 // ���i����
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsMakerCd);                   // ���i���[�J�[�R�[�h
                            paraMakerName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.MakerName);                        // ���[�J�[����
                            paraMakerKanaName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.MakerKanaName);                // ���[�J�[�J�i����
                            paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.CmpltMakerKanaName);      // ���[�J�[�J�i���́i�ꎮ�j
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsNo);                            // ���i�ԍ�
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsName);                        // ���i����
                            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsNameKana);                // ���i���̃J�i
                            paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsLGroup);                     // ���i�啪�ރR�[�h
                            paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsLGroupName);            // ���i�啪�ޖ���
                            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsMGroup);                     // ���i�����ރR�[�h
                            paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsMGroupName);            // ���i�����ޖ���
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.BLGroupCode);                     // BL�O���[�v�R�[�h
                            paraBLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.BLGroupName);                    // BL�O���[�v�R�[�h����
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.BLGoodsCode);                     // BL���i�R�[�h
                            paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.BLGoodsFullName);            // BL���i�R�[�h���́i�S�p�j
                            paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.EnterpriseGanreCode);     // ���Е��ރR�[�h
                            paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseGanreName);    // ���Е��ޖ���
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseCode);                // �q�ɃR�[�h
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseName);                // �q�ɖ���
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseShelfNo);          // �q�ɒI��
                            paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockOrderDivCd);             // �d���݌Ɏ�񂹋敪
                            paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.OpenPriceDiv);                   // �I�[�v�����i�敪
                            paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsRateRank);                // ���i�|�������N
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.CustRateGrpCode);             // ���Ӑ�|���O���[�v�R�[�h
                            paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SuppRateGrpCode);             // �d����|���O���[�v�R�[�h
                            paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.ListPriceTaxExcFl);        // �艿�i�Ŕ��C�����j
                            paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.ListPriceTaxIncFl);        // �艿�i�ō��C�����j
                            paraStockRate.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockRate);                        // �d����
                            paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateSectStckUnPrc);        // �|���ݒ苒�_�i�d���P���j
                            paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateDivStckUnPrc);          // �|���ݒ�敪�i�d���P���j
                            paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.UnPrcCalcCdStckUnPrc);   // �P���Z�o�敪�i�d���P���j
                            paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.PriceCdStckUnPrc);           // ���i�敪�i�d���P���j
                            paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StdUnPrcStckUnPrc);        // ��P���i�d���P���j
                            paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.FracProcUnitStcUnPrc);  // �[�������P�ʁi�d���P���j
                            paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.FracProcStckUnPrc);         // �[�������i�d���P���j
                            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockUnitPriceFl);          // �d���P���i�Ŕ��C�����j
                            paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockUnitTaxPriceFl);    // �d���P���i�ō��C�����j
                            paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockUnitChngDiv);           // �d���P���ύX�敪
                            paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.BfStockUnitPriceFl);      // �ύX�O�d���P���i�����j
                            paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.BfListPrice);                    // �ύX�O�艿
                            paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateBLGoodsCode);             // BL���i�R�[�h�i�|���j
                            paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateBLGoodsName);            // BL���i�R�[�h���́i�|���j
                            paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateGoodsRateGrpCd);       // ���i�|���O���[�v�R�[�h�i�|���j
                            paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateGoodsRateGrpNm);      // ���i�|���O���[�v���́i�|���j
                            paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateBLGroupCode);             // BL�O���[�v�R�[�h�i�|���j
                            paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateBLGroupName);            // BL�O���[�v���́i�|���j
                            paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockCount);                      // �d����
                            paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceTaxExc);           // �d�����z�i�Ŕ����j
                            paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceTaxInc);           // �d�����z�i�ō��݁j
                            paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockGoodsCd);                   // �d�����i�敪
                            paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceConsTax);         // �d�����z����Ŋz
                            paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.TaxationCode);                   // �ېŋ敪
                            paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockDtiSlipNote1);        // �d���`�[���ה��l1
                            paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SalesCustomerCode);         // �̔���R�[�h
                            paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SalesCustomerSnm);          // �̔��旪��
                            paraOrderNumber.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.OrderNumber);                    // �����ԍ�
                            paraSlipMemo1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo1);                        // �`�[�����P
                            paraSlipMemo2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo2);                        // �`�[�����Q
                            paraSlipMemo3.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo3);                        // �`�[�����R
                            paraInsideMemo1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo1);                    // �Г������P
                            paraInsideMemo2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo2);                    // �Г������Q
                            paraInsideMemo3.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo3);                    // �Г������R
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    # endregion

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
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
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDelete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref paramList, 0, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int RevivalLogicalDelete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref paramList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDeleteProc(ref ArrayList paramList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

            if (stockhistoryWork != null)
            {
                status = this.LogicalDeleteProc(ref stockhistoryWork, ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);

                // �ԓ`�����폜�̏ꍇ�A�����`�̐ԍ��A���`�[�ԍ�������������
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockhistoryWork.DebitNoteDiv == 1)
                    {
                        status = this.DeleteDebitNLnkSuppSlipNo(stockhistoryWork, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }

            for (int i = 0; i < paramList.Count; i++)
            {
                if (paramList[i] is StockSlipHistWork)
                {
                    paramList.RemoveAt(i);
                }
                else if (paramList[i] is ArrayList)
                {

                    if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is StockSlHistDtlWork)
                    {
                        paramList.RemoveAt(i);
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            try
            {
                status = this.LogicalDeleteStockSlipHist(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                    {
                        // �d�����ח����f�[�^�����ɂP�����ƂɎd�����ח����f�[�^��_���폜����
                        status = this.LogicalDeleteStockSlHistDtl(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // �d�������f�[�^�����ɂP�x�ɕ������̎d�����ח����f�[�^��_���폜����
                        status = this.LogicalDeleteStockSlHistDtl(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";

                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";

                base.WriteErrorLog(ex, "StockSlipHistDB.LogicalDeleteProc :" + procModestr);

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {

            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDeleteStockSlipHist(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlipHistProc(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����Ƀf�[�^�𑀍삷��
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;
                    
                    //Select�R�}���h�̐���
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�X�V����SQL�����쐬
                        # region [UPDATE��]
                        sqlText = "";
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockhistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    sqlCommand.Cancel();
                    
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) stockhistoryWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else stockhistoryWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            stockhistoryWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                            }

                            return status;
                        }
                    }

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        /// <summary>
        /// �d�����ח����f�[�^�̘_���폜��Ԃ𑀍삵�܂��B
        /// </summary>
        /// <param name="stockhistoryWork">�_���폜�Ώۂ̎d�����ח����f�[�^�ɕR�t�� StockHistoryWork</param>
        /// <param name="procMode">����敪 0:�폜, 1:����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteStockSlHistDtl(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlHistDtlProc(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d�����ח����f�[�^�̘_���폜��Ԃ𑀍삵�܂��B
        /// </summary>
        /// <param name="stockhistoryWork">�_���폜�Ώۂ̎d�����ח����f�[�^�ɕR�t�� StockHistoryWork</param>
        /// <param name="procMode">����敪 0:�폜, 1:����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteStockSlHistDtlProc(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����Ƀf�[�^�𑀍삷��
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Select�R�}���h�̐���
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�X�V����SQL�����쐬
                        # region [UPDATE��]
                        sqlText = "";
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockhistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    sqlCommand.Cancel();

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    // �R�t���d�������f�[�^�̘_���폜�敪�𓥏P����
                    /*
                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) stockhistoryWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else stockhistoryWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            stockhistoryWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                            }

                            return status;
                        }
                    }
                    */

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        /// <summary>
        /// �d�����ח����f�[�^�̘_���폜��Ԃ𑀍삵�܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�_���폜�Ώۂ� StockhistdtlWork ���i�[���� ArrayList</param>
        /// <param name="procMode">����敪 0:�폜, 1:����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlHistDtlProc(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d�����ח����f�[�^�̘_���폜��Ԃ𑀍삵�܂��B
        /// </summary>
        /// <param name="stockhistdtlWorkList">�_���폜�Ώۂ� StockhistdtlWork ���i�[���� ArrayList</param>
        /// <param name="procMode">����敪 0:�폜, 1:����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;
                    
                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����f�[�^��o�^����
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //Select�R�}���h�̐���
                            #region [SELECT��]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKSLHISTDTLRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            # endregion

                            if (sqlCommand == null)
                            {
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                            }
                            else
                            {
                                sqlCommand.CommandText = sqlText;
                                sqlCommand.Parameters.Clear();
                            }

                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                                if (_updateDateTime != stockhistdtlWork.UpdateDateTime)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    if (stockhistdtlWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }

                                //�X�V����SQL�����쐬
                                # region [UPDATE��]
                                sqlText = "";
                                sqlText += "UPDATE" + Environment.NewLine;
                                sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEY�R�}���h���Đݒ�
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                                //�X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)stockhistdtlWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                if (stockhistdtlWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
                            }

                            sqlCommand.Cancel();

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            //�_���폜���[�h�̏ꍇ
                            if (procMode == 0)
                            {
                                if (logicalDelCd == 3)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                    return status;
                                }
                                else if (logicalDelCd == 0) stockhistdtlWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                                else stockhistdtlWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                            }
                            else
                            {
                                if (logicalDelCd == 1)
                                {
                                    stockhistdtlWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                                }
                                else
                                {
                                    if (logicalDelCd == 0)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                    }
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                                    }

                                    return status;
                                }
                            }

                            #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            #endregion

                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.LogicalDeleteCode);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        // --- ADD �A��966 2011/08/16 ---------->>>>>
        /// <summary>
        /// �d�����𖾍׃f�[�^�̓�����������N���A����B
        /// </summary>
        /// <param name="stockDetailWork">�d������work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �A��966 �d�����𖾍׃f�[�^�̓�����������N���A����B</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/08/16</br>
        /// <br></br>
        /// <br>Update Note: ����d���������͂̔���f�[�^�폜���A�d�����גʔԂ̌^�s������������s��̏C��</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2011/10/14</br>
        public int ClearStockSlHistDtlSync(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKSLHISTDTLRF SET UPDATEDATETIMERF=@UPDATEDATETIME,ENTERPRISECODERF=@ENTERPRISECODE,FILEHEADERGUIDRF=@FILEHEADERGUID,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,UPDASSEMBLYID1RF=@UPDASSEMBLYID1,UPDASSEMBLYID2RF=@UPDASSEMBLYID2,ACPTANODRSTATUSSYNCRF=0,SALESSLIPDTLNUMSYNCRF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF ", sqlConnection, sqlTransaction))
                {
                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    // -- UPD 2011/10/14 ----------------------------->>>
                    //SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.BigInt);
                    // -- UPD 2011/10/14 -----------------------------<<<

                    //KEY�R�}���h���Đݒ�
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                    findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }
        // --- ADD �A��966 2011/08/16 ----------<<<<<

        #region [Delete]
        /// <summary>
        /// �d�������f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paramList">�d�������f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <br>Note       : �d�������f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        public int Delete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            try
            {
                this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

                if (stockhistoryWork != null)
                {
                    //Delete���s
                    status = this.DeleteProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this.DeleteStockSlipHist(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.DeleteStockSlHistDtl(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// �d�������f�[�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockhistoryWork">�d�������f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �d�������f�[�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        public int DeleteStockSlipHist(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlipHistProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d�������f�[�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockhistoryWork">�d�������f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �d�������f�[�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        private int DeleteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����Ƀf�[�^�𑀍삷��
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Select�R�}���h�̐���
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�X�V����SQL�����쐬
                        # region [UPDATE��]
                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        sqlCommand.Cancel();

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteStockSlHistDtl(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlHistDtlProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteStockSlHistDtlProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����Ƀf�[�^�𑀍삷��
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Select�R�}���h�̐���
                    #region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�폜����SQL�����쐬
                        # region [DELETE��]
                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        sqlCommand.Cancel();

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlHistDtlProc(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    //int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // �d���`���� 0:�d�� �̏ꍇ�ɂ̂ݗ����f�[�^��o�^����
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //Select�R�}���h�̐���
                            #region [SELECT��]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKSLIPHISTRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            # endregion

                            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                                if (_updateDateTime != stockhistdtlWork.UpdateDateTime)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    if (stockhistdtlWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }

                                //�X�V����SQL�����쐬
                                # region [UPDATE��]
                                sqlText = "";
                                sqlText += "DELETE" + Environment.NewLine;
                                sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEY�R�}���h���Đݒ�
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);
                            }
                            else
                            {
                                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                if (stockhistdtlWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
                            }

                            sqlCommand.Cancel();

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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

        # region [RedWrite]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redSlipList"></param>
        /// <param name="blkSlipList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int RedWrite(ref ArrayList redSlipList, ref ArrayList blkSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ԓ`�i�[�p
            StockSlipHistWork redStockHistoryWork = null;
            ArrayList redStockHistDtlWorkList = null;

            status = this.MakeStockHistoryParam(redSlipList, out redStockHistoryWork, out redStockHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            
            // �ԓ`����o�^
            status = this.WriteProc(ref redStockHistoryWork, ref redStockHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // �����i�[�p
            StockSlipHistWork blkStockHistoryWork = null;
            ArrayList blkStockHistDtlWorkList = null;

            status = this.MakeStockHistoryParam(blkSlipList, out blkStockHistoryWork, out blkStockHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // ��������o�^
            status = this.WriteProc(ref blkStockHistoryWork, ref blkStockHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// �����`�̐ԍ��A���d���`�[�ԍ������Z�b�g���܂�
        /// </summary>
        /// <param name="stockHistoryWork">����`�[�폜�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int DeleteDebitNLnkSuppSlipNo(StockSlipHistWork stockHistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
				// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 --------->>>>>
				IFileHeader flhd = (IFileHeader)new StockSlipHistWork();
				new FileHeader(this).SetUpdateHeader(ref flhd, this);
				// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 ---------<<<<<
                string sqlText = "";
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  DEBITNLNKSUPPSLIPNORF = 0" + Environment.NewLine;
				sqlText += " ,DEBITNOTEDIVRF = 0" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 --------->>>>>
				sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
				sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 ---------<<<<<
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND DEBITNLNKSUPPSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
					SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
					// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 --------->>>>>
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 ---------<<<<<

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SupplierFormal);
					findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SupplierSlipNo);
					// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 --------->>>>>
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
					// ADD 2011/09/08 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) #24609 ---------<<<<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        # endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockSlipHistWork CopyToStockHistoryWorkFromReader(SqlDataReader myReader)
        {
            StockSlipHistWork wkStockHistoryWork = new StockSlipHistWork();

            this.CopyToStockHistoryWorkFromReader(myReader, ref wkStockHistoryWork);
            
            return wkStockHistoryWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="stockSlipHistWork"></param>
        private void CopyToStockHistoryWorkFromReader(SqlDataReader myReader, ref StockSlipHistWork stockSlipHistWork)
        {
            //���d�������f�[�^�ύX��
            // stockSlipHistWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));  // <#name>
            if (stockSlipHistWork != null)
            {
                #region �N���X�֊i�[
                stockSlipHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));             // �쐬����
                stockSlipHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));             // �X�V����
                stockSlipHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                        // ��ƃR�[�h
                stockSlipHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
                stockSlipHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // �X�V�]�ƈ��R�[�h
                stockSlipHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // �X�V�A�Z���u��ID1
                stockSlipHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // �X�V�A�Z���u��ID2
                stockSlipHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                   // �_���폜�敪
                stockSlipHistWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                         // �d���`��
                stockSlipHistWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                         // �d���`�[�ԍ�
                stockSlipHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                              // ���_�R�[�h
                stockSlipHistWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                         // ����R�[�h
                stockSlipHistWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                             // �ԓ`�敪
                stockSlipHistWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));               // �ԍ��A���d���`�[�ԍ�
                stockSlipHistWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));                         // �d���`�[�敪
                stockSlipHistWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                             // �d�����i�敪
                stockSlipHistWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));                               // ���|�敪
                stockSlipHistWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));                        // �d�����_�R�[�h
                stockSlipHistWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));              // �d���v�㋒�_�R�[�h
                stockSlipHistWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));                   // �d���`�[�X�V�敪
                stockSlipHistWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));                      // ���͓�
                stockSlipHistWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));        // ���ד�
                stockSlipHistWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));                    // �d����
                stockSlipHistWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));        // �d���v����t
                stockSlipHistWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));                       // �����敪
                stockSlipHistWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                                   // �x����R�[�h
                stockSlipHistWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                    // �x���旪��
                stockSlipHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                 // �d����R�[�h
                stockSlipHistWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                              // �d���於1
                stockSlipHistWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                              // �d���於2
                stockSlipHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                              // �d���旪��
                stockSlipHistWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));                     // �Ǝ�R�[�h
                stockSlipHistWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));                    // �Ǝ햼��
                stockSlipHistWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));                           // �̔��G���A�R�[�h
                stockSlipHistWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));                          // �̔��G���A����
                stockSlipHistWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));                        // �d�����͎҃R�[�h
                stockSlipHistWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));                        // �d�����͎Җ���
                stockSlipHistWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));                        // �d���S���҃R�[�h
                stockSlipHistWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));                        // �d���S���Җ���
                stockSlipHistWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));               // �d���摍�z�\�����@�敪
                stockSlipHistWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));                 // ���z�\���|���K�p�敪
                stockSlipHistWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));                       // �d�����z���v
                stockSlipHistWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));                     // �d�����z���v
                stockSlipHistWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));                 // �d�����z�v�i�ō��݁j
                stockSlipHistWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));                 // �d�����z�v�i�Ŕ����j
                stockSlipHistWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));                           // �d���������z
                stockSlipHistWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));                   // �d�����z����Ŋz
                stockSlipHistWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));                   // �d���O�őΏۊz���v
                stockSlipHistWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));                     // �d�����őΏۊz���v
                stockSlipHistWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));                 // �d����ېőΏۊz���v
                stockSlipHistWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));                               // �d�����z����Ŋz�i�O�Łj
                stockSlipHistWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));               // �d�����z����Ŋz�i���Łj
                stockSlipHistWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));                     // �d���l�����z�v�i�Ŕ����j
                stockSlipHistWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));               // �d���l���O�őΏۊz���v
                stockSlipHistWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));                 // �d���l�����őΏۊz���v
                stockSlipHistWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));               // �d���l����ېőΏۊz���v
                stockSlipHistWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));                         // �d���l������Ŋz�i�O�Łj
                stockSlipHistWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));                 // �d���l������Ŋz�i���Łj
                stockSlipHistWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));                                   // ����Œ����z
                stockSlipHistWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));                           // �c�������z
                stockSlipHistWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));                           // �d�������œ]�ŕ����R�[�h
                stockSlipHistWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));              // �d�������Őŗ�
                stockSlipHistWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));                           // ���|�����
                stockSlipHistWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));               // �d���[�������敪
                stockSlipHistWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                               // �����x���敪
                stockSlipHistWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));                         // �����x���`�[�ԍ�
                stockSlipHistWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));                   // �ԕi���R�R�[�h
                stockSlipHistWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));                        // �ԕi���R
                stockSlipHistWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));                    // �����`�[�ԍ�
                stockSlipHistWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));                  // �d���`�[���l1
                stockSlipHistWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));                  // �d���`�[���l2
                stockSlipHistWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));                         // ���׍s��
                stockSlipHistWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));                // �d�c�h���M��
                stockSlipHistWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));            // �d�c�h�捞��
                stockSlipHistWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                                // �t�n�d���}�[�N�P
                stockSlipHistWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));                                // �t�n�d���}�[�N�Q
                stockSlipHistWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));                         // �`�[���s�敪
                stockSlipHistWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));                   // �`�[���s�ϋ敪
                stockSlipHistWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));  // �d���`�[���s��
                stockSlipHistWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));                  // �`�[����ݒ�p���[ID
                #endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockSlHistDtlWork CopyToStockHistDtlWorkFromReader(SqlDataReader myReader)
        {
            StockSlHistDtlWork wkStockHistDtlWork = new StockSlHistDtlWork();

            this.CopyToStockHistDtlWorkFromReader(myReader, ref wkStockHistDtlWork);

            return wkStockHistDtlWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="stockSlHistDtlWork"></param>
        private void CopyToStockHistDtlWorkFromReader(SqlDataReader myReader, ref StockSlHistDtlWork stockSlHistDtlWork)
        {
            //���d�����𖾍׃f�[�^�ύX��
            //stockSlHistDtlWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));  // <#name>
            if (stockSlHistDtlWork != null)
            {
                #region �N���X�֊i�[
                stockSlHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));   // �쐬����
                stockSlHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));   // �X�V����
                stockSlHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));              // ��ƃR�[�h
                stockSlHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
                stockSlHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));            // �X�V�]�ƈ��R�[�h
                stockSlHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));              // �X�V�A�Z���u��ID1
                stockSlHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));              // �X�V�A�Z���u��ID2
                stockSlHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));         // �_���폜�敪
                stockSlHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));             // �󒍔ԍ�
                stockSlHistDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));               // �d���`��
                stockSlHistDtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));               // �d���`�[�ԍ�
                stockSlHistDtlWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));                       // �d���s�ԍ�
                stockSlHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                    // ���_�R�[�h
                stockSlHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));               // ����R�[�h
                stockSlHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));                     // ���ʒʔ�
                stockSlHistDtlWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));             // �d�����גʔ�
                stockSlHistDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));         // �d���`���i���j
                stockSlHistDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));       // �d�����גʔԁi���j
                stockSlHistDtlWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));     // �󒍃X�e�[�^�X�i�����j
                stockSlHistDtlWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));     // ���㖾�גʔԁi�����j
                stockSlHistDtlWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));               // �d���`�[�敪�i���ׁj
                stockSlHistDtlWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));              // �d���S���҃R�[�h
                stockSlHistDtlWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));              // �d���S���Җ���
                stockSlHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));                 // ���i����
                stockSlHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                   // ���i���[�J�[�R�[�h
                stockSlHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));                        // ���[�J�[����
                stockSlHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));                // ���[�J�[�J�i����
                stockSlHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));      // ���[�J�[�J�i���́i�ꎮ�j
                stockSlHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                            // ���i�ԍ�
                stockSlHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                        // ���i����
                stockSlHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));                // ���i���̃J�i
                stockSlHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));                     // ���i�啪�ރR�[�h
                stockSlHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));            // ���i�啪�ޖ���
                stockSlHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));                     // ���i�����ރR�[�h
                stockSlHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));            // ���i�����ޖ���
                stockSlHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));                     // BL�O���[�v�R�[�h
                stockSlHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));                    // BL�O���[�v�R�[�h����
                stockSlHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));                     // BL���i�R�[�h
                stockSlHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));            // BL���i�R�[�h���́i�S�p�j
                stockSlHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));     // ���Е��ރR�[�h
                stockSlHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));    // ���Е��ޖ���
                stockSlHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                // �q�ɃR�[�h
                stockSlHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));                // �q�ɖ���
                stockSlHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));          // �q�ɒI��
                stockSlHistDtlWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));             // �d���݌Ɏ�񂹋敪
                stockSlHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));                   // �I�[�v�����i�敪
                stockSlHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));                // ���i�|�������N
                stockSlHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));             // ���Ӑ�|���O���[�v�R�[�h
                stockSlHistDtlWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));             // �d����|���O���[�v�R�[�h
                stockSlHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));        // �艿�i�Ŕ��C�����j
                stockSlHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));        // �艿�i�ō��C�����j
                stockSlHistDtlWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));                        // �d����
                stockSlHistDtlWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));        // �|���ݒ苒�_�i�d���P���j
                stockSlHistDtlWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));          // �|���ݒ�敪�i�d���P���j
                stockSlHistDtlWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));   // �P���Z�o�敪�i�d���P���j
                stockSlHistDtlWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));           // ���i�敪�i�d���P���j
                stockSlHistDtlWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));        // ��P���i�d���P���j
                stockSlHistDtlWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));  // �[�������P�ʁi�d���P���j
                stockSlHistDtlWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));         // �[�������i�d���P���j
                stockSlHistDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));          // �d���P���i�Ŕ��C�����j
                stockSlHistDtlWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));    // �d���P���i�ō��C�����j
                stockSlHistDtlWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));           // �d���P���ύX�敪
                stockSlHistDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));      // �ύX�O�d���P���i�����j
                stockSlHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));                    // �ύX�O�艿
                stockSlHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));             // BL���i�R�[�h�i�|���j
                stockSlHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));            // BL���i�R�[�h���́i�|���j
                stockSlHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));       // ���i�|���O���[�v�R�[�h�i�|���j
                stockSlHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));      // ���i�|���O���[�v���́i�|���j
                stockSlHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));             // BL�O���[�v�R�[�h�i�|���j
                stockSlHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));            // BL�O���[�v���́i�|���j
                stockSlHistDtlWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));                      // �d����
                stockSlHistDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));           // �d�����z�i�Ŕ����j
                stockSlHistDtlWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));           // �d�����z�i�ō��݁j
                stockSlHistDtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                   // �d�����i�敪
                stockSlHistDtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));         // �d�����z����Ŋz
                stockSlHistDtlWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));                   // �ېŋ敪
                stockSlHistDtlWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));        // �d���`�[���ה��l1
                stockSlHistDtlWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));         // �̔���R�[�h
                stockSlHistDtlWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));          // �̔��旪��
                stockSlHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                    // �����ԍ�
                stockSlHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));                        // �`�[�����P
                stockSlHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));                        // �`�[�����Q
                stockSlHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));                        // �`�[�����R
                stockSlHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));                    // �Г������P
                stockSlHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));                    // �Г������Q
                stockSlHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));                    // �Г������R
                #endregion
            }
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockSlipHistWork[] StockHistoryWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockSlipHistWork)
                    {
                        StockSlipHistWork wkStockHistoryWork = paraobj as StockSlipHistWork;
                        if (wkStockHistoryWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockHistoryWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockHistoryWorkArray = (StockSlipHistWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockSlipHistWork[]));
                        }
                        catch (Exception) { }
                        if (StockHistoryWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockHistoryWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockSlipHistWork wkStockHistoryWork = (StockSlipHistWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockSlipHistWork));
                                if (wkStockHistoryWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockHistoryWork);
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

        # region [���DEL 2008/06/03 M.Kubota ---]
#if false
        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
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
#endif
        # endregion
    }
}

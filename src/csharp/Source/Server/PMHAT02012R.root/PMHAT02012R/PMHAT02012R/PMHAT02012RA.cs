using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;  // ADD 2021/02/15
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����ꗗ�\�f�[�^�X�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�\�f�[�^�X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.15</br>
    /// <br></br>
    /// <br>Update Note: ���O�C�����_�P�ʂŔ����f�[�^�̍폜���s���悤�ɏC��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br></br>
    /// <br>Update Note: �`���[�j���O</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2011/02/24</br>
    /// <br>Note       : redmine#34986�̑Ή� �����ꗗ�\��UOE���������̃T�[�o�[�ŁA���엚�����O�ǉ�</br>
    /// <br>Programmer : pengjie</br>
    /// <br>Date       : 2012.03.14</br>
    /// <br></br>
    /// <br>Update Note: �ʎ������������������AUOE�����ԍ��̔Ԍ�̃��R�[�h�_���폜�ΏۊO</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2021/02/15</br>
    /// </remarks>
    [Serializable]
    public class OrderListRenewWorkDB : RemoteWithAppLockDB, IOrderListRenewWorkDB
    {

        //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
        #region�@Private Const
        private const string UOE_ORDER_SEARCH_BEGIN = "UOE�����f�[�^�����J�n";
        private const string UOE_ORDER_SEARCH_END = "UOE�����f�[�^�����I��";
        private const string UOE_ORDER_LOGICALDELETE_BEGIN = "UOE�����f�[�^�_���폜�J�n";
        private const string UOE_ORDER_LOGICALDELETE_END = "UOE�����f�[�^�_���폜�I��";
        private const string STOCKDETAIL_DELETE_BEGIN = "�d�����׃f�[�^�폜�J�n";
        private const string STOCKDETAIL_DELETE_END = "�d�����׃f�[�^�폜�I��";
        private const string UOE_ORDER_WRITE_BEGIN = "UOE�����f�[�^�o�^�J�n";
        private const string UOE_ORDER_WRITE_END = "UOE�����f�[�^�o�^�I��";
        private const string STOCKSLIP_WRITE_BEGIN = "�d���f�[�^�E���׃f�[�^�o�^�J�n";
        private const string STOCKSLIP_WRITE_END = "�d���f�[�^�E���׃f�[�^�o�^�I��";
        #endregion
        //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

        public int Write(ref object List, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //StockSlipDB _stockSlipDB = new StockSlipDB();
            IOWriteMASIRDB _stockSlipDB = new IOWriteMASIRDB();
            IOWriteControlDB _iOWriteControlDB = new IOWriteControlDB();
            
            ArrayList uoeOrderDtlList = new ArrayList();
            ArrayList uoeList = new ArrayList();
            ArrayList stockList = new ArrayList();
            CustomSerializeArrayList stockDataList = new CustomSerializeArrayList();
            ArrayList paramList = new ArrayList();
            //string enterpriseCode;// DEL pengjie 2013/03/14 REDMINE#34986
            string enterpriseCode = string.Empty; // ADD pengjie 2013/03/14 REDMINE#34986

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList operateHisList = new ArrayList(); // ADD pengjie 2013/03/14 REDMINE#34986

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            ArrayList palamList = List as ArrayList;

            // List�̒��g�̎d����
            foreach (object al in palamList)
            {
                if (al is ArrayList)
                {
                    ArrayList alList = al as ArrayList;
                    
                    // �d���f�[�^���d�����׃f�[�^
                    if (ListUtils.Find(alList, typeof(StockSlipWork), ListUtils.FindType.Class) != null)
                    {
                        stockDataList.Add(alList);
                        continue;
                    }

                    // UOE�����f�[�^
                    if (ListUtils.Find(alList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) != null)
                    {
                        uoeList = alList;
                        continue;
                    }

                    // �d���f�[�^
                    if ((ListUtils.Find(alList, typeof(StockDetailWork), ListUtils.FindType.Class) != null) && (ListUtils.Find(alList, typeof(StockSlipWork), ListUtils.FindType.Class)) == null)
                    {
                        stockList = alList;
                        continue;
                    }
                }
            }
            if (stockDataList.Count == 0 && uoeList.Count == 0 && stockList.Count == 0)
            {
                errmsg += ": List����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^�������Ă��܂���";
                base.WriteErrorLog(errmsg, status);
                return status;
            } 
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (ListUtils.IsNotEmpty(uoeList))
                {
                    // ��ƃR�[�h�擾
                    UOEOrderDtlWork uoeWork = uoeList[0] as UOEOrderDtlWork;

                    enterpriseCode = uoeWork.EnterpriseCode;
                    string sectionCode = uoeWork.SectionCode;  // ADD 2010/06/08

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE�����f�[�^�����J�n
                    operateHisList.Add(UOE_ORDER_SEARCH_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    // UOE�����f�[�^Search
                    // -- UPD 2010/06/08 ------------------------------------>>>
                    //status = this.Search(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode);
                    status = this.Search(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode, sectionCode);
                    // -- UPD 2010/06/08 ------------------------------------<<<

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE�����f�[�^�����I��
                    operateHisList.Add(UOE_ORDER_SEARCH_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    if (ListUtils.IsNotEmpty(uoeOrderDtlList))
                    {
                        // ���������Ă�    
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // UOE�����f�[�^�_���폜
                            // -- UPD 2010/06/08 ------------------------------------>>>
                            //status = this.UOELogicalDelete(ref sqlConnection, ref sqlTransaction);

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // UOE�����f�[�^�_���폜�J�n
                            operateHisList.Add(UOE_ORDER_LOGICALDELETE_BEGIN);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                            UOEOrderDtlDB uoeOrderDtlDB = new UOEOrderDtlDB();
                            uoeOrderDtlDB.LogicalDelete(ref uoeOrderDtlList, 0, ref sqlConnection, ref sqlTransaction);
                            // -- UPD 2010/06/08 ------------------------------------<<<

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // UOE�����f�[�^�_���폜�I��
                            operateHisList.Add(UOE_ORDER_LOGICALDELETE_END);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // �d�����׃f�[�^�폜�J�n
                            operateHisList.Add(STOCKDETAIL_DELETE_BEGIN);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                            // �d�����׃f�[�^�폜
                            status = this.SuppDelete(uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // �d�����׃f�[�^�폜�I��
                            operateHisList.Add(STOCKDETAIL_DELETE_END);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            errmsg += ": �������f�[�^�̍폜�Ɏ��s���܂���";
                            base.WriteErrorLog(errmsg, status);

                            return status;
                        }
                    }

                    // IOWriter�ɐV����List��n�� 
                    ArrayList paraList = new ArrayList();
                    IOWriteCtrlOptWork iOWriterCtrlOptWork = new IOWriteCtrlOptWork();

                    // iOWriterCtrlOptWork�̒ǉ�
                    iOWriterCtrlOptWork.CtrlStartingPoint = 1; //1:�d��
                    iOWriterCtrlOptWork.EnterpriseCode = enterpriseCode;
                    paraList.Add(iOWriterCtrlOptWork);

                    // UOE�����f�[�^List�̒ǉ�
                    ArrayList uoeAl = new ArrayList();
                    uoeAl.Add(uoeList);
                    paraList.Add(uoeAl);
                    
                    // �d�����׃f�[�^�̒ǉ�
                    ArrayList stockAl = new ArrayList();
                    stockAl.Add(stockList);
                    paraList.Add(stockAl);

                    string retMsg = "";
                    string retItemInfo = "";
                    SqlEncryptInfo encryptinfo = null;

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE�����f�[�^�o�^�J�n
                    operateHisList.Add(UOE_ORDER_WRITE_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    status = _iOWriteControlDB.WriteProc(ref paraList, out retMsg, out retItemInfo, ref  sqlConnection, ref sqlTransaction, ref encryptinfo);

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE�����f�[�^�o�^�I��
                    operateHisList.Add(UOE_ORDER_WRITE_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                }

                //�d���f�[�^�E���׃f�[�^
                if (ListUtils.IsNotEmpty(stockDataList))
                {
                    ArrayList paraList = new ArrayList();

                    // �f�[�^�Z�b�g
                    paraList = stockDataList;

                    SqlEncryptInfo sqlEncryptInfo = null;

                    string retString = string.Empty;
                    string retItemInfo = string.Empty;

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    ArrayList subList = paraList[0] as ArrayList;
                    if (subList != null && subList.Count > 0)
                    {
                        // �d���f�[�^
                        StockSlipWork stockSlipWork = ListUtils.Find(subList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                        if (stockSlipWork != null)
                        {
                            // ��ƃR�[�h
                            enterpriseCode = stockSlipWork.EnterpriseCode;
                        }
                    }

                    // �d���f�[�^�E���׃f�[�^�o�^�J�n
                    operateHisList.Add(STOCKSLIP_WRITE_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    // MAKON01824R.StockSlipDB.WriteforSalesOrderPrint��StockDataList��n��
                    status = _stockSlipDB.WriteforSalesOrderPrint(ref paraList, out retString ,out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // �d���f�[�^�E���׃f�[�^�o�^�I��
                    operateHisList.Add(STOCKSLIP_WRITE_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                // ���엚�����O�������ݏ���
                this.WriteOprtnHisLog(sqlConnection, enterpriseCode, operateHisList);
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
             return status;
        }

        # region [Search]
        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.14</br>
        // -- UPD 2010/06/08 -------------------------------------------------------------->>>
        //public int Search(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode)
        public int Search(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,string enterpriseCode, string sectionCode)
        // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        {

            // -- UPD 2010/06/08 -------------------------------------------------------------->>>
            //return SearchProc(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode);
            return SearchProc(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode, sectionCode);
            // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        }

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.14</br>
        // -- UPD 2010/06/08 -------------------------------------------------------------->>>
        //private int SearchProc(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode)
        private int SearchProc(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, string sectionCode)
        // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                // -- ADD 2021/02/15 --------------------------------------------->>>
                // ��UOE�I�v�V��������
                bool optCpmUoeOrderCtl = false;
                try
                {
                    ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    PurchaseStatus ps = loginInfo.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                    if (ps == PurchaseStatus.Contract)
                    {
                        optCpmUoeOrderCtl = true;
                    }
                    else
                    {
                        optCpmUoeOrderCtl = false;
                    }
                }
                catch
                {
                    // �I�v�V�����擾�ł��Ȃ��ꍇ�̓G���[�Ƃ����p��
                }
                finally
                {
                }
                // -- ADD 2021/02/15 ---------------------------------------------<<<

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                // -- UPD 2011/02/24 ---------------------------->>>
                //sqlText += "  *" + Environment.NewLine;
                sqlText += "   ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,UOEKINDRF" + Environment.NewLine;
                sqlText += "  ,ONLINENORF" + Environment.NewLine;
                sqlText += "  ,ONLINEROWNORF" + Environment.NewLine;
                sqlText += "  ,COMMONSEQNORF" + Environment.NewLine;
                sqlText += "  ,SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                // -- UPD 2011/02/24 ----------------------------<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND SYSTEMDIVCDRF = 3" + Environment.NewLine;
                sqlText += " AND DATASENDCODERF = 0" + Environment.NewLine;
                sqlText += " AND DATARECOVERDIVRF = 0" + Environment.NewLine;
                sqlText += " AND LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += " AND SECTIONCODERF = @SECTIONCODERF" + Environment.NewLine;  // ADD 2010/06/08

                // -- ADD 2021/02/15 --------------------------------------------->>>
                if (optCpmUoeOrderCtl)
                {
                    // �ʎ�������������������UOE�����ԍ��̔Ԍ�f�[�^�͘_���폜�f�[�^���o�ΏۊO
                    sqlText += " AND UOESALESORDERNORF = 0" + Environment.NewLine;
                }
                // -- ADD 2021/02/15 ---------------------------------------------<<<

                sqlCommand.CommandText = sqlText;

                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // -- ADD 2010/06/08 --------------------------------------------->>>
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                // -- ADD 2010/06/08 ---------------------------------------------<<<
                # endregion


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    UOEOrderDtlWork wkuoeOrderDtlList = new UOEOrderDtlWork();
                    
                    #region�@�i�[����
                    //�i�[����
                    wkuoeOrderDtlList.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkuoeOrderDtlList.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkuoeOrderDtlList.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkuoeOrderDtlList.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                    wkuoeOrderDtlList.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkuoeOrderDtlList.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                    wkuoeOrderDtlList.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    wkuoeOrderDtlList.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkuoeOrderDtlList.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    #endregion
                    uoeOrderDtlList.Add(wkuoeOrderDtlList);
                }

                if (uoeOrderDtlList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        #region [UOE�����f�[�^LogicalDelete]

        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note       : UOE�����f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N�� ����</br>
        /// <br>Date       : 2008.10.15</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        public int UOELogicalDelete(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.UOELogicalDeleteProc(ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note       : UOE�����f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N�� ����</br>
        /// <br>Date       : 2008.10.15</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 ���� DC.NS�p�ɏC��</br>
        private int UOELogicalDeleteProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            try
            {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    sqlText = "";
                    sqlText += "UPDATE UOEORDERDTLRF" + Environment.NewLine;
                    sqlText += " SET" + Environment.NewLine;
                    sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ANd SYSTEMDIVCDRF = 3" + Environment.NewLine;
                    sqlText += " AND DATASENDCODERF = 0" + Environment.NewLine;
                    sqlText += " AND DATARECOVERDIVRF = 0" + Environment.NewLine;
                    sqlText += " AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)uOEOrderDtlWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEOrderDtlWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.EnterpriseCode);

                    sqlCommand.ExecuteNonQuery();
             
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }        
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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

        #region[�d�����׃f�[�^Delete]
        /// <summary>
        /// �d�����׃f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�d�����׃f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeOrderDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.15</br>
        public int SuppDelete(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SuppDeleteProc(uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �d�����׃f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�d�����׃f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeOrderDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.15</br>
        private int SuppDeleteProc(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlCommand sqlCommand = null;
            string retMsg = "";
            string retItemInfo = "";
            SqlEncryptInfo sqlEncryptInfo = null;
            ArrayList stockDetailList = new ArrayList();
            try
            {

                foreach(UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlList)
                {
                    StockDetailWork stockDetailWork = new StockDetailWork();

                    stockDetailWork.EnterpriseCode = uoeOrderDtlWork.EnterpriseCode;
                    // -- UPD 2010/06/08 ------------------------------------>>>
                    //stockDetailWork.DtlRelationGuid = uoeOrderDtlWork.DtlRelationGuid;
                    stockDetailWork.StockSlipDtlNum = uoeOrderDtlWork.StockSlipDtlNum;
                    stockDetailWork.SupplierFormal = 2;
                    // -- UPD 2010/06/08 ------------------------------------<<<

                    stockDetailList.Add(stockDetailWork);
                }

                IOWriteMASIRDB _iOWriteMASIRDB = new IOWriteMASIRDB();

                status = _iOWriteMASIRDB.DeleteforOrderInput(ref stockDetailList, out retMsg, out retItemInfo,ref sqlConnection, ref sqlTransaction,ref  sqlEncryptInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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
        
        //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
        /// <summary>
        /// ���엚�����O�������ݏ���
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="operateHisList">���엚�����X�g</param>
        /// <br>Note       : ���엚�����O�������ݏ������s���܂��B</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date       : 2013.03.14</br>
        private void WriteOprtnHisLog(SqlConnection sqlConnection, string enterpriseCode, ArrayList operateHisList)
        {
            if (operateHisList != null && operateHisList.Count > 0)
            {
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                
                foreach (string operateHis in operateHisList)
                {
                    switch (operateHis)
                    {
                        // UOE�����f�[�^�����J�n
                        case UOE_ORDER_SEARCH_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "���o�J�n", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE�����f�[�^�����I��
                        case UOE_ORDER_SEARCH_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "���o�I��", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE�����f�[�^�_���폜�J�n
                        case UOE_ORDER_LOGICALDELETE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "�_���폜�J�n", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE�����f�[�^�_���폜�I��
                        case UOE_ORDER_LOGICALDELETE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "�_���폜�I��", "PMHAT02012R", 0);
                                break;
                            }
                        // �d�����׃f�[�^�폜�J�n
                        case STOCKDETAIL_DELETE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "�d�����׃f�[�^", "�폜�J�n", "PMHAT02012R", 0);
                                break;
                            }
                        // �d�����׃f�[�^�폜�I��
                        case STOCKDETAIL_DELETE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "�d�����׃f�[�^", "�폜�I��", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE�����f�[�^�o�^�J�n
                        case UOE_ORDER_WRITE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "�o�^�J�n", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE�����f�[�^�o�^�I��
                        case UOE_ORDER_WRITE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE�����f�[�^", "�o�^�I��", "PMHAT02012R", 0);
                                break;
                            }
                        // �d���f�[�^�E���׃f�[�^�o�^�J�n
                        case STOCKSLIP_WRITE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "�d���f�[�^�E���׃f�[�^", "�o�^�J�n", "PMHAT02012R", 0);
                                break;
                            }
                        // �d���f�[�^�E���׃f�[�^�o�^�I��
                        case STOCKSLIP_WRITE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "�d���f�[�^�E���׃f�[�^", "�o�^�I��", "PMHAT02012R", 0);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
        //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
        #endregion
    }
}

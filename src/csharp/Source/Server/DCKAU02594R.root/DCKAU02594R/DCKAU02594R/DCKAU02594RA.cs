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
    /// �����c������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.07</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.12</br>
    /// <br></br>
    /// <br>Update Note: ���ʃN���X�֍��ڒǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.12.09</br>
    /// </remarks>
    [Serializable]
    public class DemandBalanceLedgerDB : RemoteDB, IDemandBalanceLedgerDB
    {
        /// <summary>
        /// �����c������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        /// <br>Note       : ���ʃN���X�̍��ڒǉ�(�d�l�ύX)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.12.25</br>
        /// </remarks>
        public DemandBalanceLedgerDB()
            :
            base("DCKAU02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandBalanceWork", "CUSTDMDPRCRF")
        {
        }

        #region [SearchDemandBalanceLedger]
        /// <summary>
        /// �w�肳�ꂽ�����̐����c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐����c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        public int SearchDemandBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork = null;

            ArrayList extrInfo_DemandBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_DemandBalanceWorkList == null)
            {
                extrInfo_DemandBalanceWork = paraObj as ExtrInfo_DemandBalanceWork;
            }
            else
            {
                if (extrInfo_DemandBalanceWorkList.Count > 0)
                    extrInfo_DemandBalanceWork = extrInfo_DemandBalanceWorkList[0] as ExtrInfo_DemandBalanceWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //���������z�}�X�^�擾
                status = SearchDemandBalanceLedgerProc(ref retList, extrInfo_DemandBalanceWork, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DemandBalanceLedgerDB.SearchDemandBalanceLedger");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //���Í����L�[CLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̐����c��������߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_DemandBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐����c��������߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        private int SearchDemandBalanceLedgerProc(ref ArrayList retList, ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL��]

                string selectTxt = string.Empty;

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSDMD.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.CLAIMCODERF" + Environment.NewLine;
                // DEL 2008.12.09 >>>
                //selectTxt += " ,CUSDMD.CLAIMNAMERF" + Environment.NewLine;
                //selectTxt += " ,CUSDMD.CLAIMNAME2RF" + Environment.NewLine;
                //selectTxt += " ,CUSDMD.CLAIMSNMRF" + Environment.NewLine;
                // DEL 2008.12.09 <<<
                // ADD 2008.12.09 >>>
                selectTxt += " ,CUST.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                selectTxt += " ,CUST.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUST.CUSTOMERSNMRF AS CLAIMSNMRF" + Environment.NewLine;
                // ADD 2008.12.09 <<<
                selectTxt += " ,CUSDMD.ADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.LASTTIMEDEMANDRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.OFSTHISSALESTAXRF" + Environment.NewLine;
                // ADD 2008.12.25 >>>
                selectTxt += " ,CUSDMD.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.THISSALESTAXRF" + Environment.NewLine;
                // ADD 2008.12.25 <<<
                selectTxt += " ,CUSDMD.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSDMD.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                selectTxt += " ,EMPLO.SHORTNAMERF BILLCOLLECTERNMRF" + Environment.NewLine;
                selectTxt += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                selectTxt += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                // ADD 2008.12.09 >>>
                selectTxt += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                selectTxt += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                // ADD 2008.12.09 <<<
                selectTxt += "FROM CUSTDMDPRCRF AS CUSDMD" + Environment.NewLine;
                selectTxt += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSDMD.ENTERPRISECODERF=CUST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSDMD.CLAIMCODERF=CUST.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUSDMD.ENTERPRISECODERF=SEC.ENTERPRISECODERF" +Environment.NewLine;
                selectTxt += " AND CUSDMD.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMPLO" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     CUST.ENTERPRISECODERF=EMPLO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.BILLCOLLECTERCDRF=EMPLO.EMPLOYEECODERF" + Environment.NewLine;


                #endregion

                //Where��쐬
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_DemandBalanceWork);

                //�v�㋒�_�R�[�h�{������R�[�h�{�����\������ɕ��ёւ���
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "  CUSDMD.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += ", CUSDMD.CLAIMCODERF" + Environment.NewLine;
                selectTxt += ", CUSDMD.ADDUPDATERF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_DemandBalanceFromReader(ref myReader));

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

            return status;
        }

        #endregion

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_DemandBalanceWork">���������i�[�N���X</param>
        /// <returns>�����c���������o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("CUSDMD.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandBalanceWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND CUSDMD.LOGICALDELETECODERF=0 ");

            //�e���R�[�h�݂̂�ΏۂƂ���(���Ӑ�R�[�h=0�̂ݑΏ�)
            retString.Append("AND CUSDMD.CUSTOMERCODERF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_DemandBalanceWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_DemandBalanceWork.SectionCodes)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND CUSDMD.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //������R�[�h
            if (extrInfo_DemandBalanceWork.St_ClaimCode > 0)
            {
                retString.Append("AND CUSDMD.CLAIMCODERF>=@ST_CLAIMCODE ");
                SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
                paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandBalanceWork.St_ClaimCode);
            }
            if (extrInfo_DemandBalanceWork.St_ClaimCode > 0)
            {
                retString.Append("AND CUSDMD.CLAIMCODERF<=@ED_CLAIMCODE ");
                SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
                paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandBalanceWork.Ed_ClaimCode);
            }

            //�Ώ۔N��
            if (extrInfo_DemandBalanceWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSDMD.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_DemandBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_DemandBalanceWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append("AND CUSDMD.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_DemandBalanceWork.Ed_AddUpYearMonth);
            }

            ////0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�
            //switch (extrInfo_DemandBalanceWork.OutMoneyDiv)
            //{
            //    case 0:
            //        {
            //            break;
            //        }
            //    case 1:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF>=0 ");
            //            break;
            //        }
            //    case 2:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF>0 ");
            //            break;
            //        }
            //    case 3:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF=0 ");
            //            break;
            //        }
            //    case 4:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF!=0 ");
            //            break;
            //        }
            //    case 5:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF<=0 ");
            //            break;
            //        }
            //    case 6:
            //        {
            //            retString.Append("AND CUSDMD.AFCALDEMANDPRICERF<0 ");
            //            break;
            //        }
            //}

            return retString.ToString();
        }
        #endregion

        #region [�����c���������o���ʃN���X�i�[����]
        /// <summary>
        /// �����c���������o���ʃN���X�i�[���� Reader �� RsltInfo_DemandBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_DemandBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        /// </remarks>
        private RsltInfo_DemandBalanceWork CopyToRsltInfo_DemandBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_DemandBalanceWork wkRsltInfo_DemandBalanceWork = new RsltInfo_DemandBalanceWork();

            #region �N���X�֊i�[
            wkRsltInfo_DemandBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_DemandBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_DemandBalanceWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_DemandBalanceWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_DemandBalanceWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_DemandBalanceWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_DemandBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_DemandBalanceWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            // ADD 2008.12.25 >>>
            wkRsltInfo_DemandBalanceWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkRsltInfo_DemandBalanceWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            // ADD 2008.12.25 <<<
            wkRsltInfo_DemandBalanceWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkRsltInfo_DemandBalanceWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            wkRsltInfo_DemandBalanceWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkRsltInfo_DemandBalanceWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkRsltInfo_DemandBalanceWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkRsltInfo_DemandBalanceWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkRsltInfo_DemandBalanceWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            wkRsltInfo_DemandBalanceWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkRsltInfo_DemandBalanceWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkRsltInfo_DemandBalanceWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkRsltInfo_DemandBalanceWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            wkRsltInfo_DemandBalanceWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            wkRsltInfo_DemandBalanceWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkRsltInfo_DemandBalanceWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            // ADD 2008.12.09 >>>
            wkRsltInfo_DemandBalanceWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            wkRsltInfo_DemandBalanceWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            // ADD 2008.12.09 <<<
            #endregion

            return wkRsltInfo_DemandBalanceWork;
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
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

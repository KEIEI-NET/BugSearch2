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
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ���яC��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ���яC���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.23</br>
    /// <br></br>
    /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
    /// <br></br>
    /// <br>UpDateNote : 2008.06.02 20081 �D�c �E�l PM.NS�p�ɏC��</br>
    /// </remarks>
    [Serializable]
    public class CustRsltUpdDB : RemoteDB, ICustRsltUpdDB
    {
        /// <summary>
        /// ���Ӑ���яC��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// </remarks>
        public CustRsltUpdDB()
            :
            base("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork", "CUSTDMDPRCRF")
        {
        }

        #region [SearchAccRec ���|���z�}�X�^]
        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retObj">���Ӑ攄�|���z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        public int SearchAccRec(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;
            
            CustomSerializeArrayList retcsaList = new CustomSerializeArrayList();

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���|���z�}�X�^���o
                status = SearchAccRecProc(enterpriseCode, sectionCode, claimCode, customerCode, readMode, ref retcsaList, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.SearchAccRec");
                retObj = new CustomSerializeArrayList();
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

            retObj = retcsaList;

            return status;
        }

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retcsaList">�J�X�^���V���A���C�Y���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchAccRecProc(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList accRecList = new ArrayList();
            ArrayList accRecDepoTotalList = new ArrayList();
            ArrayList retList = new ArrayList();

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTACC.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLDISINNERTAXRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------------------->>
                //selectTxt += " ,CUSTACC.THISPAYOFFSETRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.THISPAYOFFSETTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMINTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMTAXFREERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.PAYMENTOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.PAYMENTINTAXRF" + Environment.NewLine;
                // 2008.06.02 del end ------------------------------------<<
                selectTxt += " ,CUSTACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.MONTHADDUPEXPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.STMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------------------->>
                //selectTxt += " ,CUSTACC.NONSTMNTAPPEARANCERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.NONSTMNTISDONERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.STMNTAPPEARANCERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.STMNTISDONERF" + Environment.NewLine;
                // 2008.06.02 del end ------------------------------------<<
                selectTxt += " ,CUSTACC.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CONSTAXRATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.FRACTIONPROCCDRF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                
                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //�v�㋒�_�R�[�h
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                //�������R�[�h
                if (claimCode > 0)
                {
                    selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
                }

                //���Ӑ�R�[�h�i���Ӑ�R�[�h=�O���W�v���R�[�h�ɂȂ�ׁA�O�̏ꍇ��Where���ΏۂƂ���j
                if (customerCode > 0)
                {
                    selectTxt += " AND (CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE OR CUSTACC.CUSTOMERCODERF=0)" + Environment.NewLine;
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                }
                else
                {
                    selectTxt += " AND CUSTACC.CUSTOMERCODERF=0" + Environment.NewLine;
                }

                selectTxt += "ORDER BY CUSTACC.ADDUPDATERF DESC ,CUSTACC.CUSTOMERCODERF DESC" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                //�v����t�ޔ�p
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {

                    CustAccRecWork wkCustAccRecWork = CopyToCustAccRecWorkFromReader(ref myReader);

                    //�v������ς�����^�C�~���O�Ń��X�g�𐶐�����
                    if (addupDate != DateTime.MinValue && addupDate != wkCustAccRecWork.AddUpDate)
                    {
                        //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                        if (!(customerCode > 0 && accRecList.Count == 1 && (accRecList[0] as CustAccRecWork).CustomerCode == 0))
                        {
                            retList.Add(accRecList); //���|���z�}�X�^�ǉ�

                            SearchAccRecDepoTotalProc(accRecList[0] as CustAccRecWork, ref accRecDepoTotalList);

                            retList.Add(accRecDepoTotalList);  //�����W�v�f�[�^�ǉ�

                            retcsaList.Add(retList);
                        }

                        accRecList = new ArrayList();
                        accRecDepoTotalList = new ArrayList();
                        retList = new ArrayList();
                    }

                    accRecList.Add(wkCustAccRecWork);

                    addupDate = wkCustAccRecWork.AddUpDate; //�v����t�ޔ�

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //�ŏI���R�[�h�̏���
                if (accRecList.Count != 0)
                {
                    //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                    if (!(customerCode > 0 && accRecList.Count == 1 && (accRecList[0] as CustAccRecWork).CustomerCode == 0))
                    {
                        retList.Add(accRecList); //���|���z�}�X�^�ǉ�

                        SearchAccRecDepoTotalProc(accRecList[0] as CustAccRecWork, ref accRecDepoTotalList);

                        retList.Add(accRecDepoTotalList);  //�����W�v�f�[�^�ǉ�

                        retcsaList.Add(retList);
                    }
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

        /// <summary>
        /// ���|�����W�v�f�[�^�Ǎ�
        /// </summary>
        /// <param name="wkCustAccRecWork">���|���z�}�X�^</param>
        /// <param name="retList">���|�����W�v�f�[�^���X�g</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���|�����W�v�f�[�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchAccRecDepoTotalProc(CustAccRecWork wkCustAccRecWork, ref ArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            retList = new ArrayList();
            try
            {

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,DEPOSITRF" + Environment.NewLine;
                selectTxt += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);

                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccRecDepoTotalWork wkAccRecDepoTotalWork = CopyToAccRecDepoTotalWorkFromReader(ref myReader);

                    retList.Add(wkAccRecDepoTotalWork);

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

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }

        #endregion

        #region [SearchDmdPrc �������z�}�X�^]
        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="resultsSectCd">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retObj">���Ӑ搿�����z�}�X�^</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        public int SearchDmdPrc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;

            CustomSerializeArrayList retcsaList = new CustomSerializeArrayList();

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�������z�}�X�^���o
                status = SearchDmdPrcProc(enterpriseCode, sectionCode, claimCode, resultsSectCd, customerCode, readMode, ref retcsaList, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.SearchDmdPrc");
                retObj = new CustomSerializeArrayList();
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

            retObj = retcsaList;
            return status;
        }

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="resultsSectCd">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retcsaList">�J�X�^���V���A���C�Y���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchDmdPrcProc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList dmdPrcList = new ArrayList();
            ArrayList dmdDepoTotalList = new ArrayList();
            ArrayList retList = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTDMD.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.RESULTSSECTCDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LASTTIMEDEMANDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLDISINNERTAXRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------->>
                //selectTxt += " ,CUSTDMD.THISPAYOFFSETRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.THISPAYOFFSETTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMINTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMTAXFREERF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.PAYMENTOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.PAYMENTINTAXRF" + Environment.NewLine;
                // 2008.06.02 del end -----------------------<<
                selectTxt += " ,CUSTDMD.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CADDUPUPDEXECDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.STARTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LASTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.BILLPRINTDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.COLLECTCONDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CONSTAXRATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.FRACTIONPROCCDRF" + Environment.NewLine;
                // ADD 2009/06/18 >>>
                selectTxt += " ,CUSTDMD.BILLNORF" + Environment.NewLine;
                // ADD 2009/06/18 <<<
                selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //�v�㋒�_�R�[�h
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                //������R�[�h
                if (claimCode > 0)
                {
                    selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
                }

                //���ы��_�R�[�h  
                if (customerCode > 0)
                {
                    //�Ώۓ��Ӑ惌�R�[�h�ƏW�v���R�[�h�𒊏o
                    selectTxt += "  AND ((CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE) OR (CUSTDMD.RESULTSSECTCDRF='00' AND CUSTDMD.CUSTOMERCODERF=0))" + Environment.NewLine;
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    paraResultsSectCd.Value = SqlDataMediator.SqlSetString(resultsSectCd);

                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                }
                else
                {
                    //�W�v���R�[�h�̂ݒ��o
                    selectTxt += "  AND (CUSTDMD.RESULTSSECTCDRF='00' AND CUSTDMD.CUSTOMERCODERF=0)" + Environment.NewLine;
                }

                selectTxt += "ORDER BY CUSTDMD.ADDUPDATERF DESC, CUSTDMD.RESULTSSECTCDRF DESC, CUSTDMD.CUSTOMERCODERF DESC" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                //�v����t�ޔ�p
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {
                    CustDmdPrcWork wkCustDmdPrcWork = CopyToCustDmdPrcWorkFromReader(ref myReader);

                    //�v������ς�����^�C�~���O�Ń��X�g�𐶐�����
                    if (addupDate != DateTime.MinValue && addupDate != wkCustDmdPrcWork.AddUpDate)
                    {
                        //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                        if (!(customerCode > 0 && dmdPrcList.Count == 1 && (dmdPrcList[0] as CustDmdPrcWork).CustomerCode == 0))
                        {
                            retList.Add(dmdPrcList); //�������z�}�X�^�ǉ�

                            SearchDmdDepoTotalProc(dmdPrcList[0] as CustDmdPrcWork, ref dmdDepoTotalList);

                            retList.Add(dmdDepoTotalList);  //�����W�v�f�[�^�ǉ�

                            retcsaList.Add(retList);
                        }

                        dmdPrcList = new ArrayList();
                        dmdDepoTotalList = new ArrayList();
                        retList = new ArrayList();
                    }

                    dmdPrcList.Add(wkCustDmdPrcWork);

                    addupDate = wkCustDmdPrcWork.AddUpDate; //�v����t�ޔ�
                        
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //�ŏI���R�[�h�̏���
                if (dmdPrcList.Count != 0)
                {
                    //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                    if (!(customerCode > 0 && dmdPrcList.Count == 1 && (dmdPrcList[0] as CustDmdPrcWork).CustomerCode == 0))
                    {
                        retList.Add(dmdPrcList); //�������z�}�X�^�ǉ�

                        SearchDmdDepoTotalProc(dmdPrcList[0] as CustDmdPrcWork, ref dmdDepoTotalList);

                        retList.Add(dmdDepoTotalList);  //�����W�v�f�[�^�ǉ�

                        retcsaList.Add(retList);
                    }
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

        /// <summary>
        /// ���������W�v�f�[�^�Ǎ�
        /// </summary>
        /// <param name="wkCustDmdPrcWork">�������z�}�X�^</param>
        /// <param name="retList">���������W�v�f�[�^���X�g</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������W�v�f�[�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchDmdDepoTotalProc(CustDmdPrcWork wkCustDmdPrcWork, ref ArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            retList = new ArrayList();
            try
            {

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,DEPOSITRF" + Environment.NewLine;
                selectTxt += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);

                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    DmdDepoTotalWork wkDmdDepoTotalWork = CopyToDmdDepoTotalWorkFromReader(ref myReader);

                    retList.Add(wkDmdDepoTotalWork);

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
               
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }

        #endregion

        #region [WriteAccRec WriteTotalAccRec ���|���z�}�X�^]
        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        public int WriteAccRec(ref object custAccRecWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                CustAccRecWork wkCustAccRecWork = custAccRecWork as CustAccRecWork;
                if (wkCustAccRecWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteAccRecProc(ref wkCustAccRecWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                custAccRecWork = wkCustAccRecWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteAccRec(ref object custAccRecWork)");
                // ���[���o�b�N
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
        /// ���Ӑ攄�|���z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int WriteAccRecProc(ref CustAccRecWork custAccRecWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                if (custAccRecWork != null)
                {
                    string selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    
                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);
                    
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != custAccRecWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (custAccRecWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE CUSTACCRECRF SET" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += ", UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += ", ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMNAMERF=@CLAIMNAME" + Environment.NewLine;
                        selectTxt += ", CLAIMNAME2RF=@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += ", CLAIMSNMRF=@CLAIMSNM" + Environment.NewLine;
                        selectTxt += ", CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAMERF=@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAME2RF=@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += ", CUSTOMERSNMRF=@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += ", ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += ", ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += ", LASTTIMEACCRECRF=@LASTTIMEACCREC" + Environment.NewLine;
                        selectTxt += ", THISTIMEFEEDMDNRMLRF=@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDISDMDNRMLRF=@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDMDNRMLRF=@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMETTLBLCACCRF=@THISTIMETTLBLCACC" + Environment.NewLine;
                        selectTxt += ", OFSTHISTIMESALESRF=@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += ", OFSTHISSALESTAXRF=@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += ", OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", THISTIMESALESRF=@THISTIMESALES" + Environment.NewLine;
                        selectTxt += ", THISSALESTAXRF=@THISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESOUTTAXRF=@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESINTAXRF=@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESTAXFREERF=@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += ", SALESOUTTAXRF=@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", SALESINTAXRF=@SALESINTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICRGDSRF=@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXRGDSRF=@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICDISRF=@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXDISRF=@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start ----------------------------->>
                        //selectTxt += ", THISPAYOFFSETRF=@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += ", THISPAYOFFSETTAXRF=@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMOUTTAXRF=@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMINTAXRF=@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMTAXFREERF=@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += ", PAYMENTOUTTAXRF=@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += ", PAYMENTINTAXRF=@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ------------------------------<<
                        selectTxt += ", TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += ", BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += ", AFCALTMONTHACCRECRF=@AFCALTMONTHACCREC" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL2TMBFACCRECRF=@ACPODRTTL2TMBFACCREC" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL3TMBFACCRECRF=@ACPODRTTL3TMBFACCREC" + Environment.NewLine;
                        selectTxt += ", MONTHADDUPEXPDATERF=@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += ", STMONCADDUPUPDDATERF=@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", LAMONCADDUPUPDDATERF=@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", SALESSLIPCOUNTRF=@SALESSLIPCOUNT" + Environment.NewLine;
                        // 2008.06.02 del start ----------------------------->>
                        //selectTxt += ", NONSTMNTAPPEARANCERF=@NONSTMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += ", NONSTMNTISDONERF=@NONSTMNTISDONE" + Environment.NewLine;
                        //selectTxt += ", STMNTAPPEARANCERF=@STMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += ", STMNTISDONERF=@STMNTISDONE" + Environment.NewLine;
                        // 2008.06.02 del end ------------------------------<<
                        selectTxt += ", CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += ", CONSTAXRATERF=@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += ", FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                        
                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custAccRecWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (custAccRecWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                        
                        //�V�K�쐬����SQL���𐶐�
                        selectTxt = "";
                        selectTxt += "INSERT INTO CUSTACCRECRF" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAMERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CLAIMSNMRF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERCODERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        selectTxt += " ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += " ,LASTTIMEACCRECRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMETTLBLCACCRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,SALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,SALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICDISRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLDISINNERTAXRF" + Environment.NewLine;
                        // 2008.06.02 del start --------------------------->>
                        //selectTxt += " ,THISPAYOFFSETRF" + Environment.NewLine;
                        //selectTxt += " ,THISPAYOFFSETTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMINTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMTAXFREERF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTINTAXRF" + Environment.NewLine;
                        // 2008.06.02 del end -----------------------------<<
                        selectTxt += " ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,AFCALTMONTHACCRECRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                        selectTxt += " ,MONTHADDUPEXPDATERF" + Environment.NewLine;
                        selectTxt += " ,STMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,LAMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        // 2008.06.02 del start --------------------------->>
                        //selectTxt += " ,NONSTMNTAPPEARANCERF" + Environment.NewLine;
                        //selectTxt += " ,NONSTMNTISDONERF" + Environment.NewLine;
                        //selectTxt += " ,STMNTAPPEARANCERF" + Environment.NewLine;
                        //selectTxt += " ,STMNTISDONERF" + Environment.NewLine;
                        // 2008.06.02 del end -----------------------------<<
                        selectTxt += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXRATERF" + Environment.NewLine;
                        selectTxt += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                        selectTxt += ")" + Environment.NewLine;
                        selectTxt += "VALUES" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  @CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += " ,@CLAIMSNM" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += " ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " ,@LASTTIMEACCREC" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMETTLBLCACC" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@THISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@SALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------->>
                        //selectTxt += " ,@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += " ,@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ----------------------------<<
                        selectTxt += " ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += " ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " ,@AFCALTMONTHACCREC" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL2TMBFACCREC" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL3TMBFACCREC" + Environment.NewLine;
                        selectTxt += " ,@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += " ,@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@SALESSLIPCOUNT" + Environment.NewLine;
                        // 2008.06.02 del start ------------------------->>
                        //selectTxt += " ,@NONSTMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += " ,@NONSTMNTISDONE" + Environment.NewLine;
                        //selectTxt += " ,@STMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += " ,@STMNTISDONE" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += " ,@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += ")" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custAccRecWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameter�I�u�W�F�N�g�쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimeAccRec = sqlCommand.Parameters.Add("@LASTTIMEACCREC", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcAcc = sqlCommand.Parameters.Add("@THISTIMETTLBLCACC", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    // 2008.06.02 del start ------------------------->>
                    //SqlParameter paraThisPayOffset = sqlCommand.Parameters.Add("@THISPAYOFFSET", SqlDbType.BigInt);
                    //SqlParameter paraThisPayOffsetTax = sqlCommand.Parameters.Add("@THISPAYOFFSETTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymOutTax = sqlCommand.Parameters.Add("@ITDEDPAYMOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymInTax = sqlCommand.Parameters.Add("@ITDEDPAYMINTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymTaxFree = sqlCommand.Parameters.Add("@ITDEDPAYMTAXFREE", SqlDbType.BigInt);
                    //SqlParameter paraPaymentOutTax = sqlCommand.Parameters.Add("@PAYMENTOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraPaymentInTax = sqlCommand.Parameters.Add("@PAYMENTINTAX", SqlDbType.BigInt);
                    // 2008.06.02 del end ---------------------------<<
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraAfCalTMonthAccRec = sqlCommand.Parameters.Add("@AFCALTMONTHACCREC", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl2TmBfAccRec = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFACCREC", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl3TmBfAccRec = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFACCREC", SqlDbType.BigInt);
                    SqlParameter paraMonthAddUpExpDate = sqlCommand.Parameters.Add("@MONTHADDUPEXPDATE", SqlDbType.Int);
                    SqlParameter paraStMonCAddUpUpdDate = sqlCommand.Parameters.Add("@STMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLaMonCAddUpUpdDate = sqlCommand.Parameters.Add("@LAMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                    // 2008.06.02 del start ------------------------->>
                    //SqlParameter paraNonStmntAppearance = sqlCommand.Parameters.Add("@NONSTMNTAPPEARANCE", SqlDbType.BigInt);
                    //SqlParameter paraNonStmntIsdone = sqlCommand.Parameters.Add("@NONSTMNTISDONE", SqlDbType.BigInt);
                    //SqlParameter paraStmntAppearance = sqlCommand.Parameters.Add("@STMNTAPPEARANCE", SqlDbType.BigInt);
                    //SqlParameter paraStmntIsdone = sqlCommand.Parameters.Add("@STMNTISDONE", SqlDbType.BigInt);
                    // 2008.06.02 del end ---------------------------<<
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custAccRecWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custAccRecWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custAccRecWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimSnm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custAccRecWork.AddUpYearMonth);
                    paraLastTimeAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.LastTimeAccRec);
                    paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeFeeDmdNrml);
                    paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeDisDmdNrml);
                    paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeDmdNrml);
                    paraThisTimeTtlBlcAcc.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeTtlBlcAcc);
                    paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OfsThisTimeSales);
                    paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OfsThisSalesTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OffsetInTax);
                    paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeSales);
                    paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesInTax);
                    paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesTaxFree);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.SalesOutTax);
                    paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.SalesInTax);
                    paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPricRgds);
                    paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlRetInnerTax);
                    paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPricDis);
                    paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlDisInnerTax);
                    // 2008.06.02 del start --------------------------------------->>
                    //paraThisPayOffset.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisPayOffset);
                    //paraThisPayOffsetTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisPayOffsetTax);
                    //paraItdedPaymOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymOutTax);
                    //paraItdedPaymInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymInTax);
                    //paraItdedPaymTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymTaxFree);
                    //paraPaymentOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.PaymentOutTax);
                    //paraPaymentInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.PaymentInTax);
                    // 2008.06.02 del end -----------------------------------------<<
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.BalanceAdjust);
                    paraAfCalTMonthAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AfCalTMonthAccRec);
                    paraAcpOdrTtl2TmBfAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AcpOdrTtl2TmBfAccRec);
                    paraAcpOdrTtl3TmBfAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AcpOdrTtl3TmBfAccRec);
                    paraMonthAddUpExpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.MonthAddUpExpDate);
                    paraStMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.StMonCAddUpUpdDate);
                    paraLaMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.LaMonCAddUpUpdDate);
                    paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.SalesSlipCount);
                    // 2008.06.02 del start --------------------------------------->>
                    //paraNonStmntAppearance.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.NonStmntAppearance);
                    //paraNonStmntIsdone.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.NonStmntIsdone);
                    //paraStmntAppearance.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.StmntAppearance);
                    //paraStmntIsdone.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.StmntIsdone);
                    // 2008.06.02 del end -----------------------------------------<<
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custAccRecWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.FractionProcCd);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�̎q���R�[�h�A�W�v���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�̎q���R�[�h�A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        public int WriteTotalAccRec(ref object custAccRecWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                ArrayList accRecDepoTotalList = null;
                CustAccRecWork wkCustAccRecWork = null;
                CustomSerializeArrayList csaList = custAccRecWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is CustAccRecWork)
                    {
                        //���|���z�}�X�^
                        wkCustAccRecWork = csaList[i] as CustAccRecWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //�����W�v�f�[�^
                            accRecDepoTotalList = csaList[i] as ArrayList;
                        }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //���|���z�}�X�^�X�V
                status = WriteAccRecProc(ref wkCustAccRecWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //�����W�v�f�[�^�X�V(�W�v���R�[�h�̍X�V�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && accRecDepoTotalList != null && wkCustAccRecWork.CustomerCode==0)
                {
                    status = WriteAccRecDepoTotal(ref accRecDepoTotalList, wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
                }
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteAccRec(ref object custAccRecWork)");
                // ���[���o�b�N
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
        /// ���|�����W�v�f�[�^���X�V���܂�
        /// </summary>
        /// <param name="accRecDepoTotalList">���|�����W�v�f�[�^List</param>
        /// <param name="wkCustAccRecWork">���|�����W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���|�����W�v�f�[�^���X�V���܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteAccRecDepoTotal(ref ArrayList accRecDepoTotalList, CustAccRecWork wkCustAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;
            //DELETE�R�}���h�̐���
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < accRecDepoTotalList.Count; i++)
                {
                    AccRecDepoTotalWork accRecDepoTotalWork = accRecDepoTotalList[i] as AccRecDepoTotalWork;

                    #region [Insert���쐬]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO ACCRECDEPOTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "    ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "    ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    #endregion  //[Insert���쐬]

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)accRecDepoTotalWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accRecDepoTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accRecDepoTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(accRecDepoTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.AddUpSecCode);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.ClaimCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.CustomerCode);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(accRecDepoTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.MoneyKindDiv);
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(accRecDepoTotalWork.Deposit);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        #endregion

        #region [WriteDmdPrc WriteTotalDmdPrc �������z�}�X�^]
        /// <summary>
        /// ���Ӑ搿�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        public int WriteDmdPrc(ref object custDmdPrcWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            //string sectionCode; // 2008.06.02 del
            //Int32 dmdProcNum;   // 2008.06.02 del
            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = custDmdPrcWork as CustDmdPrcWork;
                if (wkCustDmdPrcWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
 
                /*
                //�����������ʔԂ̍č̔�
                //�v�㋒�_�R�[�h
                sectionCode = wkCustDmdPrcWork.AddUpSecCode;

                status = CreateDmdProcNumProc(wkCustDmdPrcWork.EnterpriseCode, sectionCode, out dmdProcNum, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdProcNum != 0)
                {
                    wkCustDmdPrcWork.DmdProcNum = dmdProcNum;
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //�ԍ����擾�o���Ȃ������ꍇ�͏I��
                else
                {
                    //���i����̃X�e�[�^�X�y�у��b�Z�[�W�������ꍇ�̓Z�b�g�i���肦�Ȃ����O�̂��߁j
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (retMsg == null || retMsg == "") retMsg = "���������ʔԂ��̔Ԃł��܂���ł����B�ԍ��ݒ���������Ă��������B";
                    return status;
                }
                */

                //��write���s
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                    status = WriteDmdPrcProc(ref wkCustDmdPrcWork, out retMsg, ref sqlConnection, ref sqlTransaction);
                //}

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                custDmdPrcWork = wkCustDmdPrcWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteDmdPrc(ref object custDmdPrcWork)");
                // ���[���o�b�N
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
        /// ���Ӑ搿�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int WriteDmdPrcProc(ref CustDmdPrcWork custDmdPrcWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                string selectTxt = "";

                if (custDmdPrcWork != null)
                {
                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != custDmdPrcWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (custDmdPrcWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE CUSTDMDPRCRF SET" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += ", UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += ", ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMNAMERF=@CLAIMNAME" + Environment.NewLine;
                        selectTxt += ", CLAIMNAME2RF=@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += ", CLAIMSNMRF=@CLAIMSNM" + Environment.NewLine;
                        selectTxt += ", RESULTSSECTCDRF=@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += ", CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAMERF=@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAME2RF=@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += ", CUSTOMERSNMRF=@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += ", ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += ", ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += ", LASTTIMEDEMANDRF=@LASTTIMEDEMAND" + Environment.NewLine;
                        selectTxt += ", THISTIMEFEEDMDNRMLRF=@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDISDMDNRMLRF=@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDMDNRMLRF=@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMETTLBLCDMDRF=@THISTIMETTLBLCDMD" + Environment.NewLine;
                        selectTxt += ", OFSTHISTIMESALESRF=@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += ", OFSTHISSALESTAXRF=@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += ", OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", THISTIMESALESRF=@THISTIMESALES" + Environment.NewLine;
                        selectTxt += ", THISSALESTAXRF=@THISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESOUTTAXRF=@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESINTAXRF=@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESTAXFREERF=@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += ", SALESOUTTAXRF=@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", SALESINTAXRF=@SALESINTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICRGDSRF=@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXRGDSRF=@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICDISRF=@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXDISRF=@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start ------------------------->>
                        //selectTxt += ", THISPAYOFFSETRF=@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += ", THISPAYOFFSETTAXRF=@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMOUTTAXRF=@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMINTAXRF=@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMTAXFREERF=@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += ", PAYMENTOUTTAXRF=@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += ", PAYMENTINTAXRF=@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += ", TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += ", BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += ", AFCALDEMANDPRICERF=@AFCALDEMANDPRICE" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL2TMBFBLDMDRF=@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL3TMBFBLDMDRF=@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        selectTxt += ", CADDUPUPDEXECDATERF=@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += ", STARTCADDUPUPDDATERF=@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", LASTCADDUPUPDDATERF=@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", SALESSLIPCOUNTRF=@SALESSLIPCOUNT" + Environment.NewLine;
                        selectTxt += ", BILLPRINTDATERF=@BILLPRINTDATE" + Environment.NewLine;
                        selectTxt += ", EXPECTEDDEPOSITDATERF=@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        selectTxt += ", COLLECTCONDRF=@COLLECTCOND" + Environment.NewLine;
                        selectTxt += ", CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += ", CONSTAXRATERF=@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += ", FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += ", BILLNORF=@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        selectTxt += " AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                        findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (custDmdPrcWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //�V�K�쐬����SQL���𐶐�
                        selectTxt = "";
                        selectTxt += "INSERT INTO CUSTDMDPRCRF" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAMERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CLAIMSNMRF" + Environment.NewLine;
                        selectTxt += " ,RESULTSSECTCDRF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERCODERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        selectTxt += " ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += " ,LASTTIMEDEMANDRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMETTLBLCDMDRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,SALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,SALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICDISRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLDISINNERTAXRF" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------------->>
                        //selectTxt += " ,THISPAYOFFSETRF" + Environment.NewLine;
                        //selectTxt += " ,THISPAYOFFSETTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMINTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMTAXFREERF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTINTAXRF" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------------<<
                        selectTxt += " ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,AFCALDEMANDPRICERF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                        selectTxt += " ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        selectTxt += " ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        selectTxt += " ,BILLPRINTDATERF" + Environment.NewLine;
                        selectTxt += " ,EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                        selectTxt += " ,COLLECTCONDRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXRATERF" + Environment.NewLine;
                        selectTxt += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += " ,BILLNORF" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += ")" + Environment.NewLine;
                        selectTxt += "VALUES" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  @CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += " ,@CLAIMSNM" + Environment.NewLine;
                        selectTxt += " ,@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += " ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " ,@LASTTIMEDEMAND" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMETTLBLCDMD" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@THISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@SALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------->>
                        //selectTxt += " ,@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += " ,@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += " ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += " ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " ,@AFCALDEMANDPRICE" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        selectTxt += " ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += " ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@SALESSLIPCOUNT" + Environment.NewLine;
                        selectTxt += " ,@BILLPRINTDATE" + Environment.NewLine;
                        selectTxt += " ,@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        selectTxt += " ,@COLLECTCOND" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += " ,@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += " ,@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += ")" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameter�I�u�W�F�N�g�쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimeDemand = sqlCommand.Parameters.Add("@LASTTIMEDEMAND", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcDmd = sqlCommand.Parameters.Add("@THISTIMETTLBLCDMD", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    // 2008.06.02 del start ------------------------------>>
                    //SqlParameter paraThisPayOffset = sqlCommand.Parameters.Add("@THISPAYOFFSET", SqlDbType.BigInt);
                    //SqlParameter paraThisPayOffsetTax = sqlCommand.Parameters.Add("@THISPAYOFFSETTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymOutTax = sqlCommand.Parameters.Add("@ITDEDPAYMOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymInTax = sqlCommand.Parameters.Add("@ITDEDPAYMINTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymTaxFree = sqlCommand.Parameters.Add("@ITDEDPAYMTAXFREE", SqlDbType.BigInt);
                    //SqlParameter paraPaymentOutTax = sqlCommand.Parameters.Add("@PAYMENTOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraPaymentInTax = sqlCommand.Parameters.Add("@PAYMENTINTAX", SqlDbType.BigInt);
                    // 2008.06.02 del end -------------------------------<<
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraAfCalDemandPrice = sqlCommand.Parameters.Add("@AFCALDEMANDPRICE", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl2TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFBLDMD", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl3TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFBLDMD", SqlDbType.BigInt);
                    SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                    SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraBillPrintDate = sqlCommand.Parameters.Add("@BILLPRINTDATE", SqlDbType.Int);
                    SqlParameter paraExpectedDepositDate = sqlCommand.Parameters.Add("@EXPECTEDDEPOSITDATE", SqlDbType.Int);
                    SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    // ADD 2009/06/18 >>>
                    SqlParameter paraBillNo = sqlCommand.Parameters.Add("@BILLNO", SqlDbType.Int);
                    // ADD 2009/06/18 <<<

                    #endregion

                    #region Parameter�I�u�W�F�N�g�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custDmdPrcWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimSnm);
                    paraResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);
                    paraLastTimeDemand.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.LastTimeDemand);
                    paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeFeeDmdNrml);
                    paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDisDmdNrml);
                    paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDmdNrml);
                    paraThisTimeTtlBlcDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeTtlBlcDmd);
                    paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisTimeSales);
                    paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisSalesTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetInTax);
                    paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeSales);
                    paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesInTax);
                    paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesTaxFree);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesOutTax);
                    paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesInTax);
                    paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricRgds);
                    paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetInnerTax);
                    paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricDis);
                    paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisInnerTax);
                    // 2008.06.02 del start ----------------------------->>
                    //paraThisPayOffset.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisPayOffset);
                    //paraThisPayOffsetTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisPayOffsetTax);
                    //paraItdedPaymOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymOutTax);
                    //paraItdedPaymInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymInTax);
                    //paraItdedPaymTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymTaxFree);
                    //paraPaymentOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.PaymentOutTax);
                    //paraPaymentInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.PaymentInTax);
                    // 2008.06.02 del end ------------------------------<<
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.BalanceAdjust);
                    paraAfCalDemandPrice.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AfCalDemandPrice);
                    paraAcpOdrTtl2TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl2TmBfBlDmd);
                    paraAcpOdrTtl3TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl3TmBfBlDmd);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.CAddUpUpdExecDate);
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.StartCAddUpUpdDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                    paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.SalesSlipCount);
                    paraBillPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.BillPrintDate);
                    paraExpectedDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.ExpectedDepositDate);
                    paraCollectCond.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CollectCond);
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custDmdPrcWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.FractionProcCd);
                    // ADD 2009/06/18 >>>
                    paraBillNo.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.BillNo);
                    // ADD 2009/06/18 <<< 
                    #endregion

                    sqlCommand.ExecuteNonQuery();
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br></br>
        public int WriteTotalDmdPrc(ref object custDmdPrcWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            try
            {
                ArrayList dmdDepoTotalList = null;
                CustDmdPrcWork wkCustDmdPrcWork = null;
                CustomSerializeArrayList csaList = custDmdPrcWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is CustDmdPrcWork)
                    {
                        //�������z�}�X�^
                        wkCustDmdPrcWork = csaList[i] as CustDmdPrcWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //�����W�v�f�[�^
                            dmdDepoTotalList = csaList[i] as ArrayList;
                        }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //�������z�}�X�^�̍X�V
                status = WriteDmdPrcProc(ref wkCustDmdPrcWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //�����W�v�f�[�^�̍X�V(�W�v���R�[�h�̏ꍇ�̂ݍX�V)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdDepoTotalList != null && wkCustDmdPrcWork.CustomerCode==0)
                {
                    status = WriteDepoTotalPrc(ref dmdDepoTotalList, wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteDmdPrc(ref object custDmdPrcWork)");
                // ���[���o�b�N
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
        /// ���������W�v�f�[�^���X�V���܂�
        /// </summary>
        /// <param name="dmdDepoTotalList">���������W�v�f�[�^List</param>
        /// <param name="wkCustDmdPrcWork">���������W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������W�v�f�[�^���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteDepoTotalPrc(ref ArrayList dmdDepoTotalList, CustDmdPrcWork wkCustDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            //Delete�R�}���h�̐���
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < dmdDepoTotalList.Count; i++)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = dmdDepoTotalList[i] as DmdDepoTotalWork;

                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDDEPOTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "    ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "    ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    
                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdDepoTotalWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdDepoTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.AddUpSecCode);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.ClaimCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.CustomerCode);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdDepoTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindDiv);
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(dmdDepoTotalWork.Deposit);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [DeleteAccRec ���|���z�}�X�^]
        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteAccRec(object custAccRecWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CustAccRecWork wkCustAccRecWork = custAccRecWork as CustAccRecWork;

                if (wkCustAccRecWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteAccRecProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteAccRec");
                // ���[���o�b�N
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
        /// ���Ӑ攄�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int DeleteAccRecProc(CustAccRecWork custAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != custAccRecWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM CUSTACCRECRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    
                    //�W�v���R�[�h�̍폜�̏ꍇ�́A�q���S�폜���邽�ߓ��Ӑ�������ɓ���Ȃ�
                    if (custAccRecWork.CustomerCode != 0)
                    {
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    }

                    selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        public int DeleteTotalAccRec(object custAccRecWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustAccRecWork wkCustAccRecWork = null;
                //���|���z�}�X�^
                wkCustAccRecWork = (custAccRecWork as CustomSerializeArrayList)[0] as CustAccRecWork;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //���|���z�}�X�^�̍폜
                status = DeleteAccRecProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);

                //���|�����W�v�f�[�^�폜(�W�v���R�[�h�̍폜�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkCustAccRecWork.CustomerCode==0)
                {
                    status = DeleteAccRecDepoTotalProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteAccRec");
                // ���[���o�b�N
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
        /// ���|�����W�v�f�[�^�폜
        /// </summary>
        /// <param name="wkCustAccRecWork">���|�����W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���|�����W�v�f�[�^�폜</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteAccRecDepoTotalProc(CustAccRecWork wkCustAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            return status;
        }

        #endregion

        #region [DeleteDmdPrc �������z�}�X�^]
        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteDmdPrc(object custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = custDmdPrcWork as CustDmdPrcWork;

                if (wkCustDmdPrcWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteDmdPrcProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteDmdPrc");
                // ���[���o�b�N
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
        /// ���Ӑ搿�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int DeleteDmdPrcProc(CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != custDmdPrcWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM CUSTDMDPRCRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    
                    //�W�v���R�[�h�̍폜�̏ꍇ�͎q�̃��R�[�h���S�폜
                    if (custDmdPrcWork.CustomerCode > 0)
                    {
                        selectTxt += " AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    }
                    selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        public int DeleteTotalDmdPrc(object custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = null;

                //�������z�}�X�^
                wkCustDmdPrcWork = (custDmdPrcWork as CustomSerializeArrayList)[0] as CustDmdPrcWork;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //�������z�}�X�^�폜
                status = DeleteDmdPrcProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);

                //���������W�v�f�[�^�폜(�W�v���R�[�h�̍폜�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkCustDmdPrcWork.CustomerCode==0)
                {
                    status = DeleteDmdDepoTotalProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteDmdPrc");
                // ���[���o�b�N
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
        /// ���������W�v�f�[�^�폜
        /// </summary>
        /// <param name="wkCustDmdPrcWork">���������f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������W�v�f�[�^�폜</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteDmdDepoTotalProc(CustDmdPrcWork wkCustDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                String sqlText = String.Empty;
                sqlText = String.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "        AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        #endregion

        #region [���������ʔԂ̎����̔�]
        /// <summary>
        /// ���������ʔԂ������̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="dmdProcNum">���������ʔԂ̍̔Ԍ���</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ʔԂ������̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        private int CreateDmdProcNumProc(string enterpriseCode, string sectionCode, out Int32 dmdProcNum, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            dmdProcNum = 0;
            retMsg = "";

            NumberNumbering numberNumbering = new NumberNumbering();

            //�ԍ��͈͕����[�v
            string firstNo = "";
            Int32 loopCnt = 0;	//�ő僋�[�v�J�E���^
            while (loopCnt <= 999999999)
            {
                string no;
                Int32 ptnCd;
                Int32 noCode;

                //noCode = 1400 �F ���������ʔԂ̍̔�
                noCode = 1400;

                //�ԍ��̔�
                status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out no, out ptnCd, out retMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 wkDmdProcNum = System.Convert.ToInt32(no);
                    //����̔Ԕԍ���ۑ�
                    if (firstNo == "") firstNo = no;
                    //����ԍ��Ɠ���ԍ����̔Ԃ��ꂽ�ꍇ���[�v�J�E���^��Max�ɂ��ďI��
                    else if (firstNo.Equals(no))
                    {
                        loopCnt = 999999999;
                        break;
                    }
                    //���������ʔԑ}��
                    dmdProcNum = wkDmdProcNum;
                }
                //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else break;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "���������ʔԂɋ󂫔ԍ�������܂���B�폜�\�ȓ`�[���폜���Ă��������B";
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustAccRecWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustAccRecWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        private CustAccRecWork CopyToCustAccRecWorkFromReader(ref SqlDataReader myReader)
        {
            CustAccRecWork wkCustAccRecWork = new CustAccRecWork();

            #region �N���X�֊i�[
            wkCustAccRecWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustAccRecWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustAccRecWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustAccRecWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustAccRecWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustAccRecWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustAccRecWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustAccRecWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustAccRecWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkCustAccRecWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkCustAccRecWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustAccRecWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustAccRecWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkCustAccRecWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustAccRecWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkCustAccRecWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkCustAccRecWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustAccRecWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkCustAccRecWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkCustAccRecWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            wkCustAccRecWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            wkCustAccRecWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkCustAccRecWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkCustAccRecWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkCustAccRecWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkCustAccRecWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkCustAccRecWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkCustAccRecWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkCustAccRecWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkCustAccRecWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkCustAccRecWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkCustAccRecWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkCustAccRecWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkCustAccRecWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkCustAccRecWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkCustAccRecWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkCustAccRecWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkCustAccRecWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkCustAccRecWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkCustAccRecWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkCustAccRecWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkCustAccRecWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkCustAccRecWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkCustAccRecWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkCustAccRecWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkCustAccRecWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkCustAccRecWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkCustAccRecWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkCustAccRecWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            // 2008.06.02 del start ---------------------------------->>
            //wkCustAccRecWork.ThisPayOffset = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETRF"));
            //wkCustAccRecWork.ThisPayOffsetTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETTAXRF"));
            //wkCustAccRecWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
            //wkCustAccRecWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
            //wkCustAccRecWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
            //wkCustAccRecWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
            //wkCustAccRecWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
            // 2008.06.02 del end -----------------------------------<<
            wkCustAccRecWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkCustAccRecWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkCustAccRecWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            wkCustAccRecWork.AcpOdrTtl2TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFACCRECRF"));
            wkCustAccRecWork.AcpOdrTtl3TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFACCRECRF"));
            wkCustAccRecWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
            wkCustAccRecWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
            wkCustAccRecWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
            wkCustAccRecWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            // 2008.06.02 del start ---------------------------------->>
            //wkCustAccRecWork.NonStmntAppearance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NONSTMNTAPPEARANCERF"));
            //wkCustAccRecWork.NonStmntIsdone = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NONSTMNTISDONERF"));
            //wkCustAccRecWork.StmntAppearance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STMNTAPPEARANCERF"));
            //wkCustAccRecWork.StmntIsdone = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STMNTISDONERF"));
            // 2008.06.02 del end -----------------------------------<<
            wkCustAccRecWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustAccRecWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkCustAccRecWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkCustAccRecWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustDmdPrcWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustDmdPrcWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        private CustDmdPrcWork CopyToCustDmdPrcWorkFromReader(ref SqlDataReader myReader)
        {
            CustDmdPrcWork wkCustDmdPrcWork = new CustDmdPrcWork();

            #region �N���X�֊i�[
            wkCustDmdPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustDmdPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustDmdPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustDmdPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustDmdPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustDmdPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustDmdPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustDmdPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustDmdPrcWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkCustDmdPrcWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkCustDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkCustDmdPrcWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            wkCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkCustDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkCustDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkCustDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            wkCustDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            wkCustDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkCustDmdPrcWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkCustDmdPrcWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkCustDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkCustDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkCustDmdPrcWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkCustDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkCustDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkCustDmdPrcWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkCustDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkCustDmdPrcWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkCustDmdPrcWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkCustDmdPrcWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkCustDmdPrcWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkCustDmdPrcWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkCustDmdPrcWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            // 2008.06.02 del start --------------------------->>
            //wkCustDmdPrcWork.ThisPayOffset = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETRF"));
            //wkCustDmdPrcWork.ThisPayOffsetTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
            //wkCustDmdPrcWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
            //wkCustDmdPrcWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
            // 2008.06.02 del end -----------------------------<<
            wkCustDmdPrcWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkCustDmdPrcWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkCustDmdPrcWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkCustDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkCustDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkCustDmdPrcWork.BillPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BILLPRINTDATERF"));
            wkCustDmdPrcWork.ExpectedDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTEDDEPOSITDATERF"));
            wkCustDmdPrcWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkCustDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkCustDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            // ADD 2009/06/18 >>>
            wkCustDmdPrcWork.BillNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLNORF"));
            // ADD 2009/06/18 <<<
            #endregion

            return wkCustDmdPrcWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� DmdDepoTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>DmdDepoTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private DmdDepoTotalWork CopyToDmdDepoTotalWorkFromReader(ref SqlDataReader myReader)
        {
            DmdDepoTotalWork wkDmdDepoTotalWork = new DmdDepoTotalWork();

            #region �N���X�֊i�[
            wkDmdDepoTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdDepoTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdDepoTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdDepoTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdDepoTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdDepoTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdDepoTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdDepoTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdDepoTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDmdDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkDmdDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdDepoTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkDmdDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkDmdDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkDmdDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkDmdDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            #endregion

            return wkDmdDepoTotalWork;
        }


        /// <summary>
        /// �N���X�i�[���� Reader �� AccRecDepoTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AccRecDepoTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private AccRecDepoTotalWork CopyToAccRecDepoTotalWorkFromReader(ref SqlDataReader myReader)
        {
            AccRecDepoTotalWork wkAccRecDepoTotalWork = new AccRecDepoTotalWork();

            #region �N���X�֊i�[
            wkAccRecDepoTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAccRecDepoTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAccRecDepoTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccRecDepoTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAccRecDepoTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAccRecDepoTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAccRecDepoTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAccRecDepoTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAccRecDepoTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkAccRecDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkAccRecDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkAccRecDepoTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkAccRecDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccRecDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccRecDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccRecDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            #endregion

            return wkAccRecDepoTotalWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.02.28</br>
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

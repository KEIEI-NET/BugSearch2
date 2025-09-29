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
    /// �d������яC��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d������яC���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.25</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.16 22008 ���� PM.NS�p�ɏC��</br>
    /// </remarks>
    [Serializable]
    public class SuppRsltUpdDB : RemoteDB, ISuppRsltUpdDB
    {
        /// <summary>
        /// �d������яC��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        public SuppRsltUpdDB()
            :
            base("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork", "SUPLIERPAYRF")
        {
        }

        #region [SearchAccPay ���|���z�}�X�^]
        /// <summary>
        /// �d���攃�|���z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retObj">�d���攃�|���z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        public int SearchAccPay(string enterpriseCode, string sectionCode, int payeeCode, int supplierCd, int readMode, out object retObj)
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

                status = SearchAccPayProc(enterpriseCode, sectionCode, payeeCode, supplierCd, readMode, ref retcsaList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppRsltUpdDB.SearchAccPay");
                retObj = new ArrayList();
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
        /// �d���攃�|���z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retcsaList">�J�X�^���V���A���C�Y���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchAccPayProc(string enterpriseCode, string sectionCode, int payeeCode, int supplierCd, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList accPayList = new ArrayList();
            ArrayList aCalcPayTotalList = new ArrayList();
            ArrayList retList = new ArrayList();

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPACCPAY.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.PAYEENAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.PAYEENAME2RF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPLIERNM1RF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPLIERNM2RF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISSTCPRCTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDSTCINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLSTOCKINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.THISSTCPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TTLDISINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.STCKTTL2TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.STCKTTL3TMBFBLACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.MONTHADDUPEXPDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.STMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPCTAXLAYCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                selectTxt += "  ,SUPACCPAY.FRACTIONPROCCDRF" + Environment.NewLine;
                selectTxt += " FROM SUPLACCPAYRF AS SUPACCPAY" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = string.Empty;
                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "  SUPACCPAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //�v�㋒�_�R�[�h
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += "  AND SUPACCPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                //�x����R�[�h
                if (payeeCode > 0)
                {
                    selectTxt += "  AND SUPACCPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(payeeCode);
                }

                //�d����R�[�h�i�d����R�[�h=�O���W�v���R�[�h�ɂȂ�ׁA�O�̏ꍇ��Where���ΏۂƂ���j
                if (supplierCd > 0)
                {
                    selectTxt += " AND (SUPACCPAY.SUPPLIERCDRF=@FINDSUPPLIERCD OR SUPACCPAY.SUPPLIERCDRF=0)" + Environment.NewLine;
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierCd);
                }
                else
                {
                    selectTxt += " AND SUPACCPAY.SUPPLIERCDRF=0" + Environment.NewLine;
                }

                selectTxt += "ORDER BY SUPACCPAY.ADDUPDATERF DESC, SUPACCPAY.SUPPLIERCDRF DESC" + Environment.NewLine;

                sqlCommand.CommandText += selectTxt;

                myReader = sqlCommand.ExecuteReader();

                //�v����t�ޔ�p
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {
                    SuplAccPayWork wkSuplAccPayWork = CopyToSuplAccPayWorkFromReader(ref myReader);

                    //�v������ς�����^�C�~���O�Ń��X�g�𐶐�����
                    if (addupDate != DateTime.MinValue && addupDate != wkSuplAccPayWork.AddUpDate)
                    {
                        //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                        if (!(supplierCd > 0 && accPayList.Count == 1 && (accPayList[0] as SuplAccPayWork).SupplierCd == 0))
                        {
                            retList.Add(accPayList); //���|���z�}�X�^�ǉ�

                            SearchACalcPayTotalProc(accPayList[0] as SuplAccPayWork, ref aCalcPayTotalList);

                            retList.Add(aCalcPayTotalList);  //�x���W�v�f�[�^�ǉ�

                            retcsaList.Add(retList);
                        }

                        accPayList = new ArrayList();
                        aCalcPayTotalList = new ArrayList();
                        retList = new ArrayList();

                    }

                    accPayList.Add(wkSuplAccPayWork);

                    addupDate = wkSuplAccPayWork.AddUpDate; //�v����t�ޔ�

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //�ŏI���R�[�h�̏���
                if (accPayList.Count != 0)
                {
                    //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                    if (!(supplierCd > 0 && accPayList.Count == 1 && (accPayList[0] as SuplAccPayWork).SupplierCd == 0))
                    {
                        retList.Add(accPayList); //���|���z�}�X�^�ǉ�

                        SearchACalcPayTotalProc(accPayList[0] as SuplAccPayWork, ref aCalcPayTotalList);
                            
                        retList.Add(aCalcPayTotalList);  //�x���W�v�f�[�^�ǉ�

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
        /// ���|�x���W�v�f�[�^�Ǎ�
        /// </summary>
        /// <param name="wkSuplAccPayWork">���|���z�}�X�^</param>
        /// <param name="retList">���|�x���W�v�f�[�^���X�g</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���|�x���W�v�f�[�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchACalcPayTotalProc(SuplAccPayWork wkSuplAccPayWork, ref ArrayList retList)
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
                selectTxt += "  ,PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,PAYMENTRF" + Environment.NewLine;
                selectTxt += " FROM ACALCPAYTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.AddUpSecCode);

                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplAccPayWork.PayeeCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplAccPayWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    ACalcPayTotalWork wkACalcPayTotalWork = CopyToACalcPayTotalWorkFromReader(ref myReader);

                    retList.Add(wkACalcPayTotalWork);

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

        #region [SearchSuplierPay �x�����z�}�X�^]
        /// <summary>
        /// �d����x�����z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="resultsSectCd">���ы��_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retObj">�d����x�����z�}�X�^</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        public int SearchSuplierPay(string enterpriseCode, string sectionCode, int payeeCode, string resultsSectCd, int supplierCd, int readMode, out object retObj)
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

                status = SearchSuplierPayProc(enterpriseCode, sectionCode, payeeCode, resultsSectCd, supplierCd, readMode, ref retcsaList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppRsltUpdDB.SearchSuplierPay");
                retObj = new ArrayList();
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
        /// �d����x�����z�}�X�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="resultsSectCd">���ы��_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�Ǎ��敪</param>
        /// <param name="retcsaList">�J�X�^���V���A���C�Y���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchSuplierPayProc(string enterpriseCode, string sectionCode, int payeeCode, string resultsSectCd, int supplierCd, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList supPayList = new ArrayList();
            ArrayList accPayTotalList = new ArrayList();
            ArrayList retList = new ArrayList();

            try
            {
                string selectTxt = "";

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPPAY.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEENAMERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEENAME2RF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.RESULTSSECTCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPLIERNM1RF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPLIERNM2RF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.LASTTIMEPAYMENTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMETTLBLCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISSTCPRCTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDSTCINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLSTOCKINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISSTCPRCTAXDISRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TTLDISINNERTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.CADDUPUPDEXECDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STARTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.LASTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYMENTSCHEDULERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYMENTCONDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPCTAXLAYCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.FRACTIONPROCCDRF" + Environment.NewLine;
                selectTxt += " FROM SUPLIERPAYRF AS SUPPAY" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                
                selectTxt = string.Empty;
                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "  SUPPAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //�v�㋒�_�R�[�h
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += "  AND SUPPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }
                
                //�x����R�[�h
                if (payeeCode > 0)
                {
                    selectTxt += "  AND SUPPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(payeeCode);
                }
              
                //�d����R�[�h  
                if (supplierCd > 0)
                {
                    //�Ώێd���惌�R�[�h�ƏW�v���R�[�h�𒊏o
                    selectTxt += "  AND ((SUPPAY.RESULTSSECTCDRF=@FINDRESULTSSECTCD AND SUPPAY.SUPPLIERCDRF=@FINDSUPPLIERCD) OR (SUPPAY.RESULTSSECTCDRF='00' AND SUPPAY.SUPPLIERCDRF=0))" + Environment.NewLine;
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    paraResultsSectCd.Value = SqlDataMediator.SqlSetString(resultsSectCd);

                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierCd);
                }
                else
                {
                    //�W�v���R�[�h�̂ݒ��o
                    selectTxt += "  AND (SUPPAY.RESULTSSECTCDRF='00' AND SUPPAY.SUPPLIERCDRF=0)" + Environment.NewLine;
                }

                selectTxt += "ORDER BY SUPPAY.ADDUPDATERF DESC, SUPPAY.RESULTSSECTCDRF DESC, SUPPAY.SUPPLIERCDRF DESC" + Environment.NewLine;
                
                sqlCommand.CommandText += selectTxt;
                
                myReader = sqlCommand.ExecuteReader();

                //�v����t�ޔ�p
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {
                    SuplierPayWork wkSuplierPayWork = CopyToSuplierPayWorkFromReader(ref myReader);

                    //�v������ς�����^�C�~���O�Ń��X�g�𐶐�����
                    if (addupDate != DateTime.MinValue && addupDate != wkSuplierPayWork.AddUpDate)
                    {
                        //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                        if (!(supplierCd > 0 && supPayList.Count == 1 && (supPayList[0] as SuplierPayWork).SupplierCd == 0))
                        {
                            retList.Add(supPayList); //���|���z�}�X�^�ǉ�

                            SearchAccPayTotalProc(supPayList[0] as SuplierPayWork, ref accPayTotalList);

                            retList.Add(accPayTotalList);  //�x���W�v�f�[�^�ǉ�

                            retcsaList.Add(retList);
                        }
                        supPayList = new ArrayList();
                        accPayTotalList = new ArrayList();
                        retList = new ArrayList();
                    }

                    supPayList.Add(wkSuplierPayWork);

                    addupDate = wkSuplierPayWork.AddUpDate; //�v����t�ޔ�

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //�ŏI���R�[�h�̏���
                if (supPayList.Count != 0)
                {
                    //�q���R�[�h�̒��o�ŁA�W�v���R�[�h�݂̂P���Y�������ꍇ�͒��o�ΏۂƂ��Ȃ�
                    if (!(supplierCd > 0 && supPayList.Count == 1 && (supPayList[0] as SuplierPayWork).SupplierCd == 0))
                    {
                        retList.Add(supPayList); //���|���z�}�X�^�ǉ�

                        SearchAccPayTotalProc(supPayList[0] as SuplierPayWork, ref accPayTotalList);

                        retList.Add(accPayTotalList);  //�x���W�v�f�[�^�ǉ�

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
        /// ���Z�x���W�v�f�[�^�Ǎ�
        /// </summary>
        /// <param name="wkSuplierPayWork">�x�����z�}�X�^</param>
        /// <param name="retList">���Z�x���W�v�f�[�^���X�g</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Z�x���W�v�f�[�^�Ǎ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int SearchAccPayTotalProc(SuplierPayWork wkSuplierPayWork, ref ArrayList retList)
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
                selectTxt += "  ,PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,PAYMENTRF" + Environment.NewLine;
                selectTxt += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.AddUpSecCode);

                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplierPayWork.PayeeCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplierPayWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccPayTotalWork wkAccPayTotalWork = CopyToAccPayTotalWorkFromReader(ref myReader);

                    retList.Add(wkAccPayTotalWork);

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

        #region [WriteAccPay ���|���z�}�X�^]
        /// <summary>
        /// �d���攃�|���z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        public int WriteAccPay(ref object suplAccPayWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                SuplAccPayWork wkSuplAccPayWork = suplAccPayWork as SuplAccPayWork;
                if (wkSuplAccPayWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteAccPayProc(ref wkSuplAccPayWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                suplAccPayWork = wkSuplAccPayWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppRsltUpdDB.WriteAccPay(ref object suplAccPayWork)");
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
        /// �d���攃�|���z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int WriteAccPayProc(ref SuplAccPayWork suplAccPayWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                string selectTxt = "";

                if (suplAccPayWork != null)
                {
                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  SUPACCPAY.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,SUPACCPAY.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM SUPLACCPAYRF AS SUPACCPAY" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "  AND SUPACCPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += "  AND SUPACCPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    selectTxt += "  AND SUPACCPAY.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    selectTxt += "  AND SUPACCPAY.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = suplAccPayWork.AddUpSecCode;
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != suplAccPayWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (suplAccPayWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE SUPLACCPAYRF SET" + Environment.NewLine;
                        selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " , ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " , PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                        selectTxt += " , PAYEENAMERF=@PAYEENAME" + Environment.NewLine;
                        selectTxt += " , PAYEENAME2RF=@PAYEENAME2" + Environment.NewLine;
                        selectTxt += " , PAYEESNMRF=@PAYEESNM" + Environment.NewLine;
                        selectTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                        selectTxt += " , SUPPLIERNM1RF=@SUPPLIERNM1" + Environment.NewLine;
                        selectTxt += " , SUPPLIERNM2RF=@SUPPLIERNM2" + Environment.NewLine;
                        selectTxt += " , SUPPLIERSNMRF=@SUPPLIERSNM" + Environment.NewLine;
                        selectTxt += " , ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " , ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " , LASTTIMEACCPAYRF=@LASTTIMEACCPAY" + Environment.NewLine;
                        selectTxt += " , THISTIMEFEEPAYNRMLRF=@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMEDISPAYNRMLRF=@THISTIMEDISPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMEPAYNRMLRF=@THISTIMEPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMETTLBLCACPAYRF=@THISTIMETTLBLCACPAY" + Environment.NewLine;
                        selectTxt += " , OFSTHISTIMESTOCKRF=@OFSTHISTIMESTOCK" + Environment.NewLine;
                        selectTxt += " , OFSTHISSTOCKTAXRF=@OFSTHISSTOCKTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " , OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " , OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " , THISTIMESTOCKPRICERF=@THISTIMESTOCKPRICE" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXRF=@THISSTCPRCTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCOUTTAXRF=@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCINTAXRF=@TTLITDEDSTCINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCTAXFREERF=@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLSTOCKOUTERTAXRF=@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLSTOCKINNERTAXRF=@TTLSTOCKINNERTAX" + Environment.NewLine;
                        selectTxt += " , THISSTCKPRICRGDSRF=@THISSTCKPRICRGDS" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXRGDSRF=@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " , THISSTCKPRICDISRF=@THISSTCKPRICDIS" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXDISRF=@THISSTCPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        selectTxt += " , TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += " , BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " , STCKTTLACCPAYBALANCERF=@STCKTTLACCPAYBALANCE" + Environment.NewLine;
                        selectTxt += " , STCKTTL2TMBFBLACCPAYRF=@STCKTTL2TMBFBLACCPAY" + Environment.NewLine;
                        selectTxt += " , STCKTTL3TMBFBLACCPAYRF=@STCKTTL3TMBFBLACCPAY" + Environment.NewLine;
                        selectTxt += " , MONTHADDUPEXPDATERF=@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += " , STMONCADDUPUPDDATERF=@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " , LAMONCADDUPUPDDATERF=@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " , STOCKSLIPCOUNTRF=@STOCKSLIPCOUNT" + Environment.NewLine;
                        selectTxt += " , SUPPCTAXLAYCDRF=@SUPPCTAXLAYCD" + Environment.NewLine;
                        selectTxt += " , SUPPLIERCONSTAXRATERF=@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        selectTxt += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                        selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = suplAccPayWork.AddUpSecCode;
                        findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)suplAccPayWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (suplAccPayWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "INSERT INTO SUPLACCPAYRF" + Environment.NewLine;
                        selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEENAMERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEENAME2RF" + Environment.NewLine;
                        selectTxt += "  ,PAYEESNMRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERNM1RF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERNM2RF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,LASTTIMEACCPAYRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                        selectTxt += "  ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMESTOCKPRICERF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLSTOCKINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCKPRICRGDSRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCKPRICDISRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLDISINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += "  ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += "  ,STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                        selectTxt += "  ,STCKTTL2TMBFBLACCPAYRF" + Environment.NewLine;
                        selectTxt += "  ,STCKTTL3TMBFBLACCPAYRF" + Environment.NewLine;
                        selectTxt += "  ,MONTHADDUPEXPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += "  ,LAMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCKSLIPCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        selectTxt += "  ,FRACTIONPROCCDRF" + Environment.NewLine;
                        selectTxt += " )" + Environment.NewLine;
                        selectTxt += " VALUES" + Environment.NewLine;
                        selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += "  ,@PAYEECODE" + Environment.NewLine;
                        selectTxt += "  ,@PAYEENAME" + Environment.NewLine;
                        selectTxt += "  ,@PAYEENAME2" + Environment.NewLine;
                        selectTxt += "  ,@PAYEESNM" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERNM1" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERNM2" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += "  ,@LASTTIMEACCPAY" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEDISPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMETTLBLCACPAY" + Environment.NewLine;
                        selectTxt += "  ,@OFSTHISTIMESTOCK" + Environment.NewLine;
                        selectTxt += "  ,@OFSTHISSTOCKTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMESTOCKPRICE" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLSTOCKINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCKPRICRGDS" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCKPRICDIS" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAXDIS" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLDISINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += "  ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += "  ,@STCKTTLACCPAYBALANCE" + Environment.NewLine;
                        selectTxt += "  ,@STCKTTL2TMBFBLACCPAY" + Environment.NewLine;
                        selectTxt += "  ,@STCKTTL3TMBFBLACCPAY" + Environment.NewLine;
                        selectTxt += "  ,@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += "  ,@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += "  ,@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += "  ,@STOCKSLIPCOUNT" + Environment.NewLine;
                        selectTxt += "  ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        selectTxt += "  ,@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += " )" + Environment.NewLine;

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = selectTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)suplAccPayWork;
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
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimeAccPay = sqlCommand.Parameters.Add("@LASTTIMEACCPAY", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeePayNrml = sqlCommand.Parameters.Add("@THISTIMEFEEPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisPayNrml = sqlCommand.Parameters.Add("@THISTIMEDISPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimePayNrml = sqlCommand.Parameters.Add("@THISTIMEPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcAcPay = sqlCommand.Parameters.Add("@THISTIMETTLBLCACPAY", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeStock = sqlCommand.Parameters.Add("@OFSTHISTIMESTOCK", SqlDbType.BigInt);
                    SqlParameter paraOfsThisStockTax = sqlCommand.Parameters.Add("@OFSTHISSTOCKTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeStockPrice = sqlCommand.Parameters.Add("@THISTIMESTOCKPRICE", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTax = sqlCommand.Parameters.Add("@THISSTCPRCTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlStockOuterTax = sqlCommand.Parameters.Add("@TTLSTOCKOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlStockInnerTax = sqlCommand.Parameters.Add("@TTLSTOCKINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisStckPricRgds = sqlCommand.Parameters.Add("@THISSTCKPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTaxRgds = sqlCommand.Parameters.Add("@THISSTCPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisStckPricDis = sqlCommand.Parameters.Add("@THISSTCKPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTaxDis = sqlCommand.Parameters.Add("@THISSTCPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraStckTtlAccPayBalance = sqlCommand.Parameters.Add("@STCKTTLACCPAYBALANCE", SqlDbType.BigInt);
                    SqlParameter paraStckTtl2TmBfBlAccPay = sqlCommand.Parameters.Add("@STCKTTL2TMBFBLACCPAY", SqlDbType.BigInt);
                    SqlParameter paraStckTtl3TmBfBlAccPay = sqlCommand.Parameters.Add("@STCKTTL3TMBFBLACCPAY", SqlDbType.BigInt);
                    SqlParameter paraMonthAddUpExpDate = sqlCommand.Parameters.Add("@MONTHADDUPEXPDATE", SqlDbType.Int);
                    SqlParameter paraStMonCAddUpUpdDate = sqlCommand.Parameters.Add("@STMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLaMonCAddUpUpdDate = sqlCommand.Parameters.Add("@LAMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraStockSlipCount = sqlCommand.Parameters.Add("@STOCKSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                    SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplAccPayWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplAccPayWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(suplAccPayWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(suplAccPayWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(suplAccPayWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = suplAccPayWork.AddUpSecCode;
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(suplAccPayWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(suplAccPayWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(suplAccPayWork.PayeeSnm);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(suplAccPayWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(suplAccPayWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(suplAccPayWork.SupplierSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(suplAccPayWork.AddUpYearMonth);
                    paraLastTimeAccPay.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.LastTimeAccPay);
                    paraThisTimeFeePayNrml.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisTimeFeePayNrml);
                    paraThisTimeDisPayNrml.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisTimeDisPayNrml);
                    paraThisTimePayNrml.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisTimePayNrml);
                    paraThisTimeTtlBlcAcPay.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisTimeTtlBlcAcPay);
                    paraOfsThisTimeStock.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.OfsThisTimeStock);
                    paraOfsThisStockTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.OfsThisStockTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.OffsetInTax);
                    paraThisTimeStockPrice.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisTimeStockPrice);
                    paraThisStcPrcTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisStcPrcTax);
                    paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedStcOutTax);
                    paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedStcInTax);
                    paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedStcTaxFree);
                    paraTtlStockOuterTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlStockOuterTax);
                    paraTtlStockInnerTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlStockInnerTax);
                    paraThisStckPricRgds.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisStckPricRgds);
                    paraThisStcPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisStcPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlRetInnerTax);
                    paraThisStckPricDis.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisStckPricDis);
                    paraThisStcPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.ThisStcPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TtlDisInnerTax);
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.BalanceAdjust);
                    paraStckTtlAccPayBalance.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.StckTtlAccPayBalance);
                    paraStckTtl2TmBfBlAccPay.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.StckTtl2TmBfBlAccPay);
                    paraStckTtl3TmBfBlAccPay.Value = SqlDataMediator.SqlSetInt64(suplAccPayWork.StckTtl3TmBfBlAccPay);
                    paraMonthAddUpExpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.MonthAddUpExpDate);
                    paraStMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.StMonCAddUpUpdDate);
                    paraLaMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.LaMonCAddUpUpdDate);
                    paraStockSlipCount.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.StockSlipCount);
                    paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SuppCTaxLayCd);
                    paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(suplAccPayWork.SupplierConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.FractionProcCd);
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
        /// �d���攃�|���z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�̎q���R�[�h�A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        public int WriteTotalAccPay(ref object suplAccPayWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                ArrayList aCalcPayTotalList = null;
                SuplAccPayWork wkSuplAccPayWork = null;
                CustomSerializeArrayList csaList = suplAccPayWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is SuplAccPayWork)
                    {
                        //���|���z�}�X�^
                        wkSuplAccPayWork = csaList[i] as SuplAccPayWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //�x���W�v�f�[�^
                            aCalcPayTotalList = csaList[i] as ArrayList;
                        }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //���|���z�}�X�^�X�V
                status = WriteAccPayProc(ref wkSuplAccPayWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //�x���W�v�f�[�^�X�V(�W�v���R�[�h�̍X�V�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && aCalcPayTotalList != null && wkSuplAccPayWork.SupplierCd == 0)
                {
                    status = WriteACalcPayTotal(ref aCalcPayTotalList, wkSuplAccPayWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.WriteAccPay(ref object suplAccPayWork)");
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
        /// ���|�x���W�v�f�[�^���X�V���܂�
        /// </summary>
        /// <param name="aCalcPayTotalList">���|�x���W�v�f�[�^List</param>
        /// <param name="wkSuplAccPayWork">���|�x���W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���|�x���W�v�f�[�^���X�V���܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteACalcPayTotal(ref ArrayList aCalcPayTotalList, SuplAccPayWork wkSuplAccPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;
            //DELETE�R�}���h�̐���
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACALCPAYTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplAccPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplAccPayWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < aCalcPayTotalList.Count; i++)
                {
                    ACalcPayTotalWork aCalcPayTotalWork = aCalcPayTotalList[i] as ACalcPayTotalWork;

                    #region [Insert���쐬]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO ACALCPAYTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "  ,PAYEECODERF" + Environment.NewLine;
                    sqlText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "  ,PAYMENTRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  ,@PAYEECODE" + Environment.NewLine;
                    sqlText += "  ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += "  ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "  ,@PAYMENT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    #endregion  //[Insert���쐬]

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)aCalcPayTotalWork;
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
                        SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(aCalcPayTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(aCalcPayTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(aCalcPayTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(aCalcPayTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.AddUpSecCode);
                        paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(aCalcPayTotalWork.PayeeCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(aCalcPayTotalWork.SupplierCd);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(aCalcPayTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(aCalcPayTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(aCalcPayTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(aCalcPayTotalWork.MoneyKindDiv);
                        paraPayment.Value = SqlDataMediator.SqlSetInt64(aCalcPayTotalWork.Payment);
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

        #region [WriteSuplierPay �x�����z�}�X�^]
        /// <summary>
        /// �d����x�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        public int WriteSuplierPay(ref object suplierPayWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            try
            {
                SuplierPayWork wkSuplierPayWork = suplierPayWork as SuplierPayWork;
                if (wkSuplierPayWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = WriteSuplierPayProc(ref wkSuplierPayWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                suplierPayWork = wkSuplierPayWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppRsltUpdDB.WriteSuplierPay(ref object suplierPayWork)");
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
        /// �d����x�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^���X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int WriteSuplierPayProc(ref SuplierPayWork suplierPayWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                string selectTxt = "";

                if (suplierPayWork != null)
                {
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  SUPPAY.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,SUPPAY.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM SUPLIERPAYRF AS SUPPAY" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "  AND SUPPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += "  AND SUPPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    selectTxt += "  AND SUPPAY.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                    selectTxt += "  AND SUPPAY.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = suplierPayWork.AddUpSecCode;
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    findParaResultsSectCd.Value = suplierPayWork.ResultsSectCd;
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != suplierPayWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (suplierPayWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE SUPLIERPAYRF SET" + Environment.NewLine;
                        selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " , ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " , PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                        selectTxt += " , PAYEENAMERF=@PAYEENAME" + Environment.NewLine;
                        selectTxt += " , PAYEENAME2RF=@PAYEENAME2" + Environment.NewLine;
                        selectTxt += " , PAYEESNMRF=@PAYEESNM" + Environment.NewLine;
                        selectTxt += " , RESULTSSECTCDRF=@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                        selectTxt += " , SUPPLIERNM1RF=@SUPPLIERNM1" + Environment.NewLine;
                        selectTxt += " , SUPPLIERNM2RF=@SUPPLIERNM2" + Environment.NewLine;
                        selectTxt += " , SUPPLIERSNMRF=@SUPPLIERSNM" + Environment.NewLine;
                        selectTxt += " , ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " , ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " , LASTTIMEPAYMENTRF=@LASTTIMEPAYMENT" + Environment.NewLine;
                        selectTxt += " , THISTIMEFEEPAYNRMLRF=@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMEDISPAYNRMLRF=@THISTIMEDISPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMEPAYNRMLRF=@THISTIMEPAYNRML" + Environment.NewLine;
                        selectTxt += " , THISTIMETTLBLCPAYRF=@THISTIMETTLBLCPAY" + Environment.NewLine;
                        selectTxt += " , OFSTHISTIMESTOCKRF=@OFSTHISTIMESTOCK" + Environment.NewLine;
                        selectTxt += " , OFSTHISSTOCKTAXRF=@OFSTHISSTOCKTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " , ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " , OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " , OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " , THISTIMESTOCKPRICERF=@THISTIMESTOCKPRICE" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXRF=@THISSTCPRCTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCOUTTAXRF=@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCINTAXRF=@TTLITDEDSTCINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDSTCTAXFREERF=@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLSTOCKOUTERTAXRF=@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLSTOCKINNERTAXRF=@TTLSTOCKINNERTAX" + Environment.NewLine;
                        selectTxt += " , THISSTCKPRICRGDSRF=@THISSTCKPRICRGDS" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXRGDSRF=@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " , THISSTCKPRICDISRF=@THISSTCKPRICDIS" + Environment.NewLine;
                        selectTxt += " , THISSTCPRCTAXDISRF=@THISSTCPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " , TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " , TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " , TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        selectTxt += " , TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += " , BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " , STOCKTOTALPAYBALANCERF=@STOCKTOTALPAYBALANCE" + Environment.NewLine;
                        selectTxt += " , STOCKTTL2TMBFBLPAYRF=@STOCKTTL2TMBFBLPAY" + Environment.NewLine;
                        selectTxt += " , STOCKTTL3TMBFBLPAYRF=@STOCKTTL3TMBFBLPAY" + Environment.NewLine;
                        selectTxt += " , CADDUPUPDEXECDATERF=@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += " , STARTCADDUPUPDDATERF=@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " , LASTCADDUPUPDDATERF=@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " , STOCKSLIPCOUNTRF=@STOCKSLIPCOUNT" + Environment.NewLine;
                        selectTxt += " , PAYMENTSCHEDULERF=@PAYMENTSCHEDULE" + Environment.NewLine;
                        selectTxt += " , PAYMENTCONDRF=@PAYMENTCOND" + Environment.NewLine;
                        selectTxt += " , SUPPCTAXLAYCDRF=@SUPPCTAXLAYCD" + Environment.NewLine;
                        selectTxt += " , SUPPLIERCONSTAXRATERF=@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        selectTxt += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                        selectTxt += "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                        selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = suplierPayWork.AddUpSecCode;
                        findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                        findParaResultsSectCd.Value = suplierPayWork.ResultsSectCd;
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)suplierPayWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (suplierPayWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //�V�K�쐬����SQL���𐶐�
                        selectTxt = "";
                        selectTxt += "INSERT INTO SUPLIERPAYRF" + Environment.NewLine;
                        selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEENAMERF" + Environment.NewLine;
                        selectTxt += "  ,PAYEENAME2RF" + Environment.NewLine;
                        selectTxt += "  ,PAYEESNMRF" + Environment.NewLine;
                        selectTxt += "  ,RESULTSSECTCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERNM1RF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERNM2RF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMEPAYNRMLRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMETTLBLCPAYRF" + Environment.NewLine;
                        selectTxt += "  ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISTIMESTOCKPRICERF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLSTOCKINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCKPRICRGDSRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCKPRICDISRF" + Environment.NewLine;
                        selectTxt += "  ,THISSTCPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += "  ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TTLDISINNERTAXRF" + Environment.NewLine;
                        selectTxt += "  ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += "  ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                        selectTxt += "  ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                        selectTxt += "  ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                        selectTxt += "  ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        selectTxt += "  ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += "  ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCKSLIPCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,PAYMENTSCHEDULERF" + Environment.NewLine;
                        selectTxt += "  ,PAYMENTCONDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        selectTxt += "  ,FRACTIONPROCCDRF" + Environment.NewLine;
                        selectTxt += " )" + Environment.NewLine;
                        selectTxt += " VALUES" + Environment.NewLine;
                        selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += "  ,@PAYEECODE" + Environment.NewLine;
                        selectTxt += "  ,@PAYEENAME" + Environment.NewLine;
                        selectTxt += "  ,@PAYEENAME2" + Environment.NewLine;
                        selectTxt += "  ,@PAYEESNM" + Environment.NewLine;
                        selectTxt += "  ,@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERNM1" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERNM2" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += "  ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += "  ,@LASTTIMEPAYMENT" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEDISPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMEPAYNRML" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMETTLBLCPAY" + Environment.NewLine;
                        selectTxt += "  ,@OFSTHISTIMESTOCK" + Environment.NewLine;
                        selectTxt += "  ,@OFSTHISSTOCKTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISTIMESTOCKPRICE" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLSTOCKINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCKPRICRGDS" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCKPRICDIS" + Environment.NewLine;
                        selectTxt += "  ,@THISSTCPRCTAXDIS" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += "  ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TTLDISINNERTAX" + Environment.NewLine;
                        selectTxt += "  ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += "  ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += "  ,@STOCKTOTALPAYBALANCE" + Environment.NewLine;
                        selectTxt += "  ,@STOCKTTL2TMBFBLPAY" + Environment.NewLine;
                        selectTxt += "  ,@STOCKTTL3TMBFBLPAY" + Environment.NewLine;
                        selectTxt += "  ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += "  ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += "  ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += "  ,@STOCKSLIPCOUNT" + Environment.NewLine;
                        selectTxt += "  ,@PAYMENTSCHEDULE" + Environment.NewLine;
                        selectTxt += "  ,@PAYMENTCOND" + Environment.NewLine;
                        selectTxt += "  ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        selectTxt += "  ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        selectTxt += "  ,@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += " )" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)suplierPayWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

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
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimePayment = sqlCommand.Parameters.Add("@LASTTIMEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeePayNrml = sqlCommand.Parameters.Add("@THISTIMEFEEPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisPayNrml = sqlCommand.Parameters.Add("@THISTIMEDISPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimePayNrml = sqlCommand.Parameters.Add("@THISTIMEPAYNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcPay = sqlCommand.Parameters.Add("@THISTIMETTLBLCPAY", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeStock = sqlCommand.Parameters.Add("@OFSTHISTIMESTOCK", SqlDbType.BigInt);
                    SqlParameter paraOfsThisStockTax = sqlCommand.Parameters.Add("@OFSTHISSTOCKTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeStockPrice = sqlCommand.Parameters.Add("@THISTIMESTOCKPRICE", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTax = sqlCommand.Parameters.Add("@THISSTCPRCTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlStockOuterTax = sqlCommand.Parameters.Add("@TTLSTOCKOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlStockInnerTax = sqlCommand.Parameters.Add("@TTLSTOCKINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisStckPricRgds = sqlCommand.Parameters.Add("@THISSTCKPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTaxRgds = sqlCommand.Parameters.Add("@THISSTCPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisStckPricDis = sqlCommand.Parameters.Add("@THISSTCKPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisStcPrcTaxDis = sqlCommand.Parameters.Add("@THISSTCPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraStockTotalPayBalance = sqlCommand.Parameters.Add("@STOCKTOTALPAYBALANCE", SqlDbType.BigInt);
                    SqlParameter paraStockTtl2TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL2TMBFBLPAY", SqlDbType.BigInt);
                    SqlParameter paraStockTtl3TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL3TMBFBLPAY", SqlDbType.BigInt);
                    SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                    SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraStockSlipCount = sqlCommand.Parameters.Add("@STOCKSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
                    SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
                    SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                    SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(suplierPayWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = suplierPayWork.AddUpSecCode;
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeSnm);
                    paraResultsSectCd.Value = suplierPayWork.ResultsSectCd;
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(suplierPayWork.AddUpYearMonth);
                    paraLastTimePayment.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.LastTimePayment);
                    paraThisTimeFeePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeFeePayNrml);
                    paraThisTimeDisPayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeDisPayNrml);
                    paraThisTimePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimePayNrml);
                    paraThisTimeTtlBlcPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeTtlBlcPay);
                    paraOfsThisTimeStock.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisTimeStock);
                    paraOfsThisStockTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisStockTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetInTax);
                    paraThisTimeStockPrice.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeStockPrice);
                    paraThisStcPrcTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTax);
                    paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcOutTax);
                    paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcInTax);
                    paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcTaxFree);
                    paraTtlStockOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockOuterTax);
                    paraTtlStockInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockInnerTax);
                    paraThisStckPricRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricRgds);
                    paraThisStcPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetInnerTax);
                    paraThisStckPricDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricDis);
                    paraThisStcPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisInnerTax);
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.BalanceAdjust);
                    paraStockTotalPayBalance.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTotalPayBalance);
                    paraStockTtl2TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl2TmBfBlPay);
                    paraStockTtl3TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl3TmBfBlPay);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.CAddUpUpdExecDate);
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.StartCAddUpUpdDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                    paraStockSlipCount.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.StockSlipCount);
                    paraPaymentSchedule.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.PaymentSchedule);
                    paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PaymentCond);
                    paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SuppCTaxLayCd);
                    paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(suplierPayWork.SupplierConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.FractionProcCd);
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
        /// �d����x�����z�}�X�^���X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        /// <br></br>
        public int WriteTotalSuplierPay(ref object suplierPayWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            try
            {
                ArrayList accPayTotalList = null;
                SuplierPayWork wkSuplierPayWork = null;
                CustomSerializeArrayList csaList = suplierPayWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is SuplierPayWork)
                    {
                        //�x�����z�}�X�^
                        wkSuplierPayWork = csaList[i] as SuplierPayWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //�x���W�v�f�[�^
                            accPayTotalList = csaList[i] as ArrayList;
                        }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //�x�����z�}�X�^�X�V
                status = WriteSuplierPayProc(ref wkSuplierPayWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //�x���W�v�f�[�^�̍X�V(�W�v���R�[�h�̏ꍇ�̂ݍX�V)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && accPayTotalList != null && wkSuplierPayWork.SupplierCd == 0)
                {
                    status = WriteAccPayTotal(ref accPayTotalList, wkSuplierPayWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.WriteSuplierPay(ref object suplierPayWork)");
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
        /// ���Z�x���W�v�f�[�^���X�V���܂�
        /// </summary>
        /// <param name="accPayTotalList">���Z�x���W�v�f�[�^List</param>
        /// <param name="wkSuplierPayWork">���Z�x���W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Z�x���W�v�f�[�^���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteAccPayTotal(ref ArrayList accPayTotalList, SuplierPayWork wkSuplierPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            //Delete�R�}���h�̐���
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplierPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplierPayWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < accPayTotalList.Count; i++)
                {
                    AccPayTotalWork accPayTotalWork = accPayTotalList[i] as AccPayTotalWork;

                    sqlText = string.Empty;
                    sqlText += "INSERT INTO ACCPAYTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "  ,PAYEECODERF" + Environment.NewLine;
                    sqlText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "  ,PAYMENTRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  ,@PAYEECODE" + Environment.NewLine;
                    sqlText += "  ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += "  ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "  ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "  ,@PAYMENT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)accPayTotalWork;
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
                        SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accPayTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accPayTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(accPayTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.AddUpSecCode);
                        paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.PayeeCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.SupplierCd);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(accPayTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(accPayTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.MoneyKindDiv);
                        paraPayment.Value = SqlDataMediator.SqlSetInt64(accPayTotalWork.Payment);
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

        #region [DeleteAccPay ���|���z�}�X�^]
        /// <summary>
        /// �d���攃�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteAccPay(object suplAccPayWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            try
            {
                SuplAccPayWork wkSuplAccPayWork = suplAccPayWork as SuplAccPayWork;

                if (wkSuplAccPayWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteAccPayProc(wkSuplAccPayWork, ref sqlConnection, ref sqlTransaction);
                
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.DeleteAccPay");
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
        /// �d���攃�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int DeleteAccPayProc(SuplAccPayWork suplAccPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPACCPAY.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,SUPACCPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM SUPLACCPAYRF AS SUPACCPAY" + Environment.NewLine;
                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND SUPACCPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND SUPACCPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND SUPACCPAY.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND SUPACCPAY.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                findParaAddUpSecCode.Value = suplAccPayWork.AddUpSecCode;
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != suplAccPayWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM SUPLACCPAYRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = suplAccPayWork.AddUpSecCode;
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);
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
        /// �d���攃�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        public int DeleteTotalAccPay(object suplAccPayWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            try
            {
                SuplAccPayWork wkSuplAccPayWork = null;
                wkSuplAccPayWork = (suplAccPayWork as CustomSerializeArrayList)[0] as SuplAccPayWork;

                if (wkSuplAccPayWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                status = DeleteAccPayProc(wkSuplAccPayWork, ref sqlConnection, ref sqlTransaction);

                //�x���W�v�f�[�^�폜(�W�v���R�[�h�̍폜�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkSuplAccPayWork.SupplierCd == 0)
                {
                    status = DeleteACalcPayTotalProc(wkSuplAccPayWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.DeleteAccPay");
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
        /// ���|�x���W�v�f�[�^�폜
        /// </summary>
        /// <param name="wkSuplAccPayWork">���|�x���W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���|�x���W�v�f�[�^�폜</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteACalcPayTotalProc(SuplAccPayWork wkSuplAccPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACALCPAYTOTALRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                sqlText += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplAccPayWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplAccPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplAccPayWork.AddUpDate);

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

        #region [DeleteSuplierPay �x�����z�}�X�^]
        /// <summary>
        /// �d����x�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteSuplierPay(object suplierPayWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SuplierPayWork wkSuplierPayWork = suplierPayWork as SuplierPayWork;

                if (wkSuplierPayWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSuplierPayProc(wkSuplierPayWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.DeleteSuplierPay");
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
        /// �d����x�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        private int DeleteSuplierPayProc(SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPPAY.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,SUPPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM SUPLIERPAYRF AS SUPPAY" + Environment.NewLine;
                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND SUPPAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND SUPPAY.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND SUPPAY.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                selectTxt += "  AND SUPPAY.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND SUPPAY.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                findParaAddUpSecCode.Value = suplierPayWork.AddUpSecCode;
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                findParaResultsSectCd.Value = suplierPayWork.ResultsSectCd;
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != suplierPayWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM SUPLIERPAYRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    selectTxt += "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = suplierPayWork.AddUpSecCode;
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    findParaResultsSectCd.Value = suplierPayWork.ResultsSectCd;
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
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
        /// �d����x�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        public int DeleteTotalSuplierPay(object suplierPayWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            try
            {
                SuplierPayWork wkSuplierPayWork = null;

                //�x�����z�}�X�^
                wkSuplierPayWork = (suplierPayWork as CustomSerializeArrayList)[0] as SuplierPayWork;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                status = DeleteSuplierPayProc(wkSuplierPayWork, ref sqlConnection, ref sqlTransaction);

                //�x�������W�v�f�[�^�폜(�W�v���R�[�h�̍폜�̏ꍇ�̂�)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkSuplierPayWork.SupplierCd == 0)
                {
                    status = DeleteAccPayTotalProc(wkSuplierPayWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SuppRsltUpdDB.DeleteSuplierPay");
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
        /// ���Z�x���W�v�f�[�^�폜
        /// </summary>
        /// <param name="wkSuplierPayWork">���Z�x���W�v�f�[�^�폜�p�p�����[�^</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Z�x���W�v�f�[�^�폜</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteAccPayTotalProc(SuplierPayWork wkSuplierPayWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                String sqlText = String.Empty;
                sqlText = String.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "        AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkSuplierPayWork.AddUpSecCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(wkSuplierPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkSuplierPayWork.AddUpDate);

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

        #region [���Z�����ʔԂ̎����̔�]
        /*
        /// <summary>
        /// ���Z�����ʔԂ������̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="supProcNum">���Z�����ʔԂ̍̔Ԍ���</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Z�����ʔԂ������̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        private int CreateSupProcNumProc(string enterpriseCode, string sectionCode, out Int32 supProcNum, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            supProcNum = 0;
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

                //noCode = 1500 �F ���Z�����ʔԂ̍̔�
                noCode = 1500;

                //�ԍ��̔�
                status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out no, out ptnCd, out retMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 wkSupProcNum = System.Convert.ToInt32(no);
                    //����̔Ԕԍ���ۑ�
                    if (firstNo == "") firstNo = no;
                    //����ԍ��Ɠ���ԍ����̔Ԃ��ꂽ�ꍇ���[�v�J�E���^��Max�ɂ��ďI��
                    else if (firstNo.Equals(no))
                    {
                        loopCnt = 999999999;
                        break;
                    }
                    //���Z�����ʔԑ}��
                    supProcNum = wkSupProcNum;
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
                retMsg = "���Z�����ʔԂɋ󂫔ԍ�������܂���B�폜�\�ȓ`�[���폜���Ă��������B";
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }
        */ 
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuplAccPayWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>    
        /// <returns>SuplAccPayWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        private SuplAccPayWork CopyToSuplAccPayWorkFromReader(ref SqlDataReader myReader)
        {
            SuplAccPayWork wkSuplAccPayWork = new SuplAccPayWork();

            #region �N���X�֊i�[
            wkSuplAccPayWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSuplAccPayWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSuplAccPayWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSuplAccPayWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSuplAccPayWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSuplAccPayWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSuplAccPayWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSuplAccPayWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSuplAccPayWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkSuplAccPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkSuplAccPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkSuplAccPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkSuplAccPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkSuplAccPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkSuplAccPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkSuplAccPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkSuplAccPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkSuplAccPayWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkSuplAccPayWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkSuplAccPayWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            wkSuplAccPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkSuplAccPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkSuplAccPayWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkSuplAccPayWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            wkSuplAccPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkSuplAccPayWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkSuplAccPayWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkSuplAccPayWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkSuplAccPayWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkSuplAccPayWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkSuplAccPayWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkSuplAccPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkSuplAccPayWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));
            wkSuplAccPayWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
            wkSuplAccPayWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
            wkSuplAccPayWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            wkSuplAccPayWork.TtlStockOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF"));
            wkSuplAccPayWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
            wkSuplAccPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkSuplAccPayWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            wkSuplAccPayWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkSuplAccPayWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkSuplAccPayWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkSuplAccPayWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkSuplAccPayWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkSuplAccPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkSuplAccPayWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            wkSuplAccPayWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkSuplAccPayWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkSuplAccPayWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkSuplAccPayWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkSuplAccPayWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            wkSuplAccPayWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkSuplAccPayWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkSuplAccPayWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            wkSuplAccPayWork.StckTtl2TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL2TMBFBLACCPAYRF"));
            wkSuplAccPayWork.StckTtl3TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL3TMBFBLACCPAYRF"));
            wkSuplAccPayWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
            wkSuplAccPayWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
            wkSuplAccPayWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
            wkSuplAccPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkSuplAccPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkSuplAccPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            wkSuplAccPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkSuplAccPayWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SuplierPayWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SuplierPayWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        private SuplierPayWork CopyToSuplierPayWorkFromReader(ref SqlDataReader myReader)
        {
            SuplierPayWork wkSuplierPayWork = new SuplierPayWork();

            #region �N���X�֊i�[
            wkSuplierPayWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSuplierPayWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSuplierPayWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSuplierPayWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSuplierPayWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSuplierPayWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSuplierPayWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSuplierPayWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSuplierPayWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkSuplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkSuplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkSuplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkSuplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkSuplierPayWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            wkSuplierPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkSuplierPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkSuplierPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkSuplierPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkSuplierPayWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkSuplierPayWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkSuplierPayWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            wkSuplierPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkSuplierPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkSuplierPayWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkSuplierPayWork.ThisTimeTtlBlcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCPAYRF"));
            wkSuplierPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkSuplierPayWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkSuplierPayWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkSuplierPayWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkSuplierPayWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkSuplierPayWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkSuplierPayWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkSuplierPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkSuplierPayWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));
            wkSuplierPayWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
            wkSuplierPayWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
            wkSuplierPayWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            wkSuplierPayWork.TtlStockOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF"));
            wkSuplierPayWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
            wkSuplierPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkSuplierPayWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            wkSuplierPayWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkSuplierPayWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkSuplierPayWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkSuplierPayWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkSuplierPayWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkSuplierPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkSuplierPayWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            wkSuplierPayWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkSuplierPayWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkSuplierPayWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkSuplierPayWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkSuplierPayWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            wkSuplierPayWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkSuplierPayWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkSuplierPayWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            wkSuplierPayWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            wkSuplierPayWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            wkSuplierPayWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkSuplierPayWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkSuplierPayWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkSuplierPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkSuplierPayWork.PaymentSchedule = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTSCHEDULERF"));
            wkSuplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkSuplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkSuplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            wkSuplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkSuplierPayWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� AccPayTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AccPayTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private AccPayTotalWork CopyToAccPayTotalWorkFromReader(ref SqlDataReader myReader)
        {
            AccPayTotalWork wkAccPayTotalWork = new AccPayTotalWork();

            #region �N���X�֊i�[
            wkAccPayTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAccPayTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAccPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccPayTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAccPayTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAccPayTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAccPayTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAccPayTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAccPayTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkAccPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkAccPayTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkAccPayTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkAccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            #endregion

            return wkAccPayTotalWork;
        }


        /// <summary>
        /// �N���X�i�[���� Reader �� ACalcPayTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ACalcPayTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private ACalcPayTotalWork CopyToACalcPayTotalWorkFromReader(ref SqlDataReader myReader)
        {
            ACalcPayTotalWork wkACalcPayTotalWork = new ACalcPayTotalWork();

            #region �N���X�֊i�[
            wkACalcPayTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkACalcPayTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkACalcPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkACalcPayTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkACalcPayTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkACalcPayTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkACalcPayTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkACalcPayTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkACalcPayTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkACalcPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkACalcPayTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkACalcPayTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkACalcPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkACalcPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkACalcPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkACalcPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            #endregion

            return wkACalcPayTotalWork;
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

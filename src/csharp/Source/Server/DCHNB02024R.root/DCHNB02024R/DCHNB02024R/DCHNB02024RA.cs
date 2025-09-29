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
    /// �󒍏o�׊m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍏o�׊m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081�@�R�c ���F</br>
    /// <br>Date       : 2007.10.19</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2007.10.19</br>
    /// <br>           : DC�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 20081</br>
    /// <br>Date       : 2008.07.04</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.28</br>
    /// <br>           : ���o���ʃN���X���ڒǉ�</br>
    /// <br></br>
    /// <br>Update Note: 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>           : ���q���̒��o�s��C��</br>
    /// <br></br>
    /// <br>Update Note: 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.27</br>
    /// <br>           : ���t�̒��o�s��C��</br>
    /// <br></br>
    /// <br>Update Note: 23012 ���� �[���N</br>
    /// <br>Date       : 2009.01.23</br>
    /// <br>           : ���ڒǉ�</br>
    /// <br>Update Note: caohh</br>
    /// <br>Date       : 2011/08/11</br>
    /// <br>           : Redmine#23472�Ή�</br>
    /// <br>Update Note: ����</br>
    /// <br>Date       : 2011/12/02</br>
    /// <br>           : Redmine#8316�Ή�</br>
    /// <br>Update Note: �Ǘ��ԍ� : 10904597-00 �쐬�S�� : �{�{ ����</br>
    /// <br>           : �C�����e : �����艿�󎚑Ή��̏�Q�Ή�</br>
    /// <br>Date       : 2014/04/17</br>
    /// </remarks>
    [Serializable]
    public class OrderConfDB : RemoteDB, IOrderConfDB
    {
        /// <summary>
        /// �󒍏o�׊m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081�@�R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public OrderConfDB()
            :
            base("DCHNB02026D", "Broadleaf.Application.Remoting.ParamData.OrderConfWork", "ORDERCONFRF")
        {
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍏o�׊m�F�\(���v)LIST��߂��܂�
        /// </summary>
        /// <param name="orderConfWork">��������</param>
        /// <param name="paraOrderConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍏o�׊m�F�\(���v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        public int SearchSlip(out object orderConfWork, object paraOrderConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            orderConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchOrderConfProc(out orderConfWork, paraOrderConfWork, ref sqlConnection, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderConfDB.SearchSlip");
                orderConfWork = new ArrayList();
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
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍏o�׊m�F�\(����)LIST��߂��܂�
        /// </summary>
        /// <param name="orderConfWork">��������</param>
        /// <param name="paraOrderConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍏o�׊m�F�\(����)LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        public int SearchDetail(out object orderConfWork, object paraOrderConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            orderConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchOrderConfProc(out orderConfWork, paraOrderConfWork, ref sqlConnection, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderConfDB.SearchDetail");
                orderConfWork = new ArrayList();
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
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍏o�׊m�F�\LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objOrderConfWork">��������</param>
        /// <param name="paraOrderConfWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍏o�׊m�F�\LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        public int SearchOrderConfProc(out object objOrderConfWork, object paraOrderConfWork, ref SqlConnection sqlConnection, int printMode)
        {
            OrderConfShWork orderConfShWork = null;

            ArrayList orderConfShWorkList = paraOrderConfWork as ArrayList;
            ArrayList orderConfWorkList = new ArrayList();

            if (orderConfShWorkList == null)
            {
                orderConfShWork = paraOrderConfWork as OrderConfShWork;
            }
            else
            {
                if (orderConfShWorkList.Count > 0)
                    orderConfShWork = orderConfShWorkList[0] as OrderConfShWork;
            }

            int status = SearchOrderConfProc(out orderConfWorkList, orderConfShWork, ref sqlConnection, printMode);
            objOrderConfWork = orderConfWorkList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍏o�׊m�F�\(���v)LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="orderConfWorkList">��������</param>
        /// <param name="orderConfShWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍏o�׊m�F�\(���v)LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        public int SearchOrderConfProc(out ArrayList orderConfWorkList, OrderConfShWork orderConfShWork, ref SqlConnection sqlConnection, int printMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, orderConfShWork, printMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToOrderConfWorkFromReader(ref myReader, orderConfShWork, printMode));

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

            orderConfWorkList = al;

            return status;
        }

        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="orderConfShWork">���������i�[�N���X</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>�󒍏o�׊m�F�\��SQL������</returns>
        /// <br>Note       : �󒍏o�׊m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, OrderConfShWork orderConfShWork, int printMode)
        {
            #region Select��
            string sqlString = string.Empty;
            if (printMode == 0)
            {
                sqlString += "SELECT DISTINCT" + Environment.NewLine;
                sqlString += "     A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEECODERF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEENAMERF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEENAME2RF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESGOODSCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.DELAYPAYMENTDIVRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine; // ADD caohh 2011/08/11
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                // ADD 2008.10.28 <<<
                // ADD 2009.01.23 >>>
                sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                sqlString += "    ,SUM(CASE WHEN B.SALESSLIPCDDTLRF = 2 THEN B.COSTRF ELSE 0 END) AS DISCOSTRF" + Environment.NewLine;
                sqlString += "    ,SUM(B.ACPTANODRREMAINCNTRF) AS ACPTANODRREMAINCNTRF" + Environment.NewLine;
                sqlString += "    ,SUM(B.ACCEPTANORDERCNTRF) AS ACCEPTANORDERCNTRF" + Environment.NewLine;
                sqlString += "    ,SUM(B.ACPTANODRADJUSTCNTRF) AS ACPTANODRADJUSTCNTRF" + Environment.NewLine;
�@              // ADD 2009.01.23 <<<
                //add 2011/12/02 ���� Redmine #8316----->>>>>
                sqlString += "    ,B.SALESUNITCOSTRF" + Environment.NewLine;
                sqlString += "    ,B.FILEHEADERGUIDRF" + Environment.NewLine;
                //add 2011/12/02 ���� Redmine #8316-----<<<<<
                sqlString += " FROM SALESSLIPRF A" + Environment.NewLine;
                sqlString += " INNER JOIN SALESDETAILRF B ON" + Environment.NewLine;
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                sqlString += " LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += " ) " + Environment.NewLine;
                sqlString += " LEFT JOIN SUBSECTIONRF D ON" + Environment.NewLine;
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
            }
            else if (printMode == 1)
            {
                //sqlString += "SELECT " + Environment.NewLine; // DEL 2008.10.29
                sqlString += "SELECT DISTINCT" + Environment.NewLine; // ADD 2008.10.29 
                sqlString += "     A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEECODERF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEENAMERF" + Environment.NewLine;
                sqlString += "    ,A.ADDRESSEENAME2RF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESGOODSCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.DELAYPAYMENTDIVRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,B.SALESROWNORF" + Environment.NewLine;
                sqlString += "    ,B.SALESSLIPCDDTLRF" + Environment.NewLine;
                sqlString += "    ,B.GOODSMAKERCDRF" + Environment.NewLine;
                sqlString += "    ,B.MAKERNAMERF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNORF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNAMERF" + Environment.NewLine;
                sqlString += "    ,B.SHIPMENTCNTRF" + Environment.NewLine;
                sqlString += "    ,B.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXINCRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNITCOSTRF" + Environment.NewLine;
                sqlString += "    ,B.COSTRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERCDRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERSNMRF" + Environment.NewLine;
                sqlString += "    ,B.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                sqlString += "    ,B.DTLNOTERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSECODERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSENAMERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlString += "    ,B.SALESCODERF" + Environment.NewLine;
                sqlString += "    ,B.SALESCDNMRF" + Environment.NewLine;
                sqlString += "    ,E.MODELFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,E.FULLMODELRF" + Environment.NewLine;
                sqlString += "    ,E.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlString += "    ,E.CATEGORYNORF" + Environment.NewLine;
                sqlString += "    ,E.CARMNGCODERF" + Environment.NewLine;
                sqlString += "    ,E.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSCODERF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,B.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,B.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                sqlString += "    ,F.SUPPLIERSLIPNORF" + Environment.NewLine;
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,B.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlString += "    ,B.LISTPRICETAXEXCFLRF" + Environment.NewLine;�@// ADD 2008.11.27
                sqlString += "    ,B.ACPTANODRREMAINCNTRF" + Environment.NewLine;�@// ADD 2008.11.27
                // ADD 2008.10.28 <<<
                // ADD 2009.01.23 >>>
                sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                // ADD 2009.01.23 <<<
                sqlString += "    ,B.ACCEPTANORDERCNTRF" + Environment.NewLine;
                sqlString += "    ,B.ACPTANODRADJUSTCNTRF" + Environment.NewLine;
                sqlString += " FROM SALESSLIPRF A" + Environment.NewLine;
                sqlString += " INNER JOIN SALESDETAILRF B ON" + Environment.NewLine;
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                sqlString += " LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += " ) " + Environment.NewLine;
                sqlString += " LEFT JOIN SUBSECTIONRF D ON" + Environment.NewLine;
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                // DEL 2008.11.25 >>>
                //sqlString += " LEFT JOIN ACCEPTODRCARRF E ON" + Environment.NewLine;
                //sqlString += " (E.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF" + Environment.NewLine;
                //sqlString += "    AND E.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF" + Environment.NewLine;
                //sqlString += " )" + Environment.NewLine;
                // DEL 2008.11.25 <<<
                // ADD 2008.11.25 >>>
                sqlString += " LEFT JOIN ACCEPTODRCARRF E ON (" + Environment.NewLine;
                sqlString += "B.ENTERPRISECODERF=E.ENTERPRISECODERF  " + Environment.NewLine;
                sqlString += "AND B.ACCEPTANORDERNORF=E.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlString += "AND (" + Environment.NewLine;
                sqlString += "      (B.ACPTANODRSTATUSRF = 10 AND E.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 20 AND E.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 30 AND E.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 40 AND E.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
                sqlString += "    )" + Environment.NewLine;
                sqlString += ")" + Environment.NewLine;
                // ADD 2008.11.25 <<<

                sqlString += " LEFT JOIN STOCKDETAILRF F ON" + Environment.NewLine;
                sqlString += " (F.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND F.SUPPLIERFORMALRF = B.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                sqlString += "    AND F.STOCKSLIPDTLNUMRF = B.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
            }
            #endregion

            #region Where��
            sqlString += "WHERE ";

            //��ƃR�[�h
            sqlString += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(orderConfShWork.EnterpriseCode);

            //�_���폜�敪
            sqlString += "AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.LogicalDeleteCode);

            //���ьv�㋒�_�R�[�h
            //if (orderConfShWork.IsSelectAllSection == false && orderConfShWork.IsOutputAllSecRec == false)
            //{
            string sectionString = "";
            foreach (string sectionCode in orderConfShWork.ResultsAddUpSecList)
            {
                if (sectionCode != "")
                {
                    if (sectionString != "") sectionString += ",";
                    sectionString += "'" + sectionCode + "'";
                }
            }
            if (sectionString != "")
            {
                sqlString += "AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ") ";
            }
            //}

            //�󒍃X�e�[�^�X
            if (orderConfShWork.AcptAnOdrStatus != 0)
            {
                sqlString += "AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUS ";
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.AcptAnOdrStatus);
            }

            //������t(�J�n)
            if (orderConfShWork.SalesDateSt != 0)
            {
                sqlString += "AND A.SALESDATERF>=@SALESDATEST ";
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.SalesDateSt);
            }

            //������t(�I��)
            if (orderConfShWork.SalesDateEd != 0)
            {
                sqlString += "AND A.SALESDATERF<=@SALESDATEED ";
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.SalesDateEd);
            }

            //�o�ד��t(�J�n)
            if (orderConfShWork.ShipmentDaySt != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF>=@SHIPMENTDAYST ";
                SqlParameter paraShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                paraShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.ShipmentDaySt);
            }

            //�o�ד��t(�I��)
            if (orderConfShWork.ShipmentDayEd != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF<=@SHIPMENTDAYED ";
                SqlParameter paraShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                paraShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.ShipmentDayEd);
            }

            //���͓��t(�J�n)
            if (orderConfShWork.SearchSlipDateSt != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF>=@SEARCHSLIPDATEST ";
                SqlParameter paraSearchSlipDateSt = sqlCommand.Parameters.Add("@SEARCHSLIPDATEST", SqlDbType.Int);
                paraSearchSlipDateSt.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.SearchSlipDateSt);
            }

            //���͓��t(�I��)
            if (orderConfShWork.SearchSlipDateEd != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF<=@SEARCHSLIPDATEED ";
                SqlParameter paraSearchSlipDateEd = sqlCommand.Parameters.Add("@SEARCHSLIPDATEED", SqlDbType.Int);
                paraSearchSlipDateEd.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.SearchSlipDateEd);
            }

            //�ԓ`�敪
            if (orderConfShWork.DebitNoteDiv != -1)
            {
                sqlString += "AND A.DEBITNOTEDIVRF=@DEBITNOTEDIV ";
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.DebitNoteDiv);
            }

            //����`�[�敪
            if (orderConfShWork.SalesSlipCd != -1)
            {
                sqlString += "AND A.SALESSLIPCDRF=@SALESSLIPCD ";
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.SalesSlipCd);
            }

            //���Ӑ�R�[�h(�J�n)
            if (orderConfShWork.CustomerCodeSt != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF>=@CUSTOMERCODEST ";
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.CustomerCodeSt);
            }

            //���Ӑ�R�[�h(�I��)
            if (orderConfShWork.CustomerCodeEd != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF<=@CUSTOMERCODEED ";
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(orderConfShWork.CustomerCodeEd);
            }
            
            //����`�[�ԍ�(�J�n)
            if (orderConfShWork.SalesSlipNumSt != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST ";
                SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesSlipNumSt);
            }

            //����`�[�ԍ�(�I��)
            if (orderConfShWork.SalesSlipNumEd != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED ";
                SqlParameter paraSalesSlipNumStEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraSalesSlipNumStEd.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesSlipNumEd);
            }

            //�̔��]�ƈ��R�[�h(�J�n)
            if (orderConfShWork.SalesEmployeeCdSt != "")
            {
                sqlString += "AND A.SALESEMPLOYEECDRF>=@SALESEMPLOYEECDST ";
                SqlParameter paraSalesEmployeeCdSt = sqlCommand.Parameters.Add("@SALESEMPLOYEECDST", SqlDbType.NVarChar);
                paraSalesEmployeeCdSt.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesEmployeeCdSt);
            }

            //�̔��]�ƈ��R�[�h(�I��)
            if (orderConfShWork.SalesEmployeeCdEd != "")
            {
                sqlString += "AND A.SALESEMPLOYEECDRF<=@SALESEMPLOYEECDED ";
                SqlParameter paraSalesEmployeeCdEd = sqlCommand.Parameters.Add("@SALESEMPLOYEECDED", SqlDbType.NVarChar);
                paraSalesEmployeeCdEd.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesEmployeeCdEd);
            }

            //��t�]�ƈ��R�[�h(�J�n)
            if (orderConfShWork.FrontEmployeeCdSt != "")
            {
                sqlString += "AND A.FRONTEMPLOYEECDRF>=@FRONTEMPLOYEECDST ";
                SqlParameter paraFrontEmployeeCdSt = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDST", SqlDbType.NVarChar);
                paraFrontEmployeeCdSt.Value = SqlDataMediator.SqlSetString(orderConfShWork.FrontEmployeeCdSt);
            }

            //��t�]�ƈ��R�[�h(�I��)
            if (orderConfShWork.FrontEmployeeCdEd != "")
            {
                sqlString += "AND A.FRONTEMPLOYEECDRF<=@FRONTEMPLOYEECDED ";
                SqlParameter paraFrontEmployeeCdEd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDED", SqlDbType.NVarChar);
                paraFrontEmployeeCdEd.Value = SqlDataMediator.SqlSetString(orderConfShWork.FrontEmployeeCdEd);
            }

            //���͒S���҃R�[�h(�J�n)
            if (orderConfShWork.SalesInputCodeSt != "")
            {
                sqlString += "AND A.SALESINPUTCODERF>=@SALESINPUTCODEST ";
                SqlParameter paraSalesInputCodeSt = sqlCommand.Parameters.Add("@SALESINPUTCODEST", SqlDbType.NVarChar);
                paraSalesInputCodeSt.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesInputCodeSt);
            }

            //���͒S���҃R�[�h(�I��)
            if (orderConfShWork.SalesInputCodeEd != "")
            {
                sqlString += "AND A.SALESINPUTCODERF<=@SALESINPUTCODEED ";
                SqlParameter paraSalesInputCodeEd = sqlCommand.Parameters.Add("@SALESINPUTCODEED", SqlDbType.NVarChar);
                paraSalesInputCodeEd.Value = SqlDataMediator.SqlSetString(orderConfShWork.SalesInputCodeEd);
            }

            //// 2008.07.04 add start ----------------------------------->>
            ////���s�^�C�v
            //if ((orderConfShWork.PrintDiv == 1) || (orderConfShWork.PrintDiv == 3) || (orderConfShWork.PrintDiv == 5))
            //{
            //    sqlString += "AND B.ACPTANODRREMAINCNTRF=0 ";
            //}
            //// 2008.07.04 add end -------------------------------------<<

            if (printMode == 1)
            {
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------>>>>>
                ////�ꎮ�f�[�^(�ꎮ���הԍ�=0)
                //sqlString += "AND B.CMPLTSALESROWNORF=0 ";
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------<<<<<

                ////�Z�b�g�q(�Z�b�g���i�敪=2)�͏���
                //sqlString +=  "AND B.GOODSSETDIVCDRF<=1 ";
            }
            #endregion

            // ADD 2009.01.23 >>>
            if (printMode == 0)
            {
                #region GROUP BY
                sqlString += "GROUP BY" + Environment.NewLine;
                sqlString += " A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlString += " ,C.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += " ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += " ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += " ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += " ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += " ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += " ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += " ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += " ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += " ,A.ADDRESSEECODERF" + Environment.NewLine;
                sqlString += " ,A.ADDRESSEENAMERF" + Environment.NewLine;
                sqlString += " ,A.ADDRESSEENAME2RF" + Environment.NewLine;
                sqlString += " ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += " ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += " ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += " ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += " ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += " ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += " ,A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += " ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += " ,A.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlString += " ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += " ,A.SALESGOODSCDRF" + Environment.NewLine;
                sqlString += " ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += " ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                sqlString += " ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += " ,A.SALESDATERF" + Environment.NewLine;
                sqlString += " ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += " ,A.DELAYPAYMENTDIVRF" + Environment.NewLine;
                sqlString += " ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlString += " ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += " ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += " ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += " ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                sqlString += " ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += " ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += " ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += " ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += " ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += " ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += " ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine; // ADD caohh 2011/08/11
                sqlString += " ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += " ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += " ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += " ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                //add 2011/12/02 ���� Redmine #8316----->>>>>
                sqlString += " ,B.SALESUNITCOSTRF" + Environment.NewLine;
                sqlString += " ,B.FILEHEADERGUIDRF" + Environment.NewLine;
                //add 2011/12/02 ���� Redmine #8316-----<<<<<
                #endregion
            }
            // ADD 2009.01.23 <<<

            #region Order By��
            sqlString += "ORDER BY A.SALESSLIPNUMRF ";
            if (printMode == 1)
            {
                sqlString += ", B.SALESROWNORF ";
            }

            #endregion

            return sqlString;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� OrderConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="orderConfShWork">�����p�����[�^</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>OrderConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private OrderConfWork CopyToOrderConfWorkFromReader(ref SqlDataReader myReader, OrderConfShWork orderConfShWork, int printMode)
        {
            OrderConfWork wkOrderConfWork = new OrderConfWork();

            #region �N���X�֊i�[
            //�`�[���v
            wkOrderConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            wkOrderConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkOrderConfWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkOrderConfWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            wkOrderConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkOrderConfWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkOrderConfWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkOrderConfWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkOrderConfWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkOrderConfWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkOrderConfWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            wkOrderConfWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            wkOrderConfWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            wkOrderConfWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            wkOrderConfWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            wkOrderConfWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            wkOrderConfWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            wkOrderConfWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            wkOrderConfWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            wkOrderConfWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            wkOrderConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkOrderConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkOrderConfWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            wkOrderConfWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            wkOrderConfWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkOrderConfWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            wkOrderConfWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            wkOrderConfWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkOrderConfWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkOrderConfWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            wkOrderConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkOrderConfWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            wkOrderConfWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            wkOrderConfWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            wkOrderConfWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            wkOrderConfWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            wkOrderConfWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            wkOrderConfWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            wkOrderConfWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            wkOrderConfWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkOrderConfWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkOrderConfWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF")); // ADD caohh 2011/08/11
            // ADD 2008.10.28 >>>
            wkOrderConfWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkOrderConfWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            wkOrderConfWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            // ADD 2008.10.28 <<<
            // ADD 2009.01.23 >>>
            wkOrderConfWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            if (printMode == 0)
            {
                wkOrderConfWork.DisCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOSTRF"));
            }
            wkOrderConfWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
            wkOrderConfWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
            wkOrderConfWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
            // ADD 2009.01.23 <<<
            wkOrderConfWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));//add 2011/12/02 ���� Redmine #8316
            //����敪��
            if (wkOrderConfWork.SalesSlipCd == 0)
            {
                if (wkOrderConfWork.AccRecDivCd == 0)
                {
                    wkOrderConfWork.TransactionName = "��������";
                }
                else if (wkOrderConfWork.AccRecDivCd == 1)
                {
                    wkOrderConfWork.TransactionName = "�|����";
                }
            }
            else if (wkOrderConfWork.SalesSlipCd == 1)
            {
                if (wkOrderConfWork.AccRecDivCd == 0)
                {
                    wkOrderConfWork.TransactionName = "�����ԕi";
                }
                else if (wkOrderConfWork.AccRecDivCd == 1)
                {
                    wkOrderConfWork.TransactionName = "�|�ԕi";
                }
            }
            //del 2011/12/02 ���� Redmine #8316----->>>>>
            ////�e����(���v)
            //if (wkOrderConfWork.SalesTotalTaxExc == 0)
            //{
            //    wkOrderConfWork.GrossMarginRate = 0;
            //}
            //else
            //{
            //    wkOrderConfWork.GrossMarginRate = (wkOrderConfWork.SalesTotalTaxExc - wkOrderConfWork.TotalCost) * 100 / (double)wkOrderConfWork.SalesTotalTaxExc;
            //}

            ////�e���`�F�b�N�}�[�N(���v)
            //if (wkOrderConfWork.GrossMarginRate < orderConfShWork.GrsProfitCheckLower)
            //{
            //    wkOrderConfWork.GrossMarginMarkSlip = orderConfShWork.GrossMargin1Mark;
            //}
            //else if (wkOrderConfWork.GrossMarginRate < orderConfShWork.GrsProfitCheckBest)
            //{
            //    wkOrderConfWork.GrossMarginMarkSlip = orderConfShWork.GrossMargin2Mark;
            //}
            //else if (wkOrderConfWork.GrossMarginRate < orderConfShWork.GrsProfitCheckUpper)
            //{
            //    wkOrderConfWork.GrossMarginMarkSlip = orderConfShWork.GrossMargin3Mark;
            //}
            //else
            //{
            //    wkOrderConfWork.GrossMarginMarkSlip = orderConfShWork.GrossMargin4Mark;
            //}
            //add 2011/12/02 ���� Redmine #8316-----<<<<<
            //����
            if (printMode == 1)
            {
                wkOrderConfWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                wkOrderConfWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                wkOrderConfWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkOrderConfWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                wkOrderConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkOrderConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkOrderConfWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkOrderConfWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                wkOrderConfWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                wkOrderConfWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                wkOrderConfWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                wkOrderConfWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                //wkOrderConfWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));del 2011/12/02 ���� Redmine #8316
                wkOrderConfWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                wkOrderConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkOrderConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkOrderConfWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                wkOrderConfWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                wkOrderConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkOrderConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkOrderConfWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkOrderConfWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                wkOrderConfWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                wkOrderConfWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                wkOrderConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkOrderConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkOrderConfWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));

                wkOrderConfWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkOrderConfWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                wkOrderConfWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                wkOrderConfWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                wkOrderConfWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                wkOrderConfWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                wkOrderConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                // ADD 2008.10.28 >>>
                wkOrderConfWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                // ADD 2008.10.28 <<<
                // ADD 2008.11.27 >>>
                wkOrderConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkOrderConfWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                // ADD 2008.11.27 <<<
                
                //del 2011/12/02 ���� Redmine #8316----->>>>>
                ////�e����(����)
                //if (wkOrderConfWork.SalesMoneyTaxExc == 0)
                //{
                //    wkOrderConfWork.GrossMarginRateDtl = 0;
                //}
                //else
                //{
                //    wkOrderConfWork.GrossMarginRateDtl = (wkOrderConfWork.SalesMoneyTaxExc - wkOrderConfWork.Cost) * 100 / (double)wkOrderConfWork.SalesMoneyTaxExc;
                //}

                ////�e���`�F�b�N�}�[�N(����)
                //if (wkOrderConfWork.GrossMarginRateDtl < orderConfShWork.GrsProfitCheckLower)
                //{
                //    wkOrderConfWork.GrossMarginMarkDtl = orderConfShWork.GrossMargin1Mark;
                //}
                //else if (wkOrderConfWork.GrossMarginRateDtl < orderConfShWork.GrsProfitCheckBest)
                //{
                //    wkOrderConfWork.GrossMarginMarkDtl = orderConfShWork.GrossMargin2Mark;
                //}
                //else if (wkOrderConfWork.GrossMarginRateDtl < orderConfShWork.GrsProfitCheckUpper)
                //{
                //    wkOrderConfWork.GrossMarginMarkDtl = orderConfShWork.GrossMargin3Mark;
                //}
                //else
                //{
                //    wkOrderConfWork.GrossMarginMarkDtl = orderConfShWork.GrossMargin4Mark;
                //}
                //del 2011/12/02 ���� Redmine #8316-----<<<<<
            }
            #endregion

            return wkOrderConfWork;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081�@�R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
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
    }
}

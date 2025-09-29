//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���ꗗ�\�i�����j
// �v���O�����T�v   : �x���ꗗ�\�i�����j�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���@���j
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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
    /// �x���ꗗ�\�i�����jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���ꗗ�\�i�����j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI�� ���j</br>
    /// <br>Date       : 2012/09/04</br>
    /// </remarks>
    [Serializable]
    public class SumPaymentTableDB : RemoteDB, ISumPaymentTableDB
    {
        /// <summary>
        /// �x���ꗗ�\�i�����jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        public SumPaymentTableDB()
            :
            base("PMKAK02009D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_SumPaymentTotalWork", "SUPLIERPAYRF")
        {
        }

        #region [SearchPaymentTable]
        /// <summary>
        /// �w�肳�ꂽ�����̎x���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎x���ꗗ�\�i�����j��߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        public int SearchPaymentTable(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;

            ExtrInfo_SumPaymentTotalWork extrInfo_SumPaymentTotalWork = null;
            RsltInfo_SumPaymentTotalWork rsltInfo_SumPaymentTotalWork = null;

            ArrayList extrInfo_SumPaymentTotalWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_SumPaymentTotalWorkList == null)
            {
                extrInfo_SumPaymentTotalWork = paraObj as ExtrInfo_SumPaymentTotalWork;
            }
            else
            {
                if (extrInfo_SumPaymentTotalWorkList.Count > 0)
                    extrInfo_SumPaymentTotalWork = extrInfo_SumPaymentTotalWorkList[0] as ExtrInfo_SumPaymentTotalWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���x�����z�}�X�^�擾
                status = SearchPaymentTableProc(ref retList, extrInfo_SumPaymentTotalWork, ref sqlConnection);
                
                //���s�����̎擾
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        rsltInfo_SumPaymentTotalWork = retList[i] as RsltInfo_SumPaymentTotalWork;

                        //���Z�x���W�v�f�[�^�擾
                        status = this.SearchAccPayTotal(ref rsltInfo_SumPaymentTotalWork, ref sqlConnection);
                    }
                }
                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumPaymentTableDB.SearchPaymentTable");
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

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎x���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_SumPaymentTotalWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎x���ꗗ�\�i�����j��߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        private int SearchPaymentTableProc(ref ArrayList retList, ExtrInfo_SumPaymentTotalWork extrInfo_SumPaymentTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlStr = new StringBuilder();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL��]
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("     SUPLIERPAYRF.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    ,SUM_SUP.SUMSECTIONCDRF AS SUMADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,PARENT_SEC.SECTIONGUIDENMRF AS SUMADDUPSECNAMERF" + Environment.NewLine);
                sqlStr.Append("    ,SUM_SUP.SECTIONCODERF AS ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,CHILD_SEC.SECTIONGUIDENMRF AS ADDUPSECNAMERF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.RESULTSSECTCDRF" + Environment.NewLine);
                sqlStr.Append("    ,SUM_SUP.SUMSUPPLIERCDRF AS SUMPAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,PARENT_SUP.SUPPLIERSNMRF AS SUMPAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("    ,SUM_SUP.SUPPLIERCDRF AS PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,CHILD_SUP.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine);
                sqlStr.Append("    ,CHILD_SUP.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine);
                sqlStr.Append("    ,CHILD_SUP.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.SUPPLIERNM1RF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.SUPPLIERNM2RF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.ADDUPYEARMONTHRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.LASTTIMEPAYMENTRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISTIMEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISTIMETTLBLCPAYRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.OFSTHISTIMESTOCKRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISTIMESTOCKPRICERF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISSTCKPRICRGDSRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISSTCKPRICDISRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.OFSTHISSTOCKTAXRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.STOCKTOTALPAYBALANCERF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.STOCKSLIPCOUNTRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISTIMEFEEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPLIERPAYRF.THISTIMEDISPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("    ,SUPPLIERRF.PAYMENTMONTHNAMERF" + Environment.NewLine);
                sqlStr.Append("    ,SUPPLIERRF.PAYMENTDAYRF" + Environment.NewLine);
                sqlStr.Append("    ,ACCPAY.CNT" + Environment.NewLine);
                sqlStr.Append(" FROM SUPLIERPAYRF" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SECINFOSETRF ON" + Environment.NewLine);
                sqlStr.Append(" (SUPLIERPAYRF.ENTERPRISECODERF=SECINFOSETRF.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUPLIERPAYRF.ADDUPSECCODERF=SECINFOSETRF.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SUPPLIERRF ON" + Environment.NewLine);
                sqlStr.Append(" (SUPLIERPAYRF.ENTERPRISECODERF=SUPPLIERRF.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPLIERPAYRF.PAYEECODERF=SUPPLIERRF.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" INNER JOIN SUMSUPPSTRF SUM_SUP ON" + Environment.NewLine);
                sqlStr.Append(" (SUPLIERPAYRF.ENTERPRISECODERF=SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUPLIERPAYRF.ADDUPSECCODERF=SUM_SUP.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUPLIERPAYRF.PAYEECODERF=SUM_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SECINFOSETRF AS PARENT_SEC ON" + Environment.NewLine);
                sqlStr.Append(" (SUM_SUP.ENTERPRISECODERF=PARENT_SEC.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUM_SUP.SUMSECTIONCDRF=PARENT_SEC.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SECINFOSETRF AS CHILD_SEC ON" + Environment.NewLine);
                sqlStr.Append(" (SUM_SUP.ENTERPRISECODERF=CHILD_SEC.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUM_SUP.SECTIONCODERF=CHILD_SEC.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SUPPLIERRF AS PARENT_SUP ON" + Environment.NewLine);
                sqlStr.Append(" (SUM_SUP.ENTERPRISECODERF=PARENT_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUM_SUP.SUMSUPPLIERCDRF=PARENT_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN SUPPLIERRF AS CHILD_SUP ON" + Environment.NewLine);
                sqlStr.Append(" (SUM_SUP.ENTERPRISECODERF=CHILD_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SUM_SUP.SUPPLIERCDRF=CHILD_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                sqlStr.Append(" LEFT JOIN" + Environment.NewLine);
                sqlStr.Append(" (" + Environment.NewLine);
                sqlStr.Append("   SELECT" + Environment.NewLine);
                sqlStr.Append("    ENTERPRISECODERF," + Environment.NewLine);
                sqlStr.Append("    ADDUPSECCODERF," + Environment.NewLine);
                sqlStr.Append("    PAYEECODERF," + Environment.NewLine);
                sqlStr.Append("    ADDUPDATERF," + Environment.NewLine);
                sqlStr.Append("    COUNT(MONEYKINDCODERF) CNT" + Environment.NewLine);
                sqlStr.Append("   FROM" + Environment.NewLine);
                sqlStr.Append("    ACCPAYTOTALRF " + Environment.NewLine);
                sqlStr.Append("   GROUP BY" + Environment.NewLine);
                sqlStr.Append("    ENTERPRISECODERF," + Environment.NewLine);
                sqlStr.Append("    ADDUPSECCODERF," + Environment.NewLine);
                sqlStr.Append("    PAYEECODERF," + Environment.NewLine);
                sqlStr.Append("    ADDUPDATERF    " + Environment.NewLine);
                sqlStr.Append(" ) AS ACCPAY" + Environment.NewLine);
                sqlStr.Append(" ON SUPLIERPAYRF.ENTERPRISECODERF = ACCPAY.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPLIERPAYRF.ADDUPSECCODERF = ACCPAY.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPLIERPAYRF.ADDUPDATERF = ACCPAY.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPLIERPAYRF.PAYEECODERF =  ACCPAY.PAYEECODERF" + Environment.NewLine);

                sqlCommand.CommandText = sqlStr.ToString();
                #endregion

                //Where��쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_SumPaymentTotalWork);

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_PaymentTotalFromReader(ref myReader));

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
        /// <param name="extrInfo_SumPaymentTotalWork">���������i�[�N���X</param>
        /// <returns>�x���ꗗ�\�i�����j���o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_SumPaymentTotalWork extrInfo_SumPaymentTotalWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE" + Environment.NewLine);

            //���Œ����
            //��ƃR�[�h
            retString.Append("SUPLIERPAYRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SumPaymentTotalWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND SUPLIERPAYRF.LOGICALDELETECODERF=0" + Environment.NewLine);
            retString.Append("AND SUM_SUP.LOGICALDELETECODERF=0" + Environment.NewLine);

            //�W�v���R�[�h�̂ݏo��
            retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF=0" + Environment.NewLine);

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_SumPaymentTotalWork.PaymentAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_SumPaymentTotalWork.PaymentAddupSecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND SUM_SUP.SUMSECTIONCDRF IN (" + sectionString + ")" + Environment.NewLine);
                }
            }

            if (extrInfo_SumPaymentTotalWork.CAddUpUpdExecDate > DateTime.MinValue)
            {
                retString.Append("AND SUPLIERPAYRF.ADDUPDATERF=@CADDUPUPDEXECDATE" + Environment.NewLine);
                SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_SumPaymentTotalWork.CAddUpUpdExecDate);
            }

            //�x����R�[�h
            if (extrInfo_SumPaymentTotalWork.St_PayeeCode > 0)
            {
                retString.Append("AND SUM_SUP.SUMSUPPLIERCDRF>=@ST_PAYEECODE" + Environment.NewLine);
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SumPaymentTotalWork.St_PayeeCode);
            }
            if (extrInfo_SumPaymentTotalWork.Ed_PayeeCode > 0)
            {
                retString.Append("AND SUM_SUP.SUMSUPPLIERCDRF<=@ED_PAYEECODE" + Environment.NewLine);
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SumPaymentTotalWork.Ed_PayeeCode);
            }

            retString.Append("AND (" + Environment.NewLine);
            retString.Append("     LASTTIMEPAYMENTRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKTTL2TMBFBLPAYRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKTTL3TMBFBLPAYRF != 0" + Environment.NewLine);
            retString.Append("     OR OFSTHISTIMESTOCKRF != 0" + Environment.NewLine);
            retString.Append("     OR OFSTHISSTOCKTAXRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKSLIPCOUNTRF != 0" + Environment.NewLine);
            retString.Append("     OR THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("     OR THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("     OR ACCPAY.CNT != 0" + Environment.NewLine);
            retString.Append("    )" + Environment.NewLine);

            //�������_�i�e�j�R�[�h�{�����d����i�e�j�R�[�h�{�������_�i�q�j�R�[�h�{�����d����i�q�j�R�[�h���ɕ��ёւ���
            retString.Append("ORDER BY SUM_SUP.SUMSECTIONCDRF, SUM_SUP.SUMSUPPLIERCDRF, SUM_SUP.SECTIONCODERF, SUM_SUP.SUPPLIERCDRF");

            return retString.ToString();
        }
        #endregion

        /// <summary>
        /// �w�肳�ꂽ�����̐��Z�x���W�v�f�[�^��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_SumPaymentTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐��Z�x���W�v�f�[�^��߂��܂�</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        private int SearchAccPayTotal(ref RsltInfo_SumPaymentTotalWork rsltInfo_SumPaymentTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlStr = new StringBuilder();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                //SQL��
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("     MONEYKINDCODERF" + Environment.NewLine);
                sqlStr.Append("    ,MONEYKINDNAMERF" + Environment.NewLine);
                sqlStr.Append("    ,MONEYKINDDIVRF" + Environment.NewLine);
                sqlStr.Append("    ,PAYMENTRF" + Environment.NewLine);
                sqlStr.Append(" FROM ACCPAYTOTALRF" + Environment.NewLine);
                sqlStr.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlStr.Append("    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine);
                sqlStr.Append("    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine);
                sqlStr.Append("    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine);
                sqlStr.Append("    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine);
                sqlCommand.CommandText = sqlStr.ToString();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_SumPaymentTotalWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(rsltInfo_SumPaymentTotalWork.AddUpSecCode);
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(rsltInfo_SumPaymentTotalWork.PayeeCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rsltInfo_SumPaymentTotalWork.PayeeCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rsltInfo_SumPaymentTotalWork.AddUpDate);

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                //����R�[�h���X�g
                rsltInfo_SumPaymentTotalWork.MoneyKindList = new ArrayList();

                while(myReader.Read())
                {
                    RsltInfo_SumAccPayTotalWork rsltInfo_SumAccPayTotalWork = new RsltInfo_SumAccPayTotalWork();
                    rsltInfo_SumAccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    rsltInfo_SumAccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    rsltInfo_SumAccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    rsltInfo_SumAccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    rsltInfo_SumPaymentTotalWork.MoneyKindList.Add(rsltInfo_SumAccPayTotalWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (rsltInfo_SumPaymentTotalWork.MoneyKindList.Count ==0 )
                {
                    RsltInfo_SumAccPayTotalWork rsltInfo_SumAccPayTotalWork = new RsltInfo_SumAccPayTotalWork();
                    rsltInfo_SumAccPayTotalWork.MoneyKindCode = 0;
                    rsltInfo_SumAccPayTotalWork.MoneyKindName = "";
                    rsltInfo_SumAccPayTotalWork.MoneyKindDiv = 0;
                    rsltInfo_SumAccPayTotalWork.Payment = 0;
                    //����R�[�h���X�g
                    rsltInfo_SumPaymentTotalWork.MoneyKindList = new ArrayList();
                    rsltInfo_SumPaymentTotalWork.MoneyKindList.Add(rsltInfo_SumAccPayTotalWork);
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

        #region [�x���ꗗ�\�i�����j���o���ʃN���X�i�[����]
        /// <summary>
        /// �x���ꗗ�\�i�����j���o���ʃN���X�i�[���� Reader �� RsltInfo_SumPaymentTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_SumPaymentTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private RsltInfo_SumPaymentTotalWork CopyToRsltInfo_PaymentTotalFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_SumPaymentTotalWork wkRsltInfo_SumPaymentTotalWork = new RsltInfo_SumPaymentTotalWork();

            #region �N���X�֊i�[
            wkRsltInfo_SumPaymentTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_SumPaymentTotalWork.SumAddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMADDUPSECCODERF"));
            wkRsltInfo_SumPaymentTotalWork.SumAddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMADDUPSECNAMERF"));
            wkRsltInfo_SumPaymentTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_SumPaymentTotalWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_SumPaymentTotalWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            wkRsltInfo_SumPaymentTotalWork.SumPayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMPAYEECODERF"));
            wkRsltInfo_SumPaymentTotalWork.SumPayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMPAYEESNMRF"));
            wkRsltInfo_SumPaymentTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_SumPaymentTotalWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_SumPaymentTotalWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_SumPaymentTotalWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_SumPaymentTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRsltInfo_SumPaymentTotalWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkRsltInfo_SumPaymentTotalWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkRsltInfo_SumPaymentTotalWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkRsltInfo_SumPaymentTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_SumPaymentTotalWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_SumPaymentTotalWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            wkRsltInfo_SumPaymentTotalWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            wkRsltInfo_SumPaymentTotalWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisTimeTtlBlcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCPAYRF"));
            wkRsltInfo_SumPaymentTotalWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkRsltInfo_SumPaymentTotalWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_SumPaymentTotalWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_SumPaymentTotalWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            wkRsltInfo_SumPaymentTotalWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkRsltInfo_SumPaymentTotalWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkRsltInfo_SumPaymentTotalWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkRsltInfo_SumPaymentTotalWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            #endregion

            return wkRsltInfo_SumPaymentTotalWork;
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
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

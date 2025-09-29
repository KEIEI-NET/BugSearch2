using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���N�Ԏ���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���N�Ԏ��т̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���� ���n</br>
    /// <br>Date       : 2008.11.26</br>
    /// <br></br>
    /// <br>Update Note: �e�L�X�g�o�͑Ή�</br>
    /// <br>Programmer : �m�u��</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/09/13 yangmj</br>
    /// <br>           : #14643 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2012/09/18 FSI���� ���T</br>
    /// <br>             �d���摍���Ή��ɔ����Ή�</br>
    /// <br>Update Note: 2012/11/08 FSI���� ���T</br>
    /// <br>             �N�Ԏ��яƉ�/�c���Ɖ�o�͌��ʂ̏C��</br>
    /// </remarks>
    [Serializable]
    public class SuppYearResultDB : RemoteWithAppLockDB, ISuppYearResultDB
    {
        /// <summary>
        /// �d���N�Ԏ���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        /// </remarks>
        public SuppYearResultDB()
            :
            base("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultWork", "SuppYearResultRF")
        {
        }

        // --- DEL 2012/11/08 ---------->>>>>
        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        //private MonthlyAddUpDB _monthlyAddUpDB;
        // --- DEL 2012/11/08 ----------<<<<<

        // --- ADD 2012/11/08 ---------->>>>>
        #region [�����擾]
        public int SearchMonthlyAccPay(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            prevTotalDay = DateTime.MinValue;

            try
            {
                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                status = SearchMonthlyAccPayProc(enterpriseCode, sectionCode, supplierCd, out prevTotalDay, ref sqlConnection);

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchMonthlyAccPay");
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

        private int SearchMonthlyAccPayProc(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            prevTotalDay = DateTime.MinValue;

            try
            {
                //SELECT���쐬
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT MAX(ADDUPDATERF) AS ADDUPDATERF");
                selectTxt.AppendLine("  FROM SUPLACCPAYRF");
                selectTxt.AppendLine("  WHERE ENTERPRISECODERF = @ENTERPRISECODE");
                if (sectionCode.Trim() != "")
                {
                    selectTxt.AppendLine("    AND ADDUPSECCODERF = @ADDUPSECCODE");
                }
                selectTxt.AppendLine("    AND PAYEECODERF = @PAYEECODE");
                selectTxt.AppendLine("    AND SUPPLIERCDRF = 0");

                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);
                sqlCommand.Parameters.Clear();

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //�v�㋒�_�R�[�h
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);

                //�x����R�[�h
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(supplierCd);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    prevTotalDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchSuppYearResultSuppResult Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion
        // --- ADD 2012/11/08 ----------<<<<<

        #region [Search]

        /// <summary>
        /// �w�肳�ꂽ�����̎d���N�Ԏ��уf�[�^��߂��܂�
        /// </summary>
        /// <param name="suppYearResultAccPayWork">�c���Ɖ�����ʃN���X</param>
        /// <param name="suppYearResultSuppResultWorkList">���яƉ�����ʃ��X�g</param>
        /// <param name="suppYearResultCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���N�Ԏ��уf�[�^��߂��܂�</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(out object suppYearResultAccPayWork,out object suppYearResultSuppResultWorkList, object suppYearResultCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SuppYearResultCndtnWork paraWork = null;
            ArrayList _suppYearResultSuppResultWorkList = new ArrayList();
            SuppYearResultAccPayWork _suppYearResultAccPayWork = new SuppYearResultAccPayWork();

            //���яƉ�ʃ��X�g
            suppYearResultSuppResultWorkList = _suppYearResultSuppResultWorkList;
            //�c���Ɖ��Work
            suppYearResultAccPayWork = _suppYearResultAccPayWork;

            //���o����
            ArrayList paraList = suppYearResultCndtnWork as ArrayList;

            if (paraList == null)
            {
                paraWork = suppYearResultCndtnWork as SuppYearResultCndtnWork;
            }
            else
            {
                if (paraList.Count > 0)
                    paraWork = paraList[0] as SuppYearResultCndtnWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paraWork.EnterpriseCode, "�d���N�Ԏ��яƉ�", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchSuppYearResultSuppResult(ref _suppYearResultSuppResultWorkList, paraWork, ref sqlConnection);

                if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR && paraWork.AccDiv == 0)
                {
                    //�e�d����̏ꍇ�̂ݎc���Ɖ�̒��o���s��
                    status = SearchSuppYearResultAccPay(ref _suppYearResultAccPayWork, paraWork, ref sqlConnection);

                    if (_suppYearResultSuppResultWorkList.Count != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paraWork.EnterpriseCode, "�d���N�Ԏ��яƉ�", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.Search");
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

        // --- ADD 2012/09/18 ---------------------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̎d���N�Ԏ��уf�[�^��߂��܂�
        /// </summary>
        /// <param name="suppYearResultAccPayWork">�c���Ɖ�����ʃN���X</param>
        /// <param name="suppYearResultSuppResultWorkList">���яƉ�����ʃ��X�g</param>
        /// <param name="suppYearResultCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d���N�Ԏ��уf�[�^��߂��܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/09/18</br>
        public int SearchSuppSum(out object suppYearResultAccPayWork, out object suppYearResultSuppResultWorkList, object suppYearResultCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SuppYearResultCndtnWork paraWork = null;
            ArrayList _suppYearResultSuppResultWorkList = new ArrayList();
            SuppYearResultAccPayWork _suppYearResultAccPayWork = new SuppYearResultAccPayWork();

            //���яƉ�ʃ��X�g
            suppYearResultSuppResultWorkList = _suppYearResultSuppResultWorkList;
            //�c���Ɖ��Work
            suppYearResultAccPayWork = _suppYearResultAccPayWork;

            //���o����
            ArrayList paraList = suppYearResultCndtnWork as ArrayList;

            if (paraList == null)
            {
                paraWork = suppYearResultCndtnWork as SuppYearResultCndtnWork;
            }
            else
            {
                if (paraList.Count > 0)
                    paraWork = paraList[0] as SuppYearResultCndtnWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paraWork.EnterpriseCode, "�d���N�Ԏ��яƉ�", "���o�J�n");

                status = SearchSuppYearResultSuppResult(ref _suppYearResultSuppResultWorkList, paraWork, ref sqlConnection);

                if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    //�c���Ɖ�̒��o���s��
                    status = SearchSuppYearResultAccPay(ref _suppYearResultAccPayWork, paraWork, ref sqlConnection);

                    if (_suppYearResultSuppResultWorkList.Count != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paraWork.EnterpriseCode, "�d���N�Ԏ��яƉ�", "���o�I��");
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.Search");
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
        // --- ADD 2012/09/18 ----------------------------<<<<<

        #region [���яƉ�Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎��яƉ�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="suppYearResultSuppResultWorkList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        /// <br>Update Note: 2010/09/13 yangmj</br>
        /// <br>           : #14643 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
        private int SearchSuppYearResultSuppResult(ref ArrayList suppYearResultSuppResultWorkList, SuppYearResultCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            Int32 monthRange = ((paraWork.AddUpYearMonth.Year) - (paraWork.This_YearMonth.Year)) * 12 + (paraWork.AddUpYearMonth.Month) - (paraWork.This_YearMonth.Month) + 1;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                
                //�J�n�N���x
                DateTime yearMonth = paraWork.This_YearMonth;

                for (int i = 0; i < monthRange; i++)
                {

                    selectTxt = string.Empty;
                    sqlCommand.Parameters.Clear();
                    //SELECT���쐬
                    selectTxt += "SELECT" + Environment.NewLine;

                    // --- ADD 2010/07/20-------------------------------->>>>>
                    if (!"Main".Equals(paraWork.MainDiv))
                    {
                        selectTxt += "   MTTL.STOCKSECTIONCDRF AS STOCKSECTIONCDRF" + Environment.NewLine;
                        selectTxt += "  ,SEC.SECTIONGUIDENMRF AS SECTIONGUIDENMRF" + Environment.NewLine;

                        selectTxt += "  ,MTTL.SUPPLIERCDRF AS SUPPLIERCDRF" + Environment.NewLine;
                        selectTxt += "  ,SUP.SUPPLIERNM1RF AS SUPPLIERNM1RF" + Environment.NewLine;
                        selectTxt += "  ,SUP.SUPPLIERSNMRF AS SUPPLIERSNMRF" + Environment.NewLine; // ADD 2010/10/09
                        selectTxt += "  ,";
                    }
                    // --- ADD 2010/07/20--------------------------------<<<<<

                    selectTxt += "  SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=1 THEN MTTL.STOCKTOTALPRICERF ELSE 0 END) AS ST_STOCKPRICETAXEXCRF" + Environment.NewLine;
                    selectTxt += "  ,SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=1 THEN MTTL.STOCKRETGOODSPRICERF ELSE 0 END) AS ST_STOCKRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=1 THEN MTTL.STOCKTOTALDISCOUNTRF ELSE 0 END) AS ST_STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=0 THEN MTTL.STOCKTOTALPRICERF ELSE 0 END) AS OR_STOCKPRICETAXEXCRF" + Environment.NewLine;
                    selectTxt += "  ,SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=0 THEN MTTL.STOCKRETGOODSPRICERF ELSE 0 END) AS OR_STOCKRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,SUM(CASE WHEN MTTL.RSLTTTLDIVCDRF=0 THEN MTTL.STOCKTOTALDISCOUNTRF ELSE 0 END) AS OR_STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                    selectTxt += "FROM" + Environment.NewLine;
                    selectTxt += "  MTTLSTOCKSLIPRF AS MTTL" + Environment.NewLine;
                    // --- ADD 2010/07/20-------------------------------->>>>>
                    if (!"Main".Equals(paraWork.MainDiv))
                    {
                        selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        selectTxt += "  ON MTTL.STOCKSECTIONCDRF = SEC.SECTIONCODERF" + Environment.NewLine;
                        // --- ADD 2010/09/13-------------------------------->>>>>
                        selectTxt += "  AND MTTL.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        // --- ADD 2010/09/13--------------------------------<<<<<
                        selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                        selectTxt += "  ON MTTL.SUPPLIERCDRF = SUP.SUPPLIERCDRF" + Environment.NewLine;
                        // --- ADD 2010/09/13-------------------------------->>>>>
                        selectTxt += "  AND MTTL.ENTERPRISECODERF = SUP.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  AND SUP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        // --- ADD 2010/09/13--------------------------------<<<<<

                    }
                    // --- ADD 2010/07/20--------------------------------<<<<<

                    selectTxt += MakeWhereStringSuppResult(ref sqlCommand, paraWork, yearMonth);

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        SuppYearResultSuppResultWork wkSuppYearResultSuppResultWork = new SuppYearResultSuppResultWork();
                        
                        wkSuppYearResultSuppResultWork.AddUpYearMonth = yearMonth;
                        // --- ADD 2010/07/20-------------------------------->>>>>
                        if (!"Main".Equals(paraWork.MainDiv))
                        {
                            wkSuppYearResultSuppResultWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                            wkSuppYearResultSuppResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                            // ------ UPD 2010/10/09 ---------------------->>>>>
                            //wkSuppYearResultSuppResultWork.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                            wkSuppYearResultSuppResultWork.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                            // ------ UPD 2010/10/09 ----------------------<<<<<
                            wkSuppYearResultSuppResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        }
                        else
                        {
                            wkSuppYearResultSuppResultWork.StockSectionCd = string.Empty;
                            wkSuppYearResultSuppResultWork.SectionGuideNm = string.Empty;
                            wkSuppYearResultSuppResultWork.SupplierNm = string.Empty;
                            wkSuppYearResultSuppResultWork.SupplierCd = 0;
                        }
                        // --- ADD 2010/07/20--------------------------------<<<<<

                        wkSuppYearResultSuppResultWork.St_StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKPRICETAXEXCRF"));
                        wkSuppYearResultSuppResultWork.St_StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKRETGOODSPRICERF"));
                        wkSuppYearResultSuppResultWork.St_StockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKTOTALDISCOUNTRF"));
                        wkSuppYearResultSuppResultWork.Or_StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_STOCKPRICETAXEXCRF")) - SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKPRICETAXEXCRF"));  //��񁁍��v�[�݌�
                        wkSuppYearResultSuppResultWork.Or_StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_STOCKRETGOODSPRICERF")) - SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKRETGOODSPRICERF")); //��񁁍��v�[�݌�
                        wkSuppYearResultSuppResultWork.Or_StockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_STOCKTOTALDISCOUNTRF")) - SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_STOCKTOTALDISCOUNTRF")); //��񁁍��v�[�݌�

                        suppYearResultSuppResultWorkList.Add(wkSuppYearResultSuppResultWork);
                    }

                    yearMonth = yearMonth.AddMonths(1);

                    if (!myReader.IsClosed) myReader.Close();

                }

                if (suppYearResultSuppResultWorkList.Count > 0)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchSuppYearResultSuppResult Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;

        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockmngttlstWork">���������i�[�N���X</param>
        /// <param name="stDate">�J�n���t</param>
        /// <param name="edDate">�I�����t</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 �e�L�X�g�o�͑Ή�</br>
        private string MakeWhereStringSuppResult(ref SqlCommand sqlCommand, SuppYearResultCndtnWork paraWork, DateTime yearMonth)
        {
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += "    MTTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

            //�_���폜�敪
            retstring += "AND MTTL.LOGICALDELETECODERF=0" + Environment.NewLine;

            //���_�R�[�h
            //if (string.IsNullOrEmpty(paraWork.SectionCode)) // DEL 2010/07/20
            if (string.IsNullOrEmpty(paraWork.SectionCode) == false && "Main".Equals(paraWork.MainDiv)) // ADD 2010/07/20
            {
                retstring += "AND MTTL.STOCKSECTIONCDRF=@SECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            else
            {
                if (!string.IsNullOrEmpty(paraWork.SectionCodeSt))
                {
                    retstring += "AND MTTL.STOCKSECTIONCDRF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeSt);
                }



                if (!string.IsNullOrEmpty(paraWork.SectionCodeEnd))
                {
                    retstring += "AND MTTL.STOCKSECTIONCDRF<=@SECTIONCODEEND" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODEEND", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeEnd);
                }

                retstring += "AND MTTL.STOCKSECTIONCDRF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/21


            }
            // --- ADD 2010/07/20--------------------------------<<<<<
            //�d����R�[�h
            if (paraWork.SupplierCd != 0 && "Main".Equals(paraWork.MainDiv)) // ADD 2010/07/20
            {
                retstring += "AND MTTL.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            else
            {
                if (0 != paraWork.SupplierCdSt)
                {
                    retstring += "AND MTTL.SUPPLIERCDRF>=@SUPPLIERCDST" + Environment.NewLine;
                    SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                    paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdSt);
                }

                if (0 != paraWork.SupplierCdEnd)
                {
                    retstring += "AND MTTL.SUPPLIERCDRF<=@SUPPLIERCDEND" + Environment.NewLine;
                    SqlParameter paraSupplierCdEnd = sqlCommand.Parameters.Add("@SUPPLIERCDEND", SqlDbType.Int);
                    paraSupplierCdEnd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdEnd);
                }
                retstring += "AND MTTL.SUPPLIERCDRF IN (SELECT SUPPLIERCDRF FROM SUPPLIERRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/21

            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            //�Ώ۔N��
            retstring += "AND MTTL.STOCKDATEYMRF=@STOCKDATEYM" + Environment.NewLine;
            SqlParameter paraStockDateYm = sqlCommand.Parameters.Add("@STOCKDATEYM", SqlDbType.Int);
            paraStockDateYm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(yearMonth);

            // --- ADD 2010/07/20-------------------------------->>>>>
            if (!"Main".Equals(paraWork.MainDiv))
            { //ADD 2010/10/22
                retstring += "  GROUP BY MTTL.STOCKSECTIONCDRF,SEC.SECTIONGUIDENMRF,MTTL.SUPPLIERCDRF,SUP.SUPPLIERNM1RF" + Environment.NewLine;
                retstring += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine; // ADD 2010/10/09
            }//ADD 2010/10/22
            // --- ADD 2010/07/20--------------------------------<<<<<

            return retstring;
        }
        #endregion //End ���яƉ�Search

        #region �c���Ɖ�Search
        /// <summary>
        /// �w�肳�ꂽ�����̎c���Ɖ�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="suppYearResultAccPayWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        private int SearchSuppYearResultAccPay(ref SuppYearResultAccPayWork suppYearResultAccPayWork, SuppYearResultCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�x�����z�}�X�^���o
            status = SearchSuplierPay(ref suppYearResultAccPayWork, paraWork, ref sqlConnection);

            //�������̏��������W�v���g�p���Ē��o
            status = SearchMonthAccPay(ref suppYearResultAccPayWork, paraWork, ref sqlConnection);

            //�����̏��𔃊|���z�}�X�^��蒊�o
            status = SearchYearAccPay(ref suppYearResultAccPayWork, paraWork, ref sqlConnection);

            return status;

        }

        #region �x�����z�}�X�^Search
        /// <summary>
        /// �w�肳�ꂽ�����̎x�����z�}�X�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="suppYearResultAccPayWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎x�����z�}�X�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        private int SearchSuplierPay(ref SuppYearResultAccPayWork suppYearResultAccPayWork, SuppYearResultCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // --- DEL 2012/11/08 ---------->>>>>
                #region �폜
                //sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //sqlCommand.Parameters.Clear();

                ////SELECT���쐬
                //string selectTxt = string.Empty;
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "   PAY.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.LASTTIMEPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.CASHEPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.TRFRPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.CHECKKPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.DRAFTPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.OFFSETPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.FUNDTRANSFERPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.EMONEYPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,TOTAL.OTHERPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.THISTIMESTOCKPRICERF" + Environment.NewLine;
                //selectTxt += "  ,PAY.THISSTCKPRICRGDSRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.THISSTCKPRICDISRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                //selectTxt += "  ,PAY.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  SUPLIERPAYRF AS PAY" + Environment.NewLine;
                //selectTxt += "LEFT JOIN " + Environment.NewLine;
                //selectTxt += "(" + Environment.NewLine;
                //selectTxt += "  SELECT" + Environment.NewLine;
                //selectTxt += "     ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "    ,ADDUPSECCODERF" + Environment.NewLine;
                //selectTxt += "    ,PAYEECODERF" + Environment.NewLine;
                //selectTxt += "    ,SUPPLIERCDRF" + Environment.NewLine;
                //selectTxt += "    ,ADDUPDATERF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=51 THEN PAYMENTRF ELSE 0 END)) AS CASHEPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=52 THEN PAYMENTRF ELSE 0 END)) AS TRFRPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=53 THEN PAYMENTRF ELSE 0 END)) AS CHECKKPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=54 THEN PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=56 THEN PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=59 THEN PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=60 THEN PAYMENTRF ELSE 0 END)) AS EMONEYPAYMENTRF" + Environment.NewLine;
                //selectTxt += "    ,SUM((CASE WHEN MONEYKINDCODERF=58 THEN PAYMENTRF ELSE 0 END)) AS OTHERPAYMENTRF" + Environment.NewLine;
                //selectTxt += "  FROM" + Environment.NewLine;
                //selectTxt += "    ACCPAYTOTALRF" + Environment.NewLine;
                //selectTxt += "  WHERE" + Environment.NewLine;
                //selectTxt += "         ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //selectTxt += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                //// --- ADD 2010/07/20-------------------------------->>>>>
                //if ("Main".Equals(paraWork.MainDiv))
                //{
                //    // --- ADD 2010/07/20--------------------------------<<<<<
                //    selectTxt += "     AND ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                //    selectTxt += "     AND PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                //}
                //// --- ADD 2010/07/20-------------------------------->>>>>
                //else
                //{
                //    selectTxt += "     AND ADDUPSECCODERF>=@ADDUPSECCODEST" + Environment.NewLine;
                //    selectTxt += "     AND ADDUPSECCODERF<=@ADDUPSECCODEEND" + Environment.NewLine;

                //    if (0 != paraWork.SupplierCdSt)
                //        selectTxt += "     AND PAYEECODERF>=@PAYEECODEST" + Environment.NewLine;
                //    if (0 != paraWork.SupplierCdEnd)
                //        selectTxt += "     AND PAYEECODERF<=@PAYEECODEEND" + Environment.NewLine;
                //}
                //// --- ADD 2010/07/20--------------------------------<<<<<

                //selectTxt += "     AND SUPPLIERCDRF=0" + Environment.NewLine;
                //selectTxt += "     AND ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                //selectTxt += "  GROUP BY" + Environment.NewLine;
                //selectTxt += "     ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "    ,ADDUPSECCODERF" + Environment.NewLine;
                //selectTxt += "    ,PAYEECODERF" + Environment.NewLine;
                //selectTxt += "    ,SUPPLIERCDRF" + Environment.NewLine;
                //selectTxt += "    ,ADDUPDATERF" + Environment.NewLine;
                //selectTxt += "    " + Environment.NewLine;
                //selectTxt += ") AS TOTAL ON " + Environment.NewLine;
                //selectTxt += "      PAY.ENTERPRISECODERF=TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND PAY.ADDUPSECCODERF=TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                //selectTxt += "  AND PAY.PAYEECODERF=TOTAL.PAYEECODERF" + Environment.NewLine;
                //selectTxt += "  AND PAY.SUPPLIERCDRF=TOTAL.SUPPLIERCDRF" + Environment.NewLine;
                //selectTxt += "  AND PAY.ADDUPDATERF=TOTAL.ADDUPDATERF" + Environment.NewLine;
                //selectTxt += "WHERE" + Environment.NewLine;
                //selectTxt += "      PAY.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //selectTxt += "  AND PAY.LOGICALDELETECODERF=0" + Environment.NewLine;
                //// --- ADD 2010/07/20-------------------------------->>>>>
                //if ("Main".Equals(paraWork.MainDiv))
                //{
                //    // --- ADD 2010/07/20--------------------------------<<<<<
                //    selectTxt += "  AND PAY.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                //    selectTxt += "  AND PAY.PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                //    // --- ADD 2010/07/20-------------------------------->>>>>
                //}
                //else
                //{
                //    selectTxt += "  AND PAY.ADDUPSECCODERF>=@ADDUPSECCODEST" + Environment.NewLine;
                //    selectTxt += "  AND PAY.ADDUPSECCODERF<=@ADDUPSECCODEEND" + Environment.NewLine;

                //    if (0 != paraWork.SupplierCdSt)
                //        selectTxt += "     AND PAY.PAYEECODERF>=@PAYEECODEST" + Environment.NewLine;
                //    if (0 != paraWork.SupplierCdEnd)
                //        selectTxt += "     AND PAY.PAYEECODERF<=@PAYEECODEEND" + Environment.NewLine;
                //}
                //// --- ADD 2010/07/20--------------------------------<<<<<

                //selectTxt += "  AND PAY.RESULTSSECTCDRF=0" + Environment.NewLine;
                //selectTxt += "  AND PAY.SUPPLIERCDRF=0" + Environment.NewLine;
                //selectTxt += "  AND PAY.ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;

                ////��ƃR�[�h
                //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //// --- ADD 2010/07/20-------------------------------->>>>>
                //if ("Main".Equals(paraWork.MainDiv))
                //{
                //    // --- ADD 2010/07/20--------------------------------<<<<<
                //    //�v�㋒�_�R�[�h
                //    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                //    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);

                //    //�x����R�[�h
                //    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                //    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
                //    // --- ADD 2010/07/20-------------------------------->>>>>
                //}
                //else
                //{
                //    //�v�㋒�_�R�[�hFrom
                //    SqlParameter paraAddUpSecCodeSt = sqlCommand.Parameters.Add("@ADDUPSECCODEST", SqlDbType.NChar);
                //    paraAddUpSecCodeSt.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeSt);

                //    //�v�㋒�_�R�[�hTo
                //    SqlParameter paraAddUpSecCodeEnd = sqlCommand.Parameters.Add("@ADDUPSECCODEEND", SqlDbType.NChar);
                //    paraAddUpSecCodeEnd.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeEnd);


                //    //�x����R�[�hFrom
                //    SqlParameter paraPayeeCodeSt = sqlCommand.Parameters.Add("@PAYEECODEST", SqlDbType.Int);
                //    paraPayeeCodeSt.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdSt);

                //    //�x����R�[�hTo
                //    SqlParameter paraPayeeCodeEnd = sqlCommand.Parameters.Add("@PAYEECODEEND", SqlDbType.Int);
                //    paraPayeeCodeEnd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdEnd);
                //}
                //// --- ADD 2010/07/20--------------------------------<<<<<


                ////�v��N����
                //SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                //paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SuppTotalDay);

                //sqlCommand.CommandText = selectTxt;
                #endregion
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                //SELECT���쐬
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("   SUM(PAY.STOCKTTL3TMBFBLPAYRF) AS STOCKTTL3TMBFBLPAYRF");
                selectTxt.AppendLine("  ,SUM(PAY.STOCKTTL2TMBFBLPAYRF) AS STOCKTTL2TMBFBLPAYRF");
                selectTxt.AppendLine("  ,SUM(PAY.LASTTIMEPAYMENTRF) AS LASTTIMEPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.CASHEPAYMENTRF) AS CASHEPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.TRFRPAYMENTRF) AS TRFRPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.CHECKKPAYMENTRF) AS CHECKKPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.DRAFTPAYMENTRF) AS DRAFTPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.OFFSETPAYMENTRF) AS OFFSETPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.FUNDTRANSFERPAYMENTRF) AS FUNDTRANSFERPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.EMONEYPAYMENTRF) AS EMONEYPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(TOTAL.OTHERPAYMENTRF) AS OTHERPAYMENTRF");
                selectTxt.AppendLine("  ,SUM(PAY.THISTIMEFEEPAYNRMLRF) AS THISTIMEFEEPAYNRMLRF");
                selectTxt.AppendLine("  ,SUM(PAY.THISTIMEDISPAYNRMLRF) AS THISTIMEDISPAYNRMLRF");
                selectTxt.AppendLine("  ,SUM(PAY.STOCKSLIPCOUNTRF) AS STOCKSLIPCOUNTRF");
                selectTxt.AppendLine("  ,SUM(PAY.THISTIMESTOCKPRICERF) AS THISTIMESTOCKPRICERF");
                selectTxt.AppendLine("  ,SUM(PAY.THISSTCKPRICRGDSRF) AS THISSTCKPRICRGDSRF");
                selectTxt.AppendLine("  ,SUM(PAY.THISSTCKPRICDISRF) AS THISSTCKPRICDISRF");
                selectTxt.AppendLine("  ,SUM(PAY.OFSTHISTIMESTOCKRF) AS OFSTHISTIMESTOCKRF");
                selectTxt.AppendLine("  ,SUM(PAY.OFSTHISSTOCKTAXRF) AS OFSTHISSTOCKTAXRF");
                selectTxt.AppendLine("  ,SUM(ACC.STCKTTLACCPAYBALANCERF) AS STOCKTOTALPAYBALANCERF");
                selectTxt.AppendLine("FROM");
                selectTxt.AppendLine("  SUPLIERPAYRF AS PAY");
                selectTxt.AppendLine("INNER JOIN ");
                selectTxt.AppendLine("(");
                selectTxt.AppendLine("  SELECT");
                selectTxt.AppendLine("     SEC.ENTERPRISECODERF");
                selectTxt.AppendLine("    ,SEC.ADDUPSECCODERF");
                selectTxt.AppendLine("    ,SEC.PAYEECODERF");
                selectTxt.AppendLine("    ,SEC.SUPPLIERCDRF");
                selectTxt.AppendLine("    ,SEC.ADDUPDATERF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=51 THEN PAYMENTRF ELSE 0 END)) AS CASHEPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=52 THEN PAYMENTRF ELSE 0 END)) AS TRFRPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=53 THEN PAYMENTRF ELSE 0 END)) AS CHECKKPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=54 THEN PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=56 THEN PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=59 THEN PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=60 THEN PAYMENTRF ELSE 0 END)) AS EMONEYPAYMENTRF");
                selectTxt.AppendLine("    ,SUM((CASE WHEN MONEYKINDCODERF=58 THEN PAYMENTRF ELSE 0 END)) AS OTHERPAYMENTRF");
                selectTxt.AppendLine("  FROM");
                selectTxt.AppendLine("    ACCPAYTOTALRF AS SEC");
                selectTxt.AppendLine("  INNER JOIN");
                selectTxt.AppendLine("  (");
                selectTxt.AppendLine("SELECT ENTERPRISECODERF");
                selectTxt.AppendLine("      ,ADDUPSECCODERF");
                selectTxt.AppendLine("      ,PAYEECODERF");
                selectTxt.AppendLine("      ,SUPPLIERCDRF");
                selectTxt.AppendLine("      ,MAX(ADDUPDATERF) AS ADDUPDATERF");
                selectTxt.AppendLine("  FROM SUPLIERPAYRF");
                selectTxt.AppendLine("  WHERE ENTERPRISECODERF = @ENTERPRISECODE");
                if (paraWork.SectionCode.Trim() != "")
                {
                    selectTxt.AppendLine("    AND ADDUPSECCODERF = @ADDUPSECCODE");
                    selectTxt.AppendLine("    AND ADDUPDATERF = @ADDUPDATE");
                }
                selectTxt.AppendLine("    AND PAYEECODERF = @PAYEECODE");
                selectTxt.AppendLine("    AND SUPPLIERCDRF = 0");
                selectTxt.AppendLine("  GROUP BY");
                selectTxt.AppendLine("       ENTERPRISECODERF");
                selectTxt.AppendLine("      ,ADDUPSECCODERF");
                selectTxt.AppendLine("      ,PAYEECODERF");
                selectTxt.AppendLine("      ,SUPPLIERCDRF");
                selectTxt.AppendLine("  ) AS ACC ON");
                selectTxt.AppendLine("         SEC.ENTERPRISECODERF = ACC.ENTERPRISECODERF");
                selectTxt.AppendLine("     AND SEC.ADDUPSECCODERF=ACC.ADDUPSECCODERF");
                selectTxt.AppendLine("     AND SEC.PAYEECODERF=ACC.PAYEECODERF");
                selectTxt.AppendLine("     AND SEC.SUPPLIERCDRF=ACC.PAYEECODERF");
                selectTxt.AppendLine("     AND SEC.ADDUPDATERF=ACC.ADDUPDATERF");
                selectTxt.AppendLine("  WHERE");
                selectTxt.AppendLine("         SEC.ENTERPRISECODERF=@ENTERPRISECODE");
                selectTxt.AppendLine("     AND LOGICALDELETECODERF=0");
                selectTxt.AppendLine("     --AND SEC.PAYEECODERF=@PAYEECODE");
                selectTxt.AppendLine("  GROUP BY");
                selectTxt.AppendLine("     SEC.ENTERPRISECODERF");
                selectTxt.AppendLine("    ,SEC.ADDUPSECCODERF");
                selectTxt.AppendLine("    ,SEC.PAYEECODERF");
                selectTxt.AppendLine("    ,SEC.SUPPLIERCDRF");
                selectTxt.AppendLine("    ,SEC.ADDUPDATERF");
                selectTxt.AppendLine(") AS TOTAL ON");
                selectTxt.AppendLine("      PAY.ENTERPRISECODERF=TOTAL.ENTERPRISECODERF");
                selectTxt.AppendLine("  AND PAY.ADDUPSECCODERF=TOTAL.ADDUPSECCODERF");
                selectTxt.AppendLine("  AND PAY.PAYEECODERF=TOTAL.PAYEECODERF");
                selectTxt.AppendLine("  AND PAY.ADDUPDATERF=TOTAL.ADDUPDATERF");
                selectTxt.AppendLine("LEFT JOIN ");
                selectTxt.AppendLine("(");
                selectTxt.AppendLine("  SELECT");
                selectTxt.AppendLine("     SEC.ENTERPRISECODERF");
                selectTxt.AppendLine("    ,SEC.ADDUPSECCODERF");
                selectTxt.AppendLine("    ,SEC.PAYEECODERF");
                selectTxt.AppendLine("    ,SEC.SUPPLIERCDRF");
                selectTxt.AppendLine("    ,SEC.ADDUPDATERF");
                selectTxt.AppendLine("    ,STCKTTLACCPAYBALANCERF");
                selectTxt.AppendLine("  FROM");
                selectTxt.AppendLine("    SUPLACCPAYRF AS SEC");
                selectTxt.AppendLine("  INNER JOIN");
                selectTxt.AppendLine("  (");
                selectTxt.AppendLine("SELECT ENTERPRISECODERF");
                selectTxt.AppendLine("      ,ADDUPSECCODERF");
                selectTxt.AppendLine("      ,PAYEECODERF");
                selectTxt.AppendLine("      ,SUPPLIERCDRF");
                selectTxt.AppendLine("      ,MAX(ADDUPDATERF) AS ADDUPDATERF");
                selectTxt.AppendLine("  FROM SUPLACCPAYRF");
                selectTxt.AppendLine("  WHERE ENTERPRISECODERF = @ENTERPRISECODE");
                if (paraWork.SectionCode.Trim() != "")
                {
                    selectTxt.AppendLine("    AND ADDUPSECCODERF = @ADDUPSECCODE");
                    selectTxt.AppendLine("    AND ADDUPDATERF = @SECADDUPDATE");
                }
                selectTxt.AppendLine("    AND PAYEECODERF = @PAYEECODE");
                selectTxt.AppendLine("    AND SUPPLIERCDRF = 0");
                selectTxt.AppendLine("  GROUP BY");
                selectTxt.AppendLine("       ENTERPRISECODERF");
                selectTxt.AppendLine("      ,ADDUPSECCODERF");
                selectTxt.AppendLine("      ,PAYEECODERF");
                selectTxt.AppendLine("      ,SUPPLIERCDRF");
                selectTxt.AppendLine("  ) AS ACC ON");
                selectTxt.AppendLine("         SEC.ENTERPRISECODERF = ACC.ENTERPRISECODERF");
                selectTxt.AppendLine("     AND SEC.ADDUPSECCODERF=ACC.ADDUPSECCODERF");
                selectTxt.AppendLine("     AND SEC.PAYEECODERF=ACC.PAYEECODERF");
                selectTxt.AppendLine("     AND SEC.SUPPLIERCDRF=ACC.SUPPLIERCDRF");
                selectTxt.AppendLine("     AND SEC.ADDUPDATERF=ACC.ADDUPDATERF");
                selectTxt.AppendLine(") AS ACC ON");
                selectTxt.AppendLine("      PAY.ENTERPRISECODERF=ACC.ENTERPRISECODERF");
                selectTxt.AppendLine("  AND PAY.ADDUPSECCODERF=ACC.ADDUPSECCODERF");
                selectTxt.AppendLine("  AND PAY.PAYEECODERF=ACC.PAYEECODERF");
                selectTxt.AppendLine("WHERE");
                selectTxt.AppendLine("      PAY.ENTERPRISECODERF=@ENTERPRISECODE");
                selectTxt.AppendLine("  AND PAY.LOGICALDELETECODERF=0");
                selectTxt.AppendLine("  AND PAY.PAYEECODERF=@PAYEECODE");
                selectTxt.AppendLine("  AND PAY.RESULTSSECTCDRF=0");

                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);
                sqlCommand.Parameters.Clear();

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //�v�㋒�_�R�[�h
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);

                //�x����R�[�h
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);

                //�d����v��N����
                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SuppTotalDay);

                //���_�v��N����
                SqlParameter paraSecAddUpDate = sqlCommand.Parameters.Add("@SECADDUPDATE", SqlDbType.Int);
                paraSecAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SecTotalDay);
                // --- ADD 2012/11/08 ----------<<<<<

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    suppYearResultAccPayWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
                    suppYearResultAccPayWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
                    suppYearResultAccPayWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
                    suppYearResultAccPayWork.CashePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHEPAYMENTRF"));
                    suppYearResultAccPayWork.TrfrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRPAYMENTRF"));
                    suppYearResultAccPayWork.CheckKPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKKPAYMENTRF"));
                    suppYearResultAccPayWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENTRF"));
                    suppYearResultAccPayWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENTRF"));
                    suppYearResultAccPayWork.FundtransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERPAYMENTRF"));
                    suppYearResultAccPayWork.EmoneyPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EMONEYPAYMENTRF"));
                    suppYearResultAccPayWork.OtherPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERPAYMENTRF"));
                    suppYearResultAccPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
                    suppYearResultAccPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
                    suppYearResultAccPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
                    suppYearResultAccPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                    suppYearResultAccPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                    suppYearResultAccPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                    suppYearResultAccPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                    suppYearResultAccPayWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
                    // --- DEL 2012/11/08 ---------->>>>>
                    //suppYearResultAccPayWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
                    // --- DEL 2012/11/08 ----------<<<<<
                    // --- ADD 2012/11/08 ---------->>>>>
                    // �x���c���̎Z�o
                    suppYearResultAccPayWork.StockTotalPayBalance =
                        // �x���c���v
                        (suppYearResultAccPayWork.StockTtl3TmBfBlPay + suppYearResultAccPayWork.StockTtl2TmBfBlPay + suppYearResultAccPayWork.LastTimePayment) -
                        // �x����񍇌v
                        (suppYearResultAccPayWork.CashePayment + suppYearResultAccPayWork.TrfrPayment +
                        suppYearResultAccPayWork.CheckKPayment + suppYearResultAccPayWork.DraftPayment +
                        suppYearResultAccPayWork.OffsetPayment + suppYearResultAccPayWork.FundtransferPayment +
                        suppYearResultAccPayWork.EmoneyPayment + suppYearResultAccPayWork.OtherPayment +
                        suppYearResultAccPayWork.ThisTimeFeePayNrml + suppYearResultAccPayWork.ThisTimeDisPayNrml) +
                        // �x�����d���Ə���ł����Z
                        suppYearResultAccPayWork.OfsThisTimeStock + suppYearResultAccPayWork.OfsThisStockTax;

                    // �����O���c�̎擾
                    suppYearResultAccPayWork.MonthLastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
                    // --- ADD 2012/11/08 ----------<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchSuppYearResultSuppResult Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;

        }
        #endregion  //End �x�����z�}�X�^Search

        #region ������Search
        /// <summary>
        /// �w�肳�ꂽ�����œ������|����S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="suppYearResultAccPayWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����œ������|����S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        private int SearchMonthAccPay(ref SuppYearResultAccPayWork suppYearResultAccPayWork, SuppYearResultCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // --- DEL 2012/11/08 ---------->>>>>
            //_monthlyAddUpDB = new MonthlyAddUpDB();
            // --- DEL 2012/11/08 ----------<<<<<

            //�����W�v���\�b�h�Ăяo���p����
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
            ArrayList suplAccPayWorkList = new ArrayList();
            ArrayList suplAccPayChildWorkList = new ArrayList();
            ArrayList aCalcPayTotalList = new ArrayList();
            MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();
            bool msgDiv;
            string retMsg;
            //�����߂��l�����ĂP���ɕϊ����Ă���A���񎩎В������擾����
            DateTime addUpDate = paraWork.SecTotalDay.AddDays(1);
            addUpDate = addUpDate.AddMonths(1);
            addUpDate = addUpDate.AddDays(-1);

            SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
            suplAccPayWork.EnterpriseCode = paraWork.EnterpriseCode;
            suplAccPayWork.AddUpSecCode = paraWork.SectionCode;
            suplAccPayWork.PayeeCode = paraWork.SupplierCd;
            suplAccPayWork.AddUpDate = addUpDate;  
            suplAccPayWork.SupplierCd = paraWork.SupplierCd;

            suplAccPayWorkList.Add(suplAccPayWork);

            // --- DEL 2012/11/08 ---------->>>>>
            //status = _monthlyAddUpDB.MakeMonthlyAddUpSuplAccPayParameters(ref monthlyAddUpWork, ref suplAccPayWorkList, ref suplAccPayChildWorkList, ref aCalcPayTotalList, out monthlyAddUpHisWork, out msgDiv, out retMsg, ref sqlConnection);
            // --- DEL 2012/11/08 ----------<<<<<
            // --- ADD 2012/11/08 ---------->>>>>
            // �d����������������Ŏ���(���_�ʏ����̂���)
            status = SearchMonthlyAccPay(ref suplAccPayWorkList, ref suplAccPayChildWorkList, ref aCalcPayTotalList, out msgDiv, out retMsg, ref sqlConnection);
            // --- ADD 2012/11/08 ----------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            //���ʃN���X�i�[����
            suplAccPayWork = suplAccPayWorkList[0] as SuplAccPayWork;
        
            foreach(ACalcPayTotalWork aCalcPayTotalWork in aCalcPayTotalList)
            {
                switch(aCalcPayTotalWork.MoneyKindCode)
                {
                    case 51://����
                        {
                            suppYearResultAccPayWork.MonthCashePayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 52://�U��
                        {
                            suppYearResultAccPayWork.MonthTrfrPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 53://���؎�
                        {
                            suppYearResultAccPayWork.MonthCheckKPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 54://��`
                        {
                            suppYearResultAccPayWork.MonthDraftPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 56://���E
                        {
                            suppYearResultAccPayWork.MonthOffsetPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 59://�����U��
                        {
                            suppYearResultAccPayWork.MonthFundtransferPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 60://E-Money
                        {
                            suppYearResultAccPayWork.MonthEmoneyPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                    case 58://���̑�
                        {
                            suppYearResultAccPayWork.MonthOtherPayment = aCalcPayTotalWork.Payment;
                            break;
                        }
                }
                
            }

            // --- DEL 2012/11/08 ---------->>>>>
            //suppYearResultAccPayWork.MonthLastTimeAccPay = suplAccPayWork.LastTimeAccPay;
            // --- DEL 2012/11/08 ----------<<<<<
            suppYearResultAccPayWork.MonthThisTimeFeePayNrml = suplAccPayWork.ThisTimeFeePayNrml;
            suppYearResultAccPayWork.MonthThisTimeDisPayNrml = suplAccPayWork.ThisTimeDisPayNrml;
            suppYearResultAccPayWork.MonthStockSlipCount = suplAccPayWork.StockSlipCount;
            suppYearResultAccPayWork.MonthThisTimeStockPrice = suplAccPayWork.ThisTimeStockPrice;
            suppYearResultAccPayWork.MonthThisStckPricRgds = suplAccPayWork.ThisStckPricRgds;
            suppYearResultAccPayWork.MonthThisStckPricDis = suplAccPayWork.ThisStckPricDis;
            suppYearResultAccPayWork.MonthOfsThisTimeStock = suplAccPayWork.OfsThisTimeStock;
            suppYearResultAccPayWork.MonthOfsThisStockTax = suplAccPayWork.OfsThisStockTax;
            // --- DEL 2012/11/08 ---------->>>>>
            //suppYearResultAccPayWork.MonthStckTtlAccPayBalance = suplAccPayWork.StckTtlAccPayBalance;
            // --- DEL 2012/11/08 ----------<<<<<
            // --- ADD 2012/11/08 ---------->>>>>
            // �����x���c���̎Z�o
            suppYearResultAccPayWork.MonthStckTtlAccPayBalance =
                // �����c
                suppYearResultAccPayWork.MonthLastTimeAccPay -
                // ������񍇌v
                (suppYearResultAccPayWork.MonthCashePayment + suppYearResultAccPayWork.MonthTrfrPayment +
                suppYearResultAccPayWork.MonthCheckKPayment + suppYearResultAccPayWork.MonthDraftPayment +
                suppYearResultAccPayWork.MonthOffsetPayment + suppYearResultAccPayWork.MonthFundtransferPayment +
                suppYearResultAccPayWork.MonthEmoneyPayment + suppYearResultAccPayWork.MonthOtherPayment +
                suppYearResultAccPayWork.MonthThisTimeFeePayNrml + suppYearResultAccPayWork.MonthThisTimeDisPayNrml) +
                // �������d���Ə���ł����Z
                suppYearResultAccPayWork.MonthOfsThisTimeStock + suppYearResultAccPayWork.MonthOfsThisStockTax;
            // --- ADD 2012/11/08 ----------<<<<<

            //�������̍��ڂɓ������̋��z���Z�b�g���Ă���
            suppYearResultAccPayWork.YearStockSlipCount = suppYearResultAccPayWork.MonthStockSlipCount;
            suppYearResultAccPayWork.YearThisTimeStockPrice = suppYearResultAccPayWork.MonthThisTimeStockPrice;
            suppYearResultAccPayWork.YearThisStckPricRgds = suppYearResultAccPayWork.MonthThisStckPricRgds;
            suppYearResultAccPayWork.YearThisStckPricDis = suppYearResultAccPayWork.MonthThisStckPricDis;
            suppYearResultAccPayWork.YearOfsThisTimeStock = suppYearResultAccPayWork.MonthOfsThisTimeStock;
            suppYearResultAccPayWork.YearOfsThisStockTax = suppYearResultAccPayWork.MonthOfsThisStockTax;

            return status;

        }

        // --- ADD 2012/11/08 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����œ������|�����擾
        /// </summary>
        /// <param name="suplAccPayWorkList">���|���z�}�X�^�X�VList</param>
        /// <param name="suplAccPayChildWorkList">���|���z�}�X�^�X�VList(�q���R�[�h�p)</param>
        /// <param name="aCalcPayTotalList">���|�x���W�v�f�[�^�X�VList</param>
        /// <param name="msgDiv">�G���[���b�Z�[�W�L���敪</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������|�����擾���܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        /// </remarks>
        private int SearchMonthlyAccPay(ref ArrayList suplAccPayWorkList, ref ArrayList suplAccPayChildWorkList, ref ArrayList aCalcPayTotalList, out bool msgDiv, out string retMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //�������X�V�����}�X�^
            ArrayList monthlyAddUpHisWorkList = new ArrayList();

            msgDiv = false;
            retMsg = null;

            //���|���z�}�X�^
            SuplAccPayWork suplAccPayWork = null;

            try
            {
                //�����|���z�}�X�^�X�VList�쐬����
                if (suplAccPayWorkList != null && suplAccPayWorkList.Count > 0)
                {
                    suplAccPayWork = suplAccPayWorkList[0] as SuplAccPayWork;

                    suplAccPayWork.MonthAddUpExpDate = DateTime.Now;

                    //���O�񔃊|���擾
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetMonthlyAddUpHis(ref suplAccPayWork, ref sqlConnection);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //�����f�[�^�}�����̓f�[�^���Ȃ��̂őO�񌎎��X�V�N�����ɍŏ��l��}������
                        suplAccPayWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                        suplAccPayWork.StMonCAddUpUpdDate = DateTime.MinValue;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //���x���`�[�}�X�^�擾
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetPaymentSlp(ref suplAccPayWork, ref suplAccPayChildWorkList, ref sqlConnection);
                    }
                    //���x�����׃f�[�^���x���}�X�^�擾
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetPaymentDtl(ref suplAccPayWork, ref aCalcPayTotalList, ref sqlConnection);
                    }
                    //���d���f�[�^�擾
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetStockSlip(ref suplAccPayWork, ref suplAccPayChildWorkList, ref sqlConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MonthlyAddUpDB.MakeMonthlyAddUpParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �d���攃�|���z�}�X�^����O��X�V�����擾���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�X�VList</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^����O��X�V�����擾���܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        /// </remarks>
        private int GetMonthlyAddUpHis(ref SuplAccPayWork suplAccPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandTimeout = 3600;
                    sqlCommand.Connection = sqlConnection;

                    StringBuilder selectTxt = new StringBuilder();
                    selectTxt.AppendLine("SELECT MAX(ADDUPDATERF) AS ADDUPDATERF");
                    selectTxt.AppendLine("FROM SUPLACCPAYRF WITH(READUNCOMMITTED)");
                    selectTxt.AppendLine("WHERE");
                    selectTxt.AppendLine("   ENTERPRISECODERF=@FINDENTERPRISECODE");
                    selectTxt.AppendLine("  AND PAYEECODERF=@FINDCUSTOMERCODE");
                    selectTxt.AppendLine("  AND ADDUPDATERF<@ADDUPDATERF");

                    sqlCommand.CommandText = selectTxt.ToString();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //�O�񌎎��X�V���s�N�����@���@�v��N����
                        suplAccPayWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        //�����X�V�J�n�N����
                        suplAccPayWork.StMonCAddUpUpdDate = suplAccPayWork.LaMonCAddUpUpdDate.AddDays(1.0);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �x���`�[�}�X�^���擾���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�X�VList</param>
        /// <param name="suplAccPayChildWorkList">�d���攃�|���z�}�X�^�X�VList(�q���R�[�h�p)</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x���`�[�}�X�^���擾���܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        /// </remarks>
        private int GetPaymentSlp(ref SuplAccPayWork suplAccPayWork, ref ArrayList suplAccPayChildWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  ENTERPRISECODERF,");
                selectTxt.AppendLine("  PAYEECODERF,");
                selectTxt.AppendLine("  SUM(PAYMENTTOTALRF) AS PAYMENTTOTALRF,");
                selectTxt.AppendLine("  SUM(FEEPAYMENTRF) AS FEEPAYMENTRF,");
                selectTxt.AppendLine("  SUM(DISCOUNTPAYMENTRF) AS DISCOUNTPAYMENTRF");
                selectTxt.AppendLine(" FROM PAYMENTSLPRF WITH (READUNCOMMITTED)");
                selectTxt.AppendLine("  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");
                if (suplAccPayWork.AddUpSecCode.Trim() != "")
                {
                    selectTxt.AppendLine("    AND ADDUPSECCODERF=@FINDADDUPSECCODE");
                }
                selectTxt.AppendLine("    AND PAYEECODERF=@FINDSUPPLIERCD");
                selectTxt.AppendLine("    AND (ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE)");
                selectTxt.AppendLine("    AND  LOGICALDELETECODERF=0");
                selectTxt.AppendLine("  GROUP BY");
                selectTxt.AppendLine("    ENTERPRISECODERF,");
                selectTxt.AppendLine("    PAYEECODERF");

                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    #region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);
                    if (suplAccPayWork.LaMonCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.LaMonCAddUpUpdDate);
                    #endregion

                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        suplAccPayWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));      // ����x�����z
                        suplAccPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));     // ����萔�����z
                        suplAccPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));// ����l�����z 
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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �x�����׃f�[�^���擾���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�X�VList</param>
        /// <param name="aCalcPayTotalList">���|�x���W�v�f�[�^�X�VList</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����׃f�[�^���擾���܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        /// </remarks>
        private int GetPaymentDtl(ref SuplAccPayWork suplAccPayWork, ref ArrayList aCalcPayTotalList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            List<ACalcPayTotalWork> aCalcPayTotalWorkList = new List<ACalcPayTotalWork>();   // �f�[�^�i�[�p
            SqlDataReader myReader = null;

            try
            {
                #region SELECT���쐬
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  PAY.ENTERPRISECODERF");
                selectTxt.AppendLine(" ,PAY.PAYEECODERF");
                selectTxt.AppendLine(" ,PAY.MONEYKINDCODERF");
                selectTxt.AppendLine(" ,(CASE WHEN MONEYKIND.MONEYKINDNAMERF IS NOT NULL THEN MONEYKIND.MONEYKINDNAMERF ELSE '���o�^' END) AS MONEYKINDNAMERF");
                selectTxt.AppendLine(" ,(CASE WHEN MONEYKIND.MONEYKINDDIVRF IS NOT NULL THEN MONEYKIND.MONEYKINDDIVRF ELSE 0 END) AS MONEYKINDDIVRF");
                selectTxt.AppendLine(" ,PAY.PAYMENTRF");
                selectTxt.AppendLine("  FROM");
                selectTxt.AppendLine("    (SELECT");
                selectTxt.AppendLine("    PAYMENTS.ENTERPRISECODERF");
                selectTxt.AppendLine("   ,PAYMENTS.PAYEECODERF");
                selectTxt.AppendLine("   ,PAYMENTDTL.MONEYKINDCODERF");
                selectTxt.AppendLine("   ,SUM((CASE WHEN PAYMENTS.DEBITNOTEDIVRF = 1 THEN PAYMENTDTL.PAYMENTRF * -1 ELSE PAYMENTDTL.PAYMENTRF END))AS PAYMENTRF");
                selectTxt.AppendLine("  FROM PAYMENTSLPRF AS PAYMENTS WITH (READUNCOMMITTED)");
                selectTxt.AppendLine("  INNER JOIN PAYMENTDTLRF AS PAYMENTDTL WITH (READUNCOMMITTED)");
                selectTxt.AppendLine("   ON PAYMENTDTL.ENTERPRISECODERF= PAYMENTS.ENTERPRISECODERF");
                selectTxt.AppendLine("   AND PAYMENTDTL.SUPPLIERFORMALRF= PAYMENTS.SUPPLIERFORMALRF");
                selectTxt.AppendLine("   AND ((PAYMENTS.DEBITNOTEDIVRF != 1 AND PAYMENTS.PAYMENTSLIPNORF = PAYMENTDTL.PAYMENTSLIPNORF) OR");
                selectTxt.AppendLine("        (PAYMENTS.DEBITNOTEDIVRF = 1 AND PAYMENTS.DEBITNOTELINKPAYNORF = PAYMENTDTL.PAYMENTSLIPNORF))");
                selectTxt.AppendLine("  WHERE PAYMENTS.ENTERPRISECODERF=@FINDENTERPRISECODE");
                if (suplAccPayWork.AddUpSecCode.Trim() != "")
                {
                    selectTxt.AppendLine("   AND PAYMENTS.ADDUPSECCODERF=@FINDADDUPSECCODE");
                }
                selectTxt.AppendLine("   AND PAYMENTS.PAYEECODERF=@FINDPAYEECODE");
                selectTxt.AppendLine("   AND (PAYMENTS.ADDUPADATERF<=@FINDADDUPDATE AND PAYMENTS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)");
                selectTxt.AppendLine("   AND  PAYMENTS.LOGICALDELETECODERF=0");
                selectTxt.AppendLine("  GROUP BY");
                selectTxt.AppendLine("    PAYMENTS.ENTERPRISECODERF");
                selectTxt.AppendLine("   ,PAYMENTS.PAYEECODERF");
                selectTxt.AppendLine("   ,PAYMENTDTL.MONEYKINDCODERF");
                selectTxt.AppendLine(") AS PAY");
                selectTxt.AppendLine("LEFT JOIN MONEYKINDURF AS MONEYKIND WITH (READUNCOMMITTED)");
                selectTxt.AppendLine(" ON PAY.ENTERPRISECODERF = MONEYKIND.ENTERPRISECODERF");
                selectTxt.AppendLine(" AND PAY.MONEYKINDCODERF = MONEYKIND.MONEYKINDCODERF");
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    #region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.PayeeCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);
                    if (suplAccPayWork.LaMonCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.LaMonCAddUpUpdDate);
                    #endregion

                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        #region ���|�x���W�v�Z�b�g
                        ACalcPayTotalWork aCalcPayTotalWork = new ACalcPayTotalWork();
                        aCalcPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        aCalcPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                        aCalcPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                        aCalcPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                        aCalcPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                        aCalcPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        if (aCalcPayTotalWork.Payment == 0)
                        {
                            continue;
                        }
                        aCalcPayTotalWork.AddUpSecCode = suplAccPayWork.AddUpSecCode;
                        aCalcPayTotalWork.AddUpDate = suplAccPayWork.AddUpDate;
                        aCalcPayTotalWork.SupplierCd = suplAccPayWork.SupplierCd;
                        aCalcPayTotalList.Add(aCalcPayTotalWork);
                        #endregion
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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �d���f�[�^���擾���܂�
        /// </summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�X�VList</param>
        /// <param name="suplAccPayChildWorkList">�d���攃�|���z�}�X�^�X�VList(�q���R�[�h�p)</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^���擾���܂�</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        /// </remarks>
        private int GetStockSlip(ref SuplAccPayWork suplAccPayWork, ref ArrayList suplAccPayChildWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //SELECT���쐬
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  COUNT(SUPPLIERSLIPNORF) AS STOCKSLIPCOUNT");
                selectTxt.AppendLine(" ,SUM(CASE WHEN SUPPLIERSLIPCDRF = 10 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS THISTIMESTOCKPRICERF");
                selectTxt.AppendLine(" ,SUM(CASE WHEN SUPPLIERSLIPCDRF = 20 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS THISSTCKPRICRGDSRF");
                selectTxt.AppendLine(" ,SUM(STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF");
                selectTxt.AppendLine(" ,SUM(STOCKPRICETAXEXCRF + STCKDISTTLTAXEXCRF) AS OFSTHISTIMESTOCKRF");
                selectTxt.AppendLine(" ,CAST(SUM((STOCKPRICETAXEXCRF + STCKDISTTLTAXEXCRF) * TAX) AS BIGINT) AS OFFSETINTAXRF");
                selectTxt.AppendLine(" FROM(");
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  SLIP.SUPPLIERSLIPNORF");
                selectTxt.AppendLine(" ,SLIP.SUPPLIERSLIPCDRF");
                selectTxt.AppendLine(" ,SLIP.STCKDISTTLTAXEXCRF");
                selectTxt.AppendLine(" ,DTL.STOCKPRICETAXEXCRF");
                selectTxt.AppendLine(" ,(SELECT (CASE");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATERF <= SLIP.STOCKDATERF AND TAXRATEENDDATERF >= SLIP.STOCKDATERF THEN TAXRATERF");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATE2RF <= SLIP.STOCKDATERF AND TAXRATEENDDATE2RF >= SLIP.STOCKDATERF THEN TAXRATE2RF");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATE3RF <= SLIP.STOCKDATERF AND TAXRATEENDDATE3RF >= SLIP.STOCKDATERF THEN TAXRATE3RF");
                selectTxt.AppendLine("      ELSE TAXRATERF END) AS TAXRATERF");
                selectTxt.AppendLine("    FROM TAXRATESETRF");
                selectTxt.AppendLine("    WHERE ENTERPRISECODERF=@ENTERPRISECODE) AS TAX");
                selectTxt.AppendLine("FROM");
                selectTxt.AppendLine("  STOCKSLIPHISTRF AS SLIP");
                selectTxt.AppendLine("  LEFT JOIN");
                selectTxt.AppendLine("  (SELECT");
                selectTxt.AppendLine("    ENTERPRISECODERF");
                selectTxt.AppendLine("   ,SUPPLIERFORMALRF");
                selectTxt.AppendLine("   ,SUPPLIERSLIPNORF");
                selectTxt.AppendLine("   ,SUM(STOCKPRICETAXEXCRF) AS STOCKPRICETAXEXCRF");
                selectTxt.AppendLine("   ,SUM(STOCKPRICETAXINCRF) AS STOCKPRICETAXINCRF");
                selectTxt.AppendLine("   FROM STOCKSLHISTDTLRF AS STDTL");
                selectTxt.AppendLine("   GROUP BY");
                selectTxt.AppendLine("    ENTERPRISECODERF");
                selectTxt.AppendLine("   ,SUPPLIERFORMALRF");
                selectTxt.AppendLine("   ,SUPPLIERSLIPNORF");
                selectTxt.AppendLine("   ) AS DTL");
                selectTxt.AppendLine("   ON  DTL.ENTERPRISECODERF = SLIP.ENTERPRISECODERF");
                selectTxt.AppendLine("   AND DTL.SUPPLIERFORMALRF = SLIP.SUPPLIERFORMALRF");
                selectTxt.AppendLine("   AND DTL.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF");
                selectTxt.AppendLine(" WHERE");
                selectTxt.AppendLine("  SLIP.ENTERPRISECODERF = @ENTERPRISECODE");
                selectTxt.AppendLine("  AND SLIP.LOGICALDELETECODERF = 0");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERFORMALRF = 0");
                if (suplAccPayWork.AddUpSecCode.Trim() != "")
                {
                    selectTxt.AppendLine("  AND SLIP.STOCKSECTIONCDRF = @ADDUPSECCODE");
                }
                selectTxt.AppendLine("  AND SLIP.LOGICALDELETECODERF = 0");
                selectTxt.AppendLine("  AND SLIP.STOCKDATERF >= @STADDUPDATE");
                selectTxt.AppendLine("  AND SLIP.STOCKDATERF <= @EDADDUPDATE");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERCDRF >= @PAYEECODE");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERCDRF <= @PAYEECODE");
                selectTxt.AppendLine(") AS ANNUAL");

                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);
                sqlCommand.Parameters.Clear();

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.EnterpriseCode);

                //�v�㋒�_�R�[�h
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplAccPayWork.AddUpSecCode);

                //�x����R�[�h
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplAccPayWork.SupplierCd);

                //�J�n�v��N����
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@STADDUPDATE", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.StMonCAddUpUpdDate);

                //�I���v��N����
                SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@EDADDUPDATE", SqlDbType.Int);
                paraEdAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplAccPayWork.AddUpDate);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    suplAccPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));
                    suplAccPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                    suplAccPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                    suplAccPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                    suplAccPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                    suplAccPayWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchSuppYearResultSuppResult Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        // --- ADD 2012/11/08 ----------<<<<<
        #endregion  //End ������Search

        #region ������Search
        /// <summary>
        /// �w�肳�ꂽ�����œ������|����S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="suppYearResultAccPayWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����œ������|����S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.26</br>
        private int SearchYearAccPay(ref SuppYearResultAccPayWork suppYearResultAccPayWork, SuppYearResultCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // --- DEL 2012/11/08 ---------->>>>>
                #region �폜
                //string selectTxt = string.Empty;
                //sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //sqlCommand.Parameters.Clear();
                ////SELECT���쐬
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "   SUM(STOCKSLIPCOUNTRF) AS YEARSTOCKSLIPCOUNTRF" + Environment.NewLine;
                //selectTxt += "  ,SUM(THISTIMESTOCKPRICERF) AS YEARTHISTIMESTOCKPRICERF" + Environment.NewLine;
                //selectTxt += "  ,SUM(THISSTCKPRICRGDSRF) AS YEARTHISSTCKPRICRGDSRF" + Environment.NewLine;
                //selectTxt += "  ,SUM(THISSTCKPRICDISRF) AS YEARTHISSTCKPRICDISRF" + Environment.NewLine;
                //selectTxt += "  ,SUM(OFSTHISTIMESTOCKRF) AS YEAROFSTHISTIMESTOCKRF" + Environment.NewLine;
                //selectTxt += "  ,SUM(OFSTHISSTOCKTAXRF) AS YEAROFSTHISSTOCKTAXRF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  SUPLACCPAYRF" + Environment.NewLine;
                //selectTxt += "WHERE" + Environment.NewLine;
                //selectTxt += "      ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //selectTxt += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;
                //// --- ADD 2010/07/20-------------------------------->>>>>
                //if ("Main".Equals(paraWork.MainDiv))
                //{
                //    // --- ADD 2010/07/20--------------------------------<<<<<
                //    selectTxt += "  AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                //    selectTxt += "  AND PAYEECODERF = @PAYEECODE" + Environment.NewLine;
                //    // --- ADD 2010/07/20-------------------------------->>>>>
                //}
                //else
                //{
                //    selectTxt += "  AND ADDUPSECCODERF >= @ADDUPSECCODEST" + Environment.NewLine;
                //    selectTxt += "  AND ADDUPSECCODERF <= @ADDUPSECCODEEND" + Environment.NewLine;

                //    if (0 != paraWork.SupplierCdSt)
                //        selectTxt += "  AND PAYEECODERF >= @PAYEECODEST" + Environment.NewLine;
                //    if (0 != paraWork.SupplierCdEnd)
                //        selectTxt += "  AND PAYEECODERF <= @PAYEECODEEND" + Environment.NewLine;
                //}
                //// --- ADD 2010/07/20--------------------------------<<<<<

                //selectTxt += "  AND SUPPLIERCDRF = 0" + Environment.NewLine;
                //selectTxt += "  AND ADDUPDATERF>=@STADDUPDATE" + Environment.NewLine;
                //selectTxt += "  AND ADDUPDATERF<=@EDADDUPDATE" + Environment.NewLine;

                ////��ƃR�[�h
                //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //// --- ADD 2010/07/20-------------------------------->>>>>
                //if ("Main".Equals(paraWork.MainDiv))
                //{
                //    // --- ADD 2010/07/20--------------------------------<<<<<
                //    //�v�㋒�_�R�[�h
                //    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                //    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);

                //    //�x����R�[�h
                //    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                //    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
                //    // --- ADD 2010/07/20-------------------------------->>>>>
                //}
                //else
                //{
                //    //�v�㋒�_�R�[�hFrom
                //    SqlParameter paraAddUpSecCodeSt = sqlCommand.Parameters.Add("@ADDUPSECCODEST", SqlDbType.NChar);
                //    paraAddUpSecCodeSt.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeSt);

                //    //�v�㋒�_�R�[�hTo
                //    SqlParameter paraAddUpSecCodeEnd = sqlCommand.Parameters.Add("@ADDUPSECCODEEND", SqlDbType.NChar);
                //    paraAddUpSecCodeEnd.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeEnd);

                //    //�x����R�[�hFrom
                //    SqlParameter paraPayeeCodeSt = sqlCommand.Parameters.Add("@PAYEECODEST", SqlDbType.Int);
                //    paraPayeeCodeSt.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdSt);

                //    //�x����R�[�hTo
                //    SqlParameter paraPayeeCodeEnd = sqlCommand.Parameters.Add("@PAYEECODEEND", SqlDbType.Int);
                //    paraPayeeCodeEnd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCdEnd);
                //}
                //// --- ADD 2010/07/20--------------------------------<<<<<

                ////�J�n�v��N����
                //SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@STADDUPDATE", SqlDbType.Int);
                //paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CompanyBiginDate);

                ////�I���v��N����
                //SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@EDADDUPDATE", SqlDbType.Int);
                //paraEdAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SecTotalDay);

                //sqlCommand.CommandText = selectTxt;
                #endregion
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                //SELECT���쐬
                StringBuilder selectTxt = new StringBuilder();
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  COUNT(SUPPLIERSLIPNORF) AS STOCKSLIPCOUNT");
                selectTxt.AppendLine(" ,SUM(CASE WHEN SUPPLIERSLIPCDRF = 10 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS THISTIMESTOCKPRICERF");
                selectTxt.AppendLine(" ,SUM(CASE WHEN SUPPLIERSLIPCDRF = 20 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS THISSTCKPRICRGDSRF");
                selectTxt.AppendLine(" ,SUM(STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF");
                selectTxt.AppendLine(" ,SUM(STOCKPRICETAXEXCRF + STCKDISTTLTAXEXCRF) AS OFSTHISTIMESTOCKRF");
                selectTxt.AppendLine(" ,CAST(SUM((STOCKPRICETAXEXCRF + STCKDISTTLTAXEXCRF) * TAX) AS BIGINT) AS OFFSETINTAXRF");
                selectTxt.AppendLine(" FROM(");
                selectTxt.AppendLine("SELECT");
                selectTxt.AppendLine("  SLIP.SUPPLIERSLIPNORF");
                selectTxt.AppendLine(" ,SLIP.SUPPLIERSLIPCDRF");
                selectTxt.AppendLine(" ,SLIP.STCKDISTTLTAXEXCRF");
                selectTxt.AppendLine(" ,DTL.STOCKPRICETAXEXCRF");
                selectTxt.AppendLine(" ,(SELECT (CASE");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATERF <= SLIP.STOCKDATERF AND TAXRATEENDDATERF >= SLIP.STOCKDATERF THEN TAXRATERF");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATE2RF <= SLIP.STOCKDATERF AND TAXRATEENDDATE2RF >= SLIP.STOCKDATERF THEN TAXRATE2RF");
                selectTxt.AppendLine("      WHEN TAXRATESTARTDATE3RF <= SLIP.STOCKDATERF AND TAXRATEENDDATE3RF >= SLIP.STOCKDATERF THEN TAXRATE3RF");
                selectTxt.AppendLine("      ELSE TAXRATERF END) AS TAXRATERF");
                selectTxt.AppendLine("    FROM TAXRATESETRF");
                selectTxt.AppendLine("    WHERE ENTERPRISECODERF=@ENTERPRISECODE) AS TAX");
                selectTxt.AppendLine("FROM");
                selectTxt.AppendLine("  STOCKSLIPHISTRF AS SLIP");
                selectTxt.AppendLine("  LEFT JOIN");
                selectTxt.AppendLine("  (SELECT");
                selectTxt.AppendLine("    ENTERPRISECODERF");
                selectTxt.AppendLine("   ,SUPPLIERFORMALRF");
                selectTxt.AppendLine("   ,SUPPLIERSLIPNORF");
                selectTxt.AppendLine("   ,SUM(STOCKPRICETAXEXCRF) AS STOCKPRICETAXEXCRF");
                selectTxt.AppendLine("   ,SUM(STOCKPRICETAXINCRF) AS STOCKPRICETAXINCRF");
                selectTxt.AppendLine("   FROM STOCKSLHISTDTLRF AS STDTL");
                selectTxt.AppendLine("   GROUP BY");
                selectTxt.AppendLine("    ENTERPRISECODERF");
                selectTxt.AppendLine("   ,SUPPLIERFORMALRF");
                selectTxt.AppendLine("   ,SUPPLIERSLIPNORF");
                selectTxt.AppendLine("   ) AS DTL");
                selectTxt.AppendLine("   ON  DTL.ENTERPRISECODERF = SLIP.ENTERPRISECODERF");
                selectTxt.AppendLine("   AND DTL.SUPPLIERFORMALRF = SLIP.SUPPLIERFORMALRF");
                selectTxt.AppendLine("   AND DTL.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF");
                selectTxt.AppendLine(" WHERE");
                selectTxt.AppendLine("  SLIP.ENTERPRISECODERF = @ENTERPRISECODE");
                selectTxt.AppendLine("  AND SLIP.LOGICALDELETECODERF = 0");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERFORMALRF = 0");
                if (paraWork.SectionCode.Trim() != "")
                {
                    selectTxt.AppendLine("  AND SLIP.STOCKSECTIONCDRF = @ADDUPSECCODE");
                }
                selectTxt.AppendLine("  AND SLIP.LOGICALDELETECODERF = 0");
                selectTxt.AppendLine("  AND SLIP.STOCKDATERF >= @STADDUPDATE");
                selectTxt.AppendLine("  AND SLIP.STOCKDATERF <= @EDADDUPDATE");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERCDRF >= @PAYEECODE");
                selectTxt.AppendLine("  AND SLIP.SUPPLIERCDRF <= @PAYEECODE");
                selectTxt.AppendLine(") AS ANNUAL");


                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);
                sqlCommand.Parameters.Clear();

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //�v�㋒�_�R�[�h
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);

                //�x����R�[�h
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);

                //�J�n�v��N����
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@STADDUPDATE", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.CompanyBiginDate);

                //�I���v��N����
                SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@EDADDUPDATE", SqlDbType.Int);
                paraEdAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SecTotalDay);
                // --- ADD 2012/11/08 ----------<<<<<

                myReader = sqlCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    suppYearResultAccPayWork.YearStockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));
                    suppYearResultAccPayWork.YearThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                    suppYearResultAccPayWork.YearThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                    suppYearResultAccPayWork.YearThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                    suppYearResultAccPayWork.YearOfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                    suppYearResultAccPayWork.YearOfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (!myReader.IsClosed) myReader.Close();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppYearResultDB.SearchSuppYearResultSuppResult Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        
        }
        #endregion  //End ������Search


        #endregion  //End �c���Ɖ�Search

        #endregion  //End Search
    }

}

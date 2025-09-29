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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ߔN�x���v�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���v�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br></br>
    /// <br>Update Note: 2012/09/19 �c����</br>
    /// <br>�Ǘ��ԍ�   : 2012/09/26�z�M��</br>
    /// <br>             Redmine#32298 �N�G�����s�̃^�C���A�E�g���Ԃ�3600���ɃZ�b�g����</br>
    /// <br>Update Note: 2013/08/16 ���N</br>
    /// <br>             Redmine#39041 #15,#16�̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CustFinancialListResultWorkDB : RemoteDB, ICustFinancialListResultWorkDB
    {
        /// <summary>
        /// ���Ӑ�ߔN�x���v�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public CustFinancialListResultWorkDB()
            :
        base("PMHNB02139D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork", "MTTLSALESSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ���Ӑ�ߔN�x���v�\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���v�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWork">��������</param>
        /// <param name="customInqOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���v�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object custFinancialListResultList, object custFinancialListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            custFinancialListResultList = null;

            CustFinancialListCndtnWork _custFinancialListCndtnWork = custFinancialListCndtnWork as CustFinancialListCndtnWork;

            try
            {
                status = SearchProc(out custFinancialListResultList, _custFinancialListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustFinancialListResultWorkDB.Search Exception=" + ex.Message);
                custFinancialListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���v�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="custFinancialListResultList">��������</param>
        /// <param name="_custFinancialListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ߔN�x���v�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object custFinancialListResultList, CustFinancialListCndtnWork _custFinancialListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            custFinancialListResultList = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _custFinancialListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustFinancialListResultWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            custFinancialListResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_custFinancialListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Update Note : ���N 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16�̑Ή�</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, CustFinancialListCndtnWork _custFinancialListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                int loopcnt = _custFinancialListCndtnWork.Ed_Year.Year - _custFinancialListCndtnWork.St_Year.Year;

                DateTime financialYear = _custFinancialListCndtnWork.Ed_Year;

                for (int i = 0; i <= loopcnt; i++)
                {
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    //SELECT���쐬
                    selectTxt += MakeSelectString(_custFinancialListCndtnWork.PrintDiv);

                    //WHERE���̍쐬
                    selectTxt += MakeWhereString(ref sqlCommand, _custFinancialListCndtnWork, logicalMode);

                    //GROUPBY���쐬
                    selectTxt += MakeGroupByString(_custFinancialListCndtnWork.PrintDiv);

                    sqlCommand.CommandText = selectTxt;

                    // ----- ADD 2012/09/19 �c���� redmine#32298 ----->>>>>
                    //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                    sqlCommand.CommandTimeout = 3600;
                    // ----- ADD 2012/09/19 �c���� redmine#32298 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region ���o����-�l�Z�b�g
                        CustFinancialListResultWork wkCustFinancialListResultWork = new CustFinancialListResultWork();

                        //�i�[����
                        // ----- ADD ���N 2013/08/16 Redmine#39041 ----->>>>>
                        switch (_custFinancialListCndtnWork.PrintDiv)
                        {
                            case 4:
                                {
                                    //�������
                                    wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF")); 
                                    break;
                                }
                            default:
                                {
                                    wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                                    break;
                                }
                        }
                        // ----- ADD ���N 2013/08/16 Redmine#39041 -----<<<<<
                        wkCustFinancialListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        //wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")); // DEL ���N�@2013/08/16�@Redmine#39041
                        wkCustFinancialListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        wkCustFinancialListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        wkCustFinancialListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        wkCustFinancialListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        wkCustFinancialListResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYRF"));
                        wkCustFinancialListResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESRETGOODSPRICERF"));
                        wkCustFinancialListResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMDISCOUNTPRICERF"));
                        wkCustFinancialListResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                        wkCustFinancialListResultWork.FinancialYear = financialYear.Year;
                        #endregion

                        al.Add(wkCustFinancialListResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    _custFinancialListCndtnWork.St_AddUpYearMonth = _custFinancialListCndtnWork.St_AddUpYearMonth.AddYears(-1);
                    _custFinancialListCndtnWork.Ed_AddUpYearMonth = _custFinancialListCndtnWork.Ed_AddUpYearMonth.AddYears(-1);

                    financialYear = financialYear.AddYears(-1);

                    if (!myReader.IsClosed) myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
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

        /// <summary>
        /// ���s�^�C�v�ʂ�SELECT�����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>SELECT��</returns>
        /// <remarks>
        /// <br>Update Note : ���N 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16�̑Ή�</br>
        /// </remarks>
        private string MakeSelectString (Int32 printDiv)
        {
            string retString = string.Empty;

            switch (printDiv)
            {
                case 1:
                    {
                        //���_��
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,0 AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,'' AS CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                        break;
                    }
                case 2:
                    {
                        //���Ӑ拒�_��
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        break;

                    }
                case 3:
                    {
                        //�Ǘ����_��
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,CUS.MNGSECTIONCODERF AS ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,0 AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,'' AS CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS.MNGSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                        break;

                    }
                case 4:
                    {
                        //�������
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        //retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine; // DEL ���N 2013/08/16 Redmine#39041 
                        retString += "        ,CUS.CLAIMSECTIONCODERF" + Environment.NewLine; // ADD ���N 2013/08/16 Redmine#39041 
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,CUS.CLAIMCODERF AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS2.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;

                        /* -----DEL ���N 2013/08/16 Redmine#39041 ----->>>>>
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                         -----DEL ���N 2013/08/16 Redmine#39041 -----<<<<<*/

                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        retString += "LEFT JOIN CUSTOMERRF AS CUS2" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     CUS2.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS2.CUSTOMERCODERF=CUS.CLAIMCODERF" + Environment.NewLine;
                        // ----- ADD ���N 2013/08/16 Redmine#39041 ----->>>>> 
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     CUS2.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS2.CLAIMSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        // ----- ADD ���N 2013/08/16 Redmine#39041 -----<<<<<
                        break;

                    }
                default:
                    {
                        //���Ӑ��
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        break;

                    }
            }

            return retString;
        }

        /// <summary>
        /// ���s�^�C�v�ʂ�GROUP BY����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>GROUP BY��</returns>
        /// <remarks>
        /// <br>Update Note : ���N 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16�̑Ή�</br>
        /// </remarks>
        private string MakeGroupByString(Int32 printDiv)
        {
            string retString = string.Empty;

            switch (printDiv)
            {
                case 1:
                    {
                        //���_��
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;

                        break;

                    }
                case 2:
                    {
                        //���Ӑ拒�_��
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += " ,CUS.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
                case 3:
                    {
                        //�Ǘ����_��
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;

                        break;
                    }
                case 4:
                    {
                        //�������
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        //retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;  // DEL ���N 2013/08/16 Redmine#39041
                        retString += "   ,CUS.CLAIMSECTIONCODERF" + Environment.NewLine; // ADD ���N 2013/08/16 Redmine#39041
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,CUS.CLAIMCODERF" + Environment.NewLine;
                        retString += " ,CUS2.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
                default:
                    {
                        //���Ӑ��
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += " ,CUS.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
            }

            return retString;
        }
        
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustFinancialListCndtnWork _custFinancialListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " MTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_custFinancialListCndtnWork.EnterpriseCode);

            //���яW�v�敪
            retstring += " AND MTL.RSLTTTLDIVCDRF=0" + Environment.NewLine;

            //�]�ƈ��敪
            retstring += " AND MTL.EMPLOYEEDIVCDRF=10" + Environment.NewLine;

            //�v�㋒�_�R�[�h
            if (_custFinancialListCndtnWork.AddUpSecCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _custFinancialListCndtnWork.AddUpSecCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    switch (_custFinancialListCndtnWork.PrintDiv)
                    {
                        case 3:
                            {
                                retstring += " AND CUS.MNGSECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                        case 4:
                            {
                                retstring += " AND CUS.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                        default:
                            {
                    retstring += " AND MTL.ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                    }
                    //retstring += " AND MTL.ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }


            //�J�n���Ӑ�R�[�h
            if (_custFinancialListCndtnWork.St_CustomerCode != 0)
            {
                retstring += " AND MTL.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(_custFinancialListCndtnWork.St_CustomerCode);
            }
           
            //�I�����Ӑ�R�[�h
            if (_custFinancialListCndtnWork.Ed_CustomerCode != 0)
            {
                retstring += " AND MTL.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(_custFinancialListCndtnWork.Ed_CustomerCode);
            }

            //�N���x
            if (_custFinancialListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_custFinancialListCndtnWork.St_AddUpYearMonth);
            }
            if (_custFinancialListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_custFinancialListCndtnWork.Ed_AddUpYearMonth);
            }
            #endregion
            return retstring;
        }
    }
}


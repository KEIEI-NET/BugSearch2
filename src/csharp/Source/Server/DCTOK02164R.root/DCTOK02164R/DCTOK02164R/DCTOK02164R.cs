//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ����d���Δ�\(����N��)DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ����d���Δ�\(����N��)�̎��f�[�^������s���N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012 ���� �[���N
// �� �� ��  2008/11/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012 ���� �[���N
// �C �� ��  2009/05/22  �C�����e : �s��C��(MANTIS 1.5���� ID:13288)
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����d���Δ�\(����N��)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����d���Δ�\(����N��)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note:�s��C��(MANTIS 1.5���� ID:13288)</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.05.22</br>
    /// <br></br>
    /// <br>Update Note:�C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SalesSlipYearContrastResultWorkDB : RemoteDB, ISalesSlipYearContrastResultWorkDB
    {
        /// <summary>
        /// ����d���Δ�\(����N��)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        /// </remarks>
        public SalesSlipYearContrastResultWorkDB()
            :
        base("DCTOK02166D", "Broadleaf.Application.Remoting.ParamData.SalesSlipYearContrastResultWork", "MTTLSALESSTOCKSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ����d���Δ�\(����N��)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(����N��)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWork">��������</param>
        /// <param name="customInqOrderParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(����N��)LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        public int Search(out object salesSlipYearContrastResultList, object salesSlipYearContrastParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesSlipYearContrastResultList = null;

            SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork = salesSlipYearContrastParamWork as SalesSlipYearContrastParamWork;

            try
            {
                status = SearchProc(out salesSlipYearContrastResultList, _salesSlipYearContrastParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipYearContrastResultWorkDB.Search Exception=" + ex.Message);
                salesSlipYearContrastResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(����N��)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="salesSlipYearContrastResultList">��������</param>
        /// <param name="_salesSlipYearContrastParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(����N��)LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        private int SearchProc(out object salesSlipYearContrastResultList, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            salesSlipYearContrastResultList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _salesSlipYearContrastParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipYearContrastResultWorkDB.SearchProc Exception=" + ex.Message);
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

            salesSlipYearContrastResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_salesSlipYearContrastParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";

                sqlCommand.Parameters.Clear();
                //SELECT���쐬
                selectTxt += MakeSelectString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesSlipYearContrastResultWork ResultWork = new SalesSlipYearContrastResultWork();
                    //�i�[����
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));

                    ResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
                    ResultWork.SalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYSTOCK"));
                    ResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                    ResultWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICE"));
                    ResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICE"));
                    ResultWork.StockTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICESTOCK"));
                    ResultWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICE"));

                    ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSALESMONEY"));
                    ResultWork.AnnualSalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSALESMONEYSTOCK"));
                    ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARGROSSPROFIT"));
                    ResultWork.AnnualMoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARMOVESHIPMENTPRICE"));
                    ResultWork.AnnualStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSTOCKTOTALPRICE"));
                    ResultWork.AnnualStockTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSTOCKTOTALPRICESTOCK"));
                    ResultWork.AnnualMoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARMOVEARRIVALPRICE"));
                    #endregion

                    al.Add(ResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
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

        #region SELECT������
        /// <summary>
        /// ���s�^�C�v�ʂ�SELECT�����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>SELECT��</returns>
        private string MakeSelectString(ref SqlCommand sqlCommand, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retString = string.Empty;
            if (retString == "")
            {
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += ",SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += ",YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += ",SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += ",MONTHSLIP.SALESMONEY AS SALESMONEY" + Environment.NewLine;
                retString += ",MONTHSLIP.SALESMONEYSTOCK AS SALESMONEYSTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.GROSSPROFIT AS GROSSPROFIT" + Environment.NewLine;
                retString += ",MONTHSLIP.MOVESHIPMENTPRICE AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.STOCKTOTALPRICE AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.STOCKTOTALPRICESTOCK AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.MOVEARRIVALPRICE AS MOVEARRIVALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.SALESMONEY AS YEARSALESMONEY" + Environment.NewLine;
                retString += ",YEARSLIP.SALESMONEYSTOCK AS YEARSALESMONEYSTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.GROSSPROFIT AS YEARGROSSPROFIT" + Environment.NewLine;
                retString += ",YEARSLIP.MOVESHIPMENTPRICE AS YEARMOVESHIPMENTPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.STOCKTOTALPRICE AS YEARSTOCKTOTALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.STOCKTOTALPRICESTOCK AS YEARSTOCKTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.MOVEARRIVALPRICE AS YEARMOVEARRIVALPRICE" + Environment.NewLine;

                #region �����f�[�^�W�v
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT " + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                // �C�� 2009/05/22 >>>
                //retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                // �C�� 2009/05/22 <<<
                //retString += "  ,SUM(MOVESHIPMENTPRICERF)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVESHIPMENTPRICERF ELSE 0 END)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                //retString += "  ,SUM(MOVEARRIVALPRICERF) AS MOVEARRIVALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVEARRIVALPRICERF ELSE 0 END) AS MOVEARRIVALPRICE" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "  MTTLSALESSTOCKSLIPRF " + Environment.NewLine;
                retString += "  MTTLSALESSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region �����f�[�^�W�v
                // �C�� 2009/05/22 �����f�[�^������ɒ��o����Ȃ����߁@�����������̌����ł͂Ȃ��@�����������̌����ɏC�� >>>
                //retString += "LEFT JOIN" + Environment.NewLine;
                retString += "RIGHT JOIN" + Environment.NewLine;
                // �C�� 2009/05/22 <<<
                retString += "(" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                //retString += "  ,SUM(GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                //retString += "  ,SUM(MOVESHIPMENTPRICERF)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVESHIPMENTPRICERF ELSE 0 END)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVEARRIVALPRICERF ELSE 0 END) AS MOVEARRIVALPRICE" + Environment.NewLine;
                //retString += "  ,SUM(MOVEARRIVALPRICERF) AS MOVEARRIVALPRICE" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "  MTTLSALESSTOCKSLIPRF " + Environment.NewLine;
                retString += "  MTTLSALESSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;                
                retString += "ON MONTHSLIP.ADDUPSECCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += "AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN
                retString += " LEFT JOIN " + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += " SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += " LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += " SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SECINF.SECTIONCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                #endregion
            }            

            return retString;
        }
        #endregion

        #region Where�吶��
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode, int MakeMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;
            if (MakeMode == 0)
            {
                //��ƃR�[�h
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesSlipYearContrastParamWork.EnterpriseCode);

                //�v�㋒�_�R�[�h
                if (_salesSlipYearContrastParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesSlipYearContrastParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    retstring += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    retstring += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }


                //�J�n�d����R�[�h
                if (_salesSlipYearContrastParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StSupplierCd);
                }

                //�I���d����R�[�h
                if ((_salesSlipYearContrastParamWork.EdSupplierCd != 0) && (_salesSlipYearContrastParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdSupplierCd);
                }

                //�Ώۓ��t
                if (_salesSlipYearContrastParamWork.StAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StAddUpYearMonth);
                }
                if (_salesSlipYearContrastParamWork.EdAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdAddUpYearMonth);
                }
            }
            else
            {
                //��ƃR�[�h
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                //�v�㋒�_�R�[�h
                if (_salesSlipYearContrastParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesSlipYearContrastParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    retstring += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    retstring += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }


                //�J�n�d����R�[�h
                if (_salesSlipYearContrastParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                }

                //�I���d����R�[�h
                if ((_salesSlipYearContrastParamWork.EdSupplierCd != 0) && (_salesSlipYearContrastParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                }

                //�Ώۓ��t
                if (_salesSlipYearContrastParamWork.StAnnualAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraStAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@STANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraStAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StAnnualAddUpYearMonth);
                }
                if (_salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraEdAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@EDANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth);
                }
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}


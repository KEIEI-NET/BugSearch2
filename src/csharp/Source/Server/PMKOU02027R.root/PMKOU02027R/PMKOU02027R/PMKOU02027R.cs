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
    /// �d�����͕\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͕\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.13</br>
    /// <br></br>
    /// <br>Update Note: �W�v���e�[�u���̕ύX</br>
    /// <br>Update Note: ����d�������W�v�f�[�^�ˎd�������W�v�f�[�^</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.01.08</br>
    /// <br></br>
    /// <br>Update Note: �C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2011/08/01</br>
    /// </remarks>
    [Serializable]
    public class SlipHistAnalyzeResultWorkDB : RemoteDB, ISlipHistAnalyzeResultWorkDB
    {
        /// <summary>
        /// �d�����͕\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>
        public SlipHistAnalyzeResultWorkDB()
            :
        base("PMKOU02029D", "Broadleaf.Application.Remoting.ParamData.SlipHistAnalyzeResultWork", "MTTLSALESSTOCKSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �d�����͕\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d�����͕\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWork">��������</param>
        /// <param name="customInqOrderParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d�����͕\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.13</br>
        public int Search(out object slipHistAnalyzeResultList, object slipHistAnalyzeParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            slipHistAnalyzeResultList = null;

            SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork = slipHistAnalyzeParamWork as SlipHistAnalyzeParamWork;

            try
            {
                status = SearchProc(out slipHistAnalyzeResultList, _slipHistAnalyzeParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipHistAnalyzeResultWorkDB.Search Exception=" + ex.Message);
                slipHistAnalyzeResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d�����͕\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="slipHistAnalyzeResultList">��������</param>
        /// <param name="_slipHistAnalyzeParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d�����͕\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.13</br>
        private int SearchProc(out object slipHistAnalyzeResultList, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            slipHistAnalyzeResultList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _slipHistAnalyzeParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipHistAnalyzeResultWorkDB.SearchProc Exception=" + ex.Message);
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

            slipHistAnalyzeResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_slipHistAnalyzeParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += MakeSelectString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SlipHistAnalyzeResultWork ResultWork = new SlipHistAnalyzeResultWork();
                    //�i�[����

                    // �C�� 2009.01.08 >>>
                    //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    // �C�� 2009.01.08 <<<

                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.TotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICE"));
                    ResultWork.RetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGOODSPRICE"));
                    ResultWork.TotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALDISCOUNT"));
                    ResultWork.TotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICESTOCK"));
                    ResultWork.TotalPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICETOTAL"));
                    ResultWork.AnnualTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICE"));
                    ResultWork.AnnualRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALRETGOODSPRICE"));
                    ResultWork.AnnualTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALDISCOUNT"));
                    ResultWork.AnnualTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICESTOCK"));
                    ResultWork.AnnualTotalPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICETOTAL"));
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
        private string MakeSelectString(ref SqlCommand sqlCommand, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retString = string.Empty;
            if (retString == "")
            {
                // �C�� 2009.01.08 >>>
                #region DEL 2009.01.08
                /*
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += ",SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += ",YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += ",SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.RETGOODSPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALDISCOUNT" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICESTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICETOTAL" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICETOTAL" + Environment.NewLine;

                #region �����f�[�^�W�v
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF - STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALTOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM MTTLSALESSTOCKSLIPRF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 1);
                retString += "GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region �����f�[�^�W�v
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF - STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS RETGOODSPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALDISCOUNT" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS TOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS TOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM MTTLSALESSTOCKSLIPRF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 0);
                retString += "GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;
                retString += "ON " + Environment.NewLine;
                retString += "MONTHSLIP.ADDUPSECCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += "AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += "ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += "ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SECINF.SECTIONCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                #endregion
                */
                #endregion 

                #region SELECT���쐬
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                retString += " ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += " ,YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICE" + Environment.NewLine;
                retString += " ,MONTHSLIP.RETGOODSPRICE" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALDISCOUNT" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICETOTAL" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICE" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;

                #region �����f�[�^�W�v
                retString += "  SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF ELSE 0 END) AS ANNUALTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS ANNUALTOTALPRICETOTAL  " + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "   MTTLSTOCKSLIPRF" + Environment.NewLine;
                retString += "   MTTLSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region �����f�[�^�W�v
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += " SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF ELSE 0 END) AS TOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS RETGOODSPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALDISCOUNT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS TOTALPRICESTOCK" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS TOTALPRICETOTAL  " + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "   MTTLSTOCKSLIPRF" + Environment.NewLine;
                retString += "   MTTLSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;
                retString += " ON MONTHSLIP.STOCKSECTIONCDRF = YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                retString += " AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN��
                retString += "LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += " SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += " SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SECINF.SECTIONCODERF = YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                #endregion

                #region ���і����r��
                retString += "WHERE" + Environment.NewLine;
                retString += " MONTHSLIP.TOTALPRICE != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.RETGOODSPRICE != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALDISCOUNT != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALPRICESTOCK != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALPRICETOTAL != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICE != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALRETGOODSPRICE != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALDISCOUNT != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICESTOCK != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICETOTAL != 0" + Environment.NewLine;
                #endregion

                #endregion
                // �C�� 2009.01.08 <<<
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
        private string MakeWhereString(ref SqlCommand sqlCommand, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode, int MakeMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;
            if (MakeMode == 0)
            {
                //��ƃR�[�h
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_slipHistAnalyzeParamWork.EnterpriseCode);

                //�v�㋒�_�R�[�h
                if (_slipHistAnalyzeParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _slipHistAnalyzeParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        // �C�� 2009.01.08 >>>
                        //retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        retstring += " AND STOCKSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        // �C�� 2009.01.08 <<<
                    }
                }


                //�J�n�d����R�[�h
                if (_slipHistAnalyzeParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StSupplierCd);
                }

                //�I���d����R�[�h
                if ((_slipHistAnalyzeParamWork.EdSupplierCd != 0) && (_slipHistAnalyzeParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdSupplierCd);
                }

                //�Ώۓ��t
                if (_slipHistAnalyzeParamWork.StAddUpYearMonth != 0)
                {
                    // �C�� 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    // �C�� 2009.01.08 <<<

                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StAddUpYearMonth);
                }
                if (_slipHistAnalyzeParamWork.EdAddUpYearMonth != 0)
                {
                    // �C�� 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    // �C�� 2009.01.08 <<<
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdAddUpYearMonth);
                }
            }
            else
            {
                //��ƃR�[�h
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                //�v�㋒�_�R�[�h
                if (_slipHistAnalyzeParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _slipHistAnalyzeParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        // �C�� 2009.01.08 >>>
                        //retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        retstring += " AND STOCKSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        // �C�� 2009.01.08 <<<
                    }
                }


                //�J�n�d����R�[�h
                if (_slipHistAnalyzeParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                }

                //�I���d����R�[�h
                if ((_slipHistAnalyzeParamWork.EdSupplierCd != 0) && (_slipHistAnalyzeParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                }

                //�Ώۓ��t
                if (_slipHistAnalyzeParamWork.StAnnualAddUpYearMonth != 0)
                {
                    // �C�� 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    // �C�� 2009.01.08 <<<

                    SqlParameter paraStAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@STANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraStAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StAnnualAddUpYearMonth);
                }
                if (_slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth != 0)
                {
                    // �C�� 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    // �C�� 2009.01.08 <<<
                    SqlParameter paraEdAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@EDANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth);
                }
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}


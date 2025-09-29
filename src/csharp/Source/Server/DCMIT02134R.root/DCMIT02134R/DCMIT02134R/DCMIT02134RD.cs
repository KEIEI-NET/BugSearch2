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

namespace Broadleaf.Application.Remoting
{
    class MTtlStSlipSupl : MTtlStSlipBase, IMTtlStSlip
    {
        #region [SuplMTtlStSlip�p Select����������]
        /// <summary>
        /// �d����ʎd�������W�v�f�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns>�d����ʎd�������W�v�f�[�^�pSELECT��</returns>
        /// <br>Note       : �d����ʎd�������W�v�f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update     : 30290 ���Ӑ�E�d����؂蕪��</br>
        /// <br>Data       : 2008.04.23</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            return MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        /// <summary>
        /// �d����ʎd�������W�v�f�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns>�d����ʎd�������W�v�f�[�^�pSELECT��</returns>
        /// <br>Note       : �d����ʎd�������W�v�f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update     : 30290 ���Ӑ�E�d����؂蕪��</br>
        /// <br>Data       : 2008.04.23</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            Boolean bSection = false;
            Boolean bSeller = false;
            Boolean bMaker = false;

            if (paramWork.TtlType != 0)
                bSection = true;
            if (paramWork.TotalType == (int)TotalTypes.n1_Seller || paramWork.TotalType == (int)TotalTypes.n5_SellerAndMaker)
                bSeller = true;
            if (paramWork.TotalType == (int)TotalTypes.n5_SellerAndMaker)
                bMaker = true;

            string Text = "";

            Text += "SELECT "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSection, "Y.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + IFBy(bSeller, "Y.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bSeller, "Y.SUPPLIERSNMRF AS SUPPLIERSNMRF, ")
                + IFBy(bMaker, "Y.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + IFBy(bMaker, "Y.MAKERNAMERF AS MAKERNAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF AS MS_TOTALSTOCKCOUNTRF, "
                + "MA.MAS_STOCKTOTALPRICERF AS MS_STOCKTOTALPRICERF, "
                + "MB.MBS_STOCKRETGOODSPRICERF AS MS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF AS MS_STOCKTOTALDISCOUNTRF, "
                + "SUM(Y.TOTALSTOCKCOUNTRF) AS YS_TOTALSTOCKCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF AS YS_STOCKTOTALPRICERF, "
                + "YB.YBS_STOCKRETGOODSPRICERF AS YS_STOCKRETGOODSPRICERF, "
                + "SUM(Y.STOCKTOTALDISCOUNTRF) AS YS_STOCKTOTALDISCOUNTRF "
                + "FROM SUPLMTTLSTSLIPRF Y ";

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "YA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSeller, "YA.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bMaker, "YA.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(YA.STOCKTOTALPRICERF) AS YAS_STOCKTOTALPRICERF "
                + "FROM SUPLMTTLSTSLIPRF YA "
                + MakeWhereString(ref sqlCommand, paramWork, "YA", TermDiv.YearBound)
                + "AND YA.SUPPLIERSLIPCDRF=10 "     // �d��
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "YA.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", YA.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", YA.GOODSMAKERCDRF "))
                + ") YA "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=YA.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, "AND Y.SUPPLIERCDRF=YA.SUPPLIERCDRF ")
                    + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=YA.GOODSMAKERCDRF "));

            Text+= "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "YB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSeller, "YB.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bMaker, "YB.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(YB.STOCKRETGOODSPRICERF) AS YBS_STOCKRETGOODSPRICERF "
                + "FROM SUPLMTTLSTSLIPRF YB "
                + MakeWhereString(ref sqlCommand, paramWork, "YB", TermDiv.YearBound)
                + "AND YB.SUPPLIERSLIPCDRF=20 "     // �ԕi
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "YB.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", YB.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", YB.GOODSMAKERCDRF "))
                + ") YB "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=YB.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, "AND Y.SUPPLIERCDRF=YB.SUPPLIERCDRF ")
                    + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=YB.GOODSMAKERCDRF "));

            Text+= "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "M.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSeller, "M.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bMaker, "M.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(M.TOTALSTOCKCOUNTRF) AS MS_TOTALSTOCKCOUNTRF, "
                + "SUM(M.STOCKTOTALDISCOUNTRF) AS MS_STOCKTOTALDISCOUNTRF "
                + "FROM SUPLMTTLSTSLIPRF M "
                + MakeWhereString(ref sqlCommand, paramWork, "M", TermDiv.MonthBound)
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "M.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", M.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", M.GOODSMAKERCDRF "))
                + ") M "
                + "ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=M.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, "AND Y.SUPPLIERCDRF=M.SUPPLIERCDRF ")
                    + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=M.GOODSMAKERCDRF "));

            Text+= "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, " MA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSeller, "MA.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bMaker, "MA.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(MA.STOCKTOTALPRICERF) AS MAS_STOCKTOTALPRICERF "
                + "FROM SUPLMTTLSTSLIPRF MA "
                + MakeWhereString(ref sqlCommand, paramWork, "MA", TermDiv.YearBound)
                + "AND MA.SUPPLIERSLIPCDRF=10 "     // �d��
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "MA.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", MA.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", MA.GOODSMAKERCDRF "))
                + ") MA "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=MA.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, "AND Y.SUPPLIERCDRF=MA.SUPPLIERCDRF ")
                    + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=MA.GOODSMAKERCDRF "));

            Text+= "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, " MB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSeller, "MB.SUPPLIERCDRF AS SUPPLIERCDRF, ")
                + IFBy(bMaker, "MB.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(MB.STOCKRETGOODSPRICERF) AS MBS_STOCKRETGOODSPRICERF "
                + "FROM SUPLMTTLSTSLIPRF MB "
                + MakeWhereString(ref sqlCommand, paramWork, "MB", TermDiv.YearBound)
                + "AND MB.SUPPLIERSLIPCDRF=20 "     // �ԕi
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "MB.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", MB.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", MB.GOODSMAKERCDRF "))
                + ") MB "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=MB.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, "AND Y.SUPPLIERCDRF=MB.SUPPLIERCDRF ")
                    + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=MB.GOODSMAKERCDRF "));

            Text+= MakeWhereString(ref sqlCommand, paramWork, "Y", TermDiv.YearBound)
                + "GROUP BY "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF, ")
                + IFBy(bSection, "Y.SECTIONGUIDENMRF, ")
                + IFBy(bSeller, "Y.SUPPLIERCDRF, Y.SUPPLIERCDRF, ")
                + IFBy(bMaker, "Y.GOODSMAKERCDRF, Y.MAKERNAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF, MA.MAS_STOCKTOTALPRICERF, MB.MBS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF, YB.YBS_STOCKRETGOODSPRICERF "
                + "ORDER BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF ")
                    + IFBy(bSeller, ", Y.SUPPLIERCDRF ")
                    + IFBy(bMaker, ", Y.GOODSMAKERCDRF "));

            return Text;
        }
        #endregion  //[SuplMTtlStSlip�p Select����������]

        #region [SuplMTtlStSlip�p Where�吶������]
        /// <summary>
        /// �d����ʎd�������W�v�f�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <param name="refName">�e�[�u����</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <returns>�d����ʎd�������W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : �d����ʎd�������W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update     : 30290 ���Ӑ�E�d����؂蕪��</br>
        /// <br>Data       : 2008.04.23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork, string refName, TermDiv termDiv)
        {
            string text = "WHERE ";
            //�Œ����
            //��ƃR�[�h
            text += refName + ".ENTERPRISECODERF=@ENTERPRISECODE ";
            if (sqlCommand.Parameters.IndexOf("@ENTERPRISECODE") < 0)
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            }

            //�_���폜�敪
            //text += "AND " + refName + ".LOGICALDELETECODERF=0 ";

            //������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //���_�R�[�h
            if (paramWork.TtlType != 0)
            {
                //���_�ʏW�v�̏ꍇ�i�S�ЏW�v�łȂ��ꍇ�j
                if (paramWork.SectionCodes != null &&
                    paramWork.SectionCodes.Length > 0)
                {
                    if (paramWork.SectionCodes[0] != null &&
                        paramWork.SectionCodes[0] != "")
                    {
                        text += "AND " + refName + ".STOCKSECTIONCDRF IN (";
                        text += "'" + paramWork.SectionCodes[0].ToString() + "'";
                        for (int i = 1; i < paramWork.SectionCodes.Length; i++)
                        {
                            if (paramWork.SectionCodes[i] == null)
                                break;
                            text += ", '" + paramWork.SectionCodes[i].ToString() + "'";
                        }
                        text += ") ";
                    }
                }
            }

            switch (termDiv)
            {
                case TermDiv.MonthBound:     // �w�茎�͈�

                    if (paramWork.StockDateYmSt != DateTime.MinValue)
                    {
                        int addupYMSt = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.StockDateYmSt);
                        text += " AND " + refName + ".STOCKDATEYMRF>=" + addupYMSt.ToString() + " ";
                    }
                    if (paramWork.StockDateYmEd != DateTime.MinValue)
                    {
                        if (paramWork.StockDateYmSt == DateTime.MinValue)
                        {
                            text += " AND (" + refName + ".STOCKDATEYMRF IS NULL OR";
                        }
                        else
                        {
                            text += " AND";
                        }

                        int addupYMEd = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.StockDateYmEd);
                        text += " " + refName + ".STOCKDATEYMRF<=" + addupYMEd.ToString() + " ";

                        if (paramWork.StockDateYmSt == DateTime.MinValue)
                        {
                            text += " ) ";
                        }
                    }
                    break;
                case TermDiv.YearBound:     // ���͈�
                    if (paramWork.AnnualStockDateYmSt != DateTime.MinValue)
                    {
                        int addupYMSt = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.AnnualStockDateYmSt);
                        text += " AND " + refName + ".STOCKDATEYMRF>=" + addupYMSt.ToString() + " ";
                    }
                    if (paramWork.AnnualStockDateYmEd != DateTime.MinValue)
                    {
                        if (paramWork.AnnualStockDateYmSt == DateTime.MinValue)
                        {
                            text += " AND (" + refName + ".STOCKDATEYMRF IS NULL OR";
                        }
                        else
                        {
                            text += " AND";
                        }

                        int addupYMEd = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.AnnualStockDateYmEd);
                        text += " " + refName + ".STOCKDATEYMRF<=" + addupYMEd.ToString() + " ";

                        if (paramWork.AnnualStockDateYmSt == DateTime.MinValue)
                        {
                            text += " ) ";
                        }
                    }
                    break;
                default:
                    break;
            }

            //�J�n�d����R�[�h
            if (paramWork.SupplierCdSt != 0)
            {
                text += "AND " + refName + ".SUPPLIERCDRF>=@ST_SUPPLIERCD ";
                if (sqlCommand.Parameters.IndexOf("@ST_SUPPLIERCD") < 0)
                {
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCdSt);
                }
            }

            //�I���d����R�[�h
            if (paramWork.SupplierCdEd != 0)
            {
                text += "AND " + refName + ".SUPPLIERCDRF<=@ED_SUPPLIERCD ";
                if (sqlCommand.Parameters.IndexOf("@ED_SUPPLIERCD") < 0)
                {
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCdEd);
                }
            }

            //�J�n���[�J�[�R�[�h
            if (paramWork.GoodsMakerCdSt != 0)
            {
                text += "AND " + refName + ".GOODSMAKERCDRF>=@ST_GOODSMAKERCD ";
                if (sqlCommand.Parameters.IndexOf("@ST_GOODSMAKERCD") < 0)
                {
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@ST_GOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCdSt);
                }
            }

            //�I�����[�J�[�R�[�h
            if (paramWork.GoodsMakerCdEd != 0)
            {
                text += "AND " + refName + ".GOODSMAKERCDRF<=@ED_GOODSMAKERCD ";
                if (sqlCommand.Parameters.IndexOf("@ED_GOODSMAKERCD") < 0)
                {
                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@ED_GOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCdEd);
                }
            }

            return text;
        }
        #endregion //[SuplMTtlStSlip�p Where�吶������]

        #region [CopyToResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns>StockMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update     : 30290 ���Ӑ�E�d����؂蕪��</br>
        /// <br>Data       : 2008.04.23</br>
        /// </remarks>
        public StockMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, StockMonthYearReportParamWork paramWork)
        {
            return CopyToResultWorkFromReader(ref myReader, paramWork);
        }
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns>StockMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update     : 30290 ���Ӑ�E�d����؂蕪��</br>
        /// <br>Data       : 2008.04.23</br>
        /// </remarks>
        private StockMonthYearReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, StockMonthYearReportParamWork paramWork)
        {
            StockMonthYearReportResultWork resultWork = new StockMonthYearReportResultWork();

            int TotalType = paramWork.TotalType;

            if (paramWork.TtlType != 0)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }

            if (TotalType == (int)TotalTypes.n1_Seller || TotalType == (int)TotalTypes.n5_SellerAndMaker)
            {
                resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            }

            if (TotalType == (int)TotalTypes.n5_SellerAndMaker)
            {
                resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            }

            resultWork.MonthTotalStockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MS_TOTALSTOCKCOUNTRF"));
            resultWork.MonthStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKTOTALPRICERF"));
            resultWork.MonthStockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKRETGOODSPRICERF"));
            resultWork.MonthStockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKTOTALDISCOUNTRF"));

            resultWork.AnnualTotalStockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("YS_TOTALSTOCKCOUNTRF"));
            resultWork.AnnualStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKTOTALPRICERF"));
            resultWork.AnnualStockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKRETGOODSPRICERF"));
            resultWork.AnnualStockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKTOTALDISCOUNTRF"));

            return resultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]

    }
}

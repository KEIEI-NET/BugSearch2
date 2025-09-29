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
    class MTtlSaSlipCust : MTtlSaSlipBase, IMTtlSaSlip
    {

        #region [���Ӑ�ʗp Select��]
        /// <summary>
        /// ���Ӑ�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���Ӑ�ʗpSELECT��</returns>
        /// <br>Note       : ���Ӑ�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork, logicalMode);
        }
        #endregion  //[���Ӑ�ʗp Select��]

        #region [���Ӑ�ʗp Select����������]
        /// <summary>
        /// ���Ӑ�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���Ӑ�ʗpSELECT��</returns>
        /// <br>Note       : ���Ӑ�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.09.08</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";
            string Tblnm = "CSTMR";

            switch (CndtnWork.PrintType)
            {
                case 30://���_+���Ӑ�
                    {
                        Tblnm = "CSTMR";
                        break;
                    }
                case 31://���_+�Ǝ�
                    {
                        Tblnm = "USGDUB";
                        break;
                    }
                case 32://���_+�̔��ر
                    {
                        Tblnm = "USGDUS";
                        break;
                    }
            }


            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   "+Tblnm+".UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,CSLST.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SCINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "  ,CSLST.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "  ,CSTMR.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "  ,CSLST.BUSINESSTYPECODERF" + Environment.NewLine;
            selectTxt += "  ,USGDUB.GUIDENAMERF AS BUSINESSTYPECODENAME" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESAREACODERF" + Environment.NewLine;
            selectTxt += "  ,USGDUS.GUIDENAMERF AS SALESAREACODENAME" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY1" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY2" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY3" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY4" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY5" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY6" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY7" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY8" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY9" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY10" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY11" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETMONEY12" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT1" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT2" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT3" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT4" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT5" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT6" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT7" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT8" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT9" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT10" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT11" + Environment.NewLine;
            selectTxt += "  ,CSLST.SALESTARGETPROFIT12" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            //���Ӑ�ʔ���ڕW�ݒ�}�X�^
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "    CSLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "   ,CSLSTSUB.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.BUSINESSTYPECODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.SALESAREACODERF" + Environment.NewLine;
            int setDate = CndtnWork.TargetDivideCodeSt;
            for (int i = 1; i <= 12; i++)
            {
                //����ڕW���z
                selectTxt += "   ,SUM((CASE WHEN CSLSTSUB.TARGETDIVIDECODERF='" + setDate.ToString() + "' THEN CSLSTSUB.SALESTARGETMONEYRF ELSE 0 END)) AS SALESTARGETMONEY" + i.ToString() + Environment.NewLine;
                //����ڕW�e���z
                selectTxt += "   ,SUM((CASE WHEN CSLSTSUB.TARGETDIVIDECODERF='" + setDate.ToString() + "' THEN CSLSTSUB.SALESTARGETPROFITRF ELSE 0 END)) AS SALESTARGETPROFIT" + i.ToString() + Environment.NewLine;

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }
            selectTxt += "  FROM CUSTSALESTARGETRF AS CSLSTSUB" + Environment.NewLine;

            //WHERE��
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "CSLSTSUB", "", logicalMode);

            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "    CSLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "   ,CSLSTSUB.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.BUSINESSTYPECODERF" + Environment.NewLine;
            selectTxt += "   ,CSLSTSUB.SALESAREACODERF" + Environment.NewLine;

            selectTxt += " ) AS CSLST" + Environment.NewLine;

            #region [JOIN]
            //���_���ݒ�}�X�^
            selectTxt += " LEFT JOIN SECINFOSETRF SCINF" + Environment.NewLine;
            selectTxt += " ON  SCINF.ENTERPRISECODERF=CSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SCINF.SECTIONCODERF=CSLST.SECTIONCODERF" + Environment.NewLine;

            //���Ӑ�}�X�^
            selectTxt += " LEFT JOIN CUSTOMERRF CSTMR" + Environment.NewLine;
            selectTxt += " ON  CSTMR.ENTERPRISECODERF=CSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CSTMR.CUSTOMERCODERF=CSLST.CUSTOMERCODERF" + Environment.NewLine;

            //���[�U�[�K�C�h�}�X�^(�{�f�B)���Ǝ햼�̎擾�p
            selectTxt += " LEFT JOIN USERGDBDURF USGDUB" + Environment.NewLine;
            selectTxt += " ON  USGDUB.ENTERPRISECODERF=CSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUB.GUIDECODERF=CSLST.BUSINESSTYPECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUB.USERGUIDEDIVCDRF=33" + Environment.NewLine;

            //���[�U�[�K�C�h�}�X�^(�{�f�B)���n�於�̎擾�p
            selectTxt += " LEFT JOIN USERGDBDURF USGDUS" + Environment.NewLine;
            selectTxt += " ON  USGDUS.ENTERPRISECODERF=CSLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDUS.GUIDECODERF=CSLST.SALESAREACODERF" + Environment.NewLine;
            selectTxt += " AND USGDUS.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            #endregion  //[JOIN]


            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[���Ӑ�ʗp Select����������]

        #region [Where�� ��������]
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�pWHERE�� �������� (���v�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sGSMSLP">�e�[�u�������́F���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sBLGCDU">�e�[�u�������́FBL���i�R�[�h�}�X�^</param>
        /// <param name="sBLGRPU">�e�[�u�������́FBL�O���[�v�}�X�^</param>
        /// <param name="iRsltTtlDivCd">�݌Ɏ�񂹋敪</param>
        /// <returns>���Ӑ�ʔ���ڕW�ݒ�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, string TblNm1, string TblNm2, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;
            //��ƃR�[�h
            retstring += " " + TblNm1 + ".ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (CndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in CndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND " + TblNm1 + ".SECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�ڕW�Δ�敪
            retstring += " AND " + TblNm1 + ".TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintType);

            //�ڕW�ݒ�敪�@
            retstring += " AND " + TblNm1 + ".TARGETSETCDRF= 10" + Environment.NewLine;

            //�Ώ۔N���J�n
            if (CndtnWork.TargetDivideCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF>=@TARGETDIVIDECODERFST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFST", SqlDbType.NChar);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeSt));
            }
            //�Ώ۔N���I��
            if (CndtnWork.TargetDivideCodeEd != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF<=@TARGETDIVIDECODERFED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFED", SqlDbType.NChar);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeEd));
            }

            //���Ӑ�J�n
            if (CndtnWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".CUSTOMERCODERF>=@CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeSt);
            }
            if ((CndtnWork.CustomerCodeEd != 99999999) && (CndtnWork.CustomerCodeEd != 0))
            {
                retstring += " AND " + TblNm1 + ".CUSTOMERCODERF<=@CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@SALESCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            //�Ǝ�R�[�h�J�n
            if (CndtnWork.BusinessTypeCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".BUSINESSTYPECODERF>=@BUSINESSTYPECODEST" + Environment.NewLine;
                SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@BUSINESSTYPECODEST", SqlDbType.Int);
                paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BusinessTypeCodeSt);
            }
            if ((CndtnWork.BusinessTypeCodeEd != 9999) && (CndtnWork.BusinessTypeCodeEd != 0))
            {
                retstring += " AND " + TblNm1 + ".BUSINESSTYPECODERF<=@BUSINESSTYPECODEED" + Environment.NewLine;
                SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@BUSINESSTYPECODEED", SqlDbType.Int);
                paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BusinessTypeCodeEd);
            }
            //�n��R�[�h�J�n
            if (CndtnWork.SalesAreaCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".SALESAREACODERF>=@SALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesAreaCodeSt);
            }
            if ((CndtnWork.SalesAreaCodeEd != 9999) && (CndtnWork.SalesAreaCodeEd != 0)) 
            {
                retstring += " AND " + TblNm1 + ".SALESAREACODERF<=@SALESAREACODEED" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesAreaCodeEd);
            }
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[Where�� ��������]

        #region [CopyToSalesRsltListResultWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader���� �ďo]

        #region [CopyToSalesRsltListResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        private SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
        {
            #region [���o����-�l�Z�b�g]
            SalTrgtPrintResultWork ResultWork = new SalTrgtPrintResultWork();
            ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            ResultWork.BusinessTypeCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPECODENAME"));
            ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            ResultWork.SalesAreaCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREACODENAME"));
            ResultWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1"));
            ResultWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2"));
            ResultWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3"));
            ResultWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4"));
            ResultWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5"));
            ResultWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6"));
            ResultWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7"));
            ResultWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8"));
            ResultWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9"));
            ResultWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10"));
            ResultWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11"));
            ResultWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12"));
            ResultWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1"));
            ResultWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2"));
            ResultWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3"));
            ResultWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4"));
            ResultWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5"));
            ResultWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6"));
            ResultWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7"));
            ResultWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8"));
            ResultWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9"));
            ResultWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10"));
            ResultWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11"));
            ResultWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12"));
            #endregion  //[���o����-�l�Z�b�g]
            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]

    }
}

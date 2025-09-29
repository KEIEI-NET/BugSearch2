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
    class CustPrtPprBlTblRsltQuery : ICustPrtPprOutput
    {
        #region [CustPrtPprBlTblRsltWork�p SELECT��]
        /// <summary>
        /// �c���ꗗ�̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���ꗗ�̃��X�g���oSELECT��</returns>
        /// <br>Note       : �c���ꗗ�̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int SrchKndDiv, bool CreditMng, ConstantManagement.LogicalMode logicalMode)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        {
            CustPrtPprBlnceWork _custPrtPprBlnceWork = paramWork as CustPrtPprBlnceWork;
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //return this.MakeSelectStringProc(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, logicalMode);
            return this.MakeSelectStringProc(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, CreditMng, logicalMode);
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        }
        #endregion  //[CustPrtPprBlTblRsltWork�p SELECT��]

        #region [CustPrtPprBlTblRsltWork�p SELECT����������]
        /// <summary>
        /// �c���ꗗ�̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���ꗗ�̃��X�g���oSELECT��</returns>
        /// <br>Note       : �c���ꗗ�̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustPrtPprBlnceWork paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustPrtPprBlnceWork paramWork, int SrchKndDiv, bool CreditMng, ConstantManagement.LogicalMode logicalMode)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // CUSTDMDPRCRF  CTDMD  ���Ӑ搿�����z�}�X�^
            // CUSTACCRECRF  CTACC  ���Ӑ攄�|���z�}�X�^

            #region [Select���쐬]
            if (SrchKndDiv == (int)iSrchKndDiv.CustDmd)
            {
                #region [���� -> ���Ӑ搿�����z�}�X�^]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CTDMD.ADDUPDATERF" + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                selectTxt += " ,CTDMD.ADDUPYEARMONTHRF" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                selectTxt += " ,CTDMD.LASTTIMEDEMANDRF" + Environment.NewLine;
                selectTxt += "   AS LASTTIMEBLC" + Environment.NewLine;
                // --- ADD m.suzuki 2010/12/20 ---------->>>>>
                selectTxt += " ,CTDMD.ACPODRTTL2TMBFBLDMDRF AS ACPODRTTL2TMBFBLC" + Environment.NewLine;
                selectTxt += " ,CTDMD.ACPODRTTL3TMBFBLDMDRF AS ACPODRTTL3TMBFBLC" + Environment.NewLine;
                // --- ADD m.suzuki 2010/12/20 ----------<<<<<
                selectTxt += " ,CTDMD.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CTDMD.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                selectTxt += "   AS THISTIMETTLBLC" + Environment.NewLine;
                selectTxt += " ,CTDMD.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,(CTDMD.THISSALESPRICRGDSRF+CTDMD.THISSALESPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS SALESPRICRGDSDIS" + Environment.NewLine;
                selectTxt += " ,CTDMD.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CTDMD.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,(CTDMD.OFSTHISTIMESALESRF+CTDMD.OFSTHISSALESTAXRF)" + Environment.NewLine;
                selectTxt += "   AS THISSALESPRICTOTAL" + Environment.NewLine;
                selectTxt += " ,CTDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                selectTxt += "   AS AFCALBLC" + Environment.NewLine;
                selectTxt += " ,CTDMD.SALESSLIPCOUNTRF" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += " FROM CUSTDMDPRCRF AS CTDMD" + Environment.NewLine;
                selectTxt += " FROM CUSTDMDPRCRF AS CTDMD WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                #endregion
            }
            else if (SrchKndDiv == (int)iSrchKndDiv.CustAcc)
            {
                #region [���| -> ���Ӑ攄�|���z�}�X�^]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CTACC.ADDUPDATERF" + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                selectTxt += " ,CTACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                selectTxt += " ,CTACC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "   AS LASTTIMEBLC" + Environment.NewLine;
                // --- ADD m.suzuki 2010/12/20 ---------->>>>>
                selectTxt += " ,CTACC.ACPODRTTL2TMBFACCRECRF AS ACPODRTTL2TMBFBLC" + Environment.NewLine;
                selectTxt += " ,CTACC.ACPODRTTL3TMBFACCRECRF AS ACPODRTTL3TMBFBLC" + Environment.NewLine;
                // --- ADD m.suzuki 2010/12/20 ----------<<<<<
                selectTxt += " ,CTACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CTACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "   AS THISTIMETTLBLC" + Environment.NewLine;
                selectTxt += " ,CTACC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,(CTACC.THISSALESPRICRGDSRF+CTACC.THISSALESPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS SALESPRICRGDSDIS" + Environment.NewLine;
                selectTxt += " ,CTACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CTACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,(CTACC.OFSTHISTIMESALESRF+CTACC.OFSTHISSALESTAXRF)" + Environment.NewLine;
                selectTxt += "   AS THISSALESPRICTOTAL" + Environment.NewLine;
                selectTxt += " ,CTACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "   AS AFCALBLC" + Environment.NewLine;
                selectTxt += " ,CTACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                // �^�M�c���o�͂̎�
                if (CreditMng)
                {
                    selectTxt += " ,CUSTC.CREDITMONEYRF" + Environment.NewLine;
                    selectTxt += " ,CUSTC.WARNINGCREDITMONEYRF" + Environment.NewLine;
                    selectTxt += " ,CUSTC.PRSNTACCRECBALANCERF" + Environment.NewLine;
                    selectTxt += " ,CRIMCT.CREDITMNGCODERF" + Environment.NewLine;
                    selectTxt += " ,CRIMCT.ACCRECDIVCDRF" + Environment.NewLine;
                    selectTxt += " ,COMP.COMPANYTOTALDAYRF" + Environment.NewLine;
                    selectTxt += " ,CTDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                }
                // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                // -- UPD 2010/06/09 -------------------------------------->>>
                //selectTxt += " FROM CUSTACCRECRF AS CTACC" + Environment.NewLine;
                selectTxt += " FROM CUSTACCRECRF AS CTACC WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 --------------------------------------<<<
                // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                // �^�M�c���o�͂̎�
                if (CreditMng)
                {
                    // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                    selectTxt += " LEFT JOIN CUSTOMERCHANGERF AS CUSTC WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += " ON CTACC.ENTERPRISECODERF = CUSTC.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND CTACC.CLAIMCODERF = CUSTC.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += " LEFT JOIN CUSTOMERRF AS CRIMCT WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += " ON  CTACC.ENTERPRISECODERF = CRIMCT.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND CTACC.CLAIMCODERF = CRIMCT.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += " LEFT JOIN COMPANYINFRF AS COMP WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += " ON  CTACC.ENTERPRISECODERF = COMP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " LEFT JOIN CUSTDMDPRCRF AS CTDMD WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += " ON CTACC.ENTERPRISECODERF = CTDMD.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND CTACC.ADDUPSECCODERF = CTDMD.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += " AND CTACC.CLAIMCODERF = CTDMD.CLAIMCODERF" + Environment.NewLine;
                    selectTxt += " AND CTDMD.CUSTOMERCODERF = 0 " + Environment.NewLine;
                    selectTxt += " AND CTACC.ADDUPDATERF = CTDMD.ADDUPDATERF" + Environment.NewLine;
                    // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                }
                // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                #endregion
            }
            else
            {
                throw new Exception("�������s���G���[(�����p�����[�^�s��)");
            }

            //WHERE���̍쐬
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, SrchKndDiv, logicalMode);
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprBlTblRsltWork�p SELECT����������]

        #region [CustPrtPprBlTblRsltWork�p WHERE����������]
        /// <summary>
        /// �c���ꗗ�̃��X�g���o�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���ꗗ�̃��X�g���o�pWHERE��</returns>
        /// <br>Note       : �c���ꗗ���̃��X�g���o�pWHERE�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>UpdateNote : 2010/09/29 ����</br>
        /// <br>           �@redmine#14876�Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustPrtPprBlnceWork paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //�e�[�u������
            string sTblNm = null;
            if (SrchKndDiv == (int)iSrchKndDiv.CustDmd)
                sTblNm = "CTDMD.";  //���� -> ���Ӑ搿�����z�}�X�^
            else if (SrchKndDiv == (int)iSrchKndDiv.CustAcc)
                sTblNm = "CTACC.";  //���| -> ���Ӑ攄�|���z�}�X�^
            else
                throw new Exception("�������s���G���[(�����p�����[�^�s��)");

            //��ƃR�[�h
            retstring += sTblNm + "ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + sTblNm + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + sTblNm + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (paramWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND " + sTblNm + "ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // ------ ADD 2010/09/29 ----------------->>>>>
            retstring += "AND " + sTblNm + "ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)";
            retstring += Environment.NewLine;
            // ------ ADD 2010/09/29 -----------------<<<<<

            //���Ӑ�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
            //if (paramWork.CustomerCode != 0)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
            {
                retstring += " AND " + sTblNm + "CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
            }

            //������R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
            //if (paramWork.ClaimCode != 0)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
            {
                retstring += " AND " + sTblNm + "CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(paramWork.ClaimCode);
            }

            //�v��N��
            if (paramWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + sTblNm + "ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.St_AddUpYearMonth);
            }
            if (paramWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + sTblNm + "ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.Ed_AddUpYearMonth);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprBlTblRsltWork�p WHERE����������]

        #region [CustPrtPprBlTblRsltWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustPrtPprBlTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprBlnceWork</param>
        /// <param name="iParam"></param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam, bool CreditMng)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        {
            CustPrtPprBlnceWork _custPrtPprBlnceWork = paramWork as CustPrtPprBlnceWork;
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //return this.CopyToResultWorkFromReaderProc(ref myReader, _custPrtPprBlnceWork);
            return this.CopyToResultWorkFromReaderProc(ref myReader, _custPrtPprBlnceWork, CreditMng);
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        }
        #endregion  //[CustPrtPprBlTblRsltWork���� �ďo]

        #region [CustPrtPprBlTblRsltWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustPrtPprBlTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprBlnceWork</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //private CustPrtPprBlTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CustPrtPprBlnceWork paramWork)
        private CustPrtPprBlTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CustPrtPprBlnceWork paramWork, bool CreditMng)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        {
            #region ���o����-�l�Z�b�g
            CustPrtPprBlTblRsltWork resultWork = new CustPrtPprBlTblRsltWork();

            resultWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            // --- UPD m.suzuki 2010/12/20 ---------->>>>>
            //resultWork.LastTimeBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEBLC"));
            resultWork.LastTimeBlc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "LASTTIMEBLC" ) )
                                     + SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL2TMBFBLC" ) )
                                     + SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL3TMBFBLC" ) );
            // --- UPD m.suzuki 2010/12/20 ----------<<<<<
            resultWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            resultWork.ThisTimeTtlBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLC"));
            resultWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            resultWork.SalesPricRgdsDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICRGDSDIS"));
            resultWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            resultWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            resultWork.ThisSalesPricTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICTOTAL"));
            resultWork.AfCalBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALBLC"));
            resultWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            resultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "ADDUPYEARMONTHRF" ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            // �^�M�c���o�͂̎�
            if (CreditMng)
            {
                resultWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                resultWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
                resultWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
                resultWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));
                resultWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
                resultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                resultWork.CompanyTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYTOTALDAYRF"));
            }
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
            #endregion

            return resultWork;
        }
        #endregion  //[CustPrtPprBlTblRsltWork����]
    }
}

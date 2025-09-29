//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ����� �A��691
// �C �� ��  2011/08/16  �C�����e :�yPM�v�]����9���z�M���zRedmine#23598 �A��691�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ����� �A��691
// �C �� ��  2011/09/19  �C�����e :�yPM�v�]����9���z�M���zRedmine#25246 �A��691�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  XXXXXXXX-00 �쐬�S�� : 22008 ���� ���n
// �C �� ��  2011/10/19  �C�����e : ���o���̃^�C���A�E�g���ԉ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/02/25  �C�����e : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh  
// �C �� ��  2013/03/18  �C�����e : redmine #35044 �Ǘ����ŕϊ��}�X�^��ǂݏ��i�R�[�h���擾
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/06/26  �C�����e : ���M���O�̓o�^
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11670121-00  �쐬�S�� : �΍�  
// �C �� ��  2020/03/17  �C�����e : S&E���ǑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SE����f�[�^�e�L�X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : SE����f�[�^�e�L�X�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.14</br>
    /// <br>UpdateNote : 2013/02/25 zhuhh</br>
    /// <br>           : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
    /// <br>UpdateNote : 2013/03/18 zhuhh</br>
    /// <br>           : Redmine#35044 �Ǘ����ŕϊ��}�X�^��ǂݏ��i�R�[�h���擾</br>
    /// <br>UpdateNote : 2013/06/26 �c����</br>
    /// <br>           : ���M���O�̓o�^</br>
    /// </remarks>
    [Serializable]
    public class SalesHistoryJoinDB : RemoteDB, ISalesHistoryJoinWorkDB
    {
        /// <summary>
        /// SE����f�[�^�e�L�X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        public SalesHistoryJoinDB()
            :
        base("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork", "SALESHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SE����f�[�^�e�L�X�g�̑S�Ė߂鏈���i�_���폜�����j
        /// </summary>
        /// <param name="salesHistoryResultWork">��������</param>
        /// <param name="salesHistoryCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SE����f�[�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        public int Search(out object salesHistoryResultWork, object salesHistoryCndtnWork)
        {
            SqlConnection sqlConnection = null;
            salesHistoryResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesHistoryResultWork, salesHistoryCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.Search");
                salesHistoryResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SE����f�[�^�e�L�X�g��S�Ė߂鏈��
        /// </summary>
        /// <param name="salesHistoryResultWork">��������</param>
        /// <param name="salesHistoryCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// <br>Update Note: 2011/08/16 �����</br>
        /// <br>             �yPM�v�]����9���z�M���zRedmine#23598 �A��691�̑Ή�</br> 
        /// <br>UpdateNote : 2013/02/25 zhuhh</br>
        /// <br>           : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// <br>UpdateNote : 2013/03/18 zhuhh</br>
        /// <br>           : Redmine#35044 �Ǘ����ŕϊ��}�X�^��ǂݏ��i�R�[�h���擾</br>
        /// <br>UpdateNote  : 2020/03/17 �΍�</br>
        /// <br>            : �r���d���ǑΉ�</br>
        /// </remarks>
        private int SearchProc(out object salesHistoryResultWork, object salesHistoryCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesHistoryCndtnWork cndtnWork = salesHistoryCndtnWork as SalesHistoryCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesHistoryResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ");
                sb.Append(" A.CREATEDATETIMERF, ");
                sb.Append(" A.ENTERPRISECODERF, ");
                sb.Append(" A.ACPTANODRSTATUSRF, ");
                sb.Append(" A.SALESSLIPNUMRF, ");
                sb.Append(" A.SALESSLIPCDRF, ");
                sb.Append(" A.RESULTSADDUPSECCDRF, ");
                sb.Append(" A.SEARCHSLIPDATERF, ");
                sb.Append(" A.ADDUPADATERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" B.SALESROWNORF, ");
                sb.Append(" B.GOODSMAKERCDRF, ");
                //update �΍� 2020/03/17 �r���d���ǑΉ�  ----->>>>>
                sb.Append(" B.PRTGOODSNORF, ");
               // sb.Append(" B.GOODSNORF, ");
                //update �΍� 2020/03/17 �r���d���ǑΉ�  -----<<<<<
                sb.Append(" B.GOODSNAMEKANARF, ");
                sb.Append(" B.BLGOODSCODERF, ");
                sb.Append(" B.SALESUNPRCTAXEXCFLRF, ");
                sb.Append(" B.SHIPMENTCNTRF, ");
                sb.Append(" B.SALESMONEYTAXEXCRF, ");
                sb.Append(" B.LISTPRICETAXEXCFLRF, "); // ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
                sb.Append(" B.SUPPLIERCDRF, ");
                sb.Append(" B.PRTBLGOODSCODERF, ");
                sb.Append(" C.ABGOODSCODERF AS SETABGOODSCODERF, ");
                sb.Append(" C.ADDRESSEESHOPCDRF, ");
                sb.Append(" C.EXPENSEDIVCDRF, ");
                sb.Append(" C.PURETRADCOMPCDRF, ");
                sb.Append(" C.PURETRADCOMPRATERF, ");
                sb.Append(" C.PRITRADCOMPCDRF, ");
                sb.Append(" C.PRITRADCOMPRATERF, ");
                sb.Append(" C.SANDEMNGCODERF, ");
                sb.Append(" C.GOODSMAKERCD1RF, ");
                sb.Append(" C.GOODSMAKERCD2RF, ");
                sb.Append(" C.GOODSMAKERCD3RF, ");
                sb.Append(" C.GOODSMAKERCD4RF, ");
                sb.Append(" C.GOODSMAKERCD5RF, ");
                sb.Append(" C.GOODSMAKERCD6RF, ");
                sb.Append(" C.GOODSMAKERCD7RF, ");
                sb.Append(" C.GOODSMAKERCD8RF, ");
                sb.Append(" C.GOODSMAKERCD9RF, ");
                sb.Append(" C.GOODSMAKERCD10RF, ");
                sb.Append(" C.GOODSMAKERCD11RF, ");
                sb.Append(" C.GOODSMAKERCD12RF, ");
                sb.Append(" C.GOODSMAKERCD13RF, ");
                sb.Append(" C.GOODSMAKERCD14RF, ");
                sb.Append(" C.GOODSMAKERCD15RF, ");
                sb.Append(" D.CUSTOMERSNMRF, ");
                sb.Append(" E.SECTIONGUIDESNMRF, ");
                sb.Append(" F.ABGOODSCODERF, ");
                sb.Append(" G.ENTERPRISECODERF AS SEENTERPRISECODERF, ");
                sb.Append(" G.ACPTANODRSTATUSRF AS SEACPTANODRSTATUSRF, ");
                sb.Append(" G.SALESSLIPNUMRF AS SESALESSLIPNUMRF, ");
                sb.Append(" G.SALESCREATEDATETIMERF AS SESALESCREATEDATETIMERF ");

                sb.Append(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                sb.Append(" INNER JOIN SALESHISTDTLRF B ");
                sb.Append(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");

                sb.Append(" INNER JOIN SANDESETTINGRF C ");
                sb.Append(" ON A.ENTERPRISECODERF =  C.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = C.SECTIONCODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  C.CUSTOMERCODERF ");

                sb.Append(" LEFT JOIN CUSTOMERRF D ");
                sb.Append(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  D.CUSTOMERCODERF ");
                sb.Append(" AND D.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF E ");
                sb.Append(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                sb.Append(" AND E.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SANDESALEXTRDTRF G ");
                sb.Append(" ON A.ENTERPRISECODERF =  G.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = G.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF = G.SALESSLIPNUMRF ");
                //sb.Append(" AND A.CREATEDATETIMERF = G.SALESCREATEDATETIMERF "); // DEL 2011/08/16

                sb.Append(" LEFT JOIN SANDEGOODSCDCHGRF F ");
                sb.Append(" ON B.ENTERPRISECODERF =  F.ENTERPRISECODERF ");
                //sb.Append(" AND B.BLGOODSCODERF = F.BLGOODSCODERF ");// DEL zhuhh 2013/03/18 for Redmine#35044
                sb.Append(" AND B.PRTBLGOODSCODERF = F.BLGOODSCODERF ");// ADD zhuhh 2013/03/18 for Redmine#35044
                sb.Append(" AND F.LOGICALDELETECODERF = 0 ");

                // ��������
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.ADDUPADATERF,A.RESULTSADDUPSECCDRF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                sqlCommand.CommandTimeout = 3600;  // ADD 2011/10/19

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesHistoryJoinWork wkSalesHistoryJoinWork = new SalesHistoryJoinWork();

                    //�f�[�^���ʎ擾���e�i�[
                    wkSalesHistoryJoinWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    wkSalesHistoryJoinWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkSalesHistoryJoinWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    wkSalesHistoryJoinWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    wkSalesHistoryJoinWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSalesHistoryJoinWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //update �΍� 2020/03/17 �r���d���ǑΉ�  ----->>>>>
                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
//                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //update �΍� 2020/03/17 �r���d���ǑΉ�  -----<<<<<
                    wkSalesHistoryJoinWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkSalesHistoryJoinWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkSalesHistoryJoinWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkSalesHistoryJoinWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    wkSalesHistoryJoinWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkSalesHistoryJoinWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkSalesHistoryJoinWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));// ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
                    wkSalesHistoryJoinWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSalesHistoryJoinWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSalesHistoryJoinWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesHistoryJoinWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    wkSalesHistoryJoinWork.AddresseeShopCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));
                    wkSalesHistoryJoinWork.SAndEMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));
                    wkSalesHistoryJoinWork.ExpenseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));
                    wkSalesHistoryJoinWork.PureTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));
                    wkSalesHistoryJoinWork.PureTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));
                    wkSalesHistoryJoinWork.PriTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));
                    wkSalesHistoryJoinWork.PriTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));
                    wkSalesHistoryJoinWork.SetABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETABGOODSCODERF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));
                    wkSalesHistoryJoinWork.SEEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.SEAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SESalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SESALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SESalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SESALESCREATEDATETIMERF"));

                    #endregion

                    al.Add(wkSalesHistoryJoinWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SalesHistoryJoinDB.SearchProc", status);
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            salesHistoryResultWork = al;

            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// SE���㒊�o�f�[�^����ǉ��X�V�����B
        /// </summary>
        /// <param name="objectsalesHistoryJoinWorkList">�ǉ��E�X�V����SE���㒊�o�f�[�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : salesHistoryJoinWorkList �Ɋi�[����Ă���SE���㒊�o�f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        public int Write(ref object objectsalesHistoryJoinWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList salesHistoryJoinWorkList = objectsalesHistoryJoinWorkList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                foreach (SalesHistoryJoinWork detailWork in salesHistoryJoinWorkList)
                {
                    // �폜�������s
                    status = this.DeleteProc(detailWork, ref sqlConnection, ref sqlTransaction);

                    //�ǉ��������s
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.InsertProc(detailWork, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.Write(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///SE���㒊�o�f�[�^���𕨗��폜����
        /// </summary>
        /// <param name="salesHistoryJoinWork">SE���㒊�o�f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesHistoryJoinWork �Ɋi�[����Ă���SE���㒊�o�f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// <br>Update Note: 2011/09/19 �����</br>
        /// <br>             �yPM�v�]����9���z�M���zRedmine##25246 �A��691�̑Ή�</br> 
        private int DeleteProc(SalesHistoryJoinWork salesHistoryJoinWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesHistoryJoinWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [DELETE��]
                    sqlText += "DELETE " + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "SANDESALEXTRDTRF " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    //sqlText += " AND SALESCREATEDATETIMERF = @FINDSALESCREATEDATETIME" + Environment.NewLine; // DEL 2011/09/19
                    sqlCommand.CommandText = sqlText;
                    # endregion


                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findSalesCreateDateTime = sqlCommand.Parameters.Add("@FINDSALESCREATEDATETIME", SqlDbType.BigInt);

                    // KEY�R�}���h��ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.SalesSlipNum);
                    findSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.CreateDateTime);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.DeleteProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///SE���㒊�o�f�[�^����ǉ�����
        /// </summary>
        /// <param name="salesHistoryJoinWork">SE���㒊�o�f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesHistoryJoinWork �Ɋi�[����Ă���SE���㒊�o�f�[�^����ǉ����܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        private int InsertProc(SalesHistoryJoinWork salesHistoryJoinWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesHistoryJoinWork != null)
                {
                    string sqlText = string.Empty;

                    //���㒊�o�f�[�^. ����f�[�^�쐬����
                    DateTime salesCreateDateTime = salesHistoryJoinWork.CreateDateTime; 

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SANDESALEXTRDTRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESCREATEDATETIMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SALESCREATEDATETIME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // �o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesHistoryJoinWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesCreateDateTime = sqlCommand.Parameters.Add("@SALESCREATEDATETIME", SqlDbType.BigInt);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesHistoryJoinWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCreateDateTime);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.InsertProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.InsertProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesHistoryCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesHistoryCndtnWork salesHistoryCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryCndtnWork.EnterpriseCode);

            //���㗚���f�[�^.�_���폜�敪
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�󒍃X�e�[�^�X
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            //�I�[�g�o�b�N�X�ݒ�}�X�^ .�_���폜�敪
            retstring += " AND C.LOGICALDELETECODERF=@CLOGICALDELETECODERF";
            SqlParameter paraCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODERF", SqlDbType.Int);
            paraCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //���㗚�𖾍׃f�[�^.�_���폜�敪
            retstring += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODERF";
            SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODERF", SqlDbType.Int);
            paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //���_�R�[�h    ���z��ŕ����w�肳���
            if (salesHistoryCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in salesHistoryCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND A.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // AND �v���>���p�����[�^.�v����̊J�n��																																	
            if (!DateTime.MinValue.Equals(salesHistoryCndtnWork.AddUpADateSt))
            {
                retstring += " AND A.ADDUPADATERF>=@ST_SCVDAY ";
                SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                Para_St_csvDate.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.AddUpADateSt);
            }

            // AND �v���<���p�����[�^.�v����̏I����
            if (!DateTime.MinValue.Equals(salesHistoryCndtnWork.AddUpADateEd))
            {
                retstring += " AND A.ADDUPADATERF<=@ED_SCVDAY ";
                SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                Para_Ed_csvDate.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.AddUpADateEd);
            }

            // AND ���Ӑ�R�[�h>���p�����[�^.���Ӑ�R�[�h�̊J�n																																	
            if (0 != salesHistoryCndtnWork.CustomerCodeSt)
            {
                retstring += " AND A.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.CustomerCodeSt);
            }

            // AND ���Ӑ�R�[�h<���p�����[�^.���Ӑ�R�[�h�̏I��
            if (0 != salesHistoryCndtnWork.CustomerCodeEd)
            {
                retstring += " AND A.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                SqlParameter Para_Ed_customerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                Para_Ed_customerCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.CustomerCodeEd);
            }

            retstring += " AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR (B.SALESSLIPCDDTLRF = 2 AND B.SHIPMENTCNTRF = 0)) ";

            #endregion
            return retstring;
        }

        // ----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>
        /// SE����f�[�^�e�L�X�g���M���O���̓o�^�����B
        /// </summary>
        /// <param name="objectSAndESalSndLogWork">�o�^����SE����f�[�^�e�L�X�g���M���O���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSAndESalSndLogWork �Ɋi�[����Ă���SE����f�[�^�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/06/26</br>
        public int WriteLog(ref object objectSAndESalSndLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SAndESalSndLogListResultWork sAndESalSndLogWork = objectSAndESalSndLogWork as SAndESalSndLogListResultWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteLogProc(sAndESalSndLogWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.WriteLog(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///SE����f�[�^�e�L�X�g���M���O���̓o�^����
        /// </summary>
        /// <param name="sAndESalSndLogWork">�o�^����SE����f�[�^�e�L�X�g���M���O���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sAndESalSndLogWork �Ɋi�[����Ă���SE����f�[�^�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/06/26</br>
        private int WriteLogProc(SAndESalSndLogListResultWork sAndESalSndLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndESalSndLogWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText.Append(" SELECT UPDATEDATETIMERF").Append( Environment.NewLine);
                    sqlText.Append(" FROM SANDESALSNDLOGRF").Append( Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SECTIONCODERF=@FINDSECTIONCODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SANDEAUTOSENDDIVRF=@FINDSANDEAUTOSENDDIV").Append( Environment.NewLine);
                    sqlText.Append("   AND SENDDATETIMESTARTRF=@FINDSENDDATETIMESTART").Append( Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaSAndEAutoSendDiv = sqlCommand.Parameters.Add("@FINDSANDEAUTOSENDDIV", SqlDbType.NChar);
                    SqlParameter findParaSendDateTimeStart = sqlCommand.Parameters.Add("@FINDSENDDATETIMESTART", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SectionCode);
                    findParaSAndEAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SAndEAutoSendDiv);
                    findParaSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeStart);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != sAndESalSndLogWork.UpdateDateTime)
                        {
                            if (sAndESalSndLogWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sAndESalSndLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("INSERT INTO SANDESALSNDLOGRF").Append( Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  CREATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,ENTERPRISECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,FILEHEADERGUIDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF").Append( Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,SECTIONCODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,SANDEAUTOSENDDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTSTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDRESULTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDERRORCONTENTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPCOUNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPDTLCNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPTOTALMNYRF").Append( Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlText.Append("VALUES").Append( Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  @CREATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@ENTERPRISECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@FILEHEADERGUID").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDEMPLOYEECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID1").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID2").Append( Environment.NewLine);
                        sqlText.Append(" ,@LOGICALDELETECODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@SECTIONCODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@SANDEAUTOSENDDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTSTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDRESULTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDERRORCONTENTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPCOUNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPDTLCNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPTOTALMNY").Append(Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESalSndLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSAndEAutoSendDiv = sqlCommand.Parameters.Add("@SANDEAUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateStart = sqlCommand.Parameters.Add("@SENDOBJDATESTART", SqlDbType.Int);
                    SqlParameter paraSendObjDateEnd = sqlCommand.Parameters.Add("@SENDOBJDATEEND", SqlDbType.Int);
                    SqlParameter paraSendObjCustStart = sqlCommand.Parameters.Add("@SENDOBJCUSTSTART", SqlDbType.Int);
                    SqlParameter paraSendObjCustEnd = sqlCommand.Parameters.Add("@SENDOBJCUSTEND", SqlDbType.Int);
                    SqlParameter paraSendObjDiv = sqlCommand.Parameters.Add("@SENDOBJDIV", SqlDbType.Int);
                    SqlParameter paraSendResults = sqlCommand.Parameters.Add("@SENDRESULTS", SqlDbType.Int);
                    SqlParameter paraSendErrorContents = sqlCommand.Parameters.Add("@SENDERRORCONTENTS", SqlDbType.NVarChar);
                    SqlParameter paraSendSlipCount = sqlCommand.Parameters.Add("@SENDSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraSendSlipDtlCnt = sqlCommand.Parameters.Add("@SENDSLIPDTLCNT", SqlDbType.Int);
                    SqlParameter paraSendSlipTotalMny = sqlCommand.Parameters.Add("@SENDSLIPTOTALMNY", SqlDbType.BigInt);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESalSndLogWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESalSndLogWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndESalSndLogWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SectionCode);
                    paraSAndEAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SAndEAutoSendDiv);
                    paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeStart);
                    paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeEnd);
                    paraSendObjDateStart.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDateStart);
                    paraSendObjDateEnd.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDateEnd);
                    paraSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjCustStart);
                    paraSendObjCustEnd.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjCustEnd);
                    paraSendObjDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDiv);
                    paraSendResults.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendResults);
                    paraSendErrorContents.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SendErrorContents);
                    paraSendSlipCount.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendSlipCount);
                    paraSendSlipDtlCnt.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendSlipDtlCnt);
                    paraSendSlipTotalMny.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendSlipTotalMny);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.WriteLogProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.WriteLogProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        // ----- ADD �c���� 2013/06/26 -----<<<<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        #endregion  //�R�l�N�V������������
    }
}

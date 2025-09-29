//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������s(�d�q����A�g)DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���������s(�d�q����A�g)DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00 �쐬�S�� : 3H ����
// �C �� ��  2022/10/27  �C�����e : �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
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
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���������s(�d�q����A�g)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �����ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2022/10/27</br>
    /// </remarks>
    [Serializable]
    public class EBooksBillTableDB : RemoteDB, IEBooksBillTableDB
    {
        /// <summary>
        /// ���������s(�d�q����A�g)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public EBooksBillTableDB()
            :
            base("MAKAU03012D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_EBooksDemandTotalWork", "CUSTDMDPRCRF")
        {
        }

        #region [SearchBillTable]
        /// <summary>
        /// �w�肳�ꂽ�����̐����ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̐����ꗗ�\��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int SearchBillTable(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;

            ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork = null;
            RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork = null;

            ArrayList extrInfo_DemandTotalWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            ArrayList allDefSetList = new ArrayList();

            if (extrInfo_DemandTotalWorkList == null)
            {
                extrInfo_DemandTotalWork = paraObj as ExtrInfo_EBooksDemandTotalWork;
            }
            else
            {
                if (extrInfo_DemandTotalWorkList.Count > 0)
                    extrInfo_DemandTotalWork = extrInfo_DemandTotalWorkList[0] as ExtrInfo_EBooksDemandTotalWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���������z�}�X�^�擾
                status = SearchBillTableProc(ref retList, extrInfo_DemandTotalWork, ref sqlConnection);

                //���s�����̎擾
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        rsltInfo_DemandTotalWork = retList[i] as RsltInfo_EBooksDemandTotalWork;

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ����ŕʓ���󎚂���
                            if (extrInfo_DemandTotalWork.TaxPrintDiv == 0 && extrInfo_DemandTotalWork.SlipPrtKind == 0)
                            {
                                //����f�[�^�擾
                                status = SearchSalesProc(ref rsltInfo_DemandTotalWork, ref sqlConnection, extrInfo_DemandTotalWork);

                                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    //�Y���f�[�^�Ȃ� status���N���A������
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //�擾���s
                                    throw new Exception("����f�[�^�擾���s�B");
                                }
                            }
                        }

                        //���������W�v�f�[�^�擾
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status2 = this.SearchDmdDepoTotal(ref rsltInfo_DemandTotalWork, ref sqlConnection);
                        }

                        //���Ӑ�}�X�^(�������Ǘ�)�擾
                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (extrInfo_DemandTotalWork.SlipPrtKind != 0 ))
                        {
                            status2 = this.SearchCustDmdSet(ref rsltInfo_DemandTotalWork, extrInfo_DemandTotalWork, ref sqlConnection);
                        }
                    }
                }

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    status = SerchAllDefSetProc(ref allDefSetList, extrInfo_DemandTotalWork, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EBooksBillTableDB.SearchBillTable");
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

            CustomSerializeArrayList allList = new CustomSerializeArrayList();
            allList.Add(retList);
            allList.Add(allDefSetList);
            retObj = (object)allList;
            return status;
        }

        /// <summary>
        /// �S�̏����l�ݒ�̓��e�𒊏o���܂�
        /// </summary>
        /// <param name="allDefSetList"></param>
        /// <param name="extrInfo_DemandTotalWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : �S�̏����l�ݒ�̓��e�𒊏o���܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SerchAllDefSetProc(ref ArrayList allDefSetList, ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            //ArrayList retList;
            AllDefSetWork paraWork = new AllDefSetWork();
            paraWork.EnterpriseCode = extrInfo_DemandTotalWork.EnterpriseCode;

            AllDefSetDB allDefSetDB = new AllDefSetDB();
            int status = allDefSetDB.Search(out allDefSetList, paraWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̐����ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_DemandTotalWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̐����ꗗ�\��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        private int SearchBillTableProc(ref ArrayList retList, ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL��]
                sqlText += "SELECT A.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,E.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,B.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                sqlText += "    ,B.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "    ,B.CUSTOMERSNMRF AS CLAIMSNMRF" + Environment.NewLine;
                sqlText += "    ,B.KANARF CLAIMNAMEKANARF" + Environment.NewLine;
                sqlText += "    ,B.POSTNORF" + Environment.NewLine;
                sqlText += "    ,B.ADDRESS1RF" + Environment.NewLine;
                sqlText += "    ,B.ADDRESS3RF" + Environment.NewLine;
                sqlText += "    ,B.ADDRESS4RF" + Environment.NewLine;
                sqlText += "    ,B.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += "    ,B.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += "    ,B.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += "    ,B.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += "    ,B.HOMETELNORF" + Environment.NewLine;
                sqlText += "    ,B.OFFICETELNORF" + Environment.NewLine;
                sqlText += "    ,B.PORTABLETELNORF" + Environment.NewLine;
                sqlText += "    ,B.HOMEFAXNORF" + Environment.NewLine;
                sqlText += "    ,B.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += "    ,B.OTHERSTELNORF" + Environment.NewLine;
                sqlText += "    ,B.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += "    ,B.TOTALDAYRF" + Environment.NewLine;
                sqlText += "    ,B.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += "    ,C.NAMERF CUSTOMERAGENTNMRF" + Environment.NewLine;
                sqlText += "    ,B.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += "    ,D.NAMERF BILLCOLLECTERNMRF" + Environment.NewLine;
                sqlText += "    ,B.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += "    ,B.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += "    ,B.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += "    ,B.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += "    ,B.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += "    ,B.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += "    ,B.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += "    ,B.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,B.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += "    ,G.NAMERF AS CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "    ,G.NAME2RF AS CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "    ,G.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,A.LASTTIMEDEMANDRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMEDMDNRMLRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISTIMESALESRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISSALESTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                sqlText += "    ,A.OFFSETOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.OFFSETINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMESALESRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDSALESINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.ITDEDSALESTAXFREERF" + Environment.NewLine;
                sqlText += "    ,A.SALESOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.SALESINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRICRGDSRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDRETINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                sqlText += "    ,A.TTLRETOUTERTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLRETINNERTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRICDISRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRCTAXDISRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDDISINTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                sqlText += "    ,A.TTLDISOUTERTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TTLDISINNERTAXRF" + Environment.NewLine;
                sqlText += "    ,A.TAXADJUSTRF" + Environment.NewLine;
                sqlText += "    ,A.BALANCEADJUSTRF" + Environment.NewLine;
                sqlText += "    ,A.AFCALDEMANDPRICERF" + Environment.NewLine;
                sqlText += "    ,A.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "    ,A.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "    ,A.CADDUPUPDEXECDATERF" + Environment.NewLine;
                sqlText += "    ,A.STARTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "    ,A.LASTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "    ,A.SALESSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "    ,A.BILLPRINTDATERF" + Environment.NewLine;
                sqlText += "    ,A.EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                sqlText += "    ,A.COLLECTCONDRF" + Environment.NewLine;
                sqlText += "    ,A.CONSTAXRATERF" + Environment.NewLine;
                sqlText += "    ,A.FRACTIONPROCCDRF" + Environment.NewLine;
                sqlText += "    ,B.SALESAREACODERF" + Environment.NewLine;
                sqlText += "    ,F.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += "    ,B.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,A.RESULTSSECTCDRF" + Environment.NewLine;
                sqlText += "    ,H.CNT" + Environment.NewLine;
                sqlText += "    ,B.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += "    ,B.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += "     ,B.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += "     ,B.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += "     ,B.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " FROM CUSTDMDPRCRF AS A LEFT" + Environment.NewLine;
                sqlText += " JOIN CUSTOMERRF AS B ON" + Environment.NewLine;
                sqlText += " (A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND A.CLAIMCODERF=B.CUSTOMERCODERF" + Environment.NewLine;

                if (extrInfo_DemandTotalWork.EBooksFlg == 1)
                {
                    // �d�q����o�͑Ώۂ��d�q����o�͐ݒ�ɏ]��
                    if (extrInfo_DemandTotalWork.EBooksOutMode == 1)
                    {
                        sqlText += "    AND B.DMOUTCODERF=0" + Environment.NewLine;
                    }
                }
                else
                {
                    //�d�q����o�͐ݒ肠��̐�����
                    if (extrInfo_DemandTotalWork.PrintOutMode == 1)
                    {
                        sqlText += "    AND B.DMOUTCODERF=0" + Environment.NewLine;
                    }
                    //�d�q����o�͐ݒ�Ȃ��̐�����
                    if (extrInfo_DemandTotalWork.PrintOutMode == 2)
                    {
                        sqlText += "    AND B.DMOUTCODERF<>0" + Environment.NewLine;
                    } 
                }

                sqlText += " ) LEFT" + Environment.NewLine;
                sqlText += " JOIN EMPLOYEERF AS C ON" + Environment.NewLine;
                sqlText += " (B.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND B.CUSTOMERAGENTCDRF=C.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ) LEFT" + Environment.NewLine;
                sqlText += " JOIN EMPLOYEERF AS D ON" + Environment.NewLine;
                sqlText += " (B.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND B.BILLCOLLECTERCDRF=D.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ) LEFT" + Environment.NewLine;
                sqlText += " JOIN SECINFOSETRF AS E ON" + Environment.NewLine;
                sqlText += " (A.ENTERPRISECODERF=E.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND A.ADDUPSECCODERF=E.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ) LEFT" + Environment.NewLine;
                sqlText += " JOIN USERGDBDURF AS F ON" + Environment.NewLine;
                sqlText += " (F.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND F.USERGUIDEDIVCDRF=21" + Environment.NewLine;
                sqlText += "    AND F.GUIDECODERF=B.SALESAREACODERF" + Environment.NewLine;
                sqlText += " )" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF AS G ON" + Environment.NewLine;
                sqlText += " (A.ENTERPRISECODERF=G.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND A.CUSTOMERCODERF=G.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " )" + Environment.NewLine;
                sqlText += " LEFT JOIN " + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "   SELECT " + Environment.NewLine;
                sqlText += "    DEPOTOTAL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,COUNT(MONEYKINDCODERF) AS CNT" + Environment.NewLine;
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "    DMDDEPOTOTALRF AS DEPOTOTAL" + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "    DEPOTOTAL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,DEPOTOTAL.ADDUPDATERF" + Environment.NewLine;
                sqlText += " ) AS H" + Environment.NewLine;
                sqlText += " ON A.ENTERPRISECODERF = H.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF = H.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPDATERF = H.ADDUPDATERF" + Environment.NewLine;
                sqlText += " AND A.CLAIMCODERF = H.CLAIMCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_DemandTotalWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_DemandTotalFromReader(ref myReader));

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

        /// <summary>
        /// �w�肳�ꂽ�����̐��������W�v�f�[�^��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̐��������W�v�f�[�^��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchDmdDepoTotal(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                //SQL��
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "    ,DEPOSITRF" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.AddUpSecCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(rsltInfo_DemandTotalWork.ClaimCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rsltInfo_DemandTotalWork.ClaimCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rsltInfo_DemandTotalWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();

                rsltInfo_DemandTotalWork.MoneyKindList = new ArrayList();
                while (myReader.Read())
                {
                    RsltInfo_EBooksDepsitTotalWork rsltInfo_DepsitTotalWork = new RsltInfo_EBooksDepsitTotalWork();

                    rsltInfo_DepsitTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    rsltInfo_DepsitTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    rsltInfo_DepsitTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    rsltInfo_DepsitTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));

                    //����R�[�h���X�g
                    rsltInfo_DemandTotalWork.MoneyKindList.Add(rsltInfo_DepsitTotalWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (rsltInfo_DemandTotalWork.MoneyKindList.Count == 0)
                {
                    RsltInfo_EBooksDepsitTotalWork rsltInfo_DepsitTotalWork = new RsltInfo_EBooksDepsitTotalWork();

                    rsltInfo_DepsitTotalWork.MoneyKindCode = 0;
                    rsltInfo_DepsitTotalWork.MoneyKindName = "";
                    rsltInfo_DepsitTotalWork.MoneyKindDiv = 0;
                    rsltInfo_DepsitTotalWork.Deposit = 0;

                    //����R�[�h���X�g
                    rsltInfo_DemandTotalWork.MoneyKindList.Add(rsltInfo_DepsitTotalWork);
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
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�������Ǘ�)�̓`�[����ݒ�p���[ID��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="extrInfo_DemandTotalWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�������Ǘ�)�̓`�[����ݒ�p���[ID��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchCustDmdSet(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                //SQL��
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlText += " FROM CUSTDMDSETRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "    AND CUSTOMERCODERF=0" + Environment.NewLine;
                sqlText += "    AND DATAINPUTSYSTEMRF=0" + Environment.NewLine;
                sqlText += "    AND SLIPPRTKINDRF=60" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.AddUpSecCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    rsltInfo_DemandTotalWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
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

        /// <summary>
        /// �w�肳�ꂽ�����̑��z�\�����@�敪��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̑��z�\�����@�敪��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchAllDefSet(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SQL��
                sqlCommand.CommandText = "SELECT TOTALAMOUNTDISPWAYCDRF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE ";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.AddUpSecCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    rsltInfo_DemandTotalWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    //���肦�Ȃ����O�̂���
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
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

        /// <summary>
        /// �w�肳�ꂽ�����̐���������p�^�[���ԍ���߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̐���������p�^�[���ԍ���߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchDmdPrtPtnSet(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);
                //SQL��
                sqlCommand.CommandText = "SELECT DEMANDPTNNORF,DMDDTLPTNNORF FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=0 ";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.AddUpSecCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
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

        /// <summary>
        /// �w�肳�ꂽ�����̏���ŗ���߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̏���ŗ���߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchTaxRateSet(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            //�ŗ��ݒ胏�[�N
            TaxRateSetWork taxRateSetWork = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SQL��
                sqlCommand.CommandText = "SELECT TAXRATESTARTDATERF,TAXRATEENDDATERF,TAXRATERF,TAXRATESTARTDATE2RF,TAXRATEENDDATE2RF,TAXRATE2RF,TAXRATESTARTDATE3RF,TAXRATEENDDATE3RF,TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=0";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);
                    //�ŗ��Z�b�g
                    if (rsltInfo_DemandTotalWork.AddUpDate >= taxRateSetWork.TaxRateStartDate && rsltInfo_DemandTotalWork.AddUpDate <= taxRateSetWork.TaxRateEndDate)
                    {
                        //�ŗ�
                        rsltInfo_DemandTotalWork.ConsTaxRate = taxRateSetWork.TaxRate;
                    }
                    else if (rsltInfo_DemandTotalWork.AddUpDate >= taxRateSetWork.TaxRateStartDate2 && rsltInfo_DemandTotalWork.AddUpDate <= taxRateSetWork.TaxRateEndDate2)
                    {
                        //�ŗ�2
                        rsltInfo_DemandTotalWork.ConsTaxRate = taxRateSetWork.TaxRate2;
                    }
                    else if (rsltInfo_DemandTotalWork.AddUpDate >= taxRateSetWork.TaxRateStartDate3 && rsltInfo_DemandTotalWork.AddUpDate <= taxRateSetWork.TaxRateEndDate3)
                    {
                        //�ŗ�3
                        rsltInfo_DemandTotalWork.ConsTaxRate = taxRateSetWork.TaxRate3;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    //���肦�Ȃ����O�̂���
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
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

        /// <summary>
        /// �w�肳�ꂽ�����̒[�������敪��߂��܂�
        /// </summary>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃp�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�����̒[�������敪��߂��܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchSalesProcMoney(ref RsltInfo_EBooksDemandTotalWork rsltInfo_DemandTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SQL��
                sqlCommand.CommandText = "SELECT FRACTIONPROCCDRF,FRACTIONPROCCODERF,UPPERLIMITPRICERF,FRACTIONPROCUNITRF FROM SALESPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=1 AND FRACTIONPROCCODERF=0 ";
                
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_DemandTotalWork.EnterpriseCode);
                
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //�[�������敪
                    rsltInfo_DemandTotalWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));

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
        /// <param name="extrInfo_DemandTotalWork">���������i�[�N���X</param>
        /// <returns>�����ꗗ�\���o��SQL������</returns>
        /// <remarks>
        /// <br>Note        : WHERE�吶������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND A.LOGICALDELETECODERF=0 AND B.LOGICALDELETECODERF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //���ьv�㋒�_�R�[�h
            string sectionString = "";
            foreach (string sectionCode in extrInfo_DemandTotalWork.ResultsAddUpSecList)
            {
                if (sectionCode != "")
                {
                    if (sectionString != "") sectionString += ",";
                    sectionString += "'" + sectionCode + "'";
                }
            }
            if (sectionString != "")
            {
                retString.Append("AND A.ADDUPSECCODERF IN (" + sectionString + ") ");
            }

            //�v��N����
            if (extrInfo_DemandTotalWork.AddUpDate > DateTime.MinValue)
            {
                retString.Append("AND A.ADDUPDATERF=@ADDUPDATE ");
                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandTotalWork.AddUpDate);
            }
            //���Ӑ�R�[�h�i�J�n�j
            if (extrInfo_DemandTotalWork.CustomerCodeSt > 0)
            {
                retString.Append("AND A.CLAIMCODERF>=@CUSTOMERCODEST ");
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.CustomerCodeSt);
            }

            //���Ӑ�R�[�h�i�I���j
            if (extrInfo_DemandTotalWork.CustomerCodeEd > 0)
            {
                retString.Append("AND A.CLAIMCODERF<=@CUSTOMERCODEED ");
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.CustomerCodeEd);
            }

            //�W���S���R�[�h�i�J�n�j�i�I���j
            if ((extrInfo_DemandTotalWork.BillCollecterCdSt != "") && (extrInfo_DemandTotalWork.BillCollecterCdSt == extrInfo_DemandTotalWork.BillCollecterCdEd))
            {
                retString.Append("AND B.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDST ");
                SqlParameter paraBillCollecterCdSt = sqlCommand.Parameters.Add("@BILLCOLLECTERCDST", SqlDbType.NChar);
                paraBillCollecterCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdSt + "%");
            }
            else
            {
                //�W���S���R�[�h�i�J�n�j
                if (extrInfo_DemandTotalWork.BillCollecterCdSt != "")
                {
                    retString.Append("AND B.BILLCOLLECTERCDRF>=@BILLCOLLECTERCDST ");
                    SqlParameter paraBillCollecterCdSt = sqlCommand.Parameters.Add("@BILLCOLLECTERCDST", SqlDbType.NChar);
                    paraBillCollecterCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdSt);
                }
                //�W���S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                if (extrInfo_DemandTotalWork.BillCollecterCdEd != "" && extrInfo_DemandTotalWork.BillCollecterCdSt == "")
                {
                    retString.Append("AND ( B.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR B.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED OR B.BILLCOLLECTERCDRF IS NULL ) ");
                    SqlParameter paraBillCollecterCdEd = sqlCommand.Parameters.Add("@BILLCOLLECTERCDED", SqlDbType.NChar);
                    paraBillCollecterCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdEd);
                }
                else
                {
                    //�W���S���R�[�h�i�I���j
                    if (extrInfo_DemandTotalWork.BillCollecterCdEd != "")
                    {
                        retString.Append("AND ( B.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR B.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED ) ");
                        SqlParameter paraBillCollecterCdEd = sqlCommand.Parameters.Add("@BILLCOLLECTERCDED", SqlDbType.NChar);
                        paraBillCollecterCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdEd + "%");
                    }
                }
            }

            //�ڋq�S���R�[�h�i�J�n�j�i�I���j
            if ((extrInfo_DemandTotalWork.CustomerAgentCdSt != "") && (extrInfo_DemandTotalWork.CustomerAgentCdSt == extrInfo_DemandTotalWork.CustomerAgentCdEd))
            {
                retString.Append("AND B.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDST ");
                SqlParameter paraCustomerAgentCdSt = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDST", SqlDbType.NChar);
                paraCustomerAgentCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdSt + "%");
            }
            else
            {
                //�ڋq�S���R�[�h�i�J�n�j
                if (extrInfo_DemandTotalWork.CustomerAgentCdSt != "")
                {
                    retString.Append("AND B.CUSTOMERAGENTCDRF>=@CUSTOMERAGENTCDST ");
                    SqlParameter paraCustomerAgentCdSt = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDST", SqlDbType.NChar);
                    paraCustomerAgentCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdSt);
                }
                //�ڋq�S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "" && extrInfo_DemandTotalWork.CustomerAgentCdSt == "")
                {
                    retString.Append("AND ( B.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR B.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED OR B.CUSTOMERAGENTCDRF IS NULL ) ");
                    SqlParameter paraCustomerAgentCdEd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDED", SqlDbType.NChar);
                    paraCustomerAgentCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdEd);
                }
                else
                {
                    //�ڋq�S���R�[�h�i�I���j
                    if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "")
                    {
                        retString.Append("AND ( B.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR B.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED ) ");
                        SqlParameter paraCustomerAgentCdEd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDED", SqlDbType.NChar);
                        paraCustomerAgentCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdEd + "%");
                    }
                }
            }

            //�̔��G���A�R�[�h�i�J�n�j
            if (extrInfo_DemandTotalWork.SalesAreaCodeSt > 0)
            {
                retString.Append("AND B.SALESAREACODERF>=@SALESAREACODEST ");
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.SalesAreaCodeSt);
            }

            //�̔��G���A�R�[�h�i�I���j
            if (extrInfo_DemandTotalWork.SalesAreaCodeEd > 0)
            {
                retString.Append("AND B.SALESAREACODERF<=@SALESAREACODEED ");
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.SalesAreaCodeEd);
            }

            //������̂ݏo��
            retString.Append("AND A.CUSTOMERCODERF=0 ");

            if (extrInfo_DemandTotalWork.SlipPrtKind != 0)
            {
                retString.Append("AND ( (A.CUSTOMERCODERF =0 " + Environment.NewLine
                                + "       AND( A.LASTTIMEDEMANDRF != 0 " + Environment.NewLine
                                + "           OR A.ACPODRTTL2TMBFBLDMDRF != 0" + Environment.NewLine
                                + "           OR A.ACPODRTTL3TMBFBLDMDRF != 0" + Environment.NewLine
                                + "           OR A.THISTIMEDMDNRMLRF != 0" + Environment.NewLine
                                + "           OR A.OFSTHISTIMESALESRF != 0" + Environment.NewLine
                                + "           OR A.OFSTHISSALESTAXRF != 0 " + Environment.NewLine
                                + "           OR A.SALESSLIPCOUNTRF !=0 )) " + Environment.NewLine
                                + "      OR(A.CUSTOMERCODERF !=0  " + Environment.NewLine
                                + "        AND(A.OFSTHISTIMESALESRF !=0" + Environment.NewLine
                                + "           OR A.SALESSLIPCOUNTRF !=0))" + Environment.NewLine
                                + "    )");
            }
            else
            {
                retString.Append("AND ( (A.CUSTOMERCODERF =0 " + Environment.NewLine
                                + "       AND( A.LASTTIMEDEMANDRF != 0 " + Environment.NewLine
                                + "           OR A.ACPODRTTL2TMBFBLDMDRF != 0" + Environment.NewLine
                                + "           OR A.ACPODRTTL3TMBFBLDMDRF != 0" + Environment.NewLine
                                + "           OR A.THISTIMEDMDNRMLRF != 0" + Environment.NewLine
                                + "           OR A.OFSTHISTIMESALESRF != 0" + Environment.NewLine
                                + "           OR A.OFSTHISSALESTAXRF != 0 " + Environment.NewLine
                                + "           OR A.THISTIMEFEEDMDNRMLRF != 0" + Environment.NewLine
                                + "           OR A.THISTIMEDISDMDNRMLRF != 0 " + Environment.NewLine
                                + "           OR H.CNT != 0 " + Environment.NewLine
                                + "           OR A.SALESSLIPCOUNTRF !=0 )) " + Environment.NewLine
                                + "      OR(A.CUSTOMERCODERF !=0  " + Environment.NewLine
                                + "        AND(A.OFSTHISTIMESALESRF !=0" + Environment.NewLine
                                + "           OR A.SALESSLIPCOUNTRF !=0))" + Environment.NewLine
                                + "    )");
            }

            return retString.ToString();
        }
        #endregion

        #region [�����ꗗ�\���o���ʃN���X�i�[����]
        /// <summary>
        /// �����ꗗ�\���o���ʃN���X�i�[���� Reader �� RsltInfo_EBooksDemandTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_EBooksDemandTotalWork</returns>
        /// <remarks>
        /// <br>Note        : �����ꗗ�\���o���ʃN���X�i�[����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private RsltInfo_EBooksDemandTotalWork CopyToRsltInfo_DemandTotalFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_EBooksDemandTotalWork wkRsltInfo_EBooksDemandTotalWork = new RsltInfo_EBooksDemandTotalWork();

            #region �N���X�֊i�[
            wkRsltInfo_EBooksDemandTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_EBooksDemandTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMEKANARF"));
            wkRsltInfo_EBooksDemandTotalWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkRsltInfo_EBooksDemandTotalWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            wkRsltInfo_EBooksDemandTotalWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkRsltInfo_EBooksDemandTotalWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkRsltInfo_EBooksDemandTotalWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            wkRsltInfo_EBooksDemandTotalWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            wkRsltInfo_EBooksDemandTotalWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            wkRsltInfo_EBooksDemandTotalWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
            wkRsltInfo_EBooksDemandTotalWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
            wkRsltInfo_EBooksDemandTotalWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            wkRsltInfo_EBooksDemandTotalWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            wkRsltInfo_EBooksDemandTotalWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            wkRsltInfo_EBooksDemandTotalWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
            wkRsltInfo_EBooksDemandTotalWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
            wkRsltInfo_EBooksDemandTotalWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            wkRsltInfo_EBooksDemandTotalWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkRsltInfo_EBooksDemandTotalWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            wkRsltInfo_EBooksDemandTotalWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            wkRsltInfo_EBooksDemandTotalWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            wkRsltInfo_EBooksDemandTotalWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkRsltInfo_EBooksDemandTotalWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_EBooksDemandTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_EBooksDemandTotalWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            wkRsltInfo_EBooksDemandTotalWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkRsltInfo_EBooksDemandTotalWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkRsltInfo_EBooksDemandTotalWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkRsltInfo_EBooksDemandTotalWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            wkRsltInfo_EBooksDemandTotalWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkRsltInfo_EBooksDemandTotalWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkRsltInfo_EBooksDemandTotalWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            wkRsltInfo_EBooksDemandTotalWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkRsltInfo_EBooksDemandTotalWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkRsltInfo_EBooksDemandTotalWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkRsltInfo_EBooksDemandTotalWork.BillPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BILLPRINTDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.ExpectedDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTEDDEPOSITDATERF"));
            wkRsltInfo_EBooksDemandTotalWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkRsltInfo_EBooksDemandTotalWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkRsltInfo_EBooksDemandTotalWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkRsltInfo_EBooksDemandTotalWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
            wkRsltInfo_EBooksDemandTotalWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkRsltInfo_EBooksDemandTotalWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
            wkRsltInfo_EBooksDemandTotalWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
            wkRsltInfo_EBooksDemandTotalWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));

            #endregion

            return wkRsltInfo_EBooksDemandTotalWork;
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�@�N���X�i�[���� Reader �� TaxRateSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TaxRateSetWork</returns>
        /// <remarks>
        /// <br>Note        : �ŗ��ݒ�}�X�^�@�N���X�i�[����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private TaxRateSetWork CopyToTaxRateSetWorkFromReader(ref SqlDataReader myReader)
        {
            TaxRateSetWork wkTaxRateSetWork = new TaxRateSetWork();

            #region �N���X�֊i�[
            wkTaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));
            wkTaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));
            wkTaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
            wkTaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
            wkTaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));
            wkTaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
            wkTaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
            wkTaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));
            wkTaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
            #endregion

            return wkTaxRateSetWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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

        #region �y���ŗ�

        #region [SearchSalesProc]
        /// <summary>
        /// ����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="demandTotalWork">��������</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="extrInfo_DemandTotalWork">�����ꗗ�\���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/10/27</br>
        /// </remarks>
        private int SearchSalesProc(ref RsltInfo_EBooksDemandTotalWork demandTotalWork, ref SqlConnection sqlConnection, ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

            // ��ƃR�[�h
            string enterpriseCode = extrInfo_DemandTotalWork.EnterpriseCode;

            // �ŗ�1
            double taxRate1 = extrInfo_DemandTotalWork.TaxRate1;

            // �ŗ�2
            double taxRate2 = extrInfo_DemandTotalWork.TaxRate2;

            // �v��N����
            int addUpDate = Convert.ToInt32(extrInfo_DemandTotalWork.AddUpDate.ToString("yyyyMMdd"));

            // ����œ]�ŕ������X�g
            List<int> consTaxLayMethodList = new List<int>();

            string sqlText = string.Empty;

            try
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 3600;
                    #region �� �W�v���R�[�h�W�v����
                    sqlText = string.Empty;
                    #region SELECT���쐬
                    #region SELECT
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCCDRF,--�[�������敪" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCUNITRF,--�[�������P��" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF + ACCREC.RETSALESNETPRICERF + ACCREC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,               -- ���E�㍡�񔄏���z" + Environment.NewLine;
                    sqlText += "-- �� �� ����" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF AS THISTIMESALESRF," + Environment.NewLine;
                    sqlText += "-- �� �� �ԕi" + Environment.NewLine;
                    sqlText += "ACCREC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF," + Environment.NewLine;
                    sqlText += "-- �� �� �l��" + Environment.NewLine;
                    sqlText += "ACCREC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF," + Environment.NewLine;
                    sqlText += "ACCREC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,        --����`�[����" + Environment.NewLine;
                    sqlText += "ACCREC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF,     --�[�������敪" + Environment.NewLine;
                    sqlText += "ACCREC.SLIPSALESPRICECONSTAX AS SLIPSALESPRICECONSTAX, --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "ACCREC.DTLSALESPRICECONSTAX AS DTLSALESPRICECONSTAX,   --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "ACCREC.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "ACCREC.TAXATIONDIVCDRF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "ACCREC.CONSTAXRATERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    #endregion

                    #region SUB�N�G��
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine;
                    sqlText += "   -- �� �� ����" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "   -- �� �� �ԕi" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --�ԕi�������z" + Environment.NewLine;
                    sqlText += "   -- �� �� �l��" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --�l�����z�v�i�Ŕ����j" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SLIPSALESPRICECONSTAX) AS SLIPSALESPRICECONSTAX,  --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "   SUM(SALE.DTLSALESPRICECONSTAX) AS DTLSALESPRICECONSTAX,    --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "   SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "   SALE.TAXATIONDIVCDRF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "     SELECT" + Environment.NewLine;
                    sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEMANDADDUPSECCDRF," + Environment.NewLine;
                    // --- DEL START 3H ���� 2022/10/27 ----->>>>>
                    //sqlText += "      SUBSALE.SALESNETPRICERF + SALESDTL.DISSALESTAXEXCGYO AS SALESNETPRICERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 ) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    // --- DEL END 3H ���� 2022/10/27 -----<<<<<
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "      (CASE WHEN (SALESDTL.SALESSLIPCDRF =0) THEN SALESDTL.SALESMONEY + SALESDTL.DISSALESTAXEXCGYO WHEN (SALESDTL.SALESSLIPCDRF =1) THEN SALESDTL.RETSALESMONEY + SALESDTL.DISSALESTAXEXCGYO ELSE 0 END) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "      SALESDTL.DISGOODSSTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SALESDTL.TAXATIONDIVCDRF AS TAXATIONDIVCDRF, --�ېŋ敪" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 AND SALESDTL.TAXATIONDIVCDRF = 0) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =1 ) THEN DTLSALESPRICECONSTAX ELSE 0 END) AS DTLSALESPRICECONSTAX," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXRATERF" + Environment.NewLine;
                    sqlText += "     FROM" + Environment.NewLine;
                    sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "       DTL.TAXATIONDIVCDRF,--�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "       --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       SUM(DTL.SALESPRICECONSTAXRF) AS DTLSALESPRICECONSTAX,-- ���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       --�s�l��" + Environment.NewLine;
                    // --- DEL START 3H ���� 2022/10/27 ----->>>>>
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO-- �Ŕ��l�����z(�s�l��)" + Environment.NewLine;
                    // --- DEL END 3H ���� 2022/10/27 -----<<<<<
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- �Ŕ��l�����z(�s�l��)" + Environment.NewLine;
                    sqlText += "       --���i�l�����z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF <>0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISGOODSSTAXEXCGYO,-- �Ŕ��l�����z(���i�l��)" + Environment.NewLine;
                    sqlText += "       --������z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEY,-- ������z" + Environment.NewLine;
                    sqlText += "       --�ԕi���z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 1 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS RETSALESMONEY-- �ԕi���z" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       SALESDETAILRF AS DTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "      LEFT JOIN SALESSLIPRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    //sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine; // --- DEL 3H ���� 2022/10/27
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONDIVCDRF --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "  ) AS SALE" + Environment.NewLine;
                    #endregion

                    #region JOIN��
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += " AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine;
                    #endregion

                    #region WHERE��
                    sqlText += "WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "   AND SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                    sqlText += "   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(demandTotalWork.AddUpSecCode);
                    #region [WHERE�吶������]
                    //�W���S���R�[�h�i�J�n�j�i�I���j
                    if ((extrInfo_DemandTotalWork.BillCollecterCdSt != "") && (extrInfo_DemandTotalWork.BillCollecterCdSt == extrInfo_DemandTotalWork.BillCollecterCdEd))
                    {
                        sqlText += "AND CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDST " + Environment.NewLine;
                        SqlParameter paraBillCollecterCdSt = sqlCommand.Parameters.Add("@BILLCOLLECTERCDST", SqlDbType.NChar);
                        paraBillCollecterCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdSt + "%");
                    }
                    else
                    {
                        //�W���S���R�[�h�i�J�n�j
                        if (extrInfo_DemandTotalWork.BillCollecterCdSt != "")
                        {
                            sqlText += "AND CLAIM.BILLCOLLECTERCDRF>=@BILLCOLLECTERCDST " + Environment.NewLine;
                            SqlParameter paraBillCollecterCdSt = sqlCommand.Parameters.Add("@BILLCOLLECTERCDST", SqlDbType.NChar);
                            paraBillCollecterCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdSt);
                        }
                        //�W���S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                        if (extrInfo_DemandTotalWork.BillCollecterCdEd != "" && extrInfo_DemandTotalWork.BillCollecterCdSt == "")
                        {
                            sqlText += "AND ( CLAIM.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED OR B.BILLCOLLECTERCDRF IS NULL ) " + Environment.NewLine;
                            SqlParameter paraBillCollecterCdEd = sqlCommand.Parameters.Add("@BILLCOLLECTERCDED", SqlDbType.NChar);
                            paraBillCollecterCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdEd);
                        }
                        else
                        {
                            //�W���S���R�[�h�i�I���j
                            if (extrInfo_DemandTotalWork.BillCollecterCdEd != "")
                            {
                                sqlText += "AND ( CLAIM.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED ) " + Environment.NewLine;
                                SqlParameter paraBillCollecterCdEd = sqlCommand.Parameters.Add("@BILLCOLLECTERCDED", SqlDbType.NChar);
                                paraBillCollecterCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.BillCollecterCdEd + "%");
                            }
                        }
                    }

                    //�ڋq�S���R�[�h�i�J�n�j�i�I���j
                    if ((extrInfo_DemandTotalWork.CustomerAgentCdSt != "") && (extrInfo_DemandTotalWork.CustomerAgentCdSt == extrInfo_DemandTotalWork.CustomerAgentCdEd))
                    {
                        sqlText += "AND CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDST " + Environment.NewLine;
                        SqlParameter paraCustomerAgentCdSt = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDST", SqlDbType.NChar);
                        paraCustomerAgentCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdSt + "%");
                    }
                    else
                    {
                        //�ڋq�S���R�[�h�i�J�n�j
                        if (extrInfo_DemandTotalWork.CustomerAgentCdSt != "")
                        {
                            sqlText += "AND CLAIM.CUSTOMERAGENTCDRF>=@CUSTOMERAGENTCDST " + Environment.NewLine;
                            SqlParameter paraCustomerAgentCdSt = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDST", SqlDbType.NChar);
                            paraCustomerAgentCdSt.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdSt);
                        }
                        //�ڋq�S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                        if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "" && extrInfo_DemandTotalWork.CustomerAgentCdSt == "")
                        {
                            sqlText += "AND ( CLAIM.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED OR B.CUSTOMERAGENTCDRF IS NULL ) " + Environment.NewLine;
                            SqlParameter paraCustomerAgentCdEd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDED", SqlDbType.NChar);
                            paraCustomerAgentCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdEd);
                        }
                        else
                        {
                            //�ڋq�S���R�[�h�i�I���j
                            if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "")
                            {
                                sqlText += "AND ( CLAIM.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED ) " + Environment.NewLine;
                                SqlParameter paraCustomerAgentCdEd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDED", SqlDbType.NChar);
                                paraCustomerAgentCdEd.Value = SqlDataMediator.SqlSetString(extrInfo_DemandTotalWork.CustomerAgentCdEd + "%");
                            }
                        }
                    }
                    //�̔��G���A�R�[�h�i�J�n�j
                    if (extrInfo_DemandTotalWork.SalesAreaCodeSt > 0)
                    {
                        sqlText += "AND CLAIM.SALESAREACODERF>=@SALESAREACODEST " + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                        paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.SalesAreaCodeSt);
                    }

                    //�̔��G���A�R�[�h�i�I���j
                    if (extrInfo_DemandTotalWork.SalesAreaCodeEd > 0)
                    {
                        sqlText += "AND CLAIM.SALESAREACODERF<=@SALESAREACODEED " + Environment.NewLine;
                        SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                        paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(extrInfo_DemandTotalWork.SalesAreaCodeEd);
                    }

                    // ���Ӑ�R�[�h
                    if (demandTotalWork.CustomerCode != 0)
                    {
                        sqlText += "AND SALE.CUSTOMERCODERF =@CUSTOMERCODE " + Environment.NewLine;
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(demandTotalWork.CustomerCode);

                        sqlText += "AND SALE.RESULTSADDUPSECCDRF =@RESULTSADDUPSECCD " + Environment.NewLine;
                        SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                        paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(demandTotalWork.ResultsSectCd);
                    }
                    #endregion

                    #endregion

                    #region GROUP BY��
                    sqlText += "GROUP BY" + Environment.NewLine;
                    sqlText += " CLAIM.SALESCNSTAXFRCPROCCDRF,--�������Œ[�������R�[�h" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCUNITRF,--�[�������P��" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCCDRF,  --�[�������敪" + Environment.NewLine;
                    sqlText += " SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    //sqlText += " SALE.CONSTAXRATERF" + Environment.NewLine; // --- DEL 3H ���� 2022/10/27
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    sqlText += " SALE.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += " SALE.TAXATIONDIVCDRF" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    sqlText += ") AS ACCREC" + Environment.NewLine;
                    #endregion
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region Prameter�I�u�W�F�N�g�̍쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(demandTotalWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandTotalWork.AddUpDate);
                    if (demandTotalWork.LastCAddUpUpdDate != DateTime.MinValue)
                    {
                        findParaLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(demandTotalWork.LastCAddUpUpdDate);
                    }
                    else
                    {
                        //findParaLastCAddUpUpdDate.Value = 20000101;
                        bool chgFlg = false;
                        int per2yearAddUpdate = 0;
                        //���Џ��擾
                        CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                        CompanyInfDB companyInfDB = new CompanyInfDB();
                        ArrayList arrayList = new ArrayList();

                        paraCompanyInfWork.EnterpriseCode = enterpriseCode;
                        companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
                        paraCompanyInfWork = (CompanyInfWork)arrayList[0];

                        //���Џ��.����N������1�N�O�̓��̐ݒ�
                        if (paraCompanyInfWork.CompanyBiginDate != 0)
                        {
                            DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                            DateTime dt1YearBefore = dt.AddYears(-1);
                            DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                            chgFlg = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
                            findParaLastCAddUpUpdDate.Value = per2yearAddUpdate;
                        }
                    }
                    #endregion

                    myReader = sqlCommand.ExecuteReader();

                    // �[�������P��
                    double fractionProcUnit = 0;
                    // �`�[�]�ŁE���ד]�ŏ����
                    long totalSalesPricTax = 0;
                    while (myReader.Read())
                    {
                        #region �W�v���R�[�h�Z�b�g
                        custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //�[�������敪
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // �[�������P��
                        custDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// ����œ]�ŕ���
                        custDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));         // �ŗ�
                        // ������Ŋz
                        if (custDmdPrcWork.ConsTaxLayMethod == 0)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPSALESPRICECONSTAX"));
                        }
                        else if (custDmdPrcWork.ConsTaxLayMethod == 1)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSALESPRICECONSTAX"));
                        }
                        else
                        {
                            totalSalesPricTax = 0;
                        }
                        // �����E
                        custDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // ���E�㍡�񔄏���z

                        // ������
                        custDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // ���񔄏���z 

                        // ���ԕi
                        custDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));    // ����ԕi���z

                        // ���l��
                        custDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // ���񔄏�l�����z

                        // ����`�[����
                        custDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));

                        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                        // �ېŋ敪
                        int taxationDivCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                        // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                        #endregion

                        #region �ŕʓ����
                        // �ŗ�1
                        //if (custDmdPrcWork.ConsTaxLayMethod != 9 && custDmdPrcWork.ConsTaxRate == taxRate1) // --- DEL 3H ���� 2022/10/27
                        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                        if ((custDmdPrcWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custDmdPrcWork.ConsTaxRate == taxRate1)
                        // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                        {
                            // ����z(�v�ŗ�1)
                            demandTotalWork.TotalThisTimeSalesTaxRate1 += custDmdPrcWork.ThisTimeSales;
                            // �ԕi�l��(�v�ŗ�1)
                            demandTotalWork.TotalThisRgdsDisPricTaxRate1 -= custDmdPrcWork.ThisSalesPricRgds + custDmdPrcWork.ThisSalesPricDis;
                            // ������z(�v�ŗ�1)
                            demandTotalWork.TotalPureSalesTaxRate1 += custDmdPrcWork.OfsThisTimeSales;
                            // �����(�v�ŗ�1)
                            if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                            {
                                demandTotalWork.TotalSalesPricTaxTaxRate1 += totalSalesPricTax;
                            }
                            // ����(�v�ŗ�1)
                            demandTotalWork.TotalSalesSlipCountTaxRate1 += custDmdPrcWork.SalesSlipCount;
                        }
                        // �ŗ�2
                        //else if (custDmdPrcWork.ConsTaxLayMethod != 9 && custDmdPrcWork.ConsTaxRate == taxRate2) // --- DEL 3H ���� 2022/10/27
                        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                        else if ((custDmdPrcWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custDmdPrcWork.ConsTaxRate == taxRate2)
                        // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                        {
                            // ����z(�v�ŗ�2)
                            demandTotalWork.TotalThisTimeSalesTaxRate2 += custDmdPrcWork.ThisTimeSales;
                            // �ԕi�l��(�v�ŗ�2)
                            demandTotalWork.TotalThisRgdsDisPricTaxRate2 -= custDmdPrcWork.ThisSalesPricRgds + custDmdPrcWork.ThisSalesPricDis;
                            // ������z(�v�ŗ�2)
                            demandTotalWork.TotalPureSalesTaxRate2 += custDmdPrcWork.OfsThisTimeSales;
                            // �����(�v�ŗ�2)
                            if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                            {
                                demandTotalWork.TotalSalesPricTaxTaxRate2 += totalSalesPricTax;
                            }
                            // ����(�v�ŗ�2)
                            demandTotalWork.TotalSalesSlipCountTaxRate2 += custDmdPrcWork.SalesSlipCount;
                        }
                        // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                        else if (custDmdPrcWork.ConsTaxLayMethod == 9 || taxationDivCdRF == 1)
                        {
                            // ����z(�v��ې�)
                            demandTotalWork.TotalThisTimeSalesTaxFree += custDmdPrcWork.ThisTimeSales;
                            // �ԕi�l��(�v��ې�)
                            demandTotalWork.TotalThisRgdsDisPricTaxFree -= custDmdPrcWork.ThisSalesPricRgds + custDmdPrcWork.ThisSalesPricDis;
                            // ������z(�v��ې�)
                            demandTotalWork.TotalPureSalesTaxFree += custDmdPrcWork.OfsThisTimeSales;
                            // �����(�v��ې�)
                            demandTotalWork.TotalSalesPricTaxTaxFree = 0;
                            // ����(�v��ې�)
                            demandTotalWork.TotalSalesSlipCountTaxFree += custDmdPrcWork.SalesSlipCount;
                        }
                        // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                        // ���̑�
                        else
                        {
                            // ����z(�v���̑�)
                            demandTotalWork.TotalThisTimeSalesOther += custDmdPrcWork.ThisTimeSales;
                            // �ԕi�l��(�v���̑�)
                            demandTotalWork.TotalThisRgdsDisPricOther -= custDmdPrcWork.ThisSalesPricRgds + custDmdPrcWork.ThisSalesPricDis;
                            // ������z(�v���̑�)
                            demandTotalWork.TotalPureSalesOther += custDmdPrcWork.OfsThisTimeSales;
                            // �����(�v���̑�)
                            if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                            {
                                demandTotalWork.TotalSalesPricTaxOther += totalSalesPricTax;
                            }
                            // ����(�v���̑�)
                            demandTotalWork.TotalSalesSlipCountOther += custDmdPrcWork.SalesSlipCount;
                        }
                        #endregion

                        if (!consTaxLayMethodList.Contains(custDmdPrcWork.ConsTaxLayMethod))
                        {
                            consTaxLayMethodList.Add(custDmdPrcWork.ConsTaxLayMethod);
                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (!myReader.IsClosed) myReader.Close();
                    sqlText = string.Empty;

                    #region ����łƓ������v�Z�o
                    foreach (int consTaxLayMethod in consTaxLayMethodList)
                    {
                        // �`�[�]�ŁE���ד]�ŁE��ې�
                        if (consTaxLayMethod == 0 || consTaxLayMethod == 1 || consTaxLayMethod == 9)
                        {
                            continue;
                        }

                        switch (consTaxLayMethod)
                        {
                            // �����e
                            case 2:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                                //sqlText += "	    SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine; // --- DEL 3H ���� 2022/10/27
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=2" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += TotalMakeWhereString(extrInfo_DemandTotalWork);
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   CONSTAXRATERF" + Environment.NewLine;
                                break;
                            // �����q
                            case 3:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALE.SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "  SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "  SALE.CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                sqlText += "		SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                                //sqlText += "		SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine; // --- DEL 3H ���� 2022/10/27
                                sqlText += "		SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "		CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "		WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "		WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=3" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += TotalMakeWhereString(extrInfo_DemandTotalWork);
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "   SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                                break;
                        }

                        // �����]�ł݂̂̏ꍇ�A����Ŏq�������s��
                        if (!string.IsNullOrEmpty(sqlText))
                        {
                            sqlCommand.CommandText = sqlText;
                            myReader = sqlCommand.ExecuteReader();
                        }

                        // ����`�[���v�i�Ŕ����j
                        long salesTotal = 0;
                        // ����Őŗ�
                        double consTaxRate = 0.0;
                        // �����(�[��������)
                        long tempTax = 0;
                        while (myReader.Read())
                        {
                            switch (consTaxLayMethod)
                            {
                                // �����e
                                case 2:
                                // �����q
                                case 3:
                                    salesTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                                    consTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                                    // �ŗ�1
                                    if (consTaxRate == taxRate1)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custDmdPrcWork.FractionProcCd, out tempTax);
                                        demandTotalWork.TotalSalesPricTaxTaxRate1 += tempTax;
                                    }
                                    // �ŗ�2
                                    else if (consTaxRate == taxRate2)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custDmdPrcWork.FractionProcCd, out tempTax);
                                        demandTotalWork.TotalSalesPricTaxTaxRate2 += tempTax;
                                    }
                                    // ���̑�
                                    else
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custDmdPrcWork.FractionProcCd, out tempTax);
                                        demandTotalWork.TotalSalesPricTaxOther += tempTax;
                                    }
                                    break;
                            }
                        }

                        // �N�G��������
                        sqlText = string.Empty;
                        if (!myReader.IsClosed) myReader.Close();
                    }
                    #endregion

                    demandTotalWork.TotalThisSalesSumTaxRate1 = demandTotalWork.TotalPureSalesTaxRate1 + demandTotalWork.TotalSalesPricTaxTaxRate1;
                    demandTotalWork.TotalThisSalesSumTaxRate2 = demandTotalWork.TotalPureSalesTaxRate2 + demandTotalWork.TotalSalesPricTaxTaxRate2;
                    // --- ADD START 3H ���� 2022/10/27 ----->>>>>
                    demandTotalWork.TotalThisSalesSumTaxFree = demandTotalWork.TotalPureSalesTaxFree + demandTotalWork.TotalSalesPricTaxTaxFree;
                    // --- ADD END 3H ���� 2022/10/27 -----<<<<<
                    demandTotalWork.TotalThisSalesSumTaxOther = demandTotalWork.TotalPureSalesOther + demandTotalWork.TotalSalesPricTaxOther;
                    #endregion
                }

                demandTotalWork.TitleTaxRate1 = Convert.ToInt32(taxRate1 * 100) + "%";
                demandTotalWork.TitleTaxRate2 = Convert.ToInt32(taxRate2 * 100) + "%";
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillTableDB.SearchSalesProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="extrInfo_DemandTotalWork">���������i�[�N���X</param>
        /// <returns>�����ꗗ�\�ŗ��ʔ����񒊏o��SQL������</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private string TotalMakeWhereString(ExtrInfo_EBooksDemandTotalWork extrInfo_DemandTotalWork)
        {
            //��{WHERE��̍쐬
            string retString = string.Empty;
            #region [WHERE�吶������]
            //�W���S���R�[�h�i�J�n�j�i�I���j
            if ((extrInfo_DemandTotalWork.BillCollecterCdSt != "") && (extrInfo_DemandTotalWork.BillCollecterCdSt == extrInfo_DemandTotalWork.BillCollecterCdEd))
            {
                retString += "AND CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDST " + Environment.NewLine;
            }
            else
            {
                //�W���S���R�[�h�i�J�n�j
                if (extrInfo_DemandTotalWork.BillCollecterCdSt != "")
                {
                    retString += "AND CLAIM.BILLCOLLECTERCDRF>=@BILLCOLLECTERCDST " + Environment.NewLine;
                }
                //�W���S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                if (extrInfo_DemandTotalWork.BillCollecterCdEd != "" && extrInfo_DemandTotalWork.BillCollecterCdSt == "")
                {
                    retString += "AND ( CLAIM.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED OR B.BILLCOLLECTERCDRF IS NULL ) " + Environment.NewLine;
                }
                else
                {
                    //�W���S���R�[�h�i�I���j
                    if (extrInfo_DemandTotalWork.BillCollecterCdEd != "")
                    {
                        retString += "AND ( CLAIM.BILLCOLLECTERCDRF<=@BILLCOLLECTERCDED OR CLAIM.BILLCOLLECTERCDRF LIKE @BILLCOLLECTERCDED ) " + Environment.NewLine;
                    }
                }
            }

            //�ڋq�S���R�[�h�i�J�n�j�i�I���j
            if ((extrInfo_DemandTotalWork.CustomerAgentCdSt != "") && (extrInfo_DemandTotalWork.CustomerAgentCdSt == extrInfo_DemandTotalWork.CustomerAgentCdEd))
            {
                retString += "AND CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDST " + Environment.NewLine;
            }
            else
            {
                //�ڋq�S���R�[�h�i�J�n�j
                if (extrInfo_DemandTotalWork.CustomerAgentCdSt != "")
                {
                    retString += "AND CLAIM.CUSTOMERAGENTCDRF>=@CUSTOMERAGENTCDST " + Environment.NewLine;
                }
                //�ڋq�S���R�[�h�i�I���j�̂ݎw��(NULL�f�[�^���擾)
                if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "" && extrInfo_DemandTotalWork.CustomerAgentCdSt == "")
                {
                    retString += "AND ( CLAIM.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED OR B.CUSTOMERAGENTCDRF IS NULL ) " + Environment.NewLine;
                }
                else
                {
                    //�ڋq�S���R�[�h�i�I���j
                    if (extrInfo_DemandTotalWork.CustomerAgentCdEd != "")
                    {
                        retString += "AND ( CLAIM.CUSTOMERAGENTCDRF<=@CUSTOMERAGENTCDED OR CLAIM.CUSTOMERAGENTCDRF LIKE @CUSTOMERAGENTCDED ) " + Environment.NewLine;
                    }
                }
            }
            //�̔��G���A�R�[�h�i�J�n�j
            if (extrInfo_DemandTotalWork.SalesAreaCodeSt > 0)
            {
                retString += "AND CLAIM.SALESAREACODERF>=@SALESAREACODEST " + Environment.NewLine;
            }

            //�̔��G���A�R�[�h�i�I���j
            if (extrInfo_DemandTotalWork.SalesAreaCodeEd > 0)
            {
                retString += "AND CLAIM.SALESAREACODERF<=@SALESAREACODEED " + Environment.NewLine;
            }
            #endregion

            return retString;
        }
        #endregion

        #region [FracCalc ����Œ[������]
        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="inputNumerical">���l</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultNumerical">�Z�o���z</param>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // �����l�Z�b�g
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// �����_6���ȉ��؎�
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// �����_6���ȉ��؎�

            // �[�����Z�h�~
            if (((decimal)fractionUnit) == 0)
            {
                fractionUnit = 1;
            }
            // �[���P�ʂŏ��Z
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // �}�C�i�X�␳
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // ������1���擾
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin �[���w��
            bool wRoundFlg = true; // �؎�
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:�؎�
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // �؎�
                        break;
                    }
                //--------------------------------------
                // 2:�l�̌ܓ�
                //--------------------------------------
                case 2: // �l�̌ܓ�
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
                //--------------------------------------
                // 3:�؏�
                //--------------------------------------
                case 3: // �؏�
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
            }

            // �[������
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // �������؎�
            tmpKin = (decimal)(long)tmpKin;

            // �}�C�i�X�␳
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // �Z�o�l�Z�b�g
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion
        #endregion
    }
}

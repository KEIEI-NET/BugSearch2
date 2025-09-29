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
using Broadleaf.Library;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �O�N�Δ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�N�Δ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.11.29</br>
    /// <br></br>
    /// <br>UpdateNote : �ԕi���z����d�W�v����Ă���Ή�</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.04.02</br>
    /// <br></br>
    /// <br>UpdateNote : �O���[�v�R�[�h�}�X�^���o�^���̃O���[�v�R�[�h�ʂ̒��o�s��̏C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2011/02/10</br>
    /// <br></br>
    /// <br>UpdateNote : �C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br></br>
    /// <br>UpdateNote : ���s�^�C�v�u�Ǘ����_�ʁv�őS�ЏW�v�ň�����鎞�A�f�[�^�����o����Ȃ���Q�̑Ή�</br>
    /// <br>Programmer : #47029 cheq</br>
    /// <br>Date       : 2015/08/17</br>
    /// </remarks>
    [Serializable]
    public class PrevYearComparisonDB : RemoteDB, IPrevYearComparisonDB
    {
        /// <summary>
        /// �O�N�Δ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
        /// </remarks>
        public PrevYearComparisonDB()
            :
            base("DCTOK02106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PrevYearComparisonWork", "MTTLSALESSLIPRF")
        {
        }

        #region [SearchPrevYearComparison]
        /// <summary>
        /// �w�肳�ꂽ�����̑O�N�Δ�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑O�N�Δ�\��߂��܂�</br>
        /// <br>           : 12�����𒴂���͈͂��w�肳�ꂽ��Y���f�[�^�����Ƃ��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
        public int SearchPrevYearComparison(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork = null;
            //RsltInfo_PrevYearComparisonWork rsltInfo_PrevYearComparisonWork = null;

            ArrayList extrInfo_PrevYearComparisonWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PrevYearComparisonWorkList == null)
            {
                extrInfo_PrevYearComparisonWork = paraObj as ExtrInfo_PrevYearComparisonWork;
            }
            else
            {
                if (extrInfo_PrevYearComparisonWorkList.Count > 0)
                    extrInfo_PrevYearComparisonWork = extrInfo_PrevYearComparisonWorkList[0] as ExtrInfo_PrevYearComparisonWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTMTTLSALSLIPRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����ꂼ��̑O�N�Δ�\�擾
                status = SearchPrevYearComparisonProc(ref retList, extrInfo_PrevYearComparisonWork, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrevYearComparisonDB.SearchPrevYearComparison");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //���Í����L�[CLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

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
        /// �w�肳�ꂽ�����̑O�N�Δ�\��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_PrevYearComparisonWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑O�N�Δ�\��߂��܂�</br>
        /// <br>           : 12�����𒴂���͈͂��w�肳�ꂽ��Y���f�[�^�����Ƃ��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
        /// <br></br>
        private int SearchPrevYearComparisonProc(ref ArrayList retList, ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            Int32 monthRange = ((extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth / 100) - (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth / 100)) * 12 + (extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth % 100) - (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth % 100) + 1;
            //12�����𒴂���͈͂��w�肳�ꂽ��Y���f�[�^�����Ƃ��܂�
            if (monthRange > 12)
            {
                return status;
            }

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL��]
                //GroupBy���ޔ�
                string groupByString = string.Empty;
                string joinString = string.Empty;

                string selectTxt = string.Empty;

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   MAIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.NAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SALESAREACODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SALESAREANAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BUSINESSTYPECODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BUSINESSTYPENAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.ADDUPYEARMONTHRF AS ADDUPMONTHRF" + Environment.NewLine;  //���ŃO���[�v�����邽��
                selectTxt += "  ,SUM(MAIN.THISTERMSALESRF) AS THISTERMSALESRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.THISTERMGROSSRF) AS THISTERMGROSSRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.FIRSTTERMSALESRF) AS FIRSTTERMSALESRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.FIRSTTERMGROSSRF) AS FIRSTTERMGROSSRF" + Environment.NewLine;

                sqlCommand.CommandText += selectTxt;

                sqlCommand.CommandText += "FROM (" + Environment.NewLine;

                for (int loopcnt = 0; loopcnt <= 1; loopcnt++)
                {
                    //loopcnt=1�͑O�N���𒊏o����N�G�����쐬
                    if (loopcnt == 1)
                    {
                        sqlCommand.CommandText += "UNION ALL" + Environment.NewLine;
                    }

                    sqlCommand.CommandText += MakeSelectHeader(extrInfo_PrevYearComparisonWork, ref joinString ,loopcnt);

                    //�e��}�X�^�i�n�h�m��
                    sqlCommand.CommandText += joinString;

                    //WHERE��
                    sqlCommand.CommandText += MakeWhereString(extrInfo_PrevYearComparisonWork, ref sqlCommand, loopcnt);


                }

                sqlCommand.CommandText += ") AS MAIN" + Environment.NewLine;

                //GROUP BY��
                groupByString = " GROUP BY" + Environment.NewLine;
                groupByString += "   MAIN.ADDUPSECCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SECTIONGUIDESNMRF" + Environment.NewLine;
                groupByString += "  ,MAIN.CUSTOMERCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.CUSTOMERSNMRF" + Environment.NewLine;
                groupByString += "  ,MAIN.EMPLOYEECODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.NAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGOODSCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGOODSHALFNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSLGROUPRF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSLGROUPNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSMGROUPRF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSMGROUPNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGROUPCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGROUPKANANAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SALESAREACODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SALESAREANAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BUSINESSTYPECODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BUSINESSTYPENAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText += groupByString;

                #endregion

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                RsltInfo_PrevYearComparisonWork rsltInfo_PrevYearComparisonWork;
                while (myReader.Read())
                {
                    rsltInfo_PrevYearComparisonWork = CopyToRsltInfo_PrevYearComparisonFromReader(ref myReader, extrInfo_PrevYearComparisonWork);

                    retList.Add(rsltInfo_PrevYearComparisonWork);
                }

                if (!myReader.IsClosed) myReader.Close();

                if (retList.Count != 0)
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

        #endregion

        #region [�O�N�Δ�\���o���ʃN���X�i�[����]
        /// <summary>
        /// �O�N�Δ�\���o���ʃN���X�i�[���� Reader �� RsltInfo_PrevYearComparisonWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_PrevYearComparisonWork">���o����</param>
        /// <returns>RsltInfo_PrevYearComparisonWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
        /// <br></br>
        /// </remarks>
        private RsltInfo_PrevYearComparisonWork CopyToRsltInfo_PrevYearComparisonFromReader(ref SqlDataReader myReader,ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork)
        {
            RsltInfo_PrevYearComparisonWork wkRsltInfo_PrevYearComparisonWork = new RsltInfo_PrevYearComparisonWork();

            wkRsltInfo_PrevYearComparisonWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PrevYearComparisonWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkRsltInfo_PrevYearComparisonWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_PrevYearComparisonWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_PrevYearComparisonWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkRsltInfo_PrevYearComparisonWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            wkRsltInfo_PrevYearComparisonWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkRsltInfo_PrevYearComparisonWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkRsltInfo_PrevYearComparisonWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkRsltInfo_PrevYearComparisonWork.AddUpMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPMONTHRF"));
            wkRsltInfo_PrevYearComparisonWork.ThisTermSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTERMSALESRF"));
            wkRsltInfo_PrevYearComparisonWork.FirstTermSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FIRSTTERMSALESRF"));
            wkRsltInfo_PrevYearComparisonWork.ThisTermGross = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTERMGROSSRF"));
            wkRsltInfo_PrevYearComparisonWork.FirstTermGross = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FIRSTTERMGROSSRF"));

            return wkRsltInfo_PrevYearComparisonWork;
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
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

        #region ���̑��̊֐�
        /// <summary>
        /// �N���{�����̒l�擾����
        /// </summary>
        /// <param name="yearMonth">�N��</param>
        /// <param name="addMonth">���Z�N��</param>
        /// <returns>�N��</returns>
        /// <br>Note       : �w�肳�ꂽ�N���Ɂ{���������l��Ԃ��܂��B</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>		
        private int GetAddYearMonth(int yearMonth, int addMonth)
        {
            DateTime dateTime = new DateTime();
            dateTime = TDateTime.LongDateToDateTime(yearMonth * 100 + 1);
            dateTime = dateTime.AddMonths(addMonth);
            return dateTime.Year * 100 + dateTime.Month;
        }

        #endregion


        /// <summary>
        /// SELECT���쐬
        /// </summary>
        /// <param name="extrInfo_PrevYearComparisonWork">���o����</param>
        /// <param name="joinString">JOIN��</param>
        /// <param name="mode">0:�����A1:�O��</param>
        /// <returns>SELECT��</returns>
        /// <br>Note       : SELECT�����쐬���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.05</br>		
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>�Ǘ��ԍ�    : 11170129-00</br>
        /// <br>            : redmine#47029 �f�[�^�����o����Ȃ��̏�Q�Ή�</br>
        private string MakeSelectHeader(ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref string joinString ,int mode)
        {
            string selectTxt = string.Empty;

            selectTxt += "SELECT ";
            joinString = string.Empty;

            //���[�^�C�v
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                //0:���Ӑ��
                case 0:
                    {
                        //���s�^�C�v
                        //0:���Ӑ��
                        //1:���_��
                        //2:���Ӑ拒�_��
                        //3:�Ǘ����_��
                        //4:�������

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            //���_��
                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if ((extrInfo_PrevYearComparisonWork.printType == 3) ||
                                (extrInfo_PrevYearComparisonWork.printType == 4))
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<

                            }
                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //���Ӑ�R�[�h
                        if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                            (extrInfo_PrevYearComparisonWork.printType == 2) ||
                            (extrInfo_PrevYearComparisonWork.printType == 3))
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        if (extrInfo_PrevYearComparisonWork.printType == 4)
                        {
                            selectTxt += ", CUS.CLAIMCODERF AS CUSTOMERCODERF "
                                       + ", CUS2.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS2 ON CUS.ENTERPRISECODERF=CUS2.ENTERPRISECODERF AND CUS.CLAIMCODERF=CUS2.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=CUS2.ENTERPRISECODERF AND CUS.CLAIMCODERF=CUS2.CUSTOMERCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //�s�v����
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //1:�S���ҕ�
                case 1:
                    {
                        //���s�^�C�v
                        //0:�S���ҕ�
                        //1:���Ӑ��
                        //2:�S���ҋ��_��
                        //3:�Ǘ����_��

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 �f�[�^�����o����Ȃ���Q�̑Ή� ----->>>>>
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            }
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 �f�[�^�����o����Ȃ���Q�̑Ή� -----<<<<<
                        }

                        //�S���҃R�[�h
                        selectTxt += ", TTL.EMPLOYEECODERF "
                                   + ", EMP.NAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        // 2011/08/01 <<<

                        //���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //�s�v����
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //2:�󒍎ҕ�
                case 2:
                    {
                        //���s�^�C�v
                        //0:�󒍎ҕ�
                        //1:���Ӑ��
                        //2:�󒍎ҋ��_��
                        //3:�Ǘ����_��

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<

                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                            // ----- ADD cheq 2015/08/17 RedMine#47029 �f�[�^�����o����Ȃ���Q�̑Ή� ----->>>>>
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            }
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 �f�[�^�����o����Ȃ���Q�̑Ή� -----<<<<<
                        }

                        //�S���҃R�[�h
                        selectTxt += ", TTL.EMPLOYEECODERF "
                                   + ", EMP.NAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        // 2011/08/01 <<<

                        //���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //�s�v����
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //3:�n���
                case 3:
                    {
                        //���s�^�C�v
                        //0:�n���
                        //1:���Ӑ��
                        //2:�n�拒�_��
                        //3:�Ǘ����_��

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }


                        //�n��R�[�h
                        selectTxt += ", (CASE WHEN CUS.SALESAREACODERF IS NULL THEN 0 ELSE CUS.SALESAREACODERF END) AS SALESAREACODERF "
                                   + ", AREA.GUIDENAMERF AS SALESAREANAMERF ";

                        if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                        {
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS AREA ON TTL.ENTERPRISECODERF=AREA.ENTERPRISECODERF AND AREA.USERGUIDEDIVCDRF=21 AND CUS.SALESAREACODERF=AREA.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS AREA WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=AREA.ENTERPRISECODERF AND AREA.USERGUIDEDIVCDRF=21 AND CUS.SALESAREACODERF=AREA.GUIDECODERF ";
                        // 2011/08/01 <<<


                        //���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }
                        
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //�s�v����
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //4:�Ǝ��
                case 4:
                    {
                        //���s�^�C�v
                        //0:�Ǝ��
                        //1:���Ӑ��
                        //2:�Ǝ틒�_��
                        //3:�Ǘ����_��

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //�Ǝ�R�[�h
                        selectTxt += ", (CASE WHEN CUS.BUSINESSTYPECODERF IS NULL THEN 0 ELSE CUS.BUSINESSTYPECODERF END) AS BUSINESSTYPECODERF "
                                   + ", BUS.GUIDENAMERF AS BUSINESSTYPENAMERF ";

                        if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                        {
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS BUS ON TTL.ENTERPRISECODERF=BUS.ENTERPRISECODERF AND BUS.USERGUIDEDIVCDRF=33 AND CUS.BUSINESSTYPECODERF=BUS.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS BUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BUS.ENTERPRISECODERF AND BUS.USERGUIDEDIVCDRF=33 AND CUS.BUSINESSTYPECODERF=BUS.GUIDECODERF ";
                        // 2011/08/01 <<<

                        //���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //�s�v����
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";

                        break;
                    }
                //5:�O���[�v�R�[�h��
                case 5:
                    {
                        //���s�^�C�v
                        //0:�O���[�v�R�[�h��
                        //1:���i�����ޕ�
                        //2:���i�啪�ޕ�

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {
                            selectTxt += "  TTL.ADDUPSECCODERF "
                                       + ", SEC.SECTIONGUIDESNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //�O���[�v�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 0)
                        {
                            selectTxt += ", BL.BLGROUPCODERF "
                                       + ", GRP.BLGROUPKANANAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 BLGROUPCODERF "
                                       + ", '' BLGROUPKANANAMERF ";
                        }
                        
                        //���i������
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", GRP.GOODSMGROUPRF "
                                       + ", GDM.GOODSMGROUPNAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 GOODSMGROUPRF "
                                       + ", '' GOODSMGROUPNAMERF ";
                        }

                        //���i�啪��
                        if (extrInfo_PrevYearComparisonWork.printType == 2)
                        {
                            
                            // -- UPD 2011/02/10 ------------------------>>>
                            //selectTxt += ", GRP.GOODSLGROUPRF "
                            selectTxt += ", (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END) AS GOODSLGROUPRF"
                            // -- UPD 2011/02/10 ------------------------<<<
                                       + ", GDL.GUIDENAMERF AS GOODSLGROUPNAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 GOODSLGROUPRF "
                                       + ", '' GOODSLGROUPNAMERF ";
                        }

                        //�s�v����
                        selectTxt += ", 0 CUSTOMERCODERF "
                                   + ", '' CUSTOMERSNMRF ";
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN BLGOODSCDURF AS BL ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        //joinString += "LEFT JOIN BLGROUPURF AS GRP ON BL.ENTERPRISECODERF=GRP.ENTERPRISECODERF AND BL.BLGROUPCODERF=GRP.BLGROUPCODERF ";
                        //joinString += "LEFT JOIN GOODSGROUPURF AS GDM ON GRP.ENTERPRISECODERF=GDM.ENTERPRISECODERF AND GRP.GOODSMGROUPRF=GDM.GOODSMGROUPRF ";
                        joinString += "LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        joinString += "LEFT JOIN BLGROUPURF AS GRP WITH (READUNCOMMITTED) ON BL.ENTERPRISECODERF=GRP.ENTERPRISECODERF AND BL.BLGROUPCODERF=GRP.BLGROUPCODERF ";
                        joinString += "LEFT JOIN GOODSGROUPURF AS GDM WITH (READUNCOMMITTED) ON GRP.ENTERPRISECODERF=GDM.ENTERPRISECODERF AND GRP.GOODSMGROUPRF=GDM.GOODSMGROUPRF ";
                        // 2011/08/01 <<<
                        // -- UPD 2011/02/10 ---------------------------------------->>>
                        //joinString += "LEFT JOIN USERGDBDURF AS GDL ON GRP.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND GRP.GOODSLGROUPRF=GDL.GUIDECODERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS GDL ON TTL.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END)=GDL.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS GDL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END)=GDL.GUIDECODERF ";
                        // 2011/08/01 <<<
                        // -- UPD 2011/02/10 ----------------------------------------<<<

                        break;
                    }
                //6:BL�R�[�h��
                case 6:
                    {
                        //���s�^�C�v
                        //0:BL�R�[�h��
                        //1:BL�R�[�h���Ӑ��
                        //2:BL�R�[�h�S���ҕ�

                        //�S�ЏW�v�Ή�
                        //���_�R�[�h
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            selectTxt += "  TTL.ADDUPSECCODERF "
                                       + ", SEC.SECTIONGUIDESNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            //�S��
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }


                        //BL�R�[�h
                        selectTxt += ", TTL.BLGOODSCODERF "
                                   + ", BL.BLGOODSHALFNAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN BLGOODSCDURF AS BL ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        joinString += "LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        // 2011/08/01 <<<

                        //���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        if (extrInfo_PrevYearComparisonWork.printType == 2)
                        {
                            //�S���҃R�[�h
                            selectTxt += ", TTL.EMPLOYEECODERF "
                                       + ", EMP.NAMERF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                            joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", '0' EMPLOYEECODERF "
                                       + ", '' NAMERF ";

                        }

                        //�s�v����
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";
                        break;
                    }
            }

            selectTxt += ",TTL.ADDUPYEARMONTHRF % 100 AS ADDUPYEARMONTHRF" + Environment.NewLine;  //���ŃO���[�v�����邽��

            if (mode == 0)
            {
                //����
                selectTxt += ", TTL.SALESMONEYRF + TTL.SALESRETGOODSPRICERF + TTL.DISCOUNTPRICERF AS THISTERMSALESRF " + Environment.NewLine;
                selectTxt += ", TTL.GROSSPROFITRF AS THISTERMGROSSRF " + Environment.NewLine;
                selectTxt += ", 0 AS FIRSTTERMSALESRF " + Environment.NewLine;
                selectTxt += ", 0 AS FIRSTTERMGROSSRF " + Environment.NewLine;
            }
            else
            {
                //�O��
                selectTxt += ", 0 AS THISTERMSALESRF " + Environment.NewLine;
                selectTxt += ", 0 AS THISTERMGROSSRF " + Environment.NewLine;
                selectTxt += ", TTL.SALESMONEYRF + TTL.SALESRETGOODSPRICERF + TTL.DISCOUNTPRICERF AS FIRSTTERMSALESRF " + Environment.NewLine;
                selectTxt += ", TTL.GROSSPROFITRF AS FIRSTTERMGROSSRF " + Environment.NewLine;
            }

            //���[�^�C�v�ɂ��g�p����e�[�u�����قȂ�܂�
            //ListType 0:���Ӑ��,1:�S���ҕ�,2:�󒍎ҕ�,3:�n���,4:�Ǝ��,5:�O���[�v�R�[�h��,6:BL�R�[�h��
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                case 5:
                case 6:
                    {
                        //���i�ʔ��㌎���W�v�f�[�^
                        // 2011/08/01 >>>
                        //selectTxt += "FROM GOODSMTTLSASLIPRF TTL " + Environment.NewLine;
                        selectTxt += "FROM GOODSMTTLSASLIPRF TTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                        // 2011/08/01 <<<
                        break;
                    }
                default:
                    {
                        //���㌎���W�v�f�[�^
                        // 2011/08/01 >>>
                        //selectTxt += "FROM MTTLSALESSLIPRF TTL " + Environment.NewLine;
                        selectTxt += "FROM MTTLSALESSLIPRF TTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                        // 2011/08/01 <<<
                        break;
                    }
            }


            return selectTxt;

        }

        /// <summary>
        /// WHERE���쐬
        /// </summary>
        /// <param name="extrInfo_PrevYearComparisonWork">���o����</param>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="mode">0:�����A1:�O��</param>
        /// <returns>SELECT��</returns>
        /// <br>Note       : SELECT�����쐬���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.05</br>		
        private string MakeWhereString(ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref SqlCommand sqlCommand, int mode)
        {

            string retString = string.Empty;

            //��ƃR�[�h
            retString += " WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE" + mode.ToString() + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE" + mode.ToString(), SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.EnterpriseCode);

            //�Ώ۔N��(�O�N���͈͂��ΏۂƂ���)
            if (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth > 0 && extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth > 0)
            {
                retString += "AND (TTL.ADDUPYEARMONTHRF>=@ST_THISYEARMONTH" + mode.ToString() + " AND TTL.ADDUPYEARMONTHRF<=@ED_THISYEARMONTH" + mode.ToString() + ")" + Environment.NewLine;
                SqlParameter paraSt_ThisYearMonth = sqlCommand.Parameters.Add("@ST_THISYEARMONTH" + mode.ToString(), SqlDbType.Int);
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_THISYEARMONTH" + mode.ToString(), SqlDbType.Int);

                if (mode == 0)
                {
                    //����
                    paraSt_ThisYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_AddUpYearMonth);
                    paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth);
                }
                else
                {
                    //�O��
                    paraSt_ThisYearMonth.Value = SqlDataMediator.SqlSetInt32(GetAddYearMonth(extrInfo_PrevYearComparisonWork.St_AddUpYearMonth,-12));
                    paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(GetAddYearMonth(extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth,-12));
                }
            }

            //���яW�v�敪�u0:���v�v
            retString += " AND TTL.RSLTTTLDIVCDRF=0 ";

            string secCodeDD = string.Empty;

            //�e���[�p�^�[�����Ƃ̒��o�����ݒ�ƏW�v����
            //ListType 0:���Ӑ��,1:�S���ҕ�,2:�󒍎ҕ�,3:�n���,4:�Ǝ��,5:�O���[�v�R�[�h��,6:BL�R�[�h��
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                //���Ӑ��
                case 0:
                    {
                        //�]�ƈ��敪�u10:�̔��]�ƈ��v
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        //�Ǘ����_
                        if ((extrInfo_PrevYearComparisonWork.printType == 3) ||
                            (extrInfo_PrevYearComparisonWork.printType == 4))
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD +" IN (" + sectionString + ") ";
                            }
                            retString += Environment.NewLine;
                        }


                        string cusCodeDD = string.Empty;
                        if (extrInfo_PrevYearComparisonWork.printType == 4)
                        {
                            //������
                            cusCodeDD = "CUS.CLAIMCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            cusCodeDD = "TTL.CUSTOMERCODERF" + Environment.NewLine;
                        }


                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND " + cusCodeDD + ">=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND " + cusCodeDD + "<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //�S���ҕ�
                case 1:
                    {

                        //�]�ƈ��敪�u10:�̔��]�ƈ��v
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }
                        }

                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //�J�n�S���҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //�I���S���҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        break;
                    }
                //�󒍎ҕ�
                case 2:
                    {
                        //�]�ƈ��敪�u20:��t�]�ƈ��v
                        retString += " AND TTL.EMPLOYEEDIVCDRF=20 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //�J�n�󒍎҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //�I���󒍎҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        break;
                    }
                //�n���
                case 3:
                    {
                        //�]�ƈ��敪�u10:�̔��]�ƈ��v
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }


                        //�J�n�n��R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_SalesAreaCode != 0)
                        {
                            retString += "AND CUS.SALESAREACODERF>=@ST_SALESAREACODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_SalesAreaCode);
                        }
                        //�I���n��R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_SalesAreaCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_SalesAreaCode != 0)
                            {
                                retString += "AND CUS.SALESAREACODERF<=@ED_SALESAREACODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                //�J�n�R�[�h���O�̏ꍇ��NULL�l���ΏۂƂ���
                                retString += "AND (CUS.SALESAREACODERF<=@ED_SALESAREACODE" + mode.ToString() + " OR CUS.SALESAREACODERF IS NULL)" + Environment.NewLine;
                            }
                        
                            SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_SalesAreaCode);
                        }

                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //�Ǝ��
                case 4:
                    {

                        //�]�ƈ��敪�u10:�̔��]�ƈ��v
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF " + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF " + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //�J�n�Ǝ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_BusinessTypeCode != 0)
                        {
                            retString += "AND CUS.BUSINESSTYPECODERF>=@ST_BUSINESSTYPECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BusinessTypeCode = sqlCommand.Parameters.Add("@ST_BUSINESSTYPECODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BusinessTypeCode);
                        }
                        //�I���Ǝ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_BusinessTypeCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_BusinessTypeCode != 0)
                            {
                                retString += "AND CUS.BUSINESSTYPECODERF<=@ED_BUSINESSTYPECODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                //�J�n�R�[�h���O�̏ꍇ�͂m�t�k�k�l���Ώ�
                                retString += "AND (CUS.BUSINESSTYPECODERF<=@ED_BUSINESSTYPECODE" + mode.ToString() + " OR CUS.BUSINESSTYPECODERF IS NULL)" + Environment.NewLine;
                            }
                        
                            SqlParameter paraEd_BusinessTypeCode = sqlCommand.Parameters.Add("@ED_BUSINESSTYPECODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BusinessTypeCode);
                        }

                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //�O���[�v�R�[�h��
                case 5:
                    {
                        secCodeDD = "TTL.ADDUPSECCODERF";

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //�J�n���i�啪��
                        if (extrInfo_PrevYearComparisonWork.St_GoodsLGroup != 0)
                        {
                            retString += "AND GRP.GOODSLGROUPRF>=@ST_GOODSLGROUP" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_GoodsLGroup = sqlCommand.Parameters.Add("@ST_GOODSLGROUP" + mode.ToString(), SqlDbType.Int);
                            paraSt_GoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_GoodsLGroup);
                        }
                        //�I�����i�啪��
                        if (extrInfo_PrevYearComparisonWork.Ed_GoodsLGroup != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_GoodsLGroup != 0)
                            {
                                retString += "AND GRP.GOODSLGROUPRF<=@ED_GOODSLGROUP" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (GRP.GOODSLGROUPRF<=@ED_GOODSLGROUP" + mode.ToString() + " OR GRP.GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_GoodsLGroup = sqlCommand.Parameters.Add("@ED_GOODSLGROUP" + mode.ToString(), SqlDbType.Int);
                            paraEd_GoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_GoodsLGroup);
                        }

                        //�J�n���i������
                        if (extrInfo_PrevYearComparisonWork.St_GoodsMGroup != 0)
                        {
                            retString += "AND GRP.GOODSMGROUPRF>=@ST_GOODSMGROUP" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_GoodsMGroup = sqlCommand.Parameters.Add("@ST_GOODSMGROUP" + mode.ToString(), SqlDbType.Int);
                            paraSt_GoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_GoodsMGroup);
                        }
                        //�I�����i������
                        if (extrInfo_PrevYearComparisonWork.Ed_GoodsMGroup != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_GoodsMGroup != 0)
                            {
                                retString += "AND GRP.GOODSMGROUPRF<=@ED_GOODSMGROUP" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (GRP.GOODSMGROUPRF<=@ED_GOODSMGROUP" + mode.ToString() + " OR GRP.GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_GoodsMGroup = sqlCommand.Parameters.Add("@ED_GOODSMGROUP" + mode.ToString(), SqlDbType.Int);
                            paraEd_GoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_GoodsMGroup);
                        }

                        //�J�n�O���[�v�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_BLGroupCode != 0)
                        {
                            retString += "AND BL.BLGROUPCODERF>=@ST_BLGROUPCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BLGroupCode = sqlCommand.Parameters.Add("@ST_BLGROUPCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BLGroupCode);
                        }
                        //�I���O���[�v�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_BLGroupCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_BLGroupCode != 0)
                            {
                                retString += "AND BL.BLGROUPCODERF<=@ED_BLGROUPCODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (BL.BLGROUPCODERF<=@ED_BLGROUPCODE" + mode.ToString() + " OR BL.BLGROUPCODERF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_BLGroupCode = sqlCommand.Parameters.Add("@ED_BLGROUPCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BLGroupCode);
                        }

                        break;
                    }
                //BL�R�[�h��
                case 6:
                    {
                        secCodeDD = "TTL.ADDUPSECCODERF";

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //�J�n���Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //�I�����Ӑ�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //�J�n�S���҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //�I���S���҃R�[�h
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        //�J�nBL�R�[�h
                        if (extrInfo_PrevYearComparisonWork.St_BLGoodsCode != 0)
                        {
                            retString += "AND TTL.BLGOODSCODERF>=@ST_BLGOODSCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BLGoodsCode = sqlCommand.Parameters.Add("@ST_BLGOODSCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BLGoodsCode);
                        }
                        //�I��BL�R�[�h
                        if (extrInfo_PrevYearComparisonWork.Ed_BLGoodsCode != 0)
                        {
                            retString += "AND TTL.BLGOODSCODERF<=@ED_BLGOODSCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_BLGoodsCode = sqlCommand.Parameters.Add("@ED_BLGOODSCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BLGoodsCode);
                        }

                        break;
                    }

            }

            return retString;
        }

    }
}

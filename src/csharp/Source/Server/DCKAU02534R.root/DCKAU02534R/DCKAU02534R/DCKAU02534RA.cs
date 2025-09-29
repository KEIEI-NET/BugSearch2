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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����\��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����\��\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.28  �R�c ���F</br>
    /// <br>             �S���_�I�����ɑS���_�W�v���Ă���̂��C��</br>
    /// <br>             �����w��Ɖ���\����w�肪99�̏ꍇ�͑S�ΏۂɏC��(�ȑO��28���ȍ~������)</br>
    /// <br>             ���������w��E����\��������w���ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.08.08 20081</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note: 2009.04.30 22008 ����</br>
    /// <br>             �_���폜�f�[�^�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.18 23012 ����</br>
    /// <br>             ���o���ʃN���X�֍��ڒǉ�</br>
    /// <br>Update Note: 2010/08/27 �k���r </br>
    /// �@�@�@�@�@�@�@�@ #13691 ����\��\�̎d�l�ύX�Ή�</br>
    /// <br>Update Note: 2012/03/30 ���|�� </br>
    /// <br>�Ǘ��ԍ��@ : 10801804-00 5/24�z�M�� </br>
    /// <br>  �@�@�@�@�@ redmine#29152 ����\��\ ���Ӑ�̐������_��ύX�����ꍇ�̓���ɂ���</br>
    /// <br>Update Note: 2012/04/09 ���|�� </br>
    /// <br>�Ǘ��ԍ��@ : 10801804-00 5/24�z�M�� </br>
    /// <br>  �@�@�@�@�@ redmine#29295 ����\��敪�̐ݒ肪�L���ɂȂ�Ȃ�</br>
    /// </remarks>
    [Serializable]
    public class CollectProgramDB : RemoteDB, ICollectProgramDB
    {
        /// <summary>
        /// ����\��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public CollectProgramDB()
            :
            base("DCKAU02536D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_CollectPlanWork", "CUSTDMDPRCRF")
        {
        }

        #region [SearchCollectProgram]
        /// <summary>
        /// �w�肳�ꂽ�����̉���\��\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̉���\��\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
        public int SearchCollectProgram(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork = null;

            ArrayList extrInfo_CollectPlanWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_CollectPlanWorkList == null)
            {
                extrInfo_CollectPlanWork = paraObj as ExtrInfo_CollectPlanWork;
            }
            else
            {
                if (extrInfo_CollectPlanWorkList.Count > 0)
                    extrInfo_CollectPlanWork = extrInfo_CollectPlanWorkList[0] as ExtrInfo_CollectPlanWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF", "CUSTDMDPRCRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�����Ӑ搿�����z�}�X�^�擾
                status = SearchCollectProgramProc(ref retList, extrInfo_CollectPlanWork, ref sqlConnection);
                // ADD 2008.12.01 >>>
                //������������z�W�v
                status = SearchDepsitMainProc(ref retList, extrInfo_CollectPlanWork, ref sqlConnection);

                // ADD 2008.12.01 <<<

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CollectProgramDB.SearchCollectProgram");
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

        // ADD 2008.12.01 >>>
        #region SearchDepsitMainProc
        /// <summary>
        /// �w�肳�ꂽ�����̒�������z��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_CollectPlanWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒�������z��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.12.01</br>
        private int SearchDepsitMainProc(ref ArrayList retList, ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                for (int i = 0; i < retList.Count; i++)
                {
                    string sqlText = string.Empty;
                    DateTime collectmoneyDate = DateTime.MinValue;
                    sqlCommand.Parameters.Clear();

                    RsltInfo_CollectPlanWork rsltInfo_CollectPlanWork = new RsltInfo_CollectPlanWork();
                    rsltInfo_CollectPlanWork = retList[i] as RsltInfo_CollectPlanWork;
                    collectmoneyDate = rsltInfo_CollectPlanWork.AddUpDate;

                    switch (rsltInfo_CollectPlanWork.CollectMoneyCode) // 0:����,1:����,2:���X��,3���X�X��
                    {
                        case 1:
                            collectmoneyDate = collectmoneyDate.AddMonths(1);
                            break;
                        case 2:
                            collectmoneyDate = collectmoneyDate.AddMonths(2);
                            break;
                        case 3:
                            collectmoneyDate = collectmoneyDate.AddMonths(3);
                            break;
                    }
                    // 28���ȍ~�͖����Ƃ���
                    if (rsltInfo_CollectPlanWork.CollectMoneyDay >= 28)
                    {
                        collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                        collectmoneyDate = collectmoneyDate.AddMonths(1);
                        collectmoneyDate = collectmoneyDate.AddDays(-1);
                    }
                    else
                    {
                        collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, rsltInfo_CollectPlanWork.CollectMoneyDay);
                    }

                    // ������� ���o���t�̔���(�J�n�I��)
                    //if (rsltInfo_CollectPlanWork.AddUpDate >= collectmoneyDate)
                    //{
                        //continue;
                    //}

                    #region [SQL��]
                    sqlText += " SELECT SUM(DEPOSITTOTALRF) AS DEPOSITTOTALRF" + Environment.NewLine;
                    sqlText += " FROM DEPSITMAINRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                    sqlText += "  AND DEPOSITDATERF>@ADDUPDATE" + Environment.NewLine;
                    //sqlText += "  AND DEPOSITDATERF<=@DEPOSITDATE" + Environment.NewLine;
                    sqlText += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                    sqlCommand.CommandText = sqlText;
                    #endregion
                    
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    //SqlParameter paraDepoSitDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.EnterpriseCode);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rsltInfo_CollectPlanWork.AddUpDate);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(rsltInfo_CollectPlanWork.ClaimCode);
                    //paraDepoSitDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(collectmoneyDate);

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        ((RsltInfo_CollectPlanWork)retList[i]).AfterCloseDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (!myReader.IsClosed) myReader.Close();
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
        // ADD 2008.12.01 <<<

        /// <summary>
        /// �w�肳�ꂽ�����̉���\��\��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_CollectPlanWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̉���\��\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
        private int SearchCollectProgramProc(ref ArrayList retList, ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;       

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL��]
                //A:���Ӑ搿�����zϽ� B:���_���ݒ�Ͻ� C:���Ӑ�Ͻ� D:��������擾�p����Ͻ� E:�����S�̃}�X�^ F,G,H:�]�ƈ��}�X�^ I:���[�U�[�K�C�h 
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     A.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,B.SECTIONGUIDENMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,A.CLAIMNAMERF" + Environment.NewLine;
                sqlText += "    ,A.CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,A.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "    ,A.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "    ,A.LASTTIMEDEMANDRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISTIMESALESRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRICRGDSRF" + Environment.NewLine;
                sqlText += "    ,A.THISSALESPRICDISRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISSALESTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMEDMDNRMLRF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTCONDRF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += "    ,C.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += "    ,C.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += "    ,C.TOTALDAYRF" + Environment.NewLine; // ADD 2009/05/18 
                sqlText += "    ,F.NAMERF BILLCOLLECTERNMRF" + Environment.NewLine;
                sqlText += "    ,C.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += "    ,G.NAMERF CUSTOMERAGENTNMRF" + Environment.NewLine;
                sqlText += "    ,C.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += "    ,H.NAMERF OLDCUSTOMERAGENTNMRF" + Environment.NewLine;
                sqlText += "    ,C.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += "    ,C.SALESAREACODERF" + Environment.NewLine;
                sqlText += "    ,I.GUIDENAMERF SALESAREANAMERF" + Environment.NewLine;
                //sqlText += "    ,E.COLLECTPLNDIVRF" + Environment.NewLine; //DEL 2012/04/09 xupz for redmine#29295
                // ----- ADD 2012/04/09 xupz for redmine#29295---------->>>>>
                sqlText += "    ,(SELECT TOP 1 BAS.COLLECTPLNDIVRF FROM BILLALLSTRF BAS " + Environment.NewLine;
                sqlText += "    WHERE  BAS.LOGICALDELETECODERF=0  " + Environment.NewLine;
                sqlText += "    AND A.ENTERPRISECODERF=BAS.ENTERPRISECODERF  " + Environment.NewLine;
                sqlText += "    AND ((BAS.SECTIONCODERF = A.ADDUPSECCODERF)  " + Environment.NewLine;
                sqlText += "    OR (BAS.SECTIONCODERF='00')) " + Environment.NewLine;
                sqlText += "    ORDER BY BAS.SECTIONCODERF DESC)" + Environment.NewLine;
                sqlText += "    AS COLLECTPLNDIVRF" + Environment.NewLine;
                // ----- ADD 2012/04/09 xupz for redmine#29295----------<<<<<
                // DEL 2008.12.01 >>>
                //sqlText += "    ," + Environment.NewLine;
                //sqlText += "    (" + Environment.NewLine;
                //sqlText += "        SELECT SUM" + Environment.NewLine;
                //sqlText += "            (DEPOSITTOTALRF" + Environment.NewLine;
                //sqlText += "            )" + Environment.NewLine;
                //sqlText += "        FROM DEPSITMAINRF D" + Environment.NewLine;
                //sqlText += "        WHERE A.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                //sqlText += "            AND A.CLAIMCODERF=D.CLAIMCODERF" + Environment.NewLine;
                //sqlText += "            AND D.DEPOSITDATERF>A.ADDUPDATERF" + Environment.NewLine;
                //sqlText += "            AND D.DEPOSITDATERF<=A.EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                //sqlText += "        GROUP BY D.CLAIMCODERF" + Environment.NewLine;
                //sqlText += "    ) AS AFTERCLOSEDEMANDRF" + Environment.NewLine;
                // DEL 2008.12.01 <<<
                sqlText += " FROM CUSTDMDPRCRF A" + Environment.NewLine; // ���Ӑ搿�����z�}�X�^
                //�ŐV�̒��߃��R�[�h�𒊏o
                sqlText += " INNER JOIN " + Environment.NewLine;
                sqlText += " (" + Environment.NewLine;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "     MAX(CSD.ADDUPDATERF) AS ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,CSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CSD.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,CSD.CLAIMCODERF" + Environment.NewLine;
                sqlText += " FROM CUSTDMDPRCRF AS CSD" + Environment.NewLine;
                sqlText += " GROUP BY" + Environment.NewLine;
                sqlText += "     CSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CSD.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,CSD.CLAIMCODERF" + Environment.NewLine;
                sqlText += " )  AS NEWDMD ON" + Environment.NewLine;
                sqlText += "     A.ENTERPRISECODERF = NEWDMD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF = NEWDMD.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " AND A.CLAIMCODERF = NEWDMD.CLAIMCODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPDATERF = NEWDMD.ADDUPDATERF" + Environment.NewLine;
                // ���_���ݒ�}�X�^
                sqlText += " LEFT JOIN SECINFOSETRF B ON A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF=B.SECTIONCODERF" + Environment.NewLine;
                // ���Ӑ�}�X�^
                //sqlText += " LEFT JOIN CUSTOMERRF C ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " INNER JOIN CUSTOMERRF C ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.CLAIMCODERF=C.CUSTOMERCODERF" + Environment.NewLine;
                // �����S�̐ݒ�}�X�^
                // ----- DEL 2012/04/09 xupz for redmine#29295---------->>>>>
                //sqlText += " LEFT JOIN BILLALLSTRF E ON A.ENTERPRISECODERF=E.ENTERPRISECODERF" + Environment.NewLine;
                //sqlText += " AND A.ADDUPSECCODERF=E.SECTIONCODERF" + Environment.NewLine;
                // ----- DEL 2012/04/09 xupz for redmine#29295----------<<<<<
                // �]�ƈ��}�X�^
                sqlText += " LEFT JOIN EMPLOYEERF F ON C.ENTERPRISECODERF=F.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND C.BILLCOLLECTERCDRF=F.EMPLOYEECODERF" + Environment.NewLine;
                // �]�ƈ��}�X�^
                sqlText += " LEFT JOIN EMPLOYEERF G ON C.ENTERPRISECODERF=G.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND C.CUSTOMERAGENTCDRF=G.EMPLOYEECODERF" + Environment.NewLine;
                // �]�ƈ��}�X�^
                sqlText += " LEFT JOIN EMPLOYEERF H ON C.ENTERPRISECODERF=H.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND C.OLDCUSTOMERAGENTCDRF=H.EMPLOYEECODERF" + Environment.NewLine;
                // ���[�U�[�K�C�h�}�X�^
                sqlText += " LEFT JOIN USERGDBDURF I ON C.ENTERPRISECODERF=I.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND I.USERGUIDEDIVCDRF=21" + Environment.NewLine;
                sqlText += " AND I.GUIDECODERF=C.SALESAREACODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Where��쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_CollectPlanWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_CollectPlanFromReader(ref myReader));

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
        /// <param name="extrInfo_CollectPlanWork">���������i�[�N���X</param>
        /// <returns>����\��\���o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br>Update Note: 2010/08/27 �k���r #13691 ����\��\�̎d�l�ύX�Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND A.LOGICALDELETECODERF=0 ");

            //�e���R�[�h�݂̂�ΏۂƂ���(���Ӑ�R�[�h=0�̂ݑΏ�)
            retString.Append("AND A.CUSTOMERCODERF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_CollectPlanWork.CollectAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_CollectPlanWork.CollectAddupSecCodeList)
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
            }

            // ----- ADD 2012/03/30 xupz for redmine#29152---------->>>>>
            retString.Append("AND A.ADDUPSECCODERF=C.CLAIMSECTIONCODERF ");
            // ----- ADD 2012/03/30 xupz for redmine#29152----------<<<<<
            ////������
            //if (extrInfo_CollectPlanWork.AddUpDate > DateTime.MinValue)
            //{
            //    retString.Append("AND A.ADDUPDATERF<=@ADDUPDATE ");
            //    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
            //    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_CollectPlanWork.AddUpDate);
            //}
            //else
            //{
            //    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
            //    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.MinValue);
            //}
            
            //����
            // �� 2007.12.28 980081 c
            //if (extrInfo_CollectPlanWork.TotalDay == 99)
            //{
            //    //28�`31���w��
            //    retString.Append("AND C.TOTALDAYRF>=28 ");
            //}
            //else if (extrInfo_CollectPlanWork.TotalDay != 0)
            //{
            //    //�����w�肠��
            //    retString.Append("AND C.TOTALDAYRF=@TOTALDAY ");
            //    SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
            //    paraTotalDay.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.TotalDay);
            //}

            if (extrInfo_CollectPlanWork.IsLastDayTotalDay == true)
            {
                //28�`31���w��
                retString.Append("AND C.TOTALDAYRF>=28 ");
            }
            else if (extrInfo_CollectPlanWork.TotalDay != 0 && extrInfo_CollectPlanWork.TotalDay != 99)
            {
                //�����w�肠��
                retString.Append("AND C.TOTALDAYRF=@TOTALDAY ");
                SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                paraTotalDay.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.TotalDay);
            }
            // �� 2007.12.28 980081 c

            //������R�[�h
            if (extrInfo_CollectPlanWork.St_ClaimCode > 0)
            {
                retString.Append("AND A.CLAIMCODERF>=@ST_CLAIMCODE ");
                SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
                paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.St_ClaimCode);
            }
            if (extrInfo_CollectPlanWork.Ed_ClaimCode > 0)
            {
                retString.Append("AND A.CLAIMCODERF<=@ED_CLAIMCODE ");
                SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
                paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.Ed_ClaimCode);
            }

            // 2008.08.08 del start ------------------------------------------->>
            //if ((extrInfo_CollectPlanWork.St_ClaimKana != "") && (extrInfo_CollectPlanWork.St_ClaimKana == extrInfo_CollectPlanWork.Ed_ClaimKana))
            //{
            //    retString.Append("AND C.KANARF LIKE @ST_CLAIMKANA ");
            //    SqlParameter paraSt_ClaimKana = sqlCommand.Parameters.Add("@ST_CLAIMKANA", SqlDbType.NVarChar);
            //    paraSt_ClaimKana.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.St_ClaimKana + "%");
            //}
            //else
            //{
            //    //������J�i�i�J�n�j
            //    if (extrInfo_CollectPlanWork.St_ClaimKana != "")
            //    {
            //        retString.Append("AND C.KANARF>=@ST_CLAIMKANA ");
            //        SqlParameter paraSt_ClaimKana = sqlCommand.Parameters.Add("@ST_CLAIMKANA", SqlDbType.NVarChar);
            //        paraSt_ClaimKana.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.St_ClaimKana);
            //    }
            //    //������J�i�i�I���j�̂ݎw��(NULL�f�[�^���擾)
            //    if (extrInfo_CollectPlanWork.Ed_ClaimKana != "" && extrInfo_CollectPlanWork.St_ClaimKana == "")
            //    {
            //        retString.Append("AND ( C.KANARF<=@ED_CLAIMKANA OR C.KANARF LIKE @ED_CLAIMKANA OR C.KANARF IS NULL ) ");
            //        SqlParameter paraEd_ClaimKana = sqlCommand.Parameters.Add("@ED_CLAIMKANA", SqlDbType.NVarChar);
            //        paraEd_ClaimKana.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.Ed_ClaimKana);
            //    }
            //    else
            //    {
            //        //������J�i�i�I���j
            //        if (extrInfo_CollectPlanWork.Ed_ClaimKana != "")
            //        {
            //            retString.Append("AND ( C.KANARF<=@ED_CLAIMKANA OR C.KANARF LIKE @ED_CLAIMKANA ) ");
            //            SqlParameter paraEd_ClaimKana = sqlCommand.Parameters.Add("@ED_CLAIMKANA", SqlDbType.NVarChar);
            //            paraEd_ClaimKana.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.Ed_ClaimKana + "%");
            //        }
            //    }
            //}
            // 2008.08.08 del end ---------------------------------------------<<

            if (extrInfo_CollectPlanWork.EmployeeKindDiv == 0)
            {
                //�ڋq�S��(���Ӑ�}�X�^ CustomerAgentCdRF,OldCustomerAgentCdRF(CustAgentChgDateRF))
                if (extrInfo_CollectPlanWork.St_EmployeeCode != "")
                {
                    retString.Append("AND ((C.CUSTAGENTCHGDATERF IS NULL AND C.CUSTOMERAGENTCDRF>=@ST_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF<=@ADDUPDATE AND C.CUSTOMERAGENTCDRF>=@ST_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF>@ADDUPDATE AND C.OLDCUSTOMERAGENTCDRF>=@ST_EMPLOYEECODE)) ");
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.St_EmployeeCode);

                }
                if (extrInfo_CollectPlanWork.Ed_EmployeeCode != "")
                {
                    if (extrInfo_CollectPlanWork.St_EmployeeCode != "")
                    {
                        retString.Append("AND ((C.CUSTAGENTCHGDATERF IS NULL AND C.CUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF<=@ADDUPDATE AND C.CUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF>@ADDUPDATE AND C.OLDCUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE)) ");
                    }
                    else
                    {
                        retString.Append("AND ((C.CUSTOMERAGENTCDRF IS NULL) OR (C.CUSTAGENTCHGDATERF IS NULL AND C.CUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF<=@ADDUPDATE AND C.CUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE) OR (C.CUSTAGENTCHGDATERF>@ADDUPDATE AND C.OLDCUSTOMERAGENTCDRF<=@ED_EMPLOYEECODE)) ");
                    }
                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.Ed_EmployeeCode);

                }

                if ((extrInfo_CollectPlanWork.St_EmployeeCode != "") || (extrInfo_CollectPlanWork.Ed_EmployeeCode != ""))
                {
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_CollectPlanWork.AddUpDate);
                }

            }
            else if (extrInfo_CollectPlanWork.EmployeeKindDiv == 1)
            {
                //����S��(���Ӑ�}�X�^ BillCollecterCdRF)
                if (extrInfo_CollectPlanWork.St_EmployeeCode != "")
                {
                    retString.Append("AND C.BILLCOLLECTERCDRF>=@ST_EMPLOYEECODE ");
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.St_EmployeeCode);
                }
                if (extrInfo_CollectPlanWork.Ed_EmployeeCode != "")
                {
                    if (extrInfo_CollectPlanWork.St_EmployeeCode != "")
                    {
                        retString.Append("AND C.BILLCOLLECTERCDRF<=@ED_EMPLOYEECODE ");
                    }
                    else
                    {
                        retString.Append("AND ((C.BILLCOLLECTERCDRF IS NULL) OR (C.BILLCOLLECTERCDRF<=@ED_EMPLOYEECODE)) ");
                    }

                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_CollectPlanWork.Ed_EmployeeCode);
                }
            }

            //�G���A�R�[�h
            if (extrInfo_CollectPlanWork.St_SalesAreaCode != 0)
            {
                retString.Append("AND C.SALESAREACODERF>=@ST_SALESAREACODE ");
                SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.St_SalesAreaCode);
            }
            if (extrInfo_CollectPlanWork.Ed_SalesAreaCode != 0)
            {
                retString.Append("AND C.SALESAREACODERF<=@ED_SALESAREACODE ");
                SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.Ed_SalesAreaCode);
            }

            //�������
            if (extrInfo_CollectPlanWork.CollectCond != null)
            {
                string sectionString = "";
                foreach (Int32 collectCond in extrInfo_CollectPlanWork.CollectCond)
                {
                    if (collectCond != -1)
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + Convert.ToString(collectCond) + "'";
                    }
                }
                if (sectionString != "")
                {
                    //-----UPD 2010/08/27---------->>>>>
                    //retString.Append("AND A.COLLECTCONDRF IN (" + sectionString + ") ");
                    retString.Append("AND C.COLLECTCONDRF IN (" + sectionString + ") ");
                    //-----UPD 2010/08/27----------<<<<<
                }
            }

            //�����
            // �� 2007.12.28 980081 c
            //if (extrInfo_CollectPlanWork.CollectSchedule == 99)
            //{
            //    //28�`31���w��
            //    retString.Append("AND C.COLLECTMONEYDAYRF>=28 ");
            //}
            //else if (extrInfo_CollectPlanWork.CollectSchedule != 0)
            //{
            //    //�����w�肠��
            //    retString.Append("AND C.COLLECTMONEYDAYRF=@COLLECTSCHEDULE ");
            //    SqlParameter paraCollectSchedule = sqlCommand.Parameters.Add("@COLLECTSCHEDULE", SqlDbType.Int);
            //    paraCollectSchedule.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.CollectSchedule);
            //}

            if (extrInfo_CollectPlanWork.IsLastDayCollectSchedule == true)
            {
                //28�`31���w��
                retString.Append("AND C.COLLECTMONEYDAYRF>=28 ");
            }
            else if (extrInfo_CollectPlanWork.CollectSchedule != 0 && extrInfo_CollectPlanWork.CollectSchedule != 99)
            {
                //�����w�肠��
                retString.Append("AND C.COLLECTMONEYDAYRF=@COLLECTSCHEDULE ");
                SqlParameter paraCollectSchedule = sqlCommand.Parameters.Add("@COLLECTSCHEDULE", SqlDbType.Int);
                paraCollectSchedule.Value = SqlDataMediator.SqlSetInt32(extrInfo_CollectPlanWork.CollectSchedule);
            }
            // �� 2007.12.28 980081 c

            //���z���S��\0�͒��o���Ȃ��@�������1�������݂��Ȃ�
            retString.Append("AND (A.LASTTIMEDEMANDRF != 0 OR A.THISTIMEFEEDMDNRMLRF != 0 OR A.THISTIMEDISDMDNRMLRF != 0 OR A.THISTIMEDMDNRMLRF != 0 OR A.THISTIMETTLBLCDMDRF != 0 OR A.OFSTHISTIMESALESRF != 0 OR A.OFSTHISSALESTAXRF != 0 OR A.ITDEDOFFSETOUTTAXRF != 0 OR A.ITDEDOFFSETINTAXRF != 0 OR A.ITDEDOFFSETTAXFREERF != 0 OR A.OFFSETOUTTAXRF != 0 OR A.OFFSETINTAXRF != 0 OR A.THISTIMESALESRF != 0 OR A.THISSALESTAXRF != 0 OR A.ITDEDSALESOUTTAXRF != 0 OR A.ITDEDSALESINTAXRF != 0 OR A.ITDEDSALESTAXFREERF != 0 OR A.SALESOUTTAXRF != 0 OR A.SALESINTAXRF != 0 OR A.THISSALESPRICRGDSRF != 0 OR A.THISSALESPRCTAXRGDSRF != 0 OR A.TTLITDEDRETOUTTAXRF != 0 OR A.TTLITDEDRETINTAXRF != 0 OR A.TTLITDEDRETTAXFREERF != 0 OR A.TTLRETOUTERTAXRF != 0 OR A.TTLRETINNERTAXRF != 0 OR A.THISSALESPRICDISRF != 0 OR A.THISSALESPRCTAXDISRF != 0 OR A.TTLITDEDDISOUTTAXRF != 0 OR A.TTLITDEDDISINTAXRF != 0 OR A.TTLITDEDDISTAXFREERF != 0 OR A.TTLDISOUTERTAXRF != 0 OR A.TTLDISINNERTAXRF != 0 OR A.TAXADJUSTRF != 0 OR A.BALANCEADJUSTRF != 0 OR A.AFCALDEMANDPRICERF != 0) ");

            //�o�͏� 1:���Ӑ�R�[�h�� 2:�S���҃R�[�h�� 3:�n��R�[�h�� 4:�S���ҕʉ������ 5:�n��R�[�h�ʉ������ 6:�W������ 7:�W�����ʉ��������
            switch (extrInfo_CollectPlanWork.SortOrderDiv)
            {
                case 1:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.CLAIMCODERF, A.EXPECTEDDEPOSITDATERF");
                        break;
                    }
                case 2:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, C.BILLCOLLECTERCDRF, A.CLAIMCODERF, A.EXPECTEDDEPOSITDATERF");
                        break;
                    }
                case 3:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, C.SALESAREACODERF, A.CLAIMCODERF, A.EXPECTEDDEPOSITDATERF");
                        break;
                    }
                case 4:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, C.BILLCOLLECTERCDRF, A.EXPECTEDDEPOSITDATERF, A.CLAIMCODERF");
                        break;
                    }
                case 5:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, C.SALESAREACODERF, A.EXPECTEDDEPOSITDATERF, A.CLAIMCODERF");
                        break;
                    }
                case 6:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.EXPECTEDDEPOSITDATERF, A.CLAIMCODERF");
                        break;
                    }
                case 7:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.EXPECTEDDEPOSITDATERF, A.COLLECTCONDRF, A.CLAIMCODERF");
                        break;
                    }
            }

            return retString.ToString();
        }
        #endregion

        #region [����\��\���o���ʃN���X�i�[����]
        /// <summary>
        /// ����\��\���o���ʃN���X�i�[���� Reader �� RsltInfo_CollectPlanWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_CollectPlanWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        private RsltInfo_CollectPlanWork CopyToRsltInfo_CollectPlanFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_CollectPlanWork wkRsltInfo_CollectPlanWork = new RsltInfo_CollectPlanWork();

            #region �N���X�֊i�[
            wkRsltInfo_CollectPlanWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_CollectPlanWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_CollectPlanWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_CollectPlanWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_CollectPlanWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_CollectPlanWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_CollectPlanWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_CollectPlanWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkRsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkRsltInfo_CollectPlanWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            wkRsltInfo_CollectPlanWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkRsltInfo_CollectPlanWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkRsltInfo_CollectPlanWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkRsltInfo_CollectPlanWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkRsltInfo_CollectPlanWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            //wkRsltInfo_CollectPlanWork.AfterCloseDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFTERCLOSEDEMANDRF")); // DEL 2008.12.01
            wkRsltInfo_CollectPlanWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            wkRsltInfo_CollectPlanWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            wkRsltInfo_CollectPlanWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            wkRsltInfo_CollectPlanWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkRsltInfo_CollectPlanWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
            wkRsltInfo_CollectPlanWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            wkRsltInfo_CollectPlanWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            wkRsltInfo_CollectPlanWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkRsltInfo_CollectPlanWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkRsltInfo_CollectPlanWork.CollectPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTPLNDIVRF"));
            wkRsltInfo_CollectPlanWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF")); // ADD 2009/05/18
            #endregion

            if (SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF")) >= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF")))
            {
                wkRsltInfo_CollectPlanWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                wkRsltInfo_CollectPlanWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
            }
            else
            {
                wkRsltInfo_CollectPlanWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                wkRsltInfo_CollectPlanWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNMRF"));
            }

            return wkRsltInfo_CollectPlanWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
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
    }
}

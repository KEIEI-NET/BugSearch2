//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͑��샍�O�o�^����DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �e�L�X�g�o�͑��샍�O�o�^�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00       �쐬�S�� : �c����
// �� �� ��  2019/08/12        �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00       �쐬�S�� : ��
// �� �� ��  2019/09/12        �C�����e : �e�L�X�g�o�̓��O���̔ԏ����p�~
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Data;
using Microsoft.Win32;
using System.IO;
using System.Net;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �e�L�X�g�o�͑��샍�O�o�^����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�������s��</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/12</br>
    /// <br>Note       : �e�L�X�g�o�̓��O���̔ԏ����p�~</br>
    /// <br>Programmer : ��</br>
    /// <br>Date       : 2019/09/12</br>
    /// </remarks>
    [Serializable]
    public class TextOutPutOprtnHisLogDB : RemoteDB, ITextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O�o�^����DB�����[�g�I�u�W�F�N�g�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^����DB�����[�g�I�u�W�F�N�g�N���X</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public TextOutPutOprtnHisLogDB()
        {

        }

        #region �e�L�X�g�o�͑��샍�O�o�^
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O��o�^����
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWorkObj">�o�^�p�Ώۃ��[�N</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public int Write(ref object textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                using (sqlConnection = this.CreateSqlConnection(true))
                {
                    // �g�����U�N�V��������
                    using (sqlTransaction = this.CreateTransaction(ref sqlConnection))
                    {
                        TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork = (TextOutPutOprtnHisLogWork)textOutPutOprtnHisLogWorkObj;
                        // �o�^�������s��
                        status = this.WriteTextOutPutOprtnHisLogProc(ref textOutPutOprtnHisLogWork, ref sqlConnection, ref sqlTransaction, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                            textOutPutOprtnHisLogWorkObj = (object)textOutPutOprtnHisLogWork;
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.Write");
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �e�L�X�g�o�͑��샍�O��o�^����
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWork">�o�^�p�Ώۃ��[�N</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// <br>Note       : �e�L�X�g�o�̓��O���̔ԏ����p�~</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2019/09/12</br>
        /// </remarks>
        private int WriteTextOutPutOprtnHisLogProc(ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            errMsg = string.Empty;

            try
            {
                if (textOutPutOprtnHisLogWork != null)
                {
                    string sqlText = string.Empty;
                    #region
                    sqlText += " SELECT " + Environment.NewLine;
                    sqlText += " UPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " FROM " + Environment.NewLine; ;
                    // --- MOD 2019/09/12 ---------->>>>>
                    // �e�L�X�g�o�̓��O���̔ԏ����p�~
                    //sqlText += " TEXTOUTHISLOGRF " + Environment.NewLine;
                    sqlText += " TEXTOUTHISLOGRF WITH(NOLOCK)" + Environment.NewLine;
                    // --- MOD 2019/09/12 ----------<<<<<
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += " AND TEXTOUTLOGNORF=@FINDTEXTOUTLOGNORF " + Environment.NewLine;
                    #endregion
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findTextOutLogNo = sqlCommand.Parameters.Add("@FINDTEXTOUTLOGNORF", SqlDbType.BigInt);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                    findTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);

                    myReader = sqlCommand.ExecuteReader();

                    // DB�Ƀf�[�^�����݂��邩
                    bool existFlag = myReader.Read();

                    if (existFlag)
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (updateDateTime != textOutPutOprtnHisLogWork.UpdateDateTime)
                        {
                            if (textOutPutOprtnHisLogWork.UpdateDateTime == DateTime.MinValue)
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

                        sqlText = string.Empty;
                        #region
                        sqlText += " UPDATE " + Environment.NewLine;
                        sqlText += " TEXTOUTHISLOGRF " + Environment.NewLine;
                        sqlText += " SET " + Environment.NewLine;
                        sqlText += " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME " + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID " + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE " + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , LOGDATACOUNTRF=@LOGDATACOUNTRF " + Environment.NewLine;
                        sqlText += " WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                        sqlText += " AND TEXTOUTLOGNORF=@FINDTEXTOUTLOGNORF " + Environment.NewLine;
                        #endregion
                        sqlCommand.CommandText = sqlText.ToString();

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                        findTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);

                        // �R���}�z��
                        string[] commaArray = null;
                        // �R�����z��
                        string[] colonArray = null;
                        // �o�͌���
                        string count = string.Empty;

                        // �R���}�ŕ�����
                        commaArray = textOutPutOprtnHisLogWork.LogOperationData.Split(',');
                        if (commaArray != null && commaArray.Length > 0)
                        {
                            // �R�����ŕ�����
                            colonArray = commaArray[0].Split(':');
                        }
                        // �o�͌����擾
                        if (colonArray != null && colonArray.Length > 0)
                        {
                            count = colonArray[1].ToString();
                        }

                        int result;
                        if (Int32.TryParse(count, out result)) textOutPutOprtnHisLogWork.LogDataCount = result;

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)textOutPutOprtnHisLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }

                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (textOutPutOprtnHisLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        // --- DEL 2019/09/12 ---------->>>>>
                        // �e�L�X�g�o�̓��O���̔ԏ����p�~
                        // �e�L�X�g�o�̓��ONo�̔ԏ���
                        //#region �̔�
                        //status = this.GetMaxTextOutLogNo(ref textOutPutOprtnHisLogWork, ref sqlConnection, ref sqlTransaction, out errMsg);

                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    return status;
                        //}
                        //#endregion
                        // --- DEL 2019/09/12 ----------<<<<<

                        //Insert�R�}���h�̐���
                        #region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO TEXTOUTHISLOGRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        // --- DEL 2019/09/12 ---------->>>>>
                        // �e�L�X�g�o�̓��O���̔ԏ����p�~
                        //sqlText += " ,TEXTOUTLOGNORF" + Environment.NewLine;
                        // --- DEL 2019/09/12 ----------<<<<<
                        sqlText += " ,LOGDATACREATEDATERF" + Environment.NewLine;
                        sqlText += " ,LOGDATACREATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                        sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                        sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                        sqlText += " ,LOGDATACOUNTRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        // --- DEL 2019/09/12 ---------->>>>>
                        // �e�L�X�g�o�̓��O���̔ԏ����p�~
                        //sqlText += " ,@TEXTOUTLOGNO" + Environment.NewLine;
                        // --- DEL 2019/09/12 ----------<<<<<
                        sqlText += " ,@LOGDATACREATEDATE" + Environment.NewLine;
                        sqlText += " ,@LOGDATACREATETIME" + Environment.NewLine;
                        sqlText += " ,@LOGINSECTIONCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAKINDCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAMACHINENAME" + Environment.NewLine;
                        sqlText += " ,@LOGDATAAGENTCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAAGENTNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJPROCNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOPERATIONCD" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATERFUNCLVL" + Environment.NewLine;
                        sqlText += " ,@LOGDATASYSTEMVERSION" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATIONSTATUS" + Environment.NewLine;
                        sqlText += " ,@LOGDATACOUNTRF" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATIONDATA" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        // --- ADD 2019/09/12 ---------->>>>>
                        // �e�L�X�g�o�̓��O���̔ԏ����p�~
                        // �Ō��IDENTITY�̎擾SELECT��ǉ�
                        sqlText += ";SELECT SCOPE_IDENTITY() as ID" + Environment.NewLine;
                        // --- ADD 2019/09/12 ----------<<<<<

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)textOutPutOprtnHisLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                   }

                   #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                   SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                   SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                   SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                   SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                   SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                   SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                   SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                   SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                   SqlParameter paraTextOutLogNo = sqlCommand.Parameters.Add("@TEXTOUTLOGNO", SqlDbType.BigInt);
                   SqlParameter paraLogDataCreateDate = sqlCommand.Parameters.Add("@LOGDATACREATEDATE", SqlDbType.Int);
                   SqlParameter paraLogDataCreateTime = sqlCommand.Parameters.Add("@LOGDATACREATETIME", SqlDbType.Int);
                   SqlParameter paraLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                   SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                   SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                   SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                   SqlParameter paraLogDataAgentNm = sqlCommand.Parameters.Add("@LOGDATAAGENTNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjBootProgramNm = sqlCommand.Parameters.Add("@LOGDATAOBJBOOTPROGRAMNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjAssemblyNm = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjProcNm = sqlCommand.Parameters.Add("@LOGDATAOBJPROCNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                   SqlParameter paraLogOperaterDtProcLvl = sqlCommand.Parameters.Add("@LOGOPERATERDTPROCLVL", SqlDbType.NVarChar);
                   SqlParameter paraLogOperaterFuncLvl = sqlCommand.Parameters.Add("@LOGOPERATERFUNCLVL", SqlDbType.NVarChar);
                   SqlParameter paraLogDataSystemVersion = sqlCommand.Parameters.Add("@LOGDATASYSTEMVERSION", SqlDbType.NVarChar);
                   SqlParameter paraLogOperationStatus = sqlCommand.Parameters.Add("@LOGOPERATIONSTATUS", SqlDbType.Int);
                   SqlParameter paraLogDataCount = sqlCommand.Parameters.Add("@LOGDATACOUNTRF", SqlDbType.Int);
                   SqlParameter paraLogOperationData = sqlCommand.Parameters.Add("@LOGOPERATIONDATA", SqlDbType.NVarChar);
                   #endregion

                   #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                   paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(textOutPutOprtnHisLogWork.CreateDateTime);
                   paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(textOutPutOprtnHisLogWork.UpdateDateTime);
                   paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                   paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(textOutPutOprtnHisLogWork.FileHeaderGuid);
                   paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdEmployeeCode);
                   paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdAssemblyId1);
                   paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdAssemblyId2);
                   paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogicalDeleteCode);
                   paraTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);
                   int logDataCreateDateInt = textOutPutOprtnHisLogWork.LogDataCreateDateTime.Year * 10000 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Month * 100 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Day;
                   int logDataCreateTimeInt = textOutPutOprtnHisLogWork.LogDataCreateDateTime.Hour * 10000 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Minute * 100 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Second;
                   paraLogDataCreateDate.Value = SqlDataMediator.SqlSetInt32(logDataCreateDateInt);
                   paraLogDataCreateTime.Value = SqlDataMediator.SqlSetInt32(logDataCreateTimeInt);
                   paraLoginSectionCd.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LoginSectionCd);
                   paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataKindCd);
                   paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataMachineName);
                   paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataAgentCd);
                   paraLogDataAgentNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataAgentNm);
                   paraLogDataObjBootProgramNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjBootProgramNm);
                   paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjAssemblyID);
                   paraLogDataObjAssemblyNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjAssemblyNm);
                   paraLogDataObjProcNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjProcNm);
                   paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataOperationCd);
                   paraLogOperaterDtProcLvl.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperaterDtProcLvl);
                   paraLogOperaterFuncLvl.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperaterFuncLvl);
                   paraLogDataSystemVersion.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataSystemVersion);
                   paraLogOperationStatus.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogOperationStatus);
                   paraLogDataCount.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataCount);
                   paraLogOperationData.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperationData);
                   #endregion

                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                    }

                    // --- MOD 2019/09/12 ---------->>>>>
                    // �e�L�X�g�o�̓��O���̔ԏ����p�~
                    // ID���擾�������ɐݒ�
                    //sqlCommand.ExecuteNonQuery();

                    if (existFlag)
                    {
                        // Update
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert

                        // ExecuteScalar�Ő擪�s�A�擪���ڂ��擾
                        object newId = sqlCommand.ExecuteScalar();

                        // �ԋp�l�����ONo�ɐݒ�
                        Int64 resId = 0;
                        Int64.TryParse(newId.ToString(), out resId);
                        textOutPutOprtnHisLogWork.TextOutLogNo = resId;

                    }
                    // --- MOD 2019/09/12 ----------<<<<<

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex);
                errMsg = sqlex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.WriteTextOutPutOprtnHisLogProc");
                errMsg = ex.Message;
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
        #endregion

        #region �e�L�X�g�o�̓��ONo�̔�
        /// <summary>
        /// �e�L�X�g�o�̓��ONo�̔�
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWork">�o�^�p�Ώۃ��[�N</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓��ONo�̔ԏ������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        private int GetMaxTextOutLogNo(ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            errMsg = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(TEXTOUTLOGNORF) TEXTOUTLOGNO_MAX FROM TEXTOUTHISLOGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE_MAX", sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE_MAX", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        textOutPutOprtnHisLogWork.TextOutLogNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TEXTOUTLOGNO_MAX")) + 1;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.GetMaxTextOutLogNo");
                errMsg = ex.Message;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        # region [�R�l�N�V�����E�g�����U�N�V������������]
        /// <summary>
        /// �R�l�N�V������������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽ�R�l�N�V�����A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : �R�l�N�V���������������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// �g�����U�N�V������������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽ�g�����U�N�V�����A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : �g�����U�N�V���������������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
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
        # endregion
    }
}

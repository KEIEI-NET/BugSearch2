//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ����A�g�ݒ�DB�����[�g�N���X                  //
//                  :   PMSCM09074R.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.23                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

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
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Net;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using System.Collections.Generic;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����A�g�ݒ�DB�����[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����A�g�ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.07.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PM7RkSettingDB : RemoteDB, IPM7RkSettingDB
    {
        #region << Consductor >>

        /// <summary>
        /// ����A�g�ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        public PM7RkSettingDB()
            : base("PMSCM09076D", "Broadleaf.Application.Remoting.ParamData.PM7RkSettingWork", "PM7RkSettingRF")
        {
        }

        #endregion

        #region << Read Methods >>

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���A�g�ݒ��߂��܂�
        /// </summary>
        /// <param name="pm7RkSettingWork">PM7RkSettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���A�g�ݒ��߂��܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        public int Read(ref ArrayList pm7RkSettingWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {

                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                PM7RkSettingWork wpm7RkSettingWork = new PM7RkSettingWork();
                wpm7RkSettingWork = (PM7RkSettingWork)pm7RkSettingWork[0];

                try
                {
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PM7RKSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                    {

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wpm7RkSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(wpm7RkSettingWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        if (myReader.Read())
                        {
                            wpm7RkSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            wpm7RkSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            wpm7RkSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            wpm7RkSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            wpm7RkSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            wpm7RkSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            wpm7RkSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            wpm7RkSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            wpm7RkSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                            wpm7RkSettingWork.SalesRkAutoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESRKAUTOCODERF"));
                            wpm7RkSettingWork.SalesRkAutoSndTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRKAUTOSNDTIMERF"));
                            wpm7RkSettingWork.MasterRkAutoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERRKAUTOCODERF"));
                            wpm7RkSettingWork.MasterRkAutoRcvTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MASTERRKAUTORCVTIMERF"));
                            wpm7RkSettingWork.TextSaveFolder = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TEXTSAVEFOLDERRF"));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }
                    sqlConnection.Close();
                }

                return status;
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        #endregion

        #region  << Write Methods >>

        /// <summary>
        /// ����A�g�ݒ���̓o�^�A�X�V
        /// </summary>
        /// <param name="parabyte">PM7RkSettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        public int Write(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;
                try
                {
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    PM7RkSettingWork pm7RkSettingWork = (PM7RkSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(PM7RkSettingWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESRKAUTOCODERF, SALESRKAUTOSNDTIMERF, MASTERRKAUTOCODERF, MASTERRKAUTORCVTIMERF, TEXTSAVEFOLDERRF FROM PM7RKSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                    {
                        //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != pm7RkSettingWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (pm7RkSettingWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE PM7RKSETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESRKAUTOCODERF=@SALESRKAUTOCODE , SALESRKAUTOSNDTIMERF=@SALESRKAUTOSNDTIME , MASTERRKAUTOCODERF=@MASTERRKAUTOCODE , MASTERRKAUTORCVTIMERF=@MASTERRKAUTORCVTIME , TEXTSAVEFOLDERRF=@TEXTSAVEFOLDER WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pm7RkSettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pm7RkSettingWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            //�V�K�쐬����InsertSQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO PM7RKSETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESRKAUTOCODERF, SALESRKAUTOSNDTIMERF, MASTERRKAUTOCODERF, MASTERRKAUTORCVTIMERF, TEXTSAVEFOLDERRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESRKAUTOCODE, @SALESRKAUTOSNDTIME, @MASTERRKAUTOCODE, @MASTERRKAUTORCVTIME, @TEXTSAVEFOLDER)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pm7RkSettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        //Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSalesRkAutoCode = sqlCommand.Parameters.Add("@SALESRKAUTOCODE", SqlDbType.Int);
                        SqlParameter paraSalesRkAutoSndTime = sqlCommand.Parameters.Add("@SALESRKAUTOSNDTIME", SqlDbType.BigInt);
                        SqlParameter paraMasterRkAutoCode = sqlCommand.Parameters.Add("@MASTERRKAUTOCODE", SqlDbType.Int);
                        SqlParameter paraMasterRkAutoRcvTime = sqlCommand.Parameters.Add("@MASTERRKAUTORCVTIME", SqlDbType.BigInt);
                        SqlParameter paraTextSaveFolder = sqlCommand.Parameters.Add("@TEXTSAVEFOLDER", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pm7RkSettingWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pm7RkSettingWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pm7RkSettingWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pm7RkSettingWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.SectionCode);
                        paraSalesRkAutoCode.Value = SqlDataMediator.SqlSetInt32(pm7RkSettingWork.SalesRkAutoCode);
                        paraSalesRkAutoSndTime.Value = SqlDataMediator.SqlSetInt64(pm7RkSettingWork.SalesRkAutoSndTime);
                        paraMasterRkAutoCode.Value = SqlDataMediator.SqlSetInt32(pm7RkSettingWork.MasterRkAutoCode);
                        paraMasterRkAutoRcvTime.Value = SqlDataMediator.SqlSetInt64(pm7RkSettingWork.MasterRkAutoRcvTime);
                        paraTextSaveFolder.Value = SqlDataMediator.SqlSetString(pm7RkSettingWork.TextSaveFolder);

                        sqlCommand.ExecuteNonQuery();

                        // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                        parabyte = XmlByteSerializer.Serialize(pm7RkSettingWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    base.WriteSQLErrorLog(ex);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PM7RkSettingDB.Write");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #endregion

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
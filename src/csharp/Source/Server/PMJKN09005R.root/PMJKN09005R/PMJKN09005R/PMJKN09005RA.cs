//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^
// �v���O�����T�v   : ���R�����^���}�X�^ �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����^���}�X�^ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^�̎��s�f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchModelDB : RemoteWithAppLockDB, IFreeSearchModelDB
    {
        # region �� Constructor ��
        /// <summary>
        /// ���R�����^���}�X�^ �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�̎��s�f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchModelDB()
            :
        base("PMJKN09006D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork", "FREESEARCHMODELWORK") //���N���X�̃R���X�g���N�^
        {
        }
        #endregion


        #region �� ���R�����^���}�X�^�������� ��
        /// <summary>
        /// ���R�����^���}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�����^���}�X�^�N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(object paraWork, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                status = SearchProc(out retList, paraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreeSearchModelDB.Search");
                retList = new ArrayList();
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

            return status;
        }

        /// <summary>
        /// ���R�����^���}�X�^�f�[�^��S�Ė߂��܂�
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����^���}�X�^�f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        private int SearchProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchModelWork freeSearchModelParaWork = paraWork as FreeSearchModelWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" CREATEDATETIMERF, ");//�쐬����
                sb.Append(" UPDATEDATETIMERF, ");//�X�V����
                sb.Append(" ENTERPRISECODERF, ");//��ƃR�[�h
                sb.Append(" FILEHEADERGUIDRF, ");//GUID
                sb.Append(" UPDEMPLOYEECODERF, ");//�X�V�]�ƈ��R�[�h
                sb.Append(" UPDASSEMBLYID1RF, ");//�X�V�A�Z���u��ID1
                sb.Append(" UPDASSEMBLYID2RF, ");//�X�V�A�Z���u��ID2
                sb.Append(" LOGICALDELETECODERF, ");//�_���폜�敪
                sb.Append(" FREESRCHMDLFXDNORF, ");//���R�����^���Œ�ԍ�
                sb.Append(" MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" EXHAUSTGASSIGNRF, ");//�r�K�X�L��
                sb.Append(" SERIESMODELRF, ");//�V���[�Y�^��
                sb.Append(" CATEGORYSIGNMODELRF, ");//�^���i�ޕʋL���j
                sb.Append(" FULLMODELRF, ");//�^���i�t���^�j
                sb.Append(" MODELDESIGNATIONNORF, ");//�^���w��ԍ�
                sb.Append(" CATEGORYNORF, ");//�ޕʔԍ�
                sb.Append(" STPRODUCETYPEOFYEARRF, ");//�J�n���Y�N��
                sb.Append(" EDPRODUCETYPEOFYEARRF, ");//�I�����Y�N��
                sb.Append(" STPRODUCEFRAMENORF, ");//���Y�ԑ�ԍ��J�n
                sb.Append(" EDPRODUCEFRAMENORF, ");//���Y�ԑ�ԍ��I��
                sb.Append(" MODELGRADENMRF, ");//�^���O���[�h����
                sb.Append(" BODYNAMERF, ");//�{�f�B�[����
                sb.Append(" DOORCOUNTRF, ");//�h�A��
                sb.Append(" ENGINEMODELNMRF, ");//�G���W���^������
                sb.Append(" ENGINEDISPLACENMRF, ");//�r�C�ʖ���
                sb.Append(" EDIVNMRF, ");//E�敪����
                sb.Append(" TRANSMISSIONNMRF, ");//�~�b�V��������
                sb.Append(" WHEELDRIVEMETHODNMRF, ");//�쓮��������
                sb.Append(" SHIFTNMRF, ");//�V�t�g����
                sb.Append(" CREATEDATERF, ");//�쐬���t
                sb.Append(" UPDATEDATERF ");//�X�V�N����
                sb.Append(" FROM FREESEARCHMODELRF ");
                sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");
                sb.Append("     AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNORF ");
                sqlCommand.CommandText = sb.ToString();

                // Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNORF", SqlDbType.NChar);
                
                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.EnterpriseCode);
                findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.FreeSrchMdlFxdNo);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    FreeSearchModelWork wkFreeSearchModelWork = new FreeSearchModelWork();

                    //���R�����^���}�X�^�f�[�^���ʎ擾���e�i�[
                    wkFreeSearchModelWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
                    wkFreeSearchModelWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    wkFreeSearchModelWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//��ƃR�[�h
                    wkFreeSearchModelWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchModelWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//�X�V�]�ƈ��R�[�h
                    wkFreeSearchModelWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//�X�V�A�Z���u��ID1
                    wkFreeSearchModelWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//�X�V�A�Z���u��ID2
                    wkFreeSearchModelWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//�_���폜�敪
                    wkFreeSearchModelWork.FreeSrchMdlFxdNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNORF"));//���R�����^���Œ�ԍ�
                    wkFreeSearchModelWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//���[�J�[�R�[�h
                    wkFreeSearchModelWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//�Ԏ�R�[�h
                    wkFreeSearchModelWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//�Ԏ�T�u�R�[�h
                    wkFreeSearchModelWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));//�r�K�X�L��
                    wkFreeSearchModelWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));//�V���[�Y�^��
                    wkFreeSearchModelWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));//�^���i�ޕʋL���j
                    wkFreeSearchModelWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//�^���i�t���^�j
                    wkFreeSearchModelWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));//�^���w��ԍ�
                    wkFreeSearchModelWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));//�ޕʔԍ�
                    wkFreeSearchModelWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));//�J�n���Y�N��
                    wkFreeSearchModelWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));//�I�����Y�N��
                    wkFreeSearchModelWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));//���Y�ԑ�ԍ��J�n
                    wkFreeSearchModelWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));//���Y�ԑ�ԍ��I��
                    wkFreeSearchModelWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//�^���O���[�h����
                    wkFreeSearchModelWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//�{�f�B�[����
                    wkFreeSearchModelWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//�h�A��
                    wkFreeSearchModelWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//�G���W���^������
                    wkFreeSearchModelWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//�r�C�ʖ���
                    wkFreeSearchModelWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E�敪����
                    wkFreeSearchModelWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//�~�b�V��������
                    wkFreeSearchModelWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//�쓮��������
                    wkFreeSearchModelWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//�V�t�g����
                    wkFreeSearchModelWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//�쐬���t
                    wkFreeSearchModelWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//�X�V�N����
                    #endregion

                     al.Add(wkFreeSearchModelWork);
                }
                if (al.Count < 1)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
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
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            retList = al;

            return status;
        }

        #endregion


        #region �� ���R�����^���}�X�^�o�^�X�V���� ��
        /// <summary>
        /// ���R�����^���}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraObj">���R�����^���}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : paraObj �Ɋi�[����Ă��鎩�R�����^���}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        public int Write(ref object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = paraObj as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // Write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// ���R�����^���}�X�^��o�^�E�X�V���܂��B
        /// </summary>
        /// <param name="freeSearchModelList">�o�^�E�X�V���鎩�R�����^���}�X�^���i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList �Ɋi�[����Ă��鎩�R�����^���}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        public int Write(ref ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref freeSearchModelList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���R�����^���}�X�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="freeSearchModelList">���R�����^���}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : freeSearchModelList �Ɋi�[����Ă��鎩�R�����^���}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        private int WriteProc(ref ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (freeSearchModelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < freeSearchModelList.Count; i++)
                    {
                        FreeSearchModelWork freeSearchModelWork = freeSearchModelList[i] as FreeSearchModelWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNO", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != freeSearchModelWork.UpdateDateTime)
                            {
                                if (freeSearchModelWork.UpdateDateTime == DateTime.MinValue)
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

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE FREESEARCHMODELRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , FREESRCHMDLFXDNORF=@FREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlText += " , MAKERCODERF=@MAKERCODE" + Environment.NewLine;
                            sqlText += " , MODELCODERF=@MODELCODE" + Environment.NewLine;
                            sqlText += " , MODELSUBCODERF=@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " , EXHAUSTGASSIGNRF=@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " , SERIESMODELRF=@SERIESMODEL" + Environment.NewLine;
                            sqlText += " , CATEGORYSIGNMODELRF=@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " , FULLMODELRF=@FULLMODEL" + Environment.NewLine;
                            sqlText += " , MODELDESIGNATIONNORF=@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " , CATEGORYNORF=@CATEGORYNO" + Environment.NewLine;
                            sqlText += " , STPRODUCETYPEOFYEARRF=@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " , EDPRODUCETYPEOFYEARRF=@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " , STPRODUCEFRAMENORF=@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " , EDPRODUCEFRAMENORF=@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " , MODELGRADENMRF=@MODELGRADENM" + Environment.NewLine;
                            sqlText += " , BODYNAMERF=@BODYNAME" + Environment.NewLine;
                            sqlText += " , DOORCOUNTRF=@DOORCOUNT" + Environment.NewLine;
                            sqlText += " , ENGINEMODELNMRF=@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " , ENGINEDISPLACENMRF=@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " , EDIVNMRF=@EDIVNM" + Environment.NewLine;
                            sqlText += " , TRANSMISSIONNMRF=@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " , WHEELDRIVEMETHODNMRF=@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " , SHIFTNMRF=@SHIFTNM" + Environment.NewLine;
                            sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                           

                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                            findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchModelWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (freeSearchModelWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO FREESEARCHMODELRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,FREESRCHMDLFXDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                            sqlText += "    ,MODELCODERF" + Environment.NewLine;
                            sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += "    ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += "    ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += "    ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += "    ,FULLMODELRF" + Environment.NewLine;
                            sqlText += "    ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += "    ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += "    ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += "    ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += "    ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += "    ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += "    ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += "    ,BODYNAMERF" + Environment.NewLine;
                            sqlText += "    ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += "    ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += "    ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += "    ,EDIVNMRF" + Environment.NewLine;
                            sqlText += "    ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += "    ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += "    ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += "    ,CREATEDATERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@FREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERCODE" + Environment.NewLine;
                            sqlText += "    ,@MODELCODE" + Environment.NewLine;
                            sqlText += "    ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += "    ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += "    ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += "    ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += "    ,@FULLMODEL" + Environment.NewLine;
                            sqlText += "    ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += "    ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += "    ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += "    ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += "    ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += "    ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += "    ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += "    ,@BODYNAME" + Environment.NewLine;
                            sqlText += "    ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += "    ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += "    ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += "    ,@EDIVNM" + Environment.NewLine;
                            sqlText += "    ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += "    ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += "    ,@SHIFTNM" + Environment.NewLine;
                            sqlText += "    ,@CREATEDATE" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchModelWork;
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
                        SqlParameter paraFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNO", SqlDbType.NChar);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);
                        SqlParameter paraCreateDate = sqlCommand.Parameters.Add("@CREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchModelWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchModelWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freeSearchModelWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.LogicalDeleteCode);
                        paraFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelSubCode);
                        if (!String.IsNullOrEmpty(freeSearchModelWork.ExhaustGasSign))
                        {
                            paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ExhaustGasSign);
                        }
                        else
                        {
                            paraExhaustGasSign.Value = " ";
                        }

                        if (!String.IsNullOrEmpty(freeSearchModelWork.SeriesModel))
                        {
                            paraSeriesModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.SeriesModel);
                        }
                        else
                        {
                            paraSeriesModel.Value = " ";
                        }

                        if (!String.IsNullOrEmpty(freeSearchModelWork.CategorySignModel))
                        {
                            paraCategorySignModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.CategorySignModel);
                        }
                        else
                        {
                            paraCategorySignModel.Value = " ";
                        }

                        paraFullModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FullModel);
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelDesignationNo);
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.CategoryNo);
                        if (freeSearchModelWork.StProduceTypeOfYear == DateTime.MinValue)
                        {
                            paraStProduceTypeOfYear.Value = 0;
                        }
                        else
                        {
                            paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMM", freeSearchModelWork.StProduceTypeOfYear));
                        }

                        if (freeSearchModelWork.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            paraEdProduceTypeOfYear.Value = 0;
                        }
                        else
                        {
                            paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMM", freeSearchModelWork.EdProduceTypeOfYear));
                        }
                        
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.StProduceFrameNo);
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.EdProduceFrameNo);
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ModelGradeNm);
                        paraBodyName.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.BodyName);
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.DoorCount);
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EngineModelNm);
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EngineDisplaceNm);
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EDivNm);
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.TransmissionNm);
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.WheelDriveMethodNm);
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ShiftNm);
                        paraCreateDate.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.CreateDate);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.UpdateDate);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(freeSearchModelWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            freeSearchModelList = al;

            return status;
        }
        #endregion


        # region �� ���R�����^���}�X�^�����폜���� ��
        /// <summary>
        /// ���R�����^���}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="freeSearchModelList">���R�����^���}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����^���}�X�^�̃L�[�l����v���鎩�R�����^���}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        public int Delete(object freeSearchModelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = freeSearchModelList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// ���R�����^���}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="freeSearchModelList">���R�����^���}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : freeSearchModelList �Ɋi�[����Ă���UOE ������}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        public int Delete(ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(freeSearchModelList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ���R�����^���}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="freeSearchModelList">���R�����^���}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList �Ɋi�[����Ă��鎩�R�����^���}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.30</br>
        private int DeleteProc(ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (freeSearchModelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < freeSearchModelList.Count; i++)
                    {
                        FreeSearchModelWork freeSearchModelWork = freeSearchModelList[i] as FreeSearchModelWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNO", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != freeSearchModelWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                            findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
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
        #endregion  //�R�l�N�V������������
    }
}

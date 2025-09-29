//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^���
// �v���O�����T�v   : ���R�����^���}�X�^��� �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����^���}�X�^��� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^���READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchModelPrintDB : RemoteWithAppLockDB, IFreeSearchModelPrintDB
    {
        # region �� Constructor ��
        /// <summary>
        /// ���R�����^���}�X�^��� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^���READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchModelPrintDB()
            :
        base("PMJKN02009D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelPrintWork", "FREESEARCHMODELPRINTWORK") //���N���X�̃R���X�g���N�^
        {
        }
        #endregion


        #region �� ���R�����^���}�X�^�������� ��
        /// <summary>
        /// ���R�����^���}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�����^���}�X�^�i����j�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(object paraWork, out object retList)
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

                status = SearchAllProc(out retList, paraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreeSearchModelPrintDB.SearchAll");
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        private int SearchAllProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchModelParaWork freeSearchModelParaWork = paraWork as FreeSearchModelParaWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            //�^���i�t���^�j
            string modelName = freeSearchModelParaWork.ModelName;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" F.CREATEDATETIMERF, ");//�쐬����
                sb.Append(" F.UPDATEDATETIMERF, ");//�X�V����
                sb.Append(" F.ENTERPRISECODERF, ");//��ƃR�[�h
                sb.Append(" F.FILEHEADERGUIDRF, ");//GUID
                sb.Append(" F.UPDEMPLOYEECODERF, ");//�X�V�]�ƈ��R�[�h
                sb.Append(" F.UPDASSEMBLYID1RF, ");//�X�V�A�Z���u��ID1
                sb.Append(" F.UPDASSEMBLYID2RF, ");//�X�V�A�Z���u��ID2
                sb.Append(" F.LOGICALDELETECODERF, ");//�_���폜�敪
                sb.Append(" F.FREESRCHMDLFXDNORF, ");//���R�����^���Œ�ԍ�
                sb.Append(" F.MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" F.MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" F.MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" F.EXHAUSTGASSIGNRF, ");//�r�K�X�L��
                sb.Append(" F.SERIESMODELRF, ");//�V���[�Y�^��
                sb.Append(" F.CATEGORYSIGNMODELRF, ");//�^���i�ޕʋL���j
                sb.Append(" F.FULLMODELRF, ");//�^���i�t���^�j
                sb.Append(" F.MODELDESIGNATIONNORF, ");//�^���w��ԍ�
                sb.Append(" F.CATEGORYNORF, ");//�ޕʔԍ�
                sb.Append(" F.STPRODUCETYPEOFYEARRF, ");//�J�n���Y�N��
                sb.Append(" F.EDPRODUCETYPEOFYEARRF, ");//�I�����Y�N��
                sb.Append(" F.STPRODUCEFRAMENORF, ");//���Y�ԑ�ԍ��J�n
                sb.Append(" F.EDPRODUCEFRAMENORF, ");//���Y�ԑ�ԍ��I��
                sb.Append(" F.MODELGRADENMRF, ");//�^���O���[�h����
                sb.Append(" F.BODYNAMERF, ");//�{�f�B�[����
                sb.Append(" F.DOORCOUNTRF, ");//�h�A��
                sb.Append(" F.ENGINEMODELNMRF, ");//�G���W���^������
                sb.Append(" F.ENGINEDISPLACENMRF, ");//�r�C�ʖ���
                sb.Append(" F.EDIVNMRF, ");//E�敪����
                sb.Append(" F.TRANSMISSIONNMRF, ");//�~�b�V��������
                sb.Append(" F.WHEELDRIVEMETHODNMRF, ");//�쓮��������
                sb.Append(" F.SHIFTNMRF, ");//�V�t�g����
                sb.Append(" F.CREATEDATERF, ");//�쐬���t
                sb.Append(" F.UPDATEDATERF, ");//�X�V�N����
                sb.Append(" M.MODELFULLNAMERF ");//�Ԏ�S�p����		
                sb.Append(" FROM ");
                //���R�����^���}�X�^
                sb.Append(" FREESEARCHMODELRF F WITH (READUNCOMMITTED) ");
                //�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j
                sb.Append(" LEFT JOIN MODELNAMEURF M WITH (READUNCOMMITTED) ");
                sb.Append(" ON M.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND M.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND M.MODELUNIQUECODERF=RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3) ");
                sb.Append(" WHERE ");
                //��ƃR�[�h
                sb.Append(" F.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.EnterpriseCode);
                //�_���폜�敪
                sb.Append(" AND F.LOGICALDELETECODERF=0 ");
                //�쐬���t (�ȑO�A�ȍ~�A����)
                if (freeSearchModelParaWork.CreateDateTime != 0)
                {
                    if (freeSearchModelParaWork.CreateDateTimeCode == 0)
                    {
                        sb.Append(" AND F.CREATEDATERF<=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                    else if (freeSearchModelParaWork.CreateDateTimeCode == 1)
                    {
                        sb.Append(" AND F.CREATEDATERF>=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                    else if (freeSearchModelParaWork.CreateDateTimeCode == 2)
                    {
                        sb.Append(" AND F.CREATEDATERF=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                }
                //�Ԏ� ���[�J�[�R�[�h �Ԏ�R�[�h �Ԏ�T�u�R�[�h
                string carModelSt = freeSearchModelParaWork.CarMakerCodeSt.ToString("000");
                carModelSt += "-" + freeSearchModelParaWork.CarModelCodeSt.ToString("000");
                carModelSt += "-" + freeSearchModelParaWork.CarModelSubCodeSt.ToString("000");

                string carModelEd = freeSearchModelParaWork.CarMakerCodeEd.ToString("000");
                carModelEd += "-" + freeSearchModelParaWork.CarModelCodeEd.ToString("000");
                carModelEd += "-" + freeSearchModelParaWork.CarModelSubCodeEd.ToString("000");

                if ("000-000-000" != carModelSt)
                {
                    sb.Append(" AND RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3)>=@AST_MODELCODE ");
                    SqlParameter Para_St_CarModelCode = sqlCommand.Parameters.Add("@AST_MODELCODE", SqlDbType.Char);
                    Para_St_CarModelCode.Value = SqlDataMediator.SqlSetString(carModelSt);
                }
                if ("999-999-999" != carModelEd)
                {
                    sb.Append(" AND RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3)<=@AED_MODELCODE ");
                    SqlParameter Para_Ed_CarModelCode = sqlCommand.Parameters.Add("@AED_MODELCODE", SqlDbType.Char);
                    Para_Ed_CarModelCode.Value = SqlDataMediator.SqlSetString(carModelEd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" F.MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" F.MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" F.MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" F.FULLMODELRF ");//�^���i�t���^�j

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    FreeSearchModelPrintWork wkFreeSearchModelPrintWork = new FreeSearchModelPrintWork();

                    //���R�����^���}�X�^�f�[�^���ʎ擾���e�i�[
                    wkFreeSearchModelPrintWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
                    wkFreeSearchModelPrintWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    wkFreeSearchModelPrintWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//��ƃR�[�h
                    wkFreeSearchModelPrintWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchModelPrintWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//�X�V�]�ƈ��R�[�h
                    wkFreeSearchModelPrintWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//�X�V�A�Z���u��ID1
                    wkFreeSearchModelPrintWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//�X�V�A�Z���u��ID2
                    wkFreeSearchModelPrintWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//�_���폜�敪
                    wkFreeSearchModelPrintWork.FreeSrchMdlFxdNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNORF"));//���R�����^���Œ�ԍ�
                    wkFreeSearchModelPrintWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//���[�J�[�R�[�h
                    wkFreeSearchModelPrintWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//�Ԏ�R�[�h
                    wkFreeSearchModelPrintWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//�Ԏ�T�u�R�[�h
                    wkFreeSearchModelPrintWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));//�r�K�X�L��
                    wkFreeSearchModelPrintWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));//�V���[�Y�^��
                    wkFreeSearchModelPrintWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));//�^���i�ޕʋL���j
                    wkFreeSearchModelPrintWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//�^���i�t���^�j
                    wkFreeSearchModelPrintWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));//�^���w��ԍ�
                    wkFreeSearchModelPrintWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));//�ޕʔԍ�
                    wkFreeSearchModelPrintWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));//�J�n���Y�N��
                    wkFreeSearchModelPrintWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));//�I�����Y�N��
                    wkFreeSearchModelPrintWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));//���Y�ԑ�ԍ��J�n
                    wkFreeSearchModelPrintWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));//���Y�ԑ�ԍ��I��
                    wkFreeSearchModelPrintWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//�^���O���[�h����
                    wkFreeSearchModelPrintWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//�{�f�B�[����
                    wkFreeSearchModelPrintWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//�h�A��
                    wkFreeSearchModelPrintWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//�G���W���^������
                    wkFreeSearchModelPrintWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//�r�C�ʖ���
                    wkFreeSearchModelPrintWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E�敪����
                    wkFreeSearchModelPrintWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//�~�b�V��������
                    wkFreeSearchModelPrintWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//�쓮��������
                    wkFreeSearchModelPrintWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//�V�t�g����
                    wkFreeSearchModelPrintWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//�쐬���t
                    wkFreeSearchModelPrintWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//�X�V�N����
                    wkFreeSearchModelPrintWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));//�Ԏ�S�p����
                    #endregion

                    //�^���i�t���^�j���A��ʂ̓��͒l�ƈȉ��̏����ň�v���邩�ǂ����B
                    if (CheckModelName(wkFreeSearchModelPrintWork, modelName))
                    {
                        al.Add(wkFreeSearchModelPrintWork);
                    }
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


        #region [�^���i�t���^�j�̔��f]
        /// <summary>
        /// �^���i�t���^�j�̔��f����
        /// </summary>
        /// <param name="freeSearchModelPrintWork">���R�����^���}�X�^�f�[�^����</param>
        /// <param name="modelName">�^���i�t���^�j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private bool CheckModelName(FreeSearchModelPrintWork freeSearchModelPrintWork, string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return true;
            }

            //�^���i�t���^�j
            string fullModel = freeSearchModelPrintWork.FullModel;
            string[] fullModels = fullModel.Split('-');
            string secondModel = string.Empty;
            bool isHaveFirst = true;

            if (fullModels.Length > 1)
            {
                //�擪�̗v�f���S���ȏ�̂��߁A��P�v�f�����݂��Ȃ�
                if (fullModels[0].Length >= 4)
                {
                    secondModel = fullModel;
                    isHaveFirst = false;
                }
                else
                {
                    for (int i = 1; i < fullModels.Length; i++)
                    {
                        secondModel += fullModels[i];
                        if (i != fullModels.Length - 1)
                        {
                            secondModel += "-";
                        }
                    }
                }
            }

            //���͒l��"-"���܂܂Ȃ��ꍇ�A�Ώۃf�[�^�̑�Q�v�f�ȍ~�Ɣ�r����B
            if (!modelName.Contains("-"))
            {
                if (secondModel.Length >= modelName.Length && secondModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }
            //"-"�̌�ɒl�������ꍇ���A�Ώۃf�[�^�̑�Q�v�f�ȍ~�Ɣ�r����B
            else if (modelName.LastIndexOf("-") == modelName.Length - 1)
            {
                //"-"���폜����
                modelName = modelName.Substring(0, modelName.Length - 1);
                //"-"�����͒l�̊Ԃɂ���ꍇ�́A�Ώۃf�[�^�̑�P�v�f�����r����B
                if (modelName.Contains("-"))
                {
                    if (!isHaveFirst)
                    {
                        return false;
                    }
                    if (fullModel.Length >= modelName.Length && fullModel.Substring(0, modelName.Length) == modelName)
                    {
                        return true;
                    }
                }
                //"-"�̌�ɒl�������ꍇ���A�Ώۃf�[�^�̑�Q�v�f�ȍ~�Ɣ�r����B
                else if (secondModel.Length >= modelName.Length && secondModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }
            //"-"�����͒l�̊Ԃɂ���ꍇ�́A�Ώۃf�[�^�̑�P�v�f�����r����B
            else
            {
                if (!isHaveFirst)
                {
                    return false;
                }
                if (fullModel.Length >= modelName.Length && fullModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
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

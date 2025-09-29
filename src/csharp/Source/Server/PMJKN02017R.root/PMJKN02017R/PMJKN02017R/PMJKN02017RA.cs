//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^���
// �v���O�����T�v   : ���R�������i�}�X�^��� �����[�g�I�u�W�F�N�g
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
    /// ���R�������i�}�X�^��� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^���READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsPrintDB : RemoteWithAppLockDB, IFreeSearchPartsPrintDB
    {
        # region �� Constructor ��
        /// <summary>
        /// ���R�������i�}�X�^��� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^���READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchPartsPrintDB()
            :
        base("PMJKN02019D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsPrintWork", "FREESEARCHPARTSPRINTWORK") //���N���X�̃R���X�g���N�^
        {
        }
        #endregion


        #region �� ���R�������i�}�X�^�������� ��
        /// <summary>
        /// ���R�������i�}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�������i�}�X�^�i����j�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^�����������s���N���X�ł��B</br>
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
                base.WriteErrorLog(ex, "FreeSearchPartsPrintDB.SearchAll");
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
        /// ���R�������i�}�X�^�f�[�^��S�Ė߂��܂�
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�������i�}�X�^�f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        private int SearchAllProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchPartsParaWork freeSearchPartsParaWork = paraWork as FreeSearchPartsParaWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            // �V�X�e�����t
            DateTime systemDate = DateTime.Now;
            int systemDateInt = Convert.ToInt32(string.Format("{0:yyyyMMdd}", systemDate));

            //�^���i�t���^�j
            string modelName = freeSearchPartsParaWork.ModelName;

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
                sb.Append(" F.FRESRCHPRTPROPNORF, ");//���R�������i�ŗL�ԍ�
                sb.Append(" F.MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" F.MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" F.MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" F.FULLMODELRF, ");//�^���i�t���^�j
                sb.Append(" F.TBSPARTSCODERF, ");//BL�R�[�h
                sb.Append(" F.TBSPARTSCDDERIVEDNORF, ");//BL�R�[�h�}��
                sb.Append(" F.GOODSNORF, ");//���i�ԍ�
                sb.Append(" F.GOODSNONONEHYPHENRF, ");//�n�C�t�������i�ԍ�
                sb.Append(" F.GOODSMAKERCDRF, ");//���i���[�J�[�R�[�h
                sb.Append(" F.PARTSQTYRF, ");//���iQTY
                sb.Append(" F.PARTSOPNMRF, ");//���i�I�v�V��������
                sb.Append(" F.MODELPRTSADPTYMRF, ");//�^���ʕ��i�̗p�N��
                sb.Append(" F.MODELPRTSABLSYMRF, ");//�^���ʕ��i�p�~�N��
                sb.Append(" F.MODELPRTSADPTFRAMENORF, ");//�^���ʕ��i�̗p�ԑ�ԍ�
                sb.Append(" F.MODELPRTSABLSFRAMENORF, ");//�^���ʕ��i�p�~�ԑ�ԍ�
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
                sb.Append(" M.MODELFULLNAMERF, ");//�Ԏ�S�p����
                sb.Append(" MA.MAKERNAMERF, ");//���[�J�[����
                sb.Append(" B.BLGOODSHALFNAMERF ");//BL���i�R�[�h���́i���p�j
                sb.Append(" FROM ");
                //���R�������i�}�X�^
                sb.Append(" FREESEARCHPARTSRF F WITH (READUNCOMMITTED) ");
                //�Ԏ햼�̃}�X�^�i���[�U�[�o�^�j
                sb.Append(" LEFT JOIN MODELNAMEURF M WITH (READUNCOMMITTED) ");
                sb.Append(" ON M.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND M.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND M.MODELUNIQUECODERF=RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3) ");
                //�a�k���i�R�[�h�}�X�^(���[�U�[)
                sb.Append(" LEFT JOIN BLGOODSCDURF B WITH (READUNCOMMITTED) ");
                sb.Append(" ON B.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND B.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND B.BLGOODSCODERF=F.TBSPARTSCODERF ");
                //���[�J�[�}�X�^�i���[�U�[�o�^���j
                sb.Append(" LEFT JOIN MAKERURF MA WITH (READUNCOMMITTED) ");
                sb.Append(" ON MA.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND MA.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND MA.GOODSMAKERCDRF=F.GOODSMAKERCDRF ");
                sb.Append(" WHERE ");
                //��ƃR�[�h
                sb.Append(" F.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsParaWork.EnterpriseCode);
                //�_���폜�敪
                sb.Append(" AND F.LOGICALDELETECODERF=0 ");
                //�쐬���t (�ȑO�A�ȍ~�A����)
                if (freeSearchPartsParaWork.CreateDateTime != 0)
                {
                    if (freeSearchPartsParaWork.CreateDateTimeCode == 0)
                    {
                        sb.Append(" AND F.CREATEDATERF<=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                    else if (freeSearchPartsParaWork.CreateDateTimeCode == 1)
                    {
                        sb.Append(" AND F.CREATEDATERF>=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                    else if (freeSearchPartsParaWork.CreateDateTimeCode == 2)
                    {
                        sb.Append(" AND F.CREATEDATERF=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                }
                //�Ԏ� ���[�J�[�R�[�h �Ԏ�R�[�h �Ԏ�T�u�R�[�h
                string carModelSt = freeSearchPartsParaWork.CarMakerCodeSt.ToString("000");
                carModelSt += "-" + freeSearchPartsParaWork.CarModelCodeSt.ToString("000");
                carModelSt += "-" + freeSearchPartsParaWork.CarModelSubCodeSt.ToString("000");

                string carModelEd = freeSearchPartsParaWork.CarMakerCodeEd.ToString("000");
                carModelEd += "-" + freeSearchPartsParaWork.CarModelCodeEd.ToString("000");
                carModelEd += "-" + freeSearchPartsParaWork.CarModelSubCodeEd.ToString("000");

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

                //BL�R�[�h
                if (0 != freeSearchPartsParaWork.BLGoodsCodeSt)
                {
                    sb.Append(" AND F.TBSPARTSCODERF>=@FINDSTTBSPARTSCODE ");
                    SqlParameter Para_BLGoodsCodeSt = sqlCommand.Parameters.Add("@FINDSTTBSPARTSCODE", SqlDbType.Int);
                    Para_BLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.BLGoodsCodeSt);
                }
                if (0 != freeSearchPartsParaWork.BLGoodsCodeEd)
                {
                    sb.Append(" AND F.TBSPARTSCODERF<=@FINDEDTBSPARTSCODE ");
                    SqlParameter Para_BLGoodsCodeEd = sqlCommand.Parameters.Add("@FINDEDTBSPARTSCODE", SqlDbType.Int);
                    Para_BLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.BLGoodsCodeEd);
                }

                //���i���[�J�[�R�[�h
                if (0 != freeSearchPartsParaWork.MakerCodeSt)
                {
                    sb.Append(" AND F.MAKERCODERF>=@FINDSTMAKERCODE ");
                    SqlParameter Para_MakerCodeSt = sqlCommand.Parameters.Add("@FINDSTMAKERCODE", SqlDbType.Int);
                    Para_MakerCodeSt.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.MakerCodeSt);
                }
                if (0 != freeSearchPartsParaWork.MakerCodeEd)
                {
                    sb.Append(" AND F.MAKERCODERF<=@FINDEDMAKERCODE ");
                    SqlParameter Para_MakerCodeEd = sqlCommand.Parameters.Add("@FINDEDMAKERCODE", SqlDbType.Int);
                    Para_MakerCodeEd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.MakerCodeEd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" F.MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" F.MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" F.MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" F.FULLMODELRF, ");//�^���i�t���^�j
                sb.Append(" F.GOODSNORF, ");//�i��
                sb.Append(" F.GOODSMAKERCDRF ");//���[�J�[

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    FreeSearchPartsPrintWork wkFreeSearchPartsPrintWork = new FreeSearchPartsPrintWork();

                    //���R�������i�}�X�^�f�[�^���ʎ擾���e�i�[
                    wkFreeSearchPartsPrintWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
                    wkFreeSearchPartsPrintWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    wkFreeSearchPartsPrintWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//��ƃR�[�h
                    wkFreeSearchPartsPrintWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchPartsPrintWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//�X�V�]�ƈ��R�[�h
                    wkFreeSearchPartsPrintWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//�X�V�A�Z���u��ID1
                    wkFreeSearchPartsPrintWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//�X�V�A�Z���u��ID2
                    wkFreeSearchPartsPrintWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//�_���폜�敪
                    wkFreeSearchPartsPrintWork.FreSrchPrtPropNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRESRCHPRTPROPNORF"));//���R�������i�ŗL�ԍ�
                    wkFreeSearchPartsPrintWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//���[�J�[�R�[�h
                    wkFreeSearchPartsPrintWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//�Ԏ�R�[�h
                    wkFreeSearchPartsPrintWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//�Ԏ�T�u�R�[�h
                    wkFreeSearchPartsPrintWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//�^���i�t���^�j
                    wkFreeSearchPartsPrintWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));//BL�R�[�h
                    wkFreeSearchPartsPrintWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));//BL�R�[�h�}��
                    wkFreeSearchPartsPrintWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));//���i�ԍ�
                    wkFreeSearchPartsPrintWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));//�n�C�t�������i�ԍ�
                    wkFreeSearchPartsPrintWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));//���i���[�J�[�R�[�h
                    wkFreeSearchPartsPrintWork.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));//���iQTY
                    wkFreeSearchPartsPrintWork.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));//���i�I�v�V��������
                    wkFreeSearchPartsPrintWork.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));//�^���ʕ��i�̗p�N��
                    wkFreeSearchPartsPrintWork.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));//�^���ʕ��i�p�~�N��
                    wkFreeSearchPartsPrintWork.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));//�^���ʕ��i�̗p�ԑ�ԍ�
                    wkFreeSearchPartsPrintWork.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));//�^���ʕ��i�p�~�ԑ�ԍ�
                    wkFreeSearchPartsPrintWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//�^���O���[�h����
                    wkFreeSearchPartsPrintWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//�{�f�B�[����
                    wkFreeSearchPartsPrintWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//�h�A��
                    wkFreeSearchPartsPrintWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//�G���W���^������
                    wkFreeSearchPartsPrintWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//�r�C�ʖ���
                    wkFreeSearchPartsPrintWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E�敪����
                    wkFreeSearchPartsPrintWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//�~�b�V��������
                    wkFreeSearchPartsPrintWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//�쓮��������
                    wkFreeSearchPartsPrintWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//�V�t�g����
                    wkFreeSearchPartsPrintWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//�쐬���t
                    wkFreeSearchPartsPrintWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//�X�V�N����
                    wkFreeSearchPartsPrintWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));//�Ԏ�S�p����
                    wkFreeSearchPartsPrintWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));//���[�J�[����
                    wkFreeSearchPartsPrintWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));//BL���i�R�[�h���́i���p�j
                    #endregion

                    //�^���i�t���^�j���A��ʂ̓��͒l�ƈȉ��̏����ň�v���邩�ǂ����B
                    if (CheckModelName(wkFreeSearchPartsPrintWork, modelName))
                    {
                        al.Add(wkFreeSearchPartsPrintWork);
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
        /// <param name="freeSearchPartsPrintWork">���R�������i�}�X�^�f�[�^����</param>
        /// <param name="modelName">�^���i�t���^�j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private bool CheckModelName(FreeSearchPartsPrintWork freeSearchPartsPrintWork, string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return true;
            }

            //�^���i�t���^�j
            string fullModel = freeSearchPartsPrintWork.FullModel;
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

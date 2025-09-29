//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^
// �v���O�����T�v   : ���R�������i�}�X�^ �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�������i�}�X�^ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsDB : RemoteWithAppLockDB, IFreeSearchPartsDB
    {
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        # region �� Constructor ��
        /// <summary>
        /// ���R�������i�}�X�^ �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsDB()
            :
        base("PMJKN09016D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork", "FreeSearchPartsRF") //���N���X�̃R���X�g���N�^
        {
        }
        #endregion

        #region �� ���R�������i�}�X�^�������� ��
        /// <summary>
        /// ���R�������i�}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�������i�}�X�^�i�j�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <param name="readMode">�����敪�i���݁A���g�p�j</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�������i�}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(object paraWork, out object retList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retList = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchProc(out retList, paraWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                retList = new ArrayList();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// ���R�������i�}�X�^�f�[�^��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�������i�}�X�^�f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        private int SearchProc(out object retList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            FreeSearchPartsWork freeSearchPartsWork = paraWork as FreeSearchPartsWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();   //���o����

            //�^���i�t���^�j
            string modelName = freeSearchPartsWork.FullModel;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRESRCHPRTPROPNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, FULLMODELRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, GOODSNORF, GOODSNONONEHYPHENRF, GOODSMAKERCDRF, PARTSQTYRF, PARTSOPNMRF, MODELPRTSADPTYMRF, MODELPRTSABLSYMRF, MODELPRTSADPTFRAMENORF, MODELPRTSABLSFRAMENORF, MODELGRADENMRF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, ENGINEDISPLACENMRF, EDIVNMRF, TRANSMISSIONNMRF, WHEELDRIVEMETHODNMRF, SHIFTNMRF, CREATEDATERF, UPDATEDATERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");

                //Prameter�I�u�W�F�N�g�̍쐬
                //��ƃR�[�h
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sb.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sb.Append("  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //���R�������i�ŗL�ԍ�
                if (!string.IsNullOrEmpty(freeSearchPartsWork.FreSrchPrtPropNo))
                {
                    sb.Append("  AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO" + Environment.NewLine);
                    SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);
                    findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                }
                //�^���i�t���^�j
                if (!string.IsNullOrEmpty(freeSearchPartsWork.FullModel))
                {
                    sb.Append("  AND FULLMODELRF IN (");
                    string[] fullModels = freeSearchPartsWork.FullModel.Split('\t');
                    for (int i = 0; i < fullModels.Length; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append(" , ");
                        }
                        sb.Append("'" + fullModels[i] + "'");
                    }
                    sb.Append(")" + Environment.NewLine);
                }
                //BL�R�[�h
                if (freeSearchPartsWork.TbsPartsCode != 0)
                {
                    sb.Append("  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine);
                    SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                    findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                }
                //BL�R�[�h�}��
                if (freeSearchPartsWork.TbsPartsCdDerivedNo != 0)
                {
                    sb.Append("  AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO" + Environment.NewLine);
                    SqlParameter findParaTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);
                    findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                }

                //���i�ԍ�
                if (!string.IsNullOrEmpty(freeSearchPartsWork.GoodsNo))
                {
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    switch (freeSearchPartsWork.GoodsNoFuzzy)
                    {
                        //�ƈ�v
                        case 0:
                            sb.Append("  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            break;
                        //�Ŏn�܂�
                        case 1:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(this.UseLikeString(freeSearchPartsWork.GoodsNo) + "%");
                            break;
                        //���܂�
                        case 2:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString("%" + this.UseLikeString(freeSearchPartsWork.GoodsNo) + "%");
                            break;
                        //�ŏI���
                        case 3:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString("%" + this.UseLikeString(freeSearchPartsWork.GoodsNo));
                            break;
                        default:
                            sb.Append("  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            break;
                    }
                }
                //���i���[�J�[�R�[�h
                if (freeSearchPartsWork.GoodsMakerCd != 0)
                {
                    sb.Append("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" MAKERCODERF, ");//���[�J�[�R�[�h
                sb.Append(" MODELCODERF, ");//�Ԏ�R�[�h
                sb.Append(" MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h
                sb.Append(" FULLMODELRF ");//�^���i�t���^�j

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    FreeSearchPartsWork wkFreeSearchPartsWork = new FreeSearchPartsWork();

                    //���R�������i�}�X�^�f�[�^���ʎ擾���e�i�[
                    wkFreeSearchPartsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreeSearchPartsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreeSearchPartsWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreeSearchPartsWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreeSearchPartsWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreeSearchPartsWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreeSearchPartsWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreeSearchPartsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreeSearchPartsWork.FreSrchPrtPropNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRESRCHPRTPROPNORF"));
                    wkFreeSearchPartsWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    wkFreeSearchPartsWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    wkFreeSearchPartsWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    wkFreeSearchPartsWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkFreeSearchPartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkFreeSearchPartsWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkFreeSearchPartsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkFreeSearchPartsWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    wkFreeSearchPartsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkFreeSearchPartsWork.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                    wkFreeSearchPartsWork.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAdptYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAblsYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                    wkFreeSearchPartsWork.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                    wkFreeSearchPartsWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                    wkFreeSearchPartsWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                    wkFreeSearchPartsWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                    wkFreeSearchPartsWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    wkFreeSearchPartsWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));
                    wkFreeSearchPartsWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                    wkFreeSearchPartsWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                    wkFreeSearchPartsWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                    wkFreeSearchPartsWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                    wkFreeSearchPartsWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));
                    wkFreeSearchPartsWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    #endregion

                    al.Add(wkFreeSearchPartsWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            retList = al as object;

            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�̕����폜
        /// </summary>
        /// <param name="paraObjList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        public int Delete(object paraObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = paraObjList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�̕����폜
        /// </summary>
        /// <param name="paraList">���R�������i�I�u�W�F�N�g ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        private int DeleteProc(ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (paraList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < paraList.Count; i++)
                    {
                        FreeSearchPartsWork freeSearchPartsWork = paraList[i] as FreeSearchPartsWork;

                        # region [SELECT��]
                        sqlCommand.CommandText = "SELECT UPDATEDATETIMERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO AND FULLMODELRF=@FINDFULLMODEL AND TBSPARTSCODERF=@FINDTBSPARTSCODE AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);
                        SqlParameter findParaFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                        findParaFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                        findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != freeSearchPartsWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlCommand.CommandText = "DELETE FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO AND FULLMODELRF=@FINDFULLMODEL AND TBSPARTSCODERF=@FINDTBSPARTSCODE AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                            findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                            findParaFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                            findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
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
        #endregion

        # region [Write]
        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�̓o�^�A�X�V
        /// </summary>
        /// <param name="paraObjList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        public int Write(ref object paraObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = paraObjList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraObjList = paraList as object;
                }
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
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�̓o�^�A�X�V
        /// </summary>
        /// <param name="paraList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        public int Write(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�̓o�^�A�X�V
        /// </summary>
        /// <param name="paraList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        private int WriteProc(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT;
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                if (paraList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < paraList.Count; i++)
                    {
                        FreeSearchPartsWork freeSearchPartsWork = paraList[i] as FreeSearchPartsWork;

                        # region [SELECT��]
                        sqlCommand.CommandText = "SELECT UPDATEDATETIMERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO ";
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        if (string.IsNullOrEmpty(freeSearchPartsWork.EnterpriseCode))
                        {
                            freeSearchPartsWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        }
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != freeSearchPartsWork.UpdateDateTime)
                            {
                                if (freeSearchPartsWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE FREESEARCHPARTSRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FRESRCHPRTPROPNORF=@FRESRCHPRTPROPNO , MAKERCODERF=@MAKERCODE , MODELCODERF=@MODELCODE , MODELSUBCODERF=@MODELSUBCODE , FULLMODELRF=@FULLMODEL , TBSPARTSCODERF=@TBSPARTSCODE , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO , GOODSNORF=@GOODSNO , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN , GOODSMAKERCDRF=@GOODSMAKERCD , PARTSQTYRF=@PARTSQTY , PARTSOPNMRF=@PARTSOPNM , MODELPRTSADPTYMRF=@MODELPRTSADPTYM , MODELPRTSABLSYMRF=@MODELPRTSABLSYM , MODELPRTSADPTFRAMENORF=@MODELPRTSADPTFRAMENO , MODELPRTSABLSFRAMENORF=@MODELPRTSABLSFRAMENO , MODELGRADENMRF=@MODELGRADENM , BODYNAMERF=@BODYNAME , DOORCOUNTRF=@DOORCOUNT , ENGINEMODELNMRF=@ENGINEMODELNM , ENGINEDISPLACENMRF=@ENGINEDISPLACENM , EDIVNMRF=@EDIVNM , TRANSMISSIONNMRF=@TRANSMISSIONNM , WHEELDRIVEMETHODNMRF=@WHEELDRIVEMETHODNM , SHIFTNMRF=@SHIFTNM , UPDATEDATERF=@UPDATEDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO ";
                            
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                            findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchPartsWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (freeSearchPartsWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = "INSERT INTO FREESEARCHPARTSRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRESRCHPRTPROPNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, FULLMODELRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, GOODSNORF, GOODSNONONEHYPHENRF, GOODSMAKERCDRF, PARTSQTYRF, PARTSOPNMRF, MODELPRTSADPTYMRF, MODELPRTSABLSYMRF, MODELPRTSADPTFRAMENORF, MODELPRTSABLSFRAMENORF, MODELGRADENMRF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, ENGINEDISPLACENMRF, EDIVNMRF, TRANSMISSIONNMRF, WHEELDRIVEMETHODNMRF, SHIFTNMRF, CREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FRESRCHPRTPROPNO, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @FULLMODEL, @TBSPARTSCODE, @TBSPARTSCDDERIVEDNO, @GOODSNO, @GOODSNONONEHYPHEN, @GOODSMAKERCD, @PARTSQTY, @PARTSOPNM, @MODELPRTSADPTYM, @MODELPRTSABLSYM, @MODELPRTSADPTFRAMENO, @MODELPRTSABLSFRAMENO, @MODELGRADENM, @BODYNAME, @DOORCOUNT, @ENGINEMODELNM, @ENGINEDISPLACENM, @EDIVNM, @TRANSMISSIONNM, @WHEELDRIVEMETHODNM, @SHIFTNM, @CREATEDATE, @UPDATEDATE)";
                            
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchPartsWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                            SqlParameter paraCreateDate = sqlCommand.Parameters.Add("@CREATEDATE", SqlDbType.Int);
                            paraCreateDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(freeSearchPartsWork.CreateDateTime));
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
                        SqlParameter paraFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FRESRCHPRTPROPNO", SqlDbType.NChar);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPartsQty = sqlCommand.Parameters.Add("@PARTSQTY", SqlDbType.Float);
                        SqlParameter paraPartsOpNm = sqlCommand.Parameters.Add("@PARTSOPNM", SqlDbType.NVarChar);
                        SqlParameter paraModelPrtsAdptYm = sqlCommand.Parameters.Add("@MODELPRTSADPTYM", SqlDbType.Int);
                        SqlParameter paraModelPrtsAblsYm = sqlCommand.Parameters.Add("@MODELPRTSABLSYM", SqlDbType.Int);
                        SqlParameter paraModelPrtsAdptFrameNo = sqlCommand.Parameters.Add("@MODELPRTSADPTFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelPrtsAblsFrameNo = sqlCommand.Parameters.Add("@MODELPRTSABLSFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchPartsWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchPartsWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freeSearchPartsWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.LogicalDeleteCode);
                        paraFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelSubCode);
                        paraFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNoNoneHyphen);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
                        paraPartsQty.Value = SqlDataMediator.SqlSetDouble(freeSearchPartsWork.PartsQty);
                        paraPartsOpNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.PartsOpNm);
                        paraModelPrtsAdptYm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(freeSearchPartsWork.ModelPrtsAdptYm);
                        paraModelPrtsAblsYm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(freeSearchPartsWork.ModelPrtsAblsYm);
                        paraModelPrtsAdptFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelPrtsAdptFrameNo);
                        paraModelPrtsAblsFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelPrtsAblsFrameNo);
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.ModelGradeNm);
                        paraBodyName.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.BodyName);
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.DoorCount);
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EngineModelNm);
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EngineDisplaceNm);
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EDivNm);
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.TransmissionNm);
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.WheelDriveMethodNm);
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.ShiftNm);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(freeSearchPartsWork.UpdateDateTime));

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(freeSearchPartsWork);
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

            paraList = al;

            return status;
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        #endregion

        #region �� ���R�������i�}�X�^�o�^�A�X�V�ƕ����폜���� ��
        /// <summary>
        /// �w�肳�ꂽ�����̎��R�������i�f�[�^�o�^�A�X�V�ƕ����폜
        /// </summary>
        /// <param name="writeParaObjList">���R�������i�I�u�W�F�N�g���X�g</param>
        /// <param name="deleteParaObjList">���R�������i�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��R�������i�f�[�^��o�^�A�X�V�ƕ����폜���܂�</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/30</br>
        public int WriteAndDelete(ref object writeParaObjList, object deleteParaObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = writeParaObjList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                if (paraList != null && paraList.Count != 0)
                {
                    status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
                }
                if (paraList == null || paraList.Count == 0 || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        writeParaObjList = paraList as object;
                    }
                    // �p�����[�^�̃L���X�g
                    ArrayList dparaList = deleteParaObjList as ArrayList;
                    status = this.DeleteProc(dparaList, ref sqlConnection, ref sqlTransaction);

                }
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

        #endregion

        /// <summary>
        /// �B�������p��Fuzzy����
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string UseLikeString(string data)
        {
            if (data.Contains("["))
            {
                data = data.Replace("[", "[[]");
            }
            if (data.Contains("%"))
            {
                data = data.Replace("%", "[%]");
            }
            if (data.Contains("_"))
            {
                data = data.Replace("_", "[_]");
            }
            return data;
        }
    }
}

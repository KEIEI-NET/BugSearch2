//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fcaohh
// �C����    2013/02/19     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
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
    /// �|���ꊇ�o�^�E�C���U�����e�i���XDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ꊇ�o�^�E�C���U�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    [Serializable]
    public class Rate2DB : RemoteDB, IRate2DB
    {
        /// <summary>
        /// �|���ꊇ�o�^�E�C���U�����e�i���XDB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : caohh</br>														   
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public Rate2DB()
            :
        base("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work", "RATERF")
        {
        }        

        #region [Write]
        /// <summary>
        /// �|���}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="rate2Work">Rate2Work�I�u�W�F�N�g</param>
        /// <param name="eFlag">�V�ǉ��s�t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        public int Write(ref object rate2Work, bool eFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(rate2Work);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSubSectionProc(ref paraList, eFlag, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                rate2Work = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.Write(ref object rate2Work)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �|���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">Rate2Work�I�u�W�F�N�g</param>
        /// <param name="eFlag">�V�ǉ��s�t���O</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        public int WriteSubSectionProc(ref ArrayList rateWorkList, bool eFlag, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateWriteList = null;
            ArrayList rateDeleteList = null;

            if (rateWorkList != null)
            {
                CreateRateWriteDelList(rateWorkList, out rateWriteList, out rateDeleteList);

                if (rateWriteList.Count != 0)
                {
                    status = this.WriteSubSectionProcProc(ref rateWriteList, eFlag, ref sqlConnection, ref sqlTransaction);
                }
                if (rateDeleteList.Count != 0)
                {
                    status = this.DeleteSubSectionProcProc(rateDeleteList, ref sqlConnection, ref sqlTransaction);
                }
            }

            return status;
		}

        #region �|���}�X�^�X�V�p���X�g�A�폜�p���X�g�쐬
        /// <summary>
        /// �|���}�X�^�X�V�p���X�g�A�폜�p���X�g�쐬
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockWriteList">�݌ɍX�V�p���X�g</param>
        /// <param name="stockDeleteList">�݌ɍ폜�p���X�g</param>
        /// <returns>STATUS</returns>
        private int CreateRateWriteDelList(ArrayList rateWorkList, out ArrayList rateWriteList, out ArrayList rateDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            rateWriteList = new ArrayList();
            rateDeleteList = new ArrayList();

            foreach (Rate2Work rate2Work in rateWorkList)
            {
                if (rate2Work.LogicalDeleteCode == 3)
                {
                    //�폜�p���X�g�쐬
                    rateDeleteList.Add(rate2Work);
                }
                else
                {
                    //�X�V�p���X�g�쐬
                    rateWriteList.Add(rate2Work);
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �|���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">Rate2Work�I�u�W�F�N�g</param>
        /// <param name="eFlag">�V�ǉ��s�t���O</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
		private int WriteSubSectionProcProc(ref ArrayList rateWorkList, bool eFlag, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            StringBuilder sqlText = new StringBuilder();
            sqlText.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, LOGICALDELETECODERF FROM RATERF").Append(Environment.NewLine);
            sqlText.Append("WHERE").Append(Environment.NewLine);
            sqlText.Append("  ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
            sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
            sqlText.Append("  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSNORF=@FINDGOODSNO").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSRATERANKRF=@FINDGOODSRATERANK").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND BLGROUPCODERF=@FINDBLGROUPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTOMERCODERF=@FINDCUSTOMERCODE").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND SUPPLIERCDRF=@FINDSUPPLIERCD").Append(Environment.NewLine);
            sqlText.Append("  AND LOTCOUNTRF=@FINDLOTCOUNT").Append(Environment.NewLine);
            
            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        Rate2Work rate2Work = rateWorkList[i] as Rate2Work;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                        SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            if (eFlag)
                            {
                                //����GUID�f�[�^������ꍇ�Œǉ��s�̍쐬�����ƍX�V������GUID���Z�b�g����
                                rate2Work.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
                                rate2Work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                rate2Work.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                            }

                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != rate2Work.UpdateDateTime)
                            {
                                int _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                                if (_logicalDeleteCode == 0)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    if (rate2Work.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                }
                                
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
                            

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                            findParaGoodsNo.Value = rate2Work.GoodsNo;
                            findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rate2Work;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (rate2Work.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;
                            sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                            sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rate2Work;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                        SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                        SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                        SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                        SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rate2Work.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rate2Work.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rate2Work.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rate2Work.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rate2Work.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rate2Work.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rate2Work.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rate2Work.RateSettingDivide);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngCustNm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        paraGoodsNo.Value = rate2Work.GoodsNo;
                        paraGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rate2Work.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rate2Work.RateVal);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rate2Work.UpRate);
                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rate2Work.GrsProfitSecureRate);
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rate2Work.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rate2Work.UnPrcFracProcDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rate2Work);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;
        }

        /// <summary>
        /// �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">�|���}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        private int DeleteSubSectionProcProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder command = new StringBuilder();
            command.Append ("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" ).Append( Environment.NewLine);
            command.Append ("WHERE" ).Append( Environment.NewLine);
            command.Append ("  ENTERPRISECODERF=@FINDENTERPRISECODE" ).Append( Environment.NewLine);
            command.Append ("  AND SECTIONCODERF=@FINDSECTIONCODE" ).Append( Environment.NewLine);
            command.Append ("  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSNORF=@FINDGOODSNO" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSRATERANKRF=@FINDGOODSRATERANK" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND BLGROUPCODERF=@FINDBLGROUPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND BLGOODSCODERF=@FINDBLGOODSCODE" ).Append( Environment.NewLine);
            command.Append ("  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" ).Append( Environment.NewLine);
            command.Append ("  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND SUPPLIERCDRF=@FINDSUPPLIERCD" ).Append( Environment.NewLine);
            command.Append ("  AND LOTCOUNTRF=@FINDLOTCOUNT" ).Append( Environment.NewLine);
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    Rate2Work rate2Work = rateWorkList[i] as Rate2Work;
                    sqlCommand = new SqlCommand(command.ToString(), sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                    findParaGoodsNo.Value = rate2Work.GoodsNo;
                    findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                    findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != rate2Work.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
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

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            Rate2Work[] RateWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is Rate2Work)
                    {
                        Rate2Work wkRateWork = paraobj as Rate2Work;
                        if (wkRateWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRateWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RateWorkArray = (Rate2Work[])XmlByteSerializer.Deserialize(byteArray, typeof(Rate2Work[]));
                        }
                        catch (Exception) { }
                        if (RateWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RateWorkArray);
                        }
                        else
                        {
                            try
                            {
                                Rate2Work wkRateWork = (Rate2Work)XmlByteSerializer.Deserialize(byteArray, typeof(Rate2Work));
                                if (wkRateWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRateWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�ꊇ�p�폜����( ���b�g����KEY�������珜�� )]
        /// <summary>
        /// �|���}�X�^�߂�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�|���}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�߂�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        public int DeleteRate(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRateSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.DeleteRate");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">�|���}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19<</br>
        public int DeleteRateSubSectionProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRateSubSectionProcProc(rateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">�|���}�X�^�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �|���}�X�^�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19<</br>
        private int DeleteRateSubSectionProcProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;
            command += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    Rate2Work rate2Work = rateWorkList[i] as Rate2Work;
                    sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    //SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                    findParaGoodsNo.Value = rate2Work.GoodsNo;
                    findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != rate2Work.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region �������f�[�^�̊|���ꊇ��������
        #region ���w�肳�ꂽ�����̏����|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�
        /// <summary>
        /// �����f�[�^�̊|���ꊇ��������
        /// </summary>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="rateParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/03/01</br>
        public int SearchPureRate(out object retGoodsMngList, out object retRateList,
            object rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retGoodsMngList = null;
            retRateList = null;
            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPureRateProc(out retGoodsMngList, out retRateList,
                    paraWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPureRate");
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();
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
        }
        #endregion  ���w�肳�ꂽ�����̏����|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�

        #region �������f�[�^���֏��i�Ǘ����Ɗ|�����擾����
        /// <summary>
        /// �����f�[�^���֏��i�Ǘ����Ɗ|�����擾����
        /// </summary>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �����f�[�^���֏��i�Ǘ����Ɗ|�����擾����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPureRateProc(out object retGoodsMngList, out object retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode, 
            ref SqlConnection sqlConnection)
        {
            StringBuilder sqlText = new StringBuilder();
            ArrayList tempGoodsMngList = new ArrayList(); // ���i�Ǘ����}�X�^��񃊃X�g
            ArrayList tempRateList = new ArrayList();     // �|���}�X�^��񃊃X�g

            // ���i�Ǘ���񌟍�
            int status1 = SearchGoodsMngSubProc(ref tempGoodsMngList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // �|����񌟍�
            int status2 = SearchRateSubProc(ref tempRateList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // �G���[�������̏ꍇ�A�X�e�[�^�X�߂�
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status1;
            }

            // �G���[�������̏ꍇ�A�X�e�[�^�X�߂�
            if ((status2 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status2;
            }

            // �������Ȃ��̏ꍇ�A�X�e�[�^�X�߂�
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                &&(status2 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                

                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            retGoodsMngList = tempGoodsMngList;
            retRateList = tempRateList;
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion �������f�[�^���֏��i�Ǘ����Ɗ|�����擾����

        #region �������f�[�^�̏��i�Ǘ����擾
        /// <summary>
        /// �����f�[�^�̏��i�Ǘ����擾
        /// </summary>
        /// <param name="retRateList">���i�Ǘ���񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �����f�[�^�̏��i�Ǘ����擾</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchGoodsMngSubProc(ref ArrayList retGoodsMngList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    SUPPLIERCDRF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMNGRF ").Append(Environment.NewLine);
                #region WHERE������
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, rateParamWork, 1, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retGoodsMngList.Add(CopyToPureSearchResultWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


            }
            catch (SqlException ex)
            {
                //�@���N���X�ɗ�O��n���ď������Ă��炤
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
        #endregion �������f�[�^�̏��i�Ǘ����擾

        #region �������f�[�^�̊|�����擾
        /// <summary>
        /// �����f�[�^�̊|�����擾
        /// </summary>
        /// <param name="retRateList">�����f�[�^�̊|����񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �����f�[�^�̊|�����擾</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchRateSubProc(ref ArrayList retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);

                #region WHERE������
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, rateParamWork, 0, logicalMode)).Append(Environment.NewLine);
                #endregion WHERE������

                #endregion Select���쐬

                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retRateList.Add(CopyToRate2WorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


            }
            catch (SqlException ex)
            {
                //�@���N���X�ɗ�O��n���ď������Ă��炤
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
        #endregion �������f�[�^�̊|�����擾
        /// <summary>
        /// �����p���������ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="selectDiv">�敪�|���}�X�^�����Ə��i�Ǘ����}�X�^���� 0: �|���}�X�^�����@1: ���i�Ǘ����}�X�^����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : �����p���������ݒ�</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPureCommon(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, 
            �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@int selectDiv, 
            �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    ENTERPRISECODERF=@FINDENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���_�R�[�h
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // �S�Ўw��̏ꍇ�A���O�C�����_���Q��
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }


            // ���i���[�J�[�R�[�h
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND GOODSMAKERCDRF =@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }

            // �i��
            retstring.Append("    AND GOODSNORF = '' ").Append(Environment.NewLine);
            // selectDiv=0: �|���}�X�^�����@selectDiv=1: ���i�Ǘ����}�X�^����
            if (selectDiv == 0)
            {
                // �d����R�[�h
                if (paraWork.SupplierCd != 0)
                {
                    retstring.Append("    AND SUPPLIERCDRF=@FINDSUPPLIERCD ").Append(Environment.NewLine);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
                }
                // ���Ӑ�R�[�h
                if (paraWork.CustomerCode != null)
                {
                    string CustomerCodeArystr = "";

                    foreach (int CustAry in paraWork.CustomerCode)
                    {
                        if (CustomerCodeArystr != "")
                        {
                            CustomerCodeArystr += ",";
                        }
                        CustomerCodeArystr += CustAry.ToString();
                    }
                    if (CustomerCodeArystr != "")
                    {
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  )AND CUSTOMERCODERF IN (" + CustomerCodeArystr
                                         + ") )AND CUSTRATEGRPCODERF = 0) OR (UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF = 0 ))");
                    }
                    retstring.Append(Environment.NewLine);
                }

                // ���Ӑ�|���O���[�v�R�[�h
                if (paraWork.CustRateGrpCode != null)
                {
                    string CustomerGrpCodeArystr = "";
                    foreach (int CustGrpAry in paraWork.CustRateGrpCode)
                    {
                        if (CustomerGrpCodeArystr != "")
                        {
                            CustomerGrpCodeArystr += ",";
                        }
                        CustomerGrpCodeArystr += CustGrpAry.ToString();
                    }
                    if (CustomerGrpCodeArystr != "")
                    {
                        // ���Ӑ�|���̖��ݒ�𒊏o�\�Ƃ���
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  ) AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr
                                         + "))  AND CUSTOMERCODERF = 0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))");
                    }
                    retstring.Append(Environment.NewLine);
                }
            }
            
            return retstring.ToString();
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���i�Ǘ����}�X�^�Ɏ擾�f�[�^</returns>
        /// <br>Note       : �N���X�i�[�����@Reader �� Rate2SearchResultWork</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPureSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

            #region �N���X�֊i�[
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.GoodsSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� Rate2Work
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�|���}�X�^�Ɍ����擾�f�[�^</returns>
        /// <br>Note       : �N���X�i�[�����@�N���X�i�[���� Reader �� Rate2Work</br>
        /// <br>Programmer : ���j��</br>
        /// <br>Date       : 2013/03/01</br>
        private Rate2Work CopyToRate2WorkFromReader(ref SqlDataReader myReader)
        {
            Rate2Work wkResultWork = new Rate2Work();

            #region �N���X�֊i�[
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkResultWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkResultWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkResultWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkResultWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkResultWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkResultWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkResultWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkResultWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkResultWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkResultWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkResultWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkResultWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            #endregion

            return wkResultWork;
        }
        #endregion �������f�[�^�̏ꍇ�A���i�Ǘ����Ɗ|�����擾����

        #region ���D�ǃf�[�^�̊|���ꊇ��������
        #region ���w�肳�ꂽ�����̗D�Ǌ|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�
        /// <summary>
        /// �D�ǃf�[�^�̊|���ꊇ��������
        /// </summary>
        /// <param name="retPrmSettingList">�D�ǐݒ��񃊃X�g</param>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="rateParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Date       : 2013/03/01</br>
        public int SearchPrmRate(out object retPrmSettingList, out object retGoodsMngList, out object retRateList,
            object rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retPrmSettingList = null;
            retGoodsMngList = null;
            retRateList = null;

            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPrmRateProc(out retPrmSettingList, out retGoodsMngList, out retRateList,
                    paraWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPrmRate");

                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

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
        }
        #endregion  ���w�肳�ꂽ�����̗D�Ǌ|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�

        #region ���D�ǃf�[�^���֏��i�Ǘ����Ɗ|�����擾����
        /// <summary>
        /// �D�ǃf�[�^���֏��i�Ǘ����Ɗ|�����擾����
        /// </summary>
        /// <param name="retPrmSettingList">�D�ǐݒ��񃊃X�g</param>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPrmRateProc(out object retPrmSettingList, out object retGoodsMngList, out object retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            StringBuilder sqlText = new StringBuilder();
            ArrayList tempPrmSettingList = new ArrayList(); // �D�ǐݒ�}�X�^��񃊃X�g
            ArrayList tempGoodsMngList = new ArrayList(); // ���i�Ǘ����}�X�^��񃊃X�g
            ArrayList tempRateList = new ArrayList();     // �|���}�X�^��񃊃X�g

            // �D�ǐݒ��񌟍�
            int status = SearchPrmSettingSubProc(ref tempPrmSettingList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // ���i�Ǘ���񌟍�
            int status1 = SearchGoodsMngSubProc1(ref tempGoodsMngList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // �|����񌟍�
            int status2 = SearchRateSubProc1(ref tempRateList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // �G���[�������̏ꍇ�A�X�e�[�^�X�߂�
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status;
            }

            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status1;
            }

            // �G���[�������̏ꍇ�A�X�e�[�^�X�߂�
            if ((status2 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status2;
            }

            // �������Ȃ��̏ꍇ�A�X�e�[�^�X�߂�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            retPrmSettingList = tempPrmSettingList;
            retGoodsMngList = tempGoodsMngList;
            retRateList = tempRateList;

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion ���D�ǃf�[�^���֏��i�Ǘ����Ɗ|�����擾����

        #region ���D�ǐݒ���擾
        /// <summary>
        /// �D�ǐݒ���擾
        /// </summary>
        /// <param name="retPrmSettingList">�D�ǐݒ��񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPrmSettingSubProc(ref ArrayList retPrmSettingList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    PRM.CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.TBSPARTSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.PARTSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODS.BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODS.BLGOODSHALFNAMERF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    PRMSETTINGURF AS PRM WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append(" LEFT JOIN BLGOODSCDURF AS GOODS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("    ON PRM.ENTERPRISECODERF = GOODS.ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("    AND PRM.TBSPARTSCODERF = GOODS.BLGOODSCODERF ").Append(Environment.NewLine);

                #region WHERE������
                sqlText.Append(MakeWhereSearchPrm(ref sqlCommand, rateParamWork, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retPrmSettingList.Add(CopyToPrmSettingWorkFromReader(ref myReader));

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
        #endregion ���D�ǐݒ���擾

        #region ���D�ǃf�[�^�̏��i�Ǘ����擾
        /// <summary>
        /// �D�ǃf�[�^�̏��i�Ǘ����擾
        /// </summary>
        /// <param name="retRateList">���i�Ǘ���񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchGoodsMngSubProc1(ref ArrayList retGoodsMngList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    SUPPLIERCDRF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMNGRF ").Append(Environment.NewLine);
                #region WHERE������
                sqlText.Append(MakeWhereSearchPrmCommon(ref sqlCommand, rateParamWork, 1, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retGoodsMngList.Add(CopyToPrmSearchResultWorkFromReader(ref myReader));

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
        #endregion ���D�ǃf�[�^�̏��i�Ǘ����擾

        #region ���D�ǃf�[�^�̊|�����擾
        /// <summary>
        /// �D�ǃf�[�^�̊|�����擾
        /// </summary>
        /// <param name="retRateList">�D�ǃf�[�^�̊|����񃊃X�g</param>
        /// <param name="rateParamWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchRateSubProc1(ref ArrayList retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);
                #region WHERE������
                sqlText.Append(MakeWhereSearchPrmCommon(ref sqlCommand, rateParamWork, 0, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retRateList.Add(CopyToPrmRate2WorkFromReader(ref myReader));

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
        #endregion ���D�ǃf�[�^�̊|�����擾

        /// <summary>
        /// �D�Ǘp���������ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="selectDiv">�敪�|���}�X�^�����Ə��i�Ǘ����}�X�^���� 0: �|���}�X�^�����@1: ���i�Ǘ����}�X�^����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPrm(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    PRM.ENTERPRISECODERF=@FINDPRMENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDPRMENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND PRM.LOGICALDELETECODERF=@FINDPRMLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND PRM.LOGICALDELETECODERF<@FINDPRMLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDPRMLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND PRM.SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // �S�Ўw��̏ꍇ�A���O�C�����_���Q��
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND PRM.SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }

            //���i���[�J�[�R�[�h
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND PRM.PARTSMAKERCDRF =@FINDPRMPARTSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@FINDPRMPARTSMAKERCD", SqlDbType.Int);
                paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }
            else
            {
                retstring.Append("    AND (PRM.PARTSMAKERCDRF > @FINDPRMPARTSMAKERCD OR PRM.PARTSMAKERCDRF = @FINDPRMPARTSMAKERCD)").Append(Environment.NewLine);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@FINDPRMPARTSMAKERCD", SqlDbType.Int);
                paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);
            }

            return retstring.ToString();
        }

        /// <summary>
        /// �D�Ǘp���������ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="selectDiv">�敪�|���}�X�^�����Ə��i�Ǘ����}�X�^���� 0: �|���}�X�^�����@1: ���i�Ǘ����}�X�^����</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPrmCommon(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, int selectDiv, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    ENTERPRISECODERF=@FINDENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // �S�Ўw��̏ꍇ�A���O�C�����_���Q��
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }

            //���i���[�J�[�R�[�h
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND GOODSMAKERCDRF =@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }
            else
            {
                retstring.Append("    AND (GOODSMAKERCDRF >@FINDGOODSMAKERCD OR GOODSMAKERCDRF =@FINDGOODSMAKERCD)").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);
            }

            //�i��
            retstring.Append("    AND GOODSNORF = '' ").Append(Environment.NewLine);

            //�d����R�[�h
            if (paraWork.SupplierCd != 0)
            {
                retstring.Append("    AND SUPPLIERCDRF=@FINDSUPPLIERCD ").Append(Environment.NewLine);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
            }

            // selectDiv=0: �|���}�X�^�����@selectDiv=1: ���i�Ǘ����}�X�^����
            if (selectDiv == 0)
            {
                // ���Ӑ�R�[�h
                if (paraWork.CustomerCode != null)
                {
                    string CustomerCodeArystr = "";
                    foreach (int CustAry in paraWork.CustomerCode)
                    {
                        if (CustomerCodeArystr != "")
                        {
                            CustomerCodeArystr += ",";
                        }
                        CustomerCodeArystr += CustAry.ToString();
                    }
                    if (CustomerCodeArystr != "")
                    {
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  )AND CUSTOMERCODERF IN (" + CustomerCodeArystr + ") )AND CUSTRATEGRPCODERF=0) OR (UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))").Append(Environment.NewLine);
                    }
                    retstring.Append(Environment.NewLine);
                }

                //���Ӑ�|���O���[�v�R�[�h
                if (paraWork.CustRateGrpCode != null)
                {
                    string CustomerGrpCodeArystr = "";
                    foreach (int CustGrpAry in paraWork.CustRateGrpCode)
                    {
                        if (CustomerGrpCodeArystr != "")
                        {
                            CustomerGrpCodeArystr += ",";
                        }
                        CustomerGrpCodeArystr += CustGrpAry.ToString();
                    }
                    if (CustomerGrpCodeArystr != "")
                    {
                        //���Ӑ�|���̖��ݒ�𒊏o�\�Ƃ���
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  ) AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr + "))  AND CUSTOMERCODERF=0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))").Append(Environment.NewLine);
                    }
                    retstring.Append(Environment.NewLine);
                }
            }

            return retstring.ToString();
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�D�ǐݒ���}�X�^�Ɏ擾�f�[�^</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPrmSettingWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

            #region �N���X�֊i�[
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkResultWork.BGBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkResultWork.GoodsSupplierCd = 0;
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���i�Ǘ����}�X�^�Ɏ擾�f�[�^</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPrmSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

            #region �N���X�֊i�[
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.GoodsSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� Rate2Work
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�|���}�X�^�Ɍ����擾�f�[�^</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2Work CopyToPrmRate2WorkFromReader(ref SqlDataReader myReader)
        {
            Rate2Work wkResultWork = new Rate2Work();

            #region �N���X�֊i�[
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkResultWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkResultWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkResultWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkResultWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkResultWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkResultWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkResultWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkResultWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkResultWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkResultWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkResultWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkResultWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            #endregion

            return wkResultWork;
        }
        #endregion ���D�ǃf�[�^�̏ꍇ�A�D�ǐݒ���Ə��i�Ǘ����Ɗ|�����擾����

        #region ���P�ꏤ�i���̊|����������
        public int SearchRate(out object retRateList,object rateParamWork, 
                              int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retRateList = null;
            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork; // ��������
            StringBuilder sqlText = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList tempRateList = new ArrayList();
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                #region Select���쐬
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);

                #region WHERE������
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, paraWork, 0, logicalMode)).Append(Environment.NewLine);
                if (paraWork.GoodsChangeMode == 0)
                {
                    // ���i�|���f
                    sqlText.Append("    AND GOODSRATEGRPCODERF =@FINDGOODSRATEGRPCODE ").Append(Environment.NewLine);
                    SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsRateGrpCode);
                    //�w��
                    sqlText.Append("    AND GOODSRATERANKRF = ' ' ").Append(Environment.NewLine);
                }
                else
                {
                    // ���i�|���f
                    sqlText.Append("    AND GOODSRATEGRPCODERF = 0 ").Append(Environment.NewLine);
                    //�w��
                    sqlText.Append("    AND GOODSRATERANKRF =@FINGOODSRATERANK ").Append(Environment.NewLine);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINGOODSRATERANK", SqlDbType.NChar);
                    paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(paraWork.GoodsRateRank);
                }
                 // �O���[�v�R�[�h
                sqlText.Append("    AND BLGROUPCODERF =@FINDBLGROUPCD ").Append(Environment.NewLine);
                SqlParameter paraBlGroupCd = sqlCommand.Parameters.Add("@FINDBLGROUPCD", SqlDbType.Int);
                paraBlGroupCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GroupCd);
                 // �a�k�R�[�h
                sqlText.Append("    AND BLGOODSCODERF =@FINDGOODSBLCD ").Append(Environment.NewLine);
                SqlParameter paraBlGoodsCd = sqlCommand.Parameters.Add("@FINDGOODSBLCD", SqlDbType.Int);
                paraBlGoodsCd.Value = SqlDataMediator.SqlSetInt32(paraWork.BlCd);
                #endregion WHERE������

                #endregion Select���쐬

                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tempRateList.Add(CopyToRate2WorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                retRateList = tempRateList;
                return status;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPureRate");
                retRateList = new ArrayList();
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
        }
        #endregion�@���P�ꏤ�i���̊|����������
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�G�N�X�|�[�gDB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �|���}�X�^�G�N�X�|�[�gDB�����[�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-**  �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12   �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMas �� RateText
//                                   StockMasWork �� RateTextWork
//                                   IStockMasDB �� IRateTextDB
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���}�X�^�G�N�X�|�[�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�G�N�X�|�[�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12 </br>
    /// <br></br>
    /// <br>Update Note: �|�����}�X�^�C���|�[�g�E�G�N�X�|�[�g�@�\�ǉ��Ή�</br>
    /// <br>Programmer : 30521 T.MOTOYAMA</br>
    /// <br>Date       : 2013.10.28</br>
    /// </remarks>
    [Serializable]
// --- CHG  2015/10/14 K.Miura --- >>>>
//  public class StockMasDB : RemoteDB, IStockMasDB
    public class RateTextDB : RemoteDB, IRateTextDB
// --- CHG  2015/10/14 K.Miura --- <<<<
    {
        /// <summary>
        /// �|���}�X�^�G�N�X�|�[�gDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      public StockMasDB()
//          : base("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.StockMasWork", "RATERF")
        public RateTextDB()
// --- CHG  2015/10/14 K.Miura --- <<<<
            : base("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.RateTextWork", "RATERF")
        {

        }

        # region [Search]
        /// <summary>
        /// �|���}�X�^�G�N�X�|�[�g�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outList">��������</param>
        /// <param name="paraWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀe�L�X�g�̃L�[�l����v����A�S�Ă̍݌Ƀe�L�X�g���׏����擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        public int Search(out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _stockMasList = null;
// --- CHG  2015/10/14 K.Miura --- >>>>
//          StockMasWork stockMasWork = null;
//          StockMasWork stockMasWorkSt = null;
//          StockMasWork stockMasWorkEd = null;
            RateTextWork rateTextWork = null;
            RateTextWork rateTextWorkSt = null;
            RateTextWork rateTextWorkEd = null;
// --- CHG  2015/10/14 K.Miura --- <<<<

            outList = new CustomSerializeArrayList();

            try
            {
// --- CHG  2015/10/14 K.Miura --- >>>>
//              if (paraWork is StockMasWork)
//              {
//                  stockMasWork = paraWork as StockMasWork;
                if (paraWork is RateTextWork)
                {
                    rateTextWork = paraWork as RateTextWork;

                }
// --- CHG  2015/10/14 K.Miura --- <<<<
                else if (paraWork is ArrayList)
                {
                    if ((paraWork as ArrayList).Count > 0)
                    {
// --- CHG  2015/10/14 K.Miura --- >>>>
//                      stockMasWorkSt = (paraWork as ArrayList)[0] as StockMasWork;
//                      stockMasWorkEd = (paraWork as ArrayList)[1] as StockMasWork;
                        rateTextWorkSt = (paraWork as ArrayList)[0] as RateTextWork;
                        rateTextWorkEd = (paraWork as ArrayList)[1] as RateTextWork;
// --- CHG  2015/10/14 K.Miura --- <<<<

                    }
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _stockMasList, rateTextWorkSt, rateTextWorkEd, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);


                if (_stockMasList != null)
                {
                    (outList as CustomSerializeArrayList).AddRange(_stockMasList);
                }


            }
            catch (Exception ex)
            {
// --- CHG  2015/10/14 K.Miura --- >>>>
//              base.WriteErrorLog(ex, "StockMasDB.Search(out object, object, int, LogicalMode)", status);
                base.WriteErrorLog(ex, "RateTextDB.Search(out object, object, int, LogicalMode)", status);
// --- CHG  2015/10/14 K.Miura --- <<<<
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
        /// �|���}�X�^�G�N�X�|�[�g�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="stockMasList">�|���}�X�^�G�N�X�|�[�g���i�[���� ArrayList</param>
        /// <param name="paraWorkSt">���������i�J�n�j</param>
        /// <param name="paraWorkEd">���������i�I���j</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�̃L�[�l����v����A�S�Ă̊|���}�X�^�G�N�X�|�[�g���e���i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      public int Search(out ArrayList stockMasList, StockMasWork paraWorkSt, StockMasWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int Search(out ArrayList rateTextList, RateTextWork paraWorkSt, RateTextWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
// --- CHG  2015/10/14 K.Miura --- <<<<
        {
            return this.SearchProc(out rateTextList, paraWorkSt, paraWorkEd, readMode, logicalMode, false, ref sqlConnection, ref sqlTransaction);
        }


        /// <summary>
        /// �݌Ƀe�L�X�g���׏��̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="stockMasList">�݌Ƀe�L�X�g���׏����i�[���� ArrayList</param>
        /// <param name="paraWorkSt">���������i�J�n�j</param>
        /// <param name="paraWorkEd">���������i�I���j</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="isSearchPayeeWithChildren"></param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�̃L�[�l����v����A�S�Ă̊|���}�X�^�G�N�X�|�[�g���e���i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      private int SearchProc(out ArrayList stockMasList, StockMasWork paraWorkSt, StockMasWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int SearchProc(out ArrayList rateTextList, RateTextWork paraWorkSt, RateTextWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
// --- CHG  2015/10/14 K.Miura --- <<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                // �f�[�^�擾����ׂ�SQL�R�l�N�V�����𐶐��擾
                sqlConnection = this.CreateSqlConnection(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 600;
                // READ UNCOMMITTED�̐ݒ�
                sqlCommand.Transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);

                # region [SELECT��]
                StringBuilder sqlString = new StringBuilder();
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("     SECTIONCODERF");
                sqlString.AppendLine("    ,UNITRATESETDIVCDRF");
                sqlString.AppendLine("    ,UNITPRICEKINDRF");
                sqlString.AppendLine("    ,RATESETTINGDIVIDERF");
                sqlString.AppendLine("    ,RATEMNGGOODSCDRF");
                sqlString.AppendLine("    ,RATEMNGGOODSNMRF");
                sqlString.AppendLine("    ,RATEMNGCUSTCDRF");
                sqlString.AppendLine("    ,RATEMNGCUSTNMRF");
                sqlString.AppendLine("    ,GOODSMAKERCDRF");
                sqlString.AppendLine("    ,GOODSNORF");
                sqlString.AppendLine("    ,GOODSRATERANKRF");
                sqlString.AppendLine("    ,GOODSRATEGRPCODERF");
                sqlString.AppendLine("    ,BLGROUPCODERF");
                sqlString.AppendLine("    ,BLGOODSCODERF");
                sqlString.AppendLine("    ,CUSTOMERCODERF");
                sqlString.AppendLine("    ,CUSTRATEGRPCODERF");
                sqlString.AppendLine("    ,SUPPLIERCDRF");
                sqlString.AppendLine("    ,LOTCOUNTRF");
                sqlString.AppendLine("    ,PRICEFLRF");
                sqlString.AppendLine("    ,RATEVALRF");
                sqlString.AppendLine("    ,UPRATERF");
                sqlString.AppendLine("    ,GRSPROFITSECURERATERF");
                sqlString.AppendLine("    ,UNPRCFRACPROCUNITRF");
                sqlString.AppendLine("    ,UNPRCFRACPROCDIVRF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("    RATERF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	      ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	  AND (LOGICALDELETECODERF = @LOGICALDELETECODERF)");   // Add T.MOTOYAMA 2013.10.28
                sqlString.AppendLine("	  AND (@SECTIONST IS NULL OR SECTIONCODERF >= @SECTIONST)");
                sqlString.AppendLine("    AND (@SECTIONED IS NULL OR SECTIONCODERF <= @SECTIONED)");
                sqlString.AppendLine("    AND (@UNITPRICEKIND IS NULL OR UNITPRICEKINDRF = @UNITPRICEKIND)");
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	SECTIONCODERF, UNITPRICEKINDRF");
                sqlCommand.CommandText = sqlString.ToString();

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode  = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);   // Add T.MOTOYAMA 2013.10.28
                SqlParameter findSectionCodeSt   = sqlCommand.Parameters.Add("@SECTIONST", SqlDbType.NChar);
                SqlParameter findSectionCodeEd   = sqlCommand.Parameters.Add("@SECTIONED", SqlDbType.NChar);
                SqlParameter findWarehouseCodeSt = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value  = SqlDataMediator.SqlSetString(paraWorkSt.EnterpriseCode);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(readMode);
                // findSectionCodeSt.Value   = SqlDataMediator.SqlSetString(paraWorkSt.SectionCode.PadLeft(2, '0'));  // Del T.MOTOYAMA 2013.10.28
                findSectionCodeSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.SectionCode);                       // Add T.MOTOYAMA 2013.10.28
                findSectionCodeEd.Value   = SqlDataMediator.SqlSetString(paraWorkEd.SectionCode);
                findWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.WarehouseCd);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToStockMasWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
// --- CHG  2015/10/14 K.Miura --- >>>>
//              status = base.WriteSQLErrorLog(ex, "StockMasDB.Search(out ArrayList, StockMasWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
                status = base.WriteSQLErrorLog(ex, "RateTextDB.Search(out ArrayList, RateTextWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
// --- CHG  2015/10/14 K.Miura --- <<<<
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

            rateTextList = al;

            return status;
        }
        # endregion

        #region Write Add 2013.10.28 t.MOTOYAMA
        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�(�|�����}�X�^ �C���|�[�g�E�G�N�X�|�[�g�p)
        /// </summary>
        /// <param name="rateWork">RateWork�I�u�W�F�N�g</param>
        /// <param name="writestatus">�X�V�����@1:�ǉ��@2:�X�V�@3:�ǉ��{�X�V</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        public int Write(ref object rateWork, int writestatus)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(rateWork);
                if (paraList == null) return status;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSubSectionProc(ref paraList, writestatus, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                rateWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IRateTextDB.Write(ref object rateWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">RateWork�I�u�W�F�N�g</param>
        /// <param name="writestatus">�X�V�����@1:�ǉ��@2:�X�V�@3:�ǉ��{�X�V</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        private int WriteSubSectionProc(ref ArrayList rateWorkList, int writestatus, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            // CREATEDATETIME��FILEHEADERGUIDRF�̓f�[�^�Z�b�g�p�Ɏ擾����
            string command = string.Empty;
            command = "SELECT CREATEDATETIMERF, FILEHEADERGUIDRF FROM RATERF" + Environment.NewLine;
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
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        RateWork rateWork = rateWorkList[i] as RateWork;

                        //Select�R�}���h�̐���
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
                        SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //�X�V�������u2:�X�V�@3:�ǉ��{�X�V�v�̏ꍇ�A�X�V���s��
                            if (writestatus == 2 || writestatus == 3)
                            {
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
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                                findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                                findParaGoodsNo.Value = rateWork.GoodsNo;
                                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                                findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                                //�X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                // �쐬������GUID�͂����ŃZ�b�g����
                                DateTime createDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
                                rateWork.CreateDateTime = createDateTime;
                                Guid guid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                       //GUID
                                rateWork.FileHeaderGuid = guid;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                break;
                            }
                        }
                        else
                        {
                            //�X�V�������u1:�ǉ��@3:�ǉ��{�X�V�v�̏ꍇ�A�ǉ����s��
                            if (writestatus == 1 || writestatus == 3)
                            {
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
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                break;
                            }
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
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        paraGoodsNo.Value = rateWork.GoodsNo;
                        paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rateWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
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
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RateTextWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateTextWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      private StockMasWork CopyToStockMasWorkFromReader(ref SqlDataReader myReader)
        private RateTextWork CopyToStockMasWorkFromReader(ref SqlDataReader myReader)
// --- CHG  2015/10/14 K.Miura --- <<<<
        {
// --- CHG  2015/10/14 K.Miura --- >>>>
//          StockMasWork outWork = new StockMasWork();
            RateTextWork outWork = new RateTextWork();
// --- CHG  2015/10/14 K.Miura --- <<<<

            this.CopyToStockMasWorkFromReader(ref myReader, ref outWork);

            return outWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� RateTextWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="outWork">RateTextWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
        private void CopyToStockMasWorkFromReader(ref SqlDataReader myReader, ref RateTextWork outWork)
        {

            if (myReader != null && outWork != null)
            {
                # region �N���X�֊i�[
                outWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();             // ���_�R�[�h
                outWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF")).Trim();   // �P���|���ݒ�敪
                outWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF")).Trim();         // �P�����
                outWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF")).Trim(); // �|���ݒ�敪
                outWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF")).Trim();       // �|���ݒ�敪(���i)
                outWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF")).Trim();       // �|���ݒ薼��(���i)
                outWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF")).Trim();         // �|���ݒ�敪(���Ӑ�)
                outWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF")).Trim();         // �|���ݒ薼��(���Ӑ�)
                outWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                   // ���i���[�J�[�R�[�h
                outWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF")).Trim();                     // ���i�ԍ�
                outWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF")).Trim();         // ���i�|�������N
                outWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));           // ���i�|���O���[�v�R�[�h
                outWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));                     // BL�O���[�v�R�[�h
                outWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));                     // BL���i�R�[�h
                outWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                   // ���Ӑ�R�[�h
                outWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));             // ���Ӑ�|���O���[�v�R�[�h
                outWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                       // �d����R�[�h
                outWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));                          // ���b�g��
                outWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));                            // ���i(����)
                outWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));                            // �|��
                outWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));                              // UP��
                outWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));    // �e���m�ۗ�
                outWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));        // �P���[�������P��
                outWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));           // �P���[�������敪
                # endregion
            }
        }
        # endregion

        # region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
// --- CHG  2015/10/14 K.Miura --- >>>>
//          StockMasWork[] outWorkArray = null;
            RateTextWork[] outWorkArray = null;
// --- CHG  2015/10/14 K.Miura --- <<<<

            if (paraobj != null)
                try
                {
                    // ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    // �p�����[�^�N���X�̏ꍇ
                    if (paraobj is RateTextWork)
                    {
// --- CHG  2015/10/14 K.Miura --- >>>>
//                      StockMasWork outWork = paraobj as StockMasWork;
                        RateTextWork outWork = paraobj as RateTextWork;
// --- CHG  2015/10/14 K.Miura --- <<<<
                        if (outWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(outWork);
                        }
                    }

                    // byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
// --- CHG  2015/10/14 K.Miura --- >>>>
//                          outWorkArray = (StockMasWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockMasWork[]));
                            outWorkArray = (RateTextWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RateTextWork[]));
// --- CHG  2015/10/14 K.Miura --- <<<<
                        }
                        catch (Exception) { }
                        if (outWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(outWorkArray);
                        }
                        else
                        {
                            try
                            {
// --- CHG  2015/10/14 K.Miura --- >>>>
//                              StockMasWork wkStockMasWork = (StockMasWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockMasWork));
                                RateTextWork wkStockMasWork = (RateTextWork)XmlByteSerializer.Deserialize(byteArray, typeof(RateTextWork));
// --- CHG  2015/10/14 K.Miura --- <<<<
                                if (wkStockMasWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockMasWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    // �p�����[�^�N���X�̏ꍇ
                    if (paraobj is RateWork)
                    {
                        RateWork outWork = paraobj as RateWork;
                        if (outWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(outWork);
                        }
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

                }
                catch (Exception)
                {
                    // ���ɉ������Ȃ�
                }

            return retal;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
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
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12 </br>
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

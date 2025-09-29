//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�R���o�[�g
// �v���O�����T�v   : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪���A�o�׉\�����X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/08/26  �C�����e : �A��No.1016 �V�K�쐬
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
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�R���o�[�g�c�[��READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�R���o�[�g�c�[��READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/08/26</br>
    /// </remarks>
    [Serializable]
    public class StockConvertDB : RemoteDB, IStockConvertDB
    {
        #region �� �݌Ƀ}�X�^�R���o�[�g���� ��
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g�c�[���̏���
        /// </summary>
        /// <param name="stockConvertWorkObj">�݌Ƀ}�X�^�R���o�[�g�N���X���[�N</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�@��������</param>
        /// <param name="stockAcPayHistCount">�݌Ɏ󕥗����f�[�^�@��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�R���o�[�g�������s���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public int ConvertShipmentPosCnt(object stockConvertWorkObj, out int stockCount, out int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;


            StockConvertWork stockConvertWork = (StockConvertWork)stockConvertWorkObj;

            stockCount = 0;
            stockAcPayHistCount = 0;
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                // SqlTransaction��������
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // �݌Ƀ}�X�^�R���o�[�g�c�[���̉�ʌ�������
                status = ConvertShipmentPosCntProc(stockConvertWork, out stockCount, out stockAcPayHistCount, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    stockCount = 0;
                    stockAcPayHistCount = 0;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "StockConvertDB.ConvertShipmentPosCnt", sqlex.Number);
            }
            catch (Exception ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCnt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �� �݌Ƀ}�X�^�R���o�[�g����Proc ��
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g����Proc
        /// </summary>
        /// <param name="stockConvertWork">�݌Ƀ}�X�^�R���o�[�g�N���X���[�N</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�@��������</param>
        /// <param name="stockAcPayHistCount">�݌Ɏ󕥗����f�[�^�@��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�R���o�[�g����Proc���s���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int ConvertShipmentPosCntProc(StockConvertWork stockConvertWork, out int stockCount, out int stockAcPayHistCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockCount = 0;
            stockAcPayHistCount = 0;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            try
            {
                StringBuilder sb = new StringBuilder();
                // Select�R�}���h�̐���
                sb.Append(" SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF");
                sb.Append(" FROM STOCKRF ");
                sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPODRCOUNTRF != @FINDACPODRCOUNT ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcpOdrCount = sqlCommand.Parameters.Add("@FINDACPODRCOUNT", SqlDbType.Float);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = stockConvertWork.EnterpriseCode;
                findParaAcpOdrCount.Value = 0;

                sqlCommand.CommandText = sb.ToString();
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                ArrayList resultList = new ArrayList();
                while (myReader.Read())
                {
                    StockWork stWork = new StockWork();
                    stWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));

                    resultList.Add(stWork);
                }

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                foreach (StockWork stWork in resultList)
                {
                    // �݌Ƀ}�X�^�X�V����
                    status = this.UpdateStock(stockConvertWork, stWork, ref stockCount, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �݌Ɏ󕥗����f�[�^�X�V����
                        status = this.UpdateStockAcPayHist(stockConvertWork, stWork, ref stockAcPayHistCount, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCntProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCntProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        /// <summary>
        /// �݌Ƀ}�X�^�X�V����
        /// </summary>
        /// <param name="stockConvertWork">�݌Ƀ}�X�^�R���o�[�g�N���X���[�N</param>
        /// <param name="stWork"> �݌Ƀ}�X�^���[�N</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�@��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�X�V���s���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int UpdateStock(StockConvertWork stockConvertWork, StockWork stWork, ref int stockCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                //Update�R�}���h�̐���
                if (stockConvertWork.PreStckCntDspDiv == 0)
                {
                    // ���݌ɕ\���敪�́u0:�󒍕��܂ށv
                    // �o�׉\��(ShipmentPosCntRF)���d���݌ɐ��{���א��|�o�א��|�󒍐��|�ړ�����
                    sqlCommand = new SqlCommand("UPDATE STOCKRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + ARRIVALCNTRF - SHIPMENTCNTRF - ACPODRCOUNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO", sqlConnection, sqlTransaction);
                }
                else
                {
                    // ���݌ɕ\���敪�́u1:�󒍕��܂܂Ȃ��v
                    // �o�׉\��(ShipmentPosCntRF)���d���݌ɐ��{���א��|�o�א��|�ړ�����
                    sqlCommand = new SqlCommand("UPDATE STOCKRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + ARRIVALCNTRF - SHIPMENTCNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO", sqlConnection, sqlTransaction);
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stWork.LogicalDeleteCode);

                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = stWork.EnterpriseCode;
                findParaWarehouseCode.Value = stWork.WarehouseCode;
                findParaGoodsMakerCd.Value = stWork.GoodsMakerCd;
                findParaGoodsNo.Value = stWork.GoodsNo;

                int count = sqlCommand.ExecuteNonQuery();
                stockCount = stockCount + count;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.UpdateStock" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^�X�V����
        /// </summary>
        /// <param name="stockConvertWork">�݌Ƀ}�X�^�R���o�[�g�N���X���[�N</param>
        /// <param name="stWork"> �݌Ƀ}�X�^���[�N</param>
        /// <param name="stockAcPayHistCount">�݌Ɏ󕥗����f�[�^�@��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɏ󕥗����f�[�^�X�V���s���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int UpdateStockAcPayHist(StockConvertWork stockConvertWork, StockWork stWork, ref int stockAcPayHistCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                //Update�R�}���h�̐���
                if (stockConvertWork.PreStckCntDspDiv == 0)
                {
                    // ���݌ɕ\���敪�́u0:�󒍕��܂ށv
                    // �o�׉\��(ShipmentPosCntRF)���d���݌ɐ��{���א��|�o�א��|�󒍐��|�ړ�����
                    sqlCommand = new SqlCommand("UPDATE STOCKACPAYHISTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + NONADDUPARRGDSCNTRF - NONADDUPSHIPMCNTRF - ACPODRCOUNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND ACPODRCOUNTRF <> 0", sqlConnection, sqlTransaction);
                }
                else
                {
                    // ���݌ɕ\���敪�́u1:�󒍕��܂܂Ȃ��v
                    // �o�׉\��(ShipmentPosCntRF)���d���݌ɐ��{���א��|�o�א��|�ړ�����
                    sqlCommand = new SqlCommand("UPDATE STOCKACPAYHISTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + NONADDUPARRGDSCNTRF - NONADDUPSHIPMCNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND ACPODRCOUNTRF <> 0", sqlConnection, sqlTransaction);
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.UpdateDateTime);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stWork.LogicalDeleteCode);

                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = stWork.EnterpriseCode;
                findParaGoodsMakerCd.Value = stWork.GoodsMakerCd;
                findParaGoodsNo.Value = stWork.GoodsNo;
                findParaWarehouseCode.Value = stWork.WarehouseCode;

                int count = sqlCommand.ExecuteNonQuery();
                stockAcPayHistCount = stockAcPayHistCount + count;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.UpdateStockAcPayHist" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }


        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
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
        /// <param name="sqlConnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        #endregion
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class OrderPointStDB : RemoteDB, IOrderPointStDB
    {
        /// <summary>
        /// �����_�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public OrderPointStDB()
            : base("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork", "OrderPointStRF")
        {

        }

        # region [Search]
        /// <summary>
        /// �����_�ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">��������</param>
        /// <param name="paraOrderPointStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^�̃L�[�l����v����A�S�Ă̔����_�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int Search(out object outOrderPointStList, object paraOrderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _orderPointStList = null;
            OrderPointStWork orderPointStWork = null;

            outOrderPointStList = new CustomSerializeArrayList();

            try
            {
                orderPointStWork = paraOrderPointStWork as OrderPointStWork;
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchProc(out _orderPointStList, orderPointStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outOrderPointStList = _orderPointStList;

            return status;
        }

        /// <summary>
        /// �����_�ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">��������</param>
        /// <param name="orderPointStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^�̃L�[�l����v����A�S�Ă̔����_�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int SearchProc(out ArrayList outOrderPointStList, OrderPointStWork orderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PATTERNORF, PATTERNNODERIVEDNORF, WAREHOUSECODERF, SUPPLIERCDRF, GOODSMAKERCDRF, GOODSMGROUPRF, BLGROUPCODERF, BLGOODSCODERF, STCKSHIPMONTHSTRF, STCKSHIPMONTHEDRF, ORDERAPPLYDIVRF, STOCKCREATEDATERF, SHIPSCOPEMORERF, SHIPSCOPELESSRF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, SALESORDERUNITRF, ORDERPPROCUPDFLGRF" + Environment.NewLine;
                sqlText += "FROM ORDERPOINTSTRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO" + Environment.NewLine;
                sqlText += "ORDER BY PATTERNNODERIVEDNORF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                findParaPatterNo.Value = orderPointStWork.PatterNo;

                sqlCommand.CommandText += sqlText;

                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToOrderPointStWorkFromReader(ref myReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OrderPointStDB.SearchProc" + status);
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

            outOrderPointStList = al;

            return status;
        }
        # endregion

        # region [Write]

        /// <summary>
        /// �����_�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStWorkList">OrderPointStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int Write(ref object objOrderPointStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList orderPointStWorkList = objOrderPointStWorkList as ArrayList;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(ref orderPointStWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStDB.Write", status);
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

            //�߂�l�Z�b�g
            objOrderPointStWorkList = orderPointStWorkList;

            return status;
        }

        /// <summary>
        /// �����_�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStWorkList">�����_�ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int WriteProc(ref ArrayList orderPointStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList= new ArrayList();

            try
            {
                string sqlText = string.Empty;

                // ��ʂ̓��̓f�[�^�̏���
                for (int index = 0; index < orderPointStWorkList.Count; index++)
                {
                    OrderPointStWork orderPointStWork = orderPointStWorkList[index] as OrderPointStWork;

                    using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                        SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            DateTime comUpDateTime = orderPointStWork.UpdateDateTime;

                            // �r���`�F�b�N
                            if (_updateDateTime != comUpDateTime)
                            {
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ORDERPOINTSTRF " + Environment.NewLine;
                            sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PATTERNORF=@PATTERNO , PATTERNNODERIVEDNORF=@PATTERNNODERIVEDNO , WAREHOUSECODERF=@WAREHOUSECODE , SUPPLIERCDRF=@SUPPLIERCD , GOODSMAKERCDRF=@GOODSMAKERCD , GOODSMGROUPRF=@GOODSMGROUP , BLGROUPCODERF=@BLGROUPCODE , BLGOODSCODERF=@BLGOODSCODE , STCKSHIPMONTHSTRF=@STCKSHIPMONTHST , STCKSHIPMONTHEDRF=@STCKSHIPMONTHED , ORDERAPPLYDIVRF=@ORDERAPPLYDIV , STOCKCREATEDATERF=@STOCKCREATEDATE , SHIPSCOPEMORERF=@SHIPSCOPEMORE , SHIPSCOPELESSRF=@SHIPSCOPELESS , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT , SALESORDERUNITRF=@SALESORDERUNIT , ORDERPPROCUPDFLGRF=@ORDERPPROCUPDFLG " + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                            findParaPatterNo.Value = orderPointStWork.PatterNo;
                            findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)orderPointStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (orderPointStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�@��ʂ̃f�[�^�Ainsert����
                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO ORDERPOINTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PATTERNORF, PATTERNNODERIVEDNORF, WAREHOUSECODERF, SUPPLIERCDRF, GOODSMAKERCDRF, GOODSMGROUPRF, BLGROUPCODERF, BLGOODSCODERF, STCKSHIPMONTHSTRF, STCKSHIPMONTHEDRF, ORDERAPPLYDIVRF, STOCKCREATEDATERF, SHIPSCOPEMORERF, SHIPSCOPELESSRF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, SALESORDERUNITRF, ORDERPPROCUPDFLGRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PATTERNO, @PATTERNNODERIVEDNO, @WAREHOUSECODE, @SUPPLIERCD, @GOODSMAKERCD, @GOODSMGROUP, @BLGROUPCODE, @BLGOODSCODE, @STCKSHIPMONTHST, @STCKSHIPMONTHED, @ORDERAPPLYDIV, @STOCKCREATEDATE, @SHIPSCOPEMORE, @SHIPSCOPELESS, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @SALESORDERUNIT, @ORDERPPROCUPDFLG)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)orderPointStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraPatterNo = sqlCommand.Parameters.Add("@PATTERNO", SqlDbType.Int);
                        SqlParameter paraPatternNoDerivedNo = sqlCommand.Parameters.Add("@PATTERNNODERIVEDNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraStckShipMonthSt = sqlCommand.Parameters.Add("@STCKSHIPMONTHST", SqlDbType.Int);
                        SqlParameter paraStckShipMonthEd = sqlCommand.Parameters.Add("@STCKSHIPMONTHED", SqlDbType.Int);
                        SqlParameter paraOrderApplyDiv = sqlCommand.Parameters.Add("@ORDERAPPLYDIV", SqlDbType.Int);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraShipScopeMore = sqlCommand.Parameters.Add("@SHIPSCOPEMORE", SqlDbType.Float);
                        SqlParameter paraShipScopeLess = sqlCommand.Parameters.Add("@SHIPSCOPELESS", SqlDbType.Float);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraOrderPProcUpdFlg = sqlCommand.Parameters.Add("@ORDERPPROCUPDFLG", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(orderPointStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.LogicalDeleteCode);
                        paraPatterNo.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.PatterNo);
                        paraPatternNoDerivedNo.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.PatternNoDerivedNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.WarehouseCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.SupplierCd);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.GoodsMakerCd);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.BLGoodsCode);
                        paraStckShipMonthSt.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StckShipMonthSt);
                        paraStckShipMonthEd.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StckShipMonthEd);
                        paraOrderApplyDiv.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.OrderApplyDiv);
                        paraStockCreateDate.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.StockCreateDate);
                        paraShipScopeMore.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.ShipScopeMore);
                        paraShipScopeLess.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.ShipScopeLess);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(orderPointStWork.MaximumStockCnt);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.SalesOrderUnit);
                        paraOrderPProcUpdFlg.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.OrderPProcUpdFlg);

                        sqlCommand.ExecuteNonQuery();

                        ayList.Add(orderPointStWork);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "OrderPointStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OrderPointStDB.Write" + status);
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

            orderPointStWorkList = ayList;

            return status;
        }
        # endregion

        #region [LogicalDelete]
        /// <summary>
        /// �����_�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">OrderPointWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int LogicalDelete(ref object objOrderPointStList)
        {
            return LogicalDelete(ref objOrderPointStList, 1);
        }

        /// <summary>
        /// �_���폜�����_�ݒ�}�X�^�����𕜊����܂�
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�����_�ݒ�}�X�^�����𕜊����܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object objOrderPointStList)
        {
            return LogicalDelete(ref objOrderPointStList, 0);
        }

        /// <summary>
        /// �����_�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">OrderPointStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int LogicalDelete(ref object objOrderPointStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList orderPointStWorkList = objOrderPointStList as ArrayList;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = LogicalDeleteProc(ref orderPointStWorkList, procMode, ref sqlConnection, ref sqlTransaction);

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
                string procModestr = "";
                if (procMode == 1)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// �����_�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStWorkList">orderPointStWork�I�u�W�F�N�g</param>
        /// <param name="deleteMode">�֐��敪 1:�_���폜 0:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int LogicalDeleteProc(ref ArrayList orderPointStWorkList, int deleteMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < orderPointStWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    OrderPointStWork orderPointStWork = orderPointStWorkList[i] as OrderPointStWork;

                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                    SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                    findParaPatterNo.Value = orderPointStWork.PatterNo;
                    findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != orderPointStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE ORDERPOINTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)orderPointStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();

                    //�_���폜���[�h�̏ꍇ
                    if (deleteMode == 1)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) orderPointStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else orderPointStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) orderPointStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                            sqlCommand.Cancel();
                            return status;
                        }
                    }

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orderPointStWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orderPointStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orderPointStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }
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
                base.WriteErrorLog(ex, "OrderPointStDB.Write" + status);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        #region [Delete]
        /// <summary>
        /// �����_�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="objOrderPointStList">OrderPointStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Delete(ref object objOrderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList orderPointStWorkList = objOrderPointStList as ArrayList;

                status = DeleteProc(orderPointStWorkList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
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
        /// �����_�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="orderPointStWorkList">�����_�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int DeleteProc(ArrayList orderPointStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                for (int i = 0; i < orderPointStWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    OrderPointStWork orderPointStWork = orderPointStWorkList[i] as OrderPointStWork;

                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM ORDERPOINTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO  AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPatterNo = sqlCommand.Parameters.Add("@FINDPATTERNO", SqlDbType.Int);
                    SqlParameter findPatternNoDerivedNo = sqlCommand.Parameters.Add("@FINDPATTERNNODERIVEDNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                    findParaPatterNo.Value = orderPointStWork.PatterNo;
                    findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != orderPointStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // �f�[�^�͑S�č폜
                        # region [DELETE��]
                        sqlText = string.Empty;
                        sqlText += "DELETE FROM ORDERPOINTSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PATTERNORF=@FINDPATTERNO AND PATTERNNODERIVEDNORF=@FINDPATTERNNODERIVEDNO";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = orderPointStWork.EnterpriseCode;
                        findParaPatterNo.Value = orderPointStWork.PatterNo;
                        findPatternNoDerivedNo.Value = orderPointStWork.PatternNoDerivedNo;
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSetWork</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private OrderPointStWork CopyToOrderPointStWorkFromReader(ref SqlDataReader myReader)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            if (myReader != null && orderPointStWork != null)
            {
                # region �N���X�֊i�[
                orderPointStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                orderPointStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                orderPointStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                orderPointStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                orderPointStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                orderPointStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                orderPointStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                orderPointStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                orderPointStWork.PatterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNORF"));
                orderPointStWork.PatternNoDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNNODERIVEDNORF"));
                orderPointStWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                orderPointStWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                orderPointStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                orderPointStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                orderPointStWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                orderPointStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                orderPointStWork.StckShipMonthSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHSTRF"));
                orderPointStWork.StckShipMonthEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHEDRF"));
                orderPointStWork.OrderApplyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERAPPLYDIVRF"));
                orderPointStWork.StockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                orderPointStWork.ShipScopeMore = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPEMORERF"));
                orderPointStWork.ShipScopeLess = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPELESSRF"));
                orderPointStWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                orderPointStWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                orderPointStWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                orderPointStWork.OrderPProcUpdFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERPPROCUPDFLGRF"));
                # endregion
            }
            return orderPointStWork;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
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

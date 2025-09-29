//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   :�\���敪�}�X�^�����e�i���X
// �v���O�����T�v   :�\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///�\���敪�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       :�\���敪�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PriceSelectSetDB : RemoteDB, IPriceSelectSetDB
    {
        /// <summary>
        ///�\���敪�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        public PriceSelectSetDB()
            : base("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork", "PRICESELECTSET")
        {

        }

        # region [Delete]
        /// <summary>
        ///�\���敪�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">PriceSelectSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        public int Delete(ref object parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {

                PriceSelectSetWork priceSelectSetWork = parabyte as PriceSelectSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(ref priceSelectSetWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.Delete", status);
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
        ///�\���敪�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="priceSelectSetWork">�I�[�g�o�b�N�X�ݒ�}�X�^��� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private int DeleteProc(ref PriceSelectSetWork priceSelectSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE��]
                        sqlText = "DELETE FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

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
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.DeleteProc", status);
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

        # region [Search]
        /// <summary>
        ///�\���敪�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outPriceSelectSetList">��������</param>
        /// <param name="paraPriceSelectSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        public int Search(out object outPriceSelectSetList, object paraPriceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _priceSelectSetgList = null;
            PriceSelectSetWork priceSelectSetWork = null;

            outPriceSelectSetList = new CustomSerializeArrayList();

            try
            {
                priceSelectSetWork = paraPriceSelectSetWork as PriceSelectSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = this.SearchProc(out _priceSelectSetgList, priceSelectSetWork, readMode, logicalMode, ref sqlConnection);

                if (_priceSelectSetgList != null)
                {
                    (outPriceSelectSetList as CustomSerializeArrayList).AddRange(_priceSelectSetgList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///�\���敪�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="priceSelectSetList">��������</param>
        /// <param name="priceSelectSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private int SearchProc(out ArrayList priceSelectSetList, PriceSelectSetWork priceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // �R�l�N�V��������
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append(" SELECT ");
                sqlText.Append(" A.CREATEDATETIMERF, ");      // �쐬����
                sqlText.Append(" A.ENTERPRISECODERF, ");      // ��ƃR�[�h
                sqlText.Append(" A.FILEHEADERGUIDRF, ");      // GUID
                sqlText.Append(" A.UPDEMPLOYEECODERF, ");     // �X�V�]�ƈ��R�[�h
                sqlText.Append(" A.UPDASSEMBLYID1RF, ");      // �X�V�A�Z���u��ID1
                sqlText.Append(" A.UPDASSEMBLYID2RF, ");      // �X�V�A�Z���u��ID2
                sqlText.Append(" A.UPDATEDATETIMERF, ");      // �X�V����
                sqlText.Append(" A.LOGICALDELETECODERF, ");   // �_���폜�敪
                sqlText.Append(" A.PRICESELECTPTNRF, ");      // ���̓p�^�[��
                sqlText.Append(" A.GOODSMAKERCDRF, ");        // ���[�J�[�R�[�h
                sqlText.Append(" A.BLGOODSCODERF, ");         // BL�R�[�h
                sqlText.Append(" A.CUSTRATEGRPCODERF, ");     // ���Ӑ�|���O���[�v
                sqlText.Append(" A.CUSTOMERCODERF, ");        // ���Ӑ�R�[�h
                sqlText.Append(" A.PRICESELECTDIVRF,");       // ���i�\���敪
                sqlText.Append(" B.CUSTOMERSNMRF, ");         // ���Ӑ旪��
                sqlText.Append(" C.BLGOODSFULLNAMERF, ");     // BL�S�p����
                sqlText.Append(" D.MAKERNAMERF  ");           // ���[�J�[��
                sqlText.Append(" FROM PRICESELECTSETRF  A WITH (READUNCOMMITTED) ");        //�\���敪�}�X�^
                sqlText.Append(" LEFT JOIN  CUSTOMERRF B WITH (READUNCOMMITTED) ON ");// ���Ӑ�}�X�^
                sqlText.Append(" (A.ENTERPRISECODERF= B.ENTERPRISECODERF ");
                sqlText.Append(" AND A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                sqlText.Append(" AND B.LOGICALDELETECODERF = 0) ");
                sqlText.Append(" LEFT JOIN  BLGOODSCDURF C WITH (READUNCOMMITTED) ON ");// BL�R�[�h�}�X�^
                sqlText.Append(" (A.ENTERPRISECODERF= C.ENTERPRISECODERF ");
                sqlText.Append(" AND A.BLGOODSCODERF = C.BLGOODSCODERF ");
                sqlText.Append(" AND C.LOGICALDELETECODERF = 0) ");
                sqlText.Append(" LEFT JOIN  MAKERURF D WITH (READUNCOMMITTED) ON ");// ���[�J�[�}�X�^
                sqlText.Append(" (A.ENTERPRISECODERF= D.ENTERPRISECODERF ");
                sqlText.Append(" AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
                sqlText.Append(" AND D.LOGICALDELETECODERF = 0) ");
                sqlCommand.CommandText += sqlText.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, priceSelectSetWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPriceSelectSetWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.SearchProc", status);
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

            priceSelectSetList = al;

            return status;

        }

        # endregion

        #region [write]
        /// <summary>
        ///�\���敪�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        public int Write(ref object priceSelectSetWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                PriceSelectSetWork wkPriceSelectSetWork = priceSelectSetWork as PriceSelectSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref wkPriceSelectSetWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                priceSelectSetWork = wkPriceSelectSetWork;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetDB.Write", status);
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
        ///�\���敪�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�ǉ��E�X�V����I�[�g�o�b�N�X�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork �Ɋi�[����Ă���I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private int WriteProc(ref PriceSelectSetWork priceSelectSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceSelectSetWork al = new PriceSelectSetWork();

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            if (priceSelectSetWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = "UPDATE PRICESELECTSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PRICESELECTPTNRF=@PRICESELECTPTN , GOODSMAKERCDRF=@GOODSMAKERCD , BLGOODSCODERF=@BLGOODSCODE , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE , CUSTOMERCODERF=@CUSTOMERCODE , PRICESELECTDIVRF=@PRICESELECTDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (priceSelectSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = "INSERT INTO PRICESELECTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PRICESELECTPTN, @GOODSMAKERCD, @BLGOODSCODE, @CUSTRATEGRPCODE, @CUSTOMERCODE, @PRICESELECTDIV)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
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
                    SqlParameter paraPriceSelectPtn = sqlCommand.Parameters.Add("@PRICESELECTPTN", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraPriceSelectDiv = sqlCommand.Parameters.Add("@PRICESELECTDIV", SqlDbType.Int);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(priceSelectSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.LogicalDeleteCode);
                    paraPriceSelectPtn.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.PriceSelectPtn);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);
                    paraPriceSelectDiv.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.PriceSelectDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al = priceSelectSetWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "PriceSelectSetDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.WriteProc", status);
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

            priceSelectSetWork = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        ///�\���敪�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜����I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        public int LogicalDelete(ref object priceSelectSetWork)
        {
            return this.LogicalDeleteProc(ref priceSelectSetWork, 0);
        }

        /// <summary>
        ///�\���敪�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜����������I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        public int RevivalLogicalDelete(ref object priceSelectSetWork)
        {
            return this.LogicalDeleteProc(ref priceSelectSetWork, 1);
        }

        /// <summary>
        ///�\���敪�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜�𑀍삷��I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private int LogicalDeleteProc(ref object priceSelectSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PriceSelectSetWork paraList = priceSelectSetWork as PriceSelectSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                priceSelectSetWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceSelectSetDB.LogicalDeleteProc", status);
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
        ///�\���敪�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜�𑀍삷��I�[�g�o�b�N�X�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :�\���敪�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private int LogicalDeleteProc(ref PriceSelectSetWork priceSelectSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (priceSelectSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PRICESELECTPTNRF, GOODSMAKERCDRF, BLGOODSCODERF, CUSTRATEGRPCODERF, CUSTOMERCODERF, PRICESELECTDIVRF FROM PRICESELECTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != priceSelectSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = "UPDATE PRICESELECTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.GoodsMakerCd);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.BLGoodsCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustRateGrpCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)priceSelectSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
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

                    // �_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) priceSelectSetWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else priceSelectSetWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            priceSelectSetWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                            }

                            return status;
                        }
                    }

                    // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(priceSelectSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(priceSelectSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(priceSelectSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqex, "PriceSelectSetDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PriceSelectSetDB.DeleteProc", status);
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

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="priceSelectSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PriceSelectSetWork priceSelectSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += " A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(priceSelectSetWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY " + Environment.NewLine;
            retstring += " A.PRICESELECTPTNRF," + Environment.NewLine;
            retstring += " A.GOODSMAKERCDRF," + Environment.NewLine;
            retstring += " A.BLGOODSCODERF," + Environment.NewLine;
            retstring += " A.CUSTRATEGRPCODERF," + Environment.NewLine;
            retstring += " A.CUSTOMERCODERF" + Environment.NewLine;
            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PriceSelectSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        private PriceSelectSetWork CopyToPriceSelectSetWorkFromReader(ref SqlDataReader myReader)
        {
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();

            this.CopyToPriceSelectSetWorkFromReader(ref myReader, ref priceSelectSetWork);

            return priceSelectSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PriceSelectSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="priceSelectSetWork">PriceSelectSetWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        /// </remarks>
        private void CopyToPriceSelectSetWorkFromReader(ref SqlDataReader myReader, ref PriceSelectSetWork priceSelectSetWork)
        {
            if (myReader != null && priceSelectSetWork != null)
            {
                # region �N���X�֊i�[
                priceSelectSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                priceSelectSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                priceSelectSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                priceSelectSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                priceSelectSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                priceSelectSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                priceSelectSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                priceSelectSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                priceSelectSetWork.PriceSelectPtn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTPTNRF"));
                priceSelectSetWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                priceSelectSetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                priceSelectSetWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                priceSelectSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                priceSelectSetWork.PriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTDIVRF"));
                priceSelectSetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                priceSelectSetWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                priceSelectSetWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
# endregion
            }
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
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
        # endregion
    }
}

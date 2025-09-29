//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t�� DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���e�[�u���ɑ΂��Ċe���쏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00 �쐬�S�� : ������
// �C �� ��  2021/11/18  �C�����e : PJMIT-1499 OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;// ADD 2021/11/18 ������ PJMIT-1499�Ή�

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t���}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br>Update Note: 2021/11/18 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770181-00</br>
    /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnDB : RemoteDB, IGoodsBarCodeRevnDB
    {
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnDB()
            :
            base("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork", "GOODSBARCODEREVNRF")
        {
        }

        #region [����]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">��������</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>������������  0:����</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        public int Search(out object objGoodsBarCodeRevnWork, object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            objGoodsBarCodeRevnWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out objGoodsBarCodeRevnWork, objGoodsBarCodeRevnSearchParaWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">��������</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>������������  0:����</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private int SearchProc(out object objGoodsBarCodeRevnWork, object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // obj �� ���[�N
            GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = objGoodsBarCodeRevnSearchParaWork as GoodsBarCodeRevnSearchParaWork;

            ArrayList goodsBarCodeRevnWorkList = new ArrayList();

            int status = SearchProc(out goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchParaWork, readMode, logicalMode, ref sqlConnection);
            // ���[�NLIST �� obj
            objGoodsBarCodeRevnWork = goodsBarCodeRevnWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">��������</param>
        /// <param name="goodsBarCodeRevnSearchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>������������  0:����</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�o�[�R�[�h�֘A�t���}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private int SearchProc(out ArrayList goodsBarCodeRevnWorkList, GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            goodsBarCodeRevnWorkList = new ArrayList();
            try
            {
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append(
                    " SELECT "+
                    " CREATEDATETIMERF, " +
                    " UPDATEDATETIMERF, " +
                    " ENTERPRISECODERF, " +
                    " FILEHEADERGUIDRF, " +
                    " UPDEMPLOYEECODERF, " +
                    " UPDASSEMBLYID1RF, " +
                    " UPDASSEMBLYID2RF, " +
                    " LOGICALDELETECODERF, " +
                    " GOODSMAKERCDRF, " +
                    " GOODSNORF, " +
                    " GOODSBARCODERF, " +
                    " GOODSBARCODEKINDRF, " +
                    " CHECKDIGITCODERF, " +
                    " OFFERDATERF, " +
                    " OFFERDATADIVRF " +
                    " FROM GOODSBARCODEREVNRF WITH (READUNCOMMITTED) "
                    );

                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                // Where���쐬����
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsBarCodeRevnSearchParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsBarCodeRevnWorkList.Add(CopyToGoodsBarCodeRevnWorkFromReader(ref myReader));
                }
                if (goodsBarCodeRevnWorkList.Count > 0)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------>>>>>
        #region [���[�U�[�݌ɏ��i����]
        /// <summary>
        /// �w�肳�ꂽ�����̃��[�U�[�݌ɏ��i�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="condObj">�����p�����[�^</param>
        /// <returns>������������  0:����</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�U�[�݌ɏ��i�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2021/11/18</br>
        public int SearchStockGoods(out object retObj, object condObj)
        {
            retObj = null;
            SqlConnection sqlConnection = null;
            ArrayList retList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection())
            {
                try
                {
                    if (sqlConnection == null) return status;
                    sqlConnection.Open();

                    GoodsBarCodeRevnSearchParaWork condWork = (GoodsBarCodeRevnSearchParaWork)condObj;
                    // ����������null�̏ꍇ
                    if (condWork == null)
                    {
                        base.WriteErrorLog("GoodsBarCodeRevnDB.SearchStockGoods" + "�J�X�^���V���A���C�U���s");
                        return status;
                    }
                    // ���[�U�[�݌ɏ��i�}�X�^���擾
                    status = SearchStockGoodsProc(condWork, ref retList, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retObj = (object)retList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.SearchStockGoods Exception=" + ex.ToString(), status);
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�U�[�݌ɏ��i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="condWork">�����p�����[�^</param>
        /// <param name="retList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>������������  0:����</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�U�[�݌ɏ��i�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2021/11/18</br>
        private int SearchStockGoodsProc(GoodsBarCodeRevnSearchParaWork condWork, ref ArrayList retList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select���쐬]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" STOCK.GOODSNORF AS GOODSNORF, ");   // �i��
                    sqlText.AppendLine(" STOCK.GOODSMAKERCDRF AS GOODSMAKERCDRF, ");   // ���[�J�[
                    sqlText.AppendLine(" GOODS.GOODSNAMERF AS GOODSNAMERF,");  // �i��
                    sqlText.AppendLine(" MAK.MAKERNAMERF AS MAKERNAMERF, ");    // ���[�J�[����
                    sqlText.AppendLine(" GOODS.OFFERDATERF AS OFFERDATERF, ");   // �񋟓��t
                    sqlText.AppendLine(" GOODS.OFFERDATADIVRF AS OFFERDATADIVRF ");  // �񋟃f�[�^�敪
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" STOCKRF STOCK ");
                    sqlText.AppendLine(" INNER JOIN GOODSURF GOODS ");
                    sqlText.AppendLine(" ON GOODS.ENTERPRISECODERF = STOCK.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND GOODS.GOODSNORF = STOCK.GOODSNORF ");
                    sqlText.AppendLine(" AND GOODS.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND GOODS.LOGICALDELETECODERF = STOCK.LOGICALDELETECODERF ");
                    sqlText.AppendLine(" LEFT JOIN MAKERURF MAK ");
                    sqlText.AppendLine(" ON MAK.ENTERPRISECODERF = GOODS.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND MAK.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND MAK.LOGICALDELETECODERF = GOODS.LOGICALDELETECODERF ");
                    // WHERE��
                    sqlText.AppendLine(MakeStockGoodsWhereString(condWork, ref sqlCommand));
                    sqlText.AppendLine(" ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC");

                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();


                    // �N�G�����s���̃^�C���A�E�g���Ԃ�600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = new GoodsBarCodeRevnWork();
                            wkGoodsBarCodeRevnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            wkGoodsBarCodeRevnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            wkGoodsBarCodeRevnWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                            wkGoodsBarCodeRevnWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                            DateTime offerDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            int intOfferDate = 0;
                            // �񋟓��t����̏ꍇ
                            if (offerDate != DateTime.MinValue) Int32.TryParse(offerDate.ToString("yyyyMMdd"), out intOfferDate);
                            wkGoodsBarCodeRevnWork.OfferDate = intOfferDate;
                            wkGoodsBarCodeRevnWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

                            retList.Add(wkGoodsBarCodeRevnWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // ���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "SearchStockGoodsProc.SearchStockGoodsProc Exception=" + ex.ToString(), status);
                }
            }
            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�i���[�U�[�݌ɏ��i�}�X�^�j
        /// </summary>
        /// <param name="condWork">���������i�[�N���X</param>
        /// <param name="sqlCommand">�R�}���h</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �������������񐶐��{�����l�ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        private string MakeStockGoodsWhereString(GoodsBarCodeRevnSearchParaWork condWork, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine("WHERE ");

            // ��ƃR�[�h
            sqlText.AppendLine(" STOCK.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);

            // �_���폜�敪
            sqlText.AppendLine(" AND STOCK.LOGICALDELETECODERF=@LOGICALDELETECODE");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // ���i���[�J�[�R�[�h
            if (condWork.GoodsMakerCd > 0)
            {
                sqlText.AppendLine(" AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
            }

            // ���i�i��
            if (!String.IsNullOrEmpty(condWork.GoodsNo))
            {
                //�n�C�t�������i�Ԃɕϊ�
                string goodsNoNoneHyphen = condWork.GoodsNo.Replace("-", "");
                goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                sqlText.AppendLine(" AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN");
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
            }

            // �q�ɃR�[�h
            if (!String.IsNullOrEmpty(condWork.WarehouseCode))
            {
                sqlText.AppendLine(" AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
            }

            // �Ǘ����_�R�[�h
            if (!String.IsNullOrEmpty(condWork.SectionCode))
            {
                sqlText.AppendLine(" AND STOCK.SECTIONCODERF=@FINDSECTIONCODE");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(condWork.SectionCode);
            }

            return sqlText.ToString();
        }
        #endregion
        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------<<<<<

        #region [�捞]
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWorkList">GoodsBarCodeRevnWork�I�u�W�F�N�g</param>
        /// <returns>�捞��������  0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        public int WriteByInput(ref object objGoodsBarCodeRevnWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(objGoodsBarCodeRevnWorkList);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteByInputProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) { 
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.WriteByInput(object objGoodsBarCodeRevnWorkList)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// ���i�o�[�R�[�h�֘A�t���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">GoodsBarCodeRevnWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�捞��������  0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private int WriteByInputProc(ArrayList goodsBarCodeRevnWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (goodsBarCodeRevnWorkList != null && goodsBarCodeRevnWorkList.Count > 0)
                {
                    for (int i = 0; i < goodsBarCodeRevnWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork goodsBarCodeRevnWork = goodsBarCodeRevnWorkList[i] as GoodsBarCodeRevnWork;

                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF " +
                            " FROM GOODSBARCODEREVNRF " +
                            " WHERE " +
                            " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            sqlText.Append(
                                " UPDATE GOODSBARCODEREVNRF " +
                                " SET " +
                                " UPDATEDATETIMERF=@UPDATEDATETIME, " +
                                " UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, " +
                                " UPDASSEMBLYID1RF=@UPDASSEMBLYID1, " +
                                " UPDASSEMBLYID2RF=@UPDASSEMBLYID2, " +
                                " GOODSMAKERCDRF=@GOODSMAKERCD, " +
                                " GOODSNORF=@GOODSNO, " +
                                " GOODSBARCODERF=@GOODSBARCODE, " +
                                " GOODSBARCODEKINDRF=@GOODSBARCODEKIND, " +
                                " CHECKDIGITCODERF=@CHECKDIGITCODE, " +
                                " OFFERDATADIVRF=@OFFERDATADIV " +
                                " WHERE " +
                                " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                                " AND GOODSNORF=@FINDGOODSNO "
                                );
                            sqlCommand.CommandText = sqlText.ToString();
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsBarCodeRevnWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            sqlText.Append(
                                " INSERT INTO GOODSBARCODEREVNRF " +
                                " ( CREATEDATETIMERF, " +
                                " UPDATEDATETIMERF, " +
                                " ENTERPRISECODERF, " +
                                " FILEHEADERGUIDRF, " +
                                " UPDEMPLOYEECODERF, " +
                                " UPDASSEMBLYID1RF, " +
                                " UPDASSEMBLYID2RF, " +
                                " LOGICALDELETECODERF, " +
                                " GOODSMAKERCDRF, " +
                                " GOODSNORF, " +
                                " GOODSBARCODERF, " +
                                " GOODSBARCODEKINDRF, " +
                                " CHECKDIGITCODERF, " +
                                " OFFERDATADIVRF " +
                                " ) VALUES ( " +
                                " @CREATEDATETIME, " +
                                " @UPDATEDATETIME, " +
                                " @ENTERPRISECODE, " +
                                " @FILEHEADERGUID, " +
                                " @UPDEMPLOYEECODE, " +
                                " @UPDASSEMBLYID1, " +
                                " @UPDASSEMBLYID2, " +
                                " @LOGICALDELETECODE, " +
                                " @GOODSMAKERCD, " +
                                " @GOODSNO, " +
                                " @GOODSBARCODE, " +
                                " @GOODSBARCODEKIND, " +
                                " @CHECKDIGITCODE, " +
                                " @OFFERDATADIV )"
                                );

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = sqlText.ToString();


                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsBarCodeRevnWork;
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

                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCode = sqlCommand.Parameters.Add("@GOODSBARCODE", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCodeKind = sqlCommand.Parameters.Add("@GOODSBARCODEKIND", SqlDbType.Int);
                        SqlParameter paraCheckdigitCode = sqlCommand.Parameters.Add("@CHECKDIGITCODE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsBarCodeRevnWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.LogicalDeleteCode);

                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);
                        paraGoodsBarCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsBarCode);
                        paraGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsBarCodeKind);
                        paraCheckdigitCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.CheckdigitCode);
                        // �񋟋敪: 0:���[�U�f�[�^[�Œ�]
                        paraOfferDataDiv.Value = 0;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

        #region [�ۑ�]
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^����ۑ����܂�
        /// </summary>
        /// <param name="objSaveWorkList">�ۑ��p�f�[�^List</param>
        /// <param name="objDeleteWorkList">�폜�p�f�[�^List</param>
        /// <returns>�ۑ��������� 0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^����ۑ����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        public int WriteBySave(ref object objSaveWorkList,ref object objDeleteWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�ۑ��p�p�����[�^�̃L���X�g
                ArrayList paraSaveList = CastToArrayListFromPara(objSaveWorkList);
                //�폜�p�p�����[�^�̃L���X�g
                ArrayList paraDeleteList = CastToArrayListFromPara(objDeleteWorkList);

                if (paraSaveList == null || paraDeleteList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //�ۑ����s
                status = SaveWorkProc(ref paraSaveList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�폜���s
                    status = DeleteWorkProc(ref paraDeleteList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    if (sqlTransaction.Connection != null) sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                objSaveWorkList = paraSaveList;
                objDeleteWorkList = paraDeleteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.WriteBySave(ref object objSaveWorkList, ref object objDeleteWorkList)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// ���i�o�[�R�[�h�֘A�t���}�X�^����ۑ����܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="saveWorkList">�ۑ��p�f�[�^List</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�ۑ��������� 0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^����ۑ����܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private int SaveWorkProc(ref ArrayList saveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (saveWorkList != null && saveWorkList.Count > 0)
                {
                    for (int i = 0; i < saveWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork saveWork = saveWorkList[i] as GoodsBarCodeRevnWork;
                        
                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF "+
                            " FROM GOODSBARCODEREVNRF "+
                            " WHERE "+
                            " ENTERPRISECODERF=@FINDENTERPRISECODE "+
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD "+
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != saveWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (saveWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " UPDATE GOODSBARCODEREVNRF " +
                                " SET " +
                                " UPDATEDATETIMERF=@UPDATEDATETIME, " +
                                " UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, "+
                                " UPDASSEMBLYID1RF=@UPDASSEMBLYID1, " +
                                " UPDASSEMBLYID2RF=@UPDASSEMBLYID2, " +
                                " GOODSMAKERCDRF=@GOODSMAKERCD, " +
                                " GOODSNORF=@GOODSNO, " +
                                " GOODSBARCODERF=@GOODSBARCODE, " +
                                " GOODSBARCODEKINDRF=@GOODSBARCODEKIND, " +
                                " CHECKDIGITCODERF=@CHECKDIGITCODE, " +
                                " OFFERDATADIVRF=@OFFERDATADIV "+
                                " WHERE " +
                                " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                                " AND GOODSNORF=@FINDGOODSNO "
                                );
                            sqlCommand.CommandText = sqlText.ToString();
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)saveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (saveWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " INSERT INTO GOODSBARCODEREVNRF " +
                                " ( CREATEDATETIMERF, "+
                                " UPDATEDATETIMERF, "+
                                " ENTERPRISECODERF, "+
                                " FILEHEADERGUIDRF, "+
                                " UPDEMPLOYEECODERF, "+
                                " UPDASSEMBLYID1RF, "+
                                " UPDASSEMBLYID2RF, "+
                                " LOGICALDELETECODERF, "+
                                " GOODSMAKERCDRF, "+
                                " GOODSNORF, "+
                                " GOODSBARCODERF, " +
                                " GOODSBARCODEKINDRF, " +
                                " CHECKDIGITCODERF, "+
                                " OFFERDATADIVRF "+
                                " ) VALUES ( "+
                                " @CREATEDATETIME, "+
                                " @UPDATEDATETIME, "+
                                " @ENTERPRISECODE, "+
                                " @FILEHEADERGUID, "+
                                " @UPDEMPLOYEECODE, "+
                                " @UPDASSEMBLYID1, "+
                                " @UPDASSEMBLYID2, "+
                                " @LOGICALDELETECODE, "+
                                " @GOODSMAKERCD, "+
                                " @GOODSNO, "+
                                " @GOODSBARCODE, " +
                                " @GOODSBARCODEKIND, " +
                                " @CHECKDIGITCODE, "+
                                " @OFFERDATADIV )"
                                );

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = sqlText.ToString();


                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)saveWork;
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

                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCode = sqlCommand.Parameters.Add("@GOODSBARCODE", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCodeKind = sqlCommand.Parameters.Add("@GOODSBARCODEKIND", SqlDbType.Int);
                        SqlParameter paraCheckdigitCode = sqlCommand.Parameters.Add("@CHECKDIGITCODE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saveWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saveWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(saveWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saveWork.LogicalDeleteCode);

                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);
                        paraGoodsBarCode.Value = SqlDataMediator.SqlSetString(saveWork.GoodsBarCode);
                        paraGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsBarCodeKind);
                        paraCheckdigitCode.Value = SqlDataMediator.SqlSetInt32(saveWork.CheckdigitCode);
                        // �񋟋敪: 0:���[�U�f�[�^[�Œ�]
                        paraOfferDataDiv.Value = 0;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(saveWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            saveWorkList = al;

            return status;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�����폜���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="deleteWorkList">�폜�p�f�[�^List</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�폜�������� 0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�����폜���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private int DeleteWorkProc(ref ArrayList deleteWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            try
            {
                if (deleteWorkList != null && deleteWorkList.Count > 0)
                {
                    for (int i = 0; i < deleteWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork deleteWork = deleteWorkList[i] as GoodsBarCodeRevnWork;
                        if (deleteWork.CreateDateTime == DateTime.MinValue) continue;

                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF " +
                            " FROM GOODSBARCODEREVNRF " +
                            " WHERE " +
                            " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(deleteWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(deleteWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(deleteWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != deleteWork.UpdateDateTime)
                            {
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " DELETE " +
                                " FROM GOODSBARCODEREVNRF " +
                                " WHERE " +
                                " ENTERPRISECODERF=@ENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@GOODSMAKERCD " +
                                " AND GOODSNORF=@GOODSNO "
                                );

                            //Select�R�}���h�̐���
                            sqlCommand.CommandText = sqlText.ToString();

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(deleteWork.EnterpriseCode);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(deleteWork.GoodsMakerCd);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(deleteWork.GoodsNo);
                            if (myReader.IsClosed == false) myReader.Close();
                            sqlCommand.ExecuteNonQuery();
                            al.Add(deleteWork);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            deleteWorkList = al;
            return status;
        }

        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="goodsBarCodeRevnSearchParaWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            // ��ƃR�[�h
            retstring += " ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnSearchParaWork.EnterpriseCode);

            // ���i���[�J�[�R�[�h
            if (goodsBarCodeRevnSearchParaWork.GoodsMakerCd != 0)
            {
                retstring += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnSearchParaWork.GoodsMakerCd);
            }

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsBarCodeRevnWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsBarCodeRevnWork</returns>
        /// <remarks>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnWork CopyToGoodsBarCodeRevnWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = new GoodsBarCodeRevnWork();

            #region �N���X�֊i�[
            wkGoodsBarCodeRevnWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsBarCodeRevnWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsBarCodeRevnWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsBarCodeRevnWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsBarCodeRevnWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsBarCodeRevnWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsBarCodeRevnWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsBarCodeRevnWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

            wkGoodsBarCodeRevnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsBarCodeRevnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsBarCodeRevnWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));
            wkGoodsBarCodeRevnWork.GoodsBarCodeKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSBARCODEKINDRF"));
            wkGoodsBarCodeRevnWork.CheckdigitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKDIGITCODERF"));
            wkGoodsBarCodeRevnWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsBarCodeRevnWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            #endregion

            return wkGoodsBarCodeRevnWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsBarCodeRevnWork[] goodsBarCodeRevnWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is GoodsBarCodeRevnWork)
                    {
                        GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = paraobj as GoodsBarCodeRevnWork;
                        if (wkGoodsBarCodeRevnWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsBarCodeRevnWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            goodsBarCodeRevnWorkArray = (GoodsBarCodeRevnWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsBarCodeRevnWork[]));
                        }
                        catch (Exception) { }
                        if (goodsBarCodeRevnWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(goodsBarCodeRevnWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = (GoodsBarCodeRevnWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsBarCodeRevnWork));
                                if (wkGoodsBarCodeRevnWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsBarCodeRevnWork);
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

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
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
    }
}

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
    /// �I���ߕs���X�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���ߕs���X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.07.17</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.12 Yokokawa</br>
    /// <br>             ����.NS �p�ɉ���</br>
    /// <br>Update Note: 2008/09/19 Hatanaka</br>
    /// <br>             PM.NS�p�ɉ���</br>
    /// <br>Update Note: 2009/09/14 ����</br>
    /// <br>             MANTIS�Ή�(13940)</br>
    /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
    /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
    /// </remarks>
    [Serializable]
    public class InventoryExcDefUpdateDB : RemoteDB
    {
        /// <summary>
        /// �I���ߕs���X�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12  Yokokawa</br>
        /// <br>             ����.NS �p�ɉ���</br>
        /// </remarks>
        public InventoryExcDefUpdateDB()
            :
            base("SFDML02063D", "Broadleaf.Application.Remoting.ParamData.InventoryExcDefUpdateWork", "INVENTORYDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">��������</param>
        /// <param name="parainventoryExcDefUpdateWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int Search(out object inventoryExcDefUpdateWork, object parainventoryExcDefUpdateWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            inventoryExcDefUpdateWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchInventoryExcDefUpdateProc(out inventoryExcDefUpdateWork, parainventoryExcDefUpdateWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Search");
                inventoryExcDefUpdateWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objinventoryExcDefUpdateWork">��������</param>
        /// <param name="parainventoryExcDefUpdateWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        public int SearchInventoryExcDefUpdateProc(out object objinventoryExcDefUpdateWork, object parainventoryExcDefUpdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            InventoryDataUpdateWork inventoryexcdefupdateWork = null;

            ArrayList inventoryexcdefupdateWorkList = parainventoryExcDefUpdateWork as ArrayList;
            if (inventoryexcdefupdateWorkList == null)
            {
                inventoryexcdefupdateWork = parainventoryExcDefUpdateWork as InventoryDataUpdateWork;
            }
            else
            {
                if (inventoryexcdefupdateWorkList.Count > 0)
                    inventoryexcdefupdateWork = inventoryexcdefupdateWorkList[0] as InventoryDataUpdateWork;
            }
            int status = SearchInventoryExcDefUpdateProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection);
            objinventoryExcDefUpdateWork = inventoryexcdefupdateWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">��������</param>
        /// <param name="inventoryexcdefupdateWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int SearchInventoryExcDefUpdateProc(out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return SearchInventoryExcDefUpdateProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">��������</param>
        /// <param name="inventoryexcdefupdateWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        public int SearchInventoryExcDefUpdateProc(out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchInventoryExcDefUpdateProcProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">��������</param>
        /// <param name="inventoryexcdefupdateWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        private int SearchInventoryExcDefUpdateProcProc( out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF ", sqlConnection);

                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryexcdefupdateWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToInventoryExcDefUpdateWorkFromReader(ref myReader));

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

            inventoryexcdefupdateWorkList = al;

            return status;
        }

        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="stockWorkList">stockWorkList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int SearchStockFromInventoryProc(ArrayList inventoryExcDefUpdateWorkList, out ArrayList stockWorkList,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchStockFromInventoryProcProc(inventoryExcDefUpdateWorkList, out stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="stockWorkList">stockWorkList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        private int SearchStockFromInventoryProcProc( ArrayList inventoryExcDefUpdateWorkList, out ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectString = "";
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        // 2008.04.03 Upd >>>>>>>>
                        selectString =
                            "SELECT * " +
                            "FROM STOCKRF " +
                            "WHERE " +
                            "ENTERPRISECODERF=@FINDENTERPRISECODE AND " +
                            "LOGICALDELETECODERF=0 AND " +
                            "SECTIONCODERF=@FINDSECTIONCODE AND " +
                            "WAREHOUSECODERF=@FINDWAREHOUSECODE AND " +
                            "GOODSMAKERCDRF=@FINDGOODSMAKERCD AND " +
                            "GOODSNORF=@FINDGOODSNO ";

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectString, sqlConnection, sqlTransaction);

                        //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWareHouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findWareHouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {

                            al.Add(CopyToStockWorkFromInventoryReader(inventoryDataUpdateWork, ref myReader));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if (myReader != null)
                            if (myReader.IsClosed == false) myReader.Close();

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

            stockWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�
        /// </summary>
        /// <param name="parabyte">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                InventoryDataUpdateWork inventoryexcdefupdateWork = new InventoryDataUpdateWork();

                // XML�̓ǂݍ���
                inventoryexcdefupdateWork = (InventoryDataUpdateWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventoryDataUpdateWork));
                if (inventoryexcdefupdateWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref inventoryexcdefupdateWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(inventoryexcdefupdateWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Read");
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
        /// �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWork">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int ReadProc(ref InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadProc(ref inventoryexcdefupdateWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryDataUpdateWork">InventoryDataUpdateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        public int ReadProc(ref InventoryDataUpdateWork inventoryDataUpdateWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref inventoryDataUpdateWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryDataUpdateWork">InventoryDataUpdateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���ߕs���X�V��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
        private int ReadProcProc( ref InventoryDataUpdateWork inventoryDataUpdateWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection)) // DEL 2009/12/03
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection)) // ADD 2009/12/03
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        inventoryDataUpdateWork = CopyToInventoryExcDefUpdateWorkFromReader(ref myReader);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int Write(ref object inventoryExcDefUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = inventoryExcDefUpdateWork as ArrayList;//CastToArrayListFromPara(inventoryExcDefUpdateWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteInventoryExcDefUpdateProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                inventoryExcDefUpdateWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Write(ref object inventoryExcDefUpdateWork)");
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
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        public int WriteInventoryExcDefUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteInventoryExcDefUpdateProcProc(ref inventoryExcDefUpdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa ����.NS �p�ɉ���</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
        private int WriteInventoryExcDefUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (inventoryDataUpdateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // �C�� 2008/09/19 �e�[�u�����C�A�E�g�̕ύX�Ή� >>>
                            //sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYSEQNORF=@INVENTORYSEQNO , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , GOODSMAKERCDRF=@GOODSMAKERCD , MAKERNAMERF=@MAKERNAME , GOODSNORF=@GOODSNO , GOODSNAMERF=@GOODSNAME , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1 , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2 , LARGEGOODSGANRECODERF=@LARGEGOODSGANRECODE , LARGEGOODSGANRENAMERF=@LARGEGOODSGANRENAME , MEDIUMGOODSGANRECODERF=@MEDIUMGOODSGANRECODE , MEDIUMGOODSGANRENAMERF=@MEDIUMGOODSGANRENAME , DETAILGOODSGANRECODERF=@DETAILGOODSGANRECODE , DETAILGOODSGANRENAMERF=@DETAILGOODSGANRENAME , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE , ENTERPRISEGANRENAMERF=@ENTERPRISEGANRENAME , BLGOODSCODERF=@BLGOODSCODE , SUPPLIERCDRF=@SUPPLIERCD , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , JANRF=@JAN , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL , STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG , STOCKDIVRF=@STOCKDIV , LASTSTOCKDATERF=@LASTSTOCKDATE , STOCKTOTALRF=@STOCKTOTAL , SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE , SHIPCUSTOMERNAMERF=@SHIPCUSTOMERNAME , SHIPCUSTOMERNAME2RF=@SHIPCUSTOMERNAME2 , INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT , INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYDAYRF=@INVENTORYDAY , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE , INVENTORYNEWDIVRF=@INVENTORYNEWDIV , STOCKMASHINEPRICERF=@STOCKMASHINEPRICE , INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE, INVENTORYDATERF=@INVENTORYDATE, STOCKTOTALEXECRF=@STOCKTOTALEXEC, TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO";
                            #region UPDATE���쐬
                            sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET" + Environment.NewLine;
                            sqlCommand.CommandText = " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText = " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSEQNORF=@INVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            sqlCommand.CommandText = " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSLGROUPRF=@GOODSLGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = " , JANRF=@JAN" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = " , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = " , STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            sqlCommand.CommandText = " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKTOTALRF=@STOCKTOTAL" + Environment.NewLine;
                            sqlCommand.CommandText = " , SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYDAYRF=@INVENTORYDAY" + Environment.NewLine;
                            sqlCommand.CommandText = " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYNEWDIVRF=@INVENTORYNEWDIV" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKMASHINEPRICERF=@STOCKMASHINEPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYDATERF=@INVENTORYDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKTOTALEXECRF=@STOCKTOTALEXEC" + Environment.NewLine;
                            sqlCommand.CommandText = " , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD" + Environment.NewLine;
                            sqlCommand.CommandText = " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine; // ADD 2009/12/03
                            #endregion
                            // �C�� 2008/09/19 <<<
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (inventoryDataUpdateWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            // �C�� 2008/09/19 �e�[�u�����C�A�E�g�̕ύX�Ή� >>>
                            //sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, WAREHOUSENAMERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, LARGEGOODSGANRECODERF, LARGEGOODSGANRENAMERF, MEDIUMGOODSGANRECODERF, MEDIUMGOODSGANRENAMERF, DETAILGOODSGANRECODERF, DETAILGOODSGANRENAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, BLGOODSCODERF, SUPPLIERCDRF, CUSTOMERNAMERF, CUSTOMERNAME2RF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, SHIPCUSTOMERNAMERF, SHIPCUSTOMERNAME2RF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF, STOCKTOTALEXECRF, TOLERANCEUPDATECDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @WAREHOUSENAME, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @LARGEGOODSGANRECODE, @LARGEGOODSGANRENAME, @MEDIUMGOODSGANRECODE, @MEDIUMGOODSGANRENAME, @DETAILGOODSGANRECODE, @DETAILGOODSGANRENAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @BLGOODSCODE, @SUPPLIERCD, @CUSTOMERNAME, @CUSTOMERNAME2, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @SHIPCUSTOMERNAME, @SHIPCUSTOMERNAME2, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE, @STOCKTOTALEXEC, @TOLERANCEUPDATECD)";
                            #region INSERT���쐬
                            sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF" + Environment.NewLine;
                            sqlCommand.CommandText = " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",UPDATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",ENTERPRISECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlCommand.CommandText = ",UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlCommand.CommandText = "UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlCommand.CommandText = "LOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSEQNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "WAREHOUSECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSMAKERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "WAREHOUSESHELFNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            sqlCommand.CommandText = "DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSLGROUPRF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSMGROUPRF" + Environment.NewLine;
                            sqlCommand.CommandText = "BLGROUPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "ENTERPRISEGANRECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "BLGOODSCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "SUPPLIERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText = "JANRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKUNITPRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText = "BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STKUNITPRICECHGFLGRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText = "LASTSTOCKDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKTOTALRF" + Environment.NewLine;
                            sqlCommand.CommandText = "SHIPCUSTOMERCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSTOCKCNTRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYPREPRDAYRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYPREPRTIMRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYDAYRF" + Environment.NewLine;
                            sqlCommand.CommandText = "LASTINVENTORYUPDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYNEWDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKMASHINEPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSTOCKPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYTLRNCPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKTOTALEXECRF" + Environment.NewLine;
                            sqlCommand.CommandText = "TOLERANCEUPDATECDRF" + Environment.NewLine;
                            sqlCommand.CommandText = " )" + Environment.NewLine;
                            sqlCommand.CommandText = " VALUES" + Environment.NewLine;
                            sqlCommand.CommandText = " (@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = "@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText = "@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@WAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            sqlCommand.CommandText = "@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSLGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = "@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@ENTERPRISEGANRECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = "@JAN" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = "@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = "@STKUNITPRICECHGFLG" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKDIV" + Environment.NewLine;
                            sqlCommand.CommandText = "@LASTSTOCKDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKTOTAL" + Environment.NewLine;
                            sqlCommand.CommandText = "@SHIPCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSTOCKCNT" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYTOLERANCCNT" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYPREPRDAY" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYPREPRTIM" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYDAY" + Environment.NewLine;
                            sqlCommand.CommandText = "@LASTINVENTORYUPDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYNEWDIV" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKMASHINEPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSTOCKPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYTLRNCPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKTOTALEXEC" + Environment.NewLine;
                            sqlCommand.CommandText = "@TOLERANCEUPDATECD" + Environment.NewLine;
                            sqlCommand.CommandText = " )" + Environment.NewLine;
                            #endregion
                            // �C�� 2008/09/19 <<<
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            // 2007.10.05 Add >>>>>>>>
                            //�V�K�f�[�^��InventroySeqNo �́AInventorySeqNo�̍ő�l + 1 �Ƃ��܂��B
                            //inventoryDataUpdateWork�ɐݒ肳��Ă���InventorySeqNo�͖������܂��B
                            int inventorySeqNo = 0;
                            GetMaxInventorySeq(out inventorySeqNo, inventoryDataUpdateWork, ref sqlConnection);
                            inventoryDataUpdateWork.InventorySeqNo = inventorySeqNo + 1;
                            // 2007.10.05 Add <<<<<<<<
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        // �C�� 2008/09/19  �e�[�u�����C�A�E�g�ύX�Ή� >>>
                        #region �C���O
                        /*
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraLargeGoodsGanreCode = sqlCommand.Parameters.Add("@LARGEGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraLargeGoodsGanreName = sqlCommand.Parameters.Add("@LARGEGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraMediumGoodsGanreCode = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraMediumGoodsGanreName = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraDetailGoodsGanreCode = sqlCommand.Parameters.Add("@DETAILGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraDetailGoodsGanreName = sqlCommand.Parameters.Add("@DETAILGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraShipCustomerName = sqlCommand.Parameters.Add("@SHIPCUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraShipCustomerName2 = sqlCommand.Parameters.Add("@SHIPCUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        // 2008.03.07 Add >>>>>>>>
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // 2008.03.07 Add <<<<<<<<
                        */ 
                        #endregion
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // �C�� 2008/09/19  <<<
                        #endregion // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        // �C�� 2008/09/19 �e�[�u�����C�A�E�g�̕ύX�Ή� >>>
                        #region �C���O
                        /*
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                        paraLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.LargeGoodsGanreCode);
                        paraLargeGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.LargeGoodsGanreName);
                        paraMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MediumGoodsGanreCode);
                        paraMediumGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MediumGoodsGanreName);
                        paraDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DetailGoodsGanreCode);
                        paraDetailGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DetailGoodsGanreName);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                        paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseGanreName);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                        paraCustomerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.CustomerName);
                        paraCustomerName2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.CustomerName2);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                        paraShipCustomerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.ShipCustomerName);
                        paraShipCustomerName2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.ShipCustomerName2);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        // 2008.03.07 Add >>>>>>>>
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // 2008.03.07 Add <<<<<<<<
                        */ 
                        #endregion
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsLGroup);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGroupCode);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // �C�� 2008/09/19 <<<
                        #endregion // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
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

            inventoryExcDefUpdateWorkList = al;

            return status;
        }

        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2008.04.03 ����</br>
        public int WriteLastInventoryUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteLastInventoryUpdateProcProc(ref inventoryExcDefUpdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2008.04.03 ����</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
        private int WriteLastInventoryUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Select�R�}���h�̐���
                        // �C�� 2008/09/19 �X�V���ڂ̒ǉ� >>>
                        //sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction);
                        //sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , STOCKTOTALEXECRF=@STOCKTOTALEXEC , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE, INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , STOCKTOTALEXECRF=@STOCKTOTALEXEC , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE, INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE ", sqlConnection, sqlTransaction); // ADD 2009/12/03
                        // �C�� 2008/09/19 <<<

                        //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        // ADD 2008/09/19 >>>
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // ADD 2008/09/19 <<<

                        // -- UPD 2009/09/14 ----------------------->>>
                        //// ADD 2009/06/12 >>>
                        ////SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        //SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.Int);
                        //// ADD 2009/06/12 <<<
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        // -- UPD 2009/09/14 -----------------------<<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);

                        // ADD 2008/09/19 >>>�@
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // ADD 2008/09/18 <<<

                        // ADD 2009/06/12 >>>
                        //paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        // ADD 2009/06/12 <<<
                        #endregion


                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
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

            inventoryExcDefUpdateWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �I���ߕs���X�V����_���폜���܂�
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int LogicalDelete(ref object inventoryExcDefUpdateWork)
        {
            return LogicalDeleteInventoryExcDefUpdate(ref inventoryExcDefUpdateWork, 0);
        }

        /// <summary>
        /// �_���폜�I���ߕs���X�V���𕜊����܂�
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�I���ߕs���X�V���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int RevivalLogicalDelete(ref object inventoryExcDefUpdateWork)
        {
            return LogicalDeleteInventoryExcDefUpdate(ref inventoryExcDefUpdateWork, 1);
        }

        /// <summary>
        /// �I���ߕs���X�V���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        private int LogicalDeleteInventoryExcDefUpdate(ref object inventoryExcDefUpdateWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = inventoryExcDefUpdateWork as ArrayList; //CastToArrayListFromPara(inventoryExcDefUpdateWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteInventoryExcDefUpdateProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.LogicalDeleteInventoryExcDefUpdate :" + procModestr);

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
        /// �I���ߕs���X�V���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int LogicalDeleteInventoryExcDefUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteInventoryExcDefUpdateProcProc(ref inventoryExcDefUpdateWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �I���ߕs���X�V���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���ߕs���X�V���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
        private int LogicalDeleteInventoryExcDefUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO"; // DEL 2009/12/03
                            sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE"; // ADD 2009/12/03
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
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
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) inventoryDataUpdateWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else inventoryDataUpdateWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) inventoryDataUpdateWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
                    }

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            inventoryExcDefUpdateWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �I���ߕs���X�V���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�I���ߕs���X�V���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �I���ߕs���X�V���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = paraobj as ArrayList;//CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteInventoryExcDefUpdateProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Delete");
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
        /// �I���ߕs���X�V���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">�I���ߕs���X�V���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �I���ߕs���X�V���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        public int DeleteInventoryExcDefUpdateProc(ArrayList inventoryexcdefupdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteInventoryExcDefUpdateProcProc(inventoryexcdefupdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �I���ߕs���X�V���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">�I���ߕs���X�V���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �I���ߕs���X�V���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �I���f�[�^��Primary Key�ɑq�ɃR�[�h��ǉ�����</br>
        private int DeleteInventoryExcDefUpdateProcProc( ArrayList inventoryexcdefupdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < inventoryexcdefupdateWorkList.Count; i++)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = inventoryexcdefupdateWorkList[i] as InventoryDataUpdateWork;
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO"; // DEL 2009/12/03
                        sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE"; // ADD 2009/12/03
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03
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

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="inventoryExcDefUpdateWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryDataUpdateWork inventoryExcDefUpdateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //��ƃR�[�h
            retstring.Append("ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExcDefUpdateWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring.ToString();
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� InventoryExcDefUpdateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>InventoryExcDefUpdateWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// </remarks>
        private InventoryDataUpdateWork CopyToInventoryExcDefUpdateWorkFromReader(ref SqlDataReader myReader)
        {
            InventoryDataUpdateWork wkInventoryDataUpdateWork = new InventoryDataUpdateWork();

            #region �N���X�֊i�[
            // �C�� 2008/09/19 ���C�A�E�g�ύX�ɂ��C�� >>>
            #region �C���O
            /*
            wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkInventoryDataUpdateWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
            wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkInventoryDataUpdateWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkInventoryDataUpdateWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkInventoryDataUpdateWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkInventoryDataUpdateWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSNAMERF"));
            wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkInventoryDataUpdateWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkInventoryDataUpdateWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
            wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
            wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPCUSTOMERCODERF"));
            wkInventoryDataUpdateWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPCUSTOMERNAMERF"));
            wkInventoryDataUpdateWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPCUSTOMERNAME2RF"));
            wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
            wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
            wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
            wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
            wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
            wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYNEWDIVRF"));
            wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
            wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYSTOCKPRICERF"));
            wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYTLRNCPRICERF"));
            // 2008.03.07 Add >>>>>>>>
            wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
            wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALEXCRF"));
            wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOLERANCEUPDATECDRF"));
            // 2008.03.07 Add <<<<<<<<
            wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STATUSRF"));
            */
            #endregion
            wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
            wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkInventoryDataUpdateWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            wkInventoryDataUpdateWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkInventoryDataUpdateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
            wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
            wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPCUSTOMERCODERF"));
            wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
            wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
            wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
            wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
            wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
            wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYNEWDIVRF"));
            wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
            wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYSTOCKPRICERF"));
            wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYTLRNCPRICERF"));
            wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
            wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALEXECRF"));
            wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOLERANCEUPDATECDRF"));
            wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STATUSRF"));
            // �C�� 2008/09/19 <<<
            #endregion

            return wkInventoryDataUpdateWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="inventoryData">�I���f�[�^</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>InventoryExcDefUpdateWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromInventoryReader(InventoryDataUpdateWork inventoryData, ref SqlDataReader myReader)
        {
            StockWork wkStockWork = new StockWork();

            #region �N���X�֊i�[
            // �C�� 2008/09/19 ���C�A�E�g�ύX�ɂ��C�� >>>
            #region �C���O
            /*
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkStockWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //wkStockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //wkStockWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkStockWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkStockWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkStockWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkStockWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            //wkStockWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            //wkStockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            */ 
            #endregion
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //wkStockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            //wkStockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            //wkStockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            //wkStockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            // �C�� 2008/09/19 <<<

            #endregion

            return wkStockWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.07.17</br>
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

        #region �ʔԍŏI�ԍ��擾
        /// <summary>
        /// �I�������f�[�^���̒ʔԍŏI�ԍ���߂��܂�
        /// </summary>
        /// <param name="MaxInventorySeqCount">�ʔԍŏI�ԍ�</param>
        /// <param name="inventoryDataUpdateWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�������f�[�^���̒ʔԍŏI�ԍ���߂��܂�</br>
        /// <br>Programmer : Yokokawa</br>
        /// <br>Date       : 2007.10.05</br>
        private int GetMaxInventorySeq(out int MaxInventorySeqCount, InventoryDataUpdateWork inventoryDataUpdateWork, ref SqlConnection sqlConnection /*, ref SqlTransaction sqlTrans*/)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            MaxInventorySeqCount = 0;
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection/*, sqlTrans*/))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        MaxInventorySeqCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNO_MAX"));
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryDataUpdateDB.GetMaxInventorySeq Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion
    }
}

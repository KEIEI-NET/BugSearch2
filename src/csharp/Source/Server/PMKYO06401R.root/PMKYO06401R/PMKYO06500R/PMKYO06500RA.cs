//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M�����@                           �@ //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06500R.DLL							        //
// Programmer       :   ������	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2009.06.12�@							//
//                  :   public Method��SQL�������ʖڑΉ��ɂ���        //
//----------------------------------------------------------------------//
// Update Note      :   �������@2011.07.26�@							//
//                  :   SCM�Ή�-���_�Ǘ��i10704767-00�j                 //
//----------------------------------------------------------------------//
// Update Note      :   �g���Y�@2011.08.20�@							//
//                  :   myReader����D�N���X�֍��ړ]�L���s���Ă����   //
//                  :   �̓��\�b�h������                                //
//----------------------------------------------------------------------//
// Update Note      :   �������@2011.08.25�@							//
//                  :   #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�//
//----------------------------------------------------------------------//
// Update Note      :   ���仁@2011.08.26�@							//
//                  :   DC�������O��DC�e�f�[�^�̃N���A������ǉ�        //
//----------------------------------------------------------------------//
// Update Note      :   �������@2011.09.02�@							//
//                  :   �@#24364 �݌Ƀ}�X�^�̎d����w��ɂ���         //
//                      �A#24358 �݌ɒ��o�����Łu�O���[�v�R�[�h�v       //
//                               ���w�肷��Ƒ��M�ł��Ȃ�               //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockDB : RemoteDB
    {
        #region [Private]
        private int _indexCreateDateTime;
        private int _indexUpdateDateTime;
        private int _indexEnterpriseCode;
        private int _indexFileHeaderGuid;
        private int _indexUpdEmployeeCode;
        private int _indexUpdAssemblyId1;
        private int _indexUpdAssemblyId2;
        private int _indexLogicalDeleteCode;
        private int _indexSectionCode;
        private int _indexWarehouseCode;
        private int _indexGoodsMakerCd;
        private int _indexGoodsNo;
        private int _indexStockUnitPriceFl;
        private int _indexSupplierStock;
        private int _indexAcpOdrCount;
        private int _indexMonthOrderCount;
        private int _indexSalesOrderCount;
        private int _indexStockDiv;
        private int _indexMovingSupliStock;
        private int _indexShipmentPosCnt;
        private int _indexStockTotalPrice;
        private int _indexLastStockDate;
        private int _indexLastSalesDate;
        private int _indexLastInventoryUpdate;
        private int _indexMinimumStockCnt;
        private int _indexMaximumStockCnt;
        private int _indexNmlSalOdrCount;
        private int _indexSalesOrderUnit;
        private int _indexStockSupplierCode;
        private int _indexGoodsNoNoneHyphen;
        private int _indexWarehouseShelfNo;
        private int _indexDuplicationShelfNo1;
        private int _indexDuplicationShelfNo2;
        private int _indexPartsManagementDivide1;
        private int _indexPartsManagementDivide2;
        private int _indexStockNote1;
        private int _indexStockNote2;
        private int _indexShipmentCnt;
        private int _indexArrivalCnt;
        private int _indexStockCreateDate;
        private int _indexUpdateDate;
        #endregion
        /// <summary>
        /// �݌Ƀ}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCStockDB()
            : base("PMKYO06501D", "Broadleaf.Application.Remoting.ParamData.DCStockWork", "STOCKRF")
        {

        }

        #region [Read]
        /// <summary>
        /// �݌Ƀ}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockArrList">�݌Ƀ}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public int SearchStock(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            return SearchStockProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                            sqlTransaction, out stockArrList, out retMessage);
        }
        /// <summary>
        /// �݌Ƀ}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockArrList">�݌Ƀ}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private int SearchStockProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockArrList = new ArrayList();
            DCStockWork stockWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //�݌Ƀ}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockWork = new DCStockWork();

                    stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    stockArrList.Add(stockWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCStockDB.SearchStock Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion

        # region [Delete]
        /// <summary>
        ///  �݌Ƀ}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcStockWork">�݌Ƀ}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(DCStockWork dcStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  �݌Ƀ}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcStockWork">�݌Ƀ}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(DCStockWork dcStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcStockWork.EnterpriseCode;
            findParaWarehouseCode.Value = dcStockWork.WarehouseCode;
            findParaGoodsMakerCd.Value = dcStockWork.GoodsMakerCd;
            findParaGoodsNo.Value = dcStockWork.GoodsNo;


            // �݌Ƀ}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// �݌Ƀ}�X�^�o�^
        /// </summary>
        /// <param name="dcStockWork">�݌Ƀ}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(DCStockWork dcStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }

        /// <summary>
        /// �݌Ƀ}�X�^�o�^
        /// </summary>
        /// <param name="dcStockWork">�݌Ƀ}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(DCStockWork dcStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO STOCKRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @STOCKUNITPRICEFL, @SUPPLIERSTOCK, @ACPODRCOUNT, @MONTHORDERCOUNT, @SALESORDERCOUNT, @STOCKDIV, @MOVINGSUPLISTOCK, @SHIPMENTPOSCNT, @STOCKTOTALPRICE, @LASTSTOCKDATE, @LASTSALESDATE, @LASTINVENTORYUPDATE, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @NMLSALODRCOUNT, @SALESORDERUNIT, @STOCKSUPPLIERCODE, @GOODSNONONEHYPHEN, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @PARTSMANAGEMENTDIVIDE1, @PARTSMANAGEMENTDIVIDE2, @STOCKNOTE1, @STOCKNOTE2, @SHIPMENTCNT, @ARRIVALCNT, @STOCKCREATEDATE, @UPDATEDATE)";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
            SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
            SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
            SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
            SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
            SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
            SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
            SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
            SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
            SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
            SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
            SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
            SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
            SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
            SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
            SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
            SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
            SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
            SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
            SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
            SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
            SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
            SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
            SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
            SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
            SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
            SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcStockWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcStockWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockWork.SectionCode);
            }
            if (string.IsNullOrEmpty(dcStockWork.WarehouseCode.Trim()))
            {
                paraWarehouseCode.Value = dcStockWork.WarehouseCode;
            }
            else
            {
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcStockWork.WarehouseCode);
            }
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(dcStockWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = dcStockWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockWork.GoodsNo);
            }
            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockWork.StockUnitPriceFl);
            paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(dcStockWork.SupplierStock);
            paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(dcStockWork.AcpOdrCount);
            paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(dcStockWork.MonthOrderCount);
            paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(dcStockWork.SalesOrderCount);
            paraStockDiv.Value = SqlDataMediator.SqlSetInt32(dcStockWork.StockDiv);
            paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(dcStockWork.MovingSupliStock);
            paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(dcStockWork.ShipmentPosCnt);
            paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(dcStockWork.StockTotalPrice);
            paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockWork.LastStockDate);
            paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockWork.LastSalesDate);
            paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockWork.LastInventoryUpdate);
            paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(dcStockWork.MinimumStockCnt);
            paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(dcStockWork.MaximumStockCnt);
            paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(dcStockWork.NmlSalOdrCount);
            paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(dcStockWork.SalesOrderUnit);
            paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(dcStockWork.StockSupplierCode);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(dcStockWork.GoodsNoNoneHyphen);
            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(dcStockWork.WarehouseShelfNo);
            paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(dcStockWork.DuplicationShelfNo1);
            paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(dcStockWork.DuplicationShelfNo2);
            paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(dcStockWork.PartsManagementDivide1);
            paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(dcStockWork.PartsManagementDivide2);
            paraStockNote1.Value = SqlDataMediator.SqlSetString(dcStockWork.StockNote1);
            paraStockNote2.Value = SqlDataMediator.SqlSetString(dcStockWork.StockNote2);
            paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(dcStockWork.ShipmentCnt);
            paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(dcStockWork.ArrivalCnt);
            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockWork.StockCreateDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockWork.UpdateDate);


            // �݌Ƀ}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        /// <summary>
        /// �݌Ƀ}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockArrList">�݌Ƀ}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchStock(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            return SearchStockProc(enterpriseCodes, paramList, sqlConnection,
                            sqlTransaction, out stockArrList, out retMessage);
        }
        /// <summary>
        /// �݌Ƀ}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="stockArrList">�݌Ƀ}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchStockProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockArrList = new ArrayList();
            //DCStockWork stockWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StockProcParamWork param = paramList as StockProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region DEL SQL
                //DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------------------------->>>>>
                //sqlStr = "SELECT STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ";
                //sqlStr += " FROM STOCKRF LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ";
                //sqlStr += " WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //-----DEL 2011/08/20�r���[�i�`�F�b�N�G���[----->>>>>
                //    //sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //-----DEL 2011/08/20�r���[�i�`�F�b�N�G���[-----<<<<<
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //-----DEL 2011/08/20�r���[�i�`�F�b�N�G���[----->>>>>
                //    //sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //-----DEL 2011/08/20�r���[�i�`�F�b�N�G���[-----<<<<<
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF";
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF";
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF";
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF";
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF";
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF";
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////Order By Key
                //sqlStr += " ORDER BY STOCKRF.UPDATEDATETIMERF DESC";
                //DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------------------------<<<<<
                #endregion
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------------------------->>>>>
                //sqlStr.Append("SELECT STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ");//DEL 2011/09/02 #24364
                sqlStr.Append("SELECT DISTINCT STOCKRF.ENTERPRISECODERF+','+STOCKRF.WAREHOUSECODERF+','+STR(STOCKRF.GOODSMAKERCDRF)+','+STOCKRF.GOODSNORF AS STOCKPK, STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ");//ADD 2011/09/02 #24364
                sqlStr.Append(" FROM STOCKRF ");
                //if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 #24364
                if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 #24364
                {
                    //sqlStr.Append("LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF ");//DEL 2011/09/02 #24364
                    sqlStr.Append(" LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND (STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF OR GOODSMNGRF.SECTIONCODERF=@FINDSECTIONCODE) AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND (STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF OR GOODSMNGRF.GOODSNORF = '' OR GOODSMNGRF.GOODSNORF IS NULL) ");//ADD 2011/09/02 #24364
                }
                if (param.BLGloupCodeBeginRF != 0 || param.BLGloupCodeEndRF != 0)
                {
                    //sqlStr.Append("LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ");//DEL 2011/09/02 �A#24358
                    sqlStr.Append(" LEFT JOIN GOODSURF ON STOCKRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND STOCKRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND STOCKRF.GOODSNORF=GOODSURF.GOODSNORF");//ADD 2011/09/02 �A#24358
                    sqlStr.Append(" LEFT JOIN BLGOODSCDURF ON BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND BLGOODSCDURF.BLGOODSCODERF= GOODSURF.BLGOODSCODERF ");//ADD 2011/09/02 �A#24358
                }
                sqlStr.Append(" WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF");
                    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF");
                    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF");
                    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF");
                    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                }
                if (param.GoodsMakerCdBeginRF != 0)
                {
                    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                }

                if (param.GoodsMakerCdEndRF != 0)
                {
                    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                }
                if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF");
                    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.GOODSNORF <= @GOODSNOENDRF");
                    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                }

                //if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 �A#24358
                if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 �A#24358
                {
                    if (param.SupplierCdBeginRF != 0)
                    {
                        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                        SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                        supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                    }

                    if (param.SupplierCdEndRF != 0)
                    {
                        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                        SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                        supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                    }
                }

                if (param.BLGloupCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF");
                    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                }

                if (param.BLGloupCodeEndRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF");
                    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                }

                //Order By Key
                sqlStr.Append(" ORDER BY STOCKRF.UPDATEDATETIMERF DESC, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF");
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------------------------<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);//ADD 2011/09/02 #24364

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString("00");//ADD 2011/09/02 #24364

                //�݌Ƀ}�X�^�f�[�^�pSQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�---->>>>>
                if (myReader.HasRows)
                {
                    SetStockIndex(myReader);
                }
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�-----<<<<<
                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
                    //stockWork = new DCStockWork();

                    //stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    //stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    //stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    //stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    //stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    //stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    //stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    //stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    //stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    //stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    //stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    //stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    //stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    //stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    //stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    //stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    //stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    //stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    //stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    //stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    //stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    //stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    //stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    //stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    //stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    //stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    //stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    //stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    //stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    //stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    //stockArrList.Add(stockWork);
                    //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
                    #endregion DEL
                    stockArrList.Add(CopyFromMyReaderToDCStockWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCStockDB.SearchStock Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        /// <summary>
        /// �݌Ƀ}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�݌Ƀ}�X�^�f�[�^</returns>
        /// <br>Note       : �݌Ƀ}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private DCStockWork CopyFromMyReaderToDCStockWork(SqlDataReader myReader)
        {
            DCStockWork stockWork = new DCStockWork();

            #region DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            //stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            //stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            //stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            //stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            //stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            //stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            //stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            //stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            //stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            //stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            //stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            //stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            //stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            //stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            //stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            //stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            //stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            //stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            //stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            //stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            //stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            //stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            //stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            //stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            //stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            //stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            //stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            //stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            //stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            #endregion

            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� --------------------------->>>>>
            stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCreateDateTime);
            stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexUpdateDateTime);
            stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexEnterpriseCode);
            stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexFileHeaderGuid);
            stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexUpdEmployeeCode);
            stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexUpdAssemblyId1);
            stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexUpdAssemblyId2);
            stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexLogicalDeleteCode);
            stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _indexSectionCode);
            stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, _indexWarehouseCode);
            stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexGoodsMakerCd);
            stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _indexGoodsNo);
            stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, _indexStockUnitPriceFl);
            stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, _indexSupplierStock);
            stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, _indexAcpOdrCount);
            stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, _indexMonthOrderCount);
            stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, _indexSalesOrderCount);
            stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, _indexStockDiv);
            stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, _indexMovingSupliStock);
            stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, _indexShipmentPosCnt);
            stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, _indexStockTotalPrice);
            stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastStockDate);
            stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastSalesDate);
            stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastInventoryUpdate);
            stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, _indexMinimumStockCnt);
            stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, _indexMaximumStockCnt);
            stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, _indexNmlSalOdrCount);
            stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, _indexSalesOrderUnit);
            stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, _indexStockSupplierCode);
            stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, _indexGoodsNoNoneHyphen);
            stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, _indexWarehouseShelfNo);
            stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, _indexDuplicationShelfNo1);
            stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, _indexDuplicationShelfNo2);
            stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, _indexPartsManagementDivide1);
            stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, _indexPartsManagementDivide2);
            stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, _indexStockNote1);
            stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, _indexStockNote2);
            stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, _indexShipmentCnt);
            stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, _indexArrivalCnt);
            stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexStockCreateDate);
            stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexUpdateDate);
            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� ---------------------------<<<<<

            return stockWork;
        }
        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<

        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetStockIndex(SqlDataReader myReader)
        {
            _indexCreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _indexUpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _indexEnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _indexFileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _indexUpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _indexUpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _indexUpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _indexLogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _indexSectionCode = myReader.GetOrdinal("SECTIONCODERF");
            _indexWarehouseCode = myReader.GetOrdinal("WAREHOUSECODERF");
            _indexGoodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
            _indexGoodsNo = myReader.GetOrdinal("GOODSNORF");
            _indexStockUnitPriceFl = myReader.GetOrdinal("STOCKUNITPRICEFLRF");
            _indexSupplierStock = myReader.GetOrdinal("SUPPLIERSTOCKRF");
            _indexAcpOdrCount = myReader.GetOrdinal("ACPODRCOUNTRF");
            _indexMonthOrderCount = myReader.GetOrdinal("MONTHORDERCOUNTRF");
            _indexSalesOrderCount = myReader.GetOrdinal("SALESORDERCOUNTRF");
            _indexStockDiv = myReader.GetOrdinal("STOCKDIVRF");
            _indexMovingSupliStock = myReader.GetOrdinal("MOVINGSUPLISTOCKRF");
            _indexShipmentPosCnt = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
            _indexStockTotalPrice = myReader.GetOrdinal("STOCKTOTALPRICERF");
            _indexLastStockDate = myReader.GetOrdinal("LASTSTOCKDATERF");
            _indexLastSalesDate = myReader.GetOrdinal("LASTSALESDATERF");
            _indexLastInventoryUpdate = myReader.GetOrdinal("LASTINVENTORYUPDATERF");
            _indexMinimumStockCnt = myReader.GetOrdinal("MINIMUMSTOCKCNTRF");
            _indexMaximumStockCnt = myReader.GetOrdinal("MAXIMUMSTOCKCNTRF");
            _indexNmlSalOdrCount = myReader.GetOrdinal("NMLSALODRCOUNTRF");
            _indexSalesOrderUnit = myReader.GetOrdinal("SALESORDERUNITRF");
            _indexStockSupplierCode = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
            _indexGoodsNoNoneHyphen = myReader.GetOrdinal("GOODSNONONEHYPHENRF");
            _indexWarehouseShelfNo = myReader.GetOrdinal("WAREHOUSESHELFNORF");
            _indexDuplicationShelfNo1 = myReader.GetOrdinal("DUPLICATIONSHELFNO1RF");
            _indexDuplicationShelfNo2 = myReader.GetOrdinal("DUPLICATIONSHELFNO2RF");
            _indexPartsManagementDivide1 = myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF");
            _indexPartsManagementDivide2 = myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF");
            _indexStockNote1 = myReader.GetOrdinal("STOCKNOTE1RF");
            _indexStockNote2 = myReader.GetOrdinal("STOCKNOTE2RF");
            _indexShipmentCnt = myReader.GetOrdinal("SHIPMENTCNTRF");
            _indexArrivalCnt = myReader.GetOrdinal("ARRIVALCNTRF");
            _indexStockCreateDate = myReader.GetOrdinal("STOCKCREATEDATERF");
            _indexUpdateDate = myReader.GetOrdinal("UPDATEDATERF");
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="count">�������ʌ���</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������ʌ�����߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/07/26</br>
        public int SearchStockCount(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, ref int count, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StockProcParamWork param = paramList as StockProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region DEL SQL
                //sqlStr = "SELECT COUNT(STOCKRF.ENTERPRISECODERF)";
                //sqlStr += " FROM STOCKRF LEFT JOIN GOODSMNGRF ON STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.BLGOODSCODERFRF= BLGOODSCDURF.BLGOODSCODERFRF ";
                //sqlStr += " WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF";
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF";
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF";
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF";
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF";
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF";
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                #endregion
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------------------------->>>>>
                //sqlStr.Append("SELECT COUNT(STOCKRF.ENTERPRISECODERF) ");//DEL 2011/09/02 #24364
                sqlStr.Append("SELECT COUNT(DISTINCT STOCKRF.ENTERPRISECODERF+','+STOCKRF.WAREHOUSECODERF+','+STR(STOCKRF.GOODSMAKERCDRF)+','+STOCKRF.GOODSNORF )");//ADD 2011/09/02 #24364
                sqlStr.Append(" FROM STOCKRF ");
                //if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 #24364
                if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 #24364
                {
                    //sqlStr.Append("LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF ");//DEL 2011/09/02 #24364
                    sqlStr.Append(" LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND (STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF OR GOODSMNGRF.SECTIONCODERF=@FINDSECTIONCODE) AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND (STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF OR GOODSMNGRF.GOODSNORF = '' OR GOODSMNGRF.GOODSNORF IS NULL) ");//ADD 2011/09/02 #24364
                }
                if (param.BLGloupCodeBeginRF != 0 || param.BLGloupCodeEndRF != 0)
                {
                    //sqlStr.Append("LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ");//DEL 2011/09/02 �A#24358
                    sqlStr.Append(" LEFT JOIN GOODSURF ON STOCKRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND STOCKRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND STOCKRF.GOODSNORF=GOODSURF.GOODSNORF");//ADD 2011/09/02 �A#24358
                    sqlStr.Append(" LEFT JOIN BLGOODSCDURF ON BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND BLGOODSCDURF.BLGOODSCODERF= GOODSURF.BLGOODSCODERF ");//ADD 2011/09/02 �A#24358
                }
                sqlStr.Append(" WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF");
                    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF");
                    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF");
                    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                }

                if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF");
                    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                }
                if (param.GoodsMakerCdBeginRF != 0)
                {
                    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                }

                if (param.GoodsMakerCdEndRF != 0)
                {
                    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                }
                if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                {
                    sqlStr.Append(" AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF");
                    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                {
                    sqlStr.Append(" AND STOCKRF.GOODSNORF <= @GOODSNOENDRF");
                    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                }

                //if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 �A#24358
                if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 �A#24358
                {
                    if (param.SupplierCdBeginRF != 0)
                    {
                        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                        SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                        supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                    }

                    if (param.SupplierCdEndRF != 0)
                    {
                        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                        SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                        supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                    }
                }

                if (param.BLGloupCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF");
                    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                }

                if (param.BLGloupCodeEndRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF");
                    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                }
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------------------------<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);//ADD 2011/09/02 #24364

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString("00");//ADD 2011/09/02 #24364

                //�݌Ƀ}�X�^�f�[�^�pSQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�

                // �ǂݍ���
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCStockDB.SearchStockCount Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j

		// ADD 2011.08.26 ---------->>>>>
        # region [Clear]DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// R�N���X�� Method��SQL�������ʖ�
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //}
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Delete�R�}���h�̐���
        //    sqlCommand.CommandText = "DELETE FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
        //    //Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //    findParaEnterpriseCode.Value = enterpriseCode;

        //    // ���_���ݒ�}�X�^�f�[�^���폜����
        //    sqlCommand.ExecuteNonQuery();
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
        #endregion
        // ADD 2011.08.26 ----------<<<<<
    }
}
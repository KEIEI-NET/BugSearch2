using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����c�N���ADB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c�N���A�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/16 ������</br>
    /// <br>Date       : ���i�Ǘ����}�X�^�̎d������Q�Ƃ���悤�ɕύX</br>
    /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>Update Note: 2010/08/02 22018 ��� ���b</br>
    /// <br>           : �݌Ƀ}�X�^�̔����c�͎d���f�[�^�������Z�����Ƀ[�����Œ�ŃZ�b�g����悤�ύX</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : ��ʂŎd�����͈͎w�肵�Ă��S�f�[�^�̔����c���N���A�����s��C��</br>
    /// </remarks>
    [Serializable]
    public class SalesOrderRemainClearDB : RemoteWithAppLockDB, ISalesOrderRemainClearDB
    {
        /// <summary>
        /// �����c�N���ADB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public SalesOrderRemainClearDB()
            :
            base("PMZAI02046D", "Broadleaf.Application.Remoting.ParamData.ExtrInfo_SalesOrderRemainClearWork", "SALESORDERREMAINCLEARRF")
        {
        }

        #region [SearchUpdate]
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        public int SearchUpdate(object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                return SearchUpdateSalesOrderRemainClear(extrInfo_SalesOrderRemainClearWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
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
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̔�������
        /// �O�ōX�V���܂��B(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchUpdateSalesOrderRemainClear(object objExtrInfo_SalesOrderRemainClearWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // �����c�N���A�f�[�^���擾
            status = SearchSalesOrderRemainClearProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �݌Ƀ}�X�^�X�V
                if (stockWorkList.Count > 0)
                {
                    // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                    Dictionary<string, string> wareList = new Dictionary<string, string>(); //�q�Ƀ��X�g 

                    StockWork _stockWork = stockWorkList[0] as StockWork;
                    foreach (StockWork st in stockWorkList)
                    {
                        if (wareList.ContainsKey(st.WarehouseCode.Trim()) == false)
                        {
                            wareList.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                        }
                    }
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(_stockWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        infoList.Add(info);
                        if (st != 0) return st;
                    }
                    // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    StockDB stockDB = new StockDB();

                    status = stockDB.WriteStockProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);

                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    foreach (ShareCheckInfo info in infoList)
                    {
                        status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    }
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // �R�~�b�g
                sqlTransaction.Commit();
            else
            {
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }


            return status;
        }
        #endregion  //Search

        #region [SearchStockMasterTblProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchSalesOrderRemainClearProc(out ArrayList stockWorkList, ExtrInfo_SalesOrderRemainClearWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF AS GOODS ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockMasterTblProc

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_SalesOrderRemainClearWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// <br>Update Note: 2009/12/16 ������</br>
        /// <br>Date       : ���i�Ǘ����}�X�^�̎d������Q�Ƃ���悤�ɕύX</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            //�J�n�q�ɃR�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_WarehouseCode != "")
            {
                retString.Append("AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE ");
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.St_WarehouseCode);
            }

            //�I���q�ɃR�[�h
            if (extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode != "9999")
            {
                //retString.Append("AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)");
                //SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                //paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode + "%");
                retString.Append("AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE ");
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode);
            }

            //�J�n�d����R�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_SupplierCd != 0)
            {
                // ---------DEL 2009/12/16---------->>>>>
                //retString.Append("AND STOCK.STOCKSUPPLIERCODERF>=@STSUPPLIERCD ");
                //SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                //paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_SupplierCd);
                // ---------DEL 2009/12/16----------<<<<<
            }

            //�I���d����R�[�h
            if (extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd != 999999)
            {
                // ---------DEL 2009/12/16---------->>>>>
                //retString.Append("AND STOCK.STOCKSUPPLIERCODERF<=@EDSUPPLIERCD ");
                //SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                //paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd);
                // ---------DEL 2009/12/16----------<<<<<
            }

            //�J�n���[�J�[�R�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd != 0)
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD ");
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd);
            }

            //�I�����[�J�[�R�[�h
            // --- UPD m.suzuki 2010/08/02 ---------->>>>>
            //if (extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 9999)
            if ( extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 9999 && extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 0 )
            // --- UPD m.suzuki 2010/08/02 ----------<<<<<
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD ");
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd);
            }

            //�J�nBL���i�R�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode != 0)
            {
                retString.Append("AND GOODS.BLGOODSCODERF>=@STBLGOODSCODE ");
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode);
            }
        
            //�I��BL���i�R�[�h
            // --- UPD m.suzuki 2010/08/02 ---------->>>>>
            //if (extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 99999)
            if ( extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 99999 && extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 0 )
            // --- UPD m.suzuki 2010/08/02 ----------<<<<<
            {
                retString.Append("AND GOODS.BLGOODSCODERF<=@EDBLGOODSCODE ");
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode);
            }

            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>StockWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, ExtrInfo_SalesOrderRemainClearWork paramWork)
        {
            StockWork wkStockWork = new StockWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
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
                wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                wkStockWork.SalesOrderCount = 0;
                wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                # endregion
            }

            return wkStockWork;
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
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

        // ----------------ADD 2009/12/16--------------->>>>>
        #region[Search]
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̎擾���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        public int Search(out object rsultList, object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateSalesOrderRemain(extrInfo_SalesOrderRemainClearWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̎擾���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private int SearchUpdateSalesOrderRemain(object objExtrInfo_SalesOrderRemainClearWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // �����c�N���A�f�[�^���擾
            status = SearchSalesOrderRemainClearProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B�B
        /// </summary>
        /// <remarks>
        /// <param name="resultList">resultList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        // ----------------UPD 2010/06/08--------------->>>>>
        //public int Update(object resultList)
        public int Update(object resultList, object stockDetailWork)
        // ----------------UPD 2010/06/08---------------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList al = resultList as ArrayList;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = this.UpdateProc(al, ref sqlConnection, ref sqlTransaction);

                // ----------------ADD 2010/06/08--------------->>>>>
                IOWriteMASIRDB ioWrite = new IOWriteMASIRDB();
                StockDetailWork stockDetailWk = stockDetailWork as StockDetailWork;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = ioWrite.UpdateStockDetail(ref stockDetailWk, ref sqlConnection, ref sqlTransaction);
                }
                // ----------------ADD 2010/06/08---------------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        
        // -----------------ADD 2011/04/11 --------------------->>>>>
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B�B
        /// </summary>
        /// <remarks>
        /// <param name="resultList">resultList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        public int Update(object resultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList al = resultList as ArrayList;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = this.UpdateProc(al, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        // -----------------ADD 2011/04/11 ---------------------<<<<<
        
        /// <summary>
        /// ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B�B
        /// </summary>
        /// <remarks>
        /// <param name="resultList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀf�[�^�̔��������O�ōX�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private int UpdateProc(ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // �V�X�e�����b�N(�q��)
            ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
            Dictionary<string, string> wareList = new Dictionary<string, string>(); //�q�Ƀ��X�g 
            StockWork _stockWork = resultList[0] as StockWork;
            foreach (StockWork st in resultList)
            {
                if (wareList.ContainsKey(st.WarehouseCode.Trim()) == false)
                {
                    wareList.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                }
            }
            foreach (string wCode in wareList.Keys)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_stockWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                infoList.Add(info);
                if (st != 0) return st;
            }
            // �V�X�e�����b�N(�q��)

            StockDB stockDB = new StockDB();

            status = stockDB.WriteStockProc(ref resultList, ref sqlConnection, ref sqlTransaction);

            // �V�X�e�����b�N����(�q��)
            foreach (ShareCheckInfo info in infoList)
            {
                status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
            }
            // �V�X�e�����b�N����(�q��) 

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �R�~�b�g
                sqlTransaction.Commit();
            }
            else
            {
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            return status;
        }
        #endregion
        // ----------------ADD 2009/12/16---------------<<<<<

        // ----------------ADD 2010/06/08--------------->>>>>
        #region[SearchStockDetail]
        /// <summary>
        /// �d�����׃f�[�^����Ώۖ��ׂ̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����d�����׃f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int SearchStockDetail(out object rsultList, object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateStockDetail(extrInfo_SalesOrderRemainClearWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion

        #region[SearchStock]
        /// <summary>
        /// �݌Ƀ}�X�^�f�[�^����Ώۖ��ׂ̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����݌Ƀ}�X�^�f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int SearchStock(out object rsultList, object extrInfo_StockDetailWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateStock(extrInfo_StockDetailWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion

        /// <summary>
        /// ���o�����ɍ��v�����d�����׃f�[�^�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����d�����׃f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchUpdateStockDetail(object objExtrInfo_SalesOrderRemainClearWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // �����c�N���A�f�[�^���擾
            status = SearchStockDetailProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }

        /// <summary>
        /// ���o�����ɍ��v�����d�����׃f�[�^�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">�����p�����[�^</param>
        /// <param name="resultList">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɍ��v�����d�����׃f�[�^�̎擾���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchUpdateStock(object extrInfo_StockDetailWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            StockDetailWork paramWork = null;

            ArrayList paramWorkList = extrInfo_StockDetailWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = extrInfo_StockDetailWork as StockDetailWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as StockDetailWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // �����c�N���A�f�[�^���擾
            status = SearchStockProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }

        #region [SearchStockDetailProc]
        /// <summary>
        /// �w�肳�ꂽ�����̎d�����ה����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����ה����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        private int SearchStockDetailProc(out ArrayList stockWorkList, ExtrInfo_SalesOrderRemainClearWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKDETAIL.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERFORMALSRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKINPUTCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKINPUTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKAGENTCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKAGENTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.MAKERKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.CMPLTMAKERKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSRATERANKRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.CUSTRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATESECTSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEDIVSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.PRICECDSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FRACPROCSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITCHNGDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BFLISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERADJUSTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERREMAINCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.REMAINCNTUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICETAXINCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKGOODSCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.TAXATIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESCUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.DIRECTSENDINGCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERNUMBERRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAYTOORDERRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.EXPECTDELIVERYDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERDATACREATEDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERDATACREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERFORMISSUEDDIVRF" + Environment.NewLine;
                selectTxt += "FROM STOCKDETAILRF AS STOCKDETAIL" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeStockDetailWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockDetailWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockDetailProc

        #region [SearchStockMasterTblProc]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɔ����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɔ����c�N���A�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        private int SearchStockProc(out ArrayList stockWorkList, StockDetailWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                //selectTxt += " LEFT JOIN GOODSURF AS GOODS ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeStockWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockMasterTblProc

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_SalesOrderRemainClearWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        private string MakeStockDetailWhereString(ref SqlCommand sqlCommand, ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCKDETAIL.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND STOCKDETAIL.LOGICALDELETECODERF=0 ");

            //�d���`��
            retString.Append("AND STOCKDETAIL.SUPPLIERFORMALRF=2 ");

            //�J�n�q�ɃR�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_WarehouseCode != "")
            {
                retString.Append("AND STOCKDETAIL.WAREHOUSECODERF>=@STWAREHOUSECODE ");
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.St_WarehouseCode);
            }

            //�I���q�ɃR�[�h
            if (extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode != "9999")
            {
                retString.Append("AND STOCKDETAIL.WAREHOUSECODERF<=@EDWAREHOUSECODE ");
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode);
            }

            //�����c��
            retString.Append("AND STOCKDETAIL.ORDERREMAINCNTRF<>0 ");

            //�J�n�d����R�[�h
            if (extrInfo_SalesOrderRemainClearWork.St_SupplierCd != 0)
            {
                retString.Append("AND STOCKDETAIL.SUPPLIERCDRF>=@STSUPPLIERCD ");
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_SupplierCd);
            }

            //�I���d����R�[�h
            if (extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd != 999999)
            {
                retString.Append("AND STOCKDETAIL.SUPPLIERCDRF<=@EDSUPPLIERCD ");
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd);
            }

            //�������@
            retString.Append("AND (STOCKDETAIL.WAYTOORDERRF=0 OR STOCKDETAIL.WAYTOORDERRF=1)");

            return retString.ToString();
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_StockDetailWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        private string MakeStockWhereString(ref SqlCommand sqlCommand, StockDetailWork extrInfo_StockDetailWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            //�q�ɃR�[�h
            retString.Append("AND STOCK.WAREHOUSECODERF=@WAREHOUSECODE ");
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.WarehouseCode);

            //���i���[�J�[�R�[�h
            retString.Append("AND STOCK.GOODSMAKERCDRF=@GOODSMAKERCD ");
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockDetailWork.GoodsMakerCd);

            //���i�ԍ�
            retString.Append("AND STOCK.GOODSNORF=@GOODSNO ");
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.GoodsNo);

            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>StockWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[����</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ExtrInfo_SalesOrderRemainClearWork paramWork)
        {
            StockDetailWork wkStockDetailWork = new StockDetailWork();
            

            if (myReader != null)
            {

                # region �N���X�֊i�[
                wkStockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AcceptAnOrderNoRF"));
                wkStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierFormalRF"));
                wkStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierSlipNoRF"));
                wkStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockRowNoRF"));
                wkStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SectionCodeRF"));
                wkStockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SubSectionCodeRF"));
                wkStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CommonSeqNoRF"));
                wkStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockSlipDtlNumRF"));
                wkStockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierFormalSrcRF"));
                wkStockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockSlipDtlNumSrcRF"));
                wkStockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AcptAnOdrStatusSyncRF"));
                wkStockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SalesSlipDtlNumSyncRF"));
                wkStockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockSlipCdDtlRF"));
                wkStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockInputCodeRF"));
                wkStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockInputNameRF"));
                wkStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockAgentCodeRF"));
                wkStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockAgentNameRF"));
                wkStockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsKindCodeRF"));
                wkStockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsMakerCdRF"));
                wkStockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MakerNameRF"));
                wkStockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MakerKanaNameRF"));
                wkStockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CmpltMakerKanaNameRF"));
                wkStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNoRF"));
                wkStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNameRF"));
                wkStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNameKanaRF"));
                wkStockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsLGroupRF"));
                wkStockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsLGroupNameRF"));
                wkStockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsMGroupRF"));
                wkStockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsMGroupNameRF"));
                wkStockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BLGroupCodeRF"));
                wkStockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BLGroupNameRF"));
                wkStockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BLGoodsCodeRF"));
                wkStockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BLGoodsFullNameRF"));
                wkStockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("EnterpriseGanreCodeRF"));
                wkStockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EnterpriseGanreNameRF"));
                wkStockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseCodeRF"));
                wkStockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseNameRF"));
                wkStockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseShelfNoRF"));
                wkStockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockOrderDivCdRF"));
                wkStockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OpenPriceDivRF"));
                wkStockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsRateRankRF"));
                wkStockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CustRateGrpCodeRF"));
                wkStockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SuppRateGrpCodeRF"));
                wkStockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("ListPriceTaxExcFlRF"));
                wkStockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("ListPriceTaxIncFlRF"));
                wkStockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockRateRF"));
                wkStockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateSectStckUnPrcRF"));
                wkStockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateDivStckUnPrcRF"));
                wkStockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UnPrcCalcCdStckUnPrcRF"));
                wkStockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PriceCdStckUnPrcRF"));
                wkStockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StdUnPrcStckUnPrcRF"));
                wkStockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("FracProcUnitStcUnPrcRF"));
                wkStockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FracProcStckUnPrcRF"));
                wkStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockUnitPriceFlRF"));
                wkStockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockUnitTaxPriceFlRF"));
                wkStockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockUnitChngDivRF"));
                wkStockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("BfStockUnitPriceFlRF"));
                wkStockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("BfListPriceRF"));
                wkStockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateBLGoodsCodeRF"));
                wkStockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateBLGoodsNameRF"));
                wkStockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateGoodsRateGrpCdRF"));
                wkStockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateGoodsRateGrpNmRF"));
                wkStockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateBLGroupCodeRF"));
                wkStockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateBLGroupNameRF"));
                wkStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockCountRF"));
                wkStockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("OrderCntRF"));
                wkStockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("OrderAdjustCntRF"));
                wkStockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OrderRemainCntRF"));
                wkStockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RemainCntUpdDateRF"));
                wkStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceTaxExcRF"));
                wkStockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceTaxIncRF"));
                wkStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockGoodsCdRF"));
                wkStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceConsTaxRF"));
                wkStockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TaxationCodeRF"));
                wkStockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockDtiSlipNote1RF"));
                wkStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SalesCustomerCodeRF"));
                wkStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SalesCustomerSnmRF"));
                wkStockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo1RF"));
                wkStockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo2RF"));
                wkStockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo3RF"));
                wkStockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo1RF"));
                wkStockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo2RF"));
                wkStockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo3RF"));
                wkStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierCdRF"));
                wkStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SupplierSnmRF"));
                wkStockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AddresseeCodeRF"));
                wkStockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("AddresseeNameRF"));
                wkStockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DirectSendingCdRF"));
                wkStockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OrderNumberRF"));
                wkStockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("WayToOrderRF"));
                wkStockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DeliGdsCmpltDueDateRF"));
                wkStockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ExpectDeliveryDateRF"));
                wkStockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OrderDataCreateDivRF"));
                wkStockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OrderDataCreateDateRF"));
                wkStockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OrderFormIssuedDivRF"));
                # endregion
            }

            return wkStockDetailWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>StockWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[����</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, StockDetailWork paramWork)
        {
            StockWork wkStockWork = new StockWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
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
                wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF")) - paramWork.OrderRemainCnt;
                wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                # endregion
            }

            return wkStockWork;
        }

        // ----------------ADD 2010/06/08---------------<<<<<
        // --- ADD m.suzuki 2010/08/02 ---------->>>>>
        /// <summary>
        /// �d�����׍X�V�����i�d���f�[�^�̂ݍX�V����j
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <returns></returns>
        public int UpdateStockDetail( object stockDetailWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if ( sqlConnection == null ) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );

                IOWriteMASIRDB ioWrite = new IOWriteMASIRDB();
                StockDetailWork stockDetailWk = stockDetailWork as StockDetailWork;

                status = ioWrite.UpdateStockDetail( ref stockDetailWk, ref sqlConnection, ref sqlTransaction );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SalesOrderRemainClearDB.UpdateStockDetail" );
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( sqlTransaction != null )
                {
                    if ( sqlTransaction.Connection != null )
                    {
                        sqlTransaction.Commit();
                    }
                    sqlTransaction.Dispose();
                }
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // --- ADD m.suzuki 2010/08/02 ----------<<<<<
    }

}

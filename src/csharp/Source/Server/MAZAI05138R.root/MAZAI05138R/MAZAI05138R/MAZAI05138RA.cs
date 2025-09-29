//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸数入力
// プログラム概要   : 得意先電子元帳 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  1002677-00  作成担当 : xuyb
// 作 成 日  2014/10/31  修正内容 : 仕掛№2133 Redmine#40336
//                                  新規登録の際のユニーク判定の項目に
//                                  棚卸日、メーカー、商品、棚番を追加
//                                  来勘分、貸出分以外の棚卸データを対象
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
using System.Diagnostics;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 棚卸数入力DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸数入力の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 22035 三橋 弘憲　  </br>
	/// <br>Date       : 2007.04.07</br>
	/// <br></br>
    /// <br>Update Note: 2007.09.12 Yokokawa  </br>
    /// <br>             流通.NS 用に改造</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>             新規入力時の棚卸通番の付番方法を変更</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>UpdateNote : 2011/01/30 鄧潘ハン </br>
    /// <br>             障害報告 #18764</br>
    /// <br>UpdateNote : 2011/02/12 朱猛 </br>
    /// <br>             障害報告 #18877</br>
    /// <br>UpdateNote : 2011/02/15 朱猛 </br>
    /// <br>             障害報告 #18877</br>
    /// <br>Update Note: 2013/03/01 yangyi</br>
    /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
    /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>

    /// </remarks>
	[Serializable]
	public class InventoryDataUpdateDB : RemoteDB , IInventoryDataUpdateDB
	{
		/// <summary>
		/// 棚卸数入力DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
        /// <br>Update Note: 2007.09.12 Yokokawa  </br>
        /// <br>             流通.NS 用に改造</br>
        /// </remarks>
		public InventoryDataUpdateDB() :
            base("MAZAI05136D", "Broadleaf.Application.Remoting.ParamData.InventoryDataUpdateWork", "INVENTORYDATARF")
		{
        }

        #region Write
        /// <summary>
		/// 棚卸数入力を登録、更新します
		/// </summary>
        /// <param name="paraList">InventoryDataUpdateWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 棚卸数入力情報を登録、更新します</br>
		/// <br>Programmer : 22035 三橋 弘憲　  </br>
		/// <br>Date       : 2007.04.07</br>
        /// <br>Update Note: 2007.09.12 Yokokawa  </br>
        /// <br>             流通.NS 用に改造</br>
        public int Write(ref object paraList)
		{
            return this.WriteProc(ref paraList);
        }

        /// <summary>
        /// 棚卸数入力を登録、更新します
        /// </summary>
        /// <param name="paraList">InventoryDataUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸数入力情報を登録、更新します</br>
        /// <br>Programmer : 22035 三橋 弘憲　  </br>
        /// <br>Date       : 2007.04.07</br>
        /// <br>Update Note: 2007.09.12 Yokokawa  </br>
        /// <br>             流通.NS 用に改造</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸準備処理日付の変更</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン </br>
        /// <br>             障害報告 #18764</br>
        /// <br>UpdateNote : 2011/02/12 朱猛 </br>
        /// <br>             障害報告 #18877</br>
        /// <br>UpdateNote : 2011/02/15 朱猛 </br>
        /// <br>             障害報告 #18877</br>
        /// <br>UpdateNote : 2014/10/31 xuyb </br>
        /// <br>             仕掛№2133 Redmine#40336</br>
        private int WriteProc(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                ArrayList retal = new ArrayList();
                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XMLの読み込み
                    ArrayList inventoryDataUpdateWorkList = paraList as ArrayList;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    foreach (InventoryDataUpdateWork inventoryDataUpdateWork in inventoryDataUpdateWorkList)
                    {
                        try
                        {
                            // 論理削除区分チェック(0:登録処理,3:削除処理)
                            if (inventoryDataUpdateWork.LogicalDeleteCode == 0)
                            {
                                #region 登録処理
                                // -------------------- ADD xuyb 2014/10/31 Redmine#40336 ------------------------->>>>>
                                if (inventoryDataUpdateWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    #region 新規登録場合
                                    using (SqlCommand sqlCommand = new SqlCommand(string.Empty, sqlConnection))
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine
                                            + " FROM INVENTORYDATARF " + Environment.NewLine
                                            + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine
                                            + " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine
                                            + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine
                                            + " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine
                                            + " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine
                                            + " AND INVENTORYDATERF=@FINDINVENTORYDATE" + Environment.NewLine
                                            + " AND (WAREHOUSESHELFNORF IS NULL" + Environment.NewLine
                                            + " OR (WAREHOUSESHELFNORF <> 'ｶｼﾀﾞｼ'" + Environment.NewLine
                                            + " AND WAREHOUSESHELFNORF <> 'ｻｷﾀﾞｼ'))" + Environment.NewLine);
                                        sqlCommand.CommandText = sb.ToString();
                                        //Prameterオブジェクトの作成
                                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                                        SqlParameter findParaInventoryDate = sqlCommand.Parameters.Add("@FINDINVENTORYDATE", SqlDbType.Int);

                                        //Parameterオブジェクトへ値設定
                                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                                        findParaInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                                        myReader = sqlCommand.ExecuteReader();
                                        if (myReader.Read())
                                        {
                                            //新規登録で該当データ有りの場合には重複
                                            inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                            myReader.Close();
                                            retal.Add(inventoryDataUpdateWork);
                                            continue;

                                        }
                                        myReader.Close();

                                        // 2007.09.28 Add >>>>>>>>
                                        //
                                        //新規データのInventroySeqNo は、InventorySeqNoの最大値 + 1 とします。
                                        //inventoryDataUpdateWorkに設定されているInventorySeqNoは無視します。
                                        int inventorySeqNo = 0;
                                        GetMaxInventorySeq(out inventorySeqNo, inventoryDataUpdateWork, ref sqlConnection);
                                        inventorySeqNo++;
                                        // 2007.09.28 Add <<<<<<<<

                                        //新規作成時のSQL文を生成
                                        #region INSERT文作成
                                        sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF" + Environment.NewLine;
                                        sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,SECTIONCODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYSEQNORF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,WAREHOUSECODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,GOODSNORF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,GOODSLGROUPRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,GOODSMGROUPRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,BLGROUPCODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,BLGOODSCODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,SUPPLIERCDRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,JANRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STKUNITPRICECHGFLGRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STOCKDIVRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,LASTSTOCKDATERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STOCKTOTALRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,SHIPCUSTOMERCODERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYSTOCKCNTRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYPREPRDAYRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYPREPRTIMRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYDAYRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYNEWDIVRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STOCKMASHINEPRICERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYSTOCKPRICERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYTLRNCPRICERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,INVENTORYDATERF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,STOCKTOTALEXECRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,TOLERANCEUPDATECDRF" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/19 
                                        sqlCommand.CommandText += " ,GOODSNAMERF" + Environment.NewLine;   // ADD 2011/01/30
                                        sqlCommand.CommandText += " ,LISTPRICEFLRF" + Environment.NewLine; // ADD 2011/01/30
                                        sqlCommand.CommandText += "  )" + Environment.NewLine;
                                        sqlCommand.CommandText += "  VALUES" + Environment.NewLine;
                                        sqlCommand.CommandText += "  (@CREATEDATETIME" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@UPDATEDATETIME" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@ENTERPRISECODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@FILEHEADERGUID" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@SECTIONCODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYSEQNO" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@WAREHOUSECODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@GOODSMAKERCD" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@GOODSNO" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@WAREHOUSESHELFNO" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@GOODSLGROUP" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@GOODSMGROUP" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@BLGROUPCODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@BLGOODSCODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@SUPPLIERCD" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@JAN" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STOCKUNITPRICEFL" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STKUNITPRICECHGFLG" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STOCKDIV" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@LASTSTOCKDATE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STOCKTOTAL" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@SHIPCUSTOMERCODE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYSTOCKCNT" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYTOLERANCCNT" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYPREPRDAY" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYPREPRTIM" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYDAY" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYNEWDIV" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STOCKMASHINEPRICE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYSTOCKPRICE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYTLRNCPRICE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@INVENTORYDATE" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@STOCKTOTALEXEC" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@TOLERANCEUPDATECD" + Environment.NewLine;
                                        sqlCommand.CommandText += " ,@ADJSTCALCCOST" + Environment.NewLine; // ADD 2009/05/19
                                        sqlCommand.CommandText += " ,@GOODSNAME" + Environment.NewLine; // ADD 2011/01/30
                                        sqlCommand.CommandText += " ,@LISTPRICE" + Environment.NewLine; // ADD 2011/01/30
                                        sqlCommand.CommandText += "  )" + Environment.NewLine;
                                        #endregion

                                        //登録ヘッダ情報を設定
                                        object obj = (object)this;
                                        IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                                        FileHeader fileHeader = new FileHeader(obj);
                                        fileHeader.SetInsertHeader(ref flhd, obj);

                                        #region Prameterオブジェクトの作成
                                        //Prameterオブジェクトの作成
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
                                        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/19
                                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/30
                                        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float); // ADD 2011/01/30
                                        #endregion  // Prameterオブジェクトの作成

                                        #region Parameterオブジェクトへ値設定
                                        //Parameterオブジェクトへ値設定
                                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                        // 2007.10.04 Add >>>>>>>>
                                        inventoryDataUpdateWork.InventorySeqNo = inventorySeqNo;
                                        // 2007.10.04 Add <<<<<<<<
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
                                        //paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay); // 2009/12/03
                                        // --- ADD 2009/12/03 ---------->>>>>
                                        if (inventoryDataUpdateWork.InventoryPreprDay == DateTime.MinValue)
                                        {
                                            paraInventoryPreprDay.Value = 0;
                                        }
                                        else
                                        {
                                            paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                                        }
                                        // --- ADD 2009/12/03 ----------<<<<<
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
                                        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.AdjstCalcCost); // ADD 2009/05/19
                                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName); // ADD 2011/01/30
                                        paraListPrice.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.ListPrice); // ADD 2011/01/30
                                        #endregion  // Parameterオブジェクトへ値設定
                                        sqlCommand.ExecuteNonQuery();

                                        retal.Add(inventoryDataUpdateWork);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region 更新登録場合
                                    using (SqlCommand sqlCommand = new SqlCommand(string.Empty, sqlConnection))
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine
                                            + " FROM INVENTORYDATARF " + Environment.NewLine
                                            + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine
                                            + " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine
                                            + " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine
                                            + " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine);
                                        sqlCommand.CommandText = sb.ToString();
                                        //Prameterオブジェクトの作成
                                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                                        //Parameterオブジェクトへ値設定
                                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                                        myReader = sqlCommand.ExecuteReader();
                                        if (myReader.Read())
                                        {
                                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                            if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                                            {
                                                //既存データと更新日時違いの場合には排他
                                                inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                                myReader.Close();
                                                retal.Add(inventoryDataUpdateWork);
                                                continue;
                                            }
                                            myReader.Close();
                                            #region UPDATE文作成
                                            sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET" + Environment.NewLine;
                                            //sqlCommand.CommandText += " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                            sqlCommand.CommandText += " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                            sqlCommand.CommandText += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                            sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                            sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                            sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYSEQNORF=@INVENTORYSEQNO" + Environment.NewLine;
                                            sqlCommand.CommandText += ", WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                            sqlCommand.CommandText += ", GOODSNORF=@GOODSNO" + Environment.NewLine;
                                            sqlCommand.CommandText += ", WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                                            sqlCommand.CommandText += ", DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                                            sqlCommand.CommandText += ", DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                                            sqlCommand.CommandText += ", GOODSLGROUPRF=@GOODSLGROUP" + Environment.NewLine;
                                            sqlCommand.CommandText += ", GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                                            sqlCommand.CommandText += ", BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                                            sqlCommand.CommandText += ", JANRF=@JAN" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                                            sqlCommand.CommandText += ", BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                                            sqlCommand.CommandText += ", LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STOCKTOTALRF=@STOCKTOTAL" + Environment.NewLine;
                                            sqlCommand.CommandText += ", SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYDAYRF=@INVENTORYDAY" + Environment.NewLine;
                                            sqlCommand.CommandText += ", LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYNEWDIVRF=@INVENTORYNEWDIV" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STOCKMASHINEPRICERF=@STOCKMASHINEPRICE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", INVENTORYDATERF=@INVENTORYDATE" + Environment.NewLine;
                                            sqlCommand.CommandText += ", STOCKTOTALEXECRF=@STOCKTOTALEXEC" + Environment.NewLine;
                                            sqlCommand.CommandText += ", TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD" + Environment.NewLine;
                                            sqlCommand.CommandText += ", ADJSTCALCCOSTRF=@ADJSTCALCCOST" + Environment.NewLine; // ADD 2009/05/19
                                            // ---DEL 2011/02/15 ------------>>>
                                            //sqlCommand.CommandText += ", GOODSNAMERF=@GOODSNAME" + Environment.NewLine; // ADD 2011/02/12
                                            //sqlCommand.CommandText += ", LISTPRICEFLRF=@LISTPRICEFL" + Environment.NewLine; // ADD 2011/02/12
                                            // ---DEL 2011/02/15 ------------<<<
                                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                            sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                            sqlCommand.CommandText += " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine;
                                            sqlCommand.CommandText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine; // ADD 2009/12/03
                                            #endregion  // UPDATE

                                            //KEYコマンドを再設定
                                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);  // ADD 2009/12/03

                                            //更新ヘッダ情報を設定
                                            object obj = (object)this;
                                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                                            FileHeader fileHeader = new FileHeader(obj);
                                            fileHeader.SetUpdateHeader(ref flhd, obj);

                                            #region Prameterオブジェクトの作成
                                            //Prameterオブジェクトの作成
                                            SqlParameter ParaUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                                            SqlParameter ParaFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                                            SqlParameter ParaUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                            SqlParameter ParaUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                            SqlParameter ParaUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                            SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                                            SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                                            SqlParameter ParaInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                                            SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                                            SqlParameter ParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                            SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                                            SqlParameter ParaWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                                            SqlParameter ParaDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                                            SqlParameter ParaDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                                            SqlParameter ParaGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                                            SqlParameter ParaGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                                            SqlParameter ParaBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                                            SqlParameter ParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                                            SqlParameter ParaBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                            SqlParameter ParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                                            SqlParameter ParaJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                                            SqlParameter ParaStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                                            SqlParameter ParaBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                                            SqlParameter ParaStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                                            SqlParameter ParaStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                                            SqlParameter ParaLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                                            SqlParameter ParaStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                                            SqlParameter ParaShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                                            SqlParameter ParaInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                                            SqlParameter ParaInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                                            SqlParameter ParaInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                                            SqlParameter ParaInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                                            SqlParameter ParaInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                                            SqlParameter ParaLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                                            SqlParameter ParaInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                                            SqlParameter ParaStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                                            SqlParameter ParaInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                                            SqlParameter ParaInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                                            SqlParameter ParaInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                                            SqlParameter ParaStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                                            SqlParameter ParaToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                                            SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/19
                                            // ---DEL 2011/02/15 ------------>>>
                                            //SqlParameter ParaGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/02/12
                                            //SqlParameter ParaListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/02/12
                                            // ---DEL 2011/02/15 ------------<<<
                                            #endregion  // Prameterオブジェクトの作成

                                            #region Parameterオブジェクトへ値設定
                                            //Parameterオブジェクトへ値設定
                                            ParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                                            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                            ParaFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                                            ParaUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                                            ParaUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                                            ParaUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                                            ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                                            ParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                            ParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                            ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                                            ParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                                            ParaGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                                            ParaWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                                            ParaDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                                            ParaDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                                            ParaGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsLGroup);
                                            ParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMGroup);
                                            ParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGroupCode);
                                            ParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                                            ParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                                            ParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                                            ParaJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                                            ParaStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                                            ParaBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                                            ParaStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                                            ParaStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                                            ParaLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                                            ParaStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                                            ParaShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                                            ParaInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                                            ParaInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                                            //ParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay); // DEL 2009/12/03
                                            // --- ADD 2009/12/03 ---------->>>>>
                                            if (inventoryDataUpdateWork.InventoryPreprDay == DateTime.MinValue)
                                            {
                                                ParaInventoryPreprDay.Value = 0;
                                            }
                                            else
                                            {
                                                ParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                                            }
                                            // --- ADD 2009/12/03 ----------<<<<<
                                            ParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                                            ParaInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                                            ParaLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                                            ParaInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                                            ParaStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                                            ParaInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                                            ParaInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                                            ParaInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                                            ParaStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                                            ParaToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                                            paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.AdjstCalcCost); // ADD 2009/05/19 
                                            // ---DEL 2011/02/15 ------------>>>
                                            //ParaGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName); // ADD 2011/02/12
                                            //ParaListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.ListPrice); // ADD 2011/02/12
                                            // ---DEL 2011/02/15 ------------<<<

                                            #endregion  // Parameterオブジェクトへ値設定
                                        }
                                        else
                                        {
                                            //既存データが無い場合で更新対象データはすでに削除されている意味で排他を戻す
                                            inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                            myReader.Close();
                                            retal.Add(inventoryDataUpdateWork);
                                            continue;
                                        }
                                        sqlCommand.ExecuteNonQuery();

                                        retal.Add(inventoryDataUpdateWork);
                                    }
                                    #endregion
                                }
                                // -------------------- ADD xuyb 2014/10/31 Redmine#40336 -------------------------<<<<<

                                // -------------------- DEL xuyb 2014/10/31 Redmine#40336 ------------------------->>>>>
                                #region // DEL Redmine#40336
                                ////Selectコマンドの生成
                                ////using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO ", sqlConnection)) // DEL 2009/12/03
                                //using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE ", sqlConnection)) // ADD 2009/12/03
                                //{
                                //    //Prameterオブジェクトの作成
                                //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                //    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                //    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                                //    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                                //    //Parameterオブジェクトへ値設定
                                //    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                //    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                //    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                //    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                                //    myReader = sqlCommand.ExecuteReader();

                                //    if (myReader.Read())
                                //    {
                                //        #region 更新処理
                                        
                                //        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                //        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                //        if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                                //        {
                                //            //新規登録で該当データ有りの場合には重複
                                //            if (inventoryDataUpdateWork.UpdateDateTime == DateTime.MinValue)
                                //            {
                                //                inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //            }
                                //            //既存データで更新日時違いの場合には排他
                                //            else
                                //            {
                                //                inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //            }
                                //            myReader.Close();
                                //            retal.Add(inventoryDataUpdateWork);
                                //            continue;
                                //        }                                         

                                //        myReader.Close();
                                //        #region UPDATE文作成
                                //        sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET" + Environment.NewLine;
                                //        //sqlCommand.CommandText += " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                //        sqlCommand.CommandText += " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYSEQNORF=@INVENTORYSEQNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", GOODSNORF=@GOODSNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", GOODSLGROUPRF=@GOODSLGROUP" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", JANRF=@JAN" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STOCKTOTALRF=@STOCKTOTAL" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYDAYRF=@INVENTORYDAY" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYNEWDIVRF=@INVENTORYNEWDIV" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STOCKMASHINEPRICERF=@STOCKMASHINEPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", INVENTORYDATERF=@INVENTORYDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", STOCKTOTALEXECRF=@STOCKTOTALEXEC" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD" + Environment.NewLine;
                                //        sqlCommand.CommandText += ", ADJSTCALCCOSTRF=@ADJSTCALCCOST" + Environment.NewLine; // ADD 2009/05/19
                                //        // ---DEL 2011/02/15 ------------>>>
                                //        //sqlCommand.CommandText += ", GOODSNAMERF=@GOODSNAME" + Environment.NewLine; // ADD 2011/02/12
                                //        //sqlCommand.CommandText += ", LISTPRICEFLRF=@LISTPRICEFL" + Environment.NewLine; // ADD 2011/02/12
                                //        // ---DEL 2011/02/15 ------------<<<
                                //        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine; // ADD 2009/12/03
                                //        #endregion  // UPDATE

                                //        //KEYコマンドを再設定
                                //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                //        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                //        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                //        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);  // ADD 2009/12/03

                                //        //更新ヘッダ情報を設定
                                //        object obj = (object)this;
                                //        IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                                //        FileHeader fileHeader = new FileHeader(obj);
                                //        fileHeader.SetUpdateHeader(ref flhd, obj);

                                //        #region Prameterオブジェクトの作成
                                //        //Prameterオブジェクトの作成
                                //        SqlParameter ParaUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                //        SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                                //        SqlParameter ParaFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                                //        SqlParameter ParaUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                //        SqlParameter ParaUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                //        SqlParameter ParaUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                //        SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                                //        SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                                //        SqlParameter ParaInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                                //        SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                                //        SqlParameter ParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                //        SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                                //        SqlParameter ParaWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                                //        SqlParameter ParaDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                                //        SqlParameter ParaDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                                //        SqlParameter ParaGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                                //        SqlParameter ParaGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                                //        SqlParameter ParaBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                                //        SqlParameter ParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                                //        SqlParameter ParaBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                //        SqlParameter ParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                                //        SqlParameter ParaJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                                //        SqlParameter ParaStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                                //        SqlParameter ParaBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                                //        SqlParameter ParaStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                                //        SqlParameter ParaStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                                //        SqlParameter ParaLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                                //        SqlParameter ParaStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                                //        SqlParameter ParaShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                                //        SqlParameter ParaInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                                //        SqlParameter ParaInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                                //        SqlParameter ParaInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                                //        SqlParameter ParaInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                                //        SqlParameter ParaInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                                //        SqlParameter ParaLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                                //        SqlParameter ParaInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                                //        SqlParameter ParaStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                                //        SqlParameter ParaInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                                //        SqlParameter ParaInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                                //        SqlParameter ParaInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                                //        SqlParameter ParaStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                                //        SqlParameter ParaToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                                //        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/19
                                //        // ---DEL 2011/02/15 ------------>>>
                                //        //SqlParameter ParaGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/02/12
                                //        //SqlParameter ParaListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/02/12
                                //        // ---DEL 2011/02/15 ------------<<<
                                //        #endregion  // Prameterオブジェクトの作成

                                //        #region Parameterオブジェクトへ値設定
                                //        //Parameterオブジェクトへ値設定
                                //        ParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                                //        ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                //        ParaFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                                //        ParaUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                                //        ParaUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                                //        ParaUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                                //        ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                                //        ParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                //        ParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                //        ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                                //        ParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                                //        ParaGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                                //        ParaWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                                //        ParaDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                                //        ParaDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                                //        ParaGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsLGroup);
                                //        ParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMGroup);
                                //        ParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGroupCode);
                                //        ParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                                //        ParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                                //        ParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                                //        ParaJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                                //        ParaStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                                //        ParaBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                                //        ParaStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                                //        ParaStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                                //        ParaLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                                //        ParaStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                                //        ParaShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                                //        ParaInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                                //        ParaInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                                //        //ParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay); // DEL 2009/12/03
                                //        // --- ADD 2009/12/03 ---------->>>>>
                                //        if (inventoryDataUpdateWork.InventoryPreprDay == DateTime.MinValue)
                                //        {
                                //            ParaInventoryPreprDay.Value = 0;
                                //        }
                                //        else
                                //        {
                                //            ParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                                //        }
                                //        // --- ADD 2009/12/03 ----------<<<<<
                                //        ParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                                //        ParaInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                                //        ParaLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                                //        ParaInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                                //        ParaStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                                //        ParaInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                                //        ParaInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                                //        ParaInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                                //        ParaStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                                //        ParaToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                                //        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.AdjstCalcCost); // ADD 2009/05/19 
                                //        // ---DEL 2011/02/15 ------------>>>
                                //        //ParaGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName); // ADD 2011/02/12
                                //        //ParaListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.ListPrice); // ADD 2011/02/12
                                //        // ---DEL 2011/02/15 ------------<<<

                                //        #endregion  // Parameterオブジェクトへ値設定
                                //        #endregion  // 更新処理
                                //    }
                                //    else
                                //    {
                                //        #region 登録処理
                                //        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                //        if (inventoryDataUpdateWork.UpdateDateTime > DateTime.MinValue)
                                //        {
                                //            inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //            myReader.Close();
                                //            retal.Add(inventoryDataUpdateWork);
                                //            continue;
                                //        }

                                //        myReader.Close();

                                //        // 2007.09.28 Add >>>>>>>>
                                //        //
                                //        //新規データのInventroySeqNo は、InventorySeqNoの最大値 + 1 とします。
                                //        //inventoryDataUpdateWorkに設定されているInventorySeqNoは無視します。
                                //        int inventorySeqNo = 0;
                                //        GetMaxInventorySeq(out inventorySeqNo, inventoryDataUpdateWork, ref sqlConnection);
                                //        inventorySeqNo++;
                                //        // 2007.09.28 Add <<<<<<<<

                                //        //新規作成時のSQL文を生成
                                //        #region INSERT文作成
                                //        sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,SECTIONCODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYSEQNORF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,WAREHOUSECODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,GOODSNORF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,GOODSLGROUPRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,GOODSMGROUPRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,BLGROUPCODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,BLGOODSCODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,SUPPLIERCDRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,JANRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STKUNITPRICECHGFLGRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STOCKDIVRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,LASTSTOCKDATERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STOCKTOTALRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,SHIPCUSTOMERCODERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYSTOCKCNTRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYPREPRDAYRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYPREPRTIMRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYDAYRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYNEWDIVRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STOCKMASHINEPRICERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYSTOCKPRICERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYTLRNCPRICERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,INVENTORYDATERF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,STOCKTOTALEXECRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,TOLERANCEUPDATECDRF" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/19 
                                //        sqlCommand.CommandText += " ,GOODSNAMERF" + Environment.NewLine;   // ADD 2011/01/30
                                //        sqlCommand.CommandText += " ,LISTPRICEFLRF" + Environment.NewLine; // ADD 2011/01/30
                                //        sqlCommand.CommandText += "  )" + Environment.NewLine;
                                //        sqlCommand.CommandText += "  VALUES" + Environment.NewLine;
                                //        sqlCommand.CommandText += "  (@CREATEDATETIME" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@UPDATEDATETIME" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@ENTERPRISECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@FILEHEADERGUID" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@SECTIONCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYSEQNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@WAREHOUSECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@GOODSMAKERCD" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@GOODSNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@WAREHOUSESHELFNO" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@GOODSLGROUP" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@GOODSMGROUP" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@BLGROUPCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@BLGOODSCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@SUPPLIERCD" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@JAN" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STOCKUNITPRICEFL" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STKUNITPRICECHGFLG" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STOCKDIV" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@LASTSTOCKDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STOCKTOTAL" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@SHIPCUSTOMERCODE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYSTOCKCNT" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYTOLERANCCNT" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYPREPRDAY" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYPREPRTIM" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYDAY" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYNEWDIV" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STOCKMASHINEPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYSTOCKPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYTLRNCPRICE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@INVENTORYDATE" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@STOCKTOTALEXEC" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@TOLERANCEUPDATECD" + Environment.NewLine;
                                //        sqlCommand.CommandText += " ,@ADJSTCALCCOST" + Environment.NewLine; // ADD 2009/05/19
                                //        sqlCommand.CommandText += " ,@GOODSNAME" + Environment.NewLine; // ADD 2011/01/30
                                //        sqlCommand.CommandText += " ,@LISTPRICE" + Environment.NewLine; // ADD 2011/01/30
                                //        sqlCommand.CommandText += "  )" + Environment.NewLine;
                                //        #endregion

                                //        //登録ヘッダ情報を設定
                                //        object obj = (object)this;
                                //        IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                                //        FileHeader fileHeader = new FileHeader(obj);
                                //        fileHeader.SetInsertHeader(ref flhd, obj);

                                //        #region Prameterオブジェクトの作成
                                //        //Prameterオブジェクトの作成
                                //        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                                //        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                //        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                                //        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                                //        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                //        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                //        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                //        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                                //        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                                //        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                                //        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                                //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                                //        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                                //        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                                //        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                                //        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                                //        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                                //        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                                //        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                                //        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                //        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                                //        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                                //        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                                //        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                                //        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                                //        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                                //        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                                //        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                                //        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                                //        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                                //        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                                //        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                                //        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                                //        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                                //        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                                //        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                                //        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                                //        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                                //        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                                //        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                                //        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                                //        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                                //        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/19
                                //        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/30
                                //        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float); // ADD 2011/01/30
                                //        #endregion  // Prameterオブジェクトの作成

                                //        #region Parameterオブジェクトへ値設定
                                //        //Parameterオブジェクトへ値設定
                                //        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                                //        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                                //        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                //        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                                //        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                                //        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                                //        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                                //        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                                //        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                //        // 2007.10.04 Add >>>>>>>>
                                //        inventoryDataUpdateWork.InventorySeqNo = inventorySeqNo;
                                //        // 2007.10.04 Add <<<<<<<<
                                //        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                //        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                                //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                                //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                                //        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                                //        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                                //        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                                //        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsLGroup);
                                //        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMGroup);
                                //        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGroupCode);
                                //        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                                //        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                                //        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                                //        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                                //        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                                //        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                                //        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                                //        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                                //        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                                //        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                                //        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                                //        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                                //        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                                //        //paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay); // 2009/12/03
                                //        // --- ADD 2009/12/03 ---------->>>>>
                                //        if (inventoryDataUpdateWork.InventoryPreprDay == DateTime.MinValue)
                                //        {
                                //            paraInventoryPreprDay.Value = 0;
                                //        }
                                //        else
                                //        {
                                //            paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                                //        }
                                //        // --- ADD 2009/12/03 ----------<<<<<
                                //        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                                //        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                                //        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                                //        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                                //        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                                //        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                                //        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                                //        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                                //        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                                //        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                                //        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.AdjstCalcCost); // ADD 2009/05/19
                                //        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName); // ADD 2011/01/30
                                //        paraListPrice.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.ListPrice); // ADD 2011/01/30
                                //        #endregion  // Parameterオブジェクトへ値設定
                                //        #endregion  // 登録処理
                                //    }
                                //    sqlCommand.ExecuteNonQuery();

                                //    retal.Add(inventoryDataUpdateWork);
                                //}
                                #endregion
                                // -------------------- DEL xuyb 2014/10/31 Redmine#40336 -------------------------<<<<<
                                #endregion
                            }
                            else if (inventoryDataUpdateWork.LogicalDeleteCode == 3)
                            {
                                #region 削除処理 ＊論理削除区分が３のレコードを削除（論理削除区分が３になるのは新規追加行のみ）
                                //using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO ", sqlConnection)) // DEL 2009/12/03
                                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE ", sqlConnection)) // ADD 2009/12/03
                                {
                                    //Prameterオブジェクトの作成
                                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                                    //Parameterオブジェクトへ値設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                                    myReader = sqlCommand.ExecuteReader();
                                    if (myReader.Read())
                                    {
                                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                        if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                                        {
                                            inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                            myReader.Close();
                                            retal.Add(inventoryDataUpdateWork);
                                            continue;
                                        }

                                        //sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO "; // DEL 2009/12/03
                                        sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE "; // ADD 2009/12/03
                                        //KEYコマンドを再設定
                                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03
                                    }
                                    else
                                    {
                                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                        inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                        myReader.Close();
                                        retal.Add(inventoryDataUpdateWork);
                                        continue;
                                    }
                                    myReader.Close();

                                    sqlCommand.ExecuteNonQuery();

                                    retal.Add(inventoryDataUpdateWork);
                                }
                                #endregion
                            }
                        }
                        catch (SqlException ex)
                        {
                            inventoryDataUpdateWork.Status = base.WriteSQLErrorLog(ex);
                            retal.Add(inventoryDataUpdateWork);
                            if (ex.Class > 19)
                            {
                                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            continue;
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "InventoryDataUpdateDB.Write");
                            inventoryDataUpdateWork.Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            retal.Add(inventoryDataUpdateWork);
                            continue;
                        }
                    }
                }
                finally
                {
                    if (myReader != null && myReader.IsClosed == false) myReader.Close();
                    if (sqlConnection != null)
                    {
                        sqlConnection.Dispose();
                        sqlConnection.Close();
                    }
                }
                paraList = retal;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryDataUpdateDB.Write");
            }

            return status;
        }
        #endregion


        #region 通番最終番号取得
        /// <summary>
        /// 棚卸準備データ内の通番最終番号を戻します
        /// </summary>
        /// <param name="MaxInventorySeqCount">通番最終番号</param>
        /// <param name="inventoryDataUpdateWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備データ内の通番最終番号を戻します</br>
        /// <br>Programmer : Yokokawa</br>
        /// <br>Date       : 2007.09.28</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             新規入力時の棚卸通番の付番方法を変更</br>
        private int GetMaxInventorySeq(out int MaxInventorySeqCount, InventoryDataUpdateWork inventoryDataUpdateWork, ref SqlConnection sqlConnection /*, ref SqlTransaction sqlTrans*/)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            MaxInventorySeqCount = 0;
            try
            {
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection/*, sqlTrans*/)) // DEL 2009/12/03
                using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection)) // ADD 2009/12/03
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        MaxInventorySeqCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNO_MAX"));
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
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

        // --- ADD 2009/12/03 ---------->>>>>
        #region 在庫総数取得処理

        #region 在庫総数取得処理
        /// <summary>
        /// 在庫総数取得処理
        /// </summary>
        /// <param name="objIvtDataWork">棚卸データ更新ワーク</param>
        /// <param name="stockTotal">在庫総数</param>
        /// <param name="arrivalCnt">入荷数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫総数取得処理を行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        public int GetStockTotal(object objIvtDataWork, ref double stockTotal, ref double arrivalCnt, ref double shipmentCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                int lastAddUpYearMonth = 0;
                int lastAddUpDate = 0;
                double stockUnitPriceFl = 0.0;

                InventoryDataUpdateWork ivtDataWork = objIvtDataWork as InventoryDataUpdateWork;
                this.GetStockHistoryData(ivtDataWork, ref lastAddUpYearMonth, ref lastAddUpDate, ref stockUnitPriceFl, ref stockTotal, ref sqlConnection, ref sqlTrans);
                this.GetStockAcPayHistData(ivtDataWork, lastAddUpDate, ivtDataWork.InventoryDate, ref arrivalCnt, ref shipmentCnt, ref sqlConnection, ref sqlTrans);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InventoryDataUpdateDB.GetStockTotal");
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }
        #endregion

        #region 在庫履歴データ検索
        /// <summary>
        /// 在庫履歴データ検索
        /// </summary>
        /// <param name="ivtDataWork">棚卸データ更新ワーク</param>
        /// <param name="lastAddUpYearMonth">計上年月</param>
        /// <param name="lastAddUpDate">計上年月日</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）</param>
        /// <param name="stockTotal">在庫総数</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴データ検索を行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private int GetStockHistoryData(InventoryDataUpdateWork ivtDataWork,
            ref int lastAddUpYearMonth, ref int lastAddUpDate, ref double stockUnitPriceFl, ref double stockTotal,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sText = "";
                sText += "SELECT TOP 1  " + Environment.NewLine;
                sText += " STOCKHIS.ADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKTOTALRF " + Environment.NewLine;
                sText += " ,ADDUPHIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                sText += "FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine;
                sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS" + Environment.NewLine;
                sText += " ON STOCKHIS.ENTERPRISECODERF = ADDUPHIS.ENTERPRISECODERF" + Environment.NewLine;
                sText += " AND STOCKHIS.ADDUPYEARMONTHRF = ADDUPHIS.MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " AND ADDUPHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.PROCDIVCDRF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.HISTCTLCDRF=0" + Environment.NewLine;
                sText += "WHERE STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND STOCKHIS.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.GOODSNORF=@GOODSNO" + Environment.NewLine;
                sText += " AND STOCKHIS.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sText += "ORDER BY ADDUPYEARMONTHRF DESC" + Environment.NewLine;

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);

                lastAddUpYearMonth = 0;
                stockUnitPriceFl = 0.0;
                stockTotal = 0.0;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    lastAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")); // 計上年月
                    lastAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));    // 計上年月日  // ADD 2009/04/27
                    stockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));// 仕入単価（税抜，浮動）
                    stockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));            // 在庫総数
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // 在庫履歴データ検索

        #region 在庫受払履歴データ検索
        /// <summary>
        /// 在庫履歴データ検索
        /// </summary>
        /// <param name="ivtDataWork">棚卸データ更新ワーク</param>
        /// <param name="lastAddUpDate">計上年月日</param>
        /// <param name="inventoryDate">棚卸日</param>
        /// <param name="arrivalCnt">入荷数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴データ検索を行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private int GetStockAcPayHistData(InventoryDataUpdateWork ivtDataWork, int lastAddUpDate, DateTime inventoryDate,
            ref double arrivalCnt, ref double shipmentCnt,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            string sText = "";

            sText += "SELECT SUM(ARRIVALCNTRF) AS S_ARRIVALCNTRF, ";
            sText += "SUM(SHIPMENTCNTRF) AS S_SHIPMENTCNTRF ";
            sText += "FROM STOCKACPAYHISTRF ";
            sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
            sText += "AND LOGICALDELETECODERF=0 ";
            sText += "AND   (  (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)>@LASTADDUPDATE ";
            sText += "      AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)<=@INVENTORYDATE )";
            sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
            sText += "AND GOODSNORF=@GOODSNO ";
            sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraLastAddUpDate = sqlCommand.Parameters.Add("@LASTADDUPDATE", SqlDbType.Int);
            SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
            paraLastAddUpDate.Value = SqlDataMediator.SqlSetInt32(lastAddUpDate);
            paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDate);
            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);

            try
            {
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    arrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_ARRIVALCNTRF"));
                    shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_SHIPMENTCNTRF"));
                }
                else
                {
                    arrivalCnt = 0.0;
                    shipmentCnt = 0.0;
                }
                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // 在庫受払履歴データ検索
        #endregion
        // --- ADD 2009/12/03 ----------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        #region Search
        /// <summary>
        /// 棚卸入力検索
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸入力の検索を行うメソッドです。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/01</br>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retobj = new object();
            ArrayList al = new ArrayList();
            CustomSerializeArrayList cstmAl = new CustomSerializeArrayList();
            InventInputSearchCndtnWork _inventInputSearchCndtnWork = paraobj as InventInputSearchCndtnWork;
            SqlConnection sqlConnection = null;
            int ProductNumberOutPutDiv;

            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();


                Dictionary<string, InventInputSearchResultWork> skipDic = new Dictionary<string, InventInputSearchResultWork>();

                ProductNumberOutPutDiv = -1;
                //非グロスデータ取得実行部
                status = SearchNonGrossAction(ref al, ref sqlConnection, _inventInputSearchCndtnWork, ProductNumberOutPutDiv, logicalMode, skipDic);

                cstmAl.Add(al);
                retobj = cstmAl;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        #endregion

        #region 製番データ取得処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>UpdateNote : 2010/02/23 楊明俊</br>
        /// <br>             PM1005</br>
        /// <br>             データ抽出時に、商品マスタの存在チェックを行い処理対象外とするように変更する。</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
        /// <br>             障害報告 #18866</br>
        /// <br>UpdateNote : 2011/02/12 朱 猛</br>
        /// <br>             障害報告 #18877</br>
        /// <br>UpdateNote : 2013/03/01 yangyi</br>
        /// <br>             障害報告 #34175</br>
        /// <br></br>
        private int SearchNonGrossAction(ref ArrayList al, ref SqlConnection sqlConnection, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode, Dictionary<string, InventInputSearchResultWork> skipDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // 対象テーブル
                // INVENTORYDATARF IVD   棚卸データ
                string SelectDm = "";

                if ((productNumberOutPutDiv == 0) || (productNumberOutPutDiv == -1))
                {
                    SelectDm += "SELECT" + Environment.NewLine;
                    SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                    SelectDm += " ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                    SelectDm += " ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                    SelectDm += " ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                    SelectDm += " ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                    SelectDm += " ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                    SelectDm += " ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                    SelectDm += " ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                    SelectDm += " ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                    SelectDm += " ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF " + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                    SelectDm += "FROM INVENTORYDATARF AS IVD WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                else
                {
                    #region Select文作成
                    // ADD 2009/06/01 >>>
                    SelectDm += "SELECT" + Environment.NewLine;
                    SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                    SelectDm += " ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                    SelectDm += " ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                    SelectDm += " ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                    SelectDm += " ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                    SelectDm += " ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                    SelectDm += " ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                    SelectDm += " ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                    SelectDm += " ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                    SelectDm += " ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                    SelectDm += " ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                    SelectDm += " ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                    SelectDm += " ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                    SelectDm += " ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                    SelectDm += " ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                    SelectDm += " ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF " + Environment.NewLine;
                    SelectDm += " ,SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF" + Environment.NewLine;
                    SelectDm += " ,WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;
                    SelectDm += " ,MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF" + Environment.NewLine;
                    SelectDm += " ,USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF" + Environment.NewLine;
                    SelectDm += " ,BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;
                    SelectDm += " ,USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF" + Environment.NewLine;
                    SelectDm += " ,GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF" + Environment.NewLine;
                    //SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // DEL 2011/01/11
                    SelectDm += " ,IVD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // ADD 2011/01/11
                    SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF_NEW" + Environment.NewLine; // ADD 2011/02/12
                    //SelectDm += " ,IVD.LISTPRICEFLRF GOODS_LISTPRICERF" + Environment.NewLine; // ADD 2011/01/30 // DEL 2011/02/16
                    //SelectDm += " ,GOODSPRICE.LISTPRICERF GOODSPRICE_LISTPRICERF" + Environment.NewLine; // ADD 2011/02/12 // DEL 2011/02/16
                    SelectDm += " ,CTM.NAMERF CTM_NAMERF" + Environment.NewLine;
                    SelectDm += " ,CTM.NAME2RF CTM_NAME2RF" + Environment.NewLine;
                    SelectDm += " ,BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;
                    // --- ADD 2010/02/23 ---------->>>>>
                    SelectDm += " ,(CASE WHEN GOODS.LOGICALDELETECODERF IS NULL THEN 1 ELSE GOODS.LOGICALDELETECODERF END) AS IVD_GOODSDIVRF" + Environment.NewLine;
                    // --- ADD 2010/02/23 ----------<<<<<
                    //SelectDm += "FROM INVENTORYDATARF AS IVD" + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "FROM INVENTORYDATARF AS IVD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                    #region 結合
                    //SelectDm += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND SEC.SECTIONCODERF=IVD.SECTIONCODERF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN WAREHOUSERF AS WH " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN GOODSURF AS GOODS " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF" + Environment.NewLine;
                    SelectDm += "  AND GOODS.GOODSNORF=IVD.GOODSNORF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND USRGDL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                    SelectDm += "  AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND USRGDE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
                    SelectDm += "  AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                    //SelectDm += " LEFT JOIN CUSTOMERRF AS CTM " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN CUSTOMERRF AS CTM WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF " + Environment.NewLine;
                    //SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                    SelectDm += "  ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                    SelectDm += "  AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF " + Environment.NewLine;
                    // ---------- DEL 2011/02/16 ------------------->>>>>
                    //// --- ADD 2011/02/12 ---------->>>>>
                    //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
                    //SelectDm += " ON GOODSPRICE.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                    //SelectDm += " AND GOODSPRICE.GOODSMAKERCDRF = IVD.GOODSMAKERCDRF" + Environment.NewLine;
                    //SelectDm += " AND GOODSPRICE.GOODSNORF = IVD.GOODSNORF " + Environment.NewLine;
                    //SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <= IVD.INVENTORYDATERF " + Environment.NewLine;
                    //// --- ADD 2011/02/12 ----------<<<<<
                    // ---------- DEL 2011/02/16 -------------------<<<<<
                    #endregion
                    // ADD 2009/06/01 <<<

                    #endregion
                }


                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                //棚卸数入力の場合
                if ((productNumberOutPutDiv == 0) || (productNumberOutPutDiv == -1))
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventoryDataUpdateWork wkInventoryDataUpdateWork = new InventoryDataUpdateWork();

                        wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_CREATEDATETIMERF"));
                        wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_UPDATEDATETIMERF"));
                        wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_ENTERPRISECODERF"));
                        wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("IVD_FILEHEADERGUIDRF"));
                        wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDEMPLOYEECODERF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID1RF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID2RF"));
                        wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_LOGICALDELETECODERF"));
                        wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventoryDataUpdateWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventoryDataUpdateWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventoryDataUpdateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        wkInventoryDataUpdateWork.StockAmount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));

                        wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));  // ADD 2009/04/13 <<<
                        //wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STATUSRF"));
                        //wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODS_LISTPRICERF"));  // ADD 2011/01/30  // DEL 2011/02/16
                        // --- ADD 2011/02/12 ---------->>>>>
                        // --- UPD 2011/02/16 --->>>>>
                        //if ("".Equals(wkInventoryDataUpdateWork.GoodsName) && !"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))

                        //---------- DEL 2013/02/19 #34175 yangyi------------------->>>>>
                        //if ("".Equals(wkInventoryDataUpdateWork.GoodsName))
                        //// --- UPD 2011/02/16 ---<<<<<
                        //{
                        //    wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF_NEW"));
                        //    //wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // DEL 2011/02/16
                        //}
                        //---------- DEL 2013/02/19 #34175 yangyi-------------------<<<<<

                        // --- ADD 2011/02/12 ----------<<<<<
                        // --- ADD 2010/02/23 ---------->>>>>
                        //商品チェックフラグ
                        //wkInventoryDataUpdateWork.GoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSDIVRF")); //DEL 2013/02/19 #34175 yangyi
                        // --- ADD 2010/02/23 ----------<<<<<
                        wkInventoryDataUpdateWork.AdjstCalcCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_ADJSTCALCCOSTRF")); // 2009/05/21 >>>

                        #endregion   // 抽出結果-値セット

                        // ①貸出データ抽出区分（0:印刷しない,1:印刷する） ②来勘計上分データ抽出区分（0:印刷しない,1:印刷する）
                        if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            al.Add(wkInventoryDataUpdateWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 0 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 0)
                        {
                            // 棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                }
                else
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();

                        //製番在庫マスタ格納項目
                        wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventInputSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTIONGUIDENMRF"));
                        wkInventInputSearchResultWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                        wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                        wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                        wkInventInputSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventInputSearchResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventInputSearchResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDL_GOODSLGROUPNAMERF"));
                        wkInventInputSearchResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventInputSearchResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GGR_GOODSMGROUPNAMERF"));
                        wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDE_GUIDENAMERF"));
                        wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                        wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventInputSearchResultWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventInputSearchResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventInputSearchResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventInputSearchResultWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventInputSearchResultWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAMERF"));
                        wkInventInputSearchResultWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAME2RF"));
                        wkInventInputSearchResultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventInputSearchResultWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventInputSearchResultWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventInputSearchResultWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventInputSearchResultWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventInputSearchResultWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventInputSearchResultWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventInputSearchResultWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventInputSearchResultWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventInputSearchResultWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventInputSearchResultWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventInputSearchResultWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventInputSearchResultWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        #endregion    // 抽出結果-値セット
                        al.Add(wkInventInputSearchResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchNonGrossAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region WHERE文作成
        /// <summary>
        /// 検索条件文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        public string MakeWhereString(ref SqlCommand sqlCommand, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode)
        {
            return this.MakeWhereStringProc(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);
        }

        /// <summary>
        /// 検索条件文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        private string MakeWhereStringProc(ref SqlCommand sqlCommand, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = " WHERE ";

            //企業コード設定
            retstring += " IVD.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND IVD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND IVD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード設定
            if ((_inventInputSearchCndtnWork.St_SectionCode != "00") && (_inventInputSearchCndtnWork.St_SectionCode != ""))
            {
                retstring += " AND IVD.SECTIONCODERF>=@STSECTIONCODE ";
                SqlParameter findParaStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                findParaStSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_SectionCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_SectionCode != "00") && (_inventInputSearchCndtnWork.Ed_SectionCode != ""))
            {
                retstring += " AND IVD.SECTIONCODERF<=@EDSECTIONCODE ";
                SqlParameter findParaEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                findParaEdSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_SectionCode);
            }

            //メーカーコード設定
            if (_inventInputSearchCndtnWork.St_MakerCode != 0)
            {
                retstring += " AND IVD.GOODSMAKERCDRF>=@STMAKERCODE";
                SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_MakerCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_MakerCode != 9999) && (_inventInputSearchCndtnWork.Ed_MakerCode != 0))
            {
                retstring += " AND IVD.GOODSMAKERCDRF<=@EDMAKERCODE";
                SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_MakerCode);
            }

            //商品番号設定
            if (_inventInputSearchCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND IVD.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_GoodsNo);
            }
            if (_inventInputSearchCndtnWork.Ed_GoodsNo != "")
            {
                //retstring += " AND (IVD.GOODSNORF<=@EDGOODSNO OR IVD.GOODSNORF LIKE @EDGOODSNO)"; // 2008.10.08 DEL
                retstring += " AND IVD.GOODSNORF<=@EDGOODSNO ";                                     // 2008.10.08 ADD
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_GoodsNo + "%");
            }

            if (_inventInputSearchCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
            {
                //倉庫コード設定
                if (_inventInputSearchCndtnWork.St_WarehouseCode != "")
                {
                    retstring += " AND IVD.WAREHOUSECODERF>=@STWAREHOUSECODE";
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseCode);
                }
                if (_inventInputSearchCndtnWork.Ed_WarehouseCode != "")
                {
                    //retstring += " AND (IVD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR IVD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)"; // 2008.10.08 DEL
                    retstring += " AND IVD.WAREHOUSECODERF<=@EDWAREHOUSECODE";                                                  // 2008.10.08 ADD
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    //paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode + "%");  // 2008.10.08 DEL
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode);         // 2008.10.08 ADD   
                }
            }
            else
            {
                #region 倉庫1～10
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    retstring += " AND ( ";
                }

                //倉庫コード01設定
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                {
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD01";
                    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd01);
                }

                //倉庫コード02設定
                if (_inventInputSearchCndtnWork.WarehouseCd02 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD02";
                    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd02);
                }

                //倉庫コード03設定
                if (_inventInputSearchCndtnWork.WarehouseCd03 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "")
                    {
                        retstring += " OR ";
                    }

                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD03";
                    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd03);
                }

                //倉庫コード04設定
                if (_inventInputSearchCndtnWork.WarehouseCd04 != "")
                {

                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD04";
                    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd04);
                }

                //倉庫コード05設定
                if (_inventInputSearchCndtnWork.WarehouseCd05 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD05";
                    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd05);
                }

                //倉庫コード06設定
                if (_inventInputSearchCndtnWork.WarehouseCd06 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "")
                    {
                        retstring += " OR ";
                    }

                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD06";
                    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd06);
                }

                //倉庫コード07設定
                if (_inventInputSearchCndtnWork.WarehouseCd07 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD07";
                    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd07);
                }

                //倉庫コード08設定
                if (_inventInputSearchCndtnWork.WarehouseCd08 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD08";
                    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd08);
                }

                //倉庫コード09設定
                if (_inventInputSearchCndtnWork.WarehouseCd09 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD09";
                    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd09);
                }

                //倉庫コード10設定
                if (_inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd09 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD10";
                    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd10);
                }
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    retstring += " ) ";
                }
                #endregion
            }

            // -----------UDP 2011/01/11 ------------------------------->>>>>
            //棚卸表のみ
            if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
            {
                //棚番出力区分  1:棚番なしのみ出力  2: 棚番なし以外出力
                if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv != 0)
                {
                    if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv == 1)
                    {
                        // ---------- UPD 2011/02/15 ---------------------------------------->>>>>
                        retstring += " AND IVD.WAREHOUSESHELFNORF IS NULL ";

                        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                        }
                        if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
                        }
                        // ---------- UPD 2011/02/15 ----------------------------------------<<<<<
                    }
                    else if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv == 2)
                    {
                        //棚番設定
                        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                        }
                        if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
                        }
                        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo == "" && _inventInputSearchCndtnWork.Ed_WarehouseShelfNo == "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF IS NOT NULL ";
                        }
                    }
                }
                else
                {
                    //棚番設定
                    if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                    {
                        retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                        SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                    }
                    if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                    {
                        retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF IS NULL )";
                        SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);   
                    }
                }
            }
            // 棚卸調査表と棚卸差異表
            else
            {
                //棚番設定
                if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                }
                if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                {
                    retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF IS NULL )";
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
                }
            }

            //自社分類コード設定
            if (_inventInputSearchCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND IVD.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_EnterpriseGanreCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode != 9999) && (_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode != 0))
            {
                retstring += " AND IVD.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode);
            }

            //ＢＬ商品コード設定
            if (_inventInputSearchCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND IVD.BLGOODSCODERF>=@STBLGOODSCODE";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGoodsCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_BLGoodsCode != 99999) && (_inventInputSearchCndtnWork.Ed_BLGoodsCode != 0))
            {
                retstring += " AND IVD.BLGOODSCODERF<=@EDBLGOODSCODE";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGoodsCode);
            }

            //仕入先コード設定
            if (_inventInputSearchCndtnWork.St_SupplierCd != 0)
            {
                retstring += " AND IVD.SUPPLIERCDRF>=@STSUPPLIERCD";
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_SupplierCd);
            }
            if ((_inventInputSearchCndtnWork.Ed_SupplierCd != 999999) && (_inventInputSearchCndtnWork.Ed_SupplierCd != 0))
            {
                retstring += " AND IVD.SUPPLIERCDRF<=@EDSUPPLIERCD";
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_SupplierCd);
            }

            //棚卸準備処理日設定
            if (_inventInputSearchCndtnWork.St_InventoryPreprDay != DateTime.MinValue)
            {
                int startymdInventoryPreprDay = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.St_InventoryPreprDay);
                retstring += " AND IVD.INVENTORYPREPRDAYRF >= " + startymdInventoryPreprDay.ToString();
            }
            if (_inventInputSearchCndtnWork.Ed_InventoryPreprDay != DateTime.MinValue)
            {
                if (_inventInputSearchCndtnWork.St_InventoryPreprDay == DateTime.MinValue)
                {
                    retstring += " AND (IVD.INVENTORYPREPRDAYRF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymdInventoryPreprDay = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.Ed_InventoryPreprDay);
                retstring += " IVD.INVENTORYPREPRDAYRF <= " + endymdInventoryPreprDay.ToString();

                if (_inventInputSearchCndtnWork.St_InventoryPreprDay == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //棚卸日
            if (_inventInputSearchCndtnWork.InventoryDate != DateTime.MinValue)
            {
                int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.InventoryDate);
                retstring += " AND IVD.INVENTORYDATERF = " + InventoryDate.ToString();
            }

            //通番設定
            if (_inventInputSearchCndtnWork.St_InventorySeqNo != 0)
            {
                retstring += " AND IVD.INVENTORYSEQNORF>=@STINVENTORYSEQNO";
                SqlParameter paraStInventorySeqNo = sqlCommand.Parameters.Add("@STINVENTORYSEQNO", SqlDbType.Int);
                paraStInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_InventorySeqNo);
            }
            if ((_inventInputSearchCndtnWork.Ed_InventorySeqNo != 999999) && (_inventInputSearchCndtnWork.Ed_InventorySeqNo != 0))
            {
                retstring += " AND IVD.INVENTORYSEQNORF<=@EDINVENTORYSEQNO";
                SqlParameter paraEdInventorySeqNo = sqlCommand.Parameters.Add("@EDINVENTORYSEQNO", SqlDbType.Int);
                paraEdInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_InventorySeqNo);
            }

            // グループコード設定
            if (_inventInputSearchCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND IVD.BLGROUPCODERF>=@STBLGROUPCODE";
                SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGroupCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_BLGroupCode != 99999) && (_inventInputSearchCndtnWork.Ed_BLGroupCode != 0))
            {
                retstring += " AND IVD.BLGROUPCODERF<=@EDBLGROUPCODE";
                SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGroupCode);
            }

            // 在庫区分設定
            if (_inventInputSearchCndtnWork.StockDiv != 0)
            {
                switch (_inventInputSearchCndtnWork.StockDiv)
                {
                    case 1:     // 自社分のみ
                        retstring += " AND IVD.STOCKDIVRF=0";
                        break;
                    case 2:     // 受託分のみ     
                        retstring += " AND IVD.STOCKDIVRF!=0";
                        break;
                }
            }

            //差異分抽出区分
            if (_inventInputSearchCndtnWork.DifCntExtraDiv != 0)
            {
                switch (_inventInputSearchCndtnWork.DifCntExtraDiv)
                {
                    case 1:     // 数未入力分のみ 棚卸実施日が[Null]の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS Null";
                        break;
                    case 2:     // 数入力分のみ   棚卸実施日が[Null]以外の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS NOT Null" + Environment.NewLine;
                        break;
                    case 3:     // 差異分のみ
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=IVD.STOCKTOTALRF" + Environment.NewLine;
                        break;
                }
            }

            // 出力指定区分 0:全て,1:棚卸未入力分のみ,2:差異分のみ,3:重複棚番ありのみ
            if (_inventInputSearchCndtnWork.OutputAppointDiv != 0)
            {
                switch (_inventInputSearchCndtnWork.OutputAppointDiv)
                {
                    case 1:     // 数未入力分のみ 棚卸実施日が[Null]の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS Null" + Environment.NewLine;
                        break;
                    case 2:     // 差異分のみ
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=IVD.STOCKTOTALRF" + Environment.NewLine;
                        break;
                    case 3:     // 重複棚番ありのみ
                        retstring += " AND ( IVD.DUPLICATIONSHELFNO1RF IS NOT Null " + Environment.NewLine;
                        retstring += "      OR IVD.DUPLICATIONSHELFNO2RF IS NOT Null) " + Environment.NewLine;
                        break;
                }
            }

            //在庫数0抽出区分
            if (_inventInputSearchCndtnWork.StockCntZeroExtraDiv != 0)
            {
                retstring += " AND IVD.STOCKTOTALRF!=0" + Environment.NewLine;
            }

            //棚卸在庫数0抽出区分
            if (_inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv != 0)
            {
                retstring += " AND IVD.INVENTORYSTOCKCNTRF!=0" + Environment.NewLine;
            }

            //基準日設定
            if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 0)
            {
                //棚卸準備処理日が初期値以外
                int ymdInventoryPreprday = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.INVENTORYPREPRDAYRF!=" + ymdInventoryPreprday.ToString();
            }
            else if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 1)
            {
                //棚卸日が初期値以外
                int ymdInventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.INVENTORYDATERF!=" + ymdInventoryDate.ToString();
            }
            else if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 2)
            {
                //棚卸更新日が初期値以外
                int ymdInventoryUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.LASTINVENTORYUPDATERF!=" + ymdInventoryUpDate.ToString();
            }
            // 棚卸差異表の場合、棚卸数未入力は出力対象外とする
            if (_inventInputSearchCndtnWork.SelectedPaperKind == 1)
            {
                retstring += " AND IVD.INVENTORYDAYRF IS NOT NULL " + Environment.NewLine;
            }
            if ((_inventInputSearchCndtnWork.SelectedPaperKind != -1) && (_inventInputSearchCndtnWork.SelectedPaperKind != 2)) // 棚卸表以外
            {
                // --- DEL 2009/11/30 ---------->>>>>
                // 棚卸表以外は過不足更新が行われていないデータを抽出
                //retstring += " AND IVD.TOLERANCEUPDATECDRF = 0" + Environment.NewLine;
                // --- DEL 2009/11/30 ----------<<<<<
            }
            // ADD 2009/06/01 <<<
            return retstring;
        }
        #endregion    // Where文作成

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/01</br>
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
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
    }
}

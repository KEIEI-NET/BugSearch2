//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリストDBリモートオブジェクト
// プログラム概要   : 発注点設定マスタリスト実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注点設定マスタリストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリスト実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.03.27</br>
    /// </remarks>
    public class OrderSetMasListDB : RemoteDB, IOrderSetMasListDB
    {
        #region クラスコンストラクタ
        /// <summary>
        /// 発注点設定マスタリストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public OrderSetMasListDB()
            : base("PMHAT02029D", "Broadleaf.Application.Remoting.ParamData.OrderSetMasListWork", "ORDERSETMASLIST")
        {

        }
        #endregion

        #region [Search]
        #region 指定された条件の発注点設定マスタリスト一覧表情報LISTの取得処理
        /// <summary>
        /// 指定された条件の発注点設定マスタリスト一覧表情報LISTを戻します
        /// </summary>
        /// <param name="orderSetMasListParaWork">検索パラメータ</param>
        /// <param name="orderSetMasListWork">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の発注点設定マスタリスト一覧表情報LISTを戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Search(out object orderSetMasListWork, ref object orderSetMasListParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            orderSetMasListWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out orderSetMasListWork, orderSetMasListParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "orderSetMasListDB.Search");
                orderSetMasListWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "orderSetMasList.DB");
                orderSetMasListWork = new ArrayList();
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
            return status;
        }
        #endregion

        #region 指定された条件の発注点設定マスタリスト一覧表情報LIST(外部からのSqlConnectionを使用)
        /// <summary>
        /// 指定された条件の発注点設定マスタリスト一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索パラメータ</param>
        /// <param name="paraObj">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の発注点設定マスタリスト一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            OrderSetMasListParaWork paraWork = null;
            paraWork = paraObj as OrderSetMasListParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                selectTxt = MakeSearchSQL(ref selectTxt, ref sqlCommand,  paraWork);
              
                //ソート順
                selectTxt.Append( " ORDER BY ");
                //発注点設定マスタ.パターン番号 　(設定コード）
                selectTxt.Append( "A.PATTERNORF, ");
                selectTxt.Append( "A.PATTERNNODERIVEDNORF ");
                selectTxt.Append( " ASC ");
                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                //int con = 1;
                while (myReader.Read())
                {
                    al.Add(CopyToOrderSetMasListWorkFromReader(ref myReader));
                    //al.Add(CopyToOrderSetMasListWorkFromReader(ref myReader, con));
                    //con++;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;

        }

        
        #endregion

        #region 検索用SQLの取得処理
        /// <summary>
        /// 検索用SQLの取得処理
        /// </summary>
        /// <param name="selectTxt">sql文</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 検索用SQLを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL(ref StringBuilder selectTxt, ref SqlCommand sqlCommand, OrderSetMasListParaWork paraWork)
        {
            #region [取得項目]
            selectTxt.Append( "SELECT DISTINCT ");
            selectTxt.Append( "A.PATTERNORF PATTERNORF, " );                        // 設定コード
            selectTxt.Append( "A.PATTERNNODERIVEDNORF PATTERNNODERIVEDNORF, ");     // パターン番号枝番
            selectTxt.Append( "A.WAREHOUSECODERF WAREHOUSECODERF, " );              // 倉庫コード
            selectTxt.Append( "B.WAREHOUSENAMERF WAREHOUSENAMERF, ");               // 倉庫名称
            selectTxt.Append( "A.SUPPLIERCDRF SUPPLIERCDRF, "  );                   // 仕入先コード
            selectTxt.Append( "C.SUPPLIERSNMRF SUPPLIERSNMRF, " );                  // 仕入先名
            selectTxt.Append( "A.GOODSMAKERCDRF GOODSMAKERCDRF, " );                // 商品メーカーコード
            selectTxt.Append( "D.MAKERNAMERF MAKERNAMERF, " );                      // メーカー名称
            selectTxt.Append( "A.GOODSMGROUPRF GOODSMGROUPRF, ");                   // 商品中分類コード
            selectTxt.Append( "E.GOODSMGROUPNAMERF GOODSMGROUPNAMERF, ");           // 商品中分類名称
            selectTxt.Append( "A.BLGROUPCODERF BLGROUPCODERF, ");                   // BLグループコード
            selectTxt.Append("F.BLGROUPKANANAMERF BLGROUPKANANAMERF, ");            // BLグループコードカナ名称
            selectTxt.Append( "A.BLGOODSCODERF BLGOODSCODERF, ");                   // BL商品コード
            selectTxt.Append( "G.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");           // BL商品コード名称
            selectTxt.Append( "A.STCKSHIPMONTHSTRF STCKSHIPMONTHSTRF, ");           // 在庫出荷対象開始月
            selectTxt.Append( "A.STCKSHIPMONTHEDRF STCKSHIPMONTHEDRF, ");           // 在庫出荷対象終了月
            selectTxt.Append( "A.ORDERAPPLYDIVRF ORDERAPPLYDIVRF, ");               // 発注適用区分
            selectTxt.Append( "A.STOCKCREATEDATERF STOCKCREATEDATERF, ");           //在庫登録日
            selectTxt.Append( "A.SHIPSCOPEMORERF SHIPSCOPEMORERF, "  );             //出荷数範囲(以上)
            selectTxt.Append( "A.SHIPSCOPELESSRF SHIPSCOPELESSRF, "  );             //出荷数範囲(以下)
            selectTxt.Append( "A.MINIMUMSTOCKCNTRF MINIMUMSTOCKCNTRF, " );          //最低在庫数
            selectTxt.Append( "A.MAXIMUMSTOCKCNTRF MAXIMUMSTOCKCNTRF, " );          //最高在庫数
            selectTxt.Append( "A.SALESORDERUNITRF SALESORDERUNITRF, " );           //発注単位(発注ロット)
            selectTxt.Append( "A.ORDERPPROCUPDFLGRF ORDERPPROCUPDFLGRF ");       //発注点処理更新フラグ

            #endregion
            #region [テーブル]
            selectTxt.Append( "FROM ");
            selectTxt.Append( "ORDERPOINTSTRF A ");
            // 倉庫マスタ
            selectTxt.Append(" LEFT JOIN WAREHOUSERF B ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.WAREHOUSECODERF = B.WAREHOUSECODERF " );
            selectTxt.Append(" AND B.LOGICALDELETECODERF = 0) ");
            // 仕入先マスタ
            selectTxt.Append("LEFT JOIN SUPPLIERRF C ON ");  
            selectTxt.Append("(A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
            selectTxt.Append("AND A.SUPPLIERCDRF = C.SUPPLIERCDRF ");
            selectTxt.Append("AND C.LOGICALDELETECODERF = 0) ");
            // メーカーマスタ
            selectTxt.Append("LEFT JOIN MAKERURF D ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
            selectTxt.Append("AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
            selectTxt.Append("AND D.LOGICALDELETECODERF = 0) ");
             // 商品中分類マスタ
            selectTxt.Append( "LEFT JOIN GOODSGROUPURF E ON  ");
            selectTxt.Append("(A.ENTERPRISECODERF = E.ENTERPRISECODERF  ");
            selectTxt.Append(" AND A.GOODSMGROUPRF = E.GOODSMGROUPRF  ");
            selectTxt.Append(" AND E.LOGICALDELETECODERF = 0) ");
            // BLグループマスタ
            selectTxt.Append( "LEFT JOIN BLGROUPURF F ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = F.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.BLGROUPCODERF = F.BLGROUPCODERF ");
            selectTxt.Append(" AND F.LOGICALDELETECODERF = 0) ");
            // BLコードマスタ
            selectTxt.Append( "LEFT JOIN BLGOODSCDURF G ON  ");
            selectTxt.Append( "(A.ENTERPRISECODERF = G.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.BLGOODSCODERF = G.BLGOODSCODERF ");
            selectTxt.Append(" AND G.LOGICALDELETECODERF = 0) ");
            #endregion
            #region [抽出条件]
            MakeWhereString(ref selectTxt, ref sqlCommand, paraWork);

            return selectTxt;
            #endregion
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成処理と条件値設定処理
        /// </summary>
        /// <param name="sql">sql文</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>sql文</returns>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref StringBuilder sql, ref SqlCommand sqlCommand, OrderSetMasListParaWork paraWork)
        {
            sql.Append(" WHERE  ");
            // A.企業コード=パラメータ.企業コード
            sql.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE1 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            //AND A.設定コード(開始)　=パラメータ.設定コード
            //-------------ADD 2009/07/13 PVCS334---------->>>>>
            if (!string.IsNullOrEmpty(paraWork.StartSetCode)) 　// 画面の設定コード(開始)が入力された場合
            {
                sql.Append(" AND A.PATTERNORF>= @STPATTERNORF ");
                SqlParameter paraStPatterNo = sqlCommand.Parameters.Add("@STPATTERNORF", SqlDbType.Int);
                paraStPatterNo.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.StartSetCode));
            }
            //-------------ADD 2009/07/13 PVCS334----------<<<<<
            if (!string.IsNullOrEmpty(paraWork.EndSetCode)) 　// 画面の設定コード(終了)が入力された場合
            {
                sql.Append(" AND A.PATTERNORF <= @EDPATTERNORF ");
                SqlParameter paraEdPatterNo = sqlCommand.Parameters.Add("@EDPATTERNORF", SqlDbType.Int);
                paraEdPatterNo.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.EndSetCode));
            }

            //AND A.倉庫コード　=パラメータ.倉庫コード　　　// 画面の倉庫(開始)が入力された場合
            if (!string.IsNullOrEmpty(paraWork.StartWarehouseCode))
            {
                sql.Append(" AND A.WAREHOUSECODERF >= @STWAREHOUSE ");
                SqlParameter paraStWareHouse = sqlCommand.Parameters.Add("@STWAREHOUSE", SqlDbType.NChar);
                paraStWareHouse.Value = SqlDataMediator.SqlSetString(paraWork.StartWarehouseCode);
            }
            if (!string.IsNullOrEmpty(paraWork.EndWarehouseCode)) // 画面の倉庫(終了)が入力された場合
            {
                sql.Append(" AND A.WAREHOUSECODERF <= @EDWAREHOUSE ");
                SqlParameter paraEdWareHouse = sqlCommand.Parameters.Add("@EDWAREHOUSE", SqlDbType.NChar);
                paraEdWareHouse.Value = SqlDataMediator.SqlSetString(paraWork.EndWarehouseCode);
            }

            //AND A.仕入先コード　=パラメータ.仕入先コード　　　// 画面の仕入先(開始)が入力された場合
            if (0 != paraWork.StartSupplierCd)
            {
                sql.Append(" AND A.SUPPLIERCDRF >= @STSUPPLIERCDRF ");
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCDRF", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.StartSupplierCd);
            }
            if (0 != paraWork.EndSupplierCd) // 画面の仕入先(終了)が入力された場合
            {
                sql.Append(" AND A.SUPPLIERCDRF <= @EDSUPPLIERCDRF ");
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCDRF", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.EndSupplierCd);
            }

            //AND A.メーカーコード　=パラメータ.メーカーコード　　　// 画面のメーカー(開始)が入力された場合
            if (0 != paraWork.StartGoodsMakerCd)
            {
                sql.Append(" AND A.GOODSMAKERCDRF >= @STGOODSMAKERCDRF ");
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCDRF", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.StartGoodsMakerCd);
            }
            if (0 != paraWork.EndGoodsMakerCd) // 画面のメーカー(終了)が入力された場合
            {
                sql.Append(" AND A.GOODSMAKERCDRF <= @EDGOODSMAKERCDRF ");
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCDRF", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.EndGoodsMakerCd);
            }

            //AND A.商品中分類コード　=パラメータ.商品中分類コード　　　// 画面の中分類(開始)が入力された場合
            if (0 != paraWork.StartGoodsMGroup)
            {
                sql.Append(" AND A.GOODSMGROUPRF >= @STGOODSMGROUPRF ");
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUPRF", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paraWork.StartGoodsMGroup);
            }
            if (0 != paraWork.EndGoodsMGroup) // 画面の中分類(終了)が入力された場合
            {
                sql.Append(" AND A.GOODSMGROUPRF <= @EDGOODSMGROUPRF ");
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUPRF", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paraWork.EndGoodsMGroup);
            }

            //AND A.BLグループコード　=パラメータ.BLグループコード　　　// 画面のグループ(開始)が入力された場合
            if (0 != paraWork.StartBLGroupCode)
            {
                sql.Append(" AND A.BLGROUPCODERF >= @STBLGROUPCODERF ");
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODERF", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paraWork.StartBLGroupCode);
            }
            if (0 != paraWork.EndBLGroupCode) // 画面のグループ(終了)が入力された場合
            {
                sql.Append(" AND A.BLGROUPCODERF <= @EDBLGROUPCODERF ");
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODERF", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paraWork.EndBLGroupCode);
            }

            //AND A.BL商品コード　=パラメータ.BL商品コード　　　// 画面のBLコード(開始)が入力された場合
            if (0 != paraWork.StartBLGoodsCode)
            {
                sql.Append(" AND A.BLGOODSCODERF >= @STBLGOODSCODERF ");
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODERF", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paraWork.StartBLGoodsCode);
            }
            if (0 != paraWork.EndBLGoodsCode) // 画面のBLコード(終了)が入力された場合
            {
                sql.Append(" AND A.BLGOODSCODERF <= @EDBLGOODSCODERF ");
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODERF", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paraWork.EndBLGoodsCode);
            }

            //AND A.論理削除区分 = パラメータ.発行タイプ
            // パラメータ.発行タイプ != [2:全て]
            if (2 != paraWork.PrintType )
            {
                sql.Append(" AND A.LOGICALDELETECODERF=@LOGICALDELETECODERF ");
                SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);
                paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(paraWork.PrintType);
            }
            return sql;
        }
        #endregion
        #endregion

        #region クラス格納処理 Reader → OrderSetMasListWork
        /// <summary>
        /// クラス格納処理 Reader → USysDemoFeeMessWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : ReaderからOrderSetMasListWorkへ変換します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private OrderSetMasListWork CopyToOrderSetMasListWorkFromReader(ref SqlDataReader myReader)
        {
            OrderSetMasListWork listWork = new OrderSetMasListWork();
            #region クラスへ格納

            string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            int supplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            int goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            int goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            int bLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            int bLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));

            // 設定コード=発注点設定マスタ．パターン番号		
            listWork.PatterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNORF"));

            // 倉庫はNULL場合
            if (String.IsNullOrEmpty(warehouseCode))
            {
                listWork.WarehouseCode = "0000";
                listWork.WarehouseName = "全倉庫";
            }
            else if (warehouseCode.Trim().Equals("0000"))
            {
                listWork.WarehouseCode = "0000";
                listWork.WarehouseName = "全倉庫";
            }
            else
            {   // 倉庫コード=発注点設定マスタ．倉庫コード
                listWork.WarehouseCode = warehouseCode;
                // 倉庫名称 =倉庫マスタ. 倉庫名称
                listWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }

            // 仕入先はNULL場合
            if (0 == supplierCd)
            {
                listWork.SupplierCd = "000000";
                listWork.SupplierSnm = "全仕入先";
            }
            else
            {
                // 仕入先コード=発注点設定マスタ．仕入先コード    
                listWork.SupplierCd = supplierCd.ToString();
                // 仕入先名称=仕入先マスタ.仕入先略称
                listWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            }

            // メーカーはNULL場合
            if (0 == goodsMakerCd)
            {
                listWork.GoodsMakerCd = "0000";
                listWork.MakerName = "全メーカー";
            }
            else
            {
                // メーカーコード=発注点設定マスタ．商品メーカーコード
                listWork.GoodsMakerCd = goodsMakerCd.ToString();
                // メーカー名称	=メーカーマスタ.メーカー名称
                listWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            }

            // 商品中分類はNULL場合
            if (0 == goodsMGroup)
            {
                listWork.GoodsMGroup = "0000";
                listWork.GoodsMGroupName = "全商品中分類";
            }
            else
            {
                // 商品中分類コード=発注点設定マスタ．商品中分類コード
                listWork.GoodsMGroup = goodsMGroup.ToString();
                // 商品中分類名称	=商品中分類マスタ.商品中分類名称
                listWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            }

            // BL商品コードはNULL場合
            if (0 == bLGoodsCode)
            {
                listWork.BLGoodsCode = "00000";
                listWork.BLGoodsHalfName = "全ＢＬコード";
            }
            else
            {
                // BL商品コード=発注点設定マスタ．BL商品コード
                listWork.BLGoodsCode = bLGoodsCode.ToString();
                // BL商品コード名称（半角）	=ＢＬ商品コードマスタ.BL商品コード名称（半角）
                listWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }

            // BLグループはNULL場合
            if (0 == bLGroupCode)
            {
                listWork.BLGroupCode = "00000";
                listWork.BLGroupName = "全グループコード";
            }
            else
            {
                // BLグループコード=発注点設定マスタ．BLグループコード
                listWork.BLGroupCode = bLGroupCode.ToString();
                // BLグループコード名称	=BLグループマスタ.BLグループコードカナ名称
                listWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            }

            // 在庫出荷対象開始月 = 発注点設定マスタ．在庫出荷対象開始月
            string stckShipMonthSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHSTRF")).ToString();
            if (String.IsNullOrEmpty(stckShipMonthSt))
            {
                listWork.StckShipMonthSt = String.Empty;
            }
            else
            {
                listWork.StckShipMonthSt = DateTime.ParseExact(stckShipMonthSt, "yyyyMMdd", null).ToString("yyyy/MM/dd");
            }

            // 在庫出荷対象終了月 =発注点設定マスタ．在庫出荷対象終了月
            string stckShipMonthEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHEDRF")).ToString();
            if (String.IsNullOrEmpty(stckShipMonthEd))
            {
                listWork.StckShipMonthEd = String.Empty;
            }
            else
            {
                listWork.StckShipMonthEd = DateTime.ParseExact(stckShipMonthEd, "yyyyMMdd", null).ToString("yyyy/MM/dd");
            }

            // 出荷数範囲(以上) =発注点設定マスタ．出荷数範囲(以上)
            listWork.ShipScopeMore = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPEMORERF"));
            // 出荷数範囲(以下)	=発注点設定マスタ．出荷数範囲(以下)	  
            listWork.ShipScopeLess = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPELESSRF"));
            // 最低在庫数=発注点設定マスタ．最低在庫数	
            listWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            // 最高在庫数=発注点設定マスタ．最高在庫数
            listWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            // ロット数=発注点設定マスタ．発注単位
            listWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            // フラグ=発注点設定マスタ．発注点処理更新フラグ
            int orderPProcUpdFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERPPROCUPDFLGRF"));
            listWork.OrderPProcUpdFlg = OrderPProcUpdFlgConvToString(orderPProcUpdFlg);

            // 発注適用区分=発注点設定マスタ．発注適用区分
            int orderApplyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERAPPLYDIVRF"));
            listWork.OrderApplyDiv = OrderApplyDivConvToString(orderApplyDiv);

            // 在庫登録日
            string stockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF")).ToString();
            if (String.IsNullOrEmpty(stockCreateDate))
            {
                listWork.StockCreateDate = String.Empty;
            }
            else
            {
                listWork.StockCreateDate = DateTime.ParseExact(stockCreateDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + "以前";
            }
            #endregion
            return listWork;
        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="_orderPProcUpdFlg">発注点処理更新フラグ int</param>
        /// <returns>発注点処理更新フラグ string</returns>
        /// <remarks>
        /// <br>Note       : 発注点処理更新フラグ取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks> 
        private string OrderPProcUpdFlgConvToString(int _orderPProcUpdFlg)
        {
            string orderPProcUpdFlg = string.Empty;
            switch (_orderPProcUpdFlg)
            {
                case (0):
                    {
                        // 未更新
                        orderPProcUpdFlg = "未更新";
                    }
                    break;
                case (1):
                    {
                        // 更新済
                        orderPProcUpdFlg = "更新済";
                    }
                    break;
            }

            return orderPProcUpdFlg;
        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="_orderApplyDiv">発注適用区分 int</param>
        /// <returns>発注適用区分 string</returns>
        /// <remarks>
        /// <br>Note       : 発注適用区分取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks> 
        private string OrderApplyDivConvToString(int _orderApplyDiv)
        {
            string orderApplyDiv = string.Empty;
            switch (_orderApplyDiv)
            {
                case (0):
                    {
                        // 平均
                        orderApplyDiv = "平均";
                    }
                    break;
                case (1):
                    {
                        // 合計
                        orderApplyDiv = "合計";
                    }
                    break;
            }

            return orderApplyDiv;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
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

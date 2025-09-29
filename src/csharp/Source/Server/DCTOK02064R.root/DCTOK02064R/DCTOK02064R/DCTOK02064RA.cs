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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出荷商品分析表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品分析表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>UpdateNote : 返品金額が二重集計されている対応</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.04.02</br>
    /// <br></br>
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.29</br>
    /// <br></br>
    /// <br>UpdateNote : 不具合修正</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.22</br>
    /// <br></br>
    /// <br>UpdateNote : 不具合修正</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.27</br>
    /// <br></br>
    /// <br>UpdateNote : Mantis:14238</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2009/11/05</br>
    /// <br></br>
    /// <br>UpdateNote : 品名の取得方法を変更</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/05/13</br>
    /// <br></br>
    /// <br>UpdateNote : イスコ対応・READUNCOMMITTED対応</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br>Update Note: 2012/05/22 李小路</br>
    /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
    /// <br>             Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
    /// <br>Update Note: 2014/12/22 尹晶晶</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : 明治産業様Seiken品番変更</br>
    /// <br>Update Note: 2015/04/01 zhangll</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応</br>
    /// </remarks>
    [Serializable]
    public class ShipGoodsAnalyzeDB : RemoteDB, IShipGoodsAnalyzeDB
    {
        /// <summary>
        /// 出荷商品分析表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.21</br>
        /// </remarks>
        public ShipGoodsAnalyzeDB()
            :
            base("DCTOK02066D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_ShipGoodsAnalyzeWork", "GOODSMTTLSASLIPRF")
        {
        }

        #region [SearchShipGoodsAnalyze]
        /// <summary>
        /// 指定された条件の出荷商品分析表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品分析表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.21</br>
        public int SearchShipGoodsAnalyze(out object retObj, object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork = null;
            //RsltInfo_ShipGoodsAnalyzeWork rsltInfo_ShipGoodsAnalyzeWork = null;

            ArrayList extrInfo_ShipGoodsAnalyzeWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_ShipGoodsAnalyzeWorkList == null)
            {
                extrInfo_ShipGoodsAnalyzeWork = paraObj as ExtrInfo_ShipGoodsAnalyzeWork;
            }
            else
            {
                if (extrInfo_ShipGoodsAnalyzeWorkList.Count > 0)
                    extrInfo_ShipGoodsAnalyzeWork = extrInfo_ShipGoodsAnalyzeWorkList[0] as ExtrInfo_ShipGoodsAnalyzeWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTMTTLSALSLIPRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●出荷商品分析表取得
                status = SearchShipGoodsAnalyzeProc(ref retList, extrInfo_ShipGoodsAnalyzeWork, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGoodsAnalyzeDB.SearchShipGoodsAnalyze");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// 指定された条件の出荷商品分析表を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_ShipGoodsAnalyzeWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の出荷商品分析表を戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>Update Note: 2010/05/13 長内数馬</br>
        /// <br>            ・品名の取得方法を変更</br>
        /// <br>Update Note: 2012/05/22 李小路</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// <br></br>
        private int SearchShipGoodsAnalyzeProc(ref ArrayList retList, ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // ADD 2008.10.22 >>>
                string selectTxt = "";
                string sBuf = null;
                if (extrInfo_ShipGoodsAnalyzeWork.BeforeAfter == 0)
                    sBuf = "<=";  //以前
                else
                    sBuf = ">=";  //以降
                // ADD 2008.10.22 <<<

                sqlCommand = new SqlCommand("", sqlConnection);

                // 対象テーブル
                // GOODSMTTLSASLIPRF GMSLP 商品別売上月次集計データ
                // STOCKRF           STOCK 在庫マスタ
                // GOODSURF          GOODS 商品マスタ(ユーザー)
                // MAKERURF          MAKER メーカーマスタ(ユーザー)
                // SUPPLIERRF        SUPLR 仕入先マスタ
                // SECINFOSETRF      SCINF 拠点情報設定マスタ
                // BLGROUPURF        BLGPU BLグループマスタ(ユーザー)
                // BLGOODSCDURF      BLGSU BL商品コードマスタ(ユーザー)

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                // DEL 李小路 2012/05/22 Redmine#29911 ------------->>>>>
                //selectTxt += IFBy(extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec,
                //             "  ,GMSLP.ADDUPSECCODERF" + Environment.NewLine);
                //selectTxt += IFBy(extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec,
                //             "  ,SCINF2.SECTIONGUIDESNMRF" + Environment.NewLine);
                // DEL 李小路 2012/05/22 Redmine#29911 -------------<<<<<
                selectTxt += "  ,GMSLP.ADDUPSECCODERF" + Environment.NewLine;       // ADD 李小路 2012/05/22 Redmine#29911
                selectTxt += "  ,SCINF2.SECTIONGUIDESNMRF" + Environment.NewLine;   // ADD 李小路 2012/05/22 Redmine#29911
                selectTxt += "  ,GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += "  ,MAKER.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPLR.SUPPLIERSNMRF" + Environment.NewLine;
                // -- UPD 2010/05/13 ------------------------------------------>>>
                //selectTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                //selectTxt += "  ,(CASE WHEN GOODS.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODS.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine; //DEL 2014/12/22 尹晶晶 FOR Redmine#44209改良
                // -- UPD 2010/05/13 ------------------------------------------<<<
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>> 
                //合算の場合、品名の取得
                if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                {
                    // 新品番のときは、新品番マスタ→新品番集計データ→旧品番マスタ→旧品番集計データの優先順位で取得
                    // 旧品番のときは、旧品番マスタ→旧品番集計データ→新品番マスタ→新品番集計データの優先順位で取得
                    selectTxt += " ,(CASE WHEN GOODS.GOODSNAMEKANARF IS NULL THEN" + Environment.NewLine;
                    selectTxt +="    (CASE WHEN GSMSLP2.GOODSNAMEKANARF IS NULL THEN" + Environment.NewLine;
                    selectTxt +="     (CASE WHEN GOODSU2.GOODSNAMEKANARF IS NULL THEN GSMSLP3.GOODSNAMEKANARF ELSE GOODSU2.GOODSNAMEKANARF END)" + Environment.NewLine;
                    selectTxt +="    ELSE GSMSLP2.GOODSNAMEKANARF END) "+ Environment.NewLine;
                    selectTxt += "  ELSE GOODS.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine;
                }
                //品番集計区分は「別々」場合
                else
                {
                    selectTxt += "  ,(CASE WHEN GOODS.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODS.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine;
                }
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                selectTxt += "  ,GMSLP.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.TOTALCOUNT" + Environment.NewLine;
                selectTxt += "  ,GMSLP.STOCKCOUNT" + Environment.NewLine;
                selectTxt += "  ,(GMSLP.TOTALCOUNT-GMSLP.STOCKCOUNT) AS ORDERCOUNT" + Environment.NewLine;
                selectTxt += "  ,GMSLP.SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                // ADD 2008.10.22 >>>
                selectTxt += "  ,GMSLP.STOCKSALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.STOCKGROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.STOCKSALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,GMSLP.STOCKDISCOUNTPRICERF" + Environment.NewLine;
                // ADD 2008.10.22 <<<

                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [データ抽出メインQuery]
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    GMSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                // DEL 李小路 2012/05/22 Redmine#29911 ------------->>>>>
                //selectTxt += IFBy(extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec,
                //             "   ,GMSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                // DEL 李小路 2012/05/22 Redmine#29911 -------------<<<<<
                selectTxt += "   ,GMSLPSUB.ADDUPSECCODERF" + Environment.NewLine;   // ADD 李小路 2012/05/22 Redmine#29911
                selectTxt += "   ,GMSLPSUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.GOODSNORF" + Environment.NewLine;
                //2008/12/12 >>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "   ,GMSLPSUB.BLGOODSCODERF" + Environment.NewLine;
                //2008/12/12 <<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "   ,SUM(GMSLPSUB.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.TOTALCOUNT) AS TOTALCOUNT" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.STOCKCOUNT) AS STOCKCOUNT" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.STOCKCREATEDATERF" + Environment.NewLine;
                // DEL 2008.11.27 >>>
                //selectTxt += "   ,SUM(GMSLPSUB.SHIPMENTPOSCNTRF) AS SHIPMENTPOSCNTRF" + Environment.NewLine;
                //selectTxt += "   ,SUM(GMSLPSUB.MINIMUMSTOCKCNTRF) AS MINIMUMSTOCKCNTRF" + Environment.NewLine;
                //selectTxt += "   ,SUM(GMSLPSUB.MAXIMUMSTOCKCNTRF) AS MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                // DEL 2008.11.27 <<<
                // ADD 2008.11.27 >>>
                selectTxt += "   ,GMSLPSUB.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.MINIMUMSTOCKCNTRF AS MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.MAXIMUMSTOCKCNTRF AS MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                // ADD 2008.11.27 <<<
                // ADD 2008.10.22 >>>
                selectTxt += "   ,SUM(GMSLPSUB.STOCKSALESMONEYRF) AS STOCKSALESMONEYRF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.STOCKGROSSPROFITRF) AS STOCKGROSSPROFITRF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.STOCKSALESRETGOODSPRICERF) AS STOCKSALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "   ,SUM(GMSLPSUB.STOCKDISCOUNTPRICERF) AS STOCKDISCOUNTPRICERF" + Environment.NewLine;
                // ADD 2008.10.22 <<<
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;

                //商品別売上月次集計データ
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GMSLPSUB2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,GMSLPSUB2.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,GMSLPSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "    ,GMSLPSUB2.BLGOODSCODERF" + Environment.NewLine;
                // DEL 2008.10.22 >>>
                //selectTxt += "    ,GMSLPSUB2.SALESMONEYRF" + Environment.NewLine;
                //selectTxt += "    ,GMSLPSUB2.GROSSPROFITRF" + Environment.NewLine;
                //selectTxt += "    ,GMSLPSUB2.SALESRETGOODSPRICERF" + Environment.NewLine;
                //selectTxt += "    ,GMSLPSUB2.DISCOUNTPRICERF" + Environment.NewLine;
                // DEL 2008.10.22 <<<
                // ADD 2008.10.22 >>>
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=0 THEN GMSLPSUB2.SALESMONEYRF ELSE 0 END) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=0 THEN GMSLPSUB2.GROSSPROFITRF ELSE 0 END) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=0 THEN GMSLPSUB2.SALESRETGOODSPRICERF ELSE 0 END) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=0 THEN GMSLPSUB2.DISCOUNTPRICERF ELSE 0 END) AS DISCOUNTPRICERF" + Environment.NewLine;

                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.SALESMONEYRF ELSE 0 END) AS STOCKSALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.GROSSPROFITRF ELSE 0 END) AS STOCKGROSSPROFITRF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.SALESRETGOODSPRICERF ELSE 0 END) AS STOCKSALESRETGOODSPRICERF" + Environment.NewLine;

                // 2009/11/05 >>>
                // STOCKDISCOUNTPRICERFにSALESMONEYRFがセットされていたのを修正
                //selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.SALESMONEYRF ELSE 0 END) AS STOCKDISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.DISCOUNTPRICERF ELSE 0 END) AS STOCKDISCOUNTPRICERF" + Environment.NewLine;
                // 2009/11/05 <<<

                // ADD 2008.10.22
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=0 THEN GMSLPSUB2.TOTALSALESCOUNTRF ELSE 0.0 END) AS TOTALCOUNT" + Environment.NewLine;
                selectTxt += "    ,(CASE WHEN GMSLPSUB2.RSLTTTLDIVCDRF=1 THEN GMSLPSUB2.TOTALSALESCOUNTRF ELSE 0.0 END) AS STOCKCOUNT" + Environment.NewLine;
                // ADD 2008.11.27 >>>
                if (extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate != DateTime.MinValue)
                {
                // ADD 2008.11.27 <<<

                    selectTxt += "    ,(CASE WHEN STOCK1.STOCKCREATEDATERF IS NOT NULL AND STOCK1.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE1 THEN STOCK1.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.STOCKCREATEDATERF IS NOT NULL AND STOCK2.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE2 THEN STOCK2.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.STOCKCREATEDATERF ELSE  NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.STOCKCREATEDATERF IS NOT NULL AND STOCK4.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE4 THEN STOCK4.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.STOCKCREATEDATERF IS NOT NULL AND STOCK5.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE5 THEN STOCK5.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.STOCKCREATEDATERF IS NOT NULL AND STOCK6.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE6 THEN STOCK6.STOCKCREATEDATERF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.STOCKCREATEDATERF ELSE  NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS STOCKCREATEDATERF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK1.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE1 THEN STOCK1.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK2.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE2 THEN STOCK2.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK4.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE4 THEN STOCK4.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK5.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE5 THEN STOCK5.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK6.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE6 THEN STOCK6.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS SHIPMENTPOSCNTRF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK1.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE1 THEN STOCK1.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK2.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE2 THEN STOCK2.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK4.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE4 THEN STOCK4.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK5.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE5 THEN STOCK5.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK6.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE6 THEN STOCK6.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS MINIMUMSTOCKCNTRF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK1.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE1 THEN STOCK1.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK2.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE2 THEN STOCK2.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK4.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE4 THEN STOCK4.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK5.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE5 THEN STOCK5.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK6.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE6 THEN STOCK6.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL AND STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE3 THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                // ADD 2008.11.27 >>>
                }
                else
                {
                    selectTxt += "    ,(CASE WHEN STOCK1.STOCKCREATEDATERF IS NOT NULL  THEN STOCK1.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.STOCKCREATEDATERF IS NOT NULL  THEN STOCK2.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL  THEN STOCK3.STOCKCREATEDATERF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL  THEN STOCK3.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.STOCKCREATEDATERF IS NOT NULL  THEN STOCK4.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.STOCKCREATEDATERF IS NOT NULL  THEN STOCK5.STOCKCREATEDATERF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.STOCKCREATEDATERF IS NOT NULL  THEN STOCK6.STOCKCREATEDATERF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.STOCKCREATEDATERF IS NOT NULL  THEN STOCK3.STOCKCREATEDATERF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS STOCKCREATEDATERF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK1.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK2.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK3.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK3.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK4.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK5.SHIPMENTPOSCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK6.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.SHIPMENTPOSCNTRF IS NOT NULL  THEN STOCK3.SHIPMENTPOSCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS SHIPMENTPOSCNTRF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK1.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK2.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK4.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK5.MINIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK6.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MINIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MINIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS MINIMUMSTOCKCNTRF" + Environment.NewLine;
                    selectTxt += "    ,(CASE WHEN STOCK1.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK1.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    selectTxt += "      (CASE WHEN STOCK2.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK2.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                    //selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;// DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "        (CASE WHEN STOCK4.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK4.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "         (CASE WHEN STOCK5.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK5.MAXIMUMSTOCKCNTRF ELSE" + Environment.NewLine;
                        selectTxt += "          (CASE WHEN STOCK6.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK6.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                        selectTxt += "         END)" + Environment.NewLine;
                        selectTxt += "        END)" + Environment.NewLine;
                        selectTxt += "       END)" + Environment.NewLine;
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                        selectTxt += "       (CASE WHEN STOCK3.MAXIMUMSTOCKCNTRF IS NOT NULL  THEN STOCK3.MAXIMUMSTOCKCNTRF ELSE NULL END)" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "      END)" + Environment.NewLine;
                    selectTxt += "     END) AS MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                }
                // ADD 2008.11.27 <<<
                // 2011/08/01 >>>
                //selectTxt += "   FROM GOODSMTTLSASLIPRF AS GMSLPSUB2" + Environment.NewLine;
                //selectTxt += "   FROM GOODSMTTLSASLIPRF AS GMSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;  // DEL  2014/12/22 尹晶晶 FOR Redmine#44209改良
                // 2011/08/01 <<<
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += "   FROM" + Environment.NewLine;
                    selectTxt += "   (" + Environment.NewLine;
                    selectTxt += "    SELECT" + Environment.NewLine;
                    selectTxt += "      GMSLPSUB3.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.SUPPLIERCDRF" + Environment.NewLine;
                    // 品番集計区分は「合算」且つ品番表示区分が「新品番」場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv == 0)
                    {
                        // 新品番を取る
                        selectTxt += "     ,(CASE WHEN GOODSNOCHANGE.CHGDESTGOODSNORF IS NULL THEN GMSLPSUB3.GOODSNORF ELSE GOODSNOCHANGE.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        // 旧品番を取る
                        selectTxt += "     ,(CASE WHEN GOODSNOCHANGETEMP.CHGSRCGOODSNORF IS NULL THEN GMSLPSUB3.GOODSNORF ELSE GOODSNOCHANGETEMP.CHGSRCGOODSNORF END) AS CHGGOODSNO" + Environment.NewLine;
                    }
                    // 品番集計区分は「合算」且つ品番表示区分が「旧品番」場合
                    else
                    {
                        // 旧品番を取る
                        selectTxt += "     ,(CASE WHEN GOODSNOCHANGETEMP.CHGSRCGOODSNORF IS NULL THEN GMSLPSUB3.GOODSNORF ELSE GOODSNOCHANGETEMP.CHGSRCGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        // 新品番を取る
                        selectTxt += "     ,(CASE WHEN GOODSNOCHANGE.CHGDESTGOODSNORF IS NULL THEN GMSLPSUB3.GOODSNORF ELSE GOODSNOCHANGE.CHGDESTGOODSNORF END) AS CHGGOODSNO" + Environment.NewLine;
                    }
                    selectTxt += "     ,GMSLPSUB3.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "     ,GMSLPSUB3.TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "   FROM GOODSMTTLSASLIPRF AS GMSLPSUB3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE.ENTERPRISECODERF=GMSLPSUB3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE.GOODSMAKERCDRF=GMSLPSUB3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE.CHGSRCGOODSNORF=GMSLPSUB3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGETEMP WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGETEMP.ENTERPRISECODERF=GMSLPSUB3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGETEMP.GOODSMAKERCDRF=GMSLPSUB3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGETEMP.CHGDESTGOODSNORF=GMSLPSUB3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGETEMP.LOGICALDELETECODERF = 0" + Environment.NewLine;

                    //WHERE
                    selectTxt += MakeWhereStringProc(ref sqlCommand, extrInfo_ShipGoodsAnalyzeWork, logicalMode);
                    selectTxt += "   )  AS GMSLPSUB2" + Environment.NewLine;
                }
                // 品番集計区分は「別々」場合
                else
                {
                    selectTxt += "   FROM GOODSMTTLSASLIPRF AS GMSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                //拠点情報設定マスタ
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN SECINFOSETRF SCINF" + Environment.NewLine;
                selectTxt += "   LEFT JOIN SECINFOSETRF SCINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  SCINF.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SCINF.SECTIONCODERF=GMSLPSUB2.ADDUPSECCODERF" + Environment.NewLine;

                //在庫マスタ ※拠点倉庫コード１
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN STOCKRF STOCK1" + Environment.NewLine;
                selectTxt += "   LEFT JOIN STOCKRF STOCK1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  STOCK1.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND STOCK1.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   AND STOCK1.GOODSNORF=GMSLPSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "   AND STOCK1.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD1RF" + Environment.NewLine;

                //在庫マスタ ※拠点倉庫コード２
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN STOCKRF STOCK2" + Environment.NewLine;
                selectTxt += "   LEFT JOIN STOCKRF STOCK2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  STOCK2.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND STOCK2.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   AND STOCK2.GOODSNORF=GMSLPSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "   AND STOCK2.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD2RF" + Environment.NewLine;

                //在庫マスタ ※拠点倉庫コード３
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN STOCKRF STOCK3" + Environment.NewLine;
                selectTxt += "   LEFT JOIN STOCKRF STOCK3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  STOCK3.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND STOCK3.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   AND STOCK3.GOODSNORF=GMSLPSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "   AND STOCK3.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD3RF" + Environment.NewLine;
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 新品番表示、新品番の商品が在庫していない場合、旧品番の在庫情報を表示する
                // 旧品番表示、旧品番の商品が在庫していない場合、新品番の在庫情報を表示する
                if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                {
                    //在庫マスタ ※拠点倉庫コード４
                    selectTxt += "   LEFT JOIN STOCKRF STOCK4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  STOCK4.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND STOCK4.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND STOCK4.GOODSNORF=GMSLPSUB2.CHGGOODSNO" + Environment.NewLine;
                    selectTxt += "   AND STOCK4.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD1RF" + Environment.NewLine;

                    //在庫マスタ ※拠点倉庫コード５
                    selectTxt += "   LEFT JOIN STOCKRF STOCK5 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  STOCK5.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND STOCK5.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND STOCK5.GOODSNORF=GMSLPSUB2.CHGGOODSNO" + Environment.NewLine;
                    selectTxt += "   AND STOCK5.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD2RF" + Environment.NewLine;

                    //在庫マスタ ※拠点倉庫コード６
                    selectTxt += "   LEFT JOIN STOCKRF STOCK6 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  STOCK6.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND STOCK6.GOODSMAKERCDRF=GMSLPSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND STOCK6.GOODSNORF=GMSLPSUB2.CHGGOODSNO" + Environment.NewLine;
                    selectTxt += "   AND STOCK6.WAREHOUSECODERF=SCINF.SECTWAREHOUSECD3RF" + Environment.NewLine;

                }
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                //BL商品コードマスタ(ユーザー)
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN BLGOODSCDURF BLGSU" + Environment.NewLine;
                selectTxt += "   LEFT JOIN BLGOODSCDURF BLGSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  BLGSU.ENTERPRISECODERF=GMSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND BLGSU.BLGOODSCODERF=GMSLPSUB2.BLGOODSCODERF" + Environment.NewLine;

                //BLグループマスタ(ユーザー)
                // 2011/08/01 >>>
                //selectTxt += "   LEFT JOIN BLGROUPURF BLGPU" + Environment.NewLine;
                selectTxt += "   LEFT JOIN BLGROUPURF BLGPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   ON  BLGPU.ENTERPRISECODERF=BLGSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND BLGPU.BLGROUPCODERF=BLGSU.BLGROUPCODERF" + Environment.NewLine;

                //WHERE
                selectTxt += MakeWhereString(ref sqlCommand, extrInfo_ShipGoodsAnalyzeWork, logicalMode);

                selectTxt += "  ) AS GMSLPSUB" + Environment.NewLine;

                // ADD ST By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 ---------->>>>>
                if ((extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1) 
                    && (extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt != "" 
                       || extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd != ""))
                {
                    string tableName = "GMSLPSUB";
                    selectTxt += GoodsNoMakeWhereString(ref sqlCommand, extrInfo_ShipGoodsAnalyzeWork, tableName);
                }
                // ADD ED By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 ----------<<<<<

                //GROUP BY
                selectTxt += "  GROUP BY" + Environment.NewLine;
                selectTxt += "    GMSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                // DEL 李小路 2012/05/22 Redmine#29911 ------------->>>>>
                //selectTxt += IFBy(extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec,
                //             "   ,GMSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                // DEL 李小路 2012/05/22 Redmine#29911 -------------<<<<<
                selectTxt += "   ,GMSLPSUB.ADDUPSECCODERF" + Environment.NewLine;   // ADD 李小路 2012/05/22 Redmine#29911
                selectTxt += "   ,GMSLPSUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "   ,GMSLPSUB.GOODSNORF" + Environment.NewLine;
                // 2008/12/12 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "   ,GMSLPSUB.BLGOODSCODERF" + Environment.NewLine;
                // 2008/12/12 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "   ,GMSLPSUB.STOCKCREATEDATERF" + Environment.NewLine;
                // ADD 2008.11.27 >>>
                selectTxt += "   ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "   ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "   ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                // ADD 2008.11.27 <<<

                #endregion  //[データ抽出メインQuery]

                selectTxt += " ) AS GMSLP" + Environment.NewLine;

                #region [JOIN]
                //仕入先マスタ
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN SUPPLIERRF SUPLR" + Environment.NewLine;
                selectTxt += " LEFT JOIN SUPPLIERRF SUPLR WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  SUPLR.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUPLR.SUPPLIERCDRF=GMSLP.SUPPLIERCDRF" + Environment.NewLine;

                //商品マスタ(ユーザー)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODS" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  GOODS.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSMAKERCDRF=GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;

                //-- ADD 2010/05/13 -------------------------------------------->>>
                selectTxt += " LEFT JOIN " + Environment.NewLine;
                selectTxt += " ( " + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += "     ,MAX(GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "     GOODSMTTLSASLIPRF" + Environment.NewLine;
                selectTxt += "     GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "   WHERE" + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF=@GSMSLP2ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF>=@GSMSLP2ADDUPYEARMONTHST" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF<=@GSMSLP2ADDUPYEARMONTHED" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += " ) AS GSMSLP2 " + Environment.NewLine;
                selectTxt += " ON  GSMSLP2.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSMAKERCDRF=GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@GSMSLP2ENTERPRISECODERF", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(extrInfo_ShipGoodsAnalyzeWork.EnterpriseCode);

                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth);

                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth);
                //-- ADD 2010/05/13 --------------------------------------------<<<

                //メーカーマスタ(ユーザー)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKER" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  MAKER.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKER.GOODSMAKERCDRF=GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "" + Environment.NewLine;

                //if (extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec) //DEL 李小路 2012/05/22 Redmine#29911
                {
                    //拠点情報設定マスタ
                    // 2011/08/01 >>>
                    //selectTxt += "  LEFT JOIN SECINFOSETRF SCINF2" + Environment.NewLine;
                    selectTxt += "  LEFT JOIN SECINFOSETRF SCINF2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/08/01 <<<
                    selectTxt += "  ON  SCINF2.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND SCINF2.SECTIONCODERF=GMSLP.ADDUPSECCODERF" + Environment.NewLine;
                }

                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //合算で新品番のときは、旧品番マスタ→旧品番集計データの品名を取る
                //合算で旧品番のときは、新品番マスタ→新品番集計データの品名を取る
                if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += " LEFT JOIN " + Environment.NewLine;
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,MAX(GOODSU3.GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                    selectTxt += "   FROM GOODSNOCHANGERF AS GOODSNOCHANGE1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSURF GOODSU3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSU3.ENTERPRISECODERF=GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSU3.GOODSMAKERCDRF=GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv == 0)
                    {
                        selectTxt += "   AND GOODSU3.GOODSNORF=GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += "   AND GOODSU3.GOODSNORF=GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    }
                    selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += " ) AS GOODSU2 " + Environment.NewLine;
                    selectTxt += " ON  GOODSU2.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND GOODSU2.GOODSMAKERCDRF=GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv == 0)
                    {
                        selectTxt += " AND GOODSU2.CHGDESTGOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += " AND GOODSU2.CHGSRCGOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;
                    }

                    selectTxt += " LEFT JOIN " + Environment.NewLine;
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,MAX(MTL.GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                    selectTxt += "   FROM GOODSNOCHANGERF AS GOODSNOCHANGE2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSMTTLSASLIPRF MTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  MTL.ENTERPRISECODERF=GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND MTL.GOODSMAKERCDRF=GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv == 0)
                    {
                        selectTxt += "   AND MTL.GOODSNORF=GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += "   AND MTL.GOODSNORF=GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    }
                    selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   WHERE" + Environment.NewLine;
                    selectTxt += "         MTL.ENTERPRISECODERF=@GNOCGEENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     AND MTL.ADDUPYEARMONTHRF>=@GNOCGEADDUPYEARMONTHST" + Environment.NewLine;
                    selectTxt += "     AND MTL.ADDUPYEARMONTHRF<=@GNOCGEADDUPYEARMONTHED" + Environment.NewLine;
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += " ) AS GSMSLP3 " + Environment.NewLine;
                    selectTxt += " ON  GSMSLP3.ENTERPRISECODERF=GMSLP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND GSMSLP3.GOODSMAKERCDRF=GMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoShowDiv == 0)
                    {
                        selectTxt += " AND GSMSLP3.CHGDESTGOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += " AND GSMSLP3.CHGSRCGOODSNORF=GMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    SqlParameter paraNEnterpriseCode = sqlCommand.Parameters.Add("@GNOCGEENTERPRISECODERF", SqlDbType.NChar);
                    paraNEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_ShipGoodsAnalyzeWork.EnterpriseCode);

                    SqlParameter paraNSalesDateSt = sqlCommand.Parameters.Add("@GNOCGEADDUPYEARMONTHST", SqlDbType.Int);
                    paraNSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth);

                    SqlParameter paraNSalesDateEd = sqlCommand.Parameters.Add("@GNOCGEADDUPYEARMONTHED", SqlDbType.Int);
                    paraNSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth);
                }
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                #endregion  //[JOIN]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;
                // ADD 2008.11.27 >>>
                if (extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate != DateTime.MinValue) 
                {
                // ADD 2008.11.27 <<<
                    // ADD 2008.10.22 >>>
                    SqlParameter paraStockCreateDate1 = sqlCommand.Parameters.Add("@STOCKCREATEDATE1", SqlDbType.Int);
                    SqlParameter paraStockCreateDate2 = sqlCommand.Parameters.Add("@STOCKCREATEDATE2", SqlDbType.Int);
                    SqlParameter paraStockCreateDate3 = sqlCommand.Parameters.Add("@STOCKCREATEDATE3", SqlDbType.Int);
                    paraStockCreateDate1.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                    paraStockCreateDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                    paraStockCreateDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        SqlParameter paraStockCreateDate4 = sqlCommand.Parameters.Add("@STOCKCREATEDATE4", SqlDbType.Int);
                        SqlParameter paraStockCreateDate5 = sqlCommand.Parameters.Add("@STOCKCREATEDATE5", SqlDbType.Int);
                        SqlParameter paraStockCreateDate6 = sqlCommand.Parameters.Add("@STOCKCREATEDATE6", SqlDbType.Int);
                        paraStockCreateDate4.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                        paraStockCreateDate5.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                        paraStockCreateDate6.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                    }
                    // 品番集計区分が別々の場合
                    else
                    {
                    }
                    //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                    // ADD 2008.10.22 <<<
                } // ADD 2008.11.27 

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_ShipGoodsAnalyzeFromReader(ref myReader, extrInfo_ShipGoodsAnalyzeWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGoodsAnalyzeDB.SearchShipGoodsAnalyzeProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_extrInfo_ShipGoodsAnalyzeWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.29</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_ShipGoodsAnalyzeWork _extrInfo_ShipGoodsAnalyzeWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
                string retstring = " WHERE ";

                //企業コード
                retstring += " GMSLPSUB2.ENTERPRISECODERF=@ENTERPRISECODE";
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnalyzeWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    retstring += " AND GMSLPSUB2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    retstring += " AND GMSLPSUB2.LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //拠点コード    ※配列で複数指定される
                if (_extrInfo_ShipGoodsAnalyzeWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _extrInfo_ShipGoodsAnalyzeWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND GMSLPSUB2.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    }
                }

                //対象年月
                retstring += " AND GMSLPSUB2.ADDUPYEARMONTHRF>=@ADDUPYEARMONTH_ST" + Environment.NewLine;
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH_ST", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth);

                retstring += " AND GMSLPSUB2.ADDUPYEARMONTHRF<=@ADDUPYEARMONTH_ED" + Environment.NewLine;
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH_ED", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth);

                //在庫登録日
                if (_extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate != DateTime.MinValue)
                {
                    string sBuf = null;
                    if (_extrInfo_ShipGoodsAnalyzeWork.BeforeAfter == 0)
                        sBuf = "<=";  //以前
                    else
                        sBuf = ">=";  //以降

                    retstring += " AND (" + Environment.NewLine;
                    retstring += "    STOCK1.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                    retstring += " OR STOCK2.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                    retstring += " OR STOCK3.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が合算の場合
                    if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 1)
                    {
                        retstring += " OR STOCK4.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                        retstring += " OR STOCK5.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                        retstring += " OR STOCK6.STOCKCREATEDATERF" + sBuf + "@STOCKCREATEDATE" + Environment.NewLine;
                    }
                    else
                    {
                        //なし
                    }
                    //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>

                    retstring += " )" + Environment.NewLine;
                    SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                    paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate);
                }

                //仕入先コード
                if (_extrInfo_ShipGoodsAnalyzeWork.SupplierCdSt != 0)
                {
                    retstring += " AND GMSLPSUB2.SUPPLIERCDRF>=@SUPPLIERCD_ST" + Environment.NewLine;
                    SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCD_ST", SqlDbType.Int);
                    paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.SupplierCdSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.SupplierCdEd != 999999999)
                {
                    retstring += " AND GMSLPSUB2.SUPPLIERCDRF<=@SUPPLIERCD_ED" + Environment.NewLine;
                    SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCD_ED", SqlDbType.Int);
                    paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.SupplierCdEd);
                }

                //商品メーカーコード
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdSt != 0)
                {
                    retstring += " AND GMSLPSUB2.GOODSMAKERCDRF>=@GOODSMAKERCD_ST" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCD_ST", SqlDbType.Int);
                    paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdEd != 999999)
                {
                    retstring += " AND GMSLPSUB2.GOODSMAKERCDRF<=@GOODSMAKERCD_ED" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCD_ED", SqlDbType.Int);
                    paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdEd);
                }

                //BL商品コード
                if (_extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeSt != 0)
                {
                    retstring += " AND GMSLPSUB2.BLGOODSCODERF>=@BLGOODSCODE_ST" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODE_ST", SqlDbType.Int);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeEd != 99999999)
                {
                    retstring += " AND GMSLPSUB2.BLGOODSCODERF<=@BLGOODSCODE_ED" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODE_ED", SqlDbType.Int);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeEd);
                }
                //------ DEL START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //商品番号
                //if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt != "")
                //{
                //    retstring += " AND GMSLPSUB2.GOODSNORF>=@GOODSNO_ST" + Environment.NewLine;
                //    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNO_ST", SqlDbType.NVarChar);
                //    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt);
                //}
                //if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd != "")
                //{
                //    retstring += " AND GMSLPSUB2.GOODSNORF<=@BLGOODSNO_ED" + Environment.NewLine;
                //    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@BLGOODSNO_ED", SqlDbType.NVarChar);
                //    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd);
                //}
                //------ DEL START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>

                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //商品番号
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoTtlDiv == 0)
                {
                    if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt != "")
                    {
                        retstring += " AND GMSLPSUB2.GOODSNORF>=@GOODSNO_ST" + Environment.NewLine;
                        SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNO_ST", SqlDbType.NVarChar);
                        paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt);
                    }
                    if (_extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd != "")
                    {
                        retstring += " AND GMSLPSUB2.GOODSNORF<=@BLGOODSNO_ED" + Environment.NewLine;
                        SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@BLGOODSNO_ED", SqlDbType.NVarChar);
                        paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd);
                    }
                }
                else
                {
                    //なし
                }
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>

                //BLグループコード
                if (_extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeSt != 0)
                {
                    retstring += " AND BLGSU.BLGROUPCODERF>=@BLGROUPCODE_ST" + Environment.NewLine;
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODE_ST", SqlDbType.Int);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeEd != 99999)
                {
                    if (_extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeSt == 0)
                    {
                        retstring += " AND (BLGSU.BLGROUPCODERF<=@BLGROUPCODERF_ED OR BLGSU.BLGROUPCODERF IS NULL)" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND BLGSU.BLGROUPCODERF<=@BLGROUPCODERF_ED" + Environment.NewLine;
                    }

                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODERF_ED", SqlDbType.Int);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeEd);
                }

                //商品大分類コード
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupSt != 0)
                {
                    retstring += " AND BLGPU.GOODSLGROUPRF>=@GOODSLGROUP_ST" + Environment.NewLine;
                    SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@GOODSLGROUP_ST", SqlDbType.Int);
                    paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupEd != 9999)
                {
                    if (_extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupSt == 0)
                    {
                        retstring += " AND (BLGPU.GOODSLGROUPRF<=@GOODSLGROUP_ED OR BLGPU.GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND BLGPU.GOODSLGROUPRF<=@GOODSLGROUP_ED" + Environment.NewLine;
                    }

                    SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@GOODSLGROUP_ED", SqlDbType.Int);
                    paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupEd);
                }

                //商品中分類コード
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupSt != 0)
                {
                    retstring += " AND BLGPU.GOODSMGROUPRF>=@GOODSMGROUP_ST" + Environment.NewLine;
                    SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@GOODSMGROUP_ST", SqlDbType.Int);
                    paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupSt);
                }
                if (_extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupEd != 9999)
                {
                    if (_extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupSt == 0)
                    {
                        retstring += " AND (BLGPU.GOODSMGROUPRF<=@GOODSMGROUP_ED OR BLGPU.GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND BLGPU.GOODSMGROUPRF<=@GOODSMGROUP_ED" + Environment.NewLine;
                    }
                    
                    SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@GOODSMGROUP_ED", SqlDbType.Int);
                    paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(_extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupEd);
                }
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[WHERE句生成処理]

        #region [WHERE句生成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_extrInfo_ShipGoodsAnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Programmer : 44209 尹晶晶</br>
        /// <br>Date       : 2014.12.23</br>
        private string MakeWhereStringProc(ref SqlCommand sqlCommand, ExtrInfo_ShipGoodsAnalyzeWork _extrInfo_ShipGoodsAnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string ret2string = " WHERE ";

            //企業コード
            ret2string += " GMSLPSUB3.ENTERPRISECODERF=@GMSLPSUB3ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@GMSLPSUB3ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnWork.EnterpriseCode);
  
            // DEL ST By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 -------------->>>>>
            ////商品番号
            //if (_extrInfo_ShipGoodsAnWork.GoodsNoSt != "")
            //{
            //    ret2string += " AND GMSLPSUB3.GOODSNORF>=@GMSLPSUB3GOODSNO_ST" + Environment.NewLine;
            //    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GMSLPSUB3GOODSNO_ST", SqlDbType.NVarChar);
            //    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnWork.GoodsNoSt);
            //}
            //if (_extrInfo_ShipGoodsAnWork.GoodsNoEd != "")
            //{
            //    ret2string += " AND GMSLPSUB3.GOODSNORF<=@GMSLPSUB3BLGOODSNO_ED" + Environment.NewLine;
            //    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GMSLPSUB3BLGOODSNO_ED", SqlDbType.NVarChar);
            //    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(_extrInfo_ShipGoodsAnWork.GoodsNoEd);
            //}
            // DEL ED By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 --------------<<<<<
            #endregion  //WHERE文作成

            return ret2string;
        }
        #endregion  //[WHERE句生成処理]

        // ADD ST By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 ---------->>>>>
        #region [品番条件 Where句 生成処理]
        private string GoodsNoMakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_ShipGoodsAnalyzeWork CndtnWork, string tableNm)
        {
            string retstring = " WHERE" + Environment.NewLine;

            //商品番号
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += tableNm + ".GOODSNORF>=@" + tableNm + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + tableNm + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }

            if (CndtnWork.GoodsNoSt != "" && CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + Environment.NewLine;
            }

            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += tableNm + ".GOODSNORF<=@" + tableNm + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + tableNm + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }

            return retstring;
        }
        #endregion
        // ADD ED By zhangll 2015/04/01 Redmine#44209の#434 品番条件を指定した場合、PM7相違障害の対応 ----------<<<<<

        #region [出荷商品分析表抽出結果クラス格納処理]
        /// <summary>
        /// 出荷商品分析表抽出結果クラス格納処理 Reader → RsltInfo_ShipGoodsAnalyzeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_ShipGoodsAnalyzeWork">検索条件格納クラス</param>
        /// <returns>RsltInfo_ShipGoodsAnalyzeWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.29</br>
        /// <br>Update Note: 2012/05/22 李小路</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#29911　出荷商品分析表 全社集計時の集約不正の対応</br>
        /// <br></br>
        /// </remarks>
        private RsltInfo_ShipGoodsAnalyzeWork CopyToRsltInfo_ShipGoodsAnalyzeFromReader(ref SqlDataReader myReader, ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork)
        {
            RsltInfo_ShipGoodsAnalyzeWork ResultWork = new RsltInfo_ShipGoodsAnalyzeWork();

            #region [抽出結果-値セット]
            //if (extrInfo_ShipGoodsAnalyzeWork.TtlType == (int)TtlType.Sec)     //DEL 李小路 2012/05/22 Redmine#29911
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            ResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            ResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            ResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            ResultWork.TotalCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALCOUNT"));
            ResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNT"));
            ResultWork.OrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCOUNT"));
            ResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
            ResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
            ResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
            ResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
            // ADD 2008.10.22 >>>
            ResultWork.StockSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSALESMONEYRF"));
            ResultWork.StockGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGROSSPROFITRF"));
            ResultWork.StockSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSALESRETGOODSPRICERF"));
            ResultWork.StockDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISCOUNTPRICERF"));
            // ADD 2008.10.22 <<<
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.21</br>
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

        /// <summary>
        /// 引数文字列の表示/非表示を判定します。
        /// </summary>
        /// <param name="bCondition">条件式</param>
        /// <param name="Text">文字列</param>
        /// <returns></returns>
        private string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        /// <summary>
        /// 集計方法を列挙します。
        /// </summary>
        enum TtlType
        {
            All = 0,  //0:全社
            Sec = 1   //1:拠点毎
        }
    }
}

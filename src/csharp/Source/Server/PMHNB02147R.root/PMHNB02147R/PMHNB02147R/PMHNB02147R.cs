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
    /// 出荷商品優良対応表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品優良対応表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br></br>
    /// <br>UpdateNote : イスコ対応・READUNCOMMITTED対応</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br>UpdateNote : 2014/12/30 尹晶晶</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : 明治産業様Seiken品番変更</br>
    /// <br>UpdateNote : 2015/05/08 田建委</br>
    /// <br>管理番号  : 11070263-00</br>
    /// <br>           : 明治産業様Seiken品番変更 グローバル変数の削除</br>
    /// </remarks>
    [Serializable]
    public class ShipGdsPrimeListResultWorkDB : RemoteDB, IShipGdsPrimeListResultWorkDB
    {
        //------ DEL 2015/05/08 田建委 グローバル変数の削除 ---------------->>>>>
        #region DEL
        ////------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        //#region [判別用フラグ宣言]
        //private bool goodsNoSum = false;   //合算の場合、旧品番表示
        //#endregion
        ////------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        #endregion
        //------ DEL 2015/05/08 田建委 グローバル変数の削除 ----------------<<<<<
        /// <summary>
        /// 出荷商品優良対応表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public ShipGdsPrimeListResultWorkDB()
            :
        base("PMHNB02149D", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork", "MTTLSALESSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region 出荷商品優良対応表
        /// <summary>
        /// 指定された企業コードの出荷商品優良対応表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">検索結果</param>
        /// <param name="shipGdsPrimeListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの出荷商品優良対応表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object shipGdsPrimeListResultList, object shipGdsPrimeListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            shipGdsPrimeListResultList = null;

            ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork = shipGdsPrimeListCndtnWork as ShipGdsPrimeListCndtnWork;

            try
            {
                status = SearchProc(out shipGdsPrimeListResultList, _shipGdsPrimeListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.Search Exception=" + ex.Message);
                shipGdsPrimeListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの出荷商品優良対応表LISTを全て戻します
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">検索結果</param>
        /// <param name="_shipGdsPrimeListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの出荷商品優良対応表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// <br>UpdateNote : 2015/05/08 田建委</br>
        /// <br>管理番号  : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更 グローバル変数の削除</br>
        private int SearchProc(out object shipGdsPrimeListResultList, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            shipGdsPrimeListResultList = null;

            ArrayList al = new ArrayList();   //抽出結果
            //------ DEL 2015/05/08 田建委 グローバル変数の削除 ---------------->>>>>
            #region DEL
            ////------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            ////合算の場合
            //if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
            //{
            //    goodsNoSum = true;
            //}
            ////別々の場合、既存の処理と同じ
            //else
            //{
            //    goodsNoSum = false;
            //}
            ////------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            #endregion
            //------ DEL 2015/05/08 田建委 グローバル変数の削除 ----------------<<<<<

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProc(ref al, ref sqlConnection, _shipGdsPrimeListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            shipGdsPrimeListResultList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_shipGdsPrimeListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref ArrayList al, ref SqlConnection sqlConnection, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";
                sqlCommand.Parameters.Clear();
                //SELECT文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += "  ,MTL_TOTAL.CHGSRCGOODSNORF" + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                selectTxt += "  ,MTL_TOTAL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESTIMESRF AS ST_SALESTIMESRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.TOTALSALESCOUNTRF AS ST_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESMONEYRF AS ST_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESRETGOODSPRICERF AS ST_SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.DISCOUNTPRICERF AS ST_DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.GROSSPROFITRF AS ST_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESTIMESRF - (CASE WHEN MTL_STOCK.SALESTIMESRF IS NULL THEN 0 ELSE MTL_STOCK.SALESTIMESRF END)) AS OR_SALESTIMESRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.TOTALSALESCOUNTRF - (CASE WHEN MTL_STOCK.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE MTL_STOCK.TOTALSALESCOUNTRF END)) AS OR_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESMONEYRF - (CASE WHEN MTL_STOCK.SALESMONEYRF IS NULL THEN 0 ELSE MTL_STOCK.SALESMONEYRF END)) AS OR_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESRETGOODSPRICERF - (CASE WHEN MTL_STOCK.SALESRETGOODSPRICERF IS NULL THEN 0 ELSE MTL_STOCK.SALESRETGOODSPRICERF END)) AS OR_SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.DISCOUNTPRICERF - (CASE WHEN MTL_STOCK.DISCOUNTPRICERF IS NULL THEN 0 ELSE MTL_STOCK.DISCOUNTPRICERF END)) AS OR_DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.GROSSPROFITRF - (CASE WHEN MTL_STOCK.GROSSPROFITRF IS NULL THEN 0 ELSE MTL_STOCK.GROSSPROFITRF END)) AS OR_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " (SELECT" + Environment.NewLine;
                selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += "  ,MAX(MTL1.CHGSRCGOODSNORF) AS CHGSRCGOODSNORF" + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  FROM  " + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1" + Environment.NewLine;
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                // 2011/08/01 <<<
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //品番集計区分が「合算」場合
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += " SELECT" + Environment.NewLine;
                    selectTxt += "   MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE1.CHGDESTGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE1.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE2.CHGSRCGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE2.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE1  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE1.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.CHGSRCGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE2  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE2.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.CHGDESTGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "  ) AS MTL1" + Environment.NewLine;
                }
                //品番集計区分は「別々」場合
                else
                {
                    selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                selectTxt += MakeWhereString(ref sqlCommand, _shipGdsPrimeListCndtnWork, logicalMode, "MTL1");
                
                selectTxt += "  GROUP BY" + Environment.NewLine;
                selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTL_TOTAL" + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += " (SELECT" + Environment.NewLine;
                selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  FROM " + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2" + Environment.NewLine;
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;// DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                // 2011/08/01 <<<
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 品番集計区分が「合算」場合
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += " SELECT" + Environment.NewLine;
                    selectTxt += "   MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE3.CHGDESTGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE3.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE4.CHGSRCGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE4.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE3  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE3.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.CHGSRCGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE4  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE4.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.CHGDESTGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "  ) AS MTL2" + Environment.NewLine;
                }
                //品番集計区分は「別々」場合
                else
                {
                    selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                selectTxt += MakeWhereString(ref sqlCommand, _shipGdsPrimeListCndtnWork, logicalMode, "MTL2");
                
                selectTxt += "  GROUP BY" + Environment.NewLine;
                selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTL_STOCK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	  MTL_STOCK.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.ADDUPSECCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.GOODSMAKERCDRF=MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.GOODSNORF=MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "ON" + Environment.NewLine;
                // DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //selectTxt += "      SEC.ENTERPRISECODERF=MTL_STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND SEC.SECTIONCODERF=MTL_STOCK.ADDUPSECCODERF" + Environment.NewLine;
                // DEL END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                selectTxt += "      SEC.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SEC.SECTIONCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                sqlCommand.CommandText = selectTxt;

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader); // DEL 2015/05/08 田建委 グローバル変数の削除
                    ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader, _shipGdsPrimeListCndtnWork.GoodsNoTtlDiv); // ADD 2015/05/08 田建委 グローバル変数の削除

                    al.Add(wkShipGdsPrimeListResultWork);
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="tblName">テーブル名</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, ConstantManagement.LogicalMode logicalMode, string tblName)
        {
            string retstring = string.Empty;

            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS" + Environment.NewLine;
            retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGDS.ENTERPRISECODERF=" + tblName + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGDS.BLGOODSCODERF=" + tblName + ".BLGOODSCODERF" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGROUPURF AS BLGRP" + Environment.NewLine;
            retstring += "LEFT JOIN BLGROUPURF AS BLGRP WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGRP.ENTERPRISECODERF=BLGDS.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGRP.BLGROUPCODERF=BLGDS.BLGROUPCODERF" + Environment.NewLine;

            #region WHERE文作成
            retstring += "WHERE" + Environment.NewLine;
            //企業コード
            retstring += tblName + ".ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            if (tblName == "MTL1")
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrimeListCndtnWork.EnterpriseCode);
            }

            if (tblName == "MTL1")
            {
                retstring += " AND MTL1.RSLTTTLDIVCDRF=0" + Environment.NewLine;
            }
            else
            if (tblName == "MTL2")
            {
                retstring += " AND MTL2.RSLTTTLDIVCDRF=1" + Environment.NewLine;
            }

            //計上拠点コード
            if (_shipGdsPrimeListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _shipGdsPrimeListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND " + tblName + ".ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }

            //年月度
            if (_shipGdsPrimeListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrimeListCndtnWork.St_AddUpYearMonth);
                }
            }
            if (_shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth);
                }
            }

            //開始メーカーコード
            if (_shipGdsPrimeListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsMakerCd);
                }
            }

            //終了メーカーコード
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {

                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd);
                }
            }

            //開始ＢＬコード
            if (_shipGdsPrimeListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND " + tblName + ".BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_BLGoodsCode);
                }
            }

            //終了ＢＬコード
            if (_shipGdsPrimeListCndtnWork.Ed_BLGoodsCode != 0)
            {
                retstring += " AND " + tblName + ".BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {

                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_BLGoodsCode);
                }
            }

            //開始大分類コード
            if (_shipGdsPrimeListCndtnWork.St_GoodsLGroup != 0)
            {
                retstring += " AND BLGRP.GOODSLGROUPRF>=@STGOODSLGROUP" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STGOODSLGROUP", SqlDbType.Int);
                    paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsLGroup);
                }
            }

            //終了大分類コード
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsLGroup != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_GoodsLGroup != 0)
                {
                    retstring += " AND BLGRP.GOODSLGROUPRF<=@EDGOODSLGROUP" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGRP.GOODSLGROUPRF<=@EDGOODSLGROUP OR BLGRP.GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                }
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdGoodsLGroup = sqlCommand.Parameters.Add("@EDGOODSLGROUP", SqlDbType.Int);
                    paraEdGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsLGroup);
                }
            }

            //開始中分類コード
            if (_shipGdsPrimeListCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND BLGRP.GOODSMGROUPRF>=@STGOODSMGROUP" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsMGroup);
                }
            }

            //終了中分類コード
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsMGroup != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_GoodsMGroup != 0)
                {
                    retstring += " AND BLGRP.GOODSMGROUPRF<=@EDGOODSMGROUP" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGRP.GOODSMGROUPRF<=@EDGOODSMGROUP OR BLGRP.GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                }
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                    paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsMGroup);
                }
            }

            //開始グループコード
            if (_shipGdsPrimeListCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND BLGDS.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_BLGroupCode);
                }
            }

            //終了グループコード
            if (_shipGdsPrimeListCndtnWork.Ed_BLGroupCode != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_BLGroupCode != 0)
                {
                    retstring += " AND BLGDS.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGDS.BLGROUPCODERF<=@EDBLGROUPCODE OR BLGDS.BLGROUPCODERF IS NULL)" + Environment.NewLine;
                }

                if (tblName == "MTL1")
                {
                    SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_BLGroupCode);
                }
            }

            #endregion
            return retstring;
        }
        #endregion


        #region 対応品番用
        /// <summary>
        /// 指定された企業コードの出荷商品優良対応表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">検索結果</param>
        /// <param name="shipGdsPrmListCndtnPartnerList">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの出荷商品優良対応表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        public int SearchPartner(out object shipGdsPrimeListResultList, object shipGdsPrmListCndtnPartnerList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            shipGdsPrimeListResultList = null;

            ArrayList _shipGdsPrimeListCndtnPartnerList = shipGdsPrmListCndtnPartnerList as ArrayList;

            try
            {
                status = SearchProcPartner(out shipGdsPrimeListResultList, _shipGdsPrimeListCndtnPartnerList, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.Search Exception=" + ex.Message);
                shipGdsPrimeListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの出荷商品優良対応表LISTを全て戻します
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">検索結果</param>
        /// <param name="_shipGdsPrimeListCndtnPartnerList">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの出荷商品優良対応表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProcPartner(out object shipGdsPrimeListResultList, ArrayList _shipGdsPrimeListCndtnPartnerList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            shipGdsPrimeListResultList = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProcPartner(ref al, ref sqlConnection, _shipGdsPrimeListCndtnPartnerList, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.SearchProcPartner Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            shipGdsPrimeListResultList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_shipGdsPrimeListCndtnPartnerList">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// <br>UpdateNote : 2015/05/08 田建委</br>
        /// <br>管理番号  : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更 グローバル変数の削除</br>
        private int SearchProcPartner(ref ArrayList al, ref SqlConnection sqlConnection, ArrayList _shipGdsPrimeListCndtnPartnerList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                foreach (ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork in _shipGdsPrimeListCndtnPartnerList)
                {
                    //------ DEL 2015/05/08 田建委 グローバル変数の削除 ---------------->>>>>
                    #region DEL
                    ////------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    ////合算の場合
                    //if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1) 
                    //{
                    //    goodsNoSum = true;
                    //}
                    ////別々の場合、既存の処理と同じ
                    //else
                    //{
                    //    goodsNoSum = false;
                    //}
                    ////------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    #endregion
                    //------ DEL 2015/05/08 田建委 グローバル変数の削除 ----------------<<<<<
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    //SELECT文作成
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "   MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "  ,MTL_TOTAL.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "	,MTL_TOTAL.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESTIMESRF AS ST_SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.TOTALSALESCOUNTRF AS ST_TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESMONEYRF AS ST_SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESRETGOODSPRICERF AS ST_SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.DISCOUNTPRICERF AS ST_DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.GROSSPROFITRF AS ST_GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESTIMESRF - (CASE WHEN MTL_STOCK.SALESTIMESRF IS NULL THEN 0 ELSE MTL_STOCK.SALESTIMESRF END)) AS OR_SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.TOTALSALESCOUNTRF - (CASE WHEN MTL_STOCK.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE MTL_STOCK.TOTALSALESCOUNTRF END)) AS OR_TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESMONEYRF - (CASE WHEN MTL_STOCK.SALESMONEYRF IS NULL THEN 0 ELSE MTL_STOCK.SALESMONEYRF END)) AS OR_SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESRETGOODSPRICERF - (CASE WHEN MTL_STOCK.SALESRETGOODSPRICERF IS NULL THEN 0 ELSE MTL_STOCK.SALESRETGOODSPRICERF END)) AS OR_SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.DISCOUNTPRICERF - (CASE WHEN MTL_STOCK.DISCOUNTPRICERF IS NULL THEN 0 ELSE MTL_STOCK.DISCOUNTPRICERF END)) AS OR_DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.GROSSPROFITRF - (CASE WHEN MTL_STOCK.GROSSPROFITRF IS NULL THEN 0 ELSE MTL_STOCK.GROSSPROFITRF END)) AS OR_GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "FROM" + Environment.NewLine;
                    selectTxt += " (SELECT" + Environment.NewLine;
                    selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "  ,MAX(MTL1.CHGSRCGOODSNORF) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM  " + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1" + Environment.NewLine;
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                    // 2011/08/01 <<<
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    //品番集計区分が「合算」場合
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += " ( " + Environment.NewLine;
                        selectTxt += " SELECT" + Environment.NewLine;
                        selectTxt += "   MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE1.CHGDESTGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE1.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE2.CHGSRCGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE2.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.RSLTTTLDIVCDRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.BLGOODSCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESTIMESRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.TOTALSALESCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESMONEYRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESRETGOODSPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.DISCOUNTPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.GROSSPROFITRF" + Environment.NewLine;
                        selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE1  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE1.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.CHGSRCGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE2  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE2.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.CHGDESTGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "  ) AS MTL1" + Environment.NewLine;
                    }
                    //品番集計区分は「別々」場合
                    else
                    {
                        selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += MakeWhereStringPartner(ref sqlCommand, shipGdsPrmListCndtnPartnerWork, logicalMode, "MTL1");

                    selectTxt += "  GROUP BY" + Environment.NewLine;
                    selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ) AS MTL_TOTAL" + Environment.NewLine;
                    selectTxt += "LEFT JOIN" + Environment.NewLine;
                    selectTxt += " (SELECT" + Environment.NewLine;
                    selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM  " + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2" + Environment.NewLine;
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                    // 2011/08/01 <<<
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分が「合算」場合
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += " ( " + Environment.NewLine;
                        selectTxt += " SELECT" + Environment.NewLine;
                        selectTxt += "   MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE3.CHGDESTGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE3.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE4.CHGSRCGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE4.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.RSLTTTLDIVCDRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.BLGOODSCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESTIMESRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.TOTALSALESCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESMONEYRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESRETGOODSPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.DISCOUNTPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.GROSSPROFITRF" + Environment.NewLine;
                        selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE3  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE3.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.CHGSRCGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE4  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE4.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.CHGDESTGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "  ) AS MTL2" + Environment.NewLine;
                    }
                    //品番集計区分は「別々」場合
                    else
                    {
                        selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    selectTxt += MakeWhereStringPartner(ref sqlCommand, shipGdsPrmListCndtnPartnerWork, logicalMode, "MTL2");

                    selectTxt += "  GROUP BY" + Environment.NewLine;
                    selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ) AS MTL_STOCK" + Environment.NewLine;
                    selectTxt += "ON" + Environment.NewLine;
                    selectTxt += "	  MTL_STOCK.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.ADDUPSECCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.GOODSMAKERCDRF=MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.GOODSNORF=MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                    selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/08/01 <<<
                    selectTxt += "ON" + Environment.NewLine;
                    //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    //selectTxt += "      SEC.ENTERPRISECODERF=MTL_STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += "  AND SEC.SECTIONCODERF=MTL_STOCK.ADDUPSECCODERF" + Environment.NewLine;
                    //------ DEL END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    selectTxt += "      SEC.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND SEC.SECTIONCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                    sqlCommand.CommandText = selectTxt;

                    //タイムアウト時間の設定（秒）
                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader); // DEL 2015/05/08 田建委 グローバル変数の削除
                        ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader, shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv); // ADD 2015/05/08 田建委 グローバル変数の削除

                        al.Add(wkShipGdsPrimeListResultWork);
                    }

                    if (!myReader.IsClosed) myReader.Close();
                }

                if (al.Count > 0)
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
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="tblName">テーブル名</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        private string MakeWhereStringPartner(ref SqlCommand sqlCommand, ShipGdsPrmListCndtnPartnerWork _shipGdsPrmListCndtnPartnerWork, ConstantManagement.LogicalMode logicalMode, string tblName)
        {
            string retstring = string.Empty;

            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS" + Environment.NewLine;
            retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGDS.ENTERPRISECODERF=" + tblName + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGDS.BLGOODSCODERF=" + tblName + ".BLGOODSCODERF" + Environment.NewLine;

            #region WHERE文作成
            retstring += "WHERE" + Environment.NewLine;

            //企業コード
            retstring += tblName + " .ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            if (tblName == "MTL1")
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.EnterpriseCode);
            }
            
            if (tblName == "MTL1")
            {
                retstring += " AND MTL1.RSLTTTLDIVCDRF=0" + Environment.NewLine;
            }
            else
            if (tblName == "MTL2")
            {
                retstring += " AND MTL2.RSLTTTLDIVCDRF=1" + Environment.NewLine;
            }

            //計上拠点コード
            if (string.IsNullOrEmpty(_shipGdsPrmListCndtnPartnerWork.SectionCode) == false)
            {
                retstring += " AND " + tblName + ".ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.SectionCode);
                }
            }

            //開始年月度
            if (_shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth);
                }
            }

            //終了年月度
            if (_shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth);
                }
            }

            //メーカーコード
            if (_shipGdsPrmListCndtnPartnerWork.GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF=@STGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrmListCndtnPartnerWork.GoodsMakerCd);
                }
            }

            //品番
            if (string.IsNullOrEmpty(_shipGdsPrmListCndtnPartnerWork.GoodsNo) == false)
            {
                //retstring += " AND " + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;// DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                if (_shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    retstring += " AND (" + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;
                    retstring += " OR " + tblName + ".CHGSRCGOODSNORF=@GOODSNO)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND " + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                if (tblName == "MTL1")
                {
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.GoodsNo);
                }
            }

            #endregion
            return retstring;
        }
        #endregion

        /// <summary>
        /// クラス格納処理 Reader → SumCustStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsNoTtlDiv">品番集計区分</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        /// <br>UpdateNote : 2015/05/08 田建委</br>
        /// <br>管理番号  : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更 グローバル変数の削除</br>
        /// </remarks>
        //private ShipGdsPrimeListResultWork CopyToShipGdsPrimeListResultWorkFromReader(ref SqlDataReader myReader) // DEL 2015/05/08 田建委 グローバル変数の削除
        private ShipGdsPrimeListResultWork CopyToShipGdsPrimeListResultWorkFromReader(ref SqlDataReader myReader, int goodsNoTtlDiv)// ADD 2015/05/08 田建委 グローバル変数の削除
        {
            ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();

            if (myReader != null)
            {
                # region クラスへ格納
                wkShipGdsPrimeListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkShipGdsPrimeListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                wkShipGdsPrimeListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                wkShipGdsPrimeListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkShipGdsPrimeListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                //if (goodsNoSum) // DEL 2015/05/08 田建委 グローバル変数の削除
                if (goodsNoTtlDiv == 1) // ADD 2015/05/08 田建委 グローバル変数の削除
                {
                    wkShipGdsPrimeListResultWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                wkShipGdsPrimeListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkShipGdsPrimeListResultWork.St_SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ST_SALESTIMESRF"));
                wkShipGdsPrimeListResultWork.St_TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ST_TOTALSALESCOUNTRF"));
                wkShipGdsPrimeListResultWork.St_SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_SALESMONEYRF"));
                wkShipGdsPrimeListResultWork.St_SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_SALESRETGOODSPRICERF"));
                wkShipGdsPrimeListResultWork.St_DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_DISCOUNTPRICERF"));
                wkShipGdsPrimeListResultWork.St_GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_GROSSPROFITRF"));
                wkShipGdsPrimeListResultWork.Or_SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OR_SALESTIMESRF"));
                wkShipGdsPrimeListResultWork.Or_TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OR_TOTALSALESCOUNTRF"));
                wkShipGdsPrimeListResultWork.Or_SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_SALESMONEYRF"));
                wkShipGdsPrimeListResultWork.Or_SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_SALESRETGOODSPRICERF"));
                wkShipGdsPrimeListResultWork.Or_DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_DISCOUNTPRICERF"));
                wkShipGdsPrimeListResultWork.Or_GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_GROSSPROFITRF"));
                # endregion
            }

            return wkShipGdsPrimeListResultWork;
        }
    }
}


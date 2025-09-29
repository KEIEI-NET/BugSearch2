//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品価格マスタ展開DBリモートオブジェクト
// プログラム概要   : 部品価格マスタ展開DBリモートオブジェクトを管理する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 作 成 日  K2011/07/14 作成内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 修 正 日  K2011/08/20 修正内容 : イスコ個別対応
//                       Redmine23619対応
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 修 正 日  K2011/08/25 修正内容 : イスコ個別対応
//                       Redmine23619対応
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 修 正 日  K2011/08/29 修正内容 : イスコ個別対応
//                       Redmine23619対応
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : 脇田 靖之
// 修 正 日  K2013/04/05 修正内容 : イスコ個別対応
//                       「Sytem.OutOfMemoryException」障害対応
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 呉元嘯
// 修 正 日  2020/08/20  修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;  // ADD K2013/04/05 Y.Wakita
using Broadleaf.Application.Common;  // ADD 2020/08/20 呉元嘯 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部品価格マスタ展開DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品価格マスタ展開を行うクラスです。</br>
    /// <br>Programmer : huangqb</br>
    /// <br>Date       : K2011/07/14</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br>Update Note: K2011/08/25 yangyi</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br>             Redmine23619対応</br>
    /// <br>Update Note: K2011/08/29 yangyi</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br>             Redmine23619対応</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2020/08/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CostExpandDB : RemoteDB, ICostExpandDB
    {
        #region 定数
        /// <summary>メーカー</summary>
        private enum ct_GoodsMaker
        {
            Toyota = 1,       //トヨタ
            Nissan = 2,       //日産
            Takuthi = 1396,   //タクティ
            Bittowaaku = 1522 //ピットワーク
        }

        /// <summary>処理対象マスタ</summary>
        private enum ct_TargetMaster
        {
            Rate = 1,         //掛率マスタ
            GoodsAndPrice = 2 //商品マスタ・価格マスタ
        }
        #endregion

        #region プライベート変数
        // ----- ADD K2011/08/25 --------------------------->>>>>
        private GoodsUnitDataWork _wkGoodsUnitDataWork = new GoodsUnitDataWork();
        private ArrayList _priceList = new ArrayList();
        private string _enterpriseCode = string.Empty;
        private string _goodsNo = string.Empty;
        private int _goodsMakerCd = 0;
        private int _cnt = 0;
        // ----- ADD K2011/08/25 ---------------------------<<<<<
        #endregion

        #region [ユーザー商品マスタと価格マスタのみ取得処理]
        // ----- ADD K2011/08/20 --------------------------->>>>>
        /// <summary>
        /// ユーザー商品マスタと価格マスタのみ取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザー商品マスタと価格マスタのみを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        public int UsrGoodsOnlySearch(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            SqlConnection sqlConnection = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList paraList = paraObj as ArrayList;
                if (paraList == null || paraList.Count == 0) 
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                ArrayList retList = null;
                status = UsrGoodsOnlySearchProc(out retList, paraList, readMode, logicalMode, ref sqlConnection);
                retCSAList.Add(retList);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CostExpandDB.UsrGoodsOnlySearch");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            retObj = retCSAList;

            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

        }

        /// <summary>
        /// ユーザー商品マスタと価格マスタのみ取得処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paralist">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザー商品マスタと価格マスタのみを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>Update Note: K2011/08/25 yangyi</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>             Redmine23619対応</br>
        /// <br>Update Note: K2011/08/29 yangyi</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>             Redmine23619対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// <br></br>
        /// </remarks>
        private int UsrGoodsOnlySearchProc(out ArrayList retList, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectstring = "";

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                // ----- DEL K2011/08/25 --------------------------->>>>>
                //selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                //selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                //selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                //selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                //selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                //selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                //selectstring += "    ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                //selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                // ----- DEL K2011/08/25 ---------------------------<<<<<
                // ----- ADD K2011/08/25 --------------------------->>>>>
                selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATADIVRF" + Environment.NewLine;

                selectstring += "    ,GOODSPRICEURF.CREATEDATETIMERF AS PRICECREATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.UPDATEDATETIMERF AS PRICEUPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.ENTERPRISECODERF AS PRICEENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.FILEHEADERGUIDRF AS PRICEFILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.UPDEMPLOYEECODERF AS PRICEUPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.UPDASSEMBLYID1RF AS PRICEUPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.UPDASSEMBLYID2RF AS PRICEUPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.LOGICALDELETECODERF AS PRICELOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.GOODSMAKERCDRF AS PRICEGOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.GOODSNORF AS PRICEGOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.PRICESTARTDATERF AS PRICEPRICESTARTDATERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.LISTPRICERF AS PRICELISTPRICERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.SALESUNITCOSTRF AS PRICESALESUNITCOSTRF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.STOCKRATERF AS PRICESTOCKRATERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.OPENPRICEDIVRF AS PRICEOPENPRICEDIVRF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.OFFERDATERF AS PRICEOFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICEURF.UPDATEDATERF AS PRICEUPDATEDATERF" + Environment.NewLine;

                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSPRICEURF " + Environment.NewLine;
                selectstring += "    ON  GOODSPRICEURF.ENTERPRISECODERF = GOODS.ENTERPRISECODERF " + Environment.NewLine;
                selectstring += "    AND GOODSPRICEURF.GOODSNORF = GOODS.GOODSNORF " + Environment.NewLine;
                selectstring += "    AND GOODSPRICEURF.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF " + Environment.NewLine;
                selectstring += "    AND GOODSPRICEURF.LOGICALDELETECODERF = GOODS.LOGICALDELETECODERF " + Environment.NewLine;
                // ----- ADD K2011/08/25 ---------------------------<<<<<
                
                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, paralist, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                // ----- ADD K2011/08/29 --------------------------->>>>>
                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 600;
                // ----- ADD K2011/08/29 ---------------------------<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    this._cnt++;
                    //al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader)); // DEL K2011/08/25
                    // ----- ADD K2011/08/25 --------------------------->>>>>
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    //CopyToGoodsUnitDataWorkFromReader(ref myReader, al);
                    CopyToGoodsUnitDataWorkFromReader(ref myReader, al, convertDoubleRelease);
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                    // ----- ADD K2011/08/25 ---------------------------<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ----- ADD K2011/08/25 --------------------------->>>>>
                if (myReader.HasRows)
                {
                    al.Add(_wkGoodsUnitDataWork);
                }
                // ----- ADD K2011/08/25 ---------------------------<<<<<
                // ----- DEL K2011/08/25 --------------------------->>>>>
                //ArrayList priceList = new ArrayList();
                //ArrayList usrGoodsPrice;
                //foreach (GoodsUnitDataWork usrGoodsWork in al)
                //{
                //    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                //    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                //    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                //    wk.PrtsNo = usrGoodsWork.GoodsNo;
                //    priceList.Add(wk);
                //}
                //myReader.Close();
                //status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, logicalMode, sqlConnection);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    foreach (GoodsUnitDataWork usrGoodsWork in al)
                //    {
                //        usrGoodsWork.PriceList = new ArrayList();
                //        foreach (GoodsPriceUWork prc in usrGoodsPrice)
                //        {
                //            if (usrGoodsWork.GoodsMakerCd == prc.GoodsMakerCd &&
                //                usrGoodsWork.GoodsNo == prc.GoodsNo)
                //            {
                //                usrGoodsWork.PriceList.Add(prc);
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (GoodsUnitDataWork usrGoodsWork in al)
                //    {
                //        usrGoodsWork.PriceList = new ArrayList();
                //    }
                //}
                // ----- DEL K2011/08/25 ---------------------------<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }

            retList = al;

            return status;
        }

        /// <summary>
        /// ユーザー価格マスタ取得処理
        /// </summary>
        /// <param name="inSetParts">検索パラメータ</param>
        /// <param name="usrGoodsPrice">検索結果</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザー商品マスタと価格マスタのみを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int SearchUsrGoodsPriceProc(ArrayList inSetParts, out ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int whereCnt = 0;
            string wherestr = string.Empty;

            usrGoodsPrice = new ArrayList();
            if (inSetParts == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            try
            {
                string enterpriseCode = ((UsrPartsNoSearchCondWork)inSetParts[0]).EnterpriseCode;
                //メーカーコード・品番 
                foreach (UsrPartsNoSearchCondWork wk in inSetParts)
                {
                    if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                    {
                        continue;
                    }

                    wherestr += "OR ( GOODSPRICEURF.GOODSMAKERCDRF = " + wk.MakerCode + " AND ";
                    wherestr += "GOODSPRICEURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    whereCnt++;

                    if (whereCnt == 30)
                    {
                        status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            return status;
                        whereCnt = 0;
                        wherestr = string.Empty;
                    }
                }
                if (whereCnt > 0)
                {
                    status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CostExpandDB.SearchUsrGoodsPriceProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ユーザー価格マスタ取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="wherestr">検索パラメータ</param>
        /// <param name="usrGoodsPrice">検索結果</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザー商品マスタと価格マスタのみを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// <br></br>
        /// </remarks>
        private int ExecutePriceQuery(string enterpriseCode, string wherestr, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            //取得マスタ項目
            string selectstr = "SELECT "
                        + "GOODSPRICEURF.CREATEDATETIMERF, "
                        + "GOODSPRICEURF.UPDATEDATETIMERF, "
                        + "GOODSPRICEURF.ENTERPRISECODERF, "
                        + "GOODSPRICEURF.FILEHEADERGUIDRF, "
                        + "GOODSPRICEURF.UPDEMPLOYEECODERF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID1RF, "
                        + "GOODSPRICEURF.UPDASSEMBLYID2RF, "
                        + "GOODSPRICEURF.LOGICALDELETECODERF, "

                        + "GOODSPRICEURF.GOODSMAKERCDRF, "
                        + "GOODSPRICEURF.GOODSNORF, "
                        + "GOODSPRICEURF.PRICESTARTDATERF, "
                        + "GOODSPRICEURF.LISTPRICERF, "
                        + "GOODSPRICEURF.SALESUNITCOSTRF, "
                        + "GOODSPRICEURF.STOCKRATERF, "
                        + "GOODSPRICEURF.OPENPRICEDIVRF, "
                        + "GOODSPRICEURF.OFFERDATERF, "
                        + "GOODSPRICEURF.UPDATEDATERF "
                        + "FROM GOODSPRICEURF "
                        + "WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ";

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND ( ";
                }
                else
                {
                    selectstr = selectstr + "( ";
                }

                // 先頭のOR除去
                wherestr = wherestr.Substring(2) + " ) ";
                string orderStr = " ORDER BY PRICESTARTDATERF DESC, GOODSNORF";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr + orderStr, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(enterpriseCode);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value
                                    = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    GoodsPriceUWork mf = new GoodsPriceUWork();

                    mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    mf.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    mf.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = enterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                    mf.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    mf.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    usrGoodsPrice.Add(mf);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>Update Note: K2011/08/29 yangyi</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>             Redmine23619対応</br>
        /// <br></br>
        /// </remarks>
        private string MakeWhereStringMultiCondition(ref SqlCommand sqlCommand, ArrayList paraList, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = string.Empty;
            string countstr = string.Empty;
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");
            GoodsUCndtnWork wkcond = null;

            if (paraList == null || paraList.Count < 1)
                return string.Empty;

            wkcond = paraList[0] as GoodsUCndtnWork;

            //企業コード
            retstring.Append("GOODS.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkcond.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            wkstring = "";
            for (int i = 0; i < paraList.Count; i++)
            {
                wkcond = paraList[i] as GoodsUCndtnWork;
                countstr = i.ToString();
                if (wkstring != "") wkstring += "OR ";
                // ----- DEL K2011/08/29 --------------------------->>>>>
                //wkstring += "( GOODS.GOODSMAKERCDRF=@GOODSMAKERCD" + countstr + " AND GOODS.GOODSNORF=@GOODSNO" + countstr + " ) ";

                ////メーカーコード
                //SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + countstr, SqlDbType.Int);
                //paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(wkcond.GoodsMakerCd);

                ////商品番号
                //SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + countstr, SqlDbType.NChar);

                //if (SqlDataMediator.SqlSetString(wkcond.GoodsNo) != DBNull.Value)
                //{
                //    paraGoodsNo.Value = SqlDataMediator.SqlSetString(wkcond.GoodsNo);
                //}
                //else
                //{
                //    paraGoodsNo.Value = "";
                //}
                // ----- DEL K2011/08/29 ---------------------------<<<<<
                // ----- ADD K2011/08/29 --------------------------->>>>>
                //商品番号
                string goodsNo = string.Empty;
                if (SqlDataMediator.SqlSetString(wkcond.GoodsNo) != DBNull.Value)
                {
                    goodsNo = wkcond.GoodsNo;
                }
                else
                {
                    goodsNo = "";
                }

                wkstring += "( GOODS.GOODSMAKERCDRF=" + wkcond.GoodsMakerCd.ToString() + " AND GOODS.GOODSNORF= '" + goodsNo.Trim() + "' ) ";
                // ----- ADD K2011/08/29 ---------------------------<<<<<

            }
            if (wkstring != "")
            {
                retstring.Append("AND ( ");
                retstring.Append(wkstring);
                retstring.Append(" ) ");
            }

            return retstring.ToString();
        }


        /// <summary>
        /// 商品連結データクラス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="al">検索結果リスト</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>GoodsUnitDataWork</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データクラス格納処理を行います。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>Update Note: K2011/08/25 yangyi</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>             Redmine23619対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// <br></br>
        /// </remarks>
        //private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader) // DEL K2011/08/25
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private void CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader, ArrayList al) // ADD K2011/08/25
        private void CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader, ArrayList al, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {
            //GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork(); // DEL K2011/08/25

            #region クラスへ格納
            // ----- DEL K2011/08/25 --------------------------->>>>>
            //wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            //wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            //wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            //wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            //wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            //wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            //wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            //wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            //wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            //wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            //wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            //wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            //wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            //wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            // ----- DEL K2011/08/25 ---------------------------<<<<<
            // ----- ADD K2011/08/25 --------------------------->>>>>
            string currentEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            int currentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            string currentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            if (this._cnt == 1)
            {
                this._enterpriseCode = currentEnterpriseCode;
                this._goodsMakerCd = currentGoodsMakerCd;
                this._goodsNo = currentGoodsNo;
            }

            if (currentEnterpriseCode == this._enterpriseCode && currentGoodsMakerCd == this._goodsMakerCd && currentGoodsNo == this._goodsNo)
            {
                GoodsPriceUWork mf = new GoodsPriceUWork();

                mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICECREATEDATETIMERF"));
                mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICEUPDATEDATETIMERF"));
                mf.EnterpriseCode = currentEnterpriseCode;
                mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("PRICEFILEHEADERGUIDRF"));
                mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDEMPLOYEECODERF"));
                mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID1RF"));
                mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID2RF"));
                mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICELOGICALDELETECODERF"));

                mf.GoodsMakerCd = currentGoodsMakerCd;
                mf.GoodsNo = currentGoodsNo;
                mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEPRICESTARTDATERF"));
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));
                convertDoubleRelease.EnterpriseCode = currentEnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = mf.GoodsNo;
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                mf.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESALESUNITCOSTRF"));
                mf.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESTOCKRATERF"));
                mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEOPENPRICEDIVRF"));
                mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEUPDATEDATERF"));
                if (mf.PriceStartDate != DateTime.MinValue)
                {
                    this._priceList.Add(mf);
                }

                if (this._cnt == 1)
                {
                    _wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    _wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    _wkGoodsUnitDataWork.EnterpriseCode = currentEnterpriseCode;
                    _wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    _wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    _wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    _wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    _wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    _wkGoodsUnitDataWork.GoodsMakerCd = currentGoodsMakerCd;
                    _wkGoodsUnitDataWork.GoodsNo = currentGoodsNo;
                    _wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    _wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    _wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                    _wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    _wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    _wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    _wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    _wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    _wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    _wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    _wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                    _wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                    _wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                    _wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    _wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    _wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                    _wkGoodsUnitDataWork.PriceList = this._priceList;
                }
            }
            else
            {
                al.Add(_wkGoodsUnitDataWork);
                _wkGoodsUnitDataWork = new GoodsUnitDataWork();
                _priceList = new ArrayList();
                this._cnt = 1;
                this._enterpriseCode = currentEnterpriseCode;
                this._goodsMakerCd = currentGoodsMakerCd;
                this._goodsNo = currentGoodsNo;

                GoodsPriceUWork mf = new GoodsPriceUWork();

                mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICECREATEDATETIMERF"));
                mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICEUPDATEDATETIMERF"));
                mf.EnterpriseCode = currentEnterpriseCode;
                mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("PRICEFILEHEADERGUIDRF"));
                mf.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDEMPLOYEECODERF"));
                mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID1RF"));
                mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID2RF"));
                mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICELOGICALDELETECODERF"));

                mf.GoodsMakerCd = currentGoodsMakerCd;
                mf.GoodsNo = currentGoodsNo;
                mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEPRICESTARTDATERF"));
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));
                convertDoubleRelease.EnterpriseCode = currentEnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = mf.GoodsNo;
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                mf.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESALESUNITCOSTRF"));
                mf.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESTOCKRATERF"));
                mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEOPENPRICEDIVRF"));
                mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEUPDATEDATERF"));
                if (mf.PriceStartDate != DateTime.MinValue)
                {
                    this._priceList.Add(mf);
                }

                _wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                _wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                _wkGoodsUnitDataWork.EnterpriseCode = currentEnterpriseCode;
                _wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                _wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                _wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                _wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                _wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                _wkGoodsUnitDataWork.GoodsMakerCd = currentGoodsMakerCd;
                _wkGoodsUnitDataWork.GoodsNo = currentGoodsNo;
                _wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                _wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                _wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                _wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                _wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                _wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                _wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                _wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                _wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                _wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                _wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                _wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                _wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                _wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                _wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                _wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                _wkGoodsUnitDataWork.PriceList = this._priceList;
            }
            // ----- ADD K2011/08/25 ---------------------------<<<<<
            #endregion

            //return wkGoodsUnitDataWork; // DEL K2011/08/25
        }
        // ----- ADD K2011/08/20 ---------------------------<<<<<
        #endregion

        #region [部品価格マスタ展開処理]
        /// <summary>
        /// 部品価格マスタ展開処理
        /// </summary>
        /// <param name="paraObj">部品価格マスタ展開パラメータ</param>
        /// <param name="retObj">部品価格マスタ展開結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部品価格マスタ展開を行います。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        public int CostExpand(object paraObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retObj = null;
            ArrayList errorList = new ArrayList();
            CostExpandProcessNumWork costExpandProcessNumWork = new CostExpandProcessNumWork();
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //●パラメータチェック
                CustomSerializeArrayList paramArray = paraObj as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //パラメータを分解
                ArrayList rateWorkList = MakeParameter(paramArray, typeof(RateWork), 1) as ArrayList;
                ArrayList goodsUnitDataWorkList = MakeParameter(paramArray, typeof(GoodsUnitDataWork), 1) as ArrayList;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (rateWorkList != null && rateWorkList.Count > 0)
                {
                    //掛率マスタ更新
                    status = WriteRateProc(rateWorkList, ref errorList, ref costExpandProcessNumWork, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && errorList.Count <= 0)
                {
                    if (goodsUnitDataWorkList != null && goodsUnitDataWorkList.Count > 0)
                    {
                        //商品連結データ更新
                        status = WriteGoodsUnitDataProc(goodsUnitDataWorkList, ref errorList, ref costExpandProcessNumWork, ref sqlConnection, ref sqlTransaction);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && errorList.Count <= 0)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                    // エラーが発生した場合は、処理件数は0を表示する
                    costExpandProcessNumWork = new CostExpandProcessNumWork();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CostExpandDB.CostExpand(object paraObj, out object retObj)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                // エラーが発生した場合は、処理件数は0を表示する
                costExpandProcessNumWork = new CostExpandProcessNumWork();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                //上記で作成したエラーリストと更新件数を返す
                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                retList.Add(errorList);
                retList.Add(costExpandProcessNumWork);
                retObj = (object)retList;
            }

            return status;
        }
        #endregion

        # region [掛率設定マスタ情報の登録、更新処理]
        /// <summary>
        /// 商品価格マスタ情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="errorList">エラーリスト</param>
        /// <param name="costExpandProcessNumWork">処理件数</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteRateProc(ArrayList rateWorkList, ref ArrayList errorList, ref CostExpandProcessNumWork costExpandProcessNumWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (rateWorkList == null || rateWorkList.Count == 0)
                return status;

            for (int i = 0; i < rateWorkList.Count; i++)
            {
                RateWork rateWork = rateWorkList[i] as RateWork;
                int writeStatus;
                string errorMessage;
                writeStatus = WriteRateProcProc(rateWork, out errorMessage, ref sqlConnection, ref sqlTransaction);

                if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //メーカー毎に処理した件数をカウントする
                    CountProcessNum((int)ct_TargetMaster.Rate, rateWork.GoodsMakerCd, ref costExpandProcessNumWork);

                    //WARNING,ERRORじゃなかったらNORMAL
                    if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                        status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //WARNING,ERRORじゃなかったらNORMAL
                    if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                        status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    errorList.Add(SetError(rateWork.GoodsNo, rateWork.GoodsMakerCd, errorMessage));
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定マスタ情報の登録、更新処理(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWork">掛率設定マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します。(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteRateProcProc(RateWork rateWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;

            try
            {
                //Selectコマンドの生成
                command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM RATERF" + Environment.NewLine;
                command += "WHERE" + Environment.NewLine;
                command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

                sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                findParaGoodsNo.Value = rateWork.GoodsNo;
                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != rateWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (rateWork.UpdateDateTime == DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            errorMessage = "重複するデータがあるため更新できません。";
                        }
                        //既存データで更新日時違いの場合には排他
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            errorMessage = "このデータは既に更新されています。";
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //価格（浮動）、掛率、UP率、粗利確保率全て0のレコードは物理削除する
                    if (rateWork.PriceFl == 0.0 && rateWork.RateVal == 0.0 &&
                        rateWork.UpRate == 0.0 && rateWork.GrsProfitSecureRate == 0.0)
                    {
                        sqlCommand.CommandText = "DELETE FROM RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                    }
                    else
                    {
                        sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                        sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                        sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                        sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                        sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                        sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                        sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                        sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rateWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (rateWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        errorMessage = "このデータは既に削除されています。";
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    if (rateWork.PriceFl == 0.0 && rateWork.RateVal == 0.0 &&
                        rateWork.UpRate == 0.0 && rateWork.GrsProfitSecureRate == 0.0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                    sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                    sqlCommand.CommandText += " )" + Environment.NewLine;
                    sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                    sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                    sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                    sqlCommand.CommandText += " )" + Environment.NewLine;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)rateWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                paraGoodsNo.Value = rateWork.GoodsNo;
                paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
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

        # region [商品連結データの登録、更新処理]
        /// <summary>
        /// 商品連結データの登録、更新処理(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsUnitDataWorkList">商品連結データ</param>
        /// <param name="errorList">エラーリスト</param>
        /// <param name="costExpandProcessNumWork">処理件数</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データを登録、更新します。(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsUnitDataProc(ArrayList goodsUnitDataWorkList, ref ArrayList errorList, ref CostExpandProcessNumWork costExpandProcessNumWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (goodsUnitDataWorkList != null && goodsUnitDataWorkList.Count > 0)
                {
                    //商品連結データ更新リストを商品マスタ更新リストと価格マスタ更新リストに分割する
                    ArrayList goodsUWorkList = new ArrayList();
                    ArrayList goodsPriceUWorkList = new ArrayList();
                    CopyToGoodsAndPriceWork(goodsUnitDataWorkList, ref goodsUWorkList, ref goodsPriceUWorkList);

                    if (goodsUWorkList != null && goodsUWorkList.Count > 0)
                    {
                        //商品マスタを更新する
                        status = WriteGoodsUProc(goodsUWorkList, ref errorList, ref sqlConnection, ref sqlTransaction);
                    }

                    if (goodsPriceUWorkList != null && goodsPriceUWorkList.Count > 0 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //古い価格マスタを削除する
                        status = DeleteOldPriceProc(goodsPriceUWorkList, ref errorList, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //価格マスタを更新する
                            status = WriteGoodsPriceProc(goodsPriceUWorkList, ref errorList, ref costExpandProcessNumWork, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
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

        # region [連結クラス分割処理]
        /// <summary>
        /// 連結クラス分割処理
        /// </summary>
        /// <param name="goodsUnitDataList">連結リスト</param>
        /// <param name="goodsList">商品リスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 商品連結データ更新リストを商品マスタ更新リストと価格マスタ更新リストに分割します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private void CopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList)
        {
            string goodsNo = "";
            Int32 goodsMakerCd = 0;

            foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
            {
                GoodsUWork goodsUWork = new GoodsUWork();

                //商品マスタ更新項目セット
                goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
                goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
                goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
                goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
                goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
                goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
                goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
                goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                goodsUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
                goodsUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
                goodsUWork.GoodsName = goodsUnitDataWork.GoodsName;
                goodsUWork.GoodsNameKana = goodsUnitDataWork.GoodsNameKana;
                goodsUWork.Jan = goodsUnitDataWork.Jan;
                goodsUWork.BLGoodsCode = goodsUnitDataWork.BLGoodsCode;
                goodsUWork.DisplayOrder = goodsUnitDataWork.DisplayOrder;
                goodsUWork.GoodsRateRank = goodsUnitDataWork.GoodsRateRank;
                goodsUWork.TaxationDivCd = goodsUnitDataWork.TaxationDivCd;
                goodsUWork.GoodsNoNoneHyphen = goodsUnitDataWork.GoodsNoNoneHyphen;
                goodsUWork.OfferDate = goodsUnitDataWork.OfferDate;
                goodsUWork.GoodsKindCode = goodsUnitDataWork.GoodsKindCode;
                goodsUWork.GoodsNote1 = goodsUnitDataWork.GoodsNote1;
                goodsUWork.GoodsNote2 = goodsUnitDataWork.GoodsNote2;
                goodsUWork.GoodsSpecialNote = goodsUnitDataWork.GoodsSpecialNote;
                goodsUWork.EnterpriseGanreCode = goodsUnitDataWork.EnterpriseGanreCode;
                goodsUWork.UpdateDate = goodsUnitDataWork.UpdateDate;
                goodsUWork.OfferDataDiv = goodsUnitDataWork.OfferDataDiv;

                if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd))
                    goodsList.Add(goodsUWork);
                goodsNo = goodsUWork.GoodsNo;
                goodsMakerCd = goodsUWork.GoodsMakerCd;

                //価格マスタ更新項目セット
                foreach (GoodsPriceUWork goodsPrice in goodsUnitDataWork.PriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    {
                        GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                        goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                        goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
                        goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
                        goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
                        goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
                        goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
                        goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
                        goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
                        goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                        goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
                        goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
                        goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
                        goodsPriceUWork.StockRate = goodsPrice.StockRate;
                        goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
                        goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

                        goodsPriceList.Add(goodsPriceUWork);
                    }
                }
            }
        }
        #endregion

        # region [商品マスタ（ユーザー登録分）情報の登録、更新処理]
        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWorkオブジェクト</param>
        /// <param name="errorList">エラーリスト</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsUProc(ArrayList goodsUWorkList, ref ArrayList errorList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (goodsUWorkList == null || goodsUWorkList.Count == 0)
                return status;

            for (int i = 0; i < goodsUWorkList.Count; i++)
            {
                GoodsUWork goodsUWork = goodsUWorkList[i] as GoodsUWork;
                int writeStatus;
                string errorMessage;
                writeStatus = WriteGoodsUProcProc(goodsUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);

                if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //WARNING,ERRORじゃなかったらNORMAL
                    if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                        status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    errorList.Add(SetError(goodsUWork.GoodsNo, goodsUWork.GoodsMakerCd, errorMessage));
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsUWork">商品マスタ（ユーザー登録分）</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsUProcProc(GoodsUWork goodsUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNo);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != goodsUWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (goodsUWork.UpdateDateTime == DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            errorMessage = "重複するデータがあるため更新できません。";
                        }
                        //既存データで更新日時違いの場合には排他
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            errorMessage = "このデータは既に更新されています。";
                        }

                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    sqlText = "";

                    sqlText += "UPDATE GOODSURF" + Environment.NewLine;
                    sqlText += "SET" + Environment.NewLine;
                    sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlText += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                    sqlText += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                    sqlText += " , JANRF=@JAN" + Environment.NewLine;
                    sqlText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                    sqlText += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                    sqlText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                    sqlText += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                    sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                    sqlText += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                    sqlText += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                    sqlText += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                    sqlText += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                    sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                    sqlText += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNo);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (goodsUWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        errorMessage = "このデータは既に削除されています。";
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    sqlText = "" + Environment.NewLine;
                    sqlText += "INSERT INTO GOODSURF" + Environment.NewLine;
                    sqlText += "  (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlText += "  ,GOODSNAMERF" + Environment.NewLine;
                    sqlText += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                    sqlText += "  ,JANRF" + Environment.NewLine;
                    sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                    sqlText += "  ,DISPLAYORDERRF" + Environment.NewLine;
                    sqlText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                    sqlText += "  ,GOODSKINDCODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSNOTE1RF" + Environment.NewLine;
                    sqlText += "  ,GOODSNOTE2RF" + Environment.NewLine;
                    sqlText += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                    sqlText += " , OFFERDATADIVRF" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlText += "  ,@GOODSNAME" + Environment.NewLine;
                    sqlText += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                    sqlText += "  ,@JAN" + Environment.NewLine;
                    sqlText += "  ,@BLGOODSCODE" + Environment.NewLine;
                    sqlText += "  ,@DISPLAYORDER" + Environment.NewLine;
                    sqlText += "  ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                    sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                    sqlText += "  ,@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += "  ,@GOODSNOTE1" + Environment.NewLine;
                    sqlText += "  ,@GOODSNOTE2" + Environment.NewLine;
                    sqlText += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                    sqlText += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = sqlText;
                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameterオブジェクトの作成(更新用)
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
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIVRF", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNameKana);
                paraJan.Value = SqlDataMediator.SqlSetString(goodsUWork.Jan);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.BLGoodsCode);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsUWork.DisplayOrder);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsRateRank);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(goodsUWork.TaxationDivCd);
                paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNoNoneHyphen);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsUWork.OfferDate);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.GoodsKindCode);
                paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNote1);
                paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsNote2);
                paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsUWork.GoodsSpecialNote);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.EnterpriseGanreCode);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsUWork.UpdateDateTime);
                paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(goodsUWork.OfferDataDiv);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
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

        # region [古い価格マスタ削除処理]
        /// <summary>
        /// 古い価格マスタ削除処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="errorList">エラーリスト</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 古い価格マスタを削除します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int DeleteOldPriceProc(ArrayList goodsPriceUWorkList, ref ArrayList errorList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (goodsPriceUWorkList == null || goodsPriceUWorkList.Count == 0)
                return status;

            for (int i = 0; i < goodsPriceUWorkList.Count; i++)
            {
                GoodsPriceUWork goodsPriceUWork = goodsPriceUWorkList[i] as GoodsPriceUWork;
                int writeStatus;
                string errorMessage;
                writeStatus = DeleteOldPriceProcProc(goodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);

                if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //WARNING,ERRORじゃなかったらNORMAL
                    if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                        status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    errorList.Add(SetError(goodsPriceUWork.GoodsNo, goodsPriceUWork.GoodsMakerCd, errorMessage));
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }
        
        /// <summary>
        /// 古い価格マスタ削除処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsPriceUWork">価格マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 古い価格マスタを削除します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int DeleteOldPriceProcProc(GoodsPriceUWork goodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                sqlCommand.CommandText = sqlText;

                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //KEYコマンドを再設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region [商品価格マスタ情報の登録、更新処理]
        /// <summary>
        /// 商品価格マスタ情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="errorList">エラーリスト</param>
        /// <param name="costExpandProcessNumWork">処理件数</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsPriceProc(ArrayList goodsPriceUWorkList, ref ArrayList errorList, ref CostExpandProcessNumWork costExpandProcessNumWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (goodsPriceUWorkList == null || goodsPriceUWorkList.Count == 0)
                return status;

            Dictionary<string, GoodsPriceUWork> goodsPriceUWorkDic = new Dictionary<string,GoodsPriceUWork>();

            for (int i = 0; i < goodsPriceUWorkList.Count; i++)
            {
                GoodsPriceUWork goodsPriceUWork = goodsPriceUWorkList[i] as GoodsPriceUWork;
                int writeStatus;
                string errorMessage;
                writeStatus = WriteGoodsPriceProcProc(goodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);

                if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string key = goodsPriceUWork.GoodsMakerCd.ToString() + "\t" + goodsPriceUWork.GoodsNo;
                    if (!goodsPriceUWorkDic.ContainsKey(key))
                    {
                        //メーカー毎に処理した件数をカウントする
                        CountProcessNum((int)ct_TargetMaster.GoodsAndPrice, goodsPriceUWork.GoodsMakerCd, ref costExpandProcessNumWork);
                        goodsPriceUWorkDic.Add(key, goodsPriceUWork);
                    }

                    //WARNING,ERRORじゃなかったらNORMAL
                    if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                        status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    errorList.Add(SetError(goodsPriceUWork.GoodsNo, goodsPriceUWork.GoodsMakerCd, errorMessage));
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 商品価格マスタ INSERT or UPDATE 処理
        /// </summary>
        /// <param name="goodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsPriceProcProc(GoodsPriceUWork goodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != goodsPriceUWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (goodsPriceUWork.UpdateDateTime == DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            errorMessage = "重複するデータがあるため更新できません。";
                        }
                        //既存データで更新日時違いの場合には排他
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            errorMessage = "このデータは既に更新されています。";
                        }

                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //更新用のSQL文を生成
                    sqlText = "";
                    sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                    sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                    sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                    sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                    sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                    sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    goodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDateTime.Date;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (goodsPriceUWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        errorMessage = "このデータは既に削除されています。";
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //新規作成時のSQL文を生成
                    sqlText = "";
                    sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                    sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                    sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                    sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                    sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                    sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                    sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    goodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDateTime.Date;
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameterオブジェクトの作成(更新用)
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
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsPriceUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsPriceUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsPriceUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.ListPrice);
                convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = goodsPriceUWork.ListPrice;

                // 変換処理実行
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.SalesUnitCost);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.StockRate);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.OpenPriceDiv);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.OfferDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.UpdateDate);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
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

                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion

        # region [エラーオブジェクト生成処理]
        /// <summary>
        /// 部品価格マスタ展開エラーオブジェクトの生成処理
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>部品価格マスタ展開エラー</returns>
        /// <remarks>
        /// <br>Note       : 部品価格マスタ展開エラーオブジェクトを生成します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private CostExpandErrorWork SetError(string goodsNo, int goodsMakerCd, string errorMessage)
        {
            CostExpandErrorWork costExpandErrorWork = new CostExpandErrorWork();

            costExpandErrorWork.GoodsNo = goodsNo;
            costExpandErrorWork.GoodsMakerCd = goodsMakerCd;
            costExpandErrorWork.ErrorMessage = errorMessage;

            return costExpandErrorWork;
        }
        #endregion

        # region [処理件数のカウント処理]
        /// <summary>
        /// 部品価格マスタ展開の処理件数のカウント処理
        /// </summary>
        /// <param name="target">処理対象マスタ</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="costExpandProcessNumWork">部品価格マスタ展開の処理件数</param>
        /// <remarks>
        /// <br>Note       : 部品価格マスタ展開の処理件数をカウントします。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private void CountProcessNum(int target, int goodsMakerCd, ref CostExpandProcessNumWork costExpandProcessNumWork)
        {
            switch (target)
            {
                //掛率マスタ
                case (int)ct_TargetMaster.Rate:
                    {
                        switch (goodsMakerCd)
                        {
                            //トヨタ
                            case (int)ct_GoodsMaker.Toyota:
                                costExpandProcessNumWork.ToyotaBProcessNum++;
                                break;

                            //タクティ
                            case (int)ct_GoodsMaker.Takuthi:
                                costExpandProcessNumWork.TakuthiBProcessNum++;
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                //商品マスタ・価格マスタ
                case (int)ct_TargetMaster.GoodsAndPrice:
                    {
                        switch (goodsMakerCd)
                        {
                            //トヨタ
                            case (int)ct_GoodsMaker.Toyota:
                                costExpandProcessNumWork.ToyotaProcessNum++;
                                break;

                            //日産
                            case (int)ct_GoodsMaker.Nissan:
                                costExpandProcessNumWork.NissanProcessNum++;
                                break;

                            //タクティ
                            case (int)ct_GoodsMaker.Takuthi:
                                costExpandProcessNumWork.TakuthiProcessNum++;
                                break;

                            //ピットワーク
                            case (int)ct_GoodsMaker.Bittowaaku:
                                costExpandProcessNumWork.BittowaakuProcessNum++;
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;

            }
        }
        #endregion

        # region [パラメータ取得処理]
        /// <summary>
        /// パラメータ取得処理
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="type">取得タイプ</param>
        /// <param name="pattern">パラメータパターン：0クラス 1:Array</param>
        /// <returns>パラメータオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : パラメータを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        private object MakeParameter(ArrayList paramArray, Type type, Int32 pattern)
        {
            object result = null;
            //パラメータを取得
            if (pattern == 0)
            {
                foreach (object obj in paramArray)
                {
                    if (obj != null && obj.GetType() == type)
                    {
                        result = obj;
                        break;
                    }
                }
            }
            else if (pattern == 1 || pattern == 2)
            {
                foreach (object obj in paramArray)
                {
                    if (obj is ArrayList)
                    {
                        ArrayList al = obj as ArrayList;
                        if (al != null && al.Count > 0)
                        {
                            if (al[0] != null && al[0].GetType() == type)
                            {
                                result = obj;
                                break;
                            }
                        }
                    }
                    //pattern = 2の場合は1回のみ
                    if (pattern == 2)
                        break;
                }
            }
            return result;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SQLコネクション生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SQLコネクションを生成します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
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

        // --- ADD K2013/04/05 Y.Wakita ---------->>>>>
        #region [LogicalDelete]
        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        public int LogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 0);
        }

        /// <summary>
        /// 論理削除掛率設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除掛率設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        public int RevivalLogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 1);
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        private int LogicalDeleteSubSection(ref object rateWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rateWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSubSectionProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
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
                base.WriteErrorLog(ex, "RateDB.LogicalDeleteCarrier :" + procModestr);

                // ロールバック
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
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        public int LogicalDeleteSubSectionProc(ref ArrayList rateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSubSectionProcProc(ref rateWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        private int LogicalDeleteSubSectionProcProc(ref ArrayList rateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string command = string.Empty;

            command = "UPDATE RATERF" + Environment.NewLine;
            command += "SET" + Environment.NewLine;
            command += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
            command += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
            command += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
            command += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
            command += " , LOGICALDELETECODERF=1" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        RateWork rateWork = rateWorkList[i] as RateWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                        string whereString = string.Empty;
                        string whereString2 = string.Empty;
                        int cnt = 1;
                        whereString2 = MakeWhereString2(ref sqlCommand, rateWork, 0, cnt);
                        if (!string.IsNullOrEmpty(whereString2))
                        {
                            whereString += (string.IsNullOrEmpty(whereString)) ? whereString2 : " OR " + whereString2;
                        }

                        if (!string.IsNullOrEmpty(whereString))
                        {
                            whereString = "WHERE " + whereString;
                        }

                        sqlCommand.CommandText += whereString;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rateWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
 
                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        
                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rateWork);
                    }

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;

        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, RateWork rateWork, ConstantManagement.LogicalMode logicalMode, int cnt)
        {
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + cnt.ToString() + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE" + cnt.ToString(), SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            retstring += "AND LOGICALDELETECODERF=0 ";

            //拠点コード
            if (rateWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE" + cnt.ToString() + " ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE" + cnt.ToString(), SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
            }

            //単価掛率設定区分
            if (rateWork.UnitRateSetDivCd != "")
            {
                retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + cnt.ToString() + " ";
                SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD" + cnt.ToString(), SqlDbType.NChar);
                paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + cnt.ToString() + " ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD" + cnt.ToString(), SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品番号
            if (rateWork.GoodsNo != "")
            {
                retstring += "AND GOODSNORF=@FINDGOODSNO" + cnt.ToString() + " ";
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO" + cnt.ToString(), SqlDbType.NVarChar);
                paraGoodsNo.Value = rateWork.GoodsNo;
            }

            //商品掛率ランク
            if (rateWork.GoodsRateRank != "")
            {
                retstring += "AND GOODSRATERANKRF=@FINDGOODSRATERANK" + cnt.ToString() + " ";
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK" + cnt.ToString(), SqlDbType.NChar);
                paraGoodsRateRank.Value = rateWork.GoodsRateRank;
            }

            //商品掛率グループコード
            if (rateWork.GoodsRateGrpCode != 0)
            {
                retstring += "AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + cnt.ToString() + " ";
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE" + cnt.ToString(), SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
            }

            //BLグループコード
            if (rateWork.BLGroupCode != 0)
            {
                retstring += "AND BLGROUPCODERF=@FINDBLGROUPCODE" + cnt.ToString() + " ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE" + cnt.ToString(), SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
            }

            //BL商品コード
            if (rateWork.BLGoodsCode != 0)
            {
                retstring += "AND BLGOODSCODERF=@FINDBLGOODSCODE" + cnt.ToString() + " ";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE" + cnt.ToString(), SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
            }

            //得意先コード
            if (rateWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + cnt.ToString() + " ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE" + cnt.ToString(), SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
            }

            //得意先掛率グループコード
            if (rateWork.CustRateGrpCode != -1)
            {
                retstring += "AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + cnt.ToString() + " ";
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE" + cnt.ToString(), SqlDbType.Int);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
            }

            //仕入先コード
            if (rateWork.SupplierCd != 0)
            {
                retstring += "AND SUPPLIERCDRF=@FINDSUPPLIERCD" + cnt.ToString() + " ";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD" + cnt.ToString(), SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
            }

            //ロット数
            //if (rateWork.LotCount != -1.0)
            //{
            //    retstring += "AND LOTCOUNTRF=@FINDLOTCOUNT" + cnt.ToString() + " ";
            //    SqlParameter paraLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT" + cnt.ToString(), SqlDbType.Float);
            //    paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
            //}

            if (!string.IsNullOrEmpty(retstring))
            {
                retstring = "( " + retstring + " )";
            }
            return retstring;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : K2013/04/05</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RateWork[] RateWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is RateWork)
                    {
                        RateWork wkRateWork = paraobj as RateWork;
                        if (wkRateWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRateWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RateWorkArray = (RateWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RateWork[]));
                        }
                        catch (Exception) { }
                        if (RateWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RateWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RateWork wkRateWork = (RateWork)XmlByteSerializer.Deserialize(byteArray, typeof(RateWork));
                                if (wkRateWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRateWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion
        // --- ADD K2013/04/05 Y.Wakita ----------<<<<<

    }
}


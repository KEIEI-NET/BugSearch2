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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 部品情報取得DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品情報取得の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.07.14</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.17 22018 鈴木 正臣</br>
    /// <br>             ①価格の取得を修正</br>
    /// <br>               価格適用日をパラメータに追加。</br>
    /// <br></br>
    /// <br>Update Note: 2009.07.24 22018 鈴木 正臣</br>
    /// <br>             ①部品検索のソート順を変更する為、抽出クエリを一部変更。</br>
    /// <br>               なお、最終的にソート順はPMKEN08060Uで決定する。</br>
    /// <br></br>
    /// <br>Update Note: 2009.07.27 22018 鈴木 正臣</br>
    /// <br>             ①QTYの取得元フィールドを変更。「…（整備用）」を使用する。</br>
    /// <br>　　　　　　　　（PartsQtyRF→PartsQtyForRpRF）</br>
    /// <br></br>
    /// <br>Update Note: 検索部品名称マスタの全メーカー用の対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/23</br>
    /// <br></br>
    /// <br>Update Note: BL検索時の部品圧縮方法の修正(MANTIS[0014498])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/11/09</br>
    /// <br></br>
    /// <br>Update Note: 検索速度のチューニング(MANTIS[0014934])</br>
    /// <br>             ①車輌の検索可能ＢＬコードの検索クエリの修正</br>
    /// <br>             ②BLコード検索のメインクエリの修正</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/01/25</br>
    /// <br></br>
    /// <br>Update Note: 検索速度のチューニング</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/04/19</br>
    /// <br></br>
    /// <br>Update Note: 自由検索オプション対応</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合</br>
    /// <br>               自由検索 2010/04/28 の組込</br>
    /// <br>               （※2010/04/19分との統合により処理を書き換えている為、2010/06/04のコメント）</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note: 提供DB統合対応</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/06/14</br>
    /// <br></br>
    /// <br>Update Note: ＢＬコード検索速度チューニング</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/11/02</br>
    /// <br></br>
    /// <br>Update Note: 優良結合連携マスタをUNION→UNION ALLに変更</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/11/22</br>
    /// <br></br>
    /// <br>Update Note: 車台番号の抽出条件を修正(年式のelse ifにしない)</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2011/03/07</br>
    /// <br></br>
    /// <br>Update Note: SCM対応</br>
    /// <br>               BLコード検索時の検索結果に、自動見積部品コード、BLコード枝番用部品名称を追加</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// <br>Update Note: 障害対応</br>
    /// <br>               商品在庫一括登録修正の新規登録時に、提供の純正部品が検索されない不具合を修正</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2011/06/23</br>
    /// <br></br>
    /// <br>Update Note: 速度改良</br>
    /// <br>             速度改良及び同一部品圧縮処理をクエリ内部で行うように変更</br>
    /// <br>Programmer : 20073　西 毅</br>
    /// <br>Date       : 2012/01/24</br>
    /// <br>Update Note: 仕掛一覧対応 No.1742</br>
    /// <br>             商品在庫マスタ（一括登録・修正）にてセレクトコードありの優良部品が検索されない障害の修正</br>
    /// <br>Programmer : 22013 久保 将太</br>
    /// <br>Date       : 2013/02/15</br>
    /// <br></br>
    /// <br>Update Note: SCM改良</br>
    /// <br>             優良結合連携フラグ追加(ダミー品番判別用)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2013/02/12</br>
    /// <br></br>
    /// <br>Update Note: 10900269-00 SPK車台番号文字列対応</br>
    /// <br>             VINコードによる絞込処理追加</br>
    /// <br>             VIN生産No.(始期)・VIN生産No.(終期)の取得処理追加</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/03/27</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    13.フル型式固定番号からのＢＬコード検索回数改良対応</br>
    /// <br>                                    14.明細取込区分の更新方法を改良対応</br>
    /// <br>                                    15.SCM受発注データ（車両情報）取得方法改良対応</br>
    /// <br>                                    16.純正品検索改良対応</br>
    /// <br>                                    17.優良品検索改良対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OfferPartsInfDB : RemoteDB, IOfferPartsInfo
    {
        #region 内部変数定義

        /// <summary>
        /// カラー用ワーククラス
        /// </summary>
        private class colorwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }
        /// <summary>
        /// トリム用ワーククラス
        /// </summary>
        private class trimwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }
        /// <summary>
        /// 装備用ワーククラス
        /// </summary>
        private class equipwk
        {
            #region
            public int FULLMODELFIXEDNORF;
            public int TBSPARTSCODERF;
            public int TBSPARTSCDDERIVEDNORF;
            public string FIGSHAPENORF = "";
            //public int SHAPENOINSIDEROWNORF;
            #endregion
        }

        private ArrayList alcolorwk;
        private ArrayList altrimwk;
        private ArrayList alequipwk;
        private int PartsNarrowingCode;
        #endregion

        #region [ コンストラクタ ]
        /// <summary>
        ///　作業情報取得DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 99033　岩本　勇</br>
        /// <br>Date       : 2005.04.14</br>
        /// </remarks>
        public OfferPartsInfDB()
            :
            base("PMTKD06163D", "Broadleaf.Application.Remoting.OfferPartsInfDB", "OFFERPARTSINFRF")
        {
        }
        #endregion

        #region [ 部品名称取得 ]
        /// <summary>
        /// 品名取得(全角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 0);
        }

        /// <summary>
        /// 品名取得(半角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 1);
        }

        private int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string nameString = "";
            if (mode == 0)
            {
                nameString = "MAKEROFFERPARTSNAMERF";
            }
            else
            {
                nameString = "MAKEROFFERPARTSKANARF";
            }

            // -- UPD 2010/06/14 ----------------------------------------->>>
            //string query = "SELECT " + nameString + " MAKEROFFERPARTSNAMERF FROM PTMKRPRICERF "
            string query = "SELECT " + nameString + " MAKEROFFERPARTSNAMERF FROM PTMKRPRICEPMRF AS PTMKRPRICERF "
            // -- UPD 2010/06/14 -----------------------------------------<<<
                         + "WHERE NEWPRTSNOWITHHYPHENRF = @PARTSNO AND MAKERCODERF = @MAKERCODE ";
            name = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return 99;
            }
            sqlConnection.Open();

            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@PARTSNO", SqlDbType.NVarChar)).Value = partsNo;
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = makerCd;
                object ret = sqlCommand.ExecuteScalar();
                if (ret != null)
                {
                    name = ret.ToString();
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
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }

            return status;
        }
        #endregion

        #region [ GetPartsInf(純正部品検索) ]
        /// <summary>
        /// PM.NS用部品検索
        /// </summary>
        /// <param name="InPara">検索パラメータ</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された部品の情報を検索します。</br>
        /// <br>Programmer : 99033　岩本　勇</br>
        /// <br>Date       : 2006.11.14</br>
        public int GetPartsInf(GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork, out long RetCnt)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            //戻り初期化
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//カラー情報
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//トリム情報
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//装備情報
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//部品代替情報

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                //部品絞り　0:生産年式,1;車台番号
                //int PartsNarrowingCode = 0;
                //if ((InPara.MakerCode != 0) && (InPara.ModelCode != 0))
                //    ReadModelNameRF(InPara.MakerCode, InPara.ModelCode, InPara.ModelSubCode, ref PartsNarrowingCode, ref sqlConnection);

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //★★★★★部品検索メイン
                status = SearchPartsInf(InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection);

                if (status == 0)
                {
                    //カラー抽出
                    ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                    //Trim抽出
                    ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                    //装備抽出
                    ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                    //部品代替抽出
                    if (InPara.NoSubst == 0)
                        ExtrPrtsubstAll(InPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                    if (InPara.TbsPartsCode != 0) // BL検索時
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //SearchNewPartsInf(alRetParts, ref alprtsubst, ref sqlConnection);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        SearchNewPartsInf( InPara, alRetParts, ref alprtsubst, ref sqlConnection );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }

            }
            catch
            {
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

            //======結果をCustomSerializeArrayListに代入
            RetPartsCustomSerializeArrayList.Add(alRetParts);           //部品情報
            colorCustomSerializeArrayList.Add(alcolor);                 //カラー情報
            trimCustomSerializeArrayList.Add(altrim);                   //トリム情報
            equipCustomSerializeArrayList.Add(alequip);                 //装備情報
            prtsubstCustomSerializeArrayList.Add(alprtsubst);           //部品代替情報


            RetCnt = alRetParts.Count;

            return status;
        }

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// PM.NS用部品検索（自由検索での機能追加含む）
        /// </summary>
        /// <param name="InPara">検索パラメータ</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された部品の情報を検索します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2010/04/27</br>
        public int GetPartsInf( GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt )
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            //戻り初期化
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//カラー情報
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//トリム情報
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//装備情報
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//部品代替情報
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品情報(自由検索用)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品代替情報(自由検索用)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品(自由検索用)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品価格(自由検索用)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット(自由検索用)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット価格(自由検索用)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // 自由検索用（純正）
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // 自由検索用（優良）
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if ( sqlConnection == null )
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //★★★★★部品検索メイン
                if ( !InPara.NormalSearchExclude )
                {
                    status = SearchPartsInf( InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection );

                    if ( status == 0 )
                    {
                        //カラー抽出
                        ExtrColorAll( null, ref alRetParts, ref alcolor, ref sqlConnection );
                        //Trim抽出
                        ExtrTrimAll( null, ref alRetParts, ref altrim, ref sqlConnection );
                        //装備抽出
                        ExtrEquipAll( null, ref alRetParts, ref alequip, ref sqlConnection );

                        //部品代替抽出
                        if ( InPara.NoSubst == 0 )
                            ExtrPrtsubstAll( InPara, ref alRetParts, ref alprtsubst, ref sqlConnection );
                        if ( InPara.TbsPartsCode != 0 ) // BL検索時
                            SearchNewPartsInf( InPara, alRetParts, ref alprtsubst, ref sqlConnection );
                    }
                }

                //★★★★★以下、自由検索用
                if ( InPara.SearchKeyList != null && InPara.SearchKeyList.Count > 0 )
                {
                    //----------------------------------------
                    // 純正 複数品番検索
                    //----------------------------------------
                    // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供純正の検索
                    int fsStatus = GetGenuinePartsInfForFreeSearch( InPara, alRetPartsFS, sqlConnection );
                    if ( fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0 )
                    {
                        //部品代替抽出
                        if ( InPara.NoSubst == 0 )
                            ExtrPrtsubstAll( InPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection );
                        if ( InPara.TbsPartsCode != 0 ) // BL検索時
                            SearchNewPartsInf( InPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection );
                    }
                    //----------------------------------------
                    // 優良 複数品番検索
                    //----------------------------------------
                    // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供優良の検索
                    GetPrimePartsInfWithSetProc( InPara.TbsPartsCode, InPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection );

                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //======結果をCustomSerializeArrayListに代入
            RetPartsCustomSerializeArrayList.Add( alRetParts );           //部品情報
            colorCustomSerializeArrayList.Add( alcolor );                 //カラー情報
            trimCustomSerializeArrayList.Add( altrim );                   //トリム情報
            equipCustomSerializeArrayList.Add( alequip );                 //装備情報
            prtsubstCustomSerializeArrayList.Add( alprtsubst );           //部品代替情報

            // 自由検索用（純正）
            RetPartsCustomSerializeArrayListFS.Add( alRetPartsFS );       //部品情報(自由検索用)
            prtsubstCustomSerializeArrayListFS.Add( alprtsubstFS );       //部品代替情報(自由検索用)
            // 自由検索用（優良）
            retPrimePartsCustomSerializeArrayListFS.Add( alPrimPartsFS );       //優良部品(自由検索用)
            retPrimePriceCustomSerializeArrayListFS.Add( alPrimPriceFS );       //優良部品価格(自由検索用)
            retPrimeSetCustomSerializeArrayListFS.Add( alPrimSetFS );           //優良セット(自由検索用)
            retPrimeSetPriceCustomSerializeArrayListFS.Add( alPrimSetPriceFS ); //優良セット価格(自由検索用)

            RetCnt = alRetParts.Count;

            return status;
        }

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ---------------------------------->>>>>
        /// <summary>
        /// PM.NS用部品検索（自由検索での機能追加含む）（自動回答処理専用）
        /// </summary>
        /// <param name="InPara">検索パラメータ</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された部品の情報を検索します。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        public int GetPartsInf(ArrayList InParaList, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            List<GetPartsInfPara> InParaListWork = new List<GetPartsInfPara>((GetPartsInfPara[])InParaList.ToArray(typeof(GetPartsInfPara)));
            //戻り初期化
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//カラー情報
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//トリム情報
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//装備情報
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//部品代替情報
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品情報(自由検索用)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品代替情報(自由検索用)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品(自由検索用)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品価格(自由検索用)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット(自由検索用)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット価格(自由検索用)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // 自由検索用（純正）
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // 自由検索用（優良）
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                foreach (GetPartsInfPara inPara in InParaListWork)
                {
                    alRetParts = new ArrayList();
                    alcolor = new ArrayList();
                    altrim = new ArrayList();
                    alequip = new ArrayList();
                    alprtsubst = new ArrayList();
                    alRetPartsFS = new ArrayList();
                    alprtsubstFS = new ArrayList();
                    alPrimPartsFS = new ArrayList();
                    alPrimPriceFS = new ArrayList();
                    alPrimSetFS = new ArrayList();
                    alPrimSetPriceFS = new ArrayList();

                    //★★★★★部品検索メイン
                    if (!inPara.NormalSearchExclude)
                    {
                        status = SearchPartsInf(inPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection);

                        if (status == 0)
                        {
                            //カラー抽出
                            ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                            //Trim抽出
                            ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                            //装備抽出
                            ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                            //部品代替抽出
                            if (inPara.NoSubst == 0)
                                ExtrPrtsubstAll(inPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                            if (inPara.TbsPartsCode != 0) // BL検索時
                                SearchNewPartsInf(inPara, alRetParts, ref alprtsubst, ref sqlConnection);
                        }
                    }

                    //★★★★★以下、自由検索用
                    if (inPara.SearchKeyList != null && inPara.SearchKeyList.Count > 0)
                    {
                        //----------------------------------------
                        // 純正 複数品番検索
                        //----------------------------------------
                        // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供純正の検索
                        int fsStatus = GetGenuinePartsInfForFreeSearch(inPara, alRetPartsFS, sqlConnection);
                        if (fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0)
                        {
                            //部品代替抽出
                            if (inPara.NoSubst == 0)
                                ExtrPrtsubstAll(inPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                            if (inPara.TbsPartsCode != 0) // BL検索時
                                SearchNewPartsInf(inPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                        }
                        //----------------------------------------
                        // 優良 複数品番検索
                        //----------------------------------------
                        // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供優良の検索
                        GetPrimePartsInfWithSetProc(inPara.TbsPartsCode, inPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection);

                    }

                    //======結果をCustomSerializeArrayListに代入
                    //======結果がゼロの時は空のデータを作成して追加（複数件対応のため）
                    if (alRetParts.Count == 0) SetalRetParts(ref alRetParts);
                    RetPartsCustomSerializeArrayList.Add(alRetParts);           //部品情報
                    if (alcolor.Count == 0) Setalcolor(ref alcolor);
                    colorCustomSerializeArrayList.Add(alcolor);                 //カラー情報
                    if (altrim.Count == 0) Setaltrim(ref altrim);
                    trimCustomSerializeArrayList.Add(altrim);                   //トリム情報
                    if (alequip.Count == 0) Setalequip(ref alequip);
                    equipCustomSerializeArrayList.Add(alequip);                 //装備情報
                    if (alprtsubst.Count == 0) Setalprtsubst(ref alprtsubst);
                    prtsubstCustomSerializeArrayList.Add(alprtsubst);           //部品代替情報

                    // 自由検索用（純正）
                    if (alRetPartsFS.Count == 0) SetalRetPartsFS(ref alRetPartsFS);
                    RetPartsCustomSerializeArrayListFS.Add(alRetPartsFS);       //部品情報(自由検索用)
                    if (alprtsubstFS.Count == 0) SetalprtsubstFS(ref alprtsubstFS);
                    prtsubstCustomSerializeArrayListFS.Add(alprtsubstFS);       //部品代替情報(自由検索用)
                    // 自由検索用（優良）
                    if (alPrimPartsFS.Count == 0) SetalPrimPartsFS(ref alPrimPartsFS);
                    retPrimePartsCustomSerializeArrayListFS.Add(alPrimPartsFS);       //優良部品(自由検索用)
                    if (alPrimPriceFS.Count == 0) SetalPrimPriceFS(ref alPrimPriceFS);
                    retPrimePriceCustomSerializeArrayListFS.Add(alPrimPriceFS);       //優良部品価格(自由検索用)
                    if (alPrimSetFS.Count == 0) SetalPrimSetFS(ref alPrimSetFS);
                    retPrimeSetCustomSerializeArrayListFS.Add(alPrimSetFS);           //優良セット(自由検索用)
                    if (alPrimSetPriceFS.Count == 0) SetalPrimSetPriceFS(ref alPrimSetPriceFS);
                    retPrimeSetPriceCustomSerializeArrayListFS.Add(alPrimSetPriceFS); //優良セット価格(自由検索用)

                    RetCnt = RetCnt + alRetParts.Count;

                }
            }
            catch
            {
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

            if (RetCnt != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        #region 情報初期化設定 
        /// <summary>
        ///  部品情報初期化設定
        /// </summary>
        /// <param name="alRetParts"></param>
        private void SetalRetParts(ref ArrayList alRetParts)
        {
            RetPartsInf mf = new RetPartsInf();

            mf.AutoEstimatePartsCd = string.Empty;
            mf.CatalogPartsMakerCd = 0;
            mf.CategorySignModel = string.Empty;
            mf.ClgPrtsNoWithHyphen = string.Empty;
            mf.ColdDistrictsFlag = 0;
            mf.ColorNarrowingFlag = 0;
            mf.EquipNarrowingFlag = 0;
            mf.ExhaustGasSign = string.Empty;
            mf.FigShapeNo = string.Empty;
            mf.FullModelFixedNo = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.ModelPrtsAblsFrameNo = 0;
            mf.ModelPrtsAblsYm = 0;
            mf.ModelPrtsAdptFrameNo = 0;
            mf.ModelPrtsAdptYm = 0;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NewPrtsNoWithHyphen = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsNameKana = string.Empty;
            mf.PartsNarrowingCode = 0;
            mf.PartsOpNm = string.Empty;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PartsUniqueNo = 0;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.PrimeJoinLnkFlg = 0;
            mf.SeriesModel = string.Empty;
            mf.SrchPNmAcqrCarMkrCd = 0;
            mf.StandardName = string.Empty;
            mf.TbsPartsCdDerivedNm = string.Empty;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;
            mf.TrimNarrowingFlag = 0;
            mf.VinProduceEndNo = 0;
            mf.VinProduceStartNo = 0;
            mf.WorkOrPartsDivNm = string.Empty;

            alRetParts.Add(mf);
        }
        /// <summary>
        ///  カラー情報初期化設定
        /// </summary>
        /// <param name="alcolor"></param>
        private void Setalcolor(ref ArrayList alcolor)
        {
            PartsColorWork mf = new PartsColorWork();

            mf.ColorCdInfoNo = string.Empty;
            mf.PartsProperNo = 0;

            alcolor.Add(mf);

        }
        /// <summary>
        ///  トリム情報初期化設定
        /// </summary>
        /// <param name="altrim"></param>
        private void Setaltrim(ref ArrayList altrim)
        {
            PartsTrimWork mf = new PartsTrimWork();

            mf.PartsProperNo = 0;
            mf.TrimCode = string.Empty;

            altrim.Add(mf);
        }
        /// <summary>
        ///  装備情報初期化設定
        /// </summary>
        /// <param name="alequip"></param>
        private void Setalequip(ref ArrayList alequip)
        {
            PartsEquipWork mf = new PartsEquipWork();

            mf.EquipmentCode = 0;
            mf.EquipmentGenreCd = 0;
            mf.PartsProperNo = 0;

            alequip.Add(mf);
        }
        /// <summary>
        ///  部品代替情報初期化設定
        /// </summary>
        /// <param name="alprtsubst"></param>
        private void Setalprtsubst(ref ArrayList alprtsubst)
        {
            PartsSubstWork mf = new PartsSubstWork();

            mf.CatalogPartsMakerCd = 0;
            mf.MainOrSubPartsDivCd = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.NewPartsNoWithHyphen = string.Empty;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NPrtNoWithHypnDspOdr = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OldPartsNoWithHyphen = string.Empty;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsInfoCtrlFlg = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsPluralSubstCmnt = string.Empty;
            mf.PartsPluralSubstFlg = 0;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PlrlSubNewPrtNoHypn = string.Empty;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alprtsubst.Add(mf);
        }
        /// <summary>
        ///  部品情報(自由検索用)初期化設定
        /// </summary>
        /// <param name="alRetPartsFS"></param>
        private void SetalRetPartsFS(ref ArrayList alRetPartsFS)
        {
            RetPartsInf mf = new RetPartsInf();

            mf.AutoEstimatePartsCd = string.Empty;
            mf.CatalogPartsMakerCd = 0;
            mf.CategorySignModel = string.Empty;
            mf.ClgPrtsNoWithHyphen = string.Empty;
            mf.ColdDistrictsFlag = 0;
            mf.ColorNarrowingFlag = 0;
            mf.EquipNarrowingFlag = 0;
            mf.ExhaustGasSign = string.Empty;
            mf.FigShapeNo = string.Empty;
            mf.FullModelFixedNo = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.ModelPrtsAblsFrameNo = 0;
            mf.ModelPrtsAblsYm = 0;
            mf.ModelPrtsAdptFrameNo = 0;
            mf.ModelPrtsAdptYm = 0;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NewPrtsNoWithHyphen = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsNameKana = string.Empty;
            mf.PartsNarrowingCode = 0;
            mf.PartsOpNm = string.Empty;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PartsUniqueNo = 0;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.PrimeJoinLnkFlg = 0;
            mf.SeriesModel = string.Empty;
            mf.SrchPNmAcqrCarMkrCd = 0;
            mf.StandardName = string.Empty;
            mf.TbsPartsCdDerivedNm = string.Empty;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;
            mf.TrimNarrowingFlag = 0;
            mf.VinProduceEndNo = 0;
            mf.VinProduceStartNo = 0;
            mf.WorkOrPartsDivNm = string.Empty;

            alRetPartsFS.Add(mf);
        }
        /// <summary>
        ///  部品代替情報(自由検索用)初期化設定
        /// </summary>
        /// <param name="alprtsubstFS"></param>
        private void SetalprtsubstFS(ref ArrayList alprtsubstFS)
        {
            PartsSubstWork mf = new PartsSubstWork();

            mf.CatalogPartsMakerCd = 0;
            mf.MainOrSubPartsDivCd = 0;
            mf.MakerOfferPartsKana = string.Empty;
            mf.MakerOfferPartsName = string.Empty;
            mf.NewPartsNoWithHyphen = string.Empty;
            mf.NewPrtsNoNoneHyphen = string.Empty;
            mf.NPrtNoWithHypnDspOdr = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OldPartsNoWithHyphen = string.Empty;
            mf.OpenPriceDiv = 0;
            mf.PartsCode = 0;
            mf.PartsInfoCtrlFlg = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PartsName = string.Empty;
            mf.PartsPluralSubstCmnt = string.Empty;
            mf.PartsPluralSubstFlg = 0;
            mf.PartsPrice = 0;
            mf.PartsPriceStDate = DateTime.MinValue;
            mf.PartsQty = 0;
            mf.PartsSearchCode = 0;
            mf.PlrlSubNewPrtNoHypn = string.Empty;
            mf.PriceOfferDate = DateTime.MinValue;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alprtsubstFS.Add(mf);
        }
        /// <summary>
        ///  優良部品(自由検索用)初期化設定
        /// </summary>
        /// <param name="alPrimPartsFS"></param>
        private void SetalPrimPartsFS(ref ArrayList alPrimPartsFS)
        {
            OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.GoodsMGroup = 0;
            mf.JoinDestMakerCd = 0;
            mf.JoinDestPartsNo = string.Empty;
            mf.JoinDispOrder = 0;
            mf.JoinQty = 0;
            mf.JoinSourceMakerCode = 0;
            mf.JoinSourPartsNoNoneH = string.Empty;
            mf.JoinSourPartsNoWithH = string.Empty;
            mf.JoinSpecialNote = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmSetDtlNo1 = 0;
            mf.PrmSetDtlNo2 = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetPartsFlg = 0;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alPrimPartsFS.Add(mf);

        }
        /// <summary>
        ///  優良部品価格(自由検索用)初期化設定
        /// </summary>
        /// <param name="alPrimPriceFS"></param>
        private void SetalPrimPriceFS(ref ArrayList alPrimPriceFS)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            alPrimPriceFS.Add(mf);
        }
        /// <summary>
        ///  優良セット(自由検索用)初期化設定
        /// </summary>
        /// <param name="alPrimSetFS"></param>
        private void SetalPrimSetFS(ref ArrayList alPrimSetFS)
        {
            OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.CatalogShapeNo = string.Empty;
            mf.GoodsMGroup = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmPrtTbsPrtCd = 0;
            mf.PrmPrtTbsPrtCdDerivNo = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetDispOrder = 0;
            mf.SetMainMakerCd = 0;
            mf.SetMainPartsNo = string.Empty;
            mf.SetName = string.Empty;
            mf.SetQty = 0;
            mf.SetSpecialNote = string.Empty;
            mf.SetSubMakerCd = 0;
            mf.SetSubPartsNo = string.Empty;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            alPrimSetFS.Add(mf);
        }
        /// <summary>
        ///  優良セット価格(自由検索用)初期化設定
        /// </summary>
        /// <param name="alPrimSetPriceFS"></param>
        private void SetalPrimSetPriceFS(ref ArrayList alPrimSetPriceFS)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            alPrimSetPriceFS.Add(mf);
        }
        #endregion //情報初期化設定

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ----------------------------------<<<<<

        // 速度改善テスト -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// PM.NS用部品検索（自由検索での機能追加含む）
        /// </summary>
        /// <param name="InPara">検索パラメータ</param>		
        /// <param name="RetParts"></param>
        /// <param name="color"></param>
        /// <param name="trim"></param>
        /// <param name="equip"></param>
        /// <param name="prtsubst"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="retPartsFreeSearch"></param>
        /// <param name="prtsubstFreeSearch"></param>
        /// <param name="retPrimParts"></param>
        /// <param name="retPrimPrice"></param>
        /// <param name="retPrimSet"></param>
        /// <param name="retPrimSetPrice"></param>
        /// <param name="RetCnt"></param>
        /// <returns>STATUS</returns>
        public int GetPartsInfYYYY(GetPartsInfPara InPara, ref object RetParts, ref object color,
            ref object trim, ref object equip, ref object prtsubst, out List<PartsModelLnkWork> partsModelLnkWork,
            ref object retPartsFreeSearch, ref object prtsubstFreeSearch,
            ref object retPrimParts, ref object retPrimPrice, ref object retPrimSet, ref object retPrimSetPrice,
            out long RetCnt
            , List<object> foundAutoAnsItemStList)
        {
            int status = 0;
            SqlConnection sqlConnection = null;

            List<AutoAnsItemStForOffer> wkFoundAutoAnsItemStList = new List<AutoAnsItemStForOffer>();
            foreach (List<object> tgt in foundAutoAnsItemStList)
            {
                AutoAnsItemStForOffer wk = new AutoAnsItemStForOffer();
                wk.SectionCode = tgt[0].ToString().Trim();	// 拠点コード
                wk.CustomerCode = (int)tgt[1];      // 得意先コード
                wk.GoodsMGroup = (int)tgt[2];		// 商品中分類コード
                wk.BLGoodsCode = (int)tgt[3];       // BL商品コード
                wk.GoodsMakerCd = (int)tgt[4];      // 商品メーカーコード
                wk.PrmSetDtlNo2 = (int)tgt[5];      // 優良設定詳細コード２
                wk.AutoAnswerDiv = (int)tgt[6];     // 自動回答区分
                wk.PriorityOrder = (int)tgt[7];     // 優先順位

                wkFoundAutoAnsItemStList.Add(wk);
            }

            //戻り初期化
            RetCnt = 0;
            partsModelLnkWork = new List<PartsModelLnkWork>();

            ArrayList alRetParts = new ArrayList();
            ArrayList alcolor = new ArrayList();
            ArrayList altrim = new ArrayList();
            ArrayList alequip = new ArrayList();
            ArrayList alprtsubst = new ArrayList();
            ArrayList alRetPartsFS = new ArrayList();
            ArrayList alprtsubstFS = new ArrayList();
            ArrayList alPrimPartsFS = new ArrayList();
            ArrayList alPrimPriceFS = new ArrayList();
            ArrayList alPrimSetFS = new ArrayList();
            ArrayList alPrimSetPriceFS = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            CustomSerializeArrayList colorCustomSerializeArrayList = new CustomSerializeArrayList();//カラー情報
            CustomSerializeArrayList trimCustomSerializeArrayList = new CustomSerializeArrayList();//トリム情報
            CustomSerializeArrayList equipCustomSerializeArrayList = new CustomSerializeArrayList();//装備情報
            CustomSerializeArrayList prtsubstCustomSerializeArrayList = new CustomSerializeArrayList();//部品代替情報
            CustomSerializeArrayList RetPartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品情報(自由検索用)
            CustomSerializeArrayList prtsubstCustomSerializeArrayListFS = new CustomSerializeArrayList();//部品代替情報(自由検索用)
            CustomSerializeArrayList retPrimePartsCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品(自由検索用)
            CustomSerializeArrayList retPrimePriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良部品価格(自由検索用)
            CustomSerializeArrayList retPrimeSetCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット(自由検索用)
            CustomSerializeArrayList retPrimeSetPriceCustomSerializeArrayListFS = new CustomSerializeArrayList();//優良セット価格(自由検索用)

            RetParts = RetPartsCustomSerializeArrayList;
            color = colorCustomSerializeArrayList;
            trim = trimCustomSerializeArrayList;
            equip = equipCustomSerializeArrayList;
            prtsubst = prtsubstCustomSerializeArrayList;
            // 自由検索用（純正）
            retPartsFreeSearch = RetPartsCustomSerializeArrayListFS;
            prtsubstFreeSearch = prtsubstCustomSerializeArrayListFS;
            // 自由検索用（優良）
            retPrimParts = retPrimePartsCustomSerializeArrayListFS;
            retPrimPrice = retPrimePriceCustomSerializeArrayListFS;
            retPrimSet = retPrimeSetCustomSerializeArrayListFS;
            retPrimSetPrice = retPrimeSetPriceCustomSerializeArrayListFS;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                //★★★★★部品検索メイン
                if (!InPara.NormalSearchExclude)
                {
                    status = SearchPartsInfYYYY(InPara, ref alRetParts, ref partsModelLnkWork, ref sqlConnection, wkFoundAutoAnsItemStList);

                    if (status == 0)
                    {
                        //カラー抽出
                        ExtrColorAll(null, ref alRetParts, ref alcolor, ref sqlConnection);
                        //Trim抽出
                        ExtrTrimAll(null, ref alRetParts, ref altrim, ref sqlConnection);
                        //装備抽出
                        ExtrEquipAll(null, ref alRetParts, ref alequip, ref sqlConnection);

                        //部品代替抽出
                        if (InPara.NoSubst == 0)
                            ExtrPrtsubstAll(InPara, ref alRetParts, ref alprtsubst, ref sqlConnection);
                        if (InPara.TbsPartsCode != 0) // BL検索時
                            SearchNewPartsInf(InPara, alRetParts, ref alprtsubst, ref sqlConnection);
                    }
                }

                //★★★★★以下、自由検索用
                if (InPara.SearchKeyList != null && InPara.SearchKeyList.Count > 0)
                {
                    //----------------------------------------
                    // 純正 複数品番検索
                    //----------------------------------------
                    // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供純正の検索
                    int fsStatus = GetGenuinePartsInfForFreeSearch(InPara, alRetPartsFS, sqlConnection);
                    if (fsStatus == 0 && alRetPartsFS != null && alRetPartsFS.Count > 0)
                    {
                        //部品代替抽出
                        if (InPara.NoSubst == 0)
                            ExtrPrtsubstAll(InPara, ref alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                        if (InPara.TbsPartsCode != 0) // BL検索時
                            SearchNewPartsInf(InPara, alRetPartsFS, ref alprtsubstFS, ref sqlConnection);
                    }
                    //----------------------------------------
                    // 優良 複数品番検索
                    //----------------------------------------
                    // 自由検索部品(InPara.SearchKeyListで指定)に紐付く提供優良の検索
                    GetPrimePartsInfWithSetProc(InPara.TbsPartsCode, InPara.SearchKeyList, ref alPrimPartsFS, ref alPrimPriceFS, ref alPrimSetFS, ref alPrimSetPriceFS, ref sqlConnection);

                }
            }
            catch
            {
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

            //======結果をCustomSerializeArrayListに代入
            RetPartsCustomSerializeArrayList.Add(alRetParts);           //部品情報
            colorCustomSerializeArrayList.Add(alcolor);                 //カラー情報
            trimCustomSerializeArrayList.Add(altrim);                   //トリム情報
            equipCustomSerializeArrayList.Add(alequip);                 //装備情報
            prtsubstCustomSerializeArrayList.Add(alprtsubst);           //部品代替情報

            // 自由検索用（純正）
            RetPartsCustomSerializeArrayListFS.Add(alRetPartsFS);       //部品情報(自由検索用)
            prtsubstCustomSerializeArrayListFS.Add(alprtsubstFS);       //部品代替情報(自由検索用)
            // 自由検索用（優良）
            retPrimePartsCustomSerializeArrayListFS.Add(alPrimPartsFS);       //優良部品(自由検索用)
            retPrimePriceCustomSerializeArrayListFS.Add(alPrimPriceFS);       //優良部品価格(自由検索用)
            retPrimeSetCustomSerializeArrayListFS.Add(alPrimSetFS);           //優良セット(自由検索用)
            retPrimeSetPriceCustomSerializeArrayListFS.Add(alPrimSetPriceFS); //優良セット価格(自由検索用)

            RetCnt = alRetParts.Count;

            return status;
        }
        // 速度改善テスト --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 優良 複数品番検索 呼び出し
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="arrayList"></param>
        /// <param name="alPrimPartsFS"></param>
        /// <param name="alPrimPriceFS"></param>
        /// <param name="alPrimSetFS"></param>
        /// <param name="alPrimSetPriceFS"></param>
        /// <param name="sqlConnection"></param>
        /// <remarks>※パラメータ設定し、別リモートＰＧを呼び出す。</remarks>
        private int GetPrimePartsInfWithSetProc( int blGoodsCode, ArrayList arrayList, ref ArrayList alPrimPartsFS, ref ArrayList alPrimPriceFS, ref ArrayList alPrimSetFS, ref ArrayList alPrimSetPriceFS, ref SqlConnection sqlConnection )
        {
            PrimePartsInfDB primePartsInfDB = new PrimePartsInfDB();

            ArrayList paraWorkList = new ArrayList();

            # region [抽出条件リストの設定]
            // 品番・メーカーリスト
            foreach ( OfrPrtsSrchCndWork cndWork in arrayList )
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = cndWork.MakerCode;
                ofrPartsCondWork.PrtsNo = cndWork.PrtsNo;
                paraWorkList.Add( ofrPartsCondWork );
            }
            # endregion

            return primePartsInfDB.GetPrimePartsInfForFreeSearch( blGoodsCode, paraWorkList, out alPrimPartsFS, out alPrimPriceFS, out alPrimSetFS, out alPrimSetPriceFS, sqlConnection );
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        /// <summary>
        /// 部品の検索(PM.NS)
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Programmer : 99033　岩本　勇</br>
        /// <br>Date       : 2006.11.14</br>
        private int SearchPartsInf(GetPartsInfPara InPara, ref ArrayList alRetParts, ref List<PartsModelLnkWork> partsModelLnkWork, ref SqlConnection sqlConnection)
        {

            ArrayList RetInf = new ArrayList();
            ArrayList RetEquip = new ArrayList();

            alcolorwk = new ArrayList();
            altrimwk = new ArrayList();
            alequipwk = new ArrayList();

            //部品絞り　0:生産年式,1;車台番号
            PartsNarrowingCode = 0;
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            try
            {
                if ( (InPara.MakerCode != 0) && (InPara.ModelCode != 0) )
                    ReadModelNameRF( InPara, ref sqlConnection );
            }
            catch
            {
                // ReadModelNameRFで例外発生した場合は、自由検索型式とみなす。
                // 純正BLコード検索の該当は無しとするが例外エラーにせずに続行する。
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //結果の初期化
            RetInf = new ArrayList();

            try
            {
                //部品検索
                status = SearchPartsInfProc(InPara, ref RetInf, ref sqlConnection);

                if (status == 0)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
                    if ( InPara.PrtsNoWithHyphen == string.Empty && InPara.PrtsNoNoneHyphen == string.Empty )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
                    {
                        //BLコードの検索の場合のみ圧縮を掛ける
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //CompressPartsRec( ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        CompressPartsRec( InPara, ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //基底クラスに例外を渡して処理してもらう
                status = -1;
            }

            alRetParts = RetInf;

            return status;
        }

        // 速度改善テスト -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 部品の検索(PM.NS)
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPartsInfYYYY(GetPartsInfPara InPara, ref ArrayList alRetParts, ref List<PartsModelLnkWork> partsModelLnkWork, ref SqlConnection sqlConnection, List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        {

            ArrayList RetInf = new ArrayList();
            ArrayList RetEquip = new ArrayList();

            alcolorwk = new ArrayList();
            altrimwk = new ArrayList();
            alequipwk = new ArrayList();

            //部品絞り　0:生産年式,1;車台番号
            PartsNarrowingCode = 0;
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            try
            {
                if ((InPara.MakerCode != 0) && (InPara.ModelCode != 0))
                    ReadModelNameRF(InPara, ref sqlConnection);
            }
            catch
            {
                // ReadModelNameRFで例外発生した場合は、自由検索型式とみなす。
                // 純正BLコード検索の該当は無しとするが例外エラーにせずに続行する。
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //結果の初期化
            RetInf = new ArrayList();

            try
            {
                //部品検索
                status = SearchPartsInfProcYYYY(InPara, ref RetInf, ref sqlConnection,foundAutoAnsItemStList);

                if (status == 0)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/16 ADD
                    if (InPara.PrtsNoWithHyphen == string.Empty && InPara.PrtsNoNoneHyphen == string.Empty)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/16 ADD
                    {
                        //BLコードの検索の場合のみ圧縮を掛ける
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //CompressPartsRec( ref RetInf, ref partsModelLnkWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        CompressPartsRec(InPara, ref RetInf, ref partsModelLnkWork);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //基底クラスに例外を渡して処理してもらう
                status = -1;
            }

            alRetParts = RetInf;

            return status;
        }
        // 速度改善テスト --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


        #region [ Query ]
        private const string ctQryBLSearch =
            // --- UPD T.Nishi 2012/01/24 ---------->>>>>
            //       "SELECT "
            //     + "CLGPNOINFORF.OFFERDATERF, "
            //     + "CLGPNOINFORF.TBSPARTSCODERF, "
            //     + "CLGPNOINFORF.TBSPARTSCDDERIVEDNORF, "
            //     + "FIGSHAPENORF, "
            //     + "MODELPRTSADPTYMRF, "
            //     + "MODELPRTSABLSYMRF, "
            //     + "MODELPRTSADPTFRAMENORF, "
            //     + "MODELPRTSABLSFRAMENORF, "
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
            //     //+ "PARTSQTYRF, "
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
            //     + "CLGPNOINFORF.PARTSOPNMRF, "
            //     + "CLGPNOINFORF.STANDARDNAMERF, "
            //     + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
            //     + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
            //     + "PARTSMAINSUBGROUPENORF, "
            //     + "COLDDISTRICTSFLAGRF, "
            //     + "COLORNARROWINGFLAGRF, "
            //     + "TRIMNARROWINGFLAGRF, "
            //     + "EQUIPNARROWINGFLAGRF, "
            //     + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
            //     + "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, "
            //     + "MAKEROFFERPARTSNAMERF, "
            //     + "PARTSPRICERF, "
            //     + "PARTSLAYERCDRF,"
            //     + "PARTSPRICESTDATERF,"
            //     + "MAKEROFFERPARTSKANARF,"
            //     + "OPENPRICEDIVRF,"
            //     + "CLGPNOINFORF.PARTSQTYFORRPRF, "
            //     + "CLGPNOINFORF.PARTSPROPERNORF, "
            //   // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            //     + "CLGPNOINFORF.AUTOESTIMATEPARTSCDRF, "
            //     + "CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF, "
            //   // --- ADD m.suzuki 2011/05/18 ----------<<<<<
            //     + "CLGPNOINDXRF.FULLMODELFIXEDNORF, "
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
            //     + "CARMODELRF.SERIESMODELRF, "
            //     + "CARMODELRF.CATEGORYSIGNMODELRF, "
            //     + "CARMODELRF.EXHAUSTGASSIGNRF, "
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
            //     + "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,"    // 2009/10/23 Add
            //     + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
            //     + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                   "SELECT "
                 + "CLGPNOINFORF.OFFERDATERF, "
                 + "CLGPNOINFORF.TBSPARTSCODERF, "
                 + "CLGPNOINFORF.TBSPARTSCDDERIVEDNORF, "
                 + "CLGPNOINFORF.FIGSHAPENORF, "
                 + "CLGPNOINFORF.MODELPRTSADPTYMRF, "
                 + "CLGPNOINFORF.MODELPRTSABLSYMRF, "
                 + "CLGPNOINFORF.MODELPRTSADPTFRAMENORF, "
                 + "CLGPNOINFORF.MODELPRTSABLSFRAMENORF, "
                 + "CLGPNOINFORF.PARTSOPNMRF, "
                 + "CLGPNOINFORF.STANDARDNAMERF, "
                 + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
                 + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
                 + "CLGPNOINFORF.PARTSMAINSUBGROUPENORF, "
                 + "CLGPNOINFORF.COLDDISTRICTSFLAGRF, "
                 + "CLGPNOINFORF.COLORNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.TRIMNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.EQUIPNARROWINGFLAGRF, "
                 + "CLGPNOINFORF.PARTSQTYFORRPRF, "
                 + "CLGPNOINFORF.PARTSPROPERNORF, "
                 + "CLGPNOINFORF.AUTOESTIMATEPARTSCDRF, "
                 + "CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF, "
                 + "CLGPNOINFORF.PRIMEJOINLNKFLGRF, " // 優良結合連携フラグ // 2013/02/12
                 + "CLGPNOINDXRF.FULLMODELFIXEDNORF ,"
                 + "CARMODELRF.SERIESMODELRF, "
                 + "CARMODELRF.CATEGORYSIGNMODELRF, "
                 + "CARMODELRF.EXHAUSTGASSIGNRF, "
                 // --- ADD 2013/03/27 ---------->>>>>
                 + "CLGPNOINFORF.VINPRODUCESTARTNORF ,"       // VIN生産№(始期)
                 + "CLGPNOINFORF.VINPRODUCEENDNORF ,"         // VIN生産№(終期)
                 // --- ADD 2013/03/27 ----------<<<<<
                 + "ROW_NUMBER() OVER(PARTITION BY "
                   + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "   //カタログ部品メーカーコード
                   + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "   //ハイフン付カタログ部品品番
                   + "CLGPNOINFORF.PARTSQTYFORRPRF, "         //部品ＱＴＹ
                   + "CLGPNOINFORF.STANDARDNAMERF, "          //規格名称
                   + "CLGPNOINFORF.PARTSOPNMRF, "             //部品オプション名称
                   + "CLGPNOINFORF.MODELPRTSADPTYMRF, "       //型式別部品採用年月
                   + "CLGPNOINFORF.MODELPRTSABLSYMRF, "       //型式別部品廃止年月
                   + "CLGPNOINFORF.MODELPRTSADPTFRAMENORF, "  //型式別部品採用車台番号
                   + "CLGPNOINFORF.MODELPRTSABLSFRAMENORF  "  //型式別部品廃止車台番号
                   + "ORDER BY "
                   + "CARMODELRF.SERIESMODELRF, "
                   + "CARMODELRF.CATEGORYSIGNMODELRF, "
                   + "CARMODELRF.EXHAUSTGASSIGNRF, "
                   + "CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, "
                   + "CLGPNOINFORF.CATALOGPARTSMAKERCDRF, "
                   + "CLGPNOINFORF.MODELPRTSADPTYMRF "
                 + ") AS ROWNUM ";  
            // --- UPD T.Nishi 2012/01/24 ----------<<<<<

        private const string ctQryPartsNo =
                   "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                 + "PTMKRPRICERF.MAKERCODERF, "
                 + "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        private const string ctQryPartsNoForFreeSearch =
                   "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                 + "PTMKRPRICERF.MAKERCODERF, "
                 + "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, "
                 + "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ";
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        #endregion

        /// <summary>
        /// ＰＭ用部品検索ロジック
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="RetInf">抽出した部品レコード</param>
        /// <param name="sqlConnection">コネクションクラス</param>
        /// <returns></returns>
        private int SearchPartsInfProc(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            //結果の初期化
            RetInf = new ArrayList();
            //結果のArrayListにいれる作業情報クラス
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //条件フラグ定義
            int BLorPrtsNoflg = 0;//0:ＢＬコード検索　1:品番検索 2:品番曖昧検索
            bool fullmodelfixExists;

            //====BL検索か品番検索かの判定
            if (InPara.PrtsNoWithHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoWithHyphen;
                queryCol = "NEWPRTSNOWITHHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.PrtsNoNoneHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoNoneHyphen;
                queryCol = "NEWPRTSNONONEHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.TbsPartsCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//パラメータ不正
            }

            //====フル型指定番号があるかないかの判定
            int[] full = null;
            if (InPara.FullModelFixedNo != null)
            {
                full = InPara.FullModelFixedNo;
                fullmodelfixExists = true;
            }
            else
            {
                fullmodelfixExists = false;
            }


            // -- DEL 2010/04/19 元に戻す------------------------------->>>
            // 2010/01/25 Add >>>
            // BLコード検索は別メソッドで処理する
            //if (BLorPrtsNoflg == 0) return this.SearchPartsInfProc_BLSearch(InPara, ref RetInf, ref sqlConnection);
            // 2010/01/25 Add <<<
            // -- DEL 2010/04/19 ---------------------------------------<<<

            try
            {
                //●暗号化部品準備処理
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);                

                if (BLorPrtsNoflg == 0) //BLコード検索の場合
                {
                    // --- UPD T.Nishi 2012/01/24 ---------->>>>>
                    /*
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    selectstr = ctQryBLSearch;

                    // -- UPD 2010/11/02 ------------------------------->>>
                    //// --  UPD 2010/06/14 ------------------------------->>>
                    ////fromstr = "FROM CLGPNOINFORF ";
                    //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    //// --  UPD 2010/06/14 -------------------------------<<<

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        //優良結合連携マスタの参照が必要ある場合
                        // 2010/11/22 >>>
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        // 2010/11/22 <<<
                    }
                    else
                    {
                        fromstr = "FROM CLGPNOINFORF ";
                    }
                    // -- UPD 2010/11/02 -------------------------------<<<
                    fromstr += "LEFT OUTER JOIN CLGPTNOEXCRF ON ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    // -- UPD 2010/06/14 -------------------------------------------->>>
                    //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
                    // -- UPD 2010/06/14 --------------------------------------------<<<
                    fromstr += "AND CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (CLGPNOINFORF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    // 2009/10/23 >>>
                    //fromstr += "AND CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF) ";
                    fromstr += "AND ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";
                    // 2009/10/23 <<<

                    if (fullmodelfixExists)//フル型固定の指示があればIndexをJoinする
                        fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    fromstr += "LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//フル型式の絞りがあるならば
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        //sb.Append(" AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    if (InPara.ProduceTypeOfYear != 0)
                    {
                        wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                        wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                    }
                    // --- UPD m.suzuki 2011/03/07 ---------->>>>>
                    //else if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                    if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                    // --- UPD m.suzuki 2011/03/07 ----------<<<<<
                    {
                        int frameNo = Convert.ToInt32(InPara.ChassisNo);
                        wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                        wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY CLGPNOINFORF.TBSPARTSCODERF, CLGPNOINFORF.FIGSHAPENORF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                    orderstring = " ORDER BY CARMODELRF.SERIESMODELRF, CARMODELRF.CATEGORYSIGNMODELRF, CARMODELRF.EXHAUSTGASSIGNRF, CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                    */

                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    selectstr = "SELECT * FROM (";
                    selectstr += ctQryBLSearch;

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        ////優良結合連携マスタの参照が必要ある場合
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //優良結合連携マスタの参照が必要ある場合
                        //fromstr = "FROM (SELECT * , 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF UNION ALL SELECT * , 1 AS PRIMEJOINLNKFLGRF FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //<<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //優良結合連携マスタの参照が必要ある場合
                        //カタログ部品品番情報マスタに不足している列をダミーとして追加し、優良結合連携マスタとUNIONする
                        //※列順番を合わせないとクエリ実行エラーになる為、
                        // 結合順序を(優良結合連携マスタ)　UNION ALL (カタログ部品品番情報マスタ)に修正
                        fromstr = "FROM (SELECT * , 1 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM PRIMEJOINLNKRF UNION ALL SELECT * , ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM CLGPNOINFORF ) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        //fromstr = "FROM CLGPNOINFORF ";
                        //fromstr = "FROM (SELECT *, 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        //<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //優良結合連携マスタの参照が必要ない場合も
                        //カタログ部品品番情報マスタに不足している列をダミーとして追加する
                        fromstr = "FROM (SELECT *, ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += " FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }

                    fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";
                    fromstr += " LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//フル型式の絞りがあるならば
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    // --- ADD 2013/03/27 ---------->>>>>
                    if (InPara.VinCode != 0)
                    {
                        // VINコード絞込行う場合
                        if (InPara.MakerCode == 80)         // BENZの場合
                        {
                            // ハンドル位置情報を反映
                            // -1の場合は絞込を行わない
                            if (InPara.HandleInfoCd != -1)
                            {
                                wherestr += string.Format(" AND (CARMODELRF.HANDLEINFOCDRF = {0}) ", InPara.HandleInfoCd);
                            }
                            // VIN生産No.範囲を反映
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                        else if (InPara.MakerCode == 81)    // VWの場合
                        {
                            // 生産工場コードとVIN生産No.範囲を反映
                            wherestr += string.Format(" AND (CLGPNOINFORF.PRODUCEFACTORYCDRF IN ('{0}')) ", InPara.ProductionFactoryCd.Trim());
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                    }
                    else
                    {
                        // VINコード絞込行わない場合
                        if (InPara.ProduceTypeOfYear != 0)
                        {
                            wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                            wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                        }
                        if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                        {
                            int frameNo = Convert.ToInt32(InPara.ChassisNo);
                            wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                            wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                        }
                    }
                    // --- ADD 2013/03/27 ----------<<<<<

                    //PARTITION BY句で順番をつけたレコードをROWNUM=1で圧縮する処理
                    wherestr += ") AS SUBTABLE01 ";
                    wherestr += "WHERE ROWNUM = 1 ";

                    string strdum2 = selectstr + fromstr + wherestr ;


                    //上記で作成したクエリをサブクエリとして仮テーブル名Ｂとする
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    //さらに上記で作成したクエリをサブクエリとして、他のテーブルをＪＯＩＮする
                    selectstr =  "SELECT * FROM ( ";
                    selectstr += "SELECT SUBTABLE02.*, ";
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , ";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                    selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                    selectstr += "PTMKRPRICERF.PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF,";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSKANARF,";
                    selectstr += "PTMKRPRICERF.OPENPRICEDIVRF,";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, ";
                    //圧縮条件と同じ条件でPARTITION BYを行う
                    selectstr += "ROW_NUMBER() OVER(PARTITION BY ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";   //カタログ部品メーカーコード
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";   //ハイフン付カタログ部品品番
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";   //ハイフン付最新部品品番
                    selectstr += "SUBTABLE02.PARTSQTYFORRPRF, ";         //部品ＱＴＹ
                    selectstr += "SUBTABLE02.STANDARDNAMERF, ";          //規格名称
                    selectstr += "SUBTABLE02.PARTSOPNMRF, ";             //部品オプション名称
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";       //型式別部品採用年月
                    selectstr += "SUBTABLE02.MODELPRTSABLSYMRF, ";       //型式別部品廃止年月
                    selectstr += "SUBTABLE02.MODELPRTSADPTFRAMENORF, ";  //型式別部品採用車台番号
                    selectstr += "SUBTABLE02.MODELPRTSABLSFRAMENORF  ";  //型式別部品廃止車台番号
                    selectstr += "ORDER BY ";
                    //順序は圧縮処理時の並び順+メーカー+日付
                    selectstr += "SUBTABLE02.SERIESMODELRF, ";
                    selectstr += "SUBTABLE02.CATEGORYSIGNMODELRF, ";
                    selectstr += "SUBTABLE02.EXHAUSTGASSIGNRF, ";
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF DESC, ";          //メーカーコード
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF DESC";         //部品価格適用開始日
                    selectstr += ") AS ROWNUM2 ";
                    selectstr += "FROM (";
                    selectstr += strdum2;
                    selectstr += ") AS SUBTABLE02 ";

                    fromstr =  "LEFT OUTER JOIN CLGPTNOEXCRF ON ( SUBTABLE02.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND SUBTABLE02.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    fromstr += "ON ( PTMKRPRICERF.PARTSPRICEREVCDRF=0 ";  //部品価格改定区分は0固定なので0固定で指定
                    fromstr += "AND  PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ";
                    fromstr += "AND  PTMKRPRICERF.MAKERCODERF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND  PTMKRPRICERF.PARTSPRICESTDATERF <= @PARTSPRICESTDATE) ";  //日付を計上日以前に指定
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (SUBTABLE02.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND ( SUBTABLE02.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";


                    //PARTITION BY句で順番をつけたレコードをROWNUM=1で圧縮する処理
                    wherestr =  ") AS SUBTABLE03 ";
                    wherestr += "WHERE ROWNUM2 = 1 ";

                    orderstring = " ORDER BY SERIESMODELRF, CATEGORYSIGNMODELRF, EXHAUSTGASSIGNRF, CLGPRTSNOWITHHYPHENRF, CATALOGPARTSMAKERCDRF , MODELPRTSADPTYMRF, PARTSPRICESTDATERF ";
                    // --- UPD T.Nishi 2012/01/24 ----------<<<<<

                }
                else //>>>>>>品番検索の場合
                {
                    // Selectコマンド生成(部品名称マスタのJOINリード)＊品番検索の場合は車両の絞りはなし
                    //selectstr = "SELECT Cast(  DecryptByKey(PARTSNAMERF.PARTSNAMERF) AS NVARCHAR(60)  ) AS PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF,MAKERCODERF,NEWPRTSNOWITHHYPHENRF,NEWPRTSNONONEHYPHENRF,PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,PARTSINFOCTRLFLGRF ";
                    selectstr = "SELECT ";
                    if (InPara.SearchType == 1 || InPara.SearchType == 2 || InPara.SearchType == 3)
                        selectstr += "TOP(300) ";

                    #region 品番検索クエリ
                    selectstr += ctQryPartsNo;

                    // -- UPD 2010/06/14 --------------------->>>
                    //fromstr = " FROM PTMKRPRICERF ";
                    fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    // -- UPD 2010/06/14 ---------------------<<<
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                    #endregion
                    switch (InPara.SearchType)
                    {
                        case 0: // 完全一致
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 1: // 前方一致
                            partsNo = originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 2: // 後方一致
                            partsNo = "%" + originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 3: // 曖昧検索
                            partsNo = "%" + originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 4: // ハイフン無し完全一致
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNONONEHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                    }
                    if (InPara.MakerCode != 0)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
                        //wherestr += " AND OFFERDATERF DESC, PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
                        wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

                    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                    // ２輪メーカー除外判定
                    if ( InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0 )
                    {
                        wherestr += " AND NOT ( PTMKRPRICERF.MAKERCODERF BETWEEN @TWOWHEELERMAKERCDST AND @TWOWHEELERMAKERCDED ) ";
                    }
                    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY PTMKRPRICERF.TBSPARTSCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY PTMKRPRICERF.MAKERCODERF, PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF";
                    orderstring = " ORDER BY PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, PTMKRPRICERF.MAKERCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }
                string strdum = selectstr + fromstr + wherestr + orderstring;

                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                SqlParameter findCLGPRTSNOWITHHYPHEN = null;
                SqlParameter findBLCODE = null;
                switch (BLorPrtsNoflg)
                {
                    case 0://BLコード
                        findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//フルモデル番号
                        findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);
                        // --- ADD T.Nishi 2012/01/24 ---------->>>>>
                        ((SqlParameter)sqlCommand.Parameters.Add("@PARTSPRICESTDATE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(ToLongDate(InPara.PriceDate));
                        // --- ADD T.Nishi 2012/01/24 ----------<<<<<
                        break;
                    case 1://品番
                        findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//フルモデル番号
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(partsNo);
                        if (InPara.MakerCode != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                        }
                        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                        if ( InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0 )
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add( "@TWOWHEELERMAKERCDST", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt( InPara.TwoWheelerMakerCdSt );
                            ((SqlParameter)sqlCommand.Parameters.Add( "@TWOWHEELERMAKERCDED", SqlDbType.Int )).Value = SqlDataMediator.SqlSetInt( InPara.TwoWheelerMakerCdEd );
                        }
                        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
                        break;
                }

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    if (BLorPrtsNoflg == 0) // BL検索
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        if (fullmodelfixExists)//フル型固定の指示があればフル型式固定番号取得
                            mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

                        mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
                        mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                        mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
                        mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
                        mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                        mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                        mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                        mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
                        //mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 ADD
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 ADD
                        mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
                        mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
                        mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
                        mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
                        mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                        mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                        // 2009/10/23 Add >>>
                        mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
                        // 2009/10/23 Add <<<
                        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                        mf.AutoEstimatePartsCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AUTOESTIMATEPARTSCDRF" ) );
                        mf.TbsPartsCdDerivedNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNMRF" ) );
                        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                        //>>>2013/02/12
                        mf.PrimeJoinLnkFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEJOINLNKFLGRF"));
                        //<<<2013/02/12

                        // --- ADD 2013/03/27 ---------->>>>>
                        // VINコード絞込有無にかかわらず、「VIN生産№（始期）」・「VIN生産№（終期）」を取得
                        mf.VinProduceStartNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCESTARTNORF"));
                        mf.VinProduceEndNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCEENDNORF"));
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        // 2009/10/23 >>>
                        //mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        // 2009/10/23 <<<
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    }
                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();

                // 古い部品[価格情報のない部品]検索対応
                //>>>>>>>>品番一致検索の場合　部品代替マスタを検索
                //　あいまい検索の場合は古い部品は検索対象外とする。
                if ((BLorPrtsNoflg == 1) && (InPara.SearchType == 0 || InPara.SearchType == 4))// && (InPara.PrtsNoWithHyphen.Trim() != ""))
                {
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSQTYRF,PARTSSUBSTRF.OFFERDATERF, ";
                    selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";

                    fromstr = "FROM PARTSSUBSTRF ";
                    // -- UPD 2010/06/14 ------------------------------------->>>
                    //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    // -- UPD 2010/06/14 -------------------------------------<<<
                    fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    wherestr = " WHERE PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";

                    if (InPara.MakerCode != 0)
                        wherestr += "AND PARTSSUBSTRF.CATALOGPARTSMAKERCDRF = @MAKERCODE";
                    wherestr += " AND PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF=0 ";

                    orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,";
                    orderstring += "PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";
                    strdum = selectstr + " " + fromstr + " " + wherestr + " " + orderstring;

                    sqlCommand = new SqlCommand(strdum, sqlConnection);

                    findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//フルモデル番号
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(originalPartsNo.Trim());
                    if (InPara.MakerCode != 0)
                    {
                        ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        mf = new RetPartsInf();

                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        RetInf.Add(mf);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
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
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            //暗号化キークローズ
            //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            return status;
        }

        // 速度改善テスト -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// ＰＭ用部品検索ロジック
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="RetInf">抽出した部品レコード</param>
        /// <param name="sqlConnection">コネクションクラス</param>
        /// <returns></returns>
        private int SearchPartsInfProcYYYY(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection, List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        {
            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            //結果の初期化
            RetInf = new ArrayList();
            //結果のArrayListにいれる作業情報クラス
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //条件フラグ定義
            int BLorPrtsNoflg = 0;//0:ＢＬコード検索　1:品番検索 2:品番曖昧検索
            bool fullmodelfixExists;

            //====BL検索か品番検索かの判定
            if (InPara.PrtsNoWithHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoWithHyphen;
                queryCol = "NEWPRTSNOWITHHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.PrtsNoNoneHyphen != string.Empty)
            {
                originalPartsNo = InPara.PrtsNoNoneHyphen;
                queryCol = "NEWPRTSNONONEHYPHENRF";
                BLorPrtsNoflg = 1;
            }
            else if (InPara.TbsPartsCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//パラメータ不正
            }

            //====フル型指定番号があるかないかの判定
            int[] full = null;
            if (InPara.FullModelFixedNo != null)
            {
                full = InPara.FullModelFixedNo;
                fullmodelfixExists = true;
            }
            else
            {
                fullmodelfixExists = false;
            }


            // -- DEL 2010/04/19 元に戻す------------------------------->>>
            // 2010/01/25 Add >>>
            // BLコード検索は別メソッドで処理する
            //if (BLorPrtsNoflg == 0) return this.SearchPartsInfProc_BLSearch(InPara, ref RetInf, ref sqlConnection);
            // 2010/01/25 Add <<<
            // -- DEL 2010/04/19 ---------------------------------------<<<

            try
            {
                //●暗号化部品準備処理

                if (BLorPrtsNoflg == 0) //BLコード検索の場合
                {
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    selectstr = "SELECT * FROM (";
                    selectstr += ctQryBLSearch;

                    if (PrmblCodeCheck(InPara.TbsPartsCode, ref sqlConnection))
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        ////優良結合連携マスタの参照が必要ある場合
                        //fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //優良結合連携マスタの参照が必要ある場合
                        //fromstr = "FROM (SELECT * , 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF UNION ALL SELECT * , 1 AS PRIMEJOINLNKFLGRF FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                        //<<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //優良結合連携マスタの参照が必要ある場合
                        //カタログ部品品番情報マスタに不足している列をダミーとして追加し、優良結合連携マスタとUNIONする
                        //※列順番を合わせないとクエリ実行エラーになる為、
                        // 結合順序を(優良結合連携マスタ)　UNION ALL (カタログ部品品番情報マスタ)に修正
                        fromstr = "FROM (SELECT * , 1 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM PRIMEJOINLNKRF UNION ALL SELECT * , ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += "FROM CLGPNOINFORF ) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        // --- DEL 2013/03/27 ---------->>>>>
                        //>>>2013/02/12
                        //fromstr = "FROM CLGPNOINFORF ";
                        //fromstr = "FROM (SELECT *, 0 AS PRIMEJOINLNKFLGRF FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        //<<2013/02/12
                        // --- DEL 2013/03/27 ----------<<<<<
                        // --- ADD 2013/03/27 ---------->>>>>
                        //優良結合連携マスタの参照が必要ない場合も
                        //カタログ部品品番情報マスタに不足している列をダミーとして追加する
                        fromstr = "FROM (SELECT *, ";
                        fromstr += "NULL AS PRODUCEFACTORYCDRF, ";
                        fromstr += "0 AS VINPRODUCESTARTNORF, ";
                        fromstr += "0 AS VINPRODUCEENDNORF, ";
                        fromstr += "0 AS PRIMEJOINLNKFLGRF ";
                        fromstr += " FROM CLGPNOINFORF) AS CLGPNOINFORF ";
                        // --- ADD 2013/03/27 ----------<<<<<
                    }

                    fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";
                    fromstr += " LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";
                    wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    if (fullmodelfixExists)//フル型式の絞りがあるならば
                    {
                        StringBuilder sb = new StringBuilder(1000);

                        int cnt = full.GetLength(0);
                        for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                        {
                            sb.Append(",");
                            sb.Append(full[lpcnt]);
                        }

                        sb.Append(") ");
                        if (sb.Length > 2)
                        {
                            sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
                        }
                        wherestr += sb.ToString();
                    }
                    // --- ADD 2013/03/27 ---------->>>>>
                    if (InPara.VinCode != 0)
                    {
                        // VINコード絞込行う場合
                        if (InPara.MakerCode == 80)         // BENZの場合
                        {
                            // ハンドル位置情報を反映
                            // -1の場合は絞込を行わない
                            if (InPara.HandleInfoCd != -1)
                            {
                                wherestr += string.Format(" AND (CARMODELRF.HANDLEINFOCDRF = {0}) ", InPara.HandleInfoCd);
                            }
                            // VIN生産No.範囲を反映
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                        else if (InPara.MakerCode == 81)    // VWの場合
                        {
                            // 生産工場コードとVIN生産No.範囲を反映
                            wherestr += string.Format(" AND (CLGPNOINFORF.PRODUCEFACTORYCDRF IN ('{0}')) ", InPara.ProductionFactoryCd.Trim());
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCESTARTNORF = 0 OR CLGPNOINFORF.VINPRODUCESTARTNORF <= {0}) ", InPara.VinCode);
                            wherestr += string.Format(" AND (CLGPNOINFORF.VINPRODUCEENDNORF = 0 OR CLGPNOINFORF.VINPRODUCEENDNORF >= {0}) ", InPara.VinCode);
                        }
                    }
                    else
                    {
                        // VINコード絞込行わない場合
                        if (InPara.ProduceTypeOfYear != 0)
                        {
                            wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
                            wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
                        }
                        if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
                        {
                            int frameNo = Convert.ToInt32(InPara.ChassisNo);
                            wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
                            wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
                        }
                    }
                    // --- ADD 2013/03/27 ----------<<<<<

                    //PARTITION BY句で順番をつけたレコードをROWNUM=1で圧縮する処理
                    wherestr += ") AS SUBTABLE01 ";
                    wherestr += "WHERE ROWNUM = 1 ";

                    string strdum2 = selectstr + fromstr + wherestr;


                    //上記で作成したクエリをサブクエリとして仮テーブル名Ｂとする
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    //さらに上記で作成したクエリをサブクエリとして、他のテーブルをＪＯＩＮする
                    selectstr = "SELECT * FROM ( ";
                    selectstr += "SELECT SUBTABLE02.*, ";
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , ";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                    selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                    selectstr += "PTMKRPRICERF.PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF,";
                    selectstr += "PTMKRPRICERF.MAKEROFFERPARTSKANARF,";
                    selectstr += "PTMKRPRICERF.OPENPRICEDIVRF,";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD ,";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                    selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF, ";
                    //圧縮条件と同じ条件でPARTITION BYを行う
                    selectstr += "ROW_NUMBER() OVER(PARTITION BY ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";   //カタログ部品メーカーコード
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";   //ハイフン付カタログ部品品番
                    selectstr += "CLGPTNOEXCRF.NEWPRTSNOWITHHYPHENRF, ";   //ハイフン付最新部品品番
                    selectstr += "SUBTABLE02.PARTSQTYFORRPRF, ";         //部品ＱＴＹ
                    selectstr += "SUBTABLE02.STANDARDNAMERF, ";          //規格名称
                    selectstr += "SUBTABLE02.PARTSOPNMRF, ";             //部品オプション名称
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";       //型式別部品採用年月
                    selectstr += "SUBTABLE02.MODELPRTSABLSYMRF, ";       //型式別部品廃止年月
                    selectstr += "SUBTABLE02.MODELPRTSADPTFRAMENORF, ";  //型式別部品採用車台番号
                    selectstr += "SUBTABLE02.MODELPRTSABLSFRAMENORF  ";  //型式別部品廃止車台番号
                    selectstr += "ORDER BY ";
                    //順序は圧縮処理時の並び順+メーカー+日付
                    selectstr += "SUBTABLE02.SERIESMODELRF, ";
                    selectstr += "SUBTABLE02.CATEGORYSIGNMODELRF, ";
                    selectstr += "SUBTABLE02.EXHAUSTGASSIGNRF, ";
                    selectstr += "SUBTABLE02.CLGPRTSNOWITHHYPHENRF, ";
                    selectstr += "SUBTABLE02.CATALOGPARTSMAKERCDRF, ";
                    selectstr += "SUBTABLE02.MODELPRTSADPTYMRF, ";
                    selectstr += "SEARCHPRTNMRF.CARMAKERCODERF DESC, ";          //メーカーコード
                    selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF DESC";         //部品価格適用開始日
                    selectstr += ") AS ROWNUM2 ";
                    selectstr += "FROM (";
                    selectstr += strdum2;
                    selectstr += ") AS SUBTABLE02 ";

                    fromstr = "LEFT OUTER JOIN CLGPTNOEXCRF ON ( SUBTABLE02.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND SUBTABLE02.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
                    fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    fromstr += "ON ( PTMKRPRICERF.PARTSPRICEREVCDRF=0 ";  //部品価格改定区分は0固定なので0固定で指定
                    fromstr += "AND  PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ";
                    fromstr += "AND  PTMKRPRICERF.MAKERCODERF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
                    fromstr += "AND  PTMKRPRICERF.PARTSPRICESTDATERF <= @PARTSPRICESTDATE) ";  //日付を計上日以前に指定
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (SUBTABLE02.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND ( SUBTABLE02.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";


                    //PARTITION BY句で順番をつけたレコードをROWNUM=1で圧縮する処理
                    wherestr = ") AS SUBTABLE03 ";
                    wherestr += "WHERE ROWNUM2 = 1 ";

                    orderstring = " ORDER BY SERIESMODELRF, CATEGORYSIGNMODELRF, EXHAUSTGASSIGNRF, CLGPRTSNOWITHHYPHENRF, CATALOGPARTSMAKERCDRF , MODELPRTSADPTYMRF, PARTSPRICESTDATERF ";
                    // --- UPD T.Nishi 2012/01/24 ----------<<<<<

                }
                else //>>>>>>品番検索の場合
                {
                    // Selectコマンド生成(部品名称マスタのJOINリード)＊品番検索の場合は車両の絞りはなし
                    //selectstr = "SELECT Cast(  DecryptByKey(PARTSNAMERF.PARTSNAMERF) AS NVARCHAR(60)  ) AS PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF,MAKERCODERF,NEWPRTSNOWITHHYPHENRF,NEWPRTSNONONEHYPHENRF,PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,PARTSINFOCTRLFLGRF ";
                    selectstr = "SELECT ";
                    if (InPara.SearchType == 1 || InPara.SearchType == 2 || InPara.SearchType == 3)
                        selectstr += "TOP(300) ";

                    #region 品番検索クエリ
                    selectstr += ctQryPartsNo;

                    // -- UPD 2010/06/14 --------------------->>>
                    //fromstr = " FROM PTMKRPRICERF ";
                    fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                    // -- UPD 2010/06/14 ---------------------<<<
                    fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                    #endregion
                    switch (InPara.SearchType)
                    {
                        case 0: // 完全一致
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 1: // 前方一致
                            partsNo = originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 2: // 後方一致
                            partsNo = "%" + originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 3: // 曖昧検索
                            partsNo = "%" + originalPartsNo + "%";
                            wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";
                            break;
                        case 4: // ハイフン無し完全一致
                            partsNo = originalPartsNo;
                            wherestr = " WHERE PTMKRPRICERF.NEWPRTSNONONEHYPHENRF = @CLGPRTSNOWITHHYPHEN ";
                            break;
                    }
                    if (InPara.MakerCode != 0)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
                        //wherestr += " AND OFFERDATERF DESC, PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
                        wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

                    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                    // ２輪メーカー除外判定
                    if (InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0)
                    {
                        wherestr += " AND NOT ( PTMKRPRICERF.MAKERCODERF BETWEEN @TWOWHEELERMAKERCDST AND @TWOWHEELERMAKERCDED ) ";
                    }
                    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                    //orderstring = " ORDER BY PTMKRPRICERF.TBSPARTSCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    //orderstring = " ORDER BY PTMKRPRICERF.MAKERCODERF, PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF";
                    orderstring = " ORDER BY PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, PTMKRPRICERF.MAKERCODERF";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                }
                string strdum = selectstr + fromstr + wherestr + orderstring;

                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                SqlParameter findCLGPRTSNOWITHHYPHEN = null;
                SqlParameter findBLCODE = null;
                switch (BLorPrtsNoflg)
                {
                    case 0://BLコード
                        findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//フルモデル番号
                        findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);
                        // --- ADD T.Nishi 2012/01/24 ---------->>>>>
                        ((SqlParameter)sqlCommand.Parameters.Add("@PARTSPRICESTDATE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(ToLongDate(InPara.PriceDate));
                        // --- ADD T.Nishi 2012/01/24 ----------<<<<<
                        break;
                    case 1://品番
                        findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//フルモデル番号
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(partsNo);
                        if (InPara.MakerCode != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                        }
                        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
                        if (InPara.TwoWheelerMakerExclude && InPara.TwoWheelerMakerCdSt != 0 && InPara.TwoWheelerMakerCdEd != 0)
                        {
                            ((SqlParameter)sqlCommand.Parameters.Add("@TWOWHEELERMAKERCDST", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.TwoWheelerMakerCdSt);
                            ((SqlParameter)sqlCommand.Parameters.Add("@TWOWHEELERMAKERCDED", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.TwoWheelerMakerCdEd);
                        }
                        // --- ADD m.suzuki 2010/06/12 ----------<<<<<
                        break;
                }

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    if (BLorPrtsNoflg == 0) // BL検索
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        if (fullmodelfixExists)//フル型固定の指示があればフル型式固定番号取得
                            mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

                        mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
                        mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                        mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
                        mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
                        mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                        mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                        mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                        mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 DEL
                        //mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.27 ADD
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.27 ADD
                        mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
                        mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
                        mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
                        mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
                        mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                        mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD
                        // 2009/10/23 Add >>>
                        mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
                        // 2009/10/23 Add <<<
                        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                        mf.AutoEstimatePartsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTOESTIMATEPARTSCDRF"));
                        mf.TbsPartsCdDerivedNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNMRF"));
                        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                        //>>>2013/02/12
                        mf.PrimeJoinLnkFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEJOINLNKFLGRF"));
                        //<<<2013/02/12

                        // --- ADD 2013/03/27 ---------->>>>>
                        // VINコード絞込有無にかかわらず、「VIN生産№（始期）」・「VIN生産№（終期）」を取得
                        mf.VinProduceStartNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCESTARTNORF"));
                        mf.VinProduceEndNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VINPRODUCEENDNORF"));
                        // --- ADD 2013/03/27 ----------<<<<<
                    }
                    else
                    {
                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        // 2009/10/23 >>>
                        //mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        // 2009/10/23 <<<
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    }
                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();

                // 古い部品[価格情報のない部品]検索対応
                //>>>>>>>>品番一致検索の場合　部品代替マスタを検索
                //　あいまい検索の場合は古い部品は検索対象外とする。
                if ((BLorPrtsNoflg == 1) && (InPara.SearchType == 0 || InPara.SearchType == 4))// && (InPara.PrtsNoWithHyphen.Trim() != ""))
                {
                    // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                    selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSQTYRF,PARTSSUBSTRF.OFFERDATERF, ";
                    selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSLAYERCDRF,";
                    selectstr += "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";

                    fromstr = "FROM PARTSSUBSTRF ";
                    // -- UPD 2010/06/14 ------------------------------------->>>
                    //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                    // -- UPD 2010/06/14 -------------------------------------<<<
                    fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
                    wherestr = " WHERE PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN ";

                    if (InPara.MakerCode != 0)
                        wherestr += "AND PARTSSUBSTRF.CATALOGPARTSMAKERCDRF = @MAKERCODE";
                    wherestr += " AND PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF=0 ";

                    orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,";
                    orderstring += "PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";
                    strdum = selectstr + " " + fromstr + " " + wherestr + " " + orderstring;

                    sqlCommand = new SqlCommand(strdum, sqlConnection);

                    findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//フルモデル番号
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(originalPartsNo.Trim());
                    if (InPara.MakerCode != 0)
                    {
                        ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                    }

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        mf = new RetPartsInf();

                        mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                        mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                        mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                        mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                        mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                        mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                        mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                        mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                        mf.PartsNarrowingCode = PartsNarrowingCode;
                        mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                        mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        RetInf.Add(mf);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
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
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            //暗号化キークローズ
            //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            return status;
        }

        //private bool isAutoAnswer(List<AutoAnsItemStForOffer> foundAutoAnsItemStList)
        //{
        //    bool existNewGoodsNo = false;
        //    AutoAnsItemStForOffer selectAutoAnsItemSt = new AutoAnsItemStForOffer();

        //    foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
        //    {
        //        if (goods.GoodsMakerCd == row.GoodsMakerCd &&
        //            goods.GoodsNo == row.NewGoodsNo)
        //        {
        //            existNewGoodsNo = true;
        //            // 自動回答品目設定マスタを検索
        //            selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
        //            break;
        //        }
        //    }
        //    // 新品番で見つからない場合、旧品番で検索
        //    if (!existNewGoodsNo)
        //    {
        //        foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
        //        {
        //            if (goods.GoodsMakerCd == row.GoodsMakerCd &&
        //                goods.GoodsNo == row.GoodsNo)
        //            {
        //                // 自動回答品目設定マスタを検索
        //                selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
        //                break;
        //            }
        //        }
        //    }

        //    // 自動回答品目設定マスタに登録がない場合、次の品目へ
        //    if (selectAutoAnsItemSt == null)
        //    {
        //        continue;
        //    }

        //    // 自動回答品目設定マスタ.自動回答区分の判定
        //    bool autoAnswer = false;
        //    if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
        //    {
        //        // ダミー品番でなければ自動回答する
        //        if (trow.PrimeJoinLnkFlg.Equals(0))
        //        {
        //            autoAnswer = true;
        //        }
        //    }

        //}
        // 速度改善テスト --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // -- DEL 2010/11/02 ---------------------------->>>
        #region [未使用のため削除]
        //// 2010/01/25 Add >>>
        ///// <summary>
        ///// ＰＭ用部品検索ロジック（ＢＬコード検索）
        ///// </summary>
        ///// <param name="InPara">条件パラメータ</param>
        ///// <param name="RetInf">抽出した部品レコード</param>
        ///// <param name="sqlConnection">コネクションクラス</param>
        ///// <returns></returns>
        //private int SearchPartsInfProc_BLSearch(GetPartsInfPara InPara, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        //{

        //    SqlDataReader myReader = null;
        //    //SqlEncryptInfo sqlEncriptInfo = null;
        //    //結果の初期化
        //    RetInf = new ArrayList();
        //    //結果のArrayListにいれる作業情報クラス
        //    RetPartsInf mf = null;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    string selectstr = string.Empty;
        //    string fromstr = string.Empty;
        //    string wherestr = string.Empty;
        //    string orderstring = string.Empty;

        //    //条件フラグ定義
        //    bool fullmodelfixExists;

        //    //====フル型指定番号があるかないかの判定
        //    int[] full = null;
        //    if (InPara.FullModelFixedNo != null)
        //    {
        //        full = InPara.FullModelFixedNo;
        //        fullmodelfixExists = true;
        //    }
        //    else
        //    {
        //        fullmodelfixExists = false;
        //    }

        //    const int readCnt = 30;

        //    ArrayList fullModelFixedNoList = new ArrayList();

        //    // フル型式固定番号をreadCntずつに分割
        //    if (fullmodelfixExists)//フル型式の絞りがあるならば
        //    {
        //        StringBuilder sb = new StringBuilder(1000);
        //        int cnt = full.GetLength(0);
        //        for (int lpcnt = 1; lpcnt <= cnt; lpcnt++)
        //        {
        //            sb.Append(",");
        //            sb.Append(full[lpcnt - 1]);

        //            if (( lpcnt % readCnt == 0 ) || ( lpcnt == cnt ))
        //            {
        //                sb.Append(") ");
        //                if (sb.Length > 2)
        //                {
        //                    sb.Remove(0, 1).Insert(0, " AND CLGPNOINDXRF.FULLMODELFIXEDNORF IN (");
        //                }

        //                fullModelFixedNoList.Add(sb.ToString());

        //                sb = new StringBuilder(1000);
        //            }
        //        }
        //    }

        //    if (fullModelFixedNoList.Count == 0)
        //    {
        //        fullModelFixedNoList.Add(""); // ダミー
        //    }

        //    try
        //    {
        //        //●暗号化部品準備処理
        //        //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
        //        //暗号化キーOPEN（SQLExceptionの可能性有り）
        //        //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

        //        for (int index = 0; index < fullModelFixedNoList.Count; index++)
        //        {
        //            // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
        //            selectstr = ctQryBLSearch;

        //            // -- UPD 2010/06/14 ------------------------>>>
        //            //fromstr = "FROM CLGPNOINFORF ";
        //            fromstr = "FROM (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
        //            // -- UPD 2010/06/14 ------------------------<<<
        //            fromstr += "LEFT OUTER JOIN CLGPTNOEXCRF ON ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF ";
        //            fromstr += "AND CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF=CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF ) ";
        //            // -- UPD 2010/06/14 ----------------------------------------------->>>
        //            //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
        //            fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( CLGPTNOEXCRF.CLGPRTSNOWITHHYPHENRF = PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF ";
        //            // -- UPD 2010/06/14 -----------------------------------------------<<<
        //            fromstr += "AND CLGPTNOEXCRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF ) ";
        //            fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (CLGPNOINFORF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        //            fromstr += "AND ( CLGPNOINFORF.CATALOGPARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";

        //            if (fullmodelfixExists)//フル型固定の指示があればIndexをJoinする
        //                fromstr += " LEFT OUTER JOIN CLGPNOINDXRF ON ( CLGPNOINDXRF.PARTSPROPERNORF=CLGPNOINFORF.PARTSPROPERNORF) ";

        //            fromstr += "LEFT OUTER JOIN CARMODELRF ON ( CLGPNOINDXRF.FULLMODELFIXEDNORF=CARMODELRF.FULLMODELFIXEDNORF) ";

        //            wherestr = " WHERE CLGPNOINFORF.TBSPARTSCODERF = @TBSPARTSCODE ";

        //            wherestr += fullModelFixedNoList[index].ToString();

        //            if (InPara.ProduceTypeOfYear != 0)
        //            {
        //                wherestr += string.Format(" AND (MODELPRTSADPTYMRF = 0 OR MODELPRTSADPTYMRF <= {0}) ", InPara.ProduceTypeOfYear);
        //                wherestr += string.Format(" AND (MODELPRTSABLSYMRF = 0 OR MODELPRTSABLSYMRF >= {0}) ", InPara.ProduceTypeOfYear);
        //            }
        //            else if (string.IsNullOrEmpty(InPara.ChassisNo) == false)
        //            {
        //                int frameNo = Convert.ToInt32(InPara.ChassisNo);
        //                wherestr += string.Format(" AND (MODELPRTSADPTFRAMENORF = 0 OR MODELPRTSADPTFRAMENORF <= {0}) ", frameNo);
        //                wherestr += string.Format(" AND (MODELPRTSABLSFRAMENORF = 0 OR MODELPRTSABLSFRAMENORF >= {0}) ", frameNo);
        //            }

        //            orderstring = " ORDER BY CARMODELRF.SERIESMODELRF, CARMODELRF.CATEGORYSIGNMODELRF, CARMODELRF.EXHAUSTGASSIGNRF, CLGPNOINFORF.CLGPRTSNOWITHHYPHENRF, CLGPNOINFORF.CATALOGPARTSMAKERCDRF , CLGPNOINFORF.MODELPRTSADPTYMRF, PTMKRPRICERF.PARTSPRICESTDATERF ";

        //            string strdum = selectstr + fromstr + wherestr + orderstring;

        //            SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

        //            SqlParameter findBLCODE = null;

        //            findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//フルモデル番号
        //            findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.TbsPartsCode);

        //            myReader = sqlCommand.ExecuteReader();

        //            while (myReader.Read())
        //            {
        //                #region 結果のセット
        //                mf = new RetPartsInf();

        //                mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //                mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
        //                mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
        //                mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
        //                mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
        //                mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
        //                mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
        //                mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
        //                mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
        //                mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
        //                mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
        //                mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
        //                mf.PartsNarrowingCode = PartsNarrowingCode;
        //                if (fullmodelfixExists)//フル型固定の指示があればフル型式固定番号取得
        //                    mf.FullModelFixedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNORF"));

        //                mf.FigShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FIGSHAPENORF"));
        //                mf.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
        //                mf.StandardName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDNAMERF"));
        //                mf.ClgPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLGPRTSNOWITHHYPHENRF"));
        //                mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
        //                mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
        //                mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
        //                mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
        //                mf.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYFORRPRF"));
        //                mf.ColdDistrictsFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLDDISTRICTSFLAGRF"));
        //                mf.ColorNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORNARROWINGFLAGRF"));
        //                mf.TrimNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRIMNARROWINGFLAGRF"));
        //                mf.EquipNarrowingFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPNARROWINGFLAGRF"));
        //                mf.PartsUniqueNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));
        //                mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
        //                mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
        //                mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //                mf.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
        //                mf.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
        //                mf.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
        //                mf.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));
        //                RetInf.Add(mf);

        //                #endregion

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (myReader != null && !myReader.IsClosed)
        //                myReader.Close();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null && !myReader.IsClosed)
        //            myReader.Close();
        //    }
        //    //暗号化キークローズ
        //    //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

        //    return status;
        //}
        //// 2010/01/25 Add <<<
        #endregion
        // -- DEL 2010/11/02 ----------------------------<<<

        /// <summary>
        /// 最新品番情報取得（代替などでも取得出来なかった最新品番部品の情報を取得する）
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts">純正部品リスト</param>
        /// <param name="alprtsubst">代替部品リスト</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //private int SearchNewPartsInf(ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        private int SearchNewPartsInf( GetPartsInfPara InPara, ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        {
            int status = 0;
            // 最新品番部品情報が取得されたかチェック
            List<string> lstClgParts = new List<string>();
            int makerCd = ((RetPartsInf)alRetParts[0]).CatalogPartsMakerCd;
            for (int i = 0; i < alRetParts.Count; i++)
            {
                RetPartsInf parts = alRetParts[i] as RetPartsInf;
                for (int j = 0; j < lstClgParts.Count; j++)
                {
                    if (lstClgParts[j] == parts.ClgPrtsNoWithHyphen)
                    {
                        lstClgParts.Remove(parts.ClgPrtsNoWithHyphen);
                        break;
                    }
                }
                if (parts.ClgPrtsNoWithHyphen != parts.NewPrtsNoWithHyphen
                    && lstClgParts.Contains(parts.NewPrtsNoWithHyphen) == false)
                {
                    lstClgParts.Add(parts.NewPrtsNoWithHyphen);
                }
            }
            for (int i = 0; i < alprtsubst.Count; i++)
            {
                for (int j = 0; j < lstClgParts.Count; j++)
                {
                    if (lstClgParts[j] == ((PartsSubstWork)alprtsubst[i]).NewPartsNoWithHyphen)
                    {
                        lstClgParts.RemoveAt(j);
                        break;
                    }
                }
            }
            if (lstClgParts.Count > 0)
            {
                SqlDataReader myReader = null;
                // -- UPD 2010/06/14 ------------------------------------------>>>
                //string query = "SELECT " + ctQryPartsNo + " FROM PTMKRPRICERF "
                string query = "SELECT " + ctQryPartsNo + " FROM PTMKRPRICEPMRF AS PTMKRPRICERF "
                // -- UPD 2010/06/14 ------------------------------------------<<<
                        + "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF "
                        + "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) "
                        + "WHERE PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = @CLGPRTSNOWITHHYPHEN "
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                        //+ "AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        + "AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE "
                        + "AND PTMKRPRICERF.PARTSPRICESTDATERF <= @PRICEDATE "
                        + " ORDER BY PTMKRPRICERF.PARTSPRICESTDATERF DESC ";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);
                SqlParameter findMAKERCODE = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                SqlParameter findPRICEDATE = sqlCommand.Parameters.Add( "@PRICEDATE", SqlDbType.Int );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                try
                {
                    for (int i = 0; i < lstClgParts.Count; i++)
                    {
                        ArrayList RetInf = new ArrayList();
                        GetPartsInfPara search2 = new GetPartsInfPara();
                        findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(lstClgParts[i]);
                        findMAKERCODE.Value = SqlDataMediator.SqlSetInt(makerCd);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                        findPRICEDATE.Value = SqlDataMediator.SqlSetInt( ToLongDate( InPara.PriceDate ) );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

                        myReader = sqlCommand.ExecuteReader();
                        if ( myReader.Read() )
                        {
                            PartsSubstWork mf = new PartsSubstWork();
                            mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                            mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                            mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                            mf.NewPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                            mf.NewPrtsNoNoneHyphen = mf.NewPartsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                            mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                            mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                            mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                            mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                            mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                            mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                            mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                            alprtsubst.Add(mf);
                        }
                        myReader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                    if (sqlCommand != null)
                        sqlCommand.Dispose();
                }
            }
            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>
        /// 日付LongDate取得（条件用）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime date )
        {
            if ( date != DateTime.MinValue )
            {
                return (date.Year * 10000) + (date.Month * 100) + date.Day;
            }
            else
            {
                return 99991231; // 9999.12.31
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        #endregion

        #region [ SearchTbsCodeInfo ]

        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">フル型式固定番号配列</param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo(int[] FullModelFixedNos, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //戻り結果初期化

            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //status = SearchTbsCodeInfoProc(FullModelFixedNos, ref PartsNameWorks);  //部品サーチ
            status = SearchTbsCodeInfoProc( FullModelFixedNos, 0, ref PartsNameWorks );  //部品サーチ
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            return status;
        }
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">フル型式固定番号配列</param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo( int[] FullModelFixedNos, int blCode, ref object PartsNameWorks )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //戻り結果初期化
            status = SearchTbsCodeInfoProc( FullModelFixedNos, blCode, ref PartsNameWorks );  //部品サーチ

            return status;
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfo
        /// </summary>
        /// <param name="FullModelFixedNos">フル型式固定番号配列</param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        public int SearchTbsCodeInfo(int[] FullModelFixedNos, ArrayList paraList, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            PartsNameWorks = new object();    //戻り結果初期化
            status = SearchTbsCodeInfoProc(FullModelFixedNos, paraList, ref PartsNameWorks);  //部品サーチ

            return status;
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ----------------------------------<<<<<


        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private int SearchTbsCodeInfoProc(int[] FullModelFixedNos, ref object PartsNameWorks)
        private int SearchTbsCodeInfoProc( int[] FullModelFixedNos, int blCode, ref object PartsNameWorks )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlConnectionInfo sqlConnectioninfo = null;
            SqlConnection sqlConnection = null;

            ArrayList al = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            PartsNameWorks = RetPartsCustomSerializeArrayList;

            try
            {
                sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                StringBuilder fullmodelstr = new StringBuilder();

                if (FullModelFixedNos.GetLength(0) == 0)//パラメータ不正
                {
                    return 99;
                }

                // -- UPD 2010/04/19 -------------------------------------------->>>
                #region [削除]
                //// 2010/01/25 >>>

                //#region 削除
                ////int cnt = FullModelFixedNos.GetLength(0);

                ////fullmodelstr.Append("(");
                ////for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                ////{
                ////    if (lpcnt != 0)
                ////        fullmodelstr.Append(",");

                ////    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                ////}
                ////fullmodelstr.Append(")");

                ////// Selectコマンド生成(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                ////string selectstr = "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                ////selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ";
                ////selectstr += "( SELECT TBSPARTSCODERF FROM CLGPNOINFORF LEFT OUTER JOIN CLGPNOINDXRF ON ";
                ////selectstr += "( CLGPNOINDXRF.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF ) ";
                ////selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullmodelstr.ToString() + " GROUP BY TBSPARTSCODERF) ORDER BY TBSPARTSCODERF";

                ////SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                ////sqlCommand.CommandTimeout = 20;//タイムアウト２０秒に設定　デフォルト５秒

                ////myReader = sqlCommand.ExecuteReader();
                ////while (myReader.Read())
                ////{
                ////    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                ////    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                ////    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                ////    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                ////    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                ////    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                ////    al.Add(mf);

                ////    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                ////}
                //#endregion

                //List<RetTbsPartsCodeWork> searchList = new List<RetTbsPartsCodeWork>();
                //const int readCnt = 30;

                //ArrayList fullModelFixedNoList = new ArrayList();
                //// フル型式固定番号をreadCntずつに分割
                //StringBuilder sb = new StringBuilder(1000);
                //int cnt = FullModelFixedNos.GetLength(0);
                //for (int lpcnt = 1; lpcnt <= cnt; lpcnt++)
                //{
                //    sb.Append(",");
                //    sb.Append(FullModelFixedNos[lpcnt - 1]);

                //    if (( lpcnt % readCnt == 0 ) || ( lpcnt == cnt ))
                //    {
                //        sb.Append(") ");
                //        if (sb.Length > 2)
                //        {
                //            sb.Remove(0, 1).Insert(0, " (");
                //        }

                //        fullModelFixedNoList.Add(sb.ToString());

                //        sb = new StringBuilder(1000);
                //    }
                //}

                //for (int index = 0; index < fullModelFixedNoList.Count; index++)
                //{
                //    string selectstr = "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                //    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ";
                //    selectstr += "( SELECT TBSPARTSCODERF FROM CLGPNOINFORF LEFT OUTER JOIN CLGPNOINDXRF ON ";
                //    selectstr += "( CLGPNOINDXRF.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF ) ";
                //    selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullModelFixedNoList[index].ToString() + " GROUP BY TBSPARTSCODERF) ORDER BY TBSPARTSCODERF";

                //    SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                //    sqlCommand.CommandTimeout = 20;//タイムアウト２０秒に設定　デフォルト５秒

                //    myReader = sqlCommand.ExecuteReader();
                //    while (myReader.Read())
                //    {
                //        RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                //        mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                //        mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                //        mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                //        mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                //        mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                //        searchList.Add(mf);

                //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //    }
                //    if (myReader != null && !myReader.IsClosed)
                //        myReader.Close();       //リーダークローズ
                //}

                //// BLコードの絞り込み
                //List<int> blCodeList = new List<int>();
                //foreach (RetTbsPartsCodeWork mf in searchList)
                //{
                //    if (!blCodeList.Contains(mf.TbsPartsCode))
                //    {
                //        blCodeList.Add(mf.TbsPartsCode);
                //        al.Add(mf);
                //    }
                //}

                //// 2010/01/25 <<<
                #endregion

                int cnt = FullModelFixedNos.GetLength(0);

                fullmodelstr.Append("(");
                for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                {
                    if (lpcnt != 0)
                        fullmodelstr.Append(",");

                    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                }
                fullmodelstr.Append(")");

                string selectstr = "";

                // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                if ( blCode == 0 )
                {
                // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                    //一時テーブル作成
                    selectstr += "SELECT PARTSPROPERNORF INTO #CLGPNOINDXRF_WORK ";
                    selectstr += "FROM CLGPNOINDXRF ";
                    selectstr += "WHERE CLGPNOINDXRF.FULLMODELFIXEDNORF IN " + fullmodelstr.ToString() + " ";
                    selectstr += "GROUP BY PARTSPROPERNORF ";

                    // Selectコマンド生成(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                    selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF IN ( ";
                    selectstr += "SELECT TBSPARTSCODERF FROM #CLGPNOINDXRF_WORK ";
                    //-- UPD 2010/06/14 ------------------------------->>>
                    //selectstr += "LEFT OUTER JOIN CLGPNOINFORF ";
                    // -- UPD 2010/11/22 -------------------------------------->>>
                    //selectstr += "LEFT OUTER JOIN (SELECT * FROM CLGPNOINFORF UNION SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    // --- UPD 2013/03/27 ---------->>>>>
                    //selectstr += "LEFT OUTER JOIN (SELECT * FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    //カタログ部品品番情報マスタに不足している列をダミーとしてUNION ALLする
                    selectstr += "LEFT OUTER JOIN ( SELECT *, ";
                    selectstr += "NULL AS PRODUCEFACTORYCDRF, ";
                    selectstr += "0 AS VINPRODUCESTARTNORF, ";
                    selectstr += "0 AS VINPRODUCEENDNORF ";
                    selectstr += "FROM CLGPNOINFORF UNION ALL SELECT * FROM PRIMEJOINLNKRF) AS CLGPNOINFORF ";
                    // --- UPD 2013/03/27 ----------<<<<<
                    // -- UPD 2010/11/22 --------------------------------------<<<
                    //-- UPD 2010/06/14 -------------------------------<<<
                    selectstr += "ON ( #CLGPNOINDXRF_WORK.PARTSPROPERNORF = CLGPNOINFORF.PARTSPROPERNORF )  ";
                    selectstr += "GROUP BY TBSPARTSCODERF  ";

                    selectstr += ") ORDER BY TBSPARTSCODERF";

                // --- ADD m.suzuki 2010/06/04 ---------->>>>>
                }
                else
                {
                    // Selectコマンド生成(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                    selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                    selectstr += "FROM TBSPARTSCODERF WHERE TBSPARTSCODERF = " + blCode.ToString() + " ";
                    selectstr += "ORDER BY TBSPARTSCODERF";
                }
                // --- ADD m.suzuki 2010/06/04 ----------<<<<<

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandTimeout = 20;//タイムアウト２０秒に設定　デフォルト５秒

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                    al.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // -- UPD 2010/04/19 --------------------------------------------<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();       //リーダークローズ
                sqlConnection.Close();                          //コネクションクローズ
                sqlConnection.Dispose();                        //コネクション破棄
            }

            RetPartsCustomSerializeArrayList.Add(al);           //部品情報

            return status;
        }

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ---------------------------------->>>>>
        /// <summary>
        /// SearchTbsCodeInfoProc
        /// </summary>
        /// <param name="FullModelFixedNos"></param>
        /// <param name="blCode"></param>
        /// <param name="PartsNameWorks"></param>
        /// <returns></returns>
        private int SearchTbsCodeInfoProc(int[] FullModelFixedNos, ArrayList paraList, ref object PartsNameWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlConnectionInfo sqlConnectioninfo = null;
            SqlConnection sqlConnection = null;

            ArrayList al = new ArrayList();

            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            PartsNameWorks = RetPartsCustomSerializeArrayList;

            List<int> paraListWrok = new List<int>((int[])paraList.ToArray(typeof(int)));

            try
            {
                sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                StringBuilder fullmodelstr = new StringBuilder();

                if (FullModelFixedNos.GetLength(0) == 0)//パラメータ不正
                {
                    return 99;
                }

                int cnt = FullModelFixedNos.GetLength(0);

                fullmodelstr.Append("(");
                for (int lpcnt = 0; lpcnt < cnt; lpcnt++)
                {
                    if (lpcnt != 0)
                        fullmodelstr.Append(",");

                    fullmodelstr.Append(FullModelFixedNos[lpcnt].ToString());

                }
                fullmodelstr.Append(")");

                string selectstr = "";

                // Selectコマンド生成(CLGPNOINDXRF,CLGPNOINFORF,offertbspartscoderf)
                selectstr += "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF, EQUIPGENRERF, PRIMESEARCHFLGRF ";
                selectstr += "FROM TBSPARTSCODERF ";

                for (int i = 0; i < paraListWrok.Count; i++)
                {
                    if (i == 0)
                        selectstr += " WHERE ";
                    else
                        selectstr += " OR ";

                    selectstr += " (TBSPARTSCODERF = " + paraListWrok[i].ToString() + ") ";
                }

                selectstr += "ORDER BY TBSPARTSCODERF";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandTimeout = 20;//タイムアウト２０秒に設定　デフォルト５秒

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetTbsPartsCodeWork mf = new RetTbsPartsCodeWork();

                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                    mf.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                    mf.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                    mf.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));

                    al.Add(mf);

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
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();       //リーダークローズ
                sqlConnection.Close();                          //コネクションクローズ
                sqlConnection.Dispose();                        //コネクション破棄
            }

            RetPartsCustomSerializeArrayList.Add(al);           //部品情報

            return status;
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ----------------------------------<<<<<

        #endregion

        #region [ GetPartsInf(純正部品検索)処理用メソッド ]
        /// <summary>
        /// パラメータの設定にて部品情報を取得します。
        /// </summary>
        /// <param name="InPara"></param>		
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された部品の情報を検索します。</br>
        private int ReadModelNameRF(GetPartsInfPara InPara, ref SqlConnection sqlConnection)
        {
            //結果の初期化
            ArrayList RetInf = new ArrayList();

            int status = 0;
            string selectstr = "";

            // Prameterオブジェクトの作成
            SqlParameter findfull = null;
            SqlParameter findparts = null;
            SqlParameter findpartsdiv = null;

            try
            {

                // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                selectstr = "SELECT PARTSNARROWINGCODERF FROM MODELNAMERF "
                        + " WHERE MAKERCODERF=@MAKERCODERF AND MODELCODERF=@MODELCODERF AND MODELSUBCODERF=@MODELSUBCODERF ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                // Prameterオブジェクトの作成
                findfull = sqlCommand.Parameters.Add("@MAKERCODERF", SqlDbType.Int);
                findparts = sqlCommand.Parameters.Add("@MODELCODERF", SqlDbType.Int);
                findpartsdiv = sqlCommand.Parameters.Add("@MODELSUBCODERF", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findfull.Value = SqlDataMediator.SqlSetInt32(InPara.MakerCode);
                findparts.Value = SqlDataMediator.SqlSetInt32(InPara.ModelCode);
                findpartsdiv.Value = SqlDataMediator.SqlSetInt32(InPara.ModelSubCode);

                PartsNarrowingCode = (int)sqlCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
            }

            return status;
        }

        /// <summary>
        /// ｶﾗｰｺｰﾄﾞ条件絞り
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="RetInf">部品リスト</param>
        /// <param name="wkColorWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrColorAll(SerchPartsInfPara InPara, ref ArrayList RetInf, ref ArrayList wkColorWork, ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";


            PartsColorWork ptwk = null;
            try
            {
                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in RetInf)
                {
                    //ｶﾗｰ条件ありで且つ車両選択でｶﾗｰが入力されているなら
                    if ((mf.ColorNarrowingFlag == 1))
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                selectstr = "SELECT COLORCDINFONORF,PARTSPROPERNORF ";

                fromstr = "FROM PRTSCLRINFRF ";

                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();

                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsColorWork();
                    ptwk.ColorCdInfoNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCDINFONORF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkColorWork.Add(ptwk);

                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// ﾄﾘﾑ条件絞り
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="RetInf">部品リスト</param>
        /// <param name="wkTrimWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrTrimAll(SerchPartsInfPara InPara, ref ArrayList RetInf, ref ArrayList wkTrimWork, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";

            PartsTrimWork ptwk = null;
            try
            {
                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in RetInf)
                {
                    //ﾄﾘﾑ条件ありで且つ車両選択でﾄﾘﾑが入力されているなら
                    if (mf.TrimNarrowingFlag == 1)
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                selectstr = "SELECT TRIMCODERF, PARTSPROPERNORF ";

                fromstr = "FROM PRTSTRMINFRF ";

                //COL_PARTSUNIQUENO	= "";
                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();
                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsTrimWork();

                    ptwk.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkTrimWork.Add(ptwk);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// 装備絞り
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="Retinf">装備絞り</param>
        /// <param name="wkEquipWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private void ExtrEquipAll(SerchPartsInfPara InPara, ref ArrayList Retinf, ref ArrayList wkEquipWork, ref SqlConnection sqlConnection)
        {

            SqlDataReader myReader = null;

            int status = 0;
            string selectstr = "";
            string fromstr = "";
            string wherestr = "";

            PartsEquipWork ptwk = null;
            try
            {

                ArrayList alwk = new ArrayList();

                foreach (RetPartsInf mf in Retinf)
                {
                    //ﾄﾘﾑ条件ありで且つ車両選択でﾄﾘﾑが入力されているなら
                    if (mf.EquipNarrowingFlag == 1)
                    {
                        alwk.Add(mf);
                    }
                }

                if (alwk.Count == 0) return;

                // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                selectstr = "SELECT EQUIPMENTGENRECDRF,EQUIPMENTCODERF,PARTSPROPERNORF ";

                fromstr = "FROM PRTSEQPINFRF ";

                //COL_PARTSUNIQUENO
                wherestr = " WHERE PARTSPROPERNORF IN (";

                StringBuilder sb = new StringBuilder();
                List<long> lst = new List<long>();
                foreach (RetPartsInf mf in alwk)
                {
                    if (lst.Contains(mf.PartsUniqueNo) == false)
                    {
                        sb.Append(" , " + mf.PartsUniqueNo.ToString());
                        lst.Add(mf.PartsUniqueNo);
                    }
                }
                sb.Remove(0, 2);
                sb.Append(")");

                wherestr += sb.ToString();

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ptwk = new PartsEquipWork();

                    ptwk.EquipmentCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTCODERF"));
                    ptwk.EquipmentGenreCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPMENTGENRECDRF"));
                    ptwk.PartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPROPERNORF"));

                    wkEquipWork.Add(ptwk);

                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

        }

        /// <summary>
        /// 部品代替抽出
        /// </summary>
        /// <param name="InPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="alprtsubst"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int ExtrPrtsubstAll(GetPartsInfPara InPara, ref ArrayList alRetParts, ref ArrayList alprtsubst, ref SqlConnection sqlConnection)
        {
            int status = 0;

            if (alRetParts.Count == 0)
                return status;

            SqlDataReader myReader = null;

            string selectstr = "";
            string fromstr = "";
            string wherestr = "";
            StringBuilder sbstr = new StringBuilder();
            string orderstring = "";

            PartsSubstWork ptwk = null;
            try
            {
                //SqlEncryptInfo sqlEncriptInfo = null;

                //●暗号化部品準備処理
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "PARTSNAMERF", "CLGPNOINFORF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                // Selectコマンド生成(部品代替、価格マスタのJOINリード)
                // Selectコマンド生成(品番、変換、価格マスタのJOINリード)
                selectstr = "SELECT CATALOGPARTSMAKERCDRF,OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF,NPRTNOWITHHYPNDSPODRRF,";
                selectstr += "PARTSPLURALSUBSTFLGRF,MAINORSUBPARTSDIVCDRF,PARTSQTYRF,PARTSPLURALSUBSTCMNTRF,PLRLSUBNEWPRTNOHYPNRF ,NEWPRTSNONONEHYPHENRF,";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF,TBSPARTSCDDERIVEDNORF,MAKEROFFERPARTSNAMERF,PARTSPRICERF,PARTSPRICESTDATERF,PARTSLAYERCDRF,";
                selectstr += "PARTSSUBSTRF.OFFERDATERF, PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATERF, PTMKRPRICERF.MAKEROFFERPARTSKANARF, PTMKRPRICERF.OPENPRICEDIVRF ";
                //selectstr += "PARTSNAMERF.PARTSNAMERF,PARTSCODERF,PARTSSEARCHCODERF, PARTSNAMERF.OFFERDATERF, PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATERF ";

                fromstr = "FROM PARTSSUBSTRF ";
                // -- UPD 2010/06/14 ----------------------------------------->>>
                //fromstr += " LEFT OUTER JOIN PTMKRPRICERF ON ( PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                fromstr += " LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON ( PARTSSUBSTRF.NEWPARTSNOWITHHYPHENRF=PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF AND ";
                // -- UPD 2010/06/14 -----------------------------------------<<<
                fromstr += "PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=PTMKRPRICERF.MAKERCODERF  ) ";
                //fromstr += " LEFT OUTER JOIN PARTSNAMERF ON ( PARTSNAMERF.TBSPARTSCODERF=PTMKRPRICERF.TBSPARTSCODERF) ";

                wherestr = " WHERE ";

                int firstflg = 0;
                foreach (RetPartsInf mf in alRetParts)
                {
                    if (firstflg != 0)
                        sbstr.Append(" OR ");

                    if (InPara.TbsPartsCode != 0)//BL検索の場合はカタログ品番
                        sbstr.Append(" (PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=" + mf.CatalogPartsMakerCd.ToString() + " AND PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF='" + mf.ClgPrtsNoWithHyphen + "') ");
                    else//品番検索の場合は新品番
                        sbstr.Append(" (PARTSSUBSTRF.CATALOGPARTSMAKERCDRF=" + mf.CatalogPartsMakerCd.ToString() + " AND PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF='" + mf.NewPrtsNoWithHyphen + "') ");

                    firstflg++;
                }

                wherestr += sbstr.ToString();
                orderstring = " ORDER BY PARTSSUBSTRF.CATALOGPARTSMAKERCDRF,PARTSSUBSTRF.OLDPARTSNOWITHHYPHENRF,PARTSSUBSTRF.NPRTNOWITHHYPNDSPODRRF,PARTSSUBSTRF.MAINORSUBPARTSDIVCDRF ";

                SqlCommand sqlCommand = new SqlCommand(selectstr + " " + fromstr + " " + wherestr + orderstring, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    ptwk = new PartsSubstWork();

                    ptwk.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    ptwk.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    ptwk.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    ptwk.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGPARTSMAKERCDRF"));
                    ptwk.MainOrSubPartsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINORSUBPARTSDIVCDRF"));
                    ptwk.NewPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPARTSNOWITHHYPHENRF"));
                    ptwk.NewPrtsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    ptwk.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    ptwk.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    ptwk.OldPartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPARTSNOWITHHYPHENRF"));
                    ptwk.NPrtNoWithHypnDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NPRTNOWITHHYPNDSPODRRF"));
                    //ptwk.PartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSCODERF"));
                    ptwk.PartsInfoCtrlFlg = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSINFOCTRLFLGRF"));
                    ptwk.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    //ptwk.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSNAMERF"));
                    ptwk.PartsPluralSubstCmnt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSPLURALSUBSTCMNTRF"));
                    ptwk.PartsPluralSubstFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPLURALSUBSTFLGRF"));
                    ptwk.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    ptwk.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    ptwk.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );
                    //ptwk.PartsSearchCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHCODERF"));
                    ptwk.PlrlSubNewPrtNoHypn = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PLRLSUBNEWPRTNOHYPNRF"));
                    ptwk.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    ptwk.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    alprtsubst.Add(ptwk);
                }

                //暗号化キークローズ
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 同一部品圧縮処理
        /// </summary>
        /// <param name="RetInf">抽出結果部品レコード</param>
        /// <param name="partsModelLnkWork"></param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //private void CompressPartsRec(ref ArrayList RetInf, ref List<PartsModelLnkWork> partsModelLnkWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        private void CompressPartsRec( GetPartsInfPara InPara, ref ArrayList RetInf, ref List<PartsModelLnkWork> partsModelLnkWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        {
# if DEBUG
            int additionCnt = 0;
# endif

            ArrayList alwk = new ArrayList();
            RetPartsInf rtwk = new RetPartsInf();
            int ariflg = 0;

            foreach (RetPartsInf mf in RetInf)
            {
                if (mf != null)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    RetPartsInf currentInf = null;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    ariflg = 0;
                    foreach (RetPartsInf mf2 in alwk)
                    {
                        if (mf2 != null)
                        {
                            if ((mf.CatalogPartsMakerCd == mf2.CatalogPartsMakerCd) &&
                                (mf.ClgPrtsNoWithHyphen == mf2.ClgPrtsNoWithHyphen) &&
                                (mf.NewPrtsNoWithHyphen == mf2.NewPrtsNoWithHyphen) &&
                                // 2009/11/09 Add >>>
                                ( mf.PartsQty == mf2.PartsQty ) &&
                                ( mf.StandardName == mf2.StandardName ) &&
                                // 2009/11/09 Add <<<
                                (mf.PartsOpNm == mf2.PartsOpNm))
                            {
                                // 2009/11/09 >>>
                                //if (((mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm)) ||
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                                //    ((mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm)) ||
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                                //    ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm)) ||
                                //    ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm)))

                                if ((( ( mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm ) ) ||
                                     ( ( mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm ) && ( mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm ) )) &&
                                    (( ( mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo ) ) ||
                                       ( mf.ModelPrtsAdptFrameNo >= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo <= mf2.ModelPrtsAblsFrameNo ) ))
                               // 2009/11/09 <<<
                                {
                                    for (int lpcnt = 0; lpcnt < partsModelLnkWork.Count; lpcnt++)
                                    {
                                        if (partsModelLnkWork[lpcnt].PartsProperNo == mf2.PartsUniqueNo)
                                        {
                                            partsModelLnkWork[lpcnt].FullModelFixedNos.Add(mf.FullModelFixedNo);
                                            break;
                                        }
                                    }
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                                    if ( (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                                    if ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm))
                                    {
                                        if (mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm)
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                    }
                                    if ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm))
                                    {
                                        if (mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm)
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                                    // 価格情報の更新
                                    if ( (mf2.PartsPriceStDate < mf.PartsPriceStDate) &&
                                         (mf.PartsPriceStDate <= InPara.PriceDate) )
                                    {
                                        mf2.PartsPrice = mf.PartsPrice; // 部品価格
                                        mf2.PartsPriceStDate = mf.PartsPriceStDate; // 部品価格開始日
                                        mf2.OpenPriceDiv = mf.OpenPriceDiv; // オープン価格区分
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                                    // 2009/10/23 Add >>>
                                    // 検索品名の更新（メーカーコード有りを優先
                                    if (mf2.SrchPNmAcqrCarMkrCd == 0 && mf2.SrchPNmAcqrCarMkrCd != mf.SrchPNmAcqrCarMkrCd)
                                    {
                                        mf2.SrchPNmAcqrCarMkrCd = mf.SrchPNmAcqrCarMkrCd;
                                        mf2.PartsName = mf.PartsName;
                                        mf2.PartsNameKana = mf.PartsNameKana;
                                    }
                                    // 2009/10/23 Add <<<

                                    // 2009/11/09 Add >>>
                                    if (( mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo ) && ( mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo ))
                                    {
                                        if (mf.ModelPrtsAdptFrameNo < mf2.ModelPrtsAdptFrameNo)
                                            mf2.ModelPrtsAdptFrameNo = mf.ModelPrtsAdptFrameNo;
                                        if (mf.ModelPrtsAblsFrameNo > mf2.ModelPrtsAblsFrameNo)
                                            mf2.ModelPrtsAblsFrameNo = mf.ModelPrtsAblsFrameNo;
                                    }
                                    // 2009/11/09 Add <<<
                                    ariflg = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //重複していなければalwkにInsert
                    if (ariflg == 0)
                    {
                        PartsModelLnkWork AddData = new PartsModelLnkWork();
                        AddData.FullModelFixedNos = new List<int>();
                        AddData.FullModelFixedNos.Add(mf.FullModelFixedNo);
                        AddData.PartsProperNo = mf.PartsUniqueNo;
                        partsModelLnkWork.Add(AddData);

                        alwk.Add(mf);

# if DEBUG
                        additionCnt++;
# endif

                        if (mf.ColorNarrowingFlag == 1)//部品カラーマスタ用
                        {
                            colorwk wk = new colorwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            alcolorwk.Add(wk);
                        }
                        if (mf.TrimNarrowingFlag == 1)//部品トリムマスタ用
                        {
                            trimwk wk = new trimwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            altrimwk.Add(wk);
                        }
                        if (mf.EquipNarrowingFlag == 1)//部品装備マスタ用
                        {
                            equipwk wk = new equipwk();
                            wk.FIGSHAPENORF = mf.FigShapeNo;
                            wk.FULLMODELFIXEDNORF = mf.FullModelFixedNo;
                            //wk.SHAPENOINSIDEROWNORF = mf.ShapeNoInsideRowNo;
                            wk.TBSPARTSCDDERIVEDNORF = mf.TbsPartsCdDerivedNo;
                            wk.TBSPARTSCODERF = mf.TbsPartsCode;
                            alequipwk.Add(wk);
                        }
                    }
                }
            }
            //圧縮済みArrayListを戻す
            RetInf = alwk;

# if DEBUG
            int aaa = additionCnt;
# endif
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [ 逆引き検索 ]
        /// <summary>
        /// 優良から純正検索
        /// </summary>
        /// <param name="makerCd">優良メーカコード</param>
        /// <param name="partsNo">優良品番(ハイフン付)</param>
        /// <param name="RetInf">純正部品リスト</param>
        /// <returns></returns>
        public int GetGenuineParts(int makerCd, string partsNo, out object RetInf)
        {
            int status = 0;
            ArrayList ret = new ArrayList();
            RetInf = ret;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();
                status = GetGenuinePartsProc(makerCd, partsNo, ref ret, sqlConnection);
            }
            catch
            {
                status = -1;
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
        /// 優良から純正検索
        /// </summary>
        /// <param name="makerCd">優良メーカコード</param>
        /// <param name="partsNo">優良品番(ハイフン付)</param>
        /// <param name="RetInf">純正部品リスト</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetGenuinePartsProc(int makerCd, string partsNo, ref ArrayList RetInf, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT "
                 + "JOINPARTSRF.JOINSOURCEMAKERCODERF, "
                 + "JOINPARTSRF.JOINSOURPARTSNOWITHHRF, "
                 + "PTMKRPRICERF.OFFERDATERF, "
                 + "PTMKRPRICERF.TBSPARTSCODERF, "
                 + "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, "
                 + "PTMKRPRICERF.OFFERDATERF AS PRICEOFFERDATE , "
                //+ "PTMKRPRICERF.MAKERCODERF, "
                //+ "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, "
                 + "PTMKRPRICERF.PARTSPRICERF, "
                 + "PTMKRPRICERF.PARTSLAYERCDRF, "
                 + "PTMKRPRICERF.PARTSPRICESTDATERF, "
                 + "PTMKRPRICERF.MAKEROFFERPARTSKANARF,"
                 + "PTMKRPRICERF.OPENPRICEDIVRF,"
                 + "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, "
                 + "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";

            string fromstr = " FROM JOINPARTSRF ";
            // -- UPD 2010/06/14 ----------------------------------------->>>
            //fromstr += "LEFT OUTER JOIN PTMKRPRICERF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            fromstr += "LEFT OUTER JOIN PTMKRPRICEPMRF AS PTMKRPRICERF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            // -- UPD 2010/06/14 -----------------------------------------<<<
            fromstr += "AND PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
            fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

            //string fromstr = " FROM PTMKRPRICERF ";
            //fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            //fromstr += "INNER JOIN JOINPARTSRF ON PTMKRPRICERF.MAKERCODERF = JOINPARTSRF.JOINSOURCEMAKERCODERF ";
            //fromstr += "AND PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";

            string wherestr = "WHERE JOINPARTSRF.JOINDESTMAKERCDRF = " + makerCd;
            wherestr += " AND JOINPARTSRF.JOINDESTPARTSNORF = '" + partsNo + "'";
            string strdum = selectstr + " " + fromstr + " " + wherestr;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(strdum, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    RetPartsInf mf = new RetPartsInf();

                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    RetInf.Add(mf);

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
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        #endregion

        #region [ 品番複数検索処理 ]
        /// <summary>
        /// 品番複数検索処理
        /// </summary>
        /// <param name="lstSrchCond">条件リスト</param>
        /// <param name="lstRst">純正部品情報リスト</param>
        /// <param name="lstRstPrm">優良部品情報リスト</param>
        /// <param name="lstPrmPrice">優良価格リスト</param>
        /// <returns></returns>
        public int GetOfrPartsInf(ArrayList lstSrchCond,
            out ArrayList lstRst,
            out ArrayList lstRstPrm,
            out ArrayList lstPrmPrice)
        {
            int status = 0;
            lstRst = new ArrayList();
            lstRstPrm = new ArrayList();
            lstPrmPrice = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                if (lstSrchCond == null || lstSrchCond.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();
                status = GetGenuinePartsInfProc(lstSrchCond, lstRst, sqlConnection);
                status = GetPrimePartsInfProc(lstSrchCond, lstRstPrm, lstPrmPrice, sqlConnection);
            }
            catch
            {
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
            return status;
        }

        /// <summary>
        /// 品番複数検索処理[純正]
        /// </summary>
        /// <param name="lstSrchCond">条件リスト</param>
        /// <param name="lstRst">純正部品情報リスト</param>
        /// <param name="sqlConnection">DBコンネクション</param>
        /// <returns></returns>
        private int GetGenuinePartsInfProc(ArrayList lstSrchCond, ArrayList lstRst, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            selectstr += ctQryPartsNo;
            // -- UPD 2010/06/14 ---------------------->>>
            //selectstr += " FROM PTMKRPRICERF ";
            selectstr += " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
            // -- UPD 2010/06/14 ----------------------<<<
            selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            selectstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            foreach (OfrPrtsSrchCndWork wk in lstSrchCond)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                wherestr += "OR ( PTMKRPRICERF.MAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + wk.PrtsNo + "' ) ";
            }
            if (wherestr.Length == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            selectstr += " WHERE" + wherestr.Substring(2); // 先頭のOR除去
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    RetPartsInf mf = new RetPartsInf();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    lstRst.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 品番複数検索処理[優良]
        /// </summary>
        /// <param name="lstSrchCond">条件リスト</param>
        /// <param name="lstRstPrm">優良部品情報リスト</param>
        /// <param name="lstPrmPrice">優良価格リスト</param>
        /// <param name="sqlConnection">DBコンネクション</param>
        /// <returns></returns>
        private int GetPrimePartsInfProc(ArrayList lstSrchCond, ArrayList lstRstPrm, ArrayList lstPrmPrice, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            //[提供優良品番検索]
            selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
            selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
            selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
            selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
            selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF, ";
            selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
            selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
            selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
            selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
            selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
            selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF, ";
            selectstr += "PRMPRTPRICERF.OFFERDATERF AS PRICEOFFERDATERF, ";
            selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // セレクトコード
            selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
            selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
            selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

            selectstr += " FROM PRIMEPARTSRF ";
            selectstr += " LEFT OUTER JOIN PRMPRTPRICERF ON PRIMEPARTSRF.PARTSMAKERCDRF = PRMPRTPRICERF.PARTSMAKERCDRF ";
            selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";
            foreach (OfrPrtsSrchCndWork wk in lstSrchCond)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                wherestr += "OR ( PRIMEPARTSRF.PARTSMAKERCDRF = " + wk.MakerCode + " AND ";
                wherestr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = '" + wk.PrtsNo + "' ) ";
            }
            if (wherestr.Length == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            selectstr += " WHERE " + wherestr.Substring(2); // 先頭のOR除去
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // 優良部品情報
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                    lstRstPrm.Add(mf);

                    // 優良部品価格情報
                    OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();
                    priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    lstPrmPrice.Add(priceWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        #endregion

        #region [ 商品一括登録用メソッド ]
        /// <summary>
        /// 商品一括登録用メソッド
        /// </summary>
        /// <param name="InPara">パラメータ</param>
        /// <param name="RetInf">部品情報戻り</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2009.01.16</br>        
        public int SearchParts(PrtsSrchCndWork InPara, ref object RetInf)
        {
            int status;
            SqlConnection sqlConnection = null;
            CustomSerializeArrayList RetPartsCustomSerializeArrayList = new CustomSerializeArrayList();//部品情報
            RetInf = RetPartsCustomSerializeArrayList;
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (InPara.MakerCode < 100) // 純正メーカーコードか
                {
                    ArrayList lstRetInf = new ArrayList();
                    status = SearchPartsProc(InPara, lstRetInf, sqlConnection);

                    //======結果をCustomSerializeArrayListに代入
                    RetPartsCustomSerializeArrayList.Add(lstRetInf);           //部品情報

                }
                else // 優良メーカーコード処理
                {
                    ArrayList lstRstPrm = new ArrayList();
                    ArrayList lstPrmPrice = new ArrayList();
                    status = SearchPrimePartsProc(InPara, lstRstPrm, lstPrmPrice, sqlConnection);

                    //======結果をCustomSerializeArrayListに代入
                    RetPartsCustomSerializeArrayList.Add(lstRstPrm);           //部品情報
                    RetPartsCustomSerializeArrayList.Add(lstPrmPrice);         //部品情報
                }
            }
            catch
            {
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

            return status;
        }

        /// <summary>
        /// 商品一括登録用検索[純正]
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="RetInf">抽出した部品レコード</param>
        /// <param name="sqlConnection">コネクションクラス</param>
        /// <returns></returns>
        private int SearchPartsProc(PrtsSrchCndWork InPara, ArrayList RetInf, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            //結果のArrayListにいれる作業情報クラス
            RetPartsInf mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;

            //条件フラグ定義
            int BLorPrtsNoflg = 0;//0:ＢＬコード検索　1:品番曖昧検索

            //====BL検索か品番検索かの判定
            if (InPara.PrtsNo != string.Empty)
            {
                if (InPara.PrtsNo.Contains("-"))
                {
                    queryCol = "NEWPRTSNOWITHHYPHENRF";
                }
                else
                {
                    queryCol = "NEWPRTSNONONEHYPHENRF";
                }
                BLorPrtsNoflg = 1;
            }
            else if (InPara.BLCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//パラメータ不正
            }

            try
            {
                selectstr = "SELECT ";
                if (BLorPrtsNoflg == 1 && InPara.MaxCnt > 0)
                {
                    selectstr += string.Format("TOP({0}) ", InPara.MaxCnt);
                }

                #region 品番検索クエリ
                selectstr += ctQryPartsNo;

                // -- UPD 2011/06/23 ----------------->>>
                //// -- UPD 2010/06/14 ----------------->>>
                ////fromstr = " FROM PTMKRPRICERF ";
                //fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF";
                //// -- UPD 2010/06/14 -----------------<<<
                fromstr = " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                // -- UPD 2011/06/23 -----------------<<<
                fromstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                fromstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";

                #endregion

                SqlCommand sqlCommand = new SqlCommand();
                if (BLorPrtsNoflg == 0) // BL検索の場合
                {
                    wherestr = " WHERE PTMKRPRICERF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    SqlParameter findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//BLコード
                    findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.BLCode);
                }
                else if (BLorPrtsNoflg == 1) // 品番検索の場合
                {
                    wherestr = " WHERE PTMKRPRICERF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";

                    SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//品番
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(InPara.PrtsNo + "%");
                }
                if (InPara.MakerCode != 0)
                {
                    wherestr += " AND PTMKRPRICERF.MAKERCODERF = @MAKERCODE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = selectstr + fromstr + wherestr;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    mf = new RetPartsInf();

                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.CatalogPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                    mf.PartsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    mf.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace("-", "");//SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATE"));
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    //mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;// SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    RetInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 商品一括登録用検索[優良]
        /// </summary>
        /// <param name="InPara">条件パラメータ</param>
        /// <param name="lstRstPrm">優良部品情報リスト</param>
        /// <param name="lstPrmPrice">優良価格リスト</param>
        /// <param name="sqlConnection">DBコンネクション</param>
        /// <returns></returns>
        private int SearchPrimePartsProc(PrtsSrchCndWork InPara, ArrayList lstRstPrm, ArrayList lstPrmPrice, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            string selectstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;

            //条件フラグ定義
            int BLorPrtsNoflg = 0;//0:ＢＬコード検索　1:品番曖昧検索

            //====BL検索か品番検索かの判定
            if (InPara.PrtsNo != string.Empty)
            {
                if (InPara.PrtsNo.Contains("-"))
                {
                    queryCol = "PRIMEPARTSNOWITHHRF";
                }
                else
                {
                    queryCol = "PRIMEPARTSNONONEHRF";
                }
                BLorPrtsNoflg = 1;
            }
            else if (InPara.BLCode != 0)
            {
                BLorPrtsNoflg = 0;
            }
            else
            {
                return 99;//パラメータ不正
            }

            try
            {
                selectstr = "SELECT ";

                if (BLorPrtsNoflg == 1 && InPara.MaxCnt > 0)
                {
                    selectstr += string.Format("TOP({0}) ", InPara.MaxCnt);
                }
                //[提供優良品番検索]
                selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF as PRIPRMSETDTLNO1RF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
                selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
                selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF, ";
                selectstr += "PRMPRTPRICERF.OFFERDATERF AS PRICEOFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // セレクトコード
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += " FROM PRIMEPARTSRF ";
                selectstr += " LEFT OUTER JOIN PRMPRTPRICERF ON PRIMEPARTSRF.PARTSMAKERCDRF = PRMPRTPRICERF.PARTSMAKERCDRF ";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";

                SqlCommand sqlCommand = new SqlCommand();
                if (BLorPrtsNoflg == 0) // BL検索の場合
                {
                    wherestr = " WHERE PRIMEPARTSRF.TBSPARTSCODERF = @TBSPARTSCODE ";

                    SqlParameter findBLCODE = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);	//BLコード
                    findBLCODE.Value = SqlDataMediator.SqlSetInt32(InPara.BLCode);
                }
                else if (BLorPrtsNoflg == 1) // 品番検索の場合
                {
                    wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @CLGPRTSNOWITHHYPHEN ";

                    SqlParameter findCLGPRTSNOWITHHYPHEN = sqlCommand.Parameters.Add("@CLGPRTSNOWITHHYPHEN", SqlDbType.NVarChar);	//品番
                    findCLGPRTSNOWITHHYPHEN.Value = SqlDataMediator.SqlSetString(InPara.PrtsNo + "%");
                }
                if (InPara.MakerCode != 0)
                {
                    wherestr += " AND PRIMEPARTSRF.PARTSMAKERCDRF = @MAKERCODE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt(InPara.MakerCode);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = selectstr + wherestr;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // 優良部品情報
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));

                    // ADD 2013/02/14 22013 久保@仕掛一覧対応 No.1742
                    // セレクトコード（PRMSETDTLNO1）を転記していないため、クライアント側でデータが表示されない
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIPRMSETDTLNO1RF"));

                    lstRstPrm.Add(mf);

                    // 優良部品価格情報
                    OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();
                    priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    lstPrmPrice.Add(priceWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        #endregion

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        # region [ 自由検索用メソッド ]
        /// <summary>
        /// 品番複数検索処理[純正]（※自由検索用）
        /// </summary>
        /// <param name="inPara">抽出条件</param>
        /// <param name="lstRst">純正部品情報リスト</param>
        /// <param name="sqlConnection">DBコンネクション</param>
        /// <returns></returns>
        private int GetGenuinePartsInfForFreeSearch( GetPartsInfPara inPara, ArrayList lstRst, SqlConnection sqlConnection )
        {
            ArrayList lstSrchCond = inPara.SearchKeyList;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            string selectstr = "SELECT ";
            string wherestr = string.Empty;
            selectstr += ctQryPartsNoForFreeSearch;

            // -- UPD 2010/06/14 ----------------->>>
            //selectstr += " FROM PTMKRPRICERF ";
            selectstr += " FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
            // -- UPD 2010/06/14 -----------------<<<
            //selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PTMKRPRICERF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (@FINDTBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //selectstr += "AND PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF) ";
            selectstr += "AND ( PTMKRPRICERF.MAKERCODERF = SEARCHPRTNMRF.CARMAKERCODERF OR SEARCHPRTNMRF.CARMAKERCODERF = 0 )) ";
            foreach ( OfrPrtsSrchCndWork wk in lstSrchCond )
            {
                if ( (wk.PrtsNo == string.Empty) || (wk.MakerCode == 0) )
                {
                    continue;
                }

                wherestr += "OR ( PTMKRPRICERF.MAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + wk.PrtsNo + "' ) ";
            }
            if ( wherestr.Length == 0 )
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //selectstr += " WHERE" + wherestr.Substring( 2 ); // 先頭のOR除去
            wherestr = " ( " + wherestr.Substring( 2 ) + " ) "; // 先頭のOR除去
            wherestr += " AND PTMKRPRICERF.PARTSPRICESTDATERF <= @PRICEDATE ";
            selectstr += " WHERE" + wherestr;
            //selectstr += " ORDER BY SRCHPNMACQRCARMKRCD DESC";
            selectstr += " ORDER BY SRCHPNMACQRCARMKRCD DESC, PTMKRPRICERF.PARTSPRICESTDATERF DESC";
            try
            {
                SqlCommand sqlCommand = new SqlCommand( selectstr, sqlConnection );

                SqlParameter findTBSPARTSCODE = sqlCommand.Parameters.Add( "@FINDTBSPARTSCODERF", SqlDbType.Int );
                findTBSPARTSCODE.Value = SqlDataMediator.SqlSetInt( inPara.TbsPartsCode );
                SqlParameter findPRICEDATE = sqlCommand.Parameters.Add( "@PRICEDATE", SqlDbType.Int );
                findPRICEDATE.Value = SqlDataMediator.SqlSetInt( ToLongDate( inPara.PriceDate ) );

                myReader = sqlCommand.ExecuteReader();

                Dictionary<string, int> keyDic = new Dictionary<string, int>();

                while ( myReader.Read() )
                {
                    int srchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SRCHPNMACQRCARMKRCD" ) );
                    int goodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                    string goodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NEWPRTSNOWITHHYPHENRF" ) );

                    string key = CreateDicKeyForFreeSearch( goodsMakerCd, goodsNo );
                    if ( keyDic.ContainsKey( key ) )
                    {
                        continue;
                    }
                    keyDic.Add( key, srchPNmAcqrCarMkrCd );


                    RetPartsInf mf = new RetPartsInf();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );
                    mf.CatalogPartsMakerCd = goodsMakerCd;
                    mf.PartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSFULLNAMERF" ) );
                    mf.PartsNameKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSHALFNAMERF" ) );
                    mf.NewPrtsNoWithHyphen = goodsNo;
                    mf.NewPrtsNoNoneHyphen = mf.NewPrtsNoWithHyphen.Replace( "-", "" );
                    mf.MakerOfferPartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKEROFFERPARTSNAMERF" ) );
                    mf.PartsPrice = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PARTSPRICERF" ) );
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSLAYERCDRF" ) );
                    mf.PriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PRICEOFFERDATE" ) );
                    mf.PartsPriceStDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PARTSPRICESTDATERF" ) );
                    mf.PartsNarrowingCode = PartsNarrowingCode;
                    mf.ClgPrtsNoWithHyphen = mf.NewPrtsNoWithHyphen;
                    mf.MakerOfferPartsKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKEROFFERPARTSKANARF" ) );
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
                    mf.SrchPNmAcqrCarMkrCd = srchPNmAcqrCarMkrCd;

                    lstRst.Add( mf );
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 重複チェックキー生成
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateDicKeyForFreeSearch( int goodsMakerCd, string goodsNo )
        {
            return goodsMakerCd.ToString( "0000" ) + "," + goodsNo.Trim();
        }
        # endregion
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // -- ADD 2010/11/02 -------------------->>>>
        #region [優良結合連携マスタのチェック用]
        /// <summary>
        /// 優良結合連携マスタのチェック
        /// </summary>
        /// <param name="blCode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns>True:該当有り、False:該当無し</returns>
        private bool PrmblCodeCheck(int blCode ,ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            string query = "";
            SqlCommand sqlCommand = null;
            bool flg = false;

            try
            {
                query = "SELECT TOP 1 TBSPARTSCODERF FROM PRIMEJOINLNKRF WHERE TBSPARTSCODERF=@TBSPARTSCODE";

                sqlCommand = new SqlCommand(query, sqlConnection);

                SqlParameter findTbsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                findTbsCode.Value = blCode;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //該当のＢＬコードあり
                    flg = true;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                int status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
            }

            return flg;
        }
        #endregion
        // -- ADD 2010/11/02 --------------------<<<<

    }

    /// <summary>
    /// オファー用自動回答品目設定データクラス
    /// </summary>
    public class AutoAnsItemStForOffer
    {
        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>自動回答区分</summary>
        /// <remarks>0:しない,1:納期,2:価格</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>優先順位</summary>
        private Int32 _priorityOrder;

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>自動回答区分プロパティ</summary>
        /// <value>0:しない,1:納期,2:価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  PriorityOrder
        /// <summary>優先順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorityOrder
        {
            get { return _priorityOrder; }
            set { _priorityOrder = value; }
        }

        /// <summary>
        /// 自動回答品目設定マスタコンストラクタ
        /// </summary>
        /// <returns>AutoAnsItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AutoAnsItemStForOffer()
        {
        }

        /// <summary>
        /// 自動回答品目設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="customerCode">得意先コード(0は全得意先)</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２(※種別コード)</param>
        /// <param name="prmSetDtlName2">優良設定詳細名称２</param>
        /// <param name="autoAnswerDiv">自動回答区分(0:しない,1:納期,2:価格)</param>
        /// <param name="priorityOrder">優先順位</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>AutoAnsItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AutoAnsItemStForOffer(string sectionCode, Int32 customerCode, Int32 goodsMGroup, Int32 bLGoodsCode, Int32 goodsMakerCd, Int32 prmSetDtlNo2, Int32 autoAnswerDiv, Int32 priorityOrder)
        {
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._goodsMGroup = goodsMGroup;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._autoAnswerDiv = autoAnswerDiv;
            this._priorityOrder = priorityOrder;
        }

        /// <summary>
        /// 自動回答品目設定マスタ複製処理
        /// </summary>
        /// <returns>AutoAnsItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAutoAnsItemStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AutoAnsItemStForOffer Clone()
        {
            return new AutoAnsItemStForOffer(this._sectionCode, this._customerCode, this._goodsMGroup, this._bLGoodsCode, this._goodsMakerCd, this._prmSetDtlNo2, this._autoAnswerDiv, this._priorityOrder);
        }

        /// <summary>
        /// 自動回答品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAutoAnsItemStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AutoAnsItemStForOffer target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.AutoAnswerDiv == target.AutoAnswerDiv)
                 && (this.PriorityOrder == target.PriorityOrder));
        }

        /// <summary>
        /// 自動回答品目設定マスタ比較処理
        /// </summary>
        /// <param name="autoAnsItemSt1">
        ///                    比較するAutoAnsItemStクラスのインスタンス
        /// </param>
        /// <param name="autoAnsItemSt2">比較するAutoAnsItemStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AutoAnsItemStForOffer autoAnsItemSt1, AutoAnsItemStForOffer autoAnsItemSt2)
        {
            return ((autoAnsItemSt1.SectionCode == autoAnsItemSt2.SectionCode)
                 && (autoAnsItemSt1.CustomerCode == autoAnsItemSt2.CustomerCode)
                 && (autoAnsItemSt1.GoodsMGroup == autoAnsItemSt2.GoodsMGroup)
                 && (autoAnsItemSt1.BLGoodsCode == autoAnsItemSt2.BLGoodsCode)
                 && (autoAnsItemSt1.GoodsMakerCd == autoAnsItemSt2.GoodsMakerCd)
                 && (autoAnsItemSt1.PrmSetDtlNo2 == autoAnsItemSt2.PrmSetDtlNo2)
                 && (autoAnsItemSt1.AutoAnswerDiv == autoAnsItemSt2.AutoAnswerDiv)
                 && (autoAnsItemSt1.PriorityOrder == autoAnsItemSt2.PriorityOrder)
                 );
        }
        /// <summary>
        /// 自動回答品目設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAutoAnsItemStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AutoAnsItemStForOffer target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.AutoAnswerDiv != target.AutoAnswerDiv) resList.Add("AutoAnswerDiv");
            if (this.PriorityOrder != target.PriorityOrder) resList.Add("PriorityOrder");

            return resList;
        }

        /// <summary>
        /// 自動回答品目設定マスタ比較処理
        /// </summary>
        /// <param name="autoAnsItemSt1">比較するAutoAnsItemStクラスのインスタンス</param>
        /// <param name="autoAnsItemSt2">比較するAutoAnsItemStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AutoAnsItemStForOffer autoAnsItemSt1, AutoAnsItemStForOffer autoAnsItemSt2)
        {
            ArrayList resList = new ArrayList();
            if (autoAnsItemSt1.SectionCode != autoAnsItemSt2.SectionCode) resList.Add("SectionCode");
            if (autoAnsItemSt1.CustomerCode != autoAnsItemSt2.CustomerCode) resList.Add("CustomerCode");
            if (autoAnsItemSt1.GoodsMGroup != autoAnsItemSt2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (autoAnsItemSt1.BLGoodsCode != autoAnsItemSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (autoAnsItemSt1.GoodsMakerCd != autoAnsItemSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (autoAnsItemSt1.PrmSetDtlNo2 != autoAnsItemSt2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (autoAnsItemSt1.AutoAnswerDiv != autoAnsItemSt2.AutoAnswerDiv) resList.Add("AutoAnswerDiv");
            if (autoAnsItemSt1.PriorityOrder != autoAnsItemSt2.PriorityOrder) resList.Add("PriorityOrder");

            return resList;
        }
    }
}

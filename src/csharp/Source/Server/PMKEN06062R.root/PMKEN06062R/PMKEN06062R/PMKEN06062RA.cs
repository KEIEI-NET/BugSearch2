using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ユーザー部品検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー部品検索の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.05</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.19 20056 對馬 大輔 MAX件数指定可能Searchメソッド追加</br>
    /// <br>Update Note: 2009.02.24 20056 對馬 大輔 離島価格情報取得処理追加</br>
    /// <br>Update Note: 2009.04.09 20056 對馬 大輔 仕入先情報取得処理追加</br>
    /// <br>Update Note: 2009/09/04 20056 對馬 大輔 MANTIS[0012224] LogicalMode指定のSearchメソッド追加</br>
    /// <br>Update Note: 2011/01/27 22018 鈴木 正臣 代替する場合は結合検索なしでも結合選択UIが表示されるので抽出を行う</br>
    /// <br>Update Note: 2011/03/17 22008 長内 数馬 ユーザー商品検索時に在庫の取得を行わないメソッドを追加</br>
    /// <br>Update Note: 2011/11/29 30517 夏野 駿希 商品在庫一括登録修正検索時のタイムアウト時間を60秒に延長</br>
    /// <br>Update Note: 2012/05/22 zhangy3 </br>
    /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
    /// <br>             Redmine#29871 売上伝票入力　「*」を使用した品番検索の結果が毎回異なる</br>
    /// <br>Update Note: 2012/09/04 YANGMJ </br>
    /// <br>管理番号   : 10801804-00 </br>
    /// <br>             Redmine#32095 売上伝票入力　商品在庫一括登録修正検索時エラーの修正</br>
    /// <br>Update Note: 2012/12/01 zhangy3 </br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33231 商品在庫マスタの仕様変更</br>
    /// <br>Update Note: 2013/01/24 gezh </br>
    /// <br>             Redmine#33361 商品在庫一括登録修正のサーバー負荷軽減の修正</br>
    /// <br>Update Note: 2013/02/08 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
    /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note: 2013/03/27 huangt</br>
    /// <br>管理番号   : 10801804-00 2013/05/15配信分</br>
    /// <br>           : Redmine#35019 品番検索の結合品の検索のレスポンス低下対策（№1833）</br>
    /// <br>Update Note: K2013/03/18 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
    /// <br>           : Redmine#35071 商品在庫マスタ・山形部品様個別組み込み（#34640残留）</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#34962 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/04/23 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/04/25 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/04/27 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 　「商品在庫一括修正」のサーバー負荷軽減　その２</br>
    /// <br>Update Note: K2013/07/23 凌小青</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>           : Redmine#38624 　商品在庫一括修正の対応（№34962のデグレ）</br>
    /// <br>Update Note: 2013/08/13 田建委</br>
    /// <br>管理番号   : 10902175-00</br>
    /// <br>             Redmine#39794 商品在庫マスタⅡの速度改善</br>
    /// <br>Update Note: K2013/10/08 gezh</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>           : Redmine#38624 　商品在庫一括修正の障害№17対応</br>
    /// <br>Update Note: 2014/01/15 huangt</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#40998 貸出数の変更を可能にするように修正</br>
    /// <br>Update Note: 2014/02/06 湯上 千加子</br>
    /// <br>管理番号   : </br>
    /// <br>           : SCM仕掛一覧№10632対応</br>
    /// <br>Update Note: 2014/02/10 高陽</br>
    /// <br>管理番号   : 10970685-00</br>
    /// <br>           : Redmine#41976 商品マスタⅡの追加</br>
    /// <br>Update Note: 2015/08/17 田建委</br>
    /// <br>管理番号   : 11170052-00</br>
    /// <br>           : Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
    /// <br>Update Note: 2020/06/18 譚洪</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// </remarks>
    [Serializable]
    public class UsrJoinPartsSearchDB : RemoteWithAppLockDB, IUsrJoinPartsSearchDB
    {
        #region [ 検索部 ]
        # region --- ＰＵＢＬＩＣ定義 ---

        # region --- コンストラクタ ---
        /// <summary>
        ///　ユーザー部品検索DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 96186　立花　裕輔</br>
        /// <br>Date       : 2007.03.05</br>
        /// </remarks>
        public UsrJoinPartsSearchDB()
            :
            base("PMKEN06064D", "Broadleaf.Application.Remoting.UsrJoinPartsSearchDB", "JOINPARTSURF")
        {
        }
        # endregion

        # region --- ユーザー部品検索 DBリモートオブジェクト ---

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
        ///// <summary>
        /////ユーザー部品検索DBリモートオブジェクト
        ///// </summary>
        ///// <param name="retObj"></param>
        ///// <param name="searchFlg">検索フラグ</param>
        ///// <param name="searchType"></param>
        ///// <param name="searchCond">検索条件</param>        
        ///// <returns>DB Status</returns>
        //public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond)
        //{
        //    //入出力パラメーター設定
        //    SqlConnection sqlConnection = null;
        //    retObj = null;
        //    try
        //    {
        //        //ＳＱＬ初期処理
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return 99;
        //        sqlConnection.Open();
        //        //--------------------------------

        //        return UserGoodsJoinSearchProc(out retObj, searchFlg, searchType, searchCond, sqlConnection);
        //    }
        //    catch (SqlException ex)
        //    {
        //        return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Dispose();
        //        }
        //    }
        //}
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
        /// <summary>
        ///ユーザー部品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg">検索フラグ</param>
        /// <param name="searchType"></param>
        /// <param name="searchCond">検索条件</param>        
        /// <returns>DB Status</returns>
        public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond)
        {
            return this.UserGoodsJoinSearch(out retObj, searchFlg, searchType, ConstantManagement.LogicalMode.GetData0, searchCond);
        }

        /// <summary>
        /// ユーザー部品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <returns></returns>
        public int UserGoodsJoinSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond)
        {
            //入出力パラメーター設定
            SqlConnection sqlConnection = null;
            retObj = null;
            try
            {
                //ＳＱＬ初期処理
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return 99;
                sqlConnection.Open();
                //--------------------------------

                return UserGoodsJoinSearchProc(out retObj, searchFlg, searchType, logicalMode, searchCond, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD


        #region ユーザー部品検索DBリモートオブジェクト
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー部品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listSearchFlg"></param>
        /// <param name="listSearchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name=listSearchCond"></param>
        /// <returns>ステータス</returns>
        public int UserGoodsJoinSearch(out ArrayList retObj, ArrayList listSearchFlg, ArrayList listSearchType, ConstantManagement.LogicalMode logicalMode, ArrayList listSearchCond)
        {
            //入出力パラメーター設定
            SqlConnection sqlConnection = null;
            retObj = new ArrayList();

            List<UsrSearchFlg> searchFlgList = new List<UsrSearchFlg>();
            List<int> searchTypeList = new List<int>();
            List<object> searchCondList = new List<object>();

            try
            {
                // Listの件数が一致しなければエラー
                if ((searchFlgList.Count == searchTypeList.Count) && 
                    (searchFlgList.Count == searchCondList.Count))
                {
                    //ＳＱＬ初期処理
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return 99;
                    sqlConnection.Open();
                    //--------------------------------

                    UsrSearchFlg searchFlg;
                    int searchType;
                    object searchCond;
                    object retObjTemp;

                    for (int i = 0; i < listSearchFlg.Count; i++)
                    {
                        searchFlg = (UsrSearchFlg)listSearchFlg[i];
                        searchType = (int)listSearchType[i];
                        searchCond = (object)listSearchCond[i];
                        int status = UserGoodsJoinSearchProcForAutoSearch(out retObjTemp, searchFlg, searchType, logicalMode, searchCond, sqlConnection);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (retObjTemp != null)
                            {
                                retObj.Add(retObjTemp);
                            }
                        }
                    }
                }
                return 0;
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
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
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<
        #endregion


        //private int UserGoodsJoinSearchProc(out object retObj, UsrSearchFlg searchFlg, int searchType, object searchCond, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int UserGoodsJoinSearchProc(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;
            try
            {
                string enterpriseCd = string.Empty;
                ArrayList _usrPartsSubstRetWork = null;	        //ユーザー代替マスタリスト
                ArrayList _usrJoinPartsRetWork = null;	        //ユーザー結合マスタリスト
                ArrayList _usrGoodsRetWork = new ArrayList();	//ユーザー商品マスタリスト
                ArrayList _usrSetPartsRetWork = null;           //ユーザーセットマスタリスト

                ArrayList inParts = new ArrayList();            // 商品リスト(ユーザーDBの商品マスタから取得する商品情報のみ)

                ArrayList lstUsrDBSearch = new ArrayList();                // ユーザーDB検索用リスト

                ArrayList outSubst = null;                      // ユーザー代替検索結果リスト
                ArrayList outJoinSubst = null;                  // ユーザー結合代替検索結果リスト
                ArrayList outSetSubst = null;                   // ユーザーセット代替検索結果リスト

                ArrayList searchCondList = searchCond as ArrayList;

                ArrayList usrGoodsRetWorkOfr;                   // ユーザー商品リスト[ 提供分検索結果リスト ]
                ArrayList usrGoodsRetWorkUsr;                   // ユーザー商品リスト[ ユーザー分検索結果リスト ]
                if (searchCondList != null && searchCondList.Count > 0)
                {
                    enterpriseCd = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;

                    UsrPartsNoSearchCondWork cond = searchCondList[0] as UsrPartsNoSearchCondWork;

                    //商品検索処理
                    //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                    searchCondList.RemoveAt(0); // 先頭の検索条件削除

                    lstUsrDBSearch.AddRange(searchCondList);
                    inParts.AddRange(searchCondList);

                    foreach (UsrGoodsRetWork wk in usrGoodsRetWorkOfr)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.GoodsMakerCd;
                        ipa.PrtsNo = wk.GoodsNo;

                        lstUsrDBSearch.Add(ipa);
                    }
                    _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                }
                else
                {
                    #region [ 検索条件がリストでなく、データクラスの場合 - 現在不要(予備機能) ]
                    UsrPartsNoSearchCondWork cond = searchCond as UsrPartsNoSearchCondWork;
                    if (cond != null)
                    {
                        enterpriseCd = cond.EnterpriseCode;
                        lstUsrDBSearch.Add(cond);
                        if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsAndSet)
                        {
                            inParts.Add(cond);
                        }

                        //商品検索処理
                        //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); //2009/09/04 DEL
                        status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                        foreach (UsrGoodsRetWork wk in _usrSetPartsRetWork)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.GoodsMakerCd;
                            ipa.PrtsNo = wk.GoodsNo;
                            inParts.Add(ipa);
                        }
                        _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                    }
                    else
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }
                    #endregion
                }

                // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                ArrayList lstJoinSearch = new ArrayList();
                // --- UPD m.suzuki 2011/01/27 ----------<<<<<

                //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    #region [ [①a]純正品番→代替検索処理 ]
                    //status = UsrPartsSubstMain(inSubst, out outSubst, sqlConnection);
                    status = UsrPartsSubstMain(lstUsrDBSearch, out outSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------

                    foreach (UsrPartsSubstRetWork wk in outSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                        lstJoinSearch.Add( ipa );
                        // --- ADD m.suzuki 2011/01/27 ----------<<<<<
                        lstUsrDBSearch.Add( ipa );
                        inParts.Add(ipa);
                    }
                    #endregion
                }
                if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet)
                {
                    //[②]ユーザー結合検索処理（純正部品、優良部品に対し結合検索する）
                    status = UsrJoinPartsSearch(lstUsrDBSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[①b]結合品番→代替検索処理
                        status = UsrPartsSubstMain(inJoinSubst, out outJoinSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa); // TODO : ユーザー登録分の結合代替に対してセット検索を許すか？
                            inParts.Add(ipa);
                        }
                    }

                } // searchFlgが1のときのみ上記ブロックを実行
                //--------------------------------
                // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                else if ( searchFlg == UsrSearchFlg.UsrPartsAndSet )
                {
                    # region [代替のみの場合も結合選択を表示するので代替先に対する結合先のみ抽出]
                    //[②]ユーザー結合検索処理（純正部品、優良部品に対し結合検索する）
                    status = UsrJoinPartsSearch( lstJoinSearch, out _usrJoinPartsRetWork, sqlConnection );
                    if ( status != 0 )
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach ( UsrJoinPartsRetWork wk in _usrJoinPartsRetWork )
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add( ipa );
                    }
                    lstUsrDBSearch.AddRange( inJoinSubst );
                    inParts.AddRange( inJoinSubst );

                    //[①b]結合品番→代替検索処理
                    status = UsrPartsSubstMain( inJoinSubst, out outJoinSubst, sqlConnection );
                    if ( status != 0 )
                    {
                        return status;
                    }
                    foreach ( UsrPartsSubstRetWork wk in outJoinSubst )
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstUsrDBSearch.Add( ipa );
                        inParts.Add( ipa );
                    }
                    # endregion
                }
                // --- ADD m.suzuki 2011/01/27 ----------<<<<<

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                {
                    ArrayList inSetSubst = new ArrayList();
                    //[④]セット検索処理
                    status = SearchSetParts(lstUsrDBSearch, out _usrSetPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------
                    foreach (UsrSetPartsRetWork wk in _usrSetPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SetSubMakerCd;
                        ipa.PrtsNo = wk.SetSubPartsNo;

                        inSetSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inSetSubst);
                    inParts.AddRange(inSetSubst);

                    //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[①c]セット子の代替検索処理
                        status = UsrPartsSubstMain(inSetSubst, out outSetSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        //部品情報取得処理
                        foreach (UsrPartsSubstRetWork wk in outSetSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa);
                            inParts.Add(ipa);
                        }
                        //--------------------------------
                    }  // searchFlgが1のときのみ上記ブロックを実行
                }

                //[③]部品情報取得処理
                //status = SearchUsrGoods(inParts, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 DEL
                status = SearchUsrGoods(inParts, logicalMode, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 ADD
                _usrGoodsRetWork.AddRange(usrGoodsRetWorkUsr);
                if (status != 0)
                {
                    return status;
                }
                //--------------------------------
                ArrayList _usrGoodsPrice = null;

                status = SearchUsrGoodsPriceProc(lstUsrDBSearch, out _usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                if (status != 0)
                {
                    return status;
                }
                ArrayList _usrGoodsStock = null;
                status = GetStockInfo(lstUsrDBSearch, out _usrGoodsStock, sqlConnection);

                //戻り値の設定
                //if (searchFlg == UsrSearchFlg.UsrPartsAndAll)
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    if (outSubst != null)
                        _usrPartsSubstRetWork = outSubst;
                    if (outJoinSubst != null)
                        _usrPartsSubstRetWork.AddRange(outJoinSubst);
                    if (outSetSubst != null)
                        _usrPartsSubstRetWork.AddRange(outSetSubst);

                    retList.Add(_usrPartsSubstRetWork); // [0] 代替リスト
                }

                // --- UPD m.suzuki 2011/01/27 ---------->>>>>
                //if ( searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet )
                //    retList.Add(_usrJoinPartsRetWork);  // [1] 結合リスト

                if ( searchFlg == UsrSearchFlg.UsrPartsAndAll || 
                     searchFlg == UsrSearchFlg.UsrPartsJoinSet ||
                     (searchFlg == UsrSearchFlg.UsrPartsAndSet && _usrJoinPartsRetWork != null && _usrJoinPartsRetWork.Count > 0) )
                {
                    retList.Add( _usrJoinPartsRetWork );  // [1] 結合リスト
                }
                // --- UPD m.suzuki 2011/01/27 ----------<<<<<

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                    retList.Add(_usrSetPartsRetWork);   // [2] セットリスト
                retList.Add(_usrGoodsRetWork);      // [3] 商品リスト
                retList.Add(_usrGoodsPrice);        // [4] 価格リスト
                retList.Add(_usrGoodsStock);        // [5] 在庫リスト
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                retObj = (object)retList;
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー部品検索DBリモートオブジェクト（自動回答処理用）
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="searchFlg"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="searchCond"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UserGoodsJoinSearchProcForAutoSearch(out object retObj, UsrSearchFlg searchFlg, int searchType, ConstantManagement.LogicalMode logicalMode, object searchCond, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;
            try
            {
                string enterpriseCd = string.Empty;
                ArrayList _usrPartsSubstRetWork = null;	        //ユーザー代替マスタリスト
                ArrayList _usrJoinPartsRetWork = null;	        //ユーザー結合マスタリスト
                ArrayList _usrGoodsRetWork = new ArrayList();	//ユーザー商品マスタリスト
                ArrayList _usrSetPartsRetWork = null;           //ユーザーセットマスタリスト

                ArrayList inParts = new ArrayList();            // 商品リスト(ユーザーDBの商品マスタから取得する商品情報のみ)

                ArrayList lstUsrDBSearch = new ArrayList();                // ユーザーDB検索用リスト

                ArrayList outSubst = null;                      // ユーザー代替検索結果リスト
                ArrayList outJoinSubst = null;                  // ユーザー結合代替検索結果リスト
                ArrayList outSetSubst = null;                   // ユーザーセット代替検索結果リスト

                ArrayList searchCondList = searchCond as ArrayList;

                ArrayList usrGoodsRetWorkOfr;                   // ユーザー商品リスト[ 提供分検索結果リスト ]
                ArrayList usrGoodsRetWorkUsr;                   // ユーザー商品リスト[ ユーザー分検索結果リスト ]
                if (searchCondList != null && searchCondList.Count > 0)
                {
                    enterpriseCd = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;

                    UsrPartsNoSearchCondWork cond = searchCondList[0] as UsrPartsNoSearchCondWork;

                    //商品検索処理
                    //status = SearchUsrGoods(cond, searchType, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); // 2009/09/04 ADD
                    searchCondList.RemoveAt(0); // 先頭の検索条件削除

                    lstUsrDBSearch.AddRange(searchCondList);
                    inParts.AddRange(searchCondList);

                    foreach (UsrGoodsRetWork wk in usrGoodsRetWorkOfr)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.GoodsMakerCd;
                        ipa.PrtsNo = wk.GoodsNo;

                        lstUsrDBSearch.Add(ipa);
                    }
                    _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                }
                else
                {
                    #region [ 検索条件がリストでなく、データクラスの場合 - 現在不要(予備機能) ]
                    UsrPartsNoSearchCondWork cond = searchCond as UsrPartsNoSearchCondWork;
                    if (cond != null)
                    {
                        enterpriseCd = cond.EnterpriseCode;
                        lstUsrDBSearch.Add(cond);
                        if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsAndSet)
                        {
                            inParts.Add(cond);
                        }

                        //商品検索処理
                        status = SearchUsrGoods(cond, searchType, logicalMode, out usrGoodsRetWorkOfr, sqlConnection); 
                        foreach (UsrGoodsRetWork wk in _usrSetPartsRetWork)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.GoodsMakerCd;
                            ipa.PrtsNo = wk.GoodsNo;
                            inParts.Add(ipa);
                        }
                        _usrGoodsRetWork.AddRange(usrGoodsRetWorkOfr);
                    }
                    else
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }
                    #endregion
                }

                ArrayList lstJoinSearch = new ArrayList();

                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    #region [ [①a]純正品番→代替検索処理 ]
                    status = UsrPartsSubstMainForAutoAnswer(lstUsrDBSearch, out outSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    foreach (UsrPartsSubstRetWork wk in outSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstJoinSearch.Add(ipa);
                        lstUsrDBSearch.Add(ipa);
                        inParts.Add(ipa);
                    }
                    #endregion
                }
                if (searchFlg == UsrSearchFlg.UsrPartsAndAll || searchFlg == UsrSearchFlg.UsrPartsJoinSet)
                {
                    //[②]ユーザー結合検索処理（純正部品、優良部品に対し結合検索する）
                    status = UsrJoinPartsSearch(lstUsrDBSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[①b]結合品番→代替検索処理
                        status = UsrPartsSubstMainForAutoAnswer(inJoinSubst, out outJoinSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa); // TODO : ユーザー登録分の結合代替に対してセット検索を許すか？
                            inParts.Add(ipa);
                        }
                    }

                } // searchFlgが1のときのみ上記ブロックを実行
                else if (searchFlg == UsrSearchFlg.UsrPartsAndSet)
                {
                    # region [代替のみの場合も結合選択を表示するので代替先に対する結合先のみ抽出]
                    //[②]ユーザー結合検索処理（純正部品、優良部品に対し結合検索する）
                    status = UsrJoinPartsSearch(lstJoinSearch, out _usrJoinPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }

                    ArrayList inJoinSubst = new ArrayList();
                    foreach (UsrJoinPartsRetWork wk in _usrJoinPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.JoinDestMakerCd;
                        ipa.PrtsNo = wk.JoinDestPartsNo;

                        inJoinSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inJoinSubst);
                    inParts.AddRange(inJoinSubst);

                    //[①b]結合品番→代替検索処理
                    status = UsrPartsSubstMainForAutoAnswer(inJoinSubst, out outJoinSubst, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    foreach (UsrPartsSubstRetWork wk in outJoinSubst)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SubstDestMakerCd;
                        ipa.PrtsNo = wk.SubstDestPartsNo;

                        lstUsrDBSearch.Add(ipa);
                        inParts.Add(ipa);
                    }
                    # endregion
                }

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                {
                    ArrayList inSetSubst = new ArrayList();
                    //[④]セット検索処理
                    status = SearchSetParts(lstUsrDBSearch, out _usrSetPartsRetWork, sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    //--------------------------------
                    foreach (UsrSetPartsRetWork wk in _usrSetPartsRetWork)
                    {
                        UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                        ipa.EnterpriseCode = enterpriseCd;
                        ipa.MakerCode = wk.SetSubMakerCd;
                        ipa.PrtsNo = wk.SetSubPartsNo;

                        inSetSubst.Add(ipa);
                    }
                    lstUsrDBSearch.AddRange(inSetSubst);
                    inParts.AddRange(inSetSubst);

                    if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                    {
                        //[①c]セット子の代替検索処理
                        status = UsrPartsSubstMainForAutoAnswer(inSetSubst, out outSetSubst, sqlConnection);
                        if (status != 0)
                        {
                            return status;
                        }
                        //部品情報取得処理
                        foreach (UsrPartsSubstRetWork wk in outSetSubst)
                        {
                            UsrPartsNoSearchCondWork ipa = new UsrPartsNoSearchCondWork();
                            ipa.EnterpriseCode = enterpriseCd;
                            ipa.MakerCode = wk.SubstDestMakerCd;
                            ipa.PrtsNo = wk.SubstDestPartsNo;

                            lstUsrDBSearch.Add(ipa);
                            inParts.Add(ipa);
                        }
                        //--------------------------------
                    }  // searchFlgが1のときのみ上記ブロックを実行
                }

                //[③]部品情報取得処理
                status = SearchUsrGoods(inParts, logicalMode, out usrGoodsRetWorkUsr, sqlConnection); // 2009/09/04 ADD
                _usrGoodsRetWork.AddRange(usrGoodsRetWorkUsr);
                if (status != 0)
                {
                    return status;
                }
                //--------------------------------
                ArrayList _usrGoodsPrice = null;

                status = SearchUsrGoodsPriceProc(lstUsrDBSearch, out _usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                if (status != 0)
                {
                    return status;
                }
                ArrayList _usrGoodsStock = null;
                status = GetStockInfoForAutoSearch(lstUsrDBSearch, out _usrGoodsStock, sqlConnection);

                //戻り値の設定
                if (searchFlg >= UsrSearchFlg.UsrPartsAndSet)
                {
                    if (outSubst != null)
                        _usrPartsSubstRetWork = outSubst;
                    if (outJoinSubst != null)
                        _usrPartsSubstRetWork.AddRange(outJoinSubst);
                    if (outSetSubst != null)
                        _usrPartsSubstRetWork.AddRange(outSetSubst);

                    retList.Add(_usrPartsSubstRetWork); // [0] 代替リスト
                }


                if (searchFlg == UsrSearchFlg.UsrPartsAndAll ||
                     searchFlg == UsrSearchFlg.UsrPartsJoinSet ||
                     (searchFlg == UsrSearchFlg.UsrPartsAndSet && _usrJoinPartsRetWork != null && _usrJoinPartsRetWork.Count > 0))
                {
                    retList.Add(_usrJoinPartsRetWork);  // [1] 結合リスト
                }

                if (searchFlg != UsrSearchFlg.UsrPartsOnly)
                    retList.Add(_usrSetPartsRetWork);   // [2] セットリスト
                retList.Add(_usrGoodsRetWork);      // [3] 商品リスト
                retList.Add(_usrGoodsPrice);        // [4] 価格リスト
                retList.Add(_usrGoodsStock);        // [5] 在庫リスト
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                retObj = (object)retList;
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>

        // 在庫情報取得処理
        private int GetStockInfo(ArrayList inSetParts, out ArrayList _usrGoodsStock, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inSetParts == null)
            {
                _usrGoodsStock = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                _usrGoodsStock = new ArrayList();
                return 0;
            }

            //メーカーコード・品番 
            ArrayList retList = new ArrayList();
            StockDB stockDB = new StockDB();
            ArrayList stockRetList;
            StockWork stockWk = new StockWork();
            stockWk.EnterpriseCode = ((UsrPartsNoSearchCondWork)(inSetParts[0])).EnterpriseCode;

            foreach (UsrPartsNoSearchCondWork wk in inSetParts)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                stockWk.GoodsMakerCd = wk.MakerCode;
                stockWk.GoodsNo = wk.PrtsNo;
                status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
                if (status == 0)
                {
                    retList.AddRange(stockRetList);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = 0;
                }
            }
            _usrGoodsStock = retList;

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  在庫情報取得処理
        /// </summary>
        /// <param name="inSetParts"></param>
        /// <param name="_usrGoodsStock"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetStockInfoForAutoSearch(ArrayList inSetParts, out ArrayList _usrGoodsStock, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inSetParts == null)
            {
                _usrGoodsStock = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                _usrGoodsStock = new ArrayList();
                return 0;
            }

            //メーカーコード・品番 
            ArrayList retList = new ArrayList();
            StockDB stockDB = new StockDB();
            object stockRetList;
            List<StockWork> stockWkList = new List<StockWork>();


            foreach (UsrPartsNoSearchCondWork wk in inSetParts)
            {
                if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                {
                    continue;
                }

                StockWork stockWk = new StockWork();
                stockWk.EnterpriseCode = wk.EnterpriseCode;
                stockWk.GoodsMakerCd = wk.MakerCode;
                stockWk.GoodsNo = wk.PrtsNo;
                stockWkList.Add(stockWk);
            }

            object objStockWk = stockWkList;

            status = stockDB.SearchStockForAutoSearchProc(out stockRetList, objStockWk, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
            if (status == 0)
            {
                retList.AddRange(stockRetList as ArrayList);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = 0;
            }
            _usrGoodsStock = retList;

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region --- ユーザー商品検索 DBリモートオブジェクト ---
        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
        ///// <summary>
        ///// ユーザー商品検索DBリモートオブジェクト
        ///// </summary>
        ///// <param name="partsNoSearchCondWork">検索条件[1件：曖昧検索　ArrayList：検索]</param>
        ///// <param name="searchType">0:完全一致/1:前方一致/2:後方一致/3:曖昧/4:ハイフン無し完全一致/5:[特殊]結合元検索</param>
        ///// <param name="usrGoodsRetWork"></param>
        ///// <param name="usrGoodsPrice"></param>
        ///// <param name="usrGoodsStock"></param>
        ///// <returns></returns>
        //public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        //{
        //    return UserGoodsSearchProc(partsNoSearchCondWork, searchType, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        //}
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL

        // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
        /// <summary>
        /// ユーザー商品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork">検索条件[1件：曖昧検索　ArrayList：検索]</param>
        /// <param name="searchType">0:完全一致/1:前方一致/2:後方一致/3:曖昧/4:ハイフン無し完全一致/5:[特殊]結合元検索</param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return this.UserGoodsSearch(partsNoSearchCondWork, searchType, ConstantManagement.LogicalMode.GetData0, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }

        /// <summary>
        /// ユーザー商品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(object partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return UserGoodsSearchProc(partsNoSearchCondWork, searchType, logicalMode, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }
        // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー商品検索DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWorkList"></param>
        /// <param name="searchTypeList"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        public int UserGoodsSearch(ArrayList partsNoSearchCondWorkList, ArrayList searchTypeList, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock)
        {
            return UserGoodsSearchProc(partsNoSearchCondWorkList, searchTypeList, logicalMode, out usrGoodsRetWork, out usrGoodsPrice, out usrGoodsStock);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        //private int UserGoodsSearchProc(object partsNoSearchCondWork, int searchType, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) // 2009/09/04 DEL
        private int UserGoodsSearchProc(object partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) // 209/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            usrGoodsRetWork = null;
            usrGoodsPrice = null;
            usrGoodsStock = null;
            SqlConnection sqlConnection = null;

            try
            {
                string enterpriseCode;
                //ＳＱＬ初期処理
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                if (partsNoSearchCondWork is ArrayList)
                {
                    ArrayList searchCondList = partsNoSearchCondWork as ArrayList;
                    enterpriseCode = ((UsrPartsNoSearchCondWork)searchCondList[0]).EnterpriseCode;
                    //商品検索処理
                    //status = SearchUsrGoods(searchCondList, out usrGoodsRetWork, sqlConnection); // 2009/09/04 DEL
                    status = SearchUsrGoods(searchCondList, logicalMode, out usrGoodsRetWork, sqlConnection); // 2009/09/04 ADD
                }
                else if (partsNoSearchCondWork is UsrPartsNoSearchCondWork)
                {
                    if (searchType == 5) // 結合元検索か
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork as UsrPartsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //商品検索処理
                        status = SearchJoinSrcGoods(searchCond, out usrGoodsRetWork, sqlConnection);
                    }
                    else
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork as UsrPartsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //商品検索処理
                        //status = SearchUsrGoods(searchCond, searchType, out usrGoodsRetWork, sqlConnection); // 2009/09/04 DEL
                        status = SearchUsrGoods(searchCond, searchType, logicalMode, out usrGoodsRetWork, sqlConnection); // 2009/09/04 ADD
                    }
                }
                else
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                ArrayList priceList = new ArrayList();
                foreach (UsrGoodsRetWork usrGoodsWork in usrGoodsRetWork)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = enterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                status = GetStockInfo(priceList, out usrGoodsStock, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー商品検索
        /// </summary>
        /// <param name="partsNoSearchCondWorkList"></param>
        /// <param name="searchTypeList"></param>
        /// <param name="logicalMode"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <param name="usrGoodsStock"></param>
        /// <returns></returns>
        private int UserGoodsSearchProc(ArrayList partsNoSearchCondWorkList, ArrayList searchTypeList, ConstantManagement.LogicalMode logicalMode, out ArrayList usrGoodsRetWork, out ArrayList usrGoodsPrice, out ArrayList usrGoodsStock) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            usrGoodsRetWork = null;
            usrGoodsPrice = null;
            usrGoodsStock = null;
            SqlConnection sqlConnection = null;

            ArrayList usrGoodsRetWorkTemp = new ArrayList();
            ArrayList usrGoodsPriceTemp = new ArrayList();
            ArrayList usrGoodsStockTemp = new ArrayList();

            try
            {
                string enterpriseCode;
                //ＳＱＬ初期処理
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                for (int i = 0 ; i < partsNoSearchCondWorkList.Count; i++)
                {
                    UsrPartsNoSearchCondWork partsNoSearchCondWork = partsNoSearchCondWorkList[i] as UsrPartsNoSearchCondWork;
                    int searchType = (int)searchTypeList[i];

                    if (searchType == 5) // 結合元検索か
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //商品検索処理
                        status = SearchJoinSrcGoods(searchCond, out usrGoodsRetWorkTemp, sqlConnection);
                    }
                    else
                    {
                        UsrPartsNoSearchCondWork searchCond = partsNoSearchCondWork;
                        enterpriseCode = searchCond.EnterpriseCode;
                        //商品検索処理
                        status = SearchUsrGoods(searchCond, searchType, logicalMode, out usrGoodsRetWorkTemp, sqlConnection); 
                    }
                    ArrayList priceList = new ArrayList();
                    foreach (UsrGoodsRetWork usrGoodsWork in usrGoodsRetWorkTemp)
                    {
                        UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                        wk.EnterpriseCode = enterpriseCode;
                        wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                        wk.PrtsNo = usrGoodsWork.GoodsNo;
                        priceList.Add(wk);
                    }
                    status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPriceTemp, ConstantManagement.LogicalMode.GetData0, sqlConnection);
                    status = GetStockInfo(priceList, out usrGoodsStockTemp, sqlConnection);

                    usrGoodsRetWork.Add(usrGoodsRetWorkTemp);
                    usrGoodsPrice.Add(usrGoodsPriceTemp);
                    usrGoodsStock.Add(usrGoodsStockTemp);
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region --- ユーザー商品曖昧検索 DBリモートオブジェクト --- [ 不要 ]
#if NoUse
        /// <summary>
        /// ユーザー商品曖昧検索DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="usrGoodsRetWork"></param>
        /// <returns></returns>
        public int GoodsSearch(UsrPartsNoSearchCondWork partsNoSearchCondWork, out ArrayList usrGoodsRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            usrGoodsRetWork = null;
            SqlConnection sqlConnection = null;
            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //商品検索処理
                status = SearchUsrGoods(partsNoSearchCondWork, out usrGoodsRetWork, sqlConnection);
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.GoodsSearch Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
#endif
        # endregion

        /// <summary>
        /// ユーザー価格取得処理
        /// </summary>
        /// <param name="inParts"></param>
        /// <param name="usrGoodsPrice"></param>
        /// <returns></returns>
        public int SearchUsrGoodsPrice(ArrayList inParts, out ArrayList usrGoodsPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入出力パラメーター設定
            usrGoodsPrice = new ArrayList();
            SqlConnection sqlConnection = null;

            try
            {
                //ＳＱＬ初期処理
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return 99;
                sqlConnection.Open();

                //商品検索処理
                status = SearchUsrGoodsPriceProc(inParts, out usrGoodsPrice, ConstantManagement.LogicalMode.GetData0, sqlConnection);

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPriceにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPrice Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 品名取得(全角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name ,0);
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

        private int GetPartsNameProc(int makerCd, string partsNo, out string name ,int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string nameString = "";
            if (mode == 0)
                nameString = "GOODSNAMERF";
            else
                nameString = "GOODSNAMEKANARF";


            string query = "SELECT " + nameString +" GOODSNAMERF FROM GOODSURF "
                         + "WHERE GOODSNORF = @PARTSNO AND GOODSMAKERCDRF = @MAKERCODE ";
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
        //-------- ADD 田建委 2013/02/08 Redmine#34640 ------->>>>>
        /// <summary>
        /// 商品情報によって税率情報LISTを戻ります
        /// </summary>
        /// <param name="work">商品情報</param>
        /// <param name="rateList">戻りリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品情報によって税率情報LISTを戻ります</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        public int GetRateWorkByGood(GoodsUnitDataWork work, out ArrayList rateList)
        {
            RateDB rate = new RateDB();
            return rate.SearchRateByGoodsNoMarker(work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo, out rateList);
        }

        /// <summary>
        /// 前品番・次品番の検索
        /// </summary>
        /// <param name="parmWork">検索条件</param>
        /// <param name="readMode">検索モード（０：前頁；１：次頁）</param>
        /// <param name="goodsList">検索結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 前品番・次品番の検索を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        public int GetPrevNextGoods(GoodsUnitDataWork parmWork, int readMode, out ArrayList goodsList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsList = new ArrayList();
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                status = SearchPrevNextGoods(parmWork, readMode, ref goodsList, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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
        /// 前品番・次品番の検索
        /// </summary>
        /// <param name="parmWork">検索条件</param>
        /// <param name="readMode">検索モード（０：前頁；１：次頁）</param>
        /// <param name="goodsList">検索結果</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 前品番・次品番の検索を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        private int SearchPrevNextGoods(GoodsUnitDataWork parmWork, int readMode, ref ArrayList goodsList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                sqlCommand = new SqlCommand();
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT TOP(1) ").Append(Environment.NewLine);
                sqlText.Append("  GOODSNORF ").Append(Environment.NewLine);
                sqlText.Append("  ,GOODSMAKERCDRF ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  GOODSURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                //企業コード
                sqlText.Append(" ENTERPRISECODERF=@ENTERPRISECODE ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parmWork.EnterpriseCode);
                // 0:前頁 1:次頁
                if (readMode == 0)
                {
                    if (!string.IsNullOrEmpty(parmWork.GoodsNo))
                    {

                        if (parmWork.GoodsMakerCd != 0)
                        {
                            //商品番号
                            sqlText.Append(" AND ((GOODSNORF=@FINDGOODSNO ").Append(Environment.NewLine);

                            //商品メーカーコード
                            sqlText.Append(" AND GOODSMAKERCDRF<@FINDGOODSMAKERCD) ").Append(Environment.NewLine);

                            //商品番号
                            sqlText.Append(" OR (GOODSNORF<@FINDGOODSNO)) ").Append(Environment.NewLine);
                        }
                        else
                        {
                            //商品番号
                            sqlText.Append(" AND GOODSNORF<=@FINDGOODSNO ").Append(Environment.NewLine);
                        }
                    }

                    // ORDER BY
                    sqlText.Append("ORDER BY GOODSNORF DESC,GOODSMAKERCDRF DESC ").Append(Environment.NewLine);
                }
                else
                {
                    if (!string.IsNullOrEmpty(parmWork.GoodsNo))
                    {
                        if (parmWork.GoodsMakerCd != 0)
                        {
                            //商品番号
                            sqlText.Append(" AND ((GOODSNORF=@FINDGOODSNO ").Append(Environment.NewLine);

                            //商品メーカーコード
                            sqlText.Append(" AND GOODSMAKERCDRF>@FINDGOODSMAKERCD) ").Append(Environment.NewLine);

                            //商品番号
                            sqlText.Append(" OR (GOODSNORF>@FINDGOODSNO)) ").Append(Environment.NewLine);
                        }
                        else
                        {
                            //商品番号
                            sqlText.Append(" AND GOODSNORF>=@FINDGOODSNO ").Append(Environment.NewLine);
                        }
                    }

                    // ORDER BY
                    sqlText.Append("ORDER BY GOODSNORF,GOODSMAKERCDRF ").Append(Environment.NewLine);
                }

                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(parmWork.GoodsNo);

                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(parmWork.GoodsMakerCd);

                sqlCommand.CommandText = sqlText.ToString();
                sqlCommand.Connection = sqlConnection;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {

                    al.Add(CopyToGoodsWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsList = al;

            return status;
        }

        /// <summary>
        /// myReader->GoodsUWorkへ格納
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : myReader->GoodsUWorkへ格納を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        private GoodsUWork CopyToGoodsWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUWork goodsResultWork = new GoodsUWork();

            #region クラスへ格納
            goodsResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            goodsResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            #endregion

            return goodsResultWork;
        }
        //-------- ADD 田建委 2013/02/08 Redmine#34640 -------<<<<<
        //-------- ADD 田建委 K2013/03/18 Redmine#35071 ------->>>>>
        /// <summary>
        /// 指定された従業員情報に対して従業員管理情報を追加して戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="unCstChngDiv">原単価修正区分</param>
        /// <param name="stckCntChngDiv">在庫数修正区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された従業員情報に対して従業員管理情報を追加して戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        public int ReadMng(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv)
        {
            try
            {
                unCstChngDiv = 0;
                stckCntChngDiv = 0;

                int status = ReadMngProc(enterpriseCode, employeeCode, out unCstChngDiv, out stckCntChngDiv);

                return status;
            }
            catch (Exception ex)
            {
                unCstChngDiv = 0;
                stckCntChngDiv = 0;
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.ReadMng Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="unCstChngDiv">原単価修正区分</param>
        /// <param name="stckCntChngDiv">在庫数修正区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された従業員情報に対して従業員管理情報を追加して戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        private int ReadMngProc(string enterpriseCode, string employeeCode, out int unCstChngDiv, out int stckCntChngDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            unCstChngDiv = 0;
            stckCntChngDiv = 0;

            try
            {
                //コネクション文字列取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == string.Empty) return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // 従業員管理マスタから情報を取得
                StringBuilder sqlString = new StringBuilder();

                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("	 UNCSTCHNGDIVRF");
                sqlString.AppendLine("	,STCKCNTCHNGDIVRF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	 YMGTEMPLOYEEMNGRF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	    ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND EMPLOYEECODERF = @FINDEMPLOYEECODE");

                sqlCommand.CommandText = sqlString.ToString();

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    unCstChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNCSTCHNGDIVRF"));
                    stckCntChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKCNTCHNGDIVRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        //-------- ADD 田建委 K2013/03/18 Redmine#35071 -------<<<<<
        # endregion

        # region --- ＰＲＩＶＡＴＥ定義 ---

        # region --- 代替検索メイン処理 ---
        /// <summary>
        /// 代替検索メイン処理
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstMain(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = 0;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }

            foreach (UsrPartsNoSearchCondWork condWk in inWork)
            {
                UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork(condWk);

                for (int ix = 1; ix < 11; ix++) // 代替マスタ　：　仕様で最大10世代まで管理するため。
                {
                    if ((usrSearchCondWk.MakerCode == 0) || (string.IsNullOrEmpty(usrSearchCondWk.PrtsNo)))
                    {
                        break;
                    }

                    UsrPartsSubstRetWork _retwork;
                    status = UsrPartsSubstSearch(usrSearchCondWk, out _retwork, sqlConnection);
                    if (status == 0)
                    {
                        _retwork.MakerCode = condWk.MakerCode;
                        _retwork.PrtsNoWithHyphen = condWk.PrtsNo;
                        _retwork.SubstOrder = ix; // 代替順位を設定する。代替順位1は純正を直接代替するもの。2はその代替品を代替するということで10世代までいく。

                        retWork.Add(_retwork);

                        //次世代代替品検索のため、メーカコード、品番を現在の代替品に設定する。
                        usrSearchCondWk.MakerCode = _retwork.SubstDestMakerCd;
                        usrSearchCondWk.PrtsNo = _retwork.SubstDestPartsNo;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = 0;
                        break;
                    }
                    else
                    {
                        return (status);
                    }
                }
            }
            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 代替検索メイン処理（自動回答処理専用）
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstMainForAutoAnswer(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = 0;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }

            Dictionary<int, UsrPartsNoSearchCondWork> inWorkDic = new Dictionary<int, UsrPartsNoSearchCondWork>();
            Dictionary<int, UsrPartsNoSearchCondWork> usrSearchCondWkDic = new Dictionary<int, UsrPartsNoSearchCondWork>();
            string enterpriseCode = string.Empty;

            for (int i = 0; i < inWork.Count; i++)
            {
                UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork();
                usrSearchCondWk = inWork[i] as UsrPartsNoSearchCondWork;
                usrSearchCondWkDic.Add(i, usrSearchCondWk);
                inWorkDic.Add(i, usrSearchCondWk);
                if (i == 0) enterpriseCode = usrSearchCondWk.EnterpriseCode;
            }

            for (int ix = 1; ix < 11; ix++) // 代替マスタ　：　仕様で最大10世代まで管理するため。
            {
                Dictionary<int, UsrPartsSubstRetWork> retWorkList;

                status = UsrPartsSubstSearch(enterpriseCode, usrSearchCondWkDic, out retWorkList, sqlConnection);
                if (status == 0)
                {
                    foreach (int key in retWorkList.Keys)
                    {
                        retWorkList[key].MakerCode = inWorkDic[key].MakerCode;
                        retWorkList[key].PrtsNoWithHyphen = inWorkDic[key].PrtsNo;
                        retWorkList[key].SubstOrder = ix; // 代替順位を設定する。代替順位1は純正を直接代替するもの。2はその代替品を代替するということで10世代までいく。
                    }
                    retWork.AddRange(retWorkList.Values);

                    //次世代代替品検索のため、メーカコード、品番を現在の代替品に設定する。
                    usrSearchCondWkDic.Clear();
                    foreach (int key in retWorkList.Keys)
                    {
                        UsrPartsNoSearchCondWork usrSearchCondWk = new UsrPartsNoSearchCondWork();
                        usrSearchCondWk.MakerCode = retWorkList[key].SubstDestMakerCd;
                        usrSearchCondWk.PrtsNo = retWorkList[key].SubstDestPartsNo;
                        usrSearchCondWkDic.Add(key, usrSearchCondWk);
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = 0;
                    break;
                }
                else
                {
                    return (status);
                }
            }
            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<
        # endregion

        # region --- 代替検索処理 ---

        private const string ctQuerySubst =
                 "SELECT "
                 + " PARTSSUBSTURF.CHGSRCMAKERCDRF, "
                 + " PARTSSUBSTURF.CHGSRCGOODSNORF, "
                 + " PARTSSUBSTURF.CHGDESTMAKERCDRF, "
                 + " PARTSSUBSTURF.CHGDESTGOODSNORF, "
                 + " PARTSSUBSTURF.APPLYSTADATERF, "
                 + " PARTSSUBSTURF.APPLYENDDATERF "
                 + " FROM PARTSSUBSTURF ";

        /// <summary>
        /// 代替検索処理
        /// </summary>
        /// <param name="usrSearchCondWork">検索条件ワーク</param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstSearch(UsrPartsNoSearchCondWork usrSearchCondWork, out UsrPartsSubstRetWork retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQuerySubst;

            retWork = new UsrPartsSubstRetWork();

            try
            {
                //ＷＨＥＲＥＮ項目
                selectstr += "WHERE ENTERPRISECODERF = '" + usrSearchCondWork.EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0";

                //メーカーコード・品番 
                selectstr += " AND ( PARTSSUBSTURF.CHGSRCMAKERCDRF = " + usrSearchCondWork.MakerCode + " AND ";
                selectstr += "PARTSSUBSTURF.CHGSRCGOODSNORF = '" + usrSearchCondWork.PrtsNo + "' ) ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read()) // 検索結果は最大1件
                {
                    retWork.SubstSorMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    retWork.SubstSorPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    retWork.SubstDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    retWork.SubstDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    retWork.ApplyStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    retWork.ApplyEdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
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
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrPartsSubstSearchにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 代替検索処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="usrSearchCondWorkDic"></param>
        /// <param name="retWorkDic"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int UsrPartsSubstSearch(string enterpriseCode, Dictionary<int, UsrPartsNoSearchCondWork> usrSearchCondWorkDic, out Dictionary<int, UsrPartsSubstRetWork> retWorkDic, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string selectstr = ctQuerySubst;
            retWorkDic = new Dictionary<int, UsrPartsSubstRetWork>();

            if (usrSearchCondWorkDic == null || usrSearchCondWorkDic.Count == 0) return status;

            try
            {
                //ＷＨＥＲＥＮ項目
                selectstr += "WHERE ENTERPRISECODERF = '" + enterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0";

                //メーカーコード・品番 
                selectstr += " AND ( ";
                bool flgContinue = false;
                foreach (int key in usrSearchCondWorkDic.Keys)
                {
                    if (flgContinue) selectstr += " OR ";
                    selectstr += " ( PARTSSUBSTURF.CHGSRCMAKERCDRF = " + usrSearchCondWorkDic[key].MakerCode.ToString().Trim() + " AND ";
                    selectstr += "PARTSSUBSTURF.CHGSRCGOODSNORF = '" + usrSearchCondWorkDic[key].PrtsNo + "' ) ";
                    flgContinue = true;
                }
                selectstr += " ) ";

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrPartsSubstRetWork retWork = new UsrPartsSubstRetWork();
                    retWork.SubstSorMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    retWork.SubstSorPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    retWork.SubstDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    retWork.SubstDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    retWork.ApplyStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    retWork.ApplyEdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));

                    foreach (KeyValuePair<int, UsrPartsNoSearchCondWork> wk in usrSearchCondWorkDic)
                    {
                        if (retWork.SubstSorMakerCd == wk.Value.MakerCode && retWork.SubstSorPartsNo == wk.Value.PrtsNo)
                        {
                            retWorkDic.Add(wk.Key, retWork);
                            break;
                        }
                    }
                }
                if (retWorkDic.Count != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrPartsSubstSearchにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region --- 結合検索処理 ---

        private const string ctQueryJoin =
                 "SELECT "
                 + " JOINPARTSURF.JOINDISPORDERRF, "
                 + " JOINPARTSURF.JOINSOURCEMAKERCODERF, "
                 + " JOINPARTSURF.JOINSOURPARTSNOWITHHRF, "
                 + " JOINPARTSURF.JOINSOURPARTSNONONEHRF, "
                 + " JOINPARTSURF.JOINDESTMAKERCDRF, "
                 + " JOINPARTSURF.JOINDESTPARTSNORF, "
                 + " JOINPARTSURF.JOINQTYRF, "
                 + " JOINPARTSURF.JOINSPECIALNOTERF "
                 + " FROM JOINPARTSURF ";

        /// <summary>
        /// 結合検索処理
        /// </summary>
        /// <param name="inWork">結合検索対象部品リスト</param>
        /// <param name="retWork">結合検索結果リスト</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <returns>DB Status</returns>
        private int UsrJoinPartsSearch(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQueryJoin;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0) // 基本的に最小純正部品1個はあるため、ありえないケースだが、念のためチェックする。
            {
                return status;
            }
            StringBuilder wherestr = new StringBuilder(500);

            try
            {
                //ＷＨＥＲＥＮ項目
                selectstr += "WHERE ENTERPRISECODERF = '" + ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0 AND (";

                //結合先メーカーコード・結合先品番 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    wherestr.Append("OR ( JOINPARTSURF.JOINSOURCEMAKERCODERF = " + wk.MakerCode + " AND ");
                    wherestr.AppendLine("JOINPARTSURF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "' ) ");
                }
                selectstr += wherestr.Remove(0, 2).ToString() + " )"; // 先頭のOR除去

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrJoinPartsRetWork mf = new UsrJoinPartsRetWork();

                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    retWork.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.UsrJoinPartsSearchにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion

        # region --- セットマスタ検索処理 ---

        private const string ctQuerySet =
                 "SELECT "
                 + "GOODSSETRF.PARENTGOODSMAKERCDRF, "
                 + "GOODSSETRF.PARENTGOODSNORF, "
                 + "GOODSSETRF.SUBGOODSMAKERCDRF, "
                 + "GOODSSETRF.SUBGOODSNORF, "
                 + "GOODSSETRF.DISPLAYORDERRF, "
                 + "GOODSSETRF.CNTFLRF, "
            //selectstr += "GOODSSETRF.SETNAMERF, "; // ?
                 + "GOODSSETRF.SETSPECIALNOTERF, "
                 + "GOODSSETRF.CATALOGSHAPENORF "
                 + "FROM GOODSSETRF ";
        /// <summary>
        /// セットマスタ検索
        /// </summary>
        /// <param name="inWork">セット検索対象部品リスト</param>
        /// <param name="retWork">セット検索結果リスト</param>
        /// <param name="sqlConnection">SQL Connection</param>
        /// <returns>DB Status</returns>
        private int SearchSetParts(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            int status = 0;
            string selectstr = ctQuerySet;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0) // 基本的に最小純正部品1個はあるため、ありえないケースだが、念のためチェックする。
            {
                return status;
            }
            StringBuilder wherestr = new StringBuilder(500);

            try
            {
                selectstr += "WHERE ENTERPRISECODERF = '" + ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;
                selectstr += "' AND LOGICALDELETECODERF = 0 AND (";

                //結合先メーカーコード・結合先品番 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    //セット品番フラグが１の場合のみ対象

                    wherestr.Append("OR ( GOODSSETRF.PARENTGOODSMAKERCDRF = " + wk.MakerCode + " AND ");
                    wherestr.AppendLine("GOODSSETRF.PARENTGOODSNORF = '" + wk.PrtsNo + "' ) ");
                }
                selectstr += wherestr.Remove(0, 2).ToString() + " )"; // 先頭のOR除去

                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    UsrSetPartsRetWork mf = new UsrSetPartsRetWork();

                    mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                    mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    mf.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                    //mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF")); // ?
                    mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    retWork.Add(mf);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchSetPartsにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        #region << 商品マスタ検索 >>
        # region --- 商品マスタ取得項目定義 ---
        // 商品マスタ取得項目定義
        private string GOODSRFSelectFields = "SELECT "
                + "GOODSURF.CREATEDATETIMERF, "
                + "GOODSURF.UPDATEDATETIMERF, "
                + "GOODSURF.ENTERPRISECODERF, "
                + "GOODSURF.FILEHEADERGUIDRF, "
                + "GOODSURF.UPDEMPLOYEECODERF, "
                + "GOODSURF.UPDASSEMBLYID1RF, "
                + "GOODSURF.UPDASSEMBLYID2RF, "
                + "GOODSURF.LOGICALDELETECODERF, "
                + "GOODSURF.GOODSMAKERCDRF, "
                + "GOODSURF.GOODSNORF, "
                + "GOODSURF.GOODSNAMERF, "
                + "GOODSURF.GOODSNAMEKANARF, "
                + "GOODSURF.JANRF, "
                + "GOODSURF.BLGOODSCODERF, "
                + "GOODSURF.DISPLAYORDERRF, "
                + "GOODSURF.GOODSRATERANKRF, "
                + "GOODSURF.GOODSSPECIALNOTERF, "
                + "GOODSURF.OFFERDATERF, "
                + "GOODSURF.TAXATIONDIVCDRF, "
                + "GOODSURF.GOODSNONONEHYPHENRF, "
                + "GOODSURF.OFFERDATERF, "
                + "GOODSURF.GOODSKINDCODERF, "
                + "GOODSURF.GOODSNOTE1RF, "
                + "GOODSURF.GOODSNOTE2RF, "
                + "GOODSURF.ENTERPRISEGANRECODERF, "
                + "GOODSURF.UPDATEDATERF, "
                + "GOODSURF.OFFERDATADIVRF, "
                + "BLGROUPURF.GOODSMGROUPRF "
                + "FROM GOODSURF LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                + "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                + "WHERE GOODSURF.ENTERPRISECODERF = @FINDENTERPRISECODE AND ";
                //+ "GOODSURF.LOGICALDELETECODERF = 0 AND ( "; // 2009/09/04 DEL
        // ---- ADD START zhangy3 2012/05/22 FOR Redmine#29871 --------->>>>>
        //メーカーコード⇒品番の順でソートしてから優良部品(ユーザー)を取得する
        private string GOODSMAKERCDANDGOODSNOSort = " ORDER BY GOODSMAKERCDRF,GOODSNORF ";
        // ---- ADD END   zhangy3 2012/05/22 FOR Redmine#29871 ---------<<<<<
        # endregion

        # region --- 商品マスタ検索 ---
        /// <summary>
        /// 商品マスタ検索
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="logicalMode"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        //private int SearchUsrGoods(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        private int SearchUsrGoods(ArrayList inWork, ConstantManagement.LogicalMode logicalMode, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04
        {
            int status = 0;
            int whereCnt = 0;
            string wherestr = string.Empty;

            retWork = new ArrayList();
            if (inWork == null || inWork.Count == 0)
            {
                return status;
            }
            try
            {
                string enterpriseCode = ((UsrPartsNoSearchCondWork)inWork[0]).EnterpriseCode;

                //メーカーコード・品番 
                foreach (UsrPartsNoSearchCondWork wk in inWork)
                {
                    if (wk.PrtsNo == string.Empty)
                    {
                        continue;
                    }

                    if (wk.MakerCode == 0)
                    {
                        wherestr += "OR ( GOODSURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    }
                    else
                    {
                        wherestr += "OR ( GOODSURF.GOODSMAKERCDRF = " + wk.MakerCode + " AND ";
                        wherestr += "GOODSURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    }
                    whereCnt++;

                    if (whereCnt == 20)
                    {
                        //status = ExecuteUsrPartsQuery(enterpriseCode, wherestr, retWork, sqlConnection); // 2009/09/04 DEL
                        status = ExecuteUsrPartsQuery(enterpriseCode, logicalMode, wherestr, retWork, sqlConnection); // 2009/09/04 ADD
                        if (status != 0)
                            return status;
                        whereCnt = 0;
                        wherestr = string.Empty;
                    }
                }
                if (whereCnt > 0)
                {
                    //status = ExecuteUsrPartsQuery(enterpriseCode, wherestr, retWork, sqlConnection); // 2009/09/04 DEL
                    status = ExecuteUsrPartsQuery(enterpriseCode, logicalMode, wherestr, retWork, sqlConnection); // 2009/09/04 ADD
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 結合元品検索
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchJoinSrcGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //品番
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                if (prtsNoWithHyphen.Length <= 0)
                {
                    return (0);
                }

                sqlCommand = new SqlCommand();

                //取得マスタ項目
                selectstr = "SELECT "
                        + "GOODSURF.CREATEDATETIMERF, "
                        + "GOODSURF.UPDATEDATETIMERF, "
                        + "GOODSURF.ENTERPRISECODERF, "
                        + "GOODSURF.FILEHEADERGUIDRF, "
                        + "GOODSURF.UPDEMPLOYEECODERF, "
                        + "GOODSURF.UPDASSEMBLYID1RF, "
                        + "GOODSURF.UPDASSEMBLYID2RF, "
                        + "GOODSURF.LOGICALDELETECODERF, "
                        + "JOINPARTSURF.JOINSOURCEMAKERCODERF AS GOODSMAKERCDRF, "
                        + "JOINPARTSURF.JOINSOURPARTSNOWITHHRF AS GOODSNORF, "
                        + "GOODSURF.GOODSNAMERF, "
                        + "GOODSURF.GOODSNAMEKANARF, "
                        + "GOODSURF.JANRF, "
                        + "GOODSURF.BLGOODSCODERF, "
                        + "GOODSURF.DISPLAYORDERRF, "
                        + "GOODSURF.GOODSRATERANKRF, "
                        + "GOODSURF.GOODSSPECIALNOTERF, "
                        + "GOODSURF.OFFERDATERF, "
                        + "GOODSURF.TAXATIONDIVCDRF, "
                        + "GOODSURF.GOODSNONONEHYPHENRF, "
                        + "GOODSURF.OFFERDATERF, "
                        + "GOODSURF.GOODSKINDCODERF, "
                        + "GOODSURF.GOODSNOTE1RF, "
                        + "GOODSURF.GOODSNOTE2RF, "
                        + "GOODSURF.ENTERPRISEGANRECODERF, "
                        + "GOODSURF.UPDATEDATERF, "
                        + "GOODSURF.OFFERDATADIVRF, "
                        + "BLGROUPURF.GOODSMGROUPRF "
                        + "FROM JOINPARTSURF "
                        //+ "LEFT JOIN GOODSURF ON GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "        // DEL huangt 2013/03/27 Redmine#35019
                        // --- ADD huangt 2013/03/27 Redmine#35019 ---------- >>>>> 
                        + "LEFT JOIN GOODSURF ON GOODSURF.ENTERPRISECODERF = JOINPARTSURF.ENTERPRISECODERF "
                        + "AND GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "
                        // --- ADD huangt 2013/03/27 Redmine#35019 ---------- <<<<<
                        + "AND GOODSURF.GOODSMAKERCDRF = JOINPARTSURF.JOINSOURCEMAKERCODERF "
                        + "LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        + "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                        //+ "FROM GOODSURF LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        //+ "AND GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        //+ "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        //+ "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF "
                        //+ "INNER JOIN JOINPARTSURF ON GOODSURF.GOODSNORF = JOINPARTSURF.JOINSOURPARTSNOWITHHRF "
                        //+ "AND GOODSURF.GOODSMAKERCDRF = JOINPARTSURF.JOINSOURCEMAKERCODERF "
                        + "WHERE JOINPARTSURF.ENTERPRISECODERF = @FINDENTERPRISECODE AND "
                        + "JOINPARTSURF.JOINDESTMAKERCDRF = @FINDJOINDESTMAKERCD AND "
                        + "JOINPARTSURF.JOINDESTPARTSNORF = @FINDJOINDESTPARTSNO ";                        

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(partsNoSearchCondWork.EnterpriseCode);
                //メーカーコード・品番 
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar)).Value = SqlDataMediator.SqlSetString(partsNoSearchCondWork.PrtsNo);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = selectstr;

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);

                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }

        //private int ExecuteUsrPartsQuery(string enterpriseCode, string wherestr, ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int ExecuteUsrPartsQuery(string enterpriseCode, ConstantManagement.LogicalMode logicalMode, string wherestr, ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = 0;
            SqlDataReader myReader = null;

            try
            {
                //取得マスタ項目
                string selectstr = GOODSRFSelectFields;
                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF < @FINDLOGICALDELETECODE AND ( ";
                }
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                
                wherestr = wherestr.Substring(2) + " )"; // 先頭のOR除去                

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(enterpriseCode);

                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        # region --- 商品マスタ検索＜曖昧検索＞ ---
        /// <summary>
        /// 商品マスタ検索＜曖昧検索＞
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="searchType"></param>
        /// <param name="logicalMode"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Update Note: 2012/05/22 zhangy3 </br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#29871 売上伝票入力　「*」を使用した品番検索の結果が毎回異なる</br>
        //private int SearchUsrGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, int searchType, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 DEL
        private int SearchUsrGoods(UsrPartsNoSearchCondWork partsNoSearchCondWork, int searchType, ConstantManagement.LogicalMode logicalMode, out ArrayList retWork, SqlConnection sqlConnection) // 2009/09/04 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            retWork = new ArrayList();

            try
            {
                //品番
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                if (prtsNoWithHyphen.Length <= 0)
                {
                    return (0);
                }

                sqlCommand = new SqlCommand();

                //取得マスタ項目
                selectstr = GOODSRFSelectFields;
                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND ( ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectstr = selectstr + "GOODSURF.LOGICALDELETECODERF < @FINDLOGICALDELETECODE AND ( ";
                }
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                selectstr = selectstr.Insert(6, " TOP (100) ");

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(partsNoSearchCondWork.EnterpriseCode);

                // 2009/09/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                // 2009/09/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //メーカーコード・品番 
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    wherestr += " GOODSURF.GOODSMAKERCDRF = @MAKERCDRF AND ";
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCDRF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                }

                if (prtsNoWithHyphen.Contains("-") == true) //品番ハイフンあり
                {
                    partsNoRF = "GOODSURF.GOODSNORF";
                }
                else                                        //品番ハイフンなし
                {
                    partsNoRF = "GOODSURF.GOODSNONONEHYPHENRF";
                }

                switch (searchType)
                {
                    case 0: // 完全一致
                        wherestr += "GOODSURF.GOODSNORF = @GOODSNOWITHHYPRF )";
                        break;
                    case 1: // 前方一致
                        prtsNoWithHyphen = prtsNoWithHyphen + "%";
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 2: // 後方一致
                        prtsNoWithHyphen = "%" + prtsNoWithHyphen;
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 3: // 曖昧検索
                        prtsNoWithHyphen = "%" + prtsNoWithHyphen + "%";
                        wherestr += partsNoRF + " LIKE @GOODSNOWITHHYPRF )";
                        break;
                    case 4: // ハイフン無し完全一致
                        wherestr += "GOODSURF.GOODSNONONEHYPHENRF = @GOODSNOWITHHYPRF )";
                        break;
                }
                ///////////////////////////////////////////////////////

                // バインド変数にパラメータを設定                
                ((SqlParameter)sqlCommand.Parameters.Add("@GOODSNOWITHHYPRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(prtsNoWithHyphen);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                //sqlCommand.CommandText = selectstr + wherestr;//Del zhangy3 2012/05/22 FOR Redmine#29871
                sqlCommand.CommandText = selectstr + wherestr + GOODSMAKERCDANDGOODSNOSort;//ADD zhangy3 2012/05/22 FOR Redmine#29871

                myReader = sqlCommand.ExecuteReader();
                SetUsrGoodsRetWork(myReader, retWork);

                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        # endregion

        private int SearchUsrGoodsPriceProc(ArrayList inSetParts, out ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int whereCnt = 0;
            string wherestr = string.Empty;

            usrGoodsPrice = new ArrayList();
            if (inSetParts == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else if (inSetParts.Count == 0)
            {
                return 0;
            }
            try
            {
                string enterpriseCode = ((UsrPartsNoSearchCondWork)inSetParts[0]).EnterpriseCode;
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                Dictionary<string, int> makerCodeParamDic = new Dictionary<string, int>();
                Dictionary<string, string> goodsNoParamDic = new Dictionary<string, string>();
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<

                //メーカーコード・品番 
                foreach (UsrPartsNoSearchCondWork wk in inSetParts)
                {
                    if ((wk.PrtsNo == string.Empty) || (wk.MakerCode == 0))
                    {
                        continue;
                    }
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    string makerCodeParam = "@FINDGOODSMAKERCDRF" + whereCnt.ToString();
                    string GoodsNoParam = "@FINDGOODSNORF" + whereCnt.ToString();
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                    //----- DEL YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    //wherestr += "OR ( GOODSPRICEURF.GOODSMAKERCDRF = " + wk.MakerCode + " AND ";
                    //wherestr += "GOODSPRICEURF.GOODSNORF = '" + wk.PrtsNo + "' ) ";
                    //----- DEL YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                    wherestr += "OR ( GOODSPRICEURF.GOODSMAKERCDRF = " + makerCodeParam + " AND ";
                    wherestr += "GOODSPRICEURF.GOODSNORF = " + GoodsNoParam + " ) ";

                    if (makerCodeParamDic.ContainsKey(makerCodeParam))
                    {
                        makerCodeParamDic[makerCodeParam] = wk.MakerCode;
                    }
                    else
                    {
                        makerCodeParamDic.Add(makerCodeParam, wk.MakerCode);
                    }
                    if (goodsNoParamDic.ContainsKey(GoodsNoParam))
                    {
                        goodsNoParamDic[GoodsNoParam] = wk.PrtsNo;
                    }
                    else
                    {
                        goodsNoParamDic.Add(GoodsNoParam, wk.PrtsNo);
                    }
                    //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                    whereCnt++;

                    if (whereCnt == 30)
                    {
                        //status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);//DEL YANGMJ 2012/09/04 REDMINE#32095
                        status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection, makerCodeParamDic, goodsNoParamDic);//ADD YANGMJ 2012/09/04 REDMINE#32095
                        if (status != 0)
                            return status;
                        whereCnt = 0;
                        wherestr = string.Empty;
                        makerCodeParamDic = new Dictionary<string, int>();
                        goodsNoParamDic = new Dictionary<string, string>();
                    }
                }
                if (whereCnt > 0)
                {
                    //status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection);//DEL YANGMJ 2012/09/04 REDMINE#32095
                    status = ExecutePriceQuery(enterpriseCode, wherestr, usrGoodsPrice, logicalMode, sqlConnection, makerCodeParamDic, goodsNoParamDic);//ADD YANGMJ 2012/09/04 REDMINE#32095
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPriceにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        //private int ExecutePriceQuery(string enterpriseCode, string wherestr, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)//DEL YANGMJ 2012/09/04 REDMINE#32095
        private int ExecutePriceQuery(string enterpriseCode, string wherestr, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, Dictionary<string, int> makerCodeParamDic, Dictionary<string, string> goodsNoParamDic)//ADD YANGMJ 2012/09/04 REDMINE#32095
        {
            int status = 0;
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

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

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

                wherestr = wherestr.Substring(2) + " ) "; // 先頭のOR除去
                string orderStr = " ORDER BY PRICESTARTDATERF DESC, GOODSNORF";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr + orderStr, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(enterpriseCode);
                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value
                                    = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 ----->>>>>
                foreach (string key in makerCodeParamDic.Keys)
                {
                    ((SqlParameter)sqlCommand.Parameters.Add(key, SqlDbType.Int)).Value
                        = SqlDataMediator.SqlSetInt32((Int32)makerCodeParamDic[key]);
                }
                foreach (string keyGoodsNo in goodsNoParamDic.Keys)
                {
                    string temp = goodsNoParamDic[keyGoodsNo];
                    ((SqlParameter)sqlCommand.Parameters.Add(keyGoodsNo, SqlDbType.Char)).Value
                        = SqlDataMediator.SqlSetString(temp);
                }
                //----- ADD YANGMJ 2012/09/04 REDMINE#32095 -----<<<<<
                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //UsrGoodsPriceWork mf = new UsrGoodsPriceWork();
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
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
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
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        # region --- 商品マスタ情報格納処理 ---
        /// <summary>
        /// 商品マスタ情報格納処理
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private void SetUsrGoodsRetWork(SqlDataReader myReader, ArrayList retWork)
        {
            while (myReader.Read())
            {
                UsrGoodsRetWork mf = new UsrGoodsRetWork();
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
                mf.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                mf.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                mf.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                mf.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                mf.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                mf.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                mf.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                mf.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                mf.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                mf.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                mf.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                mf.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                mf.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                mf.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));

                retWork.Add(mf);
            }
        }
        # endregion
        #endregion

        # endregion
        #endregion

        #region [ 商品構成取得DBリモートオブジェクト ]
        #region [Search]
        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 削除
        ///// <summary>
        ///// 指定された条件の商品構成取得情報LISTを戻します
        ///// </summary>
        ///// <param name="retObj">検索結果</param>
        ///// <param name="paraObj">検索パラメータ</param>
        ///// <param name="readMode">検索区分(現在未使用)</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します</br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2006.12.06</br>
        //public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;
        //    SqlTransaction sqlTransaction = null;

        //    try
        //    {
        //        //コネクション生成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();

        //        status = SearchProc(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                sqlTransaction.Commit();
        //            }

        //            sqlTransaction.Dispose();
        //        }

        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)
        ///// </summary>
        ///// <param name="retObj">検索結果</param>
        ///// <param name="paraObj">検索パラメータ</param>
        ///// <param name="readMode">検索区分(現在未使用)</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2006.12.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        //public int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
        //    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    return SearchProcP(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //}

        //private int SearchProcP(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
        //    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    GoodsUCndtnWork goodsrelationdataWork = null;

        //    CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

        //    ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
        //    if (goodsrelationdataWorkList == null)
        //    {
        //        goodsrelationdataWork = paraObj as GoodsUCndtnWork;
        //    }
        //    else
        //    {
        //        if (goodsrelationdataWorkList.Count > 0)
        //            goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
        //    }

        //    CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
        //    for (int i = 0; i < paraList.Count; i++)
        //    {
        //        Type wktype = paraList[i].GetType();
        //        switch (wktype.Name)
        //        {
        //            //売上全体設定
        //            case "SalesTtlStWork":
        //                {
        //                    SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
        //                    ArrayList retal = new ArrayList();
        //                    SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
        //                    salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;
        //            //商品中分類
        //            case "GoodsGroupUWork":
        //                {
        //                    GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
        //                    ArrayList retal = new ArrayList();
        //                    GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
        //                    goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //優良設定
        //            case "PrmSettingUWork":
        //                {
        //                    PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
        //                    ArrayList retal = new ArrayList();
        //                    PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
        //                    prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //メーカー
        //            case "MakerUWork":
        //                {
        //                    MakerUDB makerUDB = new MakerUDB();
        //                    ArrayList retal = null;
        //                    MakerUWork makerUWork = new MakerUWork();
        //                    makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //BLグループ 
        //            case "BLGroupUWork":
        //                {
        //                    BLGroupUDB bLGroupUDB = new BLGroupUDB();
        //                    ArrayList retal = new ArrayList();
        //                    BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
        //                    bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //BLコード               
        //            case "BLGoodsCdUWork":
        //                {
        //                    BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
        //                    ArrayList retal = null;
        //                    BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
        //                    bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //商品管理
        //            case "GoodsMngWork":
        //                {
        //                    GoodsMngDB goodsMngDB = new GoodsMngDB();
        //                    ArrayList retal = new ArrayList();
        //                    GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
        //                    goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //ユーザーガイド
        //            case "UserGdBdUWork":
        //                {
        //                    UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
        //                    //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
        //                    UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
        //                    usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

        //                    //商品大分類(ユーザーガイド ガイド区分:70)
        //                    ArrayList retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 70;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    usrGdBdLst[0].UserGuideDivCd = 70;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);

        //                    //自社分類(ユーザーガイド ガイド区分:41)
        //                    retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 41;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].UserGuideDivCd = 41;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);

        //                    //販売区分(ユーザーガイド ガイド区分:71)
        //                    retal = null;
        //                    //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
        //                    //userGdBdUWork.UserGuideDivCd = 71;
        //                    //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
        //                    usrGdBdLst[0].UserGuideDivCd = 71;
        //                    status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //            //商品連結
        //            case "GoodsUnitDataWork":
        //                {
        //                    ArrayList retal = null;
        //                    status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, logicalMode, ref sqlConnection);
        //                    retCSAList.Add(retal);
        //                }
        //                break;

        //        }
        //    }

        //    retObj = retCSAList;

        //    // ↓ 2008.03.24 980081 c
        //    //return status;
        //    if (retCSAList.Count == 0)
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    }
        //    else
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    // ↑ 2008.03.24 980081 c
        //}
        #endregion

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return Search(ref retObj, paraObj, readMode, 0, logicalMode);
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref retObj, paraObj, readMode, maxCount, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProcP(ref retObj, paraObj, readMode, maxCount, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        private int SearchProcP(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsUCndtnWork goodsrelationdataWork = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsUCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
            }

            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();
                switch (wktype.Name)
                {
                    //売上全体設定
                    case "SalesTtlStWork":
                        {
                            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
                            ArrayList retal = new ArrayList();
                            SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
                            salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    //商品中分類
                    case "GoodsGroupUWork":
                        {
                            GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                            ArrayList retal = new ArrayList();
                            GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                            goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //優良設定
                    case "PrmSettingUWork":
                        {
                            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                            ArrayList retal = new ArrayList();
                            PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                            prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //メーカー
                    case "MakerUWork":
                        {
                            MakerUDB makerUDB = new MakerUDB();
                            ArrayList retal = null;
                            MakerUWork makerUWork = new MakerUWork();
                            makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BLグループ 
                    case "BLGroupUWork":
                        {
                            BLGroupUDB bLGroupUDB = new BLGroupUDB();
                            ArrayList retal = new ArrayList();
                            BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                            bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BLコード               
                    case "BLGoodsCdUWork":
                        {
                            BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                            ArrayList retal = null;
                            BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                            bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //商品管理
                    case "GoodsMngWork":
                        {
                            GoodsMngDB goodsMngDB = new GoodsMngDB();
                            ArrayList retal = new ArrayList();
                            GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                            goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //ユーザーガイド
                    case "UserGdBdUWork":
                        {
                            UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                            //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
                            UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
                            usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

                            //商品大分類(ユーザーガイド ガイド区分:70)
                            ArrayList retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 70;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 70;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //自社分類(ユーザーガイド ガイド区分:41)
                            retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 41;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].UserGuideDivCd = 41;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //販売区分(ユーザーガイド ガイド区分:71)
                            retal = null;
                            //userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            //userGdBdUWork.UserGuideDivCd = 71;
                            //status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                            usrGdBdLst[0].UserGuideDivCd = 71;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 離島価格
                    case "IsolIslandPrcWork":
                        {
                            IsolIslandPrcDB isolIslandPrcDB = new IsolIslandPrcDB();
                            ArrayList retal = new ArrayList();
                            IsolIslandPrcWork isolIslandPrcWork = paraList[i] as IsolIslandPrcWork;
                            isolIslandPrcWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = isolIslandPrcDB.Search(ref retal, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 2009.04.09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 仕入先
                    case "SupplierWork":
                        {
                            SupplierDB supplierDB = new SupplierDB();
                            ArrayList retal = new ArrayList();
                            SupplierWork supplierWork = paraList[i] as SupplierWork;
                            supplierWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = supplierDB.Search(out retal, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    // 2009.04.09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    //商品連結
                    case "GoodsUnitDataWork":
                        {
                            ArrayList retal = null;
                            status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                }
            }

            retObj = retCSAList;

            // ↓ 2008.03.24 980081 c
            //return status;

            // 2011/11/29 Add >>>
            // コマンドタイムアウトの場合、ステータスをそのまま返す
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                return status;
            // 2011/11/29 Add <<<
            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ↑ 2008.03.24 980081 c
        }
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">検索結果</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsrelationdataWork">抽出条件</param>
        /// <param name="paralist">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {

            // -- UPD 2011/03/17 -------------------------------------------------------->>>
            //// 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, 0, logicalMode, ref sqlConnection);
            //// 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, 0, logicalMode, 0,ref sqlConnection);
            // -- UPD 2011/03/17 --------------------------------------------------------<<<
        }

        // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">検索結果</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsrelationdataWork">抽出条件</param>
        /// <param name="paralist">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // -- UPD 2011/03/17 -------------------------------------------------------->>>
            //return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, logicalMode, ref sqlConnection);
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, logicalMode, 0, ref sqlConnection);
            // -- UPD 2011/03/17 --------------------------------------------------------<<<
        }
        // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // -- UPD 2011/03/17 -------------------------------------------------------->>>
        /// <summary>
        /// ユーザー商品マスタと価格マスタのみを取得します。
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int UsrGoodsOnlySearch(ref object retObj, object paraObj, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            GoodsUCndtnWork goodsrelationdataWork = null;
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
                if (goodsrelationdataWorkList == null)
                {
                    goodsrelationdataWork = paraObj as GoodsUCndtnWork;
                }
                else
                {
                    if (goodsrelationdataWorkList.Count > 0)
                        goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
                }

                CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
                Type wktype = paraList[0].GetType();

                ArrayList retal = null;
                status = SearchGoodsURelationDataProcP(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, logicalMode, 1, ref sqlConnection);
                retCSAList.Add(retal);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        // -- UPD 2011/03/17 --------------------------------------------------------<<<

        // -- UPD 2011/03/17 -------------------------------------------------------->>>
        //// 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ////private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //// 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, ConstantManagement.LogicalMode logicalMode, int stockSearchDiv ,ref SqlConnection sqlConnection)
        // -- UPD 2011/03/17 --------------------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string sMaxCount = string.Empty;
            if (maxCount != 0) sMaxCount = "TOP(" + maxCount.ToString() + ") ";
            // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // -------- ADD START 2014.02.10 高陽 -------->>>>>
            // 商品マスタ表示用オプション
            bool optKonmanGoodsMstCtl = false;
            ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
            PurchaseStatus ps = loginInfo.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KonmanGoodsMstCtl);
            if (ps == PurchaseStatus.Contract)
            {
                optKonmanGoodsMstCtl = true;
            }
            else
            {
                optKonmanGoodsMstCtl = false;
            }
            // -------- ADD END 2014.02.10 高陽 --------<<<<<

            string selectstring = "";
            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "SELECT " + sMaxCount + "GOODS.CREATEDATETIMERF" + Environment.NewLine;
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                // 商品マスタ表示用オプションある
                if (optKonmanGoodsMstCtl)
                {
                    selectstring += "    ,GOODSA.STANDARDRF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.PACKINGRF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.POSNORF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.MAKERGOODSNORF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.CREATEDATETIMERF AS CREATEDATETIMEARF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.UPDATEDATETIMERF AS UPDATEDATETIMEARF" + Environment.NewLine;
                    selectstring += "    ,GOODSA.FILEHEADERGUIDRF AS FILEHEADERGUIDARF" + Environment.NewLine;
                }
                // -------- ADD END 2014/02/10 高陽 --------<<<<<
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                // 商品マスタ表示用オプションある
                if (optKonmanGoodsMstCtl)
                {
                    selectstring += "LEFT JOIN GOODSUARF AS GOODSA ON" + Environment.NewLine;
                    selectstring += "    GOODS.ENTERPRISECODERF = GOODSA.ENTERPRISECODERF" + Environment.NewLine;
                    selectstring += "AND GOODS.GOODSNORF = GOODSA.GOODSNORF" + Environment.NewLine;
                    selectstring += "AND GOODS.GOODSMAKERCDRF = GOODSA.GOODSMAKERCDRF" + Environment.NewLine;
                    selectstring += "AND GOODS.LOGICALDELETECODERF = GOODSA.LOGICALDELETECODERF" + Environment.NewLine;
                }
                // -------- ADD END 2014/02/10 高陽 --------<<<<<

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();

                // ADD gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                // ADD gezh 2013/01/24 Redmine#33361 改修案② --------<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));// DEL 2014.02.10 高陽
                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader, optKonmanGoodsMstCtl));// ADD 2014.02.10 高陽

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // ADD gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                    GoodsUnitDataWork usrGoodsWork = (GoodsUnitDataWork)al[al.Count - 1];
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                    // ADD gezh 2013/01/24 Redmine#33361 改修案② --------<<<<<
                }
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                foreach (GoodsUnitDataWork usrGoodsWork in al)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 改修案② ---------- */
                myReader.Close();
                status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, logicalMode, sqlConnection);
                if (status == 0)
                {
                    // ADD gezh 2013/01/24 Redmine#33361 改修案③ -------->>>>>
                    Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();

                    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    {
                        ArrayList priceListNew;

                        string key = prc.GoodsMakerCd + prc.GoodsNo;

                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            priceListNew.Add(prc);
                        }
                        else
                        {
                            priceListNew = new ArrayList();
                            priceListNew.Add(prc);
                            priceDic.Add(key, priceListNew);
                        }
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 改修案③ --------<<<<<
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        /* ---------------- DEL gezh 2013/01/24 Redmine#33361 改修案③ -------->>>>>
                        usrGoodsWork.PriceList = new ArrayList();
                        //foreach (UsrGoodsPriceWork prc in usrGoodsPrice)
                        foreach (GoodsPriceUWork prc in usrGoodsPrice)
                        {
                            if (usrGoodsWork.GoodsMakerCd == prc.GoodsMakerCd &&
                                usrGoodsWork.GoodsNo == prc.GoodsNo)
                            {
                                usrGoodsWork.PriceList.Add(prc);
                            }
                        }
                        <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 改修案③ ---------- */
                        // ADD gezh 2013/01/24 Redmine#33361 -------->>>>>
                        ArrayList priceListNew;
                        usrGoodsWork.PriceList = new ArrayList();
                        string key = usrGoodsWork.GoodsMakerCd + usrGoodsWork.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            usrGoodsWork.PriceList.AddRange(priceListNew);
                        }
                        // ADD gezh 2013/01/24 Redmine#33361 --------<<<<<
                    }
                }
                else
                {
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        usrGoodsWork.PriceList = new ArrayList();
                    }
                }

                // -- ADD 2011/03/17 ------------->>>
                if (stockSearchDiv == 0)
                {
                // -- ADD 2011/03/17 -------------<<<
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        ArrayList stockRetList;
                        StockDB stockDB = new StockDB();

                        StockWork stockWk = new StockWork();
                        stockWk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                        stockWk.GoodsMakerCd = usrGoodsWork.GoodsMakerCd;
                        stockWk.GoodsNo = usrGoodsWork.GoodsNo;
                        status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);
                        if (status == 0)
                        {
                            usrGoodsWork.StockList = stockRetList;
                        }
                        else
                        {
                            usrGoodsWork.StockList = new ArrayList();
                        }
                    }
                }  // -- ADD 2011/03/17
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
            }

            goodsrelationdataWorkList = al;

            return status;
        }

        #region [仕様変更により下記メソッドを完全に書き直ししたが原本を残す。]
        /*
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectstring = "";
            try
            {
                selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,MAKERU.MAKERNAMERF AS MAKERNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSLGROUPRF AS GOODSLGROUP" + Environment.NewLine;
                selectstring += "    ,USERGD.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
                selectstring += "    ,GOODSGROUPU.GOODSMGROUPNAMERF AS GOODSMGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPNAMERF AS BLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,USERGD01.GUIDENAMERF AS ENTERPRISEGANRENAME" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.SALESCODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.CREATEDATETIMERF AS GOODSPCREATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATETIMERF AS GOODSPUPDATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.ENTERPRISECODERF AS GOODSPENTERPRISECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.FILEHEADERGUIDRF AS GOODSPFILEHEADERGUID" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDEMPLOYEECODERF AS GOODSPUPDEMPLOYEECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID1RF AS GOODSPUPDASSEMBLYID1" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID2RF AS GOODSPUPDASSEMBLYID2" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.PRICESTARTDATERF AS GOODSPPRICESTARTDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.LISTPRICERF AS GOODSPLISTPRICE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.SALESUNITCOSTRF AS GOODSPSALESUNITCOST" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.STOCKRATERF AS GOODSPSTOCKRATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OPENPRICEDIVRF AS GOODSPOPENPRICEDIV" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OFFERDATERF AS GOODSPOFFERDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATERF AS GOODSPUPDATEDATE" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                selectstring += "    ,WAREHOUSE.WAREHOUSENAMERF AS WAREHOUSENAME" + Environment.NewLine;
                selectstring += "    ,STOCK.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNT" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSESHELFNORF AS WAREHOUSESHELFNO" + Environment.NewLine;
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSPRICE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN MAKERURF AS MAKERU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     MAKERU.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND MAKERU.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGOODS.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGOODS.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                selectstring += " AND USERGD.GUIDECODERF=GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN WAREHOUSERF AS WAREHOUSE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     WAREHOUSE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND WAREHOUSE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGROUPURF AS BLGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGROUPU.ENTERPRISECODERF=BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGROUPU.BLGROUPCODERF=BLGOODS.BLGROUPCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD01" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD01.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD01.USERGUIDEDIVCDRF=71" + Environment.NewLine;
                selectstring += " AND USERGD01.GUIDECODERF=BLGROUPU.GOODSLGROUPRF" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSGROUPURF AS GOODSGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSGROUPU.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSGROUPU.GOODSMGROUPRF=BLGROUPU.GOODSMGROUPRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODSPRICE.PRICESTARTDATERF DESC, GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            goodsrelationdataWorkList = al;

            return status;
        }
        */
        #endregion

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiCondition(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retObj = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchMultiConditionProc(out retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiConditionProc(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList != null)
            {
            }

            CustomSerializeArrayList paraList = null;
            ArrayList retal = null;
            object paratype = new GoodsUCndtnWork();
            status = SearchGoodsURelationDataProc(out retal, null, null, paraList, readMode, logicalMode, ref sqlConnection);
            retCSAList.Add(retal);

            retObj = retCSAList;

            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsRelationDataWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, Type trgType, GoodsUCndtnWork goodsRelationDataWork, ConstantManagement.LogicalMode logicalMode)
        {
            string joinQuery = " LEFT JOIN BLGOODSCDURF ON GOODS.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF "
                        + "AND GOODS.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF LEFT JOIN BLGROUPURF "
                        + "ON BLGOODSCDURF.ENTERPRISECODERF = BLGROUPURF.ENTERPRISECODERF "
                        + "AND BLGOODSCDURF.BLGROUPCODERF = BLGROUPURF.BLGROUPCODERF ";
            string wkstring = string.Empty;
            StringBuilder whereString = new StringBuilder();
            whereString.Append("WHERE ");
            string maintable = "";

            maintable = "GOODS";
            //企業コード
            whereString.Append(maintable + ".ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                whereString.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //商品コード
            if (SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo) != DBNull.Value)
            {
                if (goodsRelationDataWork.GoodsNoSrchTyp != 0)
                {
                    //ハイフン無し品番に変換
                    string goodsNoNoneHyphen = goodsRelationDataWork.GoodsNo.Replace("-", "");

                    if (goodsRelationDataWork.GoodsNoSrchTyp != 4)
                    {
                        whereString.Append("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                        //前方一致検索の場合
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                        //後方一致検索の場合
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                        //あいまい検索の場合
                        if (goodsRelationDataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                    }
                    else
                    {
                        //ハイフン無し品番完全一致検索の場合
                        whereString.Append("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                    }

                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                }
                else
                {
                    whereString.Append("AND GOODS.GOODSNORF=@GOODSNO ");

                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo);
                }

            }

            //メーカーコード
            if (goodsRelationDataWork.GoodsMakerCd > 0)
            {
                whereString.Append("AND GOODS.GOODSMAKERCDRF=@GOODSMAKERCD ");
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMakerCd);
            }

            //商品名称
            if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsName) == false)
            {
                whereString.Append("AND GOODS.GOODSNAMERF LIKE @GOODSNAME ");
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsRelationDataWork.GoodsNameSrchTyp == 1) goodsRelationDataWork.GoodsName = goodsRelationDataWork.GoodsName + "%";
                //後方一致検索の場合
                if (goodsRelationDataWork.GoodsNameSrchTyp == 2) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName;
                //あいまい検索の場合
                if (goodsRelationDataWork.GoodsNameSrchTyp == 3) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName + "%";
                paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsName);
            }

            //商品名称カナ
            if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsNameKana) == false)
            {
                whereString.Append("AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA ");
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 1) goodsRelationDataWork.GoodsNameKana = goodsRelationDataWork.GoodsNameKana + "%";
                //後方一致検索の場合
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 2) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana;
                //あいまい検索の場合
                if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 3) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana + "%";
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNameKana);
            }

            //JANコード
            if (string.IsNullOrEmpty(goodsRelationDataWork.Jan) == false)
            {
                whereString.Append("AND GOODS.JANRF=@JAN ");
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                paraJan.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.Jan);
            }

            //BL商品コード
            if (goodsRelationDataWork.BLGoodsCode > 0)
            {
                whereString.Append("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGoodsCode);
            }

            //商品大分類コード(BLグループを参照)
            if (goodsRelationDataWork.GoodsLGroup > 0)
            {
                whereString.Append("AND BLGROUPURF.GOODSLGROUPRF=@GOODSLGROUP ");
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GoodsLGroup", SqlDbType.Int);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsLGroup);
            }

            //商品中分類コード
            if (goodsRelationDataWork.GoodsMGroup > 0)
            {
                whereString.Append("AND BLGROUPURF.GOODSMGROUPRF=@GOODSMGROUP ");
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMGroup);
            }

            //グループコード
            if (goodsRelationDataWork.BLGroupCode > 0)
            {
                whereString.Append("AND BLGROUPURF.BLGROUPCODERF=@BLGROUPCODE ");
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
            }

            //商品属性
            if (goodsRelationDataWork.GoodsKindCode != 9)
            {
                whereString.Append("AND GOODS.GOODSKINDCODERF=@GOODSKINDCODE ");
                SqlParameter paraDetailGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                paraDetailGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsKindCode);
            }
            string ret = string.Empty;
            if (goodsRelationDataWork.GoodsLGroup > 0 || goodsRelationDataWork.GoodsMGroup > 0 || goodsRelationDataWork.BLGroupCode > 0)
            {
                ret = joinQuery;
            }
            ret += whereString.ToString();
            return ret;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        private string MakeWhereStringMultiCondition(ref SqlCommand sqlCommand, Type trgType, ArrayList paraList, ConstantManagement.LogicalMode logicalMode)
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

            for (int i = 0; i < paraList.Count; i++)
            {
                wkcond = paraList[i] as GoodsUCndtnWork;
                countstr = i.ToString();
                if (wkstring != "") wkstring += "OR ";
                wkstring += "( GOODS.GOODSMAKERCDRF=@GOODSMAKERCD" + countstr + " AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN" + countstr + " ) ";

                //メーカーコード
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + countstr, SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(wkcond.GoodsMakerCd);

                //商品コード
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN" + countstr, SqlDbType.NChar);


                if (SqlDataMediator.SqlSetString(wkcond.GoodsNo) != DBNull.Value)
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(wkcond.GoodsNo);
                }
                else
                {
                    paraGoodsNo.Value = "";
                }
            }
            retstring.Append(wkstring);

            return retstring.ToString();
        }
        #endregion

        #region [クラス格納処理]

        #region [商品連結データクラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsUnitDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="optKonmanGoodsMstCtl">商品マスタ表示用オプション</param>
        /// <returns>GoodsUnitDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2014/02/10 高陽</br>
        /// <br>           : Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        //private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)// DEL 2014.02.10 高陽
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader, bool optKonmanGoodsMstCtl)// ADD 2014.02.10 高陽
        {
            GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

            #region クラスへ格納
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            // 商品マスタ表示用オプションある
            if (optKonmanGoodsMstCtl)
            {
                wkGoodsUnitDataWork.Standard = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STANDARDRF"));
                wkGoodsUnitDataWork.Packing = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PACKINGRF"));
                wkGoodsUnitDataWork.PosNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSNORF"));
                wkGoodsUnitDataWork.MakerGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERGOODSNORF"));
                wkGoodsUnitDataWork.CreateDateTimeA = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMEARF"));
                wkGoodsUnitDataWork.UpdateDateTimeA = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMEARF"));
                wkGoodsUnitDataWork.FileHeaderGuidA = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDARF"));
            }
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
            #endregion

            return wkGoodsUnitDataWork;
        }

        #region [仕様変更により以下をコメントする]
        /*
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

            #region クラスへ格納
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAME"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUP"));
            wkGoodsUnitDataWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            wkGoodsUnitDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUP"));
            wkGoodsUnitDataWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAME"));
            wkGoodsUnitDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            wkGoodsUnitDataWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAME"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAME"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkGoodsUnitDataWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            wkGoodsUnitDataWork.GoodsPriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPCREATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPUPDATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPENTERPRISECODE"));
            wkGoodsUnitDataWork.GoodsPriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GOODSPFILEHEADERGUID"));
            wkGoodsUnitDataWork.GoodsPriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDEMPLOYEECODE"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDASSEMBLYID1"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPUPDASSEMBLYID2"));
            wkGoodsUnitDataWork.GoodsPricePriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPPRICESTARTDATE"));
            wkGoodsUnitDataWork.GoodsPriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPLISTPRICE"));
            wkGoodsUnitDataWork.GoodsPriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPSALESUNITCOST"));
            wkGoodsUnitDataWork.GoodsPriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPSTOCKRATE"));
            wkGoodsUnitDataWork.GoodsPriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPOPENPRICEDIV"));
            wkGoodsUnitDataWork.GoodsPriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPOFFERDATE"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPUPDATEDATE"));
            wkGoodsUnitDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            wkGoodsUnitDataWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAME"));
            wkGoodsUnitDataWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNT"));
            wkGoodsUnitDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
            #endregion

            return wkGoodsUnitDataWork;
        }
        */
        #endregion
        #endregion

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region 商品系データを一括して扱う処理
        /// <summary>
        /// 商品・価格・在庫／代替／結合／セットの登録・更新を行います。
        /// 代替などでは元や先の2商品情報を格納するため
        /// （商品・価格・在庫）情報のみArrayListに設定し、他の情報は直接CustomSerializeArrayListにAddする。
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int WriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null || csaList.Count == 0)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction);    // DEL huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 
                status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, false);    // ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // コミット
                {
                    sqlTransaction.Commit();
                }
                else　  // ロールバック
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                goodsWork = retList;
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
        /// <summary>
        /// 商品・価格・在庫／代替／結合／セットの登録・更新を行います。
        /// 代替などでは元や先の2商品情報を格納するため
        /// （商品・価格・在庫）情報のみArrayListに設定し、他の情報は直接CustomSerializeArrayListにAddする。
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報を登録、更新します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/15</br>
        /// <br></br>
        public int WriteRelationForShipmentCnt(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null || csaList.Count == 0)
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, true);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // コミット
                {
                    sqlTransaction.Commit();
                }
                else　  // ロールバック
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.WriteRelationForShipmentCnt(ref object goodsWork)");
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                goodsWork = retList;
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

        /// <summary>
        /// 商品・価格・在庫／代替／結合／セットの登録・更新を行います。
        /// 代替などでは元や先の2商品情報を格納するため
        /// （商品・価格・在庫）情報のみArrayListに設定し、他の情報は直接CustomSerializeArrayListにAddする。
        /// </summary>
        /// <param name="csaList">更新対象リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        public int WriteRelationProc(ref CustomSerializeArrayList csaList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            //int status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction);   // DEL huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 
            int status = WriteRelationProc(csaList, ref retList, sqlConnection, sqlTransaction, false);    // ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
            csaList = retList;
            return status;
        }

        //private int WriteRelationProc(CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)      // DEL huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 
        private int WriteRelationProc(CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, bool shipmentCntChangeFlg)        // ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retList = new CustomSerializeArrayList();

            status = 0; // 最初の処理のため、ステータス0を設定しておく。

            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();
            ArrayList goodsStockList = new ArrayList();
            //ArrayList StockAdjustList = null;
            //ArrayList StockAdjustDtlList = null;
            ArrayList RateWork = new ArrayList();

            // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
            Dictionary<string, string> dic = new Dictionary<string, string>(); //倉庫リスト 
            string _enterPriseCode = string.Empty;
            for (int i = 0; i < csaList.Count; i++)
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // 各処理の先頭でこのチェックにより
                    break; // DB異常になってからは処理をせず、ロールバックするようになる。
                Type wktype = csaList[i].GetType();
                switch (wktype.Name)
                {
                    case "CustomSerializeArrayList":
                        {
                            foreach (ArrayList csList in  csaList[i] as CustomSerializeArrayList)
                            {
                                ArrayList stworkList = ListUtils.Find(csList, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;

                                if (stworkList == null) continue; //在庫調整明細がない場合は数量の変動はなし

                                foreach(StockAdjustDtlWork stwork in stworkList)
                                {
                                    if (stwork != null)
                                    {
                                        if (dic.ContainsKey(stwork.WarehouseCode) == false)
                                        {
                                            _enterPriseCode = stwork.EnterpriseCode;
                                            dic.Add(stwork.WarehouseCode, stwork.WarehouseCode);
                                        }
                                    }

                                }

                            }
                        }
                        break;
                }
            }
            foreach (string wCode in dic.Keys)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_enterPriseCode, ShareCheckType.WareHouse, "", wCode);
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                infoList.Add(info);
                if (status != 0) return status;
            }
            // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            CustomSerializeArrayList stockAdjustCsList = null;


            for (int i = 0; i < csaList.Count; i++)
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // 各処理の先頭でこのチェックにより
                    break; // DB異常になってからは処理をせず、ロールバックするようになる。
                Type wktype = csaList[i].GetType();
                switch (wktype.Name)
                {
                    case "ArrayList": // ArrayListに設定されるのは商品情報のみと規約する。
                        #region [ CustomSerializeArrayList内にさらにArrayListの場合 ]
                        {
                            ArrayList wkal = csaList[i] as ArrayList;

                            if (wkal.Count == 0)
                                continue;
                            Type wktype2 = wkal[0].GetType();

                            switch (wktype2.Name)
                            {
                                case "GoodsUnitDataWork": // 商品
                                    #region [ 商品 ]
                                    {
                                        //商品マスタ
                                        CopyToGoodsAndPriceWork(wkal, ref goodsList, ref goodsPriceList, ref goodsStockList, true);
                                        //商品マスタ更新処理
                                        if (goodsList != null)
                                        {
                                            GoodsUDB goodsUDB = new GoodsUDB();
                                            status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                                        }

                                        //価格マスタ更新処理
                                        if (goodsPriceList != null && goodsPriceList.Count > 0 && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            ArrayList writeErrorList = new ArrayList();
                                            GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                                            //int indPrice = 0;
                                            //foreach (GoodsUnitDataWork goodsUnitDataWork in wkal)
                                            //{
                                            //for (; indPrice < goodsPriceList.Count; indPrice++)
                                            for (int indPrice = 0; indPrice < goodsPriceList.Count; indPrice++)
                                            {
                                                GoodsPriceUWork tmp = goodsPriceList[indPrice] as GoodsPriceUWork;
                                                //if (goodsUnitDataWork.GoodsMakerCd == tmp.GoodsMakerCd &&
                                                //    goodsUnitDataWork.GoodsNo == tmp.GoodsNo)
                                                //{
                                                DeleteOldPrice(tmp, ref sqlConnection, ref sqlTransaction);
                                                //    break;
                                                //}
                                            }
                                            //}

                                            status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                                        }

                                        //在庫マスタ更新処理 
                                        //if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        //{
                                        //    StockDB goodsStockDB = new StockDB();
                                        //    status = goodsStockDB.WriteStockProc(ref goodsStockList, ref sqlConnection, ref sqlTransaction);
                                        //}

                                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        //{
                                        //    //戻り値セット
                                        //    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                                        //}
                                    }
                                    break;
                                    #endregion
                                case "JoinPartsUWork": // 結合
                                    #region [ 結合 ]
                                    {
                                        JoinPartsUDB joinPartsUDB = new JoinPartsUDB();
                                        JoinPartsUWork tmp = (JoinPartsUWork)wkal[0];
                                        //status = joinPartsUDB.Write(ref wkal, ref sqlConnection, ref sqlTransaction);
                                        status = joinPartsUDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.JoinSourceMakerCode, tmp.JoinSourPartsNoWithH,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }

                                    }
                                    break;
                                    #endregion
                                case "GoodsSetWork": // 商品セット
                                    #region [ 商品セット ]
                                    {
                                        GoodsSetDB goodsSetDB = new GoodsSetDB();
                                        GoodsSetWork tmp = (GoodsSetWork)wkal[0];
                                        //status = goodsSetDB.WriteGoodsSetProc(ref wkal, ref sqlConnection, ref sqlTransaction);
                                        status = goodsSetDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.ParentGoodsMakerCd, tmp.ParentGoodsNo,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }
                                    }
                                    break;
                                    #endregion
                                //case "StockAdjustWork": // 在庫調整データワーク
                                //    #region [ 在庫調整データワーク ]
                                //    {
                                //        StockAdjustList = wkal;
                                //    }
                                //    break;
                                //    #endregion
                                //case "StockAdjustDtlWork": // 在庫調整明細データワーク
                                //    #region [ 在庫調整明細データワーク ]
                                //    {
                                //        StockAdjustDtlList = wkal;
                                //    }
                                //    break;
                                //    #endregion
                                case "RateWork": // 掛率ワーク
                                    #region [ 掛率ワーク ]
                                    RateDB rateDB = new RateDB();
                                    status = rateDB.WriteSubSectionProc(ref wkal, ref sqlConnection, ref sqlTransaction);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        retList.Add(wkal);
                                    }
                                    break;
                                    #endregion
                                case "TBOSearchUWork": // TBO
                                    #region [ TBO ]
                                    {
                                        TBOSearchUDB tBOSearchUDB = new TBOSearchUDB();
                                        TBOSearchUWork tmp = (TBOSearchUWork)wkal[0];
                                        status = tBOSearchUDB.DeleteInsert(ref wkal, tmp.EnterpriseCode, tmp.EquipGenreCode, tmp.EquipName,
                                                ref sqlConnection, ref sqlTransaction);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            retList.Add(wkal);
                                        }
                                    }
                                    break;
                                    #endregion
                            }
                        }
                        break;
                        #endregion

                    case "PartsSubstUWork":
                        #region [ 部品代替 ]
                        { // 部品代替
                            PartsSubstUDB partsSubstUDB = new PartsSubstUDB();
                            ArrayList retal = new ArrayList();
                            PartsSubstUWork partsSubstUWork = csaList[i] as PartsSubstUWork;
                            retal.Add(partsSubstUWork);
                            status = partsSubstUDB.Write(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as PartsSubstUWork);
                            }
                        }
                        break;
                        #endregion

                    case "JoinPartsUWork":
                        #region [ 結合 ]
                        {// 結合
                            JoinPartsUDB joinPartsUDB = new JoinPartsUDB();
                            ArrayList retal = new ArrayList();
                            JoinPartsUWork joinPartsUWork = csaList[i] as JoinPartsUWork;
                            retal.Add(joinPartsUWork);
                            status = joinPartsUDB.Write(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as JoinPartsUWork);
                            }
                        }
                        break;
                        #endregion

                    case "GoodsSetWork":
                        #region [ 商品セット ]
                        {// 商品セット
                            GoodsSetDB goodsSetDB = new GoodsSetDB();
                            ArrayList retal = new ArrayList();
                            GoodsSetWork goodsSetWork = csaList[i] as GoodsSetWork;
                            retal.Add(goodsSetWork);
                            status = goodsSetDB.WriteGoodsSetProc(ref retal, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retList.Add(retal[0] as GoodsSetWork);
                            }
                        }
                        break;
                        #endregion
                    case "CustomSerializeArrayList": // 在庫調整データ
                        #region [ 在庫調整データ,在庫調整明細データ、在庫データ ]
                        {
                            stockAdjustCsList = csaList[i] as CustomSerializeArrayList;
                        }
                        break;
                        #endregion

                    //Add Start 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
                    case "GoodsMngWork"://商品情報管理
                        #region [ 商品情報管理 ]
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                GoodsMngDB goodsMngDB = new GoodsMngDB();
                                GoodsMngWork goodsMngWork = csaList[i] as GoodsMngWork;
                                int SupplierCd = goodsMngWork.SupplierCd;
                                string supplierSnm = goodsMngWork.SupplierSnm; // ADD 2013/08/13 田建委 Redmdine#39794
                                int EditLogicalDeleteCode = goodsMngWork.LogicalDeleteCode;
                                GoodsMngWork serGoodsMngWork = goodsMngWork.Clone();
                                if (goodsMngWork.CreateDateTime.Equals(DateTime.MinValue))
                                {
                                    goodsMngDB.ReadProc(ref serGoodsMngWork, 0, ref sqlConnection, ref sqlTransaction);
                                }
                                if (serGoodsMngWork != null && serGoodsMngWork.SupplierCd != 0)
                                {
                                    goodsMngWork = serGoodsMngWork;
                                    goodsMngWork.SupplierCd = SupplierCd;
                                    goodsMngWork.SupplierSnm = supplierSnm; // ADD 2013/08/13 田建委 Redmdine#39794
                                    goodsMngWork.LogicalDeleteCode = 0;
                                }
                                ArrayList arr = new ArrayList();
                                arr.Add(goodsMngWork);
                                if (EditLogicalDeleteCode == 3)
                                {
                                    status = goodsMngDB.DeleteGoodsMngProc(arr, ref sqlConnection, ref sqlTransaction);
                                }
                                else
                                {
                                    status = goodsMngDB.WriteGoodsMngProc(ref arr, ref sqlConnection, ref sqlTransaction);
                                }

                                //----- ADD 2013/08/13 田建委 Redmdine#39794 ----->>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (EditLogicalDeleteCode != 3)
                                    {
                                        retList.Add(arr[0] as GoodsMngWork);
                                    }
                                }
                                //----- ADD 2013/08/13 田建委 Redmdine#39794 -----<<<<<
                            }
                        }
                        break;
                        #endregion
                    //Add End   2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!shipmentCntChangeFlg)　　　// ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
                {   // ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
                //if (goodsStockList.Count > 0)// && StockAdjustList != null && StockAdjustDtlList != null)
                if (stockAdjustCsList != null)// && StockAdjustList != null && StockAdjustDtlList != null)
                {
                    string retMsg;
                    //CustomSerializeArrayList lstStock = new CustomSerializeArrayList();
                    //lstStock.Add(goodsStockList);
                    //if (StockAdjustList != null)
                    //{
                    //    lstStock.Add(StockAdjustList);
                    //    lstStock.Add(StockAdjustDtlList);
                    //}
                    //object objStockAdjustCustList = lstStock;

                    object objStockAdjustCustList = stockAdjustCsList;

                    StockAdjustDB stockAdjustDB = new StockAdjustDB();
                    status = stockAdjustDB.WriteBatch(ref objStockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        stockAdjustCsList = objStockAdjustCustList as CustomSerializeArrayList;
                        goodsStockList.Clear();

                        for (int i = 0; i < stockAdjustCsList.Count; i++)
                        {
                            ArrayList retStockList = ListUtils.Find(stockAdjustCsList[i] as CustomSerializeArrayList, typeof(StockWork), ListUtils.FindType.Array) as ArrayList;

                            foreach (StockWork stockWork in retStockList)
                            {
                                //在庫仕入リモートより返された在庫リストに更新する
                                goodsStockList.Add(stockWork);
                            }

                            //if (lstStock[i] is ArrayList && ((ArrayList)lstStock[i])[0] is StockWork)
                            //{
                            //    goodsStockList = (ArrayList)lstStock[i];
                            //    break;
                            //}
                        }

                        //戻り値セット
                        //retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList)); // DEL 2013/02/08 田建委 Redmine#34640
                        //----- ADD 2013/02/08 田建委 Redmine#34640 ---------->>>>>
                        if (goodsList.Count == 0)
                        {
                            if (goodsStockList.Count > 0)
                            {
                                retList.Add(goodsStockList);
                            }
                        }
                        else
                        {
                            retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                        }
                        //----- ADD 2013/02/08 田建委 Redmine#34640 ----------<<<<<
                    }
                }
                else
                {
                    //戻り値セット
                    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                }
                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                }
                else
                {
                    // 貸出数変更の場合
                    if (goodsStockList != null)
                    {
                        StockDB stockDB = new StockDB();
                        string retMsg;
                        stockDB.WriteStock(ref goodsStockList, ref sqlConnection, ref sqlTransaction, out retMsg);

                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //戻り値セット
                        retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));
                    }
                }
                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<
            }

            // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //更新時の排他エラーがあるため、シェアチェックは別のステータスとする
            int chkstatus = 0;

            foreach (ShareCheckInfo info in infoList)
            {
                chkstatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
            }
            
            //更新のエラーがある場合は、そちらを優先して戻り値とする
            if (status == 0)
            {
                status = chkstatus;
            }
            // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        private int DeleteOldPrice(GoodsPriceUWork GoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            int status = 0;
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
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                status = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                sqlCommand.Dispose();
            }
            return status;
        }

        /// <summary>
        /// GoodsUWork,GoodsPriceUWork → 連結クラス 
        /// </summary>
        /// <param name="goodsList">商品マスタリスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <param name="goodsStockList">商品在庫リスト(情報がないときはNULL)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        private ArrayList CopyToGoodsUnitDataList(ArrayList goodsList, ArrayList goodsPriceList, ArrayList goodsStockList)
        {
            ArrayList al = new ArrayList();

            foreach (GoodsUWork goodsUWork in goodsList)
            {
                GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

                //商品マスタ
                goodsUnitDataWork.CreateDateTime = goodsUWork.CreateDateTime;
                goodsUnitDataWork.UpdateDateTime = goodsUWork.UpdateDateTime;
                goodsUnitDataWork.EnterpriseCode = goodsUWork.EnterpriseCode;
                goodsUnitDataWork.FileHeaderGuid = goodsUWork.FileHeaderGuid;
                goodsUnitDataWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode;
                goodsUnitDataWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1;
                goodsUnitDataWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2;
                goodsUnitDataWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode;
                goodsUnitDataWork.GoodsMakerCd = goodsUWork.GoodsMakerCd;
                goodsUnitDataWork.GoodsNo = goodsUWork.GoodsNo;
                goodsUnitDataWork.GoodsName = goodsUWork.GoodsName;
                goodsUnitDataWork.GoodsNameKana = goodsUWork.GoodsNameKana;
                goodsUnitDataWork.Jan = goodsUWork.Jan;
                goodsUnitDataWork.BLGoodsCode = goodsUWork.BLGoodsCode;
                goodsUnitDataWork.DisplayOrder = goodsUWork.DisplayOrder;
                goodsUnitDataWork.TaxationDivCd = goodsUWork.TaxationDivCd;
                goodsUnitDataWork.GoodsRateRank = goodsUWork.GoodsRateRank;
                goodsUnitDataWork.GoodsNoNoneHyphen = goodsUWork.GoodsNoNoneHyphen;
                goodsUnitDataWork.OfferDate = goodsUWork.OfferDate;
                goodsUnitDataWork.GoodsKindCode = goodsUWork.GoodsKindCode;
                goodsUnitDataWork.GoodsNote1 = goodsUWork.GoodsNote1;
                goodsUnitDataWork.GoodsNote2 = goodsUWork.GoodsNote2;
                goodsUnitDataWork.GoodsSpecialNote = goodsUWork.GoodsSpecialNote;
                goodsUnitDataWork.EnterpriseGanreCode = goodsUWork.EnterpriseGanreCode;
                goodsUnitDataWork.UpdateDate = goodsUWork.UpdateDate;
                goodsUnitDataWork.OfferDataDiv = goodsUWork.OfferDataDiv;
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                goodsUnitDataWork.OptKonmanGoodsMstCtl = goodsUWork.OptKonmanGoodsMstCtl;
                goodsUnitDataWork.Standard = goodsUWork.Standard;
                goodsUnitDataWork.Packing = goodsUWork.Packing;
                goodsUnitDataWork.PosNo = goodsUWork.PosNo;
                goodsUnitDataWork.MakerGoodsNo = goodsUWork.MakerGoodsNo;
                goodsUnitDataWork.CreateDateTimeA = goodsUWork.CreateDateTimeA;
                goodsUnitDataWork.UpdateDateTimeA = goodsUWork.UpdateDateTimeA;
                goodsUnitDataWork.FileHeaderGuidA = goodsUWork.FileHeaderGuidA;
                // -------- ADD END 2014/02/10 高陽 --------<<<<<

                goodsUnitDataWork.PriceList = new ArrayList();
                //価格マスタ更新項目セット
                foreach (GoodsPriceUWork goodsPrice in goodsPriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue &&
                        goodsUnitDataWork.GoodsNo == goodsPrice.GoodsNo &&
                        goodsUnitDataWork.GoodsMakerCd == goodsPrice.GoodsMakerCd)
                    {
                        //UsrGoodsPriceWork goodsPriceUWork = new UsrGoodsPriceWork();
                        GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                        goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                        goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
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

                        goodsUnitDataWork.PriceList.Add(goodsPriceUWork);
                    }
                }

                goodsUnitDataWork.StockList = new ArrayList();
                if (goodsStockList != null)
                {
                    //在庫マスタ更新項目セット
                    foreach (StockWork goodsStock in goodsStockList)
                    {
                        if (goodsUnitDataWork.GoodsNo == goodsStock.GoodsNo &&
                            goodsUnitDataWork.GoodsMakerCd == goodsStock.GoodsMakerCd)
                        {
                            StockWork stockUWork = new StockWork();

                            stockUWork.CreateDateTime = goodsStock.CreateDateTime;
                            stockUWork.UpdateDateTime = goodsStock.UpdateDateTime;
                            stockUWork.EnterpriseCode = goodsStock.EnterpriseCode;
                            stockUWork.FileHeaderGuid = goodsStock.FileHeaderGuid;
                            stockUWork.UpdEmployeeCode = goodsStock.UpdEmployeeCode;
                            stockUWork.UpdAssemblyId1 = goodsStock.UpdAssemblyId1;
                            stockUWork.UpdAssemblyId2 = goodsStock.UpdAssemblyId2;
                            stockUWork.LogicalDeleteCode = goodsStock.LogicalDeleteCode;
                            stockUWork.SectionCode = goodsStock.SectionCode;
                            stockUWork.SectionGuideNm = goodsStock.SectionGuideNm;
                            stockUWork.WarehouseCode = goodsStock.WarehouseCode;
                            stockUWork.WarehouseName = goodsStock.WarehouseName;
                            stockUWork.GoodsMakerCd = goodsStock.GoodsMakerCd;
                            stockUWork.GoodsNo = goodsStock.GoodsNo;
                            stockUWork.StockUnitPriceFl = goodsStock.StockUnitPriceFl;
                            stockUWork.SupplierStock = goodsStock.SupplierStock;
                            stockUWork.AcpOdrCount = goodsStock.AcpOdrCount;
                            stockUWork.MonthOrderCount = goodsStock.MonthOrderCount;
                            stockUWork.SalesOrderCount = goodsStock.SalesOrderCount;
                            stockUWork.StockDiv = goodsStock.StockDiv;
                            stockUWork.MovingSupliStock = goodsStock.MovingSupliStock;
                            stockUWork.ShipmentPosCnt = goodsStock.ShipmentPosCnt;
                            stockUWork.StockTotalPrice = goodsStock.StockTotalPrice;
                            stockUWork.LastStockDate = goodsStock.LastStockDate;
                            stockUWork.LastSalesDate = goodsStock.LastSalesDate;
                            stockUWork.LastInventoryUpdate = goodsStock.LastInventoryUpdate;
                            stockUWork.MinimumStockCnt = goodsStock.MinimumStockCnt;
                            stockUWork.MaximumStockCnt = goodsStock.MaximumStockCnt;
                            stockUWork.NmlSalOdrCount = goodsStock.NmlSalOdrCount;
                            stockUWork.SalesOrderUnit = goodsStock.SalesOrderUnit;
                            stockUWork.StockSupplierCode = goodsStock.StockSupplierCode;
                            stockUWork.GoodsNoNoneHyphen = goodsStock.GoodsNoNoneHyphen;
                            stockUWork.WarehouseShelfNo = goodsStock.WarehouseShelfNo;
                            stockUWork.DuplicationShelfNo1 = goodsStock.DuplicationShelfNo1;
                            stockUWork.DuplicationShelfNo2 = goodsStock.DuplicationShelfNo2;
                            stockUWork.PartsManagementDivide1 = goodsStock.PartsManagementDivide1;
                            stockUWork.PartsManagementDivide2 = goodsStock.PartsManagementDivide2;
                            stockUWork.StockNote1 = goodsStock.StockNote1;
                            stockUWork.StockNote2 = goodsStock.StockNote2;
                            stockUWork.ShipmentCnt = goodsStock.ShipmentCnt;
                            stockUWork.ArrivalCnt = goodsStock.ArrivalCnt;
                            stockUWork.StockCreateDate = goodsStock.StockCreateDate;
                            stockUWork.UpdateDate = goodsStock.UpdateDate;

                            goodsUnitDataWork.StockList.Add(stockUWork);
                        }
                    }
                }

                al.Add(goodsUnitDataWork);
            }

            return al;
        }

        /// <summary>
        /// 連結クラス → GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">連結リスト</param>
        /// <param name="goodsList">商品リスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <param name="goodsStockList">商品在庫リスト</param>
        /// <param name="flg">価格アップデートデートタイム設定フラグ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2014/02/10 高陽</br>
        /// <br>             商品マスタⅡの追加</br>
        /// </remarks>
        private ArrayList CopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList, ref ArrayList goodsStockList, bool flg)
        {
            ArrayList al = new ArrayList();
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
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                goodsUWork.OptKonmanGoodsMstCtl = goodsUnitDataWork.OptKonmanGoodsMstCtl;
                goodsUWork.Standard = goodsUnitDataWork.Standard;
                goodsUWork.Packing = goodsUnitDataWork.Packing;
                goodsUWork.PosNo = goodsUnitDataWork.PosNo;
                goodsUWork.MakerGoodsNo = goodsUnitDataWork.MakerGoodsNo;
                goodsUWork.CreateDateTimeA = goodsUnitDataWork.CreateDateTimeA;
                goodsUWork.UpdateDateTimeA = goodsUnitDataWork.UpdateDateTimeA;
                goodsUWork.FileHeaderGuidA = goodsUnitDataWork.FileHeaderGuidA;
                // -------- ADD END 2014/02/10 高陽 --------<<<<<

                if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd))
                    goodsList.Add(goodsUWork);
                goodsNo = goodsUWork.GoodsNo;
                goodsMakerCd = goodsUWork.GoodsMakerCd;

                //価格マスタ更新項目セット
                //foreach (UsrGoodsPriceWork goodsPrice in goodsUnitDataWork.PriceList)
                foreach (GoodsPriceUWork goodsPrice in goodsUnitDataWork.PriceList)
                {
                    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    {
                        GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                        goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                        if (flg == false)
                            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
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

                //在庫マスタ更新項目セット
                #region 在庫マスタ更新項目セット
                if (goodsUnitDataWork.StockList != null)
                {
                    foreach (StockWork goodsStock in goodsUnitDataWork.StockList)
                    {
                        StockWork stockUWork = new StockWork();

                        stockUWork.CreateDateTime = goodsStock.CreateDateTime;
                        stockUWork.UpdateDateTime = goodsStock.UpdateDateTime;
                        stockUWork.EnterpriseCode = goodsStock.EnterpriseCode;
                        stockUWork.FileHeaderGuid = goodsStock.FileHeaderGuid;
                        stockUWork.UpdEmployeeCode = goodsStock.UpdEmployeeCode;
                        stockUWork.UpdAssemblyId1 = goodsStock.UpdAssemblyId1;
                        stockUWork.UpdAssemblyId2 = goodsStock.UpdAssemblyId2;
                        stockUWork.LogicalDeleteCode = goodsStock.LogicalDeleteCode;
                        stockUWork.SectionCode = goodsStock.SectionCode;
                        stockUWork.SectionGuideNm = goodsStock.SectionGuideNm;
                        stockUWork.WarehouseCode = goodsStock.WarehouseCode;
                        stockUWork.WarehouseName = goodsStock.WarehouseName;
                        stockUWork.GoodsMakerCd = goodsStock.GoodsMakerCd;
                        stockUWork.GoodsNo = goodsStock.GoodsNo;
                        stockUWork.StockUnitPriceFl = goodsStock.StockUnitPriceFl;
                        stockUWork.SupplierStock = goodsStock.SupplierStock;
                        stockUWork.AcpOdrCount = goodsStock.AcpOdrCount;
                        stockUWork.MonthOrderCount = goodsStock.MonthOrderCount;
                        stockUWork.SalesOrderCount = goodsStock.SalesOrderCount;
                        stockUWork.StockDiv = goodsStock.StockDiv;
                        stockUWork.MovingSupliStock = goodsStock.MovingSupliStock;
                        stockUWork.ShipmentPosCnt = goodsStock.ShipmentPosCnt;
                        stockUWork.StockTotalPrice = goodsStock.StockTotalPrice;
                        stockUWork.LastStockDate = goodsStock.LastStockDate;
                        stockUWork.LastSalesDate = goodsStock.LastSalesDate;
                        stockUWork.LastInventoryUpdate = goodsStock.LastInventoryUpdate;
                        stockUWork.MinimumStockCnt = goodsStock.MinimumStockCnt;
                        stockUWork.MaximumStockCnt = goodsStock.MaximumStockCnt;
                        stockUWork.NmlSalOdrCount = goodsStock.NmlSalOdrCount;
                        stockUWork.SalesOrderUnit = goodsStock.SalesOrderUnit;
                        stockUWork.StockSupplierCode = goodsStock.StockSupplierCode;
                        stockUWork.GoodsNoNoneHyphen = goodsStock.GoodsNoNoneHyphen;
                        stockUWork.WarehouseShelfNo = goodsStock.WarehouseShelfNo;
                        stockUWork.DuplicationShelfNo1 = goodsStock.DuplicationShelfNo1;
                        stockUWork.DuplicationShelfNo2 = goodsStock.DuplicationShelfNo2;
                        stockUWork.PartsManagementDivide1 = goodsStock.PartsManagementDivide1;
                        stockUWork.PartsManagementDivide2 = goodsStock.PartsManagementDivide2;
                        stockUWork.StockNote1 = goodsStock.StockNote1;
                        stockUWork.StockNote2 = goodsStock.StockNote2;
                        stockUWork.ShipmentCnt = goodsStock.ShipmentCnt;
                        stockUWork.ArrivalCnt = goodsStock.ArrivalCnt;
                        stockUWork.StockCreateDate = goodsStock.StockCreateDate;
                        stockUWork.UpdateDate = goodsStock.UpdateDate;

                        goodsStockList.Add(stockUWork);
                    }
                }
                #endregion
            }

            return al;
        }

        // 2008.06.12 add start ------------------------------->>
        /// <summary>
        /// 連結クラス → GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">連結リスト</param>
        /// <param name="goodsList">商品リスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private int ReadCopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int status = 0;
            string goodsNo = "";
            int goodsMakerCd = 0;

            string sqlTxt = string.Empty;
            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
            sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
            sqlTxt += "WHERE" + Environment.NewLine;
            sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

            //Selectコマンドの生成
            sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            try
            {
                foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
                {
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUnitDataWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    int flg = 0;
                    if (myReader.Read() == false)
                    {
                        flg = 1;
                    }
                    else
                    {
                        int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        if (logicalDeleteCode == 1)
                        {
                            flg = 2;
                        }
                    }
                    if (flg != 0) // 商品なし又は論理削除状態か
                    {
                        GoodsUWork goodsUWork = new GoodsUWork();

                        //商品マスタ更新項目セット
                        if (flg == 1)
                        {
                            goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
                            goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
                            goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
                            goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
                            goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
                            goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
                            goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
                            goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                        }
                        else
                        {
                            goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            goodsUWork.LogicalDeleteCode = 0;
                            myReader.Close();
                        }
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

                        if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd))
                        {
                            goodsList.Add(goodsUWork);
                        }
                        goodsNo = goodsUWork.GoodsNo;
                        goodsMakerCd = goodsUWork.GoodsMakerCd;

                        //価格マスタ更新項目セット
                        if (goodsUnitDataWork.PriceList != null)
                        {
                            foreach (GoodsPriceUWork goodsPrice in goodsUnitDataWork.PriceList)
                            {
                                if (goodsPrice.PriceStartDate != DateTime.MinValue)
                                {
                                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                                    goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
                                    goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
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
                                    if (flg == 2)
                                    {
                                        DeleteOldPrice(goodsPrice, ref sqlConnection, ref sqlTransaction);
                                    }
                                }
                            }

                        }
                    }
                    if (myReader != null && myReader.IsClosed == false)
                        myReader.Close();
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null && myReader.IsClosed == false)
                    myReader.Close();
            }

            return status;
        }
        // 2008.06.12 add end ---------------------------------<<

        /// <summary>
        /// 商品マスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int LogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 0);
        }

        /// <summary>
        /// 論理削除商品マスタ情報を復活します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品マスタ情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int RevivalLogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 1);
        }

        /// <summary>
        /// 商品マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        private int LogicalDeleteGoodsRelation(ref object goodsWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();
                ArrayList goodsStockList = new ArrayList();

                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //商品マスタ
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }

                if (goodsUnitDataList != null)
                {
                    CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref goodsStockList, false);
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //商品マスタ更新処理
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.LogicalDeleteGoodsUProc(ref goodsList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                //価格マスタ更新処理
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.LogicalDeleteGoodsPriceProc(ref goodsPriceList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                //在庫マスタ更新処理
                //if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    StockDB goodsStockDB = new StockDB();
                //    status = goodsStockDB.LogicalDeleteStockProc(ref goodsStockList, procMode, ref sqlConnection, ref sqlTransaction);
                //}

                retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, goodsStockList));

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "GoodsDB.LogicalDeleteGoods :" + procModestr);

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
        /// 商品マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">商品マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品マスタ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int DeleteRelation(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRelationProc(paraobj, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // コミット
                {
                    sqlTransaction.Commit();
                }
                else // ロールバック
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        private int DeleteRelationProc(object paraobj, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList goodsUnitDataList = null;
            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();
            ArrayList goodsStockList = new ArrayList();
            ArrayList RateWork = new ArrayList();

            //パラメータのキャスト
            CustomSerializeArrayList csaList = paraobj as CustomSerializeArrayList;
            if (csaList == null)
                return status;

            for (int i = 0; i < csaList.Count; i++)
            {
                ArrayList wkal = csaList[i] as ArrayList;
                if (wkal != null && wkal.Count > 0)
                {
                    if (wkal[0] is GoodsUnitDataWork) // 商品マスタ
                    {
                        goodsUnitDataList = wkal;

                        if (goodsUnitDataList != null)
                        {
                            CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref goodsStockList, false);
                        }

                        //商品マスタ削除処理
                        if (goodsList != null)
                        {
                            GoodsUDB goodsUDB = new GoodsUDB();
                            status = goodsUDB.DeleteGoodsUProc(goodsList, ref sqlConnection, ref sqlTransaction);
                        }

                        //価格マスタ削除処理
                        if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                            status = goodsPriceDB.DeleteGoodsPriceProc(goodsPriceList, ref sqlConnection, ref sqlTransaction);
                        }

                        //在庫マスタ更新処理(MAZAI04134RでなくMAZAI04364Rを使うように修正:在庫は削除もWriteBatchで処理)
                        if ((goodsStockList != null && goodsStockList.Count > 0) && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string retMsg;
                            StockAdjustDB stockAdjustDB = new StockAdjustDB();
                            CustomSerializeArrayList stockAdjustcsList = new CustomSerializeArrayList();
                            CustomSerializeArrayList lstStock = new CustomSerializeArrayList();

                            lstStock.Add(goodsStockList);

                            stockAdjustcsList.Add(lstStock);
                            object objStockAdjustCustList = stockAdjustcsList;
                            status = stockAdjustDB.WriteBatch(ref objStockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);
                            // 削除なので後処理は不要
                        }
                    }
                    else if (wkal[0] is RateWork) // 掛率ワーク
                    {
                        RateDB rateDB = new RateDB();
                        status = rateDB.DeleteSubSectionProc(wkal, ref sqlConnection, ref sqlTransaction);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        break;
                }
            }

            return status;
        }
        #endregion

        // 2008.06.12 add start --------------------------------->>
        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        /// <br></br>
        public int ReadNewWriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            try
            {
                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null)
                    return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = ReadNewWriteRelationProc(ref csaList, ref retList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)    // コミット
                {
                    sqlTransaction.Commit();
                }
                else    // ロールバック
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }

                //戻り値セット
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <param name="sqlConnection">コンネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        public int ReadNewWriteRelation(ref object goodsWork,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //パラメータのキャスト
            CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            if (csaList == null)
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            status = ReadNewWriteRelationProc(ref csaList, ref retList, sqlConnection, sqlTransaction);
            //戻り値セット
            goodsWork = retList;
            return status;
        }

        private int ReadNewWriteRelationProc(ref CustomSerializeArrayList csaList, ref CustomSerializeArrayList retList,
            SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList goodsUnitDataList = null;
            ArrayList goodsList = new ArrayList();
            ArrayList goodsPriceList = new ArrayList();

            for (int i = 0; i < csaList.Count; i++)
            {
                ArrayList wkal = csaList[i] as ArrayList;
                if (wkal != null && wkal.Count > 0)
                {
                    //商品マスタ
                    if (wkal[0] is GoodsUnitDataWork)
                        goodsUnitDataList = wkal;

                    // 商品存在確認
                    if (goodsUnitDataList != null)
                    {
                        status = ReadCopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref sqlConnection, ref sqlTransaction);
                    }

                    //商品マスタ更新処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsList.Count > 0)
                    {
                        GoodsUDB goodsUDB = new GoodsUDB();
                        status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                    }

                    //価格マスタ更新処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceList.Count > 0)
                    {
                        ArrayList writeErrorList = new ArrayList();
                        GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                        status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                    }

                    retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList, null));
                }
            }

            return status;
        }
        // 2008.06.12 add end -----------------------------------<<

        #endregion

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        #region 指定された条件の商品構成取得情報LISTを戻します(商品在庫一括登録修正用)
        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します(商品在庫一括登録修正用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="targetDiv">対象区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref retObj, paraObj, readMode, maxCount, targetDiv,logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)(商品在庫一括登録修正用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="targetDiv">対象区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProcP(ref retObj, paraObj, readMode, maxCount, targetDiv, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        private int SearchProcP(ref object retObj, object paraObj, int readMode, int maxCount, int targetDiv, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsUCndtnWork goodsrelationdataWork = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsUCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsUCndtnWork;
            }

            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();
                switch (wktype.Name)
                {
                    //売上全体設定
                    case "SalesTtlStWork":
                        {
                            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
                            ArrayList retal = new ArrayList();
                            SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
                            salesTtlStWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    //商品中分類
                    case "GoodsGroupUWork":
                        {
                            GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                            ArrayList retal = new ArrayList();
                            GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                            goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //優良設定
                    case "PrmSettingUWork":
                        {
                            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                            ArrayList retal = new ArrayList();
                            PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                            prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //メーカー
                    case "MakerUWork":
                        {
                            MakerUDB makerUDB = new MakerUDB();
                            ArrayList retal = null;
                            MakerUWork makerUWork = new MakerUWork();
                            makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BLグループ 
                    case "BLGroupUWork":
                        {
                            BLGroupUDB bLGroupUDB = new BLGroupUDB();
                            ArrayList retal = new ArrayList();
                            BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                            bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //BLコード               
                    case "BLGoodsCdUWork":
                        {
                            BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                            ArrayList retal = null;
                            BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                            bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //商品管理
                    case "GoodsMngWork":
                        {
                            GoodsMngDB goodsMngDB = new GoodsMngDB();
                            ArrayList retal = new ArrayList();
                            GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                            goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    //ユーザーガイド
                    case "UserGdBdUWork":
                        {
                            UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                            //UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
                            UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
                            usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

                            //商品大分類(ユーザーガイド ガイド区分:70)
                            ArrayList retal = null;
                            usrGdBdLst[0].EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 70;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //自社分類(ユーザーガイド ガイド区分:41)
                            retal = null;
                            usrGdBdLst[0].UserGuideDivCd = 41;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //販売区分(ユーザーガイド ガイド区分:71)
                            retal = null;
                            usrGdBdLst[0].UserGuideDivCd = 71;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                    // 離島価格
                    case "IsolIslandPrcWork":
                        {
                            IsolIslandPrcDB isolIslandPrcDB = new IsolIslandPrcDB();
                            ArrayList retal = new ArrayList();
                            IsolIslandPrcWork isolIslandPrcWork = paraList[i] as IsolIslandPrcWork;
                            isolIslandPrcWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = isolIslandPrcDB.Search(ref retal, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    // 仕入先
                    case "SupplierWork":
                        {
                            SupplierDB supplierDB = new SupplierDB();
                            ArrayList retal = new ArrayList();
                            SupplierWork supplierWork = paraList[i] as SupplierWork;
                            supplierWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                            status = supplierDB.Search(out retal, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;

                    //商品連結
                    case "GoodsUnitDataWork":
                        {
                            ArrayList retal = null;
                            status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, maxCount, targetDiv, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;

                }
            }

            retObj = retCSAList;

            // ↓ 2008.03.24 980081 c
            //return status;

            // 2011/11/29 Add >>>
            // コマンドタイムアウトの場合、ステータスをそのまま返す
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                return status;
            // 2011/11/29 Add <<<
            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ↑ 2008.03.24 980081 c
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)(商品在庫一括登録修正用)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">検索結果</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsrelationdataWork">抽出条件</param>
        /// <param name="paralist">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="maxCount">取得MAX件数(商品情報)</param>
        /// <param name="targetDiv">対象区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 田建委</br>
        /// <br>管理番号   : 11170052-00</br>
        /// <br>           : Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// </remarks>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork,
            ArrayList paralist, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchGoodsURelationDataProcP(out goodsrelationdataWorkList, trgType, goodsrelationdataWork, paralist, readMode, maxCount, targetDiv,logicalMode, 0, ref sqlConnection);
        }

        private int SearchGoodsURelationDataProcP(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsUCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, int maxCount, int targetDiv,ConstantManagement.LogicalMode logicalMode, int stockSearchDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string sMaxCount = string.Empty;
            if (maxCount != 0) sMaxCount = "TOP(" + maxCount.ToString() + ") ";
            // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            goodsrelationdataWorkList = new ArrayList();
            ArrayList retList = new ArrayList();
            ArrayList reList = new ArrayList();

            string selectstring = "";
            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;

                if (targetDiv == 0 || targetDiv == 1)
                {
                    selectstring += "SELECT " + sMaxCount + "GOODS.CREATEDATETIMERF" + Environment.NewLine;
                }
                if (targetDiv == 2 || targetDiv == 3)
                {
                    selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                }
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                //sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine; //DEL yangyi 2013/04/25 Redmine#35018
                sqlCommand.CommandText += "ORDER BY GOODS.ENTERPRISECODERF ASC, GOODS.GOODSNORF ASC, GOODS.GOODSMAKERCDRF ASC" + Environment.NewLine;//ADD yangyi 2013/04/25 Redmine#35018

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();


                // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                // ADD gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                //ArrayList priceList = new ArrayList();
                //ArrayList usrGoodsPrice;
                // ADD gezh 2013/01/24 Redmine#33361 改修案② --------<<<<<
                // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();
                Dictionary<string, ArrayList> stockDic = new Dictionary<string, ArrayList>();

                ArrayList usrGoodsPrice;

                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));// DEL 2014.02.10 高陽
                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader, false));// ADD 2014.02.10 高陽

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    // ADD gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                    //GoodsUnitDataWork usrGoodsWork = (GoodsUnitDataWork)al[al.Count - 1];
                    //UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    //wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    //wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    //wk.PrtsNo = usrGoodsWork.GoodsNo;
                    //priceList.Add(wk);
                    // ADD gezh 2013/01/24 Redmine#33361 改修案② --------<<<<<
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

                }
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 改修案② -------->>>>>
                ArrayList priceList = new ArrayList();
                ArrayList usrGoodsPrice;
                foreach (GoodsUnitDataWork usrGoodsWork in al)
                {
                    UsrPartsNoSearchCondWork wk = new UsrPartsNoSearchCondWork();
                    wk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    wk.MakerCode = usrGoodsWork.GoodsMakerCd;
                    wk.PrtsNo = usrGoodsWork.GoodsNo;
                    priceList.Add(wk);
                }
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 改修案② ---------- */
                myReader.Close();
                //status = SearchUsrGoodsPriceProc(priceList, out usrGoodsPrice, logicalMode, sqlConnection);  //DEL yangyi 2013/03/18 Redmine#34962 
                status = SearchUsrGoodsPriceAllProc(goodsrelationdataWork, out usrGoodsPrice, logicalMode, sqlConnection); //ADD yangyi 2013/03/18 Redmine#34962
                if (status == 0)
                {
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    //// ADD gezh 2013/01/24 Redmine#33361 改修案③ -------->>>>>
                    //Dictionary<string, ArrayList> priceDic = new Dictionary<string, ArrayList>();

                    //foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    //{
                    //    ArrayList priceListNew;

                    //    string key = prc.GoodsMakerCd + prc.GoodsNo;

                    //    if (priceDic.TryGetValue(key, out priceListNew))
                    //    {
                    //        priceListNew.Add(prc);
                    //    }
                    //    else
                    //    {
                    //        priceListNew = new ArrayList();
                    //        priceListNew.Add(prc);
                    //        priceDic.Add(key, priceListNew);
                    //    }
                    //}
                    //// ADD gezh 2013/01/24 Redmine#33361 改修案③ --------<<<<<
                    //foreach (GoodsUnitDataWork usrGoodsWork in al)
                    //{
                    //    /* ---------------- DEL gezh 2013/01/24 Redmine#33361 改修案③ -------->>>>>
                    //    usrGoodsWork.PriceList = new ArrayList();
                    //    //foreach (UsrGoodsPriceWork prc in usrGoodsPrice)
                    //    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    //    {
                    //        if (usrGoodsWork.GoodsMakerCd == prc.GoodsMakerCd &&
                    //            usrGoodsWork.GoodsNo == prc.GoodsNo)
                    //        {
                    //            usrGoodsWork.PriceList.Add(prc);
                    //        }
                    //    }
                    //    <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 改修案③ ---------- */
                    //    // ADD gezh 2013/01/24 Redmine#33361 -------->>>>>
                    //    ArrayList priceListNew;
                    //    usrGoodsWork.PriceList = new ArrayList();
                    //    string key = usrGoodsWork.GoodsMakerCd + usrGoodsWork.GoodsNo;
                    //    if (priceDic.TryGetValue(key, out priceListNew))
                    //    {
                    //        usrGoodsWork.PriceList.AddRange(priceListNew);
                    //    }
                    //    // ADD gezh 2013/01/24 Redmine#33361 --------<<<<<
                    //}
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    foreach (GoodsPriceUWork prc in usrGoodsPrice)
                    {
                        ArrayList priceListNew;

                        string key = prc.GoodsMakerCd + "," + prc.GoodsNo;

                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            priceListNew.Add(prc);
                        }
                        else
                        {
                            priceListNew = new ArrayList();
                            priceListNew.Add(prc);
                            priceDic.Add(key, priceListNew);
                        }
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                }
                else
                {
                    foreach (GoodsUnitDataWork usrGoodsWork in al)
                    {
                        usrGoodsWork.PriceList = new ArrayList();
                    }
                }

                // -- ADD 2011/03/17 ------------->>>
                if (stockSearchDiv == 0)
                {
                    // -- ADD 2011/03/17 -------------<<<
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    //foreach (GoodsUnitDataWork usrGoodsWork in al)
                    //{
                    //    ArrayList stockRetList;
                    //    StockDB stockDB = new StockDB();

                    //    StockWork stockWk = new StockWork();
                    //    stockWk.EnterpriseCode = usrGoodsWork.EnterpriseCode;
                    //    stockWk.GoodsMakerCd = usrGoodsWork.GoodsMakerCd;
                    //    stockWk.GoodsNo = usrGoodsWork.GoodsNo;
                    //    status = stockDB.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);
                    //    if (status == 0)
                    //    {
                    //        usrGoodsWork.StockList = stockRetList;
                    //    }
                    //    else
                    //    {
                    //        usrGoodsWork.StockList = new ArrayList();
                    //    }
                    //}
                    // --- DEL yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    if (al.Count > 0)
                    {
                        StockDB stockDB = new StockDB();
                        StockWork stockWk = new StockWork();

                        ArrayList stockRetList;
                        stockWk.EnterpriseCode = ((GoodsUnitDataWork)al[0]).EnterpriseCode;
                        stockWk.GoodsMakerCd = goodsrelationdataWork.GoodsMakerCd;
                        stockWk.GoodsNo = goodsrelationdataWork.GoodsNo;

                        //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
                        stockWk.SectionCode = goodsrelationdataWork.AddUpSectionCode; // 管理拠点コード
                        stockWk.WarehouseCode = goodsrelationdataWork.WarehouseCode; // 倉庫コード
                        //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<

                        status = this.SearchStockProc(out stockRetList, stockWk, 0, logicalMode, ref sqlConnection);

                        if (status == 0)
                        {
                            foreach (StockWork prc in stockRetList)
                            {
                                ArrayList stockListNew;
                                string key = prc.GoodsMakerCd + "," + prc.GoodsNo;

                                if (stockDic.TryGetValue(key, out stockListNew))
                                {
                                    stockListNew.Add(prc);
                                }
                                else
                                {
                                    stockListNew = new ArrayList();
                                    stockListNew.Add(prc);
                                    stockDic.Add(key, stockListNew);
                                }
                            }
                        }
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                }  // -- ADD 2011/03/17

                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>

                if (targetDiv == 0 || targetDiv == 1 || targetDiv == 3)
                {
                    foreach (GoodsUnitDataWork work in al)
                    {
                        ArrayList priceListNew;
                        work.PriceList = new ArrayList();
                        string key = work.GoodsMakerCd + "," + work.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            work.PriceList.AddRange(priceListNew);
                        }

                        if (stockSearchDiv == 0)
                        {
                            ArrayList stockListNew;
                            work.StockList = new ArrayList();

                            if (stockDic.TryGetValue(key, out stockListNew))
                            {
                                work.StockList.AddRange(stockListNew);
                            }
                        }
                    }
                    goodsrelationdataWorkList = al;
                }

                if (targetDiv == 2)
                {
                    int num = 0;　//在庫件数

                    foreach (GoodsUnitDataWork work in al)
                    {
                        // --- ADD yangyi 2013/04/27 for Redmine#35018 ------->>>>>>>>>>>
                        if (work.LogicalDeleteCode!=0)
                        {
                            continue;
                        }
                        // --- ADD yangyi 2013/04/27 for Redmine#35018 -------<<<<<<<<<<<

                        //在庫数＞最大制限件数
                        if (num >= maxCount)
                        {
                            break;
                        }

                        ArrayList priceListNew;
                        work.PriceList = new ArrayList();
                        string key = work.GoodsMakerCd + "," + work.GoodsNo;
                        if (priceDic.TryGetValue(key, out priceListNew))
                        {
                            work.PriceList.AddRange(priceListNew);
                        }

                        if (stockSearchDiv == 0)
                        {
                            ArrayList stockListNew;
                            work.StockList = new ArrayList();

                            if (stockDic.TryGetValue(key, out stockListNew))
                            {
                                num = num + stockListNew.Count; //在庫件数の計算
                                work.StockList.AddRange(stockListNew);
                                retList.Add(work);   //ADD yangyi 2013/04/23 Redmine#35018
                            }
                        }
                        //retList.Add(work);     //DEL yangyi 2013/04/23 Redmine#35018
                    }   

                    goodsrelationdataWorkList = retList;
                    
                }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
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
            }

            return status;
        }


        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="stockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013.04.01</br>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
        /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
        private int SearchStockProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
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
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
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
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                if (!string.IsNullOrEmpty(stockWork.GoodsNo))
                {
                    selectTxt += " LEFT JOIN GOODSURF GOODS ON GOODS.GOODSNORF = STOCK.GOODSNORF " + Environment.NewLine;
                    selectTxt += " AND GOODS.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                    selectTxt += " AND GOODS.ENTERPRISECODERF = STOCK.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //企業コード
                sqlCommand.CommandText += " WHERE STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //拠点コード
                if (string.IsNullOrEmpty(stockWork.SectionCode) == false)
                {
                    sqlCommand.CommandText += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                }

                //倉庫コード
                if (string.IsNullOrEmpty(stockWork.WarehouseCode) == false)
                {
                    sqlCommand.CommandText += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                }

                //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.8 ----->>>>>
                ////商品番号
                //if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
                //{
                //    sqlCommand.CommandText += " AND GOODS.GOODSNONONEHYPHENRF LIKE @FINDGOODSNO " + Environment.NewLine;
                //    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //    paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo + "%");
                //}
                //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.8 -----<<<<<

                //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.8 ----->>>>>
                //商品番号
                if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
                {
                    //ハイフン無し品番に変換
                    string goodsNoNoneHyphen = stockWork.GoodsNo.Replace("-", "");

                    //前方一致検索
                    goodsNoNoneHyphen = goodsNoNoneHyphen + "%";

                    //ハイフン無し品番完全一致検索の場合
                    sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);

                }
                //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.8 -----<<<<<

                //商品メーカーコード
                if (stockWork.GoodsMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                }

                sqlCommand.CommandTimeout = 60;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, 0));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">0:別マスタからの取得項目もセット</param>
        /// <returns>StockWork</returns>
        /// <remarks>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013.04.01</br>
        /// </remarks>
        public StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            StockWork wkStockWork = new StockWork();

            #region クラスへ格納
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
            wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
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

            if (mode == 0)
            {
                wkStockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            #endregion

            return wkStockWork;
        }

        /// <summary>
        /// 定価情報取得
        /// </summary>
        /// <param name="goodsrelationdataWork">ユーザー結合検索抽出条件クラスワーク</param>
        /// <param name="usrGoodsPrice">商品価格List</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns></returns>
        private int SearchUsrGoodsPriceAllProc(GoodsUCndtnWork goodsrelationdataWork, out ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            usrGoodsPrice = new ArrayList();
            try
            {
                status = ExecutePriceQueryAll(goodsrelationdataWork, usrGoodsPrice, logicalMode, sqlConnection);

                if (status != 0) return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UsrJoinPartsSearchDB.SearchUsrGoodsPriceにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 定価情報取得
        /// </summary>
        /// <param name="goodsrelationdataWork">抽出条件クラスワーク</param>
        /// <param name="usrGoodsPrice">商品価格List</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <br>Update Note: K2013/07/23 凌小青</br>
        /// <br>管理番号   : 10801804-00 Redmine#38624</br>
        /// <br>           : 商品在庫一括修正の対応（№34962のデグレ）</br>
        /// <br>Update Note: K2013/10/08 gezh</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>           : Redmine#38624 　商品在庫一括修正の障害№17対応</br>
        /// <br>Update Note: 2020/06/18 譚洪</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <returns></returns>
        private int ExecutePriceQueryAll(GoodsUCndtnWork goodsrelationdataWork, ArrayList usrGoodsPrice, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = 0;
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
                        + "FROM GOODSPRICEURF ";

            //if (!string.IsNullOrEmpty(goodsrelationdataWork.GoodsNo))// DEL BY 凌小青 K2013/07/23 for Redmine#38624
            if (!string.IsNullOrEmpty(goodsrelationdataWork.GoodsNo) || goodsrelationdataWork.BLGoodsCode > 0) // ADD BY 凌小青 K2013/07/23 for Redmine#38624
            {
                selectstr += " LEFT JOIN GOODSURF GOODS ON GOODS.GOODSNORF = GOODSPRICEURF.GOODSNORF ";
                selectstr += " AND GOODS.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF ";
                selectstr += " AND GOODS.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF ";
            }

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                sqlCommand.CommandText += "WHERE GOODSPRICEURF.ENTERPRISECODERF = @FINDENTERPRISECODE";

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND GOODSPRICEURF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE  ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND GOODSPRICEURF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE  ";
                }

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar)).Value
                    = SqlDataMediator.SqlSetString(goodsrelationdataWork.EnterpriseCode);

                ((SqlParameter)sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int)).Value
                                    = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //商品コード
                if (SqlDataMediator.SqlSetString(goodsrelationdataWork.GoodsNo) != DBNull.Value)
                {
                    if (goodsrelationdataWork.GoodsNoSrchTyp != 0)
                    {
                        //ハイフン無し品番に変換
                        string goodsNoNoneHyphen = goodsrelationdataWork.GoodsNo.Replace("-", "");

                        if (goodsrelationdataWork.GoodsNoSrchTyp != 4)
                        {
                            sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                            //前方一致検索の場合
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                            //後方一致検索の場合
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                            //あいまい検索の場合
                            if (goodsrelationdataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                        }
                        else
                        {
                            //ハイフン無し品番完全一致検索の場合
                            sqlCommand.CommandText += ("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                        }

                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                    }
                    else
                    {
                        sqlCommand.CommandText += ("AND GOODS.GOODSNORF=@GOODSNO ");

                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsrelationdataWork.GoodsNo);
                    }

                }

                //メーカーコード
                if (goodsrelationdataWork.GoodsMakerCd > 0)
                {
                    sqlCommand.CommandText += ("AND GOODSPRICEURF.GOODSMAKERCDRF=@GOODSMAKERCD ");
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsrelationdataWork.GoodsMakerCd);
                }

                //BL商品コード
                if (goodsrelationdataWork.BLGoodsCode > 0)
                {
                    sqlCommand.CommandText += ("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsrelationdataWork.BLGoodsCode);
                }
                sqlCommand.CommandText += "ORDER BY GOODSPRICEURF.PRICESTARTDATERF DESC";  // 価格開始日降順表示　　// ADD BY gezh K2013/10/08 for Redmine#38624

                sqlCommand.CommandTimeout = 60;

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
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
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
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        #endregion
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
    }
}

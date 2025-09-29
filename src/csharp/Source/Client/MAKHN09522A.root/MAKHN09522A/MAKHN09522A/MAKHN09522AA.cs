using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品管理情報マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>Note       : 商品管理情報の設定を行います。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2007.08.27</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.02.28 980035 金沢 貞義</br>
    /// <br>           : 不具合対応</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.03.28 30167 上野　弘貴</br>
    ///	<br>		   : 商品コード大文字小文字を区別するよう修正</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/11/25 30517 夏野 駿希</br>
    ///	<br>		   : MANTIS:13894 品名・メーカー名称が表示されるように修正</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>Update Note: 2012/09/21 袁磊 redmine#32367</br>
    /// <br>管 理 番 号: 10801804-00</br>
    ///	<br>		   : 拠点＋中分類＋メーカー＋BLコードと拠点＋中分類＋メーカーの追加</br>
    /// <br>--------------------------------------------------------------------</br>
    /// </remarks>
    public class GoodsMngAcs
    {
        #region ◆Public Members

        /// <summary>画面表示データテーブル格納データセットクラス</summary>
        public DataSet GoodsMngDataSet;
        /// <summary>全データ格納データセットクラス</summary>
        public DataSet ChildGoodsInfoDataSet;

        #region ●DataTable用名称情報
        /// <summary>データテーブルカラム名称(G
        /// UID)</summary>
        public static readonly string FILEHEADERGUID_TITLE = "Guid";
        /// <summary>データテーブルカラム名称(削除日)</summary>
        public static readonly string DELETE_DATE = "削除日";
        /// <summary>データテーブルカラム名称(論理削除区分)</summary>
        public static readonly string LOGICALDELETE_TITLE = "論理削除区分";
        /// <summary>データテーブルカラム名称(拠点コード)</summary>
        public static readonly string SECTIONCODE_TITLE = "拠点コード";
        /// <summary>データテーブルカラム名称(拠点ガイド名称)</summary>
        public static readonly string SECTIONGUIDENM_TITLE = "拠点名";
        /// <summary>データテーブルカラム名称(商品メーカーコード)</summary>
        public static readonly string GOODSMAKERCD_TITLE = "商品メーカーコード";
        /// <summary>データテーブルカラム名称(商品メーカー名称)</summary>
        public static readonly string MAKERNAME_TITLE = "メーカー名";
        /// <summary>データテーブルカラム名称(商品番号)</summary>
        public static readonly string GOODSNO_TITLE = "品番";
        /// <summary>データテーブルカラム名称(商品名称)</summary>
        public static readonly string GOODSNAME_TITLE = "品名";
        /// <summary>データテーブルカラム名称(BLコード)</summary>
        public static readonly string BLGOODSCODE_TITLE = "BLコード";
        /// <summary>データテーブルカラム名称(BLコード名称)</summary>
        public static readonly string BLGOODSNAME_TITLE = "BLコード名";
        /// <summary>データテーブルカラム名称(発注先コード１)</summary>
        public static readonly string SUPPLIERCD1_TITLE = "仕入先コード";
        /// <summary>データテーブルカラム名称(発注先名称１)</summary>
        public static readonly string SUPPLIERSNM_TITLE = "仕入先名";
        /// <summary>データテーブルカラム名称(発注ロット１)</summary>
        public static readonly string SUPPLIERLOT1_TITLE = "流通ロット";
        /// <summary>データテーブルカラム名称(商品中分類コード)</summary>
        public static readonly string GOODSMGROUP_TITLE = "商品中分類コード";
        /// <summary>データテーブルカラム名称(商品中分類名称)</summary>
        public static readonly string GOODSMGROUPNM_TITLE = "中分類名";



        /// <summary>データテーブル名称</summary>
        public static readonly string GOODSMNG_TABLE = "GoodsMng_Table";
        #endregion

        #endregion


        #region ◆Private Members

        #region ●Static Members
        /// <summary>商品管理情報マスタクラスSearchフラグ</summary>
        private static bool _searchFlg = false;
        /// <summary>商品管理情報ローカルキャッシュ用データディクショナリークラス</summary>
        private static Dictionary<Guid, GoodsMngWork> GoodsMngWorkDictionary;
        /// <summary>商品管理情報ローカルキャッシュ用リストクラス</summary>
        private static List<GoodsMngWork> GoodsMngWorkList;
        #endregion

        #region ●Const
        /// <summary>削除日表示形式</summary>
        private const string DATATIME_FORM = "ggYY/MM/DD";
        /// <summary>ガイド用XMLのファイル名</summary>
        private const string GUIDEXML_TITLE = "GOODSSETGUIDEPARENT.XML";
        #endregion

        #region ●Normal Members

        /// <summary>商品管理情報リモートオブジェクト格納バッファ</summary>
        private IGoodsMngDB _iGoodsMngDB = null;
        /// <summary>画面表示データテーブルクラス</summary>
        //private DataTable GoodsMngDataTable;

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private GoodsMngLcDB _goodsMngLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        #endregion

        #endregion

        GoodsAcs goodsAcs;
        MakerAcs makerAcs;
        BLGoodsCdAcs bLGoodsCdAcs;

        #region ◆Constructor

        /// <summary>
        /// 商品管理情報アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// Note            : 商品管理情報取得のためのリモートオブジェクトを記述します。<br />
        /// Programmer      : 980035 金沢　貞義<br />
        /// Date            : 2007.08.27<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public GoodsMngAcs()
        {
            try
            {
                // 商品管理情報マスタリモートオブジェクト取得
                this._iGoodsMngDB = (IGoodsMngDB)MediationGoodsMngDB.GetGoodsMngDB();

            }
            catch (Exception)
            {
                this._iGoodsMngDB = null;
                //this._iGoodsMngLcDB = null;
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._goodsMngLcDB = new GoodsMngLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end


            goodsAcs = new GoodsAcs();
            makerAcs = new MakerAcs();
            bLGoodsCdAcs = new BLGoodsCdAcs();

            #region ●画面表示用DataTable列設定
            // 下記の順番が実際の表示の順番になる
            /************************************
            *①削除日                           *
            *②論理削除区分                     *
            *③拠点コード                       *
            *④拠点ガイド名称                   *
            *⑤商品メーカーコード               *
            *⑥メーカー名称                     *
            *⑦商品コード                       *
            *⑧商品名称                         *
            *⑨BLコード                         *
            *⑩BLコード名称                     *
            *⑫発注先コード　                   *
            *⑬発注先名称     　                *
            *⑭発注ロット       　              *
            *************************************/
            // 画面表示テーブルのカラム設定
            //GoodsMngDataTable = new DataTable(GOODSMNG_TABLE);
            //GoodsMngDataTable.Columns.Add(DELETE_DATE, typeof(string));    // 削除日
            //GoodsMngDataTable.Columns.Add(LOGICALDELETE_TITLE, typeof(int));       // 論理削除区分

            //GoodsMngDataTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));       // 拠点コード
            //GoodsMngDataTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));    // 拠点ガイド名称
            //GoodsMngDataTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(int));         // 商品メーカーコード
            //GoodsMngDataTable.Columns.Add(MAKERNAME_TITLE, typeof(string));         // メーカー名称
            //GoodsMngDataTable.Columns.Add(GOODSNO_TITLE, typeof(string));           // 商品コード
            //GoodsMngDataTable.Columns.Add(GOODSNAME_TITLE, typeof(string));         // 商品名称

            //GoodsMngDataTable.Columns.Add(BLGOODSCODE_TITLE, typeof(int));         // BLコード
            //GoodsMngDataTable.Columns.Add(BLGOODSNAME_TITLE, typeof(string));         // BLコード名称
            //GoodsMngDataTable.Columns.Add(SUPPLIERCD1_TITLE, typeof(int));         // 仕入先コード
            //GoodsMngDataTable.Columns.Add(SUPPLIERSNM_TITLE, typeof(string));    // 仕入先名称
            //GoodsMngDataTable.Columns.Add(SUPPLIERLOT1_TITLE, typeof(int));        // 発注ロット
            //GoodsMngDataTable.Columns.Add(FILEHEADERGUID_TITLE, typeof(Guid));      // データテーブルカラム名称

            //// プライマリーキーの設定
            //GoodsMngDataTable.PrimaryKey = new DataColumn[] { GoodsMngDataTable.Columns[SECTIONCODE_TITLE],
            //                                                  GoodsMngDataTable.Columns[GOODSMAKERCD_TITLE],
            //                                                  GoodsMngDataTable.Columns[GOODSNO_TITLE],
            //                                                  GoodsMngDataTable.Columns[BLGOODSCODE_TITLE],
            //                                                };


            ////----- ueno add ---------- start 2008.03.28
            //// 大文字小文字を区別する
            //GoodsMngDataTable.CaseSensitive = true;
            ////----- ueno add ---------- end 2008.03.28

            ////画面表示テーブルをデータ管理情報へ格納
            //this.GoodsMngDataSet = new DataSet();
            //GoodsMngDataSet.Tables.Add(GoodsMngDataTable);

            #endregion

        }

        #endregion

        #region ◆Public Methods

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// Note       : オンラインモードを取得します。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int GetOnlineMode()
        {
            if (LoginInfoAcquisition.OnlineFlag)
            {
                return (int)OnlineMode.Online;
            }
            else
            {
                return (int)OnlineMode.Offline;
            }
        }
        //#region メーカー名称取得
        ///// <summary>
        ///// メーカー名称取得
        ///// </summary>
        ///// <remarks>
        ///// <param name="goodsMakerCd">メーカーコード</param>
        ///// <returns>メーカー名称</returns>
        ///// <br>Note        : メーカー名称を取得します。</br>
        ///// <br>Programmer  : 30413 犬飼</br>
        ///// <br>Date        : 2008.07.25</br>
        ///// </remarks>
        //public string GetMakerName(int goodsMakerCd)
        //{
        //    string retStr = "";

        //    if ((_makerList_Stc != null) && (_makerList_Stc.ContainsKey(goodsMakerCd) == true))
        //    {
        //        retStr = _makerList_Stc[goodsMakerCd].ToString();
        //    }
        //    return retStr;
        //}
        //#endregion

        /// <summary>
        /// 商品管理情報全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// /// <param name="retList">参照結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        //public int SearchAll(string enterpriseCode, ref int retTotalCnt)
        public int SearchAll(string enterpriseCode, out ArrayList retList)
        {
            int status = -1;
            bool nextData;
            //ArrayList retList;
            int retTotalCnt = 0;
            retList = new ArrayList();
            retList.Clear();

            #region < 検索処理 >
            status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                ConstantManagement.LogicalMode.GetDataAll, 0, null);
            #endregion

            #region < 検索後処理 >
            if (status == 0)
            {
                ArrayList paraList = new ArrayList();

                foreach (object retobj in retList)
                {
                    // ローカルにキャッシュ
                    this.SetCacheData(retobj);
                    // データテーブルに格納
                    //this.EditDataTable(retobj);

                    // データのソート
                    //this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";

                    GoodsMng goodsMng = this.CopyToGoodsMngFromGoodsMngWork(retobj);
                    paraList.Add(goodsMng);
                }
                retList = paraList;
            }
            #endregion

            return status;
        }

        // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 商品管理情報全件読み込み処理(論理削除含む)・本社機能チェック有り
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="mainOfficeFuncFlag">本社機能フラグ</param>
        /// <param name="belongSectionCode">所属拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2008.02.28<br />
        /// </remarks>
        public int SearchAll(string enterpriseCode, out ArrayList retList, int mainOfficeFuncFlag, string belongSectionCode)
        {



            int status = -1;
            bool nextData;
            int retTotalCnt = 0;
            retList = new ArrayList();

            retList.Clear();

            #region < 検索処理 >
            status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                ConstantManagement.LogicalMode.GetDataAll, 0, null);
            #endregion

            #region < 検索後処理 >
            if (status == 0)
            {
                ArrayList paraList = new ArrayList();

                foreach (object retobj in retList)
                {
                    // 本社機能チェック
                    if (mainOfficeFuncFlag != 1)
                    {
                        if (MainOfficeFuncChk(retobj, belongSectionCode) == false) continue;
                    }

                    // ローカルにキャッシュ
                    this.SetCacheData(retobj);
                    // データテーブルに格納
                    //this.EditDataTable(retobj);

                    // データのソート
                    //this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";

                    GoodsMng goodsMng = this.CopyToGoodsMngFromGoodsMngWork(retobj);
                    paraList.Add(goodsMng);
                }
                retList = paraList;
            }
            #endregion

            return status;
        }
        // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 商品管理情報読み込み処理(リモーティング)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngCode">商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadWithGoodsSet(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int goodsMngCode)
        {
            int status = -1;
            retGoodsMngList = new List<GoodsMng>();     // 商品管理情報データリスト
            GoodsMng goodsMng = new GoodsMng();         // 

            // キャッシュ or リモーティングよりデータを取得しデータテーブルを作成します
            status = this.GetGoodsMngData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsMngDataList(ref retGoodsMngList, goodsMngCode);
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngCode">商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadWithGoodsInfo(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int goodsMngCode)
        {
            return this.ReadWithGoodsInfo(out retGoodsMngList, enterpriseCode, 0, goodsMngCode);
        }

        /// <summary>
        /// 商品管理情報読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="MakerCode">メーカーコード</param>
        /// <param name="BLGoodsCode">BLコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadWithGoodsInfo(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int MakerCode, int BLGoodsCode)
        {
            int status = -1;
            retGoodsMngList = new List<GoodsMng>();
            GoodsMng goodsMng = new GoodsMng();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetGoodsMngData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsMngDataList(ref retGoodsMngList, MakerCode, BLGoodsCode);
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngCode">商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadLcWithGoodsMng(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int goodsMngCode)
        {
            int status = -1;
            retGoodsMngList = new List<GoodsMng>();
            GoodsMng goodsMng = new GoodsMng();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetLcGoodsMngData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsMngDataList(ref retGoodsMngList, goodsMngCode);
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngCode">商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadLcWithGoodsInfo(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int goodsMngCode)
        {
            return this.ReadLcWithGoodsInfo(out retGoodsMngList, enterpriseCode, 0, goodsMngCode);
        }

        /// <summary>
        /// 商品管理情報読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="MakerCode">メーカーコード</param>
        /// <param name="BLGoodsCode">BLコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int ReadLcWithGoodsInfo(out List<GoodsMng> retGoodsMngList, string enterpriseCode, int MakerCode, int BLGoodsCode)
        {
            int status = -1;
            retGoodsMngList = new List<GoodsMng>();
            GoodsMng goodsMng = new GoodsMng();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetLcGoodsMngData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsMngDataList(ref retGoodsMngList, MakerCode, BLGoodsCode);
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報登録・更新処理
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>
        /// Note       : 商品管理情報の登録・更新を行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        //public int Write(List<GoodsMng> writeDataList)
        public int Write(ref GoodsMng goodsMng)
        {
            int status = -1;

            try
            {
                // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
                //#region < 登録済みチェック処理 >
                //// プライマリキー
                //object[] objKeyArray = new object[] { goodsMng.SectionCode, goodsMng.GoodsMakerCd, goodsMng.GoodsNo, goodsMng.BLGoodsCode };

                //// < 新規登録 or 更新 のチェック >
                //if (GoodsMngWorkDictionary.ContainsKey(goodsMng.FileHeaderGuid) == false)
                //{
                //    if (this.GoodsMngDataTable.Rows.Find(objKeyArray) != null)
                //    {
                //        return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                //    }
                //}
                //#endregion
                // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<

                #region < 登録データ準備処理 >
                GoodsMngWork goodsMngWork = new GoodsMngWork();
                ArrayList paraList = new ArrayList();

                //for (int i = 0; i < writeDataList.Count; i++)
                //{
                //    //商品管理情報ワーククラスへのデータ格納処理
                //    goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(writeDataList[i]);

                //    paraList.Add(goodsMngWork);
                //}
                //商品管理情報ワーククラスへのデータ格納処理
                goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(goodsMng);
                paraList.Add(goodsMngWork);

                object paraobj = paraList;
                #endregion

                #region < 登録処理 >
                // 商品管理情報書き込み(｢A｣→｢O｣へ接続)
                status = this._iGoodsMngDB.Write(ref paraobj);
                #endregion

                #region < 登録後処理 >
                if (status == 0)
                {
                    #region < 登録データ反映処理 >
                    object retObj;
                    ArrayList retList = (ArrayList)paraobj;

                    // 商品管理情報を元にキャッシュデータを削除する
                    this.RemoveCacheData((GoodsMngWork)paraList[0]);

                    // クラス内メンバコピー
                    goodsMng = this.CopyToGoodsMngFromGoodsMngWork((GoodsMngWork)retList[0]);

                    // 登録したデータをテーブルとキャッシュに反映させる
                    for (int j = 0; j < retList.Count; j++)
                    {
                        retObj = retList[j];
                        //EditDataTable(retObj);
                        SetCacheData(retObj);
                    }
                    #endregion

                    status = 0;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsMngDB = null;
                //通信エラーは-1を戻す
                status = -1;
                return status;
            }

        }

        /// <summary>
        /// 商品管理情報論理削除処理
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報論理削除を行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        //public int LogicalDelete(List<GoodsMng> delDataList)
        public int LogicalDelete(ref GoodsMng goodsMng)
        {
            int status = 0;

            try
            {
                GoodsMngWork goodsMngWork = new GoodsMngWork();
                ArrayList paraList = new ArrayList();

                #region < 論理削除データ準備処理 >
                // ヘッダ情報をキャッシュから取得する
                //for (int i = 0; i < delDataList.Count; i++)
                //{
                //    //商品管理情報ワーククラスへのデータ格納処理
                //    goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(delDataList[i]);

                //    paraList.Add(goodsMngWork);
                //}
                //商品管理情報ワーククラスへのデータ格納処理
                goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(goodsMng);
                paraList.Add(goodsMngWork);
                object paraObj = paraList;
                #endregion

                #region < 論理削除処理 >
                status = this._iGoodsMngDB.LogicalDelete(ref paraObj);
                #endregion

                if (status == 0)
                {
                    #region < 論理削除データ反映処理 >
                    // 画面表示用データテーブルに削除日を表示する
                    object retObj;
                    ArrayList retList = (ArrayList)paraObj;

                    // 商品管理情報を元にキャッシュデータを削除する
                    this.RemoveCacheData((GoodsMngWork)paraList[0]);
                    // 画面表示用データテーブルを削除する
                    //this.RemoveDataTable((GoodsMngWork)paraList[0]);

                    // クラス内メンバコピー
                    goodsMng = this.CopyToGoodsMngFromGoodsMngWork((GoodsMngWork)retList[0]);

                    // 登録したデータをテーブルとキャッシュに反映させる
                    for (int j = 0; j < retList.Count; j++)
                    {
                        retObj = retList[j];
                        //EditDataTable(retObj);
                        SetCacheData(retObj);
                    }
                    #endregion

                    status = 0;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品管理情報物理削除処理
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報物理削除を行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        //public int Delete(List<GoodsMng> deleteDataList)
        public int Delete(GoodsMng goodsMng)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                GoodsMngWork goodsMngWork;
                //GoodsMngWork[] goodsMngWorkArray = new GoodsMngWork[deleteDataList.Count];

                //for (int i = 0; i < deleteDataList.Count; i++)
                //{
                //    goodsMngWork = new GoodsMngWork();
                //    商品管理情報ワーククラスへのデータ格納処理
                //    goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(deleteDataList[i]);

                //    goodsMngWorkArray[i] = goodsMngWork;
                //}
                //商品管理情報ワーククラスへのデータ格納処理
                goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(goodsMng);
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(goodsMngWorkArray);
                byte[] parabyte = XmlByteSerializer.Serialize(goodsMngWork);
                #endregion

                #region < 物理削除処理 >
                status = this._iGoodsMngDB.Delete(parabyte);
                //status = -1;
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    // 商品管理情報を元にキャッシュデータを削除する
                    //this.RemoveCacheData(goodsMngWorkArray[0]);
                    this.RemoveCacheData(goodsMngWork);
                    // 商品管理情報を元に画面表示データテーブル削除
                    //this.RemoveDataTable(goodsMngWorkArray[0]);
                    //this.RemoveDataTable(goodsMngWork);
                    #endregion

                    status = 0;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else
                {
                    //サーバーエラーは-1を戻す
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品管理情報論理削除復活処理
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報の復活を行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        //public int Revival(List<GoodsMng> revivalDataList)
        public int Revival(ref GoodsMng goodsMng)
        {
            int status = 0;
            try
            {
                #region < 復活データ準備処理 >
                GoodsMngWork goodsMngWork = new GoodsMngWork();
                ArrayList paraList = new ArrayList();

                //for (int i = 0; i < revivalDataList.Count; i++)
                //{
                //    //商品管理情報ワーククラスへのデータ格納処理
                //    goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(revivalDataList[i]);
                //    paraList.Add(goodsMngWork);
                //}
                //商品管理情報ワーククラスへのデータ格納処理
                goodsMngWork = this.CopyToGoodsMngWorkFromGoodsMng(goodsMng);
                paraList.Add(goodsMngWork);
                object paraobj = paraList;
                #endregion

                #region < 復活処理 >
                status = this._iGoodsMngDB.RevivalLogicalDelete(ref paraobj);
                #endregion

                #region < 復活後処理 >
                if (status == 0)
                {
                    #region -- 復活データ反映処理 --
                    object retObj;
                    ArrayList retList = (ArrayList)paraobj;

                    // 商品管理情報を元にキャッシュデータを削除する
                    this.RemoveCacheData((GoodsMngWork)paraList[0]);

                    // クラス内メンバコピー
                    goodsMng = this.CopyToGoodsMngFromGoodsMngWork((GoodsMngWork)retList[0]);

                    // 登録したデータをテーブルとキャッシュに反映させる
                    for (int j = 0; j < retList.Count; j++)
                    {
                        retObj = retList[j];
                        //EditDataTable(retObj);
                        SetCacheData(retObj);
                    }
                    #endregion

                    status = 0;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                // --- ADD 2012/09/21 袁磊 redmine#32367 ---------->>>>>
                else
                {
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品管理情報マスタデータ取得処理(リモーティング)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報マスタデータをキャッシュ or リモーティングにより取得します。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int GetGoodsMngData(string enterpriseCode)
        {
            int status = -1;

            #region ●テーブル作成
            if (_searchFlg == false)
            {
                #region < リモーティング取得 >
                ArrayList retList;
                int retTotalCnt;
                bool nextData;

                // 全検索
                status = this.SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                        ConstantManagement.LogicalMode.GetDataAll, 0, null);
                if (status == 0)
                {
                    // DB全検索がされていないためキャッシュをインスタンスする
                    GoodsMngWorkDictionary = new Dictionary<Guid, GoodsMngWork>();
                    GoodsMngWorkList = new List<GoodsMngWork>();

                    #region -- データテーブル作成 --
                    foreach (object retobj in retList)
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData(retobj);
                        // データテーブルに格納
                        //this.EditDataTable(retobj);
                        // データのソート
                        //this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";
                    }
                    #endregion
                }

                #endregion
            }
            else
            {
                #region < キャッシュ取得 >

                #region -- データテーブル作成
                foreach (object retobj in GoodsMngWorkList)
                {
                    // データテーブルに格納
                    //this.EditDataTable(retobj);
                    // データのソート
                    //this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";
                }
                #endregion

                status = 0;
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報マスタデータ取得処理(ローカルDB)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報マスタデータをキャッシュ or ローカルにより取得します。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        public int GetLcGoodsMngData(string enterpriseCode)
        {
            int status = -1;

            #region ●テーブル作成
            if (_searchFlg == false)
            {
                #region < ローカル取得 >
                /*
                List<GoodsMngWork> retList;
                GoodsMngWork paraGoodsMngWork = new GoodsMngWork();
                
                // 全件取得するため抽出条件には企業コードをセット
                paraGoodsMngWork.EnterpriseCode = enterpriseCode;
                status = this._iGoodsMngLcDB.Search(out retList, paraGoodsMngWork, 0, ConstantManagement.LogicalMode.GetDataAll);
                                                        
                if (status == 0)
                {
                    // DB全検索がされていないためキャッシュをインスタンスする
                    GoodsMngWorkDictionary = new Dictionary<Guid, GoodsMngWork>();
                    GoodsMngWorkList = new List<GoodsMngWork>();

                    #region -- データテーブル作成 --
                    foreach (object retobj in retList)
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData(retobj);
                        // データテーブルに格納
                        this.EditDataTable(retobj);
                        // データのソート
                        this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";
                    }

                    // データをキャッシュしたので検索フラグをONにする
                    _searchFlg = true;

                    #endregion
                }
                */
                #endregion
            }
            else
            {
                #region < キャッシュ取得 >

                #region -- データテーブル作成
                foreach (object retobj in GoodsMngWorkList)
                {
                    // データテーブルに格納
                    //this.EditDataTable(retobj);
                    // データのソート
                    //this.GoodsMngDataTable.DefaultView.Sort = GOODSNO_TITLE + " asc";
                }
                #endregion

                status = 0;
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品管理情報読み込み処理（ローカルDB）
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 20056 對馬 大輔<br />
        /// Date       : 2007.11.16<br />
        /// </remarks>
        public int ReadLcWithGoodsMng(out List<GoodsMng> retGoodsMngList, string enterpriseCode, string sectionCode, int goodsMakerCd, string goodsNo, int bLGoodsCode)
        {
            ////---------------------------------------------
            //// 初期化
            ////---------------------------------------------
            //// ステータス初期化
            int status = -1;
            //// 条件パラメータセット
            //GoodsMngWork goodsMngWork = new GoodsMngWork();
            //goodsMngWork.EnterpriseCode = enterpriseCode;
            //goodsMngWork.SectionCode = sectionCode;
            //goodsMngWork.GoodsMakerCd = goodsMakerCd;
            //goodsMngWork.GoodsNo = goodsNo;
            //object paraobj = goodsMngWork;
            //object retobj = null;
            //ArrayList retList = new ArrayList();
            retGoodsMngList = new List<GoodsMng>();

            ////---------------------------------------------
            //// 商品管理情報取得
            ////---------------------------------------------
            //status = this._iGoodsMngDB.SearchMultiCondition(out retobj, paraobj);

            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //        {
            //            // 商品管理情報クラスリスト作成
            //            retList = (ArrayList)retobj;
            //            this.GetGoodsMngListFromGoodsMngWorkList(ref retGoodsMngList, retList);
            //            break;
            //        }
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        {
            //            status = 4;
            //            break;
            //        }
            //    default:
            //        {
            //            status = -1;
            //            break;
            //        }
            //}

            return status;
        }

        /// <summary>
        /// 商品管理情報読み込み処理（リモートDB）
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <returns></returns>
        /// <remarks>
        /// Note       : 商品管理情報を読み込みます。<br />
        /// Programmer : 20056 對馬 大輔<br />
        /// Date       : 2007.11.16<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int ReadWithGoodsMng(out List<GoodsMng> retGoodsMngList, string enterpriseCode, string sectionCode, int goodsMakerCd, string goodsNo, int bLGoodsCode)
        {
            //---------------------------------------------
            // 初期化
            //---------------------------------------------
            // ステータス初期化
            int status = -1;
            // 条件パラメータセット
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            goodsMngWork.EnterpriseCode = enterpriseCode;
            object paraobj = goodsMngWork;
            object retobj = null;
            ArrayList retList = new ArrayList();
            retGoodsMngList = new List<GoodsMng>();

            //---------------------------------------------
            // 商品管理情報取得
            //---------------------------------------------
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //status = this._iGoodsMngDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);
            //
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //        {
            //            // 商品管理情報クラスリスト作成
            //            retList = (ArrayList)retobj;
            //            this.GetGoodsMngListFromGoodsMngWorkList(ref retGoodsMngList, retList);
            //            break;
            //        }
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        {
            //            status = 4;
            //            break;
            //        }
            //    default:
            //        {
            //            status = -1;
            //            break;
            //        }
            //}
            if (_isLocalDBRead)
            {
                List<GoodsMngWork> workList = null;
                status = this._goodsMngLcDB.Search(out workList, goodsMngWork, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 商品管理情報クラスリスト作成
                            retList.AddRange(workList);
                            this.GetGoodsMngListFromGoodsMngWorkList(ref retGoodsMngList, retList);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            status = 4;
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
                        }
                }
            }
            else
            {
                status = this._iGoodsMngDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 商品管理情報クラスリスト作成
                            retList = (ArrayList)retobj;
                            this.GetGoodsMngListFromGoodsMngWorkList(ref retGoodsMngList, retList);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            status = 4;
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
                        }
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            return status;
        }

        #endregion

        #region ◆Private Methods

        /// <summary>
        /// 商品管理情報検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevGoodsMng">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note            : 商品管理情報の検索処理を行います。<br />
        /// Programmer      : 980035 金沢　貞義<br />
        /// Date            : 2007.08.27<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsMng prevGoodsMng)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            goodsMngWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsMngWork;
            object retobj = null;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            List<GoodsMngWork> workList = null;
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            // 商品管理情報検索
            if (readCnt == 0)
            {
                // DBから全件データを取得するためキャッシュをインスタンス化する
                GoodsMngWorkDictionary = new Dictionary<Guid, GoodsMngWork>();
                GoodsMngWorkList = new List<GoodsMngWork>();

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //status = this._iGoodsMngDB.Search(out retobj, paraobj, 0, logicalMode);
                if (_isLocalDBRead)
                {
                    status = this._goodsMngLcDB.Search(out workList, goodsMngWork, 0, ConstantManagement.LogicalMode.GetData0);
                }
                else
                {
                    status = this._iGoodsMngDB.Search(out retobj, paraobj, 0, logicalMode);
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end

            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                    //retList = retobj as ArrayList;

                    if (_isLocalDBRead)
                    {
                        // 商品管理情報クラスリスト作成
                        retList.AddRange(workList);
                    }
                    else
                    {
                        retList = retobj as ArrayList;
                    }
                    // 2008.02.08 96012 ローカルＤＢ参照対応 end
                    break;

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;

                default:
                    return status;
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            // SearchFlg ON
            _searchFlg = true;

            return status;
        }

        /// <summary>
        /// 商品管理情報データクラス → 商品管理情報データワーククラス
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品管理情報の復活を行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        private GoodsMngWork CopyToGoodsMngWorkFromGoodsMng(GoodsMng goodsMng)
        {
            GoodsMngWork goodsMngWork;

            if (GoodsMngWorkDictionary.ContainsKey(goodsMng.FileHeaderGuid))
            {
                // ヘッダ情報を取得するためキャッシュしてあるワーカークラスを取得
                goodsMngWork = GoodsMngWorkDictionary[goodsMng.FileHeaderGuid];
            }
            else
            {
                // ワーカークラス初期化
                goodsMngWork = new GoodsMngWork();
            }



            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitData goodsUnitData1;
            int parStatus = goodsAcs.Read(false, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, out goodsUnitData1);

            goodsMngWork.CreateDateTime = goodsMng.CreateDateTime;
            goodsMngWork.UpdateDateTime = goodsMng.UpdateDateTime;
            goodsMngWork.EnterpriseCode = goodsMng.EnterpriseCode;
            // キャッシュされていた旧データをヘッダ情報を残して編集するデータで上書きする。
            goodsMngWork.SectionCode = goodsMng.SectionCode;            // 拠点コード
            goodsMngWork.SectionGuideNm = goodsMng.SectionGuideNm;      // 拠点名称
            goodsMngWork.GoodsMakerCd = goodsMng.GoodsMakerCd;        　// 商品メーカーコード
            goodsUnitData1.MakerName = goodsMng.GoodsMakerName;         // メーカー名称
            // 2009/11/25 Add >>>
            goodsMngWork.MakerName = goodsMng.GoodsMakerName;         // メーカー名称
            // 2009/11/25 Add <<<
            goodsMngWork.GoodsNo = goodsMng.GoodsNo;             　　　 // 商品コード
            goodsUnitData1.GoodsName = goodsMng.GoodsName;              // 品名
            // 2009/11/25 Add >>>
            goodsMngWork.GoodsName = goodsMng.GoodsName;              // 品名
            // 2009/11/25 Add <<<
            //goodsMngWork.BLGoodsCode = goodsMng.BLGoodsCode;            // BLコード
            //goodsUnitData1.BLGoodsFullName = goodsMng.BLGoodsName;          // BLコード名
            goodsMngWork.SupplierCd = goodsMng.SupplierCd1;         　　// 仕入先コード１
            goodsMngWork.SupplierSnm = goodsMng.SupplierSnm;       　 // 仕入先名称１
            goodsMngWork.SupplierLot = goodsMng.SupplierLot1;        　 // 発注ロット１
            //goodsMngWork.GoodsMGroup = goodsMng.GoodsMGroup;
            //goodsMngWork.GoodsMGroupName = goodsMng.GoodsMGroupNm;
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
            goodsMngWork.BLGoodsCode = goodsMng.BLGoodsCode;            // BLコード
            goodsMngWork.BLGoodsFullName = goodsMng.BLGoodsName;        // BLコード名
            goodsMngWork.GoodsMGroup = goodsMng.GoodsMGroup;            // 中分類コード
            goodsMngWork.GoodsMGroupName = goodsMng.GoodsMGroupNm;　　　// 中分類名称
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<

            return goodsMngWork;
        }

        ///// <summary>
        ///// 商品管理情報データテーブル登録・更新処理
        ///// </summary>
        ///// <param name="paraobj">商品管理情報オブジェクト</param>
        ///// <remarks>
        ///// Note       : 商品管理情報をデータテーブルに登録します。<br />
        ///// Programmer : 980035 金沢　貞義<br />
        ///// Date       : 2007.08.27<br />
        ///// -----------------------------------------------------------------------
        ///// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        ///// <br>           : ローカルＤＢ参照対応</br>
        ///// </remarks>
        //private void EditDataTable(object paraobj)
        //{
        //    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //    Type paraType = paraobj.GetType();

        //    #region ●Object → GoodsMngWorkクラス処理
        //    if (paraType.Name == "ArrayList")
        //    {
        //        ArrayList paraList = (ArrayList)paraobj;
        //        goodsMngWork = (GoodsMngWork)paraList[0];
        //    }
        //    else if (paraType.Name == "GoodsMngWork")
        //    {
        //        goodsMngWork = (GoodsMngWork)paraobj;
        //    }
        //    #endregion

        //    GoodsAcs goodsAcs = new GoodsAcs();
        //    // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        //    goodsAcs.IsLocalDBRead = _isLocalDBRead;
        //    // 2008.02.08 96012 ローカルＤＢ参照対応 end
        //    GoodsUnitData goodsUnitData = new GoodsUnitData();


        //    #region ●画面表示用データテーブル作成

        //    this.GoodsMngDataTable.BeginLoadData();

        //    DataRow AddRow;         // 画面表示用登録データ行

        //    // プライマリキー(表示用)
        //    object[] objKeyArray = new object[] { goodsMngWork.SectionCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, goodsMngWork.BLGoodsCode };

        //    // < 新規登録 or 更新 のチェック >
        //    if (this.GoodsMngDataTable.Rows.Find(objKeyArray) == null)
        //    {
        //        AddRow = this.GoodsMngDataTable.NewRow();
        //    }
        //    else
        //    {
        //        AddRow = this.GoodsMngDataTable.Rows.Find(objKeyArray);
        //    }

        //    #region < 商品管理情報マスタからデータ取得 >
        //    if (goodsMngWork.LogicalDeleteCode == 0)
        //    {
        //        // 論理削除されていなかったら削除日は空
        //        AddRow[DELETE_DATE] = "";
        //    }
        //    else
        //    {
        //        // 論理削除されていたら削除日に更新日付を登録
        //        AddRow[DELETE_DATE] = TDateTime.DateTimeToString(DATATIME_FORM, goodsMngWork.UpdateDateTime);
        //    }

        //    GoodsUnitData goodsUnitData1;
        //    if (goodsMngWork.GoodsNo != "")
        //    {
        //        int parStatus = goodsAcs.Read(false, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, out goodsUnitData1);
        //        AddRow[MAKERNAME_TITLE] = goodsUnitData1.MakerName;// メーカー名
        //        AddRow[GOODSNAME_TITLE] = goodsUnitData1.GoodsName;// 品名
        //        AddRow[BLGOODSNAME_TITLE] = goodsUnitData1.BLGoodsName;              // BLコード名
        //    }
        //    AddRow[FILEHEADERGUID_TITLE] = goodsMngWork.FileHeaderGuid;          // データテーブルカラム名称
        //    AddRow[LOGICALDELETE_TITLE] = goodsMngWork.LogicalDeleteCode;        // 論理削除区分
        //    AddRow[SECTIONCODE_TITLE] = goodsMngWork.SectionCode;                // 拠点コード
        //    AddRow[SECTIONGUIDENM_TITLE] = goodsMngWork.SectionGuideNm;          // 拠点ガイド名称
        //    AddRow[GOODSMAKERCD_TITLE] = goodsMngWork.GoodsMakerCd;              // メーカーコード
        //    AddRow[GOODSNO_TITLE] = goodsMngWork.GoodsNo;                        // 商品番号
        //    AddRow[BLGOODSCODE_TITLE] = goodsMngWork.BLGoodsCode;                // BLコード
        //    AddRow[SUPPLIERCD1_TITLE] = goodsMngWork.SupplierCd;                 // 仕入先コード
        //    AddRow[SUPPLIERSNM_TITLE] = goodsMngWork.SupplierSnm;                // 仕入先名称
        //    AddRow[SUPPLIERLOT1_TITLE] = goodsMngWork.SupplierLot;               // 発注先ロット

        //    #endregion

        //    // < 新規に登録する場合 >
        //    if (this.GoodsMngDataTable.Rows.Find(objKeyArray) == null)
        //    {
        //        // 作成したデータ行の追加
        //        this.GoodsMngDataTable.Rows.Add(AddRow);
        //    }

        //    this.GoodsMngDataTable.EndLoadData();

        //    #endregion
        //}

        ///// <summary>
        ///// 商品管理情報テーブルデータ削除処理
        ///// </summary>
        ///// <param name="goodsMngWork">商品管理情報ワーカークラス</param>
        ///// <remarks>
        ///// Note       : 商品管理情報テーブルのデータを1件削除します。<br />
        ///// Programmer : 980035 金沢　貞義<br />
        ///// Date       : 2007.08.27<br />
        ///// </remarks>
        //private void RemoveDataTable(GoodsMngWork goodsMngWork)
        //{
        //    #region ●画面表示用データテーブル削除
        //    // 画面表示用プライマリキー
        //    object[] objKeyArray = new object[] { goodsMngWork.SectionCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, goodsMngWork.BLGoodsCode };

        //    if (GoodsMngDataTable.Rows.Find(objKeyArray) != null)
        //    {
        //        // 画面表示用テーブルの削除
        //        GoodsMngDataTable.Rows.Find(objKeyArray).Delete();
        //    }
        //    #endregion
        //}

        /// <summary>
        /// 商品管理情報データローカルキャッシュ処理
        /// </summary>
        /// <param name="paraobj">商品管理情報データクラス</param>
        /// <remarks>
        /// Note       : 商品管理情報をローカルにキャッシュします。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        private void SetCacheData(object paraobj)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            Type paraType = paraobj.GetType();

            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsMngWork = (GoodsMngWork)paraList[0];
            }
            else if (paraType.Name == "GoodsMngWork")
            {
                goodsMngWork = (GoodsMngWork)paraobj;
            }

            // ディクショナリークラスに保存
            GoodsMngWorkDictionary.Add(goodsMngWork.FileHeaderGuid, goodsMngWork);
            // リストクラスに保存
            GoodsMngWorkList.Add(goodsMngWork);
        }

        /// <summary>
        /// 商品管理情報キャッシュデータ削除処理
        /// </summary>
        /// <param name="goodsMngWork">商品管理情報コード</param>
        /// <remarks>
        /// Note       : 商品管理情報のキャッシュデータ１件削除します。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        private void RemoveCacheData(GoodsMngWork goodsMngWork)
        {
            //string rowFilter = GoodsMngDataTable.DefaultView.RowFilter;

            //if (goodsMngWork.GoodsNo.Trim() == "")
            //{
            //    // 商品管理情報コードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            //    GoodsMngDataTable.DefaultView.RowFilter = SECTIONCODE_TITLE + " = '" + goodsMngWork.SectionCode + "' AND " +
            //                                              GOODSMAKERCD_TITLE + " = '" + goodsMngWork.GoodsMakerCd.ToString() + "' AND " +
            //                                              BLGOODSCODE_TITLE + " = '" + goodsMngWork.BLGoodsCode.ToString() + "'";
            //}
            //else
            //{
            //    // 商品管理情報コードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            //    GoodsMngDataTable.DefaultView.RowFilter = SECTIONCODE_TITLE + " = '" + goodsMngWork.SectionCode + "' AND " +
            //                                              GOODSMAKERCD_TITLE + " = '" + goodsMngWork.GoodsMakerCd.ToString() + "' AND " +
            //                                              GOODSNO_TITLE + " = '" + goodsMngWork.GoodsNo + "'";
            //}
            //int cnt = GoodsMngDataTable.DefaultView.Count;

            //for (int i = 0; i < cnt; i++)
            //{
            //    Guid guid = (Guid)GoodsMngDataTable.DefaultView[i][FILEHEADERGUID_TITLE];

            if (GoodsMngWorkDictionary != null && GoodsMngWorkList != null)
            {
                if (GoodsMngWorkDictionary.ContainsKey(goodsMngWork.FileHeaderGuid) == true)
                    {
                        // リスト削除のためのデータワーククラスを保持
                        GoodsMngWork removeData = new GoodsMngWork();
                        removeData = GoodsMngWorkDictionary[goodsMngWork.FileHeaderGuid];

                        // ディクショナリークラスのデータを削除
                        GoodsMngWorkDictionary.Remove(goodsMngWork.FileHeaderGuid);

                        // リストクラスの削除
                        if (GoodsMngWorkList.Contains(removeData) == true)
                        {
                            GoodsMngWorkList.Remove(removeData);
                        }
                    }
                }
            //}
            //GoodsMngDataTable.DefaultView.RowFilter = rowFilter;
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="goodsMngList">商品管理情報データクラスリスト</param>
        /// <param name="BLGoodsCode">検索キー</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品管理情報名称を取得します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private void GetGoodsMngDataList(ref List<GoodsMng> goodsMngList, int BLGoodsCode)
        {
            GoodsMng goodsMng = new GoodsMng();

            #region ●該当データリスト作成
            goodsMng = new GoodsMng();
            GoodsAcs goodsAcs = new GoodsAcs();
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            goodsAcs.IsLocalDBRead = _isLocalDBRead;
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            #region < 商品情報取得 >
            goodsMng.FileHeaderGuid = (Guid)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][FILEHEADERGUID_TITLE];
            goodsMng.SectionCode = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][SECTIONCODE_TITLE];
            goodsMng.SectionGuideNm = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][SECTIONGUIDENM_TITLE];
            goodsMng.GoodsMakerCd = (int)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSMAKERCD_TITLE];
            goodsMng.GoodsMakerName = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][MAKERNAME_TITLE];
            goodsMng.GoodsNo = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSNO_TITLE];
            goodsMng.GoodsName = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSNAME_TITLE];
            goodsMng.BLGoodsCode = (int)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][BLGOODSCODE_TITLE];
            goodsMng.BLGoodsName = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][BLGOODSNAME_TITLE];
            goodsMng.GoodsMGroup = (int)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSMGROUP_TITLE];
            goodsMng.GoodsMGroupNm = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSMGROUPNM_TITLE];

            #endregion

            #region < 仕入情報取得 >
            goodsMng.SupplierCd1= (int)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][SUPPLIERCD1_TITLE];
            goodsMng.SupplierSnm = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][SUPPLIERSNM_TITLE];
            goodsMng.SupplierLot1 = (int)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][SUPPLIERLOT1_TITLE];
            #endregion

            #endregion
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="goodsMngList">商品管理情報データクラスリスト</param>
        /// <param name="MakerCode">抽出条件クラス</param>
        /// <param name="BLGoodsCode">抽出条件クラス</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品管理情報名称を取得します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private void GetGoodsMngDataList(ref List<GoodsMng> goodsMngList, int MakerCode, int BLGoodsCode)
        {
            GoodsMng goodsMng;
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            goodsAcs.IsLocalDBRead = _isLocalDBRead;
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            string rowFilter;

            // 作成したテーブルをフィルタし該当データを取得
            rowFilter = this.CreateReadRowFilter(MakerCode, BLGoodsCode);
            this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView.RowFilter = rowFilter;
            int cnt = this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView.Count;

            #region ●該当データリスト作成
            string goodsSetCode;

            for (int i = 0; i < cnt; i++)
            {
                // フィルタ後のデータテーブルの削除日がないデータ行だけ有効とする
                if ((string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[i][DELETE_DATE] == "")
                {
                    goodsSetCode = (string)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[i][GOODSNO_TITLE];

                    //goodsMngWork.FileHeaderGuid = (Guid)this.ChildGoodsInfoDataSet.Tables[GOODSMNG_TABLE].DefaultView[i][FILEHEADERGUID_TITLE];
                    goodsMngWork.FileHeaderGuid = (Guid)this.GoodsMngDataSet.Tables[GOODSMNG_TABLE].DefaultView[i][FILEHEADERGUID_TITLE];
                    goodsMngWork = GoodsMngWorkDictionary[goodsMngWork.FileHeaderGuid];

                    goodsMng = new GoodsMng();

                    // ワーククラス→データクラスに格納
                    goodsMng.SectionCode = goodsMngWork.SectionCode;
                    goodsMng.SectionGuideNm = goodsMngWork.SectionGuideNm;
                    goodsMng.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                    goodsMng.GoodsMakerName = goodsMngWork.MakerName;
                    goodsMng.GoodsNo = goodsMngWork.GoodsNo;
                    goodsMng.GoodsName = goodsMngWork.GoodsName;
                    goodsMng.BLGoodsCode = goodsMngWork.BLGoodsCode;
                    goodsMng.BLGoodsName = goodsMngWork.BLGoodsFullName;
                    goodsMng.SupplierCd1 = goodsMngWork.SupplierCd;
                    goodsMng.SupplierSnm = goodsMngWork.SupplierSnm;
                    goodsMng.SupplierLot1 = goodsMngWork.SupplierLot;
                    goodsMng.GoodsMGroup = goodsMngWork.GoodsMGroup;
                    goodsMng.GoodsMGroupNm = goodsMngWork.GoodsMGroupName;

                    #region Del 2009/1/13 sakurai
                    //if (goodsMng.GoodsNo.Trim() != "")
                    //{
                    //    int parStatus = goodsAcs.Read(false, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, out goodsUnitData1);
                    //    goodsMng.GoodsMakerName = goodsUnitData1.MakerName;
                    //    goodsMng.BLGoodsName = goodsUnitData1.BLGoodsFullName;
                    //    goodsMng.GoodsName = goodsUnitData1.GoodsName;
                    //}
                    //else
                    //{
                    //    if (goodsMng.GoodsMakerCd != 0)
                    //    {
                    //        makerAcs.Read(out makerUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd);
                    //        goodsMng.GoodsMakerName = makerUMnt.MakerName;
                    //    }
                    //    if (goodsMng.BLGoodsCode != 0)
                    //    {
                    //        bLGoodsCdAcs.Read(out bLGoodsCdUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.BLGoodsCode);
                    //        goodsMng.BLGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
                    //    } 
                    //    goodsMng.GoodsName = "";

                    //}
                    #endregion

                    goodsMngList.Add(goodsMng);
                }
            }
            #endregion
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="MakerCode">メーカーコード</param>
        /// <param name="BLGoodsCode">商品コード</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品管理情報名称を取得します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private string CreateReadRowFilter(int MakerCode, int BLGoodsCode)
        {
            string rowFilter = "";

            #region < メーカーコードとBLコードのみ >
            if (MakerCode != 0 && BLGoodsCode != 0)
            {
                rowFilter = GoodsMngAcs.GOODSMAKERCD_TITLE + " = '" + MakerCode + "' AND " +
                             GoodsMngAcs.BLGOODSCODE_TITLE + " = '" + BLGoodsCode + "'";
            }
            #endregion

            #region < BLコードのみ >
            else if (MakerCode == 0 && BLGoodsCode != 0)
            {
                rowFilter = GoodsMngAcs.BLGOODSCODE_TITLE + " = '" + BLGoodsCode + "'";
            }
            #endregion

            return rowFilter;
        }

        // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 商品管理情報データ本社機能チェック
        /// </summary>
        /// <param name="paraobj">商品管理情報オブジェクト</param>
        /// <param name="belongSectionCode">所属拠点コード</param>
        /// <remarks>
        /// Note       : 本社機能チェックを行います。<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2008.02.28<br />
        /// </remarks>
        private bool MainOfficeFuncChk(object paraobj, string belongSectionCode)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            Type paraType = paraobj.GetType();

            #region ●Object → GoodsMngWorkクラス処理
            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsMngWork = (GoodsMngWork)paraList[0];
            }
            else if (paraType.Name == "GoodsMngWork")
            {
                goodsMngWork = (GoodsMngWork)paraobj;
            }
            #endregion

            bool chkFlg = false;
            if (goodsMngWork.SectionCode.TrimEnd() == belongSectionCode.TrimEnd())
            {
                chkFlg = true;
            }

            return chkFlg;
        }
        // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 商品管理情報ワーククラスから商品管理情報クラスを作成します。
        /// </summary>
        /// <param name="paraobj">商品管理情報ワーククラス</param>
        /// <remarks>
        /// <br>Note        : 商品管理情報クラスを作成します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2008.01.09</br>
        /// </remarks>
        private GoodsMng CopyToGoodsMngFromGoodsMngWork(object paraobj)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            Type paraType = paraobj.GetType();

            #region ●Object → GoodsMngWorkクラス処理
            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsMngWork = (GoodsMngWork)paraList[0];
            }
            else if (paraType.Name == "GoodsMngWork")
            {
                goodsMngWork = (GoodsMngWork)paraobj;
            }
            #endregion

            GoodsMng goodsMng = new GoodsMng();
            goodsMng.FileHeaderGuid     = goodsMngWork.FileHeaderGuid;          // データテーブルカラム名称
            goodsMng.LogicalDeleteCode  = goodsMngWork.LogicalDeleteCode;       // 論理削除区分
            goodsMng.UpdateDateTime     = goodsMngWork.UpdateDateTime;          // 修正日付
            goodsMng.EnterpriseCode = goodsMngWork.EnterpriseCode;
            goodsMng.UpdateDateTime = goodsMngWork.UpdateDateTime;
            goodsMng.CreateDateTime = goodsMngWork.CreateDateTime;
            goodsMng.SectionCode        = goodsMngWork.SectionCode.Trim();
            if (goodsMng.SectionCode == "00")
            {
                goodsMng.SectionGuideNm = "全社共通";
            }
            else
            {
                goodsMng.SectionGuideNm = goodsMngWork.SectionGuideNm;
            }
            goodsMng.GoodsMakerCd       = goodsMngWork.GoodsMakerCd;
            goodsMng.GoodsMakerName     = goodsMngWork.MakerName;
            goodsMng.GoodsNo            = goodsMngWork.GoodsNo;
            goodsMng.GoodsName          = goodsMngWork.GoodsName;
            goodsMng.BLGoodsCode        = goodsMngWork.BLGoodsCode;
            goodsMng.BLGoodsName        = goodsMngWork.BLGoodsFullName;
            goodsMng.SupplierCd1        = goodsMngWork.SupplierCd;
            goodsMng.SupplierSnm        = goodsMngWork.SupplierSnm;
            goodsMng.SupplierLot1       = goodsMngWork.SupplierLot;
            goodsMng.GoodsMGroup        = goodsMngWork.GoodsMGroup;
            goodsMng.GoodsMGroupNm      = goodsMngWork.GoodsMGroupName;

            #region Del 2009/1/13 sakurai
            //if ( goodsMng.GoodsNo.Trim() != "")
            //{
            //    int parStatus = goodsAcs.Read(false, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, out goodsUnitData1);
            //    goodsMng.GoodsMakerName = goodsUnitData1.MakerName;
            //    goodsMng.BLGoodsName = goodsUnitData1.BLGoodsFullName;
            //    goodsMng.GoodsName = goodsUnitData1.GoodsName;
            //}
            //else
            //{
            //    if (goodsMng.GoodsMakerCd != 0)
            //    {
            //        makerAcs.Read(out makerUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd);
            //        if (makerUMnt != null)
            //        {
            //            goodsMng.GoodsMakerName = makerUMnt.MakerName;
            //        }
            //    }
            //    
            //if (goodsMng.BLGoodsCode != 0)
            //    {
            //        bLGoodsCdAcs.Read(out bLGoodsCdUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.BLGoodsCode);
            //        if (bLGoodsCdUMnt != null)
            //        {
            //            goodsMng.BLGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
            //        }

            //    }
            //    goodsMng.GoodsName = "";

            //}
            #endregion

            return goodsMng;
        }

        /// <summary>
        /// 商品管理情報ワーククラスリストから商品管理情報クラスリストを作成します。
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報クラスリスト</param>
        /// <param name="retList">商品管理情報ワーククラスリスト</param>
        /// <remarks>
        /// Note       : 商品管理情報クラスリストを作成します。<br />
        /// Programmer : 20056 對馬 大輔<br />
        /// Date       : 2007.11.16<br />
        /// </remarks>
        private void GetGoodsMngListFromGoodsMngWorkList(ref List<GoodsMng> retGoodsMngList, ArrayList retList)
        {
            GoodsMng goodsMng;

            foreach (GoodsMngWork goodsMngWork in retList)
            {
                goodsMng = new GoodsMng();
                goodsMng.SectionCode = goodsMngWork.SectionCode;
                goodsMng.SectionGuideNm = goodsMngWork.SectionGuideNm;
                goodsMng.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                goodsMng.GoodsMakerName = goodsMngWork.MakerName;
                goodsMng.GoodsNo = goodsMngWork.GoodsNo;
                goodsMng.GoodsName = goodsMngWork.GoodsName;
                goodsMng.BLGoodsCode = goodsMngWork.BLGoodsCode;
                goodsMng.BLGoodsName = goodsMngWork.BLGoodsFullName;
                goodsMng.SupplierCd1 = goodsMngWork.SupplierCd;
                goodsMng.SupplierSnm = goodsMngWork.SupplierSnm;
            　  goodsMng.SupplierLot1 = goodsMngWork.SupplierLot;
                goodsMng.GoodsMGroup = goodsMngWork.GoodsMGroup;
                goodsMng.GoodsMGroupNm = goodsMngWork.GoodsMGroupName;


                #region del 2009/1/13 sakurai
                //GoodsAcs goodsAcs = new GoodsAcs();
               //GoodsUnitData goodsUnitData1;
               //MakerAcs makerAcs = new MakerAcs();
               //MakerUMnt makerUMnt;
               //BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();
               //BLGoodsCdUMnt bLGoodsCdUMnt;
               
               // if ( goodsMng.GoodsNo.Trim() != "")
               //{
               //    int parStatus = goodsAcs.Read(false, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd, goodsMngWork.GoodsNo, out goodsUnitData1);
               //    goodsMng.GoodsMakerName = goodsUnitData1.MakerName;
               //    goodsMng.BLGoodsName = goodsUnitData1.BLGoodsFullName;
               //    goodsMng.GoodsName = goodsUnitData1.GoodsName;
               //}
               //else
               //{
               //    if (goodsMng.GoodsMakerCd != 0)
               //    {
               //        makerAcs.Read(out makerUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.GoodsMakerCd);
               //        goodsMng.GoodsMakerName = makerUMnt.MakerName;
               //    }
               //    if (goodsMng.BLGoodsCode != 0)
               //    {
               //        bLGoodsCdAcs.Read(out bLGoodsCdUMnt, goodsMngWork.EnterpriseCode, goodsMngWork.BLGoodsCode);
               //        goodsMng.BLGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
               //    }
               //    goodsMng.GoodsName = "";

               //}
                #endregion
                retGoodsMngList.Add(goodsMng);
            }
        }
        #endregion

        // --- 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報のリストを取得します。
        /// </summary>
        /// <param name="prmSettingUList">検索結果</param>
        /// <param name="prmSettingUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <br>Note       : 優良設定マスタ（ユーザー登録分）のキー値が一致する、全ての優良設定マスタ（ユーザー登録分）情報を取得します。</br>
        /// <br>Programmer : redmine#32367 袁磊</br>
        /// <br>Date       : 2012/09/21</br>
        public void GetPrimeSettingMng(ref object prmSettingUList, object prmSettingUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            IPrmSettingUDB primeSettingSearchDB = (IPrmSettingUDB)MediationPrmSettingUDB.GetPrmSettingUDB();
            primeSettingSearchDB.Search(ref prmSettingUList, prmSettingUObj, readMode, logicalMode);
        }
        // --- 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
    }
}

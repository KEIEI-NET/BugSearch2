//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : セットマスタ
// プログラム概要   : セットマスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008.08.01  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 作 成 日  2008/10/08  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/02/06  修正内容 : 各種速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/14  修正内容 : Mantis【10817】論理削除時のセット商品の商品情報取得を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/08/04  修正内容 : 起動速度アップ対応
//----------------------------------------------------------------------------//

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
    /// 商品セットマスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>Note            : 商品セットマスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer      : 30005 木建　翼</br>
    /// <br>Date            : 2007.05.07</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : ReadLcWithGoodsInfoを実行すると同じ商品が返ってし </br>
    /// <br>                : まう不具合を修正                                  </br>
    /// <br>Programmer      : 30005 木建　翼</br>
    /// <br>Date            : 2007.06.04</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : DC.NS用に変更 </br>
    /// <br>Programmer      : 20081 疋田　勇人</br>
    /// <br>Date            : 2007.09.26</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : PM.NS対応 </br>
    /// <br>Programmer      : 30413 犬飼</br>
    /// <br>Date            : 2008.08.01</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 2008/10/08 30462 行澤 仁美　バグ修正</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 2009.02.06 20056 對馬 大輔</br>
    /// <br>                : 　各種速度アップ対応</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 2010/08/04 22018 鈴木 正臣</br>
    /// <br>                : 　起動速度アップ対応</br>
    /// <br>--------------------------------------------------------------------</br>
    /// </remarks>
    public class GoodsSetAcs
    {
        #region ◆Public Members

        /// <summary>画面表示データテーブル格納データセットクラス</summary>
        public DataSet GoodsSetDataSet;
        /// <summary>全データ格納データセットクラス</summary>
        public DataSet ChildGoodsInfoDataSet;

        #region ●DataTable用名称情報
        // 2008.08.21 30413 犬飼 GUIDは主キーに変更 >>>>>>START
        /// <summary>データテーブルカラム名称(GUID)</summary>
        //public static readonly string FILEHEADERGUID_TITLE = "Guid";
        public static readonly string FILEHEADERGUID_TITLE = "PrimaryKey";
        // 2008.08.21 30413 犬飼 GUIDは主キーに変更 <<<<<<END
        
        // 2008.08.20 30413 犬飼 論理削除で使用するカラム名称を削除 >>>>>>START
        ///// <summary>データテーブルカラム名称(削除日)</summary>
        //public static readonly string DELETE_DATE = "削除日";
        ///// <summary>データテーブルカラム名称(論理削除区分)</summary>
        //public static readonly string LOGICALDELETE_TITLE = "論理削除区分";
        // 2008.08.20 30413 犬飼 論理削除で使用するカラム名称を削除 <<<<<<END
        
        // 2007.09.26 hikita upd start ------------------------------------------->>
        ///// <summary>データテーブルカラム名称(商品セットコード)</summary>
        //public static readonly string GOODSSETCODE_TITLE = "商品セットコード";
        ///// <summary>データテーブルカラム名称(商品セット名称)</summary>
        //public static readonly string GOODSSETNAME_TITLE = "商品セット名称";
        ///// <summary>データテーブルカラム名称(商品セット略称)</summary>
        //public static readonly string GOODSSETSHORTNAME_TITLE = "商品セット略称";
        ///// <summary>データテーブルカラム名称(親商品メーカーコード)</summary>
        //public static readonly string PARENTMAKERCODE_TITLE = "親商品メーカーコード";
        ///// <summary>データテーブルカラム名称(親商品メーカー名称)</summary>
        //public static readonly string PARENTMAKERNAME_TITLE = "親商品メーカー名称";
        ///// <summary>データテーブルカラム名称(親商品コード)</summary>
        //public static readonly string PARENTGOODSCODE_TITLE = "親商品コード";
        ///// <summary>データテーブルカラム名称(親商品名称)</summary>
        //public static readonly string PARENTGOODSNAME_TITLE = "親商品名称";
        ///// <summary>データテーブルカラム名称(表示順位)</summary>
        //public static readonly string DISPLAYORDER_TITLE = "表示順位";
        ///// <summary>データテーブルカラム名称(メーカーコード)</summary>
        //public static readonly string MAKERCODE_TITLE = "メーカーコード";
        ///// <summary>データテーブルカラム名称(メーカー名称)</summary>
        //public static readonly string MAKERNAME_TITLE = "メーカー名称";
        ///// <summary>データテーブルカラム名称(商品コード)</summary>
        //public static readonly string GOODSCODE_TITLE = "商品コード";
        ///// <summary>データテーブルカラム名称(商品名称)</summary>
        //public static readonly string GOODSNAME_TITLE = "商品名称";
        ///// <summary>データテーブルカラム名称(機種コード)</summary>
        //public static readonly string CELLPHONEMODELCODE_TITLE = "機種コード";
        ///// <summary>データテーブルカラム名称(機種名称)</summary>
        //public static readonly string CELLPHONEMODELNAME_TITLE = "機種名称";
        ///// <summary>データテーブルカラム名称(複数)</summary>
        //public static readonly string CHILDPLURALGOODS_TITLE = "複数";

        // 2008.08.04 30413 犬飼 DataTable用名称の変更 >>>>>>START
        ///// <summary>データテーブルカラム名称(親メーカーコード)</summary>
        //public static readonly string PARENTGOODSMAKERCD_TITLE = "親メーカーコード";
        ///// <summary>データテーブルカラム名称(親メーカー名称)</summary>
        //public static readonly string PARENTGOODSMAKERNM_TITLE = "親メーカー名称";
        ///// <summary>データテーブルカラム名称(親商品番号)</summary>
        //public static readonly string PARENTGOODSNO_TITLE = "親商品番号";
        ///// <summary>データテーブルカラム名称(親商品名称)</summary>
        //public static readonly string PARENTGOODSNAME_TITLE = "親商品名称";
        ///// <summary>データテーブルカラム名称(子商品メーカーコード)</summary>
        //public static readonly string SUBGOODSMAKERCD_TITLE = "メーカーコード";
        ///// <summary>データテーブルカラム名称(子商品メーカー名称)</summary>
        //public static readonly string SUBGOODSMAKERNM_TITLE = "メーカー名称";
        ///// <summary>データテーブルカラム名称(子商品番号)</summary>
        //public static readonly string SUBGOODSNO_TITLE = "商品番号";
        ///// <summary>データテーブルカラム名称(子商品名称)</summary>
        //public static readonly string SUBGOODSNAME_TITLE = "商品名称";
        ///// <summary>データテーブルカラム名称(数量)</summary>
        //public static readonly string CNTFL_TITLE = "数量";
        ///// <summary>データテーブルカラム名称(表示順位)</summary>
        //public static readonly string DISPLAYORDER_TITLE = "表示順位";
        ///// <summary>データテーブルカラム名称(セット規格・特記事項)</summary>
        //public static readonly string SETSPECIALNOTE_TITLE = "セット規格・特記事項";
        ///// <summary>データテーブルカラム名称(カタログ図番)</summary>
        //public static readonly string CATALOGSHAPENO_TITLE = "カタログ図番";
        ///// <summary>データテーブルカラム名称(複数)</summary>
        //public static readonly string CHILDPLURALGOODS_TITLE = "複数";
        // 2007.09.26 hikita upd end ----------------------------------------------<<
        /// <summary>データテーブルカラム名称(複数)</summary>
        public static readonly string CHILDPLURALGOODS_TITLE = "複数";
        /// <summary>データテーブルカラム名称(親品番)</summary>
        public static readonly string PARENTGOODSNO_TITLE = "親品番";
        /// <summary>データテーブルカラム名称(親品名)</summary>
        public static readonly string PARENTGOODSNAME_TITLE = "親品名";
        /// <summary>データテーブルカラム名称(親メーカーコード)</summary>
        public static readonly string PARENTGOODSMAKERCD_TITLE = "親メーカーコード";
        /// <summary>データテーブルカラム名称(親メーカー名称)</summary>
        public static readonly string PARENTGOODSMAKERNM_TITLE = "親メーカー名";

        /// <summary>データテーブルカラム名称(子品番)</summary>
        public static readonly string SUBGOODSNO_TITLE = "品番";
        /// <summary>データテーブルカラム名称(子品名)</summary>
        public static readonly string SUBGOODSNAME_TITLE = "品名";
        /// <summary>データテーブルカラム名称(子商品メーカーコード)</summary>
        public static readonly string SUBGOODSMAKERCD_TITLE = "メーカー";
        /// <summary>データテーブルカラム名称(子商品メーカー名称)</summary>
        public static readonly string SUBGOODSMAKERNM_TITLE = "メーカー名";
        /// <summary>データテーブルカラム名称(ＱＴＹ)</summary>
        public static readonly string CNTFL_TITLE = "ＱＴＹ";
        /// <summary>データテーブルカラム名称(表示順位)</summary>
        public static readonly string DISPLAYORDER_TITLE = "表示順位";
        /// <summary>データテーブルカラム名称(セット規格・特記事項)</summary>
        public static readonly string SETSPECIALNOTE_TITLE = "セット規格・特記事項";
        /// <summary>データテーブルカラム名称(カタログ図番)</summary>
        public static readonly string CATALOGSHAPENO_TITLE = "カタログ図番";
        /// <summary>データテーブルカラム名称(提供区分)</summary>
        public static readonly string DIVISION_TITLE = "提供区分";
        /// <summary>データテーブルカラム名称(提供区分名称)</summary>
        public static readonly string DIVISIONNAME_TITLE = "提供区分名称";
        // 2008.08.04 30413 犬飼 DataTable用名称の変更 <<<<<<END
        

        /// <summary>データテーブル名称</summary>
        public static readonly string GOODSSET_TABLE = "GoodsSet_Table";
        /// <summary>全データ格納テーブル名称</summary>
        public static readonly string CHILDGOODSINFO_TABLE = "ChildGoodsInfo_Table";
        #endregion

        // 2008.08.06 30413 犬飼 親子区分の追加 >>>>>>START
        #region 親子区分 
        /// <summary> 親子区分列挙体 </summary>
        public enum ParentChildDivState
        {
            /// <summary> 親 </summary>
            Parent = 0,
            /// <summary> 子 </summary>
            Child = 1
        }
        #endregion ◆
        // 2008.08.06 30413 犬飼 親子区分の追加 <<<<<<END

        // 2008.08.07 30413 犬飼 プロパティ提供区分名称を追加 >>>>>>START
        /// <summary>提供区分 ユーザー</summary>
        public const string DIVISION_NAME_USER = "ユーザー";
        /// <summary>提供区分 提供</summary>
        public const string DIVISION_NAME_OFFER = "提供";
        // 2008.08.07 30413 犬飼 プロパティ提供区分名称を追加 <<<<<<END
        
        #endregion

        #region ◆Private Members

        #region ●Static Members
        /// <summary>商品セットマスタクラスSearchフラグ</summary>
        private static bool _searchFlg = false;
        /// <summary>商品セットローカルキャッシュ用データディクショナリークラス</summary>
        //private static Dictionary<string, GoodsSetWork> GoodsSetWorkDictionary;
        //private static Dictionary<Guid, GoodsSetWork> GoodsSetWorkDictionary;
        private static Dictionary<string, GoodsSetWork> GoodsSetWorkDictionary;
        /// <summary>商品セットローカルキャッシュ用リストクラス</summary>
        private static List<GoodsSetWork> GoodsSetWorkList;

        // 2008.08.21 30413 犬飼 商品連結データをローカルキャッシュで保持 >>>>>>START
        /// <summary>商品連結ローカルキャッシュ用データディクショナリークラス</summary>
        private static Dictionary<string, GoodsUnitData> lc_GoodsUnitDataDictionary;
        // 2008.08.21 30413 犬飼 商品連結データをローカルキャッシュで保持 <<<<<<END

        // 2008.10.17 30413 犬飼 商品情報をローカルキャッシュで保持 >>>>>>START
        /// <summary>親商品情報ローカルキャッシュ用データディクショナリークラス</summary>
        private static Dictionary<string, GoodsUnitData> parent_GoodsUnitDataDictionary;
        /// <summary>セット商品情報ローカルキャッシュ用データディクショナリークラス</summary>
        private static Dictionary<string, List<GoodsUnitData>> childSet_GoodsUnitDataDictionary;
        // 2008.10.17 30413 犬飼 商品情報をローカルキャッシュで保持 <<<<<<END

        #endregion
       
        #region ●Const
        /// <summary>削除日表示形式</summary>
        private const string DATATIME_FORM = "ggYY/MM/DD";
        /// <summary>ガイド用XMLのファイル名</summary>
        private const string GUIDEXML_TITLE = "GOODSSETGUIDEPARENT.XML";

        #endregion

        #region ●Normal Members

        /// <summary>商品セットリモートオブジェクト格納バッファ</summary>
        private IGoodsSetDB _iGoodsSetDB = null;
        /// <summary>商品セットローカルオブジェクト格納バッファ</summary>
        private GoodsSetLcDB _iGoodsSetLcDB = null;
        /// <summary>画面表示データテーブルクラス</summary>
        private DataTable GoodsSetDataTable;
        /// <summary>個商品情報データ保持データテーブルクラス</summary>
        private DataTable ChildGoodsInfoDataTable;

        // 2008.08.04 30413 犬飼 プロパティ追加 >>>>>>START
        // ログイン従業員
        private Employee _loginEmployee = null;
        // 2008.08.04 30413 犬飼 プロパティ追加 <<<<<<END

        // 2008.10.09 30413 犬飼 動作高速化対応 >>>>>>START
        // 商品アクセスクラス
        GoodsAcs _goodsAcs = null;
        // メーカーマスタアクセスクラス
        MakerAcs _makerAcs = null;
        // 2008.10.09 30413 犬飼 動作高速化対応 <<<<<<END
        
        #endregion

        #endregion

        #region ◆Constructor 
        
        /// <summary>
        /// 商品セットアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// Note            : 商品セット取得のためのリモートオブジェクトを記述します。<br />
        /// Programmer      : 30005  木建  翼<br />
        /// Date            : 2007.05.07<br />
        /// </remarks>
        public GoodsSetAcs()
        {
            try
            {
                // 商品セットマスタリモートオブジェクト取得
                this._iGoodsSetDB = (IGoodsSetDB)MediationGoodsSetDB.GetGoodsSetDB();
                // 商品セットマスタローカルオブジェクト取得
                this._iGoodsSetLcDB = new GoodsSetLcDB();
                
            }
            catch (Exception)
            {
                this._iGoodsSetDB = null;
                this._iGoodsSetLcDB = null;
            }

            // 2008.08.04 30413 犬飼 プロパティ追加 >>>>>>START
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            // 2008.08.04 30413 犬飼 プロパティ追加 <<<<<<END

            // 2008.10.09 30413 犬飼 動作高速化対応 >>>>>>START
            // 商品アクセスクラスのインスタンス化
            string message = "";
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, this._loginEmployee.BelongSectionCode.Trim(), out message);

            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // メーカーマスタアクセスクラスのインスタンス化
            this._makerAcs = new MakerAcs();
            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2008.10.09 30413 犬飼 動作高速化対応 <<<<<<END
        
            // 2008.08.04 30413 犬飼 画面表示用DataTable列設定の変更 >>>>>>START
            #region ●画面表示用DataTable列設定 <<<<<<変更前
            //// 下記の順番が実際の表示の順番になる
            //************************************
            //*①削除日                           *
            //*②論理削除区分                     *
            //*③親商品メーカーコード             *
            //*④親商品メーカー名称               *
            //*⑤親商品コード                     *
            //*⑥親商品名称                       *
            //*⑦表示順位                         *
            //*⑧メーカーコード                   *
            //*⑨メーカー名称                     *
            //*⑩商品コード                       *
            //*⑪商品名称                         *
            //*⑫数量                             *　　
            //*⑬セット・規格特記事項             *
            //*⑭カタログ図番                     *
            //*************************************/
            //// 画面表示テーブルのカラム設定
            //GoodsSetDataTable = new DataTable(GOODSSET_TABLE);
            //GoodsSetDataTable.Columns.Add(DELETE_DATE,                      typeof(string));    // 削除日
            //GoodsSetDataTable.Columns.Add(LOGICALDELETE_TITLE,              typeof(int));       // 論理削除区分
            //// 2007.09.26 hikita upd start ----------------------------------------------------------------------->>
            ////GoodsSetDataTable.Columns.Add(GOODSSETCODE_TITLE,               typeof(string));    // 商品セットコード
            ////GoodsSetDataTable.Columns.Add(GOODSSETNAME_TITLE,               typeof(string));    // 商品セット名称
            ////GoodsSetDataTable.Columns.Add(GOODSSETSHORTNAME_TITLE,          typeof(string));    // 商品セット略称
            ////GoodsSetDataTable.Columns.Add(DISPLAYORDER_TITLE,               typeof(int));       // 表示順位
            ////GoodsSetDataTable.Columns.Add(PARENTMAKERCODE_TITLE,            typeof(int));       // 親商品メーカーコード
            ////GoodsSetDataTable.Columns.Add(PARENTMAKERNAME_TITLE,            typeof(string));    // 親商品メーカー名称
            ////GoodsSetDataTable.Columns.Add(PARENTGOODSCODE_TITLE,            typeof(string));    // 親商品コード
            ////GoodsSetDataTable.Columns.Add(PARENTGOODSNAME_TITLE,            typeof(string));    // 親商品名称
            ////GoodsSetDataTable.Columns.Add(CELLPHONEMODELCODE_TITLE,         typeof(string));    // 機種コード
            ////GoodsSetDataTable.Columns.Add(CELLPHONEMODELNAME_TITLE,         typeof(string));    // 機種名称
            ////GoodsSetDataTable.Columns.Add(MAKERCODE_TITLE,                  typeof(int));       // メーカーコード
            ////GoodsSetDataTable.Columns.Add(MAKERNAME_TITLE,                  typeof(string));    // メーカー名称
            ////GoodsSetDataTable.Columns.Add(GOODSCODE_TITLE,                  typeof(string));    // 商品コード
            ////GoodsSetDataTable.Columns.Add(GOODSNAME_TITLE,                  typeof(string));    // 商品名称
            ////GoodsSetDataTable.Columns.Add(CHILDPLURALGOODS_TITLE,           typeof(string));    // 複数
            //// ADDした順番が表示の順番
            //GoodsSetDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));       // 親メーカーコード
            //GoodsSetDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));    // 親メーカー名称
            //GoodsSetDataTable.Columns.Add(PARENTGOODSNO_TITLE,      typeof(string));    // 親商品番号
            //GoodsSetDataTable.Columns.Add(PARENTGOODSNAME_TITLE,    typeof(string));    // 親商品名称
            //GoodsSetDataTable.Columns.Add(DISPLAYORDER_TITLE,       typeof(int));       // 表示順位
            //GoodsSetDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE,    typeof(int));       // メーカーコード
            //GoodsSetDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE,    typeof(string));    // メーカー名称
            //GoodsSetDataTable.Columns.Add(SUBGOODSNO_TITLE,         typeof(string));    // 商品番号
            //GoodsSetDataTable.Columns.Add(SUBGOODSNAME_TITLE,       typeof(string));    // 商品名称
            //GoodsSetDataTable.Columns.Add(CNTFL_TITLE,              typeof(double));    // 数量
            //GoodsSetDataTable.Columns.Add(SETSPECIALNOTE_TITLE,     typeof(string));    // セット・規格特記事項
            //GoodsSetDataTable.Columns.Add(CATALOGSHAPENO_TITLE,     typeof(string));    // カタログ図番
            //GoodsSetDataTable.Columns.Add(CHILDPLURALGOODS_TITLE,   typeof(string));    // 複数
            //// 2007.09.26 hikita upd end -------------------------------------------------------------------------<<
            
            //// プライマリーキーの設定
            //// 2007.09.26 hikita upd start ----------------------------------------------------------------------->>
            ////GoodsSetDataTable.PrimaryKey = new DataColumn[] { GoodsSetDataTable.Columns[GOODSSETCODE_TITLE] };  
            //GoodsSetDataTable.PrimaryKey = new DataColumn[] { GoodsSetDataTable.Columns[PARENTGOODSMAKERCD_TITLE],
            //                                                  GoodsSetDataTable.Columns[PARENTGOODSNO_TITLE],
            //                                                 };
            //// 2007.09.26 hikita upd end -------------------------------------------------------------------------<<

            ////画面表示テーブルをデータセットへ格納
            //this.GoodsSetDataSet = new DataSet();
            //GoodsSetDataSet.Tables.Add(GoodsSetDataTable);

            #endregion

            #region ●画面表示用DataTable列設定
            // 下記の順番が実際の表示の順番になる
            /******************
             *①削除日
             *　論理削除区分
             *②複数
             *③親品番
             *④親品名
             *　親商品メーカーコード
             *⑤親商品メーカー名称
             *⑥品番
             *⑦品名
             *　メーカーコード
             *⑧メーカー名称
             *⑨ＱＴＹ(数量)
             *　表示順位
             *⑩セット規格・特記事項
             *⑪カタログ図番
             *　提供区分
             *⑫提供区分名称
             ******************/
            // 画面表示テーブルのカラム設定
            GoodsSetDataTable = new DataTable(GOODSSET_TABLE);
            //GoodsSetDataTable.Columns.Add(DELETE_DATE, typeof(string));                 // 削除日
            //GoodsSetDataTable.Columns.Add(LOGICALDELETE_TITLE, typeof(int));            // 論理削除区分
            GoodsSetDataTable.Columns.Add(CHILDPLURALGOODS_TITLE, typeof(string));      // 複数
            GoodsSetDataTable.Columns.Add(PARENTGOODSNO_TITLE, typeof(string));         // 親品番
            GoodsSetDataTable.Columns.Add(PARENTGOODSNAME_TITLE, typeof(string));       // 親品名
            GoodsSetDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));       // 親メーカーコード
            GoodsSetDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));    // 親メーカー名称
            GoodsSetDataTable.Columns.Add(SUBGOODSNO_TITLE, typeof(string));            // 品番
            GoodsSetDataTable.Columns.Add(SUBGOODSNAME_TITLE, typeof(string));          // 品名
            GoodsSetDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE, typeof(int));          // メーカーコード
            GoodsSetDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE, typeof(string));       // メーカー名称
            //GoodsSetDataTable.Columns.Add(CNTFL_TITLE, typeof(double));                 // ＱＴＹ(数量)
            GoodsSetDataTable.Columns.Add(CNTFL_TITLE, typeof(string));                 // ＱＴＹ(数量)
            GoodsSetDataTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));             // 表示順位
            GoodsSetDataTable.Columns.Add(SETSPECIALNOTE_TITLE, typeof(string));        // セット・規格特記事項
            GoodsSetDataTable.Columns.Add(CATALOGSHAPENO_TITLE, typeof(string));        // カタログ図番
            //GoodsSetDataTable.Columns.Add(DIVISION_TITLE, typeof(int));                 // 提供区分
            //GoodsSetDataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));          // 提供区分名称
            
            // プライマリーキーの設定
            GoodsSetDataTable.PrimaryKey = new DataColumn[] { GoodsSetDataTable.Columns[PARENTGOODSNO_TITLE],
                                                              GoodsSetDataTable.Columns[PARENTGOODSMAKERCD_TITLE],
                                                             };
            
            //画面表示テーブルをデータセットへ格納
            this.GoodsSetDataSet = new DataSet();
            GoodsSetDataSet.Tables.Add(GoodsSetDataTable);

            #endregion
            // 2008.08.04 30413 犬飼 画面表示用DataTable列設定の変更 <<<<<<END


            // 2008.08.04 30413 犬飼 子商品情報格納テーブル用DataTable列設定の変更 >>>>>>START
            #region ●子商品情報格納テーブル用DataTable列設定 <<<<<<変更前

            //ChildGoodsInfoDataTable = new DataTable(CHILDGOODSINFO_TABLE);
            ////GoodsSetDataTable.Columns.Add(DELETE_DATE,                    typeof(string));    // 削除日
            ////GoodsSetDataTable.Columns.Add(LOGICALDELETE_TITLE,            typeof(int));       // 論理削除区分
            //ChildGoodsInfoDataTable.Columns.Add(FILEHEADERGUID_TITLE, typeof(Guid));    // GUID
            //// 2007.09.26 hikita upd start ----------------------------------------------------------------------->>
            ////ChildGoodsInfoDataTable.Columns.Add(GOODSSETCODE_TITLE, typeof(string));    // 商品セットコード
            ////ChildGoodsInfoDataTable.Columns.Add(MAKERCODE_TITLE, typeof(int));       // メーカーコード
            ////ChildGoodsInfoDataTable.Columns.Add(MAKERNAME_TITLE, typeof(string));    // メーカー名称
            ////ChildGoodsInfoDataTable.Columns.Add(GOODSCODE_TITLE, typeof(string));    // 商品コード
            ////ChildGoodsInfoDataTable.Columns.Add(GOODSNAME_TITLE, typeof(string));    // 商品名称
            //ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));       // 親メーカーコード
            //ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));    // 親メーカー名称
            //ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNO_TITLE, typeof(string));         // 親商品番号
            //ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNAME_TITLE, typeof(string));       // 親商品名称
            //ChildGoodsInfoDataTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));             // 表示順位
            //ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE, typeof(int));          // メーカーコード
            //ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE, typeof(string));       // メーカー名称
            //ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNO_TITLE, typeof(string));            // 商品番号
            //ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNAME_TITLE, typeof(string));          // 商品名称
            //ChildGoodsInfoDataTable.Columns.Add(CNTFL_TITLE, typeof(double));                 // 数量
            //ChildGoodsInfoDataTable.Columns.Add(SETSPECIALNOTE_TITLE, typeof(string));        // セット・規格特記事項
            //ChildGoodsInfoDataTable.Columns.Add(CATALOGSHAPENO_TITLE, typeof(string));        // カタログ図番
            //// 2007.09.26 hikita upd end -------------------------------------------------------------------------<<
            
            //// プライマリーキーの設定
            //// 2007.09.26 hikita upd start ----------------------------------------------------------------------->>
            ////ChildGoodsInfoDataTable.PrimaryKey = new DataColumn[] { ChildGoodsInfoDataTable.Columns[GOODSSETCODE_TITLE],
            ////                                                        ChildGoodsInfoDataTable.Columns[MAKERCODE_TITLE],
            ////                                                        ChildGoodsInfoDataTable.Columns[GOODSCODE_TITLE] };
            //ChildGoodsInfoDataTable.PrimaryKey = new DataColumn[] { ChildGoodsInfoDataTable.Columns[PARENTGOODSMAKERCD_TITLE],
            //                                                        ChildGoodsInfoDataTable.Columns[PARENTGOODSNO_TITLE],
            //                                                        ChildGoodsInfoDataTable.Columns[SUBGOODSMAKERCD_TITLE],
            //                                                        ChildGoodsInfoDataTable.Columns[SUBGOODSNO_TITLE] };
            //// 2007.09.26 hikita upd end -------------------------------------------------------------------------<<

            //// 全データ格納テーブルをデータセットへ格納
            //this.ChildGoodsInfoDataSet = new DataSet();
            //ChildGoodsInfoDataSet.Tables.Add(ChildGoodsInfoDataTable);

            #endregion

            #region ●子商品情報格納テーブル用DataTable列設定

            ChildGoodsInfoDataTable = new DataTable(CHILDGOODSINFO_TABLE);
            //ChildGoodsInfoDataTable.Columns.Add(FILEHEADERGUID_TITLE, typeof(Guid));          // GUID
            ChildGoodsInfoDataTable.Columns.Add(FILEHEADERGUID_TITLE, typeof(string));        // 主キー
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNO_TITLE, typeof(string));         // 親品番
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNAME_TITLE, typeof(string));       // 親品名
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));       // 親メーカーコード
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));    // 親メーカー名称
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNO_TITLE, typeof(string));            // 品番
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNAME_TITLE, typeof(string));          // 品名
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE, typeof(int));          // メーカーコード
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE, typeof(string));       // メーカー名称
            //ChildGoodsInfoDataTable.Columns.Add(CNTFL_TITLE, typeof(double));                 // ＱＴＹ(数量)
            ChildGoodsInfoDataTable.Columns.Add(CNTFL_TITLE, typeof(string));                 // ＱＴＹ(数量)
            ChildGoodsInfoDataTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));             // 表示順位
            ChildGoodsInfoDataTable.Columns.Add(SETSPECIALNOTE_TITLE, typeof(string));        // セット・規格特記事項
            ChildGoodsInfoDataTable.Columns.Add(CATALOGSHAPENO_TITLE, typeof(string));        // カタログ図番
            ChildGoodsInfoDataTable.Columns.Add(DIVISION_TITLE, typeof(int));                 // 提供区分
            ChildGoodsInfoDataTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));          // 提供区分名称
            
            // プライマリーキーの設定
            ChildGoodsInfoDataTable.PrimaryKey = new DataColumn[] { ChildGoodsInfoDataTable.Columns[PARENTGOODSNO_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[PARENTGOODSMAKERCD_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[SUBGOODSNO_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[SUBGOODSMAKERCD_TITLE] };
            
            // 全データ格納テーブルをデータセットへ格納
            this.ChildGoodsInfoDataSet = new DataSet();
            ChildGoodsInfoDataSet.Tables.Add(ChildGoodsInfoDataTable);

            #endregion
            // 2008.08.04 30413 犬飼 子商品情報格納テーブル用DataTable列設定の変更 <<<<<<END
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
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
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

        /// <summary>
        /// 商品セット全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// /// <param name="retTotalCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        public int SearchAll(string enterpriseCode, ref int retTotalCnt)
        {
            int status = -1;
            bool nextData;
            ArrayList retList;

            #region < 検索処理 >
            status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                ConstantManagement.LogicalMode.GetDataAll, 0, null);
            #endregion

            #region < 検索後処理 > 
            if (status == 0)
            {
                foreach (object retobj in retList)
                {
                    // セットマスタ情報をローカルにキャッシュ
                    this.SetCacheData(retobj);

                    //// データテーブルに格納
                    //this.EditDataTable(retobj);

                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                    //// データのソート
                    //// 2007.09.26 hikita upd start ---------------------------------------------->>
                    ////this.GoodsSetDataTable.DefaultView.Sort = GOODSSETCODE_TITLE + " asc";
                    //this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";
                    //// 2007.09.26 hikita upd end ------------------------------------------------<<
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END
                }

                // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
                //// 商品情報をキャッシュ
                //this.SetPartsInfoCacheData();
                // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<END

                // キャッシュからデータテーブルを全作成
                this.AllEditDataTable();

                // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                // データのソート
                // 親品番＋親メーカーコード
                this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                // 2008.08.121 30413 犬飼 ソートをループの外で実施 <<<<<<END
                        
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品セット読み込み処理(リモーティング)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="retGoodsList">データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsSetCode">商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadWithGoodsSet(out List<GoodsSet> retGoodsSetList, out List<GoodsUnitData> retGoodsList ,string enterpriseCode, string goodsSetCode)
        {
            int status = -1;
            retGoodsSetList = new List<GoodsSet>();     // 商品セットデータリスト
            retGoodsList = new List<GoodsUnitData>();   // 商品データリスト
            GoodsSet goodsSet = new GoodsSet();         // 

            // キャッシュ or リモーティングよりデータを取得しデータテーブルを作成します
            status = this.GetGoodsSetData(enterpriseCode);

            #region ●検索後処理 
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsSetDataList(ref retGoodsSetList, goodsSetCode);
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
        /// 商品セット読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsCode">商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadWithGoodsInfo(out List<GoodsSet> retGoodsSetList, string enterpriseCode, string parentGoodsCode)
        {
            return this.ReadWithGoodsInfo(out retGoodsSetList, enterpriseCode, 0, parentGoodsCode);
        }

        /// <summary>
        /// 商品セット読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentMakerCode">親メーカーコード</param>
        /// <param name="parentGoodsCode">親商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadWithGoodsInfo(out List<GoodsSet> retGoodsSetList, string enterpriseCode, int parentMakerCode, string parentGoodsCode)
        {
            int status = -1;
            retGoodsSetList = new List<GoodsSet>();
            GoodsSet goodsSet = new GoodsSet();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetGoodsSetData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsSetDataList(ref retGoodsSetList, parentMakerCode, parentGoodsCode);
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
        /// 商品セット読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsSetCode">商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadLcWithGoodsSet(out List<GoodsSet> retGoodsSetList, string enterpriseCode, string goodsSetCode)
        {
            int status = -1;
            retGoodsSetList = new List<GoodsSet>();
            GoodsSet goodsSet = new GoodsSet();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetLcGoodsSetData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsSetDataList(ref retGoodsSetList, goodsSetCode);
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
        /// 商品セット読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsCode">親商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadLcWithGoodsInfo(out List<GoodsSet> retGoodsSetList, string enterpriseCode, string parentGoodsCode)
        {
            return this.ReadLcWithGoodsInfo(out retGoodsSetList, enterpriseCode, 0, parentGoodsCode);
        }

        /// <summary>
        /// 商品セット読み込み処理(ローカルDB)
        /// </summary>
        /// <param name="retGoodsSetList">商品セット該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentMakerCode">親メーカーコード</param>
        /// <param name="parentGoodsCode">親商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.20<br />
        /// </remarks>
        public int ReadLcWithGoodsInfo(out List<GoodsSet> retGoodsSetList, string enterpriseCode, int parentMakerCode, string parentGoodsCode)
        {
            int status = -1;
            retGoodsSetList = new List<GoodsSet>();
            GoodsSet goodsSet = new GoodsSet();

            // キャッシュ or ローカルDBよりデータを取得しデータテーブルを作成します
            status = this.GetLcGoodsSetData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsSetDataList(ref retGoodsSetList, parentMakerCode, parentGoodsCode);
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
        /// 商品セット登録・更新処理
        /// </summary>
        /// <param name="writeDataList">商品セットデータクラスリスト</param>
        /// <param name="goodsUnitDataDic">商品連結データディクショナリー</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報の登録・更新を行います。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        //public int Write(List<GoodsSet> writeDataList)
        public int Write(List<GoodsSet> writeDataList, Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            int status = -1;

            try
            {
                // 2008.08.04 30413 犬飼 登録データ準備処理の変更 >>>>>>START
                #region < 登録データ準備処理 > <<<<<<変更前
                //GoodsSetWork goodsSetWork = new GoodsSetWork();
                //ArrayList paraList = new ArrayList();

                //for (int i = 0; i < writeDataList.Count ; i++)
                //{
                //    //商品セットワーククラスへのデータ格納処理
                //    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(writeDataList[i]);

                //    paraList.Add(goodsSetWork);
                //}

                //object paraobj = paraList;
                #endregion

                #region < 登録データ準備処理 >
                GoodsSetWork goodsSetWork = new GoodsSetWork();
                GoodsAcs goodsAcs = new GoodsAcs();
                object paraObj = new object();
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                ArrayList paraList = new ArrayList();
                ArrayList unitDataList = new ArrayList();
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                string msg = "";

                // 商品セット設定オブジェクトの追加
                for (int i = 0; i < writeDataList.Count; i++)
                {
                    // 商品セット情報を取得
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(writeDataList[i]);
                    GoodsSet wkGoodsSet = this.CopyToGoodsSetOverlap((GoodsSet)writeDataList[i], goodsSetWork);
                    paraList.Add(wkGoodsSet);

                    // 商品連結データを取得
                    goodsUnitData = CopyToGoodsUnitDataFromGoodsSet(writeDataList[i], goodsUnitDataDic);
                    if (goodsUnitData != null)
                    {
                        // 商品連結データがnull以外
                        unitDataList.Add(goodsUnitData);
                    }
                }
                // 商品連結データリストと商品セット情報リストを書込対象
                if (unitDataList.Count != 0)
                {
                    // 商品連結データリストが0件以外
                    csList.Add(unitDataList);
                }
                csList.Add(paraList);
                paraObj = csList;
                #endregion
                // 2008.08.04 30413 犬飼 登録データ準備処理の変更 <<<<<<END


                // 2008.08.04 30413 犬飼 登録処理の変更 >>>>>>START
                #region < 登録処理 > <<<<<<変更前
                //// 商品セット情報書き込み(｢A｣→｢O｣へ接続)
                ////status = this._iGoodsSetDB.Write(ref paraobj, LoginInfoAcquisition.EnterpriseCode, goodsSetWork.GoodsSetCode); // 2007.09.26 hikita del
                //status = this._iGoodsSetDB.Write(ref paraobj, LoginInfoAcquisition.EnterpriseCode, goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo); // 2007.09.26 hikita add
                #endregion

                #region < 登録処理 >
                // 商品マスタクラスを経由して商品セット設定の書き込み
                status = goodsAcs.WriteRelation(ref paraObj, out msg);
                #endregion
                // 2008.08.04 30413 犬飼 登録処理の変更 <<<<<<END
                

                #region < 登録後処理 >
                if (status == 0)
                {
                    // 2008.08.04 30413 犬飼 登録処理の変更 >>>>>>START
                    #region < 登録データ反映処理 > <<<<<<変更前
                    //object retObj;
                    //ArrayList retList = (ArrayList)paraobj;

                    //// 商品セット情報を元にキャッシュデータを削除する
                    //this.RemoveCacheData((GoodsSetWork)paraList[0]);
                    //// 商品セット情報を元に子商品情報データテーブル削除
                    //this.RemoveChildDataTable((GoodsSetWork)paraList[0]);

                    //// 登録したデータをテーブルとキャッシュに反映させる
                    //for (int j = 0; j < retList.Count ; j++)
                    //{
                    //    retObj = retList[j];
                    //    EditDataTable(retObj);
                    //    SetCacheData(retObj);
                    //}
                    #endregion

                    #region < 登録データ反映処理 >
                    object retObj;
                    // DEL 2008/10/08 不具合対応[6301] ↓
                    //ArrayList retList = (ArrayList)((CustomSerializeArrayList)paraObj)[1];
                    ArrayList retList = (ArrayList)((CustomSerializeArrayList)paraObj)[0];  // ADD 2008/10/08 不具合対応[6301]

                    //GoodsSetWork goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(writeDataList[0]);
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet((GoodsSet)retList[0]);

                    // 商品セット情報を元にキャッシュデータを削除する
                    this.RemoveCacheData(goodsSetWork);
                    // 商品セット情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTable(goodsSetWork);

                    // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 2008.11.07 30413 犬飼 品名と品番を取得するためリモートを呼び出すように修正 >>>>>>START
                    ////// 登録したデータをテーブルとキャッシュに反映させる
                    ////for (int j = 0; j < retList.Count; j++)
                    ////{
                    ////    // 2008.10.30 30413 犬飼 キャッシュ反映処理を変更 >>>>>>START
                    ////    retObj = retList[j];
                    ////    //EditDataTable(retObj);
                    ////    SetCacheData(retObj);

                    ////    GoodsSetWork wkGoodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet((GoodsSet)retList[j]);

                    ////    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
                    ////    //// 商品連結データのローカルキャッシュを追加
                    ////    //AddPartsInfoCacheData(wkGoodsSetWork);
                    ////    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<EMD
                        
                    ////    // データテーブルの反映
                    ////    EditDataTable(wkGoodsSetWork);
                    ////    // 2008.10.30 30413 犬飼 キャッシュ反映処理を変更 <<<<<<END
                    ////}

                    //ArrayList outList;
                    //// 親品番と親メーカーコードで取得
                    //status = SearchGoodsSet(out outList, (GoodsSet)retList[0]);
                    //if (status == 0)
                    //{
                    //    foreach (object retobj in outList)
                    //    {
                    //        // セットマスタ情報をローカルにキャッシュ
                    //        this.SetCacheData(retobj);

                    //        // データテーブルの反映
                    //        EditDataTable((GoodsSetWork)retobj);
                    //    }
                    //}
                    //// 2008.11.07 30413 犬飼 品名と品番を取得するためリモートを呼び出すように修正 <<<<<<END

                    ArrayList outList;
                    // 親品番と親メーカーコードで取得
                    status = SearchGoodsSet(out outList, (GoodsSet)retList[0]);
                    if (status == 0)
                    {
                        this.ChildGoodsInfoDataTable.BeginLoadData();
                        this.GoodsSetDataTable.BeginLoadData();
                        List<GoodsSetWork> goodsSetWorkList = new List<GoodsSetWork>((GoodsSetWork[])outList.ToArray(typeof(GoodsSetWork)));

                        foreach (object retobj in outList)
                        {
                            // セットマスタ情報をローカルにキャッシュ
                            this.SetCacheData(retobj);

                            // データテーブルの反映
                            this.EditDataTable((GoodsSetWork)retobj, goodsSetWorkList);
                        }

                        this.ChildGoodsInfoDataTable.EndLoadData();
                        this.GoodsSetDataTable.EndLoadData();
                    }
                    // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    #endregion
                    // 2008.08.04 30413 犬飼 登録処理の変更 <<<<<<END
                
                    status = 0;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsSetDB = null;
                //通信エラーは-1を戻す
                status = -1;
                return status;
            }

        }

        /// <summary>
        /// 商品セット論理削除処理
        /// </summary>
        /// <param name="delDataList">商品セットデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報論理削除を行います。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        public int LogicalDelete(List<GoodsSet> delDataList)
        {
            int status = 0;

            try
            {
                GoodsSetWork goodsSetWork = new GoodsSetWork();
                ArrayList paraList = new ArrayList();

                #region < 論理削除データ準備処理 >
                // ヘッダ情報をキャッシュから取得する
                for (int i = 0; i < delDataList.Count ; i++)
                {
                    //商品セットワーククラスへのデータ格納処理
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(delDataList[i]);

                    paraList.Add(goodsSetWork);
                }
                object paraObj = paraList;
                #endregion

                #region < 論理削除処理 >
                status = this._iGoodsSetDB.LogicalDelete(ref paraObj);
                #endregion

                if (status == 0)
                {
                    #region < 論理削除データ反映処理 >
                    // 画面表示用データテーブルに削除日を表示する
                    object retObj;
                    ArrayList retList = (ArrayList)paraObj;

                    // 商品セット情報を元にキャッシュデータを削除する
                    this.RemoveCacheData((GoodsSetWork)paraList[0]);
                    // 画面表示用データテーブルを削除する
                    this.RemoveDataTable((GoodsSetWork)paraList[0]);

                    // 登録したデータをテーブルとキャッシュに反映させる
                    for (int j = 0; j < retList.Count ; j++)
                    {
                        retObj = retList[j];
                        EditDataTable(retObj);
                        SetCacheData(retObj);
                    }
                    #endregion

                    status = 0;
                }
                else
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品セット物理削除処理
        /// </summary>
        /// <param name="deleteDataList">商品セットデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報物理削除を行います。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        public int Delete(List<GoodsSet> deleteDataList)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                GoodsSetWork goodsSetWork;
                GoodsSetWork[] goodsSetWorkArray = new GoodsSetWork[deleteDataList.Count];
                
                for (int i = 0; i < deleteDataList.Count; i++)
                {
                    goodsSetWork = new GoodsSetWork();
                    //商品セットワーククラスへのデータ格納処理
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(deleteDataList[i]);

                    goodsSetWorkArray[i] = goodsSetWork;
                }
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(goodsSetWorkArray);
                #endregion

                #region < 物理削除処理 >
                status = this._iGoodsSetDB.Delete(parabyte);
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    // 商品セット情報を元にキャッシュデータを削除する
                    this.RemoveCacheData(goodsSetWorkArray[0]);
                    // 商品セット情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTable(goodsSetWorkArray[0]);
                    // 商品セット情報を元に画面表示データテーブル削除
                    this.RemoveDataTable(goodsSetWorkArray[0]);
                    #endregion

                    status = 0;
                }
                // 2008.08.20 30413 犬飼 エラーコードはそのまま返す >>>>>>START
                //else
                //{
                //    //サーバーエラーは-1を戻す
                //    status = -1;
                //}
                #endregion
                // 2008.08.20 30413 犬飼 エラーコードはそのまま返す <<<<<<END
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品セット論理削除復活処理
        /// </summary>
        /// <param name="revivalDataList">商品セットデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報の復活を行います。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        public int Revival(List<GoodsSet> revivalDataList)
        {
            int status = 0;
            try
            {
                #region < 復活データ準備処理 >
                GoodsSetWork goodsSetWork = new GoodsSetWork();
                ArrayList paraList = new ArrayList();

                for (int i = 0; i < revivalDataList.Count; i++)
                {
                    //商品セットワーククラスへのデータ格納処理
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(revivalDataList[i]);
                    paraList.Add(goodsSetWork);
                }
                object paraobj = paraList;
                #endregion

                #region < 復活処理 >
                status = this._iGoodsSetDB.RevivalLogicalDelete(ref paraobj);
                #endregion

                #region < 復活後処理 >
                if (status == 0)
                {
                    #region -- 復活データ反映処理 --
                    object retObj;
                    ArrayList retList = (ArrayList)paraobj;

                    // 商品セット情報を元にキャッシュデータを削除する
                    this.RemoveCacheData((GoodsSetWork)paraList[0]);
                    // 商品セット情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTable((GoodsSetWork)paraList[0]);

                    // 登録したデータをテーブルとキャッシュに反映させる
                    for (int j = 0; j < retList.Count ; j++)
                    {
                        retObj = retList[j];
                        EditDataTable(retObj);
                        SetCacheData(retObj);
                    }
                    #endregion

                    status = 0;
                }
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
                this._iGoodsSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品セットマスタデータ取得処理(リモーティング)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セットマスタデータをキャッシュ or リモーティングにより取得します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.16<br />
        /// </remarks>
        public int GetGoodsSetData(string enterpriseCode)
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
                    GoodsSetWorkDictionary = new Dictionary<string, GoodsSetWork>();
                    GoodsSetWorkList = new List<GoodsSetWork>();

                    #region -- データテーブル作成 --
                    foreach (object retobj in retList)
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData(retobj);
                        // データテーブルに格納
                        this.EditDataTable(retobj);
                        // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                        //// データのソート
                        ////this.GoodsSetDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc, " + GOODSSETCODE_TITLE + " asc";       // 2007.09.26 hikita del
                        //this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";  // 2007.09.26 hikita add
                        // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END
                    }
                    #endregion

                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                    // データのソート
                    // 親品番＋親メーカーコード
                    this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END
                }

                #endregion
            }
            else
            {
                #region < キャッシュ取得 >

                #region -- データテーブル作成
                foreach (object retobj in GoodsSetWorkList)
                {
                    // データテーブルに格納
                    this.EditDataTable(retobj);
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                    //// データのソート
                    ////this.GoodsSetDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc, " + GOODSSETCODE_TITLE + " asc";      // 2007.09.26 hikita del
                    //this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc"; // 2007.09.26 hikita add
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END

                }
                #endregion

                // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                // データのソート
                // 親品番＋親メーカーコード
                this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END

                status = 0;
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 商品セットマスタデータ取得処理(ローカルDB)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セットマスタデータをキャッシュ or ローカルにより取得します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.19<br />
        /// </remarks>
        public int GetLcGoodsSetData(string enterpriseCode)
        {
            int status = -1;

            #region ●テーブル作成
            if (_searchFlg == false)
            {
                #region < ローカル取得 >
                List<GoodsSetWork> retList;
                GoodsSetWork paraGoodsSetWork = new GoodsSetWork();
                
                // 全件取得するため抽出条件には企業コードをセット
                paraGoodsSetWork.EnterpriseCode = enterpriseCode;
                status = this._iGoodsSetLcDB.Search(out retList, paraGoodsSetWork, 0, ConstantManagement.LogicalMode.GetDataAll);
                                                        
                if (status == 0)
                {
                    // DB全検索がされていないためキャッシュをインスタンスする
                    GoodsSetWorkDictionary = new Dictionary<string, GoodsSetWork>();
                    GoodsSetWorkList = new List<GoodsSetWork>();

                    #region -- データテーブル作成 --
                    foreach (object retobj in retList)
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData(retobj);
                        // データテーブルに格納
                        this.EditDataTable(retobj);
                        // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                        //// データのソート
                        ////this.GoodsSetDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc, " + GOODSSETCODE_TITLE + " asc";        // 2007.09.26 hikita del
                        //this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";   // 2007.09.26 hikita add
                        // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END

                    }

                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                    // データのソート
                    // 親品番＋親メーカーコード
                    this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END

                    // データをキャッシュしたので検索フラグをONにする
                    _searchFlg = true;

                    #endregion
                }

                #endregion
            }
            else
            {
                #region < キャッシュ取得 >

                #region -- データテーブル作成
                foreach (object retobj in GoodsSetWorkList)
                {
                    // データテーブルに格納
                    this.EditDataTable(retobj);
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                    //// データのソート
                    ////this.GoodsSetDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc, " + GOODSSETCODE_TITLE + " asc";        // 2007.09.26 hikita del
                    //this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";   // 2007.09.26 hikita add
                    // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END
                }
                #endregion

                // 2008.08.12 30413 犬飼 ソートをループの外で実施 >>>>>>START
                // データのソート
                // 親品番＋親メーカーコード
                this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                // 2008.08.12 30413 犬飼 ソートをループの外で実施 <<<<<<END

                status = 0;
                #endregion
            }
            #endregion

            return status;
        }
        
        #endregion

        #region ◆Private Methods

        /// <summary>
        /// 商品セット検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevGoodsSet">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note            : 商品セットの検索処理を行います。<br />
        /// Programmer      : 30005 木建　翼<br />
        /// Date            : 2007.05.08<br />
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsSet prevGoodsSet)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            // 2008.08.04 30413 犬飼 引数をnullからArrayListに変更 >>>>>>START
            //object retobj = null;
            object retobj = paraList;
            // 2008.08.04 30413 犬飼 引数をnullからArrayListに変更 <<<<<<END
            
            // 商品セット検索
            if (readCnt == 0)
            {
                // DBから全件データを取得するためキャッシュをインスタンス化する
                GoodsSetWorkDictionary = new Dictionary<string, GoodsSetWork>();
                GoodsSetWorkList = new List<GoodsSetWork>();

                status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, logicalMode);
                
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    retList = retobj as ArrayList;
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
        /// 商品セットデータクラス → 商品セットデータワーククラス
        /// </summary>
        /// <param name="goodsSet">商品セットデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報の復活を行います。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        private GoodsSetWork CopyToGoodsSetWorkFromGoodsSet(GoodsSet goodsSet)
        {
            GoodsSetWork goodsSetWork;

            // ヘッダ情報を取得するためのGUIDを取得する
            //object[] objPrimaryKey = new object[] { goodsSet.GoodsSetCode, goodsSet.MakerCode, goodsSet.GoodsCode };                                     // 2007.09.26 hikita del
            // 2008.08.11 30413 犬飼 プライマリーキーの変更 >>>>>>START
            //object[] objPrimaryKey = new object[] { goodsSet.ParentGoodsMakerCd, goodsSet.ParentGoodsNo, goodsSet.SubGoodsMakerCd, goodsSet.SubGoodsNo };  // 2007.09.26 hikita add
            object[] objPrimaryKey = new object[] { goodsSet.ParentGoodsNo, goodsSet.ParentGoodsMakerCd, goodsSet.SubGoodsNo, goodsSet.SubGoodsMakerCd };
            // 2008.08.11 30413 犬飼 プライマリーキーの変更 <<<<<<END
            DataRow row = this.ChildGoodsInfoDataTable.Rows.Find(objPrimaryKey);
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
            string key = "";
            if (row != null)
            {
                //goodsSet.FileHeaderGuid = (Guid)row[FILEHEADERGUID_TITLE];
                key = (string)row[FILEHEADERGUID_TITLE];
            }

            //if (GoodsSetWorkDictionary.ContainsKey(goodsSet.FileHeaderGuid))
            if (GoodsSetWorkDictionary.ContainsKey(key))
            {
                // ヘッダ情報を取得するためキャッシュしてあるワーカークラスを取得
                //goodsSetWork = GoodsSetWorkDictionary[goodsSet.FileHeaderGuid];
                goodsSetWork = GoodsSetWorkDictionary[key];
            }
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            else
            {
                // ワーカークラス初期化
                goodsSetWork = new GoodsSetWork();

                // 2008.08.12 30413 犬飼 ワーカーにヘッダ情報の設定を追加 >>>>>>START
                // 商品セットデータでヘッダ情報をセット
                goodsSetWork.CreateDateTime = goodsSet.CreateDateTime;
                goodsSetWork.UpdateDateTime = goodsSet.UpdateDateTime;
                goodsSetWork.EnterpriseCode = goodsSet.EnterpriseCode;
                goodsSetWork.FileHeaderGuid = goodsSet.FileHeaderGuid;
                goodsSetWork.UpdEmployeeCode = goodsSet.UpdEmployeeCode;
                goodsSetWork.UpdAssemblyId1 = goodsSet.UpdAssemblyId1;
                goodsSetWork.UpdAssemblyId2 = goodsSet.UpdAssemblyId2;
                goodsSetWork.LogicalDeleteCode = goodsSet.LogicalDeleteCode;
                // 2008.08.12 30413 犬飼 ワーカーにヘッダ情報の設定を追加 <<<<<<END
            }

            // キャッシュされていた旧データをヘッダ情報を残して編集するデータで上書きする。
            // 2007.09.26 hikita upd start ------------------------------------------------------------>>
            //goodsSetWork.GoodsSetCode       = goodsSet.GoodsSetCode;        // 商品セットコード
            //goodsSetWork.GoodsSetName       = goodsSet.GoodsSetName;        // 商品セット名称
            //goodsSetWork.GoodsSetShortName  = goodsSet.GoodsSetShortName;   // 商品セット略称
            //goodsSetWork.ParentMakerCode    = goodsSet.ParentMakerCode;     // 親商品メーカーコード
            //goodsSetWork.ParentGoodsCode    = goodsSet.ParentGoodsCode;     // 親商品コード
            //goodsSetWork.CellphoneModelCode = goodsSet.CellphoneModelCode;  // 機種コード
            //goodsSetWork.DisplayOrder       = goodsSet.DisplayOrder;        // 表示順位
            //goodsSetWork.MakerCode          = goodsSet.MakerCode;           // メーカーコード
            //goodsSetWork.GoodsCode          = goodsSet.GoodsCode;           // 商品コード
            goodsSetWork.ParentGoodsMakerCd   = goodsSet.ParentGoodsMakerCd;  // 親メーカーコード
            goodsSetWork.ParentMakerName = goodsSet.ParentGoodsMakerName;     // 親メーカー名
            goodsSetWork.ParentGoodsNo        = goodsSet.ParentGoodsNo;       // 親商品コード
            goodsSetWork.ParentGoodsName = goodsSet.ParentGoodsName;            // 親商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //goodsSetWork.ParentGoodsName      = goodsSet.ParentGoodsName;     // 親商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            goodsSetWork.SubGoodsMakerCd = goodsSet.SubGoodsMakerCd;     // 商品メーカー
            goodsSetWork.SubMakerName = goodsSet.SubGoodsMakerName;      // 商品メーカー名
            goodsSetWork.SubGoodsNo           = goodsSet.SubGoodsNo;          // 商品コード
            goodsSetWork.SubGoodsName = goodsSet.SubGoodsName;          // 商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //goodsSetWork.SubGoodsName = goodsSet.SubGoodsName;        // 商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            goodsSetWork.CntFl = goodsSet.CntFl;               // 数量
            goodsSetWork.DisplayOrder         = goodsSet.DisplayOrder;        // 表示順位
            goodsSetWork.SetSpecialNote       = goodsSet.SetSpecialNote;      // セット規格・特記事項
            goodsSetWork.CatalogShapeNo       = goodsSet.CatalogShapeNo;      // カタログ図番
            // 2007.09.26 hikita upd end --------------------------------------------------------------<<
            
            return goodsSetWork;
        }

        /// <summary>
        /// 商品セットデータテーブル登録・更新処理
        /// </summary>
        /// <param name="paraobj">商品セットオブジェクト</param>
        /// <remarks>
        /// Note       : 商品セット情報をデータテーブルに登録します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        private void EditDataTable(object paraobj)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            Type paraType = paraobj.GetType();

            #region ●Object → GoodsSetWorkクラス処理
            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsSetWork = (GoodsSetWork)paraList[0];
            }
            else if (paraType.Name == "GoodsSetWork")
            {
                goodsSetWork = (GoodsSetWork)paraobj;
            }
            // 2008.08.04 30413 犬飼 商品セット設定オブジェクトの場合を追加 >>>>>>START
            else if (paraType.Name == "GoodsSet")
            {
                goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet((GoodsSet)paraobj);
            }
            // 2008.08.04 30413 犬飼 商品セット設定オブジェクトの場合を追加 <<<<<<END
            #endregion

            //GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            
            #region ●子商品情報データテーブル作成

            ChildGoodsInfoDataTable.BeginLoadData();

            // 子商品情報登録データ行
            DataRow AddChildRow;

            // プライマリキー配列(子商品情報用)
            //object[] objKeyArray = new object[] { goodsSetWork.GoodsSetCode, goodsSetWork.MakerCode, goodsSetWork.GoodsCode };                                         // 2007.09.26 hikita del
            //object[] objKeyArray = new object[] { goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo, goodsSetWork.SubGoodsMakerCd, goodsSetWork.SubGoodsNo };  // 2007.09.26 hikita add
            // 2008.08.04 30413 犬飼 プライマリキー配列(子商品情報用)を変更 >>>>>>START
            object[] objKeyArray = new object[] { goodsSetWork.ParentGoodsNo, goodsSetWork.ParentGoodsMakerCd, goodsSetWork.SubGoodsNo, goodsSetWork.SubGoodsMakerCd };
            // 2008.08.04 30413 犬飼 プライマリキー配列(子商品情報用)を変更 <<<<<<END
            
            // < 新規登録 or 更新 のチェック >
            if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) == null)
            {
                //子商品情報データテーブルに新しい行を追加する
                AddChildRow = ChildGoodsInfoDataTable.NewRow();
            }
            else
            {
                //既存データテーブルの行を編集する
                AddChildRow = ChildGoodsInfoDataTable.Rows.Find(objKeyArray);
            }

            #region < 商品セットマスタからデータ取得 >
            //AddChildRow[FILEHEADERGUID_TITLE] = goodsSetWork.FileHeaderGuid;      // GUID
            AddChildRow[FILEHEADERGUID_TITLE] = CreateHashKey(goodsSetWork);      // 主キー
            // 2007.09.26 hikita upd start ----------------------------------------------------------->>
            //AddChildRow[GOODSSETCODE_TITLE] = goodsSetWork.GoodsSetCode;        // 商品セットコード
            //AddChildRow[MAKERCODE_TITLE] = goodsSetWork.MakerCode;              // メーカーコード
            //AddChildRow[GOODSCODE_TITLE] = goodsSetWork.GoodsCode;              // 商品コード
            // 2008.08.04 30413 犬飼 親メーカーコードに子のメーカーコードを設定いたのを修正 >>>>>>START
            //AddChildRow[PARENTGOODSMAKERCD_TITLE] = goodsSetWork.SubGoodsMakerCd; // 親メーカーコード
            AddChildRow[PARENTGOODSMAKERCD_TITLE] = goodsSetWork.ParentGoodsMakerCd; // 親メーカーコード
            // 2008.08.04 30413 犬飼 親メーカーコードに子のメーカーコードを設定いたのを修正 <<<<<<END
            AddChildRow[PARENTGOODSNO_TITLE] = goodsSetWork.ParentGoodsNo;        // 親品番
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //AddChildRow[PARENTGOODSNAME_TITLE] = goodsSetWork.ParentGoodsName;    // 親品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            AddChildRow[SUBGOODSMAKERCD_TITLE] = goodsSetWork.SubGoodsMakerCd;    // 子メーカーコード
            AddChildRow[SUBGOODSNO_TITLE] = goodsSetWork.SubGoodsNo;              // 子品番
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //AddChildRow[SUBGOODSNAME_TITLE] = goodsSetWork.SubGoodsName;          // 子品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            //AddChildRow[CNTFL_TITLE] = goodsSetWork.CntFl;                        // 数量
            AddChildRow[CNTFL_TITLE] = goodsSetWork.CntFl.ToString("##0.00");                        // 数量
            AddChildRow[DISPLAYORDER_TITLE] = goodsSetWork.DisplayOrder;          // 表示順位
            AddChildRow[SETSPECIALNOTE_TITLE] = goodsSetWork.SetSpecialNote;      // セット規格・特記事項
            AddChildRow[CATALOGSHAPENO_TITLE] = goodsSetWork.CatalogShapeNo;      // カタログ図番
            // 2007.09.26 hikita upd end -------------------------------------------------------------<<
            #endregion

            // 2008.08.04 30413 犬飼 商品検索を使って名称データ取得を変更 >>>>>>START
            #region < 商品検索を使って名称データ取得 > <<<<<<変更前
            //// 子商品情報の取得
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kideate START
            ////int chdStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.MakerCode, goodsSetWork.GoodsCode, out goodsUnitData);
            ////int chdStatus = goodsAcs.Read(true, goodsSetWork.EnterpriseCode, goodsSetWork.MakerCode, goodsSetWork.GoodsCode, out goodsUnitData);       // 2007.09.26 hikita del
            //int chdStatus = goodsAcs.Read(true, goodsSetWork.EnterpriseCode, goodsSetWork.SubGoodsMakerCd, goodsSetWork.SubGoodsNo, out goodsUnitData);  // 2007.09.26 hikita add
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate END

            //// 子商品情報のクローンを作成
            //// 2007.09.26 hikita upd start ---------------------------------------------------->>
            ////AddChildRow[MAKERNAME_TITLE] = goodsUnitData.MakerName;          // メーカー名称
            ////AddChildRow[GOODSNAME_TITLE] = goodsUnitData.GoodsName;          // 商品名称
            //AddChildRow[SUBGOODSMAKERNM_TITLE] = goodsUnitData.MakerName;      // メーカー名称
            //// 2007.09.26 hikita upd end ------------------------------------------------------<<
            #endregion


            #region < 商品検索を使って名称データ取得 >
            // 子商品情報の条件設定
            List<GoodsUnitData> goodsUnitDataList;

            // 商品・メーカー名称取得
            int status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Child, out goodsUnitDataList);

            // 子商品情報の設定
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 商品マスタデータクラス
                goodsUnitData = new GoodsUnitData();
                goodsUnitData = goodsUnitDataList[0];

                AddChildRow[SUBGOODSNAME_TITLE] = goodsUnitData.GoodsName;
                AddChildRow[SUBGOODSMAKERNM_TITLE] = goodsUnitData.MakerName;
                AddChildRow[DIVISION_TITLE] = goodsUnitData.OfferKubun;
                if (goodsUnitData.OfferKubun == 0)
                {
                    // 提供区分がユーザー
                    AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_USER;
                }
                else
                {
                    // 提供区分が提供
                    AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_OFFER;
                }
            }
            #endregion
            // 2008.08.04 30413 犬飼 商品検索を使って名称データ取得を変更 <<<<<<END
            

            // < 新規に登録する場合 >
            if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) == null)
            {
                // 作成したデータ行の追加
                this.ChildGoodsInfoDataTable.Rows.Add(AddChildRow);
            }

            this.ChildGoodsInfoDataTable.EndLoadData();

            #endregion

            #region ●画面表示用データテーブル作成

            this.GoodsSetDataTable.BeginLoadData();

            DataRow AddRow;         // 画面表示用登録データ行

            // プライマリキー(表示用)
            // 2007.09.26 hikita upd start ----------------------------------------------------->>
            //string keyCode = goodsSetWork.GoodsSetCode;

            // < 新規登録 or 更新 のチェック >
            //if (this.GoodsSetDataTable.Rows.Find(keyCode) == null)
            //{
            //    AddRow = this.GoodsSetDataTable.NewRow();
            //}
            //else
            //{
            //    AddRow = this.GoodsSetDataTable.Rows.Find(keyCode);
            //}
            // 2008.08.07 30413 犬飼 プライマリキー(表示用)を変更 >>>>>>START
            //object[] objKey = new object[] { goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo };
            object[] objKey = new object[] { goodsSetWork.ParentGoodsNo, goodsSetWork.ParentGoodsMakerCd };
            // 2008.08.07 30413 犬飼 プライマリキー(表示用)を変更 <<<<<<END
            
            // < 新規登録 or 更新 のチェック >
            if (this.GoodsSetDataTable.Rows.Find(objKey) == null)
            {
                AddRow = this.GoodsSetDataTable.NewRow();
            }
            else
            {
                AddRow = this.GoodsSetDataTable.Rows.Find(objKey);
            }
            // 2007.09.26 hikita upd end -------------------------------------------------------<<

            #region < 商品セットマスタからデータ取得 >
            // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 >>>>>>START
            //if (goodsSetWork.LogicalDeleteCode == 0)
            //{
            //    // 論理削除されていなかったら削除日は空
            //    AddRow[DELETE_DATE] = "";
            //}
            //else
            //{
            //    // 論理削除されていたら削除日に更新日付を登録
            //    AddRow[DELETE_DATE] = TDateTime.DateTimeToString(DATATIME_FORM, goodsSetWork.UpdateDateTime);
            //}
            //AddRow[LOGICALDELETE_TITLE]     = goodsSetWork.LogicalDeleteCode;       // 論理削除区分
            // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 <<<<<<END
            
            // 2007.09.26 hiktia upd start --------------------------------------------------------------->>
            //AddRow[GOODSSETCODE_TITLE]      = goodsSetWork.GoodsSetCode;            // 商品セットコード
            //AddRow[GOODSSETNAME_TITLE]      = goodsSetWork.GoodsSetName;            // 商品セット名称
            //AddRow[GOODSSETSHORTNAME_TITLE] = goodsSetWork.GoodsSetShortName;       // 商品セット略称
            //AddRow[PARENTMAKERCODE_TITLE]   = goodsSetWork.ParentMakerCode;         // 親商品メーカーコード
            //AddRow[PARENTGOODSCODE_TITLE]   = goodsSetWork.ParentGoodsCode;         // 親商品コード
            //AddRow[CELLPHONEMODELCODE_TITLE] = goodsSetWork.CellphoneModelCode;      // 機種コード
            //AddRow[DISPLAYORDER_TITLE]      = goodsSetWork.DisplayOrder;            // 表示順位
            //AddRow[MAKERCODE_TITLE]         = goodsSetWork.MakerCode;               // メーカーコード
            //AddRow[GOODSCODE_TITLE]         = goodsSetWork.GoodsCode;               // 商品コード
            AddRow[PARENTGOODSMAKERCD_TITLE]  = goodsSetWork.ParentGoodsMakerCd;    // 親メーカーコード
            AddRow[PARENTGOODSNO_TITLE]       = goodsSetWork.ParentGoodsNo;         // 親商品コード
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //AddRow[PARENTGOODSNAME_TITLE] = goodsSetWork.ParentGoodsName;         // 親商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            AddRow[SUBGOODSMAKERCD_TITLE] = goodsSetWork.SubGoodsMakerCd;           // 子メーカーコード
            AddRow[SUBGOODSNO_TITLE]          = goodsSetWork.SubGoodsNo;            // 子商品コード
            // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
            //AddRow[SUBGOODSNAME_TITLE] = goodsSetWork.SubGoodsName;            // 子商品名
            // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
            //AddRow[CNTFL_TITLE] = goodsSetWork.CntFl;                               // 数量
            AddRow[CNTFL_TITLE] = goodsSetWork.CntFl.ToString("##0.00");                               // 数量
            AddRow[DISPLAYORDER_TITLE] = goodsSetWork.DisplayOrder;          // 表示順位
            AddRow[SETSPECIALNOTE_TITLE]      = goodsSetWork.SetSpecialNote;        // セット規格・特記事項
            AddRow[CATALOGSHAPENO_TITLE]      = goodsSetWork.CatalogShapeNo;        // カタログ図番
            // 2007.09.26 hikita upd end -----------------------------------------------------------------<<
            #endregion

            // 2008.08.04 30413 犬飼 商品検索を使って名称データ取得を変更 >>>>>>START
            #region < 商品検索を使って名称データ取得 >
            //// 親商品情報の取得
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-kidate START
            ////int parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.ParentMakerCode, goodsSetWork.ParentGoodsCode, out goodsUnitData);
            ////int parStatus = goodsAcs.Read(true, goodsSetWork.EnterpriseCode, goodsSetWork.ParentMakerCode, goodsSetWork.ParentGoodsCode, out goodsUnitData);   // 2007.09.26 hikita del
            //int parStatus = goodsAcs.Read(true, goodsSetWork.EnterpriseCode, goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo, out goodsUnitData);    // 2007.09.26 hikita add
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate END
            
            //// 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            ////AddRow[PARENTMAKERNAME_TITLE]       = goodsUnitData.MakerName;              // 親商品メーカー名称
            ////AddRow[PARENTGOODSNAME_TITLE]       = goodsUnitData.GoodsName;              // 親商品名称
            ////AddRow[CELLPHONEMODELNAME_TITLE]    = goodsUnitData.CellphoneModelName;     // 機種名称
            //AddRow[PARENTGOODSMAKERNM_TITLE]      = goodsUnitData.MakerName;              // 親商品メーカー名称
            //// 2007.09.26 hikita upd end ------------------------------------------------------------------------<<

            //// 子商品情報クローンから画面に表示する子商品情報を取得
            //// 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            ////this.ChildGoodsInfoDataTable.DefaultView.RowFilter = GOODSSETCODE_TITLE + " = '" + keyCode + "'";
            //string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            //this.ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
            //                                                     PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            //// 2007.09.26 hikita upd end ------------------------------------------------------------------------<<


            //if (this.ChildGoodsInfoDataTable.DefaultView.Count > 0)
            //{
            //    // 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            //    //AddRow[MAKERNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][MAKERNAME_TITLE];
            //    //AddRow[GOODSNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][GOODSNAME_TITLE];
            //    AddRow[SUBGOODSMAKERNM_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERNM_TITLE];
            //    AddRow[SUBGOODSNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNAME_TITLE];
            //    // 2007.09.26 hikita upd end ------------------------------------------------------------------------<<
            //}

            #endregion

            #region < 商品検索を使って名称データ取得 >
            // 親商品情報の条件設定
            goodsUnitDataList = new List<GoodsUnitData>();
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            
            // 商品・メーカー名称取得
            status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Parent, out goodsUnitDataList);
            //int status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Parent, out goodsUnitDataList);

            // 親商品情報の設定
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 商品マスタデータクラス
                goodsUnitData = new GoodsUnitData();
                goodsUnitData = goodsUnitDataList[0];

                AddRow[PARENTGOODSNAME_TITLE] = goodsUnitData.GoodsName;
                AddRow[PARENTGOODSMAKERNM_TITLE] = goodsUnitData.MakerName;
            }

            // 子商品情報クローンから画面に表示する子商品情報を取得
            string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            this.ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                                 PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            if (this.ChildGoodsInfoDataTable.DefaultView.Count > 0)
            {
                // フィルタ後のビューを表示順位でソート
                this.ChildGoodsInfoDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc";
            
                // データビューが0件より大きい場合、名称を設定
                AddRow[DISPLAYORDER_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][DISPLAYORDER_TITLE];          // 表示順位
                AddRow[SUBGOODSMAKERCD_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE];
                AddRow[SUBGOODSNO_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE];
                AddRow[SUBGOODSMAKERNM_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERNM_TITLE];
                AddRow[SUBGOODSNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNAME_TITLE];
                // 2009.01.15 30413 犬飼 数量とセット規格・特記事項を表示順位の最小の値を設定 >>>>>>START
                AddRow[CNTFL_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][CNTFL_TITLE];                         // 数量
                AddRow[SETSPECIALNOTE_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SETSPECIALNOTE_TITLE];       // セット規格・特記事項
                // 2009.01.15 30413 犬飼 数量とセット規格・特記事項を表示順位の最小の値を設定 <<<<<<END
            }
            #endregion
            // 2008.08.04 30413 犬飼 商品検索を使って名称データ取得を変更 <<<<<<END

            #region < 複数の表示 >
            //this.ChildGoodsInfoDataTable.DefaultView.RowFilter = GOODSSETCODE_TITLE + " = '" + keyCode + "'";
            if (this.ChildGoodsInfoDataTable.DefaultView.Count > 1)      // 複数
            {
                AddRow[CHILDPLURALGOODS_TITLE] = "※";
            }
            else
            {
                AddRow[CHILDPLURALGOODS_TITLE] = "";
            }

            #endregion

            // < 新規に登録する場合 >
            //if (this.GoodsSetDataTable.Rows.Find(keyCode) == null)  // 2007.09.26 hikita del
            if (this.GoodsSetDataTable.Rows.Find(objKey) == null)     // 2007.09.26 hikita add
            {
                // 作成したデータ行の追加
                this.GoodsSetDataTable.Rows.Add(AddRow);
            }

            this.GoodsSetDataTable.EndLoadData();

            #endregion

        }

        /// <summary>
        /// 商品セットテーブルデータ削除処理
        /// </summary>
        /// <param name="goodsSetWork">商品セットワーカークラス</param>
        /// <remarks>
        /// Note       : 商品セット情報テーブルのデータを1件削除します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        private void RemoveDataTable(GoodsSetWork goodsSetWork)
        {
            #region ●画面表示用データテーブル削除
            // 2007.09.26 hikita upd start ------------------------------------------------------>>
            // 画面表示用プライマリキー
            //string keyCode = goodsSetWork.GoodsSetCode;

            //if (GoodsSetDataTable.Rows.Find(keyCode) != null)
            //{
                // 画面表示用テーブルの削除
            //    GoodsSetDataTable.Rows.Find(keyCode).Delete();
            //}
            // 2008.08.05 30413 犬飼 画面表示用プライマリキーを変更 >>>>>>START
            //object[] objKey = new object[] { goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo };
            object[] objKey = new object[] { goodsSetWork.ParentGoodsNo, goodsSetWork.ParentGoodsMakerCd };
            // 2008.08.05 30413 犬飼 画面表示用プライマリキーを変更 <<<<<<END
                
            // < 新規登録 or 更新 のチェック >
            if (this.GoodsSetDataTable.Rows.Find(objKey) != null)
            {
                // 画面表示用テーブルの削除
                GoodsSetDataTable.Rows.Find(objKey).Delete();
            }
            // 2007.09.26 hikita upd end -------------------------------------------------------<<
            #endregion
        }

        /// <summary>
        /// 子商品情報テーブルデータ削除処理
        /// </summary>
        /// <param name="goodsSetWork">商品セットワーカークラス</param>
        /// <remarks>
        /// Note       : 子商品情報テーブルのデータを1件削除します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.14<br />
        /// </remarks>
        private void RemoveChildDataTable(GoodsSetWork goodsSetWork)
        {
            // 商品セットコードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            // 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            //ChildGoodsInfoDataTable.DefaultView.RowFilter = GOODSSETCODE_TITLE + " = '" + goodsSetWork.GoodsSetCode + "'";
            string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            // 2007.09.26 hikita upd end ------------------------------------------------------------------------<<

            int cnt = ChildGoodsInfoDataTable.DefaultView.Count;

            for (int i = 0; i < cnt; i++)
            {
                #region ●子商品情報データテーブル削除
            
                // 子商品情報プライマリキー
                // 2008.08.05 30413 犬飼 子商品情報プライマリキーを変更 >>>>>>START
                //// 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
                ////object[] objKeyArray = new object[] {   ChildGoodsInfoDataTable.DefaultView[0][GOODSSETCODE_TITLE],
                ////                                        ChildGoodsInfoDataTable.DefaultView[0][MAKERCODE_TITLE],
                ////                                        ChildGoodsInfoDataTable.DefaultView[0][GOODSCODE_TITLE]     };

                //object[] objKeyArray = new object[] {   ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSMAKERCD_TITLE],
                //                                        ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSNO_TITLE],
                //                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE],     
                //                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE]       };
                //// 2007.09.26 hikita upd end ------------------------------------------------------------------------<<
                object[] objKeyArray = new object[] {   ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSNO_TITLE],
                                                        ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSMAKERCD_TITLE],
                                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE],     
                                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE]       };
                // 2008.08.05 30413 犬飼 子商品情報プライマリキーを変更 <<<<<<END
                
                if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) != null)
                {
                    // 子商品情報データテーブル削除
                    ChildGoodsInfoDataTable.Rows.Find(objKeyArray).Delete();
                }

                #endregion
            }
        }

        /// <summary>
        /// 商品セットデータローカルキャッシュ処理
        /// </summary>
        /// <param name="paraobj">商品セットデータクラス</param>
        /// <remarks>
        /// Note       : 商品セット情報をローカルにキャッシュします。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        private void SetCacheData(object paraobj)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            Type paraType = paraobj.GetType();

            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsSetWork = (GoodsSetWork)paraList[0];
            }
            else if (paraType.Name == "GoodsSetWork")
            {
                goodsSetWork = (GoodsSetWork)paraobj;
            }
            // 2008.08.04 30413 犬飼 商品セット設定オブジェクトの場合を追加 >>>>>>START
            else if (paraType.Name == "GoodsSet")
            {
                goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet((GoodsSet)paraobj);
            }
            // 2008.08.04 30413 犬飼 商品セット設定オブジェクトの場合を追加 <<<<<<END

            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
            // ディクショナリークラスに保存
            //GoodsSetWorkDictionary.Add(goodsSetWork.FileHeaderGuid, goodsSetWork);
            string key = CreateHashKey(goodsSetWork);
            // --- ADD m.suzuki 2010/08/04 ---------->>>>>
            if ( GoodsSetWorkDictionary.ContainsKey( key ) )
            {
                GoodsSetWorkDictionary.Remove( key );
            }
            // --- ADD m.suzuki 2010/08/04 ----------<<<<<
            GoodsSetWorkDictionary.Add(key, goodsSetWork);
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            
            // リストクラスに保存
            // --- UPD m.suzuki 2010/08/04 ---------->>>>>
            //GoodsSetWorkList.Add(goodsSetWork);
            AddToGoodsSetWorkList( ref GoodsSetWorkList, goodsSetWork );
            // --- UPD m.suzuki 2010/08/04 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/08/04 ---------->>>>>
        /// <summary>
        /// リストへの追加処理
        /// </summary>
        /// <param name="goodsSetWorkList"></param>
        /// <param name="addWork"></param>
        private void AddToGoodsSetWorkList( ref List<GoodsSetWork> goodsSetWorkList, GoodsSetWork addWork )
        {
            List<GoodsSetWork> deleteList = goodsSetWorkList.FindAll(
                delegate( GoodsSetWork wkGoodsSetWork )
                {
                    if ( (wkGoodsSetWork.ParentGoodsMakerCd == addWork.ParentGoodsMakerCd) &&
                         (wkGoodsSetWork.ParentGoodsNo == addWork.ParentGoodsNo) &&
                         (wkGoodsSetWork.SubGoodsMakerCd == addWork.SubGoodsMakerCd) &&
                         (wkGoodsSetWork.SubGoodsNo == addWork.SubGoodsNo) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 該当があれば削除
            if ( deleteList != null || deleteList.Count > 0 )
            {
                foreach ( GoodsSetWork deleteWork in deleteList )
                {
                    goodsSetWorkList.Remove( deleteWork );
                }
            }

            // 追加
            goodsSetWorkList.Add( addWork );
        }
        // --- ADD m.suzuki 2010/08/04 ----------<<<<<

        /// <summary>
        /// 商品セットキャッシュデータ削除処理
        /// </summary>
        /// <param name="goodsSetWork">商品セットコード</param>
        /// <remarks>
        /// Note       : 商品セット情報のキャッシュデータ１件削除します。<br />
        /// Programmer : 30005 木建　翼<br />
        /// Date       : 2007.05.08<br />
        /// </remarks>
        private void RemoveCacheData(GoodsSetWork goodsSetWork)
        {
    
            // 商品セットコードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            // 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            //ChildGoodsInfoDataTable.DefaultView.RowFilter = GOODSSETCODE_TITLE + " = '" + goodsSetWork.GoodsSetCode + "'";
            string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            // 2007.09.26 hikita upd end ------------------------------------------------------------------------<<

            int cnt = ChildGoodsInfoDataTable.DefaultView.Count;

            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
            for (int i = 0; i < cnt; i++)
            {
                //Guid guid = (Guid)ChildGoodsInfoDataTable.DefaultView[i][FILEHEADERGUID_TITLE];
                string key = (string)ChildGoodsInfoDataTable.DefaultView[i][FILEHEADERGUID_TITLE];
            
                if (GoodsSetWorkDictionary != null && GoodsSetWorkList != null)
                {
                    //if (GoodsSetWorkDictionary.ContainsKey(guid) == true)
                    if (GoodsSetWorkDictionary.ContainsKey(key) == true)
                    {   
                        // リスト削除のためのデータワーククラスを保持
                        GoodsSetWork removeData = new GoodsSetWork();
                        //removeData = GoodsSetWorkDictionary[guid];
                        removeData = GoodsSetWorkDictionary[key];

                        // ディクショナリークラスのデータを削除
                        //GoodsSetWorkDictionary.Remove(guid);
                        GoodsSetWorkDictionary.Remove(key);

                        // リストクラスの削除
                        if (GoodsSetWorkList.Contains(removeData) == true)
                        {
                            GoodsSetWorkList.Remove(removeData);
                        }
                    }
                }
            }
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            

        }

        /// <summary>
        /// 商品セットガイド構築
        /// </summary>
        /// <param name="guideList"></param>
        /// <param name="mode"></param>
        /// <remarks>
        /// <br>Note		    : 商品セットガイドを構築します。</br>
        /// <br>Programmer	    : 30005 木建　翼</br>
        /// <br>Date		    : 2007.05.08</br>
        /// </remarks>
        private void GuideConstruction(ref DataSet guideList, int mode)
        {
            // ガイド初期起動時はカラム設定をおこなう
            if (guideList.Tables.Count == 0)
            {
                DataTable table = new DataTable();
                DataColumn column;

                // 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.Int32");
                //column.ColumnName = "GoodsSetCode";
                //table.Columns.Add(column);

                //column = new DataColumn();
                //column.DataType = Type.GetType("System.String");
                //column.ColumnName = "GoodsSetName";
                //table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "ParentGoodsMakerCd";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "ParentGoodsNo";
                table.Columns.Add(column);
                // 2007.09.26 hikita upd end ------------------------------------------------------------------------<<

                guideList.Tables.Add(table.Clone());
            }

            guideList.Tables[0].BeginLoadData();
            // 全件検索によって取得したキャッシュデータを使用
            foreach (GoodsSetWork goodsSetWork in GoodsSetWorkList)
            {
                if (goodsSetWork.LogicalDeleteCode == 0)
                {
                    DataRow dataRow = guideList.Tables[0].NewRow();
                    //dataRow["GoodsSetCode"] = goodsSetWork.GoodsSetCode;            // 2007.09.26 hikita del
                    dataRow["ParentGoodsMakerCd"] = goodsSetWork.ParentGoodsMakerCd;  // 2007.09.26 hikita add
                    dataRow["ParentGoodsNo"]      = goodsSetWork.ParentGoodsNo;       // 2007.09.26 hikita add
                    guideList.Tables[0].Rows.Add(dataRow);
                }
            }
  
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="goodsSetList">商品セットデータクラスリスト</param>
        /// <param name="goodsSetCode">検索キー</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品セット名称を取得します。</br>
        /// <br>Programmer	: 30005 木建　翼</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private void GetGoodsSetDataList(ref List<GoodsSet> goodsSetList, string goodsSetCode)
        {
            GoodsSet goodsSet = new GoodsSet();
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            //Guid guid;
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
            string key;
            // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            
            // 作成したテーブルを商品コードでフィルタし該当データを取得
            //this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView.RowFilter = GoodsSetAcs.DELETE_DATE + " = '' AND " + 
            //                                                                    GoodsSetAcs.GOODSSETCODE_TITLE + " = '" + goodsSetCode + "'";

            // 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            //this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.RowFilter = GoodsSetAcs.GOODSSETCODE_TITLE + " = '" + goodsSetCode + "'";
            string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                                                            PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            // 2007.09.26 hikita upd end ------------------------------------------------------------------------<<

            // 商品コードでソートする
            // 2008.08.12 30413 犬飼 表示に使用することは無いのでソートしない >>>>>>START
            //// 2007.09.26 hikita upd start ---------------------------------------------------------------------->>
            ////this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Sort = GOODSSETCODE_TITLE + " asc";
            //this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Sort = SUBGOODSMAKERCD_TITLE + " asc, " + SUBGOODSNO_TITLE + " asc";
            //// 2007.09.26 hikita upd end ------------------------------------------------------------------------<<
            // 2008.08.12 30413 犬飼 表示に使用することは無いのでソートしない <<<<<<END

            int cnt = this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Count;
            
            #region ●該当データリスト作成
            for (int i = 0; i < cnt; i++)
            {
                goodsSet = new GoodsSet();
                //GoodsAcs goodsAcs = new GoodsAcs();

                //#region < 親商品情報取得 >
                //goodsSet.GoodsSetCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.GoodsSetName = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.GoodsSetShortName = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.ParentMakerCode = (int)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.ParentGoodsCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.CellphoneModelCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //goodsSet.DisplayOrder = (int)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[0][GOODSSETCODE_TITLE];
                //#endregion

                //#region < セット商品情報取得 >
                //goodsSet.MakerCode = (int)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[i][MAKERCODE_TITLE];
                //goodsSet.GoodsCode = (string)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[i][GOODSCODE_TITLE];
                //#endregion

                // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
                //guid = (Guid)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[i][FILEHEADERGUID_TITLE];
                key = (string)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[i][FILEHEADERGUID_TITLE];
                //goodsSetWork = GoodsSetWorkDictionary[guid];
                goodsSetWork = GoodsSetWorkDictionary[key];
                // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            
                // 論理削除されたデータでないとリストに追加しない
                if (goodsSetWork.LogicalDeleteCode == 0)
                {
                    // 2007.09.26 hikita upd start ------------------------------------------------>>
                    //goodsSet.GoodsSetCode = goodsSetWork.GoodsSetCode;
                    //goodsSet.GoodsSetName = goodsSetWork.GoodsSetName;
                    //goodsSet.GoodsSetShortName = goodsSetWork.GoodsSetShortName;
                    //goodsSet.ParentMakerCode = goodsSetWork.ParentMakerCode;
                    //goodsSet.ParentGoodsCode = goodsSetWork.ParentGoodsCode;
                    //goodsSet.CellphoneModelCode = goodsSetWork.CellphoneModelCode;
                    //goodsSet.MakerCode = goodsSetWork.MakerCode;
                    //goodsSet.GoodsCode = goodsSetWork.GoodsCode;
                    goodsSet.ParentGoodsMakerCd = goodsSetWork.ParentGoodsMakerCd;
                    // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
                    //goodsSet.ParentGoodsName = goodsSetWork.ParentGoodsName;
                    // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
                    goodsSet.ParentGoodsNo = goodsSetWork.ParentGoodsNo;
                    goodsSet.SetSpecialNote = goodsSetWork.SetSpecialNote;
                    goodsSet.SubGoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
                    // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
                    //goodsSet.SubGoodsName = goodsSetWork.SubGoodsName;
                    // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
                    goodsSet.SubGoodsNo = goodsSetWork.SubGoodsNo;
                    goodsSet.CntFl = goodsSetWork.CntFl;
                    goodsSet.DisplayOrder = goodsSetWork.DisplayOrder;
                    goodsSet.CatalogShapeNo = goodsSetWork.CatalogShapeNo;
                    // 2007.09.26 hikita upd end --------------------------------------------------<<

                    // 2008.08.05 30413 犬飼 親商品情報取得処理を変更 >>>>>>START
                    #region 親商品情報取得処理 <<<<<<変更前
                    //GoodsUnitData goodsUnitData1;
                    //// 親商品情報取得処理
                    ////int parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.ParentMakerCode, goodsSetWork.ParentGoodsCode, out goodsUnitData1);  // 2007.09.26 hikita del
                    //int parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo, out goodsUnitData1);   // 2007.09.26 hikita add
                    //if (parStatus == 0 && goodsUnitData1 != null)
                    //{
                    //    //goodsSet.ParentMakerName = goodsUnitData1.MakerName;  // 2007.09.26 hikita del
                    //    goodsSet.ParentGoodsName = goodsUnitData1.GoodsName;
                    //}
                    #endregion

                    #region 親商品情報取得処理
                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

                    // 商品・メーカー名称取得
                    int status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Parent, out goodsUnitDataList);

                    // 親商品情報の設定
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 商品マスタデータクラス
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        goodsSet.ParentGoodsName = goodsUnitData.GoodsName;
                    }
                    #endregion
                    // 2008.08.05 30413 犬飼 親商品情報取得処理を変更 <<<<<<END

                    // 2008.08.05 30413 犬飼 セット商品情報取得処理を変更 >>>>>>START
                    #region セット商品情報取得処理 <<<<<<変更前
                    //GoodsUnitData goodsUnitData2;
                    //// セット商品情報取得処理
                    ////parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.MakerCode, goodsSetWork.GoodsCode, out goodsUnitData2);      // 2007.09.26 hikita del
                    //parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.SubGoodsMakerCd, goodsSetWork.SubGoodsNo, out goodsUnitData2); // 2007.09.26 hikita add

                    //if (parStatus == 0 && goodsUnitData2 != null)
                    //{
                    //    //goodsSet.MakerName = goodsUnitData2.MakerName;       // 2007.09.26 hikita del
                    //    //goodsSet.GoodsName = goodsUnitData2.GoodsName;       // 2007.09.26 hikita del
                    //    goodsSet.SubGoodsName = goodsUnitData2.GoodsName;      // 2007.09.26 hikita add
                    //}
                    #endregion

                    #region セット商品情報取得処理
                    goodsUnitDataList = new List<GoodsUnitData>();

                    // 商品・メーカー名称取得
                    status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Child, out goodsUnitDataList);

                    // セット商品情報の設定
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 商品マスタデータクラス
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        goodsSet.SubGoodsName = goodsUnitData.GoodsName;
                    }
                    #endregion
                    // 2008.08.05 30413 犬飼 セット商品情報取得処理を変更 <<<<<<END
                    

                    #region < データリストに追加 >
                    goodsSetList.Add(goodsSet);
                    #endregion
                }
            }
            #endregion
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="goodsSetList">商品セットデータクラスリスト</param>
        /// <param name="parentMakerCode">親メーカーコード</param>
        /// <param name="parentGoodsCode">親品番</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品セット名称を取得します。</br>
        /// <br>Programmer	: 30005 木建　翼</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private void GetGoodsSetDataList(ref List<GoodsSet> goodsSetList, int parentMakerCode, string parentGoodsCode )
        {
            GoodsSet goodsSet;
            //GoodsAcs goodsAcs = new GoodsAcs();
                        
            string rowFilter;
            
            // 作成したテーブルをフィルタし該当データを取得
            rowFilter = this.CreateReadRowFilter(parentMakerCode, parentGoodsCode);
            this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView.RowFilter = rowFilter;
            int cnt = this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView.Count;

            #region ●該当データリスト作成
            //string goodsSetCode;  // 2007.09.26 hikita del

            string mCode;  // 2007.09.26 hikita add
            string gCode;  // 2007.09.26 hikita add
            int childGoodsCnt;
            
            for (int i = 0; i < cnt; i++)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.04 T-Kidate START
                //goodsSet = new GoodsSet();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.04 T-Kidate END

                // フィルタ後のデータテーブルの削除日がないデータ行だけ有効とする
                // 2008.08.20 30413 犬飼 削除日は無くなるので条件を削除 >>>>>>START
                //if ((string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[i][DELETE_DATE] == "")
                //{
                    // 2007.09.26 hikita upd start ----------------------------------------------------------------------------->>
                    //goodsSetCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[i][GOODSSETCODE_TITLE];
                    // 取得した商品セットコードで子商品情報テーブルをフィルタし、子商品情報のGUID取得
                    //this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.RowFilter = GOODSSETCODE_TITLE + " = '" + goodsSetCode + "'";
                    mCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[i][PARENTGOODSMAKERCD_TITLE];
                    gCode = (string)this.GoodsSetDataSet.Tables[GOODSSET_TABLE].DefaultView[i][PARENTGOODSNO_TITLE];

                    this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mCode + "' AND " +
                                                                                                    PARENTGOODSNO_TITLE + " = '" + gCode + "'";
                    // 品番でソートする
                    // 2008.08.12 30413 犬飼 表示に使用することは無いのでソートしない >>>>>>START
                    ////this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Sort = GOODSSETCODE_TITLE + " asc";
                    //this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Sort = SUBGOODSMAKERCD_TITLE + " asc, " + SUBGOODSNO_TITLE + " asc";
                    // 2008.08.12 30413 犬飼 表示に使用することは無いのでソートしない <<<<<<END
                    // 2007.09.26 hikita upd end -------------------------------------------------------------------------------<<

                    childGoodsCnt = this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView.Count;

                    // 該当セット商品情報の有効なデータすべてをリストに格納
                    for (int j = 0; j < childGoodsCnt; j++)
                    {
                        GoodsSetWork goodsSetWork = new GoodsSetWork();
                        // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
                        //goodsSetWork.FileHeaderGuid = (Guid)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[j][FILEHEADERGUID_TITLE];
                        string key = (string)this.ChildGoodsInfoDataSet.Tables[CHILDGOODSINFO_TABLE].DefaultView[j][FILEHEADERGUID_TITLE];
                        //goodsSetWork = GoodsSetWorkDictionary[goodsSetWork.FileHeaderGuid];
                        goodsSetWork = GoodsSetWorkDictionary[key];
                        // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.04 T-Kidate START
                        goodsSet = new GoodsSet();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.04 T-Kidate END

                        // ワーククラス→データクラスに格納
                        // 2007.09.26 hikita upd start ------------------------------------------->>
                        //goodsSet.GoodsSetCode = goodsSetWork.GoodsSetCode;
                        //goodsSet.GoodsSetName = goodsSetWork.GoodsSetName;
                        //goodsSet.GoodsSetShortName = goodsSetWork.GoodsSetShortName;
                        //goodsSet.ParentMakerCode = goodsSetWork.ParentMakerCode;
                        //goodsSet.ParentGoodsCode = goodsSetWork.ParentGoodsCode;
                        //goodsSet.CellphoneModelCode = goodsSetWork.CellphoneModelCode;
                        //goodsSet.MakerCode = goodsSetWork.MakerCode;
                        //goodsSet.GoodsCode = goodsSetWork.GoodsCode;
                        goodsSet.ParentGoodsMakerCd = goodsSetWork.ParentGoodsMakerCd;
                        // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
                        //goodsSet.ParentGoodsName = goodsSetWork.ParentGoodsName;
                        // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
                        goodsSet.ParentGoodsNo = goodsSetWork.ParentGoodsNo;
                        goodsSet.SetSpecialNote = goodsSetWork.SetSpecialNote;
                        goodsSet.SubGoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
                        // 2008.08.04 30413 犬飼 品名取得を変更 >>>>>>START
                        //goodsSet.SubGoodsName = goodsSetWork.SubGoodsName;
                        // 2008.08.04 30413 犬飼 品名取得を変更 <<<<<<END
                        goodsSet.SubGoodsNo = goodsSetWork.SubGoodsNo;
                        goodsSet.CntFl = goodsSetWork.CntFl;
                        goodsSet.DisplayOrder = goodsSetWork.DisplayOrder;
                        goodsSet.CatalogShapeNo = goodsSetWork.CatalogShapeNo;
                        // 2007.09.26 hikita upd end ---------------------------------------------<<

                        // 2008.08.05 30413 犬飼 親商品情報取得処理を変更 >>>>>>START
                        #region 親商品情報取得処理 <<<<<<変更前
                        //GoodsUnitData goodsUnitData1;
                        //// 親商品情報取得処理
                        ////int parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.ParentMakerCode, goodsSetWork.ParentGoodsCode, out goodsUnitData1); // 2007.09.26 hikita del
                        //int parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.ParentGoodsMakerCd, goodsSetWork.ParentGoodsNo, out goodsUnitData1);  // 2007.09.26 hikita add
                        //if (parStatus == 0 && goodsUnitData1 != null)
                        //{
                        //    //goodsSet.ParentMakerName = goodsUnitData1.MakerName;  // 2007.09.26 hikita del
                        //    goodsSet.ParentGoodsName = goodsUnitData1.GoodsName;
                        //}
                        #endregion

                        #region 親商品情報取得処理
                        List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

                        // 商品・メーカー名称取得
                        int status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Parent, out goodsUnitDataList);

                        // 親商品情報の設定
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 商品マスタデータクラス
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            goodsUnitData = goodsUnitDataList[0];

                            goodsSet.ParentGoodsName = goodsUnitData.GoodsName;
                        }
                        #endregion
                        // 2008.08.05 30413 犬飼 親商品情報取得処理を変更 <<<<<<END

                        // 2008.08.05 30413 犬飼 セット商品情報取得処理を変更 >>>>>>START
                        #region セット商品情報取得処理 <<<<<<変更前
                        //GoodsUnitData goodsUnitData2;
                        //// セット商品情報取得処理
                        ////parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.MakerCode, goodsSetWork.GoodsCode, out goodsUnitData2);      // 2007.09.26 hikita del
                        //parStatus = goodsAcs.Read(false, goodsSetWork.EnterpriseCode, goodsSetWork.SubGoodsMakerCd, goodsSetWork.SubGoodsNo, out goodsUnitData2); // 2007.09.26 hikita add
                        //if (parStatus == 0 && goodsUnitData2 != null)
                        //{
                        //    //goodsSet.MakerName = goodsUnitData2.MakerName; // 2007.09.26 hikita del
                        //    //goodsSet.GoodsName = goodsUnitData2.GoodsName; // 2007.09.26 hikita del
                        //    goodsSet.SubGoodsName = goodsUnitData2.GoodsName; // 2007.09.26 hikita add
                        //}
                        #endregion

                        #region セット商品情報取得処理
                        goodsUnitDataList = new List<GoodsUnitData>();

                        // 商品・メーカー名称取得
                        status = GetGoodMakerName(goodsSetWork, ParentChildDivState.Child, out goodsUnitDataList);

                        // セット商品情報の設定
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 商品マスタデータクラス
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            goodsUnitData = goodsUnitDataList[0];

                            goodsSet.SubGoodsName = goodsUnitData.GoodsName;
                        }
                        #endregion
                        // 2008.08.05 30413 犬飼 セット商品情報取得処理を変更 <<<<<<END

                        goodsSetList.Add(goodsSet);
                    }
                //}
                // 2008.08.20 30413 犬飼 削除日は無くなるので条件を削除 <<<<<<END                
            }
            #endregion
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="parentMakerCode">親メーカーコード</param>
        /// <param name="parentGoodsCode">親品番</param>
        /// <remarks>
        /// <br>Note		: キャッシュから商品セット名称を取得します。</br>
        /// <br>Programmer	: 30005 木建　翼</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private string CreateReadRowFilter(int parentMakerCode, string parentGoodsCode)
        {
            string rowFilter = "";

            #region < 親メーカーコードと親品番のみ >
            if (parentMakerCode != 0 && parentGoodsCode != "")
            {
                // 2007.09.26 hikita upd start ------------------------------------------------------->>
                //rowFilter = GoodsSetAcs.PARENTMAKERCODE_TITLE + " = '" + parentMakerCode + "' AND " +
                //             GoodsSetAcs.PARENTGOODSCODE_TITLE + " = '" + parentGoodsCode + "'";
                rowFilter = GoodsSetAcs.PARENTGOODSMAKERCD_TITLE + " = '" + parentMakerCode + "' AND " +
                             GoodsSetAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsCode + "'";
                // 2007.09.26 hikita upd end ---------------------------------------------------------<<
            }
            #endregion

            #region < 親品番のみ >
            else if (parentMakerCode == 0 && parentGoodsCode != "")
            {
                // 2007.09.26 hikita upd start ------------------------------------------------------->>
                //rowFilter = GoodsSetAcs.PARENTGOODSCODE_TITLE + " = '" + parentGoodsCode + "'";
                rowFilter = GoodsSetAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsCode + "'";
                // 2007.09.26 hikita upd end ---------------------------------------------------------<<
            }
            #endregion

            return rowFilter;
        }

        /// <summary>
        /// 商品・メーカー名称取得処理
        /// </summary>
        /// <param name="goodsSetWork">商品セットオブジェクトワーク</param>
        /// <param name="parentChildDivState">親子区分</param>
        /// <param name="goodsUnitDataList">商品マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note		: 商品・メーカー名称を取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.08.05</br>
        /// </remarks>
        private int GetGoodMakerName(GoodsSetWork goodsSetWork, ParentChildDivState parentChildDivState, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            string message;
            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
            //GoodsAcs goodsAcs = new GoodsAcs();
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsUnitDataList = new List<GoodsUnitData>();

            goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsCndtn.SectionCode = sectionCd;
            goodsCndtn.MakerName = "";
            goodsCndtn.GoodsNoSrchTyp = 0;

            if (parentChildDivState == ParentChildDivState.Parent)
            {
                // 親メーカーコード、親品番
                goodsCndtn.GoodsMakerCd = goodsSetWork.ParentGoodsMakerCd;
                goodsCndtn.GoodsNo = goodsSetWork.ParentGoodsNo;
            }
            else if (parentChildDivState == ParentChildDivState.Child)
            {
                // 子メーカーコード、子品番
                goodsCndtn.GoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
                goodsCndtn.GoodsNo = goodsSetWork.SubGoodsNo;
            }
            else
            {
                return status;
            }

            // 初期値データ取得
            //status = goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, sectionCd, out message);
            // 商品情報取得
            // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 >>>>>>START
            //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
            //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
            status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
            // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 <<<<<<END

            return status;
        }

        /// <summary>
        /// 品番検索（Publicメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note		: セット商品の情報を検索します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.08.07</br>
        /// </remarks>
        public int SearchGoodSetData(GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;

            status = GetPartsFromGood(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);

            return status;
        }

        /// <summary>
        /// 品番検索（Privateメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note		: セット商品の情報を検索します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.08.07</br>
        /// </remarks>
        private int GetPartsFromGood(GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            string message;
            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
            //GoodsAcs goodsAcs = new GoodsAcs();
            goodsUnitDataList = new List<GoodsUnitData>();

            // 初期値データ取得
            //status = goodsAcs.SearchInitial(goodsCndtn.EnterpriseCode, sectionCd, out message);
            // 商品情報取得
            //status = goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn,out partsInfoDataSet, out goodsUnitDataList, out message);
            status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out message);
            return status;
        }


        /// <summary>
        /// 商品セットデータクラス → 商品セットデータワーククラス
        /// </summary>
        /// <param name="inGoodsSet">商品セットデータクラス</param>
        /// <param name="inGoodsSetWork">商品セットデータワーククラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セットデータワークでヘッダ情報を設定し、更新可能な商品セットデータにします。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.08.11<br />
        /// </remarks>
        private GoodsSet CopyToGoodsSetOverlap(GoodsSet inGoodsSet, GoodsSetWork inGoodsSetWork)
        {
            GoodsSet goodsSet = new GoodsSet();

            // 商品セットデータワークでヘッダ情報をセット
            goodsSet.CreateDateTime = inGoodsSetWork.CreateDateTime;
            goodsSet.UpdateDateTime = inGoodsSetWork.UpdateDateTime;
            goodsSet.EnterpriseCode = inGoodsSetWork.EnterpriseCode;
            goodsSet.FileHeaderGuid = inGoodsSetWork.FileHeaderGuid;
            goodsSet.UpdEmployeeCode = inGoodsSetWork.UpdEmployeeCode;
            goodsSet.UpdAssemblyId1 = inGoodsSetWork.UpdAssemblyId1;
            goodsSet.UpdAssemblyId2 = inGoodsSetWork.UpdAssemblyId2;

            // 商品セットデータで論理削除区分をセット
            goodsSet.LogicalDeleteCode = inGoodsSet.LogicalDeleteCode;

            // 商品セットデータで更新情報をセット
            goodsSet.ParentGoodsNo = inGoodsSet.ParentGoodsNo;                  // 親品番
            goodsSet.ParentGoodsMakerCd = inGoodsSet.ParentGoodsMakerCd;        // 親メーカーコード
            goodsSet.SubGoodsNo = inGoodsSet.SubGoodsNo;                        // 品番
            goodsSet.SubGoodsMakerCd = inGoodsSet.SubGoodsMakerCd;              // 商品メーカーコード
            goodsSet.CntFl = inGoodsSet.CntFl;                                  // 数量
            goodsSet.DisplayOrder = inGoodsSet.DisplayOrder;                    // 表示順位
            goodsSet.SetSpecialNote = inGoodsSet.SetSpecialNote;                // セット規格・特記事項
            goodsSet.CatalogShapeNo = inGoodsSet.CatalogShapeNo;                // カタログ図番
            
            return goodsSet;
        }

        /// <summary>
        /// 品番検索（Publicメソッド）
        /// </summary>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsKind">商品種別</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note		: セット商品の情報を検索します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.08.12</br>
        /// </remarks>
        public int SearchGoodsUnitData(PartsInfoDataSet partsInfoDataSet, int makerCode, string goodsNo, GoodsAcs.GoodsKind goodsKind, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;

            status = GetGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, goodsKind, out goodsUnitDataList);

            return status;
        }

        /// <summary>
        /// 商品連結データ取得（Privateメソッド）
        /// </summary>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsKind">商品種別</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// <br>Note		: 商品連結データを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.08.12</br>
        /// </remarks>
        private int GetGoodsUnitData(PartsInfoDataSet partsInfoDataSet, int makerCode, string goodsNo, GoodsAcs.GoodsKind goodsKind, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            //string message;
            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
            //GoodsAcs goodsAcs = new GoodsAcs();

            goodsUnitDataList = new List<GoodsUnitData>();

            // 2008.08.21 30413 犬飼 商品連結データをローカルキャッシュで保持 >>>>>>START
            lc_GoodsUnitDataDictionary = new Dictionary<string, GoodsUnitData>();
            // 2008.08.21 30413 犬飼 商品連結データをローカルキャッシュで保持 <<<<<<END
        
            // 初期値データ取得
            //status = goodsAcs.SearchInitial(this._loginEmployee.EnterpriseCode, sectionCd, out message);
            // 商品情報取得
            //goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsKind, out goodsUnitDataList);
            this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, makerCode, goodsNo, goodsKind, out goodsUnitDataList);

            // 商品情報削除分セット情報取得
            this.GetGoodsSetOfDeletedGoodsInfo(makerCode, goodsNo, ref goodsUnitDataList);

            if (goodsUnitDataList != null)
            {
                status = 0;

                // 2009.02.12 30413  キャッシュ処理を削除 >>>>>>START
                //if (goodsKind == GoodsAcs.GoodsKind.ChildSet)
                //{
                //    SetCacheData(goodsUnitDataList);
                //}
                // 2009.02.12 30413  キャッシュ処理を削除 <<<<<<END
            }
            return status;
        }

        /// <summary>
        /// 商品情報削除分セット情報取得処理
        /// </summary>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsUnitDataList"></param>
        private void GetGoodsSetOfDeletedGoodsInfo(int makerCode, string goodsNo, ref List<GoodsUnitData> goodsUnitDataList)
        {
            if ((goodsUnitDataList == null) || (GoodsSetWorkList == null)) return;

            //-----------------------------------------------------------------------------
            // セット情報のキャッシュから対象レコードを取得
            //-----------------------------------------------------------------------------
            List<GoodsSetWork> goodsSetWorkList = GoodsSetWorkList.FindAll(
                delegate(GoodsSetWork goodsSetWork)
                {
                    if ((goodsSetWork.ParentGoodsMakerCd == makerCode) &&
                        (goodsSetWork.ParentGoodsNo == goodsNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // セット情報のキャッシュに存在して、検索結果に存在しない場合、削除分として設定(削除分も表示対象とする為)
            //-----------------------------------------------------------------------------
            foreach (GoodsSetWork goodsSetWork in goodsSetWorkList)
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList.Find(
                    delegate(GoodsUnitData goodsData)
                    {
                        if ((goodsData.GoodsMakerCd == goodsSetWork.SubGoodsMakerCd) &&
                            (goodsData.GoodsNo == goodsSetWork.SubGoodsNo))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (goodsUnitData == null)
                {
                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
                    addGoodsUnitData.GoodsNo = goodsSetWork.SubGoodsNo;
                    //addGoodsUnitData.GoodsName = goodsSetWork.SubGoodsName;
                    //addGoodsUnitData.GoodsMakerCd = goodsSetWork.SubGoodsMakerCd;     // DEL 2009/04/09
                    //addGoodsUnitData.MakerName = goodsSetWork.SubMakerName;
                    // ADD 2009/04/14 --->>>
                    if (goodsSetWork.SubGoodsName != string.Empty)
                    {
                        // セット商品が削除されていない場合は、商品情報を設定
                        addGoodsUnitData.GoodsName = goodsSetWork.SubGoodsName;
                        addGoodsUnitData.GoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
                        addGoodsUnitData.MakerName = goodsSetWork.SubMakerName;
                    }
                    // ADD 2009/04/14 ---<<<
                    addGoodsUnitData.SetDispOrder = goodsSetWork.DisplayOrder;
                    addGoodsUnitData.SetQty = goodsSetWork.CntFl;
                    addGoodsUnitData.SetSpecialNote = goodsSetWork.SetSpecialNote;
                    goodsUnitDataList.Add(addGoodsUnitData);
                }
            }
        }
        #endregion

        /// <summary>
        /// 商品セット物理削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">商品セットデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報物理削除を行います。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.08.20<br />
        /// </remarks>
        public int DeleteUnique(List<GoodsSet> deleteDataList)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                GoodsSetWork goodsSetWork;
                GoodsSetWork[] goodsSetWorkArray = new GoodsSetWork[deleteDataList.Count];

                for (int i = 0; i < deleteDataList.Count; i++)
                {
                    goodsSetWork = new GoodsSetWork();
                    //商品セットワーククラスへのデータ格納処理
                    goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(deleteDataList[i]);

                    goodsSetWorkArray[i] = goodsSetWork;
                }
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(goodsSetWorkArray);
                #endregion

                #region < 物理削除処理 >
                status = this._iGoodsSetDB.Delete(parabyte);
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    // 商品セット情報を元にキャッシュデータを削除する
                    this.RemoveCacheDataUnique(deleteDataList);
                    // 商品セット情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTableUnique(deleteDataList);
                    // 商品セット情報を元に画面表示データテーブル削除
                    this.RemoveDataTableUnique(goodsSetWorkArray[0]);
                    #endregion

                    status = 0;
                }
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
                this._iGoodsSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 商品セットキャッシュデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">商品セットデータクラスリスト</param>
        /// <remarks>
        /// Note       : 商品セット情報のキャッシュデータ１件削除します。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.08.20<br />
        /// </remarks>
        private void RemoveCacheDataUnique(List<GoodsSet> deleteDataList)
        {
            #region ●画面表示用データテーブル削除
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                GoodsSetWork goodsSetWork = new GoodsSetWork();
                //商品セットワーククラスへのデータ格納処理
                goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(deleteDataList[i]);
                // 商品セットコードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
                string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
                string sKeyCode = goodsSetWork.SubGoodsMakerCd.ToString().Trim();
                ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                                PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "' AND " +
                                                                SUBGOODSMAKERCD_TITLE + " = '" + sKeyCode + "' AND " +
                                                                SUBGOODSNO_TITLE + " = '" + goodsSetWork.SubGoodsNo + "'";

                // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 >>>>>>START
                if (ChildGoodsInfoDataTable.DefaultView.Count > 0)
                {
                    //Guid guid = (Guid)ChildGoodsInfoDataTable.DefaultView[i][FILEHEADERGUID_TITLE];
                    string key = (string)ChildGoodsInfoDataTable.DefaultView[i][FILEHEADERGUID_TITLE];

                    if (GoodsSetWorkDictionary != null && GoodsSetWorkList != null)
                    {
                        //if (GoodsSetWorkDictionary.ContainsKey(guid) == true)
                        if (GoodsSetWorkDictionary.ContainsKey(key) == true)
                        {
                            // リスト削除のためのデータワーククラスを保持
                            GoodsSetWork removeData = new GoodsSetWork();
                            //removeData = GoodsSetWorkDictionary[guid];
                            removeData = GoodsSetWorkDictionary[key];

                            // ディクショナリークラスのデータを削除
                            //GoodsSetWorkDictionary.Remove(guid);
                            GoodsSetWorkDictionary.Remove(key);

                            // リストクラスの削除
                            if (GoodsSetWorkList.Contains(removeData) == true)
                            {
                                GoodsSetWorkList.Remove(removeData);
                            }
                        }
                    }
                }
                // 2008.08.20 30413 犬飼 Guidのプライマリーキーを廃止 <<<<<<END
            
            }

            #endregion
        }

        /// <summary>
        /// 子商品情報テーブルデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">商品セットデータクラスリスト</param>
        /// <remarks>
        /// Note       : 子商品情報テーブルのデータを1件削除します。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.08.20<br />
        /// </remarks>
        private void RemoveChildDataTableUnique(List<GoodsSet> deleteDataList)
        {
            #region ●子商品情報データテーブル削除
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                GoodsSetWork goodsSetWork = new GoodsSetWork();
                //商品セットワーククラスへのデータ格納処理
                goodsSetWork = this.CopyToGoodsSetWorkFromGoodsSet(deleteDataList[i]);

                object[] objKeyArray = new object[] {   goodsSetWork.ParentGoodsNo,
                                                        goodsSetWork.ParentGoodsMakerCd.ToString(),
                                                        goodsSetWork.SubGoodsNo,     
                                                        goodsSetWork.SubGoodsMakerCd       };

                if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) != null)
                {
                    // 子商品情報データテーブル削除
                    ChildGoodsInfoDataTable.Rows.Find(objKeyArray).Delete();
                }
            }
            #endregion            
        }

        /// <summary>
        /// 商品セットテーブルデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="goodsSetWork">商品セットワーカークラス</param>
        /// <remarks>
        /// Note       : 商品セット情報テーブルのデータを1件削除します。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.08.20<br />
        /// </remarks>
        private void RemoveDataTableUnique(GoodsSetWork goodsSetWork)
        {
            // 子商品情報にフィルタをかける
            string mKeyCode = goodsSetWork.ParentGoodsMakerCd.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + goodsSetWork.ParentGoodsNo + "'";
            // 子商品情報をソートする
            ChildGoodsInfoDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc, " + DISPLAYORDER_TITLE + " asc";
                                                     
            #region ●画面表示用データテーブル削除

            this.GoodsSetDataTable.BeginLoadData();

            
            object[] objKey = new object[] { goodsSetWork.ParentGoodsNo, goodsSetWork.ParentGoodsMakerCd };
            
            
                // 画面表示用テーブルの削除
                DataRow AddRow = this.GoodsSetDataTable.Rows.Find(objKey);
            
            if (this.ChildGoodsInfoDataTable.DefaultView.Count > 0)
            {
                // データビューが0件より大きい場合、名称を設定
                AddRow[SUBGOODSMAKERCD_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE];
                AddRow[SUBGOODSNO_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE];
                AddRow[SUBGOODSMAKERNM_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERNM_TITLE];
                AddRow[SUBGOODSNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNAME_TITLE];
            }

            #region < 複数の表示 >
            if (this.ChildGoodsInfoDataTable.DefaultView.Count > 1)      // 複数
            {
                AddRow[CHILDPLURALGOODS_TITLE] = "※";
            }
            else
            {
                AddRow[CHILDPLURALGOODS_TITLE] = "";
            }

            this.GoodsSetDataTable.EndLoadData();
            #endregion
            #endregion
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : GoodsSetWorkクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.08.21</br>
        /// </remarks>
        private string CreateHashKey(GoodsSetWork goodsSetWork)
        {
            string strHashKey = goodsSetWork.EnterpriseCode.Trim() + "-"
                              + goodsSetWork.ParentGoodsNo.Trim() + "-" + goodsSetWork.ParentGoodsMakerCd.ToString("d04") + "-"
                              + goodsSetWork.SubGoodsNo.Trim() + "-" + goodsSetWork.SubGoodsMakerCd.ToString("d04");
            return strHashKey;
        }

        /// <summary>
        /// 商品連結データローカルキャッシュ処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データクラス</param>
        /// <remarks>
        /// Note       : 商品連結データをローカルにキャッシュします。<br />
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.08.21</br>
        /// </remarks>
        private void SetCacheData(List<GoodsUnitData> goodsUnitDataList)
        {
            foreach (GoodsUnitData workGoodsUnitData in goodsUnitDataList)
            {
                // ディクショナリークラスに保存
                string key = CreateHashKey(workGoodsUnitData);
                //if (lc_GoodsUnitDataDictionary.ContainsKey(key))
                //{
                //    lc_GoodsUnitDataDictionary.Remove(key);
                //}
                lc_GoodsUnitDataDictionary.Add(key, workGoodsUnitData);
            }
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="goodsUnitData">GoodsUnitDataクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : GoodsUnitDataクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.08.21</br>
        /// </remarks>
        private string CreateHashKey(GoodsUnitData goodsUnitData)
        {
            string strHashKey = goodsUnitData.GoodsNo.Trim() + "-" + goodsUnitData.GoodsMakerCd.ToString("d04");
            return strHashKey;
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="goodsSet">GoodsSetクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note       : GoodsSetクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.08.21</br>
        /// </remarks>
        private string CreateHashKey(GoodsSet goodsSet)
        {
            string strHashKey = goodsSet.SubGoodsNo.Trim() + "-" + goodsSet.SubGoodsMakerCd.ToString("d04");
            return strHashKey;
        }

        /// <summary>
        /// 商品セットデータクラス → 商品連結データクラス
        /// </summary>
        /// <param name="goodsSet">商品セットデータクラス</param>
        /// <param name="goodsUnitDataDic">新規登録分の商品連結データディクショナリー</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品セットデータから商品連結データを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.08.21</br>
        /// </remarks>
        private GoodsUnitData CopyToGoodsUnitDataFromGoodsSet(GoodsSet goodsSet, Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            GoodsUnitData goodsUnitData;

            // 2008.12.17 30413 犬飼 新規検索・更新時の商品連結データを取得する処理を削除 >>>>>>START
            //// 主キーの取得
            //string key = CreateHashKey(goodsSet);

            //if (lc_GoodsUnitDataDictionary.ContainsKey(key))
            //{
            //    // ヘッダ情報を取得するためキャッシュしてあるワーカークラスを取得
            //    goodsUnitData = lc_GoodsUnitDataDictionary[key];
            //}
            //else
            //{
            //    string addDataKey = goodsSet.SubGoodsNo + "-" + goodsSet.SubGoodsMakerCd.ToString("d04");
            //    if (goodsUnitDataDic.ContainsKey(addDataKey))
            //    {
            //        goodsUnitData = goodsUnitDataDic[addDataKey];
            //    }
            //    else
            //    {
            //        // ワーカークラス初期化
            //        //goodsUnitData = new GoodsUnitData();
            //        goodsUnitData = null;
            //    }
            //}
            // 新規登録分の商品連結データディクショナリーを検索
            string addDataKey = goodsSet.SubGoodsNo + "-" + goodsSet.SubGoodsMakerCd.ToString("d04");
            if (goodsUnitDataDic.ContainsKey(addDataKey))
            {
                goodsUnitData = goodsUnitDataDic[addDataKey];
            }
            else
            {
                // ワーカークラス初期化
                goodsUnitData = null;
            }
            // 2008.12.17 30413 犬飼 新規検索・更新時の商品連結データを取得する処理を削除 <<<<<<END
            
            return goodsUnitData;
        }

        /// <summary>
        /// メーカーマスタ情報取得（Publicメソッド）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerUMnt">メーカーマスタ情報</param>
        /// <remarks>
        /// <br>Note		: 指定のメーカーコードのマスタ情報を取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.10.09</br>
        /// </remarks>
        public int GetMaker(string enterpriseCode, int makerCode, out MakerUMnt makerUMnt)
        {
            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // メーカーマスタから情報を取得
            //return this._makerAcs.Read(out makerUMnt, enterpriseCode, makerCode);
            
            //return this._goodsAcs.GetMaker(enterpriseCode, makerCode, out makerUMnt);

            int status = this._makerAcs.Read(out makerUMnt, enterpriseCode, makerCode);
            if ((status == 0) && (makerUMnt.LogicalDeleteCode != 0))
            {
                makerUMnt = null;
            }

            return status;
            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// メーカーガイド表示（Publicメソッド）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerUMnt">メーカーマスタ情報</param>
        /// <remarks>
        /// <br>Note		: セット商品の情報を検索します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.10.09</br>
        /// </remarks>
        public int ExecuteMakerGuid(string enterpriseCode, out MakerUMnt makerUMnt)
        {
            // メーカーガイドを表示
            return this._makerAcs.ExecuteGuid(enterpriseCode, out makerUMnt);
        }

        /// <summary>
        /// 品番検索(結合検索なし)（Publicメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note		: 指定のメーカーコードのマスタ情報を取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.10.10</br>
        /// </remarks>
        public int SearchPartsFromGoodsNoNonVariousSearch(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string message)
        {
            // 品番検索(結合検索なし)
            return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        }

        /// <summary>
        /// 商品情報キャッシュ追加処理（Privateメソッド）
        /// </summary>
        /// <param name="wkGoodsSetWork">セット情報ワーククラス</param>
        /// <remarks>
        /// <br>Note		: 商品情報を取得してローカルキャッシュに追加します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.10.17</br>
        /// </remarks>
        private int AddPartsInfoCacheData(GoodsSetWork wkGoodsSetWork)
        {
            int status = -1;

            PartsInfoDataSet partsInfoDataSet;        // 部品情報データ
            List<GoodsUnitData> goodsUnitDataList;    // 商品連結データリスト

            List<GoodsUnitData> childGoodsUnitDataList;         // セット商品連結データリスト

            string message;

            // 品番検索を行う親商品情報を設定
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = wkGoodsSetWork.EnterpriseCode;
            goodsCndtn.SectionCode = this._loginEmployee.BelongSectionCode.Trim();
            goodsCndtn.MakerName = "";
            goodsCndtn.GoodsNoSrchTyp = 0;
            goodsCndtn.GoodsMakerCd = wkGoodsSetWork.ParentGoodsMakerCd;
            goodsCndtn.GoodsNo = wkGoodsSetWork.ParentGoodsNo;
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

            // 商品情報取得(結合検索有り、完全一致)
            status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out message);

            if (status != 0)
            {
                return status;
            }

            // キャッシュ処理
            for (int i = 0; i < goodsUnitDataList.Count; i++)
            {
                GoodsUnitData parentGoodsUnitData = null;


                foreach (GoodsUnitData workGoodsUnitData in goodsUnitDataList)
                {
                    if ((goodsCndtn.GoodsNo == workGoodsUnitData.GoodsNo) &&
                       (goodsCndtn.GoodsMakerCd == workGoodsUnitData.GoodsMakerCd))
                    {
                        parentGoodsUnitData = workGoodsUnitData.Clone();
                        break;
                    }
                }

                // セット商品情報取得
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildSet, out childGoodsUnitDataList);
                if (childGoodsUnitDataList.Count == 0)
                {
                    continue;
                }

                // 親商品とセット商品をローカルキャッシュに追加
                this.CacheUpdateGoodsSetFromGoodsUnitDataList(parentGoodsUnitData, childGoodsUnitDataList);
            }

            return status;
        }

        /// <summary>
        /// 商品情報キャッシュ処理（Privateメソッド）
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品情報を取得してローカルキャッシュとして保持します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.10.17</br>
        /// </remarks>
        private int SetPartsInfoCacheData()
        {
            int status = -1;

            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            List<PartsInfoDataSet> partsInfoDataSetList;        // 部品情報データリスト
            List<List<GoodsUnitData>> goodsUnitDataListList;    // 商品連結データリストリスト

            List<GoodsUnitData> childGoodsUnitDataList;         // セット商品連結データリスト

            string message;
            
            // 品番検索を行う親商品情報を設定
            foreach (GoodsSetWork wkGoodsSetWork in GoodsSetWorkList)
            {
                GoodsCndtn wkGoodsCndtn = new GoodsCndtn();

                wkGoodsCndtn.EnterpriseCode = wkGoodsSetWork.EnterpriseCode;
                wkGoodsCndtn.SectionCode = this._loginEmployee.BelongSectionCode.Trim();
                wkGoodsCndtn.MakerName = "";
                wkGoodsCndtn.GoodsNoSrchTyp = 0;
                wkGoodsCndtn.GoodsMakerCd = wkGoodsSetWork.ParentGoodsMakerCd;
                wkGoodsCndtn.GoodsNo = wkGoodsSetWork.ParentGoodsNo;
                wkGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

                if (!goodsCndtnList.Contains(wkGoodsCndtn))
                {
                    goodsCndtnList.Add(wkGoodsCndtn);
                }
            }

            // 商品情報取得(結合検索有り、完全一致、一括取得)
            status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtnList, out partsInfoDataSetList, out goodsUnitDataListList, out message);

            if (status != 0)
            {
                return status;
            }

            // キャッシュ処理
            parent_GoodsUnitDataDictionary = new Dictionary<string,GoodsUnitData>();
            childSet_GoodsUnitDataDictionary = new Dictionary<string, List<GoodsUnitData>>();

            for (int i = 0; i < goodsUnitDataListList.Count; i++)
            {
                GoodsCndtn wkGoodsCndtn = goodsCndtnList[i];
                GoodsUnitData parentGoodsUnitData = null;

                foreach (List<GoodsUnitData> workGoodsUnitDataList in goodsUnitDataListList)
                {
                    foreach (GoodsUnitData workGoodsUnitData in workGoodsUnitDataList)
                    {
                        if((wkGoodsCndtn.GoodsNo == workGoodsUnitData.GoodsNo) &&
                           (wkGoodsCndtn.GoodsMakerCd == workGoodsUnitData.GoodsMakerCd))
                        {
                            parentGoodsUnitData = workGoodsUnitData.Clone();
                            break;
                        }
                    }

                    if (parentGoodsUnitData != null)
                    {
                        break;
                    }
                }

                // セット商品情報取得
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSetList[i], wkGoodsCndtn.GoodsMakerCd, wkGoodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildSet, out childGoodsUnitDataList);
                if (childGoodsUnitDataList.Count == 0)
                {
                    continue;
                }

                // 親商品とセット商品をローカルキャッシュに追加
                this.CacheUpdateGoodsSetFromGoodsUnitDataList(parentGoodsUnitData, childGoodsUnitDataList);
            }
            
            return status;
        }

        /// <summary>
        /// 親商品とセット商品をローカルキャッシュ追加処理(Public)
        /// </summary>
        /// <param name="parentGoodsUnitData">親商品連結データクラス</param>
        /// <param name="childGoodsUnitDataList">セット商品連結データクラス</param>
        /// <remarks>
        /// Note       : 親商品とセット商品をローカルキャッシュに追加します。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.10.29<br />
        /// </remarks>
        public void CacheUpdateGoodsSet(GoodsUnitData parentGoodsUnitData, List<GoodsUnitData> childGoodsUnitDataList)
        {
            this.CacheUpdateGoodsSetFromGoodsUnitDataList(parentGoodsUnitData, childGoodsUnitDataList);
        }

        /// <summary>
        /// 親商品とセット商品をローカルキャッシュ追加処理(Private)
        /// </summary>
        /// <param name="parentGoodsUnitData">親商品連結データクラス</param>
        /// <param name="childGoodsUnitDataList">セット商品連結データクラス</param>
        /// <remarks>
        /// Note       : 親商品とセット商品をローカルキャッシュに追加します。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.10.29<br />
        /// </remarks>
        private void CacheUpdateGoodsSetFromGoodsUnitDataList(GoodsUnitData parentGoodsUnitData, List<GoodsUnitData> childGoodsUnitDataList)
        {
            string key = parentGoodsUnitData.GoodsNo + "-" + parentGoodsUnitData.GoodsMakerCd.ToString("d04");

            if (!parent_GoodsUnitDataDictionary.ContainsKey(key))
            {
                parent_GoodsUnitDataDictionary.Add(key, parentGoodsUnitData);
            }
            if (!childSet_GoodsUnitDataDictionary.ContainsKey(key))
            {
                childSet_GoodsUnitDataDictionary.Add(key, childGoodsUnitDataList);
            }
        }

        // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 削除
        ///// <summary>
        ///// 商品セットデータテーブル登録・更新処理
        ///// </summary>
        ///// <remarks>
        ///// Note       : 商品セット情報をデータテーブルに登録します。<br />
        ///// Programmer : 30413 犬飼<br />
        ///// Date       : 2008.10.29<br />
        ///// </remarks>
        //private void AllEditDataTable()
        //{
        //    for (int i = 0; i < GoodsSetWorkList.Count; i++)
        //    {
        //        // 商品セットのローカルキャッシュからデータテーブルを全作成
        //        GoodsSetWork wkGoodsSetWork = GoodsSetWorkList[i];
        //        this.EditDataTable(wkGoodsSetWork);
        //    }
        //}

        ///// <summary>
        ///// 商品セットデータテーブル登録・更新処理
        ///// </summary>
        ///// <param name="workGoodsSetWork">セット情報ワーククラス</param>
        ///// <remarks>
        ///// Note       : 商品セット情報をデータテーブルに登録します。<br />
        ///// Programmer : 30413 犬飼<br />
        ///// Date       : 2008.10.29<br />
        ///// </remarks>
        //private void EditDataTable(GoodsSetWork workGoodsSetWork)
        //{
        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
        //    //string key = workGoodsSetWork.ParentGoodsNo + "-" + workGoodsSetWork.ParentGoodsMakerCd.ToString("d04");
        //    //GoodsUnitData parentGoodsUnitData = new GoodsUnitData();
        //    //List<GoodsUnitData> childGoodsUnitDataList = new List<GoodsUnitData>();

        //    //// 親商品の商品連結データローカルキャッシュを取得
        //    //if (parent_GoodsUnitDataDictionary.ContainsKey(key))
        //    //{
        //    //    parentGoodsUnitData = parent_GoodsUnitDataDictionary[key];
        //    //}

        //    //// セット商品の商品連結データローカルキャッシュを取得
        //    //if (childSet_GoodsUnitDataDictionary.ContainsKey(key))
        //    //{
        //    //    childGoodsUnitDataList = childSet_GoodsUnitDataDictionary[key];
        //    //}
        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<END

        //    #region ●セット商品情報データテーブル作成

        //    ChildGoodsInfoDataTable.BeginLoadData();

        //    // 子商品情報登録データ行
        //    DataRow AddChildRow;

        //    // プライマリキー配列(セット商品情報用)
        //    object[] objKeyArray = new object[] { workGoodsSetWork.ParentGoodsNo, workGoodsSetWork.ParentGoodsMakerCd, workGoodsSetWork.SubGoodsNo, workGoodsSetWork.SubGoodsMakerCd };

        //    // < 新規登録 or 更新 のチェック >
        //    if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) == null)
        //    {
        //        //子商品情報データテーブルに新しい行を追加する
        //        AddChildRow = ChildGoodsInfoDataTable.NewRow();
        //    }
        //    else
        //    {
        //        //既存データテーブルの行を編集する
        //        AddChildRow = ChildGoodsInfoDataTable.Rows.Find(objKeyArray);
        //    }

        //    #region < セットマスタからデータ取得 >
        //    AddChildRow[FILEHEADERGUID_TITLE] = CreateHashKey(workGoodsSetWork);      // 主キー
        //    AddChildRow[PARENTGOODSMAKERCD_TITLE] = workGoodsSetWork.ParentGoodsMakerCd; // 親メーカーコード
        //    AddChildRow[PARENTGOODSNO_TITLE] = workGoodsSetWork.ParentGoodsNo;        // 親品番
        //    AddChildRow[SUBGOODSMAKERCD_TITLE] = workGoodsSetWork.SubGoodsMakerCd;    // セット商品メーカーコード
        //    AddChildRow[SUBGOODSNO_TITLE] = workGoodsSetWork.SubGoodsNo;              // セット商品品番
        //    //AddChildRow[CNTFL_TITLE] = workGoodsSetWork.CntFl;                        // 数量
        //    AddChildRow[CNTFL_TITLE] = workGoodsSetWork.CntFl.ToString("##0.00");                        // 数量
        //    AddChildRow[DISPLAYORDER_TITLE] = workGoodsSetWork.DisplayOrder;          // 表示順位
        //    AddChildRow[SETSPECIALNOTE_TITLE] = workGoodsSetWork.SetSpecialNote;      // セット規格・特記事項
        //    AddChildRow[CATALOGSHAPENO_TITLE] = workGoodsSetWork.CatalogShapeNo;      // カタログ図番
        //    #endregion

        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
        //    #region < セット商品の名称取得 >
        //    //for (int childCnt = 0; childCnt < childGoodsUnitDataList.Count; childCnt++)
        //    //{
        //    //    GoodsUnitData workGoodsUnitData = childGoodsUnitDataList[childCnt];
        //    //    if ((workGoodsSetWork.SubGoodsMakerCd == workGoodsUnitData.GoodsMakerCd) &&
        //    //        (workGoodsSetWork.SubGoodsNo == workGoodsUnitData.GoodsNo))
        //    //    {
        //    //        AddChildRow[SUBGOODSNAME_TITLE] = workGoodsUnitData.GoodsName;      // セット商品品名
        //    //        AddChildRow[SUBGOODSMAKERNM_TITLE] = workGoodsUnitData.MakerName;   // セット商品メーカー名
        //    //        switch (workGoodsUnitData.OfferKubun)
        //    //        {
        //    //            case 0:     // ユーザー登録
        //    //            case 1:     // 提供純正編集
        //    //            case 2:     // 提供優良編集
        //    //                {
        //    //                    // 提供区分がユーザー
        //    //                    AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_USER;
        //    //                    break;
        //    //                }
        //    //            case 3:     // 3:提供純正
        //    //            case 4:     // 4:提供優良
        //    //            case 5:     // 5:TBO
        //    //            case 7:     // 7:オリジナル
        //    //                {
        //    //                    // 提供区分が提供
        //    //                    AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_OFFER;
        //    //                    break;
        //    //                }
        //    //        }
        //    //    }
        //    //}
        //    #endregion

        //    AddChildRow[SUBGOODSNAME_TITLE] = workGoodsSetWork.SubGoodsName;        // セット商品品名
        //    AddChildRow[SUBGOODSMAKERNM_TITLE] = workGoodsSetWork.SubMakerName;     // セット商品メーカー名
        //    AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_USER;                   // 提供区分(ユーザー)
        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<END

        //    // < セット商品を新規に登録する場合 >
        //    if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) == null)
        //    {
        //        // 作成したデータ行の追加
        //        this.ChildGoodsInfoDataTable.Rows.Add(AddChildRow);
        //    }

        //    this.ChildGoodsInfoDataTable.EndLoadData();
        //    #endregion

        //    #region ●画面表示用データテーブル作成

        //    this.GoodsSetDataTable.BeginLoadData();

        //    DataRow AddRow;         // 画面表示用登録データ行

        //    // プライマリキー(表示用)
        //    object[] objKey = new object[] { workGoodsSetWork.ParentGoodsNo, workGoodsSetWork.ParentGoodsMakerCd };

        //    // < 新規登録 or 更新 のチェック >
        //    if (this.GoodsSetDataTable.Rows.Find(objKey) == null)
        //    {
        //        AddRow = this.GoodsSetDataTable.NewRow();
        //    }
        //    else
        //    {
        //        AddRow = this.GoodsSetDataTable.Rows.Find(objKey);
        //    }

        //    #region < セットマスタからデータ取得 >
        //    AddRow[PARENTGOODSMAKERCD_TITLE] = workGoodsSetWork.ParentGoodsMakerCd;     // 親メーカーコード
        //    AddRow[PARENTGOODSNO_TITLE] = workGoodsSetWork.ParentGoodsNo;               // 親品番
        //    AddRow[SUBGOODSMAKERCD_TITLE] = workGoodsSetWork.SubGoodsMakerCd;           // セット商品メーカーコード
        //    AddRow[SUBGOODSNO_TITLE] = workGoodsSetWork.SubGoodsNo;                     // セット商品品番
        //    //AddRow[CNTFL_TITLE] = workGoodsSetWork.CntFl;                               // 数量
        //    AddRow[CNTFL_TITLE] = workGoodsSetWork.CntFl.ToString("##0.00");                               // 数量
        //    AddRow[DISPLAYORDER_TITLE] = workGoodsSetWork.DisplayOrder;                 // 表示順位
        //    AddRow[SETSPECIALNOTE_TITLE] = workGoodsSetWork.SetSpecialNote;             // セット規格・特記事項
        //    AddRow[CATALOGSHAPENO_TITLE] = workGoodsSetWork.CatalogShapeNo;             // カタログ図番
        //    #endregion

        //    #region < 親商品情報キャッシュから名称取得 >
        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
        //    // 親品名、親メーカー名
        //    //AddRow[PARENTGOODSNAME_TITLE] = parentGoodsUnitData.GoodsName;
        //    //AddRow[PARENTGOODSMAKERNM_TITLE] = parentGoodsUnitData.MakerName;
        //    // 2009.01.15 30413 犬飼 親品名に品番を設定しているのを修正 >>>>>>START
        //    //AddRow[PARENTGOODSNAME_TITLE] = workGoodsSetWork.ParentGoodsNo;
        //    AddRow[PARENTGOODSNAME_TITLE] = workGoodsSetWork.ParentGoodsName;
        //    // 2009.01.15 30413 犬飼 親品名に品番を設定しているのを修正 <<<<<<END
        //    AddRow[PARENTGOODSMAKERNM_TITLE] = workGoodsSetWork.ParentMakerName;
        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<END

        //    // セット商品情報キャッシュから画面に表示する子商品情報を取得
        //    string mKeyCode = workGoodsSetWork.ParentGoodsMakerCd.ToString().Trim();
        //    this.ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
        //                                                         PARENTGOODSNO_TITLE + " = '" + workGoodsSetWork.ParentGoodsNo + "'";
        //    if (this.ChildGoodsInfoDataTable.DefaultView.Count > 0)
        //    {
        //        // フィルタ後のビューを表示順位でソート
        //        this.ChildGoodsInfoDataTable.DefaultView.Sort = DISPLAYORDER_TITLE + " asc";

        //        // データビューが0件より大きい場合、名称を設定
        //        AddRow[DISPLAYORDER_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][DISPLAYORDER_TITLE];           // 表示順位
        //        AddRow[SUBGOODSMAKERCD_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE];     // セット商品メーカーコード 
        //        AddRow[SUBGOODSNO_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE];               // セット商品品番
        //        AddRow[SUBGOODSMAKERNM_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERNM_TITLE];     // セット商品メーカー名
        //        AddRow[SUBGOODSNAME_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNAME_TITLE];           // セット商品品名
        //        // 2009.01.15 30413 犬飼 数量とセット規格・特記事項を表示順位の最小の値を設定 >>>>>>START
        //        AddRow[CNTFL_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][CNTFL_TITLE];                         // 数量
        //        AddRow[SETSPECIALNOTE_TITLE] = this.ChildGoodsInfoDataTable.DefaultView[0][SETSPECIALNOTE_TITLE];       // セット規格・特記事項
        //        // 2009.01.15 30413 犬飼 数量とセット規格・特記事項を表示順位の最小の値を設定 <<<<<<END
        //    }
        //    #endregion

        //    #region < 複数の表示 >
        //    if (this.ChildGoodsInfoDataTable.DefaultView.Count > 1)      // 複数
        //    {
        //        AddRow[CHILDPLURALGOODS_TITLE] = "※";
        //    }
        //    else
        //    {
        //        AddRow[CHILDPLURALGOODS_TITLE] = "";
        //    }
        //    #endregion

        //    // < 新規に登録する場合 >
        //    if (this.GoodsSetDataTable.Rows.Find(objKey) == null)
        //    {
        //        // 作成したデータ行の追加
        //        this.GoodsSetDataTable.Rows.Add(AddRow);
        //    }

        //    this.GoodsSetDataTable.EndLoadData();

        //    #endregion

        //}
        #endregion

        /// <summary>
        /// 商品セットデータテーブル登録・更新処理
        /// </summary>
        private void AllEditDataTable()
        {
            this.ChildGoodsInfoDataTable.BeginLoadData();
            this.GoodsSetDataTable.BeginLoadData();

            for (int i = 0; i < GoodsSetWorkList.Count; i++)
            {
                // 商品セットのローカルキャッシュからデータテーブルを全作成
                GoodsSetWork wkGoodsSetWork = GoodsSetWorkList[i];
                this.EditDataTable(wkGoodsSetWork, GoodsSetWorkList);
            }

            this.ChildGoodsInfoDataTable.EndLoadData();
            this.GoodsSetDataTable.EndLoadData();
        }

        /// <summary>
        /// 商品セットデータテーブル登録・更新処理
        /// </summary>
        /// <param name="workGoodsSetWork">追加情報</param>
        /// <param name="goodsSetWorkList">元リスト情報</param>
        private void EditDataTable(GoodsSetWork workGoodsSetWork, List<GoodsSetWork> goodsSetWorkList)
        {
            //-----------------------------------------------------------------------------
            // セット商品情報データテーブル作成
            //-----------------------------------------------------------------------------
            #region ●セット商品情報データテーブル作成
            bool bAdd = false;
            DataRow AddChildRow;

            //-----------------------------------------------------------------------------
            // 配列キー生成
            //-----------------------------------------------------------------------------
            object[] objKeyArray = new object[] { workGoodsSetWork.ParentGoodsNo, workGoodsSetWork.ParentGoodsMakerCd, workGoodsSetWork.SubGoodsNo, workGoodsSetWork.SubGoodsMakerCd };

            //-----------------------------------------------------------------------------
            // テーブル存在チェック
            //-----------------------------------------------------------------------------
            AddChildRow = ChildGoodsInfoDataTable.Rows.Find(objKeyArray);
            if (AddChildRow == null)
            {
                AddChildRow = ChildGoodsInfoDataTable.NewRow();
                bAdd = true;
            }

            //-----------------------------------------------------------------------------
            // データ項目セット
            //-----------------------------------------------------------------------------
            AddChildRow[FILEHEADERGUID_TITLE] = CreateHashKey(workGoodsSetWork);      // 主キー
            AddChildRow[PARENTGOODSMAKERCD_TITLE] = workGoodsSetWork.ParentGoodsMakerCd; // 親メーカーコード
            AddChildRow[PARENTGOODSNO_TITLE] = workGoodsSetWork.ParentGoodsNo;        // 親品番
            AddChildRow[SUBGOODSMAKERCD_TITLE] = workGoodsSetWork.SubGoodsMakerCd;    // セット商品メーカーコード
            AddChildRow[SUBGOODSNO_TITLE] = workGoodsSetWork.SubGoodsNo;              // セット商品品番
            AddChildRow[CNTFL_TITLE] = workGoodsSetWork.CntFl;                        // 数量
            AddChildRow[DISPLAYORDER_TITLE] = workGoodsSetWork.DisplayOrder;          // 表示順位
            AddChildRow[SETSPECIALNOTE_TITLE] = workGoodsSetWork.SetSpecialNote;      // セット規格・特記事項
            AddChildRow[CATALOGSHAPENO_TITLE] = workGoodsSetWork.CatalogShapeNo;      // カタログ図番
            AddChildRow[SUBGOODSNAME_TITLE] = workGoodsSetWork.SubGoodsName;        // セット商品品名
            AddChildRow[SUBGOODSMAKERNM_TITLE] = workGoodsSetWork.SubMakerName;     // セット商品メーカー名
            AddChildRow[DIVISIONNAME_TITLE] = DIVISION_NAME_USER;                   // 提供区分(ユーザー)

            //-----------------------------------------------------------------------------
            // データ追加
            //-----------------------------------------------------------------------------
            if (bAdd) this.ChildGoodsInfoDataTable.Rows.Add(AddChildRow);
            #endregion

            //-----------------------------------------------------------------------------
            // 画面表示用データテーブル作成
            //-----------------------------------------------------------------------------
            #region ●画面表示用データテーブル作成
            bAdd = false;
            DataRow AddRow;

            //-----------------------------------------------------------------------------
            // 配列キー生成
            //-----------------------------------------------------------------------------
            object[] objKey = new object[] { workGoodsSetWork.ParentGoodsNo, workGoodsSetWork.ParentGoodsMakerCd };

            //-----------------------------------------------------------------------------
            // テーブル存在チェック
            //-----------------------------------------------------------------------------
            AddRow = this.GoodsSetDataTable.Rows.Find(objKey);
            if (AddRow == null)
            {
                AddRow = this.GoodsSetDataTable.NewRow();
                bAdd = true;
            }

            //-----------------------------------------------------------------------------
            // データ項目セット(親情報)
            //-----------------------------------------------------------------------------
            AddRow[PARENTGOODSMAKERCD_TITLE] = workGoodsSetWork.ParentGoodsMakerCd;     // 親メーカーコード
            AddRow[PARENTGOODSNO_TITLE] = workGoodsSetWork.ParentGoodsNo;               // 親品番
            AddRow[SUBGOODSMAKERCD_TITLE] = workGoodsSetWork.SubGoodsMakerCd;           // セット商品メーカーコード
            AddRow[SUBGOODSNO_TITLE] = workGoodsSetWork.SubGoodsNo;                     // セット商品品番
            AddRow[CNTFL_TITLE] = workGoodsSetWork.CntFl;                               // 数量
            AddRow[DISPLAYORDER_TITLE] = workGoodsSetWork.DisplayOrder;                 // 表示順位
            AddRow[SETSPECIALNOTE_TITLE] = workGoodsSetWork.SetSpecialNote;             // セット規格・特記事項
            AddRow[CATALOGSHAPENO_TITLE] = workGoodsSetWork.CatalogShapeNo;             // カタログ図番
            // 2009.03.27 30413 犬飼 親商品品名が空白の場合、メーカー名も空白 >>>>>>START
            AddRow[PARENTGOODSNAME_TITLE] = workGoodsSetWork.ParentGoodsName;
            AddRow[PARENTGOODSMAKERNM_TITLE] = workGoodsSetWork.ParentMakerName;
            if (string.IsNullOrEmpty(workGoodsSetWork.ParentGoodsName))
            {
                AddRow[PARENTGOODSNAME_TITLE] = string.Empty;
                AddRow[PARENTGOODSMAKERNM_TITLE] = string.Empty;
            }
            else
            {
                AddRow[PARENTGOODSNAME_TITLE] = workGoodsSetWork.ParentGoodsName;
                AddRow[PARENTGOODSMAKERNM_TITLE] = workGoodsSetWork.ParentMakerName;
            }
            // 2009.03.27 30413 犬飼 親商品品名が空白の場合、メーカー名も空白 <<<<<<END
            
            //-----------------------------------------------------------------------------
            // 親情報に該当する子情報を全て取得
            //-----------------------------------------------------------------------------
            List<GoodsSetWork> retGoodsSetWorkList = GoodsSetWorkList.FindAll(
                delegate(GoodsSetWork goodsSetWork)
                {
                    if ((goodsSetWork.ParentGoodsMakerCd == workGoodsSetWork.ParentGoodsMakerCd) &&
                        (goodsSetWork.ParentGoodsNo == workGoodsSetWork.ParentGoodsNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // データ項目セット(子情報)
            //-----------------------------------------------------------------------------
            retGoodsSetWorkList.Sort(new GoodsSetComparer());
            if (retGoodsSetWorkList.Count > 0)
            {
                AddRow[DISPLAYORDER_TITLE] = retGoodsSetWorkList[0].DisplayOrder;           // 表示順位
                AddRow[SUBGOODSMAKERCD_TITLE] = retGoodsSetWorkList[0].SubGoodsMakerCd;     // セット商品メーカーコード 
                AddRow[SUBGOODSNO_TITLE] = retGoodsSetWorkList[0].SubGoodsNo;               // セット商品品番
                // 2009.02.18 30413 犬飼 セット商品品名が空白の場合、メーカー名も空白 >>>>>>START
                //AddRow[SUBGOODSMAKERNM_TITLE] = retGoodsSetWorkList[0].SubMakerName;        // セット商品メーカー名
                //AddRow[SUBGOODSNAME_TITLE] = retGoodsSetWorkList[0].SubGoodsName;           // セット商品品名
                if (string.IsNullOrEmpty(retGoodsSetWorkList[0].SubGoodsName))
                {
                    AddRow[SUBGOODSMAKERNM_TITLE] = string.Empty;
                    AddRow[SUBGOODSNAME_TITLE] = string.Empty;
                    AddRow[SUBGOODSMAKERCD_TITLE] = 0;      // ADD 2009/04/09
                }
                else
                {
                    AddRow[SUBGOODSMAKERNM_TITLE] = retGoodsSetWorkList[0].SubMakerName;        // セット商品メーカー名
                    AddRow[SUBGOODSNAME_TITLE] = retGoodsSetWorkList[0].SubGoodsName;           // セット商品品名
                }
                // 2009.02.18 30413 犬飼 セット商品品名が空白の場合、メーカー名も空白 <<<<<<END
                AddRow[CNTFL_TITLE] = retGoodsSetWorkList[0].CntFl;                         // 数量
                AddRow[SETSPECIALNOTE_TITLE] = retGoodsSetWorkList[0].SetSpecialNote;       // セット規格・特記事項
            }
            AddRow[CHILDPLURALGOODS_TITLE] = (retGoodsSetWorkList.Count > 1) ? "※" : "";   // 複数

            //-----------------------------------------------------------------------------
            // データ追加
            //-----------------------------------------------------------------------------
            if (bAdd) this.GoodsSetDataTable.Rows.Add(AddRow);
            #endregion
        }

        /// <summary>
        /// 商品セット情報比較クラス(表示順位(昇順))
        /// </summary>
        private class GoodsSetComparer : Comparer<GoodsSetWork>
        {
            public override int Compare(GoodsSetWork x, GoodsSetWork y)
            {
                int result = x.DisplayOrder.CompareTo(y.DisplayOrder);
                return result;
            }
        }
        // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 商品連結データの提供区分チェック処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <remarks>
        /// Note       : 商品連結データがセットマスタ情報に登録されているかチェックします。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.10.29<br />
        /// </remarks>
        public bool CheckDivision(GoodsUnitData goodsUnitData)
        {
            foreach (GoodsSetWork wkGoodsSetWork in GoodsSetWorkList)
            {
                if ((goodsUnitData.GoodsNo == wkGoodsSetWork.SubGoodsNo) &&
                   (goodsUnitData.GoodsMakerCd == wkGoodsSetWork.SubGoodsMakerCd))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 登録済みセット情報チェック
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <remarks>
        /// Note       : セットマスタに登録済みのデータかチェックを行う。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.10.30<br />
        /// </remarks>
        public bool CheckModeChange(GoodsUnitData goodsUnitData)
        {
            foreach (GoodsSetWork wkGoodsSetWork in GoodsSetWorkList)
            {
                if ((wkGoodsSetWork.ParentGoodsNo == goodsUnitData.GoodsNo) &&
                    (wkGoodsSetWork.ParentGoodsMakerCd == goodsUnitData.GoodsMakerCd))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 商品セット読み込み処理(論理削除含まない)
        /// </summary>
        /// <param name="retList">抽出結果リスト</param>
        /// <param name="goodsSet">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 商品セット情報を読み込みます。<br />
        /// Programmer : 30413 犬飼<br />
        /// Date       : 2008.11.07<br />
        /// </remarks>
        private int SearchGoodsSet(out ArrayList retList, GoodsSet goodsSet)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();

            retList = new ArrayList();

            GoodsSetWork goodsSetWork = new GoodsSetWork();

            // 親品番と親メーカーコードを抽出条件とする
            goodsSetWork.EnterpriseCode = goodsSet.EnterpriseCode;
            goodsSetWork.ParentGoodsNo = goodsSet.ParentGoodsNo;
            goodsSetWork.ParentGoodsMakerCd = goodsSet.ParentGoodsMakerCd;

            object paraobj = goodsSetWork;
            object retobj = paraList;

            status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    retList = retobj as ArrayList;
                    break;

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;

                default:
                    return status;
            }

            return status;
        }
        // --- ADD m.suzuki 2010/08/04 ---------->>>>>
        /// <summary>
        /// １件読み込み処理
        /// </summary>
        /// <param name="readCndtn"></param>
        /// <returns></returns>
        public int Read( GoodsSet readCndtn )
        {
            int status = -1;

            try
            {
                if ( GoodsSetWorkDictionary == null )
                {
                    GoodsSetWorkDictionary = new Dictionary<string, GoodsSetWork>();
                }
                if ( GoodsSetWorkList == null )
                {
                    GoodsSetWorkList = new List<GoodsSetWork>();
                }

                // [[結合情報取得]]:結合マスタ(ユーザ)検索
                ArrayList retList;
                status = SearchGoodsSet( out retList, readCndtn );

                #region < 検索後処理 >
                if ( status == 0 )
                {
                    foreach ( object retobj in retList )
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData( (GoodsSetWork)retobj );
                    }

                    // キャッシュからデータテーブルを全作成
                    this.AllEditDataTable();

                    // データのソート
                    this.GoodsSetDataTable.DefaultView.Sort = PARENTGOODSNO_TITLE + " asc, " + PARENTGOODSMAKERCD_TITLE + " asc";
                }
                #endregion
            }
            catch ( Exception )
            {
                return -1;
            }

            return status;
        }
        // --- ADD m.suzuki 2010/08/04 ----------<<<<<
    }
}

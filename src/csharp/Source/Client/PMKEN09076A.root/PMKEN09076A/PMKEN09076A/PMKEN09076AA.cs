//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 結合マスタ
// プログラム概要   : 結合マスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/07/28  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2008/10/15  修正内容 : 検索見積用のメソッド追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/02/12  修正内容 : 速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/14  修正内容 : Mantis【10815】論理削除時の結合商品の商品情報取得を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/20  修正内容 : Mantis【10815】論理削除時の価格情報と倉庫情報の取得を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/01/05  修正内容 : Mantis【14854】
//                                : マスタ削除直後新規で削除した親品番を入力しても子品番が表示される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/14  修正内容 : Mantis【15808】
//                                : 提供で結合済みの純正品版にユーザー追加した場合、削除しようとするとエラーとなる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/08/03  修正内容 : 起動速度アップ対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 結合マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : PM.NS用に変更 </br>
    /// <br>Programmer      : 30415 柴田 倫幸</br>
    /// <br>Date            : 2008/07/28</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 検索見積用のメソッド追加</br>
    /// <br>Programmer      : 21024 佐々木 健</br>
    /// <br>Date            : 2008/10/15</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 速度アップ対応</br>
    /// <br>Programmer      : 30413 犬飼</br>
    /// <br>Date            : 2009/02.12</br>
    /// <br>--------------------------------------------------------------------</br>
    /// <br>UpdateNote      : 起動速度アップ対応</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2010/08/03</br>
    /// <br>--------------------------------------------------------------------</br>
    /// </remarks>
    public class JoinPartsUAcs
    {
        #region ◆Public Members

        /// <summary>画面表示データテーブル格納データ結合クラス</summary>
        public readonly DataSet JoinPartsUDataSet;          // ADD 2008/10/17 不具合対応[6559] readonly
        /// <summary>全データ格納データ結合クラス</summary>
        public readonly DataSet ChildGoodsInfoDataSet;      // ADD 2008/10/17 不具合対応[6559] readonly

        #region ●DataTable用名称情報
        /// <summary>データテーブルカラム名称(GUID)</summary>
        public const string FILEHEADERGUID_TITLE = "Guid";                      // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(削除日)</summary>
        public const string DELETE_DATE = "削除日";                             // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(論理削除区分)</summary>
        public const string LOGICALDELETE_TITLE = "論理削除区分";               // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(複数)</summary>
        public const string CHILDPLURALGOODS_TITLE = "複数";                    // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合元品番)</summary>
        public const string PARENTGOODSNO_TITLE = "結合元品番";                 // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合元商品名称)</summary>
        public const string PARENTGOODSNAME_TITLE = "結合元品名";           // MOD 2008/10/17 不具合対応[6556] "結合元商品名称"→"結合元品名", static readonly → const
        /// <summary>データテーブルカラム名称(結合元メーカーコード)</summary>
        public const string PARENTGOODSMAKERCD_TITLE = "結合元メーカーコード";  // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合元メーカー名称)</summary>
        public const string PARENTGOODSMAKERNM_TITLE = "結合元メーカー名";  // MOD 2008/10/17 不具合対応[6556] "結合元メーカー名称"→"結合元メーカー名", static readonly → const
        /// <summary>データテーブルカラム名称(結合先品番)</summary>
        public const string SUBGOODSNO_TITLE = "結合先品番";                    // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合先商品名称)</summary>
        public const string SUBGOODSNAME_TITLE = "結合先品名";              // MOD 2008/10/17 不具合対応[6556] "結合先商品名称"→"結合先品名", static readonly → const
        /// <summary>データテーブルカラム名称(結合先メーカーコード)</summary>
        public const string SUBGOODSMAKERCD_TITLE = "結合先メーカーコード";     // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合先メーカー名称)</summary>
        public const string SUBGOODSMAKERNM_TITLE = "結合先メーカー名";     // MOD 2008/10/17 不具合対応[6556] "結合先メーカー名称"→"結合先メーカー名", static readonly → const
        /// <summary>データテーブルカラム名称(QTY)</summary>
        public const string QTY_TITLE = "QTY";                                  // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(結合規格・特記事項)</summary>
        public const string SETSPECIALNOTE_TITLE = "結合規格・特記事項";        // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(提供日付)</summary>
        public const string OFFERDATE_TITLE = "提供日付";                       // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(標準価格)</summary>
        public const string PRICE_TITLE = "標準価格";                           // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(原単価)</summary>
        public const string COST_TITLE = "原単価";                              // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(倉庫コード)</summary>
        public const string STORECODE_TITLE = "倉庫コード";                     // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(倉庫)</summary>
        public const string STORE_TITLE = "倉庫";                               // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(棚番)</summary>
        public const string SHELFNO_TITLE = "棚番";                             // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(現在庫)</summary>
        public const string STOCK_TITLE = "現在庫";                             // MOD 2008/10/17 不具合対応[6559] static readonly → const

        ///// <summary>データテーブルカラム名称(数量)</summary>
        //public const string CNTFL_TITLE = "数量";
        /// <summary>データテーブルカラム名称(表示順位)</summary>
        public const string DISPLAYORDER_TITLE = "表示順位";                    // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(提供区分)</summary>
        public const string OFFERKUBUN_TITLE = "提供区分";                      // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>データテーブルカラム名称(編集フラグ)</summary>
        public const string EDITFLG_TITLE = "編集フラグ";                       // MOD 2008/10/17 不具合対応[6559] static readonly → const

        /// <summary>データテーブル名称</summary>
        public const string JOINPARTSU_TABLE = "JoinPartsU_Table";              // MOD 2008/10/17 不具合対応[6559] static readonly → const
        /// <summary>全データ格納テーブル名称</summary>
        public const string CHILDGOODSINFO_TABLE = "ChildGoodsInfo_Table";      // MOD 2008/10/17 不具合対応[6559] static readonly → const

        #endregion

        /// <summary>在庫データ保持用</summary>
        public struct F_DATA_STORE
        {
            /// <summary>結合先メーカーコード</summary>
            public int joinDestMakerCd;
            /// <summary>結合先品番</summary>
            public string joinDestPartsNo;
            /// <summary>倉庫名称</summary>
            public string store;
            /// <summary>棚番</summary>
            public string shelfNo;
            /// <summary>現在庫</summary>
            public double stock;
            /// <summary>倉庫コード</summary>
            public string storeCode;
        }

        /// <summary>商品連結データ保持用</summary>
        public struct F_DATA_GOODSUNIT
        {
            /// <summary>結合先メーカーコード</summary>
            public int joinDestMakerCd;
            /// <summary>結合先品番</summary>
            public string joinDestPartsNo;
        }

        /// <summary>キャッシュ保持用KEY</summary>
        public struct F_DATA_DICKEY
        {
            /// <summary>結合元メーカーコード</summary>
            public int joinSourceMakerCd;
            /// <summary>結合元品番</summary>
            public string joinSourcePartsNo;
            /// <summary>結合先メーカーコード</summary>
            public int joinDestMakerCd;
            /// <summary>結合先品番</summary>
            public string joinDestPartsNo;
        }

        // 2008.10.15 Add >>>
        /// <summary>結合元データKEY</summary>
        public struct F_DATA_JOINSOURCEKEY
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="joinSourcePartsNo"></param>
            /// <param name="joinSourceMakerCd"></param>
            public F_DATA_JOINSOURCEKEY(string joinSourcePartsNo, int joinSourceMakerCd)
            {
                JoinSourcePartsNo = joinSourcePartsNo;
                JoinSourceMakerCd = joinSourceMakerCd;
            }

            /// <summary>結合元メーカーコード</summary>
            public int JoinSourceMakerCd;
            /// <summary>結合元品番</summary>
            public string JoinSourcePartsNo;
        }
        // 2008.10.15 Add <<<

        // ADD 2008/10/17 不具合対応[6559]---------->>>>>
        /// <summary>
        /// ログインユーザーを取得します。
        /// </summary>
        /// <value>ログインユーザー</value>
        public Employee LoginWorker
        {
            get { return _loginWorker; }
        }

        /// <summary>
        /// 自拠点コードを取得します。
        /// </summary>
        /// <value>自拠点コード</value>
        public string OwnSectionCode
        {
            get { return _ownSectionCode; }
        }

        // ADD 2008/10/17 不具合対応[6559]----------<<<<<

        #endregion

        #region ◆Private Members

        #region ●Static Members
        private static Dictionary<F_DATA_DICKEY, JoinPartsUWork> JoinPartsUWorkDictionary;  // MEMO:結合情報のキャッシュ
        private static List<JoinPartsUWork> JoinPartsUWorkList;                             // MEMO:結合情報のキャッシュ

        #endregion
       
        #region ●Const
        /// <summary>削除日表示形式</summary>
        private const string DATATIME_FORM = "ggYY/MM/DD";
        #endregion

        #region ●Normal Members
        // --- ADD 2008/07/28 -------------------------------->>>>>
        /// <summary>結合リモートオブジェクト格納バッファ</summary>
        private IJoinPartsUDB _iJoinPartsUDB;
        // --- ADD 2008/07/28 --------------------------------<<<<< 

        /// <summary>商品マスタアクセス</summary>
        private readonly GoodsAcs _goodsAcs;                // ADD 2008/10/17 不具合対応[6559] readonly

        /// <summary>画面表示データテーブルクラス</summary>
        private readonly DataTable JoinPartsUDataTable;     // ADD 2008/10/17 不具合対応[6559] readonly
        /// <summary>結合先情報データ保持データテーブルクラス</summary>
        private readonly DataTable ChildGoodsInfoDataTable; // ADD 2008/10/17 不具合対応[6559] readonly

        // --- ADD 2008/07/28 -------------------------------->>>>>
        /// <summary>ログインユーザー</summary>
        private readonly Employee _loginWorker;             // ADD 2008/10/17 不具合対応[6559] readonly

        /// <summary>自拠点コード</summary>
        private readonly string _ownSectionCode;            // ADD 2008/10/17 不具合対応[6559] readonly
        // --- ADD 2008/07/28 --------------------------------<<<<< 

        #endregion

        #endregion

        #region ◆Constructor 
        
        /// <summary>
        /// 結合アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// </remarks>
        public JoinPartsUAcs()
        {
            try
            {
                // 結合マスタリモートオブジェクト取得
                this._iJoinPartsUDB = (IJoinPartsUDB)MediationJoinPartsUDB.GetJoinPartsUDB();
                
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                    this._ownSectionCode = this._loginWorker.BelongSectionCode;
                }

                // 商品アクセスクラスのインスタンス化
                this._goodsAcs = new GoodsAcs();                
                string strMsg;
                this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode, out strMsg);
            }
            catch (Exception)
            {
                this._iJoinPartsUDB = null;
            }

            #region ●画面表示用DataTable列設定
            // 画面表示テーブルのカラム設定
            JoinPartsUDataTable = new DataTable(JOINPARTSU_TABLE);
            JoinPartsUDataTable.Columns.Add(DELETE_DATE, typeof(string));               // 削除日
            JoinPartsUDataTable.Columns.Add(LOGICALDELETE_TITLE, typeof(int));          // 論理削除区分
            JoinPartsUDataTable.Columns.Add(CHILDPLURALGOODS_TITLE, typeof(string));    // 複数
            JoinPartsUDataTable.Columns.Add(PARENTGOODSNO_TITLE, typeof(string));       // 結合元品番
            JoinPartsUDataTable.Columns.Add(PARENTGOODSNAME_TITLE, typeof(string));     // 結合元商品名称
            JoinPartsUDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));     // 結合元メーカーコード
            JoinPartsUDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));  // 結合元メーカー名称
            JoinPartsUDataTable.Columns.Add(SUBGOODSNO_TITLE, typeof(string));          // 結合先品番
            JoinPartsUDataTable.Columns.Add(SUBGOODSNAME_TITLE, typeof(string));        // 結合先商品名称
            JoinPartsUDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE, typeof(int));        // 結合先メーカーコード
            JoinPartsUDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE, typeof(string));     // 結合先メーカー名称
            JoinPartsUDataTable.Columns.Add(QTY_TITLE, typeof(double));                 // QTY
            JoinPartsUDataTable.Columns.Add(SETSPECIALNOTE_TITLE, typeof(string));      // 結合規格・特記事項
            //GoodsSetDataTable.Columns.Add(OFFERDATE_TITLE, typeof(string));           // 提供日付
            JoinPartsUDataTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));           // 表示順位

            // プライマリーキーの設定
            // 2007.09.26 hikita upd start ----------------------------------------------------------------------->>
            JoinPartsUDataTable.PrimaryKey = new DataColumn[] { JoinPartsUDataTable.Columns[PARENTGOODSNO_TITLE],
                                                              JoinPartsUDataTable.Columns[PARENTGOODSMAKERCD_TITLE]
                                                            };
            // 2007.09.26 hikita upd end -------------------------------------------------------------------------<<

            //画面表示テーブルをデータセットへ格納
            this.JoinPartsUDataSet = new DataSet();
            JoinPartsUDataSet.Tables.Add(JoinPartsUDataTable);

            #endregion

            #region ●結合先商品情報格納テーブル用DataTable列設定

            ChildGoodsInfoDataTable = new DataTable(CHILDGOODSINFO_TABLE);
            ChildGoodsInfoDataTable.Columns.Add(FILEHEADERGUID_TITLE, typeof(Guid));         // GUID
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERCD_TITLE, typeof(int));      // 親メーカーコード
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSMAKERNM_TITLE, typeof(string));   // 親メーカー名称
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNO_TITLE, typeof(string));        // 親商品番号
            ChildGoodsInfoDataTable.Columns.Add(PARENTGOODSNAME_TITLE, typeof(string));      // 親商品名称
            ChildGoodsInfoDataTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));            // 表示順位
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERCD_TITLE, typeof(int));         // メーカーコード
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSMAKERNM_TITLE, typeof(string));      // メーカー名称
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNO_TITLE, typeof(string));           // 商品番号
            ChildGoodsInfoDataTable.Columns.Add(SUBGOODSNAME_TITLE, typeof(string));         // 商品名称
            ChildGoodsInfoDataTable.Columns.Add(SETSPECIALNOTE_TITLE, typeof(string));       // セット・規格特記事項
            ChildGoodsInfoDataTable.Columns.Add(QTY_TITLE, typeof(double));                  // QTY
            ChildGoodsInfoDataTable.Columns.Add(OFFERDATE_TITLE, typeof(string));            // 提供日付
            ChildGoodsInfoDataTable.Columns.Add(PRICE_TITLE, typeof(double));                // MOD 標準価格 2008/10/21 不具合対応[6566] string→int
            ChildGoodsInfoDataTable.Columns.Add(COST_TITLE, typeof(double));                 // MOD 原単価 2008/10/21 不具合対応[6566] string→int
            ChildGoodsInfoDataTable.Columns.Add(STORECODE_TITLE, typeof(string));            // 倉庫コード
            ChildGoodsInfoDataTable.Columns.Add(STORE_TITLE, typeof(string));                // 倉庫
            ChildGoodsInfoDataTable.Columns.Add(SHELFNO_TITLE, typeof(string));              // 棚番
            ChildGoodsInfoDataTable.Columns.Add(STOCK_TITLE, typeof(double));                // MOD 現在庫 2008/10/21 不具合対応[6566] string→int
            ChildGoodsInfoDataTable.Columns.Add(OFFERKUBUN_TITLE, typeof(string));           // 提供区分
            ChildGoodsInfoDataTable.Columns.Add(EDITFLG_TITLE, typeof(string));              // 編集フラグ

            // プライマリーキーの設定
            ChildGoodsInfoDataTable.PrimaryKey = new DataColumn[] { ChildGoodsInfoDataTable.Columns[PARENTGOODSNO_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[PARENTGOODSMAKERCD_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[SUBGOODSNO_TITLE],
                                                                    ChildGoodsInfoDataTable.Columns[SUBGOODSMAKERCD_TITLE] };
            
            // 全データ格納テーブルをデータセットへ格納
            this.ChildGoodsInfoDataSet = new DataSet();
            ChildGoodsInfoDataSet.Tables.Add(ChildGoodsInfoDataTable);

            #endregion
        }

        #endregion

        #region ◆Public Methods

        // 2008.10.15 Add >>>
        /// <summary>
        /// 結合マスタ検索処理
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="joinSourcePartsList">結合元部品リスト</param>
        /// <param name="joinPartsDictionary">結合部品データディクショナリ（ユーザー結合マスタは表示順位でソートされます）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : 結合元部品を複数指定して結合マスタを読み込みます。<br />
        /// Programmer : 21024　佐々木 健<br />
        /// Date       : 2008.10.15<br />
        /// </remarks>
        public int Search(string enterPriseCode, List<F_DATA_JOINSOURCEKEY> joinSourcePartsList, out Dictionary<F_DATA_JOINSOURCEKEY, List<JoinPartsU>> joinPartsDictionary)
        {
            int status = -1;
            ArrayList retList;
            joinPartsDictionary = new Dictionary<F_DATA_JOINSOURCEKEY, List<JoinPartsU>>();
            try
            {
                foreach (F_DATA_JOINSOURCEKEY joinSourceKey in joinSourcePartsList)
                {
                    status = this.SearchProc(out retList, enterPriseCode, joinSourceKey.JoinSourceMakerCd, joinSourceKey.JoinSourcePartsNo, ConstantManagement.LogicalMode.GetDataAll);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        List<JoinPartsU> joinPartsUList = new List<JoinPartsU>();
                        foreach (JoinPartsUWork joinPartsUWork in retList)
                        {
                            joinPartsUList.Add(this.CopyToJoinPartsUFromJoinPartsUWork(joinPartsUWork));
                        }
                        joinPartsUList.Sort(new JoinPartsUComparer());
                        joinPartsDictionary.Add(joinSourceKey,joinPartsUList);
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return status;
        }
        // 2008.10.15 Add <<<

        /// <summary>
        /// 結合全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// /// <param name="retTotalCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        public int SearchAll(string enterpriseCode, ref int retTotalCnt)
        {
            int status = -1;

            try
            {   
                // [[結合情報取得]]:結合マスタ(ユーザ)検索
                bool nextData;
                ArrayList retList;
                status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                    ConstantManagement.LogicalMode.GetDataAll, 0, null);

                #region < 検索後処理 >
                if (status == 0)
                {
                    foreach (object retobj in retList)
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData((JoinPartsUWork)retobj);
                    }
                    
                    // キャッシュからデータテーブルを全作成
                    this.AllEditDataTable();

                    // データのソート
                    this.JoinPartsUDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";
                }
            }
            catch (Exception)
            {
                return -1;
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 結合物理削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">結合データクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        public int DeleteUnique(List<JoinPartsU> deleteDataList)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                JoinPartsUWork joinPartsUWork;
                JoinPartsUWork[] joinPartsUWorkArray = new JoinPartsUWork[deleteDataList.Count];
                ArrayList delList = new ArrayList();// 2010/07/14 Add

                for (int i = 0; i < deleteDataList.Count; i++)
                {
                    joinPartsUWork = new JoinPartsUWork();
                    //結合ワーククラスへのデータ格納処理
                    joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU(deleteDataList[i]);
                    joinPartsUWorkArray[i] = joinPartsUWork;
                    delList.Add(joinPartsUWork);// 2010/07/14 Add
                }
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(joinPartsUWorkArray);
                #endregion

                #region < 物理削除処理 >
                // 2010/07/14 >>>
                //status = this._iJoinPartsUDB.Delete(parabyte);
                status = this._iJoinPartsUDB.Delete((object)delList);
                // 2010/07/14 <<<
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    // 結合情報を元にキャッシュデータを削除する
                    this.RemoveCacheDataUnique(deleteDataList);
                    // 結合情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTableUnique(deleteDataList);
                    // 結合情報を元に画面表示データテーブル削除
                    this.RemoveDataTableUnique(joinPartsUWorkArray[0]);
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
                this._iJoinPartsUDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 結合登録・更新処理
        /// </summary>
        /// <param name="writeDataList">結合データクラスリスト</param>
        /// <param name="goodsUnitDataDic">商品連結データディクショナリー</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        public int Write(List<JoinPartsU> writeDataList, Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            int status = -1;

            try
            {
                #region < 登録データ準備処理 >
                JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                object paraObj = new object();
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                ArrayList paraList = new ArrayList();
                ArrayList unitDataList = new ArrayList();
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                string msg = "";

                // 結合設定オブジェクトの追加
                for (int i = 0; i < writeDataList.Count; i++)
                {
                    // 結合情報を取得
                    joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU(writeDataList[i]);
                    JoinPartsU wkJoinPartsU = this.CopyToJoinPartsUOverlap((JoinPartsU)writeDataList[i], joinPartsUWork);
                    paraList.Add(wkJoinPartsU);

                    // 商品連結データを取得
                    goodsUnitData = CopyToGoodsUnitDataFromJoinPartsU(writeDataList[i], goodsUnitDataDic);
                    if (goodsUnitData != null)
                    {
                        // 商品連結データがnull以外
                        unitDataList.Add(goodsUnitData);
                    }
                }
                // 商品連結データリストと結合情報リストを書込対象
                if (unitDataList.Count != 0)
                {
                    // 商品連結データリストが0件以外
                    csList.Add(unitDataList);
                }
                csList.Add(paraList);
                paraObj = csList;
                #endregion
                
                #region < 登録処理 >
                // 商品マスタクラスを経由して結合設定の書き込み
                status = this._goodsAcs.WriteRelation(ref paraObj, out msg);
                #endregion

                #region < 登録後処理 >
                if (status == 0)
                {
                    #region < 登録データ反映処理 >
                    ArrayList retList = (ArrayList)((CustomSerializeArrayList)paraObj)[0];

                    joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU((JoinPartsU)retList[0]);

                    // 結合情報を元にキャッシュデータを削除する
                    this.RemoveCacheData(joinPartsUWork);
                    // 結合情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTable(joinPartsUWork);

                    ArrayList outList;
                    // 親品番と親メーカーコードで取得
                    status = SearchJoinPartsU(out outList, (JoinPartsU)retList[0]);
                    if (status == 0)
                    {
                        this.ChildGoodsInfoDataTable.BeginLoadData();
                        this.JoinPartsUDataTable.BeginLoadData();
                        
                        foreach (object retobj in outList)
                        {
                            // 結合マスタ情報をローカルにキャッシュ
                            this.SetCacheData((JoinPartsUWork)retobj);
                            // データテーブルの反映
                            this.EditDataTable((JoinPartsUWork)retobj);
                        }

                        this.ChildGoodsInfoDataTable.EndLoadData();
                        this.JoinPartsUDataTable.EndLoadData();
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
                this._iJoinPartsUDB = null;
                //通信エラーは-1を戻す
                status = -1;
                return status;
            }
        }

        // 2008.10.15 Add >>>
        /// <summary>
        /// 結合マスタ・商品マスタ登録処理
        /// </summary>
        /// <param name="joinPartsUList">ユーザー結合マスタリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int Write(List<JoinPartsU> joinPartsUList, ref List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            int status = -1;
            msg = string.Empty;

            try
            {
                ArrayList writeGoodsUnitDataList = new ArrayList();
                ArrayList writeJoinPartsUList = new ArrayList();
                writeGoodsUnitDataList.AddRange(goodsUnitDataList);
                writeJoinPartsUList.AddRange(joinPartsUList);

                CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

                customSerializeArrayList.Add(writeJoinPartsUList);
                customSerializeArrayList.Add(writeGoodsUnitDataList);

                object retObject = customSerializeArrayList;

                // 登録
                status = this._goodsAcs.WriteRelation(ref retObject, out msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList retList = (CustomSerializeArrayList)retObject;

                    foreach (ArrayList al in retList)
                    {
                        if (al[0] is GoodsUnitData)
                        {
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])al.ToArray(typeof(GoodsUnitData)));
                        }
                    }
                }

                return status;
            }
            catch (Exception)
            {
                status = -1;

                return status;
            }
        }
        // 2008.10.15 Add <<<

        /// <summary>
        /// 結合物理削除処理
        /// </summary>
        /// <param name="deleteDataList">結合データクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        public int Delete(List<JoinPartsU> deleteDataList)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                JoinPartsUWork joinPartsUWork;
                JoinPartsUWork[] joinPartsUWorkArray = new JoinPartsUWork[deleteDataList.Count];
                ArrayList delList = new ArrayList();
                // 2010/07/14 Add >>>
                Dictionary<F_DATA_DICKEY, JoinPartsUWork> tempDeleteDataList=new Dictionary<F_DATA_DICKEY,JoinPartsUWork>();
                // 2010/07/14 Add <<<

                for (int i = 0; i < deleteDataList.Count; i++)
                {
                    // 2010/07/14 Add >>>
                    F_DATA_DICKEY DicKey = new F_DATA_DICKEY();
                    DicKey.joinSourceMakerCd = deleteDataList[i].JoinSourceMakerCode;
                    DicKey.joinSourcePartsNo = deleteDataList[i].JoinSourPartsNoWithH;
                    DicKey.joinDestMakerCd = deleteDataList[i].JoinDestMakerCd;
                    DicKey.joinDestPartsNo = deleteDataList[i].JoinDestPartsNo;
                    if (!JoinPartsUWorkDictionary.ContainsKey(DicKey))
                        continue;
                    // 2010/07/14 Add <<<
                    joinPartsUWork = new JoinPartsUWork();
                    //結合ワーククラスへのデータ格納処理
                    joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU(deleteDataList[i]);
                    // 2010/07/14 Add >>>
                    if (tempDeleteDataList.ContainsKey(DicKey))
                        continue;
                    else
                        tempDeleteDataList.Add(DicKey, joinPartsUWork);
                    // 2010/07/14 Add <<<
                    joinPartsUWorkArray[i] = joinPartsUWork;

                    delList.Add(joinPartsUWork);
                }
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(goodsSetWorkArray);
                #endregion

                #region < 物理削除処理 >
                status = this._iJoinPartsUDB.Delete((object)delList);
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    // 結合情報を元にキャッシュデータを削除する
                    this.RemoveCacheData(joinPartsUWorkArray[0]);
                    // 結合情報を元に子商品情報データテーブル削除
                    this.RemoveChildDataTable(joinPartsUWorkArray[0]);
                    // 結合情報を元に画面表示データテーブル削除
                    this.RemoveDataTable(joinPartsUWorkArray[0]);
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
                this._iJoinPartsUDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 結合論理削除復活処理
        /// </summary>
        /// <param name="revivalDataList">結合データクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        public int Revival(List<JoinPartsU> revivalDataList)
        {
            // 未使用
            return 0;
        }

        /// <summary>
        /// 品番検索(結合検索なし)（Publicメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// </remarks>
        public int SearchPartsFromGoodsNoNonVariousSearch(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string message)
        {
            // 品番検索(結合検索なし)
            return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        }

        /// <summary>
        /// 品番検索（Publicメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// </remarks>
        public int SearchJoinPartsUData(GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;

            status = GetPartsFromGood(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);

            return status;
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
        /// </remarks>
        public int SearchGoodsUnitData(PartsInfoDataSet partsInfoDataSet, int makerCode, string goodsNo, GoodsAcs.GoodsKind goodsKind, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;

            status = GetGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, goodsKind, out goodsUnitDataList);

            return status;
        }

        /// <summary>
        /// 商品連結データの提供区分チェック処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <remarks>
        /// </remarks>
        public bool CheckDivision(GoodsUnitData goodsUnitData)
        {
            foreach (JoinPartsUWork wkJoinPartsUWork in JoinPartsUWorkList)
            {
                if ((goodsUnitData.GoodsNo == wkJoinPartsUWork.JoinDestPartsNo) &&
                   (goodsUnitData.GoodsMakerCd == wkJoinPartsUWork.JoinDestMakerCd))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 価格情報の取得
        /// </summary>
        /// <param name="goodsPriceList">価格リスト</param>
        /// <remarks>
        /// </remarks>
        public GoodsPrice GetGoodsPriceFromGoodsPriceList(List<GoodsPrice> goodsPriceList)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsPriceList);
        }

        /// <summary>
        /// メーカーマスタ情報取得（Publicメソッド）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerUMnt">メーカーマスタ情報</param>
        /// <remarks>
        /// </remarks>
        public int GetMaker(string enterpriseCode, int makerCode, out MakerUMnt makerUMnt)
        {
            return this._goodsAcs.GetMaker(enterpriseCode, makerCode, out makerUMnt);
        }

        /// <summary>
        /// 登録済み結合情報チェック
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <remarks>
        /// </remarks>
        public bool CheckModeChange(GoodsUnitData goodsUnitData)
        {
            foreach (JoinPartsUWork wkJoinPartsUWork in JoinPartsUWorkList)
            {
                if ((wkJoinPartsUWork.JoinSourPartsNoWithH == goodsUnitData.GoodsNo) &&
                    (wkJoinPartsUWork.JoinSourceMakerCode == goodsUnitData.GoodsMakerCd))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ◆Private Methods

        /// <summary>
        /// 結合検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevJoinPartsU">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, JoinPartsU prevJoinPartsU)
        {
            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
            joinPartsUWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = joinPartsUWork;
            object retobj = new ArrayList();

            // 結合検索
            if (readCnt == 0)
            {
                // DBから全件データを取得するためキャッシュをインスタンス化する
                JoinPartsUWorkDictionary = new Dictionary<F_DATA_DICKEY, JoinPartsUWork>();
                JoinPartsUWorkList = new List<JoinPartsUWork>();

                status = this._iJoinPartsUDB.Search(ref retobj, paraobj, 0, logicalMode);                
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

            return status;
        }

        // 2008.10.15 Add >>>
        /// <summary>
        /// 結合元部品を指定して結合マスタを検索します。
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinSourceMakerCode">結合元メーカー</param>
        /// <param name="joinSourPartsNoWithH">結合元品番</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList retList, string enterpriseCode, int joinSourceMakerCode, string joinSourPartsNoWithH, ConstantManagement.LogicalMode logicalMode)
        {
            JoinPartsUWork goodsSetWork = new JoinPartsUWork();
            goodsSetWork.EnterpriseCode = enterpriseCode;
            goodsSetWork.JoinSourceMakerCode = joinSourceMakerCode;
            goodsSetWork.JoinSourPartsNoWithH = joinSourPartsNoWithH;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            object retobj = new ArrayList();

            // 結合マスタ検索
            status = this._iJoinPartsUDB.Search(ref retobj, paraobj, 0, logicalMode);

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
        // 2008.10.15 Add <<<

        // --- ADD m.suzuki 2010/08/03 ---------->>>>>
        /// <summary>
        /// １件読み込み処理
        /// </summary>
        /// <param name="readCndtn"></param>
        /// <returns>STATUS</returns>
        public int Read( JoinPartsU readCndtn )
        {
            int status = -1;

            try
            {
                if ( JoinPartsUWorkDictionary == null )
                {
                    JoinPartsUWorkDictionary = new Dictionary<F_DATA_DICKEY, JoinPartsUWork>();
                }
                if ( JoinPartsUWorkList == null )
                {
                    JoinPartsUWorkList = new List<JoinPartsUWork>();
                }

                // [[結合情報取得]]:結合マスタ(ユーザ)検索
                ArrayList retList;
                status = ReadProc( out retList, readCndtn, ConstantManagement.LogicalMode.GetDataAll );

                #region < 検索後処理 >
                if ( status == 0 )
                {
                    foreach ( object retobj in retList )
                    {
                        // ローカルにキャッシュ
                        this.SetCacheData( (JoinPartsUWork)retobj );
                    }

                    // キャッシュからデータテーブルを全作成
                    this.AllEditDataTable();

                    // データのソート
                    this.JoinPartsUDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc";
                }
                #endregion
            }
            catch ( Exception )
            {
                return -1;
            }

            return status;
        }
        /// <summary>
        /// １件読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadProc( out ArrayList retList, JoinPartsU paraObj, ConstantManagement.LogicalMode logicalMode )
        {
            int status = 0;

            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
            joinPartsUWork.EnterpriseCode = paraObj.EnterpriseCode;
            joinPartsUWork.JoinSourceMakerCode = paraObj.JoinSourceMakerCode;
            joinPartsUWork.JoinSourPartsNoWithH = paraObj.JoinSourPartsNoWithH;

            retList = new ArrayList();
            retList.Clear();

            object objParaObj = joinPartsUWork;
            object retObj = new ArrayList();

            // 結合マスタ検索
            status = this._iJoinPartsUDB.Search( ref retObj, objParaObj, 0, logicalMode );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    retList = retObj as ArrayList;
                    break;

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;

                default:
                    return status;
            }

            return status;
        }
        // --- ADD m.suzuki 2010/08/03 ----------<<<<<

        /// <summary>
        /// 結合データクラス → 結合データワーククラス
        /// </summary>
        /// <param name="joinPartsU">結合データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        private JoinPartsUWork CopyToJoinPartsUWorkFromJoinPartsU(JoinPartsU joinPartsU)
        {
            JoinPartsUWork joinPartsUWork;

            // ヘッダ情報を取得するためのGUIDを取得する
            //object[] objPrimaryKey = new object[] { joinPartsU.JoinSourceMakerCode, joinPartsU.JoinSourPartsNoWithH, joinPartsU.JoinDestMakerCd, joinPartsU.JoinDestPartsNo };
            object[] objPrimaryKey = new object[] {   joinPartsU.JoinSourPartsNoWithH,
                                                      joinPartsU.JoinSourceMakerCode,
                                                      joinPartsU.JoinDestPartsNo,     
                                                      joinPartsU.JoinDestMakerCd
                                                   };
            DataRow row = this.ChildGoodsInfoDataTable.Rows.Find(objPrimaryKey);
            if (row != null)
            {
                joinPartsU.FileHeaderGuid = (Guid)row[FILEHEADERGUID_TITLE];
            }
            
            F_DATA_DICKEY DicKey = new F_DATA_DICKEY();

            DicKey.joinSourceMakerCd = joinPartsU.JoinSourceMakerCode;
            DicKey.joinSourcePartsNo = joinPartsU.JoinSourPartsNoWithH;
            DicKey.joinDestMakerCd = joinPartsU.JoinDestMakerCd;
            DicKey.joinDestPartsNo = joinPartsU.JoinDestPartsNo;

            if (JoinPartsUWorkDictionary.ContainsKey(DicKey))
            {
                // ヘッダ情報を取得するためキャッシュしてあるワーカークラスを取得
                joinPartsUWork = JoinPartsUWorkDictionary[DicKey];
            }
            else
            {
                // ワーカークラス初期化
                joinPartsUWork = new JoinPartsUWork();
            }

            // キャッシュされていた旧データをヘッダ情報を残して編集するデータで上書きする。
            joinPartsUWork.JoinDispOrder = joinPartsU.JoinDispOrder;                // 結合表示順位
            joinPartsUWork.JoinSourceMakerCode = joinPartsU.JoinSourceMakerCode;    // 結合元メーカーコード
            joinPartsUWork.JoinSourPartsNoWithH = joinPartsU.JoinSourPartsNoWithH;  // 結合元品番(－付き品番)
            joinPartsUWork.JoinSourPartsNoNoneH = joinPartsU.JoinSourPartsNoNoneH;  // 結合元品番(－無し品番)
            joinPartsUWork.JoinDestMakerCd = joinPartsU.JoinDestMakerCd;            // 結合先メーカーコード
            joinPartsUWork.JoinDestPartsNo = joinPartsU.JoinDestPartsNo;            // 結合先品番(－付き品番)
            joinPartsUWork.JoinSpecialNote = joinPartsU.JoinSpecialNote;            // 結合規格・特記事項
            joinPartsUWork.JoinQty = joinPartsU.JoinQty;                            // 結合QTY
            
            return joinPartsUWork;
        }

        /// <summary>
        /// 結合データクラス → 結合データワーククラス
        /// </summary>
        /// <param name="inJoinPartsU">結合データクラス</param>
        /// <param name="inJoinPartsUWork">結合データワーククラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        private JoinPartsU CopyToJoinPartsUOverlap(JoinPartsU inJoinPartsU, JoinPartsUWork inJoinPartsUWork)
        {
            JoinPartsU joinPartsU = new JoinPartsU();

            // 結合データワークでヘッダ情報をセット
            joinPartsU.CreateDateTime = inJoinPartsUWork.CreateDateTime;
            joinPartsU.UpdateDateTime = inJoinPartsUWork.UpdateDateTime;
            joinPartsU.EnterpriseCode = inJoinPartsUWork.EnterpriseCode;
            joinPartsU.FileHeaderGuid = inJoinPartsUWork.FileHeaderGuid;
            joinPartsU.UpdEmployeeCode = inJoinPartsUWork.UpdEmployeeCode;
            joinPartsU.UpdAssemblyId1 = inJoinPartsUWork.UpdAssemblyId1;
            joinPartsU.UpdAssemblyId2 = inJoinPartsUWork.UpdAssemblyId2;

            // 結合データで論理削除区分をセット
            joinPartsU.LogicalDeleteCode = inJoinPartsU.LogicalDeleteCode;

            // 結合データで更新情報をセット
            joinPartsU.JoinDispOrder = inJoinPartsU.JoinDispOrder;                  // 表示順位
            joinPartsU.JoinSourceMakerCode = inJoinPartsU.JoinSourceMakerCode;      // 親メーカーコード
            joinPartsU.JoinSourPartsNoWithH = inJoinPartsU.JoinSourPartsNoWithH;    // 結合元品番(－付き品番)
            joinPartsU.JoinSourPartsNoNoneH = inJoinPartsU.JoinSourPartsNoNoneH;    // 結合元品番(－無し品番)
            joinPartsU.JoinDestMakerCd = inJoinPartsU.JoinDestMakerCd;              // 結合先メーカーコード
            joinPartsU.JoinDestPartsNo = inJoinPartsU.JoinDestPartsNo;              // 結合先品番(－付き品番)
            joinPartsU.JoinSpecialNote = inJoinPartsU.JoinSpecialNote;              // 結合規格・特記事項
            joinPartsU.JoinQty = inJoinPartsU.JoinQty;                              // 結合QTY
            
            return joinPartsU;
        }

        /// <summary>
        /// 結合データテーブル登録・更新処理
        /// </summary>
        private void AllEditDataTable()
        {
            this.ChildGoodsInfoDataTable.BeginLoadData();
            this.JoinPartsUDataTable.BeginLoadData();

            foreach(JoinPartsUWork joinPartsUWork in JoinPartsUWorkList)
            {
                // 結合のローカルキャッシュからデータテーブルを全作成
                this.EditDataTable(joinPartsUWork);
            }

            this.ChildGoodsInfoDataTable.EndLoadData();
            this.JoinPartsUDataTable.EndLoadData();
        }

        /// <summary>
        /// 結合データテーブル登録・更新処理
        /// </summary>
        /// <param name="wkJoinPartsUWork">追加情報</param>
        private void EditDataTable(JoinPartsUWork wkJoinPartsUWork)
        {
            //-----------------------------------------------------------------------------
            // 結合商品情報データテーブル作成
            //-----------------------------------------------------------------------------
            #region ●結合商品情報データテーブル作成
            bool bAdd = false;
            DataRow AddChildRow;

            //-----------------------------------------------------------------------------
            // 配列キー生成
            //-----------------------------------------------------------------------------
            object[] objKeyArray = new object[] { wkJoinPartsUWork.JoinSourPartsNoWithH, wkJoinPartsUWork.JoinSourceMakerCode, wkJoinPartsUWork.JoinDestPartsNo, wkJoinPartsUWork.JoinDestMakerCd };

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
            AddChildRow[FILEHEADERGUID_TITLE] = wkJoinPartsUWork.FileHeaderGuid;           // GUID
            AddChildRow[PARENTGOODSMAKERCD_TITLE] = wkJoinPartsUWork.JoinSourceMakerCode;  // 結合元メーカーコード
            AddChildRow[PARENTGOODSNO_TITLE] = wkJoinPartsUWork.JoinSourPartsNoWithH;      // 結合元品番
            AddChildRow[SUBGOODSMAKERCD_TITLE] = wkJoinPartsUWork.JoinDestMakerCd;         // 結合先メーカーコード
            AddChildRow[SUBGOODSNO_TITLE] = wkJoinPartsUWork.JoinDestPartsNo;              // 結合先品番
            AddChildRow[DISPLAYORDER_TITLE] = wkJoinPartsUWork.JoinDispOrder;              // 表示順位
            AddChildRow[SETSPECIALNOTE_TITLE] = wkJoinPartsUWork.JoinSpecialNote;          // セット規格・特記事項
            AddChildRow[QTY_TITLE] = wkJoinPartsUWork.JoinQty;                             // 結合QTY
            AddChildRow[SUBGOODSNAME_TITLE] = wkJoinPartsUWork.JoinDestGoodsName;          // 商品名称
            AddChildRow[SUBGOODSMAKERNM_TITLE] = wkJoinPartsUWork.JoinDestMakerName;       // メーカー名称
            
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
            object[] objKey = new object[] { wkJoinPartsUWork.JoinSourPartsNoWithH, wkJoinPartsUWork.JoinSourceMakerCode };

            //-----------------------------------------------------------------------------
            // テーブル存在チェック
            //-----------------------------------------------------------------------------
            AddRow = this.JoinPartsUDataTable.Rows.Find(objKey);
            if (AddRow == null)
            {
                AddRow = this.JoinPartsUDataTable.NewRow();
                bAdd = true;
            }

            //-----------------------------------------------------------------------------
            // データ項目セット(親情報)
            //-----------------------------------------------------------------------------
            if (wkJoinPartsUWork.LogicalDeleteCode == 0)
            {
                // 論理削除されていなかったら削除日は空
                AddRow[DELETE_DATE] = "";
            }
            else
            {
                // 論理削除されていたら削除日に更新日付を登録
                AddRow[DELETE_DATE] = TDateTime.DateTimeToString(DATATIME_FORM, wkJoinPartsUWork.UpdateDateTime);
            } 
            AddRow[LOGICALDELETE_TITLE] = wkJoinPartsUWork.LogicalDeleteCode;               // 論理削除区分
            AddRow[PARENTGOODSMAKERCD_TITLE] = wkJoinPartsUWork.JoinSourceMakerCode;        // 結合元メーカーコード
            AddRow[PARENTGOODSNO_TITLE] = wkJoinPartsUWork.JoinSourPartsNoWithH;            // 結合元品番
            AddRow[SUBGOODSMAKERCD_TITLE] = wkJoinPartsUWork.JoinSourceMakerCode;           // 結合元メーカーコード
            AddRow[SUBGOODSNO_TITLE] = wkJoinPartsUWork.JoinSourPartsNoWithH;               // 結合元品番
            AddRow[QTY_TITLE] = wkJoinPartsUWork.JoinQty;                                   // 結合QTY
            AddRow[DISPLAYORDER_TITLE] = wkJoinPartsUWork.JoinDispOrder;                    // 表示順位
            AddRow[SETSPECIALNOTE_TITLE] = wkJoinPartsUWork.JoinSpecialNote;                // セット規格・特記事項
            // 2009.03.26 30413 犬飼 結合元品名が空白の場合、メーカー名も空白 >>>>>>START
            //AddRow[PARENTGOODSNAME_TITLE] = wkJoinPartsUWork.JoinSourGoodsName;             // 結合元品名
            //AddRow[PARENTGOODSMAKERNM_TITLE] = wkJoinPartsUWork.JoinSourMakerName;          // 結合元メーカー名
            if (string.IsNullOrEmpty(wkJoinPartsUWork.JoinSourGoodsName))
            {
                AddRow[PARENTGOODSNAME_TITLE] = string.Empty;
                AddRow[PARENTGOODSMAKERNM_TITLE] = string.Empty;
            }
            else
            {
                AddRow[PARENTGOODSNAME_TITLE] = wkJoinPartsUWork.JoinSourGoodsName;             // 結合元品名
                AddRow[PARENTGOODSMAKERNM_TITLE] = wkJoinPartsUWork.JoinSourMakerName;          // 結合元メーカー名
            }
            // 2009.03.26 30413 犬飼 結合元品名が空白の場合、メーカー名も空白 <<<<<<END
            
            //-----------------------------------------------------------------------------
            // 親情報に該当する子情報を全て取得
            //-----------------------------------------------------------------------------
            List<JoinPartsUWork> retJoinPartsUWorkList = JoinPartsUWorkList.FindAll(
                delegate(JoinPartsUWork joinPartsUWork)
                {
                    if ((joinPartsUWork.JoinSourceMakerCode == wkJoinPartsUWork.JoinSourceMakerCode) &&
                        (joinPartsUWork.JoinSourPartsNoWithH == wkJoinPartsUWork.JoinSourPartsNoWithH))
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
            retJoinPartsUWorkList.Sort(new GoodsSetComparer());
            if (retJoinPartsUWorkList.Count > 0)
            {
                AddRow[DISPLAYORDER_TITLE] = retJoinPartsUWorkList[0].JoinDispOrder;        // 表示順位
                AddRow[SUBGOODSMAKERCD_TITLE] = retJoinPartsUWorkList[0].JoinDestMakerCd;   // 結合先メーカーコード 
                AddRow[SUBGOODSNO_TITLE] = retJoinPartsUWorkList[0].JoinDestPartsNo;        // 結合先品番
                // 2009.03.26 30413 犬飼 結合先品名が空白の場合、メーカー名も空白 >>>>>>START
                //AddRow[SUBGOODSMAKERNM_TITLE] = retJoinPartsUWorkList[0].JoinDestMakerName; // 結合先メーカー名
                //AddRow[SUBGOODSNAME_TITLE] = retJoinPartsUWorkList[0].JoinDestGoodsName;    // 結合先品名
                if (string.IsNullOrEmpty(retJoinPartsUWorkList[0].JoinDestGoodsName))
                {
                    AddRow[SUBGOODSMAKERNM_TITLE] = string.Empty;
                    AddRow[SUBGOODSNAME_TITLE] = string.Empty;
                    AddRow[SUBGOODSMAKERCD_TITLE] = 0;      // ADD 2009/04/09
                }
                else
                {
                    AddRow[SUBGOODSMAKERNM_TITLE] = retJoinPartsUWorkList[0].JoinDestMakerName; // 結合先メーカー名
                    AddRow[SUBGOODSNAME_TITLE] = retJoinPartsUWorkList[0].JoinDestGoodsName;    // 結合先品名
                }
                // 2009.03.26 30413 犬飼 結合先品名が空白の場合、メーカー名も空白 <<<<<<END
                AddRow[QTY_TITLE] = retJoinPartsUWorkList[0].JoinQty;                       // 数量
                AddRow[SETSPECIALNOTE_TITLE] = retJoinPartsUWorkList[0].JoinSpecialNote;    // 結合規格・特記事項
            }
            AddRow[CHILDPLURALGOODS_TITLE] = (retJoinPartsUWorkList.Count > 1) ? "※" : ""; // 複数

            //-----------------------------------------------------------------------------
            // データ追加
            //-----------------------------------------------------------------------------
            if (bAdd) this.JoinPartsUDataTable.Rows.Add(AddRow);
            #endregion
        }

        /// <summary>
        /// 結合情報比較クラス(表示順位(昇順))
        /// </summary>
        private class GoodsSetComparer : Comparer<JoinPartsUWork>
        {
            public override int Compare(JoinPartsUWork x, JoinPartsUWork y)
            {
                int result = x.JoinDispOrder.CompareTo(y.JoinDispOrder);
                return result;
            }
        }

        /// <summary>
        /// 結合キャッシュデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">結合データクラスリスト</param>
        /// <remarks>
        /// </remarks>
        private void RemoveCacheDataUnique(List<JoinPartsU> deleteDataList)
        {
            #region ●画面表示用データテーブル削除
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                // 結合ワーククラスへのデータ格納処理
                joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU(deleteDataList[i]);
                // 結合コードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
                string mKeyCode = joinPartsUWork.JoinSourceMakerCode.ToString().Trim();
                string sKeyCode = joinPartsUWork.JoinDestMakerCd.ToString().Trim();
                ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                                PARENTGOODSNO_TITLE + " = '" + joinPartsUWork.JoinSourPartsNoWithH + "' AND " +
                                                                SUBGOODSMAKERCD_TITLE + " = '" + sKeyCode + "' AND " +
                                                                SUBGOODSNO_TITLE + " = '" + joinPartsUWork.JoinDestPartsNo + "'";

                if (ChildGoodsInfoDataTable.DefaultView.Count > 0)
                {
                    F_DATA_DICKEY DicKey = new F_DATA_DICKEY();

                    DicKey.joinSourceMakerCd = (int)ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSMAKERCD_TITLE];
                    DicKey.joinSourcePartsNo = (string)ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSNO_TITLE];
                    DicKey.joinDestMakerCd = (int)ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE];
                    DicKey.joinDestPartsNo = (string)ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE];

                    if (JoinPartsUWorkDictionary != null && JoinPartsUWorkList != null)
                    {
                        if (JoinPartsUWorkDictionary.ContainsKey(DicKey) == true)
                        {
                            // リスト削除のためのデータワーククラスを保持
                            JoinPartsUWork removeData = new JoinPartsUWork();
                            removeData = JoinPartsUWorkDictionary[DicKey];

                            // ディクショナリークラスのデータを削除
                            JoinPartsUWorkDictionary.Remove(DicKey);

                            // リストクラスの削除
                            if (JoinPartsUWorkList.Contains(removeData) == true)
                            {
                                JoinPartsUWorkList.Remove(removeData);
                            }
                        }
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 結合先商品情報テーブルデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="deleteDataList">結合データクラスリスト</param>
        /// <remarks>
        /// </remarks>
        private void RemoveChildDataTableUnique(List<JoinPartsU> deleteDataList)
        {
            #region ●子商品情報データテーブル削除
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                // 結合ワーククラスへのデータ格納処理
                joinPartsUWork = this.CopyToJoinPartsUWorkFromJoinPartsU(deleteDataList[i]);

                object[] objKeyArray = new object[] {   joinPartsUWork.JoinSourPartsNoWithH,
                                                        joinPartsUWork.JoinSourceMakerCode,
                                                        joinPartsUWork.JoinDestPartsNo,     
                                                        joinPartsUWork.JoinDestMakerCd
                                                    };

                if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) != null)
                {
                    // 結合先商品情報データテーブル削除
                    ChildGoodsInfoDataTable.Rows.Find(objKeyArray).Delete();
                }
            }
            #endregion
        }

        /// <summary>
        /// 結合テーブルデータ削除処理（行削除専用）
        /// </summary>
        /// <param name="joinPartsUWork">結合ワーカークラス</param>
        /// <remarks>
        /// </remarks>
        private void RemoveDataTableUnique(JoinPartsUWork joinPartsUWork)
        {
            // 結合先商品情報にフィルタをかける
            string mKeyCode = joinPartsUWork.JoinSourceMakerCode.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + joinPartsUWork.JoinSourPartsNoWithH + "'";
            // 結合先商品情報をソートする
            ChildGoodsInfoDataTable.DefaultView.Sort = PARENTGOODSMAKERCD_TITLE + " asc, " + PARENTGOODSNO_TITLE + " asc, " + DISPLAYORDER_TITLE + " asc";

            #region ●画面表示用データテーブル削除

            this.JoinPartsUDataTable.BeginLoadData();

            object[] objKey = new object[] { joinPartsUWork.JoinSourPartsNoWithH, joinPartsUWork.JoinSourceMakerCode };

            // 画面表示用テーブルの削除
            DataRow AddRow = this.JoinPartsUDataTable.Rows.Find(objKey);

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

            this.JoinPartsUDataTable.EndLoadData();
            #endregion
            #endregion
        }

        /// <summary>
        /// 結合テーブルデータ削除処理
        /// </summary>
        /// <param name="joinPartsUWork">結合ワーカークラス</param>
        /// <remarks>
        /// </remarks>
        private void RemoveDataTable(JoinPartsUWork joinPartsUWork)
        {
            #region ●画面表示用データテーブル削除
            
            //object[] objKey = new object[] { addWork.JoinSourceMakerCode, addWork.JoinSourPartsNoWithH };
            object[] objKey = new object[] { joinPartsUWork.JoinSourPartsNoWithH, joinPartsUWork.JoinSourceMakerCode };

            // < 新規登録 or 更新 のチェック >
            if (this.JoinPartsUDataTable.Rows.Find(objKey) != null)
            {
                // 画面表示用テーブルの削除
                JoinPartsUDataTable.Rows.Find(objKey).Delete();
            }

            #endregion
        }

        /// <summary>
        /// 結合先商品情報テーブルデータ削除処理
        /// </summary>
        /// <param name="joinPartsUWork">結合ワーカークラス</param>
        /// <remarks>
        /// </remarks>
        private void RemoveChildDataTable(JoinPartsUWork joinPartsUWork)
        {
            // 結合コードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            string mKeyCode = joinPartsUWork.JoinSourceMakerCode.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + joinPartsUWork.JoinSourPartsNoWithH + "'";
            
            int cnt = ChildGoodsInfoDataTable.DefaultView.Count;

            for (int i = 0; i < cnt; i++)
            {
                #region ●子商品情報データテーブル削除

                // 結合先商品情報プライマリキー
                object[] objKeyArray = new object[] {   ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSNO_TITLE],
                                                        ChildGoodsInfoDataTable.DefaultView[0][PARENTGOODSMAKERCD_TITLE],
                                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSNO_TITLE],
                                                        ChildGoodsInfoDataTable.DefaultView[0][SUBGOODSMAKERCD_TITLE]
                                                    };
                
                if (ChildGoodsInfoDataTable.Rows.Find(objKeyArray) != null)
                {
                    // 結合先商品情報データテーブル削除
                    ChildGoodsInfoDataTable.Rows.Find(objKeyArray).Delete();
                }

                #endregion
            }
        }

        /// <summary>
        /// 結合データローカルキャッシュ処理
        /// </summary>
        /// <param name="joinPartsUWork">結合ワーカークラス</param>
        /// <remarks>
        /// </remarks>
        private void SetCacheData(JoinPartsUWork joinPartsUWork)
        {
            F_DATA_DICKEY DicKey = new F_DATA_DICKEY();

            DicKey.joinSourceMakerCd = joinPartsUWork.JoinSourceMakerCode;
            DicKey.joinSourcePartsNo = joinPartsUWork.JoinSourPartsNoWithH;
            DicKey.joinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            DicKey.joinDestPartsNo = joinPartsUWork.JoinDestPartsNo;

            if (JoinPartsUWorkDictionary.ContainsKey(DicKey))
            {
                JoinPartsUWorkDictionary.Remove(DicKey);
            }

            // ディクショナリークラスに保存
            JoinPartsUWorkDictionary.Add(DicKey, joinPartsUWork);

            // リストクラスに保存
            // --- UPD m.suzuki 2010/08/03 ---------->>>>>
            //JoinPartsUWorkList.Add(joinPartsUWork);
            AddToJoinPartsUWorkList( ref JoinPartsUWorkList, joinPartsUWork );
            // --- UPD m.suzuki 2010/08/03 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/08/03 ---------->>>>>
        private void AddToJoinPartsUWorkList( ref List<JoinPartsUWork> joinPartsUWorkList, JoinPartsUWork addWork )
        {
            List<JoinPartsUWork> deleteList = joinPartsUWorkList.FindAll(
                delegate( JoinPartsUWork wkJoinPartsUWork )
                {
                    if ( (wkJoinPartsUWork.JoinSourceMakerCode == addWork.JoinSourceMakerCode) &&
                         (wkJoinPartsUWork.JoinSourPartsNoWithH == addWork.JoinSourPartsNoWithH) )
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
                foreach ( JoinPartsUWork deleteWork in deleteList )
                {
                    joinPartsUWorkList.Remove( deleteWork );
                }
            }

            // 追加
            joinPartsUWorkList.Add( addWork );
        }
        // --- ADD m.suzuki 2010/08/03 ----------<<<<<

        /// <summary>
        /// 結合キャッシュデータ削除処理
        /// </summary>
        /// <param name="joinPartsUWork">結合ワーカークラス</param>
        /// <remarks>
        /// </remarks>
        private void RemoveCacheData(JoinPartsUWork joinPartsUWork)
        {
            // 結合コードでフィルタをかけ、現在登録中の同じ商品コードの情報をすべて削除する
            string mKeyCode = joinPartsUWork.JoinSourceMakerCode.ToString().Trim();
            ChildGoodsInfoDataTable.DefaultView.RowFilter = PARENTGOODSMAKERCD_TITLE + " = '" + mKeyCode + "' AND " +
                                                            PARENTGOODSNO_TITLE + " = '" + joinPartsUWork.JoinSourPartsNoWithH + "'";
            
            int cnt = ChildGoodsInfoDataTable.DefaultView.Count;

            for (int i = 0; i < cnt; i++)
            {
                Guid guid = (Guid)ChildGoodsInfoDataTable.DefaultView[i][FILEHEADERGUID_TITLE];
            
                if (JoinPartsUWorkDictionary != null && JoinPartsUWorkList != null)
                {
                    F_DATA_DICKEY DicKey = new F_DATA_DICKEY();

                    // 2010/01/05 Del >>>
                    //DicKey.joinSourceMakerCd = addWork.JoinSourceMakerCode;
                    //DicKey.joinSourcePartsNo = addWork.JoinSourPartsNoWithH;
                    //DicKey.joinDestMakerCd = addWork.JoinDestMakerCd;
                    //DicKey.joinDestPartsNo = addWork.JoinDestPartsNo;
                    // 2010/01/05 Del <<<

                    // 2010/01/05 Add >>>
                    DicKey.joinSourceMakerCd = (int)ChildGoodsInfoDataTable.DefaultView[i][PARENTGOODSMAKERCD_TITLE];
                    DicKey.joinSourcePartsNo = (string)ChildGoodsInfoDataTable.DefaultView[i][PARENTGOODSNO_TITLE];
                    DicKey.joinDestMakerCd = (int)ChildGoodsInfoDataTable.DefaultView[i][SUBGOODSMAKERCD_TITLE];
                    DicKey.joinDestPartsNo = (string)ChildGoodsInfoDataTable.DefaultView[i][SUBGOODSNO_TITLE];
                    // 2010/01/05 Add <<<

                    if (JoinPartsUWorkDictionary.ContainsKey(DicKey) == true)
                    {   
                        // リスト削除のためのデータワーククラスを保持
                        JoinPartsUWork removeData = new JoinPartsUWork();
                        removeData = JoinPartsUWorkDictionary[DicKey];

                        // ディクショナリークラスのデータを削除
                        JoinPartsUWorkDictionary.Remove(DicKey);

                        // リストクラスの削除
                        if (JoinPartsUWorkList.Contains(removeData) == true)
                        {
                            JoinPartsUWorkList.Remove(removeData);
                        }
                    }
                }
            }
        }

        // 2008.10.15 Add >>>
        /// <summary>
        /// クラスメンバーコピー処理（結合マスタワーククラス⇒結合マスタクラス）
        /// </summary>
        /// <param name="joinPartsUWork"></param>
        /// <returns></returns>
        private JoinPartsU CopyToJoinPartsUFromJoinPartsUWork(JoinPartsUWork joinPartsUWork)
        {
            JoinPartsU joinPartsU = new JoinPartsU();

            joinPartsU.CreateDateTime = joinPartsUWork.CreateDateTime;
            joinPartsU.UpdateDateTime = joinPartsUWork.UpdateDateTime;
            joinPartsU.EnterpriseCode = joinPartsUWork.EnterpriseCode;
            joinPartsU.FileHeaderGuid = joinPartsUWork.FileHeaderGuid;
            joinPartsU.UpdEmployeeCode = joinPartsUWork.UpdEmployeeCode;
            joinPartsU.UpdAssemblyId1 = joinPartsUWork.UpdAssemblyId1;
            joinPartsU.UpdAssemblyId2 = joinPartsUWork.UpdAssemblyId2;
            joinPartsU.LogicalDeleteCode = joinPartsUWork.LogicalDeleteCode;
            joinPartsU.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            joinPartsU.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            joinPartsU.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            joinPartsU.JoinSourPartsNoNoneH = joinPartsUWork.JoinSourPartsNoNoneH;
            joinPartsU.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            joinPartsU.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            joinPartsU.JoinQty = joinPartsUWork.JoinQty;
            joinPartsU.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;

            return joinPartsU;
        }

        /// <summary>
        /// ユーザー結合マスタ比較クラス(表示順位順にソート）
        /// </summary>
        /// <remarks></remarks>
        private class JoinPartsUComparer : Comparer<JoinPartsU>
        {
            public override int Compare(JoinPartsU x, JoinPartsU y)
            {
                int result = x.JoinDispOrder.CompareTo(y.JoinDispOrder);

                return result;
            }
        }
        // 2008.10.15 Add <<<

        /// <summary>
        /// 品番検索（Privateメソッド）
        /// </summary>
        /// <param name="goodsCndtn">商品連結データクラス</param>
        /// <param name="partsInfoDataSet">部品情報データセット</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <remarks>
        /// </remarks>
        private int GetPartsFromGood(GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            string message;
            string sectionCd = this._loginWorker.BelongSectionCode.Trim();
            goodsUnitDataList = new List<GoodsUnitData>();

            // 商品情報取得
            status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out message);
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
        /// </remarks>
        private int GetGoodsUnitData(PartsInfoDataSet partsInfoDataSet, int makerCode, string goodsNo, GoodsAcs.GoodsKind goodsKind, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status = -1;
            string sectionCd = this._loginWorker.BelongSectionCode.Trim();

            goodsUnitDataList = new List<GoodsUnitData>();

            // 商品情報取得
            this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, makerCode, goodsNo, goodsKind, out goodsUnitDataList);

            // 商品情報削除分結合情報取得
            this.GetJoinPartsUOfDeletedGoodsInfo(makerCode, goodsNo, ref goodsUnitDataList);

            if (goodsUnitDataList != null)
            {
                status = 0;
            }
            return status;
        }

        /// <summary>
        /// 商品情報削除分結合情報取得処理
        /// </summary>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsUnitDataList"></param>
        private void GetJoinPartsUOfDeletedGoodsInfo(int makerCode, string goodsNo, ref List<GoodsUnitData> goodsUnitDataList)
        {
            if ((goodsUnitDataList == null) || (JoinPartsUWorkList == null)) return;

            //-----------------------------------------------------------------------------
            // 結合情報のキャッシュから対象レコードを取得
            //-----------------------------------------------------------------------------
            List<JoinPartsUWork> joinPartsUWorkList = JoinPartsUWorkList.FindAll(
                delegate(JoinPartsUWork joinPartsUWork)
                {
                    if ((joinPartsUWork.JoinSourceMakerCode == makerCode) &&
                        (joinPartsUWork.JoinSourPartsNoWithH == goodsNo))
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
            // 結合情報のキャッシュに存在して、検索結果に存在しない場合、削除分として設定(削除分も表示対象とする為)
            //-----------------------------------------------------------------------------
            foreach (JoinPartsUWork joinPartsUWork in joinPartsUWorkList)
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList.Find(
                    delegate(GoodsUnitData goodsData)
                    {
                        if ((goodsData.GoodsMakerCd == joinPartsUWork.JoinDestMakerCd) &&
                            (goodsData.GoodsNo == joinPartsUWork.JoinDestPartsNo))
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
                    addGoodsUnitData.EnterpriseCode = joinPartsUWork.EnterpriseCode;        // ADD 2009/04/20
                    addGoodsUnitData.GoodsNo = joinPartsUWork.JoinDestPartsNo;
                    //addGoodsUnitData.GoodsName = addWork.JoinDestGoodsName;
                    //addGoodsUnitData.GoodsMakerCd = addWork.JoinDestMakerCd;       // DEL 2009/04/09
                    //addGoodsUnitData.MakerName = addWork.JoinDestMakerName;
                    // ADD 2009/04/14 --->>>
                    if (joinPartsUWork.JoinDestGoodsName != string.Empty)
                    {
                        addGoodsUnitData.GoodsName = joinPartsUWork.JoinDestGoodsName;
                        addGoodsUnitData.GoodsMakerCd = joinPartsUWork.JoinDestMakerCd;
                        addGoodsUnitData.MakerName = joinPartsUWork.JoinDestMakerName;

                        // ADD 2009/04/20 ------>>>
                        addGoodsUnitData.GoodsPriceList = new List<GoodsPrice>();
                        addGoodsUnitData.StockList = new List<Stock>();
                        this.GetJoinDestGoods(ref addGoodsUnitData);
                        // ADD 2009/04/20 ------<<<
                    }
                    // ADD 2009/04/14 ---<<<
                    addGoodsUnitData.JoinDispOrder = joinPartsUWork.JoinDispOrder;
                    addGoodsUnitData.JoinQty = joinPartsUWork.JoinQty;
                    addGoodsUnitData.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;
                    goodsUnitDataList.Add(addGoodsUnitData);
                }
            }
        }

        // ADD 2009/04/20 ------>>>
        /// <summary>
        /// 結合先情報取得処理(結合元情報が削除されている場合に使用)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        private void GetJoinDestGoods(ref GoodsUnitData goodsUnitData)
        {
            PartsInfoDataSet partsInfoDataSet;
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> goodsUnitDataList;

            goodsCndtn.EnterpriseCode = goodsUnitData.EnterpriseCode;
            goodsCndtn.GoodsNoSrchTyp = 0;
            goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
            goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            goodsCndtn.IsSettingSupplier = 1;
            goodsCndtn.PriceApplyDate = DateTime.Today;
            goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
            goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定

            int status = this.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);
            if (status == 0)
            {
                // 価格情報を取得
                foreach (GoodsPrice goodsPrice in goodsUnitDataList[0].GoodsPriceList)
                {
                    goodsUnitData.GoodsPriceList.Add(goodsPrice);
                }
                // 倉庫情報を取得
                foreach (Stock stock in goodsUnitDataList[0].StockList)
                {
                    goodsUnitData.StockList.Add(stock);
                }                
            }
        }
        // ADD 2009/04/20 ------<<<
        
        /// <summary>
        /// 結合データクラス → 商品連結データクラス
        /// </summary>
        /// <param name="joinPartsU">結合データクラス</param>
        /// <param name="goodsUnitDataDic">新規登録分の商品連結データディクショナリー</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        private GoodsUnitData CopyToGoodsUnitDataFromJoinPartsU(JoinPartsU joinPartsU, Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            GoodsUnitData goodsUnitData;

            // 新規登録分の商品連結データディクショナリーを検索
            string addDataKey = joinPartsU.JoinDestPartsNo + "-" + joinPartsU.JoinDestMakerCd.ToString("d04");
            if (goodsUnitDataDic.ContainsKey(addDataKey))
            {
                goodsUnitData = goodsUnitDataDic[addDataKey];
            }
            else
            {
                // ワーカークラス初期化
                goodsUnitData = null;
            }

            return goodsUnitData;
        }

        /// <summary>
        /// 結合読み込み処理(論理削除含まない)
        /// </summary>
        /// <param name="retList">抽出結果リスト</param>
        /// <param name="joinPartsU">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// </remarks>
        private int SearchJoinPartsU(out ArrayList retList, JoinPartsU joinPartsU)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();

            retList = new ArrayList();

            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();

            // 親品番と親メーカーコードを抽出条件とする
            joinPartsUWork.EnterpriseCode = joinPartsU.EnterpriseCode;
            joinPartsUWork.JoinSourPartsNoWithH = joinPartsU.JoinSourPartsNoWithH;
            joinPartsUWork.JoinSourceMakerCode = joinPartsU.JoinSourceMakerCode;

            object paraobj = joinPartsUWork;
            object retobj = paraList;

            status = this._iJoinPartsUDB.Search(ref retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

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

        #endregion
    }

    // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ---------->>>>>
    #region <セル構造体/>

    /// <summary>
    /// セル座標構造体
    /// </summary>
    public struct CellCoodinate
    {
        /// <summary>行インデックス</summary>
        private int _row;
        /// <summary>
        /// 行インデックスのアクセサ
        /// </summary>
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        /// <summary>列インデックス</summary>
        private int _column;
        /// <summary>
        /// 列インデックスのアクセサ
        /// </summary>
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="column">列インデックス</param>
        public CellCoodinate(
            int row,
            int column
        )
        {
            _row = row;
            _column = column;
        }
    }

    #endregion  // <セル構造体/>
    // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ----------<<<<<
}

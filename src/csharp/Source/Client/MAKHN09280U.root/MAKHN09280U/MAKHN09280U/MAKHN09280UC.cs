//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 商品在庫マスタ
// プログラム概要   : 商品在庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : caohh
// 修 正 日  2011/08/02  修正内容 : NSユーザー改良要望一覧連番265の対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : wangf
// 修 正 日  2011/09/15  修正内容 : 案件一覧 連番265 でのテスト不具合についての修正 FOR redmine #25013
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh 
// 修 正 日  2012/11/21  修正内容 : 2013/01/16配信分 redmine #33230  
//                                : 掛率設定マスタ内に論理削除レコードが存在する状態で、
//                                  同商品の掛率の登録をしようとしているために発生している不具合の対応
//----------------------------------------------------------------------------//
// 管理番号 11170129-00  作成担当 : 黄興貴
// 修 正 日 2015/09/10   修正内容 : Redmine#47026 商品在庫マスタの障害対応
//----------------------------------------------------------------------------//
// 管理番号  11370033-00 作成担当 : 陳艶丹
// 更 新 日  2018/10/26　修正内容 : Redmine#49732 原価UP率と粗利確保率の設定が消える対応                       
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 単品売価情報入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスメンの単品売価情報入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br>UpdateNote : 2008/12/15 30462 行澤仁美　バグ修正</br>
    /// <br>           : グリット内のTabキーでの移動対応。</br>
    /// <br>UpdateNote : 2009/01/09 30414 忍 幸史　障害ID:9903対応</br>
    /// <br>UpdateNote : 2009/02/10 30414 忍 幸史　障害ID:11264対応</br>
    /// <br>UpdateNote : 2009/03/18 30414 忍 幸史　障害ID:12530対応</br>
    /// <br>UpdateNote : 2009/11/20 30434 工藤恵優 3次分対応 得意先掛率グループ改良</br>
    /// <br>UpdateNote : 2009/11/20 30434 工藤恵優 障害ID:14598対応</br>
    /// <br>UpdateNote : 2010/01/18 30434 工藤恵優 障害ID:14896対応</br>
    /// <br>Update Note: 2010/06/08 楊明俊 不具合の対応</br>
    /// <br>Update Note: 2011/08/02 caohh 連番265 ユーザー設定画面の新規追加対応</br>
    /// <br>UpdateNote : 2012/11/21 zhuhh</br>
    /// <br>           : 2013/01/16配信分</br>
    /// <br>           : redmine #33230  掛率設定マスタ内に論理削除レコードが存在する状態で、</br>
    /// <br>           : 同商品の掛率の登録をしようとしているために発生して</br>
    /// <br>           : いる不具合の対応</br>
    /// <br>Update Note: 2015/09/10 黄興貴</br>
    /// <br>管理番号   : 11170129-00</br>
    /// <br>             Redmine#47026 商品在庫マスタの障害対応</br>
    /// <br>Update Note: 2018/10/26 陳艶丹</br>
    /// <br>管理番号   : 11370033-00</br>
    /// <br>             Redmine#49732 原価UP率と粗利確保率の設定が消える対応</br>
    /// </remarks>
    public partial class MAKHN09280UC : UserControl
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        //private GoodsAcs _goodsAcs;                                         // 商品マスタアクセスクラス
        private DataTable _salesPriceRateTable; // 商品価格データテーブル
        private GoodsUnitData _goodsUnitData;                               // 商品連結データクラス
        private DateTime _beforePriceStartDate = DateTime.MinValue;
        //private double _beforeListPrice = 0;
        //private double _beforeStockRate = 0;
        //private double _beforeSalesUnitCost = 0;
        private DateTime _beforeOfferDate = DateTime.MinValue;
        private bool _beforeCellUpdateCancel = false;
        //private List<Rate> _rateList;
        private Dictionary<int, Rate> _rateBufferDic;
        // 2009.03.03 30413 犬飼 得意先掛率Ｇ名称をキャッシュ >>>>>>START
        private Dictionary<int, string> _custRateGrpNameDic;
        // 2009.03.03 30413 犬飼 得意先掛率Ｇ名称をキャッシュ <<<<<<END

        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>得意先掛率グループの指定なしの掛率情報のキャプション</summary>
        private const string ALL_RATE_GROUP_CAPTION = "ALL";
        /// <summary>得意先掛率グループの指定なしの得意先掛率グループコード</summary>
        private const int ALL_RATE_GROUP_CODE = -1;
        /// <summary>得意先掛率グループの指定なしの得意先掛率グループコード名称</summary>
        private const string ALL_RATE_GROUP_CODE_NAME = "指定なし";

        #region 掛率設定区分

        /// <summary>通常の掛率設定区分</summary>
        private const string NORMAL_RATE_SETTING_DIVIDE = "4A"; // 得意先掛率グループ+品番+メーカー
        /// <summary>特殊な掛率設定区分</summary>
        private const string SPECIAL_RATE_SETTING_DIVIDE= "6A"; // 指定なし+品番+メーカー
        /// <summary>対象とする掛率設定区分</summary>
        private string[] _targetRateSettingDivides = new string[] { NORMAL_RATE_SETTING_DIVIDE, SPECIAL_RATE_SETTING_DIVIDE };
        /// <summary>対象とする掛率設定区分を取得します。</summary>
        private string[] TargetRateSettingDivides { get { return _targetRateSettingDivides; } }

        /// <summary>
        /// 対象とする掛率設定区分であるか判断します。
        /// </summary>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <returns>
        /// <c>true</c> :対象とする掛率設定区分です。<br/>
        /// <c>false</c>:対象とする掛率設定区分ではありません。
        /// </returns>
        private bool IsTargetRateSettingDivide(string rateSettingDivide)
        {
            return Array.Exists(TargetRateSettingDivides, delegate(string item)
            {
                return item.Equals(rateSettingDivide);
            });
        }

        /// <summary>
        /// 通常の掛率設定区分であるか判断します。
        /// </summary>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <returns>
        /// <c>true</c> :通常の掛率設定区分です。<br/>
        /// <c>false</c>:通常の掛率設定区分ではありません。
        /// </returns>
        private static bool IsNormalRateSettingDivide(string rateSettingDivide)
        {
            return rateSettingDivide.Equals(NORMAL_RATE_SETTING_DIVIDE);
        }

        #endregion // 掛率設定区分
        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

        private bool _parentEnabled = true;

        private const string ct_Col_CustRateGrp_00 = "CustRateGrp_00";
        private const string ct_Col_CustRateGrp_01 = "CustRateGrp_01";
        private const string ct_Col_CustRateGrp_02 = "CustRateGrp_02";
        private const string ct_Col_CustRateGrp_03 = "CustRateGrp_03";
        private const string ct_Col_CustRateGrp_04 = "CustRateGrp_04";
        private const string ct_Col_CustRateGrp_05 = "CustRateGrp_05";
        private const string ct_Col_CustRateGrp_06 = "CustRateGrp_06";
        private const string ct_Col_CustRateGrp_07 = "CustRateGrp_07";
        private const string ct_Col_CustRateGrp_08 = "CustRateGrp_08";
        private const string ct_Col_CustRateGrp_09 = "CustRateGrp_09";
        private const string ct_Col_CustRateGrp_10 = "CustRateGrp_10";
        private const string ct_Col_CustRateGrp_11 = "CustRateGrp_11";
        private const string ct_Col_CustRateGrp_12 = "CustRateGrp_12";
        private const string ct_Col_CustRateGrp_13 = "CustRateGrp_13";
        private const string ct_Col_CustRateGrp_14 = "CustRateGrp_14";
        private const string ct_Col_CustRateGrp_15 = "CustRateGrp_15";
        private const string ct_Col_CustRateGrp_16 = "CustRateGrp_16";
        private const string ct_Col_CustRateGrp_17 = "CustRateGrp_17";
        private const string ct_Col_CustRateGrp_18 = "CustRateGrp_18";
        private const string ct_Col_CustRateGrp_19 = "CustRateGrp_19";

        // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする >>>>>>START
        private const string ct_Col_CustRateGrp_20 = "CustRateGrp_20";
        private const string ct_Col_CustRateGrp_21 = "CustRateGrp_21";
        private const string ct_Col_CustRateGrp_22 = "CustRateGrp_22";
        private const string ct_Col_CustRateGrp_23 = "CustRateGrp_23";
        private const string ct_Col_CustRateGrp_24 = "CustRateGrp_24";
        private const string ct_Col_CustRateGrp_25 = "CustRateGrp_25";
        private const string ct_Col_CustRateGrp_26 = "CustRateGrp_26";
        private const string ct_Col_CustRateGrp_27 = "CustRateGrp_27";
        private const string ct_Col_CustRateGrp_28 = "CustRateGrp_28";
        private const string ct_Col_CustRateGrp_29 = "CustRateGrp_29";
        private const string ct_Col_CustRateGrp_30 = "CustRateGrp_30";
        private const string ct_Col_CustRateGrp_31 = "CustRateGrp_31";
        private const string ct_Col_CustRateGrp_32 = "CustRateGrp_32";
        private const string ct_Col_CustRateGrp_33 = "CustRateGrp_33";
        private const string ct_Col_CustRateGrp_34 = "CustRateGrp_34";
        private const string ct_Col_CustRateGrp_35 = "CustRateGrp_35";
        private const string ct_Col_CustRateGrp_36 = "CustRateGrp_36";
        private const string ct_Col_CustRateGrp_37 = "CustRateGrp_37";
        private const string ct_Col_CustRateGrp_38 = "CustRateGrp_38";
        private const string ct_Col_CustRateGrp_39 = "CustRateGrp_39";
        // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする <<<<<<END

        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
        // 得意先掛率グループの指定なしデータも扱うため、2列(売価率、売価)追加
        private const string ct_Col_CustRateGrp_40 = "CustRateGrp_40";
        private const string ct_Col_CustRateGrp_41 = "CustRateGrp_41";
        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
        // 扱う事の出来る掛率グループコードの数 (0～ct_RateGroupCount-1が対象)
        //private const int ct_RateGroupCount = 20;
        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
        // 得意先掛率グループの指定なしデータも扱うため、20→21に変更
        private const int ct_RateGroupCount = 21;
        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        public MAKHN09280UC()
        {
            InitializeComponent();

            //this._goodsAcs = new GoodsAcs();
            this._salesPriceRateTable = this.CreateSalesPriceRateTable();
            //this._goodsUnitData = new GoodsUnitData();

            _rateBufferDic = new Dictionary<int, Rate>();
        }
        /// <summary>
        /// 掛率テーブル生成
        /// </summary>
        /// <returns></returns>
        private DataTable CreateSalesPriceRateTable()
        {
            DataTable table = new DataTable();

            //--------------------------------------
            // カラム設定初期化
            //--------------------------------------
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_00, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_01, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_02, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_03, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_04, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_05, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_06, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_07, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_08, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_09, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_10, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_11, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_12, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_13, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_14, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_15, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_16, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_17, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_18, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_19, typeof( double ) ) );

            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする >>>>>>START
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_20, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_21, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_22, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_23, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_24, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_25, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_26, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_27, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_28, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_29, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_30, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_31, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_32, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_33, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_34, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_35, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_36, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_37, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_38, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_39, typeof(double)));
            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする <<<<<<END

            // 初期値のセット(DBNullによるエラー防止)
            table.Columns[ct_Col_CustRateGrp_00].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_01].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_02].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_03].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_04].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_05].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_06].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_07].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_08].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_09].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_10].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_11].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_12].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_13].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_14].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_15].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_16].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_17].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_18].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_19].DefaultValue = 0;

            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする >>>>>>START
            table.Columns[ct_Col_CustRateGrp_20].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_21].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_22].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_23].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_24].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_25].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_26].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_27].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_28].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_29].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_30].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_31].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_32].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_33].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_34].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_35].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_36].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_37].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_38].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_39].DefaultValue = 0;
            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする <<<<<<END

            // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // 得意先掛率グループの指定なしデータも扱うため、2列(売価率、売価)追加
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_40, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_41, typeof(double)));
            table.Columns[ct_Col_CustRateGrp_40].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_41].DefaultValue = 0;
            // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

            //--------------------------------------
            // 空行×２追加
            //--------------------------------------
            table.Rows.Add( table.NewRow() );   // 売価率
            table.Rows.Add( table.NewRow() );   // 売価額

            return table;
        }

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        /// <summary>
        /// 価格情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rowNo"></param>
        internal delegate void SettingGoodsPriceEventHandler(object sender, int rowNo);
        
        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>価格情報設定イベント</summary>
        internal event SettingGoodsPriceEventHandler SettingGoodsPrice;
        
        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        /// <summary>
        /// 商品連結データクラス
        /// </summary>
        public GoodsUnitData GoodsUnitData
        {
            get { return this._goodsUnitData; }
            set { this._goodsUnitData = value; }
        }

        //public List<Rate> RateList
        //{
        //    get { return this._rateList; }
        //    set { this._rateList = value; }
        //}

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
            ////----- ↑キー
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.Up,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
            //    Infragistics.Win.SpecialKeys.All,
            //    0,
            //    true);
            //this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
            // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
            ////----- ↓キー
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.Down,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
            //    Infragistics.Win.SpecialKeys.All,
            //    0,
            //    true);
            //this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
            // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_UnitSalesPriceInfo.BeginUpdate();

            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                if ( cell.Column.Key != ct_Col_CustRateGrp_19 )
                {
                    // [00]～[18]番
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                else
                {
                    // 最終[19]番
                    // ADD 2008/12/15 不具合対応[8733] ---------->>>>>
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                    // ADD 2008/12/15 不具合対応[8733] ----------<<<<<
                }

                ////------------------------------------------------------------
                //// 価格開始日
                ////------------------------------------------------------------
                //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // 次入力可能セル移動処理
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// 標準価格
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // 次入力可能セル移動処理
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// 仕入率
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // 次入力可能セル移動処理
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// 原単価
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // 次入力可能セル移動処理
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                //else
                //{
                //    // 次入力可能セル移動処理
                //    canMove = this.MoveNextAllowEditCell(false);
                //}
                return canMove;
            }
            finally
            {
                this.uGrid_UnitSalesPriceInfo.EndUpdate();
            }
        }

        
        // ADD 2008/12/15 不具合対応[8733] ---------->>>>>
        internal bool ShiftReturnKeyDown()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_UnitSalesPriceInfo.BeginUpdate();

            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                return canMove;
            }
            finally
            {
                this.uGrid_UnitSalesPriceInfo.EndUpdate();
            }
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_UnitSalesPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_UnitSalesPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                
                if (performActionResult)
                {
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_UnitSalesPriceInfo.ResumeLayout();
            return performActionResult;
        }
        // ADD 2008/12/15 不具合対応[8733] ----------<<<<<

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_UnitSalesPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_UnitSalesPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_UnitSalesPriceInfo.Rows[this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index].Cells[this._salesDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if ((editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable) || (editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_UnitSalesPriceInfo.ActiveRow != null))
                //        {
                //            int index = this.uGrid_UnitSalesPriceInfo.ActiveRow.Index;

                //            if (!(this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // 再帰処理
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_UnitSalesPriceInfo.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// 価格情報設定イベントコール処理
        /// </summary>
        /// <param name="rowNo"></param>
        private void SettingGoodsPriceEventCall(int rowNo)
        {
            if ((this.SettingGoodsPrice != null) && (rowNo != 0))
            {
                this.SettingGoodsPrice(this, rowNo);
            }
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                return this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
            }
            else if (this.uGrid_UnitSalesPriceInfo.ActiveRow != null)
            {
                return this.uGrid_UnitSalesPriceInfo.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        ///// <summary>
        ///// ActiveRowの行番号取得処理
        ///// </summary>
        ///// <returns></returns>
        //internal int GetActiveRowRowNo()
        //{
        //    int rowIndex = this.GetActiveRowIndex();
        //    if (rowIndex < 0) return -1;

        //    return this._goodsPriceDataTable[rowIndex].RowNo;
        //}

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="salesSlip">仕入データクラスオブジェクト</param>
        internal void SettingGridRow(int rowIndex)
        {
            if (this._salesPriceRateTable.Rows.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            //// 価格開始日
            //DateTime priceStartDate = this._goodsPriceDataTable[rowIndex].PriceStartDate;
            //// 提供日付
            //DateTime offerDate = this._goodsPriceDataTable[rowIndex].OfferDate;

            //// 指定行の全ての列に対して設定を行う。
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            //{

            //    // セル情報を取得
            //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[col];
            //    if (cell == null) continue;

            //    //------------------------------------------------
            //    // セル状態設定
            //    //------------------------------------------------
            //    if ((col.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName))
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
            //        //(col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName)
            //      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
            //        }
            //        else
            //        {
            //            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
            //        }
            //    }
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
            //    if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
            //    {
            //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
            //    }
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD

            //    //------------------------------------------------
            //    // 無効要素のテキストカラー設定
            //    //------------------------------------------------
            //    // 価格開始日
            //    if (col.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //        }
            //        else
            //        {
            //            cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //        }
            //    }
            //    // オープン価格区分
            //    if (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //            cell.Appearance.ForeColorDisabled = Color.Transparent;
            //        }
            //        else
            //        {
            //            cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            cell.Appearance.ForeColorDisabled = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //        }
            //    }
            //    // 提供日付
            //    if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
            //    {
            //        if ( offerDate == DateTime.MinValue )
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //            cell.Appearance.ForeColorDisabled = Color.Transparent;
            //        }
            //        else
            //        {
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
            //            //cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            //cell.Appearance.ForeColorDisabled = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
            //            cell.Appearance.ForeColor = Color.Black;
            //            cell.Appearance.ForeColorDisabled = Color.Black;
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD
            //        }
            //    }
            //}
        }

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKHN09280UC_Load(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
            //if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            //{
            //    //this._salesPriceRateTable.Rows.Clear();
            //    this.ClearSalesPriceRateTable();

            //    this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;

            //    //this._goodsAcs.ClearGoodsPriceDataTable();
            //}
            //else
            //{
            //    this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            //}


            //// キーマッピング設定
            //this.MakeKeyMappingForGrid( this.uGrid_UnitSalesPriceInfo );

            //// 描画が必要な明細件数を取得する。
            //int cnt = this._salesPriceRateTable.Rows.Count;

            //// 各行ごとの設定
            //for ( int i = 0; i < cnt; i++ )
            //{
            //    this.SettingGridRow( i );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
        }
        /// <summary>
        /// ロード処理
        /// </summary>
        public void Loading()
        {
            if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            {
                this.ClearSalesPriceRateTable();
                this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            }
            else
            {
                this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            }

            // キーマッピング設定
            this.MakeKeyMappingForGrid( this.uGrid_UnitSalesPriceInfo );

            // 描画が必要な明細件数を取得する。
            int cnt = this._salesPriceRateTable.Rows.Count;

            // 各行ごとの設定
            for ( int i = 0; i < cnt; i++ )
            {
                this.SettingGridRow( i );
            }
        }
        /// <summary>
        /// テーブルクリア処理（２行固定なので特殊）
        /// </summary>
        /// <br>Update Note: 2011/08/02 caohh 連番265 ユーザー設定画面の新規追加対応</br>
        /// <br>Update Note: 2011/09/15 wangf RedMine#20153の対応</br>
        //private void ClearSalesPriceRateTable() //DEL caohh 2011/08/02
        public void ClearSalesPriceRateTable() //ADD caohh 2011/08/02
        {
            // 削除
            this._salesPriceRateTable.Rows.Clear();
            _rateBufferDic.Clear(); // ADD wangf 2011/09/15

            // 空行×２追加
            this._salesPriceRateTable.Rows.Add( this._salesPriceRateTable.NewRow() );
            this._salesPriceRateTable.Rows.Add( this._salesPriceRateTable.NewRow() );
        }

        // TODO:掛率の表示用テーブルを設定する処理はココだけ
        /// <summary>
        /// 掛率リスト設定処理
        /// </summary>
        /// <param name="rateList"></param>
        /// <br>Update Note: 2010/06/08 楊明俊</br>
        /// <br>             不具合の対応</br>
        /// <br>             掛率マスタにおいて対象品番に対して、「品番＋メーカー」パターンで</br> 
        /// <br>             数量ごとの売価率を設定した場合、商品マスタでその品番を呼び出すとエラーとなる。</br>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>           : Redmine#33230  論理削除データ含む</br>
        public void SetRateList( List<Rate> rateList )
        {
            // 初期化する
            _rateBufferDic = new Dictionary<int, Rate>();
            ClearSalesPriceRateTable();

            // 指定リストから情報取得
            foreach ( Rate rate in rateList )
            {
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                // 2009.02.20 30413 犬飼 削除後の再入力不可対応 >>>>>>START
                //if (rate.LogicalDeleteCode != 0)
                //{
                //    // "0:通常"以外は登録しない
                //    continue;
                //}
                // 2009.02.20 30413 犬飼 削除後の再入力不可対応 <<<<<<END
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                if (rate.LogicalDeleteCode != 0 & rate.LogicalDeleteCode != 1)
                {
                    // "0:通常 1:論理削除"以外は登録しない
                    continue;
                }
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // 掛率設定区分は"4A"と"6A"を対象
                if (!IsTargetRateSettingDivide(rate.RateSettingDivide.Trim())) continue;
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

                int group = rate.CustRateGrpCode;

                if (IsNormalRateSettingDivide(rate.RateSettingDivide.Trim()))   // ADD 2009/11/20 3次分対応 得意先掛率グループ改良
                {
                    if (group < 0 || ct_RateGroupCount - 1 < group) continue;

                    //--- ADD 2010/06/08 ---------->>>>> 
                    if (_rateBufferDic.ContainsKey(group))
                    {
                        continue;
                    }
                    //--- ADD 2010/06/08 ----------<<<<<

                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //_salesPriceRateTable.Rows[0][group] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][group] = rate.PriceFl;
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // TODO:得意先掛率グループコードとその設定セルの対応付けはココで決まる
                    // groupに+1すると見た目は右に+1シフトする
                    // ただし、グリッドのヘッダキャプションは変わらないので、表示セル位置をシフトさせた場合、
                    // ヘッダキャプションをuGrid_UnitSalesPriceInfo_InitializeLayout()で調整する必要がある。
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    //_salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    if (rate.LogicalDeleteCode == 0)
                    {
                        _salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                        _salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                    }
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    // 複製をディクショナリに退避
                    _rateBufferDic.Add(group, rate.Clone());
                }
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                else
                {
                    // --- ADD 2010/06/08 ---------->>>>> 
                    if (_rateBufferDic.ContainsKey(ALL_RATE_GROUP_CODE))
                    {
                        continue;
                    }
                    // --- ADD 2010/06/08 ----------<<<<<
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    //_salesPriceRateTable.Rows[0][0] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    if (rate.LogicalDeleteCode == 0)
                    {
                        _salesPriceRateTable.Rows[0][0] = rate.RateVal;
                        _salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                    }
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // 複製をディクショナリに退避
                    _rateBufferDic.Add(ALL_RATE_GROUP_CODE, rate.Clone());
                }
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
            }   // foreach ( Rate rate in rateList )
        }

        // --- ADD 黄興貴 2015/09/10 Redmine#47026 --------------->>>>>
        /// <summary>
        /// 掛率リスト設定処理
        /// </summary>
        /// <param name="rateList">掛率リスト</param>
        /// <param name="mode">0:元値をセット</param>
        /// <remarks>
        /// <br>Update Note: 2015/09/10 黄興貴</br>
        /// <br>管理番号   : 11170129-00</br>
        /// <br>             Redmine#47026 商品在庫マスタの障害対応</br>
        /// </remarks>
        public void SetRateList(List<Rate> rateList,int mode)
        {
            if (mode != 0)
            {
                // 商品在庫マスタⅡを参照し、元に戻す関連処理。
                // 削除
                this._salesPriceRateTable.Rows.Clear();

                // 空行×２追加
                this._salesPriceRateTable.Rows.Add(this._salesPriceRateTable.NewRow());
                this._salesPriceRateTable.Rows.Add(this._salesPriceRateTable.NewRow());

                // 指定リストから情報取得
                foreach (Rate rate in rateList)
                {
                    if (rate.LogicalDeleteCode != 0 & rate.LogicalDeleteCode != 1)
                    {
                        // "0:通常 1:論理削除"以外は登録しない
                        continue;
                    }
                    // 掛率設定区分は"4A"と"6A"を対象
                    if (!IsTargetRateSettingDivide(rate.RateSettingDivide.Trim())) continue;

                    int group = rate.CustRateGrpCode;

                    if (IsNormalRateSettingDivide(rate.RateSettingDivide.Trim()))
                    {
                        if (group < 0 || ct_RateGroupCount - 1 < group) continue;

                        if (rate.LogicalDeleteCode == 0)
                        {
                            _salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                            _salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                        }
                    }
                    else
                    {
                        if (rate.LogicalDeleteCode == 0)
                        {
                            _salesPriceRateTable.Rows[0][0] = rate.RateVal;
                            _salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                        }
                    }
                }
            }
        }
        // --- ADD 黄興貴 2015/09/10 Redmine#47026 ---------------<<<<<

        /// <summary>
        /// 掛率リスト取得処理
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>           : Redmine#33230  論理削除データ含む</br>
        /// <br>Update Note: 2015/09/10 黄興貴</br>
        /// <br>管理番号   : 11170129-00</br>
        /// <br>             Redmine#47026 商品在庫マスタの障害対応</br>
        /// <br>Update Note: 2018/10/26 陳艶丹</br>
        /// <br>管理番号   : 11370033-00</br>
        /// <br>             Redmine#49732 原価UP率と粗利確保率の設定が消える対応</br>
        public List<Rate> GetRateList()
        {
            List<Rate> retRateList = new List<Rate>();

            for ( int group = 0; group < ct_RateGroupCount; group++ )
            {
                // グリッド入力内容を取得
                double rateVal = (double)_salesPriceRateTable.Rows[0][group];
                double priceFl = (double)_salesPriceRateTable.Rows[1][group];

                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                int groupCode = group - 1;  // 得意先掛率グループコードを調整
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

                // 入力されている列のみ登録
                if ( rateVal != 0 || priceFl != 0 )
                {
                    Rate rate;
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // if (_rateBufferDic.ContainsKey(group))
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    if (_rateBufferDic.ContainsKey(groupCode))
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    {
                        // 既存修正
                        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        // rate = _rateBufferDic[group];
                        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        //rate = _rateBufferDic[groupCode];// DEL 黄興貴 2015/09/10 Redmine#47026
                        rate = _rateBufferDic[groupCode].Clone();// ADD 黄興貴 2015/09/10 Redmine#47026
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    }
                    else
                    {
                        // 新規作成
                        rate = this.CreateNewRate();
                        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        // rate.CustRateGrpCode = group;
                        // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        rate.CustRateGrpCode = groupCode;
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    }

                    // 入力内容で書き換え
                    rate.RateVal = rateVal;
                    rate.PriceFl = priceFl;

                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // TODO:得意先掛率グループコード指定がなし用の補正
                    if (groupCode < 0)
                    {
                        rate.UnitRateSetDivCd = "16A";      // 単価種類+掛率設定区分 ※単価種類(1:売価設定)
                        rate.RateSettingDivide = "6A";      // 掛率設定区分=掛率設定区分(得意先)+掛率設定区分(商品)
                        rate.RateMngCustCd = "6";           // 掛率設定区分(得意先)…4:得意先掛率グループ/6:指定なし
                        rate.RateMngCustNm = "指定なし";    // 掛率設定名称(得意先)…4:得意先掛率グループ/6:指定なし
                        // ADD 2010/01/18 MANTIS[14896] 得意先掛率グループコード：-1 で登録するのは不可 ---------->>>>>
                        if (rate.FileHeaderGuid.Equals(Guid.Empty))
                        {
                            rate.CustRateGrpCode = 0;// groupCode;   // 得意先掛率グループコード(-1:未設定)←不可
                        }
                        // ADD 2010/01/18 MANTIS[14896] 得意先掛率グループコード：-1 で登録するのは不可 ----------<<<<<
                    }
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    // リストに追加
                    rate.LogicalDeleteCode = 0;// ADD zhuhh 2012/11/21 for Redmine #33230
                    retRateList.Add( rate );
                }
                // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // else if ( _rateBufferDic.ContainsKey( group ) )
                // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //else if (_rateBufferDic.ContainsKey(groupCode)) // DEL zhuhh 2012/11/21 for Redmine #33230
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                else if (_rateBufferDic.ContainsKey(groupCode) && _rateBufferDic[groupCode].LogicalDeleteCode != 1) // ADD zhuhh 2012/11/21 for Redmine #33230
                {
                    // 【ディクショナリ有り・入力無し】なら削除レコード生成
                    // 既存修正
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // Rate rate = _rateBufferDic[group];
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //Rate rate = _rateBufferDic[groupCode];// DEL 黄興貴 2015/09/10 Redmine#47026
                    Rate rate = _rateBufferDic[groupCode].Clone();// ADD 黄興貴 2015/09/10 Redmine#47026
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // --- ADD 陳艶丹 2018/10/26 Redmine#49732の対応---------->>>>>
                    if (rate.UpRate != 0 || rate.GrsProfitSecureRate != 0)
                    {
                        rate.RateVal = 0;
                        rate.PriceFl = 0;
                    }
                    else
                    {
                    // --- ADD 陳艶丹 2018/10/26 Redmine#49732の対応----------<<<<<
                        rate.LogicalDeleteCode = 3; // 3:物理削除
                        rate.RateVal = 0;
                        rate.PriceFl = 0;
                    }// ADD 陳艶丹 2018/10/26 Redmine#49732の対応

                    // リストに追加
                    retRateList.Add( rate );
                }
            }

            return retRateList;
        }
        /// <summary>
        /// 掛率リスト（元に戻す用）取得処理
        /// </summary>
        /// <returns></returns>
        public List<Rate> GetRateListForRollBack()
        {
            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                rateList.Add( rate );
            }
            return rateList;
        }
        /// <summary>
        /// 掛率リスト（完全削除用）取得処理
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>           : Redmine#33230  論理削除データ含まない</br>
        public List<Rate> GetRateListForDelete()
        {
            //----------------------------------------
            // ※LogicalDeleteCode=3:物理削除をセット
            //----------------------------------------

            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                //rate.LogicalDeleteCode = 3;
                //rateList.Add( rate );
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                if (rate.LogicalDeleteCode != 1)
                {
                    rate.LogicalDeleteCode = 3;
                    rateList.Add(rate); 
                }
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
            }
            return rateList;
        }
        /// <summary>
        /// 掛率リスト（論理削除復旧用）
        /// </summary>
        /// <returns></returns>
        public List<Rate> GetRateListForRevive()
        {
            //----------------------------------------
            // ※LogicalDeleteCode=0:通常に戻す
            //----------------------------------------

            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                rate.LogicalDeleteCode = 0;
                rateList.Add( rate );
            }
            return rateList;
        }

        ///// <summary>
        ///// 前回値への戻し処理（元に戻す）
        ///// </summary>
        //public void RollBackInGrid()
        //{
        //    // クリアする
        //    ClearSalesPriceRateTable();

        //    // 退避ディクショナリから再設定する。
        //    for ( int group = 0; group < ct_RateGroupCount - 1; group++ )
        //    {
        //        if ( !_rateBufferDic.ContainsKey( group ) ) continue;

        //        Rate rate = _rateBufferDic[group];
        //        _salesPriceRateTable.Rows[0][group] = rate.RateVal;
        //        _salesPriceRateTable.Rows[1][group] = rate.PriceFl;
        //    }
        //}
        /// <summary>
        /// TODO:新規掛率オブジェクト生成（関連付けられた商品情報に基づく）
        /// </summary>
        /// <returns></returns>
        private Rate CreateNewRate()
        {
            Rate newRate = new Rate();

            string employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;

            # region [掛率]
            newRate.CreateDateTime = DateTime.Now; // 作成日時
            newRate.UpdateDateTime = DateTime.MinValue; // 更新日時
            newRate.EnterpriseCode = _goodsUnitData.EnterpriseCode; // 企業コード
            newRate.FileHeaderGuid = Guid.Empty; // GUID
            newRate.UpdEmployeeCode = employeeCode; // 更新従業員コード
            //newRate.UpdAssemblyId1 = default( string ); // 更新アセンブリID1
            //newRate.UpdAssemblyId2 = default( string ); // 更新アセンブリID2
            newRate.LogicalDeleteCode = 0; // 論理削除区分
            newRate.SectionCode = "00"; // 拠点コード
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------>>>>>
            //newRate.UnitRateSetDivCd = "1A4"; // 単価掛率設定区分
            newRate.UnitRateSetDivCd = "14A"; // 単価掛率設定区分
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------<<<<<
            newRate.UnitPriceKind = "1"; // 単価種類
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------>>>>>
            //newRate.RateSettingDivide = "A4"; // 掛率設定区分
            newRate.RateSettingDivide = "4A"; // FIXME:掛率設定区分←（※このメソッドの外でセット）
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------<<<<<
            newRate.RateMngGoodsCd = "A"; // 掛率設定区分（商品）
            newRate.RateMngGoodsNm = "ﾒｰｶｰ＋品番"; // 掛率設定名称（商品）
            newRate.RateMngCustCd = "4"; // FIXME:掛率設定区分（得意先）←（※このメソッドの外でセット）
            newRate.RateMngCustNm = "得意先掛率グループ"; // FIXME:掛率設定名称（得意先）←（※このメソッドの外でセット）
            newRate.GoodsMakerCd = _goodsUnitData.GoodsMakerCd; // 商品メーカーコード
            newRate.GoodsNo = _goodsUnitData.GoodsNo; // 商品番号
            newRate.GoodsRateRank = string.Empty; // 商品掛率ランク
            newRate.GoodsRateGrpCode = 0; // 商品掛率グループコード
            newRate.BLGroupCode = 0; // BLグループコード
            newRate.BLGoodsCode = 0; // BL商品コード
            newRate.CustomerCode = 0; // 得意先コード
            newRate.CustRateGrpCode = 0; // FIXME:得意先掛率グループコード←（※このメソッドの外でセット）
            newRate.SupplierCd = 0; // 仕入先コード
            newRate.LotCount = 9999999.99; // ロット数
            newRate.PriceFl = 0; // 価格（浮動）←（※このメソッドの外でセット）
            newRate.RateVal = 0; // 掛率←（※このメソッドの外でセット）
            newRate.UpRate = 0; // UP率
            newRate.GrsProfitSecureRate = 0; // 粗利確保率
            newRate.UnPrcFracProcUnit = 1; // 単価端数処理単位 = 1
            newRate.UnPrcFracProcDiv = 2; // 単価端数処理区分 = 2:四捨五入
            # endregion

            return newRate;
        }

        /// <summary>
        /// InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns;

            #region 削除コード
            //// 一旦、全ての列を非表示にする。
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            //{
            //    //非表示設定
            //    column.Hidden = true;
            //}
            #endregion

            //string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatFl = "#,##0.00;-#,##0.00;''";
            //string rateFormatFl = "###0.00;-###0.00;''";

            #region 削除コード
            //// 列幅の自動調整方法
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            #endregion

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする >>>>>>START
            // 行レイアウト機能を有効
            this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].UseRowLayout = true;
            // 得意先掛率Ｇ名称を取得
            this.SetCustRateGrpName();
            // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする <<<<<<END
                
            int index = 0;
            
            // 全列同じ設定でＯＫ
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
	        {
                // --- ADD 2009/01/09 障害ID:9903対応------------------------------------------------------>>>>>
                //column.Header.Caption = index.ToString("00");
                column.Header.Caption = index.ToString("0000");
                // --- ADD 2009/01/09 障害ID:9903対応------------------------------------------------------<<<<<
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // TODO:得意先掛率グループコードの指定なしのカラム用に1列右にシフト
                int captionIndex = index - 1;
                column.Header.Caption = (captionIndex >= 0 ? captionIndex.ToString("d4") : ALL_RATE_GROUP_CAPTION);
                // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする >>>>>>START
                // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                //if (index < 20)
                // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                if (index < ct_RateGroupCount)  // ADD 2009/11/20 3次分対応 得意先掛率グループ改良
                {
                    column.RowLayoutColumnInfo.OriginY = 0;
                    column.RowLayoutColumnInfo.OriginX = index;
                    column.RowLayoutColumnInfo.SpanY = 1;
                    column.RowLayoutColumnInfo.SpanX = 1;
                }
                else
                {
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //int custRateGrpIdx = index - 20;
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // TODO:得意先掛率グループコードの指定なしのカラム用に1列右にシフト
                    int custRateGrpIdx = index - ct_RateGroupCount - 1;  // ADD 2009/11/20 3次分対応 得意先掛率グループ改良
                    // 2009.03.12 30413 犬飼 ガイドコードが未登録時の対応 >>>>>>START
                    //column.Header.Caption = this._custRateGrpNameDic[custRateGrpIdx];
                    column.Header.Caption = "";
                    if (this._custRateGrpNameDic.ContainsKey(custRateGrpIdx))
                    {
                        column.Header.Caption = this._custRateGrpNameDic[custRateGrpIdx];
                    }
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    else if (custRateGrpIdx < 0)
                    {
                        column.Header.Caption = this._custRateGrpNameDic[ALL_RATE_GROUP_CODE];
                    }
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // 2009.03.12 30413 犬飼 ガイドコードが未登録時の対応 <<<<<<END
                    column.RowLayoutColumnInfo.LabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.LabelOnly;
                    column.RowLayoutColumnInfo.OriginY = 1;
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    //column.RowLayoutColumnInfo.OriginX = custRateGrpIdx;
                    // DEL 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    column.RowLayoutColumnInfo.OriginX = index - ct_RateGroupCount;
                    // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                    column.RowLayoutColumnInfo.SpanY = 1;
                    column.RowLayoutColumnInfo.SpanX = 1;
                }
                // 2009.03.03 30413 犬飼 ヘッダーを得意先掛率Ｇのコードと名称2段とする <<<<<<END
                
                column.Hidden = false;
                column.Width = 120;
                column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                if ( _parentEnabled )
                {
                    column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                column.Format = moneyFormatFl;

                column.Header.VisiblePosition = index++;
	        }

            // 固定列区切り線設定
            this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// AfterPerformActionイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_UnitSalesPriceInfo.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_UnitSalesPriceInfo.ActiveCell.Value is System.DBNull))
                                        {
                                            //// 全選択状態にする。
                                            //this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart = 0;
                                            //this.uGrid_UnitSalesPriceInfo.ActiveCell.SelLength = this.uGrid_UnitSalesPriceInfo.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_Enter(object sender, EventArgs e)
        {
            if ( !_parentEnabled ) return;

            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null)
            {
                if (!this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_UnitSalesPriceInfo.ActiveCell == null))
                {
                    if (this.uGrid_UnitSalesPriceInfo.Rows.Count > 0)
                    {
                        this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[0].Cells[ct_Col_CustRateGrp_00];

                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }

            // グリッドセルアクティブ後発生イベント
            //this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());

        }

        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {
                    //// 仕入明細データテーブルRowStatus列初期化処理
                    //this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

                    //// 明細グリッドセル設定処理
                    //this.SettingGrid();
                }

                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_UnitSalesPriceInfo.ActiveCell = null;
                                this.uGrid_UnitSalesPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Clear();
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_UnitSalesPriceInfo.ActiveCell = null;
                                this.uGrid_UnitSalesPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Clear();
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                    }
                }
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                //if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
                                //{
                                //    ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_UnitSalesPriceInfo);
                                //}

                                break;
                            }
                    }
                }
                else
                {
                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.uGrid_UnitSalesPriceInfo.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart == 0)
                                            {
                                                // --- CHG 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                                //this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                                int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                                if (colIndex != 0)
                                                {
                                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                // --- CHG 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart >= this.uGrid_UnitSalesPriceInfo.ActiveCell.Text.Length)
                                            {
                                                // --- CHG 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                                //this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                                int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                                if (colIndex != 19)
                                                {
                                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                // --- CHG 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (!this.uGrid_UnitSalesPriceInfo.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                    // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                    else
                                    {
                                        int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                        int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                        e.Handled = true;
                                        this.uGrid_UnitSalesPriceInfo.Rows[rowIndex - 1].Cells[colIndex].Activate();
                                        this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<
                                }

                                break;
                            }
                        case Keys.Down:
                            {
                                // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                e.Handled = true;
                                // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<

                                if (this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index == this.uGrid_UnitSalesPriceInfo.Rows.Count - 1)
                                {
                                    // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                    //if (e.KeyCode == Keys.Down)
                                    //{
                                    //    if (this.GridKeyDownButtomRow != null)
                                    //    {
                                    //        this.GridKeyDownButtomRow(this, new EventArgs());
                                    //        e.Handled = true;
                                    //    }
                                    //}
                                    // --- DEL 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<
                                }
                                // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------>>>>>
                                else
                                {
                                    int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                    int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex + 1].Cells[colIndex].Activate();
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // --- ADD 2009/03/18 障害ID:12530対応------------------------------------------------------<<<<<
                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_UnitSalesPriceInfo.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_UnitSalesPriceInfo.ActiveRow;

                if (this.uGrid_UnitSalesPriceInfo.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
                else if (this.uGrid_UnitSalesPriceInfo.ActiveRow.Index == this.uGrid_UnitSalesPriceInfo.Rows.Count - 1)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            ////------------------------------------------------------------
            //// 価格開始日
            ////------------------------------------------------------------
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        DateTime dt = new DateTime();
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        dt = (DateTime)e.NewValue;
            //        // 価格開始日重複チェック
            //        if (this._goodsAcs.CheckRepeatPriceStartDate(dt))
            //        {
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                this.Name,
            //                "入力された日付は既に存在する為、入力できません。",
            //                -1,
            //                MessageBoxButtons.OK);

            //            this._beforeCellUpdateCancel = true;
            //            e.Cancel = true;
            //            return;
            //        }
            //        this._beforePriceStartDate = (DateTime)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforePriceStartDate = DateTime.MinValue;
            //    }
            //}
            ////------------------------------------------------------------
            //// 標準価格
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeListPrice = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeListPrice = 0;
            //    }
            //}
            ////------------------------------------------------------------
            //// 仕入率
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeStockRate = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeStockRate = 0;
            //    }
            //}
            ////------------------------------------------------------------
            //// 原単価
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeSalesUnitCost = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeSalesUnitCost = 0;
            //    }
            //}
        }

        /// <summary>
        /// AfterCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            //int rowNo = this._goodsPriceDataTable[cell.Row.Index].RowNo;
            int rowIndex = e.Cell.Row.Index;
            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = "";
                }
            }

            # region [入力変更されたセルの文字色を変える]
            bool valueChangeFlag = false;

            # region [valueChangeFlagの判定]
            int group = e.Cell.Column.Index;
            switch ( e.Cell.Row.Index )
            {
                // 売価率
                case 0:
                    {
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        group--;    // TODO:得意先掛率グループコードを調整
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        if ( _rateBufferDic.ContainsKey( group ) )
                        {
                            if ( _rateBufferDic[group].RateVal != (double)e.Cell.Value )
                            {
                                valueChangeFlag = true;
                            }
                        }
                        else
                        {
                            // ディクショナリ無→今回追加された
                            valueChangeFlag = true;
                        }
                    }
                    break;
                // 売価額
                case 1:
                    {
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        group--;    // TODO:得意先掛率グループコードを調整
                        // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        if ( _rateBufferDic.ContainsKey( group ) )
                        {
                            if ( _rateBufferDic[group].PriceFl != (double)e.Cell.Value )
                            {
                                valueChangeFlag = true;
                            }
                        }
                        else
                        {
                            // ディクショナリ無→今回追加された
                            valueChangeFlag = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            # endregion

            if ( valueChangeFlag )
            {
                // 入力変更を示す赤文字にする
                e.Cell.Appearance.ForeColor = Color.Red;
                e.Cell.Appearance.ForeColorDisabled = Color.Red;
            }
            else
            {
                // 文字色を戻す
                e.Cell.Appearance.ForeColor = SystemColors.WindowText;
                e.Cell.Appearance.ForeColorDisabled = SystemColors.WindowText;
            }
            # endregion

            #region 削除コード
            ////------------------------------------------------------------
            //// 価格開始日
            ////------------------------------------------------------------
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    DateTime dt = new DateTime();
            //    dt = (DateTime)e.Cell.Value;
            //    if (this._beforePriceStartDate != dt)
            //    {
            //        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

            //        this._goodsAcs.ClearInputInfo(rowNo); // 入力情報クリア
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
            //        this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理
            //    }
            //}
            ////------------------------------------------------------------
            //// 標準価格
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
            //{
            //    double listPrice = TStrConv.StrToDoubleDef(e.Cell.ToString(), 0);
            //    if (this._beforeListPrice != (double)e.Cell.Value)
            //    {
            //        // 計算原価率入力チェック
            //        if (this._goodsAcs.CheckInputCalcStockRate(rowNo))
            //        {
            //            // 計算原価率が入力されている場合、計算原価額再計算
            //            this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
            //            this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
            //            this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理
            //        }
            //    }
            //}
            ////------------------------------------------------------------
            //// 仕入率
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
            //{
            //    if (this._beforeStockRate != (double)e.Cell.Value)
            //    {
            //        this._goodsAcs.ClearCalcInfo(rowNo); // 算出情報クリア
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
            //        this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理
            //    }
            //}
            ////------------------------------------------------------------
            //// 原単価
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            //{
            //    if (this._beforeSalesUnitCost != (double)e.Cell.Value)
            //    {
            //        this._goodsAcs.ClearCalcInfo(rowNo); // 算出情報クリア
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
            //        this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理
            //    }
            //}

            //// 価格情報設定イベントコール
            //this.SettingGoodsPriceEventCall(rowNo);
            #endregion

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);
        }

        /// <summary>
        /// AfterRowActivateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_UnitSalesPriceInfo.ActiveRow;

            //// 価格情報設定イベントコール
            //this.SettingGoodsPriceEventCall(this.GetActiveRowRowNo());

            // グリッドセル設定処理
            this.SettingGridRow(this.GetActiveRowIndex());
        }

        /// <summary>
        /// CellDataErrorイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_UnitSalesPriceInfo.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType);
                            this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }
        /// <summary>
        /// グリッド脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_Leave( object sender, EventArgs e )
        {
            // 脱出後にフォーカス解除する
            if ( uGrid_UnitSalesPriceInfo.ActiveCell != null )
            {
                uGrid_UnitSalesPriceInfo.ActiveCell.Selected = false;
                uGrid_UnitSalesPriceInfo.ActiveCell = null;
                uGrid_UnitSalesPriceInfo.Invalidate();
            }
        }
        /// <summary>
        /// 入力可・不可制御設定
        /// </summary>
        /// <param name="enabled"></param>
        public void SettingEnabled( bool enabled )
        {
            _parentEnabled = enabled;
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns;

            try
            {
                if ( enabled )
                {
                    foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns )
                    {
                        column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
                else
                {
                    foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns )
                    {
                        column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// グリッド内キープレスイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_KeyPress( object sender, KeyPressEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid_UnitSalesPriceInfo.ActiveCell;

            switch ( cell.Row.Index )
            {
                // 売価率
                case 0:
                    {
                        if ( cell.IsInEditMode )
                        {
                            if ( !CheckMatchingSetRate( e, cell ) )
                            {
                                // イベントキャンセルする
                                e.Handled = true;
                            }
                        }
                    }
                    break;
                // 売価額
                case 1:
                    {
                        if ( cell.IsInEditMode )
                        {
                            if ( !CheckMatchingSetPrice( e, cell ) )
                            {
                                // イベントキャンセルする
                                e.Handled = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 売価率入力キープレスチェック
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool CheckMatchingSetRate( KeyPressEventArgs e, Infragistics.Win.UltraWinGrid.UltraGridCell cell )
        {
            return KeyPressNumCheck( 6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false );
        }
        /// <summary>
        /// 売価額入力キープレスチェック
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool CheckMatchingSetPrice( KeyPressEventArgs e, Infragistics.Win.UltraWinGrid.UltraGridCell cell )
        {
            return KeyPressNumCheck( 12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false );
        }
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck( int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg )
        {
            // 制御キーが押された？
            if ( Char.IsControl( key ) )
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if ( !Char.IsDigit( key ) )
            {
                // 小数点または、マイナス以外
                if ( (key != '.') && (key != '-') )
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if ( sellength > 0 )
            {
                _strResult = prevVal.Substring( 0, selstart ) + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if ( key == '-' )
            {
                if ( (minusFlg == false) || (selstart > 0) || (_strResult.IndexOf( '-' ) != -1) )
                {
                    return false;
                }
            }

            // 小数点のチェック
            if ( key == '.' )
            {
                if ( (priod <= 0) || (_strResult.IndexOf( '.' ) != -1) )
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring( 0, selstart )
                + key
                + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );

            // 桁数チェック！
            if ( _strResult.Length > keta )
            {
                if ( _strResult[0] == '-' )
                {
                    if ( _strResult.Length > (keta + 1) )
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if ( priod > 0 )
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf( '.' );

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    if ( _pointPos > _Rketa )
                    {
                        return false;
                    }
                }
                else
                {
                    if ( _strResult.Length > _Rketa )
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if ( priod < _priketa )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 得意先掛率Ｇ名称の取得
        /// </summary>
        /// <returns></returns>
        private void SetCustRateGrpName()
        {
            int status = -1;
            
            UserGuideAcs userGuideAcs = new UserGuideAcs();
            ArrayList retList;

            this._custRateGrpNameDic = new Dictionary<int, string>();

            // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // 得意先掛率グループコードの指定なし
            this._custRateGrpNameDic.Add(ALL_RATE_GROUP_CODE, ALL_RATE_GROUP_CODE_NAME);
            // ADD 2009/11/20 3次分対応 得意先掛率グループ改良 ----------<<<<<

            // 得意先掛率Ｇ名称の取得
            status = userGuideAcs.SearchDivCodeBody(out retList, LoginInfoAcquisition.EnterpriseCode, 43, UserGuideAcsData.UserBodyData);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach(UserGdBd userGdBd in retList)
                {
                    if (!this._custRateGrpNameDic.ContainsKey(userGdBd.GuideCode))
                    {
                        this._custRateGrpNameDic.Add(userGdBd.GuideCode, userGdBd.GuideName);
                    }
                }
            }
        }
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 標準価格選択画面
// プログラム概要   : 部品検索結果データセットから画面表示を行い、選択された定価を反映させる。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/10/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/11/13  修正内容 : redmine#1266  初期フォーカス位置の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/11/16  修正内容 : redmine#1320  初期表示の修正
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李侠
// 修 正 日  2010/02/04    修正内容 : PM1003・四次改良 ESCボタンで画面を終了する
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 修 正 日  2010/04/13  修正内容 : カタログ部品≠最新部品の場合に、最新部品の定価を採用する(MANTIS[0015276])
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 20056  對馬 大輔
// 修 正 日  2010/04/27  修正内容 : カーメーカーと部品メーカーの比較処理でカーメーカー変換を行う(MANTIS[0015344])
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 22018  鈴木 正臣
// 修 正 日  2010/07/27  修正内容 : 車輌未検索で品番入力時にメーカー変換処理でエラー発生する件の修正
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 修 正 日  2010/11/01  修正内容 : ①右端に表示されているボタンでTab押下時、フォーカスが消える不具合を修正(MANTIS[0016549])
//                                 ②Windowsタスクバーに画面が表示される不具合の修正(MANTIS[0016550])
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 22018　鈴木 正臣
// 修 正 日  2011/01/19  修正内容 : 標準価格選択UIに古いｶﾀﾛｸﾞ品番が表示される件の対応
//                                 (PM7と同様のチェック処理を追加する。)(MANTIS[0016928])
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 22018　鈴木 正臣
// 修 正 日  2011/02/17  修正内容 : 標準価格ゼロでユーザー商品マスタに無い結合元は対象外に変更。(PM7準拠)
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 22018　鈴木 正臣
// 修 正 日  2011/02/25  修正内容 : カーメーカーに合致する純正メーカーの行が１つも無い場合は優良で確定するよう変更。(PM7準拠)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 修 正 日  2011/06/08  修正内容 : 自由検索部品登録により、一度のBLコード検索で複数回同一の純正品が選択されたときの不具合修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/11/24  修正内容 : redmine#8034、外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 鄧潘ハン 						
// 修 正 日  2012/04/06  修正内容 : 2012/05/24配信分、Redmine#29297　 						
//                                  標準価格選択画面の純正品番の表示についての修正					
//----------------------------------------------------------------------------// 	
// 管理番号  10801804-00 作成担当 : 鄧潘ハン 						
// 修 正 日  2012/04/06  修正内容 : 2012/05/24配信分、Redmine#29153 						
//                                  標準価格選択画面が表示されないについての修正					
//----------------------------------------------------------------------------// 					
// 管理番号  10801804-00 作成担当 : gezh 						
// 修 正 日  2012/06/11  修正内容 : Redmine#30392 売上伝票入力 標準価格選択表示の対応					
//----------------------------------------------------------------------------// 
// 管理番号              作成担当 : 凌小青 						
// 修 正 日   2012/06/26 修正内容 : Redmine#30595 売上伝票入力標準価格選択ガイドの修正				
//----------------------------------------------------------------------------// 						
// 管理番号  10806792-00 作成担当 : 脇田 靖之 						
// 修 正 日  2012/12/27  修正内容 : 自社品番印字対応				
//----------------------------------------------------------------------------// 						
// 管理番号  10806792-00 作成担当 : 脇田 靖之 						
// 修 正 日  2013/01/16  修正内容 : 自社品番印字対応仕様変更対応				
//----------------------------------------------------------------------------// 						
// 管理番号  11070100-00 作成担当 : 宮本 利明
// 修 正 日  2014/06/16  修正内容 : LDNS #37904 対応分(2014/05/16)をマージ
//----------------------------------------------------------------------------// 						
// 管理番号  11070149-00 作成担当 : 30757 佐々木 貴英
// 修 正 日  2015/04/06  修正内容 : 仕掛№2405 得意先変更時表示区分再取得対応
//----------------------------------------------------------------------------// 						
						

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

// --- ADD 2012/12/27 Y.Wakita ---------->>>>>
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
// --- ADD 2012/12/27 Y.Wakita ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 標準価格選択画面フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 標準価格選択画面フォームクラスです。</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2009/10/19</br>
    /// <br>Update Note : 李占川 2009/11/13</br>
    /// <br>            : redmine#1266  初期フォーカス位置の修正</br>
    /// <br>Update Note : 李占川 2009/11/16</br>
    /// <br>            : redmine#1320  初期表示の修正</br>
    /// <br>Update Note : 2010/02/04 李侠</br>
    /// <br>            : PM1003・四次改良 ESCボタンで画面を終了する</br>
    /// <br></br>
    /// <br>Update Note : 2010/04/13　21024 佐々木 健</br>
    /// <br>            : カタログ部品≠最新部品の場合に、最新部品の定価を採用する(MANTIS[0015276])</br>
    /// <br>Update Note : 2010/04/27 20056 對馬 大輔</br>
    /// <br>            : カーメーカーと部品メーカーの比較処理でカーメーカー変換を行う(MANTIS[0015344])</br>
    /// <br>Update Note : 2010/07/27 22018 鈴木 正臣</br>
    /// <br>            : 車輌未検索で品番入力時にメーカー変換処理でエラー発生する件の修正</br>
    /// <br>Update Note : 2011/01/19 22018 鈴木 正臣</br>
    /// <br>            : 標準価格選択UIに古いｶﾀﾛｸﾞ品番が表示される件の対応(PM7と同様のチェック処理を追加する。)(MANTIS[0016928])</br>
    /// <br>Update Note : 2011/02/17 22018 鈴木 正臣</br>
    /// <br>            : 標準価格ゼロでユーザー商品マスタに無い結合元は対象外に変更。(PM7準拠)</br>
    /// <br>Update Note : 2011/02/25 22018 鈴木 正臣</br>
    /// <br>            : カーメーカーに合致する純正メーカーの行が１つも無い場合は優良で確定するよう変更。(PM7準拠)</br>
    /// <br>Update Note : 2011/06/08 22018 鈴木 正臣</br>
    /// <br>            : 自由検索部品登録により、一度のBLコード検索で複数回同一の純正品が選択されたときの不具合修正。</br>
    /// <br>Update Note : 2011/11/24 鄧潘ハン</br>
    /// <br>            : redmine#8034、外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
    /// <br>Update Note : 2012/04/06 鄧潘ハン</br>
    /// <br>管理番号    : 10801804-00 2012/05/24配信分</br>
    /// <br>              Redmine#29297   標準価格選択画面の純正品番の表示についての修正</br>
    /// <br>Update Note : 2012/04/06 鄧潘ハン</br>
    /// <br>管理番号    : 10801804-00 2012/05/24配信分</br>
    /// <br>              Redmine#29153   標準価格選択画面が表示されないについての修正</br>
    /// <br>Update Note : 2012/06/11 gezh</br>
    /// <br>管理番号    : 10801804-00 </br>
    /// <br>              Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
    /// <br>Update Note : 2012/06/26 凌小青</br>
    /// <br>              Redmine#30595 売上伝票入力標準価格選択ガイドの修正</br>
    /// <br>Update Note : 2015/04/06 30757 佐々木 貴英</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>              仕掛№2405 得意先変更時表示区分再取得対応</br>
    /// <br></br>
    /// </remarks>
    public partial class SelectionListPrice : Form
    {
        #region ■ コンストラクタ ■
        /// <summary>
        /// 標準価格選択画面UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 標準価格選択画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice()
        {
            InitializeComponent();

            //>>>2010/04/27
            this._changeMakerDic.Add(14, 4);
            this._changeMakerDic.Add(16, 6);
            this._changeMakerDic.Add(209, 9);
            this._changeMakerDic.Add(301, 1);
            //<<<2010/04/27
        }

        /// <summary>
        /// 標準価格選択画面UIクラスコンストラクタ(売上伝票入力用)
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="carInfo">車両検索結果データクラス</param>
        /// <param name="partsInfoDataSet">部品検索結果データセット</param>
        /// <param name="priceSelectDiv">表示区分</param>
        /// <remarks>
        /// <br>Note        : 標準価格選択画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice(int goodsMakerCode, string goodsNo, PMKEN01010E carInfo, PartsInfoDataSet partsInfoDataSet, int priceSelectDiv)
        {
            InitializeComponent();

            // 変数の設定
            this._goodsMakerCd = goodsMakerCode;
            this._goodsNo = goodsNo;
            this._partsInfo = partsInfoDataSet;
            this._carInfo = carInfo;
            this._priceSelectDiv = priceSelectDiv;
            this._startForm = 1;

            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            this._changeMakerDic.Add( 14, 4 );
            this._changeMakerDic.Add( 16, 6 );
            this._changeMakerDic.Add( 209, 9 );
            this._changeMakerDic.Add( 301, 1 );
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            // 画面内容初期化
            this.InitFormDate();

            // --- DEL m.suzuki 2011/02/25 ---------->>>>> // 画面初期化の↑に移動
            ////>>>2010/04/27
            //this._changeMakerDic.Add(14, 4);
            //this._changeMakerDic.Add(16, 6);
            //this._changeMakerDic.Add(209, 9);
            //this._changeMakerDic.Add(301, 1);
            ////<<<2010/04/27
            // --- UPD m.suzuki 2011/02/25 ----------<<<<<
        }

        /// <summary>
        /// 標準価格選択画面UIクラスコンストラクタ(検索見積用)
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsMakerName">メーカー名称</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsName">品名</param>
        /// <param name="priceTaxExc">標準価格(税抜)</param>
        /// <param name="partsInfoDataSet">部品検索結果データセット</param>
        /// <param name="priceSelectDiv">表示区分</param>
        /// <remarks>
        /// <br>Note        : 標準価格選択画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        public SelectionListPrice(int goodsMakerCode, string goodsMakerName, string goodsNo,
            string goodsName, double priceTaxExc, PartsInfoDataSet partsInfoDataSet, int priceSelectDiv)
        {
            InitializeComponent();

            // 変数の設定
            this._partsInfo = partsInfoDataSet;
            this._carInfo = partsInfoDataSet.SearchCarInfo;
            this._priceSelectDiv = priceSelectDiv;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsMakerNm = goodsMakerName;
            this._goodsMakerCd = goodsMakerCode;
            this._priceTaxExc = priceTaxExc;
            this._startForm = 2;

            // 画面内容初期化
            this.InitFormDate();

            //>>>2010/04/27
            this._changeMakerDic.Add(14, 4);
            this._changeMakerDic.Add(16, 6);
            this._changeMakerDic.Add(209, 9);
            this._changeMakerDic.Add(301, 1);
            //<<<2010/04/27
        }
        #endregion

        #region ■ private定数 ■
        // 1:優良
        private const int PRICE_SELECT_DIV1 = 0;
        // 2:純正
        private const int PRICE_SELECT_DIV2 = 1;
        // 3:高い方/3:高い方(1:N)
        private const int PRICE_SELECT_DIV3 = 2;
        // 4:高い方(1:1)
        private const int PRICE_SELECT_DIV4 = 3;
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>拠点コード(全体)</summary>
        private const string ctSectionCode = "00";
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        #endregion

        #region ■ private変数 ■
        int _goodsMakerCd = 0;
        string _goodsMakerNm = string.Empty;
        string _goodsNo = string.Empty;
        string _goodsName = string.Empty;
        double _priceTaxExc = 0;

        // 部品検索結果データセット
        PartsInfoDataSet _partsInfo;
        // 車両検索結果データクラス
        PMKEN01010E _carInfo;
        // 標準価格選択区分
        int _priceSelectDiv = PRICE_SELECT_DIV1;
        int _startForm = 1;
        int _startMode = 2;
        int _getDataMode = 1;

        private PartsDataSet _priceParts = null;
        private PartsDataSet.PrmPartsInfoDataTable _prmPartsInfoTable = null;
        private PartsDataSet.ClgPartsInfoDataTable _clgPartsInfoTable = null;

        private List<UltraGridRow> selectedRows = new List<UltraGridRow>();

        bool _startPriceFlag = false;
        bool _parten9 = true;

        UltraGridRow _beforeSelectedRow;

        Dictionary<int, int> _changeMakerDic = new Dictionary<int, int>(); // 2010/04/27
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        private SalesTtlSt _salesTtlSt = null;  // 売上全体設定マスタ

        int _goodsMakerCd2 = 0;                 // 標準価格選択のメーカーコード(下段)
        string _goodsMakerNm2 = string.Empty;   // 標準価格選択のメーカー名称(下段)
        string _goodsNo2 = string.Empty;        // 標準価格選択の品番(下段)
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
        /// <summary>
        /// タイトル追加文字列
        /// </summary>
        string _addTitleCaption = string.Empty;

        /// <summary>
        /// 選択純正品番
        /// </summary>
        string _srcGoodsNo = string.Empty;
        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
        #endregion

        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
        #region ■ Public Property ■
        /// <summary>
        /// タイトル追加文字列の取得と設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br>Programmer  : 30757 佐々木 貴英</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public string AddTitleCaption
        {
            get
            {
                return this._addTitleCaption;
            }
            set
            {
                this._addTitleCaption = value;
            }
        }

        /// <summary>
        /// 選択純正品メーカーコードの取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br>Programmer  : 30757 佐々木 貴英</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public int SrcGoodsMakerCode
        {
            get
            {
                return this._goodsMakerCd2;
            }
        }

        /// <summary>
        /// 選択純正品番の取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br>Programmer  : 30757 佐々木 貴英</br>
        /// <br>Date        : 2015/04/06</br>
        /// </remarks>
        public string SrcGoodsNo
        {
            get
            {
                return this._srcGoodsNo;
            }
        }
        #endregion //■ Public Property ■
        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<

        #region ■ コントロールイベント ■
        /// <summary>
        /// グリッド初期レイアウト設定イベント(上段)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_PrmPartsInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;

            this.ultraGrid_PrmPartsInfo.Enabled = false;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_PrmPartsInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // ヘッダクリックアクションの設定(ソート処理)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // 行フィルター設定
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 複数行選択可
            editBand.Layout.Override.SelectTypeRow = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.PrmPartsInfoDataTable table = this._prmPartsInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // グリッド列表示非表示設定処理
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            columns[table.PriceTaxExcColumn.ColumnName].Hidden = false;

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "メーカー";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            columns[table.PriceTaxExcColumn.ColumnName].Header.Caption = "標準価格";

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.PriceTaxExcColumn.ColumnName].CellActivation = Activation.NoEdit;

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 180;
            columns[table.GoodsNoColumn.ColumnName].Width = 130;
            columns[table.GoodsNameColumn.ColumnName].Width = 205;
            columns[table.PriceTaxExcColumn.ColumnName].Width = 120;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.PriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // フォーマット設定
            //--------------------------------------
            columns[table.PriceTaxExcColumn.ColumnName].Format = "#,##0";
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント(下段)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // ヘッダクリックアクションの設定(ソート処理)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // 行フィルター設定
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 複数行選択可
            editBand.Layout.Override.SelectTypeRow = SelectType.None;
            editBand.Layout.Override.SelectTypeCol = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.ClgPartsInfoDataTable table = this._clgPartsInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // グリッド列表示非表示設定処理
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }
            columns[table.NoColumn.ColumnName].Hidden = false;
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            columns[table.PriceTaxExcColumn.ColumnName].Hidden = false;

            // 行番号列のみセル表示色変更
            columns[table.NoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[table.NoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[table.NoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[table.NoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            columns[table.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[table.NoColumn.ColumnName].Header.Caption = "No";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "メーカー";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            columns[table.PriceTaxExcColumn.ColumnName].Header.Caption = "標準価格";

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.GoodsNameColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.PriceTaxExcColumn.ColumnName].CellActivation = Activation.NoEdit;

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[table.NoColumn.ColumnName].Width = 30;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 150;
            columns[table.GoodsNoColumn.ColumnName].Width = 130;
            columns[table.GoodsNameColumn.ColumnName].Width = 205;
            columns[table.PriceTaxExcColumn.ColumnName].Width = 120;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.PriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // フォーマット設定
            //--------------------------------------
            columns[table.PriceTaxExcColumn.ColumnName].Format = "#,##0";

            //--------------------------------------
            // クリック時動作制御
            //--------------------------------------
            columns[table.NoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsMakerNmColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.GoodsNameColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
            columns[table.PriceTaxExcColumn.ColumnName].CellClickAction = CellClickAction.RowSelect;
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ---DEL 鄧潘ハン　2014/05/16 ------------------------------------>>>>>
            //switch (e.PrevCtrl.Name)
            //{
            //    // 選択番号
            //    case "tEdit_SelectNo":
            //        {
            //            // 選択にフォーカスがある状態で[Enter]キーを入力した場合
            //            if (e.Key == Keys.Enter)
            //            {
            //                string selectNo = this.tEdit_SelectNo.Text;

            //                if (this._getDataMode == 2 || this._getDataMode == 4)
            //                {
            //                    if (Int32.Parse(selectNo) > this._clgPartsInfoTable.Count)
            //                    {
            //                        e.NextCtrl = this.tEdit_SelectNo;
            //                        this.tEdit_SelectNo.Text = "1";
            //                        return;
            //                    }

            //                    int rowNo = Int32.Parse(selectNo) - 1;

            //                    // 行は選択不可のチェック
            //                    if (!this.CheckRowMaker(this.ultraGrid_ClgPartsInfo.Rows[rowNo]))
            //                    {
            //                        e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                        this._beforeSelectedRow.Selected = true;
            //                        this._beforeSelectedRow.Activate();
            //                        return;
            //                    }

            //                    this.ultraGrid_ClgPartsInfo.Rows[rowNo].Selected = true;

            //                    this.selectedRows.Clear();
            //                    this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[rowNo]);

            //                    // 明細グリッド・行単位でのセルColor設定
            //                    this.SetSelectedRowColor();

            //                    e.NextCtrl = this.tEdit_SelectNo;

            //                    // 2:純正
            //                    if (this._getDataMode == 2)
            //                    {
            //                        DialogResult = this.ClgOKButtonClickProc();
            //                    }
            //                    // 4:高い方(1:1) 
            //                    else
            //                    {
            //                        DialogResult = this.Higher1to1ButtonClickProc();
            //                    }
            //                }
            //                else
            //                {
            //                    EventArgs eventArgs = new EventArgs();

            //                    // BLコード検索モード
            //                    if (this._startMode == 1)
            //                    {
            //                        switch (selectNo)
            //                        {
            //                            // 1:優良
            //                            case "1":
            //                                {
            //                                    this.Prm_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 2:純正
            //                            case "2":
            //                                {
            //                                    this.Clg_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 3:高い方
            //                            case "3":
            //                                {
            //                                    this.Higher_1toN_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            default:
            //                                {
            //                                    e.NextCtrl = this.tEdit_SelectNo;
            //                                    this.tEdit_SelectNo.Text = "1";
            //                                    break;
            //                                }
            //                        }
            //                    }
            //                    // 品番検索モード
            //                    else
            //                    {
            //                        switch (selectNo)
            //                        {
            //                            // 1:優良
            //                            case "1":
            //                                {
            //                                    this.Prm_OK_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 2:純正
            //                            case "2":
            //                                {
            //                                    this.Clg_OK_Button_Click(sender, eventArgs);
            //                                    e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                                    break;
            //                                }
            //                            // 3:高い方(1:N)
            //                            case "3":
            //                                {
            //                                    this.Higher_1toN_Button_Click(sender, eventArgs);
            //                                    break;
            //                                }
            //                            // 4:高い方(1:1) 
            //                            case "4":
            //                                {
            //                                    this.Higher_1to1_Button_Click(sender, eventArgs);
            //                                    e.NextCtrl = this.ultraGrid_ClgPartsInfo;
            //                                    break;
            //                                }
            //                            default:
            //                                {
            //                                    e.NextCtrl = this.tEdit_SelectNo;
            //                                    this.tEdit_SelectNo.Text = "1";
            //                                    break;
            //                                }
            //                        }
            //                    }
            //                }
            //            }
            //            break;
            //        }
            //}
            // ---DEL 鄧潘ハン　2014/05/16 ------------------------------------<<<<<

            // ---ADD 鄧潘ハン　2014/05/16 ------------------------------------>>>>>
            switch (e.PrevCtrl.Name)
            {
                // 標準価格選択(下段)
                case "ultraGrid_ClgPartsInfo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Enter)
                            {
                                // 選択番号
                                e.NextCtrl = this.tEdit_SelectNo;
                            }
                        }
                        else
                        {
                           
                            if (Higher_1to1_Button.Visible == true
                                && Higher_1to1_Button.Enabled == true)
                            {
                                // 4：高い方(1：1)
                                e.NextCtrl = this.Higher_1to1_Button;
                            }
                            else if (Higher_1toN_Button.Visible == true
                                && Higher_1toN_Button.Enabled == true)
                            {
                                // 3：高い方(1：N)
                                e.NextCtrl = this.Higher_1toN_Button;
                            }
                            else if (Clg_OK_Button.Visible == true
                            && Clg_OK_Button.Enabled == true)
                            {
                                // 2：純正
                                e.NextCtrl = this.Clg_OK_Button;
                            }
                            else if (Prm_OK_Button.Visible == true
                            && Prm_OK_Button.Enabled == true)
                            {
                                // 1：優良
                                e.NextCtrl = this.Prm_OK_Button;
                            }
                        }
                       
                        break;
                    }
            }
            // ---ADD 鄧潘ハン　2014/05/16 ------------------------------------<<<<<

            if (e.Key == Keys.Right || e.Key == Keys.Left)
            {
                switch (e.NextCtrl.Name)
                {
                    // 1：優良
                    case "Prm_OK_Button":
                        {
                            this.tEdit_SelectNo.Text = "1";
                            break;
                        }
                    // 2：純正
                    case "Clg_OK_Button":
                        {
                            if (this._getDataMode == 1)
                            {
                                this.tEdit_SelectNo.Text = "2";
                            }
                            break;
                        }
                    // 3：高い方(1：N)
                    case "Higher_1toN_Button":
                        {
                            this.tEdit_SelectNo.Text = "3";
                            break;
                        }
                    // 4：高い方(1：1)
                    case "Higher_1to1_Button":
                        {
                            if (this._getDataMode == 1)
                            {
                                this.tEdit_SelectNo.Text = "4";
                            }
                            break;
                        }
                }
            }
            else if (e.Key == Keys.Up || e.Key == Keys.Down)
            {
                e.NextCtrl = this.tEdit_SelectNo;
            }
        }

        /// <summary>
        /// [1:優良]ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: [1:優良]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Prm_OK_Button_Click(object sender, EventArgs e)
        {
            this.SetButtonEnable(PRICE_SELECT_DIV1);

            this.PrmOKButtonClickProc();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// [2:純正]ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: [2:純正]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Clg_OK_Button_Click(object sender, EventArgs e)
        {
            this._getDataMode = 2;

            if (this._clgPartsInfoTable.Rows.Count > 1)
            {
                this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0].Layout.Override.SelectTypeRow = SelectType.Single;

                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Focus();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.ultraGrid_ClgPartsInfo.Rows[0].Activate();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                // 明細グリッド・行単位でのセルColor設定
                this.SetSelectedRowColor();

                this.SetButtonEnable(PRICE_SELECT_DIV2);
            }
            else
            {
                this.selectedRows.Clear();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                DialogResult = this.ClgOKButtonClickProc();
            }
        }

        /// <summary>
        /// [3:高い方(1:N)]ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: [3:高い方(1:N)]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : 2010/02/04 李侠</br>
        /// <br>              PM1003・四次改良</br>
        /// <br>              ESCボタンで画面を終了する</br> 
        /// </remarks>
        private void Higher_1toN_Button_Click(object sender, EventArgs e)
        {
            this.SetButtonEnable(PRICE_SELECT_DIV3);
            // --- UPD 2010/02/04 ---------->>>>>
            //ESCボタンで画面を終了する
            //this.Higher1toNButtonClickProc();
            //DialogResult = DialogResult.OK;
            DialogResult = this.Higher1toNButtonClickProc();
            // --- UPD 2010/02/04 ----------<<<<<
        }

        /// <summary>
        /// [4:高い方(1:1)]ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: [4:高い方(1:1)]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void Higher_1to1_Button_Click(object sender, EventArgs e)
        {
            this._getDataMode = 4;

            if (this._clgPartsInfoTable.Rows.Count > 1)
            {
                this.ultraGrid_ClgPartsInfo.DisplayLayout.Bands[0].Layout.Override.SelectTypeRow = SelectType.Single;

                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Focus();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.ultraGrid_ClgPartsInfo.Rows[0].Activate();
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                // 明細グリッド・行単位でのセルColor設定
                this.SetSelectedRowColor();

                this.SetButtonEnable(PRICE_SELECT_DIV4);
            }
            else
            {
                this.selectedRows.Clear();
                this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                DialogResult = this.Higher1to1ButtonClickProc();
            }
        }

        /// <summary>
        /// 選択行変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 選択行変更を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (this.ultraGrid_ClgPartsInfo.Selected.Rows.Count == 0)
            {
                return;
            }

            this._beforeSelectedRow = this.ultraGrid_ClgPartsInfo.Selected.Rows[0];

            this.selectedRows.Clear();
            this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Selected.Rows[0]);

            // 明細グリッド・行単位でのセルColor設定
            this.SetSelectedRowColor();

            this.tEdit_SelectNo.Text = Convert.ToString(this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Index + 1);

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 標準価格選択のメーカーコード(下段)
            _goodsMakerCd2 = Int32.Parse(this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[1].Text);
            // 標準価格選択のメーカー名称(下段)
            _goodsMakerNm2 = this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[2].Text;
            // 標準価格選択の品番(下段)
            _goodsNo2 = this.ultraGrid_ClgPartsInfo.Selected.Rows[0].Cells[3].Text;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// グリッドマウスDouleクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドマウスDouleクリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            // 選択がない場合、処理しない
            if (selectedRows.Count == 0)
            {
                return;
            }

            // 選択行
            UltraGridRow activeRow = this.selectedRows[0];

            // 行は選択不可のチェック
            if (!this.CheckRowMaker(activeRow))
            {
                return;
            }

            if (this._getDataMode == 2)
            {
                DialogResult = this.ClgOKButtonClickProc();
            }
            else if (this._getDataMode == 4)
            {
                DialogResult = this.Higher1to1ButtonClickProc();
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : Leave時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void ultraGrid_ClgPartsInfo_Leave(object sender, EventArgs e)
        {
            this.ultraGrid_ClgPartsInfo.ActiveCell = null;
            this.ultraGrid_ClgPartsInfo.ActiveRow = null;
            this.ultraGrid_ClgPartsInfo.Selected.Rows.Clear();
        }
        #endregion

        #region ■ privateメソッド ■
        /// <summary>
        /// 画面内容初期化
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化時、初期データ設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitFormDate()
        {
            // 起動モードをセット
            // 売上伝票入力用
            if (this._startForm == 1)
            {
                // 1以下
                if ((int)this._partsInfo.SearchCondition.SearchFlg <= 1)
                {
                    // BLコード検索モード
                    this._startMode = 1;
                }
                // 2以上
                else
                {
                    // 品番検索モード
                    this._startMode = 2;
                }
            }
            // 検索見積用
            else
            {
                // 品番検索モード
                this._startMode = 2;
            }

            // 画面SIZE初期化
            this.InitializeForm(this._startMode);
            // 画面Button初期化
            this.InitializeFormButton(this._startMode);
            // 初期画面データ設定
            this.InitializeData(this._startMode);
            // 各ボタンの有効／無効の制御処理
            this.SetButtonEnable(this._priceSelectDiv);

            // フォーカスの設定
            this.tEdit_SelectNo.Focus();
            this.ActiveControl = this.tEdit_SelectNo;
        }

        /// <summary>
        /// 画面SIZE初期化
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化時、画面SIZE設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitializeForm(int startMode)
        {
            if (startMode == 1)
            {
                // 選択番号の位置
                //this.tEdit_SelectNo.Location = new System.Drawing.Point(480, 25);// DEL 2014/05/16 鄧潘ハン
                // -----ADD 2014/05/16 鄧潘ハン----->>>>>
                panel_Left.Width = 480;
                panel_Right.Width = 196;
                // -----ADD 2014/05/16 鄧潘ハン-----<<<<<
            }
            else
            {
                // 選択番号の位置
                //this.tEdit_SelectNo.Location = new System.Drawing.Point(598, 25);// DEL 2014/05/16 鄧潘ハン
                // -----ADD 2014/05/16 鄧潘ハン----->>>>>
                panel_Left.Width = 598;
                panel_Right.Width = 78;
                // -----ADD 2014/05/16 鄧潘ハン-----<<<<<
            }
        }

        /// <summary>
        /// 画面Button初期化
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化時、画面Button設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private void InitializeFormButton(int startMode)
        {
            if (startMode == 1)
            {
                this.Higher_1to1_Button.Visible = false;

                this.Higher_1toN_Button.Text = "3：高い方";
            }
            else
            {
                this.Higher_1to1_Button.Visible = true;

                this.Higher_1toN_Button.Text = "3：高い方(1：N)";
            }
        }

        /// <summary>
        /// 初期画面データ設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : 李占川 2009/11/16</br>
        /// <br>            : redmine#1320,初期表示の修正</br>
        /// <br>Update Note : 鄧潘ハン 2011/11/24</br>
        /// <br>            : redmine#8034,外車データの部品検索で標準価格選択の品番表示で元品番が表示されるの修正</br>
        /// <br>Update Note: 2012/04/06 鄧潘ハン</br>
        /// <br>管理番号   ：10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29297   標準価格選択画面の純正品番の表示についての修正</br>
        /// <br>Update Note: 2012/04/06 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29153   標準価格選択画面が表示されないについての修正</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
        /// </remarks> 
        private void InitializeData(int startMode)
        {
            string goodsNoForEstimate = ""; // ADD 鄧潘ハン 2011/11/24 Redmine#8034
            this._priceParts = new PartsDataSet();
            this._prmPartsInfoTable = this._priceParts.PrmPartsInfo;
            this._clgPartsInfoTable = this._priceParts.ClgPartsInfo;
            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            bool existsMatchMaker = false;
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            //PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = this._partsInfo.UsrGoodsInfo.RowToProcess; //DEL 鄧潘ハン 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = this._partsInfo.UsrGoodsInfo.RowToProcess; //ADD 凌小青 on 2012/06/26 for Redmine#30595

            // BLコード検索モード
            if (startMode == 1)
            {
                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // BLコード検索ならばチェック不要なのでOK扱いする
                existsMatchMaker = true;
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // Gridののセット内容
                foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                {
                    //---ADD 凌小青 on 2012/06/26 for Redmine#30595---->>>>>
                    if (rowToProcess.GoodsNo != selInfo.RowGoods.GoodsNo)
                    {
                        continue;
                    }
                    //---ADD 凌小青 on 2012/06/26 for Redmine#30595----<<<<<
                    //---DEL 鄧潘ハン 2012/04/06 Redmine#29153---->>>>>
                    //------------ADD 2009/11/30--------->>>>>
                    //if (rowToProcess.GoodsNo != selInfo.RowGoods.GoodsNo)
                    //{
                    //    continue;
                    //}
                    //------------ADD 2009/11/30---------<<<<<
                    //---DEL 鄧潘ハン 2012/04/06 Redmine#29153----<<<<<

                    // 部品選択で選択された一覧の品番
                    string goodsNo = string.Empty;
                    // NewGoodsNoがstring.Empty場合
                    if (selInfo.RowGoods.NewGoodsNo.Equals(string.Empty))
                    {
                        goodsNo = selInfo.RowGoods.GoodsNo;
                    }
                    else
                    {
                        goodsNo = selInfo.RowGoods.NewGoodsNo;
                    }

                    // --- ADD 2009/11/16 ---------->>>>>
                    // 部品選択で選択されていない場合(選択部品が１件で部品選択画面が表示されない場合)
                    // this._partsInfo.ListSelectionInfo.Values は１件となる為、
                    // 同一項目でチェックを行い、無条件で対象とする。
                    // 2010/04/13 >>>
                    //string goodsNoSel = this._partsInfo.GoodsNoSel;
                    string goodsNoSel = selInfo.SelectedPartsNo;
                    // 2010/04/13 <<<
                    if (goodsNoSel.Equals(string.Empty))
                    {
                        goodsNoSel = goodsNo;
                    }
                    // --- ADD 2009/11/16 ----------<<<<<

                    // 部品選択で選択された品番 == 部品選択で選択された一覧の品番
                    //if (this._partsInfo.GoodsNoSel == goodsNo) // DEL 2009/11/16
                    if (goodsNoSel == goodsNo) // ADD 2009/11/16
                    {
                        // 下段
                        PartsDataSet.ClgPartsInfoRow row = this._clgPartsInfoTable.NewClgPartsInfoRow();
                        row.No = 1;
                        row.GoodsMakerCode = selInfo.RowGoods.GoodsMakerCd;
                        row.GoodsMakerNm = selInfo.RowGoods.GoodsMakerNm;
                        row.GoodsNo = goodsNo; // UPD ADD 2009/11/30 
                        row.GoodsName = selInfo.RowGoods.GoodsName;
                        row.PriceTaxExc = selInfo.RowGoods.PriceTaxExc;

                        // 2010/04/13 >>>
                        // 最新品番を表示し、且つカタログ品番と異なる場合は、最新部品の定価を採用する
                        if (goodsNo == selInfo.RowGoods.NewGoodsNo && selInfo.RowGoods.GoodsNo != selInfo.RowGoods.NewGoodsNo)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow newPartsInfo = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(selInfo.RowGoods.GoodsMakerCd, goodsNo);
                            // 基本的にはありえない
                            if (row != null)
                            {
                                row.PriceTaxExc = newPartsInfo.PriceTaxExc;
                            }
                        }
                        // 2010/04/13 <<<
                        // --- UPD m.suzuki 2011/06/08 ---------->>>>>
                        //// --- ADD m.suzuki 2011/01/19 ---------->>>>>
                        //// 同一メーカー・同一標準価格は除外
                        //if ( ExistsSameMakerPrice( _clgPartsInfoTable, row.GoodsMakerCode, row.PriceTaxExc ) )
                        //{
                        //    continue;
                        //}
                        //// --- ADD m.suzuki 2011/01/19 ----------<<<<<
                        //
                        //// --- UPD m.suzuki 2011/02/17 ---------->>>>>
                        ////this._clgPartsInfoTable.AddClgPartsInfoRow(row);
                        //// 標準価格ゼロ以外または、ユーザー商品マスタに登録済みならば対象。
                        //// (但し対象外の場合も、優良の情報は必要なのでこれ以降の処理を行う)
                        //if ( row.PriceTaxExc != 0 ||
                        //     selInfo.RowGoods.UpdateDate != DateTime.MinValue )
                        //{
                        //    this._clgPartsInfoTable.AddClgPartsInfoRow( row );
                        //}
                        //// --- UPD m.suzuki 2011/02/17 ----------<<<<<
                        // 同一メーカー・同一標準価格は除外
                        if ( !ExistsSameMakerPrice( _clgPartsInfoTable, row.GoodsMakerCode, row.PriceTaxExc ) )
                        {
                            // 標準価格ゼロ以外または、ユーザー商品マスタに登録済みならば対象。
                            // (但し対象外の場合も、優良の情報は必要なのでこれ以降の処理を行う)
                            if ( row.PriceTaxExc != 0 ||
                                 selInfo.RowGoods.UpdateDate != DateTime.MinValue )
                            {
                                this._clgPartsInfoTable.AddClgPartsInfoRow( row );
                            }
                        }
                        // --- UPD m.suzuki 2011/06/08 ----------<<<<<

                        if (selInfo.ListChildGoods2.Count == 0)
                        {
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                            {
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    if (this._prmPartsInfoTable.Rows.Count == 0)
                                    {
                                        // 上段
                                        PartsDataSet.PrmPartsInfoRow row2 = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                                        row2.GoodsMakerCode = selInfo2.RowGoods.GoodsMakerCd;
                                        row2.GoodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                        row2.GoodsNo = selInfo2.RowGoods.GoodsNo;
                                        row2.GoodsName = selInfo2.RowGoods.GoodsName;
                                        row2.PriceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                        this._prmPartsInfoTable.AddPrmPartsInfoRow(row2);
                                    }

                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods2.Values)
                            {
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    if (this._prmPartsInfoTable.Rows.Count == 0)
                                    {
                                        // 上段
                                        PartsDataSet.PrmPartsInfoRow row2 = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                                        row2.GoodsMakerCode = selInfo2.RowGoods.GoodsMakerCd;
                                        row2.GoodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                        row2.GoodsNo = selInfo2.RowGoods.GoodsNo;
                                        row2.GoodsName = selInfo2.RowGoods.GoodsName;
                                        row2.PriceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                        this._prmPartsInfoTable.AddPrmPartsInfoRow(row2);
                                    }

                                    break;
                                }
                            }
                        }

                    }
                }

                // 選択番号
                this.tEdit_SelectNo.Text = "1";
            }
            // 品番検索モード
            else
            {
                int goodsMakerCd = 0;
                string goodsMakerNm = string.Empty;
                string goodsNo = string.Empty;
                string goodsName = string.Empty;
                double priceTaxExc = 0;

                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // カーメーカーコード取得(変換後)
                int carMaker = GetCarMakerCode();
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // 売上伝票入力用
                if (this._startForm == 1)
                {
                    foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                    {
                        // 優良品番検索を行った場合
                        //if (selInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                        if (selInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                        {
                            goodsMakerCd = selInfo.RowGoods.GoodsMakerCd;
                            goodsMakerNm = selInfo.RowGoods.GoodsMakerNm;
                            goodsNo = selInfo.RowGoods.GoodsNo;
                            goodsName = selInfo.RowGoods.GoodsName;
                            priceTaxExc = selInfo.RowGoods.PriceTaxExc;
                        }
                        else
                        {
                            // 純正品番検索を行った場合
                            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                            {
                                //------------UPD 2009/11/17--------->>>>>
                                if (selInfo2.RowGoods.GoodsNo == this._goodsNo)
                                {
                                    goodsMakerCd = selInfo2.RowGoods.GoodsMakerCd;
                                    goodsMakerNm = selInfo2.RowGoods.GoodsMakerNm;
                                    goodsNo = selInfo2.RowGoods.GoodsNo;
                                    goodsName = selInfo2.RowGoods.GoodsName;
                                    priceTaxExc = selInfo2.RowGoods.PriceTaxExc;
                                    break;
                                }
                                //------------UPD 2009/11/17---------<<<<<
                            }
                        }
                        break;
                    }
                }
                // 検索見積用
                else
                {
                    //---ADD 鄧潘ハン 2011/11/24 Redmine#8034-------------------->>>>>
                    foreach (SelectionInfo selInfo in this._partsInfo.ListSelectionInfo.Values)
                    {
                        if (selInfo.RowGoods.NewGoodsNo.Equals(string.Empty))
                        {
                            goodsNoForEstimate = this._goodsNo;
                        }
                        else
                        {
                            goodsNoForEstimate = selInfo.RowGoods.NewGoodsNo;
                        }
                    }
                    if (this._partsInfo.ListSelectionInfo.Values.Count == 0)
                    {
                        goodsNoForEstimate = this._partsInfo.GoodsNoSel;
                    }
                    //---ADD 鄧潘ハン 2011/11/24 Redmine#8034--------------------<<<<<
                    goodsMakerCd = this._goodsMakerCd;
                    goodsMakerNm = this._goodsMakerNm;
                    goodsNo = this._goodsNo;
                    goodsName = this._goodsName;
                    priceTaxExc = this._priceTaxExc;
                }

                // 上段
                PartsDataSet.PrmPartsInfoRow row = this._prmPartsInfoTable.NewPrmPartsInfoRow();
                row.GoodsMakerCode = goodsMakerCd;
                row.GoodsMakerNm = goodsMakerNm;
                row.GoodsNo = goodsNo;
                row.GoodsName = goodsName;
                row.PriceTaxExc = priceTaxExc;
                this._prmPartsInfoTable.AddPrmPartsInfoRow(row);

                //---ADD 鄧潘ハン 2012/04/06 Redmine#29297-------------------->>>>>
                List<PartsInfoDataSet.UsrGoodsInfoRow> usrGoodsInfoRows = new List<PartsInfoDataSet.UsrGoodsInfoRow>();

                foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in this._partsInfo.PartsInfoDataSetSrcParts.UsrGoodsInfo)
                {
                    usrGoodsInfoRows.Add(usrGoodsInfoRow);
                }

                DataToTarComparer TarData = new DataToTarComparer();
                //取得した純正部品を「メーカー」⇒「品番」の順でソートする、ソートはどちらも昇順(ASC)で行う。
                usrGoodsInfoRows.Sort(TarData);
                //---ADD 鄧潘ハン 2012/04/06 Redmine#29297--------------------<<<<<
                // 下段
                foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in usrGoodsInfoRows)//ADD 鄧潘ハン 2012/04/06 Redmine#29297
                //foreach (PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow in this._partsInfo.PartsInfoDataSetSrcParts.UsrGoodsInfo)//DEL 鄧潘ハン 2012/04/06 Redmine#29297
                {
                    // --- ADD m.suzuki 2011/01/19 ---------->>>>>
                    // 標準価格ゼロは除外
                    if ( usrGoodsInfoRow.PriceTaxExc == 0 )
                    {
                        continue;
                    }
                    // 同一メーカー・同一標準価格は除外
                    if ( ExistsSameMakerPrice( _clgPartsInfoTable, usrGoodsInfoRow.GoodsMakerCd, usrGoodsInfoRow.PriceTaxExc ) )
                    {
                        continue;
                    }
                    // --- ADD m.suzuki 2011/01/19 ----------<<<<<

                    PartsDataSet.ClgPartsInfoRow partsInfoRow = this._clgPartsInfoTable.NewClgPartsInfoRow();
                    partsInfoRow.GoodsMakerCode = usrGoodsInfoRow.GoodsMakerCd;
                    partsInfoRow.GoodsMakerNm = usrGoodsInfoRow.GoodsMakerNm;
                    partsInfoRow.GoodsNo = usrGoodsInfoRow.GoodsNo;
                    partsInfoRow.GoodsName = usrGoodsInfoRow.GoodsName;
                    partsInfoRow.PriceTaxExc = usrGoodsInfoRow.PriceTaxExc;

                    //---ADD 鄧潘ハン 2011/11/24 Redmine#8034-------------------------->>>>>
                    if (this._startForm != 1)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow newPartsInfo = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(usrGoodsInfoRow.GoodsMakerCd, goodsNoForEstimate);
                        // 基本的にはありえない
                        if (row != null && null != newPartsInfo)
                        {
                            partsInfoRow.PriceTaxExc = newPartsInfo.PriceTaxExc;
                            partsInfoRow.GoodsNo = goodsNoForEstimate;
                        }
                    }
                    //---ADD 鄧潘ハン 2011/11/24 Redmine#8034-------------------------<<<<<

                    this._clgPartsInfoTable.AddClgPartsInfoRow(partsInfoRow);

                    // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                    // カーメーカーに合致する行が１行でもあればOK
                    // (※カーメーカーの変換処理が有るので、CheckMakerメソッドを使用しない)
                    if ( carMaker <= 0 ||
                         usrGoodsInfoRow.GoodsMakerCd == carMaker )
                    {
                        existsMatchMaker = true;
                    }
                    // --- ADD m.suzuki 2011/02/25 ----------<<<<<
                }

                // 選択番号
                this.tEdit_SelectNo.Text = "1";
            }

            this._priceParts.AcceptChanges();
            this.ultraGrid_PrmPartsInfo.DataSource = this._prmPartsInfoTable.DefaultView;

            DataView dv = this._clgPartsInfoTable.DefaultView;
            // ソート順序「メーカーコード(昇順)・標準価格(昇順)」
            dv.Sort = "GoodsMakerCode, PriceTaxExc, GoodsNo";

            // Noの設定
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i][0] = i + 1;
            }
            this.ultraGrid_ClgPartsInfo.DataSource = dv;

            // --- ADD m.suzuki 2011/01/19 ---------->>>>>
            // 標準価格ゼロを除外した結果、
            // 下段グリッドに表示する純正がゼロ件になった場合は
            // 優良で確定する。
            if ( _clgPartsInfoTable.Rows.Count == 0 )
            {
                _priceSelectDiv = PRICE_SELECT_DIV1;
            }
            // --- ADD m.suzuki 2011/01/19 ----------<<<<<
            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            if ( !existsMatchMaker )
            {
                // 選択可能な行が１行もなければ優良で確定する。
                // (※カーメーカーに合致しない純正メーカーは選択不可の仕様)
                _priceSelectDiv = PRICE_SELECT_DIV1;
            }
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<
        }

        //---ADD 鄧潘ハン 2012/04/06 Redmine#29297-------------------->>>>>
        /// <summary>
        /// データソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データソート順処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2012/04/06</br>
        /// <br>管理番号   : 10801804-00 2012/05/24配信分　Redmine#29297　標準価格選択画面の純正品番の表示についての修正</br>
        /// </remarks>
        private class DataToTarComparer : IComparer<PartsInfoDataSet.UsrGoodsInfoRow>
        {
            public int Compare(PartsInfoDataSet.UsrGoodsInfoRow x, PartsInfoDataSet.UsrGoodsInfoRow y)
            {
                int ret = ComparerHelper.CompareObject(x.GoodsMakerCd, y.GoodsMakerCd);

                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.GoodsNo, y.GoodsNo);
                }
                return ret;
            }
        }

        /// <summary>
        /// Comparer処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : Comparer処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2012/04/06</br>
        /// <br>管理番号   : 10801804-00 2012/05/24配信分　Redmine#29297　標準価格選択画面の純正品番の表示についての修正</br>
        /// <br></br>
        /// </remarks>
        private class ComparerHelper
        {
            public static int CompareObject(object val1, object val2)
            {
                int a = 0;
                int b = 0;
                if (val1 == null && val2 == null)
                {
                    return 0;
                }
                else if (val1 != null && val2 != null)
                {
                    if (val1 is int)
                    {
                        Convert.ToInt32(val1);
                        a = Convert.ToInt32(val1);
                        b = Convert.ToInt32(val2);
                        if (a > b)
                        {
                            return 1;
                        }
                        else if (a == b)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return val1.ToString().CompareTo(val2.ToString());
                    }

                }
                else if (val1 != null && val2 == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        //---ADD 鄧潘ハン 2012/04/06 Redmine#29297--------------------<<<<<

        // --- ADD m.suzuki 2011/01/19 ---------->>>>>
        /// <summary>
        /// 同一メーカー・同一価格レコード存在チェック処理
        /// </summary>
        /// <param name="table">対象データテーブル</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="priceTaxExc">標準価格</param>
        /// <returns></returns>
        private bool ExistsSameMakerPrice( PartsDataSet.ClgPartsInfoDataTable table, int goodsMakerCd, double priceTaxExc )
        {
            // Viewを生成してフィルタをかける
            DataView view = new DataView( table );
            view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'",
                                            table.GoodsMakerCodeColumn.ColumnName, goodsMakerCd,
                                            table.PriceTaxExcColumn.ColumnName, priceTaxExc );
            // レコードがあればTRUE
            return (view.Count > 0);
        }
        // --- ADD m.suzuki 2011/01/19 ----------<<<<<

        /// <summary>
        /// 確定処理(1:優良)
        /// </summary>
        /// <remarks>
        /// <br>Note		: [1:優良]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult PrmOKButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            this._startPriceFlag = false;
            // 標準価格(上段),標準価格の設定処理
            this.SetSelectedListPrice((double)this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.PriceTaxExcColumn]);

            return retDialogResult;
        }

        /// <summary>
        /// 確定処理(2:純正)
        /// </summary>
        /// <remarks>
        /// <br>Note		: [2:純正]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult ClgOKButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            this._startPriceFlag = true;
            // BLコード検索モード,品番検索モード
            if (this.selectedRows.Count == 0)
            {
                return DialogResult.Cancel;
            }

            // 純正メーカーコードとカーメーカーコードが一致しない明細を選択した場合
            if (!CheckMaker((int)this.selectedRows[0].Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value))
            {
                return retDialogResult;
            }

            this.SetSelectedListPrice((double)this.selectedRows[0].Cells[this._clgPartsInfoTable.PriceTaxExcColumn.ColumnName].Value);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // 【印刷品番選択】画面表示
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// 確定処理(3:高い方(1:N))
        /// </summary>
        /// <remarks>
        /// <br>Note		: [3:高い方(1:N)]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult Higher1toNButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            // 標準価格
            double priceTaxExc = 0;
            // 標準価格(上段)
            double priceTaxExcTop = (double)this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.PriceTaxExcColumn];

            // 標準価格(下段)
            double PriceTaxExcDown = 0;
            foreach (PartsDataSet.ClgPartsInfoRow row in this._clgPartsInfoTable.Rows)
            {
                
                // 純正メーカーコードとカーメーカーコードが一致しない明細を選択した場合
                if (!CheckMaker(row.GoodsMakerCode))
                {
                    continue;
                }

                if (row.PriceTaxExc > PriceTaxExcDown)
                {
                    PriceTaxExcDown = row.PriceTaxExc;
                    // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                    // 標準価格選択のメーカーコード(下段)
                    _goodsMakerCd2 = row.GoodsMakerCode;
                    // 標準価格選択のメーカー名称(下段)
                    _goodsMakerNm2 = row.GoodsMakerNm;
                    // 標準価格選択の品番(下段)
                    _goodsNo2 = row.GoodsNo;
                    // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                }
            }

            // 標準価格(上段)と標準価格(下段)の高い方
            if (priceTaxExcTop > PriceTaxExcDown)
            {
                priceTaxExc = priceTaxExcTop;
                this._startPriceFlag = false;
            }
            else
            {
                priceTaxExc = PriceTaxExcDown;
                this._startPriceFlag = true;
            }

            // 標準価格の設定処理
            this.SetSelectedListPrice(priceTaxExc);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // 【印刷品番選択】画面表示
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// 確定処理(4:高い方(1:1))
        /// </summary>
        /// <remarks>
        /// <br>Note		: [4:高い方(1:1)]ボタンクリックイベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// </remarks>
        private DialogResult Higher1to1ButtonClickProc()
        {
            DialogResult retDialogResult = DialogResult.OK;

            UltraGridRow prmRow = this.ultraGrid_PrmPartsInfo.Rows[0];
            UltraGridRow clgRow = this.selectedRows[0];

            // 純正メーカーコードとカーメーカーコードが一致しない明細を選択した場合
            if (!CheckMaker((int)clgRow.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value))
            {
                return retDialogResult;
            }

            // 標準価格
            double priceTaxExc = 0;
            // 標準価格(上段)
            double priceTaxExcTop = (double)prmRow.Cells[this._prmPartsInfoTable.PriceTaxExcColumn.ColumnName].Value;
            // 標準価格(下段)
            double priceTaxExcDown = (double)clgRow.Cells[this._clgPartsInfoTable.PriceTaxExcColumn.ColumnName].Value;


            // 標準価格(上段)と標準価格(下段)の高い方
            if (priceTaxExcTop > priceTaxExcDown)
            {
                priceTaxExc = priceTaxExcTop;
                this._startPriceFlag = false;
            }
            else
            {
                priceTaxExc = priceTaxExcDown;
                this._startPriceFlag = true;
            }

            // 標準価格の設定処理
            this.SetSelectedListPrice(priceTaxExc);

            if (this._startForm == 1 && this._startPriceFlag)
            {
                // 【印刷品番選択】画面表示
                retDialogResult = this.StartPrintForm();
            }

            return retDialogResult;
        }

        /// <summary>
        /// 各ボタンの有効／無効の制御処理
        /// </summary>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note		: 各ボタンの有効／無効の制御を行う。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetButtonEnable(int priceSelectDiv)
        {
            switch (priceSelectDiv)
            {
                // 標準価格選択区分(1:優良)
                case PRICE_SELECT_DIV1:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Red;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        break;
                    }
                // 標準価格選択区分(2:純正)
                case PRICE_SELECT_DIV2:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Red;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // パターンのNo9
                        if (!this._parten9)
                        {
                            this.Prm_OK_Button.Enabled = false;
                            this.Clg_OK_Button.Enabled = true;
                            this.Higher_1to1_Button.Enabled = false;
                            this.Higher_1toN_Button.Enabled = false;
                        }
                        break;
                    }
                // 標準価格選択区分(3:高い方(1:N))
                case PRICE_SELECT_DIV3:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Red;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        break;
                    }
                // 標準価格選択区分(4:高い方(1:1))
                case PRICE_SELECT_DIV4:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Red;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.True;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // パターンのNo9
                        if (!this._parten9)
                        {
                            this.Prm_OK_Button.Enabled = false;
                            this.Clg_OK_Button.Enabled = false;
                            this.Higher_1to1_Button.Enabled = true;
                            this.Higher_1toN_Button.Enabled = false;
                        }
                        break;
                    }
                // 標準価格選択区分(その他)
                default:
                    {
                        this.Prm_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Prm_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Clg_OK_Button.Appearance.ForeColor = Color.Black;
                        this.Clg_OK_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1to1_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1to1_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        this.Higher_1toN_Button.Appearance.ForeColor = Color.Black;
                        this.Higher_1toN_Button.Appearance.FontData.Bold = DefaultableBoolean.False;
                        break;
                    }
            }
        }

        /// <summary>
        /// 行は選択不可のチェック
        /// </summary>
        /// <param name="usrGoodsInfo">純正メーカ</param>
        /// <remarks>
        /// <br>Note		: 純正メーカーコードとカーメーカーコードが一致していない場合、行は選択不可</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private bool CheckRowMaker(UltraGridRow usrGoodsInfo)
        {
            // 車両検索されている場合
            // --- UPD m.suzuki 2011/02/25 ---------->>>>>
            //if (this._carInfo != null
            //    && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0)
            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0 )
            // --- UPD m.suzuki 2011/02/25 ----------<<<<<
            {
                // --- ADD m.suzuki 2011/02/25 ---------->>>>>
                // メーカーコード変換
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }
                // --- ADD m.suzuki 2011/02/25 ----------<<<<<

                // 純正メーカーコードとカーメーカーコードが一致
                // --- UPD m.suzuki 2011/02/25 ---------->>>>>
                //if ((int)usrGoodsInfo.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value !=
                //    this._carInfo.CarModelInfoSummarized[0].MakerCode)
                if ( (int)usrGoodsInfo.Cells[this._clgPartsInfoTable.GoodsMakerCodeColumn.ColumnName].Value != makerCode )
                // --- UPD m.suzuki 2011/02/25 ----------<<<<<
                {
                    TMsgDisp.Show(this, 											// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "このメーカーは選択できません。",                   // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 行は選択不可のチェック
        /// </summary>
        /// <param name="goodsMake">カーメーカーコード</param>
        /// <remarks>
        /// <br>Note		: 純正メーカーコードとカーメーカーコードが一致していない場合、行は選択不可</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private bool CheckMaker(int goodsMake)
        {
            // --- UPD m.suzuki 2010/07/27 ---------->>>>>
            ////>>>2010/04/27
            //// カーメーカーコード変換
            //int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
            //if (this._changeMakerDic.ContainsKey(makerCode))
            //{
            //    makerCode = this._changeMakerDic[this._carInfo.CarModelInfoSummarized[0].MakerCode];
            //}
            ////<<<2010/04/27

            //if (this._carInfo != null
            //    && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0
            //    //>>>2010/04/27
            //    //&& goodsMake != this._carInfo.CarModelInfoSummarized[0].MakerCode)
            //    && goodsMake != makerCode)
            //    //<<<2010/04/27
            //{
            //    return false;
            //}

            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null 
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0)
            {
                // メーカーコード変換
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }

                // メーカーコード判定
                if ( goodsMake != makerCode )
                {
                    return false;
                }
            }
            // --- UPD m.suzuki 2010/07/27 ----------<<<<<

            return true;
        }
        // --- ADD m.suzuki 2011/02/25 ---------->>>>>
        /// <summary>
        /// カーメーカーコードを取得（変換後の値）
        /// </summary>
        /// <returns></returns>
        private int GetCarMakerCode()
        {
            if ( this._carInfo != null
                 && this._carInfo.CarModelInfoSummarized != null
                 && this._carInfo.CarModelInfoSummarized.Count > 0
                 && this._carInfo.CarModelInfoSummarized[0].MakerCode != 0 )
            {
                // メーカーコード変換
                int makerCode = this._carInfo.CarModelInfoSummarized[0].MakerCode;
                if ( this._changeMakerDic.ContainsKey( makerCode ) )
                {
                    makerCode = this._changeMakerDic[makerCode];
                }
                return makerCode;
            }
            else
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2011/02/25 ----------<<<<<

        /// <summary>
        /// 標準価格の設定処理
        /// </summary>
        /// <param name="priceTaxExc">標準価格</param>
        /// <remarks>
        /// <br>Note		: 確定処理して、行標準価格の設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetSelectedListPrice(double priceTaxExc)
        {
            // メーカー(上段)
            string goodsMakerCode = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerCodeColumn].ToString();
            // 品番(上段)
            string goodsNo = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsNoColumn].ToString();

            this._partsInfo.UsrGoodsInfo.BeginLoadData();
            PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(Int32.Parse(goodsMakerCode), goodsNo);

            if (row == null)
            {
                return;
            }

            // 取得した標準価格を部品検索結果データセットへ設定する。
            row.SelectedListPrice = priceTaxExc;
            // 部品検索結果データセットの標準価格選択有効区分へ「1」を設定する。
            row.SelectedListPriceDiv = 1;

            this._partsInfo.UsrGoodsInfo.EndLoadData();
        }

        /// <summary>
        /// 明細グリッド・行単位でのセルColor設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 明細グリッド・行単位でのセル設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void SetSelectedRowColor()
        {
            if (selectedRows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this._clgPartsInfoTable.Count; i++)
            {
                UltraGridRow ultraRow = this.ultraGrid_ClgPartsInfo.Rows[i];

                if (ultraRow.Selected)
                {
                    foreach (UltraGridCell cell in ultraRow.Cells)
                    {
                        if (cell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                        {
                            // Activeセル色で上書き
                            cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                            cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                            cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        }
                    }
                }
                else
                {
                    // 通常色設定
                    if (ultraRow.Index % 2 == 0)
                    {
                        foreach (UltraGridCell ultraCell in ultraRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                            {
                                ultraCell.Appearance.BackColor = Color.White;
                                ultraCell.Appearance.BackColor2 = Color.White;
                                ultraCell.Appearance.BackColorDisabled = Color.White;
                                ultraCell.Appearance.BackColorDisabled2 = Color.White;
                            }
                        }
                    }
                    else
                    {
                        foreach (UltraGridCell ultraCell in ultraRow.Cells)
                        {
                            if (ultraCell.Column.Key != this._clgPartsInfoTable.NoColumn.ColumnName)
                            {
                                ultraCell.Appearance.BackColor = Color.Lavender;
                                ultraCell.Appearance.BackColor2 = Color.Lavender;
                                ultraCell.Appearance.BackColorDisabled = Color.Lavender;
                                ultraCell.Appearance.BackColorDisabled2 = Color.Lavender;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 【印刷品番選択】画面表示
        /// </summary>
        /// <remarks>
        /// <br>Note		: 【印刷品番選択】画面表示を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// <br>Update Note : 2015/04/06 30757 佐々木 貴英</br>
        /// <br>管理番号    : 11070149-00</br>
        /// <br>              仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// </remarks>
        private DialogResult StartPrintForm()
        {
            DialogResult retDialogRt = DialogResult.OK;
            // 標準価格選択のメーカーコード(上段)
            int goodsMakerCd = Int32.Parse(this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerCodeColumn].ToString());
            // 標準価格選択のメーカー名称(上段)
            string goodsMakerNm = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsMakerNmColumn].ToString();
            // 標準価格選択の品番(上段)
            string goodsNo = this._prmPartsInfoTable.Rows[0][this._prmPartsInfoTable.GoodsNoColumn].ToString();

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            if (_goodsMakerCd2 == 0)
            {
                int selectRowIndex = 0;
                if (this._beforeSelectedRow != null)
                {
                    selectRowIndex = this._beforeSelectedRow.Index;
                }
                // 標準価格選択のメーカーコード(下段)
                _goodsMakerCd2 = Int32.Parse(this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsMakerCodeColumn].ToString());
                // 標準価格選択のメーカー名称(下段)
                _goodsMakerNm2 = this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsMakerNmColumn].ToString();
                // 標準価格選択の品番(下段)
                _goodsNo2 = this._clgPartsInfoTable.Rows[selectRowIndex][this._clgPartsInfoTable.GoodsNoColumn].ToString();
            }
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
            this._srcGoodsNo = (string)_goodsNo2.Clone();
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
            #region ●売上全体設定マスタ DCKHN09212A
            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList salesTtlStList;
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();     // 売上全体設定マスタ
            salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesTtlStAcs.SearchOnlySalesTtlInfo(out salesTtlStList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesTtlStList != null) this.CacheSalesTtlSt(salesTtlStList, enterpriseCode, sectionCode);
                if (this._salesTtlSt.EpPartsNoPrtCd == 1)
                {
                    _goodsNo2 += this._salesTtlSt.EpPartsNoAddChar;
                }
            }
            #endregion          
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // 【印刷品番選択】画面表示
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
            ////SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo);
            //SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo, _goodsMakerCd2, _goodsMakerNm2, _goodsNo2, this._salesTtlSt.EpPartsNoPrtCd);
            //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
            SelectionPrtGoodsNo printForm = new SelectionPrtGoodsNo(goodsMakerCd, goodsMakerNm, goodsNo, this._partsInfo, _goodsMakerCd2, _goodsMakerNm2, _goodsNo2, this._salesTtlSt.EpPartsNoPrtCd, this._salesTtlSt.PrintGoodsNoDef);
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
            if (!string.IsNullOrEmpty(this._addTitleCaption))
            {
                printForm.Text += this._addTitleCaption;
            }
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
            retDialogRt = printForm.ShowDialog(Owner);

            return retDialogRt;
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : 李侠</br>
        /// <br>Date        : 2010/02/04</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            // ESCボタンで画面を終了する
            this.Close();
        }
        #endregion

        #region ■ publicメソッド ■
        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 画面表示時に発生します。標準価格選択区分より、画面表示の処理</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/19</br>
        /// <br>Update Note : 李占川 2009/11/13</br>
        /// <br>            : redmine#1266  初期フォーカス位置の修正</br>
        /// <br>Update Note : 2015/04/06 30757 佐々木 貴英</br>
        /// <br>管理番号    : 11070149-00</br>
        /// <br>              仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
            if (!string.IsNullOrEmpty(this._addTitleCaption))
            {
                this.Text += this._addTitleCaption;
            }
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<

            // 起動モード
            switch (this._startMode)
            {
                // BLコード検索モード
                case 1:
                    {
                        // 標準価格選択区分
                        switch (this._priceSelectDiv)
                        {
                            // 1:優良
                            case PRICE_SELECT_DIV1:
                                {
                                    return this.PrmOKButtonClickProc();
                                }
                            // 2:純正
                            case PRICE_SELECT_DIV2:
                                {
                                    this.selectedRows.Clear();
                                    this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);
                                    return this.ClgOKButtonClickProc();
                                }
                            // 3:高い方
                            case PRICE_SELECT_DIV3:
                            case PRICE_SELECT_DIV4:
                                {
                                    return this.Higher1toNButtonClickProc();
                                }
                            // --- ADD 2009/11/13 ---------->>>>> 
                            default:
                                {
                                    this.ultraGrid_ClgPartsInfo.TabStop = false;
                                    break;
                                }
                            // --- ADD 2009/11/13 ----------<<<<<
                        }
                        break;
                    }
                // 品番検索モード
                case 2:
                    {
                        // 標準価格選択区分
                        switch (this._priceSelectDiv)
                        {
                            // 1:優良
                            case PRICE_SELECT_DIV1:
                                {
                                    return this.PrmOKButtonClickProc();
                                }
                            // 2:純正
                            case PRICE_SELECT_DIV2:
                                {
                                    this._parten9 = false;

                                    if (this._clgPartsInfoTable.Rows.Count == 1)
                                    {
                                        this.selectedRows.Clear();
                                        this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                                        return this.ClgOKButtonClickProc();
                                    }
                                    else
                                    {
                                        this.Clg_OK_Button_Click(this, new EventArgs());
                                    }
                                    break;
                                }
                            // 3:高い方(1:N)
                            case PRICE_SELECT_DIV3:
                                {
                                    return this.Higher1toNButtonClickProc();
                                }
                            // 4:高い方(1:1)
                            case PRICE_SELECT_DIV4:
                                {
                                    this._parten9 = false;

                                    if (this._clgPartsInfoTable.Rows.Count == 1)
                                    {
                                        this.selectedRows.Clear();
                                        this.ultraGrid_ClgPartsInfo.Rows[0].Selected = true;
                                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[0]);

                                        return this.Higher1to1ButtonClickProc();
                                    }
                                    else
                                    {
                                        this.Higher_1to1_Button_Click(this, new EventArgs());
                                    }
                                    break;
                                }
                            default:
                                {
                                    this.ultraGrid_ClgPartsInfo.TabStop = false;
                                    break;
                                }
                        }
                        break;
                    }
            }
            return base.ShowDialog(owner);
        }
        #endregion

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        # region ■売上全体設定マスタ制御処理
        /// <summary>
        /// 売上全体設定マスタキャッシュ
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        # endregion
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // ---ADD 鄧潘ハン　2014/05/16 ------------------------------------>>>>>
        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: キーが押された時に発生します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2014/05/16</br>
        /// </remarks>
        private void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13:
                    string selectNo = this.tEdit_SelectNo.Text;

                    if (this._getDataMode == 2 || this._getDataMode == 4)
                    {
                        if (Int32.Parse(selectNo) > this._clgPartsInfoTable.Count)
                        {
                            this.tEdit_SelectNo.Focus();
                            this.tEdit_SelectNo.Text = "1";
                            return;
                        }

                        int rowNo = Int32.Parse(selectNo) - 1;

                        // 行は選択不可のチェック
                        if (!this.CheckRowMaker(this.ultraGrid_ClgPartsInfo.Rows[rowNo]))
                        {
                            this.ultraGrid_ClgPartsInfo.Focus();
                            this._beforeSelectedRow.Selected = true;
                            this._beforeSelectedRow.Activate();
                            return;
                        }

                        this.ultraGrid_ClgPartsInfo.Rows[rowNo].Selected = true;

                        this.selectedRows.Clear();
                        this.selectedRows.Add(this.ultraGrid_ClgPartsInfo.Rows[rowNo]);

                        // 明細グリッド・行単位でのセルColor設定
                        this.SetSelectedRowColor();

                        this.tEdit_SelectNo.Focus();

                        // 2:純正
                        if (this._getDataMode == 2)
                        {
                            DialogResult = this.ClgOKButtonClickProc();
                        }
                        // 4:高い方(1:1) 
                        else
                        {
                            DialogResult = this.Higher1to1ButtonClickProc();
                        }
                    }
                    else
                    {
                        EventArgs eventArgs = new EventArgs();

                        // BLコード検索モード
                        if (this._startMode == 1)
                        {
                            switch (selectNo)
                            {
                                // 1:優良
                                case "1":
                                    {
                                        this.Prm_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 2:純正
                                case "2":
                                    {
                                        this.Clg_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 3:高い方
                                case "3":
                                    {
                                        this.Higher_1toN_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                default:
                                    {
                                        this.tEdit_SelectNo.Focus();
                                        this.tEdit_SelectNo.Text = "1";
                                        break;
                                    }
                            }
                        }
                        // 品番検索モード
                        else
                        {
                            switch (selectNo)
                            {
                                // 1:優良
                                case "1":
                                    {
                                        this.Prm_OK_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 2:純正
                                case "2":
                                    {
                                        this.Clg_OK_Button_Click(sender, eventArgs);
                                        this.ultraGrid_ClgPartsInfo.Focus();
                                        break;
                                    }
                                // 3:高い方(1:N)
                                case "3":
                                    {
                                        this.Higher_1toN_Button_Click(sender, eventArgs);
                                        break;
                                    }
                                // 4:高い方(1:1) 
                                case "4":
                                    {
                                        this.Higher_1to1_Button_Click(sender, eventArgs);
                                        this.ultraGrid_ClgPartsInfo.Focus();
                                        break;
                                    }
                                default:
                                    {
                                        this.tEdit_SelectNo.Focus();
                                        this.tEdit_SelectNo.Text = "1";
                                        break;
                                    }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        // ---ADD 鄧潘ハン　2014/05/16 ------------------------------------<<<<<
        
    }
}
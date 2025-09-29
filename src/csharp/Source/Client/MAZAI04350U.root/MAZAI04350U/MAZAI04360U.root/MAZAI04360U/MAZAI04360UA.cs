//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫仕入入力
// プログラム概要   : 在庫仕入入力で使用するデータの取得・更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/07/24  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/17  修正内容 : 不具合対応[13515]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/11/16  修正内容 : 在庫登録機能の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018  鈴木 正臣
// 修 正 日  2010/01/14  修正内容 : 同一品番・メーカー違いの商品(例: 4PK800)を
//                               : 明細部に入力した後、セル移動の度に同一品番選択
//                               : ウィンドウが表示される不具合を修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2009/12/16  修正内容 : PM.NS-5
//　　　　　　　　　　　　　　　　　標準価格、原単価、仕入数、仕入後数の
//                                  ディフォルトの改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangsf
// 修 正 日  2010/05/19  修正内容 : redmine #7935対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/05/20  修正内容 : redmine #8106対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/06/08  修正内容 : 障害改良対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/07/14  修正内容 : Mantis.15812　商品在庫マスタ呼び出し時のパラメータの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/12/20  修正内容 : 障害改良対応x月
//                                  あいまい検索で在庫品を選択した場合に、品番が表示が不正になる不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 曹文傑 連番1028,Redmine#22936
// 修 正 日  2011/07/18  修正内容 : MANTIS[17500]仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊</br>
// 修 正 日  2011/11/02  修正内容 : redmine#26320 ハイフンありとなしの同一品番が存在し、ハイフンありのみ在庫登録されていませんの対応</br>
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : lxl
// 修 正 日  2011/12/5  修正内容 : redmine#8072 在庫仕入伝票入力で、同一品番を選択した場合、明細でフォーカス移動毎に同一品番選択ウィンドウが表示される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/12/13  修正内容 : redmine#26816（元8072） 修正呼び出し時には同一品番選択ウィンドウは表示しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/12/15  修正内容 : redmine#26816（元8072） 修正呼び出し時には同一品番選択ウィンドウは表示しない
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhangy3
// 修 正 日  2013/01/04  修正内容 : 2013/03/13配信分 redmine#33845 在庫品仕入入力
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhangy3
// 修 正 日  2013/02/21  修正内容 : 2013/03/13配信分 redmine#33845 在庫品仕入入力
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/02/23  修正内容 : 2013/03/13配信分 redmine#33845 在庫品仕入入力
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhujc
// 修 正 日  2013/02/27  修正内容 : 2013/03/13配信分 redmine#34858 在庫品仕入入力
//----------------------------------------------------------------------------//
// 管理番号  10901273-00 作成担当 : 王君                                      //
// 修 正 日  2013/05/02  修正内容 : 2013/06/18配信分     　                   //
///                               : Redmine#35434 商品在庫マスタ起動区分の追加//
//----------------------------------------------------------------------------//
// 管理番号  BLINCIDENT-2393 作成担当 : 鈴木創                                //
// 修 正 日  2021/10/07      修正内容 :BLINCIDENT-2393                        //
///                                   :在庫仕入入力で備考欄にカーソルを当てた時にエラーが起きてしまう。 //
//----------------------------------------------------------------------------//
// 管理番号  11601223-00 作成担当 : 陳艶丹
// 修 正 日  2021/10/08  修正内容 : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  11800082-00 作成担当 : 陳艶丹
// 修 正 日  2022/01/20  修正内容 : BLINCIDENT-3254 再度同一品番選択画面が表示される対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫仕入入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫仕入入力を行うフォームクラスです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.03.09</br>
    /// <br>Update Note: 2007.10.11 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.01.17 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008.02.15 980035 金沢 貞義</br>
    /// <br>			 ・定価セット対応</br>
    /// <br>Update Note: 2008.03.21 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応</br>
    /// <br>Update Note: 2008/07/24 30414 忍 幸史</br>
    /// <br>			 ・Partsman用に変更</br>
    /// <br>Update Note: 2009/11/16 30434 工藤 恵優</br>
    /// <br>			 ・在庫登録機能の追加</br>
    /// <br>Update Note: 2010/06/08 楊明俊</br>
    /// <br>             ・障害改良対応</br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>               障害改良対応x月</br>
    /// <br>               あいまい検索で在庫品を選択した場合に、品番が表示が不正になる不具合の修正。</br>
    /// <br>UpdateNote :  2011/07/18 曹文傑</br>
    /// <br>              MANTIS[17500] 連番1028 仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note: 2011/11/02 楊明俊</br>
    /// <br>             redmine#26320 ハイフンありとなしの同一品番が存在し、ハイフンありのみ在庫登録されていませんの対応</br>
    /// <br>Update Note: 2011/12/5 lxl</br>
    /// <br>             redmine#26816（元8072） 修正呼び出し時には同一品番選択ウィンドウは表示しない</br>
    /// <br>Update Note: 2013/01/04 zhangy3</br>
    /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
    /// <br>           : Redmine#33845 在庫品仕入入力</br>
    /// <br>Update Note: 2013/02/21 zhangy3</br>
    /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
    /// <br>           : Redmine#33845 在庫品仕入入力</br>
    /// <br>Update Note: 2013/02/23 zhuhh</br>
    /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
    /// <br>           : Redmine#33845 在庫品仕入入力</br>
    /// <br>Update Note: 2013/05/02 王君</br>
    /// <br>管理番号   : 10901273-00　2013/06/18配信分</br>　
    /// <br>           : Redmine#35434 商品在庫マスタ起動区分の追加</br>
    /// <br>Update Note: 2021/10/08 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
    /// <br>Update Note: 2022/01/20 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
    /// </remarks>
	public partial class MAZAI04360UA : Form, IStockEntryTbsCtrlChild, IStockEntryTbsCtrlChildEvent
	{
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        public delegate void ChangeToolbarSettingEventHandler(int mode);
        public static event ChangeToolbarSettingEventHandler ChangeToolbarSetting;

        public static event ChangeFocusFooterEventHandler changeFocusFooter;
        public delegate void ChangeFocusFooterEventHandler(Boolean changeFlg);
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        // 2009.04.02 30413 犬飼 保存用イベント追加 >>>>>>START
        public static event SaveEventHandler save;
        public delegate void SaveEventHandler();
        // 2009.04.02 30413 犬飼 保存用イベント追加 <<<<<<END

        // --- ADD 2009/12/16 ---------->>>>>
        // 定価入力区分
        public int _listPriceInpDiv;
        
        // 単価入力区分
        public int _unitPriceInpDiv;

        // 移動先行インデックス
        private int _activeRowIndex = 0;

        // 移動先列インデックス
        private int _activeColumnIndex = 0;

        // 移動元行インデックス
        private int _preRowIndex = 0;

        // 移動元列インデックス
        private int _preColumnIndex = 0;

        private int _makerCode = 0;

        // --- ADD 2011/07/18 ----------->>>>>
        private AllDefSet _allDefSet;
        // --- ADD 2011/07/18 -----------<<<<<
        // --- ADD 2009/12/16 -----------<<<<<

        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
        #region 在庫登録用イベント定義

        /// <summary>
        /// 在庫登録を有効にするイベントパラメータクラス
        /// </summary>
        public sealed class EnabledToInputStockEventArgs : EventArgs
        {
            /// <summary>有効フラグ</summary>
            private bool _enabled;
            /// <summary>有効フラグを取得または設定します。</summary>
            public bool Enabled
            {
                get { return _enabled; }
                set { _enabled = value; }
            }

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="enabled">有効フラグ</param>
            public EnabledToInputStockEventArgs(bool enabled) : base()
            {
                _enabled = enabled;
            }
        }

        /// <summary>
        /// 在庫登録を有効にするイベントハンドラデリゲート
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        public delegate void OnEnabledToInputStock(object sender, EnabledToInputStockEventArgs e);

        #endregion // 在庫登録用イベント定義

        #region 在庫登録を有効にするイベント

        /// <summary>在庫登録を有効にするイベントハンドラ</summary>
        public static event OnEnabledToInputStock EnabledToInputStock;

        /// <summary>
        /// デフォルト在庫登録を有効にするイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void DefaultEnabledToInputStock(object sender, EnabledToInputStockEventArgs e)
        {
            string msg = string.Format("EnabledToInputStock = {0}", e.Enabled);
            System.Diagnostics.Debug.WriteLine(msg);
        }

        #endregion // 在庫登録を有効にするイベント
        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

		//==================================================================
		//  コンストラクタ
		//==================================================================
        public static MAZAI04360UA GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new MAZAI04360UA();
            }

            return myInstance;
        }

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public MAZAI04360UA()
		{
			InitializeComponent();

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
            ModetCmbEditor.SelectedIndex = ctMode_StockAdjust;
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];            

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }            

            // 明細列情報表示生成
			_colDispInfo = new PtAdjustStockDtlDisplayStatus();
            // 定義ファイルより初期値取得
            _colDispInfo.DeserializeData(ctFILE_ColDispInfo);
            // 定義ファイルを正しく読み込めたか？
            if (_colDispInfo.CheckDisplayStatus() == false)
            {
                // 初期値にする。
                _colDispInfo.SetDefaultValue();
            }
            
			//------ アイコン設定 ------
			// ツールバーイメージ
			this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;
            this.uButton_EmployeeGuide.ImageList = IconResourceManagement.ImageList16;
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            this.SectionGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.SectionGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.WarehouseGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.WarehouseGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.SalesSlipGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.SalesSlipGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.SlipNoteGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.SlipNoteGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            // コントロールサイズ設定
            this.tEdit_SectionCode.Size = new Size(52, 24);
            this.uLabel_SectionName.Size = new Size(242, 24);
            this.tEdit_WarehouseCode.Size = new Size(52, 24);
            this.uLabel_WarehouseName.Size = new Size(242, 24);
            this.tNedit_SupplierSlipNo.Size = new Size(84, 24);
            this.uLabel_LastSalesSlipNum.Size = new Size(78, 19);
            this.tEdit_EmployeeCode.Size = new Size(52, 24);
            this.uLabel_StockAgentName.Size = new Size(320, 24);
            this.edtNote1.Size = new Size(480, 24);

            // インスタンス作成
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._employeeAcs = new EmployeeAcs();
            this._noteGuideAcs = new NoteGuidAcs();
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            this.RowDelete_ultraButton.ImageList = IconResourceManagement.ImageList16;
            this.RowDelete_ultraButton.Appearance.Image = (int)Size16_Index.ROWDELETE;
            this.RowDelete_ultraButton.Enabled = false;
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            
			// フォントサイズ
			this._canColResizeFlg = false;
			try
			{
				this.cmbGridFont.Value = _colDispInfo.FontSize;
			}
			finally
			{
				this._canColResizeFlg = true;
			}

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
            _fractionProcCd = GetFractionProcCD();
            _stockPointWay = GetStockPointWay();
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (_stockPointWay == 2) // 1 仕入法 2 平均法 3 個別法
            //{
            //    //在庫評価法 = 移動平均法 → 原価調整不可
            //    ModetCmbEditor.Items.RemoveAt(ctMode_UnitPriceReEdit);
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            AdjustStockAcs.GetInputAgentCode += new AdjustStockAcs.GetInputAgentCodeEventHandler(this.GetInputAgentCode);
            _adjustStockAcs = AdjustStockAcs.GetInstance();

            // 画面初期化
            AllDispClear(false);

            // フォーカス設定
            makedate_tDateEdit.Focus();

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
            AdjustStockAcs.GetEditMode += new AdjustStockAcs.GetEditModeEventHandler(this.GetEditerMode);
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

            // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
            //_adjustStockAcs.DataChanged += new EventHandler(this.Adjust_DataChanged);
            // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            //this.tEdit_EmployeeCode.Text = GetEmployee();
            //_employee = new Employee();
            //SetEmployeeCode();

            this.tEdit_EmployeeCode.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this._employee = LoginInfoAcquisition.Employee;
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            this.GetDtlCalcStckCntDsp();        // ADD 2011/07/18

            EnabledToInputStock += new OnEnabledToInputStock(DefaultEnabledToInputStock);   // ADD 2009/11/16 3次分対応 在庫登録機能を追加
        }

		#endregion

		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数

        private static MAZAI04360UA myInstance = null;
        /// <summary>
        /// 在庫調整明細アクセスクラス
        /// </summary>
        private AdjustStockAcs _adjustStockAcs;




        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 画面表示モード
		/// </summary>
		private int _dispMode = (int)ChildFormDispMode.Normal;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
		/// 伝票明細列表示ステータス
		/// </summary>
		private PtAdjustStockDtlDisplayStatus _colDispInfo = null;

        private Image _guideButtonImage;

        private bool _warehouseCodeFocusFlg;

        /// <summary>
        /// 企業コード
        /// </summary>
        private string _enterpriseCode;

        /// <summary>
        /// 従業員マスタ
        /// </summary>
        private Employee _employee;

        /// <summary>
		/// 明細グリッドセル設定非同期用デリゲート
		/// </summary>
		/// <param name="row">設定対象行インデックス</param>
		private delegate void settingGridRowEditorHandler(int row);
		/// <summary>
		/// 列幅調整イベント許可フラグ
		/// </summary>
		private bool _canColResizeFlg = true;
		/// <summary>
		/// 強制再描画フラグ(AfterPerformActionイベントで強制的に再描画する時に使用する)
		/// </summary>
		private bool _forceRepaintGridFlag = false;
		/// <summary>
		/// イベント制御フラグ
		/// </summary>
		private bool _localEventBlockFlg = false;

        // --- ADD 2009/12/16 ---------->>>>>
        // 変更前標準価格
        private double _beforeListPriceInpDiv = 0;

        // 変更前原単価
        private double _beforeUnitPriceInpDiv = 0;
        // --- ADD 2009/12/16 -----------<<<<<

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// セル非アクティブ時のセル情報
		/// </summary>
		private UltraGridCell _tempCell = null;
		/// <summary>
		/// セル非アクティブ時の初期値
		/// </summary>
		private object _tempValue = null;
		/// <summary>
		/// セル非アクティブイベント実行フラグ
		/// </summary>
		private bool _beforeCellDeactivateRun = false;
		/// <summary>
		/// 特殊NewEntryパラメタ用仕入管理データクラス
		/// </summary>
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private SecInfoSetAcs _secInfoSetAcs;
        private WarehouseAcs _warehouseAcs;
        private EmployeeAcs _employeeAcs;
        private NoteGuidAcs _noteGuideAcs;

        private string _prevSectionCode = "";
        private string _prevWarehouseCode = "";
        private string _prevEmployeeCode = "";

        private bool _orderListResultFlg;

        private bool _searchFlg;

        private bool _stockExistFlg;

        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
        /// <summary>
        /// 在庫存在フラグを取得または設定します。(設定時にイベントを発生)
        /// </summary>
        private bool ExistsStockWithEvents
        {
            get { return _stockExistFlg; }
            set
            {
                _stockExistFlg = value;
                // 在庫が存在しない場合、[在庫(F8)]ボタンを有効化
                EnabledToInputStock(this, new EnabledToInputStockEventArgs(!_stockExistFlg));
            }
        }
        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private int _fractionProcCd;
        private int _stockPointWay;

        private const string ctGoodState_normalItem = "通常品";
        private const int ctGoodsState_nomalValue = 0;
        private const string ctGoodsState_errorItem = "不良品";
        private const int ctGoodsState_errorValue = 1;

        private const int ctLastSupplier = 1; //最終仕入法
        private const int ctAverage = 2;      //移動平均法
        private const int ctIndividual = 3;   //個別平均法
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private const string ctFormatNum = "#,###,##0";
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        private TotalDayCalculator _totalDayCalculator;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト // ADD 2010/05/20
        #endregion

		//--------------------------------------------------------
		//  プライベート定数
		//--------------------------------------------------------
		#region プライベート定数
		/// <summary>明細列表示ステータスファイル名称</summary>
		private const string ctFILE_ColDispInfo = "MAZAI04360U.DAT";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>明細種別リスト</summary>
		private const string ctKEY_DetailKindList = "DetailKindList";
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>PGID</summary>
		private const string ctPGID = "MAZAI04360U";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private const int ctMode_StockAdjust = 0;
        // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
        //private const int ctMode_TrustAdjust = 1;
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////private const int ctMode_ProductReEdit = 2;
        ////private const int ctMode_GoodsCodeStatus = 3;
        ////private const int ctMode_UnitPriceReEdit = 4;
        //private const int ctMode_UnitPriceReEdit = 2;
        //private const int ctMode_ShelfNoReEdit = 3;
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        private const int ctMode_UnitPriceReEdit = 1;
        private const int ctMode_ShelfNoReEdit = 2;
        // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
        private const string StrResearchErrMsg = "商品検索でエラーが発生しました。\n\r商品を再度入力してください。";
        //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        // アスタリスク
        private const string CTASTER = "*";
        // ハイフン
        private const string CTHYPHEN = "-";
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<
        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        //--------------------------------------------------------
		//  インターフェース実装部
		//--------------------------------------------------------
		#region 
        public static event GetSectionEventHandler GetSection;
        public delegate string GetSectionEventHandler();
        public static event GetFractionProcCdEventHandler  GetFractionProcCD;
        public static event GetStockPointWayCDEventHandler GetStockPointWay;
        public delegate int GetFractionProcCdEventHandler();
        public delegate int GetStockPointWayCDEventHandler();
        public static event GetEmpListEventHandler GetEmpList;
        public delegate ArrayList GetEmpListEventHandler();
        public static event GetEmployeeEventHandler GetEmployee;
        public delegate string GetEmployeeEventHandler();
        #endregion
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // ----- ADD 2010/05/20 ------------------------->>>>>
        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAZAI04350U", this);
                }
                return _operationAuthority;
            }
        }
        // ----- ADD 2010/05/20 -------------------------<<<<<

        public void Renewal()
        {
            this._adjustStockAcs.ReadStockMngTtlSt();
            this._adjustStockAcs.ReadInitData();         // 単価算出クラス初期データ読込
            this._adjustStockAcs.ReadTaxRate();          // 税率設定マスタ読込
            this._adjustStockAcs.ReadBLGoodsCdUMnt();    // BL商品コードマスタ読込
            this._adjustStockAcs.ReadWarehouse();        // 倉庫マスタ読込
            this._adjustStockAcs.ReadSecInfoSet();       // 拠点情報設定マスタ読込
            this._adjustStockAcs.ReadEmployee();         // 従業員マスタ読込
            this._adjustStockAcs.ReadMakerUMnt();        // メーカーマスタ読込
            this._adjustStockAcs.ReadSupplier();
            this._adjustStockAcs.ReadCompanyInf(); //ADD 2011/07/25
            this.GetDtlCalcStckCntDsp();      //ADD 2011/07/18
        }

        /// <summary>
        /// 発注残履歴修正フラグ
        /// </summary>
        /// <returns></returns>
        public bool GetOrderListResultFlg()
        {
            return this._orderListResultFlg;
        }

        /// <summary>
        /// 伝票番号取得処理
        /// </summary>
        /// <returns>伝票番号</returns>
        public string GetSlipNote()
        {
            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            //return edtNote1.Text;
            return this.edtNote1.DataText.Trim();
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 伝票番号設定処理
        /// </summary>
        /// <param name="msg">伝票番号</param>
        public void SetSlipNote(string msg)
        {
            edtNote1.Text = msg;
        }

        /// <summary>
        /// 仕入日取得処理
        /// </summary>
        /// <returns>仕入日</returns>
        public DateTime GetDate()
        {
            return makedate_tDateEdit.GetDateTime();
        }

        /// <summary>
        /// 拠点コード取得
        /// </summary>
        /// <returns>拠点コード</returns>
        public string GetStockSectionCode()
        {
            return this.tEdit_SectionCode.DataText.Trim();
        }

        // --- ADD 2009/12/16 ---------->>>>>
        /// <summary>
        /// 定価入力区分取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから定価入力区分を取得します。</br>
        /// <br>Programer  : 朱俊成</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        public void GetListPriceInpDiv()
        {
            int status;
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
            ArrayList retList;
            bool setFlg = false;
            try
            {
                status = stockTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockTtlSt stockTtlSt in retList)
                    {
                        // ログイン拠点のデータが存在する時
                        if ((0 == stockTtlSt.LogicalDeleteCode) && (stockTtlSt.SectionCode.Trim() == GetStockSectionCode().Trim()))
                        {
                            _listPriceInpDiv = stockTtlSt.ListPriceInpDiv;
                            setFlg = true;
                            break;
                        }
                    }
                    // ログイン拠点のデータが存在しません、全社'00'のデータを利用します
                    if (!setFlg)
                    {
                        foreach (StockTtlSt stockTtlSt in retList)
                        {
                            if (stockTtlSt.SectionCode.Trim() == "00")
                            {
                                _listPriceInpDiv = stockTtlSt.ListPriceInpDiv;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 単価入力区分取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから単価入力区分を取得します。</br>
        /// <br>Programer  : 朱俊成</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        public void GetUnitPriceInpDiv()
        {
            int status;
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
            ArrayList retList;
            bool setFlg = false;
            try
            {
                status = stockTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockTtlSt stockTtlSt in retList)
                    {
                        // ログイン拠点のデータが存在する時
                        if ((0 == stockTtlSt.LogicalDeleteCode) && (stockTtlSt.SectionCode.Trim() == GetStockSectionCode().Trim()))
                        {
                            _unitPriceInpDiv = stockTtlSt.UnitPriceInpDiv;
                            setFlg = true;
                            break;
                        }
                    }
                    // ログイン拠点のデータが存在しません、全社'00'のデータを利用します
                    if (!setFlg)
                    {
                        foreach (StockTtlSt stockTtlSt in retList)
                        {
                            if (stockTtlSt.SectionCode.Trim() == "00")
                            {
                                _unitPriceInpDiv = stockTtlSt.UnitPriceInpDiv;
                                break;
                            }
                        }
                    }

                }
            }
            catch
            {
            }
        }
        // --- ADD 2009/12/16 -----------<<<<<

        /// <summary>
        /// 仕入金額計取得
        /// </summary>
        /// <returns>仕入金額計</returns>
        public Int64 GetSubttlPrice()
        {
            if (this.lblTotalPrice.Text == "")
            {
                return 0;
            }
            else
            {
                double totalPrice;

                if (double.TryParse(this.lblTotalPrice.Text, out totalPrice) == true)
                {
                    return (Int64)totalPrice;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 前回保存伝票番号設定
        /// </summary>
        /// <param name="stockAdjustSlipNo"></param>
        public void SetStockAdjustSlipNo(int stockAdjustSlipNo)
        {
            this.uLabel_LastSalesSlipNum.Text = stockAdjustSlipNo.ToString();
        }

        public bool GetEnabledSupplierSlipNo()
        {
            return this.tNedit_SupplierSlipNo.Enabled;
        }

        public bool CheckHisTotalDayMonthly(string sectionCode, DateTime targetDate, out DateTime prevTotalDay)
        {
            int status;
            prevTotalDay = new DateTime();

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode, out prevTotalDay);
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
            }

            if (status == 0)
            {
                if (targetDate > prevTotalDay)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (true);
            }
        }

		//--------------------------------------------------------
		//  インターフェース実装部
		//--------------------------------------------------------
		#region インターフェース実装部
		#region IStockEntryTbsCtrlChild メンバ
		/// <summary>
		/// 画面表示メソッド
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <remarks>
		/// <br>Note       : パラメータ付きで画面表示を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		public void Show(object parameter)
		{
			// Gridにバインドする
			this.StockGrid.DataSource = AdjustStockAcs.AdjustStockView;
			// エントリーの明細カラーを設定
			// (SettingGridでヘッダーのAppearanceを表示順位に設定しているのでヘッダーはこの位置でセットする)
			DetailGridHeaderColorMng.SetHeaderColor((int)DetailGridHeaderColorMng.ColorGetMode.SF_Mode, "", ref this.StockGrid);
			// Gridの設定を行う
			this.SettingGrid();

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            ////選択した区分によってGRIDのEnable制御を変更
            //ChangeGridLayout(ModetCmbEditor.SelectedIndex);

            // GRIDのEnable制御
            ChangeGridLayout(); 
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
			
            this.Show();
		}

		/// <summary>
		/// StaticMemoryの情報を表示します。
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <returns>0:正常終了, 0以外:異常終了</returns>
		/// <remarks>
		/// <br>Note       : StaticMemory情報の表示処理を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		public int ShowStaticMemoryData(object sender)
		{
			// 通常表示
			return this.ShowStaticMemoryData(sender, (int)ChildFormDispMode.Normal);
		}

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// StaticMemoryの情報を表示します。
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="dispMode">表示モード</param>
		/// <returns>0:正常終了, 0以外:異常終了</returns>
		/// <remarks>
		/// <br>Note       : StaticMemory情報の表示処理を行います。</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/07/24</br>
		/// </remarks>
		public int ShowStaticMemoryData(object sender, int dispMode)
		{
            // 画面コントロールEnabled変更
            ChangeScreenEnabled(true);

            // グリッドを再設定
			this.SettingGridRowEditor();

            // スクロールポジション初期化
            this.StockGrid.DisplayLayout.RowScrollRegions.Clear();

			return 0;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// StaticMemoryの情報を表示します。
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="dispMode">表示モード</param>
        /// <returns>0:正常終了, 0以外:異常終了</returns>
        /// <remarks>
        /// <br>Note       : StaticMemory情報の表示処理を行います。</br>
        /// <br>Programer  : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.03.09</br>
        /// </remarks>
        public int ShowStaticMemoryData(object sender, int dispMode)
        {
			this._dispMode = dispMode;

			// 伝票項目表示
			this.DispSlipInfo(dispMode);

            // グリッドを再設定
            this.SettingGridRowEditor();

            return 0;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 編集モード
        /// </summary>
        public int GetEditMode()
        {
            return GetEditerMode();
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #endregion

        #region IStockEntryTbsCtrlChildEdit メンバ
        /// <summary>
		/// StaticMemoryの情報を保存します。
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <returns>ステータス</returns>
		public int SaveStaticMemoryData(object sender)
		{
			// 入力中のデータを決定する。
			// エディット系
			Control wkCtrl = this.ActiveControl;
			if (wkCtrl != null)
			{
				if (wkCtrl is EmbeddableTextBoxWithUIPermissions)
				{
					wkCtrl = wkCtrl.Parent;

					if ((wkCtrl is TNedit) && (wkCtrl.Parent != null) && (wkCtrl.Parent is TDateEdit))
					{
						wkCtrl = wkCtrl.Parent;
					}
				}

				this.tRetKeyControl_ChangeFocus(wkCtrl, new ChangeFocusEventArgs(false, false, false, Keys.Enter, wkCtrl, wkCtrl));
			}

			// グリッド
			this.StockGrid.UpdateData();
			if (this.StockGrid.ActiveCell != null)
			{
				if (this.StockGrid.ActiveCell.IsInEditMode == true)
				{
					//-- 下記の順にアクションを起こす事で、アクセスクラスへ変更を通知する。
					// 編集モードを解除
					this.StockGrid.PerformAction(UltraGridAction.ExitEditMode);
					// セル位置を移動
					this.StockGrid.PerformAction(UltraGridAction.NextCellByTab);
					// セル位置を元に戻す
					this.StockGrid.PerformAction(UltraGridAction.PrevCellByTab);
				}
			}

			return 0;
		}

		/// <summary>
		/// エラー項目を表示します。
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="ErrorItems">エラー項目</param>
		/// <returns>ステータス</returns>
		public int ShowErrorItems(object sender, ArrayList ErrorItems)
		{
			// 未実装
			return 0;
		}
		#endregion

		#region IStockEntryTbsCtrlChildEvent メンバ
		/// <summary>
		/// タブ子画面アクティブ時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EntryTabChildFormActivated(object sender, EventArgs e)
		{
			// アクセスクラスの明細テーブル行変更イベントにハンドラを追加
			AdjustStockAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;

            makedate_tDateEdit.Focus();
		}

		/// <summary>
		/// タブ子画面非アクティブ時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public int EntryTabChildFormDeactivate(object sender, EventArgs e)
		{
			// ツールバーをEnabled状態にしないと、別画面からでも起動してしまいます
			ToolbarsManager_Main.Enabled = false;

			// アクセスクラスの明細テーブル行変更イベントのハンドラを削除
			AdjustStockAcs.ProductStockDataTable.RowChanged -= SlipDtlDataTable_SlipDtlRowChanged;
            
			return 0;
		}
		#endregion

		#region IStockEntryTbsCtrlChildCheck メンバ
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入力チェック処理
		/// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
		public bool CheckInputData(out string errMsg)
		{
            this.StockGrid.AfterCellUpdate -= this.StockGrid_AfterCellUpdate;
            this.StockGrid.ActiveCell = null;
            this.StockGrid.AfterCellUpdate += this.StockGrid_AfterCellUpdate;

            errMsg = "";

            // 仕入日チェック
            if (this.makedate_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                errMsg = "仕入日が入力されていません。";
                this.makedate_tDateEdit.Focus();
                return (false);
            }
            // 拠点チェック
            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                errMsg = "拠点コードが入力されていません。";
                this.tEdit_SectionCode.Focus();
                return (false);
            }
            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
            if (this._adjustStockAcs.GetSectionName(sectionCode) == "")
            {
                errMsg = "拠点コードがマスタに登録されていません。";
                this.tEdit_SectionCode.Focus();
                return (false);
            }

            DateTime targetDate;
            if (!CheckHisTotalDayMonthly(sectionCode, this.makedate_tDateEdit.GetDateTime(), out targetDate))
            {
                errMsg = "仕入日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                this.makedate_tDateEdit.Focus();
                return (false);
            }

            // 倉庫チェック
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                errMsg = "倉庫コードが入力されていません。";
                this.tEdit_WarehouseCode.Focus();
                return (false);
            }
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();
            if (this._adjustStockAcs.GetWarehouseName(warehouseCode) == "")
            {
                errMsg = "倉庫コードがマスタに登録されていません。";
                this.tEdit_WarehouseCode.Focus();
                return (false);
            }
            // 伝票番号チェック

            // 入力担当チェック
            if (this.tEdit_EmployeeCode.DataText.Trim() == "")
            {
                errMsg = "入力担当が入力されていません。";
                this.tEdit_EmployeeCode.Focus();
                return (false);
            }
            string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();
            if (this._adjustStockAcs.GetEmployeeName(employeeCode) == "")
            {
                errMsg = "入力担当コードがマスタに登録されていません。";
                this.tEdit_EmployeeCode.Focus();
                return (false);
            }

            bool bExist = false;
            DataRow dataRow = null;
            for (int index = 0; index < AdjustStockAcs.ProductStockDataTable.Rows.Count; index++)
            {
                dataRow = AdjustStockAcs.ProductStockDataTable.Rows[index];

                if ((dataRow[AdjustStockAcs.ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)dataRow[AdjustStockAcs.ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                bExist = true;

                // 仕入数
                double salesOrderUnit = DoubleObjToDouble(dataRow[AdjustStockAcs.ctCOL_SalesOrderUnit]);

                if (salesOrderUnit == 0)
                {
                    errMsg = "仕入数が入力されていません。";
                    this.StockGrid.Focus();
                    this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Activate();
                    this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

                    return (false);
                }

                // ADD 2010.05.19 zhangsf FOR Redmine #7935 *-------------------->>>
                if (salesOrderUnit < 0
                    && MyOpeCtrl.Disabled(12)) // ADD 2010/05/20
                {
                    //errMsg = "不正な値が存在するため、登録できません。\r\n" + index + "行目の数量がマイナスです。"; // DEL 2010/05/20
                    errMsg = (index + 1) + "行目の数量がマイナスです。"; // ADD 2010/05/20
                    this.StockGrid.Focus();
                    this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Activate();
                    this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

                    return (false);
                }
                // ADD 2010.05.19 zhangsf FOR Redmine #7935 <<<--------------------*

                // 発注残
                double orderRemainCnt = StringObjToDouble(dataRow[AdjustStockAcs.ctCOL_SalesOrderCount]);

                if (this._orderListResultFlg)
                {
                    if (salesOrderUnit < 0)
                    {
                        errMsg = "発注計上時は数量のマイナスは入力できません。";
                        this.StockGrid.Focus();
                        this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Activate();
                        this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                        this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Value = orderRemainCnt;
                        return (false);
                    }
                    else if (salesOrderUnit > orderRemainCnt)
                    {
                        errMsg = "発注残数以上の仕入は行えません。";
                        this.StockGrid.Focus();
                        this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Activate();
                        this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                        this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Value = orderRemainCnt;
                        return (false);
                    }
                }
            }
            if (bExist == true)
            {
                return (true);
            }
            else
            {
                errMsg = "在庫情報が入力されていません。";
                this.StockGrid.Rows[0].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                return (false);
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        public bool CompareScreen()
        {
            if (this.makedate_tDateEdit.GetDateTime() != DateTime.Today)
            {
                return (false);
            }

            if (this.tEdit_SectionCode.DataText.Trim() != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
            {
                return (false);
            }

            if (this.tEdit_WarehouseCode.DataText.Trim() != "")
            {
                return (false);
            }

            if (this.tEdit_EmployeeCode.DataText.Trim() != LoginInfoAcquisition.Employee.EmployeeCode.Trim())
            {
                return (false);
            }

            for (int index = 0; index < this.StockGrid.Rows.Count; index++)
            {
                // 品番
                if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString() != "")
                {
                    return (false);
                }
                // 標準価格
                if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_ListPriceFl].Value.ToString() != "")
                {
                    return (false);
                }
                // 原単価
                if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_StockUnitPrice].Value.ToString() != "")
                {
                    return (false);
                }
                // 仕入数
                if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Value.ToString() != "")
                {
                    return (false);
                }
                // 明細備考
                if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_DtlNote].Value.ToString() != "")
                {
                    return (false);
                }
            }

            if (this.edtNote1.DataText.Trim() != "")
            {
                return (false);
            }

            return (true);
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public int CheckInputData(object sender)
        {
            if (makedate_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                return 1;
            }
            SetEmployeeCode();
            if (String.IsNullOrEmpty(_employee.EmployeeCode))
            {
                return -3;
            }

            bool bExist = false;
            DataRow dataRow = null;
            for (int i = 0; i < AdjustStockAcs.ProductStockDataTable.Rows.Count; i++)
            {
                dataRow = AdjustStockAcs.ProductStockDataTable.Rows[i];

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((dataRow[AdjustStockAcs.ctCOL_GoodsCode] == System.DBNull.Value))
                if ((dataRow[AdjustStockAcs.ctCOL_GoodsNo] == System.DBNull.Value))
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    continue;
                }

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((string)dataRow[AdjustStockAcs.ctCOL_GoodsCode] != "")
                if ((string)dataRow[AdjustStockAcs.ctCOL_GoodsNo] != "")
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    bExist = true;

                    if (GetEditerMode() == 0)
                    {
                        //調整入力なのに、調整数0
                        if (dataRow[AdjustStockAcs.ctCOL_AdjustCount] == System.DBNull.Value)
                        {
                            return -2;
                        }
                        if ((double)dataRow[AdjustStockAcs.ctCOL_AdjustCount] == 0)
                        {
                            return -2;
                        }
                    }
                }
            }
            if (bExist != false)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #endregion

        #region IStockEntryTbsCtrlChildResponse メンバ
        /// <summary>
		/// 親アクション対応処理
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="targetInstance">対応対象オブジェクト</param>
		/// <param name="actionKey">アクション識別キー</param>
		/// <param name="param">アクションパラメータ</param>
		/// <returns>ステータス</returns>
		public int ChildResponse(object sender, object targetInstance, string actionKey, object param)
		{
			int st = 0;

			// このインスタンスへの要求かどうかの判定
			if (targetInstance.Equals(this))
			{
			}

			return st;
		}
		#endregion
		#endregion

		//--------------------------------------------------------
		//  コントロールイベントハンドラ
		//--------------------------------------------------------
		#region コントロールイベントハンドラ

		/// <summary>
		/// 総額表示方法コンボボックス値変更イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void cmbTotalAmountDispWay_ValueChanged(object sender, EventArgs e)
		{
			// イベント制御判定
			if (_localEventBlockFlg) return;

			// グリッド行表示設定
			this.SettingGridRowEditor();
		}

		/// <summary>
		/// ツールバードロップダウン前イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ToolbarsManager_Main_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
		{
			// ドロップダウンする前に各メニューアイテムの状態を設定する
			if ((e.Tool.Key == "PopupMenuTool_Edit") && (e.Tool is PopupMenuTool))
			{
				PopupMenuTool popupMenu = (PopupMenuTool)e.Tool;

				// メニューアイテム設定
				Boolean dispFlg = false;

				bool rowSelected = (this.StockGrid.Selected.Rows.Count > 0);

				dispFlg |= rowSelected;

				// メニューを表示可能か？
				e.Cancel = (!dispFlg);

				if (!e.Cancel)
				{
					// IMEモードをOFFにする ⇒ ショートカットキーを有効にするため
					this.StockGrid.ImeMode = ImeMode.Off;
				}
			}
		}

		/// <summary>
		/// ツールバークローズアップ後イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ToolbarsManager_Main_AfterToolCloseup(object sender, ToolDropdownEventArgs e)
		{
			if (e.Tool.Key == "PopupMenuTool_Edit")
			{
				PopupMenuTool popupMenu = e.Tool as PopupMenuTool;
			}
		}

		/// <summary>
		/// 明細グリッド選択状態変更後イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
		{
			bool rowSelected = (this.StockGrid.Selected.Rows.Count > 0);

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            if (this.tNedit_SupplierSlipNo.Enabled == true)
            {
                this.RowDelete_ultraButton.Enabled = true;
            }
            else
            {
                this.RowDelete_ultraButton.Enabled = false;
            }
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// 入力補助エクスプローラバーアイテムクリックイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ExplorerBar_InputHelp_ItemClick(object sender, ItemEventArgs e)
		{
            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            // 行選択している場合、その行の明細種別をActiveにしておく
            if (this.StockGrid.Selected.Rows.Count > 0)
            {
                int row = this.StockGrid.Selected.Rows[0].Index;

                this.StockGrid.Selected.Rows.Clear();
            }

            //this.InputHelperItemExecute(e.Item.Key);
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// ツールバークリックイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
		{
			int st;
			string msg;
			Cursor bufCursor = Cursor.Current;

			switch (e.Tool.Key)
			{
				//--------------------------------------------------------
				//  行挿入
				//--------------------------------------------------------
				case "ButtonTool_InsRow":
					if (this.StockGrid.Selected.Rows.Count == 0)
					{
						if (this.StockGrid.ActiveRow != null)
						{
							// 行挿入位置の確定
							int wkRowIndex = this.StockGrid.ActiveRow.Index;

							//st = AdjustStockAcs.InsertBlankSlipDtl(wkRowIndex, out msg);
                            st = 0;
                            msg = "aa";

							if (st != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
							{
								TMsgDisp.Show(
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									ctPGID,
									msg,
									st,
									MessageBoxButtons.OK);
							}
						}
					}
					else
					{
						// 連続選択行数分を連続選択先頭行の直前に挿入する
						int[] dstRow = new int[this.StockGrid.Selected.Rows.Count];

						// 選択行インデックスリストを作成
						for (int i = 0; i < this.StockGrid.Selected.Rows.Count; i++)
						{
							dstRow[i] = this.StockGrid.Selected.Rows[i].Index;
						}

						// 一応ソート
						Array.Sort<int>(dstRow);

						int selectedCount = 0;		// 連続選択行数

						// 行末から処理
						for (int i = dstRow.Length - 1; i >= 0; i--)
						{
							// 連続選択行数インクリメント
							selectedCount++;

							// 最上段 or 連続選択先頭行なら行挿入
							if ((i == 0) || (dstRow[i - 1] != (dstRow[i] - 1)))
							{
								// 複数空白行挿入
								//st = AdjustStockAcs.InsertBlankSlipDtl(dstRow[i], selectedCount, out msg);
                                msg = "aa";
                                st = 0;

								if (st != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
								{
									TMsgDisp.Show(
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										ctPGID,
										msg,
										st,
										MessageBoxButtons.OK);
									return;
								}

								// 連続選択行数クリア
								selectedCount = 0;
							}
						}
					}

					break;
				//--------------------------------------------------------
				//  初期表示状態
				//--------------------------------------------------------
				case "ButtonTool_DefaultDisp":
					_colDispInfo.SetDefaultValue();

					this._canColResizeFlg = false;
					try
					{
						// 文字サイズを11に戻す
						this.cmbGridFont.Value = _colDispInfo.FontSize;
					}
					finally
					{
						this._canColResizeFlg = true;
					}

					// 現在の設定を元に総額表示切替を行う
					this.cmbTotalAmountDispWay_ValueChanged(this, EventArgs.Empty);

					break;
			}
		}

		/// <summary>
		/// フォントサイズ値変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void cmbGridFont_ValueChanged(object sender, EventArgs e)
		{
			// 文字サイズを変更
            StockGrid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.cmbGridFont.SelectedItem.DataValue;

			// 列幅の調整
			if (this._canColResizeFlg)
				this.timFontChange.Enabled = true;
		}

		/// <summary>
		/// フォントサイズ変更タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void timFontChange_Tick(object sender, EventArgs e)
		{
			// タイマー起動をOFFにする
			this.timFontChange.Enabled = false;

			// 列幅の調整
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.StockGrid.BeginUpdate();

			}
			finally
			{
				this.StockGrid.EndUpdate();
				this.Cursor = Cursors.Default;
			}
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 画面入力欄エンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Edit_Enter(object sender, EventArgs e)
		{
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
		/// RetKeyControllフォーカス変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <br>Update Note  : 2009/12/16 朱俊成</br>
        /// <br>               PM.NS-5</br>
        /// <br>               在庫仕入入力で標準価格と原単価の入力制御の修正</br>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":   // 拠点コード
                    if (this.tEdit_SectionCode.DataText.Trim() == "")
                    {
                        if (CheckChangeSection(this.tEdit_SectionCode.DataText.Trim()) == false)
                        {
                            // 変更せず
                            if (this._prevSectionCode.Trim() != "")
                            {
                                this.tEdit_SectionCode.Value = this._prevSectionCode.Trim().PadLeft(2, '0');
                                this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(this._prevSectionCode.Trim().PadLeft(2, '0'));
                            }
                            else
                            {
                                this.tEdit_SectionCode.Value = this._prevSectionCode.Trim();
                                this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(this._prevSectionCode.Trim());
                            }
                            break;
                        }

                        this.uLabel_SectionName.Text = "";
                        this._prevSectionCode = "";

                        // グリッド初期化
                        _adjustStockAcs.DBDataClear();

                        AdjustStockAcs.RepaintProductStock();

                        //金額・合計初期化
                        edtNote1.Text = "";
                        lbltotalCount.Text = "0.00";
                        lblTotalPrice.Text = "0";

                        this._orderListResultFlg = false;
                        this._searchFlg = false;
                        // --- ADD 2009/12/16 ---------->>>>>
                        // 定価入力区分取得処理
                        GetListPriceInpDiv();
                        // 単価入力区分取得処理
                        GetUnitPriceInpDiv();
                        // --- ADD 2009/12/16 ----------<<<<<
                        break;
                    }

                    // 拠点コード取得
                    string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                    if (this._searchFlg)
                    {
                        if (CheckChangeSection(sectionCode) == false)
                        {
                            // 変更せず
                            if (this._prevSectionCode.Trim() != "")
                            {
                                this.tEdit_SectionCode.Value = this._prevSectionCode.Trim().PadLeft(2, '0');
                            }
                            else
                            {
                                this.tEdit_SectionCode.Value = this._prevSectionCode.Trim();
                            }
                            break;
                        }

                        // グリッド初期化
                        _adjustStockAcs.DBDataClear();

                        AdjustStockAcs.RepaintProductStock();

                        //金額・合計初期化
                        edtNote1.Text = "";
                        lbltotalCount.Text = "0.00";
                        lblTotalPrice.Text = "0";

                        this._orderListResultFlg = false;
                        this._searchFlg = false;
                    }

                    // 拠点名称取得
                    this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(sectionCode);

                    if (this.uLabel_SectionName.Text.Trim() == "")
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                              ctPGID,
                              "拠点コードがマスタに登録されていません。",
                              0,
                              MessageBoxButtons.OK);

                        e.NextCtrl = e.PrevCtrl;
                        this.tEdit_SectionCode.SelectAll();
                        break;
                    }

                    this._prevSectionCode = sectionCode;

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // フォーカス設定
                            if (this.uLabel_SectionName.Text.Trim() != "")
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
                            }
                        }
                    }
                    // --- ADD 2009/12/16 ---------->>>>>
                    // 定価入力区分取得処理
                    GetListPriceInpDiv();
                    // 単価入力区分取得処理
                    GetUnitPriceInpDiv();
                    // --- ADD 2009/12/16 ----------<<<<<
                    break;
                case "tEdit_WarehouseCode": // 倉庫コード
                    // 倉庫コード取得
                    string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

                    if (this.tEdit_WarehouseCode.DataText.Trim() == "")
                    {
                        if (CheckChangeWarehouse(this.tEdit_WarehouseCode.DataText.Trim()) == false)
                        {
                            // 変更せず
                            if (this._prevWarehouseCode != "")
                            {
                                this.tEdit_WarehouseCode.Value = this._prevWarehouseCode.Trim().PadLeft(4, '0');
                                this.uLabel_WarehouseName.Text = this._adjustStockAcs.GetWarehouseName(this._prevWarehouseCode.Trim().PadLeft(4, '0'));
                            }
                            else
                            {
                                this.tEdit_WarehouseCode.Value = this._prevWarehouseCode.Trim();
                                this.uLabel_WarehouseName.Text = this._adjustStockAcs.GetWarehouseName(this._prevWarehouseCode.Trim());
                            }
                            break;
                        }

                        this.uLabel_WarehouseName.Text = "";
                        this._prevWarehouseCode = "";

                        // グリッド初期化
                        _adjustStockAcs.DBDataClear();

                        AdjustStockAcs.RepaintProductStock();

                        //金額・合計初期化
                        edtNote1.Text = "";
                        lbltotalCount.Text = "0.00";
                        lblTotalPrice.Text = "0";

                        this._orderListResultFlg = false;
                        this._searchFlg = false;

                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uLabel_SectionName.Text.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.StockGrid;
                            }
                        }

                        break;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            if (CheckChangeWarehouse(warehouseCode) == false)
                            {
                                // 変更せず
                                if (this._prevWarehouseCode != "")
                                {
                                    this.tEdit_WarehouseCode.Value = this._prevWarehouseCode.Trim().PadLeft(4, '0');
                                }
                                else
                                {
                                    this.tEdit_WarehouseCode.Value = this._prevWarehouseCode.Trim();
                                }
                                break;
                            }

                            // グリッド初期化
                            _adjustStockAcs.DBDataClear();

                            AdjustStockAcs.RepaintProductStock();

                            //金額・合計初期化
                            edtNote1.Text = "";
                            lbltotalCount.Text = "0.00";
                            lblTotalPrice.Text = "0";

                            this._orderListResultFlg = false;
                            this._searchFlg = false;
                        }

                        // 倉庫名称取得
                        this.uLabel_WarehouseName.Text = this._adjustStockAcs.GetWarehouseName(warehouseCode);

                        if (this.uLabel_WarehouseName.Text.Trim() == "")
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      ctPGID,
                                      "倉庫コードがマスタに登録されていません。",
                                      0,
                                      MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                            this.tEdit_WarehouseCode.SelectAll();

                            break;
                        }
                        else
                        {
                            this._prevWarehouseCode = warehouseCode;

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                }
                                else if (e.Key == Keys.Down)
                                {
                                    e.NextCtrl = this.StockGrid;
                                }
                            }
                        }

                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uLabel_SectionName.Text.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                    }
                    break;
                case "tEdit_EmployeeCode":  // 従業員コード
                    if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                    {
                        this.uLabel_StockAgentName.Text = "";
                        break;
                    }

                    // 従業員コード
                    string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();

                    // 従業員名称取得
                    this.uLabel_StockAgentName.Text = this._adjustStockAcs.GetEmployeeName(employeeCode);

                    if (this.uLabel_StockAgentName.Text.Trim() == "")
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ctPGID,
                                  "入力担当コードがマスタに登録されていません。",
                                  0,
                                  MessageBoxButtons.OK);

                        e.NextCtrl = e.PrevCtrl;
                        this.tEdit_EmployeeCode.SelectAll();

                        break;
                    }

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // フォーカス設定
                            if (this.uLabel_StockAgentName.Text.Trim() != "")
                            {
                                e.NextCtrl = this.GoodsSearch_ultraButton;
                            }
                        }
                        else if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = this.StockGrid;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uLabel_WarehouseName.Text.Trim() != "")
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
                            }
                        }
                    }
                    break;
                case "WarehouseGuide_uButton":
                case "uButton_EmployeeGuide":
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = this.StockGrid;
                        }
                    }
                    break;
                case "tNedit_SupplierSlipNo":
                    {
                        if (this.tNedit_SupplierSlipNo.GetInt() == 0)
                        {
                            break;
                        }

                        // 在庫調整伝票番号取得
                        int stockAdjustSlipNo = this.tNedit_SupplierSlipNo.GetInt();

                        // 在庫調整伝票情報表示
                        int status = DispStockAdjustSlipInfo(stockAdjustSlipNo, true);//add 2011/12/13 陳建明 Redmine #26816
                        //int status = DispStockAdjustSlipInfo(stockAdjustSlipNo); //del 2011/12/13 陳建明 Redmine #26816
                        if (status == 0)
                        {
                            // フォーカス設定
                            e.NextCtrl = this.tEdit_SectionCode;
                        }
                        else
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                          ctPGID,
                                          "該当するデータが存在しません。",
                                          0,
                                          MessageBoxButtons.OK);

                            this.tNedit_SupplierSlipNo.Clear();
                            e.NextCtrl = this.tNedit_SupplierSlipNo;
                        }
                        break;
                    }
                /*---- DEL 2010/05/20 -------------------------------------
                case "edtNote1":    // 伝票備考
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.edtNote1.DataText.Trim() != "")
                            {
                                if (this.makedate_tDateEdit.Enabled == true)
                                {
                                    e.NextCtrl = this.makedate_tDateEdit;
                                }
                                else
                                {
                                    e.NextCtrl = this.StockGrid;
                                }
                            }
                        }
                    }
                    break;
                ---- DEL 2010/05/20 -------------------------------------*/ 
                case "StockGrid":   // グリッド
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            // 編集モード終了
                            this.StockGrid.PerformAction(UltraGridAction.ExitEditMode);




                            // --- ADD 2010/02/05 ---------->>>>>
                            if (null != this.StockGrid.ActiveCell)
                            {
                            // --- ADD 2010/02/05 ----------<<<<<
                                if ((this.StockGrid.ActiveCell.Row.Index == this.StockGrid.Rows.Count - 1) &&
                                    (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_DtlNote))
                                {
                                    e.NextCtrl = this.edtNote1;
                                }
                                else
                                {
                                    if (this._warehouseCodeFocusFlg == true)
                                    {
                                        this._warehouseCodeFocusFlg = false;

                                        e.NextCtrl = this.tEdit_WarehouseCode;

                                        //空白入力なので、入力行の情報をクリア
                                        this._adjustStockAcs.ClrRowData(this.StockGrid.ActiveCell.Row.Index);
                                    }
                                    else
                                    {
                                        e.NextCtrl = null;

                                        // ----- ADD 2010/05/20 --------------------->>>>>
                                        if (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_SalesOrderUnit
                                            && MyOpeCtrl.Disabled(12)
                                            && DoubleObjToDouble(this.StockGrid.ActiveCell.Value) < 0
                                            && this.StockGrid.ActiveCell.DataChanged)
                                        {
                                            this.StockGrid.Rows[this.StockGrid.ActiveCell.Row.Index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Value = this.StockGrid.Rows[this.StockGrid.ActiveCell.Row.Index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].OriginalValue;
                                            this.StockGrid.Rows[this.StockGrid.ActiveCell.Row.Index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Activate();
                                            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        // ----- ADD 2010/05/20 ---------------------<<<<<
                                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                                        //if (this._stockExistFlg == false)
                                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                                        if (!ExistsStockWithEvents) // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                                        {
                                            this._stockExistFlg = true; // 単純にリセット

                                            this.StockGrid.Rows[this.StockGrid.ActiveCell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                                            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            this.StockGrid.PerformAction(UltraGridAction.NextCellByTab);
                                            // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                                            // HACK:
                                            StockGrid_AfterRowActivate(this, null);
                                            // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                                        }
                                    }
                                }
                            // --- ADD 2010/02/05 ---------->>>>>
                            }
                            // --- ADD 2010/02/05 ----------<<<<<
                            break;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            // 編集モード終了
                            this.StockGrid.PerformAction(UltraGridAction.ExitEditMode);

                            // --- UPD 2010/02/05 -------------->>>
                            //if ((this.StockGrid.ActiveCell.Row.Index == 0) &&
                            //    (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo))
                            if ((null != this.StockGrid.ActiveCell) &&
                                (this.StockGrid.ActiveCell.Row.Index == 0) &&
                                (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo))
                            // --- UPD 2010/02/05 --------------<<<
                            {
                                if (this._warehouseCodeFocusFlg == true)
                                {
                                    this._warehouseCodeFocusFlg = false;

                                    e.NextCtrl = this.tEdit_WarehouseCode;

                                    //空白入力なので、入力行の情報をクリア
                                    this._adjustStockAcs.ClrRowData(this.StockGrid.ActiveCell.Row.Index);
                                }
                                else
                                {
                                    e.NextCtrl = this.GoodsSearch_ultraButton;
                                }
                            }
                            else
                            {
                                e.NextCtrl = null;
                                this.StockGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            }
                            break;
                        }
                    }
                    break;
                case "GoodsSearch_ultraButton": // 在庫検索ボタン
                    if (e.ShiftKey == true)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uLabel_StockAgentName.Text.Trim() != "")
                            {
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                        }
                    }
                    break;
                // 2009.04.02 30413 犬飼 Enterで保存処理実行を追加 >>>>>>START
                case "SlipNoteGuide_uButton":   // 備考ガイドボタン
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Return)
                            {
                                e.NextCtrl = e.PrevCtrl;

                                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                                ctPGID,
                                                                "登録してもよろしいですか？",
                                                                0,
                                                                MessageBoxButtons.YesNo);

                                if (dr == DialogResult.Yes)
                                {
                                    e.NextCtrl = null;
                                    // 保存処理
                                    save();
                                }
                            }
                        }
                        else
                        {
                            
                        }
                        break;
                    }
                // 2009.04.02 30413 犬飼 Enterで保存処理実行を追加 <<<<<<END
            }

            if (e.NextCtrl == null)
            {
                changeFocusFooter(false);
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // グリッド
                case "StockGrid":
                    {
                        changeFocusFooter(false);

                        if (this.tNedit_SupplierSlipNo.Enabled == true)
                        {
                            this.RowDelete_ultraButton.Enabled = true;
                        }
                        else
                        {
                            this.RowDelete_ultraButton.Enabled = false;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.StockGrid.Focus();
                                this.StockGrid.Rows[0].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.StockGrid.Focus();
                                if (tNedit_SupplierSlipNo.Enabled)
                                {
                                    this.StockGrid.Rows[this.StockGrid.Rows.Count - 1].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                                }
                                else
                                {
                                    this.StockGrid.Rows[this.StockGrid.Rows.Count - 1].Cells[AdjustStockAcs.ctCOL_ListPriceFl].Activate();
                                }
                                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }

                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.StockGrid.Focus();
                                this.StockGrid.Rows[this.StockGrid.Rows.Count - 1].Cells[AdjustStockAcs.ctCOL_DtlNote].Activate();
                                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        break;
                    }
                default:
                    {
                        if ((e.NextCtrl.Name == "edtNote1") || (e.NextCtrl.Name == "SlipNoteGuide_uButton") || (e.NextCtrl.Name == "cmbGridFont"))
                        {
                            changeFocusFooter(true);
                        }
                        else
                        {
                            changeFocusFooter(false);
                        }
                        this.RowDelete_ultraButton.Enabled = false;
                        break;
                    }
            }
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            //------------- ADD 2011/07/18 ------------------------ >>>>>
            if ((e.PrevCtrl != null) && (e.PrevCtrl.Name == "StockGrid") && (e.NextCtrl != null) && (e.NextCtrl.Name != "StockGrid"))
            {
                //------------- ADD 2021/10/07 ------------------------ >>>>>
                if (PreviousRowIndex >= 0)
                {
                    this.StockGrid.PerformAction(UltraGridAction.ExitEditMode);
                    int maker = this._adjustStockAcs.StringObjToInt(this.StockGrid.Rows[PreviousRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value);
                    this._adjustStockAcs.SetAfSalesOrderUnit(maker, this.StockGrid.Rows[PreviousRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString());
                }
                //------------- ADD 2021/10/07 ------------------------ <<<<<
            }
            //------------- ADD 2011/07/18 ------------------------ <<<<<
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="TempCheck">チェック有無</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面を初期化</br>
        /// <br>Programer  : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.02.09</br>
        /// </remarks>
        private void AllDispClear(bool TempCheck)
        {
            this.makedate_tDateEdit.SetDateTime(DateTime.Today);

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            this.tEdit_EmployeeCode.DataText = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this.uLabel_StockAgentName.Text = this._adjustStockAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode.Trim());
            this.tEdit_WarehouseCode.Clear();
            this.uLabel_WarehouseName.Text = "";
            this.tNedit_SupplierSlipNo.Clear();
            //this.uLabel_LastSalesSlipNum.Text = "";
            this.edtNote1.Clear();

            this._employee = LoginInfoAcquisition.Employee;
            this._prevEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this._prevSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this._prevWarehouseCode = "";
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }       

		#endregion

		//--------------------------------------------------------
		//  明細入力グリッドイベントハンドラ
		//--------------------------------------------------------
		#region 明細入力グリッドイベントハンドラ
		/// <summary>
		/// Gridエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Gridにフォーカスがきた時に発動します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void StockGrid_Enter(object sender, EventArgs e)
		{
			if (this.StockGrid.ActiveCell == null)
			{
				this.StockGrid.PerformAction(UltraGridAction.ActivateCell);
                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
			}
			else
			{
				if (!this.StockGrid.ActiveCell.IsInEditMode)
				{
					this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
				}

                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
                // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
                this.RowDelete_ultraButton.Enabled = true;
                // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            }

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            if (this.tNedit_SupplierSlipNo.Enabled == true)
            {
                this.RowDelete_ultraButton.Enabled = true;
            }
            else
            {
                this.RowDelete_ultraButton.Enabled = false;
            }
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// Gridアクション処理後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
		{
            switch (e.UltraGridAction)
            {
                case UltraGridAction.ActivateCell:
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.PrevCell:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    // アクティブなセルがあるか？
                    if (this.StockGrid.ActiveCell != null)
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.StockGrid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                // 編集モードにある？
                                if (this.StockGrid.PerformAction(UltraGridAction.EnterEditMode))
                                {
                                    // 全選択状態にする。
                                    this.StockGrid.ActiveCell.SelStart = 0;
                                    this.StockGrid.ActiveCell.SelLength = this.StockGrid.ActiveCell.Text.Length;
                                }
                                break;
                            default:
                                // エディット系以外のスタイルであれば、編集状態にする。
                                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                        }
                    }
                    break;
            }
            
            // 強制再描画
            if (this.StockGrid.ActiveRow != null)
            {
                if (this._forceRepaintGridFlag)
                {
                    this._forceRepaintGridFlag = false;

                    System.Windows.Forms.Application.DoEvents();
                    this.SettingGridRowEditor(this.StockGrid.ActiveRow.Index);
                }
            }

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            if (this._warehouseCodeFocusFlg == true)
            {
                this._warehouseCodeFocusFlg = false;

                this.tEdit_WarehouseCode.Focus();

                this.StockGrid.ActiveCell = null;
                this.StockGrid.ActiveRow = null;
            }
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// Gridキーダウンイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_KeyDown(object sender, KeyEventArgs e)
		{
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }


            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (this._warehouseCodeFocusFlg == true)
                        {
                            this._warehouseCodeFocusFlg = false;

                            e.Handled = true;

                            //空白入力なので、入力行の情報をクリア
                            this._adjustStockAcs.ClrRowData(rowIndex);

                            this.tEdit_WarehouseCode.Focus();
                            return;
                        }

                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        //if (this._stockExistFlg == false)
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        if (!ExistsStockWithEvents) // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                        {
                            this._stockExistFlg = true; // 単純にリセット

                            e.Handled = true;

                            uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == 0)
                        {
                            this.GoodsSearch_ultraButton.Focus();
                            //------------- ADD 2011/07/18 ------------------------ >>>>>
                            int maker = this._adjustStockAcs.StringObjToInt(uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value);
                            this._adjustStockAcs.SetAfSalesOrderUnit(maker, uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString());
                            //------------- ADD 2011/07/18 ------------------------ <<<<<
                        }
                        else
                        {
                            uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (this._warehouseCodeFocusFlg == true)
                        {
                            this._warehouseCodeFocusFlg = false;

                            e.Handled = true;

                            //空白入力なので、入力行の情報をクリア
                            this._adjustStockAcs.ClrRowData(rowIndex);

                            this.tEdit_WarehouseCode.Focus();
                            return;
                        }

                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        //if (this._stockExistFlg == false)
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        if (!ExistsStockWithEvents) // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                        {
                            this._stockExistFlg = true; // 単純にリセット
                                
                            e.Handled = true;

                            uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            this.edtNote1.Focus();
                            //------------- ADD 2011/07/18 ------------------------ >>>>>
                            int maker = this._adjustStockAcs.StringObjToInt(uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value);
                            this._adjustStockAcs.SetAfSalesOrderUnit(maker, uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString());
                            //------------- ADD 2011/07/18 ------------------------ <<<<<
                        }
                        else
                        {
                            uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return;
                    }
                case Keys.Left:
                    {
                        // --- UPD 2010/02/05 -------------->>>
                        //if (uGrid.ActiveCell.IsInEditMode)
                        if ((null != uGrid.ActiveCell) && (uGrid.ActiveCell.IsInEditMode))
                        // --- UPD 2010/02/05 --------------<<<
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                // 編集モード終了
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if (this._warehouseCodeFocusFlg == true)
                                {
                                    this._warehouseCodeFocusFlg = false;

                                    e.Handled = true;

                                    //空白入力なので、入力行の情報をクリア
                                    this._adjustStockAcs.ClrRowData(rowIndex);

                                    this.tEdit_WarehouseCode.Focus();
                                    return;
                                }

                                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                                //if (this._stockExistFlg == false)
                                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                                if (!ExistsStockWithEvents) // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                                {
                                    this._stockExistFlg = true; // 単純にリセット

                                    e.Handled = true;

                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                if ((rowIndex == 0) && (uGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo))
                                {
                                    uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        
                        return;
                    }
                case Keys.Right:
                    {
                        // --- UPD 2010/02/05 -------------->>>
                        //if (uGrid.ActiveCell.IsInEditMode)
                        if ((null != uGrid.ActiveCell) && (uGrid.ActiveCell.IsInEditMode))
                        // --- UPD 2010/02/05 --------------<<<
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                // 編集モード終了
                                uGrid.PerformAction(UltraGridAction.ExitEditMode);

                                if (this._warehouseCodeFocusFlg == true)
                                {
                                    this._warehouseCodeFocusFlg = false;

                                    e.Handled = true;

                                    //空白入力なので、入力行の情報をクリア
                                    this._adjustStockAcs.ClrRowData(rowIndex);

                                    this.tEdit_WarehouseCode.Focus();
                                    return;
                                }

                                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                                //if (this._stockExistFlg == false)
                                // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                                if (!ExistsStockWithEvents) // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                                {
                                    this._stockExistFlg = true; // 単純にリセット

                                    e.Handled = true;

                                    uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }

                                if ((rowIndex == uGrid.Rows.Count - 1) && (uGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_DtlNote))
                                {
                                    uGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_DtlNote].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    uGrid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        return;
                    }
                case Keys.Escape:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            UltraGridCell cell = uGrid.ActiveCell;
                            uGrid.ActiveCell = null;
                            if (cell.Row.Index != uGrid.Rows.Count - 1)
                            {
                                uGrid.Rows[cell.Row.Index + 1].Activate();
                            }
                            else
                            {
                                uGrid.Rows[cell.Row.Index - 1].Activate();
                            }
                            uGrid.Rows[cell.Row.Index].Activate();
                            uGrid.ActiveCell = cell;
                            e.Handled = true;
                        }
                        break;
                    }
            }
		}

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }


        /// <summary>
        /// Gridキープレスイベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : グリッド上でキーが押されたときに発生します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.StockGrid.ActiveCell == null)
            {
                return;
            }

            // 入力中のグリッドセルオブジェクトを取得
            UltraGridCell cell = this.StockGrid.ActiveCell;

            // 編集モード中？
            if (this.StockGrid.ActiveCell.IsInEditMode)
            {
                string retText;
                string targetText = this.StockGrid.ActiveCell.Text;

                switch (this.StockGrid.ActiveCell.Column.Key)
                {
                    case AdjustStockAcs.ctCOL_GoodsNo:
                        if (cell.IsInEditMode)
                        {
                            // UI設定を参照
                            if (uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    case AdjustStockAcs.ctCOL_ListPriceFl:  // 標準価格
                        // 「Backspace」キーを押された時
                        if ((byte)e.KeyChar == (byte)'\b')
                        {
                            return;
                        }

                        // ActiveCellが標準価格の場合
                        // セルのテキストが選択されている場合
                        if (this.StockGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                e.KeyChar = '\0';
                            }
                        }
                        else
                        {
                            // カンマ、ピリオド削除
                            RemoveCommaPeriod(targetText, out retText, true);

                            // 文字数が9文字だったら入力不可
                            if (retText.Length == 7)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {
                                // 数値以外の時
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    // 入力値の1文字目は「,」不可
                                    if (targetText == "")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                    else
                                    {
                                        // 「,」は入力可
                                        if ((byte)e.KeyChar != ',')
                                        {
                                            e.KeyChar = '\0';
                                        }

                                        if (targetText[targetText.Length - 1].ToString() == ",")
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case AdjustStockAcs.ctCOL_StockUnitPrice:   // 原単価
                        // 「Backspace」キーを押された時
                        if ((byte)e.KeyChar == (byte)'\b')
                        {
                            return;
                        }
                        // セルのテキストが選択されている場合
                        if (this.StockGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                e.KeyChar = '\0';
                            }
                        }
                        else
                        {
                            // カンマ、ピリオド削除
                            RemoveCommaPeriod(targetText, out retText, true);

                            // 文字数が11文字だったら入力不可
                            if (retText.Length == 9)
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {
                                // 数値以外の時
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    // 入力値の1文字目は「,」「.」不可
                                    if (targetText == "")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                    else
                                    {
                                        if (targetText.IndexOf(".") >= 0)
                                        {
                                            e.KeyChar = '\0';
                                        }

                                        if (targetText[targetText.Length - 1].ToString() == ",")
                                        {
                                            e.KeyChar = '\0';
                                        }

                                        // カンマ、ピリオド削除
                                        RemoveCommaPeriod(targetText, out retText, true);

                                        if (retText.Length == 7)
                                        {
                                            if ((byte)e.KeyChar != '.')
                                            {
                                                e.KeyChar = '\0';
                                            }
                                        }

                                        // 「,」「.」は入力可
                                        if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        // 小数点取得
                                        GetDecimal(targetText, out retText);

                                        if (retText.Length == 2)
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                    else
                                    {
                                        // カンマ、ピリオド削除
                                        RemoveCommaPeriod(targetText, out retText, true);

                                        if (retText.Length == 7)
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case AdjustStockAcs.ctCOL_SalesOrderUnit:   // 仕入数
                        // 「Backspace」キーを押された時
                        if ((byte)e.KeyChar == (byte)'\b')
                        {
                            return;
                        }
                        // セルのテキストが選択されている場合
                        if (this.StockGrid.ActiveCell.SelText == targetText)
                        {
                            // 数値のみ入力可
                            // 数値のみ入力可
                            if ((byte)e.KeyChar != (byte)'-')
                            {
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    e.KeyChar = '\0';
                                }
                            }
                        }
                        else
                        {
                            // カンマ、ピリオド削除
                            RemoveCommaPeriod(targetText, out retText, true);

                            // 文字数が10文字だったら入力不可
                            if ((retText[0] != '-') && (retText.Length == 10))
                            {
                                e.KeyChar = '\0';
                            }
                            else if ((retText[0] == '-') && (retText.Length == 11))
                            {
                                e.KeyChar = '\0';
                            }
                            else
                            {
                                // 数値以外の時
                                if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                                {
                                    // 入力値の1文字目は「,」「.」不可
                                    if (targetText == "")
                                    {
                                        if ((byte)e.KeyChar != (byte)'-')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                    else
                                    {
                                        if (targetText.IndexOf(".") >= 0)
                                        {
                                            e.KeyChar = '\0';
                                        }

                                        if (targetText[targetText.Length - 1].ToString() == ",")
                                        {
                                            e.KeyChar = '\0';
                                        }

                                        // カンマ、ピリオド削除
                                        RemoveCommaPeriod(targetText, out retText, true);

                                        if ((retText[0] != '-') && (retText.Length == 8))
                                        {
                                            if ((byte)e.KeyChar != '.')
                                            {
                                                e.KeyChar = '\0';
                                            }
                                        }
                                        else if ((retText[0] == '-') && (retText.Length == 9))
                                        {
                                            if ((byte)e.KeyChar != '.')
                                            {
                                                e.KeyChar = '\0';
                                            }
                                        }

                                        // 「,」「.」は入力可
                                        if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        // 小数点取得
                                        GetDecimal(targetText, out retText);

                                        if (retText.Length == 2)
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                    else
                                    {
                                        // カンマ、ピリオド削除
                                        RemoveCommaPeriod(targetText, out retText, true);

                                        if ((retText[0] != '-') && (retText.Length == 8))
                                        {
                                            e.KeyChar = '\0';
                                        }
                                        else if ((retText[0] == '-') && (retText.Length == 9))
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// Gridキープレスイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_KeyPress(object sender, KeyPressEventArgs e)
		{
			// アクティブセルはあるか？
			if (this.StockGrid.ActiveCell != null)
			{
				// 入力中のグリッドセルオブジェクトを取得
				UltraGridCell _curcell = this.StockGrid.ActiveCell;

				// 編集モード中？
				if (this.StockGrid.ActiveCell.IsInEditMode)
				{
					switch (this.StockGrid.ActiveCell.Column.Key)
					{
						// 数量入力チェック
						case AdjustStockAcs.ctCOL_AdjustCount:
							if (!KeyPressNumCheck(12, 2, _curcell.Text, e.KeyChar, _curcell.SelStart, _curcell.SelLength, true))
							{
								e.Handled = true;
								return;
							}
							break;
                        // 仕入単価入力チェック
                        // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                        //case AdjustStockAcs.ctCOL_StockPrice:
                        //    if (!KeyPressNumCheck(12, 1, _curcell.Text, e.KeyChar, _curcell.SelStart, _curcell.SelLength, true))
                        //    {
                        //        e.Handled = true;
                        //        return;
                        //    }
                        //    break;
                        case AdjustStockAcs.ctCOL_StockUnitPrice:
                            if (!KeyPressNumCheck(12, 2, _curcell.Text, e.KeyChar, _curcell.SelStart, _curcell.SelLength, true))
                            {
								e.Handled = true;
								return;
							}
                            break;
                        // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
					}
                }
			    
			    UltraGridCell cell = this.StockGrid.ActiveCell;

			    // ActiveCellが商品ガイドボタンの場合
                if (cell.Column.Key == AdjustStockAcs.ctCOL_GoodsGuide)
                {
                    if (e.KeyChar == (char)Keys.Space) 
                    {
                        CellEventArgs ce = new CellEventArgs(cell);
                        this.StockGrid_ClickCellButton(this.StockGrid, ce);
                    }
                }
			}
        }
        
		/// <summary>
		/// Gridセルアクティブ後イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StockGrid_AfterCellActivate(object sender, EventArgs e)
		{
			// 非アクティブ時比較用にバッファリング
			this._tempCell = this.StockGrid.ActiveCell;
			if (this._tempCell != null)
			{
				this._tempValue = this._tempCell.Value;
			}
			else
			{
				this._tempValue = null;
			}

			// ステータスバーヘルプメッセージ表示
			if (this.StockGrid.ActiveCell != null)
			{
				int rowIndex = this.StockGrid.ActiveCell.Row.Index;
				string colKey = this.StockGrid.ActiveCell.Column.Key;
			}
		}

		/// <summary>
		/// セル非アクティブ前イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StockGrid_BeforeCellDeactivate(object sender, CancelEventArgs e)
		{
			if (this._beforeCellDeactivateRun) return;  

			this._beforeCellDeactivateRun = true;
			try
			{
				// AfterCellActivateイベントで捕捉したセルであるか？
				if ((this.StockGrid.ActiveCell != null) && (this._tempCell == this.StockGrid.ActiveCell))
				{
					// ステータスバーヘルプメッセージ非表示
					StatusBar_Main.Panels["HelpText"].Text = "";
				}
			}
			finally
			{
				this._beforeCellDeactivateRun = false;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
        /// エラーデータ更新時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.StockGrid.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.StockGrid.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.StockGrid.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.StockGrid.ActiveCell.Column.DataType == typeof(double)))
                {
                    EmbeddableEditorBase editorBase = this.StockGrid.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.StockGrid.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.StockGrid.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.StockGrid.ActiveCell.Column.DataType);
                            this.StockGrid.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.StockGrid.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

		/// <summary>
		/// Gridセル更新前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <br>Update Note  : 2009/12/16 朱俊成</br>
        /// <br>               PM.NS-5</br>
        /// <br>               在庫仕入入力で標準価格と原単価の入力制御の修正</br>
        private void StockGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
		{
			// 数値項目の場合
			if ((e.Cell.Column.DataType == typeof(Int64)) ||
				(e.Cell.Column.DataType == typeof(Int32)) ||
				(e.Cell.Column.DataType == typeof(Double)))
			{
				// 数値項目に「-」or 「.」だけしか入ってなかったら駄目です
				if ((this.StockGrid.ActiveCell.Text.Trim() == "-") ||
					(this.StockGrid.ActiveCell.Text.Trim() == ".") ||
					(this.StockGrid.ActiveCell.Text.Trim() == "-."))
					e.Cancel = true;
			}
            // --- ADD 2009/12/16 ---------->>>>>
            #region 標準価格
            // ActiveCellが「標準価格」の場合
            if (e.Cell.Column.Key == AdjustStockAcs.ctCOL_ListPriceFl)
            {
                this._beforeListPriceInpDiv = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion
            #region 単価入力区分
            // ActiveCellが「単価入力区分」の場合
            else if (e.Cell.Column.Key == AdjustStockAcs.ctCOL_StockUnitPrice)
            {
                this._beforeUnitPriceInpDiv = (e.Cell.Value is DBNull) ? 0 : Convert.ToDouble(e.Cell.Value);
            }
            #endregion
            // --- ADD 2009/12/16 -----------<<<<<
        }

		/// <summary>
		/// セルが編集モードに入った後に発生するイベントです
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_AfterEnterEditMode(object sender, EventArgs e)
		{
			if (this.StockGrid.ActiveCell != null)
			{
				this.StockGrid.ActiveCell.SelectAll();
			}

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            if (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo)
            {
                this.StatusBar_Main.Panels[2].Text = "前方一致検索：最後に*を入力[例:A*]";
            }
            else
            {
                this.StatusBar_Main.Panels[2].Text = "";
            }

            if (this.tNedit_SupplierSlipNo.Enabled == true)
            {
                this.RowDelete_ultraButton.Enabled = true;
            }
            else
            {
                this.RowDelete_ultraButton.Enabled = false;
            }
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// マウスでクリックされた時に発せするイベントです
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void StockGrid_MouseClick(object sender, MouseEventArgs e)
		{
			// 右クリックの場合
			if (e.Button != MouseButtons.Right) return;

			Point nowPos = new Point(e.X, e.Y);

			UIElement objElement = this.StockGrid.DisplayLayout.UIElement.ElementFromPoint(nowPos);

			// クリック位置が列ヘッダーか判定
			bool isColumnHeader = false;
			if (objElement != null)
			{
				if ((objElement.SelectableItem is UltraWinGrid.ColumnHeader) ||
					(objElement is HeaderUIElement))
				{
					isColumnHeader = true;
				}
			}

			if (isColumnHeader)
			{
			}
			else
			{
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        //--------------------------------------------------------
		//  アクセスクラスイベントハンドラ
		//--------------------------------------------------------
		#region アクセスクラスイベントハンドラ
		/// <summary>
		/// 伝票アクセスクラス明細行変更イベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SlipDtlDataTable_SlipDtlRowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Action == DataRowAction.Add)
			{
				this.SettingGridRowEditor(this.StockGrid.Rows.Count - 1);
			}
		}
		#endregion

		//--------------------------------------------------------
		//  内部処理
		//--------------------------------------------------------
		#region 内部処理

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入力補助項目実行処理
		/// </summary>
		/// <param name="itemKey">項目キー文字列</param>
		private void InputHelperItemExecute(string itemKey)
		{
			// 行選択している場合、その行の明細種別をActiveにしておく
			if (this.StockGrid.Selected.Rows.Count > 0)
			{
				int row = this.StockGrid.Selected.Rows[0].Index;

				this.StockGrid.Selected.Rows.Clear();
			}
		}

		/// <summary>
		/// 伝票項目表示処理
		/// </summary>
		/// <param name="dispMode">表示モード</param>
		/// <remarks>
		/// <br>Note       : ShowStaticMemoryで呼ばれます。</br>
		/// </remarks>
		private void DispSlipInfo(int dispMode)
		{

		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
		/// 明細グリッドセル設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void SettingGridRowEditor()
		{
			// 描画が必要な明細件数を取得する。
			int cnt = AdjustStockAcs.AdjustStockView.Count;

			// 呼び出し元のスレッドを判定
			if (!this.InvokeRequired)
			{
				// 描画を一時停止！
				this.StockGrid.BeginUpdate();
				try
				{
					// 同一スレッドの場合
					for (int i = 0; i < cnt; i++)
					{
						this.SettingGridRowEditor(i);
					}
				}
				finally
				{
					// 描画を開始!
					this.StockGrid.EndUpdate();
				}
			}
			else
			{
				// 別スレッドの場合
				settingGridRowEditorHandler settingGridRow = new settingGridRowEditorHandler(this.SettingGridRowEditor);

				for (int i = 0; i < cnt; i++)
				{
					this.BeginInvoke(settingGridRow, new object[] { i });
				}
			}
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="row">対象行</param>
		/// <remarks>
		/// <br>Note       : 指定行単位でのセルスタイル・文字色を設定する</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void SettingGridRowEditor(int rowIndex)
		{
			bool adjustActiveCell = false;

			UltraGridBand editBand = this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock];
			if (editBand == null) return;

			// 指定行の全ての列に対して設定を行う。
			foreach (UltraGridColumn wkCol in editBand.Columns)
			{
				// セル情報を取得
				UltraGridCell wkCell = this.StockGrid.Rows[rowIndex].Cells[wkCol];
				if (wkCell == null) continue;

                //商品ガイド
                if (wkCol.Key == AdjustStockAcs.ctCOL_GoodsGuide)
                {
                    this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsGuide].CellAppearance.Cursor = Cursors.Hand;
                }

				int dispState = -1;

				// 列状態情報を取得
                ControlSlipDtlColumnState.AdjustStockColumnState colState = null;
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                //if (ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex, GetEditerMode()).ContainsKey(wkCol.Key))
                //{
                //    colState = ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex, GetEditerMode())[wkCol.Key];
                //}
                if (ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex, ctMode_StockAdjust).ContainsKey(wkCol.Key))
                {
                    colState = ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex, ctMode_StockAdjust)[wkCol.Key];
                }
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

				if (colState != null)
				{
					// セルの状態により、表示スタイルを決定する。
					// 表示可能セル？
					if (colState.Visible)
					{
						// セルは有効？
						if (colState.Enabled)
						{
							// 読取専用？
							dispState = (colState.ReadOnly) ? 1 : 0;
						}
					}
				}

				switch (dispState)
				{
					// 入力可能状態
					case 0:
						// 背景色設定			<-	透明色
						wkCell.Appearance.BackColor = Color.Transparent;
						// 前景色設定			<-	指定された前景色
						wkCell.Appearance.ForeColor = colState.ForeColor;
						// 前景色(不可)設定		<-	指定された前景色
						wkCell.Appearance.ForeColorDisabled = colState.ForeColor;
						// セルの状態設定		<-	編集可能とする
						wkCell.Activation = Activation.AllowEdit;
						break;
					// リードオンリー
					case 1:
						// 背景色設定			<-	透明色
						wkCell.Appearance.BackColor = Color.Transparent;
						// 前景色設定			<-	指定された前景色
						wkCell.Appearance.ForeColor = colState.ForeColor;
						// 前景色(不可)設定		<-	指定された前景色
						wkCell.Appearance.ForeColorDisabled = colState.ForeColor;                        
						// セルの状態設定		<-	使用不可とする
						wkCell.Activation = Activation.Disabled;

						if (this.StockGrid.ActiveCell == wkCell)
						{
							adjustActiveCell = true;
						}
						break;
					// 非表示
					default:
						// 背景色				<-	SeaShell
                        wkCell.Appearance.BackColor = Color.SeaShell;
                        // 前景色				<-	背景色と同色
                        wkCell.Appearance.ForeColor = Color.Black;
                        // 前景色(不可)設定		<-	背景色と同色
                        wkCell.Appearance.ForeColor = Color.Black;
                        // セルの状態			<-	使用不可とする
						wkCell.Activation = Activation.Disabled;

						if (this.StockGrid.ActiveCell == wkCell)
						{
							adjustActiveCell = true;
						}
						break;
				}
			}	// end of foreach

			// 必要ならば、アクティブセル位置の調整
			if (adjustActiveCell)
			{
				this.StockGrid.PerformAction(UltraGridAction.NextCellByTab);
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="row">対象行</param>
        /// <remarks>
        /// <br>Note       : 指定行単位でのセルスタイル・文字色を設定する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SettingGridRowEditor(int rowIndex)
        {
            bool adjustActiveCell = false;

            UltraGridBand editBand = this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (UltraGridColumn wkCol in editBand.Columns)
            {
                // セル情報を取得
                UltraGridCell wkCell = this.StockGrid.Rows[rowIndex].Cells[wkCol];
                if (wkCell == null) continue;

                // No
                if (wkCol.Key == AdjustStockAcs.ctCOL_RowNum)
                {
                    // 背景色設定
                    wkCell.Appearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                    wkCell.Appearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                    wkCell.Appearance.ForeColor = Color.White;
                    wkCell.Appearance.ForeColorDisabled = Color.White;
                    wkCell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    wkCell.Activation = Activation.Disabled;
                    continue;
                }

                int dispState = -1;

                // 列状態情報を取得
                ControlSlipDtlColumnState.AdjustStockColumnState colState = null;
                if (ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex).ContainsKey(wkCol.Key))
                {
                    colState = ControlSlipDtlColumnState.GetSlipDtlColumnState(rowIndex)[wkCol.Key];
                }

                if (colState != null)
                {
                    // セルの状態により、表示スタイルを決定する。
                    // 表示可能セル？
                    if (colState.Visible)
                    {
                        // セルは有効？
                        if (colState.Enabled)
                        {
                            // 読取専用？
                            dispState = (colState.ReadOnly) ? 1 : 0;
                        }
                    }
                }

                switch (dispState)
                {
                    // 入力可能状態
                    case 0:
                        // 前景色設定			<-	指定された前景色
                        wkCell.Appearance.ForeColor = colState.ForeColor;
                        // 前景色(不可)設定		<-	指定された前景色
                        wkCell.Appearance.ForeColorDisabled = colState.ForeColor;
                        // セルの状態設定		<-	編集可能とする
                        wkCell.Activation = Activation.AllowEdit;
                        break;
                    // リードオンリー
                    case 1:
                        // 背景色設定			<-	255, 255, 220
                        wkCell.Appearance.BackColor = Color.FromArgb(255, 255, 220);
                        // 前景色設定			<-	指定された前景色
                        wkCell.Appearance.ForeColor = colState.ForeColor;
                        // 前景色(不可)設定		<-	指定された前景色
                        wkCell.Appearance.ForeColorDisabled = colState.ForeColor;
                        // セルの状態設定		<-	使用不可とする
                        wkCell.Activation = Activation.Disabled;

                        if (this.StockGrid.ActiveCell == wkCell)
                        {
                            adjustActiveCell = true;
                        }
                        break;
                    // 非表示
                    default:
                        // 背景色				<-	Gainsboro
                        wkCell.Appearance.BackColor = Color.Gainsboro;
                        // 前景色				<-	背景色と同色
                        wkCell.Appearance.ForeColor = Color.Black;
                        // 前景色(不可)設定		<-	背景色と同色
                        wkCell.Appearance.ForeColorDisabled = Color.Black;
                        // セルの状態			<-	使用不可とする
                        wkCell.Activation = Activation.Disabled;

                        if (this.StockGrid.ActiveCell == wkCell)
                        {
                            adjustActiveCell = true;
                        }
                        break;
                }
            }

            // 必要ならば、アクティブセル位置の調整
            if (adjustActiveCell)
            {
                this.StockGrid.PerformAction(UltraGridAction.NextCellByTab);
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        /// <summary>
		/// 仕入伝票明細表示用Gridの設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : Gridのカラムの設定を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void SettingGrid()
		{
			// グリッドのカラム情報を設定します。
			this.SettingGridColumn(this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns);
			// グリッドの表示カラムを設定します。
			this.SettingDisplayColumn(this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns);

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
			// 明細種別リストを登録します。
			this.MakeDetailKindCodeList(this.StockGrid);
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            
            // Gridのキーマッピングの設定
			this.MakeKeyMappingForGrid();
		}

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 明細表示用Grid設定
        /// </summary>
        /// <param name="columns">グリッド列</param>
        /// <remarks>
        /// <br>Note       : Gridのカラムの設定を行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 朱俊成</br>
        /// <br>             PM.NS-5</br>
        /// <br>             スペース→0、又は0.00の修正</br>
        /// </remarks>
        private void SettingGridColumn(ColumnsCollection columns)
        {
            // --- UPD 2009/12/16 -------------->>>
            // スペースではなく0、又は0.00を表示するように修正する
            //string moneyFormat = "#,##0;-#,##0;''";
            //string decimalFormat2 = "#,##0.00;-#,##0.00;''";
            string moneyFormat = "#,##0;-#,##0;'0'";
            string decimalFormat2 = "#,##0.00;-#,##0.00;'0.00'";
            // --- UPD 2009/12/16 --------------<<<

            string codeFormat = "#0;-#0;''";

            //----------------------------------------------------------------------------------------------------
            //	カラムの表示順を設定する
            //----------------------------------------------------------------------------------------------------
            ArrayList _orderList = _colDispInfo.GetVisiblePositionList();

            for (int i = 0; i < _orderList.Count; i++)
            {
                columns[(string)_orderList[i]].Header.VisiblePosition = i;
            }

            // No
            columns[AdjustStockAcs.ctCOL_RowNum].Header.Caption = "No";
            columns[AdjustStockAcs.ctCOL_RowNum].Header.Fixed = true;
            columns[AdjustStockAcs.ctCOL_RowNum].Format = codeFormat;
            columns[AdjustStockAcs.ctCOL_RowNum].Width = _colDispInfo.Width_RowNum;
            columns[AdjustStockAcs.ctCOL_RowNum].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_RowNum].CellAppearance.TextVAlign = VAlign.Middle;
            // 品番
            columns[AdjustStockAcs.ctCOL_GoodsNo].Header.Caption = "品番";
            columns[AdjustStockAcs.ctCOL_GoodsNo].Header.Fixed = true;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Width = _colDispInfo.Width_GoodsNo;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Format = codeFormat;
            columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.TextVAlign = VAlign.Middle;
            // 品名
            columns[AdjustStockAcs.ctCOL_GoodsName].Header.Caption = "品名";
            columns[AdjustStockAcs.ctCOL_GoodsName].Width = _colDispInfo.Width_GoodsName;
            columns[AdjustStockAcs.ctCOL_GoodsName].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_GoodsName].CellAppearance.TextVAlign = VAlign.Middle;
            // ＢＬコード
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Header.Caption = "BLｺｰﾄﾞ";
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Width = _colDispInfo.Width_BLGoodsCode;
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].CellAppearance.TextVAlign = VAlign.Middle;
            // メーカー
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Header.Caption = "メーカー";
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Width = _colDispInfo.Width_GoodsMakerCd;
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].CellAppearance.TextVAlign = VAlign.Middle;
            // 仕入先
            columns[AdjustStockAcs.ctCOL_SupplierCd].Header.Caption = "仕入先";
            columns[AdjustStockAcs.ctCOL_SupplierCd].Width = _colDispInfo.Width_SupplierCd;
            columns[AdjustStockAcs.ctCOL_SupplierCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_SupplierCd].CellAppearance.TextVAlign = VAlign.Middle;
            // 標準価格
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Header.Caption = "標準価格";
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Width = _colDispInfo.Width_ListPriceFl;
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Format = moneyFormat;
            columns[AdjustStockAcs.ctCOL_ListPriceFl].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_ListPriceFl].CellAppearance.TextVAlign = VAlign.Middle;
            // 原単価
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Header.Caption = "原単価";
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Width = _colDispInfo.Width_StockUnitPrice;
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Format = decimalFormat2;
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].CellAppearance.TextVAlign = VAlign.Middle;
            // 仕入数
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Header.Caption = "仕入数";
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Width = _colDispInfo.Width_SalesOrderUnit;
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Format = decimalFormat2;
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].CellAppearance.TextVAlign = VAlign.Middle;
            // 仕入後数
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Header.Caption = "仕入後数";
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Width = _colDispInfo.Width_AfSalesOrderUnit;
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Format = decimalFormat2;
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].CellAppearance.TextVAlign = VAlign.Middle;
            // 棚番
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Header.Caption = "棚番";
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Width = _colDispInfo.Width_WarehouseShelfNo;
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].CellAppearance.TextVAlign = VAlign.Middle;
            // 発注残
            columns[AdjustStockAcs.ctCOL_SalesOrderCount].Header.Caption = "発注残";
            columns[AdjustStockAcs.ctCOL_SalesOrderCount].Width = _colDispInfo.Width_SalesOrderCount;
            columns[AdjustStockAcs.ctCOL_SalesOrderCount].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_SalesOrderCount].CellAppearance.TextVAlign = VAlign.Middle;
            // 在庫数(仕入在庫数)
            columns[AdjustStockAcs.ctCOL_SupplierStock].Header.Caption = "在庫数";
            columns[AdjustStockAcs.ctCOL_SupplierStock].Width = _colDispInfo.Width_SupplierStock;
            columns[AdjustStockAcs.ctCOL_SupplierStock].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_SupplierStock].CellAppearance.TextVAlign = VAlign.Middle;
            columns[AdjustStockAcs.ctCOL_SupplierStock].Format = "N";
            // 明細備考
            columns[AdjustStockAcs.ctCOL_DtlNote].Header.Caption = "明細備考";
            columns[AdjustStockAcs.ctCOL_DtlNote].Width = _colDispInfo.Width_DtlNote;
            columns[AdjustStockAcs.ctCOL_DtlNote].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_DtlNote].CellAppearance.TextVAlign = VAlign.Middle;
        }

        /// <summary>
        /// 明細表示用Grid表示非表示設定
        /// </summary>
        /// <param name="columns">グリッド列</param>
        /// <remarks>
        /// <br>Note       : グリッドの列表示を設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SettingDisplayColumn(ColumnsCollection columns)
        {
            // 一旦すべての列を非表示に設定する
            foreach (UltraGridColumn col in columns)
            {
                col.Hidden = true;
            }

            columns[AdjustStockAcs.ctCOL_RowNum].Hidden = !_colDispInfo.Visible_RowNum;                         // No
            columns[AdjustStockAcs.ctCOL_GoodsNo].Hidden = !_colDispInfo.Visible_GoodsNo;                       // 品番
            columns[AdjustStockAcs.ctCOL_GoodsName].Hidden = !_colDispInfo.Visible_GoodsName;                   // 品名
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Hidden = !_colDispInfo.Visible_BLGoodsCode;               // ＢＬコード
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Hidden = !_colDispInfo.Visible_GoodsMakerCd;             // メーカー
            columns[AdjustStockAcs.ctCOL_SupplierCd].Hidden = !_colDispInfo.Visible_SupplierCd;                 // 仕入先
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Hidden = !_colDispInfo.Visible_ListPriceFl;               // 標準価格
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Hidden = !_colDispInfo.Visible_StockUnitPrice;         // 原単価
            columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Hidden = !_colDispInfo.Visible_SalesOrderUnit;         // 仕入数
            columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Hidden = !_colDispInfo.Visible_AfSalesOrderUnit;     // 仕入後数
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Hidden = !_colDispInfo.Visible_WarehouseShelfNo;     // 棚番
            columns[AdjustStockAcs.ctCOL_SalesOrderCount].Hidden = !_colDispInfo.Visible_SalesOrderCount;       // 発注残
            columns[AdjustStockAcs.ctCOL_SupplierStock].Hidden = !_colDispInfo.Visible_SupplierStock;           // 在庫数(仕入在庫数)
            columns[AdjustStockAcs.ctCOL_DtlNote].Hidden = !_colDispInfo.Visible_DtlNote;                       // 明細備考
        }

        /// <summary>
        /// 明細表示グリッドのカラム情報を取得します。
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <remarks>
        /// <br>Note       : グリッドの列情報を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GettingGridColumn(ColumnsCollection columns)
        {
            // No
            _colDispInfo.Width_RowNum = columns[AdjustStockAcs.ctCOL_RowNum].Width;
            _colDispInfo.Order_RowNum = columns[AdjustStockAcs.ctCOL_RowNum].Header.VisiblePosition;
            _colDispInfo.Visible_RowNum = !columns[AdjustStockAcs.ctCOL_RowNum].Hidden;
            // 品番
            _colDispInfo.Width_GoodsNo = columns[AdjustStockAcs.ctCOL_GoodsNo].Width;
            _colDispInfo.Order_GoodsNo = columns[AdjustStockAcs.ctCOL_GoodsNo].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsNo = !columns[AdjustStockAcs.ctCOL_GoodsNo].Hidden;
            // 品名
            _colDispInfo.Width_GoodsName = columns[AdjustStockAcs.ctCOL_GoodsName].Width;
            _colDispInfo.Order_GoodsName = columns[AdjustStockAcs.ctCOL_GoodsName].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsName = !columns[AdjustStockAcs.ctCOL_GoodsName].Hidden;
            // ＢＬコード
            _colDispInfo.Width_BLGoodsCode = columns[AdjustStockAcs.ctCOL_BLGoodsCode].Width;
            _colDispInfo.Order_BLGoodsCode = columns[AdjustStockAcs.ctCOL_BLGoodsCode].Header.VisiblePosition;
            _colDispInfo.Visible_BLGoodsCode = !columns[AdjustStockAcs.ctCOL_BLGoodsCode].Hidden;
            // メーカー
            _colDispInfo.Width_GoodsMakerCd = columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Width;
            _colDispInfo.Order_GoodsMakerCd = columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsMakerCd = !columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Hidden;
            // 仕入先
            _colDispInfo.Width_SupplierCd = columns[AdjustStockAcs.ctCOL_SupplierCd].Width;
            _colDispInfo.Order_SupplierCd = columns[AdjustStockAcs.ctCOL_SupplierCd].Header.VisiblePosition;
            _colDispInfo.Visible_SupplierCd = !columns[AdjustStockAcs.ctCOL_SupplierCd].Hidden;
            // 標準価格
            _colDispInfo.Width_ListPriceFl = columns[AdjustStockAcs.ctCOL_ListPriceFl].Width;
            _colDispInfo.Order_ListPriceFl = columns[AdjustStockAcs.ctCOL_ListPriceFl].Header.VisiblePosition;
            _colDispInfo.Visible_ListPriceFl = !columns[AdjustStockAcs.ctCOL_ListPriceFl].Hidden;
            // 原単価
            _colDispInfo.Width_StockUnitPrice = columns[AdjustStockAcs.ctCOL_StockUnitPrice].Width;
            _colDispInfo.Order_StockUnitPrice = columns[AdjustStockAcs.ctCOL_StockUnitPrice].Header.VisiblePosition;
            _colDispInfo.Visible_StockUnitPrice = !columns[AdjustStockAcs.ctCOL_StockUnitPrice].Hidden;
            // 仕入数
            _colDispInfo.Width_SalesOrderUnit = columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Width;
            _colDispInfo.Order_SalesOrderUnit = columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Header.VisiblePosition;
            _colDispInfo.Visible_SalesOrderUnit = !columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Hidden;
            // 仕入後数
            _colDispInfo.Width_AfSalesOrderUnit = columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Width;
            _colDispInfo.Order_AfSalesOrderUnit = columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Header.VisiblePosition;
            _colDispInfo.Visible_AfSalesOrderUnit = !columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Hidden;
            // 棚番
            _colDispInfo.Width_WarehouseShelfNo = columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Width;
            _colDispInfo.Order_WarehouseShelfNo = columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Header.VisiblePosition;
            _colDispInfo.Visible_WarehouseShelfNo = !columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Hidden;
            // 発注残
            _colDispInfo.Width_SalesOrderCount = columns[AdjustStockAcs.ctCOL_SalesOrderCount].Width;
            _colDispInfo.Order_SalesOrderCount = columns[AdjustStockAcs.ctCOL_SalesOrderCount].Header.VisiblePosition;
            _colDispInfo.Visible_SalesOrderCount = !columns[AdjustStockAcs.ctCOL_SalesOrderCount].Hidden;
            // 在庫数(仕入在庫数)
            _colDispInfo.Width_SupplierStock = columns[AdjustStockAcs.ctCOL_SupplierStock].Width;
            _colDispInfo.Order_SupplierStock = columns[AdjustStockAcs.ctCOL_SupplierStock].Header.VisiblePosition;
            _colDispInfo.Visible_SupplierStock = !columns[AdjustStockAcs.ctCOL_SupplierStock].Hidden;
            // 明細備考
            _colDispInfo.Width_DtlNote = columns[AdjustStockAcs.ctCOL_DtlNote].Width;
            _colDispInfo.Order_DtlNote = columns[AdjustStockAcs.ctCOL_DtlNote].Header.VisiblePosition;
            _colDispInfo.Visible_DtlNote = !columns[AdjustStockAcs.ctCOL_DtlNote].Hidden;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 明細表示用Grid設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : Gridのカラムの設定を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void SettingGridColumn(ColumnsCollection columns)
		{
			string moneyFormat = "#,##0;-#,##0;''";
			//string decimalFormat1 = "#,##0.0;-#,##0.0;''";
            string decimalFormat2 = "#,##0.00;-#,##0.00;''";
			string codeFormat = "#0;-#0;''";

			//----------------------------------------------------------------------------------------------------
			//	カラムの表示順を設定する
			//----------------------------------------------------------------------------------------------------
			ArrayList _orderList = _colDispInfo.GetVisiblePositionList();

			for (int i = 0; i < _orderList.Count; i++)
			{                
				columns[(string)_orderList[i]].Header.VisiblePosition = i;
			}

            // 行番号
            columns[AdjustStockAcs.ctCOL_RowNum].Header.Caption = "No";
            columns[AdjustStockAcs.ctCOL_RowNum].Header.Fixed = true;
            columns[AdjustStockAcs.ctCOL_RowNum].Format = codeFormat;
            columns[AdjustStockAcs.ctCOL_RowNum].Width = _colDispInfo.Width_RowNum;
            columns[AdjustStockAcs.ctCOL_RowNum].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_RowNum].CellAppearance.TextVAlign = VAlign.Middle;

			// 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_GoodsCode].Header.Caption = "商品コード";
            //columns[AdjustStockAcs.ctCOL_GoodsCode].Header.Fixed = true;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].Width = _colDispInfo.Width_GoodsCode;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].Format = codeFormat;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].CellAppearance = this.StockGrid.DisplayLayout.Override.HeaderAppearance.Clone() as AppearanceBase;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].CellAppearance.TextHAlign = HAlign.Left;
            //columns[AdjustStockAcs.ctCOL_GoodsCode].CellAppearance.TextVAlign = VAlign.Middle;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Header.Caption = "商品コード";
            columns[AdjustStockAcs.ctCOL_GoodsNo].Header.Fixed = true;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Width = _colDispInfo.Width_GoodsNo;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Format = codeFormat;
            columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance = this.StockGrid.DisplayLayout.Override.HeaderAppearance.Clone() as AppearanceBase;
            // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
            columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.TextVAlign = VAlign.Middle;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 商品ガイド
            columns[AdjustStockAcs.ctCOL_GoodsGuide].Header.Caption = "";
            columns[AdjustStockAcs.ctCOL_GoodsGuide].Width = _colDispInfo.Width_GoodsGuide;
            columns[AdjustStockAcs.ctCOL_GoodsGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[AdjustStockAcs.ctCOL_GoodsGuide].CellAppearance.TextVAlign = VAlign.Middle;

			// 商品名称
			columns[AdjustStockAcs.ctCOL_GoodsName].Header.Caption = "商品名称";
            columns[AdjustStockAcs.ctCOL_GoodsName].Width = _colDispInfo.Width_GoodsName;
            columns[AdjustStockAcs.ctCOL_GoodsName].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_GoodsName].CellAppearance.TextVAlign = VAlign.Middle;

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            // メーカーコード
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Header.Caption = "メーカーコード";
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Width = _colDispInfo.Width_GoodsMakerCd;
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].CellAppearance.TextVAlign = VAlign.Middle;

            // メーカー名称
            columns[AdjustStockAcs.ctCOL_MakerName].Header.Caption = "メーカー名称";
            columns[AdjustStockAcs.ctCOL_MakerName].Width = _colDispInfo.Width_MakerName;
            columns[AdjustStockAcs.ctCOL_MakerName].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_MakerName].CellAppearance.TextVAlign = VAlign.Middle;

            // 仕入先名称
            columns[AdjustStockAcs.ctCOL_CustomerName].Header.Caption = "仕入先名称";
            columns[AdjustStockAcs.ctCOL_CustomerName].Width = _colDispInfo.Width_CustomerName;
            columns[AdjustStockAcs.ctCOL_CustomerName].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_CustomerName].CellAppearance.TextVAlign = VAlign.Middle;

            // ＢＬ商品コード
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Header.Caption = "ＢＬコード";
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Width = _colDispInfo.Width_BLGoodsCode;
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].CellAppearance.TextVAlign = VAlign.Middle;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 倉庫コード
            columns[AdjustStockAcs.ctCOL_WarehouseCode].Header.Caption = "倉庫コード";
            columns[AdjustStockAcs.ctCOL_WarehouseCode].Width = _colDispInfo.Width_WarehouseCode;
            columns[AdjustStockAcs.ctCOL_WarehouseCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_WarehouseCode].CellAppearance.TextVAlign = VAlign.Middle;

            // 倉庫名称
            columns[AdjustStockAcs.ctCOL_WarehouseName].Header.Caption = "倉庫名称";
            columns[AdjustStockAcs.ctCOL_WarehouseName].Width = _colDispInfo.Width_WarehouseName;
            columns[AdjustStockAcs.ctCOL_WarehouseName].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_WarehouseName].CellAppearance.TextVAlign = VAlign.Middle;


            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //columns[AdjustStockAcs.ctCOL_ProductNumber].Header.Caption = "製造番号";
            //columns[AdjustStockAcs.ctCOL_ProductNumber].Width = _colDispInfo.Width_ProductNumber;
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].Format = codeFormat;
            //columns[AdjustStockAcs.ctCOL_ProductNumber].CellAppearance.TextHAlign = HAlign.Left;
            //columns[AdjustStockAcs.ctCOL_ProductNumber].CellAppearance.TextVAlign = VAlign.Middle;
            //
            //// 携帯番号
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].Header.Caption = "携帯番号";
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].Width = _colDispInfo.Width_StockTelNo1;
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].Format = codeFormat;
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].CellAppearance.TextHAlign = HAlign.Left;
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].CellAppearance.TextVAlign = VAlign.Middle;
            //
            //// 修正前製番
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].Header.Caption = "修正前製番";
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].Width = _colDispInfo.Width_BfProductNumber;
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].Format = codeFormat;
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].CellAppearance.TextHAlign = HAlign.Left;
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].CellAppearance.TextVAlign = VAlign.Middle;

            // 棚番
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Header.Caption = "棚番";
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Width = _colDispInfo.Width_WarehouseShelfNo;
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].CellAppearance.TextVAlign = VAlign.Middle;

            // 修正前棚番
            columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Header.Caption = "修正前棚番";
            columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Width = _colDispInfo.Width_BfWarehouseShelfNo;
            columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].CellAppearance.TextVAlign = VAlign.Middle;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 仕入在庫数
			columns[AdjustStockAcs.ctCOL_SupplierStock].Header.Caption = "仕入在庫数";
            columns[AdjustStockAcs.ctCOL_SupplierStock].Width = _colDispInfo.Width_SupplierStock;
            columns[AdjustStockAcs.ctCOL_SupplierStock].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_SupplierStock].CellAppearance.TextVAlign = VAlign.Middle;
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_SupplierStock].Format = decimalFormat1;
            columns[AdjustStockAcs.ctCOL_SupplierStock].Format = decimalFormat2;
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            // 受託在庫数
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_TrustCount].Header.Caption = "受託在庫数";
            columns[AdjustStockAcs.ctCOL_TrustCount].Header.Caption = "入荷在庫数";
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            columns[AdjustStockAcs.ctCOL_TrustCount].Width = _colDispInfo.Width_TrustCount;
            columns[AdjustStockAcs.ctCOL_TrustCount].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_TrustCount].CellAppearance.TextVAlign = VAlign.Middle;
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_TrustCount].Format = decimalFormat1;
            columns[AdjustStockAcs.ctCOL_TrustCount].Format = decimalFormat2;
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

			// 調整数
			columns[AdjustStockAcs.ctCOL_AdjustCount].Header.Caption = "調整数";
			columns[AdjustStockAcs.ctCOL_AdjustCount].Width = _colDispInfo.Width_AdjustCount;
            columns[AdjustStockAcs.ctCOL_AdjustCount].Format = decimalFormat2;
            columns[AdjustStockAcs.ctCOL_AdjustCount].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_AdjustCount].CellAppearance.TextVAlign = VAlign.Middle;
            
			// 仕入単価
			columns[AdjustStockAcs.ctCOL_StockUnitPrice].Header.Caption = "仕入単価";
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Width = _colDispInfo.Width_StockUnitPrice;
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_StockUnitPrice].Format = decimalFormat1;
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].Format = decimalFormat2;
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_StockUnitPrice].CellAppearance.TextVAlign = VAlign.Middle;

            // 修正前仕入単価
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Header.Caption = "修正前仕入単価";
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Width = _colDispInfo.Width_BfStockUnitPrice;
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Format = moneyFormat;
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Format = decimalFormat2;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].CellAppearance.TextVAlign = VAlign.Middle;

			// 調整金額
			columns[AdjustStockAcs.ctCOL_AdjustPrice].Header.Caption = "調整金額";
            columns[AdjustStockAcs.ctCOL_AdjustPrice].Width = _colDispInfo.Width_AdjustPrice;
            columns[AdjustStockAcs.ctCOL_AdjustPrice].Format = moneyFormat;
            columns[AdjustStockAcs.ctCOL_AdjustPrice].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_AdjustPrice].CellAppearance.TextVAlign = VAlign.Middle;

            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            // 明細備考
            columns[AdjustStockAcs.ctCOL_DtlNote].Header.Caption = "明細備考";
            columns[AdjustStockAcs.ctCOL_DtlNote].Width = _colDispInfo.Width_DtlNote;
            columns[AdjustStockAcs.ctCOL_DtlNote].CellAppearance.TextHAlign = HAlign.Left;
            columns[AdjustStockAcs.ctCOL_DtlNote].CellAppearance.TextVAlign = VAlign.Middle;
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            // 定価（浮動）
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Header.Caption = "定価";
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Width = _colDispInfo.Width_DtlNote;
            columns[AdjustStockAcs.ctCOL_ListPriceFl].CellAppearance.TextHAlign = HAlign.Right;
            columns[AdjustStockAcs.ctCOL_ListPriceFl].CellAppearance.TextVAlign = VAlign.Middle;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// 明細表示用Grid表示非表示設定
		/// </summary>
		/// <param name="columns"></param>
		private void SettingDisplayColumn(ColumnsCollection columns)
		{
			// 一旦すべての列を非表示に設定する
			foreach (UltraGridColumn col in columns)
			{
				col.Hidden = true;
			}

            columns[AdjustStockAcs.ctCOL_RowNum].Hidden = !_colDispInfo.Visible_RowNum;
            // 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //columns[AdjustStockAcs.ctCOL_GoodsCode].Hidden = !_colDispInfo.Visible_GoodsCode;
            columns[AdjustStockAcs.ctCOL_GoodsNo].Hidden = !_colDispInfo.Visible_GoodsNo;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品ガイド
            columns[AdjustStockAcs.ctCOL_GoodsGuide].Hidden = !_colDispInfo.Visible_GoodsGuide;
			// 商品名称
            columns[AdjustStockAcs.ctCOL_GoodsName].Hidden = !_colDispInfo.Visible_GoodsName;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            // メーカーコード
            columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Hidden = !_colDispInfo.Visible_GoodsMakerCd;
            // メーカー名称
            columns[AdjustStockAcs.ctCOL_MakerName].Hidden = !_colDispInfo.Visible_MakerName;
            // 仕入先名称
            columns[AdjustStockAcs.ctCOL_CustomerName].Hidden = !_colDispInfo.Visible_CustomerName;
            // ＢＬ商品コード
            columns[AdjustStockAcs.ctCOL_BLGoodsCode].Hidden = !_colDispInfo.Visible_BLGoodsCode;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
            columns[AdjustStockAcs.ctCOL_WarehouseCode].Hidden = !_colDispInfo.Visible_WarehouseCode;
            // 倉庫名称
            columns[AdjustStockAcs.ctCOL_WarehouseName].Hidden = !_colDispInfo.Visible_WarehouseName;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //columns[AdjustStockAcs.ctCOL_ProductNumber].Hidden = !_colDispInfo.Visible_ProductNumber;
            //// 携帯番号
            //columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = !_colDispInfo.Visible_StockTelNo1;
            //// 修正前製造番号
            //columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = !_colDispInfo.Visible_BfProductNumber;
            // 棚番
            columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Hidden = !_colDispInfo.Visible_WarehouseShelfNo;
            // 修正前棚番
            columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Hidden = !_colDispInfo.Visible_BfWarehouseShelfNo;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 仕入在庫数
			columns[AdjustStockAcs.ctCOL_SupplierStock].Hidden = !_colDispInfo.Visible_SupplierStock;
            // 受託在庫数
            columns[AdjustStockAcs.ctCOL_TrustCount].Hidden = !_colDispInfo.Visible_TrustCount;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 不良品(商品状態)
            //columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = !_colDispInfo.Visible_GoodsCodeStatus;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 調整数
			columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = !_colDispInfo.Visible_AdjustCount;
			// 仕入単価
			columns[AdjustStockAcs.ctCOL_StockUnitPrice].Hidden = !_colDispInfo.Visible_StockUnitPrice;
            // 修正前仕入単価
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = !_colDispInfo.Visible_BfStockUnitPrice;
			// 調整金額
			columns[AdjustStockAcs.ctCOL_AdjustPrice].Hidden = !_colDispInfo.Visible_AdjustPrice;
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            // 明細備考
            columns[AdjustStockAcs.ctCOL_DtlNote].Hidden = !_colDispInfo.Visible_DtlNote;
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            // 定価（浮動）
            columns[AdjustStockAcs.ctCOL_ListPriceFl].Hidden = !_colDispInfo.Visible_ListPriceFl;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// 明細表示グリッドのカラム情報を取得します。
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
		private void GettingGridColumn(ColumnsCollection columns)
		{
			// 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //_colDispInfo.Width_GoodsCode = columns[AdjustStockAcs.ctCOL_GoodsCode].Width;
			//_colDispInfo.Order_GoodsCode = columns[AdjustStockAcs.ctCOL_GoodsCode].Header.VisiblePosition;
			//_colDispInfo.Visible_GoodsCode = !columns[AdjustStockAcs.ctCOL_GoodsCode].Hidden;
            _colDispInfo.Width_GoodsNo = columns[AdjustStockAcs.ctCOL_GoodsNo].Width;
            _colDispInfo.Order_GoodsNo = columns[AdjustStockAcs.ctCOL_GoodsNo].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsNo = !columns[AdjustStockAcs.ctCOL_GoodsNo].Hidden;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品名称
			_colDispInfo.Width_GoodsName = columns[AdjustStockAcs.ctCOL_GoodsName].Width;
            _colDispInfo.Order_GoodsName = columns[AdjustStockAcs.ctCOL_GoodsName].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsName = !columns[AdjustStockAcs.ctCOL_GoodsName].Hidden;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            // メーカーコード
            _colDispInfo.Width_GoodsMakerCd = columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Width;
            _colDispInfo.Order_GoodsMakerCd = columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Header.VisiblePosition;
            _colDispInfo.Visible_GoodsMakerCd = !columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Hidden;
            // メーカー名称
            _colDispInfo.Width_MakerName = columns[AdjustStockAcs.ctCOL_MakerName].Width;
            _colDispInfo.Order_MakerName = columns[AdjustStockAcs.ctCOL_MakerName].Header.VisiblePosition;
            _colDispInfo.Visible_MakerName = !columns[AdjustStockAcs.ctCOL_MakerName].Hidden;
            // 仕入先名称
            _colDispInfo.Width_CustomerName = columns[AdjustStockAcs.ctCOL_CustomerName].Width;
            _colDispInfo.Order_CustomerName = columns[AdjustStockAcs.ctCOL_CustomerName].Header.VisiblePosition;
            _colDispInfo.Visible_CustomerName = !columns[AdjustStockAcs.ctCOL_CustomerName].Hidden;
            // ＢＬ商品コード
            _colDispInfo.Width_BLGoodsCode = columns[AdjustStockAcs.ctCOL_BLGoodsCode].Width;
            _colDispInfo.Order_BLGoodsCode = columns[AdjustStockAcs.ctCOL_BLGoodsCode].Header.VisiblePosition;
            _colDispInfo.Visible_BLGoodsCode = !columns[AdjustStockAcs.ctCOL_BLGoodsCode].Hidden;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
            _colDispInfo.Width_WarehouseCode = columns[AdjustStockAcs.ctCOL_WarehouseCode].Width;
            _colDispInfo.Order_WarehouseCode = columns[AdjustStockAcs.ctCOL_WarehouseCode].Header.VisiblePosition;
            _colDispInfo.Visible_WarehouseCode = !columns[AdjustStockAcs.ctCOL_WarehouseCode].Hidden;
            // 倉庫名称
            _colDispInfo.Width_WarehouseName = columns[AdjustStockAcs.ctCOL_WarehouseName].Width;
            _colDispInfo.Order_WarehouseName = columns[AdjustStockAcs.ctCOL_WarehouseName].Header.VisiblePosition;
            _colDispInfo.Visible_WarehouseName = !columns[AdjustStockAcs.ctCOL_WarehouseName].Hidden;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //_colDispInfo.Width_ProductNumber = columns[AdjustStockAcs.ctCOL_ProductNumber].Width;
            //_colDispInfo.Order_ProductNumber = columns[AdjustStockAcs.ctCOL_ProductNumber].Header.VisiblePosition;
            //_colDispInfo.Visible_ProductNumber = !columns[AdjustStockAcs.ctCOL_ProductNumber].Hidden;
            //// 携帯番号
            //_colDispInfo.Width_StockTelNo1 = columns[AdjustStockAcs.ctCOL_StockTelNo1].Width;
            //_colDispInfo.Order_StockTelNo1 = columns[AdjustStockAcs.ctCOL_StockTelNo1].Header.VisiblePosition;
            //_colDispInfo.Visible_StockTelNo1 = !columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden;
            // 棚番
            _colDispInfo.Width_WarehouseShelfNo = columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Width;
            _colDispInfo.Order_WarehouseShelfNo = columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Header.VisiblePosition;
            _colDispInfo.Visible_WarehouseShelfNo = !columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Hidden;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 仕入在庫数
			_colDispInfo.Width_SupplierStock = columns[AdjustStockAcs.ctCOL_SupplierStock].Width;
            _colDispInfo.Order_SupplierStock = columns[AdjustStockAcs.ctCOL_SupplierStock].Header.VisiblePosition;
            _colDispInfo.Visible_SupplierStock = !columns[AdjustStockAcs.ctCOL_SupplierStock].Hidden;
            // 受託在庫数
            _colDispInfo.Width_TrustCount = columns[AdjustStockAcs.ctCOL_TrustCount].Width;
            _colDispInfo.Order_TrustCount = columns[AdjustStockAcs.ctCOL_TrustCount].Header.VisiblePosition;
            _colDispInfo.Visible_TrustCount = !columns[AdjustStockAcs.ctCOL_TrustCount].Hidden;
            // 調整数
			_colDispInfo.Width_AdjustCount = columns[AdjustStockAcs.ctCOL_AdjustCount].Width;
			_colDispInfo.Order_AdjustCount = columns[AdjustStockAcs.ctCOL_AdjustCount].Header.VisiblePosition;
			_colDispInfo.Visible_AdjustCount = !columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden;
			// 仕入単価
			_colDispInfo.Width_StockUnitPrice = columns[AdjustStockAcs.ctCOL_StockUnitPrice].Width;
			_colDispInfo.Order_StockUnitPrice = columns[AdjustStockAcs.ctCOL_StockUnitPrice].Header.VisiblePosition;
			_colDispInfo.Visible_StockUnitPrice = !columns[AdjustStockAcs.ctCOL_StockUnitPrice].Hidden;
            // 修正前仕入単価
            _colDispInfo.Width_BfStockUnitPrice = columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Width;
            _colDispInfo.Order_BfStockUnitPrice = columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Header.VisiblePosition;
            _colDispInfo.Visible_BfStockUnitPrice = !columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden;
            // 調整金額
			_colDispInfo.Width_AdjustPrice = columns[AdjustStockAcs.ctCOL_AdjustPrice].Width;
			_colDispInfo.Order_AdjustPrice = columns[AdjustStockAcs.ctCOL_AdjustPrice].Header.VisiblePosition;
			_colDispInfo.Visible_AdjustPrice = !columns[AdjustStockAcs.ctCOL_AdjustPrice].Hidden;
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            // 明細備考
            _colDispInfo.Width_DtlNote = columns[AdjustStockAcs.ctCOL_DtlNote].Width;
            _colDispInfo.Order_DtlNote = columns[AdjustStockAcs.ctCOL_DtlNote].Header.VisiblePosition;
            _colDispInfo.Visible_DtlNote = !columns[AdjustStockAcs.ctCOL_DtlNote].Hidden;
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            // 定価（浮動）
            _colDispInfo.Width_ListPriceFl = columns[AdjustStockAcs.ctCOL_ListPriceFl].Width;
            _colDispInfo.Order_ListPriceFl = columns[AdjustStockAcs.ctCOL_ListPriceFl].Header.VisiblePosition;
            _colDispInfo.Visible_ListPriceFl = !columns[AdjustStockAcs.ctCOL_ListPriceFl].Hidden;
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
		/// Grid明細種別リスト作成処理
		/// </summary>
		/// <param name="grid">対象グリッド</param>
		private void MakeDetailKindCodeList(UltraGrid grid)
		{
			if (!grid.DisplayLayout.ValueLists.Exists(ctKEY_DetailKindList))
			{
				// 明細種別リストの作成
				ValueList wkList = new ValueList();
				wkList.Key = ctKEY_DetailKindList;
				wkList.DisplayStyle = ValueListDisplayStyle.DisplayTextAndPicture;
				wkList.DropDownListMinWidth = 0;
				wkList.MaxDropDownItems = 3;

				ValueListItem addItem;

				// アイテム－(該当無し)
				addItem = new ValueListItem();
				wkList.ValueListItems.Add(addItem);
				addItem.DataValue = ConstantManagement_SF_AP.DetailKindCode.None;                                
				addItem.DisplayText = "";

				// 通常品
				addItem = new ValueListItem();
				wkList.ValueListItems.Add(addItem);
				addItem.DataValue = 0 ;
                addItem.DisplayText = ctGoodState_normalItem;

				// 不良品
				addItem = new ValueListItem();
				wkList.ValueListItems.Add(addItem);
                addItem.DataValue = 1;
				addItem.DisplayText = ctGoodsState_errorItem;

				// グリッドにリストを追加する
				grid.DisplayLayout.ValueLists.Add(wkList);
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].ValueList = this.StockGrid.DisplayLayout.ValueLists[ctKEY_DetailKindList];
                //grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Style = UltraWinGrid.ColumnStyle.DropDownList;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            }
            grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsGuide].CellButtonAppearance.Image = _guideButtonImage;
            grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
        }

        /// <summary>
        /// Grid 商品ガイドボタン
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        private void GoodsGuideToGrid(UltraGrid grid)
        {
            UltraButton _goodsButton = new UltraButton();

            _goodsButton.ImageList = IconResourceManagement.ImageList16;

            grid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsGuide].Style = UltraWinGrid.ColumnStyle.Button;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
		/// Gridのキーマッピングの設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : 原価入力Gridのキーマッピングを設定します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		private void MakeKeyMappingForGrid()
		{
			GridKeyActionMapping enterMap;

			//----- Enterキー
            enterMap = new GridKeyActionMapping(
                Keys.Enter,
                UltraGridAction.NextCellByTab,
                0,
                UltraGridState.Cell,
                SpecialKeys.All,
                0);
            StockGrid.KeyActionMappings.Add(enterMap);

			//----- Shift + Enterキー
			enterMap = new GridKeyActionMapping(
				Keys.Enter,
				UltraGridAction.PrevCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.AltCtrl,
				SpecialKeys.Shift);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- ↑キー
			enterMap = new GridKeyActionMapping(
				Keys.Up,
				UltraGridAction.AboveCell,
				UltraGridState.IsDroppedDown,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new GridKeyActionMapping(
				Keys.Up,
				UltraGridAction.ExitEditMode,
				UltraGridState.IsDroppedDown,
				UltraGridState.RowFirst | UltraGridState.HasDropdown,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- ↓キー
			enterMap = new GridKeyActionMapping(
				Keys.Down,
				UltraGridAction.BelowCell,
				UltraGridState.IsDroppedDown,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
			enterMap = new GridKeyActionMapping(
				Keys.Down,
				UltraGridAction.ExitEditMode,
				UltraGridState.IsDroppedDown,
				UltraGridState.RowLast | UltraGridState.HasDropdown,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- 前頁キー
			enterMap = new GridKeyActionMapping(
				Keys.Prior,
				UltraGridAction.PageUpCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);

			//----- 次頁キー
			enterMap = new GridKeyActionMapping(
				Keys.Next,
				UltraGridAction.PageDownCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			StockGrid.KeyActionMappings.Add(enterMap);
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 品番入力チェック処理
		/// </summary>
		/// <param name="prevVal">入力済みテキスト</param>
		/// <param name="key">入力文字</param>
		/// <param name="selstart">選択開始位置</param>
		/// <param name="sellength">選択テキスト文字数</param>
		/// <returns>True:入力文字受付可, False:入力文字受付不可</returns>
		private bool KeyPressPartsNoCheck(string prevVal, char key, int selstart, int sellength)
		{
			int withHyphenLength = 24;
			int withoutHyphenLength = 20;

			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}

			// 英数字,ハイフン以外はNG
			if (!Regex.IsMatch(key.ToString(), "[a-zA-Z0-9-]"))
			{
				return false;
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// ハイフン数取得
			int hyphenCnt = 0;
			foreach(char wkChar in _strResult)
			{
				if (wkChar == '-') hyphenCnt++;
			}

			// ハイフン数チェック
			if ((hyphenCnt >= withHyphenLength - withoutHyphenLength) && (key == '-'))
			{
				return false;
			}

			// ハイフン無し桁数チェック
			if ((_strResult.Length - hyphenCnt >= withoutHyphenLength) && (key != '-'))
			{
				return false;
			}

			// キーが押された結果の文字列を生成する
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック
			if (_strResult.Length > withHyphenLength)
			{
				return false;
			}

			return true;
		}
        
        /// <summary>
		/// 品番入力チェック処理
		/// </summary>
		/// <param name="inputString">入力品番</param>
		/// <returns>チェック・修正後品番</returns>
		private string TextChangePartsNoCheck(string inputString)
		{
			if (inputString == null) return "";

			int withHyphenLength = 24;
			int withoutHyphenLength = 20;
			int hyphenCnt = 0;
			StringBuilder retStr = new StringBuilder();

			for (int i = 0; i < inputString.Length; i++)
			{
				// 英数字,ハイフン以外はNG
				if (!Regex.IsMatch(inputString[i].ToString(), "[a-zA-Z0-9-]"))
				{
					continue;
				}

				if (inputString[i] == '-')
				{
					// 追加可能であれば追加する
					if (hyphenCnt < withHyphenLength - withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
					// ハイフンカウンタインクリメント
					hyphenCnt++;
				}
				else
				{
					// 追加可能であれば追加する
					if (retStr.Length - hyphenCnt < withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
				}
			}

			return retStr.ToString();
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

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
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
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
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 編集可否変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void methoduoptSet_ValueChanged(object sender, EventArgs e)
        {
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー設定反映処理
        /// </summary>
        /// <param name="userSettingList">ユーザー設定リスト</param>
        /// <remarks>
        /// <br>Note       : ユーザー設定を反映します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void SetUserSetting(ArrayList userSettingList)
        {
            ArrayList captionKeyList = new ArrayList();
            captionKeyList = (ArrayList)userSettingList[0];

            ArrayList captionNameList = new ArrayList();
            captionNameList = (ArrayList)userSettingList[1];

            ArrayList visibleList = new ArrayList();
            visibleList = (ArrayList)userSettingList[2];

            ArrayList visibleAllowList = new ArrayList();
            visibleAllowList = (ArrayList)userSettingList[3];

            ArrayList visiblePositionList = new ArrayList();
            visiblePositionList = (ArrayList)userSettingList[4];

            ArrayList moveAllowList = new ArrayList();
            moveAllowList = (ArrayList)userSettingList[5];

            ColumnsCollection columns = this.StockGrid.DisplayLayout.Bands[0].Columns;

            try
            {
                this.StockGrid.BeginUpdate();

                columns[AdjustStockAcs.ctCOL_RowNum].Header.VisiblePosition = 0;
                for (int index = 0; index < captionKeyList.Count; index++)
                {
                    for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                    {
                        if ((String)captionKeyList[index] == columns[columnIndex].Key)
                        {
                            columns[columnIndex].Hidden = (Boolean)visibleList[index];
                            columns[columnIndex].Header.VisiblePosition = (int)visiblePositionList[index];
                            break;
                        }
                    }
                }
            }
            finally
            {
                this.StockGrid.EndUpdate();
            }
        }

        /// <summary>
        /// ユーザー設定取得処理
        /// </summary>
        /// <param name="userSettingList">ユーザー設定リスト</param>
        /// <remarks>
        /// <br>Note       : ユーザー設定を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void GetUserSetting(out ArrayList userSettingList)
        {
            userSettingList = new ArrayList();

            ArrayList captionKeyList = new ArrayList();
            ArrayList captionNameList = new ArrayList();
            ArrayList visibleList = new ArrayList();
            ArrayList visibleAllowList = new ArrayList();
            ArrayList visiblePositionList = new ArrayList();
            ArrayList moveAllowList = new ArrayList();

            ColumnsCollection columns = this.StockGrid.DisplayLayout.Bands[0].Columns;

            SortedList<int, string> columnList = new SortedList<int, string>();

            columnList.Add(columns[AdjustStockAcs.ctCOL_RowNum].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_RowNum].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_GoodsNo].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_GoodsNo].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_GoodsName].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_GoodsName].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_BLGoodsCode].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_BLGoodsCode].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_GoodsMakerCd].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_SupplierCd].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_SupplierCd].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_ListPriceFl].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_ListPriceFl].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_StockUnitPrice].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_StockUnitPrice].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_SalesOrderUnit].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_AfSalesOrderUnit].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_WarehouseShelfNo].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_SalesOrderCount].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_SalesOrderCount].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_SupplierStock].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_SupplierStock].Key);
            columnList.Add(columns[AdjustStockAcs.ctCOL_DtlNote].Header.VisiblePosition, columns[AdjustStockAcs.ctCOL_DtlNote].Key);

            foreach (int key in columnList.Keys)
            {
                for (int index = 0; index < columns.Count; index++)
                {
                    if (columnList[key] != columns[index].Key)
                    {
                        continue;
                    }

                    captionKeyList.Add(columns[index].Key);
                    visibleList.Add(!(columns[index].Hidden));
                    visiblePositionList.Add(key);

                    if (columns[index].Key == AdjustStockAcs.ctCOL_RowNum)
                    {
                        captionNameList.Add("No");
                        visibleAllowList.Add(false);
                        moveAllowList.Add(false);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_GoodsNo)
                    {
                        captionNameList.Add("品番");
                        visibleAllowList.Add(false);
                        moveAllowList.Add(false);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_GoodsName)
                    {
                        captionNameList.Add("品名");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_BLGoodsCode)
                    {
                        captionNameList.Add("BLｺｰﾄﾞ");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_GoodsMakerCd)
                    {
                        captionNameList.Add("メーカー");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_SupplierCd)
                    {
                        captionNameList.Add("仕入先");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_ListPriceFl)
                    {
                        captionNameList.Add("標準価格");
                        visibleAllowList.Add(false);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_StockUnitPrice)
                    {
                        captionNameList.Add("原単価");
                        visibleAllowList.Add(false);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_SalesOrderUnit)
                    {
                        captionNameList.Add("仕入数");
                        visibleAllowList.Add(false);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_AfSalesOrderUnit)
                    {
                        captionNameList.Add("仕入後数");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_WarehouseShelfNo)
                    {
                        captionNameList.Add("棚番");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_SalesOrderCount)
                    {
                        captionNameList.Add("発注残");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_SupplierStock)
                    {
                        captionNameList.Add("在庫数");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                    else if (columns[index].Key == AdjustStockAcs.ctCOL_DtlNote)
                    {
                        captionNameList.Add("明細備考");
                        visibleAllowList.Add(true);
                        moveAllowList.Add(true);
                    }
                }
            }

            userSettingList.Add(captionKeyList);
            userSettingList.Add(captionNameList);
            userSettingList.Add(visibleList);
            userSettingList.Add(visibleAllowList);
            userSettingList.Add(visiblePositionList);
            userSettingList.Add(moveAllowList);
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void RowDelete_ultraButton_Click(object sender, EventArgs e)
        {
            // ActiveRowインデックス取得処理
            int rowIndex;
            if (this.StockGrid.ActiveCell != null)
            {
                rowIndex = this.StockGrid.ActiveCell.Row.Index;
            }
            else if (this.StockGrid.ActiveRow != null)
            {
                rowIndex = this.StockGrid.ActiveRow.Index;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "明細が選択されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            // 入力行チェック
            if (this.StockGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Text.Trim() == string.Empty)
            {
                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択行を削除してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // 明細行削除処理
            this._adjustStockAcs.DelRowData(index);

            // 次入力可能セル移動処理
            this.StockGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

            //合計数
            double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
            lbltotalCount.Text = totalCount.ToString("#,###,##0");

            //合計金額
            Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
            lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
        }
        // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 選択された行を削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void RowDelete_ultraButton_Click(object sender, EventArgs e)
        {
            if ((this.StockGrid.ActiveRow == null) && (this.StockGrid.ActiveCell == null))
            {
                return;
            }

            int rowIndex;
            SelectedRowsCollection rowsCollection;
            if (this.StockGrid.ActiveRow != null)
            {
                rowIndex = this.StockGrid.ActiveRow.Index;
                rowsCollection = this.StockGrid.Selected.Rows;

                if (rowsCollection.Count == 0)
                {
                    rowsCollection.Add(this.StockGrid.Rows[rowIndex]);
                }
            }
            else
            {
                rowIndex = this.StockGrid.ActiveCell.Row.Index;
                rowsCollection = new SelectedRowsCollection();
                rowsCollection.Add(this.StockGrid.Rows[rowIndex]);
            }
            
            if (rowsCollection == null)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "明細が選択されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択行を削除してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            List<int> deleteIndex = new List<int>();
            foreach (UltraGridRow row in rowsCollection)
            {
                deleteIndex.Add(row.Index);
            }

            deleteIndex.Sort();

            List<ArrayList> keyList = new List<ArrayList>();

            foreach (UltraGridRow row in rowsCollection)
            {
                if ((row.Cells[AdjustStockAcs.ctCOL_FileHeaderGuid].Value == DBNull.Value) ||
                    ((Guid)row.Cells[AdjustStockAcs.ctCOL_FileHeaderGuid].Value == Guid.Empty))
                {
                    continue;
                }

                int makerCode = this._adjustStockAcs.StringObjToInt(row.Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value);
                string goodsNo = (string)row.Cells[AdjustStockAcs.ctCOL_GoodsNo].Value;

                ArrayList paraList = new ArrayList();
                paraList.Add(makerCode);
                paraList.Add(goodsNo);

                keyList.Add(paraList);
            }

            for (int index = deleteIndex.Count - 1; index >= 0; index--)
            {
                // 明細行削除処理
                this._adjustStockAcs.DelRowData(deleteIndex[index]);
            }

            for (int index = 0; index < keyList.Count; index++)
            {
                // 仕入後数設定
                this._adjustStockAcs.SetAfSalesOrderUnit((int)keyList[index][0], (string)keyList[index][1]);
            }

            // 次入力可能セル移動処理
            this.StockGrid.Rows[rowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

            // 合計数・合計金額設定
            SetTotal(false);
        }

        /// <summary>
        /// 合計数・合計金額設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 合計数と合計金額を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SetTotal(bool updateFlg)
        {
            //合計数
            double totalCount = _adjustStockAcs.GetTotalCount();
            lbltotalCount.Text = totalCount.ToString("N");

            //合計金額
            Int64 totalPrice;
            if (updateFlg)
            {
                // 伝票修正時
                totalPrice = _adjustStockAcs.GetTotalStockPriceTaxExc();
            }
            else
            {
                // 新規、発注計上時
                totalPrice = _adjustStockAcs.GetTotalPrice();
            }
            lblTotalPrice.Text = totalPrice.ToString(ctFormatNum);
        }

        /// <summary>
        /// 検索実行処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫検索を実行します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void Performed_uButton_Click(object sender, EventArgs e)
        {
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "先に倉庫コードを入力してください。",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_WarehouseCode.Focus();

                return;
            }

            // 倉庫コード取得
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');

            // 在庫検索ガイドを起動
            object retObj;
            StockSearchGuide stockSearchGuide = new StockSearchGuide();
            stockSearchGuide.IsMultiSelect = true;
            stockSearchGuide.IsFixedSection = true;
            stockSearchGuide.IsFixedWarehouseCode = true;

            // 検索用パラメータ
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = this._enterpriseCode;
            stockSearchPara.ZeroStckDsp = 0;    // ゼロ件在庫表示する
            stockSearchPara.SectionCode = this.tEdit_SectionCode.DataText.Trim();
            stockSearchPara.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim();
            
            // 検索モード
            StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
            guideMode = StockSearchGuide.emSearchMode.GoodsStock;

            // 検索呼出
            DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);
            if (dialogResult == DialogResult.OK)
            {
                // 選択情報を画面に反映
                List<Stock> stockEachWarehouseRetList = retObj as List<Stock>;

                List<Stock> stockList = new List<Stock>();
                foreach (Stock stock in stockEachWarehouseRetList)
                {
                    if (stock.WarehouseCode.Trim().PadLeft(4, '0') != warehouseCode)
                    {
                        continue;
                    }

                    stockList.Add(stock);
                }

                if (stockEachWarehouseRetList.Count != stockList.Count)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "入力されている倉庫に存在しない在庫が選択されました。",
                    -1,
                    MessageBoxButtons.OK);
                }

                // グリッドに反映
                this._adjustStockAcs.StockListToGrid(stockList);

                foreach (Stock stock in stockList)
                {
                    // 仕入後数設定
                    this._adjustStockAcs.SetAfSalesOrderUnit(stock.GoodsMakerCd, stock.GoodsNo);
                }
            }

            // 合計数・合計金額設定
            SetTotal(false);

            this.StockGrid.PerformAction(UltraGridAction.ExitEditMode);
            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 検索実行処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Performed_uButton_Click(object sender, EventArgs e)
        {
//            SearchGross(sender, e);

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //switch (ModetCmbEditor.SelectedIndex)
            //{
            //    case ctMode_ProductReEdit:
            //    case ctMode_GoodsCodeStatus:
            //        {
            //            //製番単位での検索のみ
            //            SearchProd(sender, e);
            //            break;
            //        }
            //    case ctMode_UnitPriceReEdit:
            //        {
            //            //グロス単位検索可能性あり
            //            SearchGross(sender, e);
            //            break;
            //        }
            //    default:
            //        {
            //            //グロス単位検索可能性あり
            //            SearchGross(sender, e);
            //            break;
            //        }
            //}
            SearchGross(sender, e);
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 製番単位検索
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SearchProd(object sender,EventArgs e)
        //{
        //    // 在庫検索ガイドを起動
        //    object retObj;
        //    StockSearchGuide stockSearchGuide = new StockSearchGuide();
        //    
        //    stockSearchGuide.IsMultiSelect = true;
        //                
        //    //検索用パラメータ
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    stockSearchPara.ZeroStckDsp = 1;//ゼロ件在庫表示しない
        //
        //    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //    //// 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //    //if ((GetEditMode() == 0) || (GetEditMode() == 4))
        //    //{
        //    //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //    //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //    //    stockSearchPara.StockState = stockState;
        //    //}
        //    //else if (GetEditMode() == 1)
        //    //{
        //    //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //    //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //    //    stockSearchPara.StockState = stockState;
        //    //}
        //    //else
        //    //{
        //    //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //    //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //    //    stockSearchPara.StockState = stockState;
        //    //}
        //    //
        //    //int[] moveStatus = { 0 };
        //    //stockSearchPara.MoveStatus = moveStatus;
        //    //
        //    //if (this.ModetCmbEditor.SelectedIndex == ctMode_ProductReEdit)
        //    //{
        //    //    stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
        //    //}
        //    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //    //検索モード
        //    StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
        //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //    //switch (ModetCmbEditor.SelectedIndex)
        //    //{
        //    //    case ctMode_ProductReEdit:
        //    //    case ctMode_GoodsCodeStatus:
        //    //        {
        //    //            guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
        //    //            break;
        //    //        }
        //    //    case ctMode_UnitPriceReEdit:
        //    //        {
        //    //            if (_stockPointWay != 1)
        //    //            {
        //    //                guideMode = StockSearchGuide.emSearchMode.StockProduct;
        //    //            }
        //    //            else
        //    //            {
        //    //                guideMode = StockSearchGuide.emSearchMode.GoodsStock;
        //    //            }
        //    //            break;
        //    //        }
        //    //    default :
        //    //        {
        //    //            guideMode = StockSearchGuide.emSearchMode.StockProduct;
        //    //            break;
        //    //        }
        //    //}
        //    guideMode = StockSearchGuide.emSearchMode.GoodsStock;
        //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //    
        //    //検索呼出
        //    DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);
        //
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //List<ProductStock> productStockRetList;
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        List<Stock> stockRetList = null;
        //
        //        //選択情報を画面に反映
        //        ArrayList retList = new ArrayList();
        //        if (guideMode != StockSearchGuide.emSearchMode.GoodsStock)
        //        {
        //            retList = retObj as ArrayList;
        //        }
        //        else
        //        {
        //            List<Stock> setStock = retObj as List<Stock>;
        //            retList.Add(setStock);
        //        }
        //
        //        bool setProduct = false;
        //        int StockPos = 0;
        //
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //if (chkPrdNumMng(retList) != true)
        //        //{
        //        //    return;
        //        //}
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //        if (ChkExist(retList) != false)
        //        {
        //            return;
        //        }
        //
        //        for (int i = 0; i < retList.Count; i++)
        //        {
        //            if (retList[i] is List<Stock>)
        //            {
        //                stockRetList = retList[i] as List<Stock>;
        //                StockPos = i;
        //                if ((stockRetList != null) && (stockRetList.Count > 0))
        //                {
        //                    _adjustStockAcs.StockToList(stockRetList);
        //                }
        //            }
        //        }
        //
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //for (int i = 0; i < retList.Count; i++)
        //        //{
        //        //    if (retList[i] is List<ProductStock>)
        //        //    {
        //        //        productStockRetList = retList[i] as List<ProductStock>;
        //        //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
        //        //        {
        //        //            int setRow = -1;
        //        //            _adjustStockAcs.ProductStockToGrid(productStockRetList,stockRetList, setRow, GetEditerMode());
        //        //            setProduct = true;
        //        //        }
        //        //    }
        //        //}
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        if (setProduct != true)
        //        {
        //            stockRetList = retList[StockPos] as List<Stock>;
        //            _adjustStockAcs.StockToGrid(stockRetList,-1);
        //        }
        //    }
        //
        //    //合計数
        //    double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
        //    lbltotalCount.Text = totalCount.ToString();
        //
        //    //合計金額
        //    Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
        //    lblTotalPrice.Text = totalPrice.ToString();
        //
        //    this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.ExitEditMode);
        //    this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.EnterEditMode);
        //
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グロス単位検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchGross(object sender,EventArgs e)
        {
            // 在庫検索ガイドを起動
            object retObj;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //StockWarehouseSearchGuide stockSearchGuide = new StockWarehouseSearchGuide();
            StockSearchGuide stockSearchGuide = new StockSearchGuide();
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            
            stockSearchGuide.IsMultiSelect = true;
                        
            //検索用パラメータ
            StockSearchPara stockSearchPara = new StockSearchPara();
            stockSearchPara.EnterpriseCode = this._enterpriseCode;
            // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
            //stockSearchPara.ZeroStckDsp = 1;//ゼロ件在庫表示しない
            stockSearchPara.ZeroStckDsp = 0;//ゼロ件在庫表示する
            // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //if ((GetEditMode() == 0) || (GetEditMode() == 4))
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else if (GetEditMode() == 1)
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else
            //{
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //
            //int[] moveStatus = { 0 };
            //stockSearchPara.MoveStatus = moveStatus;
            //
            //if (this.ModetCmbEditor.SelectedIndex == ctMode_ProductReEdit)
            //{
            //    stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            //検索モード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //StockWarehouseSearchGuide.emSearchMode guideMode = new StockWarehouseSearchGuide.emSearchMode();
            StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //switch (ModetCmbEditor.SelectedIndex)
            //{
            //    case ctMode_ProductReEdit:
            //    case ctMode_GoodsCodeStatus:
            //        {
            //            //製番単位はない
            //            break;
            //        }
            //    case ctMode_UnitPriceReEdit:
            //        {
            //            if (_stockPointWay != 1)
            //            {
            //                guideMode = StockWarehouseSearchGuide.emSearchMode.StockProduct;                                
            //            }
            //            else
            //            {
            //                guideMode = StockWarehouseSearchGuide.emSearchMode.GoodsStock;
            //            }
            //            break;
            //        }
            //    default :
            //        {
            //            guideMode = StockWarehouseSearchGuide.emSearchMode.StockProduct;
            //            break;
            //        }
            //}
            guideMode = StockSearchGuide.emSearchMode.GoodsStock;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            //検索呼出
            DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);

            if (dialogResult == DialogResult.OK)
            {
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //List<ProductStock> productStockRetList;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                //List<Stock> stockRetList = null;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //List<StockEachWarehouse> stockEachWarehouseRetList = null;
                List<StockExpansion> stockEachWarehouseRetList = null;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                //選択情報を画面に反映
                ArrayList retList = new ArrayList();
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if (guideMode != StockWarehouseSearchGuide.emSearchMode.GoodsStock)
                if (guideMode != StockSearchGuide.emSearchMode.GoodsStock)
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    retList = retObj as ArrayList;
                }
                else
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //List<StockEachWarehouse> setStockEachWarehouse = retObj as List<StockEachWarehouse>;
                    List<StockExpansion> setStockEachWarehouse = retObj as List<StockExpansion>;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    //List<Stock> setStock = retObj as List<Stock>;
                    retList.Add(setStockEachWarehouse);
                }

                bool setProduct = false;
                int StockPos = 0;

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if (ChkPrdNumMngGrs(retList) != true)
                //{
                //    return;
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                if (ChkExistGrs(retList) != false)
                {
                    return;
                }

                for (int i = 0; i < retList.Count; i++)
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //if (retList[i] is List<StockEachWarehouse>)
                    if (retList[i] is List<StockExpansion>)
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    {
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //stockEachWarehouseRetList = retList[i] as List<StockEachWarehouse>;
                        stockEachWarehouseRetList = retList[i] as List<StockExpansion>;
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        StockPos = i;
                        if ((stockEachWarehouseRetList != null) && (stockEachWarehouseRetList.Count > 0))
                        {
                            _adjustStockAcs.StockToListGrs(stockEachWarehouseRetList);
                        }
                    }
                }

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //for (int i = 0; i < retList.Count; i++)
                //{
                //    if (retList[i] is List<ProductStock>)
                //    {
                //        productStockRetList = retList[i] as List<ProductStock>;
                //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
                //        {
                //            int setRow = -1;
                //            _adjustStockAcs.ProductStockToGridGrs(productStockRetList, stockEachWarehouseRetList, setRow, GetEditerMode());
                //            setProduct = true;
                //        }
                //    }
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                if (setProduct != true)
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockEachWarehouseRetList = retList[StockPos] as List<StockEachWarehouse>;
                    stockEachWarehouseRetList = retList[StockPos] as List<StockExpansion>;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    _adjustStockAcs.StockToGridGrs(stockEachWarehouseRetList, -1);
                }

            }

            //合計数
            double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lbltotalCount.Text = totalCount.ToString();
            lbltotalCount.Text = totalCount.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            //合計金額
            Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lblTotalPrice.Text = totalPrice.ToString();
            lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.ExitEditMode);
            this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.EnterEditMode);

        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 製番管理有無チェック
        ///// </summary>
        ///// <param name="chktList"></param>
        ///// <returns></returns>
        //private bool chkPrdNumMng(ArrayList chkList)
        //{
        //    bool chkSt = true;
        //    for (int i = 0; i < chkList.Count; i++)
        //    {
        //        if (chkList[i] is List<Stock>)
        //        {
        //            List<Stock> stockList;
        //            stockList = chkList[i] as List<Stock>;
        //            if ((stockList != null) && (stockList.Count > 0))
        //            {
        //                foreach (Stock stockRet in stockList)
        //                {
        //                    if (stockRet.PrdNumMngDiv == 0)
        //                    {
        //                        TMsgDisp.Show(
        //                        Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                        ctPGID,
        //                        "製番管理しない商品が選択されています。追加処理を中止します。",
        //                        0,
        //                        MessageBoxButtons.OK);
        //                        chkSt = false;
        //                        return chkSt;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return chkSt;
        //}
        //private bool ChkPrdNumMngGrs(ArrayList chkList)
        //{
        //    bool chkSt = true;
        //    for (int i = 0; i < chkList.Count; i++)
        //    {
        //        if (chkList[i] is List<StockEachWarehouse>)
        //        {
        //            List<StockEachWarehouse> stockEachWarehouseList;
        //            stockEachWarehouseList = chkList[i] as List<StockEachWarehouse>;
        //            if ((stockEachWarehouseList != null) && (stockEachWarehouseList.Count > 0))
        //            {
        //                foreach(StockEachWarehouse stockEachWarehouseRet in stockEachWarehouseList)
        //                {
        //                    if (stockEachWarehouseRet.PrdNumMngDiv == 0)
        //                    {
        //                        TMsgDisp.Show(
        //                        Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                        ctPGID,
        //                        "製番管理しない商品が選択されています。追加処理を中止します。",
        //                        0,
        //                        MessageBoxButtons.OK);
        //                        chkSt = false;
        //                        return chkSt;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return chkSt;
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 2008.03.28 削除
        // 2008.03.28 削除 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 重複チェック
        /// </summary>
        //private bool ChkExist(ArrayList chkList)
        //{
        //    //選択データ重複チェック
        //    bool chkSt = false;
        //    bool productExist = false;

        //    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //    #region 2007.10.11 削除
        //    //for (int i = 0; i < chkList.Count; i++)
        //    //{
        //    //    if (chkSt) break;
        //    //
        //    //    //重複チェック
        //    //    if (chkList[i] is List<ProductStock>)
        //    //    {
        //    //        List<ProductStock> productStockRetList;
        //    //        productStockRetList = chkList[i] as List<ProductStock>;
        //    //
        //    //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
        //    //        {
        //    //            productExist = true;
        //    //            foreach (ProductStock productStockRet in productStockRetList)
        //    //            {
        //    //                if (chkSt) break;
        //    //                for (int ii = 0; ii < this.StockGrid.Rows.Count; ii++)
        //    //                {
        //    //                    if (this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_RowType].Value == System.DBNull.Value) 
        //    //                    {
        //    //                        continue;
        //    //                    }
        //    //                    if ((Int32)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_RowType].Value == 1)
        //    //                    {
        //    //                        //製番単位の明細で一致していたら重複エラー
        //    //                        if (productStockRet.FileHeaderGuid == (System.Guid)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_FileHeaderGuid].Value)
        //    //                        {
        //    //                            //重複があるので追加しない
        //    //                            chkSt = true;
        //    //                            TMsgDisp.Show(
        //    //                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //    //                            ctPGID,
        //    //                            "商品が重複しています。追加処理を中止します。",
        //    //                            0,
        //    //                            MessageBoxButtons.OK);
        //    //                            break;
        //    //                        }
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        //伝票単位の明細があり、企業・拠点・メーカー・商品が一致したらエラー
        //    //                        if ((productStockRet.EnterpriseCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Value)
        //    //                            && (productStockRet.SectionCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Value)
        //    //                            && (productStockRet.MakerCode == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_MakerCode].Value)
        //    //                            && (productStockRet.GoodsCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))
        //    //                        {
        //    //                            //重複があるので追加しない
        //    //                            chkSt = true;
        //    //                            TMsgDisp.Show(
        //    //                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //    //                            ctPGID,
        //    //                            "商品が重複しています。追加処理を中止します。",
        //    //                            0,
        //    //                            MessageBoxButtons.OK);
        //    //                            break;
        //    //                        }
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    #endregion
        //    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //    if (productExist != true)
        //    {
        //        //個別法のとき、製番管理する商品の商品単位呼出不可(製番単位で呼ぶこと不可)
        //        for (int i = 0; i < chkList.Count; i++)
        //        {
        //            if (chkSt) break;
        //            if (chkList[i] is List<Stock>)
        //            {
        //                List<Stock> stockRetList;
        //                stockRetList = chkList[i] as List<Stock>;

        //                if ((stockRetList != null) && (stockRetList.Count > 0))
        //                {
        //                    foreach (Stock stockRet in stockRetList)
        //                    {
        //                        if (chkSt) break;
        //                        for (int ii = 0; ii < this.StockGrid.Rows.Count; ii++)
        //                        {
        //                            if ((String.IsNullOrEmpty(this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Text)) ||
        //                                (String.IsNullOrEmpty(this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Text)))
        //                            {
        //                                // null有=>未入力
        //                                continue;
        //                            }


        //                            //企業・拠点・メーカー・商品一致で重複エラー
        //                            if ((stockRet.EnterpriseCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Value)
        //                                && (stockRet.SectionCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Value)
        //                                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //                                //&& (stockRet.MakerCode == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_MakerCode].Value)
        //                                //&& (stockRet.GoodsCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))
        //                                && (stockRet.GoodsMakerCd == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value)
        //                                && (stockRet.GoodsNo == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value))
        //                                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //                            {
        //                                //重複があるので追加しない
        //                                chkSt = true;
        //                                TMsgDisp.Show(
        //                                Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                                ctPGID,
        //                                "商品が重複しています。追加処理を中止します。",
        //                                0,
        //                                MessageBoxButtons.OK);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return chkSt;
        //}
        // 2008.03.28 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private bool ChkExistGrs(ArrayList chkList)
        {
            //選択データ重複チェック
            bool chkSt = false;
            bool productExist = false;

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 2007.10.11 削除
            //for (int i = 0; i < chkList.Count; i++)
            //{
            //    if (chkSt) break;
            //
            //    //重複チェック
            //    if (chkList[i] is List<ProductStock>)
            //    {
            //        List<ProductStock> productStockRetList;
            //        productStockRetList = chkList[i] as List<ProductStock>;
            //
            //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
            //        {
            //            productExist = true;
            //            foreach (ProductStock productStockRet in productStockRetList)
            //            {
            //                if (chkSt) break;
            //                for (int ii = 0; ii < this.StockGrid.Rows.Count; ii++)
            //                {
            //                    if (this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_RowType].Value == System.DBNull.Value)
            //                    {
            //                        continue;
            //                    }
            //                    if ((Int32)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_RowType].Value == 1)
            //                    {
            //                        //製番単位の明細で一致していたら重複エラー
            //                        if (productStockRet.FileHeaderGuid == (System.Guid)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_FileHeaderGuid].Value)
            //                        {
            //                            //重複があるので追加しない
            //                            chkSt = true;
            //                            TMsgDisp.Show(
            //                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                            ctPGID,
            //                            "商品が重複しています。追加処理を中止します。",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                            break;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        //伝票単位の明細があり、企業・拠点・メーカー・商品が一致したらエラー
            //                        if ((productStockRet.EnterpriseCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Value)
            //                            && (productStockRet.SectionCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Value)
            //                            && (productStockRet.MakerCode == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_MakerCode].Value)
            //                            && (productStockRet.GoodsCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))
            //                        {
            //                            //重複があるので追加しない
            //                            chkSt = true;
            //                            TMsgDisp.Show(
            //                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                            ctPGID,
            //                            "商品が重複しています。追加処理を中止します。",
            //                            0,
            //                            MessageBoxButtons.OK);
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //
            //}
            #endregion
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            if (productExist != true)
            {
                //個別法のとき、製番管理する商品の商品単位呼出不可(製番単位で呼ぶこと不可)
                for (int i = 0; i < chkList.Count; i++)
                {
                    if (chkSt) break;

                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //if (chkList[i] is List<StockEachWarehouse>)
                    //{
                    //    List<StockEachWarehouse> stockRetList;
                    //    stockRetList = chkList[i] as List<StockEachWarehouse>;
                    //
                    //    if ((stockRetList != null) && (stockRetList.Count > 0))
                    //    {
                    //        foreach (StockEachWarehouse stockRet in stockRetList)
                    if (chkList[i] is List<StockSearchPara>)
                    {
                        List<StockSearchPara> stockRetList;
                        stockRetList = chkList[i] as List<StockSearchPara>;

                        if ((stockRetList != null) && (stockRetList.Count > 0))
                        {
                            foreach (StockSearchPara stockRet in stockRetList)
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            {
                                if (chkSt) break;
                                for (int ii = 0; ii < this.StockGrid.Rows.Count; ii++)
                                {
                                    if ((String.IsNullOrEmpty(this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Text)) ||
                                        (String.IsNullOrEmpty(this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Text)))
                                    {
                                        // null有=>未入力
                                        continue;
                                    }


                                    //企業・拠点・メーカー・商品一致で重複エラー
                                    if ((stockRet.EnterpriseCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_EnterpriseCode].Value)
                                        && (stockRet.SectionCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_SectionCode].Value)
                                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                                        //&& (stockRet.MakerCode == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_MakerCode].Value)
                                        //&& (stockRet.GoodsCode == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))
                                        && (stockRet.GoodsMakerCd == (int)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value)
                                        && (stockRet.GoodsNo == (string)this.StockGrid.Rows[ii].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value))
                                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                                    {
                                        //重複があるので追加しない
                                        chkSt = true;
                                        TMsgDisp.Show(
                                        Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        ctPGID,
                                        "商品が重複しています。追加処理を中止します。",
                                        0,
                                        MessageBoxButtons.OK);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return chkSt;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// GRIDレイアウト変更
        /// </summary>
        /// <remarks>
        /// <br>Note       : GRIDのレイアウトを変更します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void ChangeGridLayout()
        {
            //GRID初期化
            ClrDsp(false);

            AdjustStockAcs adjustStockAcs = this._adjustStockAcs;

            ColumnsCollection columns = this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns;

            //Visible制御
            columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;

            GoodsSearch_ultraButton.Enabled = true;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録実行処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Regist_uButton_Click(object sender, EventArgs e)
        {
            int chkSt = CheckInputData(sender);

            switch (chkSt)
            {
                case -1:
                    {
                        TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ctPGID,
                            "商品が1件も登録されていません。",
                            0,
                            MessageBoxButtons.OK);
                        return;
                    }
                case 1:
                    {
                        TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ctPGID,
                            "日付の入力がありません。",
                            0,
                            MessageBoxButtons.OK);
                        makedate_tDateEdit.Focus();
                        return;
                    }
                case -2:
                    {
                        TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ctPGID,
                            "調整数の入力がない行があります。",
                            0,
                            MessageBoxButtons.OK);
                        makedate_tDateEdit.Focus();
                        return;
                    }
            }

            string retMessage;
            string setMsg = edtNote1.Text;

            //登録
            _adjustStockAcs.editDate = GetDate();
            DateTime adjustDate = GetDate();
            int status = _adjustStockAcs.SaveDBData(out retMessage,ModetCmbEditor.SelectedIndex,setMsg,adjustDate);
            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                this.ClrDsp(false);
            }
            else
            {
                MessageBox.Show("更新に失敗しました。" + "(" + status.ToString() + ")");
            }
        }

        /// <summary>
        /// GRIDレイアウト変更
        /// </summary>
        private void ChangeGridLayout(int ChangeMode)
        {
            //GRID初期化

            this.ClrDsp(false);

            AdjustStockAcs adjustStockAcs = _adjustStockAcs;

            //商品コード入力は全て大文字            
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCode].CharacterCasing = CharacterCasing.Upper;
            // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
            //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsNo].CharacterCasing = CharacterCasing.Upper;
            // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        
            switch (ChangeMode)
            {
                case ctMode_StockAdjust: // 在庫調整
                    {                        
                        //Visible制御
                        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                        _colDispInfo.SetAdjustPriceValue();
                        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = false;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = false;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = true;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = false;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Hidden = true;
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustPrice].Hidden = false;
                        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<

                        //個別評価法時は商品検索不可
                        if (_stockPointWay == 3)
                        {
                            GoodsSearch_ultraButton.Enabled = false;
                        }
                        else
                        {
                            GoodsSearch_ultraButton.Enabled = true;
                        }
                        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //ProductSearch_ultraButton.Enabled = true;
                        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                        break;
                    }
                // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_TrustAdjust: // 受託調整
                //    {
                //        //Visible制御
                //        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = false;
                //        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = false;
                //        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = true;
                //        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                //        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = false;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Hidden = true;
                //        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //        GoodsSearch_ultraButton.Enabled = true;
                //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //        //ProductSearch_ultraButton.Enabled = true;
                //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                //        break;
                //    }
                // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_ProductReEdit: // 製番調整
                //    {
                //        //Visible制御
                //        //_colDispInfo.SetProductValue();
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = false;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = false;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = true;
                //        GoodsSearch_ultraButton.Enabled = false;
                //        ProductSearch_ultraButton.Enabled = true;
                //        break;
                //    }
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                case ctMode_UnitPriceReEdit: // 原価調整
                    {
                        //Visible制御
                        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                        _colDispInfo.SetAdjustPriceValue();
                        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = false;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = true;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = true;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = false;
                        //this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = false;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Hidden = true;
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustPrice].Hidden = false;
                        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<

                        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////最終仕入時は製番検索不可
                        //if (_stockPointWay == 1)
                        //{
                        //    ProductSearch_ultraButton.Enabled = false;
                        //}
                        //else
                        //{
                        //    ProductSearch_ultraButton.Enabled = true;
                        //}
                        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                        //個別評価法時は商品検索不可
                        if (_stockPointWay == 3)
                        {
                            GoodsSearch_ultraButton.Enabled = false;
                        }
                        else
                        {
                            GoodsSearch_ultraButton.Enabled = true;
                        }
                        break;
                    }
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //case ctMode_GoodsCodeStatus: // 不良品
                //    {
                //        //Visible制御
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_StockTelNo1].Hidden = false;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfProductNumber].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                //        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_GoodsCodeStatus].Hidden = false;
                //        GoodsSearch_ultraButton.Enabled = false;
                //        ProductSearch_ultraButton.Enabled = true;
                //        break;
                //    }
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
                case ctMode_ShelfNoReEdit: // 棚番調整
                    {
                        //Visible制御
                        _colDispInfo.SetShelfNoValue();
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustCount].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfStockUnitPrice].Hidden = true;
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_BfWarehouseShelfNo].Hidden = false;
                        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                        this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns[AdjustStockAcs.ctCOL_AdjustPrice].Hidden = true;
                        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
                        GoodsSearch_ultraButton.Enabled = true;
                        break;
                    }
                // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
        /// GRID・項目初期化
        /// </summary>
        /// <param name="chgMode"></param>
        public void ClrDsp(bool chgMode)
        {
            changeFocusFooter(false);

            //GRID初期化
            _adjustStockAcs.DBDataClear();

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
            _adjustStockAcs.StockDataClear();
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

            AdjustStockAcs.RepaintProductStock();

            //金額・合計初期化
            edtNote1.Text = "";
            lbltotalCount.Text = "0.00";
            lblTotalPrice.Text = "0";
            this.AllDispClear(true);

            if (chgMode == true)
            {
                //Mode初期化
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                //ModetCmbEditor.SelectedIndex = ctMode_StockAdjust;
                //ChangeGridLayout(ModetCmbEditor.SelectedIndex);
                //_dispMode = ModetCmbEditor.SelectedIndex;
                //_adjustStockAcs.edtiMode = ModetCmbEditor.SelectedIndex;
                ChangeGridLayout();
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
            }

            this._orderListResultFlg = false;

            this._searchFlg = false;
        }

        /// <summary>
        /// 従業員マスタ取得処理
        /// </summary>
        /// <returns>従業員マスタ</returns>
        private string GetInputAgentCode()
        {
            return this.tEdit_EmployeeCode.DataText.Trim();
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void ModetCmbEditor_AfterCloseUp(object sender, EventArgs e)
        {
            if (_dispMode == ModetCmbEditor.SelectedIndex)
            {
                //変化してないので処理せず
                return;
            }
            //選択した区分によってGRIDのEnable制御を変更
            ChangeGridLayout(ModetCmbEditor.SelectedIndex);
            _dispMode = ModetCmbEditor.SelectedIndex;
            _adjustStockAcs.edtiMode = ModetCmbEditor.SelectedIndex;
            ChangeTotalEdit(_dispMode);
        }
        /// <summary>
        /// 編集モード取得
        /// </summary>
        private int GetEditerMode()
        {
            int getmode = ModetCmbEditor.SelectedIndex;
            return getmode;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト


        // ----- ADD 2011/07/18 ------------------------->>>>>
        /// <summary>
        /// 全体初期値設定を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体初期値設定を取得処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/07/18</br>
        /// <br>連番1028</br>
        /// </remarks>
        private void GetDtlCalcStckCntDsp()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
            ArrayList retAllDefSetList;
            status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode, allDefSetSearchMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ログイン担当者の所属拠点もしくは全社設定を取得
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
            }
            else
            {
                this._allDefSet = null;
            }
        }

        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == "00")
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }
        // ----- ADD 2011/07/18 -------------------------<<<<<



        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : セルの値が更新された後に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 朱俊成</br>
        /// <br>             PM.NS-5</br>
        /// <br>             在庫仕入入力で標準価格と原単価の入力制御の修正</br>
        /// </remarks>
        private void StockGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGridCell activecell = this.StockGrid.ActiveCell;

            if ((activecell == null) || (activecell.Value == null))
            {
                return;
            }

            if (activecell.Value is DBNull)
            {
                // --- ADD 2009/12/16 ---------->>>>>
                if (!(((_listPriceInpDiv == 1) && (activecell.Column.Key == AdjustStockAcs.ctCOL_ListPriceFl)) || ((_unitPriceInpDiv == 1) && (activecell.Column.Key == AdjustStockAcs.ctCOL_StockUnitPrice))))
                {
                // --- ADD 2009/12/16 -----------<<<<<
                    if ((activecell.Column.DataType == typeof(Int32)) ||
                                       (activecell.Column.DataType == typeof(Int64)) ||
                                       (activecell.Column.DataType == typeof(double)))
                    {
                        activecell.Value = 0;
                    }
                // --- ADD 2009/12/16 ---------->>>>>
                }
                // --- ADD 2009/12/16 -----------<<<<<
            }

            // 品番取得
            string goodsNo = this._adjustStockAcs.StringObjToString(this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value);
            if (goodsNo == "")
            {
                this._warehouseCodeFocusFlg = false;

                //空白入力なので、入力行の情報をクリア
                this._adjustStockAcs.ClrRowData(activecell.Row.Index);
            }
            else
            {
                // 品番
                if (activecell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo)
                {
                    // MEMO:StockGrid_AfterCellUpdate()からの商品検索
                    SearchGoods(activecell);
                }
                // 仕入数
                else if (activecell.Column.Key == AdjustStockAcs.ctCOL_SalesOrderUnit)
                {
                    // 仕入数
                    double salesOrderUnit = DoubleObjToDouble(this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_SalesOrderUnit].Value);

                    // 発注残
                    double orderRemainCnt = StringObjToDouble(this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_SalesOrderCount].Value);

                    if (this._orderListResultFlg)
                    {
                        if (salesOrderUnit < 0)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注計上時は数量のマイナスは入力できません。",
                            0,
                            MessageBoxButtons.OK);

                            this.StockGrid.ActiveCell.Value = orderRemainCnt;
                        }
                        else if (salesOrderUnit > orderRemainCnt)
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注残数以上の仕入は行えません。",
                            0,
                            MessageBoxButtons.OK);

                            this.StockGrid.ActiveCell.Value = orderRemainCnt;
                        }
                    }
                    // ----- ADD 2010/05/20 --------------------->>>>>
                    else
                    {
                        if (MyOpeCtrl.Disabled(12))
                        {
                            if (salesOrderUnit < 0)
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "マイナス値の入力はできません。",
                                0,
                                MessageBoxButtons.OK);
                            }
                        }
                    }
                    // ----- ADD 2010/05/20 ---------------------<<<<<

                    // メーカーコード
                    int makerCode = this._adjustStockAcs.StringObjToInt(this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value);

                    // ---UPD 2011/07/18------------>>>>>
                    // 仕入後数設定
                    //this._adjustStockAcs.SetAfSalesOrderUnit(makerCode, goodsNo);

                    if (_allDefSet.DtlCalcStckCntDsp == 0)
                    {
                        // 仕入後数設定
                        this._adjustStockAcs.SetAfSalesOrderUnit(makerCode, goodsNo);
                    }
                    else
                    {
                        //なし。
                    }
                    // ---UPD 2011/07/18------------<<<<<

                }

                // --- ADD 2009/12/16 ---------->>>>>
                // 価格入力区分
                else if (activecell.Column.Key == AdjustStockAcs.ctCOL_ListPriceFl)
                {
                    // 定価入力区分が「1:不可」の場合
                    if (1 == _listPriceInpDiv)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "この項目は変更できません。",
                                0,
                                MessageBoxButtons.OK);
                        this.StockGrid.AfterCellUpdate -= this.StockGrid_AfterCellUpdate;
                        this.StockGrid.ActiveCell.Value = this._beforeListPriceInpDiv;
                        this.StockGrid.AfterCellUpdate += this.StockGrid_AfterCellUpdate;
                    }

                }
                // 単価入力区分
                else if (activecell.Column.Key == AdjustStockAcs.ctCOL_StockUnitPrice)
                {
                    // 単価入力区分が「1:不可」の場合
                    if (1 == _unitPriceInpDiv)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "この項目は変更できません。",
                                0,
                                MessageBoxButtons.OK);
                        this.StockGrid.AfterCellUpdate -= this.StockGrid_AfterCellUpdate;
                        this.StockGrid.ActiveCell.Value = this._beforeUnitPriceInpDiv;
                        this.StockGrid.AfterCellUpdate += this.StockGrid_AfterCellUpdate;
                    }
                }
                // --- ADD 2009/12/16 -----------<<<<<
            
            }

            // 合計数・合計金額設定
            SetTotal(false);
        }

        private double DoubleObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (double)cellValue;
            }
        }

        private double StringObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return double.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// 在庫検索画面表示処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <param name="activecell">アクティブセル</param>
        /// <remarks>
        /// <br>Note       : 在庫検索画面を表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2010/06/08 楊明俊</br>
        /// <br>               障害改良対応</br>
        /// <br>               同一品番選択ウィンドウでの在庫数表示を修正する。</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>               障害改良対応x月</br>
        /// <br>               あいまい検索で在庫品を選択した場合に、品番が表示が不正になる不具合の修正。</br>
        /// <br>UpdateNote :  2011/07/18 曹文傑</br>
        /// <br>              MANTIS[17500] 連番1028 仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
        /// <br>Update Note: 2011/11/02 楊明俊</br>
        /// <br>             redmine#26320 ハイフンありとなしの同一品番が存在し、ハイフンありのみ在庫登録されていませんの対応</br>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        /// <br>Update Note: 2013/02/27 zhujc</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#34858 在庫品仕入入力</br>
        /// <br>Update Note: 2021/10/08 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
        /// <br>Update Note: 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : BLINCIDENT-3254 再度同一品番選択画面が表示される対応</br> 
        /// </remarks>
        private void SearchGoods(UltraGridCell activecell)
        {
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "先に倉庫コードを入力してください。",
                    -1,
                    MessageBoxButtons.OK);

                this._warehouseCodeFocusFlg = true;

                return;
            }

            this._warehouseCodeFocusFlg = false;

            // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
            //this._stockExistFlg = true;
            // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
            ExistsStockWithEvents = true;   // ADD 2009/11/16 3次分対応 在庫登録機能を追加

            // 倉庫コード取得
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

            // 拠点コード
            string sectionCode = this.tEdit_SectionCode.DataText.Trim();

            string goodsCode = activecell.Value.ToString();

            // 商品連結データ検索条件設定
            GoodsCndtn goodsCndtn;
            this._adjustStockAcs.SetGoodsCndtn(out goodsCndtn, LoginInfoAcquisition.EnterpriseCode, 0, goodsCode, sectionCode);

            // --- ADD 2010/06/08 ---------->>>>>
            List<string> listPriorWarehouseStr = new List<string>();
            listPriorWarehouseStr.Add(warehouseCode);
            goodsCndtn.ListPriorWarehouse = listPriorWarehouseStr;
            // --- ADD 2010/06/08 ----------<<<<<

            goodsCndtn.PriceApplyDate = this.makedate_tDateEdit.GetDateTime();
            
            string msg = "";
            List<GoodsUnitData> goodsUnitDataList;

            // 商品連結データ取得
            //int status = this._adjustStockAcs.GetGoodsUnitDataList(goodsCndtn, out goodsUnitDataList, out msg);//Del zhangy3 2013/01/04 For Redmine#33845
            // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>> 
            goodsCndtn.GoodsNo = goodsCode;
            //int status = this.GoodsAccesserForInputingStock.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg); // DEL zhujc on 2013/02/27 For Redmine#34858
            int status = this.GoodsAccesserForInputingStock.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg, true);// ADD zhujc on 2013/02/27 For Redmine#34858
            //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                try
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                    // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
                    //// 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                    //if (goodsCode.ToUpper().Equals(goodsCode) &&
                    //    !goodsCode.Equals(goodsUnitData.GoodsNo))
                    string chkInputGoodsNo = string.Empty;
                    string chkSearchGoodsNo = string.Empty;
                    // 比較用品番取得
                    GetCompareGoodsNo(goodsCode, goodsUnitData.GoodsNo, out chkInputGoodsNo, out chkSearchGoodsNo);
                    // 入力品番が大文字 且つ 検索された品番が入力品番と不一致の場合
                    if (chkInputGoodsNo.ToUpper().Equals(chkInputGoodsNo) &&
                        !chkInputGoodsNo.Equals(chkSearchGoodsNo))
                    // --- UPD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<
                    {
                        // ユーザー分品番検索
                        GoodsUnitData goodsUnitDataCk;
                        int ckStatus = this.GoodsAccesserForInputingStock.Read(LoginInfoAcquisition.EnterpriseCode, sectionCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, out goodsUnitDataCk);

                        // ユーザー分商品登録される場合
                        if (ckStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 小文字品番で再検索
                            goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                            goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // ADD 陳艶丹 2022/01/20 BLINCIDENT-3254

                            // 商品検索
                            status = this.GoodsAccesserForInputingStock.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg, true);
                        }
                    }
                }
                catch
                {
                    // エラーメッセージを表示
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                            form,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            StrResearchErrMsg,
                            0,
                            MessageBoxButtons.OK);
                    form.TopMost = false;

                    // 行クリア
                    this._adjustStockAcs.ClrRowData(activecell.Row.Index);

                    // 一旦、trueとし、[在庫(F8)]ボタンを操作不可にする→改めてfalseとする
                    ExistsStockWithEvents = true;
                    this._stockExistFlg = false;    // 商品が存在しない場合は在庫登録操作は不可（∴イベント付セッタを使用しない）

                    return;
                }
            }
            //--- ADD 陳艶丹 2021/10/08 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (((goodsUnitDataList[0].StockList.Count == 0) || null == (goodsUnitDataList[0].StockList))
                    && goodsUnitDataList[0].GoodsMakerCd > 999)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                msg = "選択した商品は商品登録されていません。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            //--- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    // 2010/07/14 Add >>>
                    _makerCode = goodsUnitDataList[0].GoodsMakerCd;
                    goodsCndtn.GoodsMakerCd = _makerCode;
                    goodsCndtn.GoodsNo = goodsUnitDataList[0].GoodsNo; // ADD 2010/12/20
                    //----- ADD 2011/11/02----->>>>>
                    // 商品番号検索区分
                    if (goodsCndtn.GoodsNo.Contains("-") == true)
                    {
                        goodsCndtn.GoodsNoSrchTyp = 0;
                    }
                    else
                    {
                        goodsCndtn.GoodsNoSrchTyp = 4;
                    }
                    // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
                    if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
                    {                       
                        if (goodsUnitDataList[0].OfferKubun == 3)
                        {
                            //3:提供純正品番
                            msg = "選択した商品は商品登録されていません。";
                            TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      msg,
                                      -1,
                                      MessageBoxButtons.OK);

                            this._adjustStockAcs.ClrRowData(activecell.Row.Index);
                            ExistsStockWithEvents = true;
                            this._stockExistFlg = false;
                            return;
 
                        }
                        if (Guid.Empty.Equals(goodsUnitDataList[0].FileHeaderGuid))
                        {
                            break;
                        }
                    }
                    //--- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
                    //----- ADD 2011/11/02-----<<<<<
                    this._adjustStockAcs.GetGoodsUnitDataList(goodsCndtn, out goodsUnitDataList, out msg, ConstantManagement.LogicalMode.GetData01);
                    // 2010/07/14 Add <<<
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:  // MEMO:商品は存在するが、在庫がない場合
                        // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                        // 同一品番選択ウィンドウでキャンセルした場合はクリアする
                        if ( goodsUnitDataList == null || goodsUnitDataList.Count == 0 )
                        {
                            this._adjustStockAcs.ClrRowData( activecell.Row.Index );
                        }
                        // --- ADD m.suzuki 2010/01/14 ----------<<<<<

                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        //this._stockExistFlg = false;
                        //return;
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        ExistsStockWithEvents = false;
                        break;
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      msg,
                                      -1,
                                      MessageBoxButtons.OK);

                        this._adjustStockAcs.ClrRowData(activecell.Row.Index);

                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        // 一旦、trueとし、[在庫(F8)]ボタンを操作不可にする→改めてfalseとする
                        ExistsStockWithEvents = true;
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        this._stockExistFlg = false;    // 商品が存在しない場合は在庫登録操作は不可（∴イベント付セッタを使用しない）

                        return;
                    }
            }

            // GRIDへ反映
            if (goodsUnitDataList.Count > 0)
            {
                // DEL 2009/06/17 ------>>>
                //// 同一商品が存在していた場合
                //if (this._adjustStockAcs.CheckSameGoodsUnitData(goodsUnitDataList[0].GoodsMakerCd, goodsUnitDataList[0].GoodsNo))
                //{
                //    TMsgDisp.Show(this,
                //                  emErrorLevel.ERR_LEVEL_INFO,
                //                  this.Name,
                //                  "同一品番が入力済みです。",
                //                  -1,
                //                  MessageBoxButtons.OK);

                //    this._adjustStockAcs.ClrRowData(activecell.Row.Index);
                //    this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                //    this._stockExistFlg = false;

                //    return;
                //}
                // DEL 2009/06/17 ------<<<
                
                this._adjustStockAcs.IsDataChanged = true;

                // グリッドに反映
                status = this._adjustStockAcs.GoodsUnitDataToGrid(goodsUnitDataList[0], warehouseCode, sectionCode, activecell.Row.Index);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                                    //"選択品番は在庫品ではありません。",
                                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                                      "選択した商品は在庫登録されていません。", // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                                      -1,
                                      MessageBoxButtons.OK);

                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    //this._adjustStockAcs.ClrRowData(activecell.Row.Index);
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    // MEMO:商品は存在するが、在庫がない場合はそのまま
                    if (!status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN))
                    {
                        this._adjustStockAcs.ClrRowData(activecell.Row.Index);
                    }
                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                    this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();

                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    //this._stockExistFlg = false;
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                    ExistsStockWithEvents = false;  // ADD 2009/11/16 3次分対応 在庫登録機能を追加

                    return;
                }

                // ---UPD 2011/07/18------------->>>>>
                // 仕入後数設定
                //this._adjustStockAcs.SetAfSalesOrderUnit(goodsUnitDataList[0].GoodsMakerCd, goodsUnitDataList[0].GoodsNo);

                if (this._allDefSet.DtlCalcStckCntDsp == 0)
                {
                    // 仕入後数設定
                    this._adjustStockAcs.SetAfSalesOrderUnit(goodsUnitDataList[0].GoodsMakerCd, goodsUnitDataList[0].GoodsNo);
                }
                else
                {
                    //なし。
                }
                // ---UPD 2011/07/18-------------<<<<<
            }

            // 最終行の場合は、１行追加する
            if (activecell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
            {
                AdjustStockAcs.IncrementProductStock();
            }

            // 合計数・合計金額設定
            SetTotal(false);

            this._searchFlg = true;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 ----->>>>>
        /// <summary>
        /// 比較用品番取得(ハイフン「-」と前方一致検索用の「*」を除き)
        /// </summary>
        /// <param name="inputGoodsNo">入力品番</param>
        /// <param name="searchGoodsNo">検索品番</param>
        /// <param name="compareInputGoodsNo">比較用入力品番</param>
        /// <param name="compareSearchGoodsNo">比較用検索品番</param>
        /// <remarks>
        /// <br>Note       : 2022/01/20 陳艶丹</br>
        /// <br>管理番号   : 11800082-00</br>
        /// <br>           : 比較用品番取得</br> 
        /// </remarks>
        private void GetCompareGoodsNo(string inputGoodsNo, string searchGoodsNo, out string compareInputGoodsNo, out string compareSearchGoodsNo)
        {
            compareInputGoodsNo = string.Empty;
            compareSearchGoodsNo = string.Empty;
            try
            {
                // 入力品番
                // ハイフンを除き
                string rstStr = string.Empty;
                rstStr = inputGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、前方一致検索用"*"を除き
                if (inputGoodsNo.EndsWith(CTASTER)) rstStr = rstStr.Substring(0, rstStr.Length - 1);
                compareInputGoodsNo = rstStr;

                // 検索品番
                // ハイフンを除き
                rstStr = string.Empty;
                rstStr = searchGoodsNo.Replace(CTHYPHEN, string.Empty);
                // 曖昧検索の場合、入力品番より一部品番で比較
                if (inputGoodsNo.EndsWith(CTASTER) && rstStr.Length > compareInputGoodsNo.Length)
                {
                    rstStr = rstStr.Substring(0, compareInputGoodsNo.Length);
                }
                compareSearchGoodsNo = rstStr;
            }
            catch
            {
                // 取得失敗時、既存処理に影響しない為、比較しない
                compareInputGoodsNo = string.Empty;
                compareSearchGoodsNo = string.Empty;
            }
        }
        // --- ADD 陳艶丹 2022/01/20 BLINCIDENT-3254 再度同一品番選択画面が表示される対応 -----<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void StockGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null || e.Cell.Value == null) return;
            
            UltraWinGrid.UltraGridCell activecell = e.Cell;

            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
            }            

            // ActiveCellの内容を変更
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if (activecell.Column.Key == AdjustStockAcs.ctCOL_GoodsCode)
            if (activecell.Column.Key == AdjustStockAcs.ctCOL_GoodsNo)
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            {
                if (e.Cell.Value.ToString().Trim() != "")
                {
                    //商品コード                
                    ChangeGoodsCode(sender, e, activecell);
                }
                else
                {
                    //空白入力なので、入力行の情報をクリア
                    _adjustStockAcs.ClrRowData(activecell.Row.Index);
                }
            }
            else if (activecell.Column.Key == AdjustStockAcs.ctCOL_AdjustCount)
            {
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value != System.DBNull.Value) &&
                //   ((!String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))))
                if ((this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value != System.DBNull.Value) &&
                   ((!String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value))))
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    //調整数
                    ChangeAdjustCount(sender, e, activecell);
                }
                else
                {
                    //空白入力なので、入力行の情報をクリア
                    _adjustStockAcs.ClrRowData(activecell.Row.Index);
                }
            }
            else//商品CD空白なら無効
            {
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value != System.DBNull.Value) &&
                //   ((!String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))))
                if ((this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value != System.DBNull.Value) &&
                   ((!String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value))))
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                }
                else
                {
                    //空白入力なので、入力行の情報をクリア
                    _adjustStockAcs.ClrRowData(activecell.Row.Index);
                }
            }
            //合計数
            double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lbltotalCount.Text = totalCount.ToString();
            lbltotalCount.Text = totalCount.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            //合計金額
            Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lblTotalPrice.Text = totalPrice.ToString();
            lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.ExitEditMode);
            this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.EnterEditMode);

            //次のセルを強制的に調整数へ
            if ((GetEditerMode() == 0) || (GetEditerMode() == 1))
            {
                this.StockGrid.ActiveCell = this.StockGrid.Rows[activecell.Row.Index+1].Cells[AdjustStockAcs.ctCOL_SupplierStock];
                this.StockGrid.PerformAction(UltraWinGrid.UltraGridAction.EnterEditMode);                
            }            
        }

        /// <summary>
        /// 商品コード変更時反映処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeGoodsCode(object sender, CellEventArgs e, UltraWinGrid.UltraGridCell activecell)
        {
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //string goodsCode = activecell.Value.ToString();
            //
            ////現在の編集モード
            //int mode = this.ModetCmbEditor.SelectedIndex;
            //
            //
            //switch (mode)
            //{
            //    case ctMode_StockAdjust:
            //        {
            //            if (_stockPointWay != 3)
            //            {
            //                SearchGoods(sender, e, activecell);                            
            //            }
            //            else
            //            {
            //                ChangeGoodsCodeProd(sender, e, activecell);
            //            }
            //            break;
            //        }
            //    case ctMode_TrustAdjust:
            //        {
            //            SearchGoods(sender, e, activecell);
            //            break;
            //        }
            //    case ctMode_UnitPriceReEdit:
            //        {
            //            if (_stockPointWay == 3)
            //            {
            //                ChangeGoodsCodeProd(sender, e, activecell);
            //            }
            //            else
            //            {
            //                SearchGoods(sender, e, activecell);
            //            }
            //            break;
            //        }
            //    case ctMode_ProductReEdit:
            //    case ctMode_GoodsCodeStatus:
            //        {
            //            ChangeGoodsCodeProd(sender, e, activecell);
            //            break;
            //        }
            //}
            SearchGoods(sender, e, activecell);
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        }

        private void SearchGoods(object sender ,CellEventArgs e, UltraWinGrid.UltraGridCell activecell)
        {
            string goodsCode = activecell.Value.ToString();

            //現在の編集モード
            int mode = this.ModetCmbEditor.SelectedIndex;

            // 商品コードが入力されていた場合
            if (!String.IsNullOrEmpty(goodsCode))
            {

                // 商品検索ガイド画面のインスタンスを生成                
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //StockWarehouseSearchGuide stockWarehouseSearchGuide = new StockWarehouseSearchGuide();
                StockSearchGuide stockSearchGuide = new StockSearchGuide();
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                // 商品検索ガイド検索条件データ
                StockSearchPara stockSearchPara = new StockSearchPara();
                
                stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                stockSearchPara.SectionCode = GetSection();

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //if ((GetEditMode() == 0) || (GetEditMode() == 4))
                //{
                //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                //else if (GetEditMode() == 1)
                //{
                //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                //else
                //{
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                //
                //// 移動状態
                //// 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
                //int[] moveStatus = { 0 };
                //stockSearchPara.MoveStatus = moveStatus;
                //
                //// 商品状態
                //// 0:正常,1:不良品
                //int[] goodsCodeStatus = { -1, 0, 1 };
                //stockSearchPara.GoodsCodeStatus = goodsCodeStatus;
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // ゼロ在庫表示(0:表示する 1:表示しない)
                // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
                //stockSearchPara.ZeroStckDsp = 1;
                stockSearchPara.ZeroStckDsp = 0;
                // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<

                // 商品コード検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)
                // 完全一致判別
                int targetIndex = goodsCode.IndexOf("*");

                // 完全一致
                if (targetIndex == -1)
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockSearchPara.GoodsCodeSrchTyp = 0;
                    stockSearchPara.GoodsNoSrchTyp = 0;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                }
                // 曖昧検索
                else if (goodsCode.StartsWith("*") && goodsCode.EndsWith("*"))
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockSearchPara.GoodsCodeSrchTyp = 3;
                    stockSearchPara.GoodsNoSrchTyp = 3;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    goodsCode = goodsCode.Replace("*", "");
                }
                // 前方一致
                else if (goodsCode.EndsWith("*"))
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockSearchPara.GoodsCodeSrchTyp = 1;
                    stockSearchPara.GoodsNoSrchTyp = 1;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    goodsCode = goodsCode.Replace("*", "");
                }
                // 後方一致
                else if (goodsCode.StartsWith("*"))
                {
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //stockSearchPara.GoodsCodeSrchTyp = 2;
                    stockSearchPara.GoodsNoSrchTyp = 2;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    goodsCode = goodsCode.Replace("*", "");
                }

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if (mode == ctMode_ProductReEdit)
                //{
                //      //stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 商品コード
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //stockSearchPara.GoodsCode = goodsCode;
                stockSearchPara.GoodsNo = goodsCode;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                
                
                // 商品検索ガイド結果オブジェクト

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //List<ProductStock> productstockSearchRetList = new List<ProductStock>();
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                string msg = "";
                object retObj = null;

                // 商品検索ガイド画面の表示
                int st = 0;

                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if (mode == ctMode_StockAdjust)
                //{
                //    //st = stockSearchGuide.ReadStock(this, false, true, stockSearchPara, out retObj, out msg);
                //    st = stockWarehouseSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
                //}
                //else if (mode == ctMode_TrustAdjust)
                //{
                //    st = stockWarehouseSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
                //}
                //else if (mode == ctMode_UnitPriceReEdit)
                //{
                //    if (_stockPointWay == 1)
                //    {
                //        st = stockWarehouseSearchGuide.ReadStock(this, false, false, stockSearchPara, out retObj, out msg);
                //    }
                //    else
                //    {
                //        st = stockWarehouseSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
                //    }
                //}
                //else
                //{
                //}
                st = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
               
                //ステータスにて判定
                switch (st)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL: //キャンセル
                        {
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Activate();
                            this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            return;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN: //該当データなし
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                msg,
                                -1,
                                MessageBoxButtons.OK);
                            _adjustStockAcs.ClrRowData(activecell.Row.Index);
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Activate();
                            this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                            return;
                        }
                }
                // GRIDへ反映
                if (retObj != null)
                {
                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //List<ProductStock> productStockRetList;
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                    //List<Stock> stockRetList = null;
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //List<StockEachWarehouse> stockEachWareHouseList = null;
                    List<StockExpansion> stockExpansionList = null;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                    //選択情報を画面に反映
                    ArrayList retList = new ArrayList();

                    // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
                    //if ((mode == ctMode_UnitPriceReEdit) && (_stockPointWay == 1))
                    //{
                    //    //List<Stock> setStock = retObj as List<Stock>;
                    //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //    //List<StockEachWarehouse> setStockEachWarehouse = retObj as List<StockEachWarehouse>;
                    //    List<StockExpansion> setStockEachWarehouse = retObj as List<StockExpansion>;
                    //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                    //    //retList.Add(setStock);
                    //    retList.Add(setStockEachWarehouse);
                    //}
                    //else
                    //{
                    //    //retList = retObj as ArrayList;

                    //    List<StockExpansion> setStockExpansion = retObj as List<StockExpansion>;
                    //    retList.Add(setStockExpansion);
                    //}
                    List<StockExpansion> setStockExpansion = retObj as List<StockExpansion>;
                    retList.Add(setStockExpansion);
                    // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    ////製番訂正時製番管理有無判定
                    //if (mode == ctMode_ProductReEdit)
                    //{
                    //    if (ChkPrdNumMngGrs(retList) != true)
                    //    {
                    //        _adjustStockAcs.ClrRowData(activecell.Row.Index);
                    //        return;
                    //    }
                    //}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                    //既に同一商品あり
                    if (ChkExistGrs(retList) != false)
                    {
                        _adjustStockAcs.ClrRowData(activecell.Row.Index);
                        
                        return;
                    }

                    this._adjustStockAcs.IsDataChanged = true;
                    bool setProduct = false;
                    int StockPos = 0;
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //List<StockEachWarehouse> stockList = new List<StockEachWarehouse>();
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    // 先にStock分取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (retList[i] is List<StockEachWarehouse>)
                        if (retList[i] is List<StockExpansion>)
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        {
                            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //stockEachWareHouseList = retList[i] as List<StockEachWarehouse>;
                            //StockPos = i;
                            //if ((stockEachWareHouseList != null) && (stockEachWareHouseList.Count > 0))
                            //{
                            //    _adjustStockAcs.StockToListGrs(stockEachWareHouseList);
                            //}
                            stockExpansionList = retList[i] as List<StockExpansion>;
                            StockPos = i;
                            if ((stockExpansionList != null) && (stockExpansionList.Count > 0))
                            {
                                _adjustStockAcs.StockToListGrs(stockExpansionList);
                            }
                            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        }
                    }

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //// 原価調整で最終仕入法の時は読まない (ガイドが対応していないため回避法)
                    //for (int i = 0; i < retList.Count; i++)
                    //{
                    //    if (retList[i] is List<ProductStock>)
                    //    {
                    //        productStockRetList = retList[i] as List<ProductStock>;
                    //
                    //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
                    //        {
                    //            foreach (ProductStock productStockRet in productStockRetList)
                    //            {
                    //                UltraWinGrid.UltraGridCell activeCell = e.Cell;
                    //                
                    //                _adjustStockAcs.ProductStockToGridGrs(productStockRetList, stockEachWareHouseList, activeCell.Row.Index, GetEditerMode());
                    //                setProduct = true;
                    //            }
                    //        }
                    //    }
                    //}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                    if (setProduct != true)
                    {
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //stockEachWareHouseList = retList[StockPos] as List<StockEachWarehouse>;
                        //
                        //_adjustStockAcs.StockToGridGrs(stockEachWareHouseList, e.Cell.Row.Index);
                        stockExpansionList = retList[StockPos] as List<StockExpansion>;

                        _adjustStockAcs.StockToGridGrs(stockExpansionList, e.Cell.Row.Index);
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    }                    
                }

                // 最終行の場合は、１行追加する
                if (activecell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
                {
                    AdjustStockAcs.IncrementProductStock();
                }

                //合計数
                double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
                // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                //lbltotalCount.Text = totalCount.ToString();
                lbltotalCount.Text = totalCount.ToString("#,###,##0");
                // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

                //合計金額
                Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
                // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                //lblTotalPrice.Text = totalPrice.ToString();
                lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
                // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //private void ChangeGoodsCodeProd(object sender, CellEventArgs e, UltraWinGrid.UltraGridCell activecell)
        //{
        //    string goodsCode = activecell.Value.ToString();
        //
        //    //現在の編集モード
        //    int mode = this.ModetCmbEditor.SelectedIndex;
        //
        //    // 商品コードが入力されていた場合
        //    if (!String.IsNullOrEmpty(goodsCode))
        //    {
        //        // 商品検索ガイド画面のインスタンスを生成
        //        StockSearchGuide stockSearchGuide = new StockSearchGuide();
        //
        //        // 商品検索ガイド検索条件データ
        //        StockSearchPara stockSearchPara = new StockSearchPara();
        //
        //        stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //
        //        stockSearchPara.SectionCode = GetSection();
        //
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //// 在庫状態
        //        //if ((GetEditMode() == 0) || (GetEditMode() == 4))
        //        //{
        //        //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //        //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //        //    stockSearchPara.StockState = stockState;
        //        //}
        //        //else if (GetEditMode() == 1)
        //        //{
        //        //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //        //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //        //    stockSearchPara.StockState = stockState;
        //        //}
        //        //else
        //        //{
        //        //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //        //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //        //    stockSearchPara.StockState = stockState;
        //        //}
        //        //
        //        //// 移動状態
        //        // 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
        //        //int[] moveStatus = { 0 };
        //        //stockSearchPara.MoveStatus = moveStatus;
        //        //
        //        //// 商品状態
        //        //// 0:正常,1:不良品
        //        //int[] goodsCodeStatus = { -1, 0, 1 };
        //        //stockSearchPara.GoodsCodeStatus = goodsCodeStatus;
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //        // ゼロ在庫表示(0:表示する 1:表示しない)
        //        stockSearchPara.ZeroStckDsp = 1;
        //
        //        // 商品コード検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)
        //        // 完全一致判別
        //        int targetIndex = goodsCode.IndexOf("*");
        //
        //        // 完全一致
        //        if (targetIndex == -1)
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //stockSearchPara.GoodsCodeSrchTyp = 0;
        //            stockSearchPara.GoodsNoSrchTyp = 0;
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        }
        //        // 曖昧検索
        //        else if (goodsCode.StartsWith("*") && goodsCode.EndsWith("*"))
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //stockSearchPara.GoodsCodeSrchTyp = 3;
        //            stockSearchPara.GoodsNoSrchTyp = 3;
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //            goodsCode = goodsCode.Replace("*", "");
        //        }
        //        // 前方一致
        //        else if (goodsCode.EndsWith("*"))
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //stockSearchPara.GoodsCodeSrchTyp = 1;
        //            stockSearchPara.GoodsNoSrchTyp = 1;
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //            goodsCode = goodsCode.Replace("*", "");
        //        }
        //        // 後方一致
        //        else if (goodsCode.StartsWith("*"))
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //stockSearchPara.GoodsCodeSrchTyp = 2;
        //            stockSearchPara.GoodsNoSrchTyp = 2;
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //            goodsCode = goodsCode.Replace("*", "");
        //        }
        //
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //if (mode == ctMode_ProductReEdit)
        //        //{
        //        //    //                    stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
        //        //}
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //        // 商品コード
        //        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //        //stockSearchPara.GoodsCode = goodsCode;
        //        stockSearchPara.GoodsNo = goodsCode;
        //        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //
        //        // 商品検索ガイド結果オブジェクト
        //
        //        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //List<ProductStock> productstockSearchRetList = new List<ProductStock>();
        //        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        string msg = "";
        //        object retObj;
        //
        //        // 商品検索ガイド画面の表示
        //        int st = 0;
        //
        //        if (mode == ctMode_StockAdjust)
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //if (_stockPointWay != 3)
        //            //{
        //            //    st = stockSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
        //            //}
        //            //else
        //            //{
        //            //    // 個別評価法は製番単位のみ
        //            //    st = stockSearchGuide.ReadProduct(this, false, stockSearchPara, out retObj, out msg);
        //            //}
        //            st = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        }
        //        else if (mode == ctMode_TrustAdjust)
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //st = stockSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
        //            st = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        }
        //        else if (mode == ctMode_UnitPriceReEdit)
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //if (_stockPointWay == 1)
        //            //{
        //            //    st = stockSearchGuide.ReadStock(this, false, false, stockSearchPara, out retObj, out msg);
        //            //}
        //            //else if (_stockPointWay == 3)
        //            //{
        //            //    // 個別評価法の時は製番単位のみ
        //            //    st = stockSearchGuide.ReadProduct(this, false, stockSearchPara, out retObj, out msg);
        //            //}
        //            //else
        //            //{
        //            //    st = stockSearchGuide.ReadStock(this, false, stockSearchPara, out retObj, out msg);
        //            //}
        //            st = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        }
        //        else
        //        {
        //            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //            //// 製番・不良品
        //            //st = stockSearchGuide.ReadProduct(this, false, stockSearchPara, out retObj, out msg);
        //            // 棚番
        //            st = stockSearchGuide.ReadStock(this, stockSearchPara, out retObj, out msg);
        //            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //        }
        //
        //        //ステータスにて判定
        //        switch (st)
        //        {
        //            case (int)ConstantManagement.MethodResult.ctFNC_CANCEL: //キャンセル
        //                {
        //                    this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Activate();
        //                    return;
        //                }
        //            case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN: //該当データなし
        //                {
        //                    TMsgDisp.Show(
        //                        this,
        //                        emErrorLevel.ERR_LEVEL_INFO,
        //                        this.Name,
        //                        msg,
        //                        -1,
        //                        MessageBoxButtons.OK);
        //                    _adjustStockAcs.ClrRowData(activecell.Row.Index);
        //                    this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Activate();
        //                    return;
        //                }
        //        }
        //        // GRIDへ反映
        //        if (retObj != null)
        //        {
        //
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            //List<ProductStock> productStockRetList;
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //            List<Stock> stockRetList = null;
        //
        //            //選択情報を画面に反映
        //            ArrayList retList = new ArrayList();
        //
        //            if ((mode == ctMode_UnitPriceReEdit) && (_stockPointWay == 1))
        //            {
        //                List<Stock> setStock = retObj as List<Stock>;
        //                retList.Add(setStock);
        //            }
        //            else
        //            {
        //                retList = retObj as ArrayList;
        //            }
        //
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            ////製番訂正時製番管理有無判定
        //            //if (mode == ctMode_ProductReEdit)
        //            //{
        //            //    if (chkPrdNumMng(retList) != true)
        //            //    {
        //            //        _adjustStockAcs.ClrRowData(activecell.Row.Index);
        //            //        return;
        //            //    }
        //            //}
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //            //既に同一商品あり
        //            if (ChkExist(retList) != false)
        //            {
        //                _adjustStockAcs.ClrRowData(activecell.Row.Index);
        //
        //                return;
        //            }
        //
        //            this._adjustStockAcs.IsDataChanged = true;
        //            bool setProduct = false;
        //            int StockPos = 0;
        //            List<Stock> stockList = new List<Stock>();
        //            // 先にStock分取得
        //            for (int i = 0; i < retList.Count; i++)
        //            {
        //                if (retList[i] is List<Stock>)
        //                {
        //                    stockRetList = retList[i] as List<Stock>;
        //                    StockPos = i;
        //                    if ((stockRetList != null) && (stockRetList.Count > 0))
        //                    {
        //                        _adjustStockAcs.StockToList(stockRetList);
        //                    }
        //                }
        //            }
        //
        //            // 原価調整で最終仕入法の時は読まない (ガイドが対応していないため回避法)
        //            for (int i = 0; i < retList.Count; i++)
        //            {
        //                if (retList[i] is List<ProductStock>)
        //                {
        //                    productStockRetList = retList[i] as List<ProductStock>;
        //
        //                    if ((productStockRetList != null) && (productStockRetList.Count > 0))
        //                    {
        //                        foreach (ProductStock productStockRet in productStockRetList)
        //                        {
        //                            UltraWinGrid.UltraGridCell activeCell = e.Cell;
        //                            _adjustStockAcs.ProductStockToGrid(productStockRetList, stockRetList, activeCell.Row.Index, GetEditerMode());
        //                            setProduct = true;
        //                        }
        //                    }
        //                }
        //            }
        //
        //            if (setProduct != true)
        //            {
        //                stockRetList = retList[StockPos] as List<Stock>;
        //                _adjustStockAcs.StockToGrid(stockRetList, e.Cell.Row.Index);
        //            }
        //        }
        //
        //        // 最終行の場合は、１行追加する
        //        if (activecell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
        //        {
        //            AdjustStockAcs.IncrementProductStock();
        //        }
        //
        //        //合計数
        //        double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
        //        lbltotalCount.Text = totalCount.ToString();
        //
        //        //合計金額
        //        Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
        //        lblTotalPrice.Text = totalPrice.ToString();
        //    }
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 調整数変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void ChangeAdjustCount(object sender, CellEventArgs e, UltraWinGrid.UltraGridCell activecell)
        {
            //商品コード未入力はエラー
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if (this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value == System.DBNull.Value)
            if (this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value == System.DBNull.Value)
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            {
                return;
            }
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if (String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsCode].Value))
            if (String.IsNullOrEmpty((string)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value))
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            {
                return;
            }

            //入力値取得
            double count = (Double)activecell.Value;
            //数値チェック            
            if (e.Cell.Column.DataType != typeof(double))
            {
                return;
            }

            //在庫数取得
            double orgCount = 0;
            if (GetEditerMode() == 0)
            {
                if (this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_SupplierStock].Value != System.DBNull.Value)
                {
                    orgCount = (double)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_SupplierStock].Value;
                }
            }
            // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
            //else if (GetEditerMode() == 1)
            //{
            //    if (this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_TrustCount].Value != System.DBNull.Value)
            //    {
            //        orgCount = (double)this.StockGrid.Rows[activecell.Row.Index].Cells[AdjustStockAcs.ctCOL_TrustCount].Value;
            //    }
            //}
            // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (count < 0)
            //{
            //    //マイナス入力なら一度正に変換
            //    count = count * -1;
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if (count > orgCount)
            ////入力数が在庫数を超えている→在庫数に置換え
            //{
            //    count = orgCount;
            //}

            //入力数が在庫数を超えている→在庫数に置換え（マイナス値のみ）
            if (orgCount >= 0)
            {
                double wkOrgCount = orgCount * -1;
                if (count < wkOrgCount)
                {
                    // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                    //count = wkOrgCount;

                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "在庫数がゼロ以下になる値は入力出来ません。",
                            -1,
                            MessageBoxButtons.OK);
                    count = 0;
                    // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
                }
            }
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////減算のみ可能なため、負に変換
            //count = count * -1;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            _adjustStockAcs.ProductStockChangeCell(AdjustStockAcs.ctCOL_AdjustCount, activecell.Row.Index, count);

            //合計金額
            Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lblTotalPrice.Text = totalPrice.ToString();
            lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

            //合計数
            double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //lbltotalCount.Text = totalCount.ToString();
            lbltotalCount.Text = totalCount.ToString("#,###,##0");
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

        }
        /// <summary>
        /// GUIDボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //int mode = ModetCmbEditor.SelectedIndex;
            //
            //switch (mode)
            //{
            //    case ctMode_StockAdjust:
            //        {
            //            if (_stockPointWay != 3)
            //            {
            //                CellBtnSearchGross(sender, e);
            //            }
            //            else
            //            {
            //                CellBtnSearchProd(sender, e);
            //            }
            //            break;
            //        }
            //    case ctMode_TrustAdjust:
            //        {
            //            CellBtnSearchGross(sender, e);
            //            break;
            //        }
            //    case ctMode_UnitPriceReEdit:
            //        {
            //            if (_stockPointWay == 3)
            //            {
            //                CellBtnSearchProd(sender, e);
            //            }
            //            else
            //            {
            //                CellBtnSearchGross(sender, e);
            //            }
            //            break;
            //        }
            //    case ctMode_ProductReEdit:
            //        {
            //            CellBtnSearchProd(sender, e);
            //            break;
            //        }
            //    case ctMode_GoodsCodeStatus:
            //        {
            //            CellBtnSearchProd(sender, e);
            //            break;
            //        }
            //}
            CellBtnSearchGross(sender, e);
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        }
        private void CellBtnSearchGross(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == AdjustStockAcs.ctCOL_GoodsGuide)
            {

                // ガイド起動
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ProductStock productStock = new ProductStock();
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 在庫検索ガイドを起動
                object retObj;
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //StockWarehouseSearchGuide stockSearchGuide = new StockWarehouseSearchGuide();
                StockSearchGuide stockSearchGuide = new StockSearchGuide();
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                stockSearchGuide.IsMultiSelect = true;

                //検索用パラメータ
                StockSearchPara stockSearchPara = new StockSearchPara();
                stockSearchPara.EnterpriseCode = this._enterpriseCode;
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //stockSearchPara.DataAcqrDiv = 2;//データ取得区分　製番在庫
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
                //stockSearchPara.ZeroStckDsp = 1;//ゼロ件在庫表示しない
                stockSearchPara.ZeroStckDsp = 0;//ゼロ件在庫表示する
                // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 移動状態
                //// 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
                //int[] moveStatus = { 0 };
                //stockSearchPara.MoveStatus = moveStatus;
                //
                ////                stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
                //if ((GetEditMode() == 0) || (GetEditMode() == 4))
                //{
                //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                //else if (GetEditMode() == 1)
                //{
                //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                //else
                //{
                //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
                //                     (int)ConstantManagement_Mobile.ct_StockState.Reserving,
                //                     (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
                //    stockSearchPara.StockState = stockState;
                //}
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                stockSearchGuide.IsMultiSelect = false;

                //検索モード
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //StockWarehouseSearchGuide.emSearchMode guideMode = new StockWarehouseSearchGuide.emSearchMode();
                //
                //switch (ModetCmbEditor.SelectedIndex)
                //{
                //    case ctMode_UnitPriceReEdit:
                //        {
                //            if (_stockPointWay == 1)
                //            {
                //                // 最終仕入法なら商品検索
                //                guideMode = StockWarehouseSearchGuide.emSearchMode.GoodsStock;
                //            }
                //            break;
                //        }
                //    case ctMode_StockAdjust:
                //        {
                //            //個別評価法時は製番検索のみ
                //            if (_stockPointWay != 3)
                //            {
                //                guideMode = StockWarehouseSearchGuide.emSearchMode.StockProduct;
                //            }
                //            else
                //            {
                //                
                //            }
                //            break;
                //        }
                //    default:
                //        {
                //            guideMode = StockWarehouseSearchGuide.emSearchMode.StockProduct;
                //            break;
                //        }
                //}

                StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
                guideMode = StockSearchGuide.emSearchMode.GoodsStock;
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                //検索呼出
                DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);

                if (dialogResult == DialogResult.OK)
                {

                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //List<ProductStock> productStockRetList;
                    //List<StockEachWarehouse> stockEachWarehouseRetList = null;
                    List<StockExpansion> stockEachWarehouseRetList = null;
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                    //選択情報を画面に反映
                    ArrayList retList = new ArrayList();
                    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //if (guideMode != StockWarehouseSearchGuide.emSearchMode.GoodsStock)
                    //{
                    //    retList = retObj as ArrayList;
                    //}
                    //else
                    //{
                    //    List<StockEachWarehouse> setEachWarehouseStock = retObj as List<StockEachWarehouse>;
                    //    retList.Add(setEachWarehouseStock);
                    //}
                    if (guideMode != StockSearchGuide.emSearchMode.GoodsStock)
                    {
                        retList = retObj as ArrayList;
                    }
                    else
                    {
                        List<StockExpansion> setExpansionStock = retObj as List<StockExpansion>;
                        retList.Add(setExpansionStock);
                    }
                    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    ////製番訂正時、製番有無判定
                    //if (ModetCmbEditor.SelectedIndex == ctMode_ProductReEdit)
                    //{
                    //    if (chkPrdNumMng(retList) != true)
                    //    {
                    //        return;
                    //    }
                    //}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                    // 重複チェック
                    if (ChkExistGrs(retList) != false)
                    {
                        return;
                    }

                    bool setProduct = false;
                    int StockPos = 0;
                    this._adjustStockAcs.IsDataChanged = true;
                    for (int i = 0; i < retList.Count; i++)
                    {
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (retList[i] is List<StockEachWarehouse>)
                        //{
                        //    stockEachWarehouseRetList = retList[i] as List<StockEachWarehouse>;
                        //    StockPos = i;
                        //    if ((stockEachWarehouseRetList != null) && (stockEachWarehouseRetList.Count > 0))
                        //    {
                        //        _adjustStockAcs.StockToListGrs(stockEachWarehouseRetList);
                        //    }
                        //}
                        if (retList[i] is List<StockExpansion>)
                        {
                            stockEachWarehouseRetList = retList[i] as List<StockExpansion>;
                            StockPos = i;
                            if ((stockEachWarehouseRetList != null) && (stockEachWarehouseRetList.Count > 0))
                            {
                                _adjustStockAcs.StockToListGrs(stockEachWarehouseRetList);
                            }
                        }
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    }

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //for (int i = 0; i < retList.Count; i++)
                    //{
                    //    if (retList[i] is List<ProductStock>)
                    //    {
                    //        productStockRetList = retList[i] as List<ProductStock>;
                    //
                    //        if ((productStockRetList != null) && (productStockRetList.Count > 0))
                    //        {
                    //            foreach (ProductStock productStockRet in productStockRetList)
                    //            {
                    //                UltraWinGrid.UltraGridCell activecell = e.Cell;
                    //                _adjustStockAcs.ProductStockToGridGrs(productStockRetList, stockEachWarehouseRetList, activecell.Row.Index, GetEditerMode());
                    //                setProduct = true;
                    //            }
                    //        }
                    //    }
                    //}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

                    if (setProduct != true)
                    {
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //stockEachWarehouseRetList = retList[StockPos] as List<StockEachWarehouse>;
                        stockEachWarehouseRetList = retList[StockPos] as List<StockExpansion>;
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        _adjustStockAcs.StockToGridGrs(stockEachWarehouseRetList, e.Cell.Row.Index);
                    }

                    // 最終行の場合は、１行追加する
                    if (e.Cell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
                    {
                        AdjustStockAcs.IncrementProductStock();
                    }

                    //合計数
                    double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
                    // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                    //lbltotalCount.Text = totalCount.ToString();
                    lbltotalCount.Text = totalCount.ToString("#,###,##0");
                    // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

                    //合計金額
                    Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
                    // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
                    //lblTotalPrice.Text = totalPrice.ToString();
                    lblTotalPrice.Text = totalPrice.ToString("#,###,##0");
                    // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
                }

            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //private void CellBtnSearchProd(object sender, CellEventArgs e)
        //{
        //    if (e.Cell.Column.Key == AdjustStockAcs.ctCOL_GoodsGuide)
        //    {
        //
        //        // ガイド起動
        //        ProductStock productStock = new ProductStock();
        //
        //        // 在庫検索ガイドを起動
        //        object retObj;
        //        StockSearchGuide stockSearchGuide = new StockSearchGuide();
        //        stockSearchGuide.IsMultiSelect = true;
        //
        //        //検索用パラメータ
        //        StockSearchPara stockSearchPara = new StockSearchPara();
        //        stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //        stockSearchPara.DataAcqrDiv = 2;//データ取得区分　製番在庫
        //        stockSearchPara.ZeroStckDsp = 1;//ゼロ件在庫表示しない
        //        // 移動状態
        //        // 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
        //        int[] moveStatus = { 0 };
        //        stockSearchPara.MoveStatus = moveStatus;
        //
        //        stockSearchPara.ProductNumberSrchDivCd = 1; //製番ありのみ検索
        //        if ((GetEditMode() == 0) || (GetEditMode() == 4))
        //        {
        //            // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //            int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //                             (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //                             (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //            stockSearchPara.StockState = stockState;
        //        }
        //        else if (GetEditMode() == 1)
        //        {
        //            // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
        //            int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //                             (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //                             (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //            stockSearchPara.StockState = stockState;
        //        }
        //        else
        //        {
        //            int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
        //                             (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
        //                             (int)ConstantManagement_Mobile.ct_StockState.Reserving,
        //                             (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
        //            stockSearchPara.StockState = stockState;
        //        }
        //
        //        stockSearchGuide.IsMultiSelect = false;
        //
        //        
        //        //検索モード
        //        StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
        //        switch (ModetCmbEditor.SelectedIndex)
        //        {
        //            case ctMode_ProductReEdit:
        //            case ctMode_GoodsCodeStatus:
        //                {
        //                    guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
        //                    break;
        //                }
        //            case ctMode_UnitPriceReEdit:
        //                {
        //                    if (_stockPointWay == 1)
        //                    {
        //                        // 最終仕入法なら商品検索
        //                        guideMode = StockSearchGuide.emSearchMode.GoodsStock;                                
        //                    }
        //                    else if (_stockPointWay == 3)
        //                    {
        //                        // 個別仕入法なら製番検索
        //                        guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
        //                    }
        //                    else
        //                    {
        //                        guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
        //                    }
        //                    break;
        //                }
        //            case ctMode_StockAdjust:
        //                {
        //                    //個別評価法時は製番検索のみ
        //                    if (_stockPointWay != 3)
        //                    {
        //                        guideMode = StockSearchGuide.emSearchMode.StockProduct;
        //                    }
        //                    else
        //                    {
        //                        guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
        //                    }
        //                    break;
        //                }
        //            default:
        //                {
        //                    guideMode = StockSearchGuide.emSearchMode.StockProduct;
        //                    break;
        //                }
        //        }
        //
        //        //検索呼出
        //        DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);
        //
        //        if (dialogResult == DialogResult.OK)
        //        {
        //
        //            List<ProductStock> productStockRetList;
        //            List<Stock> stockRetList = null;
        //
        //            //選択情報を画面に反映
        //            ArrayList retList = new ArrayList();
        //            if (guideMode != StockSearchGuide.emSearchMode.GoodsStock)
        //            {
        //                retList = retObj as ArrayList;
        //            }
        //            else
        //            {
        //                List<Stock> setStock = retObj as List<Stock>;
        //                retList.Add(setStock);
        //            }
        //
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            ////製番訂正時、製番有無判定
        //            //if (ModetCmbEditor.SelectedIndex == ctMode_ProductReEdit)
        //            //{
        //            //    if (chkPrdNumMng(retList) != true)
        //            //    {
        //            //        return;
        //            //    }
        //            //}
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //
        //            // 重複チェック
        //            if (ChkExist(retList) != false)
        //            {
        //                return;
        //            }
        //            this._adjustStockAcs.IsDataChanged = true;
        //            bool setProduct = false;
        //            int StockPos = 0;
        //
        //            for (int i = 0; i < retList.Count; i++)
        //            {
        //                if (retList[i] is List<Stock>)
        //                {
        //                    stockRetList = retList[i] as List<Stock>;
        //                    StockPos = i;
        //                    if ((stockRetList != null) && (stockRetList.Count > 0))
        //                    {
        //                        _adjustStockAcs.StockToList(stockRetList);
        //                    }
        //                }
        //            }
        //
        //            for (int i = 0; i < retList.Count; i++)
        //            {
        //                if (retList[i] is List<ProductStock>)
        //                {
        //                    productStockRetList = retList[i] as List<ProductStock>;
        //
        //                    if ((productStockRetList != null) && (productStockRetList.Count > 0))
        //                    {
        //                        foreach (ProductStock productStockRet in productStockRetList)
        //                        {
        //                            UltraWinGrid.UltraGridCell activecell = e.Cell;
        //                            _adjustStockAcs.ProductStockToGrid(productStockRetList,stockRetList, activecell.Row.Index, GetEditerMode());
        //                            setProduct = true;
        //                        }
        //                    }
        //                }
        //            }
        //
        //            if (setProduct != true)
        //            {
        //                stockRetList = retList[StockPos] as List<Stock>;
        //                _adjustStockAcs.StockToGrid(stockRetList, e.Cell.Row.Index );
        //            }
        //
        //            // 最終行の場合は、１行追加する
        //            if (e.Cell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
        //            {
        //                AdjustStockAcs.IncrementProductStock();
        //            }
        //
        //            //合計数
        //            double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
        //            lbltotalCount.Text = totalCount.ToString();
        //
        //            //合計金額
        //            Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
        //            lblTotalPrice.Text = totalPrice.ToString();
        //        }
        //
        //    }
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 製番検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductSearch_ultraButton_Click(object sender, EventArgs e)
        {
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 2007.10.11 削除
            ////Grosよみはありえない
            //
            //// 在庫検索ガイドを起動
            //object retObj;
            //StockSearchGuide stockSearchGuide = new StockSearchGuide();
            //stockSearchGuide.IsMultiSelect = true;
            //
            ////検索用パラメータ
            //StockSearchPara stockSearchPara = new StockSearchPara();
            //stockSearchPara.EnterpriseCode = this._enterpriseCode;
            //stockSearchPara.ZeroStckDsp = 1;//ゼロ件在庫表示しない
            //
            //// 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
            //int[] moveStatus = { 0 };
            //stockSearchPara.MoveStatus = moveStatus;
            //
            //if ((GetEditMode() == 0) || (GetEditMode()) == 4)
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else if (GetEditMode() == 1)
            //{
            //    // 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //else
            //{
            //    int[] stockState = { (int)ConstantManagement_Mobile.ct_StockState.SupplierStock,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Entrusting,
            //                         (int)ConstantManagement_Mobile.ct_StockState.Reserving,
            //                         (int)ConstantManagement_Mobile.ct_StockState.PullingOut};
            //    stockSearchPara.StockState = stockState;
            //}
            //
            ////検索モード(製番検索限定)
            //StockSearchGuide.emSearchMode guideMode = new StockSearchGuide.emSearchMode();
            //guideMode = StockSearchGuide.emSearchMode.ProductwitchStock;
            //
            ////検索呼出
            //DialogResult dialogResult = stockSearchGuide.ShowGuide(this, guideMode, false, stockSearchPara, out retObj);
            //
            //if (dialogResult == DialogResult.OK)
            //{
            //    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //    //List<ProductStock> productStockRetList;
            //    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            //    List<Stock> stockRetList = null;
            //
            //    //選択情報を画面に反映
            //    ArrayList retList = retObj as ArrayList;
            //
            //    bool setProduct = false;
            //    int StockPos = 0;
            //
            //    //製番訂正
            //    if (GetEditMode() == ctMode_ProductReEdit)
            //    {
            //        //製番管理有無チェック
            //        if (chkPrdNumMng(retList) != true)
            //        {
            //            return;
            //        }
            //    }
            //
            //    //重複チェック
            //    if (ChkExist(retList) != false)
            //    {
            //        return;
            //    }
            //
            //    this._adjustStockAcs.IsDataChanged = true;
            //    for (int i = 0; i < retList.Count; i++)
            //    {
            //        if (retList[i] is List<Stock>)
            //        {
            //            stockRetList = retList[i] as List<Stock>;
            //            StockPos = i;
            //            if ((stockRetList != null) && (stockRetList.Count > 0))
            //            {
            //                _adjustStockAcs.StockToList(stockRetList);
            //            }
            //        }
            //    }
            //
            //    for (int i = 0; i < retList.Count; i++)
            //    {
            //        if (retList[i] is List<ProductStock>)
            //        {
            //            productStockRetList = retList[i] as List<ProductStock>;
            //            if ((productStockRetList != null) && (productStockRetList.Count > 0))
            //            {
            //                int setRow = -1;
            //                _adjustStockAcs.ProductStockToGrid(productStockRetList,stockRetList, setRow, GetEditerMode());
            //                setProduct = true;
            //            }
            //        }
            //    }
            //
            //    if (setProduct != true)
            //    {
            //        stockRetList = retList[StockPos] as List<Stock>;
            //        _adjustStockAcs.StockToGrid(stockRetList, -1);
            //    }
            //
            //    //合計数
            //    double totalCount = _adjustStockAcs.ProductStockChangeTotalCount();
            //    lbltotalCount.Text = totalCount.ToString();
            //
            //    //合計金額
            //    Int64 totalPrice = _adjustStockAcs.ProductStockChangeTotalPrice();
            //    lblTotalPrice.Text = totalPrice.ToString();
            //}
    		#endregion
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 製番管理有無判定
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <returns></returns>
        private bool CheckPrdNumMngDiv(List<GoodsUnitData> goodsUnitDataList)
        {
            bool rtnSt = false;

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //for (int i = 0; i < goodsUnitDataList.Count; i++)
            //{
            //
            //    if (goodsUnitDataList[i].PrdNumMngDiv == 1)
            //    {
            //        rtnSt = true;
            //        break;
            //    }
            //
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            return rtnSt;
        }
        
        /// <summary>        
        /// ドロップダウン変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModetCmbEditor_AfterExitEditMode(object sender, EventArgs e)
        {
            if (_dispMode == ModetCmbEditor.SelectedIndex)
            {
                return;
            }

            //選択した区分によってGRIDのEnable制御を変更
            ChangeGridLayout(ModetCmbEditor.SelectedIndex);
            _dispMode = ModetCmbEditor.SelectedIndex;
            _adjustStockAcs.edtiMode = ModetCmbEditor.SelectedIndex;
            ChangeTotalEdit(_dispMode);
        }
        
        private void ChangeTotalEdit(int mode)
        {
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
            if (mode == ctMode_StockAdjust)
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            {
                lblTotalPriceTaxIncTitle.Visible = true;
                lbltotalCount.Visible = true;
                lblTotalPrice.Visible = true;
            }
            else
            {
                lblTotalPriceTaxIncTitle.Visible = false;
                lbltotalCount.Visible = false;
                lblTotalPrice.Visible = false;
            }
        }

        /// <summary>
        /// GRID上DropDownリストCloseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockGrid_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////ドロップダウンリスト選択で、確定させる。
            //int wkRowIndex = this.StockGrid.ActiveRow.Index;
            //
            //int selectValue1 = (int)e.Cell.Value; //変更後値
            //int selectValue = (int)e.Cell.OriginalValue;
            //
            //if (String.IsNullOrEmpty(e.Cell.Text))
            //{
            //    this.StockGrid.Rows[wkRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsCodeStatus].Value = selectValue1;
            //}
            //else
            //{
            //    if (e.Cell.Text == ctGoodsState_errorItem)
            //    {
            //        this.StockGrid.Rows[wkRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsCodeStatus].Value = ctGoodsState_errorValue;
            //    }
            //    else
            //    {
            //        this.StockGrid.Rows[wkRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsCodeStatus].Value = ctGoodsState_nomalValue;
            //    }
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            StockGrid_AfterCellUpdate(sender, e);
            MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// 次のセルへ移動
        /// </summary>
        /// <param name="activeCellCheck"></param>
        /// <returns></returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.StockGrid.ActiveCell != null))
            {
                if ((!this.StockGrid.ActiveCell.Column.Hidden) &&
                    (this.StockGrid.ActiveCell.Activation == Activation.AllowEdit) &&
                    (this.StockGrid.ActiveCell.Column.CellActivation == Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.StockGrid.PerformAction(UltraGridAction.NextCell);
                
                if (performActionResult)
                {
                    if ((this.StockGrid.ActiveCell.Activation == Activation.AllowEdit) &&
                        (this.StockGrid.ActiveCell.Column.CellActivation == Activation.AllowEdit))
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
                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public void SetDefaultFocus()
        {
            this.makedate_tDateEdit.Focus();

            // 2008.03.21 修正 >>>>>>>>>>>>>>>>>>>>
            this.RowDelete_ultraButton.Enabled = false;
            // 2008.03.21 修正 <<<<<<<<<<<<<<<<<<<<
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void Adjust_DataChanged(object sender, EventArgs e)
        {
            // ツールバーボタン有効無効設定処理
         //   this.SettingToolBarButtonEnabled();
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入力担当者ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim().ToString();
                this.uLabel_StockAgentName.Text = employee.Name.Trim().ToString();
            }
            _employee = employee;
        }

        private void tEdit_EmployeeCode_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {            
            SetEmployeeCode();
        }
        private void SetEmployeeCode()
        {
            string code = this.tEdit_EmployeeCode.Text.Trim();
            string name = "";
            string preCode = _employee != null ? _employee.EmployeeCode : "";

            if (!String.IsNullOrEmpty(code))
            {
                if (preCode != code)
                {
                    ArrayList empList = GetEmpList();
                    _employee = null;
                    foreach (EmployeeWork empWork in empList)
                    {
                        if (empWork.EmployeeCode.Trim() == code)
                        {
                            name = empWork.Name;
                            _employee = EmpWorkToEmp(empWork);
                            break;
                        }
                    }

                    if (name.Trim() == "")
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "従業員が存在しません。",
                            -1,
                            MessageBoxButtons.OK);
                        code = "";
                        this.tEdit_EmployeeCode.Focus();
                    }
                    this.tEdit_EmployeeCode.Text = code.Trim();
                    this.uLabel_StockAgentName.Text = name;
                    
                }
            }
            else
            {
                this.tEdit_EmployeeCode.Text = "";
                this.uLabel_StockAgentName.Text = "";
            }            
        }

        private Employee EmpWorkToEmp(EmployeeWork tgtEmpWork)
        {
            Employee employee = new Employee();
            employee.AuthorityLevel1 = tgtEmpWork.AuthorityLevel1;
            employee.AuthorityLevel2 = tgtEmpWork.AuthorityLevel2;
            employee.BelongSectionCode = tgtEmpWork.BelongSectionCode;
            employee.Birthday = tgtEmpWork.Birthday;
            employee.BusinessCode = tgtEmpWork.BusinessCode;
            employee.CompanyTelNo = tgtEmpWork.CompanyTelNo;
            employee.CreateDateTime = tgtEmpWork.CreateDateTime;
            employee.EmployeeCode = tgtEmpWork.EmployeeCode;
            employee.EnterCompanyDate = tgtEmpWork.EnterCompanyDate;
            employee.EnterpriseCode = tgtEmpWork.EnterpriseCode;
            employee.FileHeaderGuid = tgtEmpWork.FileHeaderGuid;
            employee.FrontMechaCode = tgtEmpWork.FrontMechaCode;
            employee.InOutsideCompanyCode = tgtEmpWork.InOutsideCompanyCode;
            employee.Kana = tgtEmpWork.Kana;
            employee.LogicalDeleteCode = tgtEmpWork.LogicalDeleteCode;
            employee.LoginId = tgtEmpWork.LoginId;
            employee.LoginPassword = tgtEmpWork.LoginPassword;
            employee.LvrRtCstBodyPaint = tgtEmpWork.LvrRtCstBodyPaint;
            employee.LvrRtCstBodyRepair = tgtEmpWork.LvrRtCstBodyRepair;
            employee.LvrRtCstCarInspect = tgtEmpWork.LvrRtCstCarInspect;
            employee.LvrRtCstGeneral = tgtEmpWork.LvrRtCstGeneral;
            employee.Name = tgtEmpWork.Name;
            employee.PortableTelNo = tgtEmpWork.PortableTelNo;
            employee.PostCode = tgtEmpWork.PostCode;
            employee.RetirementDate = tgtEmpWork.RetirementDate;
            employee.SexCode = tgtEmpWork.SexCode;
            employee.SexName = tgtEmpWork.SexName;
            employee.ShortName = tgtEmpWork.ShortName;
            employee.UpdAssemblyId1 = tgtEmpWork.UpdAssemblyId1;
            employee.UpdAssemblyId2 = tgtEmpWork.UpdAssemblyId2;
            employee.UpdateDateTime = tgtEmpWork.UpdateDateTime;
            employee.UpdEmployeeCode = tgtEmpWork.UpdEmployeeCode;
            employee.UserAdminFlag = tgtEmpWork.UserAdminFlag;
            return employee;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫仕入伝票照会画面起動処理
        /// </summary>
        public void ShowStockSlipGuide()
        {
            changeFocusFooter(false);

            DialogResult result = DialogResult.Cancel;

            PMZAI04001UA stockSlipGuide = new PMZAI04001UA();
            
            result = stockSlipGuide.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // 伝票番号表示
                this.tNedit_SupplierSlipNo.SetInt(stockSlipGuide.StockAdjRefSearchRetWork.StockAdjustSlipNo);

                // 伝票情報表示
                DispStockAdjustSlipInfo(stockSlipGuide.StockAdjRefSearchRetWork.StockAdjustSlipNo, true);//add 2011/12/13 陳建明 Redmine #26816
                //DispStockAdjustSlipInfo(stockSlipGuide.StockAdjRefSearchRetWork.StockAdjustSlipNo);//del 2011/12/13 陳建明 Redmine #26816
            }
        }

        /// <summary>
        /// 在庫調整伝票情報表示処理
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="flag">伝票番号で検索するかどうかを判断する用のフラグ</param>
        public int DispStockAdjustSlipInfo(int stockAdjustSlipNo, params bool[] flag)//add 2011/12/13 陳建明 Redmine #26816
        //public int DispStockAdjustSlipInfo(int stockAdjustSlipNo)//del 2011/12/13 陳建明 Redmine #26816
        {
            StockAdjust stockAdjust;
            StockSearchPara stockSearchPara = new StockSearchPara();
            List<Stock> stockList = new List<Stock>();
            List<StockAdjustDtl> stockAdjustDtlList;

            // 在庫調整データ、在庫調整明細データ取得
            int status = this._adjustStockAcs.ReadDBData(stockAdjustSlipNo, out stockAdjust, out stockAdjustDtlList);
            if (status == 0)
            {
                if (stockAdjust.LogicalDeleteCode != 0)
                {
                    this.tNedit_SupplierSlipNo.Focus();
                    return (-1);
                }

                StockAdjustDtl stockAdjustDtl = stockAdjustDtlList[0];

                // 在庫調整データグリッド反映
                this.PreviousRowIndex = -1;//add 2011/12/15 陳建明 Redmine #26816
                this._adjustStockAcs.StockAdjustDtlListToGrid(stockAdjust, stockAdjustDtlList, flag);//add 2011/12/13 陳建明 Redmine #26816
                //this._adjustStockAcs.StockAdjustDtlListToGrid(stockAdjust, stockAdjustDtlList);//del 2011/12/13 陳建明 Redmine #26816

                // 画面コントロールEnabled変更
                ChangeScreenEnabled(false);

                // ヘッダー部反映
                this.makedate_tDateEdit.SetDateTime(stockAdjust.AdjustDate);
                this.tEdit_SectionCode.DataText = stockAdjust.StockSectionCd.Trim().PadLeft(2, '0'); ;
                this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(stockAdjust.StockSectionCd);
                this.tEdit_WarehouseCode.DataText = stockAdjustDtl.WarehouseCode.Trim().PadLeft(4, '0');
                this.uLabel_WarehouseName.Text = this._adjustStockAcs.GetWarehouseName(stockAdjustDtl.WarehouseCode);
                this.tEdit_EmployeeCode.DataText = stockAdjust.StockAgentCode.Trim().PadLeft(4, '0');
                this.uLabel_StockAgentName.Text = this._adjustStockAcs.GetEmployeeName(stockAdjust.StockAgentCode);

                // フッター部反映
                this.edtNote1.DataText = stockAdjust.SlipNote.Trim();

                // 合計設定
                SetTotal(true);

                // フォーカス設定
                this.StockGrid.Rows[0].Cells[AdjustStockAcs.ctCOL_ListPriceFl].Activate();
                this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

                ChangeToolbarSetting(1);

                this._orderListResultFlg = false;
            }
            else
            {
                this.tNedit_SupplierSlipNo.Focus();
            }

            return (status);
        }

        /// <summary>
        /// 発注残照会画面起動前チェック
        /// </summary>
        /// <returns>ステータス</returns>
        private bool CheckBeforeShowOrderHisGuide()
        {
            string errMsg = "";

            try
            {
                if (this.makedate_tDateEdit.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "仕入日が入力されていません。";
                    this.makedate_tDateEdit.Focus();
                    return (false);
                }

                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    errMsg = "拠点コードが入力されていません。";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }

                string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                if (this._adjustStockAcs.GetSectionName(sectionCode) == "")
                {
                    errMsg = "拠点コードがマスタに登録されていません。";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }

                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                {
                    errMsg = "入力担当が入力されていません。。";
                    this.tEdit_EmployeeCode.Focus();
                    return (false);
                }

                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                if (this._adjustStockAcs.GetEmployeeName(employeeCode) == "")
                {
                    errMsg = "入力担当コードがマスタに登録されていません。";
                    this.tEdit_EmployeeCode.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      ctPGID,
                                      errMsg,
                                      0,
                                      MessageBoxButtons.OK);
                }
            }

            return (true);
        }

        /// <summary>
        /// 発注残照会画面起動処理
        /// </summary>
        public void ShowOrderHisGuide()
        {
            DialogResult dialogResult;

            // 発注残照会画面起動前チェック
            if (!CheckBeforeShowOrderHisGuide())
            {
                return;
            }

            bool confirmFlg = false;
            if (this.tNedit_SupplierSlipNo.GetInt() != 0)
            {
                confirmFlg = true;
            }
            else
            {
                for (int index = 0; index < this.StockGrid.Rows.Count; index++)
                {
                    // 品番
                    if (this.StockGrid.Rows[index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString() != "")
                    {
                        confirmFlg = true;
                        break;
                    }
                }
            }

            if (confirmFlg)
            {
                dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入力済みの明細情報はクリアされます。よろしいですか？",
                            0,
                            MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    //GRID初期化
                    _adjustStockAcs.DBDataClear();
                    AdjustStockAcs.RepaintProductStock();
                }
                else
                {
                    return;
                }
            }

            DCHAT04110UA orderHisGuide = new DCHAT04110UA();
            orderHisGuide.IsMultiSelect = false;
            orderHisGuide.IsCacheClear = true;
            List<OrderListResultWork> retOrderListResultWorkList = new List<OrderListResultWork>();
            List<OrderListResultWork> addOrderListResultWorkList = new List<OrderListResultWork>();
            List<int> settingStockRowNoList = new List<int>();
            orderHisGuide.IsMultiSelect = true;
            orderHisGuide.MaxSelectCount = 3000;
            orderHisGuide.IsMultiWarehouseSelect = false;
            dialogResult = orderHisGuide.ShowDialog(this, DCHAT04110UA.DisplayType.DisplayAndSelect);

            if (dialogResult == DialogResult.OK)
            {
                changeFocusFooter(false);

                retOrderListResultWorkList = orderHisGuide.orderListResultWorkList;

                if (retOrderListResultWorkList.Count > 0)
                {
                    // 残が０のデータを除くリストを作成する
                    foreach (OrderListResultWork orderListResultWork in retOrderListResultWorkList)
                    {
                        if (orderListResultWork.OrderRemainCnt != 0)
                        {
                            addOrderListResultWorkList.Add(orderListResultWork);
                        }
                    }
                    if (retOrderListResultWorkList.Count != addOrderListResultWorkList.Count)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注残が０のデータは展開されません。",
                            0,
                            MessageBoxButtons.OK);
                    }

                    // 発注残照会リモート抽出結果グリッド反映
                    this._adjustStockAcs.OrderListResultWorkToGrid(addOrderListResultWorkList);

                    if ((addOrderListResultWorkList == null) || (addOrderListResultWorkList.Count == 0))
                    {

                    }
                    else
                    {
                        // 画面コントロールEnabled変更
                        ChangeScreenEnabled(false);

                        OrderListResultWork retWork = addOrderListResultWorkList[0];

                        // ヘッダー部反映
                        //this.tEdit_SectionCode.DataText = retWork.SectionCode.Trim().PadLeft(2, '0');
                        //this.uLabel_SectionName.Text = this._adjustStockAcs.GetSectionName(retWork.SectionCode);
                        this.tEdit_WarehouseCode.DataText = retWork.WarehouseCode.Trim().PadLeft(4, '0');
                        this.uLabel_WarehouseName.Text = this._adjustStockAcs.GetWarehouseName(retWork.WarehouseCode);
                        //this.tEdit_EmployeeCode.DataText = retWork.StockInputCode.Trim().PadLeft(4, '0');
                        //this.uLabel_StockAgentName.Text = this._adjustStockAcs.GetEmployeeName(retWork.StockInputCode);

                        // 合計設定
                        SetTotal(false);

                        // フォーカス設定
                        this.StockGrid.Rows[0].Cells[AdjustStockAcs.ctCOL_ListPriceFl].Activate();
                        this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);

                        ChangeToolbarSetting(0);

                        this._orderListResultFlg = true;
                    }
                }
            }
        }

        private bool CheckChangeSection(string sectionCode)
        {
            if (this._searchFlg == false)
            {
                return (false);
            }

            if (sectionCode.Trim() == this._prevSectionCode.Trim())
            {
                return (false);
            }

            DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             ctPGID,
                                             "拠点を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
　                                           "拠点を変更しますか？",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);
            if (res == DialogResult.No)
            {
                return (false);
            }
            // --- ADD 2009/12/16 ---------->>>>>
            // 仕入全体設定マスタデータの再取得
            else
            {
                GetListPriceInpDiv();

                GetUnitPriceInpDiv();
            }
            // --- ADD 2009/12/16 -----------<<<<<
            return (true);
        }

        private bool CheckChangeWarehouse(string warehouseCode)
        {
            if (this._searchFlg == false)
            {
                return (false);
            }

            if (warehouseCode.Trim() == this._prevWarehouseCode.Trim())
            {
                return (false);
            }

            DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                             ctPGID,
                                             "倉庫を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                                             "倉庫を変更しますか？",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);
            if (res == DialogResult.No)
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// Button_Click イベント(拠点ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SectionGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    if (this._prevSectionCode.Trim() != secInfoSet.SectionCode.Trim())
                    {
                        // 変更チェック
                        if (this._searchFlg)
                        {
                            if (CheckChangeSection(secInfoSet.SectionCode) == false)
                            {
                                // 変更せず
                                return;
                            }
                        }

                        this._prevSectionCode = secInfoSet.SectionCode.Trim();

                        this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                        this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                        // グリッド初期化
                        _adjustStockAcs.DBDataClear();

                        AdjustStockAcs.RepaintProductStock();

                        //金額・合計初期化
                        edtNote1.Text = "";
                        lbltotalCount.Text = "0.00";
                        lblTotalPrice.Text = "0";

                        this._orderListResultFlg = false;
                        this._searchFlg = false;

                        // --- ADD 2009/12/16 ---------->>>>>
                        // 定価入力区分取得処理
                        GetListPriceInpDiv();
                        // 単価入力区分取得処理
                        GetUnitPriceInpDiv();
                        // --- ADD 2009/12/16 ----------<<<<<
                    }

                    // フォーカス設定
                    this.tEdit_WarehouseCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(倉庫ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void WarehouseGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouse;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    if (this._prevWarehouseCode.Trim() != warehouse.WarehouseCode.Trim())
                    {
                        // 変更チェック
                        if (this._searchFlg)
                        {
                            if (CheckChangeWarehouse(warehouse.WarehouseCode.Trim()) == false)
                            {
                                // 変更せず
                                return;
                            }
                        }

                        this._prevWarehouseCode = warehouse.WarehouseCode.Trim();

                        this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                        this.uLabel_WarehouseName.Text = warehouse.WarehouseName.Trim();

                        // グリッド初期化
                        _adjustStockAcs.DBDataClear();

                        AdjustStockAcs.RepaintProductStock();

                        //金額・合計初期化
                        edtNote1.Text = "";
                        lbltotalCount.Text = "0.00";
                        lblTotalPrice.Text = "0";

                        this._orderListResultFlg = false;
                        this._searchFlg = false;
                    }

                    // フォーカス設定
                    this.tEdit_EmployeeCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(従業員ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 従業員ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                Employee employee;

                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, sectionCode, out employee);
                if (status == 0)
                {
                    if (this._prevEmployeeCode.Trim() != employee.EmployeeCode.Trim())
                    {
                        this._prevEmployeeCode = employee.EmployeeCode.Trim();

                        this.tEdit_EmployeeCode.Text = employee.EmployeeCode.Trim();
                        this.uLabel_StockAgentName.Text = employee.Name.Trim();

                        this._employee = employee;
                    }

                    // フォーカス設定
                    this.GoodsSearch_ultraButton.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(伝票ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 伝票ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SalesSlipGuide_uButton_Click(object sender, EventArgs e)
        {
            // 在庫仕入伝票照会画面起動
            ShowStockSlipGuide();
        }

        /// <summary>
        /// Button_Click イベント(備考ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 備考ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SlipNoteGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 備考区分=107:移動伝票備考
                NoteGuidBd noteGuidBd;
                int status = this._noteGuideAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, 107);
                if (status == 0)
                {
                    this.edtNote1.Text = noteGuidBd.NoteGuideName;

                    // フォーカス設定
                    this.makedate_tDateEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void StockGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.StockGrid.DisplayLayout.Bands[0].Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.StockGrid.DisplayLayout.Bands[0].Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.StockGrid.DisplayLayout.Bands[0].Override.HeaderAppearance.ForeColor = Color.White;
            this.StockGrid.DisplayLayout.Bands[0].Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.StockGrid.DisplayLayout.Bands[0].Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.StockGrid.DisplayLayout.Bands[0].Override.RowSelectorAppearance.ForeColor = Color.White;

            // 品番
            int maxLength = this.uiSetControl1.GetSettingColumnCount(AdjustStockAcs.ctCOL_GoodsNo);
            if (maxLength > 0)
            {
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].MaxLength = maxLength;
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.TextHAlign = this.uiSetControl1.GetSettingHAlign(AdjustStockAcs.ctCOL_GoodsNo);
            }

            // 明細備考
            this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_DtlNote].MaxLength = 40;
        }

        /// <summary>
        /// 画面コントロールEnabled変更処理
        /// </summary>
        private void ChangeScreenEnabled(bool param)
        {
            this.makedate_tDateEdit.Enabled = param;
            this.tNedit_SupplierSlipNo.Enabled = param;
            this.SalesSlipGuide_uButton.Enabled = param;
            this.tEdit_SectionCode.Enabled = param;
            this.SectionGuide_uButton.Enabled = param;
            this.tEdit_WarehouseCode.Enabled = param;
            this.WarehouseGuide_uButton.Enabled = param;
            this.tEdit_EmployeeCode.Enabled = param;
            this.uButton_EmployeeGuide.Enabled = param;
            this.GoodsSearch_ultraButton.Enabled = param;

            if (param == true)
            {
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].CellActivation = Activation.AllowEdit;
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.BackColor = Color.Empty;
            }
            else
            {
                this.RowDelete_ultraButton.Enabled = param;
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].CellActivation = Activation.Disabled;
                this.StockGrid.DisplayLayout.Bands[0].Columns[AdjustStockAcs.ctCOL_GoodsNo].CellAppearance.BackColor = Color.Gainsboro;
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void StockGrid_Leave(object sender, EventArgs e)
        {
            this.StockGrid.ActiveCell = null;
        }

        private void StockGrid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.Key == AdjustStockAcs.ctCOL_DtlNote)
            {
                this.StockGrid.ImeMode = ImeMode.Hiragana;
            }
            else
            {
                this.StockGrid.ImeMode = ImeMode.NoControl;
            }

            // --- ADD 2009/12/16 ---------->>>>>
            _activeRowIndex = e.Cell.Row.Index;
            _activeColumnIndex = e.Cell.Column.Index;
            // --- ADD 2009/12/16 -----------<<<<<

        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/12/16 ---------->>>>>
        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドのフォーカスアウト操作。</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2008/12/16</br>
        /// </remarks>
        private void StockGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.StockGrid.ActiveCell;
            // ---- UPD 2010/05/20 ----------->>>>>
            if (cell != null)
            {
                _preRowIndex = cell.Row.Index;
                _preColumnIndex = cell.Column.Index;
            }
            // ---- UPD 2010/05/20 -----------<<<<<
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブ操作。</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2008/12/16</br>
        /// </remarks>
        private void StockGrid_AfterCellActivate(object sender, EventArgs e)
        {
            if (_preRowIndex < 0 || _preRowIndex > 999)
            {
                _preRowIndex = 0;
            }
            int endRowIndex = 0;
            // 新規モード以外の場合、フォーカスを設定しません
            if (true == this.tNedit_SupplierSlipNo.Enabled)
            {
                for (int i = AdjustStockAcs.maxRowCnt - 1; i >= 0; i--)
                {
                    // 最後入力行を取得する
                    if (!string.IsNullOrEmpty(this.StockGrid.Rows[i].Cells[1].Value.ToString()))
                    {
                        endRowIndex = i;
                        break;
                    }
                }
                // 移動元先の品番を取得する
                string _activeGoodsNo = this.StockGrid.Rows[_activeRowIndex].Cells[1].Value.ToString();
                // 一番行の品番を取得する
                string _zeroGoodsNo = this.StockGrid.Rows[0].Cells[1].Value.ToString();
                if ((0 == endRowIndex) && string.IsNullOrEmpty(_zeroGoodsNo))
                {
                    this.StockGrid.BeforeCellActivate -= this.StockGrid_BeforeCellActivate;
                    this.StockGrid.Rows[0].Cells[1].Activate();
                    this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                    this.StockGrid.BeforeCellActivate += this.StockGrid_BeforeCellActivate;
                }
                else
                {
                    // 移動先行＞最終入力行の次行、移動先セルが最終入力行の次行品番以外の項目、最終入力行が一番行且つ品番が未入力の場合
                    if ((_activeRowIndex > endRowIndex + 1) || ((_activeRowIndex == endRowIndex + 1) && (_activeColumnIndex > 1)))
                    {
                        this.StockGrid.BeforeCellActivate -= this.StockGrid_BeforeCellActivate;
                        this.StockGrid.Rows[_preRowIndex].Cells[_preColumnIndex].Activate();
                        this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                        this.StockGrid.BeforeCellActivate += this.StockGrid_BeforeCellActivate;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(_activeGoodsNo) && (_activeColumnIndex > 1))
                        {
                            this.StockGrid.BeforeCellActivate -= this.StockGrid_BeforeCellActivate;
                            this.StockGrid.Rows[_preRowIndex].Cells[_preColumnIndex].Activate();
                            this.StockGrid.PerformAction(UltraGridAction.EnterEditMode);
                            this.StockGrid.BeforeCellActivate += this.StockGrid_BeforeCellActivate;
                        }
                    }
                }
            }
        }
        // --- ADD 2009/12/16 -----------<<<<<

        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
        #region 在庫登録

        #region 在庫登録用商品マスタアクセス

        /// <summary>在庫登録用商品マスタアクセス</summary>
        private GoodsAcs _goodsAccesserForInputingStock;
        /// <summary>在庫登録用商品マスタアクセスを取得します。</summary>
        /// <remarks>初期化処理はMAKHN04110U.MAKHN04110U()およびMAKHN04110U.InputGoodsEntry()を参考に実装</remarks>
        /// <br>Update Note: 2013/02/21 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        private GoodsAcs GoodsAccesserForInputingStock
        {
            get
            {
                if (_goodsAccesserForInputingStock == null)
                {
                    _goodsAccesserForInputingStock = new GoodsAcs();
                    {
                        _goodsAccesserForInputingStock.IsLocalDBRead = false;
                        string msg = string.Empty;
                        int status = _goodsAccesserForInputingStock.SearchInitialForMst(
                            _enterpriseCode,
                            this.tEdit_SectionCode.DataText.Trim(),
                            out msg
                        );
                    }
                    _goodsAccesserForInputingStock.SearchInitial();// ADD zhangy3 2013/02/21 For Redmine#33845
                }                
                return _goodsAccesserForInputingStock;
            }
        }

        #endregion // 在庫登録用商品マスタアクセス

        /// <summary>
        /// 在庫登録を行います。
        /// </summary>
        /// <remarks>this.SearchGoods(UltraGridCell)をアレンジ</remarks>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        /// <br>Update Note: 2013/02/23 zhuhh</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        /// <br>Update Note: 2013/05/02 王君</br>
        /// <br>管理番号   : 10901273-00　2013/06/18配信分</br>　
        /// <br>           : Redmine#35434の対応</br>
        public void InputStock()
        {
            #region 品番で再検索

            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText.Trim()))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "先に倉庫コードを入力してください。",
                    -1,
                    MessageBoxButtons.OK
                );
                this._warehouseCodeFocusFlg = true;
                return;
            }
            this._warehouseCodeFocusFlg = false;

            // 倉庫コード
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

            // 拠点コード
            string sectionCode = this.tEdit_SectionCode.DataText.Trim();

            // 品番
            UltraGridCell goodsNoCell = this.StockGrid.ActiveRow.Cells[AdjustStockAcs.ctCOL_GoodsNo];
            string goodsCode = string.Empty;
            if (goodsNoCell == null || string.IsNullOrEmpty(goodsNoCell.Value.ToString()))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "品番を入力してください。",
                    -1,
                    MessageBoxButtons.OK
                );
                if (goodsNoCell != null) goodsNoCell.Activate();
                return;
            }
            goodsCode = goodsNoCell.Value.ToString();

            // --- ADD m.suzuki 2010/01/14 ---------->>>>>
            int goodsMakerCd = this._adjustStockAcs.StringObjToInt( this.StockGrid.ActiveRow.Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value );
            // --- ADD m.suzuki 2010/01/14 ----------<<<<<

            // 商品連結データ検索条件
            GoodsCndtn searchingGoodsCndtn;
            this._adjustStockAcs.SetGoodsCndtn(
                out searchingGoodsCndtn,
                LoginInfoAcquisition.EnterpriseCode,
                // --- UPD m.suzuki 2010/01/14 ---------->>>>>
                //0,
                goodsMakerCd,
                // --- UPD m.suzuki 2010/01/14 ----------<<<<<
                goodsCode,
                sectionCode
            );
            searchingGoodsCndtn.PriceApplyDate = this.makedate_tDateEdit.GetDateTime();

            // 商品連結データ取得
            List<GoodsUnitData> searchedGoodsUnitDataList = null;   // 2パラ目
            string msg = string.Empty;                              // 3パラ目
            // 2010/07/14 >>>
            //int status = this._adjustStockAcs.GetGoodsUnitDataList(
            //    searchingGoodsCndtn,
            //    out searchedGoodsUnitDataList,
            //    out msg
            //);
            int status = this._adjustStockAcs.GetGoodsUnitDataList(
                searchingGoodsCndtn,
                out searchedGoodsUnitDataList,
                out msg,
                ConstantManagement.LogicalMode.GetData01
            );

            List<Stock> delList = new List<Stock>();
            int i = 0;
            for (i = 0; i < searchedGoodsUnitDataList.Count; i++)
            {
                if (searchedGoodsUnitDataList[i].StockList.Count > 1)
                {
                    if (searchedGoodsUnitDataList[i].GoodsMakerCd == searchingGoodsCndtn.GoodsMakerCd)
                    {
                        for (int j = 0; j < searchedGoodsUnitDataList[i].StockList.Count; j++)
                        {
                            if (searchedGoodsUnitDataList[i].StockList[j].WarehouseCode.Trim() != this.tEdit_WarehouseCode.Text.Trim())
                            {
                                delList.Add(searchedGoodsUnitDataList[i].StockList[j]);
                            }
                        }
                        break;
                    }
                }
                else
                {
                    for (int j = 0; j < searchedGoodsUnitDataList[i].StockList.Count; j++)
                    {
                        if (searchedGoodsUnitDataList[i].StockList[j].WarehouseCode.Trim() != this.tEdit_WarehouseCode.Text.Trim())
                        {
                            delList.Add(searchedGoodsUnitDataList[i].StockList[j]);
                        }
                    }
                    break;
                }
            }
            foreach (Stock delnum in delList)
            {
                searchedGoodsUnitDataList[i].StockList.Remove(delnum);
            }
            // 2010/07/14 <<<

            #endregion // 品番で再検索

            #region 商品在庫マスタの入力フォームを呼出し

            if (searchedGoodsUnitDataList != null && searchedGoodsUnitDataList.Count > 0)
            {
                // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
                if (this._allDefSet != null)
                {
                    if (this._allDefSet.GoodsStockMSTBootDiv == 0)
                    {
                        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
                // 更新モードで商品在庫マスタの入力フォームを呼出し
                MAKHN09280UA goodsInputForm = new MAKHN09280UA(GoodsAccesserForInputingStock);
                {
                    // 商品入力画面を起動する
                    GoodsUnitData targetGoodsUnitData = searchedGoodsUnitDataList[i];
                    DialogResult result = goodsInputForm.ShowDialog(
                        this,
                        ref targetGoodsUnitData,
                        new MAKHN09280UA.StockTabItem(
                            this.tEdit_WarehouseCode.Text,
                            this.uLabel_WarehouseName.Text,
                            this.tEdit_SectionCode.Text,
                            this.uLabel_SectionName.Text
                        )
                    );
                }
                    // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
                    }
                    else
                    {
                        // 更新モードで商品在庫マスタの入力フォームを呼出し
                        PMKHN09380UA goodsInputForm = new PMKHN09380UA(GoodsAccesserForInputingStock);
                        {
                            // 商品入力画面を起動する
                            GoodsUnitData targetGoodsUnitData = searchedGoodsUnitDataList[i];
                            DialogResult result = goodsInputForm.ShowDialog(
                                this,
                                ref targetGoodsUnitData,
                                new PMKHN09380UA.StockTabItem(
                                    this.tEdit_WarehouseCode.Text,
                                    this.uLabel_WarehouseName.Text,
                                    this.tEdit_SectionCode.Text,
                                    this.uLabel_SectionName.Text
                                )
                            );
                        }
                    }
                }
                else
                {
                    return;
                }
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
            }
            else
            {
                /* --- Del Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
                System.Diagnostics.Debug.Assert(false, "在庫登録での商品在庫マスタの新規モード呼出しは未サポートです。");
                return; // TODO:新規モードで商品在庫マスタの入力フォームを呼出し ※仕様的には、このケースはNG
                  --- Del End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<*/
                // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
                List<string> listPriorWarehouseStr = new List<string>();
                listPriorWarehouseStr.Add(warehouseCode);
                DateTime priceApplyDate = this.makedate_tDateEdit.GetDateTime();
                List<GoodsUnitData> goodsUnitDataList;
                //if (GetSupportDataGoodsUnitDataList(LoginInfoAcquisition.EnterpriseCode, 0, goodsCode, sectionCode, priceApplyDate, listPriorWarehouseStr, out goodsUnitDataList)) // DEL zhuhh 2013/02/23 For Redmine#33845のNo.138
                if (GetSupportDataGoodsUnitDataList(LoginInfoAcquisition.EnterpriseCode, goodsMakerCd, goodsCode, sectionCode, priceApplyDate, listPriorWarehouseStr, out goodsUnitDataList)) // ADD zhuhh 2013/02/23 For Redmine#33845のNo.138
                {
                    // ----- ADD 王君 2013/05/02 Redmine335434 ----->>>>>
                    if (this._allDefSet != null)
                    {
                        if (this._allDefSet.GoodsStockMSTBootDiv == 0)
                        {
                            // ----- ADD 王君 2013/05/02 Redmine335434 -----<<<<<
                    // 更新モードで商品在庫マスタの入力フォームを呼出し
                    MAKHN09280UA goodsInputForm = new MAKHN09280UA(GoodsAccesserForInputingStock);
                    {
                        // 商品入力画面を起動する
                        GoodsUnitData targetGoodsUnitData = goodsUnitDataList[0];
                        targetGoodsUnitData.CreateDateTime = DateTime.Now;
                        DialogResult result = goodsInputForm.ShowDialog(
                            this,
                            ref targetGoodsUnitData,
                            new MAKHN09280UA.StockTabItem(
                                this.tEdit_WarehouseCode.Text,
                                this.uLabel_WarehouseName.Text,
                                this.tEdit_SectionCode.Text,
                                this.uLabel_SectionName.Text
                            )
                        );
                    }
                            // ----- ADD 王君 2013/05/02 Redmine335434 ----->>>>>
                        }
                        else
                        {
                            PMKHN09380UA goodsInputForm = new PMKHN09380UA(GoodsAccesserForInputingStock);
                            {
                                // 商品入力画面を起動する
                                GoodsUnitData targetGoodsUnitData = goodsUnitDataList[0];
                                targetGoodsUnitData.CreateDateTime = DateTime.Now;
                                DialogResult result = goodsInputForm.ShowDialog(
                                    this,
                                    ref targetGoodsUnitData,
                                    new PMKHN09380UA.StockTabItem(
                                        this.tEdit_WarehouseCode.Text,
                                        this.uLabel_WarehouseName.Text,
                                        this.tEdit_SectionCode.Text,
                                        this.uLabel_SectionName.Text
                                    )
                                );
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                    // ----- ADD 王君 2013/05/02 Redmine335434 -----<<<<<

                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "在庫登録での商品在庫マスタの新規モード呼出しは未サポートです。");
                    return; // TODO:新規モードで商品在庫マスタの入力フォームを呼出し ※仕様的には、このケースはNG
                }
                // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
            }

            #endregion // 商品在庫マスタの入力フォームを呼出し

            #region フォームへ展開

            status = this._adjustStockAcs.GetGoodsUnitDataList(
                searchingGoodsCndtn,
                out searchedGoodsUnitDataList,
                out msg
            );
            if (searchedGoodsUnitDataList.Count > 0)
            {   
                this._adjustStockAcs.IsDataChanged = true;

                // グリッドに反映
                status = this._adjustStockAcs.GoodsUnitDataToGrid(
                    searchedGoodsUnitDataList[0],
                    warehouseCode,
                    sectionCode,
                    goodsNoCell.Row.Index
                );
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    #region エラーメッセージ
                    //TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_INFO,
                    //    this.Name,
                    //    "選択した商品は在庫登録されていません。",
                    //    -1,
                    //    MessageBoxButtons.OK
                    //);
                    #endregion
                    // 商品は存在するが、在庫がない場合はそのまま
                    if (!status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN))
                    {
                        this._adjustStockAcs.ClrRowData(goodsNoCell.Row.Index);
                    }

                    ExistsStockWithEvents = false;

                    return;
                }

                // 仕入後数設定
                this._adjustStockAcs.SetAfSalesOrderUnit(searchedGoodsUnitDataList[0].GoodsMakerCd, searchedGoodsUnitDataList[0].GoodsNo);

                // 標準価格へフォーカス移動
                this.StockGrid.Rows[goodsNoCell.Row.Index].Cells[AdjustStockAcs.ctCOL_GoodsNo].Activate();
                this.StockGrid.PerformAction(UltraGridAction.NextCellByTab);

                ExistsStockWithEvents = true;
            }

            // 最終行の場合は、１行追加する
            if (goodsNoCell.Row.Index == AdjustStockAcs.ProductStockDataTable.Rows.Count - 1)
            {
                AdjustStockAcs.IncrementProductStock();
            }

            // 合計数・合計金額設定
            SetTotal(false);

            #endregion // フォームへ展開
        }

        /// <summary>前回の明細グリッドの行インデックス</summary>
        private int _previousRowIndex = -1;
        /// <summary>前回の明細グリッドの行インデックスを取得または設定します。</summary>
        private int PreviousRowIndex
        {
            get { return _previousRowIndex; }
            set { _previousRowIndex = value; }
        }

        /// <summary>
        /// 明細グリッドのAfterRowActivateイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 在庫登録ボタンを有効または無効に設定します。
        /// </remarks>
        /// 
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void StockGrid_AfterRowActivate(object sender, EventArgs e)
        {
            #region GuardPhrase

            if (this.StockGrid.ActiveRow == null) return;

            #endregion // GuardPhrase

            // 在庫登録ボタンの有効化
            // 入力商品の在庫情報を調査し、非在庫品の場合、在庫登録ボタンを有効にする（それ以外は無効にする）
            // ただし、毎回、在庫情報を調査するとレスポンスが著しく低下する可能性が高いので、
            // 選択行に変化がなければ処理を行わない
            int currentRowIndex = this.StockGrid.ActiveRow.Index;
            //if (currentRowIndex.Equals(PreviousRowIndex)) return;

            string goodsNo = this.StockGrid.ActiveRow.Cells[AdjustStockAcs.ctCOL_GoodsNo].Value == DBNull.Value ? string.Empty : (string)this.StockGrid.ActiveRow.Cells[AdjustStockAcs.ctCOL_GoodsNo].Value;
            if (string.IsNullOrEmpty(goodsNo.Trim()))
            {
                EnabledToInputStock(this, new EnabledToInputStockEventArgs(false));
            }
            else
            {
                // --- UPD m.suzuki 2010/01/14 ---------->>>>>
                //EnabledToInputStock(this, new EnabledToInputStockEventArgs(CanInputStock(goodsNo)));
                int goodsMakerCd = this._adjustStockAcs.StringObjToInt( this.StockGrid.ActiveRow.Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value );
                //EnabledToInputStock(this, new EnabledToInputStockEventArgs(CanInputStock(goodsNo, goodsMakerCd)));    // DEL 2011/12/5 lxl Redmine#8072
                EnabledToInputStock(this, new EnabledToInputStockEventArgs(CanInputStockTemp(goodsNo, goodsMakerCd)));  // ADD 2011/12/5 lxl Redmine#8072
                // --- UPD m.suzuki 2010/01/14 ----------<<<<<
            }

            // --- ADD 2011/07/18 ----------->>>>>
            if (this._allDefSet.DtlCalcStckCntDsp == 1 && !currentRowIndex.Equals(PreviousRowIndex))
            {
                if (PreviousRowIndex >= 0)
                {
                    int goodsMakerCd = 0;
                    int.TryParse(this.StockGrid.Rows[PreviousRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsMakerCd].Value.ToString(), out goodsMakerCd);
                    // 仕入後数設定
                    this._adjustStockAcs.SetAfSalesOrderUnit(goodsMakerCd, this.StockGrid.Rows[PreviousRowIndex].Cells[AdjustStockAcs.ctCOL_GoodsNo].Value.ToString());
                }
            }
            // --- ADD 2011/07/18 -----------<<<<<
            PreviousRowIndex = currentRowIndex;

        }

        /// <summary>
        /// 在庫登録が可能か判断します。
        /// </summary>
        /// <remarks>this.SearchGoods(UltraGridCell)をアレンジ</remarks>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>
        /// <c>true</c> :可能です。<br/>
        /// <c>false</c>:不可です。
        /// </returns>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        // --- UPD m.suzuki 2010/01/14 ---------->>>>>
        //private bool CanInputStock(string goodsNo)
        private bool CanInputStock( string goodsNo, int goodsMakerCd )
        // --- UPD m.suzuki 2010/01/14 ----------<<<<<
        {
            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText.Trim())) return false;

            // 倉庫コード
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

            // 拠点コード
            string sectionCode = this.tEdit_SectionCode.DataText.Trim();

            // 品番
            string goodsCode = goodsNo.Trim();

            // 商品連結データ検索条件設定
            GoodsCndtn searchingCondition = null;
            this._adjustStockAcs.SetGoodsCndtn(
                out searchingCondition,
                LoginInfoAcquisition.EnterpriseCode,
                // --- UPD m.suzuki 2010/01/14 ---------->>>>>
                //0,
                goodsMakerCd,
                // --- UPD m.suzuki 2010/01/14 ----------<<<<<
                goodsCode,
                sectionCode
            );

            searchingCondition.PriceApplyDate = this.makedate_tDateEdit.GetDateTime();

            // 商品連結データ取得
            List<GoodsUnitData> searchedGoodsUnitDataList = null;
            string msg = string.Empty;
            int status = this._adjustStockAcs.GetGoodsUnitDataList(
                searchingCondition,
                out searchedGoodsUnitDataList,
                out msg
            );
            // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
            if (searchedGoodsUnitDataList == null || searchedGoodsUnitDataList.Count == 0)
            {
                List<string> listPriorWarehouseStr = new List<string>();
                listPriorWarehouseStr.Add(warehouseCode);
                DateTime priceApplyDate = this.makedate_tDateEdit.GetDateTime();
                List<GoodsUnitData> goodsUnitDataList;
                return GetSupportDataGoodsUnitDataList(LoginInfoAcquisition.EnterpriseCode, 0, goodsCode, sectionCode, priceApplyDate, listPriorWarehouseStr, out goodsUnitDataList);
            }
            // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
            // 商品は存在するが、在庫がない場合、在庫登録可能
            if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN))
            {
                return true;
            }
            else if (searchedGoodsUnitDataList[0].StockList != null && searchedGoodsUnitDataList[0].StockList.Count > 0)
            {
                //return !searchedGoodsUnitDataList[0].StockList.Exists(delegate(Stock item)
                //{
                //    return item.WarehouseCode.Trim().Equals(warehouseCode);
                //});
                foreach (Stock stock in searchedGoodsUnitDataList[0].StockList)
                {
                    // 2010/07/14 >>>
                    //if (stock.WarehouseCode.Trim().Equals(warehouseCode) && stock.ShipmentPosCnt > 0)
                    if (stock.WarehouseCode.Trim().Equals(warehouseCode))
                    // 2010/07/14 <<<
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
        /// <summary>
        /// 提供品番を取得する
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="markercode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="priceApplyDate">データ</param>
        /// <param name="listPriorWarehouseStr">倉庫リスト</param>
        /// <param name="goodsUnitDataList">商品リスト</param>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : 提供品番を取得する。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2013/01/04</br>
        /// <br>Update Note: 2013/02/27 zhujc</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#34858 在庫品仕入入力</br>
        /// </remarks>
        private bool GetSupportDataGoodsUnitDataList(string enterprisecode, int markercode, string goodsCode, string sectionCode, DateTime priceApplyDate, List<string> listPriorWarehouseStr, out List<GoodsUnitData> goodsUnitDataList)
        {
            int status;
            string msg;
            goodsUnitDataList = null;
            // 商品連結データ検索条件設定
            GoodsCndtn goodsCndtn;
            this._adjustStockAcs.SetGoodsCndtn(out goodsCndtn, LoginInfoAcquisition.EnterpriseCode, markercode, goodsCode, sectionCode);
            goodsCndtn.ListPriorWarehouse = listPriorWarehouseStr;
            goodsCndtn.PriceApplyDate = priceApplyDate;
            //status = this.GoodsAccesserForInputingStock.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg); //DEL zhujc on 2013/02/27 for Redmine#34858
            status = this.GoodsAccesserForInputingStock.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg, true); //ADD zhujc on 2013/02/27 for Redmine#34858
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                    return false;
                if (goodsUnitDataList[0].OfferKubun == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
        #endregion // 在庫登録

        //ADD 2011/12/5 lxl Redmine#8072----------->>>>>>>>>>
        /// <summary>
        /// 在庫登録が可能か判断します。
        /// </summary>
        /// <remarks>this.SearchGoods(UltraGridCell)をアレンジ</remarks>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>
        /// <c>true</c> :可能です。<br/>
        /// <c>false</c>:不可です。
        /// </returns>
        /// <br>Update Note: 2013/01/04 zhangy3</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        /// <br>Update Note: 2013/02/23 zhuhh</br>
        /// <br>管理番号   : 10806793-00　2013/03/13配信分</br>　
        /// <br>           : Redmine#33845 在庫品仕入入力</br>
        private bool CanInputStockTemp(string goodsNo, int goodsMakerCd)
        {
            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText.Trim())) return false;

            // 倉庫コード
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();

            // 拠点コード
            string sectionCode = this.tEdit_SectionCode.DataText.Trim();

            // 品番
            string goodsCode = goodsNo.Trim();

            // 商品連結データ検索条件設定
            GoodsCndtn searchingCondition = null;
            this._adjustStockAcs.SetGoodsCndtn(
                out searchingCondition,
                LoginInfoAcquisition.EnterpriseCode,
                goodsMakerCd,
                goodsCode,
                sectionCode
            );

            searchingCondition.PriceApplyDate = this.makedate_tDateEdit.GetDateTime();

            // 商品連結データ取得
            List<GoodsUnitData> searchedGoodsUnitDataList = null;
            string msg = string.Empty;
            int status = this._adjustStockAcs.GetGoodsUnitDataList(
                searchingCondition,
                out searchedGoodsUnitDataList,
                out msg,
                0
            );
            // --- Add Start zhangy3 2013/01/04 For Redmine#33845 ----->>>>>
            if (searchedGoodsUnitDataList == null || searchedGoodsUnitDataList.Count == 0)
            {
                List<string> listPriorWarehouseStr = new List<string>();
                listPriorWarehouseStr.Add(warehouseCode);
                DateTime priceApplyDate = this.makedate_tDateEdit.GetDateTime();
                List<GoodsUnitData> goodsUnitDataList;
                //return GetSupportDataGoodsUnitDataList(LoginInfoAcquisition.EnterpriseCode, 0, goodsCode, sectionCode, priceApplyDate, listPriorWarehouseStr, out goodsUnitDataList); // DEL zhuhh 2013/02/23 For Redmine#33845のNo.138
                return GetSupportDataGoodsUnitDataList(LoginInfoAcquisition.EnterpriseCode, goodsMakerCd, goodsCode, sectionCode, priceApplyDate, listPriorWarehouseStr, out goodsUnitDataList); // ADD zhuhh 2013/02/23 For Redmine#33845のNo.138
            }
            // --- Add End   zhangy3 2013/01/04 For Redmine#33845 -----<<<<<
            // 商品は存在するが、在庫がない場合、在庫登録可能
            if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN))
            {
                return true;
            }
            //else if (searchedGoodsUnitDataList[0].StockList != null && searchedGoodsUnitDataList[0].StockList.Count > 0)      // Del zhangy3 2013/01/04 For Redmine#33845
            else if (searchedGoodsUnitDataList.Count > 0 && searchedGoodsUnitDataList[0].StockList != null && searchedGoodsUnitDataList[0].StockList.Count > 0) // Add zhangy3 2013/01/04 For Redmine#33845
            {
                foreach (Stock stock in searchedGoodsUnitDataList[0].StockList)
                {
                    if (stock.WarehouseCode.Trim().Equals(warehouseCode))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        //ADD 2011/12/5 lxl Redmine#8072-----------<<<<<<<<<<


        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

        // ADD 2010.05.18 zhangsf FOR Redmine #7784 *-------------------->>>
        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : セルの値が更新後に発生します。</br>
        /// <br>Programmer : zhangsf</br>
        /// <br>Date       : 2010/05/20</br>
        /// </remarks>
        private void StockGrid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            /*---- DEL 2010/05/20 -------------------------------------
            // 仕入数
            if (this.StockGrid.ActiveCell.Column.Key == AdjustStockAcs.ctCOL_SalesOrderUnit)
            {
                // 仕入数
                double salesOrderUnit = double.Parse(this.StockGrid.ActiveCell.Text);

                if (salesOrderUnit < 0)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "マイナス値の入力はできません。",
                    0,
                    MessageBoxButtons.OK);

                    e.Cancel = true;
                }
            }
            ---- DEL 2010/05/20 ------------------------------------- */
        }
        // ADD 2010.05.18 zhangsf FOR Redmine #7784 <<<--------------------*
    }
}
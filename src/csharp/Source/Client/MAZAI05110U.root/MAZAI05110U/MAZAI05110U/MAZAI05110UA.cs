//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸準備処理
// プログラム概要   : 棚卸準備処理UIクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村 仁
// 作 成 日  2007.04.12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007.09.10  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008.02.14  修正内容 : 不具合対応／仕様変更対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/08/28  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/02  修正内容 : 排他制御処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13107
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/11  修正内容 : 不具合対応[13257]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/21  修正内容 : 仕様変更　リモートに渡す条件を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/15  修正内容 : MANTIS対応(13957)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/11/30  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/12/22  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李占川
// 作 成 日  2010/02/20  修正内容 : ①PM1005、倉庫コードを変更して範囲指定した場合に有効にならない障害の対応
//                                  ②PM1005、倉庫単独指定時の障害の対応 
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : yamgj
// 作 成 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/01/30  修正内容 : readmine#18780の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 修 正 日  2012/06/08  修正内容 : 2012/06/27配信分、Redmine#30282
//                                  №1002　棚卸準備処理の改良の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangyi
// 修 正 日  2012/08/09  修正内容 : redmine#31515 「棚卸準備処理」のラッシュ時エラーの対応
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸準備処理UIクラス    
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理UIクラスの機能を実装する。</br>
	/// <br>Programmer : 23010 中村仁</br>
	/// <br>Date       : 2007.04.12</br>
    /// <br>Update Note: 2007.09.10 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.14 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応／仕様変更対応（DC.NS対応）</br>
    /// <br>UpdateNote : 2008/08/28 30414 忍 幸史</br>
    /// <br>             ・Partsman用に変更</br>
    /// <br>UpdateNote : 2009/02/02 30452 上野 俊治</br>
    /// <br>             ・排他制御処理追加</br>
    /// <br>UpdateNote : 2009/04/13 30452 上野 俊治</br>
    /// <br>             ・障害対応13107</br>
    /// <br>UpdateNote : 2009/05/11       照田 貴志</br>
    /// <br>             ・不具合対応[13257]</br>
    /// <br>UpdateNote : 2009/05/21       照田 貴志</br>
    /// <br>             ・仕様変更　リモートに渡す条件を修正</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             棚卸日の前回月次更新日以前チェック時のエラーメッセージ内容が不明確な為、内容を変更する</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             既存データ存在時の処理内容を変更</br>
    /// <br>             在庫管理全体設定の「棚卸印刷順初期設定区分」を参照して棚卸通番を付番するように変更する</br>
    /// <br>Update Note : 2009/12/22 張凱 保守依頼③対応</br>
    /// <br>             ログイン拠点に関係なく全拠点の月次更新履歴で、棚卸日の前回月次更新日以前チェックを行うように変更する</br>
    /// <br>Update Note : 2010/02/20 李占川 PM1005</br>
    /// <br>             ①倉庫コードを変更して範囲指定した場合に有効にならない障害の対応</br>
    /// <br>             ②倉庫単独指定時の障害の対応</br> 
    /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
    /// </remarks>
	public partial class MAZAI05110UA : Form, IEntryTbsMDIChild, IEntryTbsMDIChildEdit
	{
		# region Constructor
		/// <summary>
		/// 棚卸準備処理UIクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸準備処理UIクラスのインスタンスを生成します</br>
		/// <br>Programmer : 23010 中村仁</br>
		/// <br>Date       : 2007.04.12</br>
		/// </remarks>
		public MAZAI05110UA()
		{
            InitializeComponent();
										
			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;						
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			 //画面デザイン変更クラス
            this._controlScreenSkin = new ControlScreenSkin();

            //棚卸準備処理アクセスクラス
            if (this._inventoryPrepareAcs == null)
            {
                this._inventoryPrepareAcs = new InventoryPrepareAcs();
            }                         
			// グリッド設定ロード
			this._gridStateController = new GridStateController();
			this._gridStateController.LoadGridState(ct_FileName_ColDisplayStatus);

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._makerAcs = new MakerAcs();
            this._stockMngTglStAcs = new StockMngTtlStAcs();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();

            // 最終月次更新日取得
            this._prevTotalDay = GetPrevTotalDay();

            // 各種マスタ読込
            LoadSecInfoSet();
            LoadWarehouse();
            LoadSupplier();
            LoadBLGoodsCdUMnt();
            LoadBLGroupU();
            LoadMakerUMnt();
            LoadStockMngTtlSt();

            this._warehouseCodeArray = new TEdit[10];
            this._warehouseCodeArray[0] = this.tEdit_WarehouseCode_01;
            this._warehouseCodeArray[1] = this.tEdit_WarehouseCode_02;
            this._warehouseCodeArray[2] = this.tEdit_WarehouseCode_03;
            this._warehouseCodeArray[3] = this.tEdit_WarehouseCode_04;
            this._warehouseCodeArray[4] = this.tEdit_WarehouseCode_05;
            this._warehouseCodeArray[5] = this.tEdit_WarehouseCode_06;
            this._warehouseCodeArray[6] = this.tEdit_WarehouseCode_07;
            this._warehouseCodeArray[7] = this.tEdit_WarehouseCode_08;
            this._warehouseCodeArray[8] = this.tEdit_WarehouseCode_09;
            this._warehouseCodeArray[9] = this.tEdit_WarehouseCode_10;
            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
		}
		# endregion

		# region Const
		/// <summary> グリッド固定幅 </summary>
		private const int ctDifferenceHeight = 390;
		/// <summary> 列表示状態セッティングXMLファイル名 </summary>
		private const string ct_FileName_ColDisplayStatus =  "MAZAI05110U_ColSetting.DAT";
        /// <summary> PGID </summary>
        private const string ctPGID = "MAZAI05110U";
               
		# endregion    

		# region Private Members

        // 初回起動フラグ
		private bool _isFirstFlag = true;   
		// ログイン情報
		private string _enterpriseCode;		// 企業コード
        private string _loginSectionCode;   // ログイン拠点(自拠点)
        // 棚卸データ重複時更新確認ダイアログ
		private BeforeSaveCheckDialog _beforeSaveCheckDialog;
	    // 棚卸履歴格納データセット
		private DataSet _prtIvntHisDataSet;
	    // グリッドコントロールクラス                    
        private GridStateController _gridStateController = null;		
        // 棚卸準備処理アクセスクラス
        private InventoryPrepareAcs _inventoryPrepareAcs = null;	    
        // 棚卸準備処理条件パラメータクラス
        private InventoryExtCndtnWork _inventoryExtCndtnWork = null;
        // 棚卸検索抽出条件パラメータクラス
	    private InventInputSearchCndtnWork _inventInputSearchCndtnWork = null;					
				
        //ガイド用
        ///メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        ///商品区分グループマスタアクセスクラス
        private LGoodsGanreAcs _lGoodsGanreAcs = null;
        ///商品区分マスタアクセスクラス
        private MGoodsGanreAcs _mGoodsGanreAcs = null;   

        //在庫評価法
        private int _stockPointWay = 0;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        //倉庫ガイド
        private WarehouseAcs _warehouseAcs = null;
        // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
        ////キャリアガイド
        //private CarrierOdrAcs _carrierOdrAcs = null;
        ////機種ガイド
        //private CellphoneModelAcs _cellphoneModelAcs = null;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        //得意先ガイド
        private CustomerInfoAcs _customerInfoAcs = null;
        //商品区分詳細マスタアクセスクラス
        private DGoodsGanreAcs _dGoodsGanreAcs = null;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        //ＢＬ商品マスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        //ユーザーガイドマスタアクセスクラス（自社分類）
        private UserGuideGuide _userGuideGuide = null;
        // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        // BLグループコードアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;

        // 仕入先アクセスクラス
        private SupplierAcs _supplierAcs = null;

        // 拠点アクセスクラス
        private SecInfoAcs _secInfoAcs = null;

        // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;

        // 在庫管理全体設定マスタアクセスクラス
        private StockMngTtlStAcs _stockMngTglStAcs = null;

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator = null;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private StockMngTtlSt _stockMngTtlSt;

        private StockMngTtlSt _stockMngTtlStLogin;//ADD 2009/11/30

        private DateTime _prevTotalDay;

        private TEdit[] _warehouseCodeArray;
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // 削除履歴日付取得
        private int targetDelDate = 0;
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
      
		# endregion

		#region IEntryTbsMDIChild メンバ

		#region 自画面初期化・表示処理

		/// <summary>
		/// 自画面初期化・表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void IEntryTbsMDIChild.Show(object parameter)
		{
			// フレームから呼ばれていない
			//// 棚卸準備更新処理
			this._inventoryPrepareAcs.Read(out this._inventoryExtCndtnWork);	// ここでは初期化しているだけ
			this.Show();
		}

		#endregion

		#region TabActive前処理
		/// <summary>
		/// TabActive前処理
		/// </summary>
		/// <param name="parameter">対象オブジェクト</param>
		int IEntryTbsMDIChild.ShowStaticMemoryData(object sender)
		{
            // 初回起動時のみ
            if ( this._isFirstFlag )
            {               
                // データ取得処理
                this._inventoryPrepareAcs.Read(out this._inventoryExtCndtnWork);	// ここでは初期化しているだけ                           
                // 初期フォーカス               
                //this.InventStart_Button.Focus();
                this.InventoryDate_tDateEdit.Focus();
            }

            //グリッド表示用履歴データ取得
            this._inventoryPrepareAcs.Read(out this._prtIvntHisDataSet);

            // グリッド表示
            if (this.PrepareHistory_Grid.DataSource == null)
            {
                this.PrepareHistory_Grid.DataSource = this._prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            }              
            else
            {
                this.UpdateGridPrepareHistory(this._prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table]);
            }

            //グリッド描画処理
            SetUpPrepareHistoryGrid();

            // グリッド設定
            this.PrepareHistoryGridDisp();

            if (sender is InventInputSearchCndtnWork)
            {
                InventInputSearchCndtnWork pisCondWork = sender as InventInputSearchCndtnWork;

                if ( this._isFirstFlag )
                {
                    this._inventoryPrepareAcs.Read(out this._inventoryExtCndtnWork);
                }
                else
                {
                    ToDataFromScreenInventoryExtCndtnWork();
                }
                //???
                ToInventInputSearchCndtnWorkFromScreen(ref pisCondWork);
            }

			return 0;
		}


        /// <summary>
		/// //グリッド描画処理
		/// </summary>
		/// <param name="parameter">対象オブジェクト</param>
        private void SetUpPrepareHistoryGrid()
        {
            //処理区分が削除処理の履歴のForeColorをBlueに
            for(int ix = 0; ix < this.PrepareHistory_Grid.DisplayLayout.Rows.Count; ix ++)
            {
                if((int)this.PrepareHistory_Grid.DisplayLayout.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryProcDiv_Hidden].Value == 3)
                {
                    //処理日時、区分を青文字に変更する
                    this.PrepareHistory_Grid.DisplayLayout.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprDate].Appearance.ForeColor = Color.Blue;
                    this.PrepareHistory_Grid.DisplayLayout.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprTime].Appearance.ForeColor = Color.Blue;
                    this.PrepareHistory_Grid.DisplayLayout.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryProcDiv].Appearance.ForeColor = Color.Blue;
                }
            }           
        }
		#endregion

		#endregion IEntryTbsMDIChild メンバ

		#region IEntryTbsMDIChildEdit メンバ

		#region 更新処理
        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 更新処理
		/// </summary>
		/// <param name="sender">メインフレームインスタンス</param>
		/// <returns>Status</returns>
		int IEntryTbsMDIChildEdit.SaveStaticMemoryData(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			string serverErrorMsg = "";

            //棚卸準備処理
            if(this.InventStart_Button.Checked)          
            {
                if (this._inventoryExtCndtnWork == null)
                {
                    this._inventoryExtCndtnWork = new InventoryExtCndtnWork();
                    this._inventoryExtCndtnWork.EnterpriseCode = this._enterpriseCode.Trim();
                    
                    //自拠点をセット                  
                    this._inventoryExtCndtnWork.SectionCode = this._loginSectionCode;
                }

			    // 画面データセット処理
			    if ( this._isFirstFlag )
			    {
				    this._inventoryPrepareAcs.Read(out this._inventoryExtCndtnWork);
			    }
			    else
			    {
                    //画面情報→履歴条件条件クラス
				    this.ToDataFromScreenInventoryExtCndtnWork();
			    }

			    // 登録前チェック処理
			    status = this.BeforeSaveCheckProc();

			    if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			    {
				    return 0;
			    }

                //時間がかかるので抽出中画面部品のインスタンスを作成する
                SFCMN00299CA form = new SFCMN00299CA();
                // 表示文字を設定
                form.Title = "棚卸準備処理中";
                form.Message = "現在、棚卸準備処理中です。";
                try
			    {
                    form.Show();			// ダイアログ表示
                    
                    // 棚卸準備更新処理
			        status = this._inventoryPrepareAcs.WriteDBData(this._inventoryExtCndtnWork, out serverErrorMsg);
                }
                finally
                {
                    // ダイアログを閉じる
                    form.Close();                  
                }		    

			    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			    {
				    // 完了メッセージ表示
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_INFO,
					    "棚卸データを更新しました。",
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );

                    //削除ボタンを有効にする
                    this.InventDelete_Button.Enabled = true;
                    //Enableの時がイマイチ分かりづらいので
                    this.InventDelete_Button.ForeColor = SystemColors.ControlText;

			    }
			    else if ( status == (int)ConstantManagement.DB_Status.ctDB_ERROR )
			    {
				    // 失敗メッセージ表示
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_STOPDISP,
					    "棚卸準備処理に失敗しました。" + serverErrorMsg,
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );
			    }
			    else
			    {
				    // エラーステータスなのにメッセージが帰ってこなかったとき
				    if ( serverErrorMsg.CompareTo( "" ) == 0 )
				    {
					    serverErrorMsg = "棚卸準備処理に失敗しました。";
				    }
				    // 失敗メッセージ表示(Nomal, Error以外のとき。リモートからメッセージが帰ってくる。)
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_INFO,
					    serverErrorMsg,
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );

			    }

			    return 0;	// フレームにゼロ以外返しても意味ないのでゼロを返す。

            }
            //棚卸データ削除処理
            else
            {
                //削除前にダイアログを表示して一度確認する                
			    DialogResult ret = ShowMsgDisp(
				    emErrorLevel.ERR_LEVEL_INFO,
				    "棚卸データが削除されますがよろしいですか？",
				    status,
				    "SaveStaticMemoryData",
				    MessageBoxButtons.YesNo
			    );

                if(ret == DialogResult.No)
                {
                    return 0;
                }

                //棚卸データパラメータクラス
                InventoryDataWork inventoryDataWork = new InventoryDataWork();
                //自拠点の棚卸データを全て削除する
                //企業コード
                inventoryDataWork.EnterpriseCode = this._inventoryExtCndtnWork.EnterpriseCode;
                //拠点コード
                inventoryDataWork.SectionCode = this._inventoryExtCndtnWork.SectionCode;
                //削除
                status = this._inventoryPrepareAcs.Delete(inventoryDataWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			    {
				    //完了メッセージ表示
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_INFO,
					    "棚卸データを削除しました。",
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );
                    
                    //削除処理ボタンのチェックを外しEnableをfalseにする
                    this.InventStart_Button.Checked = true;
                    this.InventDelete_Button.Enabled = false;
                    //Infoラベルを非表示
                    this.Info_Title.Visible = false;
                    //Enableの時がイマイチ分かりづらいので
                    this.InventDelete_Button.ForeColor = SystemColors.ControlDark;
			    }
			    else if ( status == (int)ConstantManagement.DB_Status.ctDB_ERROR )
			    {
				    // 失敗メッセージ表示
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_STOPDISP,
					    "棚卸データの削除に失敗しました。",
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );
			    }
			    else
			    {
				     // 失敗メッセージ表示
				    ShowMsgDisp(
					    emErrorLevel.ERR_LEVEL_STOPDISP,
					    "棚卸データの削除に失敗しました。",
					    status,
					    "SaveStaticMemoryData",
					    MessageBoxButtons.OK
				    );

			    }
                return 0;	// フレームにゼロ以外返しても意味ないのでゼロを返す。
            }          
		}
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        // --- ADD 2012/08/09 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <returns>Status</returns>
        /// <br>Note       : 更新処理</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2012/08/09</br>
        int IEntryTbsMDIChildEdit.SaveStaticMemoryData(object sender)
        {
            SaveStaticMemoryData(sender);
            return 0;
        }
        // --- ADD 2012/08/09 --------------------------------------------------------------------->>>>>

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <returns>Status</returns>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        /// <br>Update Note: 2012/08/09 yangyi</br>
        /// <br>             redmine#31515 「棚卸準備処理」のラッシュ時エラーの対応</br>
        private int SaveStaticMemoryData(object sender)                        //DEL 2012/08/09
        //int IEntryTbsMDIChildEdit.SaveStaticMemoryData(object sender)        //ADD 2012/08/09
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string serverErrorMsg = "";

            //棚卸準備処理
            //if (this.InventStart_Button.Checked)                                              // DEL yangyi 2012/06/08 Redmine#30282
            if (this.InventStart_Button.Checked || this._stockMngTtlSt.InvntryDtDelDiv ==2)     // ADD yangyi 2012/06/08 Redmine#30282
            {
                if (this._inventoryExtCndtnWork == null)
                {
                    this._inventoryExtCndtnWork = new InventoryExtCndtnWork();
                    this._inventoryExtCndtnWork.EnterpriseCode = this._enterpriseCode.Trim();

                    //自拠点をセット                  
                    this._inventoryExtCndtnWork.SectionCode = this._loginSectionCode;
                }

                // 画面データセット処理
                if (this._isFirstFlag)
                {
                    this._inventoryPrepareAcs.Read(out this._inventoryExtCndtnWork);
                }
                else
                {
                    //画面情報→履歴条件条件クラス
                    this.ToDataFromScreenInventoryExtCndtnWork();
                }

                // 登録前チェック処理
                status = BeforeSaveCheckProc();
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return 0;
                }

                //時間がかかるので抽出中画面部品のインスタンスを作成する
                SFCMN00299CA form = new SFCMN00299CA();
                
                // 表示文字を設定
                form.Title = "棚卸準備処理中";
                form.Message = "現在、棚卸準備処理中です。";
                try
                {
                    // ダイアログ表示
                    form.Show();			

                    // 棚卸準備更新処理
                    status = this._inventoryPrepareAcs.WriteDBData(this._inventoryExtCndtnWork, out serverErrorMsg);
                }
                finally
                {
                    // ダイアログを閉じる
                    form.Close();
                }

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 完了メッセージ表示
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "棚卸データを更新しました。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );

                            //削除ボタンを有効にする
                            this.InventDelete_Button.Enabled = true;
                            //Infoラベルを非表示
                            Info_Title.Visible = true;
                            //Enableの時がイマイチ分かりづらいので
                            this.InventDelete_Button.ForeColor = SystemColors.ControlText;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        break;
                    // ----- DEL 2012/08/09 ---------->>>>>
                    //case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    //    break;
                    //case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    //    break;
                    // ----- DEL 2012/08/09 ---------->>>>>
                    // ----- ADD 2012/08/09 ---------->>>>>
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        string msg = "ただ今処理が混み合っているため、中断しました。再度準備処理を実行してください。\n\n" + "準備処理を実行しますか？";
                        DialogResult dr = ShowMsgDisp(emErrorLevel.ERR_LEVEL_INFO,
                                                      msg,
                                                      status,
                                                      "SaveStaticMemoryData",
                                                      MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            SaveStaticMemoryData(sender); // 棚卸準備更新処理
                        }
                        break;
                    // ----- ADD 2012/08/09 ----------<<<<<
                    // --- ADD 2009/02/02 -------------------------------->>>>>
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    // --- ADD 2009/02/02 --------------------------------<<<<<
                    default:
                        {
                            // エラーステータスなのにメッセージが帰ってこなかったとき
                            if (serverErrorMsg.CompareTo("") == 0)
                            {
                                serverErrorMsg = "棚卸準備処理に失敗しました。";
                            }

                            // 失敗メッセージ表示(Nomal, Error以外のとき。リモートからメッセージが帰ってくる。)
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                serverErrorMsg,
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                }

                this._inventoryExtCndtnWork = null; // ADD 2010/02/20

                return 0;	// フレームにゼロ以外返しても意味ないのでゼロを返す。

            }
            //棚卸データ削除処理
            else
            {
                //削除前にダイアログを表示して一度確認する                
                DialogResult ret = ShowMsgDisp(
                    emErrorLevel.ERR_LEVEL_INFO,
                    "棚卸データが削除されますがよろしいですか？",
                    status,
                    "SaveStaticMemoryData",
                    MessageBoxButtons.YesNo
                );

                if (ret == DialogResult.No)
                {
                    return 0;
                }

                //棚卸データパラメータクラス
                InventoryDataWork inventoryDataWork = new InventoryDataWork();
                //自拠点の棚卸データを全て削除する
                // --- UPD 2010/02/20 ---------->>>>>
                //企業コード
                //inventoryDataWork.EnterpriseCode = this._inventoryExtCndtnWork.EnterpriseCode;
                inventoryDataWork.EnterpriseCode = this._enterpriseCode.Trim();
                //拠点コード
                //inventoryDataWork.SectionCode = this._inventoryExtCndtnWork.SectionCode;
                inventoryDataWork.SectionCode = this._loginSectionCode;
                // --- UPD 2010/02/20 ----------<<<<<
                // DEL yangyi 2012/06/14 Redmine#30282 ------------->>>>>
                //// ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                //// 開始管理拠点コード
                //inventoryDataWork.SectionCodeSt = this.tNEdit_SectionCode_St.DataText.Trim();
                //// 終了管理拠点コード
                //inventoryDataWork.SectionCodeEd = this.tNEdit_SectionCode_Ed.DataText.Trim();
                //// ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                // DEL yangyi 2012/06/14 Redmine#30282 -------------<<<<<
                // ADD yangyi 2012/06/14 Redmine#30282 ------------->>>>>
                if (this._stockMngTtlSt.InvntryDtDelDiv == 1)
                {
                    // 開始管理拠点コード
                    if (string.IsNullOrEmpty(this.tNEdit_SectionCode_St.DataText.Trim()))
                    {
                        inventoryDataWork.SectionCodeSt = "0";
                    }
                    else
                    {
                        inventoryDataWork.SectionCodeSt = this.tNEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0') ;
                    }
                    // 終了管理拠点コード
                    if (string.IsNullOrEmpty(this.tNEdit_SectionCode_Ed.DataText.Trim()))
                    {
                        inventoryDataWork.SectionCodeEd = "99";
                    }
                    else
                    {
                        inventoryDataWork.SectionCodeEd = this.tNEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty( this.tNEdit_SectionCode_St.DataText.Trim()))
                    {
                        // 開始管理拠点コード
                        inventoryDataWork.SectionCodeSt = this.tNEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
                    }
                    if (!string.IsNullOrEmpty(this.tNEdit_SectionCode_St.DataText.Trim()))
                    {
                        // 終了管理拠点コード
                        inventoryDataWork.SectionCodeEd = this.tNEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    }
                }
                if (inventoryDataWork.SectionCodeSt =="00")
                {
                    inventoryDataWork.SectionCodeSt = "0";
                }
                // ADD yangyi 2012/06/14 Redmine#30282 -------------<<<<<
                //削除
                status = this._inventoryPrepareAcs.Delete(inventoryDataWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //完了メッセージ表示
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "棚卸データを削除しました。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            //削除処理ボタンのチェックを外しEnableをfalseにする
                            // DEL yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                            //this.InventStart_Button.Checked = true;
                            //this.InventDelete_Button.Enabled = false;
                            ////Infoラベルを非表示
                            //this.Info_Title.Visible = false;
                            ////Enableの時がイマイチ分かりづらいので
                            //this.InventDelete_Button.ForeColor = SystemColors.ControlDark;
                            // DEL yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                            // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                            // 棚卸マスタチェック
                            object retobj = null;
                            ArrayList list = new ArrayList();
                            int statusCode = 0;
                            InventoryDataWork invenDataWork = new InventoryDataWork();
                            invenDataWork.EnterpriseCode = this._enterpriseCode;
                            statusCode = this._inventoryPrepareAcs.SearchInventoryData(out retobj, invenDataWork);
                            if (statusCode == 0)
                            {
                                list = (ArrayList)retobj;
                            }
                            if (list == null)
                            {
                                //Infoラベルを非表示
                                this.Info_Title.Visible = false;
                                this.InventStart_Button.Checked = true;
                            }
                            else
                            {
                                if (list.Count == 0)
                                {
                                    //Infoラベルを非表示
                                    this.Info_Title.Visible = false;
                                    this.InventStart_Button.Checked = true;
                                }
                                else
                                {
                                    //Enableの時がイマイチ分かりづらいので
                                    this.InventDelete_Button.ForeColor = SystemColors.ControlText;
                                    //Infoラベルを表示
                                    this.Info_Title.Visible = true;
                                }
                            }
                            // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<


                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                              ShowMsgDisp(
                              emErrorLevel.ERR_LEVEL_INFO,
                              "該当するデータがありません。",
                              status,
                              "SaveStaticMemoryData",
                              MessageBoxButtons.OK
                          );
                        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        break;
                    // ----- DEL 2012/08/09 ---------->>>>>
                    //case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    //    break;
                    //case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    //    break;
                    // ----- DEL 2012/08/09 ---------->>>>>
                    // ----- ADD 2012/08/09 ---------->>>>>
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT :
                        string msg = "ただ今処理が混み合っているため、中断しました。再度削除処理を実行してください。\n\n" + "削除処理を実行しますか？";
                        DialogResult dr = ShowMsgDisp(emErrorLevel.ERR_LEVEL_INFO,
                                                      msg,
                                                      status,
                                                      "SaveStaticMemoryData",
                                                      MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            SaveStaticMemoryData(sender);  // 棚卸準備更新処理
                        }
                        break;
                    // ----- ADD 2012/08/09 ----------<<<<<
                    // --- ADD 2009/02/02 -------------------------------->>>>>
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(企業ロック)です。" + "\r\n"
                                + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                                + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_INFO,
                                "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                                + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                    // --- ADD 2009/02/02 --------------------------------<<<<<
                    default:
                        {
                            // 失敗メッセージ表示
                            ShowMsgDisp(
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                "棚卸データの削除に失敗しました。",
                                status,
                                "SaveStaticMemoryData",
                                MessageBoxButtons.OK
                            );
                            break;
                        }
                }

                return 0;	// フレームにゼロ以外返しても意味ないのでゼロを返す。
            }
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

		#endregion

		#region 更新前エラーチェック処理
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 更新前エラーチェック処理
		/// </summary>
		/// <param name="sender">メインフレームインスタンス</param>
		/// <param name="ErrorItems">エラー発生コントロールリスト</param>
		/// <returns>Status</returns>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        int IEntryTbsMDIChildEdit.ShowErrorItems(object sender, ArrayList ErrorItems)
		{
			int result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 棚卸データ削除が選択されている場合          
            if(this.InventDelete_Button.Checked)
            {
                return result;
            }

			Control errControl = null;

			try
			{
                int startTarget;
                int endTarget;
       
				// 棚卸日
                //DateTime yearMonth;
                //int year;
                //DateTime startMonthDate;
                //DateTime endMonthDate;
                //this._dateGetAcs.GetThisYearMonth(out yearMonth, out year, out startMonthDate, out endMonthDate);

                //if ((this.InventoryDate_tDateEdit.GetDateTime() <  startMonthDate) ||
                //    (this.InventoryDate_tDateEdit.GetDateTime() >= startMonthDate.AddMonths(1)))
                //{
                //    ErrorItems.Add(InventoryDate_Title.Text + "の指定に誤りがあります。");
                //    errControl = InventoryDate_tDateEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                if (this.InventoryDate_tDateEdit.GetDateTime() == DateTime.MinValue)
                {
                    ErrorItems.Add("棚卸日の指定に誤りがあります。");
                    errControl = this.InventoryDate_tDateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                if (this.InventoryDate_tDateEdit.GetDateTime() <= this._prevTotalDay)
                {
                    // --- UPD 2009/11/30 ---------->>>>>
                    //ErrorItems.Add("棚卸日の指定に誤りがあります。");
                    ErrorItems.Add("棚卸日が前回月次更新日以前になっている為、登録できません。");
                    ErrorItems.Add("前回月次更新日：" + TDateTime.DateTimeToString("yyyy年MM月dd日", this._prevTotalDay));
                    // --- UPD 2009/11/30 ----------<<<<<
                    errControl = this.InventoryDate_tDateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }

				// 倉庫コード
                if ((int)this.WarehouseCodeDiv_tComboEditor.Value == 0)
                {
                    // 範囲
                    if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") &&
                        (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
                    {
                        startTarget = int.Parse(this.tEdit_WarehouseCode_St.DataText.Trim());
                        endTarget = int.Parse(this.tEdit_WarehouseCode_Ed.DataText.Trim());

                        if (startTarget > endTarget)
                        {
                            ErrorItems.Add("倉庫の範囲指定に誤りがあります。");
                            errControl = this.tEdit_WarehouseCode_St;
                            result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            return result;
                        }
                    }
                }
                else
                {
                    // 単独
                    for (int index = 0; index < this._warehouseCodeArray.Length; index++)
                    {
                        string warehouseCode = this._warehouseCodeArray[index].DataText.Trim();

                        if (warehouseCode == "")
                        {
                            continue;
                        }

                        if (GetWarehouseName(warehouseCode) == "")
                        {
                            ErrorItems.Add("倉庫コードがマスタに登録されていません。");
                            errControl = this._warehouseCodeArray[index];
                            result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            return result;
                        }
                    }
                }

                // 棚番
                if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && 
                    (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != "") &&
                    (this.tEdit_WarehouseShelfNo_St.DataText.CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText) > 0))
                {
                    ErrorItems.Add("棚番の範囲指定に誤りがあります。");
                    errControl = this.tEdit_WarehouseShelfNo_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }

                // 仕入先コード
                if ((this.tNedit_SupplierCd_St.GetInt() != 0) && 
                    (this.tNedit_SupplierCd_Ed.GetInt() != 0))
                {
                    startTarget = this.tNedit_SupplierCd_St.GetInt();
                    endTarget = this.tNedit_SupplierCd_Ed.GetInt();

                    if (startTarget > endTarget)
                    {
                        ErrorItems.Add("仕入先の範囲指定に誤りがあります。");
                        errControl = this.tNedit_SupplierCd_St;
                        result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        return result;
                    }
                }

                // ＢＬコード
                if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                    (this.tNedit_BLGoodsCode_Ed.GetInt() != 0))
                {
                    startTarget = this.tNedit_BLGoodsCode_St.GetInt();
                    endTarget = this.tNedit_BLGoodsCode_Ed.GetInt();

                    if (startTarget > endTarget)
                    {
                        ErrorItems.Add("BLｺｰﾄﾞの範囲指定に誤りがあります。");
                        errControl = this.tNedit_BLGoodsCode_St;
                        result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        return result;
                    }
                }

                // グループコード
                if ((this.tNedit_BLGloupCode_St.GetInt() != 0) && 
                    (this.tNedit_BLGloupCode_Ed.GetInt() != 0))
                {
                    startTarget = this.tNedit_BLGloupCode_St.GetInt();
                    endTarget = this.tNedit_BLGloupCode_Ed.GetInt();

                    if (startTarget > endTarget)
                    {
                        ErrorItems.Add("ｸﾞﾙｰﾌﾟｺｰﾄﾞの範囲指定に誤りがあります。");
                        errControl = this.tNedit_BLGloupCode_St;
                        result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        return result;
                    }
                }

                // メーカーコード
                if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && 
                    (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
                {
                    startTarget = this.tNedit_GoodsMakerCd_St.GetInt();
                    endTarget = this.tNedit_GoodsMakerCd_Ed.GetInt();

                    if (startTarget > endTarget)
                    {
                        ErrorItems.Add("メーカーの範囲指定に誤りがあります。");
                        errControl = tNedit_GoodsMakerCd_St;
                        result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        return result;
                    }
                }
                //-----ADD 2011/01/11----->>>>>
                if ((this.tNEdit_SectionCode_St.GetInt() != 0) &&
                    (this.tNEdit_SectionCode_Ed.GetInt() != 0))
                {
                    startTarget = int.Parse(this.tNEdit_SectionCode_St.DataText.Trim());
                    endTarget = int.Parse(this.tNEdit_SectionCode_Ed.DataText.Trim());

                    if (startTarget > endTarget)
                    {
                        ErrorItems.Add("拠点コードの範囲指定に誤りがあります。");
                        errControl = tNEdit_SectionCode_St;
                        result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        return result;
                    }
                }
                //-----ADD 2011/01/11-----<<<<<
                //// 最終棚卸更新日
                //else if ((IsErrorDateEdit(StartInventUpdate_DateEdit)))
                //{
                //    ErrorItems.Add("最終棚卸更新日(開始)が不正な日付です。");
                //    errControl = StartInventUpdate_DateEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                //// 最終棚卸更新日
                //else if ((IsErrorDateEdit(EndInventUpdate_DateEdit)))
                //{
                //    ErrorItems.Add("最終棚卸更新日(終了)が不正な日付です。");
                //    errControl = EndInventUpdate_DateEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                //else if (((this.StartInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue) || 
                //         (this.EndInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue)) &&
                //         (this.StartInventUpdate_DateEdit.GetDateTime() > this.EndInventUpdate_DateEdit.GetDateTime()))
                //{
                //    ErrorItems.Add("最終棚卸更新日の範囲指定に誤りがあります。");
                //    errControl = StartInventUpdate_DateEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}                
                //// 最終棚卸更新日(終了)未来日付チェック
                //else if ((this.EndInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue) &&
                //         (this.EndInventUpdate_DateEdit.GetDateTime() > TDateTime.GetSFDateNow()))
                //{
                //    ErrorItems.Add("最終棚卸更新日(終了)に未来日付を指定することは出来ません。");
                //    errControl = EndInventUpdate_DateEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
			}
			finally
			{
                if (errControl != null)
                {
                    errControl.Focus();
                }
			}
			return result;
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新前エラーチェック処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <param name="ErrorItems">エラー発生コントロールリスト</param>
        /// <returns>Status</returns>
        int IEntryTbsMDIChildEdit.ShowErrorItems(object sender, ArrayList ErrorItems)
        {
            int result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //棚卸データ削除が選択されている場合          
            if (this.InventDelete_Button.Checked)
            {
                return result;
            }

            Control errControl = null;
            try
            {
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                //棚卸日
                DateTime yearMonth;
                int year;
                DateTime startMonthDate;
                DateTime endMonthDate;
                this._dateGetAcs.GetThisYearMonth(out yearMonth, out year, out startMonthDate, out endMonthDate);
                if ((this.InventoryDate_tDateEdit.GetDateTime() < startMonthDate) ||
                    (this.InventoryDate_tDateEdit.GetDateTime() >= startMonthDate.AddMonths(1)))
                {
                    ErrorItems.Add(InventoryDate_Title.Text + "の指定に誤りがあります。");
                    errControl = InventoryDate_tDateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                //倉庫コード
                if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != "") &&
                    (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0))
                {
                    ErrorItems.Add(WarehouseCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = tEdit_WarehouseCode_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
                //棚番
                else if ((this.StartShelfNo_tEdit.DataText.Trim() != "") && (this.EndShelfNo_tEdit.DataText.Trim() != "") &&
                    (this.StartShelfNo_tEdit.DataText.CompareTo(this.EndShelfNo_tEdit.DataText) > 0))
                {
                    ErrorItems.Add(ShelfNo_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = StartShelfNo_tEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                //仕入先コード
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //else if ((this.tNedit_SupplierCd_St.GetInt() != 0) && (this.tNedit_SupplierCd_Ed.GetInt() != 999) &&
                //    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                else if ((this.tNedit_SupplierCd_St.GetInt() != 0) && (this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    ErrorItems.Add(this.CustomerCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = tNedit_SupplierCd_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                //商品区分詳細コード
                else if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") && (this.tNedit_BLGloupCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_St.DataText.CompareTo(this.tNedit_BLGloupCode_Ed.DataText) > 0))
                {
                    ErrorItems.Add(this.DetailGoodsGanreCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = tNedit_BLGloupCode_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                //自社分類コード
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //else if ((this.StartEnterpriseGanreCode_tNedit.GetInt() != 0) && (this.EndEnterpriseGanreCode_tNedit.GetInt() != 999) &&
                //    (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt()))
                else if ((this.StartEnterpriseGanreCode_tNedit.GetInt() != 0) && (this.EndEnterpriseGanreCode_tNedit.GetInt() != 0) &&
                    (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt()))
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    ErrorItems.Add(this.EnterpriseGanreCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = StartEnterpriseGanreCode_tNedit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
                //メーカーコード
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //else if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 999) &&
                //    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
                else if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    ErrorItems.Add(this.MakerCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = tNedit_GoodsMakerCd_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                //商品区分グループコード
                else if ((this.StartLargeGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndLargeGoodsGanreCode_tEdit.DataText.Trim() != "") &&
                    (this.StartLargeGoodsGanreCode_tEdit.DataText.CompareTo(this.EndLargeGoodsGanreCode_tEdit.DataText) > 0))
                {
                    ErrorItems.Add(this.LargeGoodsGanreCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = StartLargeGoodsGanreCode_tEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                //商品区分コード
                else if ((this.StartMediumGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndMediumGoodsGanreCode_tEdit.DataText.Trim() != "") &&
                    (this.StartMediumGoodsGanreCode_tEdit.DataText.CompareTo(this.EndMediumGoodsGanreCode_tEdit.DataText) > 0))
                {
                    ErrorItems.Add(this.MediumGoodsGanreCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = StartMediumGoodsGanreCode_tEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }

                // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                ////商品種別
                //if(this.GoodsKind1_ultraCheckEditor.Checked == false && this.GoodsKind2_ultraCheckEditor.Checked == false &&
                //  this.GoodsKind3_ultraCheckEditor.Checked == false)
                //{
                //    //一つもチェックされていない
                //    ErrorItems.Add(this.GoodsKindCode_Title.Text + "は最低一つは選択してください。");
                //    errControl = this.GoodsKind1_ultraCheckEditor;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

                //ＢＬコード
                else if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_St.DataText.CompareTo(this.tNedit_BLGoodsCode_Ed.DataText) > 0))
                {
                    ErrorItems.Add(this.BLGoodsCode_Title.Text + "の範囲指定に誤りがあります。");
                    errControl = tNedit_BLGoodsCode_St;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                ////機種コード
                //else if ((this.St_CellphoneModelCode_tEdit.DataText.Trim() != "") &&	(this.Ed_CellphoneModelCode_tEdit.DataText.Trim() != "") &&
                //    (this.St_CellphoneModelCode_tEdit.DataText.CompareTo(this.Ed_CellphoneModelCode_tEdit.DataText) > 0))
                //{
                //    ErrorItems.Add(this.EnterpriseGanreCode_Title.Text + "の範囲指定に誤りがあります。");
                //    errControl = St_CellphoneModelCode_tEdit;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                ////在庫抽出区分
                //else if(this.CmpStockDiv_CheckEditor.Checked == false && this.TrsStockDiv_CheckEditor.Checked == false &&
                //  this.EntrustCmpStockDiv_CheckEditor.Checked == false && this.EntrustTrsStockDiv_CheckEditor.Checked == false)
                //{
                //    //一つもチェックされていない
                //    ErrorItems.Add(StockExtraDiv_Title.Text + "は最低一つは選択してください。");
                //    errControl = this.CmpStockDiv_CheckEditor;
                //    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //    return result;
                //}
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                // 最終棚卸更新日
                else if ((IsErrorDateEdit(StartInventUpdate_DateEdit)))
                {
                    ErrorItems.Add("最終棚卸更新日(開始)が不正な日付です。");
                    errControl = StartInventUpdate_DateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 最終棚卸更新日
                else if ((IsErrorDateEdit(EndInventUpdate_DateEdit)))
                {
                    ErrorItems.Add("最終棚卸更新日(終了)が不正な日付です。");
                    errControl = EndInventUpdate_DateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                else if (((this.StartInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue) || (this.EndInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue)) &&
                    (this.StartInventUpdate_DateEdit.GetDateTime() > this.EndInventUpdate_DateEdit.GetDateTime()))
                {
                    ErrorItems.Add("最終棚卸更新日の範囲指定に誤りがあります。");
                    errControl = StartInventUpdate_DateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }
                // 最終棚卸更新日(終了)未来日付チェック
                else if ((this.EndInventUpdate_DateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.EndInventUpdate_DateEdit.GetDateTime() > TDateTime.GetSFDateNow()))
                {
                    ErrorItems.Add("最終棚卸更新日(終了)に未来日付を指定することは出来ません。");
                    errControl = EndInventUpdate_DateEdit;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }

                //else
                //{
                //    result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //}
            }
            finally
            {
                if (errControl != null)
                    errControl.Focus();
            }
            return result;
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #endregion IEntryTbsMDIChildEdit メンバ

        # region Private Methods

        #region 画面初期設定処理
        /// <summary>
		/// 画面初期設定処理
		/// </summary>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        private void InitialSetting()
		{
            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            this.tEdit_WarehouseCode_St.Size = new Size(44, 24);
            this.tEdit_WarehouseCode_Ed.Size = new Size(44, 24);
            for (int index = 0; index < this._warehouseCodeArray.Length; index++)
            {
                this._warehouseCodeArray[index].Size = new Size(44, 24);
            }
            this.tEdit_WarehouseName_St.Size = new Size(187, 24);
            this.tEdit_WarehouseName_Ed.Size = new Size(187, 24);
            //this.tEdit_WarehouseShelfNo_St.Size = new Size(76, 24); // DEL 2009/04/13
            //this.tEdit_WarehouseShelfNo_Ed.Size = new Size(76, 24); // DEL 2009/04/13
            this.tEdit_WarehouseShelfNo_St.Size = new Size(84, 24); // ADD 2009/04/13
            this.tEdit_WarehouseShelfNo_Ed.Size = new Size(84, 24); // ADD 2009/04/13
            this.tNedit_SupplierCd_St.Size = new Size(60, 24);
            this.tNedit_SupplierCd_Ed.Size = new Size(60, 24);
            this.tEdit_SupplierName_St.Size = new Size(171, 24);
            this.tEdit_SupplierName_Ed.Size = new Size(171, 24);
            this.tNedit_BLGoodsCode_St.Size = new Size(60, 24);
            this.tNedit_BLGoodsCode_Ed.Size = new Size(60, 24);
            this.tEdit_BLGoodsName_St.Size = new Size(171, 24);
            this.tEdit_BLGoodsName_Ed.Size = new Size(171, 24);
            this.tNedit_BLGloupCode_St.Size = new Size(60, 24);
            this.tNedit_BLGloupCode_Ed.Size = new Size(60, 24);
            this.tEdit_BLGloupName_St.Size = new Size(171, 24);
            this.tEdit_BLGloupName_Ed.Size = new Size(171, 24);
            this.tNedit_GoodsMakerCd_St.Size = new Size(60, 24);
            this.tNedit_GoodsMakerCd_Ed.Size = new Size(60, 24);
            this.tEdit_GoodsMakerName_St.Size = new Size(171, 24);
            this.tEdit_GoodsMakerName_Ed.Size = new Size(171, 24);
            //-----ADD 2011/01/11------>>>>>
            this.tNEdit_SectionCode_St.Size = new Size(28, 24);
            this.tNEdit_SectionCode_Ed.Size = new Size(28, 24);
            this.uLabel_SectionNm_St.Size = new Size(202, 24);
            this.uLabel_SectionNm_Ed.Size = new Size(202, 24);
            //-----ADD 2011/01/11------<<<<<
            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

            //アイコン(☆) 
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
            // 倉庫ガイド(単独指定用)
            this.WarehouseGuide_Button_Array.ImageList = imageList16;
            this.WarehouseGuide_Button_Array.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

            //倉庫ガイド
            this.WarehouseGuide_Button_St.ImageList = imageList16;
            this.WarehouseGuide_Button_Ed.ImageList = imageList16;
            this.WarehouseGuide_Button_St.Appearance.Image = Size16_Index.STAR1;           
            this.WarehouseGuide_Button_Ed.Appearance.Image = Size16_Index.STAR1;

            //-----ADD 2011/01/11------>>>>>
            this.uButton_SectionGuide_St.ImageList = imageList16;
            this.uButton_SectionGuide_Ed.ImageList = imageList16;
            this.uButton_SectionGuide_St.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionGuide_Ed.Appearance.Image = Size16_Index.STAR1;
            //-----ADD 2011/01/11------<<<<<

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            this.WarehouseGuide01_Button.ImageList = imageList16;
            this.WarehouseGuide02_Button.ImageList = imageList16;
            this.WarehouseGuide03_Button.ImageList = imageList16;
            this.WarehouseGuide04_Button.ImageList = imageList16;
            this.WarehouseGuide05_Button.ImageList = imageList16;
            this.WarehouseGuide06_Button.ImageList = imageList16;
            this.WarehouseGuide07_Button.ImageList = imageList16;
            this.WarehouseGuide08_Button.ImageList = imageList16;
            this.WarehouseGuide09_Button.ImageList = imageList16;
            this.WarehouseGuide10_Button.ImageList = imageList16;
            this.WarehouseGuide01_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide02_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide03_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide04_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide05_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide06_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide07_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide08_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide09_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide10_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
            //商品区分グループガイド
            this.St_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            this.Ed_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            this.St_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //商品区分ガイド
            this.St_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            this.Ed_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            this.St_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //メーカーガイド
            this.MakerGuide_Button_St.ImageList = imageList16;
            this.MakerGuide_Button_Ed.ImageList = imageList16;
            this.MakerGuide_Button_St.Appearance.Image = Size16_Index.STAR1;
            this.MakerGuide_Button_Ed.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            //商品区分詳細ガイド
            this.DetailGoodsGanreGuide_Button_St.ImageList = imageList16;
            this.DetailGoodsGanreGuide_Button_Ed.ImageList = imageList16;
            this.DetailGoodsGanreGuide_Button_St.Appearance.Image = Size16_Index.STAR1;
            this.DetailGoodsGanreGuide_Button_Ed.Appearance.Image = Size16_Index.STAR1;
            //仕入先ガイド
            this.SupplierGuide_Button_St.ImageList = imageList16;
            this.SupplierGuide_Button_Ed.ImageList = imageList16;
            this.SupplierGuide_Button_St.Appearance.Image = Size16_Index.STAR1;
            this.SupplierGuide_Button_Ed.Appearance.Image = Size16_Index.STAR1;

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            //自社分類ガイド
            this.St_EnterpriseGanreGuide_Button.ImageList = imageList16;
            this.Ed_EnterpriseGanreGuide_Button.ImageList = imageList16;
            this.St_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //ＢＬ商品ガイド
            this.BLGoodsGuide_Button_St.ImageList = imageList16;
            this.BLGoodsGuide_Button_Ed.ImageList = imageList16;
            this.BLGoodsGuide_Button_St.Appearance.Image = Size16_Index.STAR1;
            this.BLGoodsGuide_Button_Ed.Appearance.Image = Size16_Index.STAR1;

            // 棚卸日に当日の日付をセット
            InventoryDate_tDateEdit.SetDateTime(TDateTime.GetSFDateNow());
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // 棚卸最終更新日(終了)に当日の日付をセット
            EndInventUpdate_DateEdit.SetDateTime(TDateTime.GetSFDateNow());
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            // グリッドキーマッピング設定
            MakeKeyMappingForGrid(this.PrepareHistory_Grid);

            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
            // 倉庫範囲指定に「範囲」設定
            this.WarehouseCodeDiv_tComboEditor.Value = 0;
            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            //在庫全体設定読込み
            string messag = "";
            StockMngTtlSt stockMngTtlSt = null;
            int status = this._inventoryPrepareAcs.ReadStockMngTtlSt(out stockMngTtlSt,out messag); 

            if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // メッセージ表示
                ShowMsgDisp(
                    emErrorLevel.ERR_LEVEL_STOP,
                    messag,
                    status,
                    "InitialSetting",
                    MessageBoxButtons.OK
                );
            }
            else
            {
                this._stockPointWay = stockMngTtlSt.StockPointWay;
            }
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        }
		#endregion

		#region 画面データセット処理(棚卸準備処理抽出条件クラス)
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 画面データセット処理(棚卸準備処理抽出条件クラス←画面情報)
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2010/02/20 李占川 PM1005</br>
        /// <br>             倉庫単独指定時の障害の対応</br>
        /// </remarks>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        private void ToDataFromScreenInventoryExtCndtnWork()
		{
            // 棚卸日
            this._inventoryExtCndtnWork.InventoryDate       = this.InventoryDate_tDateEdit.GetDateTime();
            // 棚番開始
            this._inventoryExtCndtnWork.StWarehouseShelfNo  = this.tEdit_WarehouseShelfNo_St.DataText;
            // 棚番終了
            this._inventoryExtCndtnWork.EdWarehouseShelfNo  = this.tEdit_WarehouseShelfNo_Ed.DataText;
            // 仕入先コード開始
            this._inventoryExtCndtnWork.StCustomerCd = this.tNedit_SupplierCd_St.GetInt();
            // 仕入先コード終了
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdCustomerCd = 999999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdCustomerCd = this.tNedit_SupplierCd_Ed.GetInt();
            }
            if ((int)this.WarehouseCodeDiv_tComboEditor.Value == 0)
            {
                // -- UPD 2009/09/15 -------------------------------------->>>
                //// 倉庫コード(開始)
                //this._inventoryExtCndtnWork.StWarehouseCd = this.tEdit_WarehouseCode_St.DataText;
                //// 倉庫コード(終了)
                //this._inventoryExtCndtnWork.EdWarehouseCd = this.tEdit_WarehouseCode_Ed.DataText;
                // 倉庫コード(開始)
                if (this.tEdit_WarehouseCode_St.DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.StWarehouseCd = this.tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');
                }
                // --- ADD 2010/02/20 ---------->>>>>
                else
                {
                    this._inventoryExtCndtnWork.StWarehouseCd = "";
                }
                // --- ADD 2010/02/20 ----------<<<<<

                // 倉庫コード(終了)
                if (this.tEdit_WarehouseCode_Ed.DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.EdWarehouseCd = this.tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');
                }
                // --- ADD 2010/02/20 ---------->>>>>
                else
                {
                    this._inventoryExtCndtnWork.EdWarehouseCd = "";
                }
                // --- ADD 2010/02/20 ----------<<<<<

                // -- UPD 2009/09/15 --------------------------------------<<<
            }
            else
            {
                if (this._warehouseCodeArray[0].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd01 = this._warehouseCodeArray[0].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd01 = "";
                }
                if (this._warehouseCodeArray[1].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd02 = this._warehouseCodeArray[1].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd02 = "";
                }
                if (this._warehouseCodeArray[2].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd03 = this._warehouseCodeArray[2].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd03 = "";
                }
                if (this._warehouseCodeArray[3].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd04 = this._warehouseCodeArray[3].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd04 = "";
                }
                if (this._warehouseCodeArray[4].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd05 = this._warehouseCodeArray[4].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd05 = "";
                }
                if (this._warehouseCodeArray[5].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd06 = this._warehouseCodeArray[5].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd06 = "";
                }
                if (this._warehouseCodeArray[6].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd07 = this._warehouseCodeArray[6].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd07 = "";
                }
                if (this._warehouseCodeArray[7].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd08 = this._warehouseCodeArray[7].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd08 = "";
                }
                if (this._warehouseCodeArray[8].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd09 = this._warehouseCodeArray[8].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd09 = "";
                }
                if (this._warehouseCodeArray[9].DataText.Trim() != "")
                {
                    this._inventoryExtCndtnWork.WarehouseCd10 = this._warehouseCodeArray[9].DataText.Trim().PadLeft(4, '0');
                }
                else
                {
                    this._inventoryExtCndtnWork.WarehouseCd10 = "";
                }
            }

            // DEL yangyi 2012/06/14 Redmine#30282 ------------->>>>>
            //-----ADD 2011/01/11----->>>>>
            //// 開始管理拠点コード
            //this._inventoryExtCndtnWork.SectionCodeSt = this.tNEdit_SectionCode_St.DataText.Trim();
            //// 終了管理拠点コード
            //this._inventoryExtCndtnWork.SectionCodeEd = this.tNEdit_SectionCode_Ed.DataText.Trim();
            //-----ADD 2011/01/11-----<<<<<
            // DEL yangyi 2012/06/14 Redmine#30282 -------------<<<<<
            // ADD yangyi 2012/06/14 Redmine#30282 ------------->>>>>
            // 開始管理拠点コード
            if (string.IsNullOrEmpty(this.tNEdit_SectionCode_St.DataText.Trim()) )
            {
                _inventoryExtCndtnWork.SectionCodeSt = "0";
            }
            else
            {
                _inventoryExtCndtnWork.SectionCodeSt = this.tNEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
            }
            // 終了管理拠点コード
            if (string.IsNullOrEmpty(this.tNEdit_SectionCode_Ed.DataText.Trim()))
            {
                _inventoryExtCndtnWork.SectionCodeEd = "99";
            }
            else
            {
                _inventoryExtCndtnWork.SectionCodeEd = this.tNEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
            }
            if (_inventoryExtCndtnWork.SectionCodeSt == "00")
            {
                _inventoryExtCndtnWork.SectionCodeSt = "0";
            }
            if (((_inventoryExtCndtnWork.SectionCodeSt =="0") || (_inventoryExtCndtnWork.SectionCodeSt=="00" )) && 
                ((_inventoryExtCndtnWork.SectionCodeEd == "00") ||(_inventoryExtCndtnWork.SectionCodeEd == "0"))) 
            {
                _inventoryExtCndtnWork.SectionCodeSt = string.Empty;
            }

            // ADD yangyi 2012/06/14 Redmine#30282 -------------<<<<<

            // メーカーコード(開始)
            this._inventoryExtCndtnWork.StMakerCd           = this.tNedit_GoodsMakerCd_St.GetInt();
            // メーカーコード(終了)
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdMakerCd = 9999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
            }
            // グループコード開始
            this._inventoryExtCndtnWork.StBLGroupCode    = this.tNedit_BLGloupCode_St.GetInt();
            // グループコード終了
            if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdBLGroupCode = 99999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdBLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
            }
            // ＢＬコード(開始)
            this._inventoryExtCndtnWork.StBLGoodsCd         = this.tNedit_BLGoodsCode_St.GetInt();
            // ＢＬコード(終了)
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdBLGoodsCd = 99999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdBLGoodsCd = this.tNedit_BLGoodsCode_Ed.GetInt();
            }

            // 在庫評価方法
            this._inventoryExtCndtnWork.StockPointWay = this._stockMngTtlSt.StockPointWay;

            // --- ADD 2009/11/30 ---------->>>>>
            //棚卸印刷順初期設定区分
            this._inventoryExtCndtnWork.InvntryPrtOdrIniDiv = this._stockMngTtlStLogin.InvntryPrtOdrIniDiv;

            //棚卸運用区分
            this._inventoryExtCndtnWork.InventoryMngDiv = this._stockMngTtlSt.InventoryMngDiv;
            // --- ADD 2009/11/30 ----------<<<<<
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面データセット処理(棚卸準備処理抽出条件クラス←画面情報)
        /// </summary>
        private void ToDataFromScreenInventoryExtCndtnWork()
        {
            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            //棚卸日
            this._inventoryExtCndtnWork.InventoryDate = this.InventoryDate_tDateEdit.GetDateTime();
            //棚番開始
            this._inventoryExtCndtnWork.StWarehouseShelfNo = this.StartShelfNo_tEdit.DataText;
            //棚番終了
            this._inventoryExtCndtnWork.EdWarehouseShelfNo = this.EndShelfNo_tEdit.DataText;
            //仕入先コード開始
            this._inventoryExtCndtnWork.StCustomerCd = this.tNedit_SupplierCd_St.GetInt();
            //仕入先コード終了
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryExtCndtnWork.EdCustomerCd = this.tNedit_SupplierCd_Ed.GetInt();
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdCustomerCd = 999999999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdCustomerCd = this.tNedit_SupplierCd_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
            //倉庫コード(開始)
            this._inventoryExtCndtnWork.StWarehouseCd = this.tEdit_WarehouseCode_St.DataText;
            //倉庫コード(終了)
            this._inventoryExtCndtnWork.EdWarehouseCd = this.tEdit_WarehouseCode_Ed.DataText;
            //メーカーコード(開始)
            this._inventoryExtCndtnWork.StMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
            //メーカーコード(終了)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryExtCndtnWork.EdMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdMakerCd = 999999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            //商品区分グループコード(開始)
            this._inventoryExtCndtnWork.StLgGoodsGanreCd = this.StartLargeGoodsGanreCode_tEdit.DataText;
            //商品区分グループコード(終了)
            this._inventoryExtCndtnWork.EdLgGoodsGanreCd = this.EndLargeGoodsGanreCode_tEdit.DataText;
            //商品区分コード(開始)
            this._inventoryExtCndtnWork.StMdGoodsGanreCd = this.StartMediumGoodsGanreCode_tEdit.DataText;
            //商品区分コード(終了)
            this._inventoryExtCndtnWork.EdMdGoodsGanreCd = this.EndMediumGoodsGanreCode_tEdit.DataText;
            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            ////機種コード(開始)
            //this._inventoryExtCndtnWork.StCellphoneModelCd  = this.St_CellphoneModelCode_tEdit.DataText;
            ////機種コード(終了)
            //this._inventoryExtCndtnWork.EdCellphoneModelCd  = this.Ed_CellphoneModelCode_tEdit.DataText;
            ////商品コード(開始)
            //this._inventoryExtCndtnWork.StGoodsCd = this.StartGoodsCode_tNedit.DataText;
            ////商品コード(終了)
            //this._inventoryExtCndtnWork.EdGoodsCd = this.EndGoodsCode_tNedit.DataText;
            //商品区分詳細コード開始
            this._inventoryExtCndtnWork.StDtGoodsGanreCd = this.tNedit_BLGloupCode_St.DataText;
            //商品区分詳細コード終了
            this._inventoryExtCndtnWork.EdDtGoodsGanreCd = this.tNedit_BLGloupCode_Ed.DataText;
            //ＢＬコード(開始)
            this._inventoryExtCndtnWork.StBLGoodsCd = this.tNedit_BLGoodsCode_St.GetInt();
            //ＢＬコード(終了)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryExtCndtnWork.EdBLGoodsCd = this.tNedit_BLGoodsCode_Ed.GetInt();
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdBLGoodsCd = 99999999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdBLGoodsCd = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            //自社分類コード(開始)
            this._inventoryExtCndtnWork.StEnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();
            //自社分類コード(終了)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryExtCndtnWork.EdCmpClassificationCd = this.EndEnterpriseGanreCode_tNedit.GetInt();
            if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
            {
                this._inventoryExtCndtnWork.EdEnterpriseGanreCode = 9999;
            }
            else
            {
                this._inventoryExtCndtnWork.EdEnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            ////商品種別
            ////一般
            //if(this.GoodsKind1_ultraCheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.GeneralGoodsExtDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.GeneralGoodsExtDiv = 1;
            //}
            ////携帯電話
            //if(this.GoodsKind2_ultraCheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.MobileGoodsExtDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.MobileGoodsExtDiv = 1;
            //}
            ////付属品
            //if(this.GoodsKind3_ultraCheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.AcsryGoodsExtDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.AcsryGoodsExtDiv = 1;
            //}           
            //
            ////自社在庫抽出区分
            //if(this.CmpStockDiv_CheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.CmpStkExtraDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.CmpStkExtraDiv = 1;
            //}
            ////受託在庫抽出区分
            //if(this.TrsStockDiv_CheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.TrtStkExtraDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.TrtStkExtraDiv = 1;
            //}
            ////委託(自社)在庫抽出区分
            //if(this.EntrustCmpStockDiv_CheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.EntCmpStkExtraDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.EntCmpStkExtraDiv = 1;
            //}
            ////委託(受託)在庫抽出区分
            //if(this.EntrustTrsStockDiv_CheckEditor.Checked)
            //{
            //    //抽出する
            //    this._inventoryExtCndtnWork.EntTrtStkExtraDiv = 0;
            //}
            //else
            //{
            //    //抽出しない
            //    this._inventoryExtCndtnWork.EntTrtStkExtraDiv = 1;
            //}
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<

            //最終棚卸更新日開始
            this._inventoryExtCndtnWork.StLtInventoryUpdate = this.StartInventUpdate_DateEdit.GetDateTime();
            //最終棚卸更新日終了
            this._inventoryExtCndtnWork.EdLtInventoryUpdate = this.EndInventUpdate_DateEdit.GetDateTime();
            //在庫評価方
            this._inventoryExtCndtnWork.StockPointWay = this._stockPointWay;
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region 画面データセット処理
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 棚卸検索条件設定処理(棚卸検索条件クラス←棚卸準備処理抽出条件クラス)
		/// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸検索条件を設定します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
	    /// <br>Date       : 2008/08/28</br>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        /// </remarks>
        private void ToInventInputSearchCndtnWorkFromScreen(ref InventInputSearchCndtnWork inventInputSearchCndtnWork)
        {
            // このタイミングでthis._inventoryExtCndtnWorkには最新の画面情報がセットされているので使用
            inventInputSearchCndtnWork.EnterpriseCode = this._inventoryExtCndtnWork.EnterpriseCode;                 // 企業コード
            //inventInputSearchCndtnWork.St_SectionCode = ;                       // 拠点コード
            //inventInputSearchCndtnWork.Ed_SectionCode = ;                       // 拠点コード
            inventInputSearchCndtnWork.St_MakerCode = this._inventoryExtCndtnWork.StMakerCd;                        // メーカーコード開始
            inventInputSearchCndtnWork.Ed_MakerCode = this._inventoryExtCndtnWork.EdMakerCd;                        // メーカーコード終了
            //inventInputSearchCndtnWork.St_GoodsNo = ;   // 品番開始
            //inventInputSearchCndtnWork.Ed_GoodsNo = ;   // 品番終了
            inventInputSearchCndtnWork.WarehouseDiv = (int)this.WarehouseCodeDiv_tComboEditor.Value;    // 倉庫指定区分
            if (inventInputSearchCndtnWork.WarehouseDiv == 0)
            {
                // 範囲指定
                inventInputSearchCndtnWork.St_WarehouseCode = this._inventoryExtCndtnWork.StWarehouseCd;                // 倉庫コード開始
                inventInputSearchCndtnWork.Ed_WarehouseCode = this._inventoryExtCndtnWork.EdWarehouseCd;                // 倉庫コード終了
            }
            else
            {
                // 単独指定
                inventInputSearchCndtnWork.WarehouseCd01 = this.tEdit_WarehouseCode_01.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd02 = this.tEdit_WarehouseCode_02.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd03 = this.tEdit_WarehouseCode_03.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd04 = this.tEdit_WarehouseCode_04.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd05 = this.tEdit_WarehouseCode_05.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd06 = this.tEdit_WarehouseCode_06.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd07 = this.tEdit_WarehouseCode_07.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd08 = this.tEdit_WarehouseCode_08.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd09 = this.tEdit_WarehouseCode_09.DataText.Trim();
                inventInputSearchCndtnWork.WarehouseCd10 = this.tEdit_WarehouseCode_10.DataText.Trim();
            }
            //-----ADD 2011/01/11----->>>>>
            inventInputSearchCndtnWork.St_SectionCode = this.tNEdit_SectionCode_St.DataText.Trim();                       // 拠点コード
            inventInputSearchCndtnWork.Ed_SectionCode = this.tNEdit_SectionCode_Ed.DataText.Trim();                       // 拠点コード
            //-----ADD 2011/01/11-----<<<<<

            inventInputSearchCndtnWork.St_WarehouseShelfNo = this._inventoryExtCndtnWork.StWarehouseShelfNo;        // 棚番開始
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = this._inventoryExtCndtnWork.EdWarehouseShelfNo;        // 棚番終了
            //inventInputSearchCndtnWork.St_EnterpriseGanreCode = this._inventoryExtCndtnWork.StEnterpriseGanreCode;  // 自社分類コード開始
            //inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = this._inventoryExtCndtnWork.EdEnterpriseGanreCode;  // 自社分類コード終了
            inventInputSearchCndtnWork.St_BLGoodsCode = this._inventoryExtCndtnWork.StBLGoodsCd;                    // ＢＬ商品コード開始
            inventInputSearchCndtnWork.Ed_BLGoodsCode = this._inventoryExtCndtnWork.EdBLGoodsCd;                    // ＢＬ商品コード終了
            inventInputSearchCndtnWork.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();                                                     // 仕入先コード開始
            inventInputSearchCndtnWork.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();                                             // 仕入先コード終了
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;                                    // 開始棚卸準備処理日付
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;                                    // 終了棚卸準備処理日付
            
            //inventInputSearchCndtnWork.InventoryDate = this._inventoryExtCndtnWork.InventoryDate;                   // 棚卸日     //DEL 2009/05/21 リモートに渡す条件変更
            inventInputSearchCndtnWork.InventoryDate = DateTime.MinValue;                                           // 棚卸日       //ADD 2009/05/21

            inventInputSearchCndtnWork.St_InventorySeqNo = 0;                                                       // 開始棚卸通番
            inventInputSearchCndtnWork.Ed_InventorySeqNo = 999999;                                                  // 終了棚卸通番    
            inventInputSearchCndtnWork.St_BLGroupCode = this._inventoryExtCndtnWork.StBLGroupCode;      // グループコード開始
            inventInputSearchCndtnWork.Ed_BLGroupCode = this._inventoryExtCndtnWork.EdBLGroupCode;      // グループコード終了
            inventInputSearchCndtnWork.DifCntExtraDiv = 0;       　                                                 // 差異分出力区分 0:全て 1:差異分のみ
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;                                                   // 棚卸数０印字区分 0:印字する,1:印字しない

            //inventInputSearchCndtnWork.SelectedPaperKind = 0;   　                                                  // 帳票種類 0:棚卸記入表,1:棚卸差異表,2:棚卸表    //DEL 2009/05/21 リモートに渡す条件変更
            inventInputSearchCndtnWork.SelectedPaperKind = -1;   　                                                  // 帳票種類 0:棚卸記入表,1:棚卸差異表,2:棚卸表     //ADD 2009/05/21
            
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;                                                    // 在庫数０印字区分 0:印字する,1:印字しない

            //inventInputSearchCndtnWork.TargetDateExtraDiv   = 0;                                                    // 抽出対象日区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日  //DEL 2009/05/21 リモートに渡す条件変更
            inventInputSearchCndtnWork.TargetDateExtraDiv = -1;                                                    // 抽出対象日区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日     //ADD 2009/05/21

            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;                                                     // 在庫数算出フラグ 0:在庫数算出しない,1:在庫数算出する
            inventInputSearchCndtnWork.CalcStockAmountDate = this._inventoryExtCndtnWork.InventoryDate;             // 在庫数算出日付
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面データセット処理(棚卸検索条件クラス←棚卸準備処理抽出条件クラス)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸検索条件クラスに画面情報をセットします</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private void ToInventInputSearchCndtnWorkFromScreen(ref InventInputSearchCndtnWork inventInputSearchCndtnWork)
        {
            //このタイミングでthis._inventoryExtCndtnWorkには最新の画面情報がセットされているので使用数
            inventInputSearchCndtnWork.EnterpriseCode = this._inventoryExtCndtnWork.EnterpriseCode;  // 企業コード
            inventInputSearchCndtnWork.SectionCode = this._inventoryExtCndtnWork.SectionCode;  // 拠点コード
            inventInputSearchCndtnWork.St_MakerCode = this._inventoryExtCndtnWork.StMakerCd;  // メーカーコード開始
            inventInputSearchCndtnWork.Ed_MakerCode = this._inventoryExtCndtnWork.EdMakerCd;  // メーカーコード終了
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.St_GoodsCode = this._inventoryExtCndtnWork.StGoodsCd;  // 商品コード開始
            //inventInputSearchCndtnWork.Ed_GoodsCode = this._inventoryExtCndtnWork.EdGoodsCd;  // 商品コード終了
            //inventInputSearchCndtnWork.St_CellphoneModelCode = this._inventoryExtCndtnWork.StCellphoneModelCd;  // 機種コード開始
            //inventInputSearchCndtnWork.Ed_CellphoneModelCode = this._inventoryExtCndtnWork.EdCellphoneModelCd;  // 機種コード終了
            //inventInputSearchCndtnWork.St_CarrierCode        = this._inventoryExtCndtnWork.StCarrierCd;  // キャリアコード開始
            //inventInputSearchCndtnWork.Ed_CarrierCode        = this._inventoryExtCndtnWork.EdCarrierCd;  // キャリアコード終了
            inventInputSearchCndtnWork.St_BLGoodsCode = this._inventoryExtCndtnWork.StBLGoodsCd;  // ＢＬ商品コード開始
            inventInputSearchCndtnWork.Ed_BLGoodsCode = this._inventoryExtCndtnWork.EdBLGoodsCd;  // ＢＬ商品コード終了
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_LargeGoodsGanreCode = this._inventoryExtCndtnWork.StLgGoodsGanreCd;  // 商品区分グループコード開始
            inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode = this._inventoryExtCndtnWork.EdLgGoodsGanreCd;  // 商品区分グループコード終了
            inventInputSearchCndtnWork.St_MediumGoodsGanreCode = this._inventoryExtCndtnWork.StMdGoodsGanreCd;  // 商品区分コード開始
            inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode = this._inventoryExtCndtnWork.EdMdGoodsGanreCd;  // 商品区分コード終了
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            inventInputSearchCndtnWork.St_DetailGoodsGanreCode = this._inventoryExtCndtnWork.StDtGoodsGanreCd;  // 商品区分詳細コード開始
            inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode = this._inventoryExtCndtnWork.EdDtGoodsGanreCd;  // 商品区分詳細コード終了
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = this._inventoryExtCndtnWork.StEnterpriseGanreCode;  // 自社分類コード開始
            inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = this._inventoryExtCndtnWork.EdEnterpriseGanreCode;  // 自社分類コード終了
            inventInputSearchCndtnWork.St_WarehouseShelfNo = this._inventoryExtCndtnWork.StWarehouseShelfNo; // 棚番開始
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = this._inventoryExtCndtnWork.EdWarehouseShelfNo; // 棚番終了
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_WarehouseCode = this._inventoryExtCndtnWork.StWarehouseCd;  // 倉庫コード開始
            inventInputSearchCndtnWork.Ed_WarehouseCode = this._inventoryExtCndtnWork.EdWarehouseCd;  // 倉庫コード終了
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.CompanyStockExtraDiv = this._inventoryExtCndtnWork.CmpStkExtraDiv;  // 自社在庫抽出区分
            //inventInputSearchCndtnWork.TrustStockExtraDiv = this._inventoryExtCndtnWork.TrtStkExtraDiv;  // 受託在庫抽出区分
            //inventInputSearchCndtnWork.EntrustCmpStockExtraDiv = this._inventoryExtCndtnWork.EntCmpStkExtraDiv;  // 委託（自社）在庫抽出区分
            //inventInputSearchCndtnWork.EntrustTrtStockExtraDiv = this._inventoryExtCndtnWork.EntTrtStkExtraDiv;  // 委託（受託）在庫抽出区分
            //inventInputSearchCndtnWork.St_CarrierEpCode = 0;  // 事業者コード開始
            //inventInputSearchCndtnWork.Ed_CarrierEpCode = 9999;  // 事業者コード終了
            //inventInputSearchCndtnWork.St_CustomerCode = 0;  // 得意先コード開始
            //inventInputSearchCndtnWork.Ed_CustomerCode = 999999999;  // 得意先コード終了
            inventInputSearchCndtnWork.St_CustomerCode = this._inventoryExtCndtnWork.StCustomerCd; // 得意先コード開始
            inventInputSearchCndtnWork.Ed_CustomerCode = this._inventoryExtCndtnWork.EdCustomerCd; // 得意先コード終了
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_ShipCustomerCode = 0;     //出荷先得意先コード開始
            inventInputSearchCndtnWork.Ed_ShipCustomerCode = 999999999; //出荷先得意先コード終了
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;  // 開始棚卸準備処理日付
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;  // 終了棚卸準備処理日付
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.St_InventoryDay = DateTime.MinValue;  // 開始棚卸実施日
            //inventInputSearchCndtnWork.Ed_InventoryDay = DateTime.MinValue;  // 終了棚卸実施日
            inventInputSearchCndtnWork.InventoryDate = this._inventoryExtCndtnWork.InventoryDate;   // 棚卸日
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_InventorySeqNo = 0;       // 開始棚卸通番
            inventInputSearchCndtnWork.Ed_InventorySeqNo = 999999;  // 終了棚卸通番          
            // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.GrossPrintDiv = 0;           //集計単位 0:商品,1:製番
            // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.DifCntExtraDiv = 0;       　 //差異分出力区分 0:全て 1:差異分のみ
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;   //棚卸数０印字区分 0:印字する,1:印字しない
            inventInputSearchCndtnWork.SelectedPaperKind = 0;   　  //帳票種類 0:棚卸記入表,1:棚卸差異表,2:棚卸表
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;    //在庫数０印字区分 0:印字する,1:印字しない
            inventInputSearchCndtnWork.TargetDateExtraDiv = 0;    //抽出対象日区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;     //在庫数算出フラグ 0:在庫数算出しない,1:在庫数算出する
            inventInputSearchCndtnWork.CalcStockAmountDate = this._inventoryExtCndtnWork.InventoryDate; //在庫数算出日付
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region 初回棚卸データ検索用条件セット処理
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 初回棚卸データ検索用条件セット処理
		/// </summary>
        /// <remarks>
        /// <br>Note       : 初回棚卸データ検索用条件をセットします</br>
		/// <br>Programmer : 30414 忍 幸史</br>
	    /// <br>Date       : 2008/08/28</br>
        /// </remarks>
        private void SetConditionForFirstSearch(ref InventInputSearchCndtnWork inventInputSearchCndtnWork)
        {
            //
            // 画面の初期値を利用
            //

            // 企業コード
            inventInputSearchCndtnWork.EnterpriseCode = this._enterpriseCode;
            //// 拠点コード(開始)
            //inventInputSearchCndtnWork.St_SectionCode = this.tEdit_SectionCode_St.DataText.Trim();
            //// 拠点コード(終了)
            //if (this.tEdit_SectionCode_Ed.DataText.Trim() == "")
            //{
            //    inventInputSearchCndtnWork.Ed_SectionCode = "99";
            //}
            //else
            //{
            //    inventInputSearchCndtnWork.Ed_SectionCode = this.tEdit_SectionCode_Ed.DataText.Trim();
            //}
            // 倉庫コード(開始)
            inventInputSearchCndtnWork.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.Trim();
            // 倉庫コード(終了)
            //if (this.tEdit_WarehouseCode_Ed.DataText.Trim() == "")
            //{
            //    inventInputSearchCndtnWork.Ed_WarehouseCode = "9999";
            //}
            //else
            //{
            //    inventInputSearchCndtnWork.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim();
            //}
            inventInputSearchCndtnWork.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim();
            // 棚番(開始)
            inventInputSearchCndtnWork.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText;
            // 棚番(終了)
            //if (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() == "")
            //{
            //    inventInputSearchCndtnWork.Ed_WarehouseShelfNo = "99999999";
            //}
            //else
            //{
            //    inventInputSearchCndtnWork.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText;
            //}
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText;
            // 仕入先コード(開始)
            inventInputSearchCndtnWork.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
            // 仕入先コード(終了)
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_SupplierCd = 999999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
            }
            // ＢＬコード(開始)
            inventInputSearchCndtnWork.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
            // ＢＬコード(終了)
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_BLGoodsCode = 99999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            // グループコード(開始)
            inventInputSearchCndtnWork.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
            // グループコード(終了)
            if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_BLGroupCode = 99999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
            }
            // メーカーコード(開始)
            inventInputSearchCndtnWork.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();
            // メーカーコード(終了)
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_MakerCode = 9999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
            }
            // 開始棚卸準備処理日付
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;
            // 終了棚卸準備処理日付
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;
            // ---DEL 2009/05/21 リモートに渡す条件変更 ------------------------------------------->>>>>
            //// 棚卸日
            //if (targetDelDate == 0)
            //{
            //    inventInputSearchCndtnWork.InventoryDate = this.InventoryDate_tDateEdit.GetDateTime();  
            //}
            //else
            //{
            //    inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(targetDelDate);
            //}
            // ---DEL 2009/05/21 リモートに渡す条件変更 -------------------------------------------<<<<<
            // 棚卸日
            inventInputSearchCndtnWork.InventoryDate = DateTime.MinValue;       //ADD 2009/05/21

            // 開始棚卸通番
            inventInputSearchCndtnWork.St_InventorySeqNo = 0;
            // 終了棚卸通番
            inventInputSearchCndtnWork.Ed_InventorySeqNo = 999999;
            // 差異分出力区分  0:全て 1:差異分のみ
            inventInputSearchCndtnWork.DifCntExtraDiv = 0;
            // 棚卸数０印字区分  0:印字する,1:印字しない
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;   
            // 帳票種類  0:棚卸記入表,1:棚卸差異表,2:棚卸表(帳票種別に関する影響を受けないようにする為、帳票区分に-1をセット)
            inventInputSearchCndtnWork.SelectedPaperKind = -1;
            // 在庫数０印字区分  0:印字する,1:印字しない
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;
            // 抽出対象日区分  0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日
            //inventInputSearchCndtnWork.TargetDateExtraDiv   = 0;              //DEL 2009/05/21　リモートに渡す条件変更
            inventInputSearchCndtnWork.TargetDateExtraDiv = -1;                 //ADD 2009/05/21
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初回棚卸データ検索用条件セット処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初回棚卸データ検索用条件をセットします</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private void SetConditionForFirstSearch(ref InventInputSearchCndtnWork inventInputSearchCndtnWork)
        {
            //画面の初期値を利用
            inventInputSearchCndtnWork.EnterpriseCode = this._enterpriseCode;  // 企業コード
            inventInputSearchCndtnWork.SectionCode = this._loginSectionCode;  // 拠点コード
            inventInputSearchCndtnWork.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();  // メーカーコード開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();  // メーカーコード終了
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_MakerCode = 999999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.St_GoodsCode = this.StartGoodsCode_tNedit.DataText;  // 商品コード開始
            //inventInputSearchCndtnWork.Ed_GoodsCode = this.EndGoodsCode_tNedit.DataText;  // 商品コード終了
            //inventInputSearchCndtnWork.St_CellphoneModelCode = this.St_CellphoneModelCode_tEdit.DataText;  // 機種コード開始
            //inventInputSearchCndtnWork.Ed_CellphoneModelCode = this.Ed_CellphoneModelCode_tEdit.DataText;  // 機種コード終了
            //inventInputSearchCndtnWork.St_CarrierCode        = this.tNedit_SupplierCd_St.GetInt();  // キャリアコード開始
            //inventInputSearchCndtnWork.Ed_CarrierCode        = this.tNedit_SupplierCd_Ed.GetInt();  // キャリアコード終了
            inventInputSearchCndtnWork.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();  // ＢＬコード開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();  // ＢＬコード終了
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_BLGoodsCode = 99999999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_LargeGoodsGanreCode = this.StartLargeGoodsGanreCode_tEdit.DataText;  // 商品区分グループコード開始
            inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode = this.EndLargeGoodsGanreCode_tEdit.DataText;  // 商品区分グループコード終了
            inventInputSearchCndtnWork.St_MediumGoodsGanreCode = this.StartMediumGoodsGanreCode_tEdit.DataText;  // 商品区分コード開始
            inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode = this.EndMediumGoodsGanreCode_tEdit.DataText;  // 商品区分コード終了
            inventInputSearchCndtnWork.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;  // 倉庫コード開始
            inventInputSearchCndtnWork.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;  // 倉庫コード終了
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            inventInputSearchCndtnWork.St_WarehouseShelfNo = this.StartShelfNo_tEdit.DataText;  // 棚番開始
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = this.EndShelfNo_tEdit.DataText;  // 棚番終了
            inventInputSearchCndtnWork.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.DataText;  // 商品区分詳細コード開始
            inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.DataText;  // 商品区分詳細コード終了
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();  // 自社分類コード開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();  // 自社分類コード終了
            if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = 9999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
            ////自社在庫抽出区分          
            ////抽出する
            //inventInputSearchCndtnWork.CompanyStockExtraDiv = 0;
            //
            ////受託在庫抽出区分           
            ////抽出する
            //inventInputSearchCndtnWork.TrustStockExtraDiv = 0;
            ////委託(自社)在庫抽出区分        
            ////抽出する
            //inventInputSearchCndtnWork.EntrustCmpStockExtraDiv = 0;         
            ////委託(受託)在庫抽出区分           
            ////抽出する
            //inventInputSearchCndtnWork.EntrustTrtStockExtraDiv = 0;
            // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.St_CarrierEpCode = 0;  // 事業者コード開始
            //inventInputSearchCndtnWork.Ed_CarrierEpCode = 9999;  // 事業者コード終了
            //inventInputSearchCndtnWork.St_CustomerCode = 0;  // 得意先コード開始
            //inventInputSearchCndtnWork.Ed_CustomerCode = 999999999;  // 得意先コード終了
            inventInputSearchCndtnWork.St_CustomerCode = this.tNedit_SupplierCd_St.GetInt();  // 得意先コード開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.Ed_CustomerCode = this.tNedit_SupplierCd_Ed.GetInt();  // 得意先コード終了
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtnWork.Ed_CustomerCode = 999999999;
            }
            else
            {
                inventInputSearchCndtnWork.Ed_CustomerCode = this.tNedit_SupplierCd_Ed.GetInt();
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_ShipCustomerCode = 0;     //出荷先得意先コード開始
            inventInputSearchCndtnWork.Ed_ShipCustomerCode = 999999999; //出荷先得意先コード終了
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;  // 開始棚卸準備処理日付
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;  // 終了棚卸準備処理日付
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.St_InventoryDay = DateTime.MinValue;  // 開始棚卸実施日
            //inventInputSearchCndtnWork.Ed_InventoryDay = DateTime.MinValue;  // 終了棚卸実施日
            if (targetDelDate == 0)
                inventInputSearchCndtnWork.InventoryDate = this.InventoryDate_tDateEdit.GetDateTime();  // 棚卸日
            else
                inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(targetDelDate); // 棚卸日
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.St_InventorySeqNo = 0;       // 開始棚卸通番
            inventInputSearchCndtnWork.Ed_InventorySeqNo = 999999;  // 終了棚卸通番          
            // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtnWork.GrossPrintDiv = 0;           //集計単位 0:商品,1:製番
            // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
            inventInputSearchCndtnWork.DifCntExtraDiv = 0;       　 //差異分出力区分 0:全て 1:差異分のみ
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;   //棚卸数０印字区分 0:印字する,1:印字しない
            //2007.07.20 H.NAKAMURA ADD
            //帳票種別に関する影響を受けないようにする為、帳票区分に-1をセット
            inventInputSearchCndtnWork.SelectedPaperKind = -1;      //帳票種類 0:棚卸記入表,1:棚卸差異表,2:棚卸表
            //inventInputSearchCndtnWork.SelectedPaperKind = 0;   　//帳票種類 0:棚卸記入表,1:棚卸差異表,2:棚卸表
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;    //在庫数０印字区分 0:印字する,1:印字しない
            inventInputSearchCndtnWork.TargetDateExtraDiv = 0;    //抽出対象日区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region グリッド更新処理
        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// グリッド更新処理
		/// </summary>
		/// <param name="dataTable">データテーブル</param>
		private void UpdateGridPrepareHistory(DataTable dataTable)
		{
			UltraGrid grid = this.PrepareHistory_Grid;

			for (int ix = 0; ix < dataTable.Rows.Count; ix++)
			{
				DataRow dr = dataTable.Rows[ix];

                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprDate	].Value = dr[InventoryPrepareAcs.ctInventoryPreprDate	];  //棚卸処理日
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprTime	].Value = dr[InventoryPrepareAcs.ctInventoryPreprTime	];  //棚卸処理時間
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctGoodsKind			    ].Value = dr[InventoryPrepareAcs.ctGoodsKind			];  //商品種別
                // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
                //grid.Rows[ix].Cells[InventoryPrepareAcs.ctCarrierName         ].Value = dr[InventoryPrepareAcs.ctCarrierName          ];　//キャリア名称
                //grid.Rows[ix].Cells[InventoryPrepareAcs.ctCellphoneModelCode	].Value = dr[InventoryPrepareAcs.ctCellphoneModelCode	];  //機種コード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryDate         ].Value = dr[InventoryPrepareAcs.ctInventoryDate        ];  //棚卸日
                // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctGoodsCode             ].Value = dr[InventoryPrepareAcs.ctGoodsCode            ];  //商品コード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctLargeGoodsCode    	].Value = dr[InventoryPrepareAcs.ctLargeGoodsCode   	];  //商品区分グループコード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctMediumGoodsCode   	].Value = dr[InventoryPrepareAcs.ctMediumGoodsCode  	];  //商品区分コード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctLastInventoryUpd		].Value = dr[InventoryPrepareAcs.ctLastInventoryUpd 	];  //最終棚卸更新日
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctMakerCode     		].Value = dr[InventoryPrepareAcs.ctMakerCode    		];  //メーカーコード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctStockExtraDiv			].Value = dr[InventoryPrepareAcs.ctStockExtraDiv		];  //在庫抽出区分
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctWareHouseCode 		].Value = dr[InventoryPrepareAcs.ctWareHouseCode    	];  //倉庫コード
			}

			grid.Refresh();
		}
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド更新処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private void UpdateGridPrepareHistory(DataTable dataTable)
        {
            UltraGrid grid = this.PrepareHistory_Grid;

            for (int ix = 0; ix < dataTable.Rows.Count; ix++)
            {
                DataRow dr = dataTable.Rows[ix];

                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprDate].Value = dr[InventoryPrepareAcs.ctInventoryPreprDate];     // 処理日
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryPreprTime].Value = dr[InventoryPrepareAcs.ctInventoryPreprTime];     // 処理時間
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryProcDiv].Value = dr[InventoryPrepareAcs.ctInventoryProcDiv];         // 処理区分
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryDate].Value = dr[InventoryPrepareAcs.ctInventoryDate];               // 棚卸日
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctInventoryDate_Int].Value = dr[InventoryPrepareAcs.ctInventoryDate_Int];       // 棚卸実施日
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctWareHouseCode].Value = dr[InventoryPrepareAcs.ctWareHouseCode];               // 倉庫コード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctMngSectionCode].Value = dr[InventoryPrepareAcs.ctMngSectionCode];             // 管理拠点//ADD 2011/01/30
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctShelfNo].Value = dr[InventoryPrepareAcs.ctShelfNo];                           // 棚番
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctSupplierCode].Value = dr[InventoryPrepareAcs.ctSupplierCode];                 // 仕入先
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctBLGoodsCode].Value = dr[InventoryPrepareAcs.ctBLGoodsCode];                   // BLコード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctBLGroupCode].Value = dr[InventoryPrepareAcs.ctBLGroupCode];                   // グループコード
                grid.Rows[ix].Cells[InventoryPrepareAcs.ctMakerCode].Value = dr[InventoryPrepareAcs.ctMakerCode];                       // メーカーコード
            }

            grid.Refresh();
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
        #endregion

		#region グリッドキーマッピング設定
		/// <summary>
		/// グリッドキーマッピング設定
		/// </summary>
		/// <param name="grid">設定対象グリッド</param>
		private void MakeKeyMappingForGrid(UltraGrid grid)
		{
			GridKeyActionMapping enterMap;

			// Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.NextCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// Shift + Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.PrevCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.AltCtrl,
				SpecialKeys.Shift);
			grid.KeyActionMappings.Add(enterMap);

			// ↑キー
			enterMap = new GridKeyActionMapping(Keys.Up,
				UltraGridAction.AboveCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// ↓キー
			enterMap  = new GridKeyActionMapping(Keys.Down,
				UltraGridAction.BelowCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 前頁キー
			enterMap  = new GridKeyActionMapping(Keys.Prior,
				UltraGridAction.PageUpCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 次頁キー
			enterMap  = new GridKeyActionMapping(Keys.Next,
				UltraGridAction.PageDownCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);
		}
		#endregion

		#region グリッド描画設定
		/// <summary>
		/// グリッド描画設定
		/// </summary>
		private void PrepareHistoryGridDisp()
		{
			// この処理は、グリッドにデータをバインドしてプロパティの設定を全て終えた後に行う。
			// グリッドの設定をする前にこの処理を行うと設定が無効化される。
			// グリッド設定情報取得
			GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.PrepareHistory_Grid);

			if (gridStateInfo != null)
			{
				// グリッド設定
				this._gridStateController.SetGridStateToGrid(ref this.PrepareHistory_Grid);
				this.FontSize_tComboEditor.Value = (int)gridStateInfo.FontSize;
				this.ckdDepositAutoColumnSize.Checked = gridStateInfo.AutoFit;
                
                /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
                //TODO:
                //更新処理ができていないので最終棚卸更新日を非表示にしておく
                PrepareHistory_Grid.DisplayLayout.Bands[0].Columns[InventoryPrepareAcs.ctLastInventoryUpd].Hidden = true;
                   --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
            }
			else
			{
				this.FontSize_tComboEditor.Value = 11;
				this.ckdDepositAutoColumnSize.Checked = false;
			}
		}
		#endregion

		#region グリッド表示列サイズ変更処理
		/// <summary>
		/// グリッド表示列サイズ変更処理
		/// </summary>
		private void DepositGridColumnSizeChange(object parameter)
		{		
			bool check = (bool)parameter;

			// グリッド列幅のオート設定
			if (check == true)
			{
				this.PrepareHistory_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
				return;
			}
			else
			{
				this.PrepareHistory_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
			}

			// 列幅の調整
			try
			{
				this.PrepareHistory_Grid.BeginUpdate();

				for (int i = 0; i < this.PrepareHistory_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.PrepareHistory_Grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(PerformAutoSizeType.VisibleRows, true);
				}
			}
			finally
			{
				this.PrepareHistory_Grid.EndUpdate();
				this.Cursor = Cursors.Default;
			}
		}
		#endregion			

		#region 更新前重複確認処理

		/// <summary>
		/// 更新前重複確認処理
		/// </summary>
		/// <returns>Status(リモートに失敗したとき:CANCEL、ダイアログで戻るボタンが押されたとき:NO_RETURN、それ以外：NOMAL)</returns>
		private int BeforeSaveCheckProc()
		{
            // --- UPD 2009/11/30 ---------->>>>>
            //BeforeSaveAttentionDialog dlg = new BeforeSaveAttentionDialog();
            BeforeSaveAttentionDialog dlg = new BeforeSaveAttentionDialog(this._stockMngTtlSt.InventoryMngDiv);
            // --- UPD 2009/11/30 ----------<<<<<
            DialogResult result = dlg.ShowDialog();

            // ---ADD 2009/05/11 不具合対応[13257] ------------------------------------->>>>>
            if (result == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // ---ADD 2009/05/11 不具合対応[13257] -------------------------------------<<<<<
            
            //棚卸データ件数取得処理
            int retCount = 0;
            int status = GetInventoryDateCount(ref retCount,1);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            #region DEL
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            //int retCount = 0;
      
            ////棚卸マスタの重複件数確認			
            //// 抽出条件の展開
            //// インスタンス再生成により条件クリア
            //this._inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            //ToInventInputSearchCndtnWorkFromScreen(ref this._inventInputSearchCndtnWork);
           
            //// 棚卸マスタの重複チェック
            //status = this._inventoryPrepareAcs.SearchCnt(out retCount, this._inventInputSearchCndtnWork);

            //// 正常
            //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    // 何もしない。
            //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //}
            //else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            //{
            //    // 何もしない。
            //    // 棚卸に件数が無い場合
            //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //}
            //else
            //{
            //    this.ShowMsgDisp(
            //        emErrorLevel.ERR_LEVEL_STOPDISP,
            //        "棚卸準備前処理に失敗しました。",
            //        status,
            //        "BeforeSaveCheckProc",
            //        MessageBoxButtons.OK);

            //    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //}
            #endregion

            // リモーティングに成功しかつ、件数がゼロ件なら重複データなしなのでDialogは表示しない
			if ( retCount == 0 )
			{              
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

            // --- UPD 2009/11/30 ---------->>>>>
            //// リモーティングに成功し、重複件数が1件以上ならダイアログを表示する。
            //// 更新確認ダイアログインスタンス確認
            //if (this._beforeSaveCheckDialog == null)
            //{
            //    this._beforeSaveCheckDialog = new BeforeSaveCheckDialog();	// インスタンス生成
            //}

            //// データ重複時処理確認ダイアログ表示
            //DialogResult dialogResult = this._beforeSaveCheckDialog.ShowDialog();

            ////画面の再描画
            //// 更新Click→OK　戻る→Cansel　が帰ってくるのでそれぞれの処理を記述
            //if (dialogResult == DialogResult.OK)
            //{
            //    //棚卸データ処理区分
            //    this._inventoryExtCndtnWork.InventoryProcDiv = this._beforeSaveCheckDialog.InventoryProcDiv;

            //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //}
            //else
            //{
            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            //}
            bool repateFlag = false;
            string serverErrorMsg = "";

            //「倉庫・品番・メーカー」が一致で同一商品と判断する
            status = this._inventoryPrepareAcs.SearchRepateDate(this._inventoryExtCndtnWork, out serverErrorMsg, ref repateFlag);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            //同一商品有りの場合
            if (repateFlag == true)
            {
                // リモーティングに成功し、重複件数が1件以上ならダイアログを表示する。
                // 更新確認ダイアログインスタンス確認
                if (this._beforeSaveCheckDialog == null)
                {
                    this._beforeSaveCheckDialog = new BeforeSaveCheckDialog();	// インスタンス生成
                }

                // データ重複時処理確認ダイアログ表示
                DialogResult dialogResult = this._beforeSaveCheckDialog.ShowDialog();

                //画面の再描画
                // 更新Click→OK　戻る→Cansel　が帰ってくるのでそれぞれの処理を記述
                if (dialogResult == DialogResult.OK)
                {
                    //棚卸データ処理区分
                    this._inventoryExtCndtnWork.InventoryProcDiv = this._beforeSaveCheckDialog.InventoryProcDiv;

                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            //同一商品無しの場合
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            // --- UPD 2009/11/30 ----------<<<<<

			return status;
        }

        #endregion

        #region 棚卸マスタ件数取得処理
        /// <summary>
		/// 棚卸マスタ件数取得処理
		/// </summary>
        private int GetInventoryDateCount(ref int count,int mode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            //棚卸マスタの重複件数確認			
            // 抽出条件の展開
            // インスタンス再生成により条件クリア
            this._inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            if(mode == 0)
            {
                //初回件数確認用の条件をセット
                SetConditionForFirstSearch(ref this._inventInputSearchCndtnWork);
            }
            else
            {
                //画面よりデータを取得
                ToInventInputSearchCndtnWorkFromScreen(ref this._inventInputSearchCndtnWork);
            }
                                 
			// 棚卸マスタの重複チェック
			status = this._inventoryPrepareAcs.SearchCnt(out count, this._inventInputSearchCndtnWork);

			// 正常
			if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				// 何もしない。
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
			{
				// 何もしない。
				// 棚卸に件数が無い場合
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			else
			{
				this.ShowMsgDisp(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					"棚卸データの取得に失敗しました。",
					status,
					"BeforeSaveCheckProc",
					MessageBoxButtons.OK);

				return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

            return status;
        }

		#endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
		#region 日付チェック処理
		/// <summary>
		/// 日付エディタエラーチェック処理
		/// </summary>
		/// <param name="dateEdit">対象日付エディタ</param>
		/// <returns>true:エラー</returns>
		private bool IsErrorDateEdit(TDateEdit dateEdit)
		{
			return this.IsErrorLongDate(dateEdit.LongDate, dateEdit.DateFormat);
		}

		/// <summary>
		/// 日付エラーチェック処理
		/// </summary>
		/// <param name="date">日付(LongDate)</param>
		/// <param name="dateFormat">TDateEditの日付フォーマット</param>
		/// <returns>true:エラー</returns>
		private bool IsErrorLongDate(int date, emDateFormat dateFormat)
		{
			int yy	= date / 10000;  
			int mm	= date / 100 % 100;
			int dd	= date % 100;  

			// 日付未入力チェック
			if (date == 0) return false;

			// システムサポートチェック
			if ((yy > 0)&&(yy < 1900)) return true;
			
			// 年・月・日別入力チェック
			switch (dateFormat)
			{
				// 年・月・日表示時
				case emDateFormat.dfG2Y2M2D:
				case emDateFormat.df4Y2M2D :
				case emDateFormat.df2Y2M2D :
				{
					if (yy == 0 || mm == 0 || dd == 0) return true;
					// 単純日付妥当性チェック
					DateTime dt = TDateTime.LongDateToDateTime(date);
					if (TDateTime.IsAvailableDate(dt) == false) return true;
					break;
				}
				// 年・月    表示時
				case emDateFormat.dfG2Y2M  :
				case emDateFormat.df4Y2M   :
				case emDateFormat.df2Y2M   :
				{
					if (yy == 0 || mm == 0) return true;
					// 単純日付妥当性チェック
					DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
					if (TDateTime.IsAvailableDate(dt) == false) return true;
					break;
				}
				// 年        表示時
				case emDateFormat.dfG2Y    :
				case emDateFormat.df4Y     :
				case emDateFormat.df2Y     :
				{
					if (yy == 0) return false;
					// 単純日付妥当性チェック
					DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
					break;
				}
				// 月・日　　表示時
				case emDateFormat.df2M2D   :
				{
					if (mm == 0 || dd == 0) return true;
					break;
				}
					// 月        表示時
				case emDateFormat.df2M     :
				{
					if (mm == 0) return true;
					break;
				}
					// 日        表示時
				case emDateFormat.df2D     :
				{
					if (dd == 0) return true;
					break;
				}
			}

			return false;
		}
		#endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region Msg表示処理
        /// <summary>
		/// Msg表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">表示メッセージ</param>
		/// <param name="iStatus">ステータス</param>
		/// <param name="iButton">ボタン</param>
		/// <param name="iDefButton">ボタン初期フォーカス</param>
		/// <returns></returns>
		private DialogResult ShowMsgDisp(emErrorLevel iLevel, string iMsg, int iStatus, string iProc, MessageBoxButtons iButton)
		{
			return TMsgDisp.Show(
				iLevel,						        //エラーレベル
				ctPGID,                             //UNIT　ID
				"棚卸準備処理",						//プログラム名称
				iProc,                              //プロセスID
				"",                                 //オペレーション
				iMsg,                               //メッセージ
				iStatus,                            //ステータス
				null,                               //オブジェクト
				iButton,				            //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
		}
		#endregion
      
        #region 画面表示切替処理
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 画面表示切替処理
		/// </summary>
		/// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面表示切替処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/28</br>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        /// </remarks>
        private void ScreenPermitionControl(bool param)
        {
            // 各コンポーネントのEnableプロパティの切替えを行います
            this.tEdit_WarehouseCode_St.Enabled = param;            // 倉庫コード(開始)
            this.tEdit_WarehouseCode_Ed.Enabled = param;            // 倉庫コード(終了)
            // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
            bool Visaleflag = false;
            if (_stockMngTtlSt.InvntryDtDelDiv == 1 && this.InventDelete_Button.Checked)
            {
                Visaleflag = true;
            }

            if (Visaleflag)
            {
                this.tNEdit_SectionCode_St.Enabled = true;              // 管理拠点コード(開始)
                this.tNEdit_SectionCode_Ed.Enabled = true;              // 管理拠点コード(終了)
                this.uButton_SectionGuide_St.Enabled = true;
                this.uButton_SectionGuide_Ed.Enabled = true;
                this.tNEdit_SectionCode_St.DataText = this._loginSectionCode;              // 管理拠点コード(開始)
                this.tNEdit_SectionCode_Ed.DataText = this._loginSectionCode;             // 管理拠点コード(終了)
                this.uLabel_SectionNm_St.Text = GetSecName(_loginSectionCode);
                this.uLabel_SectionNm_Ed.Text = GetSecName(_loginSectionCode);
            }
            else
            {
            // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                //-----ADD 2011/01/11----->>>>>
                this.tNEdit_SectionCode_St.Enabled = param;              // 管理拠点コード(開始)
                this.tNEdit_SectionCode_Ed.Enabled = param;              // 管理拠点コード(終了)
                this.uButton_SectionGuide_St.Enabled = param;
                this.uButton_SectionGuide_Ed.Enabled = param;
                //-----ADD 2011/01/11-----<<<<<
            }// ADD yangyi 2012/06/08 Redmine#30282

            this.tNedit_SupplierCd_St.Enabled = param;              // 仕入先コード(開始)
            this.tNedit_SupplierCd_Ed.Enabled = param;              // 仕入先コード(終了)
            this.tNedit_GoodsMakerCd_St.Enabled = param;            // メーカーコード(開始)
            this.tNedit_GoodsMakerCd_Ed.Enabled = param;            // メーカーコード(終了)
            this.tEdit_WarehouseShelfNo_St.Enabled = param;         // 棚番(開始)
            this.tEdit_WarehouseShelfNo_Ed.Enabled = param;         // 棚番(終了)
            this.tNedit_BLGoodsCode_St.Enabled = param;             // ＢＬコード(開始)
            this.tNedit_BLGoodsCode_Ed.Enabled = param;             // ＢＬコード(終了)
            this.tNedit_BLGloupCode_St.Enabled = param;             // グループコード(開始)
            this.tNedit_BLGloupCode_Ed.Enabled = param;             // グループコード(終了)
            this.WarehouseCodeDiv_tComboEditor.Enabled = param;     // 倉庫指定区分
            // 倉庫コード1～10
            for (int index = 0; index < this._warehouseCodeArray.Length; index++)
            {
                this._warehouseCodeArray[index].Enabled = param;
            }
            this.WarehouseGuide_Button_Array.Enabled = param;       // 倉庫ガイドボタン(範囲)
            this.BLGoodsGuide_Button_St.Enabled = param;            // ＢＬガイド(開始)
            this.BLGoodsGuide_Button_Ed.Enabled = param;            // ＢＬガイド(終了)
            this.DetailGoodsGanreGuide_Button_St.Enabled = param;   // グループコード(開始)
            this.DetailGoodsGanreGuide_Button_Ed.Enabled = param;   // グループコード(終了)
            this.WarehouseGuide_Button_St.Enabled = param;          // 倉庫ガイド(開始)
            this.WarehouseGuide_Button_Ed.Enabled = param;          // 倉庫ガイド(終了)
            this.SupplierGuide_Button_St.Enabled = param;           // 仕入先(開始)
            this.SupplierGuide_Button_Ed.Enabled = param;           // 仕入先(終了)
            this.MakerGuide_Button_St.Enabled = param;              // メーカー(開始)
            this.MakerGuide_Button_Ed.Enabled = param;              // メーカー(終了)
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面表示切替処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面表示切替処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private void ScreenPermitionControl(bool param)
        {
            //各コンポーネントのEnableプロパティの切替えを行います
            //倉庫コード(開始)
            this.tEdit_WarehouseCode_St.Enabled = param;
            //倉庫コード(終了)
            this.tEdit_WarehouseCode_Ed.Enabled = param;
            //仕入先コード(開始)
            this.tNedit_SupplierCd_St.Enabled = param;
            //仕入先コード(終了)
            this.tNedit_SupplierCd_Ed.Enabled = param;
            //メーカーコード(開始)
            this.tNedit_GoodsMakerCd_St.Enabled = param;
            //メーカーコード(終了)
            this.tNedit_GoodsMakerCd_Ed.Enabled = param;
            //商品区分グループコード(開始)
            this.StartLargeGoodsGanreCode_tEdit.Enabled = param;
            //商品区分グループコード(終了)
            this.EndLargeGoodsGanreCode_tEdit.Enabled = param;
            //商品区分コード(開始)
            this.StartMediumGoodsGanreCode_tEdit.Enabled = param;
            //商品区分コード(終了)
            this.EndMediumGoodsGanreCode_tEdit.Enabled = param;
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            ////機種コード(開始)
            //this.St_CellphoneModelCode_tEdit.Enabled        = param;
            ////機種コード(終了)
            //this.Ed_CellphoneModelCode_tEdit.Enabled        = param;
            ////商品コード(開始)
            //this.StartGoodsCode_tNedit.Enabled              = param;
            ////商品コード(終了)
            //this.EndGoodsCode_tNedit.Enabled                = param;
            //棚番(開始)
            this.StartShelfNo_tEdit.Enabled = param;
            //棚番(終了)
            this.EndShelfNo_tEdit.Enabled = param;
            //ＢＬコード(開始)
            this.tNedit_BLGoodsCode_St.Enabled = param;
            //ＢＬコード(終了)
            this.tNedit_BLGoodsCode_Ed.Enabled = param;
            //商品区分詳細コード(開始)
            this.tNedit_BLGloupCode_St.Enabled = param;
            //商品区分詳細コード(終了)
            this.tNedit_BLGloupCode_Ed.Enabled = param;
            //自社分類コード(開始)
            this.StartEnterpriseGanreCode_tNedit.Enabled = param;
            //自社分類コード(終了)
            this.EndEnterpriseGanreCode_tNedit.Enabled = param;
            //倉庫指定区分
            this.WarehouseCodeDiv_ultraOptionSet.Enabled = param;
            //倉庫コード01
            this.WarehouseCode01_tEdit.Enabled = param;
            //倉庫コード02
            this.WarehouseCode02_tEdit.Enabled = param;
            //倉庫コード03
            this.WarehouseCode03_tEdit.Enabled = param;
            //倉庫コード04
            this.WarehouseCode04_tEdit.Enabled = param;
            //倉庫コード05
            this.WarehouseCode05_tEdit.Enabled = param;
            //倉庫コード06
            this.WarehouseCode06_tEdit.Enabled = param;
            //倉庫コード07
            this.WarehouseCode07_tEdit.Enabled = param;
            //倉庫コード08
            this.WarehouseCode08_tEdit.Enabled = param;
            //倉庫コード09
            this.WarehouseCode09_tEdit.Enabled = param;
            //倉庫コード10
            this.WarehouseCode10_tEdit.Enabled = param;
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////商品種別
            ////一般
            //this.GoodsKind1_ultraCheckEditor.Enabled        = param;                   
            ////携帯電話
            //this.GoodsKind2_ultraCheckEditor.Enabled        = param;
            ////付属品
            //this.GoodsKind3_ultraCheckEditor.Enabled        = param;
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
            ////自社在庫抽出区分
            //this.CmpStockDiv_CheckEditor.Enabled            = param;        
            ////受託在庫抽出区分
            //this.TrsStockDiv_CheckEditor.Enabled            = param;          
            ////委託(自社)在庫抽出区分
            //this.EntrustCmpStockDiv_CheckEditor.Enabled     = param;          
            ////委託(受託)在庫抽出区分
            //this.EntrustTrsStockDiv_CheckEditor.Enabled     = param;                
            // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
            //最終棚卸更新日開始
            this.StartInventUpdate_DateEdit.Enabled = param;
            //最終棚卸更新日終了
            this.EndInventUpdate_DateEdit.Enabled = param;
            //ガイドボタン
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            ////商品ガイド
            //this.St_GoodsGuide_Button.Enabled               = param;
            //this.Ed_GoodsGuide_Button.Enabled               = param;
            //ＢＬガイド
            this.BLGoodsGuide_Button_St.Enabled = param;
            this.Ed_BLGoodsGuide_Button.Enabled = param;
            //商品区分詳細コード
            this.DetailGoodsGanreGuide_Button_St.Enabled = param;
            this.Ed_DetailGoodsGanreGuide_Button.Enabled = param;
            //自社分類コード
            this.St_EnterpriseGanreGuide_Button.Enabled = param;
            this.Ed_EnterpriseGanreGuide_Button.Enabled = param;
            //倉庫コード01～10
            this.WarehouseGuide01_Button.Enabled = param;
            this.WarehouseGuide02_Button.Enabled = param;
            this.WarehouseGuide03_Button.Enabled = param;
            this.WarehouseGuide04_Button.Enabled = param;
            this.WarehouseGuide05_Button.Enabled = param;
            this.WarehouseGuide06_Button.Enabled = param;
            this.WarehouseGuide07_Button.Enabled = param;
            this.WarehouseGuide08_Button.Enabled = param;
            this.WarehouseGuide09_Button.Enabled = param;
            this.WarehouseGuide10_Button.Enabled = param;
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            //倉庫
            this.WarehouseGuide_Button_St.Enabled = param;
            this.WarehouseGuide_Button_Ed.Enabled = param;
            //仕入先
            this.SupplierGuide_Button_St.Enabled = param;
            this.Ed_CustomerGuide_Button.Enabled = param;
            //商品区分グループ
            this.St_LargeGoodsGanreGuide_Button.Enabled = param;
            this.Ed_LargeGoodsGanreGuide_Button.Enabled = param;
            //商品区分
            this.St_MidiumGoodsGanreGuide_Button.Enabled = param;
            this.Ed_MidiumGoodsGanreGuide_Button.Enabled = param;
            //メーカー
            this.MakerGuide_Button_St.Enabled = param;
            this.Ed_MakerGuide_Button.Enabled = param;
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        private void LoadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        private void LoadWarehouse()
        {
            int status = 0;

            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;

                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        private void LoadSupplier()
        {
            int status = 0;

            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// BLグループコードマスタ読込処理
        /// </summary>
        private void LoadBLGroupU()
        {
            int status = 0;

            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        private void LoadMakerUMnt()
        {
            int status = 0;

            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 在庫管理全体設定マスタ読込処理
        /// </summary>
        private void LoadStockMngTtlSt()
        {
            int status = 0;

            this._stockMngTtlSt = new StockMngTtlSt();
            this._stockMngTtlStLogin = new StockMngTtlSt();//ADD 2009/11/30

            try
            {
                ArrayList retList;

                status = this._stockMngTglStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    // --- ADD 2009/11/30 ---------->>>>>
                    foreach (StockMngTtlSt stockMngTtlStLogin in retList)
                    {
                        if (stockMngTtlStLogin.LogicalDeleteCode == 0)
                        {
                            if (_loginSectionCode.Trim().Equals(stockMngTtlStLogin.SectionCode.Trim()))
                            {
                                this._stockMngTtlStLogin = stockMngTtlStLogin.Clone();
                            }
                        }
                    }
                    // --- ADD 2009/11/30 ----------<<<<<

                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.LogicalDeleteCode == 0)
                        {
                            //if (stockMngTtlSt.SectionCode == "00")//DEL 2009/11/30
                            if (stockMngTtlSt.SectionCode.Trim() == "00")// ADD 2009/11/30
                            {
                                this._stockMngTtlSt = stockMngTtlSt.Clone();

                                if (string.IsNullOrEmpty(this._stockMngTtlStLogin.SectionCode.Trim()))
                                {
                                    this._stockMngTtlStLogin = stockMngTtlSt.Clone();
                                }
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlSt = new StockMngTtlSt();
                this._stockMngTtlStLogin = new StockMngTtlSt();//ADD 2009/11/30
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim().PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }
        //-----ADD 2011/01/11----->>>>>
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="warehouseCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        private string GetSecName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }
        //-----ADD 2011/01/11-----<<<<<
        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        private string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                supplierName = this._supplierDic[supplierCode].SupplierNm1.Trim() + this._supplierDic[supplierCode].SupplierNm2.Trim();
            }

            return supplierName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        private string GetBlGoodsCdName(int blGoodsCode)
        {
            string blGoodsCdName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsCdName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsCdName;
        }

        /// <summary>
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <returns>BLグループ名称</returns>
        private string GetBlGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// 最終月次更新日取得処理
        /// </summary>
        /// <returns>最終月次更新日</returns>
        private DateTime GetPrevTotalDay()
        {
            DateTime prevTotalDay = new DateTime();

            int status = 0;

            try
            {
                status = this._totalDayCalculator.GetHisTotalDayMonthly(this._loginSectionCode, out prevTotalDay);
                // --- ADD 2009/12/22 ---------->>>>>
                if (prevTotalDay == DateTime.MinValue)
                {
                    status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                }
                // --- ADD 2009/12/22 ----------<<<<<
                if (status != 0)
                {
                    prevTotalDay = new DateTime();
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
            }

            return prevTotalDay;
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #endregion

        #region Control Events

        #region Form.Load イベント(MAZAI05110UA)
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        private void MAZAI05110UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;

            this.tEdit_WarehouseCode_St.Visible = true;
            this.tEdit_WarehouseCode_Ed.Visible = true;
            this.WarehouseGuide_Button_St.Visible = true;
            this.WarehouseGuide_Button_Ed.Visible = true;
            this.WarehouseCode_Label.Visible = true;

            //倉庫コード 01～10
            for (int index = 0; index < this._warehouseCodeArray.Length; index++)
            {
                this._warehouseCodeArray[index].Visible = false;
            }
            // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
            //在庫全体設定「00：全社」の「棚卸データ削除区分」が「不可」の場合、
            //処理区分を表示しない(初期フォーカス位置は棚卸日)
            if (_stockMngTtlSt.InvntryDtDelDiv == 2)
            {
                this.ProcessDiv_Title.Visible = false;
                this.InventStart_Button.Visible = false;
                this.InventDelete_Button.Visible = false;
                this.Info_Title.Visible = false;
                foreach (Control ctr in this.dock1.Controls)
                {
                    Point point = new Point();
                    point.X = ctr.Location.X;
                    point.Y = ctr.Location.Y - 29;
                    ctr.Location = point;
                }
                this.dock1.Size = new System.Drawing.Size(996, 281);
                this.panel1.Size = new System.Drawing.Size(996, 213);
                this.PrepareHistory_Grid.Size = new System.Drawing.Size(996, 213);
                this.windowDockingArea1.Size = new System.Drawing.Size(996, 312);
            }
            // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void MAZAI05110UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;

            // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
            //倉庫コード 開始～終了
            Point point = new Point();
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //point.X = 350;
            //point.Y = 60;
            //this.tEdit_WarehouseCode_St.Location = point;
            //point.X = 411;
            //point.Y = 60;
            //this.WarehouseGuide_Button_St.Location = point;
            //point.X = 448;
            //point.Y = 60;
            //this.WarehouseCode_Label.Location = point;
            //point.X = 476;
            //point.Y = 60;
            //this.tEdit_WarehouseCode_Ed.Location = point;
            //point.X = 537;
            //point.Y = 60;
            //this.WarehouseGuide_Button_Ed.Location = point;
            point.X = tNedit_GoodsMakerCd_St.Location.X;
            point.Y = WarehouseCode_Title.Location.Y;
            this.tEdit_WarehouseCode_St.Location = point;

            point.X = MakerGuide_Button_St.Location.X;
            this.WarehouseGuide_Button_St.Location = point;

            point.X = ultraLabel2.Location.X;
            this.WarehouseCode_Label.Location = point;

            point.X = tNedit_GoodsMakerCd_Ed.Location.X;
            this.tEdit_WarehouseCode_Ed.Location = point;

            point.X = MakerGuide_Button_Ed.Location.X;
            this.WarehouseGuide_Button_Ed.Location = point;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            this.tEdit_WarehouseCode_St.Visible = true;
            this.tEdit_WarehouseCode_Ed.Visible = true;
            this.WarehouseGuide_Button_St.Visible = true;
            this.WarehouseGuide_Button_Ed.Visible = true;
            this.WarehouseCode_Label.Visible = true;

            //倉庫コード 01～10
            this.tEdit_WarehouseCode_01.Visible = false;
            this.tEdit_WarehouseCode_02.Visible = false;
            this.tEdit_WarehouseCode_03.Visible = false;
            this.tEdit_WarehouseCode_04.Visible = false;
            this.tEdit_WarehouseCode_05.Visible = false;
            this.tEdit_WarehouseCode_06.Visible = false;
            this.tEdit_WarehouseCode_07.Visible = false;
            this.tEdit_WarehouseCode_08.Visible = false;
            this.tEdit_WarehouseCode_09.Visible = false;
            this.tEdit_WarehouseCode_10.Visible = false;
            this.WarehouseGuide01_Button.Visible = false;
            this.WarehouseGuide02_Button.Visible = false;
            this.WarehouseGuide03_Button.Visible = false;
            this.WarehouseGuide04_Button.Visible = false;
            this.WarehouseGuide05_Button.Visible = false;
            this.WarehouseGuide06_Button.Visible = false;
            this.WarehouseGuide07_Button.Visible = false;
            this.WarehouseGuide08_Button.Visible = false;
            this.WarehouseGuide09_Button.Visible = false;
            this.WarehouseGuide10_Button.Visible = false;
            // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
		#region Form.Resize イベント(MAZAI05110UA)
		/// <summary>
		/// Form.Resize イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        private void MAZAI05110UA_Resize(object sender, EventArgs e)
        {
            // 履歴グリッドHeight設定
			//this.PrepareHistory_Grid_Panel.Height = this.Height - ctDifferenceHeight;
        }
	
		#endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region Form.FormClosing
        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender">対象ｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="e">ｲﾍﾞﾝﾄﾊﾟﾗﾒｰﾀ</param>
        private void MAZAI05110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // グリッド設定保存
            if (this._gridStateController != null)
            {
                this._gridStateController.GetGridStateFromGrid(ref this.PrepareHistory_Grid);
                this._gridStateController.SaveGridState(ct_FileName_ColDisplayStatus);
            }
        }

        #endregion
		
		#region Timer.Tick イベント(Initial_Timer)

		/// <summary>
		/// Timer.Tick イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
            this.Initial_Timer.Enabled = false;

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
			// 画面初期設定処理
			this.InitialSetting();	
			this._isFirstFlag = false;
            // DEL yangyi 2012/06/08 Redmine#30282 ------------->>>>>
            //棚卸データ確認
            //int retCount = 0;
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //int status = GetInventoryDateCount(ref retCount, 0);
            //DataView dv = new DataView();
            //dv.Table = this._prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3)
            //    {
            //        continue;
            //    }

            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty)) 
            //    {
            //        this.targetDelDate = (int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int];

            //        // 棚卸マスタ件数取得
            //        GetInventoryDateCount(ref retCount, 0);
            //        break;
            //    }
            //}
            //// 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            ////件数がゼロ
            //if ( retCount == 0 )
            //{                            
            //    //棚卸削除ボタンを選択不可にする
            //    this.InventDelete_Button.Enabled = false;
            //    //Infoラベルを非表示
            //    this.Info_Title.Visible = false;
            //}
            //else
            //{
            //    //棚卸削除ボタンを選択可にする
            //    this.InventDelete_Button.Enabled = true;
            //    //Enableの時がイマイチ分かりづらいので
            //    this.InventDelete_Button.ForeColor = SystemColors.ControlText;
            //    //Infoラベルを表示
            //    this.Info_Title.Visible = true;
            //}
            // DEL yangyi 2012/06/08 Redmine#30282 -------------<<<<<
            // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
            // 棚卸マスタチェック
            object retobj = null;
            ArrayList list = new ArrayList();
            int status = 0;
            InventoryDataWork inventoryDataWork = new InventoryDataWork();
            inventoryDataWork.EnterpriseCode = this._enterpriseCode;
            status = this._inventoryPrepareAcs.SearchInventoryData(out retobj, inventoryDataWork);
            if (status == 0)
            {
                list = (ArrayList)retobj; 
            }
            if (list == null)
            {
                //棚卸削除ボタンを選択可にする
                this.InventDelete_Button.Enabled = true;
                //Enableの時がイマイチ分かりづらいので
                this.InventDelete_Button.ForeColor = SystemColors.ControlText;
                //Infoラベルを表示
                this.Info_Title.Visible = true;
            }
            else
            {
                if (list.Count == 0)
                {
                    //Infoラベルを非表示
                    this.Info_Title.Visible = false;
                }
                else
                {
                    //Enableの時がイマイチ分かりづらいので
                    this.InventDelete_Button.ForeColor = SystemColors.ControlText;
                    //Infoラベルを表示
                    this.Info_Title.Visible = true;
                }
            }
            // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
		}

		#endregion

		#region フォーカスChangeイベント(tArrowKeyControl1, tRetKeyControl1)
		/// <summary>
		/// フォーカスChangeイベント(tArrowKeyControl1, tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
				return;
         
			// 諸費用グリッドの時
			if (e.PrevCtrl == this.PrepareHistory_Grid)
			{
                if (e.ShiftKey == false)
                {
                    // リターンキー押下
                    if (e.Key == Keys.Return)
                    {
                        e.NextCtrl = null;

                        if (this.PrepareHistory_Grid != null)
                        {
                            UltraGridCell activeCell = this.PrepareHistory_Grid.ActiveCell;

                            this.PrepareHistory_Grid.PerformAction(UltraGridAction.NextCellByTab);

                            if (activeCell == this.PrepareHistory_Grid.ActiveCell)
                                this.ckdDepositAutoColumnSize.Focus();
                        }
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                }
			}
            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
            // 倉庫コードの時
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                // 倉庫コード取得
                string warehouseCode = tEdit_WarehouseCode_St.DataText.Trim();

                // 倉庫名称取得
                this.tEdit_WarehouseName_St.DataText = GetWarehouseName(warehouseCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_WarehouseName_St.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        //}
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                // 倉庫コード取得
                string warehouseCode = tEdit_WarehouseCode_Ed.DataText.Trim();

                // 倉庫名称取得
                this.tEdit_WarehouseName_Ed.DataText = GetWarehouseName(warehouseCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_WarehouseName_Ed.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                        //}
                        e.NextCtrl = this.WarehouseCodeDiv_tComboEditor;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tEdit_WarehouseCode_St;
                    }
                }
            }
            //----- ADD 2011/01/11----->>>>>
            // 開始管理拠点コード
            else if (e.PrevCtrl == this.tNEdit_SectionCode_St)
            {
                string code = this.tNEdit_SectionCode_St.DataText.Trim();

                this.uLabel_SectionNm_St.Text = GetSecName(code);

                if (code.Equals("0") || code.Equals("00"))
                {
                    this.tNEdit_SectionCode_St.Text = "";
                    this.uLabel_SectionNm_St.Text = "";
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.tNEdit_SectionCode_Ed;
                    }
                }
                
            }
            // 終了管理拠点コード
            else if (e.PrevCtrl == this.tNEdit_SectionCode_Ed)
            {
                string code = this.tNEdit_SectionCode_Ed.DataText.Trim();

                this.uLabel_SectionNm_Ed.Text = GetSecName(code);

                if (code.Equals("0") || code.Equals("00"))
                {
                    this.tNEdit_SectionCode_Ed.Text = "";
                    this.uLabel_SectionNm_Ed.Text = "";
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNEdit_SectionCode_St;
                    }
                }
            }
            // 棚番
            else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
            {
                if (e.ShiftKey)
                {
                    if ((e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.tNEdit_SectionCode_Ed;
                    }
                }
            }
            //----- ADD 2011/01/11----->>>>>
            // 仕入先コードの時
            else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                // 仕入先コード取得
                int supplierCode = this.tNedit_SupplierCd_St.GetInt();

                // 仕入先名称取得
                this.tEdit_SupplierName_St.DataText = GetSupplierName(supplierCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_SupplierName_St.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        //}
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tEdit_WarehouseShelfNo_Ed;
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                // 仕入先コード取得
                int supplierCode = this.tNedit_SupplierCd_Ed.GetInt();

                // 仕入先名称取得
                this.tEdit_SupplierName_Ed.DataText = GetSupplierName(supplierCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_SupplierName_Ed.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        //}
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_SupplierCd_St;
                    }
                }
            }
            // BLコードの時
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                // BLコード取得
                int blGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();

                // BLコード名称取得
                this.tEdit_BLGoodsName_St.DataText = GetBlGoodsCdName(blGoodsCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_BLGoodsName_St.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        //}
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_SupplierCd_Ed;
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                // BLコード取得
                int blGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();

                // BLコード名称取得
                this.tEdit_BLGoodsName_Ed.DataText = GetBlGoodsCdName(blGoodsCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_BLGoodsName_Ed.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_BLGloupCode_St;
                        //}
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_BLGoodsCode_St;
                    }
                }
            }
            // グループコードの時
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                // グループコード取得
                int blGroupCode = this.tNedit_BLGloupCode_St.GetInt();

                // グループコード名称取得
                this.tEdit_BLGloupName_St.DataText = GetBlGroupName(blGroupCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_BLGloupName_St.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        //}
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_BLGoodsCode_Ed;
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                // グループコード取得
                int blGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();

                // グループコード名称取得
                this.tEdit_BLGloupName_Ed.DataText = GetBlGroupName(blGroupCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_BLGloupName_Ed.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        //}
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_BLGloupCode_St;
                    }
                }
            }
            // メーカーコードの時
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                // メーカーコード取得
                int makerCode = this.tNedit_GoodsMakerCd_St.GetInt();

                // メーカー名称取得
                this.tEdit_GoodsMakerName_St.DataText = GetMakerName(makerCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        //if (this.tEdit_GoodsMakerName_St.DataText.Trim() != "")
                        //{
                        //    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        //}
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_BLGloupCode_Ed;
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                // メーカーコード
                int makerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // メーカー名称
                this.tEdit_GoodsMakerName_Ed.DataText = GetMakerName(makerCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.PrepareHistory_Grid.Rows.Count == 0)
                        {
                            e.NextCtrl = this.ckdDepositAutoColumnSize;
                        }
                        else
                        {
                            e.NextCtrl = this.PrepareHistory_Grid;
                        }
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = tNedit_GoodsMakerCd_St;
                    }
                }
            }
            else if (e.PrevCtrl == ckdDepositAutoColumnSize)
            {
                if (e.ShiftKey == true)
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.PrepareHistory_Grid.Rows.Count == 0)
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.WarehouseCodeDiv_tComboEditor)
            {
                if (e.ShiftKey == true)
                {
                    if (e.Key == Keys.Tab)
                    {
                        if ((int)this.WarehouseCodeDiv_tComboEditor.Value == 0)
                        {
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else
                        {
                            e.NextCtrl = this.InventoryDate_tDateEdit;
                        }
                    }
                }
            }
            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
        }
		#endregion
		
		#region ValueChangedイベント(FontSize_tComboEditor)
		/// <summary>
		/// FontSize_tComboEditor.ValueChangedイベント(FontSize_tComboEditor)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">ValueChangedイベントに使用されるイベントパラメータ</param>
		private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			// 文字サイズを変更
			this.PrepareHistory_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.FontSize_tComboEditor.SelectedItem.DataValue;
		}

		#endregion
		
		#region PrepareHistory_Grid Event

		#region InitializeLayoutイベント(PrepareHistory_Grid)
        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// InitializeLayoutイベント(PrepareHistory_Grid)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
		private void PrepareHistory_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			UltraGridBand band = e.Layout.Bands[0];
			
			// 行の高さ設定
			e.Layout.Override.DefaultRowHeight = 10;         					
			// 垂直方向配置設定
			e.Layout.Appearance.TextVAlign = VAlign.Middle;

            //e.Layout.Bands[0].Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
            //e.Layout.Bands[0].Layout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
		
			// カラムスタイル設定
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate	    ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime	    ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden  ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv         ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctGoodsKind			    ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventoryPrepareAcs.ctCarrierName            ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            //band.Columns[InventoryPrepareAcs.ctCellphoneModelCode	    ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryDate            ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int        ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate_Int   ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime_Int   ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            band.Columns[InventoryPrepareAcs.ctGoodsCode                ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctLargeGoodsCode	        ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctMediumGoodsCode	        ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctLastInventoryUpd         ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctMakerCode		        ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctStockExtraDiv		    ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctWareHouseCode	        ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            // 列のアクティブタイプの設定
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate	    ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctInventoryPreprTime	    ].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden  ].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv         ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctGoodsKind			    ].CellActivation = Activation.NoEdit;
            // 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventoryPrepareAcs.ctCarrierName            ].CellActivation = Activation.NoEdit;
			//band.Columns[InventoryPrepareAcs.ctCellphoneModelCode	    ].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryDate            ].CellActivation = Activation.NoEdit;
            // 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int        ].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate_Int   ].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime_Int   ].CellActivation = Activation.NoEdit;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            band.Columns[InventoryPrepareAcs.ctGoodsCode                ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctLargeGoodsCode	        ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctMediumGoodsCode	        ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctLastInventoryUpd	        ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctMakerCode		        ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctStockExtraDiv		    ].CellActivation = Activation.NoEdit;
			band.Columns[InventoryPrepareAcs.ctWareHouseCode	        ].CellActivation = Activation.NoEdit;

            //非表示
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden  ].Hidden = true;
            band.Columns[InventoryPrepareAcs.ctLastInventoryUpd  ].Hidden = true;
            //TODO;2007.05.21
            //商品種別を非表示→テーブルレイアウト変更が間にあわないため
            band.Columns[InventoryPrepareAcs.ctGoodsKind    ].Hidden = true;

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int        ].Hidden = true;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate_Int   ].Hidden = true;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime_Int   ].Hidden = true;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// InitializeLayoutイベント(PrepareHistory_Grid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
        private void PrepareHistory_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            // 行の高さ設定
            e.Layout.Override.DefaultRowHeight = 10;
            // 垂直方向配置設定
            e.Layout.Appearance.TextVAlign = VAlign.Middle;

            // カラムスタイル設定
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctWareHouseCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctMngSectionCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;// ADD 2011/01/30
            band.Columns[InventoryPrepareAcs.ctShelfNo].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctSupplierCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctBLGoodsCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctBLGroupCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
            band.Columns[InventoryPrepareAcs.ctMakerCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

            // 列のアクティブタイプの設定
            band.Columns[InventoryPrepareAcs.ctInventoryPreprDate].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryPreprTime].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryDate].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctWareHouseCode].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctMngSectionCode].CellActivation = Activation.NoEdit;// ADD 2011/01/30
            band.Columns[InventoryPrepareAcs.ctShelfNo].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctSupplierCode].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctBLGoodsCode].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctBLGroupCode].CellActivation = Activation.NoEdit;
            band.Columns[InventoryPrepareAcs.ctMakerCode].CellActivation = Activation.NoEdit;

            //非表示
            band.Columns[InventoryPrepareAcs.ctInventoryProcDiv_Hidden].Hidden = true;
            band.Columns[InventoryPrepareAcs.ctInventoryDate_Int].Hidden = true;

            band.Columns[InventoryPrepareAcs.ctShelfNo].Width = 160;            //ADD 2009/05/11 不具合対応[13257]
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
        #endregion

		#region InitializeRowイベント(PrepareHistory_Grid)

		/// <summary>
		/// InitializeRowイベント(PrepareHistory_Grid)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
		private void PrepareHistory_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			//グリッドの１行高さ
			e.Row.Height = 10;
			e.Row.Appearance.BackGradientStyle = GradientStyle.Vertical;

			e.Row.Activation = Activation.NoEdit;
			e.Row.Appearance.Cursor = Cursors.Arrow;
			//グリッド設定
			this.PrepareHistoryGridDisp();
		}
		#endregion

		#endregion		

		#region CheckedChangedイベント(ckdDepositAutoColumnSize)

		/// <summary>
		/// CheckedChangedイベント(ckdDepositAutoColumnSize)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
		private void ckdDepositAutoColumnSize_CheckedChanged(object sender, EventArgs e)
		{
		    // グリッド列サイズ変更スレッドスタート
		    Thread depositGridColumnSizeChangeThread = new Thread(new ParameterizedThreadStart(DepositGridColumnSizeChange));
		    depositGridColumnSizeChangeThread.Start((object)this.ckdDepositAutoColumnSize.Checked);
		}

		#endregion
	
        #region ガイドボタンクリックイベント

        #region 倉庫ガイド
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/28</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = null;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this._loginSectionCode);
            if (status == 0)
            {
                if (warehouse != null)
                {
                    // 開始、終了、単独指定用のどのボタンが押されたか？
                    if((UltraButton)sender == this.WarehouseGuide_Button_St)
                    {
                        // 開始
                        this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.Trim();
                        this.tEdit_WarehouseName_St.DataText = warehouse.WarehouseName.Trim();

                        // フォーカス設定
                        this.tEdit_WarehouseCode_Ed.Focus();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide_Button_Ed)
                    {
                        // 終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.Trim();
                        this.tEdit_WarehouseName_Ed.DataText = warehouse.WarehouseName.Trim();

                        // フォーカス設定
                        this.WarehouseCodeDiv_tComboEditor.Focus();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide_Button_Array)
                    {
                        // 単独指定用
                        for (int index = 0; index < this._warehouseCodeArray.Length; index++)
                        {
                            if (this._warehouseCodeArray[index].DataText.Trim() == "")
                            {
                                this._warehouseCodeArray[index].DataText = warehouse.WarehouseCode.Trim();
                                break;
                            }
                        }
                    }
                }
            }
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;

            if (this._warehouseAcs == null)
            {
                this._warehouseAcs = new WarehouseAcs();
            }

            int status = this._warehouseAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if ((UltraButton)sender == this.WarehouseGuide_Button_St)
                    {
                        //開始
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide_Button_Ed)
                    {
                        //終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide01_Button)
                    {
                        //01
                        this.WarehouseCode01_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide02_Button)
                    {
                        //02
                        this.WarehouseCode02_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide03_Button)
                    {
                        //03
                        this.WarehouseCode03_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide04_Button)
                    {
                        //04
                        this.WarehouseCode04_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide05_Button)
                    {
                        //05
                        this.WarehouseCode05_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide06_Button)
                    {
                        //06
                        this.WarehouseCode06_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide07_Button)
                    {
                        //07
                        this.WarehouseCode07_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide08_Button)
                    {
                        //08
                        this.WarehouseCode08_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else if ((UltraButton)sender == this.WarehouseGuide09_Button)
                    {
                        //09
                        this.WarehouseCode09_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else
                    {
                        //10
                        this.WarehouseCode10_tEdit.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }

                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }

        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region ＢＬ商品ガイド
        /// <summary>
        /// ＢＬ商品ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ＢＬ商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>    
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //ＢＬ商品ガイド起動
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (blGoodsCdUMnt != null)
                        {
                            //開始、終了どちらのボタンが押されたか？
                            if ((UltraButton)sender == this.BLGoodsGuide_Button_St)
                            {
                                //開始
                                this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                
                                // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
                                this.tEdit_BLGoodsName_St.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                                // フォーカス設定
                                this.tNedit_BLGoodsCode_Ed.Focus();
                                // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
                            }
                            else
                            {
                                //終了
                                this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                
                                // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
                                this.tEdit_BLGoodsName_Ed.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                                // フォーカス設定
                                this.tNedit_BLGloupCode_St.Focus();
                                // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
                            }
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 商品区分グループガイド
        /// <summary>
        /// 商品区分グループガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分グループガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.12</br>
        /// </remarks>    
        private void LargeGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        {
            LGoodsGanre lGoodsGanre = null;
            if(this._lGoodsGanreAcs == null)
            {
                this._lGoodsGanreAcs = new LGoodsGanreAcs();               
            }
            //従業員ガイド起動(メカ、受付、販売を全て含む)←要変更
            int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(lGoodsGanre != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((UltraButton)sender == this.St_LargeGoodsGanreGuide_Button)
                        {
                            //開始
                            this.StartLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
                        }
                        else
                        {
                            //終了
                            this.EndLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
                        }           
                                  
                    }
                    break;
                }
                //キャンセル
                case 1:
                {                  
                    break;
                }
            }
        }

        #endregion

        #region 商品区分ガイド
        /// <summary>
        /// 商品区分ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.12</br>
        /// </remarks>    
        private void MidiumGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        {
            MGoodsGanre mGoodsGanre = null;
            if(this._mGoodsGanreAcs == null)
            {
                this._mGoodsGanreAcs = new MGoodsGanreAcs();               
            }
            //商品区分ガイド起動(引数に商品グループコードが残っているので空文字をセット)
            //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 0);
            int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(mGoodsGanre != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((UltraButton)sender == this.St_MidiumGoodsGanreGuide_Button)
                        {
                            //開始
                            this.StartMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                        }
                        else
                        {
                            //終了
                            this.EndMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                        }           
                                  
                    }
                    break;
                }
                //キャンセル
                case 1:
                {                  
                    break;
                }
            }
        }
        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #region グループコードガイド
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グループコードガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : グループコードガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/28</br>
        /// </remarks>    
        private void DetailGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU = null;

            // グループコードガイド起動(引数にグループコードが残っているので空文字をセット)
            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            switch (status)
            {
                // 取得
                case 0:
                    {
                        if (blGroupU != null)
                        {
                            // 開始、終了どちらのボタンが押されたか？
                            if ((UltraButton)sender == this.DetailGoodsGanreGuide_Button_St)
                            {
                                // 開始
                                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                                this.tEdit_BLGloupName_St.DataText = blGroupU.BLGroupName.Trim();

                                // フォーカス設定
                                this.tNedit_BLGloupCode_Ed.Focus();
                            }
                            else
                            {
                                // 終了
                                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                                this.tEdit_BLGloupName_Ed.DataText = blGroupU.BLGroupName.Trim();

                                // フォーカス設定
                                this.tNedit_GoodsMakerCd_St.Focus();
                            }
                        }
                        break;
                    }
            }
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品区分詳細ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分詳細ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>    
        private void DetailGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        {
            DGoodsGanre dGoodsGanre = null;
            if (this._dGoodsGanreAcs == null)
            {
                this._dGoodsGanreAcs = new DGoodsGanreAcs();
            }
            //商品区分ガイド起動(引数に商品グループコードが残っているので空文字をセット)
            int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (dGoodsGanre != null)
                        {
                            //開始、終了どちらのボタンが押されたか？
                            if ((UltraButton)sender == this.DetailGoodsGanreGuide_Button_St)
                            {
                                //開始
                                this.StartMediumGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
                            }
                            else
                            {
                                //終了
                                this.EndMediumGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
                            }
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        #region メーカーガイド
        /// <summary>
        /// メーカーガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.12</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            //Maker maker = null;
            MakerUMnt makerUMnt = null;

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            if(this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();               
            }
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //メーカーガイド起動
            //int status = this._makerAcs.ExecuteGuid(this._enterpriseCode,out maker);
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            
            switch(status)
            {
                //取得
                case 0:
                {                  
                    //if(maker != null)
                    if (makerUMnt != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((UltraButton)sender == this.MakerGuide_Button_St)
                        {
                            //開始
                            //this.tNedit_GoodsMakerCd_St.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
                            this.tEdit_GoodsMakerName_St.DataText = makerUMnt.MakerName.Trim();

                            // フォーカス設定
                            this.tNedit_GoodsMakerCd_Ed.Focus();
                            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
                         }
                        else
                        {
                            //終了
                            //this.tNedit_GoodsMakerCd_Ed.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                            // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
                            this.tEdit_GoodsMakerName_Ed.DataText = makerUMnt.MakerName.Trim();
                            // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
                        }                                    
                    }           
                    break;
                }
                //キャンセル
                case 1:
                {
                    
                    break;
                }
            }
        }
        #endregion

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 仕入先ガイド
        /// <summary>
        /// 仕入先ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 仕入先ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/28</br>
        /// </remarks>    
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            Supplier supplier = null;

            // 仕入先ガイド起動
            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
            switch (status)
            {
                // 取得
                case 0:
                    {
                        if (supplier != null)
                        {
                            // 開始、終了どちらのボタンが押されたか？
                            if ((UltraButton)sender == this.SupplierGuide_Button_St)
                            {
                                // 開始
                                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                                this.tEdit_SupplierName_St.DataText = supplier.SupplierNm1.Trim() + supplier.SupplierNm2.Trim();

                                // フォーカス設定
                                this.tNedit_SupplierCd_Ed.Focus();
                            }
                            else
                            {
                                // 終了
                                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                                this.tEdit_SupplierName_Ed.DataText = supplier.SupplierNm1.Trim() + supplier.SupplierNm2.Trim();

                                // フォーカス設定
                                this.tNedit_BLGoodsCode_St.Focus();
                            }
                        }
                        break;
                    }
            }
        }
        #endregion
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 得意先ガイド
        /// <summary>
        /// 得意先ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>    
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {

            CustomerInfo customerInfo = null;
            if(this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            
            //得意先ガイド起動
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, 0, true, out customerInfo);
          
            switch(status)
            {
                //取得
                case 0:
                {
                    if (customerInfo != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((UltraButton)sender == this.SupplierGuide_Button_St)
                        {
                            //開始
                            this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
                         }
                        else
                        {
                            //終了
                            this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
                        }                                    
                    }           
                    break;
                }
                //キャンセル
                case 1:
                {
                    
                    break;
                }
            }
        }
        #endregion

        #region 自社分類ガイド
        /// <summary>
        /// 自社分類ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 自社分類ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>    
        private void EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        {

            UserGdBd userGdBd = null;
            if (this._userGuideGuide == null)
            {
                this._userGuideGuide = new UserGuideGuide();
            }

            //ユーザーガイド起動
            DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                if (userGdBd != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if ((UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
                    {
                        //開始
                        this.StartEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
                    }
                    else
                    {
                        //終了
                        this.EndEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
                    }
                }
            }
        }
        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #region 2007.09.10 削除
        // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
        //#region 機種ガイド
        ///// <summary>
        ///// 機種ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 機種ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.05.21</br>
        ///// </remarks>    
        //private void St_CellphoneModelGuide_Button_Click(object sender, EventArgs e)
        //{
        //    CellphoneModel cellphoneModel = null;        
        //    if(this._cellphoneModelAcs == null)
        //    {
        //        this._cellphoneModelAcs = new CellphoneModelAcs();               
        //    }
        //
        //    //キャリアガイド起動
        //    int status = this._cellphoneModelAcs.ExecuteGuid(this._enterpriseCode,0,out cellphoneModel);
        //  
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(cellphoneModel != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
        //                {
        //                    //開始
        //                    this.St_CellphoneModelCode_tEdit.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.Ed_CellphoneModelCode_tEdit.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //                }                                    
        //            }           
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {
        //            
        //            break;
        //        }
        //    }
        //}
        //
        //#endregion
        // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.09.10 削除

        #endregion

        // ---ADD 2009/05/11 不具合対応[13257] -------------------------------->>>>>
        #region 注意事項ボタンクリックイベント
        /// <summary>
        /// 注意事項ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 注意事項ボタンがクリックされると発生します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>    
        private void AttentionButton_Click(object sender, EventArgs e)
        {
            // --- UPD 2009/11/30 ---------->>>>>
            //AttentionDialog dlg = new AttentionDialog();
            AttentionDialog dlg = new AttentionDialog(this._stockMngTtlSt.InventoryMngDiv);
            // --- UPD 2009/11/30 ----------<<<<<

            dlg.ShowDialog();
        }
        #endregion
        // ---ADD 2009/05/11 不具合対応[13257] --------------------------------<<<<<


        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region Control.Leave
        /// <summary>
        /// Control.Leave イベント (tNedit_GoodsMakerCd_St)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.15</br>
        /// </remarks>
        private void StartMakerCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // 空欄か0の時初期値をセット
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (tNedit.Equals(this.tNedit_GoodsMakerCd_St))
                //{
                //    tNedit.SetInt(0);
                //}              
                //else if (tNedit.Equals(this.tNedit_GoodsMakerCd_Ed))
                //{
                //    tNedit.SetInt(999999);
                //}              
                //else if (tNedit.Equals(this.tNedit_SupplierCd_St))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.tNedit_SupplierCd_Ed))
                //{
                //    tNedit.SetInt(999999999);
                //}
                //// 2007.09.10 修正 >>>>>>>>>>>>>>>>>>>>
                //else if (tNedit.Equals(this.tNedit_BLGoodsCode_St))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.tNedit_BLGoodsCode_Ed))
                //{
                //    tNedit.SetInt(999999999);
                //}
                //else if (tNedit.Equals(this.StartEnterpriseGanreCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndEnterpriseGanreCode_tNedit))
                //{
                //    tNedit.SetInt(99);
                //}
                //// 2007.09.10 修正 <<<<<<<<<<<<<<<<<<<<
                tNedit.Clear();
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            }           
        }

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        #region InventDelete_Button_CheckedChangedイベント
        /// <summary>
		/// InventDelete_Button_CheckedChangedイベント
		/// </summary>
		/// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : InventDelete_Buttonの値が変更された時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        /// </remarks>
        private void InventDelete_Button_CheckedChanged(object sender, EventArgs e)
        {
            // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
            // 画面抽出条件の初期表示
            this.tEdit_WarehouseCode_St.Text = null;            // 倉庫コード(開始)
            this.tEdit_WarehouseCode_Ed.Text = null;            // 倉庫コード(終了)
            this.tNEdit_SectionCode_St.Text = null;             // 管理拠点コード(開始)
            this.tNEdit_SectionCode_Ed.Text = null;             // 管理拠点コード(終了)
            this.tNedit_SupplierCd_St.Text = null;              // 仕入先コード(開始)
            this.tNedit_SupplierCd_Ed.Text = null;              // 仕入先コード(終了)
            this.tNedit_GoodsMakerCd_St.Text = null;            // メーカーコード(開始)
            this.tNedit_GoodsMakerCd_Ed.Text = null;            // メーカーコード(終了)
            this.tEdit_WarehouseShelfNo_St.Text = null;         // 棚番(開始)
            this.tEdit_WarehouseShelfNo_Ed.Text = null;         // 棚番(終了)
            this.tNedit_BLGoodsCode_St.Text = null;             // ＢＬコード(開始)
            this.tNedit_BLGoodsCode_Ed.Text = null;             // ＢＬコード(終了)
            this.tNedit_BLGloupCode_St.Text = null;             // グループコード(開始)
            this.tNedit_BLGloupCode_Ed.Text = null;             // グループコード(終了)
            this.tEdit_WarehouseName_St.Text = null; 
            this.tEdit_WarehouseName_Ed.Text = null;
            this.uLabel_SectionNm_St.Text = null;
            this.uLabel_SectionNm_Ed.Text = null;
            this.tEdit_WarehouseShelfNo_St.Text = null;
            this.tEdit_WarehouseShelfNo_Ed.Text = null;
            this.tEdit_SupplierName_St.Text = null;
            this.tEdit_SupplierName_Ed.Text = null;
            this.tEdit_BLGoodsName_St.Text = null;
            this.tEdit_BLGoodsName_Ed.Text = null;
            this.tEdit_BLGloupName_St.Text = null;
            this.tEdit_BLGloupName_Ed.Text = null;
            this.tEdit_GoodsMakerName_St.Text = null;
            this.tEdit_GoodsMakerName_Ed.Text = null;
            this.WarehouseCodeDiv_tComboEditor.Value = 0;       // 倉庫指定区分
            // 倉庫コード1～10
            for (int index = 0; index < this._warehouseCodeArray.Length; index++)
            {
                this._warehouseCodeArray[index].Text = null;
            }
            // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<

            if(this.InventDelete_Button.Checked)
            {
                //棚卸データ削除処理
                ScreenPermitionControl(false);
            }
            else
            {
                //棚卸準備処理
                ScreenPermitionControl(true);               
            }
        }

        #endregion     

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>        
        #region 倉庫指定区分変更イベント
        /// <summary>
        /// 倉庫指定区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫指定区分が変更されると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>    
        private void WarehouseCodeDiv_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.WarehouseCodeDiv_tComboEditor.Value == 0)
            {
                //倉庫コード 開始～終了
                this.tEdit_WarehouseCode_St.Visible = true;
                this.tEdit_WarehouseCode_Ed.Visible = true;
                this.WarehouseGuide_Button_St.Visible = true;
                this.WarehouseGuide_Button_Ed.Visible = true;
                this.WarehouseCode_Label.Visible = true;

                //倉庫コード 01～10
                this.tEdit_WarehouseCode_01.Visible = false;
                this.tEdit_WarehouseCode_02.Visible = false;
                this.tEdit_WarehouseCode_03.Visible = false;
                this.tEdit_WarehouseCode_04.Visible = false;
                this.tEdit_WarehouseCode_05.Visible = false;
                this.tEdit_WarehouseCode_06.Visible = false;
                this.tEdit_WarehouseCode_07.Visible = false;
                this.tEdit_WarehouseCode_08.Visible = false;
                this.tEdit_WarehouseCode_09.Visible = false;
                this.tEdit_WarehouseCode_10.Visible = false;
                this.WarehouseGuide01_Button.Visible = false;
                this.WarehouseGuide02_Button.Visible = false;
                this.WarehouseGuide03_Button.Visible = false;
                this.WarehouseGuide04_Button.Visible = false;
                this.WarehouseGuide05_Button.Visible = false;
                this.WarehouseGuide06_Button.Visible = false;
                this.WarehouseGuide07_Button.Visible = false;
                this.WarehouseGuide08_Button.Visible = false;
                this.WarehouseGuide09_Button.Visible = false;
                this.WarehouseGuide10_Button.Visible = false;
            }
            else
            {
                //倉庫コード 開始～終了
                this.tEdit_WarehouseCode_St.Visible = false;
                this.tEdit_WarehouseCode_Ed.Visible = false;
                this.WarehouseGuide_Button_St.Visible = false;
                this.WarehouseGuide_Button_Ed.Visible = false;
                this.WarehouseCode_Label.Visible = false;

                //倉庫コード 01～10
                this.tEdit_WarehouseCode_01.Visible = true;
                this.tEdit_WarehouseCode_02.Visible = true;
                this.tEdit_WarehouseCode_03.Visible = true;
                this.tEdit_WarehouseCode_04.Visible = true;
                this.tEdit_WarehouseCode_05.Visible = true;
                this.tEdit_WarehouseCode_06.Visible = true;
                this.tEdit_WarehouseCode_07.Visible = true;
                this.tEdit_WarehouseCode_08.Visible = true;
                this.tEdit_WarehouseCode_09.Visible = true;
                this.tEdit_WarehouseCode_10.Visible = true;
                this.WarehouseGuide01_Button.Visible = true;
                this.WarehouseGuide02_Button.Visible = true;
                this.WarehouseGuide03_Button.Visible = true;
                this.WarehouseGuide04_Button.Visible = true;
                this.WarehouseGuide05_Button.Visible = true;
                this.WarehouseGuide06_Button.Visible = true;
                this.WarehouseGuide07_Button.Visible = true;
                this.WarehouseGuide08_Button.Visible = true;
                this.WarehouseGuide09_Button.Visible = true;
                this.WarehouseGuide10_Button.Visible = true;
            }
        }
        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 倉庫指定区分変更イベント
        /// <summary>
        /// 倉庫指定区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫指定区分が変更されると発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/28</br>
        /// <br>UpdateNote : 2010/02/20 李占川 PM1005</br>
        /// <br>             倉庫の指定区分「範囲」「単独」を変更時に、値がクリアするように変更</br>
        /// </remarks>
        private void WarehouseCodeDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.WarehouseCodeDiv_tComboEditor.Value == 0)
            {
                //倉庫コード 開始～終了
                this.tEdit_WarehouseCode_St.Visible = true;
                this.tEdit_WarehouseCode_Ed.Visible = true;
                this.tEdit_WarehouseName_St.Visible = true;
                this.tEdit_WarehouseName_Ed.Visible = true;
                this.WarehouseGuide_Button_St.Visible = true;
                this.WarehouseGuide_Button_Ed.Visible = true;
                this.WarehouseCode_Label.Visible = true;

                //倉庫コード 01～10
                for (int index = 0; index < this._warehouseCodeArray.Length; index++)
                {
                    this._warehouseCodeArray[index].Visible = false;

                    // --- ADD 2010/02/20 ---------->>>>>
                    this._warehouseCodeArray[index].DataText = "";
                    // --- ADD 2010/02/20 ----------<<<<<
                }

                // 倉庫ガイド(単独指定用)
                this.WarehouseGuide_Button_Array.Visible = false;
            }
            else
            {
                //倉庫コード 開始～終了
                this.tEdit_WarehouseCode_St.Visible = false;
                this.tEdit_WarehouseCode_Ed.Visible = false;
                this.tEdit_WarehouseName_St.Visible = false;
                this.tEdit_WarehouseName_Ed.Visible = false;
                this.WarehouseGuide_Button_St.Visible = false;
                this.WarehouseGuide_Button_Ed.Visible = false;
                this.WarehouseCode_Label.Visible = false;

                // --- ADD 2010/02/20 ---------->>>>>
                this.tEdit_WarehouseCode_St.DataText = "";
                this.tEdit_WarehouseCode_Ed.DataText = "";
                this.tEdit_WarehouseName_St.DataText = "";
                this.tEdit_WarehouseName_Ed.DataText = "";
                // --- ADD 2010/02/20 ----------<<<<<

                //倉庫コード 01～10
                for (int index = 0; index < this._warehouseCodeArray.Length; index++)
                {
                    this._warehouseCodeArray[index].Visible = true;
                }

                // 倉庫ガイド(単独指定用)
                this.WarehouseGuide_Button_Array.Visible = true;
            }
        }
        #endregion 倉庫指定区分変更イベント

        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/04/13 -------------------------------->>>>>
        #region 棚番の入力制御
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        #endregion
        //-----ADD 2011/01/11----->>>>>
        /// <summary>
        /// 管理拠点(開始)ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 管理拠点(開始)ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// </remarks>  
        private void uButton_SectionGuide_St_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNEdit_SectionCode_St.Text = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionNm_St.Text = secInfoSet.SectionGuideNm;

                this.tNEdit_SectionCode_Ed.Focus();
            }
        }

        /// <summary>
        /// 管理拠点(終了)ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 管理拠点(終了)ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// </remarks>  
        private void uButton_SectionGuide_Ed_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNEdit_SectionCode_Ed.Text = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionNm_Ed.Text = secInfoSet.SectionGuideNm;

                this.tEdit_WarehouseShelfNo_St.Focus();
            }
        }
        //-----ADD 2011/01/11-----<<<<<
        // --- ADD 2009/04/13 --------------------------------<<<<<
        # endregion

    }
}

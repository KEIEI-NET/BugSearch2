//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸数入力 抽出条件入力画面クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 作 成 日  2007.04.06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007.07.25  修正内容 : 編集機能追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008.02.14  修正内容 : 棚卸実施日対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/01  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13109
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/01/11  修正内容 : 貸出分の印刷がされない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  2015/04/27 修正内容 : Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加
//                                  Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸数入力 抽出条件入力画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 棚卸数入力 抽出条件入力画面クラス</br>
	/// <br>Programmer	: 22013 kubo</br>
	/// <br>Date		: 2007.04.06</br>
	/// <br>Update Note	: 2007.07.25 22013 kubo</br>
	/// <br>			:	・編集機能追加</br>
    /// <br>Update Note : 2008.02.14 980035 金沢 貞義</br>
    /// <br>			    ・棚卸実施日対応（DC.NS対応）</br>
    /// <br>Update Note : 2008/09/01 30414 忍 幸史</br>
    /// <br>			    ・Partsman用に変更</br>
    /// <br>Update Note : 2009/04/13 30452 上野 俊治</br>
    /// <br>			    ・障害対応13109</br>
    /// <br>            : 2009/05/14       照田 貴志　不具合対応[13260]</br>
    /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
    /// <br>             貸出分の印刷がされない不具合の修正</br>
    /// </remarks>
	public partial class MAZAI05130UA : Form, IInventInputMdiChild
	{
		#region ■ Constructor
		/// <summary>
		/// 棚卸数入力 抽出条件入力画面クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸数入力 抽出条件入力画面クラスのインスタンスを作成</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public MAZAI05130UA ()
		{
			InitializeComponent();

			this._inventInputAcs = new InventInputAcs();	// 棚卸データアクセスクラス

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            this._inventoryPrepareAcs = new InventoryPrepareAcs();  // 棚卸準備処理アクセスクラス
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            this._warehouseGuideAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._makerAcs = new MakerAcs();
            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
		#endregion ■ Constructor

		#region ■ Private Member
		// IInventInputMdiChild メンバ用 変数 ---------------------------------------
		private string _enterpriseCode	= "";		// 企業コード
		private string _sectionCode		= "";		// 拠点コード
		private string _sectionName		= "";		// 拠点名称
		private bool _isCansel			= false;	// 取消ボタンEnabled
		private bool _isSave			= false;	// 保存ボタンEnabled
		private bool _isExtract			= true;		// 抽出ボタンEnabled
		private bool _isNewInvent		= false;	// 新規ボタンEnabled
		private bool _isDetail			= false;	// 詳細ボタンEnabled
		private bool _isBarcodeRead		= false;	// バーコード読込ボタンEnabled
		// 2007.07.25 kubo add
		private bool _isDataEdit		= false;	// 編集ボタンEnabled
        private bool _isGoodsSearch = false;	// 品番検索ボタンEnabled(true:品番検索ボタンクリックができる　false:品番検索ボタンクリックができない) // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加
		internal InventInputAcs _inventInputAcs;		// 棚卸数入力アクセスクラス

 		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
        ////商品ガイド
        //private MAKHN04110UA _goodsGuide;
        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //得意先情報アクセスクラス
        private CustomerInfoAcs _customerInfoAcs;
		private string _customerTag;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        // 倉庫マスタアクセスクラス
        private WarehouseAcs _warehouseGuideAcs;

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //商品大分類マスタアクセスクラス
        private LGoodsGanreAcs _lGoodsGanreAcs = null;
        //商品中分類マスタアクセスクラス
        private MGoodsGanreAcs _mGoodsGanreAcs = null;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        //// キャリアアクセスクラス
		//private CarrierOdrAcs _carrierOdrAcs = null;
		//// 事業者アクセスクラス
		//private CarrierEpAcs _carrierEpAcs = null;
		//// 機種ガイド
		//private CellphoneModelAcs _cellphoneModelAcs = null;

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        // 商品区分詳細ガイド起動
        private DGoodsGanreAcs _dGoodsGanreAcs = null;   
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        // ＢＬコードマスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        ///ユーザーガイドマスタアクセスクラス（自社分類）
        private UserGuideGuide _userGuideGuide = null;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        // メーカーマスタアクセスクラス
		private MakerAcs _makerAcs = null;

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        // 仕入先マスタアクセスクラス
        private SupplierAcs _supplierAcs = null;

        // グループコードマスタアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
        // 棚卸準備処理アクセスクラス
        private InventoryPrepareAcs _inventoryPrepareAcs = null;
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion ■ Private Member

		#region ■ Private Const
		private const string ct_ClassID		= "MAZAI05130U";			// アセンブリＩＤまたはクラスＩＤ
		private const string ct_PrintName	= "棚卸入力 抽出条件画面";	// プログラム名称

		#endregion

		#region ■ IInventInputMdiChild メンバ
		#region IInventInputMdiChild メンバ
		/// <summary>
		/// ツールバー設定
		/// </summary>
        public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
        #endregion
		
        #region ◆ Public Property
		/// <summary> 企業コードプロパティ </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> 拠点コードプロパティ </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> 拠点名称プロパティ </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> 取消ボタンEnabledプロパティ </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> 保存ボタンEnabledプロパティ </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> 抽出ボタンEnabledプロパティ </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> 新規ボタンEnabledプロパティ </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> バーコード読込ボタンEnabledプロパティ </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加 ----->>>>>
        /// <summary> 品番検索ボタンEnabledプロパティ (true:品番検索ボタンクリックができる　false:品番検索ボタンクリックができない)</summary>
        public bool IsGoodsSearch
        {
            get { return this._isGoodsSearch; }
        }
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加 -----<<<<<
        #endregion ◆ Public Property

		#region ◆ Public Method

		#region ◎ 画面表示処理
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ タブ変更前処理
		/// <summary>
		/// タブ変更前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 終了前処理
		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 終了前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 取消前処理
		/// <summary>
		/// 取消前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 取消処理
		/// <summary>
		/// 取消処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 抽出前処理
		/// <summary>
		/// 抽出前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			// Todo:抽出前の入力整合性チェックを行う
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// メッセージを表示
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// コントロールにフォーカスをセット
				if( errComponent != null ) 
                {
                    if ((this.tEdit_WarehouseCode_St.DataText.Trim() == "") ||
                        (int.Parse(this.tEdit_WarehouseCode_St.DataText.Trim()) == 0))
                    {
                        this.tEdit_WarehouseName_St.Clear();
                    }
                    if ((this.tEdit_WarehouseCode_Ed.DataText.Trim() == "") ||
                        (int.Parse(this.tEdit_WarehouseCode_Ed.DataText.Trim()) == 0))
                    {
                        this.tEdit_WarehouseName_Ed.Clear();
                    }
                    if (this.tNedit_SupplierCd_St.GetInt() == 0)
                    {
                        this.tEdit_SupplierName_St.Clear();
                    }
                    if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
                    {
                        this.tEdit_SupplierName_Ed.Clear();
                    }
                    if (this.tNedit_BLGoodsCode_St.GetInt() == 0)
                    {
                        this.tEdit_BLGoodsName_St.Clear();
                    }
                    if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                    {
                        this.tEdit_BLGoodsName_Ed.Clear();
                    }
                    if (this.tNedit_BLGloupCode_St.GetInt() == 0)
                    {
                        this.tEdit_BLGloupName_St.Clear();
                    }
                    if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
                    {
                        this.tEdit_BLGloupName_Ed.Clear();
                    }
                    if (this.tNedit_GoodsMakerCd_St.GetInt() == 0)
                    {
                        this.tEdit_GoodsMakerName_St.Clear();
                    }
                    if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                    {
                        this.tEdit_GoodsMakerName_Ed.Clear();
                    }
					errComponent.Focus();
				}
			}
			else
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}

			return status;
		}
		#endregion

		#region ◎ 抽出処理
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int Extract (ref object parameter )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			string errMsg = "";

			InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();

			//SFCMN00299CA msgForm = new SFCMN00299CA();
			//// 抽出中画面部品のインスタンスを作成
			//msgForm.Title  = "抽出中";
			//msgForm.Message = "棚卸データの抽出中です。";

			try
			{
				//msgForm.Show();	// ダイアログ表示
				// 画面→抽出条件クラス
				status = this.SetExtraInfo( inventInputSearchCndtn );
				if( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, "抽出条件の取得に失敗しました", status );
					return status;
				}

				// Todo:アクセスクラスの抽出処理を実行
				status = this._inventInputAcs.SearchInvent( inventInputSearchCndtn, out errMsg );
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						parameter = inventInputSearchCndtn;
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						this.MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, errMsg, status );
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
						this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
						break;
				}

			}
			catch ( Exception ex )
			{
				this.MsgDispProc( "抽出処理に失敗しました", (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "Extract", ex );
			}
			finally
			{
				//msgForm.Close();
			}

            parameter = inventInputSearchCndtn;
			return status;
		}
		#endregion

		#region ◎ 新規処理
		/// <summary>
		/// 新規処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 新規処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return 0;
		}
		#endregion

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加 ----->>>>>
        #region ◎ 品番検索
        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 品番検索を行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        public int GoodsSearch(object parameter)
        {
            return 0;　// インタフェースのメソッドのために、このメソッドは何にも処理を行いません
        }
        #endregion
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加 -----<<<<<

        // --- ADD 陳嘯 2015/04/27 Redmine#45747 閉じる前チェック ----->>>>>
        #region ◎ 閉じる前チェック
        /// <summary>
        /// 閉じる前チェック
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 閉じる前チェックを行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 閉じる前チェックを追加</br>
        /// </remarks>
        public bool ClosingCheck()
        {
            return true;　// インタフェースのメソッドのために、このメソッドは何にも処理を行いません
        }
        #endregion
        // --- ADD 陳嘯 2015/04/27 Redmine#45747 閉じる前チェック -----<<<<<

        // ---ADD 2009/05/14 不具合対応[13260] -------------->>>>>
        #region  ◎ 保存前処理
        /// <summary>
        /// 保存前処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>Status　※常に正常が返る</returns>
        /// <remarks>
        /// <br>Note       : 保存前処理を行う</br>
        /// <br>Programer  : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks>
        public int BeforeSave(object parameter)
        {
            return 0;
        }
        #endregion
        // ---ADD 2009/05/14 不具合対応[13260] -------------->>>>>

		#region ◎ 保存処理
		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 詳細表示処理
		/// <summary>
		/// 詳細表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 詳細表示処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ バーコード読込処理
		/// <summary>
		/// バーコード読込処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : バーコード読込処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.06</br>
		/// </remarks>
		public int BarcodeRead ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 編集処理
		/// <summary>
		/// 編集処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 編集処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return 0;
		}
		#endregion

		#endregion ◆ Public Method
		#endregion ■ IInventInputMdiChild メンバ

		#region ■ Private Method
        #region ◎ 初期処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns>Status : int(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note       : UIの初期化処理を行う。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸日の初期表示方法の変更</br>
        /// </remarks>
        private int InitializeSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // コントロールサイズ設定
            this.tEdit_WarehouseCode_St.Size = new Size(68, 24);
            this.tEdit_WarehouseName_St.Size = new Size(171, 24);
            this.tEdit_WarehouseCode_Ed.Size = new Size(68, 24);
            this.tEdit_WarehouseName_Ed.Size = new Size(171, 24);
            this.tEdit_WarehouseShelfNo_St.Size = new Size(84, 24);
            this.tEdit_WarehouseShelfNo_Ed.Size = new Size(84, 24);
            this.tNedit_SupplierCd_St.Size = new Size(68, 24);
            this.tEdit_SupplierName_St.Size = new Size(171, 24);
            this.tNedit_SupplierCd_Ed.Size = new Size(68, 24);
            this.tEdit_SupplierName_Ed.Size = new Size(171, 24);
            this.tNedit_BLGoodsCode_St.Size = new Size(68, 24);
            this.tEdit_BLGoodsName_St.Size = new Size(171, 24);
            this.tNedit_BLGoodsCode_Ed.Size = new Size(68, 24);
            this.tEdit_BLGoodsName_Ed.Size = new Size(171, 24);
            this.tNedit_BLGloupCode_St.Size = new Size(68, 24);
            this.tEdit_BLGloupName_St.Size = new Size(171, 24);
            this.tNedit_BLGloupCode_Ed.Size = new Size(68, 24);
            this.tEdit_BLGloupName_Ed.Size = new Size(171, 24);
            this.tNedit_GoodsMakerCd_St.Size = new Size(68, 24);
            this.tEdit_GoodsMakerName_St.Size = new Size(171, 24);
            this.tNedit_GoodsMakerCd_Ed.Size = new Size(68, 24);
            this.tEdit_GoodsMakerName_Ed.Size = new Size(171, 24);



            // ボタンアイコン設定
            SetButtonImage(this.WarehouseGuideSt_Button, Size16_Index.STAR1);  // 倉庫ガイド(開始)
            SetButtonImage(this.WarehouseGuideEd_Button, Size16_Index.STAR1);  // 倉庫ガイド(終了)
            SetButtonImage(this.MakerGuideSt_Button, Size16_Index.STAR1);       // メーカーガイド(開始)
            SetButtonImage(this.MakerGuideEd_Button, Size16_Index.STAR1);      // メーカーガイド(終了)
            SetButtonImage(this.BlGroupGuideSt_Button, Size16_Index.STAR1);     // グループコードガイド(開始)
            SetButtonImage(this.BlGroupGuideEd_Button, Size16_Index.STAR1);     // グループコードガイド(終了)
            SetButtonImage(this.BLGoodsGuideSt_Button, Size16_Index.STAR1);     // BLコードガイド(開始)
            SetButtonImage(this.BLGoodsGuideEd_Button, Size16_Index.STAR1);     // BLコードガイド(終了)
            SetButtonImage(this.SupplierGuideSt_Button, Size16_Index.STAR1);	// 仕入先ガイド(開始)
            SetButtonImage(this.SupplierGuideEd_Button, Size16_Index.STAR1);   // 仕入先ガイド(終了)

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            // 画面初期化
            ClearScreen();

            // 抽出対象に「数未入力分のみ」セット
            this.DifCntExtraDiv_tComboEditor.Value = 1;

            // 対象年月日に最終棚卸準備処理日付をセット（履歴データ取得）
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            DataView dvSection = new DataView(); // ADD 2009/12/03

            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            dvSection.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table]; // ADD 2009/12/03

            // --- DEL 2009/12/03 ---------->>>>>
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3)
            //    {
            //        continue;
            //    }
            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
            //    {
            //        this.InventoryDay_TDateEdit.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
            //        break;
            //    }
            //}
            // --- DEL 2009/12/03 ----------<<<<<

            // --- ADD 2009/12/03 ---------->>>>>
            // ログイン拠点
            dvSection.RowFilter = String.Format("{0}={1}", InventoryPrepareAcs.ctSectionCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            // ソート順：更新日付
            dvSection.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";
            // ログイン拠点に該当するデータ有り：ログイン拠点に該当する最新データから棚卸日を取得
            if (dvSection.Count > 0)
            {
                foreach (DataRowView drv in dvSection)
                {
                    // 削除した履歴データは対象外
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.InventoryDay_TDateEdit.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ログイン拠点に該当するデータ無し：拠点に関係なく最新データから棚卸日を取得
            else
            {
                // ソート順：更新日付
                dv.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";

                for (int ix = 0; ix < dv.Count; ix++)
                {
                    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3)
                    {
                        continue;
                    }
                    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.InventoryDay_TDateEdit.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // --- ADD 2009/12/03 ----------<<<<<

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns>Status : int(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note       : UIの初期化処理を行う。</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private int InitializeSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            // ボタンアイコン設定
            this.SetButtonImage(this.WarehouseGuideSt_Button, Size16_Index.STAR1);	// 倉庫ガイド
            this.SetButtonImage(this.WarehouseGuideEd_Button, Size16_Index.STAR1);
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //this.SetButtonImage( this.ub_St_GoodsGuide                , Size16_Index.STAR1);	//	商品ガイド
            //this.SetButtonImage( this.ub_Ed_GoodsGuide				, Size16_Index.STAR1 );
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //this.SetButtonImage(this.ub_St_CarrierCodeGuide       , Size16_Index.STAR1);	//	キャリアガイド
            //this.SetButtonImage( this.ub_Ed_CarrierCodeGuide		, Size16_Index.STAR1 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            this.SetButtonImage(this.MakerGuideSt_Button, Size16_Index.STAR1);	//	メーカーガイド
            this.SetButtonImage(this.MakerGuideEd_Button, Size16_Index.STAR1);
            this.SetButtonImage(this.ub_St_LargeGoodsGanreGuide, Size16_Index.STAR1);	//	商品大分類ガイド
            this.SetButtonImage(this.ub_Ed_LargeGoodsGanreGuide, Size16_Index.STAR1);
            this.SetButtonImage(this.ub_St_MediumGoodsGanreGuide, Size16_Index.STAR1);	//	商品中分類ガイド
            this.SetButtonImage(this.ub_Ed_MediumGoodsGanreGuide, Size16_Index.STAR1);
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.SetButtonImage(this.ub_St_CarrierEpGuide             , Size16_Index.STAR1);	//	事業者ガイド
            //this.SetButtonImage( this.ub_Ed_CarrierEpGuide			, Size16_Index.STAR1 );
            this.SetButtonImage(this.BlGroupGuideSt_Button, Size16_Index.STAR1);	//	商品区分詳細ガイド
            this.SetButtonImage(this.BlGroupGuideEd_Button, Size16_Index.STAR1);
            this.SetButtonImage(this.BLGoodsGuideSt_Button, Size16_Index.STAR1);	//	ＢＬコードガイド
            this.SetButtonImage(this.BLGoodsGuideEd_Button, Size16_Index.STAR1);
            this.SetButtonImage(this.ub_St_EnterpriseGanreGuide, Size16_Index.STAR1);	//	自社分類ガイド
            this.SetButtonImage(this.ub_Ed_EnterpriseGanreGuide, Size16_Index.STAR1);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            this.SetButtonImage(this.SupplierGuideSt_Button, Size16_Index.STAR1);	//	仕入先ガイド
            this.SetButtonImage(this.SupplierGuideEd_Button, Size16_Index.STAR1);
            this.SetButtonImage(this.ub_St_ShipCustomerCodeGuid, Size16_Index.STAR1);	//	仕入先ガイド
            this.SetButtonImage(this.ub_Ed_ShipCustomerCodeGuid, Size16_Index.STAR1);
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //this.SetButtonImage(this.ub_St_CellphoneModelGuide        , Size16_Index.STAR1);	//	機種ガイド
            //this.SetButtonImage( this.ub_Ed_CellphoneModelGuide		, Size16_Index.STAR1 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 対象年月日に最終棚卸準備処理日付をセット（履歴データ取得）
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];

            for (int ix = 0; ix < dv.Count; ix++)
            {
                if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
                    ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                {
                    this.InventoryDay_TDateEdit.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
                    break;
                }
            }
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<


            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             貸出分の印刷がされない不具合の修正</br>
        private void ClearScreen()
        {
            this.InventoryDay_TDateEdit.SetDateTime(new DateTime());
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_WarehouseName_St.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseName_Ed.Clear();
            this.tEdit_WarehouseShelfNo_St.Clear();
            this.tEdit_WarehouseShelfNo_Ed.Clear();
            this.tNedit_SupplierCd_St.Clear();
            this.tEdit_SupplierName_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            this.tEdit_SupplierName_Ed.Clear();
            this.tNedit_BLGoodsCode_St.Clear();
            this.tEdit_BLGoodsName_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();
            this.tEdit_BLGoodsName_Ed.Clear();
            this.tNedit_BLGloupCode_St.Clear();
            this.tEdit_BLGloupName_St.Clear();
            this.tNedit_BLGloupCode_Ed.Clear();
            this.tEdit_BLGloupName_Ed.Clear();
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tEdit_GoodsMakerName_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            this.tEdit_GoodsMakerName_Ed.Clear();
            //---ADD 2011/01/11----------------------->>>>>
            // 貸出分
            this.tComboEditor_LendExtraDiv.Value = 0;
            // 来勘計上分
            this.tComboEditor_DelayPaymentDiv.Value = 0;
            //---ADD 2011/01/11-----------------------<<<<<
        }
        #endregion ◎ 画面初期化処理

        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingButton">アイコンをセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note       : ボタンのアイコンを設定する</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void SetButtonImage(UltraButton settingButton, Size16_Index iconIndex)
        {
            settingButton.ImageList = IconResourceManagement.ImageList16;
            settingButton.Appearance.Image = iconIndex;
        }
        #endregion

        #region ◎ 初期タイマー処理
        /// <summary>
        /// 初期タイマー処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 初期タイマー内で行う初期化処理を実行</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.09</br>
        /// </remarks>
        private int InitializeTimerSetting(out string errMsg)
        {
            // 初期化処理の中でも時間がかかるものを行う。
            // また、DBアクセスが走る初期化もここで処理を行う。

            // キャリアツリー初期化処理
            errMsg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

		#region ◆ 印刷前処理
		#region ◎ 抽出条件設定処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 抽出条件設定処理
		/// </summary>
		/// <param name="inventInputSearchCndtn">棚卸数入力抽出条件クラス</param>
		/// <remarks>
		/// <br>Note       : 棚卸数入力の抽出条件を設定する</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             貸出分の印刷がされない不具合の修正</br>
        /// </remarks>
		private int SetExtraInfo(InventInputSearchCndtn inventInputSearchCndtn)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // 企業コード
            inventInputSearchCndtn.EnterpriseCode = this._enterpriseCode;
            inventInputSearchCndtn.InventoryDate = this.InventoryDay_TDateEdit.GetDateTime();
            // 差異分抽出区分        
            inventInputSearchCndtn.DifCntExtraDiv = (int)this.DifCntExtraDiv_tComboEditor.Value;
            // 倉庫コード
            if (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != "")
            {
                inventInputSearchCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                inventInputSearchCndtn.St_WarehouseCode = "";
            }
            if (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != "")
            {
                inventInputSearchCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                inventInputSearchCndtn.Ed_WarehouseCode = "";
            }
            // 棚番
            inventInputSearchCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText.Trim();    
            inventInputSearchCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText.Trim(); 
            // 仕入先コード
            inventInputSearchCndtn.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();                      
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_SupplierCd = 999999;
            }
            else
            {
                inventInputSearchCndtn.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
            }
            // BLコード
            inventInputSearchCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_BLGoodsCode = 99999;
            }
            else
            {
                inventInputSearchCndtn.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            }
            // グループコード
            inventInputSearchCndtn.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
            if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_BLGroupCode = 99999;
            }
            else
            {
                inventInputSearchCndtn.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
            }
            // メーカーコード
            inventInputSearchCndtn.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_MakerCode = 9999;
            }
            else
            {
                inventInputSearchCndtn.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
            }
            // 通番
            //inventInputSearchCndtn.St_InventorySeqNo = 0;                 //DEL 2009/05/14 不具合対応[13260]
            //inventInputSearchCndtn.Ed_InventorySeqNo = 999999;            //DEL 2009/05/14 不具合対応[13260]
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------->>>>>
            inventInputSearchCndtn.St_InventorySeqNo = this.tNedit_InventorySeqNo_St.GetInt();
            if (this.tNedit_InventorySeqNo_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_InventorySeqNo = 99999999;
            }
            else
            {
                inventInputSearchCndtn.Ed_InventorySeqNo = this.tNedit_InventorySeqNo_Ed.GetInt();
            }
            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------------<<<<<

            //
			// 固定項目 (リモートでは無視される) ------------------------------------------------------------
            //
			// 帳簿数ゼロ抽出区分
			inventInputSearchCndtn.StockCntZeroExtraDiv = 0;
			// 準備処理日付
			inventInputSearchCndtn.St_InventoryPreprDay = DateTime.MinValue;
			inventInputSearchCndtn.Ed_InventoryPreprDay = DateTime.MinValue;
            // 棚卸数抽出区分(全て)
			inventInputSearchCndtn.IvtStkCntZeroExtraDiv = 0;
            // 帳票種別(棚卸記入表)
			inventInputSearchCndtn.SelectedPaperKind = -1;
            // 抽出対象日付区分(棚卸準備処理日付)
			inventInputSearchCndtn.TargetDateExtraDiv = -1;

            //---ADD 2011/01/11----------------------->>>>>
            // 貸出抽出区分
            inventInputSearchCndtn.LendExtraDiv = (int)this.tComboEditor_LendExtraDiv.Value;

            // 来勘計上抽出区分
            inventInputSearchCndtn.DelayPaymentDiv = (int)this.tComboEditor_DelayPaymentDiv.Value;
            //---ADD 2011/01/11-----------------------<<<<<


			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 抽出条件設定処理
        /// </summary>
        /// <param name="inventInputSearchCndtn">棚卸数入力抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 棚卸数入力の抽出条件を設定する</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private int SetExtraInfo(InventInputSearchCndtn inventInputSearchCndtn)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // 企業コード
            inventInputSearchCndtn.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            inventInputSearchCndtn.SectionCode = this._sectionCode;

            // 差異分抽出区分
            inventInputSearchCndtn.DifCntExtraDiv = (int)this.DifCntExtraDiv_tComboEditor.Value;

            //// 通番
            //inventInputSearchCndtn.St_InventorySeqNo = this.tne_St_InventorySeqNo.GetInt();	// 開始
            //inventInputSearchCndtn.Ed_InventorySeqNo = this.tne_Ed_InventorySeqNo.GetInt();	// 終了
            inventInputSearchCndtn.St_InventorySeqNo = 0;		// 開始
            inventInputSearchCndtn.Ed_InventorySeqNo = 999999;	// 終了

            // 倉庫コード
            inventInputSearchCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.TrimEnd();	// 開始
            inventInputSearchCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.TrimEnd();	// 終了

            // 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.St_GoodsCode = this.te_St_GoodsCode.DataText.TrimEnd();	// 開始
            //inventInputSearchCndtn.Ed_GoodsCode = this.te_Ed_GoodsCode.DataText.TrimEnd();	// 終了
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.St_GoodsNo = this.te_St_GoodsCode.DataText.TrimEnd();	// 開始
            //inventInputSearchCndtn.Ed_GoodsNo = this.te_Ed_GoodsCode.DataText.TrimEnd();	// 終了
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// キャリアコード
            //inventInputSearchCndtn.St_CarrierCode = this.tne_St_CarrierCode.GetInt();	// 開始
            //inventInputSearchCndtn.Ed_CarrierCode = this.tne_Ed_CarrierCode.GetInt();	// 終了
            //
            //// 事業者コード
            //inventInputSearchCndtn.St_CarrierEpCode	= this.tne_St_CarrierEpCode.GetInt();	// 開始
            //inventInputSearchCndtn.Ed_CarrierEpCode	= this.tne_Ed_CarrierEpCode.GetInt();	// 終了
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // メーカーコード
            inventInputSearchCndtn.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();	// 開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();	// 終了
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_MakerCode = 999999;                   	    // 終了
            }
            else
            {
                inventInputSearchCndtn.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();	// 終了
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //inventInputSearchCndtn.St_CellphoneModelCode = this.te_St_CellphoneModelCode.DataText.TrimEnd();	// 開始
            //inventInputSearchCndtn.Ed_CellphoneModelCode = this.te_Ed_CellphoneModelCode.DataText.TrimEnd();	// 終了

            // グループコード
            inventInputSearchCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.DataText.TrimEnd();	// 開始
            inventInputSearchCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.DataText.TrimEnd();	// 終了

            // ＢＬコード
            inventInputSearchCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();	// 開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();	// 終了
            if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_BLGoodsCode = 99999999;                           // 終了
            }
            else
            {
                inventInputSearchCndtn.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();	// 終了
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 自社分類コード
            inventInputSearchCndtn.St_EnterpriseGanreCode = this.tne_St_EnterpriseGanreCode.GetInt();	// 開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_EnterpriseGanreCode = this.tne_Ed_EnterpriseGanreCode.GetInt();	// 終了
            if (this.tne_Ed_EnterpriseGanreCode.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_EnterpriseGanreCode = 9999;                                       // 終了
            }
            else
            {
                inventInputSearchCndtn.Ed_EnterpriseGanreCode = this.tne_Ed_EnterpriseGanreCode.GetInt();	// 終了
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 商品大分類コード
            inventInputSearchCndtn.St_LargeGoodsGanreCode = this.te_St_LargeGoodsGanreCode.DataText;	// 開始
            inventInputSearchCndtn.Ed_LargeGoodsGanreCode = this.te_Ed_LargeGoodsGanreCode.DataText;	// 終了

            // 商品中分類コード
            inventInputSearchCndtn.St_MediumGoodsGanreCode = this.te_St_MediumGoodsGanreCode.DataText;	// 開始
            inventInputSearchCndtn.Ed_MediumGoodsGanreCode = this.te_Ed_MediumGoodsGanreCode.DataText;	// 終了

            // 仕入先コード
            inventInputSearchCndtn.St_CustomerCode = this.tNedit_SupplierCd_St.GetInt();	// 開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_CustomerCode = this.tNedit_SupplierCd_Ed.GetInt();	// 終了
            if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_CustomerCode = 999999999;                         // 終了
            }
            else
            {
                inventInputSearchCndtn.Ed_CustomerCode = this.tNedit_SupplierCd_Ed.GetInt();	// 終了
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 委託先コード
            inventInputSearchCndtn.St_ShipCustomerCode = this.tne_St_ShipCustomerCode.GetInt();	// 開始
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_ShipCustomerCode = this.tne_Ed_ShipCustomerCode.GetInt();	// 終了
            if (this.tne_Ed_ShipCustomerCode.GetInt() == 0)
            {
                inventInputSearchCndtn.Ed_ShipCustomerCode = 999999999;                             // 終了
            }
            else
            {
                inventInputSearchCndtn.Ed_ShipCustomerCode = this.tne_Ed_ShipCustomerCode.GetInt();	// 終了
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 棚卸実地日
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.St_InventoryDay = this.InventoryDay_TDateEdit.GetDateTime();	// 開始
            inventInputSearchCndtn.InventoryDate = this.InventoryDay_TDateEdit.GetDateTime();
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //inventInputSearchCndtn.Ed_InventoryDay = this.tde_Ed_InventoryDay.GetDateTime();	// 終了
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 自社在庫抽出区分
            //if ( this.uce_StockDiv_Company.Checked )
            //	inventInputSearchCndtn.CompanyStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;		// 抽出する
            //else
            //	inventInputSearchCndtn.CompanyStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.NotExtra;	// 抽出しない
            //
            //// 受託在庫抽出区分
            //if ( this.uce_StockDiv_Trust.Checked )
            //	inventInputSearchCndtn.TrustStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;		// 抽出する
            //else
            //	inventInputSearchCndtn.TrustStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.NotExtra;	// 抽出しない
            //
            //// 委託(自社)在庫抽出区分
            //if ( this.uce_StockDiv_EntrustCmp.Checked )
            //	inventInputSearchCndtn.EntrustCmpStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;		// 抽出する
            //else
            //	inventInputSearchCndtn.EntrustCmpStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.NotExtra;	// 抽出しない
            //
            //// 委託(受託)在庫抽出区分
            //if ( this.uce_StockDiv_EntrustTrt.Checked )
            //	inventInputSearchCndtn.EntrustTrtStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;		// 抽出する
            //else
            //	inventInputSearchCndtn.EntrustTrtStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.NotExtra;	// 抽出しない
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<


            // 固定項目 (リモートでは無視される) ------------------------------------------------------------
            // 帳簿数ゼロ抽出区分
            inventInputSearchCndtn.StockCntZeroExtraDiv = 0;

            // 準備処理日付
            inventInputSearchCndtn.St_InventoryPreprDay = DateTime.MinValue;
            inventInputSearchCndtn.Ed_InventoryPreprDay = DateTime.MinValue;

            // 棚卸数抽出区分
            inventInputSearchCndtn.IvtStkCntZeroExtraDiv = 0;	// 全て

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 集計単位
            //inventInputSearchCndtn.GrossPrintDiv = 0;	// 製番単位
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 帳票種別
            inventInputSearchCndtn.SelectedPaperKind = -1;	// 棚卸記入表

            // 抽出対象日付区分
            inventInputSearchCndtn.TargetDateExtraDiv = -1;	// 棚卸準備処理日付

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 入力チェック処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コンポーネント</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
            // 棚卸日
            if (!this.DateEditInputCheck(this.InventoryDay_TDateEdit, false))
            {
                errMessage = "棚卸日の入力が不正です";
                errComponent = this.InventoryDay_TDateEdit;
                return (false);
            }
			// 倉庫
			if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != "") && (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0)
                {
                    errMessage = "倉庫コードの範囲指定に誤りがあります";
			        errComponent = this.tEdit_WarehouseCode_St;
                    return (false);
                }
            }
            // 棚番
            if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0)
                {
                    errMessage = "棚番の範囲指定に誤りがあります";
                    errComponent = this.tEdit_WarehouseShelfNo_St;
                    return (false);
                }
            }
            // 仕入先
            if ((this.tNedit_SupplierCd_St.GetInt() != 0) && (this.tNedit_SupplierCd_Ed.GetInt() != 0))
            {
                if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
                {
                    errMessage = "仕入先コードの範囲指定に誤りがあります";
                    errComponent = this.tNedit_SupplierCd_St;
                    return (false);
                }
            }
            // ＢＬコード
            if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) && (this.tNedit_BLGoodsCode_Ed.GetInt() != 0))
            {
                if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
                {
                    errMessage = "BLｺｰﾄﾞの範囲指定に誤りがあります";
                    errComponent = this.tNedit_BLGoodsCode_St;
                    return (false);
                }
            }
            // グループコード
            if ((this.tNedit_BLGloupCode_St.GetInt() != 0) && (this.tNedit_BLGloupCode_Ed.GetInt() != 0))
            {
                if (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt())
                {
                    errMessage = "ｸﾞﾙｰﾌﾟｺｰﾄﾞの範囲指定に誤りがあります";
                    errComponent = this.tNedit_BLGloupCode_St;
                    return (false);
                }
            }
            // メーカーコード
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {
                    errMessage = "メーカーコードの範囲指定に誤りがあります";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    return (false);
                }
            }

            return (true);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.09</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_InputError = "の入力が不正です";
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //const string ct_NoSelect = "を選択して下さい";
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            const string ct_RangeError = "の範囲指定に誤りがあります";

            //// 棚卸通番
            //if ( this.tne_St_InventorySeqNo.GetInt() > this.tne_Ed_InventorySeqNo.GetInt() )
            //{
            //    errMessage		= string.Format( "棚卸通番{0}", ct_RangeError );
            //    errComponent	= this.tne_St_InventorySeqNo;
            //    status			= false;
            //}
            // 倉庫コード
            if (
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("倉庫コード{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 品番
            //else if (
            //    ( this.te_St_GoodsCode.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_GoodsCode.DataText.TrimEnd() != string.Empty )&&
            //    ( this.te_St_GoodsCode.DataText.TrimEnd().CompareTo( this.te_Ed_GoodsCode.DataText.TrimEnd() ) > 0 ) )
            //{
            //    errMessage		= string.Format( "品番{0}", ct_RangeError );
            //    errComponent	= this.te_St_GoodsCode;
            //    status			= false;
            //}
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// キャリアコード
            //else if ( this.tne_St_CarrierCode.GetInt() > this.tne_Ed_CarrierCode.GetInt() )
            //{
            //    errMessage		= string.Format( "キャリアコード{0}", ct_RangeError );
            //    errComponent	= this.tne_St_CarrierCode;
            //    status			= false;
            //}
            //// 事業者コード
            //else if ( this.tne_St_CarrierEpCode.GetInt() > this.tne_Ed_CarrierEpCode.GetInt() )
            //{
            //    errMessage		= string.Format( "事業者コード{0}", ct_RangeError );
            //    errComponent	= this.tne_St_CarrierEpCode;
            //    status			= false;
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // メーカーコード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //else if ( this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt() )
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                     (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                     (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                errMessage = string.Format("メーカーコード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //else if (
            //    ( this.te_St_CellphoneModelCode.DataText.TrimEnd() != string.Empty ) && 
            //    ( this.te_Ed_CellphoneModelCode.DataText.TrimEnd() != string.Empty )&&
            //    ( this.te_St_CellphoneModelCode.DataText.TrimEnd().CompareTo( this.te_Ed_CellphoneModelCode.DataText.TrimEnd() ) > 0 ) )
            //{
            //    errMessage		= string.Format( "機種コード{0}", ct_RangeError );
            //    errComponent	= this.te_St_CellphoneModelCode;
            //    status			= false;
            //}
            // グループコード
            else if (
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("商品区分詳細{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // ＢＬコード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //else if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            else if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                     (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                     (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 自社分類コード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //else if (this.tne_St_EnterpriseGanreCode.GetInt() > this.tne_Ed_EnterpriseGanreCode.GetInt())
            else if ((this.tne_St_EnterpriseGanreCode.GetInt() != 0) &&
                     (this.tne_Ed_EnterpriseGanreCode.GetInt() != 0) &&
                     (this.tne_St_EnterpriseGanreCode.GetInt() > this.tne_Ed_EnterpriseGanreCode.GetInt()))
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                errMessage = string.Format("自社分類コード{0}", ct_RangeError);
                errComponent = this.tne_St_EnterpriseGanreCode;
                status = false;
            }
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
            else if (
                (this.te_St_LargeGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
                (this.te_Ed_LargeGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
                (this.te_St_LargeGoodsGanreCode.DataText.TrimEnd().CompareTo(this.te_Ed_LargeGoodsGanreCode.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("商品区分グループ{0}", ct_RangeError);
                errComponent = this.te_St_LargeGoodsGanreCode;
                status = false;
            }
            // 商品中分類コード(EnabledがTrueのときのみチェックをする)
            else if (
                (this.te_St_MediumGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
                (this.te_Ed_MediumGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
                (this.te_St_MediumGoodsGanreCode.DataText.TrimEnd().CompareTo(this.te_Ed_MediumGoodsGanreCode.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("商品区分{0}", ct_RangeError);
                errComponent = this.te_St_MediumGoodsGanreCode;
                status = false;
            }
            // 仕入先コード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //else if ( this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt() )
            else if ((this.tNedit_SupplierCd_St.GetInt() != 0) &&
                     (this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                     (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                errMessage = string.Format("仕入先コード{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // 委託先コード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //else if ( this.tne_St_ShipCustomerCode.GetInt() > this.tne_Ed_ShipCustomerCode.GetInt() )
            else if ((this.tne_St_ShipCustomerCode.GetInt() != 0) &&
                     (this.tne_Ed_ShipCustomerCode.GetInt() != 0) &&
                     (this.tne_St_ShipCustomerCode.GetInt() > this.tne_Ed_ShipCustomerCode.GetInt()))
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            {
                errMessage = string.Format("委託先コード{0}", ct_RangeError);
                errComponent = this.tne_St_ShipCustomerCode;
                status = false;
            }
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 開始棚卸日のチェック
            //if( !this.DateEditInputCheck( this.InventoryDay_TDateEdit, true ) )
            //{
            //    errMessage		= string.Format( "開始日{0}", ct_InputError );
            //    errComponent	= this.InventoryDay_TDateEdit;
            //    status			= false;
            //}
            //// 終了棚卸日のチェック
            //else if( !this.DateEditInputCheck( this.tde_Ed_InventoryDay, true ) )
            //{
            //    errMessage		= string.Format( "終了日{0}", ct_InputError );
            //    errComponent	= this.tde_Ed_InventoryDay;
            //    status			= false;
            //}
            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //else if( this.InventoryDay_TDateEdit.GetDateTime() != DateTime.MinValue && 
            //        this.tde_Ed_InventoryDay.GetDateTime() != DateTime.MinValue && 
            //        this.InventoryDay_TDateEdit.GetLongDate() > this.tde_Ed_InventoryDay.GetLongDate() )
            //{
            //    errMessage		= string.Format( "日付{0}", ct_RangeError );
            //    errComponent	= this.InventoryDay_TDateEdit;
            //    status			= false;
            //}
            // 棚卸日のチェック
            if (!this.DateEditInputCheck(this.InventoryDay_TDateEdit, false))
            {
                errMessage = string.Format("棚卸日{0}", ct_InputError);
                errComponent = this.InventoryDay_TDateEdit;
                status = false;
            }
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫抽出区分
            //else if ( !this.uce_StockDiv_Company.Checked && !this.uce_StockDiv_Trust.Checked && !this.uce_StockDiv_EntrustCmp.Checked && !this.uce_StockDiv_EntrustTrt.Checked )
            //{
            //    errMessage		= string.Format( "在庫抽出区分{0}", ct_NoSelect );
            //    errComponent	= this.uce_StockDiv_Company;
            //    status			= false;
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 日付入力チェック処理
        /// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="targetDateEdit">チェック対象コントロール</param>
		/// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
		/// <returns>チェック結果(true/false)</returns>
		/// <remarks>
		/// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
			bool status = true;

			// 入力日付を数値型で取得
			int date = targetDateEdit.GetLongDate();
			int yy = date / 10000;
			int mm = ( date / 100 ) % 100;
			int dd = date % 100;

			// 日付未入力チェック
			if( targetDateEdit.GetDateTime() == DateTime.MinValue )
			{
				if( allowEmpty == true ) 
				{
					return status;
				}
				else 
				{
					status = false;
				}
			}
			// システムサポートチェック
			else if( yy < 1900 )
			{
				status = false;
			}
			// 年月日別入力チェック
			else if( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
			{
				status = false;
			}
			// 単純日付妥当性チェック
			else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
			{
				status = false;
			}

			return status;
		}
		#endregion
		#endregion ◆ 印刷前処理

		#region ◆ メッセージ表示処理 ( +1のオーバーロード )
		#region ◎ メッセージ表示処理
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : メッセージの表示を行います。</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				"", 								// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		#endregion

		#region ◎ エラーメッセージ表示処理
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : 例外メッセージの表示を行います。</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				ct_PrintName,						// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		#endregion
		#endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

		#endregion ■ Private Method

        #region DEL
        #region ■ Private Event
        #region ◆ 商品大分類Leave処理
        ///// <summary>
		///// 商品大分類Leave処理
		///// </summary>
		//private void LargeGoodsGanreCode_Leave ( )
		//{
		//    // 商品大分類コードが等しいときのみ商品中分類コードの入力を可能にする
		//    if ( this.te_St_LargeGoodsGanreCode.GetInt() == this.te_Ed_LargeGoodsGanreCode.GetInt() )
		//    {
		//        this.ub_St_MediumGoodsGanreGuide.Enabled = true;
		//        this.ub_Ed_MediumGoodsGanreGuide.Enabled = true;
		//    }
		//    else
		//    {
		//        this.ub_St_MediumGoodsGanreGuide.Enabled = false;
		//        this.ub_Ed_MediumGoodsGanreGuide.Enabled = false;
		//    }
		//}
		#endregion
		#endregion ■ Private Event
        #endregion DEL

        #region ■ Control Event
        #region ◎ MAZAI05130UA_Load
        /// <summary>
        /// MAZAI05130UA_Load
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生する</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void MAZAI05130UA_Load(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                status = this.InitializeSetting();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 正常終了
                        break;
                    default:
                        // 異常のためメッセージ表示
                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "初期化処理に失敗しました", status);
                        break;
                }

                this.tm_InitialTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                this.MsgDispProc("初期化処理に失敗しました", (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "Load", ex);
            }
        }
        #endregion

        #region ◎ tm_InitialTimer_Tick
        /// <summary>
        /// 初期化タイマー起動処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定した時間が経過したとき発生する</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void tm_InitialTimer_Tick(object sender, EventArgs e)
        {
            this.tm_InitialTimer.Enabled = false;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = "";
            try
            {
                // タイマー初期処理起動
                status = this.InitializeTimerSetting(out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                }


                // 初期フォーカスセット
                this.DifCntExtraDiv_tComboEditor.Focus();
            }
            catch (Exception ex)
            {
                this.MsgDispProc("初期化処理に失敗しました", (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "Load", ex);
            }
        }
        #endregion

		#region ◆ GuideButton
		#region ◎ WarehouseGuide_Click
		/// <summary>
		/// WarehouseGuide_Click
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void WarehouseGuide_Click ( object sender, EventArgs e )
		{
			Warehouse warehouseData = null;

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._sectionCode);
                if (status == 0)
                {
                    if (warehouseData != null)
                    {
                        //コード、名称を展開
                        if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                        {
                            this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                            this.tEdit_WarehouseName_St.DataText = warehouseData.WarehouseName.Trim();

                            // フォーカス設定
                            this.tEdit_WarehouseCode_Ed.Focus();
                            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
                        }
                        else
                        {
                            this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                            this.tEdit_WarehouseName_Ed.DataText = warehouseData.WarehouseName.Trim();

                            // フォーカス設定
                            this.tEdit_WarehouseShelfNo_St.Focus();
                            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		#endregion

        #region 2008.02.14 削除
        #region ◎ GoodsGuide_Click
        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ub_St_GoodsGuide_Click
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsGuide_Click ( object sender, EventArgs e )
        //{
        //    GoodsUnitData goodsUnitData = null;         

        //    if ( this._goodsGuide == null ) this._goodsGuide = new MAKHN04110UA();

        //    DialogResult ret = this._goodsGuide.ShowGuide(this,this._enterpriseCode,out goodsUnitData);

        //    if(ret == DialogResult.OK)
        //    {
        //        if(goodsUnitData != null)
        //        {
        //            //コード、名称を展開
        //            if ( ( (UltraButton)sender ).Tag.ToString().CompareTo("1") == 0 )
        //            {
        //                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        //                //this.te_St_GoodsCode.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.te_St_GoodsCode.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        //            }
        //            else
        //            {
        //                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        //                //this.te_Ed_GoodsCode.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.te_Ed_GoodsCode.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        //            }
        //        }
        //    }         

        //}
        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion
        #endregion 2008.02.14 削除

        #region 2007.09.11 削除
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ CarrierCodeGuide_Click
		///// <summary>
		///// ub_St_CarrierCodeGuide_Click
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//private void ub_St_CarrierCodeGuide_Click ( object sender, EventArgs e )
		//{
		//	if ( this._carrierOdrAcs == null ) this._carrierOdrAcs = new CarrierOdrAcs();
        //
		//	Carrier carrier = null;
        //
		//	int status = this._carrierOdrAcs.ExecuteGuid( this._enterpriseCode, this._sectionCode,out carrier );
        //
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(carrier != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0)
        //                {
        //                    //開始
        //                    this.tne_St_CarrierCode.SetInt( carrier.CarrierCode );
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.tne_Ed_CarrierCode.SetInt( carrier.CarrierCode );
        //                }           
        //                          
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }      
		//}
		#endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.09.11 削除

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ CustomerGuide
		/// <summary>
		/// ub_St_CustomerGuide_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_CustomerGuide_Click ( object sender, EventArgs e )
		{
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			this._customerTag = ((UltraButton)sender).Tag.ToString();
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
		}
		#endregion

		#region ◎ ShipCustomerCodeGuid
		/// <summary>
		/// ShipCustomerCodeGuid_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_ShipCustomerCodeGuid_Click ( object sender, EventArgs e )
		{
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_ACCEPT_WHOLE_SALE, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_RECEIVER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            this._customerTag = ((UltraButton)sender).Tag.ToString();
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ShipCustomerSelect);
			customerSearchForm.ShowDialog(this);
		}
		#endregion

		#region ◎ LargeGoodsGanreGuide
		/// <summary>
		/// LargeGoodsGanreGuide_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_LargeGoodsGanreGuide_Click ( object sender, EventArgs e )
		{
            LGoodsGanre lGoodsGanre = null;
            if(this._lGoodsGanreAcs == null)
            {
                this._lGoodsGanreAcs = new LGoodsGanreAcs();               
            }
            //商品区分グループガイド起動
            int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(lGoodsGanre != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0)
                        {
                            //開始
                            this.te_St_LargeGoodsGanreCode.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
							// LargeGoodsGanreCode_Leave( );

                        }
                        else
                        {
                            //終了
                            this.te_Ed_LargeGoodsGanreCode.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
                            // LargeGoodsGanreCode_Leave( );
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

		#region ◎ ub_St_MediumGoodsGanreGuide_Click
		/// <summary>
		/// ub_St_MediumGoodsGanreGuide_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_MediumGoodsGanreGuide_Click ( object sender, EventArgs e )
		{
            MGoodsGanre mGoodsGanre = null;
            if(this._mGoodsGanreAcs == null)
            {
                this._mGoodsGanreAcs = new MGoodsGanreAcs();               
            }
            
            //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
            int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(mGoodsGanre != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
                        {
                            //開始
                            this.te_St_MediumGoodsGanreCode.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                        }
                        else
                        {
                            //終了
                            this.te_Ed_MediumGoodsGanreCode.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
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

        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◎ DetailGoodsGanreGuide
        /// <summary>
        /// DetailGoodsGanreGuide_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlGroupGuide_Click(object sender, EventArgs e)
        {
            DGoodsGanre dGoodsGanre = null;
            if(this._dGoodsGanreAcs == null)
            {
                this._dGoodsGanreAcs = new DGoodsGanreAcs();               
            }
            //商品区分詳細ガイド起動
            int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(dGoodsGanre != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0)
                        {
                            //開始
                            this.tNedit_BLGloupCode_St.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();

                        }
                        else
                        {
                            //終了
                            this.tNedit_BLGloupCode_Ed.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
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
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ BLGoodsGuide_Click
        /// <summary>
        /// BLGoodsGuide_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            try
            {
                this.Cursor = Cursors.WaitCursor;

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
                                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                                {
                                    //開始
                                    this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                    // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                                    this.tEdit_BLGoodsName_St.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                                    // フォーカス設定
                                    this.tNedit_BLGoodsCode_Ed.Focus();
                                    // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
                                }
                                else
                                {
                                    //終了
                                    this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                    // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                                    this.tEdit_BLGoodsName_Ed.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                                    // フォーカス
                                    this.tNedit_BLGloupCode_St.Focus();
                                    // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ EnterpriseGanreGuide_Click
        /// <summary>
        /// ub_St_EnterpriseGanreGuide_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EnterpriseGanreGuide_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd = null;
            if (this._userGuideGuide == null)
            {
                this._userGuideGuide = new UserGuideGuide();
            }

            //ユーザーガイド起動
            System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                if (userGdBd != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        //開始
                        this.tne_St_EnterpriseGanreCode.SetInt(userGdBd.GuideCode);
                    }
                    else
                    {
                        //終了
                        this.tne_Ed_EnterpriseGanreCode.SetInt(userGdBd.GuideCode);
                    }
                }
            }
        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

        #region 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ub_St_CarrierEpGuide_Click
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_CarrierEpGuide_Click ( object sender, EventArgs e )
        //{
        //	if ( this._carrierEpAcs == null ) this._carrierEpAcs = new CarrierEpAcs();
        //
        //	CarrierEp carrierEp = null;
        //
        //	int status = this._carrierEpAcs.ExecuteGuid( this._enterpriseCode, out carrierEp );
        //
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(carrierEp != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //                {
        //                    //開始
        //                    this.tne_St_CarrierEpCode.SetInt( carrierEp.CarrierEpCode );
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.tne_Ed_CarrierEpCode.SetInt( carrierEp.CarrierEpCode );
        //                }           
        //                          
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }      
        //}

        ///// <summary>
        ///// ub_St_CellphoneModelGuide_Click
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_CellphoneModelGuide_Click ( object sender, EventArgs e )
        //{
        //	if ( this._cellphoneModelAcs == null ) this._cellphoneModelAcs = new CellphoneModelAcs();
        //
        //	CellphoneModel cellphoneModel = null;
        //
        //	int status = this._cellphoneModelAcs.ExecuteGuid( this._enterpriseCode, 0 , out cellphoneModel );
        //
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(cellphoneModel != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //                {
        //                    //開始
        //                    this.te_St_CellphoneModelCode.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.te_Ed_CellphoneModelCode.DataText = cellphoneModel.CellphoneModelCode.TrimEnd();
        //                }           
        //                          
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }      
        //}
        #endregion  2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

		#region ◎ MakerGuide_Click
		/// <summary>
		/// MakerGuide_Click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MakerGuide_Click(object sender, EventArgs e)
		{
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            if (this._makerAcs == null) this._makerAcs = new MakerAcs();
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //Maker maker;
            //if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker) == 0)

            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;
                if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //if (maker != null)
                    if (makerUMnt != null)
                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                        {
                            //開始
                            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.tNedit_GoodsMakerCd_St.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                            this.tEdit_GoodsMakerName_St.DataText = makerUMnt.MakerName.Trim();

                            // フォーカス設定
                            this.tNedit_GoodsMakerCd_Ed.Focus();
                            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
                        }
                        else
                        {
                            //終了
                            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.tNedit_GoodsMakerCd_Ed.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                            this.tEdit_GoodsMakerName_Ed.DataText = makerUMnt.MakerName.Trim();

                            // フォーカス設定
                            this.DifCntExtraDiv_tComboEditor.Focus();
                            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		#endregion

		#endregion ◆ GuideButton

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ te_St_LargeGoodsGanreCode_Leave
		/// <summary>
		/// te_St_LargeGoodsGanreCode_Leave
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void te_St_LargeGoodsGanreCode_Leave ( object sender, EventArgs e )
		{
			if ( sender is TNedit )
			{
				if (((TNedit)sender).DataText == "")
				{
					((TNedit)sender).SetInt( 0 );
				}
			}
			// LargeGoodsGanreCode_Leave( );
		}
		#endregion

		#region ◎ te_Ed_LargeGoodsGanreCode_Leave
		/// <summary>
		/// te_Ed_LargeGoodsGanreCode_Leave
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void te_Ed_LargeGoodsGanreCode_Leave ( object sender, EventArgs e )
		{
			if ( sender is TNedit )
			{
				if ( ( ((TNedit)sender).DataText == "") || (((TNedit)sender).GetInt() == 0) )
				{
					((TNedit)sender).DataText = ((TNedit)sender).Tag.ToString();
				}
			}
			// LargeGoodsGanreCode_Leave( );
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ Main_ultraExplorerBar_GroupExpanding
        /// <summary>
        /// Main_ultraExplorerBar_GroupExpanding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 展開をキャンセル
            e.Cancel = true;
        }
        #endregion

        #region ◎ Main_ultraExplorerBar_GroupCollapsing
        /// <summary>
        /// Main_ultraExplorerBar_GroupCollapsing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // 縮小をキャンセル
            e.Cancel = true;
        }
        #endregion

		#endregion ■ Control Event

		#region ■ Private Event

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◆ 得意先(仕入先)選択時発生イベント
		/// <summary>
		/// 得意先(仕入先)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        /// <br>Programmer  :23010 中村　仁</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustSuppli custSuppli;

            //選択された得意先の状態をチェック
			if ( this._customerInfoAcs == null ) this._customerInfoAcs = new CustomerInfoAcs();

			int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //TODO:必要か？？
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        status,
                        MessageBoxButtons.OK);

                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //if ( this._customerTag.CompareTo("1") == 0 )
                    //{
                    //    this.tNedit_SupplierCd_St.SetInt( 0 );
                    //}
                    //else
                    //{
                    //    this.tNedit_SupplierCd_Ed.SetInt( 999999999 );
                    //}
                    if ( this._customerTag.CompareTo("1") == 0 )
                    {
                        this.tNedit_SupplierCd_St.Clear();
                    }
                    else
                    {
                        this.tNedit_SupplierCd_Ed.Clear();
                    }
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

                    return;
                }
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した仕入先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //画面情報をクリア
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (this._customerTag.CompareTo("1") == 0)
                //{
                //    this.tNedit_SupplierCd_St.SetInt(0);
                //}
                //else
                //{
                //    this.tNedit_SupplierCd_Ed.SetInt(999999999);
                //}
                if (this._customerTag.CompareTo("1") == 0)
                {
                    this.tNedit_SupplierCd_St.Clear();
                }
                else
                {
                    this.tNedit_SupplierCd_Ed.Clear();
                }
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (this._customerTag.CompareTo("1") == 0)
                //{
                //    this.tNedit_SupplierCd_St.SetInt(0);
                //}
                //else
                //{
                //    this.tNedit_SupplierCd_Ed.SetInt(999999999);
                //}
                if (this._customerTag.CompareTo("1") == 0)
                {
                    this.tNedit_SupplierCd_St.Clear();
                }
                else
                {
                    this.tNedit_SupplierCd_Ed.Clear();
                }
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                return;
			}
         
            //得意先(仕入先)コードをセット     
			if ( this._customerTag.CompareTo("1") == 0 )
			{
				this.tNedit_SupplierCd_St.SetInt(customerSearchRet.CustomerCode);
			}
			else
			{
				this.tNedit_SupplierCd_Ed.SetInt(customerSearchRet.CustomerCode);
			}

		}
    
        #endregion

        #region ◆ 出荷先得意先(委託先)選択時発生イベント
        /// <summary>
		/// 出荷先得意先(委託先)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで出荷先得意先を選択した時に発生します</br>
        /// <br>Programmer  :23010 中村　仁</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_ShipCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			
            //選択された得意先の状態をチェック
			if ( this._customerInfoAcs == null ) this._customerInfoAcs = new CustomerInfoAcs();

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{             
                //なにもしない             
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した委託先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //クリア
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (this._customerTag.CompareTo("1") == 0)
                //{
                //    this.tne_St_ShipCustomerCode.SetInt(0);
                //}
                //else
                //{
                //    this.tne_Ed_ShipCustomerCode.SetInt(999999999);
                //}
                if (this._customerTag.CompareTo("1") == 0)
                {
                    this.tne_St_ShipCustomerCode.Clear();
                }
                else
                {
                    this.tne_Ed_ShipCustomerCode.Clear();
                }
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"委託先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);
                //クリア
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (this._customerTag.CompareTo("1") == 0)
                //{
                //    this.tne_St_ShipCustomerCode.SetInt(0);
                //}
                //else
                //{
                //    this.tne_Ed_ShipCustomerCode.SetInt(999999999);
                //}
                if (this._customerTag.CompareTo("1") == 0)
                {
                    this.tne_St_ShipCustomerCode.Clear();
                }
                else
                {
                    this.tne_Ed_ShipCustomerCode.Clear();
                }
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

				return;
			}
            //委託先
			if ( this._customerTag.CompareTo("1") == 0 )
			{
				this.tne_St_ShipCustomerCode.SetInt(customerSearchRet.CustomerCode);
			}
			else
			{
				this.tne_Ed_ShipCustomerCode.SetInt(customerSearchRet.CustomerCode);
			}
		}
    
        #endregion

        #region ◆ TNEdit Leave Event
        #region ◎ Tne_StartCodeLeaveEvent
        /// <summary>
		/// Tne_StartCodeLeaveEvent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tne_StartCodeLeaveEvent ( object sender, EventArgs e )
		{
			if ( sender is TNedit )
			{
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //if (((TNedit)sender).DataText == "")
                //{
                //    ((TNedit)sender).SetInt(0);
                //}
                if ( (((TNedit)sender).DataText == "") || (((TNedit)sender).GetInt() == 0) )
                {
                    ((TNedit)sender).Clear();
                }
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            }
		}
		#endregion

		#region ◎ Tne_EndCodeLeaveEvent
		/// <summary>
		/// Tne_EndCodeLeaveEvent
		/// </summary>
		/// <param name="sender"></param>t
		/// <param name="e"></param>
		private void Tne_EndCodeLeaveEvent ( object sender, EventArgs e )
		{
			if ( sender is TNedit )
			{
				if ( ( ((TNedit)sender).DataText == "") || (((TNedit)sender).GetInt() == 0) )
				{
                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //((TNedit)sender).DataText = ((TNedit)sender).Tag.ToString();
                    ((TNedit)sender).Clear();
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                }
			}
		}
		#endregion

        #endregion ◆ TNEdit Leave Event
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Button_Click イベント(仕入先ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            Supplier supplier = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._sectionCode);
                if (status == 0)
                {
                    if (supplier != null)
                    {
                        //コード、名称を展開
                        if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                        {
                            this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                            this.tEdit_SupplierName_St.DataText = supplier.SupplierNm1.Trim() + supplier.SupplierNm2.Trim();

                            // フォーカス設定
                            this.tNedit_SupplierCd_Ed.Focus();
                        }
                        else
                        {
                            this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                            this.tEdit_SupplierName_Ed.DataText = supplier.SupplierNm1.Trim() + supplier.SupplierNm2.Trim();

                            // フォーカス設定
                            this.tNedit_BLGoodsCode_St.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click(グループコードガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void BlGroupGuide_Button_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU != null)
                    {
                        //コード、名称を展開
                        if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                        {
                            this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                            this.tEdit_BLGloupName_St.DataText = blGroupU.BLGroupName.Trim();

                            // フォーカス設定
                            this.tNedit_BLGloupCode_Ed.Focus();
                        }
                        else
                        {
                            this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                            this.tEdit_BLGloupName_Ed.DataText = blGroupU.BLGroupName.Trim();

                            // フォーカス設定
                            this.tNedit_GoodsMakerCd_St.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             貸出分の印刷がされない不具合の修正</br>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "DifCntExtraDiv_tComboEditor":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                //e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;         //DEL 2009/05/14 不具合対応[13260]
                                //e.NextCtrl = this.tNedit_InventorySeqNo_Ed;       //ADD 2009/05/14 不具合対応[13260] //DEL 2011/01/13
                                e.NextCtrl = this.tComboEditor_DelayPaymentDiv;     //ADD 2011/01/11
                                
                            }
                        }
                        break;
                    }
                // 倉庫コード(開始)
                case "tEdit_WarehouseCode_St":
                    {
                        if (this.tEdit_WarehouseCode_St.DataText.Trim() == "")
                        {
                            this.tEdit_WarehouseName_St.Clear();
                        }
                        else
                        {
                            string warehouseCode = this.tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');

                            // 倉庫名称取得(開始)
                            this.tEdit_WarehouseName_St.DataText = this._inventInputAcs.GetWarehouseName(warehouseCode);
                        }

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

                        break;
                    }
                // 倉庫コード(終了)
                case "tEdit_WarehouseCode_Ed":
                    {
                        if (this.tEdit_WarehouseCode_Ed.DataText.Trim() == "")
                        {
                            this.tEdit_WarehouseName_Ed.Clear();
                        }
                        else
                        {
                            string warehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');

                            // 倉庫名称取得(終了)
                            this.tEdit_WarehouseName_Ed.DataText = this._inventInputAcs.GetWarehouseName(warehouseCode);
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                //if (this.tEdit_WarehouseName_Ed.DataText.Trim() != "")
                                //{
                                //    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                                //}
                                e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tEdit_WarehouseCode_St;
                            }
                        }

                        break;
                    }
                case "tEdit_WarehouseShelfNo_St":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tEdit_WarehouseCode_Ed;
                            }
                        }
                        break;
                    }
                // 仕入先コード(開始)
                case "tNedit_SupplierCd_St":
                    {
                        if (this.tNedit_SupplierCd_St.GetInt() == 0)
                        {
                            this.tEdit_SupplierName_St.Clear();
                        }
                        else
                        {
                            int supplierCode = this.tNedit_SupplierCd_St.GetInt();

                            // 仕入先名称(開始)取得
                            this.tEdit_SupplierName_St.DataText = this._inventInputAcs.GetSupplierName(supplierCode);
                        }
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

                        break;
                    }
                // 仕入先コード(終了)
                case "tNedit_SupplierCd_Ed":
                    {
                        if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
                        {
                            this.tEdit_SupplierName_Ed.Clear();
                        }
                        else
                        {
                            int supplierCode = this.tNedit_SupplierCd_Ed.GetInt();

                            // 仕入先名称取得(終了)
                            this.tEdit_SupplierName_Ed.DataText = this._inventInputAcs.GetSupplierName(supplierCode);
                        }
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

                        break;
                    }
                // BLコード(開始)
                case "tNedit_BLGoodsCode_St":
                    {
                        if (this.tNedit_BLGoodsCode_St.GetInt() == 0)
                        {
                            this.tEdit_BLGoodsName_St.Clear();
                        }
                        else
                        {
                            int blGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();

                            // BLコード名称取得(開始)
                            this.tEdit_BLGoodsName_St.DataText = this._inventInputAcs.GetBLGoodsName(blGoodsCode);
                        }
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

                        break;
                    }
                // BLコード(終了)
                case "tNedit_BLGoodsCode_Ed":
                    {
                        if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                        {
                            this.tEdit_BLGoodsName_Ed.Clear();
                        }
                        else
                        {
                            int blGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();

                            // BLコード名称取得(終了)
                            this.tEdit_BLGoodsName_Ed.DataText = this._inventInputAcs.GetBLGoodsName(blGoodsCode);
                        }
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

                        break;
                    }
                // グループコード(開始)
                case "tNedit_BLGloupCode_St":
                    {
                        if (this.tNedit_BLGloupCode_St.GetInt() == 0)
                        {
                            this.tEdit_BLGloupName_St.Clear();
                        }
                        else
                        {
                            int blGroupCode = this.tNedit_BLGloupCode_St.GetInt();

                            // グループコード名称取得(開始)
                            this.tEdit_BLGloupName_St.DataText = this._inventInputAcs.GetBLGroupName(blGroupCode);
                        }
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

                        break;
                    }
                // グループコード(終了)
                case "tNedit_BLGloupCode_Ed":
                    {
                        if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
                        {
                            this.tEdit_BLGloupName_Ed.Clear();
                        }
                        else
                        {
                            int blGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();

                            // グループコード名称取得(終了)
                            this.tEdit_BLGloupName_Ed.DataText = this._inventInputAcs.GetBLGroupName(blGroupCode);
                        }
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

                        break;
                    }
                // メーカーコード(開始)
                case "tNedit_GoodsMakerCd_St":
                    {
                        if (this.tNedit_GoodsMakerCd_St.GetInt() == 0)
                        {
                            this.tEdit_GoodsMakerName_St.Clear();
                        }
                        else
                        {
                            int makerCode = this.tNedit_GoodsMakerCd_St.GetInt();

                            // メーカー名称取得(開始)
                            this.tEdit_GoodsMakerName_St.DataText = this._inventInputAcs.GetMakerName(makerCode);
                        }
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

                        break;
                    }
                // メーカーコード(終了)
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                        {
                            this.tEdit_GoodsMakerName_Ed.Clear();
                        }
                        else
                        {
                            int makerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();

                            // メーカー名称取得(終了)
                            this.tEdit_GoodsMakerName_Ed.DataText = this._inventInputAcs.GetMakerName(makerCode);
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                //e.NextCtrl = this.DifCntExtraDiv_tComboEditor;        //DEL 2009/05/14 不具合対応[13260]
                                e.NextCtrl = this.tNedit_InventorySeqNo_St;             //ADD 2009/05/14 不具合対応[13260]
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tNedit_GoodsMakerCd_St;
                            }
                        }
                        break;
                    }
                // ---ADD 2009/05/14 不具合対応[13260] -------------------------------->>>>>
                // 棚卸通番(開始)
                case "tNedit_InventorySeqNo_St":
                    {
                        if (this.tNedit_InventorySeqNo_St.GetInt() == 0)
                        {
                            this.tNedit_InventorySeqNo_St.Clear();
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tNedit_InventorySeqNo_Ed;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tNedit_GoodsMakerCd_Ed;
                            }
                        }
                        break;
                    }
                // 棚卸通番(終了)
                case "tNedit_InventorySeqNo_Ed":
                    {
                        if (this.tNedit_InventorySeqNo_Ed.GetInt() == 0)
                        {
                            this.tNedit_InventorySeqNo_Ed.Clear();
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                //e.NextCtrl = this.DifCntExtraDiv_tComboEditor;// DEL 2011/01/11
                                e.NextCtrl = this.tComboEditor_LendExtraDiv;  // ADD 2011/01/11
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tNedit_InventorySeqNo_St;
                            }
                        }
                        break;
                    }
                // ---ADD 2009/05/14 不具合対応[13260] --------------------------------<<<<<
                // ---ADD 2011/01/11--------------------------------------------------->>>>>
                //貸出分
                case "tComboEditor_LendExtraDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tComboEditor_DelayPaymentDiv;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tNedit_InventorySeqNo_Ed;
                            }
                        }
                        break;
                    }
                //来勘計上分
                case "tComboEditor_DelayPaymentDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.DifCntExtraDiv_tComboEditor;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tComboEditor_LendExtraDiv;
                            }
                        }
                        break;
                    }
                // ---ADD 2011/01/11---------------------------------------------------<<<<<
                default:
                    break;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/04/13 -------------------------------->>>>>
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
        // --- ADD 2009/04/13 --------------------------------<<<<<

        #endregion
    }
}
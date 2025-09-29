//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出庫確認表
// プログラム概要   : 在庫入出庫確認表UIフォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木　正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/07  修正内容 : 不具合対応[12997]
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : yangmj
// 修 正 日  2010/11/15  修正内容 : 機能改良Ｑ４
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Application.Controller.Util; // ADD 2010/11/15
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫入出庫確認表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫入出庫確認表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>UpdateNote : 2009/04/07 照田 貴志　不具合対応[12997]</br>
    /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
    /// </remarks>
	public partial class DCZAI02200UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫受払確認表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫受払確認表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCZAI02200UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // ガイド後次フォーカス制御
            SettingGuideNextFocusControl();
		}
        /// <summary>
        /// ガイド後次フォーカス制御
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            _guideNextFocusControl.AddRange( new Control[] { tEdit_WarehouseCode_St, tEdit_WarehouseCode_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_GoodsMakerCd_St, tNedit_GoodsMakerCd_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tEdit_GoodsNo_St, tEdit_GoodsNo_Ed } );
        }
		#endregion ■ Constructor

		#region ■ Private Member
		#region ◆ Interface member
		//--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract				= false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf					= true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint					= true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton		= false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton			= true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton		= true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd		= false;
        // 拠点オプション有無
        private bool _isOptSection				= false;
        // 本社機能有無
        private bool _isMainOfficeFunc			= false;
		// 選択拠点リスト
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private StockAcPayListCndtn _stockAcPayListCndtn;

        //// 拠点ガイド用
        //SecInfoSetAcs _secInfoSetAcs;

        // 倉庫ガイド用
        private WarehouseAcs _wareHouseAcs;

        //// 仕入先ガイド用
        //private UltraButton _customerGuideSender;
        //private SFTOK01370UA _customerGuid;

        // 商品コード用
        private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //private GoodsAcs _goodsAcs;

        // メーカーガイド用
        private MakerAcs _makerAcs;

        //// 担当者ガイド用
        //EmployeeAcs _employeeAcs;

        //// 在庫検索(自社分類ガイド用)
        //SearchStockAcs _searchStockAcs;

        // ガイド後次フォーカス制御
        private GuideNextFocusControl _guideNextFocusControl;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "DCZAI02200UA";
        // プログラムID
        private const string ct_PGID = "DCZAI02200U";
        //// 帳票名称
        private string _printName = "在庫入出庫確認表"; // MOD 2008/09/25 不具合対応[5542] "在庫受払確認表"→"在庫入出庫確認表"
        // 帳票キー	
        private string _printKey = "da797c1f-b718-4fa4-8dec-cd4977b7792a";
        #endregion ◆ Interface member

		// ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_ReportSortGroup = "ReportSortGroup";           // ソート条件
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件

        //--- ADD 2008/07/02 ---------->>>>>
        // 改頁
        private const string ct_Section = "拠点";
        private const string ct_Warehouse = "倉庫";
        private const string ct_Nothing = "しない";

        // 倉庫コード
        private const string ct_WarehouseCode_Max = "9999";
        private const string ct_WarehouseCode_Min = "0";
        // メーカーコード
        private const string ct_MakerCode_Max = "9999";
        private const string ct_MakerCode_Min = "0";
        //--- ADD 2008/07/02 ----------<<<<<

        // ---ADD 2010/11/15 ------------------------>>>>>
        private const string ct_Group_0 = "しない";
        private const string ct_Group_1 = "する";

        private const string ct_SlipKuben_0 = "全て";
        private const string ct_SlipKuben_10 = "仕入";
        private const string ct_SlipKuben_20 = "売上";
        private const string ct_SlipKuben_30 = "移動出荷";
        private const string ct_SlipKuben_31 = "移動入荷";
        private const string ct_SlipKuben_11 = "入荷";
        private const string ct_SlipKuben_22 = "貸出";
        private const string ct_SlipKuben_13 = "在庫仕入";
        private const string ct_SlipKuben_42 = "マスタメンテ";
        private const string ct_SlipKuben_50 = "棚卸";
        private const string ct_SlipKuben_60 = "組立";
        private const string ct_SlipKuben_61 = "分解";
        private const string ct_SlipKuben_70 = "補充入庫";
        private const string ct_SlipKuben_71 = "補充出庫";
        // ---ADD 2010/11/15 ------------------------<<<<<
        #endregion

		#region ■ IPrintConditionInpType メンバ
		#region ◆ Public Event
		/// <summary> 親ツールバー設定イベント </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion ◆ Public Event

		#region ◆ Public Property
		/// <summary> 抽出ボタン状態取得プロパティ </summary>
		public bool CanExtract
		{
			get { return this._canExtract; }
		}

		/// <summary> PDF出力ボタン状態取得プロパティ </summary>
		public bool CanPdf
		{
			get { return this._canPdf; }
		}

		/// <summary> 印刷ボタン状態取得プロパティ </summary>
		public bool CanPrint
		{
			get { return this._canPrint; }
		}

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
		public bool VisibledExtractButton
		{
			get { return this._visibledExtractButton; }
		}

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
		public bool VisibledPdfButton
		{
			get { return this._visibledPdfButton; }
		}

        /// <summary> 印刷ボタン表示プロパティ </summary>
		public bool VisibledPrintButton
		{
			get { return this._visibledPrintButton; }
		}

		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 抽出処理
		/// <summary>
        /// 抽出処理
        /// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>0( 固定 )</returns>
		public int Extract ( ref object parameter )
		{
            // 抽出処理は無いので処理終了
            return 0;
		}
		#endregion

		#region ◎ 印刷処理
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// 帳票選択ガイド
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// 印刷情報パラメータ

			// 企業コードをセット
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// 起動PGID

			// PDF出力履歴用
			printInfo.key				= this._printKey;
			printInfo.prpnm				= this._printName;

			printInfo.PrintPaperSetCd	= 0;
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._stockAcPayListCndtn;
			printDialog.PrintInfo		= printInfo;
			
			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) {
				MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0 );
			}

			 parameter = printInfo;

			return printInfo.status;
		}
		#endregion

		#region ◎ 印刷前確認処理
		/// <summary>
		/// 印刷前確認処理
		/// </summary>
		/// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// メッセージを表示
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// コントロールにフォーカスをセット
				if( errComponent != null ) {
					errComponent.Focus();
				}

				status = false;
			}

			return status;
		}
		#endregion

		#region ◎ 画面表示処理
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._stockAcPayListCndtn = new StockAcPayListCndtn();

            this.Show();
			return;
		}
		#endregion

		#endregion ◆ Public Method
		#endregion ■ IPrintConditionInpType メンバ

		#region ■ IPrintConditionInpTypeSelectedSection メンバ
		#region ◆ Public Property

        /// <summary> 本社機能プロパティ </summary>
		public bool IsMainOfficeFunc
		{
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
		}

        /// <summary> 拠点オプションプロパティ </summary>
		public bool IsOptSection
		{
            get { return _isOptSection; }
            set { _isOptSection = value; }
		}

        /// <summary> 計上拠点選択表示取得プロパティ </summary>
		public bool VisibledSelectAddUpCd
		{
            get { return _visibledSelectAddUpCd; }
		}

		#endregion ◆ Public Property

		#region ◆ Public Method

		#region ◎ 拠点選択処理
		/// <summary>
		/// 拠点選択処理
		/// </summary>
		/// <param name="sectionCode">選択拠点コード</param>
		/// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void CheckedSection ( string sectionCode, CheckState checkState )
		{
            // 拠点を選択した時
            if ( checkState == CheckState.Checked )
            {
                // 全社が選択された場合
                if ( sectionCode == "0" )
                {
                    this._selectedSectionList.Clear();
                }

                if ( !this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Add( sectionCode, sectionCode );
                }
            }
            // 拠点選択を解除した時
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
                }
            }
		}
		#endregion

		#region ◎ 初期選択計上拠点設定処理( 未実装 )
		/// <summary>
		/// 初期選択計上拠点設定処理( 未実装 )
		/// </summary>
		/// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void InitSelectAddUpCd ( int addUpCd )
		{
			// 計上拠点選択がないので未実装
		}
		#endregion

		#region ◎ 初期選択拠点設定処理
		/// <summary>
		/// 初期選択拠点設定処理
		/// </summary>
		/// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                this._selectedSectionList.Add( wk, wk );
            }
		}
		#endregion

		#region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            //return isDefaultState;            //DEL 2009/04/07 不具合対応[12997]
            return false;                       //ADD 2009/04/07 不具合対応[12997]
        }
		#endregion

		#region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void SelectedAddUpCd (int addUpCd )
		{
            // 計上拠点選択がないので未実装
		}
		#endregion

		#endregion ◆ Public Method
		#endregion ■ IPrintConditionInpTypeSelectedSection メンバ

		#region ■ IPrintConditionInpTypePdfCareer メンバ
		#region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
		public string PrintKey
		{
            get { return this._printKey; }
		}

        /// <summary> 帳票名プロパティ </summary>
		public string PrintName
		{
            get { return this._printName; }
		}

		#endregion ◆ Public Method
		#endregion ■ IPrintConditionInpTypePdfCareer メンバ

		#region ■ Private Method
		#region ◆ 画面初期化関係
		#region ◎ 画面初期化処理
		/// <summary>
		/// 画面初期化処理
		/// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 初期値セット・日付
                this.tde_St_IoGoodsDay.SetDateTime( DateTime.Today ); // システム日付
                this.tde_Ed_IoGoodsDay.SetDateTime( DateTime.Today ); // システム日付

                // 初期値セット・文字列
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                //--- ADD 2008/07/02 ---------->>>>>
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                //--- ADD 2008/07/02 ----------<<<<<

                // 初期値セット・数値
                //--- DEL 2008/07/02 ---------->>>>>
                //this.tne_St_GoodsMakerCd.SetInt(0);
                //this.tne_Ed_GoodsMakerCd.SetInt( 0 );
                //--- DEL 2008/07/02 ----------<<<<<
                //this.tne_Ed_GoodsMakerCd.SetInt( Int32.Parse( new string( '9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column ) ) );

                // ボタン設定
                // DEL 2008/09/25 不具合対応[5603] ---------->>>>>
                //this.SetIconImage( this.ub_St_GoodsGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_GoodsGuid, Size16_Index.STAR1 );
                // DEL 2008/09/25 不具合対応[5603] ----------<<<<<
                this.SetIconImage( this.ub_St_GoodsMakerGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsMakerGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_WarehouseGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_WarehouseGuid, Size16_Index.STAR1 );

                /* ---DEL 2009/04/07 不具合対応[12997] ------------------------>>>>>
                //--- ADD 2008/07/02 ---------->>>>>
                // 改頁アイテム追加
                tComboEditor1.Items.Add(0, ct_Section);
                tComboEditor1.Items.Add(0, ct_Warehouse);
                tComboEditor1.Items.Add(0, ct_Nothing);
                tComboEditor1.SelectedIndex = 0;
                //--- ADD 2008/07/02 ----------<<<<<
                   ---DEL 2009/04/07 不具合対応[12997] ------------------------<<<<< */
                // ---ADD 2009/04/07 不具合対応[12997] ------------------------>>>>>
                // 改頁アイテム追加
                tComboEditor1.Items.Add(1, ct_Warehouse);
                tComboEditor1.Items.Add(2, ct_Nothing);
                tComboEditor1.SelectedIndex = 0;
                // ---ADD 2009/04/07 不具合対応[12997] ------------------------<<<<<

                // ---ADD 2010/11/15 ------------------------>>>>>
                // 小計印字アイテム追加
                Group_tComboEditor.Items.Add(0, ct_Group_0);
                Group_tComboEditor.Items.Add(1, ct_Group_1);
                Group_tComboEditor.SelectedIndex = 0;
                // 伝票区分アイテム追加
                SlipDiv_tComboEditor.Items.Add(0, ct_SlipKuben_0);
                SlipDiv_tComboEditor.Items.Add(10, ct_SlipKuben_10);
                SlipDiv_tComboEditor.Items.Add(20, ct_SlipKuben_20);
                SlipDiv_tComboEditor.Items.Add(30, ct_SlipKuben_30);
                SlipDiv_tComboEditor.Items.Add(31, ct_SlipKuben_31);
                SlipDiv_tComboEditor.Items.Add(11, ct_SlipKuben_11);
                SlipDiv_tComboEditor.Items.Add(22, ct_SlipKuben_22);
                SlipDiv_tComboEditor.Items.Add(13, ct_SlipKuben_13);
                SlipDiv_tComboEditor.Items.Add(42, ct_SlipKuben_42);
                SlipDiv_tComboEditor.Items.Add(50, ct_SlipKuben_50);
                SlipDiv_tComboEditor.Items.Add(60, ct_SlipKuben_60);
                SlipDiv_tComboEditor.Items.Add(61, ct_SlipKuben_61);
                SlipDiv_tComboEditor.Items.Add(70, ct_SlipKuben_70);
                SlipDiv_tComboEditor.Items.Add(71, ct_SlipKuben_71);
                SlipDiv_tComboEditor.SelectedIndex = 0;
                // 出力順追加
                Sort_tComboEditor.SelectedIndex = 0;
                // ---ADD 2010/11/15 ------------------------<<<<<

                // 初期フォーカスセット
                this.tde_St_IoGoodsDay.Focus();
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

		#region ◎ ボタンアイコン設定処理
		/// <summary>
		/// ボタンアイコン設定処理
		/// </summary>
		/// <param name="settingControl">アイコンセットするコントロール</param>
		/// <param name="iconIndex">アイコンインデックス</param>
		private void SetIconImage ( object settingControl, Size16_Index iconIndex )
		{
			((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion
		#endregion ◆ 画面初期化関係

		#region ◆ 印刷前処理
		#region ◎ 入力チェック処理
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <param name="errComponent">エラー発生コンポーネント</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            //--- DEL 2008/07/03 ---------->>>>>
            //const string ct_FullRangeError = "は１ヶ月の範囲内で入力して下さい";
            //--- DEL 2008/07/03 ----------<<<<<
            //--- ADD 2008/07/03 ---------->>>>>
            // ---DEL 2010/11/15 ------------------------>>>>>
            //const string ct_FullRangeError = "は３ヶ月の範囲内で入力して下さい";
            // ---DEL 2010/11/15 ------------------------<<<<<
            //--- ADD 2008/07/03 ----------<<<<<

            //--------------------------------------------------------------------------
            // 入出荷日
            //--------------------------------------------------------------------------
            if ( CallCheckDateRange( out cdrResult, ref tde_St_IoGoodsDay, ref tde_Ed_IoGoodsDay ) == false )
            {
                switch ( cdrResult )
                {
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("開始入出荷日{0}", ct_NoInput);
                    //        errComponent = this.tde_St_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始入出荷日{0}", ct_InputError );
                            errComponent = this.tde_St_IoGoodsDay;
                        }
                        break;
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("終了入出荷日{0}", ct_NoInput);
                    //        errComponent = this.tde_Ed_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了入出荷日{0}", ct_InputError );
                            errComponent = this.tde_Ed_IoGoodsDay;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format( "入出荷日{0}", ct_RangeError );
                            errComponent = this.tde_St_IoGoodsDay;
                        }
                        break;
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        errMessage = string.Format( "入出荷日{0}", ct_FullRangeError );
                    //        errComponent = this.tde_St_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                }

                status = false;
            }
            // ---ADD 2010/11/15 ------------------------>>>>>
            else if (this.tde_St_IoGoodsDay.GetDateTime() == DateTime.MinValue && this.tde_Ed_IoGoodsDay.GetDateTime() != DateTime.MinValue)
            {
                errMessage = string.Format("入出荷日開始{0}", ct_InputError);
                errComponent = this.tde_St_IoGoodsDay;
                status = false;
            }
            else if (this.tde_St_IoGoodsDay.GetDateTime() != DateTime.MinValue && this.tde_Ed_IoGoodsDay.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("入出荷日終了{0}", ct_InputError);
                errComponent = this.tde_Ed_IoGoodsDay;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------<<<<<
            //--------------------------------------------------------------------------
            // 倉庫コード
            //--------------------------------------------------------------------------
            else if (
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format("倉庫{0}", ct_RangeError); // MOD 2008/10/02 不具合対応[6040] "倉庫コード{0}"→"倉庫{0}"
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // メーカーコード
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode( this.tNedit_GoodsMakerCd_Ed ) )
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);   // MOD 2008/10/02 不具合対応[6040] "メーカーコード{0}"→"メーカー{0}"
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 商品番号
            //--------------------------------------------------------------------------
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format("品番{0}", ct_RangeError);   // MOD 2008/10/02 不具合対応[6040] "商品番号{0}"→"品番{0}"
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------>>>>>
            //--------------------------------------------------------------------------
            // 入力日
            //--------------------------------------------------------------------------
            else if (CallCheckDateRange(out cdrResult, ref detInputDay_St, ref detInputDay_Ed) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始入力日{0}", ct_InputError);
                            errComponent = this.detInputDay_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了入力日{0}", ct_InputError);
                            errComponent = this.detInputDay_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.detInputDay_St;
                        }
                        break;
                }

                status = false;
            }
            else if (this.detInputDay_St.GetDateTime() == DateTime.MinValue && this.detInputDay_Ed.GetDateTime() != DateTime.MinValue)
            {
                errMessage = string.Format("入力日開始{0}", ct_InputError);
                errComponent = this.detInputDay_St;
                status = false;
            }
            else if (this.detInputDay_St.GetDateTime() != DateTime.MinValue && this.detInputDay_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("入力日終了{0}", ct_InputError);
                errComponent = this.detInputDay_Ed;
                status = false;
            }
            else if (this.tde_St_IoGoodsDay.GetDateTime() == DateTime.MinValue && this.detInputDay_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("入出荷日または、入力日{0}", ct_NoInput);
                errComponent = this.tde_St_IoGoodsDay;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 伝票番号
            //--------------------------------------------------------------------------
            else if (
              (this.tNedit_SupplierSlipNo_St.DataText.TrimEnd() != string.Empty) &&
              (this.tNedit_SupplierSlipNo_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tNedit_SupplierSlipNo_St.DataText.TrimEnd().CompareTo(this.tNedit_SupplierSlipNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("伝票番号{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierSlipNo_St;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------<<<<<

            return status;
        }
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit)
        {
            //--- DEL 2008/07/03 ---------->>>>>
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref startDateEdit, ref endDateEdit, false, false);
            //--- DEL 2008/07/03 ----------<<<<<
            // ---UPD 2010/11/15 ------------------------>>>>>
            //--- ADD 2008/07/03 ---------->>>>>
            
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDateEdit, ref endDateEdit, false, false);
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDateEdit, ref endDateEdit, false);

            //--- ADD 2008/07/03 ----------<<<<<
            //return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            bool result = false;
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                result = true;
            }
            else
            {
                result = cdrResult == DateGetAcs.CheckDateRangeResult.OK;
            }
            return result;
            // ---UPD 2010/11/15 ------------------------<<<<<
        }
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
            if ( targetDateEdit.GetLongDate() < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue )
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

		#region ◎ 抽出条件設定処理(画面→抽出条件)
		/// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                /* ---DEL 2009/04/07 不具合対応[12997] -------------------------->>>>>
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 「全拠点」が選択されている場合はリストをクリア
                bool allSections = false;

                foreach ( object obj in _selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if ( allSections )
                {
                    _selectedSectionList.Clear();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                   ---DEL 2009/04/07 不具合対応[12997] --------------------------<<<<< */
                _selectedSectionList.Clear();       //ADD 2009/04/07 不具合対応[12997]

                // 拠点オプション
                this._stockAcPayListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._stockAcPayListCndtn.EnterpriseCode = this._enterpriseCode;

                // 拠点コード（複数指定）
                ArrayList sectionList = new ArrayList( this._selectedSectionList.Values );
                this._stockAcPayListCndtn.SectionCodes = (string[])sectionList.ToArray(typeof(string));

                // 有効区分
                this._stockAcPayListCndtn.ValidDivCd = 0;   // 0:有効のみ
                // 開始入出荷日
                this._stockAcPayListCndtn.St_IoGoodsDay = this.tde_St_IoGoodsDay.GetDateTime();
                // 終了入出荷日
                this._stockAcPayListCndtn.Ed_IoGoodsDay = this.tde_Ed_IoGoodsDay.GetDateTime();
                // 開始計上日付
                this._stockAcPayListCndtn.St_AddUpADate = DateTime.MinValue; //(予備項目)
                // 終了計上日付
                this._stockAcPayListCndtn.Ed_AddUpADate = DateTime.MinValue; //(予備項目)
                // ---DEL 2010/11/15 ------------------------>>>>>
                // 受払元伝票区分
                //this._stockAcPayListCndtn.AcPaySlipCd = -1; // -1:全て
                // ---DEL 2010/11/15 ------------------------<<<<<
                // 開始倉庫コード
                this._stockAcPayListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text;
                // 終了倉庫コード
                this._stockAcPayListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text;
                // 開始商品メーカーコード
                this._stockAcPayListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                this._stockAcPayListCndtn.Ed_GoodsMakerCd = GetEndCode(this.tNedit_GoodsMakerCd_Ed, 999999);

                // ---UPD 2010/11/15 ------------------------>>>>>
                //// 開始受払元伝票番号
                //this._stockAcPayListCndtn.St_AcPaySlipNum = string.Empty;
                //// 終了受払元伝票番号
                //this._stockAcPayListCndtn.Ed_AcPaySlipNum = string.Empty;

                this._stockAcPayListCndtn.St_AcPaySlipNum = this.tNedit_SupplierSlipNo_St.Text;
                this._stockAcPayListCndtn.Ed_AcPaySlipNum = this.tNedit_SupplierSlipNo_Ed.Text;
                // ---UPD 2010/11/15 ------------------------<<<<<

                // 開始商品番号
                this._stockAcPayListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了商品番号
                this._stockAcPayListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;

                //--- ADD 2008/07/02 ---------->>>>>
                // 改頁情報
                //this._stockAcPayListCndtn.ChangePage = this.tComboEditor1.SelectedIndex;                  //DEL 2009/04/07 不具合対応[12997]
                this._stockAcPayListCndtn.ChangePage = int.Parse(this.tComboEditor1.Value.ToString());      //ADD 2009/04/07 不具合対応[12997]
                //--- ADD 2008/07/02 ----------<<<<<

                // ---ADD 2010/11/15 ------------------------>>>>>
                // 入力日
                string fromD = this.detInputDay_St.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
                string fromT = DateTimeUtil.DEFAULT_FROM_TIME;
                this._stockAcPayListCndtn.St_detInputDay = DateTime.Parse(fromD + " " + fromT);

                string toD = this.detInputDay_Ed.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
                string toT = DateTimeUtil.DEFAULT_TO_TIME;
                this._stockAcPayListCndtn.Ed_detInputDay = DateTime.Parse(toD + " " + toT);

                // 小計情報
                this._stockAcPayListCndtn.GroupCnt = int.Parse(this.Group_tComboEditor.Value.ToString());

                // 出力順
                this._stockAcPayListCndtn.Sort = int.Parse(this.Sort_tComboEditor.Value.ToString());

                // 伝票区分
                if (int.Parse(this.SlipDiv_tComboEditor.Value.ToString()) == 0)
                {
                    this._stockAcPayListCndtn.AcPaySlipCd = -1;
                }
                else
                {
                    this._stockAcPayListCndtn.AcPaySlipCd = int.Parse(this.SlipDiv_tComboEditor.Value.ToString());
                }
                // ---ADD 2010/11/15 ------------------------<<<<<
            }
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit )
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        }
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        {
            if ( tNedit.GetInt() == 0 )
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion
		#endregion ◆ 印刷前処理

        # region ■ エラーメッセージ ■
        /// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				this._printName,					// プログラム名称
				"", 								// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
				this._printName,					// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
        }
        # endregion ■ エラーメッセージ ■

        #endregion ■ Private Method

        # region ■ コントロールイベント ■

        # region ■ フォームイベント ■
        /// <summary>
		/// DCZAI02200UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCZAI02200UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

			ParentToolbarSettingEvent( this );						// ツールバーボタン設定イベント起動
        }
        # endregion ■ フォームイベント ■

        # region ■ コントロール脱出イベント ■
        /// <summary>
        /// 数値項目開始脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    ( ( TNedit ) sender ).SetInt(0);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 数値項目終了脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    string maxValueText = new string('9', ((TNedit)sender).ExtEdit.Column);
            //    ( ( TNedit ) sender ).SetInt(Int32.Parse(maxValueText));
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        # endregion ■ コントロール脱出イベント ■

        # region ■ ガイドボタンクリックイベント ■
        ///// <summary>
        ///// 得意先ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        //private void ub_St_CustomerGuide_Click ( object sender, EventArgs e )
        //{
        //    // 押下されたボタンを退避
        //    if (sender is UltraButton)
        //    {
        //        _customerGuideSender = (UltraButton)sender;
        //    }

        //    this._customerGuid = new SFTOK01370UA( SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY );
        //    this._customerGuid.CustomerSelect += new CustomerSelectEventHandler( customerSearchForm_CustomerSelect );
        //    this._customerGuid.ShowDialog(this);
        //}
        ///// <summary>
        ///// 得意先ガイド選択イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="customerSearchRet"></param>
        //void customerSearchForm_CustomerSelect ( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    if (customerSearchRet == null) return;

        //    if ( _customerGuideSender == this.ub_St_CustomerGuide )
        //    {
        //        this.tne_St_CustomerCode.SetInt( customerSearchRet.CustomerCode );
        //    }
        //    else
        //    {
        //        this.tne_Ed_CustomerCode.SetInt( customerSearchRet.CustomerCode );
        //    }

        //}
        ///// <summary>
        ///// 担当者ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_EmployeeGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._employeeAcs == null )
        //    {
        //        this._employeeAcs = new EmployeeAcs();
        //    }

        //    Employee employee;
        //    int status = this._employeeAcs.ExecuteGuid( this._enterpriseCode, true, out employee);

        //    if ( status == 0 )
        //    {
        //        if ( sender == this.ub_St_EmployeeGuide )
        //        {
        //            this.te_St_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
        //        }
        //        else
        //        {
        //            this.te_Ed_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
        //        }
        //    }
        //}

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_WarehouseGuid_Click ( object sender, EventArgs e )
        {
            int status = 0;
            Warehouse warehouse;
            string sectionCode = GetWarehouseGuideSection( this._selectedSectionList );

            if ( this._wareHouseAcs == null )
            {
                this._wareHouseAcs = new WarehouseAcs();
            }

            status = this._wareHouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, sectionCode );
            if ( status != 0 ) return;

            string tag = (string)( (UltraButton)sender ).Tag;
            TEdit targetControl = null;
            if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tEdit_WarehouseCode_St;
            else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tEdit_WarehouseCode_Ed;
            else return;

            // コード展開
            targetControl.DataText = warehouse.WarehouseCode.TrimEnd();
            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 倉庫ガイド用拠点コード取得処理
        /// </summary>
        /// <param name="selectedSectionList"></param>
        /// <returns>倉庫ガイド用の指定拠点コード</returns>
        /// <remarks>
        /// <br>出力対象拠点の選択状況に応じて、拠点コードを返します</br>
        /// </remarks>
        private string GetWarehouseGuideSection( Hashtable selectedSectionList )
        {
            if ( selectedSectionList.Count >= 2 )
            {
                // 複数拠点が選択されていたら、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Count == 0 )
            {
                // 拠点が選択されていなければ、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Contains( "0" ) )
            {
                // 「全拠点」が選択されていたら、未指定
                return string.Empty;
            }

            // 選択されている拠点コードを返す
            foreach ( object obj in selectedSectionList.Values )
            {
                if ( obj is string )
                {
                    return (obj as string);
                }
            }

            return string.Empty;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// メーカーガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerGuid_Click ( object sender, EventArgs e )
        {
            MakerUMnt maker;

            if ( this._makerAcs == null )
            {
                this._makerAcs = new MakerAcs();
            }

            int status = this._makerAcs.ExecuteGuid( this._enterpriseCode, out maker );
            if ( status != 0 ) return;


            TNedit targetControl;
            if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) { targetControl = this.tNedit_GoodsMakerCd_St; }
            else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 )  { targetControl = this.tNedit_GoodsMakerCd_Ed; }
            else return;

            // 値格納
            targetControl.SetInt( maker.GoodsMakerCd );

            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();

        }

        // DEL 2008/09/25 不具合対応[5603] ---------->>>>>
        ///// <summary>
        ///// 商品ガイドボタンクリックイベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null )
        //    {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    GoodsUnitData goodsUnitData;
        //    DialogResult status = this._goodsGuid.ShowGuide( null, this._enterpriseCode, out goodsUnitData );

        //    if ( status != DialogResult.OK ) return;

        //    TEdit targetControl;
        //    if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 ) { targetControl = this.tEdit_GoodsNo_St; }
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) {targetControl =  this.tEdit_GoodsNo_Ed; }
        //    else return;

        //    // 値格納
        //    targetControl.Text = goodsUnitData.GoodsNo.TrimEnd();

        //    // 次フォーカス
        //    _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        //}
        // DEL 2008/09/25 不具合対応[5603] ----------<<<<<

        # endregion ■ ガイドボタンクリックイベント ■

        # region ■ ExplorerBarの縮小・展開処理 ■
        /// <summary>
        /// グループ展開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ縮小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        # endregion ■  ■
        # endregion ■ コントロールイベント ■

        # region ■ ガイド後次フォーカス制御クラス ■
        /// <summary>
        /// ガイド後次フォーカス制御クラス
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="control"></param>
            public void Add( Control control )
            {
                _controls.Add( control );
                if ( !_indexDic.ContainsKey( control ) )
                {
                    _indexDic.Add( control, _controls.Count - 1 );
                }
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange( IEnumerable<Control> collection )
            {
                int stIndex = _controls.Count;
                _controls.AddRange( collection );
                int edIndex = _controls.Count - 1;

                for ( int i = stIndex; i <= edIndex; i++ )
                {
                    if ( !_indexDic.ContainsKey( _controls[i] ) )
                    {
                        _indexDic.Add( _controls[i], i );
                    }
                }
            }
            /// <summary>
            /// 対象コントロールクリア
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// 次コントロール取得
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl( Control control )
            {
                int index = _indexDic[control];
                index++;

                for ( int i = index; i < _controls.Count; i++ )
                {
                    if ( !_controls[i].Visible || !_controls[i].Enabled )
                    {
                        continue;
                    }

                    if ( _controls[i] is TEdit )
                    {
                        if ( (_controls[i] as TEdit).ReadOnly == true )
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion ■ ガイド後次フォーカス制御クラス ■

        //--- ADD 2008/07/02 ---------->>>>>
        /// <summary>
        /// te_St_WarehouseCd_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void te_St_WarehouseCd_Leave(object sender, EventArgs e)
        {
            if (this.tEdit_WarehouseCode_St.Text == ct_WarehouseCode_Min)
            {
                this.tEdit_WarehouseCode_St.Text = "";
            }
        }

        /// <summary>
        /// te_Ed_WarehouseCd_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void te_Ed_WarehouseCd_Leave(object sender, EventArgs e)
        {
            if (this.tEdit_WarehouseCode_Ed.Text == ct_WarehouseCode_Max)
            {
                this.tEdit_WarehouseCode_Ed.Text = "";
            }
        }

        /// <summary>
        /// tne_St_GoodsMakerCd_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_GoodsMakerCd_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_GoodsMakerCd_St.Text == ct_MakerCode_Min)
            {
                this.tNedit_GoodsMakerCd_St.Text = "";
            }
        }

        /// <summary>
        /// tne_Ed_GoodsMakerCd_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_GoodsMakerCd_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_GoodsMakerCd_Ed.Text == ct_MakerCode_Max)
            {
                this.tNedit_GoodsMakerCd_Ed.Text = "";
            }
        }
        //--- ADD 2008/07/02 ---------->>>>>
    }
}
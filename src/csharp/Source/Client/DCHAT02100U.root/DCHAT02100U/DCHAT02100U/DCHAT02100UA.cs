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

using Broadleaf.Application.Resources;   // 2017/09/14 譚洪 ハンディターミナル二次開発
using System.Reflection;   // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注一覧表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注一覧表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 犬飼</br>
    /// <br>Date	   : 2008.09.01</br>
    /// <br>UpdateNote : 発注残一覧表追加</br>
    /// <br>Programmer : 渋谷 大輔</br>
    /// <br>Date	   : 2008.12.10</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : ㈱ダイサブの対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2019/11/05</br>
    /// <br>管理番号   : 11570226-00</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PMKOBETSU-3280の対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date	   : 2020/03/10</br>
    /// </remarks>
	public partial class DCHAT02100UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer 		// 帳票業務（条件入力）PDF出力履歴管理

	{
		#region ■ Constructor
		/// <summary>
		/// 発注一覧表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// <br>Note       : ㈱ダイサブの対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/11/05</br>
		/// <br></br>
		/// </remarks>
		public DCHAT02100UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 前回入力商品番号
            beforeGoodsNo = string.Empty;

            // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
            //// ガイド後次フォーカスの設定
            //SettingGuideNextControl();
            // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END
            
            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // 2008.09.02 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
            this._supplierAcs = new SupplierAcs();
            // 2008.09.02 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END

            // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
            //// 商品検索
            //_goodsGuid = new MAKHN04110UA();
            // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

            // 2008.09.04 30413 犬飼 ＵＩ入力保存コンポーネントの追加 >>>>>>START
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.ce_ObjDiv);                           // 
            ctrlList.Add(this.ce_BlanketStockInputDataDiv);
            ctrlList.Add(this.ce_StockMinMaxPrintDiv);
            ctrlList.Add(this.ce_LotCalcDiv);
            ctrlList.Add(this.ce_StkCntStandard);
            ctrlList.Add(this.ce_OrderStandard);
            ctrlList.Add(this.ce_LendCntPrintDiv);
            ctrlList.Add(this.ce_LendCntCalc);
            ctrlList.Add(this.ce_NewPageDiv);
            ctrlList.Add(this.ce_FaxSendDiv);
            ctrlList.Add(this.ce_PrintSortDiv);
            ctrlList.Add(this.ce_WarehouseExtra);
            ctrlList.Add(this.tEdit_WarehouseCode_St);
            ctrlList.Add(this.tEdit_WarehouseCode_Ed);
            ctrlList.Add(this.tEdit_WarehouseCode1);
            ctrlList.Add(this.tEdit_WarehouseCode2);
            ctrlList.Add(this.tEdit_WarehouseCode3);
            ctrlList.Add(this.tEdit_WarehouseCode4);
            ctrlList.Add(this.tEdit_WarehouseCode5);
            ctrlList.Add(this.tEdit_WarehouseCode6);
            ctrlList.Add(this.ce_SupplierExtra);
            ctrlList.Add(this.tNedit_SupplierCd_St);
            ctrlList.Add(this.tNedit_SupplierCd_Ed);
            ctrlList.Add(this.tNedit_SupplierCd1);
            ctrlList.Add(this.tNedit_SupplierCd2);
            ctrlList.Add(this.tNedit_SupplierCd3);
            ctrlList.Add(this.tNedit_SupplierCd4);
            ctrlList.Add(this.tNedit_SupplierCd5);
            ctrlList.Add(this.tNedit_SupplierCd6);
            ctrlList.Add(this.ce_TrustStockDiv);

            ctrlList.Add(this.tComboEditor_BarCodeShow);  // ADD 2017/09/14 譚洪 ハンディターミナル二次開発

            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
            ctrlList.Add(this.tComboEditor_MakeCdDiv);
            ctrlList.Add(this.tComboEditor_Method);
            ctrlList.Add(this.ce_CoNmPrintOutCd);
            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

            uiMemInput1.TargetControls = ctrlList;
            // 2008.09.04 30413 犬飼 ＵＩ入力保存コンポーネントの追加 <<<<<<END
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
		private OrderListCndtn _orderListCndtn;

        //// 拠点ガイド用
        //SecInfoSet _secInfoSet;
        //SecInfoSetAcs _secInfoSetAcs;

        // 倉庫ガイド用
        private Warehouse _wareHouse;
        private WarehouseAcs _wareHouseAcs;

        // 2008.09.02 30413 犬飼 ガイド系アクセスクラスの追加 >>>>>>START
        SupplierAcs _supplierAcs;
        // 2008.09.02 30413 犬飼 ガイド系アクセスクラスの追加 <<<<<<END

        // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // 起動帳票
        private int _selPrintMode;  // 0:発注一覧表 1:発注残一覧表
        // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        //// 仕入先ガイド用
        //private UltraButton _customerGuidSender = null;
        //private SFTOK01370UA _customerGuid;

        //// 商品コード用
        //private MAKHN04110UA _goodsGuid;
        //private GoodsAcs _goodsAcs;
        //private GoodsUnitData _goodsUnitData;

        //// 担当者ガイド用
        //private EmployeeAcs _employeeAcs;
        //private Employee _employee;

        //// 在庫検索(自社分類ガイド用)
        //private SearchStockAcs _searchStockAcs;
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END
            
        // 前回入力商品番号
        private string beforeGoodsNo;

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        //// ガイド後次項目ディクショナリ
        //private Dictionary<Control, Control> _nextControl;

        //// 得意先ガイド結果OKフラグ
        //private bool _customerGuideOK;
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END
        
        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary> ハンディOP(仕入)オプション区分「0:OFF(使用不可) 1:ON(使用可)」</summary>
        private bool IsOptHandySup = false;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "DCHAT02100UA";
		// プログラムID
        private const string ct_PGID            = "DCHAT02100U";
		//// 帳票名称
		private string _printName				= "発注一覧表";
        // 帳票キー	
        private string _printKey                = "0d401343-727b-4a71-abde-539bbb08531d";   // 保留
		#endregion ◆ Interface member

        // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // 起動帳票番号
        private const int CT_SelPrintMode_OrderList = 0;      // 発注一覧表
        private const int CT_SelPrintMode_OrderRemList = 1;　 // 発注残一覧表

        // 起動帳票名
        private const string CT_SelPrintModeName_OrderList    = "発注一覧表";
        private const string CT_SelPrintModeName_OrderRemList = "発注残一覧表";
        // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ---------->>>>>
        /// <summary>UOE自動発注設定アクセスクラスプログラムID</summary>
        private const string AssemblyId = "PMUOE09103AC";
        /// <summary>UOE自動発注設定マスタプログラムIDのクラス名</summary>
        private const string AssemblyIdClassName = "Broadleaf.Application.Controller.UOEAutoOrderStAcs";
        /// <summary>UOE自動発注設定マスタ取得メソッド名</summary>
        private const string AssemblyIdMethodName = "GetAutoOrderDate";
        // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ----------<<<<<
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
        /// <br>Update Note : ㈱ダイサブの対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/11/05</br>
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
            // 2008.12.10 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_OrderList:
                    {
                        this._printName = CT_SelPrintModeName_OrderList;
                        break;
                    }
                case CT_SelPrintMode_OrderRemList:
                    {
                        this._printName = CT_SelPrintModeName_OrderRemList;
                        break;
                    }
            }
            printInfo.prpnm = this._printName;
            // 2008.12.10 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            // 2008.12.10 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            /*
            // 2008.09.04 30413 犬飼 設定コードを出力順で変更 >>>>>>START
            //printInfo.PrintPaperSetCd = 0;
            if ((int)this.ce_PrintSortDiv.Value == 0)
            {
                // メーカー・品番順
                printInfo.PrintPaperSetCd = 0;
            }
            else
            {
                // 棚番順
                printInfo.PrintPaperSetCd = 1;
            }
            // 2008.09.04 30413 犬飼 設定コードを出力順で変更 <<<<<<END
            */
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_OrderList:
                    {
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        if ((int)this.tComboEditor_Method.Value == 0)
                        {
                            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                            if ((int)this.ce_PrintSortDiv.Value == 0)
                            {
                                // メーカー・品番順
                                printInfo.PrintPaperSetCd = 0;
                            }
                            else
                            {
                                // 棚番順
                                printInfo.PrintPaperSetCd = 1;
                            }
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        }
                        else
                        {
                            if ((int)this.ce_PrintSortDiv.Value == 0)
                            {
                                // メーカー・品番順
                                printInfo.PrintPaperSetCd = 4;
                            }
                            else
                            {
                                // 棚番順
                                printInfo.PrintPaperSetCd = 5;
                            }
                        }
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                        break;
                    }
                case CT_SelPrintMode_OrderRemList:
                    {
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        if ((int)this.tComboEditor_Method.Value == 0)
                        {
                            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                            if ((int)this.ce_PrintSortDiv.Value == 0)
                            {
                                // メーカー・品番順
                                printInfo.PrintPaperSetCd = 2;
                            }
                            else
                            {
                                // 棚番順
                                printInfo.PrintPaperSetCd = 3;
                            }
                            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        }
                        else
                        {
                            if ((int)this.ce_PrintSortDiv.Value == 0)
                            {
                                // メーカー・品番順
                                printInfo.PrintPaperSetCd = 6;
                            }
                            else
                            {
                                // 棚番順
                                printInfo.PrintPaperSetCd = 7;
                            }
                        }
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        break;
                    }
            }
            printInfo.prpnm = this._printName;
            // 2008.12.10 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._orderListCndtn;
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
            // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region < 起動モード取得 >

            //型チェック（Stringかどうか）
            if (parameter is string)
            {
                //起動モードを取得します（0:発注一覧表 1:発注残一覧表）
                this._selPrintMode = TStrConv.StrToIntDef((string)parameter, 0);
            }
            //起動モードが0～1以外の値であれば、デフォルト(発注一覧表)とする
            if ((this._selPrintMode < CT_SelPrintMode_OrderList) && (this._selPrintMode > CT_SelPrintMode_OrderRemList))
            {
                this._selPrintMode = CT_SelPrintMode_OrderList;
            }

            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = this._selPrintMode.ToString();

            #endregion
            // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            this._orderListCndtn = new OrderListCndtn();

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

                // 2008.11.10 30413 犬飼 拠点を追加可能に変更 >>>>>>START
                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }
                // 2008.11.10 30413 犬飼 拠点を追加可能に変更 <<<<<<END
            }
            // 拠点選択を解除した時
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
                }
            }


            // 2008.09.03 30413 犬飼 拠点選択で倉庫ガイドの設定を変更しない >>>>>>START
            //// 倉庫ガイドEnabled設定
            //// 拠点リストの要素が1つだけで1番目の要素が全社ではないときにTrueになる。
            //if ( ( this._selectedSectionList.Count == 1 ) && ( !this._selectedSectionList.ContainsKey( "0" ) ) )
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_WarehouseCodeGuide, this.ub_Ed_WarehouseCodeGuide, 
            //        string.Empty, string.Empty );
            //}
            //else
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_WarehouseCodeGuide, this.ub_Ed_WarehouseCodeGuide, 
            //        "0", string.Empty );
            //}
            // 2008.09.03 30413 犬飼 拠点選択で倉庫ガイドの設定を変更しない <<<<<<END
            
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
            return isDefaultState;
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
        /// <br>Note		: ハンディターミナル二次開発の対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/09/14</br>
        /// <br>Update Note : ㈱ダイサブの対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/11/05</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
                // 初期値セット・日付
                this.tde_ProcessDay.SetDateTime( DateTime.Today );
                //this.tde_Ed_OrderDataCreateDate.SetDateTime( DateTime.Today );

                // 初期値セット・文字列
                //this.te_St_StockAgentCode.DataText = string.Empty;
                //this.te_Ed_StockAgentCode.DataText = string.Empty;
                //this.te_St_StockInputCode.DataText = string.Empty;
                //this.te_Ed_StockInputCode.DataText = string.Empty;
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                //this.te_St_LargeGoodsGanreCode.DataText = string.Empty;
                //this.te_Ed_LargeGoodsGanreCode.DataText = string.Empty;
                //this.te_St_MediumGoodsGanreCode.DataText = string.Empty;
                //this.te_Ed_MediumGoodsGanreCode.DataText = string.Empty;
                //this.te_St_DetailGoodsGanreCode.DataText = string.Empty;
                //this.te_Ed_DetailGoodsGanreCode.DataText = string.Empty;
                //this.te_GoodsNo.DataText = string.Empty;

                // 2008.09.01 30413 犬飼 追加項目の初期値セット >>>>>>START
                this.tEdit_WarehouseCode1.DataText = string.Empty;                       // 倉庫単独１
                this.tEdit_WarehouseCode2.DataText = string.Empty;                       // 倉庫単独２
                this.tEdit_WarehouseCode3.DataText = string.Empty;                       // 倉庫単独３
                this.tEdit_WarehouseCode4.DataText = string.Empty;                       // 倉庫単独４
                this.tEdit_WarehouseCode5.DataText = string.Empty;                       // 倉庫単独５
                this.tEdit_WarehouseCode6.DataText = string.Empty;                       // 倉庫単独６
                // 2008.09.01 30413 犬飼 追加項目の初期値セット <<<<<<END
                

                // 初期値セット・数値
                //this.tne_St_SupplierCd.SetInt( 0 );
                //this.tne_Ed_SupplierCd.SetInt( 0 );
                ////this.tne_Ed_SupplierCd.SetInt( Int32.Parse( new string( '9', this.tne_Ed_SupplierCd.ExtEdit.Column ) ) );
                //this.tne_St_GoodsMakerCd.SetInt( 0 );
                //this.tne_Ed_GoodsMakerCd.SetInt( 0 );
                ////this.tne_Ed_GoodsMakerCd.SetInt( Int32.Parse( new string( '9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column ) ) );
                //this.tne_St_EnterpriseGanreCode.SetInt( 0 );
                //this.tne_Ed_EnterpriseGanreCode.SetInt( 0 );
                ////this.tne_Ed_EnterpriseGanreCode.SetInt( Int32.Parse( new string( '9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column ) ) );

                // 2008.09.01 30413 犬飼 追加項目の初期値セット >>>>>>START
                this.tNedit_SupplierCd_St.SetInt(0);
                this.tNedit_SupplierCd_Ed.SetInt(0);
                this.tNedit_SupplierCd1.SetInt(0);
                this.tNedit_SupplierCd2.SetInt(0);
                this.tNedit_SupplierCd3.SetInt(0);
                this.tNedit_SupplierCd4.SetInt(0);
                this.tNedit_SupplierCd5.SetInt(0);
                this.tNedit_SupplierCd6.SetInt(0);
                // 2008.09.01 30413 犬飼 追加項目の初期値セット <<<<<<END
                

                // 初期値セット・区分
                //this.uos_NotePrintDiv.Value = (int)OrderListCndtn.NotePrintDivState.None;
                //this.clb_OrderFormIssuedDiv.SetItemChecked( 0, true );
                //this.clb_OrderFormIssuedDiv.SetItemChecked( 1, true );
                //this.clb_StockOrderDivCd.SetItemChecked( 0, true );
                //this.clb_StockOrderDivCd.SetItemChecked( 1, true );
                this.ce_PrintSortDiv.SelectedIndex = 0;
                //this.clb_ArrivalStateDiv.SetItemChecked( 0, true );
                //this.clb_ArrivalStateDiv.SetItemChecked( 1, true );
                //this.clb_ArrivalStateDiv.SetItemChecked( 2, true );

                // 2008.09.01 30413 犬飼 追加項目の初期値セット >>>>>>START
                this.ce_ObjDiv.Value = 0;                           // 対象区分
                this.ce_BlanketStockInputDataDiv.Value = 0;         // 一括仕入入力データ作成
                this.ce_StockMinMaxPrintDiv.Value = 0;              // 現在庫・最低・最高
                this.ce_LotCalcDiv.Value = 0;                       // ロット計算
                this.ce_StkCntStandard.Value = 0;                   // 現在在庫基準
                this.ce_OrderStandard.Value = 0;                    // 発注基準
                this.ce_LendCntPrintDiv.Value = 0;                  // 貸出数
                this.ce_LendCntCalc.Value = 0;                      // 貸出数計算
                this.ce_NewPageDiv.Value = 0;                       // 改頁
                this.ce_FaxSendDiv.Value = 0;                       // FAX送信
                this.ce_WarehouseExtra.Value = 0;                   // 倉庫抽出条件
                this.ce_SupplierExtra.Value = 0;                    // 仕入先抽出条件
                this.ce_TrustStockDiv.Value = 0;                    // 受託在庫
                // 2008.09.01 30413 犬飼 追加項目の初期値セット <<<<<<END
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                this.tComboEditor_MakeCdDiv.Value = 1;
                this.tComboEditor_Method.Value = 0;
                this.ce_CoNmPrintOutCd.Value = 0;
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // 発注一覧表場合
                if (this._selPrintMode == CT_SelPrintMode_OrderList)
                {
                    // ハンディOP(仕入)オプション有無を取得する「false:OFF(使用不可) true:ON(使用可)」
                    IsOptHandySup = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Stock) > 0);

                    // ハンディOP(仕入)オプションはOFF場合
                    if (!IsOptHandySup)
                    {
                        // バーコード表示しない
                        this.tComboEditor_BarCodeShow.Value = 1;
                        this.tComboEditor_BarCodeShow.Visible = false;
                        this.BarCodeShow_Label.Visible = false;
                    }
                    else
                    {
                        // バーコード表示する
                        this.tComboEditor_BarCodeShow.Value = 0;
                        this.tComboEditor_BarCodeShow.Visible = true;
                        this.BarCodeShow_Label.Visible = true;
                    }

                    if (!this.ce_FaxSendDiv.Visible)
                    {
                        this.tComboEditor_BarCodeShow.Location = new System.Drawing.Point(518, 130);
                        this.BarCodeShow_Label.Location = new System.Drawing.Point(410, 130);
                    }

                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                    if (!this.ce_FaxSendDiv.Visible && !this.tComboEditor_BarCodeShow.Visible)
                    {
                        this.tComboEditor_MakeCdDiv.Location = new System.Drawing.Point(518, 130);
                        this.MakeCd_Label.Location = new System.Drawing.Point(410, 130);
                        this.tComboEditor_Method.Location = new System.Drawing.Point(518, 160);
                        this.Method_Label.Location = new System.Drawing.Point(410, 160);
                    }
                    else if (!this.ce_FaxSendDiv.Visible || !this.tComboEditor_BarCodeShow.Visible)
                    {
                        this.tComboEditor_MakeCdDiv.Location = new System.Drawing.Point(518, 160);
                        this.MakeCd_Label.Location = new System.Drawing.Point(410, 160);
                        this.tComboEditor_Method.Location = new System.Drawing.Point(518, 190);
                        this.Method_Label.Location = new System.Drawing.Point(410, 190);
                    }
                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                }
                else
                {
                    // バーコード表示しない
                    this.tComboEditor_BarCodeShow.Value = 1;
                    this.tComboEditor_BarCodeShow.Visible = false;
                    this.BarCodeShow_Label.Visible = false;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                // ボタン設定
                //this.SetIconImage( this.ub_St_StockAgentCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_StockAgentCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_StockInputCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_StockInputCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_SupplierCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_GoodsNoGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_LargeGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_LargeGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_MediumGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_MediumGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_DetailGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_DetailGoodsGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_EnterpriseGanreGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_EnterpriseGanreGuide, Size16_Index.STAR1 );
                // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END

                // 2008.09.01 30413 犬飼 追加項目のボタン設定 >>>>>>START
                this.SetIconImage(this.ub_Unit_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Unit_SupplierCodeGuide, Size16_Index.STAR1);
                // 2008.09.01 30413 犬飼 追加項目のボタン設定 <<<<<<END
                
                // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 出力項目の表示セット
                switch (this._selPrintMode)
                {
                    case CT_SelPrintMode_OrderList:
                        {
                            // 一括仕入入力データ作成(表示)
                            this.ce_BlanketStockInputDataDiv.Visible = true;
                            this.uLabel_BlanketStockInputDataDiv.Visible = true;

                            // 現在庫・最低・最高(位置変更)
                            this.ce_StockMinMaxPrintDiv.Location = new Point(179,100);
                            this.uLabel_StockMinMaxPrintDiv.Location = new Point(10, 100);

                            // ロット計算(表示)
                            this.ce_LotCalcDiv.Visible = true;
                            this.uLabel_LotCalcDiv.Visible = true;

                            // 現在庫数基準(表示)
                            this.ce_StkCntStandard.Visible = true;
                            this.uLabel_StkCntStandard.Visible = true;

                            // 発注基準(表示)
                            this.ce_OrderStandard.Visible = true;
                            this.uLabel_OrderStandard.Visible = true;

                            // 貸出数(位置変更)
                            this.ce_LendCntPrintDiv.Location = new Point(518, 40);
                            this.uLabel_LendCntPrintDiv.Location = new Point(410, 40);

                            // 貸出数計算(表示)
                            this.ce_LendCntCalc.Visible = true;
                            this.uLabel_LendCntCalc.Visible = true;

                            // 改頁(位置変更)
                            this.ce_NewPageDiv.Location = new Point(518, 100);
                            this.uLabel_NewPageDiv.Location = new Point(410, 100);

                            break;

                        }
                    case CT_SelPrintMode_OrderRemList:
                        {
                            // 一括仕入入力データ作成(非表示)
                            this.ce_BlanketStockInputDataDiv.Visible = false;
                            this.uLabel_BlanketStockInputDataDiv.Visible = false;

                            // 現在庫・最低・最高(位置変更)
                            this.ce_StockMinMaxPrintDiv.Location = new Point(179, 70);
                            this.uLabel_StockMinMaxPrintDiv.Location = new Point(10, 70);

                            // ロット計算(非表示)
                            this.ce_LotCalcDiv.Visible = false;
                            this.uLabel_LotCalcDiv.Visible = false;

                            // 現在庫数基準(非表示)
                            this.ce_StkCntStandard.Visible = false;
                            this.uLabel_StkCntStandard.Visible = false;

                            // 発注基準(非表示)
                            this.ce_OrderStandard.Visible = false;
                            this.uLabel_OrderStandard.Visible = false;

                            // 貸出数(位置変更)
                            this.ce_LendCntPrintDiv.Location = new Point(179, 100);
                            this.uLabel_LendCntPrintDiv.Location = new Point(10, 100);

                            // 貸出数計算(非表示)
                            this.ce_LendCntCalc.Visible = false;
                            this.uLabel_LendCntCalc.Visible = false;

                            // 改頁(位置変更)
                            this.ce_NewPageDiv.Location = new Point(179, 130);
                            this.uLabel_NewPageDiv.Location = new Point(10, 130);
                            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                            this.tComboEditor_MakeCdDiv.Location = new System.Drawing.Point(179, 160);
                            this.MakeCd_Label.Location = new System.Drawing.Point(10, 160);
                            this.tComboEditor_Method.Location = new System.Drawing.Point(179, 190);
                            this.Method_Label.Location = new System.Drawing.Point(10, 190);
                            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>

                            break;

                        }
                }

                // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 初期フォーカスセット
                this.tde_ProcessDay.Focus();
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region ガイド後次項目の設定
        ///// <summary>
        ///// ガイド後次項目の設定
        ///// </summary>
        //private void SettingGuideNextControl()
        //{
        //    // コントロールのガイド後フォーカス順を設定するリストを生成
        //    List<Control> controls = new List<Control>();

        //    // リストに追加する
        //    controls.AddRange( new Control[] { te_St_StockAgentCode, te_Ed_StockAgentCode } );
        //    controls.AddRange( new Control[] { te_St_StockInputCode, te_Ed_StockInputCode } );
        //    controls.AddRange( new Control[] { te_St_WarehouseCode, te_Ed_WarehouseCode } );
        //    controls.AddRange( new Control[] { tne_St_SupplierCd, tne_Ed_SupplierCd } );
        //    controls.AddRange( new Control[] { tne_St_GoodsMakerCd, tne_Ed_GoodsMakerCd } );
        //    controls.AddRange( new Control[] { te_GoodsNo } );
        //    controls.AddRange( new Control[] { te_St_LargeGoodsGanreCode, te_Ed_LargeGoodsGanreCode } );
        //    controls.AddRange( new Control[] { te_St_MediumGoodsGanreCode, te_Ed_MediumGoodsGanreCode } );
        //    controls.AddRange( new Control[] { te_St_DetailGoodsGanreCode, te_Ed_DetailGoodsGanreCode } );
        //    controls.AddRange( new Control[] { tne_St_EnterpriseGanreCode, tne_Ed_EnterpriseGanreCode } );


        //    // 最終項目は最後に２重に格納する
        //    controls.Add( controls[controls.Count - 1] );

        //    // コントロールのリストからディクショナリを生成
        //    _nextControl = new Dictionary<Control, Control>();
        //    for ( int index = 0; index < controls.Count - 1; index++ )
        //    {
        //        _nextControl.Add( controls[index], controls[index + 1] );
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

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
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            // 2008.10.27 30413 犬飼 未使用プロパティの削除 >>>>>>START
            //DateGetAcs.CheckDateRangeResult cdrResult;
            DateGetAcs.CheckDateResult cdResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            //const string ct_RangeOverError = "は１ヶ月の範囲内で入力して下さい";
            const string ct_InputUnitError = "の抽出条件が単独指定の場合は一つ以上入力して下さい";
            // 2008.10.27 30413 犬飼 未使用プロパティの削除 <<<<<<END
            

            // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
            //// 入力日付（開始～終了）
            //if ( CallCheckDateRange( out cdrResult, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始入力日付{0}", ct_NoInput );
            //                errComponent = this.tde_St_OrderDataCreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始入力日付{0}", ct_InputError );
            //                errComponent = this.tde_St_OrderDataCreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了入力日付{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_OrderDataCreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了入力日付{0}", ct_InputError );
            //                errComponent = this.tde_Ed_OrderDataCreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "入力日付{0}", ct_RangeError );
            //                errComponent = this.tde_St_OrderDataCreateDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "入力日付{0}", ct_RangeOverError );
            //                errComponent = this.tde_St_OrderDataCreateDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END

            // 発注日（開始～終了）
            //else if ( CallCheckDateRange( out cdrResult, ref tde_St_OrderFormPrintDate, ref tde_Ed_OrderFormPrintDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始発注日{0}", ct_NoInput );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始発注日{0}", ct_InputError );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了発注日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了発注日{0}", ct_InputError );
            //                errComponent = this.tde_Ed_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "発注日{0}", ct_RangeError );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "発注日{0}", ct_RangeOverError );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}

            // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
            //else if (CallCheckDate(out cdResult, ref tde_St_OrderFormPrintDate) == false)
            //{
            //    // 開始日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "開始発注日{0}", ct_InputError );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "開始発注日{0}", ct_NoInput );
            //                errComponent = this.tde_St_OrderFormPrintDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( CallCheckDate( out cdResult, ref tde_Ed_OrderFormPrintDate ) == false )
            //{
            //    // 終了日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "終了発注日{0}", ct_InputError );
            //                errComponent = this.tde_Ed_OrderFormPrintDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "終了発注日{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_OrderFormPrintDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( tde_St_OrderFormPrintDate.GetDateTime() > GetEndDate( tde_Ed_OrderFormPrintDate.GetDateTime() ) )
            //{
            //    // 開始＞終了
            //    errMessage = string.Format( "発注日{0}", ct_RangeError );
            //    errComponent = this.tde_St_OrderFormPrintDate;
            //    status = false;
            //}
            // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END
            
            // 希望納期（開始～終了）
            //else if ( CallCheckDateRange( out cdrResult, ref tde_St_ExpectDeliveryDate, ref tde_Ed_ExpectDeliveryDate ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始希望納期{0}", ct_NoInput );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始希望納期{0}", ct_InputError );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了希望納期{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了希望納期{0}", ct_InputError );
            //                errComponent = this.tde_Ed_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "希望納期{0}", ct_RangeError );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "希望納期{0}", ct_RangeOverError );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}

            // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
            //else if (CallCheckDate(out cdResult, ref tde_St_ExpectDeliveryDate) == false)
            //{
            //    // 開始日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "開始希望納期{0}", ct_InputError );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "開始希望納期{0}", ct_NoInput );
            //                errComponent = this.tde_St_ExpectDeliveryDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( CallCheckDate( out cdResult, ref tde_Ed_ExpectDeliveryDate ) == false )
            //{
            //    // 終了日
            //    switch ( cdResult )
            //    {
            //        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
            //            {
            //                errMessage = string.Format( "終了希望納期{0}", ct_InputError );
            //                errComponent = this.tde_Ed_ExpectDeliveryDate;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
            //            {
            //                errMessage = string.Format( "終了希望納期{0}", ct_NoInput );
            //                errComponent = this.tde_Ed_ExpectDeliveryDate;
            //            }
            //            break;
            //    }
            //    status = false;
            //}
            //else if ( tde_St_ExpectDeliveryDate.GetDateTime() > GetEndDate( tde_Ed_ExpectDeliveryDate.GetDateTime() ) )
            //{
            //    // 開始＞終了
            //    errMessage = string.Format( "希望納期{0}", ct_RangeError );
            //    errComponent = this.tde_St_ExpectDeliveryDate;
            //    status = false;
            //}
            //// 担当者
            //else if (
            //    (this.te_St_StockAgentCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_StockAgentCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_StockAgentCode.DataText.TrimEnd().CompareTo( this.te_Ed_StockAgentCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "担当者コード{0}", ct_RangeError );
            //    errComponent = this.te_St_StockAgentCode;
            //    status = false;
            //}
            //// 入力者
            //else if (
            //    (this.te_St_StockInputCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_StockInputCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_StockInputCode.DataText.TrimEnd().CompareTo( this.te_Ed_StockInputCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "入力者コード{0}", ct_RangeError );
            //    errComponent = this.te_St_WarehouseCode;
            //    status = false;
            //}
            //// 発注先（開始 > 終了 → NG）
            //else if ( this.tne_St_SupplierCd.GetInt() > GetEndCode( this.tne_Ed_SupplierCd ) )
            //{
            //    errMessage = string.Format( "発注先コード{0}", ct_RangeError );
            //    errComponent = this.tne_St_SupplierCd;
            //    status = false;
            //}
            //// 倉庫コード
            //else if (
            //    (this.te_St_WarehouseCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_WarehouseCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_WarehouseCode.DataText.TrimEnd().CompareTo( this.te_Ed_WarehouseCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "倉庫コード{0}", ct_RangeError );
            //    errComponent = this.te_St_WarehouseCode;
            //    status = false;
            //}
            //// メーカー（開始 > 終了 → NG）
            //else if ( this.tne_St_GoodsMakerCd.GetInt() > GetEndCode( this.tne_Ed_GoodsMakerCd ) )
            //{
            //    errMessage = string.Format( "メーカーコード{0}", ct_RangeError );
            //    errComponent = this.tne_St_GoodsMakerCd;
            //    status = false;
            //}
            // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END

            //// 商品番号
            //else if ( this.te_GoodsNo.DataText.TrimEnd() != string.Empty )
            //{
            //    errMessage = string.Format("商品番号{0}", ct_RangeError);
            //    errComponent = this.te_GoodsNo;
            //    status = false;
            //}

            // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
            // 商品区分グループ (開始 > 終了 → NG)
            //else if (
            //    (this.te_St_LargeGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_LargeGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_LargeGoodsGanreCode.DataText.TrimEnd().CompareTo( this.te_Ed_LargeGoodsGanreCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "商品区分グループ{0}", ct_RangeError );
            //    errComponent = this.te_St_LargeGoodsGanreCode;
            //    status = false;
            //}
            //// 商品区分 (開始 > 終了 → NG)
            //else if (
            //    (this.te_St_MediumGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_MediumGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_MediumGoodsGanreCode.DataText.TrimEnd().CompareTo( this.te_Ed_MediumGoodsGanreCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "商品区分{0}", ct_RangeError );
            //    errComponent = this.te_St_MediumGoodsGanreCode;
            //    status = false;
            //}
            //// 商品区分詳細 (開始 > 終了 → NG)
            //else if (
            //    (this.te_St_DetailGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_Ed_DetailGoodsGanreCode.DataText.TrimEnd() != string.Empty) &&
            //    (this.te_St_DetailGoodsGanreCode.DataText.TrimEnd().CompareTo( this.te_Ed_DetailGoodsGanreCode.DataText.TrimEnd() ) > 0) )
            //{
            //    errMessage = string.Format( "商品区分詳細{0}", ct_RangeError );
            //    errComponent = this.te_St_DetailGoodsGanreCode;
            //    status = false;
            //}
            //// 自社分類 (開始 > 終了 → NG)
            //else if ( this.tne_St_EnterpriseGanreCode.GetInt() > GetEndCode( this.tne_Ed_EnterpriseGanreCode ) )
            //{
            //    errMessage = string.Format( "自社分類{0}", ct_RangeError );
            //    errComponent = this.tne_St_EnterpriseGanreCode;
            //    status = false;
            //}
            // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END


            // 2008.09.02 30413 犬飼 処理日のチェック >>>>>>START
            if (CallCheckDate(out cdResult, ref tde_ProcessDay) == false)
            {
                // 処理日
                switch ( cdResult )
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("処理日{0}", ct_InputError);
                            errComponent = this.tde_ProcessDay;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("処理日{0}", ct_NoInput);
                            errComponent = this.tde_ProcessDay;
                        }
                        break;
                }
                status = false;
                return status;
            }
            // 2008.09.02 30413 犬飼 処理日のチェック <<<<<<END

            // 2008.09.04 30413 犬飼 倉庫、仕入先のチェック >>>>>>START
            // 倉庫チェック
            if ((int)this.ce_WarehouseExtra.Value == 0)
            {
                // 範囲
                if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
                {
                    errMessage = string.Format("倉庫{0}", ct_RangeError);
                    errComponent = this.tEdit_WarehouseCode_St;
                    status = false;
                    return status;
                }
            }
            else if ((int)this.ce_WarehouseExtra.Value == 1)
            {
                bool warehouseFlg = false;
                // 単独
                if (this.tEdit_WarehouseCode1.Text != "")
                {
                    warehouseFlg = true;
                }
                else if (this.tEdit_WarehouseCode2.Text != "")
                {
                    warehouseFlg = true;
                }
                else if (this.tEdit_WarehouseCode3.Text != "")
                {
                    warehouseFlg = true;
                }
                else if (this.tEdit_WarehouseCode4.Text != "")
                {
                    warehouseFlg = true;
                }
                else if (this.tEdit_WarehouseCode5.Text != "")
                {
                    warehouseFlg = true;
                }
                else if (this.tEdit_WarehouseCode6.Text != "")
                {
                    warehouseFlg = true;
                }

                if (!warehouseFlg)
                {
                    errMessage = string.Format("倉庫{0}", ct_InputUnitError);
                    errComponent = this.tEdit_WarehouseCode1;
                    status = false;
                    return status;
                }
            }

            // 仕入先チェック
            if ((int)this.ce_SupplierExtra.Value == 0)
            {
                // 範囲
                if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                {
                    errMessage = string.Format("仕入先{0}", ct_RangeError);
                    errComponent = this.tNedit_SupplierCd_St;
                    status = false;
                }                
            }
            else if ((int)this.ce_SupplierExtra.Value == 1)
            {
                bool supplierFlg = false;

                // 単独
                // 2008.12.05 30413 犬飼 抽出条件の設定を変更 >>>>>>START
                //if (this.tNedit_SupplierCd1.Text != "")
                //{
                //    supplierFlg = true;
                //}
                //else if (this.tNedit_SupplierCd2.Text != "")
                //{
                //    supplierFlg = true;
                //}
                //else if (this.tNedit_SupplierCd3.Text != "")
                //{
                //    supplierFlg = true;
                //}
                //else if (this.tNedit_SupplierCd4.Text != "")
                //{
                //    supplierFlg = true;
                //}
                //else if (this.tNedit_SupplierCd5.Text != "")
                //{
                //    supplierFlg = true;
                //}
                //else if (this.tNedit_SupplierCd6.Text != "")
                //{
                //    supplierFlg = true;
                //}

                if (this.tNedit_SupplierCd1.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd2.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd3.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd4.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd5.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                else if (this.tNedit_SupplierCd6.GetInt() != 0)
                {
                    supplierFlg = true;
                }
                // 2008.12.05 30413 犬飼 抽出条件の設定を変更 <<<<<<END
                
                if (!supplierFlg)
                {
                    errMessage = string.Format("仕入先{0}", ct_InputUnitError);
                    errComponent = this.tNedit_SupplierCd1;
                    status = false;
                }
            }
            // 2008.09.04 30413 犬飼 倉庫、仕入先のチェック <<<<<<END
            
            return status;
        }

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 日付チェック処理呼び出し
        ///// <summary>
        ///// 日付チェック処理呼び出し
        ///// </summary>
        ///// <param name="cdrResult"></param>
        ///// <param name="tde_St_OrderDataCreateDate"></param>
        ///// <param name="tde_Ed_OrderDataCreateDate"></param>
        ///// <returns></returns>
        //private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate )
        //{
        //    cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true, false );
        //    return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        /// <summary>
        /// 日付チェック処理呼び出し（発注日用 単独）
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate( out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit )
        {
            cdResult = _dateGetAcs.CheckDate( ref targetDateEdit, true );
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 終了日取得処理（未入力はMax扱いする）
        ///// <summary>
        ///// 終了日取得処理（未入力はMax扱いする）
        ///// </summary>
        ///// <param name="dateTime"></param>
        ///// <returns></returns>
        //private DateTime GetEndDate( DateTime dateTime )
        //{
        //    if ( dateTime == DateTime.MinValue )
        //    {
        //        return DateTime.MaxValue;
        //    }
        //    else
        //    {
        //        return dateTime;
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 数値項目　終了コード取得処理
        ///// <summary>
        ///// 数値項目　終了コード取得処理
        ///// </summary>
        ///// <param name="tNedit"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>数値コード項目の内容を取得する</br>
        ///// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        ///// <br>　コード値≠ゼロ　→　入力値</br>
        ///// </remarks>
        //private int GetEndCode( TNedit tNedit )
        //{
        //    // 画面上コンポーネントのColumnで終了コードを取得
        //    return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 数値項目　終了コード取得処理
        ///// <summary>
        ///// 数値項目　終了コード取得処理
        ///// </summary>
        ///// <param name="tNedit"></param>
        ///// <param name="endCodeOnDB"></param>
        ///// <returns></returns>
        //private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        //{
        //    if ( tNedit.GetInt() == 0 )
        //    {
        //        return endCodeOnDB;
        //    }
        //    else
        //    {
        //        return tNedit.GetInt();
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

		// 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region ◎ 日付入力チェック処理
        ///// <summary>
        ///// 日付入力チェック処理
        ///// </summary>
        ///// <param name="targetDateEdit">チェック対象コントロール</param>
        ///// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
        ///// <returns>チェック結果(true/false)</returns>
        ///// <remarks>
        ///// <br>Note		: 日付入力のチェックを行う。</br>
        ///// <br>Programmer	: 22018 鈴木 正臣</br>
        ///// <br>Date		: 2007.09.19</br>
        ///// </remarks>
        //private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
        //{
        //    bool status = true;

        //    // 入力日付を数値型で取得
        //    int date = targetDateEdit.GetLongDate();
        //    int yy = date / 10000;
        //    int mm = ( date / 100 ) % 100;
        //    int dd = date % 100;

        //    // 日付未入力チェック
        //    if ( targetDateEdit.LongDate <= 0 )
        //    {
        //        if( allowEmpty == true ) 
        //        {
        //            return status;
        //        }
        //        else 
        //        {
        //            status = false;
        //        }
        //    }
        //    // システムサポートチェック
        //    else if( yy < 1900 )
        //    {
        //        status = false;
        //    }
        //    // 年月日別入力チェック
        //    else if( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
        //    {
        //        status = false;
        //    }
        //    // 単純日付妥当性チェック
        //    else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
        //    {
        //        status = false;
        //    }

        //    return status;
        //}
		#endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Note		: ハンディターミナル二次開発の対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/09/14</br>
        /// <br>Update Note : ㈱ダイサブの対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/11/05</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // 拠点コードの全社チェック判定
                bool allSections = false;
                foreach ( object obj in this._selectedSectionList.Values )
                {
                    if ( (obj as string) == "0" )
                    {
                        allSections = true;
                        break;
                    }
                }
                // 全社チェックされていたらリストをクリア
                if ( allSections )
                {
                    this._selectedSectionList.Clear();
                }


                // 拠点オプション
                this._orderListCndtn.IsOptSection = this._isOptSection;

                // 企業コード
                this._orderListCndtn.EnterpriseCode = this._enterpriseCode;
                // 拠点コード（複数指定）
                this._orderListCndtn.SectionCodes = (string[])new ArrayList( this._selectedSectionList.Values ).ToArray( typeof( string ) );

                // 2008.09.01 30413 犬飼 既存項目の削除 >>>>>>START
                //// 開始入力日
                //this._orderListCndtn.St_OrderDataCreateDate = this.tde_St_OrderDataCreateDate.GetDateTime();
                //// 終了入力日
                //this._orderListCndtn.Ed_OrderDataCreateDate = this.tde_Ed_OrderDataCreateDate.GetDateTime();
                //// 開始発行日
                //this._orderListCndtn.St_OrderFormPrintDate = this.tde_St_OrderFormPrintDate.GetDateTime();
                //// 終了発行日
                //this._orderListCndtn.Ed_OrderFormPrintDate = this.tde_Ed_OrderFormPrintDate.GetDateTime();
                //// 開始希望納期
                //this._orderListCndtn.St_ExpectDeliveryDate = this.tde_St_ExpectDeliveryDate.GetDateTime();
                //// 終了希望納期
                //this._orderListCndtn.Ed_ExpectDeliveryDate = this.tde_Ed_ExpectDeliveryDate.GetDateTime();
                //// 発注書発行済区分（複数指定）
                //this._orderListCndtn.OrderFormIssuedDivs = this.GetOrderFormIssuedDivs();
                //// 仕入在庫取寄せ区分（複数指定）
                //this._orderListCndtn.StockOrderDivCds = this.GetStockOrderDivCds();
                //// 入荷状況区分 (複数指定)
                //this._orderListCndtn.ArrivalStateDiv = this.GetArrivalStateDivs();
                //// 開始仕入担当者コード
                //this._orderListCndtn.St_StockAgentCode = (string)this.te_St_StockAgentCode.Text;
                //// 終了仕入担当者コード
                //this._orderListCndtn.Ed_StockAgentCode = (string)this.te_Ed_StockAgentCode.Text;
                //// 開始仕入入力者コード
                //this._orderListCndtn.St_StockInputCode = (string)this.te_St_StockInputCode.Text;
                //// 終了仕入入力者コード
                //this._orderListCndtn.Ed_StockInputCode = (string)this.te_Ed_StockInputCode.Text;
                //// 開始仕入先コード
                //this._orderListCndtn.St_SupplierCd = this.tne_St_SupplierCd.GetInt();
                //// 終了仕入先コード
                //this._orderListCndtn.Ed_SupplierCd = GetEndCode( this.tne_Ed_SupplierCd, 999999999 );
                //// 開始倉庫コード
                //this._orderListCndtn.St_WarehouseCode = (string)this.te_St_WarehouseCode.Text;
                //// 終了倉庫コード
                //this._orderListCndtn.Ed_WarehouseCode = (string)this.te_Ed_WarehouseCode.Text;
                //// 開始商品メーカーコード
                //this._orderListCndtn.St_GoodsMakerCd = this.tne_St_GoodsMakerCd.GetInt();
                //// 終了商品メーカーコード
                //this._orderListCndtn.Ed_GoodsMakerCd = GetEndCode( this.tne_Ed_GoodsMakerCd, 999999 );

                //// 開始商品番号 (←画面上の商品番号を開始と終了の両方にセット)
                //this._orderListCndtn.St_GoodsNo = (string)this.te_GoodsNo.Text;
                //// 終了商品番号 (←画面上の商品番号を開始と終了の両方にセット)
                //this._orderListCndtn.Ed_GoodsNo = (string)this.te_GoodsNo.Text;

                //// 開始商品区分グループ
                //this._orderListCndtn.St_LargeGoodsGanreCode = (string)this.te_St_LargeGoodsGanreCode.Text;
                //// 終了商品区分グループ
                //this._orderListCndtn.Ed_LargeGoodsGanreCode = (string)this.te_Ed_LargeGoodsGanreCode.Text;
                //// 開始商品区分
                //this._orderListCndtn.St_MediumGoodsGanreCode = (string)this.te_St_MediumGoodsGanreCode.Text;
                //// 終了商品区分
                //this._orderListCndtn.Ed_MediumGoodsGanreCode = (string)this.te_Ed_MediumGoodsGanreCode.Text;
                //// 開始商品区分詳細
                //this._orderListCndtn.St_DetailGoodsGanreCode = (string)this.te_St_DetailGoodsGanreCode.Text;
                //// 終了商品区分詳細
                //this._orderListCndtn.Ed_DetailGoodsGanreCode = (string)this.te_Ed_DetailGoodsGanreCode.Text;
                //// 開始自社分類
                //this._orderListCndtn.St_EnterpriseGanreCode = (int)this.tne_St_EnterpriseGanreCode.GetInt();
                //// 終了自社分類
                //this._orderListCndtn.Ed_EnterpriseGanreCode = GetEndCode( this.tne_Ed_EnterpriseGanreCode, 9999 );

                //// 赤伝区分（複数指定）
                //this._orderListCndtn.DebitNoteDivs = null; //this.GetDebitNoteDivs();
                //// 仕入伝票区分（複数指定）
                //this._orderListCndtn.SupplierSlipCds = null; //this.GetSupplierSlipCds();
                

                //// 印刷順
                //this._orderListCndtn.PrintSortDiv = (OrderListCndtn.PrintSortDivState)this.ce_PrintSortDiv.Value;
                //// メモ印刷区分
                //this._orderListCndtn.NotePrintDiv = (OrderListCndtn.NotePrintDivState)this.uos_NotePrintDiv.Value;
                // 2008.09.01 30413 犬飼 既存項目の削除 <<<<<<END

                // 2008.09.02 30413 犬飼 項目の追加 >>>>>>START
                // 処理日
                this._orderListCndtn.ProcessDay = this.tde_ProcessDay.GetDateTime();

                // 対象区分
                this._orderListCndtn.ObjDiv = (int)this.ce_ObjDiv.Value;

                // 一括仕入入力データ作成
                this._orderListCndtn.BlanketStockInputDataDiv = (int)this.ce_BlanketStockInputDataDiv.Value;

                // 現在庫・最低・最高
                this._orderListCndtn.StockMinMaxPrintDiv = (int)this.ce_StockMinMaxPrintDiv.Value;

                // ロット計算
                this._orderListCndtn.LotCalcDiv = (int)this.ce_LotCalcDiv.Value;

                // 現在庫数基準
                this._orderListCndtn.StkCntStandard = (int)this.ce_StkCntStandard.Value;

                // 発注基準
                this._orderListCndtn.OrderStandard = (int)this.ce_OrderStandard.Value;

                // 貸出数
                this._orderListCndtn.LendCntPrintDiv = (int)this.ce_LendCntPrintDiv.Value;

                // 貸出数計算
                this._orderListCndtn.LendCntCalc = (int)this.ce_LendCntCalc.Value;

                // 改頁
                this._orderListCndtn.NewPageDiv = (int)this.ce_NewPageDiv.Value;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // 発注一覧表場合、ハンディOP(仕入)オプションはON場合
                if (this._selPrintMode == CT_SelPrintMode_OrderList && IsOptHandySup)
                {
                    // バーコード表示区分
                    this._orderListCndtn.BarCodeShowDiv = (int)this.tComboEditor_BarCodeShow.Value;
                }
                else
                {
                    // バーコード表示区分
                    this._orderListCndtn.BarCodeShowDiv = 1;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                // FAX送信
                this._orderListCndtn.FaxSendDiv = (int)this.ce_FaxSendDiv.Value;

                // 印刷順
                this._orderListCndtn.PrintSortDiv = (OrderListCndtn.PrintSortDivState)this.ce_PrintSortDiv.Value;
                
                // 倉庫抽出条件
                this._orderListCndtn.WarehouseExtra = (int)this.ce_WarehouseExtra.Value;

                if (this._orderListCndtn.WarehouseExtra == 0)
                {
                    // 範囲
                    // 開始
                    if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                    {
                        this._orderListCndtn.St_WarehouseCode = "";
                    }
                    else
                    {
                        this._orderListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                    }

                    // 終了
                    if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                    {
                        this._orderListCndtn.Ed_WarehouseCode = "";
                    }
                    else
                    {
                        this._orderListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                    }
                    this._orderListCndtn.WarehouseCodes = null;
                }
                else
                {
                    // 単独
                    ArrayList unitList = new ArrayList();

                    if (this.tEdit_WarehouseCode1.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode1.Text.TrimEnd().PadLeft(4, '0'));
                    }
                    if (this.tEdit_WarehouseCode2.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode2.Text.TrimEnd().PadLeft(4, '0'));
                    }
                    if (this.tEdit_WarehouseCode3.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode3.Text.TrimEnd().PadLeft(4, '0'));
                    }
                    if (this.tEdit_WarehouseCode4.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode4.Text.TrimEnd().PadLeft(4, '0'));
                    }
                    if (this.tEdit_WarehouseCode5.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode5.Text.TrimEnd().PadLeft(4, '0'));
                    }
                    if (this.tEdit_WarehouseCode6.Text.TrimEnd() != "")
                    {
                        unitList.Add(this.tEdit_WarehouseCode6.Text.TrimEnd().PadLeft(4, '0'));
                    }

                    string[] unitBuff = new string[unitList.Count];

                    for (int i = 0; i < unitList.Count; i++)
                    {
                        unitBuff[i] = (string)unitList[i];
                    }

                    this._orderListCndtn.WarehouseCodes = unitBuff;
                }

                // 仕入先抽出条件
                this._orderListCndtn.SupplierExtra = (int)this.ce_SupplierExtra.Value;

                if (this._orderListCndtn.SupplierExtra == 0)
                {
                    // 範囲
                    this._orderListCndtn.St_SupplierCode = this.tNedit_SupplierCd_St.GetInt();
                    this._orderListCndtn.Ed_SupplierCode = this.tNedit_SupplierCd_Ed.GetInt();
                    this._orderListCndtn.SupplierCodes = null;
                }
                else
                {
                    // 単独
                    ArrayList unitList = new ArrayList();
                  
                    // 2008.12.05 30413 犬飼 抽出条件の設定を変更 >>>>>>START
                    //if (this.tNedit_SupplierCd1.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd1.Text.Trim());
                    //}
                    //if (this.tNedit_SupplierCd2.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd2.Text.Trim());
                    //}
                    //if (this.tNedit_SupplierCd3.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd3.Text.Trim());
                    //}
                    //if (this.tNedit_SupplierCd4.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd4.Text.Trim());
                    //}
                    //if (this.tNedit_SupplierCd5.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd5.Text.Trim());
                    //}
                    //if (this.tNedit_SupplierCd6.Text != "")
                    //{
                    //    unitList.Add(this.tNedit_SupplierCd6.Text.Trim());
                    //}

                    if (this.tNedit_SupplierCd1.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd1.GetInt());
                    }
                    if (this.tNedit_SupplierCd2.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd2.GetInt());
                    }
                    if (this.tNedit_SupplierCd3.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd3.GetInt());
                    }
                    if (this.tNedit_SupplierCd4.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd4.GetInt());
                    }
                    if (this.tNedit_SupplierCd5.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd5.GetInt());
                    }
                    if (this.tNedit_SupplierCd6.GetInt() != 0)
                    {
                        unitList.Add(this.tNedit_SupplierCd6.GetInt());
                    }
                    // 2008.12.05 30413 犬飼 抽出条件の設定を変更 <<<<<<END
                    
                    int[] unitBuff = new int[unitList.Count];

                    for (int i = 0; i < unitList.Count; i++)
                    {
                        unitBuff[i] = (int)unitList[i];
                    }

                    this._orderListCndtn.SupplierCodes = unitBuff;
                }
                // 2008.09.02 30413 犬飼 項目の追加 <<<<<<END
                
                // 2008.11.10 30413 犬飼 受託在庫区分の追加 >>>>>>START
                // 受託在庫区分
                this._orderListCndtn.TrustStockDiv = (int)this.ce_TrustStockDiv.Value;
                // 2008.11.10 30413 犬飼 受託在庫区分の追加 <<<<<<END

                // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 帳票タイプ(0:発注一覧表 1:発注残一覧表)
                this._orderListCndtn.PrtPaperTypeDiv = this._selPrintMode;
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                // メーカー出力区分
                this._orderListCndtn.MakerCdDiv = (int)this.tComboEditor_MakeCdDiv.Value;
                // 自社名印字区分
                this._orderListCndtn.CoNmPrintOutCd = (int)this.ce_CoNmPrintOutCd.Value;
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                // 1:発注残一覧表の場合、不要な条件を削除
                if (this._selPrintMode == CT_SelPrintMode_OrderRemList)
                {
                    /*
                    // 一括仕入入力データ作成
                    this._orderListCndtn.BlanketStockInputDataDiv = null;

                    // ロット計算
                    this._orderListCndtn.LotCalcDiv = null;

                    // 現在庫数基準
                    this._orderListCndtn.StkCntStandard = null;

                    // 発注基準
                    this._orderListCndtn.OrderStandard = null;

                    // 貸出数計算
                    this._orderListCndtn.LendCntCalc = null;
                    */
                }
                // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 発注書発行済区分（複数指定）取得
        ///// <summary>
        ///// 発注書発行済区分（複数指定）取得
        ///// </summary>
        ///// <returns>発注書発行済区分（複数指定）</returns>
        //private int[] GetOrderFormIssuedDivs()
        //{
        //    List<int> divList = new List<int>();

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 発注済みチェック
        //    //if ( this.clb_OrderFormIssuedDiv.GetItemChecked(0) ) {
        //    //    divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.Printed );
        //    //}

        //    //// 未発注チェック
        //    //if ( this.clb_OrderFormIssuedDiv.GetItemChecked(1) ) {
        //    //    divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.NoPrinted );
        //    //}

        //    // 未発注チェック
        //    if ( this.clb_OrderFormIssuedDiv.GetItemChecked( 0 ) )
        //    {
        //        divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.NoPrinted );
        //    }

        //    // 発注済みチェック
        //    if ( this.clb_OrderFormIssuedDiv.GetItemChecked( 1 ) )
        //    {
        //        divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.Printed );
        //    }
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    // (未チェックの場合は全て)
        //    if (divList.Count == 0) {
        //        divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.Printed );
        //        divList.Add( (int)OrderListCndtn.OrderFormIssuedDivState.NoPrinted );
        //    }

        //    return divList.ToArray();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 仕入在庫取寄せ区分（複数指定）取得
        ///// <summary>
        ///// 仕入在庫取寄せ区分（複数指定）取得
        ///// </summary>
        ///// <returns>仕入在庫取寄せ区分（複数指定）</returns>
        //private int[] GetStockOrderDivCds ()
        //{
        //    List<int> divList = new List<int>();

        //    // 在庫分チェック
        //    if ( this.clb_StockOrderDivCd.GetItemChecked(0) ) {
        //        divList.Add(( int ) OrderListCndtn.StockOrderDivCdState.Stock);
        //    }

        //    // 取寄せ分チェック
        //    if ( this.clb_StockOrderDivCd.GetItemChecked(1) ) {
        //        divList.Add(( int ) OrderListCndtn.StockOrderDivCdState.Order);
        //    }

        //    // (未チェックの場合は全て)
        //    if ( divList.Count == 0 ) {
        //        divList.Add(( int ) OrderListCndtn.StockOrderDivCdState.Stock);
        //        divList.Add(( int ) OrderListCndtn.StockOrderDivCdState.Order);
        //    }

        //    return divList.ToArray();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 入荷状況区分（複数指定）取得
        ///// <summary>
        ///// 入荷状況区分（複数指定）取得
        ///// </summary>
        ///// <returns></returns>
        //private int[] GetArrivalStateDivs()
        //{
        //    List<int> divList = new List<int>();

        //    //OrderListCndtn.ArrivalStateDivState divState = ( OrderListCndtn.ArrivalStateDivState ) this.ce_ArrivalStateDiv.SelectedIndex;

        //    //switch ( divState ){
        //    //    case OrderListCndtn.ArrivalStateDivState.NoArrivaled:
        //    //        divList.Add((int)OrderListCndtn.ArrivalStateDivState.NoArrivaled);
        //    //        break;
        //    //    case OrderListCndtn.ArrivalStateDivState.PartArrivaled:
        //    //        divList.Add((int)OrderListCndtn.ArrivalStateDivState.PartArrivaled);
        //    //        break;
        //    //    case OrderListCndtn.ArrivalStateDivState.AllArrivaled:
        //    //        divList.Add((int)OrderListCndtn.ArrivalStateDivState.AllArrivaled);
        //    //        break;
        //    //    case OrderListCndtn.ArrivalStateDivState.AllData:
        //    //        divList.Add(( int ) OrderListCndtn.ArrivalStateDivState.NoArrivaled);
        //    //        divList.Add(( int ) OrderListCndtn.ArrivalStateDivState.PartArrivaled);
        //    //        divList.Add(( int ) OrderListCndtn.ArrivalStateDivState.AllArrivaled);
        //    //        break;
        //    //}

        //    // 未入荷分チェック
        //    if ( this.clb_ArrivalStateDiv.GetItemChecked( 0 ) )
        //    {
        //        divList.Add( (int)OrderListCndtn.ArrivalStateDivState.NoArrivaled );
        //    }
        //    // 一部入荷済分チェック
        //    if ( this.clb_ArrivalStateDiv.GetItemChecked( 1 ) )
        //    {
        //        divList.Add( (int)OrderListCndtn.ArrivalStateDivState.PartArrivaled );
        //    }
        //    // 全て入荷済分チェック
        //    if ( this.clb_ArrivalStateDiv.GetItemChecked( 2 ) )
        //    {
        //        divList.Add( (int)OrderListCndtn.ArrivalStateDivState.AllArrivaled );
        //    }

        //    return divList.ToArray();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        #region 赤伝区分（複数指定）取得
        ///// <summary>
        ///// 赤伝区分（複数指定）取得
        ///// </summary>
        ///// <returns>赤伝区分（複数指定）</returns>
        //private int[] GetDebitNoteDivs ()
        //{
        //    List<int> divList = new List<int>();

        //    // (全て)
        //    if ( divList.Count == 0 ) {
        //        divList.Add(( int ) OrderListCndtn.DebitNoteDivState.Normal);
        //        divList.Add(( int ) OrderListCndtn.DebitNoteDivState.DebitNote);
        //        divList.Add(( int ) OrderListCndtn.DebitNoteDivState.OrgNormal);
        //    }

        //    return divList.ToArray();
        //}
        #endregion

        #region 仕入伝票区分（複数指定）取得
        ///// <summary>
        ///// 仕入伝票区分（複数指定）取得
        ///// </summary>
        ///// <returns>仕入伝票区分（複数指定）</returns>
        //private int[] GetSupplierSlipCds ()
        //{
        //    List<int> divList = new List<int>();

        //    // (全て)
        //    if ( divList.Count == 0 ) {
        //        divList.Add(( int ) OrderListCndtn.SupplierSlipCdState.Stock);
        //        divList.Add(( int ) OrderListCndtn.SupplierSlipCdState.Return);
        //    }

        //    return divList.ToArray();
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion
        #endregion
        #endregion ◆ 印刷前処理

        #region ◆ ControlEventからCall
        #region ◎ 絞込み倉庫ガイドEnabledセット処理
        /// <summary>
		/// 絞込み倉庫ガイドEnabledセット処理
		/// </summary>
		/// <param name="targetSt">Enabledセット対象ボタン</param>
		/// <param name="targetEd">Enabledセット対象ボタン</param>
		/// <param name="compareStr1">比較対象文字列1</param>
		/// <param name="compareStr2">比較対象文字列2</param>
		private void ExtractWareHouseGuidSetProc( UltraButton targetSt, UltraButton targetEd, string compareStr1, string compareStr2 )
		{
			// 渡された文字列(絞込み拠点コード)が同じならばガイドボタンをクリック可能にする
			if ( compareStr1.CompareTo( compareStr2 ) == 0 ) 
			{
				targetSt.Enabled = true;
				targetEd.Enabled = true;
			}
			else
			{
				targetSt.Enabled = false;
				targetEd.Enabled = false;
			}
		}
		#endregion
		#endregion

		#region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#region ◎ エラーメッセージ表示処理
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
		#endregion

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region ◎ エラーメッセージ表示処理
        ///// <summary>
        ///// エラーメッセージ表示処理
        ///// </summary>
        ///// <param name="message">表示メッセージ</param>
        ///// <param name="status">ステータス</param>
        ///// <param name="procnm">発生メソッドID</param>
        ///// <param name="ex">例外情報</param>
        ///// <remarks>
        ///// <br>Note       : エラーメッセージの表示を行います。</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2006.03.24</br>
        ///// </remarks>
        //private void MsgDispProc( string message,int status, string procnm, Exception ex )
        //{
        //    string errMessage = message + "\r\n" + ex.Message;

        //    TMsgDisp.Show( 
        //        this, 								// 親ウィンドウフォーム
        //        emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
        //        ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
        //        this._printName,					// プログラム名称
        //        procnm, 							// 処理名称
        //        "",									// オペレーション
        //        errMessage,							// 表示するメッセージ
        //        status, 							// ステータス値
        //        null, 								// エラーが発生したオブジェクト
        //        MessageBoxButtons.OK, 				// 表示するボタン
        //        MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
        //}
		#endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#endregion ■ Private Method

		#region ■ Control Event
        #region ◆ DCHAT02100UA
        #region ◎ DCHAT02100UA_Load Event
        /// <summary>
        /// DCHAT02100UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote  : PMKOBETSU-3280の対応</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date	    : 2020/03/10</br>
        /// </remarks>
		private void DCHAT02100UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}
            // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ---------->>>>>
            // フタバUOEオプション（個別）：OPT-CPM0110
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract && this._selPrintMode == CT_SelPrintMode_OrderList)
            {
                // UOE自動発注情報取得
                this.GetAutoOrderDate();
            }
            // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ----------<<<<<

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

			ParentToolbarSettingEvent( this );						// ツールバーボタン設定イベント起動
		}
		#endregion

        // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ---------->>>>>
        /// <summary>
        /// UOE自動発注設定共通情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE自動発注設定共通情報を取得します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void GetAutoOrderDate()
        {
            object resultObj = null;
            object resultEMCObj = null;
            ultraLabel_EMC.Text = string.Empty;
            ultraLabel_SPK.Text = string.Empty;
            
            try
            {
                // クラスインスタンス化処理
                object obj = LoadAssembly(AssemblyId, AssemblyIdClassName);

                // Type
                Type[] paramTypes = new Type[3];
                paramTypes[0] = typeof(string);
                paramTypes[1] = typeof(object).MakeByRefType();
                paramTypes[2] = typeof(object).MakeByRefType();
                // メソッド取得
                System.Reflection.MethodInfo myMethod = obj.GetType().GetMethod(AssemblyIdMethodName, paramTypes);
                // パラメータのValue
                object[] paramValue = new object[3];
                paramValue[0] = _enterpriseCode;
                paramValue[1] = resultObj;
                paramValue[2] = resultEMCObj;

                // 処理実行
                object retVal = myMethod.Invoke(obj, paramValue);

                // 検索結果がある場合
                if (retVal != null)
                {
                    if ((int)retVal == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // SPK情報
                        resultObj = paramValue[1];
                        // EMC情報
                        resultEMCObj = paramValue[2];
                        // SPK情報がある場合
                        if (resultObj != null)
                        {
                            ultraLabel_SPK.Text = resultObj.ToString();
                        }
                        // EMC情報がある場合
                        if (resultEMCObj != null)
                        {
                            ultraLabel_EMC.Text = resultEMCObj.ToString();
                        }
                    }
                }

                // SPK、EMC共に設定されている場合
                if (!ultraLabel_SPK.Text.Equals(string.Empty) && !ultraLabel_EMC.Text.Equals(string.Empty))
                {
                    this.ueb_MainExplorerBar.Groups[0].Visible = true;
                }
                // SPKのみ設定されている場合
                else if (!ultraLabel_SPK.Text.Equals(string.Empty))
                {
                    this.ueb_MainExplorerBar.Groups[0].Visible = true;
                    this.ultraLabel_SPK.Visible = true;
                    this.ultraLabel_EMC.Visible = false;
                    this.ueb_MainExplorerBar.Groups[0].Container.Height = 26;
                }
                // EMCのみ設定されている場合
                else if (!ultraLabel_EMC.Text.Equals(string.Empty))
                {
                    this.ueb_MainExplorerBar.Groups[0].Visible = true;
                    this.ultraLabel_EMC.Location = this.ultraLabel_SPK.Location;
                    this.ueb_MainExplorerBar.Groups[0].Container.Height = 26;
                    this.ultraLabel_SPK.Visible = false;
                    this.ultraLabel_EMC.Visible = true;
                }
                else
                {
                    this.ueb_MainExplorerBar.Groups[0].Visible = false;
                }
            }
            catch
            {
                // 既存処理に影響を与えないため、処理無し
            }
        }

        /// <summary>
        /// クラスインスタンス化処理
        /// </summary>
        /// <param name="asmName">アセンブリ名称</param>
        /// <param name="className">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note		: 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private object LoadAssembly(string asmName, string className)
        {
            object obj = null;
            try
            {
                // アセンブリリフレクション
                Assembly asm = Assembly.Load(asmName);

                // クラス型取得
                Type objType = asm.GetType(className);
                // インスタンスタイプがある場合、インスタンスオブジェクトを生成します。
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch
            {
                // 既存処理に影響を与えないため、処理無し
            }
            return obj;
        }
        // ADD 2020/03/10 陳艶丹 PMKOBETSU-3280の対応 ----------<<<<<

        #region ◎ DCHAT02100UA_FormClosing Event
        /// <summary>
        /// DCHAT02100UA_FormClosing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを閉じる時に発生する</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.09.03</br>
        /// </remarks>
        private void DCHAT02100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ＵＩ入力保存コンポーネント動作のため追加
        }
        #endregion

        #endregion ◆ DCHAT02100UA

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_WarehouseCodeGuide_Click ( object sender, EventArgs e )
        {
            int status = 0;
            string sectionCode = "";
            if ( this._wareHouseAcs == null )
                this._wareHouseAcs = new WarehouseAcs();

            this._wareHouse = new Warehouse();

            // スライダーの拠点コードをもとにガイド起動
            if ( this._selectedSectionList.Count == 1 ) {
                foreach ( DictionaryEntry de in this._selectedSectionList ) {
                    sectionCode = de.Value.ToString().TrimEnd();
                }
            }

            status = this._wareHouseAcs.ExecuteGuid(out this._wareHouse, this._enterpriseCode, sectionCode);
            if ( status != 0 ) return;

            string tag = ( string ) ( ( UltraButton ) sender ).Tag;
            TEdit targetControl = null;
            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tEdit_WarehouseCode_St;
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tEdit_WarehouseCode_Ed;
            else return;

            // コード展開
            targetControl.DataText = this._wareHouse.WarehouseCode.TrimEnd();

            // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
            //// 次フォーカス
            //_nextControl[targetControl].Focus();
            // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

            // 2008.11.10 30413 犬飼 フォーカス制御を追加 >>>>>>START
            // 次のコントロールへフォーカスを移動
            this.SelectNextControl((Control)sender, true, true, true, true);
            // 2008.11.10 30413 犬飼 フォーカス制御を追加 <<<<<<END
        }

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 担当者ガイドボタンクリックイベント
        ///// <summary>
        ///// 担当者ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        //private void ub_St_StockAgentCodeGuide_Click ( object sender, EventArgs e )
        //{
        //    int status = 0;
        //    string sectionCode = "";
        //    if ( this._employeeAcs == null )
        //        this._employeeAcs = new EmployeeAcs();

        //    this._employee = new Employee();

        //    // スライダーの拠点コードをもとにガイド起動
        //    if ( this._selectedSectionList.Count == 1 ) {
        //        foreach ( DictionaryEntry de in this._selectedSectionList ) {
        //            sectionCode = de.Value.ToString().TrimEnd();
        //        }
        //    }

        //    status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, sectionCode, out this._employee);
        //    if ( status != 0 ) return;

        //    string tag = ( string ) ( ( UltraButton ) sender ).Tag;
        //    TEdit targetControl = null;
        //    if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.te_St_StockAgentCode;
        //    else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.te_Ed_StockAgentCode;
        //    else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("3") == 0 ) targetControl = this.te_St_StockInputCode;
        //    else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("4") == 0 ) targetControl = this.te_Ed_StockInputCode;
        //    else return;

        //    // コード展開
        //    targetControl.DataText = this._employee.EmployeeCode.TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 仕入先ガイドボタンクリックイベント
        ///// <summary>
        ///// 仕入先ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_CustomerCodeGuide_Click ( object sender, EventArgs e )
        //{
        //    _customerGuideOK = false;

        //    try {
        //        this._customerGuid = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //        this._customerGuid.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSelected);

        //        this._customerGuidSender = ( UltraButton ) sender;
        //        this._customerGuid.ShowDialog(this);
        //        this._customerGuidSender = null;

        //        this._customerGuid.Dispose();

        //        // 次フォーカス
        //        if ( _customerGuideOK )
        //        {
        //            if ( sender == ub_St_SupplierCodeGuide )
        //            {
        //                _nextControl[tne_St_SupplierCd].Focus();
        //            }
        //            else
        //            {
        //                _nextControl[tne_Ed_SupplierCd].Focus();
        //            }
        //        }
        //    }
        //    catch ( Exception ) {
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 仕入先検索選択結果イベント
        ///// <summary>
        ///// 仕入先検索選択結果イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="customerSearchRet"></param>
        //private void CustomerSelected ( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    try {
        //        if (_customerGuidSender != null) {
        //            TNedit targetControl = null;
        //            if ( _customerGuidSender.Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tne_St_SupplierCd;
        //            else if ( _customerGuidSender.Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tne_Ed_SupplierCd;
        //            else return;

        //            targetControl.SetInt( customerSearchRet.CustomerCode );
        //            _customerGuideOK = true;
        //        }
        //    }
        //    catch ( Exception ) {
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region メーカーガイドボタンクリックイベント
        ///// <summary>
        ///// メーカーガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsMakerCdGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsAcs == null ) {
        //        this._goodsAcs = new GoodsAcs();
        //        string msg;
        //        this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
        //    }

        //    MakerUMnt maker;
        //    int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
        //    if (status != 0) return;

        //    TNedit targetControl;
        //    if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl =  this.tne_St_GoodsMakerCd;
        //    else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tne_Ed_GoodsMakerCd;
        //    else return;

        //    targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 商品番号ガイドボタンクリックイベント
        ///// <summary>
        ///// 商品番号ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsNoGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null ) {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    this._goodsUnitData = null;
        //    DialogResult status = this._goodsGuid.ShowGuide(this, this._enterpriseCode, out this._goodsUnitData);

        //    if ( status != DialogResult.OK ) return;

        //    TEdit targetControl;
        //    if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.te_GoodsNo;
        //    else return;

        //    targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //    beforeGoodsNo = targetControl.DataText;

        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 商品番号脱出イベント
        ///// <summary>
        ///// 商品番号脱出イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void te_GoodsNo_Leave ( object sender, EventArgs e )
        //{
        //    if (te_GoodsNo.Text.Trim() == string.Empty) return;
        //    if (te_GoodsNo.Text.Trim() == beforeGoodsNo) return;

        //    List<GoodsUnitData> goodsList;
        //    string msg;
        //    string searchCode;
        //    int searchType = 1;     // 1:前方一致検索固定にする
        //    GetSearchType( this.te_GoodsNo.Text, out searchCode );

        //    this._goodsGuid.ReadGoods( this, this._enterpriseCode, searchType, searchCode, out goodsList, out msg );
        //    if (goodsList.Count > 0)
        //    {
        //        this.te_GoodsNo.Text = goodsList[0].GoodsNo;
        //        beforeGoodsNo = this.te_GoodsNo.Text;
        //    }
        //    else
        //    {
        //        this.te_GoodsNo.Text = string.Empty;
        //        beforeGoodsNo = string.Empty;
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 検索タイプ取得処理
        ///// <summary>
        ///// 検索タイプ取得処理
        ///// </summary>
        ///// <param name="inputCode">入力されたコード</param>
        ///// <param name="searchCode">検索用コード（*を除く）</param>
        ///// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        //private int GetSearchType ( string inputCode, out string searchCode )
        //{
        //    searchCode = inputCode;
        //    if ( String.IsNullOrEmpty( inputCode ) ) return 0;

        //    if ( inputCode.Contains( "*" ) )
        //    {
        //        searchCode = inputCode.Replace( "*", "" );
        //        string firstString = inputCode.Substring( 0, 1 );
        //        string lastString = inputCode.Substring( inputCode.Length - 1, 1 );

        //        if ( ( firstString == "*" ) && ( lastString == "*" ) )
        //        {
        //            return 3;
        //        }
        //        else if ( firstString == "*" )
        //        {
        //            return 2;
        //        }
        //        else if ( lastString == "*" )
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 3;
        //        }
        //    }
        //    else
        //    {
        //        // *が存在しないため完全一致検索
        //        return 0;
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 数値項目開始脱出イベント
        ///// <summary>
        ///// 数値項目開始脱出イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tne_St_Leave ( object sender, EventArgs e )
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 空白の場合は初期値をセット
        //    //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
        //    //    ( ( TNedit ) sender ).SetInt(0);
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 数値項目終了脱出イベント
        ///// <summary>
        ///// 数値項目終了脱出イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tne_Ed_Leave ( object sender, EventArgs e )
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 空白の場合は初期値をセット
        //    //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
        //    //    string maxValueText = new string('9', ((TNedit)sender).ExtEdit.Column);
        //    //    ( ( TNedit ) sender ).SetInt(Int32.Parse(maxValueText));
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 発注状態変更イベント
        ///// <summary>
        ///// 発注状態変更イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CheckedListBox_SelectedValueChanged ( object sender, EventArgs e )
        //{
        //    CheckedListBox checkedListBox = (sender as CheckedListBox);

        //    // 全てのチェックが外れた場合は、全てチェックする
        //    //if (checkedListBox.SelectedItems.Count == 0) {
        //    if (checkedListBox.CheckedItems.Count == 0) {
        //        for (int index = 0; index < checkedListBox.Items.Count; index++) {
        //            checkedListBox.SetItemChecked(index, true);
        //        }
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 商品区分グループガイドボタンクリックイベント
        ///// <summary>
        ///// 商品区分グループガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_LargeGoodsGanreGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsAcs == null )
        //    {
        //        this._goodsAcs = new GoodsAcs();
        //        string msg;
        //        this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
        //    }

        //    LGoodsGanre lGoodsGanre;
        //    int status = this._goodsAcs.ExecuteLGoodsGanreGuid( this._enterpriseCode, out lGoodsGanre );
        //    if ( status != 0 ) return;

        //    TEdit targetControl;
        //    if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.te_St_LargeGoodsGanreCode;
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.te_Ed_LargeGoodsGanreCode;
        //    else return;

        //    targetControl.DataText = lGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 商品区分ガイドボタンクリックイベント
        ///// <summary>
        ///// 商品区分ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_MediumGoodsGanreGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsAcs == null )
        //    {
        //        this._goodsAcs = new GoodsAcs();
        //        string msg;
        //        this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
        //    }

        //    MGoodsGanre mGoodsGanre;
        //    int status = this._goodsAcs.ExecuteMGoodsGanreGuid( this._enterpriseCode, string.Empty, out mGoodsGanre );
        //    if ( status != 0 ) return;

        //    TEdit targetControl;
        //    if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.te_St_MediumGoodsGanreCode;
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.te_Ed_MediumGoodsGanreCode;
        //    else return;

        //    targetControl.DataText = mGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 商品区分詳細ガイドボタンクリックイベント
        ///// <summary>
        ///// 商品区分詳細ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_DetailGoodsGanreGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsAcs == null )
        //    {
        //        this._goodsAcs = new GoodsAcs();
        //        string msg;
        //        this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
        //    }

        //    DGoodsGanre dGoodsGanre;
        //    int status = this._goodsAcs.ExecuteDGoodsGanreGuid( this._enterpriseCode, out dGoodsGanre );
        //    if ( status != 0 ) return;

        //    TEdit targetControl;
        //    if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.te_St_DetailGoodsGanreCode;
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.te_Ed_DetailGoodsGanreCode;
        //    else return;

        //    targetControl.DataText = dGoodsGanre.DetailGoodsGanreCode.ToString().TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 自社分類ガイドボタンクリックイベント
        ///// <summary>
        ///// 自社分類ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_EnterpriseGanreGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._searchStockAcs == null )
        //    {
        //        this._searchStockAcs = new SearchStockAcs();
        //    }

        //    UserGdBd userGdBd;
        //    int status = this._searchStockAcs.ExecuteUserGuideGuid( this._enterpriseCode, out userGdBd );
        //    if ( status != 0 ) return;

        //    TEdit targetControl;
        //    if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tne_St_EnterpriseGanreCode;
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tne_Ed_EnterpriseGanreCode;
        //    else return;

        //    targetControl.DataText = userGdBd.GuideCode.ToString().TrimEnd();
        //    // 次フォーカス
        //    _nextControl[targetControl].Focus();
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.01 30413 犬飼 未使用のため削除 >>>>>>START
        #region 入荷状況選択状態変更時イベント処理
        ///// <summary>
        ///// 入荷状況選択状態変更時イベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void clb_ArrivalStateDiv_SelectedValueChanged ( object sender, EventArgs e )
        //{
        //    CheckedListBox checkedListBox = ( sender as CheckedListBox );

        //    // 全てのチェックが外れた場合は、全てチェックする
        //    //if (checkedListBox.SelectedItems.Count == 0) {
        //    if ( checkedListBox.CheckedItems.Count == 0 )
        //    {
        //        for ( int index = 0; index < checkedListBox.Items.Count; index++ )
        //        {
        //            checkedListBox.SetItemChecked( index, true );
        //        }
        //    }
        //}
        #endregion
        // 2008.09.01 30413 犬飼 未使用のため削除 <<<<<<END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// グループ圧縮イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 単独倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Unit_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";
            if (this._wareHouseAcs == null)
                this._wareHouseAcs = new WarehouseAcs();

            this._wareHouse = new Warehouse();

            // スライダーの拠点コードをもとにガイド起動
            if (this._selectedSectionList.Count == 1)
            {
                foreach (DictionaryEntry de in this._selectedSectionList)
                {
                    sectionCode = de.Value.ToString().TrimEnd();
                }
            }

            status = this._wareHouseAcs.ExecuteGuid(out this._wareHouse, this._enterpriseCode, sectionCode);

            // 項目に展開
            if (status == 0)
            {
                // 左から順に未入力の倉庫へ設定
                if (this.tEdit_WarehouseCode1.Text == "")
                {
                    this.tEdit_WarehouseCode1.DataText = this._wareHouse.WarehouseCode.Trim();
                }
                else if (this.tEdit_WarehouseCode2.Text == "")
                {
                    this.tEdit_WarehouseCode2.DataText = this._wareHouse.WarehouseCode.Trim();
                }
                else if (this.tEdit_WarehouseCode3.Text == "")
                {
                    this.tEdit_WarehouseCode3.DataText = this._wareHouse.WarehouseCode.Trim();
                }
                else if (this.tEdit_WarehouseCode4.Text == "")
                {
                    this.tEdit_WarehouseCode4.DataText = this._wareHouse.WarehouseCode.Trim();
                }
                else if (this.tEdit_WarehouseCode5.Text == "")
                {
                    this.tEdit_WarehouseCode5.DataText = this._wareHouse.WarehouseCode.Trim();
                }
                else if (this.tEdit_WarehouseCode6.Text == "")
                {
                    this.tEdit_WarehouseCode6.DataText = this._wareHouse.WarehouseCode.Trim();
                }

                // 2008.11.10 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.10 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 開始仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // 2008.11.10 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.10 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 終了仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 2008.11.10 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.10 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 単独仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Unit_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                // 左から順に未入力の仕入先へ設定
                if (this.tNedit_SupplierCd1.Text == "")
                {
                    this.tNedit_SupplierCd1.SetInt(supplier.SupplierCd);
                }
                else if (this.tNedit_SupplierCd2.Text == "")
                {
                    this.tNedit_SupplierCd2.SetInt(supplier.SupplierCd);
                }
                else if (this.tNedit_SupplierCd3.Text == "")
                {
                    this.tNedit_SupplierCd3.SetInt(supplier.SupplierCd);
                }
                else if (this.tNedit_SupplierCd4.Text == "")
                {
                    this.tNedit_SupplierCd4.SetInt(supplier.SupplierCd);
                }
                else if (this.tNedit_SupplierCd5.Text == "")
                {
                    this.tNedit_SupplierCd5.SetInt(supplier.SupplierCd);
                }
                else if (this.tNedit_SupplierCd6.Text == "")
                {
                    this.tNedit_SupplierCd6.SetInt(supplier.SupplierCd);
                }

                // 2008.11.10 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.11.10 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 対象区分 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ce_ObjDiv_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = (sender as TComboEditor);

            if ((int)tComboEditor.Value == 1)
            {
                // UOE発注分の場合
                this.ce_BlanketStockInputDataDiv.Value = 1;
                this.ce_BlanketStockInputDataDiv.Enabled = false;
            }
            else
            {
                // 全て、UOE発注以外の場合
                this.ce_BlanketStockInputDataDiv.Enabled = true;
            }
        }

        /// <summary>
        /// 倉庫抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ce_WarehouseExtra_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = (sender as TComboEditor);

            if ((int)tComboEditor.Value == 0)
            {
                // 範囲の場合
                // 有効
                this.tEdit_WarehouseCode_St.Enabled = true;
                this.ub_St_WarehouseCodeGuide.Enabled = true;
                this.tEdit_WarehouseCode_Ed.Enabled = true;
                this.ub_Ed_WarehouseCodeGuide.Enabled = true;

                // 無効
                this.tEdit_WarehouseCode1.Enabled = false;
                this.tEdit_WarehouseCode2.Enabled = false;
                this.tEdit_WarehouseCode3.Enabled = false;
                this.tEdit_WarehouseCode4.Enabled = false;
                this.tEdit_WarehouseCode5.Enabled = false;
                this.tEdit_WarehouseCode6.Enabled = false;
                this.ub_Unit_WarehouseCodeGuide.Enabled = false;
            }
            else
            {
                // 単独の場合
                // 有効
                this.tEdit_WarehouseCode1.Enabled = true;
                this.tEdit_WarehouseCode2.Enabled = true;
                this.tEdit_WarehouseCode3.Enabled = true;
                this.tEdit_WarehouseCode4.Enabled = true;
                this.tEdit_WarehouseCode5.Enabled = true;
                this.tEdit_WarehouseCode6.Enabled = true;
                this.ub_Unit_WarehouseCodeGuide.Enabled = true;

                // 無効
                this.tEdit_WarehouseCode_St.Enabled = false;
                this.ub_St_WarehouseCodeGuide.Enabled = false;
                this.tEdit_WarehouseCode_Ed.Enabled = false;
                this.ub_Ed_WarehouseCodeGuide.Enabled = false;
            }
        }

        /// <summary>
        /// 仕入先抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ce_SupplierExtra_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = (sender as TComboEditor);

            if ((int)tComboEditor.Value == 0)
            {
                // 範囲の場合
                // 有効
                this.tNedit_SupplierCd_St.Enabled = true;
                this.ub_St_SupplierCodeGuide.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.ub_Ed_SupplierCodeGuide.Enabled = true;

                // 無効
                this.tNedit_SupplierCd1.Enabled = false;
                this.tNedit_SupplierCd2.Enabled = false;
                this.tNedit_SupplierCd3.Enabled = false;
                this.tNedit_SupplierCd4.Enabled = false;
                this.tNedit_SupplierCd5.Enabled = false;
                this.tNedit_SupplierCd6.Enabled = false;
                this.ub_Unit_SupplierCodeGuide.Enabled = false;
            }
            else
            {
                // 単独の場合
                // 有効
                this.tNedit_SupplierCd1.Enabled = true;
                this.tNedit_SupplierCd2.Enabled = true;
                this.tNedit_SupplierCd3.Enabled = true;
                this.tNedit_SupplierCd4.Enabled = true;
                this.tNedit_SupplierCd5.Enabled = true;
                this.tNedit_SupplierCd6.Enabled = true;
                this.ub_Unit_SupplierCodeGuide.Enabled = true;

                // 無効
                this.tNedit_SupplierCd_St.Enabled = false;
                this.ub_St_SupplierCodeGuide.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.ub_Ed_SupplierCodeGuide.Enabled = false;
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // 倉庫(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→仕入先条件
                        e.NextCtrl = this.ce_SupplierExtra;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode6)
                    {
                        // 倉庫６(単独)→仕入先条件
                        e.NextCtrl = this.ce_SupplierExtra;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→受託在庫
                        e.NextCtrl = this.ce_TrustStockDiv;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd6)
                    {
                        // 仕入先６(単独)→受託在庫
                        e.NextCtrl = this.ce_TrustStockDiv;
                    }
                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                    if (this._selPrintMode == CT_SelPrintMode_OrderRemList)
                    {
                        if (e.PrevCtrl == this.tComboEditor_Method)
                        {
                            // 自社名印字区分
                            e.NextCtrl = this.ce_CoNmPrintOutCd;
                        }
                        else if (e.PrevCtrl == ce_CoNmPrintOutCd)
                        {
                            // 印刷順
                            e.NextCtrl = this.ce_PrintSortDiv;
                        }
                        else if (e.PrevCtrl == ce_StockMinMaxPrintDiv)
                        {
                            e.NextCtrl = this.ce_LendCntPrintDiv;
                        }
                    }
                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                }
                
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.ce_TrustStockDiv)
                    {
                        // 受託在庫
                        if (this.tNedit_SupplierCd_Ed.Enabled)
                        {
                            // →仕入先(終了)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else
                        {
                            // →仕入先６(単独)
                            e.NextCtrl = this.tNedit_SupplierCd6;
                        }
                    }
                    else if (e.PrevCtrl == this.ce_SupplierExtra)
                    {
                        // 仕入先条件
                        if (this.tEdit_WarehouseCode_Ed.Enabled)
                        {
                            // →倉庫(終了)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else
                        {
                            // →倉庫６(単独)
                            e.NextCtrl = this.tEdit_WarehouseCode6;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→倉庫(開始)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (this._selPrintMode == CT_SelPrintMode_OrderRemList)
                    {
                        if (e.PrevCtrl == this.ce_PrintSortDiv)
                        {
                            // 自社名印字区分
                            e.NextCtrl = this.ce_CoNmPrintOutCd;
                        }
                        else if (e.PrevCtrl == ce_CoNmPrintOutCd)
                        {
                            // 帳票用紙ﾀｲﾌﾟ
                            e.NextCtrl = this.tComboEditor_Method;
                        }
                        else if (e.PrevCtrl == ce_LendCntPrintDiv)
                        {
                            e.NextCtrl = this.ce_StockMinMaxPrintDiv;
                        }
                    }
                }
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
            }
        }

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// 一括仕入入力ﾃﾞｰﾀ作成抽出条件 値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private void ce_BlanketStockInputDataDiv_ValueChanged(object sender, EventArgs e)
        {
            TComboEditor tComboEditor = (sender as TComboEditor);

            if ((int)tComboEditor.Value == 1)
            {
                // 「しない」の場合
                this.tComboEditor_BarCodeShow.Value = 1;
                this.tComboEditor_BarCodeShow.Enabled = false;
            }
            else
            {
                // 「する」の場合
                this.tComboEditor_BarCodeShow.Enabled = true;
            }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        #endregion ■ Control Event
    }
}
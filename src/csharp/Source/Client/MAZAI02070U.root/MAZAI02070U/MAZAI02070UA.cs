//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫一覧表
// プログラム概要   :  在庫一覧表 ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村 仁
// 作 成 日  2007/03/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/10/05  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/21  修正内容 : DC.NS対応（不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 修 正 日  2008/02/26  修正内容 : DC.NS対応（共通修正:日付チェック、０埋め対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/29  修正内容 : 不具合対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 修 正 日  2008/08/01  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/07  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/05  修正内容 : 不具合対応[12173]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/25  修正内容 : 不具合対応[12809]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/03  修正内容 : 不具合対応[13000]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 不具合対応[13101]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/25  修正内容 : 不具合対応[13586]
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12894]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫一覧表 ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫一覧表 ＵＩクラスの出力条件入力を行います。</br>
    /// <br>Programmer : 23010 中村 仁</br>
    /// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.01.21 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008.02.26 20081 疋田 勇人</br>
    /// <br>			 ・DC.NS対応（共通修正:日付チェック、０埋め対応）</br>
    /// <br>Update Note: 2008.02.29 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応</br>
    /// <br>Update Note: 2008.08.01 30416 長沼 賢二</br>
    /// <br>Update Note: 2008/10/07       照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12173]</br>
    /// <br>           : 2009/03/25       照田 貴志　不具合対応[12809]</br>
    /// <br>           : 2009/04/03       照田 貴志　不具合対応[13000]</br>
    /// <br>           : 2009/04/13       上野 俊治　不具合対応[13101]</br>
    /// <br>           : 2009/06/25       照田 貴志　不具合対応[13586]</br>
    /// <br></br>
    /// </remarks>
    public partial class MAZAI02070UA : Form,
                                        IPrintConditionInpType,						// 帳票共通(条件入力タイプ)
                                        IPrintConditionInpTypeSelectedSection,		// 帳票業務(条件入力)拠点選択
                                        IPrintConditionInpTypePdfCareer				// 帳票業務(条件入力)PDF出力履歴管理
    {

        #region Constructor
        // <summary>
        /// 在庫一覧表 ＵＩクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫一覧表 ＵＩクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// <br></br>
        /// </remarks>
        public MAZAI02070UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点用のHashtable作成
            this._hashSecList = new Hashtable();           
            //画面デザイン変更クラス
            this._controlScreenSkin = new ControlScreenSkin();
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();  // 2008.02.26 add
        }
        #endregion

        # region エントリ ポイント
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAZAI02070UA());
        }
        #endregion

        #region Events
        /// <summary>フレームツールバー設定イベント</summary>
        public event Broadleaf.Application.Common.ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Private Members
        // 企業コード
        private string _enterpriseCode = "";       
        // 抽出条件クラス
        private StockListCndtn _stockListCndtn = new StockListCndtn();
        // 選択拠点
        private Hashtable _hashSecList = null;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;   
        // ------------------------------
        // IPrintConditionInpTypeのプロパティ用変数
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ用変数
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無プロパティ
        private bool _isOptSection = false;
        // 本社機能有無プロパティ
        private bool _isMainOfficeFunc = false;
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList1 = new Hashtable();
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList2 = new Hashtable();

        // ------------------------------
        // IPrintConditionInpTypePdfCareerのプロパティ用変数
        // 帳票名称
        private string _printName = "在庫一覧表";
        // 帳票キー
        private string _printKey = "4231e013-16ce-4695-af71-a03ced02af56";      
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;
        ///メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;  
        ///商品区分グループマスタアクセスクラス
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;    // DEL 2008.08.01
        ///商品区分マスタアクセスクラス
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;    // DEL 2008.08.01
        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
        ////キャリアガイド
        //private CarrierOdrAcs _carrierOdrAcs = null;
        //商品区分詳細マスタアクセスクラス
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;    // DEL 2008.08.01
        //倉庫ガイド
        private WarehouseAcs _warehouseGuideAcs = null;
        //ＢＬ商品マスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;
        //ユーザーガイドマスタアクセスクラス（自社分類）
        //private UserGuideGuide _userGuideGuide = null;    // DEL 2008.08.01
        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
        // 日付取得部品
        private DateGetAcs _dateGet;  // 2008.02.26 add

        private UserGuideAcs _userGuideAcs = null;          //ADD 2009/06/25 不具合対応[13586]

        //--- ADD 20080/08/01 ---------->>>>>
        // 仕入先
        SupplierAcs _supplierAcs;
        //--- ADD 20080/08/01 ----------<<<<<

        // ADD 2009/03/31 不具合対応[12894]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>発行タイプラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _publicationTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 発行タイプラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>発行タイプラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PublicationTypeRadioKeyPressHelper
        {
            get { return _publicationTypeRadioKeyPressHelper; }
        }

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _newPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }

        /// <summary>出力順ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _changePageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 出力順ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>出力順ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper ChangePageDivRadioKeyPressHelper
        {
            get { return _changePageDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[12894]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion

        #region Private Constant
        // クラスID
        private const string CT_CLASSID = "MAZAI02070UA";
        // プログラムID
        private const string CT_PGID = "MAZAI02070U";
        // プログラム名称
        private const string CT_PGNM = "在庫一覧表";      
                      
        #endregion
        
        #region Properties
        // ------------------------------
        // IPrintConditionInpTypeのプロパティ
        /// <summary>
        /// 抽出ボタン状態取得プロパティ
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return this._canExtract;
            }
        }

        /// <summary>
        /// PDF出力ボタン状態取得プロパティ
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return this._canPdf;
            }
        }

        /// <summary>
        /// 印刷ボタン状態取得プロパティ
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>
        /// 抽出ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return this._visibledExtractButton;
            }
        }

        /// <summary>
        /// PDF出力ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return this._visibledPdfButton;
            }
        }

        /// <summary>
        /// 印刷ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return this._visibledPrintButton;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ
        /// <summary>
        /// 計上拠点選択表示取得プロパティ
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return this._visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// 拠点オプション有無プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get
            {
                return this._isOptSection;
            }
            set
            {
                this._isOptSection = value;
            }
        }

        /// <summary>
        /// 本社機能有無プロパティ
        /// </summary>
        public bool IsMainOfficeFunc
        {
            get
            {
                return this._isMainOfficeFunc;
            }
            set
            {
                this._isMainOfficeFunc = value;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypePdfCareerのプロパティ用変数
        /// <summary>
        /// 帳票名称
        /// </summary>
        public string PrintName
        {
            get
            {
                return this._printName;
            }
        }

        /// <summary>
        /// 帳票キー
        /// </summary>
        public string PrintKey
        {
            get
            {
                return this._printKey;
            }
        }

        #endregion

        #region Public Methods

        // ------------------------------
        // IPrintConditionInpTypeのプロパティ
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">帳票設定コード</param>
        /// <remarks>
        /// <br>Note       : 画面表示処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void Show(object parameter)
        {                        
            this.Show();
        }

        /// <summary>
        /// 印刷前入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 印刷前入力チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool result = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                result = false;
            }

            return result;
        }
      		
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">印刷情報パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = CT_PGID;// 起動PGID
                     
            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            if ((int)this.uos_PublicationType.Value == 0)
            {
                printInfo.PrintPaperSetCd = 10;
            }
            else
            {
                printInfo.PrintPaperSetCd = 20; 
            }

            // 画面→抽出条件クラス
            int status = this.SetExtrInfoFromScreen(ref this._stockListCndtn);
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._stockListCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">印刷情報パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無し
            return 0;
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ
        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <param name="addUpCd">選択拠点種別</param>
        /// <remarks>
        /// <br>Note       : 選択されている計上拠点を設定します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 未使用
        }

        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点</param>
        /// <param name="checkState"></param>
        /// <remarks>
        /// <br>Note       : 拠点選択処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された時
                if (sectionCode == "0")
                {
                    // 選択選択リストをクリア
                    this._hashSecList.Clear();
                }

                // リストに拠点が追加されていない時、拠点の状態を追加
                if (this._hashSecList.ContainsKey(sectionCode) == false)
                {
                    this._hashSecList.Add(sectionCode, checkState);
                }           
            }
            // 拠点の選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                // 選択拠点リストから削除
                if (this._hashSecList.ContainsKey(sectionCode))
                {
                    this._hashSecList.Remove(sectionCode);
                }             
            }
        }       

        /// <summary>
        /// 計上拠点選択処理
        /// </summary>
        /// <param name="addUpCd">選択拠点種別</param>
        /// <remarks>
        /// <br>Note       : 計上拠点選択処理</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 未使用
        }

        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 選択されている拠点を設定します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }

            this._hashSecList.Clear();
            for (int ix = 0; ix < sectionCodeLst.Length; ix++)
            {
                // 選択拠点を追加
                this._hashSecList.Add(sectionCodeLst[ix], CheckState.Checked);
            }
        }

        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">初期表示有無ステータス</param>
        /// <returns>変更後表示有無ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点選択スライダーの表示有無を判定します。</br>
        /// <br>           : 拠点オプション、本社機能以外の個別の表示有無判定を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            // 変更しない
            //return isDefaultState;            //DEL 2009/04/03 不具合対応[13000]
            return false;                       //ADD 2009/04/03 不具合対応[13000]
        }
        #endregion

        #region Private Methods

        #region 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////出力順コンボボックスの初期設定(0:メーカー順,1:キャリア順,2:最終仕入日,3:商品グループ・区分,4:機種,5:出荷可能数)
            //this.ChangePageDiv_tComboEditor.Items.Add(0, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_MakerCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(1,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_CarrierCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(2,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_StockDate));
            //this.ChangePageDiv_tComboEditor.Items.Add(3,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_LargeMediumGoodsGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(4,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_CellPhoneModeleCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(5,StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt));
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;

            //出力順コンボボックスの初期設定(0:倉庫順,1:メーカー順,2:最終仕入日,3:出荷可能数,4:商品グループ・区分・区分詳細,5:自社分類,6:ＢＬコード)
            //--- DEL 2008/08/01 ---------->>>>>
            //this.ChangePageDiv_tComboEditor.Items.Add(0, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_WarehouseCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(1, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_MakerCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(2, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_StockDate));
            //this.ChangePageDiv_tComboEditor.Items.Add(3, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt));
            //this.ChangePageDiv_tComboEditor.Items.Add(4, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_LargeGoodsGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(5, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_EnterpriseGanreCode));
            //this.ChangePageDiv_tComboEditor.Items.Add(6, StockListCndtn.GetSortName((int)StockListCndtn.PageChangeDiv.Sort_BLGoodsCode));
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            /* ---DEL 2009/03/05 不具合対応[12173] -------------------------------->>>>>
            DateTime thisMonth;
            _dateGet.GetThisYearMonth(out thisMonth);

            // 開始対象日付初期値設定
            this.tde_St_AddUpYearMonth.SetDateTime(thisMonth);
            // 終了対象日付初期値設定
            this.tde_Ed_AddUpYearMonth.SetDateTime(thisMonth);
               ---DEL 2009/03/05 不具合対応[12173] --------------------------------<<<<< */
            // ---ADD 2009/03/05 不具合対応[12173] -------------------------------->>>>>
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // 売上今回月次更新日を設定
                this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth);
                this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
            }
            else
            {
                // 当月を設定
                DateTime nowYearMonth;
                this._dateGet.GetThisYearMonth(out nowYearMonth);

                this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth);
                this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
            }
            // ---ADD 2009/03/05 不具合対応[12173] --------------------------------<<<<<

            // 開始出荷数指定
            this.StartShipmentPosCnt_tNedit.SetInt(1);
            // 終了出荷数指定
            this.EndShipmentPosCnt_tNedit.SetInt(999999999);

            // 在庫登録日初期値設定
            this.tde_StockCreateDate.SetDateTime(TDateTime.GetSFDateNow());

            // 発行タイプ初期値設定
            this.uos_PublicationType.Value = 0;

            // 改頁初期値設定
            this.uos_NewPageDiv.Value = 0;

            // 出力順初期値設定
            this.uos_ChangePageDiv.Value = 0;

            // 棚番ブレイク初期値設定
            this.ce_WarehouseShelfNoBreakDiv.Value = 0;
            //--- ADD 2008/08/01 ----------<<<<<
            // ---ADD 2009/03/25 不具合対応[12809] ------------------------------------------------>>>>>
            // 必須色設定
            this.tde_St_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.tde_Ed_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.tde_StockCreateDate.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
            this.ce_StockCreateDateDiv.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            this.ce_WarehouseShelfNoBreakDiv.Appearance.BackColor = Color.FromArgb(179, 219, 231);
            // ---ADD 2009/03/25 不具合対応[12809] ------------------------------------------------<<<<<
        }

        // ---ADD 2009/06/25 不具合対応[13586] -------------------------------->>>>>
        /// <summary>
        /// 管理区分名称設定
        /// </summary>
        /// <param name="control">対象コントロール</param>
        /// <param name="guideDivCode">ガイド区分</param>
        private void SetDuplicationShelfNo(CheckedListBox control, int guideDivCode)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            //初期化
            for (int i = 0; i < 10; i++)
            {
                control.Items[i] = "未登録";
            }

            //読み込み
            ArrayList arrayList = null;
            int status = this._userGuideAcs.SearchDivCodeBody(out arrayList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }
            if (arrayList == null)
            {
                return;
            }
            if (arrayList.Count == 0)
            {
                return;
            }

            //名称セット
            UserGdBd userGdBd = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                userGdBd = (UserGdBd)arrayList[i];
                if ((0 <= userGdBd.GuideCode) || (userGdBd.GuideCode <= 9))
                {
                    control.Items[userGdBd.GuideCode] = userGdBd.GuideName;
                }
            }
        }
        // ---ADD 2009/06/25 不具合対応[13586] --------------------------------<<<<<

        #endregion

        #region 抽出条件格納処理
        /// <summary>
        /// 抽出条件UIクラスデータ格納処理(画面情報⇒抽出条件UIクラス)
        /// </summary>
        /// <param name="extraInfo">抽出条件UIクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件詳細情報を画面から取得します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private int SetExtrInfoFromScreen(ref StockListCndtn extraInfo)
        {
            const string ctPROCNM = "SetExtrInfoFromScreen";
            int status = 0;

            if (extraInfo == null)
            {
                extraInfo = new StockListCndtn();
            }

            try
            {              
                // 拠点オプション
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.IsOptSection = this._isOptSection;
                //// オプションありのとき
                //if (this._isOptSection)
                //{
                //    ArrayList secList = new ArrayList();
                //    // 全社選択かどうか
                //    if ((this._hashSecList.Count == 1) && (this._hashSecList.ContainsKey("0")))
                //    {                    
                //        extraInfo.DepositStockSecCodeList = new string[0];
                //    }
                //    else
                //    {
                //        foreach (DictionaryEntry dicEntry in this._hashSecList)
                //        {
                //            if ((CheckState)dicEntry.Value == CheckState.Checked)
                //            {
                //                secList.Add(dicEntry.Key);
                //            }
                //        }
                //        extraInfo.DepositStockSecCodeList = (string[])secList.ToArray(typeof(string));
                //    }
                //}
                // // 拠点オプションなしの時
                //else
                //{
                //   extraInfo.DepositStockSecCodeList = new string[0];
                //}
                /* ---DEL 2009/04/03 不具合対応[13000] ------------------------------------------------>>>>>
                ArrayList secList = new ArrayList();
                // 全社選択かどうか
                if ((this._hashSecList.Count == 1) && (this._hashSecList.ContainsKey("0")))
                {                    
                    extraInfo.DepositStockSecCodeList = new string[0];
                }
                else
                {
                    foreach (DictionaryEntry dicEntry in this._hashSecList)
                    {
                        if ((CheckState)dicEntry.Value == CheckState.Checked)
                        {
                            secList.Add(dicEntry.Key);
                        }
                    }
                    extraInfo.DepositStockSecCodeList = (string[])secList.ToArray(typeof(string));
                }
                   ---DEL 2009/04/03 不具合対応[13000] ------------------------------------------------<<<<< */
                extraInfo.DepositStockSecCodeList = new string[0];          //ADD 2009/04/03 不具合対応[13000] 全社固定
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
               
                // 企業コード
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.EnterPriseCode = this._enterpriseCode;
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                ////画面情報→条件クラス                  

                // 出力順
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.ChangePageDiv = (int)this.ChangePageDiv_tComboEditor.Value;
                //extraInfo.ChangePageDivName = StockListCndtn.GetSortName((int)this.ChangePageDiv_tComboEditor.Value);
                //--- DEL 2008/08/01 ----------<<<<<
                //--- ADD 2008/08/01 ---------->>>>>
                extraInfo.ChangePageDiv = (int)this.uos_ChangePageDiv.Value;
                //--- ADD 2008/08/01 ---------->>>>>
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //// メーカーコード
                //extraInfo.St_MakerCode = this.StartMakerCode_tNedit.GetInt();
                //extraInfo.Ed_MakerCode = this.EndMakerCode_tNedit.GetInt();
                //// 商品コード
                //extraInfo.St_GoodsCode = this.StartGoodsCode_tEdit.DataText;
                //extraInfo.Ed_GoodsCode = this.EndGoodsCode_tEdit.DataText;
                // メーカーコード
                extraInfo.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                /* --- DEL 2008/10/07 Toを印字時、""とALL9の区別をつける必要がある為、値はそのまま渡す ---------------------->>>>>
                // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_GoodsMakerCd = this.EndMakerCode_tNedit.GetInt();
                if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                {
                    //extraInfo.Ed_GoodsMakerCd = 999999;       //DEL 2008/10/07 桁数変更
                    extraInfo.Ed_GoodsMakerCd = 9999;           //ADD 2008/10/07
                }
                else
                {
                    extraInfo.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                }
                // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();       //ADD 2008/10/07

                // 商品コード
                extraInfo.St_GoodsNo = this.tEdit_GoodsNo_St.DataText;
                extraInfo.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText;
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //// キャリアコード
                //extraInfo.St_CarrierCode = this.StartCarrierCode_tNedit.GetInt();
                //extraInfo.Ed_CarrierCode = this.EndCarrierCode_tNedit.GetInt();
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                // 商品区分グループコード
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_LargeGoodsGanreCode = this.StartLargeGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_LargeGoodsGanreCode = this.EndLargeGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // 商品区分コード
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_MediumGoodsGanreCode = this.StartMediumGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_MediumGoodsGanreCode = this.EndMediumGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                // 商品区分詳細コード
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_DetailGoodsGanreCode = this.StartDetailGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_DetailGoodsGanreCode = this.EndDetailGoodsGanreCode_tEdit.DataText;
                //--- DEL 2008/08/01 ----------<<<<<
                // 自社分類コード
                //extraInfo.St_EnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();     // DEL 2008.08.01
                // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //--- DEL 2008/08/01 ---------->>>>>
                //if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = 9999;
                //}
                //else
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                // ＢＬ商品コード
                extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                /* --- DEL 2008/10/07 Toを印字時、""とALL9の区別をつける必要がある為、値はそのまま渡す ---------------------->>>>>
                // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_BLGoodsCode = this.EndBLGoodsCode_tNedit.GetInt();
                if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                {
                    //extraInfo.Ed_BLGoodsCode = 99999999;      //DEL 2008/10/07 桁数変更
                    extraInfo.Ed_BLGoodsCode = 99999;           //ADD 2008/10/07
                }
                else
                {
                    extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                }
                // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();         //ADD 2008/10/07

                // 倉庫コード
                extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
                // 在庫区分
                //extraInfo.StockDiv = StockListCndtn.GetStockDiv(this.StockDiv_ultraOptionSet.CheckedIndex);
                // 2008.02.29 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.StockDiv = this.StockDiv_ultraOptionSet.CheckedIndex;
                //--- DEL 2008/08/01 ---------->>>>>
                //if (this.StockDiv_ultraOptionSet.CheckedIndex == 1)
                //{
                //    extraInfo.StockDiv = 2;
                //}
                //else
                //{
                //    extraInfo.StockDiv = this.StockDiv_ultraOptionSet.CheckedIndex;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2008.02.29 修正 <<<<<<<<<<<<<<<<<<<<
                // 最終仕入日
                //--- DEL 2008/08/01 ---------->>>>>
                //extraInfo.St_LastStockDate = this.StartDate_tDateEdit.GetDateTime();
                //extraInfo.Ed_LastStockDate = this.EndDate_tDateEdit.GetDateTime();
                //--- DEL 2008/08/01 ----------<<<<<
                // 開始出荷可能数
                extraInfo.St_ShipmentPosCnt = this.StartShipmentPosCnt_tNedit.GetValue();
                // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_ShipmentPosCnt = this.EndShipmentPosCnt_tNedit.GetValue();
                if (this.EndShipmentPosCnt_tNedit.GetValue() == 0)
                {
                    extraInfo.Ed_ShipmentPosCnt = 99999999;
                }
                else
                {
                    extraInfo.Ed_ShipmentPosCnt = this.EndShipmentPosCnt_tNedit.GetValue();
                }
                // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008.08.01 ---------->>>>>
                ////////////↓予備項目↓/////////////////////////////////////////////////////////////////////////////
                //// 仕入在庫数
                //extraInfo.St_SupplierStock = 0;
                //extraInfo.Ed_SupplierStock = 99999999;
                //// 受託数
                //extraInfo.St_TrustCount = 0;
                //extraInfo.Ed_TrustCount = 99999999;
                //// 最終売上日
                //extraInfo.St_LastSalesDate = DateTime.MinValue;
                //extraInfo.Ed_LastSalesDate = DateTime.MinValue;
                //// 最終棚卸更新日
                //// 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.St_LastInventoryUpDate = DateTime.MinValue;
                ////extraInfo.Ed_LastInventoryUpDate = DateTime.MinValue;
                //extraInfo.St_LastInventoryUpdate = DateTime.MinValue;
                //extraInfo.Ed_LastInventoryUpdate = DateTime.MinValue;
                //// 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                //// 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                ////// 機種コード
                ////extraInfo.St_CellphoneModelCode  = "";
                ////extraInfo.Ed_CellphoneModelCode  = "";
                //// 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                /////////////////////////////////////////////////////////////////////////////////////////////////////
                //--- DEL 2008.08.01 ----------<<<<<

                //--- ADD 2008/08/01 ---------->>>>>
                // 対象年月
                extraInfo.St_LastStockDate = this.tde_St_AddUpYearMonth.GetDateTime();
                // 対象年月
                extraInfo.Ed_LastStockDate = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // 在庫登録日
                extraInfo.StockCreateDate = this.tde_StockCreateDate.GetDateTime();
                // 在庫登録日検索フラグ
                extraInfo.StockCreateDateFlg = (StockListCndtn.StockCreateDateDivState)this.ce_StockCreateDateDiv.Value;
                // 発行タイプ
                extraInfo.PublicationType = (StockListCndtn.PublicationTypeState)this.uos_PublicationType.Value;
                // 改頁区分
                extraInfo.NewPageDiv = (StockListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                // 部品管理区分１
                this._duplicationShelfNoList1.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo1.Items.Count; index++)
                {
                    // チェック有無取得
                    if (this.clb_DuplicationShelfNo1.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList1.Add(index.ToString(), index.ToString());
                    }
                }
                extraInfo.PartsManagementDivide1 = (string[])new ArrayList(this._duplicationShelfNoList1.Values).ToArray(typeof(string));

                // 部品管理区分２
                this._duplicationShelfNoList2.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo2.Items.Count; index++)
                {
                    // チェック有無取得
                    if (this.clb_DuplicationShelfNo2.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList2.Add(index.ToString(), index.ToString());
                    }
                }
                extraInfo.PartsManagementDivide2 = (string[])new ArrayList(this._duplicationShelfNoList2.Values).ToArray(typeof(string));

                // 開始仕入先コード
                extraInfo.St_StockSupplierCode = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                /* --- DEL 2008/10/07 Toを印字時、""とALL9の区別をつける必要がある為、値はそのまま渡す ---------------------->>>>>
                //extraInfo.Ed_StockSupplierCode = GetEndCode(this.tNedit_SupplierCd_Ed, 999999999);        //DEL 2008/10/07 桁数変更
                extraInfo.Ed_StockSupplierCode = GetEndCode(this.tNedit_SupplierCd_Ed, 999999);             //ADD 2008/10/07
                   --- DEL 2008/10/07 ---------------------------------------------------------------------------------------<<<<< */
                extraInfo.Ed_StockSupplierCode = this.tNedit_SupplierCd_Ed.GetInt();            //ADD 2008/10/07

                // 開始棚番
                extraInfo.St_WarehouseShelfNo = tEdit_WarehouseShelfNo_St.Text;
                // 終了棚番
                extraInfo.Ed_WarehouseShelfNo = tEdit_WarehouseShelfNo_Ed.Text;

                // 棚番ブレイク区分
                extraInfo.WarehouseShelfNoBreakDiv = (StockListCndtn.WarehouseShelfNoBreakDivState)this.ce_WarehouseShelfNoBreakDiv.Value;
                //--- ADD 2008/08/01 ----------<<<<<
            }
            catch (Exception ex)
            {
                status = -1;
                MsgDispProc("抽出条件の取得に失敗しました。", status, ctPROCNM, ex);
            }

            return status;
        }
         
        #endregion

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
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        #region エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                CT_PGNM,							// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                CT_PGNM,							// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion       

        #region 画面入力チェック
        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー対象コントロール</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行い、エラー時はメッセージと対象のコントロールを返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // 2008.02.29 修正 >>>>>>>>>>>>>>>>>>>>
            //bool result = false;
            bool result = true;
            // 2008.02.29 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 add start -------------------------------->>
            const string ct_InputError = "の入力が不正です";
            const string ct_NoInput = "を入力して下さい";           // ADD 2008.08.01
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeError1 = "の範囲指定に誤りがあります(１２ヶ月以内で設定して下さい)";

            DateGetAcs.CheckDateRangeResult cdrResult;
            // 2008.02.26 add end ----------------------------------<<
            DateGetAcs.CheckDateResult cdResult;        // ADD 2008.08.01

            //メーカーコード
            if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") && (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {         
                    errMessage = "メーカーコードの範囲指定に誤りがあります。";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    result = false;
                    return result;
                }
            }

            //商品コード
            if ((this.tEdit_GoodsNo_St.DataText.Trim() != "") && (this.tEdit_GoodsNo_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_GoodsNo_St.DataText.Trim().CompareTo(this.tEdit_GoodsNo_Ed.DataText.Trim()) > 0)
                {         
                    errMessage = "商品コードの範囲指定に誤りがあります。";
                    errComponent = this.tEdit_GoodsNo_St;
                    result = false;
                    return result;
                }
            }

            //--- ADD 2008/08/01 ---------->>>>>
            // 対象年月（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_NoInput);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                result = false;
                return result;
            }

            // 在庫登録日
            if (CallCheckDate(out cdResult, ref tde_StockCreateDate) == false)
            {
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format("在庫登録日{0}", ct_NoInput);
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format("在庫登録日{0}", ct_InputError);
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                }
                result = false;
                return result;
            }
            //--- ADD 2008/08/01 ----------<<<<<

            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード
            //if ((this.StartCarrierCode_tNedit.DataText.Trim() != "") && (this.EndCarrierCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartCarrierCode_tNedit.GetInt() > this.EndCarrierCode_tNedit.GetInt())
            //    {         
            //        errMessage = "キャリアコードの範囲指定に誤りがあります。";
            //        errComponent = this.StartCarrierCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 upd start -------------------------------------------->>
            //出力帳票年月のチェック1
            //result = DateCheck(this.StartDate_tDateEdit, this.EndDate_tDateEdit, ref errMessage, ref errComponent);
            //if (!result)
            //{
            //    return result;
            //}
            //--- DEL 2008/08/01 ---------->>>>>
            //// 最終仕入日（開始～終了）
            //if (CallCheckDateRange(out cdrResult, ref StartDate_tDateEdit, ref EndDate_tDateEdit) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("最終仕入開始日{0}", ct_InputError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("最終仕入開始日{0}", ct_InputError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("最終仕入終了日{0}", ct_InputError);
            //                errComponent = this.EndDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("最終仕入終了日{0}", ct_InputError);
            //                errComponent = this.EndDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format("最終仕入日{0}", ct_RangeError);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format("最終仕入日{0}", ct_RangeError1);
            //                errComponent = this.StartDate_tDateEdit;
            //            }
            //            break;
            //    }
            //    result = false;
            //    return result;
            //}
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.02.26 upd end ----------------------------------------------<<

             //商品区分グループコード
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartLargeGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndLargeGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartLargeGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndLargeGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "商品区分グループの範囲指定に誤りがあります。";
            //        errComponent = this.StartLargeGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<
            
            //商品区分コード
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartMediumGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndMediumGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartMediumGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndMediumGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "商品区分の範囲指定に誤りがあります。";
            //        errComponent = this.StartMediumGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
            //商品区分詳細コード
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartDetailGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndDetailGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartDetailGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndDetailGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {
            //        errMessage = "商品区分詳細の範囲指定に誤りがあります。";
            //        errComponent = this.StartDetailGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //自社分類コード
            //--- DEL 2008/08/01 ---------->>>>>
            //if ((this.StartEnterpriseGanreCode_tNedit.DataText.Trim() != "") && (this.EndEnterpriseGanreCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt())
            //    {
            //        errMessage = "自社分類の範囲指定に誤りがあります。";
            //        errComponent = this.StartEnterpriseGanreCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            //--- DEL 2008/08/01 ----------<<<<<

            //ＢＬ商品コード
            if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
                {
                    errMessage = "ＢＬコードの範囲指定に誤りがあります。";
                    errComponent = this.tNedit_BLGoodsCode_St;
                    result = false;
                    return result;
                }
            }

            //倉庫コード
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.Trim().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.Trim()) > 0)
                {
                    errMessage = "倉庫の範囲指定に誤りがあります。";
                    errComponent = this.tEdit_WarehouseCode_St;
                    result = false;
                    return result;
                }
            }
            // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<

            //出荷可能数
            if ((this.StartShipmentPosCnt_tNedit.DataText.Trim() != "") && (this.EndShipmentPosCnt_tNedit.DataText.Trim() != ""))
            {
                if (this.StartShipmentPosCnt_tNedit.GetInt() > this.EndShipmentPosCnt_tNedit.GetInt())
                {
                    errMessage = this.StartShipmentPosCnt_Title.Text + "の範囲指定に誤りがあります。";
                    errComponent = this.StartShipmentPosCnt_tNedit;
                    result = false;
                    return result;
                }
            }

            //--- ADD 2008/08/01 ---------->>>>>
            // 仕入先（開始 > 終了 → NG）
            //if (this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_St))       //DEL 2008/10/07 チェックが行われない為
            if (this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_Ed))         //ADD 2008/10/07
            {
                errMessage = this.StockSupplierCode_Title.Text + "の範囲指定に誤りがあります。";
                errComponent = this.tNedit_SupplierCd_St;
                result = false;
                return result;
            }
            // 棚番
            if (
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("棚番{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                result = false;
                return result;
            }
            //--- ADD 2008/08/01 ----------<<<<<

            return result;
        }
        #endregion      

        #endregion     

        #region 日付入力チェック
        //--- ADD 2008.08.01 ---------->>>>>
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = _dateGet.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        //--- ADD 2008.08.01 ----------<<<<<

        // 2008.02.26 add start -------------------------------->>
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ----------------------------------<<

        /// <summary>
        /// 日付項目入力チェック関数
        /// </summary>
        /// <param name="startDateEdit">開始日付コンポーネント</param>
        /// <param name="endDateEdit">終了日付コンポーネント</param>
        /// <param name="msg">エラーメッセージ</param>   
        /// <param name="errComponent">入力エラーコントロール</param>
        /// <returns>true:正常 false:異常</returns>
        private bool DateCheck(TDateEdit startDateEdit, TDateEdit endDateEdit, ref string msg, ref Control errComponent)
        {
            bool status = true;

            if (IsErrorTDateEdit(startDateEdit, true))
            {
                msg += "開始日の日付が正しくありません。";
                errComponent = startDateEdit;
                status = false;
                return status;
            }

            if (IsErrorTDateEdit(endDateEdit, true))
            {
                msg += "終了日の日付が正しくありません。";
                errComponent = endDateEdit;
                status = false;
                return status;
            }

            if ((startDateEdit.GetDateTime() != DateTime.MinValue) && (endDateEdit.GetDateTime() != DateTime.MinValue))
            {
                if (startDateEdit.GetLongDate() > endDateEdit.GetLongDate())
                {
                    msg += "開始日が終了日を超えています。";
                    errComponent = startDateEdit;
                    status = false;
                    return status;
                }
            }
            return status;
        }
        
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="canEmpty">未入力フラグ(true:未入力可,false:未入力不可)</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return true;

            // 日付を数値型で取得
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 未入力フラグチェック
            if (canEmpty)
            {
                // 未入力可で未入力の場合は正常
                if (date == 0) return false;
            }

            // 日付未入力チェック
            if (date == 0) return true;

            // システムサポートチェック
            if ((yy > 0) && (yy < 1900)) return true;

            // 年・月・日別入力チェック
            switch (tDateEdit.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return true;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return true;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return true;
                        break;
                    }
                // 月        表示時
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return true;
                        break;
                    }
                // 日        表示時
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return true;
                        break;
                    }
            }

            return false;
        }

        #endregion

        #region ControlEvent

        #region Form Load イベント
        /// <summary>
        /// Form.Load イベント (MAZAI02070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが初めて表示される直前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void SFDML06360UA_Load(object sender, EventArgs e)
        {
            //アイコン(☆) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
                   
            //商品ガイド
            this.St_GoodsGuide_Button.ImageList = imageList16;
            this.Ed_GoodsGuide_Button.ImageList = imageList16;
            this.St_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //商品区分グループガイド
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_LargeGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_LargeGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //商品区分ガイド
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //メーカーガイド
            this.St_MakerGuide_Button.ImageList = imageList16;
            this.Ed_MakerGuide_Button.ImageList = imageList16;
            this.St_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////キャリアガイド
            //this.St_CarrierGuide_Button.ImageList = imageList16;
            //this.Ed_CarrierGuide_Button.ImageList = imageList16;
            //this.St_CarrierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_CarrierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //商品区分詳細ガイド
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //自社分類ガイド
            //--- DEL 2008/08/01 ---------->>>>>
            //this.St_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.Ed_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.St_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008/08/01 ----------<<<<<
            //ＢＬ商品コードガイド
            this.St_BLGoodsGuide_Button.ImageList = imageList16;
            this.Ed_BLGoodsGuide_Button.ImageList = imageList16;
            this.St_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //倉庫ガイド
            this.St_WarehouseGuide_Button.ImageList = imageList16;
            this.Ed_WarehouseGuide_Button.ImageList = imageList16;
            this.St_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            this.ub_St_CustomerCodeGuide.ImageList = imageList16;
            this.ub_Ed_CustomerCodeGuide.ImageList = imageList16;
            this.ub_St_CustomerCodeGuide.Appearance.Image = Size16_Index.STAR1;
            this.ub_Ed_CustomerCodeGuide.Appearance.Image = Size16_Index.STAR1;
            //--- ADD 2008/08/01 ----------<<<<<

            // --- ADD 2008/10/07 --------------->>>>>
            // 非表示(画面ロード時に一瞬見える為、コントロール自体もFalseにしておく)
            this.St_GoodsGuide_Button.Visible = false;      // 品番From
            this.Ed_GoodsGuide_Button.Visible = false;      // 品番To
            // --- ADD 2008/10/07 ---------------<<<<<

            this.SetDuplicationShelfNo(clb_DuplicationShelfNo1, 72);        //ADD 2009/06/25 不具合対応[13586]
            this.SetDuplicationShelfNo(clb_DuplicationShelfNo2, 73);        //ADD 2009/06/25 不具合対応[13586]

            //画面初期設定
            this.ScreenInitialSetting();

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            if (this.ParentToolbarSettingEvent != null)
            {
                this.ParentToolbarSettingEvent(this);
            }

            // ADD 2009/03/31 不具合対応[12894]：スペースキーでの項目選択機能を実装 ---------->>>>>
            PublicationTypeRadioKeyPressHelper.ControlList.Add(this.uos_PublicationType);
            PublicationTypeRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();

            ChangePageDivRadioKeyPressHelper.ControlList.Add(this.uos_ChangePageDiv);
            ChangePageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12894]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }
        #endregion

        #region Form VisibleChanged イベント
        /// <summary>
        /// Form.VisibleChanged イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変更されると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2006.07.31</br>
        /// </remarks>    
        private void Main_UltraExplorerBar_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // 初期フォーカス設定
                //this.StartMakerCode_tNedit.Focus();       // DEL 2008.08.01
                this.tde_St_AddUpYearMonth.Focus();         // ADD 2008.08.01
            }
        }
        #endregion

        #region UltraExplorerBar イベント
        /// <summary>
        /// UltraExplorerBar.GroupExpanding イベント (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroupが展開される前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortGroap") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// UltraExplorerBar.GroupCollapsing イベント (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroupが縮小される前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortGroap") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region Control Leave イベント
        /// <summary>
        /// Control.Leave イベント (ShipmentPosCnt_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private void StartShipmentPosCnt_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // 空欄か0の時初期値をセット
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                if (tNedit.Equals(this.StartShipmentPosCnt_tNedit))
                {
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.EndShipmentPosCnt_tNedit))
                {
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(99999999);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                }
            }
        }

        /// <summary>
        /// Control.Leave イベント (StartMakerCode_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.22</br>
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
                if (tNedit.Equals(this.tNedit_GoodsMakerCd_St))
                {
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.tNedit_GoodsMakerCd_Ed))
                {
                    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(999);
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(999999);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                }
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //else if (tNedit.Equals(this.StartCarrierCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndCarrierCode_tNedit))
                //{
                //    tNedit.SetInt(999);
                //}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                //--- DEL 2008/08/01 ---------->>>>>
                //else if (tNedit.Equals(this.StartEnterpriseGanreCode_tNedit))
                //{
                //    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //    //tNedit.SetInt(0);
                //    tNedit.DataText = "";
                //    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                //}
                //else if (tNedit.Equals(this.EndEnterpriseGanreCode_tNedit))
                //{
                //    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                //    //tNedit.SetInt(99);
                //    tNedit.DataText = "";
                //    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                else if (tNedit.Equals(this.tNedit_BLGoodsCode_St))
                {
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(0);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                }
                else if (tNedit.Equals(this.tNedit_BLGoodsCode_Ed))
                {
                    // 2008.01.21 修正 >>>>>>>>>>>>>>>>>>>>
                    //tNedit.SetInt(99999999);
                    tNedit.DataText = "";
                    // 2008.01.21 修正 <<<<<<<<<<<<<<<<<<<<
                }
                // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
            }           
        }
            
        #endregion

        #region ガイド呼出し処理

        #region メーカーガイド
        /// <summary>
        /// メーカーガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //Maker maker = null;
            MakerUMnt makerUMnt = null;
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();               
            }
            //メーカーガイド起動
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            switch(status)
            {
                //取得
                case 0:
                {
                    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //if (maker != null)
                    if (makerUMnt != null)
                    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((Infragistics.Win.Misc.UltraButton)sender == this.St_MakerGuide_Button)
                        {
                            //開始
                            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.StartMakerCode_tNedit.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                            //--- ADD 2008.08.01 ---------->>>>>
                            // 次のコントロールにフォーカス移動
                            this.tNedit_GoodsMakerCd_Ed.Focus();
                            //--- ADD 2008.08.01 ----------<<<<<
                        }
                        else
                        {
                            //終了
                            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                            //this.EndMakerCode_tNedit.SetInt(maker.MakerCode);
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                            //--- ADD 2008.08.01 ---------->>>>>
                            // 次のコントロールにフォーカス移動
                            this.tNedit_BLGoodsCode_St.Focus();
                            //--- ADD 2008.08.01 ----------<<<<<
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

        //--- DEL 2008/08/01 ---------->>>>>
        #region 商品区分グループガイド
        ///// <summary>
        ///// 商品区分グループガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分グループガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.03.22</br>
        ///// </remarks>    
        //private void LargeGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    LGoodsGanre lGoodsGanre = null;
        //    if(this._lGoodsGanreAcs == null)
        //    {
        //        this._lGoodsGanreAcs = new LGoodsGanreAcs();               
        //    }
        //    //商品区分グループガイド
        //    int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(lGoodsGanre != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_LargeGoodsGanreGuide_Button)
        //                {
        //                    //開始
        //                    this.StartLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();                           
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.EndLargeGoodsGanreCode_tEdit.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();                       
        //                }           
                                  
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
        //--- DEL 2008/08/01 ----------<<<<<

        //--- DEL 2008/08/01 ---------->>>>>
        #region 商品区分ガイド
        ///// <summary>
        ///// 商品区分ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.03.22</br>
        ///// </remarks>    
        //private void MidiumGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    MGoodsGanre mGoodsGanre = null;
        //    if(this._mGoodsGanreAcs == null)
        //    {
        //        this._mGoodsGanreAcs = new MGoodsGanreAcs();               
        //    }

        //    //TODO:引数として商品区分グループが残っている。とりあえず空文字を固定でセットしておく
        //    //商品区分ガイド起動
        //    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
        //    //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
        //    int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);
        //    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(mGoodsGanre != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_MidiumGoodsGanreGuide_Button)
        //                {
        //                    //開始
        //                    this.StartMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.EndMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }           
                                  
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
        //--- DEL 2008/08/01 ----------<<<<<

        #region 商品ガイド
        /// <summary>
        /// 商品ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        private void GoodsGuide_Button_Click(object sender, EventArgs e)
        {     
            GoodsUnitData goodsUnitData = null;
            MAKHN04110UA goodsGuide = new MAKHN04110UA();

            DialogResult ret = goodsGuide.ShowGuide(this,this._enterpriseCode,out goodsUnitData);

            if(ret == DialogResult.OK)
            {
                if(goodsUnitData != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if((Infragistics.Win.Misc.UltraButton)sender == this.St_GoodsGuide_Button)
                    {
                        //開始
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
                        this.tEdit_GoodsNo_St.DataText = goodsUnitData.GoodsNo.TrimEnd();
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //--- ADD 2008.08.01 ---------->>>>>
                        // 次のコントロールにフォーカス移動
                        this.tEdit_GoodsNo_Ed.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                    else
                    {
                        //終了
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
                        this.tEdit_GoodsNo_Ed.DataText = goodsUnitData.GoodsNo.TrimEnd();
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                    }           
                              
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }
        }

        #endregion

        //--- DEL 2008/08/01 ---------->>>>>
        // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
        #region 商品区分詳細ガイド
        ///// <summary>
        ///// 商品区分詳細ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分詳細ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 980035 金沢　貞義</br>
        ///// <br>Date       : 2007.10.05</br>
        ///// </remarks>    
        //private void DetailGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    DGoodsGanre dGoodsGanre = null;
        //    if (this._dGoodsGanreAcs == null)
        //    {
        //        this._dGoodsGanreAcs = new DGoodsGanreAcs();
        //    }

        //    //TODO:引数として商品区分グループが残っている。とりあえず空文字を固定でセットしておく
        //    //商品区分詳細ガイド起動
        //    int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);

        //    switch (status)
        //    {
        //        //取得
        //        case 0:
        //            {
        //                if (dGoodsGanre != null)
        //                {
        //                    //開始、終了どちらのボタンが押されたか？
        //                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_DetailGoodsGanreGuide_Button)
        //                    {
        //                        //開始
        //                        this.StartDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                    else
        //                    {
        //                        //終了
        //                        this.EndDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }

        //                }
        //                break;
        //            }
        //        //キャンセル
        //        case 1:
        //            {
        //                break;
        //            }
        //    }
        //}
        #endregion
        //--- DEL 2008/08/01 ----------<<<<<

        #region ＢＬ商品ガイド
        /// <summary>
        /// ＢＬ商品ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ＢＬ商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>    
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            // ＢＬ商品ガイド起動
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            switch (status)
            {
                // 取得
                case 0:
                    {
                        if (blGoodsCdUMnt != null)
                        {
                            // 開始、終了どちらのボタンが押されたか？
                            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGoodsGuide_Button)
                            {
                                // 開始
                                this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                //--- ADD 2008.08.01 ---------->>>>>
                                // 次のコントロールにフォーカス移動
                                this.tNedit_BLGoodsCode_Ed.Focus();
                                //--- ADD 2008.08.01 ----------<<<<<
                            }
                            else
                            {
                                // 終了
                                this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                                //--- ADD 2008.08.01 ---------->>>>>
                                // 次のコントロールにフォーカス移動
                                this.tEdit_GoodsNo_St.Focus();
                                //--- ADD 2008.08.01 ----------<<<<<
                            }

                        }
                        break;
                    }
                // キャンセル
                case 1:
                    {
                        break;
                    }
            }
        }

        #endregion

        #region 倉庫ガイド
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            if (this._warehouseGuideAcs == null)
            {
                this._warehouseGuideAcs = new WarehouseAcs();
            }

            // 倉庫ガイド起動
            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._loginSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    // 開始、終了どちらのボタンが押されたか？
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_WarehouseGuide_Button)
                    {
                        // 開始
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                        //--- ADD 2008.08.01 ---------->>>>>
                        // 次のコントロールにフォーカス移動
                        this.tEdit_WarehouseCode_Ed.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                    else
                    {
                        // 終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                        //--- ADD 2008.08.01 ---------->>>>>
                        // 次のコントロールにフォーカス移動
                        this.tNedit_SupplierCd_St.Focus();
                        //--- ADD 2008.08.01 ----------<<<<<
                    }
                }
            }
            else
            {
                // キャンセルなのでなにもしない
            }

        }
        #endregion

        //--- ADD 2008/08/01 ---------->>>>>
        #region 仕入先ガイド
        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_CustomerCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            Supplier supplier = new Supplier();

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status != 0) return;

            TEdit targetControl;
            Control nextControl = null;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SupplierCd_St;
                nextControl = this.tNedit_SupplierCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SupplierCd_Ed;
                nextControl = this.tEdit_WarehouseShelfNo_St;
            }
            else
            {
                return;
            }

            targetControl.DataText = supplier.SupplierCd.ToString();

            // フォーカス移動
            nextControl.Focus();

        }
        #endregion

        private void uos_ChangePageDiv_ValueChanged(object sender, EventArgs e)
        {
            // 棚番順が選択されている時のみ、棚番ブレイク区分を入力可とする。
            if ((int)(sender as UltraOptionSet).Value == (int)StockListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = true;
            }
            else
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = false;
                this.ce_WarehouseShelfNoBreakDiv.Value = (int)StockListCndtn.WarehouseShelfNoBreakDivState.Length1;
            }
        }
        //--- ADD 2008/08/01 ----------<<<<<

        //--- DEL 2008/08/01 ---------->>>>>
        #region 自社分類ガイド（ユーザーガイド）
        ///// <summary>
        ///// 自社分類ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 自社分類ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 980035 金沢　貞義</br>
        ///// <br>Date       : 2007.10.05</br>
        ///// </remarks>    
        //private void EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    UserGdBd userGdBd = null;
        //    if (this._userGuideGuide == null)
        //    {
        //        this._userGuideGuide = new UserGuideGuide();
        //    }

        //    //ユーザーガイド起動
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        if (userGdBd != null)
        //        {
        //            //開始、終了どちらのボタンが押されたか？
        //            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
        //            {
        //                //開始
        //                this.StartEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //            else
        //            {
        //                //終了
        //                this.EndEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //        }
        //    }
        //}
        #endregion
        // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ----------<<<<<

        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        #region キャリアガイド
        ///// <summary>
        ///// キャリアガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : キャリアガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        //private void St_CarrierGuide_Button_Click(object sender, EventArgs e)
        //{
        //    Carrier carrier = null;        
        //    if(this._carrierOdrAcs == null)
        //    {
        //        this._carrierOdrAcs = new CarrierOdrAcs();               
        //    }
        //
        //    //キャリアガイド起動
        //    int status = this._carrierOdrAcs.ExecuteGuid(this._enterpriseCode,this._loginSectionCode,out carrier);
        //  
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(carrier != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_CarrierGuide_Button)
        //                {
        //                    //開始
        //                     this.StartCarrierCode_tNedit.SetInt(carrier.CarrierCode);
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.EndCarrierCode_tNedit.SetInt(carrier.CarrierCode);
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

        #endregion
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

        #endregion

        #region 棚番KeyPressイベント
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

        #endregion

        // --- ADD 2008/10/07 -------------------------------------->>>>>
        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                // 選択状態
                ((ListBox)sender).SetSelected(0, true);
            }
        }

        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // 選択状態解除
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        // --- ADD 2008/10/07 --------------------------------------<<<<<
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリスト
// プログラム概要   : 発注点設定マスタ情報を抽出し、印刷・PDF出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注点設定マスタリストUIフォームクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリストUIフォームを行う。</br>      
    /// <br>Programmer : 呉元嘯</br>                                   
    /// <br>Date       : 2009.03.26</br>                                       
    /// </remarks>
    public partial class PMHAT02020UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer	        // 帳票業務（条件入力）PDF出力履歴管理
    {
       #region ■ Constructor
        /// <summary>
        /// 発注点設定マスタリストUIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリストUIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.03.26</br>                                       
        /// <br></br>
        /// </remarks>
        public PMHAT02020UA()
        {
           InitializeComponent();

           // 企業コード取得
           this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

           // ログイン担当者 
           this._employee = LoginInfoAcquisition.Employee.Clone();

           // 拠点コード
           this._loginSectionCode = this._employee.BelongSectionCode;

       }
        #endregion ■ Constructor

       #region ■ Private Member
       #region ◆ Interface member
       //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
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
       #endregion ◆ Interface member

       // 企業コード
       private string _enterpriseCode = string.Empty;

       // 画面イメージコントロール部品
       private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

       // 拠点コード
       private string _loginSectionCode;

       // 倉庫ガイド用
       WarehouseAcs _wareHouseAcs;

       // 仕入先ガイド用
       private SupplierAcs _supplierAcs;

       // メーカーガイド用
       private MakerAcs _makerAcs;

       // 商品中分類ガイド用
       private GoodsGroupUAcs _goodsGroupUAcs;

       // グループコードガイド用
       private BLGroupUAcs _blGroupUAcs;

       // BLコードガイド用
       private BLGoodsCdAcs _blGoodsCdAcs;

       // 担当者
       private Employee _employee;
       
       // フォーカスControl
       private Control _prevControl = null;

       // チェックエラー
       private bool hasCheckError = false;

       #endregion ■ Private Member

       #region ■ Private Const
       #region ◆ Interface member
       //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
       // クラスID
       private const string ct_ClassID = "PMHAT02020UA";
       // プログラムID
       private const string ct_PGID = "PMHAT02020U";
       //// 帳票名称
       private const string PDF_PRINT_NAME = "発注点設定マスタ";
       private string _printName = PDF_PRINT_NAME;
       // 帳票キー	
        private const string PDF_PRINT_KEY = "97714852-acbf-4219-a389-29f3a7b9ba96";
       private string _printKey = PDF_PRINT_KEY;
       #endregion ◆ Interface member

       // ExporerBar グループ名称
       private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
       //エラー条件メッセージ
       // const string ct_NoInput = "を入力してください。"; // DEL 2009/07/13 PVCS334
       const string ct_RangeError = "の範囲に誤りがあります。";

       // 開始ガイドフラグ
       private const string ST_GUID = "1";

       // 終了ガイドフラグ
       private const string ED_GUID = "2";
       #endregion
       
       #region ■ Control Event
       #region ◆ PMHAT02020UA
       #region ◎ PMHAT02020UA_Load Event
       /// <summary>
       /// PMHAT02020UA_Load Event
       /// </summary>
       /// <param name="sender">対象オブジェクト</param>
       /// <param name="e">イベントパラメータ</param>
       /// <remarks>
       /// <br>Note		  : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
       /// <br>Programmer : 呉元嘯</br>                                   
       /// <br>Date       : 2009.03.26</br>                                       
       /// </remarks>
       private void PMHAT02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            // コントロール初期化
            this.InitializeScreen();
            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動  
            // 初期化フォーカス
            this.Cursor = Cursors.WaitCursor;
            tNedit_PatterNo_St.Focus();
            _prevControl = tNedit_PatterNo_St;
            this.Cursor = Cursors.Default;

        }
       #endregion
       #endregion ◆ PMHAT02020UA

       #region ◆ ueb_MainExplorerBar
       #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
       #endregion

       #region ◎ GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }
       #endregion
       #endregion ◆ ueb_MainExplorerBar

       # region  ■ tArrowKeyControl1_ChangeFocus
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: なし</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_PatterNo_St)
                    {
                        // 設定コード(開始)→設定コード(終了)
                        tNedit_PatterNo_St_AfterExitEditMode(e.PrevCtrl, null);
                        e.NextCtrl = this.tNedit_PatterNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PatterNo_Ed)
                    {
                        tNedit_PatterNo_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 設定コード(終了)→倉庫コード(開始)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        tEdit_WarehouseCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 倉庫(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        tEdit_WarehouseCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 倉庫(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        tNedit_SupplierCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        tNedit_SupplierCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 仕入先(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        tNedit_GoodsMakerCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // メーカー(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        tNedit_GoodsMakerCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // メーカー(終了)→中分類(開始)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        tNedit_GoodsMGroup_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 中分類(開始)→中分類(終了)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        tNedit_GoodsMGroup_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 中分類(終了)→グループ(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        tNedit_BLGloupCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // グループ(開始)→グループ(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        tNedit_BLGloupCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // グループ(終了)→bLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        tNedit_BLGoodsCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // bLコード(開始)→bLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        tNedit_BLGoodsCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // bLコード(終了)→ 発行タイプ
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 発行タイプ→  設定コード(開始)
                        e.NextCtrl = this.tNedit_PatterNo_St;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    // 設定コード(開始)→発行タイプ
                    if (e.PrevCtrl == this.tNedit_PatterNo_St)
                    {
                        tNedit_PatterNo_St_AfterExitEditMode(e.PrevCtrl, null);
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // 発行タイプ→ bLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        tNedit_BLGoodsCode_Ed_AfterExitEditMode(e.PrevCtrl, null);                        
                        // bLコード(終了)→ bLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        tNedit_BLGoodsCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // bLコード(開始)→ グループ(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        tNedit_BLGloupCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // グループ(終了)→グループ(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        tNedit_BLGloupCode_St_AfterExitEditMode(e.PrevCtrl, null);                        
                        // グループ(開始)→中分類(終了)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        tNedit_GoodsMGroup_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 中分類(終了)→中分類(開始)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        tNedit_GoodsMGroup_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 中分類(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        tNedit_GoodsMakerCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // メーカー(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        tNedit_GoodsMakerCd_St_AfterExitEditMode(e.PrevCtrl, null);                        
                        // メーカー(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        tNedit_SupplierCd_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        tNedit_SupplierCd_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 仕入先(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        tEdit_WarehouseCode_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 倉庫(終了)→倉庫(開始)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        tEdit_WarehouseCode_St_AfterExitEditMode(e.PrevCtrl, null);
                        // 倉庫(開始)→設定コード(終了)
                        e.NextCtrl = this.tNedit_PatterNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_PatterNo_Ed)
                    {
                        tNedit_PatterNo_Ed_AfterExitEditMode(e.PrevCtrl, null);
                        // 設定コード(終了)→設定コード(開始)
                        e.NextCtrl = this.tNedit_PatterNo_St;
                    }
                }
            }
        }
        #endregion

       # region ■ ガイドボタンクリックイベント
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 倉庫ガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_WareHouse_Click(object sender, EventArgs e)
        {
            if (this._wareHouseAcs == null)
            {
                this._wareHouseAcs = new WarehouseAcs();
            }
            // 倉庫ガイド起動
            Warehouse warehouse;
            int status = this._wareHouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status != 0) return;
            // 倉庫開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
            // 倉庫終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_SupplierCd_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 仕入先ガイドクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_SupplierCd_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");
            if (status != 0) return;

            // 仕入先開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
            // 仕入先終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }

        }
        /// <summary>
        /// メーカーガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_Maker_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            // メーカーガイド起動
            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // メーカー開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            // メーカー終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 中分類ガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_GoodsMGroupCd_Click(object sender, EventArgs e)
        {
            // 商品中分類ガイド起動
            GoodsGroupU goodgroupU;

            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);
            if (status != 0) return;
            // 商品中分類開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            // 商品中分類終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// グループコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: グループガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_Group_Click(object sender, EventArgs e)
        {
            // グループガイド起動
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            // グループ開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            // グループ終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ＢＬコードガイドをクリックするときに発生する</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private void uButton_St_BLGoodsCode_Click(object sender, EventArgs e)
        {
            // ＢＬコードガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            // ＢＬコード開始ガイドを選択する場合
            if (((UltraButton)sender).Tag.ToString().CompareTo(ST_GUID) == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            // ＢＬコード終了ガイドを選択する場合
            else if (((UltraButton)sender).Tag.ToString().CompareTo(ED_GUID) == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tComboEditor_PrintType.Focus();

            }
            else
            {
                return;
            }
        }
        #endregion

       #region ■ フォーカスアウト
        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 設定コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_PatterNo_St_AfterExitEditMode(object sender, EventArgs e)
        {
            if (0 == this.tNedit_PatterNo_St.GetInt())
            {
                this.tNedit_PatterNo_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 設定コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_PatterNo_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 設定コード終了の値は数字ではない場合
            if (0 == this.tNedit_PatterNo_Ed.GetInt())
            {
                this.tNedit_PatterNo_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 倉庫コード開始の値は数字ではない場合
            if (!IsNumber(this.tEdit_WarehouseCode_St.Text))
            {
                this.tEdit_WarehouseCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }

        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 倉庫コード終了の値は数字ではない場合
            if (!IsNumber(this.tEdit_WarehouseCode_Ed.Text))
            {
                this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }

        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 仕入先コード開始の値は数字ではない場合
            if (0 == this.tNedit_SupplierCd_St.GetInt())
            {
                this.tNedit_SupplierCd_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 仕入先コード終了の値は数字ではない場合
            if (0 == this.tNedit_SupplierCd_Ed.GetInt())
            {
                this.tNedit_SupplierCd_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // メーカーコード開始の値は数字ではない場合
            if (0 == this.tNedit_GoodsMakerCd_St.GetInt())
            {
                this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // メーカーコード終了の値は数字ではない場合
            if (0 == this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 中分類コード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // 中分類コード開始の値は数字ではない場合
            if (0 == this.tNedit_GoodsMGroup_St.GetInt())
            {
                this.tNedit_GoodsMGroup_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 中分類コード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // 中分類コード終了の値は数字ではない場合
            if (0 == this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                this.tNedit_GoodsMGroup_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グループコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // グループコード開始の値は数字ではない場合
            if (0 == this.tNedit_BLGloupCode_St.GetInt())
            {
                this.tNedit_BLGloupCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グループコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // グループコード終了の値は数字ではない場合
            if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
            {
                this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLコード開始フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // BLコード開始の値は数字ではない場合
            if (0 == this.tNedit_BLGoodsCode_St.GetInt())
            {
                this.tNedit_BLGoodsCode_St.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLコード終了フォーカスが離れたときに発生します。</br>      
        /// <br>Programmer : 呉元嘯</br>                                  
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // BLコード終了の値は数字ではない場合
            if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                hasCheckError = false;
                return;
            }
        }
        #endregion

       #region ■ 数字を判断処理
        /// <summary>
        /// 数字を判断処理
        /// </summary>
        /// <param name="s">文字列</param>
        /// <remarks>
        /// <br>Note		: 数字を判断処理を行い</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.04.16</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

       #endregion ■ Control Event

       #region ■ Private Method
       #region ◆ 画面初期化関係
       #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコンを設定する。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.03.26</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

       #endregion

       #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.27</br>                                       
        /// </remarks>
        public void InitializeScreen()
        {
            //設定コード
            this.tNedit_PatterNo_St.Clear();
            this.tNedit_PatterNo_Ed.Clear();
            //倉庫
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseCode_St.Clear();
            //仕入先
            this.tNedit_SupplierCd_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            //メーカー
            this.tNedit_GoodsMakerCd_Ed.Clear();
            this.tNedit_GoodsMakerCd_St.Clear();
            //中分類
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
            //グループ
            this.tNedit_BLGoodsCode_Ed.Clear();
            this.tNedit_BLGloupCode_St.Clear();
            //ＢＬコード
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            // 発行タイプ= 「0:通常」
            tComboEditor_PrintType.Value = 0;
           
            // ボタン設定
            this.SetIconImage(this.uButton_Ed_BLGoodsCode, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_GoodsMGroupCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_Group, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_Maker, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_WareHouse, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_Ed_SupplierCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_BLGoodsCode, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_GoodsMGroupCd, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_Group, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_Maker, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_WareHouse, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_St_SupplierCd, Size16_Index.STAR1);

        }
       #endregion ◎ 画面初期化処理
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
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.27</br>                                       
        /// </remarks>s		
        public bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
           
            //設定コード
            /* ----DEL 2009/07/13 PVCS334 ---------->>>>>
            if (this.tNedit_PatterNo_St.DataText.TrimEnd() == string.Empty)
            {
                errMessage = string.Format("設定コード{0}", ct_NoInput);
                errComponent = this.tNedit_PatterNo_St;
                status = false;
            }
            ------DEL 2009/07/13 PVCS334 ----------<<<<< */
            if ((this.tNedit_PatterNo_St.DataText.TrimEnd() != string.Empty)
              && (this.tNedit_PatterNo_Ed.DataText.TrimEnd() != string.Empty)
              && (this.tNedit_PatterNo_St.GetInt() > this.tNedit_PatterNo_Ed.GetInt()))
            {
                errMessage = string.Format("設定コード{0}", ct_RangeError);
                errComponent = this.tNedit_PatterNo_St;
                status = false;
            }
            //倉庫
            else if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty)
              && (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty)
              && (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("倉庫コード{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            //仕入先
            else if ((this.tNedit_SupplierCd_St.DataText.TrimEnd() != string.Empty)
                 && (this.tNedit_SupplierCd_Ed.DataText.TrimEnd() != string.Empty)
                 && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
                {
                errMessage = string.Format("仕入先コード{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            //メーカー
            else if ((this.tNedit_GoodsMakerCd_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("メーカーコード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            //中分類
            else if ((this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("中分類コード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            //グループ
            else if ((this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            //ＢＬコード
            else if ((this.tNedit_BLGoodsCode_St.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGoodsCode_Ed.DataText.TrimEnd() != string.Empty)
                  && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            return status;
        }
        #endregion ◎ 入力チェック処理

       #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="_orderSetMasListPara">抽出条件</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note	   : 画面→抽出条件へ設定する。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.03.31</br>                                       
        /// </remarks>
        private int SetExtraInfoFromScreen( ref OrderSetMasListPara _orderSetMasListPara)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                _orderSetMasListPara.EnterpriseCode = this._enterpriseCode;

                // 設定コード(開始)
                // --- ADD 2009/07/13 PVCS334 ---------->>>>>
                if (0 != this.tNedit_PatterNo_St.GetInt())
                {
                    _orderSetMasListPara.StartSetCode = this.tNedit_PatterNo_St.GetInt().ToString("D3");
                }
                else
                {
                    _orderSetMasListPara.StartSetCode = string.Empty;
                }
                //--- ADD 2009/07/13 PVCS334----------<<<<<
                // DEL 2009/07/13 PVCS334
                // _orderSetMasListPara.StartSetCode = this.tNedit_PatterNo_St.GetInt().ToString("D3");
                // 設定コード(終了)
                if (0 != this.tNedit_PatterNo_Ed.GetInt())
                {
                    _orderSetMasListPara.EndSetCode = this.tNedit_PatterNo_Ed.GetInt().ToString("D3");
                }
                else
                {
                    _orderSetMasListPara.EndSetCode = string.Empty;
                }
                // 倉庫コード(開始)
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode_St.Text))
                {
                    _orderSetMasListPara.StartWarehouseCode = this.tEdit_WarehouseCode_St.Text.Trim();
                }
                else 
                {
                    _orderSetMasListPara.StartWarehouseCode = string.Empty;
                }
                // 倉庫コード(終了)
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode_Ed.Text))
                {
                    _orderSetMasListPara.EndWarehouseCode = this.tEdit_WarehouseCode_Ed.Text.Trim();
                }
                else
                {
                    _orderSetMasListPara.EndWarehouseCode = string.Empty;
                }
                // 仕入先コード(開始)
                _orderSetMasListPara.StartSupplierCd = tNedit_SupplierCd_St.GetInt();
                // 仕入先コード(終了)
                _orderSetMasListPara.EndSupplierCd = tNedit_SupplierCd_Ed.GetInt();
                // メーカーコード(開始)
                _orderSetMasListPara.StartGoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
                // メーカーコード(終了)
                _orderSetMasListPara.EndGoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
                // 中分類コード(開始)
                _orderSetMasListPara.StartGoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
                // 中分類コード(終了)
                _orderSetMasListPara.EndGoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
                // グループコード(開始)
                _orderSetMasListPara.StartBLGroupCode = tNedit_BLGloupCode_St.GetInt();
                // グループコード(終了)
                _orderSetMasListPara.EndBLGroupCode = tNedit_BLGloupCode_Ed.GetInt();
                // ＢＬコード(開始)
                _orderSetMasListPara.StartBLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
                // ＢＬコード(終了)
                _orderSetMasListPara.EndBLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
                // 発行タイプ
                _orderSetMasListPara.PrintType = (int)tComboEditor_PrintType.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
       
       #endregion ◆ 印刷前処理

       #region ■ エラーメッセージ ■
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.03.26</br>                                       
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
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
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
       #endregion ■ エラーメッセージ ■
       #endregion ■ Private Method 

       #region ■ IPrintConditionInpType メンバ
       #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

       #region ◆ Public Property
        /// <summary> 抽出ボタン状態</summary>
        /// <value>CanExtract</value>               
        /// <remarks>抽出ボタン状態取得プロパティ </remarks> 
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態</summary>
        /// <value>CanPdf</value>               
        /// <remarks>PDF出力ボタン状態取得プロパティ </remarks> 
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態</summary>
        /// <value>CanPrint</value>               
        /// <remarks>印刷ボタン状態取得プロパティ </remarks> 
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>抽出ボタン表示有無取得プロパティ </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF出力ボタン表示有無プロパティ取得プロパティ </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>印刷ボタン表示取得プロパティ </remarks> 
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
        /// <remarks>
        /// <br>Note       : 抽出を行います。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.03.26</br> 
        /// </remarks>
        public int Extract(ref object parameter)
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
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
       public int Print(ref object parameter)
        {
            // オフライン状態チェック
            if (!CheckOnlineStatus("PDFのデータ出力処理"))
            {
                return -1;
            }

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件クラス
            OrderSetMasListPara _orderSetMasListPara = new OrderSetMasListPara();


            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(ref _orderSetMasListPara);
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = _orderSetMasListPara;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データがありません。", 0);
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
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

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

                status = false;
            }
            // フォーカスアウト処理
            if (this._prevControl != null)
            {
                hasCheckError = false;
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
            }
            if (hasCheckError)
            {
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
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }

        #endregion

        #endregion ◆ Public Method
       #endregion ■ IPrintConditionInpType メンバ

       #region ■ IPrintConditionInpTypePdfCareer メンバ
       #region ◆ Public Property

        /// <summary> 帳票キー</summary>
        /// <value>PrintKey</value>               
        /// <remarks>帳票キー取得プロパティ </remarks>  
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名</summary>
        /// <value>PrintName</value>               
        /// <remarks>帳票名取得ププロパティ </remarks>  
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion ◆ Public Method
       #endregion ■ IPrintConditionInpTypePdfCareer メンバ

       #region ■ オフライン状態チェック処理
        /// <summary>
        /// オフラインチェックログ出力する処理
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: オフラインチェックログ出力する処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckOnlineStatus(String msg)
        {
            bool succFlg = true;

            // オフライン状態チェック									
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    msg + "に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                succFlg = false;
            }

            return succFlg;
        }
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note		: ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// リモート接続可能判定処理
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note		: リモート接続可能判定処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.03.26</br>                                       
        /// </remarks>
        private bool CheckRemoteOn()
        {

            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

       
 
    }
}
//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入在庫全体設定
// プログラム概要   : 仕入在庫関連の設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2005 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 19018 Y.Gamoto
// 作 成 日  2005/04/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/06/13  修正内容 : ①税率有効日１の位置変更（プロパティのみ変更）
//                                  ②各数値項目を右詰め（プロパティのみ変更）
//                                  ③ステータスバーの色変更（プロパティのみ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/06/17  修正内容 : 初期フォーカスの項目を全選択されるように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/06/21  修正内容 : ①消費税率に.1と打った場合0.1と表示させる修正
//                                  ②データビューの未設定を空白で表示させる修正
//                                  ③数値型Editの先頭に０が保存されないように修正（プロパティのみ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/06/22  修正内容 : コンボボックス消費税端数処理の表示項目数を変更（プロパティのみ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/06/24  修正内容 : TNeditのプロパティ設定統一化（プロパティのみ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋　弘憲
// 修 正 日  2005/06/30  修正内容 : tDateEditとtComboEditorのImeModeをDisableに変更（プロパティのみ変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋  弘憲
// 修 正 日  2005/07/04  修正内容 : フレームの最小化対応改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋　弘憲
// 修 正 日  2005/07/06  修正内容 : 排他制御対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋　弘憲
// 修 正 日  2005/07/12  修正内容 : ステータスバーを最前面へ変更
//                                  排他制御のコメント変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23003 enokida
// 修 正 日  2005/09/09  修正内容 : ログイン情報取得対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23003 enokida
// 修 正 日  2005/09/17  修正内容 : Message部品対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22021 谷藤　範幸
// 修 正 日  2005/10/19  修正内容 : ・UI子画面Hide時のOwner.Activate処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22023 土田　都
// 修 正 日  2006/06/09  修正内容 : 「総額表示方法区分」追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23003 榎田
// 修 正 日  2006/07/04  修正内容 : タブオーダーの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23003 榎田
// 修 正 日  2006/07/15  修正内容 : 税率有効日を西暦に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20031 古賀
// 修 正 日  2006/12/20  修正内容 : 携帯システム用に項目を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20031 古賀
// 修 正 日  2007/04/02  修正内容 : 消費税率にDouble桁数分登録できてしまう障害を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30005 木建　翼
// 修 正 日  2007/06/12  修正内容 : 「仕入価格取得単位区分」追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30167 上野　弘貴
// 修 正 日  2008/02/18  修正内容 : 自動支払関連項目追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20081 疋田 勇人
// 修 正 日  2008/02/27  修正内容 : 入出荷数区分２を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 修 正 日  2008/06/04  修正内容 : ・データ項目の追加/削除による修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 修 正 日  2008/07/22  修正内容 : ・項目の削除による修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2008/09/12  修正内容 : ・在庫検索区分の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/29  修正内容 : ・バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/08  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/09  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/10  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30365 宮津 銀次郎
// 修 正 日  2008/12/01  修正内容 : 仕様変更で無くなった返品項目に関わる修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/25  修正内容 : 不具合対応[13589]
//----------------------------------------------------------------------------//
// 管理番号 10704766-00  作成担当：王飛3
// 修 正 日 2011/07/28   修正内容：連番909　で拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//                       拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正してください。
// ---------------------------------------------------------------------------//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 不具合対応による共通仕様の展開
using System.Windows.Forms;

//using tsubasa;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 不具合対応による共通仕様の展開
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///	仕入在庫全体設定クラス
    /// </summary>
    /// <remarks>
    /// <br>note			:	仕入在庫関連の設定を行います。
    ///							IMasterMaintenanceSingleTypeを実装しています。</br>              
    /// <br>Programmer : 19018 Y.Gamoto</br>
    /// <br>Date       : 2005.04.13</br>
    /// <br>Update Note: 2005.06.13 22035 三橋  弘憲</br>
    /// <br>           : ①税率有効日１の位置変更（プロパティのみ変更）</br>
    /// <br>           : ②各数値項目を右詰め（プロパティのみ変更）</br>
    /// <br>           : ③ステータスバーの色変更（プロパティのみ変更）</br>
    /// <br>Update Note: 2005.06.17 22035 三橋  弘憲</br>
    /// <br>           : 初期フォーカスの項目を全選択されるように変更</br>
    /// <br>Update Note: 2005.06.21 22035 三橋  弘憲</br>
    /// <br>           : ①消費税率に.1と打った場合0.1と表示させる修正</br>
    /// <br>           : ②データビューの未設定を空白で表示させる修正</br>
    /// <br>           : ③数値型Editの先頭に０が保存されないように修正（プロパティのみ変更）</br>
    /// <br>Update Note: 2005.06.22 22035 三橋  弘憲</br>
    /// <br>           : コンボボックス消費税端数処理の表示項目数を変更（プロパティのみ変更）</br>
    /// <br>Update Note: 2005.06.24 22035 三橋  弘憲</br>
    /// <br>           : TNeditのプロパティ設定統一化（プロパティのみ変更）</br>
    /// <br>Update Note: 2005.06.30 22035 三橋　弘憲</br>
    /// <br>           : tDateEditとtComboEditorのImeModeをDisableに変更（プロパティのみ変更）</br>
    /// <br>Update Note: 2005.07.04 22035 三橋  弘憲</br>
    /// <br>           : フレームの最小化対応改良</br> 
    /// <br>Update Note: 2005.07.06 22035 三橋　弘憲</br>
    /// <br>           : 排他制御対応</br>
    /// <br>Update Note: 2005.07.12 22035 三橋　弘憲</br>
    /// <br>           : ステータスバーを最前面へ変更</br> 
    /// <br>           : 排他制御のコメント変更</br>
    /// <br>Update Note: 2005.09.09 23003 enokida</br>
    /// <br>           : ログイン情報取得対応</br>
    /// <br>Update Note: 2005.09.17 23003 enokida</br>
    /// <br>           : Message部品対応</br>
    /// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
    /// <br>		     : ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br>Update Note: 2006.06.09 22023 土田　都</br> 
    /// <br>           : 「総額表示方法区分」追加</br>
    /// <br>Update Note: 2006.07.04 23003 榎田</br>
    /// <br>           : タブオーダーの変更</br>
    /// <br>Update Note: 2006.07.15 23003 榎田</br>
    /// <br>           : 税率有効日を西暦に変更</br>
    /// <br>Update Note: 2006.12.20 20031 古賀</br>
    /// <br>           : 携帯システム用に項目を追加</br>
    /// <br>Update Note: 2007.04.02 20031 古賀</br>
    /// <br>           : 消費税率にDouble桁数分登録できてしまう障害を修正</br>
    /// <br>Update Note: 2007.06.12 30005 木建　翼</br>
    /// <br>           : 「仕入価格取得単位区分」追加</br>
    /// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
    /// <br>			   自動支払関連項目追加</br>
    /// <br>Update Note: 2008.02.27 20081 疋田 勇人</br>
    /// <br>			   入出荷数区分２を追加</br>
    /// <br>UpdateNote : 2008/06/04 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>    
    /// <br>UpdateNote : 2008/07/22 30415 柴田 倫幸</br>
    /// <br>        	 ・項目の削除による修正</br>    
    /// <br>UpdateNote : 2008/09/12 30452 上野 俊治</br>
    /// <br>        	 ・在庫検索区分の追加</br>  
    /// <br>UpdateNote : 2008/09/29       照田 貴志</br>
    /// <br>        	 ・バグ修正、仕様変更対応</br>  
    /// <br>UpdateNote   : 2008/10/08 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/10/10 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote : 2008.12.01 30365 宮津 銀次郎</br>
    /// <br>        	 仕様変更で無くなった返品項目に関わる修正。</br>  
    /// <br>UpdateNote : 2009/06/25       照田 貴志</br>  
    /// <br>        	 不具合対応[13589]</br>  
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// </remarks>
    public class SFSIR09000UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Private Members (Component)
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TEdit StockDiscountName_tEdit;
        private Infragistics.Win.Misc.UltraLabel StockDiscountName_Title_Label;
        private TComboEditor DtlNoteDispDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DtlNoteDispDiv_Title_Label;
        private TComboEditor UnitPriceInpDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UnitPriceInpDiv_Title_Label;
        private TComboEditor ListPriceInpDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ListPriceInpDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel AutoPayMoneyKindCode_Label;
        private Infragistics.Win.Misc.UltraLabel AutoPayMoneyKindDiv_Label;
        private TEdit AutoPayMoneyKindDivNm_tEdit;
        private TComboEditor AutoPayMoneyKindCode_tComboEditor;
        private TNedit AutoPayMoneyKindDiv_tNedit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PriceCheckDivCd_Title_Label;
        private TComboEditor PriceCheckDivCd_tComboEditor;
        private TComboEditor AutoEntryGoodsDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoEntryGoodsDivCd_Title_Label;
        private TComboEditor PaySlipDateAmbit_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PaySlipDateAmbit_Title_Label;
        private TComboEditor PaySlipDateClrDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PaySlipDateClrDiv_Title_Label;
        private TComboEditor AutoPayment_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoPayment_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SlipDateClrDivCd_Title_Label;
        private TComboEditor SlipDateClrDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel SectDspDivCd_Title_Label;
        private TComboEditor SectDspDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PriceCostUpdtDiv_Title_Label;
        private TComboEditor PriceCostUpdtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel StockUnitChgDivCd_Title_Label;
        private TComboEditor StockUnitChgDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private DataSet Bind_DataSet;
        private TComboEditor StockSearchDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel StockSearchDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel GoodsNmReDispDivCd_Title_Label;
        private TComboEditor GoodsNmReDispDivCd_tComboEditor;
        private System.ComponentModel.IContainer components;
        # endregion

        # region Constructor
        /// <summary>
        /// SFSIR09000UAコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>note			:	仕入在庫全体設定クラス、仕入在庫全体設定アクセスクラスを生成します。
        ///							フレーム画面の印刷ボタン非表示設定を行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        public SFSIR09000UA()
        {
            InitializeComponent();

            // --- DEL 2008/06/05 -------------------------------->>>>>
            #region 削除コード
            //// autoliaSetクラスアクセスクラス
            //this.stockTtlStAcs = new StockTtlStAcs();

            //// autoliaSetクラス
            //this.stockTtlSet = new StockTtlSt();

            //// 2005.09.09 enokida ADD ログイン情報取得対応 >>>>>>>>>>>>>>>>> START
            ////　企業コードを取得する
            //this.enterPriseCode = LoginInfoAcquisition.EnterpriseCode;
            //// 2005.09.09 enokida ADD ログイン情報取得対応 <<<<<<<<<<<<<<<<< END

            //// 印刷可能フラグを設定します。
            //// Frameの印刷ボタンの表示非表示の制御に使用します。
            //_canPrint = false;
            #endregion
            // --- DEL 2008/06/05 --------------------------------<<<<< 

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値
            this._canClose = false;	                    // 閉じる機能（デフォルトtrue固定）
            this._canDelete = true;		                // 削除機能
            this._canLogicalDeleteDataExtraction = true;	// 論理削除データ表示機能
            this._canNew = true;		                    // 新規作成機能
            this._canPrint = false;	                    // 印刷機能
            this._canSpecificationSearch = false;	        // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	    // 列サイズ自動調整機能

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;	// 企業コード

            // 初期化
            this._dataIndex = -1;
            this._stockTtlStAcs = new StockTtlStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._stockTtlStTable = new Hashtable();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // 拠点ガイドのフォーカス制御
            // DEL 2008/10/08 不具合対応[6394] ---------->>>>>
            //_sectionGuideController = new GeneralGuideUIController(
            //    this.tEdit_SectionCodeAllowZero,
            //    this.SectionGd_ultraButton,
            //    this.RgdsSlipPrtDiv_tComboEditor
            //);
            // DEL 2008/10/08 不具合対応[6394] ----------<<<<<
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<
        }
        # endregion

        # region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        # endregion

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR09000UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.StockDiscountName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockDiscountName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ListPriceInpDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ListPriceInpDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UnitPriceInpDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UnitPriceInpDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DtlNoteDispDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DtlNoteDispDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AutoPayMoneyKindCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AutoPayMoneyKindDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AutoPayMoneyKindDivNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AutoPayMoneyKindCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoPayMoneyKindDiv_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PriceCheckDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PriceCheckDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockUnitChgDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockUnitChgDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PriceCostUpdtDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PriceCostUpdtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SectDspDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectDspDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SlipDateClrDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SlipDateClrDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoEntryGoodsDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoEntryGoodsDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PaySlipDateAmbit_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PaySlipDateAmbit_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PaySlipDateClrDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PaySlipDateClrDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AutoPayment_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoPayment_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.StockSearchDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockSearchDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.GoodsNmReDispDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.GoodsNmReDispDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.StockDiscountName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceInpDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceInpDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlNoteDispDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindDivNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindDiv_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceCheckDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitChgDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceCostUpdtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectDspDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDateClrDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoEntryGoodsDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipDateAmbit_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipDateClrDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayment_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSearchDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNmReDispDivCd_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(616, 394);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 27;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(741, 394);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 28;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 444);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(877, 23);
            this.ultraStatusBar1.TabIndex = 51;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // StockDiscountName_tEdit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockDiscountName_tEdit.ActiveAppearance = appearance48;
            this.StockDiscountName_tEdit.AutoSelect = true;
            this.StockDiscountName_tEdit.DataText = "";
            this.StockDiscountName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockDiscountName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.StockDiscountName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.StockDiscountName_tEdit.Location = new System.Drawing.Point(143, 351);
            this.StockDiscountName_tEdit.MaxLength = 30;
            this.StockDiscountName_tEdit.Name = "StockDiscountName_tEdit";
            this.StockDiscountName_tEdit.Size = new System.Drawing.Size(422, 24);
            this.StockDiscountName_tEdit.TabIndex = 21;
            // 
            // StockDiscountName_Title_Label
            // 
            this.StockDiscountName_Title_Label.Location = new System.Drawing.Point(24, 354);
            this.StockDiscountName_Title_Label.Name = "StockDiscountName_Title_Label";
            this.StockDiscountName_Title_Label.Size = new System.Drawing.Size(125, 14);
            this.StockDiscountName_Title_Label.TabIndex = 84;
            this.StockDiscountName_Title_Label.Text = "値引名";
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(12, 88);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(860, 3);
            this.ultraLabel15.TabIndex = 120;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel6.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel6.Location = new System.Drawing.Point(11, 322);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(860, 3);
            this.ultraLabel6.TabIndex = 121;
            // 
            // Mode_Label
            // 
            appearance49.ForeColor = System.Drawing.Color.White;
            appearance49.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance49.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance49;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance50.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance50.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance50.TextHAlignAsString = "Center";
            appearance50.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance50;
            this.Mode_Label.Location = new System.Drawing.Point(740, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 122;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ListPriceInpDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPriceInpDiv_tComboEditor.ActiveAppearance = appearance58;
            this.ListPriceInpDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ListPriceInpDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPriceInpDiv_tComboEditor.ItemAppearance = appearance59;
            this.ListPriceInpDiv_tComboEditor.Location = new System.Drawing.Point(195, 106);
            this.ListPriceInpDiv_tComboEditor.Name = "ListPriceInpDiv_tComboEditor";
            this.ListPriceInpDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.ListPriceInpDiv_tComboEditor.TabIndex = 3;
            // 
            // ListPriceInpDiv_Title_Label
            // 
            this.ListPriceInpDiv_Title_Label.Location = new System.Drawing.Point(24, 106);
            this.ListPriceInpDiv_Title_Label.Name = "ListPriceInpDiv_Title_Label";
            this.ListPriceInpDiv_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.ListPriceInpDiv_Title_Label.TabIndex = 150;
            this.ListPriceInpDiv_Title_Label.Text = "価格入力区分";
            // 
            // UnitPriceInpDiv_tComboEditor
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnitPriceInpDiv_tComboEditor.ActiveAppearance = appearance56;
            this.UnitPriceInpDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UnitPriceInpDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnitPriceInpDiv_tComboEditor.ItemAppearance = appearance57;
            this.UnitPriceInpDiv_tComboEditor.Location = new System.Drawing.Point(195, 136);
            this.UnitPriceInpDiv_tComboEditor.Name = "UnitPriceInpDiv_tComboEditor";
            this.UnitPriceInpDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.UnitPriceInpDiv_tComboEditor.TabIndex = 5;
            // 
            // UnitPriceInpDiv_Title_Label
            // 
            this.UnitPriceInpDiv_Title_Label.Location = new System.Drawing.Point(24, 136);
            this.UnitPriceInpDiv_Title_Label.Name = "UnitPriceInpDiv_Title_Label";
            this.UnitPriceInpDiv_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.UnitPriceInpDiv_Title_Label.TabIndex = 152;
            this.UnitPriceInpDiv_Title_Label.Text = "単価入力区分";
            // 
            // DtlNoteDispDiv_tComboEditor
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DtlNoteDispDiv_tComboEditor.ActiveAppearance = appearance11;
            this.DtlNoteDispDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DtlNoteDispDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DtlNoteDispDiv_tComboEditor.ItemAppearance = appearance12;
            this.DtlNoteDispDiv_tComboEditor.Location = new System.Drawing.Point(620, 106);
            this.DtlNoteDispDiv_tComboEditor.Name = "DtlNoteDispDiv_tComboEditor";
            this.DtlNoteDispDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.DtlNoteDispDiv_tComboEditor.TabIndex = 4;
            // 
            // DtlNoteDispDiv_Title_Label
            // 
            this.DtlNoteDispDiv_Title_Label.Location = new System.Drawing.Point(447, 106);
            this.DtlNoteDispDiv_Title_Label.Name = "DtlNoteDispDiv_Title_Label";
            this.DtlNoteDispDiv_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.DtlNoteDispDiv_Title_Label.TabIndex = 154;
            this.DtlNoteDispDiv_Title_Label.Text = "明細備考表示区分";
            // 
            // AutoPayMoneyKindCode_Label
            // 
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.AutoPayMoneyKindCode_Label.Appearance = appearance10;
            this.AutoPayMoneyKindCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AutoPayMoneyKindCode_Label.Location = new System.Drawing.Point(143, 331);
            this.AutoPayMoneyKindCode_Label.Name = "AutoPayMoneyKindCode_Label";
            this.AutoPayMoneyKindCode_Label.Size = new System.Drawing.Size(144, 23);
            this.AutoPayMoneyKindCode_Label.TabIndex = 155;
            this.AutoPayMoneyKindCode_Label.Text = "自動支払金種";
            this.AutoPayMoneyKindCode_Label.Visible = false;
            // 
            // AutoPayMoneyKindDiv_Label
            // 
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.AutoPayMoneyKindDiv_Label.Appearance = appearance9;
            this.AutoPayMoneyKindDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AutoPayMoneyKindDiv_Label.Location = new System.Drawing.Point(143, 361);
            this.AutoPayMoneyKindDiv_Label.Name = "AutoPayMoneyKindDiv_Label";
            this.AutoPayMoneyKindDiv_Label.Size = new System.Drawing.Size(144, 23);
            this.AutoPayMoneyKindDiv_Label.TabIndex = 156;
            this.AutoPayMoneyKindDiv_Label.Text = "自動支払金種区分";
            this.AutoPayMoneyKindDiv_Label.Visible = false;
            // 
            // AutoPayMoneyKindDivNm_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoPayMoneyKindDivNm_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.AutoPayMoneyKindDivNm_tEdit.Appearance = appearance8;
            this.AutoPayMoneyKindDivNm_tEdit.AutoSelect = true;
            this.AutoPayMoneyKindDivNm_tEdit.DataText = "";
            this.AutoPayMoneyKindDivNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AutoPayMoneyKindDivNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.AutoPayMoneyKindDivNm_tEdit.Location = new System.Drawing.Point(316, 365);
            this.AutoPayMoneyKindDivNm_tEdit.MaxLength = 2;
            this.AutoPayMoneyKindDivNm_tEdit.Name = "AutoPayMoneyKindDivNm_tEdit";
            this.AutoPayMoneyKindDivNm_tEdit.ReadOnly = true;
            this.AutoPayMoneyKindDivNm_tEdit.Size = new System.Drawing.Size(175, 24);
            this.AutoPayMoneyKindDivNm_tEdit.TabIndex = 12;
            this.AutoPayMoneyKindDivNm_tEdit.TabStop = false;
            this.AutoPayMoneyKindDivNm_tEdit.Visible = false;
            // 
            // AutoPayMoneyKindCode_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoPayMoneyKindCode_tComboEditor.ActiveAppearance = appearance5;
            this.AutoPayMoneyKindCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoPayMoneyKindCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoPayMoneyKindCode_tComboEditor.ItemAppearance = appearance6;
            this.AutoPayMoneyKindCode_tComboEditor.Location = new System.Drawing.Point(316, 335);
            this.AutoPayMoneyKindCode_tComboEditor.Name = "AutoPayMoneyKindCode_tComboEditor";
            this.AutoPayMoneyKindCode_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.AutoPayMoneyKindCode_tComboEditor.TabIndex = 10;
            this.AutoPayMoneyKindCode_tComboEditor.Visible = false;
            this.AutoPayMoneyKindCode_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.AutoPayMoneyKindCode_tComboEditor_SelectionChangeCommitted);
            // 
            // AutoPayMoneyKindDiv_tNedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.AutoPayMoneyKindDiv_tNedit.ActiveAppearance = appearance3;
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.AutoPayMoneyKindDiv_tNedit.Appearance = appearance4;
            this.AutoPayMoneyKindDiv_tNedit.AutoSelect = true;
            this.AutoPayMoneyKindDiv_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AutoPayMoneyKindDiv_tNedit.DataText = "";
            this.AutoPayMoneyKindDiv_tNedit.Enabled = false;
            this.AutoPayMoneyKindDiv_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AutoPayMoneyKindDiv_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 17, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.AutoPayMoneyKindDiv_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AutoPayMoneyKindDiv_tNedit.Location = new System.Drawing.Point(722, 337);
            this.AutoPayMoneyKindDiv_tNedit.MaxLength = 17;
            this.AutoPayMoneyKindDiv_tNedit.Name = "AutoPayMoneyKindDiv_tNedit";
            this.AutoPayMoneyKindDiv_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.AutoPayMoneyKindDiv_tNedit.ReadOnly = true;
            this.AutoPayMoneyKindDiv_tNedit.Size = new System.Drawing.Size(113, 24);
            this.AutoPayMoneyKindDiv_tNedit.TabIndex = 159;
            this.AutoPayMoneyKindDiv_tNedit.TabStop = false;
            this.AutoPayMoneyKindDiv_tNedit.Visible = false;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(317, 47);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 166;
            this.SectionNm_Label.Text = "※ゼロで共通設定になります";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(130, 47);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.SectionCd_tEdit_Leave);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(196, 47);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(165, 47);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(18, 48);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 162;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // PriceCheckDivCd_Title_Label
            // 
            this.PriceCheckDivCd_Title_Label.Location = new System.Drawing.Point(24, 166);
            this.PriceCheckDivCd_Title_Label.Name = "PriceCheckDivCd_Title_Label";
            this.PriceCheckDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.PriceCheckDivCd_Title_Label.TabIndex = 168;
            this.PriceCheckDivCd_Title_Label.Text = "価格チェック区分";
            // 
            // PriceCheckDivCd_tComboEditor
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriceCheckDivCd_tComboEditor.ActiveAppearance = appearance54;
            this.PriceCheckDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriceCheckDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriceCheckDivCd_tComboEditor.ItemAppearance = appearance55;
            this.PriceCheckDivCd_tComboEditor.Location = new System.Drawing.Point(195, 166);
            this.PriceCheckDivCd_tComboEditor.Name = "PriceCheckDivCd_tComboEditor";
            this.PriceCheckDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.PriceCheckDivCd_tComboEditor.TabIndex = 7;
            // 
            // StockUnitChgDivCd_Title_Label
            // 
            this.StockUnitChgDivCd_Title_Label.Location = new System.Drawing.Point(24, 196);
            this.StockUnitChgDivCd_Title_Label.Name = "StockUnitChgDivCd_Title_Label";
            this.StockUnitChgDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.StockUnitChgDivCd_Title_Label.TabIndex = 170;
            this.StockUnitChgDivCd_Title_Label.Text = "仕入単価チェック区分";
            // 
            // StockUnitChgDivCd_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockUnitChgDivCd_tComboEditor.ActiveAppearance = appearance46;
            this.StockUnitChgDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockUnitChgDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockUnitChgDivCd_tComboEditor.ItemAppearance = appearance47;
            this.StockUnitChgDivCd_tComboEditor.Location = new System.Drawing.Point(195, 196);
            this.StockUnitChgDivCd_tComboEditor.Name = "StockUnitChgDivCd_tComboEditor";
            this.StockUnitChgDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.StockUnitChgDivCd_tComboEditor.TabIndex = 9;
            // 
            // PriceCostUpdtDiv_Title_Label
            // 
            this.PriceCostUpdtDiv_Title_Label.Location = new System.Drawing.Point(24, 226);
            this.PriceCostUpdtDiv_Title_Label.Name = "PriceCostUpdtDiv_Title_Label";
            this.PriceCostUpdtDiv_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.PriceCostUpdtDiv_Title_Label.TabIndex = 172;
            this.PriceCostUpdtDiv_Title_Label.Text = "価格原価更新区分";
            // 
            // PriceCostUpdtDiv_tComboEditor
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriceCostUpdtDiv_tComboEditor.ActiveAppearance = appearance44;
            this.PriceCostUpdtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriceCostUpdtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriceCostUpdtDiv_tComboEditor.ItemAppearance = appearance45;
            this.PriceCostUpdtDiv_tComboEditor.Location = new System.Drawing.Point(195, 226);
            this.PriceCostUpdtDiv_tComboEditor.Name = "PriceCostUpdtDiv_tComboEditor";
            this.PriceCostUpdtDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.PriceCostUpdtDiv_tComboEditor.TabIndex = 11;
            // 
            // SectDspDivCd_Title_Label
            // 
            this.SectDspDivCd_Title_Label.Location = new System.Drawing.Point(24, 256);
            this.SectDspDivCd_Title_Label.Name = "SectDspDivCd_Title_Label";
            this.SectDspDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.SectDspDivCd_Title_Label.TabIndex = 174;
            this.SectDspDivCd_Title_Label.Text = "拠点表示区分";
            // 
            // SectDspDivCd_tComboEditor
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectDspDivCd_tComboEditor.ActiveAppearance = appearance24;
            this.SectDspDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SectDspDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectDspDivCd_tComboEditor.ItemAppearance = appearance25;
            this.SectDspDivCd_tComboEditor.Location = new System.Drawing.Point(195, 256);
            this.SectDspDivCd_tComboEditor.Name = "SectDspDivCd_tComboEditor";
            this.SectDspDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.SectDspDivCd_tComboEditor.TabIndex = 13;
            // 
            // SlipDateClrDivCd_Title_Label
            // 
            this.SlipDateClrDivCd_Title_Label.Location = new System.Drawing.Point(447, 226);
            this.SlipDateClrDivCd_Title_Label.Name = "SlipDateClrDivCd_Title_Label";
            this.SlipDateClrDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.SlipDateClrDivCd_Title_Label.TabIndex = 176;
            this.SlipDateClrDivCd_Title_Label.Text = "伝票日付クリア区分";
            // 
            // SlipDateClrDivCd_tComboEditor
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDateClrDivCd_tComboEditor.ActiveAppearance = appearance32;
            this.SlipDateClrDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SlipDateClrDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDateClrDivCd_tComboEditor.ItemAppearance = appearance41;
            this.SlipDateClrDivCd_tComboEditor.Location = new System.Drawing.Point(620, 226);
            this.SlipDateClrDivCd_tComboEditor.Name = "SlipDateClrDivCd_tComboEditor";
            this.SlipDateClrDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.SlipDateClrDivCd_tComboEditor.TabIndex = 12;
            // 
            // AutoEntryGoodsDivCd_tComboEditor
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoEntryGoodsDivCd_tComboEditor.ActiveAppearance = appearance13;
            this.AutoEntryGoodsDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoEntryGoodsDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoEntryGoodsDivCd_tComboEditor.ItemAppearance = appearance14;
            this.AutoEntryGoodsDivCd_tComboEditor.Location = new System.Drawing.Point(620, 256);
            this.AutoEntryGoodsDivCd_tComboEditor.Name = "AutoEntryGoodsDivCd_tComboEditor";
            this.AutoEntryGoodsDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.AutoEntryGoodsDivCd_tComboEditor.TabIndex = 14;
            // 
            // AutoEntryGoodsDivCd_Title_Label
            // 
            this.AutoEntryGoodsDivCd_Title_Label.Location = new System.Drawing.Point(447, 256);
            this.AutoEntryGoodsDivCd_Title_Label.Name = "AutoEntryGoodsDivCd_Title_Label";
            this.AutoEntryGoodsDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.AutoEntryGoodsDivCd_Title_Label.TabIndex = 184;
            this.AutoEntryGoodsDivCd_Title_Label.Text = "商品自動登録";
            // 
            // PaySlipDateAmbit_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PaySlipDateAmbit_tComboEditor.ActiveAppearance = appearance1;
            this.PaySlipDateAmbit_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PaySlipDateAmbit_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PaySlipDateAmbit_tComboEditor.ItemAppearance = appearance21;
            this.PaySlipDateAmbit_tComboEditor.Location = new System.Drawing.Point(620, 166);
            this.PaySlipDateAmbit_tComboEditor.Name = "PaySlipDateAmbit_tComboEditor";
            this.PaySlipDateAmbit_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.PaySlipDateAmbit_tComboEditor.TabIndex = 8;
            // 
            // PaySlipDateAmbit_Title_Label
            // 
            this.PaySlipDateAmbit_Title_Label.Location = new System.Drawing.Point(447, 166);
            this.PaySlipDateAmbit_Title_Label.Name = "PaySlipDateAmbit_Title_Label";
            this.PaySlipDateAmbit_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.PaySlipDateAmbit_Title_Label.TabIndex = 183;
            this.PaySlipDateAmbit_Title_Label.Text = "支払伝票日付範囲区分";
            // 
            // PaySlipDateClrDiv_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PaySlipDateClrDiv_tComboEditor.ActiveAppearance = appearance17;
            this.PaySlipDateClrDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PaySlipDateClrDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PaySlipDateClrDiv_tComboEditor.ItemAppearance = appearance18;
            this.PaySlipDateClrDiv_tComboEditor.Location = new System.Drawing.Point(620, 136);
            this.PaySlipDateClrDiv_tComboEditor.Name = "PaySlipDateClrDiv_tComboEditor";
            this.PaySlipDateClrDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.PaySlipDateClrDiv_tComboEditor.TabIndex = 6;
            // 
            // PaySlipDateClrDiv_Title_Label
            // 
            this.PaySlipDateClrDiv_Title_Label.Location = new System.Drawing.Point(447, 136);
            this.PaySlipDateClrDiv_Title_Label.Name = "PaySlipDateClrDiv_Title_Label";
            this.PaySlipDateClrDiv_Title_Label.Size = new System.Drawing.Size(178, 14);
            this.PaySlipDateClrDiv_Title_Label.TabIndex = 182;
            this.PaySlipDateClrDiv_Title_Label.Text = "支払伝票日付クリア区分";
            // 
            // AutoPayment_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoPayment_tComboEditor.ActiveAppearance = appearance19;
            this.AutoPayment_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoPayment_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoPayment_tComboEditor.ItemAppearance = appearance20;
            this.AutoPayment_tComboEditor.Location = new System.Drawing.Point(316, 395);
            this.AutoPayment_tComboEditor.Name = "AutoPayment_tComboEditor";
            this.AutoPayment_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.AutoPayment_tComboEditor.TabIndex = 14;
            this.AutoPayment_tComboEditor.Visible = false;
            // 
            // AutoPayment_Title_Label
            // 
            this.AutoPayment_Title_Label.Location = new System.Drawing.Point(143, 395);
            this.AutoPayment_Title_Label.Name = "AutoPayment_Title_Label";
            this.AutoPayment_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.AutoPayment_Title_Label.TabIndex = 181;
            this.AutoPayment_Title_Label.Text = "自動支払区分";
            this.AutoPayment_Title_Label.Visible = false;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(366, 394);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 25;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(491, 394);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 26;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // StockSearchDiv_Title_Label
            // 
            this.StockSearchDiv_Title_Label.Location = new System.Drawing.Point(447, 196);
            this.StockSearchDiv_Title_Label.Name = "StockSearchDiv_Title_Label";
            this.StockSearchDiv_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.StockSearchDiv_Title_Label.TabIndex = 185;
            this.StockSearchDiv_Title_Label.Text = "在庫検索区分";
            // 
            // StockSearchDiv_tComboEditor
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockSearchDiv_tComboEditor.ActiveAppearance = appearance15;
            this.StockSearchDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockSearchDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockSearchDiv_tComboEditor.ItemAppearance = appearance16;
            this.StockSearchDiv_tComboEditor.Location = new System.Drawing.Point(620, 196);
            this.StockSearchDiv_tComboEditor.Name = "StockSearchDiv_tComboEditor";
            this.StockSearchDiv_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.StockSearchDiv_tComboEditor.TabIndex = 10;
            // 
            // GoodsNmReDispDivCd_tComboEditor
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsNmReDispDivCd_tComboEditor.ActiveAppearance = appearance22;
            this.GoodsNmReDispDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GoodsNmReDispDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsNmReDispDivCd_tComboEditor.ItemAppearance = appearance23;
            this.GoodsNmReDispDivCd_tComboEditor.Location = new System.Drawing.Point(195, 286);
            this.GoodsNmReDispDivCd_tComboEditor.Name = "GoodsNmReDispDivCd_tComboEditor";
            this.GoodsNmReDispDivCd_tComboEditor.Size = new System.Drawing.Size(235, 24);
            this.GoodsNmReDispDivCd_tComboEditor.TabIndex = 15;
            // 
            // GoodsNmReDispDivCd_Title_Label
            // 
            this.GoodsNmReDispDivCd_Title_Label.Location = new System.Drawing.Point(24, 286);
            this.GoodsNmReDispDivCd_Title_Label.Name = "GoodsNmReDispDivCd_Title_Label";
            this.GoodsNmReDispDivCd_Title_Label.Size = new System.Drawing.Size(169, 14);
            this.GoodsNmReDispDivCd_Title_Label.TabIndex = 174;
            this.GoodsNmReDispDivCd_Title_Label.Text = "商品名再表示区分";
            // 
            // SFSIR09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(877, 467);
            this.Controls.Add(this.StockSearchDiv_tComboEditor);
            this.Controls.Add(this.StockSearchDiv_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.AutoEntryGoodsDivCd_tComboEditor);
            this.Controls.Add(this.AutoEntryGoodsDivCd_Title_Label);
            this.Controls.Add(this.PaySlipDateAmbit_tComboEditor);
            this.Controls.Add(this.PaySlipDateAmbit_Title_Label);
            this.Controls.Add(this.PaySlipDateClrDiv_tComboEditor);
            this.Controls.Add(this.PaySlipDateClrDiv_Title_Label);
            this.Controls.Add(this.SlipDateClrDivCd_Title_Label);
            this.Controls.Add(this.SlipDateClrDivCd_tComboEditor);
            this.Controls.Add(this.GoodsNmReDispDivCd_Title_Label);
            this.Controls.Add(this.SectDspDivCd_Title_Label);
            this.Controls.Add(this.GoodsNmReDispDivCd_tComboEditor);
            this.Controls.Add(this.SectDspDivCd_tComboEditor);
            this.Controls.Add(this.PriceCostUpdtDiv_Title_Label);
            this.Controls.Add(this.PriceCostUpdtDiv_tComboEditor);
            this.Controls.Add(this.StockUnitChgDivCd_Title_Label);
            this.Controls.Add(this.StockUnitChgDivCd_tComboEditor);
            this.Controls.Add(this.PriceCheckDivCd_Title_Label);
            this.Controls.Add(this.PriceCheckDivCd_tComboEditor);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.AutoPayMoneyKindDiv_tNedit);
            this.Controls.Add(this.DtlNoteDispDiv_tComboEditor);
            this.Controls.Add(this.DtlNoteDispDiv_Title_Label);
            this.Controls.Add(this.UnitPriceInpDiv_tComboEditor);
            this.Controls.Add(this.UnitPriceInpDiv_Title_Label);
            this.Controls.Add(this.ListPriceInpDiv_tComboEditor);
            this.Controls.Add(this.ListPriceInpDiv_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.StockDiscountName_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.StockDiscountName_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.AutoPayment_tComboEditor);
            this.Controls.Add(this.AutoPayment_Title_Label);
            this.Controls.Add(this.AutoPayMoneyKindCode_tComboEditor);
            this.Controls.Add(this.AutoPayMoneyKindDivNm_tEdit);
            this.Controls.Add(this.AutoPayMoneyKindDiv_Label);
            this.Controls.Add(this.AutoPayMoneyKindCode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFSIR09000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "仕入在庫全体設定";
            this.Load += new System.EventHandler(this.SFSIR09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFSIR09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFSIR09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.StockDiscountName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceInpDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceInpDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlNoteDispDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindDivNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayMoneyKindDiv_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceCheckDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitChgDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceCostUpdtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectDspDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDateClrDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoEntryGoodsDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipDateAmbit_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaySlipDateClrDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPayment_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSearchDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNmReDispDivCd_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /* --- DEL 2008/06/05 -------------------------------->>>>>
		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
           --- DEL 2008/06/05 --------------------------------<<<<< */

        #region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Private Members
        //private StockTtlSt stockTtlSet;  // DEL 2008/06/05

        // --- ADD 2008/06/05 -------------------------------->>>>>
        private StockTtlStAcs _stockTtlStAcs;	// 仕入在庫全体設定アクセスクラス
        private SecInfoAcs _secInfoAcs;         // 拠点マスタアクセスクラス
        private string _enterpriseCode;			// 企業コード
        private int _logicalDeleteMode;			// モード
        private Hashtable _stockTtlStTable;		// 仕入在庫全体設定テーブル

        // 比較用clone
        private StockTtlSt _stockTtlStClone;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /* --- DEL 2008/06/05 -------------------------------->>>>>
		private StockTtlStAcs stockTtlStAcs;
		private string enterPriseCode;
           --- DEL 2008/06/05 --------------------------------<<<<< */

        // --- ADD 2008/06/05 -------------------------------->>>>>
        private const string GUID_TITLE = "GUID";
        private const string STOCKTTLST_TABLE = "STOCKTTLST"; // テーブル名

        // プロパティ用
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string DELETE_DATE = "削除日";
        /* --- DEL 2008/09/29 タイトル変更の為 --------------->>>>>
        private const string SECTIONCODE_TITLE = "コード";
        private const string SECTIONNAME_TITLE = "拠点名称";
           --- DEL 2008/09/29 --------------------------------<<<<< */
        // --- ADD 2008/09/29 -------------------------------->>>>>
        private const string SECTIONCODE_TITLE = "拠点";
        private const string SECTIONNAME_TITLE = "拠点名";
        // --- ADD 2008/09/29 --------------------------------<<<<<

        //private const string PARTSUNITPRC_TITLE = "部品単価0区分";  // DEL 2008/06/05
        // DEL 2008/10/09 不具合対応[6395] ↓
        //private const string STOCKDISCOUNTNAME_TITLE = "値引名称";
        private const string STOCKDISCOUNTNAME_TITLE = "値引名";    // ADD 2008/10/09 不具合対応[6395]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
        //private const string RGDSSLIPPRTDIV_TITLE = "返品伝票発行区分";
        //private const string RGDSUNPRCPRTDIV_TITLE = "返品時単価印刷区分";
        //private const string RGDSZEROPRTDIV_TITLE = "返品時ゼロ円印刷区分";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL
        // --- DEL 2008/07/22 -------------------------------->>>>>
        //private const string IOGOODSCNTDIV_TITLE = "入出荷数区分";
        //private const string IOGOODSCNTDIV2_TITLE = "入出荷数区分2";
        // --- DEL 2008/07/22 --------------------------------<<<<< 
        // DEL 2008/10/08 不具合対応[6395] ↓
        //private const string PRICECHECKDIVCD_TITLE = "定価チェック区分";
        private const string PRICECHECKDIVCD_TITLE = "価格チェック区分";    // ADD 2008/10/08 不具合対応[6395]
        private const string STOCKUNITCHGDIVCD_TITLE = "仕入単価チェック区分";
        // DEL 2008/10/08 不具合対応[6395] ↓
        //private const string PRICECOSTUPDTDIV_TITLE = "定価原価更新区分";
        private const string PRICECOSTUPDTDIV_TITLE = "価格原価更新区分";   // ADD 2008/10/08 不具合対応[6395]
        private const string SECTDSPDIVCD_TITLE = "拠点表示区分";
        private const string SLIPDATECLRDIVCD_TITLE = "伝票日付クリア区分";
        // --- DEL 2008/07/22 -------------------------------->>>>>
        //private const string SUPPLIERFORMALINI_TITLE = "仕入形式初期値";
        //private const string SALESSLIPDTLCONF_TITLE = "売上明細確認";
        // --- DEL 2008/07/22 --------------------------------<<<<< 
        // DEL 2008/10/08 不具合対応[6395] ↓
        //private const string LISTPRICEINPDIV_TITLE = "定価入力区分";
        private const string LISTPRICEINPDIV_TITLE = "価格入力区分";    // ADD 2008/10/08 不具合対応[6395]
        private const string UNITPRICEINPDIV_TITLE = "単価入力区分";
        private const string DTLNOTEDISPDIV_TITLE = "明細備考表示区分";

        // DEL 2009/01/16 不具合対応[9694] ---------->>>>>
        //private const string AUTOPAYMONEYKINDCODE_TITLE = "自動支払金種";
        //private const string AUTOPAYMONEYKINDDIV_TITLE = "自動支払金種区分";
        //private const string AUTOPAYMENT_TITLE = "自動支払区分";
        // DEL 2009/01/16 不具合対応[9694] ----------<<<<<

        private const string PAYSLIPDATECLRDIV_TITLE = "支払伝票日付クリア区分";
        private const string PAYSLIPDATEAMBIT_TITLE = "支払伝票日付範囲区分";
        private const string AUTOENTRYGOODSDIVCD_TITLE = "商品自動登録";
        // --- ADD 2008/06/05 --------------------------------<<<<< 
        // --- ADD 2008/09/12 -------------------------------->>>>>
        private const string STOCKSEARCHDIV_TITLE = "在庫検索区分";
        // --- ADD 2008/09/12 --------------------------------<<<<<

        // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
        private const string GOODSNMREDISPDIVCD_TITLE = "商品名再表示区分";
        // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
        
        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        //2005.06.21 ②データビューの未設定を空白で表示させる修正　三橋 >>>>>START
        //private const string HTML_UNREGISTER = "未設定";
        private const string HTML_UNREGISTER = "";
        //2005.06.21 ②データビューの未設定を空白で表示させる修正　三橋 >>>>>END

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 消費税端数処理区分
        //private const string TAXFRACPROC_NON    = "処理しない";
        //private const string TAXFRACPROC_1CUT   = "下一桁切捨";
        //private const string TAXFRACPROC_1ROUND = "下一桁四捨五入";
        //private const string TAXFRACPROC_1RAISE = "下一桁切上";
        //private const string TAXFRACPROC_2CUT   = "下二桁切捨";
        //private const string TAXFRACPROC_2ROUND = "下二桁四捨五入";
        //private const string TAXFRACPROC_2RAISE = "下二桁切上";
        //private const string TAXFRACPROC_3CUT   = "下三桁切捨";
        //private const string TAXFRACPROC_3ROUND = "下三桁四捨五入";
        //private const string TAXFRACPROC_3RAISE = "下三桁切上";
        //private const string TAXFRACPROC_CUT    = "円未満切捨";
        //private const string TAXFRACPROC_ROUND  = "円未満四捨五入";
        //private const string TAXFRACPROC_RAISE  = "円未満切上";
        // 2007.06.12 added by T-Kidate
        //#region < 仕入価格取得単位区分 >
        //private const string SUPLPRICEACQCD_STOCKSEC = "仕入拠点単位";
        //private const string SUPLPRICEACQCD_SALESSEC = "計上拠点単位";
        //#endregion

        // 2006.06.09 tsuchida add 
        // 総額表示方法区分
        private const string TOTALAMOUNTDISPWAY_OK = "総額表示する（税込み）";
        private const string TOTALAMOUNTDISPWAY_NG = "総額表示しない（税抜き）";


        // 在庫自動登録
        //private const string AUTOENTRYSTOCK_OK  = "自動登録する";
        //private const string AUTOENTRYSTOCK_NG  = "自動登録しない";

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        // 部品単価0区分
        private const string PARTSUNITPRC_NONREFER = "提供データを参照しない";
        private const string PARTSUNITPRC_REFER = "提供データを参照する";
           --- DEL 2008/06/05 --------------------------------<<<<< */

        //仕入先消費税転嫁方式コード
        private const string SUPPCTAXLAYCD_SLIP = "伝票単位";
        private const string SUPPCTAXLAYCD_DETAIL = "明細単位";
        private const string SUPPCTAXLAYCD_REQUEST = "請求単位（請求先）";
        private const string SUPPCTAXLAYCD_CUSTOMER = "請求単位（得意先）";
        private const string SUPPCTAXLAYCD_EXEMPTION = "非課税";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
        ////返品伝票発行区分
        //private const string RGDSSLIPPRTDIV_0 = "しない";
        //private const string RGDSSLIPPRTDIV_1 = "する";

        ////返品時単価印刷区分
        //private const string RGDSUNPRCPRTDIV_0 = "する";
        //private const string RGDSUNPRCPRTDIV_1 = "しない";

        ////返品時ゼロ円印刷区分
        //private const string RGDSZEROPRTDIV_0 = "する";
        //private const string RGDSZEROPRTDIV_1 = "しない";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

        // --- DEL 2008/07/22 -------------------------------->>>>>
        //入出荷数区分
        //private const string IOGOODSCNTDIV_0 = "チェック無し";
        //private const string IOGOODSCNTDIV_1 = "警告";
        //private const string IOGOODSCNTDIV_2 = "警告＋再入力";

        ////仕入形式初期値
        //private const string SUPPLIERFORMALINI_0 = "仕入";
        //private const string SUPPLIERFORMALINI_1 = "入荷";

        ////売上明細確認
        //private const string SALESSLIPDTLCONF_0 = "任意";
        //private const string SALESSLIPDTLCONF_1 = "必須";
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        //定価入力区分
        private const string LISTPRICEINPDIV_0 = "可能";
        private const string LISTPRICEINPDIV_1 = "不可";

        //単価入力区分
        private const string UNITPRICEINPDIV_0 = "可能";
        private const string UNITPRICEINPDIV_1 = "不可";

        //明細備考表示区分
        private const string DTLNOTEDISPDIV_0 = "有り";
        private const string DTLNOTEDISPDIV_1 = "無し";

        // 仕入原価評価方法
        //private const string STCKCSTASSESWAY_LAST = "最終仕入原価法";
        //private const string STCKCSTASSESWAY_AVERAGE = "移動平均法";

        // --- ADD 2008/06/05 -------------------------------->>>>>
        //自動支払区分
        private const string AUTOPAYMENT_NOMAL = "通常支払";
        private const string AUTOPAYMENT_AUTO = "自動支払";

        //定価原価更新区分
        private const string PRICECOSTUPDTDIV_0 = "非更新";
        private const string PRICECOSTUPDTDIV_1 = "無条件更新";
        private const string PRICECOSTUPDTDIV_2 = "確認更新";

        //商品自動登録
        private const string AUTOENTRYGOODSDIVCD_0 = "なし";
        private const string AUTOENTRYGOODSDIVCD_1 = "あり";

        //定価チェック区分
        private const string PRICECHECKDIVCD_0 = "無視";
        private const string PRICECHECKDIVCD_1 = "再入力";
        private const string PRICECHECKDIVCD_2 = "警告MSG";

        //仕入単価チェック区分
        private const string STOCKUNITCHGDIVCD_0 = "無視";
        private const string STOCKUNITCHGDIVCD_1 = "再入力";
        private const string STOCKUNITCHGDIVCD_2 = "警告MSG";

        // 2009.02.04 30413 犬飼 区分もテキストを変更 >>>>>>START
        //拠点表示区分
        private const string SECTDSPDIVCD_0 = "標準";
        //private const string SECTDSPDIVCD_1 = "自社マスタ";
        //private const string SECTDSPDIVCD_2 = "表示無し";
        private const string SECTDSPDIVCD_1 = "自拠点";
        private const string SECTDSPDIVCD_2 = "入力不可";
        // 2009.02.04 30413 犬飼 区分もテキストを変更 <<<<<<END

        //伝票日付クリア区分
        private const string SLIPDATECLRDIVCD_SYSTEM = "システム日付";
        private const string SLIPDATECLRDIVCD_INPUT = "入力日付";

        //支払伝票日付クリア区分
        private const string PAYSLIPDATECLRDIV_SYSTEM = "システム日付に戻す";
        private const string PAYSLIPDATECLRDIV_INPUT = "入力日付のまま";

        //支払伝票日付範囲区分
        private const string PAYSLIPDATEAMBIT_0 = "制限なし";
        private const string PAYSLIPDATEAMBIT_1 = "システム日付以降入力不可";
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        // ---DEL 2009/06/25 不具合対応[13589] ----------------->>>>>
        //// --- ADD 2008/09/12 -------------------------------->>>>>
        //private const string StockSearchDiv_0 = "優先倉庫";
        //private const string StockSearchDiv_1 = "指定倉庫";
        //// --- ADD 2008/09/12 --------------------------------<<<<<
        // ---DEL 2009/06/25 不具合対応[13589] -----------------<<<<<
        // ---ADD 2009/06/25 不具合対応[13589] ----------------->>>>>
        private const string StockSearchDiv_0 = "優先倉庫も検索";
        private const string StockSearchDiv_1 = "指定した倉庫のみ";
        // ---ADD 2009/06/25 不具合対応[13589] -----------------<<<<<

        // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
        // 商品名再表示区分
        private const string GOODSNMREDISPDIVCD_0 = "しない";
        private const string GOODSNMREDISPDIVCD_1 = "する";
        // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
        
        // 未設定時に使用
        private const string UNREGISTER = "";

        // 最終有効日
        private const int LASTTAXDATE = 99991231;

        //2005.07.04 フレームの最小化対応改良　三橋>>>>>START		
        // 変更有無判定用
        //private StockTtlSt chkStockTtlSet = new StockTtlSt();
        //private StockTtlSt chkStockTtlSet;  // DEL 2008/06/05
        //2005.07.04 フレームの最小化対応改良　三橋<<<<<<END

        //2005.09.17 enokida ADD MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
        //string pgId = "SFSIR09000U";
        //string pgNm = "仕入在庫全体設定";
        //string obj = "StockTtlStAcs";
        //2005.09.17 enokida ADD MessageBox対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

        //----- ueno add---------- start 2008.02.18
        private int _autoPayMoneyKindCode_tComboEditorValue = -1;	// 自動支払金種コードコンボボックスデータワーク
        //----- ueno add---------- end 2008.02.18

        // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
        /// <summary>拠点ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// 拠点ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>拠点ガイドの制御オブジェクト</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<

        private bool isError = false; // ADD 2011/09/08

        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new SFSIR09000UA());
        }
        # endregion

        # region Properties
        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>新規作成可能設定プロパティ</summary>
        /// <value>新規作成が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        # endregion

        # region Public Methods
        /// <summary>
        ///	印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note			:	（未実装）</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE,
                new GridColAppearance(MGridColDispType.DeletionDataBoth,
                ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add(SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            /* --- DEL 2008/06/05 -------------------------------->>>>>
            // 部品単価0区分
            appearanceTable.Add(PARTSUNITPRC_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
           --- DEL 2008/06/05 --------------------------------<<<<< */

            // 仕入値引名称
            appearanceTable.Add(STOCKDISCOUNTNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //// 返品伝票発行区分
            //appearanceTable.Add(RGDSSLIPPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 返品時単価印刷区分
            //appearanceTable.Add(RGDSUNPRCPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 返品時ゼロ円印刷区分
            //appearanceTable.Add(RGDSZEROPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 入出荷数区分
            //appearanceTable.Add(IOGOODSCNTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 入出荷数区分2
            //appearanceTable.Add(IOGOODSCNTDIV2_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 定価チェック区分
            appearanceTable.Add(PRICECHECKDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 仕入単価チェック区分
            appearanceTable.Add(STOCKUNITCHGDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 定価原価更新区分
            appearanceTable.Add(PRICECOSTUPDTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点表示区分
            appearanceTable.Add(SECTDSPDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 伝票日付クリア区分
            appearanceTable.Add(SLIPDATECLRDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 仕入形式初期値
            //appearanceTable.Add(SUPPLIERFORMALINI_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 売上明細確認
            //appearanceTable.Add(SALESSLIPDTLCONF_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 定価入力区分
            appearanceTable.Add(LISTPRICEINPDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 単価入力区分
            appearanceTable.Add(UNITPRICEINPDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 明細備考表示区分
            appearanceTable.Add(DTLNOTEDISPDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // DEL 2009/01/16 不具合対応[9694] ---------->>>>>
            //// 自動支払金種
            //appearanceTable.Add(AUTOPAYMONEYKINDCODE_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 自動支払金種区分
            //appearanceTable.Add(AUTOPAYMONEYKINDDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));

            //// 自動支払区分
            //appearanceTable.Add(AUTOPAYMENT_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2009/01/16 不具合対応[9694] ----------<<<<<

            // 支払伝票日付クリア区分
            appearanceTable.Add(PAYSLIPDATECLRDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 支払伝票日付範囲区分
            appearanceTable.Add(PAYSLIPDATEAMBIT_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 商品自動登録
            appearanceTable.Add(AUTOENTRYGOODSDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
            // 商品名再表示区分
            appearanceTable.Add(GOODSNMREDISPDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
        
            // --- ADD 2008/09/12 -------------------------------->>>>>
            appearanceTable.Add(STOCKSEARCHDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = STOCKTTLST_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchStockTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        # endregion

        # region private Methods

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note			:	画面の初期設定を行います(ｺﾝﾎﾞﾎﾞｯｸｽに固定値ADD)</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // --- ADD 2008/06/05 -------------------------------->>>>>
            // ボタン配置
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);
            // --- ADD 2008/06/05 --------------------------------<<<<< 

            //端数処理区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
#if False
		ConsTaxFracProcDiv_tComboEditor.Items.Clear();
			ConsTaxFracProcDiv_tComboEditor.Items.Add(0,TAXFRACPROC_NON);
			ConsTaxFracProcDiv_tComboEditor.Items.Add(11,TAXFRACPROC_1CUT);
			ConsTaxFracProcDiv_tComboEditor.Items.Add(12,TAXFRACPROC_1ROUND);
			ConsTaxFracProcDiv_tComboEditor.Items.Add(13,TAXFRACPROC_1RAISE);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(21,TAXFRACPROC_2CUT);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(22,TAXFRACPROC_2ROUND);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(23,TAXFRACPROC_2RAISE);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(31,TAXFRACPROC_3CUT);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(32,TAXFRACPROC_3ROUND);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(33,TAXFRACPROC_3RAISE);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(-11,TAXFRACPROC_CUT);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(-12,TAXFRACPROC_ROUND);
            ConsTaxFracProcDiv_tComboEditor.Items.Add(-13,TAXFRACPROC_RAISE);
 			ConsTaxFracProcDiv_tComboEditor.MaxDropDownItems = ConsTaxFracProcDiv_tComboEditor.Items.Count;
#endif

            // 2006.06.09 tsuchida add
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            // 総額表示方法区分に情報セット
            TotalAmountDispWayCd_tComboEditor.Items.Clear();
            TotalAmountDispWayCd_tComboEditor.Items.Add(0, TOTALAMOUNTDISPWAY_NG);
            TotalAmountDispWayCd_tComboEditor.Items.Add(1, TOTALAMOUNTDISPWAY_OK);
            TotalAmountDispWayCd_tComboEditor.MaxDropDownItems = TotalAmountDispWayCd_tComboEditor.Items.Count;
               --- DEL 2008/06/05 --------------------------------<<<<< */

            //在庫自動登録のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //AutoEntryStockCd_tComboEditor.Items.Clear();
            //AutoEntryStockCd_tComboEditor.Items.Add(0,AUTOENTRYSTOCK_OK);
            //AutoEntryStockCd_tComboEditor.Items.Add(1,AUTOENTRYSTOCK_NG);
            //AutoEntryStockCd_tComboEditor.MaxDropDownItems = AutoEntryStockCd_tComboEditor.Items.Count;

            // --- DEL 2008/06/05 -------------------------------->>>>>
            ////部品単価0円区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //PartsUnitPrcZeroCd_tComboEditor.Items.Clear();
            //PartsUnitPrcZeroCd_tComboEditor.Items.Add(0,PARTSUNITPRC_NONREFER);
            //PartsUnitPrcZeroCd_tComboEditor.Items.Add(1,PARTSUNITPRC_REFER);
            //PartsUnitPrcZeroCd_tComboEditor.MaxDropDownItems = PartsUnitPrcZeroCd_tComboEditor.Items.Count;

            ////仕入先消費税転嫁方式コードのｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //SuppCTaxLayCd_tComboEditor.Items.Clear();
            //SuppCTaxLayCd_tComboEditor.Items.Add(0, SUPPCTAXLAYCD_SLIP);
            //SuppCTaxLayCd_tComboEditor.Items.Add(1, SUPPCTAXLAYCD_DETAIL);
            //SuppCTaxLayCd_tComboEditor.Items.Add(2, SUPPCTAXLAYCD_REQUEST);
            //SuppCTaxLayCd_tComboEditor.Items.Add(3, SUPPCTAXLAYCD_CUSTOMER);
            //SuppCTaxLayCd_tComboEditor.Items.Add(9, SUPPCTAXLAYCD_EXEMPTION);
            //SuppCTaxLayCd_tComboEditor.MaxDropDownItems = SuppCTaxLayCd_tComboEditor.Items.Count;
            // --- DEL 2008/06/05 --------------------------------<<<<< 

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>G.Miyatsu 2008.12.01 DEL
            ////返品伝票発行区分
            //RgdsSlipPrtDiv_tComboEditor.Items.Clear();
            //RgdsSlipPrtDiv_tComboEditor.Items.Add(0, RGDSSLIPPRTDIV_0);
            //RgdsSlipPrtDiv_tComboEditor.Items.Add(1, RGDSSLIPPRTDIV_1);
            //RgdsSlipPrtDiv_tComboEditor.MaxDropDownItems = RgdsSlipPrtDiv_tComboEditor.Items.Count;

            ////返品時単価印刷区分
            //RgdsUnPrcPrtDiv_tComboEditor.Items.Clear();
            //RgdsUnPrcPrtDiv_tComboEditor.Items.Add(0, RGDSUNPRCPRTDIV_0);
            //RgdsUnPrcPrtDiv_tComboEditor.Items.Add(1, RGDSUNPRCPRTDIV_1);
            //RgdsUnPrcPrtDiv_tComboEditor.MaxDropDownItems = RgdsUnPrcPrtDiv_tComboEditor.Items.Count;

            ////返品時ゼロ円印刷区分
            //RgdsZeroPrtDiv_tComboEditor.Items.Clear();
            //RgdsZeroPrtDiv_tComboEditor.Items.Add(0, RGDSZEROPRTDIV_0);
            //RgdsZeroPrtDiv_tComboEditor.Items.Add(1, RGDSZEROPRTDIV_1);
            //RgdsZeroPrtDiv_tComboEditor.MaxDropDownItems = RgdsZeroPrtDiv_tComboEditor.Items.Count;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //入出荷数区分
            //  IoGoodsCntDiv_tComboEditor.Items.Clear();
            //  IoGoodsCntDiv_tComboEditor.Items.Add(0, IOGOODSCNTDIV_0);
            //  IoGoodsCntDiv_tComboEditor.Items.Add(1, IOGOODSCNTDIV_1);
            //  IoGoodsCntDiv_tComboEditor.Items.Add(2, IOGOODSCNTDIV_2);
            //  IoGoodsCntDiv_tComboEditor.MaxDropDownItems = IoGoodsCntDiv_tComboEditor.Items.Count;

            //// 2008.02.27 add start ------------------------------------->>
            //  //入出荷数区分２
            //  IoGoodsCntDiv2_tComboEditor.Items.Clear();
            //  IoGoodsCntDiv2_tComboEditor.Items.Add(0, IOGOODSCNTDIV_0);
            //  IoGoodsCntDiv2_tComboEditor.Items.Add(1, IOGOODSCNTDIV_1);
            //  IoGoodsCntDiv2_tComboEditor.Items.Add(2, IOGOODSCNTDIV_2);
            //  IoGoodsCntDiv2_tComboEditor.MaxDropDownItems = IoGoodsCntDiv2_tComboEditor.Items.Count;
            //  // 2008.02.27 add end ---------------------------------------<<

            //  //仕入形式初期値
            //  SupplierFormalIni_tComboEditor.Items.Clear();
            //  SupplierFormalIni_tComboEditor.Items.Add(0, SUPPLIERFORMALINI_0);
            //  SupplierFormalIni_tComboEditor.Items.Add(1, SUPPLIERFORMALINI_1);
            //  SupplierFormalIni_tComboEditor.MaxDropDownItems = SupplierFormalIni_tComboEditor.Items.Count;

            //  //売上明細確認
            //  SalesSlipDtlConf_tComboEditor.Items.Clear();
            //  SalesSlipDtlConf_tComboEditor.Items.Add(0, SALESSLIPDTLCONF_0);
            //  SalesSlipDtlConf_tComboEditor.Items.Add(1, SALESSLIPDTLCONF_1);
            //  SalesSlipDtlConf_tComboEditor.MaxDropDownItems = SalesSlipDtlConf_tComboEditor.Items.Count;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            //定価入力区分
            ListPriceInpDiv_tComboEditor.Items.Clear();
            ListPriceInpDiv_tComboEditor.Items.Add(0, LISTPRICEINPDIV_0);
            ListPriceInpDiv_tComboEditor.Items.Add(1, LISTPRICEINPDIV_1);
            ListPriceInpDiv_tComboEditor.MaxDropDownItems = ListPriceInpDiv_tComboEditor.Items.Count;

            //単価入力区分
            UnitPriceInpDiv_tComboEditor.Items.Clear();
            UnitPriceInpDiv_tComboEditor.Items.Add(0, UNITPRICEINPDIV_0);
            UnitPriceInpDiv_tComboEditor.Items.Add(1, UNITPRICEINPDIV_1);
            UnitPriceInpDiv_tComboEditor.MaxDropDownItems = UnitPriceInpDiv_tComboEditor.Items.Count;

            //明細備考表示区分
            DtlNoteDispDiv_tComboEditor.Items.Clear();
            DtlNoteDispDiv_tComboEditor.Items.Add(0, DTLNOTEDISPDIV_0);
            DtlNoteDispDiv_tComboEditor.Items.Add(1, DTLNOTEDISPDIV_1);
            DtlNoteDispDiv_tComboEditor.MaxDropDownItems = DtlNoteDispDiv_tComboEditor.Items.Count;

            //----- ueno add---------- start 2008.02.18
            //--------------------------------
            // 自動支払金種コードコンボボックス設定
            //--------------------------------
            if (StockTtlSt._autoPayMoneyKindCodeList.Count > 0)
            {
                string wkValue = "";

                foreach (DictionaryEntry de in StockTtlSt._autoPayMoneyKindCodeList)
                {
                    wkValue = this._stockTtlStAcs.GetAutoPayMoneyKindName((int)de.Key);
                    this.AutoPayMoneyKindCode_tComboEditor.Items.Add(de.Key, wkValue);
                }
            }
            this.AutoPayMoneyKindCode_tComboEditor.MaxDropDownItems = this.AutoPayMoneyKindCode_tComboEditor.Items.Count;

            //// 自動支払金種初期値取得
            //int autoPayMoneyKindCodeFirst = 0;
            //if ((StockTtlSt._autoPayMoneyKindCodeList != null) && (StockTtlSt._autoPayMoneyKindCodeList.Count > 0))
            //{
            //    autoPayMoneyKindCodeFirst = (int)StockTtlSt._autoPayMoneyKindCodeList.GetKey(0);
            //}
            //this.AutoPayMoneyKindCode_tComboEditor.Value = autoPayMoneyKindCodeFirst;	// 自動支払金種コード

            //this.AutoPayMoneyKindDivNm_tEdit.Clear();			// 自動支払金種区分名称
            //this.AutoPayMoneyKindDiv_tNedit.Clear();			// 自動支払金種区分（隠し項目）

            //this._autoPayMoneyKindCode_tComboEditorValue = -1;	// 自動入金金種コードコンボボックスデータワーク
            //----- ueno add---------- end 2008.02.18

            // --- ADD 2008/06/05 -------------------------------->>>>>
            // 自動支払区分
            AutoPayment_tComboEditor.Items.Clear();
            AutoPayment_tComboEditor.Items.Add(0, AUTOPAYMENT_NOMAL);
            AutoPayment_tComboEditor.Items.Add(1, AUTOPAYMENT_AUTO);
            AutoPayment_tComboEditor.MaxDropDownItems = AutoPayment_tComboEditor.Items.Count;

            // 定価原価更新区分
            PriceCostUpdtDiv_tComboEditor.Items.Clear();
            PriceCostUpdtDiv_tComboEditor.Items.Add(0, PRICECOSTUPDTDIV_0);
            PriceCostUpdtDiv_tComboEditor.Items.Add(1, PRICECOSTUPDTDIV_1);
            PriceCostUpdtDiv_tComboEditor.Items.Add(2, PRICECOSTUPDTDIV_2);
            PriceCostUpdtDiv_tComboEditor.MaxDropDownItems = PriceCostUpdtDiv_tComboEditor.Items.Count;

            // 商品自動登録
            AutoEntryGoodsDivCd_tComboEditor.Items.Clear();
            AutoEntryGoodsDivCd_tComboEditor.Items.Add(0, AUTOENTRYGOODSDIVCD_0);
            AutoEntryGoodsDivCd_tComboEditor.Items.Add(1, AUTOENTRYGOODSDIVCD_1);
            AutoEntryGoodsDivCd_tComboEditor.MaxDropDownItems = AutoEntryGoodsDivCd_tComboEditor.Items.Count;

            // 定価チェック区分
            PriceCheckDivCd_tComboEditor.Items.Clear();
            PriceCheckDivCd_tComboEditor.Items.Add(0, PRICECHECKDIVCD_0);
            PriceCheckDivCd_tComboEditor.Items.Add(1, PRICECHECKDIVCD_1);
            PriceCheckDivCd_tComboEditor.Items.Add(2, PRICECHECKDIVCD_2);
            PriceCheckDivCd_tComboEditor.MaxDropDownItems = PriceCheckDivCd_tComboEditor.Items.Count;

            // 仕入単価チェック区分
            StockUnitChgDivCd_tComboEditor.Items.Clear();
            StockUnitChgDivCd_tComboEditor.Items.Add(0, STOCKUNITCHGDIVCD_0);
            StockUnitChgDivCd_tComboEditor.Items.Add(1, STOCKUNITCHGDIVCD_1);
            StockUnitChgDivCd_tComboEditor.Items.Add(2, STOCKUNITCHGDIVCD_2);
            StockUnitChgDivCd_tComboEditor.MaxDropDownItems = StockUnitChgDivCd_tComboEditor.Items.Count;

            // 拠点表示区分
            SectDspDivCd_tComboEditor.Items.Clear();
            SectDspDivCd_tComboEditor.Items.Add(0, SECTDSPDIVCD_0);
            SectDspDivCd_tComboEditor.Items.Add(1, SECTDSPDIVCD_1);
            SectDspDivCd_tComboEditor.Items.Add(2, SECTDSPDIVCD_2);
            SectDspDivCd_tComboEditor.MaxDropDownItems = SectDspDivCd_tComboEditor.Items.Count;

            // 伝票日付クリア区分
            SlipDateClrDivCd_tComboEditor.Items.Clear();
            SlipDateClrDivCd_tComboEditor.Items.Add(0, SLIPDATECLRDIVCD_SYSTEM);
            SlipDateClrDivCd_tComboEditor.Items.Add(1, SLIPDATECLRDIVCD_INPUT);
            SlipDateClrDivCd_tComboEditor.MaxDropDownItems = SlipDateClrDivCd_tComboEditor.Items.Count;

            // 支払伝票日付クリア区分
            PaySlipDateClrDiv_tComboEditor.Items.Clear();
            PaySlipDateClrDiv_tComboEditor.Items.Add(0, PAYSLIPDATECLRDIV_SYSTEM);
            PaySlipDateClrDiv_tComboEditor.Items.Add(1, PAYSLIPDATECLRDIV_INPUT);
            PaySlipDateClrDiv_tComboEditor.MaxDropDownItems = PaySlipDateClrDiv_tComboEditor.Items.Count;

            // 支払伝票日付範囲区分
            PaySlipDateAmbit_tComboEditor.Items.Clear();
            PaySlipDateAmbit_tComboEditor.Items.Add(0, PAYSLIPDATEAMBIT_0);
            PaySlipDateAmbit_tComboEditor.Items.Add(1, PAYSLIPDATEAMBIT_1);
            PaySlipDateAmbit_tComboEditor.MaxDropDownItems = PaySlipDateAmbit_tComboEditor.Items.Count;
            // --- ADD 2008/06/05 --------------------------------<<<<< 

            // --- ADD 2008/09/12 -------------------------------->>>>>
            // 在庫検索区分
            StockSearchDiv_tComboEditor.Items.Clear();
            StockSearchDiv_tComboEditor.Items.Add(0, StockSearchDiv_0);
            StockSearchDiv_tComboEditor.Items.Add(1, StockSearchDiv_1);
            StockSearchDiv_tComboEditor.MaxDropDownItems = PaySlipDateAmbit_tComboEditor.Items.Count;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
            GoodsNmReDispDivCd_tComboEditor.Items.Clear();
            GoodsNmReDispDivCd_tComboEditor.Items.Add(0, GOODSNMREDISPDIVCD_0);
            GoodsNmReDispDivCd_tComboEditor.Items.Add(1, GOODSNMREDISPDIVCD_1);
            GoodsNmReDispDivCd_tComboEditor.MaxDropDownItems = GoodsNmReDispDivCd_tComboEditor.Items.Count;
            // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
        }


        /// <summary>
        ///	画面情報⇒仕入在庫全体設定設定クラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note			:	画面情報から仕入在庫全体設定クラスにデータを
        ///							格納します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        //private void ScreenTostockTtlSet()  // DEL 2008/06/05
        private void ScreenToStockTtlSt(ref StockTtlSt stockTtlSt)
        {
            if (stockTtlSt == null)
            {
                // 新規の場合
                stockTtlSt = new StockTtlSt();
            }
            //---ヘッダ部--//
            stockTtlSt.EnterpriseCode = this._enterpriseCode;      //企業コード

            //---データ部--//
            #region 削除コード
            /* --- DEL 2008/06/05 -------------------------------->>>>>
          //仕入在庫全体設定管理コード（0固定)
          this.stockTtlSet.StockAllStMngCd = 0;

          //税率１
          if (this.ConsTaxRates1_tNedit.DataText != "")
          {
              //消費税率１
              this.stockTtlSet.ConsTaxRate1 = this.ConsTaxRates1_tNedit.GetValue() / 100;
          }
          else
          {
              this.stockTtlSet.ConsTaxRate1 = 0;
          }
          //税率有効日１
          this.stockTtlSet.ValidDtConsTaxRate1 = this.ValidDtConsTaxRate1_tDateEdit.GetDateTime();

          //税率２
          if (this.ConsTaxRates2_tNedit.DataText != "")
          {
              //消費税率２
              this.stockTtlSet.ConsTaxRate2 = this.ConsTaxRates2_tNedit.GetValue() / 100;
          }
          else
          {
              this.stockTtlSet.ConsTaxRate2 = 0;
          }
          //税率有効日２
          this.stockTtlSet.ValidDtConsTaxRate2 = this.ValidDtConsTaxRate2_tDateEdit.GetDateTime();

          //税率３
          if (this.ConsTaxRates3_tNedit.DataText != "")
          {
              //消費税率３
              this.stockTtlSet.ConsTaxRate3 = this.ConsTaxRates3_tNedit.GetValue() / 100;
          }
          else
          {
              this.stockTtlSet.ConsTaxRate3 = 0;
          }
          //税率有効日３
          this.stockTtlSet.ValidDtConsTaxRate3 = this.ValidDtConsTaxRate3_tDateEdit.GetDateTime();

          // 2006.06.09 tsuchida add
          //総額表示方法区分
          this.stockTtlSet.TotalAmountDispWayCd = this.TotalAmountDispWayCd_tComboEditor.SelectedIndex;
             --- DEL 2008/06/05 --------------------------------<<<<< */

            //最低在庫条件区分（未使用）
            //this.stockTtlSet.BeatStockCondCd = 0;
            //仕入値引名称
            stockTtlSt.StockDiscountName = this.StockDiscountName_tEdit.DataText;

            /* --- DEL 2008/06/05 -------------------------------->>>>>
            //部品単価0区分
            this.stockTtlSet.PartsUnitPrcZeroCd = this.PartsUnitPrcZeroCd_tComboEditor.SelectedIndex;
            //仕入先消費税転嫁方式コード
            this.stockTtlSet.SuppCTaxLayCd = (int)this.SuppCTaxLayCd_tComboEditor.SelectedItem.DataValue;
               --- DEL 2008/06/05 --------------------------------<<<<< */

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            ////返品伝票発行区分
            //stockTtlSt.RgdsSlipPrtDiv = (int)this.RgdsSlipPrtDiv_tComboEditor.SelectedItem.DataValue;
            ////返品時単価印刷区分
            //stockTtlSt.RgdsUnPrcPrtDiv = (int)this.RgdsUnPrcPrtDiv_tComboEditor.SelectedItem.DataValue;
            ////返品時ゼロ円印刷区分
            //stockTtlSt.RgdsZeroPrtDiv = (int)this.RgdsZeroPrtDiv_tComboEditor.SelectedItem.DataValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            ////入出荷数区分
            //stockTtlSt.IoGoodsCntDiv = (int)this.IoGoodsCntDiv_tComboEditor.SelectedItem.DataValue;
            ////入出荷数区分２
            //stockTtlSt.IoGoodsCntDiv2 = (int)this.IoGoodsCntDiv2_tComboEditor.SelectedItem.DataValue;    // 2008.02.27 add
            ////仕入形式初期値
            //stockTtlSt.SupplierFormalIni = (int)this.SupplierFormalIni_tComboEditor.SelectedItem.DataValue;
            ////売上明細確認
            //stockTtlSt.SalesSlipDtlConf = (int)this.SalesSlipDtlConf_tComboEditor.SelectedItem.DataValue;
            // --- DEL 2008/07/22 --------------------------------<<<<< 
            #endregion

            //定価入力区分
            stockTtlSt.ListPriceInpDiv = (int)this.ListPriceInpDiv_tComboEditor.SelectedItem.DataValue;
            //単価入力区分
            stockTtlSt.UnitPriceInpDiv = (int)this.UnitPriceInpDiv_tComboEditor.SelectedItem.DataValue;
            //明細備考表示区分
            stockTtlSt.DtlNoteDispDiv = (int)this.DtlNoteDispDiv_tComboEditor.SelectedItem.DataValue;

            //----- ueno add---------- start 2008.02.18
            // DEL 2009/01/21 不具合対応[10288] ---------->>>>>
            //// 自動入金金種コード
            //stockTtlSt.AutoPayMoneyKindCode = (int)this.AutoPayMoneyKindCode_tComboEditor.SelectedItem.DataValue;
            //// 自動入金金種名称
            //stockTtlSt.AutoPayMoneyKindName = this.AutoPayMoneyKindCode_tComboEditor.SelectedItem.DisplayText;
            // DEL 2009/01/21 不具合対応[10288] ----------<<<<<
            // 自動入金金種区分（隠し項目）
            stockTtlSt.AutoPayMoneyKindDiv = this.AutoPayMoneyKindDiv_tNedit.GetInt();
            //----- ueno add---------- end 2008.02.18

            // --- ADD 2008/06/05 -------------------------------->>>>>
            // 拠点コード
            stockTtlSt.SectionCode = tEdit_SectionCodeAllowZero2.Text;
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            // uiSetControlが""のとき"00"を設定するので、デフォルト値は"00"とする
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                stockTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<

            // 定価チェック区分
            stockTtlSt.PriceCheckDivCd = this.PriceCheckDivCd_tComboEditor.SelectedIndex;
            // 仕入単価チェック区分
            stockTtlSt.StockUnitChgDivCd = this.StockUnitChgDivCd_tComboEditor.SelectedIndex;
            // 定価原価更新区分
            stockTtlSt.PriceCostUpdtDiv = this.PriceCostUpdtDiv_tComboEditor.SelectedIndex;
            // 拠点表示区分
            stockTtlSt.SectDspDivCd = this.SectDspDivCd_tComboEditor.SelectedIndex;
            // 伝票日付クリア区分
            stockTtlSt.SlipDateClrDivCd = this.SlipDateClrDivCd_tComboEditor.SelectedIndex;
            // 自動支払区分
            stockTtlSt.AutoPayment = this.AutoPayment_tComboEditor.SelectedIndex;
            // 支払伝票日付クリア区分
            stockTtlSt.PaySlipDateClrDiv = this.PaySlipDateClrDiv_tComboEditor.SelectedIndex;
            // 支払伝票日付範囲区分
            stockTtlSt.PaySlipDateAmbit = this.PaySlipDateAmbit_tComboEditor.SelectedIndex;
            // 商品自動登録
            stockTtlSt.AutoEntryGoodsDivCd = this.AutoEntryGoodsDivCd_tComboEditor.SelectedIndex;
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            // --- ADD 2008/09/12 -------------------------------->>>>>
            // 在庫検索区分
            stockTtlSt.StockSearchDiv = this.StockSearchDiv_tComboEditor.SelectedIndex;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            // 商品名再表示区分
            stockTtlSt.GoodsNmReDispDivCd = this.GoodsNmReDispDivCd_tComboEditor.SelectedIndex;
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        }

        /* --- DEL 2008/06/05 -------------------------------->>>>>
    /// <summary>
    ///	仕入在庫全体設定画面展開処理
    /// </summary>
    /// <remarks>
    /// <br>Note	   : 仕入在庫全体設定クラスから画面にデータを展開します。</br>
    /// <br>Programmer : 19018 Y.Gamoto</br>
    /// <br>Date       : 2005.04.13</br>
    /// <br>Note	   : 「仕入価格取得単位区分」追加。</br>
    /// <br>Programmer : 30005 木建　翼</br>
    /// <br>Date       : 2007.06.12</br>
    /// </remarks>
      private void stockTtlSetToScreen()
      {
          this.ConsTaxRates1_tNedit.SetValue(this.stockTtlSet.ConsTaxRate1 * 100);
          this.ConsTaxRates2_tNedit.SetValue(this.stockTtlSet.ConsTaxRate2 * 100);
          this.ConsTaxRates3_tNedit.SetValue(this.stockTtlSet.ConsTaxRate3 * 100);

          if (this.stockTtlSet.ValidDtConsTaxRate1 != DateTime.MinValue)
          {
              this.ValidDtConsTaxRate1_tDateEdit.SetDateTime(this.stockTtlSet.ValidDtConsTaxRate1);
          }
          else
          {
              this.ValidDtConsTaxRate1_tDateEdit.Clear();
          }

          if (this.stockTtlSet.ValidDtConsTaxRate2 != DateTime.MinValue)
          {
              this.ValidDtConsTaxRate2_tDateEdit.SetDateTime(this.stockTtlSet.ValidDtConsTaxRate2);
          }
          else
          {
              this.ValidDtConsTaxRate2_tDateEdit.Clear();
          }

          if (this.stockTtlSet.ValidDtConsTaxRate3 != DateTime.MinValue)
          {
              this.ValidDtConsTaxRate3_tDateEdit.SetDateTime(this.stockTtlSet.ValidDtConsTaxRate3);
          }
          else
          {
              this.ValidDtConsTaxRate3_tDateEdit.Clear();
          }

          //2006.06.09 tsuchida add
          this.TotalAmountDispWayCd_tComboEditor.Value = this.stockTtlSet.TotalAmountDispWayCd;

          //this.AutoEntryStockCd_tComboEditor.SelectedIndex = this.stockTtlSet.AutoEntryStockCd;
          this.PartsUnitPrcZeroCd_tComboEditor.Value = this.stockTtlSet.PartsUnitPrcZeroCd;
          this.StockDiscountName_tEdit.DataText = this.stockTtlSet.StockDiscountName;
          this.SuppCTaxLayCd_tComboEditor.Value = this.stockTtlSet.SuppCTaxLayCd;


          this.RgdsSlipPrtDiv_tComboEditor.Value = this.stockTtlSet.RgdsSlipPrtDiv;
          this.RgdsUnPrcPrtDiv_tComboEditor.Value = this.stockTtlSet.RgdsUnPrcPrtDiv;
          this.RgdsZeroPrtDiv_tComboEditor.Value = this.stockTtlSet.RgdsZeroPrtDiv;
          this.IoGoodsCntDiv_tComboEditor.Value = this.stockTtlSet.IoGoodsCntDiv;
          this.IoGoodsCntDiv2_tComboEditor.Value = this.stockTtlSet.IoGoodsCntDiv2;        // 2008.02.27 add
          this.SupplierFormalIni_tComboEditor.Value = this.stockTtlSet.SupplierFormalIni;
          this.SalesSlipDtlConf_tComboEditor.Value = this.stockTtlSet.SalesSlipDtlConf;
          this.ListPriceInpDiv_tComboEditor.Value = this.stockTtlSet.ListPriceInpDiv;
          this.UnitPriceInpDiv_tComboEditor.Value = this.stockTtlSet.UnitPriceInpDiv;
          this.DtlNoteDispDiv_tComboEditor.Value = this.stockTtlSet.DtlNoteDispDiv;

          //----- ueno add---------- start 2008.02.18
          this.AutoPayMoneyKindCode_tComboEditor.Value = this.stockTtlSet.AutoPayMoneyKindCode;
          this.AutoPayMoneyKindDiv_tNedit.SetInt(this.stockTtlSet.AutoPayMoneyKindDiv);

          if (this.AutoPayMoneyKindCode_tComboEditor.Value != null)
          {
              AutoPayMoneyKindCodeVisibleChange((Int32)this.AutoPayMoneyKindCode_tComboEditor.Value);			// 自動入金金種名称設定
          }
          //----- ueno add---------- end 2008.02.18
      }
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>
        ///	仕入在庫全体設定画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 仕入在庫全体設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void StockTtlStToScreen(StockTtlSt stockTtlSt)
        {
            // 拠点コード
            tEdit_SectionCodeAllowZero2.Value = stockTtlSt.SectionCode.Trim();
            // --- ADD 2008/09/29 ------------------------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text == "00")
            {
                // DEL 2008/10/10 不具合対応[6530] ↓
                //this.SectionNm_tEdit.Value = "全社設定";
                this.SectionNm_tEdit.Value = "全社共通";    // ADD 2008/10/10 不具合対応[6530]
            }
            else
            {
                // --- ADD 2008/09/29 -------------------------------------------<<<<<
                // 拠点名称
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == stockTtlSt.SectionCode.TrimEnd())
                    {
                        this.SectionNm_tEdit.Value = si.SectionGuideNm;
                        break;
                    }
                }
            }       //ADD 2008/09/29

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //this.StockDiscountName_tEdit.DataText = stockTtlSt.StockDiscountName;
            //this.RgdsSlipPrtDiv_tComboEditor.Value = stockTtlSt.RgdsSlipPrtDiv;
            //this.RgdsUnPrcPrtDiv_tComboEditor.Value = stockTtlSt.RgdsUnPrcPrtDiv;
            //this.RgdsZeroPrtDiv_tComboEditor.Value = stockTtlSt.RgdsZeroPrtDiv;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.Value = stockTtlSt.IoGoodsCntDiv;
            //this.IoGoodsCntDiv2_tComboEditor.Value = stockTtlSt.IoGoodsCntDiv2;
            //this.SupplierFormalIni_tComboEditor.Value = stockTtlSt.SupplierFormalIni;
            //this.SalesSlipDtlConf_tComboEditor.Value = stockTtlSt.SalesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            this.ListPriceInpDiv_tComboEditor.Value = stockTtlSt.ListPriceInpDiv;
            this.UnitPriceInpDiv_tComboEditor.Value = stockTtlSt.UnitPriceInpDiv;
            this.DtlNoteDispDiv_tComboEditor.Value = stockTtlSt.DtlNoteDispDiv;
            // DEL 2009/01/21 不具合対応[10288] ↓不具合対応[10288]
            //this.AutoPayMoneyKindCode_tComboEditor.Value = stockTtlSt.AutoPayMoneyKindCode;
            this.AutoPayMoneyKindDiv_tNedit.SetInt(stockTtlSt.AutoPayMoneyKindDiv);
            // DEL 2009/01/21 不具合対応[10288] ---------->>>>>
            //if (this.AutoPayMoneyKindCode_tComboEditor.Value != null)
            //{
            //    // 自動入金金種名称設定
            //    AutoPayMoneyKindCodeVisibleChange((Int32)this.AutoPayMoneyKindCode_tComboEditor.Value);			
            //}
            // DEL 2009/01/21 不具合対応[10288] ----------<<<<<

            this.PriceCheckDivCd_tComboEditor.SelectedIndex = stockTtlSt.PriceCheckDivCd;         // 定価チェック区分
            this.StockUnitChgDivCd_tComboEditor.SelectedIndex = stockTtlSt.StockUnitChgDivCd;     // 仕入単価チェック区分
            this.PriceCostUpdtDiv_tComboEditor.SelectedIndex = stockTtlSt.PriceCostUpdtDiv;       // 定価原価更新区分
            this.SectDspDivCd_tComboEditor.SelectedIndex = stockTtlSt.SectDspDivCd;               // 拠点表示区分
            this.SlipDateClrDivCd_tComboEditor.SelectedIndex = stockTtlSt.SlipDateClrDivCd;       // 伝票日付クリア区分
            this.AutoPayment_tComboEditor.SelectedIndex = stockTtlSt.AutoPayment;                 // 自動支払区分
            this.PaySlipDateClrDiv_tComboEditor.SelectedIndex = stockTtlSt.PaySlipDateClrDiv;     // 支払伝票日付クリア区分
            this.PaySlipDateAmbit_tComboEditor.SelectedIndex = stockTtlSt.PaySlipDateAmbit;       // 支払伝票日付範囲区分
            this.AutoEntryGoodsDivCd_tComboEditor.SelectedIndex = stockTtlSt.AutoEntryGoodsDivCd; // 商品自動登録
            // --- ADD 2008/09/12 -------------------------------->>>>>
            this.StockSearchDiv_tComboEditor.SelectedIndex = stockTtlSt.StockSearchDiv;           // 在庫検索区分
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            this.GoodsNmReDispDivCd_tComboEditor.SelectedIndex = stockTtlSt.GoodsNmReDispDivCd;     // 商品名再表示区分
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
            
            // 値引き名称
            this.StockDiscountName_tEdit.Text = stockTtlSt.StockDiscountName;   // ADD 2009/01/21 不具合対応[10288]
        }

        /// <summary>
        ///	仕入在庫全体設定画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note			:	画面情報を初期化します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void ScreenClear()
        {
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            this.ConsTaxRates1_tNedit.Clear();
            this.ConsTaxRates2_tNedit.Clear();
            this.ConsTaxRates3_tNedit.Clear();
            this.ValidDtConsTaxRate1_tDateEdit.Clear();
            this.ValidDtConsTaxRate2_tDateEdit.Clear();
            this.ValidDtConsTaxRate3_tDateEdit.Clear();
               --- DEL 2008/06/05 --------------------------------<<<<< */
#if False
		  this.ConsTaxFracProcDiv_tComboEditor.Value = 0;
#endif
            // 2006.06.09 tsuchida add
            //this.TotalAmountDispWayCd_tComboEditor.Value = 0;  // DEL 2008/06/05

            //this.AutoEntryStockCd_tComboEditor.SelectedIndex = 0;
            //this.SuppCTaxLayCd_tComboEditor.SelectedIndex = 0;  // DEL 2008/06/05

            this.StockDiscountName_tEdit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //this.RgdsSlipPrtDiv_tComboEditor.SelectedIndex = 0;
            //this.RgdsUnPrcPrtDiv_tComboEditor.SelectedIndex = 0;
            //this.RgdsZeroPrtDiv_tComboEditor.SelectedIndex = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.IoGoodsCntDiv_tComboEditor.SelectedIndex = 0;
            //this.IoGoodsCntDiv2_tComboEditor.SelectedIndex = 0;    // 2008.02.27 add
            //this.SupplierFormalIni_tComboEditor.SelectedIndex = 0;
            //this.SalesSlipDtlConf_tComboEditor.SelectedIndex = 0;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            this.ListPriceInpDiv_tComboEditor.SelectedIndex = 0;
            this.UnitPriceInpDiv_tComboEditor.SelectedIndex = 0;
            this.DtlNoteDispDiv_tComboEditor.SelectedIndex = 0;

            //----- ueno add---------- start 2008.02.18
            // 自動支払金種初期値取得
            int autoPayMoneyKindCodeFirst = 0;
            if ((StockTtlSt._autoPayMoneyKindCodeList != null) && (StockTtlSt._autoPayMoneyKindCodeList.Count > 0))
            {
                autoPayMoneyKindCodeFirst = (int)StockTtlSt._autoPayMoneyKindCodeList.GetKey(0);
            }
            // DEL 2009/01/21 不具合対応[10288] ↓不具合対応[10288]
            //this.AutoPayMoneyKindCode_tComboEditor.Value = autoPayMoneyKindCodeFirst;	// 自動支払金種コード

            this.AutoPayMoneyKindDivNm_tEdit.Clear();			// 自動支払金種区分名称
            this.AutoPayMoneyKindDiv_tNedit.Clear();			// 自動支払金種区分（隠し項目）

            this._autoPayMoneyKindCode_tComboEditorValue = -1;	// 自動入金金種コードコンボボックスデータワーク
            //----- ueno add---------- end 2008.02.18

            // --- ADD 2008/06/05 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();                             // 拠点コード
            this.SectionNm_tEdit.Clear();                             // 拠点ガイド名称

            this.PriceCheckDivCd_tComboEditor.SelectedIndex = 0;      // 定価チェック区分
            this.StockUnitChgDivCd_tComboEditor.SelectedIndex = 0;    // 仕入単価チェック区分
            this.PriceCostUpdtDiv_tComboEditor.SelectedIndex = 0;     // 定価原価更新区分
            this.SectDspDivCd_tComboEditor.SelectedIndex = 0;         // 拠点表示区分
            this.SlipDateClrDivCd_tComboEditor.SelectedIndex = 0;     // 伝票日付クリア区分
            this.AutoPayment_tComboEditor.SelectedIndex = 0;          // 自動支払区分
            this.PaySlipDateClrDiv_tComboEditor.SelectedIndex = 0;    // 支払伝票日付クリア区分
            this.PaySlipDateAmbit_tComboEditor.SelectedIndex = 0;     // 支払伝票日付範囲区分
            this.AutoEntryGoodsDivCd_tComboEditor.SelectedIndex = 0;  // 商品自動登録
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            // --- ADD 2008/09/12 -------------------------------->>>>>
            this.StockSearchDiv_tComboEditor.SelectedIndex = 0;       // 在庫検索区分
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START            
            this.GoodsNmReDispDivCd_tComboEditor.SelectedIndex = 0;     // 商品名再表示区分
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/05 -------------------------------->>>>>
              int status = stockTtlStAcs.Read(out this.stockTtlSet,this.enterPriseCode);
              if (status == 0)
              {
                Mode_Label.Text = UPDATE_MODE;
                // 全体初期表示設定クラス画面展開処理
                StockTtlSetToScreen();
                //税率１にフォーカスセット
                ConsTaxRates1_tNedit.Focus();
            //2005.06.13 初期フォーカスの項目を全選択されるように変更　三橋 >>>>>START 
                ConsTaxRates1_tNedit.SelectAll();
                //2005.06.13 初期フォーカスの項目を全選択されるように変更　三橋 >>>>>END
              }
              else
              {
                Mode_Label.Text = INSERT_MODE;

              }   
            
              //画面に表示した情報を一旦データクラスにセット
              ScreenTostockTtlSet();
              //読み出したデータのクローン作成
              chkStockTtlSet = this.stockTtlSet.Clone();

              return;
             --- DEL 2008/06/05 --------------------------------<<<<< */

            // --- ADD 2008/06/05 -------------------------------->>>>>
            if (this._dataIndex < 0)
            {
                // 新規モード
                this._logicalDeleteMode = -1;

                StockTtlSt newStockTtlSt = new StockTtlSt();

                // 自動支払金種初期設定
                newStockTtlSt.AutoPayMoneyKindCode = (int)StockTtlSt._autoPayMoneyKindCodeList.GetKey(0);

                // 仕入在庫全体設定オブジェクトを画面に展開
                StockTtlStToScreen(newStockTtlSt);

                // クローン作成
                this._stockTtlStClone = newStockTtlSt.Clone();
                ScreenToStockTtlSt(ref this._stockTtlStClone);

                ScreenToStockTtlSt(ref this._stockTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                StockTtlSt stockTtlSt = (StockTtlSt)this._stockTtlStTable[guid];

                // 仕入在庫全体設定オブジェクトを画面に展開
                StockTtlStToScreen(stockTtlSt);

                if (stockTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this._logicalDeleteMode = 0;

                    // クローン作成
                    this._stockTtlStClone = stockTtlSt.Clone();
                    ScreenToStockTtlSt(ref this._stockTtlStClone);
                }
                else
                {
                    // 削除モード
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this._indexBuf = this._dataIndex;

            ScreenInputPermissionControl();
            // --- ADD 2008/06/05 --------------------------------<<<<< 
        }

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>
        /// 設定画面入力チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="checkMessage">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
          private bool CheckDispInfo(ref Control control, ref string checkMessage)
          {
              bool returnStatus = false;

              // 2006.07.04 23003 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
              // 有効日3に％が設定されている場合
              if (this.ConsTaxRates3_tNedit.GetValue() > 0)
              {
                  this.ValidDtConsTaxRate3_tDateEdit.LongDate = Convert.ToInt32(DateTime.MaxValue.ToString(("yyyyMMdd")));
              }
              // 有効日2に％が設定されている場合
              else if (this.ConsTaxRates2_tNedit.GetValue() > 0)
              {
                  this.ValidDtConsTaxRate2_tDateEdit.LongDate = Convert.ToInt32(DateTime.MaxValue.ToString(("yyyyMMdd")));
              }
              else
              {
                  this.ValidDtConsTaxRate1_tDateEdit.LongDate = Convert.ToInt32(DateTime.MaxValue.ToString(("yyyyMMdd")));
              }
              // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

              // 2007.04.02  S.Koga  add ------------------------------------
              double rate1 = 0;
              if (!ConsTaxRates1_tNedit.Text.Equals(""))
              {
                  rate1 = double.Parse(this.ConsTaxRates1_tNedit.Text);
                  if (rate1 > 999.9)
                  {
                      TMsgDisp.Show(
                          this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          "消費税率１の値が不正です。",
                          -1,
                          MessageBoxButtons.OK);
                      ConsTaxRates1_tNedit.Focus();
                      ConsTaxRates1_tNedit.SelectAll();
                      return false;
                  }
              }

              double rate2 = 0;
              if (!ConsTaxRates2_tNedit.Text.Equals(""))
              {
                  rate2 = double.Parse(this.ConsTaxRates2_tNedit.Text);
                  if (rate2 > 999.9)
                  {
                      TMsgDisp.Show(
                          this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          "消費税率２の値が不正です。",
                          -1,
                          MessageBoxButtons.OK);
                      ConsTaxRates2_tNedit.Focus();
                      ConsTaxRates2_tNedit.SelectAll();
                      return false;
                  }
              }

              double rate3 = 0;
              if (!ConsTaxRates3_tNedit.Text.Equals(""))
              {
                  rate3 = double.Parse(this.ConsTaxRates3_tNedit.Text);
                  if (rate3 > 999.9)
                  {
                      TMsgDisp.Show(
                          this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          "消費税率３の値が不正です。",
                          -1,
                          MessageBoxButtons.OK);
                      ConsTaxRates3_tNedit.Focus();
                      ConsTaxRates3_tNedit.SelectAll();
                      return false;
                  }
              }
              // ------------------------------------------------------------

              //--有効日の必須チェック--//
              //有効日1は必須
              if (ValidDtConsTaxRate1_tDateEdit.LongDate == 0)
              {
                  control = ValidDtConsTaxRate1_tDateEdit;
                  checkMessage = "税率有効日１が未入力です。";
                  return returnStatus;
              }

              //税率2が設定されていたら、有効日2も必須
              if ((ConsTaxRates2_tNedit.GetValue() != 0f) &&
                  (ValidDtConsTaxRate2_tDateEdit.LongDate == 0))
              {
                  control = ValidDtConsTaxRate2_tDateEdit;
                  checkMessage = "税率有効日２が未入力です。";
                  return returnStatus;
              }

              //税率3が設定されていたら、有効日3も必須
              if ((ConsTaxRates3_tNedit.GetValue() != 0f) &&
                  (ValidDtConsTaxRate3_tDateEdit.LongDate == 0))
              {
                  control = ValidDtConsTaxRate3_tDateEdit;
                  checkMessage = "税率有効日３が未入力です。";
                  return returnStatus;
              }

              //--日付の有効性チェック--//
              if ((ValidDtConsTaxRate1_tDateEdit.CheckInputData() != null) ||
                  !(CheckDateEffect(ValidDtConsTaxRate1_tDateEdit)))
              {
                  checkMessage = "税率有効日１の入力値が不正です。";
                  control = ValidDtConsTaxRate1_tDateEdit;
                  return returnStatus;
              }

              DateTime dt = ValidDtConsTaxRate2_tDateEdit.GetDateTime();


              if ((ValidDtConsTaxRate2_tDateEdit.CheckInputData() != null) ||
                  !(CheckDateEffect(ValidDtConsTaxRate2_tDateEdit)))
              {
                  checkMessage = "税率有効日２の入力値が不正です。";
                  control = ValidDtConsTaxRate2_tDateEdit;
                  return returnStatus;
              }
              if ((ValidDtConsTaxRate3_tDateEdit.CheckInputData() != null) ||
                  !(CheckDateEffect(ValidDtConsTaxRate3_tDateEdit)))
              {
                  checkMessage = "税率有効日３の入力値が不正です。";
                  control = ValidDtConsTaxRate3_tDateEdit;
                  return returnStatus;
              }

              //--有効日の大小チェック--//
              //税率1.2
              if ((ValidDtConsTaxRate2_tDateEdit.LongDate != 0) &&
                  (ValidDtConsTaxRate1_tDateEdit.LongDate >= ValidDtConsTaxRate2_tDateEdit.LongDate))
              {
                  control = ValidDtConsTaxRate1_tDateEdit;
                  checkMessage = "税率有効日付の範囲が不正です。";
                  return returnStatus;
              }

              //税率2.3⇒有効日2の方が大きい、もしくは有効日3が設定アリ・有効日2設定なしのときNG
              if (((ValidDtConsTaxRate3_tDateEdit.LongDate != 0) &&
                   (ValidDtConsTaxRate2_tDateEdit.LongDate >= ValidDtConsTaxRate3_tDateEdit.LongDate)) ||
                  ((ValidDtConsTaxRate2_tDateEdit.LongDate == 0) &&
                   (ValidDtConsTaxRate3_tDateEdit.LongDate != 0)))
              {
                  control = ValidDtConsTaxRate2_tDateEdit;
                  checkMessage = "税率有効日付の範囲が不正です。";
                  return returnStatus;
              }

              return returnStatus = true;
          }

    
        /// <summary>
        /// 入力日付の有効性チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 年月日が空白だとチェックが走らないため、UI側でも有効性チェックを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private bool CheckDateEffect( Control control )
        {
          //何らかの入力があるが、年・月・日のいづれかに入力がなければ、警告。
          if (((TDateEdit)control).LongDate != 0)
          {
            int lYear = Convert.ToInt32((((TDateEdit)control).LongDate) / 10000);
            int lMonth =  Convert.ToInt32(((((TDateEdit)control).LongDate) % 10000) / 100);
            int lDay = (((TDateEdit)control).LongDate) % 100;
      
            if ((lDay == 0) || (lMonth == 0) || (lYear == 0))
            {
             return false;
            }
          }
          return true;    
        }
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
            }
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            return result;
        }

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>
        /// データ保存処理処理
        /// </summary>
        /// <returns>保存結果（true:OK／false:エラー在り）</returns>
        /// <remarks>
        /// <br>Note       : データの登録更新処理を行います</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.30</br>
        /// </remarks>
        private bool DataSaveProc()
        {
          bool blRes = true;
    
          //画面データ入力チェック処理
          string checkMessage = "";
          Control rcontRol = null;
          bool chkSt = CheckDispInfo(ref rcontRol, ref checkMessage );
          if (!chkSt)
          {
              //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
              TMsgDisp.Show(this,
                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                  pgId,
                  checkMessage,
                  0,
                  MessageBoxButtons.OK);
              //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
    //        MessageBox.Show(checkMessage, "入力チェック",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            rcontRol.Focus();
            return blRes = false;
          }

          // 画面から仕入在庫全体設定表示クラスにデータをセットします。
          ScreenTostockTtlSet();

          // 仕入在庫全体設定登録処理
          int status = stockTtlStAcs.Write( ref stockTtlSet);			
          if (status != 0)
          {
              //2005.07.06 排他制御対応　三橋>>>>>START
              if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
              {
			  
                  //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
                  TMsgDisp.Show(this,
                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                      pgId,
                      "既に他端末より更新されています",
                      status,
                      MessageBoxButtons.OK);
                  //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				
                  //2005.07.12 排他制御コメント変更　三橋>>>>>START
    //			  MessageBox.Show(
    //				  "既に他端末より更新されています",
    //				  "注意",
    //				  MessageBoxButtons.OK,
    //				  MessageBoxIcon.Exclamation,
    //				  MessageBoxDefaultButton.Button1);
                  //MessageBox.Show(
                  //  "既に他端末で更新されています",
                  //   "注意",
                  //  MessageBoxButtons.OK,
                  //  MessageBoxIcon.Exclamation,
                  //  MessageBoxDefaultButton.Button1);
                  //2005.07.12 排他制御コメント変更　三橋<<<<<<END

                  if (CanClose == true)
                  {
                      this.Close();
                  }
                  else
                  {
                      this.Hide();
                  }
                  return blRes = false;
              }
              else
              {
                  //2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                  TMsgDisp.Show(this,
                      emErrorLevel.ERR_LEVEL_STOP,
                      pgId,
                      pgNm,
                      "DataSaveProc",
                      TMsgDisp.OPE_UPDATE,
                      "仕入在庫全体設定の登録に失敗しました。",
                      status,
                      obj,
                      MessageBoxButtons.OK,
                      MessageBoxDefaultButton.Button1);
                  //2005.09.17 enokida 変更 MessageBox対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
    //			  MessageBox.Show(
    //				  "仕入在庫全体設定の登録に失敗しました",
    //				  "エラー",
    //				  MessageBoxButtons.OK,
    //				  MessageBoxIcon.Error,
    //				  MessageBoxDefaultButton.Button1);
                  if (CanClose == true)
                  {
                      this.Close();
                  }
                  else
                  {
                      this.Hide();
                  }
                  return blRes = false;
              }
              //MessageBox.Show(
              //  "仕入在庫全体設定の登録に失敗しました",
              //  "エラー",
              //  MessageBoxButtons.OK,
              //  MessageBoxIcon.Error,
              //  MessageBoxDefaultButton.Button1);
              //return blRes = false;
              //2005.07.06 排他制御対応　三橋<<<<<<END
          }
          Mode_Label.Text = UPDATE_MODE;
          return blRes;
        }
           --- DEL 2008/06/05 --------------------------------<<<<< */

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// <summary>
        /// 仕入在庫全体設定保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の保存を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return result;
            }

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tArrowKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            StockTtlSt stockTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                stockTtlSt = ((StockTtlSt)this._stockTtlStTable[guid]).Clone();
            }
            ScreenToStockTtlSt(ref stockTtlSt);

            // ----- DEL 2011/09/07 ------------------------------>>>>>
            //// ADD 2008/09/19 不具合対応による共通仕様の展開 ---------->>>>>
            //// 拠点コードが存在していない場合、登録しない。
            //if (!SectionUtil.ExistsCode(stockTtlSt.SectionCode) || stockTtlSt.SectionCode == "0")
            //{
            //    TMsgDisp.Show(
            //        this, 								                    // 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
            //        AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
            //        this.Text, 		                                        // プログラム名称
            //        MethodBase.GetCurrentMethod().Name, 					// 処理名称
            //        TMsgDisp.OPE_UPDATE, 				                    // オペレーション
            //        SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // 表示するメッセージ
            //        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
            //        this,			                                        // エラーが発生したオブジェクト
            //        MessageBoxButtons.OK, 				                    // 表示するボタン
            //        MessageBoxDefaultButton.Button1                         // 初期表示ボタン
            //    );
            //    return false;
            //}
            //// ADD 2008/09/19 不具合対応による共通仕様の展開 ----------<<<<<
            // ----- DEL 2011/09/07 ------------------------------<<<<<

            int status = this._stockTtlStAcs.Write(ref stockTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        StockTtlStToDataSet(stockTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "SFSIR09000U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_SectionCodeAllowZero2.Focus();
                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "仕入在庫全体設定", 				// プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockTtlStAcs,     			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /// <summary>
        /// フォームクローズ処理）
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        //----- ueno add---------- start 2008.02.18
        /// <summary>
        /// 自動支払金種区分表示変更
        /// </summary>
        /// <param name="autoPayMoneyKindCode">自動支払金種コード</param>
        /// <remarks>
        /// <br>Note　     : 自動支払金種コードの選択を変更したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.02.18</br>
        /// </remarks>
        private void AutoPayMoneyKindCodeVisibleChange(int autoPayMoneyKindCode)
        {
            try
            {
                if (this._autoPayMoneyKindCode_tComboEditorValue == autoPayMoneyKindCode) return;

                // 自動支払金種区分（隠し項目）
                int wkAutoPayMoneyKindDiv = this._stockTtlStAcs.GetAutoPayMoneyKindDiv(autoPayMoneyKindCode);
                this.AutoPayMoneyKindDiv_tNedit.SetInt(wkAutoPayMoneyKindDiv);

                // 自動支払金種区分名称
                this.AutoPayMoneyKindDivNm_tEdit.Text = StockTtlSt.GetComboBoxNm(wkAutoPayMoneyKindDiv, StockTtlSt._mnyKindDivList);

                // 選択した番号を保持
                this._autoPayMoneyKindCode_tComboEditorValue = autoPayMoneyKindCode;
            }
            catch
            {
            }
        }
        //----- ueno add---------- end 2008.02.18

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable stockTtlStTable = new DataTable(STOCKTTLST_TABLE);

            stockTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            stockTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            //stockTtlStTable.Columns.Add(PARTSUNITPRC_TITLE, typeof(string));  // DEL 2008/06/05
            stockTtlStTable.Columns.Add(STOCKDISCOUNTNAME_TITLE, typeof(string));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //stockTtlStTable.Columns.Add(RGDSSLIPPRTDIV_TITLE, typeof(string));
            //stockTtlStTable.Columns.Add(RGDSUNPRCPRTDIV_TITLE, typeof(string));
            //stockTtlStTable.Columns.Add(RGDSZEROPRTDIV_TITLE, typeof(string));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlStTable.Columns.Add(IOGOODSCNTDIV_TITLE , typeof(string));
            //stockTtlStTable.Columns.Add(IOGOODSCNTDIV2_TITLE , typeof(string));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlStTable.Columns.Add(LISTPRICEINPDIV_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(UNITPRICEINPDIV_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(PRICECHECKDIVCD_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(STOCKUNITCHGDIVCD_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(PRICECOSTUPDTDIV_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(SECTDSPDIVCD_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(SLIPDATECLRDIVCD_TITLE, typeof(string));

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlStTable.Columns.Add(SUPPLIERFORMALINI_TITLE , typeof(string));
            //stockTtlStTable.Columns.Add(SALESSLIPDTLCONF_TITLE, typeof(string));
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlStTable.Columns.Add(DTLNOTEDISPDIV_TITLE, typeof(string));

            // DEL 2009/01/16 不具合対応[9694] ---------->>>>>
            //stockTtlStTable.Columns.Add(AUTOPAYMONEYKINDCODE_TITLE , typeof(string));
            //stockTtlStTable.Columns.Add(AUTOPAYMONEYKINDDIV_TITLE , typeof(string));
            //stockTtlStTable.Columns.Add(AUTOPAYMENT_TITLE , typeof(string));
            // DEL 2009/01/16 不具合対応[9694] ----------<<<<<

            stockTtlStTable.Columns.Add(PAYSLIPDATECLRDIV_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(PAYSLIPDATEAMBIT_TITLE, typeof(string));
            stockTtlStTable.Columns.Add(AUTOENTRYGOODSDIVCD_TITLE, typeof(string));

            // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
            // 商品名再表示区分
            stockTtlStTable.Columns.Add(GOODSNMREDISPDIVCD_TITLE, typeof(string));
            // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
        
            // --- ADD 2008/09/12 -------------------------------->>>>>
            stockTtlStTable.Columns.Add(STOCKSEARCHDIV_TITLE, typeof(string));
            // --- ADD 2008/09/12 --------------------------------<<<<<

            stockTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(stockTtlStTable);
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private int SearchStockTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList stockTtlSts = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._stockTtlStAcs.SearchAll(out stockTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (StockTtlSt stockTtlSt in stockTtlSts)
                        {
                            if (this._stockTtlStTable.ContainsKey(stockTtlSt.FileHeaderGuid) == false)
                            {
                                StockTtlStToDataSet(stockTtlSt.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "仕入在庫全体設定", 				// プログラム名称
                            "SearchStockTtlSt", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockTtlStAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            totalCnt = stockTtlSts.Count;

            return status;
        }

        /// <summary>
        /// 仕入在庫全体設定オブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定オブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockTtlSt stockTtlSt = ((StockTtlSt)this._stockTtlStTable[guid]).Clone();

            // 仕入在庫全体設定が存在していない
            if (stockTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5289] ---------->>>>>
            // 拠点コードが全社設定の場合、削除不可
            if (IsAllSection(stockTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_HIDE, 				                        // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/16 不具合対応[5289] ----------<<<<<

            status = this._stockTtlStAcs.LogicalDelete(ref stockTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        StockTtlStToDataSet(stockTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "見積初期値設定", 					// プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/16 不具合対応[5289] ---------->>>>>
        /// <summary>
        /// 全社設定か判定します。
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定</param>
        /// <returns><c>true</c> :全社設定である。<br/><c>false</c>:全社設定ではない。</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5289]にて追加</br>
        /// <br>Programmer : 30434 工藤 恵優</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private static bool IsAllSection(StockTtlSt stockTtlSt)
        {
            return SectionUtil.IsAllSection(stockTtlSt.SectionCode);
        }
        // ADD 2008/09/16 不具合対応[5289] ----------<<<<<

        /// <summary>
        /// 仕入在庫全体設定オブジェクト展開処理
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void StockTtlStToDataSet(StockTtlSt stockTtlSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[STOCKTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (stockTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][DELETE_DATE] = stockTtlSt.UpdateDateTime;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = stockTtlSt.SectionCode;
            // 拠点名称
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == stockTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }

            // ADD 2008/10/08 不具合対応[6396] ---------->>>>>
            if (stockTtlSt.SectionCode.Trim().Equals("00"))
            {
                this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "全社共通";
            }
            // ADD 2008/10/08 不具合対応[6396] ----------<<<<<

            // 値引名称
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][STOCKDISCOUNTNAME_TITLE] = stockTtlSt.StockDiscountName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //// 返品伝票発行区分
            //switch (stockTtlSt.RgdsSlipPrtDiv)
            //{
            //    case 0:
            //        wrkstr = RGDSSLIPPRTDIV_0;  // しない
            //        break;
            //    case 1:
            //        wrkstr = RGDSSLIPPRTDIV_1;  // する
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][RGDSSLIPPRTDIV_TITLE] = wrkstr;

            //// 返品時単価印刷区分
            //switch (stockTtlSt.RgdsUnPrcPrtDiv)
            //{
            //    case 0:
            //        wrkstr = RGDSUNPRCPRTDIV_0;  // する
            //        break;
            //    case 1:
            //        wrkstr = RGDSUNPRCPRTDIV_1;  // しない
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][RGDSUNPRCPRTDIV_TITLE] = wrkstr;

            //// 返品時ゼロ円印刷区分
            //switch (stockTtlSt.RgdsZeroPrtDiv)
            //{
            //    case 0:
            //        wrkstr = RGDSZEROPRTDIV_0;  // する
            //        break;
            //    case 1:
            //        wrkstr = RGDSZEROPRTDIV_1;  // しない
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][RGDSZEROPRTDIV_TITLE] = wrkstr;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 入出荷数区分
            //switch (stockTtlSt.IoGoodsCntDiv)
            //{
            //    case 0:
            //        wrkstr = IOGOODSCNTDIV_0;  // チェック無し
            //        break;
            //    case 1:
            //        wrkstr = IOGOODSCNTDIV_1;  // 警告
            //        break;
            //    case 2:
            //        wrkstr = IOGOODSCNTDIV_2;  // 警告＋再入力
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][IOGOODSCNTDIV_TITLE] = wrkstr;

            //// 入出荷数区分2
            //switch (stockTtlSt.IoGoodsCntDiv2)
            //{
            //    case 0:
            //        wrkstr = IOGOODSCNTDIV_0;  // チェック無し
            //        break;
            //    case 1:
            //        wrkstr = IOGOODSCNTDIV_1;  // 警告
            //        break;
            //    case 2:
            //        wrkstr = IOGOODSCNTDIV_2;  // 警告＋再入力
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][IOGOODSCNTDIV2_TITLE] = wrkstr;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 定価チェック区分
            switch (stockTtlSt.PriceCheckDivCd)
            {
                case 0:
                    wrkstr = PRICECHECKDIVCD_0;  // 無視
                    break;
                case 1:
                    wrkstr = PRICECHECKDIVCD_1;  // 再入力
                    break;
                case 2:
                    wrkstr = PRICECHECKDIVCD_2;  // 警告MSG
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][PRICECHECKDIVCD_TITLE] = wrkstr;

            // 仕入単価チェック区分
            switch (stockTtlSt.StockUnitChgDivCd)
            {
                case 0:
                    wrkstr = STOCKUNITCHGDIVCD_0;  // 無視
                    break;
                case 1:
                    wrkstr = STOCKUNITCHGDIVCD_1;  // 再入力
                    break;
                case 2:
                    wrkstr = STOCKUNITCHGDIVCD_2;  // 警告MSG
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][STOCKUNITCHGDIVCD_TITLE] = wrkstr;

            // 定価原価更新区分
            switch (stockTtlSt.PriceCostUpdtDiv)
            {
                case 0:
                    wrkstr = PRICECOSTUPDTDIV_0;  // 非更新
                    break;
                case 1:
                    wrkstr = PRICECOSTUPDTDIV_1;  // 無条件更新
                    break;
                case 2:
                    wrkstr = PRICECOSTUPDTDIV_2;  // 確認更新
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][PRICECOSTUPDTDIV_TITLE] = wrkstr;

            // 拠点表示区分
            switch (stockTtlSt.SectDspDivCd)
            {
                case 0:
                    wrkstr = SECTDSPDIVCD_0;  // 標準
                    break;
                case 1:
                    wrkstr = SECTDSPDIVCD_1;  // 自社マスタ
                    break;
                case 2:
                    wrkstr = SECTDSPDIVCD_2;  // 表示無し
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SECTDSPDIVCD_TITLE] = wrkstr;

            // 伝票日付クリア区分
            switch (stockTtlSt.SlipDateClrDivCd)
            {
                case 0:
                    wrkstr = SLIPDATECLRDIVCD_SYSTEM;  // システム日付
                    break;
                case 1:
                    wrkstr = SLIPDATECLRDIVCD_INPUT;   // 入力日付
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SLIPDATECLRDIVCD_TITLE] = wrkstr;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //// 仕入形式初期値
            //switch (stockTtlSt.SupplierFormalIni)
            //{
            //    case 0:
            //        wrkstr = SUPPLIERFORMALINI_0;   // 仕入
            //        break;
            //    case 1:
            //        wrkstr = SUPPLIERFORMALINI_1;   // 入荷
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SUPPLIERFORMALINI_TITLE] = wrkstr;

            //// 売上明細確認
            //switch (stockTtlSt.SalesSlipDtlConf)
            //{
            //    case 0:
            //        wrkstr = SALESSLIPDTLCONF_0;   // 任意
            //        break;
            //    case 1:
            //        wrkstr = SALESSLIPDTLCONF_1;   // 必須
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][SALESSLIPDTLCONF_TITLE] = wrkstr;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // 定価入力区分
            switch (stockTtlSt.ListPriceInpDiv)
            {
                case 0:
                    wrkstr = LISTPRICEINPDIV_0;   // 可能
                    break;
                case 1:
                    wrkstr = LISTPRICEINPDIV_1;   // 不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][LISTPRICEINPDIV_TITLE] = wrkstr;

            // 単価入力区分
            switch (stockTtlSt.UnitPriceInpDiv)
            {
                case 0:
                    wrkstr = UNITPRICEINPDIV_0;   // 可能
                    break;
                case 1:
                    wrkstr = UNITPRICEINPDIV_1;   // 不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][UNITPRICEINPDIV_TITLE] = wrkstr;

            // 明細備考表示区分
            switch (stockTtlSt.DtlNoteDispDiv)
            {
                case 0:
                    wrkstr = DTLNOTEDISPDIV_0;   // 有り
                    break;
                case 1:
                    wrkstr = DTLNOTEDISPDIV_1;   // 無し
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][DTLNOTEDISPDIV_TITLE] = wrkstr;

            // DEL 2009/01/16 不具合対応[9694] ---------->>>>>
            //// 自動支払金種
            //wrkstr = this._stockTtlStAcs. GetAutoPayMoneyKindName(stockTtlSt.AutoPayMoneyKindCode);
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][AUTOPAYMONEYKINDCODE_TITLE] = wrkstr;

            //// 自動支払金種区分
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][AUTOPAYMONEYKINDDIV_TITLE] = StockTtlSt.GetComboBoxNm(stockTtlSt.AutoPayMoneyKindDiv, StockTtlSt._mnyKindDivList);

            //// 自動支払区分
            //switch (stockTtlSt.AutoPayment)
            //{
            //    case 0:
            //        wrkstr = AUTOPAYMENT_NOMAL;   // 通常支払
            //        break;
            //    case 1:
            //        wrkstr = AUTOPAYMENT_AUTO;    // 自動支払
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][AUTOPAYMENT_TITLE] = wrkstr;
            // DEL 2009/01/16 不具合対応[9694] ----------<<<<<

            // 支払伝票日付クリア区分
            switch (stockTtlSt.PaySlipDateClrDiv)
            {
                case 0:
                    wrkstr = PAYSLIPDATECLRDIV_SYSTEM;   // システム日付に戻す
                    break;
                case 1:
                    wrkstr = PAYSLIPDATECLRDIV_INPUT;    // 入力日付のまま
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][PAYSLIPDATECLRDIV_TITLE] = wrkstr;

            // 支払伝票日付範囲区分
            switch (stockTtlSt.PaySlipDateAmbit)
            {
                case 0:
                    wrkstr = PAYSLIPDATEAMBIT_0;    // 制限なし
                    break;
                case 1:
                    wrkstr = PAYSLIPDATEAMBIT_1;    // システム日付以降入力不可
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][PAYSLIPDATEAMBIT_TITLE] = wrkstr;

            // 商品自動登録
            switch (stockTtlSt.AutoEntryGoodsDivCd)
            {
                case 0:
                    wrkstr = AUTOENTRYGOODSDIVCD_0;    // なし
                    break;
                case 1:
                    wrkstr = AUTOENTRYGOODSDIVCD_1;    // あり
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][AUTOENTRYGOODSDIVCD_TITLE] = wrkstr;

            // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
            // 商品名再表示区分
            switch (stockTtlSt.GoodsNmReDispDivCd)
            {
                case 0:
                    wrkstr = GOODSNMREDISPDIVCD_0;    // なし
                    break;
                case 1:
                    wrkstr = GOODSNMREDISPDIVCD_1;    // あり
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][GOODSNMREDISPDIVCD_TITLE] = wrkstr;
            // 2009.04.01 30413 犬飼 項目追加 <<<<<<END

            // --- ADD 2008/09/12 -------------------------------->>>>>
            // 在庫検索区分
            switch (stockTtlSt.StockSearchDiv)
            {
                case 0:
                    wrkstr = StockSearchDiv_0;    // 優先倉庫
                    break;
                case 1:
                    wrkstr = StockSearchDiv_1;    // 指定倉庫
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][STOCKSEARCHDIV_TITLE] = wrkstr;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // GUID
            this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[index][GUID_TITLE] = stockTtlSt.FileHeaderGuid;

            if (this._stockTtlStTable.ContainsKey(stockTtlSt.FileHeaderGuid) == true)
            {
                this._stockTtlStTable.Remove(stockTtlSt.FileHeaderGuid);
            }
            this._stockTtlStTable.Add(stockTtlSt.FileHeaderGuid, stockTtlSt);

        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this._logicalDeleteMode)
            {
                case -1:
                    {
                        // 新規モード
                        this.Mode_Label.Text = INSERT_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 初期フォーカスをセット
                        this.tEdit_SectionCodeAllowZero2.Focus();

                        // 拠点コードのコメント表示
                        SectionNm_Label.Visible = true;

                        break;
                    }
                case 1:
                    {
                        // 削除モード
                        this.Mode_Label.Text = DELETE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false);

                        // 初期フォーカスをセット
                        this.Delete_Button.Focus();

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        break;
                    }
                default:
                    {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true);

                        // 拠点関係のコントロールを使用不可にする
                        tEdit_SectionCodeAllowZero2.Enabled = false;
                        SectionGd_ultraButton.Enabled = false;
                        SectionNm_tEdit.Enabled = false;

                        // 拠点コードのコメント非表示
                        SectionNm_Label.Visible = false;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
                        //// 初期フォーカスをセット
                        //this.RgdsSlipPrtDiv_tComboEditor.Focus();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;
            this.SectionGd_ultraButton.Enabled = enabled;
            this.SectionNm_tEdit.Enabled = enabled;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this.SupplierFormalIni_tComboEditor.Enabled = enabled;
            //this.SalesSlipDtlConf_tComboEditor.Enabled = enabled;
            //this.IoGoodsCntDiv_tComboEditor.Enabled = enabled;
            //this.IoGoodsCntDiv2_tComboEditor.Enabled = enabled;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //this.RgdsSlipPrtDiv_tComboEditor.Enabled = enabled;
            //this.RgdsUnPrcPrtDiv_tComboEditor.Enabled = enabled;
            //this.RgdsZeroPrtDiv_tComboEditor.Enabled = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL
            this.ListPriceInpDiv_tComboEditor.Enabled = enabled;
            this.UnitPriceInpDiv_tComboEditor.Enabled = enabled;
            this.DtlNoteDispDiv_tComboEditor.Enabled = enabled;
            this.AutoPayMoneyKindCode_tComboEditor.Enabled = enabled;
            this.PriceCheckDivCd_tComboEditor.Enabled = enabled;
            this.AutoPayMoneyKindDivNm_tEdit.Enabled = enabled;
            this.StockUnitChgDivCd_tComboEditor.Enabled = enabled;
            this.AutoPayment_tComboEditor.Enabled = enabled;
            this.PriceCostUpdtDiv_tComboEditor.Enabled = enabled;
            this.PaySlipDateClrDiv_tComboEditor.Enabled = enabled;
            this.SectDspDivCd_tComboEditor.Enabled = enabled;
            this.PaySlipDateAmbit_tComboEditor.Enabled = enabled;
            this.SlipDateClrDivCd_tComboEditor.Enabled = enabled;
            this.AutoEntryGoodsDivCd_tComboEditor.Enabled = enabled;
            this.StockDiscountName_tEdit.Enabled = enabled;
            // --- ADD 2008/09/12 -------------------------------->>>>>
            this.StockSearchDiv_tComboEditor.Enabled = enabled;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START            
            this.GoodsNmReDispDivCd_tComboEditor.Enabled = enabled;     // 商品名再表示区分
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END

            // ちらつき防止の為
            this.Enabled = true;
        }

        /// <summary>
        /// 仕入在庫全体設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定ブジェクトの完全削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockTtlSt stockTtlSt = (StockTtlSt)this._stockTtlStTable[guid];

            // 仕入在庫全体設定が存在していない
            if (stockTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 不具合対応[5289] ---------->>>>>
            // 拠点コードが全社設定の場合、削除不可
            if (IsAllSection(stockTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // エラーレベル
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                    this.Text, 				                                // プログラム名称
                    MethodBase.GetCurrentMethod().Name,                     // 処理名称
                    TMsgDisp.OPE_DELETE, 				                    // TODO:オペレーション
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // 表示するメッセージ
                    status, 						                        // ステータス値
                    this,			                                        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 			                        // 表示するボタン
                    MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                );
                return status;
            }
            // ADD 2008/09/16 不具合対応[5289] ----------<<<<<

            // 削除
            status = this._stockTtlStAcs.Delete(stockTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._stockTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "仕入在庫全体設定", 				// プログラム名称
                            "PhysicalDelete", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockTtlStAcs,			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 仕入在庫全体設定オブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定オブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            StockTtlSt stockTtlSt = ((StockTtlSt)this._stockTtlStTable[guid]).Clone();

            // 仕入在庫全体設定が存在していない
            if (stockTtlSt == null)
            {
                return -1;
            }

            // 復活
            status = this._stockTtlStAcs.Revival(ref stockTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        StockTtlStToDataSet(stockTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                            "仕入在庫全体設定", 				// プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._stockTtlStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        # endregion

        # region Control Events

        /// <summary>
        ///	Form.Load イベント(SFSIR09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void SFSIR09000UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // --- ADD 2008/06/05 -------------------------------->>>>>
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// 完全削除ボタン

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/06/05 --------------------------------<<<<< 

            // 画面初期設定処理
            ScreenInitialSetting();

            // --- ADD 2008/09/29 -------------------------------->>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
            //this.RgdsSlipPrtDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);            // 返品伝票発行区分
            //this.RgdsUnPrcPrtDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 返品時単価印刷区分
            //this.RgdsZeroPrtDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);            // 返品時ゼロ円印刷区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL
            this.PriceCheckDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 定価チェック区分
            this.StockUnitChgDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 仕入単価チェック区分
            this.PriceCostUpdtDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);          // 定価原価更新区分
            this.SectDspDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);              // 拠点表示区分
            this.SlipDateClrDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);          // 伝票日付クリア区分
            this.AutoEntryGoodsDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);       // 商品自動登録
            this.ListPriceInpDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 定価入力区分
            this.UnitPriceInpDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // 単価入力区分
            this.DtlNoteDispDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);            // 明細備考表示区分
            this.AutoPayMoneyKindCode_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);      // 自動支払金種
            this.AutoPayment_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);               // 自動支払区分
            this.PaySlipDateClrDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // 支払伝票日付クリア区分
            this.PaySlipDateAmbit_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);          // 支払伝票日付範囲区分
            this.StockSearchDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);            // 在庫検索区分
            // --- ADD 2008/09/29 --------------------------------<<<<< 

            // 2009.04.01 30413 犬飼 項目追加 >>>>>>START
            this.GoodsNmReDispDivCd_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);        // 商品名再表示区分
            // 2009.04.01 30413 犬飼 項目追加 <<<<<<END
            
            // 拠点ガイドのフォーカス制御の開始
            // DEL 2008/10/08 不具合対応[6394] ↓
            //SectionGuideController.StartControl();  // ADD 2008/09/19 不具合対応による共通仕様の展開
        }


        /// <summary>
        ///	Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	保存ボタンコントロールがクリックされたときに
        ///							発生します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/12 -------------------------------->>>>>
            //保存処理
            if (!SaveProc()) 
            {return;}

            DialogResult dialogResult = DialogResult.OK;

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }
        		
            //2005.07.04 フレームの最小化対応改良　三橋 >>>>>START
            this.DialogResult = dialogResult;
            //this.chkStockTtlSet = null;  // DEL 2008/06/05
            //// 最小化対応 2005.05.27 by Misaki
            //this.ValidDtConsTaxRate1_tDateEdit.SetLongDate(0);
            //// end 最小化対応 2005.05.27 by Misaki
            //this.DialogResult = dialogResult;
            //2005.07.04 フレームの最小化対応改良　三橋 <<<<<<END

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
              --- DEL 2008/06/12 --------------------------------<<<<< */


            if (!SaveProc())
            {			// 登録
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();

                // 新規モード
                this._logicalDeleteMode = -1;

                StockTtlSt newStockTtlSt = new StockTtlSt();

                // 自動支払金種初期設定
                newStockTtlSt.AutoPayMoneyKindCode = (int)StockTtlSt._autoPayMoneyKindCodeList.GetKey(0);

                // 仕入在庫全体設定オブジェクトを画面に展開
                StockTtlStToScreen(newStockTtlSt);

                // クローン作成
                this._stockTtlStClone = newStockTtlSt.Clone();
                ScreenToStockTtlSt(ref this._stockTtlStClone);

                // _GridIndexバッファ保持
                this._indexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndexバッファ初期化（メインフレーム最小化対応）
                this._indexBuf = -2;

                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
        }


        /// <summary>
        ///	Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	閉じるボタンコントロールがクリックされたときに
        ///							発生します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
          DialogResult dialogResult = DialogResult.Ignore;
		  
              //画面情報をとりあえずセット
              ScreenTostockTtlSt();
		
              //変更があるかどうか判定
          if (!chkStockTtlSet.Equals(stockTtlSet))
          {
            DialogResult result;
              //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
              result = TMsgDisp.Show(this,
                  emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                  pgId,
                  "",
                  0,
                  MessageBoxButtons.YesNoCancel);
              //2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
    //        result = MessageBox.Show( 
    //          "編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？",
    //          "保存確認",
    //          MessageBoxButtons.YesNoCancel,
    //          MessageBoxIcon.Question,
    //          MessageBoxDefaultButton.Button1);
          
            switch(result)
            {
              //保存する
              case DialogResult.Yes:
              {
                //保存処理関数
                if (!DataSaveProc())
                {return;}
                dialogResult = DialogResult.OK;
                break;
              }
              //処理しない
              case DialogResult.Cancel:
              {this.Cancel_Button.Focus();return;}

              //保存しないで終了
              case DialogResult.No:
              {
                dialogResult = DialogResult.Cancel;
                break;
              }
              default:
              { break;}
            }
          }

                // 画面非表示イベント
                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                    UnDisplaying(this, me);
                }

                //2005.07.04 フレームの最小化対応改良　三橋 >>>>>START
                this.DialogResult = DialogResult.Cancel;
                this.chkStockTtlSet = null;
                //// 最小化対応 2005.05.27 by Misaki
                //this.ValidDtConsTaxRate1_tDateEdit.SetLongDate(0);
                //// end 最小化対応 2005.05.27 by Misaki
                //this.DialogResult = DialogResult.Cancel;
                //2005.07.04 フレームの最小化対応改良　三橋 <<<<<<END

                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
                // フォームを非表示化する。
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
                 --- DEL 2008/06/06 --------------------------------<<<<< */

            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                StockTtlSt compareStockTtlSt = new StockTtlSt();
                compareStockTtlSt = this._stockTtlStClone.Clone();
                ScreenToStockTtlSt(ref compareStockTtlSt);

                // 最初に取得した画面情報と比較
                if (!(this._stockTtlStClone.Equals(compareStockTtlSt)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        ///	Form.Closing イベント(SFSIR09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
        ///							ようとしたときに発生します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void SFSIR09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //2005.07.04 フレームの最小化対応改良　三橋 >>>>>START
            //this.chkStockTtlSet = null;  // DEL 2008/06/05
            //// 最小化対応 2005.05.27 by Misaki
            //this.ValidDtConsTaxRate1_tDateEdit.SetLongDate(0);
            //// end 最小化対応 2005.05.27 by Misaki
            //2005.07.04 フレームの最小化対応改良　三橋 <<<<<<END

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;  // ADD 2008/06/05

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）			
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(SFSIR09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void SFSIR09000UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                //2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                // メインフレームアクティブ化
                this.Owner.Activate();
                //2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
                return;
            }

            /* --- DEL 2008/06/05 -------------------------------->>>>>
            //2005.07.04 フレームの最小化対応改良　三橋 >>>>>START
            if (this.chkStockTtlSet != null)
            {
                return;
            }
               --- DEL 2008/06/05 --------------------------------<<<<< */

            // --- ADD 2008/06/05 -------------------------------->>>>>
            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }
            // --- ADD 2008/06/05 --------------------------------<<<<< 

            //// 最小化対応 2005.05.27 by Misaki
            //// データがセットされていたら抜ける
            //if (ValidDtConsTaxRate1_tDateEdit.GetLongDate() != 0)
            //{
            //	return;
            //}
            //// end 最小化対応 2005.05.26 by Misaki
            //2005.07.04 フレームの最小化対応改良　三橋 <<<<<<END

            // ちらつき防止の為
            this.Enabled = false;

            timer1.Enabled = true;

            ScreenClear();
        }


        /// <summary>
        /// Timer.Tick イベント(timer1_Tick)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.13</br>
        /// </remarks>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            ScreenReconstruction();
        }

        /* --- DEL 2008/06/06 -------------------------------->>>>>
        /// <summary>
        /// ConsTaxRates1_tNedit.Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応</br>
        /// <br>Programmer : 22035 三橋  弘憲</br>
        /// <br>Date       : 2005.06.21</br>
        /// </remarks>
        private void ConsTaxRates1_tNedit_Leave(object sender, System.EventArgs e)
        {
          // 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応
          Double value = ConsTaxRates1_tNedit.GetValue();
          if ((0 <= value) && (value < 1))
          {
             ConsTaxRates1_tNedit.SetValue(value); // 表示は"0.x"になる
          }
        }


        /// <summary>
        /// ConsTaxRates2_tNedit.Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応</br>
        /// <br>Programmer : 22035 三橋  弘憲</br>
        /// <br>Date       : 2005.06.21</br>
        /// </remarks>
        private void ConsTaxRates2_tNedit_Leave(object sender, System.EventArgs e)
        {
          // 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応
          Double value = ConsTaxRates2_tNedit.GetValue();
          if ((0 <= value) && (value < 1))
          {
            ConsTaxRates2_tNedit.SetValue(value); // 表示は"0.x"になる
          }
        }


        /// <summary>
        /// ConsTaxRates3_tNedit.Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応</br>
        /// <br>Programmer : 22035 三橋  弘憲</br>
        /// <br>Date       : 2005.06.21</br>
        /// </remarks>
        private void ConsTaxRates3_tNedit_Leave(object sender, System.EventArgs e)
        {
          // 0を入力して出入りを繰り返すと表示が".0"になってしまう現象に対応
          Double value = ConsTaxRates3_tNedit.GetValue();
          if ((0 <= value) && (value < 1))
          {
            ConsTaxRates3_tNedit.SetValue(value); // 表示は"0.x"になる
          }
        }
                       --- DEL 2008/06/06 --------------------------------<<<<< */
        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 消費税率入力欄の入力チェックを桁数制御から最大値制御に変更</br>
        /// <br>Programmer : 20031 古賀　小百合</br>
        /// <br>Date       : 2007.04.02</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.NextCtrl == null) || (e.PrevCtrl == null)) return;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            switch (e.PrevCtrl.Name)
            {
            case "ConsTaxRates1_tNedit":
                {
                    double rate = 0;
                    if (!ConsTaxRates1_tNedit.Text.Equals(""))
                        rate = double.Parse(this.ConsTaxRates1_tNedit.Text);
                    if (rate > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "消費税率１の値が不正です。",
                            -1,
                            MessageBoxButtons.OK);
                        e.NextCtrl = e.PrevCtrl;
                        ConsTaxRates1_tNedit.SelectAll();
                    }
                    break;
                }
            case "ConsTaxRates2_tNedit":
                {
                    double rate = 0;
                    if (!ConsTaxRates2_tNedit.Text.Equals(""))
                        rate = double.Parse(this.ConsTaxRates2_tNedit.Text);
                    if (rate > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "消費税率２の値が不正です。",
                            -1,
                            MessageBoxButtons.OK);
                        e.NextCtrl = e.PrevCtrl;
                        ConsTaxRates2_tNedit.SelectAll();
                    }
                    break;
                }
            case "ConsTaxRates3_tNedit":
                {
                    double rate = 0;
                    if (!ConsTaxRates3_tNedit.Text.Equals(""))
                        rate = double.Parse(this.ConsTaxRates3_tNedit.Text);
                    if (rate > 999.9)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "消費税率３の値が不正です。",
                            -1,
                            MessageBoxButtons.OK);
                        e.NextCtrl = e.PrevCtrl;
                        ConsTaxRates3_tNedit.SelectAll();
                    }
                    break;
                }
                //----- ueno add---------- start 2008.02.18
                case "AutoPayMoneyKindCode_tComboEditor":
                    {
                        if (this.AutoPayMoneyKindCode_tComboEditor.Value != null)
                        {
                            AutoPayMoneyKindCodeVisibleChange((Int32)this.AutoPayMoneyKindCode_tComboEditor.Value);
                        }
                        break;
                    }
                //----- ueno add---------- end 2008.02.18

            }
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            if (e.PrevCtrl.Name == "AutoPayMoneyKindCode_tComboEditor")
            {
                if (this.AutoPayMoneyKindCode_tComboEditor.Value != null)
                {
                    AutoPayMoneyKindCodeVisibleChange((Int32)this.AutoPayMoneyKindCode_tComboEditor.Value);
                }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            else if (e.PrevCtrl.Name == "tEdit_SectionCodeAllowZero2")
            {
                // ----- ADD 2011/09/07 --------------------------------->>>>>
                // 拠点コードが存在していない場合、登録しない。
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text) && !SectionUtil.ExistsCode(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                    TMsgDisp.Show(
                        this, 								                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // エラーレベル
                        AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // アセンブリＩＤまたはクラスＩＤ
                        this.Text, 		                                        // プログラム名称
                        MethodBase.GetCurrentMethod().Name, 					// 処理名称
                        TMsgDisp.OPE_UPDATE, 				                    // オペレーション
                        SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // 表示するメッセージ
                        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// ステータス値
                        this,			                                        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK, 				                    // 表示するボタン
                        MessageBoxDefaultButton.Button1                         // 初期表示ボタン
                    );
                    isError = true; // ADD 2011/09/07
                    // 拠点コード、名称のクリア
                    tEdit_SectionCodeAllowZero2.Clear();
                    SectionNm_tEdit.Clear();
                    e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    return;
                }
                // ----- ADD 2011/09/07 ---------------------------------<<<<<
                // 拠点コード
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        # endregion

        /// <summary>
        /// AutoPayMoneyKindCode_tComboEditor_SelectionChangeCommitted イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 自動支払金種コードが変化したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.02.18</br>
        /// </remarks>
        private void AutoPayMoneyKindCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.AutoPayMoneyKindCode_tComboEditor.Value != null)
            {
                AutoPayMoneyKindCodeVisibleChange((Int32)this.AutoPayMoneyKindCode_tComboEditor.Value);
            }
        }

        /// <summary>
        /// 拠点コードガイドボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ガイド表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                // DEL 2008/10/08 不具合対応[6394] ↓
                if (status != 0) return;
                // ADD 2008/10/08 不具合対応[6394] ---------->>>>>
                if (status != 0)
                {
                    this.SectionGd_ultraButton.Focus();
                    return;
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> G.Miyatsu 2008.12.01 DEL
                    this.Cancel_Button.Focus();
                    //this.RgdsSlipPrtDiv_tComboEditor.Focus();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< G.Miyatsu 2008.12.01 DEL
                }
                // ADD 2008/10/08 不具合対応[6394] ----------<<<<<

                // 取得データ表示
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 完全削除ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "SFSIR09000U", 						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel, 		// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 復活ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 拠点コードEdit Leave処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点名称表示処理</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/05</br>
        /// </remarks>
        private void SectionCd_tEdit_Leave(object sender, EventArgs e)
        {
            // 拠点コード入力あり？
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // --- ADD 2008/09/29 --------------------------------->>>>>
                // --- UPD 2011/09/07 ------------------------->>>>>
                //if (this.tEdit_SectionCodeAllowZero2.Text == "00")
                if (this.tEdit_SectionCodeAllowZero2.Text == "00" || this.tEdit_SectionCodeAllowZero2.Text == "0")
                // --- UPD 2011/09/07 -------------------------<<<<<
                {
                    // DEL 2008/10/10 不具合対応[6530] ↓
                    //this.SectionNm_tEdit.Text = "全社設定";
                    this.SectionNm_tEdit.Value = "全社共通";    // ADD 2008/10/10 不具合対応[6530]
                    this.tEdit_SectionCodeAllowZero2.Text = "00"; // ADD 2011/09/07
                    return;
                }
                // --- ADD 2008/09/29 ---------------------------------<<<<<

                // 拠点コード名称設定
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // 拠点コード名称クリア
                this.SectionNm_tEdit.Text = "";
            }

            // --- ADD 2011/09/07 --------------------------------->>>>>
            if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
            }
            // --- ADD 2011/09/07 ---------------------------------<<<<<
        }

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            EventArgs e = new EventArgs();
            SectionCd_tEdit_Leave(null, e);

            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの仕入在庫全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[STOCKTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFSIR09000U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの仕入在庫全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの仕入在庫全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "SFSIR09000U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/07
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}

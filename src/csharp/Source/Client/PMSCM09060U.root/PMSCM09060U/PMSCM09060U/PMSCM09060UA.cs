//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM優先設定マスタ
// プログラム概要   : SCM優先設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
// Update Note      :    2011.08.08 lingxiaoqing                              //
//                  :    優先設定マスタを改良                                 // 
//----------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：wujun　　　　　　　　　　　　　　　　   //
// 修正日    2011/09/17     修正内容：仕様連絡 #25263　PCCUOE／PM側　PCC優先設定マスタの仕様変更
// ---------------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：liusy　　　　　　　　　　　　　　　　   //
// 修正日    2011/09/26     修正内容：仕様連絡 #25492　25263に戻る
// ---------------------------------------------------------------------------//
// 管理番号  10904597-00    作成担当：30744 湯上 千加子                       //
// 修正日    2013/12/16     修正内容：SCM仕掛一覧№10590対応                  //
//                                    ※画面のオブジェクト変更により
//                                      ソースコメントの「表示順」を「初期選択順」に変更します
//　　　　　　　　　　　　　　　　　　その他名称変更
// ---------------------------------------------------------------------------//
// 管理番号  11470103-00  作成担当 : 譚洪
// 作 成 日  2018/07/26   修正内容 : BLパーツオーダー自動回答不具合対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util; // ADD 2011/09/07

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM優先設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: SCM優先設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
    /// <br>Update Note:  2011.08.08 凌小青</br>
    /// <br>              優先設定マスタを改良</br>
    /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2018/07/26</br>
    /// <br></br>
    /// </remarks>
    public class PMSCM09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        //private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd1_uLabel;
        //private Broadleaf.Library.Windows.Forms.TComboEditor PriorPriceSetCd1_tComboEditor;
        //private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd2_uLabel;
        //private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd1_uLabel;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd2_uLabel;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        //private Infragistics.Win.Misc.UltraLabel SalesSlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd3_uLabel;
        // private TComboEditor PriorPriceSetCd3_tComboEditor;　
        // private TComboEditor PriorPriceSetCd2_tComboEditor;
        //private TComboEditor PrioritySetting_tComboEditor;    
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        //private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        //private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        //private TEdit tEdit_SectionCodeAllowZero; 
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private TComboEditor Discriminition_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TComboEditor SetKind_tComboEditor;
        private Panel panel_Customer;
        private Infragistics.Win.Misc.UltraLabel CustomerCode_Title_Label;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private TEdit CustomerCodeNm_tEdit;
        private TNedit tNedit_CustomerCode;
        private TComboEditor CampingCode_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TComboEditor InStock_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TComboEditor PureSuperio_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TComboEditor Order1_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Panel panel_Section;
        private Infragistics.Win.Misc.UltraLabel Section_uLabel;
        private TEdit tEdit_SectionCodeAllowZero2;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private TComboEditor PriorPriceSetCd3_tComboEditor;
        private TComboEditor PriorPriceSetCd2_tComboEditor;
        private TComboEditor PriorPriceSetCd1_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel00;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        //private Broadleaf.Library.Windows.Forms.TComboEditor PriorPriceSetCd2_tComboEditor;
        private TComboEditor Order7_ComboEditor;
        private TComboEditor Order6_ComboEditor;
        private TComboEditor Order5_ComboEditor;
        private TComboEditor Order4_ComboEditor;
        private TComboEditor Order3_ComboEditor;
        private TComboEditor Order2_ComboEditor;
        private TEdit SectionName_tEdit;
        #endregion

        #region -- Constructor --
        /// <summary>
        /// SCM優先設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: SCM優先設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public PMSCM09060UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._scmPriorStAcs = new SCMPriorStAcs();
            this._totalCount = 0;
            this._scmPriorStTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点設定アクセスクラス
            this._secInfoAcs = new SecInfoAcs();
        }
        #endregion

        private System.ComponentModel.IContainer components;

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

        #region -- Windows フォーム デザイナで生成されたコード --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem94 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem95 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem96 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem97 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem98 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem86 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem87 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem88 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem89 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem90 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem91 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem92 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem93 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem76 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem77 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem78 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem79 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem80 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem81 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem82 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem83 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem84 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem85 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem61 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem62 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem63 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem64 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem65 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem66 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem67 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem68 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem69 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem70 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem71 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem72 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem73 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem74 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem75 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem51 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem52 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem53 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem54 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem55 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem56 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem57 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem58 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem59 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem60 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem41 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem42 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem43 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem44 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem45 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem46 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem47 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem48 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem49 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem50 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem33 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem34 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem35 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem36 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem37 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem38 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem39 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem40 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09060UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.PriorPriceSetCd3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.Discriminition_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.SetKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.panel_Customer = new System.Windows.Forms.Panel();
            this.panel_Section = new System.Windows.Forms.Panel();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel00 = new Infragistics.Win.Misc.UltraLabel();
            this.CampingCode_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.InStock_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.PureSuperio_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.Order1_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PriorPriceSetCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PriorPriceSetCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.Order2_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order3_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order4_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order5_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order6_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order7_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discriminition_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).BeginInit();
            this.panel_Customer.SuspendLayout();
            this.panel_Section.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampingCode_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStock_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSuperio_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order1_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd3_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd2_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd1_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order2_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order3_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order4_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order5_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order6_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order7_ComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(317, 587);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 25;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(190, 587);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 24;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 634);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(461, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance137.ForeColor = System.Drawing.Color.White;
            appearance137.TextHAlignAsString = "Center";
            appearance137.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance137;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(325, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // PriorPriceSetCd1_uLabel
            // 
            appearance138.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd1_uLabel.Appearance = appearance138;
            this.PriorPriceSetCd1_uLabel.Location = new System.Drawing.Point(16, 269);
            this.PriorPriceSetCd1_uLabel.Name = "PriorPriceSetCd1_uLabel";
            this.PriorPriceSetCd1_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd1_uLabel.TabIndex = 179;
            this.PriorPriceSetCd1_uLabel.Text = "価格区分１";
            // 
            // PriorPriceSetCd2_uLabel
            // 
            appearance139.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd2_uLabel.Appearance = appearance139;
            this.PriorPriceSetCd2_uLabel.Location = new System.Drawing.Point(16, 298);
            this.PriorPriceSetCd2_uLabel.Name = "PriorPriceSetCd2_uLabel";
            this.PriorPriceSetCd2_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd2_uLabel.TabIndex = 183;
            this.PriorPriceSetCd2_uLabel.Text = "価格区分２";
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // PriorPriceSetCd3_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd3_uLabel.Appearance = appearance63;
            this.PriorPriceSetCd3_uLabel.Location = new System.Drawing.Point(16, 328);
            this.PriorPriceSetCd3_uLabel.Name = "PriorPriceSetCd3_uLabel";
            this.PriorPriceSetCd3_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd3_uLabel.TabIndex = 258;
            this.PriorPriceSetCd3_uLabel.Text = "価格区分３";
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 170);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(430, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(190, 587);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 24;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(59, 587);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 23;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(59, 587);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 23;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // Discriminition_ComboEditor
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Discriminition_ComboEditor.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.Discriminition_ComboEditor.Appearance = appearance7;
            this.Discriminition_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Discriminition_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Discriminition_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Discriminition_ComboEditor.ItemAppearance = appearance8;
            valueListItem94.DataValue = 0;
            valueListItem94.DisplayText = "共通";
            valueListItem95.DataValue = "1";
            valueListItem95.DisplayText = "PCC";
            valueListItem96.DataValue = "2";
            valueListItem96.DisplayText = "BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ";
            this.Discriminition_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem94,
            valueListItem95,
            valueListItem96});
            this.Discriminition_ComboEditor.Location = new System.Drawing.Point(171, 39);
            this.Discriminition_ComboEditor.Name = "Discriminition_ComboEditor";
            this.Discriminition_ComboEditor.Size = new System.Drawing.Size(254, 24);
            this.Discriminition_ComboEditor.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance34;
            this.ultraLabel2.Location = new System.Drawing.Point(17, 39);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel2.TabIndex = 1324;
            this.ultraLabel2.Text = "優先適用区分";
            // 
            // ultraLabel3
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance15;
            this.ultraLabel3.Location = new System.Drawing.Point(19, 69);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel3.TabIndex = 1323;
            this.ultraLabel3.Text = "設定種別";
            // 
            // SetKind_tComboEditor
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.SetKind_tComboEditor.Appearance = appearance65;
            this.SetKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SetKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SetKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ItemAppearance = appearance66;
            valueListItem97.DataValue = 0;
            valueListItem97.DisplayText = "拠点単位";
            valueListItem98.DataValue = 1;
            valueListItem98.DisplayText = "得意先単位";
            this.SetKind_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem97,
            valueListItem98});
            this.SetKind_tComboEditor.Location = new System.Drawing.Point(171, 69);
            this.SetKind_tComboEditor.Name = "SetKind_tComboEditor";
            this.SetKind_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.SetKind_tComboEditor.TabIndex = 2;
            this.SetKind_tComboEditor.ValueChanged += new System.EventHandler(this.SetKind_tComboEditor_ValueChanged);
            // 
            // tNedit_CustomerCode
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance135.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.ActiveAppearance = appearance135;
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance136;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "123456789";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(155, 1);
            this.tNedit_CustomerCode.MaxLength = 9;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 40;
            this.tNedit_CustomerCode.Text = "123456789";
            // 
            // CustomerCodeNm_tEdit
            // 
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance133.ForeColor = System.Drawing.Color.Black;
            appearance133.TextVAlignAsString = "Middle";
            this.CustomerCodeNm_tEdit.ActiveAppearance = appearance133;
            appearance134.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance134.ForeColor = System.Drawing.Color.Black;
            appearance134.ForeColorDisabled = System.Drawing.Color.Black;
            appearance134.TextVAlignAsString = "Middle";
            this.CustomerCodeNm_tEdit.Appearance = appearance134;
            this.CustomerCodeNm_tEdit.AutoSelect = true;
            this.CustomerCodeNm_tEdit.DataText = "";
            this.CustomerCodeNm_tEdit.Enabled = false;
            this.CustomerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCodeNm_tEdit.Location = new System.Drawing.Point(272, 1);
            this.CustomerCodeNm_tEdit.MaxLength = 20;
            this.CustomerCodeNm_tEdit.Name = "CustomerCodeNm_tEdit";
            this.CustomerCodeNm_tEdit.ReadOnly = true;
            this.CustomerCodeNm_tEdit.Size = new System.Drawing.Size(128, 24);
            this.CustomerCodeNm_tEdit.TabIndex = 100;
            this.CustomerCodeNm_tEdit.TabStop = false;
            // 
            // uButton_CustomerGuide
            // 
            appearance132.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance132.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CustomerGuide.Appearance = appearance132;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(241, 1);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerGuide.TabIndex = 3;
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.ub_St_CustomerGuide_Click);
            // 
            // CustomerCode_Title_Label
            // 
            appearance131.TextVAlignAsString = "Middle";
            this.CustomerCode_Title_Label.Appearance = appearance131;
            this.CustomerCode_Title_Label.Location = new System.Drawing.Point(2, 2);
            this.CustomerCode_Title_Label.Name = "CustomerCode_Title_Label";
            this.CustomerCode_Title_Label.Size = new System.Drawing.Size(136, 24);
            this.CustomerCode_Title_Label.TabIndex = 1313;
            this.CustomerCode_Title_Label.Text = "得意先コード";
            // 
            // panel_Customer
            // 
            this.panel_Customer.Controls.Add(this.CustomerCode_Title_Label);
            this.panel_Customer.Controls.Add(this.uButton_CustomerGuide);
            this.panel_Customer.Controls.Add(this.CustomerCodeNm_tEdit);
            this.panel_Customer.Controls.Add(this.tNedit_CustomerCode);
            this.panel_Customer.Location = new System.Drawing.Point(16, 99);
            this.panel_Customer.Name = "panel_Customer";
            this.panel_Customer.Size = new System.Drawing.Size(426, 30);
            this.panel_Customer.TabIndex = 1325;
            this.panel_Customer.Visible = false;
            // 
            // panel_Section
            // 
            this.panel_Section.Controls.Add(this.Section_uLabel);
            this.panel_Section.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.panel_Section.Controls.Add(this.SectionGuide_Button);
            this.panel_Section.Controls.Add(this.SectionName_tEdit);
            this.panel_Section.Location = new System.Drawing.Point(16, 99);
            this.panel_Section.Name = "panel_Section";
            this.panel_Section.Size = new System.Drawing.Size(426, 30);
            this.panel_Section.TabIndex = 3;
            // 
            // Section_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance22;
            this.Section_uLabel.Location = new System.Drawing.Point(3, 4);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(132, 24);
            this.Section_uLabel.TabIndex = 1324;
            this.Section_uLabel.Text = "拠点";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "00";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(154, 2);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(20, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 1;
            this.tEdit_SectionCodeAllowZero2.Text = "00";
            // 
            // SectionGuide_Button
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance12;
            this.SectionGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(184, 3);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // SectionName_tEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.Appearance = appearance2;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.Location = new System.Drawing.Point(214, 3);
            this.SectionName_tEdit.MaxLength = 20;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(35, 24);
            this.SectionName_tEdit.TabIndex = 100;
            this.SectionName_tEdit.TabStop = false;
            // 
            // ultraLabel00
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.ultraLabel00.Appearance = appearance30;
            this.ultraLabel00.Location = new System.Drawing.Point(170, 135);
            this.ultraLabel00.Name = "ultraLabel00";
            this.ultraLabel00.Size = new System.Drawing.Size(210, 23);
            this.ultraLabel00.TabIndex = 1328;
            this.ultraLabel00.Text = "※ゼロで共通設定になります";
            // 
            // CampingCode_ComboEditor
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampingCode_ComboEditor.ActiveAppearance = appearance92;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance93.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance93.ForeColorDisabled = System.Drawing.Color.Black;
            appearance93.TextVAlignAsString = "Middle";
            this.CampingCode_ComboEditor.Appearance = appearance93;
            this.CampingCode_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampingCode_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CampingCode_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampingCode_ComboEditor.ItemAppearance = appearance94;
            valueListItem86.DataValue = 0;
            valueListItem86.DisplayText = "全て";
            valueListItem87.DataValue = 1;
            valueListItem87.DisplayText = "キャンペーン";
            this.CampingCode_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem86,
            valueListItem87});
            this.CampingCode_ComboEditor.Location = new System.Drawing.Point(171, 238);
            this.CampingCode_ComboEditor.Name = "CampingCode_ComboEditor";
            this.CampingCode_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.CampingCode_ComboEditor.TabIndex = 8;
            // 
            // ultraLabel7
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance72;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 238);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel7.TabIndex = 1342;
            this.ultraLabel7.Text = "キャンペーン区分";
            // 
            // InStock_ComboEditor
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InStock_ComboEditor.ActiveAppearance = appearance95;
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance96.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance96.ForeColorDisabled = System.Drawing.Color.Black;
            appearance96.TextVAlignAsString = "Middle";
            this.InStock_ComboEditor.Appearance = appearance96;
            this.InStock_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.InStock_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.InStock_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InStock_ComboEditor.ItemAppearance = appearance97;
            valueListItem88.DataValue = 0;
            valueListItem88.DisplayText = "全て";
            valueListItem89.DataValue = 1;
            valueListItem89.DisplayText = "在庫";
            valueListItem90.DataValue = "2";
            valueListItem90.DisplayText = "委託・参照倉庫";
            valueListItem91.DataValue = "3";
            valueListItem91.DisplayText = "委託";
            this.InStock_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem88,
            valueListItem89,
            valueListItem90,
            valueListItem91});
            this.InStock_ComboEditor.Location = new System.Drawing.Point(171, 209);
            this.InStock_ComboEditor.Name = "InStock_ComboEditor";
            this.InStock_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.InStock_ComboEditor.TabIndex = 6;
            // 
            // ultraLabel8
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance76;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 209);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(77, 24);
            this.ultraLabel8.TabIndex = 1340;
            this.ultraLabel8.Text = "在庫区分";
            this.ultraLabel8.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            // 
            // PureSuperio_ComboEditor
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PureSuperio_ComboEditor.ActiveAppearance = appearance98;
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance99.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance99.ForeColorDisabled = System.Drawing.Color.Black;
            appearance99.TextVAlignAsString = "Middle";
            this.PureSuperio_ComboEditor.Appearance = appearance99;
            this.PureSuperio_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PureSuperio_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PureSuperio_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PureSuperio_ComboEditor.ItemAppearance = appearance100;
            valueListItem92.DataValue = 0;
            valueListItem92.DisplayText = "全て";
            valueListItem93.DataValue = 1;
            valueListItem93.DisplayText = "純正";
            this.PureSuperio_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem92,
            valueListItem93});
            this.PureSuperio_ComboEditor.Location = new System.Drawing.Point(171, 179);
            this.PureSuperio_ComboEditor.Name = "PureSuperio_ComboEditor";
            this.PureSuperio_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PureSuperio_ComboEditor.TabIndex = 4;
            // 
            // ultraLabel9
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance80;
            this.ultraLabel9.Location = new System.Drawing.Point(18, 179);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(77, 24);
            this.ultraLabel9.TabIndex = 1338;
            this.ultraLabel9.Text = "純優区分";
            // 
            // Order1_ComboEditor
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order1_ComboEditor.ActiveAppearance = appearance60;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            appearance67.TextVAlignAsString = "Middle";
            this.Order1_ComboEditor.Appearance = appearance67;
            this.Order1_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order1_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order1_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order1_ComboEditor.ItemAppearance = appearance68;
            valueListItem76.DataValue = 0;
            valueListItem76.DisplayText = "なし";
            valueListItem77.DataValue = 1;
            valueListItem77.DisplayText = "粗利率(高)";
            valueListItem78.DataValue = "2";
            valueListItem78.DisplayText = "単価(高)";
            valueListItem79.DataValue = "3";
            valueListItem79.DisplayText = "定価(高)";
            valueListItem80.DataValue = "4";
            valueListItem80.DisplayText = "定価(低)";
            valueListItem81.DataValue = "5";
            valueListItem81.DisplayText = "キャンペーン";
            valueListItem82.DataValue = "6";
            valueListItem82.DisplayText = "在庫";
            valueListItem83.DataValue = "7";
            valueListItem83.DisplayText = "委託";
            valueListItem84.DataValue = "8";
            valueListItem84.DisplayText = "参照倉庫";
            valueListItem85.DataValue = "9";
            valueListItem85.DisplayText = "優良設定";
            this.Order1_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem76,
            valueListItem77,
            valueListItem78,
            valueListItem79,
            valueListItem80,
            valueListItem81,
            valueListItem82,
            valueListItem83,
            valueListItem84,
            valueListItem85});
            this.Order1_ComboEditor.Location = new System.Drawing.Point(171, 367);
            this.Order1_ComboEditor.MaxDropDownItems = 10;
            this.Order1_ComboEditor.Name = "Order1_ComboEditor";
            this.Order1_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order1_ComboEditor.TabIndex = 16;
            // 
            // ultraLabel18
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance25;
            this.ultraLabel18.Location = new System.Drawing.Point(16, 367);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel18.TabIndex = 1374;
            this.ultraLabel18.Text = "初期選択順１";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel10.Location = new System.Drawing.Point(16, 358);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(430, 3);
            this.ultraLabel10.TabIndex = 1382;
            // 
            // PriorPriceSetCd3_tComboEditor
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd3_tComboEditor.ActiveAppearance = appearance87;
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd3_tComboEditor.Appearance = appearance88;
            this.PriorPriceSetCd3_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd3_tComboEditor.ItemAppearance = appearance89;
            valueListItem61.DataValue = 0;
            valueListItem61.DisplayText = "なし";
            valueListItem62.DataValue = 1;
            valueListItem62.DisplayText = "粗利率(高)";
            valueListItem63.DataValue = "2";
            valueListItem63.DisplayText = "単価(高)";
            valueListItem64.DataValue = "3";
            valueListItem64.DisplayText = "定価(高)";
            valueListItem65.DataValue = "4";
            valueListItem65.DisplayText = "定価(低)";
            this.PriorPriceSetCd3_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem61,
            valueListItem62,
            valueListItem63,
            valueListItem64,
            valueListItem65});
            this.PriorPriceSetCd3_tComboEditor.Location = new System.Drawing.Point(171, 328);
            this.PriorPriceSetCd3_tComboEditor.Name = "PriorPriceSetCd3_tComboEditor";
            this.PriorPriceSetCd3_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd3_tComboEditor.TabIndex = 14;
            // 
            // PriorPriceSetCd2_tComboEditor
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd2_tComboEditor.ActiveAppearance = appearance90;
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance91.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance91.ForeColorDisabled = System.Drawing.Color.Black;
            appearance91.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd2_tComboEditor.Appearance = appearance91;
            this.PriorPriceSetCd2_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd2_tComboEditor.ItemAppearance = appearance102;
            valueListItem66.DataValue = 0;
            valueListItem66.DisplayText = "なし";
            valueListItem67.DataValue = 1;
            valueListItem67.DisplayText = "粗利率(高)";
            valueListItem68.DataValue = "2";
            valueListItem68.DisplayText = "単価(高)";
            valueListItem69.DataValue = "3";
            valueListItem69.DisplayText = "定価(高)";
            valueListItem70.DataValue = "4";
            valueListItem70.DisplayText = "定価(低)";
            this.PriorPriceSetCd2_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem66,
            valueListItem67,
            valueListItem68,
            valueListItem69,
            valueListItem70});
            this.PriorPriceSetCd2_tComboEditor.Location = new System.Drawing.Point(171, 298);
            this.PriorPriceSetCd2_tComboEditor.Name = "PriorPriceSetCd2_tComboEditor";
            this.PriorPriceSetCd2_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd2_tComboEditor.TabIndex = 12;
            // 
            // PriorPriceSetCd1_tComboEditor
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd1_tComboEditor.ActiveAppearance = appearance103;
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            appearance104.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd1_tComboEditor.Appearance = appearance104;
            this.PriorPriceSetCd1_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd1_tComboEditor.ItemAppearance = appearance105;
            valueListItem71.DataValue = 0;
            valueListItem71.DisplayText = "なし";
            valueListItem72.DataValue = 1;
            valueListItem72.DisplayText = "粗利率(高)";
            valueListItem73.DataValue = "2";
            valueListItem73.DisplayText = "単価(高)";
            valueListItem74.DataValue = "3";
            valueListItem74.DisplayText = "定価(高)";
            valueListItem75.DataValue = "4";
            valueListItem75.DisplayText = "定価(低)";
            this.PriorPriceSetCd1_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem71,
            valueListItem72,
            valueListItem73,
            valueListItem74,
            valueListItem75});
            this.PriorPriceSetCd1_tComboEditor.Location = new System.Drawing.Point(171, 269);
            this.PriorPriceSetCd1_tComboEditor.Name = "PriorPriceSetCd1_tComboEditor";
            this.PriorPriceSetCd1_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd1_tComboEditor.TabIndex = 10;
            // 
            // ultraLabel1
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance24;
            this.ultraLabel1.Location = new System.Drawing.Point(16, 397);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel1.TabIndex = 1387;
            this.ultraLabel1.Text = "初期選択順２";
            // 
            // ultraLabel6
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance21;
            this.ultraLabel6.Location = new System.Drawing.Point(16, 457);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel6.TabIndex = 1389;
            this.ultraLabel6.Text = "初期選択順４";
            // 
            // ultraLabel11
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance23;
            this.ultraLabel11.Location = new System.Drawing.Point(16, 427);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel11.TabIndex = 1388;
            this.ultraLabel11.Text = "初期選択順３";
            // 
            // ultraLabel12
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance4;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 517);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel12.TabIndex = 1391;
            this.ultraLabel12.Text = "初期選択順６";
            // 
            // ultraLabel13
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance16;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 487);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel13.TabIndex = 1390;
            this.ultraLabel13.Text = "初期選択順５";
            // 
            // ultraLabel15
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance3;
            this.ultraLabel15.Location = new System.Drawing.Point(16, 547);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel15.TabIndex = 1392;
            this.ultraLabel15.Text = "初期選択順７";
            // 
            // Order2_ComboEditor
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order2_ComboEditor.ActiveAppearance = appearance45;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance58.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance58.ForeColorDisabled = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.Order2_ComboEditor.Appearance = appearance58;
            this.Order2_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order2_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order2_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order2_ComboEditor.ItemAppearance = appearance59;
            valueListItem51.DataValue = 0;
            valueListItem51.DisplayText = "なし";
            valueListItem52.DataValue = 1;
            valueListItem52.DisplayText = "粗利率(高)";
            valueListItem53.DataValue = "2";
            valueListItem53.DisplayText = "単価(高)";
            valueListItem54.DataValue = "3";
            valueListItem54.DisplayText = "定価(高)";
            valueListItem55.DataValue = "4";
            valueListItem55.DisplayText = "定価(低)";
            valueListItem56.DataValue = "5";
            valueListItem56.DisplayText = "キャンペーン";
            valueListItem57.DataValue = "6";
            valueListItem57.DisplayText = "在庫";
            valueListItem58.DataValue = "7";
            valueListItem58.DisplayText = "委託";
            valueListItem59.DataValue = "8";
            valueListItem59.DisplayText = "参照倉庫";
            valueListItem60.DataValue = "9";
            valueListItem60.DisplayText = "優良設定";
            this.Order2_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem51,
            valueListItem52,
            valueListItem53,
            valueListItem54,
            valueListItem55,
            valueListItem56,
            valueListItem57,
            valueListItem58,
            valueListItem59,
            valueListItem60});
            this.Order2_ComboEditor.Location = new System.Drawing.Point(171, 397);
            this.Order2_ComboEditor.MaxDropDownItems = 10;
            this.Order2_ComboEditor.Name = "Order2_ComboEditor";
            this.Order2_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order2_ComboEditor.TabIndex = 17;
            // 
            // Order3_ComboEditor
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order3_ComboEditor.ActiveAppearance = appearance42;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.Order3_ComboEditor.Appearance = appearance43;
            this.Order3_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order3_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order3_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order3_ComboEditor.ItemAppearance = appearance44;
            valueListItem41.DataValue = 0;
            valueListItem41.DisplayText = "なし";
            valueListItem42.DataValue = 1;
            valueListItem42.DisplayText = "粗利率(高)";
            valueListItem43.DataValue = "2";
            valueListItem43.DisplayText = "単価(高)";
            valueListItem44.DataValue = "3";
            valueListItem44.DisplayText = "定価(高)";
            valueListItem45.DataValue = "4";
            valueListItem45.DisplayText = "定価(低)";
            valueListItem46.DataValue = "5";
            valueListItem46.DisplayText = "キャンペーン";
            valueListItem47.DataValue = "6";
            valueListItem47.DisplayText = "在庫";
            valueListItem48.DataValue = "7";
            valueListItem48.DisplayText = "委託";
            valueListItem49.DataValue = "8";
            valueListItem49.DisplayText = "参照倉庫";
            valueListItem50.DataValue = "9";
            valueListItem50.DisplayText = "優良設定";
            this.Order3_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem41,
            valueListItem42,
            valueListItem43,
            valueListItem44,
            valueListItem45,
            valueListItem46,
            valueListItem47,
            valueListItem48,
            valueListItem49,
            valueListItem50});
            this.Order3_ComboEditor.Location = new System.Drawing.Point(171, 427);
            this.Order3_ComboEditor.MaxDropDownItems = 10;
            this.Order3_ComboEditor.Name = "Order3_ComboEditor";
            this.Order3_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order3_ComboEditor.TabIndex = 18;
            // 
            // Order4_ComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order4_ComboEditor.ActiveAppearance = appearance36;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.Order4_ComboEditor.Appearance = appearance38;
            this.Order4_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order4_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order4_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order4_ComboEditor.ItemAppearance = appearance39;
            valueListItem31.DataValue = 0;
            valueListItem31.DisplayText = "なし";
            valueListItem32.DataValue = 1;
            valueListItem32.DisplayText = "粗利率(高)";
            valueListItem33.DataValue = "2";
            valueListItem33.DisplayText = "単価(高)";
            valueListItem34.DataValue = "3";
            valueListItem34.DisplayText = "定価(高)";
            valueListItem35.DataValue = "4";
            valueListItem35.DisplayText = "定価(低)";
            valueListItem36.DataValue = "5";
            valueListItem36.DisplayText = "キャンペーン";
            valueListItem37.DataValue = "6";
            valueListItem37.DisplayText = "在庫";
            valueListItem38.DataValue = "7";
            valueListItem38.DisplayText = "委託";
            valueListItem39.DataValue = "8";
            valueListItem39.DisplayText = "参照倉庫";
            valueListItem40.DataValue = "9";
            valueListItem40.DisplayText = "優良設定";
            this.Order4_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem31,
            valueListItem32,
            valueListItem33,
            valueListItem34,
            valueListItem35,
            valueListItem36,
            valueListItem37,
            valueListItem38,
            valueListItem39,
            valueListItem40});
            this.Order4_ComboEditor.Location = new System.Drawing.Point(171, 457);
            this.Order4_ComboEditor.MaxDropDownItems = 10;
            this.Order4_ComboEditor.Name = "Order4_ComboEditor";
            this.Order4_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order4_ComboEditor.TabIndex = 19;
            // 
            // Order5_ComboEditor
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order5_ComboEditor.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.Order5_ComboEditor.Appearance = appearance32;
            this.Order5_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order5_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order5_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order5_ComboEditor.ItemAppearance = appearance35;
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "なし";
            valueListItem22.DataValue = 1;
            valueListItem22.DisplayText = "粗利率(高)";
            valueListItem23.DataValue = "2";
            valueListItem23.DisplayText = "単価(高)";
            valueListItem24.DataValue = "3";
            valueListItem24.DisplayText = "定価(高)";
            valueListItem25.DataValue = "4";
            valueListItem25.DisplayText = "定価(低)";
            valueListItem26.DataValue = "5";
            valueListItem26.DisplayText = "キャンペーン";
            valueListItem27.DataValue = "6";
            valueListItem27.DisplayText = "在庫";
            valueListItem28.DataValue = "7";
            valueListItem28.DisplayText = "委託";
            valueListItem29.DataValue = "8";
            valueListItem29.DisplayText = "参照倉庫";
            valueListItem30.DataValue = "9";
            valueListItem30.DisplayText = "優良設定";
            this.Order5_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem21,
            valueListItem22,
            valueListItem23,
            valueListItem24,
            valueListItem25,
            valueListItem26,
            valueListItem27,
            valueListItem28,
            valueListItem29,
            valueListItem30});
            this.Order5_ComboEditor.Location = new System.Drawing.Point(171, 487);
            this.Order5_ComboEditor.MaxDropDownItems = 10;
            this.Order5_ComboEditor.Name = "Order5_ComboEditor";
            this.Order5_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order5_ComboEditor.TabIndex = 20;
            // 
            // Order6_ComboEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order6_ComboEditor.ActiveAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.Order6_ComboEditor.Appearance = appearance28;
            this.Order6_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order6_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order6_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order6_ComboEditor.ItemAppearance = appearance29;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "なし";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "粗利率(高)";
            valueListItem13.DataValue = "2";
            valueListItem13.DisplayText = "単価(高)";
            valueListItem14.DataValue = "3";
            valueListItem14.DisplayText = "定価(高)";
            valueListItem15.DataValue = "4";
            valueListItem15.DisplayText = "定価(低)";
            valueListItem16.DataValue = "5";
            valueListItem16.DisplayText = "キャンペーン";
            valueListItem17.DataValue = "6";
            valueListItem17.DisplayText = "在庫";
            valueListItem18.DataValue = "7";
            valueListItem18.DisplayText = "委託";
            valueListItem19.DataValue = "8";
            valueListItem19.DisplayText = "参照倉庫";
            valueListItem20.DataValue = "9";
            valueListItem20.DisplayText = "優良設定";
            this.Order6_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16,
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20});
            this.Order6_ComboEditor.Location = new System.Drawing.Point(171, 517);
            this.Order6_ComboEditor.MaxDropDownItems = 10;
            this.Order6_ComboEditor.Name = "Order6_ComboEditor";
            this.Order6_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order6_ComboEditor.TabIndex = 21;
            // 
            // Order7_ComboEditor
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order7_ComboEditor.ActiveAppearance = appearance37;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.Order7_ComboEditor.Appearance = appearance40;
            this.Order7_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order7_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order7_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order7_ComboEditor.ItemAppearance = appearance41;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "なし";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "粗利率(高)";
            valueListItem3.DataValue = "2";
            valueListItem3.DisplayText = "単価(高)";
            valueListItem4.DataValue = "3";
            valueListItem4.DisplayText = "定価(高)";
            valueListItem5.DataValue = "4";
            valueListItem5.DisplayText = "定価(低)";
            valueListItem6.DataValue = "5";
            valueListItem6.DisplayText = "キャンペーン";
            valueListItem7.DataValue = "6";
            valueListItem7.DisplayText = "在庫";
            valueListItem8.DataValue = "7";
            valueListItem8.DisplayText = "委託";
            valueListItem9.DataValue = "8";
            valueListItem9.DisplayText = "参照倉庫";
            valueListItem10.DataValue = "9";
            valueListItem10.DisplayText = "優良設定";
            this.Order7_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.Order7_ComboEditor.Location = new System.Drawing.Point(171, 547);
            this.Order7_ComboEditor.MaxDropDownItems = 10;
            this.Order7_ComboEditor.Name = "Order7_ComboEditor";
            this.Order7_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order7_ComboEditor.TabIndex = 22;
            // 
            // PMSCM09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(461, 657);
            this.Controls.Add(this.ultraLabel00);
            this.Controls.Add(this.Order7_ComboEditor);
            this.Controls.Add(this.Order6_ComboEditor);
            this.Controls.Add(this.Order5_ComboEditor);
            this.Controls.Add(this.Order4_ComboEditor);
            this.Controls.Add(this.panel_Section);
            this.Controls.Add(this.Order3_ComboEditor);
            this.Controls.Add(this.Order2_ComboEditor);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PriorPriceSetCd3_tComboEditor);
            this.Controls.Add(this.PriorPriceSetCd2_tComboEditor);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.PriorPriceSetCd1_tComboEditor);
            this.Controls.Add(this.Order1_ComboEditor);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.CampingCode_ComboEditor);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.InStock_ComboEditor);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.PureSuperio_ComboEditor);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.panel_Customer);
            this.Controls.Add(this.Discriminition_ComboEditor);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.SetKind_tComboEditor);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.PriorPriceSetCd3_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PriorPriceSetCd2_uLabel);
            this.Controls.Add(this.PriorPriceSetCd1_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSCM09060UA";
            this.Text = "PCC優先設定";
            this.Load += new System.EventHandler(this.PMSCM09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discriminition_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).EndInit();
            this.panel_Customer.ResumeLayout(false);
            this.panel_Customer.PerformLayout();
            this.panel_Section.ResumeLayout(false);
            this.panel_Section.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampingCode_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStock_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSuperio_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order1_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd3_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd2_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd1_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order2_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order3_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order4_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order5_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order6_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order7_ComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        private SCMPriorStAcs _scmPriorStAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _scmPriorStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private SCMPriorSt _scmPriorStClone;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private bool isError = false; // ADD 2011/09/07

        //------------ADD BY lingxiaoqing  2011.08.08-------------------------->>>>>>>>>>>>>>
        private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();
        private CustomerInfo _customerInfo = new CustomerInfo();
        private string _customerName = string.Empty;
        private Hashtable _customersList = new Hashtable();
        private bool _isNewSave = false;
        private bool _cusModeFlg = false;
        //------------ADD BY lingxiaoqing 2011.08.08-------------------------<<<<<<<<<<<<<<<<

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09060U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";
        private const string VIEW_CUSTOMER_CODE_TITLE = "得意先コード";
        private const string VIEW_CUSTOMER_NAME_TITLE = "得意先名称";

        // ----------DELETE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        //private const string VIEW_PRIORITY_SETTING = "優先設定";
        //private const string VIEW_PRIOR_PRICE_SET1 = "優先価格設定１";
        //private const string VIEW_PRIOR_PRICE_SET2 = "優先価格設定２";
        //private const string VIEW_PRIOR_PRICE_SET3 = "優先価格設定３";
        // ----------DELETE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        // ----------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        private const string VIEW_PRIORITY_DISCRIMITION = "優先適用区分";
        // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
        //private const string VIEW_PRIOR_PRICE_SET1 = "選択時価格区分１";
        //private const string VIEW_PRIOR_PRICE_SET2 = "選択時価格区分２";
        //private const string VIEW_PRIOR_PRICE_SET3 = "選択時価格区分３";
        private const string VIEW_PRIOR_PRICE_SET1 = "価格区分１";
        private const string VIEW_PRIOR_PRICE_SET2 = "価格区分２";
        private const string VIEW_PRIOR_PRICE_SET3 = "価格区分３";
        // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
        //private const string VIEW_PRIOR_PRICE_SET4 = "非選択時価格区分１";
        //private const string VIEW_PRIOR_PRICE_SET5 = "非選択時価格区分２";
        //private const string VIEW_PRIOR_PRICE_SET6 = "非選択時価格区分３";
        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
        // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
        //private const string VIEW_PRIOR_SUPERIO1 = "選択時純優区分";
        //private const string VIEW_PRIOR_SUPERIO2 = "選択時在庫区分";
        //private const string VIEW_PRIOR_SUPERIO3 = "選択時キャンペーン区分";
        private const string VIEW_PRIOR_SUPERIO1 = "純優区分";
        private const string VIEW_PRIOR_SUPERIO2 = "在庫区分";
        private const string VIEW_PRIOR_SUPERIO3 = "キャンペーン区分";
        // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
        //private const string VIEW_PRIOR_SUPERIO4 = "非選択時純優区分";
        //private const string VIEW_PRIOR_SUPERIO5 = "非選択時在庫区分";
        //private const string VIEW_PRIOR_SUPERIO6 = "非選択時キャンペーン区分";
        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
        private const string VIEW_PRIOR_ORDER1 = "初期選択順１";
        private const string VIEW_PRIOR_ORDER2 = "初期選択順２";
        private const string VIEW_PRIOR_ORDER3 = "初期選択順３";
        private const string VIEW_PRIOR_ORDER4 = "初期選択順４";
        private const string VIEW_PRIOR_ORDER5 = "初期選択順５";
        private const string VIEW_PRIOR_ORDER6 = "初期選択順６";
        private const string VIEW_PRIOR_ORDER7 = "初期選択順７";
        private const string ct_NO_MESSAGE = "なし";
        // ----------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";

        // 優先(価格)設定名称
        private const string ct_PRIORITY_NAME0 = "なし";
        private const string ct_PRIORITY_NAME1 = "粗利率(高)";
        private const string ct_PRIORITY_NAME2 = "単価(高)";
        private const string ct_PRIORITY_NAME3 = "定価(高)";
        private const string ct_PRIORITY_NAME4 = "定価(低)";
        private const string ct_PRIORITY_NAME5 = "キャンペーン";
        private const string ct_PRIORITY_NAME6 = "在庫";
        private const string ct_PRIORITY_NAME7 = "委託";//ADD BY  lingxiaoqing    2011.08.08

        private const string ct_PRIORITY_NAME50 = "キャンペーン";
        private const string ct_PRIORITY_NAME56 = "キャンペーン→在庫";
        private const string ct_PRIORITY_NAME60 = "在庫";
        private const string ct_PRIORITY_NAME65 = "在庫→キャンペーン";
        // ----------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        private const string ct_ORDER_MESSAGE1 = "同じ初期選択順は一つ以上設定されることができません。";
        private const string ct_ORDER_MESSAGE2 = "定価(高)と定価(低)はどちらかしか設定できません。";
        // ----------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        // 最大優先設定数
        private const int MAX_PRIOR_PRICE_SET = 3;

        #endregion

        #region -- Main --
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMSCM09060UA());
        }
        # endregion

        #region -- Properties --
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
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

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
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

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Methods --
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmPriorStTable.Clear();

            // 全検索
            status = this._scmPriorStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;

                        foreach (SCMPriorSt scmPriorSt in retList)
                        {
                            //--------ADD BY lingxiaoqing 2011.08.08  検索得意先略称----------->>>>>>>>>>>>>>
                            if (scmPriorSt.CustomerCode != 0)
                            {
                                if (!_customersList.Contains(scmPriorSt.CustomerCode))
                                {
                                    status = _customerInfoAcs.ReadDBData(_enterpriseCode, scmPriorSt.CustomerCode, out _customerInfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        if (!_customersList.Contains(scmPriorSt.CustomerCode))
                                        {
                                            _customersList.Add(scmPriorSt.CustomerCode, _customerInfo.CustomerSnm);
                                        }
                                    }
                                    else
                                    {
                                        this._customerName = string.Empty;
                                    }
                                }
                            }
                            else
                            {
                                this._customerName = string.Empty;
                            }
                            //--------ADD BY lingxiaoqing 2011.08.08 -----------------------<<<<<<<<<<<<<
                            // SCM優先設定情報クラスのデータセット展開処理
                            SCMPriorStToDataSet(scmPriorSt.Clone(), index);
                            ++index;
                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; //ADD BY lingxiaoqing 2011.08.08
                        break;
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            PROGRAM_ID,							    // アセンブリID
                            this.Text,              　　            // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._scmPriorStAcs,					    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

            //-------DELETE BY lingxiaoqing 2011.08.08------------->>>>>>>>>>>>>
            // 全社共通データは削除不可
            //if (scmPriorSt.SectionCode.Trim() == ALL_SECTIONCODE)
            //{
            //    TMsgDisp.Show(this,                             // 親ウィンドウフォーム
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
            //            PROGRAM_ID,							    // アセンブリID
            //            "全社共通データは削除できません。",	    // 表示するメッセージ
            //            0,									    // ステータス値
            //            MessageBoxButtons.OK);					// 表示するボタン
            //    return (0);
            //}
            //-------DELETE BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<
            //-------ADD BY lingxiaoqing 2011.08.08------------->>>>>>>>>>>>>
            if (scmPriorSt.CustomerCode == 0)
            {
                // 全社共通データは削除不可
                if (scmPriorSt.SectionCode.Trim() == ALL_SECTIONCODE)
                {
                    TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            PROGRAM_ID,							    // アセンブリID
                            "全社共通データは削除できません。",	    // 表示するメッセージ
                            0,									    // ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                    return (0);
                }
            }
            //-------ADD BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<<<<
            int status;

            // SCM優先設定情報の論理削除処理
            status = this._scmPriorStAcs.LogicalDelete(ref scmPriorSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmPriorStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // SCM優先設定情報クラスのデータセット展開処理
            SCMPriorStToDataSet(scmPriorSt.Clone(), this.DataIndex);

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // -------DELETE BY lingxiaoqing 2011.08.08------------>>>>>>>>>>
            // 優先設定
            //appearanceTable.Add(VIEW_PRIORITY_SETTING, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 優先価格設定１
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 優先価格設定２
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 優先価格設定３
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // -------DELETE BY lingxiaoqing 2011.08.08------------<<<<<<<<<
            //-----------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            //得意先コード
            appearanceTable.Add(VIEW_CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //得意先名称
            appearanceTable.Add(VIEW_CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 優先適用区分
            appearanceTable.Add(VIEW_PRIORITY_DISCRIMITION, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //選択時対象純優区分
            appearanceTable.Add(VIEW_PRIOR_SUPERIO1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象純優区分
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //選択時対象在庫区分
            appearanceTable.Add(VIEW_PRIOR_SUPERIO2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象在庫区分
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //選択時対象キャンペーン区分
            appearanceTable.Add(VIEW_PRIOR_SUPERIO3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象キャンペーン区分
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 選択時対象価格区分１
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //// 非選択時対象価格区分１
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 選択時対象価格区分２
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //// 非選択時対象価格区分２
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 選択時対象価格区分３
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //// 非選択時対象価格区分３
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //初期選択順1
            appearanceTable.Add(VIEW_PRIOR_ORDER1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順2
            appearanceTable.Add(VIEW_PRIOR_ORDER2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順3
            appearanceTable.Add(VIEW_PRIOR_ORDER3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順4
            appearanceTable.Add(VIEW_PRIOR_ORDER4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順5
            appearanceTable.Add(VIEW_PRIOR_ORDER5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順6
            appearanceTable.Add(VIEW_PRIOR_ORDER6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //初期選択順7
            appearanceTable.Add(VIEW_PRIOR_ORDER7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //-----------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SCMPriorSt scmPriorSt = new SCMPriorSt();
                //クローン作成
                this._scmPriorStClone = scmPriorSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToSCMPriorSt(ref this._scmPriorStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                //this.tEdit_SectionCodeAllowZero.Focus(); //DELETE BY lingxiaoqing  2011.08.08
                this.Discriminition_ComboEditor.Focus();  //ADD BY lingxiaoqing  2011.08.08
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

                // SCM優先設定クラス画面展開処理
                SCMPriorStToScreen(scmPriorSt);

                if (scmPriorSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    //this.PrioritySetting_tComboEditor.Focus();  //DELETE BY lingxiaoqing 2011.08.08  

                    // クローン作成
                    this._scmPriorStClone = scmPriorSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSCMPriorSt(ref this._scmPriorStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;
                        //this.PrioritySetting_tComboEditor.Enabled = true;  //DELETE BY lingxiaoqing 2011.08.08                      
                        //---------ADD BY lingxiaoqing  2011.08.08------------------>>>>>>>>>>
                        this.SetKind_tComboEditor.Enabled = false;
                        this.PureSuperio_ComboEditor.Enabled = true;
                        //this.PureSuperio1_ComboEditor.Enabled = true; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.InStock_ComboEditor.Enabled = true;
                        //this.InStock1_ComboEditor.Enabled = true; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.CampingCode_ComboEditor.Enabled = true;
                        //this.CampingCode1_ComboEditor.Enabled = true; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.PriorPriceSetCd1_tComboEditor.Enabled = true;
                        this.PriorPriceSetCd2_tComboEditor.Enabled = true;
                        this.PriorPriceSetCd3_tComboEditor.Enabled = true;
                        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                        //this.PriorPriceSetCd4_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd5_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd6_tComboEditor.Enabled = true;
                        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
                        this.Order1_ComboEditor.Enabled = true;
                        this.Order2_ComboEditor.Enabled = true;
                        this.Order3_ComboEditor.Enabled = true;
                        this.Order4_ComboEditor.Enabled = true;
                        this.Order5_ComboEditor.Enabled = true;
                        this.Order6_ComboEditor.Enabled = true;
                        this.Order7_ComboEditor.Enabled = true;
                        //---------ADD BY lingxiaoqing   2011.08.08---------------<<<<<<<<<<<<
                        //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        //this.PrioritySetting_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd1_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd2_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd3_tComboEditor.Enabled = true;
                        //-----------DELETE BY lingxiaoqing  2011.08.08-----------<<<<<<<<<<<<<

                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.tEdit_SectionCodeAllowZero2.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                            //-----------ADD BY lingxiaoqing  2011.08.08--------->>>>>>>>>>>>
                            this.SetKind_tComboEditor.Enabled = true;
                            this.tNedit_CustomerCode.Enabled = true;
                            this.uButton_CustomerGuide.Enabled = true;
                            this.Discriminition_ComboEditor.Enabled = true;
                            //-----------ADD BY lingxiaoqing  2011.08.08----------<<<<<<<<<<<
                        }
                        else
                        {
                            // 更新モード
                            //this.tEdit_SectionCodeAllowZero.Enabled = false;  //DELETE BY lingxiaoqing  2011.08.08 
                            //this.SectionGuide_Button.Enabled = false;  //DELETE BY lingxiaoqing 2011.08.08
                            //-----------ADD BY lingxiaoqing  2011.08.08--------->>>>>>>>>>>>
                            if (this.SetKind_tComboEditor.SelectedIndex == 0)
                            {
                                this.tEdit_SectionCodeAllowZero2.Enabled = false;
                                this.SectionGuide_Button.Enabled = false;
                            }
                            else
                            {
                                this.tNedit_CustomerCode.Enabled = false;
                                this.uButton_CustomerGuide.Enabled = false;
                            }
                            this.Discriminition_ComboEditor.Enabled = false;
                            //-----------ADD BY lingxiaoqing  2011.08.08----------<<<<<<<<<<<
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        //this.PrioritySetting_tComboEditor.Enabled = false; //DELETE BY lingxiaoqing  2011.08.08
                        //---------ADD BY lingxiaoqing  2011.08.08------------------>>>>>>>>>>
                        this.PureSuperio_ComboEditor.Enabled = false;
                        //this.PureSuperio1_ComboEditor.Enabled = false; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.InStock_ComboEditor.Enabled = false;
                        //this.InStock1_ComboEditor.Enabled = false; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.CampingCode_ComboEditor.Enabled = false;
                        //this.CampingCode1_ComboEditor.Enabled = false; // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
                        this.PriorPriceSetCd1_tComboEditor.Enabled = false;
                        this.PriorPriceSetCd2_tComboEditor.Enabled = false;
                        this.PriorPriceSetCd3_tComboEditor.Enabled = false;
                        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                        //this.PriorPriceSetCd4_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd5_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd6_tComboEditor.Enabled = false;
                        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
                        this.Order1_ComboEditor.Enabled = false;
                        this.Order2_ComboEditor.Enabled = false;
                        this.Order3_ComboEditor.Enabled = false;
                        this.Order4_ComboEditor.Enabled = false;
                        this.Order5_ComboEditor.Enabled = false;
                        this.Order6_ComboEditor.Enabled = false;
                        this.Order7_ComboEditor.Enabled = false;
                        //---------ADD BY lingxiaoqing  2011.08.08-------------------------<<<<<<<<<<<<
                        //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        //this.PrioritySetting_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd1_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd2_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd3_tComboEditor.Enabled = false;
                        //-----------DELETE BY lingxiaoqing 2011.08.08----------<<<<<<<<<<<<<

                        break;
                    }
            }
        }

        /// <summary>
        /// SCM優先設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="scmPriorSt">SCM優先設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : SCM優先設定クラスをデータセットに格納します。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void SCMPriorStToDataSet(SCMPriorSt scmPriorSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (scmPriorSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmPriorSt.UpdateDateTimeJpInFormal;
            }

            //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            // 優先設定
            //if (scmPriorSt.PrioritySettingCd2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1 + "→" + scmPriorSt.PrioritySettingNm2;
            //}
            // 拠点コード
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmPriorSt.SectionCode;
            //// 拠点名称
            //string sectionName = GetSectionName(scmPriorSt.SectionCode);
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            //// 優先設定
            //if (scmPriorSt.PrioritySettingCd2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1 + "→" + scmPriorSt.PrioritySettingNm2;
            //}
            // 優先価格設定１
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = scmPriorSt.PriorPriceSetNm1;
            // 優先価格設定２
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = scmPriorSt.PriorPriceSetNm2;
            // 優先価格設定３
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = scmPriorSt.PriorPriceSetNm3;
            //-----------DELETE BY lingxiaoqing 2011.08.08----------<<<<<<<<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>>>>>>
            if (scmPriorSt.CustomerCode != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = ct_NO_MESSAGE;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = ct_NO_MESSAGE;
                //得意先コード
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = scmPriorSt.CustomerCode.ToString().TrimEnd().PadLeft(8, '0');
                if (scmPriorSt.CustomerCode == 0 || _isNewSave)
                {
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = _customerName;  // 得意先名称取得
                }
                else
                {
                    foreach (DictionaryEntry customer in _customersList)
                    {
                        if ((int)customer.Key == scmPriorSt.CustomerCode)
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = (string)customer.Value;
                        }
                    }
                }
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmPriorSt.SectionCode;
                // 拠点名称
                string sectionName = string.Empty;
                sectionName = GetSectionName(scmPriorSt.SectionCode);
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = ct_NO_MESSAGE;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = ct_NO_MESSAGE;
            }
            //優先適用区分           
            if (scmPriorSt.PriorAppliDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "共通";
            }
            else if (scmPriorSt.PriorAppliDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "PCC";
            }
            else
            {
                //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "PCCUOE"; //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ"; //ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
            }
            //選択時対象純優区分純優区分
            if (scmPriorSt.SelTgtPureDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO1] = "全て";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO1] = "純正";
            }
            //選択時対象純優区分在庫区分 
            if (scmPriorSt.SelTgtStckDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "全て";
            }
            else if (scmPriorSt.SelTgtStckDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "在庫";
            }
            else if (scmPriorSt.SelTgtStckDiv == 2)
            {
                // UPD 2013/12/16 吉岡 CM仕掛一覧№10590対応 2014/03/19配信予定 -------->>>>>>>>>>>>>>>>>
                // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "委託・優先倉庫";
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "委託・参照倉庫";
                // UPD 2013/12/16 吉岡 CM仕掛一覧№10590対応 2014/03/19配信予定 --------<<<<<<<<<<<<<<<<<
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "委託";
            }
            //選択時対象純優区分キャンペーン区分
            if (scmPriorSt.SelTgtCampDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO3] = "全て";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO3] = "キャンペーン";
            }
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象純優区分純優区分
            //if (scmPriorSt.UnSelTgtPureDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO4] = "全て";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO4] = "純正";
            //}
            ////非選択時対象純優区分在庫区分
            //if (scmPriorSt.UnSelTgtStckDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "全て";
            //}
            //else if (scmPriorSt.UnSelTgtStckDiv == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "在庫";
            //}
            //else if (scmPriorSt.UnSelTgtStckDiv == 2)
            //{
            //    // UPD 2013/12/16 吉岡 CM仕掛一覧№10590対応 2014/03/19配信予定 -------->>>>>>>>>>>>>>>>>
            //    // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "委託・優先倉庫";
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "委託・参照倉庫";
            //    // UPD 2013/12/16 吉岡 CM仕掛一覧№10590対応 2014/03/19配信予定 --------<<<<<<<<<<<<<<<<<
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "委託";
            //}
            ////非選択時対象純優区分キャンペーン区分
            //if (scmPriorSt.UnSelTgtCampDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO6] = "全て";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO6] = "キャンペーン";
            //}
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 選択時対象価格区分１
            if (scmPriorSt.SelTgtPricDiv1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "なし";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "粗利率(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "単価(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "定価(高)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "定価(低)";
            }
            // 選択時対象価格区分２
            if (scmPriorSt.SelTgtPricDiv2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "なし";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "粗利率(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "単価(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "定価(高)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "定価(低)";
            }
            // 選択時対象価格区分 3
            if (scmPriorSt.SelTgtPricDiv3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "なし";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "粗利率(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "単価(高)";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "定価(高)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "定価(低)";
            }
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //// 非選択時対象価格区分１
            //if (scmPriorSt.UnSelTgtPricDiv1 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "なし";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "粗利率(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "単価(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "定価(高)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "定価(低)";
            //}
            //// 非選択時対象価格区分 2
            //if (scmPriorSt.UnSelTgtPricDiv2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "なし";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "粗利率(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "単価(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "定価(高)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "定価(低)";
            //}
            //// 非選択時対象価格区分３
            //if (scmPriorSt.UnSelTgtPricDiv3 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "なし";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "粗利率(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "単価(高)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "定価(高)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "定価(低)";
            //}
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //初期選択順1
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER1] = scmPriorSt.PrioritySettingNm1;
            //初期選択順2
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER2] = scmPriorSt.PrioritySettingNm2;
            //初期選択順3
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER3] = scmPriorSt.PrioritySettingNm3;
            //初期選択順4
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER4] = scmPriorSt.PrioritySettingNm4;
            //初期選択順5
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER5] = scmPriorSt.PrioritySettingNm5;
            //初期選択順6
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER6] = scmPriorSt.PriorPriceSetNm1;
            //初期選択順7
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER7] = scmPriorSt.PriorPriceSetNm2;
            //-------------ADD BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<
            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmPriorSt.FileHeaderGuid;

            if (this._scmPriorStTable.ContainsKey(scmPriorSt.FileHeaderGuid) == true)
            {
                this._scmPriorStTable.Remove(scmPriorSt.FileHeaderGuid);
            }
            this._scmPriorStTable.Add(scmPriorSt.FileHeaderGuid, scmPriorSt);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable scmPriorStTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。

            scmPriorStTable.Columns.Add(DELETE_DATE, typeof(string));			            // 削除日

            scmPriorStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));           // 拠点コード
            scmPriorStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));           // 拠点名称
            //-------DELETE BY lingxiaoqing 2011.08.08 ------>>>>>>>>>>
            //scmPriorStTable.Columns.Add(VIEW_PRIORITY_SETTING, typeof(string));             // 優先設定
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET1, typeof(string));             // 優先価格設定１
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET2, typeof(string));             // 優先価格設定２
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET3, typeof(string));             // 優先価格設定３
            //-------DELETE BY lingxiaoqing 2011.08.08 ------<<<<<<<<<<

            //--------ADD BY lingxiaoiqng 2011.080.08 -------------->>>>>>>>>>>>
            scmPriorStTable.Columns.Add(VIEW_CUSTOMER_CODE_TITLE, typeof(string));           // 得意先コード
            scmPriorStTable.Columns.Add(VIEW_CUSTOMER_NAME_TITLE, typeof(string));           // 得意先名称
            scmPriorStTable.Columns.Add(VIEW_PRIORITY_DISCRIMITION, typeof(string));          // 優先適用区分
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO1, typeof(string));               // 選択時対象純優区分
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO4, typeof(string));               //  非選択時対象純優区分 // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO2, typeof(string));                // 選択時対象在庫区分
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO5, typeof(string));                // 非選択時対象在庫区分 // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO3, typeof(string));                // 選択時対象キャンペーン区分  
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO6, typeof(string));                // 非選択時対象キャンペーン区分 // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET1, typeof(string));             // 選択時対象価格区分１
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET4, typeof(string));             // 非選択時対象価格区分１ // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET2, typeof(string));             // 選択時対象価格区分２
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET5, typeof(string));             // 非選択時対象価格区分２ // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET3, typeof(string));             // 選択時対象価格区分３
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET6, typeof(string));             // 非選択時対象価格区分３ // DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER1, typeof(string));                   //初期選択順1
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER2, typeof(string));                   //初期選択順2
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER3, typeof(string));                   //初期選択順3
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER4, typeof(string));                   //初期選択順4
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER5, typeof(string));                    //初期選択順5
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER6, typeof(string));                    //初期選択順6
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER7, typeof(string));                    //初期選択順7
            //--------ADD BY lingxiaoiqng 2011.080.08 --------------<<<<<<<<<<<<
            scmPriorStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                 // Guid

            this.Bind_DataSet.Tables.Add(scmPriorStTable);
        }

        //------------DELETE BY lingxiaoqing 2011.08.08--------------->>>>>>>>>>>>>>>>
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br></br>
        /// </remarks>
        //private void ScreenInitialSetting()
        //{
        //// 優先設定
        //PrioritySetting_tComboEditor.Items.Clear();
        //PrioritySetting_tComboEditor.Items.Add(65, ct_PRIORITY_NAME65);
        //PrioritySetting_tComboEditor.Items.Add(56, ct_PRIORITY_NAME56);
        //PrioritySetting_tComboEditor.Items.Add(60, ct_PRIORITY_NAME60);
        //PrioritySetting_tComboEditor.Items.Add(50, ct_PRIORITY_NAME50);
        //PrioritySetting_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PrioritySetting_tComboEditor.MaxDropDownItems = PrioritySetting_tComboEditor.Items.Count;

        //// 優先価格設定１
        //PriorPriceSetCd1_tComboEditor.Items.Clear();
        //PriorPriceSetCd1_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd1_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd1_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd1_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd1_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd1_tComboEditor.MaxDropDownItems = PriorPriceSetCd1_tComboEditor.Items.Count;

        // 優先価格設定２
        //PriorPriceSetCd2_tComboEditor.Items.Clear();
        //PriorPriceSetCd2_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd2_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd2_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd2_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd2_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd2_tComboEditor.MaxDropDownItems = PriorPriceSetCd2_tComboEditor.Items.Count;

        // 優先価格設定３
        //PriorPriceSetCd3_tComboEditor.Items.Clear();
        //PriorPriceSetCd3_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd3_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd3_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd3_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd3_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd3_tComboEditor.MaxDropDownItems = PriorPriceSetCd3_tComboEditor.Items.Count;

        //}
        //------------DELETE BY lingxiaoqing ---------------<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.SectionName_tEdit.DataText = "";
            //--------DELTE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>
            //this.PrioritySetting_tComboEditor.SelectedIndex = 0;        // 優先設定
            //this.PriorPriceSetCd1_tComboEditor.SelectedIndex = 0;       // 優先価格設定１
            //this.PriorPriceSetCd2_tComboEditor.SelectedIndex = 0;       // 優先価格設定２
            //this.PriorPriceSetCd3_tComboEditor.SelectedIndex = 0;       // 優先価格設定３
            //--------DELTE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<

            //--------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();                    // 拠点コード
            this.SectionName_tEdit.Clear();                             // 拠点名称
            this.tNedit_CustomerCode.Clear();                           // 得意先
            this.CustomerCodeNm_tEdit.Clear();                          // 得意先名 
            this.Discriminition_ComboEditor.SelectedIndex = 0;          //優先適用区分
            this.SetKind_tComboEditor.SelectedIndex = 0;                //設定種別
            this.PureSuperio_ComboEditor.SelectedIndex = 0;             //選択時対象純優区分       
            this.InStock_ComboEditor.SelectedIndex = 0;                 //選択時対象在庫区分
            this.CampingCode_ComboEditor.SelectedIndex = 0;             //選択時対象キャンペーン区分
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //this.PureSuperio1_ComboEditor.SelectedIndex = 0;            //非選択時対象純優区分   
            //this.InStock1_ComboEditor.SelectedIndex = 0;                //非選択時対象在庫区分
            //this.CampingCode1_ComboEditor.SelectedIndex = 0;            //非選択時対象キャンペーン区分
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            this.PriorPriceSetCd1_tComboEditor.SelectedIndex = 0;       // 選択時対象価格区分１
            this.PriorPriceSetCd2_tComboEditor.SelectedIndex = 0;       // 選択時対象価格区分２
            this.PriorPriceSetCd3_tComboEditor.SelectedIndex = 0;       // 選択時対象価格区分３
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //this.PriorPriceSetCd4_tComboEditor.SelectedIndex = 0;       // 非選択時対象価格区分１
            //this.PriorPriceSetCd5_tComboEditor.SelectedIndex = 0;       // 非選択時対象価格区分２
            //this.PriorPriceSetCd6_tComboEditor.SelectedIndex = 0;       // 非選択時対象価格区分３
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            this.Order1_ComboEditor.SelectedIndex = 0;                 //初期選択順1
            this.Order2_ComboEditor.SelectedIndex = 0;                  //初期選択順2
            this.Order3_ComboEditor.SelectedIndex = 0;                  //初期選択順3
            this.Order4_ComboEditor.SelectedIndex = 0;                  //初期選択順4
            this.Order5_ComboEditor.SelectedIndex = 0;                  //初期選択順5
            this.Order6_ComboEditor.SelectedIndex = 0;                  //初期選択順6
            this.Order7_ComboEditor.SelectedIndex = 0;                   //初期選択順7
            //--------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        }

        /// <summary>
        /// SCM優先設定クラス画面展開処理
        /// </summary>
        /// <param name="scmPriorSt">SCM優先設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : SCM優先設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void SCMPriorStToScreen(SCMPriorSt scmPriorSt)
        {
            //--------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>
            //// 拠点コード
            //this.tEdit_SectionCodeAllowZero.DataText = scmPriorSt.SectionCode;
            //// 拠点名称
            //string sectionName = string.Empty;
            //if (scmPriorSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            //{
            //    sectionName = "全社共通";
            //}
            //else
            //{
            //    sectionName = this.GetSectionName(scmPriorSt.SectionCode);
            //}
            //this.SectionName_tEdit.DataText = sectionName;
            // 優先設定
            //this.PrioritySetting_tComboEditor.Value = (scmPriorSt.PrioritySettingCd1 * 10) + scmPriorSt.PrioritySettingCd2;

            // 優先価格設定１
            //this.PriorPriceSetCd1_tComboEditor.Value = scmPriorSt.PriorPriceSetCd1;

            // 優先価格設定２
            //this.PriorPriceSetCd2_tComboEditor.Value = scmPriorSt.PriorPriceSetCd2;

            // 優先価格設定３
            //this.PriorPriceSetCd3_tComboEditor.Value = scmPriorSt.PriorPriceSetCd3;
            //--------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>>>>>>
            //設定種別
            if (scmPriorSt.CustomerCode == 0)
            {
                this.SetKind_tComboEditor.Value = 0;
                this.Discriminition_ComboEditor.Enabled = false;
                this.SetKind_tComboEditor.Enabled = false;
                this.tEdit_SectionCodeAllowZero2.Enabled = false;
                this.SectionGuide_Button.Enabled = false;
                // 拠点コード
                this.tEdit_SectionCodeAllowZero2.DataText = scmPriorSt.SectionCode.ToString();
                // 拠点名称
                string sectionName = string.Empty;
                if (scmPriorSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
                {
                    sectionName = "全社共通";
                }
                else
                {
                    sectionName = this.GetSectionName(scmPriorSt.SectionCode);
                }
                this.SectionName_tEdit.DataText = sectionName;
            }
            else
            {
                this.SetKind_tComboEditor.Value = 1;
                this.Discriminition_ComboEditor.Enabled = false;
                this.SetKind_tComboEditor.Enabled = false;
                this.tNedit_CustomerCode.Enabled = false;
                this.uButton_CustomerGuide.Enabled = false;
                //得意先コード
                this.tNedit_CustomerCode.DataText = scmPriorSt.CustomerCode.ToString().TrimEnd().PadLeft(8, '0');
                if (scmPriorSt.CustomerCode == 0)
                {
                    this.CustomerCodeNm_tEdit.Text = _customerName;  // 得意先名称取得
                }
                else
                {
                    foreach (DictionaryEntry customer in _customersList)
                    {
                        if ((int)customer.Key == scmPriorSt.CustomerCode)
                        {
                            this.CustomerCodeNm_tEdit.Text = (string)customer.Value;
                        }
                    }
                }
            }
            //優先適用区分
            this.Discriminition_ComboEditor.Value = scmPriorSt.PriorAppliDiv;

            //選択時対象純優区分純優区分
            this.PureSuperio_ComboEditor.Value = scmPriorSt.SelTgtPureDiv;
            //選択時対象純優区分在庫区分
            this.InStock_ComboEditor.Value = scmPriorSt.SelTgtStckDiv;
            //選択時対象純優区分キャンペーン区分
            this.CampingCode_ComboEditor.Value = scmPriorSt.SelTgtCampDiv;
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象純優区分純優区分
            //this.PureSuperio1_ComboEditor.Value = scmPriorSt.UnSelTgtPureDiv;
            ////非選択時対象純優区分在庫区分
            //this.InStock1_ComboEditor.Value = scmPriorSt.UnSelTgtStckDiv;
            ////非選択時対象純優区分キャンペーン区分
            //this.CampingCode1_ComboEditor.Value = scmPriorSt.UnSelTgtCampDiv;
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 選択時対象価格区分１
            this.PriorPriceSetCd1_tComboEditor.Value = scmPriorSt.SelTgtPricDiv1;
            // 選択時対象価格区分２
            this.PriorPriceSetCd2_tComboEditor.Value = scmPriorSt.SelTgtPricDiv2;
            // 選択時対象価格区分 3
            this.PriorPriceSetCd3_tComboEditor.Value = scmPriorSt.SelTgtPricDiv3;
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            //// 非選択時対象価格区分１
            //this.PriorPriceSetCd4_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv1;
            //// 非選択時対象価格区分 2
            //this.PriorPriceSetCd5_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv2;
            //// 非選択時対象価格区分３
            //this.PriorPriceSetCd6_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv3;
            // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //初期選択順1
            this.Order1_ComboEditor.Value = scmPriorSt.PrioritySettingCd1;
            //初期選択順2
            this.Order2_ComboEditor.Value = scmPriorSt.PrioritySettingCd2;
            //初期選択順3
            this.Order3_ComboEditor.Value = scmPriorSt.PrioritySettingCd3;
            //初期選択順4
            this.Order4_ComboEditor.Value = scmPriorSt.PrioritySettingCd4;
            //初期選択順5
            this.Order5_ComboEditor.Value = scmPriorSt.PrioritySettingCd5;
            //初期選択順6
            this.Order6_ComboEditor.Value = scmPriorSt.PriorPriceSetCd1;
            //初期選択順7
            this.Order7_ComboEditor.Value = scmPriorSt.PriorPriceSetCd2;
            //-------------ADD BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<


        }

        /// <summary>
        /// 画面情報SCM優先設定クラス格納処理
        /// </summary>
        /// <param name="scmPriorSt">SCM優先設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM優先設定オブジェクトにデータを格納します。</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToSCMPriorSt(ref SCMPriorSt scmPriorSt)
        {
            if (scmPriorSt == null)
            {
                // 新規の場合
                scmPriorSt = new SCMPriorSt();
            }

            //企業コード
            scmPriorSt.EnterpriseCode = this._enterpriseCode;
            //-------------DELETE BY lingxiaoqing 2011.08.08 -------------->>>>>>>>>>>>>>>
            // 拠点コード
            //scmPriorSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;   

            // 優先設定
            //int prioritySetting = (int)this.PrioritySetting_tComboEditor.Value;
            //switch (prioritySetting)
            //{
            //    case 0:     // なし
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 0;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME0;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 50:    // キャンペーン
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 5;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME5;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 56:    // キャンペーン→倉庫
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 5;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME5;
            //            scmPriorSt.PrioritySettingCd2 = 6;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME6;
            //            break;
            //        }
            //    case 60:    // 倉庫
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 6;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME6;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 65:    // 倉庫→キャンペーン
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 6;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME6;
            //            scmPriorSt.PrioritySettingCd2 = 5;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME5;
            //            break;
            //        }
            //}

            //int inputCnt = 0;
            //for (int no = 0; no < MAX_PRIOR_PRICE_SET; no++)
            //{
            //    // 優先価格設定の設定
            //    SetPriorPriceSet(no, ref scmPriorSt, ref inputCnt);
            //}
            //-------------DELETE BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // 拠点コード
                // 拠点名称
                string sectionName = string.Empty;
                if (this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0') == ALL_SECTIONCODE)
                {
                    // 全社設定
                    scmPriorSt.SectionCode = ALL_SECTIONCODE;
                }
                else
                {
                    // 全社設定以外
                    scmPriorSt.SectionCode = this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

                }
                // 得意先コード
                scmPriorSt.CustomerCode = 0;
            }
            else
            {
                // 拠点コード
                scmPriorSt.SectionCode = "00";
                // 得意先コード
                scmPriorSt.CustomerCode = this.tNedit_CustomerCode.GetInt();

            }
            //優先適用区分
            scmPriorSt.PriorAppliDiv = Convert.ToInt32(this.Discriminition_ComboEditor.SelectedItem.DataValue);
            //選択時対象純優区分    
            scmPriorSt.SelTgtPureDiv = Convert.ToInt32(this.PureSuperio_ComboEditor.SelectedItem.DataValue);
            //選択時対象在庫区分
            scmPriorSt.SelTgtStckDiv = Convert.ToInt32(this.InStock_ComboEditor.SelectedItem.DataValue);
            //選択時対象キャンペーン区分
            scmPriorSt.SelTgtCampDiv = Convert.ToInt32(this.CampingCode_ComboEditor.SelectedItem.DataValue);
            // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象純優区分    
            //scmPriorSt.UnSelTgtPureDiv = Convert.ToInt32(this.PureSuperio1_ComboEditor.SelectedItem.DataValue);
            ////非選択時対象在庫区分
            //scmPriorSt.UnSelTgtStckDiv = Convert.ToInt32(this.InStock1_ComboEditor.SelectedItem.DataValue);
            ////非選択時対象キャンペーン区分
            //scmPriorSt.UnSelTgtCampDiv = Convert.ToInt32(this.CampingCode1_ComboEditor.SelectedItem.DataValue);
            //非選択時対象純優区分    
            scmPriorSt.UnSelTgtPureDiv = 0;
            //非選択時対象在庫区分
            scmPriorSt.UnSelTgtStckDiv = 0;
            //非選択時対象キャンペーン区分
            scmPriorSt.UnSelTgtCampDiv = 0;
            // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            //選択時対象価格区分１
            scmPriorSt.SelTgtPricDiv1 = Convert.ToInt32(this.PriorPriceSetCd1_tComboEditor.SelectedItem.DataValue);
            //選択時対象価格区分２
            scmPriorSt.SelTgtPricDiv2 = Convert.ToInt32(this.PriorPriceSetCd2_tComboEditor.SelectedItem.DataValue);
            //選択時対象価格区分 3
            scmPriorSt.SelTgtPricDiv3 = Convert.ToInt32(this.PriorPriceSetCd3_tComboEditor.SelectedItem.DataValue);
            // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
            ////非選択時対象価格区分１
            //scmPriorSt.UnSelTgtPricDiv1 = Convert.ToInt32(this.PriorPriceSetCd4_tComboEditor.SelectedItem.DataValue);
            ////非選択時対象価格区分２
            //scmPriorSt.UnSelTgtPricDiv2 = Convert.ToInt32(this.PriorPriceSetCd5_tComboEditor.SelectedItem.DataValue);
            ////非選択時対象価格区分 3
            //scmPriorSt.UnSelTgtPricDiv3 = Convert.ToInt32(this.PriorPriceSetCd6_tComboEditor.SelectedItem.DataValue);
            //非選択時対象価格区分１
            scmPriorSt.UnSelTgtPricDiv1 = 0;
            //非選択時対象価格区分２
            scmPriorSt.UnSelTgtPricDiv2 = 0;
            //非選択時対象価格区分 3
            scmPriorSt.UnSelTgtPricDiv3 = 0;
            // ---UPD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            // 優先設定コード１
            scmPriorSt.PrioritySettingCd1 = Convert.ToInt32(this.Order1_ComboEditor.SelectedItem.DataValue);
            // 優先設定名称１
            scmPriorSt.PrioritySettingNm1 = this.Order1_ComboEditor.SelectedItem.DisplayText;
            // 優先設定コード2
            scmPriorSt.PrioritySettingCd2 = Convert.ToInt32(this.Order2_ComboEditor.SelectedItem.DataValue);
            // 優先設定名称2   
            scmPriorSt.PrioritySettingNm2 = this.Order2_ComboEditor.SelectedItem.DisplayText;
            // 優先設定コード3
            scmPriorSt.PrioritySettingCd3 = Convert.ToInt32(this.Order3_ComboEditor.SelectedItem.DataValue);
            // 優先設定名称3
            scmPriorSt.PrioritySettingNm3 = this.Order3_ComboEditor.SelectedItem.DisplayText;
            // 優先設定コード4
            scmPriorSt.PrioritySettingCd4 = Convert.ToInt32(this.Order4_ComboEditor.SelectedItem.DataValue);
            // 優先設定名称4
            scmPriorSt.PrioritySettingNm4 = this.Order4_ComboEditor.SelectedItem.DisplayText;
            // 優先設定コード5
            scmPriorSt.PrioritySettingCd5 = Convert.ToInt32(this.Order5_ComboEditor.SelectedItem.DataValue);
            // 優先設定名称5
            scmPriorSt.PrioritySettingNm5 = this.Order5_ComboEditor.SelectedItem.DisplayText;
            // 優先価格設定コード1
            scmPriorSt.PriorPriceSetCd1 = Convert.ToInt32(this.Order6_ComboEditor.SelectedItem.DataValue);
            // 優先価格設定名称1
            scmPriorSt.PriorPriceSetNm1 = this.Order6_ComboEditor.SelectedItem.DisplayText;
            // 優先価格設定コード2
            scmPriorSt.PriorPriceSetCd2 = Convert.ToInt32(this.Order7_ComboEditor.SelectedItem.DataValue);
            // 優先価格設定名称2
            scmPriorSt.PriorPriceSetNm2 = this.Order7_ComboEditor.SelectedItem.DisplayText;
            // 優先価格設定コード3
            scmPriorSt.PriorPriceSetCd3 = 0;
            // 優先価格設定名称3
            scmPriorSt.PriorPriceSetNm3 = ct_PRIORITY_NAME0;
            // 優先価格設定コード4
            scmPriorSt.PriorPriceSetCd4 = 0;
            // 優先価格設定名称4
            scmPriorSt.PriorPriceSetNm4 = ct_PRIORITY_NAME0;
            // 優先価格設定コード5   
            scmPriorSt.PriorPriceSetCd5 = 0;
            // 優先価格設定名称5
            scmPriorSt.PriorPriceSetNm5 = ct_PRIORITY_NAME0;
            //-------------ADD BY lingxiaoqing -----------------------------<<<<<<<<<<<<<<<<          

        }

        //-------------DELETE BY lingxiaoqing ----------------------------->>>>>>>>>>>>>>
        /// <summary>
        /// 画面情報をSCM優先設定クラス格納処理
        /// </summary>
        /// <br paramname="setNo">設定対象の優先価格設定の番号</br>
        /// <br paramname="scmPriorSt">保存するデータクラス</br>
        /// <br paramname="inputCnt">画面読込開始のカウント数</br>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM納期設定クラスにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        //private void SetPriorPriceSet(int setNo, ref SCMPriorSt scmPriorSt, ref int inputCnt)
        //{
        //    int priorPriceSetCd = 0;
        //    string priorPriceSetNm = ct_PRIORITY_NAME0;

        //    int i;
        //    for (i = inputCnt; i < MAX_PRIOR_PRICE_SET; i++)
        //    {
        //        // 画面の優先価格設定
        //        switch (i)
        //        {
        //            case 0:
        //                {
        //                    if ((int)this.PriorPriceSetCd1_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd1_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd1_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //            case 1:
        //                {
        //                    if ((int)this.PriorPriceSetCd2_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd2_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd2_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    if ((int)this.PriorPriceSetCd3_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd3_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd3_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //        }

        //        if (priorPriceSetCd != 0)
        //        {
        //            // 優先価格設定を取得済の場合、取得処理終了
        //            break;
        //        }
        //    }

        //    // 次回読込開始のカウントを更新
        //    inputCnt = ++i;

        //    // データクラスの優先価格設定に設定
        //    switch (setNo)
        //    {
        //        case 0:
        //            {
        //                scmPriorSt.PriorPriceSetCd1 = priorPriceSetCd;      //優先価格設定コード１
        //                scmPriorSt.PriorPriceSetNm1 = priorPriceSetNm;      //優先価格設定名称１
        //                break;
        //            }
        //        case 1:
        //            {
        //                scmPriorSt..PriorPriceSetCd2 = priorPriceSetCd;      // 優先価格設定コード２
        //                scmPriorSt.PriorPriceSetNm2 = priorPriceSetNm;       // 優先価格設定名称２
        //                break;
        //            }
        //        case 2:
        //            {
        //                scmPriorSt.PriorPriceSetCd3 = priorPriceSetCd;       // 優先価格設定コード３
        //                scmPriorSt..PriorPriceSetNm3 = priorPriceSetNm;      // 優先価格設定名称１３
        //                break;
        //            }               
        //    }
        //}
        //-------------DELETE BY lingxiaoqing -----------------------------<<<<<<<<<<<<<<

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
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

            // 比較用クローンクリア
            this._scmPriorStClone = null;

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
        /// <br></br>
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
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

        /// <summary>
        ///	SCM優先設定画面入力チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM優先設定画面の入力チェックをします。</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {

            //---------DELETE BY lingxiaoqing  2011.08.08------------>>>>>>>>>>>>>>>>>
            // 拠点コード
            //if (this.tEdit_SectionCodeAllowZero.DataText == "")
            //{
            //    message = this.Section_uLabel.Text + "を設定して下さい。";
            //    control = this.tEdit_SectionCodeAllowZero;
            //    return false;
            //}

            //ArrayList chkList = new ArrayList();
            //// 優先価格設定１
            //if ((int)this.PriorPriceSetCd1_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd1_tComboEditor.Value))
            //    {
            //        message = "優先価格設定が重複しています。";
            //        control = this.PriorPriceSetCd1_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd1_tComboEditor.Value);
            //    }
            //}

            //// 優先価格設定２
            //if ((int)this.PriorPriceSetCd2_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd2_tComboEditor.Value))
            //    {
            //        message = "優先価格設定が重複しています。";
            //        control = this.PriorPriceSetCd2_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd2_tComboEditor.Value);
            //    }
            //}

            //// 優先価格設定３
            //if ((int)this.PriorPriceSetCd3_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd3_tComboEditor.Value))
            //    {
            //        message = "優先価格設定が重複しています。";
            //        control = this.PriorPriceSetCd3_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd3_tComboEditor.Value);
            //    }
            //}
            //---------DELETE BY lingxiaoqing  2011.08.08------------<<<<<<<<<<<<<<<<<<
            //---------ADD BY lingxiaoqing  2011.08.08------------>>>>>>>>>>>>>>>>>
            if (SetKind_tComboEditor.SelectedIndex == 0)
            {
                // 拠点コード
                if (this.tEdit_SectionCodeAllowZero2.DataText == "")
                {
                    message = this.Section_uLabel.Text + "を設定して下さい。";
                    control = this.tEdit_SectionCodeAllowZero2;
                    return false;
                }
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.DataText = tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0');

                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // 拠点名称取得
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK
                    );
                    message = string.Empty;
                    control = this.tEdit_SectionCodeAllowZero2;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    return false;
                }
                this.SectionName_tEdit.DataText = sectionName;

                // 拠点コードの存在チェック
                bool existCheck = false;
                // 全社共通は拠点マスタに登録されていないため、チェックの対象外
                if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText == "0")
                {
                    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                    {
                        if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                        {
                            existCheck = true;
                            break;
                        }
                    }
                }
                else
                {
                    existCheck = true;
                }

                if (!existCheck)
                {
                    message = "指定した拠点コードは存在しません。";
                    control = this.tEdit_SectionCodeAllowZero2;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    return false;
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<

            }
            //-------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
            else
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.DataText == "")
                {
                    message = this.CustomerCode_Title_Label.Text + "を設定して下さい。";
                    control = this.tNedit_CustomerCode;
                    return false;
                }
            }

            //初期選択順 
            ArrayList selectedList = new ArrayList();
            selectedList.Add(this.Order1_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order2_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order3_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order4_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order5_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order6_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order7_ComboEditor.SelectedIndex);
            ArrayList compentList = new ArrayList();
            compentList.Add(this.Order1_ComboEditor);
            compentList.Add(this.Order2_ComboEditor);
            compentList.Add(this.Order3_ComboEditor);
            compentList.Add(this.Order4_ComboEditor);
            compentList.Add(this.Order5_ComboEditor);
            compentList.Add(this.Order6_ComboEditor);
            compentList.Add(this.Order7_ComboEditor);
            for (int i = 0; i < selectedList.Count; i++)
            {
                if ((int)selectedList[i] != 0)
                {
                    for (int j = i; j < compentList.Count - 1; j++)
                    {
                        if ((int)selectedList[i] == (int)selectedList[j + 1])
                        {
                            message = ct_ORDER_MESSAGE1;
                            control = (Control)compentList[j + 1];
                            return false;
                        }
                    }
                }
                if ((int)selectedList[i] == 3 || (int)selectedList[i] == 4)
                {
                    for (int j = i; j < compentList.Count - 1; j++)
                    {
                        if ((int)selectedList[j + 1] == 4 || (int)selectedList[j + 1] == 3)
                        {
                            message = ct_ORDER_MESSAGE2;
                            control = (Control)compentList[j + 1];
                            return false;
                        }
                    }
                }
            }
            //-------------ADD BY lingxiaoqing 2011.08.08-----------------------------<<<<<<<<<<<<<<<<<<<           
            return true;
        }

        /// <summary>
        ///　保存処理(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            //画面データ入力チェック処理
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (!string.IsNullOrEmpty(message))
                {
                    // --- ADD 2011/09/07 --------------------------------<<<<<
                    // 入力チェック
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                }//ADD 2011/09/07
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            SCMPriorSt scmPriorSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmPriorSt = ((SCMPriorSt)this._scmPriorStTable[guid]).Clone();
                _isNewSave = false; // ADD BY lingxiaoqing on 2011.08.08 for データは更新する
            }
            else
            {
                _isNewSave = true; // ADD BY lingxiaoqing on 2011.08.08 for データは更新すない
            }
            // 画面情報を取得           
            ScreenToSCMPriorSt(ref scmPriorSt);
            // 登録・更新処理
            int status = this._scmPriorStAcs.Write(ref scmPriorSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            PROGRAM_ID,							    // アセンブリID
                            this.Text,  　　                        // プログラム名称
                            "SaveProc",                             // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",				    // 表示するメッセージ
                            status,									// ステータス値
                            this._scmPriorStAcs,				    	// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,			  		// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }
            //----------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>
            if (!_customersList.Contains(scmPriorSt.CustomerCode))
            {
                _customersList.Add(scmPriorSt.CustomerCode, this.CustomerCodeNm_tEdit.DataText);
            }
            //----------ADD BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<
            // SCM優先設定情報クラスのデータセット展開処理
            SCMPriorStToDataSet(scmPriorSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            result = true;
            return result;
        }


        /// <summary>
        ///　競合中メッセージ表示
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 該当コードが使用されている場合にメッセージを表示します。</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています",// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
            //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                tEdit_SectionCodeAllowZero2.Focus();
                control = tEdit_SectionCodeAllowZero2;
            }
            else
            {
                this.tNedit_CustomerCode.Focus();
                control = this.tNedit_CustomerCode;
            }
            //------------ADD BY lingxiaoqing 2010.08.08 -----------<<<<<<<<<<<<<<
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称 ※該当するものが無い場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社共通";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            isError = false;//ADD 2011/09/07
            string msg = "入力されたコードのSCM優先設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            string priorAppliDivCd = this.Discriminition_ComboEditor.SelectedItem.DisplayText; //ADD BY lingxiaoqing on 2011.08.08 for 区分優先適用区分

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                string priorAppliDiv = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_PRIORITY_DISCRIMITION];//ADD BY  lingxiaoqing on 2011.08.08 for 区分優先適用区分
                //if (sectionCd.Equals(dsSecCd.TrimEnd())) // DELETE BY lingxiaoqing on 2011.08.08 for その他の条件を添加します
                if (sectionCd.Equals(dsSecCd.TrimEnd()) && priorAppliDivCd.Equals(priorAppliDiv.TrimEnd()))// ADD BY lingxiaoqing on 2011.08.08 for その他の条件を添加します
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM優先設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/07
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのSCM優先設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
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
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>>>
        /// <summary>
        /// モード変更処理　　　　　　　　　　　　　　
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先モード変更処理</br>                   
        /// <br>Programmer : 凌小青</br>                               
        /// <br>Date       : 2011.08.08</br>                                         
        /// </remarks>
        private bool CusModeChangeProc()
        {
            string msg = "入力されたコードのSCM優先設定情報が既に登録されています。\n編集を行いますか？";

            // 得意先コード
            string customerCd = this.tNedit_CustomerCode.Text.TrimEnd().PadLeft(8, '0');
            string priorAppliDivCd = this.Discriminition_ComboEditor.SelectedItem.DisplayText;

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsCusCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMER_CODE_TITLE];
                string priorAppliDiv = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_PRIORITY_DISCRIMITION];
                if (customerCd.Equals(dsCusCd.TrimEnd()) && priorAppliDivCd.Equals(priorAppliDiv.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM優先設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 得意先コード、名称のクリア
                        this.tNedit_CustomerCode.Clear();
                        CustomerCodeNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
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
                                // 得意先コード、名称のクリア
                                this.tNedit_CustomerCode.Clear();
                                CustomerCodeNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<

        # region -- Control Events --
        /// <summary>
        ///	Form.Load イベント(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_Load(object sender, System.EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // 得意先コードガイドボタンの画像イメージ追加 
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; //ADD BY lingxiaoqing 2011.08.08

            // コントロールサイズ設定
            SetControlSize();

            // 画面初期設定処理  DELETE BY lingxiaoqing 2011.08.08
            //ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.Closing イベント(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///					  ようとしたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
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
        ///	Form.VisibleChanged イベント(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームの表示・非表示が切り替えられ
        ///					  たときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();
                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // 画面クリア
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録・更新処理
            if (!SaveProc())
            {
                return;
            }
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SCMPriorSt compareSCMPriorSt = new SCMPriorSt();

                compareSCMPriorSt = this._scmPriorStClone.Clone();
                ScreenToSCMPriorSt(ref compareSCMPriorSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._scmPriorStClone.Equals(compareSCMPriorSt))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        //emErrorLevel.ERR_LEVEL_SAVECONFIRM,                 // エラーレベル //DELETE BY lingxiaoqing 2010.08.08
                        emErrorLevel.ERR_LEVEL_QUESTION,                      // エラーレベル //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195
                        PROGRAM_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        //null, 					                          // 表示するメッセージ //DELETE BY lingxiaoqing 2010.08.08
                        "現在、偏集中のデータが存在します。\r\n" +
                        "破棄してもよろしいですか？", 					      // 表示するメッセージ //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                        0, 					                                  // ステータス値
                        //MessageBoxButtons.YesNoCancel);	                  // 表示するボタン //DELETE BY lingxiaoqing 2010.08.08 
                        MessageBoxButtons.YesNo,                              // 表示するボタン //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                         MessageBoxDefaultButton.Button2);	                  // 表示するボタン //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {

                                //----------DELETE BY lingxiaoqing 2010.08.08 ---------->>>>>>>>>>>
                                //if (!SaveProc())
                                //{
                                //    return;
                                //}
                                //return;
                                //----------DELETE BY lingxiaoqing 2010.08.08 ----------<<<<<<<<<<<
                                break;  //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                            }
                        case DialogResult.No:
                            {
                                //----------DELETE BY lingxiaoqing 2010.08.08 ---------->>>>>>>>>>>
                                //画面非表示イベント
                                //if (UnDisplaying != null)
                                //{
                                //    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.No);
                                //    UnDisplaying(this, me);
                                //}
                                //break;
                                //----------DELETE BY lingxiaoqing 2010.08.08 ----------<<<<<<<<<<<<
                                return; //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                            }
                        default:
                            {
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                //-------ADD BY lingxiaoqing 2011.08.08 ------------>>>>>>>>>>>>>>
                                if (_cusModeFlg)
                                {
                                    this.tNedit_CustomerCode.Focus();
                                    _cusModeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                //-------ADD BY lingxiaoqing 2011.08.08 ------------<<<<<<<<<<<<<
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

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
        }

        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br></br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Timer.Enabled = false;

            // 画面表示処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.PrioritySetting_tComboEditor.Focus(); //DELETE BY lingxiaoqing 2011.08.08
                    //------ADD BY lingxiaoqing 2011.08.08------------------>>>>>>>>>>>>>>>>>                    
                    this.PureSuperio_ComboEditor.Focus();
                    this.tNedit_CustomerCode.Clear();
                    this.CustomerCodeNm_tEdit.Clear();
                    //------ADD BY lingxiaoqing 2011.08.08------------------<<<<<<<<<<<<<<<<<

                    // 新規モードからモード変更対応
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
                //--------DELETE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>
                //else if (status == 1)
                //{
                //    // [戻る]の場合
                //    if (ModeChangeProc())
                //    {
                //        SectionGuide_Button.Focus();
                //    }
                //}
                //--------DELETE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            this.PureSuperio_ComboEditor.Focus();
        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<


        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>
        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイド選択イベント。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            try
            {
                int status = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out _customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tNedit_CustomerCode.SetInt(_customerInfo.CustomerCode);
                    this.CustomerCodeNm_tEdit.Text = _customerInfo.CustomerSnm;  // 略称
                    _customerName = _customerInfo.CustomerSnm;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    this.SectionName_tEdit.Clear();

                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した得意先は既に削除されています。",
                        status,
                        MessageBoxButtons.OK);

                    return;
                }
                else
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_STOPDISP,
                                  this.Name,
                                  "得意先情報の取得に失敗しました。",
                                  status,
                                  MessageBoxButtons.OK);

                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        //------------ADD BY lingxiaoqing 2011.08.08 ------------<<<<<<<<<<<<<<<<

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                //MessageBoxButtons.OKCancel,       //DELETE BY lingxiaoqing 2011.08.08 
                MessageBoxButtons.YesNo,            //ADD BY lingxiaoqing 2011.08.08 FOR Redmine#0203
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            //if (result != DialogResult.OK)//DELETE BY lingxiaoqing 2011.08.08
            if (result != DialogResult.Yes)//ADD BY lingxiaoqing 2011.08.08  FOR Redmine#0203
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

            // 完全削除処理
            int status = this._scmPriorStAcs.Delete(scmPriorSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmPriorStTable.Remove(scmPriorSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // 完全削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmPriorStAcs, 				    // エラーが発生したオブジェクト
                            //MessageBoxButtons.OK, 				// 表示するボタン  // DELETE BY lingxiaoqing 2011.08.08
                            MessageBoxButtons.YesNo, 				// 表示するボタン  // ADD BY lingxiaoqing 2011.08.08  FOR PCCUOE-0203
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        //CloseForm(DialogResult.Cancel); //DELETE BY lingxiaoqing 2011.08.08
                        CloseForm(DialogResult.No);       //ADD BY lingxiaoqing 2011.08.08
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = ((SCMPriorSt)this._scmPriorStTable[guid]).Clone();

            // 復活処理
            status = this._scmPriorStAcs.Revival(ref scmPriorSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM優先設定情報クラスのデータセット展開処理
                        SCMPriorStToDataSet(scmPriorSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._scmPriorStAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;
            _cusModeFlg = false; // ADD BY lingxiaoqing on 2011.08.08

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero2)
            {
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                {
                    this.SectionName_tEdit.Clear();
                    return;
                }
                this.tEdit_SectionCodeAllowZero2.DataText = tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0');
                // --- ADD 2011/09/07 --------------------------------<<<<<
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // 拠点名称取得
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    this.SectionName_tEdit.Clear();
                    e.NextCtrl = SectionGuide_Button; //ADD BY lingxiaoqing 2011.08.08
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                    e.NextCtrl.Select();
                    return;
                }
                //this.tEdit_SectionCodeAllowZero2.DataText = sectionCode.Trim().PadLeft(2, '0'); // ADD BY lingxiaoqing on 2011.08.08//DEL 2011/09/07
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            //e.NextCtrl = this.PrioritySetting_tComboEditor;//DELETE BY lingxiaoqing on 2011.08.08
                            e.NextCtrl = this.PureSuperio_ComboEditor; // ADD BY lingxiaoqing on 2011.08.08
                        }
                    }
                    //------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>>
                    else
                    {
                        if (sectionName.Equals("全社共通") && e.NextCtrl == this.SectionGuide_Button)
                        {
                            return;
                        }

                    }
                    e.NextCtrl = this.SectionGuide_Button;
                    //------------ADD BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<<<<<<
                }
                //ADD BY lingxiaoqing 2011.08.08 
                else
                {
                    e.NextCtrl = this.SetKind_tComboEditor;
                }

                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tEdit_SectionCodeAllowZero2
                            &&
                        e.NextCtrl == this.SectionGuide_Button
                            &&
                        string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.Trim())
                    )
                    {
                        // 何もしない ∵新規モードで起動直後に拠点のガイドボタンをクリックした場合に相当
                    }
                    else if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            //-------------- ADD BY lingxiaoqing 2011.08.08------------>>>>>>>>>>>>>>>>>
            if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                // 得意先コード取得
                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    int status = _customerInfoAcs.ReadDBData(_enterpriseCode, this.tNedit_CustomerCode.GetInt(), out _customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._customerName = _customerInfo.CustomerSnm;
                        this.CustomerCodeNm_tEdit.DataText = _customerName;
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                    else
                    {
                        this.CustomerCodeNm_tEdit.DataText = "";
                        TMsgDisp.Show(
                                               this,
                                               emErrorLevel.ERR_LEVEL_INFO,
                                               this.Name,
                                               "得意先が存在しません。",
                                               -1,
                                               MessageBoxButtons.OK
                                           );
                        this.tNedit_CustomerCode.Clear();
                        this.CustomerCodeNm_tEdit.Clear();
                        e.NextCtrl = this.uButton_CustomerGuide;
                        e.NextCtrl = this.tNedit_CustomerCode;
                        e.NextCtrl.Select();
                        return;
                    }
                    if (string.IsNullOrEmpty(this.CustomerCodeNm_tEdit.DataText) && this.tNedit_CustomerCode.GetInt() == 0)
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.CustomerCodeNm_tEdit.DataText.Trim() != "")
                            {
                                e.NextCtrl = this.PureSuperio_ComboEditor;
                            }
                        }
                    }
                }
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.uButton_CustomerGuide;
                    }
                }
                else
                {
                    e.NextCtrl = this.SetKind_tComboEditor;
                }
                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _cusModeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tNedit_CustomerCode
                            &&
                        e.NextCtrl == this.uButton_CustomerGuide
                            &&
                        string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim())
                    )
                    {
                        // 何もしない ∵新規モードで起動直後に拠点のガイドボタンをクリックした場合に相当
                    }
                    else if (CusModeChangeProc())
                    {
                        e.NextCtrl = tNedit_CustomerCode;
                    }
                }
            }
            else if (e.PrevCtrl == this.SetKind_tComboEditor)
            {
                if (e.ShiftKey == false)
                {
                    // --- UPD 2011/09/07 -------------------------------->>>>>
                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                    {
                        // --- UPD 2011/09/07 --------------------------------<<<<<
                        if (this.SetKind_tComboEditor.SelectedIndex == 0)
                        {
                            e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                        }
                        else
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                }
                else
                {
                    e.NextCtrl = this.Discriminition_ComboEditor;
                }
            }
            else if (e.PrevCtrl == this.Cancel_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.Discriminition_ComboEditor.Enabled == false)
                        {
                            e.NextCtrl = this.PureSuperio_ComboEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.Discriminition_ComboEditor;
                        }
                    }
                }
                else
                {
                    if (this.Revive_Button.Visible)
                    {
                        e.NextCtrl = this.Revive_Button;
                    }
                    else
                    {
                        e.NextCtrl = this.Ok_Button;
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_CustomerGuide)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                }
                else
                {
                    e.NextCtrl = this.tNedit_CustomerCode;
                }
            }
            else if (e.PrevCtrl == this.SectionGuide_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                }
                else
                {
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                }
            }
            else if (e.PrevCtrl == this.PureSuperio_ComboEditor)
            {
                if (e.ShiftKey == true)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionGuide_Button.Visible)
                        {
                            e.NextCtrl = this.SectionGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = this.uButton_CustomerGuide;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.Discriminition_ComboEditor)
            {
                if (e.ShiftKey == true)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.Cancel_Button;
                    }
                }
            }
            else if (e.PrevCtrl == this.Renewal_Button)
            {
                if (e.Key == Keys.Left)
                {
                    e.NextCtrl = this.Order7_ComboEditor;
                }
            }


            //-------------- ADD BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<<<<<<<
            //-------------- DELETE BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<<<<<<
            //else if (e.PrevCtrl == PrioritySetting_tComboEditor) 
            //{
            //    if ((e.ShiftKey) && (e.Key == Keys.Tab))
            //    {
            //        // SHIFT+TAB制御
            //        if (!tEdit_SectionCodeAllowZero.Enabled)
            //        {
            //            e.NextCtrl = Cancel_Button;
            //        }
            //        else
            //        {
            //            if (SectionName_tEdit.DataText != "")
            //            {
            //                e.NextCtrl = tEdit_SectionCodeAllowZero;
            //            }
            //        }
            //    }
            //}
            //--------------DELETE BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            //------------ADD BY lingxiaoqing 2011.08.08------------------>>>>>>>>>>>>>
            int status = 0;
            ArrayList retList = null;
            SCMPriorSt scmPriorSt = null;
            this.ScreenToSCMPriorSt(ref scmPriorSt);
            status = this._scmPriorStAcs.SearchAll(out retList, this._enterpriseCode);
            foreach (SCMPriorSt sp in retList)
            {
                if (sp.CustomerCode == scmPriorSt.CustomerCode &&
                    sp.SectionCode.TrimEnd().Equals(scmPriorSt.SectionCode.TrimEnd()) &&
                    sp.PriorAppliDiv == scmPriorSt.PriorAppliDiv)
                {
                    SCMPriorStToScreen(sp);
                    // SCM優先設定情報クラスのデータセット展開処理
                    SCMPriorStToDataSet(sp, this.DataIndex);
                }
            }
            //------------ADD BY lingxiaoqing 2011.08.08------------------<<<<<<<<<<<<<
            //this._secInfoAcs.ResetSectionInfo();              //DELETE BY lingxiaoqing 2011.08.08

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン          
        }

        #endregion

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>
        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別の値が変更されたときに発生します。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011.08.08</br>
        /// <br>Update Note : BLパーツオーダー自動回答不具合対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2018/07/26</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (SetKind_tComboEditor.SelectedIndex == 0)
            {
                // 拠点単位
                this.panel_Section.Visible = true;
                this.panel_Customer.Visible = false;
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();
                // フォーカス設定
                this.tEdit_SectionCodeAllowZero2.Focus();
                this.ultraLabel00.Visible = true; // ADD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            }
            else
            {
                // 得意先単位
                this.panel_Section.Visible = false;
                this.panel_Customer.Visible = true;
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionName_tEdit.Clear();
                // フォーカス設定
                this.tNedit_CustomerCode.Focus();
                this.ultraLabel00.Visible = false; // ADD 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応
            }

        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<

        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
        ////------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>
        ///// <summary>
        /////  優先適用区分を選択
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　 : 優先適用区分を選択。</br>
        ///// <br>Programmer : 凌小青</br>
        ///// <br>Date       : 2011.08.08</br>
        ///// </remarks>
        //private void Discriminition_ComboEditor_ValueChanged(object sender, EventArgs e)
        //{
        //    //優先適用区分
        //    if (this.Discriminition_ComboEditor.SelectedIndex == 1)
        //    {
        //        this.ultraLabel5.Visible = false;
        //        this.PureSuperio1_ComboEditor.Visible = false;
        //        this.InStock1_ComboEditor.Visible = false;
        //        this.CampingCode1_ComboEditor.Visible = false;
        //        this.PriorPriceSetCd4_tComboEditor.Visible = false;
        //        this.PriorPriceSetCd5_tComboEditor.Visible = false;
        //        this.PriorPriceSetCd6_tComboEditor.Visible = false;
        //    }
        //    else
        //    {

        //        this.ultraLabel5.Visible = true;
        //        this.PureSuperio1_ComboEditor.Visible = true;
        //        this.InStock1_ComboEditor.Visible = true;
        //        this.CampingCode1_ComboEditor.Visible = true;
        //        this.PriorPriceSetCd4_tComboEditor.Visible = true;
        //        this.PriorPriceSetCd5_tComboEditor.Visible = true;
        //        this.PriorPriceSetCd6_tComboEditor.Visible = true;
        //    }
        //    this.SetKind_tComboEditor.Focus();
        //}
        ////------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<
        // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
    }
}
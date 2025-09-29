using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 伝票印刷確認画面
    /// </summary>
    /// <remarks>
    /// <br>Note         : 伝票印刷確認画面です。</br>
    /// <br>               伝票印刷クラス(ISlipPrintProcを実装するクラス)を呼び出して印刷実行します。</br>
    /// <br>               ( ※このＵＩクラスは、常に「DCCMN02000UA」から呼び出します。 )</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2007.12.17</br>
    /// <br></br>
    /// <br>Update Note  : 2008.01.30 鈴木 正臣</br>
    /// <br>                 ①仕入返品伝票印刷機能を追加</br>
    /// <br>Update Note  : 2008.02.22 鈴木 正臣</br>
    /// <br>                 ①伝票初期値設定マスタを参照しないように変更</br>
    /// <br>                 ②伝票発行後、リモート呼び出しでデータを更新するように変更</br>
    /// <br>Update Note  : 2008.03.11 鈴木 正臣</br>
    /// <br>                 ①売上・仕入制御リモート対応（更新結果をエントリに返却する為の対応）</br>
    /// <br>---------------------------------------------------------------------------------</br>
    /// <br>Update Note  : 2008.05.29 鈴木 正臣</br>
    /// <br>                 ①PM.NS向け変更。</br>
    /// <br>                 ②自由帳票(売上伝票)の印刷機能を追加。</br>
    /// <br>                 ③冗長なInterface判定を削除。</br>
    /// <br>                 ④処理高速化の為,Dクラス使用/PMHNB08001Pならﾘﾌﾚｸｼｮﾝしない/UI表示する場合のみの処理を整理</br>
    /// <br>Update Note  : 2009.07.16  20056 對馬 大輔</br>
    /// <br>             : サーバーへ配置するクライアントアセンブリ対応</br>
    /// <br>             : ①ログイン情報取得方法変更</br>
    /// <br>             : ②サービス起動プロパティ追加</br>
    /// <br>             : ③ウインドウ表示制限追加</br>
    /// <br>Update Note  : 2010.03.04  大矢　睦美</br>
    /// <br>                 ①税率設定、売上金額処理区分設定を取得する</br>
    /// <br>Update Note  : 2010/05/14  22018 鈴木 正臣</br>
    /// <br>                 サブレポート機能の追加。（森川個別対応の為、追加）</br>
    /// <br>Update Note  : 2010/05/18  30531 大矢 睦美</br>
    /// <br>                 UOEガイド名称設定取得対応。（森川個別対応の為、追加）</br>
    /// <br>Update Note  : 2010/06/04  22018 鈴木 正臣</br>
    /// <br>                 成果物統合</br>
    /// <br>                   ＳＣＭ 2009.07.16 の組込</br>
    /// <br>Update Note  : 2010/07/09  22018 鈴木 正臣</br>
    /// <br>                 成果物統合２</br>
    /// <br>                   売上伝票入力のＵＩ上の"ＱＲコード作成"チェックボックス値を受渡可能に変更。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/08/30  30517 夏野 駿希</br>
    /// <br>                 個別対応改良対応</br>
    /// <br>                   自由帳票（売上伝票）個別対応用印刷クラスの個別処理フラグを参照し、処理を分岐する様に修正</br>
    /// <br>             : サービス起動(サーバー)が無くなった為、_isService を常に0とする </br>
    /// <br>Update Note  : 2011/08/09  周正雨</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : リモート伝票発行</br>
    /// <br>Update Note  : 2011/09/16  周正雨</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : 自動印刷区分＋Ｘ，Ｙ位置調整</br>
    /// <br>Update Note  : 2011/09/27  劉思遠</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559の対応</br>
    /// <br>Update Note  : 2011/09/28  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25595の対応</br>
    /// <br>Update Note  : 2011/09/30  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 No2の対応</br>
    /// <br>Update Note  : 2011/10/11  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 の対応</br>
    /// <br>Update Note  : 2011/10/13  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 の対応</br>
    /// <br>Update Note  : 2011/10/15  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 の対応</br>
    /// <br>Update Note  : 2011/10/17  wangqx</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : #25559 PCC全体設定.売上伝票発行区分チィックエーラ対応</br>
    /// <br>Update Note  : 2011/10/19  20056 對馬 大輔</br>
    /// <br>             : 障害対応：在庫移動伝票入力で伝発するとエラー</br>
    /// <br>Update Note  : 2013/04/19  宮本 利明</br>
    /// <br>             : 起動元PGが得意先電子元帳で確認画面を表示する場合、管理№が１のプリンタを初期表示するように修正</br>
    /// <br>Update Note  : 2013/06/17  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : №10542 SCM</br>
    /// <br>Update Note  : 2013/07/28  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : №10542 SCM NO.10の対応</br>
    /// <br>Update Note  : 2013/09/19  30744 湯上</br>
    /// <br>             : Redmine #40342</br>
    /// <br>             : リモート伝票発行時エラー対応</br>
    /// <br>Update Note  : 2013/09/20  吉岡</br>
    /// <br>             : ランテルUOE送信処理 速度遅延対応</br>
    /// <br>Update Note  : 2014/07/30  譚洪</br>
    /// <br>             : 「得意先電子元帳から赤伝を発行すると確認ダイアログが２回表示（売伝を２回印刷）され、リモ伝が出力されない」障害の対応。</br>
    /// <br>             : Redmine#43082「障害一覧No.10664」</br>
    /// <br>Update Note  : 2014/12/05  宮本 利明</br>
    /// <br>             : 仕掛一覧№2295(№1725)対応</br>
    /// <br>             : 印刷処理時に登録したイベントハンドラを、処理終了後に全て削除するように修正</br>
    /// <br>Update Note  : 2013/10/30  30744 湯上</br>
    /// <br>             : SCM仕掛一覧№10614対応</br>
    /// </remarks>
    internal class DCCMN02000UB : System.Windows.Forms.Form
    {
        #region Const
        //===================================
        // その他
        //===================================
        /// <summary>フォーム描画中</summary>
        private const string ctFormDrawingNow = "FORMDRAWING";
        // システム区分
        private const int ctSYSTEMDIV_CD = 0;
        // 画像使用システム区分	
        private const int ctIMAGEUSESYSTEM_CODE = 10;
        // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
        // 呼出元PGID判定用(得意先元帳)
        private const string ctPGID_PMKAU04000U = "PMKAU04000U";
        // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
        #endregion

        #region PrivateMember
        //==================================================================================
        // プライベイトメンバ定義
        //==================================================================================
        //***************************************************************
        // 内部使用メンバ
        //***************************************************************
        // 伝票印刷条件
        private ISlipPrintCndtn _iSlipPrintCndtn;
        // 印刷データ
        private List<ArrayList> _printData;

        // 伝票印刷設定データ
        private SlipPrtSetWork _slipPrtSet;

        // 印刷プレビューフォーム
        private SFMIT01290UA _slipPrintAssemblyFrom;
        // 印刷ドキュメント作成モジュール
        private Object _prtObj = null;
        // 印刷プレビュー用パラメータクラス
        private SFMIT01290UB _prtParam;

        // 企業コード
        private string _enterpriseCode = "";
        // 伝票種別
        private int _slipKind = 0;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
        //// 列項目テーブル
        //private static Hashtable _slipColList = new Hashtable();
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
        // 前回値
        private string _prevText = "";
        private int _prevInt = 0;
        // 画面タイプ(0:簡易版、1:詳細版)
        private int _FormType = 0;

        // ダイアログなし印刷制御フラグ
        private bool _printWithoutDialog;

        // 伝票印刷アクセスクラス
        private SlipPrintAcs _slipPrintAcs;

        // 伝票印刷パラメータ（データクラス外情報）
        private SlipPrintParameter _slipPrintParameter;

        // 伝票印刷ダイアログステータス
        private SlipPrintDialogStatus _slipPrintDialogState;
        // 伝票印刷ダイアログデータキャッシュ
        private SlipDialogDataCache _dataCache;
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>サービス起動フラグ(0:通常 1:サービス起動)</summary> 
        private int _isService = 0;
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        //リモート伝票発行するか
        private bool _IsRmSlpPrt;
        //リモート伝票発行設定情報
        private RmSlpPrtStWork _rmSlpPrtStWork;
        //リモート伝票発行アクセスクラス
        private ScmRtPrtDtAcs _scmRtPrtDtAcs;
        //PCC自社設定マスタアクセスクラス
        PccCmpnyStAcs _pccCmpnyStAcs;
        //PCC全体設定マスタアクセスクラス
        PccTtlStAcs _pccTtlStAcs;
        /// <summary>PCCUOE自動回答起動フラグ(0:通常 1:PCCUOE自動回答起動)</summary> 
        private int _isAutoAns = 0;
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>売上伝票数量は１件フラグ（false:１件以上、true:１件）</summary> 
        private bool _isOnlyOneSlip = false;
        /// <summary>最後送信の売上伝票フラグ（false:最後ではない、true:最後）</summary> 
        private bool _isLastSlip = false;
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>リモート伝票最新識別区分KEY変更フラグ（false:変更しない、true:変更する）</summary> 
        private bool _isKeyChangeFlag = false;
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
        /// <summary>売上伝票番号リスト</summary> 
        private List<string> _slipNumlist;
        /// <summary>問合せ番号リスト</summary> 
        private List<string> _inquiryNumList;
        /// <summary>タブレット起動区分</summary> 
        private bool _isTablet = false;
        // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
        #endregion

        #region Component
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
        private Broadleaf.Library.Windows.Forms.TLine tLine2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox8;
        private System.Windows.Forms.Panel Form1_Fill_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Splitter splitter1;
        private Infragistics.Win.Misc.UltraButton ubDetail;
        private Broadleaf.Library.Windows.Forms.TComboEditor tcePrintType;
        private System.Windows.Forms.Panel pnlBottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager utmMain;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrintCopy;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintCopy;
        private Infragistics.Win.Misc.UltraLabel ulPrintCopy;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrintRange;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintRangeTo;
        private Infragistics.Win.Misc.UltraLabel ulPrintRangeTo;
        private Broadleaf.Library.Windows.Forms.TNedit tnPrintRangeFrom;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosPrintRange;
        private Infragistics.Win.Misc.UltraLabel ulPrintRangeFrom;
        private Infragistics.Win.Misc.UltraGroupBox ugbPrinter;
        private Broadleaf.Library.Windows.Forms.TComboEditor tcePrinterName;
        private Infragistics.Win.Misc.UltraLabel ulPrinterName;
        private Infragistics.Win.Misc.UltraGroupBox ugbFormat;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ucePrevew;
        private Infragistics.Win.Misc.UltraLabel ulPrintMsg;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl utcDetail;
        private Infragistics.Win.Misc.UltraButton ubPdf;
        private Infragistics.Win.Misc.UltraButton ubPrint;
        private Infragistics.Win.Misc.UltraButton ubCancel;
        private System.Windows.Forms.Splitter splitter2;
        private Infragistics.Win.Misc.UltraGroupBox ugbCopyCount;
        private Infragistics.Win.Misc.UltraLabel ulCopyCount;
        private Infragistics.Win.Misc.UltraGroupBox ugbTitle;
        private Infragistics.Win.Misc.UltraLabel ulTitle4;
        private Infragistics.Win.Misc.UltraLabel ulTitle3;
        private Infragistics.Win.Misc.UltraLabel ulTitle2;
        private Infragistics.Win.Misc.UltraLabel ulTitle1;
        private Infragistics.Win.Misc.UltraGroupBox ugbSlipDatePrintDiv;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosSlipDatePrintDiv;
        private Infragistics.Win.Misc.UltraGroupBox ugbEnterpriseNamePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosEnterpriseNamePrtCd;
        private Infragistics.Win.Misc.UltraGroupBox ugbEachSlipTypeColMove;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugEachSlipTypeColMove;
        private Infragistics.Win.Misc.UltraGroupBox ugbEachSlipTypeCol;
        private Infragistics.Win.UltraWinTree.UltraTree utEachSlipTypeCol;
        private Infragistics.Win.Misc.UltraGroupBox ugbOutlinePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosOutlinePrtCd;
        private Infragistics.Win.Misc.UltraGroupBox ugbBankNamePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosBankNamePrtCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSourceColMove;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01407UA_Toolbars_Dock_Area_Bottom;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceSlipFontSize;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceSlipFontStyle;
        private Infragistics.Win.UltraWinEditors.UltraFontNameEditor ufneSlipFontName;
        private Broadleaf.Library.Windows.Forms.TNedit tneTopMargin;
        private Broadleaf.Library.Windows.Forms.TNedit tneLeftMargin;
        private System.Windows.Forms.Panel pnlPrevew;
        private Infragistics.Win.Misc.UltraLabel ulLeftMark1;
        private Infragistics.Win.Misc.UltraLabel ulLeftMark2;
        private Infragistics.Win.Misc.UltraLabel ulTopMark2;
        private Infragistics.Win.Misc.UltraLabel ulTopMark1;
        private Infragistics.Win.Misc.UltraGroupBox ugbMargin;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpHeader;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpDetail;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpDetail2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpMargin;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl utpFont;
        private Broadleaf.Library.Windows.Forms.TNedit tneRightMargin;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TLine tLine3;
        private Broadleaf.Library.Windows.Forms.TLine tLine4;
        private Infragistics.Win.Misc.UltraLabel ulBottomMark2;
        private Infragistics.Win.Misc.UltraLabel ulBottomMark1;
        private Infragistics.Win.Misc.UltraLabel ulRightMark2;
        private Infragistics.Win.Misc.UltraLabel ulRightMark1;
        private Broadleaf.Library.Windows.Forms.TNedit tneBottomMargin;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor tnCopyCount;
        private Infragistics.Win.Misc.UltraGroupBox ugbCustTelNoPrtDivCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosCustTelNoPrtDivCd;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox upbSlipImage;
        private System.Windows.Forms.ImageList ilSlipPrintImage;
        private System.Windows.Forms.PictureBox pbCompanyImage;
        private Infragistics.Win.Misc.UltraGroupBox ugbTotalPricePrtCd;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosTotalPricePrtCd;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.ImageList imgListIntensive;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT4;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT3;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT2;
        private Infragistics.Win.Misc.UltraButton ubSlipColorT1;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT4;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT3;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT2;
        private Infragistics.Win.Misc.UltraLabel ulSlipColorT1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle3;
        private Broadleaf.Library.Windows.Forms.TComboEditor tceTitle4;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttmToolTip;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private System.ComponentModel.IContainer components;
        #endregion

        #region Dispose
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

        // --- ADD 2014/12/05 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// イベントハンドラ削除
        /// </summary>
        public void EventDelete()
        {
            this.uosSlipDatePrintDiv.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.tnCopyCount.ValueChanged -= new System.EventHandler(this.tnCopyCount_TextChanged);
            this.tnCopyCount.Leave -= new System.EventHandler(this.UltraFontNameEditorLeave);
            this.tnCopyCount.Enter -= new System.EventHandler(this.UltraFontNameEditorEnter);
            this.tceTitle4.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle3.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle2.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.tceTitle1.ItemNotInList -= new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            this.ubSlipColorT4.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT3.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT2.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.ubSlipColorT1.Click -= new System.EventHandler(this.ubSlipColor_Click);
            this.uosEnterpriseNamePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosCustTelNoPrtDivCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosTotalPricePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ugEachSlipTypeColMove.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugEachSlipTypeColMove_InitializeLayout);
            this.ugEachSlipTypeColMove.AfterColPosChanged -= new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.ugEachSlipTypeColMove_AfterColPosChanged);
            this.utEachSlipTypeCol.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.utEachSlipTypeCol_AfterCheck);
            this.tneBottomMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneBottomMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneRightMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneRightMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneTopMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneTopMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tneLeftMargin.Leave -= new System.EventHandler(this.tneTopMargin_Leave);
            this.tneLeftMargin.Enter -= new System.EventHandler(this.tneTopMargin_Enter);
            this.tceSlipFontSize.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.Leave -= new System.EventHandler(this.UltraFontNameEditorLeave);
            this.ufneSlipFontName.Enter -= new System.EventHandler(this.UltraFontNameEditorEnter);
            this.tceSlipFontStyle.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosOutlinePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.uosBankNamePrtCd.ValueChanged -= new System.EventHandler(this.ItemValueChanged);
            this.utmMain.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utmMain_ToolClick);
            this.tnPrintRangeTo.ValueChanged -= new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            this.tnPrintRangeFrom.ValueChanged -= new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            this.uosPrintRange.ValueChanged -= new System.EventHandler(this.uosPrintRange_ValueChanged);
            this.ubDetail.Click -= new System.EventHandler(this.ubDetail_Click);
            this.tcePrintType.ValueChanged -= new System.EventHandler(this.tcePrintType_ValueChanged);
            this.ubCancel.Click -= new System.EventHandler(this.ubPrint_Click);
            this.ubPrint.Click -= new System.EventHandler(this.ubPrint_Click);
            this.ubPdf.Click -= new System.EventHandler(this.ubPrint_Click);
            this.tRetKeyControl1.ChangeFocus -= new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            this.tArrowKeyControl1.ChangeFocus -= new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            this.Load -= new System.EventHandler(this.DCCMN02000UB_Load);
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.DCCMN02000UA_KeyDown);
        }
        // --- ADD 2014/12/05 T.Miyamoto ------------------------------<<<<<
        #endregion

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("色選択ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("色選択ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("色選択ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("色選択ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ColMove", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 0");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 4");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 6");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 7");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 8");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 9");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 0");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 1");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 2");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 3");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 4");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 5");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 6");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 7");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn9 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 8");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn10 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column 9");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton2 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton3 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton4 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cancel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cancel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf");
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton5 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton6 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton7 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCCMN02000UB));
            this.utpHeader = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbSlipDatePrintDiv = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosSlipDatePrintDiv = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbCopyCount = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnCopyCount = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ulCopyCount = new Infragistics.Win.Misc.UltraLabel();
            this.ugbTitle = new Infragistics.Win.Misc.UltraGroupBox();
            this.tceTitle4 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle3 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tceTitle1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ubSlipColorT4 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT3 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT2 = new Infragistics.Win.Misc.UltraButton();
            this.ubSlipColorT1 = new Infragistics.Win.Misc.UltraButton();
            this.ulSlipColorT4 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulSlipColorT1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTitle4 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbEnterpriseNamePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosEnterpriseNamePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbCustTelNoPrtDivCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosCustTelNoPrtDivCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utpDetail = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbTotalPricePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosTotalPricePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utpDetail2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbEachSlipTypeColMove = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ugEachSlipTypeColMove = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSourceColMove = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ugbEachSlipTypeCol = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.utEachSlipTypeCol = new Infragistics.Win.UltraWinTree.UltraTree();
            this.utpMargin = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ugbMargin = new Infragistics.Win.Misc.UltraGroupBox();
            this.ulRightMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulRightMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulBottomMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulBottomMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tneBottomMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tneRightMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulTopMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulLeftMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulLeftMark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulTopMark2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tneTopMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tneLeftMargin = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.upbSlipImage = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.utpFont = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox8 = new Infragistics.Win.Misc.UltraGroupBox();
            this.pbCompanyImage = new System.Windows.Forms.PictureBox();
            this.tceSlipFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ufneSlipFontName = new Infragistics.Win.UltraWinEditors.UltraFontNameEditor();
            this.tceSlipFontStyle = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbOutlinePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosOutlinePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ugbBankNamePrtCd = new Infragistics.Win.Misc.UltraGroupBox();
            this.uosBankNamePrtCd = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.utcDetail = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.utmMain = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.pnlPrevew = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ugbPrintCopy = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnPrintCopy = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulPrintCopy = new Infragistics.Win.Misc.UltraLabel();
            this.ugbPrintRange = new Infragistics.Win.Misc.UltraGroupBox();
            this.tnPrintRangeTo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ulPrintRangeTo = new Infragistics.Win.Misc.UltraLabel();
            this.tnPrintRangeFrom = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uosPrintRange = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ulPrintRangeFrom = new Infragistics.Win.Misc.UltraLabel();
            this.ugbPrinter = new Infragistics.Win.Misc.UltraGroupBox();
            this.tcePrinterName = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ulPrinterName = new Infragistics.Win.Misc.UltraLabel();
            this.ugbFormat = new Infragistics.Win.Misc.UltraGroupBox();
            this.ubDetail = new Infragistics.Win.Misc.UltraButton();
            this.ucePrevew = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ulPrintMsg = new Infragistics.Win.Misc.UltraLabel();
            this.tcePrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubPrint = new Infragistics.Win.Misc.UltraButton();
            this.ubPdf = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._SFMIT01407UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ilSlipPrintImage = new System.Windows.Forms.ImageList(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.imgListIntensive = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.uttmToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.utpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbSlipDatePrintDiv)).BeginInit();
            this.ugbSlipDatePrintDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosSlipDatePrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCopyCount)).BeginInit();
            this.ugbCopyCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnCopyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTitle)).BeginInit();
            this.ugbTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEnterpriseNamePrtCd)).BeginInit();
            this.ugbEnterpriseNamePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosEnterpriseNamePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCustTelNoPrtDivCd)).BeginInit();
            this.ugbCustTelNoPrtDivCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosCustTelNoPrtDivCd)).BeginInit();
            this.utpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTotalPricePrtCd)).BeginInit();
            this.ugbTotalPricePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosTotalPricePrtCd)).BeginInit();
            this.utpDetail2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeColMove)).BeginInit();
            this.ugbEachSlipTypeColMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugEachSlipTypeColMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSourceColMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeCol)).BeginInit();
            this.ugbEachSlipTypeCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utEachSlipTypeCol)).BeginInit();
            this.utpMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbMargin)).BeginInit();
            this.ugbMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            this.utpFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).BeginInit();
            this.ultraGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufneSlipFontName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbOutlinePrtCd)).BeginInit();
            this.ugbOutlinePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosOutlinePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbBankNamePrtCd)).BeginInit();
            this.ugbBankNamePrtCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uosBankNamePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utcDetail)).BeginInit();
            this.utcDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utmMain)).BeginInit();
            this.Form1_Fill_Panel.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintCopy)).BeginInit();
            this.ugbPrintCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintRange)).BeginInit();
            this.ugbPrintRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosPrintRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrinter)).BeginInit();
            this.ugbPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbFormat)).BeginInit();
            this.ugbFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrintType)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // utpHeader
            // 
            this.utpHeader.Controls.Add(this.ugbSlipDatePrintDiv);
            this.utpHeader.Controls.Add(this.ugbCopyCount);
            this.utpHeader.Controls.Add(this.ugbTitle);
            this.utpHeader.Controls.Add(this.ugbEnterpriseNamePrtCd);
            this.utpHeader.Controls.Add(this.ugbCustTelNoPrtDivCd);
            this.utpHeader.Location = new System.Drawing.Point(1, 22);
            this.utpHeader.Name = "utpHeader";
            this.utpHeader.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbSlipDatePrintDiv
            // 
            this.ugbSlipDatePrintDiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbSlipDatePrintDiv.BackColorInternal = System.Drawing.Color.White;
            this.ugbSlipDatePrintDiv.Controls.Add(this.uosSlipDatePrintDiv);
            this.ugbSlipDatePrintDiv.Location = new System.Drawing.Point(8, 184);
            this.ugbSlipDatePrintDiv.Name = "ugbSlipDatePrintDiv";
            this.ugbSlipDatePrintDiv.Size = new System.Drawing.Size(458, 44);
            this.ugbSlipDatePrintDiv.TabIndex = 130;
            this.ugbSlipDatePrintDiv.Text = "発行日付の印字";
            // 
            // uosSlipDatePrintDiv
            // 
            this.uosSlipDatePrintDiv.BackColor = System.Drawing.Color.White;
            this.uosSlipDatePrintDiv.BackColorInternal = System.Drawing.Color.White;
            this.uosSlipDatePrintDiv.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosSlipDatePrintDiv.CheckedIndex = 0;
            this.uosSlipDatePrintDiv.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "印字する";
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "印字しない";
            this.uosSlipDatePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.uosSlipDatePrintDiv.ItemSpacingHorizontal = 6;
            this.uosSlipDatePrintDiv.ItemSpacingVertical = 2;
            this.uosSlipDatePrintDiv.Location = new System.Drawing.Point(32, 20);
            this.uosSlipDatePrintDiv.Name = "uosSlipDatePrintDiv";
            this.uosSlipDatePrintDiv.Size = new System.Drawing.Size(156, 20);
            this.uosSlipDatePrintDiv.TabIndex = 131;
            this.uosSlipDatePrintDiv.Text = "印字する";
            this.uosSlipDatePrintDiv.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbCopyCount
            // 
            this.ugbCopyCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbCopyCount.BackColorInternal = System.Drawing.Color.White;
            this.ugbCopyCount.Controls.Add(this.tnCopyCount);
            this.ugbCopyCount.Controls.Add(this.ulCopyCount);
            this.ugbCopyCount.Location = new System.Drawing.Point(8, 8);
            this.ugbCopyCount.Name = "ugbCopyCount";
            this.ugbCopyCount.Size = new System.Drawing.Size(458, 44);
            this.ugbCopyCount.TabIndex = 110;
            this.ugbCopyCount.Text = "複写枚数";
            // 
            // tnCopyCount
            // 
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tnCopyCount.Appearance = appearance2;
            this.tnCopyCount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnCopyCount.Location = new System.Drawing.Point(88, 16);
            this.tnCopyCount.MaxValue = 9;
            this.tnCopyCount.MinValue = 1;
            this.tnCopyCount.Name = "tnCopyCount";
            this.tnCopyCount.PromptChar = ' ';
            this.tnCopyCount.Size = new System.Drawing.Size(72, 21);
            this.tnCopyCount.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.tnCopyCount.TabIndex = 112;
            this.tnCopyCount.Value = 4;
            this.tnCopyCount.ValueChanged += new System.EventHandler(this.tnCopyCount_TextChanged);
            this.tnCopyCount.Leave += new System.EventHandler(this.UltraFontNameEditorLeave);
            this.tnCopyCount.Enter += new System.EventHandler(this.UltraFontNameEditorEnter);
            // 
            // ulCopyCount
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ulCopyCount.Appearance = appearance3;
            this.ulCopyCount.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulCopyCount.Location = new System.Drawing.Point(12, 20);
            this.ulCopyCount.Name = "ulCopyCount";
            this.ulCopyCount.Size = new System.Drawing.Size(60, 16);
            this.ulCopyCount.TabIndex = 2;
            this.ulCopyCount.Text = "複写枚数";
            // 
            // ugbTitle
            // 
            this.ugbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbTitle.BackColorInternal = System.Drawing.Color.White;
            this.ugbTitle.Controls.Add(this.tceTitle4);
            this.ugbTitle.Controls.Add(this.tceTitle3);
            this.ugbTitle.Controls.Add(this.tceTitle2);
            this.ugbTitle.Controls.Add(this.tceTitle1);
            this.ugbTitle.Controls.Add(this.ubSlipColorT4);
            this.ugbTitle.Controls.Add(this.ubSlipColorT3);
            this.ugbTitle.Controls.Add(this.ubSlipColorT2);
            this.ugbTitle.Controls.Add(this.ubSlipColorT1);
            this.ugbTitle.Controls.Add(this.ulSlipColorT4);
            this.ugbTitle.Controls.Add(this.ulSlipColorT3);
            this.ugbTitle.Controls.Add(this.ulSlipColorT2);
            this.ugbTitle.Controls.Add(this.ulSlipColorT1);
            this.ugbTitle.Controls.Add(this.ulTitle1);
            this.ugbTitle.Controls.Add(this.ulTitle2);
            this.ugbTitle.Controls.Add(this.ulTitle3);
            this.ugbTitle.Controls.Add(this.ulTitle4);
            this.ugbTitle.Location = new System.Drawing.Point(8, 56);
            this.ugbTitle.Name = "ugbTitle";
            this.ugbTitle.Size = new System.Drawing.Size(458, 124);
            this.ugbTitle.TabIndex = 120;
            this.ugbTitle.Text = "タイトル";
            // 
            // tceTitle4
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle4.ActiveAppearance = appearance4;
            this.tceTitle4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle4.ItemAppearance = appearance5;
            this.tceTitle4.Location = new System.Drawing.Point(54, 97);
            this.tceTitle4.MaxLength = 20;
            this.tceTitle4.Name = "tceTitle4";
            this.tceTitle4.Size = new System.Drawing.Size(268, 21);
            this.tceTitle4.TabIndex = 127;
            this.tceTitle4.Tag = "4";
            this.tceTitle4.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle3
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle3.ActiveAppearance = appearance6;
            this.tceTitle3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle3.ItemAppearance = appearance7;
            this.tceTitle3.Location = new System.Drawing.Point(54, 72);
            this.tceTitle3.MaxLength = 20;
            this.tceTitle3.Name = "tceTitle3";
            this.tceTitle3.Size = new System.Drawing.Size(268, 21);
            this.tceTitle3.TabIndex = 125;
            this.tceTitle3.Tag = "3";
            this.tceTitle3.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle2
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle2.ActiveAppearance = appearance8;
            this.tceTitle2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle2.ItemAppearance = appearance9;
            this.tceTitle2.Location = new System.Drawing.Point(54, 47);
            this.tceTitle2.MaxLength = 20;
            this.tceTitle2.Name = "tceTitle2";
            this.tceTitle2.Size = new System.Drawing.Size(268, 21);
            this.tceTitle2.TabIndex = 123;
            this.tceTitle2.Tag = "2";
            this.tceTitle2.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // tceTitle1
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle1.ActiveAppearance = appearance10;
            this.tceTitle1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceTitle1.ItemAppearance = appearance11;
            this.tceTitle1.Location = new System.Drawing.Point(54, 22);
            this.tceTitle1.MaxLength = 20;
            this.tceTitle1.Name = "tceTitle1";
            this.tceTitle1.Size = new System.Drawing.Size(268, 21);
            this.tceTitle1.TabIndex = 121;
            this.tceTitle1.Tag = "1";
            this.tceTitle1.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.tceTitle_ItemNotInList);
            // 
            // ubSlipColorT4
            // 
            this.ubSlipColorT4.Location = new System.Drawing.Point(396, 95);
            this.ubSlipColorT4.Name = "ubSlipColorT4";
            this.ubSlipColorT4.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT4.TabIndex = 128;
            this.ubSlipColorT4.Tag = "4";
            ultraToolTipInfo1.ToolTipText = "色選択ガイド";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT4, ultraToolTipInfo1);
            this.ubSlipColorT4.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT4.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT3
            // 
            this.ubSlipColorT3.Location = new System.Drawing.Point(396, 70);
            this.ubSlipColorT3.Name = "ubSlipColorT3";
            this.ubSlipColorT3.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT3.TabIndex = 126;
            this.ubSlipColorT3.Tag = "3";
            ultraToolTipInfo2.ToolTipText = "色選択ガイド";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT3, ultraToolTipInfo2);
            this.ubSlipColorT3.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT3.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT2
            // 
            this.ubSlipColorT2.Location = new System.Drawing.Point(396, 45);
            this.ubSlipColorT2.Name = "ubSlipColorT2";
            this.ubSlipColorT2.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT2.TabIndex = 124;
            this.ubSlipColorT2.Tag = "2";
            ultraToolTipInfo3.ToolTipText = "色選択ガイド";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT2, ultraToolTipInfo3);
            this.ubSlipColorT2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT2.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ubSlipColorT1
            // 
            this.ubSlipColorT1.Location = new System.Drawing.Point(396, 20);
            this.ubSlipColorT1.Name = "ubSlipColorT1";
            this.ubSlipColorT1.Size = new System.Drawing.Size(25, 24);
            this.ubSlipColorT1.TabIndex = 122;
            this.ubSlipColorT1.Tag = "1";
            ultraToolTipInfo4.ToolTipText = "色選択ガイド";
            this.uttmToolTip.SetUltraToolTip(this.ubSlipColorT1, ultraToolTipInfo4);
            this.ubSlipColorT1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubSlipColorT1.Click += new System.EventHandler(this.ubSlipColor_Click);
            // 
            // ulSlipColorT4
            // 
            appearance12.BorderColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            this.ulSlipColorT4.Appearance = appearance12;
            this.ulSlipColorT4.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT4.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT4.Enabled = false;
            this.ulSlipColorT4.Location = new System.Drawing.Point(332, 97);
            this.ulSlipColorT4.Name = "ulSlipColorT4";
            this.ulSlipColorT4.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT4.TabIndex = 139;
            // 
            // ulSlipColorT3
            // 
            appearance13.BorderColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.ulSlipColorT3.Appearance = appearance13;
            this.ulSlipColorT3.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT3.Enabled = false;
            this.ulSlipColorT3.Location = new System.Drawing.Point(332, 72);
            this.ulSlipColorT3.Name = "ulSlipColorT3";
            this.ulSlipColorT3.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT3.TabIndex = 138;
            // 
            // ulSlipColorT2
            // 
            appearance14.BorderColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.ulSlipColorT2.Appearance = appearance14;
            this.ulSlipColorT2.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT2.Enabled = false;
            this.ulSlipColorT2.Location = new System.Drawing.Point(332, 47);
            this.ulSlipColorT2.Name = "ulSlipColorT2";
            this.ulSlipColorT2.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT2.TabIndex = 137;
            // 
            // ulSlipColorT1
            // 
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.ulSlipColorT1.Appearance = appearance15;
            this.ulSlipColorT1.BackColorInternal = System.Drawing.Color.White;
            this.ulSlipColorT1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ulSlipColorT1.Enabled = false;
            this.ulSlipColorT1.Location = new System.Drawing.Point(332, 22);
            this.ulSlipColorT1.Name = "ulSlipColorT1";
            this.ulSlipColorT1.Size = new System.Drawing.Size(58, 21);
            this.ulSlipColorT1.TabIndex = 135;
            // 
            // ulTitle1
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ulTitle1.Appearance = appearance16;
            this.ulTitle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle1.Location = new System.Drawing.Point(12, 24);
            this.ulTitle1.Name = "ulTitle1";
            this.ulTitle1.Size = new System.Drawing.Size(48, 16);
            this.ulTitle1.TabIndex = 5;
            this.ulTitle1.Text = "１枚目";
            // 
            // ulTitle2
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ulTitle2.Appearance = appearance17;
            this.ulTitle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle2.Location = new System.Drawing.Point(12, 49);
            this.ulTitle2.Name = "ulTitle2";
            this.ulTitle2.Size = new System.Drawing.Size(48, 16);
            this.ulTitle2.TabIndex = 6;
            this.ulTitle2.Text = "２枚目";
            // 
            // ulTitle3
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ulTitle3.Appearance = appearance18;
            this.ulTitle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle3.Location = new System.Drawing.Point(12, 74);
            this.ulTitle3.Name = "ulTitle3";
            this.ulTitle3.Size = new System.Drawing.Size(48, 16);
            this.ulTitle3.TabIndex = 7;
            this.ulTitle3.Text = "３枚目";
            // 
            // ulTitle4
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ulTitle4.Appearance = appearance19;
            this.ulTitle4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTitle4.Location = new System.Drawing.Point(12, 99);
            this.ulTitle4.Name = "ulTitle4";
            this.ulTitle4.Size = new System.Drawing.Size(48, 16);
            this.ulTitle4.TabIndex = 8;
            this.ulTitle4.Text = "４枚目";
            // 
            // ugbEnterpriseNamePrtCd
            // 
            this.ugbEnterpriseNamePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEnterpriseNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbEnterpriseNamePrtCd.Controls.Add(this.uosEnterpriseNamePrtCd);
            this.ugbEnterpriseNamePrtCd.Location = new System.Drawing.Point(8, 280);
            this.ugbEnterpriseNamePrtCd.Name = "ugbEnterpriseNamePrtCd";
            this.ugbEnterpriseNamePrtCd.Size = new System.Drawing.Size(458, 44);
            this.ugbEnterpriseNamePrtCd.TabIndex = 150;
            this.ugbEnterpriseNamePrtCd.Text = "自社名印字";
            // 
            // uosEnterpriseNamePrtCd
            // 
            this.uosEnterpriseNamePrtCd.BackColor = System.Drawing.Color.White;
            this.uosEnterpriseNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosEnterpriseNamePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosEnterpriseNamePrtCd.CheckedIndex = 0;
            this.uosEnterpriseNamePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem12.DataValue = 0;
            valueListItem12.DisplayText = "自社名印字";
            valueListItem13.DataValue = 1;
            valueListItem13.DisplayText = "拠点名印字";
            valueListItem14.DataValue = 2;
            valueListItem14.DisplayText = "ビットマップ印字";
            valueListItem15.DataValue = 3;
            valueListItem15.DisplayText = "印字しない";
            this.uosEnterpriseNamePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15});
            this.uosEnterpriseNamePrtCd.ItemSpacingHorizontal = 6;
            this.uosEnterpriseNamePrtCd.ItemSpacingVertical = 2;
            this.uosEnterpriseNamePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosEnterpriseNamePrtCd.Name = "uosEnterpriseNamePrtCd";
            this.uosEnterpriseNamePrtCd.Size = new System.Drawing.Size(372, 20);
            this.uosEnterpriseNamePrtCd.TabIndex = 151;
            this.uosEnterpriseNamePrtCd.Text = "自社名印字";
            this.uosEnterpriseNamePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbCustTelNoPrtDivCd
            // 
            this.ugbCustTelNoPrtDivCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbCustTelNoPrtDivCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbCustTelNoPrtDivCd.Controls.Add(this.uosCustTelNoPrtDivCd);
            this.ugbCustTelNoPrtDivCd.Location = new System.Drawing.Point(8, 232);
            this.ugbCustTelNoPrtDivCd.Name = "ugbCustTelNoPrtDivCd";
            this.ugbCustTelNoPrtDivCd.Size = new System.Drawing.Size(458, 44);
            this.ugbCustTelNoPrtDivCd.TabIndex = 140;
            this.ugbCustTelNoPrtDivCd.Text = "得意先電話番号の印字";
            // 
            // uosCustTelNoPrtDivCd
            // 
            this.uosCustTelNoPrtDivCd.BackColor = System.Drawing.Color.White;
            this.uosCustTelNoPrtDivCd.BackColorInternal = System.Drawing.Color.White;
            this.uosCustTelNoPrtDivCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosCustTelNoPrtDivCd.CheckedIndex = 0;
            this.uosCustTelNoPrtDivCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "印字する";
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "印字しない";
            this.uosCustTelNoPrtDivCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem16,
            valueListItem17});
            this.uosCustTelNoPrtDivCd.ItemSpacingHorizontal = 6;
            this.uosCustTelNoPrtDivCd.ItemSpacingVertical = 2;
            this.uosCustTelNoPrtDivCd.Location = new System.Drawing.Point(32, 20);
            this.uosCustTelNoPrtDivCd.Name = "uosCustTelNoPrtDivCd";
            this.uosCustTelNoPrtDivCd.Size = new System.Drawing.Size(156, 20);
            this.uosCustTelNoPrtDivCd.TabIndex = 141;
            this.uosCustTelNoPrtDivCd.Text = "印字する";
            this.uosCustTelNoPrtDivCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utpDetail
            // 
            this.utpDetail.Controls.Add(this.ugbTotalPricePrtCd);
            this.utpDetail.Location = new System.Drawing.Point(-10000, -10000);
            this.utpDetail.Name = "utpDetail";
            this.utpDetail.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbTotalPricePrtCd
            // 
            this.ugbTotalPricePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbTotalPricePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.ugbTotalPricePrtCd.Controls.Add(this.uosTotalPricePrtCd);
            this.ugbTotalPricePrtCd.Location = new System.Drawing.Point(8, 8);
            this.ugbTotalPricePrtCd.Name = "ugbTotalPricePrtCd";
            this.ugbTotalPricePrtCd.Size = new System.Drawing.Size(458, 44);
            this.ugbTotalPricePrtCd.TabIndex = 285;
            this.ugbTotalPricePrtCd.Text = "合計金額印字区分";
            // 
            // uosTotalPricePrtCd
            // 
            this.uosTotalPricePrtCd.BackColor = System.Drawing.Color.White;
            this.uosTotalPricePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosTotalPricePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosTotalPricePrtCd.CheckedIndex = 0;
            this.uosTotalPricePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "全てのページ";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "先頭ページのみ";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "最終ページのみ";
            this.uosTotalPricePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.uosTotalPricePrtCd.ItemSpacingHorizontal = 6;
            this.uosTotalPricePrtCd.ItemSpacingVertical = 2;
            this.uosTotalPricePrtCd.Location = new System.Drawing.Point(32, 19);
            this.uosTotalPricePrtCd.Name = "uosTotalPricePrtCd";
            this.uosTotalPricePrtCd.Size = new System.Drawing.Size(292, 20);
            this.uosTotalPricePrtCd.TabIndex = 286;
            this.uosTotalPricePrtCd.Text = "全てのページ";
            this.uosTotalPricePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utpDetail2
            // 
            this.utpDetail2.Controls.Add(this.ugbEachSlipTypeColMove);
            this.utpDetail2.Controls.Add(this.ugbEachSlipTypeCol);
            this.utpDetail2.Location = new System.Drawing.Point(-10000, -10000);
            this.utpDetail2.Name = "utpDetail2";
            this.utpDetail2.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbEachSlipTypeColMove
            // 
            this.ugbEachSlipTypeColMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEachSlipTypeColMove.BackColorInternal = System.Drawing.Color.White;
            this.ugbEachSlipTypeColMove.Controls.Add(this.ultraLabel1);
            this.ugbEachSlipTypeColMove.Controls.Add(this.ugEachSlipTypeColMove);
            this.ugbEachSlipTypeColMove.Location = new System.Drawing.Point(8, 196);
            this.ugbEachSlipTypeColMove.Name = "ugbEachSlipTypeColMove";
            this.ugbEachSlipTypeColMove.Size = new System.Drawing.Size(466, 192);
            this.ugbEachSlipTypeColMove.TabIndex = 320;
            this.ugbEachSlipTypeColMove.Text = "列位置";
            // 
            // ultraLabel1
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance23;
            this.ultraLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(16, 20);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(328, 23);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "列をドラッグ＆ドロップで移動できます";
            // 
            // ugEachSlipTypeColMove
            // 
            this.ugEachSlipTypeColMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugEachSlipTypeColMove.DataSource = this.ultraDataSourceColMove;
            appearance24.BackColor = System.Drawing.Color.White;
            this.ugEachSlipTypeColMove.DisplayLayout.Appearance = appearance24;
            this.ugEachSlipTypeColMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 196;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 8;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 8;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 8;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 8;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 9;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 35;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 40;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Width = 48;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Width = 48;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.ugEachSlipTypeColMove.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.CardAreaAppearance = appearance25;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance26.BackColor = System.Drawing.Color.LightGray;
            appearance26.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.FontData.Name = "MS UI Gothic";
            appearance26.FontData.SizeInPoints = 10F;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.HeaderAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance27.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSelectorAppearance = appearance27;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance28.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectedRowAppearance = appearance28;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugEachSlipTypeColMove.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugEachSlipTypeColMove.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugEachSlipTypeColMove.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.ugEachSlipTypeColMove.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugEachSlipTypeColMove.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ugEachSlipTypeColMove.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ugEachSlipTypeColMove.Location = new System.Drawing.Point(12, 56);
            this.ugEachSlipTypeColMove.Name = "ugEachSlipTypeColMove";
            this.ugEachSlipTypeColMove.Size = new System.Drawing.Size(446, 32);
            this.ugEachSlipTypeColMove.TabIndex = 321;
            this.ugEachSlipTypeColMove.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugEachSlipTypeColMove_InitializeLayout);
            this.ugEachSlipTypeColMove.AfterColPosChanged += new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.ugEachSlipTypeColMove_AfterColPosChanged);
            // 
            // ultraDataSourceColMove
            // 
            this.ultraDataSourceColMove.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6,
            ultraDataColumn7,
            ultraDataColumn8,
            ultraDataColumn9,
            ultraDataColumn10});
            this.ultraDataSourceColMove.Band.Key = "ColMove";
            // 
            // ugbEachSlipTypeCol
            // 
            this.ugbEachSlipTypeCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbEachSlipTypeCol.BackColorInternal = System.Drawing.Color.White;
            this.ugbEachSlipTypeCol.Controls.Add(this.ultraLabel2);
            this.ugbEachSlipTypeCol.Controls.Add(this.utEachSlipTypeCol);
            this.ugbEachSlipTypeCol.Location = new System.Drawing.Point(8, 8);
            this.ugbEachSlipTypeCol.Name = "ugbEachSlipTypeCol";
            this.ugbEachSlipTypeCol.Size = new System.Drawing.Size(466, 184);
            this.ugbEachSlipTypeCol.TabIndex = 310;
            this.ugbEachSlipTypeCol.Text = "印刷項目";
            // 
            // ultraLabel2
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance29;
            this.ultraLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(16, 28);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(220, 16);
            this.ultraLabel2.TabIndex = 5;
            this.ultraLabel2.Text = "印字する列を指定できます";
            // 
            // utEachSlipTypeCol
            // 
            this.utEachSlipTypeCol.HideSelection = false;
            this.utEachSlipTypeCol.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.utEachSlipTypeCol.Location = new System.Drawing.Point(16, 48);
            this.utEachSlipTypeCol.Name = "utEachSlipTypeCol";
            this.utEachSlipTypeCol.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.utEachSlipTypeCol.Override = _override1;
            this.utEachSlipTypeCol.Size = new System.Drawing.Size(206, 116);
            this.utEachSlipTypeCol.TabIndex = 311;
            this.utEachSlipTypeCol.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.utEachSlipTypeCol_AfterCheck);
            // 
            // utpMargin
            // 
            this.utpMargin.Controls.Add(this.ugbMargin);
            this.utpMargin.Location = new System.Drawing.Point(-10000, -10000);
            this.utpMargin.Name = "utpMargin";
            this.utpMargin.Size = new System.Drawing.Size(474, 383);
            // 
            // ugbMargin
            // 
            this.ugbMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance37.BackColor = System.Drawing.Color.White;
            this.ugbMargin.Appearance = appearance37;
            this.ugbMargin.Controls.Add(this.ulRightMark2);
            this.ugbMargin.Controls.Add(this.ulRightMark1);
            this.ugbMargin.Controls.Add(this.ulBottomMark1);
            this.ugbMargin.Controls.Add(this.ulBottomMark2);
            this.ugbMargin.Controls.Add(this.tLine4);
            this.ugbMargin.Controls.Add(this.tLine3);
            this.ugbMargin.Controls.Add(this.tneBottomMargin);
            this.ugbMargin.Controls.Add(this.ultraLabel4);
            this.ugbMargin.Controls.Add(this.ultraLabel3);
            this.ugbMargin.Controls.Add(this.tneRightMargin);
            this.ugbMargin.Controls.Add(this.ulTopMark1);
            this.ugbMargin.Controls.Add(this.ulLeftMark2);
            this.ugbMargin.Controls.Add(this.ulLeftMark1);
            this.ugbMargin.Controls.Add(this.ulTopMark2);
            this.ugbMargin.Controls.Add(this.tLine1);
            this.ugbMargin.Controls.Add(this.tneTopMargin);
            this.ugbMargin.Controls.Add(this.tneLeftMargin);
            this.ugbMargin.Controls.Add(this.ultraLabel11);
            this.ugbMargin.Controls.Add(this.ultraLabel10);
            this.ugbMargin.Controls.Add(this.tLine2);
            this.ugbMargin.Controls.Add(this.upbSlipImage);
            this.ugbMargin.Location = new System.Drawing.Point(8, 8);
            this.ugbMargin.Name = "ugbMargin";
            this.ugbMargin.Size = new System.Drawing.Size(458, 368);
            this.ugbMargin.TabIndex = 510;
            this.ugbMargin.Text = "余白";
            // 
            // ulRightMark2
            // 
            appearance38.ForeColor = System.Drawing.Color.Red;
            appearance38.TextVAlignAsString = "Middle";
            this.ulRightMark2.Appearance = appearance38;
            this.ulRightMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulRightMark2.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulRightMark2.Location = new System.Drawing.Point(264, 284);
            this.ulRightMark2.Name = "ulRightMark2";
            this.ulRightMark2.Size = new System.Drawing.Size(19, 16);
            this.ulRightMark2.TabIndex = 522;
            this.ulRightMark2.Text = "↑";
            this.ulRightMark2.Visible = false;
            // 
            // ulRightMark1
            // 
            appearance39.ForeColor = System.Drawing.Color.Red;
            appearance39.TextVAlignAsString = "Middle";
            this.ulRightMark1.Appearance = appearance39;
            this.ulRightMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulRightMark1.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulRightMark1.Location = new System.Drawing.Point(264, 72);
            this.ulRightMark1.Name = "ulRightMark1";
            this.ulRightMark1.Size = new System.Drawing.Size(19, 13);
            this.ulRightMark1.TabIndex = 521;
            this.ulRightMark1.Text = "↓";
            this.ulRightMark1.Visible = false;
            // 
            // ulBottomMark1
            // 
            appearance40.ForeColor = System.Drawing.Color.Red;
            appearance40.TextVAlignAsString = "Middle";
            this.ulBottomMark1.Appearance = appearance40;
            this.ulBottomMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulBottomMark1.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulBottomMark1.Location = new System.Drawing.Point(128, 256);
            this.ulBottomMark1.Name = "ulBottomMark1";
            this.ulBottomMark1.Size = new System.Drawing.Size(19, 13);
            this.ulBottomMark1.TabIndex = 520;
            this.ulBottomMark1.Text = "→";
            this.ulBottomMark1.Visible = false;
            // 
            // ulBottomMark2
            // 
            appearance41.ForeColor = System.Drawing.Color.Red;
            appearance41.TextVAlignAsString = "Middle";
            this.ulBottomMark2.Appearance = appearance41;
            this.ulBottomMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulBottomMark2.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulBottomMark2.Location = new System.Drawing.Point(292, 256);
            this.ulBottomMark2.Name = "ulBottomMark2";
            this.ulBottomMark2.Size = new System.Drawing.Size(19, 13);
            this.ulBottomMark2.TabIndex = 519;
            this.ulBottomMark2.Text = "←";
            this.ulBottomMark2.Visible = false;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.Location = new System.Drawing.Point(140, 260);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(160, 12);
            this.tLine4.TabIndex = 518;
            this.tLine4.Text = "tLine4";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine3.Location = new System.Drawing.Point(276, 84);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(8, 204);
            this.tLine3.TabIndex = 517;
            this.tLine3.Text = "tLine3";
            // 
            // tneBottomMargin
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneBottomMargin.ActiveAppearance = appearance42;
            this.tneBottomMargin.AutoSelect = true;
            dropDownEditorButton1.Tag = "NEditCalculator";
            this.tneBottomMargin.ButtonsRight.Add(dropDownEditorButton1);
            this.tneBottomMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneBottomMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneBottomMargin.DataText = "";
            this.tneBottomMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneBottomMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneBottomMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneBottomMargin.Location = new System.Drawing.Point(209, 300);
            this.tneBottomMargin.MaxLength = 5;
            this.tneBottomMargin.Name = "tneBottomMargin";
            this.tneBottomMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneBottomMargin.Size = new System.Drawing.Size(69, 21);
            this.tneBottomMargin.TabIndex = 514;
            this.tneBottomMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneBottomMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ultraLabel4
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance43;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(169, 300);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(40, 20);
            this.ultraLabel4.TabIndex = 9;
            this.ultraLabel4.Text = "下(&B)";
            // 
            // ultraLabel3
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance44;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(300, 144);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(56, 20);
            this.ultraLabel3.TabIndex = 8;
            this.ultraLabel3.Text = "右(&R)";
            // 
            // tneRightMargin
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneRightMargin.ActiveAppearance = appearance45;
            this.tneRightMargin.AutoSelect = true;
            dropDownEditorButton2.Tag = "NEditCalculator";
            this.tneRightMargin.ButtonsRight.Add(dropDownEditorButton2);
            this.tneRightMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneRightMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneRightMargin.DataText = "";
            this.tneRightMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneRightMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneRightMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneRightMargin.Location = new System.Drawing.Point(300, 164);
            this.tneRightMargin.MaxLength = 5;
            this.tneRightMargin.Name = "tneRightMargin";
            this.tneRightMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneRightMargin.Size = new System.Drawing.Size(69, 21);
            this.tneRightMargin.TabIndex = 513;
            this.tneRightMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneRightMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ulTopMark1
            // 
            appearance46.ForeColor = System.Drawing.Color.Red;
            appearance46.TextVAlignAsString = "Middle";
            this.ulTopMark1.Appearance = appearance46;
            this.ulTopMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulTopMark1.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTopMark1.Location = new System.Drawing.Point(128, 104);
            this.ulTopMark1.Name = "ulTopMark1";
            this.ulTopMark1.Size = new System.Drawing.Size(19, 13);
            this.ulTopMark1.TabIndex = 12;
            this.ulTopMark1.Text = "→";
            this.ulTopMark1.Visible = false;
            // 
            // ulLeftMark2
            // 
            appearance47.ForeColor = System.Drawing.Color.Red;
            appearance47.TextVAlignAsString = "Middle";
            this.ulLeftMark2.Appearance = appearance47;
            this.ulLeftMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulLeftMark2.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulLeftMark2.Location = new System.Drawing.Point(156, 284);
            this.ulLeftMark2.Name = "ulLeftMark2";
            this.ulLeftMark2.Size = new System.Drawing.Size(19, 16);
            this.ulLeftMark2.TabIndex = 10;
            this.ulLeftMark2.Text = "↑";
            this.ulLeftMark2.Visible = false;
            // 
            // ulLeftMark1
            // 
            appearance48.ForeColor = System.Drawing.Color.Red;
            appearance48.TextVAlignAsString = "Middle";
            this.ulLeftMark1.Appearance = appearance48;
            this.ulLeftMark1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulLeftMark1.Font = new System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulLeftMark1.Location = new System.Drawing.Point(156, 72);
            this.ulLeftMark1.Name = "ulLeftMark1";
            this.ulLeftMark1.Size = new System.Drawing.Size(19, 13);
            this.ulLeftMark1.TabIndex = 9;
            this.ulLeftMark1.Text = "↓";
            this.ulLeftMark1.Visible = false;
            // 
            // ulTopMark2
            // 
            appearance49.ForeColor = System.Drawing.Color.Red;
            appearance49.TextVAlignAsString = "Middle";
            this.ulTopMark2.Appearance = appearance49;
            this.ulTopMark2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ulTopMark2.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulTopMark2.Location = new System.Drawing.Point(292, 104);
            this.ulTopMark2.Name = "ulTopMark2";
            this.ulTopMark2.Size = new System.Drawing.Size(19, 13);
            this.ulTopMark2.TabIndex = 11;
            this.ulTopMark2.Text = "←";
            this.ulTopMark2.Visible = false;
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.Location = new System.Drawing.Point(140, 108);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(160, 12);
            this.tLine1.TabIndex = 4;
            this.tLine1.Text = "tLine1";
            // 
            // tneTopMargin
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneTopMargin.ActiveAppearance = appearance50;
            this.tneTopMargin.AutoSelect = true;
            dropDownEditorButton3.Tag = "NEditCalculator";
            this.tneTopMargin.ButtonsRight.Add(dropDownEditorButton3);
            this.tneTopMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneTopMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneTopMargin.DataText = "";
            this.tneTopMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneTopMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneTopMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneTopMargin.Location = new System.Drawing.Point(209, 48);
            this.tneTopMargin.MaxLength = 5;
            this.tneTopMargin.Name = "tneTopMargin";
            this.tneTopMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneTopMargin.Size = new System.Drawing.Size(69, 21);
            this.tneTopMargin.TabIndex = 511;
            this.tneTopMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneTopMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // tneLeftMargin
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tneLeftMargin.ActiveAppearance = appearance51;
            this.tneLeftMargin.AutoSelect = true;
            dropDownEditorButton4.Tag = "NEditCalculator";
            this.tneLeftMargin.ButtonsRight.Add(dropDownEditorButton4);
            this.tneLeftMargin.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tneLeftMargin.CalcSize = new System.Drawing.Size(172, 200);
            this.tneLeftMargin.DataText = "";
            this.tneLeftMargin.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tneLeftMargin.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tneLeftMargin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tneLeftMargin.Location = new System.Drawing.Point(80, 164);
            this.tneLeftMargin.MaxLength = 5;
            this.tneLeftMargin.Name = "tneLeftMargin";
            this.tneLeftMargin.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tneLeftMargin.Size = new System.Drawing.Size(69, 21);
            this.tneLeftMargin.TabIndex = 512;
            this.tneLeftMargin.Leave += new System.EventHandler(this.tneTopMargin_Leave);
            this.tneLeftMargin.Enter += new System.EventHandler(this.tneTopMargin_Enter);
            // 
            // ultraLabel11
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance52;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel11.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(169, 48);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(40, 20);
            this.ultraLabel11.TabIndex = 7;
            this.ultraLabel11.Text = "上(&T)";
            // 
            // ultraLabel10
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance53;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.White;
            this.ultraLabel10.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(80, 144);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(56, 20);
            this.ultraLabel10.TabIndex = 6;
            this.ultraLabel10.Text = "左(&L)";
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine2.Location = new System.Drawing.Point(164, 84);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(8, 204);
            this.tLine2.TabIndex = 5;
            this.tLine2.Text = "tLine2";
            // 
            // upbSlipImage
            // 
            this.upbSlipImage.BorderShadowColor = System.Drawing.Color.Empty;
            this.upbSlipImage.Location = new System.Drawing.Point(156, 92);
            this.upbSlipImage.Name = "upbSlipImage";
            this.upbSlipImage.Size = new System.Drawing.Size(132, 184);
            this.upbSlipImage.TabIndex = 13;
            // 
            // utpFont
            // 
            this.utpFont.Controls.Add(this.ultraGroupBox8);
            this.utpFont.Location = new System.Drawing.Point(-10000, -10000);
            this.utpFont.Name = "utpFont";
            this.utpFont.Size = new System.Drawing.Size(474, 383);
            // 
            // ultraGroupBox8
            // 
            this.ultraGroupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance54.BackColor = System.Drawing.Color.White;
            this.ultraGroupBox8.Appearance = appearance54;
            this.ultraGroupBox8.Controls.Add(this.pbCompanyImage);
            this.ultraGroupBox8.Controls.Add(this.tceSlipFontSize);
            this.ultraGroupBox8.Controls.Add(this.ufneSlipFontName);
            this.ultraGroupBox8.Controls.Add(this.tceSlipFontStyle);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox8.Location = new System.Drawing.Point(8, 8);
            this.ultraGroupBox8.Name = "ultraGroupBox8";
            this.ultraGroupBox8.Size = new System.Drawing.Size(458, 368);
            this.ultraGroupBox8.TabIndex = 610;
            this.ultraGroupBox8.Text = "フォント";
            // 
            // pbCompanyImage
            // 
            this.pbCompanyImage.Location = new System.Drawing.Point(276, 96);
            this.pbCompanyImage.Name = "pbCompanyImage";
            this.pbCompanyImage.Size = new System.Drawing.Size(100, 50);
            this.pbCompanyImage.TabIndex = 614;
            this.pbCompanyImage.TabStop = false;
            this.pbCompanyImage.Visible = false;
            // 
            // tceSlipFontSize
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontSize.ActiveAppearance = appearance55;
            this.tceSlipFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tceSlipFontSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontSize.ItemAppearance = appearance56;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "標準";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "大";
            this.tceSlipFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.tceSlipFontSize.Location = new System.Drawing.Point(104, 62);
            this.tceSlipFontSize.Name = "tceSlipFontSize";
            this.tceSlipFontSize.Size = new System.Drawing.Size(60, 21);
            this.tceSlipFontSize.TabIndex = 612;
            this.tceSlipFontSize.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ufneSlipFontName
            // 
            this.ufneSlipFontName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ufneSlipFontName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ufneSlipFontName.ItemAppearance = appearance57;
            this.ufneSlipFontName.Location = new System.Drawing.Point(104, 24);
            this.ufneSlipFontName.Name = "ufneSlipFontName";
            this.ufneSlipFontName.Size = new System.Drawing.Size(188, 21);
            this.ufneSlipFontName.TabIndex = 611;
            this.ufneSlipFontName.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            this.ufneSlipFontName.Leave += new System.EventHandler(this.UltraFontNameEditorLeave);
            this.ufneSlipFontName.Enter += new System.EventHandler(this.UltraFontNameEditorEnter);
            // 
            // tceSlipFontStyle
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontStyle.ActiveAppearance = appearance58;
            this.tceSlipFontStyle.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tceSlipFontStyle.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tceSlipFontStyle.ItemAppearance = appearance59;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "標準";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "太い";
            this.tceSlipFontStyle.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.tceSlipFontStyle.Location = new System.Drawing.Point(104, 100);
            this.tceSlipFontStyle.Name = "tceSlipFontStyle";
            this.tceSlipFontStyle.Size = new System.Drawing.Size(60, 21);
            this.tceSlipFontStyle.TabIndex = 613;
            this.tceSlipFontStyle.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ultraLabel9
            // 
            appearance60.BackColor = System.Drawing.Color.White;
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance60;
            this.ultraLabel9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(16, 99);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel9.TabIndex = 5;
            this.ultraLabel9.Text = "文字の太さ";
            // 
            // ultraLabel8
            // 
            appearance61.BackColor = System.Drawing.Color.White;
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance61;
            this.ultraLabel8.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(16, 61);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel8.TabIndex = 4;
            this.ultraLabel8.Text = "文字のサイズ";
            // 
            // ultraLabel6
            // 
            appearance62.BackColor = System.Drawing.Color.White;
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance62;
            this.ultraLabel6.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(16, 23);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel6.TabIndex = 3;
            this.ultraLabel6.Text = "フォント";
            // 
            // ultraLabel5
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance30;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(8, 154);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(305, 23);
            this.ultraLabel5.TabIndex = 421;
            this.ultraLabel5.Text = "※このタブは非表示に変更しました 2008.2.22";
            // 
            // ugbOutlinePrtCd
            // 
            this.ugbOutlinePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance31.BackColor = System.Drawing.Color.White;
            this.ugbOutlinePrtCd.Appearance = appearance31;
            this.ugbOutlinePrtCd.Controls.Add(this.uosOutlinePrtCd);
            this.ugbOutlinePrtCd.Location = new System.Drawing.Point(8, 8);
            this.ugbOutlinePrtCd.Name = "ugbOutlinePrtCd";
            this.ugbOutlinePrtCd.Size = new System.Drawing.Size(458, 48);
            this.ugbOutlinePrtCd.TabIndex = 410;
            this.ugbOutlinePrtCd.Text = "摘要の印字";
            // 
            // uosOutlinePrtCd
            // 
            appearance32.BackColor = System.Drawing.Color.White;
            this.uosOutlinePrtCd.Appearance = appearance32;
            this.uosOutlinePrtCd.BackColor = System.Drawing.Color.White;
            this.uosOutlinePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosOutlinePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosOutlinePrtCd.CheckedIndex = 0;
            this.uosOutlinePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "印字する";
            valueListItem19.DataValue = 0;
            valueListItem19.DisplayText = "印字しない";
            this.uosOutlinePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem18,
            valueListItem19});
            this.uosOutlinePrtCd.ItemSpacingHorizontal = 6;
            this.uosOutlinePrtCd.ItemSpacingVertical = 2;
            this.uosOutlinePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosOutlinePrtCd.Name = "uosOutlinePrtCd";
            this.uosOutlinePrtCd.Size = new System.Drawing.Size(156, 20);
            this.uosOutlinePrtCd.TabIndex = 411;
            this.uosOutlinePrtCd.Text = "印字する";
            this.uosOutlinePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // ugbBankNamePrtCd
            // 
            this.ugbBankNamePrtCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance34.BackColor = System.Drawing.Color.White;
            this.ugbBankNamePrtCd.Appearance = appearance34;
            this.ugbBankNamePrtCd.Controls.Add(this.uosBankNamePrtCd);
            this.ugbBankNamePrtCd.Location = new System.Drawing.Point(8, 64);
            this.ugbBankNamePrtCd.Name = "ugbBankNamePrtCd";
            this.ugbBankNamePrtCd.Size = new System.Drawing.Size(458, 48);
            this.ugbBankNamePrtCd.TabIndex = 420;
            this.ugbBankNamePrtCd.Text = "銀行名の印字";
            // 
            // uosBankNamePrtCd
            // 
            appearance35.BackColor = System.Drawing.Color.White;
            this.uosBankNamePrtCd.Appearance = appearance35;
            this.uosBankNamePrtCd.BackColor = System.Drawing.Color.White;
            this.uosBankNamePrtCd.BackColorInternal = System.Drawing.Color.White;
            this.uosBankNamePrtCd.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosBankNamePrtCd.CheckedIndex = 0;
            this.uosBankNamePrtCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem20.DataValue = 1;
            valueListItem20.DisplayText = "印字する";
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "印字しない";
            this.uosBankNamePrtCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem20,
            valueListItem21});
            this.uosBankNamePrtCd.ItemSpacingHorizontal = 6;
            this.uosBankNamePrtCd.ItemSpacingVertical = 2;
            this.uosBankNamePrtCd.Location = new System.Drawing.Point(32, 20);
            this.uosBankNamePrtCd.Name = "uosBankNamePrtCd";
            this.uosBankNamePrtCd.Size = new System.Drawing.Size(156, 20);
            this.uosBankNamePrtCd.TabIndex = 421;
            this.uosBankNamePrtCd.Text = "印字する";
            this.uosBankNamePrtCd.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // utcDetail
            // 
            appearance63.BackColor = System.Drawing.Color.White;
            appearance63.BackColor2 = System.Drawing.Color.LightPink;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utcDetail.ActiveTabAppearance = appearance63;
            appearance64.BackColor = System.Drawing.Color.White;
            appearance64.BackColor2 = System.Drawing.Color.Lavender;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utcDetail.Appearance = appearance64;
            this.utcDetail.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance65.BackColor = System.Drawing.Color.White;
            this.utcDetail.ClientAreaAppearance = appearance65;
            this.utcDetail.Controls.Add(this.ultraTabSharedControlsPage1);
            this.utcDetail.Controls.Add(this.utpDetail2);
            this.utcDetail.Controls.Add(this.utpFont);
            this.utcDetail.Controls.Add(this.utpMargin);
            this.utcDetail.Controls.Add(this.utpDetail);
            this.utcDetail.Controls.Add(this.utpHeader);
            this.utcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utcDetail.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.utcDetail.Location = new System.Drawing.Point(0, 281);
            this.utcDetail.Name = "utcDetail";
            this.utcDetail.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.utcDetail.Size = new System.Drawing.Size(476, 406);
            this.utcDetail.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.utcDetail.TabIndex = 2000;
            this.utcDetail.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.utcDetail.TabPadding = new System.Drawing.Size(5, 2);
            ultraTab1.TabPage = this.utpHeader;
            ultraTab1.Text = "ヘッダー";
            ultraTab2.TabPage = this.utpDetail;
            ultraTab2.Text = "明細";
            ultraTab3.TabPage = this.utpDetail2;
            ultraTab3.Text = "明細(列）";
            ultraTab5.TabPage = this.utpMargin;
            ultraTab5.Text = "余白";
            ultraTab6.TabPage = this.utpFont;
            ultraTab6.Text = "フォント";
            this.utcDetail.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab5,
            ultraTab6});
            this.utcDetail.Tag = "";
            this.utcDetail.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.utcDetail.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(474, 383);
            // 
            // utmMain
            // 
            this.utmMain.DesignerFlags = 1;
            this.utmMain.DockWithinContainer = this;
            this.utmMain.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.utmMain.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.utmMain.ShowFullMenusDelay = 500;
            this.utmMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "伝票印刷";
            this.utmMain.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool4.SharedProps.Caption = "戻る(&C)";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.Caption = "印刷(&P)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Caption = "PDF出力(&F)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.utmMain.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6});
            this.utmMain.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utmMain_ToolClick);
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.pnlPrevew);
            this.Form1_Fill_Panel.Controls.Add(this.splitter1);
            this.Form1_Fill_Panel.Controls.Add(this.pnlLeft);
            this.Form1_Fill_Panel.Controls.Add(this.ultraStatusBar1);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(982, 710);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // pnlPrevew
            // 
            this.pnlPrevew.BackColor = System.Drawing.Color.Lavender;
            this.pnlPrevew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrevew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrevew.Location = new System.Drawing.Point(481, 0);
            this.pnlPrevew.Name = "pnlPrevew";
            this.pnlPrevew.Size = new System.Drawing.Size(501, 687);
            this.pnlPrevew.TabIndex = 8;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(476, 0);
            this.splitter1.MinSize = 476;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 687);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Controls.Add(this.utcDetail);
            this.pnlLeft.Controls.Add(this.splitter2);
            this.pnlLeft.Controls.Add(this.pnlMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(476, 687);
            this.pnlLeft.TabIndex = 1000;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 276);
            this.splitter2.MinExtra = 20;
            this.splitter2.MinSize = 230;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(476, 5);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.ugbPrintCopy);
            this.pnlMain.Controls.Add(this.ugbPrintRange);
            this.pnlMain.Controls.Add(this.ugbPrinter);
            this.pnlMain.Controls.Add(this.ugbFormat);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(476, 276);
            this.pnlMain.TabIndex = 1001;
            // 
            // ugbPrintCopy
            // 
            this.ugbPrintCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbPrintCopy.Controls.Add(this.tnPrintCopy);
            this.ugbPrintCopy.Controls.Add(this.ulPrintCopy);
            this.ugbPrintCopy.Location = new System.Drawing.Point(339, 164);
            this.ugbPrintCopy.Name = "ugbPrintCopy";
            this.ugbPrintCopy.Size = new System.Drawing.Size(125, 56);
            this.ugbPrintCopy.TabIndex = 4;
            this.ugbPrintCopy.Text = "部数";
            // 
            // tnPrintCopy
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintCopy.ActiveAppearance = appearance66;
            this.tnPrintCopy.AutoSelect = true;
            dropDownEditorButton5.Tag = "NEditCalculator";
            this.tnPrintCopy.ButtonsRight.Add(dropDownEditorButton5);
            this.tnPrintCopy.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintCopy.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintCopy.DataText = "";
            this.tnPrintCopy.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintCopy.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintCopy.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintCopy.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintCopy.Location = new System.Drawing.Point(60, 28);
            this.tnPrintCopy.MaxLength = 3;
            this.tnPrintCopy.Name = "tnPrintCopy";
            this.tnPrintCopy.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintCopy.Size = new System.Drawing.Size(48, 21);
            this.tnPrintCopy.TabIndex = 8;
            // 
            // ulPrintCopy
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ulPrintCopy.Appearance = appearance67;
            this.ulPrintCopy.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintCopy.Location = new System.Drawing.Point(16, 32);
            this.ulPrintCopy.Name = "ulPrintCopy";
            this.ulPrintCopy.Size = new System.Drawing.Size(32, 16);
            this.ulPrintCopy.TabIndex = 2;
            this.ulPrintCopy.Text = "部数";
            // 
            // ugbPrintRange
            // 
            this.ugbPrintRange.Controls.Add(this.tnPrintRangeTo);
            this.ugbPrintRange.Controls.Add(this.ulPrintRangeTo);
            this.ugbPrintRange.Controls.Add(this.tnPrintRangeFrom);
            this.ugbPrintRange.Controls.Add(this.uosPrintRange);
            this.ugbPrintRange.Controls.Add(this.ulPrintRangeFrom);
            this.ugbPrintRange.Location = new System.Drawing.Point(8, 164);
            this.ugbPrintRange.Name = "ugbPrintRange";
            this.ugbPrintRange.Size = new System.Drawing.Size(324, 56);
            this.ugbPrintRange.TabIndex = 3;
            this.ugbPrintRange.Text = "印刷範囲";
            // 
            // tnPrintRangeTo
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintRangeTo.ActiveAppearance = appearance68;
            this.tnPrintRangeTo.AutoSelect = true;
            dropDownEditorButton6.Tag = "NEditCalculator";
            this.tnPrintRangeTo.ButtonsRight.Add(dropDownEditorButton6);
            this.tnPrintRangeTo.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintRangeTo.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintRangeTo.DataText = "";
            this.tnPrintRangeTo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintRangeTo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintRangeTo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintRangeTo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintRangeTo.Location = new System.Drawing.Point(260, 28);
            this.tnPrintRangeTo.MaxLength = 3;
            this.tnPrintRangeTo.Name = "tnPrintRangeTo";
            this.tnPrintRangeTo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintRangeTo.Size = new System.Drawing.Size(48, 21);
            this.tnPrintRangeTo.TabIndex = 7;
            this.tnPrintRangeTo.ValueChanged += new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            // 
            // ulPrintRangeTo
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.ulPrintRangeTo.Appearance = appearance69;
            this.ulPrintRangeTo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintRangeTo.Location = new System.Drawing.Point(224, 32);
            this.ulPrintRangeTo.Name = "ulPrintRangeTo";
            this.ulPrintRangeTo.Size = new System.Drawing.Size(32, 16);
            this.ulPrintRangeTo.TabIndex = 5;
            this.ulPrintRangeTo.Text = "終了";
            // 
            // tnPrintRangeFrom
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tnPrintRangeFrom.ActiveAppearance = appearance70;
            this.tnPrintRangeFrom.AutoSelect = true;
            dropDownEditorButton7.Tag = "NEditCalculator";
            this.tnPrintRangeFrom.ButtonsRight.Add(dropDownEditorButton7);
            this.tnPrintRangeFrom.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcRight;
            this.tnPrintRangeFrom.CalcSize = new System.Drawing.Size(172, 200);
            this.tnPrintRangeFrom.DataText = "";
            this.tnPrintRangeFrom.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tnPrintRangeFrom.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tnPrintRangeFrom.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnPrintRangeFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tnPrintRangeFrom.Location = new System.Drawing.Point(160, 28);
            this.tnPrintRangeFrom.MaxLength = 3;
            this.tnPrintRangeFrom.Name = "tnPrintRangeFrom";
            this.tnPrintRangeFrom.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tnPrintRangeFrom.Size = new System.Drawing.Size(48, 21);
            this.tnPrintRangeFrom.TabIndex = 6;
            this.tnPrintRangeFrom.ValueChanged += new System.EventHandler(this.tnPrintRangeFrom_ValueChanged);
            // 
            // uosPrintRange
            // 
            this.uosPrintRange.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.uosPrintRange.CheckedIndex = 0;
            this.uosPrintRange.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance71.FontData.SizeInPoints = 9F;
            this.uosPrintRange.ItemAppearance = appearance71;
            this.uosPrintRange.ItemOrigin = new System.Drawing.Point(2, 2);
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "すべて ";
            valueListItem11.DataValue = 2;
            valueListItem11.DisplayText = "ページ指定";
            this.uosPrintRange.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.uosPrintRange.ItemSpacingHorizontal = 2;
            this.uosPrintRange.ItemSpacingVertical = 4;
            this.uosPrintRange.Location = new System.Drawing.Point(12, 13);
            this.uosPrintRange.Name = "uosPrintRange";
            this.uosPrintRange.Size = new System.Drawing.Size(108, 40);
            this.uosPrintRange.TabIndex = 5;
            this.uosPrintRange.Text = "すべて ";
            this.uosPrintRange.ValueChanged += new System.EventHandler(this.uosPrintRange_ValueChanged);
            // 
            // ulPrintRangeFrom
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ulPrintRangeFrom.Appearance = appearance72;
            this.ulPrintRangeFrom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintRangeFrom.Location = new System.Drawing.Point(128, 32);
            this.ulPrintRangeFrom.Name = "ulPrintRangeFrom";
            this.ulPrintRangeFrom.Size = new System.Drawing.Size(32, 16);
            this.ulPrintRangeFrom.TabIndex = 2;
            this.ulPrintRangeFrom.Text = "開始";
            // 
            // ugbPrinter
            // 
            this.ugbPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbPrinter.Controls.Add(this.tcePrinterName);
            this.ugbPrinter.Controls.Add(this.ulPrinterName);
            this.ugbPrinter.Location = new System.Drawing.Point(8, 108);
            this.ugbPrinter.Name = "ugbPrinter";
            this.ugbPrinter.Size = new System.Drawing.Size(456, 52);
            this.ugbPrinter.TabIndex = 2;
            this.ugbPrinter.Text = "プリンタ";
            // 
            // tcePrinterName
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrinterName.ActiveAppearance = appearance73;
            this.tcePrinterName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tcePrinterName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tcePrinterName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrinterName.ItemAppearance = appearance74;
            this.tcePrinterName.Location = new System.Drawing.Point(92, 16);
            this.tcePrinterName.Name = "tcePrinterName";
            this.tcePrinterName.Size = new System.Drawing.Size(268, 24);
            this.tcePrinterName.TabIndex = 4;
            // 
            // ulPrinterName
            // 
            appearance75.TextVAlignAsString = "Middle";
            this.ulPrinterName.Appearance = appearance75;
            this.ulPrinterName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrinterName.Location = new System.Drawing.Point(20, 16);
            this.ulPrinterName.Name = "ulPrinterName";
            this.ulPrinterName.Size = new System.Drawing.Size(72, 23);
            this.ulPrinterName.TabIndex = 2;
            this.ulPrinterName.Text = "プリンタ名";
            // 
            // ugbFormat
            // 
            this.ugbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbFormat.Controls.Add(this.ubDetail);
            this.ugbFormat.Controls.Add(this.ucePrevew);
            this.ugbFormat.Controls.Add(this.ulPrintMsg);
            this.ugbFormat.Controls.Add(this.tcePrintType);
            this.ugbFormat.Controls.Add(this.ultraLabel22);
            this.ugbFormat.Location = new System.Drawing.Point(8, 12);
            this.ugbFormat.Name = "ugbFormat";
            this.ugbFormat.Size = new System.Drawing.Size(456, 96);
            this.ugbFormat.TabIndex = 1;
            this.ugbFormat.Text = "帳票";
            // 
            // ubDetail
            // 
            this.ubDetail.Location = new System.Drawing.Point(364, 16);
            this.ubDetail.Name = "ubDetail";
            this.ubDetail.Size = new System.Drawing.Size(84, 24);
            this.ubDetail.TabIndex = 2;
            this.ubDetail.Text = "詳細設定";
            this.ubDetail.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubDetail.Click += new System.EventHandler(this.ubDetail_Click);
            // 
            // ucePrevew
            // 
            this.ucePrevew.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ucePrevew.Location = new System.Drawing.Point(96, 68);
            this.ucePrevew.Name = "ucePrevew";
            this.ucePrevew.Size = new System.Drawing.Size(120, 20);
            this.ucePrevew.TabIndex = 3;
            this.ucePrevew.Text = "印刷プレビュー";
            // 
            // ulPrintMsg
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ulPrintMsg.Appearance = appearance76;
            this.ulPrintMsg.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ulPrintMsg.Location = new System.Drawing.Point(96, 40);
            this.ulPrintMsg.Name = "ulPrintMsg";
            this.ulPrintMsg.Size = new System.Drawing.Size(352, 23);
            this.ulPrintMsg.TabIndex = 3;
            this.ulPrintMsg.Text = "Ａ４用紙を設定してください";
            // 
            // tcePrintType
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrintType.ActiveAppearance = appearance77;
            this.tcePrintType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tcePrintType.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tcePrintType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tcePrintType.ItemAppearance = appearance78;
            this.tcePrintType.Location = new System.Drawing.Point(92, 16);
            this.tcePrintType.Name = "tcePrintType";
            this.tcePrintType.Size = new System.Drawing.Size(268, 24);
            this.tcePrintType.TabIndex = 1;
            this.tcePrintType.ValueChanged += new System.EventHandler(this.tcePrintType_ValueChanged);
            // 
            // ultraLabel22
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance79;
            this.ultraLabel22.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(20, 16);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel22.TabIndex = 2;
            this.ultraLabel22.Text = "伝票タイプ";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.ubCancel);
            this.pnlBottom.Controls.Add(this.ubPrint);
            this.pnlBottom.Controls.Add(this.ubPdf);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 238);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(474, 36);
            this.pnlBottom.TabIndex = 1002;
            // 
            // ubCancel
            // 
            this.ubCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubCancel.Location = new System.Drawing.Point(144, 8);
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size(100, 24);
            this.ubCancel.TabIndex = 9;
            this.ubCancel.Text = "戻る(&C)";
            this.ubCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubCancel.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ubPrint
            // 
            this.ubPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubPrint.Location = new System.Drawing.Point(248, 8);
            this.ubPrint.Name = "ubPrint";
            this.ubPrint.Size = new System.Drawing.Size(100, 24);
            this.ubPrint.TabIndex = 10;
            this.ubPrint.Text = "印刷(&P)";
            this.ubPrint.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubPrint.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ubPdf
            // 
            this.ubPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubPdf.Location = new System.Drawing.Point(352, 8);
            this.ubPdf.Name = "ubPdf";
            this.ubPdf.Size = new System.Drawing.Size(116, 24);
            this.ubPdf.TabIndex = 11;
            this.ubPdf.Text = "ＰＤＦ出力(&V)";
            this.ubPdf.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ubPdf.Click += new System.EventHandler(this.ubPrint_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 687);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(982, 23);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Left
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Left";
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 710);
            this._SFMIT01407UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(982, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Right";
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 710);
            this._SFMIT01407UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Top
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Top";
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(982, 28);
            this._SFMIT01407UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.utmMain;
            // 
            // _SFMIT01407UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 738);
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Name = "_SFMIT01407UA_Toolbars_Dock_Area_Bottom";
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(982, 0);
            this._SFMIT01407UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.utmMain;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "すべてのファイル|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "PDFの格納先";
            // 
            // ilSlipPrintImage
            // 
            this.ilSlipPrintImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSlipPrintImage.ImageStream")));
            this.ilSlipPrintImage.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSlipPrintImage.Images.SetKeyName(0, "");
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // imgListIntensive
            // 
            this.imgListIntensive.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIntensive.ImageStream")));
            this.imgListIntensive.TransparentColor = System.Drawing.Color.White;
            this.imgListIntensive.Images.SetKeyName(0, "");
            this.imgListIntensive.Images.SetKeyName(1, "");
            this.imgListIntensive.Images.SetKeyName(2, "");
            this.imgListIntensive.Images.SetKeyName(3, "");
            this.imgListIntensive.Images.SetKeyName(4, "");
            // 
            // uttmToolTip
            // 
            this.uttmToolTip.ContainingControl = this;
            this.uttmToolTip.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // DCCMN02000UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(982, 738);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFMIT01407UA_Toolbars_Dock_Area_Bottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DCCMN02000UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票印刷確認";
            this.Load += new System.EventHandler(this.DCCMN02000UB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DCCMN02000UA_KeyDown);
            this.utpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbSlipDatePrintDiv)).EndInit();
            this.ugbSlipDatePrintDiv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosSlipDatePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCopyCount)).EndInit();
            this.ugbCopyCount.ResumeLayout(false);
            this.ugbCopyCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnCopyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbTitle)).EndInit();
            this.ugbTitle.ResumeLayout(false);
            this.ugbTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceTitle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEnterpriseNamePrtCd)).EndInit();
            this.ugbEnterpriseNamePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosEnterpriseNamePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbCustTelNoPrtDivCd)).EndInit();
            this.ugbCustTelNoPrtDivCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosCustTelNoPrtDivCd)).EndInit();
            this.utpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbTotalPricePrtCd)).EndInit();
            this.ugbTotalPricePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosTotalPricePrtCd)).EndInit();
            this.utpDetail2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeColMove)).EndInit();
            this.ugbEachSlipTypeColMove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugEachSlipTypeColMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSourceColMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbEachSlipTypeCol)).EndInit();
            this.ugbEachSlipTypeCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utEachSlipTypeCol)).EndInit();
            this.utpMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbMargin)).EndInit();
            this.ugbMargin.ResumeLayout(false);
            this.ugbMargin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tneLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            this.utpFont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).EndInit();
            this.ultraGroupBox8.ResumeLayout(false);
            this.ultraGroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufneSlipFontName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tceSlipFontStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbOutlinePrtCd)).EndInit();
            this.ugbOutlinePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosOutlinePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbBankNamePrtCd)).EndInit();
            this.ugbBankNamePrtCd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uosBankNamePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utcDetail)).EndInit();
            this.utcDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utmMain)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintCopy)).EndInit();
            this.ugbPrintCopy.ResumeLayout(false);
            this.ugbPrintCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrintRange)).EndInit();
            this.ugbPrintRange.ResumeLayout(false);
            this.ugbPrintRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnPrintRangeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uosPrintRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbPrinter)).EndInit();
            this.ugbPrinter.ResumeLayout(false);
            this.ugbPrinter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbFormat)).EndInit();
            this.ugbFormat.ResumeLayout(false);
            this.ugbFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcePrintType)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        //==================================================================================
        // コンストラクタ
        //==================================================================================
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DCCMN02000UB(SlipPrintAcs slipPrintAcs)
        {
            // コンポーネント初期化
            InitializeComponent();

            // 伝票印刷アクセスクラス受取
            _slipPrintAcs = slipPrintAcs;
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            _scmRtPrtDtAcs = new ScmRtPrtDtAcs();
            _pccCmpnyStAcs = new PccCmpnyStAcs();
            _pccTtlStAcs = new PccTtlStAcs();
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

            // ダイアログなし印刷＝しない
            _printWithoutDialog = false;

            // 企業情報を取得
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                // 企業コードを設定する
                _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            // 伝票印刷パラメータ(データクラス外情報)
            _slipPrintParameter = new SlipPrintParameter();

            // ステータス
            _slipPrintDialogState = SlipPrintDialogStatus.Normal;

            // 初期状態を簡易版ＵＩに設定
            this.Width = 540;
            this.Height = 300;
            this.MaximizeBox = false;
            this.CancelButton = this.ubCancel;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;

            // データキャッシュ生成
            _dataCache = SlipDialogDataCache.GetInstance();
        }
        # endregion ■ コンストラクタ ■

        //==================================================================================
        // プロパティ
        //==================================================================================
        # region ■ プロパティ ■
        /// <summary>
        /// 伝票印刷ダイアログステータス
        /// </summary>
        public SlipPrintDialogStatus SlipPrintDialogState
        {
            get { return _slipPrintDialogState; }
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// サービス起動プロパティ
        /// </summary>
        public int IsService
        {
            get { return this._isService; }
            set { this._isService = value; }
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// リモート伝票発行プロパティ
        /// </summary>
        public bool IsRmSlpPrt
        {
            get { return this._IsRmSlpPrt; }
            set { this._IsRmSlpPrt = value; }
        }
        /// <summary>
        /// PCCUOE自動回答起動フラグプロパティ(0:通常 1:PCCUOE自動回答起動)
        /// </summary>
        public int IsAutoAns
        {
            get { return this._isAutoAns; }
            set { this._isAutoAns = value; }
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>
        /// 売上伝票数量は１件フラグ（false:１件以上、true:１件）
        /// </summary>
        public bool IsOnlyOneSlip
        {
            set { this._isOnlyOneSlip = value; }
        }

        /// <summary>
        /// 最後送信の売上伝票フラグ（false:最後ではない、true:最後）
        /// </summary>
        public bool IsLastSlip
        {
            set { this._isLastSlip = value; }
        }
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>
        /// リモート伝票最新識別区分KEY変更フラグ（false:変更しない、true:変更する）
        /// </summary>
        public bool IsKeyChangeFlag
        {
            set { this._isKeyChangeFlag = value; }
        }
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
        /// <summary>
        /// 売上伝票リストプロパティ
        /// </summary>
        public List<string> SlipNumlist
        {
            get { return _slipNumlist; }
            set { _slipNumlist = value; }
        }
        /// <summary>
        /// 問合せ番号リストプロパティ
        /// </summary>
        public List<string> InquiryNumList
        {
            get { return _inquiryNumList; }
            set { _inquiryNumList = value; }
        }
        /// <summary>
        /// タブレット起動区分(True:タブレットより起動 False:タブレット以外より起動)
        /// </summary>
        public bool IsTablet
        {
            get { return _isTablet; }
            set { _isTablet = value; }
        }
        // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private List<List<object>> _printDataList;
        /// <summary>
        /// 複数伝票分のデータリスト
        /// </summary>
        public List<List<object>> PrintDataList
        {
            get { return _printDataList; }
            set { _printDataList = value; }
        }
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        //==================================================================================
        // イベント処理
        //==================================================================================
        # region ■ イベント処理 ■

        # region ■　フォームロードイベント処理　■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCCMN02000UB_Load(object sender, EventArgs e)
        {
            //******************************************************
            // 注意：　以下では、画面なし印刷のとき不要で、
            //        画面ありの時のみ必要な処理を記述します。
            //        (画面なし時の処理を極力高速化する為)
            //******************************************************

            //------------------------------------------------------
            // インスタンス生成
            //------------------------------------------------------
            # region [インスタンス生成]
            // 印刷プレビューフォーム
            _slipPrintAssemblyFrom = new SFMIT01290UA();
            # endregion

            //------------------------------------------------------
            // 画面を簡易版にする
            //------------------------------------------------------
            # region [画面を簡易版にする]
            // 詳細ボタン表示にする
            ubDetail.Visible = true;
            // プレビューボタンを表示にする
            ucePrevew.Visible = true;

            // 簡易版のボタンを表示にする
            pnlBottom.Visible = true;

            // タブコントロールを非表示
            this.pnlLeft.Visible = false;
            // ビューワーを非表示
            this.pnlPrevew.Visible = false;
            // ツールバー表示
            this.utmMain.Visible = false;
            // スプリッターを非表示
            this.splitter1.Visible = false;
            // ステータスバーを非表示
            this.ultraStatusBar1.Visible = false;

            // メインパネルのParentとDockをかえる
            this.pnlMain.Parent = Form1_Fill_Panel;
            this.pnlMain.Dock = DockStyle.Fill;

            //this.Width = 540;
            //this.Height = 300;
            //this.MaximizeBox = false;
            //this.CancelButton = this.ubCancel;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.WindowState = FormWindowState.Normal;
            # endregion

            //------------------------------------------------------
            // 画面を初期化
            //------------------------------------------------------
            # region [画面を初期化]
            // 余白ラベルを非表示
            this.ulTopMark1.Visible = false;
            this.ulTopMark2.Visible = false;
            this.ulLeftMark1.Visible = false;
            this.ulLeftMark2.Visible = false;
            # endregion

            //------------------------------------------------------
            // 詳細タブの表示制御
            //------------------------------------------------------
            # region [詳細タブの表示制御]
            // 伝票の場合
            // ①明細タブを表示
            // ②印刷イメージ(bmp)を伝票画像にする
            utpDetail.Tab.Visible = true;
            utpDetail2.Tab.Visible = true;
            //utpFooter.Tab.Visible = false;  // ←フッタタブは未使用の為表示しない。
            upbSlipImage.Image = ilSlipPrintImage.Images[0];
            # endregion

            //-------------------------------------------
            // 各種アイコンを設定する
            //-------------------------------------------
            # region [アイコン]
            // ボトムボタン
            ubCancel.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.BEFORE];
            ubPrint.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINT];
            ubPdf.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
            // 詳細ボタン
            ubDetail.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS];
            // ツールバー・イメージリストを設定する
            utmMain.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            // 戻るへのアイコン設定
            ButtonTool CancelButton = (ButtonTool)utmMain.Tools["Cancel"];
            if (CancelButton != null)
            {
                CancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            }
            // 印刷へのアイコン設定
            ButtonTool PrintButton = (ButtonTool)utmMain.Tools["Print"];
            if (PrintButton != null)
            {
                PrintButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            }
            // PDF印刷へのアイコン設定
            ButtonTool PdfButton = (ButtonTool)utmMain.Tools["Pdf"];
            if (PdfButton != null)
            {
                PdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.VIEW;
            }

            // ヘッダー
            this.utcDetail.Tabs[0].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.HEADER];
            // 明細
            this.utcDetail.Tabs[1].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.ROW];
            // 明細（列）
            this.utcDetail.Tabs[2].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.COL];
            //// フッター
            //this.utcDetail.Tabs[3].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.FOOTER];
            // マージン
            this.utcDetail.Tabs[3].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MARGIN];
            // フォント
            this.utcDetail.Tabs[4].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.FONT];

            // カラーガイド
            this.ubSlipColorT1.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT2.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT3.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ubSlipColorT4.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            # endregion

            //-------------------------------------------
            // フォント一覧調整
            //-------------------------------------------
            # region [フォント一覧調整]
            // Regular及びBoldをサポートしていないフォントは削除する
            for (int ix = 0; ix != this.ufneSlipFontName.Items.Count; ix++)
            {
                FontFamily fontFamily = new FontFamily(this.ufneSlipFontName.Items[ix].ToString());
                if ((!fontFamily.IsStyleAvailable(FontStyle.Regular) ||
                    (!fontFamily.IsStyleAvailable(FontStyle.Bold))))
                {
                    this.ufneSlipFontName.Items.RemoveAt(ix);
                }
            }
            # endregion
        }
        # endregion

        # region ■ 詳細ボタン ■
        /// <summary>
        /// 詳細ボタンの押下イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細ボタンの押下イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubDetail_Click(object sender, System.EventArgs e)
        {
            _FormType = 1; // 詳細版

            // 印刷DLLに印刷条件とデータを設定する
            CallSetPrintConditionInfoAndDataMethod();
            // 拡大率を設定する
            this._prtParam.ExpansionRate = 50;

            // スプリッターを表示
            this.splitter1.Visible = true;
            // ビューワーを表示
            this.pnlPrevew.Visible = true;
            // タブコントロールを表示
            this.pnlLeft.Visible = true;
            // ツールバー表示
            this.utmMain.Visible = true;
            // スプリッターを表示
            this.splitter1.Visible = true;
            // ステータスバーを表示
            this.ultraStatusBar1.Visible = true;

            this.pnlMain.Parent = this.pnlLeft;
            this.pnlMain.Dock = DockStyle.Top;

            this.Width = 1024;
            this.Height = 730;

            this.MaximizeBox = true;
            this.CancelButton = null;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // 簡易版のボタンを非表示にする
            pnlBottom.Visible = false;
            // メインパネルをHeightを縮める
            this.pnlMain.Height = 240;
            // ヘッダーのTabページをアクティブにする
            this.utcDetail.SelectedTab = this.utpHeader.Tab;

            // 親画面の真ん中に再表示
            this.CenterToParent();

            // プレビュー画面をバインドする
            if (_slipPrintAssemblyFrom != null)
            {
                // フォームの起動
                _slipPrintAssemblyFrom.TopLevel = false;
                _slipPrintAssemblyFrom.FormBorderStyle = FormBorderStyle.None;
                // パネルにコントロールを追加する
                this.pnlPrevew.Controls.Add(_slipPrintAssemblyFrom);
                _slipPrintAssemblyFrom.Dock = System.Windows.Forms.DockStyle.Fill;
                _slipPrintAssemblyFrom.BringToFront();
                _slipPrintAssemblyFrom.Show();
            }

            // プレビュー表示
            CallPrevewMethod();

            // 帳票タイプにフォーカスを移す
            this.tcePrintType.Focus();
            // 詳細ボタン非表示にする
            ubDetail.Visible = false;
            // プレビューボタンを非表示にする
            ucePrevew.Visible = false;

            // 自由帳票対応表示
            FormSettingForFreP(IsFrePSlip(_slipPrtSet));
        }
        # endregion ■ 詳細ボタン ■

        # region ■ 各種設定　変更イベント ■
        /// <summary>
        /// 伝票印刷設定項目の変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票印刷設定項目の変更イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ItemValueChanged(object sender, System.EventArgs e)
        {
            // 画面描画中は、exit
            if ((string)utcDetail.Tag == ctFormDrawingNow)
            {
                return;
            }
            // 簡易画面中は、処理しない
            if (_FormType == 0)
            {
                return;
            }
            // 印刷モジュールは、ロードされているか？
            if (_slipPrintAssemblyFrom != null)
            {
                // 条件＆データ設定メソッドコール
                CallSetPrintConditionInfoAndDataMethod();
                // 拡大率を設定する
                this._prtParam.ExpansionRate = 0;

                // プレビューメソッドコール
                CallPrevewMethod();
            }

            if (sender is Control)
            {
                ((Control)sender).Focus();
            }
        }
        /// <summary>
        /// 複写枚数の変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細ボタンの押下イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tnCopyCount_TextChanged(object sender, System.EventArgs e)
        {
            // 複写枚数を取得する
            int CopyCount = (int)tnCopyCount.Value;

            // タイトル１
            tceTitle1.Visible = true;
            // タイトル２
            if (CopyCount >= 2)
            {
                ulTitle2.Visible = true;
                tceTitle2.Visible = true;
                ulSlipColorT2.Visible = true;
                ubSlipColorT2.Visible = true;
            }
            else
            {
                ulTitle2.Visible = false;
                tceTitle2.Visible = false;
                ulSlipColorT2.Visible = false;
                ubSlipColorT2.Visible = false;
            }
            // タイトル３
            if (CopyCount >= 3)
            {
                ulTitle3.Visible = true;
                tceTitle3.Visible = true;
                ulSlipColorT3.Visible = true;
                ubSlipColorT3.Visible = true;
            }
            else
            {
                ulTitle3.Visible = false;
                tceTitle3.Visible = false;
                ulSlipColorT3.Visible = false;
                ubSlipColorT3.Visible = false;
            }
            // タイトル４
            if (CopyCount >= 4)
            {
                ulTitle4.Visible = true;
                tceTitle4.Visible = true;
                ulSlipColorT4.Visible = true;
                ubSlipColorT4.Visible = true;
            }
            else
            {
                ulTitle4.Visible = false;
                tceTitle4.Visible = false;
                ulSlipColorT4.Visible = false;
                ubSlipColorT4.Visible = false;
            }

            // ※変更イベントを起動する
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// ページ範囲値変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : ページ範囲値変更イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void uosPrintRange_ValueChanged(object sender, System.EventArgs e)
        {
            object ObjValue = uosPrintRange.Value;
            if (ObjValue != null)
            {
                int intValue = (int)ObjValue;
                if (intValue == 1)
                {
                    // 全て
                }
                else
                {
                    // ページ指定
                    // ページ開始にフォーカス移動
                    tnPrintRangeFrom.Focus();
                }
            }
        }

        /// <summary>
        /// 開始ページ変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細ボタンの押下イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tnPrintRangeFrom_ValueChanged(object sender, System.EventArgs e)
        {
            // 開始or終了に値が入っている場合
            if ((tnPrintRangeFrom.GetInt() > 0) || (tnPrintRangeTo.GetInt() > 0))
            {
                // ページ制定にチェックを付ける
                uosPrintRange.Value = 2;
            }
        }

        /// <summary>
        /// ノードのチェックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : ノードのチェックイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void utEachSlipTypeCol_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (e.TreeNode.CheckedState == CheckState.Unchecked)
            {
                // ノードのチェックが外れている場合、列を非表示にする
                this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[e.TreeNode.Key].Hidden = true;
            }
            else
            {
                // ノードのチェックが入っている場合、列を表示にする
                this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[e.TreeNode.Key].Hidden = false;
            }
            // ※変更イベントを起動する
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// 列移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列移動イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ugEachSlipTypeColMove_AfterColPosChanged(object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e)
        {
            // ※変更イベントを起動する
            System.EventArgs EvtArg = new EventArgs();
            ItemValueChanged(sender, EvtArg);
        }

        /// <summary>
        /// 現在選択中の伝票タイプの印刷設定を取得
        /// </summary>
        /// <returns></returns>
        private SlipPrtSetWork GetSlipPrtSetSelected()
        {
            // 画面のcomboBoxのvalueをキーにして取得
            return _slipPrintAcs.GetSlipPrtSetWork((int)tcePrintType.Value);
        }

        /// <summary>
        /// 伝票タイプ変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票タイプ変更イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tcePrintType_ValueChanged(object sender, System.EventArgs e)
        {
            // 伝票タイプ取得
            if (tcePrintType.Value != null)
            {
                // 伝票印刷設定コレクションから選択した伝票印刷設定を取得する
                _slipPrtSet = GetSlipPrtSetSelected();

                if (_slipPrtSet != null)
                {
                    // プレビューフォームを生成する
                    _slipPrintAssemblyFrom = null;
                    _slipPrintAssemblyFrom = new SFMIT01290UA();

                    // 印刷部品を生成する
                    _prtObj = null;

                    try
                    {
                        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                        //_prtObj = LoadAssemblyFrom(_slipPrtSet.OutputPgId, _slipPrtSet.OutputPgClassId);
                        _prtObj = LoadAssemblyFrom(_slipPrtSet.OutputPgId, _slipPrtSet.OutputPgClassId, _slipPrtSet.OutputFormFileName);
                        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

                    }
                    catch
                    {
                    }

                    // 印刷部品生成に失敗→終了
                    if (_prtObj == null)
                    {
                        TMsgDisp.Show(this
                            , emErrorLevel.ERR_LEVEL_STOPDISP
                            , null
                            , "伝票印刷確認画面"
                            , null
                            , TMsgDisp.OPE_PRINT
                            , "印刷部品の生成に失敗しました（" + _slipPrtSet.OutputPgId + "）"
                            , 0
                            , null
                            , null
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
                        return;
                    }


                    // 伝票印刷プレビュー部品の設定
                    if (_slipPrintAssemblyFrom != null)
                    {
                        // プレビュー画面名設定
                        _slipPrintAssemblyFrom.Text = "印刷プレビュー";
                    }

                    // データを表示する
                    //SlipPrtSetToDisplay(_slipPrtSet, _slipIniSet);
                    SlipPrtSetToDisplay(_slipPrtSet);

                    // 画面が詳細版の場合
                    if (_FormType != 0)
                    {
                        // プレビュー表示中
                        // プレビュー画面をバインドする
                        if (_slipPrintAssemblyFrom != null)
                        {
                            this.pnlPrevew.Controls.Clear();
                            // フォームの起動
                            _slipPrintAssemblyFrom.TopLevel = false;
                            _slipPrintAssemblyFrom.FormBorderStyle = FormBorderStyle.None;
                            // パネルにコントロールを追加する
                            this.pnlPrevew.Controls.Add(_slipPrintAssemblyFrom);
                            _slipPrintAssemblyFrom.Dock = System.Windows.Forms.DockStyle.Fill;
                            _slipPrintAssemblyFrom.BringToFront();
                            _slipPrintAssemblyFrom.Show();
                        }

                        // 印刷DLLに印刷条件とデータを設定する
                        CallSetPrintConditionInfoAndDataMethod();
                        // 拡大率を設定する
                        this._prtParam.ExpansionRate = 50;

                        // プレビュー表示
                        CallPrevewMethod();
                    }

                    // 自由帳票対応表示更新
                    FormSettingForFreP(IsFrePSlip(_slipPrtSet));
                }
            }
        }
        /// <summary>
        /// 自由帳票判定
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private bool IsFrePSlip(SlipPrtSetWork slipPrtSet)
        {
            return slipPrtSet.SpecialPurpose1.Equals("20");
        }
        /// <summary>
        /// 自由帳票対応 画面制御
        /// </summary>
        private void FormSettingForFreP(bool isFreP)
        {
            // ヘッダー
            ugbEnterpriseNamePrtCd.Visible = !isFreP;
            uosEnterpriseNamePrtCd.Visible = !isFreP;
            ugbCustTelNoPrtDivCd.Visible = !isFreP;
            uosCustTelNoPrtDivCd.Visible = !isFreP;
            // 明細
            this.utcDetail.Tabs[1].Visible = !isFreP;
            // 明細（列）
            this.utcDetail.Tabs[2].Visible = !isFreP;
            // 余白
            // フォント
            this.utcDetail.Tabs[4].Visible = !isFreP;
        }
        # endregion ■ 各種設定　変更イベント ■

        # region ■ ツールバー／ボタンクリック ■
        /// <summary>
        /// ツールバーのクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーのクリックイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void utmMain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // ツールバークリックイベントをボタンのイベントに収束する
            System.EventArgs buttonEventArgs = new EventArgs();
            switch (e.Tool.Key)
            {
                case "Cancel": // キャンセル
                    {
                        ubPrint_Click(ubCancel, buttonEventArgs);
                        break;
                    }
                case "Print": // 印刷
                    {
                        ubPrint_Click(ubPrint, buttonEventArgs);
                        break;
                    }
                case "Pdf": // ＰＤＦ
                    {
                        ubPrint_Click(ubPdf, buttonEventArgs);
                        break;
                    }
            }
        }

        /// <summary>
        /// 印刷/キャンセル/PDFボタンのクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷/キャンセル/PDFボタンのクリックイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubPrint_Click(object sender, System.EventArgs e)
        {
            //==============================================================
            // キャンセルボタン																								
            //==============================================================
            if (sender == ubCancel)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Hide();
            }

            //==============================================================
            // 印刷ボタン																								
            //==============================================================
            if (sender == ubPrint)
            {
                // 印刷呼び出し
                if (CallPrint() == 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }

            //==============================================================
            // ＰＤＦボタン																								
            //==============================================================
            if (sender == ubPdf)
            {
                if (this._printData != null)
                {
                    //------------------------------------------------------
                    // ※複数伝票が指定された場合、出力PDFファイルを
                    //   伝票毎に分けるために、一時的に伝票データ１件のみの
                    //   状態にします。
                    //   全ての伝票をＰＤＦ出力した後、全伝票データを
                    //   退避しておいた変数から戻します。
                    //------------------------------------------------------

                    // 伝票データＡＬＬ退避
                    List<ArrayList> printDataWk = this._printData;

                    for (int index = 0; index < printDataWk.Count; index++)
                    {
                        // PDF書き込み用に１伝票分のデータのみ設定
                        this._printData = new List<ArrayList>();
                        this._printData.Add(printDataWk[index]);

                        // 伝票番号取得
                        //string slipNum = GetSlipNumFromCndtn( this._iSlipPrintCndtn, index );
                        string slipNum = GetSlipNumFromCndtn(this._iSlipPrintCndtn, printDataWk[index], index);

                        // PDF書き込み (一時的に伝票データを１件だけにしているので、毎回[0]番を処理)
                        WritePDF(slipNum);
                    }

                    // 伝票データＡＬＬ戻す
                    this._printData = printDataWk;
                }
            }
        }

        /// <summary>
        /// 伝票番号取得処理( PDFの連番付に使用 )
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetSlipNumFromCndtn(ISlipPrintCndtn iSlipPrintCndtn, ArrayList data, int index)
        {
            if (iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                // 売上伝票の場合
                FrePSalesSlipWork slipWork = (data[0] as FrePSalesSlipWork);

                string slipType = string.Empty;

                switch (slipWork.SALESSLIPRF_ACPTANODRSTATUSRF)
                {
                    case 10:
                        slipType = "見積";
                        break;
                    case 20:
                        slipType = "受注";
                        break;
                    default:
                    case 30:
                        switch (slipWork.SALESSLIPRF_SALESSLIPCDRF)
                        {
                            default:
                            case 0:
                                slipType = "売上";
                                break;
                            case 1:
                                slipType = "返品";
                                break;
                        }
                        break;
                    case 40:
                        slipType = "貸出";
                        break;
                }

                return string.Format("{0}_{1}", slipWork.SALESSLIPRF_SALESSLIPNUMRF, slipType);
            }
            else if (iSlipPrintCndtn is StockSlipPrintCndtn)
            {
                // 仕入返品伝票の場合
                return string.Format("{0}_仕入返品", index.ToString());
            }
            else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                // 在庫移動伝票の場合
                FrePStockMoveSlipWork slipWork = (data[0] as FrePStockMoveSlipWork);
                return string.Format("{0}_在庫移動", slipWork.MOVH_STOCKMOVESLIPNORF.ToString("000000000"));
            }
            else if (iSlipPrintCndtn is EstFmPrintCndtn)
            {
                // 見積書の場合
                FrePEstFmHead slipWork = (data[0] as FrePEstFmHead);
                return string.Format("{0}", slipWork.SALESSLIPRF_SALESSLIPNUMRF);
            }
            else if (iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                // ＵＯＥ伝票の場合
                FrePSalesSlipWork slipWork = (data[0] as FrePSalesSlipWork);
                return string.Format("{0}_UOE", slipWork.SALESSLIPRF_SALESSLIPNUMRF);
            }

            // 伝票№に相当する内容が取得できない場合は通し番号としてindexをそのまま返す。
            return index.ToString();
        }

        ///// <summary>
        ///// 伝票番号取得処理( PDFの連番付に使用 )
        ///// </summary>
        ///// <param name="iSlipPrintCndtn"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //private string GetSlipNumFromCndtn( ISlipPrintCndtn iSlipPrintCndtn, int index )
        //{
        //    if ( iSlipPrintCndtn is SalesSlipPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[index].SalesSlipNum;
        //    }
        //    else if ( iSlipPrintCndtn is StockSlipPrintCndtn )
        //    {
        //    }
        //    else if ( iSlipPrintCndtn is StockMoveSlipPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as StockMoveSlipPrintCndtn).StockMoveSlipKeyList[index].StockMoveSlipNo.ToString( "000000000" );
        //    }
        //    else if ( iSlipPrintCndtn is EstFmPrintCndtn )
        //    {
        //        return (iSlipPrintCndtn as EstFmPrintCndtn).EstFmUnitDataList[index].FrePEstFmHead.SALESSLIPRF_SALESSLIPNUMRF.Trim();
        //    }
        //    else if ( iSlipPrintCndtn is UOESlipPrintCndtn )
        //    {
        //    }

        //    // 伝票№に相当する内容が取得できない場合は通し番号としてindexをそのまま返す。
        //    return index.ToString();
        //}

        /// <summary>
        /// 印刷呼び出し
        /// </summary>
        /// <returns></returns>
        private int CallPrint()
        {
            int status = 0;

            // 条件とデータを印刷モジュールに設定する
            CallSetPrintConditionInfoAndDataMethod();
            // 印刷メソッドをCALLする
            // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked))
            // UPD 2013/09/19 Redmine#40342対応 --------------------------------------------------->>>>>
            //if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked) && (this._isService == 0))
            if ((_FormType == 0) && (ucePrevew.CheckState == CheckState.Checked) && (this._isService == 0) && (!this.IsTablet))
            // UPD 2013/09/19 Redmine#40342対応 ---------------------------------------------------<<<<<
            // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                // プレビュー有りの場合
                // 拡大率を設定する
                this._prtParam.ExpansionRate = 50;
                status = CallPrevewAndPrintMethod();
            }
            else
            {
                // プレビュー無しの場合
                status = CallPrintMethod();
            }

            if (status == 0)
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Normal;
            }
            else if (CheckInvalidPrinter())
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_InvalidPrinter;
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_CallPrint;
            }

            // statusを返す
            return status;
        }
        /// <summary>
        /// 無効なプリンタ設定のチェック処理
        /// </summary>
        /// <returns>true:プリンタは不正／false:プリンタは正常</returns>
        private bool CheckInvalidPrinter()
        {
            // 印刷ドキュメントに設定されているプリンタ名称を取得する
            string printerName;
            try
            {
                printerName = ((ISlipPrintProc)_prtObj).PrintDocument.Printer.PrinterName;

                if (printerName == string.Empty) return true;

                // インストール済みプリンタ一覧に含まれるか、チェックする
                bool printerExists = false;
                foreach (string wkStr in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (wkStr.Equals(printerName))
                    {
                        printerExists = true;
                        break;
                    }
                }
                return (!printerExists);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// ＰＤＦ出力呼び出し処理
        /// </summary>
        /// <param name="slipNum">伝票番号</param>
        private void WritePDF(string slipNum)
        {
            // 先頭データ(index=0)固定
            WritePDF(0, slipNum);
        }
        /// <summary>
        /// ＰＤＦ出力呼び出し処理
        /// </summary>
        /// <param name="slipIndex">伝票データindex</param>
        /// <param name="slipNum">伝票番号</param>
        private void WritePDF(int slipIndex, string slipNum)
        {
            if (slipIndex < this._printData.Count && this._printData[slipIndex] != null && 0 <= this._printData[slipIndex].Count)
            {
            }
            else
            {
                return;
            }

            // フォルダ
            if (!string.IsNullOrEmpty(_dataCache.PdfOutPath))
            {
                saveFileDialog1.InitialDirectory = _dataCache.PdfOutPath;
            }

            // 保存フォルダ指定画面を表示する
            if (!string.IsNullOrEmpty(slipNum))
            {
                saveFileDialog1.FileName = tcePrintType.Text.Trim() + slipNum + ".pdf";
            }
            else
            {
                saveFileDialog1.FileName = tcePrintType.Text.Trim() + ".pdf";
            }


            // ファイル保存ダイアログ
            DialogResult dSts = this.saveFileDialog1.ShowDialog(this);

            if (dSts == DialogResult.OK)
            {
                // 条件とデータを印刷モジュールに設定する
                CallSetPrintConditionInfoAndDataMethod();

                if (_FormType == 0)
                {
                    // 拡大率を設定する
                    this._prtParam.ExpansionRate = 50;
                }
                else
                {
                    // 拡大率を設定する
                    this._prtParam.ExpansionRate = 0;
                }
                // PDF出力
                CallPdfPrintMethod(saveFileDialog1.FileName);
            }
        }
        # endregion ■ ツールバー／ボタンクリック ■

        # region ■ ChangeFocus ■

        /// <summary>
        /// ArrowKeyControlイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : ArrowKeyControlイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //----------------------------------------------------
            // フォーカス位置コントロール
            //----------------------------------------------------
            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
            {
                switch (e.PrevCtrl.Name.Trim())
                {
                    // PDFボタン
                    case "ubPdf":
                        {
                            // 伝票タイプにフォーカス遷移
                            e.NextCtrl = tcePrintType;
                            break;
                        }
                    // フォントスタイル
                    case "tceSlipFontStyle":
                        {
                            // 伝票タイプにフォーカス遷移
                            e.NextCtrl = tcePrintType;
                            break;
                        }
                    // 部数
                    case "tnPrintCopy":
                        {
                            if (!this.pnlBottom.Visible)
                            {
                                // ヘッダーのTabページをアクティブ
                                this.utcDetail.SelectedTab = this.utpHeader.Tab;

                                // 複写枚数又はタイトル１にフォーカス遷移
                                if (tnCopyCount.Enabled)
                                {
                                    e.NextCtrl = tnCopyCount;
                                }
                                else
                                {
                                    e.NextCtrl = tceTitle1;
                                }
                            }
                            break;
                        }
                    // 自社名印字
                    case "ugbEnterpriseNamePrtCd":
                        {
                            // 明細のTabページをアクティブ
                            this.utcDetail.SelectedTab = this.utpDetail.Tab;
                            // 合計金額印字区分にフォーカス遷移
                            e.NextCtrl = uosTotalPricePrtCd;
                            break;
                        }
                    // 合計金額印字区分
                    case "uosTotalPricePrtCd":
                        {
                            // 明細(列)のTabページをアクティブ
                            this.utcDetail.SelectedTab = this.utpDetail2.Tab;
                            // 明細列印字区分にフォーカス遷移
                            e.NextCtrl = utEachSlipTypeCol;
                            break;
                        }
                    // 明細列印字区分
                    case "utEachSlipTypeCol":
                        {
                            // 余白のTabページをアクティブ
                            this.utcDetail.SelectedTab = this.utpMargin.Tab;
                            // 摘要印字区分にフォーカス遷移
                            e.NextCtrl = uosOutlinePrtCd;
                            break;
                        }
                    // 銀行名印字区分
                    case "uosBankNamePrtCd":
                        {
                            // 余白のTabページをアクティブ
                            this.utcDetail.SelectedTab = this.utpMargin.Tab;
                            // 余白（上）にフォーカス遷移
                            e.NextCtrl = tneTopMargin;
                            break;
                        }
                    // 余白（左）
                    case "tneBottomMargin":
                        {
                            // フォントのTabページをアクティブ
                            this.utcDetail.SelectedTab = this.utpFont.Tab;
                            // フォント名称にフォーカス遷移
                            e.NextCtrl = ufneSlipFontName;
                            break;
                        }
                }
            }

            //----------------------------------------------------
            // 余白設定の入力制御
            //----------------------------------------------------
            if (this.tneTopMargin.GetValue() + this.tneBottomMargin.GetValue() > 10)
            {
                if (e.PrevCtrl == tneTopMargin)
                {
                    this.tneTopMargin.SetValue(10 - this.tneBottomMargin.GetValue());
                }
                else if (e.PrevCtrl == tneBottomMargin)
                {
                    this.tneBottomMargin.SetValue(10 - this.tneTopMargin.GetValue());
                }
            }
            if (this.tneLeftMargin.GetValue() + this.tneRightMargin.GetValue() > 5)
            {
                if (e.PrevCtrl == tneLeftMargin)
                {
                    this.tneLeftMargin.SetValue(5 - this.tneRightMargin.GetValue());
                }
                else if (e.PrevCtrl == tneRightMargin)
                {
                    this.tneRightMargin.SetValue(5 - this.tneLeftMargin.GetValue());
                }
            }

            //----------------------------------------------------
            // 値に変更がかかっているか判断
            //----------------------------------------------------
            bool ItemValueChange = false;
            if (e.PrevCtrl is TEdit)
            {
                TEdit prevEdit = (TEdit)e.PrevCtrl;
                if (prevEdit.DataText != _prevText)
                {
                    ItemValueChange = true;
                }
            }
            if (e.PrevCtrl is TComboEditor)
            {
                TComboEditor prevCombo = (TComboEditor)e.PrevCtrl;
                if (prevCombo.Text != _prevText)
                {
                    ItemValueChange = true;
                }
            }
            if (e.PrevCtrl is TNedit)
            {
                TNedit prevEdit = (TNedit)e.PrevCtrl;
                if (prevEdit.GetInt() != _prevInt)
                {
                    ItemValueChange = true;
                }
            }
            if (ItemValueChange)
            {
                EventArgs evtArg = new EventArgs();
                ItemValueChanged(sender, evtArg);
            }

            //----------------------------------------------------
            // Nextフィールドの値を退避する
            //----------------------------------------------------
            if (e.NextCtrl is TEdit)
            {
                TEdit nextEdit = (TEdit)e.NextCtrl;
                _prevText = nextEdit.DataText;
            }
            if (e.NextCtrl is TComboEditor)
            {
                TComboEditor nextCombo = (TComboEditor)e.NextCtrl;
                _prevText = nextCombo.Text;
            }
            if (e.NextCtrl is TNedit)
            {
                TNedit nextEdit = (TNedit)e.NextCtrl;
                _prevInt = nextEdit.GetInt();
            }
        }
        # endregion

        # region ■ Enter / Leave ■
        /// <summary>
        /// 余白エディットEnterイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 余白エディットEnterイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tneTopMargin_Enter(object sender, System.EventArgs e)
        {
            if (sender == tneTopMargin)
            {
                ulTopMark1.Visible = true;
                ulTopMark2.Visible = true;
            }
            if (sender == tneLeftMargin)
            {
                ulLeftMark1.Visible = true;
                ulLeftMark2.Visible = true;
            }
            if (sender == tneRightMargin)
            {
                ulRightMark1.Visible = true;
                ulRightMark2.Visible = true;
            }
            if (sender == tneBottomMargin)
            {
                ulBottomMark1.Visible = true;
                ulBottomMark2.Visible = true;
            }
        }

        /// <summary>
        /// 余白エディットLeaveイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 余白エディットLeaveイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tneTopMargin_Leave(object sender, System.EventArgs e)
        {
            if (sender == tneTopMargin)
            {
                ulTopMark1.Visible = false;
                ulTopMark2.Visible = false;
            }
            if (sender == tneLeftMargin)
            {
                ulLeftMark1.Visible = false;
                ulLeftMark2.Visible = false;
            }
            if (sender == tneRightMargin)
            {
                ulRightMark1.Visible = false;
                ulRightMark2.Visible = false;
            }
            if (sender == tneBottomMargin)
            {
                ulBottomMark1.Visible = false;
                ulBottomMark2.Visible = false;
            }
        }

        /// <summary>
        /// Enterイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : Enterイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void UltraFontNameEditorEnter(object sender, System.EventArgs e)
        {
            // UltraFontNameEditorの場合・・・
            if (sender is UltraFontNameEditor)
            {
                UltraFontNameEditor Ufne = (UltraFontNameEditor)sender;
                Ufne.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            }
            // UltraNumericEditorの場合・・・
            if (sender is UltraNumericEditor)
            {
                UltraNumericEditor Une = (UltraNumericEditor)sender;
                Une.Appearance.BackColor = Color.FromArgb(247, 227, 156);
                Une.SelectAll();
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : Leaveイベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void UltraFontNameEditorLeave(object sender, System.EventArgs e)
        {
            // UltraFontNameEditorの場合・・・
            if (sender is UltraFontNameEditor)
            {
                UltraFontNameEditor Ufne = (UltraFontNameEditor)sender;
                Ufne.Appearance.BackColor = Color.White;
            }
            // UltraNumericEditorの場合・・・
            if (sender is UltraNumericEditor)
            {
                UltraNumericEditor Une = (UltraNumericEditor)sender;
                Une.Appearance.BackColor = Color.White;
            }
        }
        # endregion

        # region ■ 列移動グリッド ■
        /// <summary>
        /// 列移動グリッド初期化イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列移動グリッド初期化イベント</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ugEachSlipTypeColMove_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.ugEachSlipTypeColMove.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
            this.ugEachSlipTypeColMove.DisplayLayout.Override.SelectTypeRow = SelectType.None;
        }
        # endregion ■ 列移動グリッド ■

        # region ■ 伝票色ボタン ■
        /// <summary>
        /// 伝票色ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票色ボタンがクリックされた時に発生します。</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void ubSlipColor_Click(object sender, System.EventArgs e)
        {
            // 画面描画中は、exit
            if ((string)utcDetail.Tag == ctFormDrawingNow)
            {
                return;
            }

            Infragistics.Win.Misc.UltraButton wkUltraButton
                = sender as Infragistics.Win.Misc.UltraButton;
            if (wkUltraButton != null)
            {
                Infragistics.Win.Misc.UltraLabel wkUltraLabel = null;
                string wkStr = "ulSlipColorT" + wkUltraButton.Tag.ToString().Trim();
                // タイトルのUltraGroupBoxからクリックされたButtonと対になるLabelを取得
                for (int ix = 0; ix != ugbTitle.Controls.Count; ix++)
                {
                    if (ugbTitle.Controls[ix].Name.Equals(wkStr))
                    {
                        wkUltraLabel = ugbTitle.Controls[ix] as Infragistics.Win.Misc.UltraLabel;
                        break;
                    }
                }
                if (wkUltraLabel != null)
                {
                    colorDialog1.Color
                        = Color.FromArgb(wkUltraLabel.Appearance.BackColor.R, wkUltraLabel.Appearance.BackColor.G, wkUltraLabel.Appearance.BackColor.B);
                    switch (colorDialog1.ShowDialog())
                    {
                        case DialogResult.OK:
                            {
                                if (!wkUltraLabel.Appearance.BackColor.Equals(colorDialog1.Color))
                                {
                                    wkUltraLabel.Appearance.BackColor = colorDialog1.Color;

                                    // ※変更イベントを起動する⇒プレビューの再描画
                                    System.EventArgs EvtArg = new EventArgs();
                                    ItemValueChanged(sender, EvtArg);
                                }
                                break;
                            }
                        default:
                            {
                                wkUltraButton.Focus();
                                break;
                            }
                    }
                }
            }
        }
        # endregion ■ 伝票色ボタン ■

        # region ■ 伝票タイトルNotInList ■
        /// <summary>
        /// タイトル項目ItemNotInListイベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : タイトルのコンボボックスにてItemListに存在しない値が入力された時に発生します。</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void tceTitle_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
        # endregion ■ 伝票タイトルNotInList ■

        # region ■ キーダウン ■
        /// <summary>
        /// フォームキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーム上でキー押下された時に発生します。</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void DCCMN02000UA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ToolClickEventArgs ev = new ToolClickEventArgs(utmMain.Tools["Cancel"], new ListToolItem());
                utmMain_ToolClick(sender, ev);
            }
        }
        # endregion ■ キーダウン ■

        # endregion

        //==================================================================================
        // publicメソッド定義
        //==================================================================================
        # region ■ publicメソッド ■

        # region ■ 印刷確認 ■
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin

        /// <summary>
        /// 印刷確認画面表示(リモート伝票発行)
        /// </summary>
        /// <param name="iSlipPrintCndtn">伝票印刷条件</param>
        /// <param name="printData">印刷実データ</param>
        /// <param name="printWithoutDialog">確認ダイアログ表示無しフラグ</param>
        /// <param name="rmSlpPrtStWork">リモート伝発設定マスタ</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>伝票印刷確認画面を表示します。</br>
        /// <br>printWithoutDialog = true の場合は画面表示せずに直接印刷処理を行います。</br>
        /// </remarks>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, List<ArrayList> printData, bool printWithoutDialog, RmSlpPrtStWork rmSlpPrtStWork)
        {
            this._rmSlpPrtStWork = rmSlpPrtStWork;
            ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

        }

        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        /// <summary>
        /// 印刷確認画面表示
        /// </summary>
        /// <param name="iSlipPrintCndtn">伝票印刷条件</param>
        /// <param name="printData">印刷実データ</param>
        /// <param name="printWithoutDialog">確認ダイアログ表示無しフラグ</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>伝票印刷確認画面を表示します。</br>
        /// <br>printWithoutDialog = true の場合は画面表示せずに直接印刷処理を行います。</br>
        /// </remarks>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, List<ArrayList> printData, bool printWithoutDialog)
        {
            // ダイアログなし印刷区分取得
            _printWithoutDialog = printWithoutDialog;

            // 印刷実データ
            _printData = printData;

            // 印刷前処理を実行し、成功ならば印刷する
            if (PrintMainInitial(iSlipPrintCndtn))
            {
                if (_printWithoutDialog)
                {
                    //----------------------------------------
                    // ダイアログなし印刷
                    //----------------------------------------
                    // 印刷呼び出し
                    PrintMain();
                }
                else
                {
                    // ---------- ADD 2014/07/30 譚洪 Redmine#43082「障害一覧No.10664」 --------- >>>
                    // 障害現象：「得意先電子元帳から赤伝を発行すると確認ダイアログが２回表示（売伝を２回印刷）され、リモ伝が出力されない」障害の対応。
                    // 障害原因：以前リモート伝発処理仕様を追加時、_printWithoutDialogがTrueの場合、リモート伝発処理仕様を追加しました。
                    //           しかし、_printWithoutDialogがFalseの場合、リモート伝発処理仕様が漏れと思います。今回、対応します。

                    // _IsRmSlpPrtがTrueの場合、リモート伝発処理します「ダイアログなし」。
                    if (_IsRmSlpPrt)
                    {
                        // PrintMainメソッドは、_IsRmSlpPrtがFalseの場合、伝票印刷処理します。
                        // PrintMainメソッドは、_IsRmSlpPrtがTrueの場合、リモート伝発処理します。
                        PrintMain();
                    }
                    // _IsRmSlpPrtがFalseの場合、又、_printWithoutDialogがFalseの場合、 ダイアログ表示し,印刷ボタンで印刷します。
                    else
                    {
                    // ---------- ADD 2014/07/30 譚洪 Redmine#43082「障害一覧No.10664」 --------- <<<

                        //----------------------------------------
                        // ダイアログあり印刷確認
                        //----------------------------------------
                        // ダイアログ表示し,印刷ボタンで印刷(印刷直前に伝票更新する)
                        DialogResult dialogResult = base.ShowDialog();
                        if (dialogResult == DialogResult.Cancel)
                        {
                            _slipPrintDialogState = SlipPrintDialogStatus.Cancel;
                        }

                    }  // ADD 2014/07/30 譚洪 Redmine#43082「障害一覧No.10664」
                }
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_Initialize;
            }
        }

        # endregion ■ 印刷確認 ■

        // ADD 2013/10/30 SCM仕掛一覧№10614対応 ------------------------------------->>>>>
        /// <summary>
        /// キャッシュクリア
        /// </summary>
        /// <remarks>
        /// <br>伝票印刷確認画面のキャッシュクリアを行います。</br>
        /// </remarks>
        public void Clear()
        {
            if (this._slipPrintAcs != null) this._slipPrintAcs = null;
            if (this._scmRtPrtDtAcs != null) this._scmRtPrtDtAcs = null;
            if (this._pccCmpnyStAcs != null) this._pccCmpnyStAcs = null;
            if (this._pccTtlStAcs != null) this._pccTtlStAcs = null;
            if (this._dataCache != null) this._dataCache = null;
            if (this._printData != null) this._printData = null;
            if (this._prtObj != null) this._prtObj = null;
            if (this._slipPrintAssemblyFrom != null)
            {
                this._slipPrintAssemblyFrom.Dispose();
                this._slipPrintAssemblyFrom = null;
            }
            if (this._slipPrintAcs != null) this._slipPrtSet = null;
        }
        // ADD 2013/10/30 SCM仕掛一覧№10614対応 -------------------------------------<<<<<

        # endregion ■ publicメソッド ■

        //==================================================================================
        // privateメソッド定義
        //==================================================================================
        # region ■ privateメソッド ■

        # region ■ 印刷確認ＵＩメイン処理 ■
        /// <summary>
        /// 印刷メイン処理initialize
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <returns>true:準備成功 / false:準備失敗</returns>
        /// <remarks>印刷準備処理を行います。（関連マスタ読み込みと印刷データ取得まで）</remarks>
        private bool PrintMainInitial(object iSlipPrintCndtn)
        {
            //----------------------------------------------
            // 伝票印刷種別取得
            //----------------------------------------------
            if (GetSlipKind(out _slipKind, iSlipPrintCndtn) == false)
            {
                return false;
            }
            this._iSlipPrintCndtn = (ISlipPrintCndtn)iSlipPrintCndtn;

            //----------------------------------------------
            // 初期処理・印刷データ取得処理
            //----------------------------------------------
            if (InitProcOnShow() != 0)
            {
                // データ取得でエラーが発生した場合、該当データが無い場合は終了
                return false;
            }

            return true;
        }

        /// <summary>
        /// 印刷確認ＵＩメイン処理
        /// </summary>
        /// <remarks>
        /// <br>この処理は、呼び出し元アセンブリからのパラメータ指定によっては、</br>
        /// <br>別スレッドで実行される可能性があります。</br>
        /// <br></br>
        /// </remarks>
        private void PrintMain()
        {
            // update by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            // 印刷呼び出し
            //if ( CallPrint() == 0 )
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Hide();
            //}            
            int status = 0;
            bool execPrint = true;
            bool execRemotePrint = true;
            // 通常の伝票印刷処理判定
            if (_IsRmSlpPrt || CheckSlipPrint() == false) execPrint = false;
            // リモート伝票印刷処理判定
            if (!_IsRmSlpPrt || CheckRemoteSlipPrint() == false) execRemotePrint = false;

            // 通常の伝票印刷
            if (execPrint)
            {
                status = CallPrint();
            }

            if (status == 0)
            {
                // リモート伝発呼び出し
                if (execRemotePrint)
                {
                    CallRemoteSlipPrint();
                }

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            // update by zhouzy for PCCUOEリモート伝票発行 20110811  end
        }

        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// SCMリモート伝票印刷データを作成する
        /// </summary>
        private void CallRemoteSlipPrint()
        {
            // 条件とデータを印刷モジュールに設定する
            CallSetPrintConditionInfoAndDataMethod();

            // 印刷DLLを呼び出し
            int status = ((ISlipPrintProc)_prtObj).StartPreview(this);
            string errMsg = null;
            if (status == 0)
            {
                // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                _scmRtPrtDtAcs.PrintDataList = PrintDataList;
                // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                //SCMリモート伝票印刷データを作成する
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, out errMsg);//DEL 2013/06/17 zhubj FOR Redmine #36594
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, out errMsg);//ADD 2013/06/17 zhubj FOR Redmine #36594//DEL 2013/07/28 zhubj FOR Redmine #36594
                // UPD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                //status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, _isKeyChangeFlag, out errMsg);//ADD 2013/07/28 zhubj FOR Redmine #36594
                status = _scmRtPrtDtAcs.WriteScmRtPrtDt((ISlipPrintProc)_prtObj, _printData, _rmSlpPrtStWork, _isOnlyOneSlip, _isLastSlip, _isKeyChangeFlag, _slipNumlist, _inquiryNumList, out errMsg);
                PrintDataList = _scmRtPrtDtAcs.PrintDataList;
                // UPD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
            }

            if (status == 0)
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Normal;
            }
            else
            {
                _slipPrintDialogState = SlipPrintDialogStatus.Error_CallPrint;
            }
        }

        /// <summary>
        /// 伝票発行チェック
        /// </summary>
        /// <returns>伝票発行チェック結果</returns>
        private bool CheckSlipPrint()
        {
            int status = -1;
            SCMTtlStAcs scmTtlStAcs;
            SCMTtlSt scmTtlSt;

            //add start by liusy 2011/09/27 #25559 --------->>>>>>>
            //////////////////////////////////////////////////////////////
            //ＰＣＣ全体設定を参照する
            //////////////////////////////////////////////////////////////
            List<PccTtlSt> pccTtlStList;
            PccTtlSt parsePccTtlSt;
            PccTtlSt pccTtlSt;
            int retTotalCnt = 0;
            int readMode = 0;
            int readCnt = 0;
            //add end by liusy 2011/09/27 #25559 --------->>>>>>>

            //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = this._printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // 売上明細データワーク
            //>>>2011/10/19
            //FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];

            FrePSalesDetailWork salesDetailWork = null;
            if ((frePSalesDetailWorkList != null) && (frePSalesDetailWorkList.Count != 0))
            {
                salesDetailWork = frePSalesDetailWorkList[0];
            }
            //<<<2011/10/19
            //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
            
            if (_isAutoAns == 1)
            {
                scmTtlStAcs = new SCMTtlStAcs();
                scmTtlSt = new SCMTtlSt();
                //該当拠点のＰＣＣ全体設定を取得する
                status = scmTtlStAcs.Read(out scmTtlSt, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd());
                if (status != 0)
                {
                    return false;
                }
                //PCC全体設定に該当あり
                if (null != scmTtlSt)
                {
                    //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
                    //SCMの場合、PCC全体設定をチィックする
                    //>>>2011/10/19
                    //if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                    if ((salesDetailWork != null) && (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0))
                    //<<<2011/10/19
                    {
                    //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
                        //受注
                        if (_slipKind == 120)
                        {
                            //PCC全体設定.受注伝票発行区分==0:しない
                            if (scmTtlSt.AcpOdrrSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }
                        //売上
                        else if (_slipKind == 30)
                        {
                            //PCC全体設定.売上伝票発行区分==0:しない
                            if (scmTtlSt.SalesSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }
                    }//add 2011/10/17 
                }
                
                //add start by wangqx 2011/10/13 #25559 --------->>>>>>>
                SalesTtlStWork SalesTtlStWork = this.GetSalesTtlSt();
                //delete start by wangqx 2011/10/15 #25559 --------->>>>>>>
                //// BLﾊﾟｰﾂｵｰﾀﾞｰ全体設定.売上伝票発行区分＝しないの場合、自動回答時にPM側での伝票印刷できない
                //if (((SalesSlipPrintCndtn)this._iSlipPrintCndtn).SCMTotalSettingSalesSlipPrtDiv == 0)
                //{
                //    //SCM全体設定.売上伝票印刷フラグ：0 印刷しない
                //    return false;
                //}
                //delete end by wangqx 2011/10/15 #25559 ---------<<<<<<<
                //add end by wangqx 2011/10/13 #25559---------<<<<<<<

                //add start by liusy 2011/09/27 #25559 --------->>>>>>>
                parsePccTtlSt = new PccTtlSt();
                parsePccTtlSt.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                parsePccTtlSt.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                pccTtlStList = new List<PccTtlSt>();
                pccTtlSt = null;
                //該当拠点のＰＣＣ全体設定を取得する
                _pccTtlStAcs.Search(ref pccTtlStList, parsePccTtlSt, out retTotalCnt, readMode, readCnt, ConstantManagement.LogicalMode.GetData0);

                if (null != pccTtlStList && pccTtlStList.Count > 0)
                {
                    pccTtlSt = pccTtlStList[0];
                }
                //PCC全体設定に該当あり
                if (null != pccTtlSt)
                {
                    //受注
                    if (_slipKind == 120)
                    {
                        //PCC全体設定.受注伝票発行区分==0:しない
                        if (pccTtlSt.AcpOdrrSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                    //delete start by wangqx 2011/10/11 #25559 --------->>>>>>>
                    ////売上
                    //else if (_slipKind == 30)
                    //{
                    //    //PCC全体設定.売上伝票発行区分==0:しない
                    //    if (pccTtlSt.SalesSlipPrtDiv == 0)
                    //    {
                    //        return false;
                    //    }
                    //}
                    //delete end by wangqx 2011/10/11 #25559 ---------<<<<<<<
                    //add start by wangqx 2011/10/15 #25559 --------->>>>>>>
                    //売上
                    else if (_slipKind == 30)
                    {
                        //add start by wangqx 2011/10/17 #25559 --------->>>>>>>
                        //PCCUOEの場合、BLﾊﾟｰﾂｵｰﾀﾞｰ全体設定.売上伝票発行区分をチィックする
                        //>>>2011/10/19
                        //if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1)
                        if ((salesDetailWork != null) && (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1))
                        //<<<2011/10/19
                        {
                            //add end by liusy 2011/10/17 #25559 ---------<<<<<<<
                            // BLﾊﾟｰﾂｵｰﾀﾞｰ全体設定.売上伝票発行区分＝しないの場合、自動回答時にPM側での伝票印刷できない
                            if (pccTtlSt.SalesSlipPrtDiv == 0)
                            {
                                return false;
                            }
                        }//add 2011/10/17 
                    }
                    //add end by wangqx 2011/10/15 #25559 ---------<<<<<<<
                }
                //add end by liusy 2011/09/27 #25559 --------->>>>>>>

                //add start by wangqx 2011/09/30 #25559 No.2 --------->>>>>>>
                List<ArrayList> printDataWk = _printData;
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                
                // 得意先マスタから取得
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo;
                int flg = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, out customerInfo);

                if (flg == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
                {
                    // 納品書出力設定チェック
                    if (customerInfo.SalesSlipPrtDiv == 1 && _slipKind == 30)
                    {
                        // 1:未使用の場合
                        return false;
                    }
                    //add start by wangqx 2011/10/11 #25559 --------->>>>>>>
                    else if (customerInfo.SalesSlipPrtDiv == 0)
                    {
                        // 0:標準の場合
                        // PCC全体設定.売上伝票発行区分をチェックする
                        // PCC全体設定に該当あり
                        if (null != pccTtlSt)
                        {
                            //売上
                            if (_slipKind == 30)
                            {
                                //PCC全体設定.売上伝票発行区分==1:しない
                                if (SalesTtlStWork.SalesSlipPrtDiv == 1)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    //add end by wangqx 2011/10/11 #25559---------<<<<<<<
                }
                //add start by wangqx 2011/10/11 #25559 --------->>>>>>>
                else
                {
                    // PCC全体設定.売上伝票発行区分をチェックする
                    // PCC全体設定に該当あり
                    if (null != pccTtlSt)
                    {
                        //売上
                        if (_slipKind == 30)
                        {
                            //PCC全体設定.売上伝票発行区分==1:しない
                            if (SalesTtlStWork.SalesSlipPrtDiv == 1)
                            {
                                return false;
                            }
                        }
                    }
                }
                //add end by wangqx 2011/10/11 #25559---------<<<<<<<
                //add end by wangqx 2011/09/30 #25559 No.2 ---------<<<<<<<
            }

            return true;
        }

        /// <summary>
        /// リモート伝票発行チェック
        /// </summary>
        /// <returns>リモート伝票発行チェック結果</returns>
        private bool CheckRemoteSlipPrint()
        {

            /*del start by liusy 2011/09/27 #25559 --------->>>>>>>
            //////////////////////////////////////////////////////////////
            //ＰＣＣ全体設定を参照する
            //////////////////////////////////////////////////////////////
            List<PccTtlSt> pccTtlStList;
            PccTtlSt parsePccTtlSt;
            PccTtlSt pccTtlSt;
            int retTotalCnt = 0;
            int readMode = 0;
            int readCnt = 0;

            if (_isAutoAns == 1)
            {
                parsePccTtlSt = new PccTtlSt();
                parsePccTtlSt.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                parsePccTtlSt.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                pccTtlStList = new List<PccTtlSt>();
                pccTtlSt = null;
                //該当拠点のＰＣＣ全体設定を取得する
                _pccTtlStAcs.Search(ref pccTtlStList, parsePccTtlSt, out retTotalCnt, readMode, readCnt, ConstantManagement.LogicalMode.GetData0);

                if (null != pccTtlStList && pccTtlStList.Count > 0)
                {
                    pccTtlSt = pccTtlStList[0];
                }
                //PCC全体設定に該当あり
                if (null != pccTtlSt)
                {
                    //受注
                    if (_slipKind == 120)
                    {
                        //PCC全体設定.受注伝票発行区分==0:しない
                        if (pccTtlSt.AcpOdrrSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                    //売上
                    else if (_slipKind == 30)
                    {
                        //PCC全体設定.売上伝票発行区分==0:しない
                        if (pccTtlSt.SalesSlipPrtDiv == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            /*del end by liusy 2011/09/27 #25559 ---------<<<<<<< */
             
            //////////////////////////////////////////////////////////////
            //ＰＣＣ自社設定を参照する
            //////////////////////////////////////////////////////////////
            PccCmpnySt parsePccCmpnySt;
            PccCmpnySt pccCmpnySt;
            //伝票区分：売上 
            if (_slipKind == 30)
            {
                // 得意先ガイド初期化
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                Broadleaf.Application.UIData.CustomerInfo customerInfo;
                //印刷データ
                List<ArrayList> printDataWk = _printData;
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, true, out customerInfo);
                // -- DEL 2011/09/28   ------ >>>>>>
                ////赤伝の場合は印刷しない
                //if (slipWork.SALESSLIPRF_DEBITNOTEDIVRF == 1)
                //{
                //    return false;
                //}
                // -- DEL 2011/09/28   ------ <<<<<<
                parsePccCmpnySt = new PccCmpnySt();
                //問合せ元企業コード
                parsePccCmpnySt.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                //問合せ元拠点コード
                parsePccCmpnySt.InqOriginalSecCd = customerInfo.CustomerSecCode;
                //問合せ先企業コード
                parsePccCmpnySt.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                //問合せ先拠点コード
                parsePccCmpnySt.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

                _pccCmpnyStAcs.Read(ref parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
                //PCC自社設定に該当あり
                if (null != parsePccCmpnySt)
                {
                    pccCmpnySt = parsePccCmpnySt;
                    if (_isAutoAns == 1)
                    {
                        //PCC自社設定.伝票発行区分!=1:回答 && PCC自社設定.伝票発行区分!=3:両方
                        if (pccCmpnySt.PccSlipPrtDiv != 1 && pccCmpnySt.PccSlipPrtDiv != 3)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //PCC自社設定.伝票発行区分!=2:リモート && PCC自社設定.伝票発行区分!=3:両方 
                        if (pccCmpnySt.PccSlipPrtDiv != 2 && pccCmpnySt.PccSlipPrtDiv != 3)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

        /// <summary>
        /// 伝票印刷種別取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="iSlipPrintCndtn"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>伝票印刷種別を取得します。伝票印刷確認ＵＩで選択可能な伝票タイプは、この伝票印刷種別に依存します。</br>
        /// </remarks>
        private bool GetSlipKind(out int slipKind, object iSlipPrintCndtn)
        {
            slipKind = 0;

            // 条件として渡されたクラスを判定
            // ( 10:見積書,30:納品書,40:返品伝票,120:受注伝票,130:出荷伝票,140:見積伝票,150:在庫移動伝票,160:UOE伝票)
            if (iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                // << 売上 >>
                //if ( (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus == 10 )
                //{
                //    // 10:見積書レイアウト
                //    slipKind = 10;
                //}
                //else
                //{
                //    // 30:納品書レイアウト
                //    slipKind = 30;
                //}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/16 DEL
                //slipKind = (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/16 ADD

                //switch ( (iSlipPrintCndtn as SalesSlipPrintCndtn).SalesSlipKeyList[0].AcptAnOdrStatus )

                if (_printData != null && _printData.Count > 0 &&
                    _printData[0] != null && _printData[0].Count > 0)
                {
                    switch ((_printData[0][0] as FrePSalesSlipWork).SALESSLIPRF_ACPTANODRSTATUSRF)
                    {
                        case 10:
                            slipKind = 140; // 見積伝票
                            break;
                        case 20:
                            slipKind = 120; // 受注伝票
                            break;
                        case 40:
                            slipKind = 130; // 貸出伝票
                            break;
                        case 30:
                        default:
                            slipKind = 30; // 売上伝票
                            break;
                    }
                }
                else
                {
                    // 例外的なケースの場合はデフォルトで30:売上伝票とする
                    slipKind = 30;
                }

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/16 ADD
                // 再発行区分
                _slipPrintParameter.ReissueDiv = (iSlipPrintCndtn as SalesSlipPrintCndtn).ReissueDiv;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                // QR作成区分
                _slipPrintParameter.MakeQRDiv = (iSlipPrintCndtn as SalesSlipPrintCndtn).MakeQRDiv;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            }
            else if (iSlipPrintCndtn is StockSlipPrintCndtn)
            {
                // << 仕入 >>
                // 40:仕入返品伝票レイアウト                
                slipKind = 40;

                // 再発行区分←未使用なのでfalse
                _slipPrintParameter.ReissueDiv = false;
            }
            else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                // << 在庫移動 >>
                // 150:在庫移動レイアウト
                slipKind = 150;

                // 再発行区分
                _slipPrintParameter.ReissueDiv = (iSlipPrintCndtn as StockMoveSlipPrintCndtn).ReissueDiv;
            }
            else if (iSlipPrintCndtn is EstFmPrintCndtn)
            {
                // << 見積書 >>
                // 10:見積書レイアウト
                slipKind = 10;

                // 再発行区分←未使用なのでfalse
                _slipPrintParameter.ReissueDiv = false;
            }
            else if (iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                // << ＵＯＥ伝票 >>
                // 160:ＵＯＥ伝票レイアウト
                slipKind = 160;

                // 再発行区分←未使用なのでfalse
                _slipPrintParameter.ReissueDiv = false;
            }
            else
            {
                // その他のクラスを渡された時はエラー終了
                return false;
            }

            return true;
        }
        # endregion ■ 印刷確認ＵＩメイン処理 ■

        # region ■ 表示時初期処理およびデータ取得 ■
        /// <summary>
        /// 表示時初期処理およびデータ取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示時初期処理を行います。リモート使用による印刷データ取得も行います。</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int InitProcOnShow()
        {
            //******************************************************
            // 注意：　以下では、画面なし印刷／画面あり　共通で
            //         必要な処理のみを記述します。
            //         画面ありの場合のみ必要な処理は、DCCMN02000UB_Load
            //         に記載します。
            //         ( 画面なし印刷を高速化する為 )
            //******************************************************

            // 印刷プレビュー用パラメータクラス
            _prtParam = new SFMIT01290UB();
            _FormType = 0; // 簡易版

            //------------------------------------------------------
            // 画面の初期値を設定する
            //------------------------------------------------------
            # region [画面の初期値を設定する]
            // 印刷範囲（全て）
            uosPrintRange.Value = 1;
            // PDF用セーブダイアログの初期フォルダ設定
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            # endregion

            //------------------------------------------------------
            // プリンタ名コンボボックスを設定
            //------------------------------------------------------
            # region [プリンタ一覧]
            tcePrinterName.Items.Clear();

            List<PrtManage> prtManageList = _slipPrintAcs.SearchAllPrtManage(_enterpriseCode);
            foreach (PrtManage itm in prtManageList)
            {
                if (itm.LogicalDeleteCode == 0)
                {
                    tcePrinterName.Items.Add(itm.PrinterMngNo, itm.PrinterName);
                }
            }
            # endregion

            //------------------------------------------------------
            // 伝票名コンボボックスを設定
            //------------------------------------------------------
            # region [伝票タイプ一覧]
            // 伝票印刷設定ディクショナリ取得
            int defaultValue = 0;
            int printerMngNo = 0;
            Dictionary<int, string> slipPrintTypeDic = _slipPrintAcs.GetSlipPrintTypeList(_slipKind, _printData, out defaultValue, out printerMngNo);

            // コンボボックスに展開
            tcePrintType.Items.Clear();
            foreach (int typeSeqNo in slipPrintTypeDic.Keys)
            {
                tcePrintType.Items.Add(typeSeqNo, slipPrintTypeDic[typeSeqNo]);
            }

            // 伝票タイプを選択状態にする（※伝票タイプのValueChangeイベントで画面表示）
            tcePrintType.Value = defaultValue;
            if (tcePrintType.Value == null && tcePrintType.Items != null && tcePrintType.Items.Count > 0)
            {
                tcePrintType.SelectedIndex = 0;
            }
            tcePrinterName.Value = printerMngNo;
            // ADD 2013/04/19 T.Miyamoto ------------------------------>>>>>
            // 確認画面表示の場合
            if (_printWithoutDialog == false)
            {
                Assembly myAssembly = Assembly.GetEntryAssembly();
                string sPgid = System.IO.Path.GetFileNameWithoutExtension(myAssembly.Location);
                // 起動元PGが得意先電子元帳の場合、管理№が１のプリンタを初期表示する。
                if (sPgid == ctPGID_PMKAU04000U)
                {
                    tcePrinterName.Value = 1;
                }
            }
            // ADD 2013/04/19 T.Miyamoto ------------------------------<<<<<
            if (tcePrinterName.Value == null && tcePrinterName.Items != null && tcePrinterName.Items.Count > 0)
            {
                tcePrinterName.SelectedIndex = 0;
            }

            # endregion

            //------------------------------------------------------
            // データクラス外の印刷制御項目を設定
            //------------------------------------------------------
            # region [データクラス外の印刷制御項目]
            _slipPrintParameter.SlipDatePrintDiv = 1;   // 日付印字有無 1:する
            _slipPrintParameter.TotalPricePrtCd = 0;    // 合計金額印字 0:全ページ
            # endregion

            return 0;
        }
        # endregion ■ 表示時初期処理およびデータ取得 ■

        # region ■ アセンブリ・ロード ■
        // update by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        ///// <summary>
        ///// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        ///// </summary>
        ///// <param name="asmname">アセンブリ名称</param>
        ///// <param name="classname">クラス名称</param>
        ///// <returns>インスタンス化されたクラス</returns>
        //private object LoadAssemblyFrom(string asmname, string classname)
        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="outputFormFileName">出力帳票フォーム名</param>
        /// <returns>インスタンス化されたクラス</returns>
        private object LoadAssemblyFrom(string asmname, string classname, string outputFormFileName)
        // update by zhouzy for PCCUOEリモート伝票発行 20110811  end
        {
            object obj = null;
            try
            {
                //************************************************************
                // ※既定の伝票印刷アセンブリが設定されている場合、
                //   直接インスタンス生成する事で処理速度向上を図ります。
                //
                //   但し、リフレクションによる処理も残し、拡張性は維持します。
                //   アセンブリロード時間短縮の為、売上伝票、見積書以外は
                //   リフレクションで呼び出します。
                //************************************************************
                switch (asmname)
                {
                    case "PMHNB08001P":
                        {
                            //------------------------------------------------
                            // 自由帳票(売上伝票)印刷
                            //------------------------------------------------
                            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                            //// 2010/08/30 Add >>>
                            //if (Broadleaf.Drawing.Printing.PMHNB08001PCA.CustomizeFlg)
                            //    obj = new Broadleaf.Drawing.Printing.PMHNB08001PCA();
                            //else
                            //    // 2010/08/30 Add <<<
                            //    obj = new Broadleaf.Drawing.Printing.PMHNB08001PA();
                            if (!Broadleaf.Drawing.Printing.PMHNB08001PCA.CustomizeFlg || Broadleaf.Drawing.Printing.PMHNB08001PA.IsPackage(outputFormFileName))
                            {
                                obj = new Broadleaf.Drawing.Printing.PMHNB08001PA();
                            }
                            else
                            {
                                obj = new Broadleaf.Drawing.Printing.PMHNB08001PCA();
                            }
                            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

                        }
                        break;
                    case "PMMIT08001P":
                        {
                            //------------------------------------------------
                            // 自由帳票(見積書)印刷
                            //------------------------------------------------
                            obj = new Broadleaf.Drawing.Printing.PMMIT08001PA();
                        }
                        break;
                    default:
                        {
                            //------------------------------------------------
                            // リフレクションによるインスタンス生成
                            //------------------------------------------------
                            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                            Type objType = asm.GetType(classname);
                            if (objType != null)
                            {
                                obj = Activator.CreateInstance(objType);
                            }
                        }
                        break;
                }

                //// 印刷インタフェース実行チェック
                //Type PrintIF = obj.GetType().GetInterface( typeof( ISlipPrintProc ).Name );
                //if ( PrintIF == null || PrintIF.Name != "ISlipPrintProc" )
                //{
                //    throw new Exception( "印刷部品の生成に失敗しました。" );
                //}
            }
            catch (FileNotFoundException ex)
            {
                // 対象アセンブリなし（警告)
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                // 対象アセンブリなし（警告)
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message + "\n\r" + ex.StackTrace
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        # endregion ■ アセンブリ・ロード ■

        # region ■ アセンブリ・印刷データ設定メソッド呼び出し ■
        /// <summary>
        /// 印刷条件・印刷データ設定メソッド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷条件・印刷データ設定メソッド起動処理</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallSetPrintConditionInfoAndDataMethod()
        {
            SlipPrintConditionInfo slipPrintConditionInfo = new SlipPrintConditionInfo();
            // 画面値を取得する
            GetSlipPrtSetFromDisplay(ref slipPrintConditionInfo, ref _slipPrtSet);

            // 条件設定
            ArrayList ConditionInfo = new ArrayList();

            # region [共通の設定]
            // 伝票印刷設定
            if (_slipPrtSet != null)
            {
                ConditionInfo.Add(_slipPrtSet);

                // 自由帳票印字位置設定
                FrePrtPSetWork frePrtPSet = _slipPrintAcs.GetFrePrtPSet(_slipPrtSet);
                if (frePrtPSet != null)
                {
                    ConditionInfo.Add(frePrtPSet);
                }
            }
            else
            {
                ConditionInfo.Add(new SlipPrtSetWork());
            }
            // 伝票印刷パラメータ
            ConditionInfo.Add(_slipPrintParameter.ToDictionary());

            // --- ADD m.suzuki 2010/05/14 ---------->>>>>
            // 自由帳票印字位置設定ディクショナリ
            ConditionInfo.Add(_slipPrintAcs.GetFrePrtPSetDic());
            // 復号化済み自由帳票印字位置設定ディクショナリ
            ConditionInfo.Add(_slipPrintAcs.GetDecryptedFrePrtPSetDic());
            // --- ADD m.suzuki 2010/05/14 ----------<<<<<
            # endregion

            # region [伝票タイプ別の設定]
            if (_iSlipPrintCndtn is SalesSlipPrintCndtn)
            {
                //---------------------------------------------
                // 売上伝票
                //---------------------------------------------
                // 全体初期表示設定
                ConditionInfo.Add(this.GetAllDefSt());
                // 売上全体設定
                ConditionInfo.Add(this.GetSalesTtlSt());
                // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
                //税率設定
                ConditionInfo.Add(this.GetTaxRateSt());
                //売上金額処理区分設定
                ConditionInfo.Add(this.GetsalesProcMn());
                // --- ADD  大矢睦美  2010/03/04 ----------<<<<<
            }
            else if (_iSlipPrintCndtn is StockMoveSlipPrintCndtn)
            {
                //---------------------------------------------
                // 在庫移動伝票
                //---------------------------------------------
                // 全体初期表示設定
                ConditionInfo.Add(this.GetAllDefSt());
                // 在庫管理全体設定
                ConditionInfo.Add(this.GetStockMngTtlSt());
            }
            else if (_iSlipPrintCndtn is EstFmPrintCndtn)
            {
                //---------------------------------------------
                // 見積書
                //---------------------------------------------
                // 全体初期表示設定
                ConditionInfo.Add(this.GetAllDefSt());
                // 売上全体設定
                ConditionInfo.Add(this.GetSalesTtlSt());
                // 見積初期値設定(編集済み)
                ConditionInfo.Add((_iSlipPrintCndtn as EstFmPrintCndtn).EstimateDefSet);
            }
            else if (_iSlipPrintCndtn is UOESlipPrintCndtn)
            {
                //---------------------------------------------
                // ＵＯＥ伝票
                //---------------------------------------------
                // 全体初期表示設定
                ConditionInfo.Add(this.GetAllDefSt());
                // 売上全体設定
                ConditionInfo.Add(this.GetSalesTtlSt());
            }
            # endregion

            # region [予備情報]
            // 予備データ
            if (_iSlipPrintCndtn.ExtrData != null && _iSlipPrintCndtn.ExtrData.Count > 0)
            {
                ConditionInfo.AddRange(_iSlipPrintCndtn.ExtrData);
            }
            slipPrintConditionInfo.ExtrInfo = ConditionInfo;
            # endregion

            // 印刷データ設定
            object pData = this._printData;

            // 印刷DLLがアセンブリされているか？
            if (_prtObj != null)
            {
                //// 印刷DLLにI/Fが実装されているか？
                //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                //{
                // 印刷DLLのプレビューにメソッドをKick
                int st = ((ISlipPrintProc)_prtObj).SetPrintConditionInfoAndData(this, slipPrintConditionInfo, pData);
                if (st == 0)
                {
                    return 0;
                }
                //}
            }
            return -1;
        }

        # region [アクセスクラスからの各種設定取得]
        /// <summary>
        /// 全体初期表示設定
        /// </summary>
        /// <returns></returns>
        private AllDefSetWork GetAllDefSt()
        {
            AllDefSetWork allDefSet = _slipPrintAcs.GetAllDefSet();
            if (allDefSet != null)
            {
                return allDefSet;
            }
            else
            {
                return (new AllDefSetWork());
            }
        }
        /// <summary>
        /// 売上全体設定取得
        /// </summary>
        /// <returns></returns>
        private SalesTtlStWork GetSalesTtlSt()
        {
            SalesTtlStWork salesTtlSt = _slipPrintAcs.GetSalesTtlSt();
            if (salesTtlSt != null)
            {
                return salesTtlSt;
            }
            else
            {
                return (new SalesTtlStWork());
            }
        }
        /// <summary>
        /// 在庫管理全体設定
        /// </summary>
        /// <returns></returns>
        private object GetStockMngTtlSt()
        {
            StockMngTtlStWork stockMngTtlSt = _slipPrintAcs.GetStockMngTtlSt();
            if (stockMngTtlSt != null)
            {
                return stockMngTtlSt;
            }
            else
            {
                return (new StockMngTtlStWork());
            }
        }
        // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
        /// <summary>
        /// 税率設定取得     
        /// </summary>
        /// <returns></returns>
        private TaxRateSetWork GetTaxRateSt()
        {
            TaxRateSetWork taxRateSet = _slipPrintAcs.GetTaxRateSet();
            if (taxRateSet != null)
            {
                return taxRateSet;
            }
            else
            {
                return (new TaxRateSetWork());
            }
        }
        /// <summary>
        /// 売上金額処理区分設定取得
        /// </summary>
        /// <returns></returns>
        private List<SalesProcMoneyWork> GetsalesProcMn()
        {
            List<SalesProcMoneyWork> salesProcMoney = _slipPrintAcs.GetSalesProcMoney();
            if (salesProcMoney != null)
            {
                return salesProcMoney;
            }
            else
            {
                return (new List<SalesProcMoneyWork>());
            }
        }
        // --- ADD  大矢睦美  2010/03/04 ----------<<<<<
        # endregion
        # endregion ■ アセンブリ・印刷データ設定メソッド呼び出し ■

        # region ■ アセンブリ・プレビュー／印刷／ＰＤＦ出力メソッド呼び出し ■

        /// <summary>
        /// プレビューメソッド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : プレビューメソッド起動処理</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrevewMethod()
        {
            // 簡易画面の場合処理しない
            if (_FormType == 0)
            {
                return 0;
            }

            int status = 0;

            try
            {
                // 印刷DLLがアセンブリされているか？
                if (_prtObj != null)
                {
                    //// 印刷DLLにI/Fが実装されているか？
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // 印刷DLLを呼び出し
                    status = ((ISlipPrintProc)_prtObj).StartPreview(this);

                    if (status == 0)
                    {
                        // パラメータの設定
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.PrintPreviewWithoutPrtBtn(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "プレビュー処理にてエラーが発生しました"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// 印刷メソッド起動処理（プレビュー無し）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷メソッド起動処理（プレビュー無し）</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrintMethod()
        {
            int status = 0;
            try
            {
                // 印刷DLLがアセンブリされているか？
                if (_prtObj != null)
                {
                    //// 印刷DLLにI/Fが実装されているか？
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // 印刷DLLのプレビューにメソッドをKick
                    status = ((ISlipPrintProc)_prtObj).StartDirectPrint(this);
                    //}
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "印刷（プレビュー無し）処理にてエラーが発生しました"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// プレビュー＋印刷メソッド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : プレビュー＋印刷メソッド起動処理</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPrevewAndPrintMethod()
        {
            int status = 0;
            try
            {
                // 印刷DLLがアセンブリされているか？
                if (_prtObj != null)
                {
                    //// 印刷DLLにI/Fが実装されているか？
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // 印刷DLLのプレビューにメソッドをKick
                    status = ((ISlipPrintProc)_prtObj).StartPreviewPrint(this);

                    if (status == 0)
                    {
                        // パラメータの設定
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.PrintPreview(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TMsgDisp.Show(this
                //    , emErrorLevel.ERR_LEVEL_STOPDISP
                //    , ex.Source
                //    , "伝票印刷確認画面"
                //    , ex.TargetSite.Name
                //    , TMsgDisp.OPE_PRINT
                //    , "プレビュー＋印刷処理にてエラーが発生しました"
                //    , 0
                //    , null
                //    , ex
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);

                if (this._isService == 0)
                {
                    TMsgDisp.Show(this
                        , emErrorLevel.ERR_LEVEL_STOPDISP
                        , ex.Source
                        , "伝票印刷確認画面"
                        , ex.TargetSite.Name
                        , TMsgDisp.OPE_PRINT
                        , "プレビュー＋印刷処理にてエラーが発生しました"
                        , 0
                        , null
                        , ex
                        , MessageBoxButtons.OK
                        , MessageBoxDefaultButton.Button1);
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// PDF＋印刷メソッド起動処理
        /// </summary>
        /// <param name="PdfOutPath">ＰＤＦ出力パス</param>
        /// <remarks>
        /// <br>Note       : PDF＋印刷メソッド起動処理</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private int CallPdfPrintMethod(string PdfOutPath)
        {
            // ＰＤＦ出力フォルダ退避
            _dataCache.PdfOutPath = Path.GetDirectoryName(PdfOutPath);

            int status = 0;
            try
            {
                // 印刷DLLがアセンブリされているか？
                if (_prtObj != null)
                {
                    //// 印刷DLLにI/Fが実装されているか？
                    //Type PrintIf = _prtObj.GetType().GetInterface(typeof(ISlipPrintProc).Name);
                    //if (PrintIf != null && PrintIf.Name == "ISlipPrintProc")
                    //{
                    // 印刷DLLのPdfPrintメソッドをKick
                    status = ((ISlipPrintProc)_prtObj).StartPdfPrint(this);
                    if (status == 0)
                    {
                        // パラメータの設定
                        _prtParam.PreviewDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PreviewDocument;
                        _prtParam.PrintDocument = ((Broadleaf.Application.Common.ISlipPrintProc)_prtObj).PrintDocument;
                        _prtParam.PdfPath = PdfOutPath;

                        if (_slipPrintAssemblyFrom != null)
                        {
                            if (_slipPrintAssemblyFrom.TopLevel) _slipPrintAssemblyFrom.ShowInTaskbar = true;
                            status = _slipPrintAssemblyFrom.OutputPDF(_prtParam);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 DEL
                //TMsgDisp.Show(this
                //    , emErrorLevel.ERR_LEVEL_STOPDISP
                //    , ex.Source
                //    , "伝票印刷確認画面"
                //    , ex.TargetSite.Name
                //    , TMsgDisp.OPE_PRINT
                //    , "StartPdfPrintメソッドが定義されていません"
                //    , 0
                //    , null
                //    , ex
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);
                //status = -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , "PDFファイルの保存に失敗しました。" + Environment.NewLine
                     + "ファイルが使用中の可能性があります。"
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                status = -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
            }
            return status;
        }
        # endregion ■ アセンブリ・プレビュー／印刷／ＰＤＦ出力メソッド呼び出し ■

        # region ■ 画面 ← マスタ設定 ■

        /// <summary>
        /// 画面に値を設定する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面に値を設定する</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void SlipPrtSetToDisplay(SlipPrtSetWork slipPrtSet)
        {
            try
            {
                // 画面表示中
                this.utcDetail.Tag = ctFormDrawingNow;

                //----------------------------------------------------
                // 簡易印刷確認画面
                //----------------------------------------------------
                # region [簡易印刷確認]
                // 出力プログラムID・・・設定不要

                // 出力確認メッセージ
                ulPrintMsg.Text = slipPrtSet.OutConfimationMsg;

                // 印刷プレビュ有無区分
                if (slipPrtSet.PrtPreviewExistCode == 1)
                {
                    ucePrevew.CheckState = CheckState.Checked;
                }
                else
                {
                    ucePrevew.CheckState = CheckState.Unchecked;
                }

                //// プリンタ管理番号
                //tcePrinterName.Value = slipPrtSet.PrinterMngNo;

                // 印刷部数
                tnPrintCopy.Value = slipPrtSet.PrtCirculation;
                # endregion

                //----------------------------------------------------
                // ヘッダー
                //----------------------------------------------------
                # region [ヘッダ]
                tnCopyCount.Enabled = true;
                tnCopyCount.MaxValue = 4;

                // 伝票タイトル1
                SetTitleToDropDownItem(tceTitle1, slipPrtSet);
                tceTitle1.Text = slipPrtSet.TitleName1;
                // 伝票タイトル2
                SetTitleToDropDownItem(tceTitle2, slipPrtSet);
                tceTitle2.Text = slipPrtSet.TitleName2;
                // 伝票タイトル3
                SetTitleToDropDownItem(tceTitle3, slipPrtSet);
                tceTitle3.Text = slipPrtSet.TitleName3;
                // 伝票タイトル4
                SetTitleToDropDownItem(tceTitle4, slipPrtSet);
                tceTitle4.Text = slipPrtSet.TitleName4;

                if (slipPrtSet.CopyCount > 0)
                {
                    tnCopyCount.Value = slipPrtSet.CopyCount;
                }
                else
                {
                    tnCopyCount.Value = 1;
                }

                // 基準色を設定する
                ulSlipColorT1.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed1, slipPrtSet.SlipBaseColorGrn1, slipPrtSet.SlipBaseColorBlu1);
                ulSlipColorT2.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed2, slipPrtSet.SlipBaseColorGrn2, slipPrtSet.SlipBaseColorBlu2);
                ulSlipColorT3.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed3, slipPrtSet.SlipBaseColorGrn3, slipPrtSet.SlipBaseColorBlu3);
                ulSlipColorT4.Appearance.BackColor
                    = Color.FromArgb(slipPrtSet.SlipBaseColorRed4, slipPrtSet.SlipBaseColorGrn4, slipPrtSet.SlipBaseColorBlu4);

                // 自社名印刷区分
                uosEnterpriseNamePrtCd.Value = slipPrtSet.EnterpriseNamePrtCd;
                // 伝票日付印字区分
                uosSlipDatePrintDiv.Value = _slipPrintParameter.SlipDatePrintDiv;
                //// 得意先電話番号印字区分
                //uosCustTelNoPrtDivCd.Value = slipPrtSet.CustTelNoPrtDivCd;

                //// バーコード印字区分（受注番号）
                //if (slipPrtSet.BarCodeAcpOdrNoPrtCd == 1)
                //{
                //    uceBCAcpOdrNoPrtCd.Checked = true;
                //}
                //else
                //{
                //    uceBCAcpOdrNoPrtCd.Checked = false;
                //}
                //// バーコード印字区分（得意先コード）
                //if (slipPrtSet.BarCodeCustCodePrtCd == 1)
                //{
                //    uceBCCustCodePrtCd.Checked = true;
                //}
                //else
                //{
                //    uceBCCustCodePrtCd.Checked = false;
                //}
                # endregion

                //----------------------------------------------------
                // 明細
                //----------------------------------------------------
                # region [明細]
                // 合計金額印字区分
                uosTotalPricePrtCd.Value = _slipPrintParameter.TotalPricePrtCd;
                # endregion


                //----------------------------------------------------
                // 明細（列）
                //----------------------------------------------------
                # region [明細（列）]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //_slipColList.Clear();

                //// 伝票タイプ別列
                //string wkStr = "";
                //string wkEachSlipTypeColId = "";
                //string wkEachSlipTypeColNm = "";
                //int wkEachSlipTypeColPrt = 0;
                //for (int ix = 0 ; ix != 10 ; ix++)
                //{
                //    wkStr = slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //    if (wkStr != "")
                //    {
                //        wkEachSlipTypeColId = slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //        wkEachSlipTypeColNm = slipPrtSet.GetType().InvokeMember("EachSlipTypeColNm" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
                //        wkEachSlipTypeColPrt = (int)slipPrtSet.GetType().InvokeMember("EachSlipTypeColPrt" + (ix + 1).ToString(), BindingFlags.GetProperty, null, slipPrtSet, null);
                //        _slipColList.Add(ix, new SlipColInfo(wkEachSlipTypeColId, wkEachSlipTypeColNm, wkEachSlipTypeColPrt));
                //    }
                //}

                ////------------------------------------------------------
                //// 伝票列を設定する
                ////------------------------------------------------------
                //// データソースとTreeを初期化する
                //ultraDataSourceColMove.Band.Columns.Clear();
                //this.utEachSlipTypeCol.Nodes.Clear();
                //// 列移動用のグリッドを設定する
                //for (int ix = 0 ; ix < _slipColList.Count ; ix++)
                //{
                //    SlipColInfo item = (SlipColInfo)_slipColList[ix];
                //    // データソース生成
                //    this.ultraDataSourceColMove.Band.Columns.Add(item.SlipColId);
                //    // データソースグリッド設定
                //    this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[item.SlipColId].Header.Caption = item.SlipColName;
                //    if (item.SlipColOnOff == 1)
                //    {
                //        this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden = false;
                //    }
                //    else
                //    {
                //        this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden = true;
                //    }
                //    // 非表示制御用のTreeNodeを設定する
                //    Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode = new Infragistics.Win.UltraWinTree.UltraTreeNode();
                //    Infragistics.Win.UltraWinTree.Override _override = new Infragistics.Win.UltraWinTree.Override();
                //    _override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                //    ultraTreeNode.Override = _override;
                //    ultraTreeNode.Key = item.SlipColId;
                //    ultraTreeNode.Text = item.SlipColName;
                //    if (item.SlipColOnOff == 0)
                //    {
                //        ultraTreeNode.CheckedState = CheckState.Unchecked;
                //    }
                //    else
                //    {
                //        ultraTreeNode.CheckedState = CheckState.Checked;
                //    }

                //    this.utEachSlipTypeCol.Nodes.Add(ultraTreeNode);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                # endregion

                //----------------------------------------------------
                // フッター
                //----------------------------------------------------
                # region [フッタ]
                //// 銀行名印字区分
                //uosBankNamePrtCd.Value = slipIniSet.BankNamePrtCd;
                //// 摘要印字区分
                //uosOutlinePrtCd.Value = slipIniSet.OutlinePrtCd;
                # endregion

                //----------------------------------------------------
                // 余白
                //----------------------------------------------------
                # region [余白]
                // 上余白
                tneTopMargin.SetValue(slipPrtSet.TopMargin);
                // 左余白
                tneLeftMargin.SetValue(slipPrtSet.LeftMargin);
                // 右余白
                tneRightMargin.SetValue(slipPrtSet.RightMargin);
                // 下余白
                tneBottomMargin.SetValue(slipPrtSet.BottomMargin);
                # endregion
                // 2011.09.16 zhouzy UPDATE STA >>>>>>
                if (_IsRmSlpPrt)
                {// 上余白
                    tneTopMargin.SetValue(_rmSlpPrtStWork.TopMargin);
                    // 左余白
                    tneLeftMargin.SetValue(_rmSlpPrtStWork.LeftMargin);
                }
                // 2011.09.16 zhouzy UPDATE END <<<<<<

                //----------------------------------------------------
                // フォント
                //----------------------------------------------------
                # region [フォント]
                // 伝票フォント名称
                ufneSlipFontName.Value = slipPrtSet.SlipFontName;
                // 伝票フォントサイズ
                tceSlipFontSize.Value = slipPrtSet.SlipFontSize;
                // 伝票フォントスタイル
                tceSlipFontStyle.Value = slipPrtSet.SlipFontStyle;
                # endregion
            }
            finally
            {
                // 画面表示終了
                this.utcDetail.Tag = "";
            }
        }
        # endregion ■ 画面 ← マスタ設定 ■

        # region ■ 画面 → マスタ設定 ■

        /// <summary>
        /// 画面から値を取得する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面から値を取得する</br>
        /// <br>Programer  : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void GetSlipPrtSetFromDisplay(ref SlipPrintConditionInfo slipPrintConditionInfo, ref SlipPrtSetWork slipPrtSet)
        {
            try
            {
                // 自社画像
                slipPrintConditionInfo.CompanyImage = this.pbCompanyImage.Image;

                //----------------------------------------------------
                // 簡易印刷確認画面
                //----------------------------------------------------
                # region [簡易印刷確認]
                // 出力プログラムID･･･セット不要

                // 印刷プレビュ有無区分
                if (ucePrevew.CheckState == CheckState.Checked)
                {
                    // プレビュー有
                    slipPrtSet.PrtPreviewExistCode = 1;
                }
                else
                {
                    // プレビュー無
                    slipPrtSet.PrtPreviewExistCode = 0;
                }

                // プリンタ管理番号/プリンタ名称
                if (tcePrinterName.Value != null)
                {
                    //// プリンタ管理番号
                    //slipPrtSet.PrinterMngNo = (int)tcePrinterName.Value;
                    // プリンタ名称
                    slipPrintConditionInfo.PrinterName = tcePrinterName.Items[tcePrinterName.SelectedIndex].DisplayText;
                }

                // 印刷部数
                slipPrtSet.PrtCirculation = tnPrintCopy.GetInt();
                // 印刷範囲
                slipPrintConditionInfo.PrintRange = (int)uosPrintRange.Value;
                // 印刷開始ページ
                slipPrintConditionInfo.PrintTopPage = tnPrintRangeFrom.GetInt();
                // 印刷終了ページ
                slipPrintConditionInfo.PrintEndPage = tnPrintRangeTo.GetInt();
                # endregion

                //----------------------------------------------------
                // ヘッダー
                //----------------------------------------------------
                # region [ヘッダ]
                // 伝票タイトル1
                slipPrtSet.TitleName1 = tceTitle1.Text;
                // 伝票タイトル2
                slipPrtSet.TitleName2 = tceTitle2.Text;
                // 伝票タイトル3
                slipPrtSet.TitleName3 = tceTitle3.Text;
                // 伝票タイトル4
                slipPrtSet.TitleName4 = tceTitle4.Text;

                // 伝票複写枚数
                slipPrtSet.CopyCount = (int)tnCopyCount.Value;

                // 自社名印刷区分
                slipPrtSet.EnterpriseNamePrtCd = (int)uosEnterpriseNamePrtCd.Value;
                // 伝票日付印字区分
                _slipPrintParameter.SlipDatePrintDiv = (int)uosSlipDatePrintDiv.Value;
                //// 得意先電話番号印字区分
                //slipPrtSet.CustTelNoPrtDivCd = (int)uosCustTelNoPrtDivCd.Value;

                //// バーコード印字区分（受注番号）
                //if ((this._isBarCodeOpt) &&
                //    (uceBCAcpOdrNoPrtCd.Checked))
                //{
                //    slipPrtSet.BarCodeAcpOdrNoPrtCd = 1;
                //}
                //else
                //{
                //    slipPrtSet.BarCodeAcpOdrNoPrtCd = 0;
                //}
                //// バーコード印字区分（得意先コード）
                //if ((this._isBarCodeOpt) &&
                //    (uceBCCustCodePrtCd.Checked))
                //{
                //    slipPrtSet.BarCodeCustCodePrtCd = 1;
                //}
                //else
                //{
                //    slipPrtSet.BarCodeCustCodePrtCd = 0;
                //}

                // 基準色１を取得する
                slipPrtSet.SlipBaseColorRed1 = ulSlipColorT1.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn1 = ulSlipColorT1.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu1 = ulSlipColorT1.Appearance.BackColor.B;
                // 基準色２を取得する
                slipPrtSet.SlipBaseColorRed2 = ulSlipColorT2.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn2 = ulSlipColorT2.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu2 = ulSlipColorT2.Appearance.BackColor.B;
                // 基準色３を取得する
                slipPrtSet.SlipBaseColorRed3 = ulSlipColorT3.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn3 = ulSlipColorT3.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu3 = ulSlipColorT3.Appearance.BackColor.B;
                // 基準色４を取得する
                slipPrtSet.SlipBaseColorRed4 = ulSlipColorT4.Appearance.BackColor.R;
                slipPrtSet.SlipBaseColorGrn4 = ulSlipColorT4.Appearance.BackColor.G;
                slipPrtSet.SlipBaseColorBlu4 = ulSlipColorT4.Appearance.BackColor.B;

                # endregion

                //----------------------------------------------------
                // 明細
                //----------------------------------------------------
                # region [明細]
                // 合計金額印字区分
                _slipPrintParameter.TotalPricePrtCd = (int)uosTotalPricePrtCd.Value;
                # endregion

                //----------------------------------------------------
                // 明細（列）
                //----------------------------------------------------
                # region [明細（列）]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //for (int ix = 0 ; ix < 10 ; ix++)
                //{
                //    string ColId = "";
                //    string ColNm = "";
                //    int ColPrt = 0;
                //    int ColPos = ix;

                //    // 列移動グリッドからカラム情報を取得する
                //    if (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns.Count > ix)
                //    {
                //        // 列のポジションを取得する
                //        ColPos = this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.VisiblePosition;
                //        if ((this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix] != null) &&
                //            (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Key != null) &&
                //            (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.Caption != null))
                //        {
                //            // 列ＩＤと列名を取得
                //            ColId = (string)this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Key;
                //            ColNm = (string)this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Header.Caption;
                //            // 印刷区分を取得する
                //            if (this.ugEachSlipTypeColMove.DisplayLayout.Bands[0].Columns[ix].Hidden == false) ColPrt = 1;
                //        }
                //    }

                //    // 伝票列情報を設定する
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColId" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColId });
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColNm" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColNm });
                //    slipPrtSet.GetType().InvokeMember("EachSlipTypeColPrt" + (ColPos + 1).ToString(), BindingFlags.SetProperty, null, slipPrtSet, new Object[] { ColPrt });
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                # endregion

                //----------------------------------------------------
                // フッター
                //----------------------------------------------------
                # region [フッタ]
                //// 銀行名印字区分
                //slipIniSet.BankNamePrtCd = (int)uosBankNamePrtCd.Value;
                //// 摘要印字区分
                //slipIniSet.OutlinePrtCd = (int)uosOutlinePrtCd.Value;
                # endregion

                //----------------------------------------------------
                // 余白
                //----------------------------------------------------
                # region [余白]
                // 上余白
                slipPrtSet.TopMargin = tneTopMargin.GetValue();
                // 左余白
                slipPrtSet.LeftMargin = tneLeftMargin.GetValue();
                // 右余白
                slipPrtSet.RightMargin = tneRightMargin.GetValue();
                // 下余白
                slipPrtSet.BottomMargin = tneBottomMargin.GetValue();
                # endregion

                //----------------------------------------------------
                // フォント
                //----------------------------------------------------
                # region [フォント]
                // 伝票フォント名称
                if (ufneSlipFontName.Value != null)
                {
                    slipPrtSet.SlipFontName = (string)ufneSlipFontName.Value;
                }
                // 伝票フォントサイズ
                if (tceSlipFontSize.Value != null)
                {
                    slipPrtSet.SlipFontSize = (int)tceSlipFontSize.Value;
                }
                // 伝票フォントスタイル
                if (tceSlipFontStyle.Value != null)
                {
                    slipPrtSet.SlipFontStyle = (int)tceSlipFontStyle.Value;
                }
                # endregion
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this
                    , emErrorLevel.ERR_LEVEL_STOPDISP
                    , ex.Source
                    , "伝票印刷確認画面"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_PRINT
                    , ex.Message + "\n\r" + ex.StackTrace
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
        }
        # endregion ■ 画面 → マスタ設定 ■

        # region ■ 伝票タイトル・DropDownItem設定 ■
        /// <summary>
        /// 伝票タイトル選択用DropDownItemセット処理
        /// </summary>
        /// <param name="comboEditor">セット対象ComboEditor</param>
        /// <param name="slipPrtSet">伝票印刷設定マスタ</param>
        /// <remarks>
        /// <br>Note       : ComboEditorのItemに選択用伝票タイトルをセットします。</br>
        /// <br>Programmer : 22018 鈴木　正臣</br>
        /// <br>Date       : 2007.12.17</br>
        /// </remarks>
        private void SetTitleToDropDownItem(TComboEditor comboEditor, SlipPrtSetWork slipPrtSet)
        {
            comboEditor.Items.Clear();

            string wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString(), BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "02", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "03", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "04", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
            wkStr = slipPrtSet.GetType().InvokeMember("TitleName" + comboEditor.Tag.ToString() + "05", BindingFlags.GetProperty, null, slipPrtSet, null).ToString();
            if ((wkStr != null) &&
                (!wkStr.Trim().Equals(String.Empty)))
            {
                comboEditor.Items.Add(wkStr);
            }
        }
        # endregion ■ 伝票タイトル・DropDownItem設定 ■

        # endregion ■ privateメソッド ■

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
        ////==================================================================================
        //// 伝票列情報クラス
        ////==================================================================================
        //# region ■ SlipColInfo ■
        ///// <summary>
        ///// 伝票列情報クラス
        ///// </summary>
        ///// <remarks>
        ///// <br>Programer  : 22018 鈴木　正臣</br>
        ///// <br>Date       : 2007.12.17</br>
        ///// </remarks>
        //[Serializable]
        //private class SlipColInfo
        //{
        //    /// <summary>
        //    /// 伝票列ID
        //    /// </summary>
        //    private string _slipColId;
        //    /// <summary>
        //    /// 伝票列名称
        //    /// </summary>
        //    private string _slipColName;
        //    /// <summary>
        //    /// 伝票列印字区分
        //    /// </summary>
        //    private int _slipColOnOff;

        //    /// <summary>
        //    /// 伝票列IDプロパティ
        //    /// </summary>
        //    public string SlipColId
        //    {
        //        get { return _slipColId; }
        //        set { this._slipColId = value; }
        //    }
        //    /// <summary>
        //    /// 伝票列名称ロパティ
        //    /// </summary>
        //    public string SlipColName
        //    {
        //        get { return _slipColName; }
        //        set { this._slipColName = value; }
        //    }
        //    /// <summary>
        //    /// 伝票列印字区分プロパティ
        //    /// </summary>
        //    public int SlipColOnOff
        //    {
        //        get { return _slipColOnOff; }
        //        set { this._slipColOnOff = value; }
        //    }

        //    /// <summary>
        //    /// コンストラクタ定義
        //    /// </summary>
        //    public SlipColInfo()
        //    {
        //        _slipColId = "";
        //        _slipColName = "";
        //        _slipColOnOff = 0;
        //    }

        //    public SlipColInfo(string pId, string pName, int pOnOff)
        //    {
        //        _slipColId = pId;
        //        _slipColName = pName;
        //        _slipColOnOff = pOnOff;
        //    }
        //}
        //# endregion ■ SlipColInfo ■
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL

        # region ■　伝票印刷パラメータ構造体　■
        /// <summary>
        /// 伝票印刷パラメータ構造体
        /// </summary>
        /// <remarks>
        /// <br>※データクラスのメンバとして存在しないデータを</br>
        /// <br>　印刷ＤＬＬに受け渡す為の構造体です。</br>
        /// <br>※objectのディクショナリとの相互変換機能を持ちます。</br>
        /// </remarks>
        private struct SlipPrintParameter
        {
            /// <summary>日付印字有無(0:しない/1:する)</summary>
            private int _slipDatePrintDiv;
            /// <summary>合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</summary>
            private int _totalPricePrtCd;
            /// <summary>再発行区分</summary>
            private bool _reissueDiv;
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>QR作成区分</summary>
            private bool _makeQRDiv;
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// 日付印字有無(0:しない/1:する)
            /// </summary>
            public int SlipDatePrintDiv
            {
                get { return _slipDatePrintDiv; }
                set { _slipDatePrintDiv = value; }
            }
            /// <summary>
            /// 合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)
            /// </summary>
            public int TotalPricePrtCd
            {
                get { return _totalPricePrtCd; }
                set { _totalPricePrtCd = value; }
            }
            /// <summary>
            /// 再発行区分
            /// </summary>
            public bool ReissueDiv
            {
                get { return _reissueDiv; }
                set { _reissueDiv = value; }
            }
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>
            /// QR作成区分
            /// </summary>
            public bool MakeQRDiv
            {
                get { return _makeQRDiv; }
                set { _makeQRDiv = value; }
            }
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="slipDatePrintDiv">日付印字有無(0:しない/1:する)</param>
            /// <param name="totalPricePrtCd">合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</param>
            /// <param name="reissueDiv">再発行区分</param>
            public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv)
            {
                _slipDatePrintDiv = slipDatePrintDiv;
                _totalPricePrtCd = totalPricePrtCd;
                _reissueDiv = reissueDiv;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                _makeQRDiv = false;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            }
            // --- ADD m.suzuki 2010/07/09 ---------->>>>>
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="slipDatePrintDiv">日付印字有無(0:しない/1:する)</param>
            /// <param name="totalPricePrtCd">合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</param>
            /// <param name="reissueDiv">再発行区分</param>
            /// <param name="makeQRDiv">QR作成区分</param>
            public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv, bool makeQRDiv)
            {
                _slipDatePrintDiv = slipDatePrintDiv;
                _totalPricePrtCd = totalPricePrtCd;
                _reissueDiv = reissueDiv;
                _makeQRDiv = makeQRDiv;
            }
            // --- ADD m.suzuki 2010/07/09 ----------<<<<<
            /// <summary>
            /// コンストラクタ (objectのディクショナリより)
            /// </summary>
            /// <param name="objectDictionary"></param>
            public SlipPrintParameter(Dictionary<string, object> objectDictionary)
            {
                // 初期値を設定
                _slipDatePrintDiv = 1;
                _totalPricePrtCd = 0;
                _reissueDiv = false;
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                _makeQRDiv = false;
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<

                // 渡されたListの内容を格納
                if (objectDictionary != null)
                {
                    if (objectDictionary.ContainsKey("SlipDatePrintDiv") && objectDictionary["SlipDatePrintDiv"] is int)
                    {
                        _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                    }
                    if (objectDictionary.ContainsKey("TotalPricePrtCd") && objectDictionary["TotalPricePrtCd"] is int)
                    {
                        _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                    }
                    if (objectDictionary.ContainsKey("ReissueDiv") && objectDictionary["ReissueDiv"] is bool)
                    {
                        _reissueDiv = (bool)objectDictionary["ReissueDiv"];
                    }
                    // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                    if (objectDictionary.ContainsKey("MakeQRDiv") && objectDictionary["MakeQRDiv"] is bool)
                    {
                        _makeQRDiv = (bool)objectDictionary["MakeQRDiv"];
                    }
                    // --- ADD m.suzuki 2010/07/09 ----------<<<<<
                }
            }
            /// <summary>
            /// ディクショナリへ変換
            /// </summary>
            /// <returns></returns>
            public Dictionary<string, object> ToDictionary()
            {
                // メンバをディクショナリに格納
                Dictionary<string, object> objectDic = new Dictionary<string, object>();
                objectDic.Add("SlipDatePrintDiv", _slipDatePrintDiv);
                objectDic.Add("TotalPricePrtCd", _totalPricePrtCd);
                objectDic.Add("ReissueDiv", _reissueDiv);
                // --- ADD m.suzuki 2010/07/09 ---------->>>>>
                objectDic.Add("MakeQRDiv", _makeQRDiv);
                // --- ADD m.suzuki 2010/07/09 ----------<<<<<

                // Dictionaryを返す
                return objectDic;
            }
        }
        # endregion ■　伝票印刷パラメータ構造体　■

        # region [伝票印刷ダイアログ・ステータス]
        /// <summary>
        /// 伝票印刷ダイアログ・ステータス
        /// </summary>
        public enum SlipPrintDialogStatus
        {
            Normal = 0,
            Cancel = 1,
            Error_CallPrint = 2,
            Error_Initialize = 3,
            Error_InvalidPrinter = 4,
        }
        # endregion

        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("DCCMN02000U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                
    }
    /// <summary>
    /// 伝票ダイアログ情報バッファ
    /// </summary>
    /// <remarks>同一プロセス内で共有したい情報を保持します。（singleton）</remarks>
    public class SlipDialogDataCache
    {
        // staticインスタンス
        private static SlipDialogDataCache stc_SlipDialogDataCache;

        // ＰＤＦ出力パス
        private string _pdfOutPath;

        /// <summary>
        /// ＰＤＦ出力パス
        /// </summary>
        public string PdfOutPath
        {
            get { return _pdfOutPath; }
            set { _pdfOutPath = value; }
        }

        /// <summary>
        /// プライベートコンストラクタ
        /// </summary>
        private SlipDialogDataCache()
        {
            _pdfOutPath = string.Empty;
        }

        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns></returns>
        public static SlipDialogDataCache GetInstance()
        {
            if (stc_SlipDialogDataCache == null)
            {
                stc_SlipDialogDataCache = new SlipDialogDataCache();
            }
            return stc_SlipDialogDataCache;
        }
    }
}

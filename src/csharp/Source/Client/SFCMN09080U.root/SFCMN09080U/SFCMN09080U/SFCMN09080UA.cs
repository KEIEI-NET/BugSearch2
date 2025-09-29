//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：全体初期表示設定マスタ
// プログラム概要   ：全体初期表示設定の登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍　幸史
// 修正日    2008/06/04     修正内容：「顧客コード自動発番」「得意先削除チェック」「会員情報管理」削除
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍　幸史
// 修正日    2008/09/10     修正内容：「消費税自動補正区分」削除
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍　幸史
// 修正日    2008/09/12     修正内容：全社共通データは削除できないよう変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30418  徳永　俊詞
// 修正日    2008/11/05     修正内容：全社共通を呼び出したときには「未登録」ではなく「全社共通」と表示するように修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍　幸史
// 修正日    2009/01/05     修正内容：障害ID：0009053対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/17     修正内容：Mantis【12827】速度アップ対応
//                                  ：Mantis【13190】マスメン最新情報対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢　睦美
// 修正日    2010/01/18     修正内容：Mantis【14890】初期表示請求書出力区分削除し、請求書タイプ毎の出力区分追加
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：zhouyu
// 修正日    2011/07/19     修正内容：連番 1028 在庫仕入入力で、品番入力後に自動で 仕入数=１ と表示され、現在庫数が足されて表示になり分かりずらい
//                                    PM7では、仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される
//                                    売上伝票入力，仕入伝票入力 も同じ
// ---------------------------------------------------------------------//
// 管理番号 10704766-00     作成担当：王飛3
// 修正日    2011/07/28     修正内容：連番909　＜全体初期表示設定＞で拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//                          拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正してください。
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：王飛３
// 修正日    2011/09/07     修正内容：障害報告 #24169　
//                                    拠点コード「1」で登録した際に「01」で登録される
//                                    全拠点での登録
//                                    拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
// 管理番号  10901273-00    作成担当：王君
// 修正日    2013/05/02     修正内容：2013/06/18配信分　 Redmine#35434　
//                                    商品在庫マスタ起動区分の追加
// ---------------------------------------------------------------------//

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
	/// 全体初期表示設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 全体初期表示設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
	/// <br>Programmer	: 23006  高橋 明子</br>
	/// <br>Date		: 2005.10.03</br>
    /// <br></br>
	/// <br>Update Note : 2005.10.04  23006 高橋 明子</br>
	/// <br>			    ・ファイル仕様書変更の為、対応</br>
    /// <br></br>
	/// <br>Update Note : 2005.10.19  23006 高橋 明子</br>
	/// <br>			    ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br></br>
	/// <br>Update Note : 2005.11.10  23006 高橋 明子</br>
	/// <br>                ・参照型コンボボックス「削除済」表示対応</br>
    /// <br></br>
	/// <br>Update Note : 2005.12.19  23006 高橋 明子</br>
	/// <br>                ・キャッシュ一本化対応</br>
    /// <br></br>
	/// <br>Update Note : 2006.01.13  23006 高橋 明子</br>
	/// <br>                ・コード参照項目の入力変更フラグを立てるときの条件修正</br>
    /// <br></br>
    /// <br>Update Note : 2006.07.26  23006 高橋 明子</br>
    /// <br>                ・ブラッシュアップ対応</br>
    /// <br></br>
    /// <br>Update Note : 2006.09.13  23006 高橋 明子</br>
    /// <br>                ・「陸運事務所番号」追加対応</br>
	/// <br></br>
    /// <br>Update Note : 2006.12.05  18322 木村 武正</br>
    /// <br>                ○携帯システム対応</br>
    /// <br>　　　　　　　　　管区コード、初期表示住所コード１～３、初期表示住所、</br>
    /// <br>                  自賠責算定区分、車両確定選択方式、陸運事務所番号を削除</br>
    /// <br>              2007.02.07 18322 T.Kimura 画面スキン変更対応</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.05 30005 木建　翼</br>
    /// <br>                ○携帯システム対応</br>
    /// <br>                  新しい項目「会員情報管理区分」を追加</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.28 22022 段上　知子</br>
    /// <br>                ・「総額表示方法」のグリッド表示位置の障害対応</br>
    /// <br>                ・「会計情報管理区分」のグリッド設定の障害対応</br>
    /// <br>                ・画面項目タイトル・項目位置の障害対応</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.19 30005  木建　翼</br>
    /// <br>                ・不要なXMLコメントのコメントアウト</br>
    /// <br></br>
    /// <br>Update Note : 2007.07.12 20031  古賀　小百合</br>
    /// <br>                ・「DM区分」を非表示に変更(復帰の可能性を踏まえ、非表示に変更するに留める)</br>
    /// <br></br>
    /// <br>Update Note : 2007.08.08 20056  對馬 大輔</br>
    /// <br>                ○流通販売基幹対応</br>
    /// <br>                ・元号表示区分１・２・３</br>
    /// <br>Update Note : 2008/06/04 30414  忍　幸史</br>
    /// <br>                ・「顧客コード自動発番」「得意先削除チェック」「会員情報管理」削除</br>
    /// <br>Update Note : 2008/09/10 30414  忍　幸史</br>
    /// <br>                ・「消費税自動補正区分」削除</br>
    /// <br>Update Note : 2008/09/12 30414  忍　幸史</br>
    /// <br>                ・全社共通データは削除できないよう変更</br>
    /// <br>Update Note : 2008/11/05 30418  徳永　俊詞</br>
    /// <br>                ・全社共通を呼び出したときには「未登録」ではなく「全社共通」と表示するように修正</br>
    /// <br>Update Note : 2009/01/05 30414  忍　幸史</br>
    /// <br>                ・障害ID：0009053対応</br>
    /// <br>Update Note : 2010/01/18 30531  大矢 睦美</br>
    /// <br>                ・請求書出力区分を削除し、請求書タイプ毎の出力区分追加（３項目）</br>
    /// <br>Update Note : 2011/07/19 zhouyu</br>
    /// <br>                ・連番 1028</br>
    /// <br>                  修正内容：連番 1028 在庫仕入入力で、品番入力後に自動で 仕入数=１ と表示され、現在庫数が足されて表示になり分かりずらい</br>
    /// <br>                  PM7では、仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>                  売上伝票入力，仕入伝票入力 も同じ</br>
    /// <br>Update Note : 2011/07/28 王飛3</br>
    /// <br>                ・連番909　＜全体初期表示設定＞で拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。</br>
    /// <br>                  拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正してください。</br>
    /// <br>UpdateNote : 2011/09/07 王飛３</br>
    /// <br>        	 ・障害報告 #24169</br>
    /// <br>UpdateNote : 王君</br>　　　　　　　　　　　　　　　　　　　　　　　
    /// <br>Date       : 2013/05/02</br>
    /// <br>管理番号   : 10901273-00 2013/06/18配信分</br> 
    /// <br>　         : Redmine#35434の対応</br>
    /// </remarks>
	public class SFCMN09080UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel DefDspCustTtlDay_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit DefDspCustTtlDay_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TNedit DefDspCustClctMnyDay_tNedit;
		private Infragistics.Win.Misc.UltraLabel DefDspCustClctMnyDay_uLabel;
		private Infragistics.Win.Misc.UltraLabel DefDspClctMnyMonthCd_uLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor DefDspClctMnyMonthCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel IniDspPrslOrCorpCd_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor IniDspPrslOrCorpCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor EraNameDispCd1_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor RemCntAutoDspDiv_tComboEditor;
        private TComboEditor MemoMoveDiv_tComboEditor;
        private TComboEditor GoodsNoInpDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero2;
        private UiSetControl uiSetControl1;
        private TComboEditor EraNameDispCd2_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor DefSlTtlBillOutput_tComboEditor;
        private TComboEditor DefDtlBillOutput_tComboEditor;
        private TComboEditor DefTtlBillOutput_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel DtlCalcStckCntDsp_Label;
        private TComboEditor DtlCalcStckCntDsp_tComboEditor;
        private TComboEditor GoodsStockMstBootDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel StockShowType_Lable;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;

		#endregion

		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期表示設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 全体初期表示設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
        public SFCMN09080UA()
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
            this._allDefSetAcs = new AllDefSetAcs();
            //this._prevAllDefSet = null;  // DEL 2008/06/04
            //this._nextData = false;  // DEL 2008/06/04
            this._totalCount = 0;
            this._allDefSetTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            this._secInfoAcs = new SecInfoAcs();    // ADD 2009/04/17

            // ↓ 20061205 18322 d
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // // 陸運事務所名称アクセスクラス
            // this._landTrnsNmAcs = new LandTrnsNmAcs();
            // // 陸運事務所名称格納用
            // this._landTrnsNmBuf = null;
            // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            // ↑ 20061205 18322 d
        }
		#endregion

		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09080UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustTtlDay_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustTtlDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustClctMnyDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DefDspCustClctMnyDay_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspClctMnyMonthCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspClctMnyMonthCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.IniDspPrslOrCorpCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.IniDspPrslOrCorpCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.EraNameDispCd1_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsNoInpDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MemoMoveDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RemCntAutoDspDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.EraNameDispCd2_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.DefTtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DefDtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DefSlTtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.DtlCalcStckCntDsp_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DtlCalcStckCntDsp_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockShowType_Lable = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsStockMstBootDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustTtlDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustClctMnyDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspClctMnyMonthCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IniDspPrslOrCorpCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd1_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNoInpDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMoveDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemCntAutoDspDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd2_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefTtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefSlTtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlCalcStckCntDsp_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsStockMstBootDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(726, 334);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 19;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(595, 334);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 17;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 374);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(886, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(751, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // DefDspCustTtlDay_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.DefDspCustTtlDay_uLabel.Appearance = appearance10;
            this.DefDspCustTtlDay_uLabel.Location = new System.Drawing.Point(16, 99);
            this.DefDspCustTtlDay_uLabel.Name = "DefDspCustTtlDay_uLabel";
            this.DefDspCustTtlDay_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspCustTtlDay_uLabel.TabIndex = 171;
            this.DefDspCustTtlDay_uLabel.Text = "得意先締日";
            // 
            // DefDspCustTtlDay_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.DefDspCustTtlDay_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.DefDspCustTtlDay_tNedit.Appearance = appearance9;
            this.DefDspCustTtlDay_tNedit.AutoSelect = true;
            this.DefDspCustTtlDay_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DefDspCustTtlDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DefDspCustTtlDay_tNedit.DataText = "";
            this.DefDspCustTtlDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DefDspCustTtlDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DefDspCustTtlDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DefDspCustTtlDay_tNedit.Location = new System.Drawing.Point(214, 99);
            this.DefDspCustTtlDay_tNedit.MaxLength = 2;
            this.DefDspCustTtlDay_tNedit.Name = "DefDspCustTtlDay_tNedit";
            this.DefDspCustTtlDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DefDspCustTtlDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustTtlDay_tNedit.TabIndex = 3;
            this.DefDspCustTtlDay_tNedit.Leave += new System.EventHandler(this.Day_Leave);
            // 
            // ultraLabel1
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.Location = new System.Drawing.Point(248, 99);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel1.TabIndex = 173;
            this.ultraLabel1.Text = "日";
            // 
            // ultraLabel2
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance14;
            this.ultraLabel2.Location = new System.Drawing.Point(248, 129);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel2.TabIndex = 176;
            this.ultraLabel2.Text = "日";
            // 
            // DefDspCustClctMnyDay_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            this.DefDspCustClctMnyDay_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.DefDspCustClctMnyDay_tNedit.Appearance = appearance16;
            this.DefDspCustClctMnyDay_tNedit.AutoSelect = true;
            this.DefDspCustClctMnyDay_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DefDspCustClctMnyDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DefDspCustClctMnyDay_tNedit.DataText = "";
            this.DefDspCustClctMnyDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DefDspCustClctMnyDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DefDspCustClctMnyDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DefDspCustClctMnyDay_tNedit.Location = new System.Drawing.Point(214, 129);
            this.DefDspCustClctMnyDay_tNedit.MaxLength = 2;
            this.DefDspCustClctMnyDay_tNedit.Name = "DefDspCustClctMnyDay_tNedit";
            this.DefDspCustClctMnyDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DefDspCustClctMnyDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustClctMnyDay_tNedit.TabIndex = 4;
            this.DefDspCustClctMnyDay_tNedit.Leave += new System.EventHandler(this.Day_Leave);
            // 
            // DefDspCustClctMnyDay_uLabel
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.DefDspCustClctMnyDay_uLabel.Appearance = appearance17;
            this.DefDspCustClctMnyDay_uLabel.Location = new System.Drawing.Point(16, 129);
            this.DefDspCustClctMnyDay_uLabel.Name = "DefDspCustClctMnyDay_uLabel";
            this.DefDspCustClctMnyDay_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspCustClctMnyDay_uLabel.TabIndex = 174;
            this.DefDspCustClctMnyDay_uLabel.Text = "得意先集金日";
            // 
            // DefDspClctMnyMonthCd_uLabel
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.DefDspClctMnyMonthCd_uLabel.Appearance = appearance18;
            this.DefDspClctMnyMonthCd_uLabel.Location = new System.Drawing.Point(16, 159);
            this.DefDspClctMnyMonthCd_uLabel.Name = "DefDspClctMnyMonthCd_uLabel";
            this.DefDspClctMnyMonthCd_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspClctMnyMonthCd_uLabel.TabIndex = 177;
            this.DefDspClctMnyMonthCd_uLabel.Text = "集金月";
            // 
            // DefDspClctMnyMonthCd_tComEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.DefDspClctMnyMonthCd_tComEditor.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefDspClctMnyMonthCd_tComEditor.Appearance = appearance20;
            this.DefDspClctMnyMonthCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefDspClctMnyMonthCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefDspClctMnyMonthCd_tComEditor.ItemAppearance = appearance21;
            this.DefDspClctMnyMonthCd_tComEditor.Location = new System.Drawing.Point(214, 159);
            this.DefDspClctMnyMonthCd_tComEditor.Name = "DefDspClctMnyMonthCd_tComEditor";
            this.DefDspClctMnyMonthCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.DefDspClctMnyMonthCd_tComEditor.TabIndex = 5;
            // 
            // IniDspPrslOrCorpCd_uLabel
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.IniDspPrslOrCorpCd_uLabel.Appearance = appearance55;
            this.IniDspPrslOrCorpCd_uLabel.Location = new System.Drawing.Point(441, 129);
            this.IniDspPrslOrCorpCd_uLabel.Name = "IniDspPrslOrCorpCd_uLabel";
            this.IniDspPrslOrCorpCd_uLabel.Size = new System.Drawing.Size(130, 24);
            this.IniDspPrslOrCorpCd_uLabel.TabIndex = 179;
            this.IniDspPrslOrCorpCd_uLabel.Text = "個人・法人";
            // 
            // IniDspPrslOrCorpCd_tComEditor
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.IniDspPrslOrCorpCd_tComEditor.ActiveAppearance = appearance30;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            this.IniDspPrslOrCorpCd_tComEditor.Appearance = appearance35;
            this.IniDspPrslOrCorpCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.IniDspPrslOrCorpCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IniDspPrslOrCorpCd_tComEditor.ItemAppearance = appearance37;
            this.IniDspPrslOrCorpCd_tComEditor.Location = new System.Drawing.Point(627, 129);
            this.IniDspPrslOrCorpCd_tComEditor.Name = "IniDspPrslOrCorpCd_tComEditor";
            this.IniDspPrslOrCorpCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.IniDspPrslOrCorpCd_tComEditor.TabIndex = 11;
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(192, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "拠点";
            // 
            // SectionName_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance3;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(255, 42);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(175, 24);
            this.SectionName_tEdit.TabIndex = 1;
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
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(437, 42);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // EraNameDispCd1_tComEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.EraNameDispCd1_tComEditor.ActiveAppearance = appearance7;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.EraNameDispCd1_tComEditor.Appearance = appearance11;
            this.EraNameDispCd1_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EraNameDispCd1_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EraNameDispCd1_tComEditor.ItemAppearance = appearance12;
            this.EraNameDispCd1_tComEditor.Location = new System.Drawing.Point(214, 189);
            this.EraNameDispCd1_tComEditor.Name = "EraNameDispCd1_tComEditor";
            this.EraNameDispCd1_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.EraNameDispCd1_tComEditor.TabIndex = 6;
            // 
            // ultraLabel3
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance26;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 189);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(194, 24);
            this.ultraLabel3.TabIndex = 247;
            this.ultraLabel3.Text = "元号表示区分(年式)";
            // 
            // ultraLabel7
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance68;
            this.ultraLabel7.Location = new System.Drawing.Point(441, 99);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel7.TabIndex = 253;
            this.ultraLabel7.Text = "品番入力区分";
            // 
            // ultraLabel12
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance62;
            this.ultraLabel12.Location = new System.Drawing.Point(441, 279);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel12.TabIndex = 259;
            this.ultraLabel12.Text = "残数自動表示区分";
            // 
            // ultraLabel13
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance63;
            this.ultraLabel13.Location = new System.Drawing.Point(441, 249);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel13.TabIndex = 258;
            this.ultraLabel13.Text = "メモ複写区分";
            // 
            // GoodsNoInpDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.GoodsNoInpDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsNoInpDiv_tComboEditor.Appearance = appearance59;
            this.GoodsNoInpDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GoodsNoInpDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsNoInpDiv_tComboEditor.ItemAppearance = appearance60;
            this.GoodsNoInpDiv_tComboEditor.Location = new System.Drawing.Point(627, 99);
            this.GoodsNoInpDiv_tComboEditor.Name = "GoodsNoInpDiv_tComboEditor";
            this.GoodsNoInpDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.GoodsNoInpDiv_tComboEditor.TabIndex = 10;
            // 
            // MemoMoveDiv_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.MemoMoveDiv_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.MemoMoveDiv_tComboEditor.Appearance = appearance44;
            this.MemoMoveDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MemoMoveDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MemoMoveDiv_tComboEditor.ItemAppearance = appearance45;
            this.MemoMoveDiv_tComboEditor.Location = new System.Drawing.Point(627, 249);
            this.MemoMoveDiv_tComboEditor.Name = "MemoMoveDiv_tComboEditor";
            this.MemoMoveDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MemoMoveDiv_tComboEditor.TabIndex = 15;
            // 
            // RemCntAutoDspDiv_tComboEditor
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.RemCntAutoDspDiv_tComboEditor.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            this.RemCntAutoDspDiv_tComboEditor.Appearance = appearance41;
            this.RemCntAutoDspDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RemCntAutoDspDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RemCntAutoDspDiv_tComboEditor.ItemAppearance = appearance42;
            this.RemCntAutoDspDiv_tComboEditor.Location = new System.Drawing.Point(627, 279);
            this.RemCntAutoDspDiv_tComboEditor.Name = "RemCntAutoDspDiv_tComboEditor";
            this.RemCntAutoDspDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.RemCntAutoDspDiv_tComboEditor.TabIndex = 16;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(22, 81);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(825, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(468, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(239, 24);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "※ゼロで共通設定になります";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(595, 334);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 18;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(464, 334);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance6;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(214, 42);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // EraNameDispCd2_tComEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.EraNameDispCd2_tComEditor.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.EraNameDispCd2_tComEditor.Appearance = appearance28;
            this.EraNameDispCd2_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EraNameDispCd2_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EraNameDispCd2_tComEditor.ItemAppearance = appearance29;
            this.EraNameDispCd2_tComEditor.Location = new System.Drawing.Point(214, 219);
            this.EraNameDispCd2_tComEditor.Name = "EraNameDispCd2_tComEditor";
            this.EraNameDispCd2_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.EraNameDispCd2_tComEditor.TabIndex = 7;
            // 
            // ultraLabel4
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance22;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 219);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(194, 24);
            this.ultraLabel4.TabIndex = 264;
            this.ultraLabel4.Text = "元号表示区分(伝票)";
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(464, 334);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 17;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // DefTtlBillOutput_tComboEditor
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.DefTtlBillOutput_tComboEditor.ActiveAppearance = appearance49;
            appearance50.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefTtlBillOutput_tComboEditor.Appearance = appearance50;
            this.DefTtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefTtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefTtlBillOutput_tComboEditor.ItemAppearance = appearance51;
            this.DefTtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 159);
            this.DefTtlBillOutput_tComboEditor.Name = "DefTtlBillOutput_tComboEditor";
            this.DefTtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefTtlBillOutput_tComboEditor.TabIndex = 12;
            // 
            // DefDtlBillOutput_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.DefDtlBillOutput_tComboEditor.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefDtlBillOutput_tComboEditor.Appearance = appearance47;
            this.DefDtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefDtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefDtlBillOutput_tComboEditor.ItemAppearance = appearance48;
            this.DefDtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 189);
            this.DefDtlBillOutput_tComboEditor.Name = "DefDtlBillOutput_tComboEditor";
            this.DefDtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefDtlBillOutput_tComboEditor.TabIndex = 13;
            // 
            // DefSlTtlBillOutput_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.DefSlTtlBillOutput_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefSlTtlBillOutput_tComboEditor.Appearance = appearance24;
            this.DefSlTtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefSlTtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefSlTtlBillOutput_tComboEditor.ItemAppearance = appearance25;
            this.DefSlTtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 219);
            this.DefSlTtlBillOutput_tComboEditor.Name = "DefSlTtlBillOutput_tComboEditor";
            this.DefSlTtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefSlTtlBillOutput_tComboEditor.TabIndex = 14;
            // 
            // ultraLabel5
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance52;
            this.ultraLabel5.Location = new System.Drawing.Point(441, 159);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(159, 24);
            this.ultraLabel5.TabIndex = 268;
            this.ultraLabel5.Text = "合計請求書出力区分";
            // 
            // ultraLabel8
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance53;
            this.ultraLabel8.Location = new System.Drawing.Point(441, 189);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(159, 24);
            this.ultraLabel8.TabIndex = 269;
            this.ultraLabel8.Text = "明細請求書出力区分";
            // 
            // ultraLabel9
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance54;
            this.ultraLabel9.Location = new System.Drawing.Point(441, 219);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(180, 24);
            this.ultraLabel9.TabIndex = 270;
            this.ultraLabel9.Text = "伝票合計請求書出力区分";
            // 
            // DtlCalcStckCntDsp_Label
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.DtlCalcStckCntDsp_Label.Appearance = appearance80;
            this.DtlCalcStckCntDsp_Label.Location = new System.Drawing.Point(16, 249);
            this.DtlCalcStckCntDsp_Label.Name = "DtlCalcStckCntDsp_Label";
            this.DtlCalcStckCntDsp_Label.Size = new System.Drawing.Size(194, 24);
            this.DtlCalcStckCntDsp_Label.TabIndex = 271;
            this.DtlCalcStckCntDsp_Label.Text = "明細算出後在庫数表示区分";
            // 
            // StockShowType_Lable
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.StockShowType_Lable.Appearance = appearance80;
            this.StockShowType_Lable.Location = new System.Drawing.Point(16, 279);
            this.StockShowType_Lable.Name = "StockShowType_Lable";
            this.StockShowType_Lable.Size = new System.Drawing.Size(194, 24);
            this.StockShowType_Lable.TabIndex = 272;
            this.StockShowType_Lable.Text = "商品在庫マスタ起動区分";
            // 
            // DtlCalcStckCntDsp_tComboEditor
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.ForeColor = System.Drawing.Color.Black;
            appearance77.TextVAlignAsString = "Middle";
            this.DtlCalcStckCntDsp_tComboEditor.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.DtlCalcStckCntDsp_tComboEditor.Appearance = appearance78;
            this.DtlCalcStckCntDsp_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DtlCalcStckCntDsp_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DtlCalcStckCntDsp_tComboEditor.ItemAppearance = appearance79;
            this.DtlCalcStckCntDsp_tComboEditor.Location = new System.Drawing.Point(214, 249);
            this.DtlCalcStckCntDsp_tComboEditor.Name = "DtlCalcStckCntDsp_tComboEditor";
            this.DtlCalcStckCntDsp_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DtlCalcStckCntDsp_tComboEditor.TabIndex = 8;
            // 
            // GoodsStockMstBootDiv_tComboEditor
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.ForeColor = System.Drawing.Color.Black;
            appearance77.TextVAlignAsString = "Middle";
            this.GoodsStockMstBootDiv_tComboEditor.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsStockMstBootDiv_tComboEditor.Appearance = appearance78;
            this.GoodsStockMstBootDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GoodsStockMstBootDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsStockMstBootDiv_tComboEditor.ItemAppearance = appearance79;
            this.GoodsStockMstBootDiv_tComboEditor.Location = new System.Drawing.Point(214, 279);
            this.GoodsStockMstBootDiv_tComboEditor.Name = "GoodsStockMstBootDiv_tComboEditor";
            this.GoodsStockMstBootDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.GoodsStockMstBootDiv_tComboEditor.TabIndex = 9;
            // 
            // SFCMN09080UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(886, 397);
            this.Controls.Add(this.GoodsStockMstBootDiv_tComboEditor);
            this.Controls.Add(this.StockShowType_Lable);
            this.Controls.Add(this.DtlCalcStckCntDsp_tComboEditor);
            this.Controls.Add(this.DtlCalcStckCntDsp_Label);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.DefSlTtlBillOutput_tComboEditor);
            this.Controls.Add(this.DefDtlBillOutput_tComboEditor);
            this.Controls.Add(this.DefTtlBillOutput_tComboEditor);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.EraNameDispCd2_tComEditor);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.RemCntAutoDspDiv_tComboEditor);
            this.Controls.Add(this.MemoMoveDiv_tComboEditor);
            this.Controls.Add(this.GoodsNoInpDiv_tComboEditor);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.EraNameDispCd1_tComEditor);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.IniDspPrslOrCorpCd_tComEditor);
            this.Controls.Add(this.IniDspPrslOrCorpCd_uLabel);
            this.Controls.Add(this.DefDspClctMnyMonthCd_tComEditor);
            this.Controls.Add(this.DefDspClctMnyMonthCd_uLabel);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.DefDspCustClctMnyDay_tNedit);
            this.Controls.Add(this.DefDspCustClctMnyDay_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.DefDspCustTtlDay_tNedit);
            this.Controls.Add(this.DefDspCustTtlDay_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09080UA";
            this.Text = "全体初期表示設定";
            this.Load += new System.EventHandler(this.SFCMN09080UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09080UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09080UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustTtlDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustClctMnyDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspClctMnyMonthCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IniDspPrslOrCorpCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd1_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNoInpDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMoveDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemCntAutoDspDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd2_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefTtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefSlTtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlCalcStckCntDsp_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsStockMstBootDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region -- Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
		private AllDefSetAcs _allDefSetAcs;
        //private AllDefSet _prevAllDefSet;  // DEL 2008/06/04
        //private bool _nextData;  // DEL 2008/06/04
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _allDefSetTable;

        private SecInfoAcs _secInfoAcs;     // ADD 2009/04/17

        // ↓ 20070207 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070207 18322 a

		// 保存比較用Clone
		private AllDefSet _allDefSetClone;

        // ↓ 20061205 18322 d
		//// 変更フラグ
		//private bool _changeFlg = false;
        // ↑ 20061205 18322 d

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE                          = "削除日";  // ADD 2008/06/04
		private const string VIEW_SECTION_CODE_TITLE	          = "拠点コード";
		private const string VIEW_SECTION_NAME_TITLE              = "拠点名称";
        // ↓ 20061205 18322 d
		//private const string VIEW_DISTRICT_CODE_TITLE             = "管区コード";
        //private const string VIEW_DISTRICT_NAME_TITLE = "陸事管区";
        //private const string VIEW_DEF_DISP_ADDR_CD1_TITLE = "初期表示住所コード1";
		//private const string VIEW_DEF_DISP_ADDR_CD2_TITLE         = "初期表示住所コード2";
		//private const string VIEW_DEF_DISP_ADDR_CD3_TITLE         = "初期表示住所コード3";
		//private const string VIEW_DEF_DISP_ADDRESS_TITLE          = "初期表示住所";
        //private const string VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE = "88No.自賠責算定区分";
        //private const string VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE = "88No.自賠責算定";
        // ↑ 20061205 18322 d

        // 2007.03.05 modified by T-Kidate
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "得意先コード自動発番区分";
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "得意先コード自動発番";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE   = "得意先削除チェック区分";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE   = "得意先削除チェック";
        //private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE      = "得意先締日";
        //private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "得意先集金日";
        //private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE = "集金月区分";
        //private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE = "集金月";
        //private const string VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE   = "個人･法人区分";
        //private const string VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE   = "個人･法人";
        //private const string VIEW_INIT_DSP_DM_DIV_CD_TITLE        = "ＤＭ区分";
        //private const string VIEW_INIT_DSP_DM_DIV_NM_TITLE        = "ＤＭ";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE   = "請求書出力区分";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE   = "請求書出力";
        // 2007.03.28 DANJO CHG START
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "顧客コード自動発番区分";
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "顧客コード自動発番";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE = "得意先削除チェック区分";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE = "得意先削除チェック";
        //private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE = "顧客締日";
        //private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "顧客集金日";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "得意先コード自動発番区分";
        private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "得意先コード自動発番";
        private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE   = "得意先削除チェック区分";
        private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE   = "得意先削除チェック";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE      = "得意先締日";
        private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "得意先集金日";
        // 2007.03.28 DANJO CHG END
        private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE = "集金月区分";
        private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE = "集金月";
        private const string VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE = "個人･法人区分";
        private const string VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE = "個人･法人";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_INIT_DSP_DM_DIV_CD_TITLE = "ＤＭ区分";
        private const string VIEW_INIT_DSP_DM_DIV_NM_TITLE = "ＤＭ";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE = "請求書出力区分";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE = "請求書出力";
        // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_MEMBER_INFO_DISP_CD_TITLE = "会員情報管理区分";
        private const string VIEW_MEMBER_INFO_DISP_NM_TITLE = "会員情報管理";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // ↓ 20061205 18322 d
		//private const string VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE  = "車両確定選択方式";
        // ↓ 20061205 18322 d
        //private const string NEWFLG_TITLE = "新規データフラグ";  // DEL 2008/06/09
		private const string VIEW_GUID_KEY_TITLE		          = "Guid";

        /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
        private const string VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE = "総額表示方法区分";
        private const string VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE = "総額表示方法";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
           --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
        private const string VIEW_ERA_NAME_DISP_CD1_TITLE = "元号表示区分(年式)";
        private const string VIEW_ERA_NAME_DISP_CD2_TITLE = "元号表示区分(伝票)";
        //private const string VIEW_ERA_NAME_DISP_CD3_TITLE = "元号表示区分(その他)"; // DEL 2009/01/30

        private const string VIEW_GOODS_NO_INP_DIV_TITLE = "品番入力区分";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_JAN_CODE_INP_DIV_TITLE = "ＪＡＮコード入力区分";
        private const string VIEW_UN_CST_LINK_DIV_TITLE = "原単価連動区分";
        private const string VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE = "消費税自動補正区分";
        private const string VIEW_REMAIN_CNT_MNG_DIV_TITLE = "残数管理区分";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        private const string VIEW_MEMO_MOVE_DIV_TITLE = "メモ複写区分";
        private const string VIEW_REM_CNT_AUTO_DSP_DIV_TITLE = "残数自動表示区分";
        /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
        private const string VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE = "総額表示掛率適用区分";
           --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
        // ↓ 20061205 18322 d
        //// 陸運事務所名称アクセスクラス
        //private LandTrnsNmAcs _landTrnsNmAcs;
        //// 陸運事務所名称格納用
        //private ArrayList _landTrnsNmBuf;
        //
        //private const string VIEW_LAND_TRANS_BRANCH_CD_TITLE      = "陸運事務所コード";
        //private const string VIEW_LAND_TRANS_BRANCH_NM_TITLE = "陸運事務所名称";
        // ↑ 20061205 18322 d
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

        // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
        private const string VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE = "合計請求書出力区分";
        private const string VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE = "合計請求書出力";
        private const string VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE = "明細請求書出力区分";
        private const string VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE = "明細請求書出力";
        private const string VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE = "伝票合計請求書出力区分";
        private const string VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE = "伝票合計請求書出力";
        // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

		// View用Gridに表示させるテーブル名
		private const string VIEW_TABLE = "VIEW_TABLE";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string ALL_SECTIONCODE = "00";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        //ADD  START zhouyu 2011/07/19------------------------------------------------------------>>>>>
        private const string UPDATE_AFTERCODE = "検索後反映";
        private const string UPDATE_AFTERDTL = "行移動時反映";
        private const string VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE = "明細算出後在庫数表示区分";
        //ADD  END zhouyu 2011/07/19--------------------------------------------------------------<<<<<

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        private const string STOCKMSTBOOTDIV1 = "商品在庫マスタ";
        private const string STOCKMSTBOOTDIV2 = "商品在庫マスタⅡ";
        private const string VIEW_DEF_STOCKMSTBOOT_TITLE = "商品在庫マスタ起動区分";
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

        private bool isError = false; // ADD 2011/09/07

		#endregion

		#region -- Main --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09080UA());
		}
		# endregion

		#region -- Properties --
		/*----------------------------------------------------------------------------------*/
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{ 
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/*----------------------------------------------------------------------------------*/
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

		/*----------------------------------------------------------------------------------*/
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

		/*----------------------------------------------------------------------------------*/
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{ 
				return this._defaultAutoFillToColumn;
			}
		}

		/*----------------------------------------------------------------------------------*/
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
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
		///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList allDefSets = null;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._allDefSetAcs.SearchAll(out allDefSets, this._enterpriseCode);
				this._totalCount = allDefSets.Count;
			}
			else
			{
				status = this._allDefSetAcs.SearchSpecificationAll(
					out allDefSets,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevAllDefSet);
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._allDefSetTable.Clear();

            status = this._allDefSetAcs.SearchAll(out allDefSets, this._enterpriseCode);
            this._totalCount = allDefSets.Count;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
					if( allDefSets.Count > 0 ) {
						// 最終の全体初期表示設定オブジェクトを退避する
						this._prevAllDefSet = ((AllDefSet)allDefSets[allDefSets.Count - 1]).Clone();
					}
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                    
                    int index = 0;

					foreach(AllDefSet allDefSet in allDefSets)
					{
					　　AllDefSetToDataSet(allDefSet.Clone(), index);
						++index;
					}
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
						"SFCMN09080U",							// アセンブリID
						"全体初期表示設定",              　　     // プログラム名称
						"Search",                               // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._allDefSetAcs,					    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

					break;
				}
			}
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 実装なし
            return 9;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			int dummy = 0;
			ArrayList allDefSets = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount = this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._allDefSetAcs.SearchSpecificationAll(
				out allDefSets,
				out dummy,
				out this._nextData,
				this._enterpriseCode,
				readCount,
				this._prevAllDefSet);

			switch (status) 
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( allDefSets.Count > 0 ) {
						// 最終の全体初期表示設定クラスを退避する
						this._prevAllDefSet = ((AllDefSet)allDefSets[allDefSets.Count - 1]).Clone();
					}
					int index = 0;
					foreach(AllDefSet allDefSet in allDefSets)
					{
						if (this._allDefSetTable.ContainsKey(allDefSet.FileHeaderGuid) == false)
						{  
							index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count;
							AllDefSetToDataSet(allDefSet.Clone(), index);
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
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09080U",							// アセンブリID
						"全体初期表示設定", 　　                  // プログラム名称
						"SearchNext",                           // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._allDefSetAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

					break;
				}
			}
			return status;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 選択中のデータを削除します。(未実装)</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Delete()
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            if (allDefSet.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "SFCMN09080U",							// アセンブリID
                        "全社共通データは削除できません。",	    // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                return (0);
            }
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

            int status;

            // 全体初期表示設定情報論理削除処理
            status = this._allDefSetAcs.LogicalDelete(ref allDefSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "SFCMN09080U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._allDefSetAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 全体初期表示設定情報クラスデータセット展開処理
            AllDefSetToDataSet(allDefSet.Clone(), this.DataIndex);

            return status;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 印刷処理を実行します。(未実装)</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
        /// <br>Update Note : 王君</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>管理番号    : 10901273-00  2013/06/18配信分</br>
        /// <br>            : Redmine#35434の対応</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            
            // ↓ 20061205 18322 d
            //appearanceTable.Add(VIEW_DISTRICT_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			//appearanceTable.Add(VIEW_DISTRICT_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD1_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD2_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD3_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDRESS_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //appearanceTable.Add(VIEW_LAND_TRANS_BRANCH_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //appearanceTable.Add(VIEW_LAND_TRANS_BRANCH_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//appearanceTable.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // ↑ 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            appearanceTable.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(VIEW_DEF_DSP_CUST_TTL_DAY_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"#0\\日",Color.Black));
            appearanceTable.Add(VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#0\\日", Color.Black));
			appearanceTable.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
            appearanceTable.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // ----------------------------------------------------------------
            // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
			//appearanceTable.Add(VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // --- DEL  大矢睦美  2010/01/18 ----------<<<<<
			// ↓ 20061205 18322 d
            //appearanceTable.Add(VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            appearanceTable.Add(VIEW_MEMBER_INFO_DISP_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2007.03.28 DANJO CHG START
            appearanceTable.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            //appearanceTable.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));
            // 2007.03.28 DANJO CHG END
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            appearanceTable.Add(VIEW_ERA_NAME_DISP_CD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ERA_NAME_DISP_CD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(VIEW_ERA_NAME_DISP_CD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); // DEL 2009/01/30
            appearanceTable.Add(VIEW_GOODS_NO_INP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_JAN_CODE_INP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_UN_CST_LINK_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_REMAIN_CNT_MNG_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(VIEW_MEMO_MOVE_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_REM_CNT_AUTO_DSP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

            //appearanceTable.Add(NEWFLG_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));  // DEL 2008/06/09
			appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            appearanceTable.Add(VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU  2011/07/19
            //仕入・出荷後数表示区分
            appearanceTable.Add(VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //ADD END ZHOUYU  2011/07/19
            appearanceTable.Add(VIEW_DEF_STOCKMSTBOOT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); // 商品在庫マスタ表示区分　// ADD 王君　2013/05/02　Redmine#35434
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private void ScreenReconstruction()
		{		
			if (this.DataIndex < 0)
			{
				// 登録モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible                = true;
				this.Cancel_Button.Visible            = true;
                // ↓ 20061205 18322 d
				//this.DefDispAddrGuide_uButton.Visible = true;
                // ↑ 20061205 18322 d

				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//				this.DistrictCode_tComEditor.NullText = "";
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				AllDefSet allDefSet = new AllDefSet();
				allDefSet = (AllDefSet)this._allDefSetTable[guid];
				string NewFlg = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][NEWFLG_TITLE].ToString();

				if(Convert.ToInt32(NewFlg) == 1)
				{
					allDefSet.SectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_SECTION_CODE_TITLE];
				}

                // ↓ 20061205 18322 d
				//this.DistrictCode_tComEditor.Focus();
                // ↑ 20061205 18322 d

				// クローンを作成
				this._allDefSetClone = allDefSet.Clone();
				AllDefSetToScreen(allDefSet);

				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;

				if(Convert.ToInt32(NewFlg) == 1)
				{
					// 登録モード
					this.Mode_Label.Text = INSERT_MODE;

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//					this.DistrictCode_tComEditor.NullText = "";
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
				}
				else
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible                = true;
					this.Cancel_Button.Visible            = true;

                    // ↓ 20061205 18322 d
					//this.DefDispAddrGuide_uButton.Visible = true;
                    // ↑ 20061205 18322 d

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//					this.DistrictCode_tComEditor.NullText = "未登録";
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
				}
			}
		}
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                AllDefSet allDefSet = new AllDefSet();
                //クローン作成
                this._allDefSetClone = allDefSet.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToAllDefSet(ref this._allDefSetClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCodeAllowZero2.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

                // 全体初期表示情報クラス画面展開処理
                AllDefSetToScreen(allDefSet);

                if (allDefSet.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.DefDspCustTtlDay_tNedit.Focus();

                    // クローン作成
                    this._allDefSetClone = allDefSet.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToAllDefSet(ref this._allDefSetClone);
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: 王君</br>　　　　　　　　　　　　　　　　　　　　　　　
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分　 </br> 
        /// <br>　         : Redmine#35434の対応</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;     // ADD 2009/04/17
                    this.SectionName_tEdit.Enabled = false;
                    this.DefDspCustTtlDay_tNedit.Enabled = true;
                    this.DefDspCustClctMnyDay_tNedit.Enabled = true;
                    this.DefDspClctMnyMonthCd_tComEditor.Enabled = true;
                    this.EraNameDispCd1_tComEditor.Enabled = true;
                    this.EraNameDispCd2_tComEditor.Enabled = true;
                    //this.EraNameDispCd3_tComEditor.Enabled = true; // DEL 2009/01/30
                    this.GoodsNoInpDiv_tComboEditor.Enabled = true;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TotalAmoDispWayCd_tComEditor.Enabled = true;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    this.IniDspPrslOrCorpCd_tComEditor.Enabled = true;
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.InitDspDmDiv_tComEditor.Enabled = true;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
                    //this.DefDspBillPrtDivCd_tComEditor.Enabled = true;
                    // --- DEL  大矢睦美  2010/01/18 ----------<<<<<
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.CnsTaxAutoCorrDiv_tComboEditor.Enabled = true;
                    this.RemainCntMngDiv_tComboEditor.Enabled = true;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    this.MemoMoveDiv_tComboEditor.Enabled = true;
                    this.RemCntAutoDspDiv_tComboEditor.Enabled = true;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TtlAmntDspRateDivCd_tComboEditor.Enabled = true;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
                    this.DefTtlBillOutput_tComboEditor.Enabled = true;
                    this.DefDtlBillOutput_tComboEditor.Enabled = true;
                    this.DefSlTtlBillOutput_tComboEditor.Enabled = true;
                    // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

                    if (mode == INSERT_MODE)
                    {
                        // 新規モード
                        this.tEdit_SectionCodeAllowZero2.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                    }
                    else
                    {
                        // 更新モード
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                    }
                    this.DtlCalcStckCntDsp_tComboEditor.Enabled = true;//ADD 2011/09/07
                    this.GoodsStockMstBootDiv_tComboEditor.Enabled = true; // ADD 王君 2013/05/02 Redmine#35434

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Renewal_Button.Visible = false;    // ADD 2009/04/17
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SectionName_tEdit.Enabled = false;
                    this.DefDspCustTtlDay_tNedit.Enabled = false;
                    this.DefDspCustClctMnyDay_tNedit.Enabled = false;
                    this.DefDspClctMnyMonthCd_tComEditor.Enabled = false;
                    this.EraNameDispCd1_tComEditor.Enabled = false;
                    this.EraNameDispCd2_tComEditor.Enabled = false;
                    //this.EraNameDispCd3_tComEditor.Enabled = false; // DEL 2009/01/30
                    this.GoodsNoInpDiv_tComboEditor.Enabled = false;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TotalAmoDispWayCd_tComEditor.Enabled = false;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    this.IniDspPrslOrCorpCd_tComEditor.Enabled = false;
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.InitDspDmDiv_tComEditor.Enabled = false;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
                    //this.DefDspBillPrtDivCd_tComEditor.Enabled = false;
                    // --- DEL  大矢睦美  2010/01/18 ----------<<<<<
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.CnsTaxAutoCorrDiv_tComboEditor.Enabled = false;
                    this.RemainCntMngDiv_tComboEditor.Enabled = false;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    this.MemoMoveDiv_tComboEditor.Enabled = false;
                    this.RemCntAutoDspDiv_tComboEditor.Enabled = false;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TtlAmntDspRateDivCd_tComboEditor.Enabled = false;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
                    this.DefTtlBillOutput_tComboEditor.Enabled = false;
                    this.DefDtlBillOutput_tComboEditor.Enabled = false;
                    this.DefSlTtlBillOutput_tComboEditor.Enabled = false;
                　　// --- ADD  大矢睦美  2010/01/18 ----------<<<<<
                    this.DtlCalcStckCntDsp_tComboEditor.Enabled = false;//ADD 2011/09/07
                    this.GoodsStockMstBootDiv_tComboEditor.Enabled = false; // ADD 王君 2013/05/02 Redmine#35434
                    break;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期表示設定オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="allDefSet">全体初期表示設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 全体初期表示設定クラスをデータセットに格納します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void AllDefSetToDataSet(AllDefSet allDefSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (allDefSet.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = allDefSet.UpdateDateTimeJpInFormal;
            }

			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = allDefSet.SectionCode;

            string sectionName = GetSectionName(allDefSet.SectionCode);
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if(sectionName=="")
            {
                sectionName = "全社共通";
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // ↓ 20061205 18322 d
            //// 管区コード
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISTRICT_CODE_TITLE] = allDefSet.DistrictCode;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISTRICT_NAME_TITLE] = allDefSet.DistrictName;
            //
			//// 初期表示住所
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD1_TITLE] = allDefSet.DefDispAddrCd1;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD2_TITLE] = allDefSet.DefDispAddrCd2;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD3_TITLE] = allDefSet.DefDispAddrCd3;
            //
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			// this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD4_TITLE] = allDefSet.DefDispAddrCd4;
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDRESS_TITLE]  = allDefSet.DefDispAddress;
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //string LandTransBranchNm = "";
            //this.GetLandTransBranchName(1, allDefSet.LandTransBranchCd, out LandTransBranchNm);
            //
            // // 陸運事務所番号
            //if (allDefSet.LandTransBranchCd != 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_CD_TITLE] = allDefSet.LandTransBranchCd;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_CD_TITLE] = DBNull.Value;
            //}
            //
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_NM_TITLE] = LandTransBranchNm;
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			// // 88No.自賠責算定
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE] = allDefSet.No88AutoLiaCalcDiv;
			//switch(allDefSet.No88AutoLiaCalcDiv)
			//{
			//	case 0:
			//		this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE] = "無";
			//		break;
            //
			//	case 1:
			//		this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE] = "有";
			//		break;			
			//}
            // ↑ 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// 総額表示方法
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE] = allDefSet.TotalAmountDispWayCd;
			switch(allDefSet.TotalAmountDispWayCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE] = "総額表示しない（税抜き）";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE] = "総額表示する（税込み）";
					break;			
			}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 顧客コード自動発番
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE] = allDefSet.CustCdAutoNumbering;
			switch(allDefSet.CustCdAutoNumbering)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE] = "手入力可";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE] = "手入力不可";
					break;			
			}

			// 得意先削除チェック
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE] = allDefSet.CustomerDelChkDivCd;
			switch(allDefSet.CustomerDelChkDivCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE] = "未引当伝票存在時は削除不可";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE] = "未引当伝票存在時でも削除可能";
					break;			
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // 得意先締日
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CUST_TTL_DAY_TITLE] = allDefSet.DefDspCustTtlDay;

			// 得意先集金日
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE] = allDefSet.DefDspCustClctMnyDay;

			// 集金月
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE] = allDefSet.DefDspClctMnyMonthCd;
			switch(allDefSet.DefDspClctMnyMonthCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "当月";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "翌月";
					break;
	
				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "翌々月";
					break;

                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "翌々々";
                    break;
			}

			// 個人･法人
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE] = allDefSet.IniDspPrslOrCorpCd;
			switch(allDefSet.IniDspPrslOrCorpCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "個人";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "法人";
					break;

				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "大口法人";
					break;

				case 3:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "業者";
					break;

				case 4:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "社員";
					break;

				case 5:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "ＡＡ";
					break;
			}

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// ＤＭ
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_CD_TITLE] = allDefSet.InitDspDmDiv;
			switch(allDefSet.InitDspDmDiv)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_NM_TITLE] = "ＤＭ出力する";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_NM_TITLE] = "ＤＭ出力しない";
					break;
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            // 請求書出力
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE] = allDefSet.DefDspBillPrtDivCd;
            //switch(allDefSet.DefDspBillPrtDivCd)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE] = "請求書出力する";
            //        break;

            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE] = "請求書出力しない";
            //        break;
            //}
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

            // ↓ 20061205 18322 d
			// // 車両確定選択方式
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE] = allDefSet.CarFixSelectMethodNm;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // 会員情報管理区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_CD_TITLE] = allDefSet.MemberInfoDispCd;
            switch (allDefSet.MemberInfoDispCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_NM_TITLE] = "会員情報管理する";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_NM_TITLE] = "会員情報管理しない";
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            switch (allDefSet.EraNameDispCd1)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD1_TITLE] = "西暦";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD1_TITLE] = "和暦";
                    break;
            }
            switch (allDefSet.EraNameDispCd2)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD2_TITLE] = "西暦";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD2_TITLE] = "和暦";
                    break;
            }
            // --- DEL 2009/01/30 -------------------------------->>>>>
            //switch (allDefSet.EraNameDispCd3)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD3_TITLE] = "西暦";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD3_TITLE] = "和暦";
            //        break;
            //}
            // --- DEL 2009/01/30 --------------------------------<<<<<
            switch (allDefSet.GoodsNoInpDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODS_NO_INP_DIV_TITLE] = "任意";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODS_NO_INP_DIV_TITLE] = "必須";
                    break;
            }
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (allDefSet.CnsTaxAutoCorrDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE] = "自動";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE] = "手動";
                    break;
            }
            switch (allDefSet.RemainCntMngDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REMAIN_CNT_MNG_DIV_TITLE] = "する";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REMAIN_CNT_MNG_DIV_TITLE] = "しない";
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            switch (allDefSet.MemoMoveDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "する";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "社外メモのみ";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "しない";
                    break;
            }
            switch (allDefSet.RemCntAutoDspDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "出荷残､入荷残のみ";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "受発注残のみ";
                    break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "出荷残､入荷残→受発注残";
                    break;
                case 4:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "受発注残→出荷残､入荷残";
                    break;
            }

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            switch (allDefSet.TtlAmntDspRateDivCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE] = "税込単価";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE] = "税抜単価";
                    break;
            }
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima
            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            //合計請求書出力
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefTtlBillOutput;
            switch (allDefSet.DefTtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE] = "出力する";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE] = "出力しない";
                    break;
            }

            //明細請求書出力
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefDtlBillOutput;
            switch (allDefSet.DefDtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE] = "出力する";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE] = "出力しない";
                    break;
            }

            //伝票合計請求書
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefSlTtlBillOutput;
            switch (allDefSet.DefSlTtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE] = "出力する";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE] = "出力しない";
                    break;
            }
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU  2011/07/19
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = allDefSet.DtlCalcStckCntDsp;
            switch (allDefSet.DtlCalcStckCntDsp)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = UPDATE_AFTERCODE;
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = UPDATE_AFTERDTL;
                    break;
            }
            //ADD END ZHOUYU 2011/07/19
            // ----- ADD 王君　2013/05/02　Redmine#35434 ----->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = allDefSet.GoodsStockMSTBootDiv;
            switch (allDefSet.GoodsStockMSTBootDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = STOCKMSTBOOTDIV1;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = STOCKMSTBOOTDIV2;
                    break;
            }
            // ----- ADD 王君　2013/05/02　Redmine#35434 -----<<<<<

            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][NEWFLG_TITLE] = 0;  // DEL 2008/06/09
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = allDefSet.FileHeaderGuid;
			
			if (this._allDefSetTable.ContainsKey(allDefSet.FileHeaderGuid) == true)
			{
				this._allDefSetTable.Remove(allDefSet.FileHeaderGuid);
			}
			this._allDefSetTable.Add(allDefSet.FileHeaderGuid, allDefSet);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable allDefSetTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            
            allDefSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));

            // ↓ 20061205 18322 d
			//allDefSetTable.Columns.Add(VIEW_DISTRICT_CODE_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DISTRICT_NAME_TITLE, typeof(string));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD1_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD2_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD3_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDRESS_TITLE, typeof(string));
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //allDefSetTable.Columns.Add(VIEW_LAND_TRANS_BRANCH_CD_TITLE, typeof(int));
            //allDefSetTable.Columns.Add(VIEW_LAND_TRANS_BRANCH_NM_TITLE, typeof(string));
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//allDefSetTable.Columns.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE, typeof(string));
            // ↑ 20061205 18322 d

            // 2007.03.28 DANJO MOV START
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            //allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, typeof(int));
            //allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, typeof(string));
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
            // 2007.03.28 DANJO MOV END

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			allDefSetTable.Columns.Add(VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            allDefSetTable.Columns.Add(VIEW_DEF_DSP_CUST_TTL_DAY_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE, typeof(string));

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // 2007.03.28 DANJO MOV START
            allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, typeof(string));
            // 2007.03.28 DANJO MOV END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            allDefSetTable.Columns.Add(VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE, typeof(string));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_INIT_DSP_DM_DIV_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- UPD  大矢睦美  2010/01/18 ---------->>>>>
            //allDefSetTable.Columns.Add(VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            // --- UPD  大矢睦美  2010/01/18 ----------<<<<<
            // ↓ 20061205 18322 d
			//allDefSetTable.Columns.Add(VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE, typeof(string));
            // ↑ 20061205 18322 d
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSetTable.Columns.Add(VIEW_MEMBER_INFO_DISP_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD1_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD2_TITLE, typeof(string));
            //allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD3_TITLE, typeof(string)); // DEL 2009/01/30

            allDefSetTable.Columns.Add(VIEW_GOODS_NO_INP_DIV_TITLE, typeof(string));
            
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_JAN_CODE_INP_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_UN_CST_LINK_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_REMAIN_CNT_MNG_DIV_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            allDefSetTable.Columns.Add(VIEW_MEMO_MOVE_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_REM_CNT_AUTO_DSP_DIV_TITLE, typeof(string));
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE, typeof(string));
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

            

            //allDefSetTable.Columns.Add(NEWFLG_TITLE, typeof(short));  // DEL 2008/06/09
			allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));
            //ADD START ZHOUYU 2011/07/19
            //仕入・出荷後数表示区分
            allDefSetTable.Columns.Add(VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE, typeof(string));
            //ADD END ZHOUYU 2011/07/19

            allDefSetTable.Columns.Add(VIEW_DEF_STOCKMSTBOOT_TITLE, typeof(string)); //ADD 王君　2013/05/02　Redmine#35434
			this.Bind_DataSet.Tables.Add(allDefSetTable);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // ↓ 20061205 18322 d
			// // 管区
			//DistrictCode_tComEditor.Items.Clear();
			//SetAreaKind(this.DistrictCode_tComEditor);
			//this.DistrictCode_tComEditor.MaxDropDownItems = DistrictCode_tComEditor.Items.Count;
            //
			// // 88No.自賠責算定
			//No88AutoLiaCalcDiv_tComEditor.Items.Clear();
			//No88AutoLiaCalcDiv_tComEditor.Items.Add(0, "無");
			//No88AutoLiaCalcDiv_tComEditor.Items.Add(1, "有");
			//No88AutoLiaCalcDiv_tComEditor.MaxDropDownItems = No88AutoLiaCalcDiv_tComEditor.Items.Count;
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// 総額表示方法
			TotalAmoDispWayCd_tComEditor.Items.Clear();
			TotalAmoDispWayCd_tComEditor.Items.Add(0, "総額表示しない（税抜き）");
			TotalAmoDispWayCd_tComEditor.Items.Add(1, "総額表示する（税込み）");
			TotalAmoDispWayCd_tComEditor.MaxDropDownItems = TotalAmoDispWayCd_tComEditor.Items.Count;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 得意先コード自動発番
			CustCdAutoNumbering_tComEditor.Items.Clear();
			CustCdAutoNumbering_tComEditor.Items.Add(0, "手入力可");
			CustCdAutoNumbering_tComEditor.Items.Add(1, "手入力不可");
			CustCdAutoNumbering_tComEditor.MaxDropDownItems = CustCdAutoNumbering_tComEditor.Items.Count;

			// 得意先削除チェック
			CustomerDelChkDivCd_tComEditor.Items.Clear();
			CustomerDelChkDivCd_tComEditor.Items.Add(0, "未引当伝票存在時は削除不可");
			CustomerDelChkDivCd_tComEditor.Items.Add(1, "未引当伝票存在時でも削除可能");
			CustomerDelChkDivCd_tComEditor.MaxDropDownItems = CustomerDelChkDivCd_tComEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // 集金月
			DefDspClctMnyMonthCd_tComEditor.Items.Clear();
			DefDspClctMnyMonthCd_tComEditor.Items.Add(0, "当月");
			DefDspClctMnyMonthCd_tComEditor.Items.Add(1, "翌月");
            DefDspClctMnyMonthCd_tComEditor.Items.Add(2, "翌々月");
            DefDspClctMnyMonthCd_tComEditor.Items.Add(3, "翌々々");
			DefDspClctMnyMonthCd_tComEditor.MaxDropDownItems = DefDspClctMnyMonthCd_tComEditor.Items.Count;

			// 個人･法人
			IniDspPrslOrCorpCd_tComEditor.Items.Clear();
			IniDspPrslOrCorpCd_tComEditor.Items.Add(0, "個人");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(1, "法人");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(2, "大口法人");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(3, "業者");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(4, "社員");
            IniDspPrslOrCorpCd_tComEditor.Items.Add(5, "ＡＡ");
			IniDspPrslOrCorpCd_tComEditor.MaxDropDownItems = IniDspPrslOrCorpCd_tComEditor.Items.Count;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// ＤＭ
			InitDspDmDiv_tComEditor.Items.Clear();
			InitDspDmDiv_tComEditor.Items.Add(0, "ＤＭ出力する");
			InitDspDmDiv_tComEditor.Items.Add(1, "ＤＭ出力しない");
			InitDspDmDiv_tComEditor.MaxDropDownItems = InitDspDmDiv_tComEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
			// 請求書出力
			//DefDspBillPrtDivCd_tComEditor.Items.Clear();
			//DefDspBillPrtDivCd_tComEditor.Items.Add(0, "請求書出力する");
			//DefDspBillPrtDivCd_tComEditor.Items.Add(1, "請求書出力しない");
			//DefDspBillPrtDivCd_tComEditor.MaxDropDownItems = DefDspBillPrtDivCd_tComEditor.Items.Count;
            // --- DEL  大矢睦美  2010/01/18 ----------<<<<<

            // ↓ 20061205 18322 d
			// // 車両確定選択方式
			//CarFixSelectMethod_tComEditor.Items.Clear();
			//AllDefSet allDefSet = new AllDefSet();
			//foreach (int ix in AllDefSet.CarFixSelectMethods)
			//{
			//	CarFixSelectMethod_tComEditor.Items.Add(ix, allDefSet.GetCarFixSelectMethodNm(ix));
			//}
			//CarFixSelectMethod_tComEditor.MaxDropDownItems = CarFixSelectMethod_tComEditor.Items.Count;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            MemberInfoDispCd_tComboEditor.Items.Clear();
            MemberInfoDispCd_tComboEditor.Items.Add(0, "会員情報管理する");
            MemberInfoDispCd_tComboEditor.Items.Add(1, "会員情報管理しない");
            MemberInfoDispCd_tComboEditor.MaxDropDownItems = MemberInfoDispCd_tComboEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // 元号表示区分１
            EraNameDispCd1_tComEditor.Items.Clear();
            EraNameDispCd1_tComEditor.Items.Add(0, "西暦");
            EraNameDispCd1_tComEditor.Items.Add(1, "和暦");
            EraNameDispCd1_tComEditor.MaxDropDownItems = EraNameDispCd1_tComEditor.Items.Count;
            // 元号表示区分２
            EraNameDispCd2_tComEditor.Items.Clear();
            EraNameDispCd2_tComEditor.Items.Add(0, "西暦");
            EraNameDispCd2_tComEditor.Items.Add(1, "和暦");
            EraNameDispCd2_tComEditor.MaxDropDownItems = EraNameDispCd2_tComEditor.Items.Count;
            // 元号表示区分３
            // --- DEL 2009/01/30 -------------------------------->>>>>
            //EraNameDispCd3_tComEditor.Items.Clear();
            //EraNameDispCd3_tComEditor.Items.Add(0, "西暦");
            //EraNameDispCd3_tComEditor.Items.Add(1, "和暦");
            //EraNameDispCd3_tComEditor.MaxDropDownItems = EraNameDispCd3_tComEditor.Items.Count;
            // --- DEL 2009/01/30 --------------------------------<<<<<
            // 品番入力区分
            GoodsNoInpDiv_tComboEditor.Items.Clear();
            GoodsNoInpDiv_tComboEditor.Items.Add(0, "任意");
            GoodsNoInpDiv_tComboEditor.Items.Add(1, "必須");
            GoodsNoInpDiv_tComboEditor.MaxDropDownItems = GoodsNoInpDiv_tComboEditor.Items.Count;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // 消費税自動補正区分
            CnsTaxAutoCorrDiv_tComboEditor.Items.Clear();
            CnsTaxAutoCorrDiv_tComboEditor.Items.Add(0, "自動");
            CnsTaxAutoCorrDiv_tComboEditor.Items.Add(1, "手動");
            CnsTaxAutoCorrDiv_tComboEditor.MaxDropDownItems = CnsTaxAutoCorrDiv_tComboEditor.Items.Count;
            // 残数管理区分
            RemainCntMngDiv_tComboEditor.Items.Clear();
            RemainCntMngDiv_tComboEditor.Items.Add(0, "する");
            RemainCntMngDiv_tComboEditor.Items.Add(1, "しない");
            RemainCntMngDiv_tComboEditor.MaxDropDownItems = RemainCntMngDiv_tComboEditor.Items.Count;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // メモ複写区分
            MemoMoveDiv_tComboEditor.Items.Clear();
            MemoMoveDiv_tComboEditor.Items.Add(0, "する");
            MemoMoveDiv_tComboEditor.Items.Add(1, "社外メモのみ");
            MemoMoveDiv_tComboEditor.Items.Add(2, "しない");
            MemoMoveDiv_tComboEditor.MaxDropDownItems = MemoMoveDiv_tComboEditor.Items.Count;
            // 残数自動表示区分
            RemCntAutoDspDiv_tComboEditor.Items.Clear();
            RemCntAutoDspDiv_tComboEditor.Items.Add(0, "しない");
            RemCntAutoDspDiv_tComboEditor.Items.Add(1, "出荷残､入荷残のみ");
            RemCntAutoDspDiv_tComboEditor.Items.Add(2, "受発注残のみ");
            RemCntAutoDspDiv_tComboEditor.Items.Add(3, "出荷残､入荷残→受発注残");
            RemCntAutoDspDiv_tComboEditor.Items.Add(4, "受発注残→出荷残､入荷残");
            RemCntAutoDspDiv_tComboEditor.MaxDropDownItems = RemCntAutoDspDiv_tComboEditor.Items.Count;

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // 総額表示掛率適用区分
            TtlAmntDspRateDivCd_tComboEditor.Items.Clear();
            TtlAmntDspRateDivCd_tComboEditor.Items.Add(0, "税込単価");
            TtlAmntDspRateDivCd_tComboEditor.Items.Add(1, "税抜単価");
            TtlAmntDspRateDivCd_tComboEditor.MaxDropDownItems = TtlAmntDspRateDivCd_tComboEditor.Items.Count;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            //合計請求書
            DefTtlBillOutput_tComboEditor.Items.Clear();
            DefTtlBillOutput_tComboEditor.Items.Add(0, "出力する");
            DefTtlBillOutput_tComboEditor.Items.Add(1, "出力しない");
            //明細請求書
            DefDtlBillOutput_tComboEditor.Items.Clear();
            DefDtlBillOutput_tComboEditor.Items.Add(0, "出力する");
            DefDtlBillOutput_tComboEditor.Items.Add(1, "出力しない");
            //伝票合計請求書
            DefSlTtlBillOutput_tComboEditor.Items.Clear();
            DefSlTtlBillOutput_tComboEditor.Items.Add(0, "出力する");
            DefSlTtlBillOutput_tComboEditor.Items.Add(1, "出力しない");
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //仕入・出荷後数表示区分
            DtlCalcStckCntDsp_tComboEditor.Items.Clear();
            DtlCalcStckCntDsp_tComboEditor.Items.Add(0, UPDATE_AFTERCODE);
            DtlCalcStckCntDsp_tComboEditor.Items.Add(1, UPDATE_AFTERDTL);
            //ADD END ZHOUYU 2011/07/19
            // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            GoodsStockMstBootDiv_tComboEditor.Items.Clear();
            GoodsStockMstBootDiv_tComboEditor.Items.Add(0, STOCKMSTBOOTDIV1);
            GoodsStockMstBootDiv_tComboEditor.Items.Add(1, STOCKMSTBOOTDIV2);
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

        }
		
		/*----------------------------------------------------------------------------------*/
        /* ↓2007.05.19 deleted b by T-Kidate : 「XMLコメントが有効な言語要素の中にありません。」対応
        /// <summary>
       ///	地区種別0セット処理（20061205：携帯システムでは使用しないので削除）
       /// </summary>
       /// <param name="targetCombo">セットするTComboEditor</param>
       /// <remarks>
       /// <br>Note	    : 地区グループマスタから地区種別0のものを取得し
       ///					  TComboEditorに格納します。</br>
       /// <br>Programmer  : 23006  高橋 明子</br>
       /// <br>Date	    : 2005.10.04</br>
       /// <br></br>
       /// <br>Update Note : 2005.12.19  23006 高橋 明子</br>
       /// <br>               ・キャッシュ一本化対応</br>
       /// </remarks>
            ↑*/ 
       // ↓ 20061205 18322 d
       //private void SetAreaKind(TComboEditor targetCombo)
       //{	
       //	if (this._allDefSetAcs.areaKindList != null)
       //	{
       //		foreach (AreaGroup areaGroup in this._allDefSetAcs.areaKindList)
       //		{
       //			if ((areaGroup.LogicalDeleteCode == 0) &&
       //				(areaGroup.AreaKind == 0))
       //			{
       //				// TComboEditorに地区名称を格納
       //				targetCombo.Items.Add(areaGroup.AreaGroupCode, areaGroup.AreaName);
       //			}
       //		}
       //	}
       //}
       // ↑ 20061205 18322 d

       /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
        /// <br>Update Note : 王君</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>管理番号    : 10901273-00 2013/06/18配信分</br>
        /// <br>            : Redmine#35434の対応</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero2.DataText                    = "";  // ADD 2008/06/04
			this.SectionName_tEdit.DataText                    = "";

            // ↓ 20061205 18322 d
			//this.DistrictCode_tComEditor.Value                 = -1;
			//this.DefDispAddrCd1_tNedit.DataText                = "";
			//this.DefDispAddrCd2_tNedit.DataText                = "";
			//this.DefDispAddrCd3_tNedit.DataText                = "";
			//this.DefDispAddress_tEdit.DataText                 = "";
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
			//this.LandTransBranchCd_tNedit.DataText             = "";
            //this.LandTransBranchCd_tEdit.DataText              = "";
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
			//this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex   = 0;
            // ↑ 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			this.TotalAmoDispWayCd_tComEditor.SelectedIndex    = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this.CustCdAutoNumbering_tComEditor.SelectedIndex  = 0;
			this.CustomerDelChkDivCd_tComEditor.SelectedIndex  = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            this.DefDspCustTtlDay_tNedit.DataText              = "";
			this.DefDspCustClctMnyDay_tNedit.DataText          = "";
			this.DefDspClctMnyMonthCd_tComEditor.SelectedIndex = 0;
			this.IniDspPrslOrCorpCd_tComEditor.SelectedIndex   = 0;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this.InitDspDmDiv_tComEditor.SelectedIndex         = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
            //this.DefDspBillPrtDivCd_tComEditor.SelectedIndex = 0;
            // --- DEL  大矢睦美  2010/01/18 ----------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            this.MemberInfoDispCd_tComboEditor.SelectedIndex   = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ↓ 20061205 18322 d 
			//this.CarFixSelectMethod_tComEditor.SelectedIndex   = 0;
            //
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.13 TAKAHASHI ADD START
			//// 変更フラグ
			//this._changeFlg = false;
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.01.13 TAKAHASHI ADD END
            // ↑ 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            this.EraNameDispCd1_tComEditor.SelectedIndex = 0;
            this.EraNameDispCd2_tComEditor.SelectedIndex = 0;
            //this.EraNameDispCd3_tComEditor.SelectedIndex = 0; // DEL 2009/01/30
            this.GoodsNoInpDiv_tComboEditor.SelectedIndex = 0;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex = 0;
            this.RemainCntMngDiv_tComboEditor.SelectedIndex = 0;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            this.MemoMoveDiv_tComboEditor.SelectedIndex = 0;
            this.RemCntAutoDspDiv_tComboEditor.SelectedIndex = 0;
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            this.TtlAmntDspRateDivCd_tComboEditor.SelectedIndex = 0;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            this.DefTtlBillOutput_tComboEditor.SelectedIndex = 0;
            this.DefDtlBillOutput_tComboEditor.SelectedIndex = 0;
            this.DefSlTtlBillOutput_tComboEditor.SelectedIndex = 0;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //仕入・出荷後数表示区分
            this.DtlCalcStckCntDsp_tComboEditor.SelectedIndex = 0;
            //ADD END ZHOUYU 2011/07/19
            this.GoodsStockMstBootDiv_tComboEditor.SelectedIndex = 0;//ADD 王君 2013/05/02 Redmine#35434 

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期表示設定クラス画面展開処理
		/// </summary>
		/// <param name="allDefSet">全体初期表示設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 全体初期表示設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void AllDefSetToScreen(AllDefSet allDefSet)
		{
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点コード
            this.tEdit_SectionCodeAllowZero2.DataText = allDefSet.SectionCode;


            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
  			// 拠点名称
            // add 2008/11/05
            string sectionName = string.Empty;
            if (allDefSet.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this._allDefSetAcs.GetSectionName(allDefSet.EnterpriseCode, allDefSet.SectionCode);
            }
            // add 2008/11/05 end
            this.SectionName_tEdit.DataText = sectionName;

            // ↓ 20061205 18322 d
            // // 管区
			//this.DistrictCode_tComEditor.Value = allDefSet.DistrictCode;
            //
            // // 初期表示住所
            //if (allDefSet.DefDispAddrCd1 != 0)
            //{
            //    this.DefDispAddrCd1_tNedit.DataText = allDefSet.DefDispAddrCd1.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd1_tNedit.Clear();
            //}
            //
            //if (allDefSet.DefDispAddrCd2 != 0)
            //{
            //    this.DefDispAddrCd2_tNedit.DataText = allDefSet.DefDispAddrCd2.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd2_tNedit.Clear();
            //}
            //
            //if (allDefSet.DefDispAddrCd3 != 0)
            //{
            //    this.DefDispAddrCd3_tNedit.DataText = allDefSet.DefDispAddrCd3.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd3_tNedit.Clear();
            //}
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			//this.DefDispAddrCd4_tNedit.DataText = allDefSet.DefDispAddrCd4.ToString();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			// this.DefDispAddress_tEdit.DataText  = allDefSet.DefDispAddress;
            //
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // string LandTransBranchNm = "";
            // this.GetLandTransBranchName(1, allDefSet.LandTransBranchCd, out LandTransBranchNm);
            //
            // // 陸運事務所番号
            // this.LandTransBranchCd_tNedit.DataText = allDefSet.LandTransBranchCd.ToString();
            // this.LandTransBranchCd_tEdit.DataText = LandTransBranchNm;
            // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			// // 88No.自賠責算定
			//this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex = allDefSet.No88AutoLiaCalcDiv;
            // ↑ 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// 総額表示方法
			this.TotalAmoDispWayCd_tComEditor.SelectedIndex  = allDefSet.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 顧客コード自動発番
			this.CustCdAutoNumbering_tComEditor.SelectedIndex = allDefSet.CustCdAutoNumbering;

			// 得意先削除チェック
			this.CustomerDelChkDivCd_tComEditor.SelectedIndex = allDefSet.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // 得意先締日
			this.DefDspCustTtlDay_tNedit.DataText = allDefSet.DefDspCustTtlDay.ToString();

			// 得意先集金日
			this.DefDspCustClctMnyDay_tNedit.DataText = allDefSet.DefDspCustClctMnyDay.ToString();

			// 集金月
			this.DefDspClctMnyMonthCd_tComEditor.SelectedIndex = allDefSet.DefDspClctMnyMonthCd;

			// 個人･法人
			this.IniDspPrslOrCorpCd_tComEditor.SelectedIndex = allDefSet.IniDspPrslOrCorpCd;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// ＤＭ
			this.InitDspDmDiv_tComEditor.SelectedIndex = allDefSet.InitDspDmDiv;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
            // 請求書出力
			//this.DefDspBillPrtDivCd_tComEditor.SelectedIndex = allDefSet.DefDspBillPrtDivCd;
            // --- DEL  大矢睦美  2010/01/18 ----------<<<<<


            
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // 会員情報管理区分
            this.MemberInfoDispCd_tComboEditor.SelectedIndex = allDefSet.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ↓ 20061205 18322 d
			//// 請求書出力
			//this.CarFixSelectMethod_tComEditor.SelectedIndex = allDefSet.CarFixSelectMethod;
            // ↑ 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // 元号表示区分１
            this.EraNameDispCd1_tComEditor.SelectedIndex = allDefSet.EraNameDispCd1;
            // 元号表示区分２
            this.EraNameDispCd2_tComEditor.SelectedIndex = allDefSet.EraNameDispCd2;
            // 元号表示区分３
            //this.EraNameDispCd3_tComEditor.SelectedIndex = allDefSet.EraNameDispCd3; // DEL 2009/01/30
            // 品番入力区分
            this.GoodsNoInpDiv_tComboEditor.SelectedIndex = allDefSet.GoodsNoInpDiv;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // 消費税自動補正区分
            this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex = allDefSet.CnsTaxAutoCorrDiv;
            // 残数管理区分
            this.RemainCntMngDiv_tComboEditor.SelectedIndex = allDefSet.RemainCntMngDiv;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // メモ複写区分
            this.MemoMoveDiv_tComboEditor.SelectedIndex = allDefSet.MemoMoveDiv;
            // 残数自動表示区分
            this.RemCntAutoDspDiv_tComboEditor.SelectedIndex = allDefSet.RemCntAutoDspDiv;
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // 総額表示掛率適用区分
            this.TtlAmntDspRateDivCd_tComboEditor.SelectedIndex = allDefSet.TtlAmntDspRateDivCd;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            this.DefTtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefTtlBillOutput;
            this.DefDtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefDtlBillOutput;
            this.DefSlTtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefSlTtlBillOutput;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //仕入・出荷後数表示区分
            this.DtlCalcStckCntDsp_tComboEditor.SelectedIndex = allDefSet.DtlCalcStckCntDsp;
            //ADD END ZHOUYU 2011/07/19
            this.GoodsStockMstBootDiv_tComboEditor.SelectedIndex = allDefSet.GoodsStockMSTBootDiv;//ADD 王君 2013/05/02 Redmine#35434 

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面情報全体初期表示設定クラス格納処理
		/// </summary>
		/// <param name="allDefSet">全体初期表示設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から全体初期表示設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void ScreenToAllDefSet(ref AllDefSet allDefSet)
		{
			if (allDefSet == null)
			{
				// 新規の場合
				allDefSet = new AllDefSet();
			}

			// 拠点名称
			//allDefSet.SectionName = this.SectionName_tEdit.DataText;

            // ↓ 20061205 18322 d
			//// 管区
			//if ((int)this.DistrictCode_tComEditor.SelectedIndex < 0) 
			//{
			//	allDefSet.DistrictCode = 0;
			//	allDefSet.DistrictName = "";
			//}
			//else 
			//{
			//	allDefSet.DistrictCode = (int)this.DistrictCode_tComEditor.Value;
			//  allDefSet.DistrictName = this.DistrictCode_tComEditor.SelectedItem.ToString();
			//}
            //
			//// 初期表示住所
			//allDefSet.DefDispAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();
			//allDefSet.DefDispAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();
			//allDefSet.DefDispAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
            //
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
            ////allDefSet.DefDispAddrCd4 = this.DefDispAddrCd4_tNedit.GetInt();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			//allDefSet.DefDispAddress = this.DefDispAddress_tEdit.DataText;
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //// 陸運事務所番号
            //allDefSet.LandTransBranchCd = this.LandTransBranchCd_tNedit.GetInt();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//// 88No.自賠責算定
			//allDefSet.No88AutoLiaCalcDiv = this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex;
            // ↑ 20061205 18322 d

            // --- CHG 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            //// 総額表示方法
            //allDefSet.TotalAmountDispWayCd = (int)this.TotalAmoDispWayCd_tComEditor.Value;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
            // 総額表示方法
            allDefSet.TotalAmountDispWayCd = 0;
            // --- CHG 2009/01/05 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 顧客コード自動発番
			allDefSet.CustCdAutoNumbering = this.CustCdAutoNumbering_tComEditor.SelectedIndex;

			// 得意先削除チェック
			allDefSet.CustomerDelChkDivCd = this.CustomerDelChkDivCd_tComEditor.SelectedIndex;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点コード
            allDefSet.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //企業コード
            allDefSet.EnterpriseCode = this._enterpriseCode; 
            
            // 得意先締日
			if (this.DefDspCustTtlDay_tNedit.DataText == "")
			{
				allDefSet.DefDspCustTtlDay = 31;
			}
			else
			{
				allDefSet.DefDspCustTtlDay = this.DefDspCustTtlDay_tNedit.GetInt();
			}

			// 得意先集金日
			if (this.DefDspCustClctMnyDay_tNedit.DataText == "")
			{
				allDefSet.DefDspCustClctMnyDay = 10;
			}
			else
			{
				allDefSet.DefDspCustClctMnyDay = this.DefDspCustClctMnyDay_tNedit.GetInt();
			}

			// 集金月
            allDefSet.DefDspClctMnyMonthCd = (int)this.DefDspClctMnyMonthCd_tComEditor.Value;

			// 個人･法人
            allDefSet.IniDspPrslOrCorpCd = (int)this.IniDspPrslOrCorpCd_tComEditor.Value;

			// ＤＭ
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            // DM区分は強制的に"発行しない"に設定
            // ----------------------------------------------------------------
            //allDefSet.InitDspDmDiv = this.InitDspDmDiv_tComEditor.SelectedIndex;
            allDefSet.InitDspDmDiv = 1;         // 発行しない
            // ----------------------------------------------------------------

            // --- DEL  大矢睦美  2010/01/18 ---------->>>>>
			// 請求書出力
            //allDefSet.DefDspBillPrtDivCd = (int)this.DefDspBillPrtDivCd_tComEditor.Value;
            // --- DEL  大矢睦美  2010/01/18 ----------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // 会員情報管理区分
            allDefSet.MemberInfoDispCd = this.MemberInfoDispCd_tComboEditor.SelectedIndex;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ↓ 20061205 18322 d
			//// 車両確定方式
			//allDefSet.CarFixSelectMethod = this.CarFixSelectMethod_tComEditor.SelectedIndex;	
            // ↑ 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // 元号表示区分１
            allDefSet.EraNameDispCd1 = (int)this.EraNameDispCd1_tComEditor.Value;
            // 元号表示区分２
            allDefSet.EraNameDispCd2 = (int)this.EraNameDispCd2_tComEditor.Value;
            // 元号表示区分３
            //allDefSet.EraNameDispCd3 = (int)this.EraNameDispCd3_tComEditor.Value; // DEL 2009/01/30
            allDefSet.EraNameDispCd3 = 0; // ADD 2009/01/30
            // 品番入力区分
            allDefSet.GoodsNoInpDiv = (int)this.GoodsNoInpDiv_tComboEditor.Value;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // 消費税自動補正区分
            allDefSet.CnsTaxAutoCorrDiv = this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // 残数管理区分
            //allDefSet.RemainCntMngDiv = (int)this.RemainCntMngDiv_tComboEditor.Value;
            allDefSet.RemainCntMngDiv = 0;
            // メモ複写区分
            allDefSet.MemoMoveDiv = (int)this.MemoMoveDiv_tComboEditor.Value;
            // 残数自動表示区分
            allDefSet.RemCntAutoDspDiv = (int)this.RemCntAutoDspDiv_tComboEditor.Value;
            // 総額表示掛率適用区分
            // --- CHG 2009/01/05 --------------------------------------------------------------------->>>>>
            //allDefSet.TtlAmntDspRateDivCd = (int)this.TtlAmntDspRateDivCd_tComboEditor.Value;
            allDefSet.TtlAmntDspRateDivCd = 0;
            // --- CHG 2009/01/05 ---------------------------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            allDefSet.DefTtlBillOutput = (int)this.DefTtlBillOutput_tComboEditor.Value;
            allDefSet.DefDtlBillOutput = (int)this.DefDtlBillOutput_tComboEditor.Value;
            allDefSet.DefSlTtlBillOutput = (int)this.DefSlTtlBillOutput_tComboEditor.Value;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //仕入・出荷後数表示区分
            allDefSet.DtlCalcStckCntDsp = (int)this.DtlCalcStckCntDsp_tComboEditor.Value;
            //ADD END ZHOUYU 2011/07/19
            allDefSet.GoodsStockMSTBootDiv = (int)this.GoodsStockMstBootDiv_tComboEditor.Value;//ADD 王君 2013/05/02 Redmine#35434 

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
			{
				TMsgDisp.Show(this,                         // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
					"SFCMN09080U",							// アセンブリID
					"既に他端末より更新されています。",	    // 表示するメッセージ
					status,									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	全体初期表示設定画面入力チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 全体初期表示設定画面の入力チェックをします。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private int CheckDisplay(ref string checkMessage)
		{
			int returnStatus = 0;

			try
			{
                // ↓ 20061205 18322 d
				// // 管区
				//if (DistrictCode_tComEditor.SelectedIndex < 0)
				//{
				//	checkMessage = "陸事管区が未選択です。";
				//	returnStatus = 10;
				//	return returnStatus;
				//}
                //
                // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
                // // 陸運事務所番号
                //string landTransBranchNm = "";
                //if (this.GetLandTransBranchName(1, this.LandTransBranchCd_tNedit.GetInt(), out landTransBranchNm) != 0)
                //{
                //    checkMessage = "陸運事務所番号が不正です。";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
                // ↑ 20061205 18322 d

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // 拠点コード
                if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
                {
                    checkMessage = "拠点コードを入力して下さい。";
                    this.tEdit_SectionCodeAllowZero2.Focus(); // ADD 2011/09/07
                    returnStatus = 20;
                    return returnStatus;
                }
                // --- ADD 2011/09/07 -------------------------------->>>>>
                // 拠点コードの存在チェック
                bool existCheck = false;
                // 全社共通は拠点マスタに登録されていないため、チェックの対象外
                if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText == "0")
                {
                    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                    {
                        if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd ())
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
                if (existCheck)
                {
                   ;
                }
                else
                {
                    checkMessage = "指定した拠点コードは存在しません。";
                    returnStatus = 50;
                    return returnStatus;
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //if (GetSectionName(this.tEdit_SectionCodeAllowZero2.DataText.Trim()) == "")
                //{
                //    checkMessage = "マスタに登録されていません。";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

				// 得意先締日
				if ((this.DefDspCustTtlDay_tNedit.DataText == "") || 
					(this.DefDspCustTtlDay_tNedit.GetInt() > 31))
				{
					checkMessage = "得意先締日は 1～31日の間に設定して下さい。";
					returnStatus = 30;
					return returnStatus;
				}

				// 得意先集金日
				if ((this.DefDspCustClctMnyDay_tNedit.DataText == "") || 
					(this.DefDspCustClctMnyDay_tNedit.GetInt() > 31))
				{
					checkMessage = "得意先集金日は 1～31日の間に設定して下さい。";
					returnStatus = 40;
					return returnStatus;
				}

				return returnStatus;
			}
			finally
			{
				if( returnStatus != 0 )
				{
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFCMN09080U",							// アセンブリID
						checkMessage,	                        // 表示するメッセージ
						0,									    // ステータス値
						MessageBoxButtons.OK);					// 表示するボタン

					//エラーステータスに合わせてフォーカスセット
                    switch (returnStatus)
                    {
                        case 10:
                            {
                                // ↓ 20061205 18322 d
                                //this.DistrictCode_tComEditor.Focus();
                                // ↑ 20061205 18322 d
                                break;
                            }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
                        case 20:
                            {
                                // ↓ 20061205 18322 d
                                //this.LandTransBranchCd_tNedit.Focus();
                                // ↑ 20061205 18322 d
                                break;
                            }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

                        case 30:
                            {
                                this.DefDspCustTtlDay_tNedit.Focus();
                                break;
                            }

                        case 40:
                            {
                                this.DefDspCustClctMnyDay_tNedit.Focus();
                                break;
                            }
                        // --- ADD 2011/09/07 -------------------------------->>>>>
                        case 50:
                            {
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionCodeAllowZero2.Focus();
                                break;
                            }
                        // --- ADD 2011/09/07 --------------------------------<<<<<
                    }
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///　保存処理(SaveAllDefSet())
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 保存処理を行います。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private bool SaveAllDefSet()
        {
            bool result = false;

            // ----- ADD 2011/09/07 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            Control control = null;
			//画面データ入力チェック処理
			string checkMessage = "";
			int chkSt = CheckDisplay(ref checkMessage);
			if( chkSt != 0 )
			{
				return result;
			}


	
			AllDefSet allDefSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				allDefSet = ((AllDefSet)this._allDefSetTable[guid]).Clone();
			}

			ScreenToAllDefSet(ref allDefSet);
			int status = this._allDefSetAcs.Write(ref allDefSet);

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
					ExclusiveTransaction(status);
					
					
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
						"SFCMN09080U",							// アセンブリID
						"全体初期表示設定",  　　                 // プログラム名称
						"SaveAllDefSet",                       // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._allDefSetAcs,				    	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,			  		// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

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
			}

			AllDefSetToDataSet(allDefSet, this.DataIndex);

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

        /*----------------------------------------------------------------------------------*/
        /* ↓2007.05.19 deleted b by T-Kidate : 「XMLコメントが有効な言語要素の中にありません。」対応
        /// <summary>
       /// 住所コード変更処理（20061205：携帯システムでは使用しないため削除）
       /// </summary>
       /// <remarks>
       /// <br>Note		: 住所コードにあわせて表示されている初期表示住所1の変更を行います。</br>
       /// <br>Programmer	: 23006　高橋 明子</br>
       /// <br>Date		: 2005.10.03</br>
       /// </remarks>
            ↑*/ 
       // ↓ 20061205 18322 d
       //private void EpAddrCdChange(int addressMode)
       //{
       //    AddressGuide addrGuide = new AddressGuide();
       //    AddressGuideResult adgRet = new AddressGuideResult();
       //
       //    int epAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();
       //    int epAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();
       //    int epAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
       //
       //    switch (addressMode)
       //    {
       //        case 1:
       //            {
       //                this.DefDispAddrCd2_tNedit.Clear();
       //                this.DefDispAddrCd3_tNedit.Clear();
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //            }
       //
       //        case 2:
       //            {
       //                this.DefDispAddrCd3_tNedit.Clear();
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //            }
       //
       //        case 3:
       //            {
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //          }
       //    }
       //
       //    // 住所マスタ読込み
       //    addrGuide.SearchAddressFromAddressCode(epAddrCd1, epAddrCd2, epAddrCd3, ref adgRet);
       //
       //    if ((adgRet.PostNo != "") && (adgRet.AddressName != ""))
       //    {
       //        this.DefDispAddress_tEdit.Text = adgRet.AddressName;
       //    }
       //}
       // ↑ 20061205 18322 d

       /*----------------------------------------------------------------------------------*/
        /* ↓2007.05.19 deleted b by T-Kidate : 「XMLコメントが有効な言語要素の中にありません。」対応
        /// <summary>
       /// 陸運事務局情報変更処理
       /// </summary>
       /// <param name="ix">メッセージ表示有無 (0:メッセージ表示する  1:メッセージ表示しない)</param>
       /// <remarks>
       /// <br>Note		: 陸事コードにあわせて表示されている陸事情報の変更を行います。</br>
       /// <br>Programmer	: 23006  高橋 明子</br>
       /// <br>Date		: 2006.09.13</br>
       /// </remarks>
           ↑*/ 
       // ↓ 20061205 18322 d
       //private int GetLandTransBranchName(int ix, int landTransBranchCd, out string numberPlate1Name)
       //{
       //    int status = 0;
       //    numberPlate1Name = "";
       //    LandTrnsNm landTrnsNm = null;
       //
       //    // 陸運事務局マスタ読込み(初回のみ)
       //    // 論理削除分も取得
       //    if (this._landTrnsNmBuf == null)
       //    {
       //        status = this._landTrnsNmAcs.SearchAll(out _landTrnsNmBuf, this._enterpriseCode);
       //    }
       //
       //    if (landTransBranchCd != 0)
       //    {
       //        // 陸運事務局マスタBufferから取得
       //        foreach (LandTrnsNm landTransNmWork in this._landTrnsNmBuf)
       //        {
       //            if (landTransNmWork.NumberPlate1Code == landTransBranchCd)
       //            {
       //                landTrnsNm = landTransNmWork.Clone();
       //                break;
       //            }
       //        }
       //
       //        // 該当コードが無かった場合StatusにNotFoundを設定
       //        if (landTrnsNm == null)
       //        {
       //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
       //        }
       //
       //        switch (status)
       //        {
       //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
       //                {
       //                    if (landTrnsNm.LogicalDeleteCode != 0)
       //                    {
       //                        if (ix == 0)
       //                        {
       //                            TMsgDisp.Show(
       //                                this,								// 親ウィンドウフォーム
       //                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
       //                                "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
       //                                "マスタから削除されています。",		// 表示するメッセージ 
       //                                0,									// ステータス値
       //                                MessageBoxButtons.OK);				// 表示するボタン
       //
       //                            numberPlate1Name = "削除済";
       //                        }
       //                        return -2;
       //                    }
       //                    else
       //                    {
       //                        numberPlate1Name = landTrnsNm.NumberPlate1Name;
       //                    }
       //                    break;
       //                }
       //
       //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
       //                {
       //                    if (ix == 0)
       //                    {
       //                        TMsgDisp.Show(
       //                            this,								// 親ウィンドウフォーム
       //                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
       //                            "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
       //                            "マスタに登録されていません。",		// 表示するメッセージ 
       //                            0,									// ステータス値
       //                            MessageBoxButtons.OK);				// 表示するボタン
       //
       //                        numberPlate1Name = "未登録";
       //                    }
       //                    break;
       //                }
       //
       //            default:
       //                {
       //                    TMsgDisp.Show(
       //                        this,								  // 親ウィンドウフォーム
       //                        emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
       //                        "SFCMN09080U",						  // アセンブリＩＤまたはクラスＩＤ
       //                        this.Text,							  // プログラム名称
       //                        "GetLandTransBranchName",			  // 処理名称
       //                        TMsgDisp.OPE_GET,					  // オペレーション
       //                        "読み込みに失敗しました。",			  // 表示するメッセージ 
       //                        status,								  // ステータス値
       //                        this._landTrnsNmAcs,				  // エラーが発生したオブジェクト
       //                        MessageBoxButtons.OK,				  // 表示するボタン
       //                        MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
       //
       //                    numberPlate1Name = "";
       //                    break;
       //                }
       //        }
       //    }
       //    else
       //    {
       //        numberPlate1Name = "";
       //    }
       //
       //  //  return status;
       //}
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています" , 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
                tEdit_SectionCodeAllowZero2.Focus();

                control = tEdit_SectionCodeAllowZero2;
        }






        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(36, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(179, 24);
            this.DefDspCustTtlDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustClctMnyDay_tNedit.Size = new System.Drawing.Size(28, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";
            // --- DEL 2011/07/28 ----->>>>>
            //if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            //{
            //    sectionName = "全社共通";
            //    return sectionName;
            //}
            // --- DEL 2011/07/28 -----<<<<<
            // DEL 2009/04/17 ------>>>
            //ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.ResetSectionInfo();
            // DEL 2009/04/17 ------<<<
            
            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)          // DEL 2009/04/17
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)      // ADD 2009/04/17
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

        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

       # endregion

       # region -- Control Events --
       /*----------------------------------------------------------------------------------*/		
		/// <summary>
		///	Form.Load イベント(SFCMN9080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_Load(object sender, System.EventArgs e)
		{
            // ↓ 20070207 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070207 18322 a

			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList                 = imageList24;
			this.Cancel_Button.ImageList             = imageList24;

            // ↓ 20061205 18322 d
			//this.DefDispAddrGuide_uButton.ImageList  = imageList16;
            //this.LandTransBranchCd_uButton.ImageList = imageList16;     // 2006.09.13 TAKAHASHI ADD
            // ↑ 20061205 18322 d

			this.Ok_Button.Appearance.Image                 = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image             = Size24_Index.CLOSE;

            // ↓ 20061205 18322 d
            //this.DefDispAddrGuide_uButton.Appearance.Image = Size16_Index.STAR1;
            //this.LandTransBranchCd_uButton.Appearance.Image = Size16_Index.STAR1;     // 2006.09.13 TAKAHASHI ADD
            // ↑ 20061205 18322 d

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            // ADD 2009/04/17 ------>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // ADD 2009/04/17 ------<<<
            
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Closing イベント(SFCMN09080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
		///					  ようとしたときに発生します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.VisibleChanged イベント(SFCMN09080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// メインフレームアクティブ化
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			
			ScreenClear();

            Timer.Enabled = true;
		}

		/*----------------------------------------------------------------------------------*/
        /* ↓2007.05.19 deleted b by T-Kidate : 「XMLコメントが有効な言語要素の中にありません。」対応
		/// <summary>
		/// Control.Click イベント(DefDispAddrGuide_uButton) 20061205(携帯システムでは使用しないため削除)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 住所ガイドボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		    ↑*/
        // ↓ 20061205 18322 d
        //private void DefDispAddrGuide_uButton_Click(object sender, System.EventArgs e)
		//{
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI ADD END
		//	// 住所ガイド
		//	AddressGuide addrGuide = new AddressGuide();
        //    AddressGuideResult adgRet;
        //
        //    int epAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();  
		//	int epAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();  
		//	int epAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
        //    DialogResult dialogResult = addrGuide.ShowAddressGuide(epAddrCd1, epAddrCd2, epAddrCd3, out adgRet);
        //
        //    if (dialogResult == DialogResult.OK)
		//	{
        //        if ((adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower) == 0)
        //        {
        //            this.DefDispAddrCd1_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd1_tNedit.SetInt(adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower);
        //        }//
        //
        //        if (adgRet.AddressCode2 == 0)
        //        {
        //            this.DefDispAddrCd2_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd2_tNedit.SetInt(adgRet.AddressCode2);
        //        }
        //
        //        if (adgRet.AddressCode3 == 0)
        //        {
        //            this.DefDispAddrCd3_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd3_tNedit.SetInt(adgRet.AddressCode3);
        //        }
        //
		//		this.DefDispAddress_tEdit.Text = adgRet.AddressName;
		//		this.No88AutoLiaCalcDiv_tComEditor.Focus();
		//	}
		//	else
		//	{
		//		this.DefDispAddrGuide_uButton.Focus();
		//	}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI ADD END
        //
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.07.26 TAKAHASHI DELETE START
        //    //// 住所ガイド
        //    //AddressGuide addrGuide = new AddressGuide();
        //    //AddressGuideResult adgRet = new AddressGuideResult();
        //
        //    //string EnterpriseCode = this._enterpriseCode;
        //    //addrGuide.SearchAddress(this._enterpriseCode, ref adgRet);
        //
        //    //if (adgRet.AddressName != "")
        //    //{
        //    //    this.DefDispAddrCd1_tNedit.SetInt(adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower);
        //    //    this.DefDispAddrCd2_tNedit.SetInt(adgRet.AddressCode2);
        //    //    this.DefDispAddrCd3_tNedit.SetInt(adgRet.AddressCode3);
        //
        //    //    this.DefDispAddress_tEdit.Text = adgRet.AddressName;
        //    //    this.No88AutoLiaCalcDiv_tComEditor.Focus();
        //    //}
        //    //else
        //    //{
        //    //    this.DefDispAddrGuide_uButton.Focus();
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI DELETE END
		//}
        // ↑ 20061205 18322 d

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (!SaveAllDefSet())
			{
				return;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                AllDefSet compareAllDefSet = new AllDefSet();

                compareAllDefSet = this._allDefSetClone.Clone();
                ScreenToAllDefSet(ref compareAllDefSet);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._allDefSetClone.Equals(compareAllDefSet))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        "SFCMN09080U", 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveAllDefSet())
                                {
                                    return;
                                }
                                return;
                            }

                        case DialogResult.No:
                            {
                                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                                break;
                            }

                        default:
                            {
                                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
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
                                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Enter イベント(tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　      : コントロールがフォームのアクティブコントロールになったときに発生します。</br>
		/// <br>Programmer		: 23006　高橋 明子</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
        private void TNedit_Enter(object sender, EventArgs e)
        {
            // ↓ 20061205 18322 d
            //this._changeFlg = false;
            // ↑ 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.ValueChanged イベント(tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note		    : tNedit内のデータが変更された際に発生します。</br>
		/// <br>Programmer		: 23006　高橋 明子</br>
		/// <br>Date			: 2006.01.13</br>
		/// </remarks>
        private void TNedit_ValueChange(object sender, EventArgs e)
        {
            // ↓ 20061205 18322 d
            //// ユーザーによって変更された場合
            //if (((TNedit)sender).Modified)
            //{
            //    this._changeFlg = true;
            //}
            // ↑ 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note			: Controlが非アクティブになった際に発生します。</br>
		/// <br>Programmer		: 23006　高橋 明子</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
        private void TNedit_Leave(object sender, EventArgs e)
        {
            // ↓ 20061205 18322 d 携帯システムでは使用しないので
            //                     初期表示住所コード＆名称、陸運事務所番号を削除
            // // 初期表示住所コード1
            //if (((TNedit)sender).Name == "DefDispAddrCd1_tNedit")
            //{
            //    if ((this._changeFlg == true) || (this.DefDispAddrCd1_tNedit.Text == ""))
            //    {
            //        this._changeFlg = false;
            //
            //        // 住所コード変更処理
            //        EpAddrCdChange(1);
            //    }
            //}
            //
            // // 初期表示住所コード2
            //if (((TNedit)sender).Name == "DefDispAddrCd2_tNedit")
            //{
            //    if (this._changeFlg == true)
            //    {
            //        this._changeFlg = false;
            //
            //        // 住所コード変更処理
            //        EpAddrCdChange(2);
            //    }
            //}
            //
            // // 初期表示住所コード3
            //if (((TNedit)sender).Name == "DefDispAddrCd3_tNedit")
            //{
            //    if (this._changeFlg == true)
            //    {
            //        this._changeFlg = false;
            //
            //        // 住所コード変更処理
            //        EpAddrCdChange(3);
            //    }
            //}
            //
            // // 陸運事務所番号
            //if (((TNedit)sender).Name == "LandTransBranchCd_tNedit")
            //{
            //    if (this.LandTransBranchCd_tNedit.GetInt() == 0)
            //    {
            //        this.LandTransBranchCd_tEdit.Clear();
            //    }
            //    else if (this._changeFlg == true)
            //    {
            //        string landTransBranchNm = "";
            //
            //        this._changeFlg = false;
            //
            //        // 陸運事務所名称取得
            //        if (this.GetLandTransBranchName(0, this.LandTransBranchCd_tNedit.GetInt(), out landTransBranchNm) != 0)
            //        {
            //            this.LandTransBranchCd_tNedit.Focus();
            //        }
            //
            //        this.LandTransBranchCd_tEdit.Text = landTransBranchNm;
            //    }
            //}
            // ↑ 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note			: Controlが非アクティブになった際に発生します。</br>
		/// <br>Programmer		: 23006　高橋 明子</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
		private void Day_Leave(object sender, System.EventArgs e)
		{
			// 得意先締日
			if (((TNedit)sender).Name == "DefDspCustTtlDay_tNedit")
			{
				if (DefDspCustTtlDay_tNedit.DataText == "0")
				{
					DefDspCustTtlDay_tNedit.DataText = "";
				}
			}

			// 得意先集金日
			if (((TNedit)sender).Name == "DefDspCustClctMnyDay_tNedit")
			{
				if (DefDspCustClctMnyDay_tNedit.DataText == "0")
				{
					DefDspCustClctMnyDay_tNedit.DataText = "";
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(LandTransBranchCd_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 陸運事務所ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2006.09.13</br>
        /// </remarks>
        private void LandTransBranchCd_uButton_Click(object sender, EventArgs e)
        {
            // ↓ 20061205 18322 d 携帯システムでは、陸運事務所はいらないので削除
            // // 陸運支局名称
            //LandTrnsNm landTrnsNm = new LandTrnsNm();
            //
            //switch (this._landTrnsNmAcs.ExecuteGuid(2, this._enterpriseCode, out landTrnsNm))
            //{
            //    case 0:
            //        {
            //            this.LandTransBranchCd_tNedit.SetInt(landTrnsNm.NumberPlate1Code);
            //            this.LandTransBranchCd_tEdit.DataText = landTrnsNm.NumberPlate1Name;
            //
            //            this.DefDispAddrCd1_tNedit.Focus();
            //
            //            break;
            //        }
            //
            //    default:
            //        {
            //            break;
            //        }
            //}
            // ↑ 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Timer.Tick イベント(timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

			ScreenReconstruction();
		}
		#endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
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

                    this.DefDspCustTtlDay_tNedit.Focus();

                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                    // 新規モードからモード変更対応
                    //if (this.DataIndex < 0 )// DEL 2011/07/28
                    if (this.DataIndex < 0 && !string.IsNullOrEmpty (this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

			// 拠点情報論理削除処理
            int status = this._allDefSetAcs.Delete(allDefSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                    this._allDefSetTable.Remove(allDefSet.FileHeaderGuid);

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return;
				}
				default:
				{
					// 物理削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFCMN09080U", 						// アセンブリＩＤまたはクラスＩＤ
						this.Text, 				            // プログラム名称
						"Delete_Button_Click", 				// 処理名称
						TMsgDisp.OPE_DELETE, 				// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
                        this._allDefSetAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = ((AllDefSet)this._allDefSetTable[guid]).Clone();

            // 復活
            status = this._allDefSetAcs.Revival(ref allDefSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        AllDefSetToDataSet(allDefSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._allDefSetAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
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

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero2)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // 拠点名称取得
                //this.SectionName_tEdit.DataText = GetSectionName(sectionCode); // DEL 2011/09/07
                // ----- // ADD 2011/09/07 ------------------->>>>>
                string sectionName = GetSectionName(sectionCode);
                if (sectionCode == "0" || sectionCode == "00")
                {
                    sectionName = "全社共通";
                }
                isError = false;
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = sectionCode.PadLeft(2, '0');
                }
                this.SectionName_tEdit.DataText = sectionName;
                // ----- // ADD 2011/09/07 -------------------<<<<<

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.SectionGuide_Button;
                        }
                    }
                }

                
                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                // ADD 2009/04/17 ------>>>
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                // ADD 2009/04/17 ------<<<
                //else if (this.DataIndex < 0 )// DEL 2011/07/28
                else if (this.DataIndex < 0 && !string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
                // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
            // ADD 2009/04/17 ------>>>
            else if (e.PrevCtrl == Renewal_Button)
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2")
                {
                    ;
                }
                // else if (this.DataIndex < 0 )// DEL 2011/07/28
                else if (this.DataIndex < 0 && !string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            // ADD 2009/04/17 ------<<<
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionName_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "入力されたコードの全体初期表示設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの全体初期表示設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/08
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの全体初期表示設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "SFCMN09080U",                          // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/08
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
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // ADD 2009/04/17 ------>>>
        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFCMN09080U",						// アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // ADD 2009/04/17 ------<<<        
	}
}

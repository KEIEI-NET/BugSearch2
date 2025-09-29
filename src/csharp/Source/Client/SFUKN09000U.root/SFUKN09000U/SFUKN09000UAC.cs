using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	///	自社情報設定クラス
	/// </summary>
	/// <remarks> 
	/// <br>note			:	自社情報の設定を行います。
	///							IMasterMaintenanceSingleTypeを実装しています。</br>              
	/// <br>Programer		:	小黒大輔</br>                            
	/// <br>Date			:	2005.04.07</br>                              
	/// <br></br>
	/// <br>Update Note		:	2005.05.31 22025 當間 豊</br>
	/// <br>								・フレームの最小化対応</br>
	/// <br>Update Note		:	2005.06.10 22025 當間 豊</br>
	/// <br>								・UI子画面項目の「右寄せ」「左寄せ」最適化対応</br>
	/// <br>								・子画面のタイトルを「自社情報登録設定」→「自社情報設定」へ変更</br>
	/// <br></br>
	/// <br>Update Note		:	2005.06.17 22025 當間 豊</br>
	/// <br>								・更新モードの初期フォーカス項目をSelectAll対応</br>
	/// <br></br>
	/// <br>Update Note		:	2005.06.18 22025 當間 豊</br>
	/// <br>								・ForeColorDisabledとBackColorDisabledの設定対応</br>
	/// <br></br>
	/// <br>Update Note		:	2005.06.23 22025 當間 豊</br>
	/// <br>								・住所２が「0」の時、フレーム表示時には"○丁目"は表示しないように変更</br>
	/// <br>Update Note		:	2005.07.04 23010 中村　仁</br>
	/// <br>								・メインフレームの最小化処理</br>
	/// <br>Update Note		:	2005.09.08 22021 谷藤　範幸</br>
	/// <br>								・ログイン情報取得部品の組込み</br>
	/// <br>Update Note     :   2005.09.13 23001 秋山　亮介</br>
	/// <br>								・ファイルレイアウト変更対応</br>
	/// <br>Update Note     :   2005.09.22 23001 秋山　亮介</br>
	/// <br>								・メッセージボックス表示部品の組込み</br>
	/// <br>Update Note     :   2005.10.19 22021 谷藤　範幸</br>
	/// <br>		        :               ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br>Update Note     :   2007.04.10 20031 古賀　小百合</br>
    /// <br>		        :               ・携帯.NS開発のため項目追加</br>
    /// <br>Update Note     :   2007.04.13 20031 古賀　小百合</br>
    /// <br>		        :               ・項目名及び、項目ID変更</br>
    /// <br>Update Note     :   2007.05.17 20031 古賀　小百合</br>
    /// <br>		        :               ・項目追加</br>
    /// <br>Update Note     :   2007.09.26 980035 金沢　貞義</br>
    /// <br>		        :               ・項目追加（DC.NS対応）</br>
    /// <br>Update Note     :   2008.01.11 980035 金沢　貞義</br>
    /// <br>		                        ・項目追加（部署管理区分）</br>
    /// <br>Update Note     :   2008/06/03 30414 忍　幸史</br>
    /// <br>		                        ・部署管理区分から「拠点＋部＋課」を削除</br>
    /// <br>Update Note     :   2008/09/05 30414 忍　幸史</br>
    /// <br>		                        ・ファイルレイアウト変更対応</br>
    /// <br>Update Note     :   2008/09/12 30414 忍　幸史</br>
    /// <br>		                        ・開始年区分、開始月区分補足追加</br>
    /// <br>Update Note     :   2008/10/28 30462 行澤　仁美</br>
    /// <br>		                        ・開始年区分、開始月区分修正[7089]</br>
    /// <br>Update Note     :   2009/02/10 30414 忍　幸史</br>
    /// <br>		                        ・障害ID:11320対応</br>
    /// <br>Update Note     :   2010/01/22 20056 對馬 大輔</br>
    /// <br>		                        MANTIS[14583] 開始月区分の設定方法変更</br>
    /// <br>Update Note		:	2010/12/21 鄧潘ハン</br>
    /// <br>                    ①開始月が不正になる不具合を修正</br>
    /// <br>Update Note     :   2011/07/22 連番 42  zhouyu </br>
    /// <br>                    月次更新で、古いデータを削除の対応</br>
    /// </remarks>
	public class SFUKN09000UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel BiginMonth_Title;
        private Broadleaf.Library.Windows.Forms.TNedit BiginMonth_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
		private System.Windows.Forms.Timer Initial_Timer;
        private TNedit BiginMonth2_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel BiginMonth2_Title;
        private TEdit CompanyName2_tEdit;
        private TEdit CompanyName1_tEdit;
        public Infragistics.Win.Misc.UltraLabel CompanyName2_Title;
        public Infragistics.Win.Misc.UltraLabel CompanyName1_Title;
        private TNedit FinancialYear_tNedit;
        public Infragistics.Win.Misc.UltraLabel FinancialYear_Title;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        public Infragistics.Win.Misc.UltraLabel CompanyBiginDate_Title;
        private TDateEdit2 CompanyBiginDate_tDateEdit;
        public Infragistics.Win.Misc.UltraLabel StartMonthDiv_Title;
        private TComboEditor StartMonthDiv_tComboEditor;
        private TComboEditor SecMngDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel SecMngDiv_Title;
        private Infragistics.Win.Misc.UltraLabel CompanyTel1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PostNo_Border_Label;
        private TEdit CompanyTelNo1_tEdit;
        private TEdit CompanyTelTitle3_tEdit;
        private TEdit CompanyTelTitle2_tEdit;
        private TEdit CompanyTelTitle1_tEdit;
        private TEdit Address1_tEdit;
        private TEdit PostNo_tEdit;
        private TEdit PostNoMark_tEdit;
        private TEdit Address3_tEdit;
        private TEdit Address4_tEdit;
        private TEdit CompanyTelNo2_tEdit;
        private TEdit CompanyTelNo3_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraButton AddressGuide_Button;
        private Infragistics.Win.Misc.UltraLabel PostNo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel Address_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel1Title_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel2Title_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel3Title_Title_Label;
        private Infragistics.Win.Misc.UltraLabel RateProtyIndex_Title_Label;
        private Infragistics.Win.Misc.UltraLabel MasterSaveMonths_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ResultDtSaveMonths_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CaPrtsDtSaveMonths_Title_Label;
        private Infragistics.Win.Misc.UltraLabel DataSaveMonths_Title_Label;
        private TComboEditor RateProtyIndex_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel DataCompressDt_Title_Label;
        private Infragistics.Win.Misc.UltraLabel MasterCompressDt_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CaPrtsDtCompressDt_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ResultDtCompressDt_Title_Label;
        private TDateEdit2 MasterCompressDt_tDateEdit;
        private TDateEdit2 CaPrtsDtCompressDt_tDateEdit;
        private TDateEdit2 ResultDtCompressDt_tDateEdit;
        private TDateEdit2 DataCompressDt_tDateEdit;
        private TNedit DataSaveMonths_tEdit;
        private TNedit ResultDtSaveMonths_tEdit;
        private TNedit CaPrtsDtSaveMonths_tEdit;
        private TNedit MasterSaveMonths_tEdit;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// SFUKN09000UAコンストラクタ
		/// </summary>
		/// <remarks> 
		/// <br>note			:	自社情報設定クラス、自社情報設定アクセスクラスを生成します。
		///							フレーム画面の印刷ボタン非表示設定を行います。</br>
		/// <br>Programer		:	小黒大輔</br>                            
		/// <br>Date			:	2005.04.07</br>                              
		/// </remarks>
		public SFUKN09000UA()
		{
			InitializeComponent();

			// companyInfクラスアクセスクラス
			this.companyInfAcs = new CompanyInfAcs();

			//　企業コードを取得する
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// ← 要変更
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 印刷可能フラグを設定します。
			// Frameの印刷ボタンの表示非表示の制御に使用します。
			_canPrint = false;

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            this._changeFlg = false;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
        }
		# endregion

		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKN09000UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BiginMonth_Title = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.BiginMonth_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.BiginMonth2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BiginMonth2_Title = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName2_Title = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName1_Title = new Infragistics.Win.Misc.UltraLabel();
            this.FinancialYear_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.FinancialYear_Title = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyBiginDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.CompanyBiginDate_Title = new Infragistics.Win.Misc.UltraLabel();
            this.StartMonthDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StartMonthDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.SecMngDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.SecMngDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CompanyTel1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PostNo_Border_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTelNo1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNoMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.AddressGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.PostNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Address_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel1Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DataSaveMonths_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CaPrtsDtSaveMonths_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ResultDtSaveMonths_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MasterSaveMonths_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateProtyIndex_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateProtyIndex_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.DataCompressDt_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ResultDtCompressDt_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CaPrtsDtCompressDt_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MasterCompressDt_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DataCompressDt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ResultDtCompressDt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.CaPrtsDtCompressDt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.MasterCompressDt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.DataSaveMonths_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ResultDtSaveMonths_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CaPrtsDtSaveMonths_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MasterSaveMonths_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.BiginMonth_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiginMonth2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinancialYear_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecMngDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateProtyIndex_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSaveMonths_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDtSaveMonths_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaPrtsDtSaveMonths_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterSaveMonths_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(481, 592);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(120, 34);
            this.Ok_Button.TabIndex = 24;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(603, 592);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(120, 34);
            this.Cancel_Button.TabIndex = 25;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 633);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(748, 23);
            this.ultraStatusBar1.TabIndex = 25;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Mode_Label
            // 
            appearance54.ForeColor = System.Drawing.Color.White;
            appearance54.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance54.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance54;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance55.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance55.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance55.TextHAlignAsString = "Center";
            appearance55.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance55;
            this.Mode_Label.Location = new System.Drawing.Point(634, 3);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // BiginMonth_Title
            // 
            this.BiginMonth_Title.Location = new System.Drawing.Point(526, 70);
            this.BiginMonth_Title.Name = "BiginMonth_Title";
            this.BiginMonth_Title.Size = new System.Drawing.Size(100, 14);
            this.BiginMonth_Title.TabIndex = 22;
            this.BiginMonth_Title.Text = "実績用期首月";
            this.BiginMonth_Title.Visible = false;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // BiginMonth_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.BiginMonth_tNedit.ActiveAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextHAlignAsString = "Right";
            appearance41.TextVAlignAsString = "Middle";
            this.BiginMonth_tNedit.Appearance = appearance41;
            this.BiginMonth_tNedit.AutoSelect = true;
            this.BiginMonth_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BiginMonth_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BiginMonth_tNedit.DataText = "";
            this.BiginMonth_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BiginMonth_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BiginMonth_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BiginMonth_tNedit.Location = new System.Drawing.Point(632, 67);
            this.BiginMonth_tNedit.MaxLength = 2;
            this.BiginMonth_tNedit.Name = "BiginMonth_tNedit";
            this.BiginMonth_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.BiginMonth_tNedit.Size = new System.Drawing.Size(28, 24);
            this.BiginMonth_tNedit.TabIndex = 230;
            this.BiginMonth_tNedit.Visible = false;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(665, 70);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel5.TabIndex = 24;
            this.ultraLabel5.Text = "月";
            this.ultraLabel5.Visible = false;
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // BiginMonth2_tNedit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.BiginMonth2_tNedit.ActiveAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.BiginMonth2_tNedit.Appearance = appearance20;
            this.BiginMonth2_tNedit.AutoSelect = true;
            this.BiginMonth2_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BiginMonth2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BiginMonth2_tNedit.DataText = "";
            this.BiginMonth2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BiginMonth2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BiginMonth2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BiginMonth2_tNedit.Location = new System.Drawing.Point(632, 37);
            this.BiginMonth2_tNedit.MaxLength = 2;
            this.BiginMonth2_tNedit.Name = "BiginMonth2_tNedit";
            this.BiginMonth2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.BiginMonth2_tNedit.Size = new System.Drawing.Size(28, 24);
            this.BiginMonth2_tNedit.TabIndex = 200;
            this.BiginMonth2_tNedit.Visible = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(666, 40);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel1.TabIndex = 21;
            this.ultraLabel1.Text = "月";
            this.ultraLabel1.Visible = false;
            // 
            // BiginMonth2_Title
            // 
            this.BiginMonth2_Title.Location = new System.Drawing.Point(526, 40);
            this.BiginMonth2_Title.Name = "BiginMonth2_Title";
            this.BiginMonth2_Title.Size = new System.Drawing.Size(100, 14);
            this.BiginMonth2_Title.TabIndex = 19;
            this.BiginMonth2_Title.Text = "会計用期首月";
            this.BiginMonth2_Title.Visible = false;
            // 
            // CompanyName2_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.ActiveAppearance = appearance15;
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.Appearance = appearance16;
            this.CompanyName2_tEdit.AutoSelect = true;
            this.CompanyName2_tEdit.DataText = "";
            this.CompanyName2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName2_tEdit.Location = new System.Drawing.Point(182, 157);
            this.CompanyName2_tEdit.MaxLength = 20;
            this.CompanyName2_tEdit.Name = "CompanyName2_tEdit";
            this.CompanyName2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName2_tEdit.TabIndex = 6;
            // 
            // CompanyName1_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.Appearance = appearance18;
            this.CompanyName1_tEdit.AutoSelect = true;
            this.CompanyName1_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyName1_tEdit.DataText = "";
            this.CompanyName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName1_tEdit.Location = new System.Drawing.Point(182, 127);
            this.CompanyName1_tEdit.MaxLength = 20;
            this.CompanyName1_tEdit.Name = "CompanyName1_tEdit";
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName1_tEdit.TabIndex = 5;
            // 
            // CompanyName2_Title
            // 
            appearance61.TextVAlignAsString = "Middle";
            this.CompanyName2_Title.Appearance = appearance61;
            this.CompanyName2_Title.Location = new System.Drawing.Point(20, 157);
            this.CompanyName2_Title.Name = "CompanyName2_Title";
            this.CompanyName2_Title.Size = new System.Drawing.Size(100, 24);
            this.CompanyName2_Title.TabIndex = 17;
            this.CompanyName2_Title.Text = "自社名称２";
            // 
            // CompanyName1_Title
            // 
            appearance65.TextVAlignAsString = "Middle";
            this.CompanyName1_Title.Appearance = appearance65;
            this.CompanyName1_Title.Location = new System.Drawing.Point(20, 127);
            this.CompanyName1_Title.Name = "CompanyName1_Title";
            this.CompanyName1_Title.Size = new System.Drawing.Size(100, 24);
            this.CompanyName1_Title.TabIndex = 16;
            this.CompanyName1_Title.Text = "自社名称１";
            // 
            // FinancialYear_tNedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.FinancialYear_tNedit.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.FinancialYear_tNedit.Appearance = appearance14;
            this.FinancialYear_tNedit.AutoSelect = true;
            this.FinancialYear_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.FinancialYear_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.FinancialYear_tNedit.DataText = "";
            this.FinancialYear_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.FinancialYear_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.FinancialYear_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FinancialYear_tNedit.Location = new System.Drawing.Point(182, 37);
            this.FinancialYear_tNedit.MaxLength = 4;
            this.FinancialYear_tNedit.Name = "FinancialYear_tNedit";
            this.FinancialYear_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.FinancialYear_tNedit.Size = new System.Drawing.Size(44, 24);
            this.FinancialYear_tNedit.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance68;
            this.ultraLabel2.Location = new System.Drawing.Point(232, 37);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(20, 24);
            this.ultraLabel2.TabIndex = 12;
            this.ultraLabel2.Text = "年";
            // 
            // FinancialYear_Title
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.FinancialYear_Title.Appearance = appearance70;
            this.FinancialYear_Title.Location = new System.Drawing.Point(20, 37);
            this.FinancialYear_Title.Name = "FinancialYear_Title";
            this.FinancialYear_Title.Size = new System.Drawing.Size(100, 24);
            this.FinancialYear_Title.TabIndex = 11;
            this.FinancialYear_Title.Text = "会計年度";
            // 
            // CompanyBiginDate_tDateEdit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.CompanyBiginDate_tDateEdit.ActiveEditAppearance = appearance94;
            this.CompanyBiginDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.CompanyBiginDate_tDateEdit.CalendarDisp = true;
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance95.TextHAlignAsString = "Right";
            appearance95.TextVAlignAsString = "Middle";
            this.CompanyBiginDate_tDateEdit.EditAppearance = appearance95;
            this.CompanyBiginDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.CompanyBiginDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyBiginDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance96.TextHAlignAsString = "Left";
            appearance96.TextVAlignAsString = "Middle";
            this.CompanyBiginDate_tDateEdit.LabelAppearance = appearance96;
            this.CompanyBiginDate_tDateEdit.Location = new System.Drawing.Point(182, 67);
            this.CompanyBiginDate_tDateEdit.Name = "CompanyBiginDate_tDateEdit";
            this.CompanyBiginDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.CompanyBiginDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.CompanyBiginDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.CompanyBiginDate_tDateEdit.TabIndex = 2;
            this.CompanyBiginDate_tDateEdit.TabStop = true;
            this.CompanyBiginDate_tDateEdit.ValueChanged += new System.EventHandler(this.CompanyBiginDate_tDateEdit_ValueChanged);
            // 
            // CompanyBiginDate_Title
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.CompanyBiginDate_Title.Appearance = appearance59;
            this.CompanyBiginDate_Title.Location = new System.Drawing.Point(20, 67);
            this.CompanyBiginDate_Title.Name = "CompanyBiginDate_Title";
            this.CompanyBiginDate_Title.Size = new System.Drawing.Size(100, 24);
            this.CompanyBiginDate_Title.TabIndex = 13;
            this.CompanyBiginDate_Title.Text = "期首年月日";
            // 
            // StartMonthDiv_tComboEditor
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StartMonthDiv_tComboEditor.ActiveAppearance = appearance33;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.StartMonthDiv_tComboEditor.Appearance = appearance5;
            this.StartMonthDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.StartMonthDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StartMonthDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StartMonthDiv_tComboEditor.ItemAppearance = appearance34;
            this.StartMonthDiv_tComboEditor.Location = new System.Drawing.Point(182, 97);
            this.StartMonthDiv_tComboEditor.MaxDropDownItems = 18;
            this.StartMonthDiv_tComboEditor.Name = "StartMonthDiv_tComboEditor";
            this.StartMonthDiv_tComboEditor.Size = new System.Drawing.Size(207, 24);
            this.StartMonthDiv_tComboEditor.TabIndex = 4;
            // 
            // StartMonthDiv_Title
            // 
            appearance57.TextVAlignAsString = "Middle";
            this.StartMonthDiv_Title.Appearance = appearance57;
            this.StartMonthDiv_Title.Location = new System.Drawing.Point(20, 97);
            this.StartMonthDiv_Title.Name = "StartMonthDiv_Title";
            this.StartMonthDiv_Title.Size = new System.Drawing.Size(100, 24);
            this.StartMonthDiv_Title.TabIndex = 15;
            this.StartMonthDiv_Title.Text = "開始月";
            // 
            // SecMngDiv_Title
            // 
            appearance56.TextVAlignAsString = "Middle";
            this.SecMngDiv_Title.Appearance = appearance56;
            this.SecMngDiv_Title.Location = new System.Drawing.Point(20, 187);
            this.SecMngDiv_Title.Name = "SecMngDiv_Title";
            this.SecMngDiv_Title.Size = new System.Drawing.Size(100, 24);
            this.SecMngDiv_Title.TabIndex = 26;
            this.SecMngDiv_Title.Text = "部門管理区分";
            // 
            // SecMngDiv_tComboEditor
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SecMngDiv_tComboEditor.ActiveAppearance = appearance74;
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            this.SecMngDiv_tComboEditor.Appearance = appearance75;
            this.SecMngDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SecMngDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SecMngDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SecMngDiv_tComboEditor.ItemAppearance = appearance76;
            this.SecMngDiv_tComboEditor.Location = new System.Drawing.Point(182, 187);
            this.SecMngDiv_tComboEditor.MaxDropDownItems = 18;
            this.SecMngDiv_tComboEditor.Name = "SecMngDiv_tComboEditor";
            this.SecMngDiv_tComboEditor.Size = new System.Drawing.Size(175, 24);
            this.SecMngDiv_tComboEditor.TabIndex = 7;
            // 
            // CompanyTel1_Title_Label
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.CompanyTel1_Title_Label.Appearance = appearance62;
            this.CompanyTel1_Title_Label.Location = new System.Drawing.Point(360, 345);
            this.CompanyTel1_Title_Label.Name = "CompanyTel1_Title_Label";
            this.CompanyTel1_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.CompanyTel1_Title_Label.TabIndex = 83;
            this.CompanyTel1_Title_Label.Text = "電話番号１";
            // 
            // CompanyTel2_Title_Label
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.CompanyTel2_Title_Label.Appearance = appearance63;
            this.CompanyTel2_Title_Label.Location = new System.Drawing.Point(360, 375);
            this.CompanyTel2_Title_Label.Name = "CompanyTel2_Title_Label";
            this.CompanyTel2_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.CompanyTel2_Title_Label.TabIndex = 84;
            this.CompanyTel2_Title_Label.Text = "電話番号２";
            // 
            // CompanyTel3_Title_Label
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.CompanyTel3_Title_Label.Appearance = appearance64;
            this.CompanyTel3_Title_Label.Location = new System.Drawing.Point(360, 405);
            this.CompanyTel3_Title_Label.Name = "CompanyTel3_Title_Label";
            this.CompanyTel3_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.CompanyTel3_Title_Label.TabIndex = 85;
            this.CompanyTel3_Title_Label.Text = "電話番号３";
            // 
            // PostNo_Border_Label
            // 
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PostNo_Border_Label.Appearance = appearance26;
            this.PostNo_Border_Label.Location = new System.Drawing.Point(217, 226);
            this.PostNo_Border_Label.Name = "PostNo_Border_Label";
            this.PostNo_Border_Label.Size = new System.Drawing.Size(3, 22);
            this.PostNo_Border_Label.TabIndex = 65;
            // 
            // CompanyTelNo1_tEdit
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance103.ForeColor = System.Drawing.Color.Black;
            appearance103.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.ActiveAppearance = appearance103;
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColor = System.Drawing.Color.Black;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            appearance104.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.Appearance = appearance104;
            this.CompanyTelNo1_tEdit.AutoSelect = true;
            this.CompanyTelNo1_tEdit.DataText = "";
            this.CompanyTelNo1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo1_tEdit.Location = new System.Drawing.Point(537, 345);
            this.CompanyTelNo1_tEdit.MaxLength = 16;
            this.CompanyTelNo1_tEdit.Name = "CompanyTelNo1_tEdit";
            this.CompanyTelNo1_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo1_tEdit.TabIndex = 14;
            // 
            // CompanyTelTitle3_tEdit
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.ActiveAppearance = appearance67;
            appearance69.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.ForeColorDisabled = System.Drawing.Color.Black;
            appearance69.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.Appearance = appearance69;
            this.CompanyTelTitle3_tEdit.AutoSelect = true;
            this.CompanyTelTitle3_tEdit.DataText = "";
            this.CompanyTelTitle3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle3_tEdit.Location = new System.Drawing.Point(182, 405);
            this.CompanyTelTitle3_tEdit.MaxLength = 6;
            this.CompanyTelTitle3_tEdit.Name = "CompanyTelTitle3_tEdit";
            this.CompanyTelTitle3_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle3_tEdit.TabIndex = 17;
            // 
            // CompanyTelTitle2_tEdit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.ActiveAppearance = appearance38;
            appearance39.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.Appearance = appearance39;
            this.CompanyTelTitle2_tEdit.AutoSelect = true;
            this.CompanyTelTitle2_tEdit.DataText = "";
            this.CompanyTelTitle2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle2_tEdit.Location = new System.Drawing.Point(182, 375);
            this.CompanyTelTitle2_tEdit.MaxLength = 6;
            this.CompanyTelTitle2_tEdit.Name = "CompanyTelTitle2_tEdit";
            this.CompanyTelTitle2_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle2_tEdit.TabIndex = 15;
            // 
            // CompanyTelTitle1_tEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.Appearance = appearance37;
            this.CompanyTelTitle1_tEdit.AutoSelect = true;
            this.CompanyTelTitle1_tEdit.DataText = "";
            this.CompanyTelTitle1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle1_tEdit.Location = new System.Drawing.Point(182, 345);
            this.CompanyTelTitle1_tEdit.MaxLength = 6;
            this.CompanyTelTitle1_tEdit.Name = "CompanyTelTitle1_tEdit";
            this.CompanyTelTitle1_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle1_tEdit.TabIndex = 13;
            // 
            // Address1_tEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.Address1_tEdit.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.Address1_tEdit.Appearance = appearance28;
            this.Address1_tEdit.AutoSelect = true;
            this.Address1_tEdit.DataText = "";
            this.Address1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address1_tEdit.Location = new System.Drawing.Point(182, 255);
            this.Address1_tEdit.MaxLength = 30;
            this.Address1_tEdit.Name = "Address1_tEdit";
            this.Address1_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address1_tEdit.TabIndex = 10;
            // 
            // PostNo_tEdit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.ActiveAppearance = appearance24;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.Appearance = appearance25;
            this.PostNo_tEdit.AutoSelect = true;
            this.PostNo_tEdit.DataText = "";
            this.PostNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.PostNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PostNo_tEdit.Location = new System.Drawing.Point(217, 225);
            this.PostNo_tEdit.MaxLength = 10;
            this.PostNo_tEdit.Name = "PostNo_tEdit";
            this.PostNo_tEdit.Size = new System.Drawing.Size(92, 24);
            this.PostNo_tEdit.TabIndex = 8;
            this.PostNo_tEdit.ValueChanged += new System.EventHandler(this.PostNo_tEdit_ValueChanged);
            this.PostNo_tEdit.Leave += new System.EventHandler(this.PostNo_tEdit_Leave);
            this.PostNo_tEdit.Enter += new System.EventHandler(this.PostNo_tEdit_Enter);
            // 
            // PostNoMark_tEdit
            // 
            this.PostNoMark_tEdit.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BackColorDisabled = System.Drawing.Color.White;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.PostNoMark_tEdit.Appearance = appearance23;
            this.PostNoMark_tEdit.AutoSelect = true;
            this.PostNoMark_tEdit.BackColor = System.Drawing.Color.White;
            this.PostNoMark_tEdit.DataText = "〒";
            this.PostNoMark_tEdit.Enabled = false;
            this.PostNoMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNoMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PostNoMark_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PostNoMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PostNoMark_tEdit.Location = new System.Drawing.Point(182, 225);
            this.PostNoMark_tEdit.MaxLength = 12;
            this.PostNoMark_tEdit.Name = "PostNoMark_tEdit";
            this.PostNoMark_tEdit.Size = new System.Drawing.Size(37, 24);
            this.PostNoMark_tEdit.TabIndex = 64;
            this.PostNoMark_tEdit.TabStop = false;
            this.PostNoMark_tEdit.Text = "〒";
            // 
            // Address3_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextVAlignAsString = "Middle";
            this.Address3_tEdit.ActiveAppearance = appearance29;
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.Address3_tEdit.Appearance = appearance30;
            this.Address3_tEdit.AutoSelect = true;
            this.Address3_tEdit.DataText = "";
            this.Address3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address3_tEdit.Location = new System.Drawing.Point(182, 285);
            this.Address3_tEdit.MaxLength = 22;
            this.Address3_tEdit.Name = "Address3_tEdit";
            this.Address3_tEdit.Size = new System.Drawing.Size(453, 24);
            this.Address3_tEdit.TabIndex = 11;
            // 
            // Address4_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.Address4_tEdit.ActiveAppearance = appearance31;
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.Address4_tEdit.Appearance = appearance32;
            this.Address4_tEdit.AutoSelect = true;
            this.Address4_tEdit.DataText = "";
            this.Address4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address4_tEdit.Location = new System.Drawing.Point(182, 315);
            this.Address4_tEdit.MaxLength = 30;
            this.Address4_tEdit.Name = "Address4_tEdit";
            this.Address4_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address4_tEdit.TabIndex = 12;
            // 
            // CompanyTelNo2_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.Appearance = appearance45;
            this.CompanyTelNo2_tEdit.AutoSelect = true;
            this.CompanyTelNo2_tEdit.DataText = "";
            this.CompanyTelNo2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo2_tEdit.Location = new System.Drawing.Point(537, 375);
            this.CompanyTelNo2_tEdit.MaxLength = 16;
            this.CompanyTelNo2_tEdit.Name = "CompanyTelNo2_tEdit";
            this.CompanyTelNo2_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo2_tEdit.TabIndex = 16;
            // 
            // CompanyTelNo3_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.Appearance = appearance47;
            this.CompanyTelNo3_tEdit.AutoSelect = true;
            this.CompanyTelNo3_tEdit.DataText = "";
            this.CompanyTelNo3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo3_tEdit.Location = new System.Drawing.Point(537, 405);
            this.CompanyTelNo3_tEdit.MaxLength = 16;
            this.CompanyTelNo3_tEdit.Name = "CompanyTelNo3_tEdit";
            this.CompanyTelNo3_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo3_tEdit.TabIndex = 18;
            // 
            // ultraLabel3
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance35;
            this.ultraLabel3.Location = new System.Drawing.Point(222, 285);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(43, 23);
            this.ultraLabel3.TabIndex = 82;
            this.ultraLabel3.Text = "丁目";
            this.ultraLabel3.Visible = false;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(20, 217);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(705, 3);
            this.ultraLabel17.TabIndex = 76;
            // 
            // AddressGuide_Button
            // 
            this.AddressGuide_Button.Location = new System.Drawing.Point(312, 225);
            this.AddressGuide_Button.Name = "AddressGuide_Button";
            this.AddressGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.AddressGuide_Button.TabIndex = 9;
            this.AddressGuide_Button.Text = "?";
            this.AddressGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AddressGuide_Button.Visible = false;
            // 
            // PostNo_Title_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.PostNo_Title_Label.Appearance = appearance4;
            this.PostNo_Title_Label.Location = new System.Drawing.Point(20, 225);
            this.PostNo_Title_Label.Name = "PostNo_Title_Label";
            this.PostNo_Title_Label.Size = new System.Drawing.Size(100, 24);
            this.PostNo_Title_Label.TabIndex = 77;
            this.PostNo_Title_Label.Text = "郵便番号";
            // 
            // Address_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.Address_Title_Label.Appearance = appearance6;
            this.Address_Title_Label.Location = new System.Drawing.Point(20, 255);
            this.Address_Title_Label.Name = "Address_Title_Label";
            this.Address_Title_Label.Size = new System.Drawing.Size(91, 24);
            this.Address_Title_Label.TabIndex = 78;
            this.Address_Title_Label.Text = "住所";
            // 
            // CompanyTel1Title_Title_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.CompanyTel1Title_Title_Label.Appearance = appearance7;
            this.CompanyTel1Title_Title_Label.Location = new System.Drawing.Point(20, 345);
            this.CompanyTel1Title_Title_Label.Name = "CompanyTel1Title_Title_Label";
            this.CompanyTel1Title_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.CompanyTel1Title_Title_Label.TabIndex = 79;
            this.CompanyTel1Title_Title_Label.Text = "電話番号１タイトル";
            // 
            // CompanyTel2Title_Title_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.CompanyTel2Title_Title_Label.Appearance = appearance8;
            this.CompanyTel2Title_Title_Label.Location = new System.Drawing.Point(20, 375);
            this.CompanyTel2Title_Title_Label.Name = "CompanyTel2Title_Title_Label";
            this.CompanyTel2Title_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.CompanyTel2Title_Title_Label.TabIndex = 80;
            this.CompanyTel2Title_Title_Label.Text = "電話番号２タイトル";
            // 
            // CompanyTel3Title_Title_Label
            // 
            appearance71.TextVAlignAsString = "Middle";
            this.CompanyTel3Title_Title_Label.Appearance = appearance71;
            this.CompanyTel3Title_Title_Label.Location = new System.Drawing.Point(20, 405);
            this.CompanyTel3Title_Title_Label.Name = "CompanyTel3Title_Title_Label";
            this.CompanyTel3Title_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.CompanyTel3Title_Title_Label.TabIndex = 81;
            this.CompanyTel3Title_Title_Label.Text = "電話番号３タイトル";
            // 
            // DataSaveMonths_Title_Label
            // 
            appearance81.TextVAlignAsString = "Middle";
            this.DataSaveMonths_Title_Label.Appearance = appearance81;
            this.DataSaveMonths_Title_Label.Location = new System.Drawing.Point(20, 435);
            this.DataSaveMonths_Title_Label.Name = "DataSaveMonths_Title_Label";
            this.DataSaveMonths_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.DataSaveMonths_Title_Label.TabIndex = 231;
            this.DataSaveMonths_Title_Label.Text = "データ保存月数";
            // 
            // CaPrtsDtSaveMonths_Title_Label
            // 
            appearance60.TextVAlignAsString = "Middle";
            this.CaPrtsDtSaveMonths_Title_Label.Appearance = appearance60;
            this.CaPrtsDtSaveMonths_Title_Label.Location = new System.Drawing.Point(20, 495);
            this.CaPrtsDtSaveMonths_Title_Label.Name = "CaPrtsDtSaveMonths_Title_Label";
            this.CaPrtsDtSaveMonths_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.CaPrtsDtSaveMonths_Title_Label.TabIndex = 232;
            this.CaPrtsDtSaveMonths_Title_Label.Text = "車輌部品保存月数";
            // 
            // ResultDtSaveMonths_Title_Label
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ResultDtSaveMonths_Title_Label.Appearance = appearance58;
            this.ResultDtSaveMonths_Title_Label.Location = new System.Drawing.Point(20, 465);
            this.ResultDtSaveMonths_Title_Label.Name = "ResultDtSaveMonths_Title_Label";
            this.ResultDtSaveMonths_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.ResultDtSaveMonths_Title_Label.TabIndex = 233;
            this.ResultDtSaveMonths_Title_Label.Text = "実績データ保存月数";
            // 
            // MasterSaveMonths_Title_Label
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.MasterSaveMonths_Title_Label.Appearance = appearance53;
            this.MasterSaveMonths_Title_Label.Location = new System.Drawing.Point(20, 525);
            this.MasterSaveMonths_Title_Label.Name = "MasterSaveMonths_Title_Label";
            this.MasterSaveMonths_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.MasterSaveMonths_Title_Label.TabIndex = 234;
            this.MasterSaveMonths_Title_Label.Text = "マスタ保存月数";
            // 
            // RateProtyIndex_Title_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.RateProtyIndex_Title_Label.Appearance = appearance9;
            this.RateProtyIndex_Title_Label.Location = new System.Drawing.Point(20, 563);
            this.RateProtyIndex_Title_Label.Name = "RateProtyIndex_Title_Label";
            this.RateProtyIndex_Title_Label.Size = new System.Drawing.Size(145, 24);
            this.RateProtyIndex_Title_Label.TabIndex = 235;
            this.RateProtyIndex_Title_Label.Text = "掛率優先順位";
            // 
            // RateProtyIndex_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateProtyIndex_tComboEditor.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateProtyIndex_tComboEditor.Appearance = appearance2;
            this.RateProtyIndex_tComboEditor.BackColor = System.Drawing.Color.White;
            this.RateProtyIndex_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RateProtyIndex_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateProtyIndex_tComboEditor.ItemAppearance = appearance3;
            this.RateProtyIndex_tComboEditor.Location = new System.Drawing.Point(182, 562);
            this.RateProtyIndex_tComboEditor.MaxDropDownItems = 18;
            this.RateProtyIndex_tComboEditor.Name = "RateProtyIndex_tComboEditor";
            this.RateProtyIndex_tComboEditor.Size = new System.Drawing.Size(175, 24);
            this.RateProtyIndex_tComboEditor.TabIndex = 23;
            // 
            // ultraLabel10
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance79;
            this.ultraLabel10.Location = new System.Drawing.Point(217, 435);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel10.TabIndex = 241;
            this.ultraLabel10.Text = "ケ月保存する";
            // 
            // ultraLabel11
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance66;
            this.ultraLabel11.Location = new System.Drawing.Point(217, 465);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel11.TabIndex = 242;
            this.ultraLabel11.Text = "ケ月保存する";
            // 
            // ultraLabel12
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance80;
            this.ultraLabel12.Location = new System.Drawing.Point(217, 495);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel12.TabIndex = 243;
            this.ultraLabel12.Text = "ケ月保存する";
            // 
            // ultraLabel13
            // 
            appearance78.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance78;
            this.ultraLabel13.Location = new System.Drawing.Point(217, 525);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel13.TabIndex = 244;
            this.ultraLabel13.Text = "ケ月保存する";
            // 
            // DataCompressDt_Title_Label
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.DataCompressDt_Title_Label.Appearance = appearance84;
            this.DataCompressDt_Title_Label.Location = new System.Drawing.Point(360, 435);
            this.DataCompressDt_Title_Label.Name = "DataCompressDt_Title_Label";
            this.DataCompressDt_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.DataCompressDt_Title_Label.TabIndex = 245;
            this.DataCompressDt_Title_Label.Text = "データ圧縮日";
            // 
            // ResultDtCompressDt_Title_Label
            // 
            appearance83.TextVAlignAsString = "Middle";
            this.ResultDtCompressDt_Title_Label.Appearance = appearance83;
            this.ResultDtCompressDt_Title_Label.Location = new System.Drawing.Point(360, 465);
            this.ResultDtCompressDt_Title_Label.Name = "ResultDtCompressDt_Title_Label";
            this.ResultDtCompressDt_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.ResultDtCompressDt_Title_Label.TabIndex = 246;
            this.ResultDtCompressDt_Title_Label.Text = "実績データ圧縮日";
            // 
            // CaPrtsDtCompressDt_Title_Label
            // 
            appearance82.TextVAlignAsString = "Middle";
            this.CaPrtsDtCompressDt_Title_Label.Appearance = appearance82;
            this.CaPrtsDtCompressDt_Title_Label.Location = new System.Drawing.Point(360, 495);
            this.CaPrtsDtCompressDt_Title_Label.Name = "CaPrtsDtCompressDt_Title_Label";
            this.CaPrtsDtCompressDt_Title_Label.Size = new System.Drawing.Size(171, 24);
            this.CaPrtsDtCompressDt_Title_Label.TabIndex = 247;
            this.CaPrtsDtCompressDt_Title_Label.Text = "車輌部品データ圧縮日";
            // 
            // MasterCompressDt_Title_Label
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.MasterCompressDt_Title_Label.Appearance = appearance77;
            this.MasterCompressDt_Title_Label.Location = new System.Drawing.Point(360, 525);
            this.MasterCompressDt_Title_Label.Name = "MasterCompressDt_Title_Label";
            this.MasterCompressDt_Title_Label.Size = new System.Drawing.Size(159, 24);
            this.MasterCompressDt_Title_Label.TabIndex = 248;
            this.MasterCompressDt_Title_Label.Text = "マスタ圧縮日";
            // 
            // DataCompressDt_tDateEdit
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance91.TextHAlignAsString = "Right";
            this.DataCompressDt_tDateEdit.ActiveEditAppearance = appearance91;
            this.DataCompressDt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.DataCompressDt_tDateEdit.CalendarDisp = true;
            appearance92.BackColor = System.Drawing.Color.White;
            appearance92.TextHAlignAsString = "Right";
            appearance92.TextVAlignAsString = "Middle";
            this.DataCompressDt_tDateEdit.EditAppearance = appearance92;
            this.DataCompressDt_tDateEdit.Enabled = false;
            this.DataCompressDt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.DataCompressDt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DataCompressDt_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance93.TextHAlignAsString = "Left";
            appearance93.TextVAlignAsString = "Middle";
            this.DataCompressDt_tDateEdit.LabelAppearance = appearance93;
            this.DataCompressDt_tDateEdit.Location = new System.Drawing.Point(537, 435);
            this.DataCompressDt_tDateEdit.Name = "DataCompressDt_tDateEdit";
            this.DataCompressDt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.DataCompressDt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.DataCompressDt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.DataCompressDt_tDateEdit.TabIndex = 20;
            this.DataCompressDt_tDateEdit.TabStop = true;
            // 
            // ResultDtCompressDt_tDateEdit
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance88.TextHAlignAsString = "Right";
            this.ResultDtCompressDt_tDateEdit.ActiveEditAppearance = appearance88;
            this.ResultDtCompressDt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ResultDtCompressDt_tDateEdit.CalendarDisp = true;
            appearance89.BackColor = System.Drawing.Color.White;
            appearance89.TextHAlignAsString = "Right";
            appearance89.TextVAlignAsString = "Middle";
            this.ResultDtCompressDt_tDateEdit.EditAppearance = appearance89;
            this.ResultDtCompressDt_tDateEdit.Enabled = false;
            this.ResultDtCompressDt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ResultDtCompressDt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ResultDtCompressDt_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance90.TextHAlignAsString = "Left";
            appearance90.TextVAlignAsString = "Middle";
            this.ResultDtCompressDt_tDateEdit.LabelAppearance = appearance90;
            this.ResultDtCompressDt_tDateEdit.Location = new System.Drawing.Point(537, 465);
            this.ResultDtCompressDt_tDateEdit.Name = "ResultDtCompressDt_tDateEdit";
            this.ResultDtCompressDt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ResultDtCompressDt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.ResultDtCompressDt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ResultDtCompressDt_tDateEdit.TabIndex = 22;
            this.ResultDtCompressDt_tDateEdit.TabStop = true;
            // 
            // CaPrtsDtCompressDt_tDateEdit
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance85.TextHAlignAsString = "Right";
            this.CaPrtsDtCompressDt_tDateEdit.ActiveEditAppearance = appearance85;
            this.CaPrtsDtCompressDt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.CaPrtsDtCompressDt_tDateEdit.CalendarDisp = true;
            appearance86.BackColor = System.Drawing.Color.White;
            appearance86.TextHAlignAsString = "Right";
            appearance86.TextVAlignAsString = "Middle";
            this.CaPrtsDtCompressDt_tDateEdit.EditAppearance = appearance86;
            this.CaPrtsDtCompressDt_tDateEdit.Enabled = false;
            this.CaPrtsDtCompressDt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.CaPrtsDtCompressDt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CaPrtsDtCompressDt_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance87.TextHAlignAsString = "Left";
            appearance87.TextVAlignAsString = "Middle";
            this.CaPrtsDtCompressDt_tDateEdit.LabelAppearance = appearance87;
            this.CaPrtsDtCompressDt_tDateEdit.Location = new System.Drawing.Point(537, 495);
            this.CaPrtsDtCompressDt_tDateEdit.Name = "CaPrtsDtCompressDt_tDateEdit";
            this.CaPrtsDtCompressDt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.CaPrtsDtCompressDt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.CaPrtsDtCompressDt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.CaPrtsDtCompressDt_tDateEdit.TabIndex = 24;
            this.CaPrtsDtCompressDt_tDateEdit.TabStop = true;
            // 
            // MasterCompressDt_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.MasterCompressDt_tDateEdit.ActiveEditAppearance = appearance10;
            this.MasterCompressDt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.MasterCompressDt_tDateEdit.CalendarDisp = true;
            appearance11.BackColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.MasterCompressDt_tDateEdit.EditAppearance = appearance11;
            this.MasterCompressDt_tDateEdit.Enabled = false;
            this.MasterCompressDt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.MasterCompressDt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MasterCompressDt_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.MasterCompressDt_tDateEdit.LabelAppearance = appearance12;
            this.MasterCompressDt_tDateEdit.Location = new System.Drawing.Point(537, 525);
            this.MasterCompressDt_tDateEdit.Name = "MasterCompressDt_tDateEdit";
            this.MasterCompressDt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.MasterCompressDt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.MasterCompressDt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.MasterCompressDt_tDateEdit.TabIndex = 26;
            this.MasterCompressDt_tDateEdit.TabStop = true;
            // 
            // DataSaveMonths_tEdit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance48.TextHAlignAsString = "Right";
            appearance48.TextVAlignAsString = "Middle";
            this.DataSaveMonths_tEdit.ActiveAppearance = appearance48;
            appearance49.BackColor = System.Drawing.Color.White;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextHAlignAsString = "Right";
            appearance49.TextVAlignAsString = "Middle";
            this.DataSaveMonths_tEdit.Appearance = appearance49;
            this.DataSaveMonths_tEdit.AutoSelect = true;
            this.DataSaveMonths_tEdit.BackColor = System.Drawing.Color.White;
            this.DataSaveMonths_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.DataSaveMonths_tEdit.DataText = "";
            this.DataSaveMonths_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DataSaveMonths_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DataSaveMonths_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DataSaveMonths_tEdit.Location = new System.Drawing.Point(182, 435);
            this.DataSaveMonths_tEdit.MaxLength = 2;
            this.DataSaveMonths_tEdit.Name = "DataSaveMonths_tEdit";
            this.DataSaveMonths_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DataSaveMonths_tEdit.Size = new System.Drawing.Size(28, 24);
            this.DataSaveMonths_tEdit.TabIndex = 19;
            this.DataSaveMonths_tEdit.Leave += new System.EventHandler(this.DataSaveMonths_tEdit_Leave);
            // 
            // ResultDtSaveMonths_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.TextHAlignAsString = "Right";
            appearance50.TextVAlignAsString = "Middle";
            this.ResultDtSaveMonths_tEdit.ActiveAppearance = appearance50;
            appearance52.BackColor = System.Drawing.Color.White;
            appearance52.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            appearance52.TextHAlignAsString = "Right";
            appearance52.TextVAlignAsString = "Middle";
            this.ResultDtSaveMonths_tEdit.Appearance = appearance52;
            this.ResultDtSaveMonths_tEdit.AutoSelect = true;
            this.ResultDtSaveMonths_tEdit.BackColor = System.Drawing.Color.White;
            this.ResultDtSaveMonths_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.ResultDtSaveMonths_tEdit.DataText = "";
            this.ResultDtSaveMonths_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ResultDtSaveMonths_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ResultDtSaveMonths_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ResultDtSaveMonths_tEdit.Location = new System.Drawing.Point(182, 465);
            this.ResultDtSaveMonths_tEdit.MaxLength = 2;
            this.ResultDtSaveMonths_tEdit.Name = "ResultDtSaveMonths_tEdit";
            this.ResultDtSaveMonths_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ResultDtSaveMonths_tEdit.Size = new System.Drawing.Size(28, 24);
            this.ResultDtSaveMonths_tEdit.TabIndex = 20;
            this.ResultDtSaveMonths_tEdit.Leave += new System.EventHandler(this.ResultDtSaveMonths_tEdit_Leave);
            // 
            // CaPrtsDtSaveMonths_tEdit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance72.TextHAlignAsString = "Right";
            appearance72.TextVAlignAsString = "Middle";
            this.CaPrtsDtSaveMonths_tEdit.ActiveAppearance = appearance72;
            appearance73.BackColor = System.Drawing.Color.White;
            appearance73.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance73.ForeColor = System.Drawing.Color.Black;
            appearance73.ForeColorDisabled = System.Drawing.Color.Black;
            appearance73.TextHAlignAsString = "Right";
            appearance73.TextVAlignAsString = "Middle";
            this.CaPrtsDtSaveMonths_tEdit.Appearance = appearance73;
            this.CaPrtsDtSaveMonths_tEdit.AutoSelect = true;
            this.CaPrtsDtSaveMonths_tEdit.BackColor = System.Drawing.Color.White;
            this.CaPrtsDtSaveMonths_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CaPrtsDtSaveMonths_tEdit.DataText = "";
            this.CaPrtsDtSaveMonths_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CaPrtsDtSaveMonths_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CaPrtsDtSaveMonths_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CaPrtsDtSaveMonths_tEdit.Location = new System.Drawing.Point(182, 495);
            this.CaPrtsDtSaveMonths_tEdit.MaxLength = 2;
            this.CaPrtsDtSaveMonths_tEdit.Name = "CaPrtsDtSaveMonths_tEdit";
            this.CaPrtsDtSaveMonths_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CaPrtsDtSaveMonths_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CaPrtsDtSaveMonths_tEdit.TabIndex = 21;
            this.CaPrtsDtSaveMonths_tEdit.Leave += new System.EventHandler(this.CaPrtsDtSaveMonths_tEdit_Leave);
            // 
            // MasterSaveMonths_tEdit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.MasterSaveMonths_tEdit.ActiveAppearance = appearance21;
            appearance51.BackColor = System.Drawing.Color.White;
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Right";
            appearance51.TextVAlignAsString = "Middle";
            this.MasterSaveMonths_tEdit.Appearance = appearance51;
            this.MasterSaveMonths_tEdit.AutoSelect = true;
            this.MasterSaveMonths_tEdit.BackColor = System.Drawing.Color.White;
            this.MasterSaveMonths_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.MasterSaveMonths_tEdit.DataText = "";
            this.MasterSaveMonths_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MasterSaveMonths_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MasterSaveMonths_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MasterSaveMonths_tEdit.Location = new System.Drawing.Point(182, 525);
            this.MasterSaveMonths_tEdit.MaxLength = 2;
            this.MasterSaveMonths_tEdit.Name = "MasterSaveMonths_tEdit";
            this.MasterSaveMonths_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MasterSaveMonths_tEdit.Size = new System.Drawing.Size(28, 24);
            this.MasterSaveMonths_tEdit.TabIndex = 22;
            this.MasterSaveMonths_tEdit.Leave += new System.EventHandler(this.MasterSaveMonths_tEdit_Leave);
            // 
            // SFUKN09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(748, 656);
            this.Controls.Add(this.MasterSaveMonths_tEdit);
            this.Controls.Add(this.CaPrtsDtSaveMonths_tEdit);
            this.Controls.Add(this.ResultDtSaveMonths_tEdit);
            this.Controls.Add(this.DataSaveMonths_tEdit);
            this.Controls.Add(this.MasterCompressDt_tDateEdit);
            this.Controls.Add(this.CaPrtsDtCompressDt_tDateEdit);
            this.Controls.Add(this.ResultDtCompressDt_tDateEdit);
            this.Controls.Add(this.DataCompressDt_tDateEdit);
            this.Controls.Add(this.MasterCompressDt_Title_Label);
            this.Controls.Add(this.CaPrtsDtCompressDt_Title_Label);
            this.Controls.Add(this.ResultDtCompressDt_Title_Label);
            this.Controls.Add(this.DataCompressDt_Title_Label);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.RateProtyIndex_tComboEditor);
            this.Controls.Add(this.RateProtyIndex_Title_Label);
            this.Controls.Add(this.MasterSaveMonths_Title_Label);
            this.Controls.Add(this.ResultDtSaveMonths_Title_Label);
            this.Controls.Add(this.CaPrtsDtSaveMonths_Title_Label);
            this.Controls.Add(this.DataSaveMonths_Title_Label);
            this.Controls.Add(this.CompanyTel1_Title_Label);
            this.Controls.Add(this.CompanyTel2_Title_Label);
            this.Controls.Add(this.CompanyTel3_Title_Label);
            this.Controls.Add(this.PostNo_Border_Label);
            this.Controls.Add(this.CompanyTelNo1_tEdit);
            this.Controls.Add(this.CompanyTelTitle3_tEdit);
            this.Controls.Add(this.CompanyTelTitle2_tEdit);
            this.Controls.Add(this.CompanyTelTitle1_tEdit);
            this.Controls.Add(this.Address1_tEdit);
            this.Controls.Add(this.PostNo_tEdit);
            this.Controls.Add(this.PostNoMark_tEdit);
            this.Controls.Add(this.Address3_tEdit);
            this.Controls.Add(this.Address4_tEdit);
            this.Controls.Add(this.CompanyTelNo2_tEdit);
            this.Controls.Add(this.CompanyTelNo3_tEdit);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.AddressGuide_Button);
            this.Controls.Add(this.PostNo_Title_Label);
            this.Controls.Add(this.Address_Title_Label);
            this.Controls.Add(this.CompanyTel1Title_Title_Label);
            this.Controls.Add(this.CompanyTel2Title_Title_Label);
            this.Controls.Add(this.CompanyTel3Title_Title_Label);
            this.Controls.Add(this.SecMngDiv_tComboEditor);
            this.Controls.Add(this.SecMngDiv_Title);
            this.Controls.Add(this.StartMonthDiv_Title);
            this.Controls.Add(this.StartMonthDiv_tComboEditor);
            this.Controls.Add(this.CompanyBiginDate_Title);
            this.Controls.Add(this.CompanyBiginDate_tDateEdit);
            this.Controls.Add(this.FinancialYear_Title);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.FinancialYear_tNedit);
            this.Controls.Add(this.CompanyName2_tEdit);
            this.Controls.Add(this.CompanyName1_tEdit);
            this.Controls.Add(this.CompanyName2_Title);
            this.Controls.Add(this.CompanyName1_Title);
            this.Controls.Add(this.BiginMonth2_tNedit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.BiginMonth2_Title);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.BiginMonth_tNedit);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.BiginMonth_Title);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKN09000UA";
            this.Text = "自社設定";
            this.Load += new System.EventHandler(this.SFUKN09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKN09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKN09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.BiginMonth_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiginMonth2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinancialYear_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecMngDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateProtyIndex_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSaveMonths_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDtSaveMonths_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaPrtsDtSaveMonths_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterSaveMonths_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members
		private CompanyInf companyInf;
		private CompanyInfAcs companyInfAcs;
		private string _enterpriseCode;

		//比較用clone
		private CompanyInf _companyInfClone;

		// プロパティ用
		private bool _canPrint;
		/// <summary>
		/// 終了プロパティ
		/// </summary>
		/// <remarks>
		/// アセンブリを終了するか、しないかを取得又はセットします。
		/// </remarks>
		private bool _canClose;

		private const string HTML_HEADER_TITLE = "設定項目";
		private const string HTML_HEADER_VALUE = "設定値";
		private const string HTML_UNREGISTER = "未設定";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

        // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
        private const string NEXT_YEAR  = "翌年";
        private const string PREV_YEAR  = "前年";
        private const string NEXT_MONTH = "翌月";
        private const string PREV_MONTH = "前月";
        // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
        // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
        private const string SECMNG_SEC = "拠点";
        private const string SECMNG_SUB = "拠点＋部";
        //private const string SECMNG_MIN = "拠点＋部＋課";  // DEL 2008/06/03
        // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

        // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
        private bool _changeFlg = false;					// コード変更フラグ
        // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
        //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
        private const string SECMNG_PROTY = "拠点優先";
        private const string SECMNG_MOSHI = "設定区分優先";
        private const string SAVE_MONTHS = "ケ月保存する";
        //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		private bool _changeFlg = false;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		#endregion

		# region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKN09000UA());
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
			get{ return _canPrint; }
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
			get{ return _canClose; }
			set{ _canClose = value; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		///	印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note			:	（未実装）</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.04.14</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
        }

        #region DEL 2008/09/12 Partsman用に変更
        /* --- DEL 2008/09/12 --------------------------------------------------------------------->>>>>
		/// <summary>
		///	HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note			:	ビュー用のＨＴＭＬコードを取得します。</br>
		/// <br>Programmer		:	小黒　大輔</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
			// tHtmlGenerate部品の引数を生成する
            // 2007.05.17  S.Koga  amend --------------------------------------
            //string [,] array = new string[4,2];
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //string[,] array = new string[7, 2];
            // 2008.01.11 修正 >>>>>>>>>>>>>>>>>>>>
            //string[,] array = new string[9, 2];
            string[,] array = new string[10, 2];
            // 2008.01.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // ----------------------------------------------------------------
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// tHtmlGenerate部品の引数を生成する
//			string [,] array = new string[19,2];
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
				
			array[0,0] = HTML_HEADER_TITLE;//「設定項目」
			array[0,1] = HTML_HEADER_VALUE;//「設定値」

            // 2007.05.17  S.Koga  add ----------------------------------------
            array[1, 0] = "企業コード";                         //企業コード
            // ----------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
			array[2,0] = this.TotalDay_Title.Text;					//自社締日
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
			//array[3,0] = this.BiginMonth_Title.Text;				//期首月
            array[3, 0] = this.FinancialYear_Title.Text;				    //会計年度
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //// 2007.04.10  S.Koga  add ----------------------------------------
            //array[4, 0] = this.BiginMonth2_Title.Text;           // 期首月２
            //// ----------------------------------------------------------------
            //
            //// 2007.05.17  S.Koga  add ----------------------------------------
            //array[5, 0] = this.CompanyName1_Title.Text;         // 会社名１
            //array[6, 0] = this.CompanyName2_Title.Text;         // 会社名２
            //// ----------------------------------------------------------------

            array[4, 0] = this.CompanyBiginDate_Title.Text;         // 期首年月日
            array[5, 0] = this.StartYearDiv_Title.Text;             // 開始年区分
            array[6, 0] = this.StartMonthDiv_Title.Text;            // 開始月区分

            array[7, 0] = this.CompanyName1_Title.Text;             // 会社名１
            array[8, 0] = this.CompanyName2_Title.Text;             // 会社名２
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            array[9, 0] = this.SecMngDiv_Title.Text;             // 部署管理区分
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			array[1,0] = this.CompamyName_Title_Label.Text + "１";	//自社名称１
//			array[2,0] = this.CompamyName_Title_Label.Text + "２";	//自社名称２
//			array[3,0] = this.PostNo_Title_Label.Text;　　　　		//郵便番号
//			array[4,0] = this.Address_Title_Label.Text;					//住所タイトル
//			array[5,0] = "  ";										//
//			array[6,0] = this.Address4_Title.Text;					//住所４アパート
//			array[7,0] = this.Tel1_Title_Label.Text;     	        //電話番号１タイトル
//			array[8,0] = this.Tel2_Title_Label.Text;	            //電話番号２タイトル
//			array[9,0] = this.Tel3_Title_Label.Text;		        //電話番号３タイトル
//			array[10,0] = this.TranfarGuid_Title.Text;				//銀行案内文
//			array[11,0] = this.AccountNo1_Title.Text;				//銀行口座１
//			array[12,0] = this.AccountNo2_Title.Text;				//銀行口座２
//			array[13,0] = this.AccountNo3_Title.Text;				//銀行口座３
//			array[14,0] = this.SetNote1_Title.Text;					//適用１
//			array[15,0] = "  ";										//適用２
//			array[16,0] = this.Pr_Title.Text;						//自社ＰＲ
//			array[17,0] = this.TotalDay_Title.Text;					//自社締日
//			array[18,0] = this.BiginMonth_Title.Text;				//期首月
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			int status = this.companyInfAcs.Read(out this.companyInf,this._enterpriseCode);

			if (status == 0)
			{
                // 2007.05.17  S.Koga  add ------------------------------------
                array[1, 1] = this._enterpriseCode.ToString();
                // ------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
				array[2,1] = companyInf.CompanyTotalDay.ToString()+"日";
                // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
                //array[3, 1] = companyInf.CompanyBiginMonth.ToString() + "月";
                if (companyInf.FinancialYear == 0)
                {
                    array[3, 1] = "";
                }
                else
                {
                    array[3, 1] = companyInf.FinancialYear.ToString() + "年";
                }
                // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
                //// 2007.04.13  S.Koga amend -----------------------------------
                //// 2007.04.10  S.Koga  add ------------------------------------
                ////array[3, 1] = companyInf.CompRestBiginMonth.ToString()+"月";
                //// ------------------------------------------------------------
                //array[4, 1] = companyInf.CompanyBiginMonth2.ToString() + "月";
                //// ------------------------------------------------------------
                //
                //// 2007.05.17  S.Koga  add ------------------------------------
                //array[5, 1] = companyInf.CompanyName1.ToString();
                //array[6, 1] = companyInf.CompanyName2.ToString();
                //// ------------------------------------------------------------

                if (companyInf.CompanyBiginDate == 0)
                {
                    array[4, 1] = "";
                }
                else
                {
                    int workYear  =  companyInf.CompanyBiginDate / 10000;
                    int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                    int workDay   =  companyInf.CompanyBiginDate % 100;
                    array[4, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }

                if (companyInf.StartYearDiv == 0)
                {
                    array[5, 1] = PREV_YEAR;
                }
                else
                {
                    array[5, 1] = NEXT_YEAR;
                }

                if (companyInf.StartMonthDiv == 0)
                {
                    if (companyInf.CompanyBiginDate == 0)
                    {
                        array[6, 1] = PREV_MONTH;
                    }
                    else
                    {
                        int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                        int workDay = companyInf.CompanyBiginDate % 100;
                        if (workMonth == 1)
                        {
                            workMonth = 12;
                        }
                        else
                        {
                            workMonth = workMonth - 1;
                        }
                        array[6, 1] = PREV_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）";
                    }
                }
                else
                {
                    if (companyInf.CompanyBiginDate == 0)
                    {
                        array[6, 1] = NEXT_MONTH;
                    }
                    else
                    {
                        int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                        int workDay = companyInf.CompanyBiginDate % 100;
                        array[6, 1] = NEXT_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）";
                    }
                }

                array[7, 1] = companyInf.CompanyName1.ToString();
                array[8, 1] = companyInf.CompanyName2.ToString();
                // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
                // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
                if (companyInf.SecMngDiv == 0)
                {
                    array[9, 1] = SECMNG_SEC;
                }
                else if (companyInf.SecMngDiv == 1)
                {
                    array[9, 1] = SECMNG_SUB;
                }
                else
                {
                    array[9, 1] = SECMNG_MIN;
                }
                // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//				array[1,1] = companyInf.CompanyName1;
//				array[2,1] = companyInf.CompanyName2;
//				array[3,1] = companyInf.PostNo;
//				array[4,1] = companyInf.Address1;
//				//array[5,1] = companyInf.Address2+"丁目"+companyInf.Address3;				// 2005.06.23 TOUMA DEL 住所２が「0」の時、フレーム表示時には"○丁目"は表示しないように変更
//
//				// 2005.06.23 TOUMA ADD 住所２が「0」の時、フレーム表示時には"○丁目"は表示しないように変更 >>>>>>>>>> START
//				if ( companyInf.Address2 == 0 )
//				{
//					array[5,1] = companyInf.Address3;
//				}
//				else
//				{
//					array[5,1] = companyInf.Address2 + "丁目" + companyInf.Address3;
//				}
//				// 2005.06.23 TOUMA ADD 住所２が「0」の時、フレーム表示時には"○丁目"は表示しないように変更 <<<<<<<<<< END
//
//				array[6,1] = companyInf.Address4;
//				array[7,1] = companyInf.CompanyTelTitle1+"："+ companyInf.CompanyTelNo1;
//				array[8,1] = companyInf.CompanyTelTitle2+"："+ companyInf.CompanyTelNo2;
//				array[9,1] = companyInf.CompanyTelTitle3+"："+ companyInf.CompanyTelNo3;
//				array[10,1] = companyInf.TransferGuidance;
//				array[11,1] = companyInf.AccountNoInfo1;
//				array[12,1] = companyInf.AccountNoInfo2;
//				array[13,1] = companyInf.AccountNoInfo3;
//				array[14,1] = companyInf.CompanySetNote1;
//				array[15,1] = companyInf.CompanySetNote2;
//				array[16,1] = companyInf.CompanyPr;
//				array[17,1] = companyInf.CompanyTotalDay.ToString()+"日";
//				array[18,1] = companyInf.CompanyBiginMonth.ToString()+"月";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			}
			else
			{
                // 2007.05.17  S.Koga  add ------------------------------------
                array[1, 1] = HTML_UNREGISTER;
                // ------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
				array[2,1] = HTML_UNREGISTER;
				array[3,1] = HTML_UNREGISTER;
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                // 2007.04.10  S.Koga  add ------------------------------------
                array[4, 1] = HTML_UNREGISTER;
                // ------------------------------------------------------------

                // 2007.05.17  S.Koga  add ------------------------------------
                array[5, 1] = HTML_UNREGISTER;
                array[6, 1] = HTML_UNREGISTER;
                // ------------------------------------------------------------

                // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
                array[7, 1] = HTML_UNREGISTER;
                array[8, 1] = HTML_UNREGISTER;
                // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
                // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
                array[9, 1] = HTML_UNREGISTER;
                // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//				array[1,1] = HTML_UNREGISTER;
//				array[2,1] = HTML_UNREGISTER;
//				array[3,1] = HTML_UNREGISTER;
//				array[4,1] = HTML_UNREGISTER;
//				array[5,1] = HTML_UNREGISTER;
//				array[6,1] = HTML_UNREGISTER;
//				array[7,1] = HTML_UNREGISTER;
//				array[8,1] = HTML_UNREGISTER;
//				array[9,1] = HTML_UNREGISTER;
//				array[10,1] = HTML_UNREGISTER;
//				array[11,1] = HTML_UNREGISTER;
//				array[12,1] = HTML_UNREGISTER;
//				array[13,1] = HTML_UNREGISTER;
//				array[14,1] = HTML_UNREGISTER;
//				array[15,1] = HTML_UNREGISTER;
//				array[16,1] = HTML_UNREGISTER;
//				array[17,1] = HTML_UNREGISTER;
//				array[18,1] = HTML_UNREGISTER;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			}

			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);
			return outCode;
		}
           --- DEL 2008/09/12 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/12 Partsman用に変更

        // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        ///	HTMLコード取得処理
        /// </summary>
        /// <returns>HTMLコード</returns>
        /// <remarks>
        /// <br>Note			:	ビュー用のＨＴＭＬコードを取得します。</br>
        /// <br>Programmer		:	30414 忍 幸史</br>
        /// <br>Date			:	2008/09/12</br>
        /// </remarks>
        public string GetHtmlCode()
        {
            string outCode = "";

            //string[,] array = new string[18, 2];      //DEL 2011/07/22 zhouyu FOR 連番 42
            string[,] array = new string[27, 2];    //ADD 2011/07/22 zhouyu FOR 連番 42

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            array[0, 0] = HTML_HEADER_TITLE;//「設定項目」
            array[0, 1] = HTML_HEADER_VALUE;//「設定値」

            array[1, 0] = "企業コード";                         //企業コード
            //array[2, 0] = this.TotalDay_Title.Text;					//自社締日
            array[2, 0] = this.FinancialYear_Title.Text;				    //会計年度
            array[3, 0] = this.CompanyBiginDate_Title.Text;         // 期首年月日
            //array[5, 0] = this.StartYearDiv_Title.Text;             // 開始年区分
            array[4, 0] = this.StartMonthDiv_Title.Text;            // 開始月区分
            array[5, 0] = this.CompanyName1_Title.Text;             // 会社名１
            array[6, 0] = this.CompanyName2_Title.Text;             // 会社名２
            array[7, 0] = this.SecMngDiv_Title.Text;             // 部署管理区分
            array[8, 0] = this.PostNo_Title_Label.Text;
            array[9, 0] = this.Address_Title_Label.Text;
            array[10, 0] = "住所２";
            array[11, 0] = "住所３";
            array[12, 0] = this.CompanyTel1Title_Title_Label.Text;
            array[13, 0] = this.CompanyTel1_Title_Label.Text;
            array[14, 0] = this.CompanyTel2Title_Title_Label.Text;
            array[15, 0] = this.CompanyTel2_Title_Label.Text;
            array[16, 0] = this.CompanyTel3Title_Title_Label.Text;
            array[17, 0] = this.CompanyTel3_Title_Label.Text;
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            array[18, 0] = this.DataSaveMonths_Title_Label.Text;
            array[19, 0] = this.DataCompressDt_Title_Label.Text;
            array[20, 0] = this.ResultDtSaveMonths_Title_Label.Text;
            array[21, 0] = this.ResultDtCompressDt_Title_Label.Text;
            array[22, 0] = this.CaPrtsDtSaveMonths_Title_Label.Text;
            array[23, 0] = this.CaPrtsDtCompressDt_Title_Label.Text;
            array[24, 0] = this.MasterSaveMonths_Title_Label.Text;
            array[25, 0] = this.MasterCompressDt_Title_Label.Text;
            array[26, 0] = this.RateProtyIndex_Title_Label.Text;
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<

            int status = this.companyInfAcs.Read(out this.companyInf, this._enterpriseCode);
            if (status == 0)
            {
                array[1, 1] = this._enterpriseCode.ToString();
                //array[2, 1] = companyInf.CompanyTotalDay.ToString() + "日";
                if (companyInf.FinancialYear == 0)
                {
                    array[2, 1] = "";
                }
                else
                {
                    array[2, 1] = companyInf.FinancialYear.ToString() + "年";
                }
                if (companyInf.CompanyBiginDate == 0)
                {
                    array[3, 1] = "";
                }
                else
                {
                    int workYear = companyInf.CompanyBiginDate / 10000;
                    int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                    int workDay = companyInf.CompanyBiginDate % 100;
                    array[3, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }
                //if (companyInf.StartYearDiv == 0)
                //{
                //    if (companyInf.FinancialYear == 0)
                //    {
                //        // DEL 2008/10/28 不具合対応[7089] ↓
                //        //array[5, 1] = PREV_YEAR;
                //        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //        array[5, 1] = "";
                //        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //    }
                //    else
                //    {
                //        if (companyInf.CompanyBiginDate == 0)
                //        {
                //            // DEL 2008/10/28 不具合対応[7089] ↓
                //            //array[5, 1] = PREV_YEAR;
                //            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //            array[5, 1] = "";
                //            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //        }
                //        else
                //        {
                //            int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                //            // DEL 2008/10/28 不具合対応[7089] ↓
                //            //array[5, 1] = PREV_YEAR.ToString() + "（" + companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）";
                //            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //            if (workMonth == 1)
                //            {
                //                array[5, 1] = companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月～" +
                //                                companyInf.FinancialYear.ToString("0000") + "年12月";
                //            }
                //            else
                //            {
                //                array[5, 1] = companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月～" +
                //                            (companyInf.FinancialYear +1).ToString("0000") + "年" + (workMonth - 1).ToString("00") + "月";
                //            }
                //            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //        }
                //    }
                //}
                //else
                //{
                //    if (companyInf.FinancialYear == 0)
                //    {
                //        // DEL 2008/10/28 不具合対応[7089] ↓
                //        //array[5, 1] = NEXT_YEAR;
                //        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //        array[5, 1] = "";
                //        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //    }
                //    else
                //    {
                //        if (companyInf.CompanyBiginDate == 0)
                //        {
                //            // DEL 2008/10/28 不具合対応[7089] ↓
                //            //array[5, 1] = NEXT_YEAR;
                //            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //            array[5, 1] = "";
                //            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //        }
                //        else
                //        {
                //            int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                //            // DEL 2008/10/28 不具合対応[7089] ↓
                //            //array[5, 1] = NEXT_YEAR.ToString() + "（" + companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）";
                //            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                //            if (workMonth == 1)
                //            {
                //                array[5, 1] = (companyInf.FinancialYear -1).ToString("0000") + "年" + workMonth.ToString("00") + "月～" +
                //                                (companyInf.FinancialYear -1).ToString("0000") + "年12月";
                //            }
                //            else
                //            {
                //                array[5, 1] = (companyInf.FinancialYear - 1).ToString("0000") + "年" + workMonth.ToString("00") + "月～" +
                //                            companyInf.FinancialYear.ToString("0000") + "年" + (workMonth - 1).ToString("00") + "月";
                //            }
                //            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                //        }
                //    }
                //}
                if (companyInf.StartMonthDiv == 0)
                {
                    if (companyInf.CompanyBiginDate == 0)
                    {
                        // DEL 2008/10/28 不具合対応[7089] ↓
                        //array[6, 1] = PREV_MONTH;
                        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                        array[4, 1] = "";
                        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                    }
                    else
                    {
                        int workYear = companyInf.FinancialYear;              // ADD 2008/10/28 不具合対応[7089]
                        int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                        int workDay = companyInf.CompanyBiginDate % 100;
                        int edMonth = 0;        // ADD 2008/10/28 不具合対応[7089]

                        // DEL 2008/10/28 不具合対応[7089] ---------->>>>>
                        //if (workMonth == 1)
                        //{
                        //    workMonth = 12;     
                        //}
                        //else
                        //{
                        //    workMonth = workMonth - 1;  
                        //}
                        //array[6, 1] = PREV_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）";
                        // DEL 2008/10/28 不具合対応[7089] ----------<<<<<

                        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                        if (workMonth == 12)
                        {
                            edMonth = 1;
                        }
                        else
                        {
                            edMonth = workMonth + 1;
                        }

                        // 2010/01/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        int stMonth = 0;
                        if (workMonth == 1)
                        {
                            stMonth = 12;
                        }
                        else
                        {
                            stMonth = workMonth - 1;
                        }
                        // 2010/01/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (workDay == 1)
                        {
                            array[4, 1] = workMonth.ToString() + "月" + workDay.ToString() + "日～" +
                                        workMonth.ToString() + "月" + DateTime.DaysInMonth(workYear, workMonth).ToString() + "日";
                        }
                        else
                        {
                            // 2010/01/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //array[4, 1] = workMonth.ToString() + "月" + workDay.ToString() + "日～" +
                            //            edMonth.ToString() + "月" + (workDay-1).ToString() + "日";
                            array[4, 1] = stMonth.ToString() + "月" + workDay.ToString() + "日～" +
                                        workMonth.ToString() + "月" + (workDay - 1).ToString() + "日";
                            // 2010/01/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<

                    }
                }
                else
                {
                    if (companyInf.CompanyBiginDate == 0)
                    {
                        // DEL 2008/10/28 不具合対応[7089] ↓
                        //array[6, 1] = NEXT_MONTH;
                        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                        array[4, 1] = "";
                        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
                    }
                    else
                    {
                        int workYear = companyInf.FinancialYear;              // ADD 2008/10/28 不具合対応[7089]
                        int workMonth = (companyInf.CompanyBiginDate % 10000) / 100;
                        int workDay = companyInf.CompanyBiginDate % 100;

                        // DEL 2008/10/28 不具合対応[7089] ↓
                        //array[6, 1] = NEXT_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）";

                        // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                        int stMonth = 0;        // ADD 2008/10/28 不具合対応[7089]
                        if (workMonth == 1)
                        {
                            stMonth = 12;
                        }
                        else
                        {
                            stMonth = workMonth - 1;
                        }

                        // 2010/01/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        int edMonth = 0;
                        if (workMonth == 12)
                        {
                            edMonth = 1;
                        }
                        else
                        {
                            edMonth = workMonth + 1;
                        }
                        // 2010/01/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (workDay == 1)
                        {
                            array[4, 1] = workMonth.ToString() + "月" + workDay.ToString() + "日～" +
                                        workMonth.ToString() + "月" + DateTime.DaysInMonth(workYear, workMonth).ToString() + "日";
                        }
                        else
                        {
                            // 2010/01/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //array[4, 1] = stMonth.ToString() + "月" + workDay.ToString() + "日～" +
                            //            workMonth.ToString() + "月" + (workDay - 1).ToString() + "日";
                            array[4, 1] = workMonth.ToString() + "月" + workDay.ToString() + "日～" +
                                        edMonth.ToString() + "月" + (workDay - 1).ToString() + "日";
                            // 2010/01/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        // ADD 2008/10/28 不具合対応[7089] ----------<<<<<

                    }
                }
                array[5, 1] = companyInf.CompanyName1.ToString();
                array[6, 1] = companyInf.CompanyName2.ToString();
                if (companyInf.SecMngDiv == 0)
                {
                    array[7, 1] = SECMNG_SEC;
                }
                else if (companyInf.SecMngDiv == 1)
                {
                    array[7, 1] = SECMNG_SUB;
                }
                array[8, 1] = companyInf.PostNo.Trim();
                array[9, 1] = companyInf.Address1.Trim();
                array[10, 1] = companyInf.Address3.Trim();
                array[11, 1] = companyInf.Address4.Trim();
                array[12, 1] = companyInf.CompanyTelTitle1.Trim();
                array[13, 1] = companyInf.CompanyTelNo1.Trim();
                array[14, 1] = companyInf.CompanyTelTitle2.Trim();
                array[15, 1] = companyInf.CompanyTelNo2.Trim();
                array[16, 1] = companyInf.CompanyTelTitle3.Trim();
                array[17, 1] = companyInf.CompanyTelNo3.Trim();
                //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
                array[18, 1] = companyInf.DataSaveMonths.ToString() + " " + SAVE_MONTHS;
                if (companyInf.DataCompressDt == 0)
                {
                    array[19, 1] = "";
                }
                else
                {
                    int workYear = companyInf.DataCompressDt / 10000;
                    int workMonth = (companyInf.DataCompressDt % 10000) / 100;
                    int workDay = companyInf.DataCompressDt % 100;
                    array[19, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }
                array[20, 1] = companyInf.ResultDtSaveMonths.ToString() + " " + SAVE_MONTHS;
                if (companyInf.ResultDtCompressDt == 0)
                {
                    array[21, 1] = "";
                }
                else
                {
                    int workYear = companyInf.ResultDtCompressDt / 10000;
                    int workMonth = (companyInf.ResultDtCompressDt % 10000) / 100;
                    int workDay = companyInf.ResultDtCompressDt % 100;
                    array[21, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }
                array[22, 1] = companyInf.CaPrtsDtSaveMonths.ToString() + " " + SAVE_MONTHS;
                if (companyInf.CaPrtsDtCompressDt == 0)
                {
                    array[23, 1] = "";
                }
                else
                {
                    int workYear = companyInf.CaPrtsDtCompressDt / 10000;
                    int workMonth = (companyInf.CaPrtsDtCompressDt % 10000) / 100;
                    int workDay = companyInf.CaPrtsDtCompressDt % 100;
                    array[23, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }
                array[24, 1] = companyInf.MasterSaveMonths.ToString() + " "+SAVE_MONTHS;
                if (companyInf.MasterCompressDt == 0)
                {
                    array[25, 1] = "";
                }
                else
                {
                    int workYear = companyInf.MasterCompressDt / 10000;
                    int workMonth = (companyInf.MasterCompressDt % 10000) / 100;
                    int workDay = companyInf.MasterCompressDt % 100;
                    array[25, 1] = workYear.ToString() + "年" + workMonth.ToString() + "月" + workDay.ToString() + "日";
                }
                if (companyInf.RatePriorityDiv == 0)
                    array[26, 1] = SECMNG_PROTY;
                else if(companyInf.RatePriorityDiv == 1)
                    array[26, 1] = SECMNG_MOSHI;
                //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
            }
            else
            {
                array[1, 1] = HTML_UNREGISTER;
                array[2, 1] = HTML_UNREGISTER;
                array[3, 1] = HTML_UNREGISTER;
                array[4, 1] = HTML_UNREGISTER;
                array[5, 1] = HTML_UNREGISTER;
                array[6, 1] = HTML_UNREGISTER;
                array[7, 1] = HTML_UNREGISTER;
                array[8, 1] = HTML_UNREGISTER;
                array[9, 1] = HTML_UNREGISTER;
                array[10, 1] = HTML_UNREGISTER;
                array[11, 1] = HTML_UNREGISTER;
                array[12, 1] = HTML_UNREGISTER;
                array[13, 1] = HTML_UNREGISTER;
                array[14, 1] = HTML_UNREGISTER;
                array[15, 1] = HTML_UNREGISTER;
                array[16, 1] = HTML_UNREGISTER;
                array[17, 1] = HTML_UNREGISTER;
                //array[18, 1] = HTML_UNREGISTER;
                //array[19, 1] = HTML_UNREGISTER;
                //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
                array[18, 1] = HTML_UNREGISTER;
                array[19, 1] = HTML_UNREGISTER;
                array[20, 1] = HTML_UNREGISTER;
                array[21, 1] = HTML_UNREGISTER;
                array[22, 1] = HTML_UNREGISTER;
                array[23, 1] = HTML_UNREGISTER;
                array[24, 1] = HTML_UNREGISTER;
                array[25, 1] = HTML_UNREGISTER;
                array[26, 1] = HTML_UNREGISTER;
                //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);
            return outCode;
        }
        // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

		# endregion

		# region private Methods
		/// <summary>
		///	画面情報－自賠責設定クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	画面情報から自賠責設定クラスにデータを
		///							格納します。</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.04.14</br>
		/// </remarks>
		private void ScreenToCompanyInf()
		{
			if (companyInf == null)
			{
				// 新規の場合
				companyInf = new CompanyInf();
			}
			//ヘッダ部
			this.companyInf.EnterpriseCode = this._enterpriseCode;
			//			this.companyInf.FileHeaderGuid = System.Guid.NewGuid();	//GuidここでセットしてＯｋ?

			//明細部
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.companyInf.CompanyName1 = this.CompanyName1_tEdit.Text;
//			this.companyInf.CompanyName2 = this.CompanyName2_tEdit.Text;
//		
//			this.companyInf.PostNo = this.PostNo_tEdit.Text.Trim();
//			this.companyInf.Address1 = this.Address1_tEdit.Text;
//			this.companyInf.Address2 = this.Address2_tNedit.GetInt();
//			this.companyInf.Address3 = this.Address3_tEdit.Text;
//			this.companyInf.Address4 = this.Address4_tEdit.Text;
//			this.companyInf.CompanyTelTitle1 = this.TelTitle1_tEdit.Text;
//			this.companyInf.CompanyTelTitle2 = this.TelTitle2_tEdit.Text;
//			this.companyInf.CompanyTelTitle3 = this.TelTitle3_tEdit.Text;
//
//			this.companyInf.CompanyTelNo1 = this.TelNo1_tEdit.Text;
//			this.companyInf.CompanyTelNo2 = this.TelNo2_tEdit.Text;
//			this.companyInf.CompanyTelNo3 = this.TelNo3_tEdit.Text;
//										
//			this.companyInf.TransferGuidance = this.Transfer_tEdit.Text;
//			this.companyInf.AccountNoInfo1	= this.AccuntNo1_tEdit.Text;
//			this.companyInf.AccountNoInfo2	= this.AccuntNo2_tEdit.Text;
//			this.companyInf.AccountNoInfo3	= this.AccuntNo3_tEdit.Text;
//			this.companyInf.CompanySetNote1 = this.SetNote1_tEdit.Text;
//			this.companyInf.CompanySetNote2 = this.SetNote2_tEdit.Text;
//			this.companyInf.CompanyPr		= this.Pr_tEdit.Text;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.companyInf.CompanyTotalDay = this.TotalDay_tNedit.GetInt();
            // 期首年月日 - 1をセット(期首年月日が1日の場合、末日セット)
            if (CompanyBiginDate_tDateEdit.GetDateDay() == 1)
            {
                this.companyInf.CompanyTotalDay = 31;
            }
            else
            {
                this.companyInf.CompanyTotalDay = CompanyBiginDate_tDateEdit.GetDateDay() - 1;
            }
            
            
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //this.companyInf.CompanyBiginMonth = this.BiginMonth_tNedit.GetInt();
            this.companyInf.CompanyBiginMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth(); 
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.04.13  S.Koga  amend --------------------------------------
            // 2007.04.10  S.Koga  add ----------------------------------------
            //this.companyInf.CompRestBiginMonth = this.BiginMonth2_tNedit.GetInt();
            // ----------------------------------------------------------------
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //this.companyInf.CompanyBiginMonth2 = this.BiginMonth2_tNedit.GetInt();
            this.companyInf.CompanyBiginMonth2 = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // ----------------------------------------------------------------

            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            this.companyInf.FinancialYear = this.FinancialYear_tNedit.GetInt();
            this.companyInf.CompanyBiginDate = this.CompanyBiginDate_tDateEdit.GetLongDate();

            //this.companyInf.StartYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            // 会計年度と期首年月日の｢年｣を比較しセット
            if (this.FinancialYear_tNedit.GetInt() == this.CompanyBiginDate_tDateEdit.GetDateYear())
            {
                // 前年
                this.companyInf.StartYearDiv = 0;
            }
            else
            {
                // 翌年
                this.companyInf.StartYearDiv = 1;
            }
            
            this.companyInf.StartMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            this.companyInf.SecMngDiv = (Int32)this.SecMngDiv_tComboEditor.Value;
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.05.17  S.Koga  add ----------------------------------------
            this.companyInf.CompanyName1 = this.CompanyName1_tEdit.Text.TrimEnd();
            this.companyInf.CompanyName2 = this.CompanyName2_tEdit.Text.TrimEnd();
            // ----------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            companyInf.PostNo = this.PostNo_tEdit.DataText.Trim();
            companyInf.Address1 = this.Address1_tEdit.DataText.Trim();
            companyInf.Address3 = this.Address3_tEdit.DataText.Trim();
            companyInf.Address4 = this.Address4_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle1 = this.CompanyTelTitle1_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle2 = this.CompanyTelTitle2_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle3 = this.CompanyTelTitle3_tEdit.DataText.Trim();
            companyInf.CompanyTelNo1 = this.CompanyTelNo1_tEdit.DataText.Trim();
            companyInf.CompanyTelNo2 = this.CompanyTelNo2_tEdit.DataText.Trim();
            companyInf.CompanyTelNo3 = this.CompanyTelNo3_tEdit.DataText.Trim();
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            if (this.DataSaveMonths_tEdit.Text.Trim() == "")
                companyInf.DataSaveMonths = 0;
            else
                companyInf.DataSaveMonths = Convert.ToInt32(this.DataSaveMonths_tEdit.Text);
            companyInf.DataCompressDt = this.DataCompressDt_tDateEdit.GetLongDate();
            if (this.ResultDtSaveMonths_tEdit.Text.Trim() == "")
                companyInf.ResultDtSaveMonths = 0;
            else
                companyInf.ResultDtSaveMonths = Convert.ToInt32(this.ResultDtSaveMonths_tEdit.Text);
            companyInf.ResultDtCompressDt = this.ResultDtCompressDt_tDateEdit.GetLongDate();
            if (this.CaPrtsDtSaveMonths_tEdit.Text.Trim() == "")
                companyInf.CaPrtsDtSaveMonths = 0;
            else
                companyInf.CaPrtsDtSaveMonths = Convert.ToInt32(this.CaPrtsDtSaveMonths_tEdit.Text);
            companyInf.CaPrtsDtCompressDt = this.CaPrtsDtCompressDt_tDateEdit.GetLongDate();
            if (this.MasterSaveMonths_tEdit.Text.Trim() == "")
                companyInf.MasterSaveMonths = 0;
            else
                companyInf.MasterSaveMonths = Convert.ToInt32(this.MasterSaveMonths_tEdit.Text);
            companyInf.MasterCompressDt = this.MasterCompressDt_tDateEdit.GetLongDate();
            companyInf.RatePriorityDiv = Convert.ToInt32(this.RateProtyIndex_tComboEditor.Value);
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
        }

		/// <summary>
		///	画面情報－自賠責設定クラス格納処理(保存確認メッセージ用)
		/// </summary>
		/// <param name="companyInf">自賠責設定クラス</param>
		/// <remarks>
		/// <br>Note			:	画面情報から自賠責設定クラスにデータを
		///							格納します。</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.04.14</br>
		/// </remarks>
		private void DispToCompanyInf(ref CompanyInf companyInf)
		{
			if (companyInf == null)
			{
				// 新規の場合
				companyInf = new CompanyInf();	
			}
			//ヘッダ部
			 companyInf.EnterpriseCode = this._enterpriseCode;

			//明細部
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			 companyInf.CompanyName1 = this.CompanyName1_tEdit.Text;
//			 companyInf.CompanyName2 = this.CompanyName2_tEdit.Text;
//		
//			 companyInf.PostNo = this.PostNo_tEdit.Text.Trim();
//			 companyInf.Address1 = this.Address1_tEdit.Text;
//			 companyInf.Address2 = this.Address2_tNedit.GetInt();
//			 companyInf.Address3 = this.Address3_tEdit.Text;
//			 companyInf.Address4 = this.Address4_tEdit.Text;
//			 companyInf.CompanyTelTitle1 = this.TelTitle1_tEdit.Text;
//			 companyInf.CompanyTelTitle2 = this.TelTitle2_tEdit.Text;
//			 companyInf.CompanyTelTitle3 = this.TelTitle3_tEdit.Text;
//
//			 companyInf.CompanyTelNo1 = this.TelNo1_tEdit.Text;
//			 companyInf.CompanyTelNo2 = this.TelNo2_tEdit.Text;
//			 companyInf.CompanyTelNo3 = this.TelNo3_tEdit.Text;
//										
//			 companyInf.TransferGuidance = this.Transfer_tEdit.Text;
//			 companyInf.AccountNoInfo1	= this.AccuntNo1_tEdit.Text;
//			 companyInf.AccountNoInfo2	= this.AccuntNo2_tEdit.Text;
//			 companyInf.AccountNoInfo3	= this.AccuntNo3_tEdit.Text;
//			 companyInf.CompanySetNote1 = this.SetNote1_tEdit.Text;
//			 companyInf.CompanySetNote2 = this.SetNote2_tEdit.Text;
//			 companyInf.CompanyPr		= this.Pr_tEdit.Text;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

             //companyInf.CompanyTotalDay = this.TotalDay_tNedit.GetInt();
             if (this.CompanyBiginDate_tDateEdit.GetDateDay() == 1)
             {
                 companyInf.CompanyTotalDay = 31;
             }
             else
             {
                 companyInf.CompanyTotalDay = this.CompanyBiginDate_tDateEdit.GetDateDay() - 1;
             }
            
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //companyInf.CompanyBiginMonth = this.BiginMonth_tNedit.GetInt();
            companyInf.CompanyBiginMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.04.13  S.Koga  amend -------------------------------------
            // 2007.04.10  S.Koga  add ---------------------------------------
            //companyInf.CompRestBiginMonth = this.BiginMonth2_tNedit.GetInt();
            // ---------------------------------------------------------------
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            //companyInf.CompanyBiginMonth2 = this.BiginMonth2_tNedit.GetInt();
            companyInf.CompanyBiginMonth2 = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // ---------------------------------------------------------------

            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            companyInf.FinancialYear = this.FinancialYear_tNedit.GetInt();
            companyInf.CompanyBiginDate = this.CompanyBiginDate_tDateEdit.GetLongDate();
            // DEL 2008/10/28 不具合対応[7089] ↓
            //companyInf.StartYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>

            //if (this.StartYearDiv_tComboEditor.Value == null)
            //{
            //    companyInf.StartYearDiv = 1;
            //}
            //else
            //{
            //    companyInf.StartYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            //}
            if (this.FinancialYear_tNedit.GetInt() == this.CompanyBiginDate_tDateEdit.GetDateYear())
            {
                companyInf.StartYearDiv = 0;
            }
            else
            {
                companyInf.StartYearDiv = 1;
            }
            
            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
            if (StartMonthDiv_tComboEditor.Value == null)
            {
                companyInf.StartMonthDiv = 1;
            }
            else
            {
                companyInf.StartMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
            }
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            companyInf.SecMngDiv = (Int32)this.SecMngDiv_tComboEditor.Value;
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.05.17  S.Koga  add ---------------------------------------
            companyInf.CompanyName1 = this.CompanyName1_tEdit.Text.TrimEnd();
            companyInf.CompanyName2 = this.CompanyName2_tEdit.Text.TrimEnd();
            // ---------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            companyInf.PostNo = this.PostNo_tEdit.DataText.Trim();
            companyInf.Address1 = this.Address1_tEdit.DataText.Trim();
            companyInf.Address3 = this.Address3_tEdit.DataText.Trim();
            companyInf.Address4 = this.Address4_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle1 = this.CompanyTelTitle1_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle2 = this.CompanyTelTitle2_tEdit.DataText.Trim();
            companyInf.CompanyTelTitle3 = this.CompanyTelTitle3_tEdit.DataText.Trim();
            companyInf.CompanyTelNo1 = this.CompanyTelNo1_tEdit.DataText.Trim();
            companyInf.CompanyTelNo2 = this.CompanyTelNo2_tEdit.DataText.Trim();
            companyInf.CompanyTelNo3 = this.CompanyTelNo3_tEdit.DataText.Trim();
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            companyInf.DataSaveMonths = Convert.ToInt32(this.DataSaveMonths_tEdit.Text);
            companyInf.DataCompressDt = this.DataCompressDt_tDateEdit.GetLongDate();
            companyInf.ResultDtSaveMonths = Convert.ToInt32(this.ResultDtSaveMonths_tEdit.Text);
            companyInf.ResultDtCompressDt = this.ResultDtCompressDt_tDateEdit.GetLongDate();
            companyInf.CaPrtsDtSaveMonths = Convert.ToInt32(this.CaPrtsDtSaveMonths_tEdit.Text);
            companyInf.CaPrtsDtCompressDt = this.CaPrtsDtCompressDt_tDateEdit.GetLongDate();
            companyInf.MasterSaveMonths = Convert.ToInt32(this.MasterSaveMonths_tEdit.Text);
            companyInf.MasterCompressDt = this.MasterCompressDt_tDateEdit.GetLongDate();
            companyInf.RatePriorityDiv = Convert.ToInt32(this.RateProtyIndex_tComboEditor.Value);
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
        }

        #region DEL 2008/09/12 Partsman用に変更
        /* --- DEL 2008/09/12 --------------------------------------------------------------------->>>>>
         /// <summary>
         ///	画面展開処理
         /// </summary>
         /// <remarks>
         /// <br>Note			:	自賠責設定クラスから画面にデータを展開します。</br>
         /// <br>Programmer		:	小黒大輔</br>
         /// <br>Date			:	2005.04.14</br>
         /// </remarks>
         private void companyInfToScreen()
         {
 ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
 //			this.CompanyName1_tEdit.Text		= this.companyInf.CompanyName1;
 //			this.CompanyName2_tEdit.Text		= this.companyInf.CompanyName2;
 //			this.PostNo_tEdit.Text				= this.companyInf.PostNo;
 //			this.Address1_tEdit.Text			= this.companyInf.Address1;
 //			this.Address2_tNedit.SetInt(this.companyInf.Address2);
 //			this.Address3_tEdit.Text			= this.companyInf.Address3; 
 //			this.Address4_tEdit.Text			= this.companyInf.Address4; 
 //			this.TelTitle1_tEdit.Text			= this.companyInf.CompanyTelTitle1;
 //			this.TelTitle2_tEdit.Text			= this.companyInf.CompanyTelTitle2;
 //			this.TelTitle3_tEdit.Text			= this.companyInf.CompanyTelTitle3;
 //
 //			this.TelNo1_tEdit.Text              = this.companyInf.CompanyTelNo1;     
 //			this.TelNo2_tEdit.Text              = this.companyInf.CompanyTelNo2; 
 //			this.TelNo3_tEdit.Text              = this.companyInf.CompanyTelNo3; 
 //		
 //			this.Transfer_tEdit.Text			= this.companyInf.TransferGuidance;
 //			this.AccuntNo1_tEdit.Text			= this.companyInf.AccountNoInfo1; 
 //			this.AccuntNo2_tEdit.Text			= this.companyInf.AccountNoInfo2; 
 //			this.AccuntNo3_tEdit.Text			= this.companyInf.AccountNoInfo3; 
 //			this.SetNote1_tEdit.Text			= this.companyInf.CompanySetNote1; 
 //			this.SetNote2_tEdit.Text			= this.companyInf.CompanySetNote2; 
 //			this.Pr_tEdit.Text					= this.companyInf.CompanyPr; 
 // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

             this.TotalDay_tNedit.SetInt(this.companyInf.CompanyTotalDay);
             this.BiginMonth_tNedit.SetInt(this.companyInf.CompanyBiginMonth);

             // 2007.04.13  S.Koga  amend --------------------------------------
             // 2007.04.10  S.Koga  add ----------------------------------------
             //this.BiginMonth2_tNedit.SetInt(this.companyInf.CompRestBiginMonth);
             // ----------------------------------------------------------------
             this.BiginMonth2_tNedit.SetInt(this.companyInf.CompanyBiginMonth2);
             // ----------------------------------------------------------------

             // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
             this.FinancialYear_tNedit.SetInt(companyInf.FinancialYear);
             this.CompanyBiginDate_tDateEdit.SetLongDate(companyInf.CompanyBiginDate);

             this.StartYearDiv_tComboEditor.Items.Clear();
             this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
             this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
             this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
             this.StartYearDiv_tComboEditor.Value = companyInf.StartYearDiv;

             // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
             int startYearDiv;
             int financialYear = this.FinancialYear_tNedit.GetInt();
             int prevYear = financialYear - 1;
             // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

             int workMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
             int workDay = this.CompanyBiginDate_tDateEdit.GetDateDay();

             int prevMonth;
             if (workMonth == 1)
             {
                 prevMonth = 12;
             }
             else
             {
                 prevMonth = workMonth - 1;
             }

             // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
             this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の開始日を設定します。";
             // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

             this.StartMonthDiv_tComboEditor.Items.Clear();
             if ((workMonth != 0) && (workDay == 1) && (companyInf.StartMonthDiv == 1))
             {
                 this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
             }
             else
             {
                 if ((workMonth != 0) && (workDay != 0))
                 {
                     this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH.ToString() + "（" + prevMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
                     this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
                 }
                 else
                 {
                     this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH.ToString());
                     this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString());
                 }
             }
             this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
             this.StartMonthDiv_tComboEditor.Value = companyInf.StartMonthDiv;
             // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<

             // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
             if (financialYear != 0)
             {
                 if ((workMonth != 0) && (workDay != 0))
                 {
                     if ((workMonth == 1) && (workDay == 1))
                     {
                         this.StartYearDiv_tComboEditor.Items.Clear();
                         this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                         this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                         this.StartYearDiv_tComboEditor.Value = 1;
                     }
                     else
                     {
                         startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                         this.StartYearDiv_tComboEditor.Items.Clear();
                         this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                         this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                         this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                         this.StartYearDiv_tComboEditor.Value = startYearDiv;
                     }
                 }
                 else
                 {
                     startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                     this.StartYearDiv_tComboEditor.Items.Clear();
                     this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
                     this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
                     this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                     this.StartYearDiv_tComboEditor.Value = startYearDiv;
                 }
             }
             else
             {
                 startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                 this.StartYearDiv_tComboEditor.Items.Clear();
                 this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
                 this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
                 this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                 this.StartYearDiv_tComboEditor.Value = startYearDiv;
             }
             // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

             // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
             this.SecMngDiv_tComboEditor.Items.Clear();
             this.SecMngDiv_tComboEditor.Items.Add(0, SECMNG_SEC);
             this.SecMngDiv_tComboEditor.Items.Add(1, SECMNG_SUB);
             //this.SecMngDiv_tComboEditor.Items.Add(2, SECMNG_MIN);  // DEL 2008/06/03
             this.SecMngDiv_tComboEditor.MaxDropDownItems = SecMngDiv_tComboEditor.Items.Count;
             this.SecMngDiv_tComboEditor.Value = companyInf.SecMngDiv;
             // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

             // 2007.05.17  S.Koga  add ----------------------------------------
             this.CompanyName1_tEdit.Text = this.companyInf.CompanyName1;
             this.CompanyName2_tEdit.Text = this.companyInf.CompanyName2;
             // ----------------------------------------------------------------

             // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
             this.PostNo_tEdit.DataText = companyInf.PostNo.Trim();
             this.Address1_tEdit.DataText = companyInf.Address1.Trim();
             this.Address3_tEdit.DataText = companyInf.Address3.Trim();
             this.Address4_tEdit.DataText = companyInf.Address4.Trim();
             this.CompanyTelTitle1_tEdit.DataText = companyInf.CompanyTelTitle1.Trim();
             this.CompanyTelTitle2_tEdit.DataText = companyInf.CompanyTelTitle2.Trim();
             this.CompanyTelTitle3_tEdit.DataText = companyInf.CompanyTelTitle3.Trim();
             this.CompanyTelNo1_tEdit.DataText = companyInf.CompanyTelNo1.Trim();
             this.CompanyTelNo2_tEdit.DataText = companyInf.CompanyTelNo2.Trim();
             this.CompanyTelNo3_tEdit.DataText = companyInf.CompanyTelNo3.Trim();
             // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
         }
            --- DEL 2008/09/12 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/12 Partsman用に変更

        // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        ///	画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note			:	自社設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer		:	30414 忍 幸史</br>
        /// <br>Date			:	2008/09/12</br>
        /// </remarks>
        private void companyInfToScreen()
        {
            //// 自社締日
            //this.TotalDay_tNedit.SetInt(this.companyInf.CompanyTotalDay);
            // 実績用期首月
            this.BiginMonth_tNedit.SetInt(this.companyInf.CompanyBiginMonth);
            // 会計用期首月
            this.BiginMonth2_tNedit.SetInt(this.companyInf.CompanyBiginMonth2);
            // 会計年度
            this.FinancialYear_tNedit.SetInt(companyInf.FinancialYear);
            // 期首年月日
            this.CompanyBiginDate_tDateEdit.SetLongDate(companyInf.CompanyBiginDate);

            // DEL 2008/10/22 不具合対応[6814]↓
            //int prevYear = companyInf.FinancialYear - 1;
            int workMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            int workDay = this.CompanyBiginDate_tDateEdit.GetDateDay();

            // 開始年区分
            // DEL 2008/10/22 不具合対応[6814] メソッドとして抽出---------->>>>>
            #region 削除コード
            //this.StartYearDiv_tComboEditor.Items.Clear();
            //if (companyInf.FinancialYear != 0)
            //{
            //    if ((workMonth != 0) && (workDay != 0))
            //    {
            //        if ((workMonth == 1) && (workDay == 1))
            //        {
            //            // DEL 2008/10/22 不具合対応[6814]↓
            //            //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            // MEMO:2008/10/22 不具合対応[6814] 前年と翌年のコンボボックスのテキスト表示が逆
            //            // ADD 2008/10/22 不具合対応[6814]↓
            //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");

            //            this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //            this.StartYearDiv_tComboEditor.Value = 1;
            //        }
            //        else
            //        {
            //            // DEL 2008/10/22 不具合対応[6814]---------->>>>>
            //            //this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            // DEL 2008/10/22 不具合対応[6814]----------<<<<<
            //            // MEMO:2008/10/22 不具合対応[6814] 前年と翌年のコンボボックスのテキスト表示が逆
            //            // ADD 2008/10/22 不具合対応[6814]---------->>>>>
            //            this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + companyInf.FinancialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            // ADD 2008/10/22 不具合対応[6814]----------<<<<<
            //        }
            //    }
            //    else
            //    {
            //        this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
            //        this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
            //    }
            //}
            //else
            //{
            //    this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
            //    this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
            //}
            //this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //this.StartYearDiv_tComboEditor.Value = companyInf.StartYearDiv;
            #endregion  // 削除コード
            // DEL 2008/10/22 不具合対応[6814]----------<<<<<
            //InitializeStartYearDivUI(companyInf.FinancialYear, workMonth, workDay, companyInf.StartYearDiv); // ADD 2008/10/22 不具合対応[6814] メソッドとして抽出

            // 開始月区分
            // DEL 2008/10/22 不具合対応[6816] メソッドとして抽出---------->>>>>
            #region 削除コード
            //int prevMonth;
            //if (workMonth == 1)
            //{
            //    prevMonth = 12;
            //}
            //else
            //{
            //    prevMonth = workMonth - 1;
            //}

            //this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の開始日を設定します。";

            // 開始月区分
            //this.StartMonthDiv_tComboEditor.Items.Clear();
            //if ((workMonth != 0) && (workDay == 1) && (companyInf.StartMonthDiv == 1))
            //{
            //    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //}
            //else
            //{
            //    if ((workMonth != 0) && (workDay != 0))
            //    {
            //        this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH + "（" + prevMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //        this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //    }
            //    else
            //    {
            //        this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH);
            //        this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH);
            //    }
            //}
            //this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
            //this.StartMonthDiv_tComboEditor.Value = companyInf.StartMonthDiv;
            #endregion  // 削除コード
            // DEL 2008/10/22 不具合対応[6816]----------<<<<<
            // DEL 2008/10/28 不具合対応[7089] ↓
            //InitializeStartMonthDivUI(workMonth, workDay, companyInf.StartMonthDiv, true);  // ADD 2008/10/22 不具合対応[6816] メソッドとして抽出
            InitializeStartMonthDivUI(companyInf.FinancialYear, workMonth, workDay, companyInf.StartMonthDiv, true);  // ADD 2008/10/28 不具合対応[7089] 

            // 部署管理区分
            this.SecMngDiv_tComboEditor.Items.Clear();
            this.SecMngDiv_tComboEditor.Items.Add(0, SECMNG_SEC);
            this.SecMngDiv_tComboEditor.Items.Add(1, SECMNG_SUB);
            this.SecMngDiv_tComboEditor.MaxDropDownItems = SecMngDiv_tComboEditor.Items.Count;
            this.SecMngDiv_tComboEditor.Value = companyInf.SecMngDiv;
            // 自社名称１
            this.CompanyName1_tEdit.Text = this.companyInf.CompanyName1;
            // 自社名称２
            this.CompanyName2_tEdit.Text = this.companyInf.CompanyName2;
            // 郵便番号
            this.PostNo_tEdit.DataText = companyInf.PostNo.Trim();
            // 住所
            this.Address1_tEdit.DataText = companyInf.Address1.Trim();
            this.Address3_tEdit.DataText = companyInf.Address3.Trim();
            this.Address4_tEdit.DataText = companyInf.Address4.Trim();
            // 電話番号タイトル
            this.CompanyTelTitle1_tEdit.DataText = companyInf.CompanyTelTitle1.Trim();
            this.CompanyTelTitle2_tEdit.DataText = companyInf.CompanyTelTitle2.Trim();
            this.CompanyTelTitle3_tEdit.DataText = companyInf.CompanyTelTitle3.Trim();
            // 電話番号
            this.CompanyTelNo1_tEdit.DataText = companyInf.CompanyTelNo1.Trim();
            this.CompanyTelNo2_tEdit.DataText = companyInf.CompanyTelNo2.Trim();
            this.CompanyTelNo3_tEdit.DataText = companyInf.CompanyTelNo3.Trim();
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            this.DataSaveMonths_tEdit.Text = companyInf.DataSaveMonths.ToString();
            this.DataCompressDt_tDateEdit.SetLongDate(companyInf.DataCompressDt);
            this.ResultDtSaveMonths_tEdit.Text = companyInf.ResultDtSaveMonths.ToString();
            this.ResultDtCompressDt_tDateEdit.SetLongDate(companyInf.ResultDtCompressDt);
            this.CaPrtsDtSaveMonths_tEdit.Text = companyInf.CaPrtsDtSaveMonths.ToString();
            this.CaPrtsDtCompressDt_tDateEdit.SetLongDate(companyInf.CaPrtsDtCompressDt);
            this.MasterSaveMonths_tEdit.Text = companyInf.MasterSaveMonths.ToString();
            this.MasterCompressDt_tDateEdit.SetLongDate(companyInf.MasterCompressDt);
            this.RateProtyIndex_tComboEditor.Items.Clear();
            this.RateProtyIndex_tComboEditor.Items.Add(0, SECMNG_PROTY);
            this.RateProtyIndex_tComboEditor.Items.Add(1, SECMNG_MOSHI);
            this.RateProtyIndex_tComboEditor.MaxDropDownItems = RateProtyIndex_tComboEditor.Items.Count;
            this.RateProtyIndex_tComboEditor.Value = companyInf.RatePriorityDiv;
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
        }

        //// ADD 2008/10/22 不具合対応[6814] 旧コードをメソッドとして抽出---------->>>>>
        ///// <summary>
        ///// 開始年月日のUIを初期化します。
        ///// </summary>
        ///// <param name="year">年</param>
        ///// <param name="month">月</param>
        ///// <param name="day">日</param>
        ///// <param name="selectValue">選択するアイテムの値</param>
        //private void InitializeStartYearDivUI(
        //    int year,
        //    int month,
        //    int day,
        //    int selectValue
        //)
        //{// HACK:2008/10/22 【応急処置】：日付の演算はDateTimeまたはTimeSpanで行う方がよい
        //    this.StartYearDiv_tComboEditor.Items.Clear();

        //    if (year > 0)
        //    {
        //        int prevYear = year - 1;
        //        if ((!month.Equals(0)) && (!day.Equals(0)))
        //        {
        //            if ((month.Equals(1)) && (day.Equals(1)))
        //            {
        //                // DEL 2008/10/28 不具合対応[7089] ↓
        //                //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + prevYear.ToString("0000") + "年" + month.ToString("00") + "月度～ ）");

        //                // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
        //                this.StartYearDiv_tComboEditor.Items.Add(1, prevYear.ToString("0000") + "年" + month.ToString("00") + "月～" +
        //                                                                prevYear.ToString("0000") + "年12月");
        //                // ADD 2008/10/28 不具合対応[7089] ----------<<<<<

        //                this.StartYearDiv_tComboEditor.MaxDropDownItems = this.StartYearDiv_tComboEditor.Items.Count;
        //                this.StartYearDiv_tComboEditor.Value = 1;
        //            }
        //            else
        //            {
        //                // DEL 2008/10/28 不具合対応[7089] ---------->>>>>
        //                //this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + companyInf.FinancialYear.ToString("0000") + "年" + month.ToString("00") + "月度～ ）");
        //                //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + prevYear.ToString("0000") + "年" + month.ToString("00") + "月度～ ）");
        //                // DEL 2008/10/28 不具合対応[7089] ----------<<<<<

        //                // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
        //                if (month == 1)
        //                {
        //                    this.StartYearDiv_tComboEditor.Items.Add(0, year.ToString("0000") + "年" + month.ToString("00") + "月～" +
        //                                                            year.ToString("0000") + "年12月");
        //                    this.StartYearDiv_tComboEditor.Items.Add(1, prevYear.ToString("0000") + "年" + month.ToString("00") + "月～" +
        //                                                            prevYear.ToString("0000") + "年12月");
        //                }
        //                else
        //                {
        //                    this.StartYearDiv_tComboEditor.Items.Add(0, year.ToString("0000") + "年" + month.ToString("00") + "月～" +
        //                                                            (year + 1).ToString("0000") + "年" + (month - 1).ToString("00") + "月");
        //                    this.StartYearDiv_tComboEditor.Items.Add(1, prevYear.ToString("0000") + "年" + month.ToString("00") + "月～" +
        //                                                            (prevYear + 1).ToString("0000") + "年" + (month - 1).ToString("00") + "月");
        //                }
        //                // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
        //            }
        //        }
        //        else
        //        {
        //            // DEL 2008/10/28 不具合対応[7089] ---------->>>>>
        //            //this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
        //            //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
        //            // DEL 2008/10/28 不具合対応[7089] ----------<<<<<
        //        }
        //    }
        //    else
        //    {
        //        // DEL 2008/10/28 不具合対応[7089] ---------->>>>>
        //        //this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
        //        //this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
        //        // DEL 2008/10/28 不具合対応[7089] ----------<<<<<
        //    }

        //    // DEL 2008/10/28 不具合対応[7089] ↓
        //    //this.StartYearDiv_tComboEditor.MaxDropDownItems = this.StartYearDiv_tComboEditor.Items.Count;
        //    // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
        //    if (this.StartYearDiv_tComboEditor.Items.Count == 0)
        //    {
        //        this.StartYearDiv_tComboEditor.MaxDropDownItems = 1;
        //    }
        //    else
        //    {
        //        this.StartYearDiv_tComboEditor.MaxDropDownItems = this.StartYearDiv_tComboEditor.Items.Count;
        //    }
        //    // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
        //    this.StartYearDiv_tComboEditor.Value = selectValue;
        //}

        /// <summary>
        /// 開始月区分のUIを初期化します。
        /// </summary>
        /// <param name="year">年 2008/10/28追加</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="selectValue">選択するアイテムの値</param>
        private void InitializeStartMonthDivUI(
            int year,
            int month,
            int day,
            int selectValue
        )
        {
            //InitializeStartMonthDivUI(month, day, selectValue, false);  // DEL 2008/10/28 不具合対応[7089]
            InitializeStartMonthDivUI(year, month, day, selectValue, false);  // ADD 2008/10/28 不具合対応[7089] 
        }

        /// <summary>
        /// 開始月区分のUIを初期化します。
        /// </summary>
        /// <param name="year">年 2008/10/28追加</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="selectValue">選択するアイテムの値</param>
        /// <param name="isFirstInitializing">初めての初期化フラグ</param>
        /// <br>Update Note		:	2010/12/21 鄧潘ハン</br>
        /// <br>                    ①開始月が不正になる不具合を修正</br>
        private void InitializeStartMonthDivUI(
            int year,
            int month,
            int day,
            int selectValue,
            bool isFirstInitializing
        )
        {// HACK:2008/10/22 【応急処置】：日付の演算はDateTimeまたはTimeSpanで行う方がよい
            bool enabledFlagOfFirstInitializingOnly = true;
            if (isFirstInitializing)
            {
                enabledFlagOfFirstInitializingOnly = this.companyInf.StartMonthDiv.Equals(1);
            }

            //this.uLabel_StartMonthDivNote.Text = "※" + month.ToString("00") + "月度の開始日を設定します。";    // DEL 2008/10/28 不具合対応[7089]
            //this.uLabel_StartMonthDivNote.Text = "※" + month.ToString("00") + "月度の期間を設定します。";    // ADD 2008/10/28 不具合対応[7089]

            this.StartMonthDiv_tComboEditor.Items.Clear();

            int prevMonth = (month.Equals(1) ? 12 : (month - 1));
            //if ((!year.Equals(0)) && (!month.Equals(0)) && (day.Equals(1)) && enabledFlagOfFirstInitializingOnly) // DEL 2008/10/28 不具合対応[7089]
            // ADD 2008/10/28 不具合対応[7089] ↓
            if ((!year.Equals(0)) && (!month.Equals(0)) && (day.Equals(1)) && enabledFlagOfFirstInitializingOnly)
            {
                // DEL 2008/10/28 不具合対応[7089] ↓
                //this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + prevMonth.ToString() + "月" + day.ToString() + "日～ ）");

                // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                this.StartMonthDiv_tComboEditor.Items.Add(1, month.ToString() + "月" + day.ToString() + "日～" +
                    month.ToString() + "月" + DateTime.DaysInMonth(year, month).ToString() + "日");
                // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
            }
            else
            {
                // DEL 2008/10/28 不具合対応[7089] ---------->>>>>
                //if ((!month.Equals(0)) && (!day.Equals(0)))
                //{
                //    this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH + "（" + month.ToString() + "月" + day.ToString() + "日～ ）");
                //    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + prevMonth.ToString() + "月" + day.ToString() + "日～ ）");
                //}
                //else
                //{
                //    this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH);
                //    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH);
                //}
                // DEL 2008/10/28 不具合対応[7089] ----------<<<<<

                // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
                if ((!year.Equals(0)) && (!month.Equals(0)) && (!day.Equals(0)))
                {
                    // 日付として認識可能な場合のみ、コンボを作成
                    if (month <= 12 && day <= 27)
                    {
                        // 2010/01/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //this.StartMonthDiv_tComboEditor.Items.Add(0, month.ToString() + "月" + day.ToString() + "日～" +
                        //                                            (month +1).ToString() + "月" + (day -1).ToString() + "日");
                        //this.StartMonthDiv_tComboEditor.Items.Add(1, prevMonth.ToString() + "月" + day.ToString() + "日～" +
                        //                                            month.ToString() + "月" + (day - 1).ToString() + "日");
                        this.StartMonthDiv_tComboEditor.Items.Add(0, prevMonth.ToString() + "月" + day.ToString() + "日～" +
                                                                    month.ToString() + "月" + (day - 1).ToString() + "日");
                        this.StartMonthDiv_tComboEditor.Items.Add(1, month.ToString() + "月" + day.ToString() + "日～" +
                                                                    //(month + 1).ToString() + "月" + (day - 1).ToString() + "日");// DEL 2010/12/21
                                                                    ((month % 12) + 1).ToString() + "月" + (day - 1).ToString() + "日");// ADD 2010/12/21
                        // 2010/01/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
                // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
            }

            // DEL 2008/10/28 不具合対応[7089] ↓
            //this.StartMonthDiv_tComboEditor.MaxDropDownItems = this.StartMonthDiv_tComboEditor.Items.Count;
            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
            if (this.StartMonthDiv_tComboEditor.Items.Count == 0)
            {
                this.StartMonthDiv_tComboEditor.MaxDropDownItems = 1;
            }
            else
            {
                this.StartMonthDiv_tComboEditor.MaxDropDownItems = this.StartMonthDiv_tComboEditor.Items.Count;
            }
            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>

            // --- CHG 2009/02/12 障害ID:11320対応------------------------------------------------------>>>>>
            //this.StartMonthDiv_tComboEditor.Value = this.StartMonthDiv_tComboEditor.Items[0].DataValue;
            if (this.StartMonthDiv_tComboEditor.Items.Count > 1)
            {
                this.StartMonthDiv_tComboEditor.Value = selectValue;
            }
            else
            {
                if (this.StartMonthDiv_tComboEditor.Items.Count != 0)
                {
                    this.StartMonthDiv_tComboEditor.SelectedIndex = 0;
                }
                else
                {
                    this.StartMonthDiv_tComboEditor.Value = null;
                }
            }
            // --- CHG 2009/02/12 障害ID:11320対応------------------------------------------------------<<<<<
        }
        // ADD 2008/10/22 不具合対応[6814]----------<<<<<

        // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<
		/// <summary>
		///	自賠責設定画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	自賠責設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.03.18</br>
		/// </remarks>
		private void ScreenClear()
		{
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.CompanyName1_tEdit.Text		= "";
//			this.CompanyName2_tEdit.Text		= "";
//			this.PostNo_tEdit.Text				= "";
//			this.Address1_tEdit.Text			= "";
//			this.Address2_tNedit.Clear();
//			this.Address3_tEdit.Text			= ""; 
//			this.Address4_tEdit.Text			= "";
//			this.TelTitle1_tEdit.Text	= "";
//			this.TelTitle2_tEdit.Text	= "";
//			this.TelTitle3_tEdit.Text	= "";
//
//			this.TelNo1_tEdit.Text = "";
//			this.TelNo2_tEdit.Text = "";
//			this.TelNo3_tEdit.Text = "";
//
//			this.Transfer_tEdit.Text			= "";
//			this.AccuntNo1_tEdit.Text			= "";
//			this.AccuntNo2_tEdit.Text			= "";
//			this.AccuntNo3_tEdit.Text			= "";
//			this.SetNote1_tEdit.Text			= "";
//			this.SetNote2_tEdit.Text			= "";
//			this.Pr_tEdit.Text					= "";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.TotalDay_tNedit.Clear();
            this.BiginMonth_tNedit.Clear();

            // 2007.04.10  S.Koga  add ---------------------------------------
            this.BiginMonth2_tNedit.Clear();
            // ---------------------------------------------------------------

            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            this.FinancialYear_tNedit.Clear();
            this.CompanyBiginDate_tDateEdit.Clear();
            //this.StartYearDiv_tComboEditor.Clear();
            this.StartMonthDiv_tComboEditor.Clear();
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            this.SecMngDiv_tComboEditor.Clear();
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.05.17  S.Koga  add ---------------------------------------
            this.CompanyName1_tEdit.Clear();
            this.CompanyName2_tEdit.Clear();
            // ---------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            this.PostNo_tEdit.Clear();
            this.Address1_tEdit.Clear();
            this.Address3_tEdit.Clear();
            this.Address4_tEdit.Clear();
            this.CompanyTelTitle1_tEdit.Clear();
            this.CompanyTelTitle2_tEdit.Clear();
            this.CompanyTelTitle3_tEdit.Clear();
            this.CompanyTelNo1_tEdit.Clear();
            this.CompanyTelNo2_tEdit.Clear();
            this.CompanyTelNo3_tEdit.Clear();

            this._changeFlg = false;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            this.DataSaveMonths_tEdit.Clear();
            this.DataCompressDt_tDateEdit.Clear();
            this.ResultDtSaveMonths_tEdit.Clear();
            this.ResultDtCompressDt_tDateEdit.Clear();
            this.CaPrtsDtSaveMonths_tEdit.Clear();
            this.CaPrtsDtCompressDt_tDateEdit.Clear();
            this.MasterSaveMonths_tEdit.Clear();
            this.MasterCompressDt_tDateEdit.Clear();
            this.RateProtyIndex_tComboEditor.Clear();
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
        }
		/// <summary>
		///			画面チェック処理
		/// </summary>
		/// <param name="control">コントロール</param>
		/// <param name="checkMessage">メッセージ</param>
		/// <returns>true:正常　false:異常</returns>
		/// <remarks>
		/// <br>Note		:	画面入力データのチェック結果を返却します。</br>
		/// <br>Programer	:	小黒大輔</br>
		/// <br>Date		:	2005.04.07</br>
		/// </remarks>
		private bool CheckInputData(ref Control control,ref string checkMessage)
		{
            ////自社締日
            //if(this.TotalDay_tNedit.GetInt() == 0)
            //{
            //    checkMessage = "自社締日が未入力です。";
            //    control = this.TotalDay_tNedit;
            //    return false;
            //}
					
            //if(this.TotalDay_tNedit.GetInt() > 31)
            //{
            //    checkMessage = "自社締日の入力範囲に誤りがあります。";
            //    control = this.TotalDay_tNedit;
            //    return false;
            //}
            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            ////期首月チェック
			//if( this.BiginMonth_tNedit.GetInt() == 0 )
			//{
			//	checkMessage = "期首月が未入力です。";
			//	control = this.BiginMonth_tNedit;
			//	return false;
			//}
            //if( this.BiginMonth_tNedit.GetInt() > 12 )
            //{
            //	checkMessage = "期首月の入力範囲に誤りがあります。";
            //	control = this.BiginMonth_tNedit;
            //	return false;
            //}
            //// 2007.04.10  S.Koga  add ----------------------------------------
            ////期首月２チェック
            //if (this.BiginMonth2_tNedit.GetInt() == 0)
            //{
            //    checkMessage = "期首月２が未入力です。";
            //    control = this.BiginMonth2_tNedit;
            //    return false;
            //}
            //if (this.BiginMonth2_tNedit.GetInt() > 12)
            //{
            //    checkMessage = "期首月２の入力範囲に誤りがあります。";
            //    control = this.BiginMonth2_tNedit;
            //    return false;
            //}
            //// ----------------------------------------------------------------

            //会計年度チェック
            if (this.FinancialYear_tNedit.GetInt() == 0)
            {
                checkMessage = "会計年度が未入力です。";
                control = this.FinancialYear_tNedit;
            	return false;
            }
            //期首年月日会計年度チェック
            if (this.CompanyBiginDate_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                if (this.CompanyBiginDate_tDateEdit.GetLongDate() == 0)
                {
                    checkMessage = "期首年月日が未入力です。";
                }
                else
                {
                    checkMessage = "期首年月日の入力に誤りがあります。";
                }
                control = this.CompanyBiginDate_tDateEdit;
                return false;
            }
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<

            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
            if (this.CompanyBiginDate_tDateEdit.GetDateDay() > 27)
            {
                checkMessage = "期首年月日の日付は27日までで入力してください。";
                control = this.CompanyBiginDate_tDateEdit;
                return false;
            }
            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<

            if ((this.CompanyBiginDate_tDateEdit.GetDateYear() != this.FinancialYear_tNedit.GetInt()) &&
                (this.CompanyBiginDate_tDateEdit.GetDateYear() != this.FinancialYear_tNedit.GetInt() - 1))
            {
                checkMessage = "期首年月日の年に誤りがあります。" + "\r\n\r\n" + 
                               this.FinancialYear_tNedit.GetInt().ToString() + "年、又は、" +
                               (this.FinancialYear_tNedit.GetInt() - 1).ToString() + "年を指定して下さい。";
                control = this.CompanyBiginDate_tDateEdit;
                return false;
            }

            // 2007.05.17  S.Koga  add ----------------------------------------
            if (this.CompanyName1_tEdit.Text.Trim().Equals(""))
            {
                //checkMessage = "会社名１が未入力です。";  // DEL 2008/06/03
                checkMessage = "自社名称１が未入力です。";  // ADD 2008/06/03
                control = this.CompanyName1_tEdit;
                return false;
            }
            // ----------------------------------------------------------------

            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
            //if (this.StartYearDiv_tComboEditor.Value == null)
            //{
            //    checkMessage = "開始年区分が未入力です。";
            //    control = this.StartYearDiv_tComboEditor;
            //    return false;
            //}

            if (this.StartMonthDiv_tComboEditor.Value == null)
            {
                checkMessage = "開始月区分が未入力です。";
                control = this.StartMonthDiv_tComboEditor;
                return false;
            }
            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
            //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
            //データ圧縮
            if (this.DataSaveMonths_tEdit.GetInt() >= 1 && this.DataSaveMonths_tEdit.GetInt() < 12)
            {
                checkMessage = "データ保存月数が不正です。";
                control = this.DataSaveMonths_tEdit;
                return false;
            }
            //実績データ圧縮日
            if (this.ResultDtSaveMonths_tEdit.GetInt() >= 1 && this.ResultDtSaveMonths_tEdit.GetInt() < 12)
            {
                checkMessage = "実績データ保存月数が不正です。";
                control = this.ResultDtSaveMonths_tEdit;
                return false;
            }
            //車輌部品データ圧縮日
            if (this.CaPrtsDtSaveMonths_tEdit.GetInt() >= 1 && this.CaPrtsDtSaveMonths_tEdit.GetInt() < 12)
            {
                checkMessage = "車輌部品保存月数が不正です。";
                control = this.CaPrtsDtSaveMonths_tEdit;
                return false;
            }
            //マスタ圧縮日
            if (this.MasterSaveMonths_tEdit.GetInt() >= 1 && this.MasterSaveMonths_tEdit.GetInt() < 12)
            {
                checkMessage = "マスタ保存月数が不正です。";
                control = this.MasterSaveMonths_tEdit;
                return false;
            }
            //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<
            return true;
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA ADD Start
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.07.07</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFUKN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"既に他端末より更新されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFUKN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"既に他端末より削除されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
					break;
				}
			}
		}

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		//2005.07.07 H.NAKAMURA ADD End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//		/// <summary>
//		/// 郵便番号変更処理
//		/// </summary>
//		/// <remarks>
//		/// <br>Note		: 郵便番号にあわせて表示されている住所１の変更を行います。</br>
//		/// <br>Programmer	: 23010 中村　仁</br>
//		/// <br>Date		: 2005.08.22</br>
//		/// </remarks>
//		private void EpPostNoChange()
//		{																		
//			AddressGuide adg = new AddressGuide();
//			AddressGuideResult adgRet = new AddressGuideResult();
//			string postNo = this.PostNo_tEdit.DataText;  
//
//			// 住所マスタ読込み
//			adg.SearchAddressFromPostNo(postNo, ref adgRet);
//
//			if ((adgRet.PostNo != "") &&
//				(adgRet.AddressName != ""))
//			{
//				this.Address1_tEdit.Text	= adgRet.AddressName;
//			}
//		}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		# endregion

		# region Control Events
		/// <summary>
		///	Form.Load イベント(SFUKN09000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		private void SFUKN09000UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ヘルプアイコン(☆)
//			this.PrtBitmapGuid_Button.ImageList = imageList16;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.PrtBitmapGuid_Button.Appearance.Image = Size16_Index.STAR1;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		}
		/// <summary>
		///	Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	保存ボタンコントロールがクリックされたときに
		///							発生します。</br>
		/// <br>Programmer		:	小黒　大輔</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			SaveCompanyInf();
		}
		/// <summary>
		///　保存処理(SaveCompanyInf())
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 保存処理を行います。</br>
		/// <br>Programmer		:	小黒　大輔</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		private void SaveCompanyInf()
		{

			Control control = null;
			string checkMessage = "";
			bool ret = true;

			//画面データ入力チェック処理
			ret = CheckInputData( ref control ,ref checkMessage );
			if(ret == false )
			{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					"SFUKN09000U", 						// アセンブリＩＤまたはクラスＩＤ
					checkMessage, 						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//				MessageBox.Show(checkMessage,
//					"入力チェック",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

				control.Focus();
				return;
			}

			// 画面から自賠責設定表示クラスにデータをセットします。
			ScreenToCompanyInf();
			
			// 自社マスタ登録
			int status = this.companyInfAcs.Write( ref companyInf);
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
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
					return ;
				}
			    //2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"自社情報設定", 					// プログラム名称
						"SaveCompanyInf", 					// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this.companyInfAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"登録に失敗しました st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					
					return ;
				}
			}
			//////////////////////2005 07.07 H.NAKAMURA DEL STA ////////////////////////////////
//			if (status != 0)
//			{
//				MessageBox.Show(
//					"自社情報設定の登録に失敗しました",
//					"エラー",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return;
//			}
			//////////////////////2005 07.07 H.NAKAMURA DEL END ////////////////////////////////

			DialogResult dialogResult = DialogResult.OK;

			Mode_Label.Text = UPDATE_MODE;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.Cancel;

			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._companyInfClone = null;
			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this.DialogResult = dialogResult;

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
		///	Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	閉じるボタンコントロールがクリックされたときに
		///							発生します。</br>
		/// <br>Programmer		:	小黒大輔</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			//保存確認
			CompanyInf compareCompanyInf = new CompanyInf();
			compareCompanyInf = this.companyInf.Clone();   
			//現在の画面情報を取得する
			DispToCompanyInf(ref compareCompanyInf);
			//最初に取得した画面情報と比較 
			if (!(this._companyInfClone.Equals(compareCompanyInf)))	
			{
				//画面情報が変更されていた場合は、保存確認メッセージを表示する 
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
				// 保存確認
				DialogResult res = TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
					"SFUKN09000U", 						// アセンブリＩＤまたはクラスＩＤ
					null, 								// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNoCancel );	// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//				DialogResult res = MessageBox.Show("編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？","保存確認",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
				switch(res)
				{
					case DialogResult.Yes:
					{
						SaveCompanyInf();
						return;
					}
					case DialogResult.No:
					{
						break;
					}
					default:
					{
						return;
					}
				}
			}

			DialogResult dialogResult = DialogResult.Cancel;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._companyInfClone = null;
			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		///	Form.Closing イベント(SFUKN09000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
		///							ようとしたときに発生します。</br>
		/// <br>Programmer		:	小黒大輔k</br>
		/// <br>Date			:	2005.04.07</br>
		/// </remarks>
		private void SFUKN09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._companyInfClone = null;
			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		///				画面ＶｉｓｉｂｌｅＣｈａｎｇイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SFUKN09000UA_VisibleChanged(object sender, System.EventArgs e)
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

			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// データがセットされていたら抜ける
			if(this._companyInfClone != null)
			{
				return;
			}
			// 2005.07.04 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			Initial_Timer.Enabled = true;

			ScreenClear();		
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 94138 小黒大輔</br>
		/// <br>Date       : 2005.04.07</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// companyInfクラス
			this.companyInf = new CompanyInf();

			int status = companyInfAcs.Read(out this.companyInf,this._enterpriseCode);
			if (status == 0 || status == 9) 
			{
				if(this.companyInf != null)
				{
					Mode_Label.Text = UPDATE_MODE;

					// 全体初期表示設定クラス画面展開処理
					companyInfToScreen();

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
					// 初期フォーカスセット
                    //this.TotalDay_tNedit.Focus();
                    //this.TotalDay_tNedit.SelectAll();
                    this.FinancialYear_tNedit.Focus();
                    this.FinancialYear_tNedit.SelectAll();
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
////					this.ultraLabel1.Focus(); //←上書きモードになってくれないので	// 2005.06.17 TOUMA DEL 更新モードの初期フォーカス項目をSelectAll対応
//					this.PostNo_tEdit.Focus();
//					this.PostNo_tEdit.SelectAll();									// 2005.06.17 TOUMA ADD 更新モードの初期フォーカス項目をSelectAll対応
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					//クローン作成
					this._companyInfClone = this.companyInf.Clone();  
					//画面情報を比較用クローンにコピーする　　　　　   
					DispToCompanyInf(ref this._companyInfClone);

				}
			}
			else
			{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
				// サーチ
				TMsgDisp.Show( 
					this, 									// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
					"SFUKN09000U", 							// アセンブリＩＤまたはクラスＩＤ
					"自社情報設定", 						// プログラム名称
					"ScreenReconstruction", 				// 処理名称
					TMsgDisp.OPE_READ, 						// オペレーション
					"自社マスタの読み込みに失敗しました。", // 表示するメッセージ
					status, 								// ステータス値
					this.companyInfAcs, 					// エラーが発生したオブジェクト
					MessageBoxButtons.OK, 					// 表示するボタン
					MessageBoxDefaultButton.Button1 );		// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//				MessageBox.Show("自社マスタ読込エラー ST="+status);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
				return;
			}


		}

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		/// <summary>
		/// 改行キー制御処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
        }

		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
        }

        // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
        #region DEL 2008/09/12 Partsman用に変更
        /* --- DEL 2008/09/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 期首年月日変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyBiginDate_tDateEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.StartMonthDiv_tComboEditor.Value == null) return;

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            int startYearDiv;
            int financialYear = this.FinancialYear_tNedit.GetInt();
            int prevYear = financialYear - 1;
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<
            int startMonthDiv;
            int workMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            int workDay   = this.CompanyBiginDate_tDateEdit.GetDateDay();

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            if (financialYear != 0)
            {
                if ((workMonth != 0) && (workDay != 0))
                {
                    if ((workMonth == 1) && (workDay == 1))
                    {
                        this.StartYearDiv_tComboEditor.Items.Clear();
                        this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                        this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                        this.StartYearDiv_tComboEditor.Value = 1;
                    }
                    else
                    {
                        startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                        this.StartYearDiv_tComboEditor.Items.Clear();
                        this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                        this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
                        this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                        this.StartYearDiv_tComboEditor.Value = startYearDiv;
                    }
                }
                else
                {
                    startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                    this.StartYearDiv_tComboEditor.Items.Clear();
                    this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
                    this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
                    this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                    this.StartYearDiv_tComboEditor.Value = startYearDiv;
                }
            }
            else
            {
                startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
                this.StartYearDiv_tComboEditor.Items.Clear();
                this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
                this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
                this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
                this.StartYearDiv_tComboEditor.Value = startYearDiv;
            }
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

            int prevMonth;
            if (workMonth == 1)
            {
                prevMonth = 12;
            }
            else
            {
                prevMonth = workMonth - 1;
            }

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の開始日を設定します。";
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

            if ((workMonth != 0) && (workDay != 0))
            {
                if (workDay == 1)
                {
                    this.StartMonthDiv_tComboEditor.Items.Clear();
                    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
                    this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
                    this.StartMonthDiv_tComboEditor.Value = 1;
                }
                else
                {
                    startMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
                    this.StartMonthDiv_tComboEditor.Items.Clear();
                    this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH.ToString() + "（" + prevMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
                    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString() + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
                    this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
                    this.StartMonthDiv_tComboEditor.Value = startMonthDiv;
                }
            }
            else
            {
                startMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
                this.StartMonthDiv_tComboEditor.Items.Clear();
                this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH.ToString());
                this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH.ToString());
                this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
                this.StartMonthDiv_tComboEditor.Value = startMonthDiv;
            }
        }
           --- DEL 2008/09/12 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/12 Partsman用に変更

        // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 期首年月日変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyBiginDate_tDateEdit_ValueChanged(object sender, EventArgs e)
        {
            // DEL 2008/10/28 不具合対応[7089] ↓
            //if (this.StartMonthDiv_tComboEditor.Value == null) return;
            
            int financialYear = this.FinancialYear_tNedit.GetInt();
            int workMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
            int workDay = this.CompanyBiginDate_tDateEdit.GetDateDay();

            // 開始年区分
            // DEL 2008/10/22 不具合対応[6814]---------->>>>>
            #region 削除コード
            //int startYearDiv;
            //int prevYear = financialYear - 1;
            //if (financialYear != 0)
            //{
            //    if ((workMonth != 0) && (workDay != 0))
            //    {
            //        if ((workMonth == 1) && (workDay == 1))
            //        {
            //            this.StartYearDiv_tComboEditor.Items.Clear();
            //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //            this.StartYearDiv_tComboEditor.Value = 1;
            //        }
            //        else
            //        {
            //            startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            //            this.StartYearDiv_tComboEditor.Items.Clear();
            //            this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
            //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");

            //            this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //            this.StartYearDiv_tComboEditor.Value = startYearDiv;
            //        }
            //    }
            //    else
            //    {
            //        startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            //        this.StartYearDiv_tComboEditor.Items.Clear();
            //        this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
            //        this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
            //        this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //        this.StartYearDiv_tComboEditor.Value = startYearDiv;
            //    }
            //}
            //else
            //{
            //    startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
            //    this.StartYearDiv_tComboEditor.Items.Clear();
            //    this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
            //    this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
            //    this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
            //    this.StartYearDiv_tComboEditor.Value = startYearDiv;
            //}
            #endregion  // 削除コード
            // DEL 2008/10/22 不具合対応[6814]----------<<<<<
            // ADD 2008/10/22 不具合対応[6814]↓
            // DEL 2008/10/28 不具合対応[7089]↓
            //InitializeStartYearDivUI(financialYear, workMonth, workDay, (Int32)this.StartYearDiv_tComboEditor.Value);

            //// ADD 2008/10/28 不具合対応[7089]---------->>>>>
            //if (this.StartYearDiv_tComboEditor.Value == null)
            //{
            //    InitializeStartYearDivUI(financialYear, workMonth, workDay, 0);
            //}
            //else
            //{
            //    InitializeStartYearDivUI(financialYear, workMonth, workDay, (Int32)this.StartYearDiv_tComboEditor.Value);
            //}
            //// ADD 2008/10/28 不具合対応[7089]----------<<<<<

            // 開始月区分
            // DEL 2008/10/22 不具合対応[6816]---------->>>>>
            #region 削除コード
            //int startMonthDiv;
            //int prevMonth;
            //if (workMonth == 1)
            //{
            //    prevMonth = 12;
            //}
            //else
            //{
            //    prevMonth = workMonth - 1;
            //}

            //this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の開始日を設定します。";

            //// 開始月区分
            //if ((workMonth != 0) && (workDay != 0))
            //{
            //    if (workDay == 1)
            //    {
            //        this.StartMonthDiv_tComboEditor.Items.Clear();
            //        this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //        this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
            //        this.StartMonthDiv_tComboEditor.Value = 1;
            //    }
            //    else
            //    {
            //        startMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
            //        this.StartMonthDiv_tComboEditor.Items.Clear();
            //        this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH + "（" + prevMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //        this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH + "（" + workMonth.ToString() + "月" + workDay.ToString() + "日～ ）");
            //        this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
            //        this.StartMonthDiv_tComboEditor.Value = startMonthDiv;
            //    }
            //}
            //else
            //{
            //    startMonthDiv = (Int32)this.StartMonthDiv_tComboEditor.Value;
            //    this.StartMonthDiv_tComboEditor.Items.Clear();
            //    this.StartMonthDiv_tComboEditor.Items.Add(0, PREV_MONTH);
            //    this.StartMonthDiv_tComboEditor.Items.Add(1, NEXT_MONTH);
            //    this.StartMonthDiv_tComboEditor.MaxDropDownItems = StartMonthDiv_tComboEditor.Items.Count;
            //    this.StartMonthDiv_tComboEditor.Value = startMonthDiv;
            //}
            #endregion  // 削除コード
            // DEL 2008/10/22 不具合対応[6816]----------<<<<<
            // ADD 2008/10/22 不具合対応[6816]↓
            //InitializeStartMonthDivUI(workMonth, workDay, (Int32)this.StartMonthDiv_tComboEditor.Value);  // DEL 2008/10/28 不具合対応[7089]
            // ADD 2008/10/28 不具合対応[7089] ---------->>>>>
            if (this.StartMonthDiv_tComboEditor.Value == null)
            {
                InitializeStartMonthDivUI(financialYear, workMonth, workDay, 0);
            }
            else
            {
                InitializeStartMonthDivUI(financialYear, workMonth, workDay, (Int32)this.StartMonthDiv_tComboEditor.Value);
            }
            // ADD 2008/10/28 不具合対応[7089] ----------<<<<<
        }
        // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/03</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "Ok_Button":
                    // 保存ボタンにフォーカスがある場合
                    if (e.Key == Keys.Left)
                    {
                        // 部署管理区分にフォーカスを移します
                        e.NextCtrl = SecMngDiv_tComboEditor;
                    }
                    break;
                case "Cancel_Button":
                    // 閉じるボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 部署管理区分にフォーカスを移します
                        e.NextCtrl = SecMngDiv_tComboEditor;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Control.Enter イベント(PostNo_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを得たときに発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/05</br>
        /// </remarks>
        private void PostNo_tEdit_Enter(object sender, EventArgs e)
        {
            this._changeFlg = false;
        }

        /// <summary>
        /// Control.Leave イベント(PostNo_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/05</br>
        /// </remarks>
        private void PostNo_tEdit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlg == true)
            {
                PostNoChange();
            }
        }

        /// <summary>
        /// TEdit.ValueChanged イベント(PostNo_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 値が変更されたときに発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/05</br>
        /// </remarks>
        private void PostNo_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.PostNo_tEdit.Modified == true)
            {
                this._changeFlg = true;
            }
        }

        /// <summary>
        /// 郵便番号変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 郵便番号にあわせて表示されている住所１の変更を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/05</br>
        /// </remarks>
        private void PostNoChange()
        {
            AddressGuide addressGuide = new AddressGuide();
            AddressGuideResult addrGuideResult = null;
            string postNo = this.PostNo_tEdit.DataText.TrimEnd();

            // 住所マスタ読込み
            DialogResult result = addressGuide.ShowPostNoSearchGuide(postNo, out addrGuideResult);
            if ((result == DialogResult.OK) &&
                (addrGuideResult.PostNo != "") &&
                (addrGuideResult.AddressName != ""))
            {
                // 郵便番号
                this.PostNo_tEdit.DataText = addrGuideResult.PostNo;

                // 住所１
                SetAddress1(addrGuideResult.AddressName);
            }
        }

        /// <summary>
        /// 住所１格納処理
        /// </summary>
        /// <param name="address1">格納対象住所１</param>
        /// <remarks>
        /// <br>Note       : 住所１を画面に表示します。文字数が長い時は分割して、住所３に格納します。</br>
        /// </remarks>
        private void SetAddress1(string address1)
        {
            // 住所１の文字数が30を超える時は、分割して住所３へ格納
            if (address1.Length > 30)
            {
                string wkAddress3 = "";

                // 住所１(先頭から30文字までを格納)
                this.Address1_tEdit.DataText = address1.Substring(0, 30);
                // 住所３(31文字目から末尾まで)
                wkAddress3 = address1.Substring(30, address1.Length - 30);

                // 住所３にも入りきらない場合(住所３が22文字を超える場合)
                if (wkAddress3.Length > 22)
                {
                    // 住所３(先頭から22文字までを格納)
                    this.Address3_tEdit.DataText = wkAddress3.Substring(0, 22);
                    // 住所４(23文字目から30文字分。)
                    this.Address3_tEdit.DataText = wkAddress3.Substring(22, Math.Min(wkAddress3.Length - 22, 30));
                }
                else
                {
                    // 住所３
                    this.Address3_tEdit.DataText = wkAddress3;
                }
            }
            else
            {
                // 住所１
                this.Address1_tEdit.DataText = address1;
            }
        }

        //ADD START 2011/07/22 zhouyu FOR 連番 42 ------------------->>>>>>
        /// <summary>
        /// Control.Leave イベント(DataSaveMonths_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void DataSaveMonths_tEdit_Leave(object sender, EventArgs e)
        {
            if (this.DataSaveMonths_tEdit.Text == "")
                this.DataSaveMonths_tEdit.Text = "0";
        }

        /// <summary>
        /// Control.Leave イベント(DataSaveMonths_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void ResultDtSaveMonths_tEdit_Leave(object sender, EventArgs e)
        {
            if (this.ResultDtSaveMonths_tEdit.Text == "")
                this.ResultDtSaveMonths_tEdit.Text = "0";
        }

        /// <summary>
        /// Control.Leave イベント(CaPrtsDtSaveMonths_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void CaPrtsDtSaveMonths_tEdit_Leave(object sender, EventArgs e)
        {
            if (this.CaPrtsDtSaveMonths_tEdit.Text == "")
                this.CaPrtsDtSaveMonths_tEdit.Text = "0";
        }

        /// <summary>
        /// Control.Leave イベント(MasterSaveMonths_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void MasterSaveMonths_tEdit_Leave(object sender, EventArgs e)
        {
            if (this.MasterSaveMonths_tEdit.Text == "")
                this.MasterSaveMonths_tEdit.Text = "0";
        }
        //ADD END 2011/07/22 zhouyu FOR 連番 42 ---------------------<<<<<<

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FinancialYear_tNedit_ValueChanged(object sender, EventArgs e)
        //{
        //    if (this.StartYearDiv_tComboEditor.Value == null) return;

        //    // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        //    int financialYear = this.FinancialYear_tNedit.GetInt();
        //    // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<
        //    int workMonth = this.CompanyBiginDate_tDateEdit.GetDateMonth();
        //    int workDay = this.CompanyBiginDate_tDateEdit.GetDateDay();

        //    // 開始年区分
        //    // DEL 2008/10/22 不具合対応[6814]---------->>>>>
        //    #region 削除コード
        //    //// --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        //    //int startYearDiv;
        //    //int prevYear = financialYear - 1;
        //    //if (financialYear != 0)
        //    //{
        //    //    if ((workMonth != 0) && (workDay != 0))
        //    //    {
        //    //        if ((workMonth == 1) && (workDay == 1))
        //    //        {
        //    //            this.StartYearDiv_tComboEditor.Items.Clear();
        //    //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
        //    //            this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
        //    //            this.StartYearDiv_tComboEditor.Value = 1;
        //    //        }
        //    //        else
        //    //        {
        //    //            startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
        //    //            this.StartYearDiv_tComboEditor.Items.Clear();
        //    //            this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR + "（" + prevYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
        //    //            this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR + "（" + financialYear.ToString("0000") + "年" + workMonth.ToString("00") + "月度～ ）");
        //    //            this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
        //    //            this.StartYearDiv_tComboEditor.Value = startYearDiv;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
        //    //        this.StartYearDiv_tComboEditor.Items.Clear();
        //    //        this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
        //    //        this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
        //    //        this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
        //    //        this.StartYearDiv_tComboEditor.Value = startYearDiv;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    startYearDiv = (Int32)this.StartYearDiv_tComboEditor.Value;
        //    //    this.StartYearDiv_tComboEditor.Items.Clear();
        //    //    this.StartYearDiv_tComboEditor.Items.Add(0, PREV_YEAR);
        //    //    this.StartYearDiv_tComboEditor.Items.Add(1, NEXT_YEAR);
        //    //    this.StartYearDiv_tComboEditor.MaxDropDownItems = StartYearDiv_tComboEditor.Items.Count;
        //    //    this.StartYearDiv_tComboEditor.Value = startYearDiv;
        //    //}
        //    //// --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<
        //    #endregion  // 削除コード
        //    // DEL 2008/10/22 不具合対応[6814]----------<<<<<
        //    // ADD 2008/10/22 不具合対応[6814]↓
        //    // DEL 2008/10/28 不具合対応[7089]↓
        //    //InitializeStartYearDivUI(financialYear, workMonth, workDay, (Int32)this.StartYearDiv_tComboEditor.Value);

        //    // ADD 2008/10/28 不具合対応[7089]---------->>>>>
        //    if (this.StartYearDiv_tComboEditor.Value == null)
        //    {
        //        InitializeStartYearDivUI(financialYear, workMonth, workDay, 0);
        //    }
        //    else
        //    {
        //        InitializeStartYearDivUI(financialYear, workMonth, workDay, (Int32)this.StartYearDiv_tComboEditor.Value);
        //    }
        //    // ADD 2008/10/28 不具合対応[7089]----------<<<<<

        //    // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        //    //this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の開始日を設定します。";    // DEL 2008/10/28 不具合対応[7089]
        //    // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

        //    this.uLabel_StartMonthDivNote.Text = "※" + workMonth.ToString("00") + "月度の期間を設定します。";    // ADD 2008/10/28 不具合対応[7089]
        //}
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

        // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
#region 削除コード
//		/// <summary>
//		/// Control.Click Event(PrtBitmapGuid_Button, CursorBitmapGuid_Button)
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">イベントパラメータ</param>
//		/// <remarks>
//		/// <br>Note       : ファイルガイドボタンがクリックされたときに発生</br>
//		/// <br>Programmer : 20089 本多　美和</br>
//		/// <br>Date       : 2005.04.28</br>
//		/// </remarks>
//		private void PrtBitmapGuid_Button_Click(object sender, System.EventArgs e)
//		{
//
////			MessageBox.Show("今後住所ガイドを表示します","自社情報登録設定",MessageBoxButtons.OK,MessageBoxIcon.Information);
//			AddressGuide adg = new AddressGuide();
//			string EnterpriseCode = this._enterpriseCode;
//			AddressGuideResult adgRet = new AddressGuideResult();
//			adg.SearchAddress(EnterpriseCode, ref adgRet);
//
//			if (adgRet.AddressName != "")
//			{
//				this.Address1_tEdit.Text = adgRet.AddressName;
//				this.PostNo_tEdit.Text = adgRet.PostNo;	
//			}
//		}
//
//		/// <summary>
//		///	Control.Leave イベント
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">キー情報</param>
//		/// <remarks>
//		/// <br>Note			:	Controlがフォームのアクティブコントロールではなくなった際に発生します。</br>
//		/// <br>Programmer		:	22033 三崎  貴史</br>
//		/// <br>Date			:	2005.08.22</br>
//		/// </remarks>
//		private void PostNo_tEdit_Leave(object sender, System.EventArgs e)
//		{
//			if(this._changeFlg)
//			{// 郵便番号変更処理
//				EpPostNoChange();
//			}
//		}
//
//
//		private void PostNo_tEdit_Enter(object sender, System.EventArgs e)
//		{
//			 this._changeFlg = false;
//		}
//
//		/// <summary>
//		///	Control.KeyDown イベント(tNedit1)
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">キー情報</param>
//		/// <remarks>
//		/// <br>Note			: Control上でキーを押下した際に発生します。</br>
//		/// <br>Programmer		: 22033 三崎  貴史</br>
//		/// <br>Date			: 2005.06.03</br>
//		/// </remarks>
//		private void PostNo_tEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
////			if (((48 <= e.KeyValue) && (e.KeyValue <=  57)) ||	// 0～9キー
////				((96 <= e.KeyValue) && (e.KeyValue <= 105)))	// 0～9キー(テンキー)
//			if ((e.ToString() != "") &&
//				(e.KeyValue != 37) &&	  // 「←」キー
//				(e.KeyValue != 39))		  // 「→」キー
//			{
//				_changeFlg = true;		
//			}					
//		}
#endregion
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		# endregion
	}
}

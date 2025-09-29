using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
//using Broadleaf.Application.Remoting.ParamData;  // DEL 2008/06/03
using Broadleaf.Library.Text;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// SFKTN09000UAクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報設定を行います。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.03.18</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 當間 豊</br>
	/// <br>					・フレームの最小化対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.17 22025 當間 豊</br>
	/// <br>					・更新モードの初期フォーカス項目をSelectAll対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.18 22025 當間 豊</br>
	/// <br>					・ForeColorDisabledとBackColorDisabledの設定対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.20 22025 當間 豊</br>
	/// <br>					・Label(郵便番号マークの右)のBackColorDisabledの設定対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.02 22021 谷藤　範幸</br> 
	/// <br>					・保存確認後のエンターキー押下時のフォーカス対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.05 22033 三崎  貴史</br>
	/// <br>					・郵便番号検索修正</br>
	/// <br>Update Note: 2005.09.08 22021 谷藤　範幸</br>
	/// <br>					・ログイン情報取得部品の組込み</br>
	/// <br>Update Note: 2005.09.22 23001 秋山　亮介</br>
	/// <br>					・メッセージボックス表示部品の組込み</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   :        ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br>Update Note: 2006.01.13 22021 谷藤　範幸</br>
    /// <br>		   :        ・コード入力欄動作不全対応</br>
    /// <br>Update Note: 2006.08.28 22021 谷藤　範幸</br>
    /// <br>		   :        ・拠点OP判断ロジックの変更</br>
    /// <br>Update Note: 2006.09.06 22021 谷藤　範幸</br>
    /// <br>		   :        ・拠点OP無しの場合は他拠点伝票自社名印刷区分、本社/拠点機能区分の表示をEnableにする</br>
    /// <br>Update Note: 2006.09.26 22021 谷藤　範幸</br>
    /// <br>		   :        ・拠点コードが0～000000の間の場合に入力チェックがかかるように修正</br>
    /// <br>Update Note: 2006.12.13 22022 段上 知子</br>
    /// <br>					1.SF版を流用し携帯版を作成</br>
    /// <br>					2.自社名称1を必須入力へ変更</br>
    /// <br>Update Note: 2007.10.5  矢田 敬吾</br>
    /// <br>					倉庫1、2、3を画面に追加</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/03 30414　忍　幸史</br>
    /// <br>           :「拠点略称」「導入年月日」追加、「他拠点伝票自社名印刷区分」「予備２～１０」削除</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/09/08 30414　忍　幸史</br>
    /// <br>           :「導入年月日」を年月日のみ表示するよう修正</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/09/12 30414　忍　幸史</br>
    /// <br>           :倉庫ガイドボタンを追加</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2013/02/06 脇田　靖之</br>
    /// <br>           :削除済みデータの表示時に倉庫ガイドボタンが活性になっている障害の修正</br>
    /// -----------------------------------------------------------------------
    /// </remarks>
	public class SFKTN09000UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{

		# region Private Members (Component)
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel EmployeeCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Broadleaf.Library.Windows.Forms.TEdit edtSectionGuideNm;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Infragistics.Win.Misc.UltraLabel CompanyName1_Title_Label;
		private Broadleaf.Library.Windows.Forms.TNedit CompanyNameCd1_tNedit;
        private Broadleaf.Library.Windows.Forms.TEdit CompanyName1_tEdit;
        // ↓ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm3_Title_Label;
        private TEdit tEdit_WarehouseCode1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode3;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm1_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm2_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm3_tEdit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TEdit edtSectionGuideSnm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private TDateEdit IntroductionDate_tDateEdit;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide01_Button;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide03_Button;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide02_Button;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraButton Renewal_Button;
        // ↑ 2007.10.5 Keigo Yata add ////////////////////////////////////////////////////////
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		# endregion

		# region Constructor
		/// <summary>
		/// SFKTN09000UAクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public SFKTN09000UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
			// エディットをリストに追加
			SetCompanyNameControlList();
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////
            // エディットをリストに追加
            SetSectWarehouseNmControlList();
            // ↑ 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// メインフレーム新規ボタン用フラグ
			this._canNewFlg = true;
			// 変数初期化
			this.secInfoSetTable = new Hashtable();
			this.secInfoSetAcs = new SecInfoSetAcs();
			this.totalCount = 0;

			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// GridのIndexBuffer格納用変数の初期化
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 拠点OP判断用フラグ
            this._sectionFlg = false;
			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            #region // 2006.08.28 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            // --- 拠点オプション未導入で既にレコードが存在する場合は新規不可 --- //
            // 拠点オプションチェック
            //if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Trial_Contract))
            //{
            //this._canDelete = false;
            //this._canLogicalDeleteDataExtraction = false;

            //int dummy = 0;
            //// レコード件数取得の為Search
            //Search (ref dummy, 0);

            //if (this.secInfoSetTable.Count >= 1)
            //{
            //    // メインフレーム新規ボタン用フラグ
            //    this._canNewFlg = false;
            //}
            //}
            //else
            //{
            //this._canDelete = true;
            //this._canLogicalDeleteDataExtraction = true;

            //}

            // 2006.08.28 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            #endregion

            // 2006.08.28 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START

            // --- 拠点オプション未導入で既にレコードが存在する場合は新規不可 --- //
            // 拠点オプションチェック
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                this._canDelete = true;
                this._canLogicalDeleteDataExtraction = true;
            }
            else
            {
                this._canDelete = false;
                this._canLogicalDeleteDataExtraction = false;

                int dummy = 0;
                // レコード件数取得の為Search
                Search(ref dummy, 0);

                if (this.secInfoSetTable.Count >= 1)
                {
                    // メインフレーム新規ボタン用フラグ
                    this._canNewFlg = false;
                }
            }
            // 2006.08.28 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// プロパティー変数初期化
			this._canPrint = false;
			if (this._canNewFlg)
			{
				this._canNew = true;
			}
			else
			{
				this._canNew = false;
			}
			this._canClose = true;		
			this._defaultAutoFillToColumn = false;
			this._dataIndex = -1;
			this._canSpecificationSearch = false;

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFKTN09000UA));
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.EmployeeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.edtSectionGuideNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyNameCd1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CompanyName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.sectWarehouseNm1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.sectWarehouseNm2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectWarehouseNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectWarehouseNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.sectWarehouseNm3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectWarehouseNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.edtSectionGuideSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.IntroductionDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.WarehouseGuide01_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseGuide02_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseGuide03_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideSnm)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Delete_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(565, 329);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 17;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 373);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(947, 23);
            this.ultraStatusBar1.TabIndex = 45;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(842, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 46;
            this.Mode_Label.Text = "更新モード";
            // 
            // Revive_Button
            // 
            this.Revive_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Revive_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(690, 329);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 18;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(690, 329);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 18;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(815, 329);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 19;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // EmployeeCode_Title_Label
            // 
            appearance74.TextVAlignAsString = "Middle";
            this.EmployeeCode_Title_Label.Appearance = appearance74;
            this.EmployeeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmployeeCode_Title_Label.Location = new System.Drawing.Point(20, 30);
            this.EmployeeCode_Title_Label.Name = "EmployeeCode_Title_Label";
            this.EmployeeCode_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.EmployeeCode_Title_Label.TabIndex = 29;
            this.EmployeeCode_Title_Label.Text = "拠点コード";
            // 
            // edtSectionGuideNm
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtSectionGuideNm.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            this.edtSectionGuideNm.Appearance = appearance86;
            this.edtSectionGuideNm.AutoSelect = true;
            this.edtSectionGuideNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.edtSectionGuideNm.DataText = "";
            this.edtSectionGuideNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtSectionGuideNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtSectionGuideNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtSectionGuideNm.Location = new System.Drawing.Point(215, 60);
            this.edtSectionGuideNm.MaxLength = 6;
            this.edtSectionGuideNm.Name = "edtSectionGuideNm";
            this.edtSectionGuideNm.Size = new System.Drawing.Size(113, 24);
            this.edtSectionGuideNm.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance73;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(20, 60);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel2.TabIndex = 30;
            this.ultraLabel2.Text = "ガイド名称";
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel20.Location = new System.Drawing.Point(15, 165);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(915, 3);
            this.ultraLabel20.TabIndex = 34;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tEdit_SectionCode
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance25;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance26;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(215, 30);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 0;
            // 
            // CompanyName1_Title_Label
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.CompanyName1_Title_Label.Appearance = appearance63;
            this.CompanyName1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CompanyName1_Title_Label.Location = new System.Drawing.Point(20, 185);
            this.CompanyName1_Title_Label.Name = "CompanyName1_Title_Label";
            this.CompanyName1_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.CompanyName1_Title_Label.TabIndex = 35;
            this.CompanyName1_Title_Label.Text = "自社名称";
            // 
            // CompanyNameCd1_tNedit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.CompanyNameCd1_tNedit.ActiveAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance22.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            appearance22.TextVAlignAsString = "Middle";
            this.CompanyNameCd1_tNedit.Appearance = appearance22;
            this.CompanyNameCd1_tNedit.AutoSelect = true;
            this.CompanyNameCd1_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyNameCd1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CompanyNameCd1_tNedit.DataText = "";
            this.CompanyNameCd1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyNameCd1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CompanyNameCd1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyNameCd1_tNedit.Location = new System.Drawing.Point(215, 185);
            this.CompanyNameCd1_tNedit.MaxLength = 4;
            this.CompanyNameCd1_tNedit.Name = "CompanyNameCd1_tNedit";
            this.CompanyNameCd1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CompanyNameCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.CompanyNameCd1_tNedit.TabIndex = 6;
            this.CompanyNameCd1_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.CompanyNameCd1_tNedit.Leave += new System.EventHandler(this.CompanyNameCd_tNedit_Leave);
            this.CompanyNameCd1_tNedit.Enter += new System.EventHandler(this.CompanyNameCd_tNedit_Enter);
            // 
            // CompanyName1_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.Appearance = appearance20;
            this.CompanyName1_tEdit.AutoSelect = true;
            this.CompanyName1_tEdit.DataText = "";
            this.CompanyName1_tEdit.Enabled = false;
            this.CompanyName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 41, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName1_tEdit.Location = new System.Drawing.Point(265, 185);
            this.CompanyName1_tEdit.MaxLength = 41;
            this.CompanyName1_tEdit.Name = "CompanyName1_tEdit";
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(670, 24);
            this.CompanyName1_tEdit.TabIndex = 7;
            // 
            // sectWarehouseNm1_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.sectWarehouseNm1_Title_Label.Appearance = appearance16;
            this.sectWarehouseNm1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm1_Title_Label.Location = new System.Drawing.Point(20, 215);
            this.sectWarehouseNm1_Title_Label.Name = "sectWarehouseNm1_Title_Label";
            this.sectWarehouseNm1_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm1_Title_Label.TabIndex = 47;
            this.sectWarehouseNm1_Title_Label.Text = "倉庫1";
            // 
            // sectWarehouseNm2_Title_Label
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.sectWarehouseNm2_Title_Label.Appearance = appearance15;
            this.sectWarehouseNm2_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm2_Title_Label.Location = new System.Drawing.Point(20, 245);
            this.sectWarehouseNm2_Title_Label.Name = "sectWarehouseNm2_Title_Label";
            this.sectWarehouseNm2_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm2_Title_Label.TabIndex = 48;
            this.sectWarehouseNm2_Title_Label.Text = "倉庫2";
            // 
            // SectWarehouseNm1_tEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.SectWarehouseNm1_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.SectWarehouseNm1_tEdit.Appearance = appearance14;
            this.SectWarehouseNm1_tEdit.AutoSelect = true;
            this.SectWarehouseNm1_tEdit.DataText = "";
            this.SectWarehouseNm1_tEdit.Enabled = false;
            this.SectWarehouseNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm1_tEdit.Location = new System.Drawing.Point(281, 215);
            this.SectWarehouseNm1_tEdit.MaxLength = 20;
            this.SectWarehouseNm1_tEdit.Name = "SectWarehouseNm1_tEdit";
            this.SectWarehouseNm1_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm1_tEdit.TabIndex = 9;
            // 
            // SectWarehouseNm2_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.SectWarehouseNm2_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.SectWarehouseNm2_tEdit.Appearance = appearance12;
            this.SectWarehouseNm2_tEdit.AutoSelect = true;
            this.SectWarehouseNm2_tEdit.DataText = "";
            this.SectWarehouseNm2_tEdit.Enabled = false;
            this.SectWarehouseNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm2_tEdit.Location = new System.Drawing.Point(281, 245);
            this.SectWarehouseNm2_tEdit.MaxLength = 20;
            this.SectWarehouseNm2_tEdit.Name = "SectWarehouseNm2_tEdit";
            this.SectWarehouseNm2_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm2_tEdit.TabIndex = 12;
            // 
            // sectWarehouseNm3_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.sectWarehouseNm3_Title_Label.Appearance = appearance10;
            this.sectWarehouseNm3_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm3_Title_Label.Location = new System.Drawing.Point(20, 275);
            this.sectWarehouseNm3_Title_Label.Name = "sectWarehouseNm3_Title_Label";
            this.sectWarehouseNm3_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm3_Title_Label.TabIndex = 53;
            this.sectWarehouseNm3_Title_Label.Text = "倉庫3";
            // 
            // SectWarehouseNm3_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.SectWarehouseNm3_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.SectWarehouseNm3_tEdit.Appearance = appearance9;
            this.SectWarehouseNm3_tEdit.AutoSelect = true;
            this.SectWarehouseNm3_tEdit.DataText = "";
            this.SectWarehouseNm3_tEdit.Enabled = false;
            this.SectWarehouseNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm3_tEdit.Location = new System.Drawing.Point(281, 275);
            this.SectWarehouseNm3_tEdit.MaxLength = 20;
            this.SectWarehouseNm3_tEdit.Name = "SectWarehouseNm3_tEdit";
            this.SectWarehouseNm3_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm3_tEdit.TabIndex = 15;
            // 
            // tEdit_WarehouseCode1
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode1.ActiveAppearance = appearance6;
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode1.Appearance = appearance7;
            this.tEdit_WarehouseCode1.AutoSelect = true;
            this.tEdit_WarehouseCode1.DataText = "";
            this.tEdit_WarehouseCode1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode1.Location = new System.Drawing.Point(215, 215);
            this.tEdit_WarehouseCode1.MaxLength = 6;
            this.tEdit_WarehouseCode1.Name = "tEdit_WarehouseCode1";
            this.tEdit_WarehouseCode1.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode1.TabIndex = 8;
            // 
            // tEdit_WarehouseCode2
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode2.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode2.Appearance = appearance5;
            this.tEdit_WarehouseCode2.AutoSelect = true;
            this.tEdit_WarehouseCode2.DataText = "";
            this.tEdit_WarehouseCode2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode2.Location = new System.Drawing.Point(215, 245);
            this.tEdit_WarehouseCode2.MaxLength = 6;
            this.tEdit_WarehouseCode2.Name = "tEdit_WarehouseCode2";
            this.tEdit_WarehouseCode2.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode2.TabIndex = 11;
            // 
            // tEdit_WarehouseCode3
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode3.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode3.Appearance = appearance3;
            this.tEdit_WarehouseCode3.AutoSelect = true;
            this.tEdit_WarehouseCode3.DataText = "";
            this.tEdit_WarehouseCode3.Enabled = false;
            this.tEdit_WarehouseCode3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode3.Location = new System.Drawing.Point(215, 275);
            this.tEdit_WarehouseCode3.MaxLength = 6;
            this.tEdit_WarehouseCode3.Name = "tEdit_WarehouseCode3";
            this.tEdit_WarehouseCode3.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode3.TabIndex = 14;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraLabel18
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance72;
            this.ultraLabel18.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel18.Location = new System.Drawing.Point(20, 90);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel18.TabIndex = 31;
            this.ultraLabel18.Text = "拠点略称";
            // 
            // edtSectionGuideSnm
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtSectionGuideSnm.ActiveAppearance = appearance17;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.edtSectionGuideSnm.Appearance = appearance28;
            this.edtSectionGuideSnm.AutoSelect = true;
            this.edtSectionGuideSnm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.edtSectionGuideSnm.DataText = "";
            this.edtSectionGuideSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtSectionGuideSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtSectionGuideSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtSectionGuideSnm.Location = new System.Drawing.Point(215, 90);
            this.edtSectionGuideSnm.MaxLength = 10;
            this.edtSectionGuideSnm.Name = "edtSectionGuideSnm";
            this.edtSectionGuideSnm.Size = new System.Drawing.Size(175, 24);
            this.edtSectionGuideSnm.TabIndex = 2;
            // 
            // ultraLabel1
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance64;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 120);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel1.TabIndex = 55;
            this.ultraLabel1.Text = "導入年月日";
            // 
            // IntroductionDate_tDateEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IntroductionDate_tDateEdit.ActiveEditAppearance = appearance78;
            this.IntroductionDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.IntroductionDate_tDateEdit.CalendarDisp = true;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            appearance79.TextHAlignAsString = "Left";
            appearance79.TextVAlignAsString = "Middle";
            this.IntroductionDate_tDateEdit.EditAppearance = appearance79;
            this.IntroductionDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.IntroductionDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.IntroductionDate_tDateEdit.LabelAppearance = appearance80;
            this.IntroductionDate_tDateEdit.Location = new System.Drawing.Point(215, 120);
            this.IntroductionDate_tDateEdit.Name = "IntroductionDate_tDateEdit";
            this.IntroductionDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.IntroductionDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.IntroductionDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.IntroductionDate_tDateEdit.TabIndex = 5;
            this.IntroductionDate_tDateEdit.TabStop = true;
            // 
            // WarehouseGuide01_Button
            // 
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide01_Button.Appearance = appearance18;
            this.WarehouseGuide01_Button.Location = new System.Drawing.Point(609, 215);
            this.WarehouseGuide01_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide01_Button.Name = "WarehouseGuide01_Button";
            this.WarehouseGuide01_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide01_Button.TabIndex = 10;
            this.WarehouseGuide01_Button.Tag = "1";
            ultraToolTipInfo3.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide01_Button, ultraToolTipInfo3);
            this.WarehouseGuide01_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide01_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // WarehouseGuide02_Button
            // 
            this.WarehouseGuide02_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide02_Button.Appearance = appearance23;
            this.WarehouseGuide02_Button.Location = new System.Drawing.Point(609, 245);
            this.WarehouseGuide02_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide02_Button.Name = "WarehouseGuide02_Button";
            this.WarehouseGuide02_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide02_Button.TabIndex = 13;
            this.WarehouseGuide02_Button.Tag = "1";
            ultraToolTipInfo2.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide02_Button, ultraToolTipInfo2);
            this.WarehouseGuide02_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide02_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // WarehouseGuide03_Button
            // 
            this.WarehouseGuide03_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide03_Button.Appearance = appearance27;
            this.WarehouseGuide03_Button.Location = new System.Drawing.Point(609, 275);
            this.WarehouseGuide03_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide03_Button.Name = "WarehouseGuide03_Button";
            this.WarehouseGuide03_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide03_Button.TabIndex = 16;
            this.WarehouseGuide03_Button.Tag = "";
            ultraToolTipInfo1.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide03_Button, ultraToolTipInfo1);
            this.WarehouseGuide03_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide03_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Renewal_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(565, 329);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 17;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFKTN09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(947, 396);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.WarehouseGuide03_Button);
            this.Controls.Add(this.WarehouseGuide02_Button);
            this.Controls.Add(this.WarehouseGuide01_Button);
            this.Controls.Add(this.IntroductionDate_tDateEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.edtSectionGuideSnm);
            this.Controls.Add(this.tEdit_WarehouseCode3);
            this.Controls.Add(this.tEdit_WarehouseCode2);
            this.Controls.Add(this.tEdit_WarehouseCode1);
            this.Controls.Add(this.SectWarehouseNm3_tEdit);
            this.Controls.Add(this.sectWarehouseNm3_Title_Label);
            this.Controls.Add(this.SectWarehouseNm2_tEdit);
            this.Controls.Add(this.SectWarehouseNm1_tEdit);
            this.Controls.Add(this.sectWarehouseNm2_Title_Label);
            this.Controls.Add(this.sectWarehouseNm1_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CompanyName1_tEdit);
            this.Controls.Add(this.CompanyNameCd1_tNedit);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.edtSectionGuideNm);
            this.Controls.Add(this.CompanyName1_Title_Label);
            this.Controls.Add(this.ultraLabel20);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.EmployeeCode_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Delete_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFKTN09000UA";
            this.Text = "拠点設定";
            this.Load += new System.EventHandler(this.SFKTN09000UAC_Load);
            this.VisibleChanged += new System.EventHandler(this.SFKTN09000UAC_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFKTN09000UAC_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideSnm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Private Menbers 
		private SecInfoSetAcs secInfoSetAcs;

		//比較用clone
		private SecInfoSet _secInfoSetClone;
	
		private int totalCount;
		private string _enterpriseCode;
		private Hashtable secInfoSetTable;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		// GridのIndexBuffer格納用変数
		private int _IndexBuffer;
		// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // 拠点OP判断用フラグ
        private bool _sectionFlg;
		// メインフレーム新規ボタン用フラグ
		private bool _canNewFlg;

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		// コントロール格納用リスト
		private ArrayList _companyNameCdCtrlList;
		private ArrayList _companyNameCtrlList;
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////////
        // コントロール格納用リスト
        private ArrayList _sectWarehouseCdCtrlList;
        private ArrayList _sectWarehouseNmCtrlList;
        // ↑ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////////
        // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
        private ArrayList _warehouseGuideCtrlList;
        // --- ADD 2013/02/06 Y.Wakita ----------<<<<<
        // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;
        // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE	= "削除日";
		private const string SECTIONCODE	= "拠点コード";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		private const string SECTIONNAME	= "拠点名称";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

		private const string SECTIONGUNM	= "拠点ガイド名称";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		private const string SECTIONPR		= "拠点ＰＲ文";
//		private const string POSTNO			= "郵便番号";
//		private const string ADDRESS		= "住所";
//		private const string TEL1			= "電話番号１";
//		private const string TEL2			= "電話番号２";
//		private const string TEL3			= "電話番号３";
//		private const string TRANGUID		= "銀行振込案内文";
//		private const string TRANACNT1		= "銀行振込口座１";
//		private const string TRANACNT2		= "銀行振込口座２";
//		private const string TRANACNT3		= "銀行振込口座３";
//		private const string SECTIONNOTE1	= "摘要１";
//		private const string SECTIONNOTE2	= "摘要２";
//		private const string SLIPNAMECD		= "伝票自社名印刷区分";
//		private const string BILLSECNMCD	= "請求書自社名印刷区分";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        //private const string OTHSLIPNAMECD	= "他拠点伝票自社名印刷区分";  // DEL 2008/06/03
        // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
        //private const string MEINSECTIONCD	= "本社機能区分";
        // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        //private const string SECCDFORNUMBERING_TITLE	= "拠点コード(番号採番用)";  // DEL 2008/06/03
        //private const string COMPANYNAMECD1_TITLE = "自社名称コード１";  // DEL 2008/06/03
        private const string COMPANYNAMECD1_TITLE = "自社名称コード";  // ADD 2008/06/03
//		private const string COMPANYNAME1_TITLE		= "自社名称１";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME1_TITLE     = "自社名称";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME1_TITLE   = "整備システム名称";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		private const string COMPANYNAMECD2_TITLE	= "自社名称コード２";
//		private const string COMPANYNAME2_TITLE		= "自社名称２";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME2_TITLE     = "予備２";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME2_TITLE     = "鈑金システム名称";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD3_TITLE	= "自社名称コード３";
//		private const string COMPANYNAME3_TITLE		= "自社名称３";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME3_TITLE     = "予備３";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME3_TITLE     = "車販システム名称";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD4_TITLE	= "自社名称コード４";
//		private const string COMPANYNAME4_TITLE		= "自社名称４";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME4_TITLE     = "予備４";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME4_TITLE     = "請求書関連名称";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD5_TITLE	= "自社名称コード５";
//		private const string COMPANYNAME5_TITLE		= "自社名称５";
		private const string COMPANYNAME5_TITLE		= "予備５";
		private const string COMPANYNAMECD6_TITLE	= "自社名称コード６";
//		private const string COMPANYNAME6_TITLE		= "自社名称６";
		private const string COMPANYNAME6_TITLE		= "予備６";
		private const string COMPANYNAMECD7_TITLE	= "自社名称コード７";
//		private const string COMPANYNAME7_TITLE		= "自社名称７";
		private const string COMPANYNAME7_TITLE		= "予備７";
		private const string COMPANYNAMECD8_TITLE	= "自社名称コード８";
//		private const string COMPANYNAME8_TITLE		= "自社名称８";
		private const string COMPANYNAME8_TITLE		= "予備８";
		private const string COMPANYNAMECD9_TITLE	= "自社名称コード９";
//		private const string COMPANYNAME9_TITLE		= "自社名称９";
		private const string COMPANYNAME9_TITLE		= "予備９";
		private const string COMPANYNAMECD10_TITLE	= "自社名称コード１０";
//		private const string COMPANYNAME10_TITLE	= "自社名称１０";
		private const string COMPANYNAME10_TITLE		= "予備１０";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // ↓ 2007.10.5  Keigo Yata add///////////////////////////////////////////////////////////////////////
        private const string SECTWAREHOUSECD1_TITLE = "拠点倉庫コード１";
        private const string SECTWAREHOUSENM1_TITLE = "拠点倉庫名称";
        private const string SECTWAREHOUSECD2_TITLE = "拠点倉庫コード2";
        private const string SECTWAREHOUSENM2_TITLE = "拠点倉庫名称2";
        private const string SECTWAREHOUSECD3_TITLE = "拠点倉庫コード3";
        private const string SECTWAREHOUSENM3_TITLE = "拠点倉庫名称3";
        // ↑ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        private const string SECTIONGUIDESNM_TITLE = "拠点略称";
        private const string INTRODUCTIONDATE_TITLE = "導入年月日";
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

		private const string SECINFOSET_TABLE = "SECINFOSET";
		private const string GUID_TITLE		= "GUID";
		
		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		private bool _changeFlg = false;

		# endregion
		
		# region Main
		/// <summary>メイン処理</summary>
		/// <value></value>
		/// <remarks>アプリケーションのメイン エントリ ポイントです。</remarks>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFKTN09000UA());
		}
		# endregion

		# region Properties
		/// <summary>印刷可/不可プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>論理削除データ抽出可/不可プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>新規登録可/不可プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>削除可/不可プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{					 
			get{ return this._canSpecificationSearch; }
		}
		# endregion
		
		# region Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = SECINFOSET_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList secInfoSets = null;

			if (this.secInfoSetTable.Count == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this.secInfoSetAcs.SearchAll(
					out secInfoSets,
					this._enterpriseCode);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.totalCount = secInfoSets.Count;

						// 拠点情報クラスをデータセットへ展開する
						int index = 0;
						foreach(SecInfoSet secInfoSet in secInfoSets)
						{
							if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == false)
							{
								SecInfoSetToDataSet(secInfoSet.Clone(), index);
								++index;
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
						///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
						// サーチ
						TMsgDisp.Show( 
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
							"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
							"拠点情報登録修正", 				// プログラム名称
							"Search", 							// 処理名称
							TMsgDisp.OPE_GET, 					// オペレーション
							"読み込みに失敗しました。", 		// 表示するメッセージ
							status, 							// ステータス値
							this.secInfoSetAcs, 				// エラーが発生したオブジェクト
							MessageBoxButtons.OK, 				// 表示するボタン
							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
						// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
						///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
						//					MessageBox.Show(
						//						"読み込みに失敗しました。 st = " + status.ToString(),
						//						"エラー",
						//						MessageBoxButtons.OK,
						//						MessageBoxIcon.Error,
						//						MessageBoxDefaultButton.Button1);
						// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

						break;
					}
				}
			}
			else
			{
				this.totalCount = this.secInfoSetTable.Count;
				SortedList sortedList = new SortedList();

				foreach (SecInfoSet	secInfoSet in this.secInfoSetTable.Values)
				{
					sortedList.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.Clone());
				}

				// 拠点情報クラスをデータセットへ展開する
				int index = 0;
				foreach(SecInfoSet secInfoSet in sortedList.Values)
				{
					SecInfoSetToDataSet(secInfoSet.Clone(), index);
					++index;
				}
			}

			// 戻り値セット
			totalCount = this.totalCount;

			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
//
//			int dummy = 0;
//			ArrayList secInfoSets = null;
//
//			// 抽出対象件数が0の場合は、残りの全件を抽出
//			if (readCount == 0)
//			{
//				readCount =	this.totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
//			}
//
//			// 件数指定拠点情報検索処理（論理削除除く）
//			int status = this.secInfoSetAcs.SearchAll(
//							out secInfoSets,
//							out dummy,
//							out this.nextData, 
//							this._enterpriseCode,
//							readCount,
//							this.prevSecInfoSet);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					// 最終の拠点情報クラスを退避する
//					this.prevSecInfoSet = ((SecInfoSet)secInfoSets[secInfoSets.Count - 1]).Clone();
//
//					// 拠点情報クラスをデータセットへ展開する
//					int index = 0;
//					foreach(SecInfoSet secInfoSet in secInfoSets)
//					{
//						if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == false)
//						{
//							SecInfoSetToDataSet(secInfoSet.Clone(), index);
//							++index;
//						}
//					}
//
//					break;
//				}
//				case (int)ConstantManagement.DB_Status.ctDB_EOF:
//				{
//					break;
//				}
//				default:
//				{
/////////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
//					// サーチ
//					TMsgDisp.Show( 
//						this, 								// 親ウィンドウフォーム
//						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
//						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
//						"拠点情報登録修正", 				// プログラム名称
//						"SearchNext", 						// 処理名称
//						TMsgDisp.OPE_GET, 					// オペレーション
//						"読み込みに失敗しました。", 		// 表示するメッセージ
//						status, 							// ステータス値
//						this.secInfoSetAcs, 				// エラーが発生したオブジェクト
//						MessageBoxButtons.OK, 				// 表示するボタン
//						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
//// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
////					MessageBox.Show(
////						"読み込みに失敗しました。 st = " + status.ToString(),
////						"エラー",
////						MessageBoxButtons.OK,
////						MessageBoxIcon.Error,
////						MessageBoxDefaultButton.Button1);
//// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
//
//					break;
//				}
//			}
//
//			return status;    
			return 0;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int Delete()
		{

			// 保持しているデータセットより修正前情報取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

			int status;
			
			// 拠点情報論理削除処理
			status = this.secInfoSetAcs.LogicalDelete(ref secInfoSet);
			/////////////////////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL STA /////////
//			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"削除に失敗しました。 st = " + status.ToString(),
//					"エラー",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			////////////////////2005 07.07 H.NAKAMURA DEL END //////////////////////////////////////////////////////

			/////////////////////////////////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA /////////
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
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 論理削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"拠点情報登録修正", 				// プログラム名称
						"Delete", 							// 処理名称
						TMsgDisp.OPE_HIDE, 					// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this.secInfoSetAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"削除に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					return status;
				}
			}
			////////////////////2005 07.07 H.NAKAMURA ADD END //////////////////////////////////////////////////////
			
			// 拠点情報クラスデータセット展開処理
			SecInfoSetToDataSet(secInfoSet.Clone(), this.DataIndex);

			return status;
		
		}
		
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
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
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{

			Hashtable appearanceTable = new Hashtable();

			// 削除日
			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

			// 拠点コード
			appearanceTable.Add(SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点名称１＋２
//			appearanceTable.Add(SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 拠点ガイド名称
			appearanceTable.Add(SECTIONGUNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点略称
            appearanceTable.Add(SECTIONGUIDESNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点ＰＲ文
//			appearanceTable.Add(SECTIONPR, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 郵便番号
//			appearanceTable.Add(POSTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 住所１＋２＋３
//			appearanceTable.Add(ADDRESS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 電話番号１タイトル＋番号
//			appearanceTable.Add(TEL1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 電話番号２タイトル＋番号
//			appearanceTable.Add(TEL2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 電話番号３タイトル＋番号
//			appearanceTable.Add(TEL3, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 銀行振込案内文
//			appearanceTable.Add(TRANGUID, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 銀行振込口座１
//			appearanceTable.Add(TRANACNT1, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 銀行振込口座２
//			appearanceTable.Add(TRANACNT2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 銀行振込口座３
//			appearanceTable.Add(TRANACNT3, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 摘要１
//			appearanceTable.Add(SECTIONNOTE1, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 摘要２
//			appearanceTable.Add(SECTIONNOTE2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// 伝票自社名印刷区分
//			appearanceTable.Add(SLIPNAMECD, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
			// 拠点コード(番号採番用)
///////////////////////////////////////////////////////////////////// 2005.11.02 AKIYAMA ADD STA //
            //appearanceTable.Add(SECCDFORNUMBERING_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));  // DEL 2008/06/03
// 2005.11.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.11.02 AKIYAMA DEL STA //
//			appearanceTable.Add(SECCDFORNUMBERING_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.11.02 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 導入年月日
            appearanceTable.Add(INTRODUCTIONDATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // 自社名称コード
			appearanceTable.Add(COMPANYNAMECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
			// 自社名称
			appearanceTable.Add(COMPANYNAME1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 自社名称コード２
            appearanceTable.Add(COMPANYNAMECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称２
            appearanceTable.Add(COMPANYNAME2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード３
            appearanceTable.Add(COMPANYNAMECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称３
            appearanceTable.Add(COMPANYNAME3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード４
            appearanceTable.Add(COMPANYNAMECD4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称４
            appearanceTable.Add(COMPANYNAME4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード５
            appearanceTable.Add(COMPANYNAMECD5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称５
            appearanceTable.Add(COMPANYNAME5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード６
            appearanceTable.Add(COMPANYNAMECD6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称６
            appearanceTable.Add(COMPANYNAME6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード７
            appearanceTable.Add(COMPANYNAMECD7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称７
            appearanceTable.Add(COMPANYNAME7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード８
            appearanceTable.Add(COMPANYNAMECD8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称８
            appearanceTable.Add(COMPANYNAME8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード９
            appearanceTable.Add(COMPANYNAMECD9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称９
            appearanceTable.Add(COMPANYNAME9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自社名称コード１０
            appearanceTable.Add(COMPANYNAMECD10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // 自社名称１０
            appearanceTable.Add(COMPANYNAME10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////////           
            // 拠点倉庫コード1
            appearanceTable.Add(SECTWAREHOUSECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // 拠点倉庫名称1
            appearanceTable.Add(SECTWAREHOUSENM1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点倉庫コード2
            appearanceTable.Add(SECTWAREHOUSECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // 拠点倉庫名称2
            appearanceTable.Add(SECTWAREHOUSENM2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 拠点倉庫コード3
            appearanceTable.Add(SECTWAREHOUSECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // 拠点倉庫名称3
            appearanceTable.Add(SECTWAREHOUSENM3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ↑ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 他拠点伝票自社名印刷区分
            appearanceTable.Add(OTHSLIPNAMECD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 請求書自社名印刷区分
//			appearanceTable.Add(BILLSECNMCD, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
            // 本社機能区分
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //appearanceTable.Add(MEINSECTIONCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;

        }
        # endregion

        # region Private Methods
        /// <summary>
        /// 拠点情報クラスデータセット展開処理
        /// </summary>
        /// <param name="secInfoSet">拠点情報クラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点情報クラスをデータセットへ格納します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.03.18</br>
        /// </remarks>
        private void SecInfoSetToDataSet(SecInfoSet secInfoSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[SECINFOSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count - 1;

            }

            if (secInfoSet.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][DELETE_DATE] = secInfoSet.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONCODE] = secInfoSet.SectionCode;
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			///////////////////////2005 08.08 H.NAKAMURA ADD STA ///////////////////////////////////////////////////////////////////
//			// 拠点名称１＋２の間にスペースを挿入
//			// 拠点名称１＋２
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNAME] = secInfoSet.CompanyName1 + "　" + secInfoSet.CompanyName2;
//			///////////////////////2005 08.08 H.NAKAMURA ADD STA ///////////////////////////////////////////////////////////////////
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // 拠点ガイド名称
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONGUNM] = secInfoSet.SectionGuideNm;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点ＰＲ文
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONPR] = secInfoSet.CompanyPr;
//
//			// 郵便番号
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][POSTNO] = secInfoSet.PostNo;
//
//			// 住所１＋２＋３＋４
//			if (secInfoSet.Address2 == 0)
//			{
//				this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][ADDRESS] = secInfoSet.Address1 + secInfoSet.Address3 + " " + secInfoSet.Address4;
//			}
//			else
//			{
//				this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][ADDRESS] = secInfoSet.Address1 + secInfoSet.Address2 + "丁目" + secInfoSet.Address3 + " " + secInfoSet.Address4;
//			}
//
//			// 電話番号１タイトル＋番号
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL1] = secInfoSet.CompanyTelTitle1 + " " + secInfoSet.CompanyTelNo1;
//
//			// 電話番号２タイトル＋番号
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL2] = secInfoSet.CompanyTelTitle2 + " " + secInfoSet.CompanyTelNo2;
//
//			// 電話番号３タイトル＋番号
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL3] = secInfoSet.CompanyTelTitle3 + " " + secInfoSet.CompanyTelNo3;
//
//			// 銀行振込案内文
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANGUID] = secInfoSet.TransferGuidance;
//
//			// 銀行振込口座１
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT1] = secInfoSet.AccountNoInfo1;
//
//			// 銀行振込口座２
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT2] = secInfoSet.AccountNoInfo2;
//
//			// 銀行振込口座３
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT3] = secInfoSet.AccountNoInfo3;
//
//			// 摘要１
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNOTE1] = secInfoSet.CompanySetNote1;
//
//			// 摘要２
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNOTE2] = secInfoSet.CompanySetNote2;
//
//			// 伝票自社名印刷区分
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SLIPNAMECD] = secInfoSet.SlipCompanyNmCd + " " + secInfoSet.SlipCompanyNm;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点コード(番号採番用)
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECCDFORNUMBERING_TITLE] = secInfoSet.SecCdForNumbering;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // 自社名称コード
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD1_TITLE] = secInfoSet.CompanyNameCd1.ToString("0000");
            // 自社名称
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME1_TITLE] = secInfoSet.CompanyName1;

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 自社名称コード２
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD2_TITLE] = secInfoSet.CompanyNameCd2;
            // 自社名称２
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME2_TITLE] = secInfoSet.CompanyName2;

            // 自社名称コード３
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD3_TITLE] = secInfoSet.CompanyNameCd3;
            // 自社名称３
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME3_TITLE] = secInfoSet.CompanyName3;

            // 自社名称コード４
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD4_TITLE] = secInfoSet.CompanyNameCd4;
            // 自社名称４
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME4_TITLE] = secInfoSet.CompanyName4;

            // 自社名称コード５
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD5_TITLE] = secInfoSet.CompanyNameCd5;
            // 自社名称５
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME5_TITLE] = secInfoSet.CompanyName5;

            // 自社名称コード６
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD6_TITLE] = secInfoSet.CompanyNameCd6;
            // 自社名称６
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME6_TITLE] = secInfoSet.CompanyName6;

            // 自社名称コード７
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD7_TITLE] = secInfoSet.CompanyNameCd7;
            // 自社名称７
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME7_TITLE] = secInfoSet.CompanyName7;

            // 自社名称コード８
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD8_TITLE] = secInfoSet.CompanyNameCd8;
            // 自社名称８
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME8_TITLE] = secInfoSet.CompanyName8;

            // 自社名称コード９
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD9_TITLE] = secInfoSet.CompanyNameCd9;
            // 自社名称９
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME9_TITLE] = secInfoSet.CompanyName9;

            // 自社名称コード１０
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD10_TITLE] = secInfoSet.CompanyNameCd10;
            // 自社名称１０
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME10_TITLE] = secInfoSet.CompanyName10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            //拠点倉庫コード1
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD1_TITLE] = secInfoSet.SectWarehouseCd1;

            //拠点倉庫名称1
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM1_TITLE] = secInfoSet.SectWarehouseNm1;

            //拠点倉庫コード2
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD2_TITLE] = secInfoSet.SectWarehouseCd2;

            //拠点倉庫名称2
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM2_TITLE] = secInfoSet.SectWarehouseNm2;

            //拠点倉庫コード3
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD3_TITLE] = secInfoSet.SectWarehouseCd3;

            //拠点倉庫名称3
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM3_TITLE] = secInfoSet.SectWarehouseNm3;

            // ↑ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// 他拠点伝票自社名印刷区分
			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][OTHSLIPNAMECD] = secInfoSet.OthrSlipCompanyNm;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 請求書自社名印刷区分
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][BILLSECNMCD] = secInfoSet.BillCompanyNmPrtCd + " " + secInfoSet.BillCompanyNmPrtNm;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 本社機能区分
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][MEINSECTIONCD] = secInfoSet.MainOfficeFuncFlagName;
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

			// GUID
			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][GUID_TITLE] = secInfoSet.FileHeaderGuid;

			if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
			{
				this.secInfoSetTable.Remove(secInfoSet.FileHeaderGuid);
			}
			this.secInfoSetTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点略称
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONGUIDESNM_TITLE] = secInfoSet.SectionGuideSnm;
            
            // 導入年月日
            // --- CHG 2008/09/08 --------------------------------------------------------------------->>>>>
            //this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][INTRODUCTIONDATE_TITLE] = secInfoSet.IntroductionDate;
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][INTRODUCTIONDATE_TITLE] = secInfoSet.IntroductionDate.ToShortDateString();
            // --- CHG 2008/09/08 ---------------------------------------------------------------------<<<<<
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable secInfoSetTable = new DataTable(SECINFOSET_TABLE);

			// Addを行う順番が、列の表示順位となります。
			secInfoSetTable.Columns.Add(DELETE_DATE, typeof(string));			// 削除日
			secInfoSetTable.Columns.Add(SECTIONCODE, typeof(string));			// 拠点コード

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(SECTIONNAME, typeof(string));			// 拠点名称１＋２
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			secInfoSetTable.Columns.Add(SECTIONGUNM, typeof(string));			// 拠点ガイド名称

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetTable.Columns.Add(SECTIONGUIDESNM_TITLE, typeof(string));     // 拠点略称
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            //secInfoSetTable.Columns.Add(OTHSLIPNAMECD, typeof(string));			// 他拠点伝票自社名印刷区分  // DEL 2008/06/03
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //secInfoSetTable.Columns.Add(MEINSECTIONCD, typeof(string));			// 本社機能区分
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(SECTIONPR, typeof(string));				// 拠点ＰＲ文
//			secInfoSetTable.Columns.Add(POSTNO, typeof(string));				// 郵便番号
//			secInfoSetTable.Columns.Add(ADDRESS, typeof(string));				// 住所１＋２＋３
//			secInfoSetTable.Columns.Add(TEL1, typeof(string));					// 電話番号１タイトル＋番号
//			secInfoSetTable.Columns.Add(TEL2, typeof(string));					// 電話番号２タイトル＋番号
//			secInfoSetTable.Columns.Add(TEL3, typeof(string));					// 電話番号３タイトル＋番号
//			secInfoSetTable.Columns.Add(TRANGUID, typeof(string));				// 銀行振込案内文
//			secInfoSetTable.Columns.Add(TRANACNT1, typeof(string));				// 銀行振込口座１
//			secInfoSetTable.Columns.Add(TRANACNT2, typeof(string));				// 銀行振込口座２
//			secInfoSetTable.Columns.Add(TRANACNT3, typeof(string));				// 銀行振込口座３
//			secInfoSetTable.Columns.Add(SECTIONNOTE1, typeof(string));			// 摘要１
//			secInfoSetTable.Columns.Add(SECTIONNOTE2, typeof(string));			// 摘要２
//			secInfoSetTable.Columns.Add(SLIPNAMECD, typeof(string));			// 伝票自社名印刷区分
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSetTable.Columns.Add(SECCDFORNUMBERING_TITLE, typeof(string));	// 拠点コード(番号採番用)  // DEL 2008/06/03

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetTable.Columns.Add(INTRODUCTIONDATE_TITLE, typeof(string));    // 導入年月日
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

			secInfoSetTable.Columns.Add(COMPANYNAMECD1_TITLE, typeof(string));			// 自社名称コード
			secInfoSetTable.Columns.Add(COMPANYNAME1_TITLE, typeof(string));		// 自社名称
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSetTable.Columns.Add(COMPANYNAMECD2_TITLE, typeof(int));			// 自社名称コード２
			secInfoSetTable.Columns.Add(COMPANYNAME2_TITLE, typeof(string));		// 自社名称２
			secInfoSetTable.Columns.Add(COMPANYNAMECD3_TITLE, typeof(int));			// 自社名称コード３
			secInfoSetTable.Columns.Add(COMPANYNAME3_TITLE, typeof(string));		// 自社名称３
			secInfoSetTable.Columns.Add(COMPANYNAMECD4_TITLE, typeof(int));			// 自社名称コード４
			secInfoSetTable.Columns.Add(COMPANYNAME4_TITLE, typeof(string));		// 自社名称４
			secInfoSetTable.Columns.Add(COMPANYNAMECD5_TITLE, typeof(int));			// 自社名称コード５
			secInfoSetTable.Columns.Add(COMPANYNAME5_TITLE, typeof(string));		// 自社名称５
			secInfoSetTable.Columns.Add(COMPANYNAMECD6_TITLE, typeof(int));			// 自社名称コード６
			secInfoSetTable.Columns.Add(COMPANYNAME6_TITLE, typeof(string));		// 自社名称６
			secInfoSetTable.Columns.Add(COMPANYNAMECD7_TITLE, typeof(int));			// 自社名称コード７
			secInfoSetTable.Columns.Add(COMPANYNAME7_TITLE, typeof(string));		// 自社名称７
			secInfoSetTable.Columns.Add(COMPANYNAMECD8_TITLE, typeof(int));			// 自社名称コード８
			secInfoSetTable.Columns.Add(COMPANYNAME8_TITLE, typeof(string));		// 自社名称８
			secInfoSetTable.Columns.Add(COMPANYNAMECD9_TITLE, typeof(int));			// 自社名称コード９
			secInfoSetTable.Columns.Add(COMPANYNAME9_TITLE, typeof(string));		// 自社名称９
			secInfoSetTable.Columns.Add(COMPANYNAMECD10_TITLE, typeof(int));		// 自社名称コード１０
			secInfoSetTable.Columns.Add(COMPANYNAME10_TITLE, typeof(string));		// 自社名称１０
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD1_TITLE, typeof(string));    // 拠点倉庫コード1
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM1_TITLE, typeof(string));    // 拠点倉庫名称1
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD2_TITLE, typeof(string));    // 拠点倉庫コード2
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM2_TITLE, typeof(string));    // 拠点倉庫名称2
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD3_TITLE, typeof(string));    // 拠点倉庫コード3
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM3_TITLE, typeof(string));    // 拠点倉庫名称3
            // ↑ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(BILLSECNMCD, typeof(string));			// 請求書自社名印刷区分
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			secInfoSetTable.Columns.Add(GUID_TITLE, typeof(Guid));
//			secInfoSetTable.Columns.Add(SECINFOSET_TABLE, typeof(SecInfoSet));

			this.Bind_DataSet.Tables.Add(secInfoSetTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbSlipCompanyNmCd.Items.Clear();
//			this.cmbSlipCompanyNmCd.Items.Add(0, "拠点設定");									// ← 要変更
//			this.cmbSlipCompanyNmCd.Items.Add(1, "自社設定");									// ← 要変更
//			this.cmbSlipCompanyNmCd.MaxDropDownItems = this.cmbSlipCompanyNmCd.Items.Count;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this.cmbOthrSlipCompanyNmCd.Items.Clear();
			this.cmbOthrSlipCompanyNmCd.Items.Add(0, "他拠点情報");								// ← 要変更
			this.cmbOthrSlipCompanyNmCd.Items.Add(1, "自拠点情報");								// ← 要変更
			this.cmbOthrSlipCompanyNmCd.MaxDropDownItems = this.cmbOthrSlipCompanyNmCd.Items.Count;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/


///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.Items.Clear();
//			this.cmbBillCompanyNmPrtCd.Items.Add(0, "他拠点設定");								// ← 要変更
//			this.cmbBillCompanyNmPrtCd.Items.Add(1, "自社設定");								// ← 要変更
//			this.cmbBillCompanyNmPrtCd.MaxDropDownItems = this.cmbBillCompanyNmPrtCd.Items.Count;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Items.Clear();
            //this.cmbMainOfficeFuncFlag.Items.Add(0, "拠点");									// ← 要変更
            //this.cmbMainOfficeFuncFlag.Items.Add(1, "本社");									// ← 要変更
            //this.cmbMainOfficeFuncFlag.MaxDropDownItems = this.cmbMainOfficeFuncFlag.Items.Count;
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this.Ok_Button.Location = new System.Drawing.Point(690, 624);
			this.Cancel_Button.Location = new System.Drawing.Point(815, 624);
			this.Delete_Button.Location = new System.Drawing.Point(565, 624);
			this.Revive_Button.Location = new System.Drawing.Point(690, 624);
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.Ok_Button.Location = new System.Drawing.Point(690, 329);
            this.Cancel_Button.Location = new System.Drawing.Point(815, 329);
            this.Delete_Button.Location = new System.Drawing.Point(565, 329);
            this.Revive_Button.Location = new System.Drawing.Point(690, 329);
            this.Renewal_Button.Location = new System.Drawing.Point(565, 329);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenClear()
		{

			this.tEdit_SectionCode.Text = "";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyName1.Text = "";
//			this.edtCompanyName2.Text = "";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.edtSectionGuideNm.Text = "";

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.edtSectionGuideSnm.Text = "";
            this.IntroductionDate_tDateEdit.Clear();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyPr.Text = "";
//			this.edtPostNo.Text = "";
//			this.edtAddress1.Text = "";
//			this.nedtAddress2.Text = "";
//			this.edtAddress3.Text = "";
//			this.edtAddress4.Text = "";
//			this.edtCompanyTelTitle1.Text = "";
//			this.edtCompanyTelTitle2.Text = "";
//			this.edtCompanyTelTitle3.Text = "";
//			this.edtCompanyTelNo1.Text = "";
//			this.edtCompanyTelNo2.Text = "";
//			this.edtCompanyTelNo3.Text = "";
//			this.edtTransferGuidance.Text = "";
//			this.edtAccountNoInfo1.Text = "";
//			this.edtAccountNoInfo2.Text = "";
//			this.edtAccountNoInfo3.Text = "";
//			this.edtCompanySetNote1.Text = "";
//			this.edtCompanySetNote2.Text = "";
//			this.cmbSlipCompanyNmCd.SelectedIndex = 0;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.cmbOthrSlipCompanyNmCd.SelectedIndex = 0;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.SelectedIndex = 0;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.SelectedIndex = 0;
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this.SecCdForNumbering_tEdit.Clear();  // DEL 2008/06/03

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// 自社名称コード
				( ( TNedit )this._companyNameCdCtrlList[ ix ] ).Clear();
				// 自社名称
				( ( TEdit )this._companyNameCtrlList[ ix ] ).Clear();
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // 拠点倉庫コード
                ((TEdit)this._sectWarehouseCdCtrlList[ix]).Clear();
                // 拠点倉庫名称
                ((TEdit)this._sectWarehouseNmCtrlList[ix]).Clear();
            }
            // ↑ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.PostNoMark_tEdit.Appearance.BackColorDisabled = Color.FromName("White");
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			// 2006.1.13 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// 参照コード変更フラグ
			this._changeFlg = false;
			// 2006.1.13 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面の再構築を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenReconstruction()
		{

			if (this.DataIndex < 0)
			{
				SecInfoSet secinfoset = new SecInfoSet();
				//クローン作成
				this._secInfoSetClone = secinfoset.Clone();
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				DispToSecInfoSet(ref this._secInfoSetClone);

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;

				this.tEdit_SectionCode.Enabled = true;
				this.tEdit_SectionCode.Focus();

				// 画面入力許可制御処理
				ScreenInputPermissionControl(true);

			}
			else
			{
				// 保持しているデータセットより修正前情報取得
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
				SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];
				
				// 拠点情報クラス画面展開処理
				SecInfoSetToScreen(secInfoSet);

				if (secInfoSet.LogicalDeleteCode == 0)
				{
				// 更新可能状態の時
					this.Mode_Label.Text = UPDATE_MODE;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(true);

					// 更新モードの場合は、拠点コードのみ入力不可とします。
					this.tEdit_SectionCode.Enabled = false;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
					this.edtSectionGuideNm.Focus();
					this.edtSectionGuideNm.SelectAll();
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
////					this.ultraStatusBar1.Focus();			// 2005.06.17 TOUMA DEL 更新モードの初期フォーカス項目をSelectAll対応
//					this.edtCompanyName1.Focus();
//					this.edtCompanyName1.SelectAll();		// 2005.06.17 TOUMA ADD 更新モードの初期フォーカス項目をSelectAll対応
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					//クローン作成
					this._secInfoSetClone = secInfoSet.Clone();  
					//画面情報を比較用クローンにコピーする　　　　　   
					DispToSecInfoSet(ref this._secInfoSetClone);

				}
				else
				{
				// 削除状態の時
					this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(false);

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//					this.PostNoMark_tEdit.Appearance.BackColorDisabled = Color.FromName("Control");
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					this.Delete_Button.Focus();

				}
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{

			this.tEdit_SectionCode.Enabled = enabled;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyName1.Enabled = enabled;
//			this.edtCompanyName2.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.edtSectionGuideNm.Enabled = enabled;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.edtSectionGuideSnm.Enabled = enabled;
            this.IntroductionDate_tDateEdit.Enabled = enabled;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyPr.Enabled = enabled;
//			this.edtPostNo.Enabled = enabled;
//			this.edtAddress1.Enabled = enabled;
//			this.nedtAddress2.Enabled = enabled;
//			this.edtAddress3.Enabled = enabled;
//			this.edtAddress4.Enabled = enabled;
//			this.edtCompanyTelTitle1.Enabled = enabled;
//			this.edtCompanyTelTitle2.Enabled = enabled;
//			this.edtCompanyTelTitle3.Enabled = enabled;
//			this.edtCompanyTelNo1.Enabled = enabled;
//			this.edtCompanyTelNo2.Enabled = enabled;
//			this.edtCompanyTelNo3.Enabled = enabled;
//			this.edtTransferGuidance.Enabled = enabled;
//			this.edtAccountNoInfo1.Enabled = enabled;
//			this.edtAccountNoInfo2.Enabled = enabled;
//			this.edtAccountNoInfo3.Enabled = enabled;
//			this.edtCompanySetNote1.Enabled = enabled;
//			this.edtCompanySetNote2.Enabled = enabled;
//			this.cmbSlipCompanyNmCd.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.cmbOthrSlipCompanyNmCd.Enabled = enabled;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Enabled = enabled;
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this.SecCdForNumbering_tEdit.Enabled = enabled;  // DEL 2008/06/03

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// 自社名称コード
				( ( TNedit )this._companyNameCdCtrlList[ ix ] ).Enabled = enabled;
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            for (int ix = 0; ix < 3; ix++)
            {
                // 拠点倉庫コード
                ((TEdit)this._sectWarehouseCdCtrlList[ix]).Enabled = enabled;
                // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
                // 拠点倉庫ガイドボタン
                ((UltraButton)this._warehouseGuideCtrlList[ix]).Enabled = enabled;
                // --- ADD 2013/02/06 Y.Wakita ----------<<<<<
            }
            // ↑ 2007.10.5 Keigo Yatav add//////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.Enabled = enabled;
//			this.PostNo_Label1.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // 2006.09.06 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            // 拠点OPが無い場合は
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0)
            {
                //this.cmbOthrSlipCompanyNmCd.Enabled = false;  // DEL 2008/06/03
                // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
                //this.cmbMainOfficeFuncFlag.Enabled = false;
                // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<
            }
            // 2006.09.06 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

		}

		/// <summary>
		/// 拠点情報クラス画面展開処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報クラス</param>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス情報から画面にデータを展開します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void SecInfoSetToScreen(SecInfoSet secInfoSet)
		{
			
			// 拠点コード
			this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点名称
//			this.edtCompanyName1.Text = secInfoSet.CompanyName1;
//			this.edtCompanyName2.Text = secInfoSet.CompanyName2;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
			// 拠点ガイド名称
			this.edtSectionGuideNm.Text = secInfoSet.SectionGuideNm.Trim();

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点略称
            this.edtSectionGuideSnm.Text = secInfoSet.SectionGuideSnm.Trim();

            // 導入年月日
            this.IntroductionDate_tDateEdit.SetDateTime(secInfoSet.IntroductionDate);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点ＰＲ文
//			this.edtCompanyPr.Text = secInfoSet.CompanyPr;
//			
//			// 郵便番号
//			this.edtPostNo.Text = secInfoSet.PostNo;
//			
//			// 住所
//			this.edtAddress1.Text = secInfoSet.Address1;
//			this.nedtAddress2.SetInt(secInfoSet.Address2);
//			this.edtAddress3.Text = secInfoSet.Address3;
//			this.edtAddress4.Text = secInfoSet.Address4;
//			
//			// 電話番号１
//			this.edtCompanyTelTitle1.Text = secInfoSet.CompanyTelTitle1;
//			this.edtCompanyTelNo1.Text = secInfoSet.CompanyTelNo1;
//			
//			// 電話番号２
//			this.edtCompanyTelTitle2.Text = secInfoSet.CompanyTelTitle2;
//			this.edtCompanyTelNo2.Text = secInfoSet.CompanyTelNo2;
//			
//			// 電話番号３
//			this.edtCompanyTelTitle3.Text = secInfoSet.CompanyTelTitle3;
//			this.edtCompanyTelNo3.Text = secInfoSet.CompanyTelNo3;
//			
//			// 銀行振込案内文
//			this.edtTransferGuidance.Text = secInfoSet.TransferGuidance;
//
//			// 銀行振込口座
//			this.edtAccountNoInfo1.Text = secInfoSet.AccountNoInfo1;
//			this.edtAccountNoInfo2.Text = secInfoSet.AccountNoInfo2;
//			this.edtAccountNoInfo3.Text = secInfoSet.AccountNoInfo3;
//
//			// 摘要
//			this.edtCompanySetNote1.Text = secInfoSet.CompanySetNote1;
//			this.edtCompanySetNote2.Text = secInfoSet.CompanySetNote2;
//
//			// 伝票自社名印刷区分
//			this.cmbSlipCompanyNmCd.SelectedIndex = secInfoSet.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 他拠点伝票自社名印刷区分
            //this.cmbOthrSlipCompanyNmCd.SelectedIndex = secInfoSet.OthrSlipCompanyNmCd;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 請求書自社名印刷区分
//			this.cmbBillCompanyNmPrtCd.SelectedIndex = secInfoSet.BillCompanyNmPrtCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 本社機能区分
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.SelectedIndex = secInfoSet.MainOfficeFuncFlag;
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// 拠点コード(番号採番用)
			this.SecCdForNumbering_tEdit.DataText = secInfoSet.SecCdForNumbering;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
            for (int ix = 0; ix < 1; ix++){  // ADD 2008/06/03
				// 自社名称コード
				TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ ix ] as TNedit;
				if( companyNameCd_tNedit != null ) {
					companyNameCd_tNedit.SetInt( secInfoSet.GetCompanyNameCd( ix ) );
				}
				// 自社名称
				TEdit companyName_tEdit = this._companyNameCtrlList[ ix ] as TEdit;
				if( companyName_tEdit != null ) {
					companyName_tEdit.DataText = secInfoSet.GetCompanyName( ix ).Trim();
				}
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // 拠点倉庫コード
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                if (sectWarehouseCd_tEdit != null)
                {
                    sectWarehouseCd_tEdit.DataText = secInfoSet.GetSectWarehouseCd(ix).Trim();
                }
                // 拠点倉庫名称
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;
                if (sectWarehouseNm_tEdit != null)
                {
                    sectWarehouseNm_tEdit.DataText = secInfoSet.GetSectWarehouseNm(ix).Trim();
                }
            }
            //↑ 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////
		}

		/// <summary>
		/// 画面情報拠点情報クラス格納処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報クラス</param>
		/// <remarks>
		/// <br>Note       : 画面情報から拠点情報クラスにデータを格納します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
		{
			if (secInfoSet == null)
			{
				// 新規の場合
				secInfoSet = new SecInfoSet();
			}

			// 企業コード
			secInfoSet.EnterpriseCode = this._enterpriseCode;			// ← 要変更

			// 拠点コード
			secInfoSet.SectionCode = this.tEdit_SectionCode.Text;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点名称
//			secInfoSet.CompanyName1 = this.edtCompanyName1.Text;
//			secInfoSet.CompanyName2 = this.edtCompanyName2.Text;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
			// 拠点ガイド名称
			secInfoSet.SectionGuideNm = this.edtSectionGuideNm.Text;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点略称
            secInfoSet.SectionGuideSnm = this.edtSectionGuideSnm.Text;

            // 導入年月日
            secInfoSet.IntroductionDate = this.IntroductionDate_tDateEdit.GetDateTime();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 拠点ＰＲ文
//			secInfoSet.CompanyPr = this.edtCompanyPr.Text;
//			
//			// 郵便番号
//			secInfoSet.PostNo = this.edtPostNo.Text;
//			
//			// 住所
//			secInfoSet.Address1 = this.edtAddress1.Text;
//			secInfoSet.Address2 = this.nedtAddress2.GetInt();
//			secInfoSet.Address3 = this.edtAddress3.Text;
//			secInfoSet.Address4 = this.edtAddress4.Text;
//			
//			// 電話番号１
//			secInfoSet.CompanyTelTitle1 = this.edtCompanyTelTitle1.Text;
//			secInfoSet.CompanyTelNo1 = this.edtCompanyTelNo1.Text;
//			
//			// 電話番号２
//			secInfoSet.CompanyTelTitle2 = this.edtCompanyTelTitle2.Text;
//			secInfoSet.CompanyTelNo2 = this.edtCompanyTelNo2.Text;
//			
//			// 電話番号３
//			secInfoSet.CompanyTelTitle3 = this.edtCompanyTelTitle3.Text;
//			secInfoSet.CompanyTelNo3 = this.edtCompanyTelNo3.Text;
//			
//			// 銀行振込案内文
//			secInfoSet.TransferGuidance = this.edtTransferGuidance.Text;
//
//			// 銀行振込口座
//			secInfoSet.AccountNoInfo1 = this.edtAccountNoInfo1.Text;
//			secInfoSet.AccountNoInfo2 = this.edtAccountNoInfo2.Text;
//			secInfoSet.AccountNoInfo3 = this.edtAccountNoInfo3.Text;
//
//			// 摘要
//			secInfoSet.CompanySetNote1 = this.edtCompanySetNote1.Text;
//			secInfoSet.CompanySetNote2 = this.edtCompanySetNote2.Text;
//
//			// 伝票自社名印刷区分
//			secInfoSet.SlipCompanyNmCd = this.cmbSlipCompanyNmCd.SelectedIndex;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 他拠点伝票自社名印刷区分
            //secInfoSet.OthrSlipCompanyNmCd = this.cmbOthrSlipCompanyNmCd.SelectedIndex;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// 請求書自社名印刷区分
//			secInfoSet.BillCompanyNmPrtCd = this.cmbBillCompanyNmPrtCd.SelectedIndex;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 本社機能区分
            // --- CHG 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //secInfoSet.MainOfficeFuncFlag = this.cmbMainOfficeFuncFlag.SelectedIndex;
            secInfoSet.MainOfficeFuncFlag = 1;
            // --- CHG 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// 拠点コード(番号採番用)
			secInfoSet.SecCdForNumbering = this.SecCdForNumbering_tEdit.DataText;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// 自社名称コード
				TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ ix ] as TNedit;
				if( companyNameCd_tNedit != null ) {
					secInfoSet.SetCompanyNameCd( companyNameCd_tNedit.GetInt(), ix );
				}
				// 自社名称
				TEdit companyName_tEdit = this._companyNameCtrlList[ ix ] as TEdit;
				if( companyName_tEdit != null ) {
					secInfoSet.SetCompanyName( companyName_tEdit.DataText, ix );
				}
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // 拠点倉庫コード
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                if (sectWarehouseCd_tEdit != null)
                {
                    if (sectWarehouseCd_tEdit.DataText.Trim() == "")
                    {
                        secInfoSet.SetSectWarehouseCd(sectWarehouseCd_tEdit.DataText, ix);
                    }
                    else
                    {
                        secInfoSet.SetSectWarehouseCd(sectWarehouseCd_tEdit.DataText.Trim().PadLeft(4, '0'), ix);
                    }
                }
                // 拠点倉庫名称
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;
                if (sectWarehouseNm_tEdit != null)
                {
                    secInfoSet.SetSectWarehouseNm(sectWarehouseNm_tEdit.DataText, ix);
                }
            }
            // ↑ 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果 (true:OK/false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			if (this.tEdit_SectionCode.Text.Trim() == "")
			{
				control = this.tEdit_SectionCode;
				message = "拠点コードを入力して下さい。";
				result = false;
			}
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			else if (this.edtCompanyName1.Text.Trim() == "")
//			{
//				control = this.edtCompanyName1;
//				message = "拠点名称を入力して下さい。";
//				result = false;
//			}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			else if (this.edtSectionGuideNm.Text.Trim() == "")
			{
				control = this.edtSectionGuideNm;
				message = "拠点ガイド名称を入力して下さい。";
				result = false;
			}
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else if (this.edtSectionGuideSnm.Text.Trim() == "")
            {
                control = this.edtSectionGuideSnm;
                message = "拠点略称を入力して下さい。";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			else if( this.tEdit_SectionCode.Text.TrimEnd() == "000000" ) {
				control = this.tEdit_SectionCode;
				message = "拠点コードに 000000 は使用できません。";
				result = false;
			}
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			else if( this.SecCdForNumbering_tEdit.Text.Trim() == "" ) {
				control = this.SecCdForNumbering_tEdit;
				message = this.SecCdForNumbering_Title_Label.Text + "を入力してください。";
				result = false;
			}
			else if( this.SecCdForNumbering_tEdit.Text.Trim().Length != 2 ) {
				control = this.SecCdForNumbering_tEdit;
				message = this.SecCdForNumbering_Title_Label.Text + "は 2 桁で入力してください。";
				result = false;
			}
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else if (this.IntroductionDate_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.IntroductionDate_tDateEdit;
                message = "導入年月日を入力して下さい。";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
            // 2006.09.26 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            else if (TStrConv.StrToIntDef(this.tEdit_SectionCode.Text.TrimEnd(),-1) == 0)
            {
                control = this.tEdit_SectionCode;
                message = "拠点コードに " + this.tEdit_SectionCode.Text.TrimEnd() + " は使用できません。";
                result = false;
            }
            // 2006.09.26 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            else if (this.CompanyNameCd1_tNedit.Text.Trim() == "")
            {
                control = this.CompanyNameCd1_tNedit;
                message = this.CompanyName1_Title_Label.Text + "を入力してください。";
                result = false;
            }
            // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else
            {
                string warehouseCode1 = this.tEdit_WarehouseCode1.DataText.Trim();
                string warehouseCode2 = this.tEdit_WarehouseCode2.DataText.Trim();
                string warehouseCode3 = this.tEdit_WarehouseCode3.DataText.Trim();

                if (warehouseCode1 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode1);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode1;
                        this.tEdit_WarehouseCode1.SelectAll();
                        this.SectWarehouseNm1_tEdit.Clear();
                        message = "マスタに登録されていません。";
                        return (false);
                    }
                }
                if (warehouseCode2 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode2);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode2;
                        this.tEdit_WarehouseCode2.SelectAll();
                        this.SectWarehouseNm2_tEdit.Clear();
                        message = "マスタに登録されていません。";
                        return (false);
                    }
                }
                if (warehouseCode3 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode3);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode3;
                        this.tEdit_WarehouseCode3.SelectAll();
                        this.SectWarehouseNm3_tEdit.Clear();
                        message = "マスタに登録されていません。";
                        return (false);
                    }
                }

                if (warehouseCode1 != "")
                {
                    if (warehouseCode2 != "")
                    {
                        this.tEdit_WarehouseCode2.DataText = warehouseCode2.PadLeft(4, '0');

                        if (warehouseCode1.PadLeft(4, '0') == warehouseCode2.PadLeft(4, '0'))
                        {
                            control = this.tEdit_WarehouseCode2;
                            message = "倉庫コードが重複しています。";
                            result = false;
                        }
                    }

                    if (warehouseCode3 != "")
                    {
                        if (warehouseCode1.PadLeft(4, '0') == warehouseCode3.PadLeft(4, '0'))
                        {
                            control = this.tEdit_WarehouseCode3;
                            message = "倉庫コードが重複しています。";
                            result = false;
                        }
                    }
                }

                if ((warehouseCode2 != "") && (warehouseCode3 != ""))
                {
                    if (warehouseCode2.PadLeft(4, '0') == warehouseCode3.PadLeft(4, '0'))
                    {
                        control = this.tEdit_WarehouseCode3;
                        message = "倉庫コードが重複しています。";
                        result = false;
                    }
                }
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			return result;
		}

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		/// <summary>
		/// 自社名称コントロールリスト格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自社名称コード・自社名称のエディットをリストに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void SetCompanyNameControlList()
		{
			// 自社名称コードエディット
			this._companyNameCdCtrlList = new ArrayList();
			this._companyNameCdCtrlList.Add( this.CompanyNameCd1_tNedit );
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this._companyNameCdCtrlList.Add( this.CompanyNameCd2_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd3_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd4_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd5_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd6_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd7_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd8_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd9_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd10_tNedit );
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

			this._companyNameCtrlList = new ArrayList();
			this._companyNameCtrlList.Add( this.CompanyName1_tEdit );
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this._companyNameCtrlList.Add( this.CompanyName2_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName3_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName4_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName5_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName6_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName7_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName8_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName9_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName10_tEdit );
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// 自社名称情報変更処理
		/// </summary>
		/// <param name="companyNameCd_tNedit">自社名称コードエディット</param>
		/// <param name="companyName_tEdit">自社名称エディット</param>
		/// <param name="showMessage">メッセージの表示(true:表示, false:非表示)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : コードから自社名称を参照します。初回のみデータをバッファに保存します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private int CompanyNameCdChange( TNedit companyNameCd_tNedit, TEdit companyName_tEdit, bool showMessage )
		{
			int status = 0;
			CompanyNm companyNm = null;

			if( companyNameCd_tNedit.GetInt() == 0 ) {
				companyNameCd_tNedit.Clear();
				companyName_tEdit.Clear();
				return 0;
			}

			status = this.secInfoSetAcs.ReadCompanyNm( out companyNm, 
				this._enterpriseCode, companyNameCd_tNedit.GetInt() );
			switch( status ) 
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( companyNm.LogicalDeleteCode == 0 ) {
						// 論理削除されていない場合
						companyName_tEdit.DataText = companyNm.CompanyName1 + "　" + companyNm.CompanyName2;
					}
					else {
						// 論理削除されていた場合
                        companyName_tEdit.DataText = "削除済";  // ADD 2008/06/03

						if( showMessage == true ) {
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
							// コード参照（削除済）
							TMsgDisp.Show( 
								this, 								// 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
								"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
								"マスタから削除されています。", 	// 表示するメッセージ
								0, 									// ステータス値
								MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//							MessageBox.Show( 
//								"マスタから削除されています。", 
//								"入力チェック", 
//								MessageBoxButtons.OK, 
//								MessageBoxIcon.Exclamation, 
//								MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                            //companyName_tEdit.DataText = "削除済";  // DEL 2008/06/03

							companyNameCd_tNedit.Focus();
							companyNameCd_tNedit.SelectAll();
                        }

						return -2;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
                    companyName_tEdit.DataText = "未登録";  // ADD 2008/06/03

					if( showMessage == true ) {
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// コード参照（未登録）
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"マスタに登録されていません。", 	// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//						MessageBox.Show( 
//							"マスタに登録されていません。", 
//							"入力チェック", 
//							MessageBoxButtons.OK, 
//							MessageBoxIcon.Exclamation, 
//							MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                    //companyName_tEdit.DataText = "未登録";  // DEL 2008/06/03

						companyNameCd_tNedit.Focus();
						companyNameCd_tNedit.SelectAll();
                    }

					break;
				}
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// サーチ
					TMsgDisp.Show( 
						this, 									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
						"SFKTN09000U", 							// アセンブリＩＤまたはクラスＩＤ
						"拠点情報登録修正", 					// プログラム名称
						"CompanyNameCdChange", 					// 処理名称
						TMsgDisp.OPE_GET, 						// オペレーション
						"自社名称の読み込みに失敗しました。", 	// 表示するメッセージ
						status, 								// ステータス値
						this.secInfoSetAcs, 					// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 					// 表示するボタン
						MessageBoxDefaultButton.Button1 );		// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show( 
//						"自社名称の読み込みに失敗しました。 st = " + status.ToString(), 
//						"エラー", 
//						MessageBoxButtons.OK, 
//						MessageBoxIcon.Error, 
//						MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					companyNameCd_tNedit.Clear();
					companyName_tEdit.Clear();
					break;
				}
			}

			return status;
		}
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // ↓ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 拠点倉庫名称コントロールリスト格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点倉庫コード・拠点倉庫名称のエディットをリストに格納します。</br>
        /// <br>programer  : 矢田 敬吾</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        private void SetSectWarehouseNmControlList()
        {
            // 拠点倉庫名称コードエディット
            this._sectWarehouseCdCtrlList = new ArrayList();
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode1);
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode2);
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode3);

            this._sectWarehouseNmCtrlList = new ArrayList();
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm1_tEdit);
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm2_tEdit);
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm3_tEdit);

            // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
            this._warehouseGuideCtrlList = new ArrayList();
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide01_Button);
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide02_Button);
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide03_Button);
            // --- ADD 2013/02/06 Y.Wakita ----------<<<<<

        }
        // ↑ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////

        //↓ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 拠点倉庫名称情報変更処理
        /// </summary>
        /// <param name="sectWarehouseCd_tEdit">拠点倉庫コードエディット</param>
        /// <param name="sectWarehouseNm_tEdit">拠点倉庫名称エディット</param>
        /// <param name="showMessage">メッセージの表示(true:表示, false:非表示)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コードから拠点倉庫名称を参照します。初回のみデータをバッファに保存します。</br>
        /// <br>Programer  : 矢田 敬吾</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        private int SectWarehouseNmCdChange(TEdit sectWarehouseCd_tEdit, TEdit sectWarehouseNm_tEdit, bool showMessage)
        {
            int status = 0;

            string warehouseName = "";

            if (sectWarehouseCd_tEdit.Text == "")
            {
                sectWarehouseCd_tEdit.Clear();
                sectWarehouseNm_tEdit.Clear();
                return 0;
            }

            status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, this.tEdit_SectionCode.Text, sectWarehouseCd_tEdit.DataText.Trim().PadLeft(4, '0'));

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if(warehouseName != "削除済")
                        //if (warehouse.LogicalDeleteCode == 0)
                        {
                            // 論理削除されていない場合
                            sectWarehouseNm_tEdit.DataText = warehouseName;
                        }

                        else
                        {
                            // 論理削除されていた場合
                            if (showMessage == true)
                            {

                                // コード参照（削除済）
                                TMsgDisp.Show(
                                    this, 								// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                    "SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
                                    "マスタから削除されています。", 	// 表示するメッセージ
                                    0, 									// ステータス値
                                    MessageBoxButtons.OK);				// 表示するボタン
                                sectWarehouseNm_tEdit.DataText = "削除済";
                                sectWarehouseCd_tEdit.Focus();
                                sectWarehouseCd_tEdit.SelectAll();
                            }

                            sectWarehouseNm_tEdit.DataText = "削除済";
                            return -2;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        if (showMessage == true)
                        {

                            // コード参照（未登録）
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                "SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
                                "マスタに登録されていません。", 	// 表示するメッセージ
                                0, 									// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン

                            sectWarehouseNm_tEdit.DataText = "未登録";
                            sectWarehouseCd_tEdit.Focus();
                            sectWarehouseCd_tEdit.SelectAll();
                        }

                        sectWarehouseNm_tEdit.DataText = "未登録";
                        break;
                    }

                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 									  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			  // エラーレベル
                            "SFKTN09000U", 							  // アセンブリＩＤまたはクラスＩＤ
                            "拠点情報登録修正", 					  // プログラム名称
                            "SectWarehouseNmCdChange", 			      // 処理名称
                            TMsgDisp.OPE_GET, 						  // オペレーション
                            "拠点倉庫名称の読み込みに失敗しました。", // 表示するメッセージ
                            status, 								  // ステータス値
                            this.secInfoSetAcs, 					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					  // 表示するボタン
                            MessageBoxDefaultButton.Button1);		  // 初期表示ボタン

                        sectWarehouseCd_tEdit.Clear();
                        sectWarehouseNm_tEdit.Clear();
                        break;
                    }
            }

            return status;
        }
        // ↑ 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////////////////

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
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
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
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
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
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
		//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
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
//			string postNo = this.edtPostNo.DataText;  
//
//			// 住所マスタ読込み
//			adg.SearchAddressFromPostNo(postNo, ref adgRet);
//
//			if ((adgRet.PostNo != "") &&
//				(adgRet.AddressName != ""))
//			{
//				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>20050905 Misaki Insert Start
//				this.edtPostNo.Text		= adgRet.PostNo;
//				//20050905 Misaki Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//				this.edtAddress1.Text	= adgRet.AddressName;
//			}
//		}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

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
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.edtSectionGuideNm.Size = new System.Drawing.Size(113, 24);
            this.edtSectionGuideSnm.Size = new System.Drawing.Size(175, 24);
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Size = new System.Drawing.Size(170, 24);
            // --- DEL 2009/01/20 障害ID:10152対応------------------------------------------------------<<<<<
            this.IntroductionDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.CompanyNameCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(670, 24);
            this.tEdit_WarehouseCode1.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm1_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_WarehouseCode2.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm2_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_WarehouseCode3.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm3_tEdit.Size = new System.Drawing.Size(322, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		# endregion

		# region Control Events
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.ImageList = imageList16;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            this.WarehouseGuide01_Button.ImageList = imageList16;
            this.WarehouseGuide01_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide02_Button.ImageList = imageList16;
            this.WarehouseGuide02_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide03_Button.ImageList = imageList16;
            this.WarehouseGuide03_Button.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.Appearance.Image = Size16_Index.STAR1;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// 画面初期設定処理
			ScreenInitialSetting();

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

			/// <summary>
		/// 画面クローズイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを閉じようとした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// GridのIndexBuffer格納用変数の初期化
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}

		}

		/// <summary>
		/// 画面表示状態変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 画面の表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_VisibleChanged(object sender, System.EventArgs e)
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
			// 拠点オプション未導入の場合
            // 2006.08.26 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //else if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Trial_Contract))
            // 2006.08.26 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

            // 2006.08.26 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            // 2006.08.26 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            {
                // 拠点OP判断用フラグ
                if ((!this._sectionFlg) &&
                    (!this._canNewFlg) &&
                    (this._dataIndex == -1))
                {
                    TMsgDisp.Show(
                        this, 																// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,									// エラーレベル
                        "SFKTN09000U", 														// アセンブリＩＤまたはクラスＩＤ
                        "拠点オプションが未導入の場合は拠点は１件しか登録出来ません。",		// 表示するメッセージ
                        0, 																	// ステータス値
                        MessageBoxButtons.OK);												// 表示するボタン

                    this._sectionFlg = true;
                    this.Hide();
                    return;
                }
                // 画面強制Hideロジック
                else if ((this._dataIndex == -1) &&
                    (this._sectionFlg))
                {
                    this._sectionFlg = false;
                    this.Hide();
                    return;
                }
            }

			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._IndexBuffer == this._dataIndex)
			{
				return;
			}
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			Initial_Timer.Enabled = true;
			
			// 画面初期化処理
			ScreenClear();

		}

		/// <summary>
		/// 保存ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされた時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 新規時画面終了判断用ローカルフラグ
			bool secFlg = true;

			// 登録処理の集約 2005.05.26 by yap
			if (SaveProc() == false)
			{
				return;
			}
			// end 登録処理の集約 2005.05.26 by yap

			//拠点オプション有り
            // 2006.08.26 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) == PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) == PurchaseStatus.Trial_Contract))
            // 2006.08.26 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

            // 2006.08.26 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            // 2006.08.26 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            {
                secFlg = true;
            }
            else
            {
                secFlg = false;
            }

			// 登録モードの場合は画面を終了せずに連続入力を可能とする
			if ((this.Mode_Label.Text == INSERT_MODE) &&
				(secFlg))
			{
				// データインデックスを初期化する
				this.DataIndex = -1;

				// 画面初期化処理
				ScreenClear();
				this.tEdit_SectionCode.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;

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

				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// GridのIndexBuffer格納用変数の初期化
				this._IndexBuffer = -2;
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			}

		}

		/// <summary>
		/// 登録処理
		/// </summary>
		/// <remarks>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			Control control = null;
			string message = "";

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 画面入力情報不正チェック処理
            if (!ScreenDataCheck(ref control, ref message))
            {
                ///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                // 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
                //				MessageBox.Show(
                //					message,
                //					"入力チェック",
                //					MessageBoxButtons.OK,
                //					MessageBoxIcon.Exclamation,
                //					MessageBoxDefaultButton.Button1);
                // 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                control.Focus();
                return result;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
			// 自社名称コード参照チェック
            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
            for (int ix = 0; ix < 1; ix++)
            {  // ADD 2008/06/03
                TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ix] as TNedit;
                TEdit companyName_tEdit = this._companyNameCtrlList[ix] as TEdit;
                if ((companyNameCd_tNedit != null) &&
                    (companyName_tEdit != null))
                {
                    if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
            }
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点倉庫コード参照チェック
            for (int ix = 0; ix < 3; ix++)
            {
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;

                if ((sectWarehouseCd_tEdit != null) &&
                    (sectWarehouseNm_tEdit != null))
                {
                    if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // ↓ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            // 拠点倉庫コードのコントロールが空白の場合には詰める処理
            for (int ix = 0; ix < 3; ix++)
            {
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;

                if (tEdit_WarehouseCode1.DataText == "")
                {
                    tEdit_WarehouseCode1.DataText = tEdit_WarehouseCode2.DataText;
                    tEdit_WarehouseCode2.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm1_tEdit.DataText = SectWarehouseNm2_tEdit.DataText;
                    SectWarehouseNm2_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }
                
                else if((tEdit_WarehouseCode1.DataText != "") &&
                    (tEdit_WarehouseCode2.DataText == ""))
                {
                    tEdit_WarehouseCode2.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm2_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }

                else if ((tEdit_WarehouseCode1.DataText == "") &&
                    (tEdit_WarehouseCode2.DataText == ""))
                {
                    tEdit_WarehouseCode1.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm1_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }

                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                if ((sectWarehouseCd_tEdit != null) &&
                    (sectWarehouseNm_tEdit != null))
                {
                    if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            }
            // ↑ 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// 画面入力情報不正チェック処理
			if (!ScreenDataCheck(ref control, ref message))
			{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//				MessageBox.Show(
//					message,
//					"入力チェック",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
				control.Focus();
				return result;
			}
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            SecInfoSet secInfoSet = null;

			// 修正登録の時
			if (DataIndex >= 0)
			{
				// 保持しているデータセットより修正前情報取得
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			//	secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];
				secInfoSet = ((SecInfoSet)this.secInfoSetTable[guid]).Clone();
			}

			// 画面情報拠点情報クラス格納処理
			DispToSecInfoSet(ref secInfoSet);

			// 拠点情報登録・更新処理
			int status = this.secInfoSetAcs.Write(ref secInfoSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// 保存が行われた＝拠点OP無しの場合これ以上の新規はありえない
					//this._canNewFlg = false;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// コード重複
					TMsgDisp.Show( 
						this, 									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
						"SFKTN09000U", 							// アセンブリＩＤまたはクラスＩＤ
						"この拠点コードは既に使用されています。", 	// 表示するメッセージ
						0, 										// ステータス値
						MessageBoxButtons.OK );					// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"この拠点コードは既に使用されています。",
//						"情報",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					this.tEdit_SectionCode.Focus();
					return result;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return result;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"拠点情報登録修正", 				// プログラム名称
						"SaveProc", 						// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this.secInfoSetAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"登録に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
                    this._IndexBuffer = -2;
					return result;
				}
			}

			// 拠点情報クラスデータセット展開処理
			SecInfoSetToDataSet(secInfoSet, this.DataIndex);

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			result = true;
			return result;
		}

        private string GetCompanyName(int companyNameCd)
        {
            string companyName = "";

            if (companyNameCd == 0)
            {
                this.CompanyNameCd1_tNedit.Clear();
                this.CompanyName1_tEdit.Clear();
            }

            CompanyNm companyNm = new CompanyNm();
            int status = this.secInfoSetAcs.ReadCompanyNm(out companyNm, this._enterpriseCode, companyNameCd);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (companyNm.LogicalDeleteCode == 0)
                        {
                            // 論理削除されていない場合
                            companyName = companyNm.CompanyName1 + "　" + companyNm.CompanyName2;
                        }
                        else
                        {
                            companyName = "削除済";
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        companyName = "未登録";
                        break;
                    }
                default:
                    {
                        this.CompanyNameCd1_tNedit.Clear();
                        this.CompanyName1_tEdit.Clear();
                        break;
                    }
            }

            return companyName;
        }

		/// <summary>
		/// 閉じるボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされた時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//保存確認
				SecInfoSet compareSecInfoSet = new SecInfoSet();
				compareSecInfoSet = this._secInfoSetClone.Clone();
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END


				//現在の画面情報を取得する
				DispToSecInfoSet(ref compareSecInfoSet);
				//最初に取得した画面情報と比較
				if (!(this._secInfoSetClone.Equals(compareSecInfoSet)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 保存確認
					DialogResult res = TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						null, 								// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.YesNoCancel );	// 表示するボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					DialogResult res = MessageBox.Show(
//						"編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？",
//						"保存確認",
//						MessageBoxButtons.YesNoCancel,
//						MessageBoxIcon.Information);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					switch(res)
					{
						case DialogResult.Yes:
						{

							// 登録処理の集約 2005.05.26 by yap
							if (SaveProc() == false)
							{
								return;
							}
							// end 登録処理の集約 2005.05.26 by yap

							break;
						}
						case DialogResult.No:
						{
							// 画面非表示イベント
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}
							break;
						}
						default:
						{
                            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                            //this.Cancel_Button.Focus();
                            //// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                            if (_modeFlg)
                            {
                                tEdit_SectionCode.Focus();
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

			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// GridのIndexBuffer格納用変数の初期化
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this.DialogResult = DialogResult.Cancel;

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
		/// 完全削除ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされた時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
		
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
			// 完全削除確認
			DialogResult result = TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？", 				// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.OKCancel, 		// 表示するボタン
				MessageBoxDefaultButton.Button2 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//			DialogResult result = MessageBox.Show(
//				"データを削除します。" + "\r\n" + "よろしいですか？",
//				"削除確認",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			if (result == DialogResult.OK)
			{
				// 保持しているデータセットより情報取得
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
				SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

				// 拠点情報論理削除処理
				int status = this.secInfoSetAcs.Delete(secInfoSet);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex].Delete();
						this.secInfoSetTable.Remove(secInfoSet.FileHeaderGuid);

						break;
					}
					//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return;
					}
					//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					default:
					{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
						// 物理削除
						TMsgDisp.Show( 
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
							"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
							"拠点情報登録修正", 				// プログラム名称
							"Delete_Button_Click", 				// 処理名称
							TMsgDisp.OPE_DELETE, 				// オペレーション
							"削除に失敗しました。", 			// 表示するメッセージ
							status, 							// ステータス値
							this.secInfoSetAcs, 				// エラーが発生したオブジェクト
							MessageBoxButtons.OK, 				// 表示するボタン
							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//						MessageBox.Show(
//							"削除に失敗しました。 st = " + status.ToString(),
//							"エラー",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
						return;
					}
				}
			}
			else
			{
///////////////////////////////////////////////////////////////////// 2005.09.26 AKIYAMA ADD STA //
				this.Delete_Button.Focus();
// 2005.09.26 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return;
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// GridのIndexBuffer格納用変数の初期化
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// 復活ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされた時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            DialogResult res = TMsgDisp.Show(this,
                                 emErrorLevel.ERR_LEVEL_QUESTION,
                                 "SFKTN09000U",
                                 "現在表示中の拠点マスタを復活します。" + "\r\n" + "よろしいですか？",
                                 0,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

			// 保持しているデータセットより情報取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

			// 拠点情報登録・更新処理
			int status = this.secInfoSetAcs.Revival(ref secInfoSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA DEL Start
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					MessageBox.Show(
//						"既にデータが完全削除されています。" + status.ToString(),
//						"情報",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
//
//					break;
//				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA DEL END		
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// 復活失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFKTN09000U", 						// アセンブリＩＤまたはクラスＩＤ
						"拠点情報登録修正", 				// プログラム名称
						"Revive_Button_Click", 				// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"復活に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this.secInfoSetAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"復活に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			// 拠点情報クラスデータセット展開処理
			SecInfoSetToDataSet(secInfoSet, this.DataIndex);

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		/// <summary>
		/// Control.Enterイベント(CompanyNameCd_tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがフォーカスを得たときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void CompanyNameCd_tNedit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>
		///	Control.ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note			: Controlの値が変更された場合に発生します。</br>
		/// <br>Programmer		: 22021  谷藤　範幸</br>
		/// <br>Date			: 2006.01.13</br>
		/// </remarks>
		private void Control_ValueChanged(object sender, System.EventArgs e)
		{
			TNedit tNEdit = (TNedit)sender;
			if (tNEdit.Modified)
			{
				_changeFlg = true;
			}
		}

		/// <summary>
		/// Control.Leave イベント(CreditCompanyCode_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void CompanyNameCd_tNedit_Leave(object sender, System.EventArgs e)
		{
			// 自社名称コードエディット取得
			TNedit companyNameCd_tNedit = sender as TNedit;
			if( companyNameCd_tNedit == null ) {
				return;
			}
			// 自社名称エディット取得
			int index = this._companyNameCdCtrlList.IndexOf( companyNameCd_tNedit );
			TEdit companyName_tEdit = this._companyNameCtrlList[ index ] as TEdit;
			if( companyName_tEdit == null ) {
				return;
			}

			if( companyNameCd_tNedit.GetInt() == 0 ) 
            {
				companyNameCd_tNedit.Clear();
				companyName_tEdit.Clear();
			}
			else 
            {
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
				if( this._changeFlg == true ) {
					this._changeFlg = false;
					if( CompanyNameCdChange( companyNameCd_tNedit, companyName_tEdit, true ) != 0 ) {
						companyNameCd_tNedit.SelectAll();
					}
                    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                this._changeFlg = false;
                //if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, true) != 0)  // DEL 2008/06/03
                if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, false) != 0)
                {
					companyNameCd_tNedit.SelectAll();
				}
			}
		}

// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        
        /// <summary>
        /// ChanageFocus イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._changeFlg = false;

            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":   // 2009.03.24 新規モードからモード変更対応
                    {
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
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        break;
                    }
                case "tEdit_WarehouseCode1":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;
                        
                        // 拠点倉庫コードエディット取得
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;
                        
                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }
                        
                        // 拠点倉庫名称エディット取得
                        
                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);
                        
                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;
                        
                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide01_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode2;
                                }
                            }
                        }

                        break;
                    }


                case "tEdit_WarehouseCode2":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;

                        // 拠点倉庫コードエディット取得
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;

                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }

                        // 拠点倉庫名称エディット取得

                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);

                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;

                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide02_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode3;
                                }
                            }
                        }

                        break;
                    }

                case "tEdit_WarehouseCode3":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;

                        // 拠点倉庫コードエディット取得
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;

                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }

                        // 拠点倉庫名称エディット取得

                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);

                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;

                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide03_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    //e.NextCtrl = this.Ok_Button;
                                    e.NextCtrl = this.Renewal_Button;
                                }
                            }
                        }

                        break;
                    }

            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraButton uButton = (UltraButton)sender;

                Warehouse warehouse;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    if (uButton.Name == "WarehouseGuide01_Button")
                    {
                        this.tEdit_WarehouseCode1.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm1_tEdit.DataText = warehouse.WarehouseName.Trim();

                        this.tEdit_WarehouseCode2.Focus();  // ADD 2008/10/09 不具合対応[6353]
                    }
                    else if (uButton.Name == "WarehouseGuide02_Button")
                    {
                        this.tEdit_WarehouseCode2.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm2_tEdit.DataText = warehouse.WarehouseName.Trim();

                        this.tEdit_WarehouseCode3.Focus();  // ADD 2008/10/09 不具合対応[6353]
                    }
                    else if (uButton.Name == "WarehouseGuide03_Button")
                    {
                        this.tEdit_WarehouseCode3.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm3_tEdit.DataText = warehouse.WarehouseName.Trim();

                        //this.Ok_Button.Focus();  // ADD 2008/10/09 不具合対応[6353]
                        this.Renewal_Button.Focus();  // ADD 2008/10/09 不具合対応[6353]
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.secInfoSetAcs = new SecInfoSetAcs();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFKTN09000U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 拠点コード
            string sectionCd = tEdit_SectionCode.Text.TrimEnd();

            for (int i = 0; i < this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[i][SECTIONCODE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFKTN09000U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの拠点設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コードのクリア
                        tEdit_SectionCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "SFKTN09000U",                          // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの拠点設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 拠点コードのクリア
                                tEdit_SectionCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        
        // ↑ 2008.03.07 Keigo Yata add///////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
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
//		private void AddressCode_Guide_Button_Click(object sender, System.EventArgs e)
//		{
//			AddressGuide adg = new AddressGuide();
//			string EnterpriseCode = this._enterpriseCode;
//			AddressGuideResult adgRet = new AddressGuideResult();
//			adg.SearchAddress(EnterpriseCode, ref adgRet);
//
//			if (adgRet.AddressName != "")
//			{
//				this.edtAddress1.Text = adgRet.AddressName;
//				this.edtPostNo.Text = adgRet.PostNo;	
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
//		private void edtPostNo_Leave(object sender, System.EventArgs e)
//		{
//			// 郵便番号変更処理
//			if(this._changeFlg == true)
//			{
//				EpPostNoChange();
//			}
//		}
//
//		private void edtPostNo_Enter(object sender, System.EventArgs e)
//		{
//			this._changeFlg = false;
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
//		private void edtPostNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
////			if (((48 <= e.KeyValue) && (e.KeyValue <=  57)) ||	// 0～9キー
////				((96 <= e.KeyValue) && (e.KeyValue <= 105)))	// 0～9キー(テンキー)
//
//			if ((e.ToString() != "") &&
//				(e.KeyValue != 37) &&	  // 「←」キー
//				(e.KeyValue != 39))		  // 「→」キー
//			{
//				_changeFlg = true;		
//			}					
//		}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		# endregion
	}
}

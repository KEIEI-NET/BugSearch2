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
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 支払設定入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払設定を行います。
	///                  IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 21027 須川  程志郎</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.13 22024 寺坂　誉志</br>
	/// <br>           : 　①閉じるボタンにて↓キー押下時の制御を追加（コンポーネントバグ対策）</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.20 22024 寺坂　誉志</br>
	/// <br>           : 　①コード参照機能一時対応修正</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.21 22024 寺坂　誉志</br>
	/// <br>           : 　①CatchMouse、TNedit(ZeroSupp、ImeMode)、HotTracking</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.27 22024 寺坂　誉志</br>
	/// <br>           : 　①閉じるボタン上で↓キーや→キー入力時にフォーカス遷移しないように修正</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.05 23013 牧　将人</br>
	/// <br>           : 　フレームの最終最小化対応</br>
	/// <br>           :   ArrowKeyControlのCatchMouseプロパティをTrueに設定</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.06 23013 牧 将人</br>
	/// <br>           :   排他制御処理　排他がかかったとき、statusを表示しないよう修正</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.08 23013 牧 将人</br>
	/// <br>           :   エラーが出た時MessageBoxのOKボタンを押下した時、UI画面を閉じる処理</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.12 23013 牧 将人</br>
	/// <br>           :   排他制御処理の中に最小化対応処理を追加</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.03 23006 高橋 明子</br>
	/// <br>			   閉じるボタンへのフォーカスセット処理</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.08  23006 高橋 明子</br>
	/// <br>			   企業コード取得処理</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.24  23006 高橋 明子</br>
	/// <br>			   金種コード参照対応、入力チェック修正</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.24  23006 高橋 明子</br>
	/// <br>			   TMsgDisp部品対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.07  23006 高橋 明子</br>
	/// <br>			   ガイドボタン実装対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.18  23006 高橋 明子</br>
	/// <br>			   ガイドボタンフォーカス制御対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 高橋 明子</br>
	/// <br>			    UI子画面Hide時のOwner.Activate処理追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 高橋 明子</br>
	/// <br>			    親マスタ反映同期対応</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.13  23006 高橋 明子</br>
	/// <br>                コード参照項目の入力変更フラグを立てるときの条件修正</br>
    /// <br></br>
    /// <br>Update Note : 2006.06.09  22029 平山 恵美</br>
    /// <br>                支払設定マスタ　新レイアウト対応</br>
    /// <br></br>
    /// <br>Update Note :  2007.05.27 30005 木建 翼</br>
    /// <br>                金額種別名称取得の修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.06.18  徳永 俊詞</br>
    /// <br>	　      ・項目「支払伝票呼出月数」削除、多数ロジック間違いFIX、9/10番目のフィールド削除等</br>
    /// <br></br>
    /// </remarks>
	public class SFSIR09020UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd1RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd2RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd3RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd4RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd5RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd6RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd7RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd8RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd1RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd2RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd3RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd4RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd5RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd6RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd7RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd8RF_tNedit;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCdRF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd1RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd2RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd3RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd4RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd5RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd6RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd7RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd8RF_Label;
		private System.Windows.Forms.Timer timer1;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd1RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd2RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd3RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd4RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd5RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd6RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd7RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd8RF_tUltraBtn;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private UltraButton InitSelMoneyKindCdRF_tUltraBtn;
        private TEdit InitSelMoneyKindCdRF_tEdit;
        private TNedit InitSelMoneyKindCdRF_tNedit;
        private UltraLabel InitSelMoneyKindCdRF_Label;
        private UltraLabel PayStMoneyKindCd9RF_Label;
        private TNedit PayStMoneyKindCd9RF_tNedit;
        private UltraButton PayStMoneyKindCd9RF_tUltraBtn;
        private UltraLabel PayStMoneyKindCd10RF_Label;
        private TNedit PayStMoneyKindCd10RF_tNedit;
        private UltraButton PayStMoneyKindCd10RF_tUltraBtn;
        private TEdit PayStMoneyKindCd10RF_tEdit;
        private TEdit PayStMoneyKindCd9RF_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 支払設定入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払設定入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public SFSIR09020UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// 支払設定アクセスクラス
			this.paymentSetAcs = new PaymentSetAcs();

			// 支払設定クラス
			this.paymentSet = new PaymentSet();

			// 画面コンポーネント登録
			tneditCompList = new ArrayList();
			tneditCompList.Add(this.PayStMoneyKindCd1RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd2RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd3RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd4RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd5RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd6RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd7RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd8RF_tNedit);
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //tneditCompList.Add(this.PayStMoneyKindCd9RF_tNedit);
            //tneditCompList.Add(this.PayStMoneyKindCd10RF_tNedit);
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			tneditCompList.TrimToSize();

			teditCompList = new ArrayList();;
			teditCompList.Add(this.PayStMoneyKindCd1RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd2RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd3RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd4RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd5RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd6RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd7RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd8RF_tEdit);
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //teditCompList.Add(this.PayStMoneyKindCd9RF_tEdit);
            //teditCompList.Add(this.PayStMoneyKindCd10RF_tEdit);
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            teditCompList.TrimToSize();

			
			// 印刷可能フラグを設定します。
			// Frameの印刷ボタンの表示非表示の制御に使用します。
			_canPrint = false;

			// 画面クローズ許可を設定します。
			// CloseかHideかの制御に使用します。
			_canClose = false;

			// 企業コードを取得する
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
			// 金種データ格納用
			this._moneyKindAcs = new MoneyKindAcs();
            this._moneyKindAcs.IsLocalDBRead = false;  // iitani a 2007.05.23 リモート固定で読むよう修正
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
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
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo11 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo9 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo10 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("金額種別ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR09020UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd1RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCdRF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd2RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd1RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd4RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd3RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd8RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd7RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd6RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd5RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd2RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd3RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd4RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd5RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd6RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd7RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd1RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd2RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd3RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd4RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd5RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd6RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd7RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd8RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd8RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PayStMoneyKindCd1RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd2RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd3RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd4RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd5RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd6RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd7RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd8RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.InitSelMoneyKindCdRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.InitSelMoneyKindCdRF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.InitSelMoneyKindCdRF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.InitSelMoneyKindCdRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd10RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd10RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd10RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd9RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd9RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd9RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd10RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd9RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 340);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(422, 23);
            this.ultraStatusBar1.TabIndex = 700;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(156, 279);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 23;
            this.Ok_Button.Tag = "210";
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(281, 279);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 24;
            this.Cancel_Button.Tag = "220";
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // PayStMoneyKindCd1RF_tEdit
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd1RF_tEdit.ActiveAppearance = appearance61;
            appearance62.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd1RF_tEdit.Appearance = appearance62;
            this.PayStMoneyKindCd1RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd1RF_tEdit.DataText = "";
            this.PayStMoneyKindCd1RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd1RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd1RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd1RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd1RF_tEdit.Location = new System.Drawing.Point(122, 51);
            this.PayStMoneyKindCd1RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd1RF_tEdit.Name = "PayStMoneyKindCd1RF_tEdit";
            this.PayStMoneyKindCd1RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd1RF_tEdit.TabIndex = 620;
            this.PayStMoneyKindCd1RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd1RF_tEdit.Tag = "111";
            // 
            // PayStMoneyKindCdRF_Label
            // 
            appearance63.ForeColor = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Center";
            appearance63.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCdRF_Label.Appearance = appearance63;
            this.PayStMoneyKindCdRF_Label.BackColorInternal = System.Drawing.SystemColors.Highlight;
            this.PayStMoneyKindCdRF_Label.Location = new System.Drawing.Point(56, 26);
            this.PayStMoneyKindCdRF_Label.Name = "PayStMoneyKindCdRF_Label";
            this.PayStMoneyKindCdRF_Label.Size = new System.Drawing.Size(179, 24);
            this.PayStMoneyKindCdRF_Label.TabIndex = 503;
            this.PayStMoneyKindCdRF_Label.Tag = "";
            this.PayStMoneyKindCdRF_Label.Text = "支払設定金種コード";
            // 
            // PayStMoneyKindCd2RF_tEdit
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd2RF_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd2RF_tEdit.Appearance = appearance65;
            this.PayStMoneyKindCd2RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd2RF_tEdit.DataText = "";
            this.PayStMoneyKindCd2RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd2RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd2RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd2RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd2RF_tEdit.Location = new System.Drawing.Point(122, 76);
            this.PayStMoneyKindCd2RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd2RF_tEdit.Name = "PayStMoneyKindCd2RF_tEdit";
            this.PayStMoneyKindCd2RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd2RF_tEdit.TabIndex = 630;
            this.PayStMoneyKindCd2RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd2RF_tEdit.Tag = "112";
            // 
            // PayStMoneyKindCd1RF_Label
            // 
            appearance66.TextHAlignAsString = "Center";
            appearance66.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd1RF_Label.Appearance = appearance66;
            this.PayStMoneyKindCd1RF_Label.Location = new System.Drawing.Point(36, 51);
            this.PayStMoneyKindCd1RF_Label.Name = "PayStMoneyKindCd1RF_Label";
            this.PayStMoneyKindCd1RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd1RF_Label.TabIndex = 504;
            this.PayStMoneyKindCd1RF_Label.Tag = "2";
            this.PayStMoneyKindCd1RF_Label.Text = "１";
            // 
            // PayStMoneyKindCd4RF_tEdit
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd4RF_tEdit.ActiveAppearance = appearance67;
            appearance68.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd4RF_tEdit.Appearance = appearance68;
            this.PayStMoneyKindCd4RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd4RF_tEdit.DataText = "";
            this.PayStMoneyKindCd4RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd4RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd4RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd4RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd4RF_tEdit.Location = new System.Drawing.Point(122, 126);
            this.PayStMoneyKindCd4RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd4RF_tEdit.Name = "PayStMoneyKindCd4RF_tEdit";
            this.PayStMoneyKindCd4RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd4RF_tEdit.TabIndex = 650;
            this.PayStMoneyKindCd4RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd4RF_tEdit.Tag = "114";
            // 
            // PayStMoneyKindCd3RF_tEdit
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd3RF_tEdit.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd3RF_tEdit.Appearance = appearance70;
            this.PayStMoneyKindCd3RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd3RF_tEdit.DataText = "";
            this.PayStMoneyKindCd3RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd3RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd3RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd3RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd3RF_tEdit.Location = new System.Drawing.Point(122, 101);
            this.PayStMoneyKindCd3RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd3RF_tEdit.Name = "PayStMoneyKindCd3RF_tEdit";
            this.PayStMoneyKindCd3RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd3RF_tEdit.TabIndex = 640;
            this.PayStMoneyKindCd3RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd3RF_tEdit.Tag = "113";
            // 
            // PayStMoneyKindCd8RF_tEdit
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd8RF_tEdit.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd8RF_tEdit.Appearance = appearance72;
            this.PayStMoneyKindCd8RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd8RF_tEdit.DataText = "";
            this.PayStMoneyKindCd8RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd8RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd8RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd8RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd8RF_tEdit.Location = new System.Drawing.Point(122, 226);
            this.PayStMoneyKindCd8RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd8RF_tEdit.Name = "PayStMoneyKindCd8RF_tEdit";
            this.PayStMoneyKindCd8RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd8RF_tEdit.TabIndex = 690;
            this.PayStMoneyKindCd8RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd8RF_tEdit.Tag = "118";
            // 
            // PayStMoneyKindCd7RF_tEdit
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd7RF_tEdit.ActiveAppearance = appearance73;
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd7RF_tEdit.Appearance = appearance74;
            this.PayStMoneyKindCd7RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd7RF_tEdit.DataText = "";
            this.PayStMoneyKindCd7RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd7RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd7RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd7RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd7RF_tEdit.Location = new System.Drawing.Point(122, 201);
            this.PayStMoneyKindCd7RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd7RF_tEdit.Name = "PayStMoneyKindCd7RF_tEdit";
            this.PayStMoneyKindCd7RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd7RF_tEdit.TabIndex = 680;
            this.PayStMoneyKindCd7RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd7RF_tEdit.Tag = "117";
            // 
            // PayStMoneyKindCd6RF_tEdit
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd6RF_tEdit.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd6RF_tEdit.Appearance = appearance76;
            this.PayStMoneyKindCd6RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd6RF_tEdit.DataText = "";
            this.PayStMoneyKindCd6RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd6RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd6RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd6RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd6RF_tEdit.Location = new System.Drawing.Point(122, 176);
            this.PayStMoneyKindCd6RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd6RF_tEdit.Name = "PayStMoneyKindCd6RF_tEdit";
            this.PayStMoneyKindCd6RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd6RF_tEdit.TabIndex = 670;
            this.PayStMoneyKindCd6RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd6RF_tEdit.Tag = "116";
            // 
            // PayStMoneyKindCd5RF_tEdit
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd5RF_tEdit.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd5RF_tEdit.Appearance = appearance78;
            this.PayStMoneyKindCd5RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd5RF_tEdit.DataText = "";
            this.PayStMoneyKindCd5RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd5RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd5RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd5RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd5RF_tEdit.Location = new System.Drawing.Point(122, 151);
            this.PayStMoneyKindCd5RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd5RF_tEdit.Name = "PayStMoneyKindCd5RF_tEdit";
            this.PayStMoneyKindCd5RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd5RF_tEdit.TabIndex = 660;
            this.PayStMoneyKindCd5RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd5RF_tEdit.Tag = "115";
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
            // Mode_Label
            // 
            appearance79.ForeColor = System.Drawing.Color.White;
            appearance79.TextHAlignAsString = "Center";
            appearance79.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance79;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(318, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 501;
            this.Mode_Label.Tag = "";
            // 
            // PayStMoneyKindCd2RF_Label
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd2RF_Label.Appearance = appearance80;
            this.PayStMoneyKindCd2RF_Label.Location = new System.Drawing.Point(36, 76);
            this.PayStMoneyKindCd2RF_Label.Name = "PayStMoneyKindCd2RF_Label";
            this.PayStMoneyKindCd2RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd2RF_Label.TabIndex = 505;
            this.PayStMoneyKindCd2RF_Label.Tag = "3";
            this.PayStMoneyKindCd2RF_Label.Text = "２";
            // 
            // PayStMoneyKindCd3RF_Label
            // 
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd3RF_Label.Appearance = appearance81;
            this.PayStMoneyKindCd3RF_Label.Location = new System.Drawing.Point(36, 101);
            this.PayStMoneyKindCd3RF_Label.Name = "PayStMoneyKindCd3RF_Label";
            this.PayStMoneyKindCd3RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd3RF_Label.TabIndex = 506;
            this.PayStMoneyKindCd3RF_Label.Tag = "4";
            this.PayStMoneyKindCd3RF_Label.Text = "３";
            // 
            // PayStMoneyKindCd4RF_Label
            // 
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd4RF_Label.Appearance = appearance82;
            this.PayStMoneyKindCd4RF_Label.Location = new System.Drawing.Point(36, 126);
            this.PayStMoneyKindCd4RF_Label.Name = "PayStMoneyKindCd4RF_Label";
            this.PayStMoneyKindCd4RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd4RF_Label.TabIndex = 507;
            this.PayStMoneyKindCd4RF_Label.Tag = "5";
            this.PayStMoneyKindCd4RF_Label.Text = "４";
            // 
            // PayStMoneyKindCd5RF_Label
            // 
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd5RF_Label.Appearance = appearance83;
            this.PayStMoneyKindCd5RF_Label.Location = new System.Drawing.Point(36, 151);
            this.PayStMoneyKindCd5RF_Label.Name = "PayStMoneyKindCd5RF_Label";
            this.PayStMoneyKindCd5RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd5RF_Label.TabIndex = 508;
            this.PayStMoneyKindCd5RF_Label.Tag = "6";
            this.PayStMoneyKindCd5RF_Label.Text = "５";
            // 
            // PayStMoneyKindCd6RF_Label
            // 
            appearance84.TextHAlignAsString = "Center";
            appearance84.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd6RF_Label.Appearance = appearance84;
            this.PayStMoneyKindCd6RF_Label.Location = new System.Drawing.Point(36, 176);
            this.PayStMoneyKindCd6RF_Label.Name = "PayStMoneyKindCd6RF_Label";
            this.PayStMoneyKindCd6RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd6RF_Label.TabIndex = 509;
            this.PayStMoneyKindCd6RF_Label.Tag = "7";
            this.PayStMoneyKindCd6RF_Label.Text = "６";
            // 
            // PayStMoneyKindCd7RF_Label
            // 
            appearance85.TextHAlignAsString = "Center";
            appearance85.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd7RF_Label.Appearance = appearance85;
            this.PayStMoneyKindCd7RF_Label.Location = new System.Drawing.Point(36, 201);
            this.PayStMoneyKindCd7RF_Label.Name = "PayStMoneyKindCd7RF_Label";
            this.PayStMoneyKindCd7RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd7RF_Label.TabIndex = 510;
            this.PayStMoneyKindCd7RF_Label.Tag = "8";
            this.PayStMoneyKindCd7RF_Label.Text = "７";
            // 
            // PayStMoneyKindCd1RF_tNedit
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance86.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd1RF_tNedit.ActiveAppearance = appearance86;
            appearance87.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd1RF_tNedit.Appearance = appearance87;
            this.PayStMoneyKindCd1RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd1RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd1RF_tNedit.DataText = "";
            this.PayStMoneyKindCd1RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd1RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd1RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd1RF_tNedit.Location = new System.Drawing.Point(56, 51);
            this.PayStMoneyKindCd1RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd1RF_tNedit.Name = "PayStMoneyKindCd1RF_tNedit";
            this.PayStMoneyKindCd1RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd1RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd1RF_tNedit.TabIndex = 3;
            this.PayStMoneyKindCd1RF_tNedit.Tag = "1";
            this.PayStMoneyKindCd1RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd1RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd1RF_tNedit_Leave);
            this.PayStMoneyKindCd1RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd2RF_tNedit
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance88.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd2RF_tNedit.ActiveAppearance = appearance88;
            appearance89.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd2RF_tNedit.Appearance = appearance89;
            this.PayStMoneyKindCd2RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd2RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd2RF_tNedit.DataText = "";
            this.PayStMoneyKindCd2RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd2RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd2RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd2RF_tNedit.Location = new System.Drawing.Point(56, 76);
            this.PayStMoneyKindCd2RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd2RF_tNedit.Name = "PayStMoneyKindCd2RF_tNedit";
            this.PayStMoneyKindCd2RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd2RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd2RF_tNedit.TabIndex = 5;
            this.PayStMoneyKindCd2RF_tNedit.Tag = "2";
            this.PayStMoneyKindCd2RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd2RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd2RF_tNedit_Leave);
            this.PayStMoneyKindCd2RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd3RF_tNedit
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance90.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd3RF_tNedit.ActiveAppearance = appearance90;
            appearance91.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd3RF_tNedit.Appearance = appearance91;
            this.PayStMoneyKindCd3RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd3RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd3RF_tNedit.DataText = "";
            this.PayStMoneyKindCd3RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd3RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd3RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd3RF_tNedit.Location = new System.Drawing.Point(56, 101);
            this.PayStMoneyKindCd3RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd3RF_tNedit.Name = "PayStMoneyKindCd3RF_tNedit";
            this.PayStMoneyKindCd3RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd3RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd3RF_tNedit.TabIndex = 7;
            this.PayStMoneyKindCd3RF_tNedit.Tag = "3";
            this.PayStMoneyKindCd3RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd3RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd3RF_tNedit_Leave);
            this.PayStMoneyKindCd3RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd4RF_tNedit
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance92.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd4RF_tNedit.ActiveAppearance = appearance92;
            appearance93.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd4RF_tNedit.Appearance = appearance93;
            this.PayStMoneyKindCd4RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd4RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd4RF_tNedit.DataText = "";
            this.PayStMoneyKindCd4RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd4RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd4RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd4RF_tNedit.Location = new System.Drawing.Point(56, 126);
            this.PayStMoneyKindCd4RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd4RF_tNedit.Name = "PayStMoneyKindCd4RF_tNedit";
            this.PayStMoneyKindCd4RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd4RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd4RF_tNedit.TabIndex = 9;
            this.PayStMoneyKindCd4RF_tNedit.Tag = "4";
            this.PayStMoneyKindCd4RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd4RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd4RF_tNedit_Leave);
            this.PayStMoneyKindCd4RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd5RF_tNedit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd5RF_tNedit.ActiveAppearance = appearance94;
            appearance95.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd5RF_tNedit.Appearance = appearance95;
            this.PayStMoneyKindCd5RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd5RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd5RF_tNedit.DataText = "";
            this.PayStMoneyKindCd5RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd5RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd5RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd5RF_tNedit.Location = new System.Drawing.Point(56, 151);
            this.PayStMoneyKindCd5RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd5RF_tNedit.Name = "PayStMoneyKindCd5RF_tNedit";
            this.PayStMoneyKindCd5RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd5RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd5RF_tNedit.TabIndex = 11;
            this.PayStMoneyKindCd5RF_tNedit.Tag = "5";
            this.PayStMoneyKindCd5RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd5RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd5RF_tNedit_Leave);
            this.PayStMoneyKindCd5RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd6RF_tNedit
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd6RF_tNedit.ActiveAppearance = appearance96;
            appearance97.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd6RF_tNedit.Appearance = appearance97;
            this.PayStMoneyKindCd6RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd6RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd6RF_tNedit.DataText = "";
            this.PayStMoneyKindCd6RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd6RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd6RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd6RF_tNedit.Location = new System.Drawing.Point(56, 176);
            this.PayStMoneyKindCd6RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd6RF_tNedit.Name = "PayStMoneyKindCd6RF_tNedit";
            this.PayStMoneyKindCd6RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd6RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd6RF_tNedit.TabIndex = 13;
            this.PayStMoneyKindCd6RF_tNedit.Tag = "6";
            this.PayStMoneyKindCd6RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd6RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd6RF_tNedit_Leave);
            this.PayStMoneyKindCd6RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd7RF_tNedit
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance98.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd7RF_tNedit.ActiveAppearance = appearance98;
            appearance99.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd7RF_tNedit.Appearance = appearance99;
            this.PayStMoneyKindCd7RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd7RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd7RF_tNedit.DataText = "";
            this.PayStMoneyKindCd7RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd7RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd7RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd7RF_tNedit.Location = new System.Drawing.Point(56, 201);
            this.PayStMoneyKindCd7RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd7RF_tNedit.Name = "PayStMoneyKindCd7RF_tNedit";
            this.PayStMoneyKindCd7RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd7RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd7RF_tNedit.TabIndex = 15;
            this.PayStMoneyKindCd7RF_tNedit.Tag = "7";
            this.PayStMoneyKindCd7RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd7RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd7RF_tNedit_Leave);
            this.PayStMoneyKindCd7RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd8RF_tNedit
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance100.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd8RF_tNedit.ActiveAppearance = appearance100;
            appearance101.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd8RF_tNedit.Appearance = appearance101;
            this.PayStMoneyKindCd8RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd8RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd8RF_tNedit.DataText = "";
            this.PayStMoneyKindCd8RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd8RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd8RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd8RF_tNedit.Location = new System.Drawing.Point(56, 226);
            this.PayStMoneyKindCd8RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd8RF_tNedit.Name = "PayStMoneyKindCd8RF_tNedit";
            this.PayStMoneyKindCd8RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd8RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd8RF_tNedit.TabIndex = 17;
            this.PayStMoneyKindCd8RF_tNedit.Tag = "8";
            this.PayStMoneyKindCd8RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd8RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd8RF_tNedit_Leave);
            this.PayStMoneyKindCd8RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd8RF_Label
            // 
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd8RF_Label.Appearance = appearance102;
            this.PayStMoneyKindCd8RF_Label.Location = new System.Drawing.Point(36, 226);
            this.PayStMoneyKindCd8RF_Label.Name = "PayStMoneyKindCd8RF_Label";
            this.PayStMoneyKindCd8RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd8RF_Label.TabIndex = 511;
            this.PayStMoneyKindCd8RF_Label.Tag = "9";
            this.PayStMoneyKindCd8RF_Label.Text = "８";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PayStMoneyKindCd1RF_tUltraBtn
            // 
            this.PayStMoneyKindCd1RF_tUltraBtn.Location = new System.Drawing.Point(94, 51);
            this.PayStMoneyKindCd1RF_tUltraBtn.Name = "PayStMoneyKindCd1RF_tUltraBtn";
            this.PayStMoneyKindCd1RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd1RF_tUltraBtn.TabIndex = 4;
            ultraToolTipInfo11.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd1RF_tUltraBtn, ultraToolTipInfo11);
            this.PayStMoneyKindCd1RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd1RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd2RF_tUltraBtn
            // 
            this.PayStMoneyKindCd2RF_tUltraBtn.Location = new System.Drawing.Point(94, 76);
            this.PayStMoneyKindCd2RF_tUltraBtn.Name = "PayStMoneyKindCd2RF_tUltraBtn";
            this.PayStMoneyKindCd2RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd2RF_tUltraBtn.TabIndex = 6;
            ultraToolTipInfo4.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd2RF_tUltraBtn, ultraToolTipInfo4);
            this.PayStMoneyKindCd2RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd2RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd3RF_tUltraBtn
            // 
            this.PayStMoneyKindCd3RF_tUltraBtn.Location = new System.Drawing.Point(94, 101);
            this.PayStMoneyKindCd3RF_tUltraBtn.Name = "PayStMoneyKindCd3RF_tUltraBtn";
            this.PayStMoneyKindCd3RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd3RF_tUltraBtn.TabIndex = 8;
            ultraToolTipInfo5.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd3RF_tUltraBtn, ultraToolTipInfo5);
            this.PayStMoneyKindCd3RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd3RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd4RF_tUltraBtn
            // 
            this.PayStMoneyKindCd4RF_tUltraBtn.Location = new System.Drawing.Point(94, 126);
            this.PayStMoneyKindCd4RF_tUltraBtn.Name = "PayStMoneyKindCd4RF_tUltraBtn";
            this.PayStMoneyKindCd4RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd4RF_tUltraBtn.TabIndex = 10;
            ultraToolTipInfo6.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd4RF_tUltraBtn, ultraToolTipInfo6);
            this.PayStMoneyKindCd4RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd4RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd5RF_tUltraBtn
            // 
            this.PayStMoneyKindCd5RF_tUltraBtn.Location = new System.Drawing.Point(94, 151);
            this.PayStMoneyKindCd5RF_tUltraBtn.Name = "PayStMoneyKindCd5RF_tUltraBtn";
            this.PayStMoneyKindCd5RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd5RF_tUltraBtn.TabIndex = 12;
            ultraToolTipInfo7.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd5RF_tUltraBtn, ultraToolTipInfo7);
            this.PayStMoneyKindCd5RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd5RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd6RF_tUltraBtn
            // 
            this.PayStMoneyKindCd6RF_tUltraBtn.Location = new System.Drawing.Point(94, 176);
            this.PayStMoneyKindCd6RF_tUltraBtn.Name = "PayStMoneyKindCd6RF_tUltraBtn";
            this.PayStMoneyKindCd6RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd6RF_tUltraBtn.TabIndex = 14;
            ultraToolTipInfo8.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd6RF_tUltraBtn, ultraToolTipInfo8);
            this.PayStMoneyKindCd6RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd6RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd7RF_tUltraBtn
            // 
            this.PayStMoneyKindCd7RF_tUltraBtn.Location = new System.Drawing.Point(94, 201);
            this.PayStMoneyKindCd7RF_tUltraBtn.Name = "PayStMoneyKindCd7RF_tUltraBtn";
            this.PayStMoneyKindCd7RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd7RF_tUltraBtn.TabIndex = 16;
            ultraToolTipInfo9.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd7RF_tUltraBtn, ultraToolTipInfo9);
            this.PayStMoneyKindCd7RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd7RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd8RF_tUltraBtn
            // 
            this.PayStMoneyKindCd8RF_tUltraBtn.Location = new System.Drawing.Point(94, 226);
            this.PayStMoneyKindCd8RF_tUltraBtn.Name = "PayStMoneyKindCd8RF_tUltraBtn";
            this.PayStMoneyKindCd8RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd8RF_tUltraBtn.TabIndex = 18;
            ultraToolTipInfo10.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd8RF_tUltraBtn, ultraToolTipInfo10);
            this.PayStMoneyKindCd8RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd8RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
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
            // InitSelMoneyKindCdRF_tNedit
            // 
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance115.TextHAlignAsString = "Right";
            this.InitSelMoneyKindCdRF_tNedit.ActiveAppearance = appearance115;
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance116.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance116.ForeColor = System.Drawing.Color.Black;
            appearance116.ForeColorDisabled = System.Drawing.Color.Black;
            appearance116.TextHAlignAsString = "Right";
            appearance116.TextVAlignAsString = "Middle";
            this.InitSelMoneyKindCdRF_tNedit.Appearance = appearance116;
            this.InitSelMoneyKindCdRF_tNedit.AutoSelect = true;
            this.InitSelMoneyKindCdRF_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.InitSelMoneyKindCdRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.InitSelMoneyKindCdRF_tNedit.DataText = "";
            this.InitSelMoneyKindCdRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCdRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.InitSelMoneyKindCdRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InitSelMoneyKindCdRF_tNedit.Location = new System.Drawing.Point(56, 301);
            this.InitSelMoneyKindCdRF_tNedit.MaxLength = 3;
            this.InitSelMoneyKindCdRF_tNedit.Name = "InitSelMoneyKindCdRF_tNedit";
            this.InitSelMoneyKindCdRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.InitSelMoneyKindCdRF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.InitSelMoneyKindCdRF_tNedit.TabIndex = 1;
            this.InitSelMoneyKindCdRF_tNedit.Tag = "0";
            this.InitSelMoneyKindCdRF_tNedit.Visible = false;
            this.InitSelMoneyKindCdRF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.InitSelMoneyKindCdRF_tNedit.Leave += new System.EventHandler(this.tNedit_Leave);
            this.InitSelMoneyKindCdRF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // InitSelMoneyKindCdRF_Label
            // 
            appearance117.ForeColor = System.Drawing.Color.White;
            appearance117.TextHAlignAsString = "Center";
            appearance117.TextVAlignAsString = "Middle";
            this.InitSelMoneyKindCdRF_Label.Appearance = appearance117;
            this.InitSelMoneyKindCdRF_Label.BackColorInternal = System.Drawing.SystemColors.Highlight;
            this.InitSelMoneyKindCdRF_Label.Location = new System.Drawing.Point(56, 276);
            this.InitSelMoneyKindCdRF_Label.Name = "InitSelMoneyKindCdRF_Label";
            this.InitSelMoneyKindCdRF_Label.Size = new System.Drawing.Size(162, 24);
            this.InitSelMoneyKindCdRF_Label.TabIndex = 703;
            this.InitSelMoneyKindCdRF_Label.Tag = "";
            this.InitSelMoneyKindCdRF_Label.Text = "初期選択金種コード";
            this.InitSelMoneyKindCdRF_Label.Visible = false;
            // 
            // InitSelMoneyKindCdRF_tUltraBtn
            // 
            this.InitSelMoneyKindCdRF_tUltraBtn.Location = new System.Drawing.Point(94, 301);
            this.InitSelMoneyKindCdRF_tUltraBtn.Name = "InitSelMoneyKindCdRF_tUltraBtn";
            this.InitSelMoneyKindCdRF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.InitSelMoneyKindCdRF_tUltraBtn.TabIndex = 2;
            ultraToolTipInfo3.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.InitSelMoneyKindCdRF_tUltraBtn, ultraToolTipInfo3);
            this.InitSelMoneyKindCdRF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.InitSelMoneyKindCdRF_tUltraBtn.Visible = false;
            this.InitSelMoneyKindCdRF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // InitSelMoneyKindCdRF_tEdit
            // 
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InitSelMoneyKindCdRF_tEdit.ActiveAppearance = appearance113;
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            this.InitSelMoneyKindCdRF_tEdit.Appearance = appearance114;
            this.InitSelMoneyKindCdRF_tEdit.AutoSelect = true;
            this.InitSelMoneyKindCdRF_tEdit.DataText = "";
            this.InitSelMoneyKindCdRF_tEdit.Enabled = false;
            this.InitSelMoneyKindCdRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCdRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.InitSelMoneyKindCdRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.InitSelMoneyKindCdRF_tEdit.Location = new System.Drawing.Point(122, 301);
            this.InitSelMoneyKindCdRF_tEdit.MaxLength = 30;
            this.InitSelMoneyKindCdRF_tEdit.Name = "InitSelMoneyKindCdRF_tEdit";
            this.InitSelMoneyKindCdRF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.InitSelMoneyKindCdRF_tEdit.TabIndex = 3;
            this.InitSelMoneyKindCdRF_tEdit.TabStop = false;
            this.InitSelMoneyKindCdRF_tEdit.Tag = "111";
            this.InitSelMoneyKindCdRF_tEdit.Visible = false;
            // 
            // PayStMoneyKindCd10RF_Label
            // 
            appearance110.TextHAlignAsString = "Center";
            appearance110.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd10RF_Label.Appearance = appearance110;
            this.PayStMoneyKindCd10RF_Label.Location = new System.Drawing.Point(15, 289);
            this.PayStMoneyKindCd10RF_Label.Name = "PayStMoneyKindCd10RF_Label";
            this.PayStMoneyKindCd10RF_Label.Size = new System.Drawing.Size(41, 24);
            this.PayStMoneyKindCd10RF_Label.TabIndex = 709;
            this.PayStMoneyKindCd10RF_Label.Tag = "11";
            this.PayStMoneyKindCd10RF_Label.Text = "１０";
            this.PayStMoneyKindCd10RF_Label.Visible = false;
            // 
            // PayStMoneyKindCd10RF_tNedit
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd10RF_tNedit.ActiveAppearance = appearance111;
            appearance112.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd10RF_tNedit.Appearance = appearance112;
            this.PayStMoneyKindCd10RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd10RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd10RF_tNedit.DataText = "";
            this.PayStMoneyKindCd10RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd10RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd10RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd10RF_tNedit.Location = new System.Drawing.Point(56, 289);
            this.PayStMoneyKindCd10RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd10RF_tNedit.Name = "PayStMoneyKindCd10RF_tNedit";
            this.PayStMoneyKindCd10RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PayStMoneyKindCd10RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd10RF_tNedit.TabIndex = 21;
            this.PayStMoneyKindCd10RF_tNedit.Tag = "10";
            this.PayStMoneyKindCd10RF_tNedit.Visible = false;
            this.PayStMoneyKindCd10RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd10RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd10RF_tNedit_Leave);
            this.PayStMoneyKindCd10RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd10RF_tUltraBtn
            // 
            this.PayStMoneyKindCd10RF_tUltraBtn.Location = new System.Drawing.Point(94, 289);
            this.PayStMoneyKindCd10RF_tUltraBtn.Name = "PayStMoneyKindCd10RF_tUltraBtn";
            this.PayStMoneyKindCd10RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd10RF_tUltraBtn.TabIndex = 22;
            ultraToolTipInfo2.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd10RF_tUltraBtn, ultraToolTipInfo2);
            this.PayStMoneyKindCd10RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd10RF_tUltraBtn.Visible = false;
            this.PayStMoneyKindCd10RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd9RF_Label
            // 
            this.PayStMoneyKindCd9RF_Label.AllowDrop = true;
            appearance107.TextHAlignAsString = "Center";
            appearance107.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd9RF_Label.Appearance = appearance107;
            this.PayStMoneyKindCd9RF_Label.Location = new System.Drawing.Point(36, 264);
            this.PayStMoneyKindCd9RF_Label.Name = "PayStMoneyKindCd9RF_Label";
            this.PayStMoneyKindCd9RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd9RF_Label.TabIndex = 713;
            this.PayStMoneyKindCd9RF_Label.Tag = "10";
            this.PayStMoneyKindCd9RF_Label.Text = "９";
            this.PayStMoneyKindCd9RF_Label.Visible = false;
            // 
            // PayStMoneyKindCd9RF_tNedit
            // 
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance108.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd9RF_tNedit.ActiveAppearance = appearance108;
            appearance109.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd9RF_tNedit.Appearance = appearance109;
            this.PayStMoneyKindCd9RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd9RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd9RF_tNedit.DataText = "";
            this.PayStMoneyKindCd9RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd9RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd9RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd9RF_tNedit.Location = new System.Drawing.Point(56, 264);
            this.PayStMoneyKindCd9RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd9RF_tNedit.Name = "PayStMoneyKindCd9RF_tNedit";
            this.PayStMoneyKindCd9RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PayStMoneyKindCd9RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd9RF_tNedit.TabIndex = 19;
            this.PayStMoneyKindCd9RF_tNedit.Tag = "9";
            this.PayStMoneyKindCd9RF_tNedit.Visible = false;
            this.PayStMoneyKindCd9RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd9RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd9RF_tNedit_Leave);
            this.PayStMoneyKindCd9RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd9RF_tUltraBtn
            // 
            this.PayStMoneyKindCd9RF_tUltraBtn.Location = new System.Drawing.Point(94, 264);
            this.PayStMoneyKindCd9RF_tUltraBtn.Name = "PayStMoneyKindCd9RF_tUltraBtn";
            this.PayStMoneyKindCd9RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd9RF_tUltraBtn.TabIndex = 20;
            ultraToolTipInfo1.ToolTipText = "金額種別ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd9RF_tUltraBtn, ultraToolTipInfo1);
            this.PayStMoneyKindCd9RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd9RF_tUltraBtn.Visible = false;
            this.PayStMoneyKindCd9RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd10RF_tEdit
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd10RF_tEdit.ActiveAppearance = appearance103;
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd10RF_tEdit.Appearance = appearance104;
            this.PayStMoneyKindCd10RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd10RF_tEdit.DataText = "";
            this.PayStMoneyKindCd10RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd10RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd10RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd10RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd10RF_tEdit.Location = new System.Drawing.Point(122, 289);
            this.PayStMoneyKindCd10RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd10RF_tEdit.Name = "PayStMoneyKindCd10RF_tEdit";
            this.PayStMoneyKindCd10RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd10RF_tEdit.TabIndex = 715;
            this.PayStMoneyKindCd10RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd10RF_tEdit.Tag = "118";
            this.PayStMoneyKindCd10RF_tEdit.Visible = false;
            // 
            // PayStMoneyKindCd9RF_tEdit
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd9RF_tEdit.ActiveAppearance = appearance105;
            appearance106.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd9RF_tEdit.Appearance = appearance106;
            this.PayStMoneyKindCd9RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd9RF_tEdit.DataText = "";
            this.PayStMoneyKindCd9RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd9RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd9RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd9RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd9RF_tEdit.Location = new System.Drawing.Point(122, 264);
            this.PayStMoneyKindCd9RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd9RF_tEdit.Name = "PayStMoneyKindCd9RF_tEdit";
            this.PayStMoneyKindCd9RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd9RF_tEdit.TabIndex = 714;
            this.PayStMoneyKindCd9RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd9RF_tEdit.Tag = "117";
            this.PayStMoneyKindCd9RF_tEdit.Visible = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(31, 279);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 19;
            this.Renewal_Button.Tag = "210";
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFSIR09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(422, 363);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd10RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tUltraBtn);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tUltraBtn);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tEdit);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tNedit);
            this.Controls.Add(this.InitSelMoneyKindCdRF_Label);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd8RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd6RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd5RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd4RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd3RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd2RF_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.PayStMoneyKindCd1RF_Label);
            this.Controls.Add(this.PayStMoneyKindCdRF_Label);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tUltraBtn);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFSIR09020UA";
            this.Text = "支払設定";
            this.Load += new System.EventHandler(this.SFSIR09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFSIR09020UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFSIR09020UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// 画面が非表示状態になった際に発生します。
		/// </summary>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members
		private PaymentSet paymentSet;
		private PaymentSet _paymentSetClone;	// 比較用Clone
		private PaymentSetAcs paymentSetAcs;
		private string enterpriseCode;
		private int payStMngNo = 0;				// 支払設定管理No：0固定
////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
		// 変更フラグ
		private bool _changeFlg = false;
// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
		// 全コントロール格納用
		private Hashtable _controlTable = null;
		// 金種データ格納用
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

		// プロパティ用
		private bool _canPrint;
		private bool _canClose;

		// 画面制御用
		private ArrayList tneditCompList;
		private ArrayList teditCompList;

		private const string HTML_HEADER_TITLE = "設定項目";
		private const string HTML_HEADER_VALUE = "設定値";
		private const string HTML_UNREGISTER = "未設定";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

        // 編集前のコード保存用
        private string _cachedValue = string.Empty;
        private bool _continueFlag = true;


        // 編集前のコード
        private string _cache1 = string.Empty;
        private string _cache2 = string.Empty;
        private string _cache3 = string.Empty;
        private string _cache4 = string.Empty;
        private string _cache5 = string.Empty;
        private string _cache6 = string.Empty;
        private string _cache7 = string.Empty;
        private string _cache8 = string.Empty;
        private string _cache9 = string.Empty;
        private string _cache10 = string.Empty;

		#endregion
		
		# region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFSIR09020UA());
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
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : （未実装）</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		/// HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note       : ビュー用のＨＴＭＬコードを取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public string GetHtmlCode() 
		{
			string outCode = "";

			// tHtmlGenerate部品の引数を生成する
// 2006.06.09  EMI Del			string [,] array = new string[10, 2];
            //string[,] array = new string[11, 2];      // 2006.06.09  EMI Add
            string[,] array = new string[9, 2];      // 2006.06.09  EMI Add

			this.tHtmlGenerate1.Coltypes = new int[2]; 

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

			// テーブルタイトル
			array[0, 0] = HTML_HEADER_TITLE;
			array[0, 1] = HTML_HEADER_VALUE;

            //if (this.Controls.Count != 0)
            //{
            //    for (int i=0; i < this.Controls.Count; i++)
            //    {
					// 設定項目タイトル
                    //if (this.Controls[i] is UltraLabel)
                    //{
                    //    UltraLabel tLabel = (UltraLabel)this.Controls[i];
                    //    if (tLabel.Tag.ToString().Trim().Length > 0)
                    //    {
                            //int labelTag = Convert.ToInt16(tLabel.Tag);
                            //if (labelTag == 0)
                            //{
                            //    //2006.06.09  EMI Del		array[1, 0] = "初期表示システム";
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
                            //    array[1, 0] = "初期選択金種コード";         //2006.06.09  EMI Add
                            //    //array[2, 0] = "初期選択金種コード";         //2006.06.09  EMI Add
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
                            //}
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                            ////2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            ////else if (labelTag == 0)
                            ////{
                            ////array[1, 0] = "支払伝票呼出月数";
                            ////}
                            ////2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                            //else if (labelTag != 0)
                            //{
                            //    //2006.06.09　EMI Del							array[labelTag, 0] = "支払設定金種コード " + tLabel.Text;
                            //    //array[labelTag + 1, 0] = "支払設定金種コード " + tLabel.Text;
                            //    array[labelTag, 0] = "支払設定金種コード " + tLabel.Text;
                            //}

                    //    }
                    //}
            //    }
            //}

            // 動的生成しても無駄なので固定作成
            //array[1, 0] = "初期選択金種コード";
            array[1, 0] = "支払設定金種コード１";
            array[2, 0] = "支払設定金種コード２";
            array[3, 0] = "支払設定金種コード３";
            array[4, 0] = "支払設定金種コード４";
            array[5, 0] = "支払設定金種コード５";
            array[6, 0] = "支払設定金種コード６";
            array[7, 0] = "支払設定金種コード７";
            array[8, 0] = "支払設定金種コード８";
            //array[9, 0] = "支払設定金種コード９";
            //array[10, 0] = "支払設定金種コード１０";

			// 支払設定テーブル読込
			int status = this.paymentSetAcs.Read(out this.paymentSet, this.enterpriseCode, this.payStMngNo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //    // 取得した内容をセット
            //    // 初期表示システム
            //    array[1, 1] = this.paymentSet.PayInitSystemNm;
  			
            //    // 支払設定金種コード
            //    if (this.paymentSet.PayStMoneyKindCd1 != 0)
            //    {
            //        array[2, 1] = this.paymentSet.PayStMoneyKindNm1;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd2 != 0)
            //    {
            //        array[3, 1] = this.paymentSet.PayStMoneyKindNm2;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd3 != 0)
            //    {
            //        array[4, 1] = this.paymentSet.PayStMoneyKindNm3;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd4 != 0)
            //    {
            //        array[5, 1] = this.paymentSet.PayStMoneyKindNm4;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd5 != 0)
            //    {
            //        array[6, 1] = this.paymentSet.PayStMoneyKindNm5;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd6 != 0)
            //    {
            //        array[7, 1] = this.paymentSet.PayStMoneyKindNm6;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd7 != 0)
            //    {
            //        array[8, 1] = this.paymentSet.PayStMoneyKindNm7;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd8 != 0)
            //    {
            //        array[9, 1] = this.paymentSet.PayStMoneyKindNm8;
            //    }
            //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				// 取得した内容をセット

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // 支払伝票呼出月数
                //array[1, 1] = this.paymentSet.PaySlipCallMonths.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START

                //// 初期選択金種コード
                //if (this.paymentSet.InitSelMoneyKindCd != 0)
                //{
                //    array[1, 1] = this.paymentSet.InitSelMoneyKindNm;
                //}
    			

				// 支払設定金種コード
				if (this.paymentSet.PayStMoneyKindCd1 != 0)
				{
					array[1, 1] = this.paymentSet.PayStMoneyKindNm1;
				}
				if (this.paymentSet.PayStMoneyKindCd2 != 0)
				{
					array[2, 1] = this.paymentSet.PayStMoneyKindNm2;
				}
				if (this.paymentSet.PayStMoneyKindCd3 != 0)
				{
					array[3, 1] = this.paymentSet.PayStMoneyKindNm3;
				}
				if (this.paymentSet.PayStMoneyKindCd4 != 0)
				{
					array[4, 1] = this.paymentSet.PayStMoneyKindNm4;
				}
				if (this.paymentSet.PayStMoneyKindCd5 != 0)
				{
					array[5, 1] = this.paymentSet.PayStMoneyKindNm5;
				}
				if (this.paymentSet.PayStMoneyKindCd6 != 0)
				{
					array[6, 1] = this.paymentSet.PayStMoneyKindNm6;
				}
				if (this.paymentSet.PayStMoneyKindCd7 != 0)
				{
					array[7, 1] = this.paymentSet.PayStMoneyKindNm7;
				}
				if (this.paymentSet.PayStMoneyKindCd8 != 0)
				{
					array[8, 1] = this.paymentSet.PayStMoneyKindNm8;
				}
                //if (this.paymentSet.PayStMoneyKindCd9 != 0)
                //{
                //    array[9, 1] = this.paymentSet.PayStMoneyKindNm9;
                //}
                //if (this.paymentSet.PayStMoneyKindCd10 != 0)
                //{
                //    array[10, 1] = this.paymentSet.PayStMoneyKindNm10;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END

			}
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 「未設定」をセット
			for (int ix = 1; ix <  array.GetLength(0); ix++)
			{
				for (int iy = 1; iy <  array.GetLength(1); iy++)
				{
					if (array[ix, iy] == null)
					{
						//array[ix, iy] = HTML_UNREGISTER;        //2006.06.09  EMI Del
                        array[ix, iy] = "";                       //2006.06.09  EMI Add     「未設定」を空白に変更
                    }
				}
			}

			// データの２次元配列のみを指定して、プロパティを使用してグリッド表示する
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;
		}
		# endregion
        
		# region private Methods
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
        private void ScreenInitialSetting()
        {
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 初期表示システムコンボボックス
            //PayInitSystemDivRF_tComboEditor.Items.Clear();
            //PayInitSystemDivRF_tComboEditor.Items.Add(1, "整備");
            //PayInitSystemDivRF_tComboEditor.Items.Add(2, "鈑金");
            //PayInitSystemDivRF_tComboEditor.Items.Add(3, "車販");
            //PayInitSystemDivRF_tComboEditor.MaxDropDownItems = PayInitSystemDivRF_tComboEditor.Items.Count;
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


           // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //PaySlipCallMonthsRF_tNedit.Text = "" ;     //2006.06.09  EMI Add
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        }

		/// <summary>
		/// 支払設定クラスデータ格納処理（画面情報⇒支払設定クラス）
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面情報から支払設定クラスにデータを格納します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenToPaymentSet()
		{
/*
			if (this.paymentSet == null)
			{
				// 新規の場合
				this.paymentSet = new PaymentSet();

				// 企業コード
				this.paymentSet.EnterpriseCode = this.enterpriseCode;
				// 支払設定管理No 0固定
				this.paymentSet.PayStMngNo = this.payStMngNo;
				// 支払初期表示画面番号 1:一括
				this.paymentSet.PayInitDspScrNumber = 1;
				// 支払表示順設定 0:日付順
				this.paymentSet.DspOrderOfPaySt = 0;
				// 支払一括引当金種コード
				this.paymentSet.LumpSumMoneyKindCd = 1;
			}
*/
			// 初期表示システム
            //2006.06.09  EMI Del			this.paymentSet.PayInitSystemDiv = Convert.ToInt32(PayInitSystemDivRF_tComboEditor.SelectedItem.DataValue);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 支払伝票呼出月数
            //this.paymentSet.PaySlipCallMonths = PaySlipCallMonthsRF_tNedit.GetInt();
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

			// 支払設定金種コード
			this.paymentSet.PayStMoneyKindCd1 = PayStMoneyKindCd1RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd2 = PayStMoneyKindCd2RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd3 = PayStMoneyKindCd3RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd4 = PayStMoneyKindCd4RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd5 = PayStMoneyKindCd5RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd6 = PayStMoneyKindCd6RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd7 = PayStMoneyKindCd7RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd8 = PayStMoneyKindCd8RF_tNedit.GetInt();
            //2006.06.09  EMI Del			this.paymentSet.PayStMoneyKindCd9 = 0;			// 無条件で0を入れる
            this.paymentSet.PayStMoneyKindCd9 = PayStMoneyKindCd9RF_tNedit.GetInt();		// 2006.06.09  EMI Add
            this.paymentSet.PayStMoneyKindCd10 = PayStMoneyKindCd10RF_tNedit.GetInt();		// 2006.06.09  EMI Add
            //this.paymentSet.InitSelMoneyKindCd = InitSelMoneyKindCdRF_tNedit.GetInt();		// 2006.06.09  EMI Add

			//支払設定金種名称
			this.paymentSet.PayStMoneyKindNm1 = PayStMoneyKindCd1RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm2 = PayStMoneyKindCd2RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm3 = PayStMoneyKindCd3RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm4 = PayStMoneyKindCd4RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm5 = PayStMoneyKindCd5RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm6 = PayStMoneyKindCd6RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm7 = PayStMoneyKindCd7RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm8 = PayStMoneyKindCd8RF_tEdit.Text.Trim();
            //2006.06.09  EMI Del			this.paymentSet.PayStMoneyKindNm9 = null;		// 無条件でnullを入れる
            this.paymentSet.PayStMoneyKindNm9 = PayStMoneyKindCd9RF_tEdit.Text.Trim();		// 2006.06.09  EMI Add
            this.paymentSet.PayStMoneyKindNm10 = PayStMoneyKindCd10RF_tEdit.Text.Trim();		// 2006.06.09  EMI Add
            //this.paymentSet.InitSelMoneyKindNm = InitSelMoneyKindCdRF_tEdit.Text.Trim();		// 2006.06.09  EMI Add

		}

		/// <summary>
		///	支払設定クラスデータ展開処理（支払設定クラス⇒画面情報）
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void PaymentSetToScreen()
		{
			// 初期表示システム
            //2006.06.09  EMI Del		PayInitSystemDivRF_tComboEditor.SelectedIndex = this.paymentSet.PayInitSystemDiv -1;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 支払伝票呼出月数
            //PaySlipCallMonthsRF_tNedit.SetInt(this.paymentSet.PaySlipCallMonths);
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

			// 支払設定金種コード
			if (this.paymentSet.PayStMoneyKindCd1 != 0)
			{
				PayStMoneyKindCd1RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd1);
				PayStMoneyKindCd1RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm1;
			}
			else
			{
				PayStMoneyKindCd1RF_tNedit.Clear();
				PayStMoneyKindCd1RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd2 != 0)
			{
				PayStMoneyKindCd2RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd2);
				PayStMoneyKindCd2RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm2;
			}
			else
			{
				PayStMoneyKindCd2RF_tNedit.Clear();
				PayStMoneyKindCd2RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd3 != 0)
			{
				PayStMoneyKindCd3RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd3);
				PayStMoneyKindCd3RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm3;
			}
			else
			{
				PayStMoneyKindCd3RF_tNedit.Clear();
				PayStMoneyKindCd3RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd4 != 0)
			{
				PayStMoneyKindCd4RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd4);
				PayStMoneyKindCd4RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm4;
			}
			else
			{
				PayStMoneyKindCd4RF_tNedit.Clear();
				PayStMoneyKindCd4RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd5 != 0)
			{
				PayStMoneyKindCd5RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd5);
				PayStMoneyKindCd5RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm5;
			}
			else
			{
				PayStMoneyKindCd5RF_tNedit.Clear();
				PayStMoneyKindCd5RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd6 != 0)
			{
				PayStMoneyKindCd6RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd6);
				PayStMoneyKindCd6RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm6;
			}
			else
			{
				PayStMoneyKindCd6RF_tNedit.Clear();
				PayStMoneyKindCd6RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd7 != 0)
			{
				PayStMoneyKindCd7RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd7);
				PayStMoneyKindCd7RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm7;
			}
			else
			{
				PayStMoneyKindCd7RF_tNedit.Clear();
				PayStMoneyKindCd7RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd8 != 0)
			{
				PayStMoneyKindCd8RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd8);
				PayStMoneyKindCd8RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm8;
			}
			else
			{
				PayStMoneyKindCd8RF_tNedit.Clear();
				PayStMoneyKindCd8RF_tEdit.Clear();
			} 
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.paymentSet.PayStMoneyKindCd9 != 0)
            { 
                PayStMoneyKindCd9RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd9);
                PayStMoneyKindCd9RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm9;
            }
            else
            {
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear(); 
            }
            if (this.paymentSet.PayStMoneyKindCd10 != 0)
            {
                PayStMoneyKindCd10RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd10);
                PayStMoneyKindCd10RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm10;
            }
            else
            {
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            //if (this.paymentSet.InitSelMoneyKindCd != 0)
            //{
            //    InitSelMoneyKindCdRF_tNedit.SetInt(this.paymentSet.InitSelMoneyKindCd);
            //    InitSelMoneyKindCdRF_tEdit.Text = this.paymentSet.InitSelMoneyKindNm;
            //}
            //else
            //{
            //    InitSelMoneyKindCdRF_tNedit.Clear();
            //    InitSelMoneyKindCdRF_tEdit.Clear();
            //}
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenClear()
		{
			// 初期表示システム
            //2006.06.09  EMI Del			PayInitSystemDivRF_tComboEditor.SelectedIndex = 0;

//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            // 支払伝票呼出月数
            //PaySlipCallMonthsRF_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            
            //// 初期選択金種コード
            //InitSelMoneyKindCdRF_tNedit.Clear();　　　
            //InitSelMoneyKindCdRF_tEdit.Clear();　　　 
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 支払設定金種コード
			PayStMoneyKindCd1RF_tNedit.Clear(); 
			PayStMoneyKindCd2RF_tNedit.Clear();
			PayStMoneyKindCd3RF_tNedit.Clear();
			PayStMoneyKindCd4RF_tNedit.Clear();
			PayStMoneyKindCd5RF_tNedit.Clear();
			PayStMoneyKindCd6RF_tNedit.Clear();
			PayStMoneyKindCd7RF_tNedit.Clear();
			PayStMoneyKindCd8RF_tNedit.Clear();
			PayStMoneyKindCd9RF_tNedit.Clear();　　　 　//2006.06.09  EMI Add
            PayStMoneyKindCd10RF_tNedit.Clear();　　　　//2006.06.09  EMI Add

			// 支払設定金種名称
			PayStMoneyKindCd1RF_tEdit.Clear();
			PayStMoneyKindCd2RF_tEdit.Clear();
			PayStMoneyKindCd3RF_tEdit.Clear();
			PayStMoneyKindCd4RF_tEdit.Clear();
			PayStMoneyKindCd5RF_tEdit.Clear();
			PayStMoneyKindCd6RF_tEdit.Clear();
			PayStMoneyKindCd7RF_tEdit.Clear();
			PayStMoneyKindCd8RF_tEdit.Clear();
            PayStMoneyKindCd9RF_tEdit.Clear();          //2006.06.09  EMI Add
            PayStMoneyKindCd10RF_tEdit.Clear();         //2006.06.09  EMI Add

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.13 TAKAHASHI ADD START
			// 変更フラグ
			this._changeFlg = false;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.01.13 TAKAHASHI ADD END
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			int status = paymentSetAcs.Read(out this.paymentSet, this.enterpriseCode, this.payStMngNo);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;

				// 支払設定クラス画面展開処理
				PaymentSetToScreen();

                // 画面上の設定
                EnableMonKindCodeFields(true, 0, true);
			}
			else
			{
				Mode_Label.Text = INSERT_MODE;

				// データクラス新規作成
				this.paymentSet = new PaymentSet();
				// 企業コード
				this.paymentSet.EnterpriseCode = this.enterpriseCode;
				// 支払設定管理No 0固定
				this.paymentSet.PayStMngNo = this.payStMngNo;
				// 支払初期表示画面番号 1:一括
                //2006.06.09  EMI Del			this.paymentSet.PayInitDspScrNumber = 1;
				// 支払表示順設定 0:日付順
                //2006.06.09  EMI Del			this.paymentSet.DspOrderOfPaySt = 0;
				// 支払一括引当金種コード
                //2006.06.09  EMI Del			this.paymentSet.LumpSumMoneyKindCd = 1;
			}

			// 支払設定クラスデータ格納
			ScreenToPaymentSet();
			// 情報変更比較用クローン作成
			this._paymentSetClone = this.paymentSet.Clone();
		}

		/// <summary>
		/// 支払設定画面入力チェック処理
		/// </summary>
		/// <param name="checkMessage">エラーメッセージ</param>
		/// <returns>エラーコード</returns>
		/// <remarks>
		/// <br>Note       : 支払設定画面の入力チェックをします。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private int checkDisplay(ref string checkMessage)
		{
			int returnStatus = 0;
			int compIndex = 0;
			try
			{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// 初期表示システム
                //// コンボボックスは必ず設定する
                //if (this.PayInitSystemDivRF_tComboEditor.SelectedIndex < 0)
                //{
                //    checkMessage = "初期表示システムが未選択です。";
                //    returnStatus = 10;
                //    return returnStatus;
                //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 未登録がないか(変換時に未登録チェックをしているので基本的にはない)
                checkMessage = "未登録のコードは登録できません。";
                //returnStatus = 11;
                if (this.PayStMoneyKindCd1RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd2RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd3RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd4RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd5RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd6RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd7RF_Label.Text == "未登録")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd8RF_Label.Text == "未登録")
                {
                    return 11;
                }
                // 2008.11.18 add start [7900]
                checkMessage = "金種コードに0は登録できません。";
                //returnStatus = 11;
                if (this.PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                // 2008.11.18 add end [7900]
                //if (this.PayStMoneyKindCd9RF_Label.Text == "未登録")
                //{
                //    return 11;
                //}
                //if (this.PayStMoneyKindCd10RF_Label.Text == "未登録")
                //{
                //    return 11;
                //}
                checkMessage = string.Empty;

                // 一つもない
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd1RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd2RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd3RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd4RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd5RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd6RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd7RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd8RF_tNedit.Text.Trim())// &&
                    //String.IsNullOrEmpty(this.PayStMoneyKindCd9RF_tNedit.Text.Trim()) &&
                    //String.IsNullOrEmpty(this.PayStMoneyKindCd10RF_tNedit.Text.Trim())
                    )
                {
                    checkMessage = "コードが登録されていません。";
                    return 1;
                }

//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // 支払伝票呼出月数
                // 必ず設定する
                //if (this.PaySlipCallMonthsRF_tNedit.GetInt() == 0 )
                //{
                    //checkMessage = "支払伝票呼出月数が設定されていません。";
                    //returnStatus = 10;
                    //return returnStatus;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                
                // 初期選択金種コード
                // 必ず設定する
                //if (this.InitSelMoneyKindCdRF_tNedit.GetInt() == 0)
                //{
                //    checkMessage = "初期選択金種コードが設定されていません。";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 2007.04.03  S.Koga  add ------------------------------------
                //int IniSelMonKiCd = this.InitSelMoneyKindCdRF_tNedit.GetInt();
                bool _iniSelMonKiCdFlg = false; 

                //// 金種コード１
                //if ((this.PayStMoneyKindCd1RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd1RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード２
                //if ((this.PayStMoneyKindCd2RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd2RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード３
                //if ((this.PayStMoneyKindCd3RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd3RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード４
                //if ((this.PayStMoneyKindCd4RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd4RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード５
                //if ((this.PayStMoneyKindCd5RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd5RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード６
                //if ((this.PayStMoneyKindCd6RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd6RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード７
                //if ((this.PayStMoneyKindCd7RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd7RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード８
                //if ((this.PayStMoneyKindCd8RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd8RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード９
                //if ((this.PayStMoneyKindCd9RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd9RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// 金種コード１０
                //if ((this.PayStMoneyKindCd10RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd10RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}

                //if (_iniSelMonKiCdFlg == false)
                //{
                //    checkMessage = "支払設定金種コードの中から選択してください。";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // ------------------------------------------------------------

				// 支払設定金種コード
				// エラー入力チェック
				for (int i = 0; i < this.tneditCompList.Count; i++)
				{
					string wrkStr = "";
					int wrkInt = ((TNedit)tneditCompList[i]).GetInt();
					
					// 入力無し
					if (wrkInt == 0)
					{
						((TEdit)teditCompList[i]).Text = wrkStr;
						continue;
					}

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI DELETE START
//					// 金種コード存在チェック
//					// ↓ 要変更 /////////////////////////////////////////////////////////////////
//					switch (wrkInt)
//					{
//						case 1 :
//						{ 
//							wrkStr = "現金・小切手";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "振込";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "クレジット";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "手数料";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "手形";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "相殺";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "その他";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "値引";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "預り金";
//							break;
//						}
//						default :
//						{
//							wrkStr = null;
//							break;
//						}
//					}
//
//					if (wrkStr != null)
//					{
//						((TEdit)teditCompList[i]).Text = wrkStr;
//					}
//					else
//					{
//					////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
//					//						((TEdit)teditCompList[i]).Clear();
//					//						checkMessage = "対象データが存在しません";
//					// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//					////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//											((TEdit)teditCompList[i]).Text = "未登録";
//											checkMessage = "マスタに登録されていません。";
//					// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//											compIndex = i;
//											returnStatus = 100;
//											return returnStatus;
//										}
//					↑ 要変更 /////////////////////////////////////////////////////////////////

				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI DELETE END
				}

				// 重複チェック
				bool isCash = false;
				//2006.06.09  EMI Del 
                //for (int i = 0; i < this.tneditCompList.Count -1; i++)
                //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                for (int i = 0; i < this.tneditCompList.Count; i++)
                //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    int sourceCd = ((TNedit)tneditCompList[i]).GetInt();

					if (sourceCd == 0) continue;
					//if (sourceCd == 1) isCash = true;			// 1:現金･小切手が入力されているかの判断をする

					for (int j = i +1; j < this.tneditCompList.Count; j++)
					{
						int destCd = ((TNedit)tneditCompList[j]).GetInt();

						//if (destCd == 1) isCash = true;			// 1:現金･小切手が入力されているかの判断をする
						if (sourceCd == destCd)
						{
							checkMessage = "コードが重複しています";
							compIndex = j;
							returnStatus = 100;
							return returnStatus;
						}
					}
				}

                //// 1: 現金･小切手は必須項目
                //if (isCash == false)
                //{
                //    checkMessage = "「1: 現金･小切手」が設定されていません";
                //    compIndex = 0;
                //    returnStatus = 100;
                //    return returnStatus;
                //}

				return returnStatus;
			}
			finally
			{
				if (returnStatus != 0)
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
                    //TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    //    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    //    "SFSIR09020U",							// アセンブリID
                    //    checkMessage,	                        // 表示するメッセージ
                    //    0,   									// ステータス値
                    //    MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					//エラーステータスに合わせてフォーカスセット
					switch(returnStatus)
					{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>					
                        //case 10 :	//初期表示システム
                        //{
                        //    this.PayInitSystemDivRF_tComboEditor.Focus();
                        //    break;
                        //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>					
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                    //case 10:	//支払伝票呼出月数
                        //{
                            //this.PaySlipCallMonthsRF_tNedit.Focus();
                            //break;
                        //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                    //case 20:	//初期選択金種コード
                    //    {
                    //        //this.InitSelMoneyKindCdRF_tNedit.Focus();　
                    //        break;
                    //    }
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    case 100:	//支払設定金種コード
						{
							((TNedit)this.tneditCompList[compIndex]).Focus();
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// 支払設定保存処理
		/// </summary>
		/// <returns>エラーコード</returns>
		/// <remarks>
		/// <br>Note       : 支払設定情報の保存を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private int SavePaymentSet()
		{
			//画面データ入力チェック処理
			string checkMessage = "";
			int chkSt = checkDisplay(ref checkMessage);
			if (chkSt != 0)
			{
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                    "支払設定", "SavePaymentSet", TMsgDisp.OPE_UPDATE,
                    checkMessage, chkSt, this.paymentSetAcs, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 9;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
            //2006.06.09  EMI Del			for (int ix = 1 ; ix <= 8; ix++)
            //for (int ix = 1; ix <= 10; ix++)       //2006.06.09  EMI Add

            //{
            //    string name;

            //    TNedit payStMonKiCd = (TNedit)this._controlTable["PayStMoneyKindCd" + ix + "RF_tNedit"];;

            //    TEdit payStMonKiNm = (TEdit)this._controlTable["PayStMoneyKindCd" + ix + "RF_tEdit"];

            //    int statusP = PayStMonKiCdChange(out name, payStMonKiCd.GetInt());

            //    if (statusP == -1)
            //    {
            //        //payStMonKiNm.Text = name;
            //        payStMonKiCd.Text = this._cachedValue;
            //        this._cachedValue = string.Empty;
            //        payStMonKiCd.Focus();
            //        payStMonKiCd.SelectAll();
            //        return statusP;
            //    }
            //    else if (statusP !=  0)
            //    {
            //        payStMonKiNm.Text = name;
            //        payStMonKiCd.Focus();
            //        payStMonKiCd.SelectAll();
            //        return statusP;
            //    }
            //}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
            //2006.06.09  EMI Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //string initname;
            
            //TNedit initSelMonKiCd = (TNedit)this._controlTable["InitSelMoneyKindCdRF_tNedit"]; ;

            //TEdit initSelMonKiNm = (TEdit)this._controlTable["InitSelMoneyKindCdRF_tEdit"];

            //int statusI = PayStMonKiCdChange(out initname, initSelMonKiCd.GetInt());

            //if (statusI == -1)
            //{
            //    //payStMonKiNm.Text = name;
            //    initSelMonKiCd.Text = this._cachedValue;
            //    this._cachedValue = string.Empty;
            //    initSelMonKiCd.Focus();
            //    initSelMonKiCd.SelectAll();
            //    return statusI;
            //}
            //else if (statusI != 0)
            //{
            //    initSelMonKiNm.Text = initname;
            //    initSelMonKiCd.Focus();
            //    initSelMonKiCd.SelectAll();
            //    return statusI;
            //}
            //2006.06.09  EMI Add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 画面から支払設定クラスにデータをセットします。
			ScreenToPaymentSet();

			// 支払設定登録処理
			int status = this.paymentSetAcs.Write(ref this.paymentSet);
			// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> START
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{ 
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status);
					
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._paymentSetClone = null;
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
					return status;
				}
					// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFSIR09020U",							// アセンブリID
						"支払設定",                             // プログラム名称
						"SavePaymentSet",                       // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this.paymentSetAcs,					    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._paymentSetClone = null;
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END	
					return status;
				}
					// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> END
			}
			return 0;
		}
		

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.07.12</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFSIR09020U",							// アセンブリID
						"既に他端末より更新されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFSIR09020U",							// アセンブリID
						"既に他端末より削除されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全コントロール取得処理
		/// </summary>
		/// <param name="parent">基本コントロール</param>
		/// <returns>全下位下層コントロール</returns>
		/// <remarks>
		/// <br>Note		: 指定された基本コントロールより全下位下層コントロールを返します。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.09.24</br>
		/// </remarks>
		private Control[] GetAllControls(Control parent)
		{
			ArrayList buf = new ArrayList();

			foreach (Control control in parent.Controls)
			{
				buf.Add(control);
				buf.AddRange(GetAllControls(control));
			}

			return (Control[])buf.ToArray(typeof(Control));
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コンポーネントテーブル格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コンポーネントをテーブルにセットします。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.09.24</br>
		/// </remarks>
		private void SetControlTable()
		{
			this._controlTable = new Hashtable();

			foreach (Control control in this.GetAllControls(this))
			{
				if (!this._controlTable.Contains(control.Name))
				{
					this._controlTable.Add(control.Name, control);
				}
			}
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 金種名称変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 金種コードにあわせて表示されている金種名称の変更を行います。</br>
		/// <br>Programmer	: 23006　高橋 明子</br>
		/// <br>Date		: 2005.12.20</br>
		/// </remarks>
        private int PayStMonKiCdChange(int ix, TNedit payStMoneyKindCdRF_tNedit, TEdit payStMoneyKindCdNmRF_tEdit)//out string payStMonKiName, int payStMonKiCode)
		{
			int status = 0;

			//payStMonKiName = null;

			// 金種コードが空なら、Nullを返す
            if (payStMoneyKindCdRF_tNedit.GetInt() == 0)
			{
                payStMoneyKindCdNmRF_tEdit.Text = "";
			}
			else
			{
				MoneyKind moneyKindInfo = new MoneyKind();

				// PrimaryKey情報をセット
				moneyKindInfo.EnterpriseCode = this.enterpriseCode;
				moneyKindInfo.PriceStCode    = 0;
                moneyKindInfo.MoneyKindCode = payStMoneyKindCdRF_tNedit.GetInt(); //payStMonKiCode;

                //string exCode = payStMoneyKindCdRF_tNedit.Text.Trim();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.27 T-Kidate START
				// 金額種別マスタより情報を取得
				//status = this._moneyKindAcs.Read(ref moneyKindInfo);
                moneyKindInfo.MoneyKindName = this.paymentSetAcs.GetDepsitStKindNm(this.enterpriseCode, moneyKindInfo.MoneyKindCode);
                if (moneyKindInfo.MoneyKindName == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.27 T-Kidate END
                
                switch (status)
                {
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						if (moneyKindInfo.LogicalDeleteCode != 0)
						{
							TMsgDisp.Show(this,                         // 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
								"SFSIR09020U",							// アセンブリID
								"マスタから削除されています。",	        // 表示するメッセージ
								status,									// ステータス値
								MessageBoxButtons.OK);					// 表示するボタン

                            payStMoneyKindCdNmRF_tEdit.Text = "削除済";

							status = -2;
						}
						else
						{
                            // [2008/09/19]ここ以外は来ないので他は無駄
                            if (moneyKindInfo.MoneyKindName == "未登録")
                            {
                                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    "SFUKK09060U",							// アセンブリID
                                    "マスタに登録されていません。",	        // 表示するメッセージ
                                    status,									// ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン

                                //payStMoneyKindCdRF_tNedit.Clear();
                                //if (!String.IsNullOrEmpty(this._cachedValue.Trim()))
                                //{
                                //    payStMoneyKindCdRF_tNedit.Text = this._cachedValue;
                                //    //payStMoneyKindCdRF_tNedit.Text = exCode;
                                //    //this._cachedValue = string.Empty;
                                //}
                                //payStMoneyKindCdRF_tNedit.Focus();
                                //_continueFlag = false;
                                status = -2;
                            }
                            else
                            {
                                payStMoneyKindCdNmRF_tEdit.Text = moneyKindInfo.MoneyKindName;
                            }
							//payStMonKiName = moneyKindInfo.MoneyKindName;
						}

						break;
					}

					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						TMsgDisp.Show(this,                         // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							"SFSIR09020U",							// アセンブリID
							"マスタに登録されていません。",	        // 表示するメッセージ
							status,									// ステータス値
							MessageBoxButtons.OK);					// 表示するボタン

                        payStMoneyKindCdNmRF_tEdit.Text = "未登録";

						break;
					}

					default:
					{
                        payStMoneyKindCdNmRF_tEdit.Text = "";

						break;
					}
				}
			}

			return status;

//			payStMonKiName = "";
//
//			int status = 0;
//						
//			MoneyKind moneyKind = null;
//
//			// 金額種別登録修正マスタ読み込み(初回のみ)
//			// 論理削除分も取得
//			if 	(this._moneyKindBuf == null)
//			{
//				status = this._moneyKindAcs.SearchAll(out _moneyKindBuf, this.enterpriseCode);
//			}			
//			
//			
//			if (payStMonKiCode != 0) 
//			{									   
//				// 金額種別登録修正マスタBufferから取得
//				foreach(MoneyKind moneyKindWork in this._moneyKindBuf)
//				{
//					if (moneyKindWork.PriceStCode == 0)
//					{
//						if (moneyKindWork.MoneyKindCode == payStMonKiCode)
//						{
//							moneyKind = moneyKindWork.Clone();
//							break;
//						}
//					}
//				}
//				
//				// 該当コードが無かった場合StatusにNotFoundを設定
//				if (moneyKind == null)
//				{
//					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//				}			
//			
//				switch (status)
//				{
//					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						// 論理削除されていた場合
//						if (moneyKind.LogicalDeleteCode != 0)
//						{
//							// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//							TMsgDisp.Show(this,                         // 親ウィンドウフォーム
//								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
//								"SFSIR09020U",							// アセンブリID
//								"マスタから削除されています。",	        // 表示するメッセージ
//								status,									// ステータス値
//								MessageBoxButtons.OK);					// 表示するボタン
//							// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//						
//							payStMonKiName = "削除済";
//							status = -2;
//						
//						}
//						else
//						{
//							payStMonKiName = moneyKind.MoneyKindName.TrimEnd();
//						}
//						break;
//					}
//					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//					{
//						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//						TMsgDisp.Show(this,                         // 親ウィンドウフォーム
//							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
//							"SFSIR09020U",							// アセンブリID
//							"マスタに登録されていません。",	        // 表示するメッセージ
//							status,									// ステータス値
//							MessageBoxButtons.OK);					// 表示するボタン
//						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//				
//						payStMonKiName = "未登録";
//						break;
//					}
//					default:
//					{
//						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//						TMsgDisp.Show(this,                         // 親ウィンドウフォーム
//							emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
//							"SFSIR09020U",							// アセンブリID
//							"支払設定",                             // プログラム名称
//							"PayStMonKiCdChange",                   // 処理名称
//							TMsgDisp.OPE_GET,                       // オペレーション
//							"諸費用名称の読み込みに失敗しました。",	// 表示するメッセージ
//							status,									// ステータス値
//							this.paymentSetAcs,					    // エラーが発生したオブジェクト
//							MessageBoxButtons.OK,					// 表示するボタン
//							MessageBoxDefaultButton.Button1);		// 初期表示ボタン
//						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//
//						break;
//					}
//				}
//			}
//			return status;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.07 TAKAHASHI ADD START
		/// <summary>
		/// ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ガイドを起動し、選択内容を画面に適用します。</br>
		/// <br>Programmer	: 23006	 高橋 明子</br>
		/// <br>Date		: 2005.10.07</br>
		/// </remarks>
		private void StartGuidProc(string objectName)
		{
			MoneyKind moneyKind = new MoneyKind();

            // ----- iitani c ---------- start 2007.05.23
            //MoneyKindAcs moneyKindAcs = new MoneyKindAcs();
			// 金額種別ガイド
			//switch (moneyKindAcs.ExecuteGuid(this.enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML"))
			switch (this._moneyKindAcs.ExecuteGuid(this.enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML"))
            // ----- iitani c ---------- start 2007.05.23
            {
				case 0:
					// 金額種別情報変更処理
					if (objectName == "PayStMoneyKindCd1RF_tUltraBtn")
					{
                        this.PayStMoneyKindCd1RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd1RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache1 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 2, true);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
                        this.PayStMoneyKindCd2RF_tNedit.Focus();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd2RF_tUltraBtn")
					{
						this.PayStMoneyKindCd2RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd2RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache2 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 3, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd3RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd3RF_tUltraBtn")
					{
						this.PayStMoneyKindCd3RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd3RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache3 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 4, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd4RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd4RF_tUltraBtn")
					{
						this.PayStMoneyKindCd4RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd4RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache4 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 5, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd5RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd5RF_tUltraBtn")
					{
						this.PayStMoneyKindCd5RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd5RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache5 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 6, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd6RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd6RF_tUltraBtn")
					{
						this.PayStMoneyKindCd6RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd6RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache6 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 7, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd7RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd7RF_tUltraBtn")
					{
						this.PayStMoneyKindCd7RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd7RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache7 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 8, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd8RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd8RF_tUltraBtn")
					{
                        this.PayStMoneyKindCd8RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd8RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache8 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 9, true);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
                        //this.Ok_Button.Focus();
                        this.PayStMoneyKindCd9RF_tNedit.Focus();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

                    //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (objectName == "PayStMoneyKindCd9RF_tUltraBtn")
                    {
                        this.PayStMoneyKindCd9RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd9RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache9 = moneyKind.MoneyKindCode.ToString();
                        this.PayStMoneyKindCd9RF_tNedit.Focus();
                        EnableMonKindCodeFields(false, 10, true);
                        this.PayStMoneyKindCd10RF_tNedit.Focus();
                    }

                    if (objectName == "PayStMoneyKindCd10RF_tUltraBtn")
                    {
                        this.PayStMoneyKindCd10RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd10RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache10 = moneyKind.MoneyKindCode.ToString();
                        this.Ok_Button.Focus();
                    }

                    //if (objectName == "InitSelMoneyKindCdRF_tUltraBtn")
                    //{
                    //    this.InitSelMoneyKindCdRF_tNedit.SetInt(moneyKind.MoneyKindCode);
                    //    this.InitSelMoneyKindCdRF_tEdit.Text = moneyKind.MoneyKindName;
                    //    this.Ok_Button.Focus();
                    //}

                    //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					break;

				case 1:
					break;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.07 TAKAHASHI ADD END
		# endregion

		# region Control Events
		/// <summary>
		/// Form.Load イベント(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void SFSIR09020UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// 保存ボタン
			this.Ok_Button.ImageList = imageList24;
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<
			// 閉じるボタン
			this.Cancel_Button.ImageList = imageList24;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			// ガイドボタン
			this.PayStMoneyKindCd1RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd1RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd2RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd2RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd3RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd3RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd4RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd4RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd5RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd5RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd6RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd6RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd7RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd7RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd8RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd8RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.PayStMoneyKindCd9RF_tUltraBtn.ImageList = imageList16;
            this.PayStMoneyKindCd9RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            this.PayStMoneyKindCd10RF_tUltraBtn.ImageList = imageList16;
            this.PayStMoneyKindCd10RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            this.InitSelMoneyKindCdRF_tUltraBtn.ImageList = imageList16;
            this.InitSelMoneyKindCdRF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// コンポーネントテーブル格納処理
			this.SetControlTable();


            // 初期値取得
            //_cache1 = this.PayStMoneyKindCd1RF_tNedit.Text.Trim();
            //_cache2 = this.PayStMoneyKindCd2RF_tNedit.Text.Trim();
            //_cache3 = this.PayStMoneyKindCd3RF_tNedit.Text.Trim();
            //_cache4 = this.PayStMoneyKindCd4RF_tNedit.Text.Trim();
            //_cache5 = this.PayStMoneyKindCd5RF_tNedit.Text.Trim();
            //_cache6 = this.PayStMoneyKindCd6RF_tNedit.Text.Trim();
            //_cache7 = this.PayStMoneyKindCd7RF_tNedit.Text.Trim();
            //_cache8 = this.PayStMoneyKindCd8RF_tNedit.Text.Trim();
            //_cache9 = this.PayStMoneyKindCd9RF_tNedit.Text.Trim();
            //_cache10 = this.PayStMoneyKindCd10RF_tNedit.Text.Trim();

            // 初期値取得
            _cache1 = this.paymentSet.PayStMoneyKindCd1.ToString();
            _cache2 = this.paymentSet.PayStMoneyKindCd2.ToString();
            _cache3 = this.paymentSet.PayStMoneyKindCd3.ToString();
            _cache4 = this.paymentSet.PayStMoneyKindCd4.ToString();
            _cache5 = this.paymentSet.PayStMoneyKindCd5.ToString();
            _cache6 = this.paymentSet.PayStMoneyKindCd6.ToString();
            _cache7 = this.paymentSet.PayStMoneyKindCd7.ToString();
            _cache8 = this.paymentSet.PayStMoneyKindCd8.ToString();
            _cache9 = this.paymentSet.PayStMoneyKindCd9.ToString();
            _cache10 = this.paymentSet.PayStMoneyKindCd10.ToString();

            

			// 画面初期設定処理
            //2006.06.09  EMI Del			ScreenInitialSetting(); 
		}

        //2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// Form.Closing イベント(SFSIR09020UA)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        ///// <remarks>
        ///// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        ///// <br>Programmer : 21027 須川  程志郎</br>
        ///// <br>Date       : 2005.04.12</br>
        ///// </remarks>
        //private void SFSIR09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    // 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //    this._paymentSetClone = null;
        //    // 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

        //    // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
        //    // フォームを非表示化する。
        //    //（フォームの「×」をクリックされた場合の対応です。）
        //    if (CanClose == false)
        //    {
        //        e.Cancel = true;
        //        this.Hide();
        //    }
        //}
        //2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Form.Closing イベント(SFSIR09020UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22029 平山　恵美</br>
        /// <br>Date       : 2006/6/9</br>　
        /// </remarks>
        private void SFSIR09020UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO Close
            // 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            this._paymentSetClone = null;
            // 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// Form.VisibleChanged イベント(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 画面の表示、非表示が変わった時に発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void SFSIR09020UA_VisibleChanged(object sender, System.EventArgs e)
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

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._paymentSetClone != null)
			{
				return;
			}
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			ScreenClear();
			timer1.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{

            foreach (Control control in this._controlTable.Values)
            {
                if (control is TNedit)
                {
                    if (control.Name.IndexOf("PayStMoneyKindCd") == 0)
                    {
                        string payStMoneyKindCdNm = "PayStMoneyKindCd" + ((TNedit)control).Tag.ToString() + "RF_tEdit";
                        TEdit payStMoneyKindCdNmRF_tEdit = ((TEdit)this._controlTable[payStMoneyKindCdNm]);
                        if (PayStMonKiCdChange(0, (TNedit)control, payStMoneyKindCdNmRF_tEdit) != 0)
                        {
                            return;
                        }
                    }
                }
            }

			// 保存処理
			if (SavePaymentSet() != 0)
			{
				return;
			}

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._paymentSetClone = null;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			DialogResult dialogResult = DialogResult.OK;

			Mode_Label.Text = UPDATE_MODE;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

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
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Cancel;

			// 支払設定クラスデータ格納
			ScreenToPaymentSet();
			if (!this.paymentSet.Equals(_paymentSetClone))
			{
				// 画面情報が変更されていた場合は、保存確認メッセージを表示する
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
					"SFSIR09020U", 			                              // アセンブリＩＤまたはクラスＩＤ
					null, 					                              // 表示するメッセージ
					0, 					                                  // ステータス値
					MessageBoxButtons.YesNoCancel);	                      // 表示するボタン
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
				switch (res)
				{
					case DialogResult.Yes :
					{
						if (SavePaymentSet() != 0)
						{
							return;
						}
						dialogResult = DialogResult.OK;
						break;
					}
					case DialogResult.No :
					{
						dialogResult = DialogResult.Cancel;
						break;
					}
					case DialogResult.Cancel :
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Cancel_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._paymentSetClone = null;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
		/// Control.Click イベント(Guide_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ガイドボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void PayStMoneyKindCd1RF_tUltraBtn_Click(object sender, System.EventArgs e)
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.07 TAKAHASHI ADD START
			string objectName = null;

			if (sender is UltraButton)
			{
				objectName = ((UltraButton)sender).Name;
				StartGuidProc(objectName);
			}
			else
			{
				return;
			}			
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.07 TAKAHASHI ADD END
		}

		/// <summary>
		/// Timer.Tick イベント(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : タイマーが起動するときに発生します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();
        }

        #region [2005.09.24 TAKAHASHI DELETE START]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI DELETE START
//		/// <summary>
//		/// TRetKeyControl.ChangeFocus イベント(SFSIR09020UA)
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">キー情報</param>
//		/// <remarks>
//		/// <br>Note       : フォーカスが遷移するときに発生します。</br>
//		/// <br>Programmer : 21027 須川  程志郎</br>
//		/// <br>Date       : 2005.04.12</br>
//		/// </remarks>
//		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
//		{
//			if ((e.PrevCtrl == null)	|| (e.NextCtrl == null)) return;
//			
//			// ↓ 要変更 /////////////////////////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
////			// 終了ボタンクリック時はチェックしない
////			if (!(Convert.ToInt32(e.NextCtrl.Tag) == 220))
////			{
//// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//			// 終了ボタンクリック時はチェックしない
//			if ((!(Convert.ToInt32(e.NextCtrl.Tag) == 220)) &&
//				(this._changeFlg == true))
//			{
//				this._changeFlg = false;
//// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//				// 入力コードより名称取得
//				int compTag =  Convert.ToInt32(e.PrevCtrl.Tag);
//
//				if ((e.PrevCtrl is TNedit) && (compTag >= 100) && (compTag < 200))
//				{
//					int wrkInt = ((TNedit)e.PrevCtrl).GetInt();
//					string wrkStr;
//
//					switch (wrkInt)
//					{
//						case 0 :
//						{
//							wrkStr = null;
//							break;
//						}
//						case 1 :
//						{
//							wrkStr = "現金・小切手";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "振込";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "クレジット";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "手数料";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "手形";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "相殺";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "その他";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "値引";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "預り金";
//							break;
//						}
//						default :
//						{
//							MessageBox.Show(
//								"マスタに登録されていません。\nコード参照機能は未実装です。\nリテラルでの仮対応です。",
//								"入力チェック",
//								MessageBoxButtons.OK,
//								MessageBoxIcon.Exclamation,
//								MessageBoxDefaultButton.Button1);
//							wrkStr = "未登録";
//							e.NextCtrl = e.PrevCtrl;
//							if (e.NextCtrl is TNedit)
//							{
//								((TNedit)(e.NextCtrl)).SelectAll();
//							}
//							break;
//						}
//					}
//
//					if (this.Controls.Count != 0)
//					{
//						for (int i=0; i < this.Controls.Count; i++)
//						{
//							// 設定項目タイトル
//							if (this.Controls[i] is TEdit)
//							{
//								TEdit teditComp = (TEdit)this.Controls[i];
//								if (compTag +10L == Convert.ToInt32(teditComp.Tag))
//								{
//									teditComp.Text = wrkStr;
//									break;
//								}
//							}
//						}
//					}
//				}
//			}
//			// ↑ 要変更 /////////////////////////////////////////////////////////////////
//		}
//////////////////////////////////////////////// 2005.06.13 TERASAKA ADD STA //
//		/// <summary>
//		/// ArrowKeyControl.ChangeFocus イベント(SFSIR09020UA)
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">キー情報</param>
//		/// <remarks>
//		/// <br>Note       : フォーカスが遷移するときに発生します。</br>
//		/// <br>Programmer : 22024 寺坂　誉志</br>
//		/// <br>Date       : 2005.06.13</br>
//		/// </remarks>
//		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
//		{
//			if (e.NextCtrl == null) return;
//////////////////////////////////////////////// 2005.06.27 TERASAKA DEL STA //
////			if (e.PrevCtrl == this.PayInitSystemDivRF_tComboEditor)
////			{
////				switch (e.Key)
////				{
////					case Keys.Up:
////					{
////						e.NextCtrl = this.Cancel_Button;
////						break;
////					}
////					case Keys.Down:
////					{
////						e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
////						break;
////					}
////				}
////			}
////			else if (e.PrevCtrl == this.Ok_Button)
////			{
////				if (e.Key == Keys.Down)
////				{
////					e.NextCtrl = this.Cancel_Button;
////				}
////			}
////			else if (e.PrevCtrl == this.Cancel_Button)
////			{
////				if ((e.Key == Keys.Down) ||
////					(e.Key == Keys.Right))
////				{
////					e.NextCtrl = this.PayInitSystemDivRF_tComboEditor;
////				}
////			}
//// 2005.06.27 TERASAKA DEL END //////////////////////////////////////////////
//			// ↓ 要変更 /////////////////////////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
////			// 終了ボタンクリック時はチェックしない
////			if (!(Convert.ToInt32(e.NextCtrl.Tag) == 220))
////			{
//// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//			// 終了ボタンクリック時はチェックしない
//			if ((!(Convert.ToInt32(e.NextCtrl.Tag) == 220)) &&
//				(this._changeFlg == true))
//			{
//				this._changeFlg = false;
//// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//				// 入力コードより名称取得
//				int compTag =  Convert.ToInt32(e.PrevCtrl.Tag);
//
//				if ((e.PrevCtrl is TNedit) && (compTag >= 100) && (compTag < 200))
//				{
//					int wrkInt = ((TNedit)e.PrevCtrl).GetInt();
//					string wrkStr;
//
//					switch (wrkInt)
//					{
//						case 0 :
//						{
//							wrkStr = null;
//							break;
//						}
//						case 1 :
//						{
//							wrkStr = "現金・小切手";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "振込";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "クレジット";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "手数料";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "手形";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "相殺";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "その他";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "値引";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "預り金";
//							break;
//						}
//						default :
//						{
//							MessageBox.Show(
//								"マスタに登録されていません。\nコード参照機能は未実装です。\nリテラルでの仮対応です。",
//								"入力チェック",
//								MessageBoxButtons.OK,
//								MessageBoxIcon.Exclamation,
//								MessageBoxDefaultButton.Button1);
//							wrkStr = "未登録";
//							e.NextCtrl = e.PrevCtrl;
//							if (e.NextCtrl is TNedit)
//							{
//								((TNedit)(e.NextCtrl)).SelectAll();
//							}
//							break;
//						}
//					}
//
//					if (this.Controls.Count != 0)
//					{
//						for (int i=0; i < this.Controls.Count; i++)
//						{
//							// 設定項目タイトル
//							if (this.Controls[i] is TEdit)
//							{
//								TEdit teditComp = (TEdit)this.Controls[i];
//								if (compTag +10L == Convert.ToInt32(teditComp.Tag))
//								{
//									teditComp.Text = wrkStr;
//									break;
//								}
//							}
//						}
//					}
//				}
//			}
//			// ↑ 要変更 /////////////////////////////////////////////////////////////////
//		}
//// 2005.06.13 TERASAKA ADD END //////////////////////////////////////////////
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI DELETE END
        #endregion

        ////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
		/// <summary>
		///	Control.Enter イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note			:	Controlがアクティブになった際に発生します。</br>
		/// <br>Programmer		:	22024 寺坂　誉志</br>
		/// <br>Date			:	2005.06.20</br>
		/// </remarks>
		private void tNedit_Enter(object sender, System.EventArgs e)
		{
            // 前の値を保存
            //this._cachedValue = ((Broadleaf.Library.Windows.Forms.TNedit)sender).Text.Trim();
            //MessageBox.Show(_cachedValue);
            // 継続可
            _continueFlag = true;

			this._changeFlg = false;
		}

// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.ValueChanged イベント(tNedit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : tNedit内のデータが変更された際に発生します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2006.01.13</br>
		/// </remarks>
		private void tNedit_ValueChanged(object sender, System.EventArgs e)
		{
			// ユーザーによって変更された場合
			if (((TNedit)sender).Modified)
			{
				this._changeFlg = true;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キー情報</param>
		/// <remarks>
		/// <br>Note			:	Control上でtNeditを抜けた際に発生します。</br>
		/// <br>Programmer		:	23006　高橋 明子</br>
		/// <br>Date			:	2005.09.22</br>
		/// </remarks>
		private void tNedit_Leave(object sender, System.EventArgs e)
		{
            // 拡張性及び柔軟性が全くないため削除

//            string name;

//            TNedit payStMonKiCd = (TNedit)sender;

//            TEdit payStMonKiNm = (TEdit)this._controlTable["PayStMoneyKindCd" + (payStMonKiCd).Tag + "RF_tEdit"];
////2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//            //if (payStMonKiCd == InitSelMoneyKindCdRF_tNedit)
//            //{
//            //    payStMonKiNm = (TEdit)this._controlTable["InitSelMoneyKindCd" + "RF_tEdit"];
//            //}
////2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//            if (payStMonKiCd.GetInt() == 0)
//            {
//                payStMonKiCd.Clear();
//                payStMonKiNm.Clear();
//            }
//            else if (this._changeFlg == true)
//            {
//                this._changeFlg = false;

//                //if (PayStMonKiCdChange(out name, payStMonKiCd.GetInt()) != 0)
//                if (PayStMonKiCdChange(0, payStMonKiCd, payStMonKiNm) != 0)
//                {
//                    payStMonKiCd.Focus();
//                    payStMonKiCd.SelectAll();
//                }
	
//                //payStMonKiNm.Text = name;
				
//            }

//            // キャッシュクリア
//            this._cachedValue = string.Empty;

        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd1RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd1RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd1RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd1RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd1RF_tNedit.Clear();
                PayStMoneyKindCd1RF_tEdit.Clear();
                PayStMoneyKindCd2RF_tNedit.Clear();
                PayStMoneyKindCd2RF_tEdit.Clear();
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd2RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd2RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd2RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd2RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd2RF_tNedit.Clear();
                PayStMoneyKindCd2RF_tEdit.Clear();
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd2RF_tNedit, PayStMoneyKindCd2RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd3RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 2, false);
                    }
                    PayStMoneyKindCd2RF_tNedit.Focus();
                    PayStMoneyKindCd2RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd3RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd3RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd3RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd3RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd3RF_tNedit, PayStMoneyKindCd3RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd4RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 4, false);
                    }
                    PayStMoneyKindCd3RF_tNedit.Focus();
                    PayStMoneyKindCd3RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd4RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd4RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd4RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd4RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd4RF_tNedit, PayStMoneyKindCd4RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd5RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 5, false);
                    }
                    PayStMoneyKindCd4RF_tNedit.Focus();
                    PayStMoneyKindCd4RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd5RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd5RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd5RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd5RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd5RF_tNedit, PayStMoneyKindCd5RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd6RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 6, false);
                    }
                    PayStMoneyKindCd5RF_tNedit.Focus();
                    PayStMoneyKindCd5RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd6RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd6RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd6RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd6RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd6RF_tNedit, PayStMoneyKindCd6RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd7RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 7, false);
                    }
                    PayStMoneyKindCd6RF_tNedit.Focus();
                    PayStMoneyKindCd6RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd7RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd7RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd7RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd7RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd7RF_tNedit, PayStMoneyKindCd7RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd8RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 8, false);
                    }
                    PayStMoneyKindCd7RF_tNedit.Focus();
                    PayStMoneyKindCd7RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd8RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd8RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd8RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd8RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd8RF_tNedit, PayStMoneyKindCd8RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd9RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 9, false);
                    }
                    PayStMoneyKindCd8RF_tNedit.Focus();
                    PayStMoneyKindCd8RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd9RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd9RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd9RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd9RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd9RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd9RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd9RF_tNedit, PayStMoneyKindCd9RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd10RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 10, false);
                    }
                    PayStMoneyKindCd9RF_tNedit.Focus();
                    PayStMoneyKindCd9RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd10RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd10RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd10RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd10RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "金種コードに0は指定できません。", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd10RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd10RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd10RF_tNedit, PayStMoneyKindCd10RF_tEdit) != 0)
                {
                    PayStMoneyKindCd10RF_tNedit.Focus();
                    PayStMoneyKindCd10RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        # endregion

        /// <summary>
        /// コントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            bool correctCode = false;
            bool isEmpty = false;

            // 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region 初期設定金種コード [InitSelMoneyKindCdRF_tNedit]
                case "InitSelMoneyKindCdRF_tNedit":
                    {
                        string code = this.InitSelMoneyKindCdRF_tNedit.Text.Trim();

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(code))
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.InitSelMoneyKindCdRF_tUltraBtn;
                                    }
                                    else
                                    {
                                        // 入力されていれば支払設定金種コード1へ
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    }

                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 閉じるボタンへ
                                    e.NextCtrl = this.Cancel_Button;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 初期設定金種コード [InitSelMoneyKindCdRF_tNedit]

                #region 支払設定金種コード1 [PayStMoneyKindCd1RF_tNedit]
                case "PayStMoneyKindCd1RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd1RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache1 = string.Empty;
                            // 2番目以降をDisableに
                            EnableMonKindCodeFields(false, 2, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd1RF_tNedit, PayStMoneyKindCd1RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache1 = code;
                                // 2番目をEnableに
                                EnableMonKindCodeFields(false, 2, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd1RF_tNedit.Text = this._cache1;
                            }
                        }
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        
                                        if (correctCode)
                                        {
                                            // コードが正しければ2へ
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // コード不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                            PayStMoneyKindCd1RF_tNedit.Focus();
                                            PayStMoneyKindCd1RF_tNedit.SelectAll();
                                        }
                                    }

                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はキャンセルボタンへ
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                    else
                                    {

                                        if (correctCode)
                                        {
                                            // コードが正しければ2へ
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // コード不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                            PayStMoneyKindCd1RF_tNedit.Focus();
                                            PayStMoneyKindCd1RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード1 [PayStMoneyKindCd1RF_tNedit]

                #region 支払設定金種コード1ガイド [PayStMoneyKindCd1RF_tUltraBtn]
                case "PayStMoneyKindCd1RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 2がEnableならそちらへ
                                    if (this.PayStMoneyKindCd2RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード2へ
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // キャンセルボタンへ
                                    e.NextCtrl = this.Cancel_Button;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード1ガイド [PayStMoneyKindCd1RF_tUltraBtn]

                #region 支払設定金種コード2 [PayStMoneyKindCd2RF_tNedit]
                case "PayStMoneyKindCd2RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd2RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache2 = string.Empty;
                            // 3番目以降をDisableに
                            EnableMonKindCodeFields(false, 3, false);   
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd2RF_tNedit, PayStMoneyKindCd2RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache2 = code;
                                // 3番目をEnableに
                                EnableMonKindCodeFields(false, 3, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd2RF_tNedit.Text = this._cache2;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tUltraBtn;
                                    }
                                    else 
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ3へ
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                            PayStMoneyKindCd2RF_tNedit.Focus();
                                            PayStMoneyKindCd2RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は1へ
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ1へ
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                            PayStMoneyKindCd2RF_tNedit.Focus();
                                            PayStMoneyKindCd2RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード2 [PayStMoneyKindCd2RF_tNedit]

                #region 支払設定金種コード2ガイド [PayStMoneyKindCd2RF_tUltraBtn]
                case "PayStMoneyKindCd2RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 3がEnableならそちらへ
                                    if (this.PayStMoneyKindCd3RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード3へ
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード1へ
                                    e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード2ガイド [PayStMoneyKindCd2RF_tUltraBtn]

                #region 支払設定金種コード3 [PayStMoneyKindCd3RF_tNedit]
                case "PayStMoneyKindCd3RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd3RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache3 = string.Empty;
                            // 4番目以降をDisableに
                            EnableMonKindCodeFields(false, 4, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd3RF_tNedit, PayStMoneyKindCd3RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache3 = code;
                                // 4番目をEnableに
                                EnableMonKindCodeFields(false, 4, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd3RF_tNedit.Text = this._cache3;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ4へ
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                            PayStMoneyKindCd3RF_tNedit.Focus();
                                            PayStMoneyKindCd3RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は2へ
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ2へ
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                            PayStMoneyKindCd3RF_tNedit.Focus();
                                            PayStMoneyKindCd3RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード3 [PayStMoneyKindCd3RF_tNedit]

                #region 支払設定金種コード3ガイド [PayStMoneyKindCd3RF_tUltraBtn]
                case "PayStMoneyKindCd3RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 4がEnableならそちらへ
                                    if (this.PayStMoneyKindCd4RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード4へ
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード2へ
                                    e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード3ガイド [PayStMoneyKindCd3RF_tUltraBtn]

                #region 支払設定金種コード4 [PayStMoneyKindCd4RF_tNedit]
                case "PayStMoneyKindCd4RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd4RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache4 = string.Empty;
                            // 5番目以降をDisableに
                            EnableMonKindCodeFields(false, 5, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd4RF_tNedit, PayStMoneyKindCd4RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache4 = code;
                                // 5番目をEnableに
                                EnableMonKindCodeFields(false, 5, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd4RF_tNedit.Text = this._cache4;
                            }
                        }
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ5へ
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                            PayStMoneyKindCd4RF_tNedit.Focus();
                                            PayStMoneyKindCd4RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は3へ
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ3へ
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                            PayStMoneyKindCd4RF_tNedit.Focus();
                                            PayStMoneyKindCd4RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード4 [PayStMoneyKindCd4RF_tNedit]

                #region 支払設定金種コード4ガイド [PayStMoneyKindCd4RF_tUltraBtn]
                case "PayStMoneyKindCd4RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 5がEnableならそちらへ
                                    if (this.PayStMoneyKindCd5RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード5へ
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード3へ
                                    e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード4ガイド [PayStMoneyKindCd4RF_tUltraBtn]

                #region 支払設定金種コード5 [PayStMoneyKindCd5RF_tNedit]
                case "PayStMoneyKindCd5RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd5RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache5 = string.Empty;
                            // 6番目以降をDisableに
                            EnableMonKindCodeFields(false, 6, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd5RF_tNedit, PayStMoneyKindCd5RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache5 = code;
                                // 6番目をEnableに
                                EnableMonKindCodeFields(false, 6, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd5RF_tNedit.Text = this._cache5;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ6へ
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                            PayStMoneyKindCd5RF_tNedit.Focus();
                                            PayStMoneyKindCd5RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は4へ
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ4へ
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                            PayStMoneyKindCd5RF_tNedit.Focus();
                                            PayStMoneyKindCd5RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード5 [PayStMoneyKindCd5RF_tNedit]

                #region 支払設定金種コード5ガイド [PayStMoneyKindCd5RF_tUltraBtn]
                case "PayStMoneyKindCd5RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 6がEnableならそちらへ
                                    if (this.PayStMoneyKindCd6RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード6へ
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード4へ
                                    e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード5ガイド [PayStMoneyKindCd5RF_tUltraBtn]

                #region 支払設定金種コード6 [PayStMoneyKindCd6RF_tNedit]
                case "PayStMoneyKindCd6RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd6RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache6 = string.Empty;
                            // 7番目以降をDisableに
                            EnableMonKindCodeFields(false, 7, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd6RF_tNedit, PayStMoneyKindCd6RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache6 = code;
                                // 7番目をEnableに
                                EnableMonKindCodeFields(false, 7, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd6RF_tNedit.Text = this._cache6;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ7へ
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                            PayStMoneyKindCd6RF_tNedit.Focus();
                                            PayStMoneyKindCd6RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は5へ
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ5へ
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                            PayStMoneyKindCd6RF_tNedit.Focus();
                                            PayStMoneyKindCd6RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード6 [PayStMoneyKindCd6RF_tNedit]

                #region 支払設定金種コード6ガイド [PayStMoneyKindCd6RF_tUltraBtn]
                case "PayStMoneyKindCd6RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 7がEnableならそちらへ
                                    if (this.PayStMoneyKindCd7RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード7へ
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード5へ
                                    e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード6ガイド [PayStMoneyKindCd6RF_tUltraBtn]

                #region 支払設定金種コード7 [PayStMoneyKindCd7RF_tNedit]
                case "PayStMoneyKindCd7RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd7RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache7 = string.Empty;
                            // 8番目以降をDisableに
                            EnableMonKindCodeFields(false, 8, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd7RF_tNedit, PayStMoneyKindCd7RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache7 = code;
                                // 8番目をEnableに
                                EnableMonKindCodeFields(false, 8, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd7RF_tNedit.Text = this._cache7;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ8へ
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                            PayStMoneyKindCd7RF_tNedit.Focus();
                                            PayStMoneyKindCd7RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は6へ
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ6へ
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                            PayStMoneyKindCd7RF_tNedit.Focus();
                                            PayStMoneyKindCd7RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード7 [PayStMoneyKindCd7RF_tNedit]

                #region 支払設定金種コード7ガイド [PayStMoneyKindCd7RF_tUltraBtn]
                case "PayStMoneyKindCd7RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 8がEnableならそちらへ
                                    if (this.PayStMoneyKindCd8RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード8へ
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード6へ
                                    e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード7ガイド [PayStMoneyKindCd7RF_tUltraBtn]

                #region 支払設定金種コード8 [PayStMoneyKindCd8RF_tNedit]
                case "PayStMoneyKindCd8RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd8RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache8 = string.Empty;
                            // 9番目以降をDisableに
                            EnableMonKindCodeFields(false, 9, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd8RF_tNedit, PayStMoneyKindCd8RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache8 = code;
                                // 9番目をEnableに
                                //EnableMonKindCodeFields(false, 9, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd8RF_tNedit.Text = this._cache8;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ9へ
                                            //e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                            PayStMoneyKindCd8RF_tNedit.Focus();
                                            PayStMoneyKindCd8RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は7へ
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ7へ
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                            PayStMoneyKindCd8RF_tNedit.Focus();
                                            PayStMoneyKindCd8RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード8 [PayStMoneyKindCd8RF_tNedit]

                #region 支払設定金種コード8ガイド [PayStMoneyKindCd8RF_tUltraBtn]
                case "PayStMoneyKindCd8RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    //// 9がEnableならそちらへ
                                    //if (this.PayStMoneyKindCd9RF_tNedit.Enabled)
                                    //{
                                    //    // 入力設定金種コード9へ
                                    //    e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    //}
                                    //else
                                    //{
                                        // 保存ボタンへ
                                    //e.NextCtrl = this.Ok_Button;
                                    e.NextCtrl = this.Renewal_Button;
                                    //}
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード7へ
                                    e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード8ガイド [PayStMoneyKindCd8RF_tUltraBtn]

                #region 支払設定金種コード9 [PayStMoneyKindCd9RF_tNedit]
                case "PayStMoneyKindCd9RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd9RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache9 = string.Empty;
                            // 10番目以降をDisableに
                            EnableMonKindCodeFields(false, 10, false);
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd9RF_tNedit, PayStMoneyKindCd9RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache9 = code;
                                // 10番目をEnableに
                                EnableMonKindCodeFields(false, 10, true);
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd9RF_tNedit.Text = this._cache9;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd9RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ10へ
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            PayStMoneyKindCd9RF_tNedit.Focus();
                                            PayStMoneyKindCd9RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は8へ
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ8へ
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            PayStMoneyKindCd9RF_tNedit.Focus();
                                            PayStMoneyKindCd9RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード9 [PayStMoneyKindCd9RF_tNedit]

                #region 支払設定金種コード9ガイド [PayStMoneyKindCd9RF_tUltraBtn]
                case "PayStMoneyKindCd9RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 10がEnableならそちらへ
                                    if (this.PayStMoneyKindCd10RF_tNedit.Enabled)
                                    {
                                        // 入力設定金種コード10へ
                                        e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                    }
                                    else
                                    {
                                        // 保存ボタンへ
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード8へ
                                    e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード9ガイド [PayStMoneyKindCd9RF_tUltraBtn]

                #region 支払設定金種コード10 [PayStMoneyKindCd10RF_tNedit]
                case "PayStMoneyKindCd10RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd10RF_tNedit.Text.Trim();

                        // 入力された値のチェック
                        if (String.IsNullOrEmpty(code))
                        {
                            // 空白
                            isEmpty = true;
                            this._cache10 = string.Empty;
                        }
                        else
                        {
                            // コードチェック
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd10RF_tNedit, PayStMoneyKindCd10RF_tEdit) == 0)
                            {
                                // コードは正しい
                                correctCode = true;

                                // コードが正しければキャッシュを更新
                                this._cache10 = code;
                            }
                            else
                            {
                                // コード不正

                                // 値を戻す
                                this.PayStMoneyKindCd10RF_tNedit.Text = this._cache10;
                            }
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合はガイドボタンへ
                                        e.NextCtrl = this.PayStMoneyKindCd10RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければOKボタンへ
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                            PayStMoneyKindCd10RF_tNedit.Focus();
                                            PayStMoneyKindCd10RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // 空白の場合は9へ
                                        e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // コードが正しければ9へ
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                        }
                                        else
                                        {
                                            // コードが不正なら移動不可
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                            PayStMoneyKindCd10RF_tNedit.Focus();
                                            PayStMoneyKindCd10RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード10 [PayStMoneyKindCd10RF_tNedit]

                #region 支払設定金種コード10ガイド [PayStMoneyKindCd10RF_tUltraBtn]
                case "PayStMoneyKindCd10RF_tUltraBtn":
                    {
                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 保存ボタンへ
                                    e.NextCtrl = this.Ok_Button;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 入力設定金種コード9へ
                                    e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // 支払設定金種コード10ガイド [PayStMoneyKindCd10RF_tUltraBtn]
            }

        }

        /// <summary>
        /// 画面上のボタンおよびコード入力欄をEnable/Disableに
        /// </summary>
        /// <param name="initialSetting"></param>
        /// <param name="codeNumber"></param>
        /// <param name="enable"></param>
        private void EnableMonKindCodeFields(bool initialSetting, int codeNumber, bool enable)
        {
            if (initialSetting)
            {
                // 1を除くすべての金種コード入力欄をDisableに。ガイドボタンもDisable
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd1RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd1RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd2RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd2RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd2RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd2RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd3RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd3RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd3RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd3RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd4RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd4RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd4RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd4RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd5RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd5RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd5RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd5RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd6RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd6RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd6RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd6RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd7RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd7RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd7RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd7RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd8RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd8RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd8RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd8RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd9RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd9RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd9RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd9RF_Label.Text.Equals("未登録"))
                {
                    this.PayStMoneyKindCd10RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd10RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = true;
                }
            }
            else
            {
                if (enable)
                {
                    if (codeNumber == 2)
                    //switch (codeNumber)
                    {
                        // ２番目をEnable/Disableに
                        this.PayStMoneyKindCd2RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 3)
                    {
                        // ３番目をEnable/Disableに
                        this.PayStMoneyKindCd3RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 4)
                    {
                        // ４番目をEnable/Disableに
                        this.PayStMoneyKindCd4RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 5)
                    {
                        // ５番目をEnable/Disableに
                        this.PayStMoneyKindCd5RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 6)
                    {
                        // ６番目をEnable/Disableに
                        this.PayStMoneyKindCd6RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 7)
                    {
                        // ７番目をEnable/Disableに
                        this.PayStMoneyKindCd7RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 8)
                    {
                        // ８番目をEnable/Disableに
                        this.PayStMoneyKindCd8RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 9)
                    {
                        // ９番目をEnable/Disableに
                        this.PayStMoneyKindCd9RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 10)
                    {
                        // １０番目をEnable/Disableに
                        this.PayStMoneyKindCd10RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = enable;
                    }

                }
                else
                {
                    // falseのときはキー項目以下をすべてfalse

                    if (codeNumber < 3)
                    //switch (codeNumber)
                    {
                        // ２番目をEnable/Disableに
                        this.PayStMoneyKindCd2RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 4)
                    {
                        // ３番目をEnable/Disableに
                        this.PayStMoneyKindCd3RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 5)
                    {
                        // ４番目をEnable/Disableに
                        this.PayStMoneyKindCd4RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 6)
                    {
                        // ５番目をEnable/Disableに
                        this.PayStMoneyKindCd5RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 7)
                    {
                        // ６番目をEnable/Disableに
                        this.PayStMoneyKindCd6RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 8)
                    {
                        // ７番目をEnable/Disableに
                        this.PayStMoneyKindCd7RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 9)
                    {
                        // ８番目をEnable/Disableに
                        this.PayStMoneyKindCd8RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 10)
                    {
                        // ９番目をEnable/Disableに
                        this.PayStMoneyKindCd9RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 11)
                    {
                        // １０番目をEnable/Disableに
                        this.PayStMoneyKindCd10RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = enable;
                    }
                }
            }
        }

        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.paymentSetAcs = new PaymentSetAcs();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFSIR09020U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/19 残案件No.14対応------------------------------------------------------<<<<<
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金伝票入力（入金型）ＵＩデバッグクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金伝票入力（入金型）ＵＩのデバッグ機能を実装します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
	/// </remarks>
	public class SFUKK01403UZ : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 入金伝票入力（入金型）ＵＩデバッグクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01403UZ()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01403UZ));
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGrid2.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraGrid2.Location = new System.Drawing.Point(0, 144);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(1000, 174);
            this.ultraGrid2.TabIndex = 82;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGrid1.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1000, 144);
            this.ultraGrid1.TabIndex = 83;
            // 
            // SFUKK01403UZ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1000, 318);
            this.Controls.Add(this.ultraGrid2);
            this.Controls.Add(this.ultraGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK01403UZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "変更中　入金/入金引当データ";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 表示処理
		/// </summary>
		/// <param name="dr1">入金情報</param>
		/// <param name="dr2">入金引当情報</param>
		/// <remarks>
		/// <br>Note　　　  : 入金情報/入金引当情報を画面へ表示します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void DataSetBinding(System.Data.DataRow dr1, ArrayList dr2)
		{

			System.Data.DataTable dt1 = dr1.Table.Clone();
			System.Data.DataRow newRow1 = dt1.NewRow();
			newRow1.ItemArray = dr1.ItemArray;
			dt1.Rows.Add(newRow1);
			ultraGrid1.DataSource = dt1;
			ultraGrid1.Rows.ExpandAll(true);

			Infragistics.Win.UltraWinGrid.UltraGridBand bdDeposit = ultraGrid1.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositDataTable];
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteNm].Header.Caption			= "赤黒種類";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositSlipNo].Header.Caption				= "入金番号";
			// 2007.10.10 upd start ------------------------------------------------------------------------->>
            // 入金計上日を表示
            //bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDateDisp].Header.Caption				= "入金日";
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Header.Caption = "入金日";
            // 2007.10.10 upd end ---------------------------------------------------------------------------<<

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositCd].Header.Caption					= "区分コード";
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositNm].Header.Caption					= "区分";

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindDivCd].Header.Caption				= "金種区分";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindCode].Header.Caption				= "金種コード";
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindName].Header.Caption				= "金種";
            // ↓ 20070125 18322 d MA.NS用に変更
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDeposit].Header.Caption				= "入金額(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrChargeDeposit].Header.Caption			= "手数料(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDisDeposit].Header.Caption				= "値引(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositTotal].Header.Caption			= "入金合計(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVariousCostDeposit].Header.Caption			= "入金額(諸)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostChargeDeposit].Header.Caption			= "手数料(諸)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDisDeposit].Header.Caption			= "値引(諸)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVariousCostDepositTotal].Header.Caption		= "入金合計(諸)";
            // ↑ 20070125 18322 d
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit].Header.Caption						= "入金額";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Header.Caption					= "手数料";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Header.Caption				= "値引";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositTotal].Header.Caption					= "入金合計";
            // ↓ 20070125 18322 d MA.NS用に変更
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositAlwc_Deposit].Header.Caption	= "引当額(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepoAlwcBlnce_Deposit].Header.Caption	= "未引当額(受)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwc_Deposit].Header.Caption		= "引当額(諸)";
			//bdDeposit.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwcBlnce_Deposit].Header.Caption	= "未引当額(諸)";
            // ↑ 20070125 18322 d
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Header.Caption		= "引当額";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAlwcBlnce_Deposit].Header.Caption		= "未引当額";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctOutline].Header.Caption						= "摘要";
			bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Header.Caption				= "締";

			if (dr2.Count == 0) return;
			System.Data.DataTable dt2 = ((System.Data.DataRow)dr2[0]).Table.Clone();
			foreach (System.Data.DataRow dr in dr2)
			{
				System.Data.DataRow newRow2 = dt2.NewRow();
				newRow2.ItemArray = dr.ItemArray;
				dt2.Rows.Add(newRow2);
			}
			ultraGrid2.DataSource = dt2;
			ultraGrid2.Rows.ExpandAll(true);

			Infragistics.Win.UltraWinGrid.UltraGridBand bdAllowance = ultraGrid2.DisplayLayout.Bands[0];
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctDepositSlipNo_Alw].Header.Caption		= "入金番号";		// 入金番号
            // ↓ 20070125 18322 d MA.NS用に変更
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctAcceptAnOrderNo_Alw].Header.Caption	= "受注番号";		// 受注番号
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctAcpOdrDepositAlwc].Header.Caption		= "引当額(受)";		// 入金引当額 受注
			//bdAllowance.Columns[InputDepositNormalTypeAcs.ctVarCostDepoAlwc].Header.Caption		= "引当額(諸)";		// 入金引当額 諸費用
            // ↑ 20070125 18322 d
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctDepositAllowance].Header.Caption		= "引当額";			// 入金引当額 共通
			bdAllowance.Columns[InputDepositNormalTypeAcs.ctReconcileDateDisp].Header.Caption		= "引当日";			// 引当日
		}
	}
}

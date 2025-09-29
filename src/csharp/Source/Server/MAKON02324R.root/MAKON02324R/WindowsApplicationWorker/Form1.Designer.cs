using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace WindowsApplicationWorker
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private static string[] _parameter;
		private static System.Windows.Forms.Form _form = null;

		[STAThread]
		static void Main(String[] args) 
		{
			try
			{
				string msg = "";
				_parameter = args;
				//アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
				int status =  ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"WindowsApplicationWorker",ex.Message,0,MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//従業員ログオフのメッセージを表示
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
	
		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent ()
		{
            this.SectionCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EnterPriseCode = new System.Windows.Forms.TextBox();
            this.SlipNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Read = new System.Windows.Forms.Button();
            this.g_StockSlip = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.g_StockDetail = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.g_StockExplaData = new System.Windows.Forms.DataGrid();
            this.SupFomal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SecKind = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockSlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockExplaData)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionCode
            // 
            this.SectionCode.Location = new System.Drawing.Point(334, 36);
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.Size = new System.Drawing.Size(65, 19);
            this.SectionCode.TabIndex = 234;
            this.SectionCode.TabStop = false;
            this.SectionCode.Text = "未使用";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(248, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 233;
            this.label6.Text = "拠点コード";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EnterPriseCode
            // 
            this.EnterPriseCode.Location = new System.Drawing.Point(98, 13);
            this.EnterPriseCode.Name = "EnterPriseCode";
            this.EnterPriseCode.Size = new System.Drawing.Size(144, 19);
            this.EnterPriseCode.TabIndex = 232;
            this.EnterPriseCode.Text = "0113180842031000";
            // 
            // SlipNo
            // 
            this.SlipNo.Location = new System.Drawing.Point(605, 36);
            this.SlipNo.Name = "SlipNo";
            this.SlipNo.Size = new System.Drawing.Size(72, 19);
            this.SlipNo.TabIndex = 235;
            this.SlipNo.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(495, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 236;
            this.label5.Text = "仕入伝票番号";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeLabel.Location = new System.Drawing.Point(683, 13);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(107, 19);
            this.timeLabel.TabIndex = 237;
            this.timeLabel.Text = "Time:";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 238;
            this.label1.Text = "企業コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(165, 84);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(64, 24);
            this.Read.TabIndex = 239;
            this.Read.Text = "Read";
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // g_StockSlip
            // 
            this.g_StockSlip.DataMember = "";
            this.g_StockSlip.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.g_StockSlip.Location = new System.Drawing.Point(12, 114);
            this.g_StockSlip.Name = "g_StockSlip";
            this.g_StockSlip.Size = new System.Drawing.Size(913, 73);
            this.g_StockSlip.TabIndex = 240;
            this.g_StockSlip.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 241;
            this.label2.Text = "仕入データ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 243;
            this.label3.Text = "仕入明細データ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // g_StockDetail
            // 
            this.g_StockDetail.DataMember = "";
            this.g_StockDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.g_StockDetail.Location = new System.Drawing.Point(12, 214);
            this.g_StockDetail.Name = "g_StockDetail";
            this.g_StockDetail.Size = new System.Drawing.Size(913, 163);
            this.g_StockDetail.TabIndex = 242;
            this.g_StockDetail.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 245;
            this.label4.Text = "仕入詳細データ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // g_StockExplaData
            // 
            this.g_StockExplaData.DataMember = "";
            this.g_StockExplaData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.g_StockExplaData.Location = new System.Drawing.Point(12, 404);
            this.g_StockExplaData.Name = "g_StockExplaData";
            this.g_StockExplaData.Size = new System.Drawing.Size(913, 157);
            this.g_StockExplaData.TabIndex = 244;
            this.g_StockExplaData.TabStop = false;
            // 
            // SupFomal
            // 
            this.SupFomal.Location = new System.Drawing.Point(605, 13);
            this.SupFomal.Name = "SupFomal";
            this.SupFomal.Size = new System.Drawing.Size(72, 19);
            this.SupFomal.TabIndex = 246;
            this.SupFomal.Text = "0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(495, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 19);
            this.label7.TabIndex = 247;
            this.label7.Text = "仕入形式";
            // 
            // SecKind
            // 
            this.SecKind.Location = new System.Drawing.Point(334, 13);
            this.SecKind.Name = "SecKind";
            this.SecKind.Size = new System.Drawing.Size(65, 19);
            this.SecKind.TabIndex = 249;
            this.SecKind.TabStop = false;
            this.SecKind.Text = "0";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(248, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 248;
            this.label9.Text = "拠点区分";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 573);
            this.Controls.Add(this.SecKind);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SupFomal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.g_StockExplaData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.g_StockDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.g_StockSlip);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.SlipNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SectionCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EnterPriseCode);
            this.Name = "Form1";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g_StockSlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockExplaData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox SectionCode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox EnterPriseCode;
		private System.Windows.Forms.TextBox SlipNo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Read;
		private System.Windows.Forms.DataGrid g_StockSlip;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid g_StockDetail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid g_StockExplaData;
		private TextBox SupFomal;
		private Label label7;
		private TextBox SecKind;
		private Label label9;
	}
}
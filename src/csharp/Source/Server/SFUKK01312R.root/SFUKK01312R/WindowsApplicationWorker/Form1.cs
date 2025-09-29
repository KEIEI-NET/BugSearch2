using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;

using Infragistics.Win;
using Infragistics.Win.UltraWinTree;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region Private Control
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.IContainer components;
		private System.Data.DataSet dataSet1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button ReadBtn;
		private Broadleaf.Library.Windows.Forms.TEdit addSecCode_tEdit;
		private System.Windows.Forms.Label label9;
		private Broadleaf.Library.Windows.Forms.TEdit endEmployeeCode_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit startEmployeeCode_tEdit;
		private System.Windows.Forms.Label label7;
		private Broadleaf.Library.Windows.Forms.TEdit endKana_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit startKana_tEdit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private Broadleaf.Library.Windows.Forms.TNedit endAddUpYearMonth_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit startAddUpYearMonth_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit endCustomerCode_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit startCustomerCode_tNedit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox enterpriseCode_textBox;
		private System.Windows.Forms.Label label1;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet selectSearch_ultraOptionSet;
		private System.Windows.Forms.CheckBox allSecCode_checkBox;
		private System.Windows.Forms.CheckBox billOutputCodeFlg_checkBox;
		private Infragistics.Win.UltraWinTree.UltraTree corporateDivCode_ultraTree;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet employeeKind_ultraOptionSet;
		private Infragistics.Win.UltraWinTree.UltraTree secCode_ultraTree;
		private System.Windows.Forms.CheckBox outputZeroBlanceFlg_checkBox;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet selectDateType_ultraOptionSet;
		private System.Windows.Forms.Label label8;
		private Broadleaf.Library.Windows.Forms.TDateEdit endAddUpDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit startAddUpDate_tDateEdit;
		private System.Windows.Forms.Button SearchBtn;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private Broadleaf.Library.Windows.Forms.TNedit startTotalDay_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit endTotalDay_tNedit;
		private System.Windows.Forms.Button CheckBtn;
		private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
		private TNedit startCustAnalysCode1_tNedit;
		private TNedit endCustAnalysCode1_tNedit;
		private Label label16;
		private Label label17;
		private TNedit endCustAnalysCode6_tNedit;
		private TNedit startCustAnalysCode6_tNedit;
		private TNedit endCustAnalysCode5_tNedit;
		private TNedit startCustAnalysCode5_tNedit;
		private Label label14;
		private Label label15;
		private TNedit endCustAnalysCode4_tNedit;
		private TNedit startCustAnalysCode4_tNedit;
		private TNedit endCustAnalysCode3_tNedit;
		private TNedit startCustAnalysCode3_tNedit;
		private Label label13;
		private Label label12;
		private Label label11;
		private Label label10;
		private TNedit endCustAnalysCode2_tNedit;
		private TNedit startCustAnalysCode2_tNedit;
		private System.Windows.Forms.DataGrid dataGrid3;
		#endregion

		#region Constructor
		public Form1()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			this._retCustDmdPrcWork = new KingetCustDmdPrcWork();
		}
		#endregion

		#region Dispose
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
		#endregion

		#region Windows フォーム デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode1 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode2 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode3 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode4 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode5 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode6 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet2 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode7 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode8 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode9 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode10 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.Override _override2 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataSet1 = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.endCustAnalysCode6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endCustAnalysCode5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.endCustAnalysCode4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endCustAnalysCode3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.endCustAnalysCode2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endCustAnalysCode1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustAnalysCode1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.endTotalDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.addSecCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.endEmployeeCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.startEmployeeCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.endKana_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.startKana_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endAddUpYearMonth_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startAddUpYearMonth_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endCustomerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startCustomerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.startTotalDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enterpriseCode_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectSearch_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.allSecCode_checkBox = new System.Windows.Forms.CheckBox();
            this.billOutputCodeFlg_checkBox = new System.Windows.Forms.CheckBox();
            this.corporateDivCode_ultraTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.employeeKind_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.secCode_ultraTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.outputZeroBlanceFlg_checkBox = new System.Windows.Forms.CheckBox();
            this.selectDateType_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label8 = new System.Windows.Forms.Label();
            this.endAddUpDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.startAddUpDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTotalDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addSecCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endEmployeeCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEmployeeCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endKana_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startKana_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endAddUpYearMonth_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAddUpYearMonth_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustomerCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustomerCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTotalDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectSearch_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corporateDivCode_ultraTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeKind_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secCode_ultraTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectDateType_ultraOptionSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.White;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.ForeColor = System.Drawing.Color.Black;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Black;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGrid1.LinkColor = System.Drawing.Color.Navy;
            this.dataGrid1.Location = new System.Drawing.Point(0, 182);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid1.Size = new System.Drawing.Size(984, 152);
            this.dataGrid1.TabIndex = 1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(368, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 116);
            this.panel1.TabIndex = 56;
            this.panel1.Visible = false;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.BackColor = System.Drawing.Color.Silver;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGrid2.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.White;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.ForeColor = System.Drawing.Color.Black;
            this.dataGrid2.GridLineColor = System.Drawing.Color.White;
            this.dataGrid2.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGrid2.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid2.Location = new System.Drawing.Point(0, 338);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Black;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.White;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid2.Size = new System.Drawing.Size(984, 120);
            this.dataGrid2.TabIndex = 2;
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(0, 462);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(984, 120);
            this.dataGrid3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ultraExpandableGroupBox1);
            this.panel2.Controls.Add(this.CheckBtn);
            this.panel2.Controls.Add(this.endTotalDay_tNedit);
            this.panel2.Controls.Add(this.ReadBtn);
            this.panel2.Controls.Add(this.addSecCode_tEdit);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.endEmployeeCode_tEdit);
            this.panel2.Controls.Add(this.startEmployeeCode_tEdit);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.endKana_tEdit);
            this.panel2.Controls.Add(this.startKana_tEdit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.endAddUpYearMonth_tNedit);
            this.panel2.Controls.Add(this.startAddUpYearMonth_tNedit);
            this.panel2.Controls.Add(this.endCustomerCode_tNedit);
            this.panel2.Controls.Add(this.startCustomerCode_tNedit);
            this.panel2.Controls.Add(this.startTotalDay_tNedit);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.enterpriseCode_textBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.selectSearch_ultraOptionSet);
            this.panel2.Controls.Add(this.allSecCode_checkBox);
            this.panel2.Controls.Add(this.billOutputCodeFlg_checkBox);
            this.panel2.Controls.Add(this.corporateDivCode_ultraTree);
            this.panel2.Controls.Add(this.employeeKind_ultraOptionSet);
            this.panel2.Controls.Add(this.secCode_ultraTree);
            this.panel2.Controls.Add(this.outputZeroBlanceFlg_checkBox);
            this.panel2.Controls.Add(this.selectDateType_ultraOptionSet);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.endAddUpDate_tDateEdit);
            this.panel2.Controls.Add(this.startAddUpDate_tDateEdit);
            this.panel2.Controls.Add(this.SearchBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 182);
            this.panel2.TabIndex = 0;
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(299, 97);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(432, 98);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(299, 82);
            this.ultraExpandableGroupBox1.SupportThemes = false;
            this.ultraExpandableGroupBox1.TabIndex = 21;
            this.ultraExpandableGroupBox1.Text = "得意先分析コード";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label16);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label17);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode6_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode6_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode5_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode5_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label14);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label15);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode4_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode4_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode3_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode3_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label13);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label12);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label11);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.label10);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode2_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode2_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.endCustAnalysCode1_tNedit);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.startCustAnalysCode1_tNedit);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(293, 60);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(257, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "6";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(216, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "5";
            // 
            // endCustAnalysCode6_tNedit
            // 
            this.endCustAnalysCode6_tNedit.ActiveAppearance = appearance1;
            this.endCustAnalysCode6_tNedit.AutoSelect = true;
            this.endCustAnalysCode6_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode6_tNedit.DataText = "";
            this.endCustAnalysCode6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode6_tNedit.Location = new System.Drawing.Point(246, 38);
            this.endCustAnalysCode6_tNedit.MaxLength = 3;
            this.endCustAnalysCode6_tNedit.Name = "endCustAnalysCode6_tNedit";
            this.endCustAnalysCode6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode6_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode6_tNedit.TabIndex = 11;
            // 
            // startCustAnalysCode6_tNedit
            // 
            this.startCustAnalysCode6_tNedit.ActiveAppearance = appearance2;
            this.startCustAnalysCode6_tNedit.AutoSelect = true;
            this.startCustAnalysCode6_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode6_tNedit.DataText = "";
            this.startCustAnalysCode6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode6_tNedit.Location = new System.Drawing.Point(246, 16);
            this.startCustAnalysCode6_tNedit.MaxLength = 3;
            this.startCustAnalysCode6_tNedit.Name = "startCustAnalysCode6_tNedit";
            this.startCustAnalysCode6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode6_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode6_tNedit.TabIndex = 10;
            // 
            // endCustAnalysCode5_tNedit
            // 
            this.endCustAnalysCode5_tNedit.ActiveAppearance = appearance3;
            this.endCustAnalysCode5_tNedit.AutoSelect = true;
            this.endCustAnalysCode5_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode5_tNedit.DataText = "";
            this.endCustAnalysCode5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode5_tNedit.Location = new System.Drawing.Point(205, 38);
            this.endCustAnalysCode5_tNedit.MaxLength = 3;
            this.endCustAnalysCode5_tNedit.Name = "endCustAnalysCode5_tNedit";
            this.endCustAnalysCode5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode5_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode5_tNedit.TabIndex = 9;
            // 
            // startCustAnalysCode5_tNedit
            // 
            this.startCustAnalysCode5_tNedit.ActiveAppearance = appearance4;
            this.startCustAnalysCode5_tNedit.AutoSelect = true;
            this.startCustAnalysCode5_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode5_tNedit.DataText = "";
            this.startCustAnalysCode5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode5_tNedit.Location = new System.Drawing.Point(205, 16);
            this.startCustAnalysCode5_tNedit.MaxLength = 3;
            this.startCustAnalysCode5_tNedit.Name = "startCustAnalysCode5_tNedit";
            this.startCustAnalysCode5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode5_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode5_tNedit.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "4";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(134, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "3";
            // 
            // endCustAnalysCode4_tNedit
            // 
            this.endCustAnalysCode4_tNedit.ActiveAppearance = appearance5;
            this.endCustAnalysCode4_tNedit.AutoSelect = true;
            this.endCustAnalysCode4_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode4_tNedit.DataText = "";
            this.endCustAnalysCode4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode4_tNedit.Location = new System.Drawing.Point(164, 38);
            this.endCustAnalysCode4_tNedit.MaxLength = 3;
            this.endCustAnalysCode4_tNedit.Name = "endCustAnalysCode4_tNedit";
            this.endCustAnalysCode4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode4_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode4_tNedit.TabIndex = 7;
            // 
            // startCustAnalysCode4_tNedit
            // 
            this.startCustAnalysCode4_tNedit.ActiveAppearance = appearance6;
            this.startCustAnalysCode4_tNedit.AutoSelect = true;
            this.startCustAnalysCode4_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode4_tNedit.DataText = "";
            this.startCustAnalysCode4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode4_tNedit.Location = new System.Drawing.Point(164, 16);
            this.startCustAnalysCode4_tNedit.MaxLength = 3;
            this.startCustAnalysCode4_tNedit.Name = "startCustAnalysCode4_tNedit";
            this.startCustAnalysCode4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode4_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode4_tNedit.TabIndex = 6;
            // 
            // endCustAnalysCode3_tNedit
            // 
            this.endCustAnalysCode3_tNedit.ActiveAppearance = appearance7;
            this.endCustAnalysCode3_tNedit.AutoSelect = true;
            this.endCustAnalysCode3_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode3_tNedit.DataText = "";
            this.endCustAnalysCode3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode3_tNedit.Location = new System.Drawing.Point(123, 38);
            this.endCustAnalysCode3_tNedit.MaxLength = 3;
            this.endCustAnalysCode3_tNedit.Name = "endCustAnalysCode3_tNedit";
            this.endCustAnalysCode3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode3_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode3_tNedit.TabIndex = 5;
            // 
            // startCustAnalysCode3_tNedit
            // 
            this.startCustAnalysCode3_tNedit.ActiveAppearance = appearance8;
            this.startCustAnalysCode3_tNedit.AutoSelect = true;
            this.startCustAnalysCode3_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode3_tNedit.DataText = "";
            this.startCustAnalysCode3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode3_tNedit.Location = new System.Drawing.Point(123, 16);
            this.startCustAnalysCode3_tNedit.MaxLength = 3;
            this.startCustAnalysCode3_tNedit.Name = "startCustAnalysCode3_tNedit";
            this.startCustAnalysCode3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode3_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode3_tNedit.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(93, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "終了";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "開始";
            // 
            // endCustAnalysCode2_tNedit
            // 
            this.endCustAnalysCode2_tNedit.ActiveAppearance = appearance9;
            this.endCustAnalysCode2_tNedit.AutoSelect = true;
            this.endCustAnalysCode2_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode2_tNedit.DataText = "";
            this.endCustAnalysCode2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode2_tNedit.Location = new System.Drawing.Point(82, 38);
            this.endCustAnalysCode2_tNedit.MaxLength = 3;
            this.endCustAnalysCode2_tNedit.Name = "endCustAnalysCode2_tNedit";
            this.endCustAnalysCode2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode2_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode2_tNedit.TabIndex = 3;
            // 
            // startCustAnalysCode2_tNedit
            // 
            this.startCustAnalysCode2_tNedit.ActiveAppearance = appearance10;
            this.startCustAnalysCode2_tNedit.AutoSelect = true;
            this.startCustAnalysCode2_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode2_tNedit.DataText = "";
            this.startCustAnalysCode2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode2_tNedit.Location = new System.Drawing.Point(82, 16);
            this.startCustAnalysCode2_tNedit.MaxLength = 3;
            this.startCustAnalysCode2_tNedit.Name = "startCustAnalysCode2_tNedit";
            this.startCustAnalysCode2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode2_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode2_tNedit.TabIndex = 2;
            // 
            // endCustAnalysCode1_tNedit
            // 
            this.endCustAnalysCode1_tNedit.ActiveAppearance = appearance11;
            this.endCustAnalysCode1_tNedit.AutoSelect = true;
            this.endCustAnalysCode1_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustAnalysCode1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustAnalysCode1_tNedit.DataText = "";
            this.endCustAnalysCode1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustAnalysCode1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustAnalysCode1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustAnalysCode1_tNedit.Location = new System.Drawing.Point(41, 38);
            this.endCustAnalysCode1_tNedit.MaxLength = 3;
            this.endCustAnalysCode1_tNedit.Name = "endCustAnalysCode1_tNedit";
            this.endCustAnalysCode1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustAnalysCode1_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endCustAnalysCode1_tNedit.TabIndex = 1;
            // 
            // startCustAnalysCode1_tNedit
            // 
            this.startCustAnalysCode1_tNedit.ActiveAppearance = appearance12;
            this.startCustAnalysCode1_tNedit.AutoSelect = true;
            this.startCustAnalysCode1_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustAnalysCode1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustAnalysCode1_tNedit.DataText = "";
            this.startCustAnalysCode1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustAnalysCode1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustAnalysCode1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustAnalysCode1_tNedit.Location = new System.Drawing.Point(41, 16);
            this.startCustAnalysCode1_tNedit.MaxLength = 3;
            this.startCustAnalysCode1_tNedit.Name = "startCustAnalysCode1_tNedit";
            this.startCustAnalysCode1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustAnalysCode1_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startCustAnalysCode1_tNedit.TabIndex = 0;
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(875, 125);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(80, 23);
            this.CheckBtn.TabIndex = 24;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // endTotalDay_tNedit
            // 
            this.endTotalDay_tNedit.ActiveAppearance = appearance13;
            this.endTotalDay_tNedit.AutoSelect = true;
            this.endTotalDay_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endTotalDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endTotalDay_tNedit.DataText = "20";
            this.endTotalDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endTotalDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endTotalDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endTotalDay_tNedit.Location = new System.Drawing.Point(276, 28);
            this.endTotalDay_tNedit.MaxLength = 12;
            this.endTotalDay_tNedit.Name = "endTotalDay_tNedit";
            this.endTotalDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endTotalDay_tNedit.Size = new System.Drawing.Size(35, 21);
            this.endTotalDay_tNedit.TabIndex = 6;
            this.endTotalDay_tNedit.Text = "20";
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(875, 150);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(80, 23);
            this.ReadBtn.TabIndex = 25;
            this.ReadBtn.Text = "Read";
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // addSecCode_tEdit
            // 
            this.addSecCode_tEdit.ActiveAppearance = appearance14;
            this.addSecCode_tEdit.AutoSelect = true;
            this.addSecCode_tEdit.DataText = "000009";
            this.addSecCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.addSecCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.addSecCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.addSecCode_tEdit.Location = new System.Drawing.Point(18, 56);
            this.addSecCode_tEdit.MaxLength = 12;
            this.addSecCode_tEdit.Name = "addSecCode_tEdit";
            this.addSecCode_tEdit.Size = new System.Drawing.Size(66, 21);
            this.addSecCode_tEdit.TabIndex = 1;
            this.addSecCode_tEdit.Text = "000009";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(786, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 102;
            this.label9.Text = "個人・法人区分";
            // 
            // endEmployeeCode_tEdit
            // 
            this.endEmployeeCode_tEdit.ActiveAppearance = appearance15;
            this.endEmployeeCode_tEdit.AutoSelect = true;
            this.endEmployeeCode_tEdit.DataText = "";
            this.endEmployeeCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endEmployeeCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.endEmployeeCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.endEmployeeCode_tEdit.Location = new System.Drawing.Point(582, 72);
            this.endEmployeeCode_tEdit.MaxLength = 12;
            this.endEmployeeCode_tEdit.Name = "endEmployeeCode_tEdit";
            this.endEmployeeCode_tEdit.Size = new System.Drawing.Size(66, 21);
            this.endEmployeeCode_tEdit.TabIndex = 19;
            // 
            // startEmployeeCode_tEdit
            // 
            this.startEmployeeCode_tEdit.ActiveAppearance = appearance16;
            this.startEmployeeCode_tEdit.AutoSelect = true;
            this.startEmployeeCode_tEdit.DataText = "";
            this.startEmployeeCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startEmployeeCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.startEmployeeCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.startEmployeeCode_tEdit.Location = new System.Drawing.Point(514, 72);
            this.startEmployeeCode_tEdit.MaxLength = 12;
            this.startEmployeeCode_tEdit.Name = "startEmployeeCode_tEdit";
            this.startEmployeeCode_tEdit.Size = new System.Drawing.Size(66, 21);
            this.startEmployeeCode_tEdit.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 101;
            this.label7.Text = "従業員コード";
            // 
            // endKana_tEdit
            // 
            this.endKana_tEdit.ActiveAppearance = appearance17;
            this.endKana_tEdit.AutoSelect = true;
            this.endKana_tEdit.DataText = "";
            this.endKana_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endKana_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.endKana_tEdit.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.endKana_tEdit.Location = new System.Drawing.Point(514, 48);
            this.endKana_tEdit.MaxLength = 12;
            this.endKana_tEdit.Name = "endKana_tEdit";
            this.endKana_tEdit.Size = new System.Drawing.Size(252, 21);
            this.endKana_tEdit.TabIndex = 17;
            // 
            // startKana_tEdit
            // 
            this.startKana_tEdit.ActiveAppearance = appearance18;
            this.startKana_tEdit.AutoSelect = true;
            this.startKana_tEdit.DataText = "";
            this.startKana_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startKana_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.startKana_tEdit.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.startKana_tEdit.Location = new System.Drawing.Point(514, 28);
            this.startKana_tEdit.MaxLength = 12;
            this.startKana_tEdit.Name = "startKana_tEdit";
            this.startKana_tEdit.Size = new System.Drawing.Size(252, 21);
            this.startKana_tEdit.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 12);
            this.label6.TabIndex = 100;
            this.label6.Text = "得意先カナ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 99;
            this.label5.Text = "企業コード";
            // 
            // endAddUpYearMonth_tNedit
            // 
            this.endAddUpYearMonth_tNedit.ActiveAppearance = appearance19;
            this.endAddUpYearMonth_tNedit.AutoSelect = true;
            this.endAddUpYearMonth_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endAddUpYearMonth_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endAddUpYearMonth_tNedit.DataText = "200508";
            this.endAddUpYearMonth_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endAddUpYearMonth_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endAddUpYearMonth_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endAddUpYearMonth_tNedit.Location = new System.Drawing.Point(278, 100);
            this.endAddUpYearMonth_tNedit.MaxLength = 12;
            this.endAddUpYearMonth_tNedit.Name = "endAddUpYearMonth_tNedit";
            this.endAddUpYearMonth_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endAddUpYearMonth_tNedit.Size = new System.Drawing.Size(59, 21);
            this.endAddUpYearMonth_tNedit.TabIndex = 10;
            this.endAddUpYearMonth_tNedit.Text = "200508";
            // 
            // startAddUpYearMonth_tNedit
            // 
            this.startAddUpYearMonth_tNedit.ActiveAppearance = appearance20;
            this.startAddUpYearMonth_tNedit.AutoSelect = true;
            this.startAddUpYearMonth_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startAddUpYearMonth_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startAddUpYearMonth_tNedit.DataText = "200505";
            this.startAddUpYearMonth_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startAddUpYearMonth_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startAddUpYearMonth_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startAddUpYearMonth_tNedit.Location = new System.Drawing.Point(218, 100);
            this.startAddUpYearMonth_tNedit.MaxLength = 12;
            this.startAddUpYearMonth_tNedit.Name = "startAddUpYearMonth_tNedit";
            this.startAddUpYearMonth_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startAddUpYearMonth_tNedit.Size = new System.Drawing.Size(59, 21);
            this.startAddUpYearMonth_tNedit.TabIndex = 9;
            this.startAddUpYearMonth_tNedit.Text = "200505";
            // 
            // endCustomerCode_tNedit
            // 
            this.endCustomerCode_tNedit.ActiveAppearance = appearance21;
            this.endCustomerCode_tNedit.AutoSelect = true;
            this.endCustomerCode_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.endCustomerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.endCustomerCode_tNedit.DataText = "999999999";
            this.endCustomerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.endCustomerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.endCustomerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.endCustomerCode_tNedit.Location = new System.Drawing.Point(582, 4);
            this.endCustomerCode_tNedit.MaxLength = 12;
            this.endCustomerCode_tNedit.Name = "endCustomerCode_tNedit";
            this.endCustomerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.endCustomerCode_tNedit.Size = new System.Drawing.Size(66, 21);
            this.endCustomerCode_tNedit.TabIndex = 15;
            this.endCustomerCode_tNedit.Text = "999999999";
            // 
            // startCustomerCode_tNedit
            // 
            this.startCustomerCode_tNedit.ActiveAppearance = appearance22;
            this.startCustomerCode_tNedit.AutoSelect = true;
            this.startCustomerCode_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startCustomerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startCustomerCode_tNedit.DataText = "";
            this.startCustomerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startCustomerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startCustomerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startCustomerCode_tNedit.Location = new System.Drawing.Point(514, 4);
            this.startCustomerCode_tNedit.MaxLength = 12;
            this.startCustomerCode_tNedit.Name = "startCustomerCode_tNedit";
            this.startCustomerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startCustomerCode_tNedit.Size = new System.Drawing.Size(66, 21);
            this.startCustomerCode_tNedit.TabIndex = 14;
            // 
            // startTotalDay_tNedit
            // 
            this.startTotalDay_tNedit.ActiveAppearance = appearance23;
            this.startTotalDay_tNedit.AutoSelect = true;
            this.startTotalDay_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.startTotalDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.startTotalDay_tNedit.DataText = "20";
            this.startTotalDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.startTotalDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.startTotalDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.startTotalDay_tNedit.Location = new System.Drawing.Point(218, 28);
            this.startTotalDay_tNedit.MaxLength = 12;
            this.startTotalDay_tNedit.Name = "startTotalDay_tNedit";
            this.startTotalDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.startTotalDay_tNedit.Size = new System.Drawing.Size(35, 21);
            this.startTotalDay_tNedit.TabIndex = 5;
            this.startTotalDay_tNedit.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 98;
            this.label4.Text = "締日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 97;
            this.label3.Text = "計上年月日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 96;
            this.label2.Text = "計上年月";
            // 
            // enterpriseCode_textBox
            // 
            this.enterpriseCode_textBox.Location = new System.Drawing.Point(61, 4);
            this.enterpriseCode_textBox.Name = "enterpriseCode_textBox";
            this.enterpriseCode_textBox.Size = new System.Drawing.Size(111, 19);
            this.enterpriseCode_textBox.TabIndex = 0;
            this.enterpriseCode_textBox.Text = "0113180842031000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 81;
            this.label1.Text = "得意先コード";
            // 
            // selectSearch_ultraOptionSet
            // 
            this.selectSearch_ultraOptionSet.ItemAppearance = appearance24;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "元帳";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "一覧表";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "明細取得";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "元帳一括";
            this.selectSearch_ultraOptionSet.Items.Add(valueListItem1);
            this.selectSearch_ultraOptionSet.Items.Add(valueListItem2);
            this.selectSearch_ultraOptionSet.Items.Add(valueListItem3);
            this.selectSearch_ultraOptionSet.Items.Add(valueListItem4);
            this.selectSearch_ultraOptionSet.Location = new System.Drawing.Point(174, 4);
            this.selectSearch_ultraOptionSet.Name = "selectSearch_ultraOptionSet";
            this.selectSearch_ultraOptionSet.Size = new System.Drawing.Size(250, 20);
            this.selectSearch_ultraOptionSet.TabIndex = 4;
            this.selectSearch_ultraOptionSet.ValueChanged += new System.EventHandler(this.selectSearch_ultraOptionSet_ValueChanged);
            // 
            // allSecCode_checkBox
            // 
            this.allSecCode_checkBox.Location = new System.Drawing.Point(18, 148);
            this.allSecCode_checkBox.Name = "allSecCode_checkBox";
            this.allSecCode_checkBox.Size = new System.Drawing.Size(132, 24);
            this.allSecCode_checkBox.TabIndex = 3;
            this.allSecCode_checkBox.Text = "全拠点レコード出力";
            // 
            // billOutputCodeFlg_checkBox
            // 
            this.billOutputCodeFlg_checkBox.Location = new System.Drawing.Point(239, 124);
            this.billOutputCodeFlg_checkBox.Name = "billOutputCodeFlg_checkBox";
            this.billOutputCodeFlg_checkBox.Size = new System.Drawing.Size(172, 24);
            this.billOutputCodeFlg_checkBox.TabIndex = 12;
            this.billOutputCodeFlg_checkBox.Text = "請求書出力区分を参照する";
            // 
            // corporateDivCode_ultraTree
            // 
            this.corporateDivCode_ultraTree.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.corporateDivCode_ultraTree.HideSelection = false;
            this.corporateDivCode_ultraTree.Indent = 15;
            this.corporateDivCode_ultraTree.Location = new System.Drawing.Point(786, 24);
            this.corporateDivCode_ultraTree.Name = "corporateDivCode_ultraTree";
            ultraTreeNode1.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode1.DataKey = 0;
            ultraTreeNode1.Key = "0";
            ultraTreeNode1.Text = "個人";
            ultraTreeNode2.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode2.DataKey = 1;
            ultraTreeNode2.Key = "1";
            ultraTreeNode2.Text = "法人";
            ultraTreeNode3.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode3.DataKey = 2;
            ultraTreeNode3.Key = "2";
            ultraTreeNode3.Text = "大口法人";
            ultraTreeNode4.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode4.DataKey = 3;
            ultraTreeNode4.Key = "3";
            ultraTreeNode4.Text = "業者";
            ultraTreeNode5.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode5.DataKey = 4;
            ultraTreeNode5.Key = "4";
            ultraTreeNode5.Text = "社員";
            ultraTreeNode6.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode6.DataKey = 5;
            ultraTreeNode6.Key = "5";
            ultraTreeNode6.Text = "AA";
            this.corporateDivCode_ultraTree.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode1,
            ultraTreeNode2,
            ultraTreeNode3,
            ultraTreeNode4,
            ultraTreeNode5,
            ultraTreeNode6});
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.corporateDivCode_ultraTree.Override = _override1;
            this.corporateDivCode_ultraTree.ShowLines = false;
            this.corporateDivCode_ultraTree.Size = new System.Drawing.Size(112, 100);
            this.corporateDivCode_ultraTree.TabIndex = 22;
            // 
            // employeeKind_ultraOptionSet
            // 
            this.employeeKind_ultraOptionSet.CheckedIndex = 0;
            this.employeeKind_ultraOptionSet.ItemAppearance = appearance25;
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "得意先";
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "集金";
            this.employeeKind_ultraOptionSet.Items.Add(valueListItem5);
            this.employeeKind_ultraOptionSet.Items.Add(valueListItem6);
            this.employeeKind_ultraOptionSet.Location = new System.Drawing.Point(654, 72);
            this.employeeKind_ultraOptionSet.Name = "employeeKind_ultraOptionSet";
            this.employeeKind_ultraOptionSet.Size = new System.Drawing.Size(116, 20);
            this.employeeKind_ultraOptionSet.TabIndex = 20;
            this.employeeKind_ultraOptionSet.Text = "得意先";
            // 
            // secCode_ultraTree
            // 
            this.secCode_ultraTree.ColumnSettings.RootColumnSet = ultraTreeColumnSet2;
            this.secCode_ultraTree.HideSelection = false;
            this.secCode_ultraTree.Indent = 15;
            this.secCode_ultraTree.Location = new System.Drawing.Point(18, 80);
            this.secCode_ultraTree.Name = "secCode_ultraTree";
            ultraTreeNode7.CheckedState = System.Windows.Forms.CheckState.Checked;
            ultraTreeNode7.Key = "ALL";
            ultraTreeNode7.Text = "全社";
            ultraTreeNode8.Key = "000001";
            ultraTreeNode8.Text = "000001";
            ultraTreeNode9.Key = "1";
            ultraTreeNode9.Text = "1";
            ultraTreeNode10.Key = "000009";
            ultraTreeNode10.Text = "000009";
            this.secCode_ultraTree.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode7,
            ultraTreeNode8,
            ultraTreeNode9,
            ultraTreeNode10});
            _override2.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            _override2.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.secCode_ultraTree.Override = _override2;
            this.secCode_ultraTree.ShowLines = false;
            this.secCode_ultraTree.Size = new System.Drawing.Size(92, 68);
            this.secCode_ultraTree.TabIndex = 2;
            // 
            // outputZeroBlanceFlg_checkBox
            // 
            this.outputZeroBlanceFlg_checkBox.Location = new System.Drawing.Point(150, 124);
            this.outputZeroBlanceFlg_checkBox.Name = "outputZeroBlanceFlg_checkBox";
            this.outputZeroBlanceFlg_checkBox.Size = new System.Drawing.Size(92, 24);
            this.outputZeroBlanceFlg_checkBox.TabIndex = 11;
            this.outputZeroBlanceFlg_checkBox.Text = "残高０出力";
            // 
            // selectDateType_ultraOptionSet
            // 
            this.selectDateType_ultraOptionSet.CheckedIndex = 0;
            this.selectDateType_ultraOptionSet.ItemAppearance = appearance26;
            valueListItem7.DataValue = false;
            valueListItem7.DisplayText = "計上年月日";
            valueListItem8.DataValue = true;
            valueListItem8.DisplayText = "計上年月";
            this.selectDateType_ultraOptionSet.Items.Add(valueListItem7);
            this.selectDateType_ultraOptionSet.Items.Add(valueListItem8);
            this.selectDateType_ultraOptionSet.Location = new System.Drawing.Point(193, 151);
            this.selectDateType_ultraOptionSet.Name = "selectDateType_ultraOptionSet";
            this.selectDateType_ultraOptionSet.Size = new System.Drawing.Size(156, 21);
            this.selectDateType_ultraOptionSet.TabIndex = 13;
            this.selectDateType_ultraOptionSet.Text = "計上年月日";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(18, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 95;
            this.label8.Text = "拠点指定";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endAddUpDate_tDateEdit
            // 
            this.endAddUpDate_tDateEdit.ActiveEditAppearance = appearance27;
            this.endAddUpDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.endAddUpDate_tDateEdit.CalendarDisp = true;
            this.endAddUpDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
            appearance28.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance28.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.endAddUpDate_tDateEdit.EditAppearance = appearance28;
            this.endAddUpDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.endAddUpDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance29.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance29.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.endAddUpDate_tDateEdit.LabelAppearance = appearance29;
            this.endAddUpDate_tDateEdit.Location = new System.Drawing.Point(218, 76);
            this.endAddUpDate_tDateEdit.Name = "endAddUpDate_tDateEdit";
            this.endAddUpDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.endAddUpDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.endAddUpDate_tDateEdit.Size = new System.Drawing.Size(184, 21);
            this.endAddUpDate_tDateEdit.TabIndex = 8;
            this.endAddUpDate_tDateEdit.TabStop = true;
            // 
            // startAddUpDate_tDateEdit
            // 
            this.startAddUpDate_tDateEdit.ActiveEditAppearance = appearance30;
            this.startAddUpDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.startAddUpDate_tDateEdit.CalendarDisp = true;
            this.startAddUpDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
            appearance31.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance31.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.startAddUpDate_tDateEdit.EditAppearance = appearance31;
            this.startAddUpDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.startAddUpDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance32.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance32.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.startAddUpDate_tDateEdit.LabelAppearance = appearance32;
            this.startAddUpDate_tDateEdit.Location = new System.Drawing.Point(218, 52);
            this.startAddUpDate_tDateEdit.Name = "startAddUpDate_tDateEdit";
            this.startAddUpDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.startAddUpDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.startAddUpDate_tDateEdit.Size = new System.Drawing.Size(184, 21);
            this.startAddUpDate_tDateEdit.TabIndex = 7;
            this.startAddUpDate_tDateEdit.TabStop = true;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(784, 125);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(85, 48);
            this.SearchBtn.TabIndex = 23;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 458);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(984, 4);
            this.splitter1.TabIndex = 75;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 334);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(984, 4);
            this.splitter2.TabIndex = 76;
            this.splitter2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(984, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGrid3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustAnalysCode1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustAnalysCode1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTotalDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addSecCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endEmployeeCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEmployeeCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endKana_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startKana_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endAddUpYearMonth_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAddUpYearMonth_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endCustomerCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startCustomerCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTotalDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectSearch_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corporateDivCode_ultraTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeKind_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secCode_ultraTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectDateType_ultraOptionSet)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Member
		private KingetCustDmdPrcWork _retCustDmdPrcWork = null;

		private ISeiKingetDB _iSeiKingetDB = null;

		private DateTime DT1;// = new DateTime(2004,1,1);
		private DateTime DT2;// = new DateTime(2005,6,1);

		private static string[] _parameter;
		private static System.Windows.Forms.Form _form = null;
		#endregion

		#region Private Const
		private const string TABLENAME1					=	"RESUALT_TBL1";
		private const string TABLENAME2					=	"RESUALT_TBL2";
		private const string TABLENAME3					=	"RESUALT_TBL3";
		
		private const string	COL_CREATEDATETIME			=	"作成日時";
		private const string	COL_UPDATEDATETIME			=	"更新日時";
		private const string	COL_ENTERPRISECODE			=	"企業コード";
		private const string	COL_FILEHEADERGUID			=	"GUID";
		private const string	COL_UPDEMPLOYEECODE			=	"更新従業員コード";
		private const string	COL_UPDASSEMBLYID1			=	"更新アセンブリID1";
		private const string	COL_UPDASSEMBLYID2			=	"更新アセンブリID2";
		private const string	COL_LOGICALDELETECODE		=	"論理削除区分";
		private const string	COL_ADDUPSECCODE			=	"計上拠点コード";
		private const string	COL_CUSTOMERCODE			=	"得意先コード";
		private const string	COL_ADDUPDATE				=	"計上年月日";
		private const string	COL_ADDUPYEARMONTH			=	"計上年月";
		private const string	COL_TLEDMDSLIPLGCT			=	"台数法定（黒伝請求計）";
		private const string	COL_TLEDMDSLIPGECT			=	"台数一般（黒伝請求計）";
		private const string	COL_TLEDMDDEBITNOTELGCT		=	"台数法定（赤伝請求計）";
		private const string	COL_TLEDMDDEBITNOTEGECT		=	"台数一般（赤伝請求計）";
		private const string	COL_TLEDMDSLIPLGCNT			=	"枚数法定（黒伝請求計）";
		private const string	COL_TLEDMDSLIPGECNT			=	"枚数一般（黒伝請求計）";
		private const string	COL_TLEDMDDEBITNOTELGCNT	=	"枚数法定（赤伝請求計）";
		private const string	COL_TLEDMDDEBITNOTEGECNT	=	"枚数一般（赤伝請求計）";
		private const string	COL_ACPODRTTLSALESDMD		=	"受注売上額（請求計）";
		private const string	COL_ACPODRDISCTTLDMD		=	"受注値引額（請求計）";
		private const string	COL_ACPODRTTLCONSTAXDMD		=	"受注消費税額（請求計）";
		private const string	COL_DMDVARCST				=	"諸費用金額（請求計）";
		private const string	COL_TTLTAXTINDMDVARCST		=	"諸費用課税計（請求計）";
		private const string	COL_TTLTAXFREEDMDVARCST		=	"諸費用非課税計（請求計）";
		private const string	COL_VARCST1TOTALDEMAND		=	"諸費用額1（請求計）";
		private const string	COL_VARCST2TOTALDEMAND		=	"諸費用額2（請求計）";
		private const string	COL_VARCST3TOTALDEMAND		=	"諸費用額3（請求計）";
		private const string	COL_VARCST4TOTALDEMAND		=	"諸費用額4（請求計）";
		private const string	COL_VARCST5TOTALDEMAND		=	"諸費用額5（請求計）";
		private const string	COL_VARCST6TOTALDEMAND		=	"諸費用額6（請求計）";
		private const string	COL_VARCST7TOTALDEMAND		=	"諸費用額7（請求計）";
		private const string	COL_VARCST8TOTALDEMAND		=	"諸費用額8（請求計）";
		private const string	COL_VARCST9TOTALDEMAND		=	"諸費用額9（請求計）";
		private const string	COL_VARCST10TOTALDEMAND		=	"諸費用額10（請求計）";
		private const string	COL_VARCST11TOTALDEMAND		=	"諸費用額11（請求計）";
		private const string	COL_VARCST12TOTALDEMAND		=	"諸費用額12（請求計）";
		private const string	COL_VARCST13TOTALDEMAND		=	"諸費用額13（請求計）";
		private const string	COL_VARCST14TOTALDEMAND		=	"諸費用額14（請求計）";
		private const string	COL_VARCST15TOTALDEMAND		=	"諸費用額15（請求計）";
		private const string	COL_VARCST16TOTALDEMAND		=	"諸費用額16（請求計）";
		private const string	COL_VARCST17TOTALDEMAND		=	"諸費用額17（請求計）";
		private const string	COL_VARCST18TOTALDEMAND		=	"諸費用額18（請求計）";
		private const string	COL_VARCST19TOTALDEMAND		=	"諸費用額19（請求計）";
		private const string	COL_VARCST20TOTALDEMAND		=	"諸費用額20（請求計）";
		private const string	COL_TTLDMDVARCSTCONSTAX		=	"諸費用消費税額（請求計）";
		private const string	COL_ACPODRTTLLMBLDMD		=	"受注前月残高（請求計）";
		private const string	COL_TTLLMVARCSTDMDBLNCE		=	"諸費用前月残高（請求計）";
		private const string	COL_BFCALTTLAODRDEPODMD		=	"計算前受注入金額（請求計）";
		private const string	COL_BFCALTTLAODRDPDSDMD		=	"計算前受注入金値引額（請求計）";
		private const string	COL_BFCALTTLAODRDPDMD		=	"計算前受注預り金（請求計）";
		private const string	COL_BFCALTTLAODRDSDMD		=	"計算前受注預り金値引額（請求計）";
		private const string	COL_AFCALTTLAODRDEPODMD		=	"計算後受注入金額（請求計）";
		private const string	COL_AFCALTTLVCSTDEPODMD		=	"計算後諸費用入金額（請求計）";
		private const string	COL_AFCALTTLAODRDPDSDMD		=	"計算後受注入金値引額（請求計）";
		private const string	COL_AFCALTTLVCSTDPDSDMD		=	"計算後諸費用入金値引額（請求計）";
		private const string	COL_AFCALTTLAODRRMDMD		=	"計算後受注前受金（請求計）";
		private const string	COL_AFCALTTLVCSTBFRMDMD		=	"計算後諸費用前受金（請求計）";
		private const string	COL_AFCALTTLAODRRMDSDMD		=	"計算後受注前受金値引額（請求計）";
		private const string	COL_AFCALTTLVCSTRMDSDMD		=	"計算後諸費用前受金値引額（請求計）";
		private const string	COL_AFCALTTLAODRBLCFDMD		=	"計算後受注繰越残高（請求計）";
		private const string	COL_AFCALTTLVCSTBLCFDMD		=	"計算後諸費用繰越残高（請求計）";
		private const string	COL_AFCALTTLAODRBLDMD		=	"計算後受注合計残高（請求計）";
		private const string	COL_AFCALTTLVCSTBLDMD		=	"計算後諸費用合計残高（請求計）";
		private const string	COL_AFCALDEMANDPRICE		=	"計算後請求金額";
		private const string	COL_ACPODRTTL2TMBFBLDMD		=	"受注2回前残高（請求計）";
		private const string	COL_TTL2TMBFVARCSTDMDBL		=	"諸費用2回前残高（請求計）";
		private const string	COL_ACPODRTTL3TMBFBLDMD		=	"受注3回前残高（請求計）";
		private const string	COL_TTL3TMBFVARCSTDMDBL		=	"諸費用3回前残高（請求計）";
		private const string	COL_ADDUPDATELASTRECFLG		=	"計上最終レコードフラグ";
		private const string	COL_NAME					=	"名称";
		private const string	COL_NAME2					=	"名称２";
		private const string	COL_HONORIFICTITLE			=	"敬称";
		private const string	COL_KANA					=	"カナ";
		private const string	COL_OUTPUTNAMECODE			=	"諸口コード";
		private const string	COL_OUTPUTNAME				=	"諸口名称";
		private const string	COL_CORPORATEDIVCODE		=	"個人・法人区分";
		private const string	COL_POSTNO					=	"郵便番号";
		private const string	COL_ADDRESS1				=	"住所１（都道府県市区郡・町村・字）";
		private const string	COL_ADDRESS2				=	"住所２（丁目）";
		private const string	COL_ADDRESS3				=	"住所３（番地）";
		private const string	COL_ADDRESS4				=	"住所４（アパート名称）";
		private const string	COL_HOMETELNO				=	"電話番号（自宅）";
		private const string	COL_OFFICETELNO				=	"電話番号（勤務先）";
		private const string	COL_PORTABLETELNO			=	"電話番号（携帯）";
		private const string	COL_HOMEFAXNO				=	"FAX番号（自宅）";
		private const string	COL_OFFICEFAXNO				=	"FAX番号（勤務先）";
		private const string	COL_OTHERSTELNO				=	"電話番号（その他）";
		private const string	COL_MAINCONTACTCODE			=	"主連絡先区分";
		private const string	COL_CUSTANALYSCODE1			=	"分析コード1";
		private const string	COL_CUSTANALYSCODE2			=	"分析コード2";
		private const string	COL_CUSTANALYSCODE3			=	"分析コード3";
		private const string	COL_CUSTANALYSCODE4			=	"分析コード4";
		private const string	COL_CUSTANALYSCODE5			=	"分析コード5";
		private const string	COL_CUSTANALYSCODE6			=	"分析コード6";
		private const string	COL_TOTALDAY				=	"締日";
		private const string	COL_COLLECTMONEYNAME		=	"集金月区分名称";
		private const string	COL_COLLECTMONEYDAY			=	"集金日";
		private const string	COL_CUSTOMERAGENTCD			=	"顧客担当従業員コード";
		private const string	COL_CUSTOMERAGENTNM			=	"顧客担当従業員名称";
		private const string	COL_BILLCOLLECTERCD			=	"集金担当従業員コード";
		private const string	COL_BILLCOLLECTERNM			=	"集金担当従業員名称";
		private const string	COL_STARTDATESPAN			=	"日付範囲（開始）";
		private const string	COL_ENDDATESPAN				=	"日付範囲（終了）";

//		private const string	COL_CREATEDATETIME			=	"作成日時";
//		private const string	COL_UPDATEDATETIME			=	"更新日時";
//		private const string	COL_ENTERPRISECODE			=	"企業コード";
//		private const string	COL_FILEHEADERGUID			=	"GUID";
//		private const string	COL_UPDEMPLOYEECODE			=	"更新従業員コード";
//		private const string	COL_UPDASSEMBLYID1			=	"更新アセンブリID1";
//		private const string	COL_UPDASSEMBLYID2			=	"更新アセンブリID2";
//		private const string	COL_LOGICALDELETECODE		=	"論理削除区分";
		private const string	COL_ACCEPTANORDERNO			=	"受注番号";
		private const string	COL_SLIPNO					=	"伝票番号";
		private const string	COL_DEBITNOTEDIV			=	"赤伝区分";
//		private const string	COL_CUSTOMERCODE			=	"得意先コード";
		private const string	COL_CARMNGNO				=	"車両管理番号";
		private const string	COL_CLAIMCODE				=	"請求先コード";
		private const string	COL_ADDUPADATE				=	"計上日付";
		private const string	COL_ACCEPTANORDERSALES		=	"受注売上計";
		private const string	COL_ACPTANODRDISCOUNTTTL	=	"受注値引計";
		private const string	COL_ACCEPTANORDERCONSTAX	=	"受注消費税額";
		private const string	COL_TOTALVARIOUSCOST		=	"諸費用金額計";
		private const string	COL_VARCSTTAXTOTAL			=	"諸費用課税計";
		private const string	COL_VARCSTTAXFREETOTAL		=	"諸費用非課税計";
		private const string	COL_VARCST1					=	"諸費用金額1";
		private const string	COL_VARCST2					=	"諸費用金額2";
		private const string	COL_VARCST3					=	"諸費用金額3";
		private const string	COL_VARCST4					=	"諸費用金額4";
		private const string	COL_VARCST5					=	"諸費用金額5";
		private const string	COL_VARCST6					=	"諸費用金額6";
		private const string	COL_VARCST7					=	"諸費用金額7";
		private const string	COL_VARCST8					=	"諸費用金額8";
		private const string	COL_VARCST9					=	"諸費用金額9";
		private const string	COL_VARCST10				=	"諸費用金額10";
		private const string	COL_VARCST11				=	"諸費用金額11";
		private const string	COL_VARCST12				=	"諸費用金額12";
		private const string	COL_VARCST13				=	"諸費用金額13";
		private const string	COL_VARCST14				=	"諸費用金額14";
		private const string	COL_VARCST15				=	"諸費用金額15";
		private const string	COL_VARCST16				=	"諸費用金額16";
		private const string	COL_VARCST17				=	"諸費用金額17";
		private const string	COL_VARCST18				=	"諸費用金額18";
		private const string	COL_VARCST19				=	"諸費用金額19";
		private const string	COL_VARCST20				=	"諸費用金額20";
		private const string	COL_VARCSTDIV1				=	"諸費用区分1";
		private const string	COL_VARCSTDIV2				=	"諸費用区分2";
		private const string	COL_VARCSTDIV3				=	"諸費用区分3";
		private const string	COL_VARCSTDIV4				=	"諸費用区分4";
		private const string	COL_VARCSTDIV5				=	"諸費用区分5";
		private const string	COL_VARCSTDIV6				=	"諸費用区分6";
		private const string	COL_VARCSTDIV7				=	"諸費用区分7";
		private const string	COL_VARCSTDIV8				=	"諸費用区分8";
		private const string	COL_VARCSTDIV9				=	"諸費用区分9";
		private const string	COL_VARCSTDIV10				=	"諸費用区分10";
		private const string	COL_VARCSTDIV11				=	"諸費用区分11";
		private const string	COL_VARCSTDIV12				=	"諸費用区分12";
		private const string	COL_VARCSTDIV13				=	"諸費用区分13";
		private const string	COL_VARCSTDIV14				=	"諸費用区分14";
		private const string	COL_VARCSTDIV15				=	"諸費用区分15";
		private const string	COL_VARCSTDIV16				=	"諸費用区分16";
		private const string	COL_VARCSTDIV17				=	"諸費用区分17";
		private const string	COL_VARCSTDIV18				=	"諸費用区分18";
		private const string	COL_VARCSTDIV19				=	"諸費用区分19";
		private const string	COL_VARCSTDIV20				=	"諸費用区分20";
		private const string	COL_VARCSTCONSTAX			=	"諸費用消費税額";
		private const string	COL_DEPOSITALLOWANCE		=	"入金引当額";
		private const string	COL_DEPOSITALWCBLNCE		=	"入金引当残高";
		private const string	COL_DATAINPUTSYSTEM			=	"データ入力システム";
		private const string	COL_DEMANDADDUPSECCD		=	"請求計上拠点コード";
		private const string	COL_RESULTSADDUPSECCD		=	"実績計上拠点コード";
		private const string	COL_UPDATESECCD				=	"更新拠点コード";
		private const string	COL_ACCEPTANORDERDATE		=	"受注日";
		private const string	COL_CARDELIEXPECTEDDATE		=	"納車予定日";
		private const string	COL_SALESEMPLOYEECD			=	"販売従業員コード";
		private const string	COL_SALESDIV				=	"売上区分";
		private const string	COL_SALESNAME				=	"売上名称";
		private const string	COL_DEBITNLNKACPTANODR		=	"赤黒連結受注番号";
		private const string	COL_DEMANDPRORATACD			=	"請求按分区分";
		private const string	COL_LASTRECONCILEDATE		=	"最終消込み日";
		private const string	COL_NUMBERPLATE1CODE		=	"陸運事務所番号";
		private const string	COL_NUMBERPLATE1NAME		=	"陸運事務局名称";
		private const string	COL_NUMBERPLATE2			=	"車両登録番号（種別）";
		private const string	COL_NUMBERPLATE3			=	"車両登録番号（カナ）";
		private const string	COL_NUMBERPLATE4			=	"車両登録番号（プレート番号）";
		private const string	COL_MAKERNAME				=	"メーカー名称";
		private const string	COL_MODELNAME				=	"車種名";
		private const string	COL_DEMANDABLESALESNOTE		=	"請求売上備考";
		private const string	COL_CREDITORLOANCD			=	"クレジット／ローン区分";
		private const string	COL_CREDITCOMPANYCODE		=	"クレジット会社コード";
		private const string	COL_CREDITSALES				=	"クレジット売上額";
		private const string	COL_CREDITALLOWANCE			=	"クレジット引当額";
		private const string	COL_CREDITALWCBLNCE			=	"クレジット引当残高";
//		private const string	COL_CORPORATEDIVCODE		=	"個人・法人区分";
		private const string	COL_AACOUNT					=	"AA回数";
		private const string	COL_MNYONDEPOALLOWANCE		=	"預り金引当額";
		private const string	COL_ACPTANODRSTATUS			=	"受注ステータス";
		private const string	COL_LASTRECONCILEADDUPDT	=	"最終消し込み計上日";
		private const string	COL_CARINSPECTORGECD		=	"車検・一般区分";
		private const string	COL_GRADENAME				=	"グレード名称";
		private const string	COL_ACPODRDEPOSITALWC		=	"受注入金引当額";
		private const string	COL_ACPODRDEPOALWCBLNCE		=	"受注入金引当残高";
		private const string	COL_VARCOSTDEPOALWC			=	"諸費用入金引当額";
		private const string	COL_VARCOSTDEPOALWCBLNCE	=	"諸費用入金引当残高";
		
//		private const string	COL_CREATEDATETIME			=	"作成日時";
//		private const string	COL_UPDATEDATETIME			=	"更新日時";
//		private const string	COL_ENTERPRISECODE			=	"企業コード";
//		private const string	COL_FILEHEADERGUID			=	"GUID";
//		private const string	COL_UPDEMPLOYEECODE			=	"更新従業員コード";
//		private const string	COL_UPDASSEMBLYID1			=	"更新アセンブリID1";
//		private const string	COL_UPDASSEMBLYID2			=	"更新アセンブリID2";
//		private const string	COL_LOGICALDELETECODE		=	"論理削除区分";
		private const string	COL_DEPOSITDEBITNOTECD		=	"入金赤黒区分";
		private const string	COL_DEPOSITSLIPNO			=	"入金伝票番号";
		private const string	COL_DEPOSITKINDCODE			=	"入金金種コード";
//		private const string	COL_CUSTOMERCODE			=	"得意先コード";
		private const string	COL_DEPOSITCD				=	"預り金区分";
		private const string	COL_DEPOSITTOTAL			=	"入金計";
		private const string	COL_OUTLINE					=	"伝票摘要";
		private const string	COL_ACCEPTANORDERSALESNO	=	"売上受注番号";
		private const string	COL_INPUTDEPOSITSECCD		=	"入金入力拠点コード";
		private const string	COL_DEPOSITDATE				=	"入金日付";
//		private const string	COL_ADDUPSECCODE			=	"計上拠点コード";
//		private const string	COL_ADDUPADATE				=	"計上日付";
//		private const string	COL_UPDATESECCD				=	"更新拠点コード";
		private const string	COL_DEPOSITKINDNAME			=	"入金金種名称";
//		private const string	COL_DEPOSITALLOWANCE		=	"入金引当額";
//		private const string	COL_DEPOSITALWCBLNCE		=	"入金引当残高";
		private const string	COL_DEPOSITAGENTCODE		=	"入金担当者コード";
		private const string	COL_DEPOSITKINDDIVCD		=	"入金金種区分";
		private const string	COL_FEEDEPOSIT				=	"手数料入金額";
		private const string	COL_DISCOUNTDEPOSIT			=	"値引入金額";
//		private const string	COL_CREDITORLOANCD			=	"クレジット／ローン区分";
//		private const string	COL_CREDITCOMPANYCODE		=	"クレジット会社コード";
		private const string	COL_DEPOSIT					=	"入金金額";
		private const string	COL_DRAFTDRAWINGDATE		=	"手形振出日";
		private const string	COL_DRAFTPAYTIMELIMIT		=	"手形支払期日";
		private const string	COL_DEBITNOTELINKDEPONO		=	"赤黒入金連結番号";
//		private const string	COL_LASTRECONCILEADDUPDT	=	"最終消し込み計上日";
		private const string	COL_AUTODEPOSITCD			=	"自動入金区分";
		private const string	COL_ACPODRDEPOSIT			=	"受注入金金額";
		private const string	COL_ACPODRCHARGEDEPOSIT		=	"受注手数料入金額";
		private const string	COL_ACPODRDISDEPOSIT		=	"受注値引入金額";
		private const string	COL_VARIOUSCOSTDEPOSIT		=	"諸費用入金金額";
		private const string	COL_VARCOSTCHARGEDEPOSIT	=	"諸費用手数料入金額";
		private const string	COL_VARCOSTDISDEPOSIT		=	"諸費用値引入金額";
		//private const string	COL_ACPODRDEPOSITALWC		=	"受注入金引当額";
		//private const string	COL_ACPODRDEPOALWCBLNCE		=	"受注入金引当残高";
		//private const string	COL_VARCOSTDEPOALWC			=	"諸費用入金引当額";
		//private const string	COL_VARCOSTDEPOALWCBLNCE	=	"諸費用入金引当残高";
		#endregion

		#region Entry Point
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(String[] args) 
		{
			try
			{
				string msg = "";
				_parameter = args;
				//アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
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

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
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
		#endregion

		#region Private Method

		#region DataSet Create
		private void DataSetColumnSet1(ref DataSet dataSet)
		{
			DataTable dt = new DataTable(TABLENAME1);

			dt.Columns.Add(COL_CREATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_UPDATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_ENTERPRISECODE		,	typeof(string));
			dt.Columns.Add(COL_FILEHEADERGUID		,	typeof(Guid));
			dt.Columns.Add(COL_UPDEMPLOYEECODE		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID1		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID2		,	typeof(string));
			dt.Columns.Add(COL_LOGICALDELETECODE	,	typeof(string));
			dt.Columns.Add(COL_ADDUPSECCODE			,	typeof(string));
			dt.Columns.Add(COL_CUSTOMERCODE			,	typeof(string));
			dt.Columns.Add(COL_ADDUPDATE			,	typeof(string));
			dt.Columns.Add(COL_ADDUPYEARMONTH		,	typeof(string));
			dt.Columns.Add(COL_TLEDMDSLIPLGCT		,	typeof(string));
			dt.Columns.Add(COL_TLEDMDSLIPGECT		,	typeof(string));
			dt.Columns.Add(COL_TLEDMDDEBITNOTELGCT	,	typeof(string));
			dt.Columns.Add(COL_TLEDMDDEBITNOTEGECT	,	typeof(string));
			dt.Columns.Add(COL_TLEDMDSLIPLGCNT		,	typeof(string));
			dt.Columns.Add(COL_TLEDMDSLIPGECNT		,	typeof(string));
			dt.Columns.Add(COL_TLEDMDDEBITNOTELGCNT	,	typeof(string));
			dt.Columns.Add(COL_TLEDMDDEBITNOTEGECNT	,	typeof(string));
			dt.Columns.Add(COL_ACPODRTTLSALESDMD	,	typeof(string));
			dt.Columns.Add(COL_ACPODRDISCTTLDMD		,	typeof(string));
			dt.Columns.Add(COL_ACPODRTTLCONSTAXDMD	,	typeof(string));
			dt.Columns.Add(COL_DMDVARCST			,	typeof(string));
			dt.Columns.Add(COL_TTLTAXTINDMDVARCST	,	typeof(string));
			dt.Columns.Add(COL_TTLTAXFREEDMDVARCST	,	typeof(string));
			dt.Columns.Add(COL_VARCST1TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST2TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST3TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST4TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST5TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST6TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST7TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST8TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST9TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST10TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST11TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST12TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST13TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST14TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST15TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST16TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST17TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST18TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST19TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_VARCST20TOTALDEMAND	,	typeof(string));
			dt.Columns.Add(COL_TTLDMDVARCSTCONSTAX	,	typeof(string));
			dt.Columns.Add(COL_ACPODRTTLLMBLDMD		,	typeof(string));
			dt.Columns.Add(COL_TTLLMVARCSTDMDBLNCE	,	typeof(string));
			dt.Columns.Add(COL_BFCALTTLAODRDEPODMD	,	typeof(string));
			dt.Columns.Add(COL_BFCALTTLAODRDPDSDMD	,	typeof(string));
			dt.Columns.Add(COL_BFCALTTLAODRDPDMD	,	typeof(string));
			dt.Columns.Add(COL_BFCALTTLAODRDSDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRDEPODMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTDEPODMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRDPDSDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTDPDSDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRRMDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTBFRMDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRRMDSDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTRMDSDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRBLCFDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTBLCFDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLAODRBLDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALTTLVCSTBLDMD	,	typeof(string));
			dt.Columns.Add(COL_AFCALDEMANDPRICE		,	typeof(string));
			dt.Columns.Add(COL_ACPODRTTL2TMBFBLDMD	,	typeof(string));
			dt.Columns.Add(COL_TTL2TMBFVARCSTDMDBL	,	typeof(string));
			dt.Columns.Add(COL_ACPODRTTL3TMBFBLDMD	,	typeof(string));
			dt.Columns.Add(COL_TTL3TMBFVARCSTDMDBL	,	typeof(string));
			dt.Columns.Add(COL_ADDUPDATELASTRECFLG	,	typeof(string));
			dt.Columns.Add(COL_NAME					,	typeof(string));
			dt.Columns.Add(COL_NAME2				,	typeof(string));
			dt.Columns.Add(COL_HONORIFICTITLE		,	typeof(string));
			dt.Columns.Add(COL_KANA					,	typeof(string));
			dt.Columns.Add(COL_OUTPUTNAMECODE		,	typeof(string));
			dt.Columns.Add(COL_OUTPUTNAME			,	typeof(string));
			dt.Columns.Add(COL_CORPORATEDIVCODE		,	typeof(string));
			dt.Columns.Add(COL_POSTNO				,	typeof(string));
			dt.Columns.Add(COL_ADDRESS1				,	typeof(string));
			dt.Columns.Add(COL_ADDRESS2				,	typeof(string));
			dt.Columns.Add(COL_ADDRESS3				,	typeof(string));
			dt.Columns.Add(COL_ADDRESS4				,	typeof(string));
			dt.Columns.Add(COL_HOMETELNO			,	typeof(string));
			dt.Columns.Add(COL_OFFICETELNO			,	typeof(string));
			dt.Columns.Add(COL_PORTABLETELNO		,	typeof(string));
			dt.Columns.Add(COL_HOMEFAXNO			,	typeof(string));
			dt.Columns.Add(COL_OFFICEFAXNO			,	typeof(string));
			dt.Columns.Add(COL_OTHERSTELNO			,	typeof(string));
			dt.Columns.Add(COL_MAINCONTACTCODE		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE1		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE2		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE3		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE4		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE5		,	typeof(string));
			dt.Columns.Add(COL_CUSTANALYSCODE6		,	typeof(string));
			dt.Columns.Add(COL_TOTALDAY				,	typeof(string));
			dt.Columns.Add(COL_COLLECTMONEYNAME		,	typeof(string));
			dt.Columns.Add(COL_COLLECTMONEYDAY		,	typeof(string));
			dt.Columns.Add(COL_CUSTOMERAGENTCD		,	typeof(string));
			dt.Columns.Add(COL_CUSTOMERAGENTNM		,	typeof(string));
			dt.Columns.Add(COL_BILLCOLLECTERCD		,	typeof(string));
			dt.Columns.Add(COL_BILLCOLLECTERNM		,	typeof(string));
			dt.Columns.Add(COL_STARTDATESPAN		,	typeof(string));
			dt.Columns.Add(COL_ENDDATESPAN			,	typeof(string));
			
			dataSet.Tables.Add(dt);
		}

		private void DataSetColumnSet2(ref DataSet dataSet)
		{
			DataTable dt = new DataTable(TABLENAME2);

			dt.Columns.Add(COL_CREATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_UPDATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_ENTERPRISECODE		,	typeof(string));
			dt.Columns.Add(COL_FILEHEADERGUID		,	typeof(Guid));
			dt.Columns.Add(COL_UPDEMPLOYEECODE		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID1		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID2		,	typeof(string));
			dt.Columns.Add(COL_LOGICALDELETECODE	,	typeof(string));
			dt.Columns.Add(COL_ACCEPTANORDERNO		,	typeof(string));
			dt.Columns.Add(COL_SLIPNO				,	typeof(string));
			dt.Columns.Add(COL_DEBITNOTEDIV			,	typeof(string));
			dt.Columns.Add(COL_CUSTOMERCODE			,	typeof(string));
			dt.Columns.Add(COL_CARMNGNO				,	typeof(string));
			dt.Columns.Add(COL_CLAIMCODE			,	typeof(string));
			dt.Columns.Add(COL_ADDUPADATE			,	typeof(string));
			dt.Columns.Add(COL_ACCEPTANORDERSALES	,	typeof(string));
			dt.Columns.Add(COL_ACCEPTANORDERCONSTAX	,	typeof(string));
			dt.Columns.Add(COL_TOTALVARIOUSCOST		,	typeof(string));
			dt.Columns.Add(COL_VARCSTTAXTOTAL		,	typeof(string));
			dt.Columns.Add(COL_VARCSTTAXFREETOTAL	,	typeof(string));
			dt.Columns.Add(COL_VARCST1				,	typeof(string));
			dt.Columns.Add(COL_VARCST2				,	typeof(string));
			dt.Columns.Add(COL_VARCST3				,	typeof(string));
			dt.Columns.Add(COL_VARCST4				,	typeof(string));
			dt.Columns.Add(COL_VARCST5				,	typeof(string));
			dt.Columns.Add(COL_VARCST6				,	typeof(string));
			dt.Columns.Add(COL_VARCST7				,	typeof(string));
			dt.Columns.Add(COL_VARCST8				,	typeof(string));
			dt.Columns.Add(COL_VARCST9				,	typeof(string));
			dt.Columns.Add(COL_VARCST10				,	typeof(string));
			dt.Columns.Add(COL_VARCST11				,	typeof(string));
			dt.Columns.Add(COL_VARCST12				,	typeof(string));
			dt.Columns.Add(COL_VARCST13				,	typeof(string));
			dt.Columns.Add(COL_VARCST14				,	typeof(string));
			dt.Columns.Add(COL_VARCST15				,	typeof(string));
			dt.Columns.Add(COL_VARCST16				,	typeof(string));
			dt.Columns.Add(COL_VARCST17				,	typeof(string));
			dt.Columns.Add(COL_VARCST18				,	typeof(string));
			dt.Columns.Add(COL_VARCST19				,	typeof(string));
			dt.Columns.Add(COL_VARCST20				,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV1			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV2			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV3			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV4			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV5			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV6			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV7			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV8			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV9			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV10			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV11			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV12			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV13			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV14			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV15			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV16			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV17			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV18			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV19			,	typeof(string));
			dt.Columns.Add(COL_VARCSTDIV20			,	typeof(string));
			dt.Columns.Add(COL_VARCSTCONSTAX		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITALLOWANCE		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITALWCBLNCE		,	typeof(string));
			dt.Columns.Add(COL_DATAINPUTSYSTEM		,	typeof(string));
			dt.Columns.Add(COL_DEMANDADDUPSECCD		,	typeof(string));
			dt.Columns.Add(COL_RESULTSADDUPSECCD	,	typeof(string));
			dt.Columns.Add(COL_UPDATESECCD			,	typeof(string));
			dt.Columns.Add(COL_ACCEPTANORDERDATE	,	typeof(string));
			dt.Columns.Add(COL_CARDELIEXPECTEDDATE	,	typeof(string));
			dt.Columns.Add(COL_SALESEMPLOYEECD		,	typeof(string));
			dt.Columns.Add(COL_SALESDIV				,	typeof(string));
			dt.Columns.Add(COL_SALESNAME			,	typeof(string));
			dt.Columns.Add(COL_DEBITNLNKACPTANODR	,	typeof(string));
			dt.Columns.Add(COL_DEMANDPRORATACD		,	typeof(string));
			dt.Columns.Add(COL_LASTRECONCILEDATE	,	typeof(string));
			dt.Columns.Add(COL_NUMBERPLATE1CODE		,	typeof(string));
			dt.Columns.Add(COL_NUMBERPLATE1NAME		,	typeof(string));
			dt.Columns.Add(COL_NUMBERPLATE2			,	typeof(string));
			dt.Columns.Add(COL_NUMBERPLATE3			,	typeof(string));
			dt.Columns.Add(COL_NUMBERPLATE4			,	typeof(string));
			dt.Columns.Add(COL_MAKERNAME			,	typeof(string));
			dt.Columns.Add(COL_MODELNAME			,	typeof(string));
			dt.Columns.Add(COL_DEMANDABLESALESNOTE	,	typeof(string));
			dt.Columns.Add(COL_CREDITORLOANCD		,	typeof(string));
			dt.Columns.Add(COL_CREDITCOMPANYCODE	,	typeof(string));
			dt.Columns.Add(COL_CREDITSALES			,	typeof(string));
			dt.Columns.Add(COL_CREDITALLOWANCE		,	typeof(string));
			dt.Columns.Add(COL_CREDITALWCBLNCE		,	typeof(string));
			dt.Columns.Add(COL_CORPORATEDIVCODE		,	typeof(string));
			dt.Columns.Add(COL_AACOUNT				,	typeof(string));
			dt.Columns.Add(COL_MNYONDEPOALLOWANCE	,	typeof(string));
			dt.Columns.Add(COL_ACPTANODRSTATUS		,	typeof(string));
			dt.Columns.Add(COL_LASTRECONCILEADDUPDT	,	typeof(string));
			dt.Columns.Add(COL_CARINSPECTORGECD		,	typeof(string));
			dt.Columns.Add(COL_GRADENAME			,	typeof(string));
			dt.Columns.Add(COL_ACPODRDEPOSITALWC	,	typeof(string));
			dt.Columns.Add(COL_ACPODRDEPOALWCBLNCE	,	typeof(string));
			dt.Columns.Add(COL_VARCOSTDEPOALWC		,	typeof(string));
			dt.Columns.Add(COL_VARCOSTDEPOALWCBLNCE	,	typeof(string));
			
			dataSet.Tables.Add(dt);
		}

		private void DataSetColumnSet3(ref DataSet dataSet)
		{
			DataTable dt = new DataTable(TABLENAME3);

			dt.Columns.Add(COL_CREATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_UPDATEDATETIME		,	typeof(string));
			dt.Columns.Add(COL_ENTERPRISECODE		,	typeof(string));
			dt.Columns.Add(COL_FILEHEADERGUID		,	typeof(Guid));
			dt.Columns.Add(COL_UPDEMPLOYEECODE		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID1		,	typeof(string));
			dt.Columns.Add(COL_UPDASSEMBLYID2		,	typeof(string));
			dt.Columns.Add(COL_LOGICALDELETECODE	,	typeof(string));
			dt.Columns.Add(COL_DEPOSITDEBITNOTECD	,	typeof(string));
			dt.Columns.Add(COL_DEPOSITSLIPNO		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITKINDCODE		,	typeof(string));
			dt.Columns.Add(COL_CUSTOMERCODE			,	typeof(string));
			dt.Columns.Add(COL_DEPOSITCD			,	typeof(string));
			dt.Columns.Add(COL_DEPOSITTOTAL			,	typeof(string));
			dt.Columns.Add(COL_OUTLINE				,	typeof(string));
			dt.Columns.Add(COL_ACCEPTANORDERSALESNO	,	typeof(string));
			dt.Columns.Add(COL_INPUTDEPOSITSECCD	,	typeof(string));
			dt.Columns.Add(COL_DEPOSITDATE			,	typeof(string));
			dt.Columns.Add(COL_ADDUPSECCODE			,	typeof(string));
			dt.Columns.Add(COL_ADDUPADATE			,	typeof(string));
			dt.Columns.Add(COL_UPDATESECCD			,	typeof(string));
			dt.Columns.Add(COL_DEPOSITKINDNAME		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITALLOWANCE		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITALWCBLNCE		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITAGENTCODE		,	typeof(string));
			dt.Columns.Add(COL_DEPOSITKINDDIVCD		,	typeof(string));
			dt.Columns.Add(COL_FEEDEPOSIT			,	typeof(string));
			dt.Columns.Add(COL_DISCOUNTDEPOSIT		,	typeof(string));
			dt.Columns.Add(COL_CREDITORLOANCD		,	typeof(string));
			dt.Columns.Add(COL_CREDITCOMPANYCODE	,	typeof(string));
			dt.Columns.Add(COL_DEPOSIT				,	typeof(string));
			dt.Columns.Add(COL_DRAFTDRAWINGDATE		,	typeof(string));
			dt.Columns.Add(COL_DRAFTPAYTIMELIMIT	,	typeof(string));
			dt.Columns.Add(COL_DEBITNOTELINKDEPONO	,	typeof(string));
			dt.Columns.Add(COL_LASTRECONCILEADDUPDT	,	typeof(string));
			dt.Columns.Add(COL_AUTODEPOSITCD		,	typeof(string));
			dt.Columns.Add(COL_ACPODRDEPOSIT		,	typeof(string));
			dt.Columns.Add(COL_ACPODRCHARGEDEPOSIT	,	typeof(string));
			dt.Columns.Add(COL_ACPODRDISDEPOSIT		,	typeof(string));
			dt.Columns.Add(COL_VARIOUSCOSTDEPOSIT	,	typeof(string));
			dt.Columns.Add(COL_VARCOSTCHARGEDEPOSIT	,	typeof(string));
			dt.Columns.Add(COL_VARCOSTDISDEPOSIT	,	typeof(string));
			dt.Columns.Add(COL_ACPODRDEPOSITALWC	,	typeof(string));
			dt.Columns.Add(COL_ACPODRDEPOALWCBLNCE	,	typeof(string));
			dt.Columns.Add(COL_VARCOSTDEPOALWC		,	typeof(string));
			dt.Columns.Add(COL_VARCOSTDEPOALWCBLNCE	,	typeof(string));
			
			dataSet.Tables.Add(dt);
		}
		#endregion

		#region List → DataSet
		private void CopyToDataSetFromArrayList1(ref DataSet dataSet, ArrayList list)
		{			
			dataSet.Tables[TABLENAME1].Rows.Clear();
			foreach (KingetCustDmdPrcWork work in list)
			{
				DataRow dr = dataSet.Tables[TABLENAME1].NewRow();
				
				dr[COL_CREATEDATETIME		] = work.CreateDateTime.ToString();
				dr[COL_UPDATEDATETIME		] = work.UpdateDateTime.ToString();
				dr[COL_ENTERPRISECODE		] = work.EnterpriseCode;
				dr[COL_FILEHEADERGUID		] = work.FileHeaderGuid;
				dr[COL_UPDEMPLOYEECODE		] = work.UpdEmployeeCode;
				dr[COL_UPDASSEMBLYID1		] = work.UpdAssemblyId1;
				dr[COL_UPDASSEMBLYID2		] = work.UpdAssemblyId2;
				dr[COL_LOGICALDELETECODE	] = work.LogicalDeleteCode.ToString();
				dr[COL_ADDUPSECCODE			] = work.AddUpSecCode.ToString();
				dr[COL_CUSTOMERCODE			] = work.CustomerCode.ToString();
				dr[COL_ADDUPDATE			] = work.AddUpDate.ToString();
				dr[COL_ADDUPYEARMONTH		] = work.AddUpYearMonth.ToString();
				//dr[COL_TLEDMDSLIPLGCT		] = work.TleDmdSlipLgCt.ToString();
				//dr[COL_TLEDMDSLIPGECT		] = work.TleDmdSlipGeCt.ToString();
				//dr[COL_TLEDMDDEBITNOTELGCT	] = work.TleDmdDebitNoteLgCt.ToString();
				//dr[COL_TLEDMDDEBITNOTEGECT	] = work.TleDmdDebitNoteGeCt.ToString();
				//dr[COL_TLEDMDSLIPLGCNT		] = work.TleDmdSlipLgCnt.ToString();
				//dr[COL_TLEDMDSLIPGECNT		] = work.TleDmdSlipGeCnt.ToString();
				//dr[COL_TLEDMDDEBITNOTELGCNT	] = work.TleDmdDebitNoteLgCnt.ToString();
				//dr[COL_TLEDMDDEBITNOTEGECNT	] = work.TleDmdDebitNoteGeCnt.ToString();
				//dr[COL_ACPODRTTLSALESDMD	] = work.AcpOdrTtlSalesDmd.ToString();
				//dr[COL_ACPODRDISCTTLDMD		] = work.AcpOdrDiscTtlDmd.ToString();
				//dr[COL_ACPODRTTLCONSTAXDMD	] = work.AcpOdrTtlConsTaxDmd.ToString();
				//dr[COL_DMDVARCST			] = work.DmdVarCst.ToString();
				//dr[COL_TTLTAXTINDMDVARCST	] = work.TtlTaxtinDmdVarCst.ToString();
				//dr[COL_TTLTAXFREEDMDVARCST	] = work.TtlTaxFreeDmdVarCst.ToString();
				//dr[COL_VARCST1TOTALDEMAND	] = work.VarCst1TotalDemand.ToString();
				//dr[COL_VARCST2TOTALDEMAND	] = work.VarCst2TotalDemand.ToString();
				//dr[COL_VARCST3TOTALDEMAND	] = work.VarCst3TotalDemand.ToString();
				//dr[COL_VARCST4TOTALDEMAND	] = work.VarCst4TotalDemand.ToString();
				//dr[COL_VARCST5TOTALDEMAND	] = work.VarCst5TotalDemand.ToString();
				//dr[COL_VARCST6TOTALDEMAND	] = work.VarCst6TotalDemand.ToString();
				//dr[COL_VARCST7TOTALDEMAND	] = work.VarCst7TotalDemand.ToString();
				//dr[COL_VARCST8TOTALDEMAND	] = work.VarCst8TotalDemand.ToString();
				//dr[COL_VARCST9TOTALDEMAND	] = work.VarCst9TotalDemand.ToString();
				//dr[COL_VARCST10TOTALDEMAND	] = work.VarCst10TotalDemand.ToString();
				//dr[COL_VARCST11TOTALDEMAND	] = work.VarCst11TotalDemand.ToString();
				//dr[COL_VARCST12TOTALDEMAND	] = work.VarCst12TotalDemand.ToString();
				//dr[COL_VARCST13TOTALDEMAND	] = work.VarCst13TotalDemand.ToString();
				//dr[COL_VARCST14TOTALDEMAND	] = work.VarCst14TotalDemand.ToString();
				//dr[COL_VARCST15TOTALDEMAND	] = work.VarCst15TotalDemand.ToString();
				//dr[COL_VARCST16TOTALDEMAND	] = work.VarCst16TotalDemand.ToString();
				//dr[COL_VARCST17TOTALDEMAND	] = work.VarCst17TotalDemand.ToString();
				//dr[COL_VARCST18TOTALDEMAND	] = work.VarCst18TotalDemand.ToString();
				//dr[COL_VARCST19TOTALDEMAND	] = work.VarCst19TotalDemand.ToString();
				//dr[COL_VARCST20TOTALDEMAND	] = work.VarCst20TotalDemand.ToString();
				//dr[COL_TTLDMDVARCSTCONSTAX	] = work.TtlDmdVarCstConsTax.ToString();
				//dr[COL_ACPODRTTLLMBLDMD		] = work.AcpOdrTtlLMBlDmd.ToString();
				//dr[COL_TTLLMVARCSTDMDBLNCE	] = work.TtlLMVarCstDmdBlnce.ToString();
				//dr[COL_BFCALTTLAODRDEPODMD	] = work.BfCalTtlAOdrDepoDmd.ToString();
				//dr[COL_BFCALTTLAODRDPDSDMD	] = work.BfCalTtlAOdrDpDsDmd.ToString();
				//dr[COL_BFCALTTLAODRDPDMD	] = work.BfCalTtlAOdrDpDmd.ToString();
				//dr[COL_BFCALTTLAODRDSDMD	] = work.BfCalTtlAOdrDsDmd.ToString();
				//dr[COL_AFCALTTLAODRDEPODMD	] = work.AfCalTtlAOdrDepoDmd.ToString();
				//dr[COL_AFCALTTLVCSTDEPODMD	] = work.AfCalTtlVCstDepoDmd.ToString();
				//dr[COL_AFCALTTLAODRDPDSDMD	] = work.AfCalTtlAOdrDpDsDmd.ToString();
				//dr[COL_AFCALTTLVCSTDPDSDMD	] = work.AfCalTtlVCstDpDsDmd.ToString();
				//dr[COL_AFCALTTLAODRRMDMD	] = work.AfCalTtlAOdrRMDmd.ToString();
				//dr[COL_AFCALTTLVCSTBFRMDMD	] = work.AfCalTtlVCstBfRMDmd.ToString();
				//dr[COL_AFCALTTLAODRRMDSDMD	] = work.AfCalTtlAOdrRMDsDmd.ToString();
				//dr[COL_AFCALTTLVCSTRMDSDMD	] = work.AfCalTtlVCstRMDsDmd.ToString();
				//dr[COL_AFCALTTLAODRBLCFDMD	] = work.AfCalTtlAOdrBlCFDmd.ToString();
				//dr[COL_AFCALTTLVCSTBLCFDMD	] = work.AfCalTtlVCstBlCFDmd.ToString();
				//dr[COL_AFCALTTLAODRBLDMD	] = work.AfCalTtlAOdrBlDmd.ToString();
				//dr[COL_AFCALTTLVCSTBLDMD	] = work.AfCalTtlVCstBlDmd.ToString();
				dr[COL_AFCALDEMANDPRICE		] = work.AfCalDemandPrice.ToString();
				dr[COL_ACPODRTTL2TMBFBLDMD	] = work.AcpOdrTtl2TmBfBlDmd.ToString();
				//dr[COL_TTL2TMBFVARCSTDMDBL	] = work.Ttl2TmBfVarCstDmdBl.ToString();
				dr[COL_ACPODRTTL3TMBFBLDMD	] = work.AcpOdrTtl3TmBfBlDmd.ToString();
				//dr[COL_TTL3TMBFVARCSTDMDBL	] = work.Ttl3TmBfVarCstDmdBl.ToString();
				//dr[COL_ADDUPDATELASTRECFLG	] = work.AddUpDateLastRecFlg.ToString();
				//dr[COL_NAME					] = work.Name.ToString();
				//dr[COL_NAME2				] = work.Name2.ToString();
				dr[COL_HONORIFICTITLE		] = work.HonorificTitle.ToString();
				dr[COL_KANA					] = work.Kana.ToString();
				dr[COL_OUTPUTNAMECODE		] = work.OutputNameCode.ToString();
				dr[COL_OUTPUTNAME			] = work.OutputName.ToString();
				dr[COL_CORPORATEDIVCODE		] = work.CorporateDivCode.ToString();
				dr[COL_POSTNO				] = work.PostNo.ToString();
				dr[COL_ADDRESS1				] = work.Address1.ToString();
				dr[COL_ADDRESS2				] = work.Address2.ToString();
				dr[COL_ADDRESS3				] = work.Address3.ToString();
				dr[COL_ADDRESS4				] = work.Address4.ToString();
				dr[COL_HOMETELNO			] = work.HomeTelNo.ToString();
				dr[COL_OFFICETELNO			] = work.OfficeTelNo.ToString();
				dr[COL_PORTABLETELNO		] = work.PortableTelNo.ToString();
				dr[COL_HOMEFAXNO			] = work.HomeFaxNo.ToString();
				dr[COL_OFFICEFAXNO			] = work.OfficeFaxNo.ToString();
				dr[COL_OTHERSTELNO			] = work.OthersTelNo.ToString();
				dr[COL_MAINCONTACTCODE		] = work.MainContactCode.ToString();
				dr[COL_CUSTANALYSCODE1		] = work.CustAnalysCode1.ToString();
				dr[COL_CUSTANALYSCODE2		] = work.CustAnalysCode2.ToString();
				dr[COL_CUSTANALYSCODE3		] = work.CustAnalysCode3.ToString();
				dr[COL_CUSTANALYSCODE4		] = work.CustAnalysCode4.ToString();
				dr[COL_CUSTANALYSCODE5		] = work.CustAnalysCode5.ToString();
				dr[COL_CUSTANALYSCODE6		] = work.CustAnalysCode6.ToString();
				dr[COL_TOTALDAY				] = work.TotalDay.ToString();
				dr[COL_COLLECTMONEYNAME		] = work.CollectMoneyName.ToString();
				dr[COL_COLLECTMONEYDAY		] = work.CollectMoneyDay.ToString();
				dr[COL_CUSTOMERAGENTCD		] = work.CustomerAgentCd.ToString();
				dr[COL_CUSTOMERAGENTNM		] = work.CustomerAgentNm.ToString();
				dr[COL_BILLCOLLECTERCD		] = work.BillCollecterCd.ToString();
				dr[COL_BILLCOLLECTERNM		] = work.BillCollecterNm.ToString();
				dr[COL_STARTDATESPAN		] = work.StartDateSpan.ToString();
				dr[COL_ENDDATESPAN			] = work.EndDateSpan.ToString();
				dataSet.Tables[TABLENAME1].Rows.Add(dr);
			}
		}

		private void CopyToDataSetFromArrayList2(ref DataSet dataSet, ArrayList list)
		{			
			dataSet.Tables[TABLENAME2].Rows.Clear();
            /*
			foreach (DmdSalesWork work in list)
			{
				DataRow dr = dataSet.Tables[TABLENAME2].NewRow();
				
				dr[COL_CREATEDATETIME		] = work.CreateDateTime.ToString();
				dr[COL_UPDATEDATETIME		] = work.UpdateDateTime.ToString();
				dr[COL_ENTERPRISECODE		] = work.EnterpriseCode;
				dr[COL_FILEHEADERGUID		] = work.FileHeaderGuid;
				dr[COL_UPDEMPLOYEECODE		] = work.UpdEmployeeCode;
				dr[COL_UPDASSEMBLYID1		] = work.UpdAssemblyId1;
				dr[COL_UPDASSEMBLYID2		] = work.UpdAssemblyId2;
				dr[COL_LOGICALDELETECODE	] = work.LogicalDeleteCode.ToString();
				dr[COL_ACCEPTANORDERNO		] = work.AcceptAnOrderNo.ToString();
				dr[COL_SLIPNO				] = work.SlipNo.ToString();
				dr[COL_DEBITNOTEDIV			] = work.DebitNoteDiv.ToString();
				dr[COL_CUSTOMERCODE			] = work.CustomerCode.ToString();
				dr[COL_CARMNGNO				] = work.CarMngNo.ToString();
				dr[COL_CLAIMCODE			] = work.ClaimCode.ToString();
				dr[COL_ADDUPADATE			] = work.AddUpADate.ToString();
				dr[COL_ACCEPTANORDERSALES	] = work.AcceptAnOrderSales.ToString();
				dr[COL_LASTRECONCILEDATE	] = work.AcptAnOdrDiscountTtl.ToString();
				dr[COL_ACCEPTANORDERCONSTAX	] = work.AcceptAnOrderConsTax.ToString();
				dr[COL_TOTALVARIOUSCOST		] = work.TotalVariousCost.ToString();
				dr[COL_VARCSTTAXTOTAL		] = work.VarCstTaxTotal.ToString();
				dr[COL_VARCSTTAXFREETOTAL	] = work.VarCstTaxFreeTotal.ToString();
				dr[COL_VARCST1				] = work.VarCst1.ToString();
				dr[COL_VARCST2				] = work.VarCst2.ToString();
				dr[COL_VARCST3				] = work.VarCst3.ToString();
				dr[COL_VARCST4				] = work.VarCst4.ToString();
				dr[COL_VARCST5				] = work.VarCst5.ToString();
				dr[COL_VARCST6				] = work.VarCst6.ToString();
				dr[COL_VARCST7				] = work.VarCst7.ToString();
				dr[COL_VARCST8				] = work.VarCst8.ToString();
				dr[COL_VARCST9				] = work.VarCst9.ToString();
				dr[COL_VARCST10				] = work.VarCst10.ToString();
				dr[COL_VARCST11				] = work.VarCst11.ToString();
				dr[COL_VARCST12				] = work.VarCst12.ToString();
				dr[COL_VARCST13				] = work.VarCst13.ToString();
				dr[COL_VARCST14				] = work.VarCst14.ToString();
				dr[COL_VARCST15				] = work.VarCst15.ToString();
				dr[COL_VARCST16				] = work.VarCst16.ToString();
				dr[COL_VARCST17				] = work.VarCst17.ToString();
				dr[COL_VARCST18				] = work.VarCst18.ToString();
				dr[COL_VARCST19				] = work.VarCst19.ToString();
				dr[COL_VARCST20				] = work.VarCst20.ToString();
				dr[COL_VARCSTDIV1			] = work.VarCstDiv1.ToString();
				dr[COL_VARCSTDIV2			] = work.VarCstDiv2.ToString();
				dr[COL_VARCSTDIV3			] = work.VarCstDiv3.ToString();
				dr[COL_VARCSTDIV4			] = work.VarCstDiv4.ToString();
				dr[COL_VARCSTDIV5			] = work.VarCstDiv5.ToString();
				dr[COL_VARCSTDIV6			] = work.VarCstDiv6.ToString();
				dr[COL_VARCSTDIV7			] = work.VarCstDiv7.ToString();
				dr[COL_VARCSTDIV8			] = work.VarCstDiv8.ToString();
				dr[COL_VARCSTDIV9			] = work.VarCstDiv9.ToString();
				dr[COL_VARCSTDIV10			] = work.VarCstDiv10.ToString();
				dr[COL_VARCSTDIV11			] = work.VarCstDiv11.ToString();
				dr[COL_VARCSTDIV12			] = work.VarCstDiv12.ToString();
				dr[COL_VARCSTDIV13			] = work.VarCstDiv13.ToString();
				dr[COL_VARCSTDIV14			] = work.VarCstDiv14.ToString();
				dr[COL_VARCSTDIV15			] = work.VarCstDiv15.ToString();
				dr[COL_VARCSTDIV16			] = work.VarCstDiv16.ToString();
				dr[COL_VARCSTDIV17			] = work.VarCstDiv17.ToString();
				dr[COL_VARCSTDIV18			] = work.VarCstDiv18.ToString();
				dr[COL_VARCSTDIV19			] = work.VarCstDiv19.ToString();
				dr[COL_VARCSTDIV20			] = work.VarCstDiv20.ToString();
				dr[COL_VARCSTCONSTAX		] = work.VarCstConsTax.ToString();
				dr[COL_DEPOSITALLOWANCE		] = work.DepositAllowance.ToString();
				dr[COL_DEPOSITALWCBLNCE		] = work.DepositAlwcBlnce.ToString();
				dr[COL_DATAINPUTSYSTEM		] = work.DataInputSystem.ToString();
				dr[COL_DEMANDADDUPSECCD		] = work.DemandAddUpSecCd.ToString();
				dr[COL_RESULTSADDUPSECCD	] = work.ResultsAddUpSecCd.ToString();
				dr[COL_UPDATESECCD			] = work.UpdateSecCd.ToString();
				dr[COL_ACCEPTANORDERDATE	] = work.AcceptAnOrderDate.ToString();
				dr[COL_CARDELIEXPECTEDDATE	] = work.CarDeliExpectedDate.ToString();
				dr[COL_SALESEMPLOYEECD		] = work.SalesEmployeeCd.ToString();
				dr[COL_SALESDIV				] = work.SalesDiv.ToString();
				dr[COL_SALESNAME			] = work.SalesName.ToString();
				dr[COL_DEBITNLNKACPTANODR	] = work.DebitNLnkAcptAnOdr.ToString();
				dr[COL_DEMANDPRORATACD		] = work.DemandProRataCd.ToString();
				dr[COL_NUMBERPLATE1CODE		] = work.NumberPlate1Code.ToString();
				dr[COL_NUMBERPLATE1NAME		] = work.NumberPlate1Name.ToString();
				dr[COL_NUMBERPLATE2			] = work.NumberPlate2.ToString();
				dr[COL_NUMBERPLATE3			] = work.NumberPlate3.ToString();
				dr[COL_NUMBERPLATE4			] = work.NumberPlate4.ToString();
				dr[COL_MAKERNAME			] = work.MakerName.ToString();
				dr[COL_MODELNAME			] = work.ModelName.ToString();
				dr[COL_DEMANDABLESALESNOTE	] = work.DemandableSalesNote.ToString();
				dr[COL_CREDITORLOANCD		] = work.CreditOrLoanCd.ToString();
				dr[COL_CREDITCOMPANYCODE	] = work.CreditCompanyCode.ToString();
				dr[COL_CREDITSALES			] = work.CreditSales.ToString();
				dr[COL_CREDITALLOWANCE		] = work.CreditAllowance.ToString();
				dr[COL_CREDITALWCBLNCE		] = work.CreditAlwcBlnce.ToString();
				dr[COL_CORPORATEDIVCODE		] = work.CorporateDivCode.ToString();
				dr[COL_AACOUNT				] = work.AaCount.ToString();
				dr[COL_MNYONDEPOALLOWANCE	] = work.MnyOnDepoAllowance.ToString();
				dr[COL_ACPTANODRSTATUS		] = work.AcptAnOdrStatus.ToString();
				dr[COL_LASTRECONCILEADDUPDT	] = work.LastReconcileAddUpDt.ToString();
				dr[COL_CARINSPECTORGECD		] = work.CarInspectOrGeCd.ToString();
				dr[COL_GRADENAME			] = work.GradeName.ToString();
				dr[COL_ACPODRDEPOSITALWC	] = work.AcpOdrDepositAlwc.ToString();
				dr[COL_ACPODRDEPOALWCBLNCE	] = work.AcpOdrDepoAlwcBlnce.ToString();
				dr[COL_VARCOSTDEPOALWC		] = work.VarCostDepoAlwc.ToString();
				dr[COL_VARCOSTDEPOALWCBLNCE	] = work.VarCostDepoAlwcBlnce.ToString();
				dataSet.Tables[TABLENAME2].Rows.Add(dr);
			}
            */
		}

		private void CopyToDataSetFromArrayList3(ref DataSet dataSet, ArrayList list)
		{			
			dataSet.Tables[TABLENAME3].Rows.Clear();
			foreach (DepsitMainWork work in list)
			{
				DataRow dr = dataSet.Tables[TABLENAME3].NewRow();
				
				dr[COL_CREATEDATETIME		] = work.CreateDateTime.ToString();
				dr[COL_UPDATEDATETIME		] = work.UpdateDateTime.ToString();
				dr[COL_ENTERPRISECODE		] = work.EnterpriseCode;
				dr[COL_FILEHEADERGUID		] = work.FileHeaderGuid;
				dr[COL_UPDEMPLOYEECODE		] = work.UpdEmployeeCode;
				dr[COL_UPDASSEMBLYID1		] = work.UpdAssemblyId1;
				dr[COL_UPDASSEMBLYID2		] = work.UpdAssemblyId2;
				dr[COL_LOGICALDELETECODE	] = work.LogicalDeleteCode.ToString();
				dr[COL_DEPOSITDEBITNOTECD	] = work.DepositDebitNoteCd.ToString();
				dr[COL_DEPOSITSLIPNO		] = work.DepositSlipNo.ToString();
				dr[COL_DEPOSITKINDCODE		] = work.DepositKindCode.ToString();
				dr[COL_CUSTOMERCODE			] = work.CustomerCode.ToString();
				dr[COL_DEPOSITCD			] = work.DepositCd.ToString();
				dr[COL_DEPOSITTOTAL			] = work.DepositTotal.ToString();
				dr[COL_OUTLINE				] = work.Outline.ToString();
				//dr[COL_ACCEPTANORDERSALESNO	] = work.AcceptAnOrderSalesNo.ToString();
				dr[COL_INPUTDEPOSITSECCD	] = work.InputDepositSecCd.ToString();
				dr[COL_DEPOSITDATE			] = work.DepositDate.ToString();
				dr[COL_ADDUPSECCODE			] = work.AddUpSecCode.ToString();
				dr[COL_ADDUPADATE			] = work.AddUpADate.ToString();
				dr[COL_UPDATESECCD			] = work.UpdateSecCd.ToString();
				dr[COL_DEPOSITKINDNAME		] = work.DepositKindName.ToString();
				dr[COL_DEPOSITALLOWANCE		] = work.DepositAllowance.ToString();
				dr[COL_DEPOSITALWCBLNCE		] = work.DepositAlwcBlnce.ToString();
				dr[COL_DEPOSITAGENTCODE		] = work.DepositAgentCode.ToString();
				dr[COL_DEPOSITKINDDIVCD		] = work.DepositKindDivCd.ToString();
				dr[COL_FEEDEPOSIT			] = work.FeeDeposit.ToString();
				dr[COL_DISCOUNTDEPOSIT		] = work.DiscountDeposit.ToString();
				//dr[COL_CREDITORLOANCD		] = work.CreditOrLoanCd.ToString();
				//dr[COL_CREDITCOMPANYCODE	] = work.CreditCompanyCode.ToString();
				dr[COL_DEPOSIT				] = work.Deposit.ToString();
				dr[COL_DRAFTDRAWINGDATE		] = work.DraftDrawingDate.ToString();
				dr[COL_DRAFTPAYTIMELIMIT	] = work.DraftPayTimeLimit.ToString();
				dr[COL_DEBITNOTELINKDEPONO	] = work.DebitNoteLinkDepoNo.ToString();
				dr[COL_LASTRECONCILEADDUPDT	] = work.LastReconcileAddUpDt.ToString();
				dr[COL_AUTODEPOSITCD		] = work.AutoDepositCd.ToString();
				//dr[COL_ACPODRDEPOSIT		] = work.AcpOdrDeposit.ToString();
				//dr[COL_ACPODRCHARGEDEPOSIT	] = work.AcpOdrChargeDeposit.ToString();
				//dr[COL_ACPODRDISDEPOSIT		] = work.AcpOdrDisDeposit.ToString();
				//dr[COL_VARIOUSCOSTDEPOSIT	] = work.VariousCostDeposit.ToString();
				//dr[COL_VARCOSTCHARGEDEPOSIT	] = work.VarCostChargeDeposit.ToString();
				//dr[COL_VARCOSTDISDEPOSIT	] = work.VarCostDisDeposit.ToString();
				//dr[COL_ACPODRDEPOSITALWC	] = work.AcpOdrDepositAlwc.ToString();
				//dr[COL_ACPODRDEPOALWCBLNCE	] = work.AcpOdrDepoAlwcBlnce.ToString();
				//dr[COL_VARCOSTDEPOALWC		] = work.VarCostDepoAlwc.ToString();
				//dr[COL_VARCOSTDEPOALWCBLNCE	] = work.VarCostDepoAlwcBlnce.ToString();
				dataSet.Tables[TABLENAME3].Rows.Add(dr);
			}
		}
		#endregion

		#region 元帳
		private void MotoSearch()
		{
			object objKingetCustDmdPrcWorkList;
			object objDmdSalesWorkList;
			object objDepsitMainWorkList;
			
			SeiKingetParameter para = new SeiKingetParameter();

			para.EnterpriseCode			= this.enterpriseCode_textBox.Text;
			if (addSecCode_tEdit.Text != "")
			{
				para.AddUpSecCodeList.Add(addSecCode_tEdit.Text);
			}
			else
			{
				para.IsSelectAllSection	= true;
			}
			para.IsOutputAllSecRec		= this.allSecCode_checkBox.Checked;
			para.StartCustomerCode		= this.startCustomerCode_tNedit.GetInt();
			para.EndCustomerCode		= this.startCustomerCode_tNedit.GetInt();
			para.StartAddUpYearMonth	= this.startAddUpYearMonth_tNedit.GetInt();
			para.EndAddUpYearMonth		= this.endAddUpYearMonth_tNedit.GetInt();
			para.IsOutputZeroBlance		= true;
			para.IsAllCorporateDivCode	= true;
			
			// 得意先分析コード
			//para.StartCustAnalysCode1 = this.startCustAnalysCode1_tNedit.GetInt();
			//para.StartCustAnalysCode2 = this.startCustAnalysCode2_tNedit.GetInt();
			//para.StartCustAnalysCode3 = this.startCustAnalysCode3_tNedit.GetInt();
			//para.StartCustAnalysCode4 = this.startCustAnalysCode4_tNedit.GetInt();
			//para.StartCustAnalysCode5 = this.startCustAnalysCode5_tNedit.GetInt();
			//para.StartCustAnalysCode6 = this.startCustAnalysCode6_tNedit.GetInt();
			//para.EndCustAnalysCode1 = this.endCustAnalysCode1_tNedit.GetInt();
			//para.EndCustAnalysCode2 = this.endCustAnalysCode2_tNedit.GetInt();
			//para.EndCustAnalysCode3 = this.endCustAnalysCode3_tNedit.GetInt();
			//para.EndCustAnalysCode4 = this.endCustAnalysCode4_tNedit.GetInt();
			//para.EndCustAnalysCode5 = this.endCustAnalysCode5_tNedit.GetInt();
			//para.EndCustAnalysCode6 = this.endCustAnalysCode6_tNedit.GetInt();

			try
			{
				int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrcWorkList, out objDmdSalesWorkList, out objDepsitMainWorkList, para);
				if (status == 0)
				{
					ArrayList list1 = objKingetCustDmdPrcWorkList as ArrayList;
					this.CopyToDataSetFromArrayList1(ref this.dataSet1, list1);
					ArrayList list2 = objDmdSalesWorkList as ArrayList;
					this.CopyToDataSetFromArrayList2(ref this.dataSet1, list2);
					ArrayList list3 = objDepsitMainWorkList as ArrayList;
					this.CopyToDataSetFromArrayList3(ref this.dataSet1, list3);
				}
				else
				{
					this.dataSet1.Tables[TABLENAME1].Rows.Clear();
					this.dataSet1.Tables[TABLENAME2].Rows.Clear();
					this.dataSet1.Tables[TABLENAME3].Rows.Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message +"\n\r"+ ex.StackTrace);
			}
			
			this.dataGrid1.DataSource = this.dataSet1.Tables[TABLENAME1];
			this.dataGrid2.DataSource = this.dataSet1.Tables[TABLENAME2];
			this.dataGrid3.DataSource = this.dataSet1.Tables[TABLENAME3];
		}
		#endregion

		#region 元帳一括
		private void MotoAllSearch()
		{
			object objKingetCustDmdPrcWorkList;
			object objDmdSalesWorkList;
			object objDepsitMainWorkList;
			
			SeiKingetParameter para = new SeiKingetParameter();
			para.EnterpriseCode		= this.enterpriseCode_textBox.Text;
			para.IsSelectAllSection	= false;
			para.IsOutputAllSecRec	= false;
			if (addSecCode_tEdit.Text == "")
			{
				para.IsSelectAllSection	= true;
				para.IsOutputAllSecRec	= true;
			}
			else
			if (addSecCode_tEdit.Text == "000000")
			{
				para.IsOutputAllSecRec	= true;
				para.AddUpSecCodeList.Add(addSecCode_tEdit.Text);
			}
			else
			{
				para.AddUpSecCodeList.Add(addSecCode_tEdit.Text);
			}
			para.StartCustomerCode	= this.startCustomerCode_tNedit.GetInt();
			para.EndCustomerCode		= this.endCustomerCode_tNedit.GetInt();
			para.TotalDay				= 0;
			para.StartTotalDay		= 0;
			para.EndTotalDay			= 0;
			para.StartAddUpDate		= DateTime.MinValue;
			para.EndAddUpDate			= DateTime.MinValue;
			para.StartAddUpYearMonth	= this.startAddUpYearMonth_tNedit.GetInt();
			para.EndAddUpYearMonth	= this.endAddUpYearMonth_tNedit.GetInt();
			para.IsOutputZeroBlance	= this.outputZeroBlanceFlg_checkBox.Checked;
			para.StartKana			= this.startKana_tEdit.Text;
			para.EndKana				= this.endKana_tEdit.Text;
			// 個人・法人区分
			foreach (UltraTreeNode node in this.corporateDivCode_ultraTree.Nodes)
			{
				if (node.CheckedState == CheckState.Checked)
				{
					int corporateDivCode = (int)node.DataKey;
					para.CorporateDivCodeList.Add(corporateDivCode);
				}
			}
			
			if (para.CorporateDivCodeList.Count == 6)
			{
				para.IsAllCorporateDivCode= true;
			}
			else
			{
				para.IsAllCorporateDivCode= false;
			}
			para.IsJudgeBillOutputCode= this.billOutputCodeFlg_checkBox.Checked;
			para.EmployeeKind			= (int)this.employeeKind_ultraOptionSet.CheckedItem.DataValue;
			para.StartEmployeeCode	= this.startEmployeeCode_tEdit.Text;
			para.EndEmployeeCode		= this.endEmployeeCode_tEdit.Text;
			
			// 得意先分析コード
			para.StartCustAnalysCode1 = this.startCustAnalysCode1_tNedit.GetInt();
			para.StartCustAnalysCode2 = this.startCustAnalysCode2_tNedit.GetInt();
			para.StartCustAnalysCode3 = this.startCustAnalysCode3_tNedit.GetInt();
			para.StartCustAnalysCode4 = this.startCustAnalysCode4_tNedit.GetInt();
			para.StartCustAnalysCode5 = this.startCustAnalysCode5_tNedit.GetInt();
			para.StartCustAnalysCode6 = this.startCustAnalysCode6_tNedit.GetInt();
			para.EndCustAnalysCode1 = this.endCustAnalysCode1_tNedit.GetInt();
			para.EndCustAnalysCode2 = this.endCustAnalysCode2_tNedit.GetInt();
			para.EndCustAnalysCode3 = this.endCustAnalysCode3_tNedit.GetInt();
			para.EndCustAnalysCode4 = this.endCustAnalysCode4_tNedit.GetInt();
			para.EndCustAnalysCode5 = this.endCustAnalysCode5_tNedit.GetInt();
			para.EndCustAnalysCode6 = this.endCustAnalysCode6_tNedit.GetInt();
			
			int status = this._iSeiKingetDB.SearchMotoAll(out objKingetCustDmdPrcWorkList, out objDmdSalesWorkList, out objDepsitMainWorkList, para);
			if (status == 0)
			{
				ArrayList list1 = objKingetCustDmdPrcWorkList as ArrayList;
				this.CopyToDataSetFromArrayList1(ref this.dataSet1, list1);
				ArrayList list2 = objDmdSalesWorkList as ArrayList;
				this.CopyToDataSetFromArrayList2(ref this.dataSet1, list2);
				ArrayList list3 = objDepsitMainWorkList as ArrayList;
				this.CopyToDataSetFromArrayList3(ref this.dataSet1, list3);
			}
			else
			{
				this.dataSet1.Tables[TABLENAME1].Rows.Clear();
				this.dataSet1.Tables[TABLENAME2].Rows.Clear();
				this.dataSet1.Tables[TABLENAME3].Rows.Clear();
			}
			
			this.dataGrid1.DataSource = this.dataSet1.Tables[TABLENAME1];
			this.dataGrid2.DataSource = this.dataSet1.Tables[TABLENAME2];
			this.dataGrid3.DataSource = this.dataSet1.Tables[TABLENAME3];
		}
		#endregion

		#region 帳票
		private void ReportSearch()
		{
			SeiKingetParameter para = new SeiKingetParameter();
			
			para.EnterpriseCode			= this.enterpriseCode_textBox.Text;
			if (this.endTotalDay_tNedit.GetInt() == 0)
			{
				para.TotalDay			= this.startTotalDay_tNedit.GetInt();
				para.StartTotalDay		= 0;
				para.EndTotalDay		= 0;
			}
			else
			{
				para.TotalDay			= 0;
				para.StartTotalDay		= this.startTotalDay_tNedit.GetInt();
				para.EndTotalDay		= this.endTotalDay_tNedit.GetInt();
			}
			para.StartCustomerCode		= this.startCustomerCode_tNedit.GetInt();
			para.EndCustomerCode		= this.endCustomerCode_tNedit.GetInt();
			para.StartKana				= this.startKana_tEdit.Text;
			para.EndKana				= this.endKana_tEdit.Text;
			para.StartEmployeeCode		= this.startEmployeeCode_tEdit.Text;
			para.EndEmployeeCode		= this.endEmployeeCode_tEdit.Text;
			para.IsOutputZeroBlance		= this.outputZeroBlanceFlg_checkBox.Checked;
			para.IsOutputAllSecRec		= this.allSecCode_checkBox.Checked;
			para.IsJudgeBillOutputCode	= this.billOutputCodeFlg_checkBox.Checked;
			para.StartAddUpYearMonth	= this.startAddUpYearMonth_tNedit.GetInt();
			para.EndAddUpYearMonth		= this.startAddUpYearMonth_tNedit.GetInt();
			para.EmployeeKind			= (int)this.employeeKind_ultraOptionSet.CheckedItem.DataValue;
			
			// 計上拠点
			if (this.secCode_ultraTree.Nodes["ALL"].CheckedState == CheckState.Checked)
			{
				para.IsSelectAllSection	= true;
			}
			else
			{
				foreach (UltraTreeNode node in this.secCode_ultraTree.Nodes)
				{
					if (node.Key != "ALL")
					{
						if (node.CheckedState == CheckState.Checked)
						{
							para.AddUpSecCodeList.Add(node.Key);
						}
					}
				}
			}
			
			// 個人・法人区分
			foreach (UltraTreeNode node in this.corporateDivCode_ultraTree.Nodes)
			{
				if (node.CheckedState == CheckState.Checked)
				{
					int corporateDivCode = TStrConv.StrToIntDef(node.Key, 0);
					bool flg = false;
					foreach (int code in para.CorporateDivCodeList)
					{
						if (code == corporateDivCode)
						{
							flg = true;
						}
					}
					if (!flg)
					{
						para.CorporateDivCodeList.Add(corporateDivCode);
					}
				}
			}

			// 得意先分析コード
			para.StartCustAnalysCode1 = this.startCustAnalysCode1_tNedit.GetInt();
			para.StartCustAnalysCode2 = this.startCustAnalysCode2_tNedit.GetInt();
			para.StartCustAnalysCode3 = this.startCustAnalysCode3_tNedit.GetInt();
			para.StartCustAnalysCode4 = this.startCustAnalysCode4_tNedit.GetInt();
			para.StartCustAnalysCode5 = this.startCustAnalysCode5_tNedit.GetInt();
			para.StartCustAnalysCode6 = this.startCustAnalysCode6_tNedit.GetInt();
			para.EndCustAnalysCode1 = this.endCustAnalysCode1_tNedit.GetInt();
			para.EndCustAnalysCode2 = this.endCustAnalysCode2_tNedit.GetInt();
			para.EndCustAnalysCode3 = this.endCustAnalysCode3_tNedit.GetInt();
			para.EndCustAnalysCode4 = this.endCustAnalysCode4_tNedit.GetInt();
			para.EndCustAnalysCode5 = this.endCustAnalysCode5_tNedit.GetInt();
			para.EndCustAnalysCode6 = this.endCustAnalysCode6_tNedit.GetInt();

			object objKingetCustDmdPrcWorkList;

			int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrcWorkList, para);
			if (status == 0)
			{
				ArrayList list1 = objKingetCustDmdPrcWorkList as ArrayList;
				this.CopyToDataSetFromArrayList1(ref this.dataSet1, list1);
			}
			else
			{
				this.dataSet1.Tables[TABLENAME1].Rows.Clear();
				this.dataSet1.Tables[TABLENAME2].Rows.Clear();
				this.dataSet1.Tables[TABLENAME3].Rows.Clear();
			}

			this.dataGrid1.DataSource = this.dataSet1.Tables[TABLENAME1];
			this.dataGrid2.DataSource = this.dataSet1.Tables[TABLENAME2];
			this.dataGrid3.DataSource = this.dataSet1.Tables[TABLENAME3];
		}
		#endregion

		#region 詳細
		private void DetailSearch()
		{
			object objDmdSalesWorkList;
			object objDepsitMainWorkList;
			
			ArrayList list = new ArrayList();
			
			SeiKingetDetailParameter detailPara = new SeiKingetDetailParameter();
			if (addSecCode_tEdit.Text.Trim() == "")
			{
				addSecCode_tEdit.Focus();
				MessageBox.Show("拠点コードを入力して下さい");
			}
			detailPara.AddUpSecCode	= addSecCode_tEdit.Text;
			detailPara.CustomerCode	= this.startCustomerCode_tNedit.GetInt();
			detailPara.AddUpDate	= this.startAddUpDate_tDateEdit.LongDate;
			
			list.Add(detailPara);
			
			object objSeiKingetDetailParameterList = list;
			
			int status = this._iSeiKingetDB.SearchDetails(out objDmdSalesWorkList, out objDepsitMainWorkList, 
				this.enterpriseCode_textBox.Text, objSeiKingetDetailParameterList);
			
			this.dataSet1.Tables[TABLENAME1].Rows.Clear();
			this.dataSet1.Tables[TABLENAME2].Rows.Clear();
			this.dataSet1.Tables[TABLENAME3].Rows.Clear();
			
			if (status == 0)
			{
				ArrayList list2 = objDmdSalesWorkList as ArrayList;
				this.CopyToDataSetFromArrayList2(ref this.dataSet1, list2);
				ArrayList list3 = objDepsitMainWorkList as ArrayList;
				this.CopyToDataSetFromArrayList3(ref this.dataSet1, list3);
			}
			
			this.dataGrid1.DataSource = this.dataSet1.Tables[TABLENAME1];
			this.dataGrid2.DataSource = this.dataSet1.Tables[TABLENAME2];
			this.dataGrid3.DataSource = this.dataSet1.Tables[TABLENAME3];
		}
		#endregion

		#region １件読込み
		private void Read()
		{
			object objKingetCustDmdPrcWork;
			
			int status = this._iSeiKingetDB.Read(out objKingetCustDmdPrcWork, this.enterpriseCode_textBox.Text,
				addSecCode_tEdit.Text, startCustomerCode_tNedit.GetInt(), startAddUpDate_tDateEdit.LongDate);
			if (status == 0)
			{
				ArrayList list1 = new ArrayList();
				list1.Add(objKingetCustDmdPrcWork);
				this.CopyToDataSetFromArrayList1(ref this.dataSet1, list1);
			}
			else
			{
				this.dataSet1.Tables[TABLENAME1].Rows.Clear();
				this.dataSet1.Tables[TABLENAME2].Rows.Clear();
				this.dataSet1.Tables[TABLENAME3].Rows.Clear();
			}
			
			this.dataGrid1.DataSource = this.dataSet1.Tables[TABLENAME1];
			this.dataGrid2.DataSource = this.dataSet1.Tables[TABLENAME2];
			this.dataGrid3.DataSource = this.dataSet1.Tables[TABLENAME3];
		}
		#endregion

		#endregion

		#region Control Events
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
			
			try
			{
				// リモートオブジェクト取得
				this._iSeiKingetDB = (ISeiKingetDB)MediationSeiKingetDB.GetSeiKingetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iSeiKingetDB = null;
			}

			this.DataSetColumnSet1(ref this.dataSet1);
			this.DataSetColumnSet2(ref this.dataSet1);
			this.DataSetColumnSet3(ref this.dataSet1);

			DT1 = DateTime.Today.AddMonths(-1);
			DT2 = DateTime.Today;

			startAddUpDate_tDateEdit.SetDateTime(DT1);
			endAddUpDate_tDateEdit.SetDateTime(DT2);
			startAddUpDate_tDateEdit.Refresh();
			endAddUpDate_tDateEdit.Refresh();

			this.startAddUpYearMonth_tNedit.SetInt(DT1.Year*100 + DT1.Month);
			this.endAddUpYearMonth_tNedit.SetInt(DT2.Year*100 + DT2.Month);
			
			this.selectSearch_ultraOptionSet.CheckedIndex = 0;
		}

		private void SearchBtn_Click(object sender, System.EventArgs e)
		{
			panel1.Visible = true;
			this.Cursor = Cursors.WaitCursor;
			
			switch ((int)this.selectSearch_ultraOptionSet.CheckedItem.DataValue)
			{
				case 0:
				{
					this.MotoSearch();
					break;
				}
				case 1:
				{
					this.ReportSearch();
					break;
				}
				case 2:
				{
					this.DetailSearch();
					break;
				}
				case 3:
				{
					this.MotoAllSearch();
					break;
				}
				default:
				{
					this.MotoSearch();
					break;
				}
			}			
			
			this.Cursor = Cursors.Default;
			panel1.Visible = false;
		}

		private void selectSearch_ultraOptionSet_ValueChanged(object sender, System.EventArgs e)
		{
			switch ((int)this.selectSearch_ultraOptionSet.CheckedItem.DataValue)
			{
				case 0:
				{
					this.addSecCode_tEdit.Enabled				= true;
					this.secCode_ultraTree.Enabled				= false;
					this.startTotalDay_tNedit.Enabled			= false;
					this.endTotalDay_tNedit.Enabled				= false;
					this.startAddUpDate_tDateEdit.Enabled		= false;
					this.endAddUpDate_tDateEdit.Enabled			= false;
					this.startAddUpYearMonth_tNedit.Enabled		= true;
					this.endAddUpYearMonth_tNedit.Enabled		= true;
					this.startCustomerCode_tNedit.Enabled		= true;
					this.endCustomerCode_tNedit.Enabled			= false;
					this.startKana_tEdit.Enabled				= false;
					this.endKana_tEdit.Enabled					= false;
					this.startEmployeeCode_tEdit.Enabled		= false;
					this.endEmployeeCode_tEdit.Enabled			= false;
					this.employeeKind_ultraOptionSet.Enabled	= false;
					this.corporateDivCode_ultraTree.Enabled		= false;
					this.ultraExpandableGroupBox1.Enabled		= false;
					break;
				}
				case 1:
				{
					this.addSecCode_tEdit.Enabled				= false;
					this.secCode_ultraTree.Enabled				= true;
					this.startTotalDay_tNedit.Enabled			= true;
					this.endTotalDay_tNedit.Enabled				= true;
					this.startAddUpDate_tDateEdit.Enabled		= false;
					this.endAddUpDate_tDateEdit.Enabled			= false;
					this.startAddUpYearMonth_tNedit.Enabled		= true;
					this.endAddUpYearMonth_tNedit.Enabled		= false;
					this.startCustomerCode_tNedit.Enabled		= true;
					this.endCustomerCode_tNedit.Enabled			= true;
					this.startKana_tEdit.Enabled				= true;
					this.endKana_tEdit.Enabled					= true;
					this.startEmployeeCode_tEdit.Enabled		= true;
					this.endEmployeeCode_tEdit.Enabled			= true;
					this.employeeKind_ultraOptionSet.Enabled	= true;
					this.corporateDivCode_ultraTree.Enabled		= true;
					this.ultraExpandableGroupBox1.Enabled		= true;
					break;
				}
				case 2:
				{
					this.addSecCode_tEdit.Enabled				= true;
					this.secCode_ultraTree.Enabled				= false;
					this.startTotalDay_tNedit.Enabled			= false;
					this.endTotalDay_tNedit.Enabled				= false;
					this.startAddUpDate_tDateEdit.Enabled		= true;
					this.endAddUpDate_tDateEdit.Enabled			= false;
					this.startAddUpYearMonth_tNedit.Enabled		= false;
					this.endAddUpYearMonth_tNedit.Enabled		= false;
					this.startCustomerCode_tNedit.Enabled		= true;
					this.endCustomerCode_tNedit.Enabled			= false;
					this.startKana_tEdit.Enabled				= false;
					this.endKana_tEdit.Enabled					= false;
					this.startEmployeeCode_tEdit.Enabled		= false;
					this.endEmployeeCode_tEdit.Enabled			= false;
					this.employeeKind_ultraOptionSet.Enabled	= false;
					this.corporateDivCode_ultraTree.Enabled		= false;
					this.ultraExpandableGroupBox1.Enabled		= false;
					break;
				}
				case 3:
				{
					this.addSecCode_tEdit.Enabled				= true;
					this.secCode_ultraTree.Enabled				= false;
					this.startTotalDay_tNedit.Enabled			= false;
					this.endTotalDay_tNedit.Enabled				= false;
					this.startAddUpDate_tDateEdit.Enabled		= false;
					this.endAddUpDate_tDateEdit.Enabled			= false;
					this.startAddUpYearMonth_tNedit.Enabled		= true;
					this.endAddUpYearMonth_tNedit.Enabled		= true;
					this.startCustomerCode_tNedit.Enabled		= true;
					this.endCustomerCode_tNedit.Enabled			= true;
					this.startKana_tEdit.Enabled				= true;
					this.endKana_tEdit.Enabled					= true;
					this.startEmployeeCode_tEdit.Enabled		= true;
					this.endEmployeeCode_tEdit.Enabled			= true;
					this.employeeKind_ultraOptionSet.Enabled	= true;
					this.corporateDivCode_ultraTree.Enabled		= true;
					this.ultraExpandableGroupBox1.Enabled		= true;
					break;
				}
			}
		}

		private void ReadBtn_Click(object sender, System.EventArgs e)
		{
			panel1.Visible = true;
			this.Cursor = Cursors.WaitCursor;
			
			this.Read();
			
			this.Cursor = Cursors.Default;
			panel1.Visible = false;
		}
		
		private void CheckBtn_Click(object sender, System.EventArgs e)
		{
			int status = this._iSeiKingetDB.CheckDemandPrice(this.enterpriseCode_textBox.Text, this.startCustomerCode_tNedit.GetInt());
			if (status == 0)
			{
				MessageBox.Show("削除 OK");
			}
			else
			{
				MessageBox.Show("削除 NG");
			}
		}
		#endregion
	}
}
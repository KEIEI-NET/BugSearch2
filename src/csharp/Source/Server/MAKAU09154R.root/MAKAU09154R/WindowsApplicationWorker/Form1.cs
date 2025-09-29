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
using Broadleaf.Library.Resources;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Write_Button;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button Delete_Button;
		private System.Windows.Forms.Button Search_Button;
		private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.TextBox LogicalDeletetextBox;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb2;

        private DmdPrtPtnWork dmdPrtPtnWork = null;
        private IDmdPrtPtnDB IdmdPrtPtnDB = null;

        private static string[] _parameter;
        private Label label14;
        private Label label3;
        private Label label4;
        private TextBox tb3;
        private TextBox tb4;
        private TextBox tb5;
        private Button Read_Button;
        private Button LogicalDelete_Button;
        private Button Revival_Button;
        private DataGrid dataGrid1;
        private Label label7;
        private TextBox tb8;
        private TextBox tb7;
        private TextBox tb6;
        private Label label2;
        private Label label6;
        private Label label8;
        private TextBox tb11;
        private TextBox tb10;
        private TextBox tb9;
        private Label label9;
        private Label label12;
        private Label label13;
        private TextBox tb20;
        private TextBox tb19;
        private TextBox tb18;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox tb23;
        private TextBox tb22;
        private TextBox tb21;
        private Label label18;
        private Label label19;
        private Label label20;
        private TextBox tb26;
        private TextBox tb25;
        private TextBox tb24;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox tb29;
        private TextBox tb28;
        private TextBox tb27;
        private Label label24;
        private Label label25;
        private Label label26;
        private TextBox tb13;
        private TextBox tb31;
        private TextBox tb30;
        private Label label27;
        private Label label28;
        private Label label29;
        private TextBox tb12;
        private Label label30;
        private TextBox tb17;
        private TextBox tb16;
        private TextBox tb15;
        private Label label31;
        private Label label32;
        private Label label33;
        private TextBox tb14;
        private Label label34;
        private TextBox tb32;
        private Label label35;
        private TextBox tb47;
        private Label label36;
        private TextBox tb46;
        private TextBox tb45;
        private Label label37;
        private Label label38;
        private TextBox tb44;
        private TextBox tb43;
        private TextBox tb42;
        private Label label39;
        private Label label40;
        private Label label41;
        private TextBox tb41;
        private TextBox tb40;
        private TextBox tb39;
        private Label label42;
        private Label label43;
        private Label label44;
        private TextBox tb38;
        private TextBox tb37;
        private TextBox tb36;
        private Label label45;
        private Label label46;
        private Label label47;
        private TextBox tb35;
        private TextBox tb34;
        private TextBox tb33;
        private Label label48;
        private Label label49;
        private Label label50;
        private TextBox tb62;
        private Label label51;
        private TextBox tb61;
        private TextBox tb60;
        private Label label52;
        private Label label53;
        private TextBox tb59;
        private TextBox tb58;
        private TextBox tb57;
        private Label label54;
        private Label label55;
        private Label label56;
        private TextBox tb56;
        private TextBox tb55;
        private TextBox tb54;
        private Label label57;
        private Label label58;
        private Label label59;
        private TextBox tb53;
        private TextBox tb52;
        private TextBox tb51;
        private Label label60;
        private Label label61;
        private Label label62;
        private TextBox tb50;
        private TextBox tb49;
        private TextBox tb48;
        private Label label63;
        private Label label64;
        private Label label65;
        private TextBox tb66;
        private Label label66;
        private TextBox tb65;
        private TextBox tb64;
        private Label label67;
        private Label label68;
        private TextBox tb63;
        private Label label69;
        private TextBox tb69;
        private Label label70;
        private TextBox tb68;
        private TextBox tb67;
        private Label label71;
        private Label label72;
        private TextBox tb70;
		private static System.Windows.Forms.Form _form = null;

		public Form1()
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
				if (components != null) 
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Write_Button = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LogicalDeletetextBox = new System.Windows.Forms.TextBox();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Search_Button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.Read_Button = new System.Windows.Forms.Button();
            this.LogicalDelete_Button = new System.Windows.Forms.Button();
            this.Revival_Button = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.tb19 = new System.Windows.Forms.TextBox();
            this.tb18 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tb23 = new System.Windows.Forms.TextBox();
            this.tb22 = new System.Windows.Forms.TextBox();
            this.tb21 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tb26 = new System.Windows.Forms.TextBox();
            this.tb25 = new System.Windows.Forms.TextBox();
            this.tb24 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tb29 = new System.Windows.Forms.TextBox();
            this.tb28 = new System.Windows.Forms.TextBox();
            this.tb27 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb31 = new System.Windows.Forms.TextBox();
            this.tb30 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tb17 = new System.Windows.Forms.TextBox();
            this.tb16 = new System.Windows.Forms.TextBox();
            this.tb15 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tb14 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tb32 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tb47 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tb46 = new System.Windows.Forms.TextBox();
            this.tb45 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tb44 = new System.Windows.Forms.TextBox();
            this.tb43 = new System.Windows.Forms.TextBox();
            this.tb42 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tb41 = new System.Windows.Forms.TextBox();
            this.tb40 = new System.Windows.Forms.TextBox();
            this.tb39 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tb38 = new System.Windows.Forms.TextBox();
            this.tb37 = new System.Windows.Forms.TextBox();
            this.tb36 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tb35 = new System.Windows.Forms.TextBox();
            this.tb34 = new System.Windows.Forms.TextBox();
            this.tb33 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tb62 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.tb61 = new System.Windows.Forms.TextBox();
            this.tb60 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.tb59 = new System.Windows.Forms.TextBox();
            this.tb58 = new System.Windows.Forms.TextBox();
            this.tb57 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tb56 = new System.Windows.Forms.TextBox();
            this.tb55 = new System.Windows.Forms.TextBox();
            this.tb54 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.tb53 = new System.Windows.Forms.TextBox();
            this.tb52 = new System.Windows.Forms.TextBox();
            this.tb51 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.tb49 = new System.Windows.Forms.TextBox();
            this.tb48 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.tb66 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.tb65 = new System.Windows.Forms.TextBox();
            this.tb64 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.tb63 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.tb69 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tb68 = new System.Windows.Forms.TextBox();
            this.tb67 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.tb70 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(160, 33);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(114, 19);
            this.tb1.TabIndex = 5;
            this.tb1.Text = "0101150842020000";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(160, 58);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(114, 19);
            this.tb2.TabIndex = 6;
            this.tb2.Text = "633495518107968750";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "請求書パターン番号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Write_Button
            // 
            this.Write_Button.Location = new System.Drawing.Point(462, 8);
            this.Write_Button.Name = "Write_Button";
            this.Write_Button.Size = new System.Drawing.Size(85, 23);
            this.Write_Button.TabIndex = 1;
            this.Write_Button.Text = "Write";
            this.Write_Button.Click += new System.EventHandler(this.Write_Button_Click);
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(735, 37);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(85, 23);
            this.Clear_Button.TabIndex = 4;
            this.Clear_Button.Text = "Clear";
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(792, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "論理削除区分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogicalDeletetextBox
            // 
            this.LogicalDeletetextBox.Location = new System.Drawing.Point(928, 505);
            this.LogicalDeletetextBox.Name = "LogicalDeletetextBox";
            this.LogicalDeletetextBox.Size = new System.Drawing.Size(24, 19);
            this.LogicalDeletetextBox.TabIndex = 12;
            this.LogicalDeletetextBox.Text = "01";
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(735, 8);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(85, 23);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(371, 8);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(85, 23);
            this.Search_Button.TabIndex = 0;
            this.Search_Button.Text = "SearchA";
            this.Search_Button.Click += new System.EventHandler(this.SearchA_Button_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 15);
            this.label10.TabIndex = 51;
            this.label10.Text = "企業コード";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(24, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1018, 22);
            this.label11.TabIndex = 50;
            this.label11.Text = "その他の設定項目";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(24, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 15);
            this.label14.TabIndex = 54;
            this.label14.Text = "請求鑑タイトル１";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 55;
            this.label3.Text = "請求鑑タイトル２";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 56;
            this.label4.Text = "請求鑑タイトル３";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(160, 105);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(114, 19);
            this.tb3.TabIndex = 8;
            this.tb3.Text = "1";
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(160, 130);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(114, 19);
            this.tb4.TabIndex = 9;
            this.tb4.Text = "1";
            // 
            // tb5
            // 
            this.tb5.Location = new System.Drawing.Point(160, 155);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(114, 19);
            this.tb5.TabIndex = 10;
            this.tb5.Text = "1";
            // 
            // Read_Button
            // 
            this.Read_Button.Location = new System.Drawing.Point(280, 8);
            this.Read_Button.Name = "Read_Button";
            this.Read_Button.Size = new System.Drawing.Size(85, 23);
            this.Read_Button.TabIndex = 59;
            this.Read_Button.Text = "Read";
            this.Read_Button.Click += new System.EventHandler(this.Read_Button_Click);
            // 
            // LogicalDelete_Button
            // 
            this.LogicalDelete_Button.Location = new System.Drawing.Point(553, 8);
            this.LogicalDelete_Button.Name = "LogicalDelete_Button";
            this.LogicalDelete_Button.Size = new System.Drawing.Size(85, 23);
            this.LogicalDelete_Button.TabIndex = 60;
            this.LogicalDelete_Button.Text = "LogicalDelete";
            this.LogicalDelete_Button.Click += new System.EventHandler(this.LogicalDelete_Button_Click);
            // 
            // Revival_Button
            // 
            this.Revival_Button.Location = new System.Drawing.Point(644, 8);
            this.Revival_Button.Name = "Revival_Button";
            this.Revival_Button.Size = new System.Drawing.Size(85, 23);
            this.Revival_Button.TabIndex = 61;
            this.Revival_Button.Text = "Revival";
            this.Revival_Button.Click += new System.EventHandler(this.Revival_Button_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(26, 530);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1016, 188);
            this.dataGrid1.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(24, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 22);
            this.label7.TabIndex = 63;
            this.label7.Text = "キー項目";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb8
            // 
            this.tb8.Location = new System.Drawing.Point(160, 230);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(114, 19);
            this.tb8.TabIndex = 66;
            this.tb8.Text = "1";
            // 
            // tb7
            // 
            this.tb7.Location = new System.Drawing.Point(160, 205);
            this.tb7.Name = "tb7";
            this.tb7.Size = new System.Drawing.Size(114, 19);
            this.tb7.TabIndex = 65;
            this.tb7.Text = "1";
            // 
            // tb6
            // 
            this.tb6.Location = new System.Drawing.Point(160, 180);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(114, 19);
            this.tb6.TabIndex = 64;
            this.tb6.Text = "1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 69;
            this.label2.Text = "請求鑑タイトル６";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 68;
            this.label6.Text = "請求鑑タイトル５";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 67;
            this.label8.Text = "請求鑑タイトル４";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb11
            // 
            this.tb11.Location = new System.Drawing.Point(160, 305);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(114, 19);
            this.tb11.TabIndex = 72;
            this.tb11.Text = "1";
            // 
            // tb10
            // 
            this.tb10.Location = new System.Drawing.Point(160, 280);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(114, 19);
            this.tb10.TabIndex = 71;
            this.tb10.Text = "1";
            // 
            // tb9
            // 
            this.tb9.Location = new System.Drawing.Point(160, 255);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(114, 19);
            this.tb9.TabIndex = 70;
            this.tb9.Text = "1";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 15);
            this.label9.TabIndex = 75;
            this.label9.Text = "請求鑑設定項目区分１";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(24, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 15);
            this.label12.TabIndex = 74;
            this.label12.Text = "請求鑑タイトル８";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(24, 257);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 15);
            this.label13.TabIndex = 73;
            this.label13.Text = "請求鑑タイトル７";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb20
            // 
            this.tb20.Location = new System.Drawing.Point(416, 105);
            this.tb20.Name = "tb20";
            this.tb20.Size = new System.Drawing.Size(114, 19);
            this.tb20.TabIndex = 78;
            this.tb20.Text = "1";
            // 
            // tb19
            // 
            this.tb19.Location = new System.Drawing.Point(160, 505);
            this.tb19.Name = "tb19";
            this.tb19.Size = new System.Drawing.Size(114, 19);
            this.tb19.TabIndex = 77;
            this.tb19.Text = "1";
            // 
            // tb18
            // 
            this.tb18.Location = new System.Drawing.Point(160, 480);
            this.tb18.Name = "tb18";
            this.tb18.Size = new System.Drawing.Size(114, 19);
            this.tb18.TabIndex = 76;
            this.tb18.Text = "1";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(280, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 15);
            this.label15.TabIndex = 81;
            this.label15.Text = "支払鑑タイトル２";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(24, 507);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 15);
            this.label16.TabIndex = 80;
            this.label16.Text = "支払鑑タイトル１";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(24, 482);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 15);
            this.label17.TabIndex = 79;
            this.label17.Text = "請求鑑設定項目区分８";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb23
            // 
            this.tb23.Location = new System.Drawing.Point(416, 180);
            this.tb23.Name = "tb23";
            this.tb23.Size = new System.Drawing.Size(114, 19);
            this.tb23.TabIndex = 84;
            this.tb23.Text = "1";
            // 
            // tb22
            // 
            this.tb22.Location = new System.Drawing.Point(416, 155);
            this.tb22.Name = "tb22";
            this.tb22.Size = new System.Drawing.Size(114, 19);
            this.tb22.TabIndex = 83;
            this.tb22.Text = "1";
            // 
            // tb21
            // 
            this.tb21.Location = new System.Drawing.Point(416, 130);
            this.tb21.Name = "tb21";
            this.tb21.Size = new System.Drawing.Size(114, 19);
            this.tb21.TabIndex = 82;
            this.tb21.Text = "1";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(280, 182);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 15);
            this.label18.TabIndex = 87;
            this.label18.Text = "支払鑑タイトル５";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(280, 157);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 15);
            this.label19.TabIndex = 86;
            this.label19.Text = "支払鑑タイトル４";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(280, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 15);
            this.label20.TabIndex = 85;
            this.label20.Text = "支払鑑タイトル３";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb26
            // 
            this.tb26.Location = new System.Drawing.Point(416, 255);
            this.tb26.Name = "tb26";
            this.tb26.Size = new System.Drawing.Size(114, 19);
            this.tb26.TabIndex = 90;
            this.tb26.Text = "1";
            // 
            // tb25
            // 
            this.tb25.Location = new System.Drawing.Point(416, 230);
            this.tb25.Name = "tb25";
            this.tb25.Size = new System.Drawing.Size(114, 19);
            this.tb25.TabIndex = 89;
            this.tb25.Text = "1";
            // 
            // tb24
            // 
            this.tb24.Location = new System.Drawing.Point(416, 205);
            this.tb24.Name = "tb24";
            this.tb24.Size = new System.Drawing.Size(114, 19);
            this.tb24.TabIndex = 88;
            this.tb24.Text = "1";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(280, 257);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(130, 15);
            this.label21.TabIndex = 93;
            this.label21.Text = "支払鑑タイトル８";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(280, 231);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 15);
            this.label22.TabIndex = 92;
            this.label22.Text = "支払鑑タイトル７";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(280, 207);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(130, 15);
            this.label23.TabIndex = 91;
            this.label23.Text = "支払鑑タイトル６";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb29
            // 
            this.tb29.Location = new System.Drawing.Point(416, 330);
            this.tb29.Name = "tb29";
            this.tb29.Size = new System.Drawing.Size(114, 19);
            this.tb29.TabIndex = 96;
            this.tb29.Text = "1";
            // 
            // tb28
            // 
            this.tb28.Location = new System.Drawing.Point(416, 305);
            this.tb28.Name = "tb28";
            this.tb28.Size = new System.Drawing.Size(114, 19);
            this.tb28.TabIndex = 95;
            this.tb28.Text = "1";
            // 
            // tb27
            // 
            this.tb27.Location = new System.Drawing.Point(416, 280);
            this.tb27.Name = "tb27";
            this.tb27.Size = new System.Drawing.Size(114, 19);
            this.tb27.TabIndex = 94;
            this.tb27.Text = "1";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(280, 332);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(130, 15);
            this.label24.TabIndex = 99;
            this.label24.Text = "請求書コメント１";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(280, 307);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(130, 15);
            this.label25.TabIndex = 98;
            this.label25.Text = "支払通知書タイトル";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(280, 282);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(130, 15);
            this.label26.TabIndex = 97;
            this.label26.Text = "請求書タイトル";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb13
            // 
            this.tb13.Location = new System.Drawing.Point(160, 355);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(114, 19);
            this.tb13.TabIndex = 104;
            this.tb13.Text = "1";
            // 
            // tb31
            // 
            this.tb31.Location = new System.Drawing.Point(416, 380);
            this.tb31.Name = "tb31";
            this.tb31.Size = new System.Drawing.Size(114, 19);
            this.tb31.TabIndex = 103;
            this.tb31.Text = "1";
            // 
            // tb30
            // 
            this.tb30.Location = new System.Drawing.Point(416, 355);
            this.tb30.Name = "tb30";
            this.tb30.Size = new System.Drawing.Size(114, 19);
            this.tb30.TabIndex = 102;
            this.tb30.Text = "1";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(24, 357);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(130, 15);
            this.label27.TabIndex = 107;
            this.label27.Text = "請求鑑設定項目区分３";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(280, 382);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(130, 15);
            this.label28.TabIndex = 106;
            this.label28.Text = "請求書コメント３";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(280, 356);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(130, 15);
            this.label29.TabIndex = 105;
            this.label29.Text = "請求書コメント２";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb12
            // 
            this.tb12.Location = new System.Drawing.Point(160, 330);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(114, 19);
            this.tb12.TabIndex = 100;
            this.tb12.Text = "1";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(24, 330);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(130, 15);
            this.label30.TabIndex = 101;
            this.label30.Text = "請求鑑設定項目区分２";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb17
            // 
            this.tb17.Location = new System.Drawing.Point(160, 455);
            this.tb17.Name = "tb17";
            this.tb17.Size = new System.Drawing.Size(114, 19);
            this.tb17.TabIndex = 112;
            this.tb17.Text = "1";
            // 
            // tb16
            // 
            this.tb16.Location = new System.Drawing.Point(160, 430);
            this.tb16.Name = "tb16";
            this.tb16.Size = new System.Drawing.Size(114, 19);
            this.tb16.TabIndex = 111;
            this.tb16.Text = "1";
            // 
            // tb15
            // 
            this.tb15.Location = new System.Drawing.Point(160, 405);
            this.tb15.Name = "tb15";
            this.tb15.Size = new System.Drawing.Size(114, 19);
            this.tb15.TabIndex = 110;
            this.tb15.Text = "1";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(24, 457);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(130, 15);
            this.label31.TabIndex = 115;
            this.label31.Text = "請求鑑設定項目区分７";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(24, 430);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(130, 15);
            this.label32.TabIndex = 114;
            this.label32.Text = "請求鑑設定項目区分６";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(24, 406);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(130, 15);
            this.label33.TabIndex = 113;
            this.label33.Text = "請求鑑設定項目区分５";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb14
            // 
            this.tb14.Location = new System.Drawing.Point(160, 380);
            this.tb14.Name = "tb14";
            this.tb14.Size = new System.Drawing.Size(114, 19);
            this.tb14.TabIndex = 108;
            this.tb14.Text = "1";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(24, 382);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(130, 15);
            this.label34.TabIndex = 109;
            this.label34.Text = "請求鑑設定項目区分４";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb32
            // 
            this.tb32.Location = new System.Drawing.Point(416, 405);
            this.tb32.Name = "tb32";
            this.tb32.Size = new System.Drawing.Size(114, 19);
            this.tb32.TabIndex = 116;
            this.tb32.Text = "1";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(280, 408);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(130, 15);
            this.label35.TabIndex = 117;
            this.label35.Text = "請求書請求集計分類１";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb47
            // 
            this.tb47.Location = new System.Drawing.Point(672, 355);
            this.tb47.Name = "tb47";
            this.tb47.Size = new System.Drawing.Size(114, 19);
            this.tb47.TabIndex = 146;
            this.tb47.Text = "1";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(536, 357);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(130, 15);
            this.label36.TabIndex = 147;
            this.label36.Text = "マイナス請求印刷区分";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb46
            // 
            this.tb46.Location = new System.Drawing.Point(672, 330);
            this.tb46.Name = "tb46";
            this.tb46.Size = new System.Drawing.Size(114, 19);
            this.tb46.TabIndex = 143;
            this.tb46.Text = "1";
            // 
            // tb45
            // 
            this.tb45.Location = new System.Drawing.Point(672, 305);
            this.tb45.Name = "tb45";
            this.tb45.Size = new System.Drawing.Size(114, 19);
            this.tb45.TabIndex = 142;
            this.tb45.Text = "1";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(536, 332);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(130, 15);
            this.label37.TabIndex = 145;
            this.label37.Text = "支払明細単価ゼロ印字";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(536, 307);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(130, 15);
            this.label38.TabIndex = 144;
            this.label38.Text = "請求明細単価ゼロ印字";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb44
            // 
            this.tb44.Location = new System.Drawing.Point(672, 280);
            this.tb44.Name = "tb44";
            this.tb44.Size = new System.Drawing.Size(114, 19);
            this.tb44.TabIndex = 138;
            this.tb44.Text = "1";
            // 
            // tb43
            // 
            this.tb43.Location = new System.Drawing.Point(672, 255);
            this.tb43.Name = "tb43";
            this.tb43.Size = new System.Drawing.Size(114, 19);
            this.tb43.TabIndex = 137;
            this.tb43.Text = "1";
            // 
            // tb42
            // 
            this.tb42.Location = new System.Drawing.Point(672, 230);
            this.tb42.Name = "tb42";
            this.tb42.Size = new System.Drawing.Size(114, 19);
            this.tb42.TabIndex = 136;
            this.tb42.Text = "1";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(536, 282);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(130, 15);
            this.label39.TabIndex = 141;
            this.label39.Text = "今回請求額ゼロ印字";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(536, 257);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(130, 15);
            this.label40.TabIndex = 140;
            this.label40.Text = "支払明細単価出力有無";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(536, 231);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(130, 15);
            this.label41.TabIndex = 139;
            this.label41.Text = "請求明細単価出力有無";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb41
            // 
            this.tb41.Location = new System.Drawing.Point(672, 205);
            this.tb41.Name = "tb41";
            this.tb41.Size = new System.Drawing.Size(114, 19);
            this.tb41.TabIndex = 132;
            this.tb41.Text = "1";
            // 
            // tb40
            // 
            this.tb40.Location = new System.Drawing.Point(672, 180);
            this.tb40.Name = "tb40";
            this.tb40.Size = new System.Drawing.Size(114, 19);
            this.tb40.TabIndex = 131;
            this.tb40.Text = "1";
            // 
            // tb39
            // 
            this.tb39.Location = new System.Drawing.Point(672, 155);
            this.tb39.Name = "tb39";
            this.tb39.Size = new System.Drawing.Size(114, 19);
            this.tb39.TabIndex = 130;
            this.tb39.Text = "1";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(536, 207);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(130, 15);
            this.label42.TabIndex = 135;
            this.label42.Text = "支払集計デフォルト名称";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(536, 182);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(130, 15);
            this.label43.TabIndex = 134;
            this.label43.Text = "請求集計デフォルト名称";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(536, 157);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(130, 15);
            this.label44.TabIndex = 133;
            this.label44.Text = "請求書請求分類名称３";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb38
            // 
            this.tb38.Location = new System.Drawing.Point(672, 130);
            this.tb38.Name = "tb38";
            this.tb38.Size = new System.Drawing.Size(114, 19);
            this.tb38.TabIndex = 126;
            this.tb38.Text = "1";
            // 
            // tb37
            // 
            this.tb37.Location = new System.Drawing.Point(672, 105);
            this.tb37.Name = "tb37";
            this.tb37.Size = new System.Drawing.Size(114, 19);
            this.tb37.TabIndex = 125;
            this.tb37.Text = "1";
            // 
            // tb36
            // 
            this.tb36.Location = new System.Drawing.Point(416, 505);
            this.tb36.Name = "tb36";
            this.tb36.Size = new System.Drawing.Size(114, 19);
            this.tb36.TabIndex = 124;
            this.tb36.Text = "1";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(536, 132);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(130, 15);
            this.label45.TabIndex = 129;
            this.label45.Text = "請求書請求分類名称２";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(536, 107);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(130, 15);
            this.label46.TabIndex = 128;
            this.label46.Text = "請求書支払集計分類３";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(280, 507);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(130, 15);
            this.label47.TabIndex = 127;
            this.label47.Text = "請求書支払集計分類２";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb35
            // 
            this.tb35.Location = new System.Drawing.Point(416, 480);
            this.tb35.Name = "tb35";
            this.tb35.Size = new System.Drawing.Size(114, 19);
            this.tb35.TabIndex = 120;
            this.tb35.Text = "1";
            // 
            // tb34
            // 
            this.tb34.Location = new System.Drawing.Point(416, 455);
            this.tb34.Name = "tb34";
            this.tb34.Size = new System.Drawing.Size(114, 19);
            this.tb34.TabIndex = 119;
            this.tb34.Text = "1";
            // 
            // tb33
            // 
            this.tb33.Location = new System.Drawing.Point(416, 430);
            this.tb33.Name = "tb33";
            this.tb33.Size = new System.Drawing.Size(114, 19);
            this.tb33.TabIndex = 118;
            this.tb33.Text = "1";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(280, 482);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(130, 15);
            this.label48.TabIndex = 123;
            this.label48.Text = "請求書支払集計分類１";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(280, 457);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(130, 15);
            this.label49.TabIndex = 122;
            this.label49.Text = "請求書請求集計分類３";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(280, 432);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(130, 15);
            this.label50.TabIndex = 121;
            this.label50.Text = "請求書請求集計分類２";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb62
            // 
            this.tb62.Location = new System.Drawing.Point(928, 305);
            this.tb62.Name = "tb62";
            this.tb62.Size = new System.Drawing.Size(114, 19);
            this.tb62.TabIndex = 176;
            this.tb62.Text = "1";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(792, 311);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(130, 15);
            this.label51.TabIndex = 177;
            this.label51.Text = "強制支払出力商品４";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb61
            // 
            this.tb61.Location = new System.Drawing.Point(928, 280);
            this.tb61.Name = "tb61";
            this.tb61.Size = new System.Drawing.Size(114, 19);
            this.tb61.TabIndex = 173;
            this.tb61.Text = "1";
            // 
            // tb60
            // 
            this.tb60.Location = new System.Drawing.Point(928, 255);
            this.tb60.Name = "tb60";
            this.tb60.Size = new System.Drawing.Size(114, 19);
            this.tb60.TabIndex = 172;
            this.tb60.Text = "1";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(792, 285);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(130, 15);
            this.label52.TabIndex = 175;
            this.label52.Text = "強制支払出力商品３";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(792, 260);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(130, 15);
            this.label53.TabIndex = 174;
            this.label53.Text = "強制支払出力商品２";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb59
            // 
            this.tb59.Location = new System.Drawing.Point(928, 230);
            this.tb59.Name = "tb59";
            this.tb59.Size = new System.Drawing.Size(114, 19);
            this.tb59.TabIndex = 168;
            this.tb59.Text = "1";
            // 
            // tb58
            // 
            this.tb58.Location = new System.Drawing.Point(928, 205);
            this.tb58.Name = "tb58";
            this.tb58.Size = new System.Drawing.Size(114, 19);
            this.tb58.TabIndex = 167;
            this.tb58.Text = "1";
            // 
            // tb57
            // 
            this.tb57.Location = new System.Drawing.Point(928, 180);
            this.tb57.Name = "tb57";
            this.tb57.Size = new System.Drawing.Size(114, 19);
            this.tb57.TabIndex = 166;
            this.tb57.Text = "1";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(792, 235);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(130, 15);
            this.label54.TabIndex = 171;
            this.label54.Text = "強制支払出力商品１";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(792, 209);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(130, 15);
            this.label55.TabIndex = 170;
            this.label55.Text = "強制請求出力商品１０";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(792, 184);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(130, 15);
            this.label56.TabIndex = 169;
            this.label56.Text = "強制請求出力商品９";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb56
            // 
            this.tb56.Location = new System.Drawing.Point(928, 155);
            this.tb56.Name = "tb56";
            this.tb56.Size = new System.Drawing.Size(114, 19);
            this.tb56.TabIndex = 162;
            this.tb56.Text = "1";
            // 
            // tb55
            // 
            this.tb55.Location = new System.Drawing.Point(928, 130);
            this.tb55.Name = "tb55";
            this.tb55.Size = new System.Drawing.Size(114, 19);
            this.tb55.TabIndex = 161;
            this.tb55.Text = "1";
            // 
            // tb54
            // 
            this.tb54.Location = new System.Drawing.Point(928, 105);
            this.tb54.Name = "tb54";
            this.tb54.Size = new System.Drawing.Size(114, 19);
            this.tb54.TabIndex = 160;
            this.tb54.Text = "1";
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(792, 156);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(130, 15);
            this.label57.TabIndex = 165;
            this.label57.Text = "強制請求出力商品８";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(792, 130);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(130, 15);
            this.label58.TabIndex = 164;
            this.label58.Text = "強制請求出力商品７";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(792, 107);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(130, 15);
            this.label59.TabIndex = 163;
            this.label59.Text = "強制請求出力商品６";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb53
            // 
            this.tb53.Location = new System.Drawing.Point(672, 505);
            this.tb53.Name = "tb53";
            this.tb53.Size = new System.Drawing.Size(114, 19);
            this.tb53.TabIndex = 156;
            this.tb53.Text = "1";
            // 
            // tb52
            // 
            this.tb52.Location = new System.Drawing.Point(672, 480);
            this.tb52.Name = "tb52";
            this.tb52.Size = new System.Drawing.Size(114, 19);
            this.tb52.TabIndex = 155;
            this.tb52.Text = "1";
            // 
            // tb51
            // 
            this.tb51.Location = new System.Drawing.Point(672, 455);
            this.tb51.Name = "tb51";
            this.tb51.Size = new System.Drawing.Size(114, 19);
            this.tb51.TabIndex = 154;
            this.tb51.Text = "1";
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(536, 507);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(130, 15);
            this.label60.TabIndex = 159;
            this.label60.Text = "強制請求出力商品５";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(536, 482);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(130, 15);
            this.label61.TabIndex = 158;
            this.label61.Text = "強制請求出力商品４";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(536, 457);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(130, 15);
            this.label62.TabIndex = 157;
            this.label62.Text = "強制請求出力商品３";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb50
            // 
            this.tb50.Location = new System.Drawing.Point(672, 430);
            this.tb50.Name = "tb50";
            this.tb50.Size = new System.Drawing.Size(114, 19);
            this.tb50.TabIndex = 150;
            this.tb50.Text = "1";
            // 
            // tb49
            // 
            this.tb49.Location = new System.Drawing.Point(672, 405);
            this.tb49.Name = "tb49";
            this.tb49.Size = new System.Drawing.Size(114, 19);
            this.tb49.TabIndex = 149;
            this.tb49.Text = "1";
            // 
            // tb48
            // 
            this.tb48.Location = new System.Drawing.Point(672, 380);
            this.tb48.Name = "tb48";
            this.tb48.Size = new System.Drawing.Size(114, 19);
            this.tb48.TabIndex = 148;
            this.tb48.Text = "1";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(536, 432);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(130, 15);
            this.label63.TabIndex = 153;
            this.label63.Text = "強制請求出力商品２";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(536, 407);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(130, 15);
            this.label64.TabIndex = 152;
            this.label64.Text = "強制請求出力商品１";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(536, 382);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(130, 15);
            this.label65.TabIndex = 151;
            this.label65.Text = "請求書入金集計明細印字";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb66
            // 
            this.tb66.Location = new System.Drawing.Point(928, 405);
            this.tb66.Name = "tb66";
            this.tb66.Size = new System.Drawing.Size(114, 19);
            this.tb66.TabIndex = 184;
            this.tb66.Text = "1";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(792, 409);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(130, 15);
            this.label66.TabIndex = 185;
            this.label66.Text = "強制支払出力商品８";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb65
            // 
            this.tb65.Location = new System.Drawing.Point(928, 380);
            this.tb65.Name = "tb65";
            this.tb65.Size = new System.Drawing.Size(114, 19);
            this.tb65.TabIndex = 181;
            this.tb65.Text = "1";
            // 
            // tb64
            // 
            this.tb64.Location = new System.Drawing.Point(928, 355);
            this.tb64.Name = "tb64";
            this.tb64.Size = new System.Drawing.Size(114, 19);
            this.tb64.TabIndex = 180;
            this.tb64.Text = "1";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(792, 383);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(130, 15);
            this.label67.TabIndex = 183;
            this.label67.Text = "強制支払出力商品７";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(792, 358);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(130, 15);
            this.label68.TabIndex = 182;
            this.label68.Text = "強制支払出力商品６";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb63
            // 
            this.tb63.Location = new System.Drawing.Point(928, 330);
            this.tb63.Name = "tb63";
            this.tb63.Size = new System.Drawing.Size(114, 19);
            this.tb63.TabIndex = 178;
            this.tb63.Text = "1";
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(792, 333);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(130, 15);
            this.label69.TabIndex = 179;
            this.label69.Text = "強制支払出力商品５";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb69
            // 
            this.tb69.Location = new System.Drawing.Point(928, 480);
            this.tb69.Name = "tb69";
            this.tb69.Size = new System.Drawing.Size(114, 19);
            this.tb69.TabIndex = 190;
            this.tb69.Text = "1";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(792, 482);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(130, 15);
            this.label70.TabIndex = 191;
            this.label70.Text = "機種別インセンティブ出力";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb68
            // 
            this.tb68.Location = new System.Drawing.Point(928, 455);
            this.tb68.Name = "tb68";
            this.tb68.Size = new System.Drawing.Size(114, 19);
            this.tb68.TabIndex = 187;
            this.tb68.Text = "1";
            // 
            // tb67
            // 
            this.tb67.Location = new System.Drawing.Point(928, 430);
            this.tb67.Name = "tb67";
            this.tb67.Size = new System.Drawing.Size(114, 19);
            this.tb67.TabIndex = 186;
            this.tb67.Text = "1";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(792, 459);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(130, 15);
            this.label71.TabIndex = 189;
            this.label71.Text = "強制支払出力商品１０";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(792, 434);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(130, 15);
            this.label72.TabIndex = 188;
            this.label72.Text = "強制支払出力商品９";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb70
            // 
            this.tb70.Location = new System.Drawing.Point(280, 58);
            this.tb70.Name = "tb70";
            this.tb70.Size = new System.Drawing.Size(114, 19);
            this.tb70.TabIndex = 192;
            this.tb70.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1066, 730);
            this.Controls.Add(this.tb70);
            this.Controls.Add(this.tb69);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.tb68);
            this.Controls.Add(this.tb67);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.tb66);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.tb65);
            this.Controls.Add(this.tb64);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.tb63);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.tb62);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.tb61);
            this.Controls.Add(this.tb60);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.tb59);
            this.Controls.Add(this.tb58);
            this.Controls.Add(this.tb57);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.tb56);
            this.Controls.Add(this.tb55);
            this.Controls.Add(this.tb54);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.tb53);
            this.Controls.Add(this.tb52);
            this.Controls.Add(this.tb51);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.tb50);
            this.Controls.Add(this.tb49);
            this.Controls.Add(this.tb48);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.tb47);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.tb46);
            this.Controls.Add(this.tb45);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.tb44);
            this.Controls.Add(this.tb43);
            this.Controls.Add(this.tb42);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.tb41);
            this.Controls.Add(this.tb40);
            this.Controls.Add(this.tb39);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.tb38);
            this.Controls.Add(this.tb37);
            this.Controls.Add(this.tb36);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.tb35);
            this.Controls.Add(this.tb34);
            this.Controls.Add(this.tb33);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.tb32);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.tb17);
            this.Controls.Add(this.tb16);
            this.Controls.Add(this.tb15);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.tb14);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.tb31);
            this.Controls.Add(this.tb30);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tb12);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tb29);
            this.Controls.Add(this.tb28);
            this.Controls.Add(this.tb27);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tb26);
            this.Controls.Add(this.tb25);
            this.Controls.Add(this.tb24);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tb23);
            this.Controls.Add(this.tb22);
            this.Controls.Add(this.tb21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tb20);
            this.Controls.Add(this.tb19);
            this.Controls.Add(this.tb18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.Revival_Button);
            this.Controls.Add(this.LogicalDelete_Button);
            this.Controls.Add(this.Read_Button);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LogicalDeletetextBox);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Write_Button);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

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
				int status =  ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"SFCMN09000U",ex.Message,0,MessageBoxButtons.OK);
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
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile , false);
            IdmdPrtPtnDB = MediationDmdPrtPtnDB.GetDmdPrtPtnDB();
		}

        private void Read_Button_Click(object sender, EventArgs e)
        {
            if (dmdPrtPtnWork == null) dmdPrtPtnWork = new DmdPrtPtnWork();

            dmdPrtPtnWork.EnterpriseCode = tb1.Text;
            dmdPrtPtnWork.DataInputSystem = 0;
            dmdPrtPtnWork.SlipPrtKind = 0;
            dmdPrtPtnWork.SlipPrtSetPaperId = tb2.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
            int status = IdmdPrtPtnDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));

                Text = "該当データ有り";

                //tb1.Text = dmdPrtPtnWork.EnterpriseCode;
                //tb2.Text = dmdPrtPtnWork.DemandPtnNo.ToString();
                //tb3.Text = dmdPrtPtnWork.DmdTtlFormTitle1;
                //tb4.Text = dmdPrtPtnWork.DmdTtlFormTitle2;
                //tb5.Text = dmdPrtPtnWork.DmdTtlFormTitle3;
                //tb6.Text = dmdPrtPtnWork.DmdTtlFormTitle4;
                //tb7.Text = dmdPrtPtnWork.DmdTtlFormTitle5;
                //tb8.Text = dmdPrtPtnWork.DmdTtlFormTitle6;
                //tb9.Text = dmdPrtPtnWork.DmdTtlFormTitle7;
                //tb10.Text = dmdPrtPtnWork.DmdTtlFormTitle8;
                //tb11.Text = dmdPrtPtnWork.DmdTtlSetItemDiv1.ToString();
                //tb12.Text = dmdPrtPtnWork.DmdTtlSetItemDiv2.ToString();
                //tb13.Text = dmdPrtPtnWork.DmdTtlSetItemDiv3.ToString();
                //tb14.Text = dmdPrtPtnWork.DmdTtlSetItemDiv4.ToString();
                //tb15.Text = dmdPrtPtnWork.DmdTtlSetItemDiv5.ToString();
                //tb16.Text = dmdPrtPtnWork.DmdTtlSetItemDiv6.ToString();
                //tb17.Text = dmdPrtPtnWork.DmdTtlSetItemDiv7.ToString();
                //tb18.Text = dmdPrtPtnWork.DmdTtlSetItemDiv8.ToString();
                //tb19.Text = dmdPrtPtnWork.PayTtlFormTitle1;
                //tb20.Text = dmdPrtPtnWork.PayTtlFormTitle2;
                //tb21.Text = dmdPrtPtnWork.PayTtlFormTitle3;
                //tb22.Text = dmdPrtPtnWork.PayTtlFormTitle4;
                //tb23.Text = dmdPrtPtnWork.PayTtlFormTitle5;
                //tb24.Text = dmdPrtPtnWork.PayTtlFormTitle6;
                //tb25.Text = dmdPrtPtnWork.PayTtlFormTitle7;
                //tb26.Text = dmdPrtPtnWork.PayTtlFormTitle8;
                //tb27.Text = dmdPrtPtnWork.DmdFormTitle;
                //tb28.Text = dmdPrtPtnWork.PaymentFormTitle;
                //tb29.Text = dmdPrtPtnWork.DmdFormComent1;
                //tb30.Text = dmdPrtPtnWork.DmdFormComent2;
                //tb31.Text = dmdPrtPtnWork.DmdFormComent3;
                //tb32.Text = dmdPrtPtnWork.DmdFmDmdTtlGenCd1.ToString();
                //tb33.Text = dmdPrtPtnWork.DmdFmDmdTtlGenCd2.ToString();
                //tb34.Text = dmdPrtPtnWork.DmdFmDmdTtlGenCd3.ToString();
                //tb35.Text = dmdPrtPtnWork.DmdFmPayTtlGenCd1.ToString();
                //tb36.Text = dmdPrtPtnWork.DmdFmPayTtlGenCd2.ToString();
                //tb37.Text = dmdPrtPtnWork.DmdFmPayTtlGenCd3.ToString();
                //tb38.Text = dmdPrtPtnWork.DmdFmDmdTtlGenNm2;
                //tb39.Text = dmdPrtPtnWork.DmdFmDmdTtlGenNm3;
                //tb40.Text = dmdPrtPtnWork.DmdTtlGenDefltNm;
                //tb41.Text = dmdPrtPtnWork.PayTtlGenDefltNm;
                //tb42.Text = dmdPrtPtnWork.DmdDtlUnitPrtDiv.ToString();
                //tb43.Text = dmdPrtPtnWork.PayDtlUnitPrtDiv.ToString();
                //tb44.Text = dmdPrtPtnWork.ThTmDmdZeroPrtDiv.ToString();
                //tb45.Text = dmdPrtPtnWork.DmdDtlPrcZeroPrtDiv.ToString();
                //tb46.Text = dmdPrtPtnWork.PayDtlPrcZeroPrtDiv.ToString();
                //tb47.Text = dmdPrtPtnWork.MinusDmdPrtDiv.ToString();
                //tb48.Text = dmdPrtPtnWork.DmdFmDepoTtlPrtDiv.ToString();
                //tb49.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd1;
                //tb50.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd2;
                //tb51.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd3;
                //tb52.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd4;
                //tb53.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd5;
                //tb54.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd6;
                //tb55.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd7;
                //tb56.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd8;
                //tb57.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd9;
                //tb58.Text = dmdPrtPtnWork.CmplDmdMdGoodsCd10;
                //tb59.Text = dmdPrtPtnWork.CmplPayMdGoodsCd1;
                //tb60.Text = dmdPrtPtnWork.CmplPayMdGoodsCd2;
                //tb61.Text = dmdPrtPtnWork.CmplPayMdGoodsCd3;
                //tb62.Text = dmdPrtPtnWork.CmplPayMdGoodsCd4;
                //tb63.Text = dmdPrtPtnWork.CmplPayMdGoodsCd5;
                //tb64.Text = dmdPrtPtnWork.CmplPayMdGoodsCd6;
                //tb65.Text = dmdPrtPtnWork.CmplPayMdGoodsCd7;
                //tb66.Text = dmdPrtPtnWork.CmplPayMdGoodsCd8;
                //tb67.Text = dmdPrtPtnWork.CmplPayMdGoodsCd9;
                //tb68.Text = dmdPrtPtnWork.CmplPayMdGoodsCd10;
                ////tb69.Text = dmdPrtPtnWork.CellphoneIncOutDiv.ToString();  // 2007.09.18 hikita del
                //tb70.Text = dmdPrtPtnWork.DemandPtnNoNm;

                LogicalDeletetextBox.Text = dmdPrtPtnWork.LogicalDeleteCode.ToString();
            }
        }

        private void SearchA_Button_Click(object sender, System.EventArgs e)
        {
            ArrayList paraarray = new ArrayList();

            DmdPrtPtnWork　bsmkstdstuWork = new DmdPrtPtnWork();
            bsmkstdstuWork.EnterpriseCode = tb1.Text;

            object paraobj = bsmkstdstuWork;
            object retobj = null;

            int status = IdmdPrtPtnDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";

                dataGrid1.DataSource = retobj;
            }
        }

        private void Write_Button_Click(object sender, System.EventArgs e)
		{
            if (dmdPrtPtnWork == null) dmdPrtPtnWork = new DmdPrtPtnWork();

            dmdPrtPtnWork.EnterpriseCode = tb1.Text;
            //dmdPrtPtnWork.DemandPtnNo = Convert.ToInt32(tb2.Text);
            //dmdPrtPtnWork.DmdTtlFormTitle1 = tb3.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle2 = tb4.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle3 = tb5.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle4 = tb6.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle5 = tb7.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle6 = tb8.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle7 = tb9.Text;
            //dmdPrtPtnWork.DmdTtlFormTitle8 = tb10.Text;
            //dmdPrtPtnWork.DmdTtlSetItemDiv1 = Convert.ToInt32(tb11.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv2 = Convert.ToInt32(tb12.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv3 = Convert.ToInt32(tb13.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv4 = Convert.ToInt32(tb14.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv5 = Convert.ToInt32(tb15.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv6 = Convert.ToInt32(tb16.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv7 = Convert.ToInt32(tb17.Text);
            //dmdPrtPtnWork.DmdTtlSetItemDiv8 = Convert.ToInt32(tb18.Text);
            //dmdPrtPtnWork.PayTtlFormTitle1 = tb19.Text;
            //dmdPrtPtnWork.PayTtlFormTitle2 = tb20.Text;
            //dmdPrtPtnWork.PayTtlFormTitle3 = tb21.Text;
            //dmdPrtPtnWork.PayTtlFormTitle4 = tb22.Text;
            //dmdPrtPtnWork.PayTtlFormTitle5 = tb23.Text;
            //dmdPrtPtnWork.PayTtlFormTitle6 = tb24.Text;
            //dmdPrtPtnWork.PayTtlFormTitle7 = tb25.Text;
            //dmdPrtPtnWork.PayTtlFormTitle8 = tb26.Text;
            //dmdPrtPtnWork.DmdFormTitle = tb27.Text;
            //dmdPrtPtnWork.PaymentFormTitle = tb28.Text;
            //dmdPrtPtnWork.DmdFormComent1 = tb29.Text;
            //dmdPrtPtnWork.DmdFormComent2 = tb30.Text;
            //dmdPrtPtnWork.DmdFormComent3 = tb31.Text;
            //dmdPrtPtnWork.DmdFmDmdTtlGenCd1 = Convert.ToInt32(tb32.Text);
            //dmdPrtPtnWork.DmdFmDmdTtlGenCd2 = Convert.ToInt32(tb33.Text);
            //dmdPrtPtnWork.DmdFmDmdTtlGenCd3 = Convert.ToInt32(tb34.Text);
            //dmdPrtPtnWork.DmdFmPayTtlGenCd1 = Convert.ToInt32(tb35.Text);
            //dmdPrtPtnWork.DmdFmPayTtlGenCd2 = Convert.ToInt32(tb36.Text);
            //dmdPrtPtnWork.DmdFmPayTtlGenCd3 = Convert.ToInt32(tb37.Text);
            //dmdPrtPtnWork.DmdFmDmdTtlGenNm2 = tb38.Text;
            //dmdPrtPtnWork.DmdFmDmdTtlGenNm3 = tb39.Text;
            //dmdPrtPtnWork.DmdTtlGenDefltNm = tb40.Text;
            //dmdPrtPtnWork.PayTtlGenDefltNm = tb41.Text;
            //dmdPrtPtnWork.DmdDtlUnitPrtDiv = Convert.ToInt32(tb42.Text);
            //dmdPrtPtnWork.PayDtlUnitPrtDiv = Convert.ToInt32(tb43.Text);
            //dmdPrtPtnWork.ThTmDmdZeroPrtDiv = Convert.ToInt32(tb44.Text);
            //dmdPrtPtnWork.DmdDtlPrcZeroPrtDiv = Convert.ToInt32(tb45.Text);
            //dmdPrtPtnWork.PayDtlPrcZeroPrtDiv = Convert.ToInt32(tb46.Text);
            //dmdPrtPtnWork.MinusDmdPrtDiv = Convert.ToInt32(tb47.Text);
            //dmdPrtPtnWork.DmdFmDepoTtlPrtDiv = Convert.ToInt32(tb48.Text);
            //dmdPrtPtnWork.CmplDmdMdGoodsCd1 = tb49.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd2 = tb50.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd3 = tb51.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd4 = tb52.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd5 = tb53.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd6 = tb54.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd7 = tb55.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd8 = tb56.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd9 = tb57.Text;
            //dmdPrtPtnWork.CmplDmdMdGoodsCd10 = tb58.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd1 = tb59.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd2 = tb60.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd3 = tb61.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd4 = tb62.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd5 = tb63.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd6 = tb64.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd7 = tb65.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd8 = tb66.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd9 = tb67.Text;
            //dmdPrtPtnWork.CmplPayMdGoodsCd10 = tb68.Text;
            //// dmdPrtPtnWork.CellphoneIncOutDiv = Convert.ToInt32(tb69.Text);  // 2007.09.18 hikita del
            //dmdPrtPtnWork.DemandPtnNoNm = tb70.Text;

			byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
			int status = IdmdPrtPtnDB.Write(ref parabyte);
            
			if (status != 0)
			{
				Text = "更新失敗";
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
                else
                {
                    MessageBox.Show("更新失敗：status=" + status.ToString());
                }
			}
			else
			{
				Text = "更新成功";
                dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));
			}
		}

        private void LogicalDelete_Button_Click(object sender, EventArgs e)
        {
            if (dmdPrtPtnWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
                int status = IdmdPrtPtnDB.LogicalDelete(ref parabyte);
                if (status != 0)
                {
                    Text = "削除失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("削除失敗：status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "削除成功";
                    dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));
                    LogicalDeletetextBox.Text = dmdPrtPtnWork.LogicalDeleteCode.ToString();
                }
            }
            else
            {
                MessageBox.Show("LogicalDelete対象データが読み込まれていません");
            }
        }

        private void Revival_Button_Click(object sender, EventArgs e)
        {
            if (dmdPrtPtnWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
                int status = IdmdPrtPtnDB.Revival(ref parabyte);
                if (status != 0)
                {
                    Text = "復活失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("復活失敗　status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "復活成功";
                    dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));
                    LogicalDeletetextBox.Text = dmdPrtPtnWork.LogicalDeleteCode.ToString();
                }
            }
            else
            {
                MessageBox.Show("Revival対象データが読み込まれていません");
            }
        }

        private void Delete_Button_Click(object sender, System.EventArgs e)
        { 
        
            if (dmdPrtPtnWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
                int status = IdmdPrtPtnDB.Delete(parabyte);
                if (status != 0)
                {
                    Text = "削除失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("削除失敗：status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "削除成功";
                }
            }
            else
            {
                MessageBox.Show("Delete対象データが読み込まれていません");
            }
        }

        private void Clear_Button_Click(object sender, System.EventArgs e)
		{
			dmdPrtPtnWork = null;
			dataGrid1.DataSource = null;
		}
	}
}

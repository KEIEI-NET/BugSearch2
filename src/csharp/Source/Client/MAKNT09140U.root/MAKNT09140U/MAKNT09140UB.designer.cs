namespace Broadleaf.Windows.Forms
{
    partial class Calendar_Control
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.PreviousYear_Button = new Infragistics.Win.Misc.UltraButton();
            this.NextYear_Button = new Infragistics.Win.Misc.UltraButton();
            this.Year_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.January_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.February_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.March_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.April_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.May_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.June_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.July_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.August_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.September_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.October_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.November_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.December_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.January_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.February_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.March_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.April_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.May_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.June_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.July_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.August_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.September_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.October_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.November_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.December_uGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousYear_Button
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.PreviousYear_Button.Appearance = appearance1;
            this.PreviousYear_Button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.PreviousYear_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PreviousYear_Button.Location = new System.Drawing.Point(190, 2);
            this.PreviousYear_Button.Margin = new System.Windows.Forms.Padding(0);
            this.PreviousYear_Button.Name = "PreviousYear_Button";
            this.PreviousYear_Button.ShowOutline = false;
            this.PreviousYear_Button.Size = new System.Drawing.Size(75, 23);
            this.PreviousYear_Button.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.PreviousYear_Button.TabIndex = 3;
            this.PreviousYear_Button.Click += new System.EventHandler(this.PreviousYear_Button_Click);
            // 
            // NextYear_Button
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.NextYear_Button.Appearance = appearance2;
            this.NextYear_Button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.NextYear_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NextYear_Button.Location = new System.Drawing.Point(485, 2);
            this.NextYear_Button.Margin = new System.Windows.Forms.Padding(0);
            this.NextYear_Button.Name = "NextYear_Button";
            this.NextYear_Button.ShowOutline = false;
            this.NextYear_Button.Size = new System.Drawing.Size(75, 23);
            this.NextYear_Button.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.NextYear_Button.TabIndex = 4;
            this.NextYear_Button.Click += new System.EventHandler(this.NextYear_Button_Click);
            // 
            // Year_uLabel
            // 
            appearance3.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Year_uLabel.Appearance = appearance3;
            this.Year_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Year_uLabel.Location = new System.Drawing.Point(313, -2);
            this.Year_uLabel.Margin = new System.Windows.Forms.Padding(0);
            this.Year_uLabel.Name = "Year_uLabel";
            this.Year_uLabel.Size = new System.Drawing.Size(133, 34);
            this.Year_uLabel.TabIndex = 15;
            this.Year_uLabel.Text = "2007年";
            // 
            // January_uGrid
            // 
            this.January_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.January_uGrid.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.January_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.January_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.January_uGrid.Location = new System.Drawing.Point(0, 34);
            this.January_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.January_uGrid.Name = "January_uGrid";
            this.January_uGrid.Size = new System.Drawing.Size(180, 158);
            this.January_uGrid.TabIndex = 5;
            this.January_uGrid.Text = "ultraGrid1";
            this.January_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.January_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // February_uGrid
            // 
            this.February_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.February_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.February_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.February_uGrid.Location = new System.Drawing.Point(190, 34);
            this.February_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.February_uGrid.Name = "February_uGrid";
            this.February_uGrid.Size = new System.Drawing.Size(180, 158);
            this.February_uGrid.TabIndex = 6;
            this.February_uGrid.Text = "ultraGrid1";
            this.February_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.February_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // March_uGrid
            // 
            this.March_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.March_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.March_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.March_uGrid.Location = new System.Drawing.Point(380, 34);
            this.March_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.March_uGrid.Name = "March_uGrid";
            this.March_uGrid.Size = new System.Drawing.Size(180, 158);
            this.March_uGrid.TabIndex = 7;
            this.March_uGrid.Text = "ultraGrid1";
            this.March_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.March_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // April_uGrid
            // 
            this.April_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.April_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.April_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.April_uGrid.Location = new System.Drawing.Point(570, 34);
            this.April_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.April_uGrid.Name = "April_uGrid";
            this.April_uGrid.Size = new System.Drawing.Size(180, 158);
            this.April_uGrid.TabIndex = 8;
            this.April_uGrid.Text = "ultraGrid1";
            this.April_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.April_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // May_uGrid
            // 
            this.May_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.May_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.May_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.May_uGrid.Location = new System.Drawing.Point(0, 203);
            this.May_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.May_uGrid.Name = "May_uGrid";
            this.May_uGrid.Size = new System.Drawing.Size(180, 158);
            this.May_uGrid.TabIndex = 9;
            this.May_uGrid.Text = "ultraGrid1";
            this.May_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.May_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // June_uGrid
            // 
            this.June_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.June_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.June_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.June_uGrid.Location = new System.Drawing.Point(190, 203);
            this.June_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.June_uGrid.Name = "June_uGrid";
            this.June_uGrid.Size = new System.Drawing.Size(180, 158);
            this.June_uGrid.TabIndex = 10;
            this.June_uGrid.Text = "ultraGrid1";
            this.June_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.June_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // July_uGrid
            // 
            this.July_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.July_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.July_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.July_uGrid.Location = new System.Drawing.Point(380, 203);
            this.July_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.July_uGrid.Name = "July_uGrid";
            this.July_uGrid.Size = new System.Drawing.Size(180, 158);
            this.July_uGrid.TabIndex = 11;
            this.July_uGrid.Text = "ultraGrid1";
            this.July_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.July_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // August_uGrid
            // 
            this.August_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.August_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.August_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.August_uGrid.Location = new System.Drawing.Point(570, 203);
            this.August_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.August_uGrid.Name = "August_uGrid";
            this.August_uGrid.Size = new System.Drawing.Size(180, 158);
            this.August_uGrid.TabIndex = 12;
            this.August_uGrid.Text = "ultraGrid1";
            this.August_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.August_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // September_uGrid
            // 
            this.September_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.September_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.September_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.September_uGrid.Location = new System.Drawing.Point(0, 372);
            this.September_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.September_uGrid.Name = "September_uGrid";
            this.September_uGrid.Size = new System.Drawing.Size(180, 158);
            this.September_uGrid.TabIndex = 13;
            this.September_uGrid.Text = "ultraGrid1";
            this.September_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.September_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // October_uGrid
            // 
            this.October_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.October_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.October_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.October_uGrid.Location = new System.Drawing.Point(190, 372);
            this.October_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.October_uGrid.Name = "October_uGrid";
            this.October_uGrid.Size = new System.Drawing.Size(180, 158);
            this.October_uGrid.TabIndex = 14;
            this.October_uGrid.Text = "ultraGrid1";
            this.October_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.October_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // November_uGrid
            // 
            this.November_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.November_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.November_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.November_uGrid.Location = new System.Drawing.Point(380, 372);
            this.November_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.November_uGrid.Name = "November_uGrid";
            this.November_uGrid.Size = new System.Drawing.Size(180, 158);
            this.November_uGrid.TabIndex = 15;
            this.November_uGrid.Text = "ultraGrid1";
            this.November_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.November_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // December_uGrid
            // 
            this.December_uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.December_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.December_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.December_uGrid.Location = new System.Drawing.Point(570, 372);
            this.December_uGrid.Margin = new System.Windows.Forms.Padding(0);
            this.December_uGrid.Name = "December_uGrid";
            this.December_uGrid.Size = new System.Drawing.Size(180, 158);
            this.December_uGrid.TabIndex = 16;
            this.December_uGrid.Text = "ultraGrid1";
            this.December_uGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.January_uGrid_MouseDown);
            this.December_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.January_uGrid_KeyDown);
            // 
            // Calendar_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.December_uGrid);
            this.Controls.Add(this.November_uGrid);
            this.Controls.Add(this.October_uGrid);
            this.Controls.Add(this.September_uGrid);
            this.Controls.Add(this.August_uGrid);
            this.Controls.Add(this.July_uGrid);
            this.Controls.Add(this.June_uGrid);
            this.Controls.Add(this.May_uGrid);
            this.Controls.Add(this.April_uGrid);
            this.Controls.Add(this.March_uGrid);
            this.Controls.Add(this.February_uGrid);
            this.Controls.Add(this.January_uGrid);
            this.Controls.Add(this.Year_uLabel);
            this.Controls.Add(this.NextYear_Button);
            this.Controls.Add(this.PreviousYear_Button);
            this.Name = "Calendar_Control";
            this.Size = new System.Drawing.Size(749, 541);
            this.Load += new System.EventHandler(this.Calendar_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.January_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.February_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.March_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.April_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.May_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.June_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.July_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.August_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.September_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.October_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.November_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.December_uGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton PreviousYear_Button;
        private Infragistics.Win.Misc.UltraButton NextYear_Button;
        private Infragistics.Win.Misc.UltraLabel Year_uLabel;
        public Infragistics.Win.UltraWinGrid.UltraGrid January_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid February_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid March_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid April_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid May_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid June_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid July_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid August_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid September_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid October_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid November_uGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid December_uGrid;
    }
}

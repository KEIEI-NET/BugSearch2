namespace Broadleaf.Windows.Forms
{
    partial class SFNETMENU2C
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFNETMENU2C));
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.lblUserSubCategory = new System.Windows.Forms.Label();
            this.btnSubNameChange = new System.Windows.Forms.Button();
            this.btnSubDelete = new System.Windows.Forms.Button();
            this.btnSubAdd = new System.Windows.Forms.Button();
            this.lstUserSubCategroy = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lblUserItem = new System.Windows.Forms.Label();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.lstItem = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.barSub = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.barSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.IsSplitterFixed = true;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.lblUserSubCategory);
            this.spltMain.Panel1.Controls.Add(this.btnSubNameChange);
            this.spltMain.Panel1.Controls.Add(this.btnSubDelete);
            this.spltMain.Panel1.Controls.Add(this.btnSubAdd);
            this.spltMain.Panel1.Controls.Add(this.lstUserSubCategroy);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.lblUserItem);
            this.spltMain.Panel2.Controls.Add(this.btnItemDelete);
            this.spltMain.Panel2.Controls.Add(this.btnItemAdd);
            this.spltMain.Panel2.Controls.Add(this.lstItem);
            this.spltMain.Size = new System.Drawing.Size(944, 468);
            this.spltMain.SplitterDistance = 355;
            this.spltMain.TabIndex = 7;
            // 
            // lblUserSubCategory
            // 
            this.lblUserSubCategory.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUserSubCategory.ForeColor = System.Drawing.Color.White;
            this.lblUserSubCategory.Location = new System.Drawing.Point(3, 29);
            this.lblUserSubCategory.Name = "lblUserSubCategory";
            this.lblUserSubCategory.Size = new System.Drawing.Size(352, 25);
            this.lblUserSubCategory.TabIndex = 9;
            this.lblUserSubCategory.Text = "設定グループ";
            this.lblUserSubCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubNameChange
            // 
            this.btnSubNameChange.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSubNameChange.Location = new System.Drawing.Point(224, 423);
            this.btnSubNameChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubNameChange.Name = "btnSubNameChange";
            this.btnSubNameChange.Size = new System.Drawing.Size(125, 29);
            this.btnSubNameChange.TabIndex = 3;
            this.btnSubNameChange.Text = "グループ名変更";
            this.btnSubNameChange.UseVisualStyleBackColor = true;
            this.btnSubNameChange.Click += new System.EventHandler(this.btnSubNameChange_Click);
            // 
            // btnSubDelete
            // 
            this.btnSubDelete.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSubDelete.Location = new System.Drawing.Point(114, 423);
            this.btnSubDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubDelete.Name = "btnSubDelete";
            this.btnSubDelete.Size = new System.Drawing.Size(105, 29);
            this.btnSubDelete.TabIndex = 2;
            this.btnSubDelete.Text = "グループ削除";
            this.btnSubDelete.UseVisualStyleBackColor = true;
            this.btnSubDelete.Click += new System.EventHandler(this.btnSubDelete_Click);
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSubAdd.Location = new System.Drawing.Point(5, 423);
            this.btnSubAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(105, 29);
            this.btnSubAdd.TabIndex = 1;
            this.btnSubAdd.Text = "グループ追加";
            this.btnSubAdd.UseVisualStyleBackColor = true;
            this.btnSubAdd.Click += new System.EventHandler(this.btnSubAdd_Click);
            // 
            // lstUserSubCategroy
            // 
            this.lstUserSubCategroy.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstUserSubCategroy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstUserSubCategroy.FullRowSelect = true;
            this.lstUserSubCategroy.GridLines = true;
            this.lstUserSubCategroy.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstUserSubCategroy.HideSelection = false;
            this.lstUserSubCategroy.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lstUserSubCategroy.Location = new System.Drawing.Point(4, 58);
            this.lstUserSubCategroy.Margin = new System.Windows.Forms.Padding(4);
            this.lstUserSubCategroy.MultiSelect = false;
            this.lstUserSubCategroy.Name = "lstUserSubCategroy";
            this.lstUserSubCategroy.Size = new System.Drawing.Size(351, 357);
            this.lstUserSubCategroy.TabIndex = 0;
            this.lstUserSubCategroy.UseCompatibleStateImageBehavior = false;
            this.lstUserSubCategroy.View = System.Windows.Forms.View.Details;
            this.lstUserSubCategroy.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstUserSubCategroy_AfterLabelEdit);
            this.lstUserSubCategroy.SelectedIndexChanged += new System.EventHandler(this.lstUserSubCategroy_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 165;
            // 
            // lblUserItem
            // 
            this.lblUserItem.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUserItem.ForeColor = System.Drawing.Color.White;
            this.lblUserItem.Location = new System.Drawing.Point(5, 29);
            this.lblUserItem.Name = "lblUserItem";
            this.lblUserItem.Size = new System.Drawing.Size(572, 25);
            this.lblUserItem.TabIndex = 10;
            this.lblUserItem.Text = "アイテム";
            this.lblUserItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Location = new System.Drawing.Point(472, 423);
            this.btnItemDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(105, 29);
            this.btnItemDelete.TabIndex = 2;
            this.btnItemDelete.Text = "機能削除";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(359, 423);
            this.btnItemAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(105, 29);
            this.btnItemAdd.TabIndex = 1;
            this.btnItemAdd.Text = "機能追加";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // lstItem
            // 
            this.lstItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lstItem.FullRowSelect = true;
            this.lstItem.GridLines = true;
            this.lstItem.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lstItem.Location = new System.Drawing.Point(6, 58);
            this.lstItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(571, 357);
            this.lstItem.TabIndex = 0;
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "プログラム(機能)名";
            this.columnHeader2.Width = 303;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "補足説明など";
            this.columnHeader3.Width = 262;
            // 
            // barSub
            // 
            this.barSub.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.barSub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel});
            this.barSub.Location = new System.Drawing.Point(0, 0);
            this.barSub.Name = "barSub";
            this.barSub.Size = new System.Drawing.Size(944, 25);
            this.barSub.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 22);
            this.btnSave.Text = "確定(&S)";
            this.btnSave.ToolTipText = "設定を保存して摘要します";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.Text = "戻る(&C)";
            this.btnCancel.ToolTipText = "変更を破棄して前の画面に戻ります";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SFNETMENU2C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(944, 468);
            this.Controls.Add(this.barSub);
            this.Controls.Add(this.spltMain);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SFNETMENU2C";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "お気に入り設定";
            this.Activated += new System.EventHandler(this.SFNETMENU2C_Activated);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            this.spltMain.ResumeLayout(false);
            this.barSub.ResumeLayout(false);
            this.barSub.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.Button btnSubNameChange;
        private System.Windows.Forms.Button btnSubDelete;
        private System.Windows.Forms.Button btnSubAdd;
        private System.Windows.Forms.ListView lstUserSubCategroy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.ListView lstItem;
        private System.Windows.Forms.ToolStrip barSub;
        private System.Windows.Forms.Label lblUserSubCategory;
        private System.Windows.Forms.Label lblUserItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;

    }
}
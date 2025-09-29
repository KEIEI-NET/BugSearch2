//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      フォームクラス                                  //
//                  :   PMKHN09730U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKHN09730UB : Form
    {
        PMKHN09730UA fPMKHN09730UA;
        private MethodInfo SFCMN00651MOD_SoftwarePurchasedCheckForUSB;
        private ArrayList _arSystemCode = new ArrayList();
        private Panel panel1;
        private Panel panel2;
        private Infragistics.Win.Misc.UltraButton buttonSelect;
        private Infragistics.Win.Misc.UltraButton buttonCancel;

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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09730UB));
            this.gridSystemFunctionGuide = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.buttonSelect = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new Infragistics.Win.Misc.UltraButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemFunctionGuide)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSystemFunctionGuide
            // 
            this.gridSystemFunctionGuide.Cursor = System.Windows.Forms.Cursors.Default;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridSystemFunctionGuide.DisplayLayout.Appearance = appearance4;
            this.gridSystemFunctionGuide.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Inset;
            this.gridSystemFunctionGuide.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSystemFunctionGuide.DisplayLayout.GroupByBox.Appearance = appearance1;
            appearance2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSystemFunctionGuide.DisplayLayout.GroupByBox.BandLabelAppearance = appearance2;
            this.gridSystemFunctionGuide.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSystemFunctionGuide.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSystemFunctionGuide.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridSystemFunctionGuide.DisplayLayout.MaxColScrollRegions = 1;
            this.gridSystemFunctionGuide.DisplayLayout.MaxRowScrollRegions = 1;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.gridSystemFunctionGuide.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.gridSystemFunctionGuide.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSystemFunctionGuide.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            this.gridSystemFunctionGuide.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridSystemFunctionGuide.DisplayLayout.Override.CellAppearance = appearance5;
            this.gridSystemFunctionGuide.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridSystemFunctionGuide.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSystemFunctionGuide.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            this.gridSystemFunctionGuide.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.gridSystemFunctionGuide.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.gridSystemFunctionGuide.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance16.BackColor = System.Drawing.Color.Lavender;
            this.gridSystemFunctionGuide.DisplayLayout.Override.RowAlternateAppearance = appearance16;
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.gridSystemFunctionGuide.DisplayLayout.Override.RowAppearance = appearance10;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.gridSystemFunctionGuide.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.gridSystemFunctionGuide.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gridSystemFunctionGuide.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.gridSystemFunctionGuide.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.gridSystemFunctionGuide.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridSystemFunctionGuide.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.gridSystemFunctionGuide.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridSystemFunctionGuide.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridSystemFunctionGuide.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.gridSystemFunctionGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSystemFunctionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gridSystemFunctionGuide.Location = new System.Drawing.Point(0, 0);
            this.gridSystemFunctionGuide.Name = "gridSystemFunctionGuide";
            this.gridSystemFunctionGuide.Size = new System.Drawing.Size(634, 465);
            this.gridSystemFunctionGuide.TabIndex = 0;
            this.gridSystemFunctionGuide.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridSystemFunctionGuide_KeyUp);
            this.gridSystemFunctionGuide.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridSystemFunctionGuide_DoubleClickRow);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(10, 6);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "選択(S)";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 36);
            this.panel1.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(91, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "戻る(X)";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridSystemFunctionGuide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 465);
            this.panel2.TabIndex = 3;
            // 
            // PMKHN09730UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 501);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09730UB";
            this.Text = "システム機能ガイド";
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemFunctionGuide)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UltraGrid gridSystemFunctionGuide;

        public PMKHN09730UB(PMKHN09730UA fMain)
        {
            fPMKHN09730UA = fMain;

            InitializeComponent();

            // XMLのフィールド（カテゴリ分）
            int CCategoryID = 0;
            int CProducts = 1;
            int CNo = 2;
            int CName = 3;
            int CDescription = 4;
            int CIconIndex = 5;
            int CIconName = 6;
            int CSysOpCode = 7;
            int CDisplayOption = 8;

            // XMLのフィールド（サブカテゴリ分）
            int SCategoryID = 0;
            int SCategorySubID = 1;
            int SNo = 2;
            int SProducts = 3;
            int SName = 4;
            int SDescription = 5;
            int SIconIndex = 6;
            int SIconName = 7;
            int SSysOpCode = 8;
            int SDisplayOption = 9;

            // XMLのフィールド（アイテム分）
            int ICategoryID = 0;
            int ICategorySubID = 1;
            int IItemID = 2;
            int INo = 3;
            int IItemSubID = 4;
            int ISubNo = 5;
            int IProducts = 6;
            int IPgId = 7;
            int IName = 8;
            int IParameter = 9;
            int IDescription = 10;
            int IIconIndex = 11;
            int IIconName = 12;
            int ISysOpCode = 13;
            int IDisplayOption = 14;

            // データテーブルのフィールド（データソース用）
            string ColSort1 = "ColSort1";                   // ソートキー1
            string ColSort2 = "ColSort2";                   // ソートキー2
            string ColCategoryID = "ColCategoryID";         // カテゴリID
            string ColCategorySubID = "ColCategorySubID";   // サブカテゴリID
            string ColItemID = "ColItemID";                 // アイテムID
            string ColClass = "ColClass";                   // 分類名称
            string ColName = "ColName";                     // メニュー項目名称

            // データソース用データテーブル定義
            DataTable dataTable = new DataTable("SystemFunctionGuide");

            dataTable.Columns.Add(ColSort1, typeof(Int32));
            dataTable.Columns.Add(ColSort2, typeof(Int32));
            dataTable.Columns.Add(ColCategoryID, typeof(Int32));
            dataTable.Columns.Add(ColCategorySubID, typeof(Int32));
            dataTable.Columns.Add(ColItemID, typeof(Int32));
            dataTable.Columns.Add(ColClass, typeof(string));
            dataTable.Columns.Add(ColName, typeof(string));

            DataTable dataTable1 = dataTable.Clone();       // カテゴリ用
            DataTable dataTable2 = dataTable.Clone();       // サブカテゴリ用
            DataTable dataTable3 = dataTable.Clone();       // アイテム用

            // 処理用ワーク
            string sWhere = "";                             // 抽出条件設定用
            int SortIndex = 0;                              // ソート順設定用
            string wkSystemFunctionName1 = "";              // カテゴリ名称設定用
            string wkSystemFunctionName2 = "";              // サブカテゴリ名称設定用
            string wkSystemFunctionName3 = "";              // アイテム名称設定用

            // メニュー情報取得
            ReadSfNetMenuNavigator readSfNetMenuNavigator = new ReadSfNetMenuNavigator();

            DataSet dsSystemProducts = new DataSet();
            int status = readSfNetMenuNavigator.ReadSfNetMenuNavigatorXML(out dsSystemProducts);

            // 製品情報取得
            string ProductID = LoginInfoAcquisition.ProductCode;

            sWhere = "CategoryID < 0 and Products = '" + ProductID + "'";
            DataRow[] TopCategory = dsSystemProducts.Tables["ProductCategory"].Select(sWhere, "CategoryID");
            if (TopCategory.Length > 0)
            {
                _arSystemCode.AddRange(TopCategory[0][CSysOpCode].ToString().Split(','));
            }

            // カテゴリ情報取得
            sWhere = "( Products = 'All' or Products = '" + ProductID + "' ) and CategoryID > 0";
            DataRow[] Category = dsSystemProducts.Tables["ProductCategory"].Select(sWhere, "No");

            // カテゴリ情報セット
            for (int i = 0; i < Category.Length; i++)
            {
                // 表示オプション判定
                string displayOption = Category[i][CDisplayOption].ToString();
                if (CheckDisplayOption(ref displayOption) == 0) continue;

                // システムオプションコード判定
                string sysOpCode = Category[i][CSysOpCode].ToString();
                if (CheckSysOpCode(ref sysOpCode) == 0) continue;

                // 表示可能なのでデータテーブルに登録
                wkSystemFunctionName1 = Category[i][CName].ToString();
                wkSystemFunctionName1 = wkSystemFunctionName1.Replace("\\n", "");

                DataRow dataRow1 = dataTable1.NewRow();

                dataRow1[ColSort1] = 0;
                dataRow1[ColSort2] = SortIndex++;
                dataRow1[ColCategoryID] = Category[i][CCategoryID];
                dataRow1[ColCategorySubID] = 0;
                dataRow1[ColItemID] = 0;
                dataRow1[ColClass] = "カテゴリ";
                dataRow1[ColName] = wkSystemFunctionName1;

                dataTable1.Rows.Add(dataRow1);
            }

            // サブカテゴリ情報取得
            DataRow[] CategorySub = dsSystemProducts.Tables["ProductSubCategory"].Select("", "CategoryID, No");

            // サブカテゴリ情報セット
            for (int i = 0; i < CategorySub.Length; i++)
            {
                Boolean findCategorySub = false;

                // 表示可能なカテゴリ配下にあるか
                for (int j = 0; j < dataTable1.Rows.Count; j++)
                {
                    if ((int)CategorySub[i][SCategoryID] == (int)dataTable1.Rows[j][ColCategoryID])
                    {
                        findCategorySub = true;
                        wkSystemFunctionName1 = dataTable1.Rows[j][ColName].ToString();
                        break;
                    }
                }

                if (!findCategorySub) continue;

                // システムオプションコード判定
                string sysOpCode = CategorySub[i][SSysOpCode].ToString();
                if (CheckSysOpCode(ref sysOpCode) == 0) continue;

                // 表示可能なのでデータテーブルに登録
                wkSystemFunctionName2 = wkSystemFunctionName1 + " - " + CategorySub[i][SName];
                wkSystemFunctionName2 = wkSystemFunctionName2.Replace("\\n", "");

                DataRow dataRow2 = dataTable2.NewRow();

                dataRow2[ColSort1] = 1;
                dataRow2[ColSort2] = SortIndex++;
                dataRow2[ColCategoryID] = CategorySub[i][SCategoryID];
                dataRow2[ColCategorySubID] = CategorySub[i][SCategorySubID];
                dataRow2[ColItemID] = 0;
                dataRow2[ColClass] = "サブカテゴリ";
                dataRow2[ColName] = wkSystemFunctionName2;

                dataTable2.Rows.Add(dataRow2);

                // アイテム情報取得
                // アイテム情報単独ではサブカテゴリの表示順にソートすることができない。
                // よって、サブカテゴリが登録された時点で配下のアイテムを処理する。
                sWhere = "CategoryID = " + CategorySub[i][SCategoryID] + " AND CategorySubID = " + CategorySub[i][SCategorySubID] + "AND ItemSubID = 0";
                DataRow[] Item = dsSystemProducts.Tables["ProductItem"].Select(sWhere, "No");

                for (int j = 0; j < Item.Length; j++)
                {
                    // システムオプションコード判定
                    sysOpCode = Item[j][ISysOpCode].ToString();
                    if (CheckSysOpCode(ref sysOpCode) == 0) continue;

                    // 表示可能なのでデータテーブルに登録
                    wkSystemFunctionName3 = wkSystemFunctionName2 + " - " + Item[j][IName];
                    wkSystemFunctionName3 = wkSystemFunctionName3.Replace("\\n", "");

                    DataRow dataRow3 = dataTable3.NewRow();

                    dataRow3[ColSort1] = 2;
                    dataRow3[ColSort2] = SortIndex++;
                    dataRow3[ColCategoryID] = Item[j][ICategoryID];
                    dataRow3[ColCategorySubID] = Item[j][ICategorySubID];
                    dataRow3[ColItemID] = Item[j][IItemID];
                    dataRow3[ColClass] = "アイテム";
                    dataRow3[ColName] = wkSystemFunctionName3;

                    dataTable3.Rows.Add(dataRow3);

                }
            }

            // グリッドのデータソースをセット
            dataTable.Merge(dataTable1);    // カテゴリ分統合
            dataTable.Merge(dataTable2);    // サブカテゴリ分統合
            dataTable.Merge(dataTable3);    // アイテム分統合

            string SortKey = string.Format("{0} Asc, {1} Asc", ColSort1, ColSort2);
            DataView dv = dataTable.DefaultView;
            dv.Sort = SortKey;

            gridSystemFunctionGuide.DataSource = dv;

            gridSystemFunctionGuide.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColSort1].Hidden = true;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColSort2].Hidden = true;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColCategoryID].Hidden = true;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColCategorySubID].Hidden = true;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColItemID].Hidden = true;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColClass].Width = 120;
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColName].Width = 450;

            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColClass].Header.Caption = "分類";
            gridSystemFunctionGuide.DisplayLayout.Bands[0].Columns[ColName].Header.Caption = "名称";

            gridSystemFunctionGuide.Select();

            this.DialogResult = DialogResult.Cancel;

        }

        /// <summary>
        /// 表示オプション判定
        /// </summary>
        /// <param name="displayOption">表示オプション</param>
        /// <remarks>
        /// <br>Note        : 表示オプションを判定し、表示対象かを判定します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private int CheckDisplayOption(ref string displayOption)
        {
            try
            {
                int ret = 1;

                if (displayOption.ToUpper() == "I") ret = 0;  // インフォメーション
                if (displayOption.ToUpper() == "E") ret = 0;  // スタートアップ
                if (displayOption.ToUpper() == "S") ret = 0;  // サポート用
                if (displayOption.ToUpper() == "A") ret = 0;  // 管理者用

                return ret;
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        /// <summary>
        /// オプションコード判定
        /// </summary>
        /// <param name="sysOpCode">オプションコード</param>
        /// <remarks>
        /// <br>Note        : オプションコードを判定し、表示対象かを判定します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private int CheckSysOpCode(ref string sysOpCode)
        {
            try
            {
                string[] ChkCode;

                if (sysOpCode.Length != 0)
                {
                    ChkCode = sysOpCode.Split(new Char[] { ',' });
                }
                else
                {
                    return 1;
                }
                return (CheckSysOpCodeBody(ChkCode));
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        /// <summary>
        /// オプションコード判定ボディ
        /// </summary>
        /// <param name="sysOpCode">オプションコード</param>
        /// <remarks>
        /// <br>Note        : オプションコードを判定し、表示対象かを判定します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private int CheckSysOpCodeBody(string[] ChkCode)
        {
            try
            {
                int nRtnCd = 0;
                bool bLessEnable = false;       //  レスオプション有無

                int i = 0;
                while (i < ChkCode.Length)
                {
                    //  且つ条件が有るかをチェックして、有る場合は分解して再帰処理
                    if (ChkCode[i].IndexOf("&") > -1)
                    {
                        bool bPermit = true;
                        string[] wkCheckCode = ChkCode[i].Split('&');

                        for (int j = 0; j < wkCheckCode.Length; j++)
                        {
                            //  単体チェックを繰り返して、その間に条件不成立があればNG
                            if (CheckSysOpCodeBody(new string[] { wkCheckCode[j] }) == 0)
                            {
                                bPermit = false;
                                break;
                            }
                        }
                        //  全条件がOKなら表示可能
                        if (bPermit == true)
                        {
                            return 1;
                        }
                        else
                        {
                            i++;
                            continue;
                        }
                    }

                    //  システム単体時に表示NG
                    if (ChkCode[i].Substring(0, 1) == "=")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                        {
                            return 0;
                        }

                        i++;

                        if (i >= ChkCode.Length)
                        {
                            return 1;
                        }
                        continue;
                    }

                    //  レスオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }

                    //  システム単体時に表示OK
                    if (ChkCode[i].Substring(0, 1) == "*")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                        {
                            return 1;
                        }
                        i++;
                        if (i >= ChkCode.Length)
                        {
                            return 0;
                        }
                        continue;
                    }

                    if ((nRtnCd = SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0)
                    {
                        //  レスオプションなら、オプション有りでNG(最優先チェック)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                        }

                        break;
                    }
                    else
                    {
                        //  レスオプションなら、
                        if (bLessEnable == true)
                        {
                            //  次のオプションチェック対象が有れば、判断はそちらの正否にゆだねる。そうでなければチェックOKとする
                            nRtnCd = 1;

                        }
                    }

                    i++;

                }
                return nRtnCd;
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        private int CheckInstallSystem(string SystemCode)
        {
            try
            {
                bool bHit = false;

                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode == _arSystemCode[i].ToString())
                    {
                        //  システムが入ってないならNG
                        if (SoftwarePurchasedCheckForUSB(SystemCode) == 0)
                        {
                            return -1;
                        }
                        bHit = true;
                        break;
                    }
                }
                //  見つからなければこの時点でNG
                if (bHit == false)
                {
                    return -3;
                }
                //  システムが入っているなら、単体かどうかを調べる
                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode != _arSystemCode[i].ToString())
                    {
                        if (SoftwarePurchasedCheckForUSB(_arSystemCode[i].ToString()) != 0)
                        {
                            //  その他のシステムが入っていれば、1
                            return 1;
                        }
                    }
                }
                //  単体ならゼロ
                return 0;
            }
            catch (Exception er)
            {
                return -9;
            }
        }

        private int SoftwarePurchasedCheckForUSB(string SoftwareCode)
        {
            Assembly SFCMN00651MOD;
            Type SFCMN00651MOD_LoginInfoAcquisition;
            object lia;
            SFCMN00651MOD = Assembly.LoadFrom("SFCMN00651C.dll");
            SFCMN00651MOD_LoginInfoAcquisition = SFCMN00651MOD.GetType("Broadleaf.Application.Common.LoginInfoAcquisition");
            SFCMN00651MOD_SoftwarePurchasedCheckForUSB = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("SoftwarePurchasedCheckForUSB", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string) }, null);
            lia = (object)Activator.CreateInstance(SFCMN00651MOD_LoginInfoAcquisition);

            return (int)SFCMN00651MOD_SoftwarePurchasedCheckForUSB.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)SoftwareCode }, null);
        }

        /// <summary>
        /// gridSystemFunctionGuide_DoubleClickRowイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 行のダブルクリック時に選択データを戻します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void gridSystemFunctionGuide_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                SetSelectedData();
            }
            catch (Exception er)
            {
                return;
            }
        }

        /// <summary>
        /// buttonCancel_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : キャンセルボタンクリック時にフォームを閉じます。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// データセット処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 選択されたシステム機能を戻します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void SetSelectedData()
        {
            if (gridSystemFunctionGuide.Selected.Rows.Count > 0)
            {
                fPMKHN09730UA.txtCategoryID.Text = gridSystemFunctionGuide.Selected.Rows[0].Cells[2].Value.ToString();
                fPMKHN09730UA.txtCategorySubID.Text = gridSystemFunctionGuide.Selected.Rows[0].Cells[3].Value.ToString();
                fPMKHN09730UA.txtItemID.Text = gridSystemFunctionGuide.Selected.Rows[0].Cells[4].Value.ToString();
                fPMKHN09730UA.txtSystemFunction.Text = gridSystemFunctionGuide.Selected.Rows[0].Cells[6].Value.ToString();

                this.DialogResult = DialogResult.OK;
            }

            this.Dispose();
        }

        /// <summary>
        /// buttonSelect_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 選択ボタンクリック時にデータセット処理を実行します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SetSelectedData();
        }

        /// <summary>
        /// gridSystemFunctionGuide_KeyUpイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : キー操作を判定し、処理を振り分けます。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        private void gridSystemFunctionGuide_KeyUp(object sender, KeyEventArgs e)
        {
            // Escキー
            if (e.KeyData == Keys.Escape)
            {
                this.Dispose();
            }
            // Alt+Xキー
            else if ((e.Alt == true) && (e.KeyCode == Keys.X))
            {
                this.Dispose();
            }
            // Enterキー
            else if (e.KeyData == Keys.Enter)
            {
                SetSelectedData();
            }
            // Alt+Sキー
            else if ((e.Alt == true) && (e.KeyCode == Keys.S))
            {
                SetSelectedData();
            }
        }

    }

}
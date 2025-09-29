using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 通知内容設定フォーム
    /// </summary>
    public partial class ReleaseSelectForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReleaseSelectForm()
        {
            InitializeComponent();
            this._TBOServiceACS = new TBOServiceACS();
            this._destSettingTable = new DataTable();
            this._list = new List<DestSetting>();
            this.Title_textBox.Clear();
            this.Content_textBox.Clear();
            this._dicPropose_Para_SCM = new Dictionary<string, Propose_Para_SCM>();

            this._startProposeList = new List<Propose_Para_SCM>();
            this._stopProposeList = new List<DestSetting>();

#if DEBUG
            //// TODO 公開情報ダミー
            //DestSetting store = new DestSetting();
            //store.enterpriseCode = "0140150842030050";
            //store.sectionCode = "000001";
            //this._list.Add(store);
#endif
        }
        #endregion

        #region const

        private const string CT_ASSEMBLYID = "SFMIT10201U";
        private const string CT_PROPOSESTOP = "公開停止";
        private const string CT_PROPOSE_YES = "公開中";
        private const string CT_PROPOSE_NO = "未公開";

        private const string ctSeparator = @"	";
        private const string ctSpace = @"　";

        private const string COL_PROPOSEDIV = "公開状況";
        private const string COL_PROPOSENAME = "公開先";
        private const string COL_STOPBUTTON  = "     ";
        private const string COL_CLASS = "CLASS";

        #endregion

        #region メンバ
        /// <summary>TBOアクセスクラス</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>公開先テーブル</summary>
        private DataTable _destSettingTable;
        /// <summary>SCM企業拠点連結ディクショナリ</summary>
        private Dictionary<string, Propose_Para_SCM> _dicPropose_Para_SCM;

        #region 起動パラメータ
        /// <summary>
        /// 起動モード(0:選択画面、1:公開状況画面)
        /// </summary>
        public int _mode;
        /// <summary>
        /// カテゴリID
        /// </summary>
        public long _categoryID;
        /// <summary>
        /// カテゴリ名称
        /// </summary>
        public string _categoryName;
        /// <summary>
        /// 企業コード
        /// </summary>
        public string _enterpriseCode;
        /// <summary>
        /// 企業名称
        /// </summary>
        public string _enterpriseName;
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string _sectionCode;
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string _sectionName;
        /// <summary>
        /// SCM企業拠点連結設定
        /// </summary>
        public List<Propose_Para_SCM> _scmList;
        /// <summary>
        /// 商品公開先情報
        /// </summary>
        public List<DestSetting> _list;
        #endregion

        #region 戻り値
        /// <summary>
        /// 件名
        /// </summary>
        public string NewsTitle;
        /// <summary>
        /// 本文
        /// </summary>
        public string NewsContent;
        /// <summary>
        /// 公開得意先リスト
        /// </summary>
        public List<Propose_Para_SCM> _startProposeList;
        /// <summary>
        /// 公開⇒非公開得意先リスト
        /// </summary>
        public List<DestSetting> _stopProposeList;
        #endregion

        #endregion

        #region Public



        #endregion




        /// <summary>
        /// 起動処理
        /// </summary>
        /// <param name="bootPara">起動パラメータ</param>
        /// <param name="target">SCM企業拠点連結情報(公開先のみ)</param>
        /// <returns></returns>
        public DialogResult ShowReleaseSelectFrom()
        {
            int st = 0;
            string errMsg= "";

            #region memo
            // ①現在の公開状況を取得
            // ②SCM企業拠点連結を取得

            // SCM 紅葉Ａ
            // SCM 紅葉Ｂ

            // 公開　紅葉Ａ
            // 公開　ブロード１

            // 状況1：初めは紅葉Ａ、Ｂ、ブロード１のSCM企業拠点連結あり
            // 状況2：紅葉Ａ、ブロード１に商品を公開
            // 状況3: ブロード１とのSCMを終了。企業拠点連結を削除
            // が上記状況

            // 公開状況
            // 公開中　紅葉Ａ
            // 未公開　紅葉Ｂ
            // 公開中　ブロード１

            // 公開先
            // SCM 紅葉Ａ　デフォチェックＯＮ
            // SCM 紅葉Ｂ

            // 保存⇒Aのみ新着データを作る

            // 公開停止モード
            // 公開状況
            // 公開中　紅葉Ａ       公開停止
            // 未公開　紅葉Ｂ　　　 Enable
            // 公開中　ブロード１   公開停止
#endregion


            if (this._mode == 0)
            {
                // 公開先選択モード
                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.panel3.Visible = true;
                this.panel4.Visible = true;
                this.panel5.Visible = true;
                this.panel6.Visible = true;
                this.panel7.Visible = true;

                this.Size = new Size(620, 520);

            }
            else
            {
                // 公開状況確認モード
                this.panel1.Visible = true;
                this.panel2.Visible = true;
                this.panel2.BringToFront();
                this.panel2.Dock = DockStyle.Fill;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;

                this.Size = new Size(620, 250);
                this.FormBorderStyle = FormBorderStyle.Sizable;

                this.Text = "公開先の確認";
            }

            // カテゴリ名称セット
            this.Category_textBox.Text = this._categoryName;

            // 公開情報取得
            st = this._TBOServiceACS.GetDestSetting(this._enterpriseCode, this._sectionCode, this._categoryID, out this._list, out errMsg);
            if (st != 0)
            {
                // 公開情報の取得に失敗
                TMsgDisp.Show(
                this,								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                errMsg,			                    // 表示するメッセージ 
                st,								    // ステータス値
                MessageBoxButtons.OK);
                this.DialogResult = DialogResult.Abort;
                return this.DialogResult;
            }

            if (this._mode == 0)
            {
                // 公開先ツリー作成
                this.MakeCustomerTree();
            }
            else
            {
                // テーブルスキーマ作成
                this.MakeTable();
                // テーブルにデータをセット
                this.SetData();
            }
         
            return this.ShowDialog();
        }

        /// <summary>
        /// 公開先ツリー作成
        /// </summary>
        private void MakeCustomerTree()
        {
            this.Customer_ultraTree.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

            this.Customer_ultraTree.Nodes.Clear();

            foreach (Propose_Para_SCM scm in this._scmList)
            {
                // 公開状況と公開先リストを作成

                // 公開先リスト
                string key = MakeSCMKey(scm);
                string text = MakeSCMText(scm);

                if (!this.Customer_ultraTree.Nodes.Exists(key))
                {
                    this.Customer_ultraTree.Nodes.Add(key, text);
                    this.Customer_ultraTree.Nodes[key].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;

                    if (!this._dicPropose_Para_SCM.ContainsKey(key))
                    {
                        this._dicPropose_Para_SCM.Add(key, scm);
                    }

                    DestSetting wkDestSetting = this._list.Find
                        (delegate(DestSetting destSetting)
                        {
                            if (destSetting.proposeDestEnterpriseCode == scm.CnectOriginalEpCd && destSetting.proposeDestSectionCode.TrimEnd() == scm.CnectOriginalSecCd.TrimEnd())
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                    if (wkDestSetting != null)
                    {
                        this.Customer_ultraTree.Nodes[key].CheckedState = CheckState.Checked;
                        this.Customer_ultraTree.Nodes[key].Tag = wkDestSetting;
                    }
                    else
                    {
                        this.Customer_ultraTree.Nodes[key].CheckedState = CheckState.Unchecked;
                    }
                }
            }

            this.Customer_ultraTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

        }

        /// <summary>
        /// 公開情報作成
        /// </summary>
        /// <returns></returns>
        private void SetData()
        {
            foreach (Propose_Para_SCM scm in this._scmList)
            {
                // 公開状況と公開先リストを作成

                // 公開先リスト
                string key = MakeSCMKey(scm);
                string text = MakeSCMText(scm);

                // 公開状況テーブル
                DataRow row = this._destSettingTable.NewRow();

                DestSetting wkDestSetting = this._list.Find
                    (delegate(DestSetting destSetting)
                    {
                        if (destSetting.proposeDestEnterpriseCode == scm.CnectOriginalEpCd && destSetting.proposeDestSectionCode.TrimEnd() == scm.CnectOriginalSecCd.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // 公開先名称
                row[COL_PROPOSENAME] = text;
                // 既に商品が公開されている得意先は公開中表示
                if (wkDestSetting != null)
                {
                    row[COL_PROPOSEDIV] = CT_PROPOSE_YES;
                    row[COL_CLASS] = wkDestSetting;
                }
                else
                {
                    row[COL_PROPOSEDIV] = CT_PROPOSE_NO;
                }

                this._destSettingTable.Rows.Add(row);
            }

            // イレギュラーケース
            // 商品公開後、SCMの企業拠点連結を解除した場合(取引をやめる場合を想定)
            // この場合、データが残ってしまうので、SCM企業拠点連結情報：なし、公開情報：ありのデータも表示する
            foreach (DestSetting dst in this._list)
            {
                Propose_Para_SCM scm = this._scmList.Find
                  (delegate(Propose_Para_SCM wkScm)
                    {
                        if (dst.proposeDestEnterpriseCode == wkScm.CnectOriginalEpCd && dst.proposeDestSectionCode.TrimEnd() == wkScm.CnectOriginalSecCd.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (scm == null)
                {
                    // 公開状況テーブル
                    DataRow row = this._destSettingTable.NewRow();
                   
                    // 公開情報のみ残ってる

                    // 公開先名 
                    row[COL_PROPOSENAME] = dst.proposeDestEnterpriseName + ctSpace + dst.proposeDestSectionName;
                    row[COL_PROPOSEDIV] = CT_PROPOSE_YES;
                    row[COL_CLASS] = dst;
                    this._destSettingTable.Rows.Add(row);
                }
            }

            // グリッドにセット
            this.Propose_Grid.DataSource = this._destSettingTable;

        }

        /// <summary>
        /// 公開先のキーを作成
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMKey(Propose_Para_SCM customer)
        {
            return customer.CnectOriginalEpCd + ctSeparator + customer.CnectOriginalSecCd;
        }

        /// <summary>
        /// 公開先のキーを作成
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMKey(string key1, string key2)
        {
            return key1 + ctSeparator + key2;
        }

        /// <summary>
        /// 公開先の名称を作成
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string MakeSCMText(Propose_Para_SCM customer)
        {
            return customer.CnectOriginalEpNm + ctSpace + customer.CnectOriginalSecNm;
        }

        /// <summary>
        /// データセット作成
        /// </summary>
        private void MakeTable()
        {
            this._destSettingTable.Columns.Add(COL_PROPOSEDIV, typeof(string));
            this._destSettingTable.Columns.Add(COL_PROPOSENAME, typeof(string));
            this._destSettingTable.Columns.Add(COL_STOPBUTTON, typeof(string));
            this._destSettingTable.Columns.Add(COL_CLASS, typeof(object));
            this._destSettingTable.Columns[COL_STOPBUTTON].DefaultValue = CT_PROPOSESTOP;
        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this._startProposeList.Clear();
            this._stopProposeList.Clear();

            // 公開先リスト作成
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                string[] keys = node.Key.Split(new string[] { ctSeparator }, StringSplitOptions.RemoveEmptyEntries);
                string scmkey = MakeSCMKey(keys[0], keys[1]);

                // 公開リスト、非公開リストを作成
                if (node.CheckedState == CheckState.Checked)
                {
                    // 公開リストに追加
                    if (this._dicPropose_Para_SCM.ContainsKey(scmkey))
                    {
                        this._startProposeList.Add(this._dicPropose_Para_SCM[scmkey]);
                    }
                }

                if (node.Tag != null && node.CheckedState == CheckState.Unchecked)
                {
                    // 公開⇒非公開にされた
                    // 非公開リストに追加
                    DestSetting delSet = (DestSetting)node.Tag;
                    delSet.logicalDelDiv = 1;
                    this._stopProposeList.Add(delSet);
                }
            }

            // 入力チェック
            // 公開先は必須
            // ただし、公開⇒非公開の場合があるのでそれを考慮

            if (this._startProposeList.Count == 0 && this._stopProposeList.Count == 0)
            {
                // メッセージを表示
                DialogResult rlt = TMsgDisp.Show(
                   this,							        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                   CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                   "公開先を選択して下さい", 	            // 表示するメッセージ 
                   0,								        // ステータス値
                   MessageBoxButtons.OK);
                this.Customer_ultraTree.Focus();
                return;
            }

            #region 件名は未入力可とする
            //// 件名 は必須とする
            //if (string.IsNullOrEmpty(this.Title_textBox.Text))
            //{
            //    // メッセージを表示
            //    DialogResult rlt = TMsgDisp.Show(
            //       this,							        // 親ウィンドウフォーム
            //       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
            //       CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
            //       "件名を入力して下さい", 	                // 表示するメッセージ 
            //       0,								        // ステータス値
            //       MessageBoxButtons.OK);
            //    this.Title_textBox.Focus();
            //    return;
            //}

            //// 本文
            //if (string.IsNullOrEmpty(this.Content_textBox.Text))
            //{
            //    // メッセージを表示
            //    DialogResult rlt = TMsgDisp.Show(
            //       this,							        // 親ウィンドウフォーム
            //       emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
            //       CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
            //       "本文が入力されていません。" 
            //       + Environment.NewLine + "このまま登録してもよろしいですか？",    // 表示するメッセージ 
            //       0,								        // ステータス値
            //       MessageBoxButtons.OKCancel);

            //    if (rlt == DialogResult.Cancel)
            //    {
            //        this.Content_textBox.Focus();
            //    }
            //    return;
            //}
            #endregion

            // 戻り値をセット
            this.NewsTitle = this.Title_textBox.Text;
            this.NewsContent = this.Content_textBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
       

        /// <summary>
        /// 公開状況グリッド InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // グリッドのカラム情報を設定します。
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            layout.UseFixedHeaders = false;

            // ヘッダーの外観設定
            layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            layout.Override.HeaderAppearance.FontData.Name = "ＭＳ ゴシック";
            layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // 1行おきの外観設定
            layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 行セレクターの設定
            layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行選択設定 行選択無しモード(アクティブのみ)
            layout.Override.SelectTypeCell = SelectType.None;
            layout.Override.SelectTypeCol = SelectType.None;
            layout.Override.SelectTypeRow = SelectType.Single;

            // 選択行の外観設定
            layout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // アクティブ行の外観設定
            layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行フィルターの設定
            layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 列の自動調整
            layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // 列の入替不可
            layout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // 列のサイズ変更不可
            layout.Override.AllowColSizing = AllowColSizing.None;
            // 列のソート不可
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            layout.Override.CellClickAction = CellClickAction.RowSelect;

            //行サイズ変更不可
            layout.Override.RowSizing = RowSizing.Fixed;
        }

        /// <summary>
        /// グリッドアップデート処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドのアップデート処理を行います。</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.Propose_Grid.UpdateData();
            this.Propose_Grid.Refresh();
        }

        /// <summary>
        /// グリッドカラム設定
        /// </summary>
        /// <param name="columnsCollection"></param>
        private void SettingGridColumn(ColumnsCollection cols)
        {
            // 公開状況
            cols[COL_PROPOSEDIV].Width = 40;
            cols[COL_PROPOSEDIV].Hidden = false;
            cols[COL_PROPOSEDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_PROPOSEDIV].CellActivation = Activation.NoEdit;
            cols[COL_PROPOSEDIV].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_PROPOSEDIV].CellDisplayStyle = CellDisplayStyle.PlainText;

            // 公開先
            cols[COL_PROPOSENAME].Hidden = false;
            cols[COL_PROPOSENAME].Width = 120;
            cols[COL_PROPOSENAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_PROPOSENAME].CellActivation = Activation.NoEdit;
            cols[COL_PROPOSENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_PROPOSENAME].CellDisplayStyle = CellDisplayStyle.PlainText;

            // 公開停止ボタン
            cols[COL_STOPBUTTON].Hidden = false;
            cols[COL_STOPBUTTON].Width = 30;
            //cols[COL_STOPBUTTON].CellButtonAppearance.Image = this._imageList.Images[0];
            cols[COL_STOPBUTTON].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            cols[COL_STOPBUTTON].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            cols[COL_STOPBUTTON].CellActivation = Activation.AllowEdit;
            cols[COL_STOPBUTTON].CellButtonAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //cols[COL_STOPBUTTON].CellButtonAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            cols[COL_STOPBUTTON].CellButtonAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            cols[COL_STOPBUTTON].CellButtonAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // 作業カラム
            cols[COL_CLASS].Hidden = true;

        }

        /// <summary>
        /// Propose_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Cells[COL_PROPOSEDIV].Value.ToString() == CT_PROPOSE_YES)
            {
                e.Row.Cells[COL_STOPBUTTON].Activation = Activation.AllowEdit;
            }
            else
            {
                e.Row.Cells[COL_STOPBUTTON].Activation = Activation.Disabled;
            }
        }

        /// <summary>
        /// 全選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SELECTALL_Button_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                node.CheckedState = CheckState.Checked;
            }
        }

        /// <summary>
        /// 全解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLEARALL_Button_Click(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.Customer_ultraTree.Nodes)
            {
                node.CheckedState = CheckState.Checked;
            }
        }


        /// <summary>
        /// Customer_ultraTree_AfterCheck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customer_ultraTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            // チェックが外された
            if (e.TreeNode.CheckedState == CheckState.Unchecked && e.TreeNode.Tag != null)
            {
                // 既に公開済みの公開先のチェックが外された

                // メッセージを表示
                DialogResult ret = TMsgDisp.Show(
                   this,							        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                   CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                   "選択解除した公開先には現在商品を公開中です。"
                   + Environment.NewLine
                   + "このまま保存を行うと、公開済みの商品が公開先より削除されます。"
                   + Environment.NewLine
                   + "選択を解除してもよろしいですか？", 	// 表示するメッセージ                                                          
                   0,								        // ステータス値
                   MessageBoxButtons.OKCancel);

                if (ret == DialogResult.Cancel)
                {
                    this.Customer_ultraTree.AfterCheck -= new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);
                    e.TreeNode.CheckedState = CheckState.Checked;
                    this.Customer_ultraTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Customer_ultraTree_AfterCheck);

                }
            }
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //キー制御         
            switch (e.PrevCtrl.Name)
            {
                case "Propose_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;

                                    //シフトキーが押されているか？
                                    if (e.ShiftKey)
                                    {
                                        // 最初のセル
                                        if (this.Propose_Grid.ActiveCell != null && this.Propose_Grid.ActiveCell.Column.Key == COL_PROPOSEDIV)
                                        {
                                            if (this.Propose_Grid.ActiveCell.Row.HasPrevSibling())
                                            {
                                                UltraGridRow prevRow = this.Propose_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                UltraGridCell prevCel = null;
                                                prevCel = prevRow.Cells[COL_STOPBUTTON];
                                                if (prevCel != null)
                                                {
                                                    prevCel.Activate();
                                                    prevCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Propose_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                        }
                                    }
                                    else
                                    {
                                        // 最終セル
                                        if (this.Propose_Grid.ActiveCell != null && this.Propose_Grid.ActiveCell.Column.Key == COL_STOPBUTTON)
                                        {
                                            if (this.Propose_Grid.ActiveCell.Row.HasNextSibling())
                                            {
                                                UltraGridRow nextRow = this.Propose_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                UltraGridCell nextCel = nextRow.Cells[COL_PROPOSEDIV];
                                                if (nextCel != null)
                                                {
                                                    nextCel.Activate();
                                                    nextCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Propose_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Propose_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // 編集中であった場合
            if (this.Propose_Grid.ActiveCell != null)
            {
                // アクティブセル
                UltraGridCell activeCell = this.Propose_Grid.ActiveCell;

                switch (e.KeyData)
                {
                    // ←キー
                    case Keys.Left:
                        // 最初のセル
                        if (activeCell.Column.Key == COL_PROPOSEDIV)
                        {
                            if (activeCell.Row.HasPrevSibling())
                            {
                                UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                UltraGridCell prevCel = null;
                                prevCel = prevRow.Cells[COL_STOPBUTTON];
                                if (prevCel != null)
                                {
                                    prevCel.Activate();
                                    prevCel.Selected = true;
                                }
                            }
                        }
                        else
                        {
                            this.Propose_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        e.Handled = true;
                        break;
                    // →キー
                    case Keys.Right:
                        // 最終セル
                        if (activeCell.Column.Key == COL_STOPBUTTON)
                        {
                            if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell nextCel = nextRow.Cells[COL_PROPOSEDIV];
                                if (nextCel != null)
                                {
                                    nextCel.Activate();
                                    nextCel.Selected = true;
                                }
                            }
                        }
                        else
                        {
                            this.Propose_Grid.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        e.Handled = true;
                        break;
                    case Keys.Up:
                        if (activeCell.Row.HasPrevSibling())
                        {
                            UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                            UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                            if (prevCel != null)
                            {
                                prevCel.Activate();
                                prevCel.Selected = true;
                            }
                        }
                        e.Handled = true;
                        break;
                    // ↓キー
                    case Keys.Down:
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];
                            belowCel.Activate();
                            belowCel.Selected = true;
                        }
                        e.Handled = true;
                        break;
                    case Keys.Space:
                        if (activeCell.Activation != Activation.Disabled)
                        {
                            if (activeCell.Column.Key == COL_STOPBUTTON)
                            {
                                // 公開停止
                                this.StopProposeGoods(activeCell.Row.Index);
                            }
                        }
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 選択された公開先への商品公開を停止します
        /// </summary>
        /// <param name="p"></param>
        private void StopProposeGoods(int index)
        {
            // メッセージを表示
            DialogResult ret = TMsgDisp.Show(
               this,							            // 親ウィンドウフォーム
               emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // エラーレベル
               CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
               "公開停止が選択されました。"
               + Environment.NewLine
               + "公開停止を行うと、公開済みの商品が公開先より削除されます。"
               + Environment.NewLine
               + "公開停止を実行してもよろしいですか？",    // 表示するメッセージ                                                          
               0,								            // ステータス値
               MessageBoxButtons.OKCancel);

            if (ret == DialogResult.OK)
            {

                // 公開停止処理
                int st = 0;
                string errMsg = "";

                //ピロピロ表示
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "処理中";
                form.Message = "公開停止処理を実行中です";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    form.Show();

                    DestSetting destSetting = (DestSetting)this.Propose_Grid.Rows[index].Cells[COL_CLASS].Value;

                    st = this._TBOServiceACS.DeleteDestSetting(destSetting, out errMsg);
                    if (st == 0)
                    {
                        // 公開状況を取得
                        st = this._TBOServiceACS.GetDestSetting(this._enterpriseCode, this._sectionCode, this._categoryID, out this._list, out errMsg);
                        if (st == 0)
                        {
                            // テーブル初期化
                            this.Propose_Grid.DataSource = null;
                            this._destSettingTable.Clear();
                            // テーブル最新化
                            this.SetData();
                        }
                        else
                        {
                            // 公開情報取得失敗
                            TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                            errMsg,			                    // 表示するメッセージ 
                            st,								    // ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        }
                    }
                    else
                    {
                        form.Close();
                        this.Cursor = Cursors.Default;

                        // 公開停止失敗
                        TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                        errMsg,			                    // 表示するメッセージ 
                        st,								    // ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                    }
                }
                finally
                {
                    // ダイアログを閉じる
                    form.Close();
                    this.Cursor = Cursors.Default;
                    this.UpDateGrid();
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Propose_Grid_ClickCellButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Propose_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            // 公開停止
            if (e.Cell.Column.Key == COL_STOPBUTTON)
            {
                this.StopProposeGoods(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Content_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 改行
            if (e.KeyCode == Keys.Enter && e.Alt)
            {
                // 改行
                try
                {
                    int index = this.Content_textBox.SelectionStart;
                    string insertVal = this.Content_textBox.Text;
                    int length = insertVal.Length;
                    if (length + 2 <= 256)
                    {
                        string wk = insertVal.Insert(index, Environment.NewLine);
                        this.Content_textBox.Text = wk;
                        this.Content_textBox.SelectionStart = index + 2;  // rn分
                    }
                }
                catch
                {

                }
            }
        }
    }
}
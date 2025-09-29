using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using System.IO;
using System.Drawing.Imaging;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 画像登録画面
    /// </summary>
    public partial class GoodsImageForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GoodsImageForm()
        {
            InitializeComponent();
            this._imgTable = new DataTable();
            this._imgTable.CaseSensitive = true;
            this._TBOServiceACS = new TBOServiceACS();
            this._goodsImageDic = new Dictionary<long, List<GoodsImage>>();
            this._saveDiv = false;
            this._imageNameChange = false;
            this._imageList = new ImageList();
            this._imageList.Images.Add(Properties.Resources._28_STAR1);
            this._imageList.TransparentColor = Color.Cyan;
            this._dataReadFlag = false;
        }
        #endregion

        #region メンバ

        /// <summary>データテーブル</summary>
        private DataTable _imgTable;
        /// <summary>TOBアクセスクラス</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>付随整備ディクショナリー</summary>
        private Dictionary<long, List<GoodsImage>> _goodsImageDic;
        /// <summary>画像名称変更フラグ</summary>
        private bool _imageNameChange;
        /// <summary>イメージリスト</summary>
        private ImageList _imageList;

        /// <summary>企業コード</summary>
        public string _enterPriseCode;
        /// <summary>起動モード(0:マスメン、1:ガイドモード)</summary>
        public int _mode;
        /// <summary>商品カテゴリリスト</summary>
        public List<GoodsCategory> _goodsCategoryList;
        /// <summary>選択中カテゴリID</summary>
        public long _goodsCategoryId;
        /// <summary>データ読込済みフラグ</summary>
        public bool _dataReadFlag;
        /// <summary>保存済みフラグ</summary>
        public bool _saveDiv;

        // ガイドモード
        /// <summary>選択イメージID</summary>
        public long _imageID;
        /// <summary>選択商品画像</summary>
        public Image _goodsImage;

        #endregion

        #region const
        private const string COL_DEL = "削除";
        private const string COL_ID = "ID";
        private const string COL_NAME = "名称";
        private const string COL_IMAGE = "画像";
        private const string COL_IMAGE_CHANGE = "画像変更区分";
        private const string COL_GUIDE = "ガイド";
        private const string COL_DATA = "データ";
        private const string CT_ASSEMBLYID = "SFMIT10201U";
        #endregion

        #region Public
        /// <summary>
        /// 商品画像設定画面起動
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowGoodsImageFrom()
        {
            if (this._mode == 0)
            {
                // マスメン
                this.Text = "商品画像設定";
                this.ToolBar_panel.Visible = false;
                this.Category_label.Text = "商品カテゴリ";
                this.Category_ComboEditor.Visible = true;
                this.tool_panel.Visible = true;
                this.Buttom_panel.Visible = true;

                // コンボ作成
                this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                foreach (GoodsCategory goodsCategory in _goodsCategoryList)
                {
                    this.Category_ComboEditor.Items.Add(goodsCategory.GoodsCategoryId, goodsCategory.GoodsCategoryName);
                }
                this.Category_ComboEditor.SelectedIndex = 0;
                // タイヤを初期選択
                this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

            }
            else
            {
                // ガイド
                this.Search_panel.Visible = true;
                this.Text = "商品画像ガイド";
                this.ToolBar_panel.Visible = true;
                this.Category_label.Text = "商品画像を選択して下さい";
                this.Category_ComboEditor.Visible = false;
                this.tool_panel.Visible = false;
                this.Buttom_panel.Visible = false;
                this.Annotation_panel.Visible = false;
                this.ImageName_TextBox.Text = "";
                this.GoodsImage_Grid.DoubleClickRow += new DoubleClickRowEventHandler(GoodsImage_Grid_DoubleClickRow);
            }

            int st = 0;

            //ピロピロ表示
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、画像データを抽出中です。";


            // 画像データ取得
            try
            {
                this.Cursor = Cursors.WaitCursor;
                form.Show();

                if ((this._mode == 0) || (this._dataReadFlag == true))
                {
                    // 初期化
                    this._goodsImageDic = new Dictionary<long, List<GoodsImage>>();
                    st = this.SearchGoodsImage();
                    if (st == 0)
                    {
                        this._dataReadFlag = false;
                    }
                }
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this.Cursor = Cursors.Default;
                System.Windows.Forms.Application.DoEvents();
            }

            if (st != 0)
            {
                this.DialogResult = DialogResult.Cancel;
                return this.DialogResult;
            }

            // テーブル作成
            this.MakeGoodsImageTable();
            // データセット
            this.SetDataTable();

            // 起動
            return this.ShowDialog();
        }

        #endregion

        #region Private

        #region  商品画像テーブル作成
        /// <summary>
        /// 商品画像テーブル作成
        /// </summary>
        private void MakeGoodsImageTable()
        {
            this._imgTable = new DataTable();
            this._imgTable.Columns.Add(COL_DEL, typeof(int));
            this._imgTable.Columns.Add(COL_ID, typeof(long));
            this._imgTable.Columns.Add(COL_NAME, typeof(string));
            this._imgTable.Columns.Add(COL_IMAGE, typeof(Image));
            this._imgTable.Columns.Add(COL_IMAGE_CHANGE, typeof(int));
            this._imgTable.Columns.Add(COL_GUIDE, typeof(object));
            this._imgTable.Columns.Add(COL_DATA, typeof(object));
            this._imgTable.Columns[COL_DEL].DefaultValue = 0;
            this._imgTable.Columns[COL_NAME].DefaultValue = "";
            this._imgTable.Columns[COL_ID].DefaultValue = 0;
            this._imgTable.Columns[COL_IMAGE_CHANGE].DefaultValue = 0;
        }
        #endregion

        #region Gridカラム設定
        /// <summary>
        /// グリッドカラム設定
        /// </summary>
        /// <param name="cols"></param>
        private void SettingGridColumn(ColumnsCollection cols)
        {
            //全てのカラムを非表示にしておく
            for (int i = 0; i < this.GoodsImage_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.GoodsImage_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;
            }

            // 名称
            cols[COL_NAME].Hidden = false;
            cols[COL_NAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            if (this._mode == 0)
            {
                cols[COL_NAME].CellActivation = Activation.AllowEdit;
            }
            else
            {
                cols[COL_NAME].CellActivation = Activation.NoEdit;
            }
            cols[COL_NAME].MaxLength = 256;
            cols[COL_NAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            cols[COL_NAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            cols[COL_NAME].CellDisplayStyle = CellDisplayStyle.PlainText;

            cols[COL_NAME].Width = 190;

            //// マスメン
            if (this._mode == 0)
            {
                cols[COL_NAME].Width = 170;
            }

            // 画像
            cols[COL_IMAGE].Hidden = false;
            cols[COL_IMAGE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            cols[COL_IMAGE].CellActivation = Activation.NoEdit;
            cols[COL_IMAGE].TabStop = false;
            

            // 画像マスメン
            if (this._mode == 0)
            {
                cols[COL_GUIDE].Hidden = false;
                cols[COL_GUIDE].Header.Caption = "";
                cols[COL_GUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                cols[COL_GUIDE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                cols[COL_GUIDE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                cols[COL_GUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                cols[COL_GUIDE].CellButtonAppearance.Image = this._imageList.Images[0];
                cols[COL_GUIDE].Width = 15;
            }
        }
        #endregion

        #region 商品画像データ取得
        /// <summary>
        /// 商品画像データ取得処理
        /// </summary>
        /// <returns></returns>
        private int SearchGoodsImage()
        {
            List<GoodsImage> goodsImageList = new List<GoodsImage>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetGoodsImageIdList(this._enterPriseCode, out goodsImageList, out errMsg);
            if (st == 0)
            {
                // 画像は1件ずつ取得する
                foreach (GoodsImage goodsImage in goodsImageList)
                {
                    long imgId = goodsImage.imageId;
                    GoodsImage wkgoodsImage = new GoodsImage();
                    st = this._TBOServiceACS.GetGoodsImage(this._enterPriseCode, imgId, out wkgoodsImage, out errMsg);

                    if (st == 0)
                    {
                        if (this._goodsImageDic.ContainsKey(wkgoodsImage.goodsCategoryId))
                        {
                            this._goodsImageDic[wkgoodsImage.goodsCategoryId].Add(wkgoodsImage);
                        }
                        else
                        {
                            List<GoodsImage> wkList = new List<GoodsImage>();
                            wkList.Add(wkgoodsImage);
                            this._goodsImageDic.Add(wkgoodsImage.goodsCategoryId, wkList);
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,							                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                        CT_ASSEMBLYID,					                // アセンブリIDまたはクラスID
                        errMsg,	                                    // 表示するメッセージ 
                        st,								            // ステータス値
                        MessageBoxButtons.OK);
                        return st;
                    }
                }

                // ソート
                this.SortGoodsImageDic();
            }
            else
            {
                TMsgDisp.Show(
                     this,							                // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                     CT_ASSEMBLYID,					                // アセンブリIDまたはクラスID
                     errMsg,	                                    // 表示するメッセージ 
                     st,								            // ステータス値
                     MessageBoxButtons.OK);
            }
            return st;
        }
        #endregion

        #region 取得データ⇒テーブルセット
        /// <summary>
        /// 取得データをテーブルにセット
        /// </summary>
        private void SetDataTable()
        {
            this._imgTable.Rows.Clear();

            if (this._goodsImageDic.ContainsKey(this._goodsCategoryId))
            {
                foreach (GoodsImage goodsImage in this._goodsImageDic[this._goodsCategoryId])
                {
                    DataRow row = this._imgTable.NewRow();
                    row[COL_DEL] = goodsImage.logicalDelDiv;
                    row[COL_DATA] = goodsImage;
                    row[COL_ID] = goodsImage.imageId;
                    row[COL_NAME] = goodsImage.imageKeyword;
                    row[COL_IMAGE] = goodsImage.imageData_Image;
                    this._imgTable.Rows.Add(row);
                }
            }

            DataView view = this._imgTable.DefaultView;
            // フィルター
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            view.RowFilter = filter.ToString();
            this.GoodsImage_Grid.DataSource = view;
        }
        #endregion

        #region 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns></returns>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // 入力チェック
            if (!this.DataInputCheck())
            {
                return -1;
            }

            // 保存対象データ作成
            GoodsImage[] saveArray = new GoodsImage[0];
            this.MakeSaveData(ref saveArray);

            // 保存対象データがなければ処理中断
            if (saveArray == null || saveArray.Length == 0)
            {
                return 0;
            }

            // 画像があるので1件ずづ渡す
            foreach (GoodsImage goodsImage in saveArray)
            {
                GoodsImage wkGoodImage = goodsImage;
                int mode = this.GetMode(goodsImage);
                // 保存実行
                st = this._TBOServiceACS.SaveGoodsImage(mode, ref wkGoodImage, out errMsg);

                if (st == 0)
                {
                    if (mode == 3)
                    {
                        // 削除
                        if (this._goodsImageDic.ContainsKey(wkGoodImage.goodsCategoryId))
                        {
                            GoodsImage target = this._goodsImageDic[wkGoodImage.goodsCategoryId].Find(
                               delegate(GoodsImage wkGoodsImage)
                               {
                                   if (wkGoodsImage.imageId == wkGoodImage.imageId)
                                       return true;
                                   else
                                       return false;
                               }
                            );
                            if (target != null)
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Remove(target);
                            }
                        }
                    }
                    else
                    {
                        // 新規更新

                        // Dic最新化
                        if (this._goodsImageDic.ContainsKey(wkGoodImage.goodsCategoryId))
                        {
                            GoodsImage target = this._goodsImageDic[wkGoodImage.goodsCategoryId].Find(
                                delegate(GoodsImage wkGoodsImage)
                                {
                                    if (wkGoodsImage.imageId == wkGoodImage.imageId)
                                        return true;
                                    else
                                        return false;
                                }
                             );

                            if (target == null)
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Add(wkGoodImage);
                            }
                            else
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Remove(target);
                                this._goodsImageDic[goodsImage.goodsCategoryId].Add(wkGoodImage);
                            }
                        }
                        else
                        {
                            List<GoodsImage> list = new List<GoodsImage>();
                            list.Add(wkGoodImage);
                            this._goodsImageDic.Add(wkGoodImage.goodsCategoryId, list);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(errMsg))
                    {
                        errMsg = "商品画像の登録に失敗しました。";
                    }

                    TMsgDisp.Show(
                        this,							    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
                        errMsg,	                            // 表示するメッセージ 
                        st,								    // ステータス値
                        MessageBoxButtons.OK);
                    return st;
                }
            }

            if (st == 0)
            {
                TMsgDisp.Show(
                      this,								// 親ウィンドウフォーム
                      emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                      CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                      "保存しました。",			        // 表示するメッセージ 
                      0,								// ステータス値
                      MessageBoxButtons.OK);
            }

            this._saveDiv = true;

            // ソートする
            this.SortGoodsImageDic();

            // テーブル再構築
            this.SetDataTable();

            return st;
        }
        #endregion

        #region 保存データ作成

        /// <summary>
        /// 保存対象データ作成
        /// </summary>
        /// <param name="saveArray"></param>
        private void MakeSaveData(ref GoodsImage[] saveArray)
        {
            // 描画停止
            this.GoodsImage_Grid.BeginUpdate();

            // 一旦フィルターを解除
            this._imgTable.DefaultView.RowFilter = "";

            // 未保存の削除データをテーブルから削除
            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2} is {3}", COL_DEL, 1, COL_DATA, "null"));

            DataRow[] delRows = this._imgTable.Select(cndString.ToString());
            foreach (DataRow delRow in delRows)
            {
                delRow.Delete();
            }
            this._imgTable.AcceptChanges();

            List<GoodsImage> retList = new List<GoodsImage>();
            for (int i = 0; i < this._imgTable.DefaultView.Count; i++)
            {
                GoodsImage saveDate = new GoodsImage();
                if (this._imgTable.DefaultView[i].Row[COL_DATA] != DBNull.Value)
                {
                    // 更新されてない行は対象外
                    if (IsChengeRow(this._imgTable.DefaultView[i].Row))
                    {
                        saveDate = ((GoodsImage)this._imgTable.DefaultView[i].Row[COL_DATA]).Clone();
                        saveDate.imageKeyword = this._imgTable.DefaultView[i].Row[COL_NAME].ToString();
                        saveDate.imageData_Image = (Image)this._imgTable.DefaultView[i].Row[COL_IMAGE];
                        saveDate.logicalDelDiv = (int)this._imgTable.DefaultView[i].Row[COL_DEL];
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    // 新規行
                    saveDate.imageKeyword = this._imgTable.DefaultView[i].Row[COL_NAME].ToString();
                    saveDate.enterpriseCode = this._enterPriseCode;
                    saveDate.goodsCategoryId = this._goodsCategoryId;
                    saveDate.uuid = "";
                    saveDate.imageData_Image = (Image)this._imgTable.DefaultView[i].Row[COL_IMAGE];
                }
                retList.Add(saveDate);
            }
            saveArray = retList.ToArray();

            // 再度フィルターセット
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            this._imgTable.DefaultView.RowFilter = filter.ToString();

            // 描画開始
            this.GoodsImage_Grid.EndUpdate();
            this.UpDateGrid();
        }

        #endregion

        #region 入力チェック
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns></returns>
        private bool DataInputCheck()
        {
            bool ret = true;
            string errMsg = "";
            string columnNm = "";
            int rowIndex = 0;
            // グリッド入力チェック
            if (!GridInputCheck(out errMsg, out columnNm, out rowIndex))
            {
                // メッセージを表示
                TMsgDisp.Show(
                   this,							        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                   CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                   errMsg,	                                // 表示するメッセージ 
                   0,								        // ステータス値
                   MessageBoxButtons.OK);

                this.GoodsImage_Grid.ActiveCell = this.GoodsImage_Grid.Rows[rowIndex].Cells[columnNm];
                ret = false;
            }
            return ret;

        }

        /// <summary>
        /// グリッド入力チェック
        /// </summary>
        /// <param name="mess"></param>
        /// <param name="columnNm"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool GridInputCheck(out string errMsg, out string columnNm, out int rowIndex)
        {
            bool result = true;
            errMsg = "";
            columnNm = "";
            rowIndex = 0;
            //グリッドのアップデート
            this.UpDateGrid();
            for (int ix = 0; ix < this.GoodsImage_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.GoodsImage_Grid.Rows[ix];

                // 未入力チェック  画像
                if (ugRow.Cells[COL_IMAGE].Value == DBNull.Value)
                {
                    rowIndex = ix;
                    errMsg = "画像を設定して下さい";
                    columnNm = COL_IMAGE;
                    return false;
                }
            }
            return result;
        }
        #endregion

        #region 変更チェック
        /// <summary>
        /// 変更チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckUpdate()
        {
            bool ret = false;
            this._imgTable.AcceptChanges();

            // データ内容比較
            for (int i = 0; i < this._imgTable.Rows.Count; i++)
            {
                DataRow row = this._imgTable.Rows[i];
                if (row[COL_DATA] == DBNull.Value)
                {
                    // 新規行
                    if ((int)row[COL_DEL] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        // 削除対象ではない新規行がある 
                        return true;
                    }
                }
                else
                {
                    // 保存済行
                    if ((int)row[COL_DEL] == 1)
                    {
                        // 保存済行が削除されている
                        return true;
                    }
                    else
                    {
                        GoodsImage image = (GoodsImage)row[COL_DATA];

                        // 名称
                        if (!image.imageKeyword.Equals(row[COL_NAME].ToString()))
                        {
                            return true;
                        }
                        // 画像
                        if ((int)row[COL_IMAGE_CHANGE] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return ret;
        }


        /// <summary>
        /// 更新チェック(行単位)
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private bool IsChengeRow(DataRow dataRow)
        {
            bool ret = false;
            // 削除されている
            if ((int)dataRow[COL_DEL] == 1)
            {
                return true;
            }

            // 画像が変更されている
            if ((int)dataRow[COL_IMAGE_CHANGE] == 1)
            {
                return true;
            }

            // 名称が変更されている
            if (!dataRow[COL_NAME].ToString().Equals(((GoodsImage)dataRow[COL_DATA]).imageKeyword))
            {
                return true;
            }
            return ret;
        }
        #endregion

        #region グリッドアップデート処理
        /// <summary>
        /// グリッドアップデート処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドのアップデート処理を行います。</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.GoodsImage_Grid.UpdateData();
            this.GoodsImage_Grid.Refresh();
        }
        #endregion

        #region ビジネスロジック

        #region ソート
        /// <summary>
        /// ソート処理
        /// </summary>
        private void SortGoodsImageDic()
        {
            if (this._goodsImageDic.ContainsKey(this._goodsCategoryId))
            {
                this._goodsImageDic[this._goodsCategoryId].Sort(delegate(GoodsImage obj1, GoodsImage obj2)
                {
                    // イメージID順
                    return obj1.imageId.CompareTo(obj2.imageId);
                });
            }
        }
        #endregion

        #region フィルター
        /// <summary>
        /// フィルター処理
        /// </summary>
        private void MakeFilter()
        {
            string filter = "";
            StringBuilder cndString = new StringBuilder();
            if (!string.IsNullOrEmpty(this.ImageName_TextBox.Text))
            {
                cndString.Append(String.Format("{0} Like '%{1}%'", COL_NAME, this.ImageName_TextBox.Text));
                filter = cndString.ToString();
            }
            this._imgTable.DefaultView.RowFilter = filter;
            this.GoodsImage_Grid.Refresh();
            this.GoodsImage_Grid.Update();
        }
        #endregion

        #region 更新モード取得
        /// <summary>
        /// 更新モード取得処理
        /// </summary>
        /// <param name="goodsImage"></param>
        /// <returns></returns>
        private int GetMode(GoodsImage goodsImage)
        {
            int mode = 1;
            if (goodsImage.insDtTime == 0)
            {
                // POST
                mode = 1;
            }
            else if (goodsImage.logicalDelDiv == 1)
            {
                //DELETE
                mode = 3;
            }
            else
            {
                //PUT
                mode = 2;
            }
            return mode;
        }
        #endregion

        #endregion

        #region ガイド選択結果セット
        /// <summary>
        /// 選択結果をセット
        /// </summary>
        private void SetResult()
        {
            if (this.GoodsImage_Grid.ActiveRow != null)
            {
                this._imageID = (long)this.GoodsImage_Grid.ActiveRow.Cells[COL_ID].Value;
                this._goodsImage = (Image)this.GoodsImage_Grid.ActiveRow.Cells[COL_IMAGE].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region GridEvent

        #region InitializeLayout
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // グリッドのカラム情報を設定します。
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.Override.DefaultRowHeight = 90;

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
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
            if (this._mode == 0)
            {
                layout.Override.SelectTypeCell = SelectType.Single;
            }
            else
            {
                layout.Override.SelectTypeCell = SelectType.None;

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

            }
            layout.Override.SelectTypeCol = SelectType.None;

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

            //行サイズ変更不可
            layout.Override.RowSizing = RowSizing.Fixed;


            if (this._mode == 0)
            {
                // マスメンモード
                layout.Override.CellClickAction = CellClickAction.Default;
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Focus();
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Activated = true;
                    this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                // ガイドモード
                layout.Override.CellClickAction = CellClickAction.RowSelect;
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Rows[0].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Activated = true;
                }
            }
        }
        #endregion

        #region KeyDown
        /// <summary>
        /// GoodsImage_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // 編集中であった場合
            if (this._mode == 0)
            {
                if (this.GoodsImage_Grid.ActiveCell != null)
                {
                    // アクティブセル
                    UltraGridCell activeCell = this.GoodsImage_Grid.ActiveCell;

                    switch (e.KeyData)
                    {
                        // ←キー
                        case Keys.Left:
                            if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            break;
                        // →キー
                        case Keys.Right:
                            if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            break;
                        // ↑キー
                        case Keys.Up:
                            if (activeCell.Row.HasPrevSibling())
                            {
                                UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                if (prevCel != null)
                                {
                                    prevCel.Activate();
                                    prevCel.Selected = true;
                                    if (prevCel.Activation == Activation.AllowEdit)
                                    {
                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.AddRow_ultraButton.Focus();
                            }
                            e.Handled = true;
                            break;
                        // ↓キー
                        case Keys.Down:
                            if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                if (belowCel != null)
                                {
                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                            e.Handled = true;
                            break;
                        case Keys.Space:
                            if (activeCell.Column.Key == COL_GUIDE)
                            {
                                this.GoodsImage_Grid_ClickCellButton(this.GoodsImage_Grid, new CellEventArgs(activeCell));
                            }
                            e.Handled = true;
                            break;
                    }
                }
            }
            else
            {
                if (this.GoodsImage_Grid.ActiveRow != null)
                {
                    // アクティブセル
                    UltraGridRow activeRow = this.GoodsImage_Grid.ActiveRow;

                    switch (e.KeyData)
                    {
                        // ↑キー
                        case Keys.Up:
                            if (activeRow.HasPrevSibling())
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.AboveRow);
                            }
                            else
                            {
                                this.ImageName_TextBox.Focus();
                            }
                            e.Handled = true;
                            break;
                        // ↓キー
                        case Keys.Down:
                            if (activeRow.HasNextSibling())
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextRow);
                            }
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Enter
        /// <summary>
        /// GoodsImage_Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_Enter(object sender, EventArgs e)
        {
            if (this._mode == 0)
            {
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Activated = true;
                    this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        #endregion

        #region DoubleClickRow
        /// <summary>
        /// 行ダブルクリック(ガイド時のみ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this._imageID = (long)e.Row.Cells[COL_ID].Value;
            this._goodsImage = (Image)e.Row.Cells[COL_IMAGE].Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region ClickCellButton
        /// <summary>
        /// 画像選択ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            // ガイドボタンの場合
            if (e.Cell.Column.Key == COL_GUIDE)
            {
                // ダイアログの表示
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // 存在しないファイル選択時の警告
                openFileDialog.CheckFileExists = true;
                // ディレクトリ変更後ダイアログボックスを閉じるとき元に戻す
                openFileDialog.RestoreDirectory = true;
                // フィルタ
                openFileDialog.Filter =
                      "画像ファイル|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.tif;*.tiff;*.gif|" +
                      "PNGファイル(*.png)|*.png|" +
                      "JPGファイル(*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                      "BMPファイル(*.bmp;*.dib)|*.bmp;*.dib|" +
                      "TIFファイル(*.tif;*.tiff)|*.tif;*.tiff|" +
                      "GIFファイル(*.gif)|*.gif";
                      //"ICOファイル(*.gif)|*.ico"; ;
                // 初期フィルタ位置
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // ファイルInfo取得
                FileInfo info = new FileInfo(openFileDialog.FileName);

                if (info.Length > 204800)
                {
                    TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	                    // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "画像サイズが200KBを超えている為、取込できません",       // 表示するメッセージ 
                       0,								                        // ステータス値
                       MessageBoxButtons.OK);
                    return;
                }

                // 画像とファイルパスを取得
                Image image = Image.FromFile(openFileDialog.FileName);

                string name = Path.GetFileNameWithoutExtension(info.Name);
                if (name.Length > 256)
                {
                    name = name.Substring(0, 256);
                }

                // 画像を追加
                int index = this.GoodsImage_Grid.ActiveRow.Index;
                this.GoodsImage_Grid.Rows[index].Cells[COL_IMAGE].Value = image;
                this.GoodsImage_Grid.Rows[index].Cells[COL_NAME].Value = name;
                this.GoodsImage_Grid.Rows[index].Cells[COL_IMAGE_CHANGE].Value = 1;
            }
        }
        #endregion
        
        #endregion

        #region その他イベント

        #region Button

        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            this.SaveProc();
        }

        /// <summary>
        /// 画像取込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportImage_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //上部に表示する説明テキストを指定する
            fbd.Description = "画像フォルダを指定してください。" + Environment.NewLine + "※ファイルサイズが200KBを超える画像は取り込むことができません。";

            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                string path = fbd.SelectedPath;

                DirectoryInfo dInfo = new DirectoryInfo(path);
                FileInfo[] fInfo = dInfo.GetFiles();

                if (fInfo != null)
                {
                    bool importFlag = false;

                    foreach (FileInfo info in fInfo)
                    {
                        try
                        {
                            // Byte とりあえず200KBを超えるものは取り込まない
                            long length = info.Length;
                            // 1024B=1KB
                            // 204800    =200KB
                            if (length > 204800)
                            {
                                continue;
                            }

                            Image image = Image.FromFile(info.FullName);
                            if (image != null)
                            {
                                DataRow row = this._imgTable.NewRow();
                                row[COL_IMAGE] = image;
                                string name = Path.GetFileNameWithoutExtension(info.Name);
                                if (name.Length > 256)
                                {
                                    name = name.Substring(0, 256); 
                                }
                                row[COL_NAME] = name;
                                row[COL_IMAGE_CHANGE] = 1;
                                this._imgTable.Rows.Add(row);
                                importFlag = true;
                            }
                        }
                        catch
                        {

                        }
                    }
                    this._imgTable.AcceptChanges();
                    this.UpDateGrid();

                    if(importFlag)
                    {
                          TMsgDisp.Show(
                          this,							        // 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,	        // エラーレベル
                          CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
                          "取込が完了しました。",               // 表示するメッセージ 
                          0,								    // ステータス値
                          MessageBoxButtons.OK);
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,							                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	                // エラーレベル
                        CT_ASSEMBLYID,					                    // アセンブリIDまたはクラスID
                        "取込可能な画像ファイルが存在しませんでした。",     // 表示するメッセージ 
                        0,								                    // ステータス値
                        MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 閉じるボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_ultraButton_Click(object sender, EventArgs e)
        {
            DataRow row = this._imgTable.NewRow();
            this._imgTable.Rows.Add(row);
            this.UpDateGrid();
        }

        /// <summary>
        /// 行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRow_Button_Click(object sender, EventArgs e)
        {
            if (this.GoodsImage_Grid.Selected.Rows.Count > 0)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "選択行を削除しますか？",                                // 表示するメッセージ 
                       0,								                        // ステータス値
                       MessageBoxButtons.OK);

                if (ret == DialogResult.OK)
                {
                    foreach (UltraGridRow row in this.GoodsImage_Grid.Selected.Rows)
                    {
                        // 保存済行
                        row.Cells[COL_DEL].Value = 1;
                    }
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.GoodsImage_Grid.ActiveRow != null)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "選択行を削除しますか？",                                // 表示するメッセージ 
                       0,								                        // ステータス値
                       MessageBoxButtons.OK);

                if (ret == DialogResult.OK)
                {
                    this.GoodsImage_Grid.ActiveRow.Cells[COL_DEL].Value = 1;
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.GoodsImage_Grid.ActiveCell != null)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "選択行を削除しますか？",                                // 表示するメッセージ 
                       0,								                        // ステータス値
                       MessageBoxButtons.OK);

                if (ret == DialogResult.OK)
                {
                    this.GoodsImage_Grid.ActiveCell.Row.Cells[COL_DEL].Value = 1;
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
        }

        #endregion

        #region ToolStrip

        /// <summary>
        /// 選択クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.SetResult();
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region TextBox
        /// <summary>
        /// ImageName_TextBox_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_Enter(object sender, EventArgs e)
        {
            //フラグ初期化
            this._imageNameChange = false;
        }

        /// <summary>
        /// ImageName_TextBox_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_Leave(object sender, EventArgs e)
        {
            if (this._imageNameChange)
            {
                this.MakeFilter();
            }
        }

        /// <summary>
        /// ImageName_TextBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_TextChanged(object sender, EventArgs e)
        {
            //ユーザーによる変更か？
            if (this.ImageName_TextBox.Modified == true)
            {
                //フラグ初期化
                this._imageNameChange = true;
            }
        }

        #endregion

        #region ComboEditor
        /// <summary>
        /// カテゴリ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 変更チェック
            if (this._goodsCategoryId != (long)this.Category_ComboEditor.Value)
            {
                // カテゴリが変更された
                bool dataSearhFlag = false;
                // 更新確認
                if (CheckUpdate())
                {
                    // メッセージを表示
                    DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "現在編集中のデータが存在します。"                       // 表示するメッセージ 
                       + Environment.NewLine + "登録してもよろしいですか？",
                       0,								                        // ステータス値
                       MessageBoxButtons.YesNoCancel);


                    if (ret == DialogResult.Yes)
                    {
                        // 保存処理
                        int st = this.SaveProc();
                        if (st == 0)
                        {
                            this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // 保存に失敗
                            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                            this.Category_ComboEditor.Value = this._goodsCategoryId;
                            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // 編集内容を破棄 インデックを更新
                        this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // キャンセル →　戻す
                        this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                        this.Category_ComboEditor.Value = this._goodsCategoryId;
                        this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // データ変更なし
                    // インデックスを更新
                    this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                    dataSearhFlag = true;
                }
                if (dataSearhFlag)
                {
                    // テーブル再構築
                    this.SetDataTable();
                }
            }
        }
        #endregion

        #region RetKey
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
                case "GoodsImage_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;
                                    if (this._mode == 0)
                                    {
                                        if (e.ShiftKey)
                                        {
                                            // 最初のセル
                                            if (this.GoodsImage_Grid.ActiveCell != null && this.GoodsImage_Grid.ActiveCell.Column.Key == COL_NAME)
                                            {
                                                if (this.GoodsImage_Grid.ActiveCell.Row.HasPrevSibling())
                                                {
                                                    UltraGridRow prevRow = this.GoodsImage_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                    UltraGridCell prevCel = null;

                                                    prevCel = prevRow.Cells[COL_IMAGE];

                                                    if (prevCel != null)
                                                    {
                                                        prevCel.Activate();
                                                        prevCel.Selected = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            // 最終セル
                                            if (this.GoodsImage_Grid.ActiveCell != null && this.GoodsImage_Grid.ActiveCell.Column.Key == COL_GUIDE)
                                            {
                                                if (this.GoodsImage_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.GoodsImage_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_NAME];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (e.Key == Keys.Enter)
                                        {
                                            this.SetResult();
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        #endregion

        #region Form
      
        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._mode == 0)
            {
                // マスメンモードの場合は入力チェック

                if (CheckUpdate())
                {
                    // メッセージを表示
                    DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "現在編集中のデータが存在します。"                       // 表示するメッセージ 
                       + Environment.NewLine + "登録してもよろしいですか？",
                       0,								                        // ステータス値
                       MessageBoxButtons.YesNoCancel);

                    if (ret == DialogResult.Yes)
                    {
                        // 保存処理
                        int st = this.SaveProc();
                        if (st != 0)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else if (ret == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

            }
        }
        #endregion

        /// <summary>
        /// GoodsImage_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (this._mode == 0)
            {
                if (e.Row.Cells[COL_DATA].Value != DBNull.Value)
                {
                    e.Row.Cells[COL_GUIDE].Activation = Activation.Disabled;
                }
            }
        }
        #endregion

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 付随整備設定画面
    /// </summary>
    public partial class AttendRepairSetForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AttendRepairSetForm()
        {
            InitializeComponent();

            this._TBOServiceACS = new TBOServiceACS();
            this._repairDic = new Dictionary<long, List<AttendRepairSet>>();
            this._saveDiv = false;
        }
        #endregion

        #region メンバ変数
        /// <summary>企業コード</summary>
        private string _enterPriseCode;
        /// <summary>TOBアクセスクラス</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>付随整備ディクショナリー</summary>
        //private Dictionary<int, List<AttendRepairSet>> _repairDic;
        private Dictionary<long, List<AttendRepairSet>> _repairDic;
        /// <summary>付随整備テーブル</summary>
        private DataTable _repairTable;
        /// <summary>カテゴリ 現在値Index</summary>
        private int _selectIndex;

        /// <summary>保存処理フラグ</summary>
        public bool _saveDiv;
        /// <summary>商品カテゴリ情報</summary>
        public List<GoodsCategory> _categoryList;

        #endregion

        #region Const

        // テーブル名
        private const string TABLENM = "TABLENM";
        // テーブルカラム
        private const string COL_DEL = "削除";
        private const string COL_SORTNO = "表示順";
        private const string COL_REPAIRNAME = "名称";
        private const string COL_DATATYPE = "作業・部品";
        private const string COL_PRICETYPE = "料金タイプ";
        private const string COL_REPAIRPRICE = "金額";
        private const string COL_DATA = "更新前データ";
        // データフォーマット
        private const string CT_MONEYFORMAT = "#,##0;-#,##0;''";
        // PGID
        private const string CT_ASSEMBLYID = "SFMIT10201U";

        #endregion

        #region Method

        #region Public

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog(string enterPriseCode, short bootMode)
        {
            this._enterPriseCode = enterPriseCode;
            int st = 0;
          
            // 商品カテゴリセット
            this.SetGoodsCategory();

            // 付随整備設定取得
            st = this.SearchAttendRepairSet(enterPriseCode);

            // データテーブル作成
            this.MakeDataTable();
            // データセット
            this.SetDataTable();
            // 表示
            return this.ShowDialog();
        }

        #endregion

        #region Private

        #region テーブル構築
        /// <summary>
        /// データテーブル作成
        /// </summary>
        private void MakeDataTable()
        {
            // 商品テーブル(共通)
            this._repairTable = new DataTable(TABLENM);

            this._repairTable.Columns.Add(COL_DEL, typeof(Int32));          // 削除区分       hyde 
            this._repairTable.Columns.Add(COL_SORTNO, typeof(Int32));       // ソート順       hyde 
            this._repairTable.Columns.Add(COL_REPAIRNAME, typeof(string));  // 名称
            this._repairTable.Columns.Add(COL_DATATYPE, typeof(Int32));     // 作業・部品区分
            this._repairTable.Columns.Add(COL_PRICETYPE, typeof(Int32));    // 金額タイプ
            this._repairTable.Columns.Add(COL_REPAIRPRICE, typeof(long));  // 金額
            this._repairTable.Columns.Add(COL_DATA, typeof(object));        // 更新前データ
            this._repairTable.Columns[COL_DEL].DefaultValue = 0;
            this._repairTable.Columns[COL_SORTNO].DefaultValue = 0;
            this._repairTable.Columns[COL_REPAIRNAME].DefaultValue = "";
            this._repairTable.Columns[COL_DATATYPE].DefaultValue = 1;
            this._repairTable.Columns[COL_PRICETYPE].DefaultValue = 1;
            this._repairTable.Columns[COL_REPAIRPRICE].DefaultValue = 0;

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
            for (int i = 0; i < this.AttendRepair_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.AttendRepair_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;
            }

            // データタイプ
            cols[COL_DATATYPE].Hidden = true;
            cols[COL_DATATYPE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList();
            valueList1.ValueListItems.Add("1", "作業");
            valueList1.ValueListItems.Add("2", "部品");
            cols[COL_DATATYPE].ValueList = valueList1;

            // 金額タイプ
            cols[COL_PRICETYPE].Hidden = false;
            cols[COL_PRICETYPE].Width = 40;
            cols[COL_PRICETYPE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList();
            valueList2.ValueListItems.Add("1", "単価");
            valueList2.ValueListItems.Add("2", "金額");
            cols[COL_PRICETYPE].ValueList = valueList2;

            // 名称
            cols[COL_REPAIRNAME].Hidden = false;
            cols[COL_REPAIRNAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_REPAIRNAME].MaxLength = 60;

            // 金額
            cols[COL_REPAIRPRICE].Hidden = false;
            cols[COL_PRICETYPE].Width = 100;
            cols[COL_REPAIRPRICE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_REPAIRPRICE].Format = CT_MONEYFORMAT;
            cols[COL_REPAIRPRICE].MaxLength = 9;
            cols[COL_REPAIRPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
        }
        #endregion

        #region データ→Table反映
        /// <summary>
        /// 取得したデータをテーブルにセットします
        /// </summary>
        private void SetDataTable()
        {
            this._repairTable.Rows.Clear();

            if (this._repairDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                foreach (AttendRepairSet set in this._repairDic[(long)this.Category_ComboEditor.Value])
                {
                    DataRow row = this._repairTable.NewRow();
                    row[COL_DATA] = set;
                    row[COL_DATATYPE] = set.dataType;
                    row[COL_DEL] = set.logicalDelDiv;
                    row[COL_PRICETYPE] = set.priceType;
                    row[COL_REPAIRNAME] = set.repairName;
                    row[COL_REPAIRPRICE] = set.repairPrice;
                    row[COL_SORTNO] = set.sortNo;
                    this._repairTable.Rows.Add(row);
                }
            }
            DataView view = this._repairTable.DefaultView;
            view.Sort = COL_SORTNO + " ASC";
            // フィルター掛けてみる
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            view.RowFilter = filter.ToString();
            this.AttendRepair_Grid.DataSource = view;
        }
        #endregion

        #region 検索

        #region 商品カテゴリ
        /// <summary>
        /// カテゴリリスト作成
        /// </summary>
        private void SetGoodsCategory()
        {
            foreach (GoodsCategory category in this._categoryList)
            {
                this.Category_ComboEditor.Items.Add(category.GoodsCategoryId, category.GoodsCategoryName);
            }
            // 初期選択はタイヤ
            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged); 
            this._selectIndex = 0;
            this.Category_ComboEditor.SelectedIndex = 0;
            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged); 
        }
        #endregion

        #region 付随整備
        /// <summary>
        /// 付随整備設定全件取得
        /// </summary>
        /// <returns></returns>
        private int SearchAttendRepairSet(string enterPriseCode)
        {
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetAttendRepairSet(enterPriseCode, out attendRepairSetList, out errMsg);
            if (st == 0)
            {
                // ディクショナリーにセット
                foreach (AttendRepairSet ripairSet in attendRepairSetList)
                {
                    if (this._repairDic.ContainsKey(ripairSet.goodsCategoryId))
                    {
                        this._repairDic[ripairSet.goodsCategoryId].Add(ripairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(ripairSet);
                        this._repairDic.Add(ripairSet.goodsCategoryId, wkList);
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                     this,							                // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                     CT_ASSEMBLYID,					                // アセンブリIDまたはクラスID
                     "付随整備情報の取得に失敗しました。",	        // 表示するメッセージ 
                     st,								            // ステータス値
                     MessageBoxButtons.OK);
            }
            return st;
        }
        #endregion

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
            AttendRepairSet[] saveArray = new AttendRepairSet[0];
            this.MakeSaveData(ref saveArray);

            // 保存対象データがなければ処理中断
            if (saveArray == null || saveArray.Length == 0)
            {
                return 0;
            }

            // 保存実行
            st = this._TBOServiceACS.SaveAttendRepairSet(ref saveArray, out errMsg);

            if (st == 0)
            {
                 TMsgDisp.Show(
                       this,								// 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                       CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                       "保存しました。",			// 表示するメッセージ 
                       0,								// ステータス値
                       MessageBoxButtons.OK);

                 this._saveDiv = true;

                // Dic最新化
                List<AttendRepairSet> list = new List<AttendRepairSet>();
                if (saveArray != null)
                {
                    list.AddRange(saveArray);
                }

                if (this._repairDic.ContainsKey((long)this.Category_ComboEditor.Value))
                {
                    this._repairDic.Remove((long)this.Category_ComboEditor.Value);
                    this._repairDic.Add((long)this.Category_ComboEditor.Value, list);
                }
                else
                {
                    this._repairDic.Add((long)this.Category_ComboEditor.Value, list);
                }
                // テーブル再作成
                this.SetDataTable();
            }
            else
            {
                 TMsgDisp.Show(
                     this,							    // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                     CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                     "付随整備の登録に失敗しました。",		// 表示するメッセージ 
                     st,								    // ステータス値
                     MessageBoxButtons.OK);
            }
            return st;
        }

        /// <summary>
        /// 保存対象データ作成
        /// </summary>
        /// <param name="saveArray"></param>
        private void MakeSaveData(ref AttendRepairSet[] saveArray)
        {
            // 描画停止
            this.AttendRepair_Grid.BeginUpdate();

            // 一旦フィルターを解除
            this._repairTable.DefaultView.RowFilter = "";

            // 未保存の削除データをテーブルから削除
            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2} is {3}" ,COL_DEL, 1, COL_DATA, "null"));

            DataRow[] delRows = this._repairTable.Select(cndString.ToString());
            foreach (DataRow delRow in delRows)
            {
                delRow.Delete();
            }
            this._repairTable.AcceptChanges();

            List<AttendRepairSet> retList = new List<AttendRepairSet>();
            for (int i = 0; i < this._repairTable.DefaultView.Count; i++)
            {
                AttendRepairSet set = new AttendRepairSet();
                if (this._repairTable.DefaultView[i].Row[COL_DATA] != DBNull.Value)
                {
                    set = (((AttendRepairSet)this._repairTable.DefaultView[i].Row[COL_DATA]).Clone());
                }
                set.enterpriseCode = this._enterPriseCode;
                set.goodsCategoryId = (long)this.Category_ComboEditor.Value;

                set.dataType = (int)this._repairTable.DefaultView[i].Row[COL_DATATYPE];
                set.priceType = (int)this._repairTable.DefaultView[i].Row[COL_PRICETYPE];
                set.repairName = this._repairTable.DefaultView[i].Row[COL_REPAIRNAME].ToString();
                set.repairPrice = (long)this._repairTable.DefaultView[i].Row[COL_REPAIRPRICE];
                set.sortNo = i + 1;
                set.logicalDelDiv = (int)this._repairTable.DefaultView[i].Row[COL_DEL];
                retList.Add(set);
            }
            saveArray = retList.ToArray();

            // 再度フィルターセット
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            this._repairTable.DefaultView.RowFilter = filter.ToString();

            // 描画停止
            this.AttendRepair_Grid.EndUpdate();
            this.UpDateGrid();
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
            this._repairTable.AcceptChanges();

            // データ内容比較
            for (int i = 0; i < this._repairTable.Rows.Count; i++)
            {
                DataRow row = this._repairTable.Rows[i];
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
                        AttendRepairSet set = (AttendRepairSet)row[COL_DATA];
                        // データタイプ
                        if (!set.dataType.Equals((int)row[COL_DATATYPE]))
                        {
                            return true;
                        }
                        // 金額タイプ
                        if (!set.priceType.Equals((int)row[COL_PRICETYPE]))
                        {
                            return true;
                        }
                        // ソート順
                        if (!set.sortNo.Equals((int)row[COL_SORTNO]))
                        {
                            return true;
                        }
                        // 整備名称
                        if (!set.repairName.Equals(row[COL_REPAIRNAME].ToString()))
                        {
                            return true;
                        }
                        // 整備金額
                        if (!set.repairPrice.Equals((long)row[COL_REPAIRPRICE]))
                        {
                            return true;
                        }
                    }
                }
            }
            return ret;
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

                this.AttendRepair_Grid.ActiveCell = this.AttendRepair_Grid.Rows[rowIndex].Cells[columnNm];
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
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
            for (int ix = 0; ix < this.AttendRepair_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.AttendRepair_Grid.Rows[ix];

                // 未入力チェック  名称
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_REPAIRNAME].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "名称を入力して下さい。";
                    columnNm = COL_REPAIRNAME;
                    return false;
                }

                // 未入力チェック  金額
                if (GetCellLong(ugRow.Cells[COL_REPAIRPRICE].Value, 0) == 0)
                {
                    rowIndex = ix;
                    errMsg = "金額を入力して下さい。";
                    columnNm = COL_REPAIRPRICE;
                    return false;
                }
            }
            return result;
        }
        #endregion

        #region グリッド関連処理

        #region グリッドアップデート処理
        /// <summary>
        /// グリッドアップデート処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドのアップデート処理を行います。</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.AttendRepair_Grid.UpdateData();
            this.AttendRepair_Grid.Refresh();
        }
        #endregion

        #region キー制御
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key) == true)
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (Char.IsNumber(key) == false)
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region GridValue取得処理
        /// <summary>
        /// セル→Int32取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得数値</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private Int32 GetCellInt32(object value, Int32 defaultValue)
        {
            return (value != DBNull.Value) ? (int)value : defaultValue;
        }

        /// <summary>
        /// セル→long取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得数値</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private long GetCellLong(object value, long defaultValue)
        {
            return (value != DBNull.Value) ? (long)value : defaultValue;
        }

        /// <summary>
        /// セル→文字列取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得文字列</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private string GetCellString(object value, string defaultValue)
        {
            return (value != DBNull.Value) ? (string)value : defaultValue;
        }
        #endregion


        #endregion

        #endregion

        #endregion

        #region Event

        #region Category_ComboEditor_ValueChanged
        /// <summary>
        /// カテゴリ変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 変更チェック
            if (this._selectIndex != this.Category_ComboEditor.SelectedIndex)
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
                            this._selectIndex = this.Category_ComboEditor.SelectedIndex;
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // 保存に失敗
                            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                            this.Category_ComboEditor.SelectedIndex = this._selectIndex;
                            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // 編集内容を破棄 インデックを更新
                        this._selectIndex = this.Category_ComboEditor.SelectedIndex;
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // キャンセル →　戻す
                        this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                        this.Category_ComboEditor.SelectedIndex = this._selectIndex;
                        this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // データ変更なし
                    // インデックスを更新
                    this._selectIndex = this.Category_ComboEditor.SelectedIndex;
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

        #region AttendRepair_Grid_InitializeLayout
        /// <summary>
        /// グリッド概観設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // グリッドのカラム情報を設定します。
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
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
            layout.Override.SelectTypeCell = SelectType.Single;
            layout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
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
            // 列のソート不可
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
        }
        #endregion

        #region Grid_KeyPress
        /// <summary>
        /// Grid_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.AttendRepair_Grid.ActiveCell;

                switch (cell.Column.Key)
                {
                    case COL_REPAIRPRICE:
                        if (this.AttendRepair_Grid.ActiveCell.Activation == Activation.AllowEdit && this.AttendRepair_Grid.ActiveCell.IsInEditMode)
                        {
                            if (!KeyPressCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 行追加、削除
        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_ultraButton_Click(object sender, EventArgs e)
        {
            DataRow row = this._repairTable.NewRow();

            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2}=MAX({3})", COL_DEL, 0, COL_SORTNO, COL_SORTNO));

            DataRow[] rows = this._repairTable.Select(cndString.ToString());
            if (rows.Length > 0)
            {
                row[COL_SORTNO] = (int)rows[0][COL_SORTNO] + 1;
            }
            else
            {
                row[COL_SORTNO] = 1;
            }
            this._repairTable.Rows.Add(row);

            this.AttendRepair_Grid.Focus();
            UltraGridRow ugRow = this.AttendRepair_Grid.GetRow(ChildRow.Last);
            if (ugRow != null)
            {
                ugRow.Cells[COL_REPAIRNAME].Activate();
                ugRow.Cells[COL_REPAIRNAME].Selected = true;
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.UpDateGrid();
        }

        /// <summary>
        /// 行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRow_Button_Click(object sender, EventArgs e)
        {
            if (this.AttendRepair_Grid.Selected.Rows.Count > 0)
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
                    foreach (UltraGridRow row in this.AttendRepair_Grid.Selected.Rows)
                    {
                        // 保存済行
                        row.Cells[COL_DEL].Value = 1;
                    }
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.AttendRepair_Grid.ActiveRow != null)
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
                   this.AttendRepair_Grid.ActiveRow.Cells[COL_DEL].Value = 1;
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.AttendRepair_Grid.ActiveCell != null)
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
                    this.AttendRepair_Grid.ActiveCell.Row.Cells[COL_DEL].Value = 1;
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
        }
        #endregion

        #region 保存、終了
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // 保存処理
            this.SaveProc();
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
        /// フォームクロージング
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepairSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 更新確認
            if (CheckUpdate())
            {
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
                        // 保存失敗
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
        #endregion

        #region Gridイレギュラー制御
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                CellDataErrorProc();
                e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                e.StayInEditMode = false;			// 編集モードは抜ける
            }
        }

        /// <summary>
        /// セル更新エラ発生時処理
        /// </summary>
        private void CellDataErrorProc()
        {
            // 数値項目の場合
            if ((this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(double)))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = this.AttendRepair_Grid.ActiveCell.EditorResolved;

                // 未入力は0にする
                if (editorBase.CurrentEditText.Trim() == "")
                {
                    editorBase.Value = 0;				// 0をセット
                    this.AttendRepair_Grid.ActiveCell.Value = 0;
                }
                // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                else if ((editorBase.CurrentEditText.Trim() == "-") ||
                    (editorBase.CurrentEditText.Trim() == ".") ||
                    (editorBase.CurrentEditText.Trim() == "-."))
                {
                    editorBase.Value = 0;				// 0をセット
                    this.AttendRepair_Grid.ActiveCell.Value = 0;
                }
                // 通常入力
                else
                {
                    try
                    {
                        editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.AttendRepair_Grid.ActiveCell.Column.DataType);
                        this.AttendRepair_Grid.ActiveCell.Value = editorBase.Value;
                    }
                    catch
                    {
                        editorBase.Value = 0;
                        this.AttendRepair_Grid.ActiveCell.Value = 0;
                    }
                }
            }
        }


        /// <summary>
        /// AttendRepair_Grid_CellChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_CellChange(object sender, CellEventArgs e)
        {
            // 現在のアクティブセルのスタイルがEdit or Default の場合
            if ((this.AttendRepair_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                (this.AttendRepair_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default))
            {
                // 変更された結果、Textが空白となった場合
                if ((this.AttendRepair_Grid.ActiveCell.Text == null) || ((this.AttendRepair_Grid.ActiveCell.Text != null) && (this.AttendRepair_Grid.ActiveCell.Text.Trim() == "")))
                {
                    // 現在のセルの型が、Int32、Int64、double型の場合
                    if ((this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                        (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                        (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(double)))
                    {
                        // 値を空白とはせずに、"0"をセットする
                        this.AttendRepair_Grid.ActiveCell.Value = 0;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// AttendRepair_Grid_AfterPerformAction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.NextCellByTab:
                case UltraGridAction.PrevCell:
                case UltraGridAction.PrevCellByTab:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    //アクティブなセルが存在するか？
                    if (this.AttendRepair_Grid.ActiveCell != null)
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.AttendRepair_Grid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:

                                if (this.AttendRepair_Grid.ActiveCell.Column.CellActivation == Activation.AllowEdit)
                                {
                                    //編集モードにする。
                                    if (this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        //編集モードになっている
                                        if (this.AttendRepair_Grid.ActiveCell.IsInEditMode)
                                        {
                                            // 全選択状態にする。
                                            this.AttendRepair_Grid.ActiveCell.SelStart = 0;
                                            this.AttendRepair_Grid.ActiveCell.SelLength = this.AttendRepair_Grid.ActiveCell.Text.Length;
                                        }
                                    }
                                }
                                break;
                            default:
                                // エディット系以外のスタイルであれば、編集状態にする。
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// AttendRepair_Grid_AfterEnterEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // 編集モードになったら選択状態
            this.AttendRepair_Grid.ActiveCell.SelectAll();
        }

        #endregion

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
                case "AttendRepair_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;
                                   
                                        if (e.ShiftKey)
                                        {
                                            // 最初のセル
                                            if (this.AttendRepair_Grid.ActiveCell != null && this.AttendRepair_Grid.ActiveCell.Column.Key == COL_REPAIRNAME)
                                            {
                                                if (this.AttendRepair_Grid.ActiveCell.Row.HasPrevSibling())
                                                {
                                                    UltraGridRow prevRow = this.AttendRepair_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                    UltraGridCell prevCel = null;

                                                    prevCel = prevRow.Cells[COL_REPAIRPRICE];

                                                    if (prevCel != null)
                                                    {
                                                        prevCel.Activate();
                                                        prevCel.Selected = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            // 最終セル
                                            if (this.AttendRepair_Grid.ActiveCell != null && this.AttendRepair_Grid.ActiveCell.Column.Key == COL_REPAIRPRICE)
                                            {
                                                if (this.AttendRepair_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.AttendRepair_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_REPAIRNAME];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
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

        /// <summary>
        /// AttendRepair_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                // アクティブセル
                UltraGridCell activeCell = this.AttendRepair_Grid.ActiveCell;

                switch (e.KeyData)
                {
                    // ←キー
                    case Keys.Left:
                        if(activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        break;
                    // →キー
                    case Keys.Right:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        //e.Handled = true;
                        break;
                    // ↑キー
                    case Keys.Up:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
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
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.AddRow_ultraButton.Focus();
                            }
                        }
                        else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (activeCell.DroppedDown)
                            {
                                return;
                            }
                            else
                            {
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
                                            this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.AddRow_ultraButton.Focus();
                                }
                            }
                        }
                     
                        e.Handled = true;
                        break;
                    // ↓キー
                    case Keys.Down:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
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
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                        }
                        else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (activeCell.DroppedDown)
                            {
                                return;
                            }
                            else if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                if (belowCel != null)
                                {
                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                        }
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_Enter(object sender, EventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                this.AttendRepair_Grid.ActiveCell.Selected = true;
                this.AttendRepair_Grid.ActiveCell.Activate();
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
            else
            {
                if (this.AttendRepair_Grid.Rows.Count > 0)
                {
                    this.AttendRepair_Grid.Rows[0].Cells[COL_REPAIRNAME].Selected = true;
                    this.AttendRepair_Grid.Rows[0].Cells[COL_REPAIRNAME].Activate();
                    this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }   
    }
}
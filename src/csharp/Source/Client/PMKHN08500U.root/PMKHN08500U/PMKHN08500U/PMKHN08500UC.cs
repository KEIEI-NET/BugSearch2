using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Windows.Forms;  // 2010/03/31 Add

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// インポート対象設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : インポート対象の設定を行うクラスです。</br>
    /// <br>Programer  : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/03/31</br>
    /// </remarks>
    public partial class PMKHN08500UC : Form
    {
        public PMKHN08500UC(string fileName, string xmlName)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(222, 239, 255);
            FileName_tEdit.Text = fileName;
            _xmlFileName = Path.GetFileNameWithoutExtension(xmlName);
        }

        private const string COLUMN_FILENM = "FileNm";
        private const string COLUMN_ITEMID = "ItemId";
        private const string COLUMN_ITEMNAME = "ItemName";
        private const string COLUMN_UPDATECD = "UpdateCd";
        private string _xmlFileName = string.Empty;
        private List<SetUpControlInfo> _setUpControlInfoList = new List<SetUpControlInfo>();

        private void PMKHN08500UC_Load(object sender, EventArgs e)
        {
            CreateGrid();
            SetGridLayout();
            if (LoadToFiles(_xmlFileName, out _setUpControlInfoList) != 0)
            {
                _setUpControlInfoList = getSetUpControlInfoList(_xmlFileName);
            }
            CreateNewRow(ref this.uGrid_Details, _setUpControlInfoList);

            this.uGrid_Details.Rows[0].Cells[3].Activate();
        }

        /// <summary>
        /// グリッドを作成します。
        /// </summary>
        private void CreateGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(COLUMN_FILENM, typeof(string));
            dt.Columns.Add(COLUMN_ITEMID, typeof(int));
            dt.Columns.Add(COLUMN_ITEMNAME, typeof(string));
            dt.Columns.Add(COLUMN_UPDATECD, typeof(string));
            this.uGrid_Details.DataSource = dt;
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
        }

        /// <summary>
        /// SetUpControlInfoListの内容をGridに追加します。
        /// </summary>
        /// <param name="uGrid">追加対象のGrid</param>
        /// <param name="setUpControlInfoList">SetUpControlInfoList</param>
        private void CreateNewRow(ref UltraGrid uGrid,List<SetUpControlInfo> setUpControlInfoList)
        {
            foreach (SetUpControlInfo setUpControlInfo in setUpControlInfoList)
            {
                uGrid.DisplayLayout.Bands[0].AddNew();

                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMID].Value = setUpControlInfo.ItemId;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMNAME].Value = setUpControlInfo.ItemName;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILENM].Value = setUpControlInfo.FileName;
                uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_UPDATECD].Value = setUpControlInfo.UpdateDiv;
            }
        }

        /// <summary>
        /// グリッドのレイアウトを設定します。
        /// </summary>
        private void SetGridLayout()
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 入力不可
            columns[COLUMN_FILENM].CellActivation = Activation.NoEdit;
            columns[COLUMN_ITEMID].CellActivation = Activation.NoEdit;
            columns[COLUMN_ITEMNAME].CellActivation = Activation.NoEdit;

            // キャプション
            columns[COLUMN_FILENM].Header.Caption = "ファイル名称";
            columns[COLUMN_ITEMID].Header.Caption = "項目ＩＤ";
            columns[COLUMN_ITEMNAME].Header.Caption = "項目名称";
            columns[COLUMN_UPDATECD].Header.Caption = "更新区分";

            // 列幅
            columns[COLUMN_FILENM].Width = 174;
            columns[COLUMN_ITEMID].Width = 50;
            columns[COLUMN_ITEMNAME].Width = 160;
            columns[COLUMN_UPDATECD].Width = 92;

            // 非表示
            columns[COLUMN_ITEMID].Hidden = true;

            // テキスト位置
            for (int i = 0; i < columns.Count; i++)
            {
                columns[i].CellAppearance.TextVAlign = VAlign.Middle;
            }

            // コンボボックス設定
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "する");
            valueList.ValueListItems.Add(1, "しない");
            columns[COLUMN_UPDATECD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[COLUMN_UPDATECD].ValueList = valueList.Clone();
        }

        /// <summary>
        /// SetUpControlInfoListの初期値を設定します。
        /// </summary>
        /// <param name="xmlName">DLL名</param>
        /// <returns>SetUpControlInfoList</returns>
        private List<SetUpControlInfo> getSetUpControlInfoList(string xmlName)
        {
            List<SetUpControlInfo> list = new List<SetUpControlInfo>();
            switch (xmlName)
            {
                case "PMKHN07630U":
                    list = GetSetUpControlinfoList07630();
                    break;
            }
            return list;
        }

        /// <summary>
        /// 商品マスタインポート時のSetUpControlInfoList初期値をセットします。
        /// </summary>
        /// <returns>SetUpControlInfoList</returns>
        private List<SetUpControlInfo> GetSetUpControlinfoList07630()
        {
            List<SetUpControlInfo> list = new List<SetUpControlInfo>();
            SetUpControlInfo addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 3;
            addList.ItemName = "品名";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 4;
            addList.ItemName = "品名ｶﾅ";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 5;
            addList.ItemName = "ＪＡＮコード";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 6;
            addList.ItemName = "ＢＬコード";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 7;
            addList.ItemName = "商品区分";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 8;
            addList.ItemName = "層別";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 9;
            addList.ItemName = "純優区分";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 10;
            addList.ItemName = "課税区分";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 11;
            addList.ItemName = "商品備考１";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 12;
            addList.ItemName = "商品備考２";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "商品マスタ";
            addList.ItemId = 13;
            addList.ItemName = "規格・特記事項";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 15;
            addList.ItemName = "価格１";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 16;
            addList.ItemName = "オープン価格区分１";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 17;
            addList.ItemName = "仕入率１";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 18;
            addList.ItemName = "原単価１";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 20;
            addList.ItemName = "価格２";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 21;
            addList.ItemName = "オープン価格区分２";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 22;
            addList.ItemName = "仕入率２";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 23;
            addList.ItemName = "原単価２";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 25;
            addList.ItemName = "価格３";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 26;
            addList.ItemName = "オープン価格区分３";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 27;
            addList.ItemName = "仕入率３";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 28;
            addList.ItemName = "原単価３";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 30;
            addList.ItemName = "価格４";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 31;
            addList.ItemName = "オープン価格区分４";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 32;
            addList.ItemName = "仕入率４";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 33;
            addList.ItemName = "原単価４";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 35;
            addList.ItemName = "価格５";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 36;
            addList.ItemName = "オープン価格区分５";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 37;
            addList.ItemName = "仕入率５";
            list.Add(addList);

            addList = new SetUpControlInfo();
            addList.FileName = "価格マスタ";
            addList.ItemId = 38;
            addList.ItemName = "原単価５";
            list.Add(addList);

            return list;
        }

        /// <summary>
        /// インポート対象設定を読み込みます。
        /// </summary>
        /// <param name="fileName">インポートDLL名</param>
        /// <param name="list">SetUpControlInfoList</param>
        /// <returns>status</returns>
        public int LoadToFiles(string fileName, out List<SetUpControlInfo> list)
        {
            // 読込処理
            int status = 0;
            list = new List<SetUpControlInfo>();
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML")))
            {
                list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML"));
            }
            else
            {
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// インポート対象設定を保存します。
        /// </summary>
        /// <param name="fileName">保存先のXMLファイル名</param>
        /// <param name="list">SetUpControlInfoList</param>
        /// <returns>status</returns>
        private int SaveToFiles(string fileName, List<SetUpControlInfo> list)
        {
            int status = 0;
            UserSettingController.SerializeUserSetting(list, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName + "_Construction.XML"));
            return status;
        }

        /// <summary>
        /// 保存ボタンより設定内容の保存を行います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            int updCnt = 0;
            this.Ok_Button.Focus();
            for (int index = 0; index < uGrid_Details.Rows.Count; index++)
            {
                object updateDiv = uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
                _setUpControlInfoList[index].UpdateDiv = Convert.ToInt32(updateDiv);
                if (Convert.ToInt32(updateDiv) == 0)
                    updCnt++;
            }
            if (updCnt == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN08500U",
                    "更新対象を設定してください。", 0, MessageBoxButtons.OK);
                return;
            }
            SaveToFiles(_xmlFileName, _setUpControlInfoList);
            this.Close();
        }

        /// <summary>
        /// 閉じるボタンより、画面を閉じます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // グリッド
                case "uGrid_Details":
                    {
                        #region グリッド

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.Rows[0].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex < 3)
                                {
                                    // にフォーカス
                                    this.uGrid_Details.Rows[rowIndex].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == 3)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        // フォーカス移動なし
                                        //this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        e.NextCtrl = this.Ok_Button;
                                        this.uGrid_Details.ActiveCell = null;
                                        return;
                                    }
                                    else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 5;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex <= 3)
                                {
                                    if (rowIndex == 0)
                                    {
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex - 1].Cells[3].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        break;

                        #endregion
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // グリッド
                case "uGrid_Details":
                    {
                        #region グリッド

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;

                                    this.uGrid_Details.Rows[0].Cells[3].Activate();

                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.Cancel_Button;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[3].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;

                        #endregion
                    }
            }
        }
    }
}
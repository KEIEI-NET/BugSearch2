//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 企業コードガイド画面
// プログラム概要   : 企業コードガイド画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李亜博
// 作 成 日  2012/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// 企業コードガイド画面
    /// </summary>
    /// <remarks>
    /// <br>Note       : 企業コードガイド画面</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update     : </br>
    /// </remarks>

    public partial class PMKYO09501UC : Form
    {
        #region ■ Constructor ■
        /// <summary>
        /// 企業コードガイド画面 コンストラクタ
        /// </summary>
        /// <param name="detail">送受信履歴ログ参照メンテ画面</param>
        /// <param name="enterpriseCodeList">企業コードガイドリスト</param>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public PMKYO09501UC(PMKYO09501UA detail, ArrayList enterpriseCodeList)
        {
            InitializeComponent();
            InitialSetting();
            DataSetColumnConstruction();

            this._PMKYO09501UA = detail;
            this._enterpriseCodeList = enterpriseCodeList;
        }
        #endregion ■ Constructor ■


        #region ■ Private Field ■
        private PMKYO09501UA _PMKYO09501UA = null;
        private DataTable _detailsTable;
        private ImageList _imageList16 = null;
        private ArrayList _enterpriseCodeList;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _cancelButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _selectButton;
        #endregion ■ Private Field ■

        #region ■ Const Memebers ■
        private const string ENTER_CODE = "企業コード";
        private const string ENTER_NAME = "企業コード名称";
        private const string CT_CLASSID = "PMKYO09501UC";
        #endregion ■ Const Memebers ■

        #region ■ Private Method ■

        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定処理です</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void InitialSetting()
        {
            _detailsTable = new DataTable();
            // ボタン変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._cancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Select"];

        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._cancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : 画面ロードイベント</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void PMKYO09501UC_Load(object sender, EventArgs e)
        {
            ButtonInitialSetting();
            DetailShow();
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット列情報構築処理です</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {

            this._detailsTable.Columns.Add(ENTER_CODE, typeof(string));
            this._detailsTable.Columns.Add(ENTER_NAME, typeof(string));

            this.uGrid_Details.DataSource = _detailsTable;
        }

        /// <summary>
        /// レコードの列のスタイルの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レコードの列のスタイルの設定</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void SetColumnStyle()
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 表示幅設定
            Columns[this._detailsTable.Columns[ENTER_CODE].ColumnName].Width = 100;
            Columns[this._detailsTable.Columns[ENTER_NAME].ColumnName].Width = 200;

            // 入力許可設定
            Columns[this._detailsTable.Columns[ENTER_CODE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._detailsTable.Columns[ENTER_NAME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// 詳細情報を表示する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細情報を表示する</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>

        private void DetailShow()
        {
            this._detailsTable.Clear();
            try
            {
                if (_enterpriseCodeList != null && _enterpriseCodeList.Count > 0)
                {
                    for (int i = 0; i < _enterpriseCodeList.Count - 1; i++)
                    {
                        DataRow row = this._detailsTable.NewRow();
                        row[_detailsTable.Columns[ENTER_CODE].ColumnName] = _enterpriseCodeList[i];
                        row[_detailsTable.Columns[ENTER_NAME].ColumnName] = _enterpriseCodeList[++i];
                        this._detailsTable.Rows.Add(row);
                    }
                }
                else
                {
                    DataRow row = this._detailsTable.NewRow();
                    row[_detailsTable.Columns[ENTER_CODE].ColumnName] = "";
                    row[_detailsTable.Columns[ENTER_NAME].ColumnName] = "";
                    this._detailsTable.Rows.Add(row);
                }
                this.uGrid_Details.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                this.Close();

                TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            CT_CLASSID,
                            ex.Message,
                             0,									    // ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
            }

        }

        #endregion ■ Private Method ■



        #region ■ Event ■

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Cancel":
                    {
                        //画面閉じる。
                        this.Close();
                    }
                    break;

                case "ButtonTool_Select":
                    {
                        if ((string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value != null && (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value != null)
                        {
                            _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                            _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                            this.Close();
                        }

                    }
                    break;
            }
        }

        /// <summary>
        /// レコードダブルクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoubleClickCellEventArgs</param>
        /// <remarks>
        /// <br>Note       : レコードダブルクリックイベント</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell != null)
            {
                _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                this.Close();
            }
        }

        /// <summary>
        /// KeyDown処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 企業コードグリッドのマウス右クリック処理。</br>
        /// <br>Programmer  : </br>
        /// <br>Date        : 2012/07/25</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (uGrid_Details.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                    _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                    this.Close();
                }
            }
        }

        #endregion ■ Event ■
    }
}
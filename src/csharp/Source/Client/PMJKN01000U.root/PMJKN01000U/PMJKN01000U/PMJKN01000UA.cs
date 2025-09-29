using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自由検索部品自動登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品自動登録のフォームクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
    /// </remarks>
    public partial class PMJKN01000UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;

        private AutoEntryFreeSearchPartsAcs _autoEntryFSPartsAcs;
        private AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable _autoEntryFSPartsDataTable;
        private AutoEntryFreeSearchPartsDataSet.CarModelDataTable _carModelDataTable;

        private int _carSelectNo;
        private DataView _autoEntryGoodsView = null;
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _prevButton;		// 前へボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextButton;		// 次へボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _countLabel;        // 選択番号ラベル

        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMJKN01000UA()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._autoEntryFSPartsAcs = AutoEntryFreeSearchPartsAcs.GetInsctance();

            this._autoEntryFSPartsDataTable = null;
            this._carModelDataTable = null;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];

            this._prevButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Prev"];
            this._nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Next"];

            this._countLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LblCntDisplay"];
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// フォームLoadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMJKN01000UI_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------
            // ツールバーボタン初期設定
            //---------------------------------------------------------
            this.ButtonInitialSetting();

            //---------------------------------------------------------
            // 初期設定タイマー起動
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // 自動登録データテーブル
            //---------------------------------------------------------
            
            // ※呼出元でAutoEntryCheckメソッドを実行してから、
            //   このＵＩのShowDialogを呼び出す処理を想定しているが、
            //   念のため、AutoEntryCheckを実行しなくても呼び出せるようにする。
            if ( _autoEntryFSPartsDataTable == null )
            {
                CreateAutoEntryFSPartsDataTable( this._salesSlipInputAcs );
            }

            //---------------------------------------------------------
            // グリッド情報設定
            //---------------------------------------------------------
            this._autoEntryGoodsView = this._autoEntryFSPartsDataTable.DefaultView;
            this.uGrid_AutoEntryFSParts.DataSource = this._autoEntryGoodsView;

            // 表示更新
            _carSelectNo = 1;
            if ( _autoEntryFSPartsDataTable.Rows.Count > 0 )
            {
                this.DisplayCarModel( _carSelectNo );
            }
        }

        /// <summary>
        /// 型式情報表示
        /// </summary>
        /// <param name="dataRow"></param>
        private void DisplayCarModel( int carSelectNo )
        {
            // 該当の型式rowを取得
            AutoEntryFreeSearchPartsDataSet.CarModelRow[] carModelRows
                = (AutoEntryFreeSearchPartsDataSet.CarModelRow[])_carModelDataTable.Select(
                    string.Format( "{0}={1}", _carModelDataTable.CarSelectNoColumn.ColumnName, carSelectNo ) 
                  );
            if ( carModelRows.Length == 0 )
            {
                return;
            }

            // ヘッダ部の型式情報を表示
            tNedit_ModelDesignationNo.SetInt( carModelRows[0].ModelDesignationNo );
            tNedit_CategoryNo.SetInt( carModelRows[0].CategoryNo );
            tEdit_EngineModelNm.Text = carModelRows[0].EngineModelNm;
            tEdit_FullModel.Text = carModelRows[0].FullModel;
            tNedit_MakerCode.SetInt( carModelRows[0].MakerCode );
            tNedit_ModelCode.SetInt( carModelRows[0].ModelCode );
            tNedit_ModelSubCode.SetInt( carModelRows[0].ModelSubCode );
            tEdit_ModelFullName.Text = carModelRows[0].ModelFullName;
            tDateEdit_FirstEntryDate.SetDateTime( carModelRows[0].FirstEntryDate );
            tEdit_ProduceFrameNo.Text = carModelRows[0].ProduceFrameNo;

            // 明細にフィルタをかける
            _autoEntryGoodsView.RowFilter = string.Format( "{0}={1}", _autoEntryFSPartsDataTable.CarSelectNoColumn.ColumnName, carSelectNo );

            // ラベル表示変更
            SetCountLabel( carSelectNo );
        }

        /// <summary>
        /// 型式選択番号ラベル更新
        /// </summary>
        /// <param name="carSelectNo"></param>
        private void SetCountLabel( int carSelectNo )
        {
            // ラベルキャプション更新
            this._countLabel.SharedProps.Caption = string.Format( "{0} / {1}", carSelectNo, _carModelDataTable.Rows.Count );

            // 戻る/進む ボタン有効・無効切り替え
            _prevButton.SharedProps.Enabled = (carSelectNo > 1);
            _nextButton.SharedProps.Enabled = (carSelectNo < _carModelDataTable.Rows.Count);
        }

        /// <summary>
        /// 自由検索部品自動登録テーブル生成
        /// </summary>
        /// <param name="salesSlipInputAcs"></param>
        /// <returns></returns>
        private void CreateAutoEntryFSPartsDataTable( SalesSlipInputAcs salesSlipInputAcs )
        {
            // データ初期化
            _autoEntryFSPartsAcs.ClearTables();
            _autoEntryFSPartsDataTable = _autoEntryFSPartsAcs.AutoEntryFSPartsDataTable;
            _carModelDataTable = _autoEntryFSPartsAcs.CarModelDataTable;

            AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow newRow;

            foreach ( SalesInputDataSet.SalesDetailRow row in salesSlipInputAcs.SalesDetailDataTable.Rows )
            {
                // BLコード未設定は除く
                if ( row.BLGoodsCode == 0 ) continue;
                // 行値引は除く（BLコード=0のはずだが念のためチェック）
                if ( row.SalesSlipCdDtl == 2 && row.ShipmentCnt == 0 ) continue;
                // 注釈行は除く（BLコード=0のはずだが念のためチェック）
                if ( row.SalesSlipCdDtl == 3 ) continue;
                // BLコード検索で入力した明細は除く
                if ( row.SearchPartsModeState == (int)SalesSlipInputAcs.SearchPartsModeState.BLCodeSearch ) continue;


                // 売上明細に紐付く型式情報の一覧を取得
                PMKEN01010E carInfo = salesSlipInputAcs.GetCarInfoFromDic( row.SalesRowNo );
                SalesInputDataSet.CarInfoRow carInfoRow = salesSlipInputAcs.GetCarInfoRow( row.SalesRowNo, SalesSlipInputAcs.GetCarInfoMode.ExistGetMode );

                // 車輌に関する情報が無い場合は除く
                if ( carInfo == null ) continue;
                if ( carInfoRow == null ) continue;


                // 自由検索部品マスタ存在チェック
                if ( _autoEntryFSPartsAcs.CheckFreeSearchParts( LoginInfoAcquisition.EnterpriseCode.Trim(), carInfo, row.BLGoodsCode, row.GoodsNo, row.GoodsMakerCd ) )
                {
                    // 自由検索部品マスタがヒットする場合は、自動登録は不要
                    continue;
                }

                foreach ( PMKEN01010E.CarModelInfoRow carModelInfoRow in carInfo.CarModelInfo.Rows )
                {
                    // 型式選択チェック(そもそも型式検索で選択された型式なのかをチェックする)
                    if ( carModelInfoRow.SelectionState == false ) continue;

                    // 重複チェック(DataTable)
                    # region [重複チェック(DataTable)]
                    // ...既に追加用テーブルに格納されているものは除外する
                    AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[] targetRows
                        = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])_autoEntryFSPartsDataTable.Select( string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}' AND {10}='{11}' AND {12}='{13}'",
                              _autoEntryFSPartsDataTable.MakerCodeColumn.ColumnName, carModelInfoRow.MakerCode,
                              _autoEntryFSPartsDataTable.ModelCodeColumn.ColumnName, carModelInfoRow.ModelCode,
                              _autoEntryFSPartsDataTable.ModelSubCodeColumn.ColumnName, carModelInfoRow.ModelSubCode,
                              _autoEntryFSPartsDataTable.FullModelColumn.ColumnName, carModelInfoRow.FullModel,
                              _autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName, row.BLGoodsCode,
                              _autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName, row.GoodsNo,
                              _autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd ) );
                    // 存在チェック
                    if ( targetRows.Length > 0 )
                    {
                        continue;
                    }
                    # endregion

                    // 行№(RowNo)取得の為、合致する明細配列を取得
                    targetRows
                        = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])_autoEntryFSPartsDataTable.Select( string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                              _autoEntryFSPartsDataTable.MakerCodeColumn.ColumnName, carModelInfoRow.MakerCode,
                              _autoEntryFSPartsDataTable.ModelCodeColumn.ColumnName, carModelInfoRow.ModelCode,
                              _autoEntryFSPartsDataTable.ModelSubCodeColumn.ColumnName, carModelInfoRow.ModelSubCode,
                              _autoEntryFSPartsDataTable.FullModelColumn.ColumnName, carModelInfoRow.FullModel ) );


                    // 明細表示内容生成
                    # region [売上明細＋型式情報⇒自由検索部品自動登録用Row]
                    newRow = _autoEntryFSPartsDataTable.NewAutoEntryFreeSearchPartsRow();

                    // 部品情報
                    newRow.Checked = false;
                    newRow.RowNo = (targetRows.Length + 1);
                    newRow.BLGoodsCode = row.BLGoodsCode;
                    newRow.BLGoodsFullName = row.BLGoodsFullName;
                    newRow.DtlRelationGuid = row.DtlRelationGuid;
                    newRow.GoodsMakerCd = row.GoodsMakerCd;
                    newRow.GoodsName = row.GoodsName;
                    newRow.GoodsNo = row.GoodsNo;

                    // 類別型式・年式・車台番号
                    if ( carInfoRow != null )
                    {
                        newRow.ModelDesignationNo = carInfoRow.ModelDesignationNo;
                        newRow.CategoryNo = carInfoRow.CategoryNo;
                        newRow.FirstEntryDate = TDateTime.LongDateToDateTime( carInfoRow.FirstEntryDate );
                        newRow.ProduceFrameNo = carInfoRow.FrameNo;
                    }

                    // 型式情報
                    newRow.EngineModelNm = carModelInfoRow.EngineModelNm;
                    newRow.FullModel = carModelInfoRow.FullModel;
                    newRow.MakerCode = carModelInfoRow.MakerCode;
                    newRow.ModelCode = carModelInfoRow.ModelCode;
                    newRow.ModelSubCode = carModelInfoRow.ModelSubCode;
                    newRow.ModelFullName = carModelInfoRow.ModelFullName;


                    // 型式選択No.(UI制御用)
                    int carSelectNo;
                    AddCarModel( newRow, out carSelectNo );
                    newRow.CarSelectNo = carSelectNo;


                    _autoEntryFSPartsDataTable.Rows.Add( newRow );
                    # endregion
                }
            }
        }

        /// <summary>
        /// 型式テーブル(UI制御用)への追加＋選択番号の取得
        /// </summary>
        /// <param name="newRow"></param>
        /// <param name="carSelectNo"></param>
        private void AddCarModel( AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow partsRow, out int carSelectNo )
        {
            AutoEntryFreeSearchPartsDataSet.CarModelRow[] rows;
            rows = (AutoEntryFreeSearchPartsDataSet.CarModelRow[])_carModelDataTable.Select( string.Format( "{0}={1} AND {2}={3} AND {4}={5} AND {6}='{7}'",
                                                            _carModelDataTable.MakerCodeColumn.ColumnName, partsRow.MakerCode,
                                                            _carModelDataTable.ModelCodeColumn.ColumnName, partsRow.ModelCode,
                                                            _carModelDataTable.ModelSubCodeColumn.ColumnName, partsRow.ModelSubCode,
                                                            _carModelDataTable.FullModelColumn.ColumnName, partsRow.FullModel ) );
            if ( rows.Length > 0 )
            {
                // 既存あり
                carSelectNo = rows[0].CarSelectNo;
            }
            else
            {
                // 既存なし⇒追加
                AutoEntryFreeSearchPartsDataSet.CarModelRow newRow = _carModelDataTable.NewCarModelRow();
                carSelectNo = (_carModelDataTable.Rows.Count + 1);
                newRow.CarSelectNo = carSelectNo;

                # region [自由検索部品自動登録row⇒型式row]
                newRow.CategoryNo = partsRow.CategoryNo;
                newRow.EngineModelNm = partsRow.EngineModelNm;
                newRow.FirstEntryDate = partsRow.FirstEntryDate;
                newRow.FullModel = partsRow.FullModel;
                newRow.MakerCode = partsRow.MakerCode;
                newRow.ModelCode = partsRow.ModelCode;
                newRow.ModelDesignationNo = partsRow.ModelDesignationNo;
                newRow.ModelFullName = partsRow.ModelFullName;
                newRow.ModelSubCode = partsRow.ModelSubCode;
                newRow.ProduceFrameNo = partsRow.ProduceFrameNo;
                # endregion

                _carModelDataTable.Rows.Add( newRow );
            }
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            this.uGrid_AutoEntryFSParts.Focus();
            if ( uGrid_AutoEntryFSParts.Rows.Count > 0 )
            {
                this.uGrid_AutoEntryFSParts.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "uGrid_AutoEntryFSParts":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // アクティブ行選択タイマー起動
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //--------------------------------------------
                // 終了
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // 全選択
                //--------------------------------------------
                case "ButtonTool_AllSelect":
                    {
                        this.SetRowSelectedAll(true);
                        this.ChangedSelectColorAll(true);
                        break;
                    }
                //--------------------------------------------
                // 全解除
                //--------------------------------------------
                case "ButtonTool_AllCancel":
                    {
                        this.SetRowSelectedAll(false);
                        this.ChangedSelectColorAll(false);
                        break;
                    }
                //--------------------------------------------
                // 戻る
                //--------------------------------------------
                case "ButtonTool_Prev":
                    {
                        this.CarModelSelectPrev();
                        break;
                    }
                //--------------------------------------------
                // 進む
                //--------------------------------------------
                case "ButtonTool_Next":
                    {
                        this.CarModelSelectNext();
                        break;
                    }
                //--------------------------------------------
                // 確定
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        private void CarModelSelectPrev()
        {
            if ( _carSelectNo > 0 )
            {
                _carSelectNo--;
                this.DisplayCarModel( _carSelectNo );
            }
        }
        /// <summary>
        /// 進むボタン押下
        /// </summary>
        private void CarModelSelectNext()
        {
            if ( _carSelectNo < _carModelDataTable.Rows.Count )
            {
                _carSelectNo++;
                this.DisplayCarModel( _carSelectNo );
            }
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMJKN01000UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            this.uGrid_AutoEntryFSParts.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_AutoEntryFSParts.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // №
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryFSPartsDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 選択フラグ
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // 固定項目
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ＢＬコード
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Width = 40;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 品名
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Width = 150;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 品番
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Width = 120;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // メーカー
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Width = 50;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryFSPartsDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 固定列区切り線設定
            this.uGrid_AutoEntryFSParts.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_AutoEntryFSParts.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

           
            // 選択チェック
            if ( objCell == objRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName] )
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// グリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // チェック反転
            this.ChangedSelect(objRow);
        }

        /// <summary>
        /// 選択行情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_AutoEntryFSParts.ActiveRow != null)
            {
                // 選択 or 解除
                this.ChangedSelect(this.uGrid_AutoEntryFSParts.ActiveRow);
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryFSParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    // アクティブ行選択タイマー起動
                    this.timer_SelectRow.Enabled = true;
                    break;
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._prevButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            // ＵＩ操作でのDataTable変更を適用する(Check状態の反映)
            this._autoEntryFSPartsDataTable.AcceptChanges();

            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        #region 選択・非選択変更処理
        /// <summary>
        /// 選択・日選択変更処理（反転）
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Value;

            // テーブル更新
            gridRow.Cells[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

            // 背景色を変更
            ChangedSelectColor(newSelectedValue, gridRow);
        }
        /// <summary>
        /// 選択・非選択変更処理（背景色のみ）
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // 対象行の選択色を設定する
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            }
        }
        /// <summary>
        /// 全ての行の背景色変更
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll(bool isSelected)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_AutoEntryFSParts.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        /// <summary>
        /// 全ての行の選択チェックをセット
        /// </summary>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // 全ての行の選択チェックを設定
            foreach ( DataRow row in this._autoEntryFSPartsDataTable.Rows )
            {
                row[this._autoEntryFSPartsDataTable.CheckedColumn.ColumnName] = rowSelected;
            }
        }
        # endregion

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 自動登録チェック（※呼出元でShowDialogを呼び出す前にデータ有無をチェックする）
        /// </summary>
        public bool AutoEntryCheck()
        {
            // 自動登録データテーブルの生成
            CreateAutoEntryFSPartsDataTable( this._salesSlipInputAcs );

            // 自動登録選択可能データ件数チェック
            return (_autoEntryFSPartsDataTable != null && _autoEntryFSPartsDataTable.Rows.Count > 0);
        }
        # endregion
    }
}
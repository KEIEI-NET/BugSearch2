using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫出荷確定処理フォーム
    /// </summary>
    public partial class MAZAI04128UA : Form
    {
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        // イメージオブジェクト
        private ImageList _imageList16 = null;
        // 在庫移動初期値取得アクセスクラス
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs = null;
        // 在庫移動検索条件情報
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;
        // 在庫移動ヘッダ情報クラス
        private StockMoveHeader _stockMoveHeader;
        // 在庫移動データテーブル
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        // 在庫移動データテーブルバックアップ
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableBackUp;
        // 従業員マスタ
        private EmployeeAcs employeeAcs;
        // 拠点マスタ
        SecInfoSetAcs secInfoSetAcs;
        // 倉庫マスタ
        WarehouseAcs warehouseAcs;

        // 在庫確定グリッド画面
        private MAZAI04128UB _stockMoveFixInput;
        // 在庫移動関連アクセスクラス
        private StockMoveInputAcs _stockMoveInputAcs;

        // ガイド後次フォーカス制御
        private GuideNextFocusControl _guideNextFocusControl;

        // 所属拠点コード
        private string _belongSectionCode;
        // 所属拠点名称
        private string _belongSectionName;

        // 前回ヘッダ情報
        private HeaderInfo _prevHeaderInfo;

        /// <summary>拠点変更イベント</summary>
        public event EventHandler SectionChange;

        # region デフォルトコンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04128UA()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            this.TopLevel = false;

            // ボタンイメージの取得
            this._imageList16 = IconResourceManagement.ImageList16;

            // 初期値データ
            _stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();

            // 在庫移動検索条件情報
            this._stockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;

            // 在庫移動確定画面
            _stockMoveFixInput = new MAZAI04128UB();

            // 在庫移動アクセスクラス
            _stockMoveInputAcs = StockMoveInputAcs.GetInstance();

            // 在庫移動データテーブル
            _stockMoveDataTable = _stockMoveInputAcs.StockMoveDataTable;

            // 在庫移動データテーブルバックアップ
            _stockMoveDataTableBackUp = _stockMoveInputAcs.StockMoveDataTableBackup;

            // 在庫移動ヘッダ情報格納データ
            this._stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;

            // 従業員マスタ
            this.employeeAcs = new EmployeeAcs();
            // 拠点マスタ
            this.secInfoSetAcs = new SecInfoSetAcs();
            // 倉庫マスタ
            this.warehouseAcs = new WarehouseAcs();

            // ガイド後次フォーカス制御
            SettingGuideNextFocusControl();

            _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
        }
        /// <summary>
        /// ガイド後次フォーカス制御
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            _guideNextFocusControl.Add( ShipAgentCd_tEdit );
            _guideNextFocusControl.Add( BfSectionCode_tEdit );
            _guideNextFocusControl.Add( BfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( AfSectionCode_tEdit );
            _guideNextFocusControl.Add( AfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( StockMvEmpCode_tEdit );
            _guideNextFocusControl.Add( tNedit_SupplierSlipNo );

            // 以降はガイドに関係ないので省略
        }
        # endregion

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04128UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // データグリッドを追加
            this.Detail_panel.Controls.Add(this._stockMoveFixInput);
            this._stockMoveFixInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面初期化処理
            this.Clear();

            // 出荷予定日
            this.ShipmentScdlDaySt_tDateEdit.SetDateTime(DateTime.Now);
            this.ShipmentScdlDayEd_tDateEdit.SetDateTime(DateTime.Now);

            // 状態初期値
            this.DisplayCondition_tComboEditor.Value = 1;

            // 初期フォーカス
            ShipAgentCd_tEdit.Focus();
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04128UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ヘッダ情報を初期化
            _stockMoveInputInitAcs.StockMoveHeaderClear();
            // 検索条件の初期化
            _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        private void SetControlSize()
        {
            this.ShipAgentCd_tEdit.Size = new Size(52, 24);
            this.ShipAgentName_tEdit.Size = new Size(147, 24);
            this.BfSectionCode_tEdit.Size = new Size(52, 24);
            this.BfSectionName_tEdit.Size = new Size(147, 24);
            this.AfSectionCode_tEdit.Size = new Size(52, 24);
            this.AfSectionName_tEdit.Size = new Size(147, 24);
            this.StockMvEmpCode_tEdit.Size = new Size(52, 24);
            this.StockMvEmpName_tEdit.Size = new Size(147, 24);
            this.BfEnterWarehCode_tEdit.Size = new Size(52, 24);
            this.BfEnterWarehName_tEdit.Size = new Size(179, 24);
            this.AfEnterWarehCode_tEdit.Size = new Size(52, 24);
            this.AfEnterWarehName_tEdit.Size = new Size(179, 24);
            this.tNedit_SupplierSlipNo.Size = new Size(84, 24);
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.MoveEmployeeGuide_uButton.ImageList = this._imageList16;
            this.BfSectionGuide_ultraButton.ImageList = this._imageList16;
            this.BfEnterWarehGuide_uButton.ImageList = this._imageList16;
            this.AfEnterpriseGuide_uButton.ImageList = this._imageList16;
            this.AfEnterWarehGuide_uButton.ImageList = this._imageList16;
            this.StockMvEmpGuide_ultraButton.ImageList = this._imageList16;
            this.Search_ultraButton.ImageList = this._imageList16;

            this.MoveEmployeeGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfSectionGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfEnterWarehGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfEnterpriseGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfEnterWarehGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.StockMvEmpGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.Search_ultraButton.Appearance.Image = (int)Size16_Index.SEARCH;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        public void Clear()
        {
            // 出荷確定担当者コード
            this.ShipAgentCd_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 出荷担当者名称
            this.ShipAgentName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            
            // 本社機能なら変更可能とする。
            if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            {
                // 移動元拠点コード
                this.BfSectionCode_tEdit.Enabled = true;
                this.BfSectionCode_tEdit.Clear();
                // 移動元拠点名称
                this.BfSectionName_tEdit.ReadOnly = true;
                this.BfSectionName_tEdit.Clear();
                this.BfSectionGuide_ultraButton.Enabled = true;
            }
            else
            {
                // 移動元拠点コード
                this.BfSectionCode_tEdit.ReadOnly = true;
                this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                // 移動元拠点名称
                this.BfSectionName_tEdit.ReadOnly = true;
                this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();
                this.BfSectionGuide_ultraButton.Enabled = false;
            }
            
            // 移動元倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 移動元倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 移動先拠点コード
            this.AfSectionCode_tEdit.Clear();
            // 移動先拠点名称
            this.AfSectionName_tEdit.Clear();
            // 移動先倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 移動先倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 移動指示担当者コード
            this.StockMvEmpCode_tEdit.Clear();
            // 移動指示担当者名称
            this.StockMvEmpName_tEdit.Clear();
            // 伝票番号
            this.tNedit_SupplierSlipNo.Clear();
            // 出荷予定日(開始)
            this.ShipmentScdlDaySt_tDateEdit.SetDateTime(DateTime.Now);
            // 出荷予定日(終了)
            this.ShipmentScdlDayEd_tDateEdit.SetDateTime(DateTime.Now);
            // 表示条件
            this.DisplayCondition_tComboEditor.Value = 1;

            this.ShipAgentCd_tEdit.Focus();

            // グリッド側クリア処理
            _stockMoveFixInput.Clear();

            //// 拠点変更イベント
            //GetSectionName();
            //if ( SectionChange != null )
            //{
            //    SectionChange( this, new EventArgs() );
            //}
        }

        /// <summary>
        /// ヘッダ情報クリア処理
        /// </summary>
        public void HeaderClear()
        {
            // 出荷確定担当者コード
            this.ShipAgentCd_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 出荷担当者名称
            this.ShipAgentName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();

            // 本社機能なら
            if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            {
                // 移動元拠点コード
                this.BfSectionCode_tEdit.Clear();
                // 移動元拠点名称
                this.BfSectionName_tEdit.Clear();
            }
            else
            {
                // 移動元拠点コード
                this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                // 移動元拠点名称
                this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();
            }

            // 移動元倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 移動元倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 移動先拠点コード
            this.AfSectionCode_tEdit.Clear();
            // 移動先拠点名称
            this.AfSectionName_tEdit.Clear();
            // 移動先倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 移動先倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 移動指示担当者コード
            this.StockMvEmpCode_tEdit.Clear();
            // 移動指示担当者名称
            this.StockMvEmpName_tEdit.Clear();
            // 伝票番号
            this.tNedit_SupplierSlipNo.Clear();
            // 出荷予定日(開始)
            this.ShipmentScdlDaySt_tDateEdit.SetDateTime(DateTime.Now);
            // 出荷予定日(終了)
            this.ShipmentScdlDayEd_tDateEdit.SetDateTime(DateTime.Now);
            // 表示条件
            this.DisplayCondition_tComboEditor.Value = 1;

            this.ShipAgentCd_tEdit.Focus();
        }

        /// <summary>
        /// データテーブルビュー設定処理
        /// </summary>
        public void DataTableSettings()
        {
            //_stockMoveDataTable.DefaultView.RowFilter = "";
            //_stockMoveDataTableBackUp.DefaultView.RowFilter = "";
            _stockMoveFixInput.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;
            _stockMoveFixInput.Clear();
        }

        /// <summary>
        /// フォーカスコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            switch (e.PrevCtrl.Name)
            {
                // 出荷確定担当者コード
                case "ShipAgentCd_tEdit":
                    {
                        // 出荷確定担当者読み込み処理
                        int status = ReadShipAgent();
                        if ( status == 0 )
                        {
                            if ( e.ShiftKey == false )
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (ShipAgentName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.BfSectionCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 移動元拠点
                case "BfSectionCode_tEdit":
                    {
                        // 移動元拠点読み込み処理
                        int status = ReadBfSection();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (BfSectionName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.ShipAgentName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.ShipAgentCd_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    } 
                // 移動元倉庫
                case "BfEnterWarehCode_tEdit":
                    {
                        // 移動元倉庫読み込み処理
                        int status = ReadBfWarehouse();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (BfEnterWarehName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.AfSectionCode_tEdit;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.BfSectionName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.BfSectionCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 移動先拠点
                case "AfSectionCode_tEdit":
                    {
                        // 移動元倉庫読み込み処理
                        int status = ReadAfSection();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (AfSectionName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.AfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.BfEnterWarehName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 移動先倉庫
                case "AfEnterWarehCode_tEdit":
                    {
                        // 移動元倉庫読み込み処理
                        int status = ReadAfWarehouse();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (AfEnterWarehName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.StockMvEmpCode_tEdit;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.AfSectionName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.AfSectionCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 移動指示担当者
                case "StockMvEmpCode_tEdit":
                    {
                        // 移動指示担当者読み込み処理
                        int status = ReadStockMvEmp();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (StockMvEmpName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = this.tNedit_SupplierSlipNo;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.AfEnterWarehName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.AfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時は移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 伝票番号
                case "tNedit_SupplierSlipNo":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.StockMvEmpName_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.StockMvEmpCode_tEdit;
                                }
                            }
                        }
                        break;
                    }
                // 出荷予定日(開始)
                case "ShipmentScdlDaySt_tDateEdit":
                    {
                        // 日付チェック
                        DateTime retDateTime;
                        if (ShipmentScdlDaySt_tDateEdit.LongDate != 0 && DateTime.TryParse(this.ShipmentScdlDaySt_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "有効な日付ではありません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                            break;
                        }

                        // 終了日とのチェック
                        if (ShipmentScdlDayEd_tDateEdit.LongDate != 0 && ShipmentScdlDaySt_tDateEdit.LongDate > ShipmentScdlDayEd_tDateEdit.LongDate)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "終了日より後の日付は入力できません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出荷確定日(終了)
                case "ShipmentScdlDayEd_tDateEdit":
                    {
                        // 日付チェック
                        DateTime retDateTime;
                        if (ShipmentScdlDayEd_tDateEdit.LongDate != 0 && DateTime.TryParse(this.ShipmentScdlDayEd_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "有効な日付ではありません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                            break;
                        }

                        // 開始日とのチェック
                        if (ShipmentScdlDaySt_tDateEdit.LongDate != 0 && ShipmentScdlDayEd_tDateEdit.LongDate < ShipmentScdlDaySt_tDateEdit.LongDate)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始日より前の日付は入力できません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "ultraGrid1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.ShipAgentCd_tEdit;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.Search_ultraButton;
                            }
                        }
                        break;
                    }
            }
        }

        # region ■ 読み込み処理 ■
        /// <summary>
        /// 移動指示担当者読み込み
        /// </summary>
        /// <returns></returns>
        private int ReadStockMvEmp()
        {
            int status = 0;

            string employeeCode = StockMvEmpCode_tEdit.Text.Trim();

            if ( employeeCode == _prevHeaderInfo.StockMvEmpCd )
            {
                // 前回入力コードと同じ→なにもしない
            }
            else
            {
                if ( employeeCode != string.Empty )
                {
                    // 名称取得
                    string employeeName = _stockMoveInputInitAcs.GetEmployeeName( employeeCode );

                    if ( employeeName != string.Empty )
                    {
                        // 入力ＯＫ→内容更新
                        status = 0;

                        // 内容セット
                        SetStockMvEmp( employeeCode, employeeName );
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動指示担当者が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力に戻す
                        SetStockMvEmp( _prevHeaderInfo.StockMvEmpCd, _prevHeaderInfo.StockMvEmpNm );
                    }
                }
                else
                {
                    // 未入力→クリア
                    SetStockMvEmp( string.Empty, string.Empty );
                }
            }

            // ステータスを返す
            return status;
        }

        /// <summary>
        /// 出荷確定担当者読み込み
        /// </summary>
        /// <returns></returns>
        private int ReadShipAgent()
        {
            int status = 0;

            string employeeCode = ShipAgentCd_tEdit.Text.TrimEnd();

            if ( employeeCode == _prevHeaderInfo.ShipAgentCode )
            {
                // 前回入力コードと同じ→なにもしない
            }
            else
            {
                if ( employeeCode != string.Empty )
                {
                    // 名称取得
                    string employeeName = _stockMoveInputInitAcs.GetEmployeeName( employeeCode );

                    if ( employeeName != string.Empty )
                    {
                        // 入力ＯＫ→内容更新
                        status = 0;

                        // 内容セット
                        SetShipAgent( employeeCode, employeeName );

                        // 拠点変更イベント処理
                        GetBelongSection();
                        if ( this.SectionChange != null )
                        {
                            SectionChange( this, new EventArgs() );
                        }
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "出荷確定担当者が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力に戻す
                        SetShipAgent( _prevHeaderInfo.ShipAgentCode, _prevHeaderInfo.ShipAgentName );
                    }
                }
                else
                {
                    // 未入力→クリア
                    SetShipAgent( string.Empty, string.Empty );

                    // 拠点変更イベント処理
                    GetBelongSection();
                    if ( this.SectionChange != null )
                    {
                        SectionChange( this, new EventArgs() );
                    }
                }
            }

            // ステータスを返す
            return status;
        }


        /// <summary>
        /// 移動先拠点読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadAfSection()
        {
            int status = 0;
            string afSectionCode = AfSectionCode_tEdit.Text.TrimEnd();

            if ( afSectionCode == _prevHeaderInfo.AfSectionCode )
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if ( afSectionCode != string.Empty )
                {
                    // 名称取得
                    string afSectionName = _stockMoveInputInitAcs.GetSectionName( afSectionCode );

                    if ( afSectionName != string.Empty )
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetAfSection( afSectionCode, afSectionName );

                        // 拠点が変わったら倉庫をクリア
                        SetAfWarehouse( string.Empty, string.Empty );
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;

                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動先拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力値に戻す
                        SetAfSection( _prevHeaderInfo.AfSectionCode, _prevHeaderInfo.AfSectionName );
                    }
                }
                else
                {
                    // 入力クリア

                    // 内容を格納
                    SetAfSection( string.Empty, string.Empty );

                    // 拠点が変わったら倉庫をクリア
                    SetAfWarehouse( string.Empty, string.Empty );
                }
            }

            // ステータスを返す
            return status;
        }

        /// <summary>
        /// 移動先倉庫読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadAfWarehouse()
        {
            int status = 0;

            // 拠点コード取得
            string afSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            if ( afSectionCode == string.Empty )
            {
                // 移動先拠点コード未入力なら移動元拠点コード使用
                afSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            }
            if ( afSectionCode == string.Empty )
            {
                // 移動元も未入力なら担当者の所属拠点を使用
                afSectionCode = _belongSectionCode;
            }

            // 倉庫コード取得
            string afWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();

            if ( afWarehouseCode == _prevHeaderInfo.AfWarehouseCode )
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if ( afWarehouseCode != string.Empty )
                {
                    // 名称取得
                    string afWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(afWarehouseCode );

                    if ( afWarehouseName != string.Empty )
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetAfWarehouse( afWarehouseCode, afWarehouseName );
                        // 拠点も反映
                        SetAfSection( afSectionCode, _stockMoveInputInitAcs.GetSectionName( afSectionCode ) );
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;

                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動先倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力値に戻す
                        SetAfWarehouse( _prevHeaderInfo.AfWarehouseCode, _prevHeaderInfo.AfWarehouseName );
                    }
                }
                else
                {
                    // 入力クリア
                    SetAfWarehouse( string.Empty, string.Empty );
                }
            }

            // ステータスを返す
            return status;
        }

        /// <summary>
        /// 移動元拠点読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadBfSection()
        {
            int status = 0;
            string bfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();

            if ( bfSectionCode == _prevHeaderInfo.BfSectionCode )
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if ( bfSectionCode != string.Empty )
                {
                    // 名称取得
                    string bfSectionName = _stockMoveInputInitAcs.GetSectionName( bfSectionCode );

                    if ( bfSectionName != string.Empty )
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetBfSection( bfSectionCode, bfSectionName );

                        // 拠点が変わったら倉庫をクリア
                        SetBfWarehouse( string.Empty, string.Empty );
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;

                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動元拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力値に戻す
                        SetBfSection( _prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName );
                    }
                }
                else
                {
                    // 入力クリア

                    // 内容を格納
                    SetBfSection( string.Empty, string.Empty );

                    // 拠点が変わったら倉庫をクリア
                    SetBfWarehouse( string.Empty, string.Empty );
                }
            }
            // ステータスを返す
            return status;
        }

        /// <summary>
        /// 移動元倉庫読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadBfWarehouse()
        {
            int status = 0;

            // 拠点コード取得
            string bfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            if ( bfSectionCode == string.Empty )
            {
                // 移動元拠点コード未入力なら移動先拠点コード使用
                bfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            }
            if ( bfSectionCode == string.Empty )
            {
                // 移動先も未入力なら担当者の所属拠点を使用
                bfSectionCode = _belongSectionCode;
            }

            // 倉庫コード取得
            string bfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();

            if ( bfWarehouseCode == _prevHeaderInfo.BfWarehouseCode )
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if ( bfWarehouseCode != string.Empty )
                {
                    // 名称取得
                    string bfWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(bfWarehouseCode );

                    if ( bfWarehouseName != string.Empty )
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetBfWarehouse( bfWarehouseCode, bfWarehouseName );
                        // 拠点も反映
                        SetBfSection( bfSectionCode, _stockMoveInputInitAcs.GetSectionName( bfSectionCode ) );
                    }
                    else
                    {
                        // 入力エラー
                        status = -1;

                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動元倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力値に戻す
                        SetBfWarehouse( _prevHeaderInfo.BfWarehouseCode, _prevHeaderInfo.BfWarehouseName );
                    }
                }
                else
                {
                    // 入力クリア
                    SetBfWarehouse( string.Empty, string.Empty );
                }
            }

            // ステータスを返す
            return status;
        }

        # region [画面セット処理]
        /// <summary>
        /// 出荷確定担当者セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetShipAgent( string code, string name )
        {
            // 内容を格納
            ShipAgentCd_tEdit.Text = code;
            ShipAgentName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.ShipAgentCode = code;
            _prevHeaderInfo.ShipAgentName = name;
        }
        /// <summary>
        /// 移動先倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetStockMvEmp( string code, string name )
        {
            // 内容を格納
            StockMvEmpCode_tEdit.Text = code;
            StockMvEmpName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.StockMvEmpCd = code;
            _prevHeaderInfo.StockMvEmpNm = name;
        }
        /// <summary>
        /// 移動元拠点セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetBfSection( string code, string name )
        {
            // 内容を格納
            BfSectionCode_tEdit.Text = code;
            BfSectionName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.BfSectionCode = code;
            _prevHeaderInfo.BfSectionName = name;
        }
        /// <summary>
        /// 移動元倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetBfWarehouse( string code, string name )
        {
            // 内容を格納
            BfEnterWarehCode_tEdit.Text = code;
            BfEnterWarehName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.BfWarehouseCode = code;
            _prevHeaderInfo.BfWarehouseName = name;
        }
        /// <summary>
        /// 移動先拠点セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetAfSection( string code, string name )
        {
            // 内容を格納
            AfSectionCode_tEdit.Text = code;
            AfSectionName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.AfSectionCode = code;
            _prevHeaderInfo.AfSectionName = name;
        }
        /// <summary>
        /// 移動先倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetAfWarehouse( string code, string name )
        {
            // 内容を格納
            AfEnterWarehCode_tEdit.Text = code;
            AfEnterWarehName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.AfWarehouseCode = code;
            _prevHeaderInfo.AfWarehouseName = name;
        }
        # endregion
        # endregion ■ 読み込み処理 ■


        /// <summary>
        ///  検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // データテーブルをリセット
                _stockMoveDataTable.Clear();

                // 条件を格納

                // 移動元拠点コード
                _stockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.Text.Trim();
                // 移動元倉庫コード
                _stockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text.Trim();
                // 移動先拠点
                _stockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.Text.Trim();
                // 移動先倉庫
                _stockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text.Trim();
                // 移動指示担当者
                _stockMoveSlipSearchCond.StockMvEmpCode = this.StockMvEmpCode_tEdit.Text.Trim();
                // 伝票番号
                _stockMoveSlipSearchCond.StockMoveSlipNo = this.tNedit_SupplierSlipNo.GetInt();
                // 出荷予定日(開始)
                _stockMoveSlipSearchCond.ShipmentScdlStDay = this.ShipmentScdlDaySt_tDateEdit.GetDateTime();
                // 出荷予定日(終了)
                _stockMoveSlipSearchCond.ShipmentScdlEdDay = this.ShipmentScdlDayEd_tDateEdit.GetDateTime();
                // 表示条件
                if (this.DisplayCondition_tComboEditor.Value == null)
                {
                    _stockMoveSlipSearchCond.MoveStatus = 0;
                }
                else
                {
                    _stockMoveSlipSearchCond.MoveStatus = Int32.Parse(this.DisplayCondition_tComboEditor.Value.ToString());
                }

                // 在庫確定画面時在庫移動データ検索処理
                int status = _stockMoveInputAcs.SearchStockMoveFix();

                // 検索条件の移動状態によってデフォルトビューを設定
                int moveStatus = _stockMoveInputInitAcs.StockMoveSlipSearchCond.MoveStatus;

                // デフォルトビューを設定
                //if (moveStatus == -1)
                //{
                //    _stockMoveDataTable.DefaultView.RowFilter = "MoveStatusView in (1,2,9)";
                //    _stockMoveDataTableBackUp.DefaultView.RowFilter = "MoveStatusView in (1,2,9)";
                //}
                //else
                //{
                //    _stockMoveDataTable.DefaultView.RowFilter = "MoveStatusView = " + moveStatus;
                //    _stockMoveDataTableBackUp.DefaultView.RowFilter = "MoveStatusView = " + moveStatus;
                //}

                //// ビューを表示
                //_stockMoveFixInput.ultraGrid1.DataSource = _stockMoveDataTable.DefaultView;
                _stockMoveFixInput.SettingGridDraw();

                // 正常終了
                if (status == 0)
                {
                }
                // 該当データ無し
                else if (status == 9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データがありません。",
                        status,
                        MessageBoxButtons.OK);
                }
                // 検索失敗
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "検索に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// クローズ可能不可能判別処理
        /// </summary>
        /// <returns>true:入力内容有 false:入力内容無</returns>
        public bool CloseDataCheck()
        {
            // ヘッダ情報を確認

            // 出荷確定担当者
            if (this.ShipAgentCd_tEdit.Text.Trim() != LoginInfoAcquisition.Employee.EmployeeCode.Trim())
            {
                return true;
            }

            // 以下検索条件のためいらない

            // 移動元拠点(本社機能時に必要)
            if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            {
                if (this.BfSectionCode_tEdit.Text.Trim() != "")
                {
                    return true;
                }
            }

            // 移動元倉庫
            if (this.BfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 移動先拠点
            if (this.AfSectionCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 移動先倉庫
            if (this.AfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 移動指示担当者
            if (this.StockMvEmpCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 伝票番号
            if (this.tNedit_SupplierSlipNo.Text.Trim() != "")
            {
                return true;
            }

            // 出荷予定日(開始)
            if (this.ShipmentScdlDaySt_tDateEdit.GetDateTime() != DateTime.Now)
            {
                return true;
            }

            // 出荷予定日(終了)
            if (this.ShipmentScdlDayEd_tDateEdit.GetDateTime() != DateTime.Now)
            {
                return true;
            }

            // 表示条件
            if (this.DisplayCondition_tComboEditor.Value.ToString() != "1")
            {
                return true;
            }

            // グリッド情報の変更確認(確定フラグのみ)
            for (int i = 0; i < _stockMoveDataTable.Count; i++)
            {
                bool stockMoveFixFlag    = (bool)_stockMoveDataTable[i]["FixFlag"];
                bool stockMoveFixFlagBak = (bool)_stockMoveDataTableBackUp[i]["FixFlag"];

                if (stockMoveFixFlag != stockMoveFixFlagBak)
                {
                    return true;
                }
            }

            return false;

            // グリッド情報を確認
            //foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            //{
            //    if (row.FixFlag == true)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        /// <summary>
        /// 移動データ確定処理前ヘッダ、フッタ入力情報チェック処理
        /// </summary>
        /// <returns>true:入力項目に問題なし false:入力項目に問題あり</returns>
        public Boolean HeaderFooterCheck()
        {
            // 出荷確定担当者
            if (this.ShipAgentCd_tEdit.Text.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出荷確定担当者が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 入力に問題が無ければチェック通過
            return true;
        }

        /// <summary>
        /// ヘッダ、フッタ情報格納処理(画面より)
        /// </summary>
        public void SetHeaderFooterInfoFromDisplay()
        {
            // 出荷確定担当者コード
            _stockMoveHeader.ShipAgentCd = this.ShipAgentCd_tEdit.Text.Trim();
            // 出荷確定担当者名
            _stockMoveHeader.ShipAgentNm = this.ShipAgentName_tEdit.Text.Trim();
        }

        # region ガイド系イベント

        /// <summary>
        /// 出荷確定担当者ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MoveEmployeeGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, LoginInfoAcquisition.Employee.BelongSectionCode, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    SetShipAgent(employee.EmployeeCode.TrimEnd(), employee.Name.TrimEnd());

                    _stockMoveHeader.ShipAgentCd = employee.EmployeeCode.Trim();
                    _stockMoveHeader.ShipAgentNm = employee.Name;

                    // 拠点変更イベント
                    GetBelongSection();
                    if (SectionChange != null)
                    {
                        SectionChange(this, new EventArgs());
                    }

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(ShipAgentCd_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 移動指示担当者ガイドボタン(検索条件)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void StockMvEmpGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, LoginInfoAcquisition.Employee.BelongSectionCode, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.StockMvEmpCode = employee.EmployeeCode.Trim();

                    // 結果セット
                    SetStockMvEmp(employee.EmployeeCode.TrimEnd(), employee.Name.TrimEnd());

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(StockMvEmpCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 移動先拠点ガイドボタン(検索条件)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void AfEnterpriseGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.AfSectionCode = secInfoSet.SectionCode;

                    // 結果セット
                    SetAfSection(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm.Trim());

                    // 移動先倉庫を削除
                    SetAfWarehouse(string.Empty, string.Empty);

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(AfSectionCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 移動先倉庫ガイドボタン(検索条件)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void AfEnterWarehGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode = this.AfSectionCode_tEdit.Text;

                //if (this.AfSectionCode_tEdit.Text.Trim() == "")
                //{
                //    SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //}
                //else
                //{
                //    SectionCode = this.AfSectionCode_tEdit.Text;
                //}

                Warehouse warehouse;

                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.AfEnterWarehCode = warehouse.WarehouseCode;

                    // 結果セット
                    SetAfWarehouse(warehouse.WarehouseCode.TrimEnd(), warehouse.WarehouseName.TrimEnd());
                    // 拠点に反映
                    SetAfSection(warehouse.SectionCode, _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode));

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(AfEnterWarehCode_tEdit).Focus();

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 移動元拠点ガイドボタン(検索条件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.BfSectionCode = secInfoSet.SectionCode;

                    // 結果セット
                    SetBfSection(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm.TrimEnd());

                    // 移動元倉庫を削除
                    SetBfWarehouse(string.Empty, string.Empty);

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(BfSectionCode_tEdit).Focus();

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 移動元倉庫ガイドボタン(検索条件)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BfEnterWarehGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode = BfSectionCode_tEdit.Text;
                Warehouse warehouse;

                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.BfEnterWarehCode = warehouse.WarehouseCode;

                    // 結果セット
                    SetBfWarehouse(warehouse.WarehouseCode.TrimEnd(), warehouse.WarehouseName.TrimEnd());
                    // 拠点に反映
                    SetBfSection(warehouse.SectionCode, _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode));

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(BfEnterWarehCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        # endregion

        # region ■ 所属拠点取得処理 ■
        /// <summary>
        /// 所属拠点名称取得処理
        /// </summary>
        /// <returns></returns>
        public string GetSectionName()
        {
            return _belongSectionName;
        }
        /// <summary>
        /// 所属拠点取得処理
        /// </summary>
        /// <returns></returns>
        private void GetBelongSection()
        {
            Employee employee;
            int status = employeeAcs.Read( out employee, LoginInfoAcquisition.EnterpriseCode, ShipAgentCd_tEdit.Text.Trim() );
            if ( status == 0 )
            {
                _belongSectionCode = employee.BelongSectionCode;
                _belongSectionName = employee.BelongSectionName;
            }
            else
            {
                // 取得できなかったら更新しない
            }
        }
        # endregion ■ 所属拠点取得処理 ■

        # region ■ ヘッダ情報構造体 ■
        /// <summary>
        /// ヘッダ情報構造体
        /// </summary>
        private struct HeaderInfo
        {
            /// <summary>出荷担当者コード</summary>
            private string _shipAgentCode;
            /// <summary>出荷担当者名称</summary>
            private string _shipAgentName;
            /// <summary>指示担当者コード</summary>
            private string _stockMvEmpCd;
            /// <summary>指示担当者名称</summary>
            private string _stockMvEmpNm;
            /// <summary>移動元拠点コード</summary>
            private string _bfSectionCode;
            /// <summary>移動元拠点名称</summary>
            private string _bfSectionName;
            /// <summary>移動元倉庫コード</summary>
            private string _bfWarehouseCode;
            /// <summary>移動元倉庫名称</summary>
            private string _bfWarehouseName;
            /// <summary>移動先拠点コード</summary>
            private string _afSectionCode;
            /// <summary>移動先拠点名称</summary>
            private string _afSectionName;
            /// <summary>移動先倉庫コード</summary>
            private string _afWarehouseCode;
            /// <summary>移動先倉庫名称</summary>
            private string _afWarehouseName;

            /// <summary>
            /// 出荷担当者コード
            /// </summary>
            public string ShipAgentCode
            {
                get { return _shipAgentCode; }
                set { _shipAgentCode = value; }
            }
            /// <summary>
            /// 出荷担当者名称
            /// </summary>
            public string ShipAgentName
            {
                get { return _shipAgentName; }
                set { _shipAgentName = value; }
            }
            /// <summary>
            /// 指示担当者コード
            /// </summary>
            public string StockMvEmpCd
            {
                get { return _stockMvEmpCd; }
                set { _stockMvEmpCd = value; }
            }
            /// <summary>
            /// 指示担当者名称
            /// </summary>
            public string StockMvEmpNm
            {
                get { return _stockMvEmpNm; }
                set { _stockMvEmpNm = value; }
            }
            /// <summary>
            /// 移動元拠点コード
            /// </summary>
            public string BfSectionCode
            {
                get { return _bfSectionCode; }
                set { _bfSectionCode = value; }
            }
            /// <summary>
            /// 移動元拠点名称
            /// </summary>
            public string BfSectionName
            {
                get { return _bfSectionName; }
                set { _bfSectionName = value; }
            }
            /// <summary>
            /// 移動元倉庫コード
            /// </summary>
            public string BfWarehouseCode
            {
                get { return _bfWarehouseCode; }
                set { _bfWarehouseCode = value; }
            }
            /// <summary>
            /// 移動元倉庫名称
            /// </summary>
            public string BfWarehouseName
            {
                get { return _bfWarehouseName; }
                set { _bfWarehouseName = value; }
            }
            /// <summary>
            /// 移動先拠点コード
            /// </summary>
            public string AfSectionCode
            {
                get { return _afSectionCode; }
                set { _afSectionCode = value; }
            }
            /// <summary>
            /// 移動先拠点名称
            /// </summary>
            public string AfSectionName
            {
                get { return _afSectionName; }
                set { _afSectionName = value; }
            }
            /// <summary>
            /// 移動先倉庫コード
            /// </summary>
            public string AfWarehouseCode
            {
                get { return _afWarehouseCode; }
                set { _afWarehouseCode = value; }
            }
            /// <summary>
            /// 移動先倉庫名称
            /// </summary>
            public string AfWarehouseName
            {
                get { return _afWarehouseName; }
                set { _afWarehouseName = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="shipAgentCode">出荷担当者コード</param>
            /// <param name="shipAgentName">出荷担当者名称</param>
            /// <param name="stockMvEmpCd">指示担当者コード</param>
            /// <param name="stockMvEmpNm">指示担当者名称</param>
            /// <param name="bfSectionCode">移動元拠点コード</param>
            /// <param name="bfSectionName">移動元拠点名称</param>
            /// <param name="bfWarehouseCode">移動元倉庫コード</param>
            /// <param name="bfWarehouseName">移動元倉庫名称</param>
            /// <param name="afSectionCode">移動先拠点コード</param>
            /// <param name="afSectionName">移動先拠点名称</param>
            /// <param name="afWarehouseCode">移動先倉庫コード</param>
            /// <param name="afWarehouseName">移動先倉庫名称</param>
            public HeaderInfo( string shipAgentCode, string shipAgentName, string stockMvEmpCd, string stockMvEmpNm, string bfSectionCode, string bfSectionName, string bfWarehouseCode, string bfWarehouseName, string afSectionCode, string afSectionName, string afWarehouseCode, string afWarehouseName )
            {
                _shipAgentCode = shipAgentCode;
                _shipAgentName = shipAgentName;
                _stockMvEmpCd = stockMvEmpCd;
                _stockMvEmpNm = stockMvEmpNm;
                _bfSectionCode = bfSectionCode;
                _bfSectionName = bfSectionName;
                _bfWarehouseCode = bfWarehouseCode;
                _bfWarehouseName = bfWarehouseName;
                _afSectionCode = afSectionCode;
                _afSectionName = afSectionName;
                _afWarehouseCode = afWarehouseCode;
                _afWarehouseName = afWarehouseName;
            }
        }
        # endregion ■ ヘッダ情報構造体 ■

        # region ■ ガイド後次フォーカス制御クラス ■
        /// <summary>
        /// ガイド後次フォーカス制御クラス
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="control"></param>
            public void Add( Control control )
            {
                _controls.Add( control );
                if ( !_indexDic.ContainsKey( control ) )
                {
                    _indexDic.Add( control, _controls.Count - 1 );
                }
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange( IEnumerable<Control> collection )
            {
                int stIndex = _controls.Count;
                _controls.AddRange( collection );
                int edIndex = _controls.Count - 1;

                for ( int i = stIndex; i <= edIndex; i++ )
                {
                    if ( !_indexDic.ContainsKey( _controls[i] ) )
                    {
                        _indexDic.Add( _controls[i], i );
                    }
                }
            }
            /// <summary>
            /// 対象コントロールクリア
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// 次コントロール取得
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl( Control control )
            {
                int index = _indexDic[control];
                index++;

                for ( int i = index; i < _controls.Count; i++ )
                {
                    if ( !_controls[i].Visible || !_controls[i].Enabled )
                    {
                        continue;
                    }

                    if ( _controls[i] is TEdit )
                    {
                        if ( (_controls[i] as TEdit).ReadOnly == true )
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion ■ ガイド後次フォーカス制御クラス ■
    }
}
//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の出荷処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/08  修正内容 : MANTIS対応[15260]：入荷処理画面で一括入荷押下時に入荷日が正しくセットされない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/15  修正内容 : MANTIS対応[15589]：入荷画面の日付が「出荷日」で分かりずらい
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : redmine #20901
//----------------------------------------------------------------------------//
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
    /// 在庫入荷処理フォーム
    /// </summary>
    public partial class MAZAI04129UA : Form
    {
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        private ImageList _imageList16 = null;
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs = null;
        private StockMoveHeader _stockMoveHeader;
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableBackUp;
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;

        private MAZAI04129UB _stockMoveArrivalInput;
        private StockMoveInputAcs _stockMoveInputAcs;

        // 従業員マスタ
        private EmployeeAcs employeeAcs;
        // 拠点マスタ
        private SecInfoSetAcs secInfoSetAcs;
        // 倉庫マスタ
        private WarehouseAcs warehouseAcs;

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

        public event SearchAfterEventHandler searchAfter;
        public delegate void SearchAfterEventHandler();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04129UA()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            this.TopLevel = false;

            // ボタンイメージの取得
            this._imageList16 = IconResourceManagement.ImageList16;

            // 初期値データ
            _stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();

            // 在庫移動確定画面
            _stockMoveArrivalInput = new MAZAI04129UB();
            _stockMoveArrivalInput.GetHeaderInfo += new EventHandler( _stockMoveArrivalInput_GetHeaderInfo );

            // 在庫移動アクセスクラス
            _stockMoveInputAcs = StockMoveInputAcs.GetInstance();

            // 在庫移動データテーブル
            _stockMoveDataTable = _stockMoveInputAcs.StockMoveDataTable;

            // 在庫移動データテーブルバックアップ
            _stockMoveDataTableBackUp = _stockMoveInputAcs.StockMoveDataTableBackup;

            // 在庫移動ヘッダ情報格納データ
            this._stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;

            // 検索条件格納クラス
            this._stockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;

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

            // 前回ヘッダ情報
            _prevHeaderInfo = new HeaderInfo();
        }

        public void Renewal()
        {
            this._stockMoveInputInitAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode);
            this._stockMoveInputAcs.LoadMakerUMnt();
            this._stockMoveInputAcs.LoadBlGoodsCdUMnt();
            this._stockMoveInputAcs.LoadStockMngTtlSt();
        }

        /// <summary>
        /// 新規処理前チェック
        /// </summary>
        public bool CompareBeforeNewProc()
        {
            // 入荷担当者
            if (this.ReceiveAgentCd_tEdit.DataText.Trim().PadLeft(4, '0') != LoginInfoAcquisition.Employee.EmployeeCode.Trim())
            {
                return (false);
            }

            // 入荷日
            if (this.ArrivalGoodsDay_tDateEdit.GetDateTime() != DateTime.Today)
            {
                return (false);
            }

            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 入庫拠点
            //if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            //{
            //    // 本社機能なら
            //    if (this.AfSectionCode_tEdit.DataText.Trim() != "")
            //    {
            //        return (false);
            //    }
            //}
            //else
            //{
            //    if (this.AfSectionCode_tEdit.DataText.Trim().PadLeft(2, '0') != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
            //    {
            //        return (false);
            //    }
            //}
            // 入庫拠点
            if (this.AfSectionCode_tEdit.DataText.Trim() != "")
            {
                return (false);
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 入庫倉庫
            if (this.AfEnterWarehCode_tEdit.DataText.Trim() != "")
            {
                return (false);
            }

            // 出庫拠点
            if (this.BfSectionCode_tEdit.DataText.Trim() != "")
            {
                return (false);
            }

            // 出庫倉庫
            if (this.BfEnterWarehCode_tEdit.DataText.Trim() != "")
            {
                return (false);
            }

            // 出荷担当者
            if (this.ShipAgentCd_tEdit.DataText.Trim() != "")
            {
                return (false);
            }

            // 伝票番号
            if (this.tNedit_SupplierSlipNo.DataText.Trim() != "")
            {
                return (false);
            }

            // 出荷日(開始)
            if (this.ShipmentFixDaySt_tDateEdit.GetDateTime() != DateTime.Today)
            {
                return (false);
            }

            // 出荷日(終了)
            if (this.ShipmentFixDayEd_tDateEdit.GetDateTime() != DateTime.Today)
            {
                return (false);
            }

            // 表示条件
            if ((int)this.DisplayCondition_tComboEditor.Value != 2)
            {
                return (false);
            }

            // グリッド
            if (this._stockMoveArrivalInput.CheckGridBeforeNewProc() == false)
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// 元に戻す前チェック
        /// </summary>
        /// <returns></returns>
        public bool CompareBeforeRetry()
        {
            // 入庫拠点コード
            if (_stockMoveSlipSearchCond.AfSectionCode != this.AfSectionCode_tEdit.Text.Trim())
            {
                return (false);
            }

            // 入庫倉庫コード
            if (_stockMoveSlipSearchCond.AfEnterWarehCode != this.AfEnterWarehCode_tEdit.Text.Trim())
            {
                return (false);
            }

            // 出庫拠点コード
            if (_stockMoveSlipSearchCond.BfSectionCode != this.BfSectionCode_tEdit.Text.Trim())
            {
                return (false);
            }

            // 出庫倉庫コード
            if (_stockMoveSlipSearchCond.BfEnterWarehCode != this.BfEnterWarehCode_tEdit.Text.Trim())
            {
                return (false);
            }

            // 出荷担当者コード
            if (_stockMoveSlipSearchCond.ShipAgentCd != this.ShipAgentCd_tEdit.Text.Trim())
            {
                return (false);
            }

            // 移動伝票番号
            if (_stockMoveSlipSearchCond.StockMoveSlipNo != this.tNedit_SupplierSlipNo.GetInt())
            {
                return (false);
            }

            // 出荷日(開始)
            if (_stockMoveSlipSearchCond.ShipmentFixStDay != this.ShipmentFixDaySt_tDateEdit.GetDateTime())
            {
                return (false);
            }

            // 出荷日(終了)
            if (_stockMoveSlipSearchCond.ShipmentFixEdDay != this.ShipmentFixDayEd_tDateEdit.GetDateTime())
            {
                return (false);
            }

            // 表示条件
            if (_stockMoveSlipSearchCond.MoveStatus != (int)this.DisplayCondition_tComboEditor.Value)
            {
                return (false);
            }

            // グリッド
            for (int index = 0; index < this._stockMoveDataTable.Rows.Count; index++)
            {
                if (this._stockMoveDataTable[index].ArrivalFlag != this._stockMoveDataTableBackUp[index].ArrivalFlag)
                {
                    return (false);
                }
            }

            return (true);
        }

        public void RetryProc()
        {
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Text = _stockMoveSlipSearchCond.AfSectionCode;
            // 入庫倉庫コードz
            this.AfEnterWarehCode_tEdit.Text = _stockMoveSlipSearchCond.AfEnterWarehCode;
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Text = _stockMoveSlipSearchCond.BfSectionCode;
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Text = _stockMoveSlipSearchCond.BfEnterWarehCode;
            // 出荷担当者コード
            this.ShipAgentCd_tEdit.Text = _stockMoveSlipSearchCond.ShipAgentCd;
            // 移動伝票番号
            this.tNedit_SupplierSlipNo.SetInt(_stockMoveSlipSearchCond.StockMoveSlipNo);
            // 出荷日(開始)
            this.ShipmentFixDaySt_tDateEdit.SetDateTime(_stockMoveSlipSearchCond.ShipmentFixStDay);
            // 出荷日(終了)
            this.ShipmentFixDayEd_tDateEdit.SetDateTime(_stockMoveSlipSearchCond.ShipmentFixEdDay);
            // 表示条件
            this.DisplayCondition_tComboEditor.Value = _stockMoveSlipSearchCond.MoveStatus;

            Search_ultraButton_Click(this.Search_ultraButton, new EventArgs());

            this.ReceiveAgentCd_tEdit.Focus();
        }

        /// <summary>
        /// ガイド後次フォーカス制御
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            _guideNextFocusControl.Add( ReceiveAgentCd_tEdit );
            _guideNextFocusControl.Add( AfSectionCode_tEdit );
            _guideNextFocusControl.Add( AfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( BfSectionCode_tEdit );
            _guideNextFocusControl.Add( BfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( ShipAgentCd_tEdit );
            _guideNextFocusControl.Add( tNedit_SupplierSlipNo );

            // 以降はガイドに関係ないので省略
        }

        /// <summary>
        /// 明細部　ヘッダ情報取得イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _stockMoveArrivalInput_GetHeaderInfo( object sender, EventArgs e )
        {
            SetHeaderFooterInfoFromDisplay();
        }

        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAZAI04129UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // データグリッドを追加0
            this.Detail_panel.Controls.Add(this._stockMoveArrivalInput);
            this._stockMoveArrivalInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面初期化処理
            this.Clear();

            this.TopLevel = false;

            // 初期フォーカス
            this.ReceiveAgentCd_tEdit.Focus();
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04129UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ヘッダ情報を初期化
            _stockMoveInputInitAcs.StockMoveHeaderClear();
            // 検索条件情報を初期化
            _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        private void SetControlSize()
        {
            this.ReceiveAgentCd_tEdit.Size = new Size(52, 24);
            this.ReceiveAgentName_tEdit.Size = new Size(147, 24);
            this.BfSectionCode_tEdit.Size = new Size(52, 24);
            this.BfSectionName_tEdit.Size = new Size(147, 24);
            this.AfSectionCode_tEdit.Size = new Size(52, 24);
            this.AfSectionName_tEdit.Size = new Size(147, 24);
            this.ShipAgentCd_tEdit.Size = new Size(52, 24);
            this.ShipAgentName_tEdit.Size = new Size(147, 24);
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
            this.ReceiveAgentGuide_uButton.ImageList = this._imageList16;
            this.AfSectionGuide_ultraButton.ImageList = this._imageList16;
            this.AfEnterWarehGuide_uButton.ImageList = this._imageList16;
            this.BfSectionGuide_uButton.ImageList = this._imageList16;
            this.BfEnterWarehGuide_uButton.ImageList = this._imageList16;
            this.ShipAgnetGuide_uButton.ImageList = this._imageList16;
            this.Search_ultraButton.ImageList = this._imageList16;
            this.AllArrival_uButton.ImageList = this._imageList16;

            this.ReceiveAgentGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfSectionGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfEnterWarehGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfSectionGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfEnterWarehGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.ShipAgnetGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.Search_ultraButton.Appearance.Image = (int)Size16_Index.SEARCH;
            this.AllArrival_uButton.Appearance.Image = (int)Size16_Index.PACKAGEINPUT;
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        public void Clear()
        {
            // 入荷担当者コード
            this.ReceiveAgentCd_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 入荷担当者名称
            this.ReceiveAgentName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();

            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 本社機能なら
            //if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            //{
            //    // 入庫拠点コード
            //    this.AfSectionCode_tEdit.Clear();
            //    this.AfSectionCode_tEdit.ReadOnly = false;
            //    this.AfSectionGuide_ultraButton.Enabled = true;
            //    // 入庫拠点名称
            //    this.AfSectionName_tEdit.Clear();
            //}
            //else
            //{
            //    // 入庫拠点コード
            //    this.AfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //    this.AfSectionCode_tEdit.ReadOnly = true;
            //    this.AfSectionGuide_ultraButton.Enabled = false;
            //    // 入庫拠点名称
            //    this.AfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();
            //}
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Clear();
            this.AfSectionCode_tEdit.ReadOnly = false;
            this.AfSectionGuide_ultraButton.Enabled = true;
            // 入庫拠点名称
            this.AfSectionName_tEdit.Clear();
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 入庫倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 入庫倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 入荷日
            this.ArrivalGoodsDay_tDateEdit.SetDateTime(DateTime.Now);
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Clear();
            // 出庫拠点名称
            this.BfSectionName_tEdit.Clear();
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 出庫倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 出荷担当者コード
            this.ShipAgentCd_tEdit.Clear();
            // 出荷担当者名称
            this.ShipAgentName_tEdit.Clear();
            // 伝票番号
            this.tNedit_SupplierSlipNo.Clear();
            // 出荷日(開始)
            this.ShipmentFixDaySt_tDateEdit.SetDateTime(DateTime.Now);
            // 出荷日(終了)
            this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Now);
            // 表示条件
            this.DisplayCondition_tComboEditor.Value = 2;

            this.ReceiveAgentCd_tEdit.Focus();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ヘッダ情報初期化
            _prevHeaderInfo.ShipAgentCode = ShipAgentCd_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ShipAgentName = ShipAgentName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ArrivalAgentCode = ReceiveAgentCd_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ArrivalAgentName = ReceiveAgentName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionName = AfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // グリッド側クリア処理
            _stockMoveArrivalInput.Clear();
        }

        /// <summary>
        /// ヘッダ情報クリア処理
        /// </summary>
        public void HeaderClear()
        {
            // 入荷担当者コード
            this.ReceiveAgentCd_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 入荷担当者名称
            this.ReceiveAgentName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            
            // 入庫拠点名称
            this.AfSectionCode_tEdit.Clear();
            
            // 入庫倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 入庫倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 入荷日
            this.ArrivalGoodsDay_tDateEdit.SetDateTime(DateTime.Now);
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Clear();
            // 出庫拠点名称
            this.BfSectionName_tEdit.Clear();
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 出庫倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 出荷担当者コード
            this.ShipAgentCd_tEdit.Clear();
            // 出荷担当者名称
            this.ShipAgentName_tEdit.Clear();
            // 伝票番号
            this.tNedit_SupplierSlipNo.Clear();
            // 出荷日(開始)
            this.ShipmentFixDaySt_tDateEdit.SetDateTime(DateTime.Now);
            // 出荷日(終了)
            this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Now);
            // 表示条件
            this.DisplayCondition_tComboEditor.Value = 2;

            this.ReceiveAgentCd_tEdit.Focus();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ヘッダ情報初期化
            _prevHeaderInfo.ShipAgentCode = ShipAgentCd_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ShipAgentName = ShipAgentName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ArrivalAgentCode = ReceiveAgentCd_tEdit.Text.TrimEnd();
            _prevHeaderInfo.ArrivalAgentName = ReceiveAgentName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionName = AfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
                // 入荷担当者コード
                case "ReceiveAgentCd_tEdit":
                    {    
                        // 入荷担当者読み込み
                        int status = ReadArrivalAgent();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (ReceiveAgentName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力あり→次項目へ
                                        e.NextCtrl = ArrivalGoodsDay_tDateEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 入荷日
                case "ArrivalGoodsDay_tDateEdit":
                    {
                        // 日付チェック
                        DateTime retDateTime;
                        if (ArrivalGoodsDay_tDateEdit.LongDate != 0 && DateTime.TryParse(this.ArrivalGoodsDay_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
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
                        else
                        {
                            this._stockMoveArrivalInput.ArrivalGoodsDayChanged();
                        }

                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.ReceiveAgentName_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.ReceiveAgentCd_tEdit;
                                }
                            }
                        }
                        break;
                    }
                // 入庫拠点コード
                case "AfSectionCode_tEdit":
                    {
                        // 入庫拠点読み込み
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
                                        e.NextCtrl = AfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                // 入庫倉庫コード
                case "AfEnterWarehCode_tEdit":
                    {
                        // 入庫倉庫読み込み
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
                                        e.NextCtrl = this.BfSectionCode_tEdit;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.AfSectionName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = AfSectionCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出庫拠点コード
                case "BfSectionCode_tEdit":
                    {
                        // 出庫拠点読み込み
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
                                    if (this.AfEnterWarehName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.AfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出庫倉庫コード
                case "BfEnterWarehCode_tEdit":
                    {
                        // 出庫倉庫読み込み
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
                                        e.NextCtrl = this.ShipAgentCd_tEdit;
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
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出荷担当者コード
                case "ShipAgentCd_tEdit":
                    {
                        // 出庫倉庫読み込み
                        int status = ReadShipAgent();
                        if ( status == 0 )
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                                {
                                    if (ShipAgentName_tEdit.Text.TrimEnd() != string.Empty)
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
                                    if (this.BfEnterWarehName_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
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
                                if (this.ShipAgentName_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.ShipAgentCd_tEdit;
                                }
                            }
                        }
                        break;
                    }
                // 出荷確定日(開始)
                case "ShipmentFixDaySt_tDateEdit":
                    {
                        DateTime retDateTime;

                        if (ShipmentFixDaySt_tDateEdit.LongDate != 0 && DateTime.TryParse(this.ShipmentFixDaySt_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "有効な日付ではありません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        //else if (this.ShipmentFixDaySt_tDateEdit.LongDate != 0)
                        //{
                        //    // 終了日とのチェック
                        //    if (ShipmentFixDayEd_tDateEdit.LongDate != 0 && ShipmentFixDaySt_tDateEdit.LongDate > ShipmentFixDayEd_tDateEdit.LongDate)
                        //    {
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            "終了日より後の日付は入力できません。",
                        //            -1,
                        //            MessageBoxButtons.OK);

                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        break;
                    }
                // 出荷確定日(終了)
                case "ShipmentFixDayEd_tDateEdit":
                    {
                        DateTime retDateTime;

                        if (ShipmentFixDayEd_tDateEdit.LongDate != 0 && DateTime.TryParse(this.ShipmentFixDayEd_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "有効な日付ではありません。",
                                -1,
                                MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                        }
                        else if (this.ShipmentFixDayEd_tDateEdit.LongDate != 0)
                        {
                            // 開始日とのチェック
                            if (ShipmentFixDaySt_tDateEdit.LongDate != 0 && ShipmentFixDayEd_tDateEdit.LongDate < ShipmentFixDaySt_tDateEdit.LongDate)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "開始日より前の日付は入力できません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                e.NextCtrl = ShipmentFixDaySt_tDateEdit;
                            }
                        }
                        break;
                    }
                case "ultraGrid1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.ReceiveAgentCd_tEdit;
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
        /// 入荷担当者読み込み
        /// </summary>
        /// <returns></returns>
        private int ReadArrivalAgent()
        {
            int status = 0;

            string employeeCode = ReceiveAgentCd_tEdit.Text.Trim();

            if ( employeeCode == _prevHeaderInfo.ArrivalAgentCode )
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
                        SetArrivalAgent( employeeCode, employeeName );

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
                                "移動指示担当者が存在しません。",
                                -1,
                                MessageBoxButtons.OK );

                        // 前回入力に戻す
                        SetArrivalAgent( _prevHeaderInfo.ArrivalAgentCode, _prevHeaderInfo.ArrivalAgentName );
                    }
                }
                else
                {
                    // 未入力→クリア
                    SetArrivalAgent( string.Empty, string.Empty );

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
        /// 出荷担当者読み込み
        /// </summary>
        /// <returns></returns>
        private int ReadShipAgent()
        {
            int status = 0;

            string employeeCode = ShipAgentCd_tEdit.Text.Trim();

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
                                "移動指示担当者が存在しません。",
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
        /// 入庫拠点読み込み処理
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
                                "入庫拠点が存在しません。",
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
        /// 入庫倉庫読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadAfWarehouse()
        {
            int status = 0;

            // 拠点コード取得
            string afSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            if (afSectionCode == string.Empty)
            {
                // 入庫拠点コード未入力なら出庫拠点コード使用
                afSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            }
            if (afSectionCode == string.Empty)
            {
                // 出庫も未入力なら担当者の所属拠点を使用
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
                                "入庫倉庫が存在しません。",
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
        /// 出庫拠点読み込み処理
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
                //// 出庫拠点入力チェック
                //if ( this.bfSectionCodeCheck( bfSectionCode ) == false )
                //{
                //    // 変更キャンセル
                //    // 前回入力値に戻す
                //    SetBfSection( _prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName );
                //    return -1;
                //}

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
                                "出庫拠点が存在しません。",
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
        /// 出庫倉庫読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadBfWarehouse()
        {
            int status = 0;

            // 拠点コード取得
            string bfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            if (bfSectionCode == string.Empty)
            {
                // 出庫拠点コード未入力なら入庫拠点コード使用
                bfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            }
            if (bfSectionCode == string.Empty)
            {
                // 入庫も未入力なら担当者の所属拠点を使用
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
                                "出庫倉庫が存在しません。",
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
        /// 出荷担当者セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetArrivalAgent( string code, string name )
        {
            // 内容を格納
            ReceiveAgentCd_tEdit.Text = code;
            ReceiveAgentName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.ArrivalAgentCode = code;
            _prevHeaderInfo.ArrivalAgentName = name;
        }
        /// <summary>
        /// 出荷担当者セット処理
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
        /// 出庫拠点セット処理
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
        /// 出庫倉庫セット処理
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
        /// 入庫拠点セット処理
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
        /// 入庫倉庫セット処理
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
                if ((this.ShipmentFixDaySt_tDateEdit.GetLongDate() != 0) &&
                    (this.ShipmentFixDayEd_tDateEdit.GetLongDate() != 0))
                {
                    if (this.ShipmentFixDaySt_tDateEdit.GetDateTime() > this.ShipmentFixDayEd_tDateEdit.GetDateTime())
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "開始日より前の日付は入力できません。",
                                    -1,
                                    MessageBoxButtons.OK);

                        this.ShipmentFixDaySt_tDateEdit.Focus();
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;

                // データテーブルをリセット
                _stockMoveDataTable.Clear();

                // 検索条件を格納

                // 入庫拠点コード
                _stockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.Text.Trim();
                // 入庫倉庫コード
                _stockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text.Trim();
                // 出庫拠点コード
                _stockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.Text.Trim();
                // 出庫倉庫コード
                _stockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text.Trim();
                // 出荷担当者コード
                _stockMoveSlipSearchCond.ShipAgentCd = this.ShipAgentCd_tEdit.Text.Trim();
                // 移動伝票番号
                _stockMoveSlipSearchCond.StockMoveSlipNo = this.tNedit_SupplierSlipNo.GetInt();
                // 出荷日(開始)
                _stockMoveSlipSearchCond.ShipmentFixStDay = this.ShipmentFixDaySt_tDateEdit.GetDateTime();
                // 出荷日(終了)
                _stockMoveSlipSearchCond.ShipmentFixEdDay = this.ShipmentFixDayEd_tDateEdit.GetDateTime();
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
                int status = _stockMoveInputAcs.SearchStockMoveArrival();

                // 検索条件の移動状態によってデフォルトビューを設定
                int moveStatus = _stockMoveInputInitAcs.StockMoveSlipSearchCond.MoveStatus;

                // デフォルトビューを設定
                //if (moveStatus == -1)
                //{
                //    _stockMoveDataTable.DefaultView.RowFilter = "MoveStatusView in (2,9)";
                //    _stockMoveDataTableBackUp.DefaultView.RowFilter = "MoveStatusView in (2,9)";
                //}
                //else
                //{
                //    _stockMoveDataTable.DefaultView.RowFilter = "MoveStatusView = " + moveStatus;
                //    _stockMoveDataTableBackUp.DefaultView.RowFilter = "MoveStatusView = " + moveStatus;
                //}

                //// ビューを表示
                //_stockMoveArrivalInput.ultraGrid1.DataSource = _stockMoveDataTable.DefaultView;
                _stockMoveArrivalInput.SettingGridDraw();


                // 正常終了
                if (status == 0)
                {
                    _stockMoveArrivalInput.AllCheckFlg = true;

                    searchAfter();
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

            // 入荷担当者
            if (this.ReceiveAgentCd_tEdit.Text.Trim() != "" && this.ReceiveAgentCd_tEdit.Text.Trim() == LoginInfoAcquisition.Employee.EmployeeCode)
            {
                return true;
            }

            // 入荷日
            if (this.ArrivalGoodsDay_tDateEdit.GetDateTime() == DateTime.Now && this.ArrivalGoodsDay_tDateEdit.LongDate > 0)
            {
                return true;
            }

            // 以下条件のためいらない

            // 入庫拠点
            if (this.AfSectionCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 入庫倉庫
            if (AfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 出庫拠点
            if (BfSectionCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 出庫倉庫
            if (BfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 出荷担当者
            if (this.ShipAgentCd_tEdit.Text.Trim() != "")
            {
                return true;
            }

            // 伝票番号
            if (this.tNedit_SupplierSlipNo.GetInt() != 0)
            {
                return true;
            }

            // 出荷予定日(開始)
            if (this.ShipmentFixDaySt_tDateEdit.GetDateTime() != DateTime.Now)
            {
                return true;
            }

            // 出荷予定日(終了)
            if (this.ShipmentFixDayEd_tDateEdit.GetDateTime() != DateTime.Now)
            {
                return true;
            }

            // 表示条件
            if (this.DisplayCondition_tComboEditor.Value.ToString() != "2")
            {
                return true;
            }

            // グリッド情報の変更確認(入荷フラグのみ)
            for (int i = 0; i < _stockMoveDataTable.Count; i++)
            {
                bool stockMoveArrivalFlag    = (bool)_stockMoveDataTable[i]["ArrivalFlag"];
                bool stockMoveArrivalFlagBak = (bool)_stockMoveDataTableBackUp[i]["ArrivalFlag"];

                if (stockMoveArrivalFlag != stockMoveArrivalFlagBak)
                {
                    return true;
                }
            }

            return false;

            // グリッド情報を確認
            //foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            //{
            //    if (row.ArrivalFlag == true)
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
            // 入荷担当者
            if (this.ReceiveAgentCd_tEdit.Text.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "入荷担当者が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 入荷日
            if (this.ArrivalGoodsDay_tDateEdit.GetDateTime() == new DateTime())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "入荷日が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 入力に問題が無ければチェック通過
            return true;
        }

        public DateTime GetArrivalGoodsDay()
        {
            return this.ArrivalGoodsDay_tDateEdit.GetDateTime();
        }

        /// <summary>
        /// ヘッダ、フッタ情報格納処理(画面より)
        /// </summary>
        public void SetHeaderFooterInfoFromDisplay()
        {
            // 入荷担当者コード
            _stockMoveHeader.ReceiveAgentCd = this.ReceiveAgentCd_tEdit.Text.Trim();
            // 入荷担当者名
            _stockMoveHeader.ReceiveAgentNm = this.ReceiveAgentName_tEdit.Text.Trim();
            // 入荷日
            _stockMoveHeader.ArrivalGoodsDay = this.ArrivalGoodsDay_tDateEdit.GetDateTime();
        }

        /// <summary>
        /// データテーブルビュー設定処理
        /// </summary>
        public void DataTableSettings()
        {
            //_stockMoveDataTable.DefaultView.RowFilter = "";
            //_stockMoveDataTableBackUp.DefaultView.RowFilter = "";
            _stockMoveArrivalInput.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;
            //_stockMoveArrivalInput.SettingGridDraw();
            _stockMoveArrivalInput.Clear();
        }

        # region ガイド系ボタンイベント

        /// <summary>
        /// 入荷担当者ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiveAgentGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, LoginInfoAcquisition.Employee.BelongSectionCode, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveHeader.ReceiveAgentCd = employee.EmployeeCode.Trim();
                    _stockMoveHeader.ReceiveAgentNm = employee.Name;

                    // 結果セット
                    SetArrivalAgent(employee.EmployeeCode.TrimEnd(), employee.Name.TrimEnd());

                    // 拠点変更イベント
                    GetBelongSection();
                    if (SectionChange != null)
                    {
                        SectionChange(this, new EventArgs());
                    }

                    // 次フォーカス
                    // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                    //_guideNextFocusControl.GetNextControl(ReceiveAgentCd_tEdit).Focus();
                    this.ArrivalGoodsDay_tDateEdit.Focus();
                    // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 入庫拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfSectionGuide_ultraButton_Click(object sender, EventArgs e)
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
                    SetAfSection(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm.TrimEnd());
                    // 倉庫クリア
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
        /// 入庫倉庫ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfEnterWarehGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode = AfSectionCode_tEdit.Text;
                Warehouse warehouse;

                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveHeader.AfEnterWarehCode = warehouse.WarehouseCode;
                    _stockMoveHeader.AfEnterWarehName = warehouse.WarehouseName;

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
        /// 出庫拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfSectionGuide_uButton_Click(object sender, EventArgs e)
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
                    // 倉庫クリア
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
        /// 出庫倉庫ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfEnterWarehGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode = this.BfSectionCode_tEdit.Text;

                //if (this.BfSectionCode_tEdit.Text.Trim() == "")
                //{
                //    SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //}
                //else
                //{
                //    SectionCode = this.BfSectionCode_tEdit.Text;
                //}

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

        /// <summary>
        /// 出荷担当者ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShipAgnetGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.ShipAgentCd = employee.EmployeeCode.Trim();

                    // 結果セット
                    SetShipAgent(employee.EmployeeCode.TrimEnd(), employee.Name.TrimEnd());

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(ShipAgentCd_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        # endregion

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
            int status = employeeAcs.Read( out employee, LoginInfoAcquisition.EnterpriseCode, ReceiveAgentCd_tEdit.Text.Trim() );
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
            /// <summary>入庫担当者コード</summary>
            private string _arrivalAgentCode;
            /// <summary>入庫担当者名称</summary>
            private string _arrivalAgentName;
            /// <summary>出荷担当者コード</summary>
            private string _shipAgentCode;
            /// <summary>出荷担当者名称</summary>
            private string _shipAgentName;
            /// <summary>出庫拠点コード</summary>
            private string _bfSectionCode;
            /// <summary>出庫拠点名称</summary>
            private string _bfSectionName;
            /// <summary>出庫倉庫コード</summary>
            private string _bfWarehouseCode;
            /// <summary>出庫倉庫名称</summary>
            private string _bfWarehouseName;
            /// <summary>入庫拠点コード</summary>
            private string _afSectionCode;
            /// <summary>入庫拠点名称</summary>
            private string _afSectionName;
            /// <summary>入庫倉庫コード</summary>
            private string _afWarehouseCode;
            /// <summary>入庫倉庫名称</summary>
            private string _afWarehouseName;

            /// <summary>
            /// 入庫担当者コード
            /// </summary>
            public string ArrivalAgentCode
            {
                get { return _arrivalAgentCode; }
                set { _arrivalAgentCode = value; }
            }
            /// <summary>
            /// 入庫担当者名称
            /// </summary>
            public string ArrivalAgentName
            {
                get { return _arrivalAgentName; }
                set { _arrivalAgentName = value; }
            }
            /// <summary>
            /// 指示担当者コード
            /// </summary>
            public string ShipAgentCode
            {
                get { return _shipAgentCode; }
                set { _shipAgentCode = value; }
            }
            /// <summary>
            /// 指示担当者名称
            /// </summary>
            public string ShipAgentName
            {
                get { return _shipAgentName; }
                set { _shipAgentName = value; }
            }
            /// <summary>
            /// 出庫拠点コード
            /// </summary>
            public string BfSectionCode
            {
                get { return _bfSectionCode; }
                set { _bfSectionCode = value; }
            }
            /// <summary>
            /// 出庫拠点名称
            /// </summary>
            public string BfSectionName
            {
                get { return _bfSectionName; }
                set { _bfSectionName = value; }
            }
            /// <summary>
            /// 出庫倉庫コード
            /// </summary>
            public string BfWarehouseCode
            {
                get { return _bfWarehouseCode; }
                set { _bfWarehouseCode = value; }
            }
            /// <summary>
            /// 出庫倉庫名称
            /// </summary>
            public string BfWarehouseName
            {
                get { return _bfWarehouseName; }
                set { _bfWarehouseName = value; }
            }
            /// <summary>
            /// 入庫拠点コード
            /// </summary>
            public string AfSectionCode
            {
                get { return _afSectionCode; }
                set { _afSectionCode = value; }
            }
            /// <summary>
            /// 入庫拠点名称
            /// </summary>
            public string AfSectionName
            {
                get { return _afSectionName; }
                set { _afSectionName = value; }
            }
            /// <summary>
            /// 入庫倉庫コード
            /// </summary>
            public string AfWarehouseCode
            {
                get { return _afWarehouseCode; }
                set { _afWarehouseCode = value; }
            }
            /// <summary>
            /// 入庫倉庫名称
            /// </summary>
            public string AfWarehouseName
            {
                get { return _afWarehouseName; }
                set { _afWarehouseName = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="arrivalAgentCode">入庫担当者コード</param>
            /// <param name="arrivalAgentName">入庫担当者名称</param>
            /// <param name="stockMvEmpCd">指示担当者コード</param>
            /// <param name="stockMvEmpNm">指示担当者名称</param>
            /// <param name="bfSectionCode">出庫拠点コード</param>
            /// <param name="bfSectionName">出庫拠点名称</param>
            /// <param name="bfWarehouseCode">出庫倉庫コード</param>
            /// <param name="bfWarehouseName">出庫倉庫名称</param>
            /// <param name="afSectionCode">入庫拠点コード</param>
            /// <param name="afSectionName">入庫拠点名称</param>
            /// <param name="afWarehouseCode">入庫倉庫コード</param>
            /// <param name="afWarehouseName">入庫倉庫名称</param>
            public HeaderInfo( string arrivalAgentCode, string arrivalAgentName, string stockMvEmpCd, string stockMvEmpNm, string bfSectionCode, string bfSectionName, string bfWarehouseCode, string bfWarehouseName, string afSectionCode, string afSectionName, string afWarehouseCode, string afWarehouseName )
            {
                _arrivalAgentCode = arrivalAgentCode;
                _arrivalAgentName = arrivalAgentName;
                _shipAgentCode = stockMvEmpCd;
                _shipAgentName = stockMvEmpNm;
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

        /// <summary>
        /// uButton_Click（一括入荷ボタン）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void AllArrival_uButton_Click(object sender, EventArgs e)
        {
            // ADD 2010/06/08 MANTIS対応[15260]：入荷処理画面で一括入荷押下時に入荷日が正しくセットされない ---------->>>>>
            SetHeaderFooterInfoFromDisplay();
            // ADD 2010/06/08 MANTIS対応[15260]：入荷処理画面で一括入荷押下時に入荷日が正しくセットされない ----------<<<<<
            _stockMoveArrivalInput.AllArrival();
        }

        // ----- ADD 2011/05/10 tianjw ------------------------------>>>>>
        /// <summary>
        /// ArrivalGoodsDay_tDateEditのLeaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ArrivalGoodsDay_tDateEditのLeaveイベント。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2011/05/10</br>
        /// </remarks>
        public void ArrivalGoodsDay_tDateEdit_Leave(object sender, EventArgs e)
        {
            this._stockMoveArrivalInput.ArrivalGoodsDayChanged();
        }
        // ----- ADD 2011/05/10 tianjw ------------------------------<<<<<
    }
}
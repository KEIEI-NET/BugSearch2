//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の入力フォームクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 作 成 日              修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2008/02/01  修正内容 : DC.NS用に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/04  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/22  修正内容 : 不具合対応[13583]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/23  修正内容 : 不具合対応[13614] 伝票区分のTabIndexプロパティ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2009.07.07  修正内容 : MANTIS対応[0013663],[0013680],[00113679]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/07/30  修正内容 : MANTIS対応[13771]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤　恵優
// 修 正 日  2010/06/08  修正内容 : 森川部品対応　移動伝票はデフォルトで発行する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤　恵優
// 修 正 日  2010/06/10  修正内容 : MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「５，６，７」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「3」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/12/09  修正内容 : 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 障害改良対応(4月)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : redmine #20881
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2011/05/20  修正内容 : redmine #21632
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2011/05/21  修正内容 : redmine #21684 伝票区分を変更する時、移動伝票区分の制御を変更します
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/09  修正内容 : 仕掛一覧 №2358　入庫前数・入庫後数を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12893]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫移動入力　入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC.NS用に変更。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.02.01</br>
    /// <br>Update Note: 2008/07/14 30414 忍 幸史</br>
    /// <br>           : Partsman用に変更</br>
    /// <br>           : 2009/06/04 照田 貴志　移動データ拠点管理対応</br>
    /// <br>           : 2009/06/22 照田 貴志　不具合対応[13583]</br>
    /// <br>           : 2009/06/23 照田 貴志　不具合対応[13614]　伝票区分のTabIndexプロパティ変更</br>
    /// <br>           : 2009.07.07　佐々木 健　MANTIS対応[0013663],[0013680],[00113679]</br>
    /// <br>           : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
    /// <br>           : 2010/11/15 tianjw 障害改良対応「3」の対応</br>
    /// <br>           : 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
    /// <br>           : 2011/04/11 鄧潘ハン 明細に仕入先を追加する。</br>
    /// <br>Update Note: 2011/05/10 tianjw redmine #20881</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// </remarks>
    public partial class MAZAI04120UA : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <br>Update Note: 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
        public MAZAI04120UA()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            // 在庫移動入力画面のグリッド部分のインスタンスを生成
            this._stockMoveInput = new MAZAI04120UB();

            // 在庫移動に関するアクセス部品のインスタンスを生成
            this._stockMoveInputAcs = StockMoveInputAcs.GetInstance();

            // 在庫移動を行う際の初期取得データのアクセス部品のインスタンスを生成
            this._stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();

            // 在庫移動ヘッダ情報格納データ
            this._stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;

            // 在庫移動入力画面のグリッドデータテーブルのインスタンスを生成
            this._stockMoveDataTable = _stockMoveInputAcs.StockMoveDataTable;

            // 在庫移動データグリッドバックアップテーブル
            this._stockMoveDataTableBackUp = _stockMoveInputAcs.StockMoveDataTableBackup;

            // ボタンイメージの取得
            this._imageList16 = IconResourceManagement.ImageList16;

            // 倉庫ガイド用インスタンス
            this.warehouseAcs = new WarehouseAcs();

            // 従業員ガイド用インスタンス
            this.employeeAcs = new EmployeeAcs();

            // 拠点ガイド用インスタンス
            this.secInfoSetAcs = new SecInfoSetAcs();

            // 移動伝票検索画面
            this._stockMoveSlipSearch = new MAZAI04120UD();

            // 移動合計更新用デリゲート
            this._stockMoveInput.TotalPriceSetting += new MAZAI04120UB.SettingTotalPriceEventHandler(this.SetDisplayTotalPriceInfo);

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            // グリッド品番列Enterデリゲート
            this._stockMoveInput.enterGoodsNoColumn += new MAZAI04120UB.EnterGoodsNoColumnEventHandler(this.EnterGoodsNoColumn);
            
            this._stockMoveInput.getSlipNo += new MAZAI04120UB.GetSlipNoEventHandler(this.GetSlipNo);
            this._stockMoveInput.getSlipmentDay += new MAZAI04120UB.GetSlipmentDayEventHandler(this.GetSlipmentDay);

            this._stockMoveInput.setFocus += new MAZAI04120UB.SetFocusEventHandler(SetFocus);
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 検索時ヘッダ情報格納デリゲート
            this._stockMoveInput.SetStockMoveHeader += new MAZAI04120UB.SetStockMoveHeaderEventHandler(this.SetHeaderFooterInfoFromDisplay);

            //this._stockSlipDetailInput.GridKeyDownTopRow += new EventHandler(this.StockSlipDetailInput_GridKeyDownTopRow);
            //this._stockSlipDetailInput.GridKeyDownButtomRow += new EventHandler(this.StockSlipDetailInput_GridKeyDownButtomRow);
            //this._stockSlipDetailInput.StockPriceChanged += new EventHandler(this.StockSlipDetailInput_StockPriceChanged);
            //this._stockSlipDetailInput.StatusBarMessageSetting += new MASIR01101UB.SettingStatusBarMessageEventHandler(this.StockSlipDetailInput_StatusBarMessageSetting);
            //this._stockSlipDetailInput.FocusSetting += new MASIR01101UB.SettingFocusEventHandler(SetFocus);

            // 前回ヘッダ情報
            _prevHeaderInfo = new HeaderInfo();

            // ガイド後フォーカス
            SettingGuideNextControl();

            // 所属拠点情報初期化
            _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName;

            this.TopLevel = false;

            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            UpdatePrintOutOption();
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

            // ---ADD 2010/12/09------->>>>>
            // 初期化
            this._prevStockMoveHeader = new StockMoveHeader();
            this._prevStockMoveHeader.StockMvEmpCode = this._stockMoveHeader.StockMvEmpCode;
            this._prevStockMoveHeader.BfSectionCode = this._stockMoveHeader.BfSectionCode;
            this._prevStockMoveHeader.ShipmentScdlDay = this._stockMoveHeader.ShipmentScdlDay;
            // ---ADD 2010/12/09-------<<<<<
        }

        // --- ADD 2011/05/20 --------------------------------------------------------------------->>>>>
        // 出荷日
        private DateTime _shipmentDay = new DateTime();
        // --- ADD 2011/05/20 ---------------------------------------------------------------------<<<<<
        
        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        public bool GetEnabledSupplierSlipNo()
        {
            return this.tNedit_SupplierSlipNo.Enabled;
        }

        /// <summary>
        /// グリッド品番列Enter時処理
        /// </summary>
        /// <param name="goodsNoFlg">品番列フラグ(True:品番 False:品番以外)</param>
        private void EnterGoodsNoColumn(Boolean goodsNoFlg)
        {
            if (enterGoodsNoColumn != null)
            {
                enterGoodsNoColumn(goodsNoFlg);
            }
        }

        public void Renewal()
        {
            this._stockMoveInputInitAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode);
            this._stockMoveInputAcs.LoadMakerUMnt();
            this._stockMoveInputAcs.LoadBlGoodsCdUMnt();
            this._stockMoveInputAcs.LoadStockMngTtlSt();
            // 自社情報設定取得処理
            this._stockMoveInput.SetCompanyInf(); // ADD 2011/07/25
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <br>Update Note: 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
        public bool CompareBeforeNewProc()
        {
            // ---UPD 2010/12/09------->>>>>
            //// 移動指示担当者
            //if (this.StockMvEmpCode_tEdit.DataText.Trim().PadLeft(4, '0') != LoginInfoAcquisition.Employee.EmployeeCode.Trim())
            //{
            //    return (false);
            //}

            //// 出荷日
            //if (this.SlipmentDay_tDateEdit.GetDateTime() != DateTime.Today)
            //{
            //    return (false);
            //}

            //// 伝票番号
            //if (this.tNedit_SupplierSlipNo.DataText.Trim() != "")
            //{
            //    return (false);
            //}

            //// 移動元拠点
            //if (this.BfSectionCode_tEdit.DataText.Trim().PadLeft(2, '0') != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
            //{
            //    return (false);
            //}

            //// 移動元倉庫
            //if (this.BfEnterWarehCode_tEdit.DataText.Trim() != "")
            //{
            //    return (false);
            //}

            //// 移動先拠点
            //if (this.AfSectionCode_tEdit.DataText.Trim() != "")
            //{
            //    return (false);
            //}

            //// 移動先倉庫
            //if (this.AfEnterWarehCode_tEdit.DataText.Trim() != "")
            //{
            //    return (false);
            //}

            //// グリッド
            //if (this._stockMoveInput.CheckGridBeforeNewProc() == false)
            //{
            //    return (false);
            //}

            //// 備考
            //if (this.Outline_tEdit.DataText.Trim() != "")
            //{
            //    return (false);
            //}

            // 移動指示担当者
            if (this.StockMvEmpCode_tEdit.DataText.Trim().PadLeft(4, '0') != this._prevStockMoveHeader.StockMvEmpCode)
            {
                return (false);
            }

            // 出荷日
            if (this.SlipmentDay_tDateEdit.GetDateTime() != this._prevStockMoveHeader.ShipmentScdlDay)
            {
                return (false);
            }

            // 伝票番号
            if (this.tNedit_SupplierSlipNo.DataText.Trim() != "")
            {
                return (false);
            }

            // 移動元拠点
            if (this.BfSectionCode_tEdit.DataText.Trim().PadLeft(2, '0') != this._prevStockMoveHeader.BfSectionCode.PadLeft(2, '0'))
            {
                return (false);
            }

            // 移動元倉庫
            if (this.BfEnterWarehCode_tEdit.DataText.Trim().PadLeft(4, '0') != this._prevStockMoveHeader.BfEnterWarehCode.PadLeft(4, '0'))
            {
                return (false);
            }

            // 移動先拠点
            if (this.AfSectionCode_tEdit.DataText.Trim().PadLeft(2, '0') != this._prevStockMoveHeader.AfSectionCode.PadLeft(2, '0'))
            {
                return (false);
            }

            // 移動先倉庫
            if (this.AfEnterWarehCode_tEdit.DataText.Trim().PadLeft(4, '0') != this._prevStockMoveHeader.AfEnterWarehCode.PadLeft(4, '0'))
            {
                return (false);
            }

            // グリッド
            if (this._stockMoveInput.CheckGridBeforeNewProc() == false)
            {
                return (false);
            }

            // 備考
            if (this.Outline_tEdit.DataText.Trim() != "")
            {
                return (false);
            }
            // ---UPD 2010/12/09-------<<<<<

            return (true);
        }

        public void RetryProc()
        {
            SearchSlipInfo(this._stockMoveSlipNo);

            _stockMoveInput.ultraGrid1.Focus();
            _stockMoveInput.ultraGrid1.Rows[0].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
            _stockMoveInput.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// 伝票番号取得処理
        /// </summary>
        /// <returns>伝票番号</returns>
        public string GetSlipNo()
        {
            return this.tNedit_SupplierSlipNo.DataText.Trim();
        }

        /// <summary>
        /// 出荷日取得処理
        /// </summary>
        /// <returns>出荷日</returns>
        public DateTime GetSlipmentDay()
        {
            return this.SlipmentDay_tDateEdit.GetDateTime();
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="controlName">コントロール名</param>
        private void SetFocus(string controlName)
        {
            Control[] controls = this.Controls.Find(controlName, true);

            if (controls.Length > 0)
            {
                controls[0].Focus();
            }
        }

        /// <summary>
        /// 在庫移動形式取得処理
        /// </summary>
        /// <returns>在庫移動形式</returns>
        public int GetStockMoveFormal()
        {
            if (this.StockMoveFormal_label.Text.Trim() == "倉庫移動")
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ガイド後フォーカス設定
        /// </summary>
        private void SettingGuideNextControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            // (header)
            _guideNextFocusControl.Add( StockMvEmpCode_tEdit );
            _guideNextFocusControl.Add( BfSectionCode_tEdit );
            _guideNextFocusControl.Add( BfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( AfSectionCode_tEdit );
            _guideNextFocusControl.Add( AfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( AfEnterWarehCode_tEdit );   // ←次はgridなので細工する
            // (grid)
            // (footer)
            _guideNextFocusControl.Add( Outline_tEdit );
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録時印刷チェックボックス
        /// </summary>
        public bool PrintCheck
        {
            get { return this.radioButton1.Checked; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録時印刷チェック取得処理
        /// </summary>
        /// <returns></returns>
        public bool GetPrintCheck()
        {
            if ((int)this.uOptionSet_PrintOut.Value == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// 前回伝票番号設定処理
        /// </summary>
        /// <param name="lastSlipNo">前回伝票番号</param>
        public void SetLastSlipNo(int lastSlipNo)
        {
            this.uLabel_LastSalesSlipNum.Text = lastSlipNo.ToString("000000000");
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        // ---ADD 2009/06/04 --------------------------------->>>>>
        /// <summary>
        /// 伝票区分
        /// </summary>
        /// <returns></returns>
        public int GetSlipDiv()
        {
            if (this.SlipDiv_tComboEditor.Visible == false)
            {
                return -1;
            }
            else
            {
                return (int)this.SlipDiv_tComboEditor.Value;
            }
        }
        // ---ADD 2009/06/04 ---------------------------------<<<<<

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        void _stockMoveInput_TotalPriceSetting()
        {
            throw new Exception("The method or operation is not implemented.");
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        public MAZAI04120UB _stockMoveInput;
        private StockMoveInputAcs _stockMoveInputAcs;
        private StockMoveHeader _stockMoveHeader;
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableBackUp;

        private WarehouseAcs warehouseAcs;
        private EmployeeAcs employeeAcs;
        private SecInfoSetAcs secInfoSetAcs;

        // ---ADD 2010/12/09--------->>>>>
        // 「新規ボタン」押下時のメッセージの有無判断用
        private StockMoveHeader _prevStockMoveHeader;
        // ---ADD 2010/12/09---------<<<<<

        // 在庫移動伝票検索画面
        private MAZAI04120UD _stockMoveSlipSearch;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 受託在庫拠点間移動区分
        private int TrustStSectMoveCd;
        // 受託在庫倉庫移動区分
        private int TrustStWhouMoveCd;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        private ImageList _imageList16 = null;										// イメージリスト

        // ガイド後フォーカス制御
        private GuideNextFocusControl _guideNextFocusControl;

        // 前回ヘッダ情報
        private HeaderInfo _prevHeaderInfo;

        /// <summary>移動指示担当者・所属拠点コード</summary>
        private string _belongSectionCode;
        /// <summary>移動指示担当者・所属拠点ガイド名称</summary>
        private string _belongSectionName;

        /// <summary>拠点変更イベント</summary>
        public event EventHandler SectionChange;

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        public event EnterGoodsNoColumnEventHandler enterGoodsNoColumn;
        public delegate void EnterGoodsNoColumnEventHandler(Boolean goodsNoFlg);

        public event ChangeFocusFooterEventHandler changeFocusFooter;
        public delegate void ChangeFocusFooterEventHandler(Boolean changeFlg);

        public event LoadSlipGuideEventHandler loadSlipGuide;
        public delegate void LoadSlipGuideEventHandler();

        public event SetSlipInfoEventHandler setSlipInfo;
        public delegate void SetSlipInfoEventHandler();

        /// <summary>検索条件情報</summary>
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;

        private int _stockMoveSlipNo;
        private ArrayList _retStockMoveWorkList;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        // 2009.04.02 30413 犬飼 保存用イベント追加 >>>>>>START
        public event SaveEventHandler save;
        public delegate void SaveEventHandler();
        // 2009.04.02 30413 犬飼 保存用イベント追加 <<<<<<END

        // ADD 2009/03/31 不具合対応[12893]：スペースキーでの項目選択機能を実装 ---------->>>>>
        #region ラジオボタンのスペースキー制御

        /// <summary>移動伝票ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printOutRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 移動伝票ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>移動伝票ラジオボタンのKeyPressイベントのヘルパ</value>
        private OptionSetKeyPressEventHelper PrintOutRadioKeyPressHelper
        {
            get { return _printOutRadioKeyPressHelper; }
        }

        #endregion  // ラジオボタンのスペースキー制御
        // ADD 2009/03/31 不具合対応[12893]：スペースキーでの項目選択機能を実装 ----------<<<<<

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
        private void MAZAI04120UA_Load(object sender, EventArgs e)
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
            this.Detail_panel.Controls.Add(this._stockMoveInput);
            this._stockMoveInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 在庫管理全体設定取得処理
            this._stockMoveInputInitAcs.ReadStockMngTtlSt();

            // 自社情報設定取得処理
            this._stockMoveInput.SetCompanyInf(); // ADD 2011/07/25

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 受託在庫拠点間移動区分
            this.TrustStSectMoveCd = _stockMoveInputInitAcs.TrustStSectMoveCd;

            // 受託在庫倉庫移動区分
            this.TrustStWhouMoveCd = _stockMoveInputInitAcs.TrustStWhouMoveCd;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            // ---ADD 2009/06/04 -------------------------------------->>>>>
            // ※ツールバーの「入荷処理(F8)」ボタンの設定はフレームのほうで行う
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                this.SlipDiv_ultraLabel.Visible = false;
                this.SlipDiv_tComboEditor.Visible = false;
                this.SlipmentDay_ultraLabel.Text = "出荷日";
            }
            else
            {
                this.SlipDiv_ultraLabel.Visible = true;
                this.SlipDiv_tComboEditor.Visible = true;
                this.SlipDiv_tComboEditor.SelectedIndex = 0;
                this.SlipmentDay_ultraLabel.Text = "日付";
            }
            // ---ADD 2009/06/04 --------------------------------------<<<<<

            // ヘッダ情報クリア
            _stockMoveInputInitAcs.StockMoveHeaderClear();

            // 検索条件情報
            _stockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;

            // 画面初期化処理
            this.Clear();

            // フォーカスセット
            this.StockMvEmpCode_tEdit.Focus();

            this.TopLevel = false;

            // ADD 2009/03/31 不具合対応[12893]：スペースキーでの項目選択機能を実装 ---------->>>>>
            #region ラジオボタンのスペースキー制御

            PrintOutRadioKeyPressHelper.ControlList.Add(this.uOptionSet_PrintOut);
            PrintOutRadioKeyPressHelper.StartSpaceKeyControl();

            #endregion  // ラジオボタンのスペースキー制御
            // ADD 2009/03/31 不具合対応[12893]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04120UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ヘッダ情報を初期化する。
            _stockMoveInputInitAcs.StockMoveHeaderClear();

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            // グリッド情報XML保存
            _stockMoveInput.SaveXmlData();

            _stockMoveInput.CloseFlg = true;
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        private void SetControlSize()
        {
            this.StockMvEmpCode_tEdit.Size = new Size(52, 24);
            this.StockMvEmpName_tEdit.Size = new Size(147, 24);
            this.BfSectionCode_tEdit.Size = new Size(52, 24);
            this.BfSectionName_tEdit.Size = new Size(147, 24);
            this.AfSectionCode_tEdit.Size = new Size(52, 24);
            this.AfSectionGuideNm_tEdit.Size = new Size(147, 24);
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
            this.MoveAgentNameGuide_uButton.ImageList = this._imageList16;
            this.MoveOthSelectionGuide_uButton.ImageList = this._imageList16;
            this.MoveOthWarehouseGuide_uButton.ImageList = this._imageList16;
            this.BfSectionGuide_ultraButton.ImageList = this._imageList16;
            this.BfEnterWarehGuide_ultraButton.ImageList = this._imageList16;
            this.Outline_uButton.ImageList = this._imageList16;
            this.SalesSlipGuide_uButton.ImageList = this._imageList16;

            this.MoveAgentNameGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.MoveOthSelectionGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.MoveOthWarehouseGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfSectionGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfEnterWarehGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.Outline_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.SalesSlipGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 本社機能かどうかの判断
        /// </summary>
        /// <returns>True: 本社機能 False: 本社機能でない</returns>
        private bool IsMainOfficeFunc()
        {
            if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// クリア処理
        /// </summary>
        /// <br>Update Note: 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
        public void Clear()
        {
            // グリッド初期化
            ClearGrid();

            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            //// 印刷チェックボックスデフォルト(1:発行しない)
            //this.uOptionSet_PrintOut.Value = 0; // MOD 2010/06/08 森川部品対応　移動伝票はデフォルトで発行する 1→0
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            // 印刷チェックボックスデフォルト(設定に従う)
            // FIXME:this.uOptionSet_PrintOut.Value = StockMoveInputInitDataAcs.LoadUserCustomSetting().PrintsSlip ? 0 : 1;
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

            // 初期表示
            this.StockMvEmpCode_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this.StockMvEmpName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            this.SlipmentDay_tDateEdit.SetDateTime(DateTime.Now);
            //---ADD 2011/05/20---------------------->>>>>
            // 出荷日を保存します
            _shipmentDay = this.SlipmentDay_tDateEdit.GetDateTime();
            //---ADD 2011/05/20----------------------<<<<<
            this.BfSectionCode_tEdit.Text = "";
            this.BfSectionName_tEdit.Text = "";
            this.BfEnterWarehCode_tEdit.Text = "";
            this.BfEnterWarehName_tEdit.Text = "";
            this.AfSectionCode_tEdit.Text = "";
            this.AfSectionGuideNm_tEdit.Text = "";
            this.AfEnterWarehCode_tEdit.Text = "";
            this.AfEnterWarehName_tEdit.Text = "";
            this.tNedit_SupplierSlipNo.Text = "";
            //this.uLabel_LastSalesSlipNum.Text = "";

            // 画面ヘッダ部分のアクティブ変更
            this.StockMvEmpCode_tEdit.Enabled = true;
            this.MoveAgentNameGuide_uButton.Enabled = true;
            this.SlipmentDay_tDateEdit.Enabled = true;
            this.AfSectionCode_tEdit.Enabled = true;
            this.MoveOthSelectionGuide_uButton.Enabled = true;
            this.AfEnterWarehCode_tEdit.Enabled = true;
            this.BfSectionCode_tEdit.Enabled = true;
            this.BfEnterWarehCode_tEdit.Enabled = true;
            this.MoveOthWarehouseGuide_uButton.Enabled = true;
            this.tNedit_SupplierSlipNo.Enabled = true;
            this.SalesSlipGuide_uButton.Enabled = true;

            this.SlipDiv_tComboEditor.Enabled = true;       //ADD 2009/06/04
            this.SlipDiv_tComboEditor.Value = 0;            //ADD 2009/06/04

            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 本社機能であれば、出庫拠点の入力を許可
            //if ( this.IsMainOfficeFunc() == true )
            //{
            //    this.BfSectionCode_tEdit.Enabled = true;
            //    this.BfSectionGuide_ultraButton.Enabled = true;
            //}
            //else
            //{
            //    this.BfSectionCode_tEdit.Enabled = false;
            //    this.BfSectionGuide_ultraButton.Enabled = false;
            //}
            this.BfSectionCode_tEdit.Enabled = true;
            this.BfSectionGuide_ultraButton.Enabled = true;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode ).Trim();

            this._stockMoveHeader.StockMvEmpCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this._stockMoveHeader.StockMvEmpName = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            this._stockMoveHeader.BfSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this._stockMoveHeader.BfSectionGuideName = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();

            // 備考を初期化
            this.Outline_tEdit.Text = "";
            this.Outline_uButton.Enabled = true;

            // 所属拠点を初期化
            _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName.Trim();

            // 前回ヘッダ情報初期化
            if (StockMvEmpCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.StockMvEmpCd = "";
            }
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            if (BfSectionCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            }
            else
            {
                _prevHeaderInfo.BfSectionCode = "";
            }
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            if (BfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.BfWarehouseCode = "";
            }
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            if (AfSectionCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            }
            else
            {
                _prevHeaderInfo.AfSectionCode = "";
            }
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            if (AfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.AfWarehouseCode = "";
            }
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();

            // ---ADD 2010/12/09-------->>>>>
            // 前回ヘッダ情報保存
            this._prevStockMoveHeader.AfEnterWarehCode = _prevHeaderInfo.AfWarehouseCode;
            this._prevStockMoveHeader.AfSectionCode = _prevHeaderInfo.AfSectionCode;
            this._prevStockMoveHeader.BfEnterWarehCode = _prevHeaderInfo.BfWarehouseCode;
            this._prevStockMoveHeader.BfSectionCode = _prevHeaderInfo.BfSectionCode;
            this._prevStockMoveHeader.StockMvEmpCode = _prevHeaderInfo.StockMvEmpCd;
            this._prevStockMoveHeader.ShipmentScdlDay = this.SlipmentDay_tDateEdit.GetDateTime();
            // ---ADD 2010/12/09--------<<<<<
        }

        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
        /// <summary>
        /// 移動伝票の[発行する]([発行しない])オプションを更新します。
        /// </summary>
        public void UpdatePrintOutOption()
        {
            this.uOptionSet_PrintOut.Value = StockMoveInputInitDataAcs.LoadUserCustomSetting().PrintsSlip ? 0 : 1;   
        }

        public int GetPrintOutOptionValue()
        {
            return (int)this.uOptionSet_PrintOut.Value;
        }

        public void SetPrintOutOptionValue(int value)
        {
            if (value < 0) return;
            this.uOptionSet_PrintOut.Value = value;
        }
        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void ClearGrid()
        {
            _stockMoveInput.oldsupplierCd = -1; // ADD 2011/04/11
            // 在庫移動明細DataTable行クリア処理
            this._stockMoveDataTable.Rows.Clear();

            // 移動合計金額のクリアとデータ更新フラグの変更処理
            this.SetDisplayTotalPriceInfo();

            // テーブル更新フラグのリセット
            this._stockMoveInput.TableUpdateFlg = false;

            // グリッド側クリア処理
            _stockMoveInput.Clear();

            // グリッド入力制御
            ClearGridEnabled();
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// クリア処理
        /// </summary>
        public void Clear()
        {
            // 在庫移動明細DataTable行クリア処理
            this._stockMoveDataTable.Rows.Clear();

            // 移動合計金額のクリアとデータ更新フラグの変更処理
            this.SetDisplayTotalPriceInfo();

            // テーブル更新フラグのリセット
            this._stockMoveInput.TableUpdateFlg = false;

            // グリッド側クリア処理
            _stockMoveInput.Clear();

            // 印刷チェックボックスデフォルト
            this.radioButton2.Checked = true;

            // グリッド側の初期化
            _stockMoveInput.Clear();

            // 初期表示
            this.StockMvEmpCode_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            this.StockMvEmpName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            this.SlipmentDay_tDateEdit.SetDateTime(DateTime.Now);
            this.BfSectionCode_tEdit.Text = "";
            this.BfSectionName_tEdit.Text = "";
            this.BfEnterWarehCode_tEdit.Text = "";
            this.BfEnterWarehName_tEdit.Text = "";
            this.AfSectionCode_tEdit.Text = "";
            this.AfSectionGuideNm_tEdit.Text = "";
            this.AfEnterWarehCode_tEdit.Text = "";
            this.AfEnterWarehName_tEdit.Text = "";
            this.StockMoveSlipNo_ultraLabel2.Text = "";

            // 画面ヘッダ部分のアクティブ変更
            this.StockMvEmpCode_tEdit.ReadOnly = false;
            this.StockMvEmpName_tEdit.ReadOnly = true;
            this.MoveAgentNameGuide_uButton.Enabled = true;
            this.SlipmentDay_tDateEdit.ReadOnly = false;
            this.AfSectionCode_tEdit.ReadOnly = false;
            this.AfSectionGuideNm_tEdit.ReadOnly = true;
            this.MoveOthSelectionGuide_uButton.Enabled = true;
            this.AfEnterWarehCode_tEdit.ReadOnly = false;
            this.AfEnterWarehName_tEdit.ReadOnly = true;

            this.BfSectionCode_tEdit.ReadOnly = false;
            this.BfSectionName_tEdit.ReadOnly = true;
            this.BfEnterWarehCode_tEdit.ReadOnly = false;
            this.BfEnterWarehName_tEdit.ReadOnly = true;

            this.MoveOthWarehouseGuide_uButton.Enabled = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 本社機能であれば、出庫拠点の入力を許可
            if (this.IsMainOfficeFunc() == true)
            {
                this.BfSectionCode_tEdit.ReadOnly = false;
                this.BfSectionName_tEdit.ReadOnly = true;
                this.BfSectionGuide_ultraButton.Enabled = true;
            }
            else
            {
                this.BfSectionCode_tEdit.ReadOnly = true;
                this.BfSectionName_tEdit.ReadOnly = true;
                this.BfSectionGuide_ultraButton.Enabled = false;
            }
            this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();

            //// 出庫拠点を入力不可にする
            //this.BfSectionCode_tEdit.ReadOnly = true;
            //this.BfSectionName_tEdit.ReadOnly = true;
            //this.BfSectionGuide_ultraButton.Enabled = false;

            //this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode).Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 備考を初期化
            this.Outline_tEdit.Text = "";
            this.Outline_tEdit.ReadOnly = false;
            this.Outline_uButton.Enabled = true;

            // 所属拠点を初期化
            _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName.Trim();
            //// 所属拠点変更イベント
            //if ( SectionChange != null )
            //{
            //    SectionChange( this, new EventArgs() );
            //}

            // 前回ヘッダ情報初期化
            _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 保存、削除後のフォーカス移動処理
        /// </summary>
        /// <param name="sender">送信先処理文字列</param>
        public void ChangeFocus(string sender)
        {
            switch (sender)
            {
                // 保存後のフォーカス移動
                case "SAVE":
                    {
                        if (this.BfSectionCode_tEdit.ReadOnly == false)
                        {
                            this.BfSectionCode_tEdit.Focus();
                        }
                        else
                        {
                            this.BfEnterWarehCode_tEdit.Focus();
                        }

                        break;
                    }
                // 削除後のフォーカス移動
                case "DELETE":
                    {
                        this.StockMvEmpCode_tEdit.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// 伝票呼出時のヘッダ情報格納処理
        /// </summary>
        /// <param name="stockMvEmpCode">移動指示担当者コード</param>
        /// <param name="stockMvEmpName">移動指示担当者名</param>
        /// <param name="shipmentScdlDay">出荷日</param>
        /// <param name="afSectionCode">入庫拠点コード</param>
        /// <param name="afSectionGuideName">入庫拠点ガイド名</param>
        /// <param name="afEnterWarehCode">入庫倉庫コード</param>
        /// <param name="afEnterWarehName">入庫倉庫名</param>
        /// <param name="bfSectionCode">出庫拠点コード</param>
        /// <param name="bfSectionGuideName">出庫拠点名</param>
        /// <param name="bfEnterWarehCode">出庫倉庫コード</param>
        /// <param name="bfEnterWarehName">出庫倉庫名</param>
        /// <param name="outLine">伝票摘要</param>
        /// <param name="stockMoveSlipNo">移動伝票番号</param>
        public void setHeader(string stockMvEmpCode, string stockMvEmpName, DateTime shipmentScdlDay,
                              string afSectionCode, string afSectionGuideName, string afEnterWarehCode, string afEnterWarehName,
                              string bfSectionCode, string bfSectionGuideName, string bfEnterWarehCode, string bfEnterWarehName,
                              string outLine, int stockMoveSlipNo)
        {
            // エディット内容
            this.StockMvEmpCode_tEdit.Text = stockMvEmpCode.Trim();
            this.StockMvEmpName_tEdit.Text = stockMvEmpName.Trim();
            this.SlipmentDay_tDateEdit.SetDateTime(shipmentScdlDay);
            this.AfSectionCode_tEdit.Text = afSectionCode.Trim();
            this.AfSectionGuideNm_tEdit.Text = afSectionGuideName.Trim();
            this.AfEnterWarehCode_tEdit.Text = afEnterWarehCode.Trim();
            this.AfEnterWarehName_tEdit.Text = afEnterWarehName.Trim();
            this.BfSectionCode_tEdit.Text = bfSectionCode.Trim();
            this.BfSectionName_tEdit.Text = bfSectionGuideName.Trim();
            this.BfEnterWarehCode_tEdit.Text = bfEnterWarehCode.Trim();
            this.BfEnterWarehName_tEdit.Text = bfEnterWarehName.Trim();
            this.Outline_tEdit.Text = outLine.Trim();
            this.tNedit_SupplierSlipNo.Text = stockMoveSlipNo.ToString().PadLeft(9, '0');
            this._stockMoveSlipNo = stockMoveSlipNo;

            // ヘッダ情報
            _stockMoveHeader.StockMvEmpCode = stockMvEmpCode.Trim();
            _stockMoveHeader.StockMvEmpName = stockMvEmpName.Trim();
            _stockMoveHeader.ShipmentScdlDay = shipmentScdlDay;
            _stockMoveHeader.AfSectionCode = afSectionCode.Trim();
            _stockMoveHeader.AfSectionGuideName = afSectionGuideName.Trim();
            _stockMoveHeader.AfEnterWarehCode = afEnterWarehCode.Trim();
            _stockMoveHeader.AfEnterWarehName = afEnterWarehName.Trim();
            _stockMoveHeader.BfSectionCode = bfSectionCode.Trim();
            _stockMoveHeader.BfSectionGuideName = bfSectionGuideName.Trim();
            _stockMoveHeader.BfEnterWarehCode = bfEnterWarehCode.Trim();
            _stockMoveHeader.BfEnterWarehName = bfEnterWarehName.Trim();
            _stockMoveHeader.OutLine = outLine.Trim();
            _stockMoveHeader.StockMoveSlipNo = stockMoveSlipNo;

            // 前回ヘッダ情報初期化
            _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();

            // 2009.07.07 Add >>>
            int stockMoveFormal = this.GetReadDataStockMoveFormal();
            this.SlipDiv_tComboEditor.Value = ( stockMoveFormal > 2 ) ? 1 : 0;
            // 2009.07.07 Add <<<

            // --ADD 2009/07/30 --------------------->>>>>
            this._stockMoveInputAcs.SlipDiv = (stockMoveFormal > 2) ? 1 : 0;
            // --ADD 2009/07/30 ---------------------<<<<<

            // 変更不可設定
            this.StockMvEmpCode_tEdit.Enabled = false;
            this.MoveAgentNameGuide_uButton.Enabled = false;
            this.SlipmentDay_tDateEdit.Enabled = false;
            this.AfSectionCode_tEdit.Enabled = false;
            this.MoveOthSelectionGuide_uButton.Enabled = false;
            this.AfEnterWarehCode_tEdit.Enabled = false;
            this.MoveOthWarehouseGuide_uButton.Enabled = false;
            this.BfSectionCode_tEdit.Enabled = false;
            this.BfSectionGuide_ultraButton.Enabled = false;
            this.BfEnterWarehCode_tEdit.Enabled = false;
            this.BfEnterWarehGuide_ultraButton.Enabled = false;
            this.tNedit_SupplierSlipNo.Enabled = false;
            this.SalesSlipGuide_uButton.Enabled = false;

            this.SlipDiv_tComboEditor.Enabled = false;          //ADD 2009/06/04

            // 拠点変更イベント処理
            GetBelongSection();
            if (SectionChange != null)
            {
                SectionChange(this, new EventArgs());
            }

            // 伝票呼出後のテーブル更新フラグをリセット
            _stockMoveInput.TableUpdateFlg = false;

            _stockMoveInput.ultraGrid1.Focus();
            _stockMoveInput.ultraGrid1.Rows[0].Cells[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Activate();
            _stockMoveInput.ultraGrid1.PerformAction(UltraGridAction.EnterEditMode);
        }


        /// <summary>
        /// ヘッダ情報クリア処理
        /// </summary>
        public void HeaderClear()
        {
            // 移動指示担当者コード
            this.StockMvEmpCode_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 移動指示担当者名称
            this.StockMvEmpName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            // 出荷日
            this.SlipmentDay_tDateEdit.SetDateTime(DateTime.Now);
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Clear();
            // 入庫拠点名称
            this.AfSectionGuideNm_tEdit.Clear();
            // 入庫倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 入庫倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Clear();
            // 出庫拠点名称
            this.BfSectionName_tEdit.Clear();
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 出庫倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 移動伝票番号
            this.tNedit_SupplierSlipNo.Text = "";
            //// 前回保存伝票番号
            //this.uLabel_LastSalesSlipNum.Text = "";
            // 移動伝票
            this.uOptionSet_PrintOut.Enabled = true;
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            //this.uOptionSet_PrintOut.Value = 0;
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            // FIXME:UpdatePrintOutOption();
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            // 備考
            this.Outline_tEdit.Clear();

            // 前回ヘッダ情報初期化
            _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();

            // 各項目状態変更
            this.StockMvEmpCode_tEdit.Enabled = true;
            this.MoveAgentNameGuide_uButton.Enabled = true;
            this.SlipmentDay_tDateEdit.Enabled = true;
            this.AfSectionCode_tEdit.Enabled = true;
            this.MoveOthSelectionGuide_uButton.Enabled = true;
            this.AfEnterWarehCode_tEdit.Enabled = true;
            this.MoveOthWarehouseGuide_uButton.Enabled = true;
            this.BfSectionCode_tEdit.Enabled = true;
            this.BfSectionGuide_ultraButton.Enabled = true;
            this.BfEnterWarehCode_tEdit.Enabled = true;
            this.BfEnterWarehGuide_ultraButton.Enabled = true;
            this.tNedit_SupplierSlipNo.Enabled = true;
            this.SalesSlipGuide_uButton.Enabled = true;
            this.Outline_tEdit.Enabled = true;
            this.Outline_uButton.Enabled = true;

            this.SlipDiv_tComboEditor.Enabled = true;       //ADD 2009/06/04
            this.SlipDiv_tComboEditor.Value = 0;            //ADD 2009/06/04

            this.StockMoveFormal_label.BackColor = Color.Orange;
            this.StockMoveFormal_label.Text = "倉庫移動";

            // 拠点変更イベント処理
            GetBelongSection();
            if (SectionChange != null)
            {
                SectionChange(this, new EventArgs());
            }

            // フォーカスセット
            this.StockMvEmpCode_tEdit.Focus();

            changeFocusFooter(false);
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 伝票呼出時のヘッダ情報格納処理
        /// </summary>
        /// <param name="stockMvEmpCode">移動指示担当者コード</param>
        /// <param name="stockMvEmpName">移動指示担当者名</param>
        /// <param name="shipmentScdlDay">出荷日</param>
        /// <param name="afSectionCode">入庫拠点コード</param>
        /// <param name="afSectionGuideName">入庫拠点ガイド名</param>
        /// <param name="afEnterWarehCode">入庫倉庫コード</param>
        /// <param name="afEnterWarehName">入庫倉庫名</param>
        /// <param name="bfSectionCode">出庫拠点コード</param>
        /// <param name="bfSectionGuideName">出庫拠点名</param>
        /// <param name="bfEnterWarehCode">出庫倉庫コード</param>
        /// <param name="bfEnterWarehName">出庫倉庫名</param>
        /// <param name="outLine">伝票摘要</param>
        /// <param name="stockMoveSlipNo">移動伝票番号</param>
        public void setHeader(string stockMvEmpCode, string stockMvEmpName, DateTime shipmentScdlDay,
                              string afSectionCode, string afSectionGuideName, string afEnterWarehCode, string afEnterWarehName,
                              string bfSectionCode, string bfSectionGuideName, string bfEnterWarehCode, string bfEnterWarehName,
                              string outLine, int stockMoveSlipNo)
        {
            // エディット内容
            this.StockMvEmpCode_tEdit.Text = stockMvEmpCode.Trim();
            this.StockMvEmpName_tEdit.Text = stockMvEmpName.Trim();
            this.SlipmentDay_tDateEdit.SetDateTime(shipmentScdlDay);
            this.AfSectionCode_tEdit.Text = afSectionCode.Trim();
            this.AfSectionGuideNm_tEdit.Text = afSectionGuideName.Trim();
            this.AfEnterWarehCode_tEdit.Text = afEnterWarehCode.Trim();
            this.AfEnterWarehName_tEdit.Text = afEnterWarehName.Trim();

            this.BfSectionCode_tEdit.Text = bfSectionCode.Trim();
            this.BfSectionName_tEdit.Text = bfSectionGuideName.Trim();
            this.BfEnterWarehCode_tEdit.Text = bfEnterWarehCode.Trim();
            this.BfEnterWarehName_tEdit.Text = bfEnterWarehName.Trim();

            this.Outline_tEdit.Text = outLine.Trim();

            this.StockMoveSlipNo_ultraLabel2.Text = stockMoveSlipNo.ToString().PadLeft(9,'0');

            // ヘッダ情報
            _stockMoveHeader.StockMvEmpCode = stockMvEmpCode.Trim();
            _stockMoveHeader.StockMvEmpName = stockMvEmpName.Trim();
            _stockMoveHeader.ShipmentScdlDay = shipmentScdlDay;
            _stockMoveHeader.AfSectionCode = afSectionCode.Trim();
            _stockMoveHeader.AfSectionGuideName = afSectionGuideName.Trim();
            _stockMoveHeader.AfEnterWarehCode = afEnterWarehCode.Trim();
            _stockMoveHeader.AfEnterWarehName = afEnterWarehName.Trim();

            _stockMoveHeader.BfSectionCode = bfSectionCode.Trim();
            _stockMoveHeader.BfSectionGuideName = bfSectionGuideName.Trim();
            _stockMoveHeader.BfEnterWarehCode = bfEnterWarehCode.Trim();
            _stockMoveHeader.BfEnterWarehName = bfEnterWarehName.Trim();

            _stockMoveHeader.OutLine = outLine.Trim();

            _stockMoveHeader.StockMoveSlipNo = stockMoveSlipNo;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 前回ヘッダ情報初期化
            _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 変更不可設定
            this.StockMvEmpCode_tEdit.ReadOnly = true;
            this.StockMvEmpName_tEdit.ReadOnly = true;
            this.MoveAgentNameGuide_uButton.Enabled = false;
            this.SlipmentDay_tDateEdit.ReadOnly = true;
            this.AfSectionCode_tEdit.ReadOnly = true;
            this.AfSectionGuideNm_tEdit.ReadOnly = true;
            this.MoveOthSelectionGuide_uButton.Enabled = false;
            this.AfEnterWarehCode_tEdit.ReadOnly = true;
            this.AfEnterWarehName_tEdit.ReadOnly = true;
            this.MoveOthWarehouseGuide_uButton.Enabled = false;

            this.BfSectionCode_tEdit.ReadOnly = true;
            this.BfSectionName_tEdit.ReadOnly = true;
            this.BfSectionGuide_ultraButton.Enabled = false;
            this.BfEnterWarehCode_tEdit.ReadOnly = true;
            this.BfEnterWarehName_tEdit.ReadOnly = true;
            this.BfEnterWarehGuide_ultraButton.Enabled = false;

            this.Outline_tEdit.ReadOnly = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.Outline_uButton.Enabled = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 拠点変更イベント処理
            GetBelongSection();
            if ( SectionChange != null )
            {
                SectionChange( this, new EventArgs() );
            }

            // 伝票呼出後のテーブル更新フラグをリセット
            _stockMoveInput.TableUpdateFlg = false;
        }

        /// <summary>
        /// ヘッダ情報クリア処理
        /// </summary>
        public void HeaderClear()
        {
            // 移動指示担当者コード
            this.StockMvEmpCode_tEdit.Text = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 移動指示担当者名称
            this.StockMvEmpName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode).Trim();
            // 出荷日
            this.SlipmentDay_tDateEdit.SetDateTime(DateTime.Now);
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Clear();
            // 入庫拠点名称
            this.AfSectionGuideNm_tEdit.Clear();
            // 入庫倉庫コード
            this.AfEnterWarehCode_tEdit.Clear();
            // 入庫倉庫名称
            this.AfEnterWarehName_tEdit.Clear();
            // 出庫拠点コード
            this.BfSectionCode_tEdit.Clear();
            // 出庫拠点名称
            this.BfSectionName_tEdit.Clear();
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Clear();
            // 出庫倉庫名称
            this.BfEnterWarehName_tEdit.Clear();
            // 移動伝票番号
            this.StockMoveSlipNo_ultraLabel2.Text = "";

            // 移動伝票
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            // 備考
            this.Outline_tEdit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 前回ヘッダ情報初期化
            _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd();
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 各項目状態変更
            this.StockMvEmpCode_tEdit.ReadOnly = false;
            this.StockMvEmpName_tEdit.ReadOnly = true;
            this.MoveAgentNameGuide_uButton.Enabled = true;
            this.SlipmentDay_tDateEdit.ReadOnly = false;
            this.AfSectionCode_tEdit.ReadOnly = false;
            this.AfSectionGuideNm_tEdit.ReadOnly = true;
            this.MoveOthSelectionGuide_uButton.Enabled = true;
            this.AfEnterWarehCode_tEdit.ReadOnly = false;
            this.AfEnterWarehName_tEdit.ReadOnly = true;
            this.MoveOthWarehouseGuide_uButton.Enabled = true;

            this.BfSectionCode_tEdit.ReadOnly = false;
            this.BfSectionName_tEdit.ReadOnly = true;
            this.BfSectionGuide_ultraButton.Enabled = true;
            this.BfEnterWarehCode_tEdit.ReadOnly = false;
            this.BfEnterWarehName_tEdit.ReadOnly = true;
            this.BfEnterWarehGuide_ultraButton.Enabled = true;

            this.Outline_tEdit.ReadOnly = false;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.Outline_uButton.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 拠点変更イベント処理
            GetBelongSection();
            if ( SectionChange != null )
            {
                SectionChange( this, new EventArgs() );
            }

            this.radioButton1.Checked = true;

            // フォーカスセット
            this.StockMvEmpCode_tEdit.Focus();

        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 明細グリッドのReturnKeyDown呼び出し
        /// </summary>
        /// <remarks>
        /// <br>外部から明細グリッド編集を確定させる為に公開します。</br>
        /// </remarks>
        public void DetailReturnKeyDown ()
        {
            // 明細部のReturnKeyDown処理呼び出し
            //this._stockMoveInput.ReturnKeyDown();

            this._stockMoveInput.SaveFlg = true;
            this._stockMoveInput.ultraGrid1.ActiveCell = null;
            this._stockMoveInput.SaveFlg = false;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        private void SearchSlipInfo(int stockMoveSlipNo)
        {
            // 取得した移動伝票番号から再度データを抽出
            _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
            // 移動伝票番号を検索条件に指定する
            _stockMoveSlipSearchCond.StockMoveSlipNo = stockMoveSlipNo;
            // 在庫移動／倉庫移動で同一伝票番号が存在しても処理できるよう、条件を追加
            //_stockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.DataText.Trim();
            //_stockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.DataText.Trim();

            // -- DEL 2009/07/30 ---------------------------------->>>>>
            //// ---ADD 2009/06/04 ------------------------------------>>>>>
            //// 伝票区分「-1:項目非表示、0:出庫伝票、1:入庫伝票」(保存処理前にAクラスにセットする必要有り)
            //int slipDiv = this.GetSlipDiv();
            //this._stockMoveInputAcs.SlipDiv = slipDiv;
            //// ---ADD 2009/06/04 ------------------------------------<<<<<

            // 移動伝票検索開始
            ArrayList retStockMoveWorkList = new ArrayList();
            int status = this._stockMoveInputAcs.SearchStockMove(ref retStockMoveWorkList);

            // -- ADD 2009/07/30 --------------------->>>>>
            // 伝票区分「-1:項目非表示、0:出庫伝票、1:入庫伝票」(保存処理前にAクラスにセットする必要有り)
            int slipDiv = -1;
            // -- ADD 2009/07/30 ---------------------<<<<<

            if (status == 0)
            {
                // -- ADD 2009/07/30 --------------------------------->>>>>
                foreach (StockMoveWork work in retStockMoveWorkList)
                {
                    if ((work.StockMoveFormal == 1) || (work.StockMoveFormal == 2))
                    {
                        // 出庫
                        slipDiv = 0;
                    }
                    else
                    {
                        // 入庫
                        slipDiv = 1;
                    }
                    break;
                }
                // -- ADD 2009/07/30 ---------------------------------<<<<<

                // ---DEL 2009/06/04 ------------------------>>>>>
                //foreach (StockMoveWork work in retStockMoveWorkList)
                //{
                //    // 入荷済みの伝票は表示しない
                //    if (work.MoveStatus == 9)
                //    {
                //        status = 9;
                //        break;
                //    }
                //}
                // ---DEL 2009/06/04 ------------------------<<<<<
                // ---ADD 2009/06/04 ------------------------>>>>>
                //在庫移動確定区分「1：入荷確定あり」
                if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
                {
                    foreach (StockMoveWork work in retStockMoveWorkList)
                    {
                        // 入荷済みの伝票は表示しない
                        if (work.MoveStatus == 9)
                        {
                            status = 9;
                            break;
                        }
                    }
                }
                // 在庫移動確定区分「2：入荷確定なし」
                else
                {
                    //伝票区分「0：出庫伝票」
                    if (slipDiv == 0)
                    {
                        foreach (StockMoveWork work in retStockMoveWorkList)
                        {
                            // 移動中の伝票は表示しない
                            if (work.MoveStatus == 2)
                            {
                                status = 9;
                                break;
                            }
                        }
                    }
                    //伝票区分「1：入庫伝票」
                    else
                    {
                        //無条件で表示OK
                    }
                }
                // ---ADD 2009/06/04 ------------------------<<<<<
            }

            if (status == 0)
            {
                this._retStockMoveWorkList = retStockMoveWorkList;

                // 取得した結果を親のグリッドに格納
                this._stockMoveSlipSearch.updateGridFromStockMoveSlipGuide(retStockMoveWorkList);

                _stockMoveInputInitAcs.GuideSelected = true;

                if (_stockMoveHeader.BfSectionCode.Trim() == _stockMoveHeader.AfSectionCode.Trim())
                {
                    this.StockMoveFormal_label.BackColor = Color.Orange;
                    this.StockMoveFormal_label.Text = "倉庫移動";
                }
                else
                {
                    this.StockMoveFormal_label.BackColor = Color.Navy;
                    this.StockMoveFormal_label.Text = "在庫移動";
                }

                // -- 2009/07/30 ---------------------------->>>>>
                //// 2009.07.07 Add >>>
                //foreach (StockMoveWork work in retStockMoveWorkList)
                //{
                //    if (( work.StockMoveFormal == 1 ) || ( work.StockMoveFormal == 2 ))
                //    {
                //        // 出庫
                //        this.SlipDiv_tComboEditor.Value = 0;
                //    }
                //    else
                //    {
                //        // 入庫
                //        this.SlipDiv_tComboEditor.Value = 1;
                //    }
                //    break;
                //}
                //// 2009.07.07 Add <<<
                
                this.SlipDiv_tComboEditor.Value = slipDiv;
                this._stockMoveInputAcs.SlipDiv = slipDiv;
                // -- 2009/07/30 ----------------------------<<<<<



                setSlipInfo();
            }
            // 該当データ無し
            else if (status == 9)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当するデータが存在しません。",
                    status,
                    MessageBoxButtons.OK);

                this.tNedit_SupplierSlipNo.Clear();
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

        // ----- ADD 2011/05/10 tianjw ---------------------------->>>>>
        /// <summary>
        /// SlipmentDay_tDateEditのLeaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : SlipmentDay_tDateEditのLeaveイベント。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2011/05/10</br>
        /// <br>Update Note: 2011/05/20 朱俊成 Redmine#21632日付を変更する場合、メッセージを追加</br>
        /// </remarks>
        private void SlipmentDay_tDateEdit_Leave(object sender, EventArgs e)
        {
            //this._stockMoveInput.ResetStockMoveDataTable(); // DEL 2011/05/20
            //---ADD 2011/05/20---------------------->>>>>
            this.SlipmentDay_tDateEdit.Leave -= this.SlipmentDay_tDateEdit_Leave;
            DateTime value = this.SlipmentDay_tDateEdit.GetDateTime();
            // 日付を変更する場合
            if (_shipmentDay != value)
            {
                // 明細部にデータがある場合
                if (this._stockMoveInput.ExistDetailData())
                {
                    string messageStr = string.Empty;
                    // 入荷確定あり/入荷確定なし（出庫伝票）時、「出荷日が変更されました」を表示します。
                    if (1 == this._stockMoveInputInitAcs.StockMoveFixCode ||
                        (1 != this._stockMoveInputInitAcs.StockMoveFixCode && 0 == this.SlipDiv_tComboEditor.SelectedIndex))
                    {
                        messageStr = "出荷日が変更されました。";
                    }
                    // 入荷確定なし（入庫伝票）時、「入荷日が変更されました」を表示します
                    else
                    {
                        messageStr = "入荷日が変更されました。";
                    }
                    DialogResult dialogResult = TMsgDisp.Show(
                                               this,
                                               emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                               this.Name,
                                               messageStr + "\r\n" + "\r\n" +
                                               "商品価格を再取得しますか？",
                                               -1,
                                               MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._stockMoveInput.ResetStockMoveDataTable();
                    }
                }
            }
            this.SlipmentDay_tDateEdit.Leave += this.SlipmentDay_tDateEdit_Leave;
            _shipmentDay = this.SlipmentDay_tDateEdit.GetDateTime();
            //---ADD 2011/05/20----------------------<<<<<
        }
        // ----- ADD 2011/05/10 tianjw ----------------------------<<<<<

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>Update Note : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 伝票番号
                case "tNedit_SupplierSlipNo":
                    {
                        if (this.tNedit_SupplierSlipNo.GetInt() == 0)
                        {
                            return;
                        }

                        int stockMoveSlipNo = this.tNedit_SupplierSlipNo.GetInt();
                        this._stockMoveSlipNo = stockMoveSlipNo;

                        SearchSlipInfo(stockMoveSlipNo);
                        break;
                    }
                // 管理部品グリッド
                case "ultraGrid1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this._stockMoveInput.ReturnKeyDown(ref e);
                            }
                        }
                        else
                        {
                            //if (e.Key == Keys.Tab) // DEL 2010/11/15
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter)) // ADD 2010/11/15
                            {
                                this._stockMoveInput.ShiftKeyDown(ref e);
                            }
                        }
                        break;
                    }
                // 移動指示担当者コード
                case "StockMvEmpCode_tEdit":
                    {
                        // 指示担当者読み込み
                        int status = ReadStockMvEmp();
                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (StockMvEmpName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力済み→次項目へ
                                        e.NextCtrl = SlipmentDay_tDateEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出荷日 ================================================== //
                case "SlipmentDay_tDateEdit":
                    {
                        // 日付チェック
                        DateTime retDateTime;
                        if ((SlipmentDay_tDateEdit.LongDate != 0) && 
                            (DateTime.TryParse(this.SlipmentDay_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false))
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "有効な日付ではありません。",
                                          -1,
                                          MessageBoxButtons.OK);

                            e.NextCtrl = e.PrevCtrl;
                        }

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
                // 出庫拠点 ============================================ //
                case "BfSectionCode_tEdit":
                    {
                        // 出庫拠点読み込み
                        int status = ReadBfSection();
                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (BfSectionName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力済み→次項目へ
                                        e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 出庫倉庫 ============================================ //
                case "BfEnterWarehCode_tEdit":
                    {
                        // 出庫倉庫読み込み
                        int status = ReadBfWarehouse();
                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (BfEnterWarehName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力済み→次項目へ
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
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 入庫拠点コード ============================================ //
                case "AfSectionCode_tEdit":
                    {
                        // 入庫拠点読み込み
                        int status = ReadAfSection();
                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (AfSectionGuideNm_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力済み→次項目へ
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
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 入庫倉庫コード ============================================ //
                case "AfEnterWarehCode_tEdit":
                    {
                        // 入庫倉庫読み込み
                        int status = ReadAfWarehouse();
                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (AfEnterWarehName_tEdit.Text.TrimEnd() != string.Empty)
                                    {
                                        // 入力済み→次項目へ
                                        e.NextCtrl = null;
                                        this._stockMoveInput.ReturnKeyDownEnterFocus();
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.AfSectionGuideNm_tEdit.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.AfSectionCode_tEdit;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 備考 ============================================ //
                case "Outline_tEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.Outline_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.uOptionSet_PrintOut;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this._stockMoveInput.ShiftKeyDownEnterFocus();
                            }
                        }
                        break;
                    }
                // 移動伝票 ============================================ //
                case "uOptionSet_PrintOut":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Outline_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.Outline_tEdit;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return)
                            {
                                e.NextCtrl = null;
                                // 保存処理
                                save();
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                // 2009.04.02 30413 犬飼 移動伝票にフォーカスがある場合の処理を追加 >>>>>>START
                //changeFocusFooter(false);
                if (this.uOptionSet_PrintOut.Focused)
                {
                    changeFocusFooter(true);
                }
                else
                {
                    changeFocusFooter(false);
                }
                // 2009.04.02 30413 犬飼 移動伝票にフォーカスがある場合の処理を追加 <<<<<<END
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "Outline_tEdit":
                case "Outline_uButton":
                case "uOptionSet_PrintOut":
                    {
                        changeFocusFooter(true);
                        break;
                    }
                default:
                    {
                        changeFocusFooter(false);
                        break;
                    }
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 管理部品グリッド
                case "ultraGrid1":
                    {
                        # region [ultraGrid1]
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this._stockMoveInput.ultraGrid1.ActiveCell != null)
                                    {
                                        if (this._stockMoveInput.ReturnKeyDown())
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            // 備考へ移動
                                            e.NextCtrl = this.Outline_tEdit;
                                        }
                                    }
                                    break;
                                }
                        }
                        # endregion
                        break;
                    }

                // 移動指示担当者コード
                case "StockMvEmpCode_tEdit":
                    {
                        # region [StockMvEmpCode_tEdit]
                        // 指示担当者読み込み
                        int status = ReadStockMvEmp();

                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (StockMvEmpCode_tEdit.Text.TrimEnd() == string.Empty)
                                            {
                                                // 未入力→ガイドへ
                                            }
                                            else
                                            {
                                                // 入力済み→次項目へ
                                                e.NextCtrl = _guideNextFocusControl.GetNextControl(StockMvEmpCode_tEdit);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        # endregion
                        break;
                    }
                // 出荷日 ================================================== //
                case "SlipmentDay_tDateEdit":
                    {
                        // 日付チェック
                        DateTime retDateTime;
                        if (SlipmentDay_tDateEdit.LongDate != 0 && DateTime.TryParse(this.SlipmentDay_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
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
                        break;
                    }

                // 入庫拠点コード ============================================ //
                case "AfSectionCode_tEdit":
                    {
                        // 入庫拠点読み込み
                        int status = ReadAfSection();

                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (AfSectionCode_tEdit.Text.TrimEnd() == string.Empty)
                                            {
                                                // 未入力→ガイドへ
                                            }
                                            else
                                            {
                                                // 入力済み→次項目へ
                                                e.NextCtrl = _guideNextFocusControl.GetNextControl(AfSectionCode_tEdit);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                // 入庫拠点名称ガイドボタン ============================================ //
                case "MoveOthSelectionGuide_uButton":
                    {
                        break;
                    }

                // 入庫倉庫コード ============================================ //
                case "AfEnterWarehCode_tEdit":
                    {
                        // 入庫倉庫読み込み
                        int status = ReadAfWarehouse();

                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {

                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (AfEnterWarehCode_tEdit.Text.TrimEnd() == string.Empty)
                                            {
                                                // 未入力→ガイドへ
                                            }
                                            else
                                            {
                                                // 入力済み→次項目へ
                                                // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                                                //e.NextCtrl = _guideNextFocusControl.GetNextControl( AfEnterWarehCode_tEdit );
                                                e.NextCtrl = this._stockMoveInput;
                                                // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                // 入庫倉庫名称ガイドボタン ============================================ //
                case "MoveOthWarehouseGuide_uButton":
                    {
                        // グリッドへ移動
                        if (_stockMoveInput.ultraGrid1.ActiveCell == null)
                        {

                        }
                        this._stockMoveInput.SetGridFocus();
                        break;
                    }

                // 出庫拠点 ============================================ //
                case "BfSectionCode_tEdit":
                    {
                        // 出庫拠点読み込み
                        int status = ReadBfSection();

                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {

                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (BfSectionCode_tEdit.Text.TrimEnd() == string.Empty)
                                            {
                                                // 未入力→ガイドへ
                                            }
                                            else
                                            {
                                                // 入力済み→次項目へ
                                                e.NextCtrl = _guideNextFocusControl.GetNextControl(BfSectionCode_tEdit);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                // 出庫倉庫 ============================================ //
                case "BfEnterWarehCode_tEdit":
                    {
                        // 出庫倉庫読み込み
                        int status = ReadBfWarehouse();

                        if (status == 0)
                        {
                            if (e.ShiftKey == false)
                            {

                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (BfEnterWarehCode_tEdit.Text.TrimEnd() == string.Empty)
                                            {
                                                // 未入力→ガイドへ
                                            }
                                            else
                                            {
                                                // 入力済み→次項目へ
                                                e.NextCtrl = _guideNextFocusControl.GetNextControl(BfEnterWarehCode_tEdit);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時はフォーカス移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }

                // 備考 ================================================== //
                case "Outline_tEdit":
                    {
                        break;
                    }
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # region ■ 読み込み処理 ■

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 移動入力担当者読み込み
        /// </summary>
        /// <returns></returns>
        private int ReadStockMvEmp()
        {
            int status = 0;

            if (StockMvEmpCode_tEdit.Text.Trim() == "")
            {
                // 未入力→クリア
                SetStockMvEmp(string.Empty, string.Empty);

                // 拠点変更イベント処理
                GetBelongSection();
                if (this.SectionChange != null)
                {
                    SectionChange(this, new EventArgs());
                }
                return 0;
            }

            string employeeCode = StockMvEmpCode_tEdit.Text.Trim().PadLeft(4, '0');

            if (employeeCode == _prevHeaderInfo.StockMvEmpCd)
            {
                // 前回入力コードと同じ→なにもしない
            }
            else
            {
                if (employeeCode != string.Empty)
                {
                    // 名称取得
                    string employeeName = _stockMoveInputInitAcs.GetEmployeeName(employeeCode);

                    if (employeeName != string.Empty)
                    {
                        // 入力ＯＫ→内容更新
                        status = 0;

                        // 内容セット
                        SetStockMvEmp(employeeCode, employeeName);

                        // 拠点変更イベント処理
                        GetBelongSection();
                        if (this.SectionChange != null)
                        {
                            SectionChange(this, new EventArgs());
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
                                MessageBoxButtons.OK);

                        // 前回入力に戻す
                        SetStockMvEmp(_prevHeaderInfo.StockMvEmpCd, _prevHeaderInfo.StockMvEmpNm);
                    }
                }
                else
                {
                    // 未入力→クリア
                    SetStockMvEmp(string.Empty, string.Empty);

                    // 拠点変更イベント処理
                    GetBelongSection();
                    if (this.SectionChange != null)
                    {
                        SectionChange(this, new EventArgs());
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

            if (AfSectionCode_tEdit.Text.TrimEnd() == "")
            {
                SetAfSection(string.Empty, string.Empty);
                SetAfWarehouse(string.Empty, string.Empty);
                CheckStockMoveMode();
                return 0;
            }

            string afSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');

            if (afSectionCode == _prevHeaderInfo.AfSectionCode)
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if (afSectionCode != string.Empty)
                {
                    // 名称取得
                    string afSectionName = _stockMoveInputInitAcs.GetSectionName(afSectionCode);

                    if (afSectionName != string.Empty)
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetAfSection(afSectionCode, afSectionName);

                        // 拠点が変わったら倉庫をクリア
                        SetAfWarehouse(string.Empty, string.Empty);
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
                                MessageBoxButtons.OK);

                        // 前回入力値に戻す
                        SetAfSection(_prevHeaderInfo.AfSectionCode, _prevHeaderInfo.AfSectionName);
                    }
                }
                else
                {
                    // 内容を格納
                    SetAfSection(string.Empty, string.Empty);

                    // 拠点が変わったら倉庫をクリア
                    SetAfWarehouse(string.Empty, string.Empty);
                }
            }

            // 拠点移動か倉庫移動かを判別
            CheckStockMoveMode();

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

            if (this.AfEnterWarehCode_tEdit.DataText.Trim() == "")
            {
                SetAfWarehouse(string.Empty, string.Empty);
                CheckStockMoveMode();
                return 0;
            }

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

            if (afWarehouseCode == _prevHeaderInfo.AfWarehouseCode)
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if (afWarehouseCode != string.Empty)
                {
                    // 名称取得
                    string afWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(afSectionCode, afWarehouseCode);

                    if (afWarehouseName != string.Empty)
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetAfWarehouse(afWarehouseCode, afWarehouseName);
                        // 拠点も反映
                        SetAfSection(afSectionCode, _stockMoveInputInitAcs.GetSectionName(afSectionCode));
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
                                MessageBoxButtons.OK);

                        SetAfWarehouse(_prevHeaderInfo.AfWarehouseCode, _prevHeaderInfo.AfWarehouseName);
                    }
                }
                else
                {
                    // 入力クリア
                    SetAfWarehouse(string.Empty, string.Empty);
                }
            }

            // 拠点移動か倉庫移動かを判別
            CheckStockMoveMode();

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

            if (BfSectionCode_tEdit.Text.TrimEnd() == "")
            {
                SetBfSection(string.Empty, string.Empty);
                SetBfWarehouse(string.Empty, string.Empty);
                CheckStockMoveMode();
                return 0;
            }

            string bfSectionCode = BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');

            if (bfSectionCode == _prevHeaderInfo.BfSectionCode)
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                // 出庫拠点入力チェック
                if (this.bfSectionCodeCheck(bfSectionCode) == false)
                {
                    // 変更キャンセル
                    // 前回入力値に戻す
                    SetBfSection(_prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName);
                    return -1;
                }

                if (bfSectionCode != string.Empty)
                {
                    // 名称取得
                    string bfSectionName = _stockMoveInputInitAcs.GetSectionName(bfSectionCode);

                    if (bfSectionName != string.Empty)
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetBfSection(bfSectionCode, bfSectionName);

                        // 拠点が変わったら倉庫をクリア
                        SetBfWarehouse(string.Empty, string.Empty);
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
                                MessageBoxButtons.OK);

                        // 前回入力値に戻す
                        SetBfSection(_prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName);
                    }
                }
                else
                {
                    // 入力クリア

                    // 内容を格納
                    SetBfSection(string.Empty, string.Empty);

                    // 拠点が変わったら倉庫をクリア
                    SetBfWarehouse(string.Empty, string.Empty);
                }
            }

            // 拠点移動か倉庫移動かを判別
            CheckStockMoveMode();

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

            if (BfEnterWarehCode_tEdit.DataText.Trim() == "")
            {
                SetBfWarehouse(string.Empty, string.Empty);
                CheckStockMoveMode();

                ClearGrid();
                return 0;
            }

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

            if (bfWarehouseCode == _prevHeaderInfo.BfWarehouseCode)
            {
                // 前回コードと同じ→何もしない
            }
            else
            {
                if (bfWarehouseCode != string.Empty)
                {
                    // 名称取得
                    string bfWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(bfSectionCode, bfWarehouseCode);

                    if (bfWarehouseName != string.Empty)
                    {
                        // 入力ＯＫ
                        status = 0;

                        // 内容を格納
                        SetBfWarehouse(bfWarehouseCode, bfWarehouseName);
                        // 拠点も反映
                        SetBfSection(bfSectionCode, _stockMoveInputInitAcs.GetSectionName(bfSectionCode));
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
                                MessageBoxButtons.OK);

                        SetBfWarehouse(_prevHeaderInfo.BfWarehouseCode, _prevHeaderInfo.BfWarehouseName);

                        ClearGrid();
                    }
                }
                else
                {
                    // 入力クリア
                    SetBfWarehouse(string.Empty, string.Empty);

                    ClearGrid();
                }
            }

            // 拠点移動か倉庫移動かを判別
            CheckStockMoveMode();

            // ステータスを返す
            return status;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 移動入力担当者読み込み
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadStockMvEmp()
        {
            if (this.StockMvEmpCode_tEdit.Text.Trim() == "")
            {
                // 未入力→クリア
                SetStockMvEmp(string.Empty, string.Empty);

                // 拠点変更イベント処理
                GetBelongSection();
                if (this.SectionChange != null)
                {
                    SectionChange(this, new EventArgs());
                }

                return (0);
            }

            // 従業員コード取得
            string employeeCode = StockMvEmpCode_tEdit.Text.Trim().PadLeft(4, '0');
            //if ( employeeCode == _prevHeaderInfo.StockMvEmpCd )
            //{
            //    // 前回入力コードと同じ→なにもしない
            //    return (0);
            //}

            // 名称取得
            string employeeName = _stockMoveInputInitAcs.GetEmployeeName(employeeCode);
            if (employeeName != string.Empty)
            {
                // 内容セット
                SetStockMvEmp(employeeCode, employeeName);

                // 拠点変更イベント処理
                GetBelongSection();
                if (this.SectionChange != null)
                {
                    SectionChange(this, new EventArgs());
                }
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "移動指示担当者が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                // 前回入力に戻す
                SetStockMvEmp(_prevHeaderInfo.StockMvEmpCd, _prevHeaderInfo.StockMvEmpNm);

                return (-1);
            }

            // ステータスを返す
            return (0);
        }

        /// <summary>
        /// 入庫拠点読み込み処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadAfSection()
        {
            //if (this.AfSectionCode_tEdit.Text.TrimEnd() == "")
            //{
            //    // 入庫拠点セット
            //    SetAfSection(string.Empty, string.Empty);

            //    // 入庫倉庫設定
            //    SetAfWarehouse(string.Empty, string.Empty);

            //    // 在庫・倉庫移動判別
            //    CheckStockMoveMode();

            //    return (0);
            //}
            if (this.AfSectionCode_tEdit.Text.TrimEnd() == "")
            {
                if (this.AfSectionCode_tEdit.Text.TrimEnd() != _prevHeaderInfo.AfSectionCode)
                {
                    // 入庫拠点入力チェック
                    if (afSectionCodeCheck(this.AfSectionCode_tEdit.Text.TrimEnd()) == false)
                    {
                        // 変更キャンセル
                        // 前回入力値に戻す
                        SetAfSection(_prevHeaderInfo.AfSectionCode, _prevHeaderInfo.AfSectionName);
                        return (-1);
                    }
                }

                // 入庫拠点セット
                SetAfSection(string.Empty, string.Empty);
                // 入庫倉庫セット
                SetAfWarehouse(string.Empty, string.Empty);
                // 在庫・倉庫移動判別
                CheckStockMoveMode();
                return (0);
            }

            // 拠点コード取得
            string afSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            if (afSectionCode == _prevHeaderInfo.AfSectionCode)
            {
                // 前回コードと同じ→何もしない
                return (0);
            }

            // 入庫拠点入力チェック
            if (afSectionCodeCheck(afSectionCode) == false)
            {
                // 変更キャンセル
                // 前回入力値に戻す
                SetAfSection(_prevHeaderInfo.AfSectionCode, _prevHeaderInfo.AfSectionName);
                return (-1);
            }

            // 名称取得
            string afSectionName = _stockMoveInputInitAcs.GetSectionName(afSectionCode);
            if (afSectionName != string.Empty)
            {
                // 内容を格納
                SetAfSection(afSectionCode, afSectionName);

                // 拠点が変わったら倉庫をクリア
                SetAfWarehouse(string.Empty, string.Empty);
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "入庫拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                // 前回入力値に戻す
                SetAfSection(_prevHeaderInfo.AfSectionCode, _prevHeaderInfo.AfSectionName);

                return (-1);
            }

            // 在庫・倉庫移動判別
            CheckStockMoveMode();

            // ステータスを返す
            return (0);
        }

        /// <summary>
        /// 入庫倉庫読み込み処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadAfWarehouse()
        {
            //if (this.AfEnterWarehCode_tEdit.DataText.Trim() == "")
            //{
            //    // 入庫倉庫設置
            //    SetAfWarehouse(string.Empty, string.Empty);
            //    // 在庫・倉庫移動判別
            //    CheckStockMoveMode();

            //    return (0);
            //}
            if (this.AfEnterWarehCode_tEdit.DataText.Trim() == "")
            {
                if (this.AfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0') != _prevHeaderInfo.AfWarehouseCode)
                {
                    // 出庫倉庫入力チェック
                    if (this.afEnterwarehCodeCheck(this.AfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0')) == false)
                    {
                        // 変更キャンセル
                        // 前回入力値に戻す
                        SetAfWarehouse(_prevHeaderInfo.AfWarehouseCode, _prevHeaderInfo.AfWarehouseName);
                        return (-1);
                    }
                }

                // 出庫倉庫セット
                SetAfWarehouse(string.Empty, string.Empty);
                // 在庫・倉庫移動判別
                CheckStockMoveMode();
                // グリッドクリア
                ClearGrid();
                return 0;
            }

            // 拠点コード取得
            string afSectionCode = this.AfSectionCode_tEdit.Text.Trim();
            if ( afSectionCode == string.Empty )
            {
                // 入庫拠点コード未入力なら出庫拠点コード使用
                afSectionCode = this.BfSectionCode_tEdit.Text.Trim();
            }
            if ( afSectionCode == string.Empty )
            {
                //// 出庫も未入力なら担当者の所属拠点を使用
                //afSectionCode = this._belongSectionCode;                                          //DEL 2009/06/22 不具合対応[13583]
                //出庫も未入力なら倉庫の管理拠点を使用
                afSectionCode = this.GetWarehouseSection(AfEnterWarehCode_tEdit.Text.Trim());       //ADD 2009/06/22 不具合対応[13583]
            }

            // 倉庫コード取得
            string afWarehouseCode = AfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0');
            if (afWarehouseCode == _prevHeaderInfo.AfWarehouseCode)
            {
                // 前回コードと同じ→何もしない
                return (0);
            }

            // 出庫倉庫入力チェック
            if (this.afEnterwarehCodeCheck(afWarehouseCode) == false)
            {
                // 変更キャンセル
                // 前回入力値に戻す
                SetAfWarehouse(_prevHeaderInfo.AfWarehouseCode, _prevHeaderInfo.AfWarehouseName);
                return (-1);
            }

            // 名称取得
            string afWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(afWarehouseCode);
            if (afWarehouseName != string.Empty)
            {
                // 内容を格納
                SetAfWarehouse(afWarehouseCode, afWarehouseName);
                // 拠点も反映
                SetAfSection(afSectionCode, _stockMoveInputInitAcs.GetSectionName(afSectionCode));
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "入庫倉庫が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                // 入庫倉庫セット
                SetAfWarehouse(_prevHeaderInfo.AfWarehouseCode, _prevHeaderInfo.AfWarehouseName);

                return (-1);
            }

            // 在庫・倉庫移動判別
            CheckStockMoveMode();

            // ステータスを返す
            return (0);
        }

        /// <summary>
        /// 出庫拠点読み込み処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadBfSection()
        {
            if (this.BfSectionCode_tEdit.Text.TrimEnd() == "")
            {
                if (this.BfSectionCode_tEdit.Text.TrimEnd() != _prevHeaderInfo.BfSectionCode)
                {
                    // 出庫拠点入力チェック
                    if (bfSectionCodeCheck(this.BfSectionCode_tEdit.Text.TrimEnd()) == false)
                    {
                        // 変更キャンセル
                        // 前回入力値に戻す
                        SetBfSection(_prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName);
                        return (-1);
                    }
                }

                // 出庫拠点セット
                SetBfSection(string.Empty, string.Empty);
                // 出庫倉庫セット
                SetBfWarehouse(string.Empty, string.Empty);
                // 在庫・倉庫移動判別
                CheckStockMoveMode();
                return (0);
            }

            // 拠点コード取得
            string bfSectionCode = this.BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            if (bfSectionCode == _prevHeaderInfo.BfSectionCode)
            {
                // 前回コードと同じ→何もしない
                return (0);
            }

            // 出庫拠点入力チェック
            if (bfSectionCodeCheck(bfSectionCode) == false)
            {
                // 変更キャンセル
                // 前回入力値に戻す
                SetBfSection(_prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName);
                return (-1);
            }

            // 名称取得
            string bfSectionName = _stockMoveInputInitAcs.GetSectionName(bfSectionCode);
            if (bfSectionName != string.Empty)
            {
                // 内容を格納
                SetBfSection(bfSectionCode, bfSectionName);

                // 拠点が変わったら倉庫をクリア
                SetBfWarehouse(string.Empty, string.Empty);
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "出庫拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                // 前回入力値に戻す
                SetBfSection(_prevHeaderInfo.BfSectionCode, _prevHeaderInfo.BfSectionName);

                return (-1);
            }

            // 在庫・倉庫移動判別
            CheckStockMoveMode();

            // ステータスを返す
            return (0);
        }

        /// <summary>
        /// 出庫倉庫読み込み処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadBfWarehouse()
        {
            if (this.BfEnterWarehCode_tEdit.DataText.Trim() == "")
            {
                if (this.BfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0') != _prevHeaderInfo.BfWarehouseCode)
                {
                    // 出庫倉庫入力チェック
                    if (this.bfEnterwarehCodeCheck(this.BfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0')) == false)
                    {
                        // 変更キャンセル
                        // 前回入力値に戻す
                        SetBfWarehouse(_prevHeaderInfo.BfWarehouseCode, _prevHeaderInfo.BfWarehouseName);
                        return (-1);
                    }
                }

                // 出庫倉庫セット
                SetBfWarehouse(string.Empty, string.Empty);
                // 在庫・倉庫移動判別
                CheckStockMoveMode();
                // グリッドクリア
                ClearGrid();
                return 0;
            }

            // 拠点コード取得
            string bfSectionCode = this.BfSectionCode_tEdit.Text.Trim();
            if ( bfSectionCode == string.Empty )
            {
                // 出庫拠点コード未入力なら入庫拠点コード使用
                bfSectionCode = AfSectionCode_tEdit.Text.Trim();
            }
            if ( bfSectionCode == string.Empty )
            {
                //// 入庫も未入力なら担当者の所属拠点を使用
                //bfSectionCode = _belongSectionCode;                                                   //DEL 2009/06/22 不具合対応[13583]
                //入庫も未入力なら倉庫の管理拠点を使用
                bfSectionCode = this.GetWarehouseSection(this.BfEnterWarehCode_tEdit.Text.Trim());      //ADD 2009/06/22 不具合対応[13583]
            }

            // 倉庫コード取得
            string bfWarehouseCode = this.BfEnterWarehCode_tEdit.Text.Trim().PadLeft(4, '0');
            if (bfWarehouseCode == _prevHeaderInfo.BfWarehouseCode)
            {
                // 前回コードと同じ→何もしない
                return (0);
            }

            // 出庫倉庫入力チェック
            if (this.bfEnterwarehCodeCheck(bfWarehouseCode) == false)
            {
                // 変更キャンセル
                // 前回入力値に戻す
                SetBfWarehouse(_prevHeaderInfo.BfWarehouseCode, _prevHeaderInfo.BfWarehouseName);
                return (-1);
            }

            // 名称取得
            string bfWarehouseName = _stockMoveInputInitAcs.GetWarehouseName(bfWarehouseCode);
            if (bfWarehouseName != string.Empty)
            {
                // 内容を格納
                SetBfWarehouse(bfWarehouseCode, bfWarehouseName);
                // 拠点も反映
                SetBfSection(bfSectionCode, _stockMoveInputInitAcs.GetSectionName(bfSectionCode));
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "出庫倉庫が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                // 出庫倉庫セット
                SetBfWarehouse(_prevHeaderInfo.BfWarehouseCode, _prevHeaderInfo.BfWarehouseName);

                // グリッドクリア
                ClearGrid();

                return (-1);
            }

            // 在庫・倉庫移動判別
            CheckStockMoveMode();

            // ステータスを返す
            return (0);
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 拠点移動・倉庫移動の判断と表示
        /// </summary>
        private void CheckStockMoveMode()
        {
            // 担当者を取得
            string belongSectionCode;
            belongSectionCode = _belongSectionCode;

            // 出庫・入庫を比較
            string bfSection = this.BfSectionCode_tEdit.Text.Trim();
            string afSection = this.AfSectionCode_tEdit.Text.Trim();

            if ( this.BfSectionCode_tEdit.Text.Trim() == "" )
            {
                if ( this.AfSectionCode_tEdit.Text.Trim() == string.Empty )
                {
                    // 出庫なし・入庫なし　→　移動指示担当者の拠点の倉庫移動とみなす
                    bfSection = _belongSectionCode;
                    afSection = _belongSectionCode;
                }
                else
                {
                    // 出庫なし・入庫あり　→　倉庫移動とみなす
                    bfSection = afSection;
                }
            }
            else
            {
                if ( this.AfSectionCode_tEdit.Text.Trim() == string.Empty )
                {
                    // 出庫あり・入庫なし　→　倉庫移動とみなす
                    afSection = bfSection;
                }
                else
                {
                    // 出庫あり・入庫あり　→　入力値のままでＯＫ
                }
            }

            if ( bfSection == afSection )
            {
                this.StockMoveFormal_label.BackColor = Color.Orange;
                this.StockMoveFormal_label.Text = "倉庫移動";
            }
            else
            {
                this.StockMoveFormal_label.BackColor = Color.Navy;
                this.StockMoveFormal_label.Text = "在庫移動";
            }
        }

        # region [画面セット処理]
        /// <summary>
        /// 入庫倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetStockMvEmp( string code, string name )
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 内容を格納
            //StockMvEmpCode_tEdit.Text = code;
            //StockMvEmpName_tEdit.Text = name;
            //// 前回情報を更新
            //_prevHeaderInfo.StockMvEmpCd = code;
            //_prevHeaderInfo.StockMvEmpNm = name;

            // 内容を格納
            StockMvEmpName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.StockMvEmpNm = name;

            if (code == String.Empty)
            {
                StockMvEmpCode_tEdit.Text = code;
                _prevHeaderInfo.StockMvEmpCd = code;
            }
            else
            {
                StockMvEmpCode_tEdit.Text = code.PadLeft(4, '0');
                _prevHeaderInfo.StockMvEmpCd = code.PadLeft(4, '0');
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        /// <summary>
        /// 出庫拠点セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetBfSection( string code, string name )
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 内容を格納
            //BfSectionCode_tEdit.Text = code;
            //BfSectionName_tEdit.Text = name;
            //// 前回情報を更新
            //_prevHeaderInfo.BfSectionCode = code;
            //_prevHeaderInfo.BfSectionName = name;

            // 内容を格納
            BfSectionName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.BfSectionName = name;

            if (code == String.Empty)
            {
                BfSectionCode_tEdit.Text = code;
                _prevHeaderInfo.BfSectionCode = code;
            }
            else
            {
                BfSectionCode_tEdit.Text = code.PadLeft(2, '0');
                _prevHeaderInfo.BfSectionCode = code.PadLeft(2, '0');
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        /// <summary>
        /// 出庫倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetBfWarehouse( string code, string name )
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 内容を格納
            //BfEnterWarehCode_tEdit.Text = code;
            //BfEnterWarehName_tEdit.Text = name;
            //// 前回情報を更新
            //_prevHeaderInfo.BfWarehouseCode = code;
            //_prevHeaderInfo.BfWarehouseName = name;

            // 内容を格納
            BfEnterWarehName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.BfWarehouseName = name;

            if (code == String.Empty)
            {
                BfEnterWarehCode_tEdit.Text = code;
                _prevHeaderInfo.BfWarehouseCode = code;
            }
            else
            {
                BfEnterWarehCode_tEdit.Text = code.PadLeft(4, '0');
                _prevHeaderInfo.BfWarehouseCode = code.PadLeft(4, '0');
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        /// <summary>
        /// 入庫拠点セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetAfSection( string code, string name )
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 内容を格納
            //AfSectionCode_tEdit.Text = code;
            //AfSectionGuideNm_tEdit.Text = name;
            //// 前回情報を更新
            //_prevHeaderInfo.AfSectionCode = code;
            //_prevHeaderInfo.AfSectionName = name;

            // 内容を格納
            AfSectionGuideNm_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.AfSectionName = name;

            if (code == String.Empty)
            {
                AfSectionCode_tEdit.Text = code;
                _prevHeaderInfo.AfSectionCode = code;
            }
            else
            {
                AfSectionCode_tEdit.Text = code.PadLeft(2, '0');
                _prevHeaderInfo.AfSectionCode = code.PadLeft(2, '0');
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        /// <summary>
        /// 入庫倉庫セット処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void SetAfWarehouse( string code, string name )
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 内容を格納
            //AfEnterWarehCode_tEdit.Text = code;
            //AfEnterWarehName_tEdit.Text = name;
            //// 前回情報を更新
            //_prevHeaderInfo.AfWarehouseCode = code;
            //_prevHeaderInfo.AfWarehouseName = name;

            // 内容を格納
            AfEnterWarehName_tEdit.Text = name;
            // 前回情報を更新
            _prevHeaderInfo.AfWarehouseName = name;

            if (code == String.Empty)
            {
                AfEnterWarehCode_tEdit.Text = code;
                _prevHeaderInfo.AfWarehouseCode = code;
            }
            else
            {
                AfEnterWarehCode_tEdit.Text = code.PadLeft(4, '0');
                _prevHeaderInfo.AfWarehouseCode = code.PadLeft(4, '0');
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }
        # endregion
        # endregion ■ 読み込み処理 ■

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動データクラス→画面格納処理
        /// </summary>
        /// <param name="stockMoveHeader">在庫移動データオブジェクト</param>
        private void SetDisplay(StockMoveHeader stockMoveHeader)
        {
            // 画面表示処理（ヘッダ、フッタ情報／在庫移動データより）
            this.SetDisplayHeaderFooterInfo(stockMoveHeader);

            // 画面表示処理（移動金額合計情報）
            this.SetDisplayTotalPriceInfo();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        /// <summary>
        /// 画面表示処理（ヘッダ、フッタ情報／在庫移動データより）
        /// </summary>
        /// <param name="stockMoveHeader">在庫移動データオブジェクト</param>
        private void SetDisplayHeaderFooterInfo(StockMoveHeader stockMoveHeader)
        {
            if (stockMoveHeader == null) return;

            // 移動指示担当者コード
            this.StockMvEmpCode_tEdit.Text = stockMoveHeader.StockMvEmpCode.Trim();
            // 移動指示担当者名
            this.StockMvEmpName_tEdit.Text = stockMoveHeader.StockMvEmpName.Trim();
            // 出荷日
            this.SlipmentDay_tDateEdit.SetDateTime(stockMoveHeader.ShipmentScdlDay);
            // 入庫拠点コード
            this.AfSectionCode_tEdit.Text = stockMoveHeader.AfSectionCode.Trim();
            // 入庫拠点名
            this.AfSectionGuideNm_tEdit.Text = stockMoveHeader.AfSectionGuideName.Trim();
            // 入庫倉庫コード
            this.AfEnterWarehCode_tEdit.Text = stockMoveHeader.AfEnterWarehCode.Trim();
            // 入庫倉庫名
            this.AfEnterWarehName_tEdit.Text = stockMoveHeader.AfEnterWarehName.Trim();

            // 出庫拠点コード
            this.BfSectionCode_tEdit.Text = stockMoveHeader.BfSectionCode.Trim();
            // 出庫拠点名
            this.BfSectionName_tEdit.Text = stockMoveHeader.BfSectionGuideName.Trim();
            // 出庫倉庫コード
            this.BfEnterWarehCode_tEdit.Text = stockMoveHeader.BfEnterWarehCode.Trim();
            // 出庫倉庫名
            this.BfEnterWarehName_tEdit.Text = stockMoveHeader.BfEnterWarehName.Trim();

            // 伝票摘要
            this.Outline_tEdit.Text = stockMoveHeader.OutLine.Trim();
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        public bool CheckInputScreen()
        {
            string errMsg = "";

            try
            {
                // 移動指示担当者
                if (this.StockMvEmpCode_tEdit.DataText.Trim() == "")
                {
                    errMsg = "移動指示担当者を入力してください。";
                    this.StockMvEmpCode_tEdit.Focus();
                    return (false);
                }
                string employeeCode = this.StockMvEmpCode_tEdit.DataText.Trim();
                if (this._stockMoveInputInitAcs.GetEmployeeName(employeeCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.StockMvEmpCode_tEdit.Focus();
                    return (false);
                }
                // 出荷日
                if (this.SlipmentDay_tDateEdit.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "出荷日を入力してください。";
                    this.SlipmentDay_tDateEdit.Focus();
                    return (false);
                }

                // 出庫拠点
                if (this.BfSectionCode_tEdit.DataText.Trim() == "")
                {
                    errMsg = "出庫拠点を入力してください。";
                    this.BfSectionCode_tEdit.Focus();
                    return (false);
                }
                string sectionCode = this.BfSectionCode_tEdit.DataText.Trim();
                if (this._stockMoveInputInitAcs.GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.BfSectionCode_tEdit.Focus();
                    return (false);
                }

                DateTime targetDate;

                if (!this._stockMoveInputInitAcs.CheckHisTotalDayMonthly(sectionCode, this.SlipmentDay_tDateEdit.GetDateTime(), out targetDate))
                {
                    errMsg = "出荷日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                    this.SlipmentDay_tDateEdit.Focus();
                    return (false);
                }

                // 出庫倉庫
                if (this.BfEnterWarehCode_tEdit.DataText.Trim() == "")
                {
                    errMsg = "出庫倉庫を入力してください。";
                    this.BfEnterWarehCode_tEdit.Focus();
                    return (false);
                }
                string warehouseCode = this.BfEnterWarehCode_tEdit.DataText.Trim();
                if (this._stockMoveInputInitAcs.GetWarehouseName(warehouseCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.BfEnterWarehCode_tEdit.Focus();
                    return (false);
                }
                // 入庫拠点
                if (this.AfSectionCode_tEdit.DataText.Trim() == "")
                {
                    errMsg = "入庫拠点を入力してください。";
                    this.AfSectionCode_tEdit.Focus();
                    return (false);
                }
                sectionCode = this.AfSectionCode_tEdit.DataText.Trim();
                if (this._stockMoveInputInitAcs.GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.AfSectionCode_tEdit.Focus();
                    return (false);
                }
                // 入庫倉庫
                if (this.AfEnterWarehCode_tEdit.DataText.Trim() == "")
                {
                    errMsg = "入庫倉庫を入力してください。";
                    this.AfEnterWarehCode_tEdit.Focus();
                    return (false);
                }
                warehouseCode = this.AfEnterWarehCode_tEdit.DataText.Trim();
                if (this._stockMoveInputInitAcs.GetWarehouseName(warehouseCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.AfEnterWarehCode_tEdit.Focus();
                    return (false);
                }
                // 本社機能チェック
                if (!MainOfficeFuncCheck())
                {
                    errMsg = "他拠点の倉庫移動はできません。";
                    this.BfSectionCode_tEdit.Focus();
                    return (false);
                }
                // ---ADD 2009/06/04 --------------------------------------->>>>>
                if (this.BfEnterWarehCode_tEdit.Text.Trim() == this.AfEnterWarehCode_tEdit.Text.Trim())
                {
                    errMsg = "出庫倉庫と同じ倉庫は入力できません。";
                    this.AfEnterWarehCode_tEdit.Focus();
                    return false;
                }
                // ---ADD 2009/06/04 ---------------------------------------<<<<<

                // グリッド
                if (!this._stockMoveInput.CheckInputGrid(out errMsg))
                {
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    errMsg,
                    0,
                    MessageBoxButtons.OK);
                    changeFocusFooter(false);
                }
            }

            return (true);
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 移動データ登録前ヘッダ、フッタ入力情報チェック処理
        /// </summary>
        /// <returns>true:入力項目に問題なし false:入力項目に問題あり</returns>
        public Boolean HeaderFooterCheck()
        {
            // 移動指示担当者
            if (this.StockMvEmpCode_tEdit.Text.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "移動指示担当者が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 出荷日
            if (this.SlipmentDay_tDateEdit.GetDateTime() == new DateTime())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出荷日が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 入庫拠点
            //// 入庫拠点は必須入力ではありません。(拠点間移動の他に倉庫間移動が存在するため。)
            //// →必須入力に変更 2008.2.22
            if ( this.AfSectionCode_tEdit.Text.Trim() == "" )
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "入庫拠点が入力されていません。",
                    -1,
                    MessageBoxButtons.OK );

                return false;
            }

            // 入庫倉庫
            if (this.AfEnterWarehCode_tEdit.Text.Trim() == "")
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "入庫倉庫が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            // 備考
            // 移動は必須入力ではありません。

            // 入力に問題が無ければチェック通過
            return true;
        }

        /// <summary>
        /// 在庫管理全体設定マスタの情報による受託在庫利用チェック
        /// </summary>
        /// <returns>0:可 1:拠点間移動不可 2:倉庫移動不可</returns>
        public int TrustStockCheck()
        {
            // 倉庫移動の場合
            if (this.AfSectionCode_tEdit.Text.Trim() == "" || _stockMoveHeader.AfSectionCode.Trim() == _belongSectionCode.Trim())
            {
                // 利用可能な場合はチェックしない
                if (TrustStWhouMoveCd == 2)
                {
                    return 0;
                }
                else
                {
                    // 受託在庫が存在しているかチェック
                    for (int i = 0; i < _stockMoveDataTable.Count; i++)
                    {
                        if (_stockMoveDataTable[i].MovingTrustStock > 0)
                        {
                            return 2;
                        }
                    }
                }
            }
            // 拠点間移動の場合
            else
            {
                // 移動可能な場合はチェックしない
                if (TrustStSectMoveCd == 2)
                {
                    return 0;
                }
                else
                {
                    // 受託在庫が存在しているかチェック
                    for (int i = 0; i < _stockMoveDataTable.Count; i++)
                    {
                        if (_stockMoveDataTable[i].MovingTrustStock > 0)
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
        
        /// <summary>
        /// 入庫拠点入庫倉庫整合性チェック
        /// </summary>
        /// <returns></returns>
        public bool AfIntegrationCheck()
        {
            if (_stockMoveHeader.AfSectionCode.Trim() == "")
            {
                _stockMoveHeader.AfSectionCode = _belongSectionCode;
            }

            if (_stockMoveInputInitAcs.GetWarehouseName(_stockMoveHeader.AfSectionCode, _stockMoveHeader.AfEnterWarehCode) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 本社機能制限チェック
        /// </summary>
        /// <returns>True: 登録可能 False: 利用不可能</returns>
        public bool MainOfficeFuncCheck()
        {
            // 本社での倉庫移動は可能
            if (this.BfSectionCode_tEdit.Text.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim() &&
                this.AfSectionCode_tEdit.Text.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
            {
                return true;
            }

            // 両方ともから空白だった場合、倉庫移動と判断
            if (this.BfSectionCode_tEdit.Text.Trim() == "" && this.AfSectionCode_tEdit.Text.Trim() == "")
            {
                return true;
            }

            // 他拠点の倉庫移動は本社では利用できない
            if (this.BfSectionCode_tEdit.Text.Trim() == AfSectionCode_tEdit.Text.Trim())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 呼出伝票内の確定レコード、入荷レコードチェック処理
        /// </summary>
        /// <returns>True: 確定、入荷レコード有 False: 確定、入荷レコード無</returns>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public bool FixAndArrivalCheck()
        {
            _stockMoveInput.oldsupplierCd = -1; // ADD 2011/04/11
            ChangeGridEnabled(true);

            // 在庫検索ボタンを押下不能にする
            _stockMoveInput.StockSearchEnable(true);

            this.Outline_tEdit.Enabled = true;
            this.Outline_uButton.Enabled = true;
            this.uOptionSet_PrintOut.Enabled = true;

            //foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            //{
            //    // 一部でも確定済みや入荷済みがある場合は更新不可
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //if (row.ShipmentFixDay.Trim() != "" || row.ArrivalGoodsDay.Trim() != "")
            //    if (row.MoveStatus == 2 || row.MoveStatus == 9)
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    {
            //        TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_INFO,
            //                this.Name,
            //                "呼び出した伝票内に確定済レコード、もしくは入荷済レコードが\r\n" +
            //                "存在するため、修正できません。",
            //                -1,
            //                MessageBoxButtons.OK);

            //        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //        //_stockMoveInput.ultraGrid1.Enabled = false;
            //        ChangeGridEnabled(false);
            //        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

            //        // 在庫検索ボタンを押下不能にする
            //        _stockMoveInput.StockSearchEnable(false);

            //        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            //        this.Outline_tEdit.Enabled = false;
            //        this.Outline_uButton.Enabled = false;
            //        this.uOptionSet_PrintOut.Enabled = false;
            //        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            //        return false;
            //    }
            //    else
            //    {
            //        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //        //_stockMoveInput.ultraGrid1.Enabled = true;
            //        ChangeGridEnabled(true);
            //        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

            //        // 在庫検索ボタンを押下不能にする
            //        _stockMoveInput.StockSearchEnable(true);

            //        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            //        this.Outline_tEdit.Enabled = true;
            //        this.Outline_uButton.Enabled = true;
            //        this.uOptionSet_PrintOut.Enabled = true;
            //        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
            //    }
            //}
            return true;
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>

        // 2009.07.07 Add >>>
        /// <summary>
        /// 在庫移動形式取得
        /// </summary>
        /// <returns></returns>
        public int GetReadDataStockMoveFormal()
        {
            int stockMoveFormal = 0;
            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                if (!string.IsNullOrEmpty(row.GoodsNo.Trim()))
                {
                    stockMoveFormal = row.StockMoveFormal;
                    break;
                }
            }
            return stockMoveFormal;
        }
        // 2009.07.07 Add <<<
        
        public void SetRowDeleteEnable(bool param)
        {
            _stockMoveInput.StockSearchEnable(param);
        }

        /// <summary>
        /// グリッドEnabled制御処理
        /// </summary>
        /// <param name="enabledFlg">制御フラグ(True:修正可能 False:修正不可)</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void ChangeGridEnabled(bool enabledFlg)
        {
            UltraGridBand editBand = _stockMoveInput.ultraGrid1.DisplayLayout.Bands[0];

            // 修正可能
            if (enabledFlg == true)
            {
                editBand.Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.MakerGuideButtonColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BLCodeGuideButtonColumn.ColumnName].CellActivation = Activation.Disabled;
                //---ADD 2011/04/11----------------------------------------------------------->>>>>
                editBand.Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].CellActivation = Activation.AllowEdit;
                editBand.Columns[_stockMoveDataTable.SupplierCdGuideButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
                //---ADD 2011/04/11-----------------------------------------------------------<<<<<
                editBand.Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].CellActivation = Activation.AllowEdit;
                editBand.Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit;
                editBand.Columns[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].CellActivation = Activation.AllowEdit;

                editBand.Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BfShelfNoColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.AfShelfNoColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.BfAfterMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
                // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
                editBand.Columns[_stockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
                editBand.Columns[_stockMoveDataTable.AfAfterMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
                // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

                _stockMoveInput.ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            }
            // 修正不可
            else
            {
                foreach (UltraGridColumn column in editBand.Columns)
                {
                    column.CellActivation = Activation.Disabled;
                }

                _stockMoveInput.ultraGrid1.ActiveCell = null;
                _stockMoveInput.ultraGrid1.ActiveRow = null;
                _stockMoveInput.ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            }
        }

        /// <summary>
        /// グリッド制御初期化処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void ClearGridEnabled()
        {
            UltraGridBand editBand = _stockMoveInput.ultraGrid1.DisplayLayout.Bands[0];

            editBand.Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.MakerGuideButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.BLGoodsCodeColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.BLCodeGuideButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            editBand.Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.SupplierCdGuideButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            editBand.Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].CellActivation = Activation.AllowEdit;
            editBand.Columns[_stockMoveDataTable.ListPriceFlViewColumn.ColumnName].CellActivation = Activation.AllowEdit;

            editBand.Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.BfShelfNoColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.AfShelfNoColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.BfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.BfAfterMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------>>>>>
            editBand.Columns[_stockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
            editBand.Columns[_stockMoveDataTable.AfAfterMoveCountColumn.ColumnName].CellActivation = Activation.Disabled;
            // --- ADD 2014/04/09 T.Miyamoto ------------------------------<<<<<

            _stockMoveInput.ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 出庫倉庫入力チェック
        /// </summary>
        /// <returns></returns>
        public bool bfEnterwarehCodeCheck()
        {
            // グリッドの有効件数を確認し、存在するようであればリセット(チェックは更新モード時は行わない)
            if ( _stockMoveInput.GetGridValidCount() > 0 && _stockMoveHeader.BfEnterWarehCode != _prevHeaderInfo.BfWarehouseCode && _stockMoveInputInitAcs.RegistMode == 0 )
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "出庫倉庫を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                        "出庫倉庫を変更しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1 );

                if ( dialogResult == DialogResult.Yes )
                {
                    // クリアＯＫ
                    _stockMoveInput.Clear();
                    return true;
                }
                else
                {
                    // キャンセル
                    return false;
                }
            }
            else
            {
                // 変更していないor明細が無いのでＯＫ
                return true;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 出庫倉庫入力チェック
        /// </summary>
        /// <returns>True: チェックOK False: チェックNG</returns>
        private bool bfEnterwarehCodeCheck(string newBfWarehouseCode)
        {
            // グリッドの有効件数を確認し、存在するようであればリセット(チェックは更新モード時は行わない)
            if ( _stockMoveInput.GetGridValidCount() > 0 && newBfWarehouseCode != _prevHeaderInfo.BfWarehouseCode && _stockMoveInputInitAcs.RegistMode == 0 )
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "出庫倉庫を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                        "出庫倉庫を変更しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // クリアＯＫ
                    _stockMoveInput.Clear();
                    return true;
                }
                else
                {
                    // キャンセル
                    return false;
                }
            }
            else
            {
                // 変更していないor明細が無いのでＯＫ
                return true;
            }
        }

        /// <summary>
        /// 入庫倉庫入力チェック
        /// </summary>
        /// <returns>True: チェックOK False: チェックNG</returns>
        private bool afEnterwarehCodeCheck(string newAfWarehouseCode)
        {
            // グリッドの有効件数を確認し、存在するようであればリセット(チェックは更新モード時は行わない)
            if (_stockMoveInput.GetGridValidCount() > 0 && newAfWarehouseCode != _prevHeaderInfo.AfWarehouseCode && _stockMoveInputInitAcs.RegistMode == 0)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "入庫倉庫を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                        "入庫倉庫を変更しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // クリアＯＫ
                    _stockMoveInput.Clear();
                    return true;
                }
                else
                {
                    // キャンセル
                    return false;
                }
            }
            else
            {
                // 変更していないor明細が無いのでＯＫ
                return true;
            }
        }

        /// <summary>
        /// 出庫拠点入力チェック
        /// </summary>
        /// <returns>True: チェックOK(拠点セットして良い) False: チェックNG（拠点セットしてはダメ）</returns>
        public bool bfSectionCodeCheck(string newBfSectionCode)
        {
            // グリッドの有効件数を確認し、存在するようであればリセット(チェックは更新モード時は行わない)
            if ( _stockMoveInput.GetGridValidCount() > 0 && newBfSectionCode != _prevHeaderInfo.BfSectionCode && _stockMoveInputInitAcs.RegistMode == 0 )
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "出庫拠点を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                        "出庫拠点を変更しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // 明細クリア
                    _stockMoveInput.Clear();
                    return true;
                }
                else
                {
                    // キャンセル
                    return false;
                }
            }
            else
            {
                // 変更していないor明細が無いのでＯＫ
                return true;
            }
        }

        /// <summary>
        /// 入庫拠点入力チェック
        /// </summary>
        /// <returns>True: チェックOK(拠点セットして良い) False: チェックNG（拠点セットしてはダメ）</returns>
        public bool afSectionCodeCheck(string newAfSectionCode)
        {
            // グリッドの有効件数を確認し、存在するようであればリセット(チェックは更新モード時は行わない)
            if (_stockMoveInput.GetGridValidCount() > 0 && newAfSectionCode != _prevHeaderInfo.AfSectionCode && _stockMoveInputInitAcs.RegistMode == 0)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "入庫拠点を変更すると明細がリセットされます。" + "\r\n" + "\r\n" +
                        "入庫拠点を変更しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // 明細クリア
                    _stockMoveInput.Clear();
                    return true;
                }
                else
                {
                    // キャンセル
                    return false;
                }
            }
            else
            {
                // 変更していないor明細が無いのでＯＫ
                return true;
            }
        }

        /// <summary>
        /// ヘッダ、フッタ情報格納処理(画面より)
        /// </summary>
        public void SetHeaderFooterInfoFromDisplay()
        {
            // 移動指示担当者コード
            _stockMoveHeader.StockMvEmpCode = this.StockMvEmpCode_tEdit.Text;
            // 移動指示担当者名
            _stockMoveHeader.StockMvEmpName = this.StockMvEmpName_tEdit.Text;
            // 出荷日
            _stockMoveHeader.ShipmentScdlDay = this.SlipmentDay_tDateEdit.GetDateTime();
            // 入庫拠点コード
            _stockMoveHeader.AfSectionCode = this.AfSectionCode_tEdit.Text;
            // 入庫拠点名
            _stockMoveHeader.AfSectionGuideName = this.AfSectionGuideNm_tEdit.Text;
            // 入庫倉庫コード
            _stockMoveHeader.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text;
            // 入庫倉庫名称
            _stockMoveHeader.AfEnterWarehName = this.AfEnterWarehName_tEdit.Text;

            // 出庫拠点コード
            _stockMoveHeader.BfSectionCode = this.BfSectionCode_tEdit.Text;
            // 出庫拠点名
            _stockMoveHeader.BfSectionGuideName = this.BfSectionName_tEdit.Text;
            // 出庫倉庫コード
            _stockMoveHeader.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text;
            // 出庫倉庫名称
            _stockMoveHeader.BfEnterWarehName = this.BfEnterWarehName_tEdit.Text;
            // 伝票摘要
            _stockMoveHeader.OutLine = this.Outline_tEdit.Text;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // セット内容の補正
            if ( _stockMoveHeader.AfSectionCode == string.Empty )
            {
                if ( _stockMoveHeader.BfSectionCode == string.Empty )
                {
                    // 入庫拠点なし・出庫拠点なし　→　移動指示担当者の拠点の倉庫移動扱いで補正
                    _stockMoveHeader.AfSectionCode = _belongSectionCode;
                    _stockMoveHeader.AfSectionGuideName = _belongSectionName;
                    _stockMoveHeader.BfSectionCode = _belongSectionCode;
                    _stockMoveHeader.BfSectionGuideName = _belongSectionName;
                }
                else
                {
                    // 入庫拠点なし・出庫拠点あり　→　倉庫移動扱いで補正
                    _stockMoveHeader.AfSectionCode = _stockMoveHeader.BfSectionCode;
                    _stockMoveHeader.AfSectionGuideName = _stockMoveHeader.BfSectionGuideName;
                }
            }
            else
            {
                if ( _stockMoveHeader.BfSectionCode == string.Empty )
                {
                    // 入庫拠点あり・出庫拠点なし　→　倉庫移動扱いで補正
                    _stockMoveHeader.BfSectionCode = _stockMoveHeader.AfSectionCode;
                    _stockMoveHeader.BfSectionGuideName = _stockMoveHeader.AfSectionGuideName;
                }
                else
                {
                    // 入庫拠点あり・出庫拠点あり　→　入力値のままでＯＫ
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// 画面表示処理（在庫移動金額合計情報）
        /// </summary>
        public void SetDisplayTotalPriceInfo()
        {
            long totalPrice = 0;

            // 移動明細の合計金額を表示する。
            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                try
                {
                    // 単価を取得
                    double unitPrice = row.StockUnitPriceFl;
                    // 仕入在庫出荷数を取得
                    double movingSupliStock = row.MovingSupliStock;
                    //// 受託在庫出荷数を取得
                    //double movingTrustStock = row.MovingTrustStock;

                    // 合計に加算する。
                    double dblTotalPrice = unitPrice * movingSupliStock;
                    switch (this._stockMoveInputInitAcs.StockMngTtlSt.FractionProcCd)
                    {
                        case 1:
                            {
                                // 切り捨て
                                totalPrice += (long)(dblTotalPrice / 1);
                                break;
                            }
                        case 2:
                            {
                                // 四捨五入
                                totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                                break;
                            }
                        case 3:
                            {
                                // 切り上げ
                                if (dblTotalPrice % 1 == 0)
                                {
                                    totalPrice += (long)(dblTotalPrice);
                                }
                                else
                                {
                                    totalPrice += (long)((dblTotalPrice + 1) / 1);
                                }
                                break;
                            }
                    }
                }
                catch
                {
                    continue;
                }
            }
            this.AllMvPrice2_ultraLabel.Text = totalPrice.ToString("C");
        }

        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        public void SetDisplayTotalMoveingPrice()
        {
            long totalPrice = 0;

            // 移動明細の合計金額を表示する。
            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                //---ADD 2011/04/11-------------->>>>>
                if (row.GoodsNo != "")
                {
                //---ADD 2011/04/11--------------<<<<<
                    totalPrice += row.MovingPrice;
                }// ADD 2011/04/11
            }

            this.AllMvPrice2_ultraLabel.Text = totalPrice.ToString("C");
        }

        /// <summary>
        /// 移動伝票検索画面呼出処理
        /// </summary>
        public void GuideShow()
        {
            // 結果オブジェクト
            object retObj = null;

            _stockMoveSlipSearch = new MAZAI04120UD();

            // 在庫移動伝票検索画面表示
            //StockMoveSlipSearch.BelongSectionCode = _belongSectionCode;
            //StockMoveSlipSearch.BelongSectionName = _belongSectionName;
            _stockMoveSlipSearch.ShowGuide( this, out retObj );

            // 倉庫移動か拠点移動かを判断
            if (_stockMoveInputInitAcs.GuideSelected == true)
            {
                if (_stockMoveHeader.BfSectionCode.Trim() == _stockMoveHeader.AfSectionCode.Trim())
                {
                    this.StockMoveFormal_label.BackColor = Color.Orange;
                    this.StockMoveFormal_label.Text = "倉庫移動";
                }
                else
                {
                    this.StockMoveFormal_label.BackColor = Color.Navy;
                    this.StockMoveFormal_label.Text = "在庫移動";
                }

                this._retStockMoveWorkList = (ArrayList)retObj;
            }
        }

        /// <summary>
        /// ユーザー設定反映処理
        /// </summary>
        /// <param name="userSettingList">ユーザー設定情報</param>
        public void SetUserSetting(ArrayList userSettingList)
        {
            this._stockMoveInput.SetUserSetting(userSettingList);
        }

        /// <summary>
        /// ユーザー設定取得処理
        /// </summary>
        /// <param name="userSettingList">ユーザー設定情報</param>
        public void GetUserSetting(out ArrayList userSettingList)
        {
            this._stockMoveInput.GetUserSetting(out userSettingList);
        }

        // -------- ADD 2010/11/15 ---------------->>>>>
        /// <summary>
        /// グリッド情報XML保存
        /// </summary>
        public void SaveXmlData()
        {
            // グリッド情報XML保存
            this._stockMoveInput.SaveXmlData();
        }
        // -------- ADD 2010/11/15 ----------------<<<<<

        public bool CompareBeforeRetry()
        {
            // グリッド
            if (this._stockMoveInput.CheckGridBeforeRetry(this._retStockMoveWorkList) == false)
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// クローズ可能不可能判別処理
        /// </summary>
        /// <returns>true:入力内容有 false:入力内容無</returns>
        public bool CloseDataCheck()
        {
            // データテーブルが更新されたかどうかを判断
            if (_stockMoveInput.TableUpdateFlg == true)
            {
                return true;
            }

            // ヘッダ情報を確認

            // 移動指示担当者
            if (this.StockMvEmpCode_tEdit.Text != _stockMoveHeader.StockMvEmpCode)
            {
                return true;
            }

            // 出荷日
            if (this.SlipmentDay_tDateEdit.GetDateTime() != _stockMoveHeader.ShipmentScdlDay)
            {
                return true;
            }

            // 入庫拠点
            if (this.AfSectionCode_tEdit.Text != _stockMoveHeader.AfSectionCode)
            {
                return true;
            }

            // 入庫倉庫
            if (this.AfEnterWarehCode_tEdit.Text != _stockMoveHeader.AfEnterWarehCode)
            {
                return true;
            }

            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 本社機能時のチェック
            //if (_stockMoveInputInitAcs.MainOfficeFunc == 1)
            //{
            //    // 出庫拠点
            //    if (this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0') != _stockMoveHeader.BfSectionCode.Trim().PadLeft(2, '0'))
            //    {
            //        return true;
            //    }
            //}
            //// 拠点機能時のチェック
            //else
            //{
            //    // 出庫拠点
            //    if (this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0') != _belongSectionCode.Trim().PadLeft(2, '0'))
            //    {
            //        return true;
            //    }
            //}
            // 出庫拠点
            if (this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0') != _stockMoveHeader.BfSectionCode.Trim().PadLeft(2, '0'))
            {
                return true;
            }
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 出庫倉庫
            if (this.BfEnterWarehCode_tEdit.Text != _stockMoveHeader.BfEnterWarehCode)
            {
                return true;
            }

            // 移動伝票発行区分
            //if (this.radioButton1.Checked == true || this.radioButton2.Checked == true)
            //{
            //    return true;
            //}

            // グリッド情報を確認
            //foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            //{

            //    if (row.GoodsCode != "")
            //    //if (!row.IsNull(_stockMoveDetailDataTable.GoodsCodeColumn))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        /// <summary>
        /// 在庫移動入力正常終了後更新フラグのリセット処理
        /// </summary>
        public void SetTableUpdateFlg()
        {
            _stockMoveInput.TableUpdateFlg = false;
        }

        /// <summary>
        /// データテーブルビュー設定処理
        /// </summary>
        public void DataTableSettings()
        {
            //_stockMoveDataTable.DefaultView.RowFilter = "";
            _stockMoveInput.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;
            _stockMoveInput.Clear();
        }

        /// <summary>
        /// プリンタドライバの取得に失敗した場合のラジオボタン無効化処理
        /// </summary>
        public void CheckBoxEnableChange()
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //this.radioButton2.Checked = true;

            //this.radioButton1.Enabled = false;
            //this.radioButton2.Enabled = false;
            this.uOptionSet_PrintOut.Value = 1;
            this.uOptionSet_PrintOut.Enabled = false;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }

        # region ガイド系イベント

        /// <summary>
        /// 移動指示担当者ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAgentNameGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                //int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, LoginInfoAcquisition.Employee.BelongSectionCode, out employee);
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, string.Empty, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    SetStockMvEmp(employee.EmployeeCode.TrimEnd(), employee.Name.TrimEnd());

                    // 拠点変更イベント
                    GetBelongSection();
                    if (SectionChange != null)
                    {
                        SectionChange(this, new EventArgs());
                    }

                    // 次フォーカス
                    // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                    //_guideNextFocusControl.GetNextControl(StockMvEmpCode_tEdit).Focus();
                    this.SlipmentDay_tDateEdit.Focus();
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
        private void MoveOthSelectionGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.AfSectionCode_tEdit.DataText.Trim() != "")
                    {
                        // 入庫拠点入力チェック
                        if (this.afSectionCodeCheck(secInfoSet.SectionCode) == false)
                        {
                            // 変更キャンセル
                            return;
                        }
                    }

                    // 入庫拠点を変更した場合には入庫倉庫を削除する。
                    if (_prevHeaderInfo.AfSectionCode != secInfoSet.SectionCode.TrimEnd())
                    {
                        SetAfWarehouse(string.Empty, string.Empty);
                    }

                    // 結果セット
                    SetAfSection(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm.TrimEnd());

                    // 在庫移動・倉庫移動判定
                    CheckStockMoveMode();

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
        private void MoveOthWarehouseGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点コード取得
                // (※もし未入力ならば全拠点の倉庫を対象にする)
                string SectionCode = this.AfSectionCode_tEdit.Text;

                Warehouse warehouse;
                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.AfEnterWarehCode_tEdit.DataText.Trim() != "")
                    {
                        // 入庫倉庫入力チェック
                        if (this.afEnterwarehCodeCheck(warehouse.WarehouseCode) == false)
                        {
                            // 変更キャンセル
                            return;
                        }
                    }

                    // 結果セット
                    SetAfWarehouse(warehouse.WarehouseCode.Trim(), warehouse.WarehouseName.Trim());

                    //// 拠点にも反映
                    //SetAfSection(warehouse.SectionCode.TrimEnd(), _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode));      //DEL 2009/06/22 不具合対応[13583]
                    // ---ADD 2009/06/22 不具合対応[13583] ----------------------------------------->>>>>
                    if (SectionCode == string.Empty)
                    {
                        if (this.BfSectionCode_tEdit.Text.Trim() == string.Empty)
                        {
                            // 出庫拠点をセット
                            SetAfSection(warehouse.SectionCode.TrimEnd(), _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode));
                        }
                        else
                        {
                            // 入庫拠点と同じ値をセット
                            SetAfSection(this.BfSectionCode_tEdit.Text.Trim(), _stockMoveInputInitAcs.GetSectionName(this.BfSectionCode_tEdit.Text.Trim()));
                        }
                    }
                    // ---ADD 2009/06/22 不具合対応[13583] -----------------------------------------<<<<<

                    // 在庫移動・倉庫移動判定
                    CheckStockMoveMode();

                    // 次フォーカス
                    // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                    //_guideNextFocusControl.GetNextControl(AfEnterWarehCode_tEdit).Focus();
                    this._stockMoveInput.Focus();
                    // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
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
        private void BfSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点ガイド呼び出し
                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.BfSectionCode_tEdit.DataText.Trim() != "")
                    {
                        // 出庫拠点入力チェック
                        if (this.bfSectionCodeCheck(secInfoSet.SectionCode) == false)
                        {
                            // 変更キャンセル
                            return;
                        }
                    }

                    // 出庫拠点を変更した場合は出庫倉庫を削除する。
                    if (_prevHeaderInfo.BfSectionCode != secInfoSet.SectionCode.TrimEnd())
                    {
                        SetBfWarehouse(string.Empty, string.Empty);
                    }

                    // 結果セット
                    SetBfSection(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm.Trim());

                    // 在庫移動・倉庫移動の判定
                    CheckStockMoveMode();

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
        private void BfEnterWarehGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点コード取得
                string SectionCode = this.BfSectionCode_tEdit.Text;

                //if ( SectionCode.Trim() == string.Empty )
                //{
                //    if ( this.AfSectionCode_tEdit.Text.Trim() == string.Empty )
                //    {
                //        //// 入庫も未入力ならば、移動指示担当者の拠点
                //        //SectionCode = _belongSectionCode;
                //    }
                //    else
                //    {
                //        // 入庫が未入力でなければ、入庫の拠点
                //        SectionCode = this.AfSectionCode_tEdit.Text.Trim();
                //    }
                //}

                // 倉庫ガイド呼び出し
                Warehouse warehouse;
                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.BfEnterWarehCode_tEdit.DataText.Trim() != "")
                    {
                        // 出庫倉庫入力チェック
                        if (this.bfEnterwarehCodeCheck(warehouse.WarehouseCode) == false)
                        {
                            // 変更キャンセル
                            return;
                        }
                    }

                    // 結果セット
                    SetBfWarehouse(warehouse.WarehouseCode.Trim(), warehouse.WarehouseName.Trim());

                    if (SectionCode == string.Empty)
                    {
                        //// 出庫拠点をセット
                        //SetBfSection(warehouse.SectionCode, _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode));        //DEL 2009/06/22 不具合対応[13583]
                        // ---ADD 2009/06/22 不具合対応[13583] ----------------------------------------->>>>>
                        if (this.AfSectionCode_tEdit.Text.Trim() == string.Empty)
                        {
                            // 出庫拠点をセット
                            SetBfSection(warehouse.SectionCode.Trim(), _stockMoveInputInitAcs.GetSectionName(warehouse.SectionCode.Trim()));
                        }
                        else
                        {
                            // 入庫拠点と同じ値をセット
                            SetBfSection(this.AfSectionCode_tEdit.Text.Trim(), _stockMoveInputInitAcs.GetSectionName(this.AfSectionCode_tEdit.Text.Trim()));
                        }
                        // ---ADD 2009/06/22 不具合対応[13583] -----------------------------------------<<<<<
                    }

                    // 在庫移動・倉庫移動判定
                    CheckStockMoveMode();

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(BfEnterWarehCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 備考ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Outline_uButton_Click ( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 備考区分=105:移動伝票備考
                int noteGuideDivCode = 105;

                NoteGuidAcs noteGuidAcs = new NoteGuidAcs();

                NoteGuidBd noteGuidBd;
                int status = noteGuidAcs.ExecuteGuide(out noteGuidBd, LoginInfoAcquisition.EnterpriseCode, noteGuideDivCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Outline_tEdit.Text = noteGuidBd.NoteGuideName;

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(Outline_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
                    if ( !_controls[i].Visible ||  !_controls[i].Enabled )
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

        # region ■ ヘッダ情報構造体 ■
        /// <summary>
        /// ヘッダ情報構造体
        /// </summary>
        private struct HeaderInfo
        {
            /// <summary>指示担当者コード</summary>
            private string _stockMvEmpCd;
            /// <summary>指示担当者名称</summary>
            private string _stockMvEmpNm;
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
            public HeaderInfo( string stockMvEmpCd, string stockMvEmpNm, string bfSectionCode, string bfSectionName, string bfWarehouseCode, string bfWarehouseName, string afSectionCode, string afSectionName, string afWarehouseCode, string afWarehouseName )
            {
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

        /// <summary>
        /// 拠点名称取得処理
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
            int status = employeeAcs.Read( out employee, LoginInfoAcquisition.EnterpriseCode, StockMvEmpCode_tEdit.Text.Trim() );
            if ( status == 0 )
            {
                if (employee.LogicalDeleteCode == 0)
                {
                    _belongSectionCode = employee.BelongSectionCode;
                    _belongSectionName = employee.BelongSectionName;
                }
            }
            else
            {
                // 取得できなかったら更新しない
            }
        }

        private void SalesSlipGuide_uButton_Click(object sender, EventArgs e)
        {
            // 伝票ガイド呼出
            loadSlipGuide();
        }

        // ---ADD 2009/06/22 不具合対応[13583] ------------------->>>>>
        /// <summary>
        /// 倉庫の管理拠点取得
        /// </summary>
        /// <param name="warehouseCode">倉庫</param>
        /// <returns>管理拠点</returns>
        private string GetWarehouseSection(string warehouseCode)
        {
            ArrayList arrayList = null;
            int status = warehouseAcs.SearchAll(out arrayList, LoginInfoAcquisition.EnterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return string.Empty;
            }
            if (arrayList == null)
            {
                return string.Empty;
            }
            if (arrayList.Count == 0)
            {
                return string.Empty;
            }

            Warehouse warehouse = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                warehouse = (Warehouse)arrayList[i];
                if (warehouseCode.Trim().PadLeft(4, '0') == warehouse.WarehouseCode.Trim().PadLeft(4, '0'))
                {
                    return warehouse.SectionCode.Trim();
                }
            }
            return string.Empty;
        }
        // ---ADD 2009/06/22 不具合対応[13583] -------------------<<<<<

        // ---ADD 2010/11/15---------------->>>>>
        /// <summary>
        /// 新規入力時の保存実行後のフォーカスは、明細１行目の品番へ移動する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規入力時の保存実行後のフォーカスは、明細１行目の品番へ移動する。</br>br>
        /// <br>Programer  : 曹文傑</br>
        /// <br>Date       : 2010/11/15<br/>
        /// </remarks>
        public void ChangeFocusAfterSave()
        {
            this._stockMoveInput.SetFocusAfterSave();
        }

        /// <summary>
        /// 新規入力時の保存実行後クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規入力時の保存実行後クリア処理。</br>br>
        /// <br>Programer  : 曹文傑</br>
        /// <br>Date       : 2010/11/15<br/>
        /// <br>Update Note: 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
        /// </remarks>
        public void ClearAfterSave()
        {
            // グリッド初期化
            ClearGrid();

            // 備考を初期化
            this.Outline_tEdit.Text = "";
            this.Outline_uButton.Enabled = true;

            // 所属拠点を初期化
            _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName.Trim();

            // 前回ヘッダ情報初期化
            if (StockMvEmpCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.StockMvEmpCd = StockMvEmpCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.StockMvEmpCd = "";
            }
            _prevHeaderInfo.StockMvEmpNm = StockMvEmpName_tEdit.Text.TrimEnd();
            if (BfSectionCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.BfSectionCode = BfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            }
            else
            {
                _prevHeaderInfo.BfSectionCode = "";
            }
            _prevHeaderInfo.BfSectionName = BfSectionName_tEdit.Text.TrimEnd();
            if (BfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.BfWarehouseCode = BfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.BfWarehouseCode = "";
            }
            _prevHeaderInfo.BfWarehouseName = BfEnterWarehName_tEdit.Text.TrimEnd();
            if (AfSectionCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.AfSectionCode = AfSectionCode_tEdit.Text.TrimEnd().PadLeft(2, '0');
            }
            else
            {
                _prevHeaderInfo.AfSectionCode = "";
            }
            _prevHeaderInfo.AfSectionName = AfSectionGuideNm_tEdit.Text.TrimEnd();
            if (AfEnterWarehCode_tEdit.Text.Trim() != "")
            {
                _prevHeaderInfo.AfWarehouseCode = AfEnterWarehCode_tEdit.Text.TrimEnd().PadLeft(4, '0');
            }
            else
            {
                _prevHeaderInfo.AfWarehouseCode = "";
            }
            _prevHeaderInfo.AfWarehouseName = AfEnterWarehName_tEdit.Text.TrimEnd();
            // ---ADD 2010/12/09-------->>>>>
            // 前回ヘッダ情報保存
            this._prevStockMoveHeader.AfEnterWarehCode = _prevHeaderInfo.AfWarehouseCode;
            this._prevStockMoveHeader.AfSectionCode = _prevHeaderInfo.AfSectionCode;
            this._prevStockMoveHeader.BfEnterWarehCode = _prevHeaderInfo.BfWarehouseCode;
            this._prevStockMoveHeader.BfSectionCode = _prevHeaderInfo.BfSectionCode;
            this._prevStockMoveHeader.StockMvEmpCode = _prevHeaderInfo.StockMvEmpCd;
            this._prevStockMoveHeader.ShipmentScdlDay = this.SlipmentDay_tDateEdit.GetDateTime();
            // ---ADD 2010/12/09--------<<<<<
        }
        // ---ADD 2010/11/15----------------<<<<<

        /// <summary>
        /// 伝票区分を変更する時、移動伝票区分の制御を変更します
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票区分を変更する時、移動伝票区分の制御を変更します。</br>
        /// <br>Programer  : 朱俊成</br>
        /// <br>Date       : 2011/05/21<br/>
        public void SlipDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 入庫移動確定なし、出庫伝票
            if (1 != this._stockMoveInputInitAcs.StockMoveFixCode && 0 == this.SlipDiv_tComboEditor.SelectedIndex)
            {
                ultraLabel2.Visible = true;
                uOptionSet_PrintOut.Visible = true;
                this.UpdatePrintOutOption();
            }
            // 入庫移動確定なし、入庫伝票
            else if (1 != this._stockMoveInputInitAcs.StockMoveFixCode && 1 == this.SlipDiv_tComboEditor.SelectedIndex)
            {
                ultraLabel2.Visible = false;
                uOptionSet_PrintOut.Visible = false;
                this.uOptionSet_PrintOut.Value = 1;
            }
        }
    }
}
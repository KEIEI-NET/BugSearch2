using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 出力条件／出力先設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 出力条件／出力先設定UIフォームクラス</br>
    /// <br>Programmer  : 王増喜</br>
    /// <br>Date        : 2010/07/20</br>
    /// <br>Update Note : 2010/10/09 曹文傑</br>
    /// <br>            ・障害ID:15882 PM1010Fテキスト出力対応</br>
    /// </remarks>
    public partial class PMZAI04101UE : Form
    {
        #region プライベート変数
        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;

        /// <summary>出力形式</summary>
        private bool _excelFlg;

        /// <summary>企業コード</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>出力ファイル名</summary>
        private string _settingFileName = string.Empty;

        /// <summary>倉庫コードリスト</summary>
        private List<string> _warehouseCodeList = new List<string>();
        private string _preWarehouseCodeFrom = string.Empty;
        private string _preWareHouseCodeTo = string.Empty;

        /// <summary>棚番コードリスト</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>メーカーコードリスト</summary>
        private List<Int32> _makerCodeList = new List<Int32>();
        private string _preMakerCodeFrom = string.Empty;
        private string _preMakerCodeTo = string.Empty;

        /// <summary>BLコードリスト</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();
        private string _preBlGoodsCodeFrom = string.Empty;
        private string _preBlGoodsCodeTo = string.Empty;

        /// <summary>品番リスト</summary>
        private List<string> _goodsNoList = new List<string>();

        /// <summary>MAKHN09332A 倉庫</summary>
        private WarehouseAcs _warehouseAcs;

        /// <summary>MAKHN09112A)メーカー</summary>
        private MakerAcs _makerAcs;

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        // --- ADD 2010/10/09 ---------->>>>>
        # region Delegate
        /// <summary>
        /// データを出力
        /// </summary>
        /// <returns>出力結果</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>データを出力イベント</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<<<
        #endregion

        #region コンストラクタ
        /// <summary>
        /// 出力条件／出力先設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力条件／出力先設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMZAI04101UE()
        {
            InitializeComponent();
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        /// <summary>
        /// フォーム終了ステータス
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// 出力形式
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
        }

        /// <summary>
        /// 倉庫コード
        /// </summary>
        public List<string> WarehouseCodeList
        {
            get { return this._warehouseCodeList; }
            set { this._warehouseCodeList = value; }
        }

        /// <summary>
        /// 棚番
        /// </summary>
        public List<string> WarehouseShelfNoList
        {
            get { return this._warehouseShelfNoList; }
            set { this._warehouseShelfNoList = value; }
        }

        /// <summary>
        /// メーカーコード
        /// </summary>
        public List<Int32> MakerCodeList
        {
            get { return this._makerCodeList; }
            set { this._makerCodeList = value; }
        }

        /// <summary>
        /// BLコード
        /// </summary>
        public List<Int32> BlGoodsCodeList
        {
            get { return this._blGoodsCodeList; }
            set { this._blGoodsCodeList = value; }
        }

        /// <summary>
        /// 品番
        /// </summary>
        public List<string> GoodsNoList
        {
            get { return this._goodsNoList; }
            set { this._goodsNoList = value; }
        }
        #endregion

        #region イベント
        /// <summary>Form.Load イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : Form.Load がクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void PMZAI04101UE_Load(object sender, System.EventArgs e)
        {
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            _imageList16 = IconResourceManagement.ImageList16;

            this.uButton_WarehouseCd_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseCd_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerCd_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerCd_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BlGoodsCode_From.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BlGoodsCode_To.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_OutputFileName.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];

            ChangeFileName();
        }

        /// <summary>
        /// 倉庫ガイド開始ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 倉庫ガイド開始ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_WarehouseCd_From_Click(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status == 0)
            {
                this.tEdit_WarehouseCd_From.Text = warehouse.WarehouseCode.Trim();
                this._preWarehouseCodeFrom = warehouse.WarehouseCode.Trim();
                this.tEdit_WarehouseCd_To.Focus();
            }
        }

        /// <summary>
        /// 倉庫ガイド終了ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 倉庫ガイド開始ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_WarehouseCd_To_Click(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status == 0)
            {
                this.tEdit_WarehouseCd_To.Text = warehouse.WarehouseCode.Trim();
                this._preWareHouseCodeTo = warehouse.WarehouseCode.Trim();
                this.tEdit_WarehouseShelfNo_From.Focus();
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_MakerCd_From_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            if (status == 0)
            {
                this.tNedit_MakerCd_From.Text = makerUmnt.GoodsMakerCd.ToString();
                this._preMakerCodeFrom = makerUmnt.GoodsMakerCd.ToString();
                // フォーカス設定
                this.tNedit_MakerCd_To.Focus();
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_MakerCd_To_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
            if (status == 0)
            {
                this.tNedit_MakerCd_To.Text = makerUmnt.GoodsMakerCd.ToString();
                this._preMakerCodeTo = makerUmnt.GoodsMakerCd.ToString();
                // フォーカス設定
                this.tNedit_BlGoodsCode_From.Focus();
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : BLコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_BlGoodsCode_From_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status == 0)
            {
                this.tNedit_BlGoodsCode_From.Text = bLGoodsCdUmnt.BLGoodsCode.ToString();
                this._preBlGoodsCodeFrom = bLGoodsCdUmnt.BLGoodsCode.ToString();
                // フォーカス設定
                this.tNedit_BlGoodsCode_To.Focus();
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : BLコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_BlGoodsCode_To_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status == 0)
            {
                this.tNedit_BlGoodsCode_To.Text = bLGoodsCdUmnt.BLGoodsCode.ToString();
                this._preBlGoodsCodeTo = bLGoodsCdUmnt.BLGoodsCode.ToString();
                // フォーカス設定
                this.tEdit_GoodsNo_From.Focus();
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォーカス移動時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 gaofeng</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // 倉庫コードFrom
                case "tEdit_WarehouseCd_From":
                    {
                        string inputValue = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');

                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text.Trim()))
                        {
                            break;
                        }

                        Warehouse warehouse;
                        int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouse.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (String.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_WarehouseCd_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseCd_To;
                                        }
                                        break;
                                }
                            }

                            this._preWarehouseCodeFrom = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');
                            this.tEdit_WarehouseCd_From.Text = this.tEdit_WarehouseCd_From.Text.Trim().PadLeft(4, '0');
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする
                            this.tEdit_WarehouseCd_From.Text = this._preWarehouseCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // 倉庫コードTo
                case "tEdit_WarehouseCd_To":
                    {
                        string inputValue = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');

                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text.Trim()))
                        {
                            break;
                        }

                        Warehouse warehouse;
                        int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouse.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (String.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_WarehouseCd_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseShelfNo_From;
                                        }
                                        break;
                                }
                            }

                            this._preWareHouseCodeTo = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');
                            this.tEdit_WarehouseCd_To.Text = this.tEdit_WarehouseCd_To.Text.Trim().PadLeft(4, '0');
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする。
                            this.tEdit_WarehouseCd_To.Text = this._preWareHouseCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // メーカーFrom
                case "tNedit_MakerCd_From":
                    {
                        Int32 inputValue = this.tNedit_MakerCd_From.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        MakerUMnt makerUmnt;
                        int status = _makerAcs.Read(out makerUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_MakerCd_From.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_MakerCd_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_MakerCd_To;
                                        }
                                        break;
                                }
                            }

                            this._preMakerCodeFrom = this.tNedit_MakerCd_From.Text;
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカコード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする。
                            this.tNedit_MakerCd_From.Text = this._preMakerCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // メーカーTo
                case "tNedit_MakerCd_To":
                    {
                        Int32 inputValue = this.tNedit_MakerCd_To.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }
                        MakerUMnt makerUmnt;
                        int status = _makerAcs.Read(out makerUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_MakerCd_To.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_MakerCd_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BlGoodsCode_From;
                                        }
                                        break;
                                }
                            }

                            this._preMakerCodeTo = this.tNedit_MakerCd_To.Text;
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカコード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする。
                            this.tNedit_MakerCd_To.Text = this._preMakerCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // BLコードFrom
                case "tNedit_BlGoodsCode_From":
                    {
                        Int32 inputValue = this.tNedit_BlGoodsCode_From.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        BLGoodsCdUMnt blGoodsCdUmnt;
                        int status = _blGoodsCdAcs.Read(out blGoodsCdUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_BlGoodsCode_From.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_BlGoodsCode_From;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_BlGoodsCode_To;
                                        }
                                        break;
                                }
                            }

                            this._preBlGoodsCodeFrom = this.tNedit_BlGoodsCode_From.Text;
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BLコード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする。
                            this.tNedit_BlGoodsCode_From.Text = this._preBlGoodsCodeFrom;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;

                // BLコードTo
                case "tNedit_BlGoodsCode_To":
                    {
                        Int32 inputValue = this.tNedit_BlGoodsCode_To.GetInt();

                        if (inputValue == 0)
                        {
                            break;
                        }

                        BLGoodsCdUMnt blGoodsCdUmnt;
                        int status = _blGoodsCdAcs.Read(out blGoodsCdUmnt, this._enterpriseCode, inputValue);

                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUmnt.LogicalDeleteCode == 0)// ADD 2010/09/21
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tNedit_BlGoodsCode_To.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.uButton_BlGoodsCode_To;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_GoodsNo_From;
                                        }
                                        break;
                                }
                            }

                            this._preBlGoodsCodeTo = this.tNedit_BlGoodsCode_To.Text;
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "BLコード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードクリアする。
                            this.tNedit_BlGoodsCode_To.Text = this._preBlGoodsCodeTo;
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                case "tEdit_OutputFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_OutputFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = uButton_OK;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_OutputFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : キャンセルボタンクリック時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : OKボタンクリック時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        /// <br>UpdateNote  : 2010/10/09 曹文傑</br>
        /// <br>             ・障害ID:15882 PM1010Fテキスト出力対応</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region 入力チェック

            // 倉庫
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_WarehouseCd_From.Text.CompareTo(this.tEdit_WarehouseCd_To.Text) > 0)
            if (this.tEdit_WarehouseCd_To.Text != "" && (this.tEdit_WarehouseCd_From.Text.CompareTo(this.tEdit_WarehouseCd_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始倉庫の値が終了倉庫の値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 棚番
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_WarehouseShelfNo_From.Text.CompareTo(this.tEdit_WarehouseShelfNo_To.Text) > 0)
            if (this.tEdit_WarehouseShelfNo_To.Text != "" && (this.tEdit_WarehouseShelfNo_From.Text.CompareTo(this.tEdit_WarehouseShelfNo_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始棚番の値が終了棚番の値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // メーカー
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tNedit_MakerCd_From.GetInt() > this.tNedit_MakerCd_To.GetInt())
            if (this.tNedit_MakerCd_To.Text != "" && (this.tNedit_MakerCd_From.GetInt() > this.tNedit_MakerCd_To.GetInt()))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始メーカーの値が終了メーカーの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // BLコード
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tNedit_BlGoodsCode_From.GetInt() > this.tNedit_BlGoodsCode_To.GetInt())
            if (this.tNedit_BlGoodsCode_To.Text != "" && (this.tNedit_BlGoodsCode_From.GetInt() > this.tNedit_BlGoodsCode_To.GetInt()))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始BLコードの値が終了BLコードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 品番
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (this.tEdit_GoodsNo_From.Text.CompareTo(this.tEdit_GoodsNo_To.Text) > 0)
            if (this.tEdit_GoodsNo_To.Text != "" && (this.tEdit_GoodsNo_From.Text.CompareTo(this.tEdit_GoodsNo_To.Text) > 0))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始品番の値が終了品番の値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 出力ファイル名
            if (string.IsNullOrEmpty(this.tEdit_OutputFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出力ファイル名を設定してください。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            #endregion  // 入力チェック

            SetExtratConst();

            this.DResult = DialogResult.OK;
            // --- UPD 2010/10/09 ---------->>>>>
            //this.Close();
            bool outputRslt = true;
            if (this.OutputData != null)
            {
                outputRslt = this.OutputData();
            }
            if (outputRslt)
            {
                this.Close();
            }
            // --- UPD 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// ファイルダイアログ表示ボタンクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ファイルダイアログ表示ボタンクリック時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_OutputFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_OutputFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_OutputFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_OutputFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }
        #endregion // イベント

        #region プライベートメンバ
        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <remarks>
        /// <br>Note        : 抽出条件をセットします。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void SetExtratConst()
        {
            List<string> warehouseCodeList = new List<string>();
            List<string> warehouseShelfNoList = new List<string>();
            List<Int32> makerCodeList = new List<Int32>();
            List<Int32> blGoodsCodeList = new List<Int32>();
            List<string> goodsNoList = new List<string>();

            string selectConditionFrom = string.Empty;
            string selectConditionTo = string.Empty;

            Int32 intSelectConditionFrom;
            Int32 intSelectConditionTo;

            // 倉庫
            if (!string.IsNullOrEmpty(this.tEdit_WarehouseCd_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_WarehouseCd_To.Text))
            {
                selectConditionFrom = this.tEdit_WarehouseCd_From.Text;
                warehouseCodeList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_WarehouseCd_To.Text;
                warehouseCodeList.Add(selectConditionTo);
            }
            this.WarehouseCodeList = warehouseCodeList;

            // 棚番
            if (!string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo_To.Text))
            {
                selectConditionFrom = this.tEdit_WarehouseShelfNo_From.Text;
                warehouseShelfNoList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_WarehouseShelfNo_To.Text;
                warehouseShelfNoList.Add(selectConditionTo);
            }
            this.WarehouseShelfNoList = warehouseShelfNoList;

            // メーカー
            if (this.tNedit_MakerCd_From.GetInt() != 0
                || this.tNedit_MakerCd_To.GetInt() != 0)
            {
                intSelectConditionFrom = this.tNedit_MakerCd_From.GetInt();
                makerCodeList.Add(intSelectConditionFrom);

                intSelectConditionTo = this.tNedit_MakerCd_To.GetInt();
                makerCodeList.Add(intSelectConditionTo);
            }
            this.MakerCodeList = makerCodeList;

            // BLコード
            if (this.tNedit_BlGoodsCode_From.GetInt() != 0
                || this.tNedit_BlGoodsCode_To.GetInt() != 0)
            {
                intSelectConditionFrom = this.tNedit_BlGoodsCode_From.GetInt();
                blGoodsCodeList.Add(intSelectConditionFrom);

                intSelectConditionTo = this.tNedit_BlGoodsCode_To.GetInt();
                blGoodsCodeList.Add(intSelectConditionTo);
            }
            this.BlGoodsCodeList = blGoodsCodeList;

            // 品番
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo_From.Text)
                || !string.IsNullOrEmpty(this.tEdit_GoodsNo_To.Text))
            {
                selectConditionFrom = this.tEdit_GoodsNo_From.Text;
                goodsNoList.Add(selectConditionFrom);

                selectConditionTo = this.tEdit_GoodsNo_To.Text;
                goodsNoList.Add(selectConditionTo);
            }
            this.GoodsNoList = goodsNoList;

            // 出力先ファイル名
            this.SettingFileName = this.tEdit_OutputFileName.Text;
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 出力ファイル名変更処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void ChangeFileName()
        {
            PMZAI04101UC userSettingForm = new PMZAI04101UC();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.AnalysisTextSettingAcs.Deserialize();

            fileName = userSettingForm.AnalysisTextSettingAcs.StockFileNameValue;

            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (_excelFlg)
                {
                    // 拡張子をXLSにする
                    fileName += ".xls";
                }
                else
                {
                    // 拡張子をCSVにする
                    fileName += ".csv";
                }
            }
            this.tEdit_OutputFileName.Text = fileName;
        }
        #endregion // プライベートメンバ
    }
}

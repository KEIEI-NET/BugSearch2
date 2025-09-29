//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 商品在庫マスタ
// プログラム概要   : 商品在庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : caohh
// 修 正 日  2011/08/02  修正内容 : NSユーザー改良要望一覧連番265の対応
//----------------------------------------------------------------------------//
// 管理番号  2013/01/16配信分 作成担当 : zhangy3
// 修 正 日  2012/12/01  　　 修正内容 : 障害報告#33231 商品在庫マスタ
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品在庫マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 連番265 商品在庫マスタ画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>Update Note: 2012/12/01 zhangy3　</br>
    /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
    /// </remarks>
    public partial class PMKHN09380UD : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09380UD()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._goodsStockInputConstructionAcs = new GoodsStockInputConstructionAcs1();

            this.tComboEditor1.SelectedIndex = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this.ul_GoodsNoMaker.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[0] == 1;
            this.ul_GoodsInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[1] == 1;
            this.ul_PriceInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[2] == 1;
            this.ul_UnitPrice.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[3] == 1;
            this.ul_StockInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[4] == 1;
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            radioBtnLst.Value = this._goodsStockInputConstructionAcs.KeepOnInfo[5];
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<

            this._saveInfoDiv = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this._keepOnInfo = this._goodsStockInputConstructionAcs.KeepOnInfo;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private int _saveInfoDiv;  // 保存前情報区分
        private List<int> _keepOnInfo;　// 保存前情報保持
        private GoodsStockInputConstructionAcs1 _goodsStockInputConstructionAcs = null;
        # endregion

        # region Properties
        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        /// <summary>保存前情報区分プロパティ</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }
        /// <summary>保存前情報保持プロパティ</summary>
        public List<int> KeepOnInfo
        {
            get { return this._keepOnInfo; }
            set { this._keepOnInfo = value; }
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 連番265 ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// </remarks>
        private void PMKHN09380UD_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            this.tComboEditor1.SelectedIndex = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this.ul_GoodsNoMaker.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[0] == 1;
            this.ul_GoodsInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[1] == 1;
            this.ul_PriceInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[2] == 1;
            this.ul_UnitPrice.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[3] == 1;
            this.ul_StockInfo.Checked = this._goodsStockInputConstructionAcs.KeepOnInfo[4] == 1;

            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            this.radioBtnLst.Value = this._goodsStockInputConstructionAcs.KeepOnInfo[5];
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
            this._saveInfoDiv = this._goodsStockInputConstructionAcs.SaveInfoDiv;
            this._keepOnInfo = this._goodsStockInputConstructionAcs.KeepOnInfo;
        }

        /// <summary>
        /// tComboEditor1_ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 連番265 コンボボックスの値が変更されたときに発生します。</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// </remarks>
        private void tComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            //「0:クリアしない」場合
            if (this.tComboEditor1.SelectedIndex == 0) 
            {
                this.ul_GoodsNoMaker.Enabled = false;
                this.ul_GoodsInfo.Enabled = false;
                this.ul_PriceInfo.Enabled = false;
                this.ul_UnitPrice.Enabled = false;
                this.ul_StockInfo.Enabled = false;
            }
            //「1:クリアする」場合
            else if (this.tComboEditor1.SelectedIndex == 1) 
            {
                this.ul_GoodsNoMaker.Enabled = true;
                this.ul_GoodsInfo.Enabled = true;
                this.ul_PriceInfo.Enabled = true;
                this.ul_UnitPrice.Enabled = true;
                this.ul_StockInfo.Enabled = true;
            }
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 連番265 ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._keepOnInfo = new List<int>();
            //for (int index = 0; index < 5; index++) //Del 2012/12/01 zhangy3 for Redmine#33231
            for (int index = 0; index < 6; index++) //Add 2012/12/01 zhangy3 for Redmine#33231
            {
                this._keepOnInfo.Add(0);
            }

            //「0:クリアしない」場合
            if (this.tComboEditor1.SelectedIndex == 0)
            {
                this._saveInfoDiv = 0;  
            }
            //「0:クリアする」場合
            else
            {
                this._saveInfoDiv = 1;
                // 品番・メーカー
                if (this.ul_GoodsNoMaker.Checked)
                {
                    this._keepOnInfo[0] = 1;
                }
                // 商品情報
                if (this.ul_GoodsInfo.Checked)
                {
                    this._keepOnInfo[1] = 1;
                }
                // 価格情報
                if (this.ul_PriceInfo.Checked) 
                {
                    this._keepOnInfo[2] = 1;
                }
                // 単品売価
                if (this.ul_UnitPrice.Checked) 
                {
                    this._keepOnInfo[3] = 1;
                }
                // 在庫情報
                if (this.ul_StockInfo.Checked) 
                {
                    this._keepOnInfo[4] = 1;
                }
            }
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            this._keepOnInfo[5] = Convert.ToInt32(radioBtnLst.Value);
            // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
            this._goodsStockInputConstructionAcs.SaveInfoDiv = this._saveInfoDiv;
            this._goodsStockInputConstructionAcs.KeepOnInfo = this._keepOnInfo;
            this._goodsStockInputConstructionAcs.Serialize();
        }
        # endregion
    }
}
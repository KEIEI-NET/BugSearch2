//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品マスタ更新処理
//                  :   PMKHN09670U.EXE
// Name Space       :   Broadleaf.Windows.Forms
// Programmer       :   許雁波
// Date             :   2011/07/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   機能追加：ログ出力
// Programmer       :   周雨
// Date             :   2011/08/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   案件一覧 連番 1029でのテスト不具合について
// Programmer       :   周雨
// Date             :   2011/09/16
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   案件一覧 連番 1029でのテスト不具合について
// Programmer       :   王飛３
// Date             :   2011/09/16
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   価格更新区分追加の対応
// Programmer       :   yangmj
// Date             :   2012/06/12
//----------------------------------------------------------------------
// Update Note      :   層別更新処理変更の対応
// Programmer       :   yangmj
// Date             :   2012/06/26
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品マスタ更新処理ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ更新を行うＵＩフォームクラスです。</br>
    /// <br>Programmer : 許雁波</br>
    /// <br>Date       : 2011.07.22</br>
    /// <br>Update Note: 連番1029 機能追加：ログ出力</br>
    /// <br>Programmer : 周雨</br>
    /// <br>Date       : 2011/08/22</br>
    /// <br>Update Note: 案件一覧 連番 1029でのテスト不具合について</br>
    /// <br>Programmer : 周雨</br>
    /// <br>Date       : 2011/09/16</br>
    /// <br>Update Note: 案件一覧 連番 1029でのテスト不具合について</br>
    /// <br>Programmer : 王飛３</br>
    /// <br>Date       : 2011/09/16</br>
    /// <br>Update Note: 価格更新区分追加の対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br>Update Note: 層別更新処理変更の対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/26</br>
    /// </remarks>
    public partial class PMKHN09670U : Form
    {
        /// <summary>商品アクセスクラス</summary>
        private GoodsAcs _goodsAcs;
        /// <summary>メーカーアクセスクラス</summary>
        private MakerAcs _makerAcs;
        /// <summary>ＢＬ商品コード検索ガイド</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>中分類検索ガイド</summary>
        private GoodsGroupUAcs _goodsGroupUAcs;
        /// <summary>商品マスタ更新処理アクセスクラス</summary>
        private GoodsUAcs _goodsMngAcs;
        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null; 
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        //-------------- ADD 2011/08/22 --------------------- >>>>>
        /// <summary>メーカー</summary>
        private MakerUMnt _maker;
        /// <summary>中分類</summary>
        private GoodsGroupU _goodsGroupU;
        /// <summary>BLコード</summary>
        private BLGoodsCdUMnt _blGoodsCdUMnt;
        //-------------- ADD 2011/08/22 --------------------- <<<<<
        #region 初期設定処理
        /// <summary>
        /// 商品マスタ更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品マスタ更新処理の新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/23</br>
        /// <br>Update Note: 連番1029 機能追加：ログ出力</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/08/22</br>
        /// </remarks>
        public PMKHN09670U()
        {
            InitializeComponent();
            ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- >>>>>
            if (_goodsMngAcs == null)
                _goodsMngAcs = new GoodsUAcs();
            //メーカー
            if (_maker == null)
                _maker = new MakerUMnt();
            //中分類
            if (_goodsGroupU == null)
                _goodsGroupU = new GoodsGroupU();
            //BLコード
            if (_blGoodsCdUMnt == null)
                _blGoodsCdUMnt = new BLGoodsCdUMnt();
            // --------------- ADD 2011/08/22 機能追加：ログ出力 -------------- <<<<<
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/23</br>
        /// <br>Update Note: 連番1029 機能追加：ログ出力</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/08/22</br>
        /// <br>Update Note: 案件一覧 連番 1029でのテスト不具合について FOR redmine #25232</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/09/16</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 層別更新処理変更の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/26</br>
        /// </remarks>
        private void PMKHN09670U_Load(object sender, EventArgs e)
        {
            this._goodsMngAcs.Write("起動", "起動", "");   // ADD 2011/08/22 機能追加：ログ出力
            _goodsAcs = new GoodsAcs();
            _blGoodsCdAcs = new BLGoodsCdAcs();
            _goodsGroupUAcs = new GoodsGroupUAcs();
            _makerAcs = new MakerAcs();

            this.Name_tComboEditor.Items.Clear();
            /* --- DEL 2011/09/16 ----------------- >>>>>
            this.Name_tComboEditor.Items.Add(0, "する");
            this.Name_tComboEditor.Items.Add(1, "しない");
            --- DEL 2011/09/16 ----------------- >>>>> */
            // --- ADD 2011/09/16 ----------------- >>>>>
            this.Name_tComboEditor.Items.Add(0, "しない");
            this.Name_tComboEditor.Items.Add(1, "する");
            // --- ADD 2011/09/16 ----------------- <<<<<

            this.Rate_tComboEditor.Items.Clear();
            /* --- DEL 2011/09/16 ----------------- >>>>>
            this.Rate_tComboEditor.Items.Add(0, "する");
            this.Rate_tComboEditor.Items.Add(1, "しない");
            --- DEL 2011/09/16 ----------------- >>>>> */
            // --- ADD 2011/09/16 ----------------- >>>>>
            this.Rate_tComboEditor.Items.Add(0, "しない");
            //this.Rate_tComboEditor.Items.Add(1, "する");// DEL yangmj 2012/06/26 層別更新処理変更
            //----- ADD yangmj 2012/06/26 層別更新処理変更 ------>>>>>
            this.Rate_tComboEditor.Items.Add(1, "する（提供未設定分は更新無）");
            this.Rate_tComboEditor.Items.Add(2, "する（無条件更新）");
            //----- ADD yangmj 2012/06/26 層別更新処理変更 ------<<<<<
            // --- ADD 2011/09/16 ----------------- <<<<<

            this.BLCode_tComboEditor.Items.Clear();
            /* --- DEL 2011/09/16 ----------------- >>>>>
            this.BLCode_tComboEditor.Items.Add(0, "する");
            this.BLCode_tComboEditor.Items.Add(1, "しない");
            --- DEL 2011/09/16 ----------------- >>>>> */
            // --- ADD 2011/09/16 ----------------- >>>>>
            this.BLCode_tComboEditor.Items.Add(0, "しない");
            this.BLCode_tComboEditor.Items.Add(1, "する");
            // --- ADD 2011/09/16 ----------------- <<<<<

            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            this.Price_tComboEditor.Items.Clear();
            this.Price_tComboEditor.Items.Add(0, "しない");
            this.Price_tComboEditor.Items.Add(1, "する");
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

            /* --- DEL 2011/09/16 ----------------- >>>>>
            this.Name_tComboEditor.SelectedIndex = 1;
            this.Rate_tComboEditor.SelectedIndex = 1;
            this.BLCode_tComboEditor.SelectedIndex = 1;
            --- DEL 2011/09/16 ----------------- >>>>> */
            // --- ADD 2011/09/16 ----------------- >>>>>
            this.Name_tComboEditor.SelectedIndex = 0;
            this.Rate_tComboEditor.SelectedIndex = 0;
            this.BLCode_tComboEditor.SelectedIndex = 0;
            // --- ADD 2011/09/16 ----------------- <<<<<

            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            this.Price_tComboEditor.SelectedIndex = 0;
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

            this._imageList16 = IconResourceManagement.ImageList16;

            this.MakerGuide_Button.ImageList = this._imageList16;
            this.MGroupGuide_Button.ImageList = this._imageList16;
            this.BLGoodsCodeGuide_Button.ImageList = this._imageList16;

            this.MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.MGroupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.BLGoodsCodeGuide_Button.Appearance.Image = Size16_Index.STAR1;
            
        }
        #endregion

        #region ツールバークリックイベント
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 連番1029 機能追加：ログ出力</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/08/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case "Btn_Close":
                    {
                        this._goodsMngAcs.Write("終了", "終了", "");   // ADD 2011/08/22 機能追加：ログ出力

                        // 終了処理
                        Close();
                        break;
                    }
                //更新
                case "Btn_Update":
                    {

                        //_goodsAcs
                        #region ●抽出条件チェック
                        if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, 
                                "メーカーを入力してください。", -1, MessageBoxButtons.OK);
                            // ----------------- ADD 2011/08/22 ------------------ >>>>>
                            if (this._maker.GoodsMakerCd != 0)
                            {
                                this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.Text = "";
                            }
                            this.MakerCode_uLabel.Text = this._maker.MakerName;
                            // ----------------- ADD 2011/08/22 ------------------ <<<<<
                            this.tNedit_GoodsMakerCd.Focus();
                            return;
                        }
                        /* --- DEL 2011/09/16 ------------------- >>>>>
                        if ((int)this.Name_tComboEditor.Value == 1 && 
                            (int)this.Rate_tComboEditor.Value == 1 &&
                            ((int)this.BLCode_tComboEditor.Value == 1))
                        --- DEL 2011/09/16 ---------------------- <<<<<*/
                        // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                        //// --- ADD 2011/09/16 ------------------>>>>>
                        //if ((int)this.Name_tComboEditor.Value == 0 &&
                        //    (int)this.Rate_tComboEditor.Value == 0 &&
                        //    ((int)this.BLCode_tComboEditor.Value == 0))
                        //// --- ADD 2011/09/16 ------------------<<<<<
                        // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                        if ((int)this.Name_tComboEditor.Value == 0 &&
                            (int)this.Rate_tComboEditor.Value == 0 &&
                            (int)this.BLCode_tComboEditor.Value == 0 &&
                            ((int)this.Price_tComboEditor.Value == 0))
                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                        {
                            /* ---------------- DEL 2011/08/22 ----------------------- >>>>>
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                "少なくとも一つの「する」をえらんでください。", -1, MessageBoxButtons.OK);
                            ------------------ DEL 2011/08/22 ----------------------- <<<<<*/
                            // --------------- ADD 2011/08/22 ----------------------- >>>>>
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                "いずれかの更新区分を設定して下さい。", -1, MessageBoxButtons.OK);
                            this.Name_tComboEditor.Focus();
                            // --------------- ADD 2011/08/22 ----------------------- <<<<<
                            return;
                        }
                        #endregion

                        #region ●抽出条件設定
                        //-----------------------------------------------------------------------------
                        // 抽出条件設定
                        //-----------------------------------------------------------------------------
                        //this._goodsMngAcs = new GoodsUAcs();   // DEL 2011/08/22 機能追加：ログ出力
                        GoodsUpdate goodsUpdate = new GoodsUpdate();
                        goodsUpdate.EnterpriseCode = this._enterpriseCode;
                        goodsUpdate.GoodsNameUpdateDivCd = (int)this.Name_tComboEditor.Value;
                        goodsUpdate.RateRankUpdateDivCd = (int)this.Rate_tComboEditor.Value;
                        goodsUpdate.BLCodeUpdateDivCd = (int)this.BLCode_tComboEditor.Value;
                        goodsUpdate.PriceUpdateDivCd = (int)this.Price_tComboEditor.Value; // ADD yangmj 2012/06/12 価格更新区分追加
                        goodsUpdate.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        goodsUpdate.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                        goodsUpdate.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        #endregion

                        //共通処理中画面生成
                        SFCMN00299CA processingDialog = new SFCMN00299CA();
                        processingDialog.DispCancelButton = false;
                        processingDialog.Title = "更新処理";
                        processingDialog.Message = "現在、データ抽出、更新中です…";
                        processingDialog.Show((Form)this.Parent); 

                        int updCnt = 0;
                        int status = this._goodsMngAcs.Update(out updCnt, goodsUpdate);
                        // --------------------ADD 2011/08/22 機能追加：ログ出力 ------------------------>>>>>
                        string logDataMessage = string.Empty;
                        if (goodsUpdate.GoodsMakerCd > 0)
                            logDataMessage += "メーカ：" + goodsUpdate.GoodsMakerCd;
                        if (goodsUpdate.GoodsMGroup > 0)
                            logDataMessage += " 中分類：" + goodsUpdate.GoodsMGroup;
                        if (goodsUpdate.BLGoodsCode > 0)
                            logDataMessage += " BLコード：" + goodsUpdate.BLGoodsCode;
                        this._goodsMngAcs.Write("商品マスタ更新", logDataMessage + " より、商品マスタには、" + updCnt.ToString() + "件を更新しました。", "");
                        // --------------------ADD 2011/08/22 機能追加：ログ出力 ------------------------<<<<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.UpdateCountLabel.Text = updCnt.ToString();
                        }
                        else if (status == 1)
                        {
                            processingDialog.Close();
                            this.UpdateCountLabel.Text = "0";
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            "処理対象が2万件を超えました、条件を変更して再度処理を行ってください", -1, MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            this.UpdateCountLabel.Text = "0";
                        }
                        //共通処理中画面閉じる
                        processingDialog.Close();
                        // --- 王飛３ ADD 2011/09/16 ------------------>>>>>
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                       "商品マスタ更新処理が終了しました。", 0, MessageBoxButtons.OK);
                        // --- 王飛３ ADD 2011/09/16 ------------------<<<<<

                        break;
                    }
            }
        }
        #endregion

         /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // ガイド起動
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
                if (status != 0) return;
                if (maker.GoodsMakerCd < 1000)
                {
                    // 警告を出す
                    TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "純正メーカーは選択できません。",
                              -1,
                              MessageBoxButtons.OK);
                    // ----------------- ADD 2011/08/22 ------------------ >>>>>
                    if (this._maker.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd.Text = "";
                    }
                    this.MakerCode_uLabel.Text = this._maker.MakerName;
                    // ----------------- ADD 2011/08/22 ------------------ <<<<<
                    this.tNedit_GoodsMakerCd.Focus();  // ADD 2011/09/16
                    return;
                }
                this.tNedit_GoodsMakerCd.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_uLabel.Text = maker.MakerName;
                this._maker = maker;  // ADD 2011/08/22
                this.tNedit_GoodsMGroup.Focus();  // ADD 2011/09/16
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: ＢＬコードガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;
            //this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsFullName;   // DEL 2011/09/16
            this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;   // ADD 2011/09/16
            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
            // --- ADD 2011/09/16 ------------- >>>>>
            if (blGoodsCdUMnt.BLGoodsCode > 0)
            {
                this.Name_tComboEditor.Focus();
            }
            else 
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            // --- ADD 2011/09/16 ------------- <<<<<
            this._blGoodsCdUMnt = blGoodsCdUMnt;  // ADD 2011/08/22
        }

        /// <summary>
        /// 中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 中分類ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;
            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
            if (status != 0) return;
            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
            // --- ADD 2011/09/16 ------------- >>>>>
            if (goodsGroupU.GoodsMGroup > 0)
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            else
            {
                this.tNedit_GoodsMGroup.Focus();
            }
            // --- ADD 2011/09/16 ------------- <<<<<
            this._goodsGroupU = goodsGroupU;  // ADD 2011/08/22
        }

        /// <summary>
        /// tArrowKeyControl1チェンジフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォーカスが遷移したタイミングで発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd":
                    {
                        if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                        {
                            this.MakerCode_uLabel.Text = "";
                            this._maker = new MakerUMnt();   // 王飛３ ADD 2011/09/16
                            return;
                        }
                        if (this.tNedit_GoodsMakerCd.GetInt() < 1000)
                        {
                            // 警告を出す
                            TMsgDisp.Show(
                                      this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "純正メーカーは選択できません。",
                                      -1,
                                      MessageBoxButtons.OK);
                            /* ----------------- DEL 2011/08/22 ------------------ >>>>>
                            this.MakerCode_tNedit.Text = "";
                            this.MakerCode_uLabel.Text = "";
                            -------------------- DEL 2011/08/22 ------------------ <<<<<*/
                            // ----------------- ADD 2011/08/22 ------------------ >>>>>
                            if (this._maker.GoodsMakerCd != 0)
                            {
                                this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.Text = "";
                            }
                            this.MakerCode_uLabel.Text = this._maker.MakerName;
                            // ----------------- ADD 2011/08/22 ------------------ <<<<<
                            e.NextCtrl = e.PrevCtrl;
                            this.tNedit_GoodsMakerCd.Focus(); // ADD 2011/08/22
                            return;
                        }
                        try
                        {
                            MakerUMnt maker;

                            // コード名称の取得
                            int status = this._makerAcs.Read(out maker, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MakerCode_uLabel.Text = maker.MakerName;
                                this._maker = maker;  // ADD 2011/08/22
                            }
                            else
                            {
                                // 警告を出す
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "入力されたメーカーコードは存在しません。",
                                          -1,
                                          MessageBoxButtons.OK);
                                /* ----------------- DEL 2011/08/22 ------------------ >>>>>
                                this.MakerCode_tNedit.Text = "";
                                this.MakerCode_uLabel.Text = "";
                                -------------------- DEL 2011/08/22 ------------------ <<<<<*/
                                // ----------------- ADD 2011/08/22 ------------------ >>>>>
                                if (this._maker.GoodsMakerCd != 0)
                                {
                                    this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Text = "";
                                }
                                this.MakerCode_uLabel.Text = this._maker.MakerName;
                                // ----------------- ADD 2011/08/22 ------------------ <<<<<
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMakerCd.Focus(); // ADD 2011/08/22
                                return;
                            }
                        }
                        catch
                        {

                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = MakerGuide_Button;
                                        }
                                        else
                                        {
                                            // 中分類コード
                                            e.NextCtrl = this.tNedit_GoodsMGroup;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                                        //// BLコード更新区分
                                        //e.NextCtrl = this.BLCode_tComboEditor;
                                        // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                                        // 価格更新区分
                                        e.NextCtrl = this.Price_tComboEditor;
                                        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    {
                        if (this.tNedit_GoodsMGroup.Text.Trim() == "")
                        {
                            this.MGroup_uLabel.Text = "";
                            this._goodsGroupU = new GoodsGroupU(); // 王飛３ ADD 2011/09/16
                            return;
                        }
                        try
                        {
                            GoodsGroupU goodsGroupU;
                            int status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
                                this._goodsGroupU = goodsGroupU;  // ADD 2011/08/22
                            }
                            else
                            {
                                // 警告を出す
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "入力された中分類コードは存在しません。",
                                          -1,
                                          MessageBoxButtons.OK);
                                /* ----------------- DEL 2011/08/22 ------------------ >>>>>
                                this.MGroup_tNedit.Text = "";
                                this.MGroup_uLabel.Text = "";
                                -------------------- DEL 2011/08/22 ------------------ <<<<<*/
                                // ----------------- ADD 2011/08/22 ------------------ >>>>>
                                if (this._goodsGroupU.GoodsMGroup != 0)
                                {
                                    this.tNedit_GoodsMGroup.Text = this._goodsGroupU.GoodsMGroup.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Text = "";
                                }
                                this.MGroup_uLabel.Text = this._goodsGroupU.GoodsMGroupName;
                                // ----------------- ADD 2011/08/22 ------------------ <<<<<
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMGroup.Focus();  // ADD 2011/08/22
                                return;
                            }
                        }
                        catch
                        {
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMGroup.Text.Trim() == "")
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = MGroupGuide_Button;
                                        }
                                        else
                                        {
                                            // 中分類コード
                                            e.NextCtrl = this.tNedit_BLGoodsCode;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_BLGoodsCode":
                    {
                        if (this.tNedit_BLGoodsCode.Text.Trim() == "")
                        {
                            this.BLGoodsCode_uLabel.Text = "";
                            this._blGoodsCdUMnt = new BLGoodsCdUMnt();   // 王飛３ ADD 2011/09/16
                            return;
                        }
                        try
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt;
                            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsFullName;  // DEL 2011/09/16
                                this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;    // ADD 2011/09/16
                                this._blGoodsCdUMnt = blGoodsCdUMnt;  // ADD 2011/08/22
                            }
                            else
                            {
                                // 警告を出す
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "入力されたBLコードは存在しません。",
                                          -1,
                                          MessageBoxButtons.OK);
                                /* ----------------- DEL 2011/08/22 ------------------ >>>>>
                                this.BLGoodsCode_tNedit.Text = "";
                                this.BLGoodsCode_uLabel.Text = "";
                                -------------------- DEL 2011/08/22 ------------------ <<<<<*/
                                // ----------------- ADD 2011/08/22 ------------------ >>>>>
                                if (this._blGoodsCdUMnt.BLGoodsCode != 0)
                                {
                                    this.tNedit_BLGoodsCode.Text = this._blGoodsCdUMnt.BLGoodsCode.ToString();
                                }
                                else
                                {
                                    this.tNedit_BLGoodsCode.Text = "";
                                }
                                //this.BLGoodsCode_uLabel.Text = this._blGoodsCdUMnt.BLGoodsFullName;  // DEL 2011/09/16
                                this.BLGoodsCode_uLabel.Text = this._blGoodsCdUMnt.BLGoodsHalfName;    // ADD 2011/09/16
                                // ----------------- ADD 2011/08/22 ------------------ <<<<<
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGoodsCode.Focus();  // ADD 2011/08/22
                                return;
                            }
                        }
                        catch
                        {
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_BLGoodsCode.Text.Trim() == "")
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = BLGoodsCodeGuide_Button;
                                        }
                                        else
                                        {
                                            // 中分類コード
                                            e.NextCtrl = this.Name_tComboEditor;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        // --- ADD 2011/09/16 -------------------- >>>>>
        /// <summary>
        /// PMKHN09670U_KeyDownフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/09/16</br>
        /// </remarks>
        private void PMKHN09670U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (this.tNedit_GoodsMakerCd.Focused)
                { 
                    MakerGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_GoodsMGroup.Focused)
                {
                    MGroupGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_BLGoodsCode.Focused)
                {
                    BLGoodsCodeGuide_Button_Click(sender, e);
                    return;
                }
            }
        }
        // --- ADD 2011/09/16 -------------------- <<<<<

    }

}
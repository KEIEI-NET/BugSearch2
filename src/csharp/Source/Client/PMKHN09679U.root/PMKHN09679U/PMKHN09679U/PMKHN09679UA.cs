//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品マスタ更新(サポート)処理
//                  :   PMKHN09679U.EXE
// Name Space       :   Broadleaf.Windows.Forms
// Programmer       :   譚洪
// Date             :   2021/08/09
// Update Note      :   新規作成
//----------------------------------------------------------------------
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
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
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品マスタ更新(サポート)処理ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ更新(サポート)を行うＵＩフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2021/08/09</br>
    /// </remarks>
    public partial class PMKHN09679U : Form
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
        /// <summary>メーカー</summary>
        private MakerUMnt _maker;
        /// <summary>中分類</summary>
        private GoodsGroupU _goodsGroupU;
        /// <summary>BLコード</summary>
        private BLGoodsCdUMnt _blGoodsCdUMnt;

        #region Const
        private const string UpdateErrMsg = "商品マスタの更新に失敗しました。";
        private const string ProcessNm = "商品マスタ更新(サポート)";
        private const string LogUpdateMsg = "{0} より、商品マスタには、{1}件を更新しました。";
        private const string LogUpdateErr = "{0} より、商品マスタの更新に失敗しました。";
        private const string GetMakerErr = "メーカー取得取得失敗";
        private const string CntZero = "0";
        private const int MakerDiv = 1000;
        private const int CntZeroInt = 0;
        #endregion

        #region 初期設定処理
        /// <summary>
        /// 商品マスタ更新(サポート)処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品マスタ更新処理の新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2021/08/09</br>
        /// </remarks>
        public PMKHN09679U()
        {
            InitializeComponent();
            ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void PMKHN09679U_Load(object sender, EventArgs e)
        {
            this._goodsMngAcs.Write("起動", "起動", "");
            _goodsAcs = new GoodsAcs();
            _blGoodsCdAcs = new BLGoodsCdAcs();
            _goodsGroupUAcs = new GoodsGroupUAcs();
            _makerAcs = new MakerAcs();

            this.Name_tComboEditor.Items.Clear();
            this.Name_tComboEditor.Items.Add(0, "しない");
            this.Name_tComboEditor.Items.Add(1, "する");

            this.Rate_tComboEditor.Items.Clear();
            this.Rate_tComboEditor.Items.Add(0, "しない");
            this.Rate_tComboEditor.Items.Add(1, "する（提供未設定分は更新無）");
            this.Rate_tComboEditor.Items.Add(2, "する（無条件更新）");

            this.BLCode_tComboEditor.Items.Clear();
            this.BLCode_tComboEditor.Items.Add(0, "しない");
            this.BLCode_tComboEditor.Items.Add(1, "する");

            this.Price_tComboEditor.Items.Clear();
            this.Price_tComboEditor.Items.Add(0, "しない");
            this.Price_tComboEditor.Items.Add(1, "する");

            this.Name_tComboEditor.SelectedIndex = 0;
            this.Rate_tComboEditor.SelectedIndex = 0;
            this.BLCode_tComboEditor.SelectedIndex = 0;
            this.Price_tComboEditor.SelectedIndex = 0;

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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case "Btn_Close":
                    {
                        this._goodsMngAcs.Write("終了", "終了", "");

                        // 終了処理
                        Close();
                        break;
                    }
                //更新
                case "Btn_Update":
                    {

                        //_goodsAcs
                        #region ●抽出条件チェック
                        if ((int)this.Name_tComboEditor.Value == 0 &&
                            (int)this.Rate_tComboEditor.Value == 0 &&
                            (int)this.BLCode_tComboEditor.Value == 0 &&
                            ((int)this.Price_tComboEditor.Value == 0))
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                "いずれかの更新区分を設定して下さい。", -1, MessageBoxButtons.OK);
                            this.Name_tComboEditor.Focus();
                            return;
                        }
                        #endregion

                        
                        //共通処理中画面生成
                        SFCMN00299CA processingDialog = new SFCMN00299CA();
                        processingDialog.DispCancelButton = false;
                        processingDialog.Title = "更新処理";
                        processingDialog.Message = "現在、データ抽出、更新中です…";
                        processingDialog.Show((Form)this.Parent);

                        #region メーカー取得
                        ArrayList makerList = new ArrayList();
                        if (this.tNedit_GoodsMakerCd.Text.Trim() == string.Empty)
                        {
                            // メーカーが未入力場合、メーカー取得
                            int status = _makerAcs.SearchAll(out makerList, this._enterpriseCode);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this._goodsMngAcs.Write(ProcessNm, GetMakerErr, string.Empty);
                                processingDialog.Close();
                                this.UpdateCountLabel.Text = CntZero;
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                UpdateErrMsg, -1, MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            MakerUMnt sgMakerUWork = new MakerUMnt();
                            sgMakerUWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                            makerList.Add(sgMakerUWork);
                        }
                        #endregion

                        int totalCnt = CntZeroInt;
                        foreach (MakerUMnt sgMakerUWork in makerList)
                        {
                            // 純正メーカーが更新対象外
                            if (sgMakerUWork.GoodsMakerCd < MakerDiv)
                            {
                                continue;
                            }

                            #region ●抽出条件設定
                            //-----------------------------------------------------------------------------
                            // 抽出条件設定
                            //-----------------------------------------------------------------------------
                            GoodsUpdate goodsUpdate = new GoodsUpdate();
                            goodsUpdate.EnterpriseCode = this._enterpriseCode;
                            goodsUpdate.GoodsNameUpdateDivCd = (int)this.Name_tComboEditor.Value;
                            goodsUpdate.RateRankUpdateDivCd = (int)this.Rate_tComboEditor.Value;
                            goodsUpdate.BLCodeUpdateDivCd = (int)this.BLCode_tComboEditor.Value;
                            goodsUpdate.PriceUpdateDivCd = (int)this.Price_tComboEditor.Value;
                            goodsUpdate.GoodsMakerCd = sgMakerUWork.GoodsMakerCd;
                            goodsUpdate.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                            goodsUpdate.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            #endregion

                            int updCnt = 0;
                            int status = this._goodsMngAcs.Update(out updCnt, goodsUpdate);
                            string logDataMessage = string.Empty;
                            if (goodsUpdate.GoodsMakerCd > 0)
                                logDataMessage += "メーカ：" + goodsUpdate.GoodsMakerCd;
                            if (goodsUpdate.GoodsMGroup > 0)
                                logDataMessage += " 中分類：" + goodsUpdate.GoodsMGroup;
                            if (goodsUpdate.BLGoodsCode > 0)
                                logDataMessage += " BLコード：" + goodsUpdate.BLGoodsCode;
                            this._goodsMngAcs.Write("商品マスタ更新", logDataMessage + " より、商品マスタには、" + updCnt.ToString() + "件を更新しました。", "");

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                totalCnt = totalCnt + updCnt;
                            }
                            else
                            {
                                this._goodsMngAcs.Write(ProcessNm, string.Format(LogUpdateErr, logDataMessage), string.Empty);
                                processingDialog.Close();
                                this.UpdateCountLabel.Text = "0";
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                UpdateErrMsg, -1, MessageBoxButtons.OK);
                                return;
                            }
                        }
                        //処理件数を表示
                        this.UpdateCountLabel.Text = totalCnt.ToString();
                        //共通処理中画面閉じる
                        processingDialog.Close();
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                       "商品マスタ更新処理が終了しました。", 0, MessageBoxButtons.OK);

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
        /// <br>Note       : メーカーガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
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
                    if (this._maker.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd.Text = "";
                    }
                    this.MakerCode_uLabel.Text = this._maker.MakerName;
                    this.tNedit_GoodsMakerCd.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_uLabel.Text = maker.MakerName;
                this._maker = maker;
                this.tNedit_GoodsMGroup.Focus();
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
        /// <br>Note       : ＢＬコードガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;
            this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
            if (blGoodsCdUMnt.BLGoodsCode > 0)
            {
                this.Price_tComboEditor.Focus();
            }
            else 
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            this._blGoodsCdUMnt = blGoodsCdUMnt;
        }

        /// <summary>
        /// 中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 中分類ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;
            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
            if (status != 0) return;
            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
            if (goodsGroupU.GoodsMGroup > 0)
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            else
            {
                this.tNedit_GoodsMGroup.Focus();
            }
            this._goodsGroupU = goodsGroupU;
        }

        /// <summary>
        /// tArrowKeyControl1チェンジフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォーカスが遷移したタイミングで発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/08/09</br>
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
                            this._maker = new MakerUMnt();
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
                            if (this._maker.GoodsMakerCd != 0)
                            {
                                this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.Text = "";
                            }
                            this.MakerCode_uLabel.Text = this._maker.MakerName;
                            e.NextCtrl = e.PrevCtrl;
                            this.tNedit_GoodsMakerCd.Focus();
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
                                this._maker = maker;
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
                                if (this._maker.GoodsMakerCd != 0)
                                {
                                    this.tNedit_GoodsMakerCd.Text = this._maker.GoodsMakerCd.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Text = "";
                                }
                                this.MakerCode_uLabel.Text = this._maker.MakerName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMakerCd.Focus();
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
                                        // 価格更新区分
                                        e.NextCtrl = this.Price_tComboEditor;
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
                            this._goodsGroupU = new GoodsGroupU();
                            return;
                        }
                        try
                        {
                            GoodsGroupU goodsGroupU;
                            int status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
                                this._goodsGroupU = goodsGroupU;
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
                                if (this._goodsGroupU.GoodsMGroup != 0)
                                {
                                    this.tNedit_GoodsMGroup.Text = this._goodsGroupU.GoodsMGroup.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Text = "";
                                }
                                this.MGroup_uLabel.Text = this._goodsGroupU.GoodsMGroupName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_GoodsMGroup.Focus();
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
                                            // BLコード
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
                            this._blGoodsCdUMnt = new BLGoodsCdUMnt();
                            return;
                        }
                        try
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt;
                            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
                                this._blGoodsCdUMnt = blGoodsCdUMnt;
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
                                if (this._blGoodsCdUMnt.BLGoodsCode != 0)
                                {
                                    this.tNedit_BLGoodsCode.Text = this._blGoodsCdUMnt.BLGoodsCode.ToString();
                                }
                                else
                                {
                                    this.tNedit_BLGoodsCode.Text = "";
                                }
                                this.BLGoodsCode_uLabel.Text = this._blGoodsCdUMnt.BLGoodsHalfName;
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGoodsCode.Focus();
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
                                            // 価格更新区分
                                            e.NextCtrl = this.Price_tComboEditor;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// PMKHN09679U_KeyDownフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/09/16</br>
        /// </remarks>
        private void PMKHN09679U_KeyDown(object sender, KeyEventArgs e)
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

    }

}
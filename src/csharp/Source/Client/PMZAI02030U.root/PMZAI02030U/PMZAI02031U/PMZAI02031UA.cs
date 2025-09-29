using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 発注残クリアフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注残クリアのフォームクラスです。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.23</br>
    /// <br>Update Note: 2008.11.19 30452 上野 俊治</br>
    /// <br>            ・画面パネルをDock.Fillに修正</br>
    /// <br>            ・最大化ボタンを無効に修正</br>
    /// <br>            ・uiSetControlのchangeFocusイベントを設定</br>
    /// <br>            ・Tab、Enterキーでのガイド遷移を不可に修正</br>
    /// <br>Update Note: 2009.01.23 30452 上野 俊治</br>
    /// <br>            ・障害対応9137(最大化を有効化。UltraExplorerBar追加。)</br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・排他制御処理追加。</br>
    /// <br>Update Note: 2009.02.18 30452 上野 俊治</br>
    /// <br>            ・障害対応11640(排他エラー時のエラーレベルをERR_LEVEL_STOPDISPに変更)</br>
    /// <br>Update Note: 2009.02.18 30452 上野 俊治</br>
    /// <br>            ・障害対応11675</br>
    /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
    /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
    /// </remarks>
    public partial class PMZAI02031UA : Form
    {
        #region ■ コンストラクタ
        public PMZAI02031UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 各種ガイドアクセスのインスタンス化
            this._warehouseAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
        }
        #endregion

        #region ■ private変数

        // 企業コード
        private string _enterpriseCode = "";
        
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private ExtrInfo_SalesOrderRemainClear _extrInfo_SalesOrderRemainClear;

        // 発注残クリアアクセスクラス
        private SalesOrderRemainClearAcs _salesOrderRemainClearAcs;

        // 倉庫ガイド
        private WarehouseAcs _warehouseAcs;
        // 仕入先ガイド
        private SupplierAcs _supplierAcs;
        // メーカーガイド
        private MakerAcs _makerAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;
        #endregion

        #region ■ privateメソッド
        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            // ツールバーアイコン設定
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // ガイドアイコン設定
            this.SetIconImage(this.uButton_WarehouseCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_WarehouseCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SupplierCdStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_SupplierCdEdGuid, Size16_Index.STAR1);
            // -------DEL 2010/06/08------->>>>>
            //this.SetIconImage(this.uButton_GoodsMakerCdStGuide, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_GoodsMakerCdEdGuide, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_BLGoodsCodeStGuid, Size16_Index.STAR1);
            //this.SetIconImage(this.uButton_BLGoodsCodeEdGuid, Size16_Index.STAR1);
            // -------DEL 2010/06/08-------<<<<<

            // 初期フォーカスセット
            this.uButton_WarehouseCodeStGuid.Focus();

            return status;
        }

        /// <summary>
        /// クリア実行前 入力チェック
        /// </summary>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private bool DecisionBeforeCheck()
        {
            const string ct_RangeError = "の範囲指定に誤りがあります";
            string errMessage = "";
            Control errComponent = null;

            bool status = true;

            // 倉庫
            if (this.tEdit_WarehouseCode_Ed.DataText != string.Empty
                && (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0))
            {
                errMessage = string.Format("倉庫{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 仕入先
            else if (this.tNedit_SupplierCd_Ed.GetInt() != 0
                && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // -------DEL 2010/06/08------->>>>>
            //// メーカー
            //else if (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0
            //    && (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            //{
            //    errMessage = string.Format("メーカー{0}", ct_RangeError);
            //    errComponent = this.tNedit_GoodsMakerCd_St;
            //    status = false;
            //}
            //else if (this.tNedit_BLGoodsCode_Ed.GetInt() != 0
            //    && (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            //{
            //    errMessage = string.Format("BLコード{0}", ct_RangeError);
            //    errComponent = this.tNedit_BLGoodsCode_St;
            //    status = false;
            //}
            // -------DEL 2010/06/08-------<<<<<

            if (!status)
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

            }

            return status;
        }

        /// <summary>
        /// クリア条件設定処理
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                this._extrInfo_SalesOrderRemainClear = new ExtrInfo_SalesOrderRemainClear();

                // 企業コード
                this._extrInfo_SalesOrderRemainClear.EnterpriseCode = this._enterpriseCode;

                // 倉庫コード
                if (this.tEdit_WarehouseCode_St.DataText == "") this._extrInfo_SalesOrderRemainClear.St_WarehouseCode = "0000";
                else this._extrInfo_SalesOrderRemainClear.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.PadLeft(4, '0');

                if (this.tEdit_WarehouseCode_Ed.DataText == "") this._extrInfo_SalesOrderRemainClear.Ed_WarehouseCode = "9999";
                else this._extrInfo_SalesOrderRemainClear.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.PadLeft(4, '0');

                // 仕入先
                this._extrInfo_SalesOrderRemainClear.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                this._extrInfo_SalesOrderRemainClear.Ed_SupplierCd = this.GetEndCode(this.tNedit_SupplierCd_Ed);

                // -------DEL 2010/06/08------->>>>>
                //// メーカー
                //this._extrInfo_SalesOrderRemainClear.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                //this._extrInfo_SalesOrderRemainClear.Ed_GoodsMakerCd = this.GetEndCode(this.tNedit_GoodsMakerCd_Ed);

                //// BLコード
                //this._extrInfo_SalesOrderRemainClear.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                //this._extrInfo_SalesOrderRemainClear.Ed_BLGoodsCode = this.GetEndCode(this.tNedit_BLGoodsCode_Ed);

                // -------DEL 2010/06/08-------<<<<<
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// クリア処理実行
        /// </summary>
        private void ExecuteClear()
        {
            int status = 0;
            this._salesOrderRemainClearAcs = new SalesOrderRemainClearAcs();

            string msg; // ADD 2009/02/02
            status = this._salesOrderRemainClearAcs.Clear(this._extrInfo_SalesOrderRemainClear, out msg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 正常終了
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO, 
                                      this.Name,
                                      "更新しました",
                                      status,
                                      MessageBoxButtons.OK);
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 存在しない
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "対象データが存在しません",
                                      status,
                                      MessageBoxButtons.OK);
                    }
                    break;
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        // --- DEL 2009/02/18 -------------------------------->>>>>
                        //TMsgDisp.Show(this,
                        //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //    this.Name,
                        //    msg,
                        //    status,
                        //    MessageBoxButtons.OK);
                        // --- DEL 2009/02/18 --------------------------------<<<<<
                        // --- ADD 2009/02/18 -------------------------------->>>>>
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n" + "\r\n" + msg,
                        status,
                        MessageBoxButtons.OK);
                        // --- ADD 2009/02/18 --------------------------------<<<<<
                    }
                    break;
                // --- ADD 2009/02/02 --------------------------------<<<<<
                default:
                    {
                        // その他エラー
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "更新に失敗しました" ,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMZAI02031UA",						// アセンブリＩＤまたはクラスＩＤ
                "発注残クリア", 					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMZAI02031UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02031UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);

            // 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更
        }

        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                // 確定ボタン
                case "ButtonTool_Update":
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "クリアしてもよろしいですか？ ",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }

                        // 入力条件チェック
                        if (!this.DecisionBeforeCheck())
                        {
                            return;
                        }

                        // 入力条件抽出
                        if (this.SetExtraInfoFromScreen() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }

                        // リモート処理呼出
                        this.ExecuteClear();

                        break;
                    }
                // クリアボタン
                case "ButtonTool_Clear":
                    {
                        // 検索条件のクリア
                        this.tEdit_WarehouseCode_St.DataText = "";
                        this.tEdit_WarehouseCode_Ed.DataText = "";
                        this.tNedit_SupplierCd_St.SetInt(0);
                        this.tNedit_SupplierCd_Ed.SetInt(0);
                        // -------DEL 2010/06/08------->>>>>
                        //this.tNedit_GoodsMakerCd_St.SetInt(0);
                        //this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                        //this.tNedit_BLGoodsCode_St.SetInt(0);
                        //this.tNedit_BLGoodsCode_Ed.SetInt(0);
                        // -------DEL 2010/06/08-------<<<<<

                        // フォーカス設定
                        this.tEdit_WarehouseCode_St.Focus();

                        break;
                    }
            }
        }

        // --- ADD 2008/11/19 -------------------------------->>>>>
        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // タブキー、エンターキーでのガイド遷移は不可とする
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                // -------UPD 2010/06/08------->>>>>
                //if (e.NextCtrl == this.uButton_BLGoodsCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                //{
                //    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                //}
                //else if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter)) //DEL 2010/06/08
                //{
                //    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                //}

                if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter)) //DEL 2010/06/08
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }

                // -------UPD 2010/06/08-------<<<<<
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                if (e.NextCtrl == this.uButton_SupplierCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    // -------UPD 2010/06/08------->>>>>
                    //e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                    // -------UPD 2010/06/08-------<<<<<
                }
            }
            // -------DEL 2010/06/08------->>>>>
            //else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //{
            //    if (e.NextCtrl == this.uButton_SupplierCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_SupplierCd_Ed;
            //    }
            //    else if (e.NextCtrl == this.uButton_GoodsMakerCdStGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //{
            //    if (e.NextCtrl == this.uButton_GoodsMakerCdStGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //    }
            //    else if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_St;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            //{
            //    if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuide && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //    }
            //    else if (e.NextCtrl == this.uButton_BLGoodsCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            //{
            //    if (e.NextCtrl == this.uButton_BLGoodsCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tNedit_BLGoodsCode_St;
            //    }
            //    else if (e.NextCtrl == this.uButton_BLGoodsCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
            //    {
            //        e.NextCtrl = this.tEdit_WarehouseCode_St;
            //    }
            //}
            // -------DEL 2010/06/08-------<<<<<
        }
        // --- ADD 2008/11/19 --------------------------------<<<<<

        /// <summary>
        /// 倉庫(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeStGuid_Click(object sender, EventArgs e)
        {
            // 倉庫ガイド起動
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
        }

        /// <summary>
        /// 倉庫(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeEdGuid_Click(object sender, EventArgs e)
        {
            // 倉庫ガイド起動
            Warehouse warehouse;

            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_SupplierCd_St.Focus();
            }
        }

        /// <summary>
        /// 仕入先(開始)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierCdStGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tNedit_SupplierCd_Ed.Focus();
            }
        }

        /// <summary>
        /// 仕入先(終了)ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        /// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        private void uButton_SupplierCdEdGuid_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                //this.tNedit_GoodsMakerCd_St.Focus(); DEL 2010/06/08
                this.tEdit_WarehouseCode_St.Focus(); // ADD 2010/06/08
            }
        }

        // -------DEL 2010/06/08------->>>>>

        ///// <summary>
        ///// メーカーガイド（開始）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_GoodsMakerCdStGuide_Click(object sender, EventArgs e)
        //{
        //    MakerUMnt makerUMnt;

        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
        //        this.tNedit_GoodsMakerCd_Ed.Focus();
        //    }
        //}

        ///// <summary>
        ///// メーカーガイド（終了）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_GoodsMakerCdEdGuide_Click(object sender, EventArgs e)
        //{
        //    MakerUMnt makerUMnt;

        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
        //        this.tNedit_BLGoodsCode_St.Focus();
        //    }
        //}

        ///// <summary>
        ///// ＢＬガイド（開始）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <br>Update Note: 2010/06/08 張凱 障害改良対応（７月リリース分）の対応</br>
        ///// <br>            ・仕入明細を読み込み、仕入明細の発注残分の数量を対象在庫マスタの発注残からマイナスするようにする。</br>
        //private void uButton_BLGoodsCodeStGuid_Click(object sender, EventArgs e)
        //{
        //    BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
        //    BLGoodsCdUMnt bLGoodsCdUMnt;
        //    int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
        //        this.tNedit_BLGoodsCode_Ed.Focus();
        //    }
        //}

        ///// <summary>
        ///// ＢＬガイド（終了）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uButton_BLGoodsCodeEdGuid_Click(object sender, EventArgs e)
        //{
        //    BLGoodsCdAcs BLGoodsCdAcs = new BLGoodsCdAcs();
        //    BLGoodsCdUMnt bLGoodsCdUMnt;
        //    int status = BLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
        //        this.tEdit_WarehouseCode_St.Focus();
        //    }
        //}

        // -------DEL 2010/06/08-------<<<<<

        // --- ADD 2009/01/23 -------------------------------->>>>>
        /// <summary>
        /// ultraExplorerBar1_GroupCollapsingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ClearInfoGroup")
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ultraExplorerBar1_GroupExpandingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == "ClearInfoGroup")
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }
        // --- ADD 2009/01/23 --------------------------------<<<<<
        #endregion
    }
}
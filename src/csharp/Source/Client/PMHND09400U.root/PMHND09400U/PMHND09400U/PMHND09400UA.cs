//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新処理（手動）
// プログラム概要   : 商品バーコード更新処理（手動）ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード更新処理（手動）ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新のメインＵＩクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    public partial class PMHND09400U : Form
    {
        #region 型宣言

        /// <summary>
        /// 商品バーコード更新処理（手動）ＵＩ独自の結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
              /// <summary>成功</summary>
              Normal = 0
            , /// <summary>ハンディーターミナルOPバーコード提供オプション無効</summary>
              OptPmHndBarcodeOfferInvalid = -1
            , /// <summary>致命的エラー</summary>
              Error = -1000
        };

        #endregion //型宣言

        #region 定数定義

        /// <summary>
        /// オペレーションログ文字列：起動
        /// </summary>
        private static readonly string OperationLogTextStart = "起動";

        /// <summary>
        /// オペレーションログ文字列：終了
        /// </summary>
        private static readonly string OperationLogTextEnd = "終了"; 

        /// <summary>
        /// バーコード更新区分要素文字列：ユーザー更新以外
        /// </summary>
        private static readonly string BarcodeUpdateKndNameWithoutUserUpdate = "ユーザー更新以外";

        /// <summary>
        /// バーコード更新区分要素文字列：全て
        /// </summary>
        private static readonly string BarcodeUpdateKndNameAll = "全て";

        /// <summary>
        /// 進捗ダイアログタイトル
        /// </summary>
        private static readonly string ProcessingDialogTitleUpdate = "更新処理";

        /// <summary>
        /// 進捗ダイアログ表示文言
        /// </summary>
        private static readonly string ProcessingDialogMessageDefault = "現在、データ抽出、更新中です…";

        /// <summary>
        /// エラーメッセージ：未登録中分類コード入力
        /// </summary>
        private static readonly string GoodsMGroupInfoNotExists = "入力された中分類コードは存在しません。";

        /// <summary>
        /// エラーメッセージ：未登録BLコード入力
        /// </summary>
        private static readonly string BLCodeInfoNotExists = "入力されたBLコードは存在しません。";

        /// <summary>
        /// エラーメッセージ：純正メーカーコード入力
        /// </summary>
        private static readonly string CannotSelectGenuineMaker = "純正メーカーは選択できません。";

        /// <summary>
        /// エラーメッセージ：メーカー範囲指定不正
        /// </summary>
        private static readonly string ErrorTextIlligalMakerCodeRenge = "メーカーの範囲指定に誤りがあります。";

        /// <summary>
        /// エラーメッセージ：処理件数超過
        /// </summary>
        private static readonly string UpdateResultTextReadCountMaxOrver = "処理対象が2万件を超えました、条件を変更して再度処理を行ってください。";

        /// <summary>
        /// エラーメッセージ：処理失敗
        /// </summary>
        private static readonly string UpdateResultTextError = "商品バーコード更新処理に失敗しました。";

        /// <summary>
        /// 処理終了時メッセージ
        /// </summary>
        private static readonly string UpdateResultTextNormal = "商品バーコード更新処理が終了しました。";

        /// <summary>
        /// 未登録マスタコード入力時名称文字列
        /// </summary>
        private static readonly string NoRecodeInfoName = "未登録";

        #endregion //定数定義

        #region メンバーフィールド

        /// <summary>メーカーアクセスクラス</summary>
        private MakerAcs GoodsMakerGuidAcs;

        /// <summary>ＢＬ商品コード検索ガイド</summary>
        private BLGoodsCdAcs BlGoodsCdGuidAcs;

        /// <summary>中分類検索ガイド</summary>
        private GoodsGroupUAcs GoodsGroupUGuidAcs;

        /// <summary>商品バーコード更新アクセサクラス</summary>
        private PrmGoodsBarCodeRevnUpdateAcs PrmGoodsBrcdAcs;
        
        /// <summary>イメージリスト</summary>
        private ImageList ImageList16 = null; 
        /// <summary>企業コード</summary>
        private string ExecEnterpriseCode;
        /// <summary>メーカー（開始）</summary>
        private MakerUMnt MakerSt;
        /// <summary>メーカー（終了）</summary>
        private MakerUMnt MakerEd;
        /// <summary>中分類</summary>
        private GoodsGroupU GoodsGroupUInfo;
        /// <summary>BLコード</summary>
        private BLGoodsCdUMnt BlGoodsCdUInfo;

        /// <summary>
        /// 機能名
        /// </summary>
        private string AssemblyTitle;

        #endregion メンバーフィールド

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品バーコード更新処理（手動）ＵＩの新しいインスタンスの生成と初期化</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public PMHND09400U()
        {
            InitializeComponent();
            this.ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this.ExecEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //商品バーコード更新アクセサクラスインスタンス生成
            if (this.PrmGoodsBrcdAcs == null)
                this.PrmGoodsBrcdAcs = new PrmGoodsBarCodeRevnUpdateAcs();
            
            //メーカー（開始）
            if (MakerSt == null)
                MakerSt = new MakerUMnt();
            //メーカー（終了）
            if (MakerEd == null)
                MakerEd = new MakerUMnt();
            //中分類
            if (GoodsGroupUInfo == null)
                GoodsGroupUInfo = new GoodsGroupU();
            //BLコード
            if (BlGoodsCdUInfo == null)
                BlGoodsCdUInfo = new BLGoodsCdUMnt();

            //機能名の取得
            System.Reflection.AssemblyTitleAttribute assemblyTitle = 
                (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof( AssemblyTitleAttribute ) );
            this.AssemblyTitle = assemblyTitle.Title;

            //イベントハンドラの設定
            base.FormClosing += new FormClosingEventHandler( PMHND09400U_FormClosing );
        }
        #endregion //コンストラクタ

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロード時に実行される処理</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_Load(object sender, EventArgs e)
        {
            this.PrmGoodsBrcdAcs.WriteOperationLog( PMHND09400U.OperationLogTextStart, PMHND09400U.OperationLogTextStart, string.Empty );
            this.BlGoodsCdGuidAcs = new BLGoodsCdAcs();
            this.GoodsGroupUGuidAcs = new GoodsGroupUAcs();
            this.GoodsMakerGuidAcs = new MakerAcs();

            this.BarCode_tComboEditor.Items.Clear();
            this.BarCode_tComboEditor.Items.Add(
                (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.WithoutUserUpdate, PMHND09400U.BarcodeUpdateKndNameWithoutUserUpdate );
            this.BarCode_tComboEditor.Items.Add( 
                (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL, PMHND09400U.BarcodeUpdateKndNameAll );

            this.BarCode_tComboEditor.SelectedIndex = 0;

            this.ImageList16 = IconResourceManagement.ImageList16;

            this.MakerGuide_St_Button.ImageList = this.ImageList16;
            this.MakerGuide_Ed_Button.ImageList = this.ImageList16;
            this.MGroupGuide_Button.ImageList = this.ImageList16;
            this.BLGoodsCodeGuide_Button.ImageList = this.ImageList16;

            this.MakerGuide_St_Button.Appearance.Image = Size16_Index.STAR1;
            this.MakerGuide_Ed_Button.Appearance.Image = Size16_Index.STAR1;
            this.MGroupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.BLGoodsCodeGuide_Button.Appearance.Image = Size16_Index.STAR1;
            
        }
    
        #region ツールバークリックイベント
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case "Btn_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                //更新
                case "Btn_Update":
                    {
                        try
                        {
                            #region ●抽出条件チェック
                            if (this.tNedit_GoodsMakerCd_St.GetInt() > this.GetEndCode( this.tNedit_GoodsMakerCd_Ed ))
                            {
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        PMHND09400U.ErrorTextIlligalMakerCodeRenge, -1, MessageBoxButtons.OK );
                                this.tNedit_GoodsMakerCd_St.Focus();
                                return;
                            }
                            #endregion

                            #region ●抽出条件設定
                            //-----------------------------------------------------------------------------
                            // 抽出条件設定
                            //-----------------------------------------------------------------------------
                            PrmGoodsBrcdUpdateParamWork updateParam = new PrmGoodsBrcdUpdateParamWork();
                            updateParam.EnterpriseCode = this.ExecEnterpriseCode;
                            int uiValue = this.tNedit_GoodsMakerCd_St.GetInt();
                            updateParam.MakerCdST = uiValue < PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum ? 
                                PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum : uiValue;
                            uiValue = this.tNedit_GoodsMakerCd_Ed.GetInt();
                            updateParam.MakerCdED = uiValue == 0 ? PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMaximum : uiValue;
                            updateParam.BarcodeUpdateKndDiv = (int)this.BarCode_tComboEditor.Value;
                            updateParam.GoodMGroup = this.tNedit_GoodsMGroup.GetInt();
                            updateParam.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            updateParam.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                            updateParam.RecordCnt = 0;
                            #endregion

                            //共通処理中画面生成
                            SFCMN00299CA processingDialog = new SFCMN00299CA();
                            processingDialog.DispCancelButton = false;
                            processingDialog.Title = PMHND09400U.ProcessingDialogTitleUpdate;
                            processingDialog.Message = PMHND09400U.ProcessingDialogMessageDefault;
                            processingDialog.Show( (Form)this.Parent );

                            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            try
                            {

                                status = this.PrmGoodsBrcdAcs.Update( ref updateParam, false);
                                string logDataMessage = this.PrmGoodsBrcdAcs.CreateUpdateLogText( ref updateParam );
                                this.PrmGoodsBrcdAcs.WriteOperationLog( this.AssemblyTitle, logDataMessage, string.Empty );

                                this.UpdateCountLabel.Text = updateParam.RecordCnt.ToString();
                            }
                            finally
                            {
                                processingDialog.Close();
                            }
                            if (status == (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver)
                            {
                                // 処理件数オーバー
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, PMHND09400U.UpdateResultTextReadCountMaxOrver, -1, MessageBoxButtons.OK );
                            }
                            else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 処理件数オーバー以外のエラー
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, PMHND09400U.UpdateResultTextError, status, MessageBoxButtons.OK );
                            }
                            else
                            {
                                // 正常または更新対象なし
                                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, PMHND09400U.UpdateResultTextNormal, 0, MessageBoxButtons.OK );
                            }
                        }
                        catch(Exception exp)
                        {
                            // 例外エラー
                            this.WriteErrorLog( exp, PMHND09400U.UpdateResultTextError, (int)ConstantManagement.DB_Status.ctDB_ERROR );
                            TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_STOP, this.Name, exp.Message, (int)ConstantManagement.DB_Status.ctDB_ERROR, MessageBoxButtons.OK );
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : クライアントログにログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void WriteErrorLog( Exception ex, string errorText, int status )
        {
            ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
            if (ex != null)
            {
                string message = string.Concat( new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" } );
                clientLogTextOut.Output( ex.Source, message, status, ex );
            }
            else
            {
                clientLogTextOut.Output( base.GetType().Assembly.GetName().Name, errorText, status );
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
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // ガイド起動
                int status = this.GoodsMakerGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out maker);
                if (status != 0) return;

                if (chkPrime(maker.GoodsMakerCd) == false)
                {
                    if (this.MakerSt.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd_St.Text = this.MakerSt.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                    }
                    this.MakerCode_St_uLabel.Text = this.MakerSt.MakerName;
                    this.tNedit_GoodsMakerCd_St.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd_St.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_St_uLabel.Text = maker.MakerName;
                this.MakerSt = maker;
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MakerGuide_Ed_Button_Click(object sender, EventArgs e)
        {
            try
            {

                MakerUMnt maker;

                // ガイド起動
                int status = this.GoodsMakerGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out maker);
                if (status != 0) return;

                if (chkPrime(maker.GoodsMakerCd) == false)
                {
                    if (this.MakerEd.GoodsMakerCd != 0)
                    {
                        this.tNedit_GoodsMakerCd_Ed.Text = this.MakerEd.GoodsMakerCd.ToString();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                    }
                    this.MakerCode_Ed_uLabel.Text = this.MakerEd.MakerName;
                    this.tNedit_GoodsMakerCd_Ed.Focus();
                    return;
                }
                this.tNedit_GoodsMakerCd_Ed.Text = maker.GoodsMakerCd.ToString();
                this.MakerCode_Ed_uLabel.Text = maker.MakerName;
                this.MakerEd = maker;
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
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this.BlGoodsCdGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out blGoodsCdUMnt);
            if (status != 0) return;
            this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
            if (blGoodsCdUMnt.BLGoodsCode > 0)
            {
                this.BarCode_tComboEditor.Focus();
            }
            else 
            {
                this.tNedit_BLGoodsCode.Focus();
            }
            this.BlGoodsCdUInfo = blGoodsCdUMnt;
        }

        /// <summary>
        /// 中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 中分類ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void MGroupGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsGroupU goodsGroupU;
            int status = this.GoodsGroupUGuidAcs.ExecuteGuid(this.ExecEnterpriseCode, out goodsGroupU);
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
            this.GoodsGroupUInfo = goodsGroupU;
        }

        /// <summary>
        /// tArrowKeyControl1チェンジフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスが遷移したタイミングで発生します。</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd_St":
                    {
                        int status = this.SetGoodsMakerValues(
                              ref this.tNedit_GoodsMakerCd_St
                            , ref this.MakerSt
                            , ref this.MakerCode_St_uLabel
                            , e );
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd_St.Text.Trim() == string.Empty)
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = MakerGuide_St_Button;
                                        }
                                        else
                                        {
                                            // メーカーコード（終了）
                                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
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
                                        // バーコード更新区分
                                        e.NextCtrl = this.BarCode_tComboEditor;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        int status = this.SetGoodsMakerValues(
                              ref this.tNedit_GoodsMakerCd_Ed
                            , ref this.MakerEd
                            , ref this.MakerCode_Ed_uLabel
                            , e );
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            return;
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_GoodsMakerCd_Ed.Text.Trim() == string.Empty)
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = MakerGuide_Ed_Button;
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
                                        // メーカーコード（開始）
                                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tNedit_GoodsMGroup":
                    {
                        int goodsMGroupCode = 0;
                        if (!string.IsNullOrEmpty( this.tNedit_GoodsMGroup.Text ))
                        {
                            goodsMGroupCode = this.tNedit_GoodsMGroup.GetInt();
                        }
                        if (goodsMGroupCode == 0)
                        {
                            this.MGroup_uLabel.Text = string.Empty;
                            this.GoodsGroupUInfo = new GoodsGroupU();
                            return;
                        }
                        try
                        {
                            GoodsGroupU goodsGroupU;
                            int status = this.GoodsGroupUGuidAcs.Search(out goodsGroupU, this.ExecEnterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.MGroup_uLabel.Text = goodsGroupU.GoodsMGroupName;
                                this.GoodsGroupUInfo = goodsGroupU;
                            }
                            else
                            {
                                // 警告を出す
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          PMHND09400U.GoodsMGroupInfoNotExists,
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this.GoodsGroupUInfo.GoodsMGroup != 0)
                                {
                                    this.tNedit_GoodsMGroup.Text = this.GoodsGroupUInfo.GoodsMGroup.ToString();
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Text = string.Empty;
                                }
                                this.MGroup_uLabel.Text = this.GoodsGroupUInfo.GoodsMGroupName;
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
                                        if (this.tNedit_GoodsMGroup.Text.Trim() == string.Empty)
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
                        int blCode = 0;
                        if (!string.IsNullOrEmpty( this.tNedit_BLGoodsCode.Text ))
                        {
                            blCode = this.tNedit_BLGoodsCode.GetInt();
                        }
                        if (blCode == 0)
                        {
                            this.BLGoodsCode_uLabel.Text = string.Empty;
                            this.BlGoodsCdUInfo = new BLGoodsCdUMnt();
                            return;
                        }
                        try
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt;
                            int status = this.BlGoodsCdGuidAcs.Read(out blGoodsCdUMnt, this.ExecEnterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.BLGoodsCode_uLabel.Text = blGoodsCdUMnt.BLGoodsHalfName;
                                this.BlGoodsCdUInfo = blGoodsCdUMnt;
                            }
                            else
                            {
                                // 警告を出す
                                TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          PMHND09400U.BLCodeInfoNotExists,
                                          -1,
                                          MessageBoxButtons.OK);
                                if (this.BlGoodsCdUInfo.BLGoodsCode != 0)
                                {
                                    this.tNedit_BLGoodsCode.Text = this.BlGoodsCdUInfo.BLGoodsCode.ToString();
                                }
                                else
                                {
                                    this.tNedit_BLGoodsCode.Text = string.Empty;
                                }
                                this.BLGoodsCode_uLabel.Text = this.BlGoodsCdUInfo.BLGoodsHalfName;
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
                                        if (this.tNedit_BLGoodsCode.Text.Trim() == string.Empty)
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = BLGoodsCodeGuide_Button;
                                        }
                                        else
                                        {
                                            // 中分類コード
                                            e.NextCtrl = this.BarCode_tComboEditor;
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
        /// 商品バーコード更新処理（手動）ＵＩキー押下イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新処理（手動）ＵＩでキーが押下された場合に発生</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (this.tNedit_GoodsMakerCd_St.Focused)
                { 
                    MakerGuide_Button_Click(sender, e);
                    return;
                }
                if (this.tNedit_GoodsMakerCd_Ed.Focused)
                {
                    this.MakerGuide_Ed_Button_Click( sender, e );
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

        /// <summary>
        /// フォームクローズ前イベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">FormClosingEventArgs型イベントデータ</param>
        /// <remarks>
        /// <br>Note       : フォームが閉じる前に発生</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private void PMHND09400U_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (this.PrmGoodsBrcdAcs == null)
                this.PrmGoodsBrcdAcs = new PrmGoodsBarCodeRevnUpdateAcs();
            this.PrmGoodsBrcdAcs.WriteOperationLog( PMHND09400U.OperationLogTextEnd, PMHND09400U.OperationLogTextEnd, string.Empty );
        }
        #endregion //イベントハンドラ

        #region プライベートメソッド

        /// <summary>
        /// 純正メーカーチェック
        /// </summary>
        /// <param name="goodsMakerCd">判定メーカーコード</param>
        /// <returns>判定結果[true:優良メーカー、false:純正メーカー]</returns>
        /// <remarks>
        /// <br>Note       : 判定メーカーコードが純正メーカーのコードか否かを判定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private bool chkPrime( int goodsMakerCd )
        {
            bool status = true;

            if (0 < goodsMakerCd && goodsMakerCd < PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum)
            {
                status = false;

                // 警告を出す
                TMsgDisp.Show(
                          this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          this.Name,
                          PMHND09400U.CannotSelectGenuineMaker,
                          -1,
                          MessageBoxButtons.OK);
            }
            return status;
        }

        /// <summary>
        /// 最大値判定付きコード取得処理
        /// </summary>
        /// <param name="tNedit">処理対象入力コントロール</param>
        /// <returns>取得コード</returns>
        /// <remarks>
        /// <br>Note       : 処理対象入力コントロールの入力値に対応するコードを取得する</br>
        /// <br>             入力値が0の場合は処理対象入力コントロールで入力可能な最大値を、0以外の場合は入力値を返す</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 最大値判定付きコード取得処理(最大値指定)
        /// </summary>
        /// <param name="tNedit">処理対象入力コントロール</param>
        /// <param name="endCodeOnDB">最大値</param>
        /// <returns>取得コード</returns>
        /// <remarks>
        /// <br>Note       : 処理対象入力コントロールの入力値に対応するコードを取得する</br>
        /// <br>             入力値が0の場合は引数で指定された最大値を、0以外の場合は入力値を返す</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
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
        /// メーカー情報設定処理
        /// </summary>
        /// <param name="tNeditCode">メーカーコード取得/設定先</param>
        /// <param name="makerBuffer">メーカー情報取得/設定先</param>
        /// <param name="label">メーカー名設定先</param>
        /// <param name="e">フォーカス先設定用イベントパラメータ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : メーカーコード入力欄の値に対応するメーカー情報のセットを行う</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SetGoodsMakerValues( ref TNedit tNeditCode, ref MakerUMnt makerBuffer, ref Infragistics.Win.Misc.UltraLabel label, ChangeFocusEventArgs e )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string code = tNeditCode.Text;
            int codeValue = 0;

            if (!string.IsNullOrEmpty( tNeditCode.Text ))
            {
                codeValue = tNeditCode.GetInt();
            }

            if (codeValue == 0)
            {
                // メーカーコードに空白もしくは0がセットされていた場合
                label.Text = string.Empty;
                makerBuffer = new MakerUMnt();
                return status;
            }

            if (!this.chkPrime( codeValue ))
            {
                // 純正メーカーの場合、前回入力値に戻す
                if (makerBuffer.GoodsMakerCd != 0)
                {
                    tNeditCode.Text = makerBuffer.GoodsMakerCd.ToString();
                }
                else
                {
                    tNeditCode.Text = string.Empty;
                }
                label.Text = this.MakerSt.MakerName;
                e.NextCtrl = e.PrevCtrl;
                tNeditCode.Focus();
                return status;
            }

            // 優良メーカーの場合
            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                MakerUMnt maker;

                // コード名称の取得
                int dbStatus = this.GoodsMakerGuidAcs.Read( out maker, this.ExecEnterpriseCode, codeValue );
                if (dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    label.Text = maker.MakerName;
                    makerBuffer = maker;
                }
                else
                {
                    makerBuffer.GoodsMakerCd = codeValue;
                    makerBuffer.MakerName = PMHND09400U.NoRecodeInfoName;
                    label.Text = makerBuffer.MakerName;
                }
            }
            catch
            {

            }

            return status;
        }

        #endregion //プライベートメソッド
    }

}
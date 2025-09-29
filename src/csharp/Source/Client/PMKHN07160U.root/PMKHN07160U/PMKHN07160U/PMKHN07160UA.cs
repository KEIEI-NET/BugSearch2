//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（エクスポート）
// プログラム概要   : 商品マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2009/08/17  修正内容 : 「BLコードガイド」の改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/05/12  修正内容 : Mantis.15352フィードバック　商品マスタに存在しない品番を指定して抽出すると
//                                  エラーとなる不具合の修正（該当なしのコメント追加）
//----------------------------------------------------------------------------//
// 管理番号  11570163-00 作成担当 : 田建委
// 修 正 日  2019/08/19  修正内容 : テキスト出力操作ログおよび出力時アラートメッセージ追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Broadleaf.Application.Remoting.ParamData; // ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品マスタ（エクスポート）
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（エクスポート）クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Note       : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/08/19</br>
    /// </remarks>
    public partial class PMKHN07160UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br>Note        : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/08/19</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07160UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _goodsExportAcs = new GoodsExportAcs();
            _goodsExportWork = new GoodsExportWork();
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応
        }
        #endregion

        #region ■ Private member
        // 商品マスタ（エクスポート）アクセスクラス
        private GoodsExportAcs _goodsExportAcs;
        // 商品マスタ（エクスポート）クラス
        private GoodsExportWork _goodsExportWork;

        // 企業コード
        private string _enterpriseCode;
        // メーカーガイドアクセスクラス
        private GoodsAcs _goodsAcs;
        private BLGoodsCdAcs _blGoodsCdAcs; // ADD 2009/08/17

        //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        // ログ出力共通部品
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // 登録・更新用操作履歴ワーク
        private TextOutPutOprtnHisLogWork TextOutPutOprtnHisLogWorkObj = null;
        //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion ■ Private member

        #region  ■ Private cost
        //エラー条件メッセージ
        private const string ct_INPUTERROR = "が不正です。";
        private const string ct_NOINPUT = "を入力してください。";
        private const string ct_RANGEERROR = "の範囲指定に誤りがあります。";
        // クラスID
        private const string ct_CLASSID = "PMKHN07160UA";
        private const string PMKHN07160U_PRPID = "PMKHN07160U.xml";
        private const string PRINTSET_TABLE = "GoodsExp";

        //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        // 最初から
        private const string StartStr = "最初から";
        // 最後まで
        private const string EndStr = "最後まで";
        // アセンブリID
        private const string AssemblyID = "PMKHN07160U";
        // アセンブリ名
        private const string AssemblyNm = "商品マスタ（エクスポート）";
        // メソッド名
        private const string MethodNm = "Extract";
        // 画面条件
        private const string MenuCon = "メーカー：{0} ～ {1},ＢＬコード：{2} ～ {3},品番：{4} ～ {5},ﾃｷｽﾄﾌｧｲﾙ名：{6}";
        // 出力件数
        private const string CountNumStr = "データ出力件数:{0},";
        //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion

        #region ■ IExportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            // 入力チェック処理
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// 抽出データ処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Note       : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            #region アラート表示
            // エラーメッセージ
            string errMsg = string.Empty;
            // アラート表示
            status = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // アラートでOKボタンが押されない場合、テキスト出力が実行できない
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                // 中止
                return status;
            }
            #endregion

            #region 操作履歴登録
            TextOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
            // ログデータ対象アセンブリID
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = AssemblyID;
            // ログデータ対象アセンブリ名称
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = AssemblyNm;
            // ログデータ対象起動プログラム名称
            TextOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = AssemblyNm;
            // ログデータ対象処理名
            TextOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
            // 画面条件
            // メーカーコード
            string makerCodeSt = this.tNedit_GoodsMakerCd_St.Text.Trim();
            makerCodeSt = string.IsNullOrEmpty(makerCodeSt) ? StartStr : makerCodeSt;
            string makerCodeEd = this.tNedit_GoodsMakerCd_Ed.Text.Trim();
            makerCodeEd = string.IsNullOrEmpty(makerCodeEd) ? EndStr : makerCodeEd;
            // BLコード
            string blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
            blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
            string blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
            blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
            // 品番
            string goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
            goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
            string goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
            goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
            // 出力ファイル名
            string filePath = this.tEdit_TextFileName.Text.Trim();
            string logOperationData = string.Format(MenuCon, makerCodeSt, makerCodeEd, blCodeSt, blCodeEd, goodsNoSt, goodsNoEd, filePath);
            // ログオペレーションデータ
            TextOutPutOprtnHisLogWorkObj.LogOperationData = logOperationData;

            // エラーメッセージ
            errMsg = string.Empty;
            // 操作履歴登録
            status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);

            // ログ登録異常またはアラートでOKボタンが押されない場合、テキスト出力が実行できない
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                return status;
            }
            #endregion
            //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<

            this.uLabel_OutPutNum.Text = "0";
            // 画面→抽出条件クラス
            this.SetExtraInfoFromScreen();
            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "エクスポート中";
            form.Message = "現在、データをエクスポート中です。";
            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // 検索
                status = this._goodsExportAcs.Search(_goodsExportWork, out dataTable);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BLコードクラスをデータセットへ展開する
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                // 2010/05/12 Add >>>
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        TMsgDisp.Show(						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                            "PMKHN07160U", 						// アセンブリＩＤまたはクラスＩＤ
                            "商品マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "該当データがありません。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsExportAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
                // 2010/05/12 Add <<<
                default:
                    {
                        TMsgDisp.Show(						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07160U", 						// アセンブリＩＤまたはクラスＩＤ
                            "商品マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsExportAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07160U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";
            // 画面表示
            this.Show();
            return;
        }

        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ完了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ｴｸｽﾎﾟｰﾄ完了処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Note       : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");

            //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            // 操作履歴登録
            TextOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString()) + TextOutPutOprtnHisLogWorkObj.LogOperationData;
            int status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
            // ログ登録異常の場合、テキスト出力が実行できない
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && !string.IsNullOrEmpty(errMsg))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                            errMsg, status, MessageBoxButtons.OK);
                // 中止
                return;
            }
            //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        }
        #endregion  ◆ Public Method
        #endregion ■ IExportConditionInpType メンバ

        #region ■ Private Event
        #region ◆ ガイド検索
        /// <summary>
        /// メーカーガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : メーカーガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tNedit_BLGoodsCode_St;
            }
            else
            {
                return;
            }
            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // 次フォーカス
            nextControl.Focus();
        }

        /// <summary>
        /// BLコードガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : BLコードガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/08/17 ------------------------------->>>>>
            //if (this._goodsAcs == null)
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //BLGoodsCdUMnt blGoodsCdUMnt;
            //int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            // --- DEL 2009/08/17 ------------------------------<<<<<

            // --- ADD 2009/08/17 ------------------------------->>>>>
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            // BLコードガイド表示
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            // --- ADD 2009/08/17 ------------------------------<<<<<

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(blGoodsCdUMnt.BLGoodsCode);
            nextControl.Focus();
        }
        #endregion

        #region ◆ ファイルダイアログ
        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 朱宝軍</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;

                if (String.IsNullOrEmpty(this.tEdit_TextFileName.Text.Trim()))
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //「ファイルの種類」を指定
                saveFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }
        #endregion

        #region ◆ ChangeFocus
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.04.01</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // メーカー(終了)→ＢＬコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // ＢＬコード(開始)→ＢＬコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // ＢＬコード(終了)→ 品番(開始)
                        e.NextCtrl = tEdit_GoodsNo_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // 品番(開始)→品番(終了)
                        e.NextCtrl = this.tEdit_GoodsNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
                    {
                        // 品番(終了)→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // メーカー(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // ＢＬコード(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // ＢＬコード(終了)→ ＢＬコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // 品番(開始)→ＢＬコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
                    {
                        // 品番(終了)→ 品番(開始)
                        e.NextCtrl = this.tEdit_GoodsNo_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ 品番(終了)
                        e.NextCtrl = this.tEdit_GoodsNo_Ed;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 朱宝軍</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion　■ Private Event

        #region ■ Control Event
        /// <summary>
        /// PMKHN07160UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void PMKHN07160UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動 
        }
        #endregion

        #region ■ Private Method
        #region ◎ エラーメッセージ表示処理 ( +1のオーバーロード )
        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                "商品マスタ（ｴｸｽﾎﾟｰﾄ）",			// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 画面初期化処理を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // メーカー
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // ＢＬコード
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();
            // 品番
            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();


            this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);
            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput();
            this.tNedit_GoodsMakerCd_St.Focus();
        }
        #endregion

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎ 検索情報処理
        /// <summary>
        /// 検索情報処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索情報処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // 企業コード
            _goodsExportWork.EnterpriseCode = this._enterpriseCode;
            // メーカー開始
            _goodsExportWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();

            // メーカー終了
            _goodsExportWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

            // ＢＬコード開始
            _goodsExportWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

            // ＢＬコード終了
            _goodsExportWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

            // 品番開始
            _goodsExportWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText.TrimEnd();

            // 品番終了
            _goodsExportWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText.TrimEnd();
        }
        #endregion

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopyチェック
            WordCoopyCheck();
            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "テキストファイル名を入力してください。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSVファイルパスが不正です。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }
            // メーカー
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("メーカー{0}", ct_RANGEERROR);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // BLコード
            if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RANGEERROR);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // 品番
            if (
                !String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) &&
                !String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) == 1)
            {
                errMessage = string.Format("品番{0}", ct_RANGEERROR);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            int goodsMakerStCode = this.tNedit_GoodsMakerCd_St.GetInt();
            int goodsMakerEdCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
            if (goodsMakerStCode == 0 && this.tNedit_GoodsMakerCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (goodsMakerEdCode == 0 && this.tNedit_GoodsMakerCd_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
            }

            int blGoodsStCode = this.tNedit_BLGoodsCode_St.GetInt();
            int blGoodsEdCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            if (blGoodsStCode == 0 && this.tNedit_BLGoodsCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_St.Text = String.Empty;
            }
            if (blGoodsEdCode == 0 && this.tNedit_BLGoodsCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_Ed.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_St.DataText.Contains("　") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("　") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex r1 = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText.Trim()))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText.Trim()))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
        }

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion　■ Private Method


    }
}
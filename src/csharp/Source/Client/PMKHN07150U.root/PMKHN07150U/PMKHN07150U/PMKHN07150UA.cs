//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLグループマスタ（エクスポート）
// プログラム概要   : BLグループマスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLグループマスタ（エクスポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLグループマスタ（エクスポート）UIフォームクラス</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07150UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// BLグループマスタ（エクスポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループマスタ（エクスポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07150UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._bLGroupSetExpAcs = new BLGroupSetExpAcs();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            DataSetColumnConstruction();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // クラスID
        private const string ct_ClassID = "PMKHN07150UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07150U";
        // CSV名称
        private string _printName = "BLグループマスタ（エクスポート）";
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";

        private BLGroupUAcs _bLGroupUAcs;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private BLGroupExportWork _bLGroupExportWork;

        // データアクセス
        private BLGroupSetExpAcs _bLGroupSetExpAcs;
        #endregion ■ Private Member

        #region ■ Private Const

        // dataview名称用
        private const string BLGROUPCODE = "BLGroupCode";
        private const string BLGROUPNAME = "BLGroupName";
        private const string BLGROUPKANANAME = "BLGroupKanaName";
        private const string SALESCODE = "SalesCode";
        private const string SALESCODENAME = "SalesCodeName";
        private const string GOODSLGROUP = "GoodsLGroup";
        private const string GOODSLGROUPNAME = "GoodsLGroupName";
        private const string GOODSMGROUP = "GoodsMGroup";
        private const string GOODSMGROUPNAME = "GoodsMGroupName";

        private const string PRINTSET_TABLE = "BLGROUPSET";
        private const string PMKHN07150U_PRPID = "PMKHN07150U.xml";
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;

            this.uLabel_OutPutNum.Text = "0";

            ArrayList bLGroupSetExpExpList = null;

            // 画面→抽出条件クラス
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "エクスポート中";
            form.Message = "現在、データをエクスポート中です。";

            try
            {
                // ダイアログ表示
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._bLGroupSetExpAcs.SearchAll(
                        out bLGroupSetExpExpList,
                        this._enterpriseCode,
                        this._bLGroupExportWork);
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
                        int index = 0;
                        foreach (BLGroupSetExp bLGroupSetExp in bLGroupSetExpExpList)
                        {
                            SecExportSetToDataSet(bLGroupSetExp.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "BLグループマスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._bLGroupSetExpAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07150U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return 0;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._bLGroupExportWork = new BLGroupExportWork();

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  ◆ Public Method
        #endregion ■ IExportConditionInpType メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // ボタン設定
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // 初期フォーカスセット
                this.tNedit_BLGloupCode_St.Focus();

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion ◎ 画面初期化処理

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 李占川</br>
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

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note	   : ボタンアイコン設定処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion ◎ ボタンアイコン設定処理
        #endregion ◆ 画面初期化関係

        #region ◆ ｴｸｽﾎﾟｰﾄ前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 李占川</br>                                    
        /// <br>Date        : 2009.05.13</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // メーカー
            if (!String.IsNullOrEmpty(this.tNedit_BLGloupCode_St.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_BLGloupCode_St.DataText))
            {
                this.tNedit_BLGloupCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tNedit_BLGloupCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_BLGloupCode_Ed.DataText))
            {
                this.tNedit_BLGloupCode_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // Coopyチェック
            WordCoopyCheck();

            const string ct_RangeError = "の範囲指定に誤りがあります。";

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

            // グループコードガイド
            if (
                (this.tNedit_BLGloupCode_St.GetInt() != 0) &&
                (this.tNedit_BLGloupCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt())
            {
                errMessage = string.Format("BLグループ{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
                return status;
            }

            return status;
        }
        #endregion ◎ 入力チェック処理

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// ｴｸｽﾎﾟｰﾄ条件設定処理(画面→ｴｸｽﾎﾟｰﾄ条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		 : 画面→ｴｸｽﾎﾟｰﾄ条件へ設定する。</br>
        /// <br>Programmer 　: 李占川</br>
        /// <br>Date       　: 2009.05.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 開始BLコード
                this._bLGroupExportWork.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                // 終了BLコード
                this._bLGroupExportWork.BLGroupCodeEd = this.tNedit_BLGloupCode_Ed.GetInt();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 抽出条件設定処理(画面→抽出条件)
        #endregion ◆ ｴｸｽﾎﾟｰﾄ前処理

        #region ◆ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理

        #region DataSet関連
        /// <summary>
        /// BLコードクラスデータセット展開処理
        /// </summary>
        /// <param name="bLGroupSetExp">BLコードクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : BLコードクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void SecExportSetToDataSet(BLGroupSetExp bLGroupSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            if (bLGroupSetExp.BLGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = bLGroupSetExp.BLGroupCode.ToString("00000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPNAME] = GetSubString(bLGroupSetExp.BLGroupName,20);
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPKANANAME] = GetSubString(bLGroupSetExp.BLGroupKanaName,20);
            if (bLGroupSetExp.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = bLGroupSetExp.SalesCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODENAME] = bLGroupSetExp.SalesCodeName;
            if (bLGroupSetExp.GoodsLGroup == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSLGROUP] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSLGROUP] = bLGroupSetExp.GoodsLGroup.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSLGROUPNAME] = bLGroupSetExp.GoodsLGroupName;
            if (bLGroupSetExp.GoodsMGroup == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMGROUP] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMGROUP] = bLGroupSetExp.GoodsMGroup.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMGROUPNAME] = bLGroupSetExp.GoodsMGroupName;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));		    // 	ｺｰﾄﾞ
            PrintSetTable.Columns.Add(BLGROUPNAME, typeof(string));		    // 	名称
            PrintSetTable.Columns.Add(BLGROUPKANANAME, typeof(string));		// 	ｶﾅ
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		    // 	販売区分
            PrintSetTable.Columns.Add(SALESCODENAME, typeof(string));		// 	販売区分名
            PrintSetTable.Columns.Add(GOODSLGROUP, typeof(string));		    // 	商品大分類
            PrintSetTable.Columns.Add(GOODSLGROUPNAME, typeof(string));		// 	商品大分類名
            PrintSetTable.Columns.Add(GOODSMGROUP, typeof(string));		    // 	商品中分類
            PrintSetTable.Columns.Add(GOODSMGROUPNAME, typeof(string));		// 	商品中分類名

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }
        #endregion DataSet関連

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
        bfString = bfString.Trim();
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN07150U_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void PMKHN07150U_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }

        /// <summary>
        /// グループコードガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : グループコードガイドをクリックときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void ub_GuideCode_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_St;
                nextControl = this.tNedit_BLGloupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_Ed;
                nextControl = this.tEdit_TextFileName;
            }
            else
            {
                return;
            }

            targetControl.SetInt(bLGroupU.BLGroupCode);


            // フォーカス移動
            nextControl.Focus();
        }

        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = "出力ファイル選択";
                saveFileDialog.RestoreDirectory = true;

                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
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

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // Coopyチェック
            WordCoopyCheck();
        }

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

        #endregion ■ Control Event
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ（エクスポート）
// プログラム概要   : 結合マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
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
    /// 結合マスタ（エクスポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタ（エクスポート）UIフォームクラス</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07170UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 結合マスタ（エクスポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ（エクスポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07170UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._JoinPartsSetExpAcs = new JoinPartsSetExpAcs();

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
        private string _printName = "結合マスタ（エクスポート）";
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";

        private GoodsAcs _goodsAcs;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private JoinPartsExpWork _joinPartsExpWork;

        // データアクセス
        private JoinPartsSetExpAcs _JoinPartsSetExpAcs;
        #endregion ■ Private Member

        #region ■ Private Const

        // dataview名称用
        private const string JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
        private const string JOINSOURCEMAKERNAME = "JoinSourceMakerName";
        private const string JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
        private const string JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
        private const string JOINDISPORDER = "JoinDispOrder";
        private const string JOINDESTPARTSNO = "JoinDestPartsNo";
        private const string JOINDESTMAKERCD = "JoinDestMakerCd";
        private const string JOINDESTMAKERNAME = "JoinDestMakerCdName";
        private const string JOINQTY = "JoinQty";
        private const string JOINSPECIALNOTE = "JoinSpecialNote";

        private const string PRINTSET_TABLE = "JOINPARTSSET";
        private const string PMKHN07120U_PRPID = "PMKHN07170U.xml";

        private const string NUMBER_FORMAT = "##0.00";
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
        /// <br>Date       : 2009.05.14</br>
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
        /// <br>Date       : 2009.05.14</br>
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
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this.uLabel_OutPutNum.Text = "0";

            ArrayList PrintSets = null;

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
                status = this._JoinPartsSetExpAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._joinPartsExpWork);
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
                        foreach (JoinPartsSetExp joinPartsSetExp in PrintSets)
                        {
                            SecExportSetToDataSet(joinPartsSetExp, index);
                            ++index;
                        }

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKHN07170U", 						// アセンブリＩＤまたはクラスＩＤ
                            "結合マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._JoinPartsSetExpAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07120U_PRPID;
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
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._joinPartsExpWork = new JoinPartsExpWork();

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
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・文字列
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // ボタン設定
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // 初期フォーカスセット
                this.tNedit_GoodsMakerCd_St.Focus();

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
        /// <br>Date       : 2009.05.14</br>
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
        /// <br>Date        : 2009.05.14</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // メーカー
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_St.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_St.DataText))
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_Ed.DataText))
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
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
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
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
        /// <br>Date       : 2009.05.14</br>
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

            // 結合
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("結合元メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // カナ
            if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("結合元品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
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
        /// <br>Date       　: 2009.05.14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 開始BLコード
                this._joinPartsExpWork.JoinSourceMakerCodeSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了BLコード
                this._joinPartsExpWork.JoinSourceMakerCodeEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 開始結合元品番
                this._joinPartsExpWork.JoinSourPartsNoWithHSt = this.tEdit_GoodsNo_St.DataText;
                // 終了結合元品番
                this._joinPartsExpWork.JoinSourPartsNoWithHEd = this.tEdit_GoodsNo_Ed.DataText;
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
        /// <br>Date       : 2009.05.14</br>
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
        /// <param name="joinPartsSetExp">BLコードクラス</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : BLコードクラスをデータセットへ格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SecExportSetToDataSet(JoinPartsSetExp joinPartsSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (joinPartsSetExp.JoinSourceMakerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERCODE] = joinPartsSetExp.JoinSourceMakerCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERNAME] = joinPartsSetExp.JoinSourceMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURPARTSNOWITHH] = GetSubString(joinPartsSetExp.JoinSourPartsNoWithH,24);

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURPARTSNONONEH] = GetSubString(joinPartsSetExp.JoinSourPartsNoNoneH,24);
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDISPORDER] = joinPartsSetExp.JoinDispOrder;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTPARTSNO] = GetSubString(joinPartsSetExp.JoinDestPartsNo,24);
            if (joinPartsSetExp.JoinDestMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = joinPartsSetExp.JoinDestMakerCd.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERNAME] = joinPartsSetExp.JoinDestMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINQTY] = joinPartsSetExp.JoinQty.ToString(NUMBER_FORMAT);
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSPECIALNOTE] = GetSubString(joinPartsSetExp.JoinSpecialNote,20);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Addを行う順番が、列の表示順位となります。
            PrintSetTable.Columns.Add(JOINSOURCEMAKERCODE, typeof(string));		// 	結合元メーカーコード
            PrintSetTable.Columns.Add(JOINSOURCEMAKERNAME, typeof(string));		// 	結合元メーカー名称
            PrintSetTable.Columns.Add(JOINSOURPARTSNOWITHH, typeof(string));	// 	結合元品番(－付き品番)
            PrintSetTable.Columns.Add(JOINSOURPARTSNONONEH, typeof(string));	// 	結合元品番(－無し品番)
            PrintSetTable.Columns.Add(JOINDISPORDER, typeof(Int32));		    // 	結合表示順位
            PrintSetTable.Columns.Add(JOINDESTPARTSNO, typeof(string));		    // 	結合先品番(－付き品番)
            PrintSetTable.Columns.Add(JOINDESTMAKERCD, typeof(string));		    // 	結合先メーカーコード
            PrintSetTable.Columns.Add(JOINDESTMAKERNAME, typeof(string));		// 	結合先メーカー名
            PrintSetTable.Columns.Add(JOINQTY, typeof(string));		            // 	結合QTY
            PrintSetTable.Columns.Add(JOINSPECIALNOTE, typeof(string));		    // 	結合規格・特記事項

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
            string afString = "";
            bfString = bfString.Trim();
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
        /// PMKHN07120U_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
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
        /// メーカーガイド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : メーカーガイドをクリックときに発生する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ub_GuideCode_Click(object sender, EventArgs e)
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
                nextControl = this.tEdit_GoodsNo_St;
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
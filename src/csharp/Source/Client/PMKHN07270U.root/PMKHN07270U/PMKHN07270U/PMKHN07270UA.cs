//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（エクスポート）
// プログラム概要   : 商品管理情報マスタ（エクスポート）フォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱宝軍
// 作 成 日  2012/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 更 新 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/13  修正内容 : 2012/10/17配信分、Redmine#32367
//                                  商品マスタエクスポートで不具合現象の対応
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
    /// 商品管理情報マスタマスタ（エクスポート）
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタマスタ（エクスポート）クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Note       : 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
    /// <br>Programmer : liusy</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Note       : 商品マスタエクスポートで不具合現象の対応。</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Note       : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/08/19</br>
    /// </remarks>
    public partial class PMKHN07270UA : Form, IExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// <br>Note        : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        public PMKHN07270UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応
        }
        #endregion

        #region ■ Private member
        // 商品管理情報マスタマスタ（エクスポート）アクセスクラス
        private GoodsMngExportAcs _goodsMngExportAcs;
        // 企業コード
        private string _enterpriseCode;
        // メーカーガイドアクセスクラス
        private GoodsAcs _goodsAcs;
        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;

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
        private const string ct_CLASSID = "PMKHN07270UA";
        private const string PMKHN07270U_PRPID = "PMKHN07270U.xml";
        private const string PRINTSET_TABLE = "GoodsMngExp";

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        //設定種別
        private const string SETKIND_1 = "拠点＋品番";
        private const string SETKIND_2 = "拠点＋中分類＋メーカー＋BLコード";
        private const string SETKIND_3 = "拠点＋中分類＋メーカー";
        private const string SETKIND_4 = "拠点＋メーカー";
        private const string SETKIND_5 = "全て";
        private const int SETKIND_1_VALUE = 0;
        private const int SETKIND_2_VALUE = 1;
        private const int SETKIND_3_VALUE = 2;
        private const int SETKIND_4_VALUE = 3;
        private const int SETKIND_5_VALUE = 4;
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

        //----- ADD 2019/08/19 田建委 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        // 最初から
        private const string StartStr = "最初から";
        // 最後まで
        private const string EndStr = "最後まで";
        // アセンブリID
        private const string AssemblyID = "PMKHN07270U";
        // アセンブリ名
        private const string AssemblyNm = "商品管理情報マスタ（エクスポート）";
        // メソッド名
        private const string MethodNm = "Extract";
        // 画面条件
        private const string MenuCon1 = "入力パターン：{0},拠点：{1} ～ {2},メーカー：{3} ～ {4},品番：{5} ～ {6},ﾃｷｽﾄﾌｧｲﾙ名：{7}";
        private const string MenuCon2 = "入力パターン：{0},拠点：{1} ～ {2},メーカー：{3} ～ {4},BLコード：{5} ～ {6},中分類：{7} ～ {8},ﾃｷｽﾄﾌｧｲﾙ名：{9}";
        private const string MenuCon3 = "入力パターン：{0},拠点：{1} ～ {2},メーカー：{3} ～ {4},中分類：{5} ～ {6},ﾃｷｽﾄﾌｧｲﾙ名：{7}";
        private const string MenuCon4 = "入力パターン：{0},拠点：{1} ～ {2},メーカー：{3} ～ {4},ﾃｷｽﾄﾌｧｲﾙ名：{5}";
        private const string MenuCon5 = "入力パターン：{0},拠点：{1} ～ {2},メーカー：{3} ～ {4},品番：{5} ～ {6},BLコード：{7} ～ {8},中分類：{9} ～ {10},ﾃｷｽﾄﾌｧｲﾙ名：{11}";
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
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
            // 入力パターン
            string inputCase = this.SetKind_tComboEditor.SelectedItem.DisplayText.Trim();
            // 拠点
            string sectionSt = this.tEdit_SectionCode_St.Text.Trim();
            sectionSt = string.IsNullOrEmpty(sectionSt) ? StartStr : sectionSt;
            string sectionEd = this.tEdit_SectionCode_Ed.Text.Trim();
            sectionEd = string.IsNullOrEmpty(sectionEd) ? EndStr : sectionEd;
            // メーカー
            string makerCodeSt = this.tNedit_GoodsMakerCd_St.Text.Trim();
            makerCodeSt = string.IsNullOrEmpty(makerCodeSt) ? StartStr : makerCodeSt;
            string makerCodeEd = this.tNedit_GoodsMakerCd_Ed.Text.Trim();
            makerCodeEd = string.IsNullOrEmpty(makerCodeEd) ? EndStr : makerCodeEd;
            // 品番
            string goodsNoSt = string.Empty;
            string goodsNoEd = string.Empty;
            // BLコード
            string blCodeSt = string.Empty;
            string blCodeEd = string.Empty;
            // 中分類
            string goodsMGroupSt = string.Empty;
            string goodsMGroupEd = string.Empty;
            // 出力ファイル名
            string filePath = this.tEdit_TextFileName.Text.Trim();
            // ログオペレーションデータ
            string logOperationData = string.Empty;
            switch (this.SetKind_tComboEditor.SelectedIndex)
            {
                // 拠点＋品番
                case 0:
                    // 品番
                    goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
                    goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
                    goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
                    goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
                    logOperationData = string.Format(MenuCon1, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsNoSt, goodsNoEd, filePath);
                    break;
                // 拠点＋中分類＋メーカー＋BLコード
                case 1:
                    // BLコード
                    blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
                    blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
                    blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
                    blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
                    // 中分類
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon2, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, blCodeSt, blCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                // 拠点＋中分類＋メーカー
                case 2:
                    // 中分類
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon3, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                // 拠点＋メーカー
                case 3:
                    logOperationData = string.Format(MenuCon4, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, filePath);
                    break;
                // 全て
                case 4:
                    // 品番
                    goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
                    goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
                    goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
                    goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
                    // BLコード
                    blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
                    blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
                    blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
                    blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
                    // 中分類
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon5, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsNoSt, goodsNoEd, blCodeSt, blCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                default:
                    // なし
                    break;
            }
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
            GoodsMngExport goodsMngExportWork = new GoodsMngExport();
            this.SetExtraInfoFromScreen(ref goodsMngExportWork);
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
                if (_goodsMngExportAcs == null) _goodsMngExportAcs = new GoodsMngExportAcs();
                status = this._goodsMngExportAcs.Search(goodsMngExportWork, out dataTable);
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
                        //データセットへ展開する
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ct_CLASSID, 						// アセンブリＩＤまたはクラスＩＤ
                            "商品管理情報マスタ（ｴｸｽﾎﾟｰﾄ）", 			// プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._goodsMngExportAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07270U_PRPID;
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
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
        /// 拠点コードガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 拠点コードガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // 拠点ガイド表示
            if (_secInfoSetAcs == null) _secInfoSetAcs = new SecInfoSetAcs();
            status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 拠点開始コード
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tEdit_SectionCode_St;
                    nextControl = this.tEdit_SectionCode_Ed;
                }
                // 拠点終了コード
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tEdit_SectionCode_Ed;
                    nextControl = this.tNedit_GoodsMakerCd_St;
                }
                else
                {
                    return;
                }
                // コード展開
                targetControl.DataText = secInfoSet.SectionCode.Trim();
                // フォーカス
                nextControl.Focus();
            }
            else
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.ub_SectionCodeStGuid;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    nextControl = this.ub_SectionCodeEdGuid;
                }
                nextControl.Focus();
            }

        }

        /// <summary>
        /// メーカーガイド起動ボタン起動イベント                                               
        /// </summary>
        /// <param name="sender">イベントソース</param>                              
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : メーカーガイドクリック時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>管理番号    : 10801804-00</br>
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
            // メーカーガイド表示
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;

            TNedit targetControl;
            Control nextControl = null;
            // メーカー開始コード
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            // メーカー終了コード
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
                if (SetKind_tComboEditor.Text == SETKIND_1 || SetKind_tComboEditor.Text == SETKIND_5)
                {
                    nextControl = this.tEdit_GoodsNo_St;

                }
                else if (SetKind_tComboEditor.Text == SETKIND_2)
                {
                    nextControl = this.tNedit_BLGoodsCode_St;
                }
                else if (SetKind_tComboEditor.Text == SETKIND_3)
                {
                    nextControl = this.tNedit_GoodsMGroup_St;
                }
                else
                {
                    nextControl = this.tEdit_TextFileName;
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
                //nextControl = this.tEdit_GoodsNo_St; //DEL liusy 2012/09/24 for Redmine#32367
            }
            else
            {
                return;
            }
            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd().PadLeft(4, '0');

            // 次フォーカス
            nextControl.Focus();
        }

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        /// <summary>
        /// Control.Click イベント(BLGoodsCodeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : BLコードガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : liusy</br>
        /// <br>Date        : 2012/09/24</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {

            // 検索条件の設定
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

            //BLコードガイド起動
            int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;


            TNedit targetControl;
            Control nextControl = null;
            // BL開始コード
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            // BL終了コード
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tNedit_GoodsMGroup_St;
            }
            else
            {
                return;
            }
            targetControl.DataText = bLGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd().PadLeft(5, '0');
            // 次フォーカス
            nextControl.Focus();
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note        : 中分類ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : liusy</br>
        /// <br>Date        : 2012/09/24</br>
        /// 
        private void uButton_GoodsMGroup_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            GoodsGroupU goodsMGroup;
            // ガイド起動
            int status = this._goodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
            TNedit targetControl;
            Control nextControl = null;
            // BL開始コード
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_St;
                nextControl = this.tNedit_GoodsMGroup_Ed;
            }
            // BL終了コード
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_Ed;
                nextControl = this.tEdit_TextFileName;
            }
            else
            {
                return;
            }
            targetControl.DataText = goodsMGroup.GoodsMGroup.ToString().TrimEnd().PadLeft(4, '0');
            // 次フォーカス
            nextControl.Focus();
        }
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
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
        /// <br>Date        : 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
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
        /// <br>Date        : 2012/06/05</br>  
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // --- DEL liusy 2012/09/24 for Redmine#32367---------->>>>>
            //if (!e.ShiftKey)
            //{
            //    if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //    {
            //        if (!"00".Equals(tEdit_SectionCode_St.Text.Trim().PadLeft(2, '0')))
            //            tEdit_SectionCode_St.Text = tEdit_SectionCode_St.Text.Trim().PadLeft(2, '0');
            //        else
            //            tEdit_SectionCode_St.Text = "";
            //    }
            //    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //    {
            //        if (!"00".Equals(tEdit_SectionCode_Ed.Text.Trim().PadLeft(2, '0')))
            //            tEdit_SectionCode_Ed.Text = tEdit_SectionCode_Ed.Text.Trim().PadLeft(2, '0');
            //        else
            //            tEdit_SectionCode_Ed.Text = "";
            //    }
            //    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //    {
            //        tNedit_GoodsMakerCd_St.Text = tNedit_GoodsMakerCd_St.Text.Trim().PadLeft(4, '0');
            //    }
            //    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //    {
            //        tNedit_GoodsMakerCd_Ed.Text = tNedit_GoodsMakerCd_Ed.Text.Trim().PadLeft(4, '0');
            //    }
            //    // SHIFTキー未押下
            //    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
            //    {
            //        if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //        {
            //            // 拠点(開始)→拠点(終了)
            //            e.NextCtrl = this.tEdit_SectionCode_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //        {
            //            // 拠点(終了)→メーカー(開始)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //        {
            //            // メーカー(開始)→メーカー(終了)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //        {
            //            // メーカー(終了)→品番(開始)
            //            e.NextCtrl = this.tEdit_GoodsNo_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
            //        {
            //            // 品番(開始)→品番(終了)
            //            e.NextCtrl = this.tEdit_GoodsNo_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            //        {
            //            // 品番(終了)→ ﾃｷｽﾄﾌｧｲﾙ名
            //            e.NextCtrl = this.tEdit_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_TextFileName)
            //        {
            //            // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
            //            e.NextCtrl = this.uButton_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.uButton_TextFileName)
            //        {
            //            // ファイルダイアログ→ メーカー(開始)
            //            e.NextCtrl = this.tEdit_SectionCode_St;
            //        }
            //    }
            //}
            //else
            //{
            //    // SHIFTキー押下
            //    if (e.Key == Keys.Tab)
            //    {
            //        if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //        {
            //            // 拠点(開始)→ファイルダイアログ
            //            e.NextCtrl = this.uButton_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //        {
            //            // 拠点(終了)→拠点(開始)
            //            e.NextCtrl = this.tEdit_SectionCode_St;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //        {
            //            // メーカー(開始)→ファイルダイアログ
            //            e.NextCtrl = this.tEdit_SectionCode_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //        {
            //            // メーカー(終了)→メーカー(開始)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
            //        {
            //            // 品番(開始)→ＢＬコード(終了)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            //        {
            //            // 品番(終了)→ 品番(開始)
            //            e.NextCtrl = this.tEdit_GoodsNo_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_TextFileName)
            //        {
            //            // ﾃｷｽﾄﾌｧｲﾙ名→ 品番(終了)
            //            e.NextCtrl = this.tEdit_GoodsNo_Ed;
            //        }
            //        else if (e.PrevCtrl == this.uButton_TextFileName)
            //        {
            //            // ファイルダイアログ→ ﾃｷｽﾄﾌｧｲﾙ名
            //            e.NextCtrl = this.tEdit_TextFileName;
            //        }
            //    }
            // --- DEL liusy 2012/09/24 for Redmine#32367----------<<<<<
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
        /// <br>Date        : 2012/06/05</br> 
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopyチェック
            WordCoopyCheck();
        }
        #endregion　■ Private Event

        #region ■ Control Event
        /// <summary>
        /// PMKHN07270UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void PMKHN07270UA_Load(object sender, EventArgs e)
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
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                "商品管理情報マスタ（ｴｸｽﾎﾟｰﾄ）",	// プログラム名称
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
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // メーカー
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // 拠点
            this.tEdit_SectionCode_Ed.Clear();
            this.tEdit_SectionCode_St.Clear();
            // 品番
            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();


            this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            //this.tEdit_SectionCode_St.Focus(); // DEL liusy 2012/09/24 for Redmine#32367
            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>> 
            // BLコード
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();
            // 中分類
            this.tNedit_GoodsMGroup_Ed.Clear();
            this.tNedit_GoodsMGroup_St.Clear();

            this.SetIconImage(this.ub_St_BLGoodsGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_BLGoodsGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_St_GoodsMGroupGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMGroupGuid, Size16_Index.STAR1);
            // 設定種別

            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_1_VALUE, SETKIND_1);
            this.SetKind_tComboEditor.Items.Add(SETKIND_2_VALUE, SETKIND_2);
            this.SetKind_tComboEditor.Items.Add(SETKIND_3_VALUE, SETKIND_3);
            this.SetKind_tComboEditor.Items.Add(SETKIND_4_VALUE, SETKIND_4);
            this.SetKind_tComboEditor.Items.Add(SETKIND_5_VALUE, SETKIND_5);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;
            this.SetKind_tComboEditor.SelectedIndex = 0;
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput();
        }
        #endregion

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
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
        /// <param name="goodsMngExportWork">抽出条件クラス</param>
        /// <remarks>
        /// <br>Note		: 検索情報処理を行う。</br>
        /// <br>Programmer	: 朱宝軍</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// <br>Update Note : 2012/11/13 李亜博</br>
        ///	<br>			  Redmine#32367 商品マスタエクスポートで不具合現象の対応</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(ref GoodsMngExport goodsMngExportWork)
        {
            // 企業コード
            goodsMngExportWork.EnterpriseCode = this._enterpriseCode;
            // メーカー開始
            goodsMngExportWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();

            // メーカー終了
            goodsMngExportWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

            // 拠点コード開始
            goodsMngExportWork.SectionCdSt = this.tEdit_SectionCode_St.DataText.TrimEnd();

            // 拠点コード終了
            goodsMngExportWork.SectionCdEd = this.tEdit_SectionCode_Ed.DataText.TrimEnd();

            // 品番開始
            goodsMngExportWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText.TrimEnd();

            // 品番終了
            goodsMngExportWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText.TrimEnd();

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            // BLコード開始
            goodsMngExportWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

            // BLコード終了
            goodsMngExportWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

            // 中分類開始
            goodsMngExportWork.GoodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();

            // 中分類終了
            goodsMngExportWork.GoodsMGroupEd = this.tNedit_GoodsMGroup_Ed.GetInt();
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD 李亜博 2012/11/13 for Redmine#32367---------->>>>>
            //設定種別
            goodsMngExportWork.SetKind = (Int32)this.SetKind_tComboEditor.Value;
            // --- ADD 李亜博 2012/11/13 for Redmine#32367----------<<<<<
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
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
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

            // 拠点（開始～終了）
            if ((this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("拠点{0}", ct_RANGEERROR);
                errComponent = this.tEdit_SectionCode_St;
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

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>

            // BLコード
            if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("BLコード{0}", ct_RANGEERROR);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // 中分類
            if ((this.tNedit_GoodsMGroup_St.GetInt() != 0) &&
                (this.tNedit_GoodsMGroup_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                errMessage = string.Format("中分類{0}", ct_RANGEERROR);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
                return status;
            }
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            return status;
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void WordCoopyCheck()
        {
            // 拠点コード
            Regex sectionRegex = new Regex(@"^\d+(\.)?\d*$");
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) && !sectionRegex.IsMatch(this.tEdit_SectionCode_St.DataText))
            {
                this.tEdit_SectionCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) && !sectionRegex.IsMatch(this.tEdit_SectionCode_Ed.DataText))
            {
                this.tEdit_SectionCode_Ed.Text = String.Empty;
            }
            // メーカー
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
            // 品番
            if (this.tEdit_GoodsNo_St.DataText.Contains("　") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("　") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex goodsRegex = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !goodsRegex.IsMatch(this.tEdit_GoodsNo_St.DataText.Trim()))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !goodsRegex.IsMatch(this.tEdit_GoodsNo_Ed.DataText.Trim()))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            //BLコード
            int bLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
            int bLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
            if (bLGoodsCodeSt == 0 && this.tNedit_GoodsMakerCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_St.Text = String.Empty;
            }
            if (bLGoodsCodeEd == 0 && this.tNedit_BLGoodsCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_Ed.Text = String.Empty;
            }

            //中分類
            int goodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();
            int goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.GetInt();
            if (goodsMGroupSt == 0 && this.tNedit_GoodsMGroup_St.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMGroup_St.Text = String.Empty;
            }
            if (goodsMGroupEd == 0 && this.tNedit_GoodsMGroup_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMGroup_Ed.Text = String.Empty;
            }
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
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
        /// <br>Date		: 2012/06/05</br>
        /// <br>管理番号    : 10801804-00</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        #region ◎ 設定種別変更イベント
        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別が変更されたときに発生します。</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2012/09/24</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {

            this.BLGoodsCode_Label.Location = new System.Drawing.Point(12, 188);
            this.BlCodeRange_Label.Location = new System.Drawing.Point(315, 188);
            this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(147, 188);
            this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(341, 188);
            this.ub_St_BLGoodsGuide.Location = new System.Drawing.Point(203, 188);
            this.ub_Ed_BLGoodsGuide.Location = new System.Drawing.Point(397, 188);

            this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 214);
            this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 214);
            this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 214);
            this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 214);
            this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 214);
            this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 214);

            //拠点＋品番
            if (this.SetKind_tComboEditor.Text == SETKIND_1)
            {

                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = false;
                this.tNedit_GoodsMGroup_Ed.Enabled = false;
                this.ub_St_GoodsMGroupGuid.Enabled = false;
                this.ub_Ed_GoodsMGroupGuid.Enabled = false;


                this.GoodNo_Label.Visible = true;
                this.GoodNoRange_Label.Visible = true;
                this.tEdit_GoodsNo_St.Visible = true;
                this.tEdit_GoodsNo_Ed.Visible = true;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = false;
                this.GoodMGroupRange_Label.Visible = false;
                this.tNedit_GoodsMGroup_St.Visible = false;
                this.tNedit_GoodsMGroup_Ed.Visible = false;
                this.ub_St_GoodsMGroupGuid.Visible = false;
                this.ub_Ed_GoodsMGroupGuid.Visible = false;
            }
            //拠点＋中分類＋メーカー＋BLコード
            else if (this.SetKind_tComboEditor.Text == SETKIND_2)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.ub_St_BLGoodsGuide.Enabled = true;
                this.ub_Ed_BLGoodsGuide.Enabled = true;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = true;
                this.BlCodeRange_Label.Visible = true;
                this.tNedit_BLGoodsCode_St.Visible = true;
                this.tNedit_BLGoodsCode_Ed.Visible = true;
                this.ub_St_BLGoodsGuide.Visible = true;
                this.ub_Ed_BLGoodsGuide.Visible = true;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;

                this.BLGoodsCode_Label.Location = new System.Drawing.Point(12, 136);
                this.BlCodeRange_Label.Location = new System.Drawing.Point(315, 136);
                this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(147, 136);
                this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(341, 136);
                this.ub_St_BLGoodsGuide.Location = new System.Drawing.Point(203, 136);
                this.ub_Ed_BLGoodsGuide.Location = new System.Drawing.Point(397, 136);

                this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 162);
                this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 162);
                this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 162);
                this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 162);
                this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 162);
                this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 162);
            }
            //拠点＋中分類＋メーカー
            else if (this.SetKind_tComboEditor.Text == SETKIND_3)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;

                this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 136);
                this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 136);
                this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 136);
                this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 136);
                this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 136);
                this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 136);
            }
            //　拠点＋メーカー
            else if (this.SetKind_tComboEditor.Text == SETKIND_4)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = false;
                this.tNedit_GoodsMGroup_Ed.Enabled = false;
                this.ub_St_GoodsMGroupGuid.Enabled = false;
                this.ub_Ed_GoodsMGroupGuid.Enabled = false;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = false;
                this.GoodMGroupRange_Label.Visible = false;
                this.tNedit_GoodsMGroup_St.Visible = false;
                this.tNedit_GoodsMGroup_Ed.Visible = false;
                this.ub_St_GoodsMGroupGuid.Visible = false;
                this.ub_Ed_GoodsMGroupGuid.Visible = false;
            }
            //全て
            else 
            {

                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.ub_St_BLGoodsGuide.Enabled = true;
                this.ub_Ed_BLGoodsGuide.Enabled = true;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = true;
                this.GoodNoRange_Label.Visible = true;
                this.tEdit_GoodsNo_St.Visible = true;
                this.tEdit_GoodsNo_Ed.Visible = true;

                this.BLGoodsCode_Label.Visible = true;
                this.BlCodeRange_Label.Visible = true;
                this.tNedit_BLGoodsCode_St.Visible = true;
                this.tNedit_BLGoodsCode_Ed.Visible = true;
                this.ub_St_BLGoodsGuide.Visible = true;
                this.ub_Ed_BLGoodsGuide.Visible = true;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;
            }

            this.tEdit_SectionCode_St.Clear();
            this.tEdit_SectionCode_Ed.Clear();

            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();

            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();

            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
        }
        #endregion
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        #endregion　■ Private Method


    }
}
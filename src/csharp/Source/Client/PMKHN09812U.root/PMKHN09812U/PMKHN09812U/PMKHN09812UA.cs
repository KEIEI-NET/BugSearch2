//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタエクスポート画面
// プログラム概要   : 掛率マスタエクスポート画面を表示する
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30521 本山　貴将 
// 修 正 日  2013.10.28  修正内容 : 掛け率マスタインポート・エクスポート機能追加対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 黒澤　直貴
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasExportAcs → RateTextExportAcs
//                                   StockMasShWork → RateTextShWork
//                                   ※一括置換の為、コメントなし
//----------------------------------------------------------------------------//

using System;
using System.Collections;
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  掛率マスタエクスポート画面
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタエクスポート画面クラスの定義</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br>Description: 掛率マスタエクスポート機能で共通の処理の定義</br>
    /// </remarks>
    public partial class PMKHN09812UA : Form, ICSVExportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2013/06/12</br>
        /// <br>>Description: 掛率マスタエクスポート機能の処理の定義</br>
        /// </remarks>
        public PMKHN09812UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _rateTextExportAcs = new RateTextExportAcs();
            _rateTextExportWork = new RateTextShWork();
            _secInfoSetAcs = new SecInfoSetAcs();  // Add 2013.10.28 T.MOTOYAMA

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();

            // ダミー実行（コンパイル時警告対応
            ExecCsvConvertEvent = null;
            if (null != ExecCsvConvertEvent)
            {
                int? dummyVal = 0;
                ExecCsvConvertEvent(null, ref dummyVal);
            }
        }
        #endregion

        #region ■ Private member
        // 掛率マスタエクスポート アクセサクラス
        private RateTextExportAcs _rateTextExportAcs;
        // 掛率マスタエクスポート 抽出条件クラスクラス
        private RateTextShWork _rateTextExportWork;

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        // 企業コード
        private string _enterpriseCode;

        #endregion ■ Private member

        #region  ■ Private cost

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        private const string UNITPRICEKIND_1 = "売価設定";
        private const string UNITPRICEKIND_2 = "原価設定";
        private const string UNITPRICEKIND_3 = "価格設定";
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        #endregion

        #region ■ ICSVExportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        /// <summary> イベント設定 </summary>
        /// <remarks> 得意先マスタのように、標準の処理では足りない場合に使用する</remarks>
        public event ExecCsvConvertEventHandler ExecCsvConvertEvent;

        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// 掛率マスタエクスポート前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 掛率マスタエクスポート前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = Properties.Resources.PRINTSET_TABLE;
        }

        /// <summary>
        /// 抽出データ処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this.uLabel_OutPutNum.Text = Properties.Resources.LabelTxtOutPutNum;
            // 画面→抽出条件クラス
            this.SetExtraInfoFromScreen();

            // メインフレームから以下の値を取得
            Dictionary<string, object> paramDic = parameter as Dictionary<string, object>;

            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;

            try
            {
                // 検索
                status = this._rateTextExportAcs.Search(_rateTextExportWork, out dataTable);
            }
            catch
            {
                dataTable = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
            }
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BLコードクラスをデータセットへ展開する
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        // ダイアログを閉じる
                        SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                        form = paramDic["formexport"] as SFCMN00299CA;
                        form.Close();

                        TMsgDisp.Show(						    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            Properties.Resources.ClassID,       // アセンブリＩＤまたはクラスＩＤ
                            Properties.Resources.ProgramName,   // プログラム名称
                            "Extract", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._rateTextExportAcs,            // エラーが発生したオブジェクト
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            ArrayList paramList = parameter as ArrayList;

            // 出力スキーマリスト
            List<string> schemeList = new List<string>();
            // 出力項目最大長さ
            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            // 拠点コード
            schemeList.Add("拠点コード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);
            // 単価掛率設定区分
            schemeList.Add("単価掛率設定区分");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // 単価種類
            schemeList.Add("単価種類");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // 掛率設定区分
            schemeList.Add("掛率設定区分");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);
            // 掛率設定区分(商品)
            schemeList.Add("掛率設定区分(商品)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // 掛率設定名称(商品)
            schemeList.Add("掛率設定名称(商品)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 50);
            // 掛率設定区分(得意先)
            schemeList.Add("掛率設定区分(得意先)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // 掛率設定名称(得意先)
            schemeList.Add("掛率設定名称(得意先)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 50);
            // 商品メーカーコード
            schemeList.Add("商品メーカーコード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 6);
            // 商品番号
            schemeList.Add("商品番号");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 40);
            // 商品掛率ランク
            schemeList.Add("商品掛率ランク");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 6);
            // 商品掛率グループコード
            schemeList.Add("商品掛率グループコード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // BLグループコード
            schemeList.Add("BLグループコード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // BL商品コード
            schemeList.Add("BL商品コード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 8);
            // 得意先コード
            schemeList.Add("得意先コード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // 得意先掛率グループコード
            schemeList.Add("得意先掛率グループコード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // 仕入先コード
            schemeList.Add("仕入先コード");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // ロット数
            schemeList.Add("ロット数");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // 価格(浮動)
            schemeList.Add("価格(浮動)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 12);
            // 掛率
            schemeList.Add("掛率");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // UP率
            schemeList.Add("UP率");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // 粗利確保率
            schemeList.Add("粗利確保率");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // 単価端数処理単位
            schemeList.Add("単価端数処理単位");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // 単価端数処理区分
            schemeList.Add("単価端数処理区分");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);

            paramList.Add(schemeList);
            paramList.Add(maxLengthList);
            paramList.Add(this.tEdit_TextFileName.DataText.ToString());
            
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
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
        /// 掛率マスタエクスポート完了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : テキスト変換完了処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            // 掛率マスタエクスポート完了後に画面の設定項目を保存する(PM7同等)
            this.uiMemInput1.WriteMemInput();

            this.uLabel_OutPutNum.Text =
                this.Bind_DataSet.Tables[Properties.Resources.PRINTSET_TABLE].DefaultView.Count.ToString(
                    Properties.Resources.LabelFmtOutPutNum);

            this.uLabel_OutPutNum.Text = String.Format("{0, 13}", this.uLabel_OutPutNum.Text);
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet　=new SecInfoSet();

            // 拠点ガイド表示
            if (_secInfoSetAcs == null)
                _secInfoSetAcs = new SecInfoSetAcs();
            try
            {
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
            }
            catch
            {
            }            
            
            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this._tEdit_SectionCode_St;
                    nextControl = this._tEdit_SectionCode_Ed;

                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    // 拠点名称(開始)
                    this.SectionCodeNm_tEdit_St.DataText = secInfoSet.SectionGuideNm;
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this._tEdit_SectionCode_Ed;
                    // nextControl = this.tNedit_ExpenseDivCd;    // Del 2013.10.28 T.MOTOYAMA
                    
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    nextControl = this.UnitPriceKind_tComboEditor;
                    
                    // 拠点名称(終了)
                    this.SectionCodeNm_tEdit_Ed.DataText = secInfoSet.SectionGuideNm;
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
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
        #endregion // ◆ ガイド検索

        #region  // Add 2013.10.28 T.MOTOYAMA 拠点名称取得処理
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCd">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note　　　 : 拠点名称を取得します</br>                 
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private String GetSectionName(string sectionCd)
        {
            int status = 0;
            string sectionName = "";

            SecInfoSet secInfoSet = new SecInfoSet();

            // 拠点アクセスクラス
            if (_secInfoSetAcs == null)
                _secInfoSetAcs = new SecInfoSetAcs();
            
            // 全社レコードの場合
            if (sectionCd == "0" || sectionCd == "00")
            {
                sectionName = "全社";
                return sectionName;
            }

            try
            {
                status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCd);
            }
            catch
            {
                // 拠点名称取得できなくても特に処理はしない
            }

            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }
            else
            {
                sectionName = "";
            }

            return sectionName;
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // タイトルバーの文字列
                saveFileDialog.Title = Properties.Resources.SaveFileDialogTitle;
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
                saveFileDialog.Filter = Properties.Resources.SaveFileDialogFilter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }
        #endregion // ◆ ファイルダイアログ

        #region ◆ ChangeFocus
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this._tEdit_SectionCode_St)
                    {
                        // 拠点(開始)→拠点ガイドボタン(開始)
                        // e.NextCtrl = this._tEdit_SectionCode_Ed;  // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.ub_SectionCodeStGuid;      // Add 2013.10.28 T.MOTOYAMA
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else if (e.PrevCtrl == this.ub_SectionCodeStGuid) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // 拠点ガイドボタン(開始)→拠点(終了)
                        e.NextCtrl = this._tEdit_SectionCode_Ed;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                    else if (e.PrevCtrl == this._tEdit_SectionCode_Ed)
                    {
                        // 拠点(終了)→拠点ガイドボタン(終了)
                        // e.NextCtrl = this.tNedit_ExpenseDivCd;     // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.ub_SectionCodeEdGuid; // Add 2013.10.28 T.MOTOYAMA
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else if (e.PrevCtrl == this.ub_SectionCodeEdGuid)
                    {
                        // 拠点ガイドボタン(終了)→単価種類
                        e.NextCtrl = this.UnitPriceKind_tComboEditor;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

                    // else if (e.PrevCtrl == this.tNedit_ExpenseDivCd)     // Del 2013.10.28 T.MOTOYAMA
                    else if (e.PrevCtrl == this.UnitPriceKind_tComboEditor) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // 単価種類→ ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ 拠点(開始)
                        e.NextCtrl = this._tEdit_SectionCode_St;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this._tEdit_SectionCode_St)
                    {
                        // 拠点(開始)→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this._tEdit_SectionCode_Ed)
                    {
                        // 拠点(終了)→拠点(開始)
                        e.NextCtrl = this._tEdit_SectionCode_St;
                    }
                    // else if (e.PrevCtrl == this.tNedit_ExpenseDivCd)     // Del 2013.10.28 T.MOTOYAMA
                    else if (e.PrevCtrl == this.UnitPriceKind_tComboEditor) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // 単価種類→拠点(終了)
                        e.NextCtrl = this._tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→単価種類
                        // e.NextCtrl = this.tNedit_ExpenseDivCd;     // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.UnitPriceKind_tComboEditor; // Add 2013.10.28 T.MOTOYAMA
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // ファイルダイアログ→ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            // Coopyチェック
            WordCopyCheck();
        }
        #endregion // ◆ ChangeFocus

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカス移動時に発生します</br>                 
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopyチェック
            WordCopyCheck();
        }
        #endregion　■ Private Event

        #region ■ Control Event
        /// <summary>
        /// PMKHN09812UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09812UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            if (ParentToolbarSettingEvent != null)
            {
                ParentToolbarSettingEvent(this);// ツールバーボタン設定イベント起動 
            }
        }
        #endregion

        #region ■ Private Method

        #region ◎ エラーメッセージ表示処理 ( +1のオーバーロード )
        /// <summary>エラーメッセージ表示処理</summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">エラーステータス</param>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                Properties.Resources.ClassID,       // アセンブリＩＤまたはクラスＩＤ
                Properties.Resources.ProgramName,   // プログラム名称
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
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 拠点
            this.ultraLabel5.Text = Properties.Resources.LabelTxtSection;
            this._tEdit_SectionCode_Ed.Clear();
            this._tEdit_SectionCode_St.Clear();

            // 単価種類
            this.ultraLabel4.Text = "単価種類";
            // this.tNedit_ExpenseDivCd.Clear();           // Del 2013.10.28 T.MOTOYAMA
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            this.UnitPriceKind_tComboEditor.Items.Clear();
            this.UnitPriceKind_tComboEditor.Items.Add("", "");
            this.UnitPriceKind_tComboEditor.Items.Add("1", UNITPRICEKIND_1);
            this.UnitPriceKind_tComboEditor.Items.Add("2", UNITPRICEKIND_2);
            this.UnitPriceKind_tComboEditor.Items.Add("3", UNITPRICEKIND_3);
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
            
            //ボタンアイコン設定
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput();
            this._tEdit_SectionCode_St.Focus();
        }
        #endregion

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this._tEdit_SectionCode_St);
            saveCtrAry.Add(this._tEdit_SectionCode_Ed);
            // saveCtrAry.Add(this.tNedit_ExpenseDivCd); // Del 2013.10.28 T.MOTOYAMA

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            saveCtrAry.Add(this.SectionCodeNm_tEdit_St);
            saveCtrAry.Add(this.SectionCodeNm_tEdit_Ed);
            saveCtrAry.Add(this.UnitPriceKind_tComboEditor);
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                        
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;

            // 画面Close時に画面情報を保存しない(PM7同等)
            this.uiMemInput1.WriteOnClose = false;

        }
        #endregion

        #region ◎ 検索情報処理
        /// <summary>
        /// 検索情報処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索情報処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // 企業コード
            _rateTextExportWork.EnterpriseCode = this._enterpriseCode;

            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //// 拠点コード(開始)
            //_stockMasExportWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.TrimEnd();

            //// 拠点コード(終了)
            //_stockMasExportWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.TrimEnd();
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (this._tEdit_SectionCode_St.Text == null)
                this._tEdit_SectionCode_St.Text = String.Empty;

            if (this._tEdit_SectionCode_Ed.Text == null)
                this._tEdit_SectionCode_Ed.Text = String.Empty;

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.Text.Trim()))
            {
                // 拠点コード(開始)
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_St.Text.PadLeft(2, '0');
            }
            else
            {
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_St.Text;
            }

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.Text.Trim()))
            {
                // 拠点コード(終了)
                _rateTextExportWork.SectionCodeEd = this._tEdit_SectionCode_Ed.Text.PadLeft(2, '0');
            }
            else
            {
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_Ed.Text;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            // 単価種類
            // _stockMasExportWork.WarehouseCdSt = this.tNedit_ExpenseDivCd.Text;  // Del 2013.10.28 T.MOTOYAMA
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                this.UnitPriceKind_tComboEditor.Value = "";
            }
            _rateTextExportWork.WarehouseCdSt = this.UnitPriceKind_tComboEditor.Value.ToString();
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
        }
        #endregion //◎ 検索情報処理

        #region ◎　入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopyチェック
            WordCopyCheck();
            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = Properties.Resources.MsgStrEmptyFileName;
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // ファイルの拡張子チェック
            string stExtension = System.IO.Path.GetExtension(fileName);

            if (stExtension == ".CSV" ||
                stExtension == ".csv")
            {                
            }
            else
            {
                errMessage = "拡張子が不正です。";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ファイル名に不正文字が含まれているかチェック
            try
            {
                // まずフォルダ存在のチェック
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    errMessage = Properties.Resources.MsgStrNotExistPath;
                    errComponent = this.tEdit_TextFileName;
                    status = false;
                    return status;
                }
                else
                {
                    string _fileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);

                    if (_fileName.IndexOf("/") >= 0 ||
                        _fileName.IndexOf(":") >= 0 ||
                        _fileName.IndexOf(";") >= 0 ||
                        _fileName.IndexOf("*") >= 0 ||
                        _fileName.IndexOf("?") >= 0 ||
                        _fileName.IndexOf("\"") >= 0 ||
                        _fileName.IndexOf("<") >= 0 ||
                        _fileName.IndexOf(">") >= 0 ||
                        _fileName.IndexOf("|") >= 0 ||
                        Path.GetFileNameWithoutExtension(_fileName).IndexOf(".") >= 0)
                    {
                        errMessage = Properties.Resources.MsgStrInvalidFileName;
                        errComponent = this.tEdit_TextFileName;
                        status = false;
                        return status;
                    }
                }
            }
            catch
            {
                errMessage = Properties.Resources.MsgStrNotExistPath;
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            // ファイルが使用中かどうかチェックする
            if (File.Exists(fileName) == true)
            {
                try
                {
                    Stream st = null;
                    st = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    if (st != null)
                    {
                        st.Close();
                        st.Dispose();
                    }
                    else
                    {
                        errMessage = Properties.Resources.MsgStrFileLocked;
                        return false;
                    }
                }
                catch
                {
                    errMessage = Properties.Resources.MsgStrFileLocked;
                    return false;
                }
            }

            // 拠点（開始～終了）
            if ((this._tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this._tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this._tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this._tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format(Properties.Resources.MsgStrRangeError, Properties.Resources.LabelTxtSection);
                errComponent = this._tEdit_SectionCode_St;
                status = false;
                return status;
            }
            
            return status;
        }

        /// <summary>
        /// Copyチェック処理                                              
        /// </summary>
        /// <remarks>
        /// <br>Note　　　 : Copy文字時に発生します</br>                  
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WordCopyCheck()
        {
            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //int warehouseStCode = this.tNedit_ExpenseDivCd.GetInt();
            //if (warehouseStCode == 0 && this.tNedit_ExpenseDivCd.Text.Trim().Length > 0)
            //{
            //    this.tNedit_ExpenseDivCd.Text = String.Empty;
            //}
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion

            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.DataText.TrimEnd()) && !r.IsMatch(this._tEdit_SectionCode_St.DataText))
            {
                this._tEdit_SectionCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this._tEdit_SectionCode_Ed.DataText))
            {
                this._tEdit_SectionCode_Ed.Text = String.Empty;
            }

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.Text.Trim()))
            {
                // 拠点コード(開始)
                this._tEdit_SectionCode_St.Text = this._tEdit_SectionCode_St.Text.PadLeft(2, '0');
                // 拠点名称(開始)
                this.SectionCodeNm_tEdit_St.Text = GetSectionName(this._tEdit_SectionCode_St.Text);
            }
            else
            {
                // 拠点名称(開始)
                this.SectionCodeNm_tEdit_St.Text = String.Empty;
            }

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.Text.Trim()))
            {
                // 拠点コード(終了)
                this._tEdit_SectionCode_Ed.Text = this._tEdit_SectionCode_Ed.Text.PadLeft(2, '0');
                // 拠点名称(終了)
                this.SectionCodeNm_tEdit_Ed.Text = GetSectionName(this._tEdit_SectionCode_Ed.Text);
            }
            else
            {
                // 拠点名称(終了)
                this.SectionCodeNm_tEdit_Ed.Text = String.Empty;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////                        
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコン設定処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion //◎ ボタンアイコン設定処理
        #endregion　//■ Private Method
    }
}
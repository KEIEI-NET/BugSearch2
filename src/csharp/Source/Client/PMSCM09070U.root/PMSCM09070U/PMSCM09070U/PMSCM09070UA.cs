//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   売上連携設定フォームクラス                    //
//                  :   PMSCM09070UA.DLL                              //
// Name Space       :   Broadleaf.Windows.Forms                       //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上連携設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上連携設定の設定を行います。</br>
    /// <br>Programmer       :   gaoy</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public partial class PMSCM09070UA : Form, IMasterMaintenanceSingleType
    {

        #region << Conductor >>

        /// <summary>
        /// 売上連携設定コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>note             :   売上連携設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/21</br>
        /// </remarks>
        public PMSCM09070UA()
        {

            InitializeComponent();

            //売上連携設定テーブルアクセスクラス
            this._pm7RkSettingAcs = new PM7RkSettingAcs();
            //売上連携設定UIクラス
            this._pm7RkSetting = new PM7RkSetting();
            this._pm7RkSettingDataSet = new PM7RkSetting();

            //企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //拠点コード取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pm7RkSetting.SectionCode = this._sectionCode;

            // 比較用クローン
            this._pm7RkSettingClone = null;

            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;

        }

        #endregion

        #region << Private Members >>

        private PM7RkSettingAcs _pm7RkSettingAcs;   //売上連携設定テーブルアクセスクラス
        private PM7RkSetting _pm7RkSetting;         //売上連携設定データクラス
        private PM7RkSetting _pm7RkSettingDataSet;  //売上連携設定データクラス

        private string _enterpriseCode;             //企業コード
        private string _sectionCode;                 //拠点コード

        // 比較用クローン
        private PM7RkSetting _pm7RkSettingClone;    //比較用売上連携設定データクラス

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;

        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";

        // 編集モード
        private const string UPDATE_MODE1 = "新規モード";
        private const string UPDATE_MODE2 = "更新モード";

        private const string CT_PGID = "PMSCM09070U";
        private const string CT_PGNM = "売上連携全体設定";

        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion

        #region << Events >>

        /// <summary>
        /// 画面非表示イベント
        /// </summary>
        /// <remarks>
        /// 画面が非表示状態になった際に発生します。
        /// </remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

        #region << Properties >>

        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion

        #region << Public Methods >>

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        public int Print()
        {
            return 0;

        }

        /// <summary>
        /// HTMLコード取得
        /// </summary>
        /// <returns>HTMLコード</returns>
        /// <remarks>
        /// <br>Note       : HTMLコードの取得を行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        public string GetHtmlCode()
        {
            const string ctPROCNM = "GetHtmlCode";
            string outCode = "";

            List<string> titleList = new List<string>();
            List<string> valueList = new List<string>();

            titleList.Add(HTML_HEADER_TITLE);               //「設定項目」
            valueList.Add(HTML_HEADER_VALUE);               //「設定値」
            titleList.Add(this.SalesRkAutoCode_ultraLabel.Text);     //売上連携自動区分
            titleList.Add(this.SalesRkAutoSndTime_ultraLabel.Text);  //売上連携自動送信間隔
            titleList.Add(this.MasterRkAutoCode_ultraLabel.Text);    //マスタ連携自動区分
            titleList.Add(this.MasterRkAutoRcvTime_ultraLabel.Text); //マスタ連携自動受信間隔
            titleList.Add(this.TextSaveFolder_ultraLabel.Text);          //テキスト格納フォルダ

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = this._pm7RkSettingAcs.Read(ref this._pm7RkSetting);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (this._pm7RkSetting != null)
                        {
                            this._pm7RkSettingDataSet = this._pm7RkSetting.Clone();

                            valueList.Add(this.SalesRkAutoCode_tComboEditor.Items.GetItem(this._pm7RkSetting.SalesRkAutoCode).ToString());
                            if (this._pm7RkSetting.SalesRkAutoCode == 1)
                            {
                                valueList.Add(this._pm7RkSetting.SalesRkAutoSndTime.ToString()+"分");
                            }
                            else
                            { 
                                valueList.Add("");
                            }
                            valueList.Add(this.MasterRkAutoCode_tComboEditor.Items.GetItem(this._pm7RkSetting.MasterRkAutoCode).ToString());
                            if (this._pm7RkSetting.MasterRkAutoCode == 1)
                            {
                                valueList.Add(this._pm7RkSetting.MasterRkAutoRcvTime.ToString() + "分");
                            }
                            else
                            {
                                valueList.Add("");
                            }
                            valueList.Add(this._pm7RkSetting.TextSaveFolder);
                        }
                        else
                        {
                            valueList.Add("しない");
                            valueList.Add(HTML_UNREGISTER);
                            valueList.Add("しない");
                            valueList.Add(HTML_UNREGISTER);
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;

                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        valueList.Add("しない");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add("しない");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add(HTML_UNREGISTER);
                        break;
                    }
                default:
                    {
                        //リード
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "読み込みに失敗しました。",           // 表示するメッセージ
                            status,                               // ステータス値
                            this._pm7RkSettingAcs,                 // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);     // 初期表示ボタン

                        // 未設定
                        valueList.Add("しない");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add("しない");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add(HTML_UNREGISTER);

                        break;
                    }
            }

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            string[,] array = new string[titleList.Count, 2];

            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                array[ix, 0] = titleList[ix];
                array[ix, 1] = valueList[ix];
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);

            return outCode;
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// データ編集画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            //売上連携自動区分
            this.SalesRkAutoCode_tComboEditor.Items.Clear();
            this.SalesRkAutoCode_tComboEditor.Items.Add(0, "しない");
            this.SalesRkAutoCode_tComboEditor.Items.Add(1, "する");
            this.SalesRkAutoCode_tComboEditor.MaxDropDownItems = this.SalesRkAutoCode_tComboEditor.Items.Count;
            this.SalesRkAutoCode_tComboEditor.SelectedIndex = 0;

            //マスタ連携自動区分
            this.MasterRkAutoCode_tComboEditor.Items.Clear();
            this.MasterRkAutoCode_tComboEditor.Items.Add(0, "しない");
            this.MasterRkAutoCode_tComboEditor.Items.Add(1, "する");
            this.MasterRkAutoCode_tComboEditor.MaxDropDownItems = this.SalesRkAutoCode_tComboEditor.Items.Count;
            this.MasterRkAutoCode_tComboEditor.SelectedIndex = 0;

            //テキスト格納フォルダIMEモード
            this.TextSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
        }

        /// <summary>
        /// 画面情報売上連携設定クラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から売上連携設定クラスにデータを格納します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenToPM7RkSetting()
        {
            if (this._pm7RkSetting == null)
            {
                this._pm7RkSetting = new PM7RkSetting();
            }

            //売上連携自動区分
            if (this.SalesRkAutoCode_tComboEditor.Value != null)
            {
                this._pm7RkSetting.SalesRkAutoCode = this.SalesRkAutoCode_tComboEditor.SelectedIndex;
            }

            //売上連携自動送信間隔
            try
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    this._pm7RkSetting.SalesRkAutoSndTime = 0; 
                }
                else
                {
                    this._pm7RkSetting.SalesRkAutoSndTime = Convert.ToInt64(this.SalesRkAutoSndTime_tEdit.Text.Trim());
                }
            }
            catch (Exception)
            {
                this._pm7RkSetting.SalesRkAutoSndTime = 0;
            }

            //マスタ連携自動区分
            if (this.MasterRkAutoCode_tComboEditor.Value != null)
            {
                this._pm7RkSetting.MasterRkAutoCode = this.MasterRkAutoCode_tComboEditor.SelectedIndex;
            }

            //マスタ連携自動受信間隔
            try
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    this._pm7RkSetting.MasterRkAutoRcvTime = 0;
                }
                else
                {
                    this._pm7RkSetting.MasterRkAutoRcvTime = Convert.ToInt64(this.MasterRkAutoRcvTime_tEdit.Text.Trim());
                }
            }
            catch (Exception)
            {
                this._pm7RkSetting.MasterRkAutoRcvTime = 0;
            }

            //テキスト格納フォルダ
            this._pm7RkSetting.TextSaveFolder = this.TextSaveFolder_tEdit.Text.TrimEnd();
        }

        /// <summary>
        /// 画面情報売上連携設定クラス格納処理(チェック用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から売上連携設定クラスにデータを格納します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void DispToPM7RkSetting(ref PM7RkSetting pm7RkSetting)
        {
            if (pm7RkSetting == null)
            {
                pm7RkSetting = new PM7RkSetting();
            }

            //売上連携自動区分
            if (this.SalesRkAutoCode_tComboEditor.Value != null)
            {
                pm7RkSetting.SalesRkAutoCode = this.SalesRkAutoCode_tComboEditor.SelectedIndex;
            }

            //売上連携自動送信間隔
            try
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    pm7RkSetting.SalesRkAutoSndTime = 0;
                }
                else
                {
                    pm7RkSetting.SalesRkAutoSndTime = Convert.ToInt64(this.SalesRkAutoSndTime_tEdit.Text.TrimEnd());
                }
            }
            catch (Exception)
            {
                pm7RkSetting.SalesRkAutoSndTime = 0;
            }

            //マスタ連携自動区分
            if (this.MasterRkAutoCode_tComboEditor.Value != null)
            {
                pm7RkSetting.MasterRkAutoCode = this.MasterRkAutoCode_tComboEditor.SelectedIndex;
            }

            //マスタ連携自動受信間隔
            try
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    pm7RkSetting.MasterRkAutoRcvTime = 0;
                }
                else
                {
                    pm7RkSetting.MasterRkAutoRcvTime = Convert.ToInt64(this.MasterRkAutoRcvTime_tEdit.Text.TrimEnd());
                }
            }
            catch (Exception)
            {
                pm7RkSetting.MasterRkAutoRcvTime = 0;
            }
            //テキスト格納フォルダ
            pm7RkSetting.TextSaveFolder = this.TextSaveFolder_tEdit.Text.TrimEnd();
           
        }

        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上連携設定クラスから画面にデータを展開します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void PM7RkSettingToScreen()
        {
            //売上連携自動区分
            this.SalesRkAutoCode_tComboEditor.SelectedIndex = this._pm7RkSetting.SalesRkAutoCode;
            
            //売上連携自動送信間隔
            if (this._pm7RkSetting.SalesRkAutoCode == 1)
            {
                this.SalesRkAutoSndTime_tEdit.Text = this._pm7RkSetting.SalesRkAutoSndTime.ToString();
            }
            else 
            {
                this.SalesRkAutoSndTime_tEdit.Text = "";
            }
            
            //マスタ連携自動区分
            this.MasterRkAutoCode_tComboEditor.SelectedIndex = this._pm7RkSetting.MasterRkAutoCode;

            //マスタ連携自動受信間隔
            if (this._pm7RkSetting.MasterRkAutoCode == 1)
            {
                this.MasterRkAutoRcvTime_tEdit.Text = this._pm7RkSetting.MasterRkAutoRcvTime.ToString();
            }
            else
            {
                this.MasterRkAutoRcvTime_tEdit.Text = ""; 
            }
            
            //テキスト格納フォルダ
            this.TextSaveFolder_tEdit.Text = this._pm7RkSetting.TextSaveFolder;

        }


        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SalesRkAutoSndTime_tEdit.Clear();
            this.MasterRkAutoRcvTime_tEdit.Clear();
            this.TextSaveFolder_tEdit.Clear();
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築処理します</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._pm7RkSettingDataSet == null)
            {
                this.Mode_ultraLabel.Text = UPDATE_MODE1;   //新規モード

                this.SalesRkAutoCode_tComboEditor.SelectedIndex = 0;
                this.SalesRkAutoSndTime_tEdit.Text = "";
                this.MasterRkAutoCode_tComboEditor.SelectedIndex = 0;
                this.MasterRkAutoRcvTime_tEdit.Text = "";
                this.TextSaveFolder_tEdit.Text = "";

                // 初期フォーカスをセット
                this.SalesRkAutoCode_tComboEditor.Focus();

                this._pm7RkSetting = new PM7RkSetting();

                // 比較用クローン作成
                this._pm7RkSettingClone = this._pm7RkSetting.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToPM7RkSetting(ref this._pm7RkSettingClone);

            }

            this.Mode_ultraLabel.Text = UPDATE_MODE2;   //更新モード

            this._pm7RkSetting = this._pm7RkSettingDataSet.Clone();

            //画面展開処理
            this.PM7RkSettingToScreen();

            // 初期フォーカスをセット
            this.SalesRkAutoCode_tComboEditor.Focus();

            // 比較用クローン作成
            this._pm7RkSettingClone = this._pm7RkSetting.Clone();
            // 画面情報を比較用クローンにコピー
            this.DispToPM7RkSetting(ref this._pm7RkSettingClone);

        }

        /// <summary>
        /// 画面のデータチェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面項目の入力チェックを行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string errorMessage)
        {
            bool result = false;
            //必須入力チェック
            //売上連携自動送信間隔条件必須
            if (this.SalesRkAutoCode_tComboEditor.Text == "する")
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    control = this.SalesRkAutoSndTime_tEdit;
                    errorMessage = this.SalesRkAutoSndTime_ultraLabel.Text + "を入力して下さい。";
                    return result;
                }
            }
            //マスタ連携自動受信間隔条件必須
            if (this.MasterRkAutoCode_tComboEditor.Text == "する")
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    control = this.MasterRkAutoRcvTime_tEdit;
                    errorMessage = this.MasterRkAutoRcvTime_ultraLabel.Text + "を入力して下さい。";
                    return result;
                }
            }
            //テキスト格納フォルダ必須入力チェック
            if (this.TextSaveFolder_tEdit.Text.Trim() == "")
            {
                control = this.TextSaveFolder_tEdit;
                errorMessage = this.TextSaveFolder_ultraLabel.Text + "を入力して下さい。";
                return result;
            }

            //売上連携自動送信間隔
            if (this.SalesRkAutoCode_tComboEditor.Text == "する")
            {
                try
                {
                    if (this.SalesRkAutoSndTime_tEdit.Text.Trim() != "" && Int64.Parse(this.SalesRkAutoSndTime_tEdit.Text.Trim()) <= 4)
                    {
                        this.SalesRkAutoSndTime_tEdit.Clear();
                        control = this.SalesRkAutoSndTime_tEdit;
                        errorMessage = this.SalesRkAutoSndTime_ultraLabel.Text + "の値を５分以上で入力してください。";
                        return result;
                    }
                }
                catch (Exception)
                {
                    this.SalesRkAutoSndTime_tEdit.Clear();
                    control = this.SalesRkAutoSndTime_tEdit;
                    errorMessage = "自動送信間隔を数値で入力してください。";
                    return result;
                }
            }

            //マスタ連携自動受信間隔
            if (this.MasterRkAutoCode_tComboEditor.Text == "する")
            {
                try
                {
                    if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() != "" && Int64.Parse(this.MasterRkAutoRcvTime_tEdit.Text.Trim()) <= 4)
                    {
                        this.MasterRkAutoRcvTime_tEdit.Clear();
                        control = this.MasterRkAutoRcvTime_tEdit;
                        errorMessage = this.MasterRkAutoRcvTime_ultraLabel.Text + "の値を５分以上で入力してください。";
                        return result;
                    }
                }
                catch (Exception)
                {
                    this.MasterRkAutoRcvTime_tEdit.Clear();
                    control = this.MasterRkAutoRcvTime_tEdit;
                    errorMessage = "自動受信間隔を数値で入力してください。";
                    return result;
                }
            }

            //テキスト格納フォルダ有効性チェック
            if (this.TextSaveFolder_tEdit.Text.Trim() != "" && !Directory.Exists(this.TextSaveFolder_tEdit.Text))
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "指定したフォルダが存在しません。";
                return result;
            }
            else if (this.TextSaveFolder_tEdit.Text.Length >= 129)
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "指定したフォルダの長さが128桁を超えました。";
                return result;
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : 全体項目表示名称の保存を行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = "";
            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    message,                               // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.OK);                // 表示するボタン

                // コントロールを選択
                control.Focus();
                if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            this.ScreenToPM7RkSetting();

            this._pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pm7RkSetting.SectionCode = this._sectionCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = this._pm7RkSettingAcs.Write(ref this._pm7RkSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                                    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
                            CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",    // 表示するメッセージ
                            0,                                       // ステータス値
                            MessageBoxButtons.OK);                   // 表示するボタン

                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "登録に失敗しました。",               // 表示するメッセージ
                            status,                               // ステータス値
                            this._pm7RkSettingAcs,              // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);     // 初期表示ボタン

                        this.CloseForm(DialogResult.Cancel);

                        return result;
                    }
            }
            return result;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベン
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // 比較用クローンクリア
            this._pm7RkSettingClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region << Control Events >>

        /// <summary>
        /// Form.Load イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks> 
        private void PMSCM09070UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Save_uButton.ImageList = imageList24;
            this.Cancel_uButton.ImageList = imageList24;
            this.DirGuide_uButton.ImageList = imageList16;

            this.Save_uButton.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_uButton.Appearance.Image = Size24_Index.CLOSE;
            this.DirGuide_uButton.Appearance.Image = Size16_Index.STAR1;

            this.ScreenInitialSetting();
        }

        /// <summary>
        /// Form.FormClosing イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void PMSCM09070UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._pm7RkSettingClone = null;

            // ユーザーによって閉じられる場合
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.Load イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks> 
        private void PMSCM09070UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // データがセットされていたら抜ける
            if (this._pm7RkSettingClone != null)
            {
                return;
            }

            this.Initial_Timer.Enabled = true;
            //// 画面クリア
            this.ScreenClear();
        }

        /// <summary>
        /// Initial_Timer_Tick イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;
            this.ScreenReconstruction();
        }

        /// <summary>
        /// ValueChanged イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントのvalueが変更されたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void SalesRkAutoCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesRkAutoCode_tComboEditor.SelectedIndex == 1)
            {
                this.SalesRkAutoSndTime_tEdit.Enabled = true;
            }
            //売上連携自動送信間隔入力不可能
            else
            {
                this.SalesRkAutoSndTime_tEdit.Clear();
                this.SalesRkAutoSndTime_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// ValueChanged イベント (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントのvalueが変更されたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void MasterRkAutoCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.MasterRkAutoCode_tComboEditor.SelectedIndex == 1)
            {
                this.MasterRkAutoRcvTime_tEdit.Enabled = true;
            }
            //マスタ連携自動受信間隔入力不可能
            else
            {
                this.MasterRkAutoRcvTime_tEdit.Clear();
                this.MasterRkAutoRcvTime_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// Control.Click イベント(DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : テキスト格納フォルダボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void DirGuide_uButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "テキスト格納フォルダ選択";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    TextSaveFolder_tEdit.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Control.MouseHover イベント(DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : テキスト格納フォルダボタンコントロールがMouseHoverされたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private void DirGuide_uButton_MouseHover(object sender, EventArgs e)
        {
            this.DirGuide_uButton.Refresh();
            this.toolTip1.SetToolTip(this.DirGuide_uButton, "テキスト格納フォルダガイド");
        }

        /// <summary>
        /// UltraButton.Click イベント (Save_uButton_Click)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Save_uButton_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // フォームを閉じる
            this.CloseForm(DialogResult.OK);

        }


        /// <summary>
        /// UltraButton.Click イベント (Cancel_uButton_Click)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Cancel_uButton_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;

            PM7RkSetting comparePM7RkSetting = new PM7RkSetting();

            comparePM7RkSetting = this._pm7RkSettingClone.Clone();

            this.DispToPM7RkSetting(ref comparePM7RkSetting);

            if (comparePM7RkSetting.Equals(this._pm7RkSettingClone) == false)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                DialogResult res = TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    null,                                  // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.YesNoCancel);       // 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (this.SaveProc() == false)
                            {
                                return;
                            }
                            result = DialogResult.OK;
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            this.Cancel_uButton.Focus();
                            return;
                        }
                }
            }

            // 画面を閉じる
            this.CloseForm(result);
        }

        #endregion

    }
}
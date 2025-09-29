using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    public partial class PMJKN09011UF : Form
    {
        /// <summary>
        /// 引用登録 フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 引用登録 フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpDate</br>
        /// <br>2010.05.22 葛軍 RedMine#8049</br>
        /// </remarks>
        //public PMJKN09011UF(ArrayList fspFullRowRestList, ArrayList fspOneRowRestList)// DEL 2010/05/22 GEJUN FOR REDMINE#8049
        public PMJKN09011UF(ArrayList fspFullRowRestList, ArrayList fspOneRowRestList, FreeSearchModel freeSearchModel)// ADD 2010/05/22 GEJUN FOR REDMINE#8049
        {
            InitializeComponent();
            this._fspFullRowRestList = fspFullRowRestList;
            this._fspOneRowRestList = fspOneRowRestList;
            this._freeSearchModel = freeSearchModel;    // ADD 2010/05/22 GEJUN FOR REDMINE#8049
        }

        # region Private Members
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        // 明細行全てのデータリスト
        private ArrayList _fspFullRowRestList;
        // カーソル行のみのデータ
        private ArrayList _fspOneRowRestList;
        // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
        // 排ガス記号
        private string _exhaustGasSign;
        // シリーズ型式
        private string _seriesModel;
        // 型式（類別記号）
        private string _categorySignModel;
        // 自由検索型式データ
        private FreeSearchModel _freeSearchModel;
        // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        # endregion

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void PMJKN09011UF_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_ModelFullGuide.ImageList = imageList16;
            this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.QuoteMode_OptionSet.CheckedIndex = 0;
        }

        /// <summary>
        /// 保存データチェック処理
        /// </summary>
        /// <returns></returns>
        private bool CheckSaveData()
        {
            bool flg = true;

            #region 画面入力値チェック
            // 車種
            if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text))
            {
                if (this.tNedit_MakerCode.GetInt() == 0
                    && this.tNedit_ModelCode.GetInt() == 0
                    && this.tNedit_ModelSubCode.GetInt() == 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "車種を入力して下さい。",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "車種が入力不正です。",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }

                // 指定フォーカス設定処理
                this.tNedit_MakerCode.Focus();

                return false;
            }

            // 型式
            if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "型式を入力して下さい。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                // 指定フォーカス設定処理
                this.tEdit_FullModel.Focus();

                return false;
            }

            // 型式の判断
            if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
            {
                string fullModel = this.tEdit_FullModel.Text;

                bool flag = false;
                flag = this.CheckModelName(fullModel);

                if (!flag)
                {
                    this.tEdit_FullModel.Focus();
                    return false;
                }
            }
            #endregion

            return flg;
        }
        #region [型式（フル型）の判断]
        /// <summary>
        /// 型式（フル型）の判断処理
        /// </summary>
        /// <param name="fullModels">型式結果</param>
        /// <param name="modelName">型式（フル型）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private bool CheckModelName(string modelName)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(modelName))
            {
                msg = "型式を入力して下さい。";
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }

            //型式（フル型）
            string[] fullModels = modelName.Split('-');

            //if (fullModels.Length < 3)
            //{
            //    msg = "型式が入力不正です。";
            //    // メッセージを表示
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
            //    return false;
            //}

            string zrModel = string.Empty;
            string frModel = string.Empty;
            string sdModel = string.Empty;

            //先頭の要素が４桁以上のため、第１要素が存在しない
            if (fullModels[0].Length >= 4)
            {
                //msg = "型式０を入力して下さい。";
                //// メッセージを表示
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                //return false;
                frModel = fullModels[0]; // 型式１にする
                for (int i = 1; i < fullModels.Length; i++)
                {
                    sdModel += fullModels[i];
                    if (i != fullModels.Length - 1)
                    {
                        sdModel += "-";
                    }
                } // 型式２
            }
            else
            {
                zrModel = fullModels[0]; // 型式０
                if (fullModels.Length > 1)
                {
                    frModel = fullModels[1]; // 型式１
                    for (int i = 2; i < fullModels.Length; i++)
                    {
                        sdModel += fullModels[i];
                        if (i != fullModels.Length - 1)
                        {
                            sdModel += "-";
                        }
                    } // 型式２
                }
            }

            if (zrModel.Length >= 5)
            {
                msg = "型式０を４文字以下にして下さい。";
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }
            if (frModel.Length >= 16)
            {
                msg = "型式１を１５文字以下にして下さい。";
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }
            if (sdModel.Length >= 16)
            {
                msg = "型式２を１５文字以下にして下さい。";
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }

            // ADD START 2010/05/22 GEJUN FOR REDMINE#8049

            // 分解した結果、型式２が0桁の場合
            if (String.IsNullOrEmpty(sdModel))
            {
                // 型式１の桁数が0桁の場合は、型式０を型式１とする
                if (String.IsNullOrEmpty(frModel))
                {
                    frModel = zrModel;
                    zrModel = string.Empty;
                }
                // 型式０が存在し、型式１が数字で始まる場合は、型式０を型式１、型式１を型式２とする
                if (!String.IsNullOrEmpty(zrModel)
                    && (!String.IsNullOrEmpty(frModel) && frModel.ToCharArray()[0] <= '9' && frModel.ToCharArray()[0] >= '0'))
                {
                    sdModel = frModel;
                    frModel = zrModel;
                    zrModel = string.Empty;
                }
            }
            this._exhaustGasSign = zrModel;
            this._seriesModel = frModel;
            this._categorySignModel = sdModel;
            // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
            return true;
        }
        #endregion

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer  : 肖緒徳</br>
        /// <br>Date        : 2010.04.26</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,        // エラーレベル
                "PMJKN09011UF",      // アセンブリＩＤまたはクラスＩＤ
                "引用登録",            // プログラム名称
                "",         // 処理名称
                "",         // オペレーション
                message,       // 表示するメッセージ
                status,        // ステータス値
                null,         // エラーが発生したオブジェクト
                MessageBoxButtons.OK,     // 表示するボタン
                MessageBoxDefaultButton.Button1); // 初期表示ボタン
        }


        /// <summary>
        /// 車種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode = this.tNedit_MakerCode.GetInt();

            int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
                this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
                this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;

                this.tEdit_FullModel.Focus();
            }
        }


        /// <summary>
        /// tNedit_MakerCode_ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tNedit_MakerCode_ValueChanged(object sender, EventArgs e)
        {
            string makerCode = this.tNedit_MakerCode.Text;
            if (string.IsNullOrEmpty(makerCode))
            {
                //車種ｺｰﾄ
                this.tNedit_ModelCode.Clear();
                this.tNedit_ModelCode.Enabled = false;
                //車種呼称ｺｰﾄ
                this.tNedit_ModelSubCode.Clear();
                this.tNedit_ModelSubCode.Enabled = false;
                //車種名称
                this.tEdit_ModelFullName.Clear();
            }
            else
            {
                //車種ｺｰﾄ
                this.tNedit_ModelCode.Enabled = true;
            }
        }

        /// <summary>
        /// tNedit_ModelCode_ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tNedit_ModelCode_ValueChanged(object sender, EventArgs e)
        {
            string modelCode = this.tNedit_ModelCode.Text;
            if (string.IsNullOrEmpty(modelCode))
            {
                //車種呼称ｺｰﾄ
                this.tNedit_ModelSubCode.Clear();
                this.tNedit_ModelSubCode.Enabled = false;
                //車種名称
                this.tEdit_ModelFullName.Clear();
            }
            else
            {
                //車種呼称ｺｰﾄ
                this.tNedit_ModelSubCode.Enabled = true;
            }
        }

        /// <summary>
        /// tNedit_ModelSubCode_ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tNedit_ModelSubCode_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tNedit_ModelSubCode.Text))
            {
                //車種名称
                this.tEdit_ModelFullName.Clear();
            }
        }

        /// <summary>
        /// tNedit_ModelSubCode_AfterExitEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
        {
            TNedit tNedit = (TNedit)sender;// ADD 2010/05/22 GEJUN FOR REDMINE#8049
            //ｶｰﾒｰｶｰｺｰﾄ
            string makerCode = this.tNedit_MakerCode.Text;
            //車種ｺｰﾄ
            string modelCode = this.tNedit_ModelCode.Text;
            //車種呼称ｺｰﾄ
            string modelSubCode = this.tNedit_ModelSubCode.Text;
            MakerAcs makerAcs = new MakerAcs();// ADD 2010/05/22 GEJUN FOR REDMINE#8049
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            MakerUMnt makerUMnt; // ADD 2010/05/22 GEJUN FOR REDMINE#8049
            ModelNameU modelNameU;
            // DEL START 2010/05/22 GEJUN FOR REDMINE#8049
            //if (!string.IsNullOrEmpty(makerCode) && !string.IsNullOrEmpty(modelCode) && !string.IsNullOrEmpty(modelSubCode))
            //{
            //    int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
            //    }
            //}
            // DEL END 2010/05/22 GEJUN FOR REDMINE#8049
            // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
            if (!string.IsNullOrEmpty(makerCode))
            {
                if ((this.tNedit_MakerCode.GetInt() != 0) && (this.tNedit_ModelCode.GetInt() == 0))
                {
                    //メーカーデータの取得
                    int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_MakerCode.GetInt());
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //メーカー
                        this.tNedit_MakerCode.SetInt(makerUMnt.GoodsMakerCd);
                        this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
                    }
                    else
                    {
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "該当データがありません。",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
                    }
                }
                else if (this.tNedit_ModelCode.GetInt() != 0)
                {
                    int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
                        if (modelNameU.ModelCode != 0)
                        {
                            this.tNedit_ModelCode.Text = modelNameU.ModelCode.ToString("000");
                        }
                        if (modelNameU.ModelSubCode != 0)
                        {
                            this.tNedit_ModelSubCode.Text = modelNameU.ModelSubCode.ToString("000");
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "該当データがありません。",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
                    }
                }
            }
            // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (CheckSaveData())
            {

                if (this._fspFullRowRestList.Count > 0 && this._fspOneRowRestList.Count > 0)
                {
                    FreeSearchPartsAcs freeSearchPartsAcs = new FreeSearchPartsAcs();
                    ArrayList retList = new ArrayList();
                    if (this.QuoteMode_OptionSet.CheckedIndex == 0)
                    {
                        foreach (FreeSearchParts freeSearchPartsPara in this._fspFullRowRestList)
                        {
                            //メーカーコード			画面車輌情報		 ｶｰﾒｰｶｰｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.MakerCode = this.tNedit_MakerCode.GetInt();
                            //車種コード			画面車輌情報		車種ｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.ModelCode = this.tNedit_ModelCode.GetInt();
                            //車種サブコード			画面車輌情報		車種呼称ｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
                            //型式（フル型）			画面車輌情報		型式をｾｯﾄ
                            freeSearchPartsPara.FullModel = this.tEdit_FullModel.Text;
                            //UpdateDateTime
                            freeSearchPartsPara.UpdateDateTime = DateTime.MinValue;
                            //自由検索部品固有番号
                            freeSearchPartsPara.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                            retList.Add(freeSearchPartsPara);
                        }
                    }
                    else
                    {
                        foreach (FreeSearchParts freeSearchPartsPara in this._fspOneRowRestList)
                        {
                            //メーカーコード			画面車輌情報		 ｶｰﾒｰｶｰｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.MakerCode = this.tNedit_MakerCode.GetInt();
                            //車種コード			画面車輌情報		車種ｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.ModelCode = this.tNedit_ModelCode.GetInt();
                            //車種サブコード			画面車輌情報		車種呼称ｺｰﾄﾞをｾｯﾄ
                            freeSearchPartsPara.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
                            //型式（フル型）			画面車輌情報		型式をｾｯﾄ
                            freeSearchPartsPara.FullModel = this.tEdit_FullModel.Text;
                            //UpdateDateTime
                            freeSearchPartsPara.UpdateDateTime = DateTime.MinValue;
                            //自由検索部品固有番号
                            freeSearchPartsPara.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                            retList.Add(freeSearchPartsPara);
                        }

                    }
                    int status = freeSearchPartsAcs.Write(ref retList);

                    // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
                    // 画面情報自由検索型式マスタの更新
                    this._freeSearchModel.LogicalDeleteCode = 0;
                    this._freeSearchModel.EnterpriseCode = this._enterpriseCode;
                    this._freeSearchModel.FreeSrchMdlFxdNo = Guid.NewGuid().ToString().Replace("-", "");
                    this._freeSearchModel.MakerCode = this.tNedit_MakerCode.GetInt(); //メーカーコード
                    this._freeSearchModel.ModelCode = this.tNedit_ModelCode.GetInt(); // 車種コード
                    this._freeSearchModel.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // 車種サブコード
                    this._freeSearchModel.FullModel = this.tEdit_FullModel.Text.ToUpper(); // 型式（フル型）
                    this._freeSearchModel.ExhaustGasSign = this._exhaustGasSign;
                    this._freeSearchModel.SeriesModel = this._seriesModel;
                    this._freeSearchModel.CategorySignModel = this._categorySignModel;
                    // 作成日付
                    int createDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);
                    this._freeSearchModel.CreateDate = createDate;
                    // 更新年月日
                    this._freeSearchModel.UpdateDate = createDate;

                    FreeSearchModelAcs freeSearchModelAcs = new FreeSearchModelAcs();
                    freeSearchModelAcs.Write(ref _freeSearchModel);
                    // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
                    //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    //ADD END 2009/05/22 GEJUN FOR REDMINE#8049

                }
                this.Close();
            }
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FullModel":
                    {
                        this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
                        break;
                    }
            }
        }
    }
}
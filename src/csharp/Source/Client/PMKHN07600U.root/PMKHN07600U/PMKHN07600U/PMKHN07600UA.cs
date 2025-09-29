//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/06/13  修正内容 : 大陽案件、Redmine#30391 在庫マスタインボートチェックの追加//
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/06/27  修正内容 : 内部発見バッグの対応：大小写について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/06/28  修正内容 : 内部発見バッグの対応：ログファイル形について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/06/29  修正内容 : 内部発見バッグの対応：ログファイルの名について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/03  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタ（インポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ（インポート） UIフォームクラス</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2012/07/20 zhangy3 </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
    /// </remarks>
    public partial class PMKHN07600UA : Form, IImportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 在庫マスタ（インポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07600UA()
        {
            InitializeComponent();

            // 在庫マスタ（インポート）のアクセス
            this._stockImportAcs = new StockImportAcs();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IImportConditionInpTypeのプロパティ用変数 ----------------------------------
        #endregion ◆ Interface member
        // 在庫マスタ（インポート）のアクセス
        private StockImportAcs _stockImportAcs;
        // 企業コード
        private string _enterpriseCode = "";
        // 読込件数
        private Int32 _readCnt = 0;
        // 追加件数
        private Int32 _addCnt = 0;
        // 更新件数
        private Int32 _updCnt = 0;
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        // エラー件数
        private Int32 _errCnt = 0;
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        #endregion ■ Private Member

        #region ■ Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "追加更新";
        private const string ct_AddNm = "追加";
        private const string ct_UpdNm = "更新";
        // ------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387--------->>>>
        private const int ct_DataCheckOn = 1;
        private const int ct_DataCheckOff = 0;
        private const string ct_DataCheckOnNm = "あり";
        private const string ct_DataCheckOffNm = "なし";
        // ------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387---------<<<<
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        // エラーログが出力する時、確認メッセージ
        private const string ERRORLOG_EXPORT_MSG = "インポートに失敗した行があります。\r\n{0}を参照して下さい。";
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        // クラスID
        private const string ct_ClassID = "PMKHN07600UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07600U";
        // CSV名称
        private string _printName = "在庫マスタ（インポート）";
        #endregion

        #region ■ IImportConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Method
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面表示を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // 画面表示
            this.Show();
            
            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = "0";

            return;
        }

        /// <summary>
        /// ベースでチェック処理を行うかどうか。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースでチェック処理を行うかどうか。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool IsUseBaseCheck()
        {
            // ベースでチェック処理を行う。
            return true;
        }

        /// <summary>
        /// チェックしたいテキストファイル名
        /// </summary>
        /// <remarks>
        /// <br>Note	   : チェックしたいテキストファイル名を戻る。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public string ImportFileName()
        {
            return this.tEdit_TextFileName.DataText;
        }

        /// <summary>
        /// 特にチェックがあれば実装する。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 特にチェックがあれば実装する、なければTrueを戻る。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            // 実装しない
            return true;
        }

        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: zhangy3</br>
        /// <br>Date		: 2012/06/13</br>
        /// <br>Update Note : 2012/07/03 zhangy3 </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        //private bool ScreenInputCheck()//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
        private bool ScreenInputCheck(out string errLogPath)//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
        {
            bool status = true;
            string errMessage = string.Empty;
            string fileName = tEdit_TextFileName.DataText.Trim();
            string text = tEdit_LogFileName.DataText.Trim();
            errLogPath = tEdit_LogFileName.DataText.Trim();//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
            //パス入力しない場合
            if (string.Empty.Equals(text))
            {
                errMessage = "エラーログファイル名を入力してください。";
                status = false;
            }
           
            //ディレクトリ存在しない場合
            if (status)
            {
                int dir_index = text.LastIndexOf("\\");
                int file_index = text.LastIndexOf(".");
                if (!Directory.Exists(text))
                {
                    //if (dir_index > 0 && file_index > 0 && text.Substring(file_index+1).ToUpper().Equals("CSV"))//DEL zhangy3 2012/06/28 FOR 内部発見バッグの対応
                    if (dir_index > 0 && file_index > 0)//ADD zhangy3 2012/06/28 FOR 内部発見バッグの対応
                    {
                        string errorLogFileDir = string.Empty;
                        if (file_index > dir_index)
                        {
                            errorLogFileDir = text.Substring(0, dir_index);
                        }
                        else
                        {
                            errorLogFileDir = text;
                        }
                        if (!Directory.Exists(errorLogFileDir))
                        {
                            //errMessage = "エラーログファイルパスが不正です。";//DEL zhangy3 2012/07/03 FOR Redmine#30387
                            errMessage = "CSVファイルパスが不正です。";//ADD zhangy3 2012/07/03 FOR Redmine#30387
                            status = false;
                        }
                    }
                    else
                    {
                        //errMessage = "エラーログファイルパスが不正です。";//DEL zhangy3 2012/07/03 FOR Redmine#30387
                        errMessage = "CSVファイルパスが不正です。";//ADD zhangy3 2012/07/03 FOR Redmine#30387
                        status = false;
                    }
                }
                else
                {
                    if(dir_index+1==text.Length)
                        //text = text + "_Error.CSV";//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
                        errLogPath = text + Guid.NewGuid().ToString() + ".CSV";//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
                    else
                        //text = text + "\\_Error.CSV";//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
                        errLogPath = text + "\\" + Guid.NewGuid().ToString() + ".CSV";//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
                   
                }
            }
            //パスの長さチェック
            if (status)
            {
                if (text.Length > 100)
                {
                    errMessage = "エラーログファイルが100桁以内で入力してください。";
                    status = false;
                }
            }
            //同じパスの場合
            if (status)
            {
                //if (fileName.Equals(text))//DEL zhangy3 2012/06/27 FOR 内部発見バッグの対応
                if (fileName.ToUpper().Equals(text.ToUpper()))//ADD zhangy3 2012/06/27 FOR 内部発見バッグの対応
                {
                    errMessage = "テキストファイル名とエラーログファイル名は同一の指定は出来ません。";
                    status = false;
                }
            }
            tEdit_LogFileName.DataText = text;
            //エラー存在の場合、メッセージを出る。
            if (!status)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    "",
                   errMessage,
                   0,
                   MessageBoxButtons.OK);
                tEdit_LogFileName.Focus();
            }
            return status;
        }
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        /// <summary>
        /// ベースにチェックエラーがあれば、フォーカスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースにチェックエラーがあれば、フォーカスの設定を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_ErrCnt.Text = "0";//Add zhangy3 2012/06/13 FOR Redmine#30391
            // テキストファイルのフォーカスの設定
            this.tEdit_TextFileName.Focus();
            return;
        }

        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="csvDataList">CSVファイル</param>
        /// <remarks>
        /// <br>Note	   : インポート処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
            string logPath = string.Empty;//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
            //インポート値のチェック
            //if (!ScreenInputCheck())//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
            if (!ScreenInputCheck(out logPath))//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<

            try
            {
                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "インポート中";
                form.Message = "現在、データをインポート中です。";
                // ダイアログ表示
                form.Show();

                this.uLabel_ReadCnt.Text = "0";
                this.uLabel_AddCnt.Text = "0";
                this.uLabel_UpdCnt.Text = "0";
                this.uLabel_ErrCnt.Text = "0";//Add zhangy3 2012/06/13 FOR Redmine#30391

                // 処理区分とCSVデータを設定する
                ExtrInfo_StockImportWorkTbl importWorkTbl = new ExtrInfo_StockImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.DataCheckKbn = (int)this.tComboEditor_DataCheckKbn.Value; // ADD ZHANGY3 2012/07/20 FOR REDMINE#30387

                string errMsg = string.Empty;
                //status = this._stockImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errMsg);//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
                //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                //エラーログパス
                //string logPath = tEdit_LogFileName.Text;//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
                //インポートの処理
                status = this._stockImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out this._errCnt, logPath, out errMsg);
                //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<

                // ダイアログを閉じる
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                        // エラー件数
                        this.uLabel_ErrCnt.Text = NumberFormat(this._errCnt);
                        if (this._errCnt > 0)
                        {
                            //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, logPath), 0);//DEL zhangy3 2012/06/29 FOR 内部発見バッグの対応
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, this.tEdit_LogFileName.DataText.Trim()), 0);//ADD zhangy3 2012/06/29 FOR 内部発見バッグの対応
                        }
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // 更新件数
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                        }
                        else
                        {
                            // 追加件数と更新件数が全てゼロの場合、メッセージを表示する
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により削除されています。", 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により更新されています。", 0);
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg = "在庫マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "在庫マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            return status;
        }
        #endregion  ◆ Public Method
        #endregion ■ IImportConditionInpType メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 入力項目の初期化を行う</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();

                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // 追加更新
                listItem0.DataValue = ct_AddUpdCd;
                listItem0.DisplayText = ct_AddUpdNm;

                // 追加
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = ct_AddCd;
                listItem1.DisplayText = ct_AddNm;

                // 更新
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = ct_UpdCd;
                listItem2.DisplayText = ct_UpdNm;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // 「追加更新」を選択されています
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                // ------------ADD ZHANGY3 2012/07/20 FOR Redmine#30387--------->>>>
                this.tComboEditor_DataCheckKbn.BeginUpdate();
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                // あり
                listItem3.DataValue = ct_DataCheckOn;
                listItem3.DisplayText = ct_DataCheckOnNm;
                // なし
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_DataCheckOff;
                listItem4.DisplayText = ct_DataCheckOffNm;
                this.tComboEditor_DataCheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // 「あり」を選択されています
                this.tComboEditor_DataCheckKbn.SelectedIndex = 0;
                this.tComboEditor_DataCheckKbn.EndUpdate();
                // ------------ADD ZHANGY3 2012/07/20 FOR Redmine#30387---------<<<<
                //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                this.uButton_LogFileGuide.ImageList = IconResourceManagement.ImageList16;
                //ｴﾗｰﾛｸﾞﾌｧｲﾙ名
                this.uButton_LogFileGuide.Appearance.Image = Size16_Index.STAR1;
                //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 画面初期化処理

        #region ◆ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br>Update Note : 2012/07/20 zhangy3 </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            saveCtrAry.Add(this.tEdit_TextFileName);
            // ------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387--------->>>>
            saveCtrAry.Add(this.tEdit_LogFileName);
            saveCtrAry.Add(this.tComboEditor_DataCheckKbn);
            // ------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387---------<<<<
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 数字のフォーマット
        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region ◆ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
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

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion ◆ エラーメッセージ表示処理
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN07640UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void PMKHN07650UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }

        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "取込ファイル選択";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }
                //「ファイルの種類」を指定
                openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
        /// <summary>
        /// エラーログCSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : エラーログCSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/06/13</br>
        /// </remarks>
        private void uButton_ErrorLogFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "エラーログファイル選択";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_LogFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_LogFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_LogFileName.Text);
                }
                //「ファイルの種類」を指定
                openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string text = openFileDialog.FileName;
                    if (text.Length > 100)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        "",
                        "エラーログファイルが100桁以内で入力してください。",
                       0,
                       MessageBoxButtons.OK);
                    }
                    else
                        this.tEdit_LogFileName.DataText = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// テキストファイル名変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : テキストファイル名変更された時発生します。</br> 
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/06/13</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //テキストファイル名
                string textFilePath = this.tEdit_TextFileName.DataText.Substring(0, this.tEdit_TextFileName.DataText.LastIndexOf('\\'));
                //テキストファイルパス名
                string textFileName = this.tEdit_TextFileName.DataText.Substring(this.tEdit_TextFileName.DataText.LastIndexOf('\\') + 1, this.tEdit_TextFileName.DataText.Length - 4 - this.tEdit_TextFileName.DataText.LastIndexOf('\\')-1);
                string errLogPath = textFilePath + "\\" + textFileName + "_Error.CSV";
                //ログのパス
                if (errLogPath.Length <= 100)
                {
                    this.tEdit_LogFileName.DataText = errLogPath;
                }
                else
                {
                    string errMessage = "エラーログファイルが100桁以内で入力してください。";
                   TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    "",
                   errMessage,
                   0,
                   MessageBoxButtons.OK);
                }
            }
            catch
            {
                return;
            }
        }
        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
        #region フォーカス移動イベント
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : 矢印キーでのフォーカス移動時に発生します</br>                 
        /// <br>Programmer  : 劉学智</br>                                   
        /// <br>Date        : 2009.06.03</br>                                       
        /// <br>Update Note : 2012/07/20 zhangy3 </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // 処理区分→テキストファイル名
                        //e.NextCtrl = this.tEdit_TextFileName;//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                        //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                        // 処理区分→チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→  倉庫(開始)
                        //e.NextCtrl = this.tComboEditor_ProcessKbn;//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                        //ファイルダイアログ→ エラーログﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_LogFileName;
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
                    }
                    //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        //エラーログﾌｧｲﾙ名→ エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        //エラーログファイルダイアログ→ 倉庫(開始)
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
                    //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // 処理区分→ファイルダイアログ
                        //e.NextCtrl = this.uButton_TextFileGuide;//DEL ZHANGY3 2012/06/13 FOR REDMINE#30391
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                        // 処理区分→エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                        //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // テキストファイル名→ 処理区分
                        //e.NextCtrl = this.tComboEditor_ProcessKbn;//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                        //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                        // テキストファイル名→ チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                    }
                    //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 --------------->>>>>>
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        //エラーログファイルダイアログ->エラーログﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        //エラーログﾌｧｲﾙ名->ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    //ADD ZHANGY3 2012/06/13 FOR REDMINE#30391 ---------------<<<<<<
                    //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→ 処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                }
            }
        }
        #endregion
        #endregion ■ Control Event

    }
}